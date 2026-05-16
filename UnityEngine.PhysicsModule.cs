using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.LowLevelPhysics;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

[assembly: InternalsVisibleTo("UnityEngine.XRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VFXModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestWWWModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestTextureModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityTestProtocolModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityCurlModule")]
[assembly: InternalsVisibleTo("UnityEngine.UmbraModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsModule")]
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubsystemsModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubstanceModule")]
[assembly: InternalsVisibleTo("UnityEngine.StreamingModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteMaskModule")]
[assembly: InternalsVisibleTo("UnityEngine.TilemapModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteShapeModule")]
[assembly: InternalsVisibleTo("UnityEngine.ShaderVariantAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.ScreenCaptureModule")]
[assembly: InternalsVisibleTo("UnityEngine.RuntimeInitializeOnLoadManagerInitializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainPhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.PropertiesModule")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.2D")]
[assembly: InternalsVisibleTo("Unity.DeploymentTests.Services")]
[assembly: InternalsVisibleTo("Unity.Burst.Editor")]
[assembly: InternalsVisibleTo("Unity.Burst")]
[assembly: InternalsVisibleTo("Unity.Automation")]
[assembly: InternalsVisibleTo("UnityEngine.TestRunner")]
[assembly: InternalsVisibleTo("UnityEngine.Purchasing")]
[assembly: InternalsVisibleTo("UnityEngine.Advertisements")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS4VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4Module")]
[assembly: InternalsVisibleTo("UnityEngine.SwitchModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Physics2DModule")]
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.ParticleSystemModule")]
[assembly: InternalsVisibleTo("UnityEngine.ContentLoadModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterRendererModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterInputModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClothModule")]
[assembly: InternalsVisibleTo("UnityEngine.AudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.AssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.HotReloadModule")]
[assembly: InternalsVisibleTo("UnityEngine.AnimationModule")]
[assembly: InternalsVisibleTo("UnityEngine.AndroidJNIModule")]
[assembly: InternalsVisibleTo("UnityEngine.AccessibilityModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConnectModule")]
[assembly: InternalsVisibleTo("UnityEngine.ARModule")]
[assembly: InternalsVisibleTo("UnityEngine.JSONSerializeModule")]
[assembly: InternalsVisibleTo("UnityEngine.PhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.AMDModule")]
[assembly: InternalsVisibleTo("UnityEngine.AIModule")]
[assembly: InternalsVisibleTo("UnityEngine.CoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.SharedInternalsModule")]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("UnityEngine.InputModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.NVIDIAModule")]
[assembly: InternalsVisibleTo("UnityEngine.MultiplayerModule")]
[assembly: InternalsVisibleTo("UnityEngine.MarshallingModule")]
[assembly: InternalsVisibleTo("UnityEngine.LocalizationModule")]
[assembly: InternalsVisibleTo("UnityEngine.InsightsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConsentModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputForUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.IMGUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreTextEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreFontEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputLegacyModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextRenderingModule")]
[assembly: InternalsVisibleTo("UnityEngine.HierarchyCoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.GridModule")]
[assembly: InternalsVisibleTo("UnityEngine.GraphicsStateCollectionSerializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.GameCenterModule")]
[assembly: InternalsVisibleTo("UnityEngine.ImageConversionModule")]
[assembly: InternalsVisibleTo("UnityEngine.GIModule")]
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Deployment")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Tooling")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Application")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.007")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.006")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.001")]
[assembly: InternalsVisibleTo("UnityEngine.Core.Runtime.Tests")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.008")]
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.009")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
[assembly: InternalsVisibleTo("Unity.Modules.Physics.Tests.Editor")]
[assembly: InternalsVisibleTo("Unity.Modules.Physics.Tests.Playmode")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: InternalsVisibleTo("Unity.Subsystem.Registration")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.024")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.023")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.021")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.020")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.019")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.018")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.017")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.016")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.015")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.014")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.013")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.012")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.022")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.CommonUtils")]
[assembly: InternalsVisibleTo("Unity.Modules.Physics.Tests.Common")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine
{
	public struct ContactPoint
	{
		internal Vector3 m_Point;

		internal Vector3 m_Normal;

		internal Vector3 m_Impulse;

		internal int m_ThisColliderInstanceID;

		internal int m_OtherColliderInstanceID;

		internal float m_Separation;

		public Vector3 point => m_Point;

		public Vector3 normal => m_Normal;

		public Vector3 impulse => m_Impulse;

		public Collider thisCollider => Physics.GetColliderByInstanceID(m_ThisColliderInstanceID);

		public Collider otherCollider => Physics.GetColliderByInstanceID(m_OtherColliderInstanceID);

		public float separation => m_Separation;

		internal ContactPoint(Vector3 point, Vector3 normal, Vector3 impulse, float separation, int thisInstanceID, int otherInstenceID)
		{
			m_Point = point;
			m_Normal = normal;
			m_Impulse = impulse;
			m_Separation = separation;
			m_ThisColliderInstanceID = thisInstanceID;
			m_OtherColliderInstanceID = otherInstenceID;
		}
	}
	public class Collision
	{
		private ContactPairHeader m_Header;

		private ContactPair m_Pair;

		private bool m_Flipped;

		private ContactPoint[] m_LegacyContacts = null;

		public Vector3 impulse => m_Pair.impulseSum;

		public Vector3 relativeVelocity => m_Flipped ? m_Header.m_RelativeVelocity : (-m_Header.m_RelativeVelocity);

		public Rigidbody rigidbody => body as Rigidbody;

		public ArticulationBody articulationBody => body as ArticulationBody;

		public Component body => m_Flipped ? m_Header.body : m_Header.otherBody;

		public Collider collider => m_Flipped ? m_Pair.collider : m_Pair.otherCollider;

		public Transform transform => (rigidbody != null) ? rigidbody.transform : collider.transform;

		public GameObject gameObject => (body != null) ? body.gameObject : collider.gameObject;

		internal bool Flipped
		{
			get
			{
				return m_Flipped;
			}
			set
			{
				m_Flipped = value;
			}
		}

		public int contactCount => (int)m_Pair.m_NbPoints;

		public ContactPoint[] contacts
		{
			get
			{
				if (m_LegacyContacts == null)
				{
					m_LegacyContacts = new ContactPoint[m_Pair.m_NbPoints];
					m_Pair.ExtractContactsArray(m_LegacyContacts, m_Flipped);
				}
				return m_LegacyContacts;
			}
		}

		public Collision()
		{
			m_Header = default(ContactPairHeader);
			m_Pair = default(ContactPair);
			m_Flipped = false;
			m_LegacyContacts = null;
		}

		internal Collision(in ContactPairHeader header, in ContactPair pair, bool flipped)
		{
			m_LegacyContacts = new ContactPoint[pair.m_NbPoints];
			pair.ExtractContactsArray(m_LegacyContacts, flipped);
			m_Header = header;
			m_Pair = pair;
			m_Flipped = flipped;
		}

		internal void Reuse(in ContactPairHeader header, in ContactPair pair)
		{
			m_Header = header;
			m_Pair = pair;
			m_LegacyContacts = null;
			m_Flipped = false;
		}

		public unsafe ContactPoint GetContact(int index)
		{
			if (index < 0 || index >= contactCount)
			{
				throw new ArgumentOutOfRangeException($"Cannot get contact at index {index}. There are {contactCount} contact(s).");
			}
			if (m_LegacyContacts != null)
			{
				return m_LegacyContacts[index];
			}
			float num = (m_Flipped ? (-1f) : 1f);
			ContactPairPoint* contactPoint_Internal = m_Pair.GetContactPoint_Internal(index);
			return new ContactPoint(contactPoint_Internal->m_Position, contactPoint_Internal->m_Normal * num, contactPoint_Internal->m_Impulse, contactPoint_Internal->m_Separation, m_Flipped ? m_Pair.otherColliderInstanceID : m_Pair.colliderInstanceID, m_Flipped ? m_Pair.colliderInstanceID : m_Pair.otherColliderInstanceID);
		}

		public int GetContacts(ContactPoint[] contacts)
		{
			if (contacts == null)
			{
				throw new NullReferenceException("Cannot get contacts as the provided array is NULL.");
			}
			if (m_LegacyContacts != null)
			{
				int num = Mathf.Min(m_LegacyContacts.Length, contacts.Length);
				Array.Copy(m_LegacyContacts, contacts, num);
				return num;
			}
			return m_Pair.ExtractContactsArray(contacts, m_Flipped);
		}

		public int GetContacts(List<ContactPoint> contacts)
		{
			if (contacts == null)
			{
				throw new NullReferenceException("Cannot get contacts as the provided list is NULL.");
			}
			contacts.Clear();
			if (m_LegacyContacts != null)
			{
				contacts.AddRange(m_LegacyContacts);
				return m_LegacyContacts.Length;
			}
			int nbPoints = (int)m_Pair.m_NbPoints;
			if (nbPoints == 0)
			{
				return 0;
			}
			if (contacts.Capacity < nbPoints)
			{
				contacts.Capacity = nbPoints;
			}
			return m_Pair.ExtractContacts(contacts, m_Flipped);
		}
	}
	public enum CollisionDetectionMode
	{
		Discrete,
		Continuous,
		ContinuousDynamic,
		ContinuousSpeculative
	}
	public enum ForceMode
	{
		Force = 0,
		Acceleration = 5,
		Impulse = 1,
		VelocityChange = 2
	}
	public struct SoftJointLimit
	{
		private float m_Limit;

		private float m_Bounciness;

		private float m_ContactDistance;

		public float limit
		{
			get
			{
				return m_Limit;
			}
			set
			{
				m_Limit = value;
			}
		}

		public float bounciness
		{
			get
			{
				return m_Bounciness;
			}
			set
			{
				m_Bounciness = value;
			}
		}

		public float contactDistance
		{
			get
			{
				return m_ContactDistance;
			}
			set
			{
				m_ContactDistance = value;
			}
		}
	}
	public struct SoftJointLimitSpring
	{
		private float m_Spring;

		private float m_Damper;

		public float spring
		{
			get
			{
				return m_Spring;
			}
			set
			{
				m_Spring = value;
			}
		}

		public float damper
		{
			get
			{
				return m_Damper;
			}
			set
			{
				m_Damper = value;
			}
		}
	}
	public struct JointDrive
	{
		private float m_PositionSpring;

		private float m_PositionDamper;

		private float m_MaximumForce;

		private int m_UseAcceleration;

		public float positionSpring
		{
			get
			{
				return m_PositionSpring;
			}
			set
			{
				m_PositionSpring = value;
			}
		}

		public float positionDamper
		{
			get
			{
				return m_PositionDamper;
			}
			set
			{
				m_PositionDamper = value;
			}
		}

		public float maximumForce
		{
			get
			{
				return m_MaximumForce;
			}
			set
			{
				m_MaximumForce = value;
			}
		}

		public bool useAcceleration
		{
			get
			{
				return m_UseAcceleration == 1;
			}
			set
			{
				m_UseAcceleration = (value ? 1 : 0);
			}
		}
	}
	public struct JointMotor
	{
		private float m_TargetVelocity;

		private float m_Force;

		private int m_FreeSpin;

		public float targetVelocity
		{
			get
			{
				return m_TargetVelocity;
			}
			set
			{
				m_TargetVelocity = value;
			}
		}

		public float force
		{
			get
			{
				return m_Force;
			}
			set
			{
				m_Force = value;
			}
		}

		public bool freeSpin
		{
			get
			{
				return m_FreeSpin == 1;
			}
			set
			{
				m_FreeSpin = (value ? 1 : 0);
			}
		}
	}
	public struct JointSpring
	{
		public float spring;

		public float damper;

		public float targetPosition;
	}
	public struct JointLimits
	{
		private float m_Min;

		private float m_Max;

		private float m_Bounciness;

		private float m_BounceMinVelocity;

		private float m_ContactDistance;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("minBounce and maxBounce are replaced by a single JointLimits.bounciness for both limit ends.", true)]
		public float minBounce;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("minBounce and maxBounce are replaced by a single JointLimits.bounciness for both limit ends.", true)]
		public float maxBounce;

		public float min
		{
			get
			{
				return m_Min;
			}
			set
			{
				m_Min = value;
			}
		}

		public float max
		{
			get
			{
				return m_Max;
			}
			set
			{
				m_Max = value;
			}
		}

		public float bounciness
		{
			get
			{
				return m_Bounciness;
			}
			set
			{
				m_Bounciness = value;
			}
		}

		public float bounceMinVelocity
		{
			get
			{
				return m_BounceMinVelocity;
			}
			set
			{
				m_BounceMinVelocity = value;
			}
		}

		public float contactDistance
		{
			get
			{
				return m_ContactDistance;
			}
			set
			{
				m_ContactDistance = value;
			}
		}
	}
	public struct WheelFrictionCurve
	{
		private float m_ExtremumSlip;

		private float m_ExtremumValue;

		private float m_AsymptoteSlip;

		private float m_AsymptoteValue;

		private float m_Stiffness;

		public float extremumSlip
		{
			get
			{
				return m_ExtremumSlip;
			}
			set
			{
				m_ExtremumSlip = value;
			}
		}

		public float extremumValue
		{
			get
			{
				return m_ExtremumValue;
			}
			set
			{
				m_ExtremumValue = value;
			}
		}

		public float asymptoteSlip
		{
			get
			{
				return m_AsymptoteSlip;
			}
			set
			{
				m_AsymptoteSlip = value;
			}
		}

		public float asymptoteValue
		{
			get
			{
				return m_AsymptoteValue;
			}
			set
			{
				m_AsymptoteValue = value;
			}
		}

		public float stiffness
		{
			get
			{
				return m_Stiffness;
			}
			set
			{
				m_Stiffness = value;
			}
		}
	}
	public enum ArticulationJointType
	{
		FixedJoint,
		PrismaticJoint,
		RevoluteJoint,
		SphericalJoint
	}
	public enum ArticulationDofLock
	{
		LockedMotion,
		LimitedMotion,
		FreeMotion
	}
	public enum ArticulationDriveType
	{
		Force,
		Acceleration,
		Target,
		Velocity
	}
	[NativeHeader("Modules/Physics/ArticulationBody.h")]
	public struct ArticulationDrive
	{
		public float lowerLimit;

		public float upperLimit;

		public float stiffness;

		public float damping;

		public float forceLimit;

		public float target;

		public float targetVelocity;

		public ArticulationDriveType driveType;
	}
	[NativeHeader("Modules/Physics/ArticulationBody.h")]
	public struct ArticulationReducedSpace
	{
		private unsafe fixed float x[3];

		public int dofCount;

		public unsafe float this[int i]
		{
			get
			{
				if (i < 0 || i >= dofCount)
				{
					throw new IndexOutOfRangeException();
				}
				return x[i];
			}
			set
			{
				if (i < 0 || i >= dofCount)
				{
					throw new IndexOutOfRangeException();
				}
				x[i] = value;
			}
		}

		public unsafe ArticulationReducedSpace(float a)
		{
			x[0] = a;
			dofCount = 1;
		}

		public unsafe ArticulationReducedSpace(float a, float b)
		{
			x[0] = a;
			x[1] = b;
			dofCount = 2;
		}

		public unsafe ArticulationReducedSpace(float a, float b, float c)
		{
			x[0] = a;
			x[1] = b;
			x[2] = c;
			dofCount = 3;
		}
	}
	[NativeHeader("Modules/Physics/ArticulationBody.h")]
	public struct ArticulationJacobian
	{
		private int rowsCount;

		private int colsCount;

		private List<float> matrixData;

		public float this[int row, int col]
		{
			get
			{
				if (row < 0 || row >= rowsCount)
				{
					throw new IndexOutOfRangeException();
				}
				if (col < 0 || col >= colsCount)
				{
					throw new IndexOutOfRangeException();
				}
				return matrixData[row * colsCount + col];
			}
			set
			{
				if (row < 0 || row >= rowsCount)
				{
					throw new IndexOutOfRangeException();
				}
				if (col < 0 || col >= colsCount)
				{
					throw new IndexOutOfRangeException();
				}
				matrixData[row * colsCount + col] = value;
			}
		}

		public int rows
		{
			get
			{
				return rowsCount;
			}
			set
			{
				rowsCount = value;
			}
		}

		public int columns
		{
			get
			{
				return colsCount;
			}
			set
			{
				colsCount = value;
			}
		}

		public List<float> elements
		{
			get
			{
				return matrixData;
			}
			set
			{
				matrixData = value;
			}
		}

		public ArticulationJacobian(int rows, int cols)
		{
			rowsCount = rows;
			colsCount = cols;
			matrixData = new List<float>(rows * cols);
			for (int i = 0; i < rows * cols; i++)
			{
				matrixData.Add(0f);
			}
		}
	}
	public enum ArticulationDriveAxis
	{
		X,
		Y,
		Z
	}
	[RequireComponent(typeof(Transform))]
	[NativeClass("Physics::ArticulationBody")]
	[NativeHeader("Modules/Physics/ArticulationBody.h")]
	public class ArticulationBody : Behaviour
	{
		public ArticulationJointType jointType
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_jointType_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_jointType_Injected(intPtr, value);
			}
		}

		public Vector3 anchorPosition
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_anchorPosition_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_anchorPosition_Injected(intPtr, ref value);
			}
		}

		public Vector3 parentAnchorPosition
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_parentAnchorPosition_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_parentAnchorPosition_Injected(intPtr, ref value);
			}
		}

		public Quaternion anchorRotation
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_anchorRotation_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_anchorRotation_Injected(intPtr, ref value);
			}
		}

		public Quaternion parentAnchorRotation
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_parentAnchorRotation_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_parentAnchorRotation_Injected(intPtr, ref value);
			}
		}

		public bool isRoot
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isRoot_Injected(intPtr);
			}
		}

		public bool matchAnchors
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_matchAnchors_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_matchAnchors_Injected(intPtr, value);
			}
		}

		public ArticulationDofLock linearLockX
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_linearLockX_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_linearLockX_Injected(intPtr, value);
			}
		}

		public ArticulationDofLock linearLockY
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_linearLockY_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_linearLockY_Injected(intPtr, value);
			}
		}

		public ArticulationDofLock linearLockZ
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_linearLockZ_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_linearLockZ_Injected(intPtr, value);
			}
		}

		public ArticulationDofLock swingYLock
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_swingYLock_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_swingYLock_Injected(intPtr, value);
			}
		}

		public ArticulationDofLock swingZLock
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_swingZLock_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_swingZLock_Injected(intPtr, value);
			}
		}

		public ArticulationDofLock twistLock
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_twistLock_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_twistLock_Injected(intPtr, value);
			}
		}

		public ArticulationDrive xDrive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_xDrive_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_xDrive_Injected(intPtr, ref value);
			}
		}

		public ArticulationDrive yDrive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_yDrive_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_yDrive_Injected(intPtr, ref value);
			}
		}

		public ArticulationDrive zDrive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_zDrive_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_zDrive_Injected(intPtr, ref value);
			}
		}

		public bool immovable
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_immovable_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_immovable_Injected(intPtr, value);
			}
		}

		public bool useGravity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_useGravity_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_useGravity_Injected(intPtr, value);
			}
		}

		public float linearDamping
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_linearDamping_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_linearDamping_Injected(intPtr, value);
			}
		}

		public float angularDamping
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_angularDamping_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_angularDamping_Injected(intPtr, value);
			}
		}

		public float jointFriction
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_jointFriction_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_jointFriction_Injected(intPtr, value);
			}
		}

		public LayerMask excludeLayers
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_excludeLayers_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_excludeLayers_Injected(intPtr, ref value);
			}
		}

		public LayerMask includeLayers
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_includeLayers_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_includeLayers_Injected(intPtr, ref value);
			}
		}

		public Vector3 linearVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_linearVelocity_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_linearVelocity_Injected(intPtr, ref value);
			}
		}

		public Vector3 angularVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_angularVelocity_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_angularVelocity_Injected(intPtr, ref value);
			}
		}

		public float mass
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_mass_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_mass_Injected(intPtr, value);
			}
		}

		public bool automaticCenterOfMass
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_automaticCenterOfMass_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_automaticCenterOfMass_Injected(intPtr, value);
			}
		}

		public Vector3 centerOfMass
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_centerOfMass_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_centerOfMass_Injected(intPtr, ref value);
			}
		}

		public Vector3 worldCenterOfMass
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_worldCenterOfMass_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public bool automaticInertiaTensor
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_automaticInertiaTensor_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_automaticInertiaTensor_Injected(intPtr, value);
			}
		}

		public Vector3 inertiaTensor
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_inertiaTensor_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_inertiaTensor_Injected(intPtr, ref value);
			}
		}

		internal Matrix4x4 worldInertiaTensorMatrix
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_worldInertiaTensorMatrix_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public Quaternion inertiaTensorRotation
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_inertiaTensorRotation_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_inertiaTensorRotation_Injected(intPtr, ref value);
			}
		}

		public float sleepThreshold
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_sleepThreshold_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_sleepThreshold_Injected(intPtr, value);
			}
		}

		public int solverIterations
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_solverIterations_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_solverIterations_Injected(intPtr, value);
			}
		}

		public int solverVelocityIterations
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_solverVelocityIterations_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_solverVelocityIterations_Injected(intPtr, value);
			}
		}

		public float maxAngularVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_maxAngularVelocity_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_maxAngularVelocity_Injected(intPtr, value);
			}
		}

		public float maxLinearVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_maxLinearVelocity_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_maxLinearVelocity_Injected(intPtr, value);
			}
		}

		public float maxJointVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_maxJointVelocity_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_maxJointVelocity_Injected(intPtr, value);
			}
		}

		public float maxDepenetrationVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_maxDepenetrationVelocity_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_maxDepenetrationVelocity_Injected(intPtr, value);
			}
		}

		public ArticulationReducedSpace jointPosition
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_jointPosition_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_jointPosition_Injected(intPtr, ref value);
			}
		}

		public ArticulationReducedSpace jointVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_jointVelocity_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_jointVelocity_Injected(intPtr, ref value);
			}
		}

		public ArticulationReducedSpace jointAcceleration
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_jointAcceleration_Injected(intPtr, out var ret);
				return ret;
			}
			[Obsolete("Setting joint accelerations is not supported in forward kinematics. To have inverse dynamics take acceleration into account, use GetJointForcesForAcceleration instead", true)]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_jointAcceleration_Injected(intPtr, ref value);
			}
		}

		public ArticulationReducedSpace jointForce
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_jointForce_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_jointForce_Injected(intPtr, ref value);
			}
		}

		public ArticulationReducedSpace driveForce
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_driveForce_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public int dofCount
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_dofCount_Injected(intPtr);
			}
		}

		public int index
		{
			[NativeMethod("GetBodyIndex")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_index_Injected(intPtr);
			}
		}

		public CollisionDetectionMode collisionDetectionMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_collisionDetectionMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_collisionDetectionMode_Injected(intPtr, value);
			}
		}

		[Obsolete("Please use ArticulationBody.linearVelocity instead. (UnityUpgradable) -> linearVelocity")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3 velocity
		{
			get
			{
				return linearVelocity;
			}
			set
			{
				linearVelocity = value;
			}
		}

		[Obsolete("computeParentAnchor has been renamed to matchAnchors (UnityUpgradable) -> matchAnchors")]
		public bool computeParentAnchor
		{
			get
			{
				return matchAnchors;
			}
			set
			{
				matchAnchors = value;
			}
		}

		public Vector3 GetAccumulatedForce([UnityEngine.Internal.DefaultValue("Time.fixedDeltaTime")] float step)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetAccumulatedForce_Injected(intPtr, step, out var ret);
			return ret;
		}

		[ExcludeFromDocs]
		public Vector3 GetAccumulatedForce()
		{
			return GetAccumulatedForce(Time.fixedDeltaTime);
		}

		public Vector3 GetAccumulatedTorque([UnityEngine.Internal.DefaultValue("Time.fixedDeltaTime")] float step)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetAccumulatedTorque_Injected(intPtr, step, out var ret);
			return ret;
		}

		[ExcludeFromDocs]
		public Vector3 GetAccumulatedTorque()
		{
			return GetAccumulatedTorque(Time.fixedDeltaTime);
		}

		public void AddForce(Vector3 force, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddForce_Injected(intPtr, ref force, mode);
		}

		[ExcludeFromDocs]
		public void AddForce(Vector3 force)
		{
			AddForce(force, ForceMode.Force);
		}

		public void AddRelativeForce(Vector3 force, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddRelativeForce_Injected(intPtr, ref force, mode);
		}

		[ExcludeFromDocs]
		public void AddRelativeForce(Vector3 force)
		{
			AddRelativeForce(force, ForceMode.Force);
		}

		public void AddTorque(Vector3 torque, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddTorque_Injected(intPtr, ref torque, mode);
		}

		[ExcludeFromDocs]
		public void AddTorque(Vector3 torque)
		{
			AddTorque(torque, ForceMode.Force);
		}

		public void AddRelativeTorque(Vector3 torque, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddRelativeTorque_Injected(intPtr, ref torque, mode);
		}

		[ExcludeFromDocs]
		public void AddRelativeTorque(Vector3 torque)
		{
			AddRelativeTorque(torque, ForceMode.Force);
		}

		public void AddForceAtPosition(Vector3 force, Vector3 position, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddForceAtPosition_Injected(intPtr, ref force, ref position, mode);
		}

		[ExcludeFromDocs]
		public void AddForceAtPosition(Vector3 force, Vector3 position)
		{
			AddForceAtPosition(force, position, ForceMode.Force);
		}

		public void ResetCenterOfMass()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ResetCenterOfMass_Injected(intPtr);
		}

		public void ResetInertiaTensor()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ResetInertiaTensor_Injected(intPtr);
		}

		public void Sleep()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Sleep_Injected(intPtr);
		}

		public bool IsSleeping()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IsSleeping_Injected(intPtr);
		}

		public void WakeUp()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			WakeUp_Injected(intPtr);
		}

		public void TeleportRoot(Vector3 position, Quaternion rotation)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			TeleportRoot_Injected(intPtr, ref position, ref rotation);
		}

		public Vector3 GetClosestPoint(Vector3 point)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetClosestPoint_Injected(intPtr, ref point, out var ret);
			return ret;
		}

		public Vector3 GetRelativePointVelocity(Vector3 relativePoint)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetRelativePointVelocity_Injected(intPtr, ref relativePoint, out var ret);
			return ret;
		}

		public Vector3 GetPointVelocity(Vector3 worldPoint)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetPointVelocity_Injected(intPtr, ref worldPoint, out var ret);
			return ret;
		}

		[NativeMethod("GetDenseJacobian")]
		private int GetDenseJacobian_Internal(ref ArticulationJacobian jacobian)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetDenseJacobian_Internal_Injected(intPtr, ref jacobian);
		}

		public int GetDenseJacobian(ref ArticulationJacobian jacobian)
		{
			if (jacobian.elements == null)
			{
				jacobian.elements = new List<float>();
			}
			return GetDenseJacobian_Internal(ref jacobian);
		}

		public unsafe int GetJointPositions(List<float> positions)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper positions2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = positions;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						positions2 = new BlittableListWrapper(arrayWrapper, list.Count);
						return GetJointPositions_Injected(intPtr, ref positions2);
					}
				}
				return GetJointPositions_Injected(intPtr, ref positions2);
			}
			finally
			{
				positions2.Unmarshal(list);
			}
		}

		public unsafe void SetJointPositions(List<float> positions)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper positions2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = positions;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						positions2 = new BlittableListWrapper(arrayWrapper, list.Count);
						SetJointPositions_Injected(intPtr, ref positions2);
						return;
					}
				}
				SetJointPositions_Injected(intPtr, ref positions2);
			}
			finally
			{
				positions2.Unmarshal(list);
			}
		}

		public unsafe int GetJointVelocities(List<float> velocities)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper velocities2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = velocities;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						velocities2 = new BlittableListWrapper(arrayWrapper, list.Count);
						return GetJointVelocities_Injected(intPtr, ref velocities2);
					}
				}
				return GetJointVelocities_Injected(intPtr, ref velocities2);
			}
			finally
			{
				velocities2.Unmarshal(list);
			}
		}

		public unsafe void SetJointVelocities(List<float> velocities)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper velocities2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = velocities;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						velocities2 = new BlittableListWrapper(arrayWrapper, list.Count);
						SetJointVelocities_Injected(intPtr, ref velocities2);
						return;
					}
				}
				SetJointVelocities_Injected(intPtr, ref velocities2);
			}
			finally
			{
				velocities2.Unmarshal(list);
			}
		}

		public unsafe int GetJointAccelerations(List<float> accelerations)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper accelerations2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = accelerations;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						accelerations2 = new BlittableListWrapper(arrayWrapper, list.Count);
						return GetJointAccelerations_Injected(intPtr, ref accelerations2);
					}
				}
				return GetJointAccelerations_Injected(intPtr, ref accelerations2);
			}
			finally
			{
				accelerations2.Unmarshal(list);
			}
		}

		public unsafe int GetJointForces(List<float> forces)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper forces2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = forces;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						forces2 = new BlittableListWrapper(arrayWrapper, list.Count);
						return GetJointForces_Injected(intPtr, ref forces2);
					}
				}
				return GetJointForces_Injected(intPtr, ref forces2);
			}
			finally
			{
				forces2.Unmarshal(list);
			}
		}

		public unsafe void SetJointForces(List<float> forces)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper forces2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = forces;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						forces2 = new BlittableListWrapper(arrayWrapper, list.Count);
						SetJointForces_Injected(intPtr, ref forces2);
						return;
					}
				}
				SetJointForces_Injected(intPtr, ref forces2);
			}
			finally
			{
				forces2.Unmarshal(list);
			}
		}

		public ArticulationReducedSpace GetJointForcesForAcceleration(ArticulationReducedSpace acceleration)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetJointForcesForAcceleration_Injected(intPtr, ref acceleration, out var ret);
			return ret;
		}

		public unsafe int GetDriveForces(List<float> forces)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper forces2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = forces;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						forces2 = new BlittableListWrapper(arrayWrapper, list.Count);
						return GetDriveForces_Injected(intPtr, ref forces2);
					}
				}
				return GetDriveForces_Injected(intPtr, ref forces2);
			}
			finally
			{
				forces2.Unmarshal(list);
			}
		}

		public unsafe int GetJointGravityForces(List<float> forces)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper forces2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = forces;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						forces2 = new BlittableListWrapper(arrayWrapper, list.Count);
						return GetJointGravityForces_Injected(intPtr, ref forces2);
					}
				}
				return GetJointGravityForces_Injected(intPtr, ref forces2);
			}
			finally
			{
				forces2.Unmarshal(list);
			}
		}

		public unsafe int GetJointCoriolisCentrifugalForces(List<float> forces)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper forces2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = forces;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						forces2 = new BlittableListWrapper(arrayWrapper, list.Count);
						return GetJointCoriolisCentrifugalForces_Injected(intPtr, ref forces2);
					}
				}
				return GetJointCoriolisCentrifugalForces_Injected(intPtr, ref forces2);
			}
			finally
			{
				forces2.Unmarshal(list);
			}
		}

		public unsafe int GetJointExternalForces(List<float> forces, float step)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper forces2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = forces;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						forces2 = new BlittableListWrapper(arrayWrapper, list.Count);
						return GetJointExternalForces_Injected(intPtr, ref forces2, step);
					}
				}
				return GetJointExternalForces_Injected(intPtr, ref forces2, step);
			}
			finally
			{
				forces2.Unmarshal(list);
			}
		}

		public unsafe int GetDriveTargets(List<float> targets)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper targets2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = targets;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						targets2 = new BlittableListWrapper(arrayWrapper, list.Count);
						return GetDriveTargets_Injected(intPtr, ref targets2);
					}
				}
				return GetDriveTargets_Injected(intPtr, ref targets2);
			}
			finally
			{
				targets2.Unmarshal(list);
			}
		}

		public unsafe void SetDriveTargets(List<float> targets)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper targets2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = targets;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						targets2 = new BlittableListWrapper(arrayWrapper, list.Count);
						SetDriveTargets_Injected(intPtr, ref targets2);
						return;
					}
				}
				SetDriveTargets_Injected(intPtr, ref targets2);
			}
			finally
			{
				targets2.Unmarshal(list);
			}
		}

		public unsafe int GetDriveTargetVelocities(List<float> targetVelocities)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper targetVelocities2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = targetVelocities;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						targetVelocities2 = new BlittableListWrapper(arrayWrapper, list.Count);
						return GetDriveTargetVelocities_Injected(intPtr, ref targetVelocities2);
					}
				}
				return GetDriveTargetVelocities_Injected(intPtr, ref targetVelocities2);
			}
			finally
			{
				targetVelocities2.Unmarshal(list);
			}
		}

		public unsafe void SetDriveTargetVelocities(List<float> targetVelocities)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper targetVelocities2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = targetVelocities;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						targetVelocities2 = new BlittableListWrapper(arrayWrapper, list.Count);
						SetDriveTargetVelocities_Injected(intPtr, ref targetVelocities2);
						return;
					}
				}
				SetDriveTargetVelocities_Injected(intPtr, ref targetVelocities2);
			}
			finally
			{
				targetVelocities2.Unmarshal(list);
			}
		}

		public unsafe int GetDofStartIndices(List<int> dofStartIndices)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<int> list = default(List<int>);
			BlittableListWrapper dofStartIndices2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = dofStartIndices;
				if (list != null)
				{
					fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						dofStartIndices2 = new BlittableListWrapper(arrayWrapper, list.Count);
						return GetDofStartIndices_Injected(intPtr, ref dofStartIndices2);
					}
				}
				return GetDofStartIndices_Injected(intPtr, ref dofStartIndices2);
			}
			finally
			{
				dofStartIndices2.Unmarshal(list);
			}
		}

		public void SetDriveTarget(ArticulationDriveAxis axis, float value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetDriveTarget_Injected(intPtr, axis, value);
		}

		public void SetDriveTargetVelocity(ArticulationDriveAxis axis, float value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetDriveTargetVelocity_Injected(intPtr, axis, value);
		}

		public void SetDriveLimits(ArticulationDriveAxis axis, float lower, float upper)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetDriveLimits_Injected(intPtr, axis, lower, upper);
		}

		public void SetDriveStiffness(ArticulationDriveAxis axis, float value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetDriveStiffness_Injected(intPtr, axis, value);
		}

		public void SetDriveDamping(ArticulationDriveAxis axis, float value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetDriveDamping_Injected(intPtr, axis, value);
		}

		public void SetDriveForceLimit(ArticulationDriveAxis axis, float value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetDriveForceLimit_Injected(intPtr, axis, value);
		}

		public void PublishTransform()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			PublishTransform_Injected(intPtr);
		}

		public void SnapAnchorToClosestContact()
		{
			if ((bool)base.transform.parent)
			{
				ArticulationBody componentInParent = base.transform.parent.GetComponentInParent<ArticulationBody>();
				while ((bool)componentInParent && !componentInParent.enabled)
				{
					componentInParent = componentInParent.transform.parent.GetComponentInParent<ArticulationBody>();
				}
				if ((bool)componentInParent)
				{
					Vector3 vector = componentInParent.worldCenterOfMass;
					Vector3 closestPoint = GetClosestPoint(vector);
					anchorPosition = base.transform.InverseTransformPoint(closestPoint);
					anchorRotation = Quaternion.FromToRotation(Vector3.right, base.transform.InverseTransformDirection(vector - closestPoint).normalized);
				}
			}
		}

		[Obsolete("Setting joint accelerations is not supported in forward kinematics. To have inverse dynamics take acceleration into account, use GetJointForcesForAcceleration instead", true)]
		public unsafe void SetJointAccelerations(List<float> accelerations)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<float> list = default(List<float>);
			BlittableListWrapper accelerations2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = accelerations;
				if (list != null)
				{
					fixed (float[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						accelerations2 = new BlittableListWrapper(arrayWrapper, list.Count);
						SetJointAccelerations_Injected(intPtr, ref accelerations2);
						return;
					}
				}
				SetJointAccelerations_Injected(intPtr, ref accelerations2);
			}
			finally
			{
				accelerations2.Unmarshal(list);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ArticulationJointType get_jointType_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_jointType_Injected(IntPtr _unity_self, ArticulationJointType value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_anchorPosition_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_anchorPosition_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_parentAnchorPosition_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_parentAnchorPosition_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_anchorRotation_Injected(IntPtr _unity_self, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_anchorRotation_Injected(IntPtr _unity_self, [In] ref Quaternion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_parentAnchorRotation_Injected(IntPtr _unity_self, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_parentAnchorRotation_Injected(IntPtr _unity_self, [In] ref Quaternion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isRoot_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_matchAnchors_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_matchAnchors_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ArticulationDofLock get_linearLockX_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_linearLockX_Injected(IntPtr _unity_self, ArticulationDofLock value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ArticulationDofLock get_linearLockY_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_linearLockY_Injected(IntPtr _unity_self, ArticulationDofLock value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ArticulationDofLock get_linearLockZ_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_linearLockZ_Injected(IntPtr _unity_self, ArticulationDofLock value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ArticulationDofLock get_swingYLock_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_swingYLock_Injected(IntPtr _unity_self, ArticulationDofLock value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ArticulationDofLock get_swingZLock_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_swingZLock_Injected(IntPtr _unity_self, ArticulationDofLock value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ArticulationDofLock get_twistLock_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_twistLock_Injected(IntPtr _unity_self, ArticulationDofLock value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_xDrive_Injected(IntPtr _unity_self, out ArticulationDrive ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_xDrive_Injected(IntPtr _unity_self, [In] ref ArticulationDrive value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_yDrive_Injected(IntPtr _unity_self, out ArticulationDrive ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_yDrive_Injected(IntPtr _unity_self, [In] ref ArticulationDrive value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_zDrive_Injected(IntPtr _unity_self, out ArticulationDrive ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_zDrive_Injected(IntPtr _unity_self, [In] ref ArticulationDrive value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_immovable_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_immovable_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_useGravity_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_useGravity_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_linearDamping_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_linearDamping_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_angularDamping_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_angularDamping_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_jointFriction_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_jointFriction_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_excludeLayers_Injected(IntPtr _unity_self, out LayerMask ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_excludeLayers_Injected(IntPtr _unity_self, [In] ref LayerMask value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_includeLayers_Injected(IntPtr _unity_self, out LayerMask ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_includeLayers_Injected(IntPtr _unity_self, [In] ref LayerMask value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAccumulatedForce_Injected(IntPtr _unity_self, [UnityEngine.Internal.DefaultValue("Time.fixedDeltaTime")] float step, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAccumulatedTorque_Injected(IntPtr _unity_self, [UnityEngine.Internal.DefaultValue("Time.fixedDeltaTime")] float step, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddForce_Injected(IntPtr _unity_self, [In] ref Vector3 force, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddRelativeForce_Injected(IntPtr _unity_self, [In] ref Vector3 force, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddTorque_Injected(IntPtr _unity_self, [In] ref Vector3 torque, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddRelativeTorque_Injected(IntPtr _unity_self, [In] ref Vector3 torque, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddForceAtPosition_Injected(IntPtr _unity_self, [In] ref Vector3 force, [In] ref Vector3 position, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_linearVelocity_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_linearVelocity_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_angularVelocity_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_angularVelocity_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_mass_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_mass_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_automaticCenterOfMass_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_automaticCenterOfMass_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_centerOfMass_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_centerOfMass_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_worldCenterOfMass_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_automaticInertiaTensor_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_automaticInertiaTensor_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_inertiaTensor_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_inertiaTensor_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_worldInertiaTensorMatrix_Injected(IntPtr _unity_self, out Matrix4x4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_inertiaTensorRotation_Injected(IntPtr _unity_self, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_inertiaTensorRotation_Injected(IntPtr _unity_self, [In] ref Quaternion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResetCenterOfMass_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResetInertiaTensor_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Sleep_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsSleeping_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void WakeUp_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_sleepThreshold_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_sleepThreshold_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_solverIterations_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_solverIterations_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_solverVelocityIterations_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_solverVelocityIterations_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_maxAngularVelocity_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_maxAngularVelocity_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_maxLinearVelocity_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_maxLinearVelocity_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_maxJointVelocity_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_maxJointVelocity_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_maxDepenetrationVelocity_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_maxDepenetrationVelocity_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_jointPosition_Injected(IntPtr _unity_self, out ArticulationReducedSpace ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_jointPosition_Injected(IntPtr _unity_self, [In] ref ArticulationReducedSpace value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_jointVelocity_Injected(IntPtr _unity_self, out ArticulationReducedSpace ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_jointVelocity_Injected(IntPtr _unity_self, [In] ref ArticulationReducedSpace value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_jointAcceleration_Injected(IntPtr _unity_self, out ArticulationReducedSpace ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_jointAcceleration_Injected(IntPtr _unity_self, [In] ref ArticulationReducedSpace value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_jointForce_Injected(IntPtr _unity_self, out ArticulationReducedSpace ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_jointForce_Injected(IntPtr _unity_self, [In] ref ArticulationReducedSpace value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_driveForce_Injected(IntPtr _unity_self, out ArticulationReducedSpace ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_dofCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_index_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void TeleportRoot_Injected(IntPtr _unity_self, [In] ref Vector3 position, [In] ref Quaternion rotation);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetClosestPoint_Injected(IntPtr _unity_self, [In] ref Vector3 point, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRelativePointVelocity_Injected(IntPtr _unity_self, [In] ref Vector3 relativePoint, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetPointVelocity_Injected(IntPtr _unity_self, [In] ref Vector3 worldPoint, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetDenseJacobian_Internal_Injected(IntPtr _unity_self, ref ArticulationJacobian jacobian);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetJointPositions_Injected(IntPtr _unity_self, ref BlittableListWrapper positions);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetJointPositions_Injected(IntPtr _unity_self, ref BlittableListWrapper positions);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetJointVelocities_Injected(IntPtr _unity_self, ref BlittableListWrapper velocities);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetJointVelocities_Injected(IntPtr _unity_self, ref BlittableListWrapper velocities);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetJointAccelerations_Injected(IntPtr _unity_self, ref BlittableListWrapper accelerations);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetJointForces_Injected(IntPtr _unity_self, ref BlittableListWrapper forces);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetJointForces_Injected(IntPtr _unity_self, ref BlittableListWrapper forces);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetJointForcesForAcceleration_Injected(IntPtr _unity_self, [In] ref ArticulationReducedSpace acceleration, out ArticulationReducedSpace ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetDriveForces_Injected(IntPtr _unity_self, ref BlittableListWrapper forces);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetJointGravityForces_Injected(IntPtr _unity_self, ref BlittableListWrapper forces);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetJointCoriolisCentrifugalForces_Injected(IntPtr _unity_self, ref BlittableListWrapper forces);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetJointExternalForces_Injected(IntPtr _unity_self, ref BlittableListWrapper forces, float step);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetDriveTargets_Injected(IntPtr _unity_self, ref BlittableListWrapper targets);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetDriveTargets_Injected(IntPtr _unity_self, ref BlittableListWrapper targets);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetDriveTargetVelocities_Injected(IntPtr _unity_self, ref BlittableListWrapper targetVelocities);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetDriveTargetVelocities_Injected(IntPtr _unity_self, ref BlittableListWrapper targetVelocities);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetDofStartIndices_Injected(IntPtr _unity_self, ref BlittableListWrapper dofStartIndices);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetDriveTarget_Injected(IntPtr _unity_self, ArticulationDriveAxis axis, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetDriveTargetVelocity_Injected(IntPtr _unity_self, ArticulationDriveAxis axis, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetDriveLimits_Injected(IntPtr _unity_self, ArticulationDriveAxis axis, float lower, float upper);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetDriveStiffness_Injected(IntPtr _unity_self, ArticulationDriveAxis axis, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetDriveDamping_Injected(IntPtr _unity_self, ArticulationDriveAxis axis, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetDriveForceLimit_Injected(IntPtr _unity_self, ArticulationDriveAxis axis, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern CollisionDetectionMode get_collisionDetectionMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_collisionDetectionMode_Injected(IntPtr _unity_self, CollisionDetectionMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PublishTransform_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetJointAccelerations_Injected(IntPtr _unity_self, ref BlittableListWrapper accelerations);
	}
	[NativeHeader("Modules/Physics/BoxCollider.h")]
	[RequireComponent(typeof(Transform))]
	public class BoxCollider : Collider
	{
		public Vector3 center
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_center_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_center_Injected(intPtr, ref value);
			}
		}

		public Vector3 size
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_size_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_size_Injected(intPtr, ref value);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_center_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_center_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_size_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_size_Injected(IntPtr _unity_self, [In] ref Vector3 value);
	}
	[NativeHeader("Modules/Physics/CapsuleCollider.h")]
	[RequireComponent(typeof(Transform))]
	public class CapsuleCollider : Collider
	{
		public Vector3 center
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_center_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_center_Injected(intPtr, ref value);
			}
		}

		public float radius
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_radius_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_radius_Injected(intPtr, value);
			}
		}

		public float height
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_height_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_height_Injected(intPtr, value);
			}
		}

		public int direction
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_direction_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_direction_Injected(intPtr, value);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_center_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_center_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_radius_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_radius_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_height_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_height_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_direction_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_direction_Injected(IntPtr _unity_self, int value);
	}
	public enum CollisionFlags
	{
		None = 0,
		Sides = 1,
		Above = 2,
		Below = 4,
		CollidedSides = 1,
		CollidedAbove = 2,
		CollidedBelow = 4
	}
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode]
	public class ControllerColliderHit
	{
		internal CharacterController m_Controller;

		internal Collider m_Collider;

		internal Vector3 m_Point;

		internal Vector3 m_Normal;

		internal Vector3 m_MoveDirection;

		internal float m_MoveLength;

		internal int m_Push;

		public CharacterController controller => m_Controller;

		public Collider collider => m_Collider;

		public Rigidbody rigidbody => m_Collider.attachedRigidbody;

		public GameObject gameObject => m_Collider.gameObject;

		public Transform transform => m_Collider.transform;

		public Vector3 point => m_Point;

		public Vector3 normal => m_Normal;

		public Vector3 moveDirection => m_MoveDirection;

		public float moveLength => m_MoveLength;

		private bool push
		{
			get
			{
				return m_Push != 0;
			}
			set
			{
				m_Push = (value ? 1 : 0);
			}
		}
	}
	[NativeHeader("Modules/Physics/CharacterController.h")]
	public class CharacterController : Collider
	{
		public Vector3 velocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_velocity_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public bool isGrounded
		{
			[NativeName("IsGrounded")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isGrounded_Injected(intPtr);
			}
		}

		public CollisionFlags collisionFlags
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_collisionFlags_Injected(intPtr);
			}
		}

		public float radius
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_radius_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_radius_Injected(intPtr, value);
			}
		}

		public float height
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_height_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_height_Injected(intPtr, value);
			}
		}

		public Vector3 center
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_center_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_center_Injected(intPtr, ref value);
			}
		}

		public float slopeLimit
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_slopeLimit_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_slopeLimit_Injected(intPtr, value);
			}
		}

		public float stepOffset
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_stepOffset_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_stepOffset_Injected(intPtr, value);
			}
		}

		public float skinWidth
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_skinWidth_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_skinWidth_Injected(intPtr, value);
			}
		}

		public float minMoveDistance
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_minMoveDistance_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_minMoveDistance_Injected(intPtr, value);
			}
		}

		public bool detectCollisions
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_detectCollisions_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_detectCollisions_Injected(intPtr, value);
			}
		}

		public bool enableOverlapRecovery
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_enableOverlapRecovery_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_enableOverlapRecovery_Injected(intPtr, value);
			}
		}

		internal bool isSupported
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isSupported_Injected(intPtr);
			}
		}

		public bool SimpleMove(Vector3 speed)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SimpleMove_Injected(intPtr, ref speed);
		}

		public CollisionFlags Move(Vector3 motion)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Move_Injected(intPtr, ref motion);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SimpleMove_Injected(IntPtr _unity_self, [In] ref Vector3 speed);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern CollisionFlags Move_Injected(IntPtr _unity_self, [In] ref Vector3 motion);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_velocity_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isGrounded_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern CollisionFlags get_collisionFlags_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_radius_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_radius_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_height_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_height_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_center_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_center_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_slopeLimit_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_slopeLimit_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_stepOffset_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_stepOffset_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_skinWidth_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_skinWidth_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_minMoveDistance_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_minMoveDistance_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_detectCollisions_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_detectCollisions_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_enableOverlapRecovery_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_enableOverlapRecovery_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isSupported_Injected(IntPtr _unity_self);
	}
	[RequireComponent(typeof(Rigidbody))]
	[NativeClass("Unity::CharacterJoint")]
	[NativeHeader("Modules/Physics/CharacterJoint.h")]
	public class CharacterJoint : Joint
	{
		public Vector3 swingAxis
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_swingAxis_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_swingAxis_Injected(intPtr, ref value);
			}
		}

		public SoftJointLimitSpring twistLimitSpring
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_twistLimitSpring_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_twistLimitSpring_Injected(intPtr, ref value);
			}
		}

		public SoftJointLimitSpring swingLimitSpring
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_swingLimitSpring_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_swingLimitSpring_Injected(intPtr, ref value);
			}
		}

		public SoftJointLimit lowTwistLimit
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_lowTwistLimit_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_lowTwistLimit_Injected(intPtr, ref value);
			}
		}

		public SoftJointLimit highTwistLimit
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_highTwistLimit_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_highTwistLimit_Injected(intPtr, ref value);
			}
		}

		public SoftJointLimit swing1Limit
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_swing1Limit_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_swing1Limit_Injected(intPtr, ref value);
			}
		}

		public SoftJointLimit swing2Limit
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_swing2Limit_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_swing2Limit_Injected(intPtr, ref value);
			}
		}

		public bool enableProjection
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_enableProjection_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_enableProjection_Injected(intPtr, value);
			}
		}

		public float projectionDistance
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_projectionDistance_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_projectionDistance_Injected(intPtr, value);
			}
		}

		public float projectionAngle
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_projectionAngle_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_projectionAngle_Injected(intPtr, value);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_swingAxis_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_swingAxis_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_twistLimitSpring_Injected(IntPtr _unity_self, out SoftJointLimitSpring ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_twistLimitSpring_Injected(IntPtr _unity_self, [In] ref SoftJointLimitSpring value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_swingLimitSpring_Injected(IntPtr _unity_self, out SoftJointLimitSpring ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_swingLimitSpring_Injected(IntPtr _unity_self, [In] ref SoftJointLimitSpring value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_lowTwistLimit_Injected(IntPtr _unity_self, out SoftJointLimit ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_lowTwistLimit_Injected(IntPtr _unity_self, [In] ref SoftJointLimit value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_highTwistLimit_Injected(IntPtr _unity_self, out SoftJointLimit ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_highTwistLimit_Injected(IntPtr _unity_self, [In] ref SoftJointLimit value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_swing1Limit_Injected(IntPtr _unity_self, out SoftJointLimit ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_swing1Limit_Injected(IntPtr _unity_self, [In] ref SoftJointLimit value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_swing2Limit_Injected(IntPtr _unity_self, out SoftJointLimit ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_swing2Limit_Injected(IntPtr _unity_self, [In] ref SoftJointLimit value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_enableProjection_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_enableProjection_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_projectionDistance_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_projectionDistance_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_projectionAngle_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_projectionAngle_Injected(IntPtr _unity_self, float value);
	}
	[NativeHeader("Modules/Physics/Collider.h")]
	public class Collider : Component
	{
		public bool enabled
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_enabled_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_enabled_Injected(intPtr, value);
			}
		}

		public Rigidbody attachedRigidbody
		{
			[NativeMethod("GetRigidbody")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<Rigidbody>(get_attachedRigidbody_Injected(intPtr));
			}
		}

		public ArticulationBody attachedArticulationBody
		{
			[NativeMethod("GetArticulationBody")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<ArticulationBody>(get_attachedArticulationBody_Injected(intPtr));
			}
		}

		public bool isTrigger
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isTrigger_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_isTrigger_Injected(intPtr, value);
			}
		}

		public float contactOffset
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_contactOffset_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_contactOffset_Injected(intPtr, value);
			}
		}

		public Bounds bounds
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_bounds_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public bool hasModifiableContacts
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_hasModifiableContacts_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_hasModifiableContacts_Injected(intPtr, value);
			}
		}

		public bool providesContacts
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_providesContacts_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_providesContacts_Injected(intPtr, value);
			}
		}

		public int layerOverridePriority
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_layerOverridePriority_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_layerOverridePriority_Injected(intPtr, value);
			}
		}

		public LayerMask excludeLayers
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_excludeLayers_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_excludeLayers_Injected(intPtr, ref value);
			}
		}

		public LayerMask includeLayers
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_includeLayers_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_includeLayers_Injected(intPtr, ref value);
			}
		}

		public GeometryHolder GeometryHolder
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_GeometryHolder_Injected(intPtr, out var ret);
				return ret;
			}
		}

		[NativeMethod("Material")]
		public PhysicsMaterial sharedMaterial
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<PhysicsMaterial>(get_sharedMaterial_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_sharedMaterial_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public PhysicsMaterial material
		{
			[NativeMethod("GetClonedMaterial")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<PhysicsMaterial>(get_material_Injected(intPtr));
			}
			[NativeMethod("SetMaterial")]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_material_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public Vector3 ClosestPoint(Vector3 position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ClosestPoint_Injected(intPtr, ref position, out var ret);
			return ret;
		}

		public T GetGeometry<T>() where T : struct, IGeometry
		{
			return GeometryHolder.As<T>();
		}

		private RaycastHit Raycast(Ray ray, float maxDistance, ref bool hasHit)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Raycast_Injected(intPtr, ref ray, maxDistance, ref hasHit, out var ret);
			return ret;
		}

		public bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance)
		{
			bool hasHit = false;
			hitInfo = Raycast(ray, maxDistance, ref hasHit);
			return hasHit;
		}

		[NativeName("ClosestPointOnBounds")]
		private void Internal_ClosestPointOnBounds(Vector3 point, ref Vector3 outPos, ref float distance)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Internal_ClosestPointOnBounds_Injected(intPtr, ref point, ref outPos, ref distance);
		}

		public Vector3 ClosestPointOnBounds(Vector3 position)
		{
			float distance = 0f;
			Vector3 outPos = Vector3.zero;
			Internal_ClosestPointOnBounds(position, ref outPos, ref distance);
			return outPos;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_enabled_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_enabled_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_attachedRigidbody_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_attachedArticulationBody_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isTrigger_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_isTrigger_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_contactOffset_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_contactOffset_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ClosestPoint_Injected(IntPtr _unity_self, [In] ref Vector3 position, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_bounds_Injected(IntPtr _unity_self, out Bounds ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_hasModifiableContacts_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_hasModifiableContacts_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_providesContacts_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_providesContacts_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_layerOverridePriority_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_layerOverridePriority_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_excludeLayers_Injected(IntPtr _unity_self, out LayerMask ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_excludeLayers_Injected(IntPtr _unity_self, [In] ref LayerMask value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_includeLayers_Injected(IntPtr _unity_self, out LayerMask ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_includeLayers_Injected(IntPtr _unity_self, [In] ref LayerMask value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_GeometryHolder_Injected(IntPtr _unity_self, out GeometryHolder ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_sharedMaterial_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_sharedMaterial_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_material_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_material_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Raycast_Injected(IntPtr _unity_self, [In] ref Ray ray, float maxDistance, ref bool hasHit, out RaycastHit ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_ClosestPointOnBounds_Injected(IntPtr _unity_self, [In] ref Vector3 point, ref Vector3 outPos, ref float distance);
	}
	public enum JointProjectionMode
	{
		None,
		PositionAndRotation,
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("JointProjectionMode.PositionOnly is no longer supported", true)]
		PositionOnly
	}
	public enum RotationDriveMode
	{
		XYAndZ,
		Slerp
	}
	public enum ConfigurableJointMotion
	{
		Locked,
		Limited,
		Free
	}
	[RequireComponent(typeof(Rigidbody))]
	[NativeHeader("Modules/Physics/ConfigurableJoint.h")]
	[NativeClass("Unity::ConfigurableJoint")]
	public class ConfigurableJoint : Joint
	{
		public Vector3 secondaryAxis
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_secondaryAxis_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_secondaryAxis_Injected(intPtr, ref value);
			}
		}

		public ConfigurableJointMotion xMotion
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_xMotion_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_xMotion_Injected(intPtr, value);
			}
		}

		public ConfigurableJointMotion yMotion
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_yMotion_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_yMotion_Injected(intPtr, value);
			}
		}

		public ConfigurableJointMotion zMotion
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_zMotion_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_zMotion_Injected(intPtr, value);
			}
		}

		public ConfigurableJointMotion angularXMotion
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_angularXMotion_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_angularXMotion_Injected(intPtr, value);
			}
		}

		public ConfigurableJointMotion angularYMotion
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_angularYMotion_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_angularYMotion_Injected(intPtr, value);
			}
		}

		public ConfigurableJointMotion angularZMotion
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_angularZMotion_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_angularZMotion_Injected(intPtr, value);
			}
		}

		public SoftJointLimitSpring linearLimitSpring
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_linearLimitSpring_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_linearLimitSpring_Injected(intPtr, ref value);
			}
		}

		public SoftJointLimitSpring angularXLimitSpring
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_angularXLimitSpring_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_angularXLimitSpring_Injected(intPtr, ref value);
			}
		}

		public SoftJointLimitSpring angularYZLimitSpring
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_angularYZLimitSpring_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_angularYZLimitSpring_Injected(intPtr, ref value);
			}
		}

		public SoftJointLimit linearLimit
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_linearLimit_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_linearLimit_Injected(intPtr, ref value);
			}
		}

		public SoftJointLimit lowAngularXLimit
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_lowAngularXLimit_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_lowAngularXLimit_Injected(intPtr, ref value);
			}
		}

		public SoftJointLimit highAngularXLimit
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_highAngularXLimit_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_highAngularXLimit_Injected(intPtr, ref value);
			}
		}

		public SoftJointLimit angularYLimit
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_angularYLimit_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_angularYLimit_Injected(intPtr, ref value);
			}
		}

		public SoftJointLimit angularZLimit
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_angularZLimit_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_angularZLimit_Injected(intPtr, ref value);
			}
		}

		public Vector3 targetPosition
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_targetPosition_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_targetPosition_Injected(intPtr, ref value);
			}
		}

		public Vector3 targetVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_targetVelocity_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_targetVelocity_Injected(intPtr, ref value);
			}
		}

		public JointDrive xDrive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_xDrive_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_xDrive_Injected(intPtr, ref value);
			}
		}

		public JointDrive yDrive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_yDrive_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_yDrive_Injected(intPtr, ref value);
			}
		}

		public JointDrive zDrive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_zDrive_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_zDrive_Injected(intPtr, ref value);
			}
		}

		public Quaternion targetRotation
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_targetRotation_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_targetRotation_Injected(intPtr, ref value);
			}
		}

		public Vector3 targetAngularVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_targetAngularVelocity_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_targetAngularVelocity_Injected(intPtr, ref value);
			}
		}

		public RotationDriveMode rotationDriveMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_rotationDriveMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rotationDriveMode_Injected(intPtr, value);
			}
		}

		public JointDrive angularXDrive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_angularXDrive_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_angularXDrive_Injected(intPtr, ref value);
			}
		}

		public JointDrive angularYZDrive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_angularYZDrive_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_angularYZDrive_Injected(intPtr, ref value);
			}
		}

		public JointDrive slerpDrive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_slerpDrive_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_slerpDrive_Injected(intPtr, ref value);
			}
		}

		public JointProjectionMode projectionMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_projectionMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_projectionMode_Injected(intPtr, value);
			}
		}

		public float projectionDistance
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_projectionDistance_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_projectionDistance_Injected(intPtr, value);
			}
		}

		public float projectionAngle
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_projectionAngle_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_projectionAngle_Injected(intPtr, value);
			}
		}

		public bool configuredInWorldSpace
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_configuredInWorldSpace_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_configuredInWorldSpace_Injected(intPtr, value);
			}
		}

		public bool swapBodies
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_swapBodies_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_swapBodies_Injected(intPtr, value);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_secondaryAxis_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_secondaryAxis_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ConfigurableJointMotion get_xMotion_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_xMotion_Injected(IntPtr _unity_self, ConfigurableJointMotion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ConfigurableJointMotion get_yMotion_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_yMotion_Injected(IntPtr _unity_self, ConfigurableJointMotion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ConfigurableJointMotion get_zMotion_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_zMotion_Injected(IntPtr _unity_self, ConfigurableJointMotion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ConfigurableJointMotion get_angularXMotion_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_angularXMotion_Injected(IntPtr _unity_self, ConfigurableJointMotion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ConfigurableJointMotion get_angularYMotion_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_angularYMotion_Injected(IntPtr _unity_self, ConfigurableJointMotion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ConfigurableJointMotion get_angularZMotion_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_angularZMotion_Injected(IntPtr _unity_self, ConfigurableJointMotion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_linearLimitSpring_Injected(IntPtr _unity_self, out SoftJointLimitSpring ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_linearLimitSpring_Injected(IntPtr _unity_self, [In] ref SoftJointLimitSpring value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_angularXLimitSpring_Injected(IntPtr _unity_self, out SoftJointLimitSpring ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_angularXLimitSpring_Injected(IntPtr _unity_self, [In] ref SoftJointLimitSpring value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_angularYZLimitSpring_Injected(IntPtr _unity_self, out SoftJointLimitSpring ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_angularYZLimitSpring_Injected(IntPtr _unity_self, [In] ref SoftJointLimitSpring value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_linearLimit_Injected(IntPtr _unity_self, out SoftJointLimit ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_linearLimit_Injected(IntPtr _unity_self, [In] ref SoftJointLimit value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_lowAngularXLimit_Injected(IntPtr _unity_self, out SoftJointLimit ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_lowAngularXLimit_Injected(IntPtr _unity_self, [In] ref SoftJointLimit value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_highAngularXLimit_Injected(IntPtr _unity_self, out SoftJointLimit ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_highAngularXLimit_Injected(IntPtr _unity_self, [In] ref SoftJointLimit value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_angularYLimit_Injected(IntPtr _unity_self, out SoftJointLimit ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_angularYLimit_Injected(IntPtr _unity_self, [In] ref SoftJointLimit value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_angularZLimit_Injected(IntPtr _unity_self, out SoftJointLimit ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_angularZLimit_Injected(IntPtr _unity_self, [In] ref SoftJointLimit value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_targetPosition_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_targetPosition_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_targetVelocity_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_targetVelocity_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_xDrive_Injected(IntPtr _unity_self, out JointDrive ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_xDrive_Injected(IntPtr _unity_self, [In] ref JointDrive value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_yDrive_Injected(IntPtr _unity_self, out JointDrive ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_yDrive_Injected(IntPtr _unity_self, [In] ref JointDrive value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_zDrive_Injected(IntPtr _unity_self, out JointDrive ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_zDrive_Injected(IntPtr _unity_self, [In] ref JointDrive value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_targetRotation_Injected(IntPtr _unity_self, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_targetRotation_Injected(IntPtr _unity_self, [In] ref Quaternion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_targetAngularVelocity_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_targetAngularVelocity_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern RotationDriveMode get_rotationDriveMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rotationDriveMode_Injected(IntPtr _unity_self, RotationDriveMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_angularXDrive_Injected(IntPtr _unity_self, out JointDrive ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_angularXDrive_Injected(IntPtr _unity_self, [In] ref JointDrive value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_angularYZDrive_Injected(IntPtr _unity_self, out JointDrive ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_angularYZDrive_Injected(IntPtr _unity_self, [In] ref JointDrive value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_slerpDrive_Injected(IntPtr _unity_self, out JointDrive ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_slerpDrive_Injected(IntPtr _unity_self, [In] ref JointDrive value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern JointProjectionMode get_projectionMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_projectionMode_Injected(IntPtr _unity_self, JointProjectionMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_projectionDistance_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_projectionDistance_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_projectionAngle_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_projectionAngle_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_configuredInWorldSpace_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_configuredInWorldSpace_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_swapBodies_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_swapBodies_Injected(IntPtr _unity_self, bool value);
	}
	[NativeHeader("Modules/Physics/ConstantForce.h")]
	[RequireComponent(typeof(Rigidbody))]
	public class ConstantForce : Behaviour
	{
		public Vector3 force
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_force_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_force_Injected(intPtr, ref value);
			}
		}

		public Vector3 torque
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_torque_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_torque_Injected(intPtr, ref value);
			}
		}

		public Vector3 relativeForce
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_relativeForce_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_relativeForce_Injected(intPtr, ref value);
			}
		}

		public Vector3 relativeTorque
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_relativeTorque_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_relativeTorque_Injected(intPtr, ref value);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_force_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_force_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_torque_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_torque_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_relativeForce_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_relativeForce_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_relativeTorque_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_relativeTorque_Injected(IntPtr _unity_self, [In] ref Vector3 value);
	}
	[NativeHeader("Modules/Physics/PhysicsQuery.h")]
	[NativeHeader("Modules/Physics/PhysicsManager.h")]
	[StaticAccessor("GetPhysicsManager()", StaticAccessorType.Dot)]
	public class Physics
	{
		public delegate void ContactEventDelegate(PhysicsScene scene, NativeArray<ContactPairHeader>.ReadOnly headerArray);

		internal const float k_MaxFloatMinusEpsilon = 3.4028233E+38f;

		public const int IgnoreRaycastLayer = 4;

		public const int DefaultRaycastLayers = -5;

		public const int AllLayers = -1;

		private static readonly Collision s_ReusableCollision;

		public static Vector3 gravity
		{
			[ThreadSafe]
			get
			{
				get_gravity_Injected(out var ret);
				return ret;
			}
			set
			{
				set_gravity_Injected(ref value);
			}
		}

		public static extern float defaultContactOffset
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static extern float sleepThreshold
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static extern bool queriesHitTriggers
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static extern bool queriesHitBackfaces
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static extern float bounceThreshold
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static extern float defaultMaxDepenetrationVelocity
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static extern int defaultSolverIterations
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static extern int defaultSolverVelocityIterations
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static extern SimulationMode simulationMode
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static extern float defaultMaxAngularSpeed
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static extern bool improvedPatchFriction
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static extern bool invokeCollisionCallbacks
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static PhysicsScene defaultPhysicsScene => PhysicsScene.GetDefaultScene();

		public static extern bool autoSyncTransforms
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static extern bool reuseCollisionCallbacks
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		[StaticAccessor("GetPhysicsManager()")]
		public static extern float interCollisionDistance
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeName("GetClothInterCollisionDistance")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeName("SetClothInterCollisionDistance")]
			set;
		}

		[StaticAccessor("GetPhysicsManager()")]
		public static extern float interCollisionStiffness
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeName("GetClothInterCollisionStiffness")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeName("SetClothInterCollisionStiffness")]
			set;
		}

		[StaticAccessor("GetPhysicsManager()")]
		public static extern bool interCollisionSettingsToggle
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeName("GetClothInterCollisionSettingsToggle")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeName("SetClothInterCollisionSettingsToggle")]
			set;
		}

		public static Vector3 clothGravity
		{
			[ThreadSafe]
			get
			{
				get_clothGravity_Injected(out var ret);
				return ret;
			}
			set
			{
				set_clothGravity_Injected(ref value);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Physics.autoSimulation has been replaced by Physics.simulationMode", false)]
		public static bool autoSimulation
		{
			get
			{
				return simulationMode != SimulationMode.Script;
			}
			set
			{
				simulationMode = ((!value) ? SimulationMode.Script : SimulationMode.FixedUpdate);
			}
		}

		public static event Action<PhysicsScene, NativeArray<ModifiableContactPair>> ContactModifyEvent;

		public static event Action<PhysicsScene, NativeArray<ModifiableContactPair>> ContactModifyEventCCD;

		internal static event Action<PhysicsScene, IntPtr, int, bool> GenericContactModifyEvent;

		public static event ContactEventDelegate ContactEvent;

		[RequiredByNativeCode]
		private static void OnSceneContactModify(PhysicsScene scene, IntPtr buffer, int count, bool isCCD)
		{
			Physics.GenericContactModifyEvent?.Invoke(scene, buffer, count, isCCD);
		}

		private unsafe static void PhysXOnSceneContactModify(PhysicsScene scene, IntPtr buffer, int count, bool isCCD)
		{
			NativeArray<ModifiableContactPair> arg = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<ModifiableContactPair>(buffer.ToPointer(), count, Allocator.None);
			if (!isCCD)
			{
				Physics.ContactModifyEvent?.Invoke(scene, arg);
			}
			else
			{
				Physics.ContactModifyEventCCD?.Invoke(scene, arg);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetIntegrationInfos(out IntPtr integrations, out ulong integrationCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetCurrentIntegrationInfo(out IntPtr integration);

		internal unsafe static ReadOnlySpan<IntegrationInfo> GetIntegrationInfos()
		{
			GetIntegrationInfos(out var integrations, out var integrationCount);
			return new ReadOnlySpan<IntegrationInfo>(integrations.ToPointer(), (int)integrationCount);
		}

		public unsafe static IntegrationInfo GetCurrentIntegrationInfo()
		{
			GetCurrentIntegrationInfo(out var integration);
			return *(IntegrationInfo*)integration.ToPointer();
		}

		public static void IgnoreCollision([NotNull] Collider collider1, [NotNull] Collider collider2, [UnityEngine.Internal.DefaultValue("true")] bool ignore)
		{
			if ((object)collider1 == null)
			{
				ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
			}
			if ((object)collider2 == null)
			{
				ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider1);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
			}
			IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(collider2);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
			}
			IgnoreCollision_Injected(intPtr, intPtr2, ignore);
		}

		[ExcludeFromDocs]
		public static void IgnoreCollision(Collider collider1, Collider collider2)
		{
			IgnoreCollision(collider1, collider2, ignore: true);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeName("IgnoreCollision")]
		public static extern void IgnoreLayerCollision(int layer1, int layer2, [UnityEngine.Internal.DefaultValue("true")] bool ignore);

		[ExcludeFromDocs]
		public static void IgnoreLayerCollision(int layer1, int layer2)
		{
			IgnoreLayerCollision(layer1, layer2, ignore: true);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool GetIgnoreLayerCollision(int layer1, int layer2);

		public static bool GetIgnoreCollision([NotNull] Collider collider1, [NotNull] Collider collider2)
		{
			if ((object)collider1 == null)
			{
				ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
			}
			if ((object)collider2 == null)
			{
				ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider1);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
			}
			IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(collider2);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
			}
			return GetIgnoreCollision_Injected(intPtr, intPtr2);
		}

		public static bool Raycast(Vector3 origin, Vector3 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.Raycast(origin, direction, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance, int layerMask)
		{
			return defaultPhysicsScene.Raycast(origin, direction, maxDistance, layerMask);
		}

		[ExcludeFromDocs]
		public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance)
		{
			return defaultPhysicsScene.Raycast(origin, direction, maxDistance);
		}

		[ExcludeFromDocs]
		public static bool Raycast(Vector3 origin, Vector3 direction)
		{
			return defaultPhysicsScene.Raycast(origin, direction);
		}

		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.Raycast(origin, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
		}

		[RequiredByNativeCode]
		[ExcludeFromDocs]
		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask)
		{
			return defaultPhysicsScene.Raycast(origin, direction, out hitInfo, maxDistance, layerMask);
		}

		[ExcludeFromDocs]
		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance)
		{
			return defaultPhysicsScene.Raycast(origin, direction, out hitInfo, maxDistance);
		}

		[ExcludeFromDocs]
		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo)
		{
			return defaultPhysicsScene.Raycast(origin, direction, out hitInfo);
		}

		public static bool Raycast(Ray ray, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.Raycast(ray.origin, ray.direction, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool Raycast(Ray ray, float maxDistance, int layerMask)
		{
			return defaultPhysicsScene.Raycast(ray.origin, ray.direction, maxDistance, layerMask);
		}

		[ExcludeFromDocs]
		public static bool Raycast(Ray ray, float maxDistance)
		{
			return defaultPhysicsScene.Raycast(ray.origin, ray.direction, maxDistance);
		}

		[ExcludeFromDocs]
		public static bool Raycast(Ray ray)
		{
			return defaultPhysicsScene.Raycast(ray.origin, ray.direction);
		}

		public static bool Raycast(Ray ray, out RaycastHit hitInfo, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.Raycast(ray.origin, ray.direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask)
		{
			return Raycast(ray.origin, ray.direction, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance)
		{
			return defaultPhysicsScene.Raycast(ray.origin, ray.direction, out hitInfo, maxDistance);
		}

		[ExcludeFromDocs]
		public static bool Raycast(Ray ray, out RaycastHit hitInfo)
		{
			return defaultPhysicsScene.Raycast(ray.origin, ray.direction, out hitInfo);
		}

		public static bool Linecast(Vector3 start, Vector3 end, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			Vector3 direction = end - start;
			return defaultPhysicsScene.Raycast(start, direction, direction.magnitude, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool Linecast(Vector3 start, Vector3 end, int layerMask)
		{
			return Linecast(start, end, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool Linecast(Vector3 start, Vector3 end)
		{
			return Linecast(start, end, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			Vector3 direction = end - start;
			return defaultPhysicsScene.Raycast(start, direction, out hitInfo, direction.magnitude, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo, int layerMask)
		{
			return Linecast(start, end, out hitInfo, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo)
		{
			return Linecast(start, end, out hitInfo, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			RaycastHit hitInfo;
			return defaultPhysicsScene.CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask)
		{
			return CapsuleCast(point1, point2, radius, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance)
		{
			return CapsuleCast(point1, point2, radius, direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction)
		{
			return CapsuleCast(point1, point2, radius, direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask)
		{
			return CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance)
		{
			return CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo)
		{
			return CapsuleCast(point1, point2, radius, direction, out hitInfo, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask)
		{
			return SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance)
		{
			return SphereCast(origin, radius, direction, out hitInfo, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo)
		{
			return SphereCast(origin, radius, direction, out hitInfo, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static bool SphereCast(Ray ray, float radius, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			RaycastHit hitInfo;
			return SphereCast(ray.origin, radius, ray.direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool SphereCast(Ray ray, float radius, float maxDistance, int layerMask)
		{
			return SphereCast(ray, radius, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool SphereCast(Ray ray, float radius, float maxDistance)
		{
			return SphereCast(ray, radius, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool SphereCast(Ray ray, float radius)
		{
			return SphereCast(ray, radius, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return SphereCast(ray.origin, radius, ray.direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float maxDistance, int layerMask)
		{
			return SphereCast(ray, radius, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float maxDistance)
		{
			return SphereCast(ray, radius, out hitInfo, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo)
		{
			return SphereCast(ray, radius, out hitInfo, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, [UnityEngine.Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			RaycastHit hitInfo;
			return defaultPhysicsScene.BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask)
		{
			return BoxCast(center, halfExtents, direction, orientation, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance)
		{
			return BoxCast(center, halfExtents, direction, orientation, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation)
		{
			return BoxCast(center, halfExtents, direction, orientation, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction)
		{
			return BoxCast(center, halfExtents, direction, Quaternion.identity, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, [UnityEngine.Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, Quaternion orientation, float maxDistance, int layerMask)
		{
			return BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, Quaternion orientation, float maxDistance)
		{
			return BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, Quaternion orientation)
		{
			return BoxCast(center, halfExtents, direction, out hitInfo, orientation, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo)
		{
			return BoxCast(center, halfExtents, direction, out hitInfo, Quaternion.identity, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		[FreeFunction("Physics::RaycastAll")]
		private static RaycastHit[] Internal_RaycastAll(PhysicsScene physicsScene, Ray ray, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction)
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			RaycastHit[] result;
			try
			{
				Internal_RaycastAll_Injected(ref physicsScene, ref ray, maxDistance, mask, queryTriggerInteraction, out ret);
			}
			finally
			{
				RaycastHit[] array = default(RaycastHit[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}

		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			float magnitude = direction.magnitude;
			if (magnitude > float.Epsilon)
			{
				Vector3 direction2 = direction / magnitude;
				return Internal_RaycastAll(ray: new Ray(origin, direction2), physicsScene: defaultPhysicsScene, maxDistance: maxDistance, mask: layerMask, queryTriggerInteraction: queryTriggerInteraction);
			}
			return new RaycastHit[0];
		}

		[ExcludeFromDocs]
		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance, int layerMask)
		{
			return RaycastAll(origin, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance)
		{
			return RaycastAll(origin, direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction)
		{
			return RaycastAll(origin, direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static RaycastHit[] RaycastAll(Ray ray, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return RaycastAll(ray.origin, ray.direction, maxDistance, layerMask, queryTriggerInteraction);
		}

		[RequiredByNativeCode]
		[ExcludeFromDocs]
		public static RaycastHit[] RaycastAll(Ray ray, float maxDistance, int layerMask)
		{
			return RaycastAll(ray.origin, ray.direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static RaycastHit[] RaycastAll(Ray ray, float maxDistance)
		{
			return RaycastAll(ray.origin, ray.direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static RaycastHit[] RaycastAll(Ray ray)
		{
			return RaycastAll(ray.origin, ray.direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static int RaycastNonAlloc(Ray ray, RaycastHit[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.Raycast(ray.origin, ray.direction, results, maxDistance, layerMask, queryTriggerInteraction);
		}

		[RequiredByNativeCode]
		[ExcludeFromDocs]
		public static int RaycastNonAlloc(Ray ray, RaycastHit[] results, float maxDistance, int layerMask)
		{
			return defaultPhysicsScene.Raycast(ray.origin, ray.direction, results, maxDistance, layerMask);
		}

		[ExcludeFromDocs]
		public static int RaycastNonAlloc(Ray ray, RaycastHit[] results, float maxDistance)
		{
			return defaultPhysicsScene.Raycast(ray.origin, ray.direction, results, maxDistance);
		}

		[ExcludeFromDocs]
		public static int RaycastNonAlloc(Ray ray, RaycastHit[] results)
		{
			return defaultPhysicsScene.Raycast(ray.origin, ray.direction, results);
		}

		public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.Raycast(origin, direction, results, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask)
		{
			return defaultPhysicsScene.Raycast(origin, direction, results, maxDistance, layerMask);
		}

		[ExcludeFromDocs]
		public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float maxDistance)
		{
			return defaultPhysicsScene.Raycast(origin, direction, results, maxDistance);
		}

		[ExcludeFromDocs]
		public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results)
		{
			return defaultPhysicsScene.Raycast(origin, direction, results);
		}

		[FreeFunction("Physics::CapsuleCastAll")]
		private static RaycastHit[] Query_CapsuleCastAll(PhysicsScene physicsScene, Vector3 p0, Vector3 p1, float radius, Vector3 direction, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction)
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			RaycastHit[] result;
			try
			{
				Query_CapsuleCastAll_Injected(ref physicsScene, ref p0, ref p1, radius, ref direction, maxDistance, mask, queryTriggerInteraction, out ret);
			}
			finally
			{
				RaycastHit[] array = default(RaycastHit[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}

		public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			float magnitude = direction.magnitude;
			if (magnitude > float.Epsilon)
			{
				Vector3 direction2 = direction / magnitude;
				return Query_CapsuleCastAll(defaultPhysicsScene, point1, point2, radius, direction2, maxDistance, layerMask, queryTriggerInteraction);
			}
			return new RaycastHit[0];
		}

		[ExcludeFromDocs]
		public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask)
		{
			return CapsuleCastAll(point1, point2, radius, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance)
		{
			return CapsuleCastAll(point1, point2, radius, direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction)
		{
			return CapsuleCastAll(point1, point2, radius, direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		[FreeFunction("Physics::SphereCastAll")]
		private static RaycastHit[] Query_SphereCastAll(PhysicsScene physicsScene, Vector3 origin, float radius, Vector3 direction, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction)
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			RaycastHit[] result;
			try
			{
				Query_SphereCastAll_Injected(ref physicsScene, ref origin, radius, ref direction, maxDistance, mask, queryTriggerInteraction, out ret);
			}
			finally
			{
				RaycastHit[] array = default(RaycastHit[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}

		public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			float magnitude = direction.magnitude;
			if (magnitude > float.Epsilon)
			{
				Vector3 direction2 = direction / magnitude;
				return Query_SphereCastAll(defaultPhysicsScene, origin, radius, direction2, maxDistance, layerMask, queryTriggerInteraction);
			}
			return new RaycastHit[0];
		}

		[ExcludeFromDocs]
		public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance, int layerMask)
		{
			return SphereCastAll(origin, radius, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance)
		{
			return SphereCastAll(origin, radius, direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction)
		{
			return SphereCastAll(origin, radius, direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static RaycastHit[] SphereCastAll(Ray ray, float radius, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return SphereCastAll(ray.origin, radius, ray.direction, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static RaycastHit[] SphereCastAll(Ray ray, float radius, float maxDistance, int layerMask)
		{
			return SphereCastAll(ray, radius, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static RaycastHit[] SphereCastAll(Ray ray, float radius, float maxDistance)
		{
			return SphereCastAll(ray, radius, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static RaycastHit[] SphereCastAll(Ray ray, float radius)
		{
			return SphereCastAll(ray, radius, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		[FreeFunction("Physics::OverlapCapsule")]
		private static Collider[] OverlapCapsule_Internal(PhysicsScene physicsScene, Vector3 point0, Vector3 point1, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return OverlapCapsule_Internal_Injected(ref physicsScene, ref point0, ref point1, radius, layerMask, queryTriggerInteraction);
		}

		public static Collider[] OverlapCapsule(Vector3 point0, Vector3 point1, float radius, [UnityEngine.Internal.DefaultValue("AllLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return OverlapCapsule_Internal(defaultPhysicsScene, point0, point1, radius, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static Collider[] OverlapCapsule(Vector3 point0, Vector3 point1, float radius, int layerMask)
		{
			return OverlapCapsule(point0, point1, radius, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static Collider[] OverlapCapsule(Vector3 point0, Vector3 point1, float radius)
		{
			return OverlapCapsule(point0, point1, radius, -1, QueryTriggerInteraction.UseGlobal);
		}

		[FreeFunction("Physics::OverlapSphere")]
		private static Collider[] OverlapSphere_Internal(PhysicsScene physicsScene, Vector3 position, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return OverlapSphere_Internal_Injected(ref physicsScene, ref position, radius, layerMask, queryTriggerInteraction);
		}

		public static Collider[] OverlapSphere(Vector3 position, float radius, [UnityEngine.Internal.DefaultValue("AllLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return OverlapSphere_Internal(defaultPhysicsScene, position, radius, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static Collider[] OverlapSphere(Vector3 position, float radius, int layerMask)
		{
			return OverlapSphere(position, radius, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static Collider[] OverlapSphere(Vector3 position, float radius)
		{
			return OverlapSphere(position, radius, -1, QueryTriggerInteraction.UseGlobal);
		}

		[NativeName("Simulate")]
		internal static void Simulate_Internal(PhysicsScene physicsScene, float step, SimulationStage stages, SimulationOption options)
		{
			Simulate_Internal_Injected(ref physicsScene, step, stages, options);
		}

		public static void Simulate(float step)
		{
			if (simulationMode != SimulationMode.Script)
			{
				Debug.LogWarning("Physics.Simulate(...) was called but simulation mode is not set to Script. You should set simulation mode to Script first before calling this function therefore the simulation was not run.");
			}
			else
			{
				Simulate_Internal(defaultPhysicsScene, step, SimulationStage.All, SimulationOption.All);
			}
		}

		[NativeName("InterpolateBodies")]
		internal static void InterpolateBodies_Internal(PhysicsScene physicsScene)
		{
			InterpolateBodies_Internal_Injected(ref physicsScene);
		}

		[NativeName("ResetInterpolatedTransformPosition")]
		internal static void ResetInterpolationPoses_Internal(PhysicsScene physicsScene)
		{
			ResetInterpolationPoses_Internal_Injected(ref physicsScene);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SyncTransforms();

		[FreeFunction("Physics::ComputePenetration")]
		private static bool Query_ComputePenetration([NotNull] Collider colliderA, Vector3 positionA, Quaternion rotationA, [NotNull] Collider colliderB, Vector3 positionB, Quaternion rotationB, ref Vector3 direction, ref float distance)
		{
			if ((object)colliderA == null)
			{
				ThrowHelper.ThrowArgumentNullException(colliderA, "colliderA");
			}
			if ((object)colliderB == null)
			{
				ThrowHelper.ThrowArgumentNullException(colliderB, "colliderB");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(colliderA);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(colliderA, "colliderA");
			}
			IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(colliderB);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(colliderB, "colliderB");
			}
			return Query_ComputePenetration_Injected(intPtr, ref positionA, ref rotationA, intPtr2, ref positionB, ref rotationB, ref direction, ref distance);
		}

		public static bool ComputePenetration(Collider colliderA, Vector3 positionA, Quaternion rotationA, Collider colliderB, Vector3 positionB, Quaternion rotationB, out Vector3 direction, out float distance)
		{
			direction = Vector3.zero;
			distance = 0f;
			return Query_ComputePenetration(colliderA, positionA, rotationA, colliderB, positionB, rotationB, ref direction, ref distance);
		}

		[FreeFunction("Physics::ClosestPoint")]
		private static Vector3 Query_ClosestPoint([NotNull] Collider collider, Vector3 position, Quaternion rotation, Vector3 point)
		{
			if ((object)collider == null)
			{
				ThrowHelper.ThrowArgumentNullException(collider, "collider");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(collider, "collider");
			}
			Query_ClosestPoint_Injected(intPtr, ref position, ref rotation, ref point, out var ret);
			return ret;
		}

		public static Vector3 ClosestPoint(Vector3 point, Collider collider, Vector3 position, Quaternion rotation)
		{
			return Query_ClosestPoint(collider, position, rotation, point);
		}

		public static int OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results, [UnityEngine.Internal.DefaultValue("AllLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.OverlapSphere(position, radius, results, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static int OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results, int layerMask)
		{
			return OverlapSphereNonAlloc(position, radius, results, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static int OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results)
		{
			return OverlapSphereNonAlloc(position, radius, results, -1, QueryTriggerInteraction.UseGlobal);
		}

		[FreeFunction("Physics::SphereTest")]
		private static bool CheckSphere_Internal(PhysicsScene physicsScene, Vector3 position, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return CheckSphere_Internal_Injected(ref physicsScene, ref position, radius, layerMask, queryTriggerInteraction);
		}

		public static bool CheckSphere(Vector3 position, float radius, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return CheckSphere_Internal(defaultPhysicsScene, position, radius, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool CheckSphere(Vector3 position, float radius, int layerMask)
		{
			return CheckSphere(position, radius, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool CheckSphere(Vector3 position, float radius)
		{
			return CheckSphere(position, radius, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.CapsuleCast(point1, point2, radius, direction, results, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask)
		{
			return CapsuleCastNonAlloc(point1, point2, radius, direction, results, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results, float maxDistance)
		{
			return CapsuleCastNonAlloc(point1, point2, radius, direction, results, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results)
		{
			return CapsuleCastNonAlloc(point1, point2, radius, direction, results, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.SphereCast(origin, radius, direction, results, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask)
		{
			return SphereCastNonAlloc(origin, radius, direction, results, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, float maxDistance)
		{
			return SphereCastNonAlloc(origin, radius, direction, results, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results)
		{
			return SphereCastNonAlloc(origin, radius, direction, results, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return SphereCastNonAlloc(ray.origin, radius, ray.direction, results, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results, float maxDistance, int layerMask)
		{
			return SphereCastNonAlloc(ray, radius, results, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results, float maxDistance)
		{
			return SphereCastNonAlloc(ray, radius, results, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results)
		{
			return SphereCastNonAlloc(ray, radius, results, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		[FreeFunction("Physics::CapsuleTest")]
		private static bool CheckCapsule_Internal(PhysicsScene physicsScene, Vector3 start, Vector3 end, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return CheckCapsule_Internal_Injected(ref physicsScene, ref start, ref end, radius, layerMask, queryTriggerInteraction);
		}

		public static bool CheckCapsule(Vector3 start, Vector3 end, float radius, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return CheckCapsule_Internal(defaultPhysicsScene, start, end, radius, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool CheckCapsule(Vector3 start, Vector3 end, float radius, int layerMask)
		{
			return CheckCapsule(start, end, radius, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool CheckCapsule(Vector3 start, Vector3 end, float radius)
		{
			return CheckCapsule(start, end, radius, -5, QueryTriggerInteraction.UseGlobal);
		}

		[FreeFunction("Physics::BoxTest")]
		private static bool CheckBox_Internal(PhysicsScene physicsScene, Vector3 center, Vector3 halfExtents, Quaternion orientation, int layermask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return CheckBox_Internal_Injected(ref physicsScene, ref center, ref halfExtents, ref orientation, layermask, queryTriggerInteraction);
		}

		public static bool CheckBox(Vector3 center, Vector3 halfExtents, [UnityEngine.Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layermask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return CheckBox_Internal(defaultPhysicsScene, center, halfExtents, orientation, layermask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask)
		{
			return CheckBox(center, halfExtents, orientation, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation)
		{
			return CheckBox(center, halfExtents, orientation, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static bool CheckBox(Vector3 center, Vector3 halfExtents)
		{
			return CheckBox(center, halfExtents, Quaternion.identity, -5, QueryTriggerInteraction.UseGlobal);
		}

		[FreeFunction("Physics::OverlapBox")]
		private static Collider[] OverlapBox_Internal(PhysicsScene physicsScene, Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return OverlapBox_Internal_Injected(ref physicsScene, ref center, ref halfExtents, ref orientation, layerMask, queryTriggerInteraction);
		}

		public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, [UnityEngine.Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [UnityEngine.Internal.DefaultValue("AllLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return OverlapBox_Internal(defaultPhysicsScene, center, halfExtents, orientation, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask)
		{
			return OverlapBox(center, halfExtents, orientation, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, Quaternion orientation)
		{
			return OverlapBox(center, halfExtents, orientation, -1, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents)
		{
			return OverlapBox(center, halfExtents, Quaternion.identity, -1, QueryTriggerInteraction.UseGlobal);
		}

		public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, [UnityEngine.Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [UnityEngine.Internal.DefaultValue("AllLayers")] int mask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.OverlapBox(center, halfExtents, results, orientation, mask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, Quaternion orientation, int mask)
		{
			return OverlapBoxNonAlloc(center, halfExtents, results, orientation, mask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, Quaternion orientation)
		{
			return OverlapBoxNonAlloc(center, halfExtents, results, orientation, -1, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results)
		{
			return OverlapBoxNonAlloc(center, halfExtents, results, Quaternion.identity, -1, QueryTriggerInteraction.UseGlobal);
		}

		public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, [UnityEngine.Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.BoxCast(center, halfExtents, direction, results, orientation, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, Quaternion orientation)
		{
			return BoxCastNonAlloc(center, halfExtents, direction, results, orientation, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, Quaternion orientation, float maxDistance)
		{
			return BoxCastNonAlloc(center, halfExtents, direction, results, orientation, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, Quaternion orientation, float maxDistance, int layerMask)
		{
			return BoxCastNonAlloc(center, halfExtents, direction, results, orientation, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results)
		{
			return BoxCastNonAlloc(center, halfExtents, direction, results, Quaternion.identity, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		[FreeFunction("Physics::BoxCastAll")]
		private static RaycastHit[] Internal_BoxCastAll(PhysicsScene physicsScene, Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			RaycastHit[] result;
			try
			{
				Internal_BoxCastAll_Injected(ref physicsScene, ref center, ref halfExtents, ref direction, ref orientation, maxDistance, layerMask, queryTriggerInteraction, out ret);
			}
			finally
			{
				RaycastHit[] array = default(RaycastHit[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}

		public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, [UnityEngine.Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			float magnitude = direction.magnitude;
			if (magnitude > float.Epsilon)
			{
				Vector3 direction2 = direction / magnitude;
				return Internal_BoxCastAll(defaultPhysicsScene, center, halfExtents, direction2, orientation, maxDistance, layerMask, queryTriggerInteraction);
			}
			return new RaycastHit[0];
		}

		[ExcludeFromDocs]
		public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask)
		{
			return BoxCastAll(center, halfExtents, direction, orientation, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance)
		{
			return BoxCastAll(center, halfExtents, direction, orientation, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation)
		{
			return BoxCastAll(center, halfExtents, direction, orientation, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction)
		{
			return BoxCastAll(center, halfExtents, direction, Quaternion.identity, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		public static int OverlapCapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results, [UnityEngine.Internal.DefaultValue("AllLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return defaultPhysicsScene.OverlapCapsule(point0, point1, radius, results, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public static int OverlapCapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results, int layerMask)
		{
			return OverlapCapsuleNonAlloc(point0, point1, radius, results, layerMask, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public static int OverlapCapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results)
		{
			return OverlapCapsuleNonAlloc(point0, point1, radius, results, -1, QueryTriggerInteraction.UseGlobal);
		}

		[StaticAccessor("GetPhysicsManager()")]
		public static void RebuildBroadphaseRegions(Bounds worldBounds, int subdivisions)
		{
			RebuildBroadphaseRegions_Injected(ref worldBounds, subdivisions);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("GetPhysicsManager()")]
		[ThreadSafe]
		public static extern void BakeMesh(int meshID, bool convex, MeshColliderCookingOptions cookingOptions);

		public static void BakeMesh(int meshID, bool convex)
		{
			BakeMesh(meshID, convex, MeshColliderCookingOptions.CookForFasterSimulation | MeshColliderCookingOptions.EnableMeshCleaning | MeshColliderCookingOptions.WeldColocatedVertices | MeshColliderCookingOptions.UseFastMidphase);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("PhysicsManager", StaticAccessorType.DoubleColon)]
		internal static extern bool ConnectPhysicsSDKVisualDebugger();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("PhysicsManager", StaticAccessorType.DoubleColon)]
		internal static extern void DisconnectPhysicsSDKVisualDebugger();

		[StaticAccessor("PhysicsManager", StaticAccessorType.DoubleColon)]
		internal static Collider GetColliderByInstanceID(EntityId entityId)
		{
			return Unmarshal.UnmarshalUnityObject<Collider>(GetColliderByInstanceID_Injected(ref entityId));
		}

		[StaticAccessor("PhysicsManager", StaticAccessorType.DoubleColon)]
		internal static Component GetBodyByInstanceID(EntityId entityId)
		{
			return Unmarshal.UnmarshalUnityObject<Component>(GetBodyByInstanceID_Injected(ref entityId));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		[StaticAccessor("PhysicsManager", StaticAccessorType.DoubleColon)]
		internal static extern uint TranslateTriangleIndexFromID(int instanceID, uint faceIndex);

		[StaticAccessor("PhysicsManager", StaticAccessorType.DoubleColon)]
		private static void SendOnCollisionEnter(Component component, Collision collision)
		{
			SendOnCollisionEnter_Injected(Object.MarshalledUnityObject.Marshal(component), collision);
		}

		[StaticAccessor("PhysicsManager", StaticAccessorType.DoubleColon)]
		private static void SendOnCollisionStay(Component component, Collision collision)
		{
			SendOnCollisionStay_Injected(Object.MarshalledUnityObject.Marshal(component), collision);
		}

		[StaticAccessor("PhysicsManager", StaticAccessorType.DoubleColon)]
		private static void SendOnCollisionExit(Component component, Collision collision)
		{
			SendOnCollisionExit_Injected(Object.MarshalledUnityObject.Marshal(component), collision);
		}

		[RequiredByNativeCode]
		private unsafe static void OnSceneContact(PhysicsScene scene, IntPtr buffer, int count)
		{
			if (count == 0)
			{
				return;
			}
			NativeArray<ContactPairHeader> nativeArray = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<ContactPairHeader>(buffer.ToPointer(), count, Allocator.None);
			try
			{
				Physics.ContactEvent?.Invoke(scene, nativeArray.AsReadOnly());
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
			finally
			{
				ReportContacts(nativeArray.AsReadOnly());
			}
		}

		private static void ReportContacts(NativeArray<ContactPairHeader>.ReadOnly array)
		{
			if (!invokeCollisionCallbacks)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				ContactPairHeader header = array[i];
				if (header.hasRemovedBody)
				{
					continue;
				}
				for (int j = 0; j < header.m_NbPairs; j++)
				{
					ref readonly ContactPair contactPair = ref header.GetContactPair(j);
					if (contactPair.hasRemovedCollider)
					{
						continue;
					}
					Component body = header.body;
					Component otherBody = header.otherBody;
					Component component = ((body != null) ? body : contactPair.collider);
					Component component2 = ((otherBody != null) ? otherBody : contactPair.otherCollider);
					if ((bool)component && (bool)component2)
					{
						if (contactPair.isCollisionEnter)
						{
							SendOnCollisionEnter(component, GetCollisionToReport(in header, in contactPair, flipped: false));
							SendOnCollisionEnter(component2, GetCollisionToReport(in header, in contactPair, flipped: true));
						}
						if (contactPair.isCollisionStay)
						{
							SendOnCollisionStay(component, GetCollisionToReport(in header, in contactPair, flipped: false));
							SendOnCollisionStay(component2, GetCollisionToReport(in header, in contactPair, flipped: true));
						}
						if (contactPair.isCollisionExit)
						{
							SendOnCollisionExit(component, GetCollisionToReport(in header, in contactPair, flipped: false));
							SendOnCollisionExit(component2, GetCollisionToReport(in header, in contactPair, flipped: true));
						}
					}
				}
			}
		}

		private static Collision GetCollisionToReport(in ContactPairHeader header, in ContactPair pair, bool flipped)
		{
			if (reuseCollisionCallbacks)
			{
				s_ReusableCollision.Reuse(in header, in pair);
				s_ReusableCollision.Flipped = flipped;
				return s_ReusableCollision;
			}
			return new Collision(in header, in pair, flipped);
		}

		static Physics()
		{
			Physics.GenericContactModifyEvent = PhysXOnSceneContactModify;
			s_ReusableCollision = new Collision();
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_gravity_Injected(out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_gravity_Injected([In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void IgnoreCollision_Injected(IntPtr collider1, IntPtr collider2, [UnityEngine.Internal.DefaultValue("true")] bool ignore);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetIgnoreCollision_Injected(IntPtr collider1, IntPtr collider2);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_RaycastAll_Injected([In] ref PhysicsScene physicsScene, [In] ref Ray ray, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction, out BlittableArrayWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Query_CapsuleCastAll_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 p0, [In] ref Vector3 p1, float radius, [In] ref Vector3 direction, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction, out BlittableArrayWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Query_SphereCastAll_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 origin, float radius, [In] ref Vector3 direction, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction, out BlittableArrayWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Collider[] OverlapCapsule_Internal_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 point0, [In] ref Vector3 point1, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Collider[] OverlapSphere_Internal_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 position, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Simulate_Internal_Injected([In] ref PhysicsScene physicsScene, float step, SimulationStage stages, SimulationOption options);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InterpolateBodies_Internal_Injected([In] ref PhysicsScene physicsScene);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResetInterpolationPoses_Internal_Injected([In] ref PhysicsScene physicsScene);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Query_ComputePenetration_Injected(IntPtr colliderA, [In] ref Vector3 positionA, [In] ref Quaternion rotationA, IntPtr colliderB, [In] ref Vector3 positionB, [In] ref Quaternion rotationB, ref Vector3 direction, ref float distance);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Query_ClosestPoint_Injected(IntPtr collider, [In] ref Vector3 position, [In] ref Quaternion rotation, [In] ref Vector3 point, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_clothGravity_Injected(out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_clothGravity_Injected([In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CheckSphere_Internal_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 position, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CheckCapsule_Internal_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 start, [In] ref Vector3 end, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CheckBox_Internal_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 center, [In] ref Vector3 halfExtents, [In] ref Quaternion orientation, int layermask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Collider[] OverlapBox_Internal_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 center, [In] ref Vector3 halfExtents, [In] ref Quaternion orientation, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_BoxCastAll_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 center, [In] ref Vector3 halfExtents, [In] ref Vector3 direction, [In] ref Quaternion orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out BlittableArrayWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RebuildBroadphaseRegions_Injected([In] ref Bounds worldBounds, int subdivisions);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetColliderByInstanceID_Injected([In] ref EntityId entityId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetBodyByInstanceID_Injected([In] ref EntityId entityId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SendOnCollisionEnter_Injected(IntPtr component, Collision collision);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SendOnCollisionStay_Injected(IntPtr component, Collision collision);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SendOnCollisionExit_Injected(IntPtr component, Collision collision);
	}
	[NativeHeader("Modules/Physics/PhysXContactModification.h")]
	[NativeHeader("Modules/Physics/PhysicsCollisionGeometry.h")]
	public struct ModifiableContactPair
	{
		private IntPtr actor;

		private IntPtr otherActor;

		private IntPtr shape;

		private IntPtr otherShape;

		public Quaternion rotation;

		public Vector3 position;

		public Quaternion otherRotation;

		public Vector3 otherPosition;

		private int numContacts;

		private IntPtr contacts;

		public int colliderInstanceID => ResolveShapeToInstanceID(shape);

		public int otherColliderInstanceID => ResolveShapeToInstanceID(otherShape);

		public int bodyInstanceID => ResolveActorToInstanceID(actor);

		public int otherBodyInstanceID => ResolveActorToInstanceID(otherActor);

		public Vector3 bodyVelocity => GetActorLinearVelocity(actor);

		public Vector3 bodyAngularVelocity => GetActorAngularVelocity(actor);

		public Vector3 otherBodyVelocity => GetActorLinearVelocity(otherActor);

		public Vector3 otherBodyAngularVelocity => GetActorAngularVelocity(otherActor);

		public int contactCount => numContacts;

		public unsafe ModifiableMassProperties massProperties
		{
			get
			{
				return GetContactPatch()->massProperties;
			}
			set
			{
				ModifiableContactPatch* contactPatch = GetContactPatch();
				contactPatch->massProperties = value;
				byte* internalFlags = &contactPatch->internalFlags;
				*internalFlags |= 8;
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("Physics::PhysxCompatibility::TranslateTriangleIndex", true)]
		internal static extern uint TranslateTriangleIndex(IntPtr shapePtr, uint rawIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("Physics::PhysxCompatibility::ResolveShapeToInstanceID", true)]
		internal static extern int ResolveShapeToInstanceID(IntPtr shapePtr);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("Physics::PhysxCompatibility::ResolveActorToInstanceID", true)]
		internal static extern int ResolveActorToInstanceID(IntPtr actorPtr);

		[FreeFunction("Physics::PhysxCompatibility::GetActorLinearVelocity", true)]
		internal static Vector3 GetActorLinearVelocity(IntPtr actorPtr)
		{
			GetActorLinearVelocity_Injected(actorPtr, out var ret);
			return ret;
		}

		[FreeFunction("Physics::PhysxCompatibility::GetActorAngularVelocity", true)]
		internal static Vector3 GetActorAngularVelocity(IntPtr actorPtr)
		{
			GetActorAngularVelocity_Injected(actorPtr, out var ret);
			return ret;
		}

		public unsafe Vector3 GetPoint(int i)
		{
			return GetContact(i)->contact;
		}

		public unsafe void SetPoint(int i, Vector3 v)
		{
			GetContact(i)->contact = v;
		}

		public unsafe Vector3 GetNormal(int i)
		{
			return GetContact(i)->normal;
		}

		public unsafe void SetNormal(int i, Vector3 normal)
		{
			GetContact(i)->normal = normal;
			byte* internalFlags = &GetContactPatch()->internalFlags;
			*internalFlags |= 0x40;
		}

		public unsafe float GetSeparation(int i)
		{
			return GetContact(i)->separation;
		}

		public unsafe void SetSeparation(int i, float separation)
		{
			GetContact(i)->separation = separation;
		}

		public unsafe Vector3 GetTargetVelocity(int i)
		{
			return GetContact(i)->targetVelocity;
		}

		public unsafe void SetTargetVelocity(int i, Vector3 velocity)
		{
			GetContact(i)->targetVelocity = velocity;
			byte* internalFlags = &GetContactPatch()->internalFlags;
			*internalFlags |= 0x10;
		}

		public unsafe float GetBounciness(int i)
		{
			return GetContact(i)->restitution;
		}

		public unsafe void SetBounciness(int i, float bounciness)
		{
			GetContact(i)->restitution = bounciness;
			byte* internalFlags = &GetContactPatch()->internalFlags;
			*internalFlags |= 0x40;
		}

		public unsafe float GetStaticFriction(int i)
		{
			return GetContact(i)->staticFriction;
		}

		public unsafe void SetStaticFriction(int i, float staticFriction)
		{
			GetContact(i)->staticFriction = staticFriction;
			byte* internalFlags = &GetContactPatch()->internalFlags;
			*internalFlags |= 0x40;
		}

		public unsafe float GetDynamicFriction(int i)
		{
			return GetContact(i)->dynamicFriction;
		}

		public unsafe void SetDynamicFriction(int i, float dynamicFriction)
		{
			GetContact(i)->dynamicFriction = dynamicFriction;
			byte* internalFlags = &GetContactPatch()->internalFlags;
			*internalFlags |= 0x40;
		}

		public unsafe float GetMaxImpulse(int i)
		{
			return GetContact(i)->maxImpulse;
		}

		public unsafe void SetMaxImpulse(int i, float value)
		{
			GetContact(i)->maxImpulse = value;
			byte* internalFlags = &GetContactPatch()->internalFlags;
			*internalFlags |= 0x20;
		}

		public void IgnoreContact(int i)
		{
			SetMaxImpulse(i, 0f);
		}

		public unsafe uint GetFaceIndex(int i)
		{
			if ((GetContactPatch()->internalFlags & 1) != 0)
			{
				IntPtr intPtr = new IntPtr(contacts.ToInt64() + numContacts * sizeof(ModifiableContact) + (numContacts + i) * 4);
				uint rawIndex = *(uint*)(void*)intPtr;
				return TranslateTriangleIndex(otherShape, rawIndex);
			}
			return uint.MaxValue;
		}

		private unsafe ModifiableContact* GetContact(int index)
		{
			IntPtr intPtr = new IntPtr(contacts.ToInt64() + index * sizeof(ModifiableContact));
			return (ModifiableContact*)(void*)intPtr;
		}

		private unsafe ModifiableContactPatch* GetContactPatch()
		{
			IntPtr intPtr = new IntPtr(contacts.ToInt64() - numContacts * sizeof(ModifiableContactPatch));
			return (ModifiableContactPatch*)(void*)intPtr;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetActorLinearVelocity_Injected(IntPtr actorPtr, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetActorAngularVelocity_Injected(IntPtr actorPtr, out Vector3 ret);
	}
	public struct ModifiableMassProperties
	{
		public float inverseMassScale;

		public float inverseInertiaScale;

		public float otherInverseMassScale;

		public float otherInverseInertiaScale;
	}
	internal struct ModifiableContact
	{
		public Vector3 contact;

		public float separation;

		public Vector3 targetVelocity;

		public float maxImpulse;

		public Vector3 normal;

		public float restitution;

		public uint materialFlags;

		public ushort materialIndex;

		public ushort otherMaterialIndex;

		public float staticFriction;

		public float dynamicFriction;
	}
	internal struct ModifiableContactPatch
	{
		public enum Flags
		{
			HasFaceIndices = 1,
			HasModifiedMassRatios = 8,
			HasTargetVelocity = 0x10,
			HasMaxImpulse = 0x20,
			RegeneratePatches = 0x40
		}

		public ModifiableMassProperties massProperties;

		public Vector3 normal;

		public float restitution;

		public float dynamicFriction;

		public float staticFriction;

		public byte startContactIndex;

		public byte contactCount;

		public byte materialFlags;

		public byte internalFlags;

		public ushort materialIndex;

		public ushort otherMaterialIndex;
	}
	[NativeClass("Unity::FixedJoint")]
	[NativeHeader("Modules/Physics/FixedJoint.h")]
	[RequireComponent(typeof(Rigidbody))]
	public class FixedJoint : Joint
	{
	}
	[NativeClass("Unity::HingeJoint")]
	[NativeHeader("Modules/Physics/HingeJoint.h")]
	[RequireComponent(typeof(Rigidbody))]
	public class HingeJoint : Joint
	{
		public JointMotor motor
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_motor_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_motor_Injected(intPtr, ref value);
			}
		}

		public JointLimits limits
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_limits_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_limits_Injected(intPtr, ref value);
			}
		}

		public JointSpring spring
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_spring_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_spring_Injected(intPtr, ref value);
			}
		}

		public bool useMotor
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_useMotor_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_useMotor_Injected(intPtr, value);
			}
		}

		public bool useLimits
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_useLimits_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_useLimits_Injected(intPtr, value);
			}
		}

		public bool extendedLimits
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_extendedLimits_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_extendedLimits_Injected(intPtr, value);
			}
		}

		public bool useSpring
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_useSpring_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_useSpring_Injected(intPtr, value);
			}
		}

		public float velocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_velocity_Injected(intPtr);
			}
		}

		public float angle
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_angle_Injected(intPtr);
			}
		}

		public bool useAcceleration
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_useAcceleration_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_useAcceleration_Injected(intPtr, value);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_motor_Injected(IntPtr _unity_self, out JointMotor ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_motor_Injected(IntPtr _unity_self, [In] ref JointMotor value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_limits_Injected(IntPtr _unity_self, out JointLimits ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_limits_Injected(IntPtr _unity_self, [In] ref JointLimits value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_spring_Injected(IntPtr _unity_self, out JointSpring ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_spring_Injected(IntPtr _unity_self, [In] ref JointSpring value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_useMotor_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_useMotor_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_useLimits_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_useLimits_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_extendedLimits_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_extendedLimits_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_useSpring_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_useSpring_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_velocity_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_angle_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_useAcceleration_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_useAcceleration_Injected(IntPtr _unity_self, bool value);
	}
	[NativeHeader("Modules/Physics/Joint.h")]
	[NativeClass("Unity::Joint")]
	public class Joint : Component
	{
		public Rigidbody connectedBody
		{
			[NativeName("GetConnectedRigidbody")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<Rigidbody>(get_connectedBody_Injected(intPtr));
			}
			[NativeName("SetConnectedRigidbody")]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_connectedBody_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public ArticulationBody connectedArticulationBody
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<ArticulationBody>(get_connectedArticulationBody_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_connectedArticulationBody_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public Vector3 axis
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_axis_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_axis_Injected(intPtr, ref value);
			}
		}

		public Vector3 anchor
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_anchor_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_anchor_Injected(intPtr, ref value);
			}
		}

		public Vector3 connectedAnchor
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_connectedAnchor_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_connectedAnchor_Injected(intPtr, ref value);
			}
		}

		public bool autoConfigureConnectedAnchor
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_autoConfigureConnectedAnchor_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_autoConfigureConnectedAnchor_Injected(intPtr, value);
			}
		}

		public float breakForce
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_breakForce_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_breakForce_Injected(intPtr, value);
			}
		}

		public float breakTorque
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_breakTorque_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_breakTorque_Injected(intPtr, value);
			}
		}

		public bool enableCollision
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_enableCollision_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_enableCollision_Injected(intPtr, value);
			}
		}

		public bool enablePreprocessing
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_enablePreprocessing_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_enablePreprocessing_Injected(intPtr, value);
			}
		}

		public float massScale
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_massScale_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_massScale_Injected(intPtr, value);
			}
		}

		public float connectedMassScale
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_connectedMassScale_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_connectedMassScale_Injected(intPtr, value);
			}
		}

		public Vector3 currentForce
		{
			get
			{
				Vector3 linearForce = Vector3.zero;
				Vector3 angularForce = Vector3.zero;
				GetCurrentForces(ref linearForce, ref angularForce);
				return linearForce;
			}
		}

		public Vector3 currentTorque
		{
			get
			{
				Vector3 linearForce = Vector3.zero;
				Vector3 angularForce = Vector3.zero;
				GetCurrentForces(ref linearForce, ref angularForce);
				return angularForce;
			}
		}

		private void GetCurrentForces(ref Vector3 linearForce, ref Vector3 angularForce)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetCurrentForces_Injected(intPtr, ref linearForce, ref angularForce);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_connectedBody_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_connectedBody_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_connectedArticulationBody_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_connectedArticulationBody_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_axis_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_axis_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_anchor_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_anchor_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_connectedAnchor_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_connectedAnchor_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_autoConfigureConnectedAnchor_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_autoConfigureConnectedAnchor_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_breakForce_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_breakForce_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_breakTorque_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_breakTorque_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_enableCollision_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_enableCollision_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_enablePreprocessing_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_enablePreprocessing_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_massScale_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_massScale_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_connectedMassScale_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_connectedMassScale_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetCurrentForces_Injected(IntPtr _unity_self, ref Vector3 linearForce, ref Vector3 angularForce);
	}
	[Flags]
	public enum MeshColliderCookingOptions
	{
		None = 0,
		[Obsolete("No longer used because the problem this was trying to solve is gone since Unity 2018.3", true)]
		InflateConvexMesh = 1,
		CookForFasterSimulation = 2,
		EnableMeshCleaning = 4,
		WeldColocatedVertices = 8,
		UseFastMidphase = 0x10
	}
	[RequireComponent(typeof(Transform))]
	[NativeHeader("Runtime/Graphics/Mesh/Mesh.h")]
	[NativeHeader("Modules/Physics/MeshCollider.h")]
	public class MeshCollider : Collider
	{
		public Mesh sharedMesh
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<Mesh>(get_sharedMesh_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_sharedMesh_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public bool convex
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_convex_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_convex_Injected(intPtr, value);
			}
		}

		public MeshColliderCookingOptions cookingOptions
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_cookingOptions_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_cookingOptions_Injected(intPtr, value);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_sharedMesh_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_sharedMesh_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_convex_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_convex_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern MeshColliderCookingOptions get_cookingOptions_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_cookingOptions_Injected(IntPtr _unity_self, MeshColliderCookingOptions value);
	}
	public enum QueryTriggerInteraction
	{
		UseGlobal,
		Ignore,
		Collide
	}
	public enum SimulationMode
	{
		FixedUpdate,
		Update,
		Script
	}
	public enum SimulationStage : ushort
	{
		None = 0,
		PrepareSimulation = 1,
		RunSimulation = 2,
		PublishSimulationResults = 4,
		All = 7
	}
	public enum SimulationOption : ushort
	{
		None,
		SyncTransforms,
		IgnoreEmptyScenes,
		All
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct IntegrationInfo
	{
		[Flags]
		internal enum SupportedUnityFeatures
		{
			None = 0,
			DynamicsSupport = 2,
			SDKVisualDebuggerSupport = 4,
			ArticulationSupport = 8,
			ImmediateModeSupport = 0x10,
			VehicleSupport = 0x20,
			CharacterControllerSupport = 0x40
		}

		internal const uint k_InvalidID = 0u;

		internal const uint k_FallbackIntegrationId = 3737844653u;

		[FieldOffset(0)]
		private readonly uint m_Id;

		[FieldOffset(4)]
		private unsafe fixed ushort m_IntegrationVersion[3];

		[FieldOffset(10)]
		private unsafe fixed ushort m_SdkVersion[3];

		[FieldOffset(16)]
		private readonly SupportedUnityFeatures m_Features;

		[FieldOffset(20)]
		private unsafe fixed byte m_Name[16];

		[FieldOffset(36)]
		private unsafe fixed byte m_Desc[220];

		public readonly uint id => m_Id;

		public unsafe string name
		{
			get
			{
				fixed (byte* value = m_Name)
				{
					return Marshal.PtrToStringAnsi(new IntPtr(value));
				}
			}
		}

		public unsafe string description
		{
			get
			{
				fixed (byte* desc = m_Desc)
				{
					return Marshal.PtrToStringAnsi(new IntPtr(desc));
				}
			}
		}

		public bool isFallback => id == 3737844653u;
	}
	[UsedByNativeCode]
	public readonly struct ContactPairHeader
	{
		internal readonly int m_BodyID;

		internal readonly int m_OtherBodyID;

		internal readonly IntPtr m_StartPtr;

		internal readonly uint m_NbPairs;

		internal readonly CollisionPairHeaderFlags m_Flags;

		internal readonly Vector3 m_RelativeVelocity;

		public int bodyInstanceID => m_BodyID;

		public int otherBodyInstanceID => m_OtherBodyID;

		public Component body => Physics.GetBodyByInstanceID(m_BodyID);

		public Component otherBody => Physics.GetBodyByInstanceID(m_OtherBodyID);

		public int pairCount => (int)m_NbPairs;

		internal bool hasRemovedBody => (m_Flags & CollisionPairHeaderFlags.RemovedActor) != 0 || (m_Flags & CollisionPairHeaderFlags.RemovedOtherActor) != 0;

		[Obsolete("Please use ContactPairHeader.bodyInstanceID instead. (UnityUpgradable) -> bodyInstanceID", false)]
		public int BodyInstanceID => bodyInstanceID;

		[Obsolete("Please use ContactPairHeader.otherBodyInstanceID instead. (UnityUpgradable) -> otherBodyInstanceID", false)]
		public int OtherBodyInstanceID => otherBodyInstanceID;

		[Obsolete("Please use ContactPairHeader.body instead. (UnityUpgradable) -> body", false)]
		public Component Body => body;

		[Obsolete("Please use ContactPairHeader.otherBody instead. (UnityUpgradable) -> otherBody", false)]
		public Component OtherBody => otherBody;

		[Obsolete("Please use ContactPairHeader.pairCount instead. (UnityUpgradable) -> pairCount", false)]
		public int PairCount => pairCount;

		public unsafe ref readonly ContactPair GetContactPair(int index)
		{
			return ref *GetContactPair_Internal(index);
		}

		internal unsafe ContactPair* GetContactPair_Internal(int index)
		{
			if (index >= m_NbPairs)
			{
				throw new IndexOutOfRangeException("Invalid ContactPair index. Index should be greater than 0 and less than ContactPairHeader.PairCount");
			}
			return (ContactPair*)(m_StartPtr.ToInt64() + index * sizeof(ContactPair));
		}
	}
	[UsedByNativeCode]
	public readonly struct ContactPair
	{
		private const uint c_InvalidFaceIndex = uint.MaxValue;

		internal readonly int m_ColliderID;

		internal readonly int m_OtherColliderID;

		internal readonly IntPtr m_StartPtr;

		internal readonly uint m_NbPoints;

		internal readonly CollisionPairFlags m_Flags;

		internal readonly CollisionPairEventFlags m_Events;

		internal readonly Vector3 m_ImpulseSum;

		public int colliderInstanceID => m_ColliderID;

		public int otherColliderInstanceID => m_OtherColliderID;

		public Collider collider => (m_ColliderID == 0) ? null : Physics.GetColliderByInstanceID(m_ColliderID);

		public Collider otherCollider => (m_OtherColliderID == 0) ? null : Physics.GetColliderByInstanceID(m_OtherColliderID);

		public int contactCount => (int)m_NbPoints;

		public Vector3 impulseSum => m_ImpulseSum;

		public bool isCollisionEnter => (m_Events & CollisionPairEventFlags.NotifyTouchFound) != 0;

		public bool isCollisionExit => (m_Events & CollisionPairEventFlags.NotifyTouchLost) != 0;

		public bool isCollisionStay => (m_Events & CollisionPairEventFlags.NotifyTouchPersists) != 0;

		internal bool hasRemovedCollider => (m_Flags & CollisionPairFlags.RemovedShape) != 0 || (m_Flags & CollisionPairFlags.RemovedOtherShape) != 0;

		[Obsolete("Please use ContactPair.colliderInstanceID instead. (UnityUpgradable) -> colliderInstanceID", false)]
		public int ColliderInstanceID => colliderInstanceID;

		[Obsolete("Please use ContactPair.otherColliderInstanceID instead. (UnityUpgradable) -> otherColliderInstanceID", false)]
		public int OtherColliderInstanceID => otherColliderInstanceID;

		[Obsolete("Please use ContactPair.collider instead. (UnityUpgradable) -> collider", false)]
		public Collider Collider => collider;

		[Obsolete("Please use ContactPair.otherCollider instead. (UnityUpgradable) -> otherCollider", false)]
		public Collider OtherCollider => otherCollider;

		[Obsolete("Please use ContactPair.contactCount instead. (UnityUpgradable) -> contactCount", false)]
		public int ContactCount => contactCount;

		[Obsolete("Please use ContactPair.impulseSum instead. (UnityUpgradable) -> impulseSum", false)]
		public Vector3 ImpulseSum => impulseSum;

		[Obsolete("Please use ContactPair.isCollisionEnter instead. (UnityUpgradable) -> isCollisionEnter", false)]
		public bool IsCollisionEnter => isCollisionEnter;

		[Obsolete("Please use ContactPair.isCollisionExit instead. (UnityUpgradable) -> isCollisionExit", false)]
		public bool IsCollisionExit => isCollisionExit;

		[Obsolete("Please use ContactPair.isCollisionStay instead. (UnityUpgradable) -> isCollisionStay", false)]
		public bool IsCollisionStay => isCollisionStay;

		internal int ExtractContacts(List<ContactPoint> managedContainer, bool flipped)
		{
			int num = (int)Math.Min(managedContainer.Capacity, m_NbPoints);
			managedContainer.Clear();
			for (int i = 0; i < num; i++)
			{
				ref readonly ContactPairPoint contactPoint = ref GetContactPoint(i);
				ContactPoint item = new ContactPoint
				{
					m_Point = contactPoint.position,
					m_Impulse = contactPoint.impulse,
					m_Separation = contactPoint.separation
				};
				if (flipped)
				{
					item.m_Normal = -contactPoint.normal;
					item.m_ThisColliderInstanceID = m_OtherColliderID;
					item.m_OtherColliderInstanceID = m_ColliderID;
				}
				else
				{
					item.m_Normal = contactPoint.normal;
					item.m_ThisColliderInstanceID = m_ColliderID;
					item.m_OtherColliderInstanceID = m_OtherColliderID;
				}
				managedContainer.Add(item);
			}
			return num;
		}

		internal int ExtractContactsArray(ContactPoint[] managedContainer, bool flipped)
		{
			int num = (int)Math.Min(managedContainer.Length, m_NbPoints);
			for (int i = 0; i < num; i++)
			{
				ref readonly ContactPairPoint contactPoint = ref GetContactPoint(i);
				ContactPoint contactPoint2 = new ContactPoint
				{
					m_Point = contactPoint.position,
					m_Impulse = contactPoint.impulse,
					m_Separation = contactPoint.separation
				};
				if (flipped)
				{
					contactPoint2.m_Normal = -contactPoint.normal;
					contactPoint2.m_ThisColliderInstanceID = m_OtherColliderID;
					contactPoint2.m_OtherColliderInstanceID = m_ColliderID;
				}
				else
				{
					contactPoint2.m_Normal = contactPoint.normal;
					contactPoint2.m_ThisColliderInstanceID = m_ColliderID;
					contactPoint2.m_OtherColliderInstanceID = m_OtherColliderID;
				}
				managedContainer[i] = contactPoint2;
			}
			return num;
		}

		public void CopyToNativeArray(NativeArray<ContactPairPoint> buffer)
		{
			int num = Mathf.Min(buffer.Length, contactCount);
			for (int i = 0; i < num; i++)
			{
				buffer[i] = GetContactPoint(i);
			}
		}

		public unsafe ref readonly ContactPairPoint GetContactPoint(int index)
		{
			return ref *GetContactPoint_Internal(index);
		}

		public unsafe uint GetContactPointFaceIndex(int contactIndex)
		{
			uint internalFaceIndex = GetContactPoint_Internal(contactIndex)->m_InternalFaceIndex0;
			uint internalFaceIndex2 = GetContactPoint_Internal(contactIndex)->m_InternalFaceIndex1;
			if (internalFaceIndex != uint.MaxValue)
			{
				return Physics.TranslateTriangleIndexFromID(m_ColliderID, internalFaceIndex);
			}
			if (internalFaceIndex2 != uint.MaxValue)
			{
				return Physics.TranslateTriangleIndexFromID(m_OtherColliderID, internalFaceIndex2);
			}
			return uint.MaxValue;
		}

		internal unsafe ContactPairPoint* GetContactPoint_Internal(int index)
		{
			if (index >= m_NbPoints)
			{
				throw new IndexOutOfRangeException("Invalid ContactPairPoint index. Index should be greater than 0 and less than ContactPair.ContactCount");
			}
			return (ContactPairPoint*)(m_StartPtr.ToInt64() + index * sizeof(ContactPairPoint));
		}
	}
	[UsedByNativeCode]
	public readonly struct ContactPairPoint
	{
		internal readonly Vector3 m_Position;

		internal readonly float m_Separation;

		internal readonly Vector3 m_Normal;

		internal readonly uint m_InternalFaceIndex0;

		internal readonly Vector3 m_Impulse;

		internal readonly uint m_InternalFaceIndex1;

		public Vector3 position => m_Position;

		public float separation => m_Separation;

		public Vector3 normal => m_Normal;

		public Vector3 impulse => m_Impulse;

		[Obsolete("Please use ContactPairPoint.position instead. (UnityUpgradable) -> position", false)]
		public Vector3 Position => position;

		[Obsolete("Please use ContactPairPoint.separation instead. (UnityUpgradable) -> separation", false)]
		public float Separation => separation;

		[Obsolete("Please use ContactPairPoint.normal instead. (UnityUpgradable) -> normal", false)]
		public Vector3 Normal => normal;

		[Obsolete("Please use ContactPairPoint.impulse instead. (UnityUpgradable) -> impulse", false)]
		public Vector3 Impulse => impulse;
	}
	internal enum CollisionPairHeaderFlags : ushort
	{
		RemovedActor = 1,
		RemovedOtherActor
	}
	internal enum CollisionPairFlags : ushort
	{
		RemovedShape = 1,
		RemovedOtherShape = 2,
		ActorPairHasFirstTouch = 4,
		ActorPairLostTouch = 8,
		InternalHasImpulses = 0x10,
		InternalContactsAreFlipped = 0x20
	}
	internal enum CollisionPairEventFlags : ushort
	{
		SolveContacts = 1,
		ModifyContacts = 2,
		NotifyTouchFound = 4,
		NotifyTouchPersists = 8,
		NotifyTouchLost = 16,
		NotifyTouchCCD = 32,
		NotifyThresholdForceFound = 64,
		NotifyThresholdForcePersists = 128,
		NotifyThresholdForceLost = 256,
		NotifyContactPoint = 512,
		DetectDiscreteContact = 1024,
		DetectCCDContact = 2048,
		PreSolverVelocity = 4096,
		PostSolverVelocity = 8192,
		ContactEventPose = 16384,
		NextFree = 32768,
		ContactDefault = 1025,
		TriggerDefault = 1044
	}
	public enum PhysicsMaterialCombine
	{
		Average,
		Multiply,
		Minimum,
		Maximum
	}
	[NativeHeader("Modules/Physics/PhysicsMaterial.h")]
	public class PhysicsMaterial : Object
	{
		public float bounciness
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_bounciness_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_bounciness_Injected(intPtr, value);
			}
		}

		public float dynamicFriction
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_dynamicFriction_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_dynamicFriction_Injected(intPtr, value);
			}
		}

		public float staticFriction
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_staticFriction_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_staticFriction_Injected(intPtr, value);
			}
		}

		public PhysicsMaterialCombine frictionCombine
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_frictionCombine_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_frictionCombine_Injected(intPtr, value);
			}
		}

		public PhysicsMaterialCombine bounceCombine
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_bounceCombine_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_bounceCombine_Injected(intPtr, value);
			}
		}

		public PhysicsMaterial()
		{
			Internal_CreateDynamicsMaterial(this, "DynamicMaterial");
		}

		public PhysicsMaterial(string name)
		{
			Internal_CreateDynamicsMaterial(this, name);
		}

		private unsafe static void Internal_CreateDynamicsMaterial([Writable] PhysicsMaterial mat, string name)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						Internal_CreateDynamicsMaterial_Injected(mat, ref managedSpanWrapper);
						return;
					}
				}
				Internal_CreateDynamicsMaterial_Injected(mat, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_CreateDynamicsMaterial_Injected([Writable] PhysicsMaterial mat, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_bounciness_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_bounciness_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_dynamicFriction_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_dynamicFriction_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_staticFriction_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_staticFriction_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern PhysicsMaterialCombine get_frictionCombine_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_frictionCombine_Injected(IntPtr _unity_self, PhysicsMaterialCombine value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern PhysicsMaterialCombine get_bounceCombine_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_bounceCombine_Injected(IntPtr _unity_self, PhysicsMaterialCombine value);
	}
	[Obsolete("PhysicMaterialCombine has been renamed to PhysicsMaterialCombine. Please use PhysicsMaterialCombine instead. (UnityUpgradable) -> PhysicsMaterialCombine", true)]
	public enum PhysicMaterialCombine
	{
		Average = 0,
		Minimum = 2,
		Multiply = 1,
		Maximum = 3
	}
	[NativeClass(null)]
	[Obsolete("PhysicMaterial has been renamed to PhysicsMaterial. Please use PhysicsMaterial instead. (UnityUpgradable) -> PhysicsMaterial", true)]
	public class PhysicMaterial : Object
	{
		public float bounciness { get; set; }

		public float dynamicFriction { get; set; }

		public float staticFriction { get; set; }

		public PhysicMaterialCombine frictionCombine { get; set; }

		public PhysicMaterialCombine bounceCombine { get; set; }

		[Obsolete("Use PhysicMaterial.bounciness instead (UnityUpgradable) -> bounciness")]
		public float bouncyness { get; set; }

		public PhysicMaterial()
		{
		}

		public PhysicMaterial(string name)
		{
		}
	}
	[NativeHeader("Modules/Physics/Public/PhysicsSceneHandle.h")]
	[NativeHeader("Modules/Physics/PhysicsQuery.h")]
	public struct PhysicsScene : IEquatable<PhysicsScene>
	{
		private int m_index;

		private int m_version;

		public override string ToString()
		{
			return $"PhysicsScene(Index: {m_index}, Version: {m_version})";
		}

		public static bool operator ==(PhysicsScene lhs, PhysicsScene rhs)
		{
			return lhs.m_index == rhs.m_index && lhs.m_version == rhs.m_version;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(PhysicsScene lhs, PhysicsScene rhs)
		{
			return !(lhs == rhs);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(m_index, m_version);
		}

		public override bool Equals(object other)
		{
			if (!(other is PhysicsScene physicsScene))
			{
				return false;
			}
			return this == physicsScene;
		}

		public bool Equals(PhysicsScene other)
		{
			return this == other;
		}

		public bool IsValid()
		{
			return IsValid_Internal(this);
		}

		[NativeMethod("IsPhysicsSceneValid")]
		[StaticAccessor("GetPhysicsManager()", StaticAccessorType.Dot)]
		private static bool IsValid_Internal(PhysicsScene physicsScene)
		{
			return IsValid_Internal_Injected(ref physicsScene);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static PhysicsScene GetDefaultScene()
		{
			return new PhysicsScene
			{
				m_index = 0,
				m_version = 1
			};
		}

		public bool IsEmpty()
		{
			if (IsValid())
			{
				return IsEmpty_Internal(this);
			}
			throw new InvalidOperationException("Cannot check if physics scene is empty as it is invalid.");
		}

		[NativeMethod("IsPhysicsWorldEmpty")]
		[StaticAccessor("GetPhysicsManager()", StaticAccessorType.Dot)]
		private static bool IsEmpty_Internal(PhysicsScene physicsScene)
		{
			return IsEmpty_Internal_Injected(ref physicsScene);
		}

		public void Simulate(float step)
		{
			if (IsValid())
			{
				if (this == GetDefaultScene() && Physics.simulationMode != SimulationMode.Script)
				{
					Debug.LogWarning("PhysicsScene.Simulate(...) was called but simulation mode is not set to Script. You should set simulation mode to Script first before calling this function therefore the simulation was not run.");
				}
				else
				{
					Physics.Simulate_Internal(this, step, SimulationStage.All, SimulationOption.All);
				}
				return;
			}
			throw new InvalidOperationException("Cannot simulate the physics scene as it is invalid.");
		}

		public void RunSimulationStages(float step, SimulationStage stages, [UnityEngine.Internal.DefaultValue("SimulationOption.All")] SimulationOption options = SimulationOption.All)
		{
			if (!IsValid())
			{
				throw new InvalidOperationException("Cannot simulate the physics scene as it is invalid.");
			}
			if (this == GetDefaultScene() && Physics.simulationMode != SimulationMode.Script)
			{
				Debug.LogWarning("PhysicsScene.Simulate(...) was called but simulation mode is not set to Script. You should set simulation mode to Script first before calling this function therefore the simulation was not run.");
			}
			else
			{
				Physics.Simulate_Internal(this, step, stages, options);
			}
		}

		public void InterpolateBodies()
		{
			if (!IsValid())
			{
				throw new InvalidOperationException("Cannot interpolate the physics scene as it is invalid.");
			}
			if (this == Physics.defaultPhysicsScene)
			{
				Debug.LogWarning("PhysicsScene.InterpolateBodies() was called on the default Physics Scene. This is done automatically and the call will be ignored");
			}
			else
			{
				Physics.InterpolateBodies_Internal(this);
			}
		}

		public void ResetInterpolationPoses()
		{
			if (!IsValid())
			{
				throw new InvalidOperationException("Cannot reset poses of the physics scene as it is invalid.");
			}
			if (this == Physics.defaultPhysicsScene)
			{
				Debug.LogWarning("PhysicsScene.ResetInterpolationPoses() was called on the default Physics Scene. This is done automatically and the call will be ignored");
			}
			else
			{
				Physics.ResetInterpolationPoses_Internal(this);
			}
		}

		public bool Raycast(Vector3 origin, Vector3 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance = float.PositiveInfinity, [UnityEngine.Internal.DefaultValue("Physics.DefaultRaycastLayers")] int layerMask = -5, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			float magnitude = direction.magnitude;
			if (magnitude > float.Epsilon)
			{
				Vector3 direction2 = direction / magnitude;
				return Internal_RaycastTest(ray: new Ray(origin, direction2), physicsScene: this, maxDistance: maxDistance, layerMask: layerMask, queryTriggerInteraction: queryTriggerInteraction);
			}
			return false;
		}

		[FreeFunction("Physics::RaycastTest")]
		private static bool Internal_RaycastTest(PhysicsScene physicsScene, Ray ray, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return Internal_RaycastTest_Injected(ref physicsScene, ref ray, maxDistance, layerMask, queryTriggerInteraction);
		}

		public bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance = float.PositiveInfinity, [UnityEngine.Internal.DefaultValue("Physics.DefaultRaycastLayers")] int layerMask = -5, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			hitInfo = default(RaycastHit);
			float magnitude = direction.magnitude;
			if (magnitude > float.Epsilon)
			{
				Vector3 direction2 = direction / magnitude;
				return Internal_Raycast(ray: new Ray(origin, direction2), physicsScene: this, maxDistance: maxDistance, hit: ref hitInfo, layerMask: layerMask, queryTriggerInteraction: queryTriggerInteraction);
			}
			return false;
		}

		[FreeFunction("Physics::Raycast")]
		private static bool Internal_Raycast(PhysicsScene physicsScene, Ray ray, float maxDistance, ref RaycastHit hit, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return Internal_Raycast_Injected(ref physicsScene, ref ray, maxDistance, ref hit, layerMask, queryTriggerInteraction);
		}

		public int Raycast(Vector3 origin, Vector3 direction, RaycastHit[] raycastHits, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance = float.PositiveInfinity, [UnityEngine.Internal.DefaultValue("Physics.DefaultRaycastLayers")] int layerMask = -5, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			float magnitude = direction.magnitude;
			if (magnitude > float.Epsilon)
			{
				return Internal_RaycastNonAlloc(ray: new Ray(origin, direction.normalized), physicsScene: this, raycastHits: raycastHits, maxDistance: maxDistance, mask: layerMask, queryTriggerInteraction: queryTriggerInteraction);
			}
			return 0;
		}

		[FreeFunction("Physics::RaycastNonAlloc")]
		private unsafe static int Internal_RaycastNonAlloc(PhysicsScene physicsScene, Ray ray, RaycastHit[] raycastHits, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction)
		{
			Span<RaycastHit> span = new Span<RaycastHit>(raycastHits);
			int result;
			fixed (RaycastHit* begin = span)
			{
				ManagedSpanWrapper raycastHits2 = new ManagedSpanWrapper(begin, span.Length);
				result = Internal_RaycastNonAlloc_Injected(ref physicsScene, ref ray, ref raycastHits2, maxDistance, mask, queryTriggerInteraction);
			}
			return result;
		}

		[FreeFunction("Physics::CapsuleCast")]
		private static bool Query_CapsuleCast(PhysicsScene physicsScene, Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, ref RaycastHit hitInfo, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return Query_CapsuleCast_Injected(ref physicsScene, ref point1, ref point2, radius, ref direction, maxDistance, ref hitInfo, layerMask, queryTriggerInteraction);
		}

		private static bool Internal_CapsuleCast(PhysicsScene physicsScene, Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			float magnitude = direction.magnitude;
			hitInfo = default(RaycastHit);
			if (magnitude > float.Epsilon)
			{
				Vector3 direction2 = direction / magnitude;
				return Query_CapsuleCast(physicsScene, point1, point2, radius, direction2, maxDistance, ref hitInfo, layerMask, queryTriggerInteraction);
			}
			return false;
		}

		public bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance = float.PositiveInfinity, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask = -5, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			return Internal_CapsuleCast(this, point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
		}

		[FreeFunction("Physics::CapsuleCastNonAlloc")]
		private unsafe static int Internal_CapsuleCastNonAlloc(PhysicsScene physicsScene, Vector3 p0, Vector3 p1, float radius, Vector3 direction, RaycastHit[] raycastHits, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction)
		{
			Span<RaycastHit> span = new Span<RaycastHit>(raycastHits);
			int result;
			fixed (RaycastHit* begin = span)
			{
				ManagedSpanWrapper raycastHits2 = new ManagedSpanWrapper(begin, span.Length);
				result = Internal_CapsuleCastNonAlloc_Injected(ref physicsScene, ref p0, ref p1, radius, ref direction, ref raycastHits2, maxDistance, mask, queryTriggerInteraction);
			}
			return result;
		}

		public int CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance = float.PositiveInfinity, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask = -5, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			float magnitude = direction.magnitude;
			if (magnitude > float.Epsilon)
			{
				return Internal_CapsuleCastNonAlloc(this, point1, point2, radius, direction, results, maxDistance, layerMask, queryTriggerInteraction);
			}
			return 0;
		}

		[FreeFunction("Physics::OverlapCapsuleNonAlloc")]
		private static int OverlapCapsuleNonAlloc_Internal(PhysicsScene physicsScene, Vector3 point0, Vector3 point1, float radius, [Unmarshalled] Collider[] results, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return OverlapCapsuleNonAlloc_Internal_Injected(ref physicsScene, ref point0, ref point1, radius, results, layerMask, queryTriggerInteraction);
		}

		public int OverlapCapsule(Vector3 point0, Vector3 point1, float radius, Collider[] results, [UnityEngine.Internal.DefaultValue("AllLayers")] int layerMask = -1, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			return OverlapCapsuleNonAlloc_Internal(this, point0, point1, radius, results, layerMask, queryTriggerInteraction);
		}

		[FreeFunction("Physics::SphereCast")]
		private static bool Query_SphereCast(PhysicsScene physicsScene, Vector3 origin, float radius, Vector3 direction, float maxDistance, ref RaycastHit hitInfo, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return Query_SphereCast_Injected(ref physicsScene, ref origin, radius, ref direction, maxDistance, ref hitInfo, layerMask, queryTriggerInteraction);
		}

		private static bool Internal_SphereCast(PhysicsScene physicsScene, Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			float magnitude = direction.magnitude;
			hitInfo = default(RaycastHit);
			if (magnitude > float.Epsilon)
			{
				Vector3 direction2 = direction / magnitude;
				return Query_SphereCast(physicsScene, origin, radius, direction2, maxDistance, ref hitInfo, layerMask, queryTriggerInteraction);
			}
			return false;
		}

		public bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance = float.PositiveInfinity, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask = -5, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			return Internal_SphereCast(this, origin, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
		}

		[FreeFunction("Physics::SphereCastNonAlloc")]
		private unsafe static int Internal_SphereCastNonAlloc(PhysicsScene physicsScene, Vector3 origin, float radius, Vector3 direction, RaycastHit[] raycastHits, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction)
		{
			Span<RaycastHit> span = new Span<RaycastHit>(raycastHits);
			int result;
			fixed (RaycastHit* begin = span)
			{
				ManagedSpanWrapper raycastHits2 = new ManagedSpanWrapper(begin, span.Length);
				result = Internal_SphereCastNonAlloc_Injected(ref physicsScene, ref origin, radius, ref direction, ref raycastHits2, maxDistance, mask, queryTriggerInteraction);
			}
			return result;
		}

		public int SphereCast(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance = float.PositiveInfinity, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask = -5, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			float magnitude = direction.magnitude;
			if (magnitude > float.Epsilon)
			{
				return Internal_SphereCastNonAlloc(this, origin, radius, direction, results, maxDistance, layerMask, queryTriggerInteraction);
			}
			return 0;
		}

		[FreeFunction("Physics::OverlapSphereNonAlloc")]
		private static int OverlapSphereNonAlloc_Internal(PhysicsScene physicsScene, Vector3 position, float radius, [Unmarshalled] Collider[] results, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return OverlapSphereNonAlloc_Internal_Injected(ref physicsScene, ref position, radius, results, layerMask, queryTriggerInteraction);
		}

		public int OverlapSphere(Vector3 position, float radius, Collider[] results, [UnityEngine.Internal.DefaultValue("AllLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			return OverlapSphereNonAlloc_Internal(this, position, radius, results, layerMask, queryTriggerInteraction);
		}

		[FreeFunction("Physics::BoxCast")]
		private static bool Query_BoxCast(PhysicsScene physicsScene, Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, ref RaycastHit outHit, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return Query_BoxCast_Injected(ref physicsScene, ref center, ref halfExtents, ref direction, ref orientation, maxDistance, ref outHit, layerMask, queryTriggerInteraction);
		}

		private static bool Internal_BoxCast(PhysicsScene physicsScene, Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			float magnitude = direction.magnitude;
			hitInfo = default(RaycastHit);
			if (magnitude > float.Epsilon)
			{
				Vector3 direction2 = direction / magnitude;
				return Query_BoxCast(physicsScene, center, halfExtents, direction2, orientation, maxDistance, ref hitInfo, layerMask, queryTriggerInteraction);
			}
			return false;
		}

		public bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, [UnityEngine.Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance = float.PositiveInfinity, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask = -5, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			return Internal_BoxCast(this, center, halfExtents, orientation, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo)
		{
			return Internal_BoxCast(this, center, halfExtents, Quaternion.identity, direction, out hitInfo, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
		}

		[FreeFunction("Physics::OverlapBoxNonAlloc")]
		private static int OverlapBoxNonAlloc_Internal(PhysicsScene physicsScene, Vector3 center, Vector3 halfExtents, [Unmarshalled] Collider[] results, Quaternion orientation, int mask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return OverlapBoxNonAlloc_Internal_Injected(ref physicsScene, ref center, ref halfExtents, results, ref orientation, mask, queryTriggerInteraction);
		}

		public int OverlapBox(Vector3 center, Vector3 halfExtents, Collider[] results, [UnityEngine.Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask = -5, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			return OverlapBoxNonAlloc_Internal(this, center, halfExtents, results, orientation, layerMask, queryTriggerInteraction);
		}

		[ExcludeFromDocs]
		public int OverlapBox(Vector3 center, Vector3 halfExtents, Collider[] results)
		{
			return OverlapBoxNonAlloc_Internal(this, center, halfExtents, results, Quaternion.identity, -5, QueryTriggerInteraction.UseGlobal);
		}

		[FreeFunction("Physics::BoxCastNonAlloc")]
		private unsafe static int Internal_BoxCastNonAlloc(PhysicsScene physicsScene, Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] raycastHits, Quaternion orientation, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction)
		{
			Span<RaycastHit> span = new Span<RaycastHit>(raycastHits);
			int result;
			fixed (RaycastHit* begin = span)
			{
				ManagedSpanWrapper raycastHits2 = new ManagedSpanWrapper(begin, span.Length);
				result = Internal_BoxCastNonAlloc_Injected(ref physicsScene, ref center, ref halfExtents, ref direction, ref raycastHits2, ref orientation, maxDistance, mask, queryTriggerInteraction);
			}
			return result;
		}

		public int BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, [UnityEngine.Internal.DefaultValue("Quaternion.identity")] Quaternion orientation, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance = float.PositiveInfinity, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask = -5, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			float magnitude = direction.magnitude;
			if (magnitude > float.Epsilon)
			{
				return Internal_BoxCastNonAlloc(this, center, halfExtents, direction, results, orientation, maxDistance, layerMask, queryTriggerInteraction);
			}
			return 0;
		}

		[ExcludeFromDocs]
		public int BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results)
		{
			return BoxCast(center, halfExtents, direction, results, Quaternion.identity);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsValid_Internal_Injected([In] ref PhysicsScene physicsScene);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsEmpty_Internal_Injected([In] ref PhysicsScene physicsScene);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Internal_RaycastTest_Injected([In] ref PhysicsScene physicsScene, [In] ref Ray ray, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Internal_Raycast_Injected([In] ref PhysicsScene physicsScene, [In] ref Ray ray, float maxDistance, ref RaycastHit hit, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int Internal_RaycastNonAlloc_Injected([In] ref PhysicsScene physicsScene, [In] ref Ray ray, ref ManagedSpanWrapper raycastHits, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Query_CapsuleCast_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 point1, [In] ref Vector3 point2, float radius, [In] ref Vector3 direction, float maxDistance, ref RaycastHit hitInfo, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int Internal_CapsuleCastNonAlloc_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 p0, [In] ref Vector3 p1, float radius, [In] ref Vector3 direction, ref ManagedSpanWrapper raycastHits, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int OverlapCapsuleNonAlloc_Internal_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 point0, [In] ref Vector3 point1, float radius, Collider[] results, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Query_SphereCast_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 origin, float radius, [In] ref Vector3 direction, float maxDistance, ref RaycastHit hitInfo, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int Internal_SphereCastNonAlloc_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 origin, float radius, [In] ref Vector3 direction, ref ManagedSpanWrapper raycastHits, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int OverlapSphereNonAlloc_Internal_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 position, float radius, Collider[] results, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Query_BoxCast_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 center, [In] ref Vector3 halfExtents, [In] ref Vector3 direction, [In] ref Quaternion orientation, float maxDistance, ref RaycastHit outHit, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int OverlapBoxNonAlloc_Internal_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 center, [In] ref Vector3 halfExtents, Collider[] results, [In] ref Quaternion orientation, int mask, QueryTriggerInteraction queryTriggerInteraction);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int Internal_BoxCastNonAlloc_Injected([In] ref PhysicsScene physicsScene, [In] ref Vector3 center, [In] ref Vector3 halfExtents, [In] ref Vector3 direction, ref ManagedSpanWrapper raycastHits, [In] ref Quaternion orientation, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction);
	}
	public static class PhysicsSceneExtensions
	{
		public static PhysicsScene GetPhysicsScene(this Scene scene)
		{
			if (!scene.IsValid())
			{
				throw new ArgumentException("Cannot get physics scene; Unity scene is invalid.", "scene");
			}
			PhysicsScene physicsScene_Internal = GetPhysicsScene_Internal(scene);
			if (physicsScene_Internal.IsValid())
			{
				return physicsScene_Internal;
			}
			throw new Exception("The physics scene associated with the Unity scene is invalid.");
		}

		[StaticAccessor("GetPhysicsManager()", StaticAccessorType.Dot)]
		[NativeMethod("GetPhysicsSceneFromUnityScene")]
		private static PhysicsScene GetPhysicsScene_Internal(Scene scene)
		{
			GetPhysicsScene_Internal_Injected(ref scene, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetPhysicsScene_Internal_Injected([In] ref Scene scene, out PhysicsScene ret);
	}
	public struct QueryParameters(int layerMask = -5, bool hitMultipleFaces = false, QueryTriggerInteraction hitTriggers = QueryTriggerInteraction.UseGlobal, bool hitBackfaces = false)
	{
		public int layerMask = layerMask;

		public bool hitMultipleFaces = hitMultipleFaces;

		public QueryTriggerInteraction hitTriggers = hitTriggers;

		public bool hitBackfaces = hitBackfaces;

		public static QueryParameters Default => new QueryParameters(-5, false, QueryTriggerInteraction.UseGlobal, false);
	}
	public struct ColliderHit
	{
		private int m_ColliderInstanceID;

		public int instanceID => m_ColliderInstanceID;

		public Collider collider => Object.FindObjectFromInstanceID(instanceID) as Collider;
	}
	[NativeHeader("Modules/Physics/BatchCommands/RaycastCommand.h")]
	[NativeHeader("Runtime/Jobs/ScriptBindings/JobsBindingsTypes.h")]
	public struct RaycastCommand
	{
		public QueryParameters queryParameters;

		public Vector3 from { get; set; }

		public Vector3 direction { get; set; }

		public PhysicsScene physicsScene { get; set; }

		public float distance { get; set; }

		[Obsolete("maxHits property was moved to be a part of RaycastCommand.ScheduleBatch.", false)]
		public int maxHits
		{
			get
			{
				return 1;
			}
			set
			{
			}
		}

		[Obsolete("Layer Mask is now a part of QueryParameters struct", false)]
		public int layerMask
		{
			get
			{
				return queryParameters.layerMask;
			}
			set
			{
				queryParameters.layerMask = value;
			}
		}

		public RaycastCommand(Vector3 from, Vector3 direction, QueryParameters queryParameters, float distance = float.MaxValue)
		{
			this.from = from;
			this.direction = direction;
			physicsScene = Physics.defaultPhysicsScene;
			this.distance = distance;
			this.queryParameters = queryParameters;
		}

		public RaycastCommand(PhysicsScene physicsScene, Vector3 from, Vector3 direction, QueryParameters queryParameters, float distance = float.MaxValue)
		{
			this.from = from;
			this.direction = direction;
			this.physicsScene = physicsScene;
			this.distance = distance;
			this.queryParameters = queryParameters;
		}

		public unsafe static JobHandle ScheduleBatch(NativeArray<RaycastCommand> commands, NativeArray<RaycastHit> results, int minCommandsPerJob, int maxHits, JobHandle dependsOn = default(JobHandle))
		{
			if (maxHits < 1)
			{
				Debug.LogWarning("maxHits should be greater than 0.");
				return default(JobHandle);
			}
			if (results.Length < maxHits * commands.Length)
			{
				Debug.LogWarning("The supplied results buffer is too small, there should be at least maxHits space per each command in the batch.");
				return default(JobHandle);
			}
			BatchQueryJob<RaycastCommand, RaycastHit> output = new BatchQueryJob<RaycastCommand, RaycastHit>(commands, results);
			JobsUtility.JobScheduleParameters parameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf(ref output), BatchQueryJobStruct<BatchQueryJob<RaycastCommand, RaycastHit>>.Initialize(), dependsOn, ScheduleMode.Batched);
			return ScheduleRaycastBatch(ref parameters, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(commands), commands.Length, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(results), results.Length, minCommandsPerJob, maxHits);
		}

		public static JobHandle ScheduleBatch(NativeArray<RaycastCommand> commands, NativeArray<RaycastHit> results, int minCommandsPerJob, JobHandle dependsOn = default(JobHandle))
		{
			return ScheduleBatch(commands, results, minCommandsPerJob, 1, dependsOn);
		}

		[FreeFunction("ScheduleRaycastCommandBatch", ThrowsException = true)]
		private unsafe static JobHandle ScheduleRaycastBatch(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, int maxHits)
		{
			ScheduleRaycastBatch_Injected(ref parameters, commands, commandLen, result, resultLen, minCommandsPerJob, maxHits, out var ret);
			return ret;
		}

		[Obsolete("This struct signature is no longer supported. Use struct with a QueryParameters instead", false)]
		public RaycastCommand(Vector3 from, Vector3 direction, float distance = float.MaxValue, int layerMask = -5, int maxHits = 1)
		{
			this.from = from;
			this.direction = direction;
			physicsScene = Physics.defaultPhysicsScene;
			queryParameters = QueryParameters.Default;
			this.distance = distance;
			this.layerMask = layerMask;
		}

		[Obsolete("This struct signature is no longer supported. Use struct with a QueryParameters instead", false)]
		public RaycastCommand(PhysicsScene physicsScene, Vector3 from, Vector3 direction, float distance = float.MaxValue, int layerMask = -5, int maxHits = 1)
		{
			this.from = from;
			this.direction = direction;
			this.physicsScene = physicsScene;
			queryParameters = QueryParameters.Default;
			this.distance = distance;
			this.layerMask = layerMask;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void ScheduleRaycastBatch_Injected(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, int maxHits, out JobHandle ret);
	}
	[NativeHeader("Runtime/Jobs/ScriptBindings/JobsBindingsTypes.h")]
	[NativeHeader("Modules/Physics/BatchCommands/SpherecastCommand.h")]
	public struct SpherecastCommand
	{
		public QueryParameters queryParameters;

		public Vector3 origin { get; set; }

		public float radius { get; set; }

		public Vector3 direction { get; set; }

		public float distance { get; set; }

		public PhysicsScene physicsScene { get; set; }

		[Obsolete("Layer Mask is now a part of QueryParameters struct", false)]
		public int layerMask
		{
			get
			{
				return queryParameters.layerMask;
			}
			set
			{
				queryParameters.layerMask = value;
			}
		}

		public SpherecastCommand(Vector3 origin, float radius, Vector3 direction, QueryParameters queryParameters, float distance = float.MaxValue)
		{
			this.origin = origin;
			this.direction = direction;
			this.radius = radius;
			this.distance = distance;
			physicsScene = Physics.defaultPhysicsScene;
			this.queryParameters = queryParameters;
		}

		public SpherecastCommand(PhysicsScene physicsScene, Vector3 origin, float radius, Vector3 direction, QueryParameters queryParameters, float distance = float.MaxValue)
		{
			this.origin = origin;
			this.direction = direction;
			this.radius = radius;
			this.distance = distance;
			this.physicsScene = physicsScene;
			this.queryParameters = queryParameters;
		}

		public unsafe static JobHandle ScheduleBatch(NativeArray<SpherecastCommand> commands, NativeArray<RaycastHit> results, int minCommandsPerJob, int maxHits, JobHandle dependsOn = default(JobHandle))
		{
			if (maxHits < 1)
			{
				Debug.LogWarning("maxHits should be greater than 0.");
				return default(JobHandle);
			}
			if (results.Length < maxHits * commands.Length)
			{
				Debug.LogWarning("The supplied results buffer is too small, there should be at least maxHits space per each command in the batch.");
				return default(JobHandle);
			}
			BatchQueryJob<SpherecastCommand, RaycastHit> output = new BatchQueryJob<SpherecastCommand, RaycastHit>(commands, results);
			JobsUtility.JobScheduleParameters parameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf(ref output), BatchQueryJobStruct<BatchQueryJob<SpherecastCommand, RaycastHit>>.Initialize(), dependsOn, ScheduleMode.Batched);
			return ScheduleSpherecastBatch(ref parameters, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(commands), commands.Length, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(results), results.Length, minCommandsPerJob, maxHits);
		}

		public static JobHandle ScheduleBatch(NativeArray<SpherecastCommand> commands, NativeArray<RaycastHit> results, int minCommandsPerJob, JobHandle dependsOn = default(JobHandle))
		{
			return ScheduleBatch(commands, results, minCommandsPerJob, 1, dependsOn);
		}

		[FreeFunction("ScheduleSpherecastCommandBatch", ThrowsException = true)]
		private unsafe static JobHandle ScheduleSpherecastBatch(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, int maxHits)
		{
			ScheduleSpherecastBatch_Injected(ref parameters, commands, commandLen, result, resultLen, minCommandsPerJob, maxHits, out var ret);
			return ret;
		}

		[Obsolete("This struct signature is no longer supported. Use struct with a QueryParameters instead", false)]
		public SpherecastCommand(Vector3 origin, float radius, Vector3 direction, float distance = float.MaxValue, int layerMask = -5)
		{
			this.origin = origin;
			this.direction = direction;
			this.radius = radius;
			this.distance = distance;
			physicsScene = Physics.defaultPhysicsScene;
			queryParameters = QueryParameters.Default;
			this.layerMask = layerMask;
		}

		[Obsolete("This struct signature is no longer supported. Use struct with a QueryParameters instead", false)]
		public SpherecastCommand(PhysicsScene physicsScene, Vector3 origin, float radius, Vector3 direction, float distance = float.MaxValue, int layerMask = -5)
		{
			this.origin = origin;
			this.direction = direction;
			this.radius = radius;
			this.distance = distance;
			this.physicsScene = physicsScene;
			queryParameters = QueryParameters.Default;
			this.layerMask = layerMask;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void ScheduleSpherecastBatch_Injected(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, int maxHits, out JobHandle ret);
	}
	[NativeHeader("Modules/Physics/BatchCommands/CapsulecastCommand.h")]
	[NativeHeader("Runtime/Jobs/ScriptBindings/JobsBindingsTypes.h")]
	public struct CapsulecastCommand
	{
		public QueryParameters queryParameters;

		public Vector3 point1 { get; set; }

		public Vector3 point2 { get; set; }

		public float radius { get; set; }

		public Vector3 direction { get; set; }

		public float distance { get; set; }

		public PhysicsScene physicsScene { get; set; }

		[Obsolete("Layer Mask is now a part of QueryParameters struct", false)]
		public int layerMask
		{
			get
			{
				return queryParameters.layerMask;
			}
			set
			{
				queryParameters.layerMask = value;
			}
		}

		public CapsulecastCommand(Vector3 p1, Vector3 p2, float radius, Vector3 direction, QueryParameters queryParameters, float distance = float.MaxValue)
		{
			point1 = p1;
			point2 = p2;
			this.direction = direction;
			this.radius = radius;
			this.distance = distance;
			physicsScene = Physics.defaultPhysicsScene;
			this.queryParameters = queryParameters;
		}

		public CapsulecastCommand(PhysicsScene physicsScene, Vector3 p1, Vector3 p2, float radius, Vector3 direction, QueryParameters queryParameters, float distance = float.MaxValue)
		{
			point1 = p1;
			point2 = p2;
			this.direction = direction;
			this.radius = radius;
			this.distance = distance;
			this.physicsScene = physicsScene;
			this.queryParameters = queryParameters;
		}

		public unsafe static JobHandle ScheduleBatch(NativeArray<CapsulecastCommand> commands, NativeArray<RaycastHit> results, int minCommandsPerJob, int maxHits, JobHandle dependsOn = default(JobHandle))
		{
			if (maxHits < 1)
			{
				Debug.LogWarning("maxHits should be greater than 0.");
				return default(JobHandle);
			}
			if (results.Length < maxHits * commands.Length)
			{
				Debug.LogWarning("The supplied results buffer is too small, there should be at least maxHits space per each command in the batch.");
				return default(JobHandle);
			}
			BatchQueryJob<CapsulecastCommand, RaycastHit> output = new BatchQueryJob<CapsulecastCommand, RaycastHit>(commands, results);
			JobsUtility.JobScheduleParameters parameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf(ref output), BatchQueryJobStruct<BatchQueryJob<CapsulecastCommand, RaycastHit>>.Initialize(), dependsOn, ScheduleMode.Batched);
			return ScheduleCapsulecastBatch(ref parameters, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(commands), commands.Length, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(results), results.Length, minCommandsPerJob, maxHits);
		}

		public static JobHandle ScheduleBatch(NativeArray<CapsulecastCommand> commands, NativeArray<RaycastHit> results, int minCommandsPerJob, JobHandle dependsOn = default(JobHandle))
		{
			return ScheduleBatch(commands, results, minCommandsPerJob, 1, dependsOn);
		}

		[FreeFunction("ScheduleCapsulecastCommandBatch", ThrowsException = true)]
		private unsafe static JobHandle ScheduleCapsulecastBatch(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, int maxHits)
		{
			ScheduleCapsulecastBatch_Injected(ref parameters, commands, commandLen, result, resultLen, minCommandsPerJob, maxHits, out var ret);
			return ret;
		}

		[Obsolete("This struct signature is no longer supported. Use struct with a QueryParameters instead", false)]
		public CapsulecastCommand(Vector3 p1, Vector3 p2, float radius, Vector3 direction, float distance = float.MaxValue, int layerMask = -5)
		{
			point1 = p1;
			point2 = p2;
			this.direction = direction;
			this.radius = radius;
			this.distance = distance;
			physicsScene = Physics.defaultPhysicsScene;
			queryParameters = QueryParameters.Default;
			this.layerMask = layerMask;
		}

		[Obsolete("This struct signature is no longer supported. Use struct with a QueryParameters instead", false)]
		public CapsulecastCommand(PhysicsScene physicsScene, Vector3 p1, Vector3 p2, float radius, Vector3 direction, float distance = float.MaxValue, int layerMask = -5)
		{
			point1 = p1;
			point2 = p2;
			this.direction = direction;
			this.radius = radius;
			this.distance = distance;
			this.physicsScene = physicsScene;
			queryParameters = QueryParameters.Default;
			this.layerMask = layerMask;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void ScheduleCapsulecastBatch_Injected(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, int maxHits, out JobHandle ret);
	}
	[NativeHeader("Runtime/Jobs/ScriptBindings/JobsBindingsTypes.h")]
	[NativeHeader("Modules/Physics/BatchCommands/BoxcastCommand.h")]
	public struct BoxcastCommand
	{
		public QueryParameters queryParameters;

		public Vector3 center { get; set; }

		public Vector3 halfExtents { get; set; }

		public Quaternion orientation { get; set; }

		public Vector3 direction { get; set; }

		public float distance { get; set; }

		public PhysicsScene physicsScene { get; set; }

		[Obsolete("Layer Mask is now a part of QueryParameters struct", false)]
		public int layerMask
		{
			get
			{
				return queryParameters.layerMask;
			}
			set
			{
				queryParameters.layerMask = value;
			}
		}

		public BoxcastCommand(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, QueryParameters queryParameters, float distance = float.MaxValue)
		{
			this.center = center;
			this.halfExtents = halfExtents;
			this.orientation = orientation;
			this.direction = direction;
			this.distance = distance;
			physicsScene = Physics.defaultPhysicsScene;
			this.queryParameters = queryParameters;
		}

		public BoxcastCommand(PhysicsScene physicsScene, Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, QueryParameters queryParameters, float distance = float.MaxValue)
		{
			this.center = center;
			this.halfExtents = halfExtents;
			this.orientation = orientation;
			this.direction = direction;
			this.distance = distance;
			this.physicsScene = physicsScene;
			this.queryParameters = queryParameters;
		}

		public unsafe static JobHandle ScheduleBatch(NativeArray<BoxcastCommand> commands, NativeArray<RaycastHit> results, int minCommandsPerJob, int maxHits, JobHandle dependsOn = default(JobHandle))
		{
			if (maxHits < 1)
			{
				Debug.LogWarning("maxHits should be greater than 0.");
				return default(JobHandle);
			}
			if (results.Length < maxHits * commands.Length)
			{
				Debug.LogWarning("The supplied results buffer is too small, there should be at least maxHits space per each command in the batch.");
				return default(JobHandle);
			}
			BatchQueryJob<BoxcastCommand, RaycastHit> output = new BatchQueryJob<BoxcastCommand, RaycastHit>(commands, results);
			JobsUtility.JobScheduleParameters parameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf(ref output), BatchQueryJobStruct<BatchQueryJob<BoxcastCommand, RaycastHit>>.Initialize(), dependsOn, ScheduleMode.Batched);
			return ScheduleBoxcastBatch(ref parameters, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(commands), commands.Length, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(results), results.Length, minCommandsPerJob, maxHits);
		}

		public static JobHandle ScheduleBatch(NativeArray<BoxcastCommand> commands, NativeArray<RaycastHit> results, int minCommandsPerJob, JobHandle dependsOn = default(JobHandle))
		{
			return ScheduleBatch(commands, results, minCommandsPerJob, 1, dependsOn);
		}

		[FreeFunction("ScheduleBoxcastCommandBatch", ThrowsException = true)]
		private unsafe static JobHandle ScheduleBoxcastBatch(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, int maxHits)
		{
			ScheduleBoxcastBatch_Injected(ref parameters, commands, commandLen, result, resultLen, minCommandsPerJob, maxHits, out var ret);
			return ret;
		}

		[Obsolete("This struct signature is no longer supported. Use struct with a QueryParameters instead", false)]
		public BoxcastCommand(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, float distance = float.MaxValue, int layerMask = -5)
		{
			this.center = center;
			this.halfExtents = halfExtents;
			this.orientation = orientation;
			this.direction = direction;
			this.distance = distance;
			physicsScene = Physics.defaultPhysicsScene;
			queryParameters = QueryParameters.Default;
			this.layerMask = layerMask;
		}

		[Obsolete("This struct signature is no longer supported. Use struct with a QueryParameters instead", false)]
		public BoxcastCommand(PhysicsScene physicsScene, Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, float distance = float.MaxValue, int layerMask = -5)
		{
			this.center = center;
			this.halfExtents = halfExtents;
			this.orientation = orientation;
			this.direction = direction;
			this.distance = distance;
			this.physicsScene = physicsScene;
			queryParameters = QueryParameters.Default;
			this.layerMask = layerMask;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void ScheduleBoxcastBatch_Injected(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, int maxHits, out JobHandle ret);
	}
	[NativeHeader("Runtime/Jobs/ScriptBindings/JobsBindingsTypes.h")]
	[NativeHeader("Modules/Physics/BatchCommands/ClosestPointCommand.h")]
	public struct ClosestPointCommand
	{
		public Vector3 point { get; set; }

		public int colliderInstanceID { get; set; }

		public Vector3 position { get; set; }

		public Quaternion rotation { get; set; }

		public Vector3 scale { get; set; }

		public ClosestPointCommand(Vector3 point, int colliderInstanceID, Vector3 position, Quaternion rotation, Vector3 scale)
		{
			this.point = point;
			this.colliderInstanceID = colliderInstanceID;
			this.position = position;
			this.rotation = rotation;
			this.scale = scale;
		}

		public ClosestPointCommand(Vector3 point, Collider collider, Vector3 position, Quaternion rotation, Vector3 scale)
		{
			this.point = point;
			colliderInstanceID = collider.GetInstanceID();
			this.position = position;
			this.rotation = rotation;
			this.scale = scale;
		}

		public unsafe static JobHandle ScheduleBatch(NativeArray<ClosestPointCommand> commands, NativeArray<Vector3> results, int minCommandsPerJob, JobHandle dependsOn = default(JobHandle))
		{
			BatchQueryJob<ClosestPointCommand, Vector3> output = new BatchQueryJob<ClosestPointCommand, Vector3>(commands, results);
			JobsUtility.JobScheduleParameters parameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf(ref output), BatchQueryJobStruct<BatchQueryJob<ClosestPointCommand, Vector3>>.Initialize(), dependsOn, ScheduleMode.Batched);
			return ScheduleClosestPointCommandBatch(ref parameters, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(commands), commands.Length, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(results), results.Length, minCommandsPerJob);
		}

		[FreeFunction("ScheduleClosestPointCommandBatch", ThrowsException = true)]
		private unsafe static JobHandle ScheduleClosestPointCommandBatch(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob)
		{
			ScheduleClosestPointCommandBatch_Injected(ref parameters, commands, commandLen, result, resultLen, minCommandsPerJob, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void ScheduleClosestPointCommandBatch_Injected(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, out JobHandle ret);
	}
	[NativeHeader("Modules/Physics/BatchCommands/OverlapSphereCommand.h")]
	public struct OverlapSphereCommand
	{
		public QueryParameters queryParameters;

		public Vector3 point { get; set; }

		public float radius { get; set; }

		public PhysicsScene physicsScene { get; set; }

		public OverlapSphereCommand(Vector3 point, float radius, QueryParameters queryParameters)
		{
			this.point = point;
			this.radius = radius;
			this.queryParameters = queryParameters;
			physicsScene = Physics.defaultPhysicsScene;
		}

		public OverlapSphereCommand(PhysicsScene physicsScene, Vector3 point, float radius, QueryParameters queryParameters)
		{
			this.physicsScene = physicsScene;
			this.point = point;
			this.radius = radius;
			this.queryParameters = queryParameters;
		}

		public unsafe static JobHandle ScheduleBatch(NativeArray<OverlapSphereCommand> commands, NativeArray<ColliderHit> results, int minCommandsPerJob, int maxHits, JobHandle dependsOn = default(JobHandle))
		{
			if (maxHits < 1)
			{
				Debug.LogWarning("maxHits should be greater than 0.");
				return default(JobHandle);
			}
			if (results.Length < maxHits * commands.Length)
			{
				Debug.LogWarning("The supplied results buffer is too small, there should be at least maxHits space per each command in the batch.");
				return default(JobHandle);
			}
			BatchQueryJob<OverlapSphereCommand, ColliderHit> output = new BatchQueryJob<OverlapSphereCommand, ColliderHit>(commands, results);
			JobsUtility.JobScheduleParameters parameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf(ref output), BatchQueryJobStruct<BatchQueryJob<OverlapSphereCommand, ColliderHit>>.Initialize(), dependsOn, ScheduleMode.Batched);
			return ScheduleOverlapSphereBatch(ref parameters, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(commands), commands.Length, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(results), results.Length, minCommandsPerJob, maxHits);
		}

		[FreeFunction("ScheduleOverlapSphereCommandBatch", ThrowsException = true)]
		private unsafe static JobHandle ScheduleOverlapSphereBatch(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, int maxHits)
		{
			ScheduleOverlapSphereBatch_Injected(ref parameters, commands, commandLen, result, resultLen, minCommandsPerJob, maxHits, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void ScheduleOverlapSphereBatch_Injected(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, int maxHits, out JobHandle ret);
	}
	[NativeHeader("Modules/Physics/BatchCommands/OverlapBoxCommand.h")]
	public struct OverlapBoxCommand
	{
		public QueryParameters queryParameters;

		public Vector3 center { get; set; }

		public Vector3 halfExtents { get; set; }

		public Quaternion orientation { get; set; }

		public PhysicsScene physicsScene { get; set; }

		public OverlapBoxCommand(Vector3 center, Vector3 halfExtents, Quaternion orientation, QueryParameters queryParameters)
		{
			this.center = center;
			this.halfExtents = halfExtents;
			this.orientation = orientation;
			this.queryParameters = queryParameters;
			physicsScene = Physics.defaultPhysicsScene;
		}

		public OverlapBoxCommand(PhysicsScene physicsScene, Vector3 center, Vector3 halfExtents, Quaternion orientation, QueryParameters queryParameters)
		{
			this.physicsScene = physicsScene;
			this.center = center;
			this.halfExtents = halfExtents;
			this.orientation = orientation;
			this.queryParameters = queryParameters;
		}

		public unsafe static JobHandle ScheduleBatch(NativeArray<OverlapBoxCommand> commands, NativeArray<ColliderHit> results, int minCommandsPerJob, int maxHits, JobHandle dependsOn = default(JobHandle))
		{
			if (maxHits < 1)
			{
				Debug.LogWarning("maxHits should be greater than 0.");
				return default(JobHandle);
			}
			if (results.Length < maxHits * commands.Length)
			{
				Debug.LogWarning("The supplied results buffer is too small, there should be at least maxHits space per each command in the batch.");
				return default(JobHandle);
			}
			BatchQueryJob<OverlapBoxCommand, ColliderHit> output = new BatchQueryJob<OverlapBoxCommand, ColliderHit>(commands, results);
			JobsUtility.JobScheduleParameters parameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf(ref output), BatchQueryJobStruct<BatchQueryJob<OverlapBoxCommand, ColliderHit>>.Initialize(), dependsOn, ScheduleMode.Batched);
			return ScheduleOverlapBoxBatch(ref parameters, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(commands), commands.Length, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(results), results.Length, minCommandsPerJob, maxHits);
		}

		[FreeFunction("ScheduleOverlapBoxCommandBatch", ThrowsException = true)]
		private unsafe static JobHandle ScheduleOverlapBoxBatch(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, int maxHits)
		{
			ScheduleOverlapBoxBatch_Injected(ref parameters, commands, commandLen, result, resultLen, minCommandsPerJob, maxHits, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void ScheduleOverlapBoxBatch_Injected(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, int maxHits, out JobHandle ret);
	}
	[NativeHeader("Modules/Physics/BatchCommands/OverlapCapsuleCommand.h")]
	public struct OverlapCapsuleCommand
	{
		public QueryParameters queryParameters;

		public Vector3 point0 { get; set; }

		public Vector3 point1 { get; set; }

		public float radius { get; set; }

		public PhysicsScene physicsScene { get; set; }

		public OverlapCapsuleCommand(Vector3 point0, Vector3 point1, float radius, QueryParameters queryParameters)
		{
			this.point0 = point0;
			this.point1 = point1;
			this.radius = radius;
			this.queryParameters = queryParameters;
			physicsScene = Physics.defaultPhysicsScene;
		}

		public OverlapCapsuleCommand(PhysicsScene physicsScene, Vector3 point0, Vector3 point1, float radius, QueryParameters queryParameters)
		{
			this.physicsScene = physicsScene;
			this.point0 = point0;
			this.point1 = point1;
			this.radius = radius;
			this.queryParameters = queryParameters;
		}

		public unsafe static JobHandle ScheduleBatch(NativeArray<OverlapCapsuleCommand> commands, NativeArray<ColliderHit> results, int minCommandsPerJob, int maxHits, JobHandle dependsOn = default(JobHandle))
		{
			if (maxHits < 1)
			{
				Debug.LogWarning("maxHits should be greater than 0.");
				return default(JobHandle);
			}
			if (results.Length < maxHits * commands.Length)
			{
				Debug.LogWarning("The supplied results buffer is too small, there should be at least maxHits space per each command in the batch.");
				return default(JobHandle);
			}
			BatchQueryJob<OverlapCapsuleCommand, ColliderHit> output = new BatchQueryJob<OverlapCapsuleCommand, ColliderHit>(commands, results);
			JobsUtility.JobScheduleParameters parameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf(ref output), BatchQueryJobStruct<BatchQueryJob<OverlapCapsuleCommand, ColliderHit>>.Initialize(), dependsOn, ScheduleMode.Batched);
			return ScheduleOverlapCapsuleBatch(ref parameters, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(commands), commands.Length, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(results), results.Length, minCommandsPerJob, maxHits);
		}

		[FreeFunction("ScheduleOverlapCapsuleCommandBatch", ThrowsException = true)]
		private unsafe static JobHandle ScheduleOverlapCapsuleBatch(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, int maxHits)
		{
			ScheduleOverlapCapsuleBatch_Injected(ref parameters, commands, commandLen, result, resultLen, minCommandsPerJob, maxHits, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void ScheduleOverlapCapsuleBatch_Injected(ref JobsUtility.JobScheduleParameters parameters, void* commands, int commandLen, void* result, int resultLen, int minCommandsPerJob, int maxHits, out JobHandle ret);
	}
	[NativeHeader("Runtime/Interfaces/IRaycast.h")]
	[NativeHeader("PhysicsScriptingClasses.h")]
	[NativeHeader("Modules/Physics/RaycastHit.h")]
	[UsedByNativeCode]
	public struct RaycastHit
	{
		[NativeName("point")]
		internal Vector3 m_Point;

		[NativeName("normal")]
		internal Vector3 m_Normal;

		[NativeName("faceID")]
		internal uint m_FaceID;

		[NativeName("distance")]
		internal float m_Distance;

		[NativeName("uv")]
		internal Vector2 m_UV;

		[NativeName("collider")]
		internal int m_Collider;

		public Collider collider => Object.FindObjectFromInstanceID(m_Collider) as Collider;

		public int colliderInstanceID => m_Collider;

		public Vector3 point
		{
			get
			{
				return m_Point;
			}
			set
			{
				m_Point = value;
			}
		}

		public Vector3 normal
		{
			get
			{
				return m_Normal;
			}
			set
			{
				m_Normal = value;
			}
		}

		public Vector3 barycentricCoordinate
		{
			get
			{
				return new Vector3(1f - (m_UV.y + m_UV.x), m_UV.x, m_UV.y);
			}
			set
			{
				m_UV = value;
			}
		}

		public float distance
		{
			get
			{
				return m_Distance;
			}
			set
			{
				m_Distance = value;
			}
		}

		public int triangleIndex => (int)m_FaceID;

		public Vector2 textureCoord => CalculateRaycastTexCoord(m_Collider, m_UV, m_Point, m_FaceID, 0);

		public Vector2 textureCoord2 => CalculateRaycastTexCoord(m_Collider, m_UV, m_Point, m_FaceID, 1);

		public Transform transform
		{
			get
			{
				Rigidbody rigidbody = this.rigidbody;
				if (rigidbody != null)
				{
					return rigidbody.transform;
				}
				if (collider != null)
				{
					return collider.transform;
				}
				return null;
			}
		}

		public Rigidbody rigidbody => (collider != null) ? collider.attachedRigidbody : null;

		public ArticulationBody articulationBody => (collider != null) ? collider.attachedArticulationBody : null;

		public Vector2 lightmapCoord
		{
			get
			{
				Vector2 result = CalculateRaycastTexCoord(m_Collider, m_UV, m_Point, m_FaceID, 1);
				if (collider.GetComponent<Renderer>() != null)
				{
					Vector4 lightmapScaleOffset = collider.GetComponent<Renderer>().lightmapScaleOffset;
					result.x = result.x * lightmapScaleOffset.x + lightmapScaleOffset.z;
					result.y = result.y * lightmapScaleOffset.y + lightmapScaleOffset.w;
				}
				return result;
			}
		}

		[NativeMethod("CalculateRaycastTexCoord", true, true)]
		private static Vector2 CalculateRaycastTexCoord(int colliderInstanceID, Vector2 uv, Vector3 pos, uint face, int textcoord)
		{
			CalculateRaycastTexCoord_Injected(colliderInstanceID, ref uv, ref pos, face, textcoord, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CalculateRaycastTexCoord_Injected(int colliderInstanceID, [In] ref Vector2 uv, [In] ref Vector3 pos, uint face, int textcoord, out Vector2 ret);
	}
	public enum RigidbodyConstraints
	{
		None = 0,
		FreezePositionX = 2,
		FreezePositionY = 4,
		FreezePositionZ = 8,
		FreezeRotationX = 16,
		FreezeRotationY = 32,
		FreezeRotationZ = 64,
		FreezePosition = 14,
		FreezeRotation = 112,
		FreezeAll = 126
	}
	public enum RigidbodyInterpolation
	{
		None,
		Interpolate,
		Extrapolate
	}
	[NativeHeader("Modules/Physics/Rigidbody.h")]
	[RequireComponent(typeof(Transform))]
	public class Rigidbody : Component
	{
		public Vector3 linearVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_linearVelocity_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_linearVelocity_Injected(intPtr, ref value);
			}
		}

		public Vector3 angularVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_angularVelocity_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_angularVelocity_Injected(intPtr, ref value);
			}
		}

		public float linearDamping
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_linearDamping_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_linearDamping_Injected(intPtr, value);
			}
		}

		public float angularDamping
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_angularDamping_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_angularDamping_Injected(intPtr, value);
			}
		}

		public float mass
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_mass_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_mass_Injected(intPtr, value);
			}
		}

		public bool useGravity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_useGravity_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_useGravity_Injected(intPtr, value);
			}
		}

		public float maxDepenetrationVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_maxDepenetrationVelocity_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_maxDepenetrationVelocity_Injected(intPtr, value);
			}
		}

		public bool isKinematic
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isKinematic_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_isKinematic_Injected(intPtr, value);
			}
		}

		public bool freezeRotation
		{
			get
			{
				return constraints.HasFlag(RigidbodyConstraints.FreezeRotation);
			}
			set
			{
				if (value)
				{
					constraints |= RigidbodyConstraints.FreezeRotation;
				}
				else
				{
					constraints &= RigidbodyConstraints.FreezePosition;
				}
			}
		}

		public RigidbodyConstraints constraints
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_constraints_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_constraints_Injected(intPtr, value);
			}
		}

		public CollisionDetectionMode collisionDetectionMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_collisionDetectionMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_collisionDetectionMode_Injected(intPtr, value);
			}
		}

		public bool automaticCenterOfMass
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_automaticCenterOfMass_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_automaticCenterOfMass_Injected(intPtr, value);
			}
		}

		public Vector3 centerOfMass
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_centerOfMass_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_centerOfMass_Injected(intPtr, ref value);
			}
		}

		public Vector3 worldCenterOfMass
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_worldCenterOfMass_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public bool automaticInertiaTensor
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_automaticInertiaTensor_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_automaticInertiaTensor_Injected(intPtr, value);
			}
		}

		public Quaternion inertiaTensorRotation
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_inertiaTensorRotation_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_inertiaTensorRotation_Injected(intPtr, ref value);
			}
		}

		public Vector3 inertiaTensor
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_inertiaTensor_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_inertiaTensor_Injected(intPtr, ref value);
			}
		}

		internal Matrix4x4 worldInertiaTensorMatrix
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_worldInertiaTensorMatrix_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public bool detectCollisions
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_detectCollisions_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_detectCollisions_Injected(intPtr, value);
			}
		}

		public Vector3 position
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_position_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_position_Injected(intPtr, ref value);
			}
		}

		public Quaternion rotation
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_rotation_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rotation_Injected(intPtr, ref value);
			}
		}

		public RigidbodyInterpolation interpolation
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_interpolation_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_interpolation_Injected(intPtr, value);
			}
		}

		public int solverIterations
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_solverIterations_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_solverIterations_Injected(intPtr, value);
			}
		}

		public float sleepThreshold
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_sleepThreshold_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_sleepThreshold_Injected(intPtr, value);
			}
		}

		public float maxAngularVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_maxAngularVelocity_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_maxAngularVelocity_Injected(intPtr, value);
			}
		}

		public float maxLinearVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_maxLinearVelocity_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_maxLinearVelocity_Injected(intPtr, value);
			}
		}

		public int solverVelocityIterations
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_solverVelocityIterations_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_solverVelocityIterations_Injected(intPtr, value);
			}
		}

		public LayerMask excludeLayers
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_excludeLayers_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_excludeLayers_Injected(intPtr, ref value);
			}
		}

		public LayerMask includeLayers
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_includeLayers_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_includeLayers_Injected(intPtr, ref value);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use Rigidbody.linearDamping instead. (UnityUpgradable) -> linearDamping")]
		public float drag
		{
			get
			{
				return linearDamping;
			}
			set
			{
				linearDamping = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use Rigidbody.angularDamping instead. (UnityUpgradable) -> angularDamping")]
		public float angularDrag
		{
			get
			{
				return angularDamping;
			}
			set
			{
				angularDamping = value;
			}
		}

		[Obsolete("Please use Rigidbody.linearVelocity instead. (UnityUpgradable) -> linearVelocity")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3 velocity
		{
			get
			{
				return linearVelocity;
			}
			set
			{
				linearVelocity = value;
			}
		}

		public void MovePosition(Vector3 position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			MovePosition_Injected(intPtr, ref position);
		}

		public void MoveRotation(Quaternion rot)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			MoveRotation_Injected(intPtr, ref rot);
		}

		public void Move(Vector3 position, Quaternion rotation)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Move_Injected(intPtr, ref position, ref rotation);
		}

		public void Sleep()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Sleep_Injected(intPtr);
		}

		public bool IsSleeping()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IsSleeping_Injected(intPtr);
		}

		public void WakeUp()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			WakeUp_Injected(intPtr);
		}

		public void ResetCenterOfMass()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ResetCenterOfMass_Injected(intPtr);
		}

		public void ResetInertiaTensor()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ResetInertiaTensor_Injected(intPtr);
		}

		public Vector3 GetRelativePointVelocity(Vector3 relativePoint)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetRelativePointVelocity_Injected(intPtr, ref relativePoint, out var ret);
			return ret;
		}

		public Vector3 GetPointVelocity(Vector3 worldPoint)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetPointVelocity_Injected(intPtr, ref worldPoint, out var ret);
			return ret;
		}

		public void PublishTransform()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			PublishTransform_Injected(intPtr);
		}

		public Vector3 GetAccumulatedForce([UnityEngine.Internal.DefaultValue("Time.fixedDeltaTime")] float step)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetAccumulatedForce_Injected(intPtr, step, out var ret);
			return ret;
		}

		[ExcludeFromDocs]
		public Vector3 GetAccumulatedForce()
		{
			return GetAccumulatedForce(Time.fixedDeltaTime);
		}

		public Vector3 GetAccumulatedTorque([UnityEngine.Internal.DefaultValue("Time.fixedDeltaTime")] float step)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetAccumulatedTorque_Injected(intPtr, step, out var ret);
			return ret;
		}

		[ExcludeFromDocs]
		public Vector3 GetAccumulatedTorque()
		{
			return GetAccumulatedTorque(Time.fixedDeltaTime);
		}

		public void AddForce(Vector3 force, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddForce_Injected(intPtr, ref force, mode);
		}

		[ExcludeFromDocs]
		public void AddForce(Vector3 force)
		{
			AddForce(force, ForceMode.Force);
		}

		public void AddForce(float x, float y, float z, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode)
		{
			AddForce(new Vector3(x, y, z), mode);
		}

		[ExcludeFromDocs]
		public void AddForce(float x, float y, float z)
		{
			AddForce(new Vector3(x, y, z), ForceMode.Force);
		}

		public void AddRelativeForce(Vector3 force, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddRelativeForce_Injected(intPtr, ref force, mode);
		}

		[ExcludeFromDocs]
		public void AddRelativeForce(Vector3 force)
		{
			AddRelativeForce(force, ForceMode.Force);
		}

		public void AddRelativeForce(float x, float y, float z, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode)
		{
			AddRelativeForce(new Vector3(x, y, z), mode);
		}

		[ExcludeFromDocs]
		public void AddRelativeForce(float x, float y, float z)
		{
			AddRelativeForce(new Vector3(x, y, z), ForceMode.Force);
		}

		public void AddTorque(Vector3 torque, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddTorque_Injected(intPtr, ref torque, mode);
		}

		[ExcludeFromDocs]
		public void AddTorque(Vector3 torque)
		{
			AddTorque(torque, ForceMode.Force);
		}

		public void AddTorque(float x, float y, float z, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode)
		{
			AddTorque(new Vector3(x, y, z), mode);
		}

		[ExcludeFromDocs]
		public void AddTorque(float x, float y, float z)
		{
			AddTorque(new Vector3(x, y, z), ForceMode.Force);
		}

		public void AddRelativeTorque(Vector3 torque, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddRelativeTorque_Injected(intPtr, ref torque, mode);
		}

		[ExcludeFromDocs]
		public void AddRelativeTorque(Vector3 torque)
		{
			AddRelativeTorque(torque, ForceMode.Force);
		}

		public void AddRelativeTorque(float x, float y, float z, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode)
		{
			AddRelativeTorque(new Vector3(x, y, z), mode);
		}

		[ExcludeFromDocs]
		public void AddRelativeTorque(float x, float y, float z)
		{
			AddRelativeTorque(x, y, z, ForceMode.Force);
		}

		public void AddForceAtPosition(Vector3 force, Vector3 position, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddForceAtPosition_Injected(intPtr, ref force, ref position, mode);
		}

		[ExcludeFromDocs]
		public void AddForceAtPosition(Vector3 force, Vector3 position)
		{
			AddForceAtPosition(force, position, ForceMode.Force);
		}

		public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, [UnityEngine.Internal.DefaultValue("0.0f")] float upwardsModifier, [UnityEngine.Internal.DefaultValue("ForceMode.Force)")] ForceMode mode)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddExplosionForce_Injected(intPtr, explosionForce, ref explosionPosition, explosionRadius, upwardsModifier, mode);
		}

		[ExcludeFromDocs]
		public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier)
		{
			AddExplosionForce(explosionForce, explosionPosition, explosionRadius, upwardsModifier, ForceMode.Force);
		}

		[ExcludeFromDocs]
		public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius)
		{
			AddExplosionForce(explosionForce, explosionPosition, explosionRadius, 0f, ForceMode.Force);
		}

		[NativeName("ClosestPointOnBounds")]
		private void Internal_ClosestPointOnBounds(Vector3 point, ref Vector3 outPos, ref float distance)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Internal_ClosestPointOnBounds_Injected(intPtr, ref point, ref outPos, ref distance);
		}

		public Vector3 ClosestPointOnBounds(Vector3 position)
		{
			float distance = 0f;
			Vector3 outPos = Vector3.zero;
			Internal_ClosestPointOnBounds(position, ref outPos, ref distance);
			return outPos;
		}

		private RaycastHit SweepTest(Vector3 direction, float maxDistance, QueryTriggerInteraction queryTriggerInteraction, ref bool hasHit)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SweepTest_Injected(intPtr, ref direction, maxDistance, queryTriggerInteraction, ref hasHit, out var ret);
			return ret;
		}

		public bool SweepTest(Vector3 direction, out RaycastHit hitInfo, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			float magnitude = direction.magnitude;
			if (magnitude > float.Epsilon)
			{
				Vector3 direction2 = direction / magnitude;
				bool hasHit = false;
				hitInfo = SweepTest(direction2, maxDistance, queryTriggerInteraction, ref hasHit);
				return hasHit;
			}
			hitInfo = default(RaycastHit);
			return false;
		}

		[ExcludeFromDocs]
		public bool SweepTest(Vector3 direction, out RaycastHit hitInfo, float maxDistance)
		{
			return SweepTest(direction, out hitInfo, maxDistance, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public bool SweepTest(Vector3 direction, out RaycastHit hitInfo)
		{
			return SweepTest(direction, out hitInfo, float.PositiveInfinity, QueryTriggerInteraction.UseGlobal);
		}

		[NativeName("SweepTestAll")]
		private RaycastHit[] Internal_SweepTestAll(Vector3 direction, float maxDistance, QueryTriggerInteraction queryTriggerInteraction)
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			RaycastHit[] result;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				Internal_SweepTestAll_Injected(intPtr, ref direction, maxDistance, queryTriggerInteraction, out ret);
			}
			finally
			{
				RaycastHit[] array = default(RaycastHit[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}

		public RaycastHit[] SweepTestAll(Vector3 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance, [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
		{
			float magnitude = direction.magnitude;
			if (magnitude > float.Epsilon)
			{
				Vector3 direction2 = direction / magnitude;
				return Internal_SweepTestAll(direction2, maxDistance, queryTriggerInteraction);
			}
			return new RaycastHit[0];
		}

		[ExcludeFromDocs]
		public RaycastHit[] SweepTestAll(Vector3 direction, float maxDistance)
		{
			return SweepTestAll(direction, maxDistance, QueryTriggerInteraction.UseGlobal);
		}

		[ExcludeFromDocs]
		public RaycastHit[] SweepTestAll(Vector3 direction)
		{
			return SweepTestAll(direction, float.PositiveInfinity, QueryTriggerInteraction.UseGlobal);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use Rigidbody.mass instead. Setting density on a Rigidbody no longer has any effect.", false)]
		public void SetDensity(float density)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_linearVelocity_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_linearVelocity_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_angularVelocity_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_angularVelocity_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_linearDamping_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_linearDamping_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_angularDamping_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_angularDamping_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_mass_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_mass_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_useGravity_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_useGravity_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_maxDepenetrationVelocity_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_maxDepenetrationVelocity_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isKinematic_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_isKinematic_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern RigidbodyConstraints get_constraints_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_constraints_Injected(IntPtr _unity_self, RigidbodyConstraints value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern CollisionDetectionMode get_collisionDetectionMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_collisionDetectionMode_Injected(IntPtr _unity_self, CollisionDetectionMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_automaticCenterOfMass_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_automaticCenterOfMass_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_centerOfMass_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_centerOfMass_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_worldCenterOfMass_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_automaticInertiaTensor_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_automaticInertiaTensor_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_inertiaTensorRotation_Injected(IntPtr _unity_self, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_inertiaTensorRotation_Injected(IntPtr _unity_self, [In] ref Quaternion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_inertiaTensor_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_inertiaTensor_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_worldInertiaTensorMatrix_Injected(IntPtr _unity_self, out Matrix4x4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_detectCollisions_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_detectCollisions_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_position_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_position_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_rotation_Injected(IntPtr _unity_self, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rotation_Injected(IntPtr _unity_self, [In] ref Quaternion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern RigidbodyInterpolation get_interpolation_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_interpolation_Injected(IntPtr _unity_self, RigidbodyInterpolation value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_solverIterations_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_solverIterations_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_sleepThreshold_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_sleepThreshold_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_maxAngularVelocity_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_maxAngularVelocity_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_maxLinearVelocity_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_maxLinearVelocity_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void MovePosition_Injected(IntPtr _unity_self, [In] ref Vector3 position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void MoveRotation_Injected(IntPtr _unity_self, [In] ref Quaternion rot);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Move_Injected(IntPtr _unity_self, [In] ref Vector3 position, [In] ref Quaternion rotation);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Sleep_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsSleeping_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void WakeUp_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResetCenterOfMass_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResetInertiaTensor_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRelativePointVelocity_Injected(IntPtr _unity_self, [In] ref Vector3 relativePoint, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetPointVelocity_Injected(IntPtr _unity_self, [In] ref Vector3 worldPoint, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_solverVelocityIterations_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_solverVelocityIterations_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PublishTransform_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_excludeLayers_Injected(IntPtr _unity_self, out LayerMask ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_excludeLayers_Injected(IntPtr _unity_self, [In] ref LayerMask value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_includeLayers_Injected(IntPtr _unity_self, out LayerMask ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_includeLayers_Injected(IntPtr _unity_self, [In] ref LayerMask value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAccumulatedForce_Injected(IntPtr _unity_self, [UnityEngine.Internal.DefaultValue("Time.fixedDeltaTime")] float step, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAccumulatedTorque_Injected(IntPtr _unity_self, [UnityEngine.Internal.DefaultValue("Time.fixedDeltaTime")] float step, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddForce_Injected(IntPtr _unity_self, [In] ref Vector3 force, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddRelativeForce_Injected(IntPtr _unity_self, [In] ref Vector3 force, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddTorque_Injected(IntPtr _unity_self, [In] ref Vector3 torque, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddRelativeTorque_Injected(IntPtr _unity_self, [In] ref Vector3 torque, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddForceAtPosition_Injected(IntPtr _unity_self, [In] ref Vector3 force, [In] ref Vector3 position, [UnityEngine.Internal.DefaultValue("ForceMode.Force")] ForceMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddExplosionForce_Injected(IntPtr _unity_self, float explosionForce, [In] ref Vector3 explosionPosition, float explosionRadius, [UnityEngine.Internal.DefaultValue("0.0f")] float upwardsModifier, [UnityEngine.Internal.DefaultValue("ForceMode.Force)")] ForceMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_ClosestPointOnBounds_Injected(IntPtr _unity_self, [In] ref Vector3 point, ref Vector3 outPos, ref float distance);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SweepTest_Injected(IntPtr _unity_self, [In] ref Vector3 direction, float maxDistance, QueryTriggerInteraction queryTriggerInteraction, ref bool hasHit, out RaycastHit ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_SweepTestAll_Injected(IntPtr _unity_self, [In] ref Vector3 direction, float maxDistance, QueryTriggerInteraction queryTriggerInteraction, out BlittableArrayWrapper ret);
	}
	[RequireComponent(typeof(Transform))]
	[NativeHeader("Modules/Physics/SphereCollider.h")]
	public class SphereCollider : Collider
	{
		public Vector3 center
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_center_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_center_Injected(intPtr, ref value);
			}
		}

		public float radius
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_radius_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_radius_Injected(intPtr, value);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_center_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_center_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_radius_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_radius_Injected(IntPtr _unity_self, float value);
	}
	[RequireComponent(typeof(Rigidbody))]
	[NativeHeader("Modules/Physics/SpringJoint.h")]
	[NativeClass("Unity::SpringJoint")]
	public class SpringJoint : Joint
	{
		public float spring
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_spring_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_spring_Injected(intPtr, value);
			}
		}

		public float damper
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_damper_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_damper_Injected(intPtr, value);
			}
		}

		public float minDistance
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_minDistance_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_minDistance_Injected(intPtr, value);
			}
		}

		public float maxDistance
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_maxDistance_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_maxDistance_Injected(intPtr, value);
			}
		}

		public float tolerance
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_tolerance_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_tolerance_Injected(intPtr, value);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_spring_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_spring_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_damper_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_damper_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_minDistance_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_minDistance_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_maxDistance_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_maxDistance_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_tolerance_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_tolerance_Injected(IntPtr _unity_self, float value);
	}
}
namespace UnityEngine.LowLevelPhysics
{
	public struct ImmediateTransform
	{
		private Quaternion m_Rotation;

		private Vector3 m_Position;

		public Quaternion Rotation
		{
			get
			{
				return m_Rotation;
			}
			set
			{
				m_Rotation = value;
			}
		}

		public Vector3 Position
		{
			get
			{
				return m_Position;
			}
			set
			{
				m_Position = value;
			}
		}
	}
	public struct ImmediateContact
	{
		private Vector3 m_Normal;

		private float m_Separation;

		private Vector3 m_Point;

		private float m_MaxImpulse;

		private Vector3 m_TargetVel;

		private float m_StaticFriction;

		private byte m_MaterialFlags;

		private byte m_Pad;

		private ushort m_InternalUse;

		private uint m_InternalFaceIndex1;

		private float m_DynamicFriction;

		private float m_Restitution;

		public Vector3 Normal
		{
			get
			{
				return m_Normal;
			}
			set
			{
				m_Normal = value;
			}
		}

		public float Separation
		{
			get
			{
				return m_Separation;
			}
			set
			{
				m_Separation = value;
			}
		}

		public Vector3 Point
		{
			get
			{
				return m_Point;
			}
			set
			{
				m_Point = value;
			}
		}
	}
	[NativeHeader("Modules/Physics/ImmediatePhysics.h")]
	public static class ImmediatePhysics
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("Physics::Immediate::GenerateContacts", true)]
		private unsafe static extern int GenerateContacts_Native(void* geom1, void* geom2, void* xform1, void* xform2, int numPairs, void* contacts, int contactArrayLength, void* sizes, int sizesArrayLength, float contactDistance);

		public unsafe static int GenerateContacts(NativeArray<GeometryHolder>.ReadOnly geom1, NativeArray<GeometryHolder>.ReadOnly geom2, NativeArray<ImmediateTransform>.ReadOnly xform1, NativeArray<ImmediateTransform>.ReadOnly xform2, int pairCount, NativeArray<ImmediateContact> outContacts, NativeArray<int> outContactCounts, float contactDistance = 0.01f)
		{
			if (geom1.Length < pairCount || geom2.Length < pairCount || xform1.Length < pairCount || xform2.Length < pairCount)
			{
				throw new ArgumentException("Provided geometry or transform arrays are not large enough to fit the count of pairs.");
			}
			if (pairCount > outContactCounts.Length)
			{
				throw new ArgumentException("The output contact counts array is not big enough. The size of the array needs to match or exceed the amount of pairs.");
			}
			if (contactDistance <= 0f)
			{
				throw new ArgumentException("Contact distance must be positive and not equal to zero.");
			}
			return GenerateContacts_Native(geom1.GetUnsafeReadOnlyPtr(), geom2.GetUnsafeReadOnlyPtr(), xform1.GetUnsafeReadOnlyPtr(), xform2.GetUnsafeReadOnlyPtr(), pairCount, outContacts.GetUnsafePtr(), outContacts.Length, outContactCounts.GetUnsafePtr(), outContactCounts.Length, contactDistance);
		}
	}
	public interface IGeometry
	{
		GeometryType GeometryType { get; }
	}
	public struct BoxGeometry : IGeometry
	{
		private Vector3 m_HalfExtents;

		public Vector3 HalfExtents
		{
			get
			{
				return m_HalfExtents;
			}
			set
			{
				m_HalfExtents = value;
			}
		}

		public GeometryType GeometryType => GeometryType.Box;

		public BoxGeometry(Vector3 halfExtents)
		{
			m_HalfExtents = halfExtents;
		}
	}
	public struct SphereGeometry : IGeometry
	{
		private float m_Radius;

		public float Radius
		{
			get
			{
				return m_Radius;
			}
			set
			{
				m_Radius = value;
			}
		}

		public GeometryType GeometryType => GeometryType.Sphere;

		public SphereGeometry(float radius)
		{
			m_Radius = radius;
		}
	}
	public struct CapsuleGeometry : IGeometry
	{
		private float m_Radius;

		private float m_HalfLength;

		public float Radius
		{
			get
			{
				return m_Radius;
			}
			set
			{
				m_Radius = value;
			}
		}

		public float HalfLength
		{
			get
			{
				return m_HalfLength;
			}
			set
			{
				m_HalfLength = value;
			}
		}

		public GeometryType GeometryType => GeometryType.Capsule;

		public CapsuleGeometry(float radius, float halfLength)
		{
			m_Radius = radius;
			m_HalfLength = halfLength;
		}
	}
	public struct ConvexMeshGeometry : IGeometry
	{
		private Vector3 m_Scale;

		private Quaternion m_Rotation;

		private IntPtr m_ConvexMesh;

		private byte m_MeshFlags;

		private byte pad1;

		private short pad2;

		private uint pad3;

		public Vector3 Scale
		{
			get
			{
				return m_Scale;
			}
			set
			{
				m_Scale = value;
			}
		}

		public Quaternion ScaleAxisRotation
		{
			get
			{
				return m_Rotation;
			}
			set
			{
				m_Rotation = value;
			}
		}

		public GeometryType GeometryType => GeometryType.ConvexMesh;
	}
	public struct TriangleMeshGeometry : IGeometry
	{
		private Vector3 m_Scale;

		private Quaternion m_Rotation;

		private byte m_MeshFlags;

		private byte pad1;

		private short pad2;

		private IntPtr m_TriangleMesh;

		private uint pad3;

		public Vector3 Scale
		{
			get
			{
				return m_Scale;
			}
			set
			{
				m_Scale = value;
			}
		}

		public Quaternion ScaleAxisRotation
		{
			get
			{
				return m_Rotation;
			}
			set
			{
				m_Rotation = value;
			}
		}

		public GeometryType GeometryType => GeometryType.TriangleMesh;
	}
	public struct TerrainGeometry : IGeometry
	{
		private IntPtr m_TerrainData;

		private float m_HeightScale;

		private float m_RowScale;

		private float m_ColumnScale;

		private byte m_TerrainFlags;

		private byte pad1;

		private short pad2;

		private uint pad3;

		public GeometryType GeometryType => GeometryType.Terrain;
	}
	public enum GeometryType
	{
		Sphere = 0,
		Capsule = 2,
		Box = 3,
		ConvexMesh = 4,
		TriangleMesh = 5,
		Terrain = 6,
		Invalid = -1
	}
	public struct GeometryHolder
	{
		private int m_Type;

		private uint m_DataStart;

		private IntPtr m_FakePointer0;

		private IntPtr m_FakePointer1;

		private unsafe fixed uint m_Blob[6];

		public GeometryType Type => (GeometryType)m_Type;

		private unsafe void SetGeometry<T>(T geometry) where T : struct, IGeometry
		{
			m_Type = (int)geometry.GeometryType;
			UnsafeUtility.CopyStructureToPtr(ref geometry, UnsafeUtility.AddressOf(ref m_DataStart));
		}

		public unsafe T As<T>() where T : struct, IGeometry
		{
			T output = default(T);
			if (output.GeometryType != (GeometryType)m_Type)
			{
				throw new InvalidOperationException($"Unable to get geometry of type {output.GeometryType} from a geometry holder that stores {m_Type}.");
			}
			UnsafeUtility.CopyPtrToStructure<T>(UnsafeUtility.AddressOf(ref m_DataStart), out output);
			return output;
		}

		public static GeometryHolder Create<T>(T geometry) where T : struct, IGeometry
		{
			GeometryHolder result = new GeometryHolder
			{
				m_DataStart = 0u,
				m_Type = -1,
				m_FakePointer0 = new IntPtr(3735928559L),
				m_FakePointer1 = new IntPtr(3735928559L)
			};
			result.SetGeometry(geometry);
			return result;
		}
	}
}
