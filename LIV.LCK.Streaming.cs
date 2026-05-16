using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Liv.Lck.Core;
using Liv.Lck.DependencyInjection;
using Liv.Lck.Encoding;
using Liv.Lck.Telemetry;
using Liv.NGFX;
using UnityEngine;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("LIV.LCK.Streaming.PlayModeTests")]
[assembly: InternalsVisibleTo("LIV.LCK.Streaming.EditModeTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
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
			FilePathsData = new byte[323]
			{
				0, 0, 0, 1, 0, 0, 0, 76, 92, 80,
				97, 99, 107, 97, 103, 101, 115, 92, 116, 118,
				46, 108, 105, 118, 46, 108, 99, 107, 45, 115,
				116, 114, 101, 97, 109, 105, 110, 103, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 73, 76, 99, 107, 78,
				97, 116, 105, 118, 101, 83, 116, 114, 101, 97,
				109, 105, 110, 103, 83, 101, 114, 118, 105, 99,
				101, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 75, 92, 80, 97, 99, 107, 97, 103, 101,
				115, 92, 116, 118, 46, 108, 105, 118, 46, 108,
				99, 107, 45, 115, 116, 114, 101, 97, 109, 105,
				110, 103, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 76,
				99, 107, 78, 97, 116, 105, 118, 101, 83, 116,
				114, 101, 97, 109, 105, 110, 103, 83, 101, 114,
				118, 105, 99, 101, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 61, 92, 80, 97, 99, 107,
				97, 103, 101, 115, 92, 116, 118, 46, 108, 105,
				118, 46, 108, 99, 107, 45, 115, 116, 114, 101,
				97, 109, 105, 110, 103, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 76, 99, 107, 83, 116, 114, 101, 97,
				109, 101, 114, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 79, 92, 80, 97, 99, 107, 97,
				103, 101, 115, 92, 116, 118, 46, 108, 105, 118,
				46, 108, 99, 107, 45, 115, 116, 114, 101, 97,
				109, 105, 110, 103, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 76, 99, 107, 83, 116, 114, 101, 97, 109,
				105, 110, 103, 77, 111, 100, 117, 108, 101, 73,
				110, 105, 116, 105, 97, 108, 105, 122, 101, 114,
				46, 99, 115
			},
			TypesData = new byte[180]
			{
				0, 0, 0, 0, 44, 76, 105, 118, 46, 76,
				99, 107, 46, 83, 116, 114, 101, 97, 109, 105,
				110, 103, 124, 73, 76, 99, 107, 78, 97, 116,
				105, 118, 101, 83, 116, 114, 101, 97, 109, 105,
				110, 103, 83, 101, 114, 118, 105, 99, 101, 0,
				0, 0, 0, 43, 76, 105, 118, 46, 76, 99,
				107, 46, 83, 116, 114, 101, 97, 109, 105, 110,
				103, 124, 76, 99, 107, 78, 97, 116, 105, 118,
				101, 83, 116, 114, 101, 97, 109, 105, 110, 103,
				83, 101, 114, 118, 105, 99, 101, 0, 0, 0,
				0, 29, 76, 105, 118, 46, 76, 99, 107, 46,
				83, 116, 114, 101, 97, 109, 105, 110, 103, 124,
				76, 99, 107, 83, 116, 114, 101, 97, 109, 101,
				114, 0, 0, 0, 0, 44, 76, 105, 118, 46,
				76, 99, 107, 46, 83, 116, 114, 101, 97, 109,
				105, 110, 103, 124, 83, 116, 114, 101, 97, 109,
				105, 110, 103, 77, 111, 100, 117, 108, 101, 73,
				110, 105, 116, 105, 97, 108, 105, 122, 101, 114
			},
			TotalFiles = 4,
			TotalTypes = 4,
			IsEditorOnly = false
		};
	}
}
namespace Liv.Lck.Streaming;

internal interface ILckNativeStreamingService
{
	bool CreateNativeStreamer();

	void DestroyNativeStreamer();

	bool HasNativeStreamer();

	bool StartNativeStreamer(int width, int height);

	bool StopNativeStreamer();

	void SetNativeStreamerLogLevel(Liv.NGFX.LogLevel logLevel);

	LckEncodedPacketCallback GetStreamPacketCallback();
}
internal class LckNativeStreamingService : ILckNativeStreamingService
{
	private const string StreamingLib = "lck_streaming_rs";

	private IntPtr _streamerContext = IntPtr.Zero;

	private Liv.NGFX.LogLevel _logLevel = Liv.NGFX.LogLevel.Error;

	[DllImport("lck_streaming_rs")]
	private static extern IntPtr CreateStreamer();

	[DllImport("lck_streaming_rs")]
	private static extern void DestroyStreamer(IntPtr streamerContext);

	[DllImport("lck_streaming_rs")]
	private static extern bool StartStreamer(IntPtr streamerContext, int width, int height);

	[DllImport("lck_streaming_rs")]
	private static extern void StopStreamer(IntPtr streamerContext);

	[DllImport("lck_streaming_rs")]
	private static extern void SetStreamerLogLevel(IntPtr streamerContext, uint level);

	[DllImport("lck_streaming_rs")]
	private static extern IntPtr GetStreamerCallbackFunction();

	[DllImport("lck_streaming_rs")]
	private static extern void SetPacketInterleaverEnabled(IntPtr streamerContext, bool enabled);

	public bool CreateNativeStreamer()
	{
		_streamerContext = CreateStreamer();
		if (!HasNativeStreamer())
		{
			return false;
		}
		UpdateNativeStreamerLogLevel();
		return true;
	}

	public void DestroyNativeStreamer()
	{
		if (HasNativeStreamer())
		{
			DestroyStreamer(_streamerContext);
			_streamerContext = IntPtr.Zero;
		}
	}

	public bool HasNativeStreamer()
	{
		return _streamerContext != IntPtr.Zero;
	}

	public bool StartNativeStreamer(int width, int height)
	{
		return StartStreamer(_streamerContext, width, height);
	}

	public bool StopNativeStreamer()
	{
		StopStreamer(_streamerContext);
		return true;
	}

	public void SetNativeStreamerLogLevel(Liv.NGFX.LogLevel logLevel)
	{
		_logLevel = logLevel;
		if (HasNativeStreamer())
		{
			UpdateNativeStreamerLogLevel();
		}
	}

	public LckEncodedPacketCallback GetStreamPacketCallback()
	{
		return new LckEncodedPacketCallback(_streamerContext, GetStreamerCallbackFunction());
	}

	private void UpdateNativeStreamerLogLevel()
	{
		SetStreamerLogLevel(_streamerContext, (uint)_logLevel);
	}
}
internal class LckStreamer : ILckStreamer, ILckCaptureStateProvider, IDisposable
{
	private readonly ILckNativeStreamingService _nativeStreamingService;

	private readonly ILckEncoder _encoder;

	private readonly ILckOutputConfigurer _outputConfigurer;

	private readonly ILckEventBus _eventBus;

	private readonly ILckTelemetryClient _telemetryClient;

	private readonly ILckTelemetryContextProvider _telemetryContextProvider;

	private const EncoderConsumer ConsumerName = EncoderConsumer.Streaming;

	private float _streamStartTime;

	private bool _disposed;

	private CameraTrackDescriptor _currentStreamDescriptor;

	private LckEncodedPacketHandler _streamingPacketHandler;

	private Dictionary<string, object> _streamingTelemetryContext = new Dictionary<string, object>();

	public bool IsStreaming => CurrentCaptureState != LckCaptureState.Idle;

	public LckCaptureState CurrentCaptureState { get; private set; }

	private float CurrentStreamDurationSeconds => Time.time - _streamStartTime;

	public LckResult<bool> IsPaused()
	{
		return LckResult<bool>.NewSuccess(CurrentCaptureState == LckCaptureState.Paused);
	}

	public LckStreamer(ILckNativeStreamingService nativeStreamingService, ILckEncoder encoder, ILckOutputConfigurer outputConfigurer, ILckEventBus eventBus, ILckTelemetryClient telemetryClient, ILckTelemetryContextProvider telemetryContextProvider)
	{
		_nativeStreamingService = nativeStreamingService;
		_encoder = encoder;
		_outputConfigurer = outputConfigurer;
		_eventBus = eventBus;
		_telemetryClient = telemetryClient;
		_telemetryContextProvider = telemetryContextProvider;
		_eventBus.AddListener<LckEvents.EncoderStoppedEvent>(OnEncoderStopped);
		_eventBus.AddListener<LckEvents.CaptureErrorEvent>(OnCaptureError);
		Dictionary<string, object> context = new Dictionary<string, object> { { "service", "LckStreamer" } };
		_telemetryClient.SendTelemetry(new LckTelemetryEvent(LckTelemetryEventType.ServiceCreated, context));
	}

	public LckResult StartStreaming()
	{
		if (IsStreaming)
		{
			LckLog.LogError("Streaming already started", "StartStreaming", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 66);
			return LckResult.NewError(LckError.StreamingError, "Streaming already started");
		}
		if (!_nativeStreamingService.HasNativeStreamer())
		{
			LckResult lckResult = SetUpNativeStreamer();
			if (!lckResult.Success)
			{
				return lckResult;
			}
		}
		CurrentCaptureState = LckCaptureState.Starting;
		StartStreamingAsync();
		return LckResult.NewSuccess();
	}

	public LckResult StopStreaming(LckService.StopReason stopReason)
	{
		LckLog.Log(string.Format("LCK {0} triggered with stop reason: {1}", "StopStreaming", stopReason), "StopStreaming", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 88);
		if (!_nativeStreamingService.HasNativeStreamer())
		{
			LckLog.LogError("Native streamer does not exist", "StopStreaming", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 92);
			return LckResult.NewError(LckError.StreamingError, "Native streamer does not exist");
		}
		if (_encoder == null)
		{
			LckLog.LogError("Encoder is null", "StopStreaming", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 98);
			return LckResult.NewError(LckError.StreamingError, "Encoder is null");
		}
		if (!IsStreaming)
		{
			LckLog.LogError("Streaming is already stopped", "StopStreaming", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 104);
			return LckResult.NewError(LckError.StreamingError, "Streaming is already stopped");
		}
		LckLog.Log("LCK Stopping Streaming", "StopStreaming", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 108);
		CurrentCaptureState = LckCaptureState.Stopping;
		StopStreamingAsync(stopReason);
		return LckResult.NewSuccess();
	}

	public LckResult<TimeSpan> GetStreamDuration()
	{
		if (!IsStreaming)
		{
			return LckResult<TimeSpan>.NewError(LckError.StreamingError, "Stream has not been started.");
		}
		return LckResult<TimeSpan>.NewSuccess(TimeSpan.FromSeconds(CurrentStreamDurationSeconds));
	}

	public void SetLogLevel(Liv.NGFX.LogLevel logLevel)
	{
		_nativeStreamingService.SetNativeStreamerLogLevel(logLevel);
	}

	private async Task<LckResult> StartNativeStreamerAsync(int width, int height)
	{
		return await Task.Run(delegate
		{
			try
			{
				if (_nativeStreamingService.StartNativeStreamer(width, height))
				{
					return LckResult.NewSuccess();
				}
				LckLog.LogError($"Failed to start native streamer (resolution: {width}x{height})", "StartNativeStreamerAsync", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 140);
				return LckResult.NewError(LckError.StreamingError, "Failed to start native streamer");
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogException(ex);
				LckLog.LogError($"Failed to start native streamer (resolution: {width}x{height}): {ex.Message}", "StartNativeStreamerAsync", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 146);
				return LckResult.NewError(LckError.StreamingError, ex.Message);
			}
		});
	}

	private async Task StartStreamingAsync()
	{
		_outputConfigurer.SetActiveCaptureType(LckCaptureType.Streaming);
		LckResult<CameraTrackDescriptor> activeCameraTrackDescriptor = _outputConfigurer.GetActiveCameraTrackDescriptor();
		if (!activeCameraTrackDescriptor.Success)
		{
			CurrentCaptureState = LckCaptureState.Idle;
			LckResult result = LckResult.NewError(LckError.UnknownError, activeCameraTrackDescriptor.Message);
			TriggerStreamingStartedEvent(result);
			return;
		}
		_currentStreamDescriptor = activeCameraTrackDescriptor.Result;
		UpdateStreamingTelemetryContext();
		CameraResolutionDescriptor cameraResolutionDescriptor = _currentStreamDescriptor.CameraResolutionDescriptor;
		int width = (int)cameraResolutionDescriptor.Width;
		int height = (int)cameraResolutionDescriptor.Height;
		LckResult lckResult = await StartNativeStreamerAsync(width, height);
		if (!lckResult.Success)
		{
			CurrentCaptureState = LckCaptureState.Idle;
			TriggerStreamingStartedEvent(lckResult);
			return;
		}
		_streamingPacketHandler = new LckEncodedPacketHandler(this, _nativeStreamingService.GetStreamPacketCallback());
		LckResult lckResult2 = _encoder.AcquireEncoder(EncoderConsumer.Streaming, _currentStreamDescriptor, new LckEncodedPacketHandler[1] { _streamingPacketHandler });
		if (!lckResult2.Success)
		{
			CurrentCaptureState = LckCaptureState.Idle;
			LckLog.LogError($"Failed to start encoding for streaming (resolution: {width}x{height}): {lckResult2.Message}", "StartStreamingAsync", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 188);
			TriggerStreamingStartedEvent(lckResult2);
		}
		else
		{
			CurrentCaptureState = LckCaptureState.InProgress;
			_streamStartTime = Time.time;
			LckLog.Log($"Streaming started with dimensions {width}x{height}", "StartStreamingAsync", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 196);
			TriggerStreamingStartedEvent(LckResult.NewSuccess());
		}
	}

	private async Task<LckResult> StopNativeStreamerAsync()
	{
		return await Task.Run(delegate
		{
			try
			{
				return _nativeStreamingService.StopNativeStreamer() ? LckResult.NewSuccess() : LckResult.NewError(LckError.StreamingError, "Failed to stop native streamer");
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogException(ex);
				return LckResult.NewError(LckError.StreamingError, ex.Message);
			}
		});
	}

	private async Task StopStreamingAsync(LckService.StopReason stopReason)
	{
		_ = 1;
		try
		{
			LckResult lckResult = await _encoder.ReleaseEncoderAsync(EncoderConsumer.Streaming, new LckEncodedPacketHandler[1] { _streamingPacketHandler });
			if (!lckResult.Success)
			{
				TriggerStreamingStoppedEvent(lckResult);
				return;
			}
			LckResult lckResult2 = await StopNativeStreamerAsync();
			if (!lckResult2.Success)
			{
				TriggerStreamingStoppedEvent(lckResult2);
				return;
			}
			_nativeStreamingService.DestroyNativeStreamer();
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogException(ex);
			TriggerStreamingStoppedEvent(LckResult.NewError(LckError.StreamingError, ex.Message));
			return;
		}
		CurrentCaptureState = LckCaptureState.Idle;
		_telemetryClient.SendTelemetry(new LckTelemetryEvent(LckTelemetryEventType.StreamingStopped, _streamingTelemetryContext));
		TriggerStreamingStoppedEvent(LckResult.NewSuccess());
	}

	private LckResult SetUpNativeStreamer()
	{
		if (_nativeStreamingService.HasNativeStreamer())
		{
			LckLog.LogError("Streamer already exists", "SetUpNativeStreamer", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 256);
			return LckResult.NewError(LckError.StreamingError, "Streamer already exists");
		}
		if (!_nativeStreamingService.CreateNativeStreamer())
		{
			LckLog.LogError("LCK Failed to create native streamer", "SetUpNativeStreamer", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 262);
			return LckResult.NewError(LckError.StreamingError, "LCK Failed to create native streamer");
		}
		if (!_nativeStreamingService.GetStreamPacketCallback().IsValid)
		{
			_nativeStreamingService.DestroyNativeStreamer();
			LckLog.LogError("LCK Failed to get streamer callback function", "SetUpNativeStreamer", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 269);
			return LckResult.NewError(LckError.StreamingError, "LCK Failed to get streamer callback function");
		}
		return LckResult.NewSuccess();
	}

	private void OnEncoderStopped(LckEvents.EncoderStoppedEvent encoderStoppedEvent)
	{
		if (CurrentCaptureState == LckCaptureState.InProgress)
		{
			LckLog.LogError($"Encoder stopped unexpectedly during streaming (duration: {CurrentStreamDurationSeconds}s) - stopping stream", "OnEncoderStopped", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 281);
			StopStreaming(LckService.StopReason.Error);
		}
	}

	private void TriggerStreamingStoppedEvent(LckResult result)
	{
		_eventBus.Trigger(new LckEvents.StreamingStoppedEvent(result));
	}

	private void TriggerStreamingStartedEvent(LckResult result)
	{
		_eventBus.Trigger(new LckEvents.StreamingStartedEvent(result));
	}

	private void UpdateStreamingTelemetryContext()
	{
		_streamingTelemetryContext = new Dictionary<string, object>
		{
			{ "streaming.durationSeconds", CurrentStreamDurationSeconds },
			{
				"streaming.targetResolutionX",
				_currentStreamDescriptor.CameraResolutionDescriptor.Width
			},
			{
				"streaming.targetResolutionY",
				_currentStreamDescriptor.CameraResolutionDescriptor.Height
			},
			{ "streaming.targetFramerate", _currentStreamDescriptor.Framerate },
			{ "streaming.targetBitrate", _currentStreamDescriptor.Bitrate },
			{ "streaming.targetAudioBitrate", _currentStreamDescriptor.AudioBitrate }
		};
		LckResult<uint> numberOfAudioChannels = _outputConfigurer.GetNumberOfAudioChannels();
		if (numberOfAudioChannels.Success)
		{
			_streamingTelemetryContext.Add("streaming.audioChannels", numberOfAudioChannels.Result);
		}
		LckResult<uint> audioSampleRate = _outputConfigurer.GetAudioSampleRate();
		if (audioSampleRate.Success)
		{
			_streamingTelemetryContext.Add("streaming.audioSampleRate", audioSampleRate.Result);
		}
		_telemetryContextProvider.SetTelemetryContext(LckTelemetryContextType.StreamingContext, _streamingTelemetryContext);
	}

	private void OnCaptureError(LckEvents.CaptureErrorEvent captureErrorEvent)
	{
		if (CurrentCaptureState != LckCaptureState.Idle && CurrentCaptureState != LckCaptureState.Stopping)
		{
			LckLog.LogError("Stopping stream because a capture error occurred: " + captureErrorEvent.Error.Message, "OnCaptureError", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 328);
			StopStreaming(LckService.StopReason.Error);
		}
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			if (IsStreaming && !StopStreaming(LckService.StopReason.ApplicationLifecycle).Success)
			{
				LckLog.LogError("Failed to stop streaming while disposing LckStreamer", "Dispose", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 340);
			}
			_eventBus.RemoveListener<LckEvents.EncoderStoppedEvent>(OnEncoderStopped);
			_eventBus.RemoveListener<LckEvents.CaptureErrorEvent>(OnCaptureError);
			_nativeStreamingService.DestroyNativeStreamer();
			_disposed = true;
			Dictionary<string, object> context = new Dictionary<string, object> { { "service", "LckStreamer" } };
			_telemetryClient.SendTelemetry(new LckTelemetryEvent(LckTelemetryEventType.ServiceDisposed, context));
			LckLog.Log("LckStreamer disposed", "Dispose", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamer.cs", 351);
		}
	}
}
internal static class StreamingModuleInitializer
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Initialize()
	{
		LckModuleLoader.RegisterModule(delegate(LckDiContainer container)
		{
			container.AddSingleton<ILckNativeStreamingService, LckNativeStreamingService>();
			container.AddSingleton<ILckStreamer, LckStreamer>();
			LckLog.Log("LCK: Loaded module - Liv.Lck.Streaming", "Initialize", ".\\Packages\\tv.liv.lck-streaming\\Runtime\\Scripts\\LckStreamingModuleInitializer.cs", 18);
		}, "Liv.Lck.Streaming");
	}
}
