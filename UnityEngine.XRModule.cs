using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
[assembly: InternalsVisibleTo("UnityEngine.ScreenCaptureModule")]
[assembly: InternalsVisibleTo("UnityEngine.RuntimeInitializeOnLoadManagerInitializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.PropertiesModule")]
[assembly: InternalsVisibleTo("UnityEngine.Physics2DModule")]
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.ParticleSystemModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.ShaderVariantAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteShapeModule")]
[assembly: InternalsVisibleTo("UnityEngine.TilemapModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteMaskModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4Module")]
[assembly: InternalsVisibleTo("UnityEngine.SwitchModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.XRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VFXModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestWWWModule")]
[assembly: InternalsVisibleTo("UnityEngine.GameCenterModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestTextureModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityTestProtocolModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityCurlModule")]
[assembly: InternalsVisibleTo("UnityEngine.UmbraModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainPhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubsystemsModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubstanceModule")]
[assembly: InternalsVisibleTo("UnityEngine.StreamingModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.ImageConversionModule")]
[assembly: InternalsVisibleTo("UnityEngine.GIModule")]
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.012")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.013")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.014")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.015")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.016")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.017")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.018")]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.019")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.021")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.022")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.023")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.024")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.Subsystem.Registration")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.020")]
[assembly: InternalsVisibleTo("UnityEngine.SharedInternalsModule")]
[assembly: InternalsVisibleTo("UnityEngine.CoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.AIModule")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConnectModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.ARModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputModule")]
[assembly: InternalsVisibleTo("UnityEngine.JSONSerializeModule")]
[assembly: InternalsVisibleTo("UnityEngine.PhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.AMDModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.009")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.008")]
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
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Application")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.CommonUtils")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Tooling")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Deployment")]
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
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine.XR
{
	[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputTrackingFacade.h")]
	[RequiredByNativeCode]
	[StaticAccessor("XRInputTrackingFacade::Get()", StaticAccessorType.Dot)]
	[NativeConditional("ENABLE_VR")]
	public static class InputTracking
	{
		private enum TrackingStateEventType
		{
			NodeAdded,
			NodeRemoved,
			TrackingAcquired,
			TrackingLost
		}

		[NativeConditional("ENABLE_VR")]
		[Obsolete("This API is obsolete, and should no longer be used. Please use the TrackedPoseDriver in the Legacy Input Helpers package for controlling a camera in XR.")]
		public static extern bool disablePositionalTracking
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeName("GetPositionalTrackingDisabled")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeName("SetPositionalTrackingDisabled")]
			set;
		}

		public static event Action<XRNodeState> trackingAcquired;

		public static event Action<XRNodeState> trackingLost;

		public static event Action<XRNodeState> nodeAdded;

		public static event Action<XRNodeState> nodeRemoved;

		[RequiredByNativeCode]
		private static void InvokeTrackingEvent(TrackingStateEventType eventType, XRNode nodeType, long uniqueID, bool tracked)
		{
			Action<XRNodeState> action = null;
			XRNodeState obj = new XRNodeState
			{
				uniqueID = (ulong)uniqueID,
				nodeType = nodeType,
				tracked = tracked
			};
			((Action<XRNodeState>)(eventType switch
			{
				TrackingStateEventType.TrackingAcquired => InputTracking.trackingAcquired, 
				TrackingStateEventType.TrackingLost => InputTracking.trackingLost, 
				TrackingStateEventType.NodeAdded => InputTracking.nodeAdded, 
				TrackingStateEventType.NodeRemoved => InputTracking.nodeRemoved, 
				_ => throw new ArgumentException("TrackingEventHandler - Invalid EventType: " + eventType), 
			}))?.Invoke(obj);
		}

		[NativeConditional("ENABLE_VR", "Vector3f::zero")]
		[Obsolete("This API is obsolete, and should no longer be used. Please use InputDevice.TryGetFeatureValue with the CommonUsages.devicePosition usage instead.")]
		public static Vector3 GetLocalPosition(XRNode node)
		{
			GetLocalPosition_Injected(node, out var ret);
			return ret;
		}

		[NativeConditional("ENABLE_VR", "Quaternionf::identity()")]
		[Obsolete("This API is obsolete, and should no longer be used. Please use InputDevice.TryGetFeatureValue with the CommonUsages.deviceRotation usage instead.")]
		public static Quaternion GetLocalRotation(XRNode node)
		{
			GetLocalRotation_Injected(node, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[Obsolete("This API is obsolete, and should no longer be used. Please use XRInputSubsystem.TryRecenter() instead.")]
		[NativeConditional("ENABLE_VR")]
		public static extern void Recenter();

		[NativeConditional("ENABLE_VR")]
		[Obsolete("This API is obsolete, and should no longer be used. Please use InputDevice.name with the device associated with that tracking data instead.")]
		public static string GetNodeName(ulong uniqueId)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				GetNodeName_Injected(uniqueId, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		public static void GetNodeStates(List<XRNodeState> nodeStates)
		{
			if (nodeStates == null)
			{
				throw new ArgumentNullException("nodeStates");
			}
			nodeStates.Clear();
			GetNodeStates_Internal(nodeStates);
		}

		[NativeConditional("ENABLE_VR")]
		private unsafe static void GetNodeStates_Internal([NotNull] List<XRNodeState> nodeStates)
		{
			if (nodeStates == null)
			{
				ThrowHelper.ThrowArgumentNullException(nodeStates, "nodeStates");
			}
			List<XRNodeState> list = default(List<XRNodeState>);
			BlittableListWrapper nodeStates2 = default(BlittableListWrapper);
			try
			{
				list = nodeStates;
				fixed (XRNodeState[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					nodeStates2 = new BlittableListWrapper(arrayWrapper, list.Count);
					GetNodeStates_Internal_Injected(ref nodeStates2);
				}
			}
			finally
			{
				nodeStates2.Unmarshal(list);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputTracking.h")]
		[StaticAccessor("XRInputTracking::Get()", StaticAccessorType.Dot)]
		internal static extern ulong GetDeviceIdAtXRNode(XRNode node);

		[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputTracking.h")]
		[StaticAccessor("XRInputTracking::Get()", StaticAccessorType.Dot)]
		internal unsafe static void GetDeviceIdsAtXRNode_Internal(XRNode node, [NotNull] List<ulong> deviceIds)
		{
			if (deviceIds == null)
			{
				ThrowHelper.ThrowArgumentNullException(deviceIds, "deviceIds");
			}
			List<ulong> list = default(List<ulong>);
			BlittableListWrapper deviceIds2 = default(BlittableListWrapper);
			try
			{
				list = deviceIds;
				fixed (ulong[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					deviceIds2 = new BlittableListWrapper(arrayWrapper, list.Count);
					GetDeviceIdsAtXRNode_Internal_Injected(node, ref deviceIds2);
				}
			}
			finally
			{
				deviceIds2.Unmarshal(list);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalPosition_Injected(XRNode node, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalRotation_Injected(XRNode node, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetNodeName_Injected(ulong uniqueId, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetNodeStates_Internal_Injected(ref BlittableListWrapper nodeStates);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetDeviceIdsAtXRNode_Internal_Injected(XRNode node, ref BlittableListWrapper deviceIds);
	}
	public enum XRNode
	{
		LeftEye,
		RightEye,
		CenterEye,
		Head,
		LeftHand,
		RightHand,
		GameController,
		TrackingReference,
		HardwareTracker
	}
	[Flags]
	internal enum AvailableTrackingData
	{
		None = 0,
		PositionAvailable = 1,
		RotationAvailable = 2,
		VelocityAvailable = 4,
		AngularVelocityAvailable = 8,
		AccelerationAvailable = 0x10,
		AngularAccelerationAvailable = 0x20
	}
	[UsedByNativeCode]
	public struct XRNodeState
	{
		private XRNode m_Type;

		private AvailableTrackingData m_AvailableFields;

		private Vector3 m_Position;

		private Quaternion m_Rotation;

		private Vector3 m_Velocity;

		private Vector3 m_AngularVelocity;

		private Vector3 m_Acceleration;

		private Vector3 m_AngularAcceleration;

		private int m_Tracked;

		private ulong m_UniqueID;

		public ulong uniqueID
		{
			get
			{
				return m_UniqueID;
			}
			set
			{
				m_UniqueID = value;
			}
		}

		public XRNode nodeType
		{
			get
			{
				return m_Type;
			}
			set
			{
				m_Type = value;
			}
		}

		public bool tracked
		{
			get
			{
				return m_Tracked == 1;
			}
			set
			{
				m_Tracked = (value ? 1 : 0);
			}
		}

		public Vector3 position
		{
			set
			{
				m_Position = value;
				m_AvailableFields |= AvailableTrackingData.PositionAvailable;
			}
		}

		public Quaternion rotation
		{
			set
			{
				m_Rotation = value;
				m_AvailableFields |= AvailableTrackingData.RotationAvailable;
			}
		}

		public Vector3 velocity
		{
			set
			{
				m_Velocity = value;
				m_AvailableFields |= AvailableTrackingData.VelocityAvailable;
			}
		}

		public Vector3 angularVelocity
		{
			set
			{
				m_AngularVelocity = value;
				m_AvailableFields |= AvailableTrackingData.AngularVelocityAvailable;
			}
		}

		public Vector3 acceleration
		{
			set
			{
				m_Acceleration = value;
				m_AvailableFields |= AvailableTrackingData.AccelerationAvailable;
			}
		}

		public Vector3 angularAcceleration
		{
			set
			{
				m_AngularAcceleration = value;
				m_AvailableFields |= AvailableTrackingData.AngularAccelerationAvailable;
			}
		}

		public bool TryGetPosition(out Vector3 position)
		{
			return TryGet(m_Position, AvailableTrackingData.PositionAvailable, out position);
		}

		public bool TryGetRotation(out Quaternion rotation)
		{
			return TryGet(m_Rotation, AvailableTrackingData.RotationAvailable, out rotation);
		}

		public bool TryGetVelocity(out Vector3 velocity)
		{
			return TryGet(m_Velocity, AvailableTrackingData.VelocityAvailable, out velocity);
		}

		public bool TryGetAngularVelocity(out Vector3 angularVelocity)
		{
			return TryGet(m_AngularVelocity, AvailableTrackingData.AngularVelocityAvailable, out angularVelocity);
		}

		public bool TryGetAcceleration(out Vector3 acceleration)
		{
			return TryGet(m_Acceleration, AvailableTrackingData.AccelerationAvailable, out acceleration);
		}

		public bool TryGetAngularAcceleration(out Vector3 angularAcceleration)
		{
			return TryGet(m_AngularAcceleration, AvailableTrackingData.AngularAccelerationAvailable, out angularAcceleration);
		}

		private bool TryGet(Vector3 inValue, AvailableTrackingData availabilityFlag, out Vector3 outValue)
		{
			if ((m_AvailableFields & availabilityFlag) > AvailableTrackingData.None)
			{
				outValue = inValue;
				return true;
			}
			outValue = Vector3.zero;
			return false;
		}

		private bool TryGet(Quaternion inValue, AvailableTrackingData availabilityFlag, out Quaternion outValue)
		{
			if ((m_AvailableFields & availabilityFlag) > AvailableTrackingData.None)
			{
				outValue = inValue;
				return true;
			}
			outValue = Quaternion.identity;
			return false;
		}
	}
	[NativeConditional("ENABLE_VR")]
	public struct HapticCapabilities : IEquatable<HapticCapabilities>
	{
		private uint m_NumChannels;

		private bool m_SupportsImpulse;

		private bool m_SupportsBuffer;

		private uint m_BufferFrequencyHz;

		private uint m_BufferMaxSize;

		private uint m_BufferOptimalSize;

		public uint numChannels
		{
			get
			{
				return m_NumChannels;
			}
			internal set
			{
				m_NumChannels = value;
			}
		}

		public bool supportsImpulse
		{
			get
			{
				return m_SupportsImpulse;
			}
			internal set
			{
				m_SupportsImpulse = value;
			}
		}

		public bool supportsBuffer
		{
			get
			{
				return m_SupportsBuffer;
			}
			internal set
			{
				m_SupportsBuffer = value;
			}
		}

		public uint bufferFrequencyHz
		{
			get
			{
				return m_BufferFrequencyHz;
			}
			internal set
			{
				m_BufferFrequencyHz = value;
			}
		}

		public uint bufferMaxSize
		{
			get
			{
				return m_BufferMaxSize;
			}
			internal set
			{
				m_BufferMaxSize = value;
			}
		}

		public uint bufferOptimalSize
		{
			get
			{
				return m_BufferOptimalSize;
			}
			internal set
			{
				m_BufferOptimalSize = value;
			}
		}

		public override bool Equals(object obj)
		{
			if (!(obj is HapticCapabilities))
			{
				return false;
			}
			return Equals((HapticCapabilities)obj);
		}

		public bool Equals(HapticCapabilities other)
		{
			return numChannels == other.numChannels && supportsImpulse == other.supportsImpulse && supportsBuffer == other.supportsBuffer && bufferFrequencyHz == other.bufferFrequencyHz && bufferMaxSize == other.bufferMaxSize && bufferOptimalSize == other.bufferOptimalSize;
		}

		public override int GetHashCode()
		{
			return numChannels.GetHashCode() ^ (supportsImpulse.GetHashCode() << 1) ^ (supportsBuffer.GetHashCode() >> 1) ^ (bufferFrequencyHz.GetHashCode() << 2) ^ (bufferMaxSize.GetHashCode() >> 2) ^ (bufferOptimalSize.GetHashCode() << 3);
		}

		public static bool operator ==(HapticCapabilities a, HapticCapabilities b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(HapticCapabilities a, HapticCapabilities b)
		{
			return !(a == b);
		}
	}
	internal enum InputFeatureType : uint
	{
		Custom = 0u,
		Binary = 1u,
		DiscreteStates = 2u,
		Axis1D = 3u,
		Axis2D = 4u,
		Axis3D = 5u,
		Rotation = 6u,
		Hand = 7u,
		Bone = 8u,
		Eyes = 9u,
		kUnityXRInputFeatureTypeInvalid = uint.MaxValue
	}
	internal enum ConnectionChangeType : uint
	{
		Connected,
		Disconnected,
		ConfigChange
	}
	public enum InputDeviceRole : uint
	{
		Unknown,
		Generic,
		LeftHanded,
		RightHanded,
		GameController,
		TrackingReference,
		HardwareTracker,
		LegacyController
	}
	[Flags]
	public enum InputDeviceCharacteristics : uint
	{
		None = 0u,
		HeadMounted = 1u,
		Camera = 2u,
		HeldInHand = 4u,
		HandTracking = 8u,
		EyeTracking = 0x10u,
		TrackedDevice = 0x20u,
		Controller = 0x40u,
		TrackingReference = 0x80u,
		Left = 0x100u,
		Right = 0x200u,
		Simulated6DOF = 0x400u
	}
	[Flags]
	public enum InputTrackingState : uint
	{
		None = 0u,
		Position = 1u,
		Rotation = 2u,
		Velocity = 4u,
		AngularVelocity = 8u,
		Acceleration = 0x10u,
		AngularAcceleration = 0x20u,
		All = 0x3Fu
	}
	[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputDevices.h")]
	[RequiredByNativeCode]
	[NativeConditional("ENABLE_VR")]
	public struct InputFeatureUsage : IEquatable<InputFeatureUsage>
	{
		internal string m_Name;

		[NativeName("m_FeatureType")]
		internal InputFeatureType m_InternalType;

		public string name
		{
			get
			{
				return m_Name;
			}
			internal set
			{
				m_Name = value;
			}
		}

		internal InputFeatureType internalType
		{
			get
			{
				return m_InternalType;
			}
			set
			{
				m_InternalType = value;
			}
		}

		public Type type => m_InternalType switch
		{
			InputFeatureType.Custom => typeof(byte[]), 
			InputFeatureType.Binary => typeof(bool), 
			InputFeatureType.DiscreteStates => typeof(uint), 
			InputFeatureType.Axis1D => typeof(float), 
			InputFeatureType.Axis2D => typeof(Vector2), 
			InputFeatureType.Axis3D => typeof(Vector3), 
			InputFeatureType.Rotation => typeof(Quaternion), 
			InputFeatureType.Hand => typeof(Hand), 
			InputFeatureType.Bone => typeof(Bone), 
			InputFeatureType.Eyes => typeof(Eyes), 
			_ => throw new InvalidCastException("No valid managed type for unknown native type."), 
		};

		internal InputFeatureUsage(string name, InputFeatureType type)
		{
			m_Name = name;
			m_InternalType = type;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is InputFeatureUsage))
			{
				return false;
			}
			return Equals((InputFeatureUsage)obj);
		}

		public bool Equals(InputFeatureUsage other)
		{
			return name == other.name && internalType == other.internalType;
		}

		public override int GetHashCode()
		{
			return name.GetHashCode() ^ (internalType.GetHashCode() << 1);
		}

		public static bool operator ==(InputFeatureUsage a, InputFeatureUsage b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(InputFeatureUsage a, InputFeatureUsage b)
		{
			return !(a == b);
		}

		public InputFeatureUsage<T> As<T>()
		{
			if (type != typeof(T))
			{
				throw new ArgumentException("InputFeatureUsage type does not match out variable type.");
			}
			return new InputFeatureUsage<T>(name);
		}
	}
	public struct InputFeatureUsage<T> : IEquatable<InputFeatureUsage<T>>
	{
		public string name { get; set; }

		private Type usageType => typeof(T);

		public InputFeatureUsage(string usageName)
		{
			name = usageName;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is InputFeatureUsage<T>))
			{
				return false;
			}
			return Equals((InputFeatureUsage<T>)obj);
		}

		public bool Equals(InputFeatureUsage<T> other)
		{
			return name == other.name;
		}

		public override int GetHashCode()
		{
			return name.GetHashCode();
		}

		public static bool operator ==(InputFeatureUsage<T> a, InputFeatureUsage<T> b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(InputFeatureUsage<T> a, InputFeatureUsage<T> b)
		{
			return !(a == b);
		}

		public static explicit operator InputFeatureUsage(InputFeatureUsage<T> self)
		{
			InputFeatureType inputFeatureType = InputFeatureType.kUnityXRInputFeatureTypeInvalid;
			Type type = self.usageType;
			if (type == typeof(bool))
			{
				inputFeatureType = InputFeatureType.Binary;
			}
			else if (type == typeof(uint))
			{
				inputFeatureType = InputFeatureType.DiscreteStates;
			}
			else if (type == typeof(float))
			{
				inputFeatureType = InputFeatureType.Axis1D;
			}
			else if (type == typeof(Vector2))
			{
				inputFeatureType = InputFeatureType.Axis2D;
			}
			else if (type == typeof(Vector3))
			{
				inputFeatureType = InputFeatureType.Axis3D;
			}
			else if (type == typeof(Quaternion))
			{
				inputFeatureType = InputFeatureType.Rotation;
			}
			else if (type == typeof(Hand))
			{
				inputFeatureType = InputFeatureType.Hand;
			}
			else if (type == typeof(Bone))
			{
				inputFeatureType = InputFeatureType.Bone;
			}
			else if (type == typeof(Eyes))
			{
				inputFeatureType = InputFeatureType.Eyes;
			}
			else if (type == typeof(byte[]))
			{
				inputFeatureType = InputFeatureType.Custom;
			}
			else if (type.IsEnum)
			{
				inputFeatureType = InputFeatureType.DiscreteStates;
			}
			if (inputFeatureType != InputFeatureType.kUnityXRInputFeatureTypeInvalid)
			{
				return new InputFeatureUsage(self.name, inputFeatureType);
			}
			throw new InvalidCastException("No valid InputFeatureType for " + self.name + ".");
		}
	}
	public static class CommonUsages
	{
		public static InputFeatureUsage<bool> isTracked = new InputFeatureUsage<bool>("IsTracked");

		public static InputFeatureUsage<bool> primaryButton = new InputFeatureUsage<bool>("PrimaryButton");

		public static InputFeatureUsage<bool> primaryTouch = new InputFeatureUsage<bool>("PrimaryTouch");

		public static InputFeatureUsage<bool> secondaryButton = new InputFeatureUsage<bool>("SecondaryButton");

		public static InputFeatureUsage<bool> secondaryTouch = new InputFeatureUsage<bool>("SecondaryTouch");

		public static InputFeatureUsage<bool> gripButton = new InputFeatureUsage<bool>("GripButton");

		public static InputFeatureUsage<bool> triggerButton = new InputFeatureUsage<bool>("TriggerButton");

		public static InputFeatureUsage<bool> menuButton = new InputFeatureUsage<bool>("MenuButton");

		public static InputFeatureUsage<bool> primary2DAxisClick = new InputFeatureUsage<bool>("Primary2DAxisClick");

		public static InputFeatureUsage<bool> primary2DAxisTouch = new InputFeatureUsage<bool>("Primary2DAxisTouch");

		public static InputFeatureUsage<bool> secondary2DAxisClick = new InputFeatureUsage<bool>("Secondary2DAxisClick");

		public static InputFeatureUsage<bool> secondary2DAxisTouch = new InputFeatureUsage<bool>("Secondary2DAxisTouch");

		public static InputFeatureUsage<bool> userPresence = new InputFeatureUsage<bool>("UserPresence");

		public static InputFeatureUsage<InputTrackingState> trackingState = new InputFeatureUsage<InputTrackingState>("TrackingState");

		public static InputFeatureUsage<float> batteryLevel = new InputFeatureUsage<float>("BatteryLevel");

		public static InputFeatureUsage<float> trigger = new InputFeatureUsage<float>("Trigger");

		public static InputFeatureUsage<float> grip = new InputFeatureUsage<float>("Grip");

		public static InputFeatureUsage<Vector2> primary2DAxis = new InputFeatureUsage<Vector2>("Primary2DAxis");

		public static InputFeatureUsage<Vector2> secondary2DAxis = new InputFeatureUsage<Vector2>("Secondary2DAxis");

		public static InputFeatureUsage<Vector3> devicePosition = new InputFeatureUsage<Vector3>("DevicePosition");

		public static InputFeatureUsage<Vector3> leftEyePosition = new InputFeatureUsage<Vector3>("LeftEyePosition");

		public static InputFeatureUsage<Vector3> rightEyePosition = new InputFeatureUsage<Vector3>("RightEyePosition");

		public static InputFeatureUsage<Vector3> centerEyePosition = new InputFeatureUsage<Vector3>("CenterEyePosition");

		public static InputFeatureUsage<Vector3> colorCameraPosition = new InputFeatureUsage<Vector3>("CameraPosition");

		public static InputFeatureUsage<Vector3> deviceVelocity = new InputFeatureUsage<Vector3>("DeviceVelocity");

		public static InputFeatureUsage<Vector3> deviceAngularVelocity = new InputFeatureUsage<Vector3>("DeviceAngularVelocity");

		public static InputFeatureUsage<Vector3> leftEyeVelocity = new InputFeatureUsage<Vector3>("LeftEyeVelocity");

		public static InputFeatureUsage<Vector3> leftEyeAngularVelocity = new InputFeatureUsage<Vector3>("LeftEyeAngularVelocity");

		public static InputFeatureUsage<Vector3> rightEyeVelocity = new InputFeatureUsage<Vector3>("RightEyeVelocity");

		public static InputFeatureUsage<Vector3> rightEyeAngularVelocity = new InputFeatureUsage<Vector3>("RightEyeAngularVelocity");

		public static InputFeatureUsage<Vector3> centerEyeVelocity = new InputFeatureUsage<Vector3>("CenterEyeVelocity");

		public static InputFeatureUsage<Vector3> centerEyeAngularVelocity = new InputFeatureUsage<Vector3>("CenterEyeAngularVelocity");

		public static InputFeatureUsage<Vector3> colorCameraVelocity = new InputFeatureUsage<Vector3>("CameraVelocity");

		public static InputFeatureUsage<Vector3> colorCameraAngularVelocity = new InputFeatureUsage<Vector3>("CameraAngularVelocity");

		public static InputFeatureUsage<Vector3> deviceAcceleration = new InputFeatureUsage<Vector3>("DeviceAcceleration");

		public static InputFeatureUsage<Vector3> deviceAngularAcceleration = new InputFeatureUsage<Vector3>("DeviceAngularAcceleration");

		public static InputFeatureUsage<Vector3> leftEyeAcceleration = new InputFeatureUsage<Vector3>("LeftEyeAcceleration");

		public static InputFeatureUsage<Vector3> leftEyeAngularAcceleration = new InputFeatureUsage<Vector3>("LeftEyeAngularAcceleration");

		public static InputFeatureUsage<Vector3> rightEyeAcceleration = new InputFeatureUsage<Vector3>("RightEyeAcceleration");

		public static InputFeatureUsage<Vector3> rightEyeAngularAcceleration = new InputFeatureUsage<Vector3>("RightEyeAngularAcceleration");

		public static InputFeatureUsage<Vector3> centerEyeAcceleration = new InputFeatureUsage<Vector3>("CenterEyeAcceleration");

		public static InputFeatureUsage<Vector3> centerEyeAngularAcceleration = new InputFeatureUsage<Vector3>("CenterEyeAngularAcceleration");

		public static InputFeatureUsage<Vector3> colorCameraAcceleration = new InputFeatureUsage<Vector3>("CameraAcceleration");

		public static InputFeatureUsage<Vector3> colorCameraAngularAcceleration = new InputFeatureUsage<Vector3>("CameraAngularAcceleration");

		public static InputFeatureUsage<Quaternion> deviceRotation = new InputFeatureUsage<Quaternion>("DeviceRotation");

		public static InputFeatureUsage<Quaternion> leftEyeRotation = new InputFeatureUsage<Quaternion>("LeftEyeRotation");

		public static InputFeatureUsage<Quaternion> rightEyeRotation = new InputFeatureUsage<Quaternion>("RightEyeRotation");

		public static InputFeatureUsage<Quaternion> centerEyeRotation = new InputFeatureUsage<Quaternion>("CenterEyeRotation");

		public static InputFeatureUsage<Quaternion> colorCameraRotation = new InputFeatureUsage<Quaternion>("CameraRotation");

		public static InputFeatureUsage<Hand> handData = new InputFeatureUsage<Hand>("HandData");

		public static InputFeatureUsage<Eyes> eyesData = new InputFeatureUsage<Eyes>("EyesData");

		[Obsolete("CommonUsages.dPad is not used by any XR platform and will be removed.")]
		public static InputFeatureUsage<Vector2> dPad = new InputFeatureUsage<Vector2>("DPad");

		[Obsolete("CommonUsages.indexFinger is not used by any XR platform and will be removed.")]
		public static InputFeatureUsage<float> indexFinger = new InputFeatureUsage<float>("IndexFinger");

		[Obsolete("CommonUsages.MiddleFinger is not used by any XR platform and will be removed.")]
		public static InputFeatureUsage<float> middleFinger = new InputFeatureUsage<float>("MiddleFinger");

		[Obsolete("CommonUsages.RingFinger is not used by any XR platform and will be removed.")]
		public static InputFeatureUsage<float> ringFinger = new InputFeatureUsage<float>("RingFinger");

		[Obsolete("CommonUsages.PinkyFinger is not used by any XR platform and will be removed.")]
		public static InputFeatureUsage<float> pinkyFinger = new InputFeatureUsage<float>("PinkyFinger");

		[Obsolete("CommonUsages.thumbrest is Oculus only, and is being moved to their package. Please use OculusUsages.thumbrest. These will still function until removed.")]
		public static InputFeatureUsage<bool> thumbrest = new InputFeatureUsage<bool>("Thumbrest");

		[Obsolete("CommonUsages.indexTouch is Oculus only, and is being moved to their package.  Please use OculusUsages.indexTouch. These will still function until removed.")]
		public static InputFeatureUsage<float> indexTouch = new InputFeatureUsage<float>("IndexTouch");

		[Obsolete("CommonUsages.thumbTouch is Oculus only, and is being moved to their package.  Please use OculusUsages.thumbTouch. These will still function until removed.")]
		public static InputFeatureUsage<float> thumbTouch = new InputFeatureUsage<float>("ThumbTouch");
	}
	[UsedByNativeCode]
	[NativeConditional("ENABLE_VR")]
	public struct InputDevice : IEquatable<InputDevice>
	{
		private static List<XRInputSubsystem> s_InputSubsystemCache;

		private ulong m_DeviceId;

		private bool m_Initialized;

		private ulong deviceId => m_Initialized ? m_DeviceId : ulong.MaxValue;

		public XRInputSubsystem subsystem
		{
			get
			{
				if (s_InputSubsystemCache == null)
				{
					s_InputSubsystemCache = new List<XRInputSubsystem>();
				}
				if (m_Initialized)
				{
					uint num = (uint)(m_DeviceId >> 32);
					SubsystemManager.GetSubsystems(s_InputSubsystemCache);
					for (int i = 0; i < s_InputSubsystemCache.Count; i++)
					{
						if (num == s_InputSubsystemCache[i].GetIndex())
						{
							return s_InputSubsystemCache[i];
						}
					}
				}
				return null;
			}
		}

		public bool isValid => IsValidId() && InputDevices.IsDeviceValid(m_DeviceId);

		public string name => IsValidId() ? InputDevices.GetDeviceName(m_DeviceId) : null;

		[Obsolete("This API has been marked as deprecated and will be removed in future versions. Please use InputDevice.characteristics instead.")]
		public InputDeviceRole role => IsValidId() ? InputDevices.GetDeviceRole(m_DeviceId) : InputDeviceRole.Unknown;

		public string manufacturer => IsValidId() ? InputDevices.GetDeviceManufacturer(m_DeviceId) : null;

		public string serialNumber => IsValidId() ? InputDevices.GetDeviceSerialNumber(m_DeviceId) : null;

		public InputDeviceCharacteristics characteristics => IsValidId() ? InputDevices.GetDeviceCharacteristics(m_DeviceId) : InputDeviceCharacteristics.None;

		internal InputDevice(ulong deviceId)
		{
			m_DeviceId = deviceId;
			m_Initialized = true;
		}

		private bool IsValidId()
		{
			return deviceId != ulong.MaxValue;
		}

		public bool SendHapticImpulse(uint channel, float amplitude, float duration = 1f)
		{
			if (!IsValidId())
			{
				return false;
			}
			if (amplitude < 0f)
			{
				throw new ArgumentException("Amplitude of SendHapticImpulse cannot be negative.");
			}
			if (duration < 0f)
			{
				throw new ArgumentException("Duration of SendHapticImpulse cannot be negative.");
			}
			return InputDevices.SendHapticImpulse(m_DeviceId, channel, amplitude, duration);
		}

		public bool SendHapticBuffer(uint channel, byte[] buffer)
		{
			if (!IsValidId())
			{
				return false;
			}
			return InputDevices.SendHapticBuffer(m_DeviceId, channel, buffer);
		}

		public bool TryGetHapticCapabilities(out HapticCapabilities capabilities)
		{
			if (CheckValidAndSetDefault<HapticCapabilities>(out capabilities))
			{
				return InputDevices.TryGetHapticCapabilities(m_DeviceId, out capabilities);
			}
			return false;
		}

		public void StopHaptics()
		{
			if (IsValidId())
			{
				InputDevices.StopHaptics(m_DeviceId);
			}
		}

		public bool TryGetFeatureUsages(List<InputFeatureUsage> featureUsages)
		{
			if (IsValidId())
			{
				return InputDevices.TryGetFeatureUsages(m_DeviceId, featureUsages);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<bool> usage, out bool value)
		{
			if (CheckValidAndSetDefault<bool>(out value))
			{
				return InputDevices.TryGetFeatureValue_bool(m_DeviceId, usage.name, out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<uint> usage, out uint value)
		{
			if (CheckValidAndSetDefault<uint>(out value))
			{
				return InputDevices.TryGetFeatureValue_UInt32(m_DeviceId, usage.name, out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<float> usage, out float value)
		{
			if (CheckValidAndSetDefault<float>(out value))
			{
				return InputDevices.TryGetFeatureValue_float(m_DeviceId, usage.name, out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<Vector2> usage, out Vector2 value)
		{
			if (CheckValidAndSetDefault<Vector2>(out value))
			{
				return InputDevices.TryGetFeatureValue_Vector2f(m_DeviceId, usage.name, out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<Vector3> usage, out Vector3 value)
		{
			if (CheckValidAndSetDefault<Vector3>(out value))
			{
				return InputDevices.TryGetFeatureValue_Vector3f(m_DeviceId, usage.name, out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<Quaternion> usage, out Quaternion value)
		{
			if (CheckValidAndSetDefault<Quaternion>(out value))
			{
				return InputDevices.TryGetFeatureValue_Quaternionf(m_DeviceId, usage.name, out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<Hand> usage, out Hand value)
		{
			if (CheckValidAndSetDefault<Hand>(out value))
			{
				return InputDevices.TryGetFeatureValue_XRHand(m_DeviceId, usage.name, out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<Bone> usage, out Bone value)
		{
			if (CheckValidAndSetDefault<Bone>(out value))
			{
				return InputDevices.TryGetFeatureValue_XRBone(m_DeviceId, usage.name, out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<Eyes> usage, out Eyes value)
		{
			if (CheckValidAndSetDefault<Eyes>(out value))
			{
				return InputDevices.TryGetFeatureValue_XREyes(m_DeviceId, usage.name, out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<byte[]> usage, byte[] value)
		{
			if (IsValidId())
			{
				return InputDevices.TryGetFeatureValue_Custom(m_DeviceId, usage.name, value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<InputTrackingState> usage, out InputTrackingState value)
		{
			if (IsValidId())
			{
				uint value2 = 0u;
				if (InputDevices.TryGetFeatureValue_UInt32(m_DeviceId, usage.name, out value2))
				{
					value = (InputTrackingState)value2;
					return true;
				}
			}
			value = InputTrackingState.None;
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<bool> usage, DateTime time, out bool value)
		{
			if (CheckValidAndSetDefault<bool>(out value))
			{
				return InputDevices.TryGetFeatureValueAtTime_bool(m_DeviceId, usage.name, TimeConverter.LocalDateTimeToUnixTimeMilliseconds(time), out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<uint> usage, DateTime time, out uint value)
		{
			if (CheckValidAndSetDefault<uint>(out value))
			{
				return InputDevices.TryGetFeatureValueAtTime_UInt32(m_DeviceId, usage.name, TimeConverter.LocalDateTimeToUnixTimeMilliseconds(time), out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<float> usage, DateTime time, out float value)
		{
			if (CheckValidAndSetDefault<float>(out value))
			{
				return InputDevices.TryGetFeatureValueAtTime_float(m_DeviceId, usage.name, TimeConverter.LocalDateTimeToUnixTimeMilliseconds(time), out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<Vector2> usage, DateTime time, out Vector2 value)
		{
			if (CheckValidAndSetDefault<Vector2>(out value))
			{
				return InputDevices.TryGetFeatureValueAtTime_Vector2f(m_DeviceId, usage.name, TimeConverter.LocalDateTimeToUnixTimeMilliseconds(time), out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<Vector3> usage, DateTime time, out Vector3 value)
		{
			if (CheckValidAndSetDefault<Vector3>(out value))
			{
				return InputDevices.TryGetFeatureValueAtTime_Vector3f(m_DeviceId, usage.name, TimeConverter.LocalDateTimeToUnixTimeMilliseconds(time), out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<Quaternion> usage, DateTime time, out Quaternion value)
		{
			if (CheckValidAndSetDefault<Quaternion>(out value))
			{
				return InputDevices.TryGetFeatureValueAtTime_Quaternionf(m_DeviceId, usage.name, TimeConverter.LocalDateTimeToUnixTimeMilliseconds(time), out value);
			}
			return false;
		}

		public bool TryGetFeatureValue(InputFeatureUsage<InputTrackingState> usage, DateTime time, out InputTrackingState value)
		{
			if (IsValidId())
			{
				uint value2 = 0u;
				if (InputDevices.TryGetFeatureValueAtTime_UInt32(m_DeviceId, usage.name, TimeConverter.LocalDateTimeToUnixTimeMilliseconds(time), out value2))
				{
					value = (InputTrackingState)value2;
					return true;
				}
			}
			value = InputTrackingState.None;
			return false;
		}

		private bool CheckValidAndSetDefault<T>(out T value)
		{
			value = default(T);
			return IsValidId();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is InputDevice))
			{
				return false;
			}
			return Equals((InputDevice)obj);
		}

		public bool Equals(InputDevice other)
		{
			return deviceId == other.deviceId;
		}

		public override int GetHashCode()
		{
			return deviceId.GetHashCode();
		}

		public static bool operator ==(InputDevice a, InputDevice b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(InputDevice a, InputDevice b)
		{
			return !(a == b);
		}
	}
	internal static class TimeConverter
	{
		private static readonly DateTime s_Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public static DateTime now => DateTime.Now;

		public static long LocalDateTimeToUnixTimeMilliseconds(DateTime date)
		{
			return Convert.ToInt64((date.ToUniversalTime() - s_Epoch).TotalMilliseconds);
		}

		public static DateTime UnixTimeMillisecondsToLocalDateTime(long unixTimeInMilliseconds)
		{
			DateTime dateTime = s_Epoch;
			return dateTime.AddMilliseconds(unixTimeInMilliseconds).ToLocalTime();
		}
	}
	public enum HandFinger
	{
		Thumb,
		Index,
		Middle,
		Ring,
		Pinky
	}
	[StaticAccessor("XRInputDevices::Get()", StaticAccessorType.Dot)]
	[RequiredByNativeCode]
	[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputDevices.h")]
	[NativeHeader("XRScriptingClasses.h")]
	[NativeConditional("ENABLE_VR")]
	[NativeHeader("Modules/XR/XRPrefix.h")]
	public struct Hand : IEquatable<Hand>
	{
		private ulong m_DeviceId;

		private uint m_FeatureIndex;

		internal ulong deviceId => m_DeviceId;

		internal uint featureIndex => m_FeatureIndex;

		public bool TryGetRootBone(out Bone boneOut)
		{
			return Hand_TryGetRootBone(this, out boneOut);
		}

		private static bool Hand_TryGetRootBone(Hand hand, out Bone boneOut)
		{
			return Hand_TryGetRootBone_Injected(ref hand, out boneOut);
		}

		public bool TryGetFingerBones(HandFinger finger, List<Bone> bonesOut)
		{
			if (bonesOut == null)
			{
				throw new ArgumentNullException("bonesOut");
			}
			return Hand_TryGetFingerBonesAsList(this, finger, bonesOut);
		}

		private unsafe static bool Hand_TryGetFingerBonesAsList(Hand hand, HandFinger finger, [NotNull] List<Bone> bonesOut)
		{
			if (bonesOut == null)
			{
				ThrowHelper.ThrowArgumentNullException(bonesOut, "bonesOut");
			}
			List<Bone> list = default(List<Bone>);
			BlittableListWrapper bonesOut2 = default(BlittableListWrapper);
			try
			{
				list = bonesOut;
				fixed (Bone[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					bonesOut2 = new BlittableListWrapper(arrayWrapper, list.Count);
					return Hand_TryGetFingerBonesAsList_Injected(ref hand, finger, ref bonesOut2);
				}
			}
			finally
			{
				bonesOut2.Unmarshal(list);
			}
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Hand))
			{
				return false;
			}
			return Equals((Hand)obj);
		}

		public bool Equals(Hand other)
		{
			return deviceId == other.deviceId && featureIndex == other.featureIndex;
		}

		public override int GetHashCode()
		{
			return deviceId.GetHashCode() ^ (featureIndex.GetHashCode() << 1);
		}

		public static bool operator ==(Hand a, Hand b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(Hand a, Hand b)
		{
			return !(a == b);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Hand_TryGetRootBone_Injected([In] ref Hand hand, out Bone boneOut);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Hand_TryGetFingerBonesAsList_Injected([In] ref Hand hand, HandFinger finger, ref BlittableListWrapper bonesOut);
	}
	internal enum EyeSide
	{
		Left,
		Right
	}
	[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputDevices.h")]
	[RequiredByNativeCode]
	[NativeHeader("Modules/XR/XRPrefix.h")]
	[NativeHeader("XRScriptingClasses.h")]
	[StaticAccessor("XRInputDevices::Get()", StaticAccessorType.Dot)]
	[NativeConditional("ENABLE_VR")]
	public struct Eyes : IEquatable<Eyes>
	{
		private ulong m_DeviceId;

		private uint m_FeatureIndex;

		internal ulong deviceId => m_DeviceId;

		internal uint featureIndex => m_FeatureIndex;

		public bool TryGetLeftEyePosition(out Vector3 position)
		{
			return Eyes_TryGetEyePosition(this, EyeSide.Left, out position);
		}

		public bool TryGetRightEyePosition(out Vector3 position)
		{
			return Eyes_TryGetEyePosition(this, EyeSide.Right, out position);
		}

		public bool TryGetLeftEyeRotation(out Quaternion rotation)
		{
			return Eyes_TryGetEyeRotation(this, EyeSide.Left, out rotation);
		}

		public bool TryGetRightEyeRotation(out Quaternion rotation)
		{
			return Eyes_TryGetEyeRotation(this, EyeSide.Right, out rotation);
		}

		private static bool Eyes_TryGetEyePosition(Eyes eyes, EyeSide chirality, out Vector3 position)
		{
			return Eyes_TryGetEyePosition_Injected(ref eyes, chirality, out position);
		}

		private static bool Eyes_TryGetEyeRotation(Eyes eyes, EyeSide chirality, out Quaternion rotation)
		{
			return Eyes_TryGetEyeRotation_Injected(ref eyes, chirality, out rotation);
		}

		public bool TryGetFixationPoint(out Vector3 fixationPoint)
		{
			return Eyes_TryGetFixationPoint(this, out fixationPoint);
		}

		private static bool Eyes_TryGetFixationPoint(Eyes eyes, out Vector3 fixationPoint)
		{
			return Eyes_TryGetFixationPoint_Injected(ref eyes, out fixationPoint);
		}

		public bool TryGetLeftEyeOpenAmount(out float openAmount)
		{
			return Eyes_TryGetEyeOpenAmount(this, EyeSide.Left, out openAmount);
		}

		public bool TryGetRightEyeOpenAmount(out float openAmount)
		{
			return Eyes_TryGetEyeOpenAmount(this, EyeSide.Right, out openAmount);
		}

		private static bool Eyes_TryGetEyeOpenAmount(Eyes eyes, EyeSide chirality, out float openAmount)
		{
			return Eyes_TryGetEyeOpenAmount_Injected(ref eyes, chirality, out openAmount);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Eyes))
			{
				return false;
			}
			return Equals((Eyes)obj);
		}

		public bool Equals(Eyes other)
		{
			return deviceId == other.deviceId && featureIndex == other.featureIndex;
		}

		public override int GetHashCode()
		{
			return deviceId.GetHashCode() ^ (featureIndex.GetHashCode() << 1);
		}

		public static bool operator ==(Eyes a, Eyes b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(Eyes a, Eyes b)
		{
			return !(a == b);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Eyes_TryGetEyePosition_Injected([In] ref Eyes eyes, EyeSide chirality, out Vector3 position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Eyes_TryGetEyeRotation_Injected([In] ref Eyes eyes, EyeSide chirality, out Quaternion rotation);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Eyes_TryGetFixationPoint_Injected([In] ref Eyes eyes, out Vector3 fixationPoint);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Eyes_TryGetEyeOpenAmount_Injected([In] ref Eyes eyes, EyeSide chirality, out float openAmount);
	}
	[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputDevices.h")]
	[StaticAccessor("XRInputDevices::Get()", StaticAccessorType.Dot)]
	[NativeHeader("XRScriptingClasses.h")]
	[NativeHeader("Modules/XR/XRPrefix.h")]
	[NativeConditional("ENABLE_VR")]
	[RequiredByNativeCode]
	public struct Bone : IEquatable<Bone>
	{
		private ulong m_DeviceId;

		private uint m_FeatureIndex;

		internal ulong deviceId => m_DeviceId;

		internal uint featureIndex => m_FeatureIndex;

		public bool TryGetPosition(out Vector3 position)
		{
			return Bone_TryGetPosition(this, out position);
		}

		private static bool Bone_TryGetPosition(Bone bone, out Vector3 position)
		{
			return Bone_TryGetPosition_Injected(ref bone, out position);
		}

		public bool TryGetRotation(out Quaternion rotation)
		{
			return Bone_TryGetRotation(this, out rotation);
		}

		private static bool Bone_TryGetRotation(Bone bone, out Quaternion rotation)
		{
			return Bone_TryGetRotation_Injected(ref bone, out rotation);
		}

		public bool TryGetParentBone(out Bone parentBone)
		{
			return Bone_TryGetParentBone(this, out parentBone);
		}

		private static bool Bone_TryGetParentBone(Bone bone, out Bone parentBone)
		{
			return Bone_TryGetParentBone_Injected(ref bone, out parentBone);
		}

		public bool TryGetChildBones(List<Bone> childBones)
		{
			return Bone_TryGetChildBones(this, childBones);
		}

		private unsafe static bool Bone_TryGetChildBones(Bone bone, [NotNull] List<Bone> childBones)
		{
			if (childBones == null)
			{
				ThrowHelper.ThrowArgumentNullException(childBones, "childBones");
			}
			List<Bone> list = default(List<Bone>);
			BlittableListWrapper childBones2 = default(BlittableListWrapper);
			try
			{
				list = childBones;
				fixed (Bone[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					childBones2 = new BlittableListWrapper(arrayWrapper, list.Count);
					return Bone_TryGetChildBones_Injected(ref bone, ref childBones2);
				}
			}
			finally
			{
				childBones2.Unmarshal(list);
			}
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Bone))
			{
				return false;
			}
			return Equals((Bone)obj);
		}

		public bool Equals(Bone other)
		{
			return deviceId == other.deviceId && featureIndex == other.featureIndex;
		}

		public override int GetHashCode()
		{
			return deviceId.GetHashCode() ^ (featureIndex.GetHashCode() << 1);
		}

		public static bool operator ==(Bone a, Bone b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(Bone a, Bone b)
		{
			return !(a == b);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Bone_TryGetPosition_Injected([In] ref Bone bone, out Vector3 position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Bone_TryGetRotation_Injected([In] ref Bone bone, out Quaternion rotation);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Bone_TryGetParentBone_Injected([In] ref Bone bone, out Bone parentBone);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Bone_TryGetChildBones_Injected([In] ref Bone bone, ref BlittableListWrapper childBones);
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputDevices.h")]
	[StaticAccessor("XRInputDevices::Get()", StaticAccessorType.Dot)]
	[UsedByNativeCode]
	[NativeConditional("ENABLE_VR")]
	public class InputDevices
	{
		private static List<InputDevice> s_InputDeviceList;

		public static event Action<InputDevice> deviceConnected;

		public static event Action<InputDevice> deviceDisconnected;

		public static event Action<InputDevice> deviceConfigChanged;

		public static InputDevice GetDeviceAtXRNode(XRNode node)
		{
			ulong deviceIdAtXRNode = InputTracking.GetDeviceIdAtXRNode(node);
			return new InputDevice(deviceIdAtXRNode);
		}

		public static void GetDevicesAtXRNode(XRNode node, List<InputDevice> inputDevices)
		{
			if (inputDevices == null)
			{
				throw new ArgumentNullException("inputDevices");
			}
			List<ulong> list = new List<ulong>();
			InputTracking.GetDeviceIdsAtXRNode_Internal(node, list);
			inputDevices.Clear();
			foreach (ulong item2 in list)
			{
				InputDevice item = new InputDevice(item2);
				if (item.isValid)
				{
					inputDevices.Add(item);
				}
			}
		}

		public static void GetDevices(List<InputDevice> inputDevices)
		{
			if (inputDevices == null)
			{
				throw new ArgumentNullException("inputDevices");
			}
			inputDevices.Clear();
			GetDevices_Internal(inputDevices);
		}

		[Obsolete("This API has been marked as deprecated and will be removed in future versions. Please use InputDevices.GetDevicesWithCharacteristics instead.")]
		public static void GetDevicesWithRole(InputDeviceRole role, List<InputDevice> inputDevices)
		{
			if (inputDevices == null)
			{
				throw new ArgumentNullException("inputDevices");
			}
			if (s_InputDeviceList == null)
			{
				s_InputDeviceList = new List<InputDevice>();
			}
			GetDevices_Internal(s_InputDeviceList);
			inputDevices.Clear();
			foreach (InputDevice s_InputDevice in s_InputDeviceList)
			{
				if (s_InputDevice.role == role)
				{
					inputDevices.Add(s_InputDevice);
				}
			}
		}

		public static void GetDevicesWithCharacteristics(InputDeviceCharacteristics desiredCharacteristics, List<InputDevice> inputDevices)
		{
			if (inputDevices == null)
			{
				throw new ArgumentNullException("inputDevices");
			}
			if (s_InputDeviceList == null)
			{
				s_InputDeviceList = new List<InputDevice>();
			}
			GetDevices_Internal(s_InputDeviceList);
			inputDevices.Clear();
			foreach (InputDevice s_InputDevice in s_InputDeviceList)
			{
				if ((s_InputDevice.characteristics & desiredCharacteristics) == desiredCharacteristics)
				{
					inputDevices.Add(s_InputDevice);
				}
			}
		}

		[RequiredByNativeCode]
		private static void InvokeConnectionEvent(ulong deviceId, ConnectionChangeType change)
		{
			switch (change)
			{
			case ConnectionChangeType.Connected:
				if (InputDevices.deviceConnected != null)
				{
					InputDevices.deviceConnected(new InputDevice(deviceId));
				}
				break;
			case ConnectionChangeType.Disconnected:
				if (InputDevices.deviceDisconnected != null)
				{
					InputDevices.deviceDisconnected(new InputDevice(deviceId));
				}
				break;
			case ConnectionChangeType.ConfigChange:
				if (InputDevices.deviceConfigChanged != null)
				{
					InputDevices.deviceConfigChanged(new InputDevice(deviceId));
				}
				break;
			}
		}

		private unsafe static void GetDevices_Internal([NotNull] List<InputDevice> inputDevices)
		{
			if (inputDevices == null)
			{
				ThrowHelper.ThrowArgumentNullException(inputDevices, "inputDevices");
			}
			List<InputDevice> list = default(List<InputDevice>);
			BlittableListWrapper inputDevices2 = default(BlittableListWrapper);
			try
			{
				list = inputDevices;
				fixed (InputDevice[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					inputDevices2 = new BlittableListWrapper(arrayWrapper, list.Count);
					GetDevices_Internal_Injected(ref inputDevices2);
				}
			}
			finally
			{
				inputDevices2.Unmarshal(list);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool SendHapticImpulse(ulong deviceId, uint channel, float amplitude, float duration);

		internal unsafe static bool SendHapticBuffer(ulong deviceId, uint channel, [NotNull] byte[] buffer)
		{
			if (buffer == null)
			{
				ThrowHelper.ThrowArgumentNullException(buffer, "buffer");
			}
			Span<byte> span = new Span<byte>(buffer);
			bool result;
			fixed (byte* begin = span)
			{
				ManagedSpanWrapper buffer2 = new ManagedSpanWrapper(begin, span.Length);
				result = SendHapticBuffer_Injected(deviceId, channel, ref buffer2);
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool TryGetHapticCapabilities(ulong deviceId, out HapticCapabilities capabilities);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void StopHaptics(ulong deviceId);

		internal static bool TryGetFeatureUsages(ulong deviceId, [NotNull] List<InputFeatureUsage> featureUsages)
		{
			if (featureUsages == null)
			{
				ThrowHelper.ThrowArgumentNullException(featureUsages, "featureUsages");
			}
			return TryGetFeatureUsages_Injected(deviceId, featureUsages);
		}

		internal unsafe static bool TryGetFeatureValue_bool(ulong deviceId, string usage, out bool value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValue_bool_Injected(deviceId, ref managedSpanWrapper, out value);
					}
				}
				return TryGetFeatureValue_bool_Injected(deviceId, ref managedSpanWrapper, out value);
			}
			finally
			{
			}
		}

		internal unsafe static bool TryGetFeatureValue_UInt32(ulong deviceId, string usage, out uint value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValue_UInt32_Injected(deviceId, ref managedSpanWrapper, out value);
					}
				}
				return TryGetFeatureValue_UInt32_Injected(deviceId, ref managedSpanWrapper, out value);
			}
			finally
			{
			}
		}

		internal unsafe static bool TryGetFeatureValue_float(ulong deviceId, string usage, out float value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValue_float_Injected(deviceId, ref managedSpanWrapper, out value);
					}
				}
				return TryGetFeatureValue_float_Injected(deviceId, ref managedSpanWrapper, out value);
			}
			finally
			{
			}
		}

		internal unsafe static bool TryGetFeatureValue_Vector2f(ulong deviceId, string usage, out Vector2 value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValue_Vector2f_Injected(deviceId, ref managedSpanWrapper, out value);
					}
				}
				return TryGetFeatureValue_Vector2f_Injected(deviceId, ref managedSpanWrapper, out value);
			}
			finally
			{
			}
		}

		internal unsafe static bool TryGetFeatureValue_Vector3f(ulong deviceId, string usage, out Vector3 value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValue_Vector3f_Injected(deviceId, ref managedSpanWrapper, out value);
					}
				}
				return TryGetFeatureValue_Vector3f_Injected(deviceId, ref managedSpanWrapper, out value);
			}
			finally
			{
			}
		}

		internal unsafe static bool TryGetFeatureValue_Quaternionf(ulong deviceId, string usage, out Quaternion value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValue_Quaternionf_Injected(deviceId, ref managedSpanWrapper, out value);
					}
				}
				return TryGetFeatureValue_Quaternionf_Injected(deviceId, ref managedSpanWrapper, out value);
			}
			finally
			{
			}
		}

		internal unsafe static bool TryGetFeatureValue_Custom(ulong deviceId, string usage, [Out] byte[] value)
		{
			//The blocks IL_002a, IL_0030, IL_0036, IL_0038, IL_004c are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_004c are reachable both inside and outside the pinned region starting at IL_0031. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			BlittableArrayWrapper value2 = default(BlittableArrayWrapper);
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper usage2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						usage2 = ref managedSpanWrapper;
						if (value != null)
						{
							fixed (byte[] array = value)
							{
								if (array.Length != 0)
								{
									value2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
								}
								return TryGetFeatureValue_Custom_Injected(deviceId, ref usage2, out value2);
							}
						}
						return TryGetFeatureValue_Custom_Injected(deviceId, ref usage2, out value2);
					}
				}
				usage2 = ref managedSpanWrapper;
				if (value != null)
				{
					array = value;
					if (array.Length != 0)
					{
						value2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
				}
				return TryGetFeatureValue_Custom_Injected(deviceId, ref usage2, out value2);
			}
			finally
			{
				value2.Unmarshal(ref array);
			}
		}

		internal unsafe static bool TryGetFeatureValueAtTime_bool(ulong deviceId, string usage, long time, out bool value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValueAtTime_bool_Injected(deviceId, ref managedSpanWrapper, time, out value);
					}
				}
				return TryGetFeatureValueAtTime_bool_Injected(deviceId, ref managedSpanWrapper, time, out value);
			}
			finally
			{
			}
		}

		internal unsafe static bool TryGetFeatureValueAtTime_UInt32(ulong deviceId, string usage, long time, out uint value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValueAtTime_UInt32_Injected(deviceId, ref managedSpanWrapper, time, out value);
					}
				}
				return TryGetFeatureValueAtTime_UInt32_Injected(deviceId, ref managedSpanWrapper, time, out value);
			}
			finally
			{
			}
		}

		internal unsafe static bool TryGetFeatureValueAtTime_float(ulong deviceId, string usage, long time, out float value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValueAtTime_float_Injected(deviceId, ref managedSpanWrapper, time, out value);
					}
				}
				return TryGetFeatureValueAtTime_float_Injected(deviceId, ref managedSpanWrapper, time, out value);
			}
			finally
			{
			}
		}

		internal unsafe static bool TryGetFeatureValueAtTime_Vector2f(ulong deviceId, string usage, long time, out Vector2 value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValueAtTime_Vector2f_Injected(deviceId, ref managedSpanWrapper, time, out value);
					}
				}
				return TryGetFeatureValueAtTime_Vector2f_Injected(deviceId, ref managedSpanWrapper, time, out value);
			}
			finally
			{
			}
		}

		internal unsafe static bool TryGetFeatureValueAtTime_Vector3f(ulong deviceId, string usage, long time, out Vector3 value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValueAtTime_Vector3f_Injected(deviceId, ref managedSpanWrapper, time, out value);
					}
				}
				return TryGetFeatureValueAtTime_Vector3f_Injected(deviceId, ref managedSpanWrapper, time, out value);
			}
			finally
			{
			}
		}

		internal unsafe static bool TryGetFeatureValueAtTime_Quaternionf(ulong deviceId, string usage, long time, out Quaternion value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValueAtTime_Quaternionf_Injected(deviceId, ref managedSpanWrapper, time, out value);
					}
				}
				return TryGetFeatureValueAtTime_Quaternionf_Injected(deviceId, ref managedSpanWrapper, time, out value);
			}
			finally
			{
			}
		}

		internal unsafe static bool TryGetFeatureValue_XRHand(ulong deviceId, string usage, out Hand value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValue_XRHand_Injected(deviceId, ref managedSpanWrapper, out value);
					}
				}
				return TryGetFeatureValue_XRHand_Injected(deviceId, ref managedSpanWrapper, out value);
			}
			finally
			{
			}
		}

		internal unsafe static bool TryGetFeatureValue_XRBone(ulong deviceId, string usage, out Bone value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValue_XRBone_Injected(deviceId, ref managedSpanWrapper, out value);
					}
				}
				return TryGetFeatureValue_XRBone_Injected(deviceId, ref managedSpanWrapper, out value);
			}
			finally
			{
			}
		}

		internal unsafe static bool TryGetFeatureValue_XREyes(ulong deviceId, string usage, out Eyes value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(usage, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(usage);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetFeatureValue_XREyes_Injected(deviceId, ref managedSpanWrapper, out value);
					}
				}
				return TryGetFeatureValue_XREyes_Injected(deviceId, ref managedSpanWrapper, out value);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool IsDeviceValid(ulong deviceId);

		internal static string GetDeviceName(ulong deviceId)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				GetDeviceName_Injected(deviceId, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		internal static string GetDeviceManufacturer(ulong deviceId)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				GetDeviceManufacturer_Injected(deviceId, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		internal static string GetDeviceSerialNumber(ulong deviceId)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				GetDeviceSerialNumber_Injected(deviceId, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern InputDeviceCharacteristics GetDeviceCharacteristics(ulong deviceId);

		internal static InputDeviceRole GetDeviceRole(ulong deviceId)
		{
			InputDeviceCharacteristics deviceCharacteristics = GetDeviceCharacteristics(deviceId);
			if ((deviceCharacteristics & (InputDeviceCharacteristics.HeadMounted | InputDeviceCharacteristics.TrackedDevice)) == (InputDeviceCharacteristics.HeadMounted | InputDeviceCharacteristics.TrackedDevice))
			{
				return InputDeviceRole.Generic;
			}
			if ((deviceCharacteristics & (InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left)) == (InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left))
			{
				return InputDeviceRole.LeftHanded;
			}
			if ((deviceCharacteristics & (InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Right)) == (InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Right))
			{
				return InputDeviceRole.RightHanded;
			}
			if ((deviceCharacteristics & InputDeviceCharacteristics.Controller) == InputDeviceCharacteristics.Controller)
			{
				return InputDeviceRole.GameController;
			}
			if ((deviceCharacteristics & (InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.TrackingReference)) == (InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.TrackingReference))
			{
				return InputDeviceRole.TrackingReference;
			}
			if ((deviceCharacteristics & InputDeviceCharacteristics.TrackedDevice) == InputDeviceCharacteristics.TrackedDevice)
			{
				return InputDeviceRole.HardwareTracker;
			}
			return InputDeviceRole.Unknown;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetDevices_Internal_Injected(ref BlittableListWrapper inputDevices);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SendHapticBuffer_Injected(ulong deviceId, uint channel, ref ManagedSpanWrapper buffer);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureUsages_Injected(ulong deviceId, List<InputFeatureUsage> featureUsages);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValue_bool_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValue_UInt32_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out uint value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValue_float_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValue_Vector2f_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out Vector2 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValue_Vector3f_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValue_Quaternionf_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out Quaternion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValue_Custom_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out BlittableArrayWrapper value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValueAtTime_bool_Injected(ulong deviceId, ref ManagedSpanWrapper usage, long time, out bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValueAtTime_UInt32_Injected(ulong deviceId, ref ManagedSpanWrapper usage, long time, out uint value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValueAtTime_float_Injected(ulong deviceId, ref ManagedSpanWrapper usage, long time, out float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValueAtTime_Vector2f_Injected(ulong deviceId, ref ManagedSpanWrapper usage, long time, out Vector2 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValueAtTime_Vector3f_Injected(ulong deviceId, ref ManagedSpanWrapper usage, long time, out Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValueAtTime_Quaternionf_Injected(ulong deviceId, ref ManagedSpanWrapper usage, long time, out Quaternion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValue_XRHand_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out Hand value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValue_XRBone_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out Bone value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFeatureValue_XREyes_Injected(ulong deviceId, ref ManagedSpanWrapper usage, out Eyes value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetDeviceName_Injected(ulong deviceId, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetDeviceManufacturer_Injected(ulong deviceId, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetDeviceSerialNumber_Injected(ulong deviceId, out ManagedSpanWrapper ret);
	}
	[NativeConditional("ENABLE_XR")]
	[UsedByNativeCode]
	[NativeType(Header = "Modules/XR/Subsystems/Display/XRDisplaySubsystem.h")]
	[NativeHeader("Modules/XR/XRPrefix.h")]
	public class XRDisplaySubsystem : IntegratedSubsystem<XRDisplaySubsystemDescriptor>
	{
		[Flags]
		public enum FoveatedRenderingFlags
		{
			None = 0,
			GazeAllowed = 1
		}

		public enum LateLatchNode
		{
			Head,
			LeftHand,
			RightHand
		}

		[Flags]
		public enum TextureLayout
		{
			Texture2DArray = 1,
			SingleTexture2D = 2,
			SeparateTexture2Ds = 4
		}

		public enum ReprojectionMode
		{
			Unspecified,
			PositionAndOrientation,
			OrientationOnly,
			None
		}

		[NativeHeader("Modules/XR/Subsystems/Display/XRDisplaySubsystem.bindings.h")]
		public struct XRRenderParameter
		{
			public Matrix4x4 view;

			public Matrix4x4 projection;

			public Rect viewport;

			public Mesh occlusionMesh;

			public Mesh visibleMesh;

			public int textureArraySlice;

			public Matrix4x4 previousView;

			public bool isPreviousViewValid;
		}

		[NativeHeader("Runtime/Graphics/RenderTextureDesc.h")]
		[NativeHeader("Runtime/Graphics/CommandBuffer/RenderingCommandBuffer.h")]
		[NativeHeader("Modules/XR/Subsystems/Display/XRDisplaySubsystem.bindings.h")]
		public struct XRRenderPass
		{
			private IntPtr displaySubsystemInstance;

			public int renderPassIndex;

			public RenderTargetIdentifier renderTarget;

			public RenderTextureDescriptor renderTargetDesc;

			public int renderTargetScaledWidth;

			public int renderTargetScaledHeight;

			public bool hasMotionVectorPass;

			public RenderTargetIdentifier motionVectorRenderTarget;

			public RenderTextureDescriptor motionVectorRenderTargetDesc;

			public bool shouldFillOutDepth;

			public bool spaceWarpRightHandedNDC;

			public int cullingPassIndex;

			public IntPtr foveatedRenderingInfo;

			[NativeConditional("ENABLE_XR")]
			[NativeMethod(Name = "XRRenderPassScriptApi::GetRenderParameter", IsFreeFunction = true, HasExplicitThis = true, ThrowsException = true)]
			public void GetRenderParameter(Camera camera, int renderParameterIndex, out XRRenderParameter renderParameter)
			{
				GetRenderParameter_Injected(ref this, Object.MarshalledUnityObject.Marshal(camera), renderParameterIndex, out renderParameter);
			}

			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeConditional("ENABLE_XR")]
			[NativeMethod(Name = "XRRenderPassScriptApi::GetRenderParameterCount", IsFreeFunction = true, HasExplicitThis = true)]
			public extern int GetRenderParameterCount();

			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern void GetRenderParameter_Injected(ref XRRenderPass _unity_self, IntPtr camera, int renderParameterIndex, out XRRenderParameter renderParameter);
		}

		[NativeHeader("Runtime/Graphics/RenderTexture.h")]
		[NativeHeader("Modules/XR/Subsystems/Display/XRDisplaySubsystem.bindings.h")]
		public struct XRBlitParams
		{
			public RenderTexture srcTex;

			public int srcTexArraySlice;

			public Rect srcRect;

			public Rect destRect;

			public IntPtr foveatedRenderingInfo;

			public bool srcHdrEncoded;

			public ColorGamut srcHdrColorGamut;

			public int srcHdrMaxLuminance;
		}

		[NativeHeader("Modules/XR/Subsystems/Display/XRDisplaySubsystem.bindings.h")]
		public struct XRMirrorViewBlitDesc
		{
			private IntPtr displaySubsystemInstance;

			public bool nativeBlitAvailable;

			public bool nativeBlitInvalidStates;

			public int blitParamsCount;

			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeConditional("ENABLE_XR")]
			[NativeMethod(Name = "XRMirrorViewBlitDescScriptApi::GetBlitParameter", IsFreeFunction = true, HasExplicitThis = true)]
			public extern void GetBlitParameter(int blitParameterIndex, out XRBlitParams blitParameter);
		}

		internal new static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(XRDisplaySubsystem xrDisplaySubsystem)
			{
				return xrDisplaySubsystem.m_Ptr;
			}
		}

		private HDROutputSettings m_HDROutputSettings;

		[Obsolete("singlePassRenderingDisabled{get;set;} is deprecated. Use textureLayout and supportedTextureLayouts instead.", false)]
		public bool singlePassRenderingDisabled
		{
			get
			{
				return (textureLayout & TextureLayout.Texture2DArray) == 0;
			}
			set
			{
				if (value)
				{
					textureLayout = TextureLayout.SeparateTexture2Ds;
				}
				else if ((supportedTextureLayouts & TextureLayout.Texture2DArray) > (TextureLayout)0)
				{
					textureLayout = TextureLayout.Texture2DArray;
				}
			}
		}

		public bool displayOpaque
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_displayOpaque_Injected(intPtr);
			}
		}

		public bool contentProtectionEnabled
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_contentProtectionEnabled_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_contentProtectionEnabled_Injected(intPtr, value);
			}
		}

		public float scaleOfAllViewports
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_scaleOfAllViewports_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_scaleOfAllViewports_Injected(intPtr, value);
			}
		}

		public float scaleOfAllRenderTargets
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_scaleOfAllRenderTargets_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_scaleOfAllRenderTargets_Injected(intPtr, value);
			}
		}

		public float globalDynamicScale
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_globalDynamicScale_Injected(intPtr);
			}
		}

		public float zNear
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_zNear_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_zNear_Injected(intPtr, value);
			}
		}

		public float zFar
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_zFar_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_zFar_Injected(intPtr, value);
			}
		}

		public bool sRGB
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_sRGB_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_sRGB_Injected(intPtr, value);
			}
		}

		public float occlusionMaskScale
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_occlusionMaskScale_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_occlusionMaskScale_Injected(intPtr, value);
			}
		}

		public float foveatedRenderingLevel
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_foveatedRenderingLevel_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_foveatedRenderingLevel_Injected(intPtr, value);
			}
		}

		public FoveatedRenderingFlags foveatedRenderingFlags
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_foveatedRenderingFlags_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_foveatedRenderingFlags_Injected(intPtr, value);
			}
		}

		public TextureLayout textureLayout
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_textureLayout_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_textureLayout_Injected(intPtr, value);
			}
		}

		public TextureLayout supportedTextureLayouts
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_supportedTextureLayouts_Injected(intPtr);
			}
		}

		public ReprojectionMode reprojectionMode
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_reprojectionMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_reprojectionMode_Injected(intPtr, value);
			}
		}

		public bool disableLegacyRenderer
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_disableLegacyRenderer_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_disableLegacyRenderer_Injected(intPtr, value);
			}
		}

		public HDROutputSettings hdrOutputSettings
		{
			get
			{
				if (m_HDROutputSettings == null)
				{
					m_HDROutputSettings = new HDROutputSettings(-1);
				}
				return m_HDROutputSettings;
			}
		}

		public event Action<bool> displayFocusChanged;

		[RequiredByNativeCode]
		private void InvokeDisplayFocusChanged(bool focus)
		{
			if (this.displayFocusChanged != null)
			{
				this.displayFocusChanged(focus);
			}
		}

		public void MarkTransformLateLatched(Transform transform, LateLatchNode nodeType)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			MarkTransformLateLatched_Injected(intPtr, Object.MarshalledUnityObject.Marshal(transform), nodeType);
		}

		public int ScaledTextureWidth(RenderTexture renderTexture)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return ScaledTextureWidth_Injected(intPtr, Object.MarshalledUnityObject.Marshal(renderTexture));
		}

		public int ScaledTextureHeight(RenderTexture renderTexture)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return ScaledTextureHeight_Injected(intPtr, Object.MarshalledUnityObject.Marshal(renderTexture));
		}

		public void SetFocusPlane(Vector3 point, Vector3 normal, Vector3 velocity)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetFocusPlane_Injected(intPtr, ref point, ref normal, ref velocity);
		}

		public void SetMSAALevel(int level)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetMSAALevel_Injected(intPtr, level);
		}

		public int GetRenderPassCount()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetRenderPassCount_Injected(intPtr);
		}

		public void GetRenderPass(int renderPassIndex, out XRRenderPass renderPass)
		{
			if (!Internal_TryGetRenderPass(renderPassIndex, out renderPass))
			{
				throw new IndexOutOfRangeException("renderPassIndex");
			}
		}

		[NativeMethod("TryGetRenderPass")]
		private bool Internal_TryGetRenderPass(int renderPassIndex, out XRRenderPass renderPass)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Internal_TryGetRenderPass_Injected(intPtr, renderPassIndex, out renderPass);
		}

		public void EndRecordingIfLateLatched(Camera camera)
		{
			if (!Internal_TryEndRecordingIfLateLatched(camera) && camera == null)
			{
				throw new ArgumentNullException("camera");
			}
		}

		[NativeMethod("TryEndRecordingIfLateLatched")]
		private bool Internal_TryEndRecordingIfLateLatched(Camera camera)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Internal_TryEndRecordingIfLateLatched_Injected(intPtr, Object.MarshalledUnityObject.Marshal(camera));
		}

		public void BeginRecordingIfLateLatched(Camera camera)
		{
			if (!Internal_TryBeginRecordingIfLateLatched(camera) && camera == null)
			{
				throw new ArgumentNullException("camera");
			}
		}

		[NativeMethod("TryBeginRecordingIfLateLatched")]
		private bool Internal_TryBeginRecordingIfLateLatched(Camera camera)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Internal_TryBeginRecordingIfLateLatched_Injected(intPtr, Object.MarshalledUnityObject.Marshal(camera));
		}

		public void GetCullingParameters(Camera camera, int cullingPassIndex, out ScriptableCullingParameters scriptableCullingParameters)
		{
			if (!Internal_TryGetCullingParams(camera, cullingPassIndex, out scriptableCullingParameters))
			{
				if (camera == null)
				{
					throw new ArgumentNullException("camera");
				}
				throw new IndexOutOfRangeException("cullingPassIndex");
			}
		}

		[NativeMethod("TryGetCullingParams")]
		[NativeHeader("Runtime/Graphics/ScriptableRenderLoop/ScriptableCulling.h")]
		private bool Internal_TryGetCullingParams(Camera camera, int cullingPassIndex, out ScriptableCullingParameters scriptableCullingParameters)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Internal_TryGetCullingParams_Injected(intPtr, Object.MarshalledUnityObject.Marshal(camera), cullingPassIndex, out scriptableCullingParameters);
		}

		[NativeMethod("TryGetAppGPUTimeLastFrame")]
		public bool TryGetAppGPUTimeLastFrame(out float gpuTimeLastFrame)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return TryGetAppGPUTimeLastFrame_Injected(intPtr, out gpuTimeLastFrame);
		}

		[NativeMethod("TryGetCompositorGPUTimeLastFrame")]
		public bool TryGetCompositorGPUTimeLastFrame(out float gpuTimeLastFrameCompositor)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return TryGetCompositorGPUTimeLastFrame_Injected(intPtr, out gpuTimeLastFrameCompositor);
		}

		[NativeMethod("TryGetDroppedFrameCount")]
		public bool TryGetDroppedFrameCount(out int droppedFrameCount)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return TryGetDroppedFrameCount_Injected(intPtr, out droppedFrameCount);
		}

		[NativeMethod("TryGetFramePresentCount")]
		public bool TryGetFramePresentCount(out int framePresentCount)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return TryGetFramePresentCount_Injected(intPtr, out framePresentCount);
		}

		[NativeMethod("TryGetDisplayRefreshRate")]
		public bool TryGetDisplayRefreshRate(out float displayRefreshRate)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return TryGetDisplayRefreshRate_Injected(intPtr, out displayRefreshRate);
		}

		[NativeMethod("TryGetMotionToPhoton")]
		public bool TryGetMotionToPhoton(out float motionToPhoton)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return TryGetMotionToPhoton_Injected(intPtr, out motionToPhoton);
		}

		[NativeMethod(Name = "UnityXRRenderTextureIdToRenderTexture", IsThreadSafe = false)]
		[NativeConditional("ENABLE_XR")]
		public RenderTexture GetRenderTexture(uint unityXrRenderTextureId)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<RenderTexture>(GetRenderTexture_Injected(intPtr, unityXrRenderTextureId));
		}

		[NativeMethod(Name = "GetTextureForRenderPass", IsThreadSafe = false)]
		[NativeConditional("ENABLE_XR")]
		public RenderTexture GetRenderTextureForRenderPass(int renderPass)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<RenderTexture>(GetRenderTextureForRenderPass_Injected(intPtr, renderPass));
		}

		[NativeConditional("ENABLE_XR")]
		[NativeMethod(Name = "GetSharedDepthTextureForRenderPass", IsThreadSafe = false)]
		public RenderTexture GetSharedDepthTextureForRenderPass(int renderPass)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<RenderTexture>(GetSharedDepthTextureForRenderPass_Injected(intPtr, renderPass));
		}

		[NativeConditional("ENABLE_XR")]
		[NativeMethod(Name = "GetPreferredMirrorViewBlitMode", IsThreadSafe = false)]
		public int GetPreferredMirrorBlitMode()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetPreferredMirrorBlitMode_Injected(intPtr);
		}

		[NativeConditional("ENABLE_XR")]
		[NativeMethod(Name = "SetPreferredMirrorViewBlitMode", IsThreadSafe = false)]
		public void SetPreferredMirrorBlitMode(int blitMode)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetPreferredMirrorBlitMode_Injected(intPtr, blitMode);
		}

		[Obsolete("GetMirrorViewBlitDesc(RenderTexture, out XRMirrorViewBlitDesc) is deprecated. Use GetMirrorViewBlitDesc(RenderTexture, out XRMirrorViewBlitDesc, int) instead.", false)]
		public bool GetMirrorViewBlitDesc(RenderTexture mirrorRt, out XRMirrorViewBlitDesc outDesc)
		{
			return GetMirrorViewBlitDesc(mirrorRt, out outDesc, -1);
		}

		[NativeConditional("ENABLE_XR")]
		[NativeMethod(Name = "QueryMirrorViewBlitDesc", IsThreadSafe = false)]
		public bool GetMirrorViewBlitDesc(RenderTexture mirrorRt, out XRMirrorViewBlitDesc outDesc, int mode)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetMirrorViewBlitDesc_Injected(intPtr, Object.MarshalledUnityObject.Marshal(mirrorRt), out outDesc, mode);
		}

		[Obsolete("AddGraphicsThreadMirrorViewBlit(CommandBuffer, bool) is deprecated. Use AddGraphicsThreadMirrorViewBlit(CommandBuffer, bool, int) instead.", false)]
		public bool AddGraphicsThreadMirrorViewBlit(CommandBuffer cmd, bool allowGraphicsStateInvalidate)
		{
			return AddGraphicsThreadMirrorViewBlit(cmd, allowGraphicsStateInvalidate, -1);
		}

		[NativeHeader("Runtime/Graphics/CommandBuffer/RenderingCommandBuffer.h")]
		[NativeConditional("ENABLE_XR")]
		[NativeMethod(Name = "AddGraphicsThreadMirrorViewBlit", IsThreadSafe = false)]
		public bool AddGraphicsThreadMirrorViewBlit(CommandBuffer cmd, bool allowGraphicsStateInvalidate, int mode)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return AddGraphicsThreadMirrorViewBlit_Injected(intPtr, (cmd == null) ? ((IntPtr)0) : CommandBuffer.BindingsMarshaller.ConvertToNative(cmd), allowGraphicsStateInvalidate, mode);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_displayOpaque_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_contentProtectionEnabled_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_contentProtectionEnabled_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_scaleOfAllViewports_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_scaleOfAllViewports_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_scaleOfAllRenderTargets_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_scaleOfAllRenderTargets_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_globalDynamicScale_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_zNear_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_zNear_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_zFar_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_zFar_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_sRGB_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_sRGB_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_occlusionMaskScale_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_occlusionMaskScale_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_foveatedRenderingLevel_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_foveatedRenderingLevel_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern FoveatedRenderingFlags get_foveatedRenderingFlags_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_foveatedRenderingFlags_Injected(IntPtr _unity_self, FoveatedRenderingFlags value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void MarkTransformLateLatched_Injected(IntPtr _unity_self, IntPtr transform, LateLatchNode nodeType);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern TextureLayout get_textureLayout_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_textureLayout_Injected(IntPtr _unity_self, TextureLayout value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern TextureLayout get_supportedTextureLayouts_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int ScaledTextureWidth_Injected(IntPtr _unity_self, IntPtr renderTexture);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int ScaledTextureHeight_Injected(IntPtr _unity_self, IntPtr renderTexture);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ReprojectionMode get_reprojectionMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_reprojectionMode_Injected(IntPtr _unity_self, ReprojectionMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFocusPlane_Injected(IntPtr _unity_self, [In] ref Vector3 point, [In] ref Vector3 normal, [In] ref Vector3 velocity);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetMSAALevel_Injected(IntPtr _unity_self, int level);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_disableLegacyRenderer_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_disableLegacyRenderer_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetRenderPassCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Internal_TryGetRenderPass_Injected(IntPtr _unity_self, int renderPassIndex, out XRRenderPass renderPass);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Internal_TryEndRecordingIfLateLatched_Injected(IntPtr _unity_self, IntPtr camera);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Internal_TryBeginRecordingIfLateLatched_Injected(IntPtr _unity_self, IntPtr camera);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Internal_TryGetCullingParams_Injected(IntPtr _unity_self, IntPtr camera, int cullingPassIndex, out ScriptableCullingParameters scriptableCullingParameters);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetAppGPUTimeLastFrame_Injected(IntPtr _unity_self, out float gpuTimeLastFrame);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetCompositorGPUTimeLastFrame_Injected(IntPtr _unity_self, out float gpuTimeLastFrameCompositor);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetDroppedFrameCount_Injected(IntPtr _unity_self, out int droppedFrameCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetFramePresentCount_Injected(IntPtr _unity_self, out int framePresentCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetDisplayRefreshRate_Injected(IntPtr _unity_self, out float displayRefreshRate);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetMotionToPhoton_Injected(IntPtr _unity_self, out float motionToPhoton);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetRenderTexture_Injected(IntPtr _unity_self, uint unityXrRenderTextureId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetRenderTextureForRenderPass_Injected(IntPtr _unity_self, int renderPass);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetSharedDepthTextureForRenderPass_Injected(IntPtr _unity_self, int renderPass);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetPreferredMirrorBlitMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetPreferredMirrorBlitMode_Injected(IntPtr _unity_self, int blitMode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetMirrorViewBlitDesc_Injected(IntPtr _unity_self, IntPtr mirrorRt, out XRMirrorViewBlitDesc outDesc, int mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool AddGraphicsThreadMirrorViewBlit_Injected(IntPtr _unity_self, IntPtr cmd, bool allowGraphicsStateInvalidate, int mode);
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct XRMirrorViewBlitMode
	{
		public const int Default = 0;

		public const int LeftEye = -1;

		public const int RightEye = -2;

		public const int SideBySide = -3;

		public const int SideBySideOcclusionMesh = -4;

		public const int Distort = -5;

		public const int None = -6;

		public const int MotionVectors = -7;
	}
	[NativeHeader("Modules/XR/XRPrefix.h")]
	[NativeType(Header = "Modules/XR/Subsystems/Display/XRDisplaySubsystemDescriptor.h")]
	public struct XRMirrorViewBlitModeDesc
	{
		public int blitMode;

		public string blitModeDesc;
	}
	[NativeType(Header = "Modules/XR/Subsystems/Display/XRDisplaySubsystemDescriptor.h")]
	[UsedByNativeCode]
	public class XRDisplaySubsystemDescriptor : IntegratedSubsystemDescriptor<XRDisplaySubsystem>
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(XRDisplaySubsystemDescriptor descriptor)
			{
				return descriptor.m_Ptr;
			}
		}

		[NativeConditional("ENABLE_XR")]
		public bool disablesLegacyVr
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_disablesLegacyVr_Injected(intPtr);
			}
		}

		[NativeConditional("ENABLE_XR")]
		public bool enableBackBufferMSAA
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_enableBackBufferMSAA_Injected(intPtr);
			}
		}

		[NativeMethod("TryGetAvailableMirrorModeCount")]
		[NativeConditional("ENABLE_XR")]
		public int GetAvailableMirrorBlitModeCount()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAvailableMirrorBlitModeCount_Injected(intPtr);
		}

		[NativeMethod("TryGetMirrorModeByIndex")]
		[NativeConditional("ENABLE_XR")]
		public void GetMirrorBlitModeByIndex(int index, out XRMirrorViewBlitModeDesc mode)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetMirrorBlitModeByIndex_Injected(intPtr, index, out mode);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_disablesLegacyVr_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_enableBackBufferMSAA_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetAvailableMirrorBlitModeCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetMirrorBlitModeByIndex_Injected(IntPtr _unity_self, int index, out XRMirrorViewBlitModeDesc mode);
	}
	public enum TrackingOriginModeFlags
	{
		Unknown = 0,
		Device = 1,
		Floor = 2,
		TrackingReference = 4,
		Unbounded = 8
	}
	[NativeType(Header = "Modules/XR/Subsystems/Input/XRInputSubsystem.h")]
	[UsedByNativeCode]
	[NativeConditional("ENABLE_XR")]
	public class XRInputSubsystem : IntegratedSubsystem<XRInputSubsystemDescriptor>
	{
		internal new static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(XRInputSubsystem xrInputSubsystem)
			{
				return xrInputSubsystem.m_Ptr;
			}
		}

		private List<ulong> m_DeviceIdsCache;

		public event Action<XRInputSubsystem> trackingOriginUpdated;

		public event Action<XRInputSubsystem> boundaryChanged;

		internal uint GetIndex()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetIndex_Injected(intPtr);
		}

		public bool TryRecenter()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return TryRecenter_Injected(intPtr);
		}

		public bool TryGetInputDevices(List<InputDevice> devices)
		{
			if (devices == null)
			{
				throw new ArgumentNullException("devices");
			}
			devices.Clear();
			if (m_DeviceIdsCache == null)
			{
				m_DeviceIdsCache = new List<ulong>();
			}
			m_DeviceIdsCache.Clear();
			TryGetDeviceIds_AsList(m_DeviceIdsCache);
			for (int i = 0; i < m_DeviceIdsCache.Count; i++)
			{
				devices.Add(new InputDevice(m_DeviceIdsCache[i]));
			}
			return true;
		}

		public bool TrySetTrackingOriginMode(TrackingOriginModeFlags origin)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return TrySetTrackingOriginMode_Injected(intPtr, origin);
		}

		public TrackingOriginModeFlags GetTrackingOriginMode()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetTrackingOriginMode_Injected(intPtr);
		}

		public TrackingOriginModeFlags GetSupportedTrackingOriginModes()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetSupportedTrackingOriginModes_Injected(intPtr);
		}

		public bool TryGetBoundaryPoints(List<Vector3> boundaryPoints)
		{
			if (boundaryPoints == null)
			{
				throw new ArgumentNullException("boundaryPoints");
			}
			return TryGetBoundaryPoints_AsList(boundaryPoints);
		}

		private unsafe bool TryGetBoundaryPoints_AsList(List<Vector3> boundaryPoints)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<Vector3> list = default(List<Vector3>);
			BlittableListWrapper boundaryPoints2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = boundaryPoints;
				if (list != null)
				{
					fixed (Vector3[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						boundaryPoints2 = new BlittableListWrapper(arrayWrapper, list.Count);
						return TryGetBoundaryPoints_AsList_Injected(intPtr, ref boundaryPoints2);
					}
				}
				return TryGetBoundaryPoints_AsList_Injected(intPtr, ref boundaryPoints2);
			}
			finally
			{
				boundaryPoints2.Unmarshal(list);
			}
		}

		[RequiredByNativeCode(GenerateProxy = true)]
		private static void InvokeTrackingOriginUpdatedEvent(IntPtr internalPtr)
		{
			IntegratedSubsystem integratedSubsystemByPtr = SubsystemManager.GetIntegratedSubsystemByPtr(internalPtr);
			if (integratedSubsystemByPtr is XRInputSubsystem { trackingOriginUpdated: not null } xRInputSubsystem)
			{
				xRInputSubsystem.trackingOriginUpdated(xRInputSubsystem);
			}
		}

		[RequiredByNativeCode(GenerateProxy = true)]
		private static void InvokeBoundaryChangedEvent(IntPtr internalPtr)
		{
			IntegratedSubsystem integratedSubsystemByPtr = SubsystemManager.GetIntegratedSubsystemByPtr(internalPtr);
			if (integratedSubsystemByPtr is XRInputSubsystem { boundaryChanged: not null } xRInputSubsystem)
			{
				xRInputSubsystem.boundaryChanged(xRInputSubsystem);
			}
		}

		internal unsafe void TryGetDeviceIds_AsList(List<ulong> deviceIds)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<ulong> list = default(List<ulong>);
			BlittableListWrapper deviceIds2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = deviceIds;
				if (list != null)
				{
					fixed (ulong[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						deviceIds2 = new BlittableListWrapper(arrayWrapper, list.Count);
						TryGetDeviceIds_AsList_Injected(intPtr, ref deviceIds2);
						return;
					}
				}
				TryGetDeviceIds_AsList_Injected(intPtr, ref deviceIds2);
			}
			finally
			{
				deviceIds2.Unmarshal(list);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetIndex_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryRecenter_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TrySetTrackingOriginMode_Injected(IntPtr _unity_self, TrackingOriginModeFlags origin);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern TrackingOriginModeFlags GetTrackingOriginMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern TrackingOriginModeFlags GetSupportedTrackingOriginModes_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetBoundaryPoints_AsList_Injected(IntPtr _unity_self, ref BlittableListWrapper boundaryPoints);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void TryGetDeviceIds_AsList_Injected(IntPtr _unity_self, ref BlittableListWrapper deviceIds);
	}
	[NativeConditional("ENABLE_XR")]
	[UsedByNativeCode]
	[NativeType(Header = "Modules/XR/Subsystems/Input/XRInputSubsystemDescriptor.h")]
	[NativeHeader("Modules/XR/XRPrefix.h")]
	public class XRInputSubsystemDescriptor : IntegratedSubsystemDescriptor<XRInputSubsystem>
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(XRInputSubsystemDescriptor descriptor)
			{
				return descriptor.m_Ptr;
			}
		}

		[NativeConditional("ENABLE_XR")]
		public bool disablesLegacyInput
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_disablesLegacyInput_Injected(intPtr);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_disablesLegacyInput_Injected(IntPtr _unity_self);
	}
	[UsedByNativeCode]
	[NativeHeader("Modules/XR/Subsystems/Meshing/XRMeshBindings.h")]
	public struct MeshId : IEquatable<MeshId>
	{
		private static MeshId s_InvalidId = default(MeshId);

		private ulong m_SubId1;

		private ulong m_SubId2;

		public static MeshId InvalidId => s_InvalidId;

		public override string ToString()
		{
			return string.Format("{0}-{1}", m_SubId1.ToString("X16"), m_SubId2.ToString("X16"));
		}

		public override int GetHashCode()
		{
			return m_SubId1.GetHashCode() ^ m_SubId2.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return obj is MeshId && Equals((MeshId)obj);
		}

		public bool Equals(MeshId other)
		{
			return m_SubId1 == other.m_SubId1 && m_SubId2 == other.m_SubId2;
		}

		public static bool operator ==(MeshId id1, MeshId id2)
		{
			return id1.m_SubId1 == id2.m_SubId1 && id1.m_SubId2 == id2.m_SubId2;
		}

		public static bool operator !=(MeshId id1, MeshId id2)
		{
			return id1.m_SubId1 != id2.m_SubId1 || id1.m_SubId2 != id2.m_SubId2;
		}
	}
	[NativeHeader("Modules/XR/Subsystems/Meshing/XRMeshBindings.h")]
	[RequiredByNativeCode]
	public enum MeshGenerationStatus
	{
		Success,
		InvalidMeshId,
		GenerationAlreadyInProgress,
		Canceled,
		UnknownError
	}
	internal static class HashCodeHelper
	{
		private const int k_HashCodeMultiplier = 486187739;

		public static int Combine(int hash1, int hash2)
		{
			return hash1 * 486187739 + hash2;
		}

		public static int Combine(int hash1, int hash2, int hash3)
		{
			return Combine(Combine(hash1, hash2), hash3);
		}

		public static int Combine(int hash1, int hash2, int hash3, int hash4)
		{
			return Combine(Combine(hash1, hash2, hash3), hash4);
		}

		public static int Combine(int hash1, int hash2, int hash3, int hash4, int hash5)
		{
			return Combine(Combine(hash1, hash2, hash3, hash4), hash5);
		}

		public static int Combine(int hash1, int hash2, int hash3, int hash4, int hash5, int hash6)
		{
			return Combine(Combine(hash1, hash2, hash3, hash4, hash5), hash6);
		}

		public static int Combine(int hash1, int hash2, int hash3, int hash4, int hash5, int hash6, int hash7)
		{
			return Combine(Combine(hash1, hash2, hash3, hash4, hash5, hash6), hash7);
		}

		public static int Combine(int hash1, int hash2, int hash3, int hash4, int hash5, int hash6, int hash7, int hash8)
		{
			return Combine(Combine(hash1, hash2, hash3, hash4, hash5, hash6, hash7), hash8);
		}
	}
	[NativeHeader("Modules/XR/Subsystems/Meshing/XRMeshBindings.h")]
	[RequiredByNativeCode]
	public struct MeshGenerationResult : IEquatable<MeshGenerationResult>
	{
		public MeshId MeshId { get; }

		public Mesh Mesh { get; }

		public MeshCollider MeshCollider { get; }

		public MeshGenerationStatus Status { get; }

		public MeshVertexAttributes Attributes { get; }

		public ulong Timestamp { get; }

		public Vector3 Position { get; }

		public Quaternion Rotation { get; }

		public Vector3 Scale { get; }

		public override bool Equals(object obj)
		{
			if (!(obj is MeshGenerationResult))
			{
				return false;
			}
			return Equals((MeshGenerationResult)obj);
		}

		public bool Equals(MeshGenerationResult other)
		{
			return MeshId.Equals(other.MeshId) && Mesh.Equals(other.Mesh) && MeshCollider.Equals(other.MeshCollider) && Status == other.Status && Attributes == other.Attributes && Position.Equals(other.Position) && Rotation.Equals(other.Rotation) && Scale.Equals(other.Scale);
		}

		public static bool operator ==(MeshGenerationResult lhs, MeshGenerationResult rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(MeshGenerationResult lhs, MeshGenerationResult rhs)
		{
			return !lhs.Equals(rhs);
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Combine(MeshId.GetHashCode(), Mesh.GetHashCode(), MeshCollider.GetHashCode(), ((int)Status).GetHashCode(), ((int)Attributes).GetHashCode(), Position.GetHashCode(), Rotation.GetHashCode(), Scale.GetHashCode());
		}
	}
	[NativeHeader("Modules/XR/Subsystems/Meshing/XRMeshBindings.h")]
	[UsedByNativeCode]
	[Flags]
	public enum MeshVertexAttributes
	{
		None = 0,
		Normals = 1,
		Tangents = 2,
		UVs = 4,
		Colors = 8
	}
	[UsedByNativeCode]
	[NativeHeader("Modules/XR/Subsystems/Meshing/XRMeshBindings.h")]
	[Flags]
	public enum MeshGenerationOptions
	{
		None = 0,
		ConsumeTransform = 1
	}
	[NativeHeader("Modules/XR/Subsystems/Meshing/XRMeshBindings.h")]
	[UsedByNativeCode]
	public enum MeshChangeState
	{
		Added,
		Updated,
		Removed,
		Unchanged
	}
	[NativeHeader("Modules/XR/Subsystems/Meshing/XRMeshBindings.h")]
	[UsedByNativeCode]
	public struct MeshInfo : IEquatable<MeshInfo>
	{
		public MeshId MeshId { get; set; }

		public MeshChangeState ChangeState { get; set; }

		public int PriorityHint { get; set; }

		public override bool Equals(object obj)
		{
			if (!(obj is MeshInfo))
			{
				return false;
			}
			return Equals((MeshInfo)obj);
		}

		public bool Equals(MeshInfo other)
		{
			return MeshId.Equals(other.MeshId) && ChangeState.Equals(other.ChangeState) && PriorityHint.Equals(other.PriorityHint);
		}

		public static bool operator ==(MeshInfo lhs, MeshInfo rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(MeshInfo lhs, MeshInfo rhs)
		{
			return !lhs.Equals(rhs);
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Combine(MeshId.GetHashCode(), ((int)ChangeState).GetHashCode(), PriorityHint.GetHashCode());
		}
	}
	[NativeHeader("Modules/XR/Subsystems/Meshing/XRMeshBindings.h")]
	[UsedByNativeCode]
	public readonly struct MeshTransform : IEquatable<MeshTransform>
	{
		public MeshId MeshId { get; }

		public ulong Timestamp { get; }

		public Vector3 Position { get; }

		public Quaternion Rotation { get; }

		public Vector3 Scale { get; }

		public MeshTransform(in MeshId meshId, ulong timestamp, in Vector3 position, in Quaternion rotation, in Vector3 scale)
		{
			MeshId = meshId;
			Timestamp = timestamp;
			Position = position;
			Rotation = rotation;
			Scale = scale;
		}

		public override bool Equals(object obj)
		{
			return obj is MeshTransform other && Equals(other);
		}

		public bool Equals(MeshTransform other)
		{
			return MeshId.Equals(other.MeshId) && Timestamp == other.Timestamp && Position.Equals(other.Position) && Rotation.Equals(other.Rotation) && Scale.Equals(other.Scale);
		}

		public static bool operator ==(MeshTransform lhs, MeshTransform rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(MeshTransform lhs, MeshTransform rhs)
		{
			return !lhs.Equals(rhs);
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Combine(MeshId.GetHashCode(), Timestamp.GetHashCode(), Position.GetHashCode(), Rotation.GetHashCode(), Scale.GetHashCode());
		}
	}
	[NativeConditional("ENABLE_XR")]
	[NativeHeader("Modules/XR/Subsystems/Meshing/XRMeshingSubsystem.h")]
	[UsedByNativeCode]
	[NativeHeader("Modules/XR/XRPrefix.h")]
	public class XRMeshSubsystem : IntegratedSubsystem<XRMeshSubsystemDescriptor>
	{
		[NativeConditional("ENABLE_XR")]
		private readonly struct MeshTransformList(IntPtr self) : IDisposable
		{
			private readonly IntPtr m_Self = self;

			public int Count => GetLength(m_Self);

			public IntPtr Data => GetData(m_Self);

			public void Dispose()
			{
				Dispose(m_Self);
			}

			[MethodImpl(MethodImplOptions.InternalCall)]
			[FreeFunction("UnityXRMeshTransformList_get_Length")]
			private static extern int GetLength(IntPtr self);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[FreeFunction("UnityXRMeshTransformList_get_Data")]
			private static extern IntPtr GetData(IntPtr self);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[FreeFunction("UnityXRMeshTransformList_Dispose")]
			private static extern void Dispose(IntPtr self);
		}

		internal new static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(XRMeshSubsystem subsystem)
			{
				return subsystem.m_Ptr;
			}
		}

		public float meshDensity
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_meshDensity_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_meshDensity_Injected(intPtr, value);
			}
		}

		public bool TryGetMeshInfos(List<MeshInfo> meshInfosOut)
		{
			if (meshInfosOut == null)
			{
				throw new ArgumentNullException("meshInfosOut");
			}
			return GetMeshInfosAsList(meshInfosOut);
		}

		private unsafe bool GetMeshInfosAsList(List<MeshInfo> meshInfos)
		{
			//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			List<MeshInfo> list = default(List<MeshInfo>);
			BlittableListWrapper meshInfos2 = default(BlittableListWrapper);
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				list = meshInfos;
				if (list != null)
				{
					fixed (MeshInfo[] array = NoAllocHelpers.ExtractArrayFromList(list))
					{
						BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
						if (array.Length != 0)
						{
							arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						meshInfos2 = new BlittableListWrapper(arrayWrapper, list.Count);
						return GetMeshInfosAsList_Injected(intPtr, ref meshInfos2);
					}
				}
				return GetMeshInfosAsList_Injected(intPtr, ref meshInfos2);
			}
			finally
			{
				meshInfos2.Unmarshal(list);
			}
		}

		private MeshInfo[] GetMeshInfosAsFixedArray()
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			MeshInfo[] result;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetMeshInfosAsFixedArray_Injected(intPtr, out ret);
			}
			finally
			{
				MeshInfo[] array = default(MeshInfo[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}

		public void GenerateMeshAsync(MeshId meshId, Mesh mesh, MeshCollider meshCollider, MeshVertexAttributes attributes, Action<MeshGenerationResult> onMeshGenerationComplete)
		{
			GenerateMeshAsync(meshId, mesh, meshCollider, attributes, onMeshGenerationComplete, MeshGenerationOptions.None);
		}

		public void GenerateMeshAsync(MeshId meshId, Mesh mesh, MeshCollider meshCollider, MeshVertexAttributes attributes, Action<MeshGenerationResult> onMeshGenerationComplete, MeshGenerationOptions options)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GenerateMeshAsync_Injected(intPtr, ref meshId, Object.MarshalledUnityObject.Marshal(mesh), Object.MarshalledUnityObject.Marshal(meshCollider), attributes, onMeshGenerationComplete, options);
		}

		[RequiredByNativeCode]
		private void InvokeMeshReadyDelegate(MeshGenerationResult result, Action<MeshGenerationResult> onMeshGenerationComplete)
		{
			onMeshGenerationComplete?.Invoke(result);
		}

		public bool SetBoundingVolume(Vector3 origin, Vector3 extents)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetBoundingVolume_Injected(intPtr, ref origin, ref extents);
		}

		public unsafe NativeArray<MeshTransform> GetUpdatedMeshTransforms(Allocator allocator)
		{
			using MeshTransformList meshTransformList = new MeshTransformList(GetUpdatedMeshTransforms());
			NativeArray<MeshTransform> nativeArray = new NativeArray<MeshTransform>(meshTransformList.Count, allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr(), meshTransformList.Data.ToPointer(), meshTransformList.Count * sizeof(MeshTransform));
			return nativeArray;
		}

		private IntPtr GetUpdatedMeshTransforms()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetUpdatedMeshTransforms_Injected(intPtr);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetMeshInfosAsList_Injected(IntPtr _unity_self, ref BlittableListWrapper meshInfos);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetMeshInfosAsFixedArray_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GenerateMeshAsync_Injected(IntPtr _unity_self, [In] ref MeshId meshId, IntPtr mesh, IntPtr meshCollider, MeshVertexAttributes attributes, Action<MeshGenerationResult> onMeshGenerationComplete, MeshGenerationOptions options);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_meshDensity_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_meshDensity_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetBoundingVolume_Injected(IntPtr _unity_self, [In] ref Vector3 origin, [In] ref Vector3 extents);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetUpdatedMeshTransforms_Injected(IntPtr _unity_self);
	}
	[UsedByNativeCode]
	[NativeType(Header = "Modules/XR/Subsystems/Planes/XRMeshSubsystemDescriptor.h")]
	[NativeHeader("Modules/XR/XRPrefix.h")]
	public class XRMeshSubsystemDescriptor : IntegratedSubsystemDescriptor<XRMeshSubsystem>
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(XRMeshSubsystemDescriptor descriptor)
			{
				return descriptor.m_Ptr;
			}
		}
	}
}
namespace UnityEngine.XR.Provider
{
	public static class XRStats
	{
		public static bool TryGetStat(IntegratedSubsystem xrSubsystem, string tag, out float value)
		{
			return TryGetStat_Internal(xrSubsystem.m_Ptr, tag, out value);
		}

		[StaticAccessor("XRStats::Get()", StaticAccessorType.Dot)]
		[NativeMethod("TryGetStatByName_Internal")]
		[NativeHeader("Modules/XR/Stats/XRStats.h")]
		[NativeConditional("ENABLE_XR")]
		private unsafe static bool TryGetStat_Internal(IntPtr ptr, string tag, out float value)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(tag, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(tag);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return TryGetStat_Internal_Injected(ptr, ref managedSpanWrapper, out value);
					}
				}
				return TryGetStat_Internal_Injected(ptr, ref managedSpanWrapper, out value);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TryGetStat_Internal_Injected(IntPtr ptr, ref ManagedSpanWrapper tag, out float value);
	}
}
