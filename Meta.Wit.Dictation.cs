using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Meta.Voice.Net.WebSockets;
using Meta.WitAi.Configuration;
using Meta.WitAi.Data;
using Meta.WitAi.Data.Configuration;
using Meta.WitAi.Dictation;
using Meta.WitAi.Dictation.Data;
using Meta.WitAi.Dictation.Events;
using Meta.WitAi.Events;
using Meta.WitAi.Events.UnityEventListeners;
using Meta.WitAi.Interfaces;
using Meta.WitAi.Requests;
using Meta.WitAi.Utilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

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
			FilePathsData = new byte[1420]
			{
				0, 0, 0, 1, 0, 0, 0, 163, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 118, 111, 105, 99,
				101, 64, 100, 51, 102, 54, 102, 51, 55, 98,
				56, 101, 49, 99, 92, 70, 101, 97, 116, 117,
				114, 101, 115, 92, 68, 105, 99, 116, 97, 116,
				105, 111, 110, 92, 115, 111, 117, 114, 99, 101,
				92, 76, 105, 98, 92, 87, 105, 116, 46, 97,
				105, 92, 70, 101, 97, 116, 117, 114, 101, 115,
				92, 100, 105, 99, 116, 97, 116, 105, 111, 110,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 68, 105, 99,
				116, 97, 116, 105, 111, 110, 92, 68, 97, 116,
				97, 92, 68, 105, 99, 116, 97, 116, 105, 111,
				110, 83, 101, 115, 115, 105, 111, 110, 46, 99,
				115, 0, 0, 0, 2, 0, 0, 0, 158, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 118, 111, 105,
				99, 101, 64, 100, 51, 102, 54, 102, 51, 55,
				98, 56, 101, 49, 99, 92, 70, 101, 97, 116,
				117, 114, 101, 115, 92, 68, 105, 99, 116, 97,
				116, 105, 111, 110, 92, 115, 111, 117, 114, 99,
				101, 92, 76, 105, 98, 92, 87, 105, 116, 46,
				97, 105, 92, 70, 101, 97, 116, 117, 114, 101,
				115, 92, 100, 105, 99, 116, 97, 116, 105, 111,
				110, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 68, 105,
				99, 116, 97, 116, 105, 111, 110, 92, 68, 105,
				99, 116, 97, 116, 105, 111, 110, 83, 101, 114,
				118, 105, 99, 101, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 164, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 118, 111, 105, 99, 101, 64, 100,
				51, 102, 54, 102, 51, 55, 98, 56, 101, 49,
				99, 92, 70, 101, 97, 116, 117, 114, 101, 115,
				92, 68, 105, 99, 116, 97, 116, 105, 111, 110,
				92, 115, 111, 117, 114, 99, 101, 92, 76, 105,
				98, 92, 87, 105, 116, 46, 97, 105, 92, 70,
				101, 97, 116, 117, 114, 101, 115, 92, 100, 105,
				99, 116, 97, 116, 105, 111, 110, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 68, 105, 99, 116, 97, 116,
				105, 111, 110, 92, 69, 118, 101, 110, 116, 115,
				92, 68, 105, 99, 116, 97, 116, 105, 111, 110,
				69, 118, 101, 110, 116, 115, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 170, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 118, 111, 105, 99, 101,
				64, 100, 51, 102, 54, 102, 51, 55, 98, 56,
				101, 49, 99, 92, 70, 101, 97, 116, 117, 114,
				101, 115, 92, 68, 105, 99, 116, 97, 116, 105,
				111, 110, 92, 115, 111, 117, 114, 99, 101, 92,
				76, 105, 98, 92, 87, 105, 116, 46, 97, 105,
				92, 70, 101, 97, 116, 117, 114, 101, 115, 92,
				100, 105, 99, 116, 97, 116, 105, 111, 110, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 68, 105, 99, 116,
				97, 116, 105, 111, 110, 92, 69, 118, 101, 110,
				116, 115, 92, 68, 105, 99, 116, 97, 116, 105,
				111, 110, 83, 101, 115, 115, 105, 111, 110, 69,
				118, 101, 110, 116, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 167, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 118, 111, 105, 99, 101, 64, 100,
				51, 102, 54, 102, 51, 55, 98, 56, 101, 49,
				99, 92, 70, 101, 97, 116, 117, 114, 101, 115,
				92, 68, 105, 99, 116, 97, 116, 105, 111, 110,
				92, 115, 111, 117, 114, 99, 101, 92, 76, 105,
				98, 92, 87, 105, 116, 46, 97, 105, 92, 70,
				101, 97, 116, 117, 114, 101, 115, 92, 100, 105,
				99, 116, 97, 116, 105, 111, 110, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 68, 105, 99, 116, 97, 116,
				105, 111, 110, 92, 77, 117, 108, 116, 105, 82,
				101, 113, 117, 101, 115, 116, 84, 114, 97, 110,
				115, 99, 114, 105, 112, 116, 105, 111, 110, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 195,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 118, 111,
				105, 99, 101, 64, 100, 51, 102, 54, 102, 51,
				55, 98, 56, 101, 49, 99, 92, 70, 101, 97,
				116, 117, 114, 101, 115, 92, 68, 105, 99, 116,
				97, 116, 105, 111, 110, 92, 115, 111, 117, 114,
				99, 101, 92, 76, 105, 98, 92, 87, 105, 116,
				46, 97, 105, 92, 70, 101, 97, 116, 117, 114,
				101, 115, 92, 100, 105, 99, 116, 97, 116, 105,
				111, 110, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 68,
				105, 99, 116, 97, 116, 105, 111, 110, 92, 83,
				101, 114, 118, 105, 99, 101, 82, 101, 102, 101,
				114, 101, 110, 99, 101, 115, 92, 68, 105, 99,
				116, 97, 116, 105, 111, 110, 83, 101, 114, 118,
				105, 99, 101, 65, 117, 100, 105, 111, 69, 118,
				101, 110, 116, 82, 101, 102, 101, 114, 101, 110,
				99, 101, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 185, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 118, 111, 105, 99, 101, 64, 100, 51, 102,
				54, 102, 51, 55, 98, 56, 101, 49, 99, 92,
				70, 101, 97, 116, 117, 114, 101, 115, 92, 68,
				105, 99, 116, 97, 116, 105, 111, 110, 92, 115,
				111, 117, 114, 99, 101, 92, 76, 105, 98, 92,
				87, 105, 116, 46, 97, 105, 92, 70, 101, 97,
				116, 117, 114, 101, 115, 92, 100, 105, 99, 116,
				97, 116, 105, 111, 110, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 68, 105, 99, 116, 97, 116, 105, 111,
				110, 92, 83, 101, 114, 118, 105, 99, 101, 82,
				101, 102, 101, 114, 101, 110, 99, 101, 115, 92,
				68, 105, 99, 116, 97, 116, 105, 111, 110, 83,
				101, 114, 118, 105, 99, 101, 82, 101, 102, 101,
				114, 101, 110, 99, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 154, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 118, 111, 105, 99, 101, 64,
				100, 51, 102, 54, 102, 51, 55, 98, 56, 101,
				49, 99, 92, 70, 101, 97, 116, 117, 114, 101,
				115, 92, 68, 105, 99, 116, 97, 116, 105, 111,
				110, 92, 115, 111, 117, 114, 99, 101, 92, 76,
				105, 98, 92, 87, 105, 116, 46, 97, 105, 92,
				70, 101, 97, 116, 117, 114, 101, 115, 92, 100,
				105, 99, 116, 97, 116, 105, 111, 110, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 68, 105, 99, 116, 97,
				116, 105, 111, 110, 92, 87, 105, 116, 68, 105,
				99, 116, 97, 116, 105, 111, 110, 46, 99, 115
			},
			TypesData = new byte[443]
			{
				0, 0, 0, 0, 42, 77, 101, 116, 97, 46,
				87, 105, 116, 65, 105, 46, 68, 105, 99, 116,
				97, 116, 105, 111, 110, 46, 68, 97, 116, 97,
				124, 68, 105, 99, 116, 97, 116, 105, 111, 110,
				83, 101, 115, 115, 105, 111, 110, 0, 0, 0,
				0, 37, 77, 101, 116, 97, 46, 87, 105, 116,
				65, 105, 46, 68, 105, 99, 116, 97, 116, 105,
				111, 110, 124, 68, 105, 99, 116, 97, 116, 105,
				111, 110, 83, 101, 114, 118, 105, 99, 101, 0,
				0, 0, 0, 38, 77, 101, 116, 97, 46, 87,
				105, 116, 65, 105, 46, 68, 105, 99, 116, 97,
				116, 105, 111, 110, 124, 73, 68, 105, 99, 116,
				97, 116, 105, 111, 110, 83, 101, 114, 118, 105,
				99, 101, 0, 0, 0, 0, 43, 77, 101, 116,
				97, 46, 87, 105, 116, 65, 105, 46, 68, 105,
				99, 116, 97, 116, 105, 111, 110, 46, 69, 118,
				101, 110, 116, 115, 124, 68, 105, 99, 116, 97,
				116, 105, 111, 110, 69, 118, 101, 110, 116, 115,
				0, 0, 0, 0, 49, 77, 101, 116, 97, 46,
				87, 105, 116, 65, 105, 46, 68, 105, 99, 116,
				97, 116, 105, 111, 110, 46, 69, 118, 101, 110,
				116, 115, 124, 68, 105, 99, 116, 97, 116, 105,
				111, 110, 83, 101, 115, 115, 105, 111, 110, 69,
				118, 101, 110, 116, 0, 0, 0, 0, 46, 77,
				101, 116, 97, 46, 87, 105, 116, 65, 105, 46,
				68, 105, 99, 116, 97, 116, 105, 111, 110, 124,
				77, 117, 108, 116, 105, 82, 101, 113, 117, 101,
				115, 116, 84, 114, 97, 110, 115, 99, 114, 105,
				112, 116, 105, 111, 110, 0, 0, 0, 0, 64,
				77, 101, 116, 97, 46, 87, 105, 116, 65, 105,
				46, 83, 101, 114, 118, 105, 99, 101, 82, 101,
				102, 101, 114, 101, 110, 99, 101, 115, 124, 68,
				105, 99, 116, 97, 116, 105, 111, 110, 83, 101,
				114, 118, 105, 99, 101, 65, 117, 100, 105, 111,
				69, 118, 101, 110, 116, 82, 101, 102, 101, 114,
				101, 110, 99, 101, 0, 0, 0, 0, 46, 77,
				101, 116, 97, 46, 87, 105, 116, 65, 105, 46,
				85, 116, 105, 108, 105, 116, 105, 101, 115, 124,
				68, 105, 99, 116, 97, 116, 105, 111, 110, 83,
				101, 114, 118, 105, 99, 101, 82, 101, 102, 101,
				114, 101, 110, 99, 101, 0, 0, 0, 0, 33,
				77, 101, 116, 97, 46, 87, 105, 116, 65, 105,
				46, 68, 105, 99, 116, 97, 116, 105, 111, 110,
				124, 87, 105, 116, 68, 105, 99, 116, 97, 116,
				105, 111, 110
			},
			TotalFiles = 8,
			TotalTypes = 9,
			IsEditorOnly = false
		};
	}
}
namespace Meta.WitAi.Utilities
{
	[Serializable]
	public struct DictationServiceReference
	{
		[SerializeField]
		internal DictationService dictationService;

		public DictationService DictationService
		{
			get
			{
				if (!dictationService)
				{
					DictationService[] array = Resources.FindObjectsOfTypeAll<DictationService>();
					if (array != null)
					{
						dictationService = Array.Find(array, (DictationService o) => o.gameObject.scene.rootCount != 0);
					}
				}
				return dictationService;
			}
		}
	}
}
namespace Meta.WitAi.ServiceReferences
{
	public class DictationServiceAudioEventReference : AudioInputServiceReference
	{
		[SerializeField]
		private DictationServiceReference _dictationServiceReference;

		public override IAudioInputEvents AudioEvents => _dictationServiceReference.DictationService.AudioEvents;
	}
}
namespace Meta.WitAi.Dictation
{
	public abstract class DictationService : BaseSpeechService, IDictationService, ITelemetryEventsProvider, IAudioEventProvider, ITranscriptionEventProvider
	{
		[Tooltip("Events that will fire before, during and after an activation")]
		[SerializeField]
		protected DictationEvents dictationEvents = new DictationEvents();

		protected TelemetryEvents telemetryEvents = new TelemetryEvents();

		public virtual bool IsRequestActive => Active;

		public abstract ITranscriptionProvider TranscriptionProvider { get; set; }

		public abstract bool MicActive { get; }

		public virtual DictationEvents DictationEvents
		{
			get
			{
				return dictationEvents;
			}
			set
			{
				dictationEvents = value;
			}
		}

		public TelemetryEvents TelemetryEvents
		{
			get
			{
				return telemetryEvents;
			}
			set
			{
				telemetryEvents = value;
			}
		}

		public IAudioInputEvents AudioEvents => DictationEvents;

		public ITranscriptionEvent TranscriptionEvents => DictationEvents;

		protected abstract bool ShouldSendMicData { get; }

		protected override SpeechEvents GetSpeechEvents()
		{
			return DictationEvents;
		}

		public void Activate()
		{
			Activate(new WitRequestOptions(), new VoiceServiceRequestEvents());
		}

		public void Activate(WitRequestOptions requestOptions)
		{
			Activate(requestOptions, new VoiceServiceRequestEvents());
		}

		public VoiceServiceRequest Activate(VoiceServiceRequestEvents requestEvents)
		{
			return Activate(new WitRequestOptions(), requestEvents);
		}

		public abstract VoiceServiceRequest Activate(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents);

		public void ActivateImmediately()
		{
			ActivateImmediately(new WitRequestOptions(), new VoiceServiceRequestEvents());
		}

		public void ActivateImmediately(WitRequestOptions requestOptions)
		{
			ActivateImmediately(requestOptions, new VoiceServiceRequestEvents());
		}

		public VoiceServiceRequest ActivateImmediately(VoiceServiceRequestEvents requestEvents)
		{
			return ActivateImmediately(new WitRequestOptions(), requestEvents);
		}

		public abstract VoiceServiceRequest ActivateImmediately(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents);

		public abstract void Cancel();

		protected virtual void Awake()
		{
			if (!GetComponent<AudioEventListener>())
			{
				base.gameObject.AddComponent<AudioEventListener>();
			}
			if (!GetComponent<TranscriptionEventListener>())
			{
				base.gameObject.AddComponent<TranscriptionEventListener>();
			}
		}
	}
	public interface IDictationService : ITelemetryEventsProvider
	{
		bool Active { get; }

		bool IsRequestActive { get; }

		bool MicActive { get; }

		ITranscriptionProvider TranscriptionProvider { get; set; }

		DictationEvents DictationEvents { get; set; }

		new TelemetryEvents TelemetryEvents { get; set; }

		VoiceServiceRequest Activate(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents);

		VoiceServiceRequest ActivateImmediately(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents);

		void Deactivate();

		void Cancel();
	}
	public class MultiRequestTranscription : MonoBehaviour
	{
		[SerializeField]
		private DictationService witDictation;

		[SerializeField]
		private int linesBetweenActivations = 2;

		[Multiline]
		[SerializeField]
		private string activationSeparator = string.Empty;

		[Header("Events")]
		[SerializeField]
		private WitTranscriptionEvent onTranscriptionUpdated = new WitTranscriptionEvent();

		private StringBuilder _text;

		private string _activeText;

		private bool _newSection;

		private StringBuilder _separator;

		private void Awake()
		{
			if (!witDictation)
			{
				witDictation = UnityEngine.Object.FindAnyObjectByType<DictationService>();
			}
			_text = new StringBuilder();
			_separator = new StringBuilder();
			for (int i = 0; i < linesBetweenActivations; i++)
			{
				_separator.AppendLine();
			}
			if (!string.IsNullOrEmpty(activationSeparator))
			{
				_separator.Append(activationSeparator);
			}
		}

		private void OnEnable()
		{
			witDictation.DictationEvents.OnFullTranscription.AddListener(OnFullTranscription);
			witDictation.DictationEvents.OnPartialTranscription.AddListener(OnPartialTranscription);
			witDictation.DictationEvents.OnAborting.AddListener(OnCancelled);
		}

		private void OnDisable()
		{
			_activeText = string.Empty;
			witDictation.DictationEvents.OnFullTranscription.RemoveListener(OnFullTranscription);
			witDictation.DictationEvents.OnPartialTranscription.RemoveListener(OnPartialTranscription);
			witDictation.DictationEvents.OnAborting.RemoveListener(OnCancelled);
		}

		private void OnCancelled()
		{
			_activeText = string.Empty;
			OnTranscriptionUpdated();
		}

		private void OnFullTranscription(string text)
		{
			_activeText = string.Empty;
			if (_text.Length > 0)
			{
				_text.Append(_separator);
			}
			_text.Append(text);
			OnTranscriptionUpdated();
		}

		private void OnPartialTranscription(string text)
		{
			_activeText = text;
			OnTranscriptionUpdated();
		}

		public void Clear()
		{
			_text.Clear();
			onTranscriptionUpdated.Invoke(string.Empty);
		}

		private void OnTranscriptionUpdated()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(_text);
			if (!string.IsNullOrEmpty(_activeText))
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(_separator);
				}
				if (!string.IsNullOrEmpty(_activeText))
				{
					stringBuilder.Append(_activeText);
				}
			}
			onTranscriptionUpdated.Invoke(stringBuilder.ToString());
		}
	}
	public class WitDictation : DictationService, IWitRuntimeConfigProvider, IVoiceEventProvider, IVoiceServiceRequestProvider, IWitConfigurationProvider
	{
		[SerializeField]
		private WitRuntimeConfiguration witRuntimeConfiguration;

		private WitService witService;

		private readonly VoiceEvents _voiceEvents = new VoiceEvents();

		public WitRuntimeConfiguration RuntimeConfiguration
		{
			get
			{
				return witRuntimeConfiguration;
			}
			set
			{
				witRuntimeConfiguration = value;
			}
		}

		public WitConfiguration Configuration => RuntimeConfiguration?.witConfiguration;

		public override bool Active
		{
			get
			{
				if (null != witService)
				{
					return witService.Active;
				}
				return false;
			}
		}

		public override bool IsRequestActive
		{
			get
			{
				if (null != witService)
				{
					return witService.IsRequestActive;
				}
				return false;
			}
		}

		public override ITranscriptionProvider TranscriptionProvider
		{
			get
			{
				return witService.TranscriptionProvider;
			}
			set
			{
				witService.TranscriptionProvider = value;
			}
		}

		public override bool MicActive
		{
			get
			{
				if (null != witService)
				{
					return witService.MicActive;
				}
				return false;
			}
		}

		protected override bool ShouldSendMicData
		{
			get
			{
				if (!witRuntimeConfiguration.sendAudioToWit)
				{
					return TranscriptionProvider == null;
				}
				return true;
			}
		}

		public VoiceEvents VoiceEvents => _voiceEvents;

		public override DictationEvents DictationEvents
		{
			get
			{
				return dictationEvents;
			}
			set
			{
				DictationEvents listener = dictationEvents;
				dictationEvents = value;
				if (base.gameObject.activeSelf)
				{
					VoiceEvents.RemoveListener(listener);
					VoiceEvents.AddListener(dictationEvents);
				}
			}
		}

		public VoiceServiceRequest CreateRequest(WitRuntimeConfiguration requestSettings, WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents)
		{
			WitConfiguration witConfiguration = requestSettings?.witConfiguration;
			if (witConfiguration != null && witConfiguration.RequestType == WitRequestType.WebSocket)
			{
				return WitSocketRequest.GetDictationRequest(witConfiguration, GetComponent<WitWebSocketAdapter>(), AudioBuffer.Instance, requestOptions, requestEvents);
			}
			return witConfiguration.CreateDictationRequest(requestOptions, requestEvents);
		}

		public override VoiceServiceRequest Activate(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents)
		{
			SetupRequestParameters(ref requestOptions, ref requestEvents);
			return witService.Activate(requestOptions, requestEvents);
		}

		public override VoiceServiceRequest ActivateImmediately(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents)
		{
			SetupRequestParameters(ref requestOptions, ref requestEvents);
			return witService.ActivateImmediately(requestOptions, requestEvents);
		}

		public override void Deactivate()
		{
			witService.Deactivate();
		}

		public override void Cancel()
		{
			witService.DeactivateAndAbortRequest();
		}

		protected override void Awake()
		{
			base.Awake();
			witService = base.gameObject.AddComponent<WitService>();
			witService.VoiceEventProvider = this;
			witService.ConfigurationProvider = this;
			witService.RequestProvider = this;
			witService.TelemetryEventsProvider = this;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			VoiceEvents.AddListener(DictationEvents);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			VoiceEvents.RemoveListener(DictationEvents);
		}

		public void TranscribeFile(string fileName)
		{
			if (CreateRequest(witRuntimeConfiguration, new WitRequestOptions(), new VoiceServiceRequestEvents()) is WitRequest witRequest)
			{
				byte[] postData = File.ReadAllBytes(fileName);
				witRequest.postData = postData;
				witService.ExecuteRequest(witRequest);
			}
		}
	}
}
namespace Meta.WitAi.Dictation.Events
{
	[Serializable]
	public class DictationEvents : SpeechEvents
	{
		private const string EVENT_CATEGORY_DICTATION_EVENTS = "Dictation Events";

		[Tooltip("Called when an individual dictation session has started. This can include multiple server activations if dictation is set up to automatically reactivate when the server endpoints an utterance.")]
		[EventCategory("Dictation Events")]
		[FormerlySerializedAs("onDictationSessionStarted")]
		[SerializeField]
		[HideInInspector]
		private DictationSessionEvent _onDictationSessionStarted = new DictationSessionEvent();

		[Tooltip("Called when a dictation is completed after Deactivate has been called or auto-reactivate is disabled.")]
		[EventCategory("Dictation Events")]
		[FormerlySerializedAs("onDictationSessionStopped")]
		[SerializeField]
		[HideInInspector]
		private DictationSessionEvent _onDictationSessionStopped = new DictationSessionEvent();

		public DictationSessionEvent OnDictationSessionStarted => _onDictationSessionStarted;

		public DictationSessionEvent OnDictationSessionStopped => _onDictationSessionStopped;

		[Obsolete("Deprecated for 'OnDictationSessionStarted' event")]
		public DictationSessionEvent onDictationSessionStarted => OnDictationSessionStarted;

		[Obsolete("Deprecated for 'OnDictationSessionStopped' event")]
		public DictationSessionEvent onDictationSessionStopped => OnDictationSessionStopped;

		[Obsolete("Deprecated for 'OnStartListening' event")]
		public UnityEvent onStart => base.OnStartListening;

		[Obsolete("Deprecated for 'OnStoppedListening' event")]
		public UnityEvent onStopped => base.OnStoppedListening;

		[Obsolete("Deprecated for 'OnMicLevelChanged' event")]
		public WitMicLevelChangedEvent onMicAudioLevel => base.OnMicLevelChanged;

		[Obsolete("Deprecated for 'OnError' event")]
		public WitErrorEvent onError => base.OnError;

		[Obsolete("Deprecated for 'OnResponse' event")]
		public WitResponseEvent onResponse => base.OnResponse;
	}
	[Serializable]
	public class DictationSessionEvent : UnityEvent<DictationSession>
	{
	}
}
namespace Meta.WitAi.Dictation.Data
{
	[Serializable]
	public class DictationSession : VoiceSession
	{
		public IDictationService dictationService;

		public string[] clientRequestId;

		public string sessionId = WitConstants.GetUniqueId();
	}
}
