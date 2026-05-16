using System;
using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

[assembly: InternalsVisibleTo("UnityEngine.Advertisements")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: InternalsVisibleTo("UnityEngine.Purchasing")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS4VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4Module")]
[assembly: InternalsVisibleTo("UnityEngine.SwitchModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.TestRunner")]
[assembly: InternalsVisibleTo("Unity.Burst")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.Automation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Application")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.CommonUtils")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Tooling")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Deployment")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.2D")]
[assembly: InternalsVisibleTo("Unity.DeploymentTests.Services")]
[assembly: InternalsVisibleTo("Unity.Burst.Editor")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
[assembly: InternalsVisibleTo("UnityEngine.XRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VFXModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestWWWModule")]
[assembly: InternalsVisibleTo("UnityEngine.ParticleSystemModule")]
[assembly: InternalsVisibleTo("UnityEngine.NVIDIAModule")]
[assembly: InternalsVisibleTo("UnityEngine.MultiplayerModule")]
[assembly: InternalsVisibleTo("UnityEngine.MarshallingModule")]
[assembly: InternalsVisibleTo("UnityEngine.LocalizationModule")]
[assembly: InternalsVisibleTo("UnityEngine.InsightsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConsentModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputForUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.IMGUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreFontEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputLegacyModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextRenderingModule")]
[assembly: InternalsVisibleTo("UnityEngine.HierarchyCoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.GridModule")]
[assembly: InternalsVisibleTo("UnityEngine.GraphicsStateCollectionSerializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.GameCenterModule")]
[assembly: InternalsVisibleTo("UnityEngine.ImageConversionModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreTextEngineModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("UnityEngine.Physics2DModule")]
[assembly: InternalsVisibleTo("UnityEngine.RuntimeInitializeOnLoadManagerInitializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestTextureModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityTestProtocolModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityCurlModule")]
[assembly: InternalsVisibleTo("UnityEngine.UmbraModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIModule")]
[assembly: InternalsVisibleTo("UnityEngine.PropertiesModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainPhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubsystemsModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubstanceModule")]
[assembly: InternalsVisibleTo("UnityEngine.StreamingModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteMaskModule")]
[assembly: InternalsVisibleTo("UnityEngine.TilemapModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteShapeModule")]
[assembly: InternalsVisibleTo("UnityEngine.ShaderVariantAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.ScreenCaptureModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.008")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.007")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.006")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.009")]
[assembly: InternalsVisibleTo("UnityEngine.Core.Runtime.Tests")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.012")]
[assembly: InternalsVisibleTo("Unity.Subsystem.Registration")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.024")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.023")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.022")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.020")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.019")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.018")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.017")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.016")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.015")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.014")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.013")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.021")]
[assembly: InternalsVisibleTo("UnityEngine.GIModule")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: InternalsVisibleTo("UnityEngine.SharedInternalsModule")]
[assembly: InternalsVisibleTo("UnityEngine.CoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.AIModule")]
[assembly: InternalsVisibleTo("UnityEngine.AMDModule")]
[assembly: InternalsVisibleTo("UnityEngine.PhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.JSONSerializeModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputModule")]
[assembly: InternalsVisibleTo("UnityEngine.ARModule")]
[assembly: InternalsVisibleTo("UnityEngine.AccessibilityModule")]
[assembly: InternalsVisibleTo("UnityEngine.AndroidJNIModule")]
[assembly: InternalsVisibleTo("UnityEngine.HotReloadModule")]
[assembly: InternalsVisibleTo("UnityEngine.AssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.AudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClothModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterInputModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterRendererModule")]
[assembly: InternalsVisibleTo("UnityEngine.ContentLoadModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConnectModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
[assembly: InternalsVisibleTo("UnityEngine.AnimationModule")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine.Analytics
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	public class SubsystemsAnalyticBase : AnalyticsEventBase
	{
		public string subsystem;

		public SubsystemsAnalyticBase(string eventName)
			: base(eventName, 1)
		{
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	public class SubsystemsAnalyticStart : SubsystemsAnalyticBase
	{
		public SubsystemsAnalyticStart()
			: base("SubsystemStart")
		{
		}

		[RequiredByNativeCode]
		internal static SubsystemsAnalyticStart CreateSubsystemsAnalyticStart()
		{
			return new SubsystemsAnalyticStart();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class SubsystemsAnalyticStop : SubsystemsAnalyticBase
	{
		public SubsystemsAnalyticStop()
			: base("SubsystemStop")
		{
		}

		[RequiredByNativeCode]
		internal static SubsystemsAnalyticStop CreateSubsystemsAnalyticStop()
		{
			return new SubsystemsAnalyticStop();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	public class SubsystemsAnalyticInfo : SubsystemsAnalyticBase
	{
		private string id;

		private string plugin_name;

		private string version;

		private string library_name;

		public SubsystemsAnalyticInfo()
			: base("SubsystemInfo")
		{
		}

		[RequiredByNativeCode]
		internal static SubsystemsAnalyticInfo CreateSubsystemsAnalyticInfo()
		{
			return new SubsystemsAnalyticInfo();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class VRDeviceAnalyticBase : AnalyticsEventBase
	{
		public VRDeviceAnalyticBase()
			: base("deviceStatus", 1)
		{
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	public class VRDeviceAnalyticAspect : VRDeviceAnalyticBase
	{
		public float vr_aspect_ratio;

		[RequiredByNativeCode]
		internal static VRDeviceAnalyticAspect CreateVRDeviceAnalyticAspect()
		{
			return new VRDeviceAnalyticAspect();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class VRDeviceMirrorAnalytic : VRDeviceAnalyticBase
	{
		public bool vr_device_mirror_mode;

		[RequiredByNativeCode]
		internal static VRDeviceMirrorAnalytic CreateVRDeviceMirrorAnalytic()
		{
			return new VRDeviceMirrorAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class VRDeviceUserAnalytic : VRDeviceAnalyticBase
	{
		public int vr_user_presence;

		[RequiredByNativeCode]
		internal static VRDeviceUserAnalytic CreateVRDeviceUserAnalytic()
		{
			return new VRDeviceUserAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class VRDeviceActiveControllersAnalytic : VRDeviceAnalyticBase
	{
		public string[] vr_active_controllers;

		[RequiredByNativeCode]
		internal static VRDeviceActiveControllersAnalytic CreateVRDeviceActiveControllersAnalytic()
		{
			return new VRDeviceActiveControllersAnalytic();
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/UnityAnalyticsCommon/Public/UnityAnalyticsCommon.h")]
	[ExcludeFromDocs]
	public static class AnalyticsCommon
	{
		[StaticAccessor("GetUnityAnalyticsCommon()", StaticAccessorType.Dot)]
		private static extern bool ugsAnalyticsEnabledInternal
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("UGSAnalyticsUserOptStatus")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("SetUGSAnalyticsUserOptStatus")]
			set;
		}

		public static bool ugsAnalyticsEnabled
		{
			get
			{
				return ugsAnalyticsEnabledInternal;
			}
			set
			{
				ugsAnalyticsEnabledInternal = value;
			}
		}
	}
	public enum AnalyticsResult
	{
		Ok,
		NotInitialized,
		AnalyticsDisabled,
		TooManyItems,
		SizeLimitReached,
		TooManyRequests,
		InvalidData,
		UnsupportedPlatform
	}
	[ExcludeFromDocs]
	public interface UGSAnalyticsInternalTools
	{
		static void SetPrivacyStatus(bool status)
		{
			AnalyticsCommon.ugsAnalyticsEnabled = status;
		}
	}
	[ExcludeFromDocs]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class AnalyticInfoAttribute : Attribute
	{
		public int version { get; }

		public string vendorKey { get; }

		public string eventName { get; }

		internal int maxEventsPerHour { get; }

		internal int maxNumberOfElements { get; }

		public AnalyticInfoAttribute(string eventName, string vendorKey = "", int version = 1, int maxEventsPerHour = 1000, int maxNumberOfElements = 1000)
		{
			this.version = version;
			this.vendorKey = vendorKey;
			this.eventName = eventName;
			this.maxEventsPerHour = maxEventsPerHour;
			this.maxNumberOfElements = maxNumberOfElements;
		}
	}
	[ExcludeFromDocs]
	public interface IAnalytic
	{
		public interface IData
		{
		}

		public struct DataList<T>(T[] datas) : IEnumerable, IData where T : struct
		{
			private readonly T[] m_UsageData = datas;

			public IEnumerator GetEnumerator()
			{
				return m_UsageData.GetEnumerator();
			}
		}

		bool TryGatherData(out IData data, [NotNullWhen(false)] out Exception error);
	}
	[ExcludeFromDocs]
	public class Analytic : AnalyticsEventBase
	{
		public readonly IAnalytic instance;

		public readonly AnalyticInfoAttribute info;

		public Analytic(IAnalytic instance, AnalyticInfoAttribute info)
			: base(info.eventName, info.version)
		{
			this.instance = instance;
			this.info = info;
		}
	}
}
namespace UnityEditor.Analytics
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	public class AssetDatabaseRefreshAnalytic : AnalyticsEventBase
	{
		[SerializeField]
		public bool isV2;

		[SerializeField]
		public long Imports_Imported;

		[SerializeField]
		public long Imports_ImportedInProcess;

		[SerializeField]
		public long Imports_ImportedOutOfProcess;

		[SerializeField]
		public long Imports_Refresh;

		[SerializeField]
		public long Imports_DomainReload;

		[SerializeField]
		public long CacheServer_MetadataRequested;

		[SerializeField]
		public long CacheServer_MetadataDownloaded;

		[SerializeField]
		public long CacheServer_MetadataFailedToDownload;

		[SerializeField]
		public long CacheServer_MetadataUploaded;

		[SerializeField]
		public long CacheServer_ArtifactsFailedToUpload;

		[SerializeField]
		public long CacheServer_MetadataVersionsDownloaded;

		[SerializeField]
		public long CacheServer_MetadataMatched;

		[SerializeField]
		public long CacheServer_ArtifactsDownloaded;

		[SerializeField]
		public long CacheServer_ArtifactFilesDownloaded;

		[SerializeField]
		public long CacheServer_ArtifactFilesFailedToDownload;

		[SerializeField]
		public long CacheServer_ArtifactsUploaded;

		[SerializeField]
		public long CacheServer_ArtifactFilesUploaded;

		[SerializeField]
		public long CacheServer_ArtifactFilesFailedToUpload;

		[SerializeField]
		public long CacheServer_Connects;

		[SerializeField]
		public long CacheServer_Disconnects;

		public AssetDatabaseRefreshAnalytic()
			: base("assetDatabaseInitRefresh", 1)
		{
		}

		[RequiredByNativeCode]
		internal static AssetDatabaseRefreshAnalytic CreateAssetDatabaseRefreshAnalytic()
		{
			return new AssetDatabaseRefreshAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class BuildAssetBundleAnalytic : AnalyticsEventBase
	{
		public bool success;

		public string error;

		public BuildAssetBundleAnalytic()
			: base("unity5BuildAssetBundles", 1)
		{
		}

		[RequiredByNativeCode]
		internal static BuildAssetBundleAnalytic CreateBuildAssetBundleAnalytic()
		{
			return new BuildAssetBundleAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class CollabOperationAnalytic : AnalyticsEventBase
	{
		public string category;

		public string operation;

		public string result;

		public long start_ts;

		public long duration;

		public CollabOperationAnalytic()
			: base("collabOperation", 1)
		{
		}

		[RequiredByNativeCode]
		internal static CollabOperationAnalytic CreateCollabOperationAnalytic()
		{
			return new CollabOperationAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class LicensingErrorAnalytic : AnalyticsEventBase
	{
		public string licensingErrorType;

		public string additionalData;

		public string errorMessage;

		public string correlationId;

		public string sessionId;

		public LicensingErrorAnalytic()
			: base("license_error", 1)
		{
		}

		[RequiredByNativeCode]
		internal static LicensingErrorAnalytic CreateLicensingErrorAnalytic()
		{
			return new LicensingErrorAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class LicensingInitAnalytic : AnalyticsEventBase
	{
		public string licensingProtocolVersion;

		public string licensingClientVersion;

		public string channelType;

		public double initTime;

		public bool isLegacy;

		public string sessionId;

		public string correlationId;

		public LicensingInitAnalytic()
			: base("license_init", 1)
		{
		}

		[RequiredByNativeCode]
		internal static LicensingInitAnalytic CreateLicensingInitAnalytic()
		{
			return new LicensingInitAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class MetalPatchShaderComputeBufferAnalytic : AnalyticsEventBase
	{
		public MetalPatchShaderComputeBufferAnalytic()
			: base("MetalPatchShaderComputeBuffersUsage", 1)
		{
		}

		[RequiredByNativeCode]
		internal static MetalPatchShaderComputeBufferAnalytic CreateMetalPatchShaderComputeBufferAnalytic()
		{
			return new MetalPatchShaderComputeBufferAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class NavmeshBakingAnalytic : AnalyticsEventBase
	{
		private bool new_nav_api;

		private bool bake_at_runtime;

		private int height_meshes_count;

		private int offmesh_links_count;

		public NavmeshBakingAnalytic()
			: base("navigation_navmesh_baking", 1)
		{
		}

		[RequiredByNativeCode]
		internal static NavmeshBakingAnalytic CreateNavmeshBakingAnalytic()
		{
			return new NavmeshBakingAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class ProjectSettingsInformationAnalytic : AnalyticsEventBase
	{
		private int agent_types_count;

		private int areas_count;

		public ProjectSettingsInformationAnalytic()
			: base("navigation_project_settings_info", 1)
		{
		}

		[RequiredByNativeCode]
		internal static ProjectSettingsInformationAnalytic CreateProjectSettingsInformationAnalytic()
		{
			return new ProjectSettingsInformationAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class SendGameBuildAnalytic : AnalyticsEventBase
	{
		private int navmesh_count;

		public SendGameBuildAnalytic()
			: base("navigation_gamebuild_info", 1, SendEventOptions.kAppendBuildGuid)
		{
		}

		[RequiredByNativeCode]
		internal static SendGameBuildAnalytic CreateSendGameBuildAnalytic()
		{
			return new SendGameBuildAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class PackageManagerBaseAnalytic : AnalyticsEventBase
	{
		public long start_ts;

		public long duration;

		public bool blocking;

		public string package_id;

		public int status_code;

		public string error_message;

		public PackageManagerBaseAnalytic(string eventName)
			: base(eventName, 1, SendEventOptions.kAppendNone, "packageManager")
		{
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	public class PackageManagerAddPackageAnalytic : PackageManagerBaseAnalytic
	{
		public PackageManagerAddPackageAnalytic()
			: base("addPackage")
		{
		}

		[RequiredByNativeCode]
		internal static PackageManagerAddPackageAnalytic CreatePackageManagerAddPackageAnalytic()
		{
			return new PackageManagerAddPackageAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class PackageManagerTestAnalytic : PackageManagerBaseAnalytic
	{
		public PackageManagerTestAnalytic()
			: base("PackageManager")
		{
		}

		[RequiredByNativeCode]
		internal static PackageManagerTestAnalytic CreatePackageManagerTestAnalytic()
		{
			return new PackageManagerTestAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class PackageManagerRemovePackageAnalytic : PackageManagerBaseAnalytic
	{
		public PackageManagerRemovePackageAnalytic()
			: base("removePackage")
		{
		}

		[RequiredByNativeCode]
		internal static PackageManagerRemovePackageAnalytic CreatePackageManagerRemovePackageAnalytic()
		{
			return new PackageManagerRemovePackageAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class PackageManagerResolvePackageAnalytic : PackageManagerBaseAnalytic
	{
		public string[] packages;

		public string[] package_registries;

		public string[] package_signatures;

		public string[] package_sources;

		public string[] package_types;

		public string[] package_compliance_statuses;

		public PackageManagerResolvePackageAnalytic()
			: base("resolvePackages")
		{
		}

		[RequiredByNativeCode]
		internal static PackageManagerResolvePackageAnalytic CreatePackageManagerResolvePackageAnalytic()
		{
			return new PackageManagerResolvePackageAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	public class PackageManagerEmbedPackageAnalytic : PackageManagerBaseAnalytic
	{
		public PackageManagerEmbedPackageAnalytic()
			: base("embedPackage")
		{
		}

		[RequiredByNativeCode]
		internal static PackageManagerEmbedPackageAnalytic CreatePackageManagerEmbedPackageAnalytic()
		{
			return new PackageManagerEmbedPackageAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	public class PackageManagerResetPackageAnalytic : PackageManagerBaseAnalytic
	{
		public PackageManagerResetPackageAnalytic()
			: base("resetToDefaultDependencies")
		{
		}

		[RequiredByNativeCode]
		internal static PackageManagerResetPackageAnalytic CreatePackageManagerResetPackageAnalytic()
		{
			return new PackageManagerResetPackageAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	public class PackageManagerResolveErrorPackageAnalytic : PackageManagerBaseAnalytic
	{
		public string reason;

		public string action;

		public PackageManagerResolveErrorPackageAnalytic()
			: base("resolveErrorUserAction")
		{
		}

		[RequiredByNativeCode]
		internal static PackageManagerResolveErrorPackageAnalytic CreatePackageManagerResolveErrorPackageAnalytic()
		{
			return new PackageManagerResolveErrorPackageAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	public class PackageManagerStartServerPackageAnalytic : PackageManagerBaseAnalytic
	{
		public PackageManagerStartServerPackageAnalytic()
			: base("startPackageManagerServer")
		{
		}

		[RequiredByNativeCode]
		internal static PackageManagerStartServerPackageAnalytic CreatePackageManagerStartServerPackageAnalytic()
		{
			return new PackageManagerStartServerPackageAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	internal class AssetImportStatusAnalytic : AnalyticsEventBase
	{
		public string package_name;

		public int package_items_count;

		public int package_import_status;

		public string error_message;

		public int project_assets_count;

		public int unselected_assets_count;

		public int selected_new_assets_count;

		public int selected_changed_assets_count;

		public int unchanged_assets_count;

		public string[] selected_asset_extensions;

		public AssetImportStatusAnalytic()
			: base("assetImportStatus", 1, SendEventOptions.kAppendBuildTarget)
		{
		}

		[RequiredByNativeCode]
		public static AssetImportStatusAnalytic CreateAssetImportStatusAnalytic()
		{
			return new AssetImportStatusAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	internal class AssetImportAnalytic : AnalyticsEventBase
	{
		public string package_name;

		public int package_import_choice;

		public AssetImportAnalytic()
			: base("assetImport", 1)
		{
		}

		[RequiredByNativeCode]
		public static AssetImportAnalytic CreateAssetImportAnalytic()
		{
			return new AssetImportAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	internal class AssetExportAnalytic : AnalyticsEventBase
	{
		public string package_name;

		public string error_message;

		public int items_count;

		public string[] asset_extensions;

		public bool include_upm_dependencies;

		public AssetExportAnalytic()
			: base("assetExport", 1)
		{
		}

		[RequiredByNativeCode]
		public static AssetExportAnalytic CreateAssetExportAnalytic()
		{
			return new AssetExportAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	public class StallSummaryAnalytic : AnalyticsEventBase
	{
		public double Duration;

		public StallSummaryAnalytic()
			: base("editorStallSummary", 1)
		{
		}

		[RequiredByNativeCode]
		internal static StallSummaryAnalytic CreateStallSummaryAnalytic()
		{
			return new StallSummaryAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	internal class StallMarkerAnalytic : AnalyticsEventBase
	{
		public string Name;

		public bool HasProgressMarkup;

		public double Duration;

		public StallMarkerAnalytic()
			: base("editorStallMarker", 1)
		{
		}

		[RequiredByNativeCode]
		internal static StallMarkerAnalytic CreateStallMarkerAnalytic()
		{
			return new StallMarkerAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[ExcludeFromDocs]
	internal class TestAnalytic : AnalyticsEventBase
	{
		public int param;

		public TestAnalytic()
			: base("TestAnalytic", 1)
		{
		}

		[RequiredByNativeCode]
		public static TestAnalytic CreateTestAnalytic()
		{
			return new TestAnalytic();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	public class VCProviderAnalytics : AnalyticsEventBase
	{
		public string Mode;

		public VCProviderAnalytics()
			: base("versioncontrol_ProviderSettings_OnUpdate", 1)
		{
		}

		[RequiredByNativeCode]
		internal static VCProviderAnalytics CreateVCProviderAnalytics()
		{
			return new VCProviderAnalytics();
		}
	}
}
