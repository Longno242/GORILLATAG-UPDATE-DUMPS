using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using CustomMapSupport;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: Preserve]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = ".NET Standard 2.1")]
[assembly: AssemblyCompany("GT_CustomMapSupportRuntime")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0+f62584c1cc7ed35093cade5ffebac0a220824e3b")]
[assembly: AssemblyProduct("GT_CustomMapSupportRuntime")]
[assembly: AssemblyTitle("GT_CustomMapSupportRuntime")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: RefSafetyRules(11)]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute(byte P_0)
		{
			NullableFlags = new byte[1] { P_0 };
		}

		public NullableAttribute(byte[] P_0)
		{
			NullableFlags = P_0;
		}
	}
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableContextAttribute : Attribute
	{
		public readonly byte Flag;

		public NullableContextAttribute(byte P_0)
		{
			Flag = P_0;
		}
	}
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Module, AllowMultiple = false, Inherited = false)]
	internal sealed class RefSafetyRulesAttribute : Attribute
	{
		public readonly int Version;

		public RefSafetyRulesAttribute(int P_0)
		{
			Version = P_0;
		}
	}
}
namespace CustomMapSupport
{
	public static class Bezier
	{
		public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
		{
			t = Mathf.Clamp01(t);
			float num = 1f - t;
			return num * num * p0 + 2f * num * t * p1 + t * t * p2;
		}

		public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, float t)
		{
			return 2f * (1f - t) * (p1 - p0) + 2f * t * (p2 - p1);
		}

		public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			t = Mathf.Clamp01(t);
			float num = 1f - t;
			return num * num * num * p0 + 3f * num * num * t * p1 + 3f * num * t * t * p2 + t * t * t * p3;
		}

		public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			t = Mathf.Clamp01(t);
			float num = 1f - t;
			return 3f * num * num * (p1 - p0) + 6f * num * t * (p2 - p1) + 3f * t * t * (p3 - p2);
		}
	}
	public enum BezierControlPointMode
	{
		Free,
		Aligned,
		Mirrored
	}
	public class BezierSpline : MonoBehaviour
	{
		public Vector3[]? points;

		public BezierControlPointMode[]? modes;

		public bool loop;

		private float _totalArcLength;

		private float[]? _timesTable;

		private float[]? _lengthsTable;

		public bool Loop
		{
			get
			{
				return loop;
			}
			set
			{
				loop = value;
				if (value)
				{
					if (modes != null)
					{
						modes[modes.Length - 1] = modes[0];
					}
					if (points != null)
					{
						SetControlPoint(0, points[0]);
					}
				}
			}
		}

		public int ControlPointCount
		{
			get
			{
				Vector3[]? array = points;
				if (array == null)
				{
					return 0;
				}
				return array.Length;
			}
		}

		public int CurveCount
		{
			get
			{
				if (points != null)
				{
					return (points.Length - 1) / 3;
				}
				return 0;
			}
		}

		private void Awake()
		{
			float num = 0f;
			for (int i = 1; i < points?.Length; i++)
			{
				num += (points[i] - points[i - 1]).magnitude;
			}
			int subdivisions = Mathf.RoundToInt(num / 0.1f);
			buildTimesLengthsTables(subdivisions);
		}

		private void buildTimesLengthsTables(int subdivisions)
		{
			_totalArcLength = 0f;
			float num = 1f / (float)subdivisions;
			_timesTable = new float[subdivisions];
			_lengthsTable = new float[subdivisions];
			Vector3 b = GetPoint(0f);
			for (int i = 1; i <= subdivisions; i++)
			{
				float num2 = num * (float)i;
				Vector3 point = GetPoint(num2);
				_totalArcLength += Vector3.Distance(point, b);
				b = point;
				_timesTable[i - 1] = num2;
				_lengthsTable[i - 1] = _totalArcLength;
			}
		}

		private float getPathFromTime(float t)
		{
			if (float.IsNaN(_totalArcLength) || _totalArcLength == 0f)
			{
				return t;
			}
			if (t > 0f && t < 1f)
			{
				float num = _totalArcLength * t;
				float num2 = 0f;
				float num3 = 0f;
				float num4 = 0f;
				float num5 = 0f;
				for (int i = 0; i < _lengthsTable?.Length; i++)
				{
					if (_lengthsTable[i] > num)
					{
						num4 = ((_timesTable == null) ? 0f : _timesTable[i]);
						num5 = _lengthsTable[i];
						if (i > 0)
						{
							num3 = _lengthsTable[i - 1];
						}
						break;
					}
					num2 = ((_timesTable == null) ? 0f : _timesTable[i]);
				}
				t = num2 + (num - num3) / (num5 - num3) * (num4 - num2);
			}
			if (t > 1f)
			{
				t = 1f;
			}
			else if (t < 0f)
			{
				t = 0f;
			}
			return t;
		}

		public Vector3[]? GetControlPoints()
		{
			return points;
		}

		public BezierControlPointMode[]? GetControlPointModes()
		{
			return modes;
		}

		public Vector3 GetControlPoint(int index)
		{
			if (points == null)
			{
				return Vector3.zero;
			}
			return points[index];
		}

		public void SetControlPoint(int index, Vector3 point)
		{
			if (points == null || points.Length <= index)
			{
				return;
			}
			if (index % 3 == 0)
			{
				Vector3 vector = point - points[index];
				if (loop)
				{
					if (index == 0)
					{
						points[1] += vector;
						points[points.Length - 2] += vector;
						points[points.Length - 1] = point;
					}
					else if (index == points.Length - 1)
					{
						points[0] = point;
						points[1] += vector;
						points[index - 1] += vector;
					}
					else
					{
						points[index - 1] += vector;
						points[index + 1] += vector;
					}
				}
				else
				{
					if (index > 0)
					{
						points[index - 1] += vector;
					}
					if (index + 1 < points.Length)
					{
						points[index + 1] += vector;
					}
				}
			}
			points[index] = point;
			EnforceMode(index);
		}

		public BezierControlPointMode GetControlPointMode(int index)
		{
			if (modes == null)
			{
				return BezierControlPointMode.Free;
			}
			return modes[(index + 1) / 3];
		}

		public void SetControlPointMode(int index, BezierControlPointMode mode)
		{
			if (modes == null)
			{
				return;
			}
			int num = (index + 1) / 3;
			modes[num] = mode;
			if (loop)
			{
				if (num == 0)
				{
					modes[modes.Length - 1] = mode;
				}
				else if (num == modes.Length - 1)
				{
					modes[0] = mode;
				}
			}
			EnforceMode(index);
		}

		private void EnforceMode(int index)
		{
			if (modes == null || points == null)
			{
				return;
			}
			int num = (index + 1) / 3;
			BezierControlPointMode bezierControlPointMode = modes[num];
			if (bezierControlPointMode == BezierControlPointMode.Free || (!loop && (num == 0 || num == modes.Length - 1)))
			{
				return;
			}
			int num2 = num * 3;
			int num3;
			int num4;
			if (index <= num2)
			{
				num3 = num2 - 1;
				if (num3 < 0)
				{
					num3 = points.Length - 2;
				}
				num4 = num2 + 1;
				if (num4 >= points.Length)
				{
					num4 = 1;
				}
			}
			else
			{
				num3 = num2 + 1;
				if (num3 >= points.Length)
				{
					num3 = 1;
				}
				num4 = num2 - 1;
				if (num4 < 0)
				{
					num4 = points.Length - 2;
				}
			}
			Vector3 vector = points[num2];
			Vector3 vector2 = vector - points[num3];
			if (bezierControlPointMode == BezierControlPointMode.Aligned)
			{
				vector2 = vector2.normalized * Vector3.Distance(vector, points[num4]);
			}
			points[num4] = vector + vector2;
		}

		public Vector3 GetPoint(float t, bool ConstantVelocity)
		{
			if (ConstantVelocity)
			{
				return GetPoint(getPathFromTime(t));
			}
			return GetPoint(t);
		}

		public Vector3 GetPoint(float t)
		{
			if (points == null)
			{
				return Vector3.zero;
			}
			int num;
			if (t >= 1f)
			{
				t = 1f;
				num = points.Length - 4;
			}
			else
			{
				t = Mathf.Clamp01(t) * (float)CurveCount;
				num = (int)t;
				t -= (float)num;
				num *= 3;
			}
			return base.transform.TransformPoint(Bezier.GetPoint(points[num], points[num + 1], points[num + 2], points[num + 3], t));
		}

		public Vector3 GetPointLocal(float t)
		{
			if (points == null)
			{
				return Vector3.zero;
			}
			int num;
			if (t >= 1f)
			{
				t = 1f;
				num = points.Length - 4;
			}
			else
			{
				t = Mathf.Clamp01(t) * (float)CurveCount;
				num = (int)t;
				t -= (float)num;
				num *= 3;
			}
			return Bezier.GetPoint(points[num], points[num + 1], points[num + 2], points[num + 3], t);
		}

		private Vector3 GetVelocity(float t)
		{
			if (points == null)
			{
				return Vector3.zero;
			}
			int num;
			if (t >= 1f)
			{
				t = 1f;
				num = points.Length - 4;
			}
			else
			{
				t = Mathf.Clamp01(t) * (float)CurveCount;
				num = (int)t;
				t -= (float)num;
				num *= 3;
			}
			return base.transform.TransformPoint(Bezier.GetFirstDerivative(points[num], points[num + 1], points[num + 2], points[num + 3], t)) - base.transform.position;
		}

		public Vector3 GetDirection(float t, bool ConstantVelocity)
		{
			if (ConstantVelocity)
			{
				return GetDirection(getPathFromTime(t));
			}
			return GetDirection(t);
		}

		public Vector3 GetDirection(float t)
		{
			return GetVelocity(t).normalized;
		}

		public void AddCurve()
		{
			if (modes != null && points != null)
			{
				Vector3 vector = points[points.Length - 1];
				Array.Resize(ref points, points.Length + 3);
				vector.x += 1f;
				points[points.Length - 3] = vector;
				vector.x += 1f;
				points[points.Length - 2] = vector;
				vector.x += 1f;
				points[points.Length - 1] = vector;
				Array.Resize(ref modes, modes.Length + 1);
				modes[modes.Length - 1] = modes[modes.Length - 2];
				EnforceMode(points.Length - 4);
				if (loop)
				{
					points[points.Length - 1] = points[0];
					modes[modes.Length - 1] = modes[0];
					EnforceMode(0);
				}
			}
		}

		public void RemoveLastCurve()
		{
			if (modes != null && points != null && points.Length > 4)
			{
				Array.Resize(ref points, points.Length - 3);
				Array.Resize(ref modes, modes.Length - 1);
			}
		}

		public void RemoveCurve(int index)
		{
			if (modes != null && points != null && points.Length > 4)
			{
				List<Vector3> list = points.ToList();
				int i;
				for (i = 4; i < points.Length && index - 3 > i; i += 3)
				{
				}
				for (int j = 0; j < 3; j++)
				{
					list.RemoveAt(i);
				}
				points = list.ToArray();
				int index2 = (i - 4) / 3;
				List<BezierControlPointMode> list2 = modes.ToList();
				list2.RemoveAt(index2);
				modes = list2.ToArray();
			}
		}

		public void Reset()
		{
			points = new Vector3[4]
			{
				new Vector3(0f, -1f, 0f),
				new Vector3(0f, -1f, 2f),
				new Vector3(0f, -1f, 4f),
				new Vector3(0f, -1f, 6f)
			};
			modes = new BezierControlPointMode[2];
		}
	}
}
namespace GT_CustomMapSupportRuntime
{
	public class AccessDoorPlaceholder : MonoBehaviour
	{
	}
	public enum AgentBehaviours
	{
		Search,
		Chase,
		Attack,
		Count
	}
	public enum AttackType
	{
		Tag,
		UseGT,
		UseLuau
	}
	public enum NavAgentType
	{
		Humanoid,
		Small,
		Medium,
		Large
	}
	public class AIAgent : MapEntity
	{
		[HideInInspector]
		[Obsolete("Use MapEntity.entityTypeId instead")]
		public byte enemyTypeId;

		[Tooltip("\"NavAgentType\" determines how the NavAgent will interact with the NavMesh.\nCheck the settings for each Nav Agent type in the \"Window > AI > Navigation\" window on the \"Agents\" tab to determine which agent type best fits your Agent.\nEnsure your Scene contains a baked navmesh for the corresponding agent type.\n\nPlease note that any changes to the values for the agent types as well as the addition of any new agent types will be ignored once your map is loaded in-game")]
		public NavAgentType navAgentType;

		[Tooltip("\"MovementSpeed\" determines the max movement speed of the agent.")]
		public float movementSpeed;

		[Tooltip("\"Acceleration\" determines how quickly the agent can get to max speed.")]
		public float acceleration;

		[Tooltip("\"TurnSpeed\" determines how quickly the agent can turn.")]
		public float turnSpeed;

		[Tooltip("If checked, this agent can target players who have already been tagged in non-custom game modes. If unchecked, this agent will NOT target tagged players in non-custom game modes.")]
		public bool allowTargetingTaggedPlayers;

		[Tooltip("\"SightOffset\" determines from what point raycasts will begin. It is the offset from the position of the AIAgent's transform.")]
		public Vector3 sightOffset;

		[Tooltip("\"SightFOV\" is the field of view for the agent when searching for players. 360 max")]
		[Range(0f, 360f)]
		public float sightFOV;

		[Tooltip("\"SightDist\" determines how close a player must be to the agent before it will consider them as a target.")]
		public float sightDist;

		[Tooltip("\"LoseSightDist\" sets the distance at which an agent will lose sight of a player and stop targeting them.")]
		public float loseSightDist;

		[Tooltip("If checked, this agent will continue moving to their chase target's last known position.\nIf unchecked, this agent will stop moving as soon as it loses sight of their chase target.")]
		public bool rememberLoseSightPosition = true;

		[Tooltip("\"StopDist\" sets how close an agent will come to a player when chasing.\nSetting this too small may result in players getting stuck inside agent colliders.\"")]
		public float stopDist;

		[Tooltip("\"AttackType\" Determines how a hit from this Agent will be handled.\nTag - Agent won't deal damage to players when attacking and will Tag them instead. In the Custom Game Mode this will send the \"taggedByAI\" event to your Luau script.\nUseGT - Will deal damage to players using GT's built-in systems. Allows you to make use of GT's health, death, and revive systems.\nUseLuau - Sends the \"playerHit\" event to Luau with the damage amount. Allows you to determine what happens with damage, but you won't be able to use GT's built-in systems")]
		public AttackType attackType;

		[Tooltip("\"AttackDist\" is the distance at which an agent will start attacking a player.")]
		public float attackDist;

		[Tooltip("If checked, the Attack behavior will be driven by Trigger colliders attached to this Agent.\n The design intention for these colliders is that they are small and attached to the \"damaging\" parts of your agent like their hands or weapon. If they are too big, attacking may not work as expected.\n\n If unchecked, the Attack behavior will be driven solely by the target being within the specified Attack Distance.")]
		public bool useColliders;

		[Tooltip("If checked, this Agent will immediately stop moving when starting an attack. If unchecked, the Agent will finish it's active move request while it starts attacking.")]
		public bool stopMovingToAttack;

		[Tooltip("\"DamageAmount\" is how much damage the agent does per attack")]
		public float damageAmount;

		[Tooltip("\"TimeBetweenAttacks\" is how much time (in seconds) should there be between attacks.")]
		public float timeBetweenAttacks;

		[Tooltip("\"AttackAnimName\" is the name of the Attack state in the Animation Controller(s) that will be activated when the agent attacks.")]
		public string attackAnimName = "Attack";

		[Tooltip("\"AnimBlendTime\" is how much time (in seconds) it should take to blend into the Attack animation.\nSetting this to 0 means the Animation Controller(s) will immediately switch to the Attackanimation state\"")]
		public float animBlendTime;

		[Tooltip("\"DamageDelayAfterPlayingAnim\" is how much time (in seconds) to delay the attack damage event after starting the attack animation. This is only used if \"UseColliders\" is unchecked. This is useful when your attack animation contains a long windup.")]
		public float damageDelayAfterPlayingAnim;

		[Tooltip("The \"AgentBehaviours\" list determines what behaviours an agent will use and what priority each behaviour is be given.\n\nPriority is based of index in the list. If the first behaviour in the list can execute, all behaviours after it will be skipped.\n\nOnly one instance of a behaviour will be used, any duplicates will be ignored.\n\nLeaving this empty will result in the agent doing nothing unless specifically told by a LUAU script.\"")]
		public List<AgentBehaviours> agentBehaviours = new List<AgentBehaviours>();

		[Obsolete("Use MapEntity.lua_EntityID instead")]
		public short lua_AgentID;

		private static List<AgentBehaviours> validateBehaviors = new List<AgentBehaviours>();

		private static List<int> invalidEntries = new List<int>();

		public void OnValidate()
		{
			if (agentBehaviours.Count > 3)
			{
				agentBehaviours.RemoveRange(3, agentBehaviours.Count - 3);
			}
			try
			{
				validateBehaviors.Clear();
				invalidEntries.Clear();
				if (agentBehaviours.Count == 0)
				{
					return;
				}
				for (int i = 0; i < agentBehaviours.Count; i++)
				{
					if (!validateBehaviors.Contains(agentBehaviours[i]))
					{
						validateBehaviors.Add(agentBehaviours[i]);
					}
					else
					{
						invalidEntries.Add(i);
					}
				}
				foreach (int invalidEntry in invalidEntries)
				{
					for (int j = 0; j < 3; j++)
					{
						if (!validateBehaviors.Contains((AgentBehaviours)j))
						{
							agentBehaviours[invalidEntry] = (AgentBehaviours)j;
							validateBehaviors.Add(agentBehaviours[invalidEntry]);
							break;
						}
					}
				}
			}
			catch (Exception message)
			{
				UnityEngine.Debug.Log(message);
			}
		}

		public override long GetPackedCreateData()
		{
			bool hasInstance = AISpawnManager.HasInstance;
			return (long)(hasInstance ? enemyTypeId : entityTypeId) + (long)((hasInstance ? lua_AgentID : lua_EntityID) << 8);
		}

		public static void UnpackCreateData(long data, out byte entityTypeID, out short luaAgentID)
		{
			entityTypeID = (byte)(data & 0xFF);
			luaAgentID = (short)((data >> 8) & 0xFFFF);
		}
	}
	public class AISpawnManager : MonoBehaviour
	{
		private Dictionary<int, GameObject> enemyTypes = new Dictionary<int, GameObject>(64);

		public static AISpawnManager? instance;

		private static bool hasInstance;

		private Dictionary<string, AISpawnPoint> spawnPoints = new Dictionary<string, AISpawnPoint>(128);

		public static bool HasInstance => hasInstance;

		private void Awake()
		{
			if (instance != null)
			{
				UnityEngine.Object.Destroy(this);
				return;
			}
			instance = this;
			hasInstance = true;
			GetEnemyTypeTemplates();
			FindSpawnPoints();
		}

		public void FindSpawnPoints()
		{
			spawnPoints.Clear();
			AISpawnPoint[] array = UnityEngine.Object.FindObjectsByType<AISpawnPoint>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
			for (int i = 0; i < array.Length; i++)
			{
				spawnPoints.Add(array[i].spawnID, array[i]);
			}
		}

		public bool GetSpawnPoint(string spawnPointID, out AISpawnPoint spawnPoint)
		{
			if (!spawnPoints.TryGetValue(spawnPointID, out spawnPoint))
			{
				return false;
			}
			return true;
		}

		public bool GetEnemyType(int enemyTypeIndex, out GameObject? newEnemy)
		{
			if (!enemyTypes.ContainsKey(enemyTypeIndex))
			{
				newEnemy = null;
				return false;
			}
			newEnemy = enemyTypes[enemyTypeIndex];
			return true;
		}

		public bool SpawnEnemy(string spawnPointID, int enemyTypeIndex, out AIAgent? newEnemy)
		{
			if (!enemyTypes.ContainsKey(enemyTypeIndex))
			{
				UnityEngine.Debug.Log("AISpawnManager::SpawnEnemy enemy index incorrect");
				newEnemy = null;
				return false;
			}
			if (!spawnPoints.TryGetValue(spawnPointID, out AISpawnPoint value))
			{
				UnityEngine.Debug.Log("AISpawnManager::SpawnEnemy Can't find spawn point");
				newEnemy = null;
				return false;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(enemyTypes[enemyTypeIndex], value.transform);
			value.spawnCount++;
			newEnemy = gameObject.GetComponent<AIAgent>();
			return true;
		}

		public bool SpawnEnemy(int enemyTypeIndex, out AIAgent? newEnemy)
		{
			if (!enemyTypes.ContainsKey(enemyTypeIndex))
			{
				UnityEngine.Debug.Log("AISpawnManager::SpawnEnemy enemy index incorrect");
				newEnemy = null;
				return false;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(enemyTypes[enemyTypeIndex]);
			newEnemy = gameObject.GetComponent<AIAgent>();
			return true;
		}

		private void GetEnemyTypeTemplates()
		{
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				AIAgent component = child.GetComponent<AIAgent>();
				if (!(component == null) && component.isTemplate)
				{
					child.gameObject.SetActive(value: false);
					enemyTypes[component.enemyTypeId] = child.gameObject;
				}
			}
		}
	}
	public class AISpawnPoint : MonoBehaviour
	{
		public string spawnID = "";

		public int spawnCount;
	}
	public static class CMSExtensions
	{
		public static string GetHierarchyPath(this Transform transform)
		{
			string text = transform.name;
			while ((bool)transform.parent)
			{
				transform = transform.parent;
				text = transform.name + "/" + text;
			}
			return "/" + text;
		}

		public static string GetHierarchyPath(this Transform transform, int maxDepth)
		{
			string text = transform.name;
			int num = 0;
			while ((bool)transform.parent && num < maxDepth)
			{
				transform = transform.parent;
				text = transform.name + "/" + text;
				num++;
			}
			return "/" + text;
		}

		public static string GetHierarchyPath(this Transform transform, Transform stopper)
		{
			string text = transform.name;
			while ((bool)transform.parent && transform.parent != stopper)
			{
				transform = transform.parent;
				text = transform.name + "/" + text;
			}
			return "/" + text;
		}

		public static string GetHierarchyPath(this GameObject gameObject)
		{
			return gameObject.transform.GetHierarchyPath();
		}

		public static string GetHierarchyPath(this GameObject gameObject, int limit)
		{
			return gameObject.transform.GetHierarchyPath(limit);
		}

		public static string[] GetHierarchyPaths(this GameObject[] gobj)
		{
			string[] array = new string[gobj.Length];
			for (int i = 0; i < gobj.Length; i++)
			{
				array[i] = gobj[i].GetHierarchyPath();
			}
			return array;
		}

		public static string[] GetHierarchyPaths(this Transform[] xform)
		{
			string[] array = new string[xform.Length];
			for (int i = 0; i < xform.Length; i++)
			{
				array[i] = xform[i].GetHierarchyPath();
			}
			return array;
		}

		public static T? GetComponentByHierarchyPath<T>(this GameObject root, string path) where T : Component
		{
			string[] array = path.Split(new string[1] { "/->/" }, StringSplitOptions.None);
			if (array.Length < 2)
			{
				return null;
			}
			string[] array2 = array[0].Split(new string[1] { "/" }, StringSplitOptions.RemoveEmptyEntries);
			Transform transform = root.transform;
			for (int i = 1; i < array2.Length; i++)
			{
				string n = array2[i];
				transform = transform.Find(n);
				if (transform == null)
				{
					return null;
				}
			}
			Type type = Type.GetType(array[1].Split('#')[0]);
			if (type == null)
			{
				return null;
			}
			Component component = transform.GetComponent(type);
			if (component == null)
			{
				return null;
			}
			return component as T;
		}

		public static int GetHierarchyDepth(this Transform xform)
		{
			int num = 0;
			Transform parent = xform.parent;
			while (parent != null)
			{
				num++;
				parent = parent.parent;
			}
			return num;
		}
	}
	public class CMSZoneShaderSettings : MonoBehaviour
	{
		public enum EOverrideMode
		{
			LeaveUnchanged,
			ApplyNewValue,
			ApplyDefaultValue
		}

		public enum ETextureOverrideType
		{
			Default,
			Custom
		}

		public struct CMSZoneShaderProperties
		{
			public bool isInitialized;

			public Color groundFogColor;

			public float groundFogDepthFadeSize;

			public Transform? groundFogHeightPlane;

			public float groundFogHeight;

			public float groundFogHeightFadeSize;

			public int zoneLiquidType;

			public int liquidShape;

			public float liquidShapeRadius;

			public Transform? liquidBottomTransform;

			public float zoneLiquidUVScale;

			public Color underwaterTintColor;

			public Color underwaterFogColor;

			public Vector4 underwaterFogParams;

			public Vector4 underwaterCausticsParams;

			public Texture2D? underwaterCausticsTexture;

			public Vector2 underwaterEffectsDistanceToSurfaceFade;

			public Texture2D? liquidResidueTex;

			public Transform? mainWaterSurfacePlane;

			public float zoneWeatherMapDissolveProgress;

			public float GroundFogHeightFade => 1f / Mathf.Max(1E-05f, groundFogHeightFadeSize);
		}

		public enum EZoneLiquidType
		{
			None,
			Water,
			Lava
		}

		public enum ELiquidShape
		{
			Plane,
			Cylinder
		}

		[NonSerialized]
		public Collider[]? edZoneColliders;

		[NonSerialized]
		public bool edWasInitialized;

		public static bool isInitialized;

		public static CMSZoneShaderSettings? defaultsInstance;

		public static bool hasDefaultsInstance;

		public static CMSZoneShaderSettings? activeInstance;

		public static bool hasActiveInstance;

		public bool isExported;

		[Tooltip("Set this to true for cases like it is the first CMSZoneShaderSettings that should be activated when a scene is loaded.")]
		public bool activateOnLoad;

		[Tooltip("These values will be used as the default global values that will be fallen back to when not in a zone and that the other scripts will reference.")]
		public bool isDefaultValues;

		public bool applyGroundFog;

		private static readonly int groundFogColor_shaderProp = Shader.PropertyToID("_ZoneGroundFogColor");

		public EOverrideMode groundFogColor_overrideMode;

		public Color groundFogColor = new Color(0.7f, 0.9f, 1f, 1f);

		private static readonly int groundFogDepthFadeSq_shaderProp = Shader.PropertyToID("_ZoneGroundFogDepthFadeSq");

		public EOverrideMode groundFogDepthFade_overrideMode;

		public float groundFogDepthFadeSize = 20f;

		private static readonly int groundFogHeight_shaderProp = Shader.PropertyToID("_ZoneGroundFogHeight");

		public EOverrideMode groundFogHeight_overrideMode;

		public Transform? groundFogHeightPlane;

		public float groundFogHeight = 7.45f;

		private static readonly int groundFogHeightFade_shaderProp = Shader.PropertyToID("_ZoneGroundFogHeightFade");

		public EOverrideMode groundFogHeightFade_overrideMode;

		public float groundFogHeightFadeSize = 20f;

		public bool applyLiquidEffects;

		public EOverrideMode zoneLiquidType_overrideMode;

		public EZoneLiquidType zoneLiquidType = EZoneLiquidType.Water;

		private static EZoneLiquidType liquidType_previousValue = EZoneLiquidType.None;

		public EOverrideMode liquidShape_overrideMode;

		public ELiquidShape liquidShape;

		private static ELiquidShape liquidShape_previousValue = ELiquidShape.Plane;

		public EOverrideMode liquidShapeRadius_overrideMode;

		public float liquidShapeRadius = 1f;

		private static float liquidShapeRadius_previousValue;

		private bool hasLiquidBottomTransform;

		public EOverrideMode liquidBottomTransform_overrideMode;

		public Transform? liquidBottomTransform;

		private float liquidBottomPosY_previousValue;

		private static readonly int shaderParam_GlobalZoneLiquidUVScale = Shader.PropertyToID("_GlobalZoneLiquidUVScale");

		public EOverrideMode zoneLiquidUVScale_overrideMode;

		public float zoneLiquidUVScale = 0.01f;

		private static readonly int shaderParam_GlobalWaterTintColor = Shader.PropertyToID("_GlobalWaterTintColor");

		public EOverrideMode underwaterTintColor_overrideMode;

		public Color underwaterTintColor = new Color(0.3f, 0.65f, 1f, 0.2f);

		private static readonly int shaderParam_GlobalUnderwaterFogColor = Shader.PropertyToID("_GlobalUnderwaterFogColor");

		public EOverrideMode underwaterFogColor_overrideMode;

		public Color underwaterFogColor = new Color(0.12f, 0.41f, 0.77f);

		private static readonly int shaderParam_GlobalUnderwaterFogParams = Shader.PropertyToID("_GlobalUnderwaterFogParams");

		public EOverrideMode underwaterFogParams_overrideMode;

		public float underwaterFogStart = -5f;

		public float underwaterFogDistance = 40f;

		[Tooltip("Fog params are: start, distance (end - start), unused, unused")]
		public Vector4 underwaterFogParams = new Vector4(-5f, 40f, 0f, 0f);

		private static readonly int shaderParam_GlobalUnderwaterCausticsParams = Shader.PropertyToID("_GlobalUnderwaterCausticsParams");

		public EOverrideMode underwaterCausticsParams_overrideMode;

		public float underwaterCausticsSpeed = 0.075f;

		public float underwaterCausticsScale = 0.075f;

		[Tooltip("Caustics params are: Speed, Scale, Alpha, unused")]
		public Vector4 underwaterCausticsParams = new Vector4(0.075f, 0.075f, 1f, 0f);

		public static readonly int shaderParam_GlobalUnderwaterCausticsTex = Shader.PropertyToID("_GlobalUnderwaterCausticsTex");

		public EOverrideMode underwaterCausticsTexture_overrideMode;

		public ETextureOverrideType underwaterCausticsTextureOverrideType;

		public Texture2D? underwaterCausticsTexture;

		private static readonly int shaderParam_GlobalUnderwaterEffectsDistanceToSurfaceFade = Shader.PropertyToID("_GlobalUnderwaterEffectsDistanceToSurfaceFade");

		public EOverrideMode underwaterEffectsDistanceToSurfaceFade_overrideMode;

		[Range(0.0001f, 50f)]
		public float underwaterFogDistanceToSurfaceFadeMinimum = 0.0001f;

		[Range(0.0001f, 50f)]
		public float underwaterFogDistanceToSurfaceFadeMaximum = 50f;

		public Vector2 underwaterEffectsDistanceToSurfaceFade = new Vector2(0.0001f, 50f);

		private const string kEdTooltip_liquidResidueTex = "This is used for things like the charred surface effect when lava burns static geo.";

		public static readonly int shaderParam_GlobalLiquidResidueTex = Shader.PropertyToID("_GlobalLiquidResidueTex");

		[Tooltip("This is used for things like the charred surface effect when lava burns static geo.")]
		public EOverrideMode liquidResidueTex_overrideMode;

		public ETextureOverrideType liquidResidueTextureOverrideType;

		[Tooltip("This is used for things like the charred surface effect when lava burns static geo.")]
		public Texture2D? liquidResidueTex;

		private readonly int shaderParam_GlobalMainWaterSurfacePlane = Shader.PropertyToID("_GlobalMainWaterSurfacePlane");

		public bool hasMainWaterSurfacePlane;

		public bool hasDynamicWaterSurfacePlane;

		public EOverrideMode mainWaterSurfacePlane_overrideMode;

		public Transform? mainWaterSurfacePlane;

		private static readonly int shaderParam_ZoneWeatherMapDissolveProgress = Shader.PropertyToID("_ZoneWeatherMapDissolveProgress");

		public EOverrideMode zoneWeatherMapDissolveProgress_overrideMode;

		[Range(0f, 1f)]
		public float zoneWeatherMapDissolveProgress = 1f;

		public bool isActiveInstance => activeInstance == this;

		public float GroundFogDepthFadeSq => 1f / Mathf.Max(1E-05f, groundFogDepthFadeSize * groundFogDepthFadeSize);

		public float GroundFogHeightFade => 1f / Mathf.Max(1E-05f, groundFogHeightFadeSize);

		private static int shaderParam_ZoneLiquidPosRadiusSq { get; set; } = Shader.PropertyToID("_ZoneLiquidPosRadiusSq");

		public int GetGroundFogColorOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)groundFogColor_overrideMode;
		}

		public int GetGroundFogDepthFadeOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)groundFogDepthFade_overrideMode;
		}

		public int GetGroundFogHeightOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)groundFogHeight_overrideMode;
		}

		public int GetGroundFogHeightFadeOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)groundFogHeightFade_overrideMode;
		}

		public void SetZoneLiquidTypeKeywordEnum(EZoneLiquidType liquidType)
		{
			if (!isExported)
			{
				if (liquidType == EZoneLiquidType.None)
				{
					Shader.EnableKeyword("_GLOBAL_ZONE_LIQUID_TYPE__NONE");
				}
				else
				{
					Shader.DisableKeyword("_GLOBAL_ZONE_LIQUID_TYPE__NONE");
				}
				if (liquidType == EZoneLiquidType.Water)
				{
					Shader.EnableKeyword("_GLOBAL_ZONE_LIQUID_TYPE__WATER");
				}
				else
				{
					Shader.DisableKeyword("_GLOBAL_ZONE_LIQUID_TYPE__WATER");
				}
				if (liquidType == EZoneLiquidType.Lava)
				{
					Shader.EnableKeyword("_GLOBAL_ZONE_LIQUID_TYPE__LAVA");
				}
				else
				{
					Shader.DisableKeyword("_GLOBAL_ZONE_LIQUID_TYPE__LAVA");
				}
			}
		}

		public int GetZoneLiquidTypeOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)zoneLiquidType_overrideMode;
		}

		public int GetZoneLiquidType()
		{
			return (int)zoneLiquidType;
		}

		public void SetZoneLiquidShapeKeywordEnum(ELiquidShape shape)
		{
			if (!isExported)
			{
				if (shape == ELiquidShape.Plane)
				{
					Shader.EnableKeyword("_ZONE_LIQUID_SHAPE__PLANE");
				}
				else
				{
					Shader.DisableKeyword("_ZONE_LIQUID_SHAPE__PLANE");
				}
				if (shape == ELiquidShape.Cylinder)
				{
					UnityEngine.Debug.Log("Enable CYLINDER liquid...");
					Shader.EnableKeyword("_ZONE_LIQUID_SHAPE__CYLINDER");
				}
				else
				{
					Shader.DisableKeyword("_ZONE_LIQUID_SHAPE__CYLINDER");
				}
			}
		}

		public int GetLiquidShapeOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)liquidShape_overrideMode;
		}

		public int GetZoneLiquidShape()
		{
			return (int)liquidShape;
		}

		public int GetLiquidShapeRadiusOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)liquidShapeRadius_overrideMode;
		}

		public int GetLiquidBottomTransformOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)liquidBottomTransform_overrideMode;
		}

		public static float GetWaterY()
		{
			if (!(activeInstance == null) && !(activeInstance.mainWaterSurfacePlane == null))
			{
				return activeInstance.mainWaterSurfacePlane.position.y;
			}
			return -1f;
		}

		public int GetZoneLiquidUVScaleOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)zoneLiquidUVScale_overrideMode;
		}

		public int GetUnderwaterTintColorOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)underwaterTintColor_overrideMode;
		}

		public int GetUnderwaterFogColorOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)underwaterFogColor_overrideMode;
		}

		public int GetUnderwaterFogParamsOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)underwaterFogParams_overrideMode;
		}

		public int GetUnderwaterCausticsParamsOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)underwaterCausticsParams_overrideMode;
		}

		public int GetUnderwaterCausticsTextureOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)underwaterCausticsTexture_overrideMode;
		}

		public int GetUnderwaterEffectsDistanceToSurfaceFadeOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)underwaterEffectsDistanceToSurfaceFade_overrideMode;
		}

		public int GetLiquidResidueTextureOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)liquidResidueTex_overrideMode;
		}

		public int GetMainWaterSurfacePlaneOverrideMode()
		{
			if (isDefaultValues)
			{
				return 1;
			}
			return (int)mainWaterSurfacePlane_overrideMode;
		}

		public void Initialize()
		{
			if (!isExported)
			{
				if (mainWaterSurfacePlane == null)
				{
					hasMainWaterSurfacePlane = false;
					hasDynamicWaterSurfacePlane = false;
				}
				else
				{
					hasMainWaterSurfacePlane = mainWaterSurfacePlane_overrideMode == EOverrideMode.ApplyNewValue || isDefaultValues;
					hasDynamicWaterSurfacePlane = hasMainWaterSurfacePlane && !mainWaterSurfacePlane.gameObject.isStatic;
				}
				hasLiquidBottomTransform = liquidBottomTransform != null && (liquidBottomTransform_overrideMode == EOverrideMode.ApplyNewValue || isDefaultValues);
				CheckDefaultsInstance();
				if (activateOnLoad)
				{
					BecomeActiveInstance();
				}
			}
		}

		protected void OnDestroy()
		{
			if (!isExported)
			{
				if (defaultsInstance == this)
				{
					hasDefaultsInstance = false;
				}
				if (activeInstance == this)
				{
					hasActiveInstance = false;
				}
			}
		}

		private void UpdateMainPlaneShaderProperty()
		{
			if (isExported)
			{
				return;
			}
			Transform transform = null;
			if (hasMainWaterSurfacePlane && (mainWaterSurfacePlane_overrideMode == EOverrideMode.ApplyNewValue || isDefaultValues))
			{
				transform = mainWaterSurfacePlane;
			}
			else if (mainWaterSurfacePlane_overrideMode == EOverrideMode.ApplyDefaultValue && defaultsInstance != null && defaultsInstance.hasMainWaterSurfacePlane)
			{
				transform = defaultsInstance.mainWaterSurfacePlane;
			}
			if (!(transform == null))
			{
				Vector3 position = transform.position;
				Vector3 up = transform.up;
				float w = 0f - Vector3.Dot(up, position);
				Shader.SetGlobalVector(shaderParam_GlobalMainWaterSurfacePlane, new Vector4(up.x, up.y, up.z, w));
				ELiquidShape eLiquidShape = (liquidShape_previousValue = ((liquidShape_overrideMode == EOverrideMode.ApplyNewValue || isDefaultValues) ? liquidShape : ((liquidShape_overrideMode != EOverrideMode.ApplyDefaultValue || !(defaultsInstance != null)) ? liquidShape_previousValue : defaultsInstance.liquidShape)));
				float y = (liquidBottomPosY_previousValue = (((liquidBottomTransform_overrideMode == EOverrideMode.ApplyNewValue || isDefaultValues) && liquidBottomTransform != null) ? liquidBottomTransform.position.y : ((liquidBottomTransform_overrideMode != EOverrideMode.ApplyDefaultValue || !(defaultsInstance != null) || !(defaultsInstance.liquidBottomTransform != null)) ? liquidBottomPosY_previousValue : defaultsInstance.liquidBottomTransform.position.y)));
				float num = ((liquidShapeRadius_overrideMode == EOverrideMode.ApplyNewValue || isDefaultValues) ? liquidShapeRadius : ((liquidShape_overrideMode != EOverrideMode.ApplyDefaultValue || !(defaultsInstance != null)) ? liquidShapeRadius_previousValue : defaultsInstance.liquidShapeRadius));
				if (eLiquidShape == ELiquidShape.Cylinder)
				{
					UnityEngine.Debug.Log("Setting Cylinder Liquid Radius...");
					Shader.SetGlobalVector(shaderParam_ZoneLiquidPosRadiusSq, new Vector4(position.x, y, position.z, num * num));
					liquidShapeRadius_previousValue = num;
				}
			}
		}

		private void CheckDefaultsInstance()
		{
			if (isExported || !isDefaultValues)
			{
				return;
			}
			if (hasDefaultsInstance && defaultsInstance != null && defaultsInstance != this)
			{
				if (!Application.isPlaying)
				{
					UnityEngine.Debug.LogWarning("CMSZoneShaderSettings: (Edit time warning) Deactivating instance with `isDefaultValues` set to true. CMSZoneShaderSettings Object: " + base.name, this);
					base.gameObject.SetActive(value: false);
					return;
				}
				string hierarchyPath = defaultsInstance.transform.GetHierarchyPath();
				UnityEngine.Debug.LogError("CMSZoneShaderSettings: Destroying conflicting defaults instance.\n- keeping: \"" + hierarchyPath + "\"\n- destroying (this): \"" + base.transform.GetHierarchyPath() + "\"", this);
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else
			{
				defaultsInstance = this;
				hasDefaultsInstance = true;
				BecomeActiveInstance();
			}
		}

		public void BecomeActiveInstance(bool force = false)
		{
			if (!isExported && (!(activeInstance == this) || force))
			{
				ApplyValues();
				activeInstance = this;
				hasActiveInstance = true;
			}
		}

		public static void ActivateDefaultSettings()
		{
			if (defaultsInstance != null)
			{
				defaultsInstance.BecomeActiveInstance();
			}
		}

		public void SetGroundFogValue(Color fogColor, float fogDepthFade, float fogHeight, float fogHeightFade)
		{
			if (!isExported)
			{
				groundFogColor_overrideMode = EOverrideMode.ApplyNewValue;
				groundFogColor = fogColor;
				groundFogDepthFade_overrideMode = EOverrideMode.ApplyNewValue;
				groundFogDepthFadeSize = fogDepthFade;
				groundFogHeight_overrideMode = EOverrideMode.ApplyNewValue;
				groundFogHeight = fogHeight;
				groundFogHeightFade_overrideMode = EOverrideMode.ApplyNewValue;
				groundFogHeightFadeSize = fogHeightFade;
				BecomeActiveInstance(force: true);
			}
		}

		private void ApplyValues()
		{
			if (isExported || defaultsInstance == null)
			{
				return;
			}
			if (!applyGroundFog)
			{
				ApplyColor(groundFogColor_shaderProp, groundFogColor_overrideMode, new Color(0f, 0f, 0f, 0f), defaultsInstance.groundFogColor);
			}
			else
			{
				ApplyColor(groundFogColor_shaderProp, groundFogColor_overrideMode, groundFogColor, defaultsInstance.groundFogColor);
				ApplyFloat(groundFogDepthFadeSq_shaderProp, groundFogDepthFade_overrideMode, GroundFogDepthFadeSq, defaultsInstance.GroundFogDepthFadeSq);
				if (groundFogHeightPlane != null)
				{
					groundFogHeight = groundFogHeightPlane.position.y;
				}
				ApplyFloat(groundFogHeight_shaderProp, groundFogHeight_overrideMode, groundFogHeight, defaultsInstance.groundFogHeight);
				ApplyFloat(groundFogHeightFade_shaderProp, groundFogHeightFade_overrideMode, GroundFogHeightFade, defaultsInstance.GroundFogHeightFade);
			}
			if (!applyLiquidEffects)
			{
				SetZoneLiquidTypeKeywordEnum(EZoneLiquidType.None);
				SetZoneLiquidShapeKeywordEnum(ELiquidShape.Plane);
				ApplyColor(shaderParam_GlobalWaterTintColor, underwaterTintColor_overrideMode, new Color(0f, 0f, 0f, 0f), defaultsInstance.underwaterTintColor);
				ApplyColor(shaderParam_GlobalUnderwaterFogColor, underwaterFogColor_overrideMode, new Color(0f, 0f, 0f, 0f), defaultsInstance.underwaterFogColor);
				ApplyTexture(shaderParam_GlobalLiquidResidueTex, liquidResidueTex_overrideMode, null, defaultsInstance.liquidResidueTex);
				Shader.SetGlobalVector(shaderParam_GlobalMainWaterSurfacePlane, new Vector4(0f, 1f, 0f, 10000f));
			}
			else
			{
				if (zoneLiquidType_overrideMode != EOverrideMode.LeaveUnchanged || isDefaultValues)
				{
					EZoneLiquidType eZoneLiquidType = ((zoneLiquidType_overrideMode == EOverrideMode.ApplyNewValue) ? zoneLiquidType : defaultsInstance.zoneLiquidType);
					if (eZoneLiquidType != liquidType_previousValue || !isInitialized)
					{
						SetZoneLiquidTypeKeywordEnum(eZoneLiquidType);
						liquidType_previousValue = eZoneLiquidType;
					}
				}
				UnityEngine.Debug.Log("Applying Liquid Shape...");
				if (liquidShape_overrideMode != EOverrideMode.LeaveUnchanged || isDefaultValues)
				{
					UnityEngine.Debug.Log("Override Mode != LeaveUnchanged");
					ELiquidShape eLiquidShape = ((liquidShape_overrideMode == EOverrideMode.ApplyNewValue) ? liquidShape : defaultsInstance.liquidShape);
					if (eLiquidShape != liquidShape_previousValue || !isInitialized)
					{
						UnityEngine.Debug.Log("Set Liquid Shape...");
						SetZoneLiquidShapeKeywordEnum(eLiquidShape);
						liquidShape_previousValue = eLiquidShape;
					}
					else
					{
						UnityEngine.Debug.Log("Same liquid shape AND already initialized");
					}
				}
				ApplyFloat(shaderParam_GlobalZoneLiquidUVScale, zoneLiquidUVScale_overrideMode, zoneLiquidUVScale, defaultsInstance.zoneLiquidUVScale);
				ApplyColor(shaderParam_GlobalWaterTintColor, underwaterTintColor_overrideMode, underwaterTintColor, defaultsInstance.underwaterTintColor);
				ApplyColor(shaderParam_GlobalUnderwaterFogColor, underwaterFogColor_overrideMode, underwaterFogColor, defaultsInstance.underwaterFogColor);
				ApplyVector(shaderParam_GlobalUnderwaterFogParams, underwaterFogParams_overrideMode, underwaterFogParams, defaultsInstance.underwaterFogParams);
				ApplyVector(shaderParam_GlobalUnderwaterCausticsParams, underwaterCausticsParams_overrideMode, underwaterCausticsParams, defaultsInstance.underwaterCausticsParams);
				ApplyTexture(shaderParam_GlobalUnderwaterCausticsTex, underwaterCausticsTexture_overrideMode, underwaterCausticsTexture, defaultsInstance.underwaterCausticsTexture);
				ApplyVector(shaderParam_GlobalUnderwaterEffectsDistanceToSurfaceFade, underwaterEffectsDistanceToSurfaceFade_overrideMode, underwaterEffectsDistanceToSurfaceFade, defaultsInstance.underwaterEffectsDistanceToSurfaceFade);
				ApplyTexture(shaderParam_GlobalLiquidResidueTex, liquidResidueTex_overrideMode, liquidResidueTex, defaultsInstance.liquidResidueTex);
				ApplyFloat(shaderParam_ZoneWeatherMapDissolveProgress, zoneWeatherMapDissolveProgress_overrideMode, zoneWeatherMapDissolveProgress, defaultsInstance.zoneWeatherMapDissolveProgress);
				UpdateMainPlaneShaderProperty();
			}
			isInitialized = true;
		}

		public void RefreshValues()
		{
			if (!isExported)
			{
				if (mainWaterSurfacePlane == null)
				{
					hasMainWaterSurfacePlane = false;
					hasDynamicWaterSurfacePlane = false;
				}
				else
				{
					hasMainWaterSurfacePlane = mainWaterSurfacePlane_overrideMode == EOverrideMode.ApplyNewValue || isDefaultValues;
					hasDynamicWaterSurfacePlane = hasMainWaterSurfacePlane && !mainWaterSurfacePlane.gameObject.isStatic;
				}
				hasLiquidBottomTransform = liquidBottomTransform != null && (liquidBottomTransform_overrideMode == EOverrideMode.ApplyNewValue || isDefaultValues);
			}
		}

		private void ApplyColor(int shaderProp, EOverrideMode overrideMode, Color value, Color defaultValue)
		{
			if (!isExported)
			{
				if (overrideMode == EOverrideMode.ApplyNewValue || isDefaultValues)
				{
					Shader.SetGlobalColor(shaderProp, value.linear);
				}
				else if (overrideMode == EOverrideMode.ApplyDefaultValue)
				{
					Shader.SetGlobalColor(shaderProp, defaultValue.linear);
				}
			}
		}

		private void ApplyFloat(int shaderProp, EOverrideMode overrideMode, float value, float defaultValue)
		{
			if (!isExported)
			{
				if (overrideMode == EOverrideMode.ApplyNewValue || isDefaultValues)
				{
					Shader.SetGlobalFloat(shaderProp, value);
				}
				else if (overrideMode == EOverrideMode.ApplyDefaultValue)
				{
					Shader.SetGlobalFloat(shaderProp, defaultValue);
				}
			}
		}

		private void ApplyVector(int shaderProp, EOverrideMode overrideMode, Vector2 value, Vector2 defaultValue)
		{
			if (!isExported)
			{
				if (overrideMode == EOverrideMode.ApplyNewValue || isDefaultValues)
				{
					Shader.SetGlobalVector(shaderProp, value);
				}
				else if (overrideMode == EOverrideMode.ApplyDefaultValue)
				{
					Shader.SetGlobalVector(shaderProp, defaultValue);
				}
			}
		}

		private void ApplyVector(int shaderProp, EOverrideMode overrideMode, Vector3 value, Vector3 defaultValue)
		{
			if (!isExported)
			{
				if (overrideMode == EOverrideMode.ApplyNewValue || isDefaultValues)
				{
					Shader.SetGlobalVector(shaderProp, value);
				}
				else if (overrideMode == EOverrideMode.ApplyDefaultValue)
				{
					Shader.SetGlobalVector(shaderProp, defaultValue);
				}
			}
		}

		private void ApplyVector(int shaderProp, EOverrideMode overrideMode, Vector4 value, Vector4 defaultValue)
		{
			if (!isExported)
			{
				if (overrideMode == EOverrideMode.ApplyNewValue || isDefaultValues)
				{
					Shader.SetGlobalVector(shaderProp, value);
				}
				else if (overrideMode == EOverrideMode.ApplyDefaultValue)
				{
					Shader.SetGlobalVector(shaderProp, defaultValue);
				}
			}
		}

		public void ApplyTexture(int shaderProp, EOverrideMode overrideMode, Texture2D? value, Texture2D? defaultValue)
		{
			if (!isExported)
			{
				if (overrideMode == EOverrideMode.ApplyNewValue || isDefaultValues)
				{
					Shader.SetGlobalTexture(shaderProp, value);
				}
				else if (overrideMode == EOverrideMode.ApplyDefaultValue)
				{
					Shader.SetGlobalTexture(shaderProp, defaultValue);
				}
			}
		}

		public CMSZoneShaderProperties GetProperties()
		{
			return new CMSZoneShaderProperties
			{
				groundFogColor = groundFogColor,
				groundFogDepthFadeSize = groundFogDepthFadeSize,
				groundFogHeightPlane = groundFogHeightPlane,
				groundFogHeight = groundFogHeight,
				groundFogHeightFadeSize = groundFogDepthFadeSize,
				zoneLiquidType = GetZoneLiquidType(),
				liquidShape = GetZoneLiquidShape(),
				liquidShapeRadius = liquidShapeRadius,
				liquidBottomTransform = liquidBottomTransform,
				zoneLiquidUVScale = zoneLiquidUVScale,
				underwaterTintColor = underwaterTintColor,
				underwaterFogColor = underwaterFogColor,
				underwaterFogParams = underwaterFogParams,
				underwaterCausticsParams = underwaterCausticsParams,
				underwaterCausticsTexture = underwaterCausticsTexture,
				underwaterEffectsDistanceToSurfaceFade = underwaterEffectsDistanceToSurfaceFade,
				liquidResidueTex = liquidResidueTex,
				mainWaterSurfacePlane = mainWaterSurfacePlane,
				zoneWeatherMapDissolveProgress = zoneWeatherMapDissolveProgress,
				isInitialized = true
			};
		}
	}
	public class Constants
	{
		public enum CMSGameModeType
		{
			Casual,
			Infection,
			HuntDown,
			Paintbrawl,
			Ambush,
			FreezeTag,
			Ghost,
			Custom,
			Count
		}

		public static readonly int customMapSupportVersion = 5;

		public static readonly int minRopeLength = 3;

		public static readonly int maxRopeLength = 31;

		public static readonly int storeATMLimit = 1;

		public static readonly int atmCreatorCodeSizeLimit = 10;

		public static readonly int storeDisplayStandLimit = 12;

		public static readonly int storeCheckoutCounterLimit = 2;

		public static readonly int storeTryOnConsoleLimit = 2;

		public static readonly int storeTryOnAreaLimit = 2;

		public static readonly float storeTryOnAreaVolumeLimit = 64f;

		public static readonly float minTeleportDistFromStorePlaceholder = 2f;

		public static readonly int aiAgentLimit = 100;

		public static readonly int leafGliderLimit = 16;

		public static readonly Vector3 AccessDoorWorldPosition = new Vector3(0f, -11.098f, 2.9295f);

		public static readonly List<Type> componentAllowList = new List<Type>
		{
			typeof(MeshRenderer),
			typeof(Transform),
			typeof(MeshFilter),
			typeof(MeshRenderer),
			typeof(Collider),
			typeof(BoxCollider),
			typeof(SphereCollider),
			typeof(CapsuleCollider),
			typeof(MeshCollider),
			typeof(Light),
			typeof(ReflectionProbe),
			typeof(AudioSource),
			typeof(Animator),
			typeof(SkinnedMeshRenderer),
			typeof(TextMesh),
			typeof(ParticleSystem),
			typeof(ParticleSystemRenderer),
			typeof(RectTransform),
			typeof(SpriteRenderer),
			typeof(BillboardRenderer),
			typeof(Canvas),
			typeof(CanvasRenderer),
			typeof(Rigidbody),
			typeof(TrailRenderer),
			typeof(LineRenderer),
			typeof(Camera),
			typeof(NavMesh),
			typeof(NavMeshAgent),
			typeof(NavMeshObstacle),
			typeof(HingeJoint),
			typeof(ConstantForce),
			typeof(LODGroup),
			typeof(MapDescriptor),
			typeof(AccessDoorPlaceholder),
			typeof(MapOrientationPoint),
			typeof(SurfaceOverrideSettings),
			typeof(TeleporterSettings),
			typeof(TagZoneSettings),
			typeof(LuauTriggerSettings),
			typeof(MapBoundarySettings),
			typeof(ObjectActivationTriggerSettings),
			typeof(LoadZoneSettings),
			typeof(GTObjectPlaceholder),
			typeof(CMSZoneShaderSettings),
			typeof(ZoneShaderTriggerSettings),
			typeof(MultiPartFire),
			typeof(HandHoldSettings),
			typeof(CustomMapEjectButtonSettings),
			typeof(BezierSpline),
			typeof(UberShaderDynamicLight),
			typeof(MapEntity),
			typeof(GrabbableEntity),
			typeof(AIAgent),
			typeof(AISpawnManager),
			typeof(MapSpawnPoint),
			typeof(MapSpawnManager),
			typeof(AISpawnPoint),
			typeof(RopeSwingSegment),
			typeof(ZiplineSegment),
			typeof(PlayAnimationTriggerSettings),
			typeof(SurfaceMoverSettings),
			typeof(MovingSurfaceSettings),
			typeof(CustomMapReviveStation)
		};

		public static readonly List<string> componentTypeStringAllowList = new List<string>
		{
			"UniversalAdditionalLightData", "BakerySkyLight", "BakeryDirectLight", "BakeryPointLight", "ftLightmapsStorage", "BakeryAlwaysRender", "BakeryLightMesh", "BakeryLightmapGroupSelector", "BakeryPackAsSingleSquare", "BakerySector",
			"BakeryVolume", "BakeryLightmapGroup", "ProBuilderMesh", "TMP_Text", "TMPro.TextMeshPro", "TMPro.TextMeshProUGUI", "UnityEngine.UI.CanvasScaler", "UnityEngine.UI.GraphicRaycaster", "UnityEngine.Halo", "UnityEngine.Rendering.LensFlareComponentSRP",
			"UnityEngine.Rendering.Universal.UniversalAdditionalCameraData", "Unity.AI.Navigation.NavMeshModifier", "Unity.AI.Navigation.NavMeshSurface", "Unity.AI.Navigation.NavMeshSurfaceVolume", "Unity.AI.Navigation.NavMeshLink"
		};

		public static readonly List<string> componentTypeStringsToStripPreExport = new List<string> { "ProBuilderShape", "PolyShape", "InspectorNote" };
	}
	public class CustomMapEjectButtonSettings : MonoBehaviour
	{
		public enum EjectType
		{
			EjectFromVirtualStump,
			ReturnToVirtualStump
		}

		public EjectType ejectType;
	}
	public class CustomMapReviveStation : MonoBehaviour
	{
		[Tooltip("Sets the SFX, if any, that play when a player is revived.")]
		public AudioSource? audioSource;

		[Tooltip("Sets the particle effects, if any, that play when a player is revived.")]
		public ParticleSystem[]? particleEffects;

		[Tooltip("How long (in seconds) before the revive station can be used again. A value of 0 means it can always be used")]
		public double reviveCooldownSeconds;
	}
	[Preserve]
	public class Descriptor
	{
		[JsonProperty(PropertyName = "objectName")]
		public string objectName = "";

		[JsonConstructor]
		public Descriptor()
		{
		}
	}
	public class GrabbableEntity : MapEntity
	{
		public AudioSource? audioSource;

		public AudioClip? catchSound;

		public float catchSoundVolume;

		public AudioClip? throwSound;

		public float throwSoundVolume;

		public override long GetPackedCreateData()
		{
			return (long)entityTypeId + (long)(lua_EntityID << 8);
		}

		public static void UnpackCreateData(long data, out byte entityTypeID, out short luaAgentID)
		{
			entityTypeID = (byte)(data & 0xFF);
			luaAgentID = (short)((data >> 8) & 0xFFFF);
		}
	}
	public enum GTObject
	{
		LeafGlider,
		GliderWindVolume,
		WaterVolume,
		ForceVolume,
		ATM,
		HoverboardArea,
		HoverboardDispenser,
		RopeSwing,
		ZipLine,
		Store_DisplayStand,
		Store_TryOnArea,
		Store_Checkout,
		Store_TryOnConsole
	}
	public struct ForceVolumeProperties
	{
		public float accel;

		public float maxDepth;

		public float maxSpeed;

		public bool disableGrip;

		public bool dampenLateralVelocity;

		public float dampenXVel;

		public float dampenZVel;

		public bool applyPullToCenterAcceleration;

		public float pullToCenterAccel;

		public float pullToCenterMaxSpeed;

		public float pullToCenterMinDistance;

		public AudioClip? enterClip;

		public AudioClip? exitClip;

		public AudioClip? loopClip;

		public AudioClip? loopCrescendoClip;
	}
	public struct GliderWindVolumeProperties
	{
		public float maxSpeed;

		public float maxAccel;

		public AnimationCurve speedVsAccelCurve;

		public Vector3 localWindDirection;
	}
	public struct WaterVolumeProperties
	{
		public Transform? surfacePlane;

		public List<MeshCollider> surfaceColliders;

		public CMSZoneShaderSettings.EZoneLiquidType liquidType;
	}
	public class GTObjectPlaceholder : MonoBehaviour
	{
		public enum ECustomMapCosmeticItem
		{
			Item_A,
			Item_B,
			Item_C,
			Item_D,
			Item_E,
			Item_F,
			Item_G,
			Item_H,
			Item_I,
			Item_J,
			Item_K,
			Item_L
		}

		public GTObject PlaceholderObject;

		public bool useDefaultPlaceholder = true;

		public bool useCustomMesh;

		public float maxDistanceBeforeRespawn = 180f;

		public float maxSpeed = 30f;

		public float maxAccel = 15f;

		public AnimationCurve SpeedVSAccelCurve = AnimationCurve.Linear(0f, 1f, 1f, 0f);

		public Vector3 localWindDirection = Vector3.up;

		public bool useWaterMesh = true;

		public float scrollTextureX;

		public float scrollTextureY;

		public float scaleTexture = 20f;

		[Tooltip("Transform for your flat Water Surface Plane. Y-Axis should point towards the Top of the water")]
		public Transform? surfacePlane;

		[Tooltip("Put any mesh colliders here that are used for your Water Surface if they aren't flat and aligned with the surfacePlane Transform")]
		public List<MeshCollider> surfaceColliders = new List<MeshCollider>();

		[Tooltip("Type of liquid for this Water Volume. This will also determine the Splash Effects that are used.")]
		public CMSZoneShaderSettings.EZoneLiquidType liquidType = CMSZoneShaderSettings.EZoneLiquidType.Water;

		[Tooltip("How fast to accelerate to the max speed of the Force Volume.\n\nExample: An acceleration of 10 would get to a max speed of 50 over 5 seconds.")]
		[Range(0f, 120f)]
		public float accel_FV;

		[Tooltip("Max depth towards the center of the volume before forcing closing velocity to 0 (-1 to not use max depth)")]
		[Range(-1f, 100f)]
		public float maxDepth_FV = -1f;

		[Tooltip("Maximum speed, in meters per second, the player can move along the direction of the volume's Y-Axis.")]
		[Range(0f, 120f)]
		public float maxSpeed_FV;

		[Tooltip("If true, all surfaces become maximum slippery while in the force volume")]
		public bool disableGrip_FV;

		public bool dampenLatVel_FV = true;

		[Tooltip("Dampen current velocity on the X axis")]
		[Range(0f, 100f)]
		public float dampenXVel_FV;

		[Tooltip("Dampen current velocity on the Z axis")]
		[Range(0f, 100f)]
		public float dampenZVel_FV;

		[Tooltip("If true, pulls player to center of the volume (towards Y-Axis)")]
		public bool applyPull_FV = true;

		[Range(0f, 500f)]
		public float pullToCenterAccel_FV;

		[Range(0f, 500f)]
		public float pullToCenterMaxSpeed_FV;

		[Tooltip("The Minimum distance before the centering force is applied")]
		[Range(0.0001f, 0.5f)]
		public float pullToCenterMinDist_FV = 0.1f;

		public AudioClip? enterClip;

		public AudioClip? exitClip;

		public AudioClip? loopClip;

		public AudioClip? loopCrescendoClip;

		[Tooltip("Creator Code that is pre-filled on this specific ATM")]
		public string defaultCreatorCode = "";

		[Range(3f, 31f)]
		public int ropeLength = 3;

		public GameObject? ropeSwingSegmentPrefab;

		public float ropeSegmentGenerationOffset = 1f;

		public List<RopeSwingSegment> ropeSwingSegments = new List<RopeSwingSegment>();

		public BezierSpline? spline;

		public GameObject? ziplineSegmentPrefab;

		public float ziplineSegmentGenerationOffset = 0.92f;

		public List<ZiplineSegment> ziplineSegments = new List<ZiplineSegment>();

		public ECustomMapCosmeticItem CosmeticItem;

		public WaterVolumeProperties GetWaterVolumeProperties()
		{
			return new WaterVolumeProperties
			{
				surfacePlane = surfacePlane,
				surfaceColliders = surfaceColliders,
				liquidType = liquidType
			};
		}

		public ForceVolumeProperties GetForceVolumeProperties()
		{
			return new ForceVolumeProperties
			{
				accel = accel_FV,
				maxSpeed = maxSpeed_FV,
				maxDepth = maxDepth_FV,
				disableGrip = disableGrip_FV,
				dampenLateralVelocity = dampenLatVel_FV,
				dampenXVel = dampenXVel_FV,
				dampenZVel = dampenZVel_FV,
				applyPullToCenterAcceleration = applyPull_FV,
				pullToCenterAccel = pullToCenterAccel_FV,
				pullToCenterMaxSpeed = pullToCenterMaxSpeed_FV,
				pullToCenterMinDistance = pullToCenterMinDist_FV,
				enterClip = enterClip,
				exitClip = exitClip,
				loopClip = loopClip,
				loopCrescendoClip = loopCrescendoClip
			};
		}

		public void SetForceVolumeProperties(ForceVolumeProperties props)
		{
			accel_FV = props.accel;
			maxSpeed_FV = props.maxSpeed;
			maxDepth_FV = props.maxDepth;
			disableGrip_FV = props.disableGrip;
			dampenLatVel_FV = props.dampenLateralVelocity;
			dampenXVel_FV = props.dampenXVel;
			dampenZVel_FV = props.dampenZVel;
			applyPull_FV = props.applyPullToCenterAcceleration;
			pullToCenterAccel_FV = props.pullToCenterAccel;
			pullToCenterMaxSpeed_FV = props.pullToCenterMaxSpeed;
			pullToCenterMinDist_FV = props.pullToCenterMinDistance;
			enterClip = props.enterClip;
			exitClip = props.exitClip;
			loopClip = props.loopClip;
			loopCrescendoClip = props.loopCrescendoClip;
		}
	}
	[RequireComponent(typeof(Collider))]
	[DisallowMultipleComponent]
	public class HandHoldSettings : MonoBehaviour
	{
		public enum HandSnapMethod
		{
			None,
			SnapToCenterPoint,
			SnapToNearestEdge,
			SnapToXAxisPoint,
			SnapToYAxisPoint,
			SnapToZAxisPoint
		}

		public HandSnapMethod handSnapMethod;

		public bool rotatePlayerWhenHeld;

		[Tooltip("If TRUE, players will be able to perform the Grab action before their hand collides with this HandHold and it will still be grabbed once their hand comes in contact with the HandHold. If FALSE, players must perform the Grab action while their hand is already near the HandHold for it to be grabbed.")]
		public bool allowPreGrab;
	}
	[RequireComponent(typeof(BoxCollider))]
	[DisallowMultipleComponent]
	public class LoadZoneSettings : MonoBehaviour
	{
		public bool useDynamicLighting;

		public Color UberShaderAmbientDynamicLight = Color.black;

		public List<string> scenesToLoad = new List<string>();

		public List<string> scenesToUnload = new List<string>();
	}
	[RequireComponent(typeof(Collider))]
	public class LuauTriggerSettings : TriggerSettings
	{
		[Tooltip("Should this Trigger sync to all players, or only be processed for the person who triggered it?\nLuau Triggers generally shouldn't need to do this, but doing so will sync it's internal TriggerCount to all players.")]
		public bool syncedToAllPlayers;

		public override void PropagateProperties()
		{
			syncedToAllPlayers_private = syncedToAllPlayers;
		}
	}
	[DisallowMultipleComponent]
	public class MapBoundarySettings : TriggerSettings
	{
		[Tooltip("Should this Trigger sync to all players, or only be processed for the person who triggered it?\nMapBoundary triggers generally shouldn't need to do this, but doing so will sync it's internal TriggerCount to all players.")]
		public bool syncedToAllPlayers;

		[Tooltip("Teleport points used to return the player to the map. Chosen at random.")]
		[SerializeField]
		public List<Transform> TeleportPoints = new List<Transform>();

		[Tooltip("Should the player get Tagged when they hit this Boundary?")]
		public bool ShouldTagPlayer = true;

		public override void PropagateProperties()
		{
			syncedToAllPlayers_private = syncedToAllPlayers;
		}
	}
	public enum ExportLightingType
	{
		Default_Unity,
		Alternative,
		Off
	}
	public struct VirtualStumpReturnWatchProps
	{
		public float holdDuration;

		public bool shouldTagPlayer;

		public bool shouldKickPlayer;

		public bool infectionOverride;

		public float holdDuration_Infection;

		public bool shouldTagPlayer_Infection;

		public bool shouldKickPlayer_Infection;

		public bool customModeOverride;

		public float holdDuration_Custom;

		public bool shouldTagPlayer_CustomMode;

		public bool shouldKickPlayer_CustomMode;
	}
	[DisallowMultipleComponent]
	public class MapDescriptor : MonoBehaviour
	{
		[Obsolete("Moved to Map Export Settings")]
		public bool IsInitialScene;

		[Obsolete("Moved to Map Export Settings")]
		public bool DisableHoldingHandsAllGameModes;

		[Obsolete("Moved to Map Export Settings")]
		public bool DisableHoldingHandsCustomOnly;

		[Obsolete("Moved to Map Export Settings")]
		public float watchHoldDuration = 0.5f;

		[Obsolete("Moved to Map Export Settings")]
		public bool watchShouldTagPlayer;

		[Obsolete("Moved to Map Export Settings")]
		public bool watchShouldKickPlayer;

		[Obsolete("Moved to Map Export Settings")]
		public bool watchInfectionOverride;

		[Obsolete("Moved to Map Export Settings")]
		public float watchHoldDuration_Infection = 0.5f;

		[Obsolete("Moved to Map Export Settings")]
		public bool watchShouldTagPlayer_Infection;

		[Obsolete("Moved to Map Export Settings")]
		public bool watchShouldKickPlayer_Infection;

		[Obsolete("Moved to Map Export Settings")]
		public bool watchCustomModeOverride;

		[Obsolete("Moved to Map Export Settings")]
		public float watchHoldDuration_CustomMode = 0.5f;

		[Obsolete("Moved to Map Export Settings")]
		public bool watchShouldTagPlayer_CustomMode;

		[Obsolete("Moved to Map Export Settings")]
		public bool watchShouldKickPlayer_CustomMode;

		[Obsolete("Moved to Map Export Settings")]
		public bool UseUberShaderDynamicLighting;

		[Obsolete("Moved to Map Export Settings")]
		public Color UberShaderAmbientDynamicLight = Color.black;

		[Obsolete("Moved to Map Export Settings")]
		public TextAsset? CustomGamemode;

		[Obsolete("Moved to Map Export Settings")]
		public bool DevMode;

		[Obsolete("Moved to Map Export Settings")]
		public int MaxPlayers = 10;

		public const float MIN_DIAMETER = 1000f;

		public const float MAX_DIAMETER = 50000f;

		[Tooltip("If \"AddSkybox\" is enabled, a skybox will automatically be added to your scene prior to export.")]
		public bool AddSkybox = true;

		[Range(1000f, 50000f)]
		[Tooltip("Set the size of the skybox.")]
		public float SkyboxDiameter = 1000f;

		[Tooltip("If \"CustomSkybox\" texture is valid, it will be used on the added skybox, otherwise the skybox will use the \"Bobbie\\Outer\" shader along with \"CustomSkyboxTint\".")]
		public Cubemap? CustomSkybox;

		[Tooltip("If \"CustomSkybox\" texture is set to None, this color will be used to Tint the skybox")]
		public Color CustomSkyboxTint = new Color(0.224f, 0.424f, 0.839f, 1f);

		[Tooltip("How should lighting be baked/exported?\n 1. Default_Unity - this will bake lighting using Unity's built-in system\n 2. Alternative - this will not trigger a light bake and will NOT delete Lightmapping data before exporting (use this option if you use a 3rd party baker like Bakery)\n 3. Off - this will not bake lighting and will delete Lightmapping data before exporting")]
		public ExportLightingType LightingExportType;

		[Tooltip("If \"ExportAllObjects\" is enabled, any objects that aren't a child object of your MapDescriptor will be automatically re-parented to the MapDescriptor GameObject prior to export.")]
		public bool ExportAllObjects = true;

		[Obsolete("Moved to Map Export Settings")]
		public VirtualStumpReturnWatchProps GetReturnToVStumpWatchProps()
		{
			VirtualStumpReturnWatchProps result = default(VirtualStumpReturnWatchProps);
			result.holdDuration = watchHoldDuration;
			result.shouldTagPlayer = watchShouldTagPlayer;
			result.shouldKickPlayer = watchShouldKickPlayer;
			result.infectionOverride = watchInfectionOverride;
			result.holdDuration_Infection = watchHoldDuration_Infection;
			result.shouldTagPlayer_Infection = watchShouldTagPlayer_Infection;
			result.shouldKickPlayer_Infection = watchShouldKickPlayer_Infection;
			result.customModeOverride = watchCustomModeOverride;
			result.holdDuration_Custom = watchHoldDuration_CustomMode;
			result.shouldTagPlayer_CustomMode = watchShouldTagPlayer_CustomMode;
			result.shouldKickPlayer_CustomMode = watchShouldKickPlayer_CustomMode;
			return result;
		}
	}
	public class MapEntity : MonoBehaviour
	{
		[Tooltip("If \"IsTemplate\" is enabled, this Map Entity will be used by the MapSpawnManager to create duplicate Map Entities of the same \"entityTypeId\". Template Map Entities will not be created when the map loads.")]
		public bool isTemplate;

		[Tooltip("\"EntityTypeID\" is used to distinguish each Map Entity that the MapSpawnManager can create. Make sure each Map Entity with \"IsTemplate\" set to TRUE has a unique \"EntityTypeID\".")]
		public byte entityTypeId;

		[Tooltip("The \"LuaEntityID\" can be used in Luau scripts with the \"findPrePlacedAIAgentByID\" and\"findPrePlacedGrabbableByID\" functions to find your pre-placed Map Entities after the map is loaded.")]
		public short lua_EntityID;

		public virtual long GetPackedCreateData()
		{
			return 0L;
		}
	}
	public class MapOrientationPoint : AccessDoorPlaceholder
	{
	}
	public class MapPackageInfo
	{
		[JsonProperty(PropertyName = "pcFileName")]
		public string? pcFileName;

		[JsonProperty(PropertyName = "androidFileName")]
		public string? androidFileName;

		[JsonProperty(PropertyName = "descriptor")]
		public Descriptor? descriptor;

		[JsonProperty(PropertyName = "initialScene")]
		public string? initialScene;

		[JsonProperty(PropertyName = "initialScenes")]
		public string[]? initialScenes;

		[JsonProperty(PropertyName = "customMapSupportVersion")]
		public int customMapSupportVersion;

		[JsonProperty(PropertyName = "maxPlayers")]
		public int maxPlayers = 10;

		[JsonProperty(PropertyName = "availableGameModes")]
		public int[]? availableGameModes;

		[JsonProperty(PropertyName = "defaultGameMode")]
		public int defaultGameMode;

		[JsonProperty(PropertyName = "disableHoldingHandsAllModes")]
		public bool disableHoldingHandsAllModes;

		[JsonProperty(PropertyName = "disableHoldingHandsCustomMode")]
		public bool disableHoldingHandsCustomMode;

		[JsonProperty(PropertyName = "watchHoldDuration")]
		public float watchHoldDuration = 0.5f;

		[JsonProperty(PropertyName = "watchShouldTagPlayer")]
		public bool watchShouldTagPlayer;

		[JsonProperty(PropertyName = "watchShouldKickPlayer")]
		public bool watchShouldKickPlayer;

		[JsonProperty(PropertyName = "watchInfectionOverride")]
		public bool watchInfectionOverride;

		[JsonProperty(PropertyName = "watchHoldDuration_Infection")]
		public float watchHoldDuration_Infection = 0.5f;

		[JsonProperty(PropertyName = "watchShouldTagPlayer_Infection")]
		public bool watchShouldTagPlayer_Infection;

		[JsonProperty(PropertyName = "watchShouldKickPlayer_Infection")]
		public bool watchShouldKickPlayer_Infection;

		[JsonProperty(PropertyName = "watchCustomModeOverride")]
		public bool watchCustomModeOverride;

		[JsonProperty(PropertyName = "watchHoldDuration_CustomMode")]
		public float watchHoldDuration_CustomMode = 0.5f;

		[JsonProperty(PropertyName = "watchShouldTagPlayer_CustomMode")]
		public bool watchShouldTagPlayer_CustomMode;

		[JsonProperty(PropertyName = "watchShouldKickPlayer_CustomMode")]
		public bool watchShouldKickPlayer_CustomMode;

		[JsonProperty(PropertyName = "useUberShaderDynamicLighting")]
		public bool useUberShaderDynamicLighting;

		[JsonProperty(PropertyName = "uberShaderAmbientDynamicLight_R")]
		public float uberShaderAmbientDynamicLight_R;

		[JsonProperty(PropertyName = "uberShaderAmbientDynamicLight_G")]
		public float uberShaderAmbientDynamicLight_G;

		[JsonProperty(PropertyName = "uberShaderAmbientDynamicLight_B")]
		public float uberShaderAmbientDynamicLight_B;

		[JsonProperty(PropertyName = "uberShaderAmbientDynamicLight_A")]
		public float uberShaderAmbientDynamicLight_A;

		[JsonProperty(PropertyName = "customGamemodeScript")]
		public string? customGamemodeScript;

		[JsonProperty(PropertyName = "luauDevMode")]
		public bool devMode;

		[JsonConstructor]
		public MapPackageInfo()
		{
		}

		public VirtualStumpReturnWatchProps GetReturnToVStumpWatchProps()
		{
			VirtualStumpReturnWatchProps result = default(VirtualStumpReturnWatchProps);
			result.holdDuration = watchHoldDuration;
			result.shouldTagPlayer = watchShouldTagPlayer;
			result.shouldKickPlayer = watchShouldKickPlayer;
			result.infectionOverride = watchInfectionOverride;
			result.holdDuration_Infection = watchHoldDuration_Infection;
			result.shouldTagPlayer_Infection = watchShouldTagPlayer_Infection;
			result.shouldKickPlayer_Infection = watchShouldKickPlayer_Infection;
			result.customModeOverride = watchCustomModeOverride;
			result.holdDuration_Custom = watchHoldDuration_CustomMode;
			result.shouldTagPlayer_CustomMode = watchShouldTagPlayer_CustomMode;
			result.shouldKickPlayer_CustomMode = watchShouldKickPlayer_CustomMode;
			return result;
		}
	}
	public class MapSpawnManager : MonoBehaviour
	{
		private Dictionary<int, GameObject> entityTypes = new Dictionary<int, GameObject>(64);

		public static MapSpawnManager? instance;

		private static bool hasInstance;

		private Dictionary<string, MapSpawnPoint> spawnPoints = new Dictionary<string, MapSpawnPoint>(128);

		public static bool HasInstance => hasInstance;

		private void Awake()
		{
			if (instance != null)
			{
				UnityEngine.Object.Destroy(this);
				return;
			}
			instance = this;
			hasInstance = true;
			GetEntityTypeTemplates();
			FindSpawnPoints();
		}

		public void FindSpawnPoints()
		{
			spawnPoints.Clear();
			MapSpawnPoint[] array = UnityEngine.Object.FindObjectsByType<MapSpawnPoint>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
			for (int i = 0; i < array.Length; i++)
			{
				spawnPoints.Add(array[i].spawnID, array[i]);
			}
		}

		public bool GetSpawnPoint(string spawnPointID, out MapSpawnPoint spawnPoint)
		{
			if (!spawnPoints.TryGetValue(spawnPointID, out spawnPoint))
			{
				return false;
			}
			return true;
		}

		public bool GetEntityType(int enemyTypeIndex, out GameObject? newEntity)
		{
			if (!entityTypes.ContainsKey(enemyTypeIndex))
			{
				newEntity = null;
				return false;
			}
			newEntity = entityTypes[enemyTypeIndex];
			return true;
		}

		public bool SpawnEntity(string spawnPointID, int enemyTypeIndex, out MapEntity? newEntity)
		{
			if (!entityTypes.ContainsKey(enemyTypeIndex))
			{
				UnityEngine.Debug.Log("AISpawnManager::SpawnEnemy enemy index incorrect");
				newEntity = null;
				return false;
			}
			if (!spawnPoints.TryGetValue(spawnPointID, out MapSpawnPoint value))
			{
				UnityEngine.Debug.Log("AISpawnManager::SpawnEnemy Can't find spawn point");
				newEntity = null;
				return false;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(entityTypes[enemyTypeIndex], value.transform);
			value.spawnCount++;
			newEntity = gameObject.GetComponent<MapEntity>();
			return true;
		}

		public bool SpawnEntity(int enemyTypeIndex, out MapEntity? newEnemy)
		{
			if (!entityTypes.ContainsKey(enemyTypeIndex))
			{
				UnityEngine.Debug.Log("AISpawnManager::SpawnEnemy enemy index incorrect");
				newEnemy = null;
				return false;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(entityTypes[enemyTypeIndex]);
			newEnemy = gameObject.GetComponent<MapEntity>();
			return true;
		}

		private void GetEntityTypeTemplates()
		{
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				MapEntity component = child.GetComponent<MapEntity>();
				if (!(component == null) && component.isTemplate)
				{
					child.gameObject.SetActive(value: false);
					entityTypes[component.entityTypeId] = child.gameObject;
				}
			}
		}
	}
	public class MapSpawnPoint : MonoBehaviour
	{
		public string spawnID = "";

		public int spawnCount;
	}
	[RequireComponent(typeof(Collider))]
	public class MovingSurfaceSettings : MonoBehaviour
	{
		[HideInInspector]
		[Tooltip("Assign an ID that is unique for each moving surface in your map. should NOT be -1")]
		public int uniqueId = -1;
	}
	public class MultiPartFire : MonoBehaviour
	{
		public Transform? baseFire;

		public Transform? middleFire;

		public Transform? topFire;

		public float baseMultiplier;

		public float middleMultiplier;

		public float topMultiplier;

		public float bottomRange;

		public float middleRange;

		public float topRange;

		public float perlinStepBottom;

		public float perlinStepMiddle;

		public float perlinStepTop;

		public float slerp = 0.01f;

		private float lastAngleBottom;

		private float lastAngleMiddle;

		private float lastAngleTop;

		private float perlinBottom;

		private float perlinMiddle;

		private float perlinTop;

		private bool mergedBottom;

		private bool mergedMiddle;

		private bool mergedTop;

		private Vector3 tempVec;

		private float lastTime;

		private void Start()
		{
			lastAngleBottom = 0f;
			lastAngleMiddle = 0f;
			lastAngleTop = 0f;
			perlinBottom = UnityEngine.Random.Range(0, 100);
			perlinMiddle = UnityEngine.Random.Range(200, 300);
			perlinTop = UnityEngine.Random.Range(400, 500);
			tempVec = new Vector3(0f, 0f, 0f);
			mergedBottom = false;
			mergedMiddle = false;
			mergedTop = false;
			lastTime = Time.time;
		}

		public void Update()
		{
			Flap(ref perlinBottom, perlinStepBottom, ref lastAngleBottom, ref baseFire, bottomRange, baseMultiplier, ref mergedBottom);
			Flap(ref perlinMiddle, perlinStepMiddle, ref lastAngleMiddle, ref middleFire, middleRange, middleMultiplier, ref mergedMiddle);
			Flap(ref perlinTop, perlinStepTop, ref lastAngleTop, ref topFire, topRange, topMultiplier, ref mergedTop);
			lastTime = Time.time;
		}

		private void Flap(ref float perlinValue, float perlinStep, ref float lastAngle, ref Transform? flameTransform, float range, float multiplier, ref bool isMerged)
		{
			if (flameTransform == null)
			{
				return;
			}
			perlinValue += perlinStep;
			lastAngle += (Time.time - lastTime) * Mathf.PerlinNoise(perlinValue, 0f);
			tempVec.x = range * Mathf.Sin(lastAngle * multiplier);
			if (Mathf.Abs(tempVec.x - flameTransform.localEulerAngles.x) > 180f)
			{
				if (tempVec.x > flameTransform.localEulerAngles.x)
				{
					tempVec.x -= 360f;
				}
				else
				{
					tempVec.x += 360f;
				}
			}
			if (isMerged)
			{
				flameTransform.localEulerAngles = tempVec;
			}
			else if (Mathf.Abs(flameTransform.localEulerAngles.x - tempVec.x) < 1f)
			{
				isMerged = true;
				flameTransform.localEulerAngles = tempVec;
			}
			else
			{
				tempVec.x = (tempVec.x - flameTransform.localEulerAngles.x) * slerp + flameTransform.localEulerAngles.x;
				flameTransform.localEulerAngles = tempVec;
			}
		}
	}
	[RequireComponent(typeof(Collider))]
	public class ObjectActivationTriggerSettings : TriggerSettings
	{
		[Tooltip("Should this Trigger sync to all players, or only be processed for the person who triggered it?\nObjectActivationTriggers generally need to do this to ensure activated/deactivated objects are in the same state for all players. Disable with caution.")]
		public bool syncedToAllPlayers = true;

		[Tooltip("Any objects that should be activated when this is triggered")]
		public List<GameObject> objectsToActivate = new List<GameObject>();

		[Tooltip("Any objects that should be deactivated when this is triggered")]
		public List<GameObject> objectsToDeactivate = new List<GameObject>();

		[Tooltip("Any other triggers that should be reset when this is triggered. Resetting a Trigger will reset it's internal triggerCount to 0.")]
		public List<GameObject> triggersToReset = new List<GameObject>();

		[Tooltip("If TRUE, only the TriggerCount for the Triggers in \"Triggers to Reset\" will be reset. LastTriggerTime will be unchanged.")]
		public bool onlyResetTriggerCount;

		public override void PropagateProperties()
		{
			syncedToAllPlayers_private = syncedToAllPlayers;
		}
	}
	[RequireComponent(typeof(Collider))]
	public class PlayAnimationTriggerSettings : TriggerSettings
	{
		[Tooltip("Should this Trigger sync to all players, or only be processed for the person who triggered it?\nPlayAnimationTriggers should generally have this enabled to ensure animated objects are in the same state for all players. Disable with caution.")]
		public bool syncedToAllPlayers = true;

		[Tooltip("Any objects that should play the specified animation when this is triggered")]
		public List<GameObject> animatedObjects = new List<GameObject>();

		[Tooltip("The name of the animation state to activate for any Animator components on the \"Animated Objects\".")]
		public string animationName = "";

		public override void PropagateProperties()
		{
			syncedToAllPlayers_private = syncedToAllPlayers;
		}
	}
	public class RopeSwingSegment : MonoBehaviour
	{
		public GameObject? ropeSwingParent;

		public int boneIndex;
	}
	public class SurfaceMoverSettings : MonoBehaviour
	{
		public enum MoveType
		{
			Translation,
			Rotation
		}

		public enum RotationAxis
		{
			X,
			Y,
			Z
		}

		[SerializeField]
		public MoveType moveType;

		[Range(0.001f, float.MaxValue)]
		[Tooltip("Meters per second for Translation | Revolutions per second for Rotation")]
		[SerializeField]
		public float velocity = 0.001f;

		[Range(0f, float.MaxValue)]
		[Tooltip("How long in seconds should the cycle be delayed?")]
		[SerializeField]
		public float cycleDelay;

		[Tooltip("If TRUE, Translation mode will move from End to Start; Rotation mode will rotate in the negative direction.")]
		[SerializeField]
		public bool reverseDir;

		[Tooltip("If TRUE, Translation mode movement direction will be reversed when it reaches Start or End; Rotation mode rotation direction will be reversed once it's rotated the full Rotation Amount")]
		[SerializeField]
		public bool reverseDirOnCycle = true;

		[SerializeField]
		public Transform? start;

		[SerializeField]
		public Transform? end;

		[Tooltip("Which local axis should the object rotate around?")]
		[SerializeField]
		public RotationAxis rotationAxis = RotationAxis.Y;

		[Range(0.001f, 360f)]
		[Tooltip("How far should the object rotate per-cycle (in degrees)")]
		[SerializeField]
		public float rotationAmount = 360f;

		[Tooltip("If TRUE the rotation starting point will be the initial Y-axis rotation value of the object when the map is loaded, otherwise it will start at 0")]
		[SerializeField]
		public bool rotationRelativeToStarting = true;

		public bool hasBeenExported;

		private AnimationCurve? lerpAlpha;

		private Vector3 startingRotation;

		private float cycleDuration;

		private float distance;

		private float currT;

		private float percent;

		private bool currForward;

		public void OnEnable()
		{
			if (hasBeenExported)
			{
				return;
			}
			if (moveType == MoveType.Translation && start != null && end != null)
			{
				distance = Vector3.Distance(end.position, start.position);
				float num = distance / velocity;
				cycleDuration = num + cycleDelay;
			}
			else
			{
				if (rotationRelativeToStarting)
				{
					startingRotation = base.transform.localRotation.eulerAngles;
				}
				cycleDuration = rotationAmount / 360f / velocity;
				cycleDuration += cycleDelay;
			}
			float num2 = cycleDelay / cycleDuration;
			Vector2 vector = new Vector2(num2 / 2f, 0f);
			Vector2 vector2 = new Vector2(1f - num2 / 2f, 1f);
			float num3 = (vector2.y - vector.y) / (vector2.x - vector.x);
			lerpAlpha = new AnimationCurve(new Keyframe(num2 / 2f, 0f, 0f, num3), new Keyframe(1f - num2 / 2f, 1f, num3, 0f));
		}

		private void FixedUpdate()
		{
			if (!hasBeenExported)
			{
				Move();
			}
		}

		private long NetworkTimeMs()
		{
			return (long)(Time.time * 1000f);
		}

		private long CycleLengthMs()
		{
			return (long)(cycleDuration * 1000f);
		}

		private double PlatformTime()
		{
			long num = NetworkTimeMs();
			long num2 = CycleLengthMs();
			return (double)(num - num / num2 * num2) / 1000.0;
		}

		private int CycleCount()
		{
			return (int)(NetworkTimeMs() / CycleLengthMs());
		}

		private float CycleCompletionPercent()
		{
			return Mathf.Clamp((float)(PlatformTime() / (double)cycleDuration), 0f, 1f);
		}

		private bool IsEvenCycle()
		{
			return CycleCount() % 2 == 0;
		}

		public void Move()
		{
			Progress();
			switch (moveType)
			{
			case MoveType.Translation:
				base.transform.localPosition = UpdatePointToPoint(percent);
				break;
			case MoveType.Rotation:
				UpdateRotation(percent);
				break;
			}
		}

		private Vector3 UpdatePointToPoint(float percentage)
		{
			if (lerpAlpha == null || start == null || end == null)
			{
				return base.transform.localPosition;
			}
			float t = lerpAlpha.Evaluate(percentage);
			return Vector3.Lerp(start.localPosition, end.localPosition, t);
		}

		private void UpdateRotation(float percentage)
		{
			if (lerpAlpha == null)
			{
				return;
			}
			float num = lerpAlpha.Evaluate(percentage) * rotationAmount;
			if (rotationRelativeToStarting)
			{
				Vector3 euler = startingRotation;
				switch (rotationAxis)
				{
				case RotationAxis.X:
					euler.x += num;
					break;
				case RotationAxis.Y:
					euler.y += num;
					break;
				case RotationAxis.Z:
					euler.z += num;
					break;
				}
				base.transform.localRotation = Quaternion.Euler(euler);
			}
			else
			{
				switch (rotationAxis)
				{
				case RotationAxis.X:
					base.transform.localRotation = Quaternion.AngleAxis(num, Vector3.right);
					break;
				case RotationAxis.Y:
					base.transform.localRotation = Quaternion.AngleAxis(num, Vector3.up);
					break;
				case RotationAxis.Z:
					base.transform.localRotation = Quaternion.AngleAxis(num, Vector3.forward);
					break;
				}
			}
		}

		private void Progress()
		{
			currT = CycleCompletionPercent();
			currForward = IsEvenCycle();
			percent = currT;
			if (reverseDirOnCycle)
			{
				percent = (currForward ? currT : (1f - currT));
			}
			if (reverseDir)
			{
				percent = 1f - percent;
			}
		}
	}
	public enum SurfaceSoundOverride
	{
		Default = 0,
		None = 1,
		pillowhandtap = 3,
		grassrockhandtap = 7,
		barkhandtap = 8,
		woodhandtap = 9,
		dirthandtap = 14,
		metalhandtap = 18,
		crystalhandtap = 20,
		leafcrunch = 31,
		snowstep = 32,
		crystalhandtap_root_2octdown = 40,
		crystalhandtap_second_2octdown = 41,
		crystalhandtap_third_2octdown = 42,
		crystalhandtap_fifth_2octdown = 43,
		crystalhandtap_sixth_2octdown = 44,
		crystalhandtap_root_1octdown = 45,
		crystalhandtap_second_1octdown = 46,
		crystalhandtap_third_1octdown = 47,
		crystalhandtap_fifth_1octdown = 48,
		crystalhandtap_sixth_1octdown = 49,
		crystalhandtap_root = 50,
		crystalhandtap_root_second = 51,
		crystalhandtap_third = 52,
		crystalhandtap_fifth = 53,
		crystalhandtap_sixth = 54,
		umbrellaopen = 64,
		umbrellaclose = 65,
		keyboardclick = 66,
		buttonpress = 67,
		p2_racktom = 68,
		p1_snare = 69,
		p2_floor_tom_2 = 70,
		p2_kick = 71,
		p1_open_hat = 72,
		bongolowest = 73,
		bongohigh = 74,
		squeak_squeeze = 75,
		squeak_release = 76,
		bonerattle = 77,
		Tombstone_Surface_04 = 78,
		cauldroninner = 79,
		Cauldron_Surface_04 = 80,
		pumpkinhit = 81,
		Web_Surface_02 = 82,
		ShortTurkeyGobbleBQuiet = 83,
		foodpop = 84,
		bite1 = 85,
		bite2 = 86,
		bite3 = 87,
		HayImpactA = 88,
		ropecreak = 89,
		planthit = 90,
		ToyFrogSound = 91,
		VineHit1 = 92,
		cloud2 = 93,
		woodfloor2 = 94,
		tire = 95,
		fruitsquish_1 = 96,
		washingmachinehit = 98,
		LeafHit1 = 99,
		skyjunglewood2 = 100,
		skyjunglewood = 101,
		huthit = 105,
		fireflyjarhit = 106,
		beanbag1 = 107,
		beanbag2 = 108,
		softhit1 = 110,
		storewoodhit = 112,
		shelfhit = 114,
		roofhit = 115,
		cranehit = 116,
		rughit1 = 118,
		snowglobehit = 120,
		ornamenthit = 121,
		gifthit = 134,
		ToyGorillaElf_Squeeze = 140,
		ToyGorillaElf_Release = 141,
		metalhit1 = 146,
		metalhit2 = 149,
		PenguinSqueeze = 154,
		PenguinRelease = 155,
		WolfSqueeze = 156,
		WolfRelease = 157,
		BoxHit = 160,
		DungeonPillowHit = 164,
		BasementWoodWall = 173,
		BookHit = 178,
		MonkeyeSqueeze = 187,
		DragonSqueeze = 188,
		ConcreteHit = 189,
		BeeSqueeze = 191,
		SpongeSquish = 193,
		SpongeRelease_CC0_234872__mlsulli__sponge_being_squeezed_01 = 194,
		CoyoteHowl_Quiet2 = 195,
		DivingBoardBounce = 196,
		SandTap = 197,
		PalmTreeBark = 198,
		SharkSqueeze = 200,
		SharkRelease = 201,
		TentBounce = 202,
		FireworkMortarInteraction_01__442359__toddcircle__metallic_slap = 203,
		WaterBalloonGrab_04 = 204,
		SlipAndSlideStep = 205,
		DolphinSqueeze3 = 206,
		DolphinRelease3 = 207,
		BugSprayShort = 208,
		Trampoline1 = 210,
		ButtonSplitDownQuiet = 211,
		ButtonSplitUpQuiet = 212,
		HugeCrystalHit = 213,
		crystalhandtap_seventh = 214,
		crystalhandtap_seventh_1octup = 215,
		crystalhandtap_seventh_1octdown = 216,
		crystalhandtap_seventh_2octdown = 217,
		crystalhandtap_fourth = 218,
		crystalhandtap_fourth_1octdown = 219,
		crystalhandtap_fourth_1octup = 220,
		crystalhandtap_fourth_2octdown = 221,
		EelSqueeze = 222,
		EelRelease = 223,
		crystalhandtap_root_1octup = 224,
		crystalhandtap_second_1octup = 225,
		crystalhandtap_third_1octup = 226,
		crystalhandtap_fifth_1octup = 227,
		crystalhandtap_sixth_1octup = 228,
		BottleSqueeze = 229,
		LavaRockBucketGrab_01 = 231,
		sfx_phoenix_caw_fiery_short = 232,
		sfx_fan_open = 233,
		sfx_fan_close = 234,
		CatSqueeze = 235,
		CatRelease = 236,
		Squirrel_Squeezy_Toy_01_SFX = 237,
		Turkey_Baster_Cosmetic_01_SFX = 238,
		Turkey_Baster_Cosmetic_02_SFX = 239,
		SFX_Tin_Soldier_Monke_Toy_001 = 242,
		SFX_Tin_Soldier_Monke_Toy_002 = 243,
		GT_Tuning_Fork_001 = 244,
		GT_Tuning_Fork_002 = 245,
		GT_Tuning_Fork_Fail_006 = 246,
		GT_Tuning_Fork_deepring = 247,
		GT_Tuning_Fork_neutralring = 248,
		HeartSqueeze = 250,
		HeartBeat1 = 251,
		Smoker_Bellows_Out_short01 = 253,
		Smoker_Bellows_In_short02 = 254,
		Race_Bell = 255,
		hand_tap_bounce_house_001 = 256,
		hand_tap_bounce_house_002 = 257,
		Purple_Step_01 = 258,
		GT_Gate_Fence_Closing_End = 259
	}
	[DisallowMultipleComponent]
	public class SurfaceOverrideSettings : MonoBehaviour
	{
		public SurfaceSoundOverride soundOverride;

		public float extraVelMultiplier = 1f;

		public float extraVelMaxMultiplier = 1f;

		[Tooltip("-1.0 represents the default value, valid values are between 0.0 and 1.0")]
		public float slidePercentage = -1f;

		[Tooltip("If TRUE, players won't be pushed away when tapping on the object")]
		public bool disablePushBackEffect;
	}
	[RequireComponent(typeof(Collider))]
	[DisallowMultipleComponent]
	public class TagZoneSettings : TriggerSettings
	{
		[Tooltip("Should this Trigger sync to all players, or only be processed for the person who triggered it?\nTagZones generally shouldn't need to do this, but doing so will sync it's internal TriggerCount to all players.")]
		public bool syncedToAllPlayers;

		public override void PropagateProperties()
		{
			syncedToAllPlayers_private = syncedToAllPlayers;
		}
	}
	[RequireComponent(typeof(Collider))]
	[DisallowMultipleComponent]
	public class TeleporterSettings : TriggerSettings
	{
		[Tooltip("Should this Trigger sync to all players, or only be processed for the person who triggered it?\nTeleporters generally shouldn't need to do this, but doing so will sync it's internal TriggerCount to all players.")]
		public bool syncedToAllPlayers;

		[Tooltip("Teleport points used for this teleporter. Chosen at random.")]
		[SerializeField]
		public List<Transform> TeleportPoints = new List<Transform>();

		[Tooltip("Should the teleporter change the players rotation to match the chosen Teleport Point's rotation?")]
		[SerializeField]
		public bool matchTeleportPointRotation = true;

		[Tooltip("Should the teleporter maintain the players current velocity after teleporting?")]
		[SerializeField]
		public bool maintainVelocity = true;

		public override void PropagateProperties()
		{
			syncedToAllPlayers_private = syncedToAllPlayers;
		}
	}
	public enum TriggerSource
	{
		None,
		Hands,
		Head,
		Body,
		HeadOrBody
	}
	public abstract class TriggerSettings : MonoBehaviour
	{
		[Tooltip("Hands and Body/Head colliders have inherently different settings in GorillaTag and cannot be detected on the same trigger.")]
		public TriggerSource triggeredBy = TriggerSource.HeadOrBody;

		[Tooltip("Deprecated, use the 'triggeredBy' property instead. \nHands and Body/Head colliders have inherently different settings in GorillaTag and cannot be detected on the same trigger.")]
		[HideInInspector]
		public bool triggeredByHands = true;

		[Tooltip("Deprecated, use the 'triggeredBy' property instead. \nHands and Body/Head colliders have inherently different settings in GorillaTag and cannot be detected on the same trigger.")]
		[HideInInspector]
		public bool triggeredByBody = true;

		[Tooltip("Deprecated, use the 'triggeredBy' property instead. \nHands and Body/Head colliders have inherently different settings in GorillaTag and cannot be detected on the same trigger.")]
		[HideInInspector]
		public bool triggeredByHead = true;

		[Tooltip("Should this Trigger re-trigger if a player stays inside it for long enough?")]
		public bool retriggerAfterDuration;

		[Tooltip("(Seconds) If 'retriggerAfterDuration' is TRUE, how long does a player need to Stay inside the Trigger before it re-triggers? If 'generalRetriggerDelay' is larger, that value will be used instead.")]
		public double retriggerStayDuration = 2.0;

		[HideInInspector]
		public float retriggerDelay = 2f;

		[Tooltip("(Seconds) When this trigger is Enabled/Activated, it can't be triggered until this duration has passed.")]
		public double onEnableTriggerDelay;

		[Tooltip("(Seconds) After being triggered, how long before this trigger can be triggered again?")]
		public double generalRetriggerDelay;

		[Tooltip("How many times is this Trigger allowed to trigger? 0 means infinite")]
		public byte numAllowedTriggers;

		[Tooltip("Validation Distance is used to validate network synced trigger activations and is automatically calculated during the Map Export process for single-collider triggers using a Box, Sphere, or Capsule collider. To customize this, or if using a MeshCollider or multi-collider setup, you can set this override to a positive, non-zero value. Generally it should be equal to about 1.5 times the full collider radius (including scale). For example: if using a Sphere collider with radius 2.0 and its GameObject has a scale of 3.0 (resulting in an actual radius of 6.0), you would set this value to (2.0 * 3.0) * 1.5 = 9.0")]
		public float validationDistanceOverride = -1f;

		[HideInInspector]
		public byte triggerId;

		[HideInInspector]
		public float validationDistance = 1f;

		[HideInInspector]
		public bool syncedToAllPlayers_private;

		public virtual void PropagateProperties()
		{
		}
	}
	[RequireComponent(typeof(Light))]
	public class UberShaderDynamicLight : MonoBehaviour
	{
		public Light? dynamicLight;

		private void Awake()
		{
			if (dynamicLight == null)
			{
				dynamicLight = GetComponent<Light>();
			}
		}
	}
	public static class Utilities
	{
		public static string SanitizeString(string str)
		{
			string text = "";
			for (int i = 0; i < str.Length; i++)
			{
				if (char.IsLetterOrDigit(str[i]))
				{
					text += str[i];
				}
				else if (char.IsWhiteSpace(str[i]))
				{
					text += "-";
				}
			}
			return text;
		}

		private static void StripMeshesForObjectsOfType<T>(GameObject rootObject)
		{
			T[] componentsInChildren = rootObject.GetComponentsInChildren<T>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Component component = componentsInChildren[i] as Component;
				if (!(component == null))
				{
					if (component.gameObject.GetComponent<Renderer>() != null)
					{
						UnityEngine.Object.DestroyImmediate(component.gameObject.GetComponent<Renderer>());
					}
					if (component.gameObject.GetComponent<MeshFilter>() != null)
					{
						UnityEngine.Object.DestroyImmediate(component.gameObject.GetComponent<MeshFilter>());
					}
				}
			}
		}

		public static string GetSceneNameFromFilePath(string filePath, bool sanitizeName = true)
		{
			string[] array = filePath.Split('/')[^1].Split('.');
			string text = "";
			for (int i = 0; i < array.Length - 1; i++)
			{
				text += array[i];
				if (i < array.Length - 2)
				{
					text += ".";
				}
			}
			if (!sanitizeName)
			{
				return text;
			}
			return SanitizeString(text);
		}
	}
	public class ZiplineSegment : MonoBehaviour
	{
		public GameObject? ziplineParent;
	}
	[RequireComponent(typeof(Collider))]
	[DisallowMultipleComponent]
	public class ZoneShaderTriggerSettings : MonoBehaviour
	{
		public enum ActivationType
		{
			ActivateSpecificSettings,
			ActivateCustomMapDefaults
		}

		public ActivationType activationType;

		[Tooltip("If this is TRUE, these ZoneShaderSettings will be activated when this GameObject is activated")]
		public bool activateOnEnable;

		public GameObject? zoneShaderSettingsObject;
	}
}
