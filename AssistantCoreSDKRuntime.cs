using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Oculus.Voice.Core.Bindings.Interfaces;
using Oculus.Voice.Core.Utilities;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Scripting;

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
			FilePathsData = new byte[1301]
			{
				0, 0, 0, 1, 0, 0, 0, 134, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 118, 111, 105, 99,
				101, 64, 100, 51, 102, 54, 102, 51, 55, 98,
				56, 101, 49, 99, 92, 76, 105, 98, 92, 80,
				108, 97, 116, 102, 111, 114, 109, 67, 111, 109,
				112, 97, 116, 105, 98, 105, 108, 105, 116, 121,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 65, 110, 100,
				114, 111, 105, 100, 92, 65, 110, 100, 114, 111,
				105, 100, 83, 101, 114, 118, 105, 99, 101, 67,
				111, 110, 110, 101, 99, 116, 105, 111, 110, 46,
				99, 115, 0, 0, 0, 2, 0, 0, 0, 135,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 118, 111,
				105, 99, 101, 64, 100, 51, 102, 54, 102, 51,
				55, 98, 56, 101, 49, 99, 92, 76, 105, 98,
				92, 80, 108, 97, 116, 102, 111, 114, 109, 67,
				111, 109, 112, 97, 116, 105, 98, 105, 108, 105,
				116, 121, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 65,
				110, 100, 114, 111, 105, 100, 92, 66, 97, 115,
				101, 65, 110, 100, 114, 105, 111, 100, 67, 111,
				110, 110, 101, 99, 116, 105, 111, 110, 73, 109,
				112, 108, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 150, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 118, 111, 105, 99, 101, 64, 100, 51, 102,
				54, 102, 51, 55, 98, 56, 101, 49, 99, 92,
				76, 105, 98, 92, 80, 108, 97, 116, 102, 111,
				114, 109, 67, 111, 109, 112, 97, 116, 105, 98,
				105, 108, 105, 116, 121, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 65, 110, 100, 114, 111, 105, 100, 92,
				80, 108, 97, 116, 102, 111, 114, 109, 76, 111,
				103, 103, 101, 114, 92, 86, 111, 105, 99, 101,
				83, 68, 75, 67, 111, 110, 115, 111, 108, 101,
				76, 111, 103, 103, 101, 114, 73, 109, 112, 108,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				146, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 118,
				111, 105, 99, 101, 64, 100, 51, 102, 54, 102,
				51, 55, 98, 56, 101, 49, 99, 92, 76, 105,
				98, 92, 80, 108, 97, 116, 102, 111, 114, 109,
				67, 111, 109, 112, 97, 116, 105, 98, 105, 108,
				105, 116, 121, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				65, 110, 100, 114, 111, 105, 100, 92, 80, 108,
				97, 116, 102, 111, 114, 109, 76, 111, 103, 103,
				101, 114, 92, 86, 111, 105, 99, 101, 83, 68,
				75, 76, 111, 103, 103, 101, 114, 66, 105, 110,
				100, 105, 110, 103, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 151, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 118, 111, 105, 99, 101, 64, 100,
				51, 102, 54, 102, 51, 55, 98, 56, 101, 49,
				99, 92, 76, 105, 98, 92, 80, 108, 97, 116,
				102, 111, 114, 109, 67, 111, 109, 112, 97, 116,
				105, 98, 105, 108, 105, 116, 121, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 65, 110, 100, 114, 111, 105,
				100, 92, 80, 108, 97, 116, 102, 111, 114, 109,
				76, 111, 103, 103, 101, 114, 92, 86, 111, 105,
				99, 101, 83, 68, 75, 80, 108, 97, 116, 102,
				111, 114, 109, 76, 111, 103, 103, 101, 114, 73,
				109, 112, 108, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 124, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 118, 111, 105, 99, 101, 64, 100, 51,
				102, 54, 102, 51, 55, 98, 56, 101, 49, 99,
				92, 76, 105, 98, 92, 80, 108, 97, 116, 102,
				111, 114, 109, 67, 111, 109, 112, 97, 116, 105,
				98, 105, 108, 105, 116, 121, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 73, 110, 116, 101, 114, 102, 97,
				99, 101, 115, 92, 73, 67, 111, 110, 110, 101,
				99, 116, 105, 111, 110, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 128, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 118, 111, 105, 99, 101, 64,
				100, 51, 102, 54, 102, 51, 55, 98, 56, 101,
				49, 99, 92, 76, 105, 98, 92, 80, 108, 97,
				116, 102, 111, 114, 109, 67, 111, 109, 112, 97,
				116, 105, 98, 105, 108, 105, 116, 121, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 73, 110, 116, 101, 114,
				102, 97, 99, 101, 115, 92, 73, 86, 111, 105,
				99, 101, 83, 68, 75, 76, 111, 103, 103, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 136, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				118, 111, 105, 99, 101, 64, 100, 51, 102, 54,
				102, 51, 55, 98, 56, 101, 49, 99, 92, 76,
				105, 98, 92, 80, 108, 97, 116, 102, 111, 114,
				109, 67, 111, 109, 112, 97, 116, 105, 98, 105,
				108, 105, 116, 121, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 85, 116, 105, 108, 105, 116, 121, 92, 65,
				114, 114, 97, 121, 69, 108, 101, 109, 101, 110,
				116, 84, 105, 116, 108, 101, 65, 116, 116, 114,
				105, 98, 117, 116, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 125, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 118, 111, 105, 99, 101, 64,
				100, 51, 102, 54, 102, 51, 55, 98, 56, 101,
				49, 99, 92, 76, 105, 98, 92, 80, 108, 97,
				116, 102, 111, 114, 109, 67, 111, 109, 112, 97,
				116, 105, 98, 105, 108, 105, 116, 121, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 85, 116, 105, 108, 105,
				116, 121, 92, 68, 97, 116, 101, 84, 105, 109,
				101, 85, 116, 105, 108, 105, 116, 121, 46, 99,
				115
			},
			TypesData = new byte[643]
			{
				0, 0, 0, 0, 59, 79, 99, 117, 108, 117,
				115, 46, 86, 111, 105, 99, 101, 46, 67, 111,
				114, 101, 46, 66, 105, 110, 100, 105, 110, 103,
				115, 46, 65, 110, 100, 114, 111, 105, 100, 124,
				65, 110, 100, 114, 111, 105, 100, 83, 101, 114,
				118, 105, 99, 101, 67, 111, 110, 110, 101, 99,
				116, 105, 111, 110, 0, 0, 0, 0, 60, 79,
				99, 117, 108, 117, 115, 46, 86, 111, 105, 99,
				101, 46, 67, 111, 114, 101, 46, 66, 105, 110,
				100, 105, 110, 103, 115, 46, 65, 110, 100, 114,
				111, 105, 100, 124, 66, 97, 115, 101, 65, 110,
				100, 114, 111, 105, 100, 67, 111, 110, 110, 101,
				99, 116, 105, 111, 110, 73, 109, 112, 108, 0,
				0, 0, 0, 53, 79, 99, 117, 108, 117, 115,
				46, 86, 111, 105, 99, 101, 46, 67, 111, 114,
				101, 46, 66, 105, 110, 100, 105, 110, 103, 115,
				46, 65, 110, 100, 114, 111, 105, 100, 124, 66,
				97, 115, 101, 83, 101, 114, 118, 105, 99, 101,
				66, 105, 110, 100, 105, 110, 103, 0, 0, 0,
				0, 75, 79, 99, 117, 108, 117, 115, 46, 86,
				111, 105, 99, 101, 46, 67, 111, 114, 101, 46,
				66, 105, 110, 100, 105, 110, 103, 115, 46, 65,
				110, 100, 114, 111, 105, 100, 46, 80, 108, 97,
				116, 102, 111, 114, 109, 76, 111, 103, 103, 101,
				114, 124, 86, 111, 105, 99, 101, 83, 68, 75,
				67, 111, 110, 115, 111, 108, 101, 76, 111, 103,
				103, 101, 114, 73, 109, 112, 108, 0, 0, 0,
				0, 71, 79, 99, 117, 108, 117, 115, 46, 86,
				111, 105, 99, 101, 46, 67, 111, 114, 101, 46,
				66, 105, 110, 100, 105, 110, 103, 115, 46, 65,
				110, 100, 114, 111, 105, 100, 46, 80, 108, 97,
				116, 102, 111, 114, 109, 76, 111, 103, 103, 101,
				114, 124, 86, 111, 105, 99, 101, 83, 68, 75,
				76, 111, 103, 103, 101, 114, 66, 105, 110, 100,
				105, 110, 103, 0, 0, 0, 0, 76, 79, 99,
				117, 108, 117, 115, 46, 86, 111, 105, 99, 101,
				46, 67, 111, 114, 101, 46, 66, 105, 110, 100,
				105, 110, 103, 115, 46, 65, 110, 100, 114, 111,
				105, 100, 46, 80, 108, 97, 116, 102, 111, 114,
				109, 76, 111, 103, 103, 101, 114, 124, 86, 111,
				105, 99, 101, 83, 68, 75, 80, 108, 97, 116,
				102, 111, 114, 109, 76, 111, 103, 103, 101, 114,
				73, 109, 112, 108, 0, 0, 0, 0, 49, 79,
				99, 117, 108, 117, 115, 46, 86, 111, 105, 99,
				101, 46, 67, 111, 114, 101, 46, 66, 105, 110,
				100, 105, 110, 103, 115, 46, 73, 110, 116, 101,
				114, 102, 97, 99, 101, 115, 124, 73, 67, 111,
				110, 110, 101, 99, 116, 105, 111, 110, 0, 0,
				0, 0, 53, 79, 99, 117, 108, 117, 115, 46,
				86, 111, 105, 99, 101, 46, 67, 111, 114, 101,
				46, 66, 105, 110, 100, 105, 110, 103, 115, 46,
				73, 110, 116, 101, 114, 102, 97, 99, 101, 115,
				124, 73, 86, 111, 105, 99, 101, 83, 68, 75,
				76, 111, 103, 103, 101, 114, 0, 0, 0, 0,
				54, 79, 99, 117, 108, 117, 115, 46, 86, 111,
				105, 99, 101, 46, 67, 111, 114, 101, 46, 85,
				116, 105, 108, 105, 116, 105, 101, 115, 124, 65,
				114, 114, 97, 121, 69, 108, 101, 109, 101, 110,
				116, 84, 105, 116, 108, 101, 65, 116, 116, 114,
				105, 98, 117, 116, 101, 0, 0, 0, 0, 43,
				79, 99, 117, 108, 117, 115, 46, 86, 111, 105,
				99, 101, 46, 67, 111, 114, 101, 46, 85, 116,
				105, 108, 105, 116, 105, 101, 115, 124, 68, 97,
				116, 101, 84, 105, 109, 101, 85, 116, 105, 108,
				105, 116, 121
			},
			TotalFiles = 9,
			TotalTypes = 10,
			IsEditorOnly = false
		};
	}
}
namespace Oculus.Voice.Core.Utilities
{
	public class ArrayElementTitleAttribute : PropertyAttribute
	{
		public string varname;

		public string fallbackName;

		public ArrayElementTitleAttribute(string elementTitleVar = null, string fallbackName = null)
		{
			varname = elementTitleVar;
			this.fallbackName = fallbackName;
		}
	}
	public class DateTimeUtility
	{
		public static DateTime UtcNow => DateTime.UtcNow;

		public static long ElapsedMilliseconds => UtcNow.Ticks / 10000;
	}
}
namespace Oculus.Voice.Core.Bindings.Interfaces
{
	public interface IConnection
	{
		bool IsConnected { get; }

		void Connect(string version);

		void Disconnect();
	}
	public interface IVoiceSDKLogger
	{
		bool IsUsingPlatformIntegration { get; set; }

		bool ShouldLogToConsole { get; set; }

		string WitApplication { get; set; }

		void LogInteractionStart(string requestId, string witApi);

		void LogInteractionEndSuccess();

		void LogInteractionEndFailure(string errorMessage);

		void LogInteractionPoint(string interactionPoint);

		void LogAnnotation(string annotationKey, string annotationValue);

		void LogFirstTranscriptionTime();
	}
}
namespace Oculus.Voice.Core.Bindings.Android
{
	public class AndroidServiceConnection : IConnection
	{
		private AndroidJavaObject mAssistantServiceConnection;

		private string serviceFragmentClass;

		private string serviceGetter;

		public bool IsConnected => mAssistantServiceConnection != null;

		public AndroidJavaObject AssistantServiceConnection => mAssistantServiceConnection;

		public AndroidServiceConnection(string serviceFragmentClassName, string serviceGetterMethodName)
		{
			serviceFragmentClass = serviceFragmentClassName;
			serviceGetter = serviceGetterMethodName;
		}

		public void Connect(string version)
		{
			if (mAssistantServiceConnection != null)
			{
				return;
			}
			try
			{
				AndroidJNIHelper.debug = true;
				AndroidJavaObject androidJavaObject = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
				using AndroidJavaClass androidJavaClass = new AndroidJavaClass(serviceFragmentClass);
				mAssistantServiceConnection = androidJavaClass.CallStatic<AndroidJavaObject>("createAndAttach", new object[2] { androidJavaObject, version });
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogErrorFormat("AndroidServiceConnection Connect Failed\nService: {0}\nException:\n{1}\n\n", serviceFragmentClass, ex);
			}
		}

		public void Disconnect()
		{
			mAssistantServiceConnection?.Call("detach");
		}

		public AndroidJavaObject GetService()
		{
			return mAssistantServiceConnection?.Call<AndroidJavaObject>(serviceGetter, Array.Empty<object>());
		}
	}
	public class BaseAndroidConnectionImpl<T> where T : BaseServiceBinding
	{
		private string fragmentClassName;

		protected T service;

		protected readonly AndroidServiceConnection serviceConnection;

		public bool IsConnected => serviceConnection.IsConnected;

		public BaseAndroidConnectionImpl(string className)
		{
			fragmentClassName = className;
			serviceConnection = new AndroidServiceConnection(className, "getService");
		}

		public virtual void Connect(string version)
		{
			serviceConnection.Connect(version);
			AndroidJavaObject androidJavaObject = serviceConnection.GetService();
			if (androidJavaObject != null)
			{
				service = (T)Activator.CreateInstance(typeof(T), androidJavaObject);
			}
		}

		public virtual void Disconnect()
		{
			service.Shutdown();
			serviceConnection.Disconnect();
			service = null;
		}
	}
	public class BaseServiceBinding
	{
		protected AndroidJavaObject binding;

		protected BaseServiceBinding(AndroidJavaObject sdkInstance)
		{
			binding = sdkInstance;
		}

		public void Shutdown()
		{
			binding.Call("shutdown");
		}
	}
}
namespace Oculus.Voice.Core.Bindings.Android.PlatformLogger
{
	public class VoiceSDKConsoleLoggerImpl : IVoiceSDKLogger
	{
		private static readonly string TAG = "VoiceSDKConsoleLogger";

		private bool loggedFirstTranscriptionTime;

		public bool IsUsingPlatformIntegration { get; set; }

		public string WitApplication { get; set; }

		public string PackageName { get; }

		public bool ShouldLogToConsole { get; set; }

		public VoiceSDKConsoleLoggerImpl()
		{
			PackageName = UnityEngine.Device.Application.identifier;
		}

		public void LogInteractionStart(string requestId, string witApi)
		{
			if (ShouldLogToConsole)
			{
				loggedFirstTranscriptionTime = false;
				UnityEngine.Debug.Log(TAG + ": Interaction started with request ID: " + requestId);
				UnityEngine.Debug.Log(TAG + ": WitApi: " + witApi);
				UnityEngine.Debug.Log(TAG + ": request_start_time: " + DateTimeUtility.ElapsedMilliseconds);
				UnityEngine.Debug.Log(TAG + ": WitAppID: " + WitApplication);
				UnityEngine.Debug.Log(TAG + ": PackageName: " + PackageName);
			}
		}

		public void LogInteractionEndSuccess()
		{
			if (ShouldLogToConsole)
			{
				UnityEngine.Debug.Log(TAG + ": Interaction finished successfully");
				UnityEngine.Debug.Log(TAG + ": request_end_time: " + DateTimeUtility.ElapsedMilliseconds);
			}
		}

		public void LogInteractionEndFailure(string errorMessage)
		{
			if (ShouldLogToConsole)
			{
				UnityEngine.Debug.Log(TAG + ": Interaction finished with error: " + errorMessage);
				UnityEngine.Debug.Log(TAG + ": request_end_time: " + DateTimeUtility.ElapsedMilliseconds);
			}
		}

		public void LogInteractionPoint(string interactionPoint)
		{
			if (ShouldLogToConsole)
			{
				UnityEngine.Debug.Log(TAG + ": Interaction point: " + interactionPoint);
				UnityEngine.Debug.Log(TAG + ": " + interactionPoint + "_start_time: " + DateTimeUtility.ElapsedMilliseconds);
			}
		}

		public void LogAnnotation(string annotationKey, string annotationValue)
		{
			if (ShouldLogToConsole)
			{
				UnityEngine.Debug.Log(TAG + ": Logging key-value pair: " + annotationKey + "::" + annotationValue);
			}
		}

		public void LogFirstTranscriptionTime()
		{
			if (!loggedFirstTranscriptionTime)
			{
				loggedFirstTranscriptionTime = true;
				LogInteractionPoint("firstPartialTranscriptionTime");
			}
		}
	}
	public class VoiceSDKLoggerBinding : BaseServiceBinding
	{
		private readonly TaskScheduler _scheduler;

		[Preserve]
		public VoiceSDKLoggerBinding(AndroidJavaObject loggerInstance)
			: base(loggerInstance)
		{
			_scheduler = TaskScheduler.FromCurrentSynchronizationContext();
		}

		public void Connect()
		{
			Call<bool>("connect", Array.Empty<object>());
		}

		public void LogInteractionStart(string requestId, string startTime)
		{
			Call("logInteractionStart", requestId, startTime);
		}

		public void LogInteractionEndSuccess(string endTime)
		{
			Call("logInteractionEndSuccess", endTime);
		}

		public void LogInteractionEndFailure(string endTime, string errorMessage)
		{
			Call("logInteractionEndFailure", endTime, errorMessage);
		}

		public void LogInteractionPoint(string interactionPoint, string time)
		{
			Call("logInteractionPoint", interactionPoint, time);
		}

		public void LogAnnotation(string annotationKey, string annotationValue)
		{
			Call("logAnnotation", annotationKey, annotationValue);
		}

		private Task Call(string methodName, params object[] parameters)
		{
			Task task = new Task(delegate
			{
				binding.Call(methodName, parameters);
			});
			task.Start(_scheduler);
			return task;
		}

		private Task<TReturnType> Call<TReturnType>(string methodName, params object[] parameters)
		{
			Task<TReturnType> task = new Task<TReturnType>(() => binding.Call<TReturnType>(methodName, parameters));
			task.Start(_scheduler);
			return task;
		}
	}
	public class VoiceSDKPlatformLoggerImpl : BaseAndroidConnectionImpl<VoiceSDKLoggerBinding>, IVoiceSDKLogger
	{
		private VoiceSDKConsoleLoggerImpl consoleLoggerImpl = new VoiceSDKConsoleLoggerImpl();

		private bool loggedFirstTranscriptionTime;

		public bool IsUsingPlatformIntegration { get; set; }

		public string WitApplication { get; set; }

		public string PackageName { get; }

		public bool ShouldLogToConsole
		{
			get
			{
				return consoleLoggerImpl.ShouldLogToConsole;
			}
			set
			{
				consoleLoggerImpl.ShouldLogToConsole = value;
			}
		}

		public VoiceSDKPlatformLoggerImpl()
			: base("com.oculus.assistant.api.unity.logging.UnityPlatformLoggerServiceFragment")
		{
			PackageName = UnityEngine.Application.identifier;
		}

		public override void Connect(string version)
		{
			base.Connect(version);
			if (service != null)
			{
				service.Connect();
				UnityEngine.Debug.Log("Logging Platform integration initialization complete.");
			}
		}

		public override void Disconnect()
		{
			UnityEngine.Debug.Log("Logging Platform integration shutdown");
			base.Disconnect();
		}

		public void LogInteractionStart(string requestId, string witApi)
		{
			loggedFirstTranscriptionTime = false;
			consoleLoggerImpl.LogInteractionStart(requestId, witApi);
			service?.LogInteractionStart(requestId, DateTimeUtility.ElapsedMilliseconds.ToString());
			LogAnnotation("isUsingPlatform", IsUsingPlatformIntegration.ToString());
			LogAnnotation("witApi", witApi);
			LogAnnotation("witAppId", WitApplication);
			LogAnnotation("package", PackageName);
		}

		public void LogInteractionEndSuccess()
		{
			consoleLoggerImpl.LogInteractionEndSuccess();
			service?.LogInteractionEndSuccess(DateTimeUtility.ElapsedMilliseconds.ToString());
		}

		public void LogInteractionEndFailure(string errorMessage)
		{
			consoleLoggerImpl.LogInteractionEndFailure(errorMessage);
			service?.LogInteractionEndFailure(DateTimeUtility.ElapsedMilliseconds.ToString(), errorMessage);
		}

		public void LogInteractionPoint(string interactionPoint)
		{
			consoleLoggerImpl.LogInteractionPoint(interactionPoint);
			service?.LogInteractionPoint(interactionPoint, DateTimeUtility.ElapsedMilliseconds.ToString());
		}

		public void LogAnnotation(string annotationKey, string annotationValue)
		{
			consoleLoggerImpl.LogAnnotation(annotationKey, annotationValue);
			service?.LogAnnotation(annotationKey, annotationValue);
		}

		public void LogFirstTranscriptionTime()
		{
			if (!loggedFirstTranscriptionTime)
			{
				loggedFirstTranscriptionTime = true;
				LogInteractionPoint("firstPartialTranscriptionTime");
			}
		}
	}
}
