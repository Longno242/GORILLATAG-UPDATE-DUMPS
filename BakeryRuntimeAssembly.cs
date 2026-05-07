using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyVersion("0.0.0.0")]
[HelpURL("https://geom.io/bakery/wiki/index.php?title=Manual#Bakery_Always_Render")]
public class BakeryAlwaysRender : MonoBehaviour
{
}
[HelpURL("https://geom.io/bakery/wiki/index.php?title=Manual#Bakery_Direct_Light")]
[ExecuteInEditMode]
[DisallowMultipleComponent]
public class BakeryDirectLight : MonoBehaviour
{
	public Color color = Color.white;

	public float intensity = 1f;

	public float shadowSpread = 0.01f;

	public int samples = 16;

	public int bitmask = 1;

	public bool bakeToIndirect;

	public bool shadowmask;

	public bool shadowmaskDenoise;

	public float indirectIntensity = 1f;

	public Texture2D cloudShadow;

	public float cloudShadowTilingX = 0.01f;

	public float cloudShadowTilingY = 0.01f;

	public float cloudShadowOffsetX;

	public float cloudShadowOffsetY;

	public bool supersample;

	public int UID;

	public static int lightsChanged;

	private static GameObject objShownError;
}
[HelpURL("https://geom.io/bakery/wiki/index.php?title=Manual#Bakery_Light_Filter")]
[DisallowMultipleComponent]
public class BakeryLightFilter : MonoBehaviour
{
	public Texture2D texture;

	[HideInInspector]
	public int lmid;
}
public struct BakeryLightmapGroupPlain
{
	public string name;

	public int resolution;

	public int id;

	public int renderMode;

	public int renderDirMode;

	public int atlasPacker;

	public bool vertexBake;

	public bool containsTerrains;

	public bool probes;

	public bool isImplicit;

	public bool computeSSS;

	public int sssSamples;

	public float sssDensity;

	public float sssR;

	public float sssG;

	public float sssB;

	public float fakeShadowBias;

	public bool transparentSelfShadow;

	public bool flipNormal;

	public string parentName;

	public int sceneLodLevel;

	public bool autoResolution;

	public int holeFilling;

	public int vertexSamplingDensity;
}
[CreateAssetMenu(menuName = "Bakery lightmap group")]
public class BakeryLightmapGroup : ScriptableObject
{
	public enum ftLMGroupMode
	{
		OriginalUV,
		PackAtlas,
		Vertex
	}

	public enum RenderMode
	{
		FullLighting = 0,
		Indirect = 1,
		Shadowmask = 2,
		Subtractive = 3,
		AmbientOcclusionOnly = 4,
		Auto = 1000
	}

	public enum RenderDirMode
	{
		None = 0,
		BakedNormalMaps = 1,
		DominantDirection = 2,
		RNM = 3,
		SH = 4,
		ProbeSH = 5,
		MonoSH = 6,
		ProbeSHL2 = 7,
		Auto = 1000
	}

	public enum AtlasPacker
	{
		Default = 0,
		xatlas = 1,
		Auto = 1000
	}

	public enum HoleFilling
	{
		Auto,
		Yes,
		No
	}

	[SerializeField]
	[Range(1f, 8192f)]
	public int resolution = 512;

	[SerializeField]
	public int bitmask = 1;

	[SerializeField]
	public int id = -1;

	public int sortingID = -1;

	[SerializeField]
	public bool isImplicit;

	[SerializeField]
	public float area;

	[SerializeField]
	public int totalVertexCount;

	[SerializeField]
	public int vertexCounter;

	[SerializeField]
	public int sceneLodLevel = -1;

	[SerializeField]
	public bool autoResolution;

	[SerializeField]
	public string sceneName;

	[SerializeField]
	public int tag = -1;

	[SerializeField]
	public bool containsTerrains;

	[SerializeField]
	public bool probes;

	[SerializeField]
	public ftLMGroupMode mode = ftLMGroupMode.PackAtlas;

	[SerializeField]
	public RenderMode renderMode = RenderMode.Auto;

	[SerializeField]
	public RenderDirMode renderDirMode = RenderDirMode.Auto;

	[SerializeField]
	public AtlasPacker atlasPacker = AtlasPacker.Auto;

	[SerializeField]
	public HoleFilling holeFilling;

	[SerializeField]
	public int vertexSamplingDensity;

	[SerializeField]
	public bool computeSSS;

	[SerializeField]
	public int sssSamples = 16;

	[SerializeField]
	public float sssDensity = 10f;

	[SerializeField]
	public Color sssColor = Color.white;

	[SerializeField]
	public float sssScale = 1f;

	[SerializeField]
	public float fakeShadowBias;

	[SerializeField]
	public bool transparentSelfShadow;

	[SerializeField]
	public bool flipNormal;

	[SerializeField]
	public string parentName;

	[SerializeField]
	public string overridePath = "";

	[SerializeField]
	public bool fixPos3D;

	[SerializeField]
	public Vector3 voxelSize = Vector3.one;

	public int passedFilter;

	public BakeryLightmapGroupPlain GetPlainStruct()
	{
		BakeryLightmapGroupPlain result = default(BakeryLightmapGroupPlain);
		result.name = base.name;
		result.id = id;
		result.resolution = resolution;
		result.vertexBake = mode == ftLMGroupMode.Vertex;
		result.isImplicit = isImplicit;
		result.renderMode = (int)renderMode;
		result.renderDirMode = (int)renderDirMode;
		result.atlasPacker = (int)atlasPacker;
		result.holeFilling = (int)holeFilling;
		result.vertexSamplingDensity = vertexSamplingDensity;
		result.computeSSS = computeSSS;
		result.sssSamples = sssSamples;
		result.sssDensity = sssDensity;
		result.sssR = sssColor.r * sssScale;
		result.sssG = sssColor.g * sssScale;
		result.sssB = sssColor.b * sssScale;
		result.containsTerrains = containsTerrains;
		result.probes = probes;
		result.fakeShadowBias = fakeShadowBias;
		result.transparentSelfShadow = transparentSelfShadow;
		result.flipNormal = flipNormal;
		result.parentName = parentName;
		result.sceneLodLevel = sceneLodLevel;
		result.autoResolution = autoResolution;
		return result;
	}
}
[HelpURL("https://geom.io/bakery/wiki/index.php?title=Manual#Bakery_Lightmap_Group_Selector")]
public class BakeryLightmapGroupSelector : MonoBehaviour
{
	public bool active = true;

	public UnityEngine.Object lmgroupAsset;

	public bool instanceResolutionOverride;

	public int instanceResolution = 256;
}
[HelpURL("https://geom.io/bakery/wiki/index.php?title=Manual#Bakery_Lightmapped_Prefab")]
[DisallowMultipleComponent]
public class BakeryLightmappedPrefab : MonoBehaviour
{
}
[HelpURL("https://geom.io/bakery/wiki/index.php?title=Manual#Bakery_Light_Mesh")]
[ExecuteInEditMode]
[DisallowMultipleComponent]
public class BakeryLightMesh : MonoBehaviour
{
	public int UID;

	public Color color = Color.white;

	public float intensity = 1f;

	public Texture2D texture;

	public float cutoff = 100f;

	public int samples = 256;

	public int samples2 = 16;

	public int samples2_previous = 16;

	public int bitmask = 1;

	public bool selfShadow = true;

	public bool bakeToIndirect = true;

	public bool shadowmask;

	public float indirectIntensity = 1f;

	public bool shadowmaskFalloff;

	public int maskChannel;

	public int lmid = -2;

	public static int lightsChanged;

	private static GameObject objShownError;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		MeshRenderer component = base.gameObject.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Gizmos.DrawWireSphere(component.bounds.center, cutoff);
		}
	}
}
[HelpURL("https://geom.io/bakery/wiki/index.php?title=Manual#Bakery_Pack_As_Single_Square")]
public class BakeryPackAsSingleSquare : MonoBehaviour
{
}
[HelpURL("https://geom.io/bakery/wiki/index.php?title=Manual#Bakery_Point_Light")]
[ExecuteInEditMode]
[DisallowMultipleComponent]
public class BakeryPointLight : MonoBehaviour
{
	public enum ftLightProjectionMode
	{
		Omni,
		Cookie,
		Cubemap,
		IES,
		Cone
	}

	public enum Direction
	{
		NegativeY,
		PositiveZ
	}

	public int UID;

	public Color color = Color.white;

	public float intensity = 1f;

	public float shadowSpread = 0.05f;

	public float cutoff = 10f;

	public bool realisticFalloff;

	public bool legacySampling = true;

	public int samples = 8;

	public ftLightProjectionMode projMode;

	public Texture2D cookie;

	public float angle = 30f;

	public float innerAngle;

	public Cubemap cubemap;

	public UnityEngine.Object iesFile;

	public int bitmask = 1;

	public bool bakeToIndirect;

	public bool shadowmask;

	public bool shadowmaskFalloff;

	public float indirectIntensity = 1f;

	public float falloffMinRadius = 1f;

	public int shadowmaskGroupID;

	public bool correctCookieDistortion;

	public Direction directionMode;

	public int maskChannel;

	private const float GIZMO_MAXSIZE = 0.1f;

	private const float GIZMO_SCALE = 0.01f;

	public static int lightsChanged;

	private static GameObject objShownError;
}
[HelpURL("https://geom.io/bakery/wiki/index.php?title=Partial_scene_baking")]
public class BakerySector : MonoBehaviour
{
	public enum CaptureMode
	{
		None = -1,
		CaptureInPlace,
		CaptureToAsset,
		LoadCaptured
	}

	public CaptureMode captureMode;

	public string captureAssetName = "";

	public BakerySectorCapture captureAsset;

	public bool allowUVPaddingAdjustment;

	public List<Transform> tforms = new List<Transform>();

	public List<Transform> cpoints = new List<Transform>();

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		for (int i = 0; i < cpoints.Count; i++)
		{
			if (cpoints[i] != null)
			{
				Gizmos.DrawWireSphere(cpoints[i].position, 1f);
			}
		}
	}
}
public class BakerySectorCapture : ScriptableObject
{
}
[HelpURL("https://geom.io/bakery/wiki/index.php?title=Manual#Bakery_Shared_LOD_UV")]
public class BakerySharedLodUv : MonoBehaviour
{
}
[HelpURL("https://geom.io/bakery/wiki/index.php?title=Manual#Bakery_Sky_Light")]
[ExecuteInEditMode]
[DisallowMultipleComponent]
public class BakerySkyLight : MonoBehaviour
{
	public string texName = "sky.dds";

	public Color color = Color.white;

	public float intensity = 1f;

	public int samples = 32;

	public bool hemispherical;

	public int bitmask = 1;

	public bool bakeToIndirect = true;

	public float indirectIntensity = 1f;

	public bool tangentSH;

	public bool correctRotation;

	public Cubemap cubemap;

	public int UID;

	public static int lightsChanged;

	private static GameObject objShownError;
}
[HelpURL("https://geom.io/bakery/wiki/index.php?title=Manual#Bakery_Volume")]
[ExecuteInEditMode]
public class BakeryVolume : MonoBehaviour
{
	public enum Encoding
	{
		Half4,
		RGBA8,
		RGBA8Mono
	}

	public enum ShadowmaskEncoding
	{
		RGBA8,
		A8
	}

	public bool enableBaking = true;

	public Bounds bounds = new Bounds(Vector3.zero, Vector3.one);

	public bool adaptiveRes = true;

	public float voxelsPerUnit = 0.5f;

	public int resolutionX = 16;

	public int resolutionY = 16;

	public int resolutionZ = 16;

	public Encoding encoding;

	public ShadowmaskEncoding shadowmaskEncoding;

	public bool firstLightIsAlwaysAlpha;

	public bool denoise;

	public bool isGlobal;

	public Texture3D bakedTexture0;

	public Texture3D bakedTexture1;

	public Texture3D bakedTexture2;

	public Texture3D bakedTexture3;

	public Texture3D bakedMask;

	public bool supportRotationAfterBake;

	public bool rotateAroundY;

	public bool _rotateAroundXYZ;

	public int multiVolumePriority;

	public static BakeryVolume globalVolume;

	public static bool showAll;

	private Transform tform;

	public Vector3 GetMin()
	{
		if (rotateAroundY)
		{
			Vector2 rotationY = GetRotationY();
			Vector3 vector = bounds.min - bounds.center;
			return new Vector3(vector.x * rotationY.y + vector.z * rotationY.x, vector.y, vector.x * (0f - rotationY.x) + vector.z * rotationY.y) + bounds.center;
		}
		return bounds.min;
	}

	public Vector3 GetMax()
	{
		if (rotateAroundY)
		{
			Vector2 rotationY = GetRotationY();
			Vector3 vector = bounds.max - bounds.center;
			return new Vector3(vector.x * rotationY.y + vector.z * rotationY.x, vector.y, vector.x * (0f - rotationY.x) + vector.z * rotationY.y) + bounds.center;
		}
		return bounds.max;
	}

	private Vector3 TransformPoint(Vector3 p, Vector3 center, Vector2 sc)
	{
		p -= center;
		return new Vector3(p.x * sc.y + p.z * sc.x, p.y, p.x * (0f - sc.x) + p.z * sc.y) + center;
	}

	public Vector4 GetWorldXZMinMax()
	{
		Vector3 min = bounds.min;
		Vector3 max = bounds.max;
		if (rotateAroundY)
		{
			Vector2 rotationY = GetRotationY();
			Vector3 center = bounds.center;
			Vector3 min2 = bounds.min;
			Vector3 p = new Vector3(bounds.max.x, 0f, bounds.min.z);
			Vector3 max2 = bounds.max;
			Vector3 p2 = new Vector3(bounds.min.x, 0f, bounds.max.z);
			min2 = TransformPoint(min2, center, rotationY);
			p = TransformPoint(p, center, rotationY);
			max2 = TransformPoint(max2, center, rotationY);
			p2 = TransformPoint(p2, center, rotationY);
			float x = Mathf.Min(Mathf.Min(Mathf.Min(min2.x, p.x), max2.x), p2.x);
			float y = Mathf.Min(Mathf.Min(Mathf.Min(min2.z, p.z), max2.z), p2.z);
			float z = Mathf.Max(Mathf.Max(Mathf.Max(min2.x, p.x), max2.x), p2.x);
			float w = Mathf.Max(Mathf.Max(Mathf.Max(min2.z, p.z), max2.z), p2.z);
			return new Vector4(x, y, z, w);
		}
		return new Vector4(min.x, min.z, max.x, max.z);
	}

	public Vector3 GetMaxXMinZ()
	{
		if (rotateAroundY)
		{
			Vector2 rotationY = GetRotationY();
			Vector3 vector = new Vector3(bounds.max.x, 0f, bounds.min.z) - bounds.center;
			return new Vector3(vector.x * rotationY.y + vector.z * rotationY.x, vector.y, vector.x * (0f - rotationY.x) + vector.z * rotationY.y) + bounds.center;
		}
		return bounds.max;
	}

	public Vector3 GetInvSize()
	{
		Bounds bounds = this.bounds;
		return new Vector3(1f / bounds.size.x, 1f / bounds.size.y, 1f / bounds.size.z);
	}

	public Matrix4x4 GetMatrix()
	{
		if (tform == null)
		{
			tform = base.transform;
		}
		return Matrix4x4.TRS(tform.position, tform.rotation, Vector3.one).inverse;
	}

	public Vector2 GetRotationY()
	{
		if (!rotateAroundY)
		{
			return new Vector2(0f, 1f);
		}
		if (tform == null)
		{
			tform = base.transform;
		}
		float f = tform.eulerAngles.y * (MathF.PI / 180f);
		return new Vector2(Mathf.Sin(f), Mathf.Cos(f));
	}

	public void SetGlobalParams()
	{
		Shader.SetGlobalTexture("_Volume0", bakedTexture0);
		Shader.SetGlobalTexture("_Volume1", bakedTexture1);
		Shader.SetGlobalTexture("_Volume2", bakedTexture2);
		if (bakedTexture3 != null)
		{
			Shader.SetGlobalTexture("_Volume3", bakedTexture3);
		}
		Shader.SetGlobalTexture("_VolumeMask", bakedMask);
		Shader.SetGlobalVector("_GlobalVolumeMin", GetMin());
		Shader.SetGlobalVector("_GlobalVolumeInvSize", GetInvSize());
		if (supportRotationAfterBake)
		{
			Shader.SetGlobalMatrix("_GlobalVolumeMatrix", GetMatrix());
		}
		if (rotateAroundY)
		{
			Shader.SetGlobalVector("_GlobalVolumeRY", GetRotationY());
		}
		if (bakedTexture0 != null)
		{
			Shader.SetGlobalVector("_GlobalVolumeVoxelSize", new Vector3(1f / (float)bakedTexture0.width, 1f / (float)bakedTexture0.height, 1f / (float)bakedTexture0.depth));
		}
	}

	public void UpdateBounds()
	{
		Vector3 position = base.transform.position;
		Vector3 size = bounds.size;
		bounds = new Bounds(position, size);
	}

	public void OnEnable()
	{
		if (isGlobal)
		{
			globalVolume = this;
			SetGlobalParams();
		}
	}

	private void OnDrawGizmos()
	{
		if (showAll)
		{
			Gizmos.color = new Color(1f, 1f, 1f, 0.35f);
			Transform transform = base.transform;
			if (rotateAroundY)
			{
				Quaternion quaternion = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
				Gizmos.matrix = Matrix4x4.TRS(quaternion * -transform.position + transform.position, quaternion, Vector3.one);
			}
			Gizmos.DrawWireCube(transform.position, bounds.size);
		}
	}
}
public class ftGlobalStorage : ScriptableObject
{
}
public class ftLightmaps
{
	private struct LightmapAdditionalData
	{
		public Texture2D rnm0;

		public Texture2D rnm1;

		public Texture2D rnm2;

		public int mode;
	}

	private static List<int> lightmapRefCount;

	private static List<LightmapAdditionalData> globalMapsAdditional;

	private static int directionalMode;

	static ftLightmaps()
	{
		directionalMode = -1;
		SceneManager.activeSceneChanged -= OnSceneChangedPlay;
		SceneManager.activeSceneChanged += OnSceneChangedPlay;
	}

	private static void SetDirectionalMode()
	{
		if (directionalMode >= 0)
		{
			LightmapSettings.lightmapsMode = ((directionalMode == 1) ? LightmapsMode.CombinedDirectional : LightmapsMode.NonDirectional);
		}
	}

	private static void OnSceneChangedPlay(Scene prev, Scene next)
	{
		SetDirectionalMode();
	}

	public static void RefreshFull()
	{
		Scene activeScene = SceneManager.GetActiveScene();
		int sceneCount = SceneManager.sceneCount;
		for (int i = 0; i < sceneCount; i++)
		{
			Scene sceneAt = SceneManager.GetSceneAt(i);
			if (sceneAt.isLoaded && !sceneAt.isSubScene)
			{
				SceneManager.SetActiveScene(sceneAt);
				if ((bool)FindInScene("!ftraceLightmaps", sceneAt))
				{
					LightmapSettings.lightmaps = new LightmapData[0];
				}
			}
		}
		for (int j = 0; j < sceneCount; j++)
		{
			Scene sceneAt2 = SceneManager.GetSceneAt(j);
			if (!sceneAt2.isSubScene)
			{
				RefreshScene(sceneAt2, null, updateNonBaked: true);
			}
		}
		SceneManager.SetActiveScene(activeScene);
	}

	public static GameObject FindInScene(string nm, Scene scn)
	{
		GameObject[] rootGameObjects = scn.GetRootGameObjects();
		for (int i = 0; i < rootGameObjects.Length; i++)
		{
			if (rootGameObjects[i].name == nm)
			{
				return rootGameObjects[i];
			}
			Transform transform = rootGameObjects[i].transform.Find(nm);
			if (transform != null)
			{
				return transform.gameObject;
			}
		}
		return null;
	}

	private static Texture2D GetEmptyDirectionTex(ftLightmapsStorage storage)
	{
		return storage.emptyDirectionTex;
	}

	public static void RefreshScene(Scene scene, ftLightmapsStorage storage = null, bool updateNonBaked = false, bool incrementRefcount = false)
	{
		int sceneCount = SceneManager.sceneCount;
		if (globalMapsAdditional == null)
		{
			globalMapsAdditional = new List<LightmapAdditionalData>();
		}
		List<LightmapData> list = new List<LightmapData>();
		List<LightmapAdditionalData> list2 = new List<LightmapAdditionalData>();
		LightmapData[] lightmaps = LightmapSettings.lightmaps;
		List<LightmapAdditionalData> list3 = globalMapsAdditional;
		if (storage == null)
		{
			if (!scene.isLoaded)
			{
				return;
			}
			SceneManager.SetActiveScene(scene);
			GameObject gameObject = FindInScene("!ftraceLightmaps", scene);
			if (gameObject == null)
			{
				return;
			}
			storage = gameObject.GetComponent<ftLightmapsStorage>();
			if (storage == null)
			{
				return;
			}
		}
		if (storage.idremap == null || storage.idremap.Length != storage.maps.Count)
		{
			storage.idremap = new int[storage.maps.Count];
		}
		directionalMode = ((storage.dirMaps.Count != 0) ? 1 : 0);
		bool flag = false;
		SetDirectionalMode();
		if (directionalMode == 1)
		{
			for (int i = 0; i < lightmaps.Length; i++)
			{
				if (lightmaps[i].lightmapDir == null)
				{
					LightmapData lightmapData = lightmaps[i];
					lightmapData.lightmapDir = GetEmptyDirectionTex(storage);
					lightmaps[i] = lightmapData;
					flag = true;
				}
			}
		}
		bool flag2 = false;
		if (lightmaps.Length == storage.maps.Count)
		{
			flag2 = true;
			for (int j = 0; j < storage.maps.Count; j++)
			{
				if (lightmaps[j].lightmapColor != storage.maps[j])
				{
					flag2 = false;
					break;
				}
				if (storage.rnmMaps0.Count > j && (list3.Count <= j || list3[j].rnm0 != storage.rnmMaps0[j]))
				{
					flag2 = false;
					break;
				}
			}
		}
		if (!flag2)
		{
			if (sceneCount >= 1)
			{
				for (int k = 0; k < lightmaps.Length; k++)
				{
					if ((lightmaps[k] != null && (!(lightmaps[k].lightmapColor == null) || !(lightmaps[k].shadowMask == null))) || (k != 0 && k != lightmaps.Length - 1))
					{
						list.Add(lightmaps[k]);
						if (list3.Count > k)
						{
							list2.Add(list3[k]);
						}
					}
				}
			}
			for (int l = 0; l < storage.maps.Count; l++)
			{
				Texture2D texture2D = storage.maps[l];
				Texture2D texture2D2 = null;
				Texture2D texture2D3 = null;
				Texture2D texture2D4 = null;
				Texture2D rnm = null;
				Texture2D rnm2 = null;
				int mode = 0;
				if (storage.masks.Count > l)
				{
					texture2D2 = storage.masks[l];
				}
				if (storage.dirMaps.Count > l)
				{
					texture2D3 = storage.dirMaps[l];
				}
				if (storage.rnmMaps0.Count > l)
				{
					texture2D4 = storage.rnmMaps0[l];
					rnm = storage.rnmMaps1[l];
					rnm2 = storage.rnmMaps2[l];
					mode = storage.mapsMode[l];
				}
				bool flag3 = false;
				int num = -1;
				for (int m = 0; m < list.Count; m++)
				{
					if (list[m].lightmapColor == texture2D && list[m].shadowMask == texture2D2)
					{
						storage.idremap[l] = m;
						flag3 = true;
						if (texture2D4 != null && (list2.Count <= m || list2[m].rnm0 == null))
						{
							while (list2.Count <= m)
							{
								list2.Add(default(LightmapAdditionalData));
							}
							list2[m] = new LightmapAdditionalData
							{
								rnm0 = texture2D4,
								rnm1 = rnm,
								rnm2 = rnm2,
								mode = mode
							};
						}
						break;
					}
					if (num < 0 && list[m].lightmapColor == null && list[m].shadowMask == null)
					{
						storage.idremap[l] = m;
						num = m;
					}
				}
				if (flag3)
				{
					continue;
				}
				LightmapData lightmapData2 = ((num < 0) ? new LightmapData() : list[num]);
				lightmapData2.lightmapColor = texture2D;
				if (storage.masks.Count > l)
				{
					lightmapData2.shadowMask = texture2D2;
				}
				if (storage.dirMaps.Count > l && texture2D3 != null)
				{
					lightmapData2.lightmapDir = texture2D3;
				}
				else if (directionalMode == 1)
				{
					lightmapData2.lightmapDir = GetEmptyDirectionTex(storage);
				}
				if (num < 0)
				{
					list.Add(lightmapData2);
					storage.idremap[l] = list.Count - 1;
				}
				else
				{
					list[num] = lightmapData2;
				}
				if (storage.rnmMaps0.Count <= l)
				{
					continue;
				}
				LightmapAdditionalData lightmapAdditionalData = new LightmapAdditionalData
				{
					rnm0 = texture2D4,
					rnm1 = rnm,
					rnm2 = rnm2,
					mode = mode
				};
				if (num < 0)
				{
					while (list2.Count < list.Count - 1)
					{
						list2.Add(default(LightmapAdditionalData));
					}
					list2.Add(lightmapAdditionalData);
				}
				else
				{
					while (list2.Count < num + 1)
					{
						list2.Add(default(LightmapAdditionalData));
					}
					list2[num] = lightmapAdditionalData;
				}
			}
		}
		else
		{
			for (int n = 0; n < storage.maps.Count; n++)
			{
				storage.idremap[n] = n;
			}
		}
		if (flag2 && flag)
		{
			LightmapSettings.lightmaps = lightmaps;
		}
		if (!flag2)
		{
			LightmapSettings.lightmaps = list.ToArray();
			globalMapsAdditional = list2;
		}
		if (RenderSettings.ambientMode == AmbientMode.Skybox)
		{
			SphericalHarmonicsL2 ambientProbe = RenderSettings.ambientProbe;
			int num2 = -1;
			for (int num3 = 0; num3 < 3; num3++)
			{
				for (int num4 = 0; num4 < 9; num4++)
				{
					float num5 = Mathf.Abs(ambientProbe[num3, num4]);
					if (num5 > 1000f || num5 < 1E-06f)
					{
						num2 = 1;
						break;
					}
					if (ambientProbe[num3, num4] != 0f)
					{
						num2 = 0;
						break;
					}
				}
				if (num2 >= 0)
				{
					break;
				}
			}
			if (num2 != 0)
			{
				if (SystemInfo.graphicsDeviceType != GraphicsDeviceType.WebGPU)
				{
					DynamicGI.UpdateEnvironment();
				}
				else
				{
					UnityEngine.Debug.LogError("Unity doesn't support DynamicGI.UpdateEnvironment() on WebGPU.");
				}
			}
		}
		Vector4 vector = new Vector4(1f, 1f, 0f, 0f);
		for (int num6 = 0; num6 < storage.bakedRenderers.Count; num6++)
		{
			Renderer renderer = storage.bakedRenderers[num6];
			if (renderer == null)
			{
				continue;
			}
			int num7 = storage.bakedIDs[num6];
			Mesh mesh = null;
			if (num6 < storage.bakedVertexColorMesh.Count)
			{
				mesh = storage.bakedVertexColorMesh[num6];
			}
			if (mesh != null)
			{
				MeshRenderer meshRenderer = renderer as MeshRenderer;
				if (meshRenderer == null)
				{
					UnityEngine.Debug.LogError("Unity cannot use additionalVertexStreams on non-MeshRenderer");
					continue;
				}
				meshRenderer.additionalVertexStreams = mesh;
				meshRenderer.lightmapIndex = 65535;
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				materialPropertyBlock.SetFloat("bakeryLightmapMode", 1f);
				meshRenderer.SetPropertyBlock(materialPropertyBlock);
				continue;
			}
			int num8 = (renderer.lightmapIndex = ((num7 < 0 || num7 >= storage.idremap.Length) ? num7 : storage.idremap[num7]));
			if (!renderer.isPartOfStaticBatch)
			{
				Vector4 lightmapScaleOffset = ((num7 < 0) ? vector : storage.bakedScaleOffset[num6]);
				renderer.lightmapScaleOffset = lightmapScaleOffset;
			}
			if (renderer.lightmapIndex >= 0 && num8 < globalMapsAdditional.Count)
			{
				LightmapAdditionalData lightmapAdditionalData2 = globalMapsAdditional[num8];
				if (lightmapAdditionalData2.rnm0 != null)
				{
					MaterialPropertyBlock materialPropertyBlock2 = new MaterialPropertyBlock();
					materialPropertyBlock2.SetTexture("_RNM0", lightmapAdditionalData2.rnm0);
					materialPropertyBlock2.SetTexture("_RNM1", lightmapAdditionalData2.rnm1);
					materialPropertyBlock2.SetTexture("_RNM2", lightmapAdditionalData2.rnm2);
					materialPropertyBlock2.SetFloat("bakeryLightmapMode", lightmapAdditionalData2.mode);
					renderer.SetPropertyBlock(materialPropertyBlock2);
				}
			}
		}
		if (updateNonBaked)
		{
			for (int num10 = 0; num10 < storage.nonBakedRenderers.Count; num10++)
			{
				Renderer renderer2 = storage.nonBakedRenderers[num10];
				if (!(renderer2 == null) && !renderer2.isPartOfStaticBatch)
				{
					renderer2.lightmapIndex = 65534;
				}
			}
		}
		for (int num11 = 0; num11 < storage.bakedRenderersTerrain.Count; num11++)
		{
			Terrain terrain = storage.bakedRenderersTerrain[num11];
			if (terrain == null)
			{
				continue;
			}
			int num12 = storage.bakedIDsTerrain[num11];
			terrain.lightmapIndex = ((num12 < 0 || num12 >= storage.idremap.Length) ? num12 : storage.idremap[num12]);
			Vector4 lightmapScaleOffset2 = ((num12 < 0) ? vector : storage.bakedScaleOffsetTerrain[num11]);
			terrain.lightmapScaleOffset = lightmapScaleOffset2;
			if (terrain.lightmapIndex >= 0 && terrain.lightmapIndex < globalMapsAdditional.Count)
			{
				LightmapAdditionalData lightmapAdditionalData3 = globalMapsAdditional[terrain.lightmapIndex];
				if (lightmapAdditionalData3.rnm0 != null)
				{
					MaterialPropertyBlock materialPropertyBlock3 = new MaterialPropertyBlock();
					materialPropertyBlock3.SetTexture("_RNM0", lightmapAdditionalData3.rnm0);
					materialPropertyBlock3.SetTexture("_RNM1", lightmapAdditionalData3.rnm1);
					materialPropertyBlock3.SetTexture("_RNM2", lightmapAdditionalData3.rnm2);
					materialPropertyBlock3.SetFloat("bakeryLightmapMode", lightmapAdditionalData3.mode);
					terrain.SetSplatMaterialPropertyBlock(materialPropertyBlock3);
				}
			}
		}
		for (int num13 = 0; num13 < storage.bakedLights.Count; num13++)
		{
			if (!(storage.bakedLights[num13] == null))
			{
				int num14 = storage.bakedLightChannels[num13];
				LightBakingOutput bakingOutput = new LightBakingOutput
				{
					isBaked = true
				};
				if (num14 < 0)
				{
					bakingOutput.lightmapBakeType = LightmapBakeType.Baked;
				}
				else
				{
					bakingOutput.lightmapBakeType = LightmapBakeType.Mixed;
					bakingOutput.mixedLightingMode = ((num14 >= 100) ? MixedLightingMode.Subtractive : MixedLightingMode.Shadowmask);
					bakingOutput.occlusionMaskChannel = ((num14 >= 100) ? (num14 - 100) : num14);
					bakingOutput.probeOcclusionLightIndex = storage.bakedLights[num13].bakingOutput.probeOcclusionLightIndex;
				}
				storage.bakedLights[num13].bakingOutput = bakingOutput;
			}
		}
		if (!incrementRefcount)
		{
			return;
		}
		if (lightmapRefCount == null)
		{
			lightmapRefCount = new List<int>();
		}
		for (int num15 = 0; num15 < storage.idremap.Length; num15++)
		{
			int num16 = storage.idremap[num15];
			while (lightmapRefCount.Count <= num16)
			{
				lightmapRefCount.Add(0);
			}
			if (lightmapRefCount[num16] < 0)
			{
				lightmapRefCount[num16] = 0;
			}
			lightmapRefCount[num16]++;
		}
	}

	public static void UnloadScene(ftLightmapsStorage storage)
	{
		if (lightmapRefCount == null || storage.idremap == null)
		{
			return;
		}
		LightmapData[] array = null;
		List<LightmapAdditionalData> list = null;
		for (int i = 0; i < storage.idremap.Length; i++)
		{
			int num = storage.idremap[i];
			if (num == 0 || lightmapRefCount.Count <= num)
			{
				continue;
			}
			lightmapRefCount[num]--;
			if (lightmapRefCount[num] != 0)
			{
				continue;
			}
			if (array == null)
			{
				array = LightmapSettings.lightmaps;
			}
			if (array.Length > num)
			{
				array[num].lightmapColor = null;
				array[num].lightmapDir = null;
				array[num].shadowMask = null;
				if (list == null)
				{
					list = globalMapsAdditional;
				}
				if (list != null && list.Count > num)
				{
					list[num] = default(LightmapAdditionalData);
				}
			}
		}
		if (array != null)
		{
			LightmapSettings.lightmaps = array;
		}
	}

	public static void RefreshScene2(Scene scene, ftLightmapsStorage storage)
	{
		for (int i = 0; i < storage.bakedRenderers.Count; i++)
		{
			Renderer renderer = storage.bakedRenderers[i];
			if (!(renderer == null))
			{
				int num = storage.bakedIDs[i];
				renderer.lightmapIndex = ((num < 0 || num >= storage.idremap.Length) ? num : storage.idremap[num]);
			}
		}
		for (int j = 0; j < storage.bakedRenderersTerrain.Count; j++)
		{
			Terrain terrain = storage.bakedRenderersTerrain[j];
			if (!(terrain == null))
			{
				int num = storage.bakedIDsTerrain[j];
				terrain.lightmapIndex = ((num < 0 || num >= storage.idremap.Length) ? num : storage.idremap[num]);
			}
		}
		if (storage.anyVolumes)
		{
			if (storage.compressedVolumes)
			{
				Shader.EnableKeyword("BAKERY_COMPRESSED_VOLUME");
			}
			else
			{
				Shader.DisableKeyword("BAKERY_COMPRESSED_VOLUME");
			}
		}
	}
}
[ExecuteInEditMode]
public class ftLightmapsStorage : MonoBehaviour
{
	public const bool externalStorage = false;

	public List<Renderer> bakedRenderers = new List<Renderer>();

	public List<Renderer> nonBakedRenderers = new List<Renderer>();

	public List<Light> bakedLights = new List<Light>();

	public List<Terrain> bakedRenderersTerrain = new List<Terrain>();

	public List<Texture2D> maps = new List<Texture2D>();

	public List<Texture2D> masks = new List<Texture2D>();

	public List<Texture2D> dirMaps = new List<Texture2D>();

	public List<Texture2D> rnmMaps0 = new List<Texture2D>();

	public List<Texture2D> rnmMaps1 = new List<Texture2D>();

	public List<Texture2D> rnmMaps2 = new List<Texture2D>();

	public List<int> mapsMode = new List<int>();

	public List<int> bakedIDs = new List<int>();

	public List<Vector4> bakedScaleOffset = new List<Vector4>();

	public List<Mesh> bakedVertexColorMesh = new List<Mesh>();

	public List<int> bakedLightChannels = new List<int>();

	public List<int> bakedIDsTerrain = new List<int>();

	public List<Vector4> bakedScaleOffsetTerrain = new List<Vector4>();

	public List<string> assetList = new List<string>();

	public List<int> uvOverlapAssetList = new List<int>();

	public int[] idremap;

	public bool usesRealtimeGI;

	public Texture2D emptyDirectionTex;

	public bool anyVolumes;

	public bool compressedVolumes;

	private void Awake()
	{
		ftLightmaps.RefreshScene(base.gameObject.scene, this, updateNonBaked: false, incrementRefcount: true);
	}

	private void Start()
	{
		ftLightmaps.RefreshScene(base.gameObject.scene, this);
		ftLightmaps.RefreshScene2(base.gameObject.scene, this);
	}

	private void OnDestroy()
	{
		ftLightmaps.UnloadScene(this);
	}
}
public class ftLocalStorage : ScriptableObject
{
	[SerializeField]
	public List<string> modifiedAssetPathList = new List<string>();

	[SerializeField]
	public List<int> modifiedAssetPaddingHash = new List<int>();
}
public class ftStorageAsset : ScriptableObject
{
	[SerializeField]
	public List<Texture2D> maps = new List<Texture2D>();

	[SerializeField]
	public List<Texture2D> masks = new List<Texture2D>();

	[SerializeField]
	public List<Texture2D> dirMaps = new List<Texture2D>();

	[SerializeField]
	public List<Texture2D> rnmMaps0 = new List<Texture2D>();

	[SerializeField]
	public List<Texture2D> rnmMaps1 = new List<Texture2D>();

	[SerializeField]
	public List<Texture2D> rnmMaps2 = new List<Texture2D>();

	[SerializeField]
	public List<int> mapsMode = new List<int>();

	[SerializeField]
	public List<int> bakedIDs = new List<int>();

	[SerializeField]
	public List<Vector4> bakedScaleOffset = new List<Vector4>();

	[SerializeField]
	public List<Mesh> bakedVertexColorMesh = new List<Mesh>();

	[SerializeField]
	public List<int> bakedLightChannels = new List<int>();

	[SerializeField]
	public List<int> bakedIDsTerrain = new List<int>();

	[SerializeField]
	public List<Vector4> bakedScaleOffsetTerrain = new List<Vector4>();

	[SerializeField]
	public List<string> assetList = new List<string>();

	[SerializeField]
	public List<int> uvOverlapAssetList = new List<int>();

	[SerializeField]
	public int[] idremap;
}
public static class ftUniqueIDRegistry
{
	public static Dictionary<int, int> Mapping = new Dictionary<int, int>();

	public static Dictionary<int, int> MappingInv = new Dictionary<int, int>();

	public static void Deregister(int id)
	{
		int instanceId = GetInstanceId(id);
		if (instanceId >= 0)
		{
			MappingInv.Remove(instanceId);
			Mapping.Remove(id);
		}
	}

	public static void Register(int id, int value)
	{
		if (!Mapping.ContainsKey(id))
		{
			Mapping[id] = value;
			MappingInv[value] = id;
		}
	}

	public static int GetInstanceId(int id)
	{
		if (!Mapping.TryGetValue(id, out var value))
		{
			return -1;
		}
		return value;
	}

	public static int GetUID(int instanceId)
	{
		if (MappingInv.TryGetValue(instanceId, out var value))
		{
			return value;
		}
		return -1;
	}
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
			FilePathsData = new byte[860]
			{
				0, 0, 0, 1, 0, 0, 0, 36, 92, 65,
				115, 115, 101, 116, 115, 92, 66, 97, 107, 101,
				114, 121, 92, 66, 97, 107, 101, 114, 121, 65,
				108, 119, 97, 121, 115, 82, 101, 110, 100, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 35, 92, 65, 115, 115, 101, 116, 115, 92,
				66, 97, 107, 101, 114, 121, 92, 66, 97, 107,
				101, 114, 121, 68, 105, 114, 101, 99, 116, 76,
				105, 103, 104, 116, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 35, 92, 65, 115, 115, 101,
				116, 115, 92, 66, 97, 107, 101, 114, 121, 92,
				66, 97, 107, 101, 114, 121, 76, 105, 103, 104,
				116, 70, 105, 108, 116, 101, 114, 46, 99, 115,
				0, 0, 0, 2, 0, 0, 0, 37, 92, 65,
				115, 115, 101, 116, 115, 92, 66, 97, 107, 101,
				114, 121, 92, 66, 97, 107, 101, 114, 121, 76,
				105, 103, 104, 116, 109, 97, 112, 71, 114, 111,
				117, 112, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 45, 92, 65, 115, 115, 101, 116, 115,
				92, 66, 97, 107, 101, 114, 121, 92, 66, 97,
				107, 101, 114, 121, 76, 105, 103, 104, 116, 109,
				97, 112, 71, 114, 111, 117, 112, 83, 101, 108,
				101, 99, 116, 111, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 41, 92, 65, 115, 115,
				101, 116, 115, 92, 66, 97, 107, 101, 114, 121,
				92, 66, 97, 107, 101, 114, 121, 76, 105, 103,
				104, 116, 109, 97, 112, 112, 101, 100, 80, 114,
				101, 102, 97, 98, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 33, 92, 65, 115, 115, 101,
				116, 115, 92, 66, 97, 107, 101, 114, 121, 92,
				66, 97, 107, 101, 114, 121, 76, 105, 103, 104,
				116, 77, 101, 115, 104, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 42, 92, 65, 115, 115,
				101, 116, 115, 92, 66, 97, 107, 101, 114, 121,
				92, 66, 97, 107, 101, 114, 121, 80, 97, 99,
				107, 65, 115, 83, 105, 110, 103, 108, 101, 83,
				113, 117, 97, 114, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 34, 92, 65, 115, 115,
				101, 116, 115, 92, 66, 97, 107, 101, 114, 121,
				92, 66, 97, 107, 101, 114, 121, 80, 111, 105,
				110, 116, 76, 105, 103, 104, 116, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 30, 92, 65,
				115, 115, 101, 116, 115, 92, 66, 97, 107, 101,
				114, 121, 92, 66, 97, 107, 101, 114, 121, 83,
				101, 99, 116, 111, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 37, 92, 65, 115, 115,
				101, 116, 115, 92, 66, 97, 107, 101, 114, 121,
				92, 66, 97, 107, 101, 114, 121, 83, 101, 99,
				116, 111, 114, 67, 97, 112, 116, 117, 114, 101,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				35, 92, 65, 115, 115, 101, 116, 115, 92, 66,
				97, 107, 101, 114, 121, 92, 66, 97, 107, 101,
				114, 121, 83, 104, 97, 114, 101, 100, 76, 111,
				100, 85, 118, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 32, 92, 65, 115, 115, 101, 116,
				115, 92, 66, 97, 107, 101, 114, 121, 92, 66,
				97, 107, 101, 114, 121, 83, 107, 121, 76, 105,
				103, 104, 116, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 30, 92, 65, 115, 115, 101, 116,
				115, 92, 66, 97, 107, 101, 114, 121, 92, 66,
				97, 107, 101, 114, 121, 86, 111, 108, 117, 109,
				101, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 33, 92, 65, 115, 115, 101, 116, 115, 92,
				66, 97, 107, 101, 114, 121, 92, 102, 116, 71,
				108, 111, 98, 97, 108, 83, 116, 111, 114, 97,
				103, 101, 46, 99, 115, 0, 0, 0, 2, 0,
				0, 0, 29, 92, 65, 115, 115, 101, 116, 115,
				92, 66, 97, 107, 101, 114, 121, 92, 102, 116,
				76, 105, 103, 104, 116, 109, 97, 112, 115, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 36,
				92, 65, 115, 115, 101, 116, 115, 92, 66, 97,
				107, 101, 114, 121, 92, 102, 116, 76, 105, 103,
				104, 116, 109, 97, 112, 115, 83, 116, 111, 114,
				97, 103, 101, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 32, 92, 65, 115, 115, 101, 116,
				115, 92, 66, 97, 107, 101, 114, 121, 92, 102,
				116, 76, 111, 99, 97, 108, 83, 116, 111, 114,
				97, 103, 101, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 32, 92, 65, 115, 115, 101, 116,
				115, 92, 66, 97, 107, 101, 114, 121, 92, 102,
				116, 83, 116, 111, 114, 97, 103, 101, 65, 115,
				115, 101, 116, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 36, 92, 65, 115, 115, 101, 116,
				115, 92, 66, 97, 107, 101, 114, 121, 92, 102,
				116, 85, 110, 105, 113, 117, 101, 73, 68, 82,
				101, 103, 105, 115, 116, 114, 121, 46, 99, 115
			},
			TypesData = new byte[529]
			{
				0, 0, 0, 0, 19, 124, 66, 97, 107, 101,
				114, 121, 65, 108, 119, 97, 121, 115, 82, 101,
				110, 100, 101, 114, 0, 0, 0, 0, 18, 124,
				66, 97, 107, 101, 114, 121, 68, 105, 114, 101,
				99, 116, 76, 105, 103, 104, 116, 0, 0, 0,
				0, 18, 124, 66, 97, 107, 101, 114, 121, 76,
				105, 103, 104, 116, 70, 105, 108, 116, 101, 114,
				0, 0, 0, 0, 25, 124, 66, 97, 107, 101,
				114, 121, 76, 105, 103, 104, 116, 109, 97, 112,
				71, 114, 111, 117, 112, 80, 108, 97, 105, 110,
				0, 0, 0, 0, 20, 124, 66, 97, 107, 101,
				114, 121, 76, 105, 103, 104, 116, 109, 97, 112,
				71, 114, 111, 117, 112, 0, 0, 0, 0, 28,
				124, 66, 97, 107, 101, 114, 121, 76, 105, 103,
				104, 116, 109, 97, 112, 71, 114, 111, 117, 112,
				83, 101, 108, 101, 99, 116, 111, 114, 0, 0,
				0, 0, 24, 124, 66, 97, 107, 101, 114, 121,
				76, 105, 103, 104, 116, 109, 97, 112, 112, 101,
				100, 80, 114, 101, 102, 97, 98, 0, 0, 0,
				0, 16, 124, 66, 97, 107, 101, 114, 121, 76,
				105, 103, 104, 116, 77, 101, 115, 104, 0, 0,
				0, 0, 25, 124, 66, 97, 107, 101, 114, 121,
				80, 97, 99, 107, 65, 115, 83, 105, 110, 103,
				108, 101, 83, 113, 117, 97, 114, 101, 0, 0,
				0, 0, 17, 124, 66, 97, 107, 101, 114, 121,
				80, 111, 105, 110, 116, 76, 105, 103, 104, 116,
				0, 0, 0, 0, 13, 124, 66, 97, 107, 101,
				114, 121, 83, 101, 99, 116, 111, 114, 0, 0,
				0, 0, 20, 124, 66, 97, 107, 101, 114, 121,
				83, 101, 99, 116, 111, 114, 67, 97, 112, 116,
				117, 114, 101, 0, 0, 0, 0, 18, 124, 66,
				97, 107, 101, 114, 121, 83, 104, 97, 114, 101,
				100, 76, 111, 100, 85, 118, 0, 0, 0, 0,
				15, 124, 66, 97, 107, 101, 114, 121, 83, 107,
				121, 76, 105, 103, 104, 116, 0, 0, 0, 0,
				13, 124, 66, 97, 107, 101, 114, 121, 86, 111,
				108, 117, 109, 101, 0, 0, 0, 0, 16, 124,
				102, 116, 71, 108, 111, 98, 97, 108, 83, 116,
				111, 114, 97, 103, 101, 0, 0, 0, 0, 12,
				124, 102, 116, 76, 105, 103, 104, 116, 109, 97,
				112, 115, 0, 0, 0, 0, 34, 102, 116, 76,
				105, 103, 104, 116, 109, 97, 112, 115, 124, 76,
				105, 103, 104, 116, 109, 97, 112, 65, 100, 100,
				105, 116, 105, 111, 110, 97, 108, 68, 97, 116,
				97, 0, 0, 0, 0, 19, 124, 102, 116, 76,
				105, 103, 104, 116, 109, 97, 112, 115, 83, 116,
				111, 114, 97, 103, 101, 0, 0, 0, 0, 15,
				124, 102, 116, 76, 111, 99, 97, 108, 83, 116,
				111, 114, 97, 103, 101, 0, 0, 0, 0, 15,
				124, 102, 116, 83, 116, 111, 114, 97, 103, 101,
				65, 115, 115, 101, 116, 0, 0, 0, 0, 19,
				124, 102, 116, 85, 110, 105, 113, 117, 101, 73,
				68, 82, 101, 103, 105, 115, 116, 114, 121
			},
			TotalFiles = 20,
			TotalTypes = 22,
			IsEditorOnly = false
		};
	}
}
