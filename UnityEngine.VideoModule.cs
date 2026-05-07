using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Audio;
using UnityEngine.Playables;
using UnityEngine.Scripting;
using UnityEngine.Video;

[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.CommonUtils")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Tooling")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Deployment")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.2D")]
[assembly: InternalsVisibleTo("Unity.DeploymentTests.Services")]
[assembly: InternalsVisibleTo("Unity.Burst.Editor")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Application")]
[assembly: InternalsVisibleTo("Unity.Burst")]
[assembly: InternalsVisibleTo("UnityEngine.TestRunner")]
[assembly: InternalsVisibleTo("UnityEngine.Purchasing")]
[assembly: InternalsVisibleTo("UnityEngine.Advertisements")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("Unity.Automation")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubsystemsModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubstanceModule")]
[assembly: InternalsVisibleTo("UnityEngine.StreamingModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteMaskModule")]
[assembly: InternalsVisibleTo("UnityEngine.TilemapModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteShapeModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainPhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.ShaderVariantAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.RuntimeInitializeOnLoadManagerInitializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.PropertiesModule")]
[assembly: InternalsVisibleTo("UnityEngine.Physics2DModule")]
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.ParticleSystemModule")]
[assembly: InternalsVisibleTo("UnityEngine.NVIDIAModule")]
[assembly: InternalsVisibleTo("UnityEngine.MultiplayerModule")]
[assembly: InternalsVisibleTo("UnityEngine.ScreenCaptureModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UmbraModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
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
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestTextureModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityTestProtocolModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityCurlModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.012")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.009")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.008")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.007")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.006")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.013")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.001")]
[assembly: InternalsVisibleTo("UnityEngine.Core.Runtime.Tests")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.014")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.015")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.016")]
[assembly: InternalsVisibleTo("Unity.Audio.DSPGraph")]
[assembly: InternalsVisibleTo("VideoTesting")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: InternalsVisibleTo("Unity.Subsystem.Registration")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.024")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.023")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.022")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.021")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.020")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.019")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.018")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.017")]
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("UnityEngine.MarshallingModule")]
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("UnityEngine.LocalizationModule")]
[assembly: InternalsVisibleTo("UnityEngine.InsightsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConsentModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.SharedInternalsModule")]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("UnityEngine.ClusterInputModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterRendererModule")]
[assembly: InternalsVisibleTo("UnityEngine.CoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConnectModule")]
[assembly: InternalsVisibleTo("UnityEngine.ContentLoadModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputForUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.IMGUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreTextEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreFontEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputLegacyModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextRenderingModule")]
[assembly: InternalsVisibleTo("UnityEngine.HierarchyCoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.GridModule")]
[assembly: InternalsVisibleTo("UnityEngine.GraphicsStateCollectionSerializerModule")]
[assembly: InternalsVisibleTo("Unity.Audio.DSPGraph.Tests")]
[assembly: InternalsVisibleTo("UnityEngine.ImageConversionModule")]
[assembly: InternalsVisibleTo("UnityEngine.GIModule")]
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: InternalsVisibleTo("UnityEngine.GameCenterModule")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine.Experimental.Video
{
	[StaticAccessor("VideoClipPlayableBindings", StaticAccessorType.DoubleColon)]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[RequiredByNativeCode]
	[NativeHeader("Modules/Video/Public/Director/VideoClipPlayable.h")]
	[NativeHeader("Modules/Video/Public/ScriptBindings/VideoClipPlayable.bindings.h")]
	[NativeHeader("Modules/Video/Public/VideoClip.h")]
	public struct VideoClipPlayable : IPlayable, IEquatable<VideoClipPlayable>
	{
		private PlayableHandle m_Handle;

		public static VideoClipPlayable Create(PlayableGraph graph, VideoClip clip, bool looping)
		{
			PlayableHandle handle = CreateHandle(graph, clip, looping);
			VideoClipPlayable videoClipPlayable = new VideoClipPlayable(handle);
			if (clip != null)
			{
				videoClipPlayable.SetDuration(clip.length);
			}
			return videoClipPlayable;
		}

		private static PlayableHandle CreateHandle(PlayableGraph graph, VideoClip clip, bool looping)
		{
			PlayableHandle handle = PlayableHandle.Null;
			if (!InternalCreateVideoClipPlayable(ref graph, clip, looping, ref handle))
			{
				return PlayableHandle.Null;
			}
			return handle;
		}

		internal VideoClipPlayable(PlayableHandle handle)
		{
			if (handle.IsValid() && !handle.IsPlayableOfType<VideoClipPlayable>())
			{
				throw new InvalidCastException("Can't set handle: the playable is not an VideoClipPlayable.");
			}
			m_Handle = handle;
		}

		public PlayableHandle GetHandle()
		{
			return m_Handle;
		}

		public static implicit operator Playable(VideoClipPlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		public static explicit operator VideoClipPlayable(Playable playable)
		{
			return new VideoClipPlayable(playable.GetHandle());
		}

		public bool Equals(VideoClipPlayable other)
		{
			return GetHandle() == other.GetHandle();
		}

		public VideoClip GetClip()
		{
			return GetClipInternal(ref m_Handle);
		}

		public void SetClip(VideoClip value)
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

		public bool IsPlaying()
		{
			return GetIsPlayingInternal(ref m_Handle);
		}

		public double GetStartDelay()
		{
			return GetStartDelayInternal(ref m_Handle);
		}

		internal void SetStartDelay(double value)
		{
			ValidateStartDelayInternal(value);
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
				throw new ArgumentException("VideoClipPlayable.pauseDelay: Setting new delay when existing delay is too small or 0.0 (" + pauseDelayInternal + "), Video system will not be able to change in time");
			}
			SetPauseDelayInternal(ref m_Handle, value);
		}

		public void Seek(double startTime, double startDelay)
		{
			Seek(startTime, startDelay, 0.0);
		}

		public void Seek(double startTime, double startDelay, [DefaultValue("0")] double duration)
		{
			ValidateStartDelayInternal(startDelay);
			SetStartDelayInternal(ref m_Handle, startDelay);
			if (duration > 0.0)
			{
				m_Handle.SetDuration(duration + startTime);
				SetPauseDelayInternal(ref m_Handle, startDelay + duration);
			}
			else
			{
				m_Handle.SetDuration(double.MaxValue);
				SetPauseDelayInternal(ref m_Handle, 0.0);
			}
			m_Handle.SetTime(startTime);
			m_Handle.Play();
		}

		private void ValidateStartDelayInternal(double startDelay)
		{
			double startDelayInternal = GetStartDelayInternal(ref m_Handle);
			if (IsPlaying() && (startDelay < 0.05 || (startDelayInternal >= 1E-05 && startDelayInternal < 0.05)))
			{
				Debug.LogWarning("VideoClipPlayable.StartDelay: Setting new delay when existing delay is too small or 0.0 (" + startDelayInternal + "), Video system will not be able to change in time");
			}
		}

		[NativeThrows]
		private static VideoClip GetClipInternal(ref PlayableHandle hdl)
		{
			return Unmarshal.UnmarshalUnityObject<VideoClip>(GetClipInternal_Injected(ref hdl));
		}

		[NativeThrows]
		private static void SetClipInternal(ref PlayableHandle hdl, VideoClip clip)
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
		private static extern bool GetIsPlayingInternal(ref PlayableHandle hdl);

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
		private static bool InternalCreateVideoClipPlayable(ref PlayableGraph graph, VideoClip clip, bool looping, ref PlayableHandle handle)
		{
			return InternalCreateVideoClipPlayable_Injected(ref graph, Object.MarshalledUnityObject.Marshal(clip), looping, ref handle);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool ValidateType(ref PlayableHandle hdl);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetClipInternal_Injected(ref PlayableHandle hdl);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetClipInternal_Injected(ref PlayableHandle hdl, IntPtr clip);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool InternalCreateVideoClipPlayable_Injected(ref PlayableGraph graph, IntPtr clip, bool looping, ref PlayableHandle handle);
	}
	[StaticAccessor("VideoPlayerExtensionsBindings", StaticAccessorType.DoubleColon)]
	[NativeHeader("VideoScriptingClasses.h")]
	[NativeHeader("Modules/Video/Public/VideoPlayer.h")]
	[NativeHeader("Modules/Video/Public/ScriptBindings/VideoPlayerExtensions.bindings.h")]
	public static class VideoPlayerExtensions
	{
		public static AudioSampleProvider GetAudioSampleProvider(this VideoPlayer vp, ushort trackIndex)
		{
			ushort controlledAudioTrackCount = vp.controlledAudioTrackCount;
			if (trackIndex >= controlledAudioTrackCount)
			{
				throw new ArgumentOutOfRangeException("trackIndex", trackIndex, "VideoPlayer is currently configured with " + controlledAudioTrackCount + " tracks.");
			}
			VideoAudioOutputMode audioOutputMode = vp.audioOutputMode;
			if (audioOutputMode != VideoAudioOutputMode.APIOnly)
			{
				throw new InvalidOperationException("VideoPlayer.GetAudioSampleProvider requires audioOutputMode to be APIOnly. Current: " + audioOutputMode);
			}
			AudioSampleProvider audioSampleProvider = AudioSampleProvider.Lookup(vp.InternalGetAudioSampleProviderId(trackIndex), vp, trackIndex);
			if (audioSampleProvider == null)
			{
				throw new InvalidOperationException("VideoPlayer.GetAudioSampleProvider got null provider.");
			}
			if (audioSampleProvider.owner != vp)
			{
				throw new InvalidOperationException("Internal error: VideoPlayer.GetAudioSampleProvider got provider used by another object.");
			}
			if (audioSampleProvider.trackIndex != trackIndex)
			{
				throw new InvalidOperationException("Internal error: VideoPlayer.GetAudioSampleProvider got provider for track " + audioSampleProvider.trackIndex + " instead of " + trackIndex);
			}
			return audioSampleProvider;
		}

		internal static uint InternalGetAudioSampleProviderId([NotNull] this VideoPlayer vp, ushort trackIndex)
		{
			if ((object)vp == null)
			{
				ThrowHelper.ThrowArgumentNullException(vp, "vp");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(vp);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(vp, "vp");
			}
			return InternalGetAudioSampleProviderId_Injected(intPtr, trackIndex);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint InternalGetAudioSampleProviderId_Injected(IntPtr vp, ushort trackIndex);
	}
}
namespace UnityEngine.Video
{
	[NativeHeader("Modules/Video/Public/VideoClip.h")]
	[RequiredByNativeCode]
	public sealed class VideoClip : Object
	{
		public string originalPath
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
					get_originalPath_Injected(intPtr, out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
		}

		public ulong frameCount
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_frameCount_Injected(intPtr);
			}
		}

		public double frameRate
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_frameRate_Injected(intPtr);
			}
		}

		[NativeName("Duration")]
		public double length
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

		public uint width
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_width_Injected(intPtr);
			}
		}

		public uint height
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
		}

		public uint pixelAspectRatioNumerator
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_pixelAspectRatioNumerator_Injected(intPtr);
			}
		}

		public uint pixelAspectRatioDenominator
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_pixelAspectRatioDenominator_Injected(intPtr);
			}
		}

		public bool sRGB
		{
			[NativeName("IssRGB")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_sRGB_Injected(intPtr);
			}
		}

		public ushort audioTrackCount
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_audioTrackCount_Injected(intPtr);
			}
		}

		private VideoClip()
		{
		}

		public ushort GetAudioChannelCount(ushort audioTrackIdx)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAudioChannelCount_Injected(intPtr, audioTrackIdx);
		}

		public uint GetAudioSampleRate(ushort audioTrackIdx)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAudioSampleRate_Injected(intPtr, audioTrackIdx);
		}

		public string GetAudioLanguage(ushort audioTrackIdx)
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
				GetAudioLanguage_Injected(intPtr, audioTrackIdx, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_originalPath_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ulong get_frameCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double get_frameRate_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double get_length_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint get_width_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint get_height_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint get_pixelAspectRatioNumerator_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint get_pixelAspectRatioDenominator_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_sRGB_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ushort get_audioTrackCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ushort GetAudioChannelCount_Injected(IntPtr _unity_self, ushort audioTrackIdx);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetAudioSampleRate_Injected(IntPtr _unity_self, ushort audioTrackIdx);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAudioLanguage_Injected(IntPtr _unity_self, ushort audioTrackIdx, out ManagedSpanWrapper ret);
	}
	[RequiredByNativeCode]
	public enum VideoRenderMode
	{
		CameraFarPlane,
		CameraNearPlane,
		RenderTexture,
		MaterialOverride,
		APIOnly
	}
	[RequiredByNativeCode]
	public enum Video3DLayout
	{
		No3D,
		SideBySide3D,
		OverUnder3D
	}
	[RequiredByNativeCode]
	public enum VideoAspectRatio
	{
		NoScaling,
		FitVertically,
		FitHorizontally,
		FitInside,
		FitOutside,
		Stretch
	}
	[Obsolete("VideoTimeSource is deprecated. Use TimeUpdateMode instead. (UnityUpgradable) -> VideoTimeUpdateMode")]
	[RequiredByNativeCode]
	public enum VideoTimeSource
	{
		[Obsolete("AudioDSPTimeSource is deprecated. Use DSPTime instead. (UnityUpgradable) -> DSPTime")]
		AudioDSPTimeSource,
		[Obsolete("GameTimeSource is deprecated. Use GameTime instead. (UnityUpgradable) -> GameTime")]
		GameTimeSource
	}
	[RequiredByNativeCode]
	public enum VideoTimeReference
	{
		Freerun,
		InternalTime,
		ExternalTime
	}
	[RequiredByNativeCode]
	public enum VideoSource
	{
		VideoClip,
		Url
	}
	[RequiredByNativeCode]
	public enum VideoTimeUpdateMode
	{
		DSPTime,
		GameTime,
		UnscaledGameTime
	}
	[RequiredByNativeCode]
	public enum VideoAudioOutputMode
	{
		None,
		AudioSource,
		Direct,
		APIOnly
	}
	[RequiredByNativeCode]
	[NativeHeader("Modules/Video/Public/VideoPlayer.h")]
	[RequireComponent(typeof(Transform))]
	public sealed class VideoPlayer : Behaviour
	{
		public delegate void EventHandler(VideoPlayer source);

		public delegate void ErrorEventHandler(VideoPlayer source, string message);

		public delegate void FrameReadyEventHandler(VideoPlayer source, long frameIdx);

		public delegate void TimeEventHandler(VideoPlayer source, double seconds);

		public VideoSource source
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_source_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_source_Injected(intPtr, value);
			}
		}

		public VideoTimeUpdateMode timeUpdateMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_timeUpdateMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_timeUpdateMode_Injected(intPtr, value);
			}
		}

		[NativeName("VideoUrl")]
		public unsafe string url
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
					get_url_Injected(intPtr, out ret);
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
							set_url_Injected(intPtr, ref managedSpanWrapper);
							return;
						}
					}
					set_url_Injected(intPtr, ref managedSpanWrapper);
				}
				finally
				{
				}
			}
		}

		[NativeName("VideoClip")]
		public VideoClip clip
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<VideoClip>(get_clip_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_clip_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public VideoRenderMode renderMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_renderMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_renderMode_Injected(intPtr, value);
			}
		}

		public bool canSetTimeUpdateMode
		{
			[NativeName("CanSetTimeUpdateMode")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_canSetTimeUpdateMode_Injected(intPtr);
			}
		}

		[NativeHeader("Runtime/Camera/Camera.h")]
		public Camera targetCamera
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<Camera>(get_targetCamera_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_targetCamera_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		[NativeHeader("Runtime/Graphics/RenderTexture.h")]
		public RenderTexture targetTexture
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<RenderTexture>(get_targetTexture_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_targetTexture_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		[NativeHeader("Runtime/Graphics/Renderer.h")]
		public Renderer targetMaterialRenderer
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<Renderer>(get_targetMaterialRenderer_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_targetMaterialRenderer_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public unsafe string targetMaterialProperty
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
					get_targetMaterialProperty_Injected(intPtr, out ret);
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
							set_targetMaterialProperty_Injected(intPtr, ref managedSpanWrapper);
							return;
						}
					}
					set_targetMaterialProperty_Injected(intPtr, ref managedSpanWrapper);
				}
				finally
				{
				}
			}
		}

		public VideoAspectRatio aspectRatio
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_aspectRatio_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_aspectRatio_Injected(intPtr, value);
			}
		}

		public float targetCameraAlpha
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_targetCameraAlpha_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_targetCameraAlpha_Injected(intPtr, value);
			}
		}

		public Video3DLayout targetCamera3DLayout
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_targetCamera3DLayout_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_targetCamera3DLayout_Injected(intPtr, value);
			}
		}

		[NativeHeader("Runtime/Graphics/Texture.h")]
		public Texture texture
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<Texture>(get_texture_Injected(intPtr));
			}
		}

		public bool isPrepared
		{
			[NativeName("IsPrepared")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isPrepared_Injected(intPtr);
			}
		}

		public bool waitForFirstFrame
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_waitForFirstFrame_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_waitForFirstFrame_Injected(intPtr, value);
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

		public bool isPaused
		{
			[NativeName("IsPaused")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isPaused_Injected(intPtr);
			}
		}

		public bool canSetTime
		{
			[NativeName("CanSetTime")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_canSetTime_Injected(intPtr);
			}
		}

		[NativeName("SecPosition")]
		public double time
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

		[NativeName("FramePosition")]
		public long frame
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_frame_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_frame_Injected(intPtr, value);
			}
		}

		public double clockTime
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_clockTime_Injected(intPtr);
			}
		}

		public bool canStep
		{
			[NativeName("CanStep")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_canStep_Injected(intPtr);
			}
		}

		public bool canSetPlaybackSpeed
		{
			[NativeName("CanSetPlaybackSpeed")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_canSetPlaybackSpeed_Injected(intPtr);
			}
		}

		public float playbackSpeed
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_playbackSpeed_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_playbackSpeed_Injected(intPtr, value);
			}
		}

		[NativeName("Loop")]
		public bool isLooping
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isLooping_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_isLooping_Injected(intPtr, value);
			}
		}

		[Obsolete("VideoPlayer.canSetTimeSource is deprecated. Use canSetTimeUpdateMode instead. (UnityUpgradable) -> canSetTimeUpdateMode")]
		public bool canSetTimeSource
		{
			[NativeName("CanSetTimeSource")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_canSetTimeSource_Injected(intPtr);
			}
		}

		[Obsolete("VideoPlayer.timeSource is deprecated. Use timeUpdateMode instead. (UnityUpgradable) -> timeUpdateMode")]
		public VideoTimeSource timeSource
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_timeSource_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_timeSource_Injected(intPtr, value);
			}
		}

		public VideoTimeReference timeReference
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_timeReference_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_timeReference_Injected(intPtr, value);
			}
		}

		public double externalReferenceTime
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_externalReferenceTime_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_externalReferenceTime_Injected(intPtr, value);
			}
		}

		public bool canSetSkipOnDrop
		{
			[NativeName("CanSetSkipOnDrop")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_canSetSkipOnDrop_Injected(intPtr);
			}
		}

		public bool skipOnDrop
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_skipOnDrop_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_skipOnDrop_Injected(intPtr, value);
			}
		}

		public ulong frameCount
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_frameCount_Injected(intPtr);
			}
		}

		public float frameRate
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_frameRate_Injected(intPtr);
			}
		}

		[NativeName("Duration")]
		public double length
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

		public uint width
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_width_Injected(intPtr);
			}
		}

		public uint height
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
		}

		public uint pixelAspectRatioNumerator
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_pixelAspectRatioNumerator_Injected(intPtr);
			}
		}

		public uint pixelAspectRatioDenominator
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_pixelAspectRatioDenominator_Injected(intPtr);
			}
		}

		public ushort audioTrackCount
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_audioTrackCount_Injected(intPtr);
			}
		}

		public static extern ushort controlledAudioTrackMaxCount
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public ushort controlledAudioTrackCount
		{
			get
			{
				return GetControlledAudioTrackCount();
			}
			set
			{
				int num = controlledAudioTrackMaxCount;
				if (value > num)
				{
					throw new ArgumentException($"Cannot control more than {num} tracks.", "value");
				}
				SetControlledAudioTrackCount(value);
			}
		}

		public VideoAudioOutputMode audioOutputMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_audioOutputMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_audioOutputMode_Injected(intPtr, value);
			}
		}

		public bool canSetDirectAudioVolume
		{
			[NativeName("CanSetDirectAudioVolume")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_canSetDirectAudioVolume_Injected(intPtr);
			}
		}

		public bool sendFrameReadyEvents
		{
			[NativeName("AreFrameReadyEventsEnabled")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_sendFrameReadyEvents_Injected(intPtr);
			}
			[NativeName("EnableFrameReadyEvents")]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_sendFrameReadyEvents_Injected(intPtr, value);
			}
		}

		public event EventHandler prepareCompleted;

		public event EventHandler loopPointReached;

		public event EventHandler started;

		public event EventHandler frameDropped;

		public event ErrorEventHandler errorReceived;

		public event EventHandler seekCompleted;

		public event TimeEventHandler clockResyncOccurred;

		public event FrameReadyEventHandler frameReady;

		public void Prepare()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Prepare_Injected(intPtr);
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

		public void StepForward()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			StepForward_Injected(intPtr);
		}

		public string GetAudioLanguageCode(ushort trackIndex)
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
				GetAudioLanguageCode_Injected(intPtr, trackIndex, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		public ushort GetAudioChannelCount(ushort trackIndex)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAudioChannelCount_Injected(intPtr, trackIndex);
		}

		public uint GetAudioSampleRate(ushort trackIndex)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAudioSampleRate_Injected(intPtr, trackIndex);
		}

		private ushort GetControlledAudioTrackCount()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetControlledAudioTrackCount_Injected(intPtr);
		}

		private void SetControlledAudioTrackCount(ushort value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetControlledAudioTrackCount_Injected(intPtr, value);
		}

		public void EnableAudioTrack(ushort trackIndex, bool enabled)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			EnableAudioTrack_Injected(intPtr, trackIndex, enabled);
		}

		public bool IsAudioTrackEnabled(ushort trackIndex)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IsAudioTrackEnabled_Injected(intPtr, trackIndex);
		}

		public float GetDirectAudioVolume(ushort trackIndex)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetDirectAudioVolume_Injected(intPtr, trackIndex);
		}

		public void SetDirectAudioVolume(ushort trackIndex, float volume)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetDirectAudioVolume_Injected(intPtr, trackIndex, volume);
		}

		public bool GetDirectAudioMute(ushort trackIndex)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetDirectAudioMute_Injected(intPtr, trackIndex);
		}

		public void SetDirectAudioMute(ushort trackIndex, bool mute)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetDirectAudioMute_Injected(intPtr, trackIndex, mute);
		}

		[NativeHeader("Modules/Audio/Public/AudioSource.h")]
		public AudioSource GetTargetAudioSource(ushort trackIndex)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<AudioSource>(GetTargetAudioSource_Injected(intPtr, trackIndex));
		}

		public void SetTargetAudioSource(ushort trackIndex, AudioSource source)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetTargetAudioSource_Injected(intPtr, trackIndex, MarshalledUnityObject.Marshal(source));
		}

		[RequiredByNativeCode]
		private static void InvokePrepareCompletedCallback_Internal(VideoPlayer source)
		{
			if (source.prepareCompleted != null)
			{
				source.prepareCompleted(source);
			}
		}

		[RequiredByNativeCode]
		private static void InvokeFrameReadyCallback_Internal(VideoPlayer source, long frameIdx)
		{
			if (source.frameReady != null)
			{
				source.frameReady(source, frameIdx);
			}
		}

		[RequiredByNativeCode]
		private static void InvokeLoopPointReachedCallback_Internal(VideoPlayer source)
		{
			if (source.loopPointReached != null)
			{
				source.loopPointReached(source);
			}
		}

		[RequiredByNativeCode]
		private static void InvokeStartedCallback_Internal(VideoPlayer source)
		{
			if (source.started != null)
			{
				source.started(source);
			}
		}

		[RequiredByNativeCode]
		private static void InvokeFrameDroppedCallback_Internal(VideoPlayer source)
		{
			if (source.frameDropped != null)
			{
				source.frameDropped(source);
			}
		}

		[RequiredByNativeCode]
		private static void InvokeErrorReceivedCallback_Internal(VideoPlayer source, string errorStr)
		{
			if (source.errorReceived != null)
			{
				source.errorReceived(source, errorStr);
			}
		}

		[RequiredByNativeCode]
		private static void InvokeSeekCompletedCallback_Internal(VideoPlayer source)
		{
			if (source.seekCompleted != null)
			{
				source.seekCompleted(source);
			}
		}

		[RequiredByNativeCode]
		private static void InvokeClockResyncOccurredCallback_Internal(VideoPlayer source, double seconds)
		{
			if (source.clockResyncOccurred != null)
			{
				source.clockResyncOccurred(source, seconds);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern VideoSource get_source_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_source_Injected(IntPtr _unity_self, VideoSource value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern VideoTimeUpdateMode get_timeUpdateMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_timeUpdateMode_Injected(IntPtr _unity_self, VideoTimeUpdateMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_url_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_url_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_clip_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_clip_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern VideoRenderMode get_renderMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_renderMode_Injected(IntPtr _unity_self, VideoRenderMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_canSetTimeUpdateMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_targetCamera_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_targetCamera_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_targetTexture_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_targetTexture_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_targetMaterialRenderer_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_targetMaterialRenderer_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_targetMaterialProperty_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_targetMaterialProperty_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern VideoAspectRatio get_aspectRatio_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_aspectRatio_Injected(IntPtr _unity_self, VideoAspectRatio value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_targetCameraAlpha_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_targetCameraAlpha_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Video3DLayout get_targetCamera3DLayout_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_targetCamera3DLayout_Injected(IntPtr _unity_self, Video3DLayout value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_texture_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Prepare_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isPrepared_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_waitForFirstFrame_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_waitForFirstFrame_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_playOnAwake_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_playOnAwake_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Play_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Pause_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Stop_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isPlaying_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isPaused_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_canSetTime_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double get_time_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_time_Injected(IntPtr _unity_self, double value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern long get_frame_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_frame_Injected(IntPtr _unity_self, long value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double get_clockTime_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_canStep_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void StepForward_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_canSetPlaybackSpeed_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_playbackSpeed_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_playbackSpeed_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isLooping_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_isLooping_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_canSetTimeSource_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern VideoTimeSource get_timeSource_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_timeSource_Injected(IntPtr _unity_self, VideoTimeSource value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern VideoTimeReference get_timeReference_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_timeReference_Injected(IntPtr _unity_self, VideoTimeReference value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double get_externalReferenceTime_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_externalReferenceTime_Injected(IntPtr _unity_self, double value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_canSetSkipOnDrop_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_skipOnDrop_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_skipOnDrop_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ulong get_frameCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_frameRate_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double get_length_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint get_width_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint get_height_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint get_pixelAspectRatioNumerator_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint get_pixelAspectRatioDenominator_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ushort get_audioTrackCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAudioLanguageCode_Injected(IntPtr _unity_self, ushort trackIndex, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ushort GetAudioChannelCount_Injected(IntPtr _unity_self, ushort trackIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetAudioSampleRate_Injected(IntPtr _unity_self, ushort trackIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ushort GetControlledAudioTrackCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetControlledAudioTrackCount_Injected(IntPtr _unity_self, ushort value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void EnableAudioTrack_Injected(IntPtr _unity_self, ushort trackIndex, bool enabled);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsAudioTrackEnabled_Injected(IntPtr _unity_self, ushort trackIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern VideoAudioOutputMode get_audioOutputMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_audioOutputMode_Injected(IntPtr _unity_self, VideoAudioOutputMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_canSetDirectAudioVolume_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetDirectAudioVolume_Injected(IntPtr _unity_self, ushort trackIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetDirectAudioVolume_Injected(IntPtr _unity_self, ushort trackIndex, float volume);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetDirectAudioMute_Injected(IntPtr _unity_self, ushort trackIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetDirectAudioMute_Injected(IntPtr _unity_self, ushort trackIndex, bool mute);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetTargetAudioSource_Injected(IntPtr _unity_self, ushort trackIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTargetAudioSource_Injected(IntPtr _unity_self, ushort trackIndex, IntPtr source);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_sendFrameReadyEvents_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_sendFrameReadyEvents_Injected(IntPtr _unity_self, bool value);
	}
}
namespace UnityEngineInternal.Video
{
	[UsedByNativeCode]
	internal enum VideoError
	{
		NoErr,
		OutOfMemoryErr,
		CantReadFile,
		CantWriteFile,
		BadParams,
		NoData,
		BadPermissions,
		DeviceNotAvailable,
		ResourceNotAvailable,
		NetworkErr
	}
	[UsedByNativeCode]
	internal enum VideoPixelFormat
	{
		RGB,
		RGBA,
		YUV,
		YUVA
	}
	[UsedByNativeCode]
	internal enum VideoAlphaLayout
	{
		Native,
		Split
	}
	[NativeHeader("Modules/Video/Public/Base/MediaComponent.h")]
	[UsedByNativeCode]
	internal class VideoPlayback
	{
		public delegate void Callback();

		internal static class BindingsMarshaller
		{
			public static VideoPlayback ConvertToManaged(IntPtr ptr)
			{
				return new VideoPlayback(ptr);
			}

			public static IntPtr ConvertToNative(VideoPlayback videoPlayback)
			{
				return videoPlayback.m_Ptr;
			}
		}

		internal IntPtr m_Ptr;

		private VideoPlayback(IntPtr ptr)
		{
			m_Ptr = ptr;
		}

		public void StartPlayback()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			StartPlayback_Injected(intPtr);
		}

		public void PausePlayback()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			PausePlayback_Injected(intPtr);
		}

		public void StopPlayback()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			StopPlayback_Injected(intPtr);
		}

		public VideoError GetStatus()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetStatus_Injected(intPtr);
		}

		public bool IsReady()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IsReady_Injected(intPtr);
		}

		public bool IsPlaying()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IsPlaying_Injected(intPtr);
		}

		public void Step()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Step_Injected(intPtr);
		}

		public bool CanStep()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return CanStep_Injected(intPtr);
		}

		public uint GetWidth()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetWidth_Injected(intPtr);
		}

		public uint GetHeight()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetHeight_Injected(intPtr);
		}

		public float GetFrameRate()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetFrameRate_Injected(intPtr);
		}

		public float GetDuration()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetDuration_Injected(intPtr);
		}

		public ulong GetFrameCount()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetFrameCount_Injected(intPtr);
		}

		public uint GetPixelAspectRatioNumerator()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetPixelAspectRatioNumerator_Injected(intPtr);
		}

		public uint GetPixelAspectRatioDenominator()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetPixelAspectRatioDenominator_Injected(intPtr);
		}

		public VideoPixelFormat GetPixelFormat()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetPixelFormat_Injected(intPtr);
		}

		public bool CanNotSkipOnDrop()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return CanNotSkipOnDrop_Injected(intPtr);
		}

		public void SetSkipOnDrop(bool skipOnDrop)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetSkipOnDrop_Injected(intPtr, skipOnDrop);
		}

		public bool GetTexture(Texture texture, out long outputFrameNum)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetTexture_Injected(intPtr, UnityEngine.Object.MarshalledUnityObject.Marshal(texture), out outputFrameNum);
		}

		public void SeekToFrame(long frameIndex, Callback seekCompletedCallback)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SeekToFrame_Injected(intPtr, frameIndex, seekCompletedCallback);
		}

		public void SeekToTime(double secs, Callback seekCompletedCallback)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SeekToTime_Injected(intPtr, secs, seekCompletedCallback);
		}

		public float GetPlaybackSpeed()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetPlaybackSpeed_Injected(intPtr);
		}

		public void SetPlaybackSpeed(float value)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetPlaybackSpeed_Injected(intPtr, value);
		}

		public bool GetLoop()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetLoop_Injected(intPtr);
		}

		public void SetLoop(bool value)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetLoop_Injected(intPtr, value);
		}

		public void SetAdjustToLinearSpace(bool enable)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetAdjustToLinearSpace_Injected(intPtr, enable);
		}

		[NativeHeader("Modules/Audio/Public/AudioSource.h")]
		public ushort GetAudioTrackCount()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAudioTrackCount_Injected(intPtr);
		}

		public ushort GetAudioChannelCount(ushort trackIdx)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAudioChannelCount_Injected(intPtr, trackIdx);
		}

		public uint GetAudioSampleRate(ushort trackIdx)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAudioSampleRate_Injected(intPtr, trackIdx);
		}

		public string GetAudioLanguageCode(ushort trackIdx)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetAudioLanguageCode_Injected(intPtr, trackIdx, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		public void SetAudioTarget(ushort trackIdx, bool enabled, bool softwareOutput, AudioSource audioSource)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetAudioTarget_Injected(intPtr, trackIdx, enabled, softwareOutput, UnityEngine.Object.MarshalledUnityObject.Marshal(audioSource));
		}

		private uint GetAudioSampleProviderId(ushort trackIndex)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAudioSampleProviderId_Injected(intPtr, trackIndex);
		}

		public AudioSampleProvider GetAudioSampleProvider(ushort trackIndex)
		{
			if (trackIndex >= GetAudioTrackCount())
			{
				throw new ArgumentOutOfRangeException("trackIndex", trackIndex, "VideoPlayback has " + GetAudioTrackCount() + " tracks.");
			}
			AudioSampleProvider audioSampleProvider = AudioSampleProvider.Lookup(GetAudioSampleProviderId(trackIndex), null, trackIndex);
			if (audioSampleProvider == null)
			{
				throw new InvalidOperationException("VideoPlayback.GetAudioSampleProvider got null provider.");
			}
			if (audioSampleProvider.owner != null)
			{
				throw new InvalidOperationException("Internal error: VideoPlayback.GetAudioSampleProvider got unexpected non-null provider owner.");
			}
			if (audioSampleProvider.trackIndex != trackIndex)
			{
				throw new InvalidOperationException("Internal error: VideoPlayback.GetAudioSampleProvider got provider for track " + audioSampleProvider.trackIndex + " instead of " + trackIndex);
			}
			return audioSampleProvider;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool PlatformSupportsH265();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void StartPlayback_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PausePlayback_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void StopPlayback_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern VideoError GetStatus_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsReady_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsPlaying_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Step_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CanStep_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetWidth_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetHeight_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetFrameRate_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetDuration_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ulong GetFrameCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetPixelAspectRatioNumerator_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetPixelAspectRatioDenominator_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern VideoPixelFormat GetPixelFormat_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CanNotSkipOnDrop_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSkipOnDrop_Injected(IntPtr _unity_self, bool skipOnDrop);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetTexture_Injected(IntPtr _unity_self, IntPtr texture, out long outputFrameNum);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SeekToFrame_Injected(IntPtr _unity_self, long frameIndex, Callback seekCompletedCallback);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SeekToTime_Injected(IntPtr _unity_self, double secs, Callback seekCompletedCallback);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetPlaybackSpeed_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetPlaybackSpeed_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetLoop_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLoop_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetAdjustToLinearSpace_Injected(IntPtr _unity_self, bool enable);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ushort GetAudioTrackCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ushort GetAudioChannelCount_Injected(IntPtr _unity_self, ushort trackIdx);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetAudioSampleRate_Injected(IntPtr _unity_self, ushort trackIdx);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAudioLanguageCode_Injected(IntPtr _unity_self, ushort trackIdx, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetAudioTarget_Injected(IntPtr _unity_self, ushort trackIdx, bool enabled, bool softwareOutput, IntPtr audioSource);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetAudioSampleProviderId_Injected(IntPtr _unity_self, ushort trackIndex);
	}
	[UsedByNativeCode]
	[NativeHeader("Modules/Video/Public/Base/VideoMediaPlayback.h")]
	internal class VideoPlaybackMgr : IDisposable
	{
		public delegate void Callback();

		public delegate void MessageCallback(string message);

		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(VideoPlaybackMgr videoPlaybackMgr)
			{
				return videoPlaybackMgr.m_Ptr;
			}
		}

		internal IntPtr m_Ptr;

		public ulong videoPlaybackCount
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_videoPlaybackCount_Injected(intPtr);
			}
		}

		public VideoPlaybackMgr()
		{
			m_Ptr = Internal_Create();
		}

		public void Dispose()
		{
			if (m_Ptr != IntPtr.Zero)
			{
				Internal_Destroy(m_Ptr);
				m_Ptr = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Internal_Create();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Destroy(IntPtr ptr);

		public unsafe VideoPlayback CreateVideoPlayback(string fileName, MessageCallback errorCallback, Callback readyCallback, Callback reachedEndCallback, bool splitAlpha = false)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			IntPtr intPtr2 = default(IntPtr);
			VideoPlayback result;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(fileName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(fileName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						intPtr2 = CreateVideoPlayback_Injected(intPtr, ref managedSpanWrapper, errorCallback, readyCallback, reachedEndCallback, splitAlpha);
					}
				}
				else
				{
					intPtr2 = CreateVideoPlayback_Injected(intPtr, ref managedSpanWrapper, errorCallback, readyCallback, reachedEndCallback, splitAlpha);
				}
			}
			finally
			{
				IntPtr intPtr3 = intPtr2;
				result = ((intPtr3 == (IntPtr)0) ? null : VideoPlayback.BindingsMarshaller.ConvertToManaged(intPtr3));
			}
			return result;
		}

		public void ReleaseVideoPlayback(VideoPlayback playback)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ReleaseVideoPlayback_Injected(intPtr, (playback == null) ? ((IntPtr)0) : VideoPlayback.BindingsMarshaller.ConvertToNative(playback));
		}

		public void Update()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Update_Injected(intPtr);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ProcessOSMainLoopMessagesForTesting();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr CreateVideoPlayback_Injected(IntPtr _unity_self, ref ManagedSpanWrapper fileName, MessageCallback errorCallback, Callback readyCallback, Callback reachedEndCallback, bool splitAlpha);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ReleaseVideoPlayback_Injected(IntPtr _unity_self, IntPtr playback);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ulong get_videoPlaybackCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Update_Injected(IntPtr _unity_self);
	}
}
