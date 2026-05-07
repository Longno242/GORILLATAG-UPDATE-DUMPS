using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using AOT;
using Meta.XR.Util;
using Microsoft.CodeAnalysis;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.OpenXR;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Oculus.Haptics.Tests")]
[assembly: AssemblyVersion("0.0.0.0")]
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
			FilePathsData = new byte[531]
			{
				0, 0, 0, 1, 0, 0, 0, 80, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 104, 97, 112, 116,
				105, 99, 115, 64, 48, 102, 49, 101, 52, 52,
				99, 53, 56, 57, 54, 52, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 72, 97, 112, 116, 105,
				99, 67, 108, 105, 112, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 86, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 104, 97, 112, 116, 105, 99,
				115, 64, 48, 102, 49, 101, 52, 52, 99, 53,
				56, 57, 54, 52, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 72, 97, 112, 116, 105, 99, 67,
				108, 105, 112, 80, 108, 97, 121, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 77,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 104, 97,
				112, 116, 105, 99, 115, 64, 48, 102, 49, 101,
				52, 52, 99, 53, 56, 57, 54, 52, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 72, 97, 112,
				116, 105, 99, 115, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 82, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 104, 97, 112, 116, 105, 99, 115,
				64, 48, 102, 49, 101, 52, 52, 99, 53, 56,
				57, 54, 52, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 72, 97, 112, 116, 105, 99, 83, 111,
				117, 114, 99, 101, 46, 99, 115, 0, 0, 0,
				3, 0, 0, 0, 83, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 104, 97, 112, 116, 105, 99, 115,
				64, 48, 102, 49, 101, 52, 52, 99, 53, 56,
				57, 54, 52, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 72, 97, 112, 116, 105, 99, 115, 83,
				100, 107, 70, 102, 105, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 75, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 104, 97, 112, 116, 105, 99,
				115, 64, 48, 102, 49, 101, 52, 52, 99, 53,
				56, 57, 54, 52, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 85, 116, 105, 108, 115, 46, 99,
				115
			},
			TypesData = new byte[252]
			{
				0, 0, 0, 0, 25, 79, 99, 117, 108, 117,
				115, 46, 72, 97, 112, 116, 105, 99, 115, 124,
				72, 97, 112, 116, 105, 99, 67, 108, 105, 112,
				0, 0, 0, 0, 31, 79, 99, 117, 108, 117,
				115, 46, 72, 97, 112, 116, 105, 99, 115, 124,
				72, 97, 112, 116, 105, 99, 67, 108, 105, 112,
				80, 108, 97, 121, 101, 114, 0, 0, 0, 0,
				22, 79, 99, 117, 108, 117, 115, 46, 72, 97,
				112, 116, 105, 99, 115, 124, 72, 97, 112, 116,
				105, 99, 115, 0, 0, 0, 0, 27, 79, 99,
				117, 108, 117, 115, 46, 72, 97, 112, 116, 105,
				99, 115, 124, 72, 97, 112, 116, 105, 99, 83,
				111, 117, 114, 99, 101, 0, 0, 0, 0, 18,
				79, 99, 117, 108, 117, 115, 46, 72, 97, 112,
				116, 105, 99, 115, 124, 70, 102, 105, 0, 0,
				0, 0, 29, 79, 99, 117, 108, 117, 115, 46,
				72, 97, 112, 116, 105, 99, 115, 46, 70, 102,
				105, 124, 83, 100, 107, 86, 101, 114, 115, 105,
				111, 110, 0, 0, 0, 0, 40, 79, 99, 117,
				108, 117, 115, 46, 72, 97, 112, 116, 105, 99,
				115, 46, 70, 102, 105, 124, 78, 117, 108, 108,
				66, 97, 99, 107, 101, 110, 100, 83, 116, 97,
				116, 105, 115, 116, 105, 99, 115, 0, 0, 0,
				0, 20, 79, 99, 117, 108, 117, 115, 46, 72,
				97, 112, 116, 105, 99, 115, 124, 85, 116, 105,
				108, 115
			},
			TotalFiles = 6,
			TotalTypes = 8,
			IsEditorOnly = false
		};
	}
}
namespace Oculus.Haptics
{
	public class HapticClip : ScriptableObject
	{
		[SerializeField]
		public string json;
	}
	public class HapticClipPlayer : IDisposable
	{
		private int _clipId = -1;

		private int _playerId = -1;

		protected Haptics _haptics;

		public bool isLooping
		{
			get
			{
				return _haptics.IsHapticPlayerLooping(_playerId);
			}
			set
			{
				_haptics.LoopHapticPlayer(_playerId, value);
			}
		}

		public float clipDuration => _haptics.GetClipDuration(_clipId);

		public float amplitude
		{
			get
			{
				return _haptics.GetAmplitudeHapticPlayer(_playerId);
			}
			set
			{
				_haptics.SetAmplitudeHapticPlayer(_playerId, value);
			}
		}

		public float frequencyShift
		{
			get
			{
				return _haptics.GetFrequencyShiftHapticPlayer(_playerId);
			}
			set
			{
				_haptics.SetFrequencyShiftHapticPlayer(_playerId, value);
			}
		}

		public uint priority
		{
			get
			{
				return _haptics.GetPriorityHapticPlayer(_playerId);
			}
			set
			{
				_haptics.SetPriorityHapticPlayer(_playerId, value);
			}
		}

		public HapticClip clip
		{
			set
			{
				int num = _haptics.LoadClip(value.json);
				if (-1 != num)
				{
					_haptics.SetHapticPlayerClip(_playerId, num);
					if (_clipId != -1)
					{
						_haptics.ReleaseClip(_clipId);
					}
					_clipId = num;
				}
			}
		}

		public HapticClipPlayer()
		{
			SetHaptics();
			int num = _haptics.CreateHapticPlayer();
			if (-1 != num)
			{
				_playerId = num;
			}
		}

		public HapticClipPlayer(HapticClip clip)
		{
			SetHaptics();
			int num = _haptics.CreateHapticPlayer();
			if (-1 != num)
			{
				_playerId = num;
				this.clip = clip;
			}
		}

		protected virtual void SetHaptics()
		{
			_haptics = Haptics.Instance;
		}

		public void Play(Controller controller)
		{
			_haptics.PlayHapticPlayer(_playerId, controller);
		}

		public void Pause()
		{
			_haptics.PauseHapticPlayer(_playerId);
		}

		public void Resume()
		{
			_haptics.ResumeHapticPlayer(_playerId);
		}

		public void Stop()
		{
			_haptics.StopHapticPlayer(_playerId);
		}

		public void Seek(float time)
		{
			_haptics.SeekPlaybackPositionHapticPlayer(_playerId, time);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_playerId != -1)
			{
				if (!_haptics.ReleaseClip(_clipId) & _haptics.ReleaseHapticPlayer(_playerId))
				{
					UnityEngine.Debug.LogError("Error: HapticClipPlayer or HapticClip could not be released");
				}
				_clipId = -1;
				_playerId = -1;
			}
		}

		~HapticClipPlayer()
		{
			Dispose(disposing: false);
		}
	}
	public class Haptics : IDisposable
	{
		protected static Haptics instance;

		public const string HapticsSDKTelemetryName = "haptics_sdk";

		private static SynchronizationContext syncContext;

		public static bool IsPCMHaptics { get; private set; }

		public static Haptics Instance
		{
			get
			{
				if (!IsSupportedPlatform())
				{
					UnityEngine.Debug.LogError("Error: This platform is not supported for haptics");
					instance = null;
					return null;
				}
				if (instance == null)
				{
					instance = new Haptics();
				}
				if (!EnsureInitialized())
				{
					instance = null;
				}
				return instance;
			}
		}

		private static bool IsSupportedPlatform()
		{
			return true;
		}

		private static bool IsPcmHapticsExtensionEnabled()
		{
			string[] enabledExtensions = OpenXRRuntime.GetEnabledExtensions();
			for (int i = 0; i < enabledExtensions.Length; i++)
			{
				if (enabledExtensions[i].Equals("XR_FB_haptic_pcm"))
				{
					return true;
				}
			}
			return false;
		}

		[MonoPInvokeCallback(typeof(Ffi.HapticsSdkPlayCallback))]
		private static void PlayCallback(IntPtr context, Ffi.Controller controller, float duration, float amplitude)
		{
			syncContext.Post(delegate
			{
				switch (controller)
				{
				case Ffi.Controller.Left:
					InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).SendHapticImpulse(0u, amplitude, duration);
					break;
				case Ffi.Controller.Right:
					InputDevices.GetDeviceAtXRNode(XRNode.RightHand).SendHapticImpulse(0u, amplitude, duration);
					break;
				}
			}, null);
		}

		protected Haptics()
		{
		}

		private static bool EnsureInitialized()
		{
			if (IsInitialized())
			{
				return true;
			}
			if (IsPcmHapticsExtensionEnabled() && Ffi.Succeeded(Ffi.initialize_with_ovr_plugin("Unity", Application.unityVersion, "78.0.0-mainline.0")))
			{
				UnityEngine.Debug.Log("Initialized with OVRPlugin backend");
				IsPCMHaptics = true;
				return true;
			}
			if (Ffi.Succeeded(Ffi.initialize_with_callback_backend(IntPtr.Zero, PlayCallback)))
			{
				UnityEngine.Debug.Log("Initialized with callback backend");
				syncContext = SynchronizationContext.Current;
				return true;
			}
			UnityEngine.Debug.LogError("Error: " + Ffi.error_message());
			return false;
		}

		private static bool IsInitialized()
		{
			if (Ffi.Failed(Ffi.initialized(out var initialized)))
			{
				UnityEngine.Debug.LogError("Failed to get initialization state");
				return false;
			}
			return initialized;
		}

		public int LoadClip(string clipJson)
		{
			int clip_id_out = -1;
			return Ffi.load_clip(clipJson, out clip_id_out) switch
			{
				Ffi.Result.LoadClipFailed => throw new FormatException("Invalid format for clip: " + clipJson + "."), 
				Ffi.Result.InvalidUtf8 => throw new FormatException("Invalid UTF8 encoding for clip: " + clipJson + "."), 
				_ => clip_id_out, 
			};
		}

		public bool ReleaseClip(int clipId)
		{
			return Ffi.Succeeded(Ffi.release_clip(clipId));
		}

		public int CreateHapticPlayer()
		{
			int player_id = -1;
			Ffi.create_player(out player_id);
			return player_id;
		}

		public void SetHapticPlayerClip(int playerId, int clipId)
		{
			switch (Ffi.player_set_clip(playerId, clipId))
			{
			case Ffi.Result.PlayerIdInvalid:
				throw new ArgumentException($"Invalid player ID: {playerId}.");
			case Ffi.Result.ClipIdInvalid:
				throw new ArgumentException($"Invalid clipId: {clipId}.");
			}
		}

		public void PlayHapticPlayer(int playerId, Controller controller)
		{
			Ffi.Controller controller2 = Utils.ControllerToFfiController(controller);
			switch (Ffi.player_play(playerId, controller2))
			{
			case Ffi.Result.PlayerIdInvalid:
				throw new ArgumentException($"Invalid player ID: {playerId}.");
			case Ffi.Result.NoClipLoaded:
				throw new InvalidOperationException($"Player with ID {playerId} has no clip loaded.");
			}
		}

		public void PauseHapticPlayer(int playerId)
		{
			switch (Ffi.player_pause(playerId))
			{
			case Ffi.Result.PlayerIdInvalid:
				throw new ArgumentException($"Invalid player ID: {playerId}.");
			case Ffi.Result.NoClipLoaded:
				throw new InvalidOperationException($"Player with ID {playerId} has no clip loaded.");
			}
		}

		public void ResumeHapticPlayer(int playerId)
		{
			switch (Ffi.player_resume(playerId))
			{
			case Ffi.Result.PlayerIdInvalid:
				throw new ArgumentException($"Invalid player ID: {playerId}.");
			case Ffi.Result.NoClipLoaded:
				throw new InvalidOperationException($"Player with ID {playerId} has no clip loaded.");
			}
		}

		public void StopHapticPlayer(int playerId)
		{
			switch (Ffi.player_stop(playerId))
			{
			case Ffi.Result.PlayerIdInvalid:
				throw new ArgumentException($"Invalid player ID: {playerId}.");
			case Ffi.Result.NoClipLoaded:
				throw new InvalidOperationException($"Player with ID {playerId} has no clip loaded.");
			}
		}

		public void SeekPlaybackPositionHapticPlayer(int playerId, float time)
		{
			switch (Ffi.player_seek(playerId, time))
			{
			case Ffi.Result.PlayerIdInvalid:
				throw new ArgumentException($"Invalid player ID: {playerId}.");
			case Ffi.Result.NoClipLoaded:
				throw new InvalidOperationException($"Player with ID {playerId} has no clip loaded.");
			case Ffi.Result.PlayerInvalidSeekPosition:
				throw new ArgumentOutOfRangeException($"Invalid time: {time} for player {playerId}." + "Make sure the value is positive and within the playback duration of the currently loaded clip.");
			}
		}

		public float GetClipDuration(int clipId)
		{
			float clip_duration = 0f;
			if (Ffi.Result.ClipIdInvalid == Ffi.clip_duration(clipId, out clip_duration))
			{
				throw new ArgumentException($"Invalid clip ID: {clipId}.");
			}
			return clip_duration;
		}

		public void LoopHapticPlayer(int playerId, bool enabled)
		{
			if (Ffi.Result.PlayerIdInvalid == Ffi.player_set_looping_enabled(playerId, enabled))
			{
				throw new ArgumentException($"Invalid player ID: {playerId}.");
			}
		}

		public bool IsHapticPlayerLooping(int playerId)
		{
			bool looping_enabled = false;
			if (Ffi.Result.PlayerIdInvalid == Ffi.player_looping_enabled(playerId, out looping_enabled))
			{
				throw new ArgumentException($"Invalid player ID: {playerId}.");
			}
			return looping_enabled;
		}

		public void SetAmplitudeHapticPlayer(int playerId, float amplitude)
		{
			switch (Ffi.player_set_amplitude(playerId, amplitude))
			{
			case Ffi.Result.PlayerIdInvalid:
				throw new ArgumentException($"Invalid player ID: {playerId}.");
			case Ffi.Result.PlayerInvalidAmplitude:
				throw new ArgumentOutOfRangeException($"Invalid amplitude: {amplitude} for player {playerId}." + "Make sure the value is non-negative.");
			}
		}

		public float GetAmplitudeHapticPlayer(int playerId)
		{
			float amplitude = 1f;
			if (Ffi.Result.PlayerIdInvalid == Ffi.player_amplitude(playerId, out amplitude))
			{
				throw new ArgumentException($"Invalid player ID: {playerId}.");
			}
			return amplitude;
		}

		public void SetFrequencyShiftHapticPlayer(int playerId, float amount)
		{
			switch (Ffi.player_set_frequency_shift(playerId, amount))
			{
			case Ffi.Result.PlayerIdInvalid:
				throw new ArgumentException($"Invalid player ID: {playerId}.");
			case Ffi.Result.PlayerInvalidFrequencyShift:
				throw new ArgumentOutOfRangeException($"Invalid frequency shift amount: {amount} for player {playerId}." + "Make sure the value is on the range -1.0 to 1.0 (inclusive).");
			}
		}

		public float GetFrequencyShiftHapticPlayer(int playerId)
		{
			float frequency_shift = 0f;
			if (Ffi.Result.PlayerIdInvalid == Ffi.player_frequency_shift(playerId, out frequency_shift))
			{
				throw new ArgumentException($"Invalid player ID: {playerId}.");
			}
			return frequency_shift;
		}

		private static uint MapPriority(uint input, int inMin, int inMax, int outMin, int outMax)
		{
			try
			{
				return checked((uint)Math.Round(Utils.Map((int)input, inMin, inMax, outMin, outMax)));
			}
			catch (OverflowException)
			{
				throw new ArgumentOutOfRangeException($"Invalid priority value: {input}. " + "Make sure the value is within the range 0 to 255 (inclusive).");
			}
		}

		public void SetPriorityHapticPlayer(int playerId, uint value)
		{
			switch (Ffi.player_set_priority(playerId, MapPriority(value, 0, 255, 1024, 0)))
			{
			case Ffi.Result.PlayerIdInvalid:
				throw new ArgumentException($"Invalid player ID: {playerId}.");
			case Ffi.Result.PlayerInvalidPriority:
				throw new ArgumentOutOfRangeException($"Invalid priority value: {value} for player {playerId}. " + "Make sure the value is within the range 0 to 255 (inclusive).");
			}
		}

		public uint GetPriorityHapticPlayer(int playerId)
		{
			uint priority = 128u;
			if (Ffi.Result.PlayerIdInvalid == Ffi.player_priority(playerId, out priority))
			{
				throw new ArgumentException($"Invalid player ID: {playerId}.");
			}
			return MapPriority(priority, 0, 1024, 255, 0);
		}

		public bool ReleaseHapticPlayer(int playerId)
		{
			return Ffi.Succeeded(Ffi.release_player(playerId));
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (instance != null)
			{
				if (IsInitialized() && Ffi.Failed(Ffi.uninitialize()))
				{
					UnityEngine.Debug.LogError("Error: " + Ffi.error_message());
				}
				instance = null;
			}
		}

		~Haptics()
		{
			Dispose(disposing: false);
		}
	}
	[Feature(Feature.Haptics)]
	public class HapticSource : MonoBehaviour, ISerializationCallbackReceiver
	{
		private HapticClipPlayer _player;

		[SerializeField]
		private HapticClip _clip;

		[SerializeField]
		private Controller _controller = Controller.Both;

		[SerializeField]
		private bool _loop;

		[SerializeField]
		[Range(0f, float.MaxValue)]
		private float _amplitude = 1f;

		[SerializeField]
		[Range(-1f, 1f)]
		private float _frequencyShift;

		[SerializeField]
		[Range(0f, 255f)]
		private uint _priority = 128u;

		public HapticClip clip
		{
			set
			{
				_clip = value;
				if (_player != null)
				{
					_player.clip = _clip;
				}
			}
		}

		public float clipDuration => _player.clipDuration;

		public Controller controller
		{
			set
			{
				_controller = value;
			}
		}

		[DefaultValue(false)]
		public bool loop
		{
			get
			{
				return _loop;
			}
			set
			{
				_loop = value;
				_player.isLooping = _loop;
			}
		}

		[DefaultValue(1.0)]
		public float amplitude
		{
			get
			{
				return _amplitude;
			}
			set
			{
				_amplitude = value;
				_player.amplitude = _amplitude;
			}
		}

		[DefaultValue(0.0)]
		public float frequencyShift
		{
			get
			{
				return _frequencyShift;
			}
			set
			{
				_frequencyShift = value;
				_player.frequencyShift = _frequencyShift;
			}
		}

		[DefaultValue(128)]
		public uint priority
		{
			get
			{
				return _priority;
			}
			set
			{
				_priority = value;
				_player.priority = _priority;
			}
		}

		private void Awake()
		{
			_player = new HapticClipPlayer();
			_player.clip = _clip;
			SyncSerializedFieldsToPlayer();
		}

		public void Play()
		{
			_player.Play(_controller);
		}

		public void Play(Controller controller)
		{
			this.controller = controller;
			_player.Play(_controller);
		}

		public void Pause()
		{
			_player.Pause();
		}

		public void Resume()
		{
			_player.Resume();
		}

		public void Stop()
		{
			_player.Stop();
		}

		public void Seek(float time)
		{
			_player.Seek(time);
		}

		private void SyncSerializedFieldsToPlayer()
		{
			if (_player != null)
			{
				_player.isLooping = _loop;
				_player.amplitude = _amplitude;
				_player.frequencyShift = _frequencyShift;
				_player.priority = _priority;
			}
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			if (_player != null)
			{
				SyncSerializedFieldsToPlayer();
			}
		}

		protected virtual void OnDestroy()
		{
			_player.Dispose();
		}
	}
	public class Ffi
	{
		public enum Result
		{
			Success = 0,
			Error = -1,
			InstanceInitializationFailed = -2,
			InstanceAlreadyInitialized = -3,
			InstanceAlreadyUninitialized = -4,
			InstanceNotInitialized = -5,
			InvalidUtf8 = -6,
			LoadClipFailed = -7,
			CreatePlayerFailed = -8,
			ClipIdInvalid = -9,
			PlayerIdInvalid = -10,
			PlayerInvalidAmplitude = -11,
			PlayerInvalidFrequencyShift = -12,
			PlayerInvalidPriority = -13,
			NoClipLoaded = -14,
			InvalidPlayCallbackPointer = -15,
			PlayerInvalidSeekPosition = -16
		}

		public struct SdkVersion
		{
			public ushort major;

			public ushort minor;

			public ushort patch;
		}

		public enum Controller
		{
			Left,
			Right,
			Both
		}

		public enum LogLevel
		{
			Trace,
			Debug,
			Info,
			Warn,
			Error
		}

		public delegate void LogCallback(LogLevel level, string message);

		public delegate void HapticsSdkPlayCallback(IntPtr context, Controller controller, float duration, float amplitude);

		public struct NullBackendStatistics
		{
			public long stream_count;

			public long play_call_count;
		}

		private const string NativeLibName = "haptics_sdk";

		public const int InvalidId = -1;

		public static bool Succeeded(Result result)
		{
			return result >= Result.Success;
		}

		public static bool Failed(Result result)
		{
			return result < Result.Success;
		}

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_version")]
		public static extern SdkVersion version();

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_initialize_logging")]
		public static extern Result initialize_logging([MarshalAs(UnmanagedType.FunctionPtr)] LogCallback? logCallback);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_initialize_with_callback_backend")]
		public static extern Result initialize_with_callback_backend(IntPtr context, [MarshalAs(UnmanagedType.FunctionPtr)] HapticsSdkPlayCallback? playCallback);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_initialize_with_ovr_plugin")]
		private static extern Result initialize_with_ovr_plugin_bytes([In] byte[] game_engine_name, [In] byte[] game_engine_version, [In] byte[] game_engine_haptics_sdk_version);

		public static Result initialize_with_ovr_plugin(string game_engine_name, string game_engine_version, string game_engine_haptics_sdk_version)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(game_engine_name + "\0");
			byte[] bytes2 = Encoding.UTF8.GetBytes(game_engine_version + "\0");
			byte[] bytes3 = Encoding.UTF8.GetBytes(game_engine_haptics_sdk_version + "\0");
			return initialize_with_ovr_plugin_bytes(bytes, bytes2, bytes3);
		}

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_initialize_with_null_backend")]
		public static extern Result initialize_with_null_backend();

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_uninitialize")]
		public static extern Result uninitialize();

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_initialized")]
		public static extern Result initialized(out bool initialized);

		[DllImport("haptics_sdk")]
		private static extern IntPtr haptics_sdk_error_message();

		[DllImport("haptics_sdk")]
		private static extern int haptics_sdk_error_message_length();

		public static string error_message()
		{
			IntPtr intPtr = haptics_sdk_error_message();
			if (intPtr == IntPtr.Zero)
			{
				throw new InvalidOperationException("No error message is available");
			}
			int num = haptics_sdk_error_message_length();
			byte[] array = new byte[num];
			Marshal.Copy(intPtr, array, 0, num);
			return Encoding.UTF8.GetString(array);
		}

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_set_suspended")]
		public static extern Result set_suspended(bool suspended);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_load_clip")]
		private static extern Result load_clip_bytes([In] byte[] data, uint data_length, out int clip_id_out);

		public static Result load_clip(string data, out int clip_id_out)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(data);
			return load_clip_bytes(bytes, (uint)bytes.Length, out clip_id_out);
		}

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_clip_duration")]
		public static extern Result clip_duration(int clipId, out float clip_duration);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_release_clip")]
		public static extern Result release_clip(int clipId);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_create_player")]
		public static extern Result create_player(out int player_id);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_release_player")]
		public static extern Result release_player(int playerId);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_player_set_clip")]
		public static extern Result player_set_clip(int playerId, int clipId);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_player_play")]
		public static extern Result player_play(int playerId, Controller controller);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_player_pause")]
		public static extern Result player_pause(int playerId);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_player_resume")]
		public static extern Result player_resume(int playerId);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_player_stop")]
		public static extern Result player_stop(int playerId);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_player_seek")]
		public static extern Result player_seek(int playerId, float time);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_player_set_amplitude")]
		public static extern Result player_set_amplitude(int playerId, float amplitude);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_player_amplitude")]
		public static extern Result player_amplitude(int playerId, out float amplitude);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_player_set_frequency_shift")]
		public static extern Result player_set_frequency_shift(int playerId, float amount);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_player_frequency_shift")]
		public static extern Result player_frequency_shift(int playerId, out float frequency_shift);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_player_set_looping_enabled")]
		public static extern Result player_set_looping_enabled(int playerId, bool enabled);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_player_looping_enabled")]
		public static extern Result player_looping_enabled(int playerId, out bool looping_enabled);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_player_set_priority")]
		public static extern Result player_set_priority(int playerId, uint priority);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_player_priority")]
		public static extern Result player_priority(int playerId, out uint priority);

		[DllImport("haptics_sdk", EntryPoint = "haptics_sdk_get_null_backend_statistics")]
		public static extern NullBackendStatistics get_null_backend_statistics();
	}
	public enum Controller
	{
		Left,
		Right,
		Both
	}
	internal static class Utils
	{
		internal static Ffi.Controller ControllerToFfiController(Controller controller)
		{
			return controller switch
			{
				Controller.Left => Ffi.Controller.Left, 
				Controller.Right => Ffi.Controller.Right, 
				Controller.Both => Ffi.Controller.Both, 
				_ => throw new ArgumentException($"Invalid controller selected: {controller}."), 
			};
		}

		internal static float Map(int input, int inMin, int inMax, int outMin, int outMax)
		{
			float num = (input - inMin) * (outMax - outMin);
			float num2 = inMax - inMin;
			return num / num2 + (float)outMin;
		}
	}
}
