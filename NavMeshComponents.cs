using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.Serialization;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyVersion("0.0.0.0")]
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
			FilePathsData = new byte[241]
			{
				0, 0, 0, 1, 0, 0, 0, 48, 92, 65,
				115, 115, 101, 116, 115, 92, 78, 97, 118, 77,
				101, 115, 104, 67, 111, 109, 112, 111, 110, 101,
				110, 116, 115, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 78, 97, 118, 77, 101, 115, 104, 76,
				105, 110, 107, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 52, 92, 65, 115, 115, 101, 116,
				115, 92, 78, 97, 118, 77, 101, 115, 104, 67,
				111, 109, 112, 111, 110, 101, 110, 116, 115, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 78, 97,
				118, 77, 101, 115, 104, 77, 111, 100, 105, 102,
				105, 101, 114, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 58, 92, 65, 115, 115, 101, 116,
				115, 92, 78, 97, 118, 77, 101, 115, 104, 67,
				111, 109, 112, 111, 110, 101, 110, 116, 115, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 78, 97,
				118, 77, 101, 115, 104, 77, 111, 100, 105, 102,
				105, 101, 114, 86, 111, 108, 117, 109, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 51,
				92, 65, 115, 115, 101, 116, 115, 92, 78, 97,
				118, 77, 101, 115, 104, 67, 111, 109, 112, 111,
				110, 101, 110, 116, 115, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 78, 97, 118, 77, 101, 115,
				104, 83, 117, 114, 102, 97, 99, 101, 46, 99,
				115
			},
			TypesData = new byte[141]
			{
				0, 0, 0, 0, 26, 85, 110, 105, 116, 121,
				69, 110, 103, 105, 110, 101, 46, 65, 73, 124,
				78, 97, 118, 77, 101, 115, 104, 76, 105, 110,
				107, 0, 0, 0, 0, 30, 85, 110, 105, 116,
				121, 69, 110, 103, 105, 110, 101, 46, 65, 73,
				124, 78, 97, 118, 77, 101, 115, 104, 77, 111,
				100, 105, 102, 105, 101, 114, 0, 0, 0, 0,
				36, 85, 110, 105, 116, 121, 69, 110, 103, 105,
				110, 101, 46, 65, 73, 124, 78, 97, 118, 77,
				101, 115, 104, 77, 111, 100, 105, 102, 105, 101,
				114, 86, 111, 108, 117, 109, 101, 0, 0, 0,
				0, 29, 85, 110, 105, 116, 121, 69, 110, 103,
				105, 110, 101, 46, 65, 73, 124, 78, 97, 118,
				77, 101, 115, 104, 83, 117, 114, 102, 97, 99,
				101
			},
			TotalFiles = 4,
			TotalTypes = 4,
			IsEditorOnly = false
		};
	}
}
namespace UnityEngine.AI;

[ExecuteInEditMode]
[DefaultExecutionOrder(-101)]
[AddComponentMenu("Navigation/NavMeshLink", 33)]
[HelpURL("https://github.com/Unity-Technologies/NavMeshComponents#documentation-draft")]
public class NavMeshLink : MonoBehaviour
{
	[SerializeField]
	private int m_AgentTypeID;

	[SerializeField]
	private Vector3 m_StartPoint = new Vector3(0f, 0f, -2.5f);

	[SerializeField]
	private Vector3 m_EndPoint = new Vector3(0f, 0f, 2.5f);

	[SerializeField]
	private float m_Width;

	[SerializeField]
	private int m_CostModifier = -1;

	[SerializeField]
	private bool m_Bidirectional = true;

	[SerializeField]
	private bool m_AutoUpdatePosition;

	[SerializeField]
	private int m_Area;

	private NavMeshLinkInstance m_LinkInstance;

	private Vector3 m_LastPosition = Vector3.zero;

	private Quaternion m_LastRotation = Quaternion.identity;

	private static readonly List<NavMeshLink> s_Tracked = new List<NavMeshLink>();

	public int agentTypeID
	{
		get
		{
			return m_AgentTypeID;
		}
		set
		{
			m_AgentTypeID = value;
			UpdateLink();
		}
	}

	public Vector3 startPoint
	{
		get
		{
			return m_StartPoint;
		}
		set
		{
			m_StartPoint = value;
			UpdateLink();
		}
	}

	public Vector3 endPoint
	{
		get
		{
			return m_EndPoint;
		}
		set
		{
			m_EndPoint = value;
			UpdateLink();
		}
	}

	public float width
	{
		get
		{
			return m_Width;
		}
		set
		{
			m_Width = value;
			UpdateLink();
		}
	}

	public int costModifier
	{
		get
		{
			return m_CostModifier;
		}
		set
		{
			m_CostModifier = value;
			UpdateLink();
		}
	}

	public bool bidirectional
	{
		get
		{
			return m_Bidirectional;
		}
		set
		{
			m_Bidirectional = value;
			UpdateLink();
		}
	}

	public bool autoUpdate
	{
		get
		{
			return m_AutoUpdatePosition;
		}
		set
		{
			SetAutoUpdate(value);
		}
	}

	public int area
	{
		get
		{
			return m_Area;
		}
		set
		{
			m_Area = value;
			UpdateLink();
		}
	}

	private void OnEnable()
	{
		AddLink();
		if (m_AutoUpdatePosition && m_LinkInstance.valid)
		{
			AddTracking(this);
		}
	}

	private void OnDisable()
	{
		RemoveTracking(this);
		m_LinkInstance.Remove();
	}

	public void UpdateLink()
	{
		m_LinkInstance.Remove();
		AddLink();
	}

	private static void AddTracking(NavMeshLink link)
	{
		if (s_Tracked.Count == 0)
		{
			NavMesh.onPreUpdate = (NavMesh.OnNavMeshPreUpdate)Delegate.Combine(NavMesh.onPreUpdate, new NavMesh.OnNavMeshPreUpdate(UpdateTrackedInstances));
		}
		s_Tracked.Add(link);
	}

	private static void RemoveTracking(NavMeshLink link)
	{
		s_Tracked.Remove(link);
		if (s_Tracked.Count == 0)
		{
			NavMesh.onPreUpdate = (NavMesh.OnNavMeshPreUpdate)Delegate.Remove(NavMesh.onPreUpdate, new NavMesh.OnNavMeshPreUpdate(UpdateTrackedInstances));
		}
	}

	private void SetAutoUpdate(bool value)
	{
		if (m_AutoUpdatePosition != value)
		{
			m_AutoUpdatePosition = value;
			if (value)
			{
				AddTracking(this);
			}
			else
			{
				RemoveTracking(this);
			}
		}
	}

	private void AddLink()
	{
		m_LinkInstance = NavMesh.AddLink(new NavMeshLinkData
		{
			startPosition = m_StartPoint,
			endPosition = m_EndPoint,
			width = m_Width,
			costModifier = m_CostModifier,
			bidirectional = m_Bidirectional,
			area = m_Area,
			agentTypeID = m_AgentTypeID
		}, base.transform.position, base.transform.rotation);
		if (m_LinkInstance.valid)
		{
			m_LinkInstance.owner = this;
		}
		m_LastPosition = base.transform.position;
		m_LastRotation = base.transform.rotation;
	}

	private bool HasTransformChanged()
	{
		if (m_LastPosition != base.transform.position)
		{
			return true;
		}
		if (m_LastRotation != base.transform.rotation)
		{
			return true;
		}
		return false;
	}

	private void OnDidApplyAnimationProperties()
	{
		UpdateLink();
	}

	private static void UpdateTrackedInstances()
	{
		foreach (NavMeshLink item in s_Tracked)
		{
			if (item.HasTransformChanged())
			{
				item.UpdateLink();
			}
		}
	}
}
[ExecuteInEditMode]
[AddComponentMenu("Navigation/NavMeshModifier", 32)]
[HelpURL("https://github.com/Unity-Technologies/NavMeshComponents#documentation-draft")]
public class NavMeshModifier : MonoBehaviour
{
	[SerializeField]
	private bool m_OverrideArea;

	[SerializeField]
	private int m_Area;

	[SerializeField]
	private bool m_IgnoreFromBuild;

	[SerializeField]
	private List<int> m_AffectedAgents = new List<int>(new int[1] { -1 });

	private static readonly List<NavMeshModifier> s_NavMeshModifiers = new List<NavMeshModifier>();

	public bool overrideArea
	{
		get
		{
			return m_OverrideArea;
		}
		set
		{
			m_OverrideArea = value;
		}
	}

	public int area
	{
		get
		{
			return m_Area;
		}
		set
		{
			m_Area = value;
		}
	}

	public bool ignoreFromBuild
	{
		get
		{
			return m_IgnoreFromBuild;
		}
		set
		{
			m_IgnoreFromBuild = value;
		}
	}

	public static List<NavMeshModifier> activeModifiers => s_NavMeshModifiers;

	private void OnEnable()
	{
		if (!s_NavMeshModifiers.Contains(this))
		{
			s_NavMeshModifiers.Add(this);
		}
	}

	private void OnDisable()
	{
		s_NavMeshModifiers.Remove(this);
	}

	public bool AffectsAgentType(int agentTypeID)
	{
		if (m_AffectedAgents.Count == 0)
		{
			return false;
		}
		if (m_AffectedAgents[0] == -1)
		{
			return true;
		}
		return m_AffectedAgents.IndexOf(agentTypeID) != -1;
	}
}
[ExecuteInEditMode]
[AddComponentMenu("Navigation/NavMeshModifierVolume", 31)]
[HelpURL("https://github.com/Unity-Technologies/NavMeshComponents#documentation-draft")]
public class NavMeshModifierVolume : MonoBehaviour
{
	[SerializeField]
	private Vector3 m_Size = new Vector3(4f, 3f, 4f);

	[SerializeField]
	private Vector3 m_Center = new Vector3(0f, 1f, 0f);

	[SerializeField]
	private int m_Area;

	[SerializeField]
	private List<int> m_AffectedAgents = new List<int>(new int[1] { -1 });

	private static readonly List<NavMeshModifierVolume> s_NavMeshModifiers = new List<NavMeshModifierVolume>();

	public Vector3 size
	{
		get
		{
			return m_Size;
		}
		set
		{
			m_Size = value;
		}
	}

	public Vector3 center
	{
		get
		{
			return m_Center;
		}
		set
		{
			m_Center = value;
		}
	}

	public int area
	{
		get
		{
			return m_Area;
		}
		set
		{
			m_Area = value;
		}
	}

	public static List<NavMeshModifierVolume> activeModifiers => s_NavMeshModifiers;

	private void OnEnable()
	{
		if (!s_NavMeshModifiers.Contains(this))
		{
			s_NavMeshModifiers.Add(this);
		}
	}

	private void OnDisable()
	{
		s_NavMeshModifiers.Remove(this);
	}

	public bool AffectsAgentType(int agentTypeID)
	{
		if (m_AffectedAgents.Count == 0)
		{
			return false;
		}
		if (m_AffectedAgents[0] == -1)
		{
			return true;
		}
		return m_AffectedAgents.IndexOf(agentTypeID) != -1;
	}
}
public enum CollectObjects
{
	All,
	Volume,
	Children
}
[ExecuteAlways]
[DefaultExecutionOrder(-102)]
[AddComponentMenu("Navigation/NavMeshSurface", 30)]
[HelpURL("https://github.com/Unity-Technologies/NavMeshComponents#documentation-draft")]
public class NavMeshSurface : MonoBehaviour
{
	[SerializeField]
	private int m_AgentTypeID;

	[SerializeField]
	private CollectObjects m_CollectObjects;

	[SerializeField]
	private Vector3 m_Size = new Vector3(10f, 10f, 10f);

	[SerializeField]
	private Vector3 m_Center = new Vector3(0f, 2f, 0f);

	[SerializeField]
	private LayerMask m_LayerMask = -1;

	[SerializeField]
	private NavMeshCollectGeometry m_UseGeometry;

	[SerializeField]
	private int m_DefaultArea;

	[SerializeField]
	private bool m_IgnoreNavMeshAgent = true;

	[SerializeField]
	private bool m_IgnoreNavMeshObstacle = true;

	[SerializeField]
	private bool m_OverrideTileSize;

	[SerializeField]
	private int m_TileSize = 256;

	[SerializeField]
	private bool m_OverrideVoxelSize;

	[SerializeField]
	private float m_VoxelSize;

	[SerializeField]
	private bool m_BuildHeightMesh;

	[FormerlySerializedAs("m_BakedNavMeshData")]
	[SerializeField]
	private NavMeshData m_NavMeshData;

	private NavMeshDataInstance m_NavMeshDataInstance;

	private Vector3 m_LastPosition = Vector3.zero;

	private Quaternion m_LastRotation = Quaternion.identity;

	private static readonly List<NavMeshSurface> s_NavMeshSurfaces = new List<NavMeshSurface>();

	public int agentTypeID
	{
		get
		{
			return m_AgentTypeID;
		}
		set
		{
			m_AgentTypeID = value;
		}
	}

	public CollectObjects collectObjects
	{
		get
		{
			return m_CollectObjects;
		}
		set
		{
			m_CollectObjects = value;
		}
	}

	public Vector3 size
	{
		get
		{
			return m_Size;
		}
		set
		{
			m_Size = value;
		}
	}

	public Vector3 center
	{
		get
		{
			return m_Center;
		}
		set
		{
			m_Center = value;
		}
	}

	public LayerMask layerMask
	{
		get
		{
			return m_LayerMask;
		}
		set
		{
			m_LayerMask = value;
		}
	}

	public NavMeshCollectGeometry useGeometry
	{
		get
		{
			return m_UseGeometry;
		}
		set
		{
			m_UseGeometry = value;
		}
	}

	public int defaultArea
	{
		get
		{
			return m_DefaultArea;
		}
		set
		{
			m_DefaultArea = value;
		}
	}

	public bool ignoreNavMeshAgent
	{
		get
		{
			return m_IgnoreNavMeshAgent;
		}
		set
		{
			m_IgnoreNavMeshAgent = value;
		}
	}

	public bool ignoreNavMeshObstacle
	{
		get
		{
			return m_IgnoreNavMeshObstacle;
		}
		set
		{
			m_IgnoreNavMeshObstacle = value;
		}
	}

	public bool overrideTileSize
	{
		get
		{
			return m_OverrideTileSize;
		}
		set
		{
			m_OverrideTileSize = value;
		}
	}

	public int tileSize
	{
		get
		{
			return m_TileSize;
		}
		set
		{
			m_TileSize = value;
		}
	}

	public bool overrideVoxelSize
	{
		get
		{
			return m_OverrideVoxelSize;
		}
		set
		{
			m_OverrideVoxelSize = value;
		}
	}

	public float voxelSize
	{
		get
		{
			return m_VoxelSize;
		}
		set
		{
			m_VoxelSize = value;
		}
	}

	public bool buildHeightMesh
	{
		get
		{
			return m_BuildHeightMesh;
		}
		set
		{
			m_BuildHeightMesh = value;
		}
	}

	public NavMeshData navMeshData
	{
		get
		{
			return m_NavMeshData;
		}
		set
		{
			m_NavMeshData = value;
		}
	}

	public static List<NavMeshSurface> activeSurfaces => s_NavMeshSurfaces;

	private void OnEnable()
	{
		Register(this);
		AddData();
	}

	private void OnDisable()
	{
		RemoveData();
		Unregister(this);
	}

	public void AddData()
	{
		if (!m_NavMeshDataInstance.valid)
		{
			if (m_NavMeshData != null)
			{
				m_NavMeshDataInstance = NavMesh.AddNavMeshData(m_NavMeshData, base.transform.position, base.transform.rotation);
				m_NavMeshDataInstance.owner = this;
			}
			m_LastPosition = base.transform.position;
			m_LastRotation = base.transform.rotation;
		}
	}

	public void RemoveData()
	{
		m_NavMeshDataInstance.Remove();
		m_NavMeshDataInstance = default(NavMeshDataInstance);
	}

	public NavMeshBuildSettings GetBuildSettings()
	{
		NavMeshBuildSettings settingsByID = NavMesh.GetSettingsByID(m_AgentTypeID);
		if (settingsByID.agentTypeID == -1)
		{
			Debug.LogWarning("No build settings for agent type ID " + agentTypeID, this);
			settingsByID.agentTypeID = m_AgentTypeID;
		}
		if (overrideTileSize)
		{
			settingsByID.overrideTileSize = true;
			settingsByID.tileSize = tileSize;
		}
		if (overrideVoxelSize)
		{
			settingsByID.overrideVoxelSize = true;
			settingsByID.voxelSize = voxelSize;
		}
		return settingsByID;
	}

	public void BuildNavMesh()
	{
		List<NavMeshBuildSource> sources = CollectSources();
		Bounds localBounds = new Bounds(m_Center, Abs(m_Size));
		if (m_CollectObjects == CollectObjects.All || m_CollectObjects == CollectObjects.Children)
		{
			localBounds = CalculateWorldBounds(sources);
		}
		NavMeshData navMeshData = NavMeshBuilder.BuildNavMeshData(GetBuildSettings(), sources, localBounds, base.transform.position, base.transform.rotation);
		if (navMeshData != null)
		{
			navMeshData.name = base.gameObject.name;
			RemoveData();
			m_NavMeshData = navMeshData;
			if (base.isActiveAndEnabled)
			{
				AddData();
			}
		}
	}

	public AsyncOperation UpdateNavMesh(NavMeshData data)
	{
		List<NavMeshBuildSource> sources = CollectSources();
		Bounds localBounds = new Bounds(m_Center, Abs(m_Size));
		if (m_CollectObjects == CollectObjects.All || m_CollectObjects == CollectObjects.Children)
		{
			localBounds = CalculateWorldBounds(sources);
		}
		return NavMeshBuilder.UpdateNavMeshDataAsync(data, GetBuildSettings(), sources, localBounds);
	}

	private static void Register(NavMeshSurface surface)
	{
		if (s_NavMeshSurfaces.Count == 0)
		{
			NavMesh.onPreUpdate = (NavMesh.OnNavMeshPreUpdate)Delegate.Combine(NavMesh.onPreUpdate, new NavMesh.OnNavMeshPreUpdate(UpdateActive));
		}
		if (!s_NavMeshSurfaces.Contains(surface))
		{
			s_NavMeshSurfaces.Add(surface);
		}
	}

	private static void Unregister(NavMeshSurface surface)
	{
		s_NavMeshSurfaces.Remove(surface);
		if (s_NavMeshSurfaces.Count == 0)
		{
			NavMesh.onPreUpdate = (NavMesh.OnNavMeshPreUpdate)Delegate.Remove(NavMesh.onPreUpdate, new NavMesh.OnNavMeshPreUpdate(UpdateActive));
		}
	}

	private static void UpdateActive()
	{
		for (int i = 0; i < s_NavMeshSurfaces.Count; i++)
		{
			s_NavMeshSurfaces[i].UpdateDataIfTransformChanged();
		}
	}

	private void AppendModifierVolumes(ref List<NavMeshBuildSource> sources)
	{
		List<NavMeshModifierVolume> list;
		if (m_CollectObjects == CollectObjects.Children)
		{
			list = new List<NavMeshModifierVolume>(GetComponentsInChildren<NavMeshModifierVolume>());
			list.RemoveAll((NavMeshModifierVolume x) => !x.isActiveAndEnabled);
		}
		else
		{
			list = NavMeshModifierVolume.activeModifiers;
		}
		foreach (NavMeshModifierVolume item2 in list)
		{
			if (((int)m_LayerMask & (1 << item2.gameObject.layer)) != 0 && item2.AffectsAgentType(m_AgentTypeID))
			{
				Vector3 pos = item2.transform.TransformPoint(item2.center);
				Vector3 lossyScale = item2.transform.lossyScale;
				Vector3 vector = new Vector3(item2.size.x * Mathf.Abs(lossyScale.x), item2.size.y * Mathf.Abs(lossyScale.y), item2.size.z * Mathf.Abs(lossyScale.z));
				NavMeshBuildSource item = new NavMeshBuildSource
				{
					shape = NavMeshBuildSourceShape.ModifierBox,
					transform = Matrix4x4.TRS(pos, item2.transform.rotation, Vector3.one),
					size = vector,
					area = item2.area
				};
				sources.Add(item);
			}
		}
	}

	private List<NavMeshBuildSource> CollectSources()
	{
		List<NavMeshBuildSource> sources = new List<NavMeshBuildSource>();
		List<NavMeshBuildMarkup> list = new List<NavMeshBuildMarkup>();
		List<NavMeshModifier> list2;
		if (m_CollectObjects == CollectObjects.Children)
		{
			list2 = new List<NavMeshModifier>(GetComponentsInChildren<NavMeshModifier>());
			list2.RemoveAll((NavMeshModifier x) => !x.isActiveAndEnabled);
		}
		else
		{
			list2 = NavMeshModifier.activeModifiers;
		}
		foreach (NavMeshModifier item in list2)
		{
			if (((int)m_LayerMask & (1 << item.gameObject.layer)) != 0 && item.AffectsAgentType(m_AgentTypeID))
			{
				list.Add(new NavMeshBuildMarkup
				{
					root = item.transform,
					overrideArea = item.overrideArea,
					area = item.area,
					ignoreFromBuild = item.ignoreFromBuild
				});
			}
		}
		if (m_CollectObjects == CollectObjects.All)
		{
			NavMeshBuilder.CollectSources(null, m_LayerMask, m_UseGeometry, m_DefaultArea, list, sources);
		}
		else if (m_CollectObjects == CollectObjects.Children)
		{
			NavMeshBuilder.CollectSources(base.transform, m_LayerMask, m_UseGeometry, m_DefaultArea, list, sources);
		}
		else if (m_CollectObjects == CollectObjects.Volume)
		{
			NavMeshBuilder.CollectSources(GetWorldBounds(Matrix4x4.TRS(base.transform.position, base.transform.rotation, Vector3.one), new Bounds(m_Center, m_Size)), m_LayerMask, m_UseGeometry, m_DefaultArea, list, sources);
		}
		if (m_IgnoreNavMeshAgent)
		{
			sources.RemoveAll((NavMeshBuildSource x) => x.component != null && x.component.gameObject.GetComponent<NavMeshAgent>() != null);
		}
		if (m_IgnoreNavMeshObstacle)
		{
			sources.RemoveAll((NavMeshBuildSource x) => x.component != null && x.component.gameObject.GetComponent<NavMeshObstacle>() != null);
		}
		AppendModifierVolumes(ref sources);
		return sources;
	}

	private static Vector3 Abs(Vector3 v)
	{
		return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
	}

	private static Bounds GetWorldBounds(Matrix4x4 mat, Bounds bounds)
	{
		Vector3 vector = Abs(mat.MultiplyVector(Vector3.right));
		Vector3 vector2 = Abs(mat.MultiplyVector(Vector3.up));
		Vector3 vector3 = Abs(mat.MultiplyVector(Vector3.forward));
		Vector3 vector4 = mat.MultiplyPoint(bounds.center);
		Vector3 vector5 = vector * bounds.size.x + vector2 * bounds.size.y + vector3 * bounds.size.z;
		return new Bounds(vector4, vector5);
	}

	private Bounds CalculateWorldBounds(List<NavMeshBuildSource> sources)
	{
		Matrix4x4 inverse = Matrix4x4.TRS(base.transform.position, base.transform.rotation, Vector3.one).inverse;
		Bounds result = default(Bounds);
		foreach (NavMeshBuildSource source in sources)
		{
			switch (source.shape)
			{
			case NavMeshBuildSourceShape.Mesh:
			{
				Mesh mesh = source.sourceObject as Mesh;
				result.Encapsulate(GetWorldBounds(inverse * source.transform, mesh.bounds));
				break;
			}
			case NavMeshBuildSourceShape.Terrain:
			{
				TerrainData terrainData = source.sourceObject as TerrainData;
				result.Encapsulate(GetWorldBounds(inverse * source.transform, new Bounds(0.5f * terrainData.size, terrainData.size)));
				break;
			}
			case NavMeshBuildSourceShape.Box:
			case NavMeshBuildSourceShape.Sphere:
			case NavMeshBuildSourceShape.Capsule:
			case NavMeshBuildSourceShape.ModifierBox:
				result.Encapsulate(GetWorldBounds(inverse * source.transform, new Bounds(Vector3.zero, source.size)));
				break;
			}
		}
		result.Expand(0.1f);
		return result;
	}

	private bool HasTransformChanged()
	{
		if (m_LastPosition != base.transform.position)
		{
			return true;
		}
		if (m_LastRotation != base.transform.rotation)
		{
			return true;
		}
		return false;
	}

	private void UpdateDataIfTransformChanged()
	{
		if (HasTransformChanged())
		{
			RemoveData();
			AddData();
		}
	}
}
