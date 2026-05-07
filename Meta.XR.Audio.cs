using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Meta.XR.Acoustics;
using Meta.XR.Audio;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Meta.XR.Audio.Editor")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
internal sealed class MetaXRAcousticControlZone : MonoBehaviour
{
	[Serializable]
	internal class State
	{
		[SerializeField]
		internal Color color = Color.blue;

		[SerializeField]
		internal Spectrum rt60 = new Spectrum();

		[SerializeField]
		internal Spectrum reverbLevel = new Spectrum();

		[SerializeField]
		internal float fadeDistance = 1f;

		internal void Clone(State other)
		{
			color = other.color;
			reverbLevel.Clone(other.reverbLevel);
			rt60.Clone(other.rt60);
			fadeDistance = other.fadeDistance;
		}
	}

	[SerializeField]
	private State _state = new State();

	private IntPtr _controlHandle = IntPtr.Zero;

	internal State state => _state;

	internal Color ZoneColor
	{
		get
		{
			return _state.color;
		}
		set
		{
			_state.color = value;
		}
	}

	internal Spectrum Rt60
	{
		get
		{
			return _state.rt60;
		}
		set
		{
			_state.rt60 = value;
		}
	}

	internal Spectrum ReverbLevel
	{
		get
		{
			return _state.reverbLevel;
		}
		set
		{
			_state.reverbLevel = value;
		}
	}

	internal float FadeDistance
	{
		get
		{
			return _state.fadeDistance;
		}
		set
		{
			_state.fadeDistance = value;
			ApplyTransform();
		}
	}

	private Vector3 NativeFadeDistance => new Vector3(_state.fadeDistance / base.transform.localScale.x, _state.fadeDistance / base.transform.localScale.y, _state.fadeDistance / base.transform.localScale.z);

	private Vector3 NativeBoxSize => new Vector3(2f + NativeFadeDistance.x, 2f + NativeFadeDistance.y, 2f + NativeFadeDistance.z);

	internal void Clone(State other)
	{
		_state.Clone(other);
	}

	internal MetaXRAcousticControlZone()
	{
		Rt60.points = new List<Spectrum.Point>
		{
			new Spectrum.Point(1000f)
		};
		ReverbLevel.points = new List<Spectrum.Point>
		{
			new Spectrum.Point(1000f)
		};
	}

	private void Start()
	{
		StartInternal();
	}

	internal void StartInternal()
	{
		if (!(_controlHandle != IntPtr.Zero))
		{
			if (MetaXRAcousticNativeInterface.Interface.CreateControlZone(out _controlHandle) != 0)
			{
				UnityEngine.Debug.LogError("Unable to create internal Control Zone", base.gameObject);
			}
			else
			{
				ApplyProperties();
			}
		}
	}

	private void OnDestroy()
	{
		DestroyInternal();
	}

	internal void DestroyInternal()
	{
		if (_controlHandle != IntPtr.Zero)
		{
			MetaXRAcousticNativeInterface.Interface.DestroyControlZone(_controlHandle);
			_controlHandle = IntPtr.Zero;
		}
	}

	private void OnEnable()
	{
		if (!(_controlHandle == IntPtr.Zero))
		{
			MetaXRAcousticNativeInterface.Interface.ControlZoneSetEnabled(_controlHandle, enabled: true);
		}
	}

	private void OnDisable()
	{
		if (!(_controlHandle == IntPtr.Zero))
		{
			MetaXRAcousticNativeInterface.Interface.ControlZoneSetEnabled(_controlHandle, enabled: false);
		}
	}

	private void LateUpdate()
	{
		if (!(_controlHandle == IntPtr.Zero) && base.transform.hasChanged)
		{
			ApplyTransform();
			base.transform.hasChanged = false;
		}
	}

	private void ApplyTransform()
	{
		if (!(_controlHandle == IntPtr.Zero))
		{
			MetaXRAcousticNativeInterface.Interface.ControlZoneSetBox(_controlHandle, NativeBoxSize.x, NativeBoxSize.y, NativeBoxSize.z);
			MetaXRAcousticNativeInterface.Interface.ControlZoneSetFadeDistance(_controlHandle, NativeFadeDistance.x, NativeFadeDistance.y, NativeFadeDistance.z);
			MetaXRAcousticNativeInterface.Interface.ControlZoneSetTransform(_controlHandle, base.transform.localToWorldMatrix);
		}
	}

	internal void ApplyProperties()
	{
		if (_controlHandle == IntPtr.Zero)
		{
			return;
		}
		ApplyTransform();
		MetaXRAcousticNativeInterface.Interface.ControlZoneReset(_controlHandle, ControlZoneProperty.RT60);
		foreach (Spectrum.Point point in Rt60.points)
		{
			MetaXRAcousticNativeInterface.Interface.ControlZoneSetFrequency(_controlHandle, ControlZoneProperty.RT60, point.frequency, point.data);
		}
		MetaXRAcousticNativeInterface.Interface.ControlZoneReset(_controlHandle, ControlZoneProperty.REVERB_LEVEL);
		foreach (Spectrum.Point point2 in ReverbLevel.points)
		{
			MetaXRAcousticNativeInterface.Interface.ControlZoneSetFrequency(_controlHandle, ControlZoneProperty.REVERB_LEVEL, point2.frequency, point2.data);
		}
	}
}
internal class MetaXRAcousticGeometry : MonoBehaviour
{
	internal enum LoadState
	{
		NotLoaded,
		Loading,
		Interrupted,
		Loaded
	}

	private struct MeshMaterial
	{
		internal Mesh mesh;

		internal Transform meshTransform;

		internal IMaterialDataProvider[] meshMaterials;
	}

	private struct TerrainMaterial
	{
		internal Terrain terrain;

		internal IMaterialDataProvider[] terrainMaterials;

		internal Mesh[] treePrototypeMeshes;
	}

	internal interface ITransformVisitor
	{
		object visit(Transform transform, object userData);
	}

	private interface IGatherer : ITransformVisitor
	{
		List<MeshMaterial> Meshes { get; }

		List<TerrainMaterial> Terrains { get; }
	}

	private class MeshGatherer : IGatherer, ITransformVisitor
	{
		private List<MeshMaterial> meshes = new List<MeshMaterial>();

		private List<TerrainMaterial> terrains = new List<TerrainMaterial>();

		internal int ignoredMeshCount;

		internal bool ignoreStatic;

		public List<MeshMaterial> Meshes => meshes;

		public List<TerrainMaterial> Terrains => terrains;

		internal MeshGatherer(bool ignoreStatic)
		{
			this.ignoreStatic = ignoreStatic;
		}

		public object visit(Transform transform, object parentData)
		{
			IMaterialDataProvider[] array = parentData as IMaterialDataProvider[];
			MeshFilter[] components = transform.GetComponents<MeshFilter>();
			Terrain[] components2 = transform.GetComponents<Terrain>();
			IMaterialDataProvider[] array2 = Array.ConvertAll((from x in transform.GetComponents<MetaXRAcousticMaterial>()
				where x.enabled
				select x).ToArray(), (MetaXRAcousticMaterial x) => x);
			IMaterialDataProvider[] array3 = array2;
			if (array3 != null && array3.Length != 0)
			{
				int num = array3.Length;
				if (array != null && array.Length > num)
				{
					num = array.Length;
				}
				IMaterialDataProvider[] array4 = new IMaterialDataProvider[num];
				if (array != null)
				{
					for (int num2 = array3.Length; num2 < num; num2++)
					{
						array4[num2] = array[num2];
					}
				}
				array = array4;
				for (int num3 = 0; num3 < array3.Length; num3++)
				{
					array[num3] = array3[num3];
				}
			}
			MeshFilter[] array5 = components;
			foreach (MeshFilter meshFilter in array5)
			{
				Mesh sharedMesh = meshFilter.sharedMesh;
				if (!(sharedMesh == null))
				{
					if (ignoreStatic && (!sharedMesh.isReadable || transform.gameObject.isStatic))
					{
						UnityEngine.Debug.LogError("Mesh: " + meshFilter.gameObject.name + " not readable. Use \"File Enabled\" for static geometry", transform);
						ignoredMeshCount++;
						continue;
					}
					meshes.Add(new MeshMaterial
					{
						mesh = sharedMesh,
						meshTransform = transform,
						meshMaterials = array
					});
				}
			}
			Terrain[] array6 = components2;
			foreach (Terrain terrain in array6)
			{
				terrains.Add(new TerrainMaterial
				{
					terrain = terrain,
					terrainMaterials = array
				});
			}
			return array;
		}
	}

	private class ColliderGatherer : IGatherer, ITransformVisitor
	{
		private List<MeshMaterial> meshes = new List<MeshMaterial>();

		private List<TerrainMaterial> terrains = new List<TerrainMaterial>();

		public List<MeshMaterial> Meshes => meshes;

		public List<TerrainMaterial> Terrains => terrains;

		public object visit(Transform transform, object parentData)
		{
			IMaterialDataProvider[] array = Array.ConvertAll((from x in transform.GetComponents<MetaXRAcousticMaterial>()
				where x.enabled
				select x).ToArray(), (MetaXRAcousticMaterial x) => x);
			IMaterialDataProvider[] array2 = array;
			MeshCollider[] components = transform.GetComponents<MeshCollider>();
			foreach (MeshCollider meshCollider in components)
			{
				if (meshCollider.sharedMesh == null)
				{
					continue;
				}
				if (array2.Length == 0)
				{
					MetaXRAcousticMaterialProperties metaXRAcousticMaterialProperties = MetaXRAcousticMaterialMapping.Instance.findAcousticMaterial(meshCollider.sharedMaterial);
					if (metaXRAcousticMaterialProperties != null)
					{
						array2 = new IMaterialDataProvider[1] { metaXRAcousticMaterialProperties };
					}
				}
				meshes.Add(new MeshMaterial
				{
					mesh = meshCollider.sharedMesh,
					meshTransform = transform,
					meshMaterials = array2
				});
			}
			BoxCollider[] components2 = transform.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider in components2)
			{
				Mesh mesh = new Mesh();
				Vector3[] vertices = new Vector3[8]
				{
					boxCollider.center + Vector3.Scale(boxCollider.size * 0.5f, new Vector3(1f, 1f, 1f)),
					boxCollider.center + Vector3.Scale(boxCollider.size * 0.5f, new Vector3(1f, 1f, -1f)),
					boxCollider.center + Vector3.Scale(boxCollider.size * 0.5f, new Vector3(1f, -1f, 1f)),
					boxCollider.center + Vector3.Scale(boxCollider.size * 0.5f, new Vector3(1f, -1f, -1f)),
					boxCollider.center + Vector3.Scale(boxCollider.size * 0.5f, new Vector3(-1f, 1f, 1f)),
					boxCollider.center + Vector3.Scale(boxCollider.size * 0.5f, new Vector3(-1f, 1f, -1f)),
					boxCollider.center + Vector3.Scale(boxCollider.size * 0.5f, new Vector3(-1f, -1f, 1f)),
					boxCollider.center + Vector3.Scale(boxCollider.size * 0.5f, new Vector3(-1f, -1f, -1f))
				};
				int[] indices = new int[24]
				{
					1, 0, 2, 3, 0, 4, 6, 2, 4, 5,
					7, 6, 5, 1, 3, 7, 1, 5, 4, 0,
					2, 6, 7, 3
				};
				mesh.vertices = vertices;
				mesh.SetIndices(indices, MeshTopology.Quads, 0);
				if (array2.Length == 0)
				{
					MetaXRAcousticMaterialProperties metaXRAcousticMaterialProperties2 = MetaXRAcousticMaterialMapping.Instance.findAcousticMaterial(boxCollider.sharedMaterial);
					if (metaXRAcousticMaterialProperties2 != null)
					{
						array2 = new IMaterialDataProvider[1] { metaXRAcousticMaterialProperties2 };
					}
				}
				meshes.Add(new MeshMaterial
				{
					mesh = mesh,
					meshTransform = transform,
					meshMaterials = array2
				});
			}
			return null;
		}
	}

	internal static bool AUTO_VALIDATE = true;

	internal const string FILE_EXTENSION = "xrageo";

	internal static int EnabledGeometryCount = 0;

	[SerializeField]
	[FormerlySerializedAs("relativeFilePath_")]
	private string relativeFilePath = "";

	[SerializeField]
	internal bool FileEnabled = true;

	[SerializeField]
	internal bool IncludeChildMeshes = true;

	[SerializeField]
	internal MeshFlags Flags = MeshFlags.ENABLE_SIMPLIFICATION;

	[SerializeField]
	private float maxSimplifyError = 0.1f;

	[SerializeField]
	private float minDiffractionEdgeAngle = 1f;

	[SerializeField]
	private float minDiffractionEdgeLength = 0.01f;

	[SerializeField]
	private float flagLength = 1f;

	[SerializeField]
	private int lodSelection;

	[SerializeField]
	private bool useColliders;

	[SerializeField]
	private bool overrideExcludeTagsEnabled;

	[SerializeField]
	private string[] overrideExcludeTags;

	[NonSerialized]
	internal IntPtr geometryHandle = IntPtr.Zero;

	[NonSerialized]
	internal LoadState loadState_;

	[NonSerialized]
	private int vertexCount = -1;

	[SerializeField]
	private Color[] materialColors;

	[SerializeField]
	private Hash128 HierarchyHash;

	internal const int Success = 0;

	private static int terrainDecimation;

	internal string RelativeFilePath => relativeFilePath;

	internal string AbsoluteFilePath
	{
		get
		{
			return Path.GetFullPath(Path.Combine(Application.dataPath, RelativeFilePath));
		}
		set
		{
			string text = value.Replace('\\', '/');
			if (text.StartsWith(Application.dataPath))
			{
				relativeFilePath = text.Substring(Application.dataPath.Length + 1);
			}
			else
			{
				UnityEngine.Debug.LogError("invalid path " + value + ", outside application path " + Application.dataPath, base.gameObject);
			}
		}
	}

	internal bool EnableSimplification
	{
		get
		{
			return (Flags & MeshFlags.ENABLE_SIMPLIFICATION) != 0;
		}
		set
		{
			if (value)
			{
				Flags |= MeshFlags.ENABLE_SIMPLIFICATION;
			}
			else
			{
				Flags &= ~MeshFlags.ENABLE_SIMPLIFICATION;
			}
		}
	}

	internal bool EnableDiffraction
	{
		get
		{
			return (Flags & MeshFlags.ENABLE_DIFFRACTION) != 0;
		}
		set
		{
			if (value)
			{
				Flags |= MeshFlags.ENABLE_DIFFRACTION;
			}
			else
			{
				Flags &= ~MeshFlags.ENABLE_DIFFRACTION;
			}
		}
	}

	internal float MaxSimplifyError
	{
		get
		{
			return maxSimplifyError;
		}
		set
		{
			maxSimplifyError = Math.Max(value, 0f);
		}
	}

	internal float MinDiffractionEdgeAngle
	{
		get
		{
			return minDiffractionEdgeAngle;
		}
		set
		{
			minDiffractionEdgeAngle = Math.Clamp(value, 0f, 180f);
		}
	}

	internal float MinDiffractionEdgeLength
	{
		get
		{
			return minDiffractionEdgeLength;
		}
		set
		{
			minDiffractionEdgeLength = Math.Max(value, 0f);
		}
	}

	internal float FlagLength
	{
		get
		{
			return flagLength;
		}
		set
		{
			flagLength = value;
		}
	}

	internal int LodSelection
	{
		get
		{
			return lodSelection;
		}
		set
		{
			lodSelection = value;
		}
	}

	internal bool UseColliders
	{
		get
		{
			return useColliders;
		}
		set
		{
			useColliders = value;
		}
	}

	internal bool OverrideExcludeTagsEnabled
	{
		get
		{
			return overrideExcludeTagsEnabled;
		}
		set
		{
			overrideExcludeTagsEnabled = value;
		}
	}

	internal string[] OverrideExcludeTags
	{
		get
		{
			return overrideExcludeTags;
		}
		set
		{
			overrideExcludeTags = value;
		}
	}

	internal string[] ExcludeTags
	{
		get
		{
			if (!OverrideExcludeTagsEnabled)
			{
				return MetaXRAcousticSettings.Instance.ExcludeTags;
			}
			return OverrideExcludeTags;
		}
	}

	internal bool IsLoaded => loadState_ == LoadState.Loaded;

	internal int VertexCount => vertexCount;

	internal static event Action OnAnyGeometryEnabled;

	private void Awake()
	{
		StartInternal();
	}

	internal bool StartInternal()
	{
		if (!CreatePropagationGeometry())
		{
			return false;
		}
		ApplyTransform();
		return true;
	}

	internal bool CreatePropagationGeometry()
	{
		if (geometryHandle != IntPtr.Zero)
		{
			UnityEngine.Debug.LogWarning("Tried to initialize geometry twice, destroying stale copy", base.gameObject);
			DestroyPropagationGeometry();
		}
		if (geometryHandle != IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Unable to clean up stale geometry", base.gameObject);
			return false;
		}
		if (MetaXRAcousticNativeInterface.Interface.CreateAudioGeometry(out geometryHandle) != 0)
		{
			UnityEngine.Debug.LogError("Unable to create geometry handle", base.gameObject);
			return false;
		}
		if (FileEnabled)
		{
			if (string.IsNullOrEmpty(relativeFilePath))
			{
				if (Application.isPlaying)
				{
					UnityEngine.Debug.LogError("No file set, make sure to Bake Mesh to File", base.gameObject);
				}
				return false;
			}
			if (!ReadFile())
			{
				return false;
			}
		}
		else if (Application.isPlaying)
		{
			if (base.gameObject.isStatic)
			{
				UnityEngine.Debug.LogError("Static geometry requires \"File Enabled\"", base.gameObject);
				return false;
			}
			if (!GatherGeometryRuntime())
			{
				return false;
			}
		}
		return true;
	}

	private void IncrementEnabledGeometryCount()
	{
		EnabledGeometryCount++;
		if (EnabledGeometryCount == 1)
		{
			MetaXRAcousticGeometry.OnAnyGeometryEnabled();
		}
	}

	private void DecrementEnabledGeometryCount()
	{
		EnabledGeometryCount--;
	}

	private void OnEnable()
	{
		if (loadState_ == LoadState.Interrupted)
		{
			UnityEngine.Debug.Log("Resuming interrupted load!!");
			ReadFile();
		}
		else if (!(geometryHandle == IntPtr.Zero) && (loadState_ != LoadState.NotLoaded || !FileEnabled))
		{
			UnityEngine.Debug.Log("Enabling Geometry: " + relativeFilePath, base.gameObject);
			MetaXRAcousticNativeInterface.Interface.AudioGeometrySetObjectFlag(geometryHandle, ObjectFlags.ENABLED, enabled: true);
			ApplyTransform();
			MetaXRAcousticNativeInterface.Interface.AudioGeometrySetObjectFlag(geometryHandle, ObjectFlags.STATIC, base.gameObject.isStatic);
			if (IsLoaded)
			{
				IncrementEnabledGeometryCount();
			}
		}
	}

	private void OnDisable()
	{
		if (!(geometryHandle == IntPtr.Zero))
		{
			UnityEngine.Debug.Log("Disabling Geometry: " + relativeFilePath, base.gameObject);
			if (loadState_ == LoadState.Loading && !base.gameObject.activeInHierarchy)
			{
				UnityEngine.Debug.Log("Interrupted load!!");
				loadState_ = LoadState.Interrupted;
			}
			MetaXRAcousticNativeInterface.Interface.AudioGeometrySetObjectFlag(geometryHandle, ObjectFlags.ENABLED, enabled: false);
			ApplyTransform();
			MetaXRAcousticNativeInterface.Interface.AudioGeometrySetObjectFlag(geometryHandle, ObjectFlags.STATIC, base.gameObject.isStatic);
			if (IsLoaded)
			{
				DecrementEnabledGeometryCount();
			}
		}
	}

	private void LateUpdate()
	{
		if (!(geometryHandle == IntPtr.Zero) && base.transform.hasChanged)
		{
			ApplyTransform();
			base.transform.hasChanged = false;
		}
	}

	private void ApplyTransform()
	{
		if (!(geometryHandle == IntPtr.Zero))
		{
			MetaXRAcousticNativeInterface.Interface.AudioGeometrySetTransform(geometryHandle, base.transform.localToWorldMatrix);
		}
	}

	private void OnDestroy()
	{
		DestroyInternal();
	}

	internal bool DestroyInternal()
	{
		if (!DestroyPropagationGeometry())
		{
			return false;
		}
		return true;
	}

	private bool DestroyPropagationGeometry()
	{
		lock (this)
		{
			if (geometryHandle != IntPtr.Zero && MetaXRAcousticNativeInterface.Interface.DestroyAudioGeometry(geometryHandle) != 0)
			{
				UnityEngine.Debug.LogError("Unable to destroy geometry", base.gameObject);
				return false;
			}
			geometryHandle = IntPtr.Zero;
			return true;
		}
	}

	private static bool isObjectUsedByLODGroup(GameObject obj, LODGroup lod)
	{
		LOD[] lODs = lod.GetLODs();
		for (int i = 0; i < lODs.Length; i++)
		{
			Renderer[] renderers = lODs[i].renderers;
			for (int j = 0; j < renderers.Length; j++)
			{
				if (renderers[j].gameObject == obj)
				{
					return true;
				}
			}
		}
		return false;
	}

	private static void traverseMeshHierarchy(GameObject obj, bool includeChildren, string[] excludeTags, bool parentWasExcluded, int lodSelection, LODGroup parentLOD, ITransformVisitor visitor, object parentData = null)
	{
		if (!obj.activeInHierarchy)
		{
			return;
		}
		LODGroup lODGroup = obj.GetComponent(typeof(LODGroup)) as LODGroup;
		if (lODGroup != null)
		{
			LOD[] lODs = lODGroup.GetLODs();
			if (lODs.Length != 0)
			{
				if (lODs.Length == 1 && lODs[0].renderers.Length == 1)
				{
					obj = lODs[0].renderers[0].gameObject;
				}
				else
				{
					int num = Mathf.Clamp(lodSelection, 0, lODs.Length - 1);
					Renderer[] renderers = lODs[num].renderers;
					for (int i = 0; i < renderers.Length; i++)
					{
						if (renderers[i] != null && !(renderers[i].gameObject == obj))
						{
							traverseMeshHierarchy(renderers[i].gameObject, includeChildren, excludeTags, parentWasExcluded, lodSelection, null, visitor, parentData);
						}
					}
				}
				parentLOD = lODGroup;
			}
		}
		bool flag = true;
		bool flag2 = parentLOD != lODGroup && parentLOD != null && isObjectUsedByLODGroup(obj, parentLOD);
		if (Enumerable.Contains(excludeTags, obj.tag) || parentWasExcluded || flag2)
		{
			MetaXRAcousticMaterial component = obj.GetComponent<MetaXRAcousticMaterial>();
			flag = ((!(component == null) && component.enabled) ? true : false);
		}
		if (flag)
		{
			parentData = visitor.visit(obj.transform, parentData);
		}
		if (!includeChildren)
		{
			return;
		}
		foreach (Transform item in obj.transform)
		{
			if (item.GetComponent<MetaXRAcousticGeometry>() == null)
			{
				traverseMeshHierarchy(item.gameObject, includeChildren, excludeTags, !flag, lodSelection, parentLOD, visitor, parentData);
			}
		}
	}

	private bool GatherGeometryInternal(IntPtr geometryHandle, GameObject meshObject, Matrix4x4 worldToLocal, bool ignoreStatic, out int ignoredMeshCount)
	{
		ignoredMeshCount = 0;
		IGatherer gatherer = ((!useColliders) ? ((IGatherer)new MeshGatherer(ignoreStatic)) : ((IGatherer)new ColliderGatherer()));
		traverseMeshHierarchy(meshObject, IncludeChildMeshes, ExcludeTags, parentWasExcluded: false, lodSelection, null, gatherer);
		int totalVertexCount = 0;
		uint totalIndexCount = 0u;
		int totalFaceCount = 0;
		int totalMaterialCount = 0;
		foreach (MeshMaterial mesh in gatherer.Meshes)
		{
			updateCountsForMesh(ref totalVertexCount, ref totalIndexCount, ref totalFaceCount, ref totalMaterialCount, mesh.mesh);
		}
		IMaterialDataProvider[] array = new IMaterialDataProvider[1];
		for (int i = 0; i < gatherer.Terrains.Count; i++)
		{
			TerrainMaterial value = gatherer.Terrains[i];
			TerrainData terrainData = value.terrain.terrainData;
			int heightmapResolution = terrainData.heightmapResolution;
			int heightmapResolution2 = terrainData.heightmapResolution;
			int num = (heightmapResolution - 1) / terrainDecimation + 1;
			int num2 = (heightmapResolution2 - 1) / terrainDecimation + 1;
			int num3 = num * num2;
			int num4 = (num - 1) * (num2 - 1) * 6;
			totalMaterialCount++;
			totalVertexCount += num3;
			totalIndexCount += (uint)num4;
			totalFaceCount += num4 / 3;
			TreePrototype[] treePrototypes = terrainData.treePrototypes;
			if (treePrototypes.Length == 0)
			{
				continue;
			}
			if (array[0] == null)
			{
				array[0] = value.terrainMaterials.Last();
			}
			value.treePrototypeMeshes = new Mesh[treePrototypes.Length];
			for (int j = 0; j < treePrototypes.Length; j++)
			{
				MeshFilter[] componentsInChildren = treePrototypes[j].prefab.GetComponentsInChildren<MeshFilter>();
				int num5 = int.MaxValue;
				int num6 = -1;
				for (int k = 0; k < componentsInChildren.Length; k++)
				{
					int num7 = componentsInChildren[k].sharedMesh.vertexCount;
					if (num7 < num5)
					{
						num5 = num7;
						num6 = k;
					}
				}
				value.treePrototypeMeshes[j] = componentsInChildren[num6].sharedMesh;
			}
			TreeInstance[] treeInstances = terrainData.treeInstances;
			for (int l = 0; l < treeInstances.Length; l++)
			{
				TreeInstance treeInstance = treeInstances[l];
				updateCountsForMesh(ref totalVertexCount, ref totalIndexCount, ref totalFaceCount, ref totalMaterialCount, value.treePrototypeMeshes[treeInstance.prototypeIndex]);
			}
			gatherer.Terrains[i] = value;
		}
		List<Vector3> tempVertices = new List<Vector3>();
		List<int> tempIndices = new List<int>();
		MeshGroup[] array2 = new MeshGroup[totalMaterialCount];
		float[] array3 = new float[totalVertexCount * 3];
		int[] array4 = new int[totalIndexCount];
		int vertexOffset = 0;
		int indexOffset = 0;
		int groupOffset = 0;
		foreach (MeshMaterial mesh2 in gatherer.Meshes)
		{
			Matrix4x4 matrix = worldToLocal * mesh2.meshTransform.localToWorldMatrix;
			if (!uploadMeshFilter(tempVertices, tempIndices, array2, array3, array4, ref vertexOffset, ref indexOffset, ref groupOffset, mesh2.mesh, mesh2.meshMaterials, matrix))
			{
				return false;
			}
		}
		foreach (TerrainMaterial terrain in gatherer.Terrains)
		{
			TerrainData terrainData2 = terrain.terrain.terrainData;
			Matrix4x4 matrix4x = worldToLocal * terrain.terrain.gameObject.transform.localToWorldMatrix;
			int heightmapResolution3 = terrainData2.heightmapResolution;
			int heightmapResolution4 = terrainData2.heightmapResolution;
			float[,] heights = terrainData2.GetHeights(0, 0, heightmapResolution3, heightmapResolution4);
			Vector3 size = terrainData2.size;
			size = new Vector3(size.x / (float)(heightmapResolution3 - 1) * (float)terrainDecimation, size.y, size.z / (float)(heightmapResolution4 - 1) * (float)terrainDecimation);
			int num8 = (heightmapResolution3 - 1) / terrainDecimation + 1;
			int num9 = (heightmapResolution4 - 1) / terrainDecimation + 1;
			int num10 = num8 * num9;
			int num11 = (num8 - 1) * (num9 - 1) * 2;
			array2[groupOffset].faceType = FaceType.TRIANGLES;
			array2[groupOffset].faceCount = (UIntPtr)(ulong)num11;
			array2[groupOffset].indexOffset = (UIntPtr)(ulong)indexOffset;
			if (terrain.terrainMaterials != null && terrain.terrainMaterials.Length != 0)
			{
				array2[groupOffset].material = MetaXRAcousticMaterial.CreateMaterialNativeHandle(terrain.terrainMaterials[0].Data);
			}
			else
			{
				array2[groupOffset].material = IntPtr.Zero;
			}
			for (int m = 0; m < num9; m++)
			{
				for (int n = 0; n < num8; n++)
				{
					int num12 = (vertexOffset + m * num8 + n) * 3;
					Vector3 vector = matrix4x.MultiplyPoint3x4(Vector3.Scale(size, new Vector3(m, heights[n * terrainDecimation, m * terrainDecimation], n)));
					array3[num12] = vector.x;
					array3[num12 + 1] = vector.y;
					array3[num12 + 2] = vector.z;
				}
			}
			for (int num13 = 0; num13 < num9 - 1; num13++)
			{
				for (int num14 = 0; num14 < num8 - 1; num14++)
				{
					array4[indexOffset] = vertexOffset + num13 * num8 + num14;
					array4[indexOffset + 1] = vertexOffset + (num13 + 1) * num8 + num14;
					array4[indexOffset + 2] = vertexOffset + num13 * num8 + num14 + 1;
					array4[indexOffset + 3] = vertexOffset + (num13 + 1) * num8 + num14;
					array4[indexOffset + 4] = vertexOffset + (num13 + 1) * num8 + num14 + 1;
					array4[indexOffset + 5] = vertexOffset + num13 * num8 + num14 + 1;
					indexOffset += 6;
				}
			}
			vertexOffset += num10;
			groupOffset++;
			TreeInstance[] treeInstances = terrainData2.treeInstances;
			for (int l = 0; l < treeInstances.Length; l++)
			{
				TreeInstance treeInstance2 = treeInstances[l];
				Vector3 vector2 = Vector3.Scale(treeInstance2.position, terrainData2.size);
				Matrix4x4 localToWorldMatrix = terrain.terrain.gameObject.transform.localToWorldMatrix;
				localToWorldMatrix.SetColumn(3, localToWorldMatrix.GetColumn(3) + new Vector4(vector2.x, vector2.y, vector2.z, 0f));
				Matrix4x4 matrix2 = worldToLocal * localToWorldMatrix;
				if (!uploadMeshFilter(tempVertices, tempIndices, array2, array3, array4, ref vertexOffset, ref indexOffset, ref groupOffset, terrain.treePrototypeMeshes[treeInstance2.prototypeIndex], array, matrix2))
				{
					return false;
				}
			}
		}
		if (totalVertexCount == 0)
		{
			_ = base.gameObject.scene;
			string text = base.gameObject.scene.name + ":" + string.Join("/", (from t in base.gameObject.GetComponentsInParent<Transform>()
				select t.name).Reverse().ToArray());
			UnityEngine.Debug.LogError("Geometry unable to upload mesh, vertex count is zero " + text, base.gameObject);
			return false;
		}
		UnityEngine.Debug.Log($"Uploading mesh {base.name} with {totalVertexCount} vertices");
		MeshSimplification simplification = new MeshSimplification
		{
			thisSize = (UIntPtr)(ulong)Marshal.SizeOf(typeof(MeshSimplification)),
			flags = Flags,
			unitScale = 1f,
			maxError = MaxSimplifyError,
			minDiffractionEdgeAngle = MinDiffractionEdgeAngle,
			minDiffractionEdgeLength = MinDiffractionEdgeLength,
			flagLength = FlagLength,
			threadCount = (UIntPtr)1uL
		};
		int num15 = MetaXRAcousticNativeInterface.Interface.AudioGeometryUploadSimplifiedMeshArrays(geometryHandle, array3, totalVertexCount, array4, array4.Length, array2, array2.Length, ref simplification);
		MetaXRAcousticNativeInterface.Interface.AudioGeometrySetObjectFlag(geometryHandle, ObjectFlags.ENABLED, base.isActiveAndEnabled);
		MetaXRAcousticNativeInterface.Interface.AudioGeometrySetObjectFlag(geometryHandle, ObjectFlags.STATIC, base.gameObject.isStatic);
		MeshGroup[] array5 = array2;
		for (int l = 0; l < array5.Length; l++)
		{
			MeshGroup meshGroup = array5[l];
			MetaXRAcousticMaterial.DestroyMaterialNativeHandle(meshGroup.material);
		}
		if (num15 == 0)
		{
			List<IMaterialDataProvider> list = new List<IMaterialDataProvider>();
			foreach (MeshMaterial mesh3 in gatherer.Meshes)
			{
				int num16 = 0;
				int subMeshCount = mesh3.mesh.subMeshCount;
				int num17 = ((mesh3.meshMaterials != null) ? mesh3.meshMaterials.Length : 0);
				if (num17 != 0)
				{
					int num18 = Mathf.Min(num17, subMeshCount);
					for (num16 = 0; num16 < num18; num16++)
					{
						list.Add(mesh3.meshMaterials[num16]);
					}
					for (num16 = num18; num16 < subMeshCount; num16++)
					{
						list.Add(mesh3.meshMaterials[num17 - 1]);
					}
				}
				else
				{
					for (int num19 = 0; num19 < subMeshCount; num19++)
					{
						list.Add(null);
					}
				}
			}
			foreach (TerrainMaterial terrain2 in gatherer.Terrains)
			{
				if (terrain2.terrainMaterials != null && terrain2.terrainMaterials.Length != 0)
				{
					list.AddRange(terrain2.terrainMaterials);
				}
			}
			return true;
		}
		return false;
	}

	private static bool uploadMeshFilter(List<Vector3> tempVertices, List<int> tempIndices, MeshGroup[] groups, float[] vertices, int[] indices, ref int vertexOffset, ref int indexOffset, ref int groupOffset, Mesh mesh, IMaterialDataProvider[] materials, Matrix4x4 matrix)
	{
		tempVertices.Clear();
		mesh.GetVertices(tempVertices);
		int count = tempVertices.Count;
		for (int i = 0; i < count; i++)
		{
			Vector3 vector = matrix.MultiplyPoint3x4(tempVertices[i]);
			int num = (vertexOffset + i) * 3;
			vertices[num] = vector.x;
			vertices[num + 1] = vector.y;
			vertices[num + 2] = vector.z;
		}
		for (int j = 0; j < mesh.subMeshCount; j++)
		{
			MeshTopology topology = mesh.GetTopology(j);
			if (topology != MeshTopology.Triangles && topology != MeshTopology.Quads)
			{
				continue;
			}
			tempIndices.Clear();
			mesh.GetIndices(tempIndices, j);
			int count2 = tempIndices.Count;
			for (int k = 0; k < count2; k++)
			{
				indices[indexOffset + k] = tempIndices[k] + vertexOffset;
			}
			switch (topology)
			{
			case MeshTopology.Triangles:
				groups[groupOffset + j].faceType = FaceType.TRIANGLES;
				groups[groupOffset + j].faceCount = (UIntPtr)(ulong)(count2 / 3);
				break;
			case MeshTopology.Quads:
				groups[groupOffset + j].faceType = FaceType.QUADS;
				groups[groupOffset + j].faceCount = (UIntPtr)(ulong)(count2 / 4);
				break;
			}
			groups[groupOffset + j].indexOffset = (UIntPtr)(ulong)indexOffset;
			if (materials != null && materials.Length != 0)
			{
				int num2 = j;
				if (num2 >= materials.Length)
				{
					num2 = materials.Length - 1;
				}
				groups[groupOffset + j].material = MetaXRAcousticMaterial.CreateMaterialNativeHandle(materials[num2].Data);
			}
			else
			{
				groups[groupOffset + j].material = IntPtr.Zero;
			}
			indexOffset += count2;
		}
		vertexOffset += count;
		groupOffset += mesh.subMeshCount;
		return true;
	}

	private static void updateCountsForMesh(ref int totalVertexCount, ref uint totalIndexCount, ref int totalFaceCount, ref int totalMaterialCount, Mesh mesh)
	{
		totalMaterialCount += mesh.subMeshCount;
		totalVertexCount += mesh.vertexCount;
		for (int i = 0; i < mesh.subMeshCount; i++)
		{
			MeshTopology topology = mesh.GetTopology(i);
			if (topology == MeshTopology.Triangles || topology == MeshTopology.Quads)
			{
				uint indexCount = mesh.GetIndexCount(i);
				totalIndexCount += indexCount;
				switch (topology)
				{
				case MeshTopology.Triangles:
					totalFaceCount += (int)indexCount / 3;
					break;
				case MeshTopology.Quads:
					totalFaceCount += (int)indexCount / 4;
					break;
				}
			}
		}
	}

	internal bool GatherGeometryRuntime()
	{
		UnityEngine.Debug.Log("Gathering geometry");
		if (!GatherGeometryInternal(geometryHandle, base.gameObject, base.gameObject.transform.worldToLocalMatrix, Application.isPlaying, out var ignoredMeshCount))
		{
			return false;
		}
		if (ignoredMeshCount != 0)
		{
			UnityEngine.Debug.LogWarning($"Failed to upload meshes, {ignoredMeshCount} static meshes ignored. Turn on \"File Enabled\" to process static meshes offline", base.gameObject);
		}
		return true;
	}

	internal bool ReadFile()
	{
		if (string.IsNullOrEmpty(AbsoluteFilePath))
		{
			UnityEngine.Debug.LogError("Invalid mesh file path", base.gameObject);
			return false;
		}
		int num = AbsoluteFilePath.IndexOf("StreamingAssets");
		if (Application.isPlaying && num > 0)
		{
			string relativePath = AbsoluteFilePath.Substring(num + 16);
			StartCoroutine(LoadGeometryAsync(relativePath));
		}
		else
		{
			if (MetaXRAcousticNativeInterface.Interface.AudioGeometryReadMeshFile(geometryHandle, AbsoluteFilePath) != 0)
			{
				UnityEngine.Debug.LogError("Error reading mesh file " + AbsoluteFilePath, base.gameObject);
				return false;
			}
			MetaXRAcousticNativeInterface.Interface.AudioGeometrySetObjectFlag(geometryHandle, ObjectFlags.ENABLED, base.isActiveAndEnabled);
			ApplyTransform();
			MetaXRAcousticNativeInterface.Interface.AudioGeometrySetObjectFlag(geometryHandle, ObjectFlags.STATIC, base.gameObject.isStatic);
		}
		return true;
	}

	private IEnumerator LoadGeometryAsync(string relativePath)
	{
		string text = Application.streamingAssetsPath + "/" + relativePath;
		UnityEngine.Debug.Log("Loading Geometry " + base.name + " from StreamingAssets " + text, base.gameObject);
		float startTime = Time.realtimeSinceStartup;
		UnityWebRequest unityWebRequest = UnityWebRequest.Get(text);
		loadState_ = LoadState.Loading;
		yield return unityWebRequest.SendWebRequest();
		if (!string.IsNullOrEmpty(unityWebRequest.error))
		{
			UnityEngine.Debug.LogError($"web request: done={unityWebRequest.isDone}: {unityWebRequest.error}", base.gameObject);
		}
		float num = Time.realtimeSinceStartup - startTime;
		UnityEngine.Debug.Log($"Geometry {base.name}, read time = {num}", base.gameObject);
		LoadGeometryFromMemory(unityWebRequest.downloadHandler.nativeData);
	}

	private unsafe async void LoadGeometryFromMemory(NativeArray<byte>.ReadOnly data)
	{
		if (data.Length == 0)
		{
			return;
		}
		float startTime = Time.realtimeSinceStartup;
		int result = -1;
		await Task.Run(delegate
		{
			IntPtr data2 = (IntPtr)data.GetUnsafeReadOnlyPtr();
			lock (this)
			{
				if (geometryHandle != IntPtr.Zero)
				{
					result = MetaXRAcousticNativeInterface.Interface.AudioGeometryReadMeshMemory(geometryHandle, data2, (ulong)data.Length);
					GC.KeepAlive(data);
				}
			}
		});
		if (result == 0)
		{
			float num = Time.realtimeSinceStartup - startTime;
			UnityEngine.Debug.Log($"Sucessfully loaded Geometry {base.name}, load time = {num}", base.gameObject);
			MetaXRAcousticNativeInterface.Interface.AudioGeometrySetObjectFlag(geometryHandle, ObjectFlags.ENABLED, base.isActiveAndEnabled);
			ApplyTransform();
			MetaXRAcousticNativeInterface.Interface.AudioGeometrySetObjectFlag(geometryHandle, ObjectFlags.STATIC, base.gameObject.isStatic);
			loadState_ = LoadState.Loaded;
			if (base.isActiveAndEnabled)
			{
				IncrementEnabledGeometryCount();
			}
		}
		else
		{
			UnityEngine.Debug.Log("Unable to read the geometry " + base.name, base.gameObject);
		}
	}

	static MetaXRAcousticGeometry()
	{
		MetaXRAcousticGeometry.OnAnyGeometryEnabled = delegate
		{
		};
		terrainDecimation = 4;
	}
}
internal class MetaXRAcousticMap : MonoBehaviour
{
	internal const string FILE_EXTENSION = "xramap";

	[SerializeField]
	internal MetaXRAcousticSceneGroup SceneGroup;

	[SerializeField]
	internal bool customPointsEnabled;

	[NonSerialized]
	internal bool IsLoaded;

	[SerializeField]
	internal AcousticMapFlags Flags = AcousticMapFlags.NO_FLOATING | AcousticMapFlags.DIFFRACTION;

	internal const float DISTANCE_PARAMETER_MAX = 10000f;

	[SerializeField]
	internal uint ReflectionCount = 6u;

	[SerializeField]
	[Range(0f, 10000f)]
	internal float MinSpacing = 1f;

	[SerializeField]
	[Range(0f, 10000f)]
	internal float MaxSpacing = 10f;

	[SerializeField]
	[Range(0f, 10000f)]
	internal float HeadHeight = 1.5f;

	[SerializeField]
	[Range(0f, 10000f)]
	internal float MaxHeight = 3f;

	[SerializeField]
	private Vector3 gravityVector = new Vector3(0f, -1f, 0f);

	[FormerlySerializedAs("relativeFilePath_")]
	[SerializeField]
	private string relativeFilePath = "";

	[NonSerialized]
	internal IntPtr mapHandle = IntPtr.Zero;

	[NonSerialized]
	private Action delayedEnable;

	internal const int Success = 0;

	internal bool StaticOnly
	{
		get
		{
			return (Flags & AcousticMapFlags.STATIC_ONLY) != 0;
		}
		set
		{
			if (value)
			{
				Flags |= AcousticMapFlags.STATIC_ONLY;
			}
			else
			{
				Flags &= ~AcousticMapFlags.STATIC_ONLY;
			}
		}
	}

	internal bool NoFloating
	{
		get
		{
			return (Flags & AcousticMapFlags.NO_FLOATING) != 0;
		}
		set
		{
			if (value)
			{
				Flags |= AcousticMapFlags.NO_FLOATING;
			}
			else
			{
				Flags &= ~AcousticMapFlags.NO_FLOATING;
			}
		}
	}

	internal bool Diffraction
	{
		get
		{
			return (Flags & AcousticMapFlags.DIFFRACTION) != 0;
		}
		set
		{
			if (value)
			{
				Flags |= AcousticMapFlags.DIFFRACTION;
			}
			else
			{
				Flags &= ~AcousticMapFlags.DIFFRACTION;
			}
		}
	}

	internal Vector3 GravityVector
	{
		get
		{
			return gravityVector;
		}
		set
		{
			gravityVector = value.normalized;
		}
	}

	internal string RelativeFilePath => relativeFilePath;

	internal string AbsoluteFilePath
	{
		get
		{
			return Path.GetFullPath(Path.Combine(Application.dataPath, RelativeFilePath));
		}
		set
		{
			string text = value.Replace('\\', '/');
			if (text.StartsWith(Application.dataPath))
			{
				relativeFilePath = text.Substring(Application.dataPath.Length + 1);
				if (File.Exists(AbsoluteFilePath))
				{
					DestroyInternal();
					StartInternal();
				}
			}
			else
			{
				UnityEngine.Debug.LogError("invalid path " + value + ", outside application path " + Application.dataPath);
			}
		}
	}

	private void Start()
	{
		StartInternal();
	}

	internal void StartInternal(bool autoLoad = true)
	{
		if (mapHandle != IntPtr.Zero)
		{
			return;
		}
		if (MetaXRAcousticNativeInterface.Interface.CreateAudioSceneIR(out mapHandle) != 0)
		{
			UnityEngine.Debug.LogError("Unable to create internal Acoustic Map", base.gameObject);
			return;
		}
		if (Application.isPlaying)
		{
			if (!string.IsNullOrEmpty(relativeFilePath))
			{
				string text = relativeFilePath;
				if (relativeFilePath.StartsWith("StreamingAssets"))
				{
					string streamingAssetsSubPath = text.Substring("StreamingAssets/".Length);
					StartCoroutine(LoadMapAsync(streamingAssetsSubPath));
				}
			}
		}
		else if (autoLoad)
		{
			bool flag = !string.IsNullOrEmpty(relativeFilePath) && !string.IsNullOrEmpty(base.name) && File.Exists(AbsoluteFilePath);
			if (flag)
			{
				UnityEngine.Debug.Log("Loading Acoustic Map " + base.name + " from File " + AbsoluteFilePath);
			}
			int num = MetaXRAcousticNativeInterface.Interface.AudioSceneIRReadFile(mapHandle, AbsoluteFilePath);
			if (num != 0)
			{
				if (flag)
				{
					UnityEngine.Debug.LogError($"Error {num}: Unable to load the Acoustic Map from file: {AbsoluteFilePath}");
				}
				return;
			}
			if (!flag)
			{
				UnityEngine.Debug.Log("Found data in default location: " + RelativeFilePath);
				relativeFilePath = RelativeFilePath;
			}
		}
		ApplyTransform();
	}

	private IEnumerator LoadMapAsync(string streamingAssetsSubPath)
	{
		string text = Application.streamingAssetsPath + "/" + streamingAssetsSubPath;
		UnityEngine.Debug.Log("Loading Acoustic Map " + base.name + " from StreamingAssets " + text);
		float startTime = Time.realtimeSinceStartup;
		UnityWebRequest unityWebRequest = UnityWebRequest.Get(text);
		yield return unityWebRequest.SendWebRequest();
		if (!string.IsNullOrEmpty(unityWebRequest.error))
		{
			UnityEngine.Debug.LogError($"web request: done={unityWebRequest.isDone}: {unityWebRequest.error}", base.gameObject);
		}
		float num = Time.realtimeSinceStartup - startTime;
		UnityEngine.Debug.Log($"Acoustic Map {base.name}, read time = {num}", base.gameObject);
		LoadMapFromMemory(unityWebRequest.downloadHandler.nativeData);
	}

	private unsafe async void LoadMapFromMemory(NativeArray<byte>.ReadOnly data)
	{
		if (data.Length == 0)
		{
			return;
		}
		float startTime = Time.realtimeSinceStartup;
		int result = -1;
		await Task.Run(delegate
		{
			IntPtr data2 = (IntPtr)data.GetUnsafeReadOnlyPtr();
			lock (this)
			{
				if (mapHandle != IntPtr.Zero)
				{
					result = MetaXRAcousticNativeInterface.Interface.AudioSceneIRReadMemory(mapHandle, data2, (ulong)data.Length);
					GC.KeepAlive(data);
				}
			}
		});
		if (result == 0)
		{
			float num = Time.realtimeSinceStartup - startTime;
			UnityEngine.Debug.Log($"Sucessfully loaded Acoustic Map {base.name}, load time = {num}", base.gameObject);
			delayedEnable = delegate
			{
				MetaXRAcousticGeometry.OnAnyGeometryEnabled -= delayedEnable;
				UnityEngine.Debug.Log("Delayed enable", base.gameObject);
				MetaXRAcousticNativeInterface.Interface.AudioSceneIRSetEnabled(mapHandle, base.isActiveAndEnabled);
			};
			if (MetaXRAcousticGeometry.EnabledGeometryCount > 0)
			{
				MetaXRAcousticNativeInterface.Interface.AudioSceneIRSetEnabled(mapHandle, base.isActiveAndEnabled);
			}
			else
			{
				MetaXRAcousticGeometry.OnAnyGeometryEnabled += delayedEnable;
			}
			IsLoaded = true;
		}
		else
		{
			UnityEngine.Debug.LogError($"Error {result}: Unable to read the Acoustic Map.");
		}
	}

	private void OnDestroy()
	{
		DestroyInternal();
	}

	internal void DestroyInternal()
	{
		lock (this)
		{
			if (mapHandle != IntPtr.Zero)
			{
				if (MetaXRAcousticNativeInterface.Interface.DestroyAudioSceneIR(mapHandle) != 0)
				{
					UnityEngine.Debug.LogError("Unable to destroy Acoustic Map", base.gameObject);
				}
				mapHandle = IntPtr.Zero;
			}
		}
	}

	private void OnEnable()
	{
		if (!(mapHandle == IntPtr.Zero))
		{
			UnityEngine.Debug.Log("Enabling AcousticMap: " + RelativeFilePath);
			MetaXRAcousticNativeInterface.Interface.AudioSceneIRSetEnabled(mapHandle, enabled: true);
		}
	}

	private void OnDisable()
	{
		if (!(mapHandle == IntPtr.Zero))
		{
			MetaXRAcousticGeometry.OnAnyGeometryEnabled -= delayedEnable;
			UnityEngine.Debug.Log("Disabling AcousticMap: " + RelativeFilePath);
			MetaXRAcousticNativeInterface.Interface.AudioSceneIRSetEnabled(mapHandle, enabled: false);
		}
	}

	private void LateUpdate()
	{
		if (!(mapHandle == IntPtr.Zero) && base.transform.hasChanged)
		{
			ApplyTransform();
			base.transform.hasChanged = false;
		}
	}

	private void ApplyTransform()
	{
		MetaXRAcousticNativeInterface.Interface.AudioSceneIRSetTransform(mapHandle, base.transform.localToWorldMatrix);
	}
}
public sealed class MetaXRAcousticMaterial : MonoBehaviour, IMaterialDataProvider
{
	[SerializeField]
	private MetaXRAcousticMaterialProperties properties;

	[SerializeField]
	private bool hasCustomData;

	[SerializeField]
	internal MaterialData customData;

	[NonSerialized]
	private IntPtr materialHandle = IntPtr.Zero;

	internal MetaXRAcousticMaterialProperties Properties
	{
		get
		{
			return properties;
		}
		set
		{
			properties = value;
		}
	}

	public MaterialData Data
	{
		get
		{
			if (!hasCustomData)
			{
				return properties?.Data;
			}
			return customData;
		}
	}

	internal Color Color
	{
		get
		{
			if (Data == null)
			{
				return Color.magenta;
			}
			return Data.color;
		}
	}

	internal void CopyPresetToCustomData(MetaXRAcousticMaterialProperties.BuiltinPreset preset)
	{
		if (!hasCustomData)
		{
			UnityEngine.Debug.LogError("Material doesn't have custom data", base.gameObject);
		}
		else
		{
			MetaXRAcousticMaterialProperties.SetPreset(preset, ref customData);
		}
	}

	private void Start()
	{
		if (!base.gameObject.isStatic)
		{
			StartInternal();
		}
	}

	internal bool StartInternal()
	{
		if (materialHandle != IntPtr.Zero)
		{
			return true;
		}
		materialHandle = CreateMaterialNativeHandle(Data);
		return true;
	}

	private void OnDestroy()
	{
		DestroyInternal();
	}

	internal void DestroyInternal()
	{
		if (materialHandle != IntPtr.Zero)
		{
			DestroyMaterialNativeHandle(materialHandle);
			materialHandle = IntPtr.Zero;
		}
	}

	internal bool ApplyMaterialProperties()
	{
		return ApplyPropertiesToNative(materialHandle, Data);
	}

	internal static IntPtr CreateMaterialNativeHandle(MaterialData data = null)
	{
		IntPtr material = IntPtr.Zero;
		if (MetaXRAcousticNativeInterface.Interface.CreateAudioMaterial(out material) != 0)
		{
			UnityEngine.Debug.LogError("Unable to create internal audio material");
			return material;
		}
		if (data != null)
		{
			ApplyPropertiesToNative(material, data);
		}
		return material;
	}

	internal static void DestroyMaterialNativeHandle(IntPtr handle)
	{
		MetaXRAcousticNativeInterface.Interface.DestroyAudioMaterial(handle);
	}

	private static bool ApplyPropertiesToNative(IntPtr handle, MaterialData data)
	{
		return ApplyPropertiesToNative(handle, data, null);
	}

	private static bool ApplyPropertiesToNative(IntPtr handle, MaterialData data, GameObject gameObject)
	{
		if (handle == IntPtr.Zero || data == null)
		{
			if (gameObject != null)
			{
				_ = gameObject.scene;
				string text = gameObject.scene.name + ":" + string.Join("/", (from t in gameObject.GetComponentsInParent<Transform>()
					select t.name).Reverse().ToArray());
				UnityEngine.Debug.LogWarning("Acoustic Material configured with empty properties: " + text, gameObject);
			}
			return false;
		}
		MetaXRAcousticNativeInterface.Interface.AudioMaterialReset(handle, MaterialProperty.ABSORPTION);
		foreach (Spectrum.Point point in data.absorption.points)
		{
			MetaXRAcousticNativeInterface.Interface.AudioMaterialSetFrequency(handle, MaterialProperty.ABSORPTION, point.frequency, point.data);
		}
		MetaXRAcousticNativeInterface.Interface.AudioMaterialReset(handle, MaterialProperty.TRANSMISSION);
		foreach (Spectrum.Point point2 in data.transmission.points)
		{
			MetaXRAcousticNativeInterface.Interface.AudioMaterialSetFrequency(handle, MaterialProperty.TRANSMISSION, point2.frequency, point2.data);
		}
		MetaXRAcousticNativeInterface.Interface.AudioMaterialReset(handle, MaterialProperty.SCATTERING);
		foreach (Spectrum.Point point3 in data.scattering.points)
		{
			MetaXRAcousticNativeInterface.Interface.AudioMaterialSetFrequency(handle, MaterialProperty.SCATTERING, point3.frequency, point3.data);
		}
		return true;
	}
}
internal class MetaXRAcousticMaterialMapping : ScriptableObject
{
	[Serializable]
	internal class Pair
	{
		[SerializeField]
		internal PhysicsMaterial physicMaterial;

		[SerializeField]
		internal MetaXRAcousticMaterialProperties acousticMaterial;
	}

	[HideInInspector]
	[SerializeField]
	internal Pair[] mapping;

	[HideInInspector]
	[SerializeField]
	[Tooltip("Acoustic material to apply when there is no physics material.")]
	internal MetaXRAcousticMaterialProperties fallbackMaterial;

	private static MetaXRAcousticMaterialMapping instance;

	internal static MetaXRAcousticMaterialMapping Instance
	{
		get
		{
			if (instance == null)
			{
				instance = Resources.Load<MetaXRAcousticMaterialMapping>("MetaXRAcousticMaterialMapping");
				if (instance == null)
				{
					instance = ScriptableObject.CreateInstance<MetaXRAcousticMaterialMapping>();
				}
			}
			return instance;
		}
	}

	internal MetaXRAcousticMaterialProperties findAcousticMaterial(PhysicsMaterial pmat)
	{
		if (pmat == null || mapping == null || mapping.Length == 0)
		{
			return fallbackMaterial;
		}
		return Array.Find(mapping, (Pair pair) => object.Equals(pair.physicMaterial, pmat))?.acousticMaterial;
	}
}
[CreateAssetMenu(menuName = "MetaXRAudio/Acoustic Material Properties")]
internal class MetaXRAcousticMaterialProperties : ScriptableObject, IMaterialDataProvider
{
	internal enum BuiltinPreset
	{
		Custom,
		AcousticTile,
		Brick,
		BrickPainted,
		Cardboard,
		Carpet,
		CarpetHeavy,
		CarpetHeavyPadded,
		CeramicTile,
		Concrete,
		ConcreteRough,
		ConcreteBlock,
		ConcreteBlockPainted,
		Curtain,
		Foliage,
		Glass,
		GlassHeavy,
		Grass,
		Gravel,
		GypsumBoard,
		Marble,
		Mud,
		PlasterOnBrick,
		PlasterOnConcreteBlock,
		Rubber,
		Soil,
		SoundProof,
		Snow,
		Steel,
		Stone,
		Vent,
		Water,
		WoodThin,
		WoodThick,
		WoodFloor,
		WoodOnConcrete,
		MetaDefault
	}

	[SerializeField]
	private MaterialData data = new MaterialData();

	[SerializeField]
	private BuiltinPreset preset;

	public MaterialData Data => data;

	internal BuiltinPreset Preset
	{
		get
		{
			return preset;
		}
		set
		{
			if (value != BuiltinPreset.Custom)
			{
				SetPreset(value, ref data);
			}
			preset = value;
		}
	}

	internal static void SetPreset(BuiltinPreset builtinPreset, ref MaterialData data)
	{
		switch (builtinPreset)
		{
		case BuiltinPreset.AcousticTile:
			AcousticTile(ref data);
			break;
		case BuiltinPreset.Brick:
			Brick(ref data);
			break;
		case BuiltinPreset.BrickPainted:
			BrickPainted(ref data);
			break;
		case BuiltinPreset.Cardboard:
			Cardboard(ref data);
			break;
		case BuiltinPreset.Carpet:
			Carpet(ref data);
			break;
		case BuiltinPreset.CarpetHeavy:
			CarpetHeavy(ref data);
			break;
		case BuiltinPreset.CarpetHeavyPadded:
			CarpetHeavyPadded(ref data);
			break;
		case BuiltinPreset.CeramicTile:
			CeramicTile(ref data);
			break;
		case BuiltinPreset.Concrete:
			Concrete(ref data);
			break;
		case BuiltinPreset.ConcreteRough:
			ConcreteRough(ref data);
			break;
		case BuiltinPreset.ConcreteBlock:
			ConcreteBlock(ref data);
			break;
		case BuiltinPreset.ConcreteBlockPainted:
			ConcreteBlockPainted(ref data);
			break;
		case BuiltinPreset.Curtain:
			Curtain(ref data);
			break;
		case BuiltinPreset.Foliage:
			Foliage(ref data);
			break;
		case BuiltinPreset.Glass:
			Glass(ref data);
			break;
		case BuiltinPreset.GlassHeavy:
			GlassHeavy(ref data);
			break;
		case BuiltinPreset.Grass:
			Grass(ref data);
			break;
		case BuiltinPreset.Gravel:
			Gravel(ref data);
			break;
		case BuiltinPreset.GypsumBoard:
			GypsumBoard(ref data);
			break;
		case BuiltinPreset.Marble:
			Marble(ref data);
			break;
		case BuiltinPreset.Mud:
			Mud(ref data);
			break;
		case BuiltinPreset.PlasterOnBrick:
			PlasterOnBrick(ref data);
			break;
		case BuiltinPreset.PlasterOnConcreteBlock:
			PlasterOnConcreteBlock(ref data);
			break;
		case BuiltinPreset.Rubber:
			Rubber(ref data);
			break;
		case BuiltinPreset.Soil:
			Soil(ref data);
			break;
		case BuiltinPreset.SoundProof:
			SoundProof(ref data);
			break;
		case BuiltinPreset.Snow:
			Snow(ref data);
			break;
		case BuiltinPreset.Steel:
			Steel(ref data);
			break;
		case BuiltinPreset.Stone:
			Stone(ref data);
			break;
		case BuiltinPreset.Vent:
			Vent(ref data);
			break;
		case BuiltinPreset.Water:
			Water(ref data);
			break;
		case BuiltinPreset.WoodThin:
			WoodThin(ref data);
			break;
		case BuiltinPreset.WoodThick:
			WoodThick(ref data);
			break;
		case BuiltinPreset.WoodFloor:
			WoodFloor(ref data);
			break;
		case BuiltinPreset.WoodOnConcrete:
			WoodOnConcrete(ref data);
			break;
		case BuiltinPreset.MetaDefault:
			MetaDefault(ref data);
			break;
		default:
			UnityEngine.Debug.LogError("no preset specified");
			break;
		}
	}

	private static void AcousticTile(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.5f },
			{ 250f, 0.7f },
			{ 500f, 0.6f },
			{ 1000f, 0.7f },
			{ 2000f, 0.7f },
			{ 4000f, 0.5f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.15f },
			{ 500f, 0.2f },
			{ 1000f, 0.2f },
			{ 2000f, 0.25f },
			{ 4000f, 0.3f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.05f },
			{ 250f, 0.04f },
			{ 500f, 0.03f },
			{ 1000f, 0.02f },
			{ 2000f, 0.005f },
			{ 4000f, 0.002f }
		};
	}

	private static void Brick(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.02f },
			{ 250f, 0.02f },
			{ 500f, 0.03f },
			{ 1000f, 0.04f },
			{ 2000f, 0.05f },
			{ 4000f, 0.07f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.2f },
			{ 250f, 0.25f },
			{ 500f, 0.3f },
			{ 1000f, 0.35f },
			{ 2000f, 0.4f },
			{ 4000f, 0.45f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.025f },
			{ 250f, 0.019f },
			{ 500f, 0.01f },
			{ 1000f, 0.0045f },
			{ 2000f, 0.0018f },
			{ 4000f, 0.00089f }
		};
	}

	private static void BrickPainted(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.01f },
			{ 250f, 0.01f },
			{ 500f, 0.02f },
			{ 1000f, 0.02f },
			{ 2000f, 0.02f },
			{ 4000f, 0.03f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.15f },
			{ 250f, 0.15f },
			{ 500f, 0.2f },
			{ 1000f, 0.2f },
			{ 2000f, 0.2f },
			{ 4000f, 0.25f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.025f },
			{ 250f, 0.019f },
			{ 500f, 0.01f },
			{ 1000f, 0.0045f },
			{ 2000f, 0.0018f },
			{ 4000f, 0.00089f }
		};
	}

	private static void Cardboard(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 400f, 0.41f },
			{ 500f, 0.607f },
			{ 630f, 0.773f },
			{ 800f, 0.669f },
			{ 1000f, 0.685f },
			{ 1250f, 0.806f },
			{ 1600f, 0.579f },
			{ 2000f, 0.792f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.12f },
			{ 500f, 0.14f },
			{ 1000f, 0.16f },
			{ 2000f, 0.18f },
			{ 4000f, 0.2f }
		};
		data.transmission = new Spectrum
		{
			{ 400f, 0.082f },
			{ 500f, 0.121f },
			{ 630f, 0.155f },
			{ 800f, 0.134f },
			{ 1000f, 0.137f },
			{ 1250f, 0.161f },
			{ 1600f, 0.116f },
			{ 2000f, 0.158f }
		};
	}

	private static void Carpet(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.01f },
			{ 250f, 0.05f },
			{ 500f, 0.1f },
			{ 1000f, 0.2f },
			{ 2000f, 0.45f },
			{ 4000f, 0.65f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.1f },
			{ 500f, 0.15f },
			{ 1000f, 0.2f },
			{ 2000f, 0.3f },
			{ 4000f, 0.45f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.004f },
			{ 250f, 0.0079f },
			{ 500f, 0.0056f },
			{ 1000f, 0.0016f },
			{ 2000f, 0.0014f },
			{ 4000f, 0.0005f }
		};
	}

	private static void CarpetHeavy(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.02f },
			{ 250f, 0.06f },
			{ 500f, 0.14f },
			{ 1000f, 0.37f },
			{ 2000f, 0.48f },
			{ 4000f, 0.63f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.15f },
			{ 500f, 0.2f },
			{ 1000f, 0.25f },
			{ 2000f, 0.35f },
			{ 4000f, 0.5f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.004f },
			{ 250f, 0.0079f },
			{ 500f, 0.0056f },
			{ 1000f, 0.0016f },
			{ 2000f, 0.0014f },
			{ 4000f, 0.0005f }
		};
	}

	private static void CarpetHeavyPadded(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.08f },
			{ 250f, 0.24f },
			{ 500f, 0.57f },
			{ 1000f, 0.69f },
			{ 2000f, 0.71f },
			{ 4000f, 0.73f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.15f },
			{ 500f, 0.2f },
			{ 1000f, 0.25f },
			{ 2000f, 0.35f },
			{ 4000f, 0.5f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.004f },
			{ 250f, 0.0079f },
			{ 500f, 0.0056f },
			{ 1000f, 0.0016f },
			{ 2000f, 0.0014f },
			{ 4000f, 0.0005f }
		};
	}

	private static void CeramicTile(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.01f },
			{ 250f, 0.01f },
			{ 500f, 0.01f },
			{ 1000f, 0.01f },
			{ 2000f, 0.02f },
			{ 4000f, 0.02f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.12f },
			{ 500f, 0.14f },
			{ 1000f, 0.16f },
			{ 2000f, 0.18f },
			{ 4000f, 0.2f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.004f },
			{ 250f, 0.0079f },
			{ 500f, 0.0056f },
			{ 1000f, 0.0016f },
			{ 2000f, 0.0014f },
			{ 4000f, 0.0005f }
		};
	}

	private static void Concrete(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.01f },
			{ 250f, 0.01f },
			{ 500f, 0.02f },
			{ 1000f, 0.02f },
			{ 2000f, 0.02f },
			{ 4000f, 0.02f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.11f },
			{ 500f, 0.12f },
			{ 1000f, 0.13f },
			{ 2000f, 0.14f },
			{ 4000f, 0.15f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.004f },
			{ 250f, 0.0079f },
			{ 500f, 0.0056f },
			{ 1000f, 0.0016f },
			{ 2000f, 0.0014f },
			{ 4000f, 0.0005f }
		};
	}

	private static void ConcreteRough(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.01f },
			{ 250f, 0.02f },
			{ 500f, 0.04f },
			{ 1000f, 0.06f },
			{ 2000f, 0.08f },
			{ 4000f, 0.1f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.12f },
			{ 500f, 0.15f },
			{ 1000f, 0.2f },
			{ 2000f, 0.25f },
			{ 4000f, 0.3f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.004f },
			{ 250f, 0.0079f },
			{ 500f, 0.0056f },
			{ 1000f, 0.0016f },
			{ 2000f, 0.0014f },
			{ 4000f, 0.0005f }
		};
	}

	private static void ConcreteBlock(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.36f },
			{ 250f, 0.44f },
			{ 500f, 0.31f },
			{ 1000f, 0.29f },
			{ 2000f, 0.39f },
			{ 4000f, 0.21f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.12f },
			{ 500f, 0.15f },
			{ 1000f, 0.2f },
			{ 2000f, 0.3f },
			{ 4000f, 0.4f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.02f },
			{ 250f, 0.01f },
			{ 500f, 0.0063f },
			{ 1000f, 0.0035f },
			{ 2000f, 0.00011f },
			{ 4000f, 0.00063f }
		};
	}

	private static void ConcreteBlockPainted(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.05f },
			{ 500f, 0.06f },
			{ 1000f, 0.07f },
			{ 2000f, 0.09f },
			{ 4000f, 0.08f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.11f },
			{ 500f, 0.13f },
			{ 1000f, 0.15f },
			{ 2000f, 0.16f },
			{ 4000f, 0.2f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.02f },
			{ 250f, 0.01f },
			{ 500f, 0.0063f },
			{ 1000f, 0.0035f },
			{ 2000f, 0.00011f },
			{ 4000f, 0.00063f }
		};
	}

	private static void Curtain(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.07f },
			{ 250f, 0.31f },
			{ 500f, 0.49f },
			{ 1000f, 0.75f },
			{ 2000f, 0.7f },
			{ 4000f, 0.6f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.15f },
			{ 500f, 0.2f },
			{ 1000f, 0.3f },
			{ 2000f, 0.4f },
			{ 4000f, 0.5f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.42f },
			{ 250f, 0.39f },
			{ 500f, 0.21f },
			{ 1000f, 0.14f },
			{ 2000f, 0.079f },
			{ 4000f, 0.045f }
		};
	}

	private static void Foliage(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.03f },
			{ 250f, 0.06f },
			{ 500f, 0.11f },
			{ 1000f, 0.17f },
			{ 2000f, 0.27f },
			{ 4000f, 0.31f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.2f },
			{ 250f, 0.3f },
			{ 500f, 0.4f },
			{ 1000f, 0.5f },
			{ 2000f, 0.7f },
			{ 4000f, 0.8f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.9f },
			{ 250f, 0.9f },
			{ 500f, 0.9f },
			{ 1000f, 0.8f },
			{ 2000f, 0.5f },
			{ 4000f, 0.3f }
		};
	}

	private static void Glass(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.35f },
			{ 250f, 0.25f },
			{ 500f, 0.18f },
			{ 1000f, 0.12f },
			{ 2000f, 0.07f },
			{ 4000f, 0.05f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.05f },
			{ 250f, 0.05f },
			{ 500f, 0.05f },
			{ 1000f, 0.05f },
			{ 2000f, 0.05f },
			{ 4000f, 0.05f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.125f },
			{ 250f, 0.089f },
			{ 500f, 0.05f },
			{ 1000f, 0.028f },
			{ 2000f, 0.022f },
			{ 4000f, 0.079f }
		};
	}

	private static void GlassHeavy(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.18f },
			{ 250f, 0.06f },
			{ 500f, 0.04f },
			{ 1000f, 0.03f },
			{ 2000f, 0.02f },
			{ 4000f, 0.02f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.05f },
			{ 250f, 0.05f },
			{ 500f, 0.05f },
			{ 1000f, 0.05f },
			{ 2000f, 0.05f },
			{ 4000f, 0.05f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.056f },
			{ 250f, 0.039f },
			{ 500f, 0.028f },
			{ 1000f, 0.02f },
			{ 2000f, 0.032f },
			{ 4000f, 0.014f }
		};
	}

	private static void Grass(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.11f },
			{ 250f, 0.26f },
			{ 500f, 0.6f },
			{ 1000f, 0.69f },
			{ 2000f, 0.92f },
			{ 4000f, 0.99f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.3f },
			{ 250f, 0.3f },
			{ 500f, 0.4f },
			{ 1000f, 0.5f },
			{ 2000f, 0.6f },
			{ 4000f, 0.7f }
		};
		data.transmission = new Spectrum();
	}

	private static void Gravel(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.25f },
			{ 250f, 0.6f },
			{ 500f, 0.65f },
			{ 1000f, 0.7f },
			{ 2000f, 0.75f },
			{ 4000f, 0.8f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.2f },
			{ 250f, 0.3f },
			{ 500f, 0.4f },
			{ 1000f, 0.5f },
			{ 2000f, 0.6f },
			{ 4000f, 0.7f }
		};
		data.transmission = new Spectrum();
	}

	private static void GypsumBoard(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.29f },
			{ 250f, 0.1f },
			{ 500f, 0.05f },
			{ 1000f, 0.04f },
			{ 2000f, 0.07f },
			{ 4000f, 0.09f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.11f },
			{ 500f, 0.12f },
			{ 1000f, 0.13f },
			{ 2000f, 0.14f },
			{ 4000f, 0.15f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.035f },
			{ 250f, 0.0125f },
			{ 500f, 0.0056f },
			{ 1000f, 0.0025f },
			{ 2000f, 0.0013f },
			{ 4000f, 0.0032f }
		};
	}

	private static void Marble(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.01f },
			{ 250f, 0.01f },
			{ 500f, 0.01f },
			{ 1000f, 0.01f },
			{ 2000f, 0.02f },
			{ 4000f, 0.02f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.1f },
			{ 500f, 0.1f },
			{ 1000f, 0.1f },
			{ 2000f, 0.1f },
			{ 4000f, 0.1f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.004f },
			{ 250f, 0.0079f },
			{ 500f, 0.0056f },
			{ 1000f, 0.0016f },
			{ 2000f, 0.0014f },
			{ 4000f, 0.0005f }
		};
	}

	private static void Mud(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.15f },
			{ 250f, 0.25f },
			{ 500f, 0.3f },
			{ 1000f, 0.25f },
			{ 2000f, 0.2f },
			{ 4000f, 0.15f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.2f },
			{ 500f, 0.25f },
			{ 1000f, 0.4f },
			{ 2000f, 0.55f },
			{ 4000f, 0.7f }
		};
		data.transmission = new Spectrum();
	}

	private static void PlasterOnBrick(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.01f },
			{ 250f, 0.02f },
			{ 500f, 0.02f },
			{ 1000f, 0.03f },
			{ 2000f, 0.04f },
			{ 4000f, 0.05f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.2f },
			{ 250f, 0.25f },
			{ 500f, 0.3f },
			{ 1000f, 0.35f },
			{ 2000f, 0.4f },
			{ 4000f, 0.45f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.025f },
			{ 250f, 0.019f },
			{ 500f, 0.01f },
			{ 1000f, 0.0045f },
			{ 2000f, 0.0018f },
			{ 4000f, 0.00089f }
		};
	}

	private static void PlasterOnConcreteBlock(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.12f },
			{ 250f, 0.09f },
			{ 500f, 0.07f },
			{ 1000f, 0.05f },
			{ 2000f, 0.05f },
			{ 4000f, 0.04f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.2f },
			{ 250f, 0.25f },
			{ 500f, 0.3f },
			{ 1000f, 0.35f },
			{ 2000f, 0.4f },
			{ 4000f, 0.45f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.02f },
			{ 250f, 0.01f },
			{ 500f, 0.0063f },
			{ 1000f, 0.0035f },
			{ 2000f, 0.00011f },
			{ 4000f, 0.00063f }
		};
	}

	private static void Rubber(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.05f },
			{ 250f, 0.05f },
			{ 500f, 0.1f },
			{ 1000f, 0.1f },
			{ 2000f, 0.05f },
			{ 4000f, 0.05f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.1f },
			{ 500f, 0.1f },
			{ 1000f, 0.1f },
			{ 2000f, 0.15f },
			{ 4000f, 0.2f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.01f },
			{ 250f, 0.01f },
			{ 500f, 0.02f },
			{ 1000f, 0.02f },
			{ 2000f, 0.01f },
			{ 4000f, 0.01f }
		};
	}

	private static void Soil(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.15f },
			{ 250f, 0.25f },
			{ 500f, 0.4f },
			{ 1000f, 0.55f },
			{ 2000f, 0.6f },
			{ 4000f, 0.6f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.2f },
			{ 500f, 0.25f },
			{ 1000f, 0.4f },
			{ 2000f, 0.55f },
			{ 4000f, 0.7f }
		};
		data.transmission = new Spectrum();
	}

	private static void SoundProof(ref MaterialData data)
	{
		data.absorption = new Spectrum { { 1000f, 1f } };
		data.scattering = new Spectrum { { 1000f, 0f } };
		data.transmission = new Spectrum();
	}

	private static void Snow(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.45f },
			{ 250f, 0.75f },
			{ 500f, 0.9f },
			{ 1000f, 0.95f },
			{ 2000f, 0.95f },
			{ 4000f, 0.95f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.2f },
			{ 250f, 0.3f },
			{ 500f, 0.4f },
			{ 1000f, 0.5f },
			{ 2000f, 0.6f },
			{ 4000f, 0.75f }
		};
		data.transmission = new Spectrum();
	}

	private static void Steel(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.05f },
			{ 250f, 0.1f },
			{ 500f, 0.1f },
			{ 1000f, 0.1f },
			{ 2000f, 0.07f },
			{ 4000f, 0.02f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.1f },
			{ 500f, 0.1f },
			{ 1000f, 0.1f },
			{ 2000f, 0.1f },
			{ 4000f, 0.1f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.25f },
			{ 250f, 0.2f },
			{ 500f, 0.17f },
			{ 1000f, 0.089f },
			{ 2000f, 0.089f },
			{ 4000f, 0.0056f }
		};
	}

	private static void Stone(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.02f },
			{ 500f, 0.02f },
			{ 2000f, 0.05f },
			{ 4000f, 0.05f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.1f },
			{ 500f, 0.15f },
			{ 1000f, 0.2f },
			{ 2000f, 0.25f },
			{ 4000f, 0.3f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.004f },
			{ 250f, 0.0079f },
			{ 500f, 0.0056f },
			{ 1000f, 0.00016f },
			{ 2000f, 0.0014f },
			{ 4000f, 0.0005f }
		};
	}

	private static void Vent(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 63.5f, 0.15f },
			{ 125f, 0.15f },
			{ 250f, 0.2f },
			{ 500f, 0.5f },
			{ 1000f, 0.35f },
			{ 2000f, 0.3f },
			{ 4000f, 0.2f },
			{ 8000f, 0.2f }
		};
		data.scattering = new Spectrum
		{
			{ 63.5f, 0.1f },
			{ 125f, 0.1f },
			{ 250f, 0.1f },
			{ 500f, 0.15f },
			{ 1000f, 0.3f },
			{ 2000f, 0.4f },
			{ 4000f, 0.5f },
			{ 8000f, 0.5f }
		};
		data.transmission = new Spectrum
		{
			{ 63.5f, 0.135f },
			{ 125f, 0.135f },
			{ 250f, 0.18f },
			{ 500f, 0.45f },
			{ 1000f, 0.315f },
			{ 2000f, 0.27f },
			{ 4000f, 0.18f },
			{ 8000f, 0.18f }
		};
	}

	private static void Water(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.01f },
			{ 250f, 0.01f },
			{ 500f, 0.01f },
			{ 1000f, 0.02f },
			{ 2000f, 0.02f },
			{ 4000f, 0.03f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.1f },
			{ 500f, 0.1f },
			{ 1000f, 0.07f },
			{ 2000f, 0.05f },
			{ 4000f, 0.05f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.03f },
			{ 250f, 0.03f },
			{ 500f, 0.03f },
			{ 1000f, 0.02f },
			{ 2000f, 0.015f },
			{ 4000f, 0.01f }
		};
	}

	private static void WoodThin(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.42f },
			{ 250f, 0.21f },
			{ 500f, 0.1f },
			{ 1000f, 0.08f },
			{ 2000f, 0.06f },
			{ 4000f, 0.06f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.1f },
			{ 500f, 0.1f },
			{ 1000f, 0.1f },
			{ 2000f, 0.1f },
			{ 4000f, 0.15f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.2f },
			{ 250f, 0.125f },
			{ 500f, 0.079f },
			{ 1000f, 0.1f },
			{ 2000f, 0.089f },
			{ 4000f, 0.05f }
		};
	}

	private static void WoodThick(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.19f },
			{ 250f, 0.14f },
			{ 500f, 0.09f },
			{ 1000f, 0.06f },
			{ 2000f, 0.06f },
			{ 4000f, 0.05f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.1f },
			{ 500f, 0.1f },
			{ 1000f, 0.1f },
			{ 2000f, 0.1f },
			{ 4000f, 0.15f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.035f },
			{ 250f, 0.028f },
			{ 500f, 0.028f },
			{ 1000f, 0.028f },
			{ 2000f, 0.011f },
			{ 4000f, 0.0071f }
		};
	}

	private static void WoodFloor(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.15f },
			{ 250f, 0.11f },
			{ 500f, 0.1f },
			{ 1000f, 0.07f },
			{ 2000f, 0.06f },
			{ 4000f, 0.07f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.1f },
			{ 500f, 0.1f },
			{ 1000f, 0.1f },
			{ 2000f, 0.1f },
			{ 4000f, 0.15f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.071f },
			{ 250f, 0.025f },
			{ 500f, 0.0158f },
			{ 1000f, 0.0056f },
			{ 2000f, 0.0035f },
			{ 4000f, 0.0016f }
		};
	}

	private static void WoodOnConcrete(ref MaterialData data)
	{
		data.absorption = new Spectrum
		{
			{ 125f, 0.04f },
			{ 250f, 0.04f },
			{ 500f, 0.07f },
			{ 1000f, 0.06f },
			{ 2000f, 0.06f },
			{ 4000f, 0.07f }
		};
		data.scattering = new Spectrum
		{
			{ 125f, 0.1f },
			{ 250f, 0.1f },
			{ 500f, 0.1f },
			{ 1000f, 0.1f },
			{ 2000f, 0.1f },
			{ 4000f, 0.15f }
		};
		data.transmission = new Spectrum
		{
			{ 125f, 0.004f },
			{ 250f, 0.0079f },
			{ 500f, 0.0056f },
			{ 1000f, 0.0016f },
			{ 2000f, 0.0014f },
			{ 4000f, 0.0005f }
		};
	}

	private static void MetaDefault(ref MaterialData data)
	{
		data.absorption = new Spectrum { { 1000f, 0.1f } };
		data.scattering = new Spectrum { { 1000f, 0.5f } };
		data.transmission = new Spectrum { { 1000f, 0f } };
	}
}
public class MetaXRAcousticNativeInterface
{
	public enum ovrAudioScalarType : uint
	{
		Int8,
		UInt8,
		Int16,
		UInt16,
		Int32,
		UInt32,
		Int64,
		UInt64,
		Float16,
		Float32,
		Float64
	}

	public interface INativeInterface
	{
		int SetAcousticModel(AcousticModel model);

		int ResetReverb();

		int SetEnabled(int feature, bool enabled);

		int SetEnabled(EnableFlagInternal feature, bool enabled);

		int CreateAudioGeometry(out IntPtr geometry);

		int DestroyAudioGeometry(IntPtr geometry);

		int AudioGeometrySetObjectFlag(IntPtr geometry, ObjectFlags flag, bool enabled);

		int AudioGeometryUploadMeshArrays(IntPtr geometry, float[] vertices, int vertexCount, int[] indices, int indexCount, MeshGroup[] groups, int groupCount);

		int AudioGeometryUploadSimplifiedMeshArrays(IntPtr geometry, float[] vertices, int vertexCount, int[] indices, int indexCount, MeshGroup[] groups, int groupCount, ref MeshSimplification simplification);

		int AudioGeometrySetTransform(IntPtr geometry, in Matrix4x4 matrix);

		int AudioGeometryGetTransform(IntPtr geometry, out float[] matrix4x4);

		int AudioGeometryWriteMeshFile(IntPtr geometry, string filePath);

		int AudioGeometryReadMeshFile(IntPtr geometry, string filePath);

		int AudioGeometryReadMeshMemory(IntPtr geometry, IntPtr data, ulong dataLength);

		int AudioGeometryWriteMeshFileObj(IntPtr geometry, string filePath);

		int AudioGeometryGetSimplifiedMesh(IntPtr geometry, out float[] vertices, out uint[] indices, out uint[] materialIndices);

		int AudioMaterialGetFrequency(IntPtr material, MaterialProperty property, float frequency, out float value);

		int CreateAudioMaterial(out IntPtr material);

		int DestroyAudioMaterial(IntPtr material);

		int AudioMaterialSetFrequency(IntPtr material, MaterialProperty property, float frequency, float value);

		int AudioMaterialReset(IntPtr material, MaterialProperty property);

		int CreateAudioSceneIR(out IntPtr sceneIR);

		int DestroyAudioSceneIR(IntPtr sceneIR);

		int AudioSceneIRSetEnabled(IntPtr sceneIR, bool enabled);

		int AudioSceneIRGetEnabled(IntPtr sceneIR, out bool enabled);

		int AudioSceneIRGetStatus(IntPtr sceneIR, out AcousticMapStatus status);

		int InitializeAudioSceneIRParameters(out MapParameters parameters);

		int AudioSceneIRCompute(IntPtr sceneIR, ref MapParameters parameters);

		int AudioSceneIRComputeCustomPoints(IntPtr sceneIR, float[] points, UIntPtr pointCount, ref MapParameters parameters);

		int AudioSceneIRGetPointCount(IntPtr sceneIR, out UIntPtr pointCount);

		int AudioSceneIRGetPoints(IntPtr sceneIR, float[] points, UIntPtr maxPointCount);

		int AudioSceneIRSetTransform(IntPtr sceneIR, in Matrix4x4 matrix);

		int AudioSceneIRGetTransform(IntPtr sceneIR, out float[] matrix4x4);

		int AudioSceneIRWriteFile(IntPtr sceneIR, string filePath);

		int AudioSceneIRReadFile(IntPtr sceneIR, string filePath);

		int AudioSceneIRReadMemory(IntPtr sceneIR, IntPtr data, ulong dataLength);

		int CreateControlZone(out IntPtr control);

		int DestroyControlZone(IntPtr control);

		int ControlZoneSetEnabled(IntPtr control, bool enabled);

		int ControlZoneGetEnabled(IntPtr control, out bool enabled);

		int ControlZoneSetTransform(IntPtr control, in Matrix4x4 matrix);

		int ControlZoneGetTransform(IntPtr control, out float[] matrix4x4);

		int ControlZoneSetBox(IntPtr control, float sizeX, float sizeY, float sizeZ);

		int ControlZoneGetBox(IntPtr control, out float sizeX, out float sizeY, out float sizeZ);

		int ControlZoneSetFadeDistance(IntPtr control, float fadeX, float fadeY, float fadeZ);

		int ControlZoneGetFadeDistance(IntPtr control, out float fadeX, out float fadeY, out float fadeZ);

		int ControlZoneSetFrequency(IntPtr control, ControlZoneProperty property, float frequency, float value);

		int ControlZoneReset(IntPtr control, ControlZoneProperty property);
	}

	public class UnityNativeInterface : INativeInterface
	{
		public const string binaryName = "MetaXRAudioUnity";

		private IntPtr context_ = IntPtr.Zero;

		private int version;

		private IntPtr context
		{
			get
			{
				if (context_ == IntPtr.Zero)
				{
					ovrAudio_GetPluginContext(out context_);
					ovrAudio_GetVersion(out var _, out version, out var _);
				}
				return context_;
			}
		}

		[DllImport("MetaXRAudioUnity")]
		public static extern int ovrAudio_GetPluginContext(out IntPtr context);

		[DllImport("MetaXRAudioUnity")]
		public static extern IntPtr ovrAudio_GetVersion(out int Major, out int Minor, out int Patch);

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_SetAcousticModel(IntPtr context, AcousticModel quality);

		public int SetAcousticModel(AcousticModel model)
		{
			return ovrAudio_SetAcousticModel(context, model);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ResetSharedReverb(IntPtr context);

		public int ResetReverb()
		{
			return ovrAudio_ResetSharedReverb(context);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_Enable(IntPtr context, int what, int enable);

		public int SetEnabled(int feature, bool enabled)
		{
			return ovrAudio_Enable(context, feature, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_Enable(IntPtr context, EnableFlagInternal what, int enable);

		public int SetEnabled(EnableFlagInternal feature, bool enabled)
		{
			return ovrAudio_Enable(context, feature, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_CreateAudioGeometry(IntPtr context, out IntPtr geometry);

		public int CreateAudioGeometry(out IntPtr geometry)
		{
			return ovrAudio_CreateAudioGeometry(context, out geometry);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_DestroyAudioGeometry(IntPtr geometry);

		public int DestroyAudioGeometry(IntPtr geometry)
		{
			return ovrAudio_DestroyAudioGeometry(geometry);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioGeometrySetObjectFlag(IntPtr geometry, ObjectFlags flag, int enabled);

		public int AudioGeometrySetObjectFlag(IntPtr geometry, ObjectFlags flag, bool enabled)
		{
			if (version < 94)
			{
				return -1;
			}
			return ovrAudio_AudioGeometrySetObjectFlag(geometry, flag, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioGeometryUploadMeshArrays(IntPtr geometry, float[] vertices, UIntPtr verticesBytesOffset, UIntPtr vertexCount, UIntPtr vertexStride, ovrAudioScalarType vertexType, int[] indices, UIntPtr indicesByteOffset, UIntPtr indexCount, ovrAudioScalarType indexType, MeshGroup[] groups, UIntPtr groupCount);

		public int AudioGeometryUploadMeshArrays(IntPtr geometry, float[] vertices, int vertexCount, int[] indices, int indexCount, MeshGroup[] groups, int groupCount)
		{
			return ovrAudio_AudioGeometryUploadMeshArrays(geometry, vertices, UIntPtr.Zero, (UIntPtr)(ulong)vertexCount, UIntPtr.Zero, ovrAudioScalarType.Float32, indices, UIntPtr.Zero, (UIntPtr)(ulong)indexCount, ovrAudioScalarType.UInt32, groups, (UIntPtr)(ulong)groupCount);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioGeometryUploadSimplifiedMeshArrays(IntPtr geometry, float[] vertices, UIntPtr verticesBytesOffset, UIntPtr vertexCount, UIntPtr vertexStride, ovrAudioScalarType vertexType, int[] indices, UIntPtr indicesByteOffset, UIntPtr indexCount, ovrAudioScalarType indexType, MeshGroup[] groups, UIntPtr groupCount, ref MeshSimplification simplification);

		public int AudioGeometryUploadSimplifiedMeshArrays(IntPtr geometry, float[] vertices, int vertexCount, int[] indices, int indexCount, MeshGroup[] groups, int groupCount, ref MeshSimplification simplification)
		{
			return ovrAudio_AudioGeometryUploadSimplifiedMeshArrays(geometry, vertices, UIntPtr.Zero, (UIntPtr)(ulong)vertexCount, UIntPtr.Zero, ovrAudioScalarType.Float32, indices, UIntPtr.Zero, (UIntPtr)(ulong)indexCount, ovrAudioScalarType.UInt32, groups, (UIntPtr)(ulong)groupCount, ref simplification);
		}

		[DllImport("MetaXRAudioUnity")]
		private unsafe static extern int ovrAudio_AudioGeometrySetTransform(IntPtr geometry, float* matrix4x4);

		public unsafe int AudioGeometrySetTransform(IntPtr geometry, in Matrix4x4 matrix)
		{
			float* ptr = stackalloc float[16];
			*ptr = matrix.m00;
			ptr[1] = matrix.m10;
			ptr[2] = 0f - matrix.m20;
			ptr[3] = matrix.m30;
			ptr[4] = matrix.m01;
			ptr[5] = matrix.m11;
			ptr[6] = 0f - matrix.m21;
			ptr[7] = matrix.m31;
			ptr[8] = matrix.m02;
			ptr[9] = matrix.m12;
			ptr[10] = 0f - matrix.m22;
			ptr[11] = matrix.m32;
			ptr[12] = matrix.m03;
			ptr[13] = matrix.m13;
			ptr[14] = 0f - matrix.m23;
			ptr[15] = matrix.m33;
			return ovrAudio_AudioGeometrySetTransform(geometry, ptr);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioGeometryGetTransform(IntPtr geometry, out float[] matrix4x4);

		public int AudioGeometryGetTransform(IntPtr geometry, out float[] matrix4x4)
		{
			return ovrAudio_AudioGeometryGetTransform(geometry, out matrix4x4);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioGeometryWriteMeshFile(IntPtr geometry, string filePath);

		public int AudioGeometryWriteMeshFile(IntPtr geometry, string filePath)
		{
			return ovrAudio_AudioGeometryWriteMeshFile(geometry, filePath);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioGeometryReadMeshFile(IntPtr geometry, string filePath);

		public int AudioGeometryReadMeshFile(IntPtr geometry, string filePath)
		{
			return ovrAudio_AudioGeometryReadMeshFile(geometry, filePath);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioGeometryReadMeshMemory(IntPtr geometry, IntPtr data, ulong dataLength);

		public int AudioGeometryReadMeshMemory(IntPtr geometry, IntPtr data, ulong dataLength)
		{
			return ovrAudio_AudioGeometryReadMeshMemory(geometry, data, dataLength);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioGeometryWriteMeshFileObj(IntPtr geometry, string filePath);

		public int AudioGeometryWriteMeshFileObj(IntPtr geometry, string filePath)
		{
			return ovrAudio_AudioGeometryWriteMeshFileObj(geometry, filePath);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioGeometryGetSimplifiedMeshWithMaterials(IntPtr geometry, IntPtr unused1, out uint numVertices, IntPtr unused2, IntPtr unused3, out uint numTriangles);

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioGeometryGetSimplifiedMeshWithMaterials(IntPtr geometry, float[] vertices, ref uint numVertices, uint[] indices, uint[] materialIndices, ref uint numTriangles);

		public int AudioGeometryGetSimplifiedMesh(IntPtr geometry, out float[] vertices, out uint[] indices, out uint[] materialIndices)
		{
			uint numVertices;
			uint numTriangles;
			int num = ovrAudio_AudioGeometryGetSimplifiedMeshWithMaterials(geometry, IntPtr.Zero, out numVertices, IntPtr.Zero, IntPtr.Zero, out numTriangles);
			if (num != 0)
			{
				UnityEngine.Debug.LogError("unexpected error getting simplified mesh array sizes");
				vertices = null;
				indices = null;
				materialIndices = null;
				return num;
			}
			vertices = new float[numVertices * 3];
			indices = new uint[numTriangles * 3];
			materialIndices = new uint[numTriangles];
			return ovrAudio_AudioGeometryGetSimplifiedMeshWithMaterials(geometry, vertices, ref numVertices, indices, materialIndices, ref numTriangles);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_CreateAudioMaterial(IntPtr context, out IntPtr material);

		public int CreateAudioMaterial(out IntPtr material)
		{
			return ovrAudio_CreateAudioMaterial(context, out material);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_DestroyAudioMaterial(IntPtr material);

		public int DestroyAudioMaterial(IntPtr material)
		{
			return ovrAudio_DestroyAudioMaterial(material);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioMaterialSetFrequency(IntPtr material, MaterialProperty property, float frequency, float value);

		public int AudioMaterialSetFrequency(IntPtr material, MaterialProperty property, float frequency, float value)
		{
			return ovrAudio_AudioMaterialSetFrequency(material, property, frequency, value);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioMaterialGetFrequency(IntPtr material, MaterialProperty property, float frequency, out float value);

		public int AudioMaterialGetFrequency(IntPtr material, MaterialProperty property, float frequency, out float value)
		{
			return ovrAudio_AudioMaterialGetFrequency(material, property, frequency, out value);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioMaterialReset(IntPtr material, MaterialProperty property);

		public int AudioMaterialReset(IntPtr material, MaterialProperty property)
		{
			return ovrAudio_AudioMaterialReset(material, property);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_CreateAudioSceneIR(IntPtr context, out IntPtr sceneIR);

		public int CreateAudioSceneIR(out IntPtr sceneIR)
		{
			return ovrAudio_CreateAudioSceneIR(context, out sceneIR);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_DestroyAudioSceneIR(IntPtr sceneIR);

		public int DestroyAudioSceneIR(IntPtr sceneIR)
		{
			return ovrAudio_DestroyAudioSceneIR(sceneIR);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioSceneIRSetEnabled(IntPtr sceneIR, int enabled);

		public int AudioSceneIRSetEnabled(IntPtr sceneIR, bool enabled)
		{
			return ovrAudio_AudioSceneIRSetEnabled(sceneIR, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioSceneIRGetEnabled(IntPtr sceneIR, out int enabled);

		public int AudioSceneIRGetEnabled(IntPtr sceneIR, out bool enabled)
		{
			int enabled2;
			int result = ovrAudio_AudioSceneIRGetEnabled(sceneIR, out enabled2);
			enabled = enabled2 != 0;
			return result;
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioSceneIRGetStatus(IntPtr sceneIR, out AcousticMapStatus status);

		public int AudioSceneIRGetStatus(IntPtr sceneIR, out AcousticMapStatus status)
		{
			return ovrAudio_AudioSceneIRGetStatus(sceneIR, out status);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_InitializeAudioSceneIRParameters(out MapParameters parameters);

		public int InitializeAudioSceneIRParameters(out MapParameters parameters)
		{
			return ovrAudio_InitializeAudioSceneIRParameters(out parameters);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioSceneIRCompute(IntPtr sceneIR, ref MapParameters parameters);

		public int AudioSceneIRCompute(IntPtr sceneIR, ref MapParameters parameters)
		{
			return ovrAudio_AudioSceneIRCompute(sceneIR, ref parameters);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioSceneIRComputeCustomPoints(IntPtr sceneIR, float[] points, UIntPtr pointCount, ref MapParameters parameters);

		public int AudioSceneIRComputeCustomPoints(IntPtr sceneIR, float[] points, UIntPtr pointCount, ref MapParameters parameters)
		{
			return ovrAudio_AudioSceneIRComputeCustomPoints(sceneIR, points, pointCount, ref parameters);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioSceneIRGetPointCount(IntPtr sceneIR, out UIntPtr pointCount);

		public int AudioSceneIRGetPointCount(IntPtr sceneIR, out UIntPtr pointCount)
		{
			return ovrAudio_AudioSceneIRGetPointCount(sceneIR, out pointCount);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioSceneIRGetPoints(IntPtr sceneIR, float[] points, UIntPtr maxPointCount);

		public int AudioSceneIRGetPoints(IntPtr sceneIR, float[] points, UIntPtr maxPointCount)
		{
			return ovrAudio_AudioSceneIRGetPoints(sceneIR, points, maxPointCount);
		}

		[DllImport("MetaXRAudioUnity")]
		private unsafe static extern int ovrAudio_AudioSceneIRSetTransform(IntPtr sceneIR, float* matrix4x4);

		public unsafe int AudioSceneIRSetTransform(IntPtr sceneIR, in Matrix4x4 matrix)
		{
			float* ptr = stackalloc float[16];
			*ptr = matrix.m00;
			ptr[1] = matrix.m10;
			ptr[2] = 0f - matrix.m20;
			ptr[3] = matrix.m30;
			ptr[4] = matrix.m01;
			ptr[5] = matrix.m11;
			ptr[6] = 0f - matrix.m21;
			ptr[7] = matrix.m31;
			ptr[8] = matrix.m02;
			ptr[9] = matrix.m12;
			ptr[10] = 0f - matrix.m22;
			ptr[11] = matrix.m32;
			ptr[12] = matrix.m03;
			ptr[13] = matrix.m13;
			ptr[14] = 0f - matrix.m23;
			ptr[15] = matrix.m33;
			return ovrAudio_AudioSceneIRSetTransform(sceneIR, ptr);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioSceneIRGetTransform(IntPtr sceneIR, out float[] matrix4x4);

		public int AudioSceneIRGetTransform(IntPtr sceneIR, out float[] matrix4x4)
		{
			return ovrAudio_AudioSceneIRGetTransform(sceneIR, out matrix4x4);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioSceneIRWriteFile(IntPtr sceneIR, string filePath);

		public int AudioSceneIRWriteFile(IntPtr sceneIR, string filePath)
		{
			return ovrAudio_AudioSceneIRWriteFile(sceneIR, filePath);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioSceneIRReadFile(IntPtr sceneIR, string filePath);

		public int AudioSceneIRReadFile(IntPtr sceneIR, string filePath)
		{
			return ovrAudio_AudioSceneIRReadFile(sceneIR, filePath);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_AudioSceneIRReadMemory(IntPtr sceneIR, IntPtr data, ulong dataLength);

		public int AudioSceneIRReadMemory(IntPtr sceneIR, IntPtr data, ulong dataLength)
		{
			return ovrAudio_AudioSceneIRReadMemory(sceneIR, data, dataLength);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_CreateControlZone(IntPtr context, out IntPtr control);

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_CreateControlVolume(IntPtr context, out IntPtr control);

		public int CreateControlZone(out IntPtr control)
		{
			try
			{
				return ovrAudio_CreateControlZone(context, out control);
			}
			catch
			{
				return ovrAudio_CreateControlVolume(context, out control);
			}
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_DestroyControlZone(IntPtr control);

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_DestroyControlVolume(IntPtr control);

		public int DestroyControlZone(IntPtr control)
		{
			try
			{
				return ovrAudio_DestroyControlZone(control);
			}
			catch
			{
				return ovrAudio_DestroyControlVolume(control);
			}
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlZoneSetEnabled(IntPtr control, int enabled);

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlVolumeSetEnabled(IntPtr control, int enabled);

		public int ControlZoneSetEnabled(IntPtr control, bool enabled)
		{
			try
			{
				return ovrAudio_ControlZoneSetEnabled(control, enabled ? 1 : 0);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetEnabled(control, enabled ? 1 : 0);
			}
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlZoneGetEnabled(IntPtr control, out int enabled);

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlVolumeGetEnabled(IntPtr control, out int enabled);

		public int ControlZoneGetEnabled(IntPtr control, out bool enabled)
		{
			int enabled2 = 0;
			int result;
			try
			{
				result = ovrAudio_ControlZoneGetEnabled(control, out enabled2);
			}
			catch
			{
				result = ovrAudio_ControlVolumeGetEnabled(control, out enabled2);
			}
			enabled = enabled2 != 0;
			return result;
		}

		[DllImport("MetaXRAudioUnity")]
		private unsafe static extern int ovrAudio_ControlZoneSetTransform(IntPtr control, float* matrix4x4);

		[DllImport("MetaXRAudioUnity")]
		private unsafe static extern int ovrAudio_ControlVolumeSetTransform(IntPtr control, float* matrix4x4);

		public unsafe int ControlZoneSetTransform(IntPtr control, in Matrix4x4 matrix)
		{
			float* ptr = stackalloc float[16];
			*ptr = matrix.m00;
			ptr[1] = matrix.m10;
			ptr[2] = 0f - matrix.m20;
			ptr[3] = matrix.m30;
			ptr[4] = matrix.m01;
			ptr[5] = matrix.m11;
			ptr[6] = 0f - matrix.m21;
			ptr[7] = matrix.m31;
			ptr[8] = matrix.m02;
			ptr[9] = matrix.m12;
			ptr[10] = 0f - matrix.m22;
			ptr[11] = matrix.m32;
			ptr[12] = matrix.m03;
			ptr[13] = matrix.m13;
			ptr[14] = 0f - matrix.m23;
			ptr[15] = matrix.m33;
			try
			{
				return ovrAudio_ControlZoneSetTransform(control, ptr);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetTransform(control, ptr);
			}
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlZoneGetTransform(IntPtr control, out float[] matrix4x4);

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlVolumeGetTransform(IntPtr control, out float[] matrix4x4);

		public int ControlZoneGetTransform(IntPtr control, out float[] matrix4x4)
		{
			try
			{
				return ovrAudio_ControlZoneGetTransform(control, out matrix4x4);
			}
			catch
			{
				return ovrAudio_ControlVolumeGetTransform(control, out matrix4x4);
			}
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlZoneSetBox(IntPtr control, float sizeX, float sizeY, float sizeZ);

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlVolumeSetBox(IntPtr control, float sizeX, float sizeY, float sizeZ);

		public int ControlZoneSetBox(IntPtr control, float sizeX, float sizeY, float sizeZ)
		{
			try
			{
				return ovrAudio_ControlZoneSetBox(control, sizeX, sizeY, sizeZ);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetBox(control, sizeX, sizeY, sizeZ);
			}
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlZoneGetBox(IntPtr control, out float sizeX, out float sizeY, out float sizeZ);

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlVolumeGetBox(IntPtr control, out float sizeX, out float sizeY, out float sizeZ);

		public int ControlZoneGetBox(IntPtr control, out float sizeX, out float sizeY, out float sizeZ)
		{
			try
			{
				return ovrAudio_ControlZoneGetBox(control, out sizeX, out sizeY, out sizeZ);
			}
			catch
			{
				return ovrAudio_ControlVolumeGetBox(control, out sizeX, out sizeY, out sizeZ);
			}
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlZoneSetFadeDistance(IntPtr control, float fadeX, float fadeY, float fadeZ);

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlVolumeSetFadeDistance(IntPtr control, float fadeX, float fadeY, float fadeZ);

		public int ControlZoneSetFadeDistance(IntPtr control, float fadeX, float fadeY, float fadeZ)
		{
			try
			{
				return ovrAudio_ControlZoneSetFadeDistance(control, fadeX, fadeY, fadeZ);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetFadeDistance(control, fadeX, fadeY, fadeZ);
			}
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlZoneGetFadeDistance(IntPtr control, out float fadeX, out float fadeY, out float fadeZ);

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlVolumeGetFadeDistance(IntPtr control, out float fadeX, out float fadeY, out float fadeZ);

		public int ControlZoneGetFadeDistance(IntPtr control, out float fadeX, out float fadeY, out float fadeZ)
		{
			try
			{
				return ovrAudio_ControlZoneGetFadeDistance(control, out fadeX, out fadeY, out fadeZ);
			}
			catch
			{
				return ovrAudio_ControlVolumeGetFadeDistance(control, out fadeX, out fadeY, out fadeZ);
			}
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlZoneSetFrequency(IntPtr control, ControlZoneProperty property, float frequency, float value);

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlVolumeSetFrequency(IntPtr control, ControlZoneProperty property, float frequency, float value);

		public int ControlZoneSetFrequency(IntPtr control, ControlZoneProperty property, float frequency, float value)
		{
			try
			{
				return ovrAudio_ControlZoneSetFrequency(control, property, frequency, value);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetFrequency(control, property, frequency, value);
			}
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlZoneReset(IntPtr control, ControlZoneProperty property);

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_ControlVolumeReset(IntPtr control, ControlZoneProperty property);

		public int ControlZoneReset(IntPtr control, ControlZoneProperty property)
		{
			try
			{
				return ovrAudio_ControlZoneReset(control, property);
			}
			catch
			{
				return ovrAudio_ControlVolumeReset(control, property);
			}
		}

		int INativeInterface.AudioGeometrySetTransform(IntPtr geometry, in Matrix4x4 matrix)
		{
			return AudioGeometrySetTransform(geometry, in matrix);
		}

		int INativeInterface.AudioSceneIRSetTransform(IntPtr sceneIR, in Matrix4x4 matrix)
		{
			return AudioSceneIRSetTransform(sceneIR, in matrix);
		}

		int INativeInterface.ControlZoneSetTransform(IntPtr control, in Matrix4x4 matrix)
		{
			return ControlZoneSetTransform(control, in matrix);
		}
	}

	public class WwisePluginInterface : INativeInterface
	{
		public const string binaryName = "MetaXRAudioWwise";

		private IntPtr context_ = IntPtr.Zero;

		private int version;

		private IntPtr context
		{
			get
			{
				if (context_ == IntPtr.Zero)
				{
					context_ = getOrCreateGlobalOvrAudioContext();
					ovrAudio_GetVersion(out var _, out version, out var _);
				}
				return context_;
			}
		}

		[DllImport("MetaXRAudioWwise")]
		public static extern IntPtr getOrCreateGlobalOvrAudioContext();

		[DllImport("MetaXRAudioWwise")]
		public static extern IntPtr ovrAudio_GetVersion(out int Major, out int Minor, out int Patch);

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_SetAcousticModel(IntPtr context, AcousticModel quality);

		public int SetAcousticModel(AcousticModel model)
		{
			return ovrAudio_SetAcousticModel(context, model);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ResetSharedReverb(IntPtr context);

		public int ResetReverb()
		{
			return ovrAudio_ResetSharedReverb(context);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_Enable(IntPtr context, int what, int enable);

		public int SetEnabled(int feature, bool enabled)
		{
			return ovrAudio_Enable(context, feature, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_Enable(IntPtr context, EnableFlagInternal what, int enable);

		public int SetEnabled(EnableFlagInternal feature, bool enabled)
		{
			return ovrAudio_Enable(context, feature, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_CreateAudioGeometry(IntPtr context, out IntPtr geometry);

		public int CreateAudioGeometry(out IntPtr geometry)
		{
			return ovrAudio_CreateAudioGeometry(context, out geometry);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_DestroyAudioGeometry(IntPtr geometry);

		public int DestroyAudioGeometry(IntPtr geometry)
		{
			return ovrAudio_DestroyAudioGeometry(geometry);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioGeometrySetObjectFlag(IntPtr geometry, ObjectFlags flag, int enabled);

		public int AudioGeometrySetObjectFlag(IntPtr geometry, ObjectFlags flag, bool enabled)
		{
			if (version < 94)
			{
				return -1;
			}
			return ovrAudio_AudioGeometrySetObjectFlag(geometry, flag, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioGeometryUploadMeshArrays(IntPtr geometry, float[] vertices, UIntPtr verticesBytesOffset, UIntPtr vertexCount, UIntPtr vertexStride, ovrAudioScalarType vertexType, int[] indices, UIntPtr indicesByteOffset, UIntPtr indexCount, ovrAudioScalarType indexType, MeshGroup[] groups, UIntPtr groupCount);

		public int AudioGeometryUploadMeshArrays(IntPtr geometry, float[] vertices, int vertexCount, int[] indices, int indexCount, MeshGroup[] groups, int groupCount)
		{
			return ovrAudio_AudioGeometryUploadMeshArrays(geometry, vertices, UIntPtr.Zero, (UIntPtr)(ulong)vertexCount, UIntPtr.Zero, ovrAudioScalarType.Float32, indices, UIntPtr.Zero, (UIntPtr)(ulong)indexCount, ovrAudioScalarType.UInt32, groups, (UIntPtr)(ulong)groupCount);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioGeometryUploadSimplifiedMeshArrays(IntPtr geometry, float[] vertices, UIntPtr verticesBytesOffset, UIntPtr vertexCount, UIntPtr vertexStride, ovrAudioScalarType vertexType, int[] indices, UIntPtr indicesByteOffset, UIntPtr indexCount, ovrAudioScalarType indexType, MeshGroup[] groups, UIntPtr groupCount, ref MeshSimplification simplification);

		public int AudioGeometryUploadSimplifiedMeshArrays(IntPtr geometry, float[] vertices, int vertexCount, int[] indices, int indexCount, MeshGroup[] groups, int groupCount, ref MeshSimplification simplification)
		{
			return ovrAudio_AudioGeometryUploadSimplifiedMeshArrays(geometry, vertices, UIntPtr.Zero, (UIntPtr)(ulong)vertexCount, UIntPtr.Zero, ovrAudioScalarType.Float32, indices, UIntPtr.Zero, (UIntPtr)(ulong)indexCount, ovrAudioScalarType.UInt32, groups, (UIntPtr)(ulong)groupCount, ref simplification);
		}

		[DllImport("MetaXRAudioWwise")]
		private unsafe static extern int ovrAudio_AudioGeometrySetTransform(IntPtr geometry, float* matrix4x4);

		public unsafe int AudioGeometrySetTransform(IntPtr geometry, in Matrix4x4 matrix)
		{
			float* ptr = stackalloc float[16];
			*ptr = matrix.m00;
			ptr[1] = matrix.m10;
			ptr[2] = 0f - matrix.m20;
			ptr[3] = matrix.m30;
			ptr[4] = matrix.m01;
			ptr[5] = matrix.m11;
			ptr[6] = 0f - matrix.m21;
			ptr[7] = matrix.m31;
			ptr[8] = matrix.m02;
			ptr[9] = matrix.m12;
			ptr[10] = 0f - matrix.m22;
			ptr[11] = matrix.m32;
			ptr[12] = matrix.m03;
			ptr[13] = matrix.m13;
			ptr[14] = 0f - matrix.m23;
			ptr[15] = matrix.m33;
			return ovrAudio_AudioGeometrySetTransform(geometry, ptr);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioGeometryGetTransform(IntPtr geometry, out float[] matrix4x4);

		public int AudioGeometryGetTransform(IntPtr geometry, out float[] matrix4x4)
		{
			return ovrAudio_AudioGeometryGetTransform(geometry, out matrix4x4);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioGeometryWriteMeshFile(IntPtr geometry, string filePath);

		public int AudioGeometryWriteMeshFile(IntPtr geometry, string filePath)
		{
			return ovrAudio_AudioGeometryWriteMeshFile(geometry, filePath);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioGeometryReadMeshFile(IntPtr geometry, string filePath);

		public int AudioGeometryReadMeshFile(IntPtr geometry, string filePath)
		{
			return ovrAudio_AudioGeometryReadMeshFile(geometry, filePath);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioGeometryReadMeshMemory(IntPtr geometry, IntPtr data, ulong dataLength);

		public int AudioGeometryReadMeshMemory(IntPtr geometry, IntPtr data, ulong dataLength)
		{
			return ovrAudio_AudioGeometryReadMeshMemory(geometry, data, dataLength);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioGeometryWriteMeshFileObj(IntPtr geometry, string filePath);

		public int AudioGeometryWriteMeshFileObj(IntPtr geometry, string filePath)
		{
			return ovrAudio_AudioGeometryWriteMeshFileObj(geometry, filePath);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioGeometryGetSimplifiedMeshWithMaterials(IntPtr geometry, IntPtr unused1, out uint numVertices, IntPtr unused2, IntPtr unused3, out uint numTriangles);

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioGeometryGetSimplifiedMeshWithMaterials(IntPtr geometry, float[] vertices, ref uint numVertices, uint[] indices, uint[] materialIndices, ref uint numTriangles);

		public int AudioGeometryGetSimplifiedMesh(IntPtr geometry, out float[] vertices, out uint[] indices, out uint[] materialIndices)
		{
			uint numVertices;
			uint numTriangles;
			int num = ovrAudio_AudioGeometryGetSimplifiedMeshWithMaterials(geometry, IntPtr.Zero, out numVertices, IntPtr.Zero, IntPtr.Zero, out numTriangles);
			if (num != 0)
			{
				UnityEngine.Debug.LogError("unexpected error getting simplified mesh array sizes");
				vertices = null;
				indices = null;
				materialIndices = null;
				return num;
			}
			vertices = new float[numVertices * 3];
			indices = new uint[numTriangles * 3];
			materialIndices = new uint[numTriangles];
			return ovrAudio_AudioGeometryGetSimplifiedMeshWithMaterials(geometry, vertices, ref numVertices, indices, materialIndices, ref numTriangles);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_CreateAudioMaterial(IntPtr context, out IntPtr material);

		public int CreateAudioMaterial(out IntPtr material)
		{
			return ovrAudio_CreateAudioMaterial(context, out material);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_DestroyAudioMaterial(IntPtr material);

		public int DestroyAudioMaterial(IntPtr material)
		{
			return ovrAudio_DestroyAudioMaterial(material);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioMaterialSetFrequency(IntPtr material, MaterialProperty property, float frequency, float value);

		public int AudioMaterialSetFrequency(IntPtr material, MaterialProperty property, float frequency, float value)
		{
			return ovrAudio_AudioMaterialSetFrequency(material, property, frequency, value);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioMaterialGetFrequency(IntPtr material, MaterialProperty property, float frequency, out float value);

		public int AudioMaterialGetFrequency(IntPtr material, MaterialProperty property, float frequency, out float value)
		{
			return ovrAudio_AudioMaterialGetFrequency(material, property, frequency, out value);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioMaterialReset(IntPtr material, MaterialProperty property);

		public int AudioMaterialReset(IntPtr material, MaterialProperty property)
		{
			return ovrAudio_AudioMaterialReset(material, property);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_CreateAudioSceneIR(IntPtr context, out IntPtr sceneIR);

		public int CreateAudioSceneIR(out IntPtr sceneIR)
		{
			return ovrAudio_CreateAudioSceneIR(context, out sceneIR);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_DestroyAudioSceneIR(IntPtr sceneIR);

		public int DestroyAudioSceneIR(IntPtr sceneIR)
		{
			return ovrAudio_DestroyAudioSceneIR(sceneIR);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioSceneIRSetEnabled(IntPtr sceneIR, int enabled);

		public int AudioSceneIRSetEnabled(IntPtr sceneIR, bool enabled)
		{
			return ovrAudio_AudioSceneIRSetEnabled(sceneIR, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioSceneIRGetEnabled(IntPtr sceneIR, out int enabled);

		public int AudioSceneIRGetEnabled(IntPtr sceneIR, out bool enabled)
		{
			int enabled2;
			int result = ovrAudio_AudioSceneIRGetEnabled(sceneIR, out enabled2);
			enabled = enabled2 != 0;
			return result;
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioSceneIRGetStatus(IntPtr sceneIR, out AcousticMapStatus status);

		public int AudioSceneIRGetStatus(IntPtr sceneIR, out AcousticMapStatus status)
		{
			return ovrAudio_AudioSceneIRGetStatus(sceneIR, out status);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_InitializeAudioSceneIRParameters(out MapParameters parameters);

		public int InitializeAudioSceneIRParameters(out MapParameters parameters)
		{
			return ovrAudio_InitializeAudioSceneIRParameters(out parameters);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioSceneIRCompute(IntPtr sceneIR, ref MapParameters parameters);

		public int AudioSceneIRCompute(IntPtr sceneIR, ref MapParameters parameters)
		{
			return ovrAudio_AudioSceneIRCompute(sceneIR, ref parameters);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioSceneIRComputeCustomPoints(IntPtr sceneIR, float[] points, UIntPtr pointCount, ref MapParameters parameters);

		public int AudioSceneIRComputeCustomPoints(IntPtr sceneIR, float[] points, UIntPtr pointCount, ref MapParameters parameters)
		{
			return ovrAudio_AudioSceneIRComputeCustomPoints(sceneIR, points, pointCount, ref parameters);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioSceneIRGetPointCount(IntPtr sceneIR, out UIntPtr pointCount);

		public int AudioSceneIRGetPointCount(IntPtr sceneIR, out UIntPtr pointCount)
		{
			return ovrAudio_AudioSceneIRGetPointCount(sceneIR, out pointCount);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioSceneIRGetPoints(IntPtr sceneIR, float[] points, UIntPtr maxPointCount);

		public int AudioSceneIRGetPoints(IntPtr sceneIR, float[] points, UIntPtr maxPointCount)
		{
			return ovrAudio_AudioSceneIRGetPoints(sceneIR, points, maxPointCount);
		}

		[DllImport("MetaXRAudioWwise")]
		private unsafe static extern int ovrAudio_AudioSceneIRSetTransform(IntPtr sceneIR, float* matrix4x4);

		public unsafe int AudioSceneIRSetTransform(IntPtr sceneIR, in Matrix4x4 matrix)
		{
			float* ptr = stackalloc float[16];
			*ptr = matrix.m00;
			ptr[1] = matrix.m10;
			ptr[2] = 0f - matrix.m20;
			ptr[3] = matrix.m30;
			ptr[4] = matrix.m01;
			ptr[5] = matrix.m11;
			ptr[6] = 0f - matrix.m21;
			ptr[7] = matrix.m31;
			ptr[8] = matrix.m02;
			ptr[9] = matrix.m12;
			ptr[10] = 0f - matrix.m22;
			ptr[11] = matrix.m32;
			ptr[12] = matrix.m03;
			ptr[13] = matrix.m13;
			ptr[14] = 0f - matrix.m23;
			ptr[15] = matrix.m33;
			return ovrAudio_AudioSceneIRSetTransform(sceneIR, ptr);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioSceneIRGetTransform(IntPtr sceneIR, out float[] matrix4x4);

		public int AudioSceneIRGetTransform(IntPtr sceneIR, out float[] matrix4x4)
		{
			return ovrAudio_AudioSceneIRGetTransform(sceneIR, out matrix4x4);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioSceneIRWriteFile(IntPtr sceneIR, string filePath);

		public int AudioSceneIRWriteFile(IntPtr sceneIR, string filePath)
		{
			return ovrAudio_AudioSceneIRWriteFile(sceneIR, filePath);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioSceneIRReadFile(IntPtr sceneIR, string filePath);

		public int AudioSceneIRReadFile(IntPtr sceneIR, string filePath)
		{
			return ovrAudio_AudioSceneIRReadFile(sceneIR, filePath);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_AudioSceneIRReadMemory(IntPtr sceneIR, IntPtr data, ulong dataLength);

		public int AudioSceneIRReadMemory(IntPtr sceneIR, IntPtr data, ulong dataLength)
		{
			return ovrAudio_AudioSceneIRReadMemory(sceneIR, data, dataLength);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_CreateControlZone(IntPtr context, out IntPtr control);

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_CreateControlVolume(IntPtr context, out IntPtr control);

		public int CreateControlZone(out IntPtr control)
		{
			try
			{
				return ovrAudio_CreateControlZone(context, out control);
			}
			catch
			{
				return ovrAudio_CreateControlVolume(context, out control);
			}
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_DestroyControlZone(IntPtr control);

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_DestroyControlVolume(IntPtr control);

		public int DestroyControlZone(IntPtr control)
		{
			try
			{
				return ovrAudio_DestroyControlZone(control);
			}
			catch
			{
				return ovrAudio_DestroyControlVolume(control);
			}
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlZoneSetEnabled(IntPtr control, int enabled);

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlVolumeSetEnabled(IntPtr control, int enabled);

		public int ControlZoneSetEnabled(IntPtr control, bool enabled)
		{
			try
			{
				return ovrAudio_ControlZoneSetEnabled(control, enabled ? 1 : 0);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetEnabled(control, enabled ? 1 : 0);
			}
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlZoneGetEnabled(IntPtr control, out int enabled);

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlVolumeGetEnabled(IntPtr control, out int enabled);

		public int ControlZoneGetEnabled(IntPtr control, out bool enabled)
		{
			int enabled2 = 0;
			int result;
			try
			{
				result = ovrAudio_ControlZoneGetEnabled(control, out enabled2);
			}
			catch
			{
				result = ovrAudio_ControlVolumeGetEnabled(control, out enabled2);
			}
			enabled = enabled2 != 0;
			return result;
		}

		[DllImport("MetaXRAudioWwise")]
		private unsafe static extern int ovrAudio_ControlZoneSetTransform(IntPtr control, float* matrix4x4);

		[DllImport("MetaXRAudioWwise")]
		private unsafe static extern int ovrAudio_ControlVolumeSetTransform(IntPtr control, float* matrix4x4);

		public unsafe int ControlZoneSetTransform(IntPtr control, in Matrix4x4 matrix)
		{
			float* ptr = stackalloc float[16];
			*ptr = matrix.m00;
			ptr[1] = matrix.m10;
			ptr[2] = 0f - matrix.m20;
			ptr[3] = matrix.m30;
			ptr[4] = matrix.m01;
			ptr[5] = matrix.m11;
			ptr[6] = 0f - matrix.m21;
			ptr[7] = matrix.m31;
			ptr[8] = matrix.m02;
			ptr[9] = matrix.m12;
			ptr[10] = 0f - matrix.m22;
			ptr[11] = matrix.m32;
			ptr[12] = matrix.m03;
			ptr[13] = matrix.m13;
			ptr[14] = 0f - matrix.m23;
			ptr[15] = matrix.m33;
			try
			{
				return ovrAudio_ControlZoneSetTransform(control, ptr);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetTransform(control, ptr);
			}
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlZoneGetTransform(IntPtr control, out float[] matrix4x4);

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlVolumeGetTransform(IntPtr control, out float[] matrix4x4);

		public int ControlZoneGetTransform(IntPtr control, out float[] matrix4x4)
		{
			try
			{
				return ovrAudio_ControlZoneGetTransform(control, out matrix4x4);
			}
			catch
			{
				return ovrAudio_ControlVolumeGetTransform(control, out matrix4x4);
			}
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlZoneSetBox(IntPtr control, float sizeX, float sizeY, float sizeZ);

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlVolumeSetBox(IntPtr control, float sizeX, float sizeY, float sizeZ);

		public int ControlZoneSetBox(IntPtr control, float sizeX, float sizeY, float sizeZ)
		{
			try
			{
				return ovrAudio_ControlZoneSetBox(control, sizeX, sizeY, sizeZ);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetBox(control, sizeX, sizeY, sizeZ);
			}
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlZoneGetBox(IntPtr control, out float sizeX, out float sizeY, out float sizeZ);

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlVolumeGetBox(IntPtr control, out float sizeX, out float sizeY, out float sizeZ);

		public int ControlZoneGetBox(IntPtr control, out float sizeX, out float sizeY, out float sizeZ)
		{
			try
			{
				return ovrAudio_ControlZoneGetBox(control, out sizeX, out sizeY, out sizeZ);
			}
			catch
			{
				return ovrAudio_ControlVolumeGetBox(control, out sizeX, out sizeY, out sizeZ);
			}
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlZoneSetFadeDistance(IntPtr control, float fadeX, float fadeY, float fadeZ);

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlVolumeSetFadeDistance(IntPtr control, float fadeX, float fadeY, float fadeZ);

		public int ControlZoneSetFadeDistance(IntPtr control, float fadeX, float fadeY, float fadeZ)
		{
			try
			{
				return ovrAudio_ControlZoneSetFadeDistance(control, fadeX, fadeY, fadeZ);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetFadeDistance(control, fadeX, fadeY, fadeZ);
			}
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlZoneGetFadeDistance(IntPtr control, out float fadeX, out float fadeY, out float fadeZ);

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlVolumeGetFadeDistance(IntPtr control, out float fadeX, out float fadeY, out float fadeZ);

		public int ControlZoneGetFadeDistance(IntPtr control, out float fadeX, out float fadeY, out float fadeZ)
		{
			try
			{
				return ovrAudio_ControlZoneGetFadeDistance(control, out fadeX, out fadeY, out fadeZ);
			}
			catch
			{
				return ovrAudio_ControlVolumeGetFadeDistance(control, out fadeX, out fadeY, out fadeZ);
			}
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlZoneSetFrequency(IntPtr control, ControlZoneProperty property, float frequency, float value);

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlVolumeSetFrequency(IntPtr control, ControlZoneProperty property, float frequency, float value);

		public int ControlZoneSetFrequency(IntPtr control, ControlZoneProperty property, float frequency, float value)
		{
			try
			{
				return ovrAudio_ControlZoneSetFrequency(control, property, frequency, value);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetFrequency(control, property, frequency, value);
			}
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlZoneReset(IntPtr control, ControlZoneProperty property);

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_ControlVolumeReset(IntPtr control, ControlZoneProperty property);

		public int ControlZoneReset(IntPtr control, ControlZoneProperty property)
		{
			try
			{
				return ovrAudio_ControlZoneReset(control, property);
			}
			catch
			{
				return ovrAudio_ControlVolumeReset(control, property);
			}
		}

		int INativeInterface.AudioGeometrySetTransform(IntPtr geometry, in Matrix4x4 matrix)
		{
			return AudioGeometrySetTransform(geometry, in matrix);
		}

		int INativeInterface.AudioSceneIRSetTransform(IntPtr sceneIR, in Matrix4x4 matrix)
		{
			return AudioSceneIRSetTransform(sceneIR, in matrix);
		}

		int INativeInterface.ControlZoneSetTransform(IntPtr control, in Matrix4x4 matrix)
		{
			return ControlZoneSetTransform(control, in matrix);
		}
	}

	public class FMODPluginInterface : INativeInterface
	{
		public const string binaryName = "MetaXRAudioFMOD";

		private IntPtr context_ = IntPtr.Zero;

		private int version;

		private IntPtr context
		{
			get
			{
				if (context_ == IntPtr.Zero)
				{
					ovrAudio_GetPluginContext(out context_);
					ovrAudio_GetVersion(out var _, out version, out var _);
				}
				return context_;
			}
		}

		[DllImport("MetaXRAudioFMOD")]
		public static extern int ovrAudio_GetPluginContext(out IntPtr context);

		[DllImport("MetaXRAudioFMOD")]
		public static extern IntPtr ovrAudio_GetVersion(out int Major, out int Minor, out int Patch);

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_SetAcousticModel(IntPtr context, AcousticModel quality);

		public int SetAcousticModel(AcousticModel model)
		{
			return ovrAudio_SetAcousticModel(context, model);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ResetSharedReverb(IntPtr context);

		public int ResetReverb()
		{
			return ovrAudio_ResetSharedReverb(context);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_Enable(IntPtr context, int what, int enable);

		public int SetEnabled(int feature, bool enabled)
		{
			return ovrAudio_Enable(context, feature, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_Enable(IntPtr context, EnableFlagInternal what, int enable);

		public int SetEnabled(EnableFlagInternal feature, bool enabled)
		{
			return ovrAudio_Enable(context, feature, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_CreateAudioGeometry(IntPtr context, out IntPtr geometry);

		public int CreateAudioGeometry(out IntPtr geometry)
		{
			return ovrAudio_CreateAudioGeometry(context, out geometry);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_DestroyAudioGeometry(IntPtr geometry);

		public int DestroyAudioGeometry(IntPtr geometry)
		{
			return ovrAudio_DestroyAudioGeometry(geometry);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioGeometrySetObjectFlag(IntPtr geometry, ObjectFlags flag, int enabled);

		public int AudioGeometrySetObjectFlag(IntPtr geometry, ObjectFlags flag, bool enabled)
		{
			if (version < 94)
			{
				return -1;
			}
			return ovrAudio_AudioGeometrySetObjectFlag(geometry, flag, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioGeometryUploadMeshArrays(IntPtr geometry, float[] vertices, UIntPtr verticesBytesOffset, UIntPtr vertexCount, UIntPtr vertexStride, ovrAudioScalarType vertexType, int[] indices, UIntPtr indicesByteOffset, UIntPtr indexCount, ovrAudioScalarType indexType, MeshGroup[] groups, UIntPtr groupCount);

		public int AudioGeometryUploadMeshArrays(IntPtr geometry, float[] vertices, int vertexCount, int[] indices, int indexCount, MeshGroup[] groups, int groupCount)
		{
			return ovrAudio_AudioGeometryUploadMeshArrays(geometry, vertices, UIntPtr.Zero, (UIntPtr)(ulong)vertexCount, UIntPtr.Zero, ovrAudioScalarType.Float32, indices, UIntPtr.Zero, (UIntPtr)(ulong)indexCount, ovrAudioScalarType.UInt32, groups, (UIntPtr)(ulong)groupCount);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioGeometryUploadSimplifiedMeshArrays(IntPtr geometry, float[] vertices, UIntPtr verticesBytesOffset, UIntPtr vertexCount, UIntPtr vertexStride, ovrAudioScalarType vertexType, int[] indices, UIntPtr indicesByteOffset, UIntPtr indexCount, ovrAudioScalarType indexType, MeshGroup[] groups, UIntPtr groupCount, ref MeshSimplification simplification);

		public int AudioGeometryUploadSimplifiedMeshArrays(IntPtr geometry, float[] vertices, int vertexCount, int[] indices, int indexCount, MeshGroup[] groups, int groupCount, ref MeshSimplification simplification)
		{
			return ovrAudio_AudioGeometryUploadSimplifiedMeshArrays(geometry, vertices, UIntPtr.Zero, (UIntPtr)(ulong)vertexCount, UIntPtr.Zero, ovrAudioScalarType.Float32, indices, UIntPtr.Zero, (UIntPtr)(ulong)indexCount, ovrAudioScalarType.UInt32, groups, (UIntPtr)(ulong)groupCount, ref simplification);
		}

		[DllImport("MetaXRAudioFMOD")]
		private unsafe static extern int ovrAudio_AudioGeometrySetTransform(IntPtr geometry, float* matrix4x4);

		public unsafe int AudioGeometrySetTransform(IntPtr geometry, in Matrix4x4 matrix)
		{
			float* ptr = stackalloc float[16];
			*ptr = matrix.m00;
			ptr[1] = matrix.m10;
			ptr[2] = 0f - matrix.m20;
			ptr[3] = matrix.m30;
			ptr[4] = matrix.m01;
			ptr[5] = matrix.m11;
			ptr[6] = 0f - matrix.m21;
			ptr[7] = matrix.m31;
			ptr[8] = matrix.m02;
			ptr[9] = matrix.m12;
			ptr[10] = 0f - matrix.m22;
			ptr[11] = matrix.m32;
			ptr[12] = matrix.m03;
			ptr[13] = matrix.m13;
			ptr[14] = 0f - matrix.m23;
			ptr[15] = matrix.m33;
			return ovrAudio_AudioGeometrySetTransform(geometry, ptr);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioGeometryGetTransform(IntPtr geometry, out float[] matrix4x4);

		public int AudioGeometryGetTransform(IntPtr geometry, out float[] matrix4x4)
		{
			return ovrAudio_AudioGeometryGetTransform(geometry, out matrix4x4);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioGeometryWriteMeshFile(IntPtr geometry, string filePath);

		public int AudioGeometryWriteMeshFile(IntPtr geometry, string filePath)
		{
			return ovrAudio_AudioGeometryWriteMeshFile(geometry, filePath);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioGeometryReadMeshFile(IntPtr geometry, string filePath);

		public int AudioGeometryReadMeshFile(IntPtr geometry, string filePath)
		{
			return ovrAudio_AudioGeometryReadMeshFile(geometry, filePath);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioGeometryReadMeshMemory(IntPtr geometry, IntPtr data, ulong dataLength);

		public int AudioGeometryReadMeshMemory(IntPtr geometry, IntPtr data, ulong dataLength)
		{
			return ovrAudio_AudioGeometryReadMeshMemory(geometry, data, dataLength);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioGeometryWriteMeshFileObj(IntPtr geometry, string filePath);

		public int AudioGeometryWriteMeshFileObj(IntPtr geometry, string filePath)
		{
			return ovrAudio_AudioGeometryWriteMeshFileObj(geometry, filePath);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioGeometryGetSimplifiedMeshWithMaterials(IntPtr geometry, IntPtr unused1, out uint numVertices, IntPtr unused2, IntPtr unused3, out uint numTriangles);

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioGeometryGetSimplifiedMeshWithMaterials(IntPtr geometry, float[] vertices, ref uint numVertices, uint[] indices, uint[] materialIndices, ref uint numTriangles);

		public int AudioGeometryGetSimplifiedMesh(IntPtr geometry, out float[] vertices, out uint[] indices, out uint[] materialIndices)
		{
			uint numVertices;
			uint numTriangles;
			int num = ovrAudio_AudioGeometryGetSimplifiedMeshWithMaterials(geometry, IntPtr.Zero, out numVertices, IntPtr.Zero, IntPtr.Zero, out numTriangles);
			if (num != 0)
			{
				UnityEngine.Debug.LogError("unexpected error getting simplified mesh array sizes");
				vertices = null;
				indices = null;
				materialIndices = null;
				return num;
			}
			vertices = new float[numVertices * 3];
			indices = new uint[numTriangles * 3];
			materialIndices = new uint[numTriangles];
			return ovrAudio_AudioGeometryGetSimplifiedMeshWithMaterials(geometry, vertices, ref numVertices, indices, materialIndices, ref numTriangles);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_CreateAudioMaterial(IntPtr context, out IntPtr material);

		public int CreateAudioMaterial(out IntPtr material)
		{
			return ovrAudio_CreateAudioMaterial(context, out material);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_DestroyAudioMaterial(IntPtr material);

		public int DestroyAudioMaterial(IntPtr material)
		{
			return ovrAudio_DestroyAudioMaterial(material);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioMaterialSetFrequency(IntPtr material, MaterialProperty property, float frequency, float value);

		public int AudioMaterialSetFrequency(IntPtr material, MaterialProperty property, float frequency, float value)
		{
			return ovrAudio_AudioMaterialSetFrequency(material, property, frequency, value);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioMaterialGetFrequency(IntPtr material, MaterialProperty property, float frequency, out float value);

		public int AudioMaterialGetFrequency(IntPtr material, MaterialProperty property, float frequency, out float value)
		{
			return ovrAudio_AudioMaterialGetFrequency(material, property, frequency, out value);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioMaterialReset(IntPtr material, MaterialProperty property);

		public int AudioMaterialReset(IntPtr material, MaterialProperty property)
		{
			return ovrAudio_AudioMaterialReset(material, property);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_CreateAudioSceneIR(IntPtr context, out IntPtr sceneIR);

		public int CreateAudioSceneIR(out IntPtr sceneIR)
		{
			return ovrAudio_CreateAudioSceneIR(context, out sceneIR);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_DestroyAudioSceneIR(IntPtr sceneIR);

		public int DestroyAudioSceneIR(IntPtr sceneIR)
		{
			return ovrAudio_DestroyAudioSceneIR(sceneIR);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioSceneIRSetEnabled(IntPtr sceneIR, int enabled);

		public int AudioSceneIRSetEnabled(IntPtr sceneIR, bool enabled)
		{
			return ovrAudio_AudioSceneIRSetEnabled(sceneIR, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioSceneIRGetEnabled(IntPtr sceneIR, out int enabled);

		public int AudioSceneIRGetEnabled(IntPtr sceneIR, out bool enabled)
		{
			int enabled2;
			int result = ovrAudio_AudioSceneIRGetEnabled(sceneIR, out enabled2);
			enabled = enabled2 != 0;
			return result;
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioSceneIRGetStatus(IntPtr sceneIR, out AcousticMapStatus status);

		public int AudioSceneIRGetStatus(IntPtr sceneIR, out AcousticMapStatus status)
		{
			return ovrAudio_AudioSceneIRGetStatus(sceneIR, out status);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_InitializeAudioSceneIRParameters(out MapParameters parameters);

		public int InitializeAudioSceneIRParameters(out MapParameters parameters)
		{
			return ovrAudio_InitializeAudioSceneIRParameters(out parameters);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioSceneIRCompute(IntPtr sceneIR, ref MapParameters parameters);

		public int AudioSceneIRCompute(IntPtr sceneIR, ref MapParameters parameters)
		{
			return ovrAudio_AudioSceneIRCompute(sceneIR, ref parameters);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioSceneIRComputeCustomPoints(IntPtr sceneIR, float[] points, UIntPtr pointCount, ref MapParameters parameters);

		public int AudioSceneIRComputeCustomPoints(IntPtr sceneIR, float[] points, UIntPtr pointCount, ref MapParameters parameters)
		{
			return ovrAudio_AudioSceneIRComputeCustomPoints(sceneIR, points, pointCount, ref parameters);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioSceneIRGetPointCount(IntPtr sceneIR, out UIntPtr pointCount);

		public int AudioSceneIRGetPointCount(IntPtr sceneIR, out UIntPtr pointCount)
		{
			return ovrAudio_AudioSceneIRGetPointCount(sceneIR, out pointCount);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioSceneIRGetPoints(IntPtr sceneIR, float[] points, UIntPtr maxPointCount);

		public int AudioSceneIRGetPoints(IntPtr sceneIR, float[] points, UIntPtr maxPointCount)
		{
			return ovrAudio_AudioSceneIRGetPoints(sceneIR, points, maxPointCount);
		}

		[DllImport("MetaXRAudioFMOD")]
		private unsafe static extern int ovrAudio_AudioSceneIRSetTransform(IntPtr sceneIR, float* matrix4x4);

		public unsafe int AudioSceneIRSetTransform(IntPtr sceneIR, in Matrix4x4 matrix)
		{
			float* ptr = stackalloc float[16];
			*ptr = matrix.m00;
			ptr[1] = matrix.m10;
			ptr[2] = 0f - matrix.m20;
			ptr[3] = matrix.m30;
			ptr[4] = matrix.m01;
			ptr[5] = matrix.m11;
			ptr[6] = 0f - matrix.m21;
			ptr[7] = matrix.m31;
			ptr[8] = matrix.m02;
			ptr[9] = matrix.m12;
			ptr[10] = 0f - matrix.m22;
			ptr[11] = matrix.m32;
			ptr[12] = matrix.m03;
			ptr[13] = matrix.m13;
			ptr[14] = 0f - matrix.m23;
			ptr[15] = matrix.m33;
			return ovrAudio_AudioSceneIRSetTransform(sceneIR, ptr);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioSceneIRGetTransform(IntPtr sceneIR, out float[] matrix4x4);

		public int AudioSceneIRGetTransform(IntPtr sceneIR, out float[] matrix4x4)
		{
			return ovrAudio_AudioSceneIRGetTransform(sceneIR, out matrix4x4);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioSceneIRWriteFile(IntPtr sceneIR, string filePath);

		public int AudioSceneIRWriteFile(IntPtr sceneIR, string filePath)
		{
			return ovrAudio_AudioSceneIRWriteFile(sceneIR, filePath);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioSceneIRReadFile(IntPtr sceneIR, string filePath);

		public int AudioSceneIRReadFile(IntPtr sceneIR, string filePath)
		{
			return ovrAudio_AudioSceneIRReadFile(sceneIR, filePath);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_AudioSceneIRReadMemory(IntPtr sceneIR, IntPtr data, ulong dataLength);

		public int AudioSceneIRReadMemory(IntPtr sceneIR, IntPtr data, ulong dataLength)
		{
			return ovrAudio_AudioSceneIRReadMemory(sceneIR, data, dataLength);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_CreateControlZone(IntPtr context, out IntPtr control);

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_CreateControlVolume(IntPtr context, out IntPtr control);

		public int CreateControlZone(out IntPtr control)
		{
			try
			{
				return ovrAudio_CreateControlZone(context, out control);
			}
			catch
			{
				return ovrAudio_CreateControlVolume(context, out control);
			}
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_DestroyControlZone(IntPtr control);

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_DestroyControlVolume(IntPtr control);

		public int DestroyControlZone(IntPtr control)
		{
			try
			{
				return ovrAudio_DestroyControlZone(control);
			}
			catch
			{
				return ovrAudio_DestroyControlVolume(control);
			}
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlZoneSetEnabled(IntPtr control, int enabled);

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlVolumeSetEnabled(IntPtr control, int enabled);

		public int ControlZoneSetEnabled(IntPtr control, bool enabled)
		{
			try
			{
				return ovrAudio_ControlZoneSetEnabled(control, enabled ? 1 : 0);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetEnabled(control, enabled ? 1 : 0);
			}
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlZoneGetEnabled(IntPtr control, out int enabled);

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlVolumeGetEnabled(IntPtr control, out int enabled);

		public int ControlZoneGetEnabled(IntPtr control, out bool enabled)
		{
			int enabled2 = 0;
			int result;
			try
			{
				result = ovrAudio_ControlZoneGetEnabled(control, out enabled2);
			}
			catch
			{
				result = ovrAudio_ControlVolumeGetEnabled(control, out enabled2);
			}
			enabled = enabled2 != 0;
			return result;
		}

		[DllImport("MetaXRAudioFMOD")]
		private unsafe static extern int ovrAudio_ControlZoneSetTransform(IntPtr control, float* matrix4x4);

		[DllImport("MetaXRAudioFMOD")]
		private unsafe static extern int ovrAudio_ControlVolumeSetTransform(IntPtr control, float* matrix4x4);

		public unsafe int ControlZoneSetTransform(IntPtr control, in Matrix4x4 matrix)
		{
			float* ptr = stackalloc float[16];
			*ptr = matrix.m00;
			ptr[1] = matrix.m10;
			ptr[2] = 0f - matrix.m20;
			ptr[3] = matrix.m30;
			ptr[4] = matrix.m01;
			ptr[5] = matrix.m11;
			ptr[6] = 0f - matrix.m21;
			ptr[7] = matrix.m31;
			ptr[8] = matrix.m02;
			ptr[9] = matrix.m12;
			ptr[10] = 0f - matrix.m22;
			ptr[11] = matrix.m32;
			ptr[12] = matrix.m03;
			ptr[13] = matrix.m13;
			ptr[14] = 0f - matrix.m23;
			ptr[15] = matrix.m33;
			try
			{
				return ovrAudio_ControlZoneSetTransform(control, ptr);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetTransform(control, ptr);
			}
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlZoneGetTransform(IntPtr control, out float[] matrix4x4);

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlVolumeGetTransform(IntPtr control, out float[] matrix4x4);

		public int ControlZoneGetTransform(IntPtr control, out float[] matrix4x4)
		{
			try
			{
				return ovrAudio_ControlZoneGetTransform(control, out matrix4x4);
			}
			catch
			{
				return ovrAudio_ControlVolumeGetTransform(control, out matrix4x4);
			}
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlZoneSetBox(IntPtr control, float sizeX, float sizeY, float sizeZ);

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlVolumeSetBox(IntPtr control, float sizeX, float sizeY, float sizeZ);

		public int ControlZoneSetBox(IntPtr control, float sizeX, float sizeY, float sizeZ)
		{
			try
			{
				return ovrAudio_ControlZoneSetBox(control, sizeX, sizeY, sizeZ);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetBox(control, sizeX, sizeY, sizeZ);
			}
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlZoneGetBox(IntPtr control, out float sizeX, out float sizeY, out float sizeZ);

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlVolumeGetBox(IntPtr control, out float sizeX, out float sizeY, out float sizeZ);

		public int ControlZoneGetBox(IntPtr control, out float sizeX, out float sizeY, out float sizeZ)
		{
			try
			{
				return ovrAudio_ControlZoneGetBox(control, out sizeX, out sizeY, out sizeZ);
			}
			catch
			{
				return ovrAudio_ControlVolumeGetBox(control, out sizeX, out sizeY, out sizeZ);
			}
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlZoneSetFadeDistance(IntPtr control, float fadeX, float fadeY, float fadeZ);

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlVolumeSetFadeDistance(IntPtr control, float fadeX, float fadeY, float fadeZ);

		public int ControlZoneSetFadeDistance(IntPtr control, float fadeX, float fadeY, float fadeZ)
		{
			try
			{
				return ovrAudio_ControlZoneSetFadeDistance(control, fadeX, fadeY, fadeZ);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetFadeDistance(control, fadeX, fadeY, fadeZ);
			}
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlZoneGetFadeDistance(IntPtr control, out float fadeX, out float fadeY, out float fadeZ);

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlVolumeGetFadeDistance(IntPtr control, out float fadeX, out float fadeY, out float fadeZ);

		public int ControlZoneGetFadeDistance(IntPtr control, out float fadeX, out float fadeY, out float fadeZ)
		{
			try
			{
				return ovrAudio_ControlZoneGetFadeDistance(control, out fadeX, out fadeY, out fadeZ);
			}
			catch
			{
				return ovrAudio_ControlVolumeGetFadeDistance(control, out fadeX, out fadeY, out fadeZ);
			}
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlZoneSetFrequency(IntPtr control, ControlZoneProperty property, float frequency, float value);

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlVolumeSetFrequency(IntPtr control, ControlZoneProperty property, float frequency, float value);

		public int ControlZoneSetFrequency(IntPtr control, ControlZoneProperty property, float frequency, float value)
		{
			try
			{
				return ovrAudio_ControlZoneSetFrequency(control, property, frequency, value);
			}
			catch
			{
				return ovrAudio_ControlVolumeSetFrequency(control, property, frequency, value);
			}
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlZoneReset(IntPtr control, ControlZoneProperty property);

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_ControlVolumeReset(IntPtr control, ControlZoneProperty property);

		public int ControlZoneReset(IntPtr control, ControlZoneProperty property)
		{
			try
			{
				return ovrAudio_ControlZoneReset(control, property);
			}
			catch
			{
				return ovrAudio_ControlVolumeReset(control, property);
			}
		}

		int INativeInterface.AudioGeometrySetTransform(IntPtr geometry, in Matrix4x4 matrix)
		{
			return AudioGeometrySetTransform(geometry, in matrix);
		}

		int INativeInterface.AudioSceneIRSetTransform(IntPtr sceneIR, in Matrix4x4 matrix)
		{
			return AudioSceneIRSetTransform(sceneIR, in matrix);
		}

		int INativeInterface.ControlZoneSetTransform(IntPtr control, in Matrix4x4 matrix)
		{
			return ControlZoneSetTransform(control, in matrix);
		}
	}

	public class DummyInterface : INativeInterface
	{
		public int SetAcousticModel(AcousticModel model)
		{
			return -1;
		}

		public int ResetReverb()
		{
			return -1;
		}

		public int SetEnabled(int feature, bool enabled)
		{
			return -1;
		}

		public int SetEnabled(EnableFlagInternal feature, bool enabled)
		{
			return -1;
		}

		public int CreateAudioGeometry(out IntPtr geometry)
		{
			geometry = IntPtr.Zero;
			return -1;
		}

		public int DestroyAudioGeometry(IntPtr geometry)
		{
			return -1;
		}

		public int AudioGeometrySetObjectFlag(IntPtr geometry, ObjectFlags flag, bool enabled)
		{
			return -1;
		}

		public int AudioGeometryUploadMeshArrays(IntPtr geometry, float[] vertices, int vertexCount, int[] indices, int indexCount, MeshGroup[] groups, int groupCount)
		{
			return -1;
		}

		public int AudioGeometryUploadSimplifiedMeshArrays(IntPtr geometry, float[] vertices, int vertexCount, int[] indices, int indexCount, MeshGroup[] groups, int groupCount, ref MeshSimplification simplification)
		{
			return -1;
		}

		public int AudioGeometrySetTransform(IntPtr geometry, in Matrix4x4 matrix)
		{
			return -1;
		}

		public int AudioGeometryGetTransform(IntPtr geometry, out float[] matrix4x4)
		{
			matrix4x4 = null;
			return -1;
		}

		public int AudioGeometryWriteMeshFile(IntPtr geometry, string filePath)
		{
			return -1;
		}

		public int AudioGeometryReadMeshFile(IntPtr geometry, string filePath)
		{
			return -1;
		}

		public int AudioGeometryReadMeshMemory(IntPtr geometry, IntPtr data, ulong dataLength)
		{
			return -1;
		}

		public int AudioGeometryWriteMeshFileObj(IntPtr geometry, string filePath)
		{
			return -1;
		}

		public int AudioGeometryGetSimplifiedMesh(IntPtr geometry, out float[] vertices, out uint[] indices, out uint[] materialIndices)
		{
			vertices = null;
			indices = null;
			materialIndices = null;
			return -1;
		}

		public int AudioMaterialGetFrequency(IntPtr material, MaterialProperty property, float frequency, out float value)
		{
			value = 0f;
			return -1;
		}

		public int CreateAudioMaterial(out IntPtr material)
		{
			material = IntPtr.Zero;
			return -1;
		}

		public int DestroyAudioMaterial(IntPtr material)
		{
			return -1;
		}

		public int AudioMaterialSetFrequency(IntPtr material, MaterialProperty property, float frequency, float value)
		{
			return -1;
		}

		public int AudioMaterialReset(IntPtr material, MaterialProperty property)
		{
			return -1;
		}

		public int CreateAudioSceneIR(out IntPtr sceneIR)
		{
			sceneIR = IntPtr.Zero;
			return -1;
		}

		public int DestroyAudioSceneIR(IntPtr sceneIR)
		{
			return -1;
		}

		public int AudioSceneIRSetEnabled(IntPtr sceneIR, bool enabled)
		{
			return -1;
		}

		public int AudioSceneIRGetEnabled(IntPtr sceneIR, out bool enabled)
		{
			enabled = false;
			return -1;
		}

		public int AudioSceneIRGetStatus(IntPtr sceneIR, out AcousticMapStatus status)
		{
			status = AcousticMapStatus.EMPTY;
			return -1;
		}

		public int InitializeAudioSceneIRParameters(out MapParameters parameters)
		{
			parameters = default(MapParameters);
			return -1;
		}

		public int AudioSceneIRCompute(IntPtr sceneIR, ref MapParameters parameters)
		{
			return -1;
		}

		public int AudioSceneIRComputeCustomPoints(IntPtr sceneIR, float[] points, UIntPtr pointCount, ref MapParameters parameters)
		{
			return -1;
		}

		public int AudioSceneIRGetPointCount(IntPtr sceneIR, out UIntPtr pointCount)
		{
			pointCount = UIntPtr.Zero;
			return -1;
		}

		public int AudioSceneIRGetPoints(IntPtr sceneIR, float[] points, UIntPtr maxPointCount)
		{
			return -1;
		}

		public int AudioSceneIRSetTransform(IntPtr sceneIR, in Matrix4x4 matrix)
		{
			return -1;
		}

		public int AudioSceneIRGetTransform(IntPtr sceneIR, out float[] matrix4x4)
		{
			matrix4x4 = new float[16];
			return -1;
		}

		public int AudioSceneIRWriteFile(IntPtr sceneIR, string filePath)
		{
			return -1;
		}

		public int AudioSceneIRReadFile(IntPtr sceneIR, string filePath)
		{
			return -1;
		}

		public int AudioSceneIRReadMemory(IntPtr sceneIR, IntPtr data, ulong dataLength)
		{
			return -1;
		}

		public int CreateControlZone(out IntPtr control)
		{
			control = IntPtr.Zero;
			return -1;
		}

		public int DestroyControlZone(IntPtr control)
		{
			return -1;
		}

		public int ControlZoneSetEnabled(IntPtr control, bool enabled)
		{
			return -1;
		}

		public int ControlZoneGetEnabled(IntPtr control, out bool enabled)
		{
			enabled = false;
			return -1;
		}

		public int ControlZoneSetTransform(IntPtr control, in Matrix4x4 matrix)
		{
			return -1;
		}

		public int ControlZoneGetTransform(IntPtr control, out float[] matrix4x4)
		{
			matrix4x4 = new float[16];
			return -1;
		}

		public int ControlZoneSetBox(IntPtr control, float sizeX, float sizeY, float sizeZ)
		{
			return -1;
		}

		public int ControlZoneGetBox(IntPtr control, out float sizeX, out float sizeY, out float sizeZ)
		{
			sizeX = 0f;
			sizeY = 0f;
			sizeZ = 0f;
			return -1;
		}

		public int ControlZoneSetFadeDistance(IntPtr control, float fadeX, float fadeY, float fadeZ)
		{
			return -1;
		}

		public int ControlZoneGetFadeDistance(IntPtr control, out float fadeX, out float fadeY, out float fadeZ)
		{
			fadeX = 0f;
			fadeY = 0f;
			fadeZ = 0f;
			return -1;
		}

		public int ControlZoneSetFrequency(IntPtr control, ControlZoneProperty property, float frequency, float value)
		{
			return -1;
		}

		public int ControlZoneReset(IntPtr control, ControlZoneProperty property)
		{
			return -1;
		}

		int INativeInterface.AudioGeometrySetTransform(IntPtr geometry, in Matrix4x4 matrix)
		{
			return AudioGeometrySetTransform(geometry, in matrix);
		}

		int INativeInterface.AudioSceneIRSetTransform(IntPtr sceneIR, in Matrix4x4 matrix)
		{
			return AudioSceneIRSetTransform(sceneIR, in matrix);
		}

		int INativeInterface.ControlZoneSetTransform(IntPtr control, in Matrix4x4 matrix)
		{
			return ControlZoneSetTransform(control, in matrix);
		}
	}

	private static INativeInterface CachedInterface;

	public static INativeInterface Interface
	{
		get
		{
			if (CachedInterface == null)
			{
				CachedInterface = FindInterface();
			}
			return CachedInterface;
		}
	}

	private static INativeInterface FindInterface()
	{
		try
		{
			WwisePluginInterface.getOrCreateGlobalOvrAudioContext();
			WwisePluginInterface.ovrAudio_GetVersion(out var _, out var Minor, out var _);
			if (Minor < 92)
			{
				UnityEngine.Debug.LogError("Incompatible SDK version, update your MetaXRAudioWwise plugin");
				return new DummyInterface();
			}
			UnityEngine.Debug.Log("Meta XR Audio Native Interface initialized with Wwise plugin");
			return new WwisePluginInterface();
		}
		catch (DllNotFoundException)
		{
		}
		try
		{
			FMODPluginInterface.ovrAudio_GetPluginContext(out var _);
			FMODPluginInterface.ovrAudio_GetVersion(out var _, out var Minor2, out var _);
			if (Minor2 < 92)
			{
				UnityEngine.Debug.LogError("Incompatible SDK version, update your MetaXRAudioFMOD plugin");
				return new DummyInterface();
			}
			UnityEngine.Debug.Log("Meta XR Audio Native Interface initialized with FMOD plugin");
			return new FMODPluginInterface();
		}
		catch (DllNotFoundException)
		{
		}
		try
		{
			UnityNativeInterface.ovrAudio_GetPluginContext(out var _);
			UnityNativeInterface.ovrAudio_GetVersion(out var _, out var Minor3, out var _);
			if (Minor3 < 92)
			{
				UnityEngine.Debug.LogError("Incompatible SDK version, update your MetaXRAudioFMOD plugin");
				return new DummyInterface();
			}
			UnityEngine.Debug.Log("Meta XR Audio Native Interface initialized with Unity plugin");
			return new UnityNativeInterface();
		}
		catch
		{
			UnityEngine.Debug.LogError("Unable to locate MetaXRAudio plugin for MetaXRAcoustics!\nIf you're using Unity audio make sure you have imported the MetaXRAudioUnity package\nIf you're using Wwise or FMOD make sure you have their Unity integration in your project and the MetaXRAudioWwise or MetaXRAudioFMOD plugins in correct location in the Assets folder");
		}
		return new DummyInterface();
	}
}
[CreateAssetMenu(menuName = "MetaXRAudio/Acoustic Scene Group")]
internal class MetaXRAcousticSceneGroup : ScriptableObject
{
	[SerializeField]
	internal string[] sceneGuids;
}
public class MetaXRAcousticSettings : ScriptableObject
{
	[Tooltip("This is the path inside your Unity project which will store all baked geometry files.")]
	internal const string AcousticFileRootDir = "StreamingAssets/Acoustics";

	[SerializeField]
	[Tooltip("Select which type of acoustic modeling system is used to generate reverb and reflections.")]
	private AcousticModel acousticModel = AcousticModel.Automatic;

	[SerializeField]
	[Tooltip("When enabled and using geometry, all spatailized AudioSources will diffract (propagate around corners and obstructions)")]
	private bool diffractionEnabled = true;

	[SerializeField]
	[Tooltip("Geometry will exclude children with these tags")]
	private string[] excludeTags = new string[0];

	[SerializeField]
	[Tooltip("When you bake an acoustic map, also bake all the acoustic geometry files")]
	private bool mapBakeWriteGeo = true;

	private static MetaXRAcousticSettings instance;

	public AcousticModel AcousticModel
	{
		get
		{
			return acousticModel;
		}
		set
		{
			if (value != acousticModel)
			{
				acousticModel = value;
				MetaXRAcousticNativeInterface.Interface.SetAcousticModel(value);
			}
		}
	}

	internal bool DiffractionEnabled
	{
		get
		{
			return diffractionEnabled;
		}
		set
		{
			if (value != diffractionEnabled)
			{
				diffractionEnabled = value;
				MetaXRAcousticNativeInterface.Interface.SetEnabled(EnableFlagInternal.DIFFRACTION, value);
			}
		}
	}

	internal string[] ExcludeTags
	{
		get
		{
			return excludeTags;
		}
		set
		{
			excludeTags = value;
		}
	}

	[Tooltip("If enabled, acoustic geometry files will also be written when baking an acoustic map")]
	internal bool MapBakeWriteGeo
	{
		get
		{
			return mapBakeWriteGeo;
		}
		set
		{
			mapBakeWriteGeo = value;
		}
	}

	public static MetaXRAcousticSettings Instance
	{
		get
		{
			if (instance == null)
			{
				instance = Resources.Load<MetaXRAcousticSettings>("MetaXRAcousticSettings");
				if (instance == null)
				{
					instance = ScriptableObject.CreateInstance<MetaXRAcousticSettings>();
				}
			}
			return instance;
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void OnBeforeSceneLoadRuntimeMethod()
	{
		Instance.ApplyAllSettings();
	}

	internal void ApplyAllSettings()
	{
		UnityEngine.Debug.Log("Applying Acoustic Propagation Settings: " + $"[acoustic model = {AcousticModel}], " + $"[diffraction = {DiffractionEnabled}], ");
		MetaXRAcousticNativeInterface.Interface.SetAcousticModel(AcousticModel);
		MetaXRAcousticNativeInterface.Interface.SetEnabled(EnableFlagInternal.DIFFRACTION, DiffractionEnabled);
	}
}
public class MetaXRAudioNativeInterface
{
	public enum ovrAudioScalarType : uint
	{
		Int8,
		UInt8,
		Int16,
		UInt16,
		Int32,
		UInt32,
		Int64,
		UInt64,
		Float16,
		Float32,
		Float64
	}

	public interface NativeInterface
	{
		int SetAdvancedBoxRoomParameters(float width, float height, float depth, bool lockToListenerPosition, Vector3 position, float[] wallMaterials);

		int SetSharedReverbWetLevel(float linearLevel);

		int SetEnabled(int feature, bool enabled);

		int SetRoomClutterFactor(float[] clutterFactor);

		int SetDynamicRoomRaysPerSecond(int RaysPerSecond);

		int SetDynamicRoomInterpSpeed(float InterpSpeed);

		int SetDynamicRoomMaxWallDistance(float MaxWallDistance);

		int SetDynamicRoomRaysRayCacheSize(int RayCacheSize);

		int GetRoomDimensions(float[] roomDimensions, float[] reflectionsCoefs, out Vector3 position);

		int GetRaycastHits(Vector3[] points, Vector3[] normals, int length);
	}

	public class UnityNativeInterface : NativeInterface
	{
		public const string binaryName = "MetaXRAudioUnity";

		private IntPtr context_ = IntPtr.Zero;

		private IntPtr context
		{
			get
			{
				if (context_ == IntPtr.Zero)
				{
					ovrAudio_GetPluginContext(out context_);
				}
				return context_;
			}
		}

		[DllImport("MetaXRAudioUnity")]
		public static extern int ovrAudio_GetPluginContext(out IntPtr context);

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_SetAdvancedBoxRoomParametersUnity(IntPtr context, float width, float height, float depth, bool lockToListenerPosition, float positionX, float positionY, float positionZ, float[] wallMaterials);

		public int SetAdvancedBoxRoomParameters(float width, float height, float depth, bool lockToListenerPosition, Vector3 position, float[] wallMaterials)
		{
			return ovrAudio_SetAdvancedBoxRoomParametersUnity(context, width, height, depth, lockToListenerPosition, position.x, position.y, 0f - position.z, wallMaterials);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_SetRoomClutterFactor(IntPtr context, float[] clutterFactor);

		public int SetRoomClutterFactor(float[] clutterFactor)
		{
			return ovrAudio_SetRoomClutterFactor(context, clutterFactor);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_SetSharedReverbWetLevel(IntPtr context, float linearLevel);

		public int SetSharedReverbWetLevel(float linearLevel)
		{
			return ovrAudio_SetSharedReverbWetLevel(context, linearLevel);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_Enable(IntPtr context, int what, int enable);

		public int SetEnabled(int feature, bool enabled)
		{
			return ovrAudio_Enable(context, feature, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_Enable(IntPtr context, EnableFlag what, int enable);

		public int SetEnabled(EnableFlag feature, bool enabled)
		{
			return ovrAudio_Enable(context, feature, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_SetDynamicRoomRaysPerSecond(IntPtr context, int RaysPerSecond);

		public int SetDynamicRoomRaysPerSecond(int RaysPerSecond)
		{
			return ovrAudio_SetDynamicRoomRaysPerSecond(context, RaysPerSecond);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_SetDynamicRoomInterpSpeed(IntPtr context, float InterpSpeed);

		public int SetDynamicRoomInterpSpeed(float InterpSpeed)
		{
			return ovrAudio_SetDynamicRoomInterpSpeed(context, InterpSpeed);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_SetDynamicRoomMaxWallDistance(IntPtr context, float MaxWallDistance);

		public int SetDynamicRoomMaxWallDistance(float MaxWallDistance)
		{
			return ovrAudio_SetDynamicRoomMaxWallDistance(context, MaxWallDistance);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_SetDynamicRoomRaysRayCacheSize(IntPtr context, int RayCacheSize);

		public int SetDynamicRoomRaysRayCacheSize(int RayCacheSize)
		{
			return ovrAudio_SetDynamicRoomRaysRayCacheSize(context, RayCacheSize);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_GetRoomDimensions(IntPtr context, float[] roomDimensions, float[] reflectionsCoefs, out Vector3 position);

		public int GetRoomDimensions(float[] roomDimensions, float[] reflectionsCoefs, out Vector3 position)
		{
			return ovrAudio_GetRoomDimensions(context, roomDimensions, reflectionsCoefs, out position);
		}

		[DllImport("MetaXRAudioUnity")]
		private static extern int ovrAudio_GetRaycastHits(IntPtr context, Vector3[] points, Vector3[] normals, int length);

		public int GetRaycastHits(Vector3[] points, Vector3[] normals, int length)
		{
			return ovrAudio_GetRaycastHits(context, points, normals, length);
		}
	}

	public class WwisePluginInterface : NativeInterface
	{
		public const string binaryName = "MetaXRAudioWwise";

		private IntPtr context_ = IntPtr.Zero;

		private IntPtr context
		{
			get
			{
				if (context_ == IntPtr.Zero)
				{
					context_ = getOrCreateGlobalOvrAudioContext();
				}
				return context_;
			}
		}

		[DllImport("MetaXRAudioWwise")]
		public static extern IntPtr getOrCreateGlobalOvrAudioContext();

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_SetAdvancedBoxRoomParametersUnity(IntPtr context, float width, float height, float depth, bool lockToListenerPosition, float positionX, float positionY, float positionZ, float[] wallMaterials);

		public int SetAdvancedBoxRoomParameters(float width, float height, float depth, bool lockToListenerPosition, Vector3 position, float[] wallMaterials)
		{
			return ovrAudio_SetAdvancedBoxRoomParametersUnity(context, width, height, depth, lockToListenerPosition, position.x, position.y, 0f - position.z, wallMaterials);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_SetRoomClutterFactor(IntPtr context, float[] clutterFactor);

		public int SetRoomClutterFactor(float[] clutterFactor)
		{
			return ovrAudio_SetRoomClutterFactor(context, clutterFactor);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_SetSharedReverbWetLevel(IntPtr context, float linearLevel);

		public int SetSharedReverbWetLevel(float linearLevel)
		{
			return ovrAudio_SetSharedReverbWetLevel(context, linearLevel);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_Enable(IntPtr context, int what, int enable);

		public int SetEnabled(int feature, bool enabled)
		{
			return ovrAudio_Enable(context, feature, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_Enable(IntPtr context, EnableFlag what, int enable);

		public int SetEnabled(EnableFlag feature, bool enabled)
		{
			return ovrAudio_Enable(context, feature, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_SetDynamicRoomRaysPerSecond(IntPtr context, int RaysPerSecond);

		public int SetDynamicRoomRaysPerSecond(int RaysPerSecond)
		{
			return ovrAudio_SetDynamicRoomRaysPerSecond(context, RaysPerSecond);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_SetDynamicRoomInterpSpeed(IntPtr context, float InterpSpeed);

		public int SetDynamicRoomInterpSpeed(float InterpSpeed)
		{
			return ovrAudio_SetDynamicRoomInterpSpeed(context, InterpSpeed);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_SetDynamicRoomMaxWallDistance(IntPtr context, float MaxWallDistance);

		public int SetDynamicRoomMaxWallDistance(float MaxWallDistance)
		{
			return ovrAudio_SetDynamicRoomMaxWallDistance(context, MaxWallDistance);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_SetDynamicRoomRaysRayCacheSize(IntPtr context, int RayCacheSize);

		public int SetDynamicRoomRaysRayCacheSize(int RayCacheSize)
		{
			return ovrAudio_SetDynamicRoomRaysRayCacheSize(context, RayCacheSize);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_GetRoomDimensions(IntPtr context, float[] roomDimensions, float[] reflectionsCoefs, out Vector3 position);

		public int GetRoomDimensions(float[] roomDimensions, float[] reflectionsCoefs, out Vector3 position)
		{
			return ovrAudio_GetRoomDimensions(context, roomDimensions, reflectionsCoefs, out position);
		}

		[DllImport("MetaXRAudioWwise")]
		private static extern int ovrAudio_GetRaycastHits(IntPtr context, Vector3[] points, Vector3[] normals, int length);

		public int GetRaycastHits(Vector3[] points, Vector3[] normals, int length)
		{
			return ovrAudio_GetRaycastHits(context, points, normals, length);
		}
	}

	public class FMODPluginInterface : NativeInterface
	{
		public const string binaryName = "MetaXRAudioFMOD";

		private IntPtr context_ = IntPtr.Zero;

		private IntPtr context
		{
			get
			{
				if (context_ == IntPtr.Zero)
				{
					ovrAudio_GetPluginContext(out context_);
				}
				return context_;
			}
		}

		[DllImport("MetaXRAudioFMOD")]
		public static extern int ovrAudio_GetPluginContext(out IntPtr context);

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_SetAdvancedBoxRoomParametersUnity(IntPtr context, float width, float height, float depth, bool lockToListenerPosition, float positionX, float positionY, float positionZ, float[] wallMaterials);

		public int SetAdvancedBoxRoomParameters(float width, float height, float depth, bool lockToListenerPosition, Vector3 position, float[] wallMaterials)
		{
			return ovrAudio_SetAdvancedBoxRoomParametersUnity(context, width, height, depth, lockToListenerPosition, position.x, position.y, 0f - position.z, wallMaterials);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_SetRoomClutterFactor(IntPtr context, float[] clutterFactor);

		public int SetRoomClutterFactor(float[] clutterFactor)
		{
			return ovrAudio_SetRoomClutterFactor(context, clutterFactor);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_SetSharedReverbWetLevel(IntPtr context, float linearLevel);

		public int SetSharedReverbWetLevel(float linearLevel)
		{
			return ovrAudio_SetSharedReverbWetLevel(context, linearLevel);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_Enable(IntPtr context, int what, int enable);

		public int SetEnabled(int feature, bool enabled)
		{
			return ovrAudio_Enable(context, feature, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_Enable(IntPtr context, EnableFlag what, int enable);

		public int SetEnabled(EnableFlag feature, bool enabled)
		{
			return ovrAudio_Enable(context, feature, enabled ? 1 : 0);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_SetDynamicRoomRaysPerSecond(IntPtr context, int RaysPerSecond);

		public int SetDynamicRoomRaysPerSecond(int RaysPerSecond)
		{
			return ovrAudio_SetDynamicRoomRaysPerSecond(context, RaysPerSecond);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_SetDynamicRoomInterpSpeed(IntPtr context, float InterpSpeed);

		public int SetDynamicRoomInterpSpeed(float InterpSpeed)
		{
			return ovrAudio_SetDynamicRoomInterpSpeed(context, InterpSpeed);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_SetDynamicRoomMaxWallDistance(IntPtr context, float MaxWallDistance);

		public int SetDynamicRoomMaxWallDistance(float MaxWallDistance)
		{
			return ovrAudio_SetDynamicRoomMaxWallDistance(context, MaxWallDistance);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_SetDynamicRoomRaysRayCacheSize(IntPtr context, int RayCacheSize);

		public int SetDynamicRoomRaysRayCacheSize(int RayCacheSize)
		{
			return ovrAudio_SetDynamicRoomRaysRayCacheSize(context, RayCacheSize);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_GetRoomDimensions(IntPtr context, float[] roomDimensions, float[] reflectionsCoefs, out Vector3 position);

		public int GetRoomDimensions(float[] roomDimensions, float[] reflectionsCoefs, out Vector3 position)
		{
			return ovrAudio_GetRoomDimensions(context, roomDimensions, reflectionsCoefs, out position);
		}

		[DllImport("MetaXRAudioFMOD")]
		private static extern int ovrAudio_GetRaycastHits(IntPtr context, Vector3[] points, Vector3[] normals, int length);

		public int GetRaycastHits(Vector3[] points, Vector3[] normals, int length)
		{
			return ovrAudio_GetRaycastHits(context, points, normals, length);
		}
	}

	private static NativeInterface CachedInterface;

	public static NativeInterface Interface
	{
		get
		{
			if (CachedInterface == null)
			{
				CachedInterface = FindInterface();
			}
			return CachedInterface;
		}
	}

	private static NativeInterface FindInterface()
	{
		IntPtr context;
		try
		{
			context = WwisePluginInterface.getOrCreateGlobalOvrAudioContext();
			UnityEngine.Debug.Log("Meta XR Audio Native Interface initialized with Wwise plugin");
			return new WwisePluginInterface();
		}
		catch (DllNotFoundException)
		{
		}
		try
		{
			FMODPluginInterface.ovrAudio_GetPluginContext(out context);
			UnityEngine.Debug.Log("Meta XR Audio Native Interface initialized with FMOD plugin");
			return new FMODPluginInterface();
		}
		catch (DllNotFoundException)
		{
		}
		UnityEngine.Debug.Log("Meta XR Audio Native Interface initialized with Unity plugin");
		return new UnityNativeInterface();
	}
}
public sealed class MetaXRAudioRoomAcousticProperties : MonoBehaviour
{
	public enum MaterialPreset
	{
		AcousticTile,
		Brick,
		BrickPainted,
		Cardboard,
		Carpet,
		CarpetHeavy,
		CarpetHeavyPadded,
		CeramicTile,
		Concrete,
		ConcreteRough,
		ConcreteBlock,
		ConcreteBlockPainted,
		Curtain,
		Foliage,
		Glass,
		GlassHeavy,
		Grass,
		Gravel,
		GypsumBoard,
		Marble,
		Mud,
		PlasterOnBrick,
		PlasterOnConcreteBlock,
		Rubber,
		Soil,
		SoundProof,
		Snow,
		Steel,
		Stone,
		Vent,
		Water,
		WoodThin,
		WoodThick,
		WoodFloor,
		WoodOnConcrete,
		MetaDefault
	}

	[Tooltip("Center the room model on the listener. When disabled, center the room model on the GameObject this script is attached to.")]
	public bool lockPositionToListener = true;

	[Tooltip("Width of the room model in meters")]
	public float width = 8f;

	[Tooltip("Height of the room model in meters")]
	public float height = 3f;

	[Tooltip("Depth of the room model in meters")]
	public float depth = 5f;

	[Tooltip("Material of the left wall of the room model")]
	public MaterialPreset leftMaterial = MaterialPreset.GypsumBoard;

	[Tooltip("Material of the right wall of the room model")]
	public MaterialPreset rightMaterial = MaterialPreset.GypsumBoard;

	[Tooltip("Material of the ceiling of the room model")]
	public MaterialPreset ceilingMaterial;

	[Tooltip("Material of the floor of the room model")]
	public MaterialPreset floorMaterial = MaterialPreset.Carpet;

	[Tooltip("Material of the front wall of the room model")]
	public MaterialPreset frontMaterial = MaterialPreset.GypsumBoard;

	[Tooltip("Material of the back wall of the room model")]
	public MaterialPreset backMaterial = MaterialPreset.GypsumBoard;

	[Tooltip("Diffuses the reflections and reverberation to simulate objects inside the room. Zero represents a completely empty room.")]
	[Range(0f, 1f)]
	public float clutterFactor = 0.5f;

	private const int kAudioBandCount = 4;

	private float[] clutterFactorBands = new float[4];

	private float[] wallMaterials = new float[24];

	[RuntimeInitializeOnLoadMethod]
	private static void CheckSceneHasRoom()
	{
		MetaXRAudioRoomAcousticProperties[] array = UnityEngine.Object.FindObjectsOfType<MetaXRAudioRoomAcousticProperties>();
		if (array.Length == 0)
		{
			UnityEngine.Debug.Log("No Meta XR Audio Room found, setting default room");
			GameObject obj = new GameObject("Temporary Room");
			obj.AddComponent<MetaXRAudioRoomAcousticProperties>().Update();
			UnityEngine.Object.DestroyImmediate(obj);
		}
		if (array.Length > 1)
		{
			UnityEngine.Debug.LogError("Multiple Meta XR Audio Rooms found, only one is allowed!");
		}
	}

	private void Update()
	{
		SetWallMaterialPreset(0, rightMaterial);
		SetWallMaterialPreset(1, leftMaterial);
		SetWallMaterialPreset(2, ceilingMaterial);
		SetWallMaterialPreset(3, floorMaterial);
		SetWallMaterialPreset(4, frontMaterial);
		SetWallMaterialPreset(5, backMaterial);
		MetaXRAudioNativeInterface.Interface.SetAdvancedBoxRoomParameters(width, height, depth, lockPositionToListener, base.transform.position, wallMaterials);
		float num = clutterFactor;
		for (int num2 = 3; num2 >= 0; num2--)
		{
			clutterFactorBands[num2] = num;
			num *= 0.5f;
		}
		MetaXRAudioNativeInterface.Interface.SetRoomClutterFactor(clutterFactorBands);
	}

	private void SetWallMaterialPreset(int wallIndex, MaterialPreset materialPreset)
	{
		switch (materialPreset)
		{
		case MaterialPreset.AcousticTile:
			SetWallMaterialProperties(wallIndex, 0.48816842f, 0.36147523f, 0.33959538f, 0.49894625f);
			break;
		case MaterialPreset.Brick:
			SetWallMaterialProperties(wallIndex, 0.9754688f, 0.9720645f, 0.9491802f, 0.9301054f);
			break;
		case MaterialPreset.BrickPainted:
			SetWallMaterialProperties(wallIndex, 0.9757106f, 0.98332417f, 0.9781167f, 0.9700527f);
			break;
		case MaterialPreset.Cardboard:
			SetWallMaterialProperties(wallIndex, 0.59f, 0.435728f, 0.25165f, 0.208f);
			break;
		case MaterialPreset.Carpet:
			SetWallMaterialProperties(wallIndex, 0.9876337f, 0.90548664f, 0.5831106f, 0.35105383f);
			break;
		case MaterialPreset.CarpetHeavy:
			SetWallMaterialProperties(wallIndex, 0.9776337f, 0.8590829f, 0.5264796f, 0.37079042f);
			break;
		case MaterialPreset.CarpetHeavyPadded:
			SetWallMaterialProperties(wallIndex, 0.91053474f, 0.5304332f, 0.29405582f, 0.27010542f);
			break;
		case MaterialPreset.CeramicTile:
			SetWallMaterialProperties(wallIndex, 0.99f, 0.99f, 0.98275393f, 0.98f);
			break;
		case MaterialPreset.Concrete:
			SetWallMaterialProperties(wallIndex, 0.99f, 0.98332417f, 0.98f, 0.98f);
			break;
		case MaterialPreset.ConcreteRough:
			SetWallMaterialProperties(wallIndex, 0.98940843f, 0.96449465f, 0.922127f, 0.90010536f);
			break;
		case MaterialPreset.ConcreteBlock:
			SetWallMaterialProperties(wallIndex, 0.6352674f, 0.6522307f, 0.67105347f, 0.7890516f);
			break;
		case MaterialPreset.ConcreteBlockPainted:
			SetWallMaterialProperties(wallIndex, 0.9029579f, 0.9402359f, 0.91758406f, 0.9199473f);
			break;
		case MaterialPreset.Curtain:
			SetWallMaterialProperties(wallIndex, 0.68649423f, 0.54586f, 0.31007856f, 0.39947313f);
			break;
		case MaterialPreset.Foliage:
			SetWallMaterialProperties(wallIndex, 0.51825935f, 0.5035683f, 0.5786888f, 0.6902108f);
			break;
		case MaterialPreset.Glass:
			SetWallMaterialProperties(wallIndex, 0.6559158f, 0.8006318f, 0.9188397f, 0.92348814f);
			break;
		case MaterialPreset.GlassHeavy:
			SetWallMaterialProperties(wallIndex, 0.82709897f, 0.95022273f, 0.9746041f, 0.98f);
			break;
		case MaterialPreset.Grass:
			SetWallMaterialProperties(wallIndex, 0.8811263f, 0.5071708f, 0.1318931f, 0.010368884f);
			break;
		case MaterialPreset.Gravel:
			SetWallMaterialProperties(wallIndex, 0.7292947f, 0.37312245f, 0.25531745f, 0.20026344f);
			break;
		case MaterialPreset.GypsumBoard:
			SetWallMaterialProperties(wallIndex, 0.72124004f, 0.92769015f, 0.9343023f, 0.9101054f);
			break;
		case MaterialPreset.Marble:
			SetWallMaterialProperties(wallIndex, 0.99f, 0.99f, 0.982754f, 0.98f);
			break;
		case MaterialPreset.Mud:
			SetWallMaterialProperties(wallIndex, 0.844084f, 0.726577f, 0.794683f, 0.849737f);
			break;
		case MaterialPreset.PlasterOnBrick:
			SetWallMaterialProperties(wallIndex, 0.9756965f, 0.979106f, 0.9610635f, 0.9500527f);
			break;
		case MaterialPreset.PlasterOnConcreteBlock:
			SetWallMaterialProperties(wallIndex, 0.8817747f, 0.92477393f, 0.95149755f, 0.9599473f);
			break;
		case MaterialPreset.Rubber:
			SetWallMaterialProperties(wallIndex, 0.95f, 0.916621f, 0.93623f, 0.95f);
			break;
		case MaterialPreset.Soil:
			SetWallMaterialProperties(wallIndex, 0.8440842f, 0.63462424f, 0.41666287f, 0.40000004f);
			break;
		case MaterialPreset.SoundProof:
			SetWallMaterialProperties(wallIndex, 0f, 0f, 0f, 0f);
			break;
		case MaterialPreset.Snow:
			SetWallMaterialProperties(wallIndex, 0.53225267f, 0.15453577f, 0.050964415f, 0.050000012f);
			break;
		case MaterialPreset.Steel:
			SetWallMaterialProperties(wallIndex, 0.7931117f, 0.8401404f, 0.92559177f, 0.97973657f);
			break;
		case MaterialPreset.Stone:
			SetWallMaterialProperties(wallIndex, 0.98f, 0.97874f, 0.955701f, 0.95f);
			break;
		case MaterialPreset.Vent:
			SetWallMaterialProperties(wallIndex, 0.847042f, 0.62045f, 0.70217f, 0.799473f);
			break;
		case MaterialPreset.Water:
			SetWallMaterialProperties(wallIndex, 0.97058827f, 0.9717535f, 0.9783096f, 0.9700527f);
			break;
		case MaterialPreset.WoodThin:
			SetWallMaterialProperties(wallIndex, 0.59242314f, 0.8582733f, 0.9172423f, 0.94f);
			break;
		case MaterialPreset.WoodThick:
			SetWallMaterialProperties(wallIndex, 0.8129579f, 0.8953296f, 0.9413047f, 0.9499473f);
			break;
		case MaterialPreset.WoodFloor:
			SetWallMaterialProperties(wallIndex, 0.8523663f, 0.8989921f, 0.9347841f, 0.9300527f);
			break;
		case MaterialPreset.WoodOnConcrete:
			SetWallMaterialProperties(wallIndex, 0.96f, 0.94123226f, 0.9379238f, 0.9300527f);
			break;
		case MaterialPreset.MetaDefault:
			SetWallMaterialProperties(wallIndex, 0.9f, 0.9f, 0.9f, 0.9f);
			break;
		}
	}

	private void SetWallMaterialProperties(int wallIndex, float band0, float band1, float band2, float band3)
	{
		wallMaterials[wallIndex * 4] = band0;
		wallMaterials[wallIndex * 4 + 1] = band1;
		wallMaterials[wallIndex * 4 + 2] = band2;
		wallMaterials[wallIndex * 4 + 3] = band3;
	}
}
public sealed class MetaXRAudioSettings : ScriptableObject
{
	[SerializeField]
	public int voiceLimit = 64;

	private static MetaXRAudioSettings instance;

	public static MetaXRAudioSettings Instance
	{
		get
		{
			if (instance == null)
			{
				instance = Resources.Load<MetaXRAudioSettings>("MetaXRAudioSettings");
				if (instance == null)
				{
					instance = ScriptableObject.CreateInstance<MetaXRAudioSettings>();
				}
			}
			return instance;
		}
	}
}
[RequireComponent(typeof(AudioSource))]
public class MetaXRAudioSource : MonoBehaviour
{
	public enum NativeParameterIndex
	{
		P_GAIN,
		P_USEINVSQR,
		P_NEAR,
		P_FAR,
		P_RADIUS,
		P_DISABLE_RFL,
		P_AMBISTAT,
		P_READONLY_GLOBAL_RFL_ENABLED,
		P_READONLY_NUM_VOICES,
		P_HRTF_INTENSITY,
		P_REFLECTIONS_SEND,
		P_REVERB_SEND,
		P_DIRECTIVITY_ENABLED,
		P_DIRECTIVITY_INTENSITY,
		P_AMBI_DIRECT_ENABLED,
		P_REVERB_REACH,
		P_DIRECT_ENABLED,
		P_OCCLUSION_INTENSITY,
		P_MEDIUM_ABSORPTION,
		P_NUM
	}

	private AudioSource source_;

	private bool wasPlaying_;

	[SerializeField]
	[Tooltip("Enables HRTF Spatialization.")]
	private bool enableSpatialization = true;

	[SerializeField]
	[Tooltip("Additional gain beyond 0dB")]
	[Range(0f, 20f)]
	private float gainBoostDb;

	[SerializeField]
	[Tooltip("Enables room acoustics simulation (early reflections and reverberation) for this audio source only")]
	private bool enableAcoustics = true;

	[SerializeField]
	[Tooltip("Additional gain applied to reverb send for this audio source only")]
	[Range(-60f, 20f)]
	private float reverbSendDb;

	public bool EnableSpatialization
	{
		get
		{
			return enableSpatialization;
		}
		set
		{
			enableSpatialization = value;
		}
	}

	public float GainBoostDb
	{
		get
		{
			return gainBoostDb;
		}
		set
		{
			gainBoostDb = Mathf.Clamp(value, 0f, 20f);
		}
	}

	public bool EnableAcoustics
	{
		get
		{
			return enableAcoustics;
		}
		set
		{
			enableAcoustics = value;
		}
	}

	public float ReverbSendDb
	{
		get
		{
			return reverbSendDb;
		}
		set
		{
			reverbSendDb = Mathf.Clamp(value, -60f, 20f);
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void OnBeforeSceneLoadRuntimeMethod()
	{
		UnityEngine.Debug.Log($"Setting spatial voice limit: {MetaXRAudioSettings.Instance.voiceLimit}");
		MetaXRAudio_SetGlobalVoiceLimit(MetaXRAudioSettings.Instance.voiceLimit);
	}

	private void Awake()
	{
		source_ = GetComponent<AudioSource>();
		UpdateParameters();
	}

	private void Update()
	{
		if (source_ == null)
		{
			source_ = GetComponent<AudioSource>();
			if (source_ == null)
			{
				return;
			}
		}
		UpdateParameters();
		wasPlaying_ = source_.isPlaying;
	}

	public void UpdateParameters()
	{
		source_.spatialize = enableSpatialization;
		source_.SetSpatializerFloat(0, gainBoostDb);
		source_.SetSpatializerFloat(5, enableAcoustics ? 0f : 1f);
		source_.SetSpatializerFloat(11, reverbSendDb);
	}

	[DllImport("MetaXRAudioUnity")]
	private static extern int MetaXRAudio_SetGlobalVoiceLimit(int VoiceLimit);
}
[RequireComponent(typeof(MetaXRAudioSource))]
public class MetaXRAudioSourceExperimentalFeatures : MonoBehaviour
{
	public enum DirectivityPatternType
	{
		None,
		HumanVoice
	}

	private AudioSource source_;

	[SerializeField]
	[Tooltip("How much of the HRTF EQ is applied to the sound. Interaural time delay (ITD) and interaural level differences (ILD) are kept the same.")]
	[Range(0f, 1f)]
	private float hrtfIntensity = 1f;

	[SerializeField]
	[Tooltip("Used to increase the spatial audio emitter radius. Useful for sounds that come from a large area rather than a precise point. If increased too large, users may end up inside the radius if the sound source is too close.")]
	private float volumetricRadius;

	[SerializeField]
	[Tooltip("Additional gain applied to early reflections for this audio source only")]
	[Range(-60f, 20f)]
	private float earlyReflectionsSendDb;

	[SerializeField]
	[Tooltip("Adjust how much the direct-to-reverberant ratio increases with distance")]
	[Range(0f, 1f)]
	private float reverbReach = 0.5f;

	[SerializeField]
	[Tooltip("Adjust how much the direct-to-reverberant ratio increases with distance")]
	[Range(0f, 1f)]
	private float occlusionIntensity = 1f;

	[SerializeField]
	[Tooltip("Intensity controller for Directvity , Value of 1 will apply full directivity")]
	[Range(0f, 1f)]
	private float directivityIntensity = 1f;

	[SerializeField]
	[Tooltip("Option for human voice directivity pattern that makes this sound more muffled when the source is facing away from listener")]
	private DirectivityPatternType directivityPattern;

	[SerializeField]
	[Tooltip("This switch can disable direct sound propagation, so only late reverberations is heard from this source")]
	private bool directSoundEnabled = true;

	[SerializeField]
	[Tooltip("This switch can disable direct sound propagation, so only late reverberations is heard from this source")]
	private bool mediumAbsorption = true;

	public float HrtfIntensity
	{
		get
		{
			return hrtfIntensity;
		}
		set
		{
			hrtfIntensity = Mathf.Clamp(value, 0f, 1f);
		}
	}

	public float VolumetricRadius
	{
		get
		{
			return volumetricRadius;
		}
		set
		{
			volumetricRadius = Mathf.Max(value, 0f);
		}
	}

	public float EarlyReflectionsSendDb
	{
		get
		{
			return earlyReflectionsSendDb;
		}
		set
		{
			earlyReflectionsSendDb = Mathf.Clamp(value, -60f, 20f);
		}
	}

	public float ReverbReach
	{
		get
		{
			return reverbReach;
		}
		set
		{
			reverbReach = Mathf.Clamp(value, 0f, 1f);
		}
	}

	public float OcclusionIntensity
	{
		get
		{
			return occlusionIntensity;
		}
		set
		{
			occlusionIntensity = Mathf.Clamp(value, 0f, 1f);
		}
	}

	public float DirectivityIntensity
	{
		get
		{
			return directivityIntensity;
		}
		set
		{
			directivityIntensity = Mathf.Clamp(value, 0f, 1f);
		}
	}

	public DirectivityPatternType DirectivityPattern
	{
		get
		{
			return directivityPattern;
		}
		set
		{
			directivityPattern = value;
		}
	}

	public bool DirectSoundEnabled
	{
		get
		{
			return directSoundEnabled;
		}
		set
		{
			directSoundEnabled = value;
		}
	}

	public bool MediumAbsorption
	{
		get
		{
			return mediumAbsorption;
		}
		set
		{
			mediumAbsorption = value;
		}
	}

	private void OnValidate()
	{
		volumetricRadius = Mathf.Max(volumetricRadius, 0f);
	}

	private void Awake()
	{
		source_ = GetComponent<AudioSource>();
		UpdateParameters();
	}

	private void Update()
	{
		if (source_ == null)
		{
			source_ = GetComponent<AudioSource>();
			if (source_ == null)
			{
				return;
			}
		}
		UpdateParameters();
	}

	public void UpdateParameters()
	{
		source_.SetSpatializerFloat(9, hrtfIntensity);
		source_.SetSpatializerFloat(13, directivityIntensity);
		source_.SetSpatializerFloat(4, volumetricRadius);
		source_.SetSpatializerFloat(10, earlyReflectionsSendDb);
		source_.SetSpatializerFloat(12, (directivityPattern == DirectivityPatternType.None) ? 0f : 1f);
		source_.SetSpatializerFloat(15, reverbReach);
		source_.SetSpatializerFloat(16, directSoundEnabled ? 1f : 0f);
		source_.SetSpatializerFloat(17, occlusionIntensity);
		source_.SetSpatializerFloat(18, mediumAbsorption ? 1f : 0f);
	}

	[DllImport("MetaXRAudioUnity")]
	private static extern void MetaXRAudio_GetGlobalRoomReflectionValues(ref bool reflOn, ref bool reverbOn, ref float width, ref float height, ref float length);
}
internal class MetaXRAudioUtils
{
	internal static string GetCaseSensitivePathForFile(string path)
	{
		if (!File.Exists(path))
		{
			return path;
		}
		string text = Path.GetPathRoot(path);
		string[] array = path.Substring(text.Length).Split(Path.DirectorySeparatorChar);
		foreach (string searchPattern in array)
		{
			text = Directory.EnumerateFileSystemEntries(text, searchPattern).First();
		}
		return text;
	}

	internal static void CreateDirectoryForFilePath(string absPath)
	{
		int num = Math.Max(absPath.LastIndexOf('/'), absPath.LastIndexOf('\\'));
		if (num >= 0)
		{
			string path = absPath.Substring(0, num);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}
	}
}
public class MetaXRAudioVersion : MonoBehaviour
{
	private void Awake()
	{
		int Major = 0;
		int Minor = 0;
		int Patch = 0;
		MetaXRAudio_GetVersion(ref Major, ref Minor, ref Patch);
		UnityEngine.Debug.Log(string.Format($"MetaXRAudio Version: {Major}.{Minor}.{Patch}"));
	}

	[DllImport("MetaXRAudioUnity")]
	private static extern void MetaXRAudio_GetVersion(ref int Major, ref int Minor, ref int Patch);
}
[CompilerGenerated]
[EditorBrowsable(EditorBrowsableState.Never)]
[GeneratedCode("Unity.MonoScriptGenerator.MonoScriptInfoGenerator", null)]
internal class UnitySourceGeneratedAssemblyMonoScriptTypes_v1
{
	private struct MonoScriptData
	{
		public byte[] FilePathsData;

		public byte[] TypesData;

		public int TotalTypes;

		public int TotalFiles;

		public bool IsEditorOnly;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static MonoScriptData Get()
	{
		return new MonoScriptData
		{
			FilePathsData = new byte[1732]
			{
				0, 0, 0, 2, 0, 0, 0, 101, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 97, 117, 100, 105,
				111, 64, 50, 100, 55, 56, 53, 50, 54, 54,
				49, 52, 53, 48, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 115, 99, 114, 105, 112, 116, 115,
				92, 77, 101, 116, 97, 88, 82, 65, 99, 111,
				117, 115, 116, 105, 99, 67, 111, 110, 116, 114,
				111, 108, 90, 111, 110, 101, 46, 99, 115, 0,
				0, 0, 7, 0, 0, 0, 98, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 97, 117, 100, 105, 111,
				64, 50, 100, 55, 56, 53, 50, 54, 54, 49,
				52, 53, 48, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 115, 99, 114, 105, 112, 116, 115, 92,
				77, 101, 116, 97, 88, 82, 65, 99, 111, 117,
				115, 116, 105, 99, 71, 101, 111, 109, 101, 116,
				114, 121, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 93, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 97, 117, 100, 105, 111, 64, 50, 100, 55,
				56, 53, 50, 54, 54, 49, 52, 53, 48, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 115, 99,
				114, 105, 112, 116, 115, 92, 77, 101, 116, 97,
				88, 82, 65, 99, 111, 117, 115, 116, 105, 99,
				77, 97, 112, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 98, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 97, 117, 100, 105, 111, 64, 50, 100,
				55, 56, 53, 50, 54, 54, 49, 52, 53, 48,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 115,
				99, 114, 105, 112, 116, 115, 92, 77, 101, 116,
				97, 88, 82, 65, 99, 111, 117, 115, 116, 105,
				99, 77, 97, 116, 101, 114, 105, 97, 108, 46,
				99, 115, 0, 0, 0, 2, 0, 0, 0, 105,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 97, 117,
				100, 105, 111, 64, 50, 100, 55, 56, 53, 50,
				54, 54, 49, 52, 53, 48, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 115, 99, 114, 105, 112,
				116, 115, 92, 77, 101, 116, 97, 88, 82, 65,
				99, 111, 117, 115, 116, 105, 99, 77, 97, 116,
				101, 114, 105, 97, 108, 77, 97, 112, 112, 105,
				110, 103, 46, 99, 115, 0, 0, 0, 5, 0,
				0, 0, 108, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 97, 117, 100, 105, 111, 64, 50, 100, 55,
				56, 53, 50, 54, 54, 49, 52, 53, 48, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 115, 99,
				114, 105, 112, 116, 115, 92, 77, 101, 116, 97,
				88, 82, 65, 99, 111, 117, 115, 116, 105, 99,
				77, 97, 116, 101, 114, 105, 97, 108, 80, 114,
				111, 112, 101, 114, 116, 105, 101, 115, 46, 99,
				115, 0, 0, 0, 10, 0, 0, 0, 105, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 97, 117, 100,
				105, 111, 64, 50, 100, 55, 56, 53, 50, 54,
				54, 49, 52, 53, 48, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 115, 99, 114, 105, 112, 116,
				115, 92, 77, 101, 116, 97, 88, 82, 65, 99,
				111, 117, 115, 116, 105, 99, 78, 97, 116, 105,
				118, 101, 73, 110, 116, 101, 114, 102, 97, 99,
				101, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 100, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				97, 117, 100, 105, 111, 64, 50, 100, 55, 56,
				53, 50, 54, 54, 49, 52, 53, 48, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 115, 99, 114,
				105, 112, 116, 115, 92, 77, 101, 116, 97, 88,
				82, 65, 99, 111, 117, 115, 116, 105, 99, 83,
				99, 101, 110, 101, 71, 114, 111, 117, 112, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 98,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 97, 117,
				100, 105, 111, 64, 50, 100, 55, 56, 53, 50,
				54, 54, 49, 52, 53, 48, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 115, 99, 114, 105, 112,
				116, 115, 92, 77, 101, 116, 97, 88, 82, 65,
				99, 111, 117, 115, 116, 105, 99, 83, 101, 116,
				116, 105, 110, 103, 115, 46, 99, 115, 0, 0,
				0, 5, 0, 0, 0, 102, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 97, 117, 100, 105, 111, 64,
				50, 100, 55, 56, 53, 50, 54, 54, 49, 52,
				53, 48, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 115, 99, 114, 105, 112, 116, 115, 92, 77,
				101, 116, 97, 88, 82, 65, 117, 100, 105, 111,
				78, 97, 116, 105, 118, 101, 73, 110, 116, 101,
				114, 102, 97, 99, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 109, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 97, 117, 100, 105, 111, 64,
				50, 100, 55, 56, 53, 50, 54, 54, 49, 52,
				53, 48, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 115, 99, 114, 105, 112, 116, 115, 92, 77,
				101, 116, 97, 88, 82, 65, 117, 100, 105, 111,
				82, 111, 111, 109, 65, 99, 111, 117, 115, 116,
				105, 99, 80, 114, 111, 112, 101, 114, 116, 105,
				101, 115, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 95, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 97, 117, 100, 105, 111, 64, 50, 100, 55,
				56, 53, 50, 54, 54, 49, 52, 53, 48, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 115, 99,
				114, 105, 112, 116, 115, 92, 77, 101, 116, 97,
				88, 82, 65, 117, 100, 105, 111, 83, 101, 116,
				116, 105, 110, 103, 115, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 93, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 97, 117, 100, 105, 111, 64,
				50, 100, 55, 56, 53, 50, 54, 54, 49, 52,
				53, 48, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 115, 99, 114, 105, 112, 116, 115, 92, 77,
				101, 116, 97, 88, 82, 65, 117, 100, 105, 111,
				83, 111, 117, 114, 99, 101, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 113, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 97, 117, 100, 105, 111,
				64, 50, 100, 55, 56, 53, 50, 54, 54, 49,
				52, 53, 48, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 115, 99, 114, 105, 112, 116, 115, 92,
				77, 101, 116, 97, 88, 82, 65, 117, 100, 105,
				111, 83, 111, 117, 114, 99, 101, 69, 120, 112,
				101, 114, 105, 109, 101, 110, 116, 97, 108, 70,
				101, 97, 116, 117, 114, 101, 115, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 92, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 97, 117, 100, 105,
				111, 64, 50, 100, 55, 56, 53, 50, 54, 54,
				49, 52, 53, 48, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 115, 99, 114, 105, 112, 116, 115,
				92, 77, 101, 116, 97, 88, 82, 65, 117, 100,
				105, 111, 85, 116, 105, 108, 115, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 94, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 97, 117, 100, 105,
				111, 64, 50, 100, 55, 56, 53, 50, 54, 54,
				49, 52, 53, 48, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 115, 99, 114, 105, 112, 116, 115,
				92, 77, 101, 116, 97, 88, 82, 65, 117, 100,
				105, 111, 86, 101, 114, 115, 105, 111, 110, 46,
				99, 115
			},
			TypesData = new byte[1569]
			{
				0, 0, 0, 0, 26, 124, 77, 101, 116, 97,
				88, 82, 65, 99, 111, 117, 115, 116, 105, 99,
				67, 111, 110, 116, 114, 111, 108, 90, 111, 110,
				101, 0, 0, 0, 0, 31, 77, 101, 116, 97,
				88, 82, 65, 99, 111, 117, 115, 116, 105, 99,
				67, 111, 110, 116, 114, 111, 108, 90, 111, 110,
				101, 124, 83, 116, 97, 116, 101, 0, 0, 0,
				0, 23, 124, 77, 101, 116, 97, 88, 82, 65,
				99, 111, 117, 115, 116, 105, 99, 71, 101, 111,
				109, 101, 116, 114, 121, 0, 0, 0, 0, 35,
				77, 101, 116, 97, 88, 82, 65, 99, 111, 117,
				115, 116, 105, 99, 71, 101, 111, 109, 101, 116,
				114, 121, 124, 77, 101, 115, 104, 77, 97, 116,
				101, 114, 105, 97, 108, 0, 0, 0, 0, 38,
				77, 101, 116, 97, 88, 82, 65, 99, 111, 117,
				115, 116, 105, 99, 71, 101, 111, 109, 101, 116,
				114, 121, 124, 84, 101, 114, 114, 97, 105, 110,
				77, 97, 116, 101, 114, 105, 97, 108, 0, 0,
				0, 0, 40, 77, 101, 116, 97, 88, 82, 65,
				99, 111, 117, 115, 116, 105, 99, 71, 101, 111,
				109, 101, 116, 114, 121, 124, 73, 84, 114, 97,
				110, 115, 102, 111, 114, 109, 86, 105, 115, 105,
				116, 111, 114, 0, 0, 0, 0, 32, 77, 101,
				116, 97, 88, 82, 65, 99, 111, 117, 115, 116,
				105, 99, 71, 101, 111, 109, 101, 116, 114, 121,
				124, 73, 71, 97, 116, 104, 101, 114, 101, 114,
				0, 0, 0, 0, 35, 77, 101, 116, 97, 88,
				82, 65, 99, 111, 117, 115, 116, 105, 99, 71,
				101, 111, 109, 101, 116, 114, 121, 124, 77, 101,
				115, 104, 71, 97, 116, 104, 101, 114, 101, 114,
				0, 0, 0, 0, 39, 77, 101, 116, 97, 88,
				82, 65, 99, 111, 117, 115, 116, 105, 99, 71,
				101, 111, 109, 101, 116, 114, 121, 124, 67, 111,
				108, 108, 105, 100, 101, 114, 71, 97, 116, 104,
				101, 114, 101, 114, 0, 0, 0, 0, 18, 124,
				77, 101, 116, 97, 88, 82, 65, 99, 111, 117,
				115, 116, 105, 99, 77, 97, 112, 0, 0, 0,
				0, 23, 124, 77, 101, 116, 97, 88, 82, 65,
				99, 111, 117, 115, 116, 105, 99, 77, 97, 116,
				101, 114, 105, 97, 108, 0, 0, 0, 0, 30,
				124, 77, 101, 116, 97, 88, 82, 65, 99, 111,
				117, 115, 116, 105, 99, 77, 97, 116, 101, 114,
				105, 97, 108, 77, 97, 112, 112, 105, 110, 103,
				0, 0, 0, 0, 34, 77, 101, 116, 97, 88,
				82, 65, 99, 111, 117, 115, 116, 105, 99, 77,
				97, 116, 101, 114, 105, 97, 108, 77, 97, 112,
				112, 105, 110, 103, 124, 80, 97, 105, 114, 0,
				0, 0, 0, 30, 77, 101, 116, 97, 46, 88,
				82, 46, 65, 99, 111, 117, 115, 116, 105, 99,
				115, 124, 77, 97, 116, 101, 114, 105, 97, 108,
				68, 97, 116, 97, 0, 0, 0, 0, 39, 77,
				101, 116, 97, 46, 88, 82, 46, 65, 99, 111,
				117, 115, 116, 105, 99, 115, 124, 73, 77, 97,
				116, 101, 114, 105, 97, 108, 68, 97, 116, 97,
				80, 114, 111, 118, 105, 100, 101, 114, 0, 0,
				0, 0, 26, 77, 101, 116, 97, 46, 88, 82,
				46, 65, 99, 111, 117, 115, 116, 105, 99, 115,
				124, 83, 112, 101, 99, 116, 114, 117, 109, 0,
				0, 0, 0, 32, 77, 101, 116, 97, 46, 88,
				82, 46, 65, 99, 111, 117, 115, 116, 105, 99,
				115, 46, 83, 112, 101, 99, 116, 114, 117, 109,
				124, 80, 111, 105, 110, 116, 0, 0, 0, 0,
				33, 124, 77, 101, 116, 97, 88, 82, 65, 99,
				111, 117, 115, 116, 105, 99, 77, 97, 116, 101,
				114, 105, 97, 108, 80, 114, 111, 112, 101, 114,
				116, 105, 101, 115, 0, 0, 0, 0, 27, 77,
				101, 116, 97, 46, 88, 82, 46, 65, 99, 111,
				117, 115, 116, 105, 99, 115, 124, 77, 101, 115,
				104, 71, 114, 111, 117, 112, 0, 0, 0, 0,
				36, 77, 101, 116, 97, 46, 88, 82, 46, 65,
				99, 111, 117, 115, 116, 105, 99, 115, 124, 77,
				101, 115, 104, 83, 105, 109, 112, 108, 105, 102,
				105, 99, 97, 116, 105, 111, 110, 0, 0, 0,
				0, 34, 77, 101, 116, 97, 46, 88, 82, 46,
				65, 99, 111, 117, 115, 116, 105, 99, 115, 124,
				83, 99, 101, 110, 101, 73, 82, 67, 97, 108,
				108, 98, 97, 99, 107, 115, 0, 0, 0, 0,
				31, 77, 101, 116, 97, 46, 88, 82, 46, 65,
				99, 111, 117, 115, 116, 105, 99, 115, 124, 77,
				97, 112, 80, 97, 114, 97, 109, 101, 116, 101,
				114, 115, 0, 0, 0, 0, 30, 124, 77, 101,
				116, 97, 88, 82, 65, 99, 111, 117, 115, 116,
				105, 99, 78, 97, 116, 105, 118, 101, 73, 110,
				116, 101, 114, 102, 97, 99, 101, 0, 0, 0,
				0, 46, 77, 101, 116, 97, 88, 82, 65, 99,
				111, 117, 115, 116, 105, 99, 78, 97, 116, 105,
				118, 101, 73, 110, 116, 101, 114, 102, 97, 99,
				101, 124, 73, 78, 97, 116, 105, 118, 101, 73,
				110, 116, 101, 114, 102, 97, 99, 101, 0, 0,
				0, 0, 50, 77, 101, 116, 97, 88, 82, 65,
				99, 111, 117, 115, 116, 105, 99, 78, 97, 116,
				105, 118, 101, 73, 110, 116, 101, 114, 102, 97,
				99, 101, 124, 85, 110, 105, 116, 121, 78, 97,
				116, 105, 118, 101, 73, 110, 116, 101, 114, 102,
				97, 99, 101, 0, 0, 0, 0, 50, 77, 101,
				116, 97, 88, 82, 65, 99, 111, 117, 115, 116,
				105, 99, 78, 97, 116, 105, 118, 101, 73, 110,
				116, 101, 114, 102, 97, 99, 101, 124, 87, 119,
				105, 115, 101, 80, 108, 117, 103, 105, 110, 73,
				110, 116, 101, 114, 102, 97, 99, 101, 0, 0,
				0, 0, 49, 77, 101, 116, 97, 88, 82, 65,
				99, 111, 117, 115, 116, 105, 99, 78, 97, 116,
				105, 118, 101, 73, 110, 116, 101, 114, 102, 97,
				99, 101, 124, 70, 77, 79, 68, 80, 108, 117,
				103, 105, 110, 73, 110, 116, 101, 114, 102, 97,
				99, 101, 0, 0, 0, 0, 44, 77, 101, 116,
				97, 88, 82, 65, 99, 111, 117, 115, 116, 105,
				99, 78, 97, 116, 105, 118, 101, 73, 110, 116,
				101, 114, 102, 97, 99, 101, 124, 68, 117, 109,
				109, 121, 73, 110, 116, 101, 114, 102, 97, 99,
				101, 0, 0, 0, 0, 25, 124, 77, 101, 116,
				97, 88, 82, 65, 99, 111, 117, 115, 116, 105,
				99, 83, 99, 101, 110, 101, 71, 114, 111, 117,
				112, 0, 0, 0, 0, 23, 124, 77, 101, 116,
				97, 88, 82, 65, 99, 111, 117, 115, 116, 105,
				99, 83, 101, 116, 116, 105, 110, 103, 115, 0,
				0, 0, 0, 27, 124, 77, 101, 116, 97, 88,
				82, 65, 117, 100, 105, 111, 78, 97, 116, 105,
				118, 101, 73, 110, 116, 101, 114, 102, 97, 99,
				101, 0, 0, 0, 0, 42, 77, 101, 116, 97,
				88, 82, 65, 117, 100, 105, 111, 78, 97, 116,
				105, 118, 101, 73, 110, 116, 101, 114, 102, 97,
				99, 101, 124, 78, 97, 116, 105, 118, 101, 73,
				110, 116, 101, 114, 102, 97, 99, 101, 0, 0,
				0, 0, 47, 77, 101, 116, 97, 88, 82, 65,
				117, 100, 105, 111, 78, 97, 116, 105, 118, 101,
				73, 110, 116, 101, 114, 102, 97, 99, 101, 124,
				85, 110, 105, 116, 121, 78, 97, 116, 105, 118,
				101, 73, 110, 116, 101, 114, 102, 97, 99, 101,
				0, 0, 0, 0, 47, 77, 101, 116, 97, 88,
				82, 65, 117, 100, 105, 111, 78, 97, 116, 105,
				118, 101, 73, 110, 116, 101, 114, 102, 97, 99,
				101, 124, 87, 119, 105, 115, 101, 80, 108, 117,
				103, 105, 110, 73, 110, 116, 101, 114, 102, 97,
				99, 101, 0, 0, 0, 0, 46, 77, 101, 116,
				97, 88, 82, 65, 117, 100, 105, 111, 78, 97,
				116, 105, 118, 101, 73, 110, 116, 101, 114, 102,
				97, 99, 101, 124, 70, 77, 79, 68, 80, 108,
				117, 103, 105, 110, 73, 110, 116, 101, 114, 102,
				97, 99, 101, 0, 0, 0, 0, 34, 124, 77,
				101, 116, 97, 88, 82, 65, 117, 100, 105, 111,
				82, 111, 111, 109, 65, 99, 111, 117, 115, 116,
				105, 99, 80, 114, 111, 112, 101, 114, 116, 105,
				101, 115, 0, 0, 0, 0, 20, 124, 77, 101,
				116, 97, 88, 82, 65, 117, 100, 105, 111, 83,
				101, 116, 116, 105, 110, 103, 115, 0, 0, 0,
				0, 18, 124, 77, 101, 116, 97, 88, 82, 65,
				117, 100, 105, 111, 83, 111, 117, 114, 99, 101,
				0, 0, 0, 0, 38, 124, 77, 101, 116, 97,
				88, 82, 65, 117, 100, 105, 111, 83, 111, 117,
				114, 99, 101, 69, 120, 112, 101, 114, 105, 109,
				101, 110, 116, 97, 108, 70, 101, 97, 116, 117,
				114, 101, 115, 0, 0, 0, 0, 17, 124, 77,
				101, 116, 97, 88, 82, 65, 117, 100, 105, 111,
				85, 116, 105, 108, 115, 0, 0, 0, 0, 19,
				124, 77, 101, 116, 97, 88, 82, 65, 117, 100,
				105, 111, 86, 101, 114, 115, 105, 111, 110
			},
			TotalFiles = 16,
			TotalTypes = 41,
			IsEditorOnly = false
		};
	}
}
namespace Meta.XR.Audio
{
	[Flags]
	public enum EnableFlag : uint
	{
		NONE = 0u,
		SIMPLE_ROOM_MODELING = 2u,
		LATE_REVERBERATION = 3u,
		RANDOMIZE_REVERB = 4u,
		PERFORMANCE_COUNTERS = 5u
	}
}
namespace Meta.XR.Acoustics
{
	[Serializable]
	public class MaterialData
	{
		[SerializeField]
		internal Spectrum absorption = new Spectrum();

		[SerializeField]
		internal Spectrum transmission = new Spectrum();

		[SerializeField]
		internal Spectrum scattering = new Spectrum();

		[SerializeField]
		internal Color color = Color.yellow;

		internal bool IsEmpty
		{
			get
			{
				if (absorption.points.Count == 0 && transmission.points.Count == 0)
				{
					return scattering.points.Count == 0;
				}
				return false;
			}
		}

		internal void Clone(MaterialData other)
		{
			color = other.color;
			absorption.Clone(other.absorption);
			transmission.Clone(other.transmission);
			scattering.Clone(other.scattering);
		}
	}
	internal interface IMaterialDataProvider
	{
		MaterialData Data { get; }

		string name { get; }
	}
	[Serializable]
	internal sealed class Spectrum : IEnumerable<Spectrum.Point>, IEnumerable
	{
		[Serializable]
		internal struct Point : IComparable<Point>
		{
			[SerializeField]
			internal float frequency;

			[SerializeField]
			internal float data;

			internal Point(float frequency = 0f, float data = 0f)
			{
				this.frequency = frequency;
				this.data = data;
			}

			public int CompareTo(Point other)
			{
				return frequency.CompareTo(other.frequency);
			}

			public static implicit operator Point(Vector2 v)
			{
				return new Point(v.x, v.y);
			}

			public static implicit operator Vector2(Point point)
			{
				return new Vector2(point.frequency, point.data);
			}

			public override string ToString()
			{
				return $"({frequency}Hz, {data:0.00})";
			}
		}

		[SerializeField]
		internal int selection = int.MaxValue;

		[SerializeField]
		internal List<Point> points = new List<Point>();

		internal float this[float f]
		{
			get
			{
				if (points.Count > 0)
				{
					Point point = new Point(float.MinValue);
					Point point2 = new Point(float.MaxValue);
					foreach (Point point3 in points)
					{
						if (point3.frequency < f)
						{
							if (point3.frequency > point.frequency)
							{
								point = point3;
							}
						}
						else if (point3.frequency < point2.frequency)
						{
							point2 = point3;
						}
					}
					if (point.frequency == float.MinValue)
					{
						point.data = points.OrderBy((Point p) => p.frequency).First().data;
					}
					if (point2.frequency == float.MaxValue)
					{
						point2.data = points.OrderBy((Point p) => p.frequency).Last().data;
					}
					return Mathf.Lerp(point.data, point2.data, (f - point.frequency) / (point2.frequency - point.frequency));
				}
				return 0f;
			}
		}

		IEnumerator<Point> IEnumerable<Point>.GetEnumerator()
		{
			return points.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return points.GetEnumerator();
		}

		internal void Add(float frequency, float data)
		{
			points.Add(new Point(frequency, data));
		}

		internal Spectrum(Spectrum other = null)
		{
			if (other != null)
			{
				Clone(other);
			}
		}

		internal void Clone(Spectrum other)
		{
			if (this != other)
			{
				selection = other.selection;
				points = new List<Point>(other.points);
			}
		}

		internal void Sort()
		{
			if (points.Count != 0)
			{
				Point item = points[selection];
				points.Sort();
				selection = points.IndexOf(item);
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Point point in points)
			{
				stringBuilder.Append($"[{point.frequency}, {point.data}] ");
			}
			return stringBuilder.ToString();
		}
	}
	public enum AcousticModel
	{
		Automatic = -1,
		None = 0,
		ShoeboxRoom = 1,
		AcousticRayTracing = 3
	}
	[Flags]
	public enum EnableFlagInternal : uint
	{
		NONE = 0u,
		SIMPLE_ROOM_MODELING = 2u,
		LATE_REVERBERATION = 3u,
		RANDOMIZE_REVERB = 4u,
		PERFORMANCE_COUNTERS = 5u,
		DIFFRACTION = 6u
	}
	public enum FaceType : uint
	{
		TRIANGLES,
		QUADS
	}
	public enum MaterialProperty : uint
	{
		ABSORPTION,
		TRANSMISSION,
		SCATTERING
	}
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MeshGroup
	{
		public UIntPtr indexOffset;

		public UIntPtr faceCount;

		[MarshalAs(UnmanagedType.U4)]
		public FaceType faceType;

		public IntPtr material;
	}
	[Flags]
	public enum AcousticMapStatus : uint
	{
		EMPTY = 0u,
		MAPPED = 1u,
		READY = 3u
	}
	[Flags]
	public enum AcousticMapFlags : uint
	{
		NONE = 0u,
		STATIC_ONLY = 1u,
		NO_FLOATING = 2u,
		MAP_ONLY = 4u,
		DIFFRACTION = 8u
	}
	[Flags]
	public enum ObjectFlags : uint
	{
		EMPTY = 0u,
		ENABLED = 1u,
		STATIC = 2u
	}
	[Flags]
	public enum MeshFlags : uint
	{
		NONE = 0u,
		ENABLE_SIMPLIFICATION = 1u,
		ENABLE_DIFFRACTION = 2u
	}
	public struct MeshSimplification
	{
		public UIntPtr thisSize;

		[MarshalAs(UnmanagedType.U4)]
		public MeshFlags flags;

		public float unitScale;

		public float maxError;

		public float minDiffractionEdgeAngle;

		public float minDiffractionEdgeLength;

		public float flagLength;

		public UIntPtr threadCount;
	}
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate bool ProgressCallback(IntPtr userData, string description, float progress);
	public struct SceneIRCallbacks
	{
		public IntPtr userData;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		public ProgressCallback progress;
	}
	public struct MapParameters
	{
		public UIntPtr thisSize;

		public SceneIRCallbacks callbacks;

		public UIntPtr threadCount;

		public UIntPtr reflectionCount;

		[MarshalAs(UnmanagedType.U4)]
		public AcousticMapFlags flags;

		public float minResolution;

		public float maxResolution;

		public float headHeight;

		public float maxHeight;

		public float gravityVectorX;

		public float gravityVectorY;

		public float gravityVectorZ;
	}
	public enum ControlZoneProperty : uint
	{
		RT60,
		REVERB_LEVEL
	}
}
