using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Modio.API;
using Modio.API.HttpClient;
using Modio.API.Interfaces;
using Modio.API.SchemaDefinitions;
using Modio.Errors;
using Modio.Extensions;
using Modio.FileIO;
using Modio.Images;
using Modio.Platforms;
using Modio.Users;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Networking;

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
			FilePathsData = new byte[725]
			{
				0, 0, 0, 1, 0, 0, 0, 47, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 108, 117, 103,
				105, 110, 115, 92, 109, 111, 100, 46, 105, 111,
				92, 85, 110, 105, 116, 121, 92, 65, 111, 116,
				84, 121, 112, 101, 69, 110, 102, 111, 114, 99,
				101, 114, 46, 99, 115, 0, 0, 0, 2, 0,
				0, 0, 51, 92, 65, 115, 115, 101, 116, 115,
				92, 80, 108, 117, 103, 105, 110, 115, 92, 109,
				111, 100, 46, 105, 111, 92, 85, 110, 105, 116,
				121, 92, 73, 109, 97, 103, 101, 67, 97, 99,
				104, 101, 84, 101, 120, 116, 117, 114, 101, 50,
				68, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 51, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 108, 117, 103, 105, 110, 115, 92, 109, 111,
				100, 46, 105, 111, 92, 85, 110, 105, 116, 121,
				92, 77, 111, 100, 105, 111, 65, 112, 105, 85,
				110, 105, 116, 121, 67, 108, 105, 101, 110, 116,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				61, 92, 65, 115, 115, 101, 116, 115, 92, 80,
				108, 117, 103, 105, 110, 115, 92, 109, 111, 100,
				46, 105, 111, 92, 85, 110, 105, 116, 121, 92,
				77, 111, 100, 105, 111, 80, 108, 97, 116, 102,
				111, 114, 109, 83, 101, 116, 116, 105, 110, 103,
				115, 69, 120, 97, 109, 112, 108, 101, 115, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 51,
				92, 65, 115, 115, 101, 116, 115, 92, 80, 108,
				117, 103, 105, 110, 115, 92, 109, 111, 100, 46,
				105, 111, 92, 85, 110, 105, 116, 121, 92, 77,
				111, 100, 105, 111, 80, 114, 101, 73, 110, 105,
				116, 105, 97, 108, 105, 122, 101, 114, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 42, 92,
				65, 115, 115, 101, 116, 115, 92, 80, 108, 117,
				103, 105, 110, 115, 92, 109, 111, 100, 46, 105,
				111, 92, 85, 110, 105, 116, 121, 92, 77, 111,
				100, 105, 111, 85, 110, 105, 116, 121, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 48, 92,
				65, 115, 115, 101, 116, 115, 92, 80, 108, 117,
				103, 105, 110, 115, 92, 109, 111, 100, 46, 105,
				111, 92, 85, 110, 105, 116, 121, 92, 77, 111,
				100, 105, 111, 85, 110, 105, 116, 121, 76, 111,
				103, 103, 101, 114, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 50, 92, 65, 115, 115, 101,
				116, 115, 92, 80, 108, 117, 103, 105, 110, 115,
				92, 109, 111, 100, 46, 105, 111, 92, 85, 110,
				105, 116, 121, 92, 77, 111, 100, 105, 111, 85,
				110, 105, 116, 121, 83, 101, 116, 116, 105, 110,
				103, 115, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 65, 92, 65, 115, 115, 101, 116, 115,
				92, 80, 108, 117, 103, 105, 110, 115, 92, 109,
				111, 100, 46, 105, 111, 92, 85, 110, 105, 116,
				121, 92, 83, 101, 116, 116, 105, 110, 103, 115,
				92, 77, 111, 100, 105, 111, 67, 111, 109, 112,
				111, 110, 101, 110, 116, 85, 73, 83, 101, 116,
				116, 105, 110, 103, 115, 46, 99, 115, 0, 0,
				0, 5, 0, 0, 0, 56, 92, 65, 115, 115,
				101, 116, 115, 92, 80, 108, 117, 103, 105, 110,
				115, 92, 109, 111, 100, 46, 105, 111, 92, 85,
				110, 105, 116, 121, 92, 83, 116, 114, 101, 97,
				109, 105, 110, 103, 68, 111, 119, 110, 108, 111,
				97, 100, 72, 97, 110, 100, 108, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 53,
				92, 65, 115, 115, 101, 116, 115, 92, 80, 108,
				117, 103, 105, 110, 115, 92, 109, 111, 100, 46,
				105, 111, 92, 85, 110, 105, 116, 121, 92, 85,
				110, 105, 116, 121, 82, 111, 111, 116, 80, 97,
				116, 104, 80, 114, 111, 118, 105, 100, 101, 114,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				54, 92, 65, 115, 115, 101, 116, 115, 92, 80,
				108, 117, 103, 105, 110, 115, 92, 109, 111, 100,
				46, 105, 111, 92, 85, 110, 105, 116, 121, 92,
				85, 110, 105, 116, 121, 87, 101, 98, 66, 114,
				111, 119, 115, 101, 114, 72, 97, 110, 100, 108,
				101, 114, 46, 99, 115
			},
			TypesData = new byte[788]
			{
				0, 0, 0, 0, 27, 77, 111, 100, 105, 111,
				46, 85, 110, 105, 116, 121, 124, 65, 111, 116,
				84, 121, 112, 101, 69, 110, 102, 111, 114, 99,
				101, 114, 0, 0, 0, 0, 31, 77, 111, 100,
				105, 111, 46, 85, 110, 105, 116, 121, 124, 73,
				109, 97, 103, 101, 67, 97, 99, 104, 101, 84,
				101, 120, 116, 117, 114, 101, 50, 68, 0, 0,
				0, 0, 41, 77, 111, 100, 105, 111, 46, 85,
				110, 105, 116, 121, 124, 77, 111, 100, 105, 111,
				73, 109, 97, 103, 101, 84, 101, 120, 116, 117,
				114, 101, 50, 68, 69, 120, 116, 101, 110, 115,
				105, 111, 110, 115, 0, 0, 0, 0, 31, 77,
				111, 100, 105, 111, 46, 85, 110, 105, 116, 121,
				124, 77, 111, 100, 105, 111, 65, 80, 73, 85,
				110, 105, 116, 121, 67, 108, 105, 101, 110, 116,
				0, 0, 0, 0, 32, 77, 111, 100, 105, 111,
				46, 85, 110, 105, 116, 121, 124, 77, 111, 100,
				105, 111, 65, 110, 100, 114, 111, 105, 100, 83,
				101, 116, 116, 105, 110, 103, 115, 0, 0, 0,
				0, 31, 77, 111, 100, 105, 111, 46, 85, 110,
				105, 116, 121, 124, 77, 111, 100, 105, 111, 80,
				114, 101, 73, 110, 105, 116, 105, 97, 108, 105,
				122, 101, 114, 0, 0, 0, 0, 22, 77, 111,
				100, 105, 111, 46, 85, 110, 105, 116, 121, 124,
				77, 111, 100, 105, 111, 85, 110, 105, 116, 121,
				0, 0, 0, 0, 28, 77, 111, 100, 105, 111,
				46, 85, 110, 105, 116, 121, 124, 77, 111, 100,
				105, 111, 85, 110, 105, 116, 121, 76, 111, 103,
				103, 101, 114, 0, 0, 0, 0, 30, 77, 111,
				100, 105, 111, 46, 85, 110, 105, 116, 121, 124,
				77, 111, 100, 105, 111, 85, 110, 105, 116, 121,
				83, 101, 116, 116, 105, 110, 103, 115, 0, 0,
				0, 0, 45, 77, 111, 100, 105, 111, 46, 85,
				110, 105, 116, 121, 46, 83, 101, 116, 116, 105,
				110, 103, 115, 124, 77, 111, 100, 105, 111, 67,
				111, 109, 112, 111, 110, 101, 110, 116, 85, 73,
				83, 101, 116, 116, 105, 110, 103, 115, 0, 0,
				0, 0, 36, 77, 111, 100, 105, 111, 46, 85,
				110, 105, 116, 121, 124, 83, 116, 114, 101, 97,
				109, 105, 110, 103, 68, 111, 119, 110, 108, 111,
				97, 100, 72, 97, 110, 100, 108, 101, 114, 0,
				0, 0, 0, 56, 77, 111, 100, 105, 111, 46,
				85, 110, 105, 116, 121, 46, 83, 116, 114, 101,
				97, 109, 105, 110, 103, 68, 111, 119, 110, 108,
				111, 97, 100, 72, 97, 110, 100, 108, 101, 114,
				124, 67, 104, 117, 110, 107, 101, 100, 83, 116,
				114, 101, 97, 109, 66, 117, 102, 102, 101, 114,
				0, 0, 0, 0, 68, 77, 111, 100, 105, 111,
				46, 85, 110, 105, 116, 121, 46, 83, 116, 114,
				101, 97, 109, 105, 110, 103, 68, 111, 119, 110,
				108, 111, 97, 100, 72, 97, 110, 100, 108, 101,
				114, 43, 67, 104, 117, 110, 107, 101, 100, 83,
				116, 114, 101, 97, 109, 66, 117, 102, 102, 101,
				114, 124, 66, 117, 102, 102, 101, 114, 67, 104,
				117, 110, 107, 0, 0, 0, 0, 76, 77, 111,
				100, 105, 111, 46, 85, 110, 105, 116, 121, 46,
				83, 116, 114, 101, 97, 109, 105, 110, 103, 68,
				111, 119, 110, 108, 111, 97, 100, 72, 97, 110,
				100, 108, 101, 114, 43, 67, 104, 117, 110, 107,
				101, 100, 83, 116, 114, 101, 97, 109, 66, 117,
				102, 102, 101, 114, 124, 65, 115, 121, 110, 99,
				65, 117, 116, 111, 82, 101, 115, 101, 116, 69,
				118, 101, 110, 116, 0, 0, 0, 0, 82, 77,
				111, 100, 105, 111, 46, 85, 110, 105, 116, 121,
				46, 83, 116, 114, 101, 97, 109, 105, 110, 103,
				68, 111, 119, 110, 108, 111, 97, 100, 72, 97,
				110, 100, 108, 101, 114, 43, 67, 104, 117, 110,
				107, 101, 100, 83, 116, 114, 101, 97, 109, 66,
				117, 102, 102, 101, 114, 43, 65, 115, 121, 110,
				99, 65, 117, 116, 111, 82, 101, 115, 101, 116,
				69, 118, 101, 110, 116, 124, 69, 109, 112, 116,
				121, 0, 0, 0, 0, 33, 77, 111, 100, 105,
				111, 46, 85, 110, 105, 116, 121, 124, 85, 110,
				105, 116, 121, 82, 111, 111, 116, 80, 97, 116,
				104, 80, 114, 111, 118, 105, 100, 101, 114, 0,
				0, 0, 0, 34, 77, 111, 100, 105, 111, 46,
				85, 110, 105, 116, 121, 124, 85, 110, 105, 116,
				121, 87, 101, 98, 66, 114, 111, 119, 115, 101,
				114, 72, 97, 110, 100, 108, 101, 114
			},
			TotalFiles = 12,
			TotalTypes = 17,
			IsEditorOnly = false
		};
	}
}
namespace Modio.Unity
{
	internal class AotTypeEnforcer : MonoBehaviour
	{
		private void Awake()
		{
			Modio.API.AotTypeEnforcer.Hello();
		}
	}
	public class ImageCacheTexture2D : BaseImageCache<Texture2D>
	{
		public static readonly ImageCacheTexture2D Instance = new ImageCacheTexture2D();

		protected override Texture2D Convert(byte[] rawBytes)
		{
			if (rawBytes == null || rawBytes.Length == 0)
			{
				ModioLog.Verbose?.Log(":INTERNAL: Attempted to parse image from NULL/0-length buffer.");
				return null;
			}
			Texture2D texture2D = new Texture2D(0, 0);
			if (texture2D.LoadImage(rawBytes, markNonReadable: false))
			{
				return texture2D;
			}
			ModioLog.Verbose?.Log(":INTERNAL: Failed to parse image data.");
			return null;
		}

		protected override byte[] ConvertToBytes(Texture2D image)
		{
			if (!(image != null))
			{
				return null;
			}
			return image.EncodeToPNG();
		}
	}
	public static class ModioImageTexture2DExtensions
	{
		public static Task<(Error error, Texture2D texture)> DownloadAsTexture2D(this ImageReference imageReference)
		{
			return ImageCacheTexture2D.Instance.DownloadImage(imageReference);
		}

		public static Task<(Error error, Texture2D texture)> DownloadAsTexture2D<TResolution>(this ModioImageSource<TResolution> imageSource, TResolution resolution) where TResolution : Enum
		{
			return ImageCacheTexture2D.Instance.DownloadImage(imageSource.GetUri(resolution));
		}
	}
	public class ModioAPIUnityClient : IModioAPIInterface, IDisposable
	{
		private string _basePath = string.Empty;

		private readonly List<string> _defaultParameters = new List<string>();

		private readonly Dictionary<string, string> _pathParameters = new Dictionary<string, string>();

		private readonly Dictionary<string, string> _defaultHeaders = new Dictionary<string, string>();

		private readonly List<UnityWebRequest> _webRequests = new List<UnityWebRequest>();

		private CancellationTokenSource _cancellationTokenSource;

		[ModioDebugMenu(ShowInSettingsMenu = true, ShowInBrowserMenu = false)]
		public static bool UseUnityClient
		{
			get
			{
				return ModioServices.Resolve<IModioAPIInterface>() is ModioAPIUnityClient;
			}
			set
			{
				if (value != UseUnityClient)
				{
					if (value)
					{
						ModioServices.Bind<IModioAPIInterface>().FromNew<ModioAPIUnityClient>();
					}
					else
					{
						ModioServices.Bind<IModioAPIInterface>().FromNew<ModioAPIHttpClient>();
					}
					User.LogOut();
				}
			}
		}

		public void SetBasePath(string value)
		{
			_basePath = value;
		}

		public void AddDefaultPathParameter(string key, string value)
		{
			_pathParameters[key] = value;
		}

		public void RemoveDefaultPathParameter(string key)
		{
			_pathParameters.Remove(key);
		}

		public void AddDefaultParameter(string value)
		{
			_defaultParameters.Add(value);
		}

		public void RemoveDefaultParameter(string value)
		{
			_defaultParameters.Remove(value);
		}

		public void ResetConfiguration()
		{
			_cancellationTokenSource?.Cancel();
			_cancellationTokenSource = new CancellationTokenSource();
			_defaultParameters.Clear();
			_pathParameters.Clear();
			_defaultHeaders.Clear();
			_basePath = string.Empty;
			ModioClient.OnShutdown -= Shutdown;
			ModioClient.OnShutdown += Shutdown;
		}

		private void Shutdown()
		{
			_cancellationTokenSource?.Cancel();
		}

		public async Task<(Error, Stream)> DownloadFile(string url, CancellationToken token = default(CancellationToken))
		{
			Error error = await CheckFakeErrorsForTest(url);
			if ((bool)error)
			{
				return (error, null);
			}
			if (string.IsNullOrEmpty(url))
			{
				ModioLog.Error?.Log("Attempting to download null url");
				return (new HttpError(HttpErrorCode.REQUEST_ERROR), null);
			}
			ModioAPIRequest modioAPIRequest = ModioAPIRequest.New(url);
			CancellationToken cancellationToken = _cancellationTokenSource?.Token ?? CancellationToken.None;
			if (token == default(CancellationToken))
			{
				token = cancellationToken;
			}
			StreamingDownloadHandler handler = new StreamingDownloadHandler(1048576, token);
			UnityWebRequest webRequest = CreateWebRequest(modioAPIRequest, url, handler);
			handler.SetCallingRequest(webRequest);
			Error error2 = EnforceAuthentication(modioAPIRequest, webRequest);
			if ((bool)error2)
			{
				return (error2, null);
			}
			await LogRequest(webRequest);
			Stream stream;
			try
			{
				webRequest.SendWebRequest();
				await handler.ResponseReceived(token);
				long responseCode = webRequest.responseCode;
				if (responseCode < 200 || responseCode >= 300)
				{
					string text = webRequest.downloadHandler.text;
					if (!IsResponseConnectionFailure(webRequest.responseCode))
					{
						return (GetErrorAndLogBadResponse(text), null);
					}
					ModioLog.Error?.Log($"Unable to reach mod.io servers {webRequest.responseCode}");
					ModioAPI.SetOfflineStatus(isOffline: true);
					webRequest.Abort();
					webRequest.Dispose();
					return (new Error(ErrorCode.CANNOT_OPEN_CONNECTION), null);
				}
				stream = handler.GetStream();
			}
			catch (Exception ex)
			{
				ModioLog.Error?.Log($"Exception in {url}: {ex}");
				webRequest.Abort();
				webRequest.Dispose();
				return (new ErrorException(ex), null);
			}
			return (Error.None, stream);
		}

		private Task<Error> CheckFakeErrorsForTest(string url)
		{
			ModioAPITestSettings testSettings = ModioClient.Settings.GetPlatformSettings<ModioAPITestSettings>();
			if (testSettings == null)
			{
				return Task.FromResult(Error.None);
			}
			if (testSettings.ShouldFakeDisconnected(url))
			{
				return FakeConnectionError();
			}
			if (testSettings.ShouldFakeRateLimit(url))
			{
				return Task.FromResult((Error)new RateLimitError(RateLimitErrorCode.RATELIMITED, 42));
			}
			return Task.FromResult(Error.None);
			async Task<Error> FakeConnectionError()
			{
				await Task.Delay((int)(testSettings.FakeDisconnectedTimeoutDuration * 1000f));
				return new Error(ErrorCode.CANNOT_OPEN_CONNECTION);
			}
		}

		public void SetDefaultHeader(string name, string value)
		{
			_defaultHeaders[name] = value;
		}

		public void RemoveDefaultHeader(string name)
		{
			_defaultHeaders.Remove(name);
		}

		private UnityWebRequest CreateWebRequest(ModioAPIRequest request, string target, DownloadHandler downloadHandler = null)
		{
			UnityWebRequest unityWebRequest = new UnityWebRequest(target, MapMethod(request.Method))
			{
				downloadHandler = (downloadHandler ?? new DownloadHandlerBuffer())
			};
			foreach (KeyValuePair<string, string> defaultHeader in _defaultHeaders)
			{
				unityWebRequest.SetRequestHeader(defaultHeader.Key, defaultHeader.Value);
			}
			unityWebRequest.SetRequestHeader("User-Agent", Version.GetCurrent());
			unityWebRequest.uploadHandler = MapUploadHandler(request);
			if (unityWebRequest.uploadHandler == null)
			{
				unityWebRequest.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
			}
			foreach (KeyValuePair<string, string> headerParameter in request.Options.HeaderParameters)
			{
				unityWebRequest.SetRequestHeader(headerParameter.Key, headerParameter.Value);
			}
			foreach (KeyValuePair<string, string> defaultHeader2 in _defaultHeaders)
			{
				request.Options.HeaderParameters[defaultHeader2.Key] = defaultHeader2.Value;
			}
			return unityWebRequest;
		}

		private static Error EnforceAuthentication(ModioAPIRequest downloadRequest, UnityWebRequest webRequest)
		{
			if (downloadRequest.Options.RequiresAuthentication && !User.Current.IsAuthenticated)
			{
				return new Error(ErrorCode.USER_NOT_AUTHENTICATED);
			}
			if (User.Current.IsAuthenticated)
			{
				webRequest.SetRequestHeader("Authorization", "Bearer " + User.Current?.GetAuthToken());
			}
			return Error.None;
		}

		private async Task<(Error error, T)> GetJson<T>(ModioAPIRequest request, Func<JsonTextReader, Task<T>> reader)
		{
			string target = BuildPath(request);
			Error error = await CheckFakeErrorsForTest(target);
			if ((bool)error)
			{
				return (error: error, default(T));
			}
			using UnityWebRequest webRequest = CreateWebRequest(request, target);
			error = EnforceAuthentication(request, webRequest);
			if ((bool)error)
			{
				return (error: error, default(T));
			}
			_webRequests.Add(webRequest);
			CancellationToken cachedShutdownToken = _cancellationTokenSource?.Token ?? CancellationToken.None;
			try
			{
				await LogRequest(webRequest, request);
				error = await SendRequest(webRequest, cachedShutdownToken);
				if ((bool)error)
				{
					return (error: error, default(T));
				}
				string text = webRequest.downloadHandler.text;
				if (webRequest.responseCode == 204)
				{
					return (error: Error.None, (T)(object)default(Response204));
				}
				ModioLog.Verbose?.Log($"{webRequest.responseCode} | {text}");
				if (webRequest.responseCode < 200 || webRequest.responseCode >= 300)
				{
					if (IsResponseConnectionFailure(webRequest.responseCode))
					{
						ModioLog.Error?.Log($"Unable to reach mod.io servers {webRequest.responseCode}");
						ModioAPI.SetOfflineStatus(isOffline: true);
						return (error: new Error(ErrorCode.CANNOT_OPEN_CONNECTION), default(T));
					}
					if (webRequest.responseCode == 429 && webRequest.GetResponseHeaders().TryGetValue("retry-after", out var value) && !string.IsNullOrEmpty(value) && int.TryParse(value, out var result))
					{
						GetErrorAndLogBadResponse(text);
						return (error: new RateLimitError(RateLimitErrorCode.RATELIMITED, result), default(T));
					}
					return (error: GetErrorAndLogBadResponse(text), default(T));
				}
				if (ModioAPI.IsOffline)
				{
					ModioAPI.SetOfflineStatus(isOffline: false);
				}
				using StringReader stringReader = new StringReader(text);
				using JsonTextReader jsonTextReader = new JsonTextReader(stringReader);
				T item = await reader(jsonTextReader);
				return (error: Error.None, item);
			}
			catch (JsonException arg)
			{
				ModioLog.Verbose?.Log(ErrorCode.HTTP_EXCEPTION.GetMessage($"{target}\n{arg}"));
				return (error: new Error(ErrorCode.INVALID_JSON), default(T));
			}
			catch (Exception ex)
			{
				ModioLog.Error?.Log(ex.GetType());
				return (error: new Error(ErrorCode.INVALID_JSON), default(T));
			}
			finally
			{
				_webRequests.Remove(webRequest);
			}
		}

		private static Error GetErrorAndLogBadResponse(string jsonResponse)
		{
			if (!string.IsNullOrEmpty(jsonResponse) && jsonResponse[0] != '{')
			{
				int num = jsonResponse.IndexOf('{');
				if (num > 0)
				{
					string text = jsonResponse.Substring(0, num);
					ModioLog.Verbose?.Log("Unexpected error from server before JSON: " + text);
					jsonResponse = jsonResponse.Substring(num);
				}
			}
			ErrorObject errorObject;
			try
			{
				using StringReader reader = new StringReader(jsonResponse);
				using JsonTextReader reader2 = new JsonTextReader(reader);
				errorObject = new JsonSerializer().Deserialize<ErrorObject>(reader2);
			}
			catch (JsonException)
			{
				ModioLog.Error?.Log("There is an error with the json response.");
				return new Error(ErrorCode.INVALID_JSON);
			}
			if (errorObject.Error.ErrorRef == 0L)
			{
				ModioLog.Error?.Log("Invalid error returned from API, please contact mod.io support.\n" + $"{errorObject.Error.Code}: {errorObject.Error.Message}");
				return new Error(ErrorCode.UNKNOWN);
			}
			return new Error((ErrorCode)errorObject.Error.ErrorRef);
		}

		public Task<(Error error, T? result)> GetJson<T>(ModioAPIRequest request) where T : struct
		{
			return GetJson(request, (JsonTextReader reader) => Task.FromResult((T?)new JsonSerializer().Deserialize<T>(reader)));
		}

		public Task<(Error error, JToken)> GetJson(ModioAPIRequest request)
		{
			return GetJson(request, (JsonTextReader reader) => JToken.ReadFromAsync(reader));
		}

		private UploadHandler MapUploadHandler(ModioAPIRequest request)
		{
			switch (request.ContentType)
			{
			case ModioAPIRequestContentType.None:
				return null;
			case ModioAPIRequestContentType.FormUrlEncoded:
			{
				string text = CreateFormUrlEncodedContent(request.Options.FormParameters);
				if (!string.IsNullOrEmpty(text))
				{
					return new UploadHandlerRaw(Encoding.UTF8.GetBytes(text))
					{
						contentType = "application/x-www-form-urlencoded"
					};
				}
				return null;
			}
			case ModioAPIRequestContentType.MultipartFormData:
				return CreateMultipartFormDataUploadHandler(request.Options);
			case ModioAPIRequestContentType.ByteArray:
				return PrepareByteArray(request.Options);
			case ModioAPIRequestContentType.String:
				if (request.ContentTypeHint == "application/json")
				{
					return new UploadHandlerRaw(request.Options.BodyDataBytes)
					{
						contentType = request.ContentTypeHint
					};
				}
				break;
			}
			throw new NotImplementedException();
		}

		private UploadHandler CreateMultipartFormDataUploadHandler(ModioAPIRequestOptions options)
		{
			string text = Guid.NewGuid().ToString().ToUpperInvariant();
			using MemoryStream memoryStream = new MemoryStream();
			using (StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.UTF8, 1024, leaveOpen: true))
			{
				streamWriter.WriteLine("--" + text);
				foreach (KeyValuePair<string, string> formParameter in options.FormParameters)
				{
					streamWriter.WriteLine("--" + text);
					streamWriter.WriteLine("Content-Disposition: form-data; name=" + formParameter.Key);
					streamWriter.WriteLine("Content-Type: text/plain; charset=utf-8");
					streamWriter.WriteLine();
					streamWriter.WriteLine(formParameter.Value);
				}
				foreach (KeyValuePair<string, ModioAPIFileParameter> fileParameter in options.FileParameters)
				{
					if (fileParameter.Value.Unused)
					{
						continue;
					}
					using Stream stream = fileParameter.Value.GetContent();
					if (stream != null)
					{
						streamWriter.WriteLine("--" + text);
						streamWriter.WriteLine("Content-Disposition: form-data; name=\"" + fileParameter.Key + "\"; filename=\"" + fileParameter.Value.Name + "\"; filename*=utf-8''" + fileParameter.Value.Name);
						streamWriter.WriteLine("Content-Type: " + fileParameter.Value.ContentType);
						streamWriter.WriteLine();
						streamWriter.Flush();
						stream.CopyTo(memoryStream);
						streamWriter.WriteLine();
					}
				}
				streamWriter.WriteLine("--" + text + "--");
				streamWriter.Flush();
			}
			return new UploadHandlerRaw(memoryStream.ToArray())
			{
				contentType = "multipart/form-data; boundary=" + text
			};
		}

		private static UploadHandler PrepareByteArray(ModioAPIRequestOptions options)
		{
			string text = Guid.NewGuid().ToString().ToUpperInvariant();
			return new UploadHandlerRaw(options.BodyDataBytes)
			{
				contentType = "multipart/form-data; boundary=" + text
			};
		}

		private string CreateFormUrlEncodedContent(Dictionary<string, string> formParameters)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> formParameter in formParameters)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append("&");
				}
				stringBuilder.Append(UnityWebRequest.EscapeURL(formParameter.Key) + "=" + UnityWebRequest.EscapeURL(formParameter.Value));
			}
			return stringBuilder.ToString();
		}

		private string MapMethod(ModioAPIRequestMethod method)
		{
			return method switch
			{
				ModioAPIRequestMethod.Post => "POST", 
				ModioAPIRequestMethod.Put => "PUT", 
				ModioAPIRequestMethod.Get => "GET", 
				ModioAPIRequestMethod.Delete => "DELETE", 
				_ => throw new NotImplementedException(), 
			};
		}

		private string BuildPath(ModioAPIRequest request)
		{
			StringBuilder stringBuilder = new StringBuilder(_basePath + request.GetUri(_defaultParameters));
			foreach (KeyValuePair<string, string> pathParameter in _pathParameters)
			{
				stringBuilder.Replace("{" + pathParameter.Key + "}", pathParameter.Value);
			}
			return stringBuilder.ToString();
		}

		private async Task<Error> SendRequest(UnityWebRequest webRequest, CancellationToken shutdownToken = default(CancellationToken), CancellationToken token = default(CancellationToken))
		{
			UnityWebRequestAsyncOperation operation = webRequest.SendWebRequest();
			while (!operation.isDone)
			{
				if (token.IsCancellationRequested || shutdownToken.IsCancellationRequested)
				{
					webRequest.Abort();
					break;
				}
				await Task.Yield();
			}
			if (shutdownToken.IsCancellationRequested)
			{
				return new Error(ErrorCode.SHUTTING_DOWN);
			}
			if (token.IsCancellationRequested)
			{
				return new Error(ErrorCode.OPERATION_CANCELLED);
			}
			return Error.None;
		}

		public void Dispose()
		{
			foreach (UnityWebRequest webRequest in _webRequests)
			{
				webRequest?.Dispose();
			}
		}

		private Task LogRequest(UnityWebRequest request, ModioAPIRequest modioRequest = null)
		{
			if (ModioLog.Verbose == null)
			{
				return Task.CompletedTask;
			}
			if (request == null)
			{
				return Task.CompletedTask;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(request.method + " " + request.uri.PathAndQuery + " HTTP/1.1");
			if (modioRequest != null)
			{
				foreach (var (text3, text4) in modioRequest.Options.HeaderParameters)
				{
					stringBuilder.AppendLine(string.Equals(text3, "Authorization") ? (text3 + ": Bearer (omitted)") : (text3 + ": " + string.Join(", ", text4)));
				}
			}
			foreach (string defaultParameter in _defaultParameters)
			{
				stringBuilder.AppendLine(defaultParameter);
			}
			if (request.uploadHandler != null && request.uploadHandler.data.Length != 0)
			{
				stringBuilder.AppendLine("Content-Type: " + request.uploadHandler.contentType);
				stringBuilder.AppendLine();
				stringBuilder.Append(Encoding.UTF8.GetString(request.uploadHandler.data));
			}
			ModioLog.Verbose?.Log(stringBuilder.ToString());
			return Task.CompletedTask;
		}

		private static bool IsResponseConnectionFailure(long responseCode)
		{
			if (responseCode != 0L && responseCode != 408)
			{
				return responseCode == 503;
			}
			return true;
		}
	}
	[Serializable]
	public class ModioAndroidSettings : IModioServiceSettings
	{
	}
	public class ModioPreInitializer : MonoBehaviour
	{
		private void Start()
		{
			if (!ModioClient.IsInitialized)
			{
				ModioClient.Init().ForgetTaskSafely();
			}
		}
	}
	internal static class ModioUnity
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void OnAfterAssembliesLoaded()
		{
			ModioUnitySettings modioUnitySettings = Resources.Load<ModioUnitySettings>("mod.io/v3_config_local");
			if (modioUnitySettings == null)
			{
				modioUnitySettings = Resources.Load<ModioUnitySettings>("mod.io/v3_config");
			}
			if (ModioCommandLine.TryGet("gameid", out var value))
			{
				modioUnitySettings.Settings.GameId = int.Parse(value);
			}
			if (ModioCommandLine.TryGet("apikey", out var value2))
			{
				modioUnitySettings.Settings.APIKey = value2;
			}
			if (ModioCommandLine.TryGet("url", out var value3))
			{
				modioUnitySettings.Settings.ServerURL = value3;
			}
			ModioServices.Bind<IModioLogHandler>().FromNew<ModioUnityLogger>(ModioServicePriority.EngineImplementation);
			string text = $"Unity; {UnityEngine.Application.unityVersion}; {UnityEngine.Application.platform}";
			ModioLog.Verbose?.Log(text);
			Version.AddEnvironmentDetails(text);
			if (modioUnitySettings != null)
			{
				ModioServices.BindInstance(modioUnitySettings.Settings);
			}
			else
			{
				ModioLog.Message?.Log("Couldn't find a ModioUnitySettings named 'mod.io/v3_config' to load in a Resources folder");
			}
			ModioServices.Bind<IModioAPIInterface>().FromNew<ModioAPIUnityClient>(ModioServicePriority.EngineImplementation);
			ModioServices.Bind<IModioRootPathProvider>().FromNew<WindowsRootPathProvider>(ModioServicePriority.PlatformProvided, WindowsRootPathProvider.IsPublicEnvironmentVariableSet);
			if (UnityEngine.Application.platform == RuntimePlatform.LinuxPlayer)
			{
				ModioServices.Bind<IModioDataStorage>().FromNew<LinuxDataStorage>(ModioServicePriority.PlatformProvided);
			}
			if (UnityEngine.Application.platform == RuntimePlatform.OSXPlayer)
			{
				ModioServices.Bind<IModioDataStorage>().FromNew<MacDataStorage>(ModioServicePriority.PlatformProvided);
			}
			ModioServices.Bind<IModioRootPathProvider>().FromNew<UnityRootPathProvider>(ModioServicePriority.Default);
			ModioServices.Bind<IWebBrowserHandler>().FromNew<UnityWebBrowserHandler>(ModioServicePriority.EngineImplementation);
			ModioServices.BindErrorMessage<ModioSettings>("Please ensure you've bound a ModioSettings. You can create one using the menu item 'Tools/mod.io/Edit Settings'", (ModioServicePriority)1);
			UnityEngine.Application.quitting += delegate
			{
				ModioClient.Shutdown().ForgetTaskSafely();
			};
			InitPlatform();
		}

		private static void Log(LogLevel logLevel, object message)
		{
			(logLevel switch
			{
				LogLevel.Error => UnityEngine.Debug.LogError, 
				LogLevel.Warning => UnityEngine.Debug.LogWarning, 
				_ => UnityEngine.Debug.Log, 
			})(message);
		}

		private static void InitPlatform()
		{
			ModioAPI.Platform platform = UnityEngine.Application.platform switch
			{
				RuntimePlatform.OSXEditor => ModioAPI.Platform.Mac, 
				RuntimePlatform.OSXPlayer => ModioAPI.Platform.Mac, 
				RuntimePlatform.WindowsPlayer => ModioAPI.Platform.Windows, 
				RuntimePlatform.WindowsEditor => ModioAPI.Platform.Windows, 
				RuntimePlatform.IPhonePlayer => ModioAPI.Platform.IOS, 
				RuntimePlatform.Android => ModioAPI.Platform.Android, 
				RuntimePlatform.LinuxPlayer => ModioAPI.Platform.Linux, 
				RuntimePlatform.LinuxEditor => ModioAPI.Platform.Linux, 
				RuntimePlatform.PS4 => ModioAPI.Platform.PlayStation4, 
				RuntimePlatform.XboxOne => ModioAPI.Platform.XboxOne, 
				RuntimePlatform.Switch => ModioAPI.Platform.Switch, 
				RuntimePlatform.GameCoreXboxSeries => ModioAPI.Platform.XboxSeriesX, 
				RuntimePlatform.GameCoreXboxOne => ModioAPI.Platform.XboxOne, 
				RuntimePlatform.PS5 => ModioAPI.Platform.PlayStation5, 
				_ => ModioAPI.Platform.None, 
			};
			if (platform != ModioAPI.Platform.None)
			{
				ModioAPI.SetPlatform(platform);
			}
		}
	}
	public class ModioUnityLogger : IModioLogHandler
	{
		private readonly string _prefix;

		public ModioUnityLogger()
			: this("[mod.io] ")
		{
		}

		public ModioUnityLogger(string prefix)
		{
			_prefix = prefix;
		}

		public void LogHandler(LogLevel logLevel, object message)
		{
			string arg = logLevel switch
			{
				LogLevel.Error => "[ERROR] ", 
				LogLevel.Warning => "[WARNING] ", 
				_ => string.Empty, 
			};
			ILogger unityLogger = UnityEngine.Debug.unityLogger;
			unityLogger.Log(logLevel switch
			{
				LogLevel.None => LogType.Log, 
				LogLevel.Error => LogType.Error, 
				LogLevel.Warning => LogType.Warning, 
				LogLevel.Message => LogType.Log, 
				LogLevel.Verbose => LogType.Log, 
				_ => LogType.Log, 
			}, $"{_prefix}{arg}{message}");
		}
	}
	[CreateAssetMenu(fileName = "config.asset", menuName = "ModIo/v3/config")]
	public class ModioUnitySettings : ScriptableObject
	{
		public const string DefaultResourceName = "mod.io/v3_config";

		public const string DefaultResourceNameOverride = "mod.io/v3_config_local";

		[SerializeField]
		private ModioSettings _settings;

		[SerializeField]
		[SerializeReference]
		private IModioServiceSettings[] _platformSettings;

		public ModioSettings Settings
		{
			get
			{
				_settings.PlatformSettings = _platformSettings;
				return _settings;
			}
		}
	}
	internal class StreamingDownloadHandler : DownloadHandlerScript
	{
		private class ChunkedStreamBuffer : Stream
		{
			private class BufferChunk : IDisposable
			{
				internal NativeArray<byte> Data { get; }

				internal int Offset { get; set; }

				internal int Length => Data.Length;

				internal bool HasData => Offset < Data.Length;

				internal int RemainingLength => Data.Length - Offset;

				internal BufferChunk(NativeArray<byte> data, int offset)
				{
					Data = data;
					Offset = offset;
				}

				public void Dispose()
				{
					Data.Dispose();
				}
			}

			private class AsyncAutoResetEvent
			{
				[StructLayout(LayoutKind.Sequential, Size = 1)]
				private struct Empty
				{
				}

				private readonly Queue<TaskCompletionSource<Empty>> _signalWaiters = new Queue<TaskCompletionSource<Empty>>();

				private bool _signaled;

				public Task WaitAsync(CancellationToken cancellationToken = default(CancellationToken))
				{
					if (cancellationToken.IsCancellationRequested)
					{
						return Task.FromCanceled(cancellationToken);
					}
					lock (_signalWaiters)
					{
						if (_signaled)
						{
							_signaled = false;
							return Task.CompletedTask;
						}
						TaskCompletionSource<Empty> taskCompletionSource = new TaskCompletionSource<Empty>(TaskCreationOptions.RunContinuationsAsynchronously);
						if (cancellationToken.IsCancellationRequested)
						{
							taskCompletionSource.TrySetCanceled(cancellationToken);
							return taskCompletionSource.Task;
						}
						_signalWaiters.Enqueue(taskCompletionSource);
						return taskCompletionSource.Task;
					}
				}

				public void Set()
				{
					TaskCompletionSource<Empty> taskCompletionSource = null;
					lock (_signalWaiters)
					{
						if (_signalWaiters.Count > 0)
						{
							taskCompletionSource = _signalWaiters.Dequeue();
						}
						else
						{
							_signaled = true;
						}
					}
					taskCompletionSource?.TrySetResult(default(Empty));
				}
			}

			private readonly ConcurrentQueue<BufferChunk> _dataQueue = new ConcurrentQueue<BufferChunk>();

			private readonly CancellationToken _shutdownToken;

			private readonly AsyncAutoResetEvent _signal = new AsyncAutoResetEvent();

			public override bool CanRead => true;

			public override bool CanSeek => false;

			public override bool CanWrite => true;

			public override long Length => -1L;

			public override long Position { get; set; } = -1L;

			private bool IsDone { get; set; }

			internal ChunkedStreamBuffer(CancellationToken shutdownToken)
			{
				_shutdownToken = shutdownToken;
			}

			public override void Flush()
			{
				BufferChunk result;
				while (_dataQueue.TryDequeue(out result))
				{
					result.Dispose();
				}
				_dataQueue.Clear();
			}

			public override int Read(byte[] buffer, int offset, int count)
			{
				return ReadAsync(buffer, offset, count, CancellationToken.None).Result;
			}

			public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
			{
				if (cancellationToken == CancellationToken.None)
				{
					cancellationToken = _shutdownToken;
				}
				int totalBytesRead = 0;
				while (totalBytesRead < count)
				{
					BufferChunk result;
					while (!_dataQueue.TryPeek(out result))
					{
						if (cancellationToken.IsCancellationRequested)
						{
							cancellationToken.ThrowIfCancellationRequested();
						}
						if (IsDone && _dataQueue.IsEmpty)
						{
							return totalBytesRead;
						}
						if (totalBytesRead > 0)
						{
							return totalBytesRead;
						}
						await _signal.WaitAsync(_shutdownToken);
					}
					int num = Math.Min(result.RemainingLength, count - totalBytesRead);
					NativeArray<byte>.Copy(result.Data, result.Offset, buffer, offset + totalBytesRead, num);
					totalBytesRead += num;
					result.Offset += num;
					if (!result.HasData)
					{
						_dataQueue.TryDequeue(out var _);
						result.Dispose();
					}
				}
				return totalBytesRead;
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				throw new NotSupportedException();
			}

			public override void SetLength(long value)
			{
				throw new NotSupportedException();
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				if (!_shutdownToken.IsCancellationRequested)
				{
					int num = Math.Min(buffer.Length, count);
					NativeArray<byte> nativeArray = new NativeArray<byte>(num, Allocator.Persistent);
					NativeArray<byte>.Copy(buffer, offset, nativeArray, 0, num - offset);
					_dataQueue.Enqueue(new BufferChunk(nativeArray, 0));
					_signal.Set();
				}
			}

			public void Complete()
			{
				IsDone = true;
				_signal.Set();
			}
		}

		private readonly ChunkedStreamBuffer _streamBuffer;

		private readonly CancellationToken _cancellationToken;

		private readonly TaskCompletionSource<bool> _hasReceivedHeaders = new TaskCompletionSource<bool>();

		private UnityWebRequest _callingRequest;

		internal StreamingDownloadHandler(int bufferSize = 1048576, CancellationToken token = default(CancellationToken))
			: this(new byte[bufferSize], token)
		{
		}

		private StreamingDownloadHandler(byte[] buffer, CancellationToken token = default(CancellationToken))
			: base(buffer)
		{
			_streamBuffer = new ChunkedStreamBuffer(token);
			_cancellationToken = token;
		}

		public void SetCallingRequest(UnityWebRequest request)
		{
			_callingRequest = request;
		}

		internal Stream GetStream()
		{
			return _streamBuffer;
		}

		protected override bool ReceiveData(byte[] dataReceived, int dataLength)
		{
			if (_cancellationToken.IsCancellationRequested)
			{
				_callingRequest.Abort();
				_streamBuffer.Flush();
				_hasReceivedHeaders.TrySetCanceled();
				return true;
			}
			_streamBuffer.Write(dataReceived, 0, dataLength);
			_hasReceivedHeaders.TrySetResult(result: true);
			return true;
		}

		public async Task ResponseReceived(CancellationToken token)
		{
			await _hasReceivedHeaders.Task;
		}

		protected override void CompleteContent()
		{
			base.CompleteContent();
			_streamBuffer.Complete();
		}
	}
	public class UnityRootPathProvider : IModioRootPathProvider
	{
		public string Path => UnityEngine.Application.persistentDataPath;

		public string UserPath => System.IO.Path.Combine(UnityEngine.Application.persistentDataPath, "UserData");
	}
	public class UnityWebBrowserHandler : IWebBrowserHandler
	{
		public void OpenUrl(string url)
		{
			UnityEngine.Device.Application.OpenURL(url);
		}
	}
}
namespace Modio.Unity.Settings
{
	[Serializable]
	public class ModioComponentUISettings : IModioServiceSettings
	{
		public bool ShowMonetizationUI;

		public bool ShowEnableModToggle;

		public bool FallbackToEmailAuthentication;
	}
}
