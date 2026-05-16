using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;
using UnityEngineInternal;

[assembly: InternalsVisibleTo("UnityEngine.ScreenCaptureModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Application")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.CommonUtils")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Tooling")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.2D")]
[assembly: InternalsVisibleTo("Unity.DeploymentTests.Services")]
[assembly: InternalsVisibleTo("Unity.Burst.Editor")]
[assembly: InternalsVisibleTo("Unity.Burst")]
[assembly: InternalsVisibleTo("Unity.Automation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Deployment")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("UnityEngine.TestRunner")]
[assembly: InternalsVisibleTo("UnityEngine.Purchasing")]
[assembly: InternalsVisibleTo("UnityEngine.Advertisements")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestTextureModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityTestProtocolModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityCurlModule")]
[assembly: InternalsVisibleTo("UnityEngine.UmbraModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainPhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubsystemsModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubstanceModule")]
[assembly: InternalsVisibleTo("UnityEngine.StreamingModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteMaskModule")]
[assembly: InternalsVisibleTo("UnityEngine.TilemapModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestWWWModule")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("UnityEngine.VFXModule")]
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS4VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4Module")]
[assembly: InternalsVisibleTo("UnityEngine.SwitchModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("UnityEngine.XRModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteShapeModule")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.009")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.008")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.007")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.006")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.012")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.001")]
[assembly: InternalsVisibleTo("UnityEngine.Core.Runtime.Tests")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.013")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.014")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.015")]
[assembly: InternalsVisibleTo("Unity.Subsystem.Registration")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.024")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.023")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.022")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.021")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.020")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.019")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.018")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.017")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.016")]
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.ShaderVariantAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.RuntimeInitializeOnLoadManagerInitializerModule")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConnectModule")]
[assembly: InternalsVisibleTo("UnityEngine.ContentLoadModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterRendererModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterInputModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClothModule")]
[assembly: InternalsVisibleTo("UnityEngine.AudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.AssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.HotReloadModule")]
[assembly: InternalsVisibleTo("UnityEngine.AnimationModule")]
[assembly: InternalsVisibleTo("UnityEngine.AndroidJNIModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.AccessibilityModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputModule")]
[assembly: InternalsVisibleTo("UnityEngine.JSONSerializeModule")]
[assembly: InternalsVisibleTo("UnityEngine.PhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.AMDModule")]
[assembly: InternalsVisibleTo("UnityEngine.AIModule")]
[assembly: InternalsVisibleTo("UnityEngine.CoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.SharedInternalsModule")]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("UnityEngine.ARModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.PropertiesModule")]
[assembly: InternalsVisibleTo("UnityEngine.Physics2DModule")]
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.ParticleSystemModule")]
[assembly: InternalsVisibleTo("UnityEngine.NVIDIAModule")]
[assembly: InternalsVisibleTo("UnityEngine.MultiplayerModule")]
[assembly: InternalsVisibleTo("UnityEngine.MarshallingModule")]
[assembly: InternalsVisibleTo("UnityEngine.LocalizationModule")]
[assembly: InternalsVisibleTo("UnityEngine.InsightsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConsentModule")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
[assembly: InternalsVisibleTo("UnityEngine.IMGUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputForUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreFontEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreTextEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.ImageConversionModule")]
[assembly: InternalsVisibleTo("UnityEngine.GameCenterModule")]
[assembly: InternalsVisibleTo("UnityEngine.GIModule")]
[assembly: InternalsVisibleTo("UnityEngine.GridModule")]
[assembly: InternalsVisibleTo("UnityEngine.HierarchyCoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextRenderingModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputLegacyModule")]
[assembly: InternalsVisibleTo("UnityEngine.GraphicsStateCollectionSerializerModule")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngineInternal
{
	internal static class WebRequestUtils
	{
		private static Regex domainRegex = new Regex("^\\s*\\w+(?:\\.\\w+)+(\\/.*)?$");

		[RequiredByNativeCode]
		internal static string RedirectTo(string baseUri, string redirectUri)
		{
			Uri uri = ((redirectUri[0] != '/') ? new Uri(redirectUri, UriKind.RelativeOrAbsolute) : new Uri(redirectUri, UriKind.Relative));
			if (uri.IsAbsoluteUri)
			{
				return uri.AbsoluteUri;
			}
			Uri baseUri2 = new Uri(baseUri, UriKind.Absolute);
			Uri uri2 = new Uri(baseUri2, uri);
			return uri2.AbsoluteUri;
		}

		internal static string MakeInitialUrl(string targetUrl, string localUrl)
		{
			if (string.IsNullOrEmpty(targetUrl))
			{
				return "";
			}
			bool prependProtocol = false;
			Uri uri = new Uri(localUrl);
			Uri uri2 = null;
			if (targetUrl[0] == '/')
			{
				uri2 = new Uri(uri, targetUrl);
				prependProtocol = true;
			}
			if (uri2 == null && domainRegex.IsMatch(targetUrl))
			{
				targetUrl = uri.Scheme + "://" + targetUrl;
				prependProtocol = true;
			}
			FormatException ex = null;
			try
			{
				if (uri2 == null && targetUrl[0] != '.')
				{
					uri2 = new Uri(targetUrl);
				}
			}
			catch (FormatException ex2)
			{
				ex = ex2;
			}
			if (uri2 == null)
			{
				try
				{
					uri2 = new Uri(uri, targetUrl);
					prependProtocol = true;
				}
				catch (FormatException)
				{
					throw ex;
				}
			}
			return MakeUriString(uri2, targetUrl, prependProtocol);
		}

		internal static string MakeUriString(Uri targetUri, string targetUrl, bool prependProtocol)
		{
			if (targetUri.IsFile)
			{
				if (!targetUri.IsLoopback)
				{
					return targetUri.OriginalString;
				}
				string text = targetUri.AbsolutePath;
				string originalString = targetUri.OriginalString;
				if (text.Contains("%"))
				{
					if (text.Contains('+') && !originalString.StartsWith("file:"))
					{
						return "file:///" + originalString.Replace('\\', '/');
					}
					text = URLDecode(text);
				}
				if (text.Length > 0 && text[0] != '/')
				{
					text = "/" + text;
				}
				if (originalString.StartsWith("file://\\\\?\\", StringComparison.InvariantCultureIgnoreCase) || originalString.StartsWith("file:///\\\\?\\", StringComparison.InvariantCultureIgnoreCase))
				{
					return originalString;
				}
				return "file://" + text;
			}
			string scheme = targetUri.Scheme;
			if (!prependProtocol && targetUrl.Length >= scheme.Length + 2 && targetUrl[scheme.Length + 1] != '/')
			{
				StringBuilder stringBuilder = new StringBuilder(scheme, targetUrl.Length);
				stringBuilder.Append(':');
				if (scheme == "jar")
				{
					string text2 = targetUri.AbsolutePath;
					if (text2.Contains("%"))
					{
						text2 = URLDecode(text2);
					}
					if (text2.StartsWith("file:/") && text2.Length > 6 && text2[6] != '/')
					{
						stringBuilder.Append("file://");
						stringBuilder.Append(text2.Substring(5));
					}
					else
					{
						stringBuilder.Append(text2);
					}
					return stringBuilder.ToString();
				}
				stringBuilder.Append(targetUri.PathAndQuery);
				stringBuilder.Append(targetUri.Fragment);
				return stringBuilder.ToString();
			}
			if (targetUrl.Contains("%"))
			{
				return targetUri.OriginalString;
			}
			return targetUri.AbsoluteUri;
		}

		private static string URLDecode(string encoded)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(encoded);
			byte[] bytes2 = WWWTranscoder.URLDecode(bytes);
			return Encoding.UTF8.GetString(bytes2);
		}
	}
}
namespace UnityEngine
{
	public class WWWForm
	{
		private List<byte[]> formData;

		private List<string> fieldNames;

		private List<string> fileNames;

		private List<string> types;

		private byte[] boundary;

		private bool containsFiles = false;

		private static byte[] dDash = DefaultEncoding.GetBytes("--");

		private static byte[] crlf = DefaultEncoding.GetBytes("\r\n");

		private static byte[] contentTypeHeader = DefaultEncoding.GetBytes("Content-Type: ");

		private static byte[] dispositionHeader = DefaultEncoding.GetBytes("Content-disposition: form-data; name=\"");

		private static byte[] endQuote = DefaultEncoding.GetBytes("\"");

		private static byte[] fileNameField = DefaultEncoding.GetBytes("; filename=\"");

		private static byte[] ampersand = DefaultEncoding.GetBytes("&");

		private static byte[] equal = DefaultEncoding.GetBytes("=");

		internal static Encoding DefaultEncoding => Encoding.ASCII;

		public Dictionary<string, string> headers
		{
			get
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				if (containsFiles)
				{
					dictionary["Content-Type"] = "multipart/form-data; boundary=\"" + Encoding.UTF8.GetString(boundary, 0, boundary.Length) + "\"";
				}
				else
				{
					dictionary["Content-Type"] = "application/x-www-form-urlencoded";
				}
				return dictionary;
			}
		}

		public byte[] data
		{
			get
			{
				using MemoryStream memoryStream = new MemoryStream(1024);
				if (containsFiles)
				{
					for (int i = 0; i < formData.Count; i++)
					{
						memoryStream.Write(crlf, 0, crlf.Length);
						memoryStream.Write(dDash, 0, dDash.Length);
						memoryStream.Write(boundary, 0, boundary.Length);
						memoryStream.Write(crlf, 0, crlf.Length);
						memoryStream.Write(contentTypeHeader, 0, contentTypeHeader.Length);
						byte[] bytes = Encoding.UTF8.GetBytes(types[i]);
						memoryStream.Write(bytes, 0, bytes.Length);
						memoryStream.Write(crlf, 0, crlf.Length);
						memoryStream.Write(dispositionHeader, 0, dispositionHeader.Length);
						string headerName = Encoding.UTF8.HeaderName;
						string text = fieldNames[i];
						if (!WWWTranscoder.SevenBitClean(text, Encoding.UTF8) || text.IndexOf("=?") > -1)
						{
							text = "=?" + headerName + "?Q?" + WWWTranscoder.QPEncode(text, Encoding.UTF8) + "?=";
						}
						byte[] bytes2 = Encoding.UTF8.GetBytes(text);
						memoryStream.Write(bytes2, 0, bytes2.Length);
						memoryStream.Write(endQuote, 0, endQuote.Length);
						if (fileNames[i] != null)
						{
							string text2 = fileNames[i];
							if (!WWWTranscoder.SevenBitClean(text2, Encoding.UTF8) || text2.IndexOf("=?") > -1)
							{
								text2 = "=?" + headerName + "?Q?" + WWWTranscoder.QPEncode(text2, Encoding.UTF8) + "?=";
							}
							byte[] bytes3 = Encoding.UTF8.GetBytes(text2);
							memoryStream.Write(fileNameField, 0, fileNameField.Length);
							memoryStream.Write(bytes3, 0, bytes3.Length);
							memoryStream.Write(endQuote, 0, endQuote.Length);
						}
						memoryStream.Write(crlf, 0, crlf.Length);
						memoryStream.Write(crlf, 0, crlf.Length);
						byte[] array = formData[i];
						memoryStream.Write(array, 0, array.Length);
					}
					memoryStream.Write(crlf, 0, crlf.Length);
					memoryStream.Write(dDash, 0, dDash.Length);
					memoryStream.Write(boundary, 0, boundary.Length);
					memoryStream.Write(dDash, 0, dDash.Length);
					memoryStream.Write(crlf, 0, crlf.Length);
				}
				else
				{
					for (int j = 0; j < formData.Count; j++)
					{
						byte[] array2 = WWWTranscoder.DataEncode(Encoding.UTF8.GetBytes(fieldNames[j]));
						byte[] toEncode = formData[j];
						byte[] array3 = WWWTranscoder.DataEncode(toEncode);
						if (j > 0)
						{
							memoryStream.Write(ampersand, 0, ampersand.Length);
						}
						memoryStream.Write(array2, 0, array2.Length);
						memoryStream.Write(equal, 0, equal.Length);
						memoryStream.Write(array3, 0, array3.Length);
					}
				}
				return memoryStream.ToArray();
			}
		}

		public WWWForm()
		{
			formData = new List<byte[]>();
			fieldNames = new List<string>();
			fileNames = new List<string>();
			types = new List<string>();
			boundary = new byte[40];
			for (int i = 0; i < 40; i++)
			{
				int num = Random.Range(48, 110);
				if (num > 57)
				{
					num += 7;
				}
				if (num > 90)
				{
					num += 6;
				}
				boundary[i] = (byte)num;
			}
		}

		public void AddField(string fieldName, string value)
		{
			AddField(fieldName, value, Encoding.UTF8);
		}

		public void AddField(string fieldName, string value, Encoding e)
		{
			fieldNames.Add(fieldName);
			fileNames.Add(null);
			formData.Add(e.GetBytes(value));
			types.Add("text/plain; charset=\"" + e.WebName + "\"");
		}

		public void AddField(string fieldName, int i)
		{
			AddField(fieldName, i.ToString());
		}

		[ExcludeFromDocs]
		public void AddBinaryData(string fieldName, byte[] contents)
		{
			AddBinaryData(fieldName, contents, null, null);
		}

		[ExcludeFromDocs]
		public void AddBinaryData(string fieldName, byte[] contents, string fileName)
		{
			AddBinaryData(fieldName, contents, fileName, null);
		}

		public void AddBinaryData(string fieldName, byte[] contents, [UnityEngine.Internal.DefaultValue("null")] string fileName, [UnityEngine.Internal.DefaultValue("null")] string mimeType)
		{
			containsFiles = true;
			bool flag = contents.Length > 8 && contents[0] == 137 && contents[1] == 80 && contents[2] == 78 && contents[3] == 71 && contents[4] == 13 && contents[5] == 10 && contents[6] == 26 && contents[7] == 10;
			if (fileName == null)
			{
				fileName = fieldName + (flag ? ".png" : ".dat");
			}
			if (mimeType == null)
			{
				mimeType = ((!flag) ? "application/octet-stream" : "image/png");
			}
			fieldNames.Add(fieldName);
			fileNames.Add(fileName);
			formData.Add(contents);
			types.Add(mimeType);
		}
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UnityWebRequestWWWModule" })]
	internal class WWWTranscoder
	{
		private static byte[] ucHexChars = WWWForm.DefaultEncoding.GetBytes("0123456789ABCDEF");

		private static byte[] lcHexChars = WWWForm.DefaultEncoding.GetBytes("0123456789abcdef");

		private static byte urlEscapeChar = 37;

		private static byte[] urlSpace = new byte[1] { 43 };

		private static byte[] dataSpace = WWWForm.DefaultEncoding.GetBytes("%20");

		private static byte[] urlForbidden = WWWForm.DefaultEncoding.GetBytes("@&;:<>=?\"'/\\!#%+$,{}|^[]`");

		private static byte qpEscapeChar = 61;

		private static byte[] qpSpace = new byte[1] { 95 };

		private static byte[] qpForbidden = WWWForm.DefaultEncoding.GetBytes("&;=?\"'%+_");

		private static byte Hex2Byte(byte[] b, int offset)
		{
			byte b2 = 0;
			for (int i = offset; i < offset + 2; i++)
			{
				b2 *= 16;
				int num = b[i];
				if (num >= 48 && num <= 57)
				{
					num -= 48;
				}
				else if (num >= 65 && num <= 75)
				{
					num -= 55;
				}
				else if (num >= 97 && num <= 102)
				{
					num -= 87;
				}
				if (num > 15)
				{
					return 63;
				}
				b2 += (byte)num;
			}
			return b2;
		}

		private static void Byte2Hex(byte b, byte[] hexChars, out byte byte0, out byte byte1)
		{
			byte0 = hexChars[b >> 4];
			byte1 = hexChars[b & 0xF];
		}

		public static string URLEncode(string toEncode)
		{
			return URLEncode(toEncode, Encoding.UTF8);
		}

		public static string URLEncode(string toEncode, Encoding e)
		{
			byte[] array = Encode(e.GetBytes(toEncode), urlEscapeChar, urlSpace, urlForbidden, uppercase: false);
			return WWWForm.DefaultEncoding.GetString(array, 0, array.Length);
		}

		public static byte[] URLEncode(byte[] toEncode)
		{
			return Encode(toEncode, urlEscapeChar, urlSpace, urlForbidden, uppercase: false);
		}

		public static string DataEncode(string toEncode)
		{
			return DataEncode(toEncode, Encoding.UTF8);
		}

		public static string DataEncode(string toEncode, Encoding e)
		{
			byte[] array = Encode(e.GetBytes(toEncode), urlEscapeChar, dataSpace, urlForbidden, uppercase: false);
			return WWWForm.DefaultEncoding.GetString(array, 0, array.Length);
		}

		public static byte[] DataEncode(byte[] toEncode)
		{
			return Encode(toEncode, urlEscapeChar, dataSpace, urlForbidden, uppercase: false);
		}

		public static string QPEncode(string toEncode)
		{
			return QPEncode(toEncode, Encoding.UTF8);
		}

		public static string QPEncode(string toEncode, Encoding e)
		{
			byte[] array = Encode(e.GetBytes(toEncode), qpEscapeChar, qpSpace, qpForbidden, uppercase: true);
			return WWWForm.DefaultEncoding.GetString(array, 0, array.Length);
		}

		public static byte[] QPEncode(byte[] toEncode)
		{
			return Encode(toEncode, qpEscapeChar, qpSpace, qpForbidden, uppercase: true);
		}

		public static byte[] Encode(byte[] input, byte escapeChar, byte[] space, byte[] forbidden, bool uppercase)
		{
			using MemoryStream memoryStream = new MemoryStream(input.Length * 2);
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] == 32)
				{
					memoryStream.Write(space, 0, space.Length);
				}
				else if (input[i] < 32 || input[i] > 126 || ByteArrayContains(forbidden, input[i]))
				{
					memoryStream.WriteByte(escapeChar);
					Byte2Hex(input[i], uppercase ? ucHexChars : lcHexChars, out var @byte, out var byte2);
					memoryStream.WriteByte(@byte);
					memoryStream.WriteByte(byte2);
				}
				else
				{
					memoryStream.WriteByte(input[i]);
				}
			}
			return memoryStream.ToArray();
		}

		private static bool ByteArrayContains(byte[] array, byte b)
		{
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				if (array[i] == b)
				{
					return true;
				}
			}
			return false;
		}

		public static string URLDecode(string toEncode)
		{
			return URLDecode(toEncode, Encoding.UTF8);
		}

		public static string URLDecode(string toEncode, Encoding e)
		{
			byte[] array = Decode(WWWForm.DefaultEncoding.GetBytes(toEncode), urlEscapeChar, urlSpace);
			return e.GetString(array, 0, array.Length);
		}

		public static byte[] URLDecode(byte[] toEncode)
		{
			return Decode(toEncode, urlEscapeChar, urlSpace);
		}

		public static string DataDecode(string toDecode)
		{
			return DataDecode(toDecode, Encoding.UTF8);
		}

		public static string DataDecode(string toDecode, Encoding e)
		{
			byte[] array = Decode(WWWForm.DefaultEncoding.GetBytes(toDecode), urlEscapeChar, dataSpace);
			return e.GetString(array, 0, array.Length);
		}

		public static byte[] DataDecode(byte[] toDecode)
		{
			return Decode(toDecode, urlEscapeChar, dataSpace);
		}

		public static string QPDecode(string toEncode)
		{
			return QPDecode(toEncode, Encoding.UTF8);
		}

		public static string QPDecode(string toEncode, Encoding e)
		{
			byte[] array = Decode(WWWForm.DefaultEncoding.GetBytes(toEncode), qpEscapeChar, qpSpace);
			return e.GetString(array, 0, array.Length);
		}

		public static byte[] QPDecode(byte[] toEncode)
		{
			return Decode(toEncode, qpEscapeChar, qpSpace);
		}

		private static bool ByteSubArrayEquals(byte[] array, int index, byte[] comperand)
		{
			if (array.Length - index < comperand.Length)
			{
				return false;
			}
			for (int i = 0; i < comperand.Length; i++)
			{
				if (array[index + i] != comperand[i])
				{
					return false;
				}
			}
			return true;
		}

		public static byte[] Decode(byte[] input, byte escapeChar, byte[] space)
		{
			using MemoryStream memoryStream = new MemoryStream(input.Length);
			for (int i = 0; i < input.Length; i++)
			{
				if (ByteSubArrayEquals(input, i, space))
				{
					i += space.Length - 1;
					memoryStream.WriteByte(32);
				}
				else if (input[i] == escapeChar && i + 2 < input.Length)
				{
					i++;
					memoryStream.WriteByte(Hex2Byte(input, i++));
				}
				else
				{
					memoryStream.WriteByte(input[i]);
				}
			}
			return memoryStream.ToArray();
		}

		public static bool SevenBitClean(string s)
		{
			return SevenBitClean(s, Encoding.UTF8);
		}

		public unsafe static bool SevenBitClean(string s, Encoding e)
		{
			if (string.IsNullOrEmpty(s))
			{
				return true;
			}
			int num = s.Length * 2;
			byte* ptr = stackalloc byte[(int)(uint)num];
			int bytes;
			fixed (char* chars = s)
			{
				bytes = e.GetBytes(chars, s.Length, ptr, num);
			}
			return SevenBitClean(ptr, bytes);
		}

		public unsafe static bool SevenBitClean(byte* input, int inputLength)
		{
			for (int i = 0; i < inputLength; i++)
			{
				if (input[i] < 32 || input[i] > 126)
				{
					return false;
				}
			}
			return true;
		}
	}
}
namespace UnityEngine.Networking
{
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/UnityWebRequest/Public/CertificateHandler/CertificateHandlerScript.h")]
	public class CertificateHandler : IDisposable
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(CertificateHandler handler)
			{
				return handler.m_Ptr;
			}
		}

		[NonSerialized]
		internal IntPtr m_Ptr;

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Create([Unmarshalled] CertificateHandler obj);

		[NativeMethod(IsThreadSafe = true)]
		private void ReleaseFromScripting()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ReleaseFromScripting_Injected(intPtr);
		}

		protected CertificateHandler()
		{
			m_Ptr = Create(this);
		}

		~CertificateHandler()
		{
			Dispose();
		}

		protected virtual bool ValidateCertificate(byte[] certificateData)
		{
			return false;
		}

		[RequiredByNativeCode]
		internal bool ValidateCertificateNative(byte[] certificateData)
		{
			return ValidateCertificate(certificateData);
		}

		public void Dispose()
		{
			if (m_Ptr != IntPtr.Zero)
			{
				ReleaseFromScripting();
				m_Ptr = IntPtr.Zero;
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ReleaseFromScripting_Injected(IntPtr _unity_self);
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/UnityWebRequest/Public/DownloadHandler/DownloadHandler.h")]
	public class DownloadHandler : IDisposable
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(DownloadHandler handler)
			{
				return handler.m_Ptr;
			}
		}

		[NonSerialized]
		[VisibleToOtherModules]
		internal IntPtr m_Ptr;

		public bool isDone => IsDone();

		public string error => GetErrorMsg();

		public NativeArray<byte>.ReadOnly nativeData => GetNativeData().AsReadOnly();

		public byte[] data => GetData();

		public string text => GetText();

		[NativeMethod(IsThreadSafe = true)]
		private void ReleaseFromScripting()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ReleaseFromScripting_Injected(intPtr);
		}

		[VisibleToOtherModules]
		internal DownloadHandler()
		{
		}

		~DownloadHandler()
		{
			Dispose();
		}

		public virtual void Dispose()
		{
			if (m_Ptr != IntPtr.Zero)
			{
				ReleaseFromScripting();
				m_Ptr = IntPtr.Zero;
			}
		}

		private bool IsDone()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IsDone_Injected(intPtr);
		}

		private string GetErrorMsg()
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetErrorMsg_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		protected virtual NativeArray<byte> GetNativeData()
		{
			return default(NativeArray<byte>);
		}

		protected virtual byte[] GetData()
		{
			return InternalGetByteArray(this);
		}

		protected unsafe virtual string GetText()
		{
			NativeArray<byte> nativeArray = GetNativeData();
			if (nativeArray.IsCreated && nativeArray.Length > 0)
			{
				return new string((sbyte*)nativeArray.GetUnsafeReadOnlyPtr(), 0, nativeArray.Length, GetTextEncoder());
			}
			return "";
		}

		private Encoding GetTextEncoder()
		{
			string contentType = GetContentType();
			if (!string.IsNullOrEmpty(contentType))
			{
				int num = contentType.IndexOf("charset", StringComparison.OrdinalIgnoreCase);
				if (num > -1)
				{
					int num2 = contentType.IndexOf('=', num);
					if (num2 > -1)
					{
						string text = contentType.Substring(num2 + 1).Trim().Trim('\'', '"')
							.Trim();
						int num3 = text.IndexOf(';');
						if (num3 > -1)
						{
							text = text.Substring(0, num3);
						}
						try
						{
							return Encoding.GetEncoding(text);
						}
						catch (ArgumentException ex)
						{
							Debug.LogWarning($"Unsupported encoding '{text}': {ex.Message}");
						}
						catch (NotSupportedException ex2)
						{
							Debug.LogWarning($"Unsupported encoding '{text}': {ex2.Message}");
						}
					}
				}
			}
			return Encoding.UTF8;
		}

		private string GetContentType()
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetContentType_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[RequiredByNativeCode]
		protected virtual bool ReceiveData(byte[] data, int dataLength)
		{
			return true;
		}

		[RequiredByNativeCode]
		protected virtual void ReceiveContentLengthHeader(ulong contentLength)
		{
			ReceiveContentLength((int)contentLength);
		}

		[Obsolete("Use ReceiveContentLengthHeader")]
		protected virtual void ReceiveContentLength(int contentLength)
		{
		}

		[RequiredByNativeCode]
		protected virtual void CompleteContent()
		{
		}

		[RequiredByNativeCode]
		protected virtual float GetProgress()
		{
			return 0f;
		}

		protected static T GetCheckedDownloader<T>(UnityWebRequest www) where T : DownloadHandler
		{
			if (www == null)
			{
				throw new NullReferenceException("Cannot get content from a null UnityWebRequest object");
			}
			if (!www.isDone)
			{
				throw new InvalidOperationException("Cannot get content from an unfinished UnityWebRequest object");
			}
			if (www.result == UnityWebRequest.Result.ProtocolError)
			{
				throw new InvalidOperationException(www.error);
			}
			return (T)www.downloadHandler;
		}

		[VisibleToOtherModules]
		[NativeThrows]
		internal unsafe static byte* InternalGetByteArray(DownloadHandler dh, out int length)
		{
			return InternalGetByteArray_Injected((dh == null) ? ((IntPtr)0) : BindingsMarshaller.ConvertToNative(dh), out length);
		}

		internal static byte[] InternalGetByteArray(DownloadHandler dh)
		{
			NativeArray<byte> nativeArray = dh.GetNativeData();
			if (nativeArray.IsCreated)
			{
				return nativeArray.ToArray();
			}
			return null;
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UnityWebRequestAudioModule", "UnityEngine.UnityWebRequestTextureModule" })]
		internal unsafe static NativeArray<byte> InternalGetNativeArray(DownloadHandler dh, ref NativeArray<byte> nativeArray)
		{
			int length;
			byte* bytes = InternalGetByteArray(dh, out length);
			if (nativeArray.IsCreated)
			{
				if (nativeArray.Length == length)
				{
					return nativeArray;
				}
				DisposeNativeArray(ref nativeArray);
			}
			CreateNativeArrayForNativeData(ref nativeArray, bytes, length);
			return nativeArray;
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UnityWebRequestAudioModule", "UnityEngine.UnityWebRequestTextureModule" })]
		internal static void DisposeNativeArray(ref NativeArray<byte> data)
		{
			if (data.IsCreated)
			{
				data = default(NativeArray<byte>);
			}
		}

		internal unsafe static void CreateNativeArrayForNativeData(ref NativeArray<byte> data, byte* bytes, int length)
		{
			data = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(bytes, length, Allocator.Persistent);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ReleaseFromScripting_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsDone_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetErrorMsg_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetContentType_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern byte* InternalGetByteArray_Injected(IntPtr dh, out int length);
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/UnityWebRequest/Public/DownloadHandler/DownloadHandlerBuffer.h")]
	public sealed class DownloadHandlerBuffer : DownloadHandler
	{
		internal new static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(DownloadHandlerBuffer handler)
			{
				return handler.m_Ptr;
			}
		}

		private NativeArray<byte> m_NativeData;

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Create([Unmarshalled] DownloadHandlerBuffer obj);

		private void InternalCreateBuffer()
		{
			m_Ptr = Create(this);
		}

		public DownloadHandlerBuffer()
		{
			InternalCreateBuffer();
		}

		protected override NativeArray<byte> GetNativeData()
		{
			return DownloadHandler.InternalGetNativeArray(this, ref m_NativeData);
		}

		public override void Dispose()
		{
			DownloadHandler.DisposeNativeArray(ref m_NativeData);
			base.Dispose();
		}

		public static string GetContent(UnityWebRequest www)
		{
			return DownloadHandler.GetCheckedDownloader<DownloadHandlerBuffer>(www).text;
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/UnityWebRequest/Public/DownloadHandler/DownloadHandlerScript.h")]
	public class DownloadHandlerScript : DownloadHandler
	{
		internal new static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(DownloadHandlerScript handler)
			{
				return handler.m_Ptr;
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Create([Unmarshalled] DownloadHandlerScript obj);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr CreatePreallocated([Unmarshalled] DownloadHandlerScript obj, [Unmarshalled] byte[] preallocatedBuffer);

		private void InternalCreateScript()
		{
			m_Ptr = Create(this);
		}

		private void InternalCreateScript(byte[] preallocatedBuffer)
		{
			m_Ptr = CreatePreallocated(this, preallocatedBuffer);
		}

		public DownloadHandlerScript()
		{
			InternalCreateScript();
		}

		public DownloadHandlerScript(byte[] preallocatedBuffer)
		{
			if (preallocatedBuffer == null || preallocatedBuffer.Length < 1)
			{
				throw new ArgumentException("Cannot create a preallocated-buffer DownloadHandlerScript backed by a null or zero-length array");
			}
			InternalCreateScript(preallocatedBuffer);
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/UnityWebRequest/Public/DownloadHandler/DownloadHandlerVFS.h")]
	public sealed class DownloadHandlerFile : DownloadHandler
	{
		internal new static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(DownloadHandlerFile handler)
			{
				return handler.m_Ptr;
			}
		}

		public bool removeFileOnAbort
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_removeFileOnAbort_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_removeFileOnAbort_Injected(intPtr, value);
			}
		}

		[NativeThrows]
		private unsafe static IntPtr Create([Unmarshalled] DownloadHandlerFile obj, string path, bool append)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(path, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(path);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return Create_Injected(obj, ref managedSpanWrapper, append);
					}
				}
				return Create_Injected(obj, ref managedSpanWrapper, append);
			}
			finally
			{
			}
		}

		private void InternalCreateVFS(string path, bool append)
		{
			string directoryName = Path.GetDirectoryName(path);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			m_Ptr = Create(this, path, append);
		}

		public DownloadHandlerFile(string path)
		{
			InternalCreateVFS(path, append: false);
		}

		public DownloadHandlerFile(string path, bool append)
		{
			InternalCreateVFS(path, append);
		}

		protected override NativeArray<byte> GetNativeData()
		{
			throw new NotSupportedException("Raw data access is not supported");
		}

		protected override byte[] GetData()
		{
			throw new NotSupportedException("Raw data access is not supported");
		}

		protected override string GetText()
		{
			throw new NotSupportedException("String access is not supported");
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Create_Injected(DownloadHandlerFile obj, ref ManagedSpanWrapper path, bool append);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_removeFileOnAbort_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_removeFileOnAbort_Injected(IntPtr _unity_self, bool value);
	}
	public interface IMultipartFormSection
	{
		string sectionName { get; }

		byte[] sectionData { get; }

		string fileName { get; }

		string contentType { get; }
	}
	public class MultipartFormDataSection : IMultipartFormSection
	{
		private string name;

		private byte[] data;

		private string content;

		public string sectionName => name;

		public byte[] sectionData => data;

		public string fileName => null;

		public string contentType => content;

		public MultipartFormDataSection(string name, byte[] data, string contentType)
		{
			if (data == null || data.Length < 1)
			{
				throw new ArgumentException("Cannot create a multipart form data section without body data");
			}
			this.name = name;
			this.data = data;
			content = contentType;
		}

		public MultipartFormDataSection(string name, byte[] data)
			: this(name, data, null)
		{
		}

		public MultipartFormDataSection(byte[] data)
			: this(null, data)
		{
		}

		public MultipartFormDataSection(string name, string data, Encoding encoding, string contentType)
		{
			if (string.IsNullOrEmpty(data))
			{
				throw new ArgumentException("Cannot create a multipart form data section without body data");
			}
			byte[] bytes = encoding.GetBytes(data);
			this.name = name;
			this.data = bytes;
			if (contentType != null && !contentType.Contains("encoding="))
			{
				contentType = contentType.Trim() + "; encoding=" + encoding.WebName;
			}
			content = contentType;
		}

		public MultipartFormDataSection(string name, string data, string contentType)
			: this(name, data, Encoding.UTF8, contentType)
		{
		}

		public MultipartFormDataSection(string name, string data)
			: this(name, data, "text/plain")
		{
		}

		public MultipartFormDataSection(string data)
			: this(null, data)
		{
		}
	}
	public class MultipartFormFileSection : IMultipartFormSection
	{
		private string name;

		private byte[] data;

		private string file;

		private string content;

		public string sectionName => name;

		public byte[] sectionData => data;

		public string fileName => file;

		public string contentType => content;

		private void Init(string name, byte[] data, string fileName, string contentType)
		{
			this.name = name;
			this.data = data;
			file = fileName;
			content = contentType;
		}

		public MultipartFormFileSection(string name, byte[] data, string fileName, string contentType)
		{
			if (data == null || data.Length < 1)
			{
				throw new ArgumentException("Cannot create a multipart form file section without body data");
			}
			if (string.IsNullOrEmpty(fileName))
			{
				fileName = "file.dat";
			}
			if (string.IsNullOrEmpty(contentType))
			{
				contentType = "application/octet-stream";
			}
			Init(name, data, fileName, contentType);
		}

		public MultipartFormFileSection(byte[] data)
			: this(null, data, null, null)
		{
		}

		public MultipartFormFileSection(string fileName, byte[] data)
			: this(null, data, fileName, null)
		{
		}

		public MultipartFormFileSection(string name, string data, Encoding dataEncoding, string fileName)
		{
			if (string.IsNullOrEmpty(data))
			{
				throw new ArgumentException("Cannot create a multipart form file section without body data");
			}
			if (dataEncoding == null)
			{
				dataEncoding = Encoding.UTF8;
			}
			byte[] bytes = dataEncoding.GetBytes(data);
			if (string.IsNullOrEmpty(fileName))
			{
				fileName = "file.txt";
			}
			if (string.IsNullOrEmpty(content))
			{
				content = "text/plain; charset=" + dataEncoding.WebName;
			}
			Init(name, bytes, fileName, content);
		}

		public MultipartFormFileSection(string data, Encoding dataEncoding, string fileName)
			: this(null, data, dataEncoding, fileName)
		{
		}

		public MultipartFormFileSection(string data, string fileName)
			: this(data, null, fileName)
		{
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	[UsedByNativeCode]
	[NativeHeader("Modules/UnityWebRequest/Public/UnityWebRequestAsyncOperation.h")]
	[NativeHeader("UnityWebRequestScriptingClasses.h")]
	public class UnityWebRequestAsyncOperation : AsyncOperation
	{
		internal new static class BindingsMarshaller
		{
			public static UnityWebRequestAsyncOperation ConvertToManaged(IntPtr ptr)
			{
				return new UnityWebRequestAsyncOperation(ptr);
			}
		}

		public UnityWebRequest webRequest { get; internal set; }

		public UnityWebRequestAsyncOperation()
		{
		}

		private UnityWebRequestAsyncOperation(IntPtr ptr)
			: base(ptr)
		{
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/UnityWebRequest/Public/UnityWebRequest.h")]
	public class UnityWebRequest : IDisposable
	{
		internal enum UnityWebRequestMethod
		{
			Get,
			Post,
			Put,
			Head,
			Custom
		}

		internal enum UnityWebRequestError
		{
			OK,
			OKCached,
			Unknown,
			SDKError,
			UnsupportedProtocol,
			MalformattedUrl,
			CannotResolveProxy,
			CannotResolveHost,
			CannotConnectToHost,
			AccessDenied,
			GenericHttpError,
			WriteError,
			ReadError,
			OutOfMemory,
			Timeout,
			HTTPPostError,
			SSLCannotConnect,
			Aborted,
			TooManyRedirects,
			ReceivedNoData,
			SSLNotSupported,
			FailedToSendData,
			FailedToReceiveData,
			SSLCertificateError,
			SSLCipherNotAvailable,
			SSLCACertError,
			UnrecognizedContentEncoding,
			LoginFailed,
			SSLShutdownFailed,
			RedirectLimitInvalid,
			InvalidRedirect,
			CannotModifyRequest,
			HeaderNameContainsInvalidCharacters,
			HeaderValueContainsInvalidCharacters,
			CannotOverrideSystemHeaders,
			AlreadySent,
			InvalidMethod,
			NotImplemented,
			NoInternetConnection,
			DataProcessingError,
			InsecureConnectionNotAllowed
		}

		public enum Result
		{
			InProgress,
			Success,
			ConnectionError,
			ProtocolError,
			DataProcessingError
		}

		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(UnityWebRequest unityWebRequest)
			{
				return unityWebRequest.m_Ptr;
			}
		}

		[NonSerialized]
		internal IntPtr m_Ptr;

		[NonSerialized]
		internal DownloadHandler m_DownloadHandler;

		[NonSerialized]
		internal UploadHandler m_UploadHandler;

		[NonSerialized]
		internal CertificateHandler m_CertificateHandler;

		[NonSerialized]
		internal Uri m_Uri;

		public const string kHttpVerbGET = "GET";

		public const string kHttpVerbHEAD = "HEAD";

		public const string kHttpVerbPOST = "POST";

		public const string kHttpVerbPUT = "PUT";

		public const string kHttpVerbCREATE = "CREATE";

		public const string kHttpVerbDELETE = "DELETE";

		public bool disposeCertificateHandlerOnDispose { get; set; }

		public bool disposeDownloadHandlerOnDispose { get; set; }

		public bool disposeUploadHandlerOnDispose { get; set; }

		public string method
		{
			get
			{
				return GetMethod() switch
				{
					UnityWebRequestMethod.Get => "GET", 
					UnityWebRequestMethod.Post => "POST", 
					UnityWebRequestMethod.Put => "PUT", 
					UnityWebRequestMethod.Head => "HEAD", 
					_ => GetCustomMethod(), 
				};
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException("Cannot set a UnityWebRequest's method to an empty or null string");
				}
				switch (value.ToUpper())
				{
				case "GET":
					InternalSetMethod(UnityWebRequestMethod.Get);
					break;
				case "POST":
					InternalSetMethod(UnityWebRequestMethod.Post);
					break;
				case "PUT":
					InternalSetMethod(UnityWebRequestMethod.Put);
					break;
				case "HEAD":
					InternalSetMethod(UnityWebRequestMethod.Head);
					break;
				default:
					InternalSetCustomMethod(value.ToUpper());
					break;
				}
			}
		}

		public string error
		{
			get
			{
				switch (result)
				{
				case Result.InProgress:
				case Result.Success:
					return null;
				case Result.ProtocolError:
					return $"HTTP/1.1 {responseCode} {GetHTTPStatusString(responseCode)}";
				default:
					return GetWebErrorString(GetError());
				}
			}
		}

		private bool use100Continue
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_use100Continue_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_use100Continue_Injected(intPtr, value);
			}
		}

		public bool useHttpContinue
		{
			get
			{
				return use100Continue;
			}
			set
			{
				if (!isModifiable)
				{
					throw new InvalidOperationException("UnityWebRequest has already been sent and its 100-Continue setting cannot be altered");
				}
				use100Continue = value;
			}
		}

		public string url
		{
			get
			{
				return GetUrl();
			}
			set
			{
				string localUrl = "https://localhost/";
				InternalSetUrl(WebRequestUtils.MakeInitialUrl(value, localUrl));
			}
		}

		public Uri uri
		{
			get
			{
				return new Uri(GetUrl());
			}
			set
			{
				if (!value.IsAbsoluteUri)
				{
					throw new ArgumentException("URI must be absolute");
				}
				InternalSetUrl(WebRequestUtils.MakeUriString(value, value.OriginalString, prependProtocol: false));
				m_Uri = value;
			}
		}

		public long responseCode
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_responseCode_Injected(intPtr);
			}
		}

		public float uploadProgress
		{
			get
			{
				if (!IsExecuting() && !isDone)
				{
					return -1f;
				}
				return GetUploadProgress();
			}
		}

		public bool isModifiable
		{
			[NativeMethod("IsModifiable")]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isModifiable_Injected(intPtr);
			}
		}

		public bool isDone => result != Result.InProgress;

		[Obsolete("UnityWebRequest.isNetworkError is deprecated. Use (UnityWebRequest.result == UnityWebRequest.Result.ConnectionError) instead.", false)]
		public bool isNetworkError => result == Result.ConnectionError;

		[Obsolete("UnityWebRequest.isHttpError is deprecated. Use (UnityWebRequest.result == UnityWebRequest.Result.ProtocolError) instead.", false)]
		public bool isHttpError => result == Result.ProtocolError;

		public Result result
		{
			[NativeMethod("GetResult")]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_result_Injected(intPtr);
			}
		}

		public float downloadProgress
		{
			get
			{
				if (!IsExecuting() && !isDone)
				{
					return -1f;
				}
				return GetDownloadProgress();
			}
		}

		public ulong uploadedBytes
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_uploadedBytes_Injected(intPtr);
			}
		}

		public ulong downloadedBytes
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_downloadedBytes_Injected(intPtr);
			}
		}

		public int redirectLimit
		{
			get
			{
				return GetRedirectLimit();
			}
			set
			{
				SetRedirectLimitFromScripting(value);
			}
		}

		[Obsolete("HTTP/2 and many HTTP/1.1 servers don't support this; we recommend leaving it set to false (default).", false)]
		public bool chunkedTransfer
		{
			get
			{
				return GetChunked();
			}
			set
			{
				if (!isModifiable)
				{
					throw new InvalidOperationException("UnityWebRequest has already been sent and its chunked transfer encoding setting cannot be altered");
				}
				UnityWebRequestError unityWebRequestError = SetChunked(value);
				if (unityWebRequestError != UnityWebRequestError.OK)
				{
					throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
				}
			}
		}

		public UploadHandler uploadHandler
		{
			get
			{
				return m_UploadHandler;
			}
			set
			{
				if (!isModifiable)
				{
					throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the upload handler");
				}
				UnityWebRequestError unityWebRequestError = SetUploadHandler(value);
				if (unityWebRequestError != UnityWebRequestError.OK)
				{
					throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
				}
				m_UploadHandler = value;
			}
		}

		public DownloadHandler downloadHandler
		{
			get
			{
				return m_DownloadHandler;
			}
			set
			{
				if (!isModifiable)
				{
					throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the download handler");
				}
				UnityWebRequestError unityWebRequestError = SetDownloadHandler(value);
				if (unityWebRequestError != UnityWebRequestError.OK)
				{
					throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
				}
				m_DownloadHandler = value;
			}
		}

		public CertificateHandler certificateHandler
		{
			get
			{
				return m_CertificateHandler;
			}
			set
			{
				if (!isModifiable)
				{
					throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the certificate handler");
				}
				UnityWebRequestError unityWebRequestError = SetCertificateHandler(value);
				if (unityWebRequestError != UnityWebRequestError.OK)
				{
					throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
				}
				m_CertificateHandler = value;
			}
		}

		public int timeout
		{
			get
			{
				return GetTimeoutMsec() / 1000;
			}
			set
			{
				if (!isModifiable)
				{
					throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the timeout");
				}
				value = Math.Max(value, 0);
				UnityWebRequestError unityWebRequestError = SetTimeoutMsec(value * 1000);
				if (unityWebRequestError != UnityWebRequestError.OK)
				{
					throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
				}
			}
		}

		internal bool suppressErrorsToConsole
		{
			get
			{
				return GetSuppressErrorsToConsole();
			}
			set
			{
				if (!isModifiable)
				{
					throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the timeout");
				}
				UnityWebRequestError unityWebRequestError = SetSuppressErrorsToConsole(value);
				if (unityWebRequestError != UnityWebRequestError.OK)
				{
					throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
				}
			}
		}

		[NativeMethod(IsThreadSafe = true)]
		[NativeConditional("ENABLE_UNITYWEBREQUEST")]
		private static string GetWebErrorString(UnityWebRequestError err)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				GetWebErrorString_Injected(err, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[VisibleToOtherModules]
		internal static string GetHTTPStatusString(long responseCode)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				GetHTTPStatusString_Injected(responseCode, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		public static void ClearCookieCache()
		{
			ClearCookieCache(null, null);
		}

		public static void ClearCookieCache(Uri uri)
		{
			if (uri == null)
			{
				ClearCookieCache(null, null);
				return;
			}
			string host = uri.Host;
			string text = uri.AbsolutePath;
			if (text == "/")
			{
				text = null;
			}
			ClearCookieCache(host, text);
		}

		private unsafe static void ClearCookieCache(string domain, string path)
		{
			//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper domain2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(domain, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(domain);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						domain2 = ref managedSpanWrapper;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(path, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(path);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								ClearCookieCache_Injected(ref domain2, ref managedSpanWrapper2);
								return;
							}
						}
						ClearCookieCache_Injected(ref domain2, ref managedSpanWrapper2);
						return;
					}
				}
				domain2 = ref managedSpanWrapper;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(path, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(path);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						ClearCookieCache_Injected(ref domain2, ref managedSpanWrapper2);
						return;
					}
				}
				ClearCookieCache_Injected(ref domain2, ref managedSpanWrapper2);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		internal static extern IntPtr Create();

		[NativeMethod(IsThreadSafe = true)]
		private void Release()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Release_Injected(intPtr);
		}

		internal void InternalDestroy()
		{
			if (m_Ptr != IntPtr.Zero)
			{
				Abort();
				Release();
				m_Ptr = IntPtr.Zero;
			}
		}

		private void InternalSetDefaults()
		{
			disposeDownloadHandlerOnDispose = true;
			disposeUploadHandlerOnDispose = true;
			disposeCertificateHandlerOnDispose = true;
		}

		public UnityWebRequest()
		{
			m_Ptr = Create();
			InternalSetDefaults();
		}

		public UnityWebRequest(string url)
		{
			m_Ptr = Create();
			InternalSetDefaults();
			this.url = url;
		}

		public UnityWebRequest(Uri uri)
		{
			m_Ptr = Create();
			InternalSetDefaults();
			this.uri = uri;
		}

		public UnityWebRequest(string url, string method)
		{
			m_Ptr = Create();
			InternalSetDefaults();
			this.url = url;
			this.method = method;
		}

		public UnityWebRequest(Uri uri, string method)
		{
			m_Ptr = Create();
			InternalSetDefaults();
			this.uri = uri;
			this.method = method;
		}

		public UnityWebRequest(string url, string method, DownloadHandler downloadHandler, UploadHandler uploadHandler)
		{
			m_Ptr = Create();
			InternalSetDefaults();
			this.url = url;
			this.method = method;
			this.downloadHandler = downloadHandler;
			this.uploadHandler = uploadHandler;
		}

		public UnityWebRequest(Uri uri, string method, DownloadHandler downloadHandler, UploadHandler uploadHandler)
		{
			m_Ptr = Create();
			InternalSetDefaults();
			this.uri = uri;
			this.method = method;
			this.downloadHandler = downloadHandler;
			this.uploadHandler = uploadHandler;
		}

		~UnityWebRequest()
		{
			DisposeHandlers();
			InternalDestroy();
		}

		public void Dispose()
		{
			DisposeHandlers();
			InternalDestroy();
			GC.SuppressFinalize(this);
		}

		private void DisposeHandlers()
		{
			if (disposeDownloadHandlerOnDispose)
			{
				downloadHandler?.Dispose();
			}
			if (disposeUploadHandlerOnDispose)
			{
				uploadHandler?.Dispose();
			}
			if (disposeCertificateHandlerOnDispose)
			{
				certificateHandler?.Dispose();
			}
		}

		[NativeThrows]
		internal UnityWebRequestAsyncOperation BeginWebRequest()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = BeginWebRequest_Injected(intPtr);
			return (intPtr2 == (IntPtr)0) ? null : UnityWebRequestAsyncOperation.BindingsMarshaller.ConvertToManaged(intPtr2);
		}

		[Obsolete("Use SendWebRequest.  It returns a UnityWebRequestAsyncOperation which contains a reference to the WebRequest object.", false)]
		public AsyncOperation Send()
		{
			return SendWebRequest();
		}

		public UnityWebRequestAsyncOperation SendWebRequest()
		{
			UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = BeginWebRequest();
			if (unityWebRequestAsyncOperation != null)
			{
				unityWebRequestAsyncOperation.webRequest = this;
			}
			return unityWebRequestAsyncOperation;
		}

		[NativeMethod(IsThreadSafe = true)]
		public void Abort()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Abort_Injected(intPtr);
		}

		private UnityWebRequestError SetMethod(UnityWebRequestMethod methodType)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetMethod_Injected(intPtr, methodType);
		}

		internal void InternalSetMethod(UnityWebRequestMethod methodType)
		{
			if (!isModifiable)
			{
				throw new InvalidOperationException("UnityWebRequest has already been sent and its request method can no longer be altered");
			}
			UnityWebRequestError unityWebRequestError = SetMethod(methodType);
			if (unityWebRequestError != UnityWebRequestError.OK)
			{
				throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
			}
		}

		private unsafe UnityWebRequestError SetCustomMethod(string customMethodName)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(customMethodName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(customMethodName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return SetCustomMethod_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return SetCustomMethod_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		internal void InternalSetCustomMethod(string customMethodName)
		{
			if (!isModifiable)
			{
				throw new InvalidOperationException("UnityWebRequest has already been sent and its request method can no longer be altered");
			}
			UnityWebRequestError unityWebRequestError = SetCustomMethod(customMethodName);
			if (unityWebRequestError != UnityWebRequestError.OK)
			{
				throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
			}
		}

		internal UnityWebRequestMethod GetMethod()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetMethod_Injected(intPtr);
		}

		internal string GetCustomMethod()
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetCustomMethod_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		private UnityWebRequestError GetError()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetError_Injected(intPtr);
		}

		private string GetUrl()
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetUrl_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		private unsafe UnityWebRequestError SetUrl(string url)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(url, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(url);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return SetUrl_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return SetUrl_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		private void InternalSetUrl(string url)
		{
			if (!isModifiable)
			{
				throw new InvalidOperationException("UnityWebRequest has already been sent and its URL cannot be altered");
			}
			UnityWebRequestError unityWebRequestError = SetUrl(url);
			if (unityWebRequestError != UnityWebRequestError.OK)
			{
				throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
			}
		}

		private float GetUploadProgress()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetUploadProgress_Injected(intPtr);
		}

		private bool IsExecuting()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IsExecuting_Injected(intPtr);
		}

		private float GetDownloadProgress()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetDownloadProgress_Injected(intPtr);
		}

		private int GetRedirectLimit()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetRedirectLimit_Injected(intPtr);
		}

		[NativeThrows]
		private void SetRedirectLimitFromScripting(int limit)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetRedirectLimitFromScripting_Injected(intPtr, limit);
		}

		private bool GetChunked()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetChunked_Injected(intPtr);
		}

		private UnityWebRequestError SetChunked(bool chunked)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetChunked_Injected(intPtr, chunked);
		}

		public unsafe string GetRequestHeader(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						GetRequestHeader_Injected(intPtr, ref managedSpanWrapper, out ret);
					}
				}
				else
				{
					GetRequestHeader_Injected(intPtr, ref managedSpanWrapper, out ret);
				}
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[NativeMethod("SetRequestHeader")]
		internal unsafe UnityWebRequestError InternalSetRequestHeader(string name, string value)
		{
			//The blocks IL_0039, IL_0046, IL_0054, IL_0062, IL_0067 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0067 are reachable both inside and outside the pinned region starting at IL_0054. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0067 are reachable both inside and outside the pinned region starting at IL_0054. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper name2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						name2 = ref managedSpanWrapper;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(value);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								return InternalSetRequestHeader_Injected(intPtr, ref name2, ref managedSpanWrapper2);
							}
						}
						return InternalSetRequestHeader_Injected(intPtr, ref name2, ref managedSpanWrapper2);
					}
				}
				name2 = ref managedSpanWrapper;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(value);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						return InternalSetRequestHeader_Injected(intPtr, ref name2, ref managedSpanWrapper2);
					}
				}
				return InternalSetRequestHeader_Injected(intPtr, ref name2, ref managedSpanWrapper2);
			}
			finally
			{
			}
		}

		public void SetRequestHeader(string name, string value)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Cannot set a Request Header with a null or empty name");
			}
			if (value == null)
			{
				throw new ArgumentException("Cannot set a Request header with a null");
			}
			if (!isModifiable)
			{
				throw new InvalidOperationException("UnityWebRequest has already been sent and its request headers cannot be altered");
			}
			UnityWebRequestError unityWebRequestError = InternalSetRequestHeader(name, value);
			if (unityWebRequestError != UnityWebRequestError.OK)
			{
				throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
			}
		}

		public unsafe string GetResponseHeader(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						GetResponseHeader_Injected(intPtr, ref managedSpanWrapper, out ret);
					}
				}
				else
				{
					GetResponseHeader_Injected(intPtr, ref managedSpanWrapper, out ret);
				}
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		internal string[] GetResponseHeaderKeys()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetResponseHeaderKeys_Injected(intPtr);
		}

		public Dictionary<string, string> GetResponseHeaders()
		{
			string[] responseHeaderKeys = GetResponseHeaderKeys();
			if (responseHeaderKeys == null || responseHeaderKeys.Length == 0)
			{
				return null;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>(responseHeaderKeys.Length, StringComparer.OrdinalIgnoreCase);
			for (int i = 0; i < responseHeaderKeys.Length; i++)
			{
				string responseHeader = GetResponseHeader(responseHeaderKeys[i]);
				dictionary.Add(responseHeaderKeys[i], responseHeader);
			}
			return dictionary;
		}

		private UnityWebRequestError SetUploadHandler(UploadHandler uh)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetUploadHandler_Injected(intPtr, (uh == null) ? ((IntPtr)0) : UploadHandler.BindingsMarshaller.ConvertToNative(uh));
		}

		private UnityWebRequestError SetDownloadHandler(DownloadHandler dh)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetDownloadHandler_Injected(intPtr, (dh == null) ? ((IntPtr)0) : DownloadHandler.BindingsMarshaller.ConvertToNative(dh));
		}

		private UnityWebRequestError SetCertificateHandler(CertificateHandler ch)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetCertificateHandler_Injected(intPtr, (ch == null) ? ((IntPtr)0) : CertificateHandler.BindingsMarshaller.ConvertToNative(ch));
		}

		private int GetTimeoutMsec()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetTimeoutMsec_Injected(intPtr);
		}

		private UnityWebRequestError SetTimeoutMsec(int timeout)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetTimeoutMsec_Injected(intPtr, timeout);
		}

		private bool GetSuppressErrorsToConsole()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetSuppressErrorsToConsole_Injected(intPtr);
		}

		private UnityWebRequestError SetSuppressErrorsToConsole(bool suppress)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetSuppressErrorsToConsole_Injected(intPtr, suppress);
		}

		public static UnityWebRequest Get(string uri)
		{
			return new UnityWebRequest(uri, "GET", new DownloadHandlerBuffer(), null);
		}

		public static UnityWebRequest Get(Uri uri)
		{
			return new UnityWebRequest(uri, "GET", new DownloadHandlerBuffer(), null);
		}

		public static UnityWebRequest Delete(string uri)
		{
			return new UnityWebRequest(uri, "DELETE");
		}

		public static UnityWebRequest Delete(Uri uri)
		{
			return new UnityWebRequest(uri, "DELETE");
		}

		public static UnityWebRequest Head(string uri)
		{
			return new UnityWebRequest(uri, "HEAD");
		}

		public static UnityWebRequest Head(Uri uri)
		{
			return new UnityWebRequest(uri, "HEAD");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("UnityWebRequest.GetTexture is obsolete. Use UnityWebRequestTexture.GetTexture instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestTexture.GetTexture(*)", true)]
		public static UnityWebRequest GetTexture(string uri)
		{
			throw new NotSupportedException("UnityWebRequest.GetTexture is obsolete. Use UnityWebRequestTexture.GetTexture instead.");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("UnityWebRequest.GetTexture is obsolete. Use UnityWebRequestTexture.GetTexture instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestTexture.GetTexture(*)", true)]
		public static UnityWebRequest GetTexture(string uri, bool nonReadable)
		{
			throw new NotSupportedException("UnityWebRequest.GetTexture is obsolete. Use UnityWebRequestTexture.GetTexture instead.");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("UnityWebRequest.GetAudioClip is obsolete. Use UnityWebRequestMultimedia.GetAudioClip instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestMultimedia.GetAudioClip(*)", true)]
		public static UnityWebRequest GetAudioClip(string uri, AudioType audioType)
		{
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
		public static UnityWebRequest GetAssetBundle(string uri)
		{
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
		public static UnityWebRequest GetAssetBundle(string uri, uint crc)
		{
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
		public static UnityWebRequest GetAssetBundle(string uri, uint version, uint crc)
		{
			return null;
		}

		[Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static UnityWebRequest GetAssetBundle(string uri, Hash128 hash, uint crc)
		{
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
		public static UnityWebRequest GetAssetBundle(string uri, CachedAssetBundle cachedAssetBundle, uint crc)
		{
			return null;
		}

		public static UnityWebRequest Put(string uri, byte[] bodyData)
		{
			return new UnityWebRequest(uri, "PUT", new DownloadHandlerBuffer(), new UploadHandlerRaw(bodyData));
		}

		public static UnityWebRequest Put(Uri uri, byte[] bodyData)
		{
			return new UnityWebRequest(uri, "PUT", new DownloadHandlerBuffer(), new UploadHandlerRaw(bodyData));
		}

		public static UnityWebRequest Put(string uri, string bodyData)
		{
			return new UnityWebRequest(uri, "PUT", new DownloadHandlerBuffer(), new UploadHandlerRaw(Encoding.UTF8.GetBytes(bodyData)));
		}

		public static UnityWebRequest Put(Uri uri, string bodyData)
		{
			return new UnityWebRequest(uri, "PUT", new DownloadHandlerBuffer(), new UploadHandlerRaw(Encoding.UTF8.GetBytes(bodyData)));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("UnityWebRequest.Post with only a string data is obsolete. Use UnityWebRequest.Post with content type argument or UnityWebRequest.PostWwwForm instead (UnityUpgradable) -> [UnityEngine] UnityWebRequest.PostWwwForm(*)", false)]
		public static UnityWebRequest Post(string uri, string postData)
		{
			return PostWwwForm(uri, postData);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("UnityWebRequest.Post with only a string data is obsolete. Use UnityWebRequest.Post with content type argument or UnityWebRequest.PostWwwForm instead (UnityUpgradable) -> [UnityEngine] UnityWebRequest.PostWwwForm(*)", false)]
		public static UnityWebRequest Post(Uri uri, string postData)
		{
			return PostWwwForm(uri, postData);
		}

		public static UnityWebRequest PostWwwForm(string uri, string form)
		{
			UnityWebRequest request = new UnityWebRequest(uri, "POST");
			SetupPostWwwForm(request, form);
			return request;
		}

		public static UnityWebRequest PostWwwForm(Uri uri, string form)
		{
			UnityWebRequest request = new UnityWebRequest(uri, "POST");
			SetupPostWwwForm(request, form);
			return request;
		}

		private static void SetupPostWwwForm(UnityWebRequest request, string postData)
		{
			request.downloadHandler = new DownloadHandlerBuffer();
			if (!string.IsNullOrEmpty(postData))
			{
				byte[] array = null;
				string s = WWWTranscoder.DataEncode(postData, Encoding.UTF8);
				array = Encoding.UTF8.GetBytes(s);
				request.uploadHandler = new UploadHandlerRaw(array);
				request.uploadHandler.contentType = "application/x-www-form-urlencoded";
			}
		}

		public static UnityWebRequest Post(string uri, string postData, string contentType)
		{
			UnityWebRequest request = new UnityWebRequest(uri, "POST");
			SetupPost(request, postData, contentType);
			return request;
		}

		public static UnityWebRequest Post(Uri uri, string postData, string contentType)
		{
			UnityWebRequest request = new UnityWebRequest(uri, "POST");
			SetupPost(request, postData, contentType);
			return request;
		}

		private static void SetupPost(UnityWebRequest request, string postData, string contentType)
		{
			request.downloadHandler = new DownloadHandlerBuffer();
			if (string.IsNullOrEmpty(postData))
			{
				request.SetRequestHeader("Content-Type", contentType);
				return;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(postData);
			request.uploadHandler = new UploadHandlerRaw(bytes);
			request.uploadHandler.contentType = contentType;
		}

		public static UnityWebRequest Post(string uri, WWWForm formData)
		{
			UnityWebRequest request = new UnityWebRequest(uri, "POST");
			SetupPost(request, formData);
			return request;
		}

		public static UnityWebRequest Post(Uri uri, WWWForm formData)
		{
			UnityWebRequest request = new UnityWebRequest(uri, "POST");
			SetupPost(request, formData);
			return request;
		}

		private static void SetupPost(UnityWebRequest request, WWWForm formData)
		{
			request.downloadHandler = new DownloadHandlerBuffer();
			if (formData == null)
			{
				return;
			}
			byte[] array = null;
			array = formData.data;
			if (array.Length == 0)
			{
				array = null;
			}
			if (array != null)
			{
				request.uploadHandler = new UploadHandlerRaw(array);
			}
			Dictionary<string, string> headers = formData.headers;
			foreach (KeyValuePair<string, string> item in headers)
			{
				request.SetRequestHeader(item.Key, item.Value);
			}
		}

		public static UnityWebRequest Post(string uri, List<IMultipartFormSection> multipartFormSections)
		{
			byte[] boundary = GenerateBoundary();
			return Post(uri, multipartFormSections, boundary);
		}

		public static UnityWebRequest Post(Uri uri, List<IMultipartFormSection> multipartFormSections)
		{
			byte[] boundary = GenerateBoundary();
			return Post(uri, multipartFormSections, boundary);
		}

		public static UnityWebRequest Post(string uri, List<IMultipartFormSection> multipartFormSections, byte[] boundary)
		{
			UnityWebRequest request = new UnityWebRequest(uri, "POST");
			SetupPost(request, multipartFormSections, boundary);
			return request;
		}

		public static UnityWebRequest Post(Uri uri, List<IMultipartFormSection> multipartFormSections, byte[] boundary)
		{
			UnityWebRequest request = new UnityWebRequest(uri, "POST");
			SetupPost(request, multipartFormSections, boundary);
			return request;
		}

		private static void SetupPost(UnityWebRequest request, List<IMultipartFormSection> multipartFormSections, byte[] boundary)
		{
			request.downloadHandler = new DownloadHandlerBuffer();
			byte[] array = null;
			if (multipartFormSections != null && multipartFormSections.Count != 0)
			{
				array = SerializeFormSections(multipartFormSections, boundary);
			}
			if (array != null)
			{
				UploadHandler uploadHandler = new UploadHandlerRaw(array);
				uploadHandler.contentType = "multipart/form-data; boundary=" + Encoding.UTF8.GetString(boundary, 0, boundary.Length);
				request.uploadHandler = uploadHandler;
			}
		}

		public static UnityWebRequest Post(string uri, Dictionary<string, string> formFields)
		{
			UnityWebRequest request = new UnityWebRequest(uri, "POST");
			SetupPost(request, formFields);
			return request;
		}

		public static UnityWebRequest Post(Uri uri, Dictionary<string, string> formFields)
		{
			UnityWebRequest request = new UnityWebRequest(uri, "POST");
			SetupPost(request, formFields);
			return request;
		}

		private static void SetupPost(UnityWebRequest request, Dictionary<string, string> formFields)
		{
			request.downloadHandler = new DownloadHandlerBuffer();
			byte[] array = null;
			if (formFields != null && formFields.Count != 0)
			{
				array = SerializeSimpleForm(formFields);
			}
			if (array != null)
			{
				UploadHandler uploadHandler = new UploadHandlerRaw(array);
				uploadHandler.contentType = "application/x-www-form-urlencoded";
				request.uploadHandler = uploadHandler;
			}
		}

		public static string EscapeURL(string s)
		{
			return EscapeURL(s, Encoding.UTF8);
		}

		public static string EscapeURL(string s, Encoding e)
		{
			if (s == null)
			{
				return null;
			}
			if (s == "")
			{
				return "";
			}
			if (e == null)
			{
				return null;
			}
			byte[] bytes = e.GetBytes(s);
			byte[] bytes2 = WWWTranscoder.URLEncode(bytes);
			return e.GetString(bytes2);
		}

		public static string UnEscapeURL(string s)
		{
			return UnEscapeURL(s, Encoding.UTF8);
		}

		public static string UnEscapeURL(string s, Encoding e)
		{
			if (s == null)
			{
				return null;
			}
			if (s.IndexOf('%') == -1 && s.IndexOf('+') == -1)
			{
				return s;
			}
			byte[] bytes = e.GetBytes(s);
			byte[] bytes2 = WWWTranscoder.URLDecode(bytes);
			return e.GetString(bytes2);
		}

		public static byte[] SerializeFormSections(List<IMultipartFormSection> multipartFormSections, byte[] boundary)
		{
			if (multipartFormSections == null || multipartFormSections.Count == 0)
			{
				return null;
			}
			byte[] bytes = Encoding.UTF8.GetBytes("\r\n");
			byte[] bytes2 = WWWForm.DefaultEncoding.GetBytes("--");
			int num = 0;
			foreach (IMultipartFormSection multipartFormSection in multipartFormSections)
			{
				num += 64 + multipartFormSection.sectionData.Length;
			}
			List<byte> list = new List<byte>(num);
			foreach (IMultipartFormSection multipartFormSection2 in multipartFormSections)
			{
				string text = "form-data";
				string sectionName = multipartFormSection2.sectionName;
				string fileName = multipartFormSection2.fileName;
				string text2 = "Content-Disposition: " + text;
				if (!string.IsNullOrEmpty(sectionName))
				{
					text2 = text2 + "; name=\"" + sectionName + "\"";
				}
				if (!string.IsNullOrEmpty(fileName))
				{
					text2 = text2 + "; filename=\"" + fileName + "\"";
				}
				text2 += "\r\n";
				string contentType = multipartFormSection2.contentType;
				if (!string.IsNullOrEmpty(contentType))
				{
					text2 = text2 + "Content-Type: " + contentType + "\r\n";
				}
				list.AddRange(bytes);
				list.AddRange(bytes2);
				list.AddRange(boundary);
				list.AddRange(bytes);
				list.AddRange(Encoding.UTF8.GetBytes(text2));
				list.AddRange(bytes);
				list.AddRange(multipartFormSection2.sectionData);
			}
			list.AddRange(bytes);
			list.AddRange(bytes2);
			list.AddRange(boundary);
			list.AddRange(bytes2);
			list.AddRange(bytes);
			return list.ToArray();
		}

		public static byte[] GenerateBoundary()
		{
			byte[] array = new byte[40];
			for (int i = 0; i < 40; i++)
			{
				int num = Random.Range(48, 110);
				if (num > 57)
				{
					num += 7;
				}
				if (num > 90)
				{
					num += 6;
				}
				array[i] = (byte)num;
			}
			return array;
		}

		public static byte[] SerializeSimpleForm(Dictionary<string, string> formFields)
		{
			string text = "";
			foreach (KeyValuePair<string, string> formField in formFields)
			{
				if (text.Length > 0)
				{
					text += "&";
				}
				text = text + WWWTranscoder.DataEncode(formField.Key) + "=" + WWWTranscoder.DataEncode(formField.Value);
			}
			return Encoding.UTF8.GetBytes(text);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetWebErrorString_Injected(UnityWebRequestError err, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetHTTPStatusString_Injected(long responseCode, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ClearCookieCache_Injected(ref ManagedSpanWrapper domain, ref ManagedSpanWrapper path);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Release_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr BeginWebRequest_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Abort_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern UnityWebRequestError SetMethod_Injected(IntPtr _unity_self, UnityWebRequestMethod methodType);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern UnityWebRequestError SetCustomMethod_Injected(IntPtr _unity_self, ref ManagedSpanWrapper customMethodName);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern UnityWebRequestMethod GetMethod_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetCustomMethod_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern UnityWebRequestError GetError_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_use100Continue_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_use100Continue_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetUrl_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern UnityWebRequestError SetUrl_Injected(IntPtr _unity_self, ref ManagedSpanWrapper url);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern long get_responseCode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetUploadProgress_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsExecuting_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isModifiable_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Result get_result_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetDownloadProgress_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ulong get_uploadedBytes_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ulong get_downloadedBytes_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetRedirectLimit_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetRedirectLimitFromScripting_Injected(IntPtr _unity_self, int limit);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetChunked_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern UnityWebRequestError SetChunked_Injected(IntPtr _unity_self, bool chunked);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRequestHeader_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern UnityWebRequestError InternalSetRequestHeader_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, ref ManagedSpanWrapper value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetResponseHeader_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string[] GetResponseHeaderKeys_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern UnityWebRequestError SetUploadHandler_Injected(IntPtr _unity_self, IntPtr uh);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern UnityWebRequestError SetDownloadHandler_Injected(IntPtr _unity_self, IntPtr dh);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern UnityWebRequestError SetCertificateHandler_Injected(IntPtr _unity_self, IntPtr ch);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetTimeoutMsec_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern UnityWebRequestError SetTimeoutMsec_Injected(IntPtr _unity_self, int timeout);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetSuppressErrorsToConsole_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern UnityWebRequestError SetSuppressErrorsToConsole_Injected(IntPtr _unity_self, bool suppress);
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/UnityWebRequest/Public/UploadHandler/UploadHandler.h")]
	public class UploadHandler : IDisposable
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(UploadHandler uploadHandler)
			{
				return uploadHandler.m_Ptr;
			}
		}

		[NonSerialized]
		internal IntPtr m_Ptr;

		public byte[] data => GetData();

		public string contentType
		{
			get
			{
				return GetContentType();
			}
			set
			{
				SetContentType(value);
			}
		}

		public float progress => GetProgress();

		[NativeMethod(IsThreadSafe = true)]
		private void ReleaseFromScripting()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ReleaseFromScripting_Injected(intPtr);
		}

		internal UploadHandler()
		{
		}

		~UploadHandler()
		{
			Dispose();
		}

		public virtual void Dispose()
		{
			if (m_Ptr != IntPtr.Zero)
			{
				ReleaseFromScripting();
				m_Ptr = IntPtr.Zero;
			}
		}

		internal virtual byte[] GetData()
		{
			return null;
		}

		internal virtual string GetContentType()
		{
			return InternalGetContentType();
		}

		internal virtual void SetContentType(string newContentType)
		{
			InternalSetContentType(newContentType);
		}

		internal virtual float GetProgress()
		{
			return InternalGetProgress();
		}

		[NativeMethod("GetContentType")]
		private string InternalGetContentType()
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				InternalGetContentType_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[NativeMethod("SetContentType")]
		private unsafe void InternalSetContentType(string newContentType)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(newContentType, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(newContentType);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						InternalSetContentType_Injected(intPtr, ref managedSpanWrapper);
						return;
					}
				}
				InternalSetContentType_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[NativeMethod("GetProgress")]
		private float InternalGetProgress()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return InternalGetProgress_Injected(intPtr);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ReleaseFromScripting_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalGetContentType_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetContentType_Injected(IntPtr _unity_self, ref ManagedSpanWrapper newContentType);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float InternalGetProgress_Injected(IntPtr _unity_self);
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/UnityWebRequest/Public/UploadHandler/UploadHandlerRaw.h")]
	public sealed class UploadHandlerRaw : UploadHandler
	{
		internal new static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(UploadHandlerRaw uploadHandler)
			{
				return uploadHandler.m_Ptr;
			}
		}

		private NativeArray<byte> m_Payload;

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern IntPtr Create([Unmarshalled] UploadHandlerRaw self, byte* data, int dataLength);

		public UploadHandlerRaw(byte[] data)
			: this((data == null || data.Length == 0) ? default(NativeArray<byte>) : new NativeArray<byte>(data, Allocator.Persistent), transferOwnership: true)
		{
		}

		public unsafe UploadHandlerRaw(NativeArray<byte> data, bool transferOwnership)
		{
			if (!data.IsCreated || data.Length == 0)
			{
				m_Ptr = Create(this, null, 0);
				return;
			}
			if (transferOwnership)
			{
				m_Payload = data;
			}
			m_Ptr = Create(this, (byte*)data.GetUnsafeReadOnlyPtr(), data.Length);
		}

		public unsafe UploadHandlerRaw(NativeArray<byte>.ReadOnly data)
		{
			if (!data.IsCreated || data.Length == 0)
			{
				m_Ptr = Create(this, null, 0);
			}
			else if (data.Length == 0)
			{
				m_Ptr = Create(this, null, 0);
			}
			else
			{
				m_Ptr = Create(this, (byte*)data.GetUnsafeReadOnlyPtr(), data.Length);
			}
		}

		internal override byte[] GetData()
		{
			if (m_Payload.IsCreated)
			{
				return m_Payload.ToArray();
			}
			return null;
		}

		public override void Dispose()
		{
			if (m_Payload.IsCreated)
			{
				m_Payload.Dispose();
			}
			base.Dispose();
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/UnityWebRequest/Public/UploadHandler/UploadHandlerFile.h")]
	public sealed class UploadHandlerFile : UploadHandler
	{
		internal new static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(UploadHandlerFile uploadHandler)
			{
				return uploadHandler.m_Ptr;
			}
		}

		[NativeThrows]
		private unsafe static IntPtr Create([Unmarshalled] UploadHandlerFile self, string filePath)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(filePath, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(filePath);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return Create_Injected(self, ref managedSpanWrapper);
					}
				}
				return Create_Injected(self, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		public UploadHandlerFile(string filePath)
		{
			m_Ptr = Create(this, filePath);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Create_Injected(UploadHandlerFile self, ref ManagedSpanWrapper filePath);
	}
}
