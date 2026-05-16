using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Unity.AI.Navigation.Tests")]
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
			FilePathsData = new byte[559]
			{
				0, 0, 0, 1, 0, 0, 0, 78, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				97, 105, 46, 110, 97, 118, 105, 103, 97, 116,
				105, 111, 110, 64, 53, 50, 49, 56, 101, 52,
				98, 102, 55, 101, 100, 99, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 72, 101, 108, 112, 85,
				114, 108, 115, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 81, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				117, 110, 105, 116, 121, 46, 97, 105, 46, 110,
				97, 118, 105, 103, 97, 116, 105, 111, 110, 64,
				53, 50, 49, 56, 101, 52, 98, 102, 55, 101,
				100, 99, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 78, 97, 118, 77, 101, 115, 104, 76, 105,
				110, 107, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 92, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 117,
				110, 105, 116, 121, 46, 97, 105, 46, 110, 97,
				118, 105, 103, 97, 116, 105, 111, 110, 64, 53,
				50, 49, 56, 101, 52, 98, 102, 55, 101, 100,
				99, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				78, 97, 118, 77, 101, 115, 104, 76, 105, 110,
				107, 46, 100, 101, 112, 114, 101, 99, 97, 116,
				101, 100, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 85, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 117,
				110, 105, 116, 121, 46, 97, 105, 46, 110, 97,
				118, 105, 103, 97, 116, 105, 111, 110, 64, 53,
				50, 49, 56, 101, 52, 98, 102, 55, 101, 100,
				99, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				78, 97, 118, 77, 101, 115, 104, 77, 111, 100,
				105, 102, 105, 101, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 91, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 117, 110, 105, 116, 121, 46, 97, 105,
				46, 110, 97, 118, 105, 103, 97, 116, 105, 111,
				110, 64, 53, 50, 49, 56, 101, 52, 98, 102,
				55, 101, 100, 99, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 78, 97, 118, 77, 101, 115, 104,
				77, 111, 100, 105, 102, 105, 101, 114, 86, 111,
				108, 117, 109, 101, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 84, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 117, 110, 105, 116, 121, 46, 97, 105, 46,
				110, 97, 118, 105, 103, 97, 116, 105, 111, 110,
				64, 53, 50, 49, 56, 101, 52, 98, 102, 55,
				101, 100, 99, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 78, 97, 118, 77, 101, 115, 104, 83,
				117, 114, 102, 97, 99, 101, 46, 99, 115
			},
			TypesData = new byte[230]
			{
				0, 0, 0, 0, 28, 85, 110, 105, 116, 121,
				46, 65, 73, 46, 78, 97, 118, 105, 103, 97,
				116, 105, 111, 110, 124, 72, 101, 108, 112, 85,
				114, 108, 115, 1, 0, 0, 0, 31, 85, 110,
				105, 116, 121, 46, 65, 73, 46, 78, 97, 118,
				105, 103, 97, 116, 105, 111, 110, 124, 78, 97,
				118, 77, 101, 115, 104, 76, 105, 110, 107, 1,
				0, 0, 0, 31, 85, 110, 105, 116, 121, 46,
				65, 73, 46, 78, 97, 118, 105, 103, 97, 116,
				105, 111, 110, 124, 78, 97, 118, 77, 101, 115,
				104, 76, 105, 110, 107, 0, 0, 0, 0, 35,
				85, 110, 105, 116, 121, 46, 65, 73, 46, 78,
				97, 118, 105, 103, 97, 116, 105, 111, 110, 124,
				78, 97, 118, 77, 101, 115, 104, 77, 111, 100,
				105, 102, 105, 101, 114, 0, 0, 0, 0, 41,
				85, 110, 105, 116, 121, 46, 65, 73, 46, 78,
				97, 118, 105, 103, 97, 116, 105, 111, 110, 124,
				78, 97, 118, 77, 101, 115, 104, 77, 111, 100,
				105, 102, 105, 101, 114, 86, 111, 108, 117, 109,
				101, 0, 0, 0, 0, 34, 85, 110, 105, 116,
				121, 46, 65, 73, 46, 78, 97, 118, 105, 103,
				97, 116, 105, 111, 110, 124, 78, 97, 118, 77,
				101, 115, 104, 83, 117, 114, 102, 97, 99, 101
			},
			TotalFiles = 6,
			TotalTypes = 6,
			IsEditorOnly = false
		};
	}
}
namespace Unity.AI.Navigation;

internal static class HelpUrls
{
	private const string Version = "2.0";

	private const string BaseUrl = "https://docs.unity3d.com/Packages/com.unity.ai.navigation@2.0";

	internal const string Manual = "https://docs.unity3d.com/Packages/com.unity.ai.navigation@2.0/manual/";

	internal const string Api = "https://docs.unity3d.com/Packages/com.unity.ai.navigation@2.0/api/";
}
[ExecuteAlways]
[DefaultExecutionOrder(-101)]
[AddComponentMenu("Navigation/NavMesh Link", 33)]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.ai.navigation@2.0/manual/NavMeshLink.html")]
public class NavMeshLink : MonoBehaviour
{
	[SerializeField]
	[HideInInspector]
	private byte m_SerializedVersion;

	[SerializeField]
	private int m_AgentTypeID;

	[SerializeField]
	private Vector3 m_StartPoint = new Vector3(0f, 0f, -2.5f);

	[SerializeField]
	private Vector3 m_EndPoint = new Vector3(0f, 0f, 2.5f);

	[SerializeField]
	private Transform m_StartTransform;

	[SerializeField]
	private Transform m_EndTransform;

	[SerializeField]
	private bool m_Activated = true;

	[SerializeField]
	private float m_Width;

	[SerializeField]
	[Min(0f)]
	private float m_CostModifier = -1f;

	[SerializeField]
	private bool m_IsOverridingCost;

	[SerializeField]
	private bool m_Bidirectional = true;

	[SerializeField]
	private bool m_AutoUpdatePosition;

	[SerializeField]
	private int m_Area;

	private NavMeshLinkInstance m_LinkInstance;

	private bool m_StartTransformWasEmpty = true;

	private bool m_EndTransformWasEmpty = true;

	private Vector3 m_LastStartWorldPosition = Vector3.positiveInfinity;

	private Vector3 m_LastEndWorldPosition = Vector3.positiveInfinity;

	private Vector3 m_LastPosition = Vector3.positiveInfinity;

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
			if (value != m_AgentTypeID)
			{
				m_AgentTypeID = value;
				UpdateLink();
			}
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
			if (!(value == m_StartPoint))
			{
				m_StartPoint = value;
				UpdateLink();
			}
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
			if (!(value == m_EndPoint))
			{
				m_EndPoint = value;
				UpdateLink();
			}
		}
	}

	public Transform startTransform
	{
		get
		{
			return m_StartTransform;
		}
		set
		{
			if (!(value == m_StartTransform))
			{
				m_StartTransform = value;
				UpdateLink();
			}
		}
	}

	public Transform endTransform
	{
		get
		{
			return m_EndTransform;
		}
		set
		{
			if (!(value == m_EndTransform))
			{
				m_EndTransform = value;
				UpdateLink();
			}
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
			if (!value.Equals(m_Width))
			{
				m_Width = value;
				UpdateLink();
			}
		}
	}

	public float costModifier
	{
		get
		{
			if (!m_IsOverridingCost)
			{
				return 0f - m_CostModifier;
			}
			return m_CostModifier;
		}
		set
		{
			bool flag = value >= 0f;
			if (!value.Equals(costModifier) || flag != m_IsOverridingCost)
			{
				m_IsOverridingCost = flag;
				m_CostModifier = Mathf.Abs(value);
				UpdateLink();
			}
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
			if (value != m_Bidirectional)
			{
				m_Bidirectional = value;
				UpdateLink();
			}
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
			if (value != m_AutoUpdatePosition)
			{
				m_AutoUpdatePosition = value;
				if (m_AutoUpdatePosition)
				{
					AddTracking(this);
				}
				else
				{
					RemoveTracking(this);
				}
			}
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
			if (value != m_Area)
			{
				m_Area = value;
				UpdateLink();
			}
		}
	}

	public bool activated
	{
		get
		{
			return m_Activated;
		}
		set
		{
			m_Activated = value;
			NavMesh.SetLinkActive(m_LinkInstance, m_Activated);
		}
	}

	public bool occupied => NavMesh.IsLinkOccupied(m_LinkInstance);

	[Obsolete("autoUpdatePositions has been deprecated. Use autoUpdate instead. (UnityUpgradable) -> autoUpdate")]
	public bool autoUpdatePositions
	{
		get
		{
			return autoUpdate;
		}
		set
		{
			autoUpdate = value;
		}
	}

	[Obsolete("biDirectional has been deprecated. Use bidirectional instead. (UnityUpgradable) -> bidirectional")]
	public bool biDirectional
	{
		get
		{
			return bidirectional;
		}
		set
		{
			bidirectional = value;
		}
	}

	[Obsolete("costOverride has been deprecated. Use costModifier instead. (UnityUpgradable) -> costModifier")]
	public float costOverride
	{
		get
		{
			return costModifier;
		}
		set
		{
			costModifier = value;
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void ClearTrackedList()
	{
		s_Tracked.Clear();
	}

	private void UpgradeSerializedVersion()
	{
		if (m_SerializedVersion < 1)
		{
			m_SerializedVersion = 1;
			m_IsOverridingCost = m_CostModifier >= 0f;
			m_CostModifier = Mathf.Abs(m_CostModifier);
			if (m_StartTransform == base.gameObject.transform)
			{
				m_StartTransform = null;
			}
			if (m_EndTransform == base.gameObject.transform)
			{
				m_EndTransform = null;
			}
		}
	}

	private void Awake()
	{
		UpgradeSerializedVersion();
	}

	private void OnEnable()
	{
		AddLink();
		if (m_AutoUpdatePosition && NavMesh.IsLinkValid(m_LinkInstance))
		{
			AddTracking(this);
		}
	}

	private void OnDisable()
	{
		RemoveTracking(this);
		NavMesh.RemoveLink(m_LinkInstance);
	}

	public void UpdateLink()
	{
		if (base.isActiveAndEnabled)
		{
			NavMesh.RemoveLink(m_LinkInstance);
			AddLink();
		}
	}

	private static void AddTracking(NavMeshLink link)
	{
		if (s_Tracked.Count == 0)
		{
			NavMesh.onPreUpdate = (NavMesh.OnNavMeshPreUpdate)Delegate.Combine(NavMesh.onPreUpdate, new NavMesh.OnNavMeshPreUpdate(UpdateTrackedInstances));
		}
		s_Tracked.Add(link);
		link.RecordEndpointTransforms();
	}

	private static void RemoveTracking(NavMeshLink link)
	{
		s_Tracked.Remove(link);
		if (s_Tracked.Count == 0)
		{
			NavMesh.onPreUpdate = (NavMesh.OnNavMeshPreUpdate)Delegate.Remove(NavMesh.onPreUpdate, new NavMesh.OnNavMeshPreUpdate(UpdateTrackedInstances));
		}
	}

	internal void GetWorldPositions(out Vector3 worldStartPosition, out Vector3 worldEndPosition)
	{
		bool flag = m_StartTransform == null;
		bool flag2 = m_EndTransform == null;
		Matrix4x4 matrix4x = ((flag || flag2) ? LocalToWorldUnscaled() : Matrix4x4.identity);
		worldStartPosition = (flag ? matrix4x.MultiplyPoint3x4(m_StartPoint) : m_StartTransform.position);
		worldEndPosition = (flag2 ? matrix4x.MultiplyPoint3x4(m_EndPoint) : m_EndTransform.position);
	}

	internal void GetLocalPositions(out Vector3 localStartPosition, out Vector3 localEndPosition)
	{
		bool flag = m_StartTransform == null;
		bool flag2 = m_EndTransform == null;
		Matrix4x4 matrix4x = ((flag && flag2) ? Matrix4x4.identity : LocalToWorldUnscaled().inverse);
		localStartPosition = (flag ? m_StartPoint : matrix4x.MultiplyPoint3x4(m_StartTransform.position));
		localEndPosition = (flag2 ? m_EndPoint : matrix4x.MultiplyPoint3x4(m_EndTransform.position));
	}

	private void AddLink()
	{
		GetLocalPositions(out var localStartPosition, out var localEndPosition);
		NavMeshLinkData link = new NavMeshLinkData
		{
			startPosition = localStartPosition,
			endPosition = localEndPosition,
			width = m_Width,
			costModifier = costModifier,
			bidirectional = m_Bidirectional,
			area = m_Area,
			agentTypeID = m_AgentTypeID
		};
		m_LinkInstance = NavMesh.AddLink(link, base.transform.position, base.transform.rotation);
		if (NavMesh.IsLinkValid(m_LinkInstance))
		{
			NavMesh.SetLinkOwner(m_LinkInstance, this);
			NavMesh.SetLinkActive(m_LinkInstance, m_Activated);
		}
		m_LastPosition = base.transform.position;
		m_LastRotation = base.transform.rotation;
		RecordEndpointTransforms();
		GetWorldPositions(out m_LastStartWorldPosition, out m_LastEndWorldPosition);
	}

	internal void RecordEndpointTransforms()
	{
		m_StartTransformWasEmpty = m_StartTransform == null;
		m_EndTransformWasEmpty = m_EndTransform == null;
	}

	internal bool HaveTransformsChanged()
	{
		bool flag = m_StartTransform == null;
		bool flag2 = m_EndTransform == null;
		if (flag && flag2 && m_StartTransformWasEmpty && m_EndTransformWasEmpty && base.transform.position == m_LastPosition && base.transform.rotation == m_LastRotation)
		{
			return false;
		}
		Matrix4x4 matrix4x = ((flag || flag2) ? LocalToWorldUnscaled() : Matrix4x4.identity);
		if ((flag ? matrix4x.MultiplyPoint3x4(m_StartPoint) : m_StartTransform.position) != m_LastStartWorldPosition)
		{
			return true;
		}
		return (flag2 ? matrix4x.MultiplyPoint3x4(m_EndPoint) : m_EndTransform.position) != m_LastEndWorldPosition;
	}

	internal Matrix4x4 LocalToWorldUnscaled()
	{
		return Matrix4x4.TRS(base.transform.position, base.transform.rotation, Vector3.one);
	}

	private void OnDidApplyAnimationProperties()
	{
		UpdateLink();
	}

	private static void UpdateTrackedInstances()
	{
		foreach (NavMeshLink item in s_Tracked)
		{
			if (item.HaveTransformsChanged())
			{
				item.UpdateLink();
			}
			item.RecordEndpointTransforms();
		}
	}

	[Obsolete("UpdatePositions() has been deprecated. Use UpdateLink() instead. (UnityUpgradable) -> UpdateLink(*)")]
	public void UpdatePositions()
	{
		UpdateLink();
	}
}
[ExecuteAlways]
[DefaultExecutionOrder(-103)]
[AddComponentMenu("Navigation/NavMesh Modifier", 32)]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.ai.navigation@2.0/manual/NavMeshModifier.html")]
public class NavMeshModifier : MonoBehaviour
{
	[SerializeField]
	[HideInInspector]
	private byte m_SerializedVersion;

	[SerializeField]
	private bool m_OverrideArea;

	[SerializeField]
	private int m_Area;

	[SerializeField]
	private bool m_OverrideGenerateLinks;

	[SerializeField]
	private bool m_GenerateLinks;

	[SerializeField]
	private bool m_IgnoreFromBuild;

	[SerializeField]
	private bool m_ApplyToChildren = true;

	[SerializeField]
	private List<int> m_AffectedAgents = new List<int>(new int[1] { -1 });

	private static bool s_RebuildNavMeshModifiers = true;

	private static List<NavMeshModifier> s_NavMeshModifiers = new List<NavMeshModifier>();

	private static readonly HashSet<NavMeshModifier> s_NavMeshModifiersSet = new HashSet<NavMeshModifier>();

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

	public bool overrideGenerateLinks
	{
		get
		{
			return m_OverrideGenerateLinks;
		}
		set
		{
			m_OverrideGenerateLinks = value;
		}
	}

	public bool generateLinks
	{
		get
		{
			return m_GenerateLinks;
		}
		set
		{
			m_GenerateLinks = value;
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

	public bool applyToChildren
	{
		get
		{
			return m_ApplyToChildren;
		}
		set
		{
			m_ApplyToChildren = value;
		}
	}

	public static List<NavMeshModifier> activeModifiers
	{
		get
		{
			if (s_RebuildNavMeshModifiers)
			{
				s_NavMeshModifiers = s_NavMeshModifiersSet.ToList();
				s_RebuildNavMeshModifiers = false;
			}
			return s_NavMeshModifiers;
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void ClearNavMeshModifiers()
	{
		s_NavMeshModifiers.Clear();
		s_NavMeshModifiersSet.Clear();
	}

	private void OnEnable()
	{
		RegisterModifier();
	}

	private void OnDisable()
	{
		UnregisterModifier();
	}

	private void RegisterModifier()
	{
		if (s_NavMeshModifiersSet.Add(this))
		{
			s_RebuildNavMeshModifiers = true;
		}
	}

	private void UnregisterModifier()
	{
		if (s_NavMeshModifiersSet.Remove(this))
		{
			s_RebuildNavMeshModifiers = true;
		}
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
[ExecuteAlways]
[AddComponentMenu("Navigation/NavMesh Modifier Volume", 31)]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.ai.navigation@2.0/manual/NavMeshModifierVolume.html")]
public class NavMeshModifierVolume : MonoBehaviour
{
	[SerializeField]
	[HideInInspector]
	private byte m_SerializedVersion;

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

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void ClearNavMeshModifiers()
	{
		s_NavMeshModifiers.Clear();
	}

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
	[InspectorName("All Game Objects")]
	All,
	[InspectorName("Volume")]
	Volume,
	[InspectorName("Current Object Hierarchy")]
	Children,
	[InspectorName("NavMeshModifier Component Only")]
	MarkedWithModifier
}
[ExecuteAlways]
[DefaultExecutionOrder(-102)]
[AddComponentMenu("Navigation/NavMesh Surface", 30)]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.ai.navigation@2.0/manual/NavMeshSurface.html")]
public class NavMeshSurface : MonoBehaviour
{
	[SerializeField]
	[HideInInspector]
	private byte m_SerializedVersion;

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
	private bool m_GenerateLinks;

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
	private float m_MinRegionArea = 2f;

	[FormerlySerializedAs("m_BakedNavMeshData")]
	[SerializeField]
	private NavMeshData m_NavMeshData;

	[SerializeField]
	private bool m_BuildHeightMesh;

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

	public float minRegionArea
	{
		get
		{
			return m_MinRegionArea;
		}
		set
		{
			m_MinRegionArea = value;
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

	internal NavMeshDataInstance navMeshDataInstance => m_NavMeshDataInstance;

	public static List<NavMeshSurface> activeSurfaces => s_NavMeshSurfaces;

	private Bounds GetInflatedBounds()
	{
		NavMeshBuildSettings settingsByID = NavMesh.GetSettingsByID(m_AgentTypeID);
		float num = ((settingsByID.agentTypeID != -1) ? settingsByID.agentRadius : 0f);
		Bounds result = new Bounds(center, size);
		result.Expand(new Vector3(num, 0f, num));
		return result;
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void ClearNavMeshSurfaces()
	{
		s_NavMeshSurfaces.Clear();
	}

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
			UnityEngine.Debug.LogWarning("No build settings for agent type ID " + agentTypeID, this);
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
		settingsByID.minRegionArea = minRegionArea;
		settingsByID.buildHeightMesh = buildHeightMesh;
		return settingsByID;
	}

	public void BuildNavMesh()
	{
		List<NavMeshBuildSource> sources = CollectSources();
		Bounds localBounds = new Bounds(m_Center, Abs(m_Size));
		if (m_CollectObjects != CollectObjects.Volume)
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

	public UnityEngine.AsyncOperation UpdateNavMesh(NavMeshData data)
	{
		List<NavMeshBuildSource> sources = CollectSources();
		Bounds localBounds = new Bounds(m_Center, Abs(m_Size));
		if (m_CollectObjects != CollectObjects.Volume)
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
					ignoreFromBuild = item.ignoreFromBuild,
					applyToChildren = item.applyToChildren,
					overrideGenerateLinks = item.overrideGenerateLinks,
					generateLinks = item.generateLinks
				});
			}
		}
		switch (m_CollectObjects)
		{
		default:
			CollectSourcesInHierarchy(null, m_LayerMask, m_UseGeometry, m_DefaultArea, m_GenerateLinks, list, includeOnlyMarkedObjects: false, sources);
			break;
		case CollectObjects.Children:
			CollectSourcesInHierarchy(base.transform, m_LayerMask, m_UseGeometry, m_DefaultArea, m_GenerateLinks, list, includeOnlyMarkedObjects: false, sources);
			break;
		case CollectObjects.Volume:
		{
			Bounds worldBounds = GetWorldBounds(Matrix4x4.TRS(base.transform.position, base.transform.rotation, Vector3.one), GetInflatedBounds());
			CollectSourcesInVolume(worldBounds, m_LayerMask, m_UseGeometry, m_DefaultArea, m_GenerateLinks, list, includeOnlyMarkedObjects: false, sources);
			break;
		}
		case CollectObjects.MarkedWithModifier:
			CollectSourcesInHierarchy(null, m_LayerMask, m_UseGeometry, m_DefaultArea, m_GenerateLinks, list, includeOnlyMarkedObjects: true, sources);
			break;
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

	private void CollectSourcesInVolume(Bounds includedWorldBounds, int includedLayerMask, NavMeshCollectGeometry geometry, int areaByDefault, bool generateLinksByDefault, List<NavMeshBuildMarkup> markups, bool includeOnlyMarkedObjects, List<NavMeshBuildSource> results)
	{
		NavMeshBuilder.CollectSources(includedWorldBounds, includedLayerMask, geometry, areaByDefault, generateLinksByDefault, markups, includeOnlyMarkedObjects, results);
	}

	private void CollectSourcesInHierarchy(Transform root, int includedLayerMask, NavMeshCollectGeometry geometry, int areaByDefault, bool generateLinksByDefault, List<NavMeshBuildMarkup> markups, bool includeOnlyMarkedObjects, List<NavMeshBuildSource> results)
	{
		NavMeshBuilder.CollectSources(root, includedLayerMask, geometry, areaByDefault, generateLinksByDefault, markups, includeOnlyMarkedObjects, results);
	}
}
