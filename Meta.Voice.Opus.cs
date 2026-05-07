using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
			FilePathsData = new byte[384]
			{
				0, 0, 0, 1, 0, 0, 0, 120, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 118, 111, 105, 99,
				101, 64, 100, 51, 102, 54, 102, 51, 55, 98,
				56, 101, 49, 99, 92, 76, 105, 98, 92, 87,
				105, 116, 46, 97, 105, 92, 76, 105, 98, 92,
				116, 104, 105, 114, 100, 45, 112, 97, 114, 116,
				121, 92, 85, 110, 105, 116, 121, 79, 112, 117,
				115, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 68, 101,
				99, 111, 100, 101, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 120, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 118, 111, 105, 99, 101, 64,
				100, 51, 102, 54, 102, 51, 55, 98, 56, 101,
				49, 99, 92, 76, 105, 98, 92, 87, 105, 116,
				46, 97, 105, 92, 76, 105, 98, 92, 116, 104,
				105, 114, 100, 45, 112, 97, 114, 116, 121, 92,
				85, 110, 105, 116, 121, 79, 112, 117, 115, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 69, 110, 99, 111,
				100, 101, 114, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 120, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 118, 111, 105, 99, 101, 64, 100, 51,
				102, 54, 102, 51, 55, 98, 56, 101, 49, 99,
				92, 76, 105, 98, 92, 87, 105, 116, 46, 97,
				105, 92, 76, 105, 98, 92, 116, 104, 105, 114,
				100, 45, 112, 97, 114, 116, 121, 92, 85, 110,
				105, 116, 121, 79, 112, 117, 115, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 76, 105, 98, 114, 97, 114,
				121, 46, 99, 115
			},
			TypesData = new byte[99]
			{
				0, 0, 0, 0, 28, 77, 101, 116, 97, 46,
				86, 111, 105, 99, 101, 46, 85, 110, 105, 116,
				121, 79, 112, 117, 115, 124, 68, 101, 99, 111,
				100, 101, 114, 0, 0, 0, 0, 28, 77, 101,
				116, 97, 46, 86, 111, 105, 99, 101, 46, 85,
				110, 105, 116, 121, 79, 112, 117, 115, 124, 69,
				110, 99, 111, 100, 101, 114, 0, 0, 0, 0,
				28, 77, 101, 116, 97, 46, 86, 111, 105, 99,
				101, 46, 85, 110, 105, 116, 121, 79, 112, 117,
				115, 124, 76, 105, 98, 114, 97, 114, 121
			},
			TotalFiles = 3,
			TotalTypes = 3,
			IsEditorOnly = false
		};
	}
}
namespace Meta.Voice.UnityOpus;

public class Decoder : IDisposable
{
	public const int maximumPacketDuration = 5760;

	private IntPtr decoder;

	private readonly NumChannels channels;

	private readonly float[] softclipMem;

	private bool disposedValue;

	public Decoder(SamplingFrequency samplingFrequency, NumChannels channels)
	{
		this.channels = channels;
		decoder = Library.OpusDecoderCreate(samplingFrequency, channels, out var error);
		if (error != ErrorCode.OK)
		{
			UnityEngine.Debug.LogError("[UnityOpus] Failed to create Decoder. Error code is " + error);
			decoder = IntPtr.Zero;
		}
		softclipMem = new float[(int)channels];
	}

	public int Decode(byte[] data, int dataLength, float[] pcm, int decodeFec = 0)
	{
		if (decoder == IntPtr.Zero)
		{
			return 0;
		}
		int num = Library.OpusDecodeFloat(decoder, data, dataLength, pcm, pcm.Length / (int)channels, decodeFec);
		Library.OpusPcmSoftClip(pcm, num / (int)channels, channels, softclipMem);
		return num;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue && !(decoder == IntPtr.Zero))
		{
			Library.OpusDecoderDestroy(decoder);
			decoder = IntPtr.Zero;
			disposedValue = true;
		}
	}

	~Decoder()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
public class Encoder : IDisposable
{
	private int bitrate;

	private int complexity;

	private OpusSignal signal;

	private IntPtr encoder;

	private NumChannels channels;

	private bool disposedValue;

	public int Bitrate
	{
		get
		{
			return bitrate;
		}
		set
		{
			Library.OpusEncoderSetBitrate(encoder, value);
			bitrate = value;
		}
	}

	public int Complexity
	{
		get
		{
			return complexity;
		}
		set
		{
			Library.OpusEncoderSetComplexity(encoder, value);
			complexity = value;
		}
	}

	public OpusSignal Signal
	{
		get
		{
			return signal;
		}
		set
		{
			Library.OpusEncoderSetSignal(encoder, value);
			signal = value;
		}
	}

	public Encoder(SamplingFrequency samplingFrequency, NumChannels channels, OpusApplication application)
	{
		this.channels = channels;
		encoder = Library.OpusEncoderCreate(samplingFrequency, channels, application, out var error);
		if (error != ErrorCode.OK)
		{
			UnityEngine.Debug.LogError("[UnityOpus] Failed to init encoder. Error code: " + error);
			encoder = IntPtr.Zero;
		}
	}

	public int Encode(float[] pcm, byte[] output)
	{
		if (encoder == IntPtr.Zero)
		{
			return 0;
		}
		return Library.OpusEncodeFloat(encoder, pcm, pcm.Length / (int)channels, output, output.Length);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue && !(encoder == IntPtr.Zero))
		{
			Library.OpusEncoderDestroy(encoder);
			encoder = IntPtr.Zero;
			disposedValue = true;
		}
	}

	~Encoder()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
public enum SamplingFrequency
{
	Frequency_8000 = 8000,
	Frequency_12000 = 12000,
	Frequency_16000 = 16000,
	Frequency_24000 = 24000,
	Frequency_48000 = 48000
}
public enum NumChannels
{
	Mono = 1,
	Stereo
}
public enum OpusApplication
{
	VoIP = 2048,
	Audio = 2049,
	RestrictedLowDelay = 2051
}
public enum OpusSignal
{
	Auto = -1000,
	Voice = 3001,
	Music = 3002
}
public enum ErrorCode
{
	OK = 0,
	BadArg = -1,
	BufferTooSmall = -2,
	InternalError = -3,
	InvalidPacket = -4,
	Unimplemented = -5,
	InvalidState = -6,
	AllocFail = -7
}
public class Library
{
	public const int maximumPacketDuration = 5760;

	private const string dllName = "UnityOpus";

	[DllImport("UnityOpus")]
	public static extern IntPtr OpusEncoderCreate(SamplingFrequency samplingFrequency, NumChannels channels, OpusApplication application, out ErrorCode error);

	[DllImport("UnityOpus")]
	public static extern int OpusEncode(IntPtr encoder, short[] pcm, int frameSize, byte[] data, int maxDataBytes);

	[DllImport("UnityOpus")]
	public static extern int OpusEncodeFloat(IntPtr encoder, float[] pcm, int frameSize, byte[] data, int maxDataBytes);

	[DllImport("UnityOpus")]
	public static extern void OpusEncoderDestroy(IntPtr encoder);

	[DllImport("UnityOpus")]
	public static extern int OpusEncoderSetBitrate(IntPtr encoder, int bitrate);

	[DllImport("UnityOpus")]
	public static extern int OpusEncoderSetComplexity(IntPtr encoder, int complexity);

	[DllImport("UnityOpus")]
	public static extern int OpusEncoderSetSignal(IntPtr encoder, OpusSignal signal);

	[DllImport("UnityOpus")]
	public static extern IntPtr OpusDecoderCreate(SamplingFrequency samplingFrequency, NumChannels channels, out ErrorCode error);

	[DllImport("UnityOpus")]
	public static extern int OpusDecode(IntPtr decoder, byte[] data, int len, short[] pcm, int frameSize, int decodeFec);

	[DllImport("UnityOpus")]
	public static extern int OpusDecodeFloat(IntPtr decoder, byte[] data, int len, float[] pcm, int frameSize, int decodeFec);

	[DllImport("UnityOpus")]
	public static extern void OpusDecoderDestroy(IntPtr decoder);

	[DllImport("UnityOpus")]
	public static extern void OpusPcmSoftClip(float[] pcm, int frameSize, NumChannels channels, float[] softclipMem);
}
