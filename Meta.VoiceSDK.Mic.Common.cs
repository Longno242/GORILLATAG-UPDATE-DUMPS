using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Meta.Voice;
using Meta.WitAi.Data;
using Meta.WitAi.Interfaces;
using UnityEngine;

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
			FilePathsData = new byte[881]
			{
				0, 0, 0, 1, 0, 0, 0, 115, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 118, 111, 105, 99,
				101, 64, 100, 51, 102, 54, 102, 51, 55, 98,
				56, 101, 49, 99, 92, 76, 105, 98, 92, 87,
				105, 116, 46, 97, 105, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 76, 105, 98, 92, 77, 105, 99, 92,
				67, 111, 109, 109, 111, 110, 92, 65, 117, 100,
				105, 111, 69, 110, 99, 111, 100, 105, 110, 103,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				120, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 118,
				111, 105, 99, 101, 64, 100, 51, 102, 54, 102,
				51, 55, 98, 56, 101, 49, 99, 92, 76, 105,
				98, 92, 87, 105, 116, 46, 97, 105, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 76, 105, 98, 92, 77,
				105, 99, 92, 67, 111, 109, 109, 111, 110, 92,
				66, 97, 115, 101, 65, 117, 100, 105, 111, 67,
				108, 105, 112, 73, 110, 112, 117, 116, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 119, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 118, 111, 105,
				99, 101, 64, 100, 51, 102, 54, 102, 51, 55,
				98, 56, 101, 49, 99, 92, 76, 105, 98, 92,
				87, 105, 116, 46, 97, 105, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 76, 105, 98, 92, 77, 105, 99,
				92, 67, 111, 109, 109, 111, 110, 92, 73, 65,
				117, 100, 105, 111, 73, 110, 112, 117, 116, 83,
				111, 117, 114, 99, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 126, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 118, 111, 105, 99, 101, 64,
				100, 51, 102, 54, 102, 51, 55, 98, 56, 101,
				49, 99, 92, 76, 105, 98, 92, 87, 105, 116,
				46, 97, 105, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				76, 105, 98, 92, 77, 105, 99, 92, 67, 111,
				109, 109, 111, 110, 92, 73, 65, 117, 100, 105,
				111, 76, 101, 118, 101, 108, 82, 97, 110, 103,
				101, 80, 114, 111, 118, 105, 100, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 126,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 118, 111,
				105, 99, 101, 64, 100, 51, 102, 54, 102, 51,
				55, 98, 56, 101, 49, 99, 92, 76, 105, 98,
				92, 87, 105, 116, 46, 97, 105, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 76, 105, 98, 92, 77, 105,
				99, 92, 67, 111, 109, 109, 111, 110, 92, 73,
				65, 117, 100, 105, 111, 86, 97, 114, 105, 97,
				98, 108, 101, 83, 97, 109, 112, 108, 101, 82,
				97, 116, 101, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 109, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 118, 111, 105, 99, 101, 64, 100, 51,
				102, 54, 102, 51, 55, 98, 56, 101, 49, 99,
				92, 76, 105, 98, 92, 87, 105, 116, 46, 97,
				105, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 76, 105,
				98, 92, 77, 105, 99, 92, 67, 111, 109, 109,
				111, 110, 92, 77, 105, 99, 66, 97, 115, 101,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				110, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 118,
				111, 105, 99, 101, 64, 100, 51, 102, 54, 102,
				51, 55, 98, 56, 101, 49, 99, 92, 76, 105,
				98, 92, 87, 105, 116, 46, 97, 105, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 76, 105, 98, 92, 77,
				105, 99, 92, 67, 111, 109, 109, 111, 110, 92,
				77, 105, 99, 68, 101, 98, 117, 103, 46, 99,
				115
			},
			TypesData = new byte[266]
			{
				0, 0, 0, 0, 29, 77, 101, 116, 97, 46,
				87, 105, 116, 65, 105, 46, 68, 97, 116, 97,
				124, 65, 117, 100, 105, 111, 69, 110, 99, 111,
				100, 105, 110, 103, 0, 0, 0, 0, 33, 77,
				101, 116, 97, 46, 87, 105, 116, 65, 105, 46,
				76, 105, 98, 124, 66, 97, 115, 101, 65, 117,
				100, 105, 111, 67, 108, 105, 112, 73, 110, 112,
				117, 116, 0, 0, 0, 0, 39, 77, 101, 116,
				97, 46, 87, 105, 116, 65, 105, 46, 73, 110,
				116, 101, 114, 102, 97, 99, 101, 115, 124, 73,
				65, 117, 100, 105, 111, 73, 110, 112, 117, 116,
				83, 111, 117, 114, 99, 101, 0, 0, 0, 0,
				39, 77, 101, 116, 97, 46, 87, 105, 116, 65,
				105, 46, 76, 105, 98, 124, 73, 65, 117, 100,
				105, 111, 76, 101, 118, 101, 108, 82, 97, 110,
				103, 101, 80, 114, 111, 118, 105, 100, 101, 114,
				0, 0, 0, 0, 46, 77, 101, 116, 97, 46,
				87, 105, 116, 65, 105, 46, 73, 110, 116, 101,
				114, 102, 97, 99, 101, 115, 124, 73, 65, 117,
				100, 105, 111, 86, 97, 114, 105, 97, 98, 108,
				101, 83, 97, 109, 112, 108, 101, 82, 97, 116,
				101, 0, 0, 0, 0, 22, 77, 101, 116, 97,
				46, 87, 105, 116, 65, 105, 46, 76, 105, 98,
				124, 77, 105, 99, 66, 97, 115, 101, 0, 0,
				0, 0, 23, 77, 101, 116, 97, 46, 87, 105,
				116, 65, 105, 46, 76, 105, 98, 124, 77, 105,
				99, 68, 101, 98, 117, 103
			},
			TotalFiles = 7,
			TotalTypes = 7,
			IsEditorOnly = false
		};
	}
}
namespace Meta.WitAi.Interfaces
{
	public interface IAudioInputSource
	{
		bool IsRecording { get; }

		AudioEncoding AudioEncoding { get; }

		bool IsMuted { get; }

		event Action OnStartRecording;

		event Action OnStartRecordingFailed;

		event Action<int, float[], float> OnSampleReady;

		event Action OnStopRecording;

		event Action OnMicMuted;

		event Action OnMicUnmuted;

		void StartRecording(int sampleLen);

		void StopRecording();
	}
	public interface IAudioVariableSampleRate
	{
		bool NeedsSampleRateCalculation { get; }
	}
}
namespace Meta.WitAi.Lib
{
	public abstract class BaseAudioClipInput : MonoBehaviour, IAudioInputSource, IAudioLevelRangeProvider
	{
		private AudioEncoding _audioEncoding;

		private Coroutine _activateCoroutine;

		private Coroutine _recordCoroutine;

		public abstract AudioClip Clip { get; }

		public abstract int ClipPosition { get; }

		public abstract bool CanActivateAudio { get; }

		public virtual bool ActivateOnEnable => false;

		public virtual int AudioChannels => 1;

		public virtual int AudioSampleRate => 16000;

		public virtual int AudioSampleLength { get; private set; }

		public virtual float MinAudioLevel => 0.5f;

		public virtual float MaxAudioLevel => 1f;

		public AudioEncoding AudioEncoding
		{
			get
			{
				if (_audioEncoding == null)
				{
					_audioEncoding = new AudioEncoding();
				}
				_audioEncoding.numChannels = AudioChannels;
				_audioEncoding.samplerate = AudioSampleRate;
				_audioEncoding.encoding = "signed-integer";
				return _audioEncoding;
			}
		}

		public VoiceAudioInputState ActivationState { get; private set; }

		public virtual bool IsRecording { get; private set; }

		public virtual bool IsMuted { get; private set; }

		public event Action<VoiceAudioInputState> OnActivationStateChange;

		public event Action OnStartRecording;

		public event Action OnStartRecordingFailed;

		public event Action OnStopRecording;

		public event Action<int, float[], float> OnSampleReady;

		public event Action OnMicMuted;

		public event Action OnMicUnmuted;

		protected void SetActivationState(VoiceAudioInputState newActivationState)
		{
			ActivationState = newActivationState;
			this.OnActivationStateChange?.Invoke(ActivationState);
		}

		protected virtual void SetMuted(bool muted)
		{
			if (IsMuted != muted)
			{
				IsMuted = muted;
				if (IsMuted)
				{
					this.OnMicMuted?.Invoke();
				}
				else
				{
					this.OnMicUnmuted?.Invoke();
				}
			}
		}

		protected virtual void OnEnable()
		{
			if (ActivateOnEnable && ActivationState != VoiceAudioInputState.Activating && ActivationState != VoiceAudioInputState.On)
			{
				ActivateAudio();
			}
		}

		private void ActivateAudio()
		{
			if (ActivationState == VoiceAudioInputState.On || ActivationState == VoiceAudioInputState.Activating)
			{
				VLog.W(GetType().Name, $"Cannot activate when audio is already {ActivationState}");
				return;
			}
			if (!base.gameObject.activeInHierarchy)
			{
				VLog.W(GetType().Name, "Audio activation is disabled while GameObject is inactive");
				return;
			}
			if (!CanActivateAudio)
			{
				VLog.W(GetType().Name, "Audio activation is currently restricted");
				return;
			}
			if (_activateCoroutine != null)
			{
				StopCoroutine(_activateCoroutine);
				_activateCoroutine = null;
			}
			_activateCoroutine = StartCoroutine(PerformActivation());
		}

		private IEnumerator PerformActivation()
		{
			SetActivationState(VoiceAudioInputState.Activating);
			yield return HandleActivation();
			if (ActivationState == VoiceAudioInputState.Activating)
			{
				SetActivationState(VoiceAudioInputState.On);
			}
			_activateCoroutine = null;
		}

		protected abstract IEnumerator HandleActivation();

		protected virtual void OnDisable()
		{
			if (IsRecording)
			{
				StopRecording();
			}
			if (ActivateOnEnable && ActivationState != VoiceAudioInputState.Deactivating && ActivationState != VoiceAudioInputState.Off)
			{
				DeactivateAudio();
			}
		}

		private void DeactivateAudio()
		{
			if (ActivationState == VoiceAudioInputState.Off || ActivationState == VoiceAudioInputState.Deactivating)
			{
				VLog.W(GetType().Name, $"Cannot deactivate when audio is already {ActivationState}");
				return;
			}
			if (_activateCoroutine != null)
			{
				StopCoroutine(_activateCoroutine);
				_activateCoroutine = null;
			}
			SetActivationState(VoiceAudioInputState.Deactivating);
			HandleDeactivation();
			if (ActivationState == VoiceAudioInputState.Deactivating)
			{
				SetActivationState(VoiceAudioInputState.Off);
			}
		}

		protected abstract void HandleDeactivation();

		public virtual void StartRecording(int sampleDurationMS)
		{
			if (IsRecording)
			{
				VLog.W(GetType().Name, "Cannot start recording when already recording");
				this.OnStartRecordingFailed?.Invoke();
				return;
			}
			IsRecording = true;
			AudioSampleLength = sampleDurationMS;
			if (_recordCoroutine != null)
			{
				StopCoroutine(_recordCoroutine);
				_recordCoroutine = null;
			}
			_recordCoroutine = StartCoroutine(ReadRawAudio());
		}

		private IEnumerator ReadRawAudio()
		{
			if (ActivationState != VoiceAudioInputState.On)
			{
				if (ActivationState != VoiceAudioInputState.Activating)
				{
					ActivateAudio();
				}
				while (ActivationState == VoiceAudioInputState.Activating)
				{
					yield return null;
				}
				if (ActivationState != VoiceAudioInputState.On)
				{
					IsRecording = false;
					this.OnStartRecordingFailed?.Invoke();
					yield break;
				}
			}
			AudioClip micClip = Clip;
			if (micClip == null)
			{
				VLog.W(GetType().Name, "No AudioClip found following activation");
				IsRecording = false;
				this.OnStartRecordingFailed?.Invoke();
				yield break;
			}
			this.OnStartRecording?.Invoke();
			float num = (float)AudioSampleLength / 1000f;
			int audioChannels = AudioChannels;
			int audioSampleRate = AudioSampleRate;
			int num2 = Mathf.CeilToInt((float)(audioChannels * audioSampleRate) * num);
			float[] samples = new float[num2];
			int prevMicPosition = ClipPosition;
			int readAbsPosition = prevMicPosition;
			int loops = 0;
			while (micClip != null && IsRecording)
			{
				yield return null;
				bool flag = true;
				while (micClip != null && flag)
				{
					int clipPosition = ClipPosition;
					if (clipPosition < prevMicPosition)
					{
						loops++;
					}
					prevMicPosition = clipPosition;
					int num3 = loops * micClip.samples + clipPosition;
					int num4 = readAbsPosition + samples.Length;
					flag = num4 < num3;
					if (flag && micClip.GetData(samples, readAbsPosition % micClip.samples))
					{
						this.OnSampleReady?.Invoke(0, samples, 0f);
						readAbsPosition = num4;
					}
				}
			}
			if (IsRecording)
			{
				StopRecording();
			}
		}

		public virtual void StopRecording()
		{
			if (!IsRecording)
			{
				VLog.E(GetType().Name, "Cannot stop recording when not recording");
				return;
			}
			if (!ActivateOnEnable || !base.gameObject.activeInHierarchy)
			{
				DeactivateAudio();
			}
			IsRecording = false;
			this.OnStopRecording?.Invoke();
		}
	}
	public interface IAudioLevelRangeProvider
	{
		float MinAudioLevel { get; }

		float MaxAudioLevel { get; }
	}
	public abstract class MicBase : MonoBehaviour, IAudioInputSource
	{
		private int _sampleCount;

		private Coroutine _reader;

		public abstract int MicPosition { get; }

		public bool IsRecording { get; private set; }

		public virtual bool IsMicListening => Microphone.IsRecording(GetMicName());

		public bool IsInputAvailable => GetMicClip() != null;

		public AudioEncoding AudioEncoding { get; set; } = new AudioEncoding();

		public virtual bool IsMuted { get; private set; }

		public event Action OnStartRecording;

		public event Action OnStartRecordingFailed;

		public event Action OnStopRecording;

		public event Action<int, float[], float> OnSampleReady;

		public event Action OnMicMuted;

		public event Action OnMicUnmuted;

		public abstract string GetMicName();

		public abstract int GetMicSampleRate();

		public abstract AudioClip GetMicClip();

		protected virtual void SetMuted(bool muted)
		{
			if (IsMuted != muted)
			{
				IsMuted = muted;
				if (IsMuted)
				{
					this.OnMicMuted?.Invoke();
				}
				else
				{
					this.OnMicUnmuted?.Invoke();
				}
			}
		}

		public virtual void CheckForInput()
		{
		}

		public virtual void StartRecording(int sampleDurationMS)
		{
			if (IsRecording)
			{
				StopRecording();
			}
			if (!IsInputAvailable)
			{
				this.OnStartRecordingFailed();
				return;
			}
			IsRecording = true;
			_reader = StartCoroutine(ReadRawAudio(sampleDurationMS));
		}

		protected virtual IEnumerator ReadRawAudio(int sampleDurationMS)
		{
			this.OnStartRecording?.Invoke();
			AudioClip micClip = GetMicClip();
			GetMicName();
			int micSampleRate = GetMicSampleRate();
			int num = AudioEncoding.samplerate / 1000 * sampleDurationMS * micClip.channels;
			float[] sample = new float[num];
			int loops = 0;
			int readAbsPos = MicPosition;
			int prevPos = readAbsPos;
			int micTempTotal = micSampleRate / 1000 * sampleDurationMS * micClip.channels;
			int micDif = micTempTotal / num;
			float[] temp = new float[micTempTotal];
			while (micClip != null && IsMicListening && IsRecording)
			{
				bool flag = true;
				while (flag && micClip != null)
				{
					int micPosition = MicPosition;
					if (micPosition < prevPos)
					{
						loops++;
					}
					prevPos = micPosition;
					int num2 = loops * micClip.samples + micPosition;
					int num3 = readAbsPos + micTempTotal;
					if (num3 < num2)
					{
						micClip.GetData(temp, readAbsPos % micClip.samples);
						float num4 = 0f;
						int num5 = 0;
						for (int i = 0; i < temp.Length; i++)
						{
							float num6 = temp[i] * temp[i];
							if (num4 < num6)
							{
								num4 = num6;
							}
							if (i % micDif == 0 && num5 < sample.Length)
							{
								sample[num5] = temp[i];
								num5++;
							}
						}
						_sampleCount++;
						this.OnSampleReady?.Invoke(_sampleCount, sample, num4);
						readAbsPos = num3;
					}
					else
					{
						flag = false;
					}
				}
				yield return null;
			}
			if (IsRecording)
			{
				StopRecording();
			}
		}

		public virtual void StopRecording()
		{
			if (IsRecording)
			{
				IsRecording = false;
				if (_reader != null)
				{
					StopCoroutine(_reader);
					_reader = null;
				}
				this.OnStopRecording?.Invoke();
			}
		}
	}
	public class MicDebug : MonoBehaviour
	{
		[SerializeField]
		private IAudioInputSource _micSource;

		[SerializeField]
		private string fileDirectory = "MicClips";

		[SerializeField]
		private string fileName = "mic_debug_";

		private FileStream _fileStream;

		private byte[] _buffer;

		private const int FLOAT_TO_SHORT = 32767;

		private const int BYTES_PER_SHORT = 2;

		private void OnEnable()
		{
			if (_micSource == null)
			{
				_micSource = base.gameObject.GetComponentInChildren<IAudioInputSource>();
			}
			if (_micSource != null)
			{
				_micSource.OnStartRecording += OnStartRecording;
				_micSource.OnSampleReady += OnSampleReady;
				_micSource.OnStopRecording += OnStopRecording;
			}
		}

		private void OnDisable()
		{
			if (_micSource != null)
			{
				_micSource.OnStartRecording -= OnStartRecording;
				_micSource.OnSampleReady -= OnSampleReady;
				_micSource.OnStopRecording -= OnStopRecording;
			}
		}

		private void OnDestroy()
		{
			UnloadStream();
		}

		private void OnStartRecording()
		{
			string temporaryCachePath = Application.temporaryCachePath;
			temporaryCachePath = temporaryCachePath + "/" + fileDirectory;
			if (temporaryCachePath.EndsWith("/"))
			{
				temporaryCachePath = temporaryCachePath.Substring(0, temporaryCachePath.Length - 1);
			}
			if (!Directory.Exists(temporaryCachePath))
			{
				Directory.CreateDirectory(temporaryCachePath);
			}
			DateTime now = DateTime.Now;
			temporaryCachePath = $"{temporaryCachePath}/{fileName}{now.Year:0000}{now.Month:00}{now.Day:00}_{now.Hour:00}{now.Minute:00}{now.Second:00}.pcm";
			VLog.D("MicDebug - Writing recording to file: " + temporaryCachePath);
			_fileStream = File.Open(temporaryCachePath, FileMode.Create);
		}

		private void OnSampleReady(int sampleCount, float[] sample, float levelMax)
		{
			if (_fileStream != null && sample != null)
			{
				if (_buffer == null || _buffer.Length != sample.Length * 2)
				{
					_buffer = new byte[sample.Length * 2];
				}
				for (int i = 0; i < sample.Length; i++)
				{
					short num = (short)(sample[i] * 32767f);
					_buffer[i * 2] = (byte)num;
					_buffer[i * 2 + 1] = (byte)(num >> 8);
				}
				_fileStream.Write(_buffer, 0, _buffer.Length);
			}
		}

		private void OnStopRecording()
		{
			UnloadStream();
		}

		private void UnloadStream()
		{
			if (_fileStream != null)
			{
				_fileStream.Close();
				_fileStream.Dispose();
				_fileStream = null;
			}
		}
	}
}
namespace Meta.WitAi.Data
{
	[Serializable]
	public class AudioEncoding
	{
		public enum Endian
		{
			Big,
			Little
		}

		public int numChannels = 1;

		public int samplerate = 16000;

		public string encoding = "signed-integer";

		public const string ENCODING_SIGNED = "signed-integer";

		public const string ENCODING_UNSIGNED = "unsigned-integer";

		public int bits = 16;

		public const int BITS_BYTE = 8;

		public const int BITS_SHORT = 16;

		public const int BITS_INT = 32;

		public const int BITS_LONG = 64;

		public Endian endian = Endian.Little;

		public override string ToString()
		{
			return $"audio/raw;bits={bits};rate={samplerate / 1000}k;encoding={encoding};endian={endian.ToString().ToLower()}";
		}
	}
}
