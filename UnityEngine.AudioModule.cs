using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Playables;
using UnityEngine.Scripting;

[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.UIModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainPhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubsystemsModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubstanceModule")]
[assembly: InternalsVisibleTo("UnityEngine.StreamingModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteMaskModule")]
[assembly: InternalsVisibleTo("UnityEngine.TilemapModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteShapeModule")]
[assembly: InternalsVisibleTo("UnityEngine.ShaderVariantAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.ScreenCaptureModule")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
[assembly: InternalsVisibleTo("UnityEngine.RuntimeInitializeOnLoadManagerInitializerModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS4VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4Module")]
[assembly: InternalsVisibleTo("UnityEngine.SwitchModule")]
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("UnityEngine.PropertiesModule")]
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.CommonUtils")]
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
[assembly: InternalsVisibleTo("UnityEngine.AIModule")]
[assembly: InternalsVisibleTo("UnityEngine.CoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.SharedInternalsModule")]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
[assembly: InternalsVisibleTo("UnityEngine.Physics2DModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.GameCenterModule")]
[assembly: InternalsVisibleTo("UnityEngine.ImageConversionModule")]
[assembly: InternalsVisibleTo("UnityEngine.GIModule")]
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Application")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
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
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.013")]
[assembly: InternalsVisibleTo("Unity.Audio.DSPGraph.Tests")]
[assembly: InternalsVisibleTo("Unity.Audio.DSPGraph")]
[assembly: InternalsVisibleTo("Unity.Audio.Tests")]
[assembly: InternalsVisibleTo("Unity.AudioMixer.Tests")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: InternalsVisibleTo("Unity.Subsystem.Registration")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.012")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.023")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.022")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.021")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.020")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.019")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.018")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.017")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.016")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.015")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.014")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.024")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
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
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("VivoxUnity")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine
{
	public enum AudioSpeakerMode
	{
		[Obsolete("Raw speaker mode is not supported. Do not use.", true)]
		Raw,
		Mono,
		Stereo,
		Quad,
		Surround,
		Mode5point1,
		Mode7point1,
		Prologic
	}
	public enum AudioDataLoadState
	{
		Unloaded,
		Loading,
		Loaded,
		Failed
	}
	public struct AudioConfiguration
	{
		public AudioSpeakerMode speakerMode;

		public int dspBufferSize;

		public int sampleRate;

		public int numRealVoices;

		public int numVirtualVoices;
	}
	public enum AudioCompressionFormat
	{
		PCM,
		Vorbis,
		ADPCM,
		MP3,
		VAG,
		HEVAG,
		XMA,
		AAC,
		GCADPCM,
		ATRAC9
	}
	public enum AudioClipLoadType
	{
		DecompressOnLoad,
		CompressedInMemory,
		Streaming
	}
	public enum AudioVelocityUpdateMode
	{
		Auto,
		Fixed,
		Dynamic
	}
	public enum FFTWindow
	{
		Rectangular,
		Triangle,
		Hamming,
		Hanning,
		Blackman,
		BlackmanHarris
	}
	public enum AudioRolloffMode
	{
		Logarithmic,
		Linear,
		Custom
	}
	public enum AudioSourceCurveType
	{
		CustomRolloff,
		SpatialBlend,
		ReverbZoneMix,
		Spread
	}
	public enum AudioReverbPreset
	{
		Off,
		Generic,
		PaddedCell,
		Room,
		Bathroom,
		Livingroom,
		Stoneroom,
		Auditorium,
		Concerthall,
		Cave,
		Arena,
		Hangar,
		CarpetedHallway,
		Hallway,
		StoneCorridor,
		Alley,
		Forest,
		City,
		Mountains,
		Quarry,
		Plain,
		ParkingLot,
		SewerPipe,
		Underwater,
		Drugged,
		Dizzy,
		Psychotic,
		User
	}
	internal struct PlayableSettings
	{
		public AudioContainerElement element { get; }

		public double scheduledTime { get; }

		public float pitchOffset { get; }

		public float volumeOffset { get; }

		public double triggerTimeOffset { get; }
	}
	internal struct ActivePlayable
	{
		public PlayableSettings settings { get; }

		public PlayableHandle clipPlayableHandle { get; }
	}
	public enum AudioSpatialExperience
	{
		Bypassed,
		HeadTracked,
		Fixed
	}
	[StaticAccessor("GetAudioManager()", StaticAccessorType.Dot)]
	[NativeHeader("Modules/Audio/Public/ScriptBindings/Audio.bindings.h")]
	public sealed class AudioSettings
	{
		public delegate void AudioConfigurationChangeHandler(bool deviceWasChanged);

		public static class Mobile
		{
			public static bool muteState => false;

			public static bool stopAudioOutputOnMute
			{
				get
				{
					return false;
				}
				set
				{
					Debug.LogWarning("Setting AudioSettings.Mobile.stopAudioOutputOnMute is possible on iOS and Android only");
				}
			}

			public static bool audioOutputStarted => true;

			public static event Action<bool> OnMuteStateChanged;

			public static void StartAudioOutput()
			{
				Debug.LogWarning("AudioSettings.Mobile.StartAudioOutput is implemented for iOS and Android only");
			}

			public static void StopAudioOutput()
			{
				Debug.LogWarning("AudioSettings.Mobile.StopAudioOutput is implemented for iOS and Android only");
			}
		}

		public static extern AudioSpeakerMode driverCapabilities
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeName("GetSpeakerModeCaps")]
			get;
		}

		public static AudioSpeakerMode speakerMode
		{
			get
			{
				return GetSpeakerMode();
			}
			set
			{
				Debug.LogWarning("Setting AudioSettings.speakerMode is deprecated and has been replaced by audio project settings and the AudioSettings.GetConfiguration/AudioSettings.Reset API.");
				AudioConfiguration configuration = GetConfiguration();
				configuration.speakerMode = value;
				if (!SetConfiguration(configuration))
				{
					Debug.LogWarning("Setting AudioSettings.speakerMode failed");
				}
			}
		}

		internal static extern int profilerCaptureFlags
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern double dspTime
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod(Name = "GetDSPTime", IsThreadSafe = true)]
			get;
		}

		public static int outputSampleRate
		{
			get
			{
				return GetSampleRate();
			}
			set
			{
				Debug.LogWarning("Setting AudioSettings.outputSampleRate is deprecated and has been replaced by audio project settings and the AudioSettings.GetConfiguration/AudioSettings.Reset API.");
				AudioConfiguration configuration = GetConfiguration();
				configuration.sampleRate = value;
				if (!SetConfiguration(configuration))
				{
					Debug.LogWarning("Setting AudioSettings.outputSampleRate failed");
				}
			}
		}

		internal static extern bool unityAudioDisabled
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeName("IsAudioDisabled")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeName("DisableAudio")]
			set;
		}

		public static AudioSpatialExperience audioSpatialExperience
		{
			get
			{
				return AudioSpatialExperience.Bypassed;
			}
			set
			{
				Debug.LogWarning("AudioSettings.audioSpatialExperience is not implemented on this platform.");
			}
		}

		public static event AudioConfigurationChangeHandler OnAudioConfigurationChanged;

		internal static event Action OnAudioSystemShuttingDown;

		internal static event Action OnAudioSystemStartedUp;

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioSpeakerMode GetSpeakerMode();

		[NativeThrows]
		[NativeMethod(Name = "AudioSettings::SetConfiguration", IsFreeFunction = true)]
		private static bool SetConfiguration(AudioConfiguration config)
		{
			return SetConfiguration_Injected(ref config);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "AudioSettings::GetSampleRate", IsFreeFunction = true)]
		private static extern int GetSampleRate();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "AudioSettings::GetDSPBufferSize", IsFreeFunction = true)]
		public static extern void GetDSPBufferSize(out int bufferLength, out int numBuffers);

		[Obsolete("AudioSettings.SetDSPBufferSize is deprecated and has been replaced by audio project settings and the AudioSettings.GetConfiguration/AudioSettings.Reset API.")]
		public static void SetDSPBufferSize(int bufferLength, int numBuffers)
		{
			Debug.LogWarning("AudioSettings.SetDSPBufferSize is deprecated and has been replaced by audio project settings and the AudioSettings.GetConfiguration/AudioSettings.Reset API.");
			AudioConfiguration configuration = GetConfiguration();
			configuration.dspBufferSize = bufferLength;
			if (!SetConfiguration(configuration))
			{
				Debug.LogWarning("SetDSPBufferSize failed");
			}
		}

		[NativeName("GetCurrentSpatializerDefinitionName")]
		public static string GetSpatializerPluginName()
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				GetSpatializerPluginName_Injected(out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		public static AudioConfiguration GetConfiguration()
		{
			GetConfiguration_Injected(out var ret);
			return ret;
		}

		public static bool Reset(AudioConfiguration config)
		{
			return SetConfiguration(config);
		}

		[RequiredByNativeCode]
		internal static void InvokeOnAudioConfigurationChanged(bool deviceWasChanged)
		{
			if (AudioSettings.OnAudioConfigurationChanged != null)
			{
				AudioSettings.OnAudioConfigurationChanged(deviceWasChanged);
			}
		}

		[RequiredByNativeCode]
		internal static void InvokeOnAudioSystemShuttingDown()
		{
			AudioSettings.OnAudioSystemShuttingDown?.Invoke();
		}

		[RequiredByNativeCode]
		internal static void InvokeOnAudioSystemStartedUp()
		{
			AudioSettings.OnAudioSystemStartedUp?.Invoke();
		}

		[NativeMethod(Name = "AudioSettings::GetCurrentAmbisonicDefinitionName", IsFreeFunction = true)]
		internal static string GetAmbisonicDecoderPluginName()
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				GetAmbisonicDecoderPluginName_Injected(out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetConfiguration_Injected([In] ref AudioConfiguration config);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSpatializerPluginName_Injected(out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetConfiguration_Injected(out AudioConfiguration ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAmbisonicDecoderPluginName_Injected(out ManagedSpanWrapper ret);
	}
	[StaticAccessor("AudioClipBindings", StaticAccessorType.DoubleColon)]
	[NativeHeader("Modules/Audio/Public/ScriptBindings/Audio.bindings.h")]
	public sealed class AudioClip : AudioResource
	{
		public delegate void PCMReaderCallback(float[] data);

		public delegate void PCMSetPositionCallback(int position);

		[NativeProperty("LengthSec")]
		public float length
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_length_Injected(intPtr);
			}
		}

		[NativeProperty("SampleCount")]
		public int samples
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_samples_Injected(intPtr);
			}
		}

		[NativeProperty("ChannelCount")]
		public int channels
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_channels_Injected(intPtr);
			}
		}

		public int frequency
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_frequency_Injected(intPtr);
			}
		}

		[Obsolete("Use AudioClip.loadState instead to get more detailed information about the loading process.")]
		public bool isReadyToPlay
		{
			[NativeName("ReadyToPlay")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isReadyToPlay_Injected(intPtr);
			}
		}

		public AudioClipLoadType loadType
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_loadType_Injected(intPtr);
			}
		}

		public bool preloadAudioData
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_preloadAudioData_Injected(intPtr);
			}
		}

		public bool ambisonic
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_ambisonic_Injected(intPtr);
			}
		}

		public bool loadInBackground
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_loadInBackground_Injected(intPtr);
			}
		}

		public AudioDataLoadState loadState
		{
			[NativeMethod(Name = "AudioClipBindings::GetLoadState", HasExplicitThis = true)]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_loadState_Injected(intPtr);
			}
		}

		private event PCMReaderCallback m_PCMReaderCallback = null;

		private event PCMSetPositionCallback m_PCMSetPositionCallback = null;

		private AudioClip()
		{
		}

		private unsafe static bool GetData([NotNull] AudioClip clip, Span<float> data, int samplesOffset)
		{
			if ((object)clip == null)
			{
				ThrowHelper.ThrowArgumentNullException(clip, "clip");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(clip);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(clip, "clip");
			}
			Span<float> span = data;
			bool data_Injected;
			fixed (float* begin = span)
			{
				ManagedSpanWrapper data2 = new ManagedSpanWrapper(begin, span.Length);
				data_Injected = GetData_Injected(intPtr, ref data2, samplesOffset);
			}
			return data_Injected;
		}

		private unsafe static bool SetData([NotNull] AudioClip clip, ReadOnlySpan<float> data, int samplesOffset)
		{
			if ((object)clip == null)
			{
				ThrowHelper.ThrowArgumentNullException(clip, "clip");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(clip);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(clip, "clip");
			}
			ReadOnlySpan<float> readOnlySpan = data;
			bool result;
			fixed (float* begin = readOnlySpan)
			{
				ManagedSpanWrapper data2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
				result = SetData_Injected(intPtr, ref data2, samplesOffset);
			}
			return result;
		}

		private static AudioClip Construct_Internal()
		{
			return Unmarshal.UnmarshalUnityObject<AudioClip>(Construct_Internal_Injected());
		}

		private string GetName()
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetName_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		private unsafe void CreateUserSound(string name, int lengthSamples, int channels, int frequency, bool stream)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						CreateUserSound_Injected(intPtr, ref managedSpanWrapper, lengthSamples, channels, frequency, stream);
						return;
					}
				}
				CreateUserSound_Injected(intPtr, ref managedSpanWrapper, lengthSamples, channels, frequency, stream);
			}
			finally
			{
			}
		}

		public bool LoadAudioData()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return LoadAudioData_Injected(intPtr);
		}

		public bool UnloadAudioData()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return UnloadAudioData_Injected(intPtr);
		}

		public bool GetData(Span<float> data, int offsetSamples)
		{
			if (channels <= 0)
			{
				Debug.Log("AudioClip.GetData failed; AudioClip " + GetName() + " contains no data");
				return false;
			}
			return GetData(this, data, offsetSamples);
		}

		public bool GetData(float[] data, int offsetSamples)
		{
			if (channels <= 0)
			{
				Debug.Log("AudioClip.GetData failed; AudioClip " + GetName() + " contains no data");
				return false;
			}
			return GetData(this, MemoryExtensions.AsSpan(data), offsetSamples);
		}

		public bool SetData(float[] data, int offsetSamples)
		{
			if (channels <= 0)
			{
				Debug.Log("AudioClip.SetData failed; AudioClip " + GetName() + " contains no data");
				return false;
			}
			if (offsetSamples < 0 || offsetSamples >= samples)
			{
				throw new ArgumentException("AudioClip.SetData failed; invalid offsetSamples");
			}
			if (data == null || data.Length == 0)
			{
				throw new ArgumentException("AudioClip.SetData failed; invalid data");
			}
			return SetData(this, MemoryExtensions.AsSpan(data), offsetSamples);
		}

		public bool SetData(ReadOnlySpan<float> data, int offsetSamples)
		{
			if (channels <= 0)
			{
				Debug.Log("AudioClip.SetData failed; AudioClip " + GetName() + " contains no data");
				return false;
			}
			if (offsetSamples < 0 || offsetSamples >= samples)
			{
				throw new ArgumentException("AudioClip.SetData failed; invalid offsetSamples");
			}
			if (data.Length == 0)
			{
				throw new ArgumentException("AudioClip.SetData failed; invalid data");
			}
			return SetData(this, data, offsetSamples);
		}

		[Obsolete("The _3D argument of AudioClip is deprecated. Use the spatialBlend property of AudioSource instead to morph between 2D and 3D playback.")]
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream)
		{
			return Create(name, lengthSamples, channels, frequency, stream);
		}

		[Obsolete("The _3D argument of AudioClip is deprecated. Use the spatialBlend property of AudioSource instead to morph between 2D and 3D playback.")]
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream, PCMReaderCallback pcmreadercallback)
		{
			return Create(name, lengthSamples, channels, frequency, stream, pcmreadercallback, null);
		}

		[Obsolete("The _3D argument of AudioClip is deprecated. Use the spatialBlend property of AudioSource instead to morph between 2D and 3D playback.")]
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream, PCMReaderCallback pcmreadercallback, PCMSetPositionCallback pcmsetpositioncallback)
		{
			return Create(name, lengthSamples, channels, frequency, stream, pcmreadercallback, pcmsetpositioncallback);
		}

		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream)
		{
			return Create(name, lengthSamples, channels, frequency, stream, null, null);
		}

		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream, PCMReaderCallback pcmreadercallback)
		{
			return Create(name, lengthSamples, channels, frequency, stream, pcmreadercallback, null);
		}

		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream, PCMReaderCallback pcmreadercallback, PCMSetPositionCallback pcmsetpositioncallback)
		{
			if (name == null)
			{
				throw new NullReferenceException();
			}
			if (lengthSamples <= 0)
			{
				throw new ArgumentException("Length of created clip must be larger than 0");
			}
			if (channels <= 0)
			{
				throw new ArgumentException("Number of channels in created clip must be greater than 0");
			}
			if (frequency <= 0)
			{
				throw new ArgumentException("Frequency in created clip must be greater than 0");
			}
			AudioClip audioClip = Construct_Internal();
			if (pcmreadercallback != null)
			{
				audioClip.m_PCMReaderCallback += pcmreadercallback;
			}
			if (pcmsetpositioncallback != null)
			{
				audioClip.m_PCMSetPositionCallback += pcmsetpositioncallback;
			}
			audioClip.CreateUserSound(name, lengthSamples, channels, frequency, stream);
			return audioClip;
		}

		[RequiredByNativeCode]
		private void InvokePCMReaderCallback_Internal(float[] data)
		{
			if (this.m_PCMReaderCallback != null)
			{
				this.m_PCMReaderCallback(data);
			}
		}

		[RequiredByNativeCode]
		private void InvokePCMSetPositionCallback_Internal(int position)
		{
			if (this.m_PCMSetPositionCallback != null)
			{
				this.m_PCMSetPositionCallback(position);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetData_Injected(IntPtr clip, ref ManagedSpanWrapper data, int samplesOffset);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetData_Injected(IntPtr clip, ref ManagedSpanWrapper data, int samplesOffset);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Construct_Internal_Injected();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetName_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CreateUserSound_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, int lengthSamples, int channels, int frequency, bool stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_length_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_samples_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_channels_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_frequency_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isReadyToPlay_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioClipLoadType get_loadType_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool LoadAudioData_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool UnloadAudioData_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_preloadAudioData_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_ambisonic_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_loadInBackground_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioDataLoadState get_loadState_Injected(IntPtr _unity_self);
	}
	public class AudioBehaviour : Behaviour
	{
	}
	[StaticAccessor("AudioListenerBindings", StaticAccessorType.DoubleColon)]
	[RequireComponent(typeof(Transform))]
	public sealed class AudioListener : AudioBehaviour
	{
		public static extern float volume
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		[NativeProperty("ListenerPause")]
		public static extern bool pause
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public AudioVelocityUpdateMode velocityUpdateMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_velocityUpdateMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_velocityUpdateMode_Injected(intPtr, value);
			}
		}

		[NativeThrows]
		private unsafe static void GetOutputDataHelper([Out] float[] samples, int channel)
		{
			//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			BlittableArrayWrapper samples2 = default(BlittableArrayWrapper);
			try
			{
				if (samples != null)
				{
					fixed (float[] array = samples)
					{
						if (array.Length != 0)
						{
							samples2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						GetOutputDataHelper_Injected(out samples2, channel);
						return;
					}
				}
				GetOutputDataHelper_Injected(out samples2, channel);
			}
			finally
			{
				samples2.Unmarshal(ref array);
			}
		}

		[NativeThrows]
		private unsafe static void GetSpectrumDataHelper([Out] float[] samples, int channel, FFTWindow window)
		{
			//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			BlittableArrayWrapper samples2 = default(BlittableArrayWrapper);
			try
			{
				if (samples != null)
				{
					fixed (float[] array = samples)
					{
						if (array.Length != 0)
						{
							samples2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						GetSpectrumDataHelper_Injected(out samples2, channel, window);
						return;
					}
				}
				GetSpectrumDataHelper_Injected(out samples2, channel, window);
			}
			finally
			{
				samples2.Unmarshal(ref array);
			}
		}

		[Obsolete("GetOutputData returning a float[] is deprecated, use GetOutputData and pass a pre allocated array instead.")]
		public static float[] GetOutputData(int numSamples, int channel)
		{
			float[] array = new float[numSamples];
			GetOutputDataHelper(array, channel);
			return array;
		}

		public static void GetOutputData(float[] samples, int channel)
		{
			GetOutputDataHelper(samples, channel);
		}

		[Obsolete("GetSpectrumData returning a float[] is deprecated, use GetSpectrumData and pass a pre allocated array instead.")]
		public static float[] GetSpectrumData(int numSamples, int channel, FFTWindow window)
		{
			float[] array = new float[numSamples];
			GetSpectrumDataHelper(array, channel, window);
			return array;
		}

		public static void GetSpectrumData(float[] samples, int channel, FFTWindow window)
		{
			GetSpectrumDataHelper(samples, channel, window);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetOutputDataHelper_Injected(out BlittableArrayWrapper samples, int channel);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSpectrumDataHelper_Injected(out BlittableArrayWrapper samples, int channel, FFTWindow window);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioVelocityUpdateMode get_velocityUpdateMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_velocityUpdateMode_Injected(IntPtr _unity_self, AudioVelocityUpdateMode value);
	}
	[StaticAccessor("AudioSourceBindings", StaticAccessorType.DoubleColon)]
	[RequireComponent(typeof(Transform))]
	public sealed class AudioSource : AudioBehaviour
	{
		public float volume
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_volume_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_volume_Injected(intPtr, value);
			}
		}

		public float pitch
		{
			get
			{
				return GetPitch(this);
			}
			set
			{
				SetPitch(this, value);
			}
		}

		[NativeProperty("SecPosition")]
		public float time
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_time_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_time_Injected(intPtr, value);
			}
		}

		[NativeProperty("SamplePosition")]
		public int timeSamples
		{
			[NativeMethod(IsThreadSafe = true)]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_timeSamples_Injected(intPtr);
			}
			[NativeMethod(IsThreadSafe = true)]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_timeSamples_Injected(intPtr, value);
			}
		}

		public AudioClip clip
		{
			get
			{
				return resource as AudioClip;
			}
			set
			{
				resource = value;
			}
		}

		public AudioResource resource
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<AudioResource>(get_resource_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_resource_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public AudioMixerGroup outputAudioMixerGroup
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<AudioMixerGroup>(get_outputAudioMixerGroup_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_outputAudioMixerGroup_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public bool isPlaying
		{
			[NativeName("IsPlayingScripting")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isPlaying_Injected(intPtr);
			}
		}

		internal bool isContainerPlaying
		{
			[NativeName("IsContainerPlaying")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isContainerPlaying_Injected(intPtr);
			}
		}

		internal ActivePlayable[] containerActivePlayables
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_containerActivePlayables_Injected(intPtr);
			}
		}

		public bool isVirtual
		{
			[NativeName("GetLastVirtualState")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isVirtual_Injected(intPtr);
			}
		}

		public bool loop
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_loop_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_loop_Injected(intPtr, value);
			}
		}

		public bool ignoreListenerVolume
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_ignoreListenerVolume_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_ignoreListenerVolume_Injected(intPtr, value);
			}
		}

		public bool playOnAwake
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_playOnAwake_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_playOnAwake_Injected(intPtr, value);
			}
		}

		public bool ignoreListenerPause
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_ignoreListenerPause_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_ignoreListenerPause_Injected(intPtr, value);
			}
		}

		public AudioVelocityUpdateMode velocityUpdateMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_velocityUpdateMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_velocityUpdateMode_Injected(intPtr, value);
			}
		}

		[NativeProperty("StereoPan")]
		public float panStereo
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_panStereo_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_panStereo_Injected(intPtr, value);
			}
		}

		[NativeProperty("SpatialBlendMix")]
		public float spatialBlend
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_spatialBlend_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_spatialBlend_Injected(intPtr, value);
			}
		}

		public bool spatialize
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_spatialize_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_spatialize_Injected(intPtr, value);
			}
		}

		public bool spatializePostEffects
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_spatializePostEffects_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_spatializePostEffects_Injected(intPtr, value);
			}
		}

		public float reverbZoneMix
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_reverbZoneMix_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_reverbZoneMix_Injected(intPtr, value);
			}
		}

		public bool bypassEffects
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_bypassEffects_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_bypassEffects_Injected(intPtr, value);
			}
		}

		public bool bypassListenerEffects
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_bypassListenerEffects_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_bypassListenerEffects_Injected(intPtr, value);
			}
		}

		public bool bypassReverbZones
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_bypassReverbZones_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_bypassReverbZones_Injected(intPtr, value);
			}
		}

		public float dopplerLevel
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_dopplerLevel_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_dopplerLevel_Injected(intPtr, value);
			}
		}

		public float spread
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_spread_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_spread_Injected(intPtr, value);
			}
		}

		public int priority
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_priority_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_priority_Injected(intPtr, value);
			}
		}

		public bool mute
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_mute_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_mute_Injected(intPtr, value);
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

		public AudioRolloffMode rolloffMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_rolloffMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rolloffMode_Injected(intPtr, value);
			}
		}

		[Obsolete("minVolume is not supported anymore. Use min-, maxDistance and rolloffMode instead.", true)]
		public float minVolume
		{
			get
			{
				Debug.LogError("minVolume is not supported anymore. Use min-, maxDistance and rolloffMode instead.");
				return 0f;
			}
			set
			{
				Debug.LogError("minVolume is not supported anymore. Use min-, maxDistance and rolloffMode instead.");
			}
		}

		[Obsolete("maxVolume is not supported anymore. Use min-, maxDistance and rolloffMode instead.", true)]
		public float maxVolume
		{
			get
			{
				Debug.LogError("maxVolume is not supported anymore. Use min-, maxDistance and rolloffMode instead.");
				return 0f;
			}
			set
			{
				Debug.LogError("maxVolume is not supported anymore. Use min-, maxDistance and rolloffMode instead.");
			}
		}

		[Obsolete("rolloffFactor is not supported anymore. Use min-, maxDistance and rolloffMode instead.", true)]
		public float rolloffFactor
		{
			get
			{
				Debug.LogError("rolloffFactor is not supported anymore. Use min-, maxDistance and rolloffMode instead.");
				return 0f;
			}
			set
			{
				Debug.LogError("rolloffFactor is not supported anymore. Use min-, maxDistance and rolloffMode instead.");
			}
		}

		private static float GetPitch([NotNull] AudioSource source)
		{
			if ((object)source == null)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(source);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			return GetPitch_Injected(intPtr);
		}

		private static void SetPitch([NotNull] AudioSource source, float pitch)
		{
			if ((object)source == null)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(source);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			SetPitch_Injected(intPtr, pitch);
		}

		private static void PlayHelper([NotNull] AudioSource source, ulong delay)
		{
			if ((object)source == null)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(source);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			PlayHelper_Injected(intPtr, delay);
		}

		private void Play(double delay)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Play_Injected(intPtr, delay);
		}

		private static void PlayOneShotHelper([NotNull] AudioSource source, [NotNull] AudioClip clip, float volumeScale)
		{
			if ((object)source == null)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			if ((object)clip == null)
			{
				ThrowHelper.ThrowArgumentNullException(clip, "clip");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(source);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(clip);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(clip, "clip");
			}
			PlayOneShotHelper_Injected(intPtr, intPtr2, volumeScale);
		}

		private void Stop(bool stopOneShots)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Stop_Injected(intPtr, stopOneShots);
		}

		[NativeThrows]
		private static void SetCustomCurveHelper([NotNull] AudioSource source, AudioSourceCurveType type, AnimationCurve curve)
		{
			if ((object)source == null)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(source);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			SetCustomCurveHelper_Injected(intPtr, type, (curve == null) ? ((IntPtr)0) : AnimationCurve.BindingsMarshaller.ConvertToNative(curve));
		}

		private static AnimationCurve GetCustomCurveHelper([NotNull] AudioSource source, AudioSourceCurveType type)
		{
			if ((object)source == null)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(source);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			IntPtr customCurveHelper_Injected = GetCustomCurveHelper_Injected(intPtr, type);
			return (customCurveHelper_Injected == (IntPtr)0) ? null : AnimationCurve.BindingsMarshaller.ConvertToManaged(customCurveHelper_Injected);
		}

		private unsafe static void GetOutputDataHelper([NotNull] AudioSource source, [Out] float[] samples, int channel)
		{
			//The blocks IL_003f are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			if ((object)source == null)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			BlittableArrayWrapper samples2 = default(BlittableArrayWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(source);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowArgumentNullException(source, "source");
				}
				if (samples != null)
				{
					fixed (float[] array = samples)
					{
						if (array.Length != 0)
						{
							samples2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						GetOutputDataHelper_Injected(intPtr, out samples2, channel);
						return;
					}
				}
				GetOutputDataHelper_Injected(intPtr, out samples2, channel);
			}
			finally
			{
				samples2.Unmarshal(ref array);
			}
		}

		[NativeThrows]
		private unsafe static void GetSpectrumDataHelper([NotNull] AudioSource source, [Out] float[] samples, int channel, FFTWindow window)
		{
			//The blocks IL_003f are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			if ((object)source == null)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			BlittableArrayWrapper samples2 = default(BlittableArrayWrapper);
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(source);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowArgumentNullException(source, "source");
				}
				if (samples != null)
				{
					fixed (float[] array = samples)
					{
						if (array.Length != 0)
						{
							samples2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						GetSpectrumDataHelper_Injected(intPtr, out samples2, channel, window);
						return;
					}
				}
				GetSpectrumDataHelper_Injected(intPtr, out samples2, channel, window);
			}
			finally
			{
				samples2.Unmarshal(ref array);
			}
		}

		[ExcludeFromDocs]
		public void Play()
		{
			PlayHelper(this, 0uL);
		}

		public void Play([UnityEngine.Internal.DefaultValue("0")] ulong delay)
		{
			PlayHelper(this, delay);
		}

		public void PlayDelayed(float delay)
		{
			Play((delay < 0f) ? 0.0 : (0.0 - (double)delay));
		}

		public void PlayScheduled(double time)
		{
			Play((time < 0.0) ? 0.0 : time);
		}

		[ExcludeFromDocs]
		public void PlayOneShot(AudioClip clip)
		{
			PlayOneShot(clip, 1f);
		}

		public void PlayOneShot(AudioClip clip, [UnityEngine.Internal.DefaultValue("1.0F")] float volumeScale)
		{
			if (clip == null)
			{
				Debug.LogWarning("PlayOneShot was called with a null AudioClip.");
			}
			else
			{
				PlayOneShotHelper(this, clip, volumeScale);
			}
		}

		public void SetScheduledStartTime(double time)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetScheduledStartTime_Injected(intPtr, time);
		}

		public void SetScheduledEndTime(double time)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetScheduledEndTime_Injected(intPtr, time);
		}

		public void Stop()
		{
			Stop(stopOneShots: true);
		}

		public void Pause()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Pause_Injected(intPtr);
		}

		public void UnPause()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			UnPause_Injected(intPtr);
		}

		internal void SkipToNextElementIfHasContainer()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SkipToNextElementIfHasContainer_Injected(intPtr);
		}

		[ExcludeFromDocs]
		public static void PlayClipAtPoint(AudioClip clip, Vector3 position)
		{
			PlayClipAtPoint(clip, position, 1f);
		}

		public static void PlayClipAtPoint(AudioClip clip, Vector3 position, [UnityEngine.Internal.DefaultValue("1.0F")] float volume)
		{
			GameObject gameObject = new GameObject("One shot audio");
			gameObject.transform.position = position;
			AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
			audioSource.clip = clip;
			audioSource.spatialBlend = 1f;
			audioSource.volume = volume;
			audioSource.Play();
			Object.Destroy(gameObject, clip.length * ((Time.timeScale < 0.01f) ? 0.01f : Time.timeScale));
		}

		public void SetCustomCurve(AudioSourceCurveType type, AnimationCurve curve)
		{
			SetCustomCurveHelper(this, type, curve);
		}

		public AnimationCurve GetCustomCurve(AudioSourceCurveType type)
		{
			return GetCustomCurveHelper(this, type);
		}

		[Obsolete("GetOutputData returning a float[] is deprecated, use GetOutputData and pass a pre allocated array instead.")]
		public float[] GetOutputData(int numSamples, int channel)
		{
			float[] array = new float[numSamples];
			GetOutputDataHelper(this, array, channel);
			return array;
		}

		public void GetOutputData(float[] samples, int channel)
		{
			GetOutputDataHelper(this, samples, channel);
		}

		[Obsolete("GetSpectrumData returning a float[] is deprecated, use GetSpectrumData and pass a pre allocated array instead.")]
		public float[] GetSpectrumData(int numSamples, int channel, FFTWindow window)
		{
			float[] array = new float[numSamples];
			GetSpectrumDataHelper(this, array, channel, window);
			return array;
		}

		public void GetSpectrumData(float[] samples, int channel, FFTWindow window)
		{
			GetSpectrumDataHelper(this, samples, channel, window);
		}

		public bool SetSpatializerFloat(int index, float value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetSpatializerFloat_Injected(intPtr, index, value);
		}

		public bool GetSpatializerFloat(int index, out float value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetSpatializerFloat_Injected(intPtr, index, out value);
		}

		public bool GetAmbisonicDecoderFloat(int index, out float value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAmbisonicDecoderFloat_Injected(intPtr, index, out value);
		}

		public bool SetAmbisonicDecoderFloat(int index, float value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetAmbisonicDecoderFloat_Injected(intPtr, index, value);
		}

		internal float GetAudioRandomContainerRuntimeMeterValue()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAudioRandomContainerRuntimeMeterValue_Injected(intPtr);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetPitch_Injected(IntPtr source);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetPitch_Injected(IntPtr source, float pitch);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PlayHelper_Injected(IntPtr source, ulong delay);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Play_Injected(IntPtr _unity_self, double delay);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PlayOneShotHelper_Injected(IntPtr source, IntPtr clip, float volumeScale);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Stop_Injected(IntPtr _unity_self, bool stopOneShots);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetCustomCurveHelper_Injected(IntPtr source, AudioSourceCurveType type, IntPtr curve);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetCustomCurveHelper_Injected(IntPtr source, AudioSourceCurveType type);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetOutputDataHelper_Injected(IntPtr source, out BlittableArrayWrapper samples, int channel);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSpectrumDataHelper_Injected(IntPtr source, out BlittableArrayWrapper samples, int channel, FFTWindow window);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_volume_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_volume_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_time_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_time_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_timeSamples_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_timeSamples_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_resource_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_resource_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_outputAudioMixerGroup_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_outputAudioMixerGroup_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetScheduledStartTime_Injected(IntPtr _unity_self, double time);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetScheduledEndTime_Injected(IntPtr _unity_self, double time);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Pause_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UnPause_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SkipToNextElementIfHasContainer_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isPlaying_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isContainerPlaying_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ActivePlayable[] get_containerActivePlayables_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isVirtual_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_loop_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_loop_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_ignoreListenerVolume_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_ignoreListenerVolume_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_playOnAwake_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_playOnAwake_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_ignoreListenerPause_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_ignoreListenerPause_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioVelocityUpdateMode get_velocityUpdateMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_velocityUpdateMode_Injected(IntPtr _unity_self, AudioVelocityUpdateMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_panStereo_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_panStereo_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_spatialBlend_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_spatialBlend_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_spatialize_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_spatialize_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_spatializePostEffects_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_spatializePostEffects_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_reverbZoneMix_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_reverbZoneMix_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_bypassEffects_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_bypassEffects_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_bypassListenerEffects_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_bypassListenerEffects_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_bypassReverbZones_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_bypassReverbZones_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_dopplerLevel_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_dopplerLevel_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_spread_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_spread_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_priority_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_priority_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_mute_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_mute_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_minDistance_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_minDistance_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_maxDistance_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_maxDistance_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioRolloffMode get_rolloffMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rolloffMode_Injected(IntPtr _unity_self, AudioRolloffMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetSpatializerFloat_Injected(IntPtr _unity_self, int index, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetSpatializerFloat_Injected(IntPtr _unity_self, int index, out float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetAmbisonicDecoderFloat_Injected(IntPtr _unity_self, int index, out float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetAmbisonicDecoderFloat_Injected(IntPtr _unity_self, int index, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetAudioRandomContainerRuntimeMeterValue_Injected(IntPtr _unity_self);
	}
	[NativeHeader("Modules/Audio/Public/AudioReverbZone.h")]
	[RequireComponent(typeof(Transform))]
	public sealed class AudioReverbZone : Behaviour
	{
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

		public AudioReverbPreset reverbPreset
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_reverbPreset_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_reverbPreset_Injected(intPtr, value);
			}
		}

		public int room
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_room_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_room_Injected(intPtr, value);
			}
		}

		public int roomHF
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_roomHF_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_roomHF_Injected(intPtr, value);
			}
		}

		public int roomLF
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_roomLF_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_roomLF_Injected(intPtr, value);
			}
		}

		public float decayTime
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_decayTime_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_decayTime_Injected(intPtr, value);
			}
		}

		public float decayHFRatio
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_decayHFRatio_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_decayHFRatio_Injected(intPtr, value);
			}
		}

		public int reflections
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_reflections_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_reflections_Injected(intPtr, value);
			}
		}

		public float reflectionsDelay
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_reflectionsDelay_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_reflectionsDelay_Injected(intPtr, value);
			}
		}

		public int reverb
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_reverb_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_reverb_Injected(intPtr, value);
			}
		}

		public float reverbDelay
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_reverbDelay_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_reverbDelay_Injected(intPtr, value);
			}
		}

		public float HFReference
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_HFReference_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_HFReference_Injected(intPtr, value);
			}
		}

		public float LFReference
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_LFReference_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_LFReference_Injected(intPtr, value);
			}
		}

		[Obsolete("Warning! roomRolloffFactor is no longer supported.")]
		public float roomRolloffFactor
		{
			get
			{
				Debug.LogWarning("Warning! roomRolloffFactor is no longer supported.");
				return 10f;
			}
			set
			{
				Debug.LogWarning("Warning! roomRolloffFactor is no longer supported.");
			}
		}

		public float diffusion
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_diffusion_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_diffusion_Injected(intPtr, value);
			}
		}

		public float density
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_density_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_density_Injected(intPtr, value);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_minDistance_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_minDistance_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_maxDistance_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_maxDistance_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioReverbPreset get_reverbPreset_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_reverbPreset_Injected(IntPtr _unity_self, AudioReverbPreset value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_room_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_room_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_roomHF_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_roomHF_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_roomLF_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_roomLF_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_decayTime_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_decayTime_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_decayHFRatio_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_decayHFRatio_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_reflections_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_reflections_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_reflectionsDelay_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_reflectionsDelay_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_reverb_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_reverb_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_reverbDelay_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_reverbDelay_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_HFReference_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_HFReference_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_LFReference_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_LFReference_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_diffusion_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_diffusion_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_density_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_density_Injected(IntPtr _unity_self, float value);
	}
	[RequireComponent(typeof(AudioBehaviour))]
	public sealed class AudioLowPassFilter : Behaviour
	{
		public AnimationCurve customCutoffCurve
		{
			get
			{
				return GetCustomLowpassLevelCurveCopy();
			}
			set
			{
				SetCustomLowpassLevelCurveHelper(this, value);
			}
		}

		public float cutoffFrequency
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_cutoffFrequency_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_cutoffFrequency_Injected(intPtr, value);
			}
		}

		public float lowpassResonanceQ
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_lowpassResonanceQ_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_lowpassResonanceQ_Injected(intPtr, value);
			}
		}

		private AnimationCurve GetCustomLowpassLevelCurveCopy()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr customLowpassLevelCurveCopy_Injected = GetCustomLowpassLevelCurveCopy_Injected(intPtr);
			return (customLowpassLevelCurveCopy_Injected == (IntPtr)0) ? null : AnimationCurve.BindingsMarshaller.ConvertToManaged(customLowpassLevelCurveCopy_Injected);
		}

		[NativeMethod(Name = "AudioLowPassFilterBindings::SetCustomLowpassLevelCurveHelper", IsFreeFunction = true)]
		[NativeThrows]
		private static void SetCustomLowpassLevelCurveHelper([NotNull] AudioLowPassFilter source, AnimationCurve curve)
		{
			if ((object)source == null)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(source);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			SetCustomLowpassLevelCurveHelper_Injected(intPtr, (curve == null) ? ((IntPtr)0) : AnimationCurve.BindingsMarshaller.ConvertToNative(curve));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetCustomLowpassLevelCurveCopy_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetCustomLowpassLevelCurveHelper_Injected(IntPtr source, IntPtr curve);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_cutoffFrequency_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_cutoffFrequency_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_lowpassResonanceQ_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_lowpassResonanceQ_Injected(IntPtr _unity_self, float value);
	}
	[RequireComponent(typeof(AudioBehaviour))]
	public sealed class AudioHighPassFilter : Behaviour
	{
		public float cutoffFrequency
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_cutoffFrequency_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_cutoffFrequency_Injected(intPtr, value);
			}
		}

		public float highpassResonanceQ
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_highpassResonanceQ_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_highpassResonanceQ_Injected(intPtr, value);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_cutoffFrequency_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_cutoffFrequency_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_highpassResonanceQ_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_highpassResonanceQ_Injected(IntPtr _unity_self, float value);
	}
	[RequireComponent(typeof(AudioBehaviour))]
	public sealed class AudioDistortionFilter : Behaviour
	{
		public float distortionLevel
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_distortionLevel_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_distortionLevel_Injected(intPtr, value);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_distortionLevel_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_distortionLevel_Injected(IntPtr _unity_self, float value);
	}
	[RequireComponent(typeof(AudioBehaviour))]
	public sealed class AudioEchoFilter : Behaviour
	{
		public float delay
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_delay_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_delay_Injected(intPtr, value);
			}
		}

		public float decayRatio
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_decayRatio_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_decayRatio_Injected(intPtr, value);
			}
		}

		public float dryMix
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_dryMix_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_dryMix_Injected(intPtr, value);
			}
		}

		public float wetMix
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_wetMix_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_wetMix_Injected(intPtr, value);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_delay_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_delay_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_decayRatio_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_decayRatio_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_dryMix_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_dryMix_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_wetMix_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_wetMix_Injected(IntPtr _unity_self, float value);
	}
	[RequireComponent(typeof(AudioBehaviour))]
	public sealed class AudioChorusFilter : Behaviour
	{
		public float dryMix
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_dryMix_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_dryMix_Injected(intPtr, value);
			}
		}

		public float wetMix1
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_wetMix1_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_wetMix1_Injected(intPtr, value);
			}
		}

		public float wetMix2
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_wetMix2_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_wetMix2_Injected(intPtr, value);
			}
		}

		public float wetMix3
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_wetMix3_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_wetMix3_Injected(intPtr, value);
			}
		}

		public float delay
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_delay_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_delay_Injected(intPtr, value);
			}
		}

		public float rate
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_rate_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rate_Injected(intPtr, value);
			}
		}

		public float depth
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_depth_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_depth_Injected(intPtr, value);
			}
		}

		[Obsolete("Warning! Feedback is deprecated. This property does nothing.")]
		public float feedback
		{
			get
			{
				Debug.LogWarning("Warning! Feedback is deprecated. This property does nothing.");
				return 0f;
			}
			set
			{
				Debug.LogWarning("Warning! Feedback is deprecated. This property does nothing.");
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_dryMix_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_dryMix_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_wetMix1_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_wetMix1_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_wetMix2_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_wetMix2_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_wetMix3_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_wetMix3_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_delay_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_delay_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_rate_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rate_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_depth_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_depth_Injected(IntPtr _unity_self, float value);
	}
	[RequireComponent(typeof(AudioBehaviour))]
	public sealed class AudioReverbFilter : Behaviour
	{
		public AudioReverbPreset reverbPreset
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_reverbPreset_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_reverbPreset_Injected(intPtr, value);
			}
		}

		public float dryLevel
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_dryLevel_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_dryLevel_Injected(intPtr, value);
			}
		}

		public float room
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_room_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_room_Injected(intPtr, value);
			}
		}

		public float roomHF
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_roomHF_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_roomHF_Injected(intPtr, value);
			}
		}

		[Obsolete("Warning! roomRolloffFactor is no longer supported.")]
		public float roomRolloffFactor
		{
			get
			{
				Debug.LogWarning("Warning! roomRolloffFactor is no longer supported.");
				return 10f;
			}
			set
			{
				Debug.LogWarning("Warning! roomRolloffFactor is no longer supported.");
			}
		}

		public float decayTime
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_decayTime_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_decayTime_Injected(intPtr, value);
			}
		}

		public float decayHFRatio
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_decayHFRatio_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_decayHFRatio_Injected(intPtr, value);
			}
		}

		public float reflectionsLevel
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_reflectionsLevel_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_reflectionsLevel_Injected(intPtr, value);
			}
		}

		public float reflectionsDelay
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_reflectionsDelay_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_reflectionsDelay_Injected(intPtr, value);
			}
		}

		public float reverbLevel
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_reverbLevel_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_reverbLevel_Injected(intPtr, value);
			}
		}

		public float reverbDelay
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_reverbDelay_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_reverbDelay_Injected(intPtr, value);
			}
		}

		public float diffusion
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_diffusion_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_diffusion_Injected(intPtr, value);
			}
		}

		public float density
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_density_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_density_Injected(intPtr, value);
			}
		}

		public float hfReference
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_hfReference_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_hfReference_Injected(intPtr, value);
			}
		}

		public float roomLF
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_roomLF_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_roomLF_Injected(intPtr, value);
			}
		}

		public float lfReference
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_lfReference_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_lfReference_Injected(intPtr, value);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioReverbPreset get_reverbPreset_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_reverbPreset_Injected(IntPtr _unity_self, AudioReverbPreset value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_dryLevel_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_dryLevel_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_room_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_room_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_roomHF_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_roomHF_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_decayTime_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_decayTime_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_decayHFRatio_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_decayHFRatio_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_reflectionsLevel_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_reflectionsLevel_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_reflectionsDelay_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_reflectionsDelay_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_reverbLevel_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_reverbLevel_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_reverbDelay_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_reverbDelay_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_diffusion_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_diffusion_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_density_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_density_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_hfReference_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_hfReference_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_roomLF_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_roomLF_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_lfReference_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_lfReference_Injected(IntPtr _unity_self, float value);
	}
	[StaticAccessor("GetAudioManager()", StaticAccessorType.Dot)]
	public sealed class Microphone
	{
		public static extern string[] devices
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeName("GetRecordDevices")]
			get;
		}

		internal static extern bool isAnyDeviceRecording
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeName("IsAnyRecordDeviceActive")]
			get;
		}

		[NativeMethod(IsThreadSafe = true)]
		private unsafe static int GetMicrophoneDeviceIDFromName(string name)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetMicrophoneDeviceIDFromName_Injected(ref managedSpanWrapper);
					}
				}
				return GetMicrophoneDeviceIDFromName_Injected(ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		private static AudioClip StartRecord(int deviceID, bool loop, float lengthSec, int frequency)
		{
			return Unmarshal.UnmarshalUnityObject<AudioClip>(StartRecord_Injected(deviceID, loop, lengthSec, frequency));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void EndRecord(int deviceID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsRecording(int deviceID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern int GetRecordPosition(int deviceID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetDeviceCaps(int deviceID, out int minFreq, out int maxFreq);

		public static AudioClip Start(string deviceName, bool loop, int lengthSec, int frequency)
		{
			int microphoneDeviceIDFromName = GetMicrophoneDeviceIDFromName(deviceName);
			if (microphoneDeviceIDFromName == -1)
			{
				throw new ArgumentException("Couldn't acquire device ID for device name " + deviceName);
			}
			if (lengthSec <= 0)
			{
				throw new ArgumentException("Length of recording must be greater than zero seconds (was: " + lengthSec + " seconds)");
			}
			if (lengthSec > 3600)
			{
				throw new ArgumentException("Length of recording must be less than one hour (was: " + lengthSec + " seconds)");
			}
			if (frequency <= 0)
			{
				throw new ArgumentException("Frequency of recording must be greater than zero (was: " + frequency + " Hz)");
			}
			return StartRecord(microphoneDeviceIDFromName, loop, lengthSec, frequency);
		}

		public static void End(string deviceName)
		{
			int microphoneDeviceIDFromName = GetMicrophoneDeviceIDFromName(deviceName);
			if (microphoneDeviceIDFromName != -1)
			{
				EndRecord(microphoneDeviceIDFromName);
			}
		}

		public static bool IsRecording(string deviceName)
		{
			int microphoneDeviceIDFromName = GetMicrophoneDeviceIDFromName(deviceName);
			if (microphoneDeviceIDFromName == -1)
			{
				return false;
			}
			return IsRecording(microphoneDeviceIDFromName);
		}

		public static int GetPosition(string deviceName)
		{
			int microphoneDeviceIDFromName = GetMicrophoneDeviceIDFromName(deviceName);
			if (microphoneDeviceIDFromName == -1)
			{
				return 0;
			}
			return GetRecordPosition(microphoneDeviceIDFromName);
		}

		public static void GetDeviceCaps(string deviceName, out int minFreq, out int maxFreq)
		{
			minFreq = 0;
			maxFreq = 0;
			int microphoneDeviceIDFromName = GetMicrophoneDeviceIDFromName(deviceName);
			if (microphoneDeviceIDFromName != -1)
			{
				GetDeviceCaps(microphoneDeviceIDFromName, out minFreq, out maxFreq);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetMicrophoneDeviceIDFromName_Injected(ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr StartRecord_Injected(int deviceID, bool loop, float lengthSec, int frequency);
	}
	[NativeType(Header = "Modules/Audio/Public/ScriptBindings/AudioRenderer.bindings.h")]
	public class AudioRenderer
	{
		public static bool Start()
		{
			return Internal_AudioRenderer_Start();
		}

		public static bool Stop()
		{
			return Internal_AudioRenderer_Stop();
		}

		public static int GetSampleCountForCaptureFrame()
		{
			return Internal_AudioRenderer_GetSampleCountForCaptureFrame();
		}

		internal unsafe static bool AddMixerGroupSink(AudioMixerGroup mixerGroup, NativeArray<float> buffer, bool excludeFromMix)
		{
			return Internal_AudioRenderer_AddMixerGroupSink(mixerGroup, buffer.GetUnsafePtr(), buffer.Length, excludeFromMix);
		}

		public unsafe static bool Render(NativeArray<float> buffer)
		{
			return Internal_AudioRenderer_Render(buffer.GetUnsafePtr(), buffer.Length);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_AudioRenderer_Start();

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_AudioRenderer_Stop();

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int Internal_AudioRenderer_GetSampleCountForCaptureFrame();

		internal unsafe static bool Internal_AudioRenderer_AddMixerGroupSink(AudioMixerGroup mixerGroup, void* ptr, int length, bool excludeFromMix)
		{
			return Internal_AudioRenderer_AddMixerGroupSink_Injected(Object.MarshalledUnityObject.Marshal(mixerGroup), ptr, length, excludeFromMix);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal unsafe static extern bool Internal_AudioRenderer_Render(void* ptr, int length);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern bool Internal_AudioRenderer_AddMixerGroupSink_Injected(IntPtr mixerGroup, void* ptr, int length, bool excludeFromMix);
	}
	[ExcludeFromObjectFactory]
	[Obsolete("MovieTexture is removed. Use VideoPlayer instead.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromPreset]
	public sealed class MovieTexture : Texture
	{
		[Obsolete("MovieTexture is removed. Use VideoPlayer instead.", true)]
		public AudioClip audioClip
		{
			get
			{
				FeatureRemoved();
				return null;
			}
		}

		[Obsolete("MovieTexture is removed. Use VideoPlayer instead.", true)]
		public bool loop
		{
			get
			{
				FeatureRemoved();
				return false;
			}
			set
			{
				FeatureRemoved();
			}
		}

		[Obsolete("MovieTexture is removed. Use VideoPlayer instead.", true)]
		public bool isPlaying
		{
			get
			{
				FeatureRemoved();
				return false;
			}
		}

		[Obsolete("MovieTexture is removed. Use VideoPlayer instead.", true)]
		public bool isReadyToPlay
		{
			get
			{
				FeatureRemoved();
				return false;
			}
		}

		[Obsolete("MovieTexture is removed. Use VideoPlayer instead.", true)]
		public float duration
		{
			get
			{
				FeatureRemoved();
				return 1f;
			}
		}

		private static void FeatureRemoved()
		{
			throw new Exception("MovieTexture has been removed from Unity. Use VideoPlayer instead.");
		}

		private MovieTexture()
		{
		}

		[Obsolete("MovieTexture is removed. Use VideoPlayer instead.", true)]
		public void Play()
		{
			FeatureRemoved();
		}

		[Obsolete("MovieTexture is removed. Use VideoPlayer instead.", true)]
		public void Stop()
		{
			FeatureRemoved();
		}

		[Obsolete("MovieTexture is removed. Use VideoPlayer instead.", true)]
		public void Pause()
		{
			FeatureRemoved();
		}
	}
	public enum WebCamFlags
	{
		FrontFacing = 1,
		AutoFocusPointSupported
	}
	public enum WebCamKind
	{
		Unknown,
		WideAngle,
		Telephoto,
		ColorAndDepth,
		UltraWideAngle
	}
	[UsedByNativeCode]
	public struct WebCamDevice
	{
		[NativeName("name")]
		internal string m_Name;

		[NativeName("depthCameraName")]
		internal string m_DepthCameraName;

		[NativeName("flags")]
		internal int m_Flags;

		[NativeName("kind")]
		internal WebCamKind m_Kind;

		[NativeName("resolutions")]
		internal Resolution[] m_Resolutions;

		public string name => m_Name;

		public bool isFrontFacing => (m_Flags & 1) != 0;

		public WebCamKind kind => m_Kind;

		public string depthCameraName => (m_DepthCameraName == "") ? null : m_DepthCameraName;

		public bool isAutoFocusPointSupported => (m_Flags & 2) != 0;

		public Resolution[] availableResolutions => m_Resolutions;
	}
	[NativeHeader("AudioScriptingClasses.h")]
	[NativeHeader("Runtime/Video/ScriptBindings/WebCamTexture.bindings.h")]
	[NativeHeader("Runtime/Video/BaseWebCamTexture.h")]
	public sealed class WebCamTexture : Texture
	{
		public static extern WebCamDevice[] devices
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeName("Internal_GetDevices")]
			[StaticAccessor("WebCamTextureBindings", StaticAccessorType.DoubleColon)]
			get;
		}

		public bool isPlaying
		{
			[NativeName("IsPlaying")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isPlaying_Injected(intPtr);
			}
		}

		[NativeName("Device")]
		public unsafe string deviceName
		{
			get
			{
				ManagedSpanWrapper ret = default(ManagedSpanWrapper);
				string stringAndDispose;
				try
				{
					IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
					if (intPtr == (IntPtr)0)
					{
						ThrowHelper.ThrowNullReferenceException(this);
					}
					get_deviceName_Injected(intPtr, out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
			set
			{
				//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
				try
				{
					IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
					if (intPtr == (IntPtr)0)
					{
						ThrowHelper.ThrowNullReferenceException(this);
					}
					ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
					if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
					{
						ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
						fixed (char* begin = readOnlySpan)
						{
							managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
							set_deviceName_Injected(intPtr, ref managedSpanWrapper);
							return;
						}
					}
					set_deviceName_Injected(intPtr, ref managedSpanWrapper);
				}
				finally
				{
				}
			}
		}

		public float requestedFPS
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_requestedFPS_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_requestedFPS_Injected(intPtr, value);
			}
		}

		public int requestedWidth
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_requestedWidth_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_requestedWidth_Injected(intPtr, value);
			}
		}

		public int requestedHeight
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_requestedHeight_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_requestedHeight_Injected(intPtr, value);
			}
		}

		public int videoRotationAngle
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_videoRotationAngle_Injected(intPtr);
			}
		}

		public bool videoVerticallyMirrored
		{
			[NativeName("IsVideoVerticallyMirrored")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_videoVerticallyMirrored_Injected(intPtr);
			}
		}

		public bool didUpdateThisFrame
		{
			[NativeName("DidUpdateThisFrame")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_didUpdateThisFrame_Injected(intPtr);
			}
		}

		public Vector2? autoFocusPoint
		{
			get
			{
				return (internalAutoFocusPoint.x < 0f) ? ((Vector2?)null) : new Vector2?(internalAutoFocusPoint);
			}
			set
			{
				internalAutoFocusPoint = ((!value.HasValue) ? new Vector2(-1f, -1f) : value.Value);
			}
		}

		internal Vector2 internalAutoFocusPoint
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_internalAutoFocusPoint_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_internalAutoFocusPoint_Injected(intPtr, ref value);
			}
		}

		public bool isDepth
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isDepth_Injected(intPtr);
			}
		}

		public WebCamTexture(string deviceName, int requestedWidth, int requestedHeight, int requestedFPS)
		{
			Internal_CreateWebCamTexture(this, deviceName, requestedWidth, requestedHeight, requestedFPS);
		}

		public WebCamTexture(string deviceName, int requestedWidth, int requestedHeight)
		{
			Internal_CreateWebCamTexture(this, deviceName, requestedWidth, requestedHeight, 0);
		}

		public WebCamTexture(string deviceName)
		{
			Internal_CreateWebCamTexture(this, deviceName, 0, 0, 0);
		}

		public WebCamTexture(int requestedWidth, int requestedHeight, int requestedFPS)
		{
			Internal_CreateWebCamTexture(this, "", requestedWidth, requestedHeight, requestedFPS);
		}

		public WebCamTexture(int requestedWidth, int requestedHeight)
		{
			Internal_CreateWebCamTexture(this, "", requestedWidth, requestedHeight, 0);
		}

		public WebCamTexture()
		{
			Internal_CreateWebCamTexture(this, "", 0, 0, 0);
		}

		public void Play()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Play_Injected(intPtr);
		}

		public void Pause()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Pause_Injected(intPtr);
		}

		public void Stop()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Stop_Injected(intPtr);
		}

		[FreeFunction("WebCamTextureBindings::Internal_GetPixel", HasExplicitThis = true)]
		public Color GetPixel(int x, int y)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetPixel_Injected(intPtr, x, y, out var ret);
			return ret;
		}

		public Color[] GetPixels()
		{
			return GetPixels(0, 0, width, height);
		}

		[FreeFunction("WebCamTextureBindings::Internal_GetPixels", HasExplicitThis = true, ThrowsException = true)]
		[return: Unmarshalled]
		public Color[] GetPixels(int x, int y, int blockWidth, int blockHeight)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetPixels_Injected(intPtr, x, y, blockWidth, blockHeight);
		}

		[ExcludeFromDocs]
		public Color32[] GetPixels32()
		{
			return GetPixels32(null);
		}

		[FreeFunction("WebCamTextureBindings::Internal_GetPixels32", HasExplicitThis = true, ThrowsException = true)]
		[return: Unmarshalled]
		public Color32[] GetPixels32([Unmarshalled][UnityEngine.Internal.DefaultValue("null")] Color32[] colors)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetPixels32_Injected(intPtr, colors);
		}

		[StaticAccessor("WebCamTextureBindings", StaticAccessorType.DoubleColon)]
		private unsafe static void Internal_CreateWebCamTexture([Writable] WebCamTexture self, string scriptingDevice, int requestedWidth, int requestedHeight, int maxFramerate)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(scriptingDevice, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(scriptingDevice);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						Internal_CreateWebCamTexture_Injected(self, ref managedSpanWrapper, requestedWidth, requestedHeight, maxFramerate);
						return;
					}
				}
				Internal_CreateWebCamTexture_Injected(self, ref managedSpanWrapper, requestedWidth, requestedHeight, maxFramerate);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Play_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Pause_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Stop_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isPlaying_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_deviceName_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_deviceName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_requestedFPS_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_requestedFPS_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_requestedWidth_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_requestedWidth_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_requestedHeight_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_requestedHeight_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_videoRotationAngle_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_videoVerticallyMirrored_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_didUpdateThisFrame_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetPixel_Injected(IntPtr _unity_self, int x, int y, out Color ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Color[] GetPixels_Injected(IntPtr _unity_self, int x, int y, int blockWidth, int blockHeight);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Color32[] GetPixels32_Injected(IntPtr _unity_self, [UnityEngine.Internal.DefaultValue("null")] Color32[] colors);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_internalAutoFocusPoint_Injected(IntPtr _unity_self, out Vector2 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_internalAutoFocusPoint_Injected(IntPtr _unity_self, [In] ref Vector2 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isDepth_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_CreateWebCamTexture_Injected([Writable] WebCamTexture self, ref ManagedSpanWrapper scriptingDevice, int requestedWidth, int requestedHeight, int maxFramerate);
	}
}
namespace UnityEngine.Experimental.Audio
{
	[NativeHeader("AudioScriptingClasses.h")]
	[NativeHeader("Modules/Audio/Public/ScriptBindings/AudioClipExtensions.bindings.h")]
	[NativeHeader("Modules/Audio/Public/AudioClip.h")]
	internal static class AudioClipExtensionsInternal
	{
		[NativeMethod(IsFreeFunction = true, ThrowsException = true)]
		public static uint Internal_CreateAudioClipSampleProvider([NotNull] this AudioClip audioClip, ulong start, long end, bool loop, bool allowDrop, bool loopPointIsStart = false)
		{
			if ((object)audioClip == null)
			{
				ThrowHelper.ThrowArgumentNullException(audioClip, "audioClip");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(audioClip);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(audioClip, "audioClip");
			}
			return Internal_CreateAudioClipSampleProvider_Injected(intPtr, start, end, loop, allowDrop, loopPointIsStart);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint Internal_CreateAudioClipSampleProvider_Injected(IntPtr audioClip, ulong start, long end, bool loop, bool allowDrop, bool loopPointIsStart);
	}
	[StaticAccessor("AudioSampleProviderBindings", StaticAccessorType.DoubleColon)]
	[NativeType(Header = "Modules/Audio/Public/ScriptBindings/AudioSampleProvider.bindings.h")]
	public class AudioSampleProvider : IDisposable
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate uint ConsumeSampleFramesNativeFunction(uint providerId, IntPtr interleavedSampleFrames, uint sampleFrameCount);

		public delegate void SampleFramesHandler(AudioSampleProvider provider, uint sampleFrameCount);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SampleFramesEventNativeFunction(IntPtr userData, uint providerId, uint sampleFrameCount);

		private ConsumeSampleFramesNativeFunction m_ConsumeSampleFramesNativeFunction;

		public uint id { get; private set; }

		public ushort trackIndex { get; private set; }

		public Object owner { get; private set; }

		public bool valid => InternalIsValid(id);

		public ushort channelCount { get; private set; }

		public uint sampleRate { get; private set; }

		public uint maxSampleFrameCount => InternalGetMaxSampleFrameCount(id);

		public uint availableSampleFrameCount => InternalGetAvailableSampleFrameCount(id);

		public uint freeSampleFrameCount => InternalGetFreeSampleFrameCount(id);

		public uint freeSampleFrameCountLowThreshold
		{
			get
			{
				return InternalGetFreeSampleFrameCountLowThreshold(id);
			}
			set
			{
				InternalSetFreeSampleFrameCountLowThreshold(id, value);
			}
		}

		public bool enableSampleFramesAvailableEvents
		{
			get
			{
				return InternalGetEnableSampleFramesAvailableEvents(id);
			}
			set
			{
				InternalSetEnableSampleFramesAvailableEvents(id, value);
			}
		}

		public bool enableSilencePadding
		{
			get
			{
				return InternalGetEnableSilencePadding(id);
			}
			set
			{
				InternalSetEnableSilencePadding(id, value);
			}
		}

		public static ConsumeSampleFramesNativeFunction consumeSampleFramesNativeFunction => (ConsumeSampleFramesNativeFunction)Marshal.GetDelegateForFunctionPointer(InternalGetConsumeSampleFramesNativeFunctionPtr(), typeof(ConsumeSampleFramesNativeFunction));

		public event SampleFramesHandler sampleFramesAvailable;

		public event SampleFramesHandler sampleFramesOverflow;

		[VisibleToOtherModules]
		internal static AudioSampleProvider Lookup(uint providerId, Object ownerObj, ushort trackIndex)
		{
			AudioSampleProvider audioSampleProvider = InternalGetScriptingPtr(providerId);
			if (audioSampleProvider != null || !InternalIsValid(providerId))
			{
				return audioSampleProvider;
			}
			return new AudioSampleProvider(providerId, ownerObj, trackIndex);
		}

		internal static AudioSampleProvider Create(ushort channelCount, uint sampleRate)
		{
			uint providerId = InternalCreateSampleProvider(channelCount, sampleRate);
			if (!InternalIsValid(providerId))
			{
				return null;
			}
			return new AudioSampleProvider(providerId, null, 0);
		}

		private AudioSampleProvider(uint providerId, Object ownerObj, ushort trackIdx)
		{
			owner = ownerObj;
			id = providerId;
			trackIndex = trackIdx;
			m_ConsumeSampleFramesNativeFunction = (ConsumeSampleFramesNativeFunction)Marshal.GetDelegateForFunctionPointer(InternalGetConsumeSampleFramesNativeFunctionPtr(), typeof(ConsumeSampleFramesNativeFunction));
			ushort chCount = 0;
			uint sRate = 0u;
			InternalGetFormatInfo(providerId, out chCount, out sRate);
			channelCount = chCount;
			sampleRate = sRate;
			InternalSetScriptingPtr(providerId, this);
		}

		~AudioSampleProvider()
		{
			owner = null;
			Dispose();
		}

		public void Dispose()
		{
			if (id != 0)
			{
				InternalSetScriptingPtr(id, null);
				if (owner == null)
				{
					InternalRemove(id);
				}
				id = 0u;
			}
			GC.SuppressFinalize(this);
		}

		public unsafe uint ConsumeSampleFrames(NativeArray<float> sampleFrames)
		{
			if (channelCount == 0)
			{
				return 0u;
			}
			return m_ConsumeSampleFramesNativeFunction(id, (IntPtr)sampleFrames.GetUnsafePtr(), (uint)sampleFrames.Length / (uint)channelCount);
		}

		internal unsafe uint QueueSampleFrames(NativeArray<float> sampleFrames)
		{
			if (channelCount == 0)
			{
				return 0u;
			}
			return InternalQueueSampleFrames(id, (IntPtr)sampleFrames.GetUnsafeReadOnlyPtr(), (uint)(sampleFrames.Length / channelCount));
		}

		public void SetSampleFramesAvailableNativeHandler(SampleFramesEventNativeFunction handler, IntPtr userData)
		{
			InternalSetSampleFramesAvailableNativeHandler(id, Marshal.GetFunctionPointerForDelegate(handler), userData);
		}

		public void ClearSampleFramesAvailableNativeHandler()
		{
			InternalClearSampleFramesAvailableNativeHandler(id);
		}

		public void SetSampleFramesOverflowNativeHandler(SampleFramesEventNativeFunction handler, IntPtr userData)
		{
			InternalSetSampleFramesOverflowNativeHandler(id, Marshal.GetFunctionPointerForDelegate(handler), userData);
		}

		public void ClearSampleFramesOverflowNativeHandler()
		{
			InternalClearSampleFramesOverflowNativeHandler(id);
		}

		[RequiredByNativeCode]
		private void InvokeSampleFramesAvailable(int sampleFrameCount)
		{
			if (this.sampleFramesAvailable != null)
			{
				this.sampleFramesAvailable(this, (uint)sampleFrameCount);
			}
		}

		[RequiredByNativeCode]
		private void InvokeSampleFramesOverflow(int droppedSampleFrameCount)
		{
			if (this.sampleFramesOverflow != null)
			{
				this.sampleFramesOverflow(this, (uint)droppedSampleFrameCount);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern uint InternalCreateSampleProvider(ushort channelCount, uint sampleRate);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		internal static extern void InternalRemove(uint providerId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern void InternalGetFormatInfo(uint providerId, out ushort chCount, out uint sRate);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioSampleProvider InternalGetScriptingPtr(uint providerId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern void InternalSetScriptingPtr(uint providerId, AudioSampleProvider provider);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		internal static extern bool InternalIsValid(uint providerId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern uint InternalGetMaxSampleFrameCount(uint providerId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern uint InternalGetAvailableSampleFrameCount(uint providerId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern uint InternalGetFreeSampleFrameCount(uint providerId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern uint InternalGetFreeSampleFrameCountLowThreshold(uint providerId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern void InternalSetFreeSampleFrameCountLowThreshold(uint providerId, uint sampleFrameCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern bool InternalGetEnableSampleFramesAvailableEvents(uint providerId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern void InternalSetEnableSampleFramesAvailableEvents(uint providerId, bool enable);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetSampleFramesAvailableNativeHandler(uint providerId, IntPtr handler, IntPtr userData);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalClearSampleFramesAvailableNativeHandler(uint providerId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetSampleFramesOverflowNativeHandler(uint providerId, IntPtr handler, IntPtr userData);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalClearSampleFramesOverflowNativeHandler(uint providerId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern bool InternalGetEnableSilencePadding(uint id);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern void InternalSetEnableSilencePadding(uint id, bool enabled);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern IntPtr InternalGetConsumeSampleFramesNativeFunctionPtr();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern uint InternalQueueSampleFrames(uint id, IntPtr interleavedSampleFrames, uint sampleFrameCount);
	}
	[NativeHeader("Modules/Audio/Public/ScriptBindings/AudioSampleProviderExtensions.bindings.h")]
	[StaticAccessor("AudioSampleProviderExtensionsBindings", StaticAccessorType.DoubleColon)]
	internal static class AudioSampleProviderExtensionsInternal
	{
		public static float GetSpeed(this AudioSampleProvider provider)
		{
			return InternalGetAudioSampleProviderSpeed(provider.id);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		private static extern float InternalGetAudioSampleProviderSpeed(uint providerId);
	}
	[NativeHeader("Modules/Audio/Public/ScriptBindings/AudioSourceExtensions.bindings.h")]
	[NativeHeader("Modules/Audio/Public/AudioSource.h")]
	[NativeHeader("AudioScriptingClasses.h")]
	internal static class AudioSourceExtensionsInternal
	{
		public static void RegisterSampleProvider(this AudioSource source, AudioSampleProvider provider)
		{
			Internal_RegisterSampleProviderWithAudioSource(source, provider.id);
		}

		public static void UnregisterSampleProvider(this AudioSource source, AudioSampleProvider provider)
		{
			Internal_UnregisterSampleProviderFromAudioSource(source, provider.id);
		}

		[NativeMethod(IsFreeFunction = true, ThrowsException = true)]
		private static void Internal_RegisterSampleProviderWithAudioSource([NotNull] AudioSource source, uint providerId)
		{
			if ((object)source == null)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(source);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			Internal_RegisterSampleProviderWithAudioSource_Injected(intPtr, providerId);
		}

		[NativeMethod(IsFreeFunction = true, ThrowsException = true)]
		private static void Internal_UnregisterSampleProviderFromAudioSource([NotNull] AudioSource source, uint providerId)
		{
			if ((object)source == null)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(source);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(source, "source");
			}
			Internal_UnregisterSampleProviderFromAudioSource_Injected(intPtr, providerId);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_RegisterSampleProviderWithAudioSource_Injected(IntPtr source, uint providerId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_UnregisterSampleProviderFromAudioSource_Injected(IntPtr source, uint providerId);
	}
}
namespace UnityEngine.Audio
{
	[NativeHeader("Modules/Audio/Public/AudioResource.h")]
	public abstract class AudioResource : Object
	{
		protected internal AudioResource()
		{
		}
	}
	[NativeHeader("Modules/Audio/Public/ScriptBindings/Audio.bindings.h")]
	internal sealed class AudioManagerTestProxy
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "AudioManagerTestProxy::ComputeAudibilityConsistency", IsFreeFunction = true)]
		internal static extern bool ComputeAudibilityConsistency();
	}
	[StaticAccessor("AudioClipPlayableBindings", StaticAccessorType.DoubleColon)]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[NativeHeader("Modules/Audio/Public/Director/AudioClipPlayable.h")]
	[NativeHeader("Modules/Audio/Public/ScriptBindings/AudioClipPlayable.bindings.h")]
	[RequiredByNativeCode]
	public struct AudioClipPlayable : IPlayable, IEquatable<AudioClipPlayable>
	{
		private PlayableHandle m_Handle;

		public static AudioClipPlayable Create(PlayableGraph graph, AudioClip clip, bool looping)
		{
			PlayableHandle handle = CreateHandle(graph, clip, looping);
			AudioClipPlayable audioClipPlayable = new AudioClipPlayable(handle);
			if (clip != null)
			{
				audioClipPlayable.SetDuration(clip.length);
			}
			return audioClipPlayable;
		}

		private static PlayableHandle CreateHandle(PlayableGraph graph, AudioClip clip, bool looping)
		{
			PlayableHandle handle = PlayableHandle.Null;
			if (!InternalCreateAudioClipPlayable(ref graph, clip, looping, ref handle))
			{
				return PlayableHandle.Null;
			}
			return handle;
		}

		internal AudioClipPlayable(PlayableHandle handle)
		{
			if (handle.IsValid() && !handle.IsPlayableOfType<AudioClipPlayable>())
			{
				throw new InvalidCastException("Can't set handle: the playable is not an AudioClipPlayable.");
			}
			m_Handle = handle;
		}

		public PlayableHandle GetHandle()
		{
			return m_Handle;
		}

		public static implicit operator Playable(AudioClipPlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		public static explicit operator AudioClipPlayable(Playable playable)
		{
			return new AudioClipPlayable(playable.GetHandle());
		}

		public bool Equals(AudioClipPlayable other)
		{
			return GetHandle() == other.GetHandle();
		}

		public AudioClip GetClip()
		{
			return GetClipInternal(ref m_Handle);
		}

		public void SetClip(AudioClip value)
		{
			SetClipInternal(ref m_Handle, value);
		}

		public bool GetLooped()
		{
			return GetLoopedInternal(ref m_Handle);
		}

		public void SetLooped(bool value)
		{
			SetLoopedInternal(ref m_Handle, value);
		}

		internal float GetVolume()
		{
			return GetVolumeInternal(ref m_Handle);
		}

		internal void SetVolume(float value)
		{
			if (value < 0f || value > 1f)
			{
				throw new ArgumentException("Trying to set AudioClipPlayable volume outside of range (0.0 - 1.0): " + value);
			}
			SetVolumeInternal(ref m_Handle, value);
		}

		internal float GetClipPositionSec()
		{
			return GetClipPositionSecInternal(ref m_Handle);
		}

		internal float GetStereoPan()
		{
			return GetStereoPanInternal(ref m_Handle);
		}

		internal void SetStereoPan(float value)
		{
			if (value < -1f || value > 1f)
			{
				throw new ArgumentException("Trying to set AudioClipPlayable stereo pan outside of range (-1.0 - 1.0): " + value);
			}
			SetStereoPanInternal(ref m_Handle, value);
		}

		internal float GetSpatialBlend()
		{
			return GetSpatialBlendInternal(ref m_Handle);
		}

		internal void SetSpatialBlend(float value)
		{
			if (value < 0f || value > 1f)
			{
				throw new ArgumentException("Trying to set AudioClipPlayable spatial blend outside of range (0.0 - 1.0): " + value);
			}
			SetSpatialBlendInternal(ref m_Handle, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("IsPlaying() has been deprecated. Use IsChannelPlaying() instead (UnityUpgradable) -> IsChannelPlaying()", true)]
		public bool IsPlaying()
		{
			return IsChannelPlaying();
		}

		public bool IsChannelPlaying()
		{
			return GetIsChannelPlayingInternal(ref m_Handle);
		}

		public double GetStartDelay()
		{
			return GetStartDelayInternal(ref m_Handle);
		}

		internal void SetStartDelay(double value)
		{
			SetStartDelayInternal(ref m_Handle, value);
		}

		public double GetPauseDelay()
		{
			return GetPauseDelayInternal(ref m_Handle);
		}

		internal void GetPauseDelay(double value)
		{
			double pauseDelayInternal = GetPauseDelayInternal(ref m_Handle);
			if (m_Handle.GetPlayState() == PlayState.Playing && (value < 0.05 || (pauseDelayInternal != 0.0 && pauseDelayInternal < 0.05)))
			{
				throw new ArgumentException("AudioClipPlayable.pauseDelay: Setting new delay when existing delay is too small or 0.0 (" + pauseDelayInternal + "), audio system will not be able to change in time");
			}
			SetPauseDelayInternal(ref m_Handle, value);
		}

		public void Seek(double startTime, double startDelay)
		{
			Seek(startTime, startDelay, 0.0);
		}

		public void Seek(double startTime, double startDelay, [System.ComponentModel.DefaultValue("0")] double duration)
		{
			SetStartDelayInternal(ref m_Handle, startDelay);
			if (duration > 0.0)
			{
				double num = startDelay + duration;
				if (num >= m_Handle.GetDuration())
				{
					m_Handle.SetDone(value: true);
				}
				m_Handle.SetDuration(duration + startTime);
				SetPauseDelayInternal(ref m_Handle, startDelay + duration);
			}
			else
			{
				m_Handle.SetDone(value: true);
				m_Handle.SetDuration(double.MaxValue);
				SetPauseDelayInternal(ref m_Handle, 0.0);
			}
			m_Handle.SetTime(startTime);
			m_Handle.Play();
		}

		[NativeThrows]
		private static AudioClip GetClipInternal(ref PlayableHandle hdl)
		{
			return Unmarshal.UnmarshalUnityObject<AudioClip>(GetClipInternal_Injected(ref hdl));
		}

		[NativeThrows]
		private static void SetClipInternal(ref PlayableHandle hdl, AudioClip clip)
		{
			SetClipInternal_Injected(ref hdl, Object.MarshalledUnityObject.Marshal(clip));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool GetLoopedInternal(ref PlayableHandle hdl);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetLoopedInternal(ref PlayableHandle hdl, bool looped);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern float GetVolumeInternal(ref PlayableHandle hdl);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetVolumeInternal(ref PlayableHandle hdl, float volume);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern float GetClipPositionSecInternal(ref PlayableHandle hdl);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern float GetStereoPanInternal(ref PlayableHandle hdl);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetStereoPanInternal(ref PlayableHandle hdl, float stereoPan);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern float GetSpatialBlendInternal(ref PlayableHandle hdl);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetSpatialBlendInternal(ref PlayableHandle hdl, float spatialBlend);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool GetIsChannelPlayingInternal(ref PlayableHandle hdl);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern double GetStartDelayInternal(ref PlayableHandle hdl);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetStartDelayInternal(ref PlayableHandle hdl, double delay);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern double GetPauseDelayInternal(ref PlayableHandle hdl);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetPauseDelayInternal(ref PlayableHandle hdl, double delay);

		[NativeThrows]
		private static bool InternalCreateAudioClipPlayable(ref PlayableGraph graph, AudioClip clip, bool looping, ref PlayableHandle handle)
		{
			return InternalCreateAudioClipPlayable_Injected(ref graph, Object.MarshalledUnityObject.Marshal(clip), looping, ref handle);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool ValidateType(ref PlayableHandle hdl);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetClipInternal_Injected(ref PlayableHandle hdl);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetClipInternal_Injected(ref PlayableHandle hdl, IntPtr clip);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool InternalCreateAudioClipPlayable_Injected(ref PlayableGraph graph, IntPtr clip, bool looping, ref PlayableHandle handle);
	}
	public enum AudioMixerUpdateMode
	{
		Normal,
		UnscaledTime
	}
	[ExcludeFromPreset]
	[ExcludeFromObjectFactory]
	[NativeHeader("Modules/Audio/Public/AudioMixer.h")]
	[NativeHeader("Modules/Audio/Public/ScriptBindings/AudioMixer.bindings.h")]
	public class AudioMixer : Object
	{
		[NativeProperty]
		public AudioMixerGroup outputAudioMixerGroup
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<AudioMixerGroup>(get_outputAudioMixerGroup_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_outputAudioMixerGroup_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		[NativeProperty]
		public AudioMixerUpdateMode updateMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_updateMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_updateMode_Injected(intPtr, value);
			}
		}

		internal AudioMixer()
		{
		}

		[NativeMethod("FindSnapshotFromName")]
		public unsafe AudioMixerSnapshot FindSnapshot(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			IntPtr gcHandlePtr = default(IntPtr);
			AudioMixerSnapshot result;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						gcHandlePtr = FindSnapshot_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				else
				{
					gcHandlePtr = FindSnapshot_Injected(intPtr, ref managedSpanWrapper);
				}
			}
			finally
			{
				result = Unmarshal.UnmarshalUnityObject<AudioMixerSnapshot>(gcHandlePtr);
			}
			return result;
		}

		[NativeMethod("AudioMixerBindings::FindMatchingGroups", IsFreeFunction = true, HasExplicitThis = true)]
		public unsafe AudioMixerGroup[] FindMatchingGroups(string subPath)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(subPath, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(subPath);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return FindMatchingGroups_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return FindMatchingGroups_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		internal void TransitionToSnapshot(AudioMixerSnapshot snapshot, float timeToReach)
		{
			if (snapshot == null)
			{
				throw new ArgumentException("null Snapshot passed to AudioMixer.TransitionToSnapshot of AudioMixer '" + base.name + "'");
			}
			if (snapshot.audioMixer != this)
			{
				throw new ArgumentException("Snapshot '" + snapshot.name + "' passed to AudioMixer.TransitionToSnapshot is not a snapshot from AudioMixer '" + base.name + "'");
			}
			TransitionToSnapshotInternal(snapshot, timeToReach);
		}

		[NativeMethod("TransitionToSnapshot")]
		private void TransitionToSnapshotInternal(AudioMixerSnapshot snapshot, float timeToReach)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			TransitionToSnapshotInternal_Injected(intPtr, MarshalledUnityObject.Marshal(snapshot), timeToReach);
		}

		[NativeMethod("AudioMixerBindings::TransitionToSnapshots", IsFreeFunction = true, HasExplicitThis = true, ThrowsException = true)]
		public unsafe void TransitionToSnapshots(AudioMixerSnapshot[] snapshots, float[] weights, float timeToReach)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<float> span = new Span<float>(weights);
			fixed (float* begin = span)
			{
				ManagedSpanWrapper weights2 = new ManagedSpanWrapper(begin, span.Length);
				TransitionToSnapshots_Injected(intPtr, snapshots, ref weights2, timeToReach);
			}
		}

		[NativeMethod]
		public unsafe bool SetFloat(string name, float value)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return SetFloat_Injected(intPtr, ref managedSpanWrapper, value);
					}
				}
				return SetFloat_Injected(intPtr, ref managedSpanWrapper, value);
			}
			finally
			{
			}
		}

		[NativeMethod]
		public unsafe bool ClearFloat(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return ClearFloat_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return ClearFloat_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[NativeMethod]
		public unsafe bool GetFloat(string name, out float value)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetFloat_Injected(intPtr, ref managedSpanWrapper, out value);
					}
				}
				return GetFloat_Injected(intPtr, ref managedSpanWrapper, out value);
			}
			finally
			{
			}
		}

		[NativeMethod("AudioMixerBindings::GetAbsoluteAudibilityFromGroup", HasExplicitThis = true, IsFreeFunction = true)]
		internal float GetAbsoluteAudibilityFromGroup(AudioMixerGroup group)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAbsoluteAudibilityFromGroup_Injected(intPtr, MarshalledUnityObject.Marshal(group));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_outputAudioMixerGroup_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_outputAudioMixerGroup_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr FindSnapshot_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioMixerGroup[] FindMatchingGroups_Injected(IntPtr _unity_self, ref ManagedSpanWrapper subPath);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void TransitionToSnapshotInternal_Injected(IntPtr _unity_self, IntPtr snapshot, float timeToReach);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void TransitionToSnapshots_Injected(IntPtr _unity_self, AudioMixerSnapshot[] snapshots, ref ManagedSpanWrapper weights, float timeToReach);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioMixerUpdateMode get_updateMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_updateMode_Injected(IntPtr _unity_self, AudioMixerUpdateMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetFloat_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ClearFloat_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetFloat_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, out float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetAbsoluteAudibilityFromGroup_Injected(IntPtr _unity_self, IntPtr group);
	}
	[NativeHeader("Modules/Audio/Public/AudioMixerGroup.h")]
	public class AudioMixerGroup : Object, ISubAssetNotDuplicatable
	{
		[NativeProperty]
		public AudioMixer audioMixer
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<AudioMixer>(get_audioMixer_Injected(intPtr));
			}
		}

		internal AudioMixerGroup()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_audioMixer_Injected(IntPtr _unity_self);
	}
	[NativeHeader("Modules/Audio/Public/ScriptBindings/AudioMixerPlayable.bindings.h")]
	[NativeHeader("Modules/Audio/Public/Director/AudioMixerPlayable.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[StaticAccessor("AudioMixerPlayableBindings", StaticAccessorType.DoubleColon)]
	[RequiredByNativeCode]
	public struct AudioMixerPlayable : IPlayable, IEquatable<AudioMixerPlayable>
	{
		private PlayableHandle m_Handle;

		public static AudioMixerPlayable Create(PlayableGraph graph, int inputCount = 0, bool normalizeInputVolumes = false)
		{
			PlayableHandle handle = CreateHandle(graph, inputCount, normalizeInputVolumes);
			return new AudioMixerPlayable(handle);
		}

		private static PlayableHandle CreateHandle(PlayableGraph graph, int inputCount, bool normalizeInputVolumes)
		{
			PlayableHandle handle = PlayableHandle.Null;
			if (!CreateAudioMixerPlayableInternal(ref graph, normalizeInputVolumes, ref handle))
			{
				return PlayableHandle.Null;
			}
			handle.SetInputCount(inputCount);
			return handle;
		}

		internal AudioMixerPlayable(PlayableHandle handle)
		{
			if (handle.IsValid() && !handle.IsPlayableOfType<AudioMixerPlayable>())
			{
				throw new InvalidCastException("Can't set handle: the playable is not an AudioMixerPlayable.");
			}
			m_Handle = handle;
		}

		public PlayableHandle GetHandle()
		{
			return m_Handle;
		}

		public static implicit operator Playable(AudioMixerPlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		public static explicit operator AudioMixerPlayable(Playable playable)
		{
			return new AudioMixerPlayable(playable.GetHandle());
		}

		public bool Equals(AudioMixerPlayable other)
		{
			return GetHandle() == other.GetHandle();
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool CreateAudioMixerPlayableInternal(ref PlayableGraph graph, bool normalizeInputVolumes, ref PlayableHandle handle);
	}
	[NativeHeader("Modules/Audio/Public/AudioMixerSnapshot.h")]
	public class AudioMixerSnapshot : Object, ISubAssetNotDuplicatable
	{
		[NativeProperty]
		public AudioMixer audioMixer
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<AudioMixer>(get_audioMixer_Injected(intPtr));
			}
		}

		internal AudioMixerSnapshot()
		{
		}

		public void TransitionTo(float timeToReach)
		{
			audioMixer.TransitionToSnapshot(this, timeToReach);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_audioMixer_Injected(IntPtr _unity_self);
	}
	public static class AudioPlayableBinding
	{
		public static PlayableBinding Create(string name, Object key)
		{
			return PlayableBinding.CreateInternal(name, key, typeof(AudioSource), CreateAudioOutput);
		}

		private static PlayableOutput CreateAudioOutput(PlayableGraph graph, string name)
		{
			return AudioPlayableOutput.Create(graph, name, null);
		}
	}
	[NativeHeader("Runtime/Director/Core/HPlayableOutput.h")]
	[NativeHeader("Modules/Audio/Public/ScriptBindings/AudioPlayableGraphExtensions.bindings.h")]
	[StaticAccessor("AudioPlayableGraphExtensionsBindings", StaticAccessorType.DoubleColon)]
	internal static class AudioPlayableGraphExtensions
	{
		[NativeThrows]
		internal unsafe static bool InternalCreateAudioOutput(ref PlayableGraph graph, string name, out PlayableOutputHandle handle)
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
						return InternalCreateAudioOutput_Injected(ref graph, ref managedSpanWrapper, out handle);
					}
				}
				return InternalCreateAudioOutput_Injected(ref graph, ref managedSpanWrapper, out handle);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool InternalCreateAudioOutput_Injected(ref PlayableGraph graph, ref ManagedSpanWrapper name, out PlayableOutputHandle handle);
	}
	[NativeHeader("Modules/Audio/Public/ScriptBindings/AudioPlayableOutput.bindings.h")]
	[NativeHeader("Modules/Audio/Public/Director/AudioPlayableOutput.h")]
	[NativeHeader("Modules/Audio/Public/AudioSource.h")]
	[StaticAccessor("AudioPlayableOutputBindings", StaticAccessorType.DoubleColon)]
	[RequiredByNativeCode]
	public struct AudioPlayableOutput : IPlayableOutput
	{
		private PlayableOutputHandle m_Handle;

		public static AudioPlayableOutput Null => new AudioPlayableOutput(PlayableOutputHandle.Null);

		public static AudioPlayableOutput Create(PlayableGraph graph, string name, AudioSource target)
		{
			if (!AudioPlayableGraphExtensions.InternalCreateAudioOutput(ref graph, name, out var handle))
			{
				return Null;
			}
			AudioPlayableOutput result = new AudioPlayableOutput(handle);
			result.SetTarget(target);
			return result;
		}

		internal AudioPlayableOutput(PlayableOutputHandle handle)
		{
			if (handle.IsValid() && !handle.IsPlayableOutputOfType<AudioPlayableOutput>())
			{
				throw new InvalidCastException("Can't set handle: the playable is not an AudioPlayableOutput.");
			}
			m_Handle = handle;
		}

		public PlayableOutputHandle GetHandle()
		{
			return m_Handle;
		}

		public static implicit operator PlayableOutput(AudioPlayableOutput output)
		{
			return new PlayableOutput(output.GetHandle());
		}

		public static explicit operator AudioPlayableOutput(PlayableOutput output)
		{
			return new AudioPlayableOutput(output.GetHandle());
		}

		public AudioSource GetTarget()
		{
			return InternalGetTarget(ref m_Handle);
		}

		public void SetTarget(AudioSource value)
		{
			InternalSetTarget(ref m_Handle, value);
		}

		public bool GetEvaluateOnSeek()
		{
			return InternalGetEvaluateOnSeek(ref m_Handle);
		}

		public void SetEvaluateOnSeek(bool value)
		{
			InternalSetEvaluateOnSeek(ref m_Handle, value);
		}

		[NativeThrows]
		private static AudioSource InternalGetTarget(ref PlayableOutputHandle output)
		{
			return Unmarshal.UnmarshalUnityObject<AudioSource>(InternalGetTarget_Injected(ref output));
		}

		[NativeThrows]
		private static void InternalSetTarget(ref PlayableOutputHandle output, AudioSource target)
		{
			InternalSetTarget_Injected(ref output, Object.MarshalledUnityObject.Marshal(target));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool InternalGetEvaluateOnSeek(ref PlayableOutputHandle output);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void InternalSetEvaluateOnSeek(ref PlayableOutputHandle output, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr InternalGetTarget_Injected(ref PlayableOutputHandle output);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetTarget_Injected(ref PlayableOutputHandle output, IntPtr target);
	}
	internal enum AudioRandomContainerTriggerMode
	{
		Manual,
		Automatic
	}
	internal enum AudioRandomContainerPlaybackMode
	{
		Sequential,
		Shuffle,
		Random
	}
	internal enum AudioRandomContainerAutomaticTriggerMode
	{
		Pulse,
		Offset
	}
	internal enum AudioRandomContainerLoopMode
	{
		Infinite,
		Clips,
		Cycles
	}
	[NativeHeader("Modules/Audio/Public/AudioContainerElement.h")]
	internal sealed class AudioContainerElement : Object
	{
		internal AudioClip audioClip
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<AudioClip>(get_audioClip_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_audioClip_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		internal float volume
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_volume_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_volume_Injected(intPtr, value);
			}
		}

		internal bool enabled
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

		internal AudioContainerElement()
		{
			Internal_Create(this);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Create([Writable] AudioContainerElement self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_audioClip_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_audioClip_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_volume_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_volume_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_enabled_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_enabled_Injected(IntPtr _unity_self, bool value);
	}
	[NativeHeader("Modules/Audio/Public/AudioRandomContainer.h")]
	[ExcludeFromPreset]
	internal sealed class AudioRandomContainer : AudioResource
	{
		internal enum ChangeEventType
		{
			Volume,
			Pitch,
			List
		}

		internal float volume
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_volume_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_volume_Injected(intPtr, value);
			}
		}

		internal Vector2 volumeRandomizationRange
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_volumeRandomizationRange_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_volumeRandomizationRange_Injected(intPtr, ref value);
			}
		}

		internal bool volumeRandomizationEnabled
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_volumeRandomizationEnabled_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_volumeRandomizationEnabled_Injected(intPtr, value);
			}
		}

		internal float pitch
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_pitch_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_pitch_Injected(intPtr, value);
			}
		}

		internal Vector2 pitchRandomizationRange
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_pitchRandomizationRange_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_pitchRandomizationRange_Injected(intPtr, ref value);
			}
		}

		internal bool pitchRandomizationEnabled
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_pitchRandomizationEnabled_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_pitchRandomizationEnabled_Injected(intPtr, value);
			}
		}

		internal AudioContainerElement[] elements
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_elements_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_elements_Injected(intPtr, value);
			}
		}

		internal AudioRandomContainerTriggerMode triggerMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_triggerMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_triggerMode_Injected(intPtr, value);
			}
		}

		internal AudioRandomContainerPlaybackMode playbackMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_playbackMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_playbackMode_Injected(intPtr, value);
			}
		}

		internal int avoidRepeatingLast
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_avoidRepeatingLast_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_avoidRepeatingLast_Injected(intPtr, value);
			}
		}

		internal AudioRandomContainerAutomaticTriggerMode automaticTriggerMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_automaticTriggerMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_automaticTriggerMode_Injected(intPtr, value);
			}
		}

		internal float automaticTriggerTime
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_automaticTriggerTime_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_automaticTriggerTime_Injected(intPtr, value);
			}
		}

		internal Vector2 automaticTriggerTimeRandomizationRange
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_automaticTriggerTimeRandomizationRange_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_automaticTriggerTimeRandomizationRange_Injected(intPtr, ref value);
			}
		}

		internal bool automaticTriggerTimeRandomizationEnabled
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_automaticTriggerTimeRandomizationEnabled_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_automaticTriggerTimeRandomizationEnabled_Injected(intPtr, value);
			}
		}

		internal AudioRandomContainerLoopMode loopMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_loopMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_loopMode_Injected(intPtr, value);
			}
		}

		internal int loopCount
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_loopCount_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_loopCount_Injected(intPtr, value);
			}
		}

		internal Vector2 loopCountRandomizationRange
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_loopCountRandomizationRange_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_loopCountRandomizationRange_Injected(intPtr, ref value);
			}
		}

		internal bool loopCountRandomizationEnabled
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_loopCountRandomizationEnabled_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_loopCountRandomizationEnabled_Injected(intPtr, value);
			}
		}

		internal AudioRandomContainer()
		{
			Internal_Create(this);
		}

		internal void NotifyObservers(ChangeEventType eventType)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			NotifyObservers_Injected(intPtr, eventType);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Create([Writable] AudioRandomContainer self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_volume_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_volume_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_volumeRandomizationRange_Injected(IntPtr _unity_self, out Vector2 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_volumeRandomizationRange_Injected(IntPtr _unity_self, [In] ref Vector2 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_volumeRandomizationEnabled_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_volumeRandomizationEnabled_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_pitch_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_pitch_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_pitchRandomizationRange_Injected(IntPtr _unity_self, out Vector2 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_pitchRandomizationRange_Injected(IntPtr _unity_self, [In] ref Vector2 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_pitchRandomizationEnabled_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_pitchRandomizationEnabled_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioContainerElement[] get_elements_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_elements_Injected(IntPtr _unity_self, AudioContainerElement[] value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioRandomContainerTriggerMode get_triggerMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_triggerMode_Injected(IntPtr _unity_self, AudioRandomContainerTriggerMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioRandomContainerPlaybackMode get_playbackMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_playbackMode_Injected(IntPtr _unity_self, AudioRandomContainerPlaybackMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_avoidRepeatingLast_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_avoidRepeatingLast_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioRandomContainerAutomaticTriggerMode get_automaticTriggerMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_automaticTriggerMode_Injected(IntPtr _unity_self, AudioRandomContainerAutomaticTriggerMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_automaticTriggerTime_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_automaticTriggerTime_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_automaticTriggerTimeRandomizationRange_Injected(IntPtr _unity_self, out Vector2 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_automaticTriggerTimeRandomizationRange_Injected(IntPtr _unity_self, [In] ref Vector2 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_automaticTriggerTimeRandomizationEnabled_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_automaticTriggerTimeRandomizationEnabled_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AudioRandomContainerLoopMode get_loopMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_loopMode_Injected(IntPtr _unity_self, AudioRandomContainerLoopMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_loopCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_loopCount_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_loopCountRandomizationRange_Injected(IntPtr _unity_self, out Vector2 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_loopCountRandomizationRange_Injected(IntPtr _unity_self, [In] ref Vector2 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_loopCountRandomizationEnabled_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_loopCountRandomizationEnabled_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void NotifyObservers_Injected(IntPtr _unity_self, ChangeEventType eventType);
	}
}
namespace Unity.Audio
{
	[VisibleToOtherModules]
	internal interface IHandle<HandleType> : IValidatable, IEquatable<HandleType> where HandleType : struct, IHandle<HandleType>
	{
	}
	[VisibleToOtherModules]
	internal interface IValidatable
	{
		bool Valid { get; }
	}
}
