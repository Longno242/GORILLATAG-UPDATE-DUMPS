using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Oculus.Assistant.VoiceCommand.Configuration;
using Oculus.Assistant.VoiceCommand.Data;
using Oculus.Voice.Core.Utilities;
using UnityEngine;
using UnityEngine.Events;

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
			FilePathsData = new byte[480]
			{
				0, 0, 0, 1, 0, 0, 0, 113, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 118, 111, 105, 99,
				101, 64, 100, 51, 102, 54, 102, 51, 55, 98,
				56, 101, 49, 99, 92, 76, 105, 98, 92, 67,
				111, 109, 109, 111, 110, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 67, 111, 110, 102, 105, 103, 117, 114,
				97, 116, 105, 111, 110, 92, 86, 111, 105, 99,
				101, 67, 111, 109, 109, 97, 110, 100, 46, 99,
				115, 0, 0, 0, 2, 0, 0, 0, 110, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 118, 111, 105,
				99, 101, 64, 100, 51, 102, 54, 102, 51, 55,
				98, 56, 101, 49, 99, 92, 76, 105, 98, 92,
				67, 111, 109, 109, 111, 110, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 68, 97, 116, 97, 92, 86, 111,
				105, 99, 101, 67, 111, 109, 109, 97, 110, 100,
				82, 101, 115, 117, 108, 116, 46, 99, 115, 0,
				0, 0, 4, 0, 0, 0, 108, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 118, 111, 105, 99, 101,
				64, 100, 51, 102, 54, 102, 51, 55, 98, 56,
				101, 49, 99, 92, 76, 105, 98, 92, 67, 111,
				109, 109, 111, 110, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 76, 105, 115, 116, 101, 110, 101, 114, 115,
				92, 83, 108, 111, 116, 72, 97, 110, 100, 108,
				101, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 117, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 118, 111, 105, 99, 101, 64, 100, 51, 102,
				54, 102, 51, 55, 98, 56, 101, 49, 99, 92,
				76, 105, 98, 92, 67, 111, 109, 109, 111, 110,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 76, 105, 115,
				116, 101, 110, 101, 114, 115, 92, 86, 111, 105,
				99, 101, 67, 111, 109, 109, 97, 110, 100, 76,
				105, 115, 116, 101, 110, 101, 114, 46, 99, 115
			},
			TypesData = new byte[512]
			{
				0, 0, 0, 0, 56, 79, 99, 117, 108, 117,
				115, 46, 65, 115, 115, 105, 115, 116, 97, 110,
				116, 46, 86, 111, 105, 99, 101, 67, 111, 109,
				109, 97, 110, 100, 46, 67, 111, 110, 102, 105,
				103, 117, 114, 97, 116, 105, 111, 110, 124, 86,
				111, 105, 99, 101, 67, 111, 109, 109, 97, 110,
				100, 0, 0, 0, 0, 53, 79, 99, 117, 108,
				117, 115, 46, 65, 115, 115, 105, 115, 116, 97,
				110, 116, 46, 86, 111, 105, 99, 101, 67, 111,
				109, 109, 97, 110, 100, 46, 68, 97, 116, 97,
				124, 86, 111, 105, 99, 101, 67, 111, 109, 109,
				97, 110, 100, 82, 101, 115, 117, 108, 116, 0,
				0, 0, 0, 61, 79, 99, 117, 108, 117, 115,
				46, 65, 115, 115, 105, 115, 116, 97, 110, 116,
				46, 86, 111, 105, 99, 101, 67, 111, 109, 109,
				97, 110, 100, 46, 68, 97, 116, 97, 46, 86,
				111, 105, 99, 101, 67, 111, 109, 109, 97, 110,
				100, 82, 101, 115, 117, 108, 116, 124, 66, 117,
				105, 108, 100, 101, 114, 0, 0, 0, 0, 51,
				79, 99, 117, 108, 117, 115, 46, 65, 115, 115,
				105, 115, 116, 97, 110, 116, 46, 86, 111, 105,
				99, 101, 67, 111, 109, 109, 97, 110, 100, 46,
				76, 105, 115, 116, 101, 110, 101, 114, 115, 124,
				83, 108, 111, 116, 72, 97, 110, 100, 108, 101,
				114, 0, 0, 0, 0, 65, 79, 99, 117, 108,
				117, 115, 46, 65, 115, 115, 105, 115, 116, 97,
				110, 116, 46, 86, 111, 105, 99, 101, 67, 111,
				109, 109, 97, 110, 100, 46, 76, 105, 115, 116,
				101, 110, 101, 114, 115, 124, 86, 111, 105, 99,
				101, 67, 111, 109, 109, 97, 110, 100, 82, 101,
				115, 117, 108, 116, 72, 97, 110, 100, 108, 101,
				114, 0, 0, 0, 0, 61, 79, 99, 117, 108,
				117, 115, 46, 65, 115, 115, 105, 115, 116, 97,
				110, 116, 46, 86, 111, 105, 99, 101, 67, 111,
				109, 109, 97, 110, 100, 46, 76, 105, 115, 116,
				101, 110, 101, 114, 115, 124, 79, 110, 67, 111,
				109, 109, 97, 110, 100, 83, 108, 111, 116, 82,
				101, 99, 101, 105, 118, 101, 100, 0, 0, 0,
				0, 65, 79, 99, 117, 108, 117, 115, 46, 65,
				115, 115, 105, 115, 116, 97, 110, 116, 46, 86,
				111, 105, 99, 101, 67, 111, 109, 109, 97, 110,
				100, 46, 76, 105, 115, 116, 101, 110, 101, 114,
				115, 124, 86, 111, 105, 99, 101, 67, 111, 109,
				109, 97, 110, 100, 67, 97, 108, 108, 98, 97,
				99, 107, 69, 118, 101, 110, 116, 0, 0, 0,
				0, 60, 79, 99, 117, 108, 117, 115, 46, 65,
				115, 115, 105, 115, 116, 97, 110, 116, 46, 86,
				111, 105, 99, 101, 67, 111, 109, 109, 97, 110,
				100, 46, 76, 105, 115, 116, 101, 110, 101, 114,
				115, 124, 86, 111, 105, 99, 101, 67, 111, 109,
				109, 97, 110, 100, 76, 105, 115, 116, 101, 110,
				101, 114
			},
			TotalFiles = 4,
			TotalTypes = 8,
			IsEditorOnly = false
		};
	}
}
namespace Oculus.Assistant.VoiceCommand.Listeners
{
	[Serializable]
	public class SlotHandler
	{
		[Tooltip("The name of the slot to listen for")]
		public string slotName;

		public OnCommandSlotReceived onCommandSlotReceived = new OnCommandSlotReceived();

		public override string ToString()
		{
			return slotName;
		}
	}
	[Serializable]
	public class VoiceCommandResultHandler : VoiceCommandListener
	{
		public Oculus.Assistant.VoiceCommand.Configuration.VoiceCommand voiceCommand;

		public VoiceCommandCallbackEvent onVoiceCommandReceived = new VoiceCommandCallbackEvent();

		[ArrayElementTitle("slotName", "Unassigned Slot")]
		public SlotHandler[] slotHandlers = Array.Empty<SlotHandler>();

		public void OnCallback(VoiceCommandResult result)
		{
			if (!(voiceCommand.actionId == result.ActionId))
			{
				return;
			}
			onVoiceCommandReceived.Invoke(result);
			SlotHandler[] array = slotHandlers;
			foreach (SlotHandler slotHandler in array)
			{
				if (result.TryGetSlot(slotHandler.slotName, out var slotValue))
				{
					slotHandler.onCommandSlotReceived.Invoke(slotValue);
				}
			}
		}
	}
	[Serializable]
	public class OnCommandSlotReceived : UnityEvent<string>
	{
	}
	[Serializable]
	public class VoiceCommandCallbackEvent : UnityEvent<VoiceCommandResult>
	{
	}
	public interface VoiceCommandListener
	{
		void OnCallback(VoiceCommandResult result);
	}
}
namespace Oculus.Assistant.VoiceCommand.Data
{
	public class VoiceCommandResult
	{
		public abstract class Builder
		{
			public abstract string ActionId { get; }

			public abstract byte[] CommandOutput { get; }

			public abstract string InteractionId { get; }

			public abstract string DebugPhraseMatched { get; }

			public abstract string Utterance { get; }

			public abstract Dictionary<string, string> SlotValues { get; }

			public virtual VoiceCommandResult Build()
			{
				return new VoiceCommandResult
				{
					actionId = ActionId,
					commandOutput = CommandOutput,
					interactionId = InteractionId,
					debugPhraseMatched = DebugPhraseMatched,
					utterance = Utterance,
					slotValues = SlotValues
				};
			}
		}

		private string actionId;

		private byte[] commandOutput;

		private string utterance;

		private string interactionId;

		private string debugPhraseMatched;

		private Dictionary<string, string> slotValues;

		public string ActionId => actionId;

		public byte[] CommandOutput => commandOutput;

		public string InteractionId => interactionId;

		public string DebugPhraseMatched => debugPhraseMatched;

		public string Utterance => utterance;

		public Dictionary<string, string> MatchedSlots => slotValues;

		public string this[string slotName]
		{
			get
			{
				if (!slotValues.TryGetValue(slotName, out var value))
				{
					return null;
				}
				return value;
			}
		}

		public override string ToString()
		{
			string text = "{\n  actionId = " + actionId + ",\n  commandOutput = " + ((commandOutput != null) ? (commandOutput.Length + " bytes") : "null") + ",\n  interactionId = " + interactionId + ",\n  utterance = " + utterance + ",\n  matchedSlots = [";
			foreach (KeyValuePair<string, string> slotValue in slotValues)
			{
				text = text + "\n    " + slotValue.Key + " = " + slotValue.Value + ",";
			}
			text += "\n  ]";
			return text + "\n}";
		}

		public bool TryGetSlot(string slotName, out string slotValue)
		{
			return slotValues.TryGetValue(slotName, out slotValue);
		}

		public bool HasSlot(string slotName)
		{
			return slotValues.ContainsKey(slotName);
		}
	}
}
namespace Oculus.Assistant.VoiceCommand.Configuration
{
	[CreateAssetMenu(fileName = "Action-VoiceCommandActionName", menuName = "Voice SDK/Voice Command Action")]
	public class VoiceCommand : ScriptableObject
	{
		public string actionId;

		public virtual byte[] InputData { get; }

		public override string ToString()
		{
			return base.name;
		}
	}
}
