using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using Meta.Voice;
using Meta.WitAi;
using Meta.WitAi.Configuration;
using Meta.WitAi.Data.Configuration;
using Meta.WitAi.Dictation;
using Meta.WitAi.Dictation.Data;
using Meta.WitAi.Dictation.Events;
using Meta.WitAi.Events;
using Meta.WitAi.Interfaces;
using Meta.WitAi.Json;
using Meta.WitAi.Requests;
using Oculus.Voice.Core.Bindings.Android;
using Oculus.Voice.Core.Bindings.Android.PlatformLogger;
using Oculus.Voice.Core.Bindings.Interfaces;
using Oculus.Voice.Dictation.Bindings.Android;
using Oculus.Voice.Dictation.Configuration;
using Oculus.VoiceSDK.Utilities;
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
			FilePathsData = new byte[1483]
			{
				0, 0, 0, 1, 0, 0, 0, 142, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 118, 111, 105, 99,
				101, 64, 100, 51, 102, 54, 102, 51, 55, 98,
				56, 101, 49, 99, 92, 70, 101, 97, 116, 117,
				114, 101, 115, 92, 68, 105, 99, 116, 97, 116,
				105, 111, 110, 92, 115, 111, 117, 114, 99, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 65, 80, 73,
				92, 67, 111, 110, 102, 105, 103, 117, 114, 97,
				116, 105, 111, 110, 92, 68, 105, 99, 116, 97,
				116, 105, 111, 110, 67, 111, 110, 102, 105, 103,
				117, 114, 97, 116, 105, 111, 110, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 133, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 118, 111, 105, 99,
				101, 64, 100, 51, 102, 54, 102, 51, 55, 98,
				56, 101, 49, 99, 92, 70, 101, 97, 116, 117,
				114, 101, 115, 92, 68, 105, 99, 116, 97, 116,
				105, 111, 110, 92, 115, 111, 117, 114, 99, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 65, 80, 73,
				92, 76, 105, 115, 116, 101, 110, 101, 114, 115,
				92, 68, 105, 99, 116, 97, 116, 105, 111, 110,
				76, 105, 115, 116, 101, 110, 101, 114, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 136, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 118, 111, 105,
				99, 101, 64, 100, 51, 102, 54, 102, 51, 55,
				98, 56, 101, 49, 99, 92, 70, 101, 97, 116,
				117, 114, 101, 115, 92, 68, 105, 99, 116, 97,
				116, 105, 111, 110, 92, 115, 111, 117, 114, 99,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 65, 80,
				73, 92, 83, 101, 114, 118, 105, 99, 101, 92,
				65, 112, 112, 68, 105, 99, 116, 97, 116, 105,
				111, 110, 69, 120, 112, 101, 114, 105, 101, 110,
				99, 101, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 148, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 118, 111, 105, 99, 101, 64, 100, 51, 102,
				54, 102, 51, 55, 98, 56, 101, 49, 99, 92,
				70, 101, 97, 116, 117, 114, 101, 115, 92, 68,
				105, 99, 116, 97, 116, 105, 111, 110, 92, 115,
				111, 117, 114, 99, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 66, 105, 110, 100, 105, 110, 103, 115,
				92, 65, 110, 100, 114, 111, 105, 100, 92, 68,
				105, 99, 116, 97, 116, 105, 111, 110, 67, 111,
				110, 102, 105, 103, 117, 114, 97, 116, 105, 111,
				110, 66, 105, 110, 100, 105, 110, 103, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 143, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 118, 111, 105,
				99, 101, 64, 100, 51, 102, 54, 102, 51, 55,
				98, 56, 101, 49, 99, 92, 70, 101, 97, 116,
				117, 114, 101, 115, 92, 68, 105, 99, 116, 97,
				116, 105, 111, 110, 92, 115, 111, 117, 114, 99,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 66, 105,
				110, 100, 105, 110, 103, 115, 92, 65, 110, 100,
				114, 111, 105, 100, 92, 68, 105, 99, 116, 97,
				116, 105, 111, 110, 76, 105, 115, 116, 101, 110,
				101, 114, 66, 105, 110, 100, 105, 110, 103, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 133,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 118, 111,
				105, 99, 101, 64, 100, 51, 102, 54, 102, 51,
				55, 98, 56, 101, 49, 99, 92, 70, 101, 97,
				116, 117, 114, 101, 115, 92, 68, 105, 99, 116,
				97, 116, 105, 111, 110, 92, 115, 111, 117, 114,
				99, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 66,
				105, 110, 100, 105, 110, 103, 115, 92, 65, 110,
				100, 114, 111, 105, 100, 92, 73, 83, 101, 114,
				118, 105, 99, 101, 69, 118, 101, 110, 116, 115,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				140, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 118,
				111, 105, 99, 101, 64, 100, 51, 102, 54, 102,
				51, 55, 98, 56, 101, 49, 99, 92, 70, 101,
				97, 116, 117, 114, 101, 115, 92, 68, 105, 99,
				116, 97, 116, 105, 111, 110, 92, 115, 111, 117,
				114, 99, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				66, 105, 110, 100, 105, 110, 103, 115, 92, 65,
				110, 100, 114, 111, 105, 100, 92, 80, 108, 97,
				116, 102, 111, 114, 109, 68, 105, 99, 116, 97,
				116, 105, 111, 110, 73, 109, 112, 108, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 146, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 118, 111, 105,
				99, 101, 64, 100, 51, 102, 54, 102, 51, 55,
				98, 56, 101, 49, 99, 92, 70, 101, 97, 116,
				117, 114, 101, 115, 92, 68, 105, 99, 116, 97,
				116, 105, 111, 110, 92, 115, 111, 117, 114, 99,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 66, 105,
				110, 100, 105, 110, 103, 115, 92, 65, 110, 100,
				114, 111, 105, 100, 92, 80, 108, 97, 116, 102,
				111, 114, 109, 68, 105, 99, 116, 97, 116, 105,
				111, 110, 83, 68, 75, 66, 105, 110, 100, 105,
				110, 103, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 143, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 118, 111, 105, 99, 101, 64, 100, 51, 102,
				54, 102, 51, 55, 98, 56, 101, 49, 99, 92,
				70, 101, 97, 116, 117, 114, 101, 115, 92, 68,
				105, 99, 116, 97, 116, 105, 111, 110, 92, 115,
				111, 117, 114, 99, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 66, 105, 110, 100, 105, 110, 103, 115,
				92, 65, 110, 100, 114, 111, 105, 100, 92, 80,
				108, 97, 116, 102, 111, 114, 109, 68, 105, 99,
				116, 97, 116, 105, 111, 110, 83, 101, 115, 115,
				105, 111, 110, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 139, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 118, 111, 105, 99, 101, 64, 100, 51,
				102, 54, 102, 51, 55, 98, 56, 101, 49, 99,
				92, 70, 101, 97, 116, 117, 114, 101, 115, 92,
				68, 105, 99, 116, 97, 116, 105, 111, 110, 92,
				115, 111, 117, 114, 99, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 68, 97, 116, 97, 92, 87, 105,
				116, 68, 105, 99, 116, 97, 116, 105, 111, 110,
				82, 117, 110, 116, 105, 109, 101, 67, 111, 110,
				102, 105, 103, 117, 114, 97, 116, 105, 111, 110,
				46, 99, 115
			},
			TypesData = new byte[640]
			{
				0, 0, 0, 0, 59, 79, 99, 117, 108, 117,
				115, 46, 86, 111, 105, 99, 101, 46, 68, 105,
				99, 116, 97, 116, 105, 111, 110, 46, 67, 111,
				110, 102, 105, 103, 117, 114, 97, 116, 105, 111,
				110, 124, 68, 105, 99, 116, 97, 116, 105, 111,
				110, 67, 111, 110, 102, 105, 103, 117, 114, 97,
				116, 105, 111, 110, 0, 0, 0, 0, 50, 79,
				99, 117, 108, 117, 115, 46, 86, 111, 105, 99,
				101, 46, 68, 105, 99, 116, 97, 116, 105, 111,
				110, 46, 76, 105, 115, 116, 101, 110, 101, 114,
				115, 124, 68, 105, 99, 116, 97, 116, 105, 111,
				110, 76, 105, 115, 116, 101, 110, 101, 114, 0,
				0, 0, 0, 45, 79, 99, 117, 108, 117, 115,
				46, 86, 111, 105, 99, 101, 46, 68, 105, 99,
				116, 97, 116, 105, 111, 110, 124, 65, 112, 112,
				68, 105, 99, 116, 97, 116, 105, 111, 110, 69,
				120, 112, 101, 114, 105, 101, 110, 99, 101, 0,
				0, 0, 0, 69, 79, 99, 117, 108, 117, 115,
				46, 86, 111, 105, 99, 101, 46, 68, 105, 99,
				116, 97, 116, 105, 111, 110, 46, 66, 105, 110,
				100, 105, 110, 103, 115, 46, 65, 110, 100, 114,
				111, 105, 100, 124, 68, 105, 99, 116, 97, 116,
				105, 111, 110, 67, 111, 110, 102, 105, 103, 117,
				114, 97, 116, 105, 111, 110, 66, 105, 110, 100,
				105, 110, 103, 0, 0, 0, 0, 64, 79, 99,
				117, 108, 117, 115, 46, 86, 111, 105, 99, 101,
				46, 68, 105, 99, 116, 97, 116, 105, 111, 110,
				46, 66, 105, 110, 100, 105, 110, 103, 115, 46,
				65, 110, 100, 114, 111, 105, 100, 124, 68, 105,
				99, 116, 97, 116, 105, 111, 110, 76, 105, 115,
				116, 101, 110, 101, 114, 66, 105, 110, 100, 105,
				110, 103, 0, 0, 0, 0, 54, 79, 99, 117,
				108, 117, 115, 46, 86, 111, 105, 99, 101, 46,
				68, 105, 99, 116, 97, 116, 105, 111, 110, 46,
				66, 105, 110, 100, 105, 110, 103, 115, 46, 65,
				110, 100, 114, 111, 105, 100, 124, 73, 83, 101,
				114, 118, 105, 99, 101, 69, 118, 101, 110, 116,
				115, 0, 0, 0, 0, 61, 79, 99, 117, 108,
				117, 115, 46, 86, 111, 105, 99, 101, 46, 68,
				105, 99, 116, 97, 116, 105, 111, 110, 46, 66,
				105, 110, 100, 105, 110, 103, 115, 46, 65, 110,
				100, 114, 111, 105, 100, 124, 80, 108, 97, 116,
				102, 111, 114, 109, 68, 105, 99, 116, 97, 116,
				105, 111, 110, 73, 109, 112, 108, 0, 0, 0,
				0, 67, 79, 99, 117, 108, 117, 115, 46, 86,
				111, 105, 99, 101, 46, 68, 105, 99, 116, 97,
				116, 105, 111, 110, 46, 66, 105, 110, 100, 105,
				110, 103, 115, 46, 65, 110, 100, 114, 111, 105,
				100, 124, 80, 108, 97, 116, 102, 111, 114, 109,
				68, 105, 99, 116, 97, 116, 105, 111, 110, 83,
				68, 75, 66, 105, 110, 100, 105, 110, 103, 0,
				0, 0, 0, 64, 79, 99, 117, 108, 117, 115,
				46, 86, 111, 105, 99, 101, 46, 68, 105, 99,
				116, 97, 116, 105, 111, 110, 46, 66, 105, 110,
				100, 105, 110, 103, 115, 46, 65, 110, 100, 114,
				111, 105, 100, 124, 80, 108, 97, 116, 102, 111,
				114, 109, 68, 105, 99, 116, 97, 116, 105, 111,
				110, 83, 101, 115, 115, 105, 111, 110, 0, 0,
				0, 0, 57, 77, 101, 116, 97, 46, 87, 105,
				116, 65, 105, 46, 67, 111, 110, 102, 105, 103,
				117, 114, 97, 116, 105, 111, 110, 124, 87, 105,
				116, 68, 105, 99, 116, 97, 116, 105, 111, 110,
				82, 117, 110, 116, 105, 109, 101, 67, 111, 110,
				102, 105, 103, 117, 114, 97, 116, 105, 111, 110
			},
			TotalFiles = 10,
			TotalTypes = 10,
			IsEditorOnly = false
		};
	}
}
namespace Meta.WitAi.Configuration
{
	[Serializable]
	public class WitDictationRuntimeConfiguration : WitRuntimeConfiguration
	{
		[Header("Dictation")]
		[SerializeField]
		public DictationConfiguration dictationConfiguration;

		protected override Vector2 RecordingTimeRange => new Vector2(-1f, 300f);
	}
}
namespace Oculus.Voice.Dictation
{
	public class AppDictationExperience : DictationService, IWitRuntimeConfigProvider, IWitConfigurationProvider
	{
		[SerializeField]
		private WitDictationRuntimeConfiguration runtimeConfiguration;

		[Tooltip("Uses platform dictation service instead of accessing wit directly from within the application.")]
		[SerializeField]
		private bool usePlatformServices;

		[Tooltip("Dictation will not fallback to Wit if platform dictation is not available. Not applicable in Unity Editor")]
		[SerializeField]
		private bool doNotFallbackToWit;

		[Tooltip("Enables logs related to the interaction to be displayed on console")]
		[SerializeField]
		private bool enableConsoleLogging;

		private IDictationService _dictationServiceImpl;

		private IVoiceSDKLogger _voiceSDKLogger;

		private bool _isActive;

		private DictationSession _activeSession;

		private WitRequestOptions _activeRequestOptions;

		public WitRuntimeConfiguration RuntimeConfiguration => runtimeConfiguration;

		public WitDictationRuntimeConfiguration RuntimeDictationConfiguration
		{
			get
			{
				return runtimeConfiguration;
			}
			set
			{
				runtimeConfiguration = value;
			}
		}

		public WitConfiguration Configuration => RuntimeConfiguration?.witConfiguration;

		public DictationSession ActiveSession => _activeSession;

		public WitRequestOptions ActiveRequestOptions => _activeRequestOptions;

		private static string PACKAGE_VERSION => VoiceSDKConstants.SdkVersion;

		public bool HasPlatformIntegrations => false;

		public bool UsePlatformIntegrations
		{
			get
			{
				return usePlatformServices;
			}
			set
			{
				if (usePlatformServices != value || HasPlatformIntegrations != value)
				{
					usePlatformServices = value;
				}
			}
		}

		public bool DoNotFallbackToWit
		{
			get
			{
				return doNotFallbackToWit;
			}
			set
			{
				doNotFallbackToWit = value;
			}
		}

		public override bool Active
		{
			get
			{
				if (_dictationServiceImpl != null)
				{
					return _dictationServiceImpl.Active;
				}
				return false;
			}
		}

		public override bool IsRequestActive
		{
			get
			{
				if (_dictationServiceImpl != null)
				{
					return _dictationServiceImpl.IsRequestActive;
				}
				return false;
			}
		}

		public override ITranscriptionProvider TranscriptionProvider
		{
			get
			{
				return _dictationServiceImpl.TranscriptionProvider;
			}
			set
			{
				_dictationServiceImpl.TranscriptionProvider = value;
			}
		}

		public override bool MicActive
		{
			get
			{
				if (_dictationServiceImpl != null)
				{
					return _dictationServiceImpl.MicActive;
				}
				return false;
			}
		}

		protected override bool ShouldSendMicData
		{
			get
			{
				if (!RuntimeConfiguration.sendAudioToWit)
				{
					return TranscriptionProvider == null;
				}
				return true;
			}
		}

		public event Action OnInitialized;

		private void InitDictation()
		{
			if (string.IsNullOrEmpty(PACKAGE_VERSION))
			{
				VLog.E("No SDK Version Set");
			}
			if (!UsePlatformIntegrations)
			{
				if (_dictationServiceImpl is PlatformDictationImpl)
				{
					((PlatformDictationImpl)_dictationServiceImpl).Disconnect();
				}
				if (_voiceSDKLogger is VoiceSDKPlatformLoggerImpl)
				{
					try
					{
						((VoiceSDKPlatformLoggerImpl)_voiceSDKLogger).Disconnect();
					}
					catch (Exception ex)
					{
						VLog.E("Disconnection error: " + ex.Message);
					}
				}
			}
			_voiceSDKLogger = new VoiceSDKConsoleLoggerImpl();
			RevertToWitDictation();
			_voiceSDKLogger.WitApplication = RuntimeDictationConfiguration?.witConfiguration?.GetLoggerAppId();
			_voiceSDKLogger.ShouldLogToConsole = enableConsoleLogging;
			this.OnInitialized?.Invoke();
		}

		private void OnPlatformServiceNotAvailable()
		{
			if (DoNotFallbackToWit)
			{
				VLog.D("Platform dictation service unavailable. Falling back to WitDictation is disabled");
				DictationEvents.OnError?.Invoke("Platform dictation unavailable", "Platform dictation service is not available");
			}
			else
			{
				VLog.D("Platform dictation service unavailable. Falling back to WitDictation");
				RevertToWitDictation();
			}
		}

		private void OnDictationServiceNotAvailable()
		{
			VLog.D("Dictation service unavailable");
			DictationEvents.OnError?.Invoke("Dictation unavailable", "Dictation service is not available");
		}

		private void RevertToWitDictation()
		{
			WitDictation witDictation = GetComponent<WitDictation>();
			if (null == witDictation)
			{
				witDictation = base.gameObject.AddComponent<WitDictation>();
				witDictation.hideFlags = HideFlags.HideInInspector;
			}
			witDictation.RuntimeConfiguration = RuntimeDictationConfiguration;
			witDictation.DictationEvents = DictationEvents;
			witDictation.TelemetryEvents = base.TelemetryEvents;
			witDictation.ShouldWrap = false;
			_dictationServiceImpl = witDictation;
			VLog.D("WitDictation init complete");
			_voiceSDKLogger.IsUsingPlatformIntegration = false;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (MicPermissionsManager.HasMicPermission())
			{
				InitDictation();
			}
			else
			{
				MicPermissionsManager.RequestMicPermission(delegate
				{
					InitDictation();
				});
			}
			DictationEvents.OnDictationSessionStarted.AddListener(OnDictationSessionStarted);
			base.TelemetryEvents.OnAudioTrackerFinished.AddListener(OnAudioDurationTrackerFinished);
		}

		protected override void OnDisable()
		{
			_dictationServiceImpl = null;
			_voiceSDKLogger = null;
			DictationEvents.OnDictationSessionStarted.RemoveListener(OnDictationSessionStarted);
			base.TelemetryEvents.OnAudioTrackerFinished.RemoveListener(OnAudioDurationTrackerFinished);
			base.OnDisable();
		}

		public void Toggle()
		{
			if (Active)
			{
				Deactivate();
			}
			else
			{
				Activate();
			}
		}

		public override VoiceServiceRequest Activate(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents)
		{
			if (_dictationServiceImpl == null)
			{
				OnDictationServiceNotAvailable();
				return null;
			}
			if (!_isActive)
			{
				_activeSession = new DictationSession();
				DictationEvents.OnDictationSessionStarted.Invoke(_activeSession);
			}
			_isActive = true;
			SetupRequestParameters(ref requestOptions, ref requestEvents);
			return _dictationServiceImpl.Activate(requestOptions, requestEvents);
		}

		public override VoiceServiceRequest ActivateImmediately(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents)
		{
			if (_dictationServiceImpl == null)
			{
				OnDictationServiceNotAvailable();
				return null;
			}
			if (!_isActive)
			{
				_activeSession = new DictationSession();
				DictationEvents.OnDictationSessionStarted.Invoke(_activeSession);
			}
			_isActive = true;
			SetupRequestParameters(ref requestOptions, ref requestEvents);
			return _dictationServiceImpl.ActivateImmediately(requestOptions, requestEvents);
		}

		public override void Deactivate()
		{
			if (_dictationServiceImpl == null)
			{
				OnDictationServiceNotAvailable();
				return;
			}
			_isActive = false;
			_dictationServiceImpl.Deactivate();
		}

		public override void Cancel()
		{
			if (_dictationServiceImpl == null)
			{
				OnDictationServiceNotAvailable();
				return;
			}
			_dictationServiceImpl.Cancel();
			CleanupSession();
		}

		protected override void OnRequestInit(VoiceServiceRequest request)
		{
			base.OnRequestInit(request);
			_activeRequestOptions = request?.Options;
			_voiceSDKLogger.LogInteractionStart(request?.Options?.RequestId, "dictation");
			_voiceSDKLogger.LogAnnotation("minWakeThreshold", RuntimeConfiguration?.soundWakeThreshold.ToString(CultureInfo.InvariantCulture));
			_voiceSDKLogger.LogAnnotation("minKeepAliveTimeSec", RuntimeConfiguration?.minKeepAliveTimeInSeconds.ToString(CultureInfo.InvariantCulture));
			_voiceSDKLogger.LogAnnotation("minTranscriptionKeepAliveTimeSec", RuntimeConfiguration?.minTranscriptionKeepAliveTimeInSeconds.ToString(CultureInfo.InvariantCulture));
			_voiceSDKLogger.LogAnnotation("maxRecordingTime", RuntimeConfiguration?.maxRecordingTime.ToString(CultureInfo.InvariantCulture));
		}

		protected override void OnRequestStartListening(VoiceServiceRequest request)
		{
			base.OnRequestStartListening(request);
			_voiceSDKLogger.LogInteractionPoint("startedListening");
		}

		protected override void OnRequestStopListening(VoiceServiceRequest request)
		{
			base.OnRequestStopListening(request);
			_voiceSDKLogger.LogInteractionPoint("stoppedListening");
			if (RuntimeDictationConfiguration.dictationConfiguration.multiPhrase && _isActive)
			{
				Activate(_activeRequestOptions);
			}
		}

		private void OnDictationSessionStarted(DictationSession session)
		{
			if (session is PlatformDictationSession platformDictationSession)
			{
				_activeSession = session;
				_voiceSDKLogger.LogAnnotation("platformInteractionId", platformDictationSession.platformSessionId);
			}
		}

		private void OnAudioDurationTrackerFinished(long timestamp, double audioDuration)
		{
			_voiceSDKLogger.LogAnnotation("adt_duration", audioDuration.ToString(CultureInfo.InvariantCulture));
			_voiceSDKLogger.LogAnnotation("adt_finished", timestamp.ToString());
		}

		protected override void OnRequestPartialTranscription(VoiceServiceRequest request, string transcription)
		{
			base.OnRequestPartialTranscription(request, transcription);
			_voiceSDKLogger.LogFirstTranscriptionTime();
		}

		protected override void OnRequestFullTranscription(VoiceServiceRequest request, string transcription)
		{
			base.OnRequestFullTranscription(request, transcription);
			_voiceSDKLogger.LogInteractionPoint("fullTranscriptionTime");
		}

		protected override void OnRequestComplete(VoiceServiceRequest request)
		{
			base.OnRequestComplete(request);
			if (request.State == VoiceRequestState.Failed)
			{
				_voiceSDKLogger.LogInteractionEndFailure(request.Results.Message);
			}
			else if (request.State == VoiceRequestState.Canceled)
			{
				_voiceSDKLogger.LogInteractionEndFailure("aborted");
			}
			else
			{
				WitResponseNode witResponseNode = request.ResponseData?["speech"]?["tokens"];
				if (witResponseNode != null)
				{
					int count = witResponseNode.Count;
					string annotationValue = request.ResponseData["speech"]["tokens"][count - 1]?["end"]?.Value;
					_voiceSDKLogger.LogAnnotation("audioLength", annotationValue);
				}
				_voiceSDKLogger.LogInteractionEndSuccess();
			}
			if (!_isActive)
			{
				DictationEvents.OnDictationSessionStopped?.Invoke(_activeSession);
				CleanupSession();
			}
		}

		private void CleanupSession()
		{
			_activeSession = null;
			_activeRequestOptions = null;
			_isActive = false;
		}
	}
}
namespace Oculus.Voice.Dictation.Bindings.Android
{
	public class DictationConfigurationBinding
	{
		private readonly WitDictationRuntimeConfiguration _runtimeConfiguration;

		private readonly DictationConfiguration _dictationConfiguration;

		private readonly int MAX_PLATFORM_SUPPORTED_RECORDING_TIME_SECONDS = 300;

		public DictationConfigurationBinding(WitDictationRuntimeConfiguration runtimeConfiguration)
		{
			if (runtimeConfiguration == null)
			{
				VLog.W("No dictation config has been defined. Using the default configuration.");
				_dictationConfiguration = new DictationConfiguration();
			}
			else
			{
				_dictationConfiguration = runtimeConfiguration.dictationConfiguration;
				_runtimeConfiguration = runtimeConfiguration;
			}
		}

		public AndroidJavaObject ToJavaObject()
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.oculus.assistant.api.voicesdk.dictation.PlatformDictationConfiguration");
			androidJavaObject.Set("multiPhrase", _dictationConfiguration.multiPhrase);
			androidJavaObject.Set("scenario", _dictationConfiguration.scenario);
			androidJavaObject.Set("inputType", _dictationConfiguration.inputType);
			if (_runtimeConfiguration != null)
			{
				int num = (int)_runtimeConfiguration.maxRecordingTime;
				if (num < 0)
				{
					num = MAX_PLATFORM_SUPPORTED_RECORDING_TIME_SECONDS;
				}
				androidJavaObject.Set("interactionTimeoutSeconds", num);
			}
			return androidJavaObject;
		}
	}
	public class DictationListenerBinding : AndroidJavaProxy
	{
		private IDictationService _dictationService;

		private IServiceEvents _serviceEvents;

		private DictationEvents DictationEvents => _dictationService.DictationEvents;

		public DictationListenerBinding(IDictationService dictationService, IServiceEvents serviceEvents)
			: base("com.oculus.assistant.api.voicesdk.dictation.PlatformDictationListener")
		{
			_dictationService = dictationService;
			_serviceEvents = serviceEvents;
		}

		public void onStart(string sessionId)
		{
			DictationEvents.OnStartListening?.Invoke();
			new PlatformDictationSession
			{
				dictationService = _dictationService,
				platformSessionId = sessionId
			};
		}

		public void onMicAudioLevel(string sessionId, int micLevel)
		{
			DictationEvents.OnMicAudioLevelChanged?.Invoke((float)micLevel / 100f);
		}

		public void onPartialTranscription(string sessionId, string transcription)
		{
			DictationEvents.OnPartialTranscription?.Invoke(transcription);
		}

		public void onFinalTranscription(string sessionId, string transcription)
		{
			DictationEvents.OnFullTranscription?.Invoke(transcription);
		}

		public void onError(string sessionId, string errorType, string errorMessage)
		{
			DictationEvents.OnError?.Invoke(errorType, errorMessage);
		}

		public void onStopped(string sessionId)
		{
			DictationEvents.OnStoppedListening?.Invoke();
			new PlatformDictationSession
			{
				dictationService = _dictationService,
				platformSessionId = sessionId
			};
		}

		public void onServiceNotAvailable(string error, string message)
		{
			VLog.W("Platform dictation service is not available");
			_serviceEvents.OnServiceNotAvailable(error, message);
		}
	}
	public interface IServiceEvents
	{
		void OnServiceNotAvailable(string error, string message);
	}
	public class PlatformDictationImpl : BaseAndroidConnectionImpl<PlatformDictationSDKBinding>, IDictationService, ITelemetryEventsProvider, IServiceEvents
	{
		private readonly IDictationService _baseService;

		private bool _serviceAvailable = true;

		private WitDictationRuntimeConfiguration _dictationRuntimeConfiguration;

		private DictationListenerBinding _listenerBinding;

		public Action OnServiceNotAvailableEvent;

		public bool PlatformSupportsDictation
		{
			get
			{
				if (service != null && service.IsSupported)
				{
					return _serviceAvailable;
				}
				return false;
			}
		}

		public bool Active => service.Active;

		public bool IsRequestActive => service.IsRequestActive;

		public bool MicActive => service.Active;

		public ITranscriptionProvider TranscriptionProvider { get; set; }

		public DictationEvents DictationEvents
		{
			get
			{
				return _baseService.DictationEvents;
			}
			set
			{
				_baseService.DictationEvents = value;
			}
		}

		public TelemetryEvents TelemetryEvents
		{
			get
			{
				return _baseService.TelemetryEvents;
			}
			set
			{
				_baseService.TelemetryEvents = value;
			}
		}

		public PlatformDictationImpl(IDictationService dictationService)
			: base("com.oculus.assistant.api.unity.dictation.UnityDictationServiceFragment")
		{
			_baseService = dictationService;
		}

		public override void Connect(string version)
		{
			base.Connect(version);
			if (service != null)
			{
				_listenerBinding = new DictationListenerBinding(this, this);
				service.SetListener(_listenerBinding);
			}
		}

		public override void Disconnect()
		{
			base.Disconnect();
		}

		public void SetDictationRuntimeConfiguration(WitDictationRuntimeConfiguration configuration)
		{
			_dictationRuntimeConfiguration = configuration;
		}

		private void Activate()
		{
			service.StartDictation(new DictationConfigurationBinding(_dictationRuntimeConfiguration));
		}

		public VoiceServiceRequest Activate(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents)
		{
			Activate();
			return null;
		}

		public VoiceServiceRequest ActivateImmediately(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents)
		{
			Activate();
			return null;
		}

		public void Deactivate()
		{
			service.StopDictation();
		}

		public void Cancel()
		{
			service.StopDictation();
		}

		public void OnServiceNotAvailable(string error, string message)
		{
			_serviceAvailable = false;
			OnServiceNotAvailableEvent?.Invoke();
		}
	}
	public class PlatformDictationSDKBinding : BaseServiceBinding
	{
		public bool Active => binding.Call<bool>("isActive", Array.Empty<object>());

		public bool IsRequestActive => binding.Call<bool>("isRequestActive", Array.Empty<object>());

		public bool IsSupported => binding.Call<bool>("isSupported", Array.Empty<object>());

		public PlatformDictationSDKBinding(AndroidJavaObject sdkInstance)
			: base(sdkInstance)
		{
		}

		public void StartDictation(DictationConfigurationBinding configuration)
		{
			binding.Call("startDictation", configuration.ToJavaObject());
		}

		public void StopDictation()
		{
			binding.Call("stopDictation");
		}

		public void SetListener(DictationListenerBinding listenerBinding)
		{
			binding.Call("setListener", listenerBinding);
		}
	}
	public class PlatformDictationSession : DictationSession
	{
		public string platformSessionId;
	}
}
namespace Oculus.Voice.Dictation.Listeners
{
	public interface DictationListener
	{
		void OnStart(DictationListener listener);

		void OnMicAudioLevel(float micLevel);

		void OnPartialTranscription(string transcription);

		void OnFinalTranscription(string transcription);

		void OnError(string errorType, string errorMessage);

		void OnStopped(DictationListener listener);
	}
}
namespace Oculus.Voice.Dictation.Configuration
{
	[Serializable]
	public class DictationConfiguration
	{
		[Tooltip("Re-open the mic after the final transcription. Useful for long form content/messaging.")]
		public bool multiPhrase;

		[Tooltip("Hint about the scenario that the user is dictating. Default to package name. In the future we might have messaging, search, general, etc")]
		public string scenario = "default";

		[Tooltip("Input types: text_default: Normal text, numeric: Numbers, email: Email addresses")]
		public string inputType = "text_default";
	}
}
