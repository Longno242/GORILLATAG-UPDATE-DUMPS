using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("VoiceSDK.Telemetry")]
[assembly: InternalsVisibleTo("Meta.WitAi.Tests.Editor")]
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
			FilePathsData = new byte[707]
			{
				0, 0, 0, 1, 0, 0, 0, 106, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 118, 111, 105, 99,
				101, 64, 100, 51, 102, 54, 102, 51, 55, 98,
				56, 101, 49, 99, 92, 76, 105, 98, 92, 84,
				101, 108, 101, 109, 101, 116, 114, 121, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 73, 84, 101, 108, 101,
				109, 101, 116, 114, 121, 87, 114, 105, 116, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 101, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				118, 111, 105, 99, 101, 64, 100, 51, 102, 54,
				102, 51, 55, 98, 56, 101, 49, 99, 92, 76,
				105, 98, 92, 84, 101, 108, 101, 109, 101, 116,
				114, 121, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 79,
				112, 101, 114, 97, 116, 105, 111, 110, 73, 68,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				106, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 118,
				111, 105, 99, 101, 64, 100, 51, 102, 54, 102,
				51, 55, 98, 56, 101, 49, 99, 92, 76, 105,
				98, 92, 84, 101, 108, 101, 109, 101, 116, 114,
				121, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 82, 117,
				110, 116, 105, 109, 101, 84, 101, 108, 101, 109,
				101, 116, 114, 121, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 112, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 118, 111, 105, 99, 101, 64, 100,
				51, 102, 54, 102, 51, 55, 98, 56, 101, 49,
				99, 92, 76, 105, 98, 92, 84, 101, 108, 101,
				109, 101, 116, 114, 121, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 84, 114, 97, 99, 105, 110, 103, 92,
				73, 84, 114, 97, 99, 101, 80, 114, 111, 118,
				105, 100, 101, 114, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 124, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 118, 111, 105, 99, 101, 64, 100,
				51, 102, 54, 102, 51, 55, 98, 56, 101, 49,
				99, 92, 76, 105, 98, 92, 84, 101, 108, 101,
				109, 101, 116, 114, 121, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 84, 114, 97, 99, 105, 110, 103, 92,
				85, 110, 105, 116, 121, 80, 114, 111, 102, 105,
				108, 101, 114, 84, 114, 97, 99, 101, 80, 114,
				111, 118, 105, 100, 101, 114, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 110, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 118, 111, 105, 99, 101,
				64, 100, 51, 102, 54, 102, 51, 55, 98, 56,
				101, 49, 99, 92, 76, 105, 98, 92, 84, 101,
				108, 101, 109, 101, 116, 114, 121, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 84, 114, 97, 99, 105, 110,
				103, 92, 86, 115, 100, 107, 80, 114, 111, 102,
				105, 108, 101, 114, 46, 99, 115
			},
			TypesData = new byte[362]
			{
				0, 0, 0, 0, 46, 77, 101, 116, 97, 46,
				86, 111, 105, 99, 101, 46, 84, 101, 108, 101,
				109, 101, 116, 114, 121, 85, 116, 105, 108, 105,
				116, 105, 101, 115, 124, 73, 84, 101, 108, 101,
				109, 101, 116, 114, 121, 87, 114, 105, 116, 101,
				114, 0, 0, 0, 0, 41, 77, 101, 116, 97,
				46, 86, 111, 105, 99, 101, 46, 84, 101, 108,
				101, 109, 101, 116, 114, 121, 85, 116, 105, 108,
				105, 116, 105, 101, 115, 124, 79, 112, 101, 114,
				97, 116, 105, 111, 110, 73, 68, 0, 0, 0,
				0, 46, 77, 101, 116, 97, 46, 86, 111, 105,
				99, 101, 46, 84, 101, 108, 101, 109, 101, 116,
				114, 121, 85, 116, 105, 108, 105, 116, 105, 101,
				115, 124, 82, 117, 110, 116, 105, 109, 101, 84,
				101, 108, 101, 109, 101, 116, 114, 121, 0, 0,
				0, 0, 63, 77, 101, 116, 97, 46, 86, 111,
				105, 99, 101, 46, 84, 101, 108, 101, 109, 101,
				116, 114, 121, 85, 116, 105, 108, 105, 116, 105,
				101, 115, 46, 80, 101, 114, 102, 111, 114, 109,
				97, 110, 99, 101, 84, 114, 97, 99, 105, 110,
				103, 124, 73, 84, 114, 97, 99, 101, 80, 114,
				111, 118, 105, 100, 101, 114, 0, 0, 0, 0,
				75, 77, 101, 116, 97, 46, 86, 111, 105, 99,
				101, 46, 84, 101, 108, 101, 109, 101, 116, 114,
				121, 85, 116, 105, 108, 105, 116, 105, 101, 115,
				46, 80, 101, 114, 102, 111, 114, 109, 97, 110,
				99, 101, 84, 114, 97, 99, 105, 110, 103, 124,
				85, 110, 105, 116, 121, 80, 114, 111, 102, 105,
				108, 101, 114, 84, 114, 97, 99, 101, 80, 114,
				111, 118, 105, 100, 101, 114, 0, 0, 0, 0,
				61, 77, 101, 116, 97, 46, 86, 111, 105, 99,
				101, 46, 84, 101, 108, 101, 109, 101, 116, 114,
				121, 85, 116, 105, 108, 105, 116, 105, 101, 115,
				46, 80, 101, 114, 102, 111, 114, 109, 97, 110,
				99, 101, 84, 114, 97, 99, 105, 110, 103, 124,
				86, 115, 100, 107, 80, 114, 111, 102, 105, 108,
				101, 114
			},
			TotalFiles = 6,
			TotalTypes = 6,
			IsEditorOnly = false
		};
	}
}
namespace Meta.Voice.TelemetryUtilities
{
	public interface ITelemetryWriter
	{
		void StartEvent(OperationID operationId, RuntimeTelemetryEventType runtimeTelemetryEventType);

		void LogEventTermination(OperationID operationId, TerminationReason reason = TerminationReason.Successful, string message = "");

		void LogInstantaneousEvent(OperationID operationId, RuntimeTelemetryEventType runtimeTelemetryEventType, Dictionary<string, string> annotations = null);

		void LogPoint(OperationID operationId, RuntimeTelemetryPoint point);

		void AnnotateEvent(OperationID operationID, string annotationKey, string annotationValue);
	}
	public readonly struct OperationID
	{
		public static readonly OperationID INVALID;

		private string Value { get; }

		public bool IsAssigned => Value != null;

		public OperationID(string value)
		{
			if (value == null)
			{
				value = Guid.NewGuid().ToString();
			}
			Value = value;
		}

		public static OperationID Create(string value = null)
		{
			return new OperationID(value);
		}

		public override string ToString()
		{
			return Value;
		}

		public static implicit operator string(OperationID correlationId)
		{
			return correlationId.Value;
		}

		public static explicit operator OperationID(string value)
		{
			return new OperationID(value);
		}

		public static implicit operator OperationID(Guid value)
		{
			return new OperationID(value.ToString());
		}

		public override bool Equals(object obj)
		{
			if (obj is OperationID operationID)
			{
				return Value == operationID.Value;
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (IsAssigned)
			{
				return Value.GetHashCode();
			}
			return 0;
		}
	}
	public class RuntimeTelemetry : ITelemetryWriter
	{
		private readonly List<ITelemetryWriter> _writers = new List<ITelemetryWriter>();

		public static RuntimeTelemetry Instance { get; } = new RuntimeTelemetry();

		internal RuntimeTelemetry()
		{
		}

		public void RegisterWriter(ITelemetryWriter writer)
		{
			_writers.Add(writer);
		}

		public void StartEvent(OperationID operationId, RuntimeTelemetryEventType runtimeTelemetryEventType)
		{
			foreach (ITelemetryWriter writer in _writers)
			{
				writer.StartEvent(operationId, runtimeTelemetryEventType);
			}
		}

		public void LogEventTermination(OperationID operationId, TerminationReason reason = TerminationReason.Successful, string message = "")
		{
			foreach (ITelemetryWriter writer in _writers)
			{
				writer.LogEventTermination(operationId, reason, message);
			}
		}

		public void LogInstantaneousEvent(OperationID operationId, RuntimeTelemetryEventType runtimeTelemetryEventType, Dictionary<string, string> annotations = null)
		{
			foreach (ITelemetryWriter writer in _writers)
			{
				writer.LogInstantaneousEvent(operationId, runtimeTelemetryEventType, annotations);
			}
		}

		public void LogPoint(OperationID operationId, RuntimeTelemetryPoint point)
		{
			foreach (ITelemetryWriter writer in _writers)
			{
				writer.LogPoint(operationId, point);
			}
		}

		public void LogPoint(string operationId, RuntimeTelemetryPoint point)
		{
			LogPoint((OperationID)operationId, point);
		}

		public void AnnotateEvent(OperationID operationID, string annotationKey, string annotationValue)
		{
			foreach (ITelemetryWriter writer in _writers)
			{
				writer.AnnotateEvent(operationID, annotationKey, annotationValue);
			}
		}
	}
	public enum RuntimeTelemetryEventType
	{
		Global,
		VoiceServiceRequest,
		Llm,
		TtsRequest,
		Conversation
	}
	public enum RuntimeTelemetryPoint
	{
		MicOn,
		ListeningStarted,
		AudioBlockSent,
		PartialResponseReceived,
		FullResponseReceived,
		FirstPartialTranscriptionReceivedByClient,
		FullTranscriptionReceivedByClient,
		FullUserTranscriptionSentToServer,
		FirstPartialTranscriptionReceivedFromClient,
		FullUserTranscriptionReceivedFromClient,
		FullUserTranscriptionSentFromServer,
		FirstPartialTextResponseSentToServer,
		FullTextResponseSentToServer,
		PartialTTSSent,
		FullTTSSent,
		PartialTTSAudioReceived,
		FinalTTSAudioReceived,
		FirstPartialAudioDecode,
		FinalAudioDecode,
		FirstPartialAudioSentToClient,
		FinalAudioSentToClient,
		FirstPartialAudioFromServer,
		FinalAudioFromServer,
		PlaybackStarted,
		PlaybackStopped,
		TtsLoadBegin,
		TtsLoadComplete,
		ListeningStopped,
		FinalAudioSamplesEmpty,
		FinalAudioEventsEmpty
	}
	public enum TerminationReason
	{
		Undetermined,
		Successful,
		Failed,
		Canceled
	}
}
namespace Meta.Voice.TelemetryUtilities.PerformanceTracing
{
	public interface ITraceProvider
	{
		void BeginSample(string sampleName);

		void EndSample(string sampleName);
	}
	public class UnityProfilerTraceProvider : ITraceProvider
	{
		public void BeginSample(string sampleName)
		{
		}

		public void EndSample(string sampleName)
		{
		}
	}
	public static class VsdkProfiler
	{
		public static ITraceProvider traceProvider = new UnityProfilerTraceProvider();

		public static bool profilingEnabled = false;

		public static void BeginSample(string sampleName)
		{
			if (profilingEnabled)
			{
				traceProvider.BeginSample(sampleName);
			}
		}

		public static void EndSample(string sampleName)
		{
			if (profilingEnabled)
			{
				traceProvider.EndSample(sampleName);
			}
		}
	}
}
