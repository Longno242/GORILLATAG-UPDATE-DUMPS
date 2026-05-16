using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
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
			FilePathsData = new byte[346]
			{
				0, 0, 0, 1, 0, 0, 0, 76, 92, 80,
				97, 99, 107, 97, 103, 101, 115, 92, 116, 118,
				46, 108, 105, 118, 46, 108, 99, 107, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 80, 108, 117,
				103, 105, 110, 115, 92, 78, 97, 116, 105, 118,
				101, 65, 117, 100, 105, 111, 66, 114, 105, 100,
				103, 101, 92, 73, 78, 97, 116, 105, 118, 101,
				65, 117, 100, 105, 111, 80, 108, 97, 121, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 82, 92, 80, 97, 99, 107, 97, 103, 101,
				115, 92, 116, 118, 46, 108, 105, 118, 46, 108,
				99, 107, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 80, 108, 117, 103, 105, 110, 115, 92, 78,
				97, 116, 105, 118, 101, 65, 117, 100, 105, 111,
				66, 114, 105, 100, 103, 101, 92, 78, 97, 116,
				105, 118, 101, 65, 117, 100, 105, 111, 80, 108,
				97, 121, 101, 114, 70, 97, 99, 116, 111, 114,
				121, 46, 99, 115, 0, 0, 0, 4, 0, 0,
				0, 82, 92, 80, 97, 99, 107, 97, 103, 101,
				115, 92, 116, 118, 46, 108, 105, 118, 46, 108,
				99, 107, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 80, 108, 117, 103, 105, 110, 115, 92, 78,
				97, 116, 105, 118, 101, 65, 117, 100, 105, 111,
				66, 114, 105, 100, 103, 101, 92, 78, 97, 116,
				105, 118, 101, 65, 117, 100, 105, 111, 80, 108,
				97, 121, 101, 114, 87, 105, 110, 100, 111, 119,
				115, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 74, 92, 80, 97, 99, 107, 97, 103, 101,
				115, 92, 116, 118, 46, 108, 105, 118, 46, 108,
				99, 107, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 80, 108, 117, 103, 105, 110, 115, 92, 78,
				97, 116, 105, 118, 101, 65, 117, 100, 105, 111,
				66, 114, 105, 100, 103, 101, 92, 78, 97, 116,
				105, 118, 101, 65, 117, 100, 105, 111, 85, 116,
				105, 108, 115, 46, 99, 115
			},
			TypesData = new byte[377]
			{
				0, 0, 0, 0, 40, 76, 105, 118, 46, 78,
				97, 116, 105, 118, 101, 65, 117, 100, 105, 111,
				66, 114, 105, 100, 103, 101, 124, 73, 78, 97,
				116, 105, 118, 101, 65, 117, 100, 105, 111, 80,
				108, 97, 121, 101, 114, 0, 0, 0, 0, 46,
				76, 105, 118, 46, 78, 97, 116, 105, 118, 101,
				65, 117, 100, 105, 111, 66, 114, 105, 100, 103,
				101, 124, 78, 97, 116, 105, 118, 101, 65, 117,
				100, 105, 111, 80, 108, 97, 121, 101, 114, 70,
				97, 99, 116, 111, 114, 121, 0, 0, 0, 0,
				46, 76, 105, 118, 46, 78, 97, 116, 105, 118,
				101, 65, 117, 100, 105, 111, 66, 114, 105, 100,
				103, 101, 124, 78, 97, 116, 105, 118, 101, 65,
				117, 100, 105, 111, 80, 108, 97, 121, 101, 114,
				87, 105, 110, 100, 111, 119, 115, 0, 0, 0,
				0, 61, 76, 105, 118, 46, 78, 97, 116, 105,
				118, 101, 65, 117, 100, 105, 111, 66, 114, 105,
				100, 103, 101, 46, 78, 97, 116, 105, 118, 101,
				65, 117, 100, 105, 111, 80, 108, 97, 121, 101,
				114, 87, 105, 110, 100, 111, 119, 115, 124, 80,
				114, 101, 108, 111, 97, 100, 101, 100, 65, 117,
				100, 105, 111, 0, 0, 0, 0, 57, 76, 105,
				118, 46, 78, 97, 116, 105, 118, 101, 65, 117,
				100, 105, 111, 66, 114, 105, 100, 103, 101, 46,
				78, 97, 116, 105, 118, 101, 65, 117, 100, 105,
				111, 80, 108, 97, 121, 101, 114, 87, 105, 110,
				100, 111, 119, 115, 124, 87, 97, 118, 101, 70,
				111, 114, 109, 97, 116, 0, 0, 0, 0, 54,
				76, 105, 118, 46, 78, 97, 116, 105, 118, 101,
				65, 117, 100, 105, 111, 66, 114, 105, 100, 103,
				101, 46, 78, 97, 116, 105, 118, 101, 65, 117,
				100, 105, 111, 80, 108, 97, 121, 101, 114, 87,
				105, 110, 100, 111, 119, 115, 124, 87, 97, 118,
				101, 72, 100, 114, 0, 0, 0, 0, 38, 76,
				105, 118, 46, 78, 97, 116, 105, 118, 101, 65,
				117, 100, 105, 111, 66, 114, 105, 100, 103, 101,
				124, 78, 97, 116, 105, 118, 101, 65, 117, 100,
				105, 111, 85, 116, 105, 108, 115
			},
			TotalFiles = 4,
			TotalTypes = 7,
			IsEditorOnly = false
		};
	}
}
namespace Liv.NativeAudioBridge;

public interface INativeAudioPlayer : IDisposable
{
	void PreloadAudioClip(AudioClip audioClip, float volume, bool forceReload = false);

	void PlayAudioClip(AudioClip audioClip, float volume);

	void StopAllAudio();
}
public static class NativeAudioPlayerFactory
{
	public static INativeAudioPlayer CreateNativeAudioPlayer()
	{
		return new NativeAudioPlayerWindows();
	}
}
public class NativeAudioPlayerWindows : INativeAudioPlayer, IDisposable
{
	private delegate void WaveOutProc(IntPtr hwo, int uMsg, int dwInstance, int dwParam1, int dwParam2);

	private struct PreloadedAudio
	{
		public GCHandle DataHandle;

		public WaveFormat Format;

		public int BufferLength;
	}

	private struct WaveFormat
	{
		public short wFormatTag;

		public short nChannels;

		public int nSamplesPerSec;

		public int nAvgBytesPerSec;

		public short nBlockAlign;

		public short wBitsPerSample;

		public short cbSize;
	}

	private struct WaveHdr
	{
		public IntPtr lpData;

		public int dwBufferLength;

		public int dwBytesRecorded;

		public IntPtr dwUser;

		public int dwFlags;

		public int dwLoops;

		public IntPtr lpNext;

		public int reserved;
	}

	private static byte[] _audioByteDataArray;

	private const int BitsPerSample = 16;

	private const string Lib = "winmm.dll";

	private bool _disposed;

	private Dictionary<int, PreloadedAudio> _audioClips = new Dictionary<int, PreloadedAudio>();

	[DllImport("winmm.dll")]
	private static extern int waveOutOpen(out IntPtr hWaveOut, int uDeviceID, WaveFormat lpFormat, WaveOutProc dwCallback, int dwInstance, int dwFlags);

	[DllImport("winmm.dll")]
	private static extern int waveOutPrepareHeader(IntPtr hWaveOut, ref WaveHdr lpWaveOutHdr, int uSize);

	[DllImport("winmm.dll")]
	private static extern int waveOutWrite(IntPtr hWaveOut, ref WaveHdr lpWaveOutHdr, int uSize);

	[DllImport("winmm.dll")]
	private static extern int waveOutUnprepareHeader(IntPtr hWaveOut, ref WaveHdr lpWaveOutHdr, int uSize);

	[DllImport("winmm.dll")]
	private static extern int waveOutClose(IntPtr hWaveOut);

	public void PreloadAudioClip(AudioClip audioClip, float volume, bool forceReload = false)
	{
		ValidateAudioClipForPreloading(audioClip);
		PreloadAudioClip(audioClip.GetHashCode(), PrepareAudioData(audioClip, volume), audioClip.frequency, audioClip.channels, 16, forceReload);
	}

	public void PlayAudioClip(AudioClip audioClip, float volume = 1f)
	{
		if (!audioClip)
		{
			throw new InvalidOperationException("LCK: Native Audio can not play AudioClip, audio clip is null.");
		}
		int audioClipId = audioClip.GetHashCode();
		if (!_audioClips.ContainsKey(audioClipId))
		{
			PreloadAudioClip(audioClipId, PrepareAudioData(audioClip, volume), audioClip.frequency, audioClip.channels, 16, forceReload: false);
		}
		Task.Run(async delegate
		{
			await PlayAudio(audioClipId);
		});
	}

	public void StopAllAudio()
	{
		throw new NotImplementedException();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool disposing)
	{
		if (_disposed)
		{
			return;
		}
		foreach (KeyValuePair<int, PreloadedAudio> audioClip in _audioClips)
		{
			if (audioClip.Value.DataHandle.IsAllocated)
			{
				audioClip.Value.DataHandle.Free();
			}
		}
		_audioClips.Clear();
		_disposed = true;
	}

	~NativeAudioPlayerWindows()
	{
		Dispose(disposing: false);
	}

	private void ValidateAudioClipForPreloading(AudioClip audioClip)
	{
		if (!audioClip)
		{
			throw new InvalidOperationException("Native Audio can not preload AudioClip, audio clip is null.");
		}
	}

	private void PreloadAudioClip(int key, byte[] audioData, int sampleRate, int channels, int bitsPerSample, bool forceReload)
	{
		if (forceReload || !_audioClips.ContainsKey(key))
		{
			if (forceReload && _audioClips.ContainsKey(key))
			{
				UnloadAudioClip(key);
			}
			WaveFormat format = new WaveFormat
			{
				wFormatTag = 1,
				nChannels = (short)channels,
				nSamplesPerSec = sampleRate,
				wBitsPerSample = (short)bitsPerSample,
				nBlockAlign = (short)(channels * bitsPerSample / 8),
				nAvgBytesPerSec = sampleRate * channels * bitsPerSample / 8,
				cbSize = 0
			};
			GCHandle dataHandle = GCHandle.Alloc(audioData, GCHandleType.Pinned);
			_audioClips[key] = new PreloadedAudio
			{
				DataHandle = dataHandle,
				BufferLength = audioData.Length,
				Format = format
			};
		}
	}

	private void UnloadAudioClip(int audioClipKey)
	{
		int hashCode = audioClipKey.GetHashCode();
		if (!_audioClips.ContainsKey(hashCode))
		{
			throw new InvalidOperationException($"LCK: Native Audio cannot unload AudioClip ({audioClipKey}), it is not preloaded.");
		}
		PreloadedAudio preloadedAudio = _audioClips[hashCode];
		if (preloadedAudio.DataHandle.IsAllocated)
		{
			preloadedAudio.DataHandle.Free();
		}
		_audioClips.Remove(hashCode);
	}

	private static byte[] PrepareAudioData(AudioClip clip, float volume)
	{
		return ConvertAudioClipToByteArray(clip, volume);
	}

	private static byte[] ConvertAudioClipToByteArray(AudioClip clip, float volume)
	{
		float[] array = new float[clip.samples * clip.channels];
		clip.GetData(array, 0);
		byte[] array2 = new byte[array.Length * 2];
		int num = 32767;
		for (int i = 0; i < array.Length; i++)
		{
			short num2 = (short)(Mathf.Clamp(array[i] * volume, -1f, 1f) * (float)num);
			array2[i * 2] = (byte)(num2 & 0xFF);
			array2[i * 2 + 1] = (byte)((num2 & 0xFF00) >> 8);
		}
		return array2;
	}

	private Task PlayAudio(int audioClipId)
	{
		PreloadedAudio preloadedAudio = _audioClips[audioClipId];
		if (waveOutOpen(out var hWaveOut, -1, preloadedAudio.Format, null, 0, 0) != 0)
		{
			throw new InvalidOperationException("Failed to open waveform audio device.");
		}
		WaveHdr lpWaveOutHdr = new WaveHdr
		{
			lpData = preloadedAudio.DataHandle.AddrOfPinnedObject(),
			dwBufferLength = preloadedAudio.BufferLength,
			dwFlags = 0,
			dwLoops = 0,
			dwUser = GCHandle.ToIntPtr(preloadedAudio.DataHandle)
		};
		waveOutPrepareHeader(hWaveOut, ref lpWaveOutHdr, Marshal.SizeOf(lpWaveOutHdr));
		waveOutWrite(hWaveOut, ref lpWaveOutHdr, Marshal.SizeOf(lpWaveOutHdr));
		while ((lpWaveOutHdr.dwFlags & 1) != 1)
		{
			Thread.Sleep(100);
		}
		waveOutUnprepareHeader(hWaveOut, ref lpWaveOutHdr, Marshal.SizeOf(lpWaveOutHdr));
		waveOutClose(hWaveOut);
		return Task.CompletedTask;
	}
}
public static class NativeAudioUtils
{
	public static sbyte[] ConvertAudioClipToByteArray(AudioClip audioClip, float volume = 1f)
	{
		float[] array = new float[audioClip.samples * audioClip.channels];
		audioClip.GetData(array, 0);
		sbyte[] array2 = new sbyte[array.Length * 2];
		int num = 32767;
		for (int i = 0; i < array.Length; i++)
		{
			short num2 = (short)(Mathf.Clamp(array[i] * volume, -1f, 1f) * (float)num);
			array2[i * 2] = (sbyte)(num2 & 0xFF);
			array2[i * 2 + 1] = (sbyte)((num2 & 0xFF00) >> 8);
		}
		return array2;
	}
}
