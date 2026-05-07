using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

[assembly: InternalsVisibleTo("UnityEngine.UnityConnectModule")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS4VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4Module")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.SwitchModule")]
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.XRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VFXModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestWWWModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestTextureModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
[assembly: InternalsVisibleTo("UnityEngine.Advertisements")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Application")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.CommonUtils")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Tooling")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Deployment")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.2D")]
[assembly: InternalsVisibleTo("Unity.DeploymentTests.Services")]
[assembly: InternalsVisibleTo("Unity.Burst.Editor")]
[assembly: InternalsVisibleTo("Unity.Burst")]
[assembly: InternalsVisibleTo("Unity.Automation")]
[assembly: InternalsVisibleTo("UnityEngine.TestRunner")]
[assembly: InternalsVisibleTo("UnityEngine.Purchasing")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityTestProtocolModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityCurlModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConsentModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputForUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.IMGUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreTextEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreFontEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputLegacyModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextRenderingModule")]
[assembly: InternalsVisibleTo("UnityEngine.HierarchyCoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.GridModule")]
[assembly: InternalsVisibleTo("UnityEngine.GraphicsStateCollectionSerializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.GameCenterModule")]
[assembly: InternalsVisibleTo("UnityEngine.ImageConversionModule")]
[assembly: InternalsVisibleTo("UnityEngine.GIModule")]
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.InsightsModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("UnityEngine.LocalizationModule")]
[assembly: InternalsVisibleTo("UnityEngine.MultiplayerModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.SpriteShapeModule")]
[assembly: InternalsVisibleTo("UnityEngine.ShaderVariantAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.ScreenCaptureModule")]
[assembly: InternalsVisibleTo("UnityEngine.RuntimeInitializeOnLoadManagerInitializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.PropertiesModule")]
[assembly: InternalsVisibleTo("UnityEngine.Physics2DModule")]
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.ParticleSystemModule")]
[assembly: InternalsVisibleTo("UnityEngine.NVIDIAModule")]
[assembly: InternalsVisibleTo("UnityEngine.MarshallingModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.007")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.006")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.001")]
[assembly: InternalsVisibleTo("UnityEngine.Core.Runtime.Tests")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.008")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.009")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
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
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.015")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.014")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.013")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.012")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
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
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterRendererModule")]
[assembly: InternalsVisibleTo("UnityEngine.ContentLoadModule")]
[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: InternalsVisibleTo("UnityEngine.SharedInternalsModule")]
[assembly: InternalsVisibleTo("UnityEngine.CoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.AIModule")]
[assembly: InternalsVisibleTo("UnityEngine.PhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.JSONSerializeModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputModule")]
[assembly: InternalsVisibleTo("UnityEngine.AMDModule")]
[assembly: InternalsVisibleTo("UnityEngine.AccessibilityModule")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.ARModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClothModule")]
[assembly: InternalsVisibleTo("UnityEngine.AudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterInputModule")]
[assembly: InternalsVisibleTo("UnityEngine.HotReloadModule")]
[assembly: InternalsVisibleTo("UnityEngine.AnimationModule")]
[assembly: InternalsVisibleTo("UnityEngine.AndroidJNIModule")]
[assembly: InternalsVisibleTo("UnityEngine.AssetBundleModule")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine
{
	[NativeHeader("UnityAnalyticsScriptingClasses.h")]
	[NativeHeader("Modules/UnityAnalytics/RemoteSettings/RemoteSettings.h")]
	public static class RemoteSettings
	{
		public delegate void UpdatedEventHandler();

		public static event UpdatedEventHandler Updated;

		public static event Action BeforeFetchFromServer;

		public static event Action<bool, bool, int> Completed;

		[Preserve]
		[RequiredByNativeCode]
		internal static void RemoteSettingsUpdated(bool wasLastUpdatedFromServer)
		{
			RemoteSettings.Updated?.Invoke();
		}

		[Preserve]
		[RequiredByNativeCode]
		internal static void RemoteSettingsBeforeFetchFromServer()
		{
			RemoteSettings.BeforeFetchFromServer?.Invoke();
		}

		[Preserve]
		[RequiredByNativeCode]
		internal static void RemoteSettingsUpdateCompleted(bool wasLastUpdatedFromServer, bool settingsChanged, int response)
		{
			RemoteSettings.Completed?.Invoke(wasLastUpdatedFromServer, settingsChanged, response);
		}

		[Obsolete("Calling CallOnUpdate() is not necessary any more and should be removed. Use RemoteSettingsUpdated instead", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void CallOnUpdate()
		{
			throw new NotSupportedException("Calling CallOnUpdate() is not necessary any more and should be removed.");
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ForceUpdate();

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool WasLastUpdatedFromServer();

		[ExcludeFromDocs]
		public static int GetInt(string key)
		{
			return GetInt(key, 0);
		}

		public unsafe static int GetInt(string key, [UnityEngine.Internal.DefaultValue("0")] int defaultValue)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetInt_Injected(ref managedSpanWrapper, defaultValue);
					}
				}
				return GetInt_Injected(ref managedSpanWrapper, defaultValue);
			}
			finally
			{
			}
		}

		[ExcludeFromDocs]
		public static long GetLong(string key)
		{
			return GetLong(key, 0L);
		}

		public unsafe static long GetLong(string key, [UnityEngine.Internal.DefaultValue("0")] long defaultValue)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetLong_Injected(ref managedSpanWrapper, defaultValue);
					}
				}
				return GetLong_Injected(ref managedSpanWrapper, defaultValue);
			}
			finally
			{
			}
		}

		[ExcludeFromDocs]
		public static float GetFloat(string key)
		{
			return GetFloat(key, 0f);
		}

		public unsafe static float GetFloat(string key, [UnityEngine.Internal.DefaultValue("0.0F")] float defaultValue)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetFloat_Injected(ref managedSpanWrapper, defaultValue);
					}
				}
				return GetFloat_Injected(ref managedSpanWrapper, defaultValue);
			}
			finally
			{
			}
		}

		[ExcludeFromDocs]
		public static string GetString(string key)
		{
			return GetString(key, "");
		}

		public unsafe static string GetString(string key, [UnityEngine.Internal.DefaultValue("\"\"")] string defaultValue)
		{
			//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper key2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						key2 = ref managedSpanWrapper;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(defaultValue, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(defaultValue);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								GetString_Injected(ref key2, ref managedSpanWrapper2, out ret);
							}
						}
						else
						{
							GetString_Injected(ref key2, ref managedSpanWrapper2, out ret);
						}
					}
				}
				else
				{
					key2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(defaultValue, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(defaultValue);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							GetString_Injected(ref key2, ref managedSpanWrapper2, out ret);
						}
					}
					else
					{
						GetString_Injected(ref key2, ref managedSpanWrapper2, out ret);
					}
				}
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[ExcludeFromDocs]
		public static bool GetBool(string key)
		{
			return GetBool(key, defaultValue: false);
		}

		public unsafe static bool GetBool(string key, [UnityEngine.Internal.DefaultValue("false")] bool defaultValue)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetBool_Injected(ref managedSpanWrapper, defaultValue);
					}
				}
				return GetBool_Injected(ref managedSpanWrapper, defaultValue);
			}
			finally
			{
			}
		}

		public unsafe static bool HasKey(string key)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return HasKey_Injected(ref managedSpanWrapper);
					}
				}
				return HasKey_Injected(ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetCount();

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string[] GetKeys();

		public static T GetObject<T>(string key = "")
		{
			return (T)GetObject(typeof(T), key);
		}

		public static object GetObject(Type type, string key = "")
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type.IsAbstract || type.IsSubclassOf(typeof(Object)))
			{
				throw new ArgumentException("Cannot deserialize to new instances of type '" + type.Name + ".'");
			}
			return GetAsScriptingObject(type, null, key);
		}

		public static object GetObject(string key, object defaultValue)
		{
			if (defaultValue == null)
			{
				throw new ArgumentNullException("defaultValue");
			}
			Type type = defaultValue.GetType();
			if (type.IsAbstract || type.IsSubclassOf(typeof(Object)))
			{
				throw new ArgumentException("Cannot deserialize to new instances of type '" + type.Name + ".'");
			}
			return GetAsScriptingObject(type, defaultValue, key);
		}

		internal unsafe static object GetAsScriptingObject(Type t, object defaultValue, string key)
		{
			//The blocks IL_002b are reachable both inside and outside the pinned region starting at IL_001a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetAsScriptingObject_Injected(t, defaultValue, ref managedSpanWrapper);
					}
				}
				return GetAsScriptingObject_Injected(t, defaultValue, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		public static IDictionary<string, object> GetDictionary(string key = "")
		{
			UseSafeLock();
			IDictionary<string, object> dictionary = RemoteConfigSettingsHelper.GetDictionary(GetSafeTopMap(), key);
			ReleaseSafeLock();
			return dictionary;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void UseSafeLock();

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ReleaseSafeLock();

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr GetSafeTopMap();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetInt_Injected(ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("0")] int defaultValue);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern long GetLong_Injected(ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("0")] long defaultValue);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetFloat_Injected(ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("0.0F")] float defaultValue);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetString_Injected(ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("\"\"")] ref ManagedSpanWrapper defaultValue, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetBool_Injected(ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("false")] bool defaultValue);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasKey_Injected(ref ManagedSpanWrapper key);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern object GetAsScriptingObject_Injected(Type t, object defaultValue, ref ManagedSpanWrapper key);
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/UnityAnalyticsCommon/Public/UnityAnalyticsCommon.h")]
	[ExcludeFromDocs]
	[NativeHeader("Modules/UnityAnalytics/RemoteSettings/RemoteSettings.h")]
	[NativeHeader("UnityAnalyticsScriptingClasses.h")]
	public class RemoteConfigSettings : IDisposable
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(RemoteConfigSettings remoteConfigSettings)
			{
				return remoteConfigSettings.m_Ptr;
			}
		}

		[NonSerialized]
		internal IntPtr m_Ptr;

		public event Action<bool> Updated;

		private RemoteConfigSettings()
		{
		}

		public RemoteConfigSettings(string configKey)
		{
			m_Ptr = Internal_Create(this, configKey);
			this.Updated = null;
		}

		~RemoteConfigSettings()
		{
			Destroy();
		}

		private void Destroy()
		{
			if (m_Ptr != IntPtr.Zero)
			{
				Internal_Destroy(m_Ptr);
				m_Ptr = IntPtr.Zero;
			}
		}

		public void Dispose()
		{
			Destroy();
			GC.SuppressFinalize(this);
		}

		internal unsafe static IntPtr Internal_Create([Unmarshalled] RemoteConfigSettings rcs, string configKey)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(configKey, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(configKey);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return Internal_Create_Injected(rcs, ref managedSpanWrapper);
					}
				}
				return Internal_Create_Injected(rcs, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		internal static extern void Internal_Destroy(IntPtr ptr);

		[RequiredByNativeCode]
		[Preserve]
		internal static void RemoteConfigSettingsUpdated(RemoteConfigSettings rcs, bool wasLastUpdatedFromServer)
		{
			rcs.Updated?.Invoke(wasLastUpdatedFromServer);
		}

		public unsafe static AnalyticsResult QueueConfig(string name, object param, int ver = 1, string prefix = "")
		{
			//The blocks IL_0029, IL_0038, IL_0046, IL_0054, IL_0059 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper name2;
				object param2;
				int ver2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						name2 = ref managedSpanWrapper;
						param2 = param;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								return QueueConfig_Injected(ref name2, param2, ver2, ref managedSpanWrapper2);
							}
						}
						return QueueConfig_Injected(ref name2, param2, ver2, ref managedSpanWrapper2);
					}
				}
				name2 = ref managedSpanWrapper;
				param2 = param;
				ver2 = ver;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						return QueueConfig_Injected(ref name2, param2, ver2, ref managedSpanWrapper2);
					}
				}
				return QueueConfig_Injected(ref name2, param2, ver2, ref managedSpanWrapper2);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool SendDeviceInfoInConfigRequest();

		public unsafe static void AddSessionTag(string tag)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(tag, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(tag);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						AddSessionTag_Injected(ref managedSpanWrapper);
						return;
					}
				}
				AddSessionTag_Injected(ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		public void ForceUpdate()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ForceUpdate_Injected(intPtr);
		}

		public bool WasLastUpdatedFromServer()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return WasLastUpdatedFromServer_Injected(intPtr);
		}

		[ExcludeFromDocs]
		public int GetInt(string key)
		{
			return GetInt(key, 0);
		}

		public unsafe int GetInt(string key, [UnityEngine.Internal.DefaultValue("0")] int defaultValue)
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
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetInt_Injected(intPtr, ref managedSpanWrapper, defaultValue);
					}
				}
				return GetInt_Injected(intPtr, ref managedSpanWrapper, defaultValue);
			}
			finally
			{
			}
		}

		[ExcludeFromDocs]
		public long GetLong(string key)
		{
			return GetLong(key, 0L);
		}

		public unsafe long GetLong(string key, [UnityEngine.Internal.DefaultValue("0")] long defaultValue)
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
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetLong_Injected(intPtr, ref managedSpanWrapper, defaultValue);
					}
				}
				return GetLong_Injected(intPtr, ref managedSpanWrapper, defaultValue);
			}
			finally
			{
			}
		}

		[ExcludeFromDocs]
		public float GetFloat(string key)
		{
			return GetFloat(key, 0f);
		}

		public unsafe float GetFloat(string key, [UnityEngine.Internal.DefaultValue("0.0F")] float defaultValue)
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
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetFloat_Injected(intPtr, ref managedSpanWrapper, defaultValue);
					}
				}
				return GetFloat_Injected(intPtr, ref managedSpanWrapper, defaultValue);
			}
			finally
			{
			}
		}

		[ExcludeFromDocs]
		public string GetString(string key)
		{
			return GetString(key, "");
		}

		public unsafe string GetString(string key, [UnityEngine.Internal.DefaultValue("\"\"")] string defaultValue)
		{
			//The blocks IL_0039, IL_0046, IL_0054, IL_0062, IL_0067 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0067 are reachable both inside and outside the pinned region starting at IL_0054. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0067 are reachable both inside and outside the pinned region starting at IL_0054. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
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
				ref ManagedSpanWrapper key2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						key2 = ref managedSpanWrapper;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(defaultValue, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(defaultValue);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								GetString_Injected(intPtr, ref key2, ref managedSpanWrapper2, out ret);
							}
						}
						else
						{
							GetString_Injected(intPtr, ref key2, ref managedSpanWrapper2, out ret);
						}
					}
				}
				else
				{
					key2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(defaultValue, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(defaultValue);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							GetString_Injected(intPtr, ref key2, ref managedSpanWrapper2, out ret);
						}
					}
					else
					{
						GetString_Injected(intPtr, ref key2, ref managedSpanWrapper2, out ret);
					}
				}
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[ExcludeFromDocs]
		public bool GetBool(string key)
		{
			return GetBool(key, defaultValue: false);
		}

		public unsafe bool GetBool(string key, [UnityEngine.Internal.DefaultValue("false")] bool defaultValue)
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
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetBool_Injected(intPtr, ref managedSpanWrapper, defaultValue);
					}
				}
				return GetBool_Injected(intPtr, ref managedSpanWrapper, defaultValue);
			}
			finally
			{
			}
		}

		public unsafe bool HasKey(string key)
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
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return HasKey_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return HasKey_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		public int GetCount()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetCount_Injected(intPtr);
		}

		public string[] GetKeys()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetKeys_Injected(intPtr);
		}

		public T GetObject<T>(string key = "")
		{
			return (T)GetObject(typeof(T), key);
		}

		public object GetObject(Type type, string key = "")
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type.IsAbstract || type.IsSubclassOf(typeof(Object)))
			{
				throw new ArgumentException("Cannot deserialize to new instances of type '" + type.Name + ".'");
			}
			return GetAsScriptingObject(type, null, key);
		}

		public object GetObject(string key, object defaultValue)
		{
			if (defaultValue == null)
			{
				throw new ArgumentNullException("defaultValue");
			}
			Type type = defaultValue.GetType();
			if (type.IsAbstract || type.IsSubclassOf(typeof(Object)))
			{
				throw new ArgumentException("Cannot deserialize to new instances of type '" + type.Name + ".'");
			}
			return GetAsScriptingObject(type, defaultValue, key);
		}

		internal unsafe object GetAsScriptingObject(Type t, object defaultValue, string key)
		{
			//The blocks IL_003b are reachable both inside and outside the pinned region starting at IL_002a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetAsScriptingObject_Injected(intPtr, t, defaultValue, ref managedSpanWrapper);
					}
				}
				return GetAsScriptingObject_Injected(intPtr, t, defaultValue, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		public IDictionary<string, object> GetDictionary(string key = "")
		{
			UseSafeLock();
			IDictionary<string, object> dictionary = RemoteConfigSettingsHelper.GetDictionary(GetSafeTopMap(), key);
			ReleaseSafeLock();
			return dictionary;
		}

		internal void UseSafeLock()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			UseSafeLock_Injected(intPtr);
		}

		internal void ReleaseSafeLock()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ReleaseSafeLock_Injected(intPtr);
		}

		internal IntPtr GetSafeTopMap()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetSafeTopMap_Injected(intPtr);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Internal_Create_Injected(RemoteConfigSettings rcs, ref ManagedSpanWrapper configKey);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult QueueConfig_Injected(ref ManagedSpanWrapper name, object param, int ver, ref ManagedSpanWrapper prefix);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddSessionTag_Injected(ref ManagedSpanWrapper tag);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ForceUpdate_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool WasLastUpdatedFromServer_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetInt_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("0")] int defaultValue);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern long GetLong_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("0")] long defaultValue);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetFloat_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("0.0F")] float defaultValue);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("\"\"")] ref ManagedSpanWrapper defaultValue, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetBool_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, [UnityEngine.Internal.DefaultValue("false")] bool defaultValue);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasKey_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string[] GetKeys_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern object GetAsScriptingObject_Injected(IntPtr _unity_self, Type t, object defaultValue, ref ManagedSpanWrapper key);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UseSafeLock_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ReleaseSafeLock_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetSafeTopMap_Injected(IntPtr _unity_self);
	}
	internal static class RemoteConfigSettingsHelper
	{
		[Preserve]
		[RequiredByNativeCode]
		internal enum Tag
		{
			kUnknown,
			kIntVal,
			kInt64Val,
			kUInt64Val,
			kDoubleVal,
			kBoolVal,
			kStringVal,
			kArrayVal,
			kMixedArrayVal,
			kMapVal,
			kMaxTags
		}

		internal unsafe static IntPtr GetSafeMap(IntPtr m, string key)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetSafeMap_Injected(m, ref managedSpanWrapper);
					}
				}
				return GetSafeMap_Injected(m, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string[] GetSafeMapKeys(IntPtr m);

		internal static Tag[] GetSafeMapTypes(IntPtr m)
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			Tag[] result;
			try
			{
				GetSafeMapTypes_Injected(m, out ret);
			}
			finally
			{
				Tag[] array = default(Tag[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}

		internal unsafe static long GetSafeNumber(IntPtr m, string key, long defaultValue)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetSafeNumber_Injected(m, ref managedSpanWrapper, defaultValue);
					}
				}
				return GetSafeNumber_Injected(m, ref managedSpanWrapper, defaultValue);
			}
			finally
			{
			}
		}

		internal unsafe static float GetSafeFloat(IntPtr m, string key, float defaultValue)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetSafeFloat_Injected(m, ref managedSpanWrapper, defaultValue);
					}
				}
				return GetSafeFloat_Injected(m, ref managedSpanWrapper, defaultValue);
			}
			finally
			{
			}
		}

		internal unsafe static bool GetSafeBool(IntPtr m, string key, bool defaultValue)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetSafeBool_Injected(m, ref managedSpanWrapper, defaultValue);
					}
				}
				return GetSafeBool_Injected(m, ref managedSpanWrapper, defaultValue);
			}
			finally
			{
			}
		}

		internal unsafe static string GetSafeStringValue(IntPtr m, string key, string defaultValue)
		{
			//The blocks IL_002a, IL_0037, IL_0045, IL_0053, IL_0058 are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0058 are reachable both inside and outside the pinned region starting at IL_0045. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0058 are reachable both inside and outside the pinned region starting at IL_0045. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper key2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						key2 = ref managedSpanWrapper;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(defaultValue, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(defaultValue);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								GetSafeStringValue_Injected(m, ref key2, ref managedSpanWrapper2, out ret);
							}
						}
						else
						{
							GetSafeStringValue_Injected(m, ref key2, ref managedSpanWrapper2, out ret);
						}
					}
				}
				else
				{
					key2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(defaultValue, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(defaultValue);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							GetSafeStringValue_Injected(m, ref key2, ref managedSpanWrapper2, out ret);
						}
					}
					else
					{
						GetSafeStringValue_Injected(m, ref key2, ref managedSpanWrapper2, out ret);
					}
				}
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		internal unsafe static IntPtr GetSafeArray(IntPtr m, string key)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetSafeArray_Injected(m, ref managedSpanWrapper);
					}
				}
				return GetSafeArray_Injected(m, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern long GetSafeArraySize(IntPtr a);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr GetSafeArrayArray(IntPtr a, long i);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr GetSafeArrayMap(IntPtr a, long i);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Tag GetSafeArrayType(IntPtr a, long i);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern long GetSafeNumberArray(IntPtr a, long i);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern float GetSafeArrayFloat(IntPtr a, long i);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool GetSafeArrayBool(IntPtr a, long i);

		internal static string GetSafeArrayStringValue(IntPtr a, long i)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				GetSafeArrayStringValue_Injected(a, i, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		public static IDictionary<string, object> GetDictionary(IntPtr m, string key)
		{
			if (m == IntPtr.Zero)
			{
				return null;
			}
			if (!string.IsNullOrEmpty(key))
			{
				m = GetSafeMap(m, key);
				if (m == IntPtr.Zero)
				{
					return null;
				}
			}
			return GetDictionary(m);
		}

		internal static IDictionary<string, object> GetDictionary(IntPtr m)
		{
			if (m == IntPtr.Zero)
			{
				return null;
			}
			IDictionary<string, object> dictionary = new Dictionary<string, object>();
			Tag[] safeMapTypes = GetSafeMapTypes(m);
			string[] safeMapKeys = GetSafeMapKeys(m);
			for (int i = 0; i < safeMapKeys.Length; i++)
			{
				SetDictKeyType(m, dictionary, safeMapKeys[i], safeMapTypes[i]);
			}
			return dictionary;
		}

		internal static object GetArrayArrayEntries(IntPtr a, long i)
		{
			return GetArrayEntries(GetSafeArrayArray(a, i));
		}

		internal static IDictionary<string, object> GetArrayMapEntries(IntPtr a, long i)
		{
			return GetDictionary(GetSafeArrayMap(a, i));
		}

		internal static T[] GetArrayEntriesType<T>(IntPtr a, long size, Func<IntPtr, long, T> f)
		{
			T[] array = new T[size];
			for (long num = 0L; num < size; num++)
			{
				array[num] = f(a, num);
			}
			return array;
		}

		internal static object GetArrayEntries(IntPtr a)
		{
			long safeArraySize = GetSafeArraySize(a);
			if (safeArraySize == 0)
			{
				return null;
			}
			switch (GetSafeArrayType(a, 0L))
			{
			case Tag.kIntVal:
			case Tag.kInt64Val:
				return GetArrayEntriesType(a, safeArraySize, GetSafeNumberArray);
			case Tag.kDoubleVal:
				return GetArrayEntriesType(a, safeArraySize, GetSafeArrayFloat);
			case Tag.kBoolVal:
				return GetArrayEntriesType(a, safeArraySize, GetSafeArrayBool);
			case Tag.kStringVal:
				return GetArrayEntriesType(a, safeArraySize, GetSafeArrayStringValue);
			case Tag.kArrayVal:
				return GetArrayEntriesType(a, safeArraySize, GetArrayArrayEntries);
			case Tag.kMapVal:
				return GetArrayEntriesType(a, safeArraySize, GetArrayMapEntries);
			default:
				return null;
			}
		}

		internal static object GetMixedArrayEntries(IntPtr a)
		{
			long safeArraySize = GetSafeArraySize(a);
			if (safeArraySize == 0)
			{
				return null;
			}
			object[] array = new object[safeArraySize];
			for (long num = 0L; num < safeArraySize; num++)
			{
				switch (GetSafeArrayType(a, num))
				{
				case Tag.kIntVal:
				case Tag.kInt64Val:
					array[num] = GetSafeNumberArray(a, num);
					break;
				case Tag.kDoubleVal:
					array[num] = GetSafeArrayFloat(a, num);
					break;
				case Tag.kBoolVal:
					array[num] = GetSafeArrayBool(a, num);
					break;
				case Tag.kStringVal:
					array[num] = GetSafeArrayStringValue(a, num);
					break;
				case Tag.kArrayVal:
					array[num] = GetArrayArrayEntries(a, num);
					break;
				case Tag.kMapVal:
					array[num] = GetArrayMapEntries(a, num);
					break;
				}
			}
			return array;
		}

		internal static void SetDictKeyType(IntPtr m, IDictionary<string, object> dict, string key, Tag tag)
		{
			switch (tag)
			{
			case Tag.kIntVal:
			case Tag.kInt64Val:
				dict[key] = GetSafeNumber(m, key, 0L);
				break;
			case Tag.kDoubleVal:
				dict[key] = GetSafeFloat(m, key, 0f);
				break;
			case Tag.kBoolVal:
				dict[key] = GetSafeBool(m, key, defaultValue: false);
				break;
			case Tag.kStringVal:
				dict[key] = GetSafeStringValue(m, key, "");
				break;
			case Tag.kArrayVal:
				dict[key] = GetArrayEntries(GetSafeArray(m, key));
				break;
			case Tag.kMixedArrayVal:
				dict[key] = GetMixedArrayEntries(GetSafeArray(m, key));
				break;
			case Tag.kMapVal:
				dict[key] = GetDictionary(GetSafeMap(m, key));
				break;
			case Tag.kUInt64Val:
				break;
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetSafeMap_Injected(IntPtr m, ref ManagedSpanWrapper key);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSafeMapTypes_Injected(IntPtr m, out BlittableArrayWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern long GetSafeNumber_Injected(IntPtr m, ref ManagedSpanWrapper key, long defaultValue);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetSafeFloat_Injected(IntPtr m, ref ManagedSpanWrapper key, float defaultValue);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetSafeBool_Injected(IntPtr m, ref ManagedSpanWrapper key, bool defaultValue);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSafeStringValue_Injected(IntPtr m, ref ManagedSpanWrapper key, ref ManagedSpanWrapper defaultValue, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetSafeArray_Injected(IntPtr m, ref ManagedSpanWrapper key);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSafeArrayStringValue_Injected(IntPtr a, long i, out ManagedSpanWrapper ret);
	}
}
namespace UnityEngine.Analytics
{
	[Preserve]
	[RequiredByNativeCode]
	[NativeHeader("Modules/UnityAnalytics/Public/UnityAnalytics.h")]
	[NativeHeader("Modules/UnityAnalyticsCommon/Public/UnityAnalyticsCommon.h")]
	[NativeHeader("Modules/UnityAnalytics/ContinuousEvent/Manager.h")]
	[ExcludeFromDocs]
	public class ContinuousEvent
	{
		public static AnalyticsResult RegisterCollector<T>(string metricName, Func<T> del) where T : struct, IComparable<T>, IEquatable<T>
		{
			if (string.IsNullOrEmpty(metricName))
			{
				throw new ArgumentException("Cannot set metric name to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return InternalRegisterCollector(typeof(T).ToString(), metricName, del);
		}

		public static AnalyticsResult SetEventHistogramThresholds<T>(string eventName, int count, T[] data, int ver = 1, string prefix = "") where T : struct, IComparable<T>, IEquatable<T>
		{
			if (string.IsNullOrEmpty(eventName))
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return InternalSetEventHistogramThresholds(typeof(T).ToString(), eventName, count, data, ver, prefix);
		}

		public static AnalyticsResult SetCustomEventHistogramThresholds<T>(string eventName, int count, T[] data) where T : struct, IComparable<T>, IEquatable<T>
		{
			if (string.IsNullOrEmpty(eventName))
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return InternalSetCustomEventHistogramThresholds(typeof(T).ToString(), eventName, count, data);
		}

		public static AnalyticsResult ConfigureCustomEvent(string customEventName, string metricName, float interval, float period, bool enabled = true)
		{
			if (string.IsNullOrEmpty(customEventName))
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return InternalConfigureCustomEvent(customEventName, metricName, interval, period, enabled);
		}

		public static AnalyticsResult ConfigureEvent(string eventName, string metricName, float interval, float period, bool enabled = true, int ver = 1, string prefix = "")
		{
			if (string.IsNullOrEmpty(eventName))
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return InternalConfigureEvent(eventName, metricName, interval, period, enabled, ver, prefix);
		}

		[StaticAccessor("::GetUnityAnalytics().GetContinuousEventManager()", StaticAccessorType.Dot)]
		private unsafe static AnalyticsResult InternalRegisterCollector(string type, string metricName, object collector)
		{
			//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper type2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(type, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(type);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						type2 = ref managedSpanWrapper;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(metricName, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(metricName);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								return InternalRegisterCollector_Injected(ref type2, ref managedSpanWrapper2, collector);
							}
						}
						return InternalRegisterCollector_Injected(ref type2, ref managedSpanWrapper2, collector);
					}
				}
				type2 = ref managedSpanWrapper;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(metricName, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(metricName);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						return InternalRegisterCollector_Injected(ref type2, ref managedSpanWrapper2, collector);
					}
				}
				return InternalRegisterCollector_Injected(ref type2, ref managedSpanWrapper2, collector);
			}
			finally
			{
			}
		}

		[StaticAccessor("::GetUnityAnalytics().GetContinuousEventManager()", StaticAccessorType.Dot)]
		private unsafe static AnalyticsResult InternalSetEventHistogramThresholds(string type, string eventName, int count, object data, int ver, string prefix)
		{
			//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057, IL_0069, IL_0079, IL_0087, IL_008c are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057, IL_0069, IL_0079, IL_0087, IL_008c are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008c are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008c are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057, IL_0069, IL_0079, IL_0087, IL_008c are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008c are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008c are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper type2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				ref ManagedSpanWrapper eventName2;
				int count2;
				object data2;
				int ver2;
				ManagedSpanWrapper managedSpanWrapper3 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan3;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(type, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(type);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						type2 = ref managedSpanWrapper;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(eventName);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								eventName2 = ref managedSpanWrapper2;
								count2 = count;
								data2 = data;
								ver2 = ver;
								if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
								{
									readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
									fixed (char* begin3 = readOnlySpan3)
									{
										managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
										return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
									}
								}
								return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
							}
						}
						eventName2 = ref managedSpanWrapper2;
						count2 = count;
						data2 = data;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
						{
							readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin3 = readOnlySpan3)
							{
								managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
								return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
							}
						}
						return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
					}
				}
				type2 = ref managedSpanWrapper;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(eventName);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						eventName2 = ref managedSpanWrapper2;
						count2 = count;
						data2 = data;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
						{
							readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin3 = readOnlySpan3)
							{
								managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
								return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
							}
						}
						return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
					}
				}
				eventName2 = ref managedSpanWrapper2;
				count2 = count;
				data2 = data;
				ver2 = ver;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
				{
					readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
					fixed (char* begin3 = readOnlySpan3)
					{
						managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
						return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
					}
				}
				return InternalSetEventHistogramThresholds_Injected(ref type2, ref eventName2, count2, data2, ver2, ref managedSpanWrapper3);
			}
			finally
			{
			}
		}

		[StaticAccessor("::GetUnityAnalytics().GetContinuousEventManager()", StaticAccessorType.Dot)]
		private unsafe static AnalyticsResult InternalSetCustomEventHistogramThresholds(string type, string eventName, int count, object data)
		{
			//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper type2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(type, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(type);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						type2 = ref managedSpanWrapper;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(eventName);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								return InternalSetCustomEventHistogramThresholds_Injected(ref type2, ref managedSpanWrapper2, count, data);
							}
						}
						return InternalSetCustomEventHistogramThresholds_Injected(ref type2, ref managedSpanWrapper2, count, data);
					}
				}
				type2 = ref managedSpanWrapper;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(eventName);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						return InternalSetCustomEventHistogramThresholds_Injected(ref type2, ref managedSpanWrapper2, count, data);
					}
				}
				return InternalSetCustomEventHistogramThresholds_Injected(ref type2, ref managedSpanWrapper2, count, data);
			}
			finally
			{
			}
		}

		[StaticAccessor("::GetUnityAnalytics().GetContinuousEventManager()", StaticAccessorType.Dot)]
		private unsafe static AnalyticsResult InternalConfigureCustomEvent(string customEventName, string metricName, float interval, float period, bool enabled)
		{
			//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper customEventName2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(customEventName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(customEventName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						customEventName2 = ref managedSpanWrapper;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(metricName, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(metricName);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								return InternalConfigureCustomEvent_Injected(ref customEventName2, ref managedSpanWrapper2, interval, period, enabled);
							}
						}
						return InternalConfigureCustomEvent_Injected(ref customEventName2, ref managedSpanWrapper2, interval, period, enabled);
					}
				}
				customEventName2 = ref managedSpanWrapper;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(metricName, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(metricName);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						return InternalConfigureCustomEvent_Injected(ref customEventName2, ref managedSpanWrapper2, interval, period, enabled);
					}
				}
				return InternalConfigureCustomEvent_Injected(ref customEventName2, ref managedSpanWrapper2, interval, period, enabled);
			}
			finally
			{
			}
		}

		[StaticAccessor("::GetUnityAnalytics().GetContinuousEventManager()", StaticAccessorType.Dot)]
		private unsafe static AnalyticsResult InternalConfigureEvent(string eventName, string metricName, float interval, float period, bool enabled, int ver, string prefix)
		{
			//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057, IL_006b, IL_007b, IL_0089, IL_008e are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057, IL_006b, IL_007b, IL_0089, IL_008e are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008e are reachable both inside and outside the pinned region starting at IL_007b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008e are reachable both inside and outside the pinned region starting at IL_007b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057, IL_006b, IL_007b, IL_0089, IL_008e are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008e are reachable both inside and outside the pinned region starting at IL_007b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008e are reachable both inside and outside the pinned region starting at IL_007b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper eventName2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				ref ManagedSpanWrapper metricName2;
				float interval2;
				float period2;
				bool enabled2;
				int ver2;
				ManagedSpanWrapper managedSpanWrapper3 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan3;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						eventName2 = ref managedSpanWrapper;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(metricName, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(metricName);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								metricName2 = ref managedSpanWrapper2;
								interval2 = interval;
								period2 = period;
								enabled2 = enabled;
								ver2 = ver;
								if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
								{
									readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
									fixed (char* begin3 = readOnlySpan3)
									{
										managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
										return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
									}
								}
								return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
							}
						}
						metricName2 = ref managedSpanWrapper2;
						interval2 = interval;
						period2 = period;
						enabled2 = enabled;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
						{
							readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin3 = readOnlySpan3)
							{
								managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
								return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
							}
						}
						return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
					}
				}
				eventName2 = ref managedSpanWrapper;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(metricName, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(metricName);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						metricName2 = ref managedSpanWrapper2;
						interval2 = interval;
						period2 = period;
						enabled2 = enabled;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
						{
							readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin3 = readOnlySpan3)
							{
								managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
								return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
							}
						}
						return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
					}
				}
				metricName2 = ref managedSpanWrapper2;
				interval2 = interval;
				period2 = period;
				enabled2 = enabled;
				ver2 = ver;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
				{
					readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
					fixed (char* begin3 = readOnlySpan3)
					{
						managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
						return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
					}
				}
				return InternalConfigureEvent_Injected(ref eventName2, ref metricName2, interval2, period2, enabled2, ver2, ref managedSpanWrapper3);
			}
			finally
			{
			}
		}

		internal static bool IsInitialized()
		{
			return Analytics.IsInitialized();
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult InternalRegisterCollector_Injected(ref ManagedSpanWrapper type, ref ManagedSpanWrapper metricName, object collector);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult InternalSetEventHistogramThresholds_Injected(ref ManagedSpanWrapper type, ref ManagedSpanWrapper eventName, int count, object data, int ver, ref ManagedSpanWrapper prefix);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult InternalSetCustomEventHistogramThresholds_Injected(ref ManagedSpanWrapper type, ref ManagedSpanWrapper eventName, int count, object data);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult InternalConfigureCustomEvent_Injected(ref ManagedSpanWrapper customEventName, ref ManagedSpanWrapper metricName, float interval, float period, bool enabled);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult InternalConfigureEvent_Injected(ref ManagedSpanWrapper eventName, ref ManagedSpanWrapper metricName, float interval, float period, bool enabled, int ver, ref ManagedSpanWrapper prefix);
	}
	[RequiredByNativeCode]
	[Preserve]
	public enum AnalyticsSessionState
	{
		kSessionStopped,
		kSessionStarted,
		kSessionPaused,
		kSessionResumed
	}
	[Preserve]
	[NativeHeader("Modules/UnityAnalytics/Public/UnityAnalytics.h")]
	[NativeHeader("UnityAnalyticsScriptingClasses.h")]
	[RequiredByNativeCode]
	public static class AnalyticsSessionInfo
	{
		public delegate void SessionStateChanged(AnalyticsSessionState sessionState, long sessionId, long sessionElapsedTime, bool sessionChanged);

		public delegate void IdentityTokenChanged(string token);

		public static extern AnalyticsSessionState sessionState
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("GetPlayerSessionState")]
			get;
		}

		public static extern long sessionId
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("GetPlayerSessionId")]
			get;
		}

		public static extern long sessionCount
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("GetPlayerSessionCount")]
			get;
		}

		public static extern long sessionElapsedTime
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("GetPlayerSessionElapsedTime")]
			get;
		}

		public static extern bool sessionFirstRun
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("GetPlayerSessionFirstRun", false, true)]
			get;
		}

		public static string userId
		{
			[NativeMethod("GetUserId")]
			get
			{
				ManagedSpanWrapper ret = default(ManagedSpanWrapper);
				string stringAndDispose;
				try
				{
					get_userId_Injected(out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
		}

		public static string customUserId
		{
			get
			{
				if (!Analytics.IsInitialized())
				{
					return null;
				}
				return customUserIdInternal;
			}
			set
			{
				if (Analytics.IsInitialized())
				{
					customUserIdInternal = value;
				}
			}
		}

		public static string customDeviceId
		{
			get
			{
				if (!Analytics.IsInitialized())
				{
					return null;
				}
				return customDeviceIdInternal;
			}
			set
			{
				if (Analytics.IsInitialized())
				{
					customDeviceIdInternal = value;
				}
			}
		}

		public static string identityToken
		{
			get
			{
				if (!Analytics.IsInitialized())
				{
					return null;
				}
				return identityTokenInternal;
			}
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static string identityTokenInternal
		{
			[NativeMethod("GetIdentityToken")]
			get
			{
				ManagedSpanWrapper ret = default(ManagedSpanWrapper);
				string stringAndDispose;
				try
				{
					get_identityTokenInternal_Injected(out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private unsafe static string customUserIdInternal
		{
			[NativeMethod("GetCustomUserId")]
			get
			{
				ManagedSpanWrapper ret = default(ManagedSpanWrapper);
				string stringAndDispose;
				try
				{
					get_customUserIdInternal_Injected(out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
			[NativeMethod("SetCustomUserId")]
			set
			{
				//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
				try
				{
					ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
					if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
					{
						ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
						fixed (char* begin = readOnlySpan)
						{
							managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
							set_customUserIdInternal_Injected(ref managedSpanWrapper);
							return;
						}
					}
					set_customUserIdInternal_Injected(ref managedSpanWrapper);
				}
				finally
				{
				}
			}
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private unsafe static string customDeviceIdInternal
		{
			[NativeMethod("GetCustomDeviceId")]
			get
			{
				ManagedSpanWrapper ret = default(ManagedSpanWrapper);
				string stringAndDispose;
				try
				{
					get_customDeviceIdInternal_Injected(out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
			[NativeMethod("SetCustomDeviceId")]
			set
			{
				//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
				try
				{
					ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
					if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
					{
						ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
						fixed (char* begin = readOnlySpan)
						{
							managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
							set_customDeviceIdInternal_Injected(ref managedSpanWrapper);
							return;
						}
					}
					set_customDeviceIdInternal_Injected(ref managedSpanWrapper);
				}
				finally
				{
				}
			}
		}

		public static event SessionStateChanged sessionStateChanged;

		public static event IdentityTokenChanged identityTokenChanged;

		[RequiredByNativeCode]
		[Preserve]
		internal static void CallSessionStateChanged(AnalyticsSessionState sessionState, long sessionId, long sessionElapsedTime, bool sessionChanged)
		{
			AnalyticsSessionInfo.sessionStateChanged?.Invoke(sessionState, sessionId, sessionElapsedTime, sessionChanged);
		}

		[RequiredByNativeCode]
		[Preserve]
		internal static void CallIdentityTokenChanged(string token)
		{
			AnalyticsSessionInfo.identityTokenChanged?.Invoke(token);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_userId_Injected(out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_identityTokenInternal_Injected(out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_customUserIdInternal_Injected(out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_customUserIdInternal_Injected(ref ManagedSpanWrapper value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_customDeviceIdInternal_Injected(out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_customDeviceIdInternal_Injected(ref ManagedSpanWrapper value);
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/UnityAnalytics/Public/Events/UserCustomEvent.h")]
	internal class CustomEventData : IDisposable
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(CustomEventData customEventData)
			{
				return customEventData.m_Ptr;
			}
		}

		[NonSerialized]
		internal IntPtr m_Ptr;

		private CustomEventData()
		{
		}

		public CustomEventData(string name)
		{
			m_Ptr = Internal_Create(this, name);
		}

		~CustomEventData()
		{
			Destroy();
		}

		private void Destroy()
		{
			if (m_Ptr != IntPtr.Zero)
			{
				Internal_Destroy(m_Ptr);
				m_Ptr = IntPtr.Zero;
			}
		}

		public void Dispose()
		{
			Destroy();
			GC.SuppressFinalize(this);
		}

		internal unsafe static IntPtr Internal_Create([Unmarshalled] CustomEventData ced, string name)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return Internal_Create_Injected(ced, ref managedSpanWrapper);
					}
				}
				return Internal_Create_Injected(ced, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		internal static extern void Internal_Destroy(IntPtr ptr);

		public unsafe bool AddString(string key, string value)
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
				ref ManagedSpanWrapper key2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						key2 = ref managedSpanWrapper;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(value);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								return AddString_Injected(intPtr, ref key2, ref managedSpanWrapper2);
							}
						}
						return AddString_Injected(intPtr, ref key2, ref managedSpanWrapper2);
					}
				}
				key2 = ref managedSpanWrapper;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(value);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						return AddString_Injected(intPtr, ref key2, ref managedSpanWrapper2);
					}
				}
				return AddString_Injected(intPtr, ref key2, ref managedSpanWrapper2);
			}
			finally
			{
			}
		}

		public unsafe bool AddInt32(string key, int value)
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
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return AddInt32_Injected(intPtr, ref managedSpanWrapper, value);
					}
				}
				return AddInt32_Injected(intPtr, ref managedSpanWrapper, value);
			}
			finally
			{
			}
		}

		public unsafe bool AddUInt32(string key, uint value)
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
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return AddUInt32_Injected(intPtr, ref managedSpanWrapper, value);
					}
				}
				return AddUInt32_Injected(intPtr, ref managedSpanWrapper, value);
			}
			finally
			{
			}
		}

		public unsafe bool AddInt64(string key, long value)
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
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return AddInt64_Injected(intPtr, ref managedSpanWrapper, value);
					}
				}
				return AddInt64_Injected(intPtr, ref managedSpanWrapper, value);
			}
			finally
			{
			}
		}

		public unsafe bool AddUInt64(string key, ulong value)
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
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return AddUInt64_Injected(intPtr, ref managedSpanWrapper, value);
					}
				}
				return AddUInt64_Injected(intPtr, ref managedSpanWrapper, value);
			}
			finally
			{
			}
		}

		public unsafe bool AddBool(string key, bool value)
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
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return AddBool_Injected(intPtr, ref managedSpanWrapper, value);
					}
				}
				return AddBool_Injected(intPtr, ref managedSpanWrapper, value);
			}
			finally
			{
			}
		}

		public unsafe bool AddDouble(string key, double value)
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
				if (!StringMarshaller.TryMarshalEmptyOrNullString(key, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(key);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return AddDouble_Injected(intPtr, ref managedSpanWrapper, value);
					}
				}
				return AddDouble_Injected(intPtr, ref managedSpanWrapper, value);
			}
			finally
			{
			}
		}

		public bool AddDictionary(IDictionary<string, object> eventData)
		{
			foreach (KeyValuePair<string, object> eventDatum in eventData)
			{
				string key = eventDatum.Key;
				object value = eventDatum.Value;
				if (value == null)
				{
					AddString(key, "null");
					continue;
				}
				Type type = value.GetType();
				if (type == typeof(string))
				{
					AddString(key, (string)value);
					continue;
				}
				if (type == typeof(char))
				{
					AddString(key, char.ToString((char)value));
					continue;
				}
				if (type == typeof(sbyte))
				{
					AddInt32(key, (sbyte)value);
					continue;
				}
				if (type == typeof(byte))
				{
					AddInt32(key, (byte)value);
					continue;
				}
				if (type == typeof(short))
				{
					AddInt32(key, (short)value);
					continue;
				}
				if (type == typeof(ushort))
				{
					AddUInt32(key, (ushort)value);
					continue;
				}
				if (type == typeof(int))
				{
					AddInt32(key, (int)value);
					continue;
				}
				if (type == typeof(uint))
				{
					AddUInt32(eventDatum.Key, (uint)value);
					continue;
				}
				if (type == typeof(long))
				{
					AddInt64(key, (long)value);
					continue;
				}
				if (type == typeof(ulong))
				{
					AddUInt64(key, (ulong)value);
					continue;
				}
				if (type == typeof(bool))
				{
					AddBool(key, (bool)value);
					continue;
				}
				if (type == typeof(float))
				{
					AddDouble(key, (double)Convert.ToDecimal((float)value));
					continue;
				}
				if (type == typeof(double))
				{
					AddDouble(key, (double)value);
					continue;
				}
				if (type == typeof(decimal))
				{
					AddDouble(key, (double)Convert.ToDecimal((decimal)value));
					continue;
				}
				if (type.IsValueType)
				{
					AddString(key, value.ToString());
					continue;
				}
				throw new ArgumentException($"Invalid type: {type} passed");
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Internal_Create_Injected(CustomEventData ced, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool AddString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, ref ManagedSpanWrapper value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool AddInt32_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool AddUInt32_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, uint value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool AddInt64_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, long value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool AddUInt64_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, ulong value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool AddBool_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool AddDouble_Injected(IntPtr _unity_self, ref ManagedSpanWrapper key, double value);
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/UnityAnalytics/Public/UnityAnalytics.h")]
	[NativeHeader("Modules/UnityAnalytics/Public/Events/UserCustomEvent.h")]
	[NativeHeader("Modules/UnityAnalyticsCommon/Public/UnityAnalyticsCommon.h")]
	[NativeHeader("Modules/UnityConnect/UnityConnectSettings.h")]
	public static class Analytics
	{
		public static bool initializeOnStartup
		{
			get
			{
				if (!IsInitialized())
				{
					return false;
				}
				return initializeOnStartupInternal;
			}
			set
			{
				if (IsInitialized())
				{
					initializeOnStartupInternal = value;
				}
			}
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern bool initializeOnStartupInternal
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("GetInitializeOnStartup")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("SetInitializeOnStartup")]
			set;
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern bool enabledInternal
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("GetEnabled")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("SetEnabled")]
			set;
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern bool playerOptedOutInternal
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("GetPlayerOptedOut")]
			get;
		}

		[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
		private static string eventUrlInternal
		{
			[NativeMethod("GetEventUrl")]
			get
			{
				ManagedSpanWrapper ret = default(ManagedSpanWrapper);
				string stringAndDispose;
				try
				{
					get_eventUrlInternal_Injected(out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
		}

		[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
		private static string configUrlInternal
		{
			[NativeMethod("GetConfigUrl")]
			get
			{
				ManagedSpanWrapper ret = default(ManagedSpanWrapper);
				string stringAndDispose;
				try
				{
					get_configUrlInternal_Injected(out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
		}

		[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
		private static string dashboardUrlInternal
		{
			[NativeMethod("GetDashboardUrl")]
			get
			{
				ManagedSpanWrapper ret = default(ManagedSpanWrapper);
				string stringAndDispose;
				try
				{
					get_dashboardUrlInternal_Injected(out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern bool limitUserTrackingInternal
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("GetLimitUserTracking")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("SetLimitUserTracking")]
			set;
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern bool deviceStatsEnabledInternal
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("GetDeviceStatsEnabled")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("SetDeviceStatsEnabled")]
			set;
		}

		public static bool playerOptedOut
		{
			get
			{
				if (!IsInitialized())
				{
					return false;
				}
				return playerOptedOutInternal;
			}
		}

		public static string eventUrl
		{
			get
			{
				if (!IsInitialized())
				{
					return string.Empty;
				}
				return eventUrlInternal;
			}
		}

		public static string dashboardUrl
		{
			get
			{
				if (!IsInitialized())
				{
					return string.Empty;
				}
				return dashboardUrlInternal;
			}
		}

		public static string configUrl
		{
			get
			{
				if (!IsInitialized())
				{
					return string.Empty;
				}
				return configUrlInternal;
			}
		}

		public static bool limitUserTracking
		{
			get
			{
				if (!IsInitialized())
				{
					return false;
				}
				return limitUserTrackingInternal;
			}
			set
			{
				if (IsInitialized())
				{
					limitUserTrackingInternal = value;
				}
			}
		}

		public static bool deviceStatsEnabled
		{
			get
			{
				if (!IsInitialized())
				{
					return false;
				}
				return deviceStatsEnabledInternal;
			}
			set
			{
				if (IsInitialized())
				{
					deviceStatsEnabledInternal = value;
				}
			}
		}

		public static bool enabled
		{
			get
			{
				if (!IsInitialized())
				{
					return false;
				}
				return enabledInternal;
			}
			set
			{
				if (IsInitialized())
				{
					enabledInternal = value;
				}
			}
		}

		public static AnalyticsResult ResumeInitialization()
		{
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return ResumeInitializationInternal();
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("ResumeInitialization")]
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern AnalyticsResult ResumeInitializationInternal();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		internal static extern bool IsInitialized();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("FlushEvents")]
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern bool FlushArchivedEvents();

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private unsafe static AnalyticsResult Transaction(string productId, double amount, string currency, string receiptPurchaseData, string signature, bool usingIAPService)
		{
			//The blocks IL_0029, IL_0037, IL_0045, IL_0053, IL_0058, IL_0065, IL_0074, IL_0082, IL_0087, IL_0095, IL_00a5, IL_00b3, IL_00b8 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0058, IL_0065, IL_0074, IL_0082, IL_0087, IL_0095, IL_00a5, IL_00b3, IL_00b8 are reachable both inside and outside the pinned region starting at IL_0045. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0087, IL_0095, IL_00a5, IL_00b3, IL_00b8 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0087, IL_0095, IL_00a5, IL_00b3, IL_00b8 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0058, IL_0065, IL_0074, IL_0082, IL_0087, IL_0095, IL_00a5, IL_00b3, IL_00b8 are reachable both inside and outside the pinned region starting at IL_0045. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0087, IL_0095, IL_00a5, IL_00b3, IL_00b8 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0087, IL_0095, IL_00a5, IL_00b3, IL_00b8 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00b8 are reachable both inside and outside the pinned region starting at IL_00a5. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper productId2;
				double amount2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				ref ManagedSpanWrapper currency2;
				ManagedSpanWrapper managedSpanWrapper3 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan3;
				ref ManagedSpanWrapper receiptPurchaseData2;
				ManagedSpanWrapper managedSpanWrapper4 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan4;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(productId, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(productId);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						productId2 = ref managedSpanWrapper;
						amount2 = amount;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(currency, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(currency);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								currency2 = ref managedSpanWrapper2;
								if (!StringMarshaller.TryMarshalEmptyOrNullString(receiptPurchaseData, ref managedSpanWrapper3))
								{
									readOnlySpan3 = MemoryExtensions.AsSpan(receiptPurchaseData);
									fixed (char* begin3 = readOnlySpan3)
									{
										managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
										receiptPurchaseData2 = ref managedSpanWrapper3;
										if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
										{
											readOnlySpan4 = MemoryExtensions.AsSpan(signature);
											fixed (char* begin4 = readOnlySpan4)
											{
												managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
												return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
											}
										}
										return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
									}
								}
								receiptPurchaseData2 = ref managedSpanWrapper3;
								if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
								{
									readOnlySpan4 = MemoryExtensions.AsSpan(signature);
									fixed (char* begin4 = readOnlySpan4)
									{
										managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
										return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
									}
								}
								return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
							}
						}
						currency2 = ref managedSpanWrapper2;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(receiptPurchaseData, ref managedSpanWrapper3))
						{
							readOnlySpan3 = MemoryExtensions.AsSpan(receiptPurchaseData);
							fixed (char* begin3 = readOnlySpan3)
							{
								managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
								receiptPurchaseData2 = ref managedSpanWrapper3;
								if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
								{
									readOnlySpan4 = MemoryExtensions.AsSpan(signature);
									fixed (char* begin4 = readOnlySpan4)
									{
										managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
										return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
									}
								}
								return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
							}
						}
						receiptPurchaseData2 = ref managedSpanWrapper3;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
						{
							readOnlySpan4 = MemoryExtensions.AsSpan(signature);
							fixed (char* begin4 = readOnlySpan4)
							{
								managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
								return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
							}
						}
						return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
					}
				}
				productId2 = ref managedSpanWrapper;
				amount2 = amount;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(currency, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(currency);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						currency2 = ref managedSpanWrapper2;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(receiptPurchaseData, ref managedSpanWrapper3))
						{
							readOnlySpan3 = MemoryExtensions.AsSpan(receiptPurchaseData);
							fixed (char* begin3 = readOnlySpan3)
							{
								managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
								receiptPurchaseData2 = ref managedSpanWrapper3;
								if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
								{
									readOnlySpan4 = MemoryExtensions.AsSpan(signature);
									fixed (char* begin4 = readOnlySpan4)
									{
										managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
										return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
									}
								}
								return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
							}
						}
						receiptPurchaseData2 = ref managedSpanWrapper3;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
						{
							readOnlySpan4 = MemoryExtensions.AsSpan(signature);
							fixed (char* begin4 = readOnlySpan4)
							{
								managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
								return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
							}
						}
						return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
					}
				}
				currency2 = ref managedSpanWrapper2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(receiptPurchaseData, ref managedSpanWrapper3))
				{
					readOnlySpan3 = MemoryExtensions.AsSpan(receiptPurchaseData);
					fixed (char* begin3 = readOnlySpan3)
					{
						managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
						receiptPurchaseData2 = ref managedSpanWrapper3;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
						{
							readOnlySpan4 = MemoryExtensions.AsSpan(signature);
							fixed (char* begin4 = readOnlySpan4)
							{
								managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
								return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
							}
						}
						return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
					}
				}
				receiptPurchaseData2 = ref managedSpanWrapper3;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(signature, ref managedSpanWrapper4))
				{
					readOnlySpan4 = MemoryExtensions.AsSpan(signature);
					fixed (char* begin4 = readOnlySpan4)
					{
						managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
						return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
					}
				}
				return Transaction_Injected(ref productId2, amount2, ref currency2, ref receiptPurchaseData2, ref managedSpanWrapper4, usingIAPService);
			}
			finally
			{
			}
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private unsafe static AnalyticsResult SendCustomEventName(string customEventName)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(customEventName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(customEventName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return SendCustomEventName_Injected(ref managedSpanWrapper);
					}
				}
				return SendCustomEventName_Injected(ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static AnalyticsResult SendCustomEvent(CustomEventData eventData)
		{
			return SendCustomEvent_Injected((eventData == null) ? ((IntPtr)0) : CustomEventData.BindingsMarshaller.ConvertToNative(eventData));
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		internal unsafe static AnalyticsResult IsCustomEventWithLimitEnabled(string customEventName)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(customEventName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(customEventName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return IsCustomEventWithLimitEnabled_Injected(ref managedSpanWrapper);
					}
				}
				return IsCustomEventWithLimitEnabled_Injected(ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		internal unsafe static AnalyticsResult EnableCustomEventWithLimit(string customEventName, bool enable)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(customEventName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(customEventName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return EnableCustomEventWithLimit_Injected(ref managedSpanWrapper, enable);
					}
				}
				return EnableCustomEventWithLimit_Injected(ref managedSpanWrapper, enable);
			}
			finally
			{
			}
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		internal unsafe static AnalyticsResult IsEventWithLimitEnabled(string eventName, int ver, string prefix)
		{
			//The blocks IL_0029, IL_0037, IL_0045, IL_0053, IL_0058 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0058 are reachable both inside and outside the pinned region starting at IL_0045. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0058 are reachable both inside and outside the pinned region starting at IL_0045. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper eventName2;
				int ver2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						eventName2 = ref managedSpanWrapper;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								return IsEventWithLimitEnabled_Injected(ref eventName2, ver2, ref managedSpanWrapper2);
							}
						}
						return IsEventWithLimitEnabled_Injected(ref eventName2, ver2, ref managedSpanWrapper2);
					}
				}
				eventName2 = ref managedSpanWrapper;
				ver2 = ver;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						return IsEventWithLimitEnabled_Injected(ref eventName2, ver2, ref managedSpanWrapper2);
					}
				}
				return IsEventWithLimitEnabled_Injected(ref eventName2, ver2, ref managedSpanWrapper2);
			}
			finally
			{
			}
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		internal unsafe static AnalyticsResult EnableEventWithLimit(string eventName, bool enable, int ver, string prefix)
		{
			//The blocks IL_0029, IL_0038, IL_0046, IL_0054, IL_0059 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper eventName2;
				bool enable2;
				int ver2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						eventName2 = ref managedSpanWrapper;
						enable2 = enable;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								return EnableEventWithLimit_Injected(ref eventName2, enable2, ver2, ref managedSpanWrapper2);
							}
						}
						return EnableEventWithLimit_Injected(ref eventName2, enable2, ver2, ref managedSpanWrapper2);
					}
				}
				eventName2 = ref managedSpanWrapper;
				enable2 = enable;
				ver2 = ver;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						return EnableEventWithLimit_Injected(ref eventName2, enable2, ver2, ref managedSpanWrapper2);
					}
				}
				return EnableEventWithLimit_Injected(ref eventName2, enable2, ver2, ref managedSpanWrapper2);
			}
			finally
			{
			}
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		internal unsafe static AnalyticsResult RegisterEventWithLimit(string eventName, int maxEventPerHour, int maxItems, string vendorKey, int ver, string prefix, string assemblyInfo, bool notifyServer)
		{
			//The blocks IL_0029, IL_0038, IL_0046, IL_0054, IL_0059, IL_0069, IL_0079, IL_0087, IL_008c, IL_009a, IL_00aa, IL_00b8, IL_00bd are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0059, IL_0069, IL_0079, IL_0087, IL_008c, IL_009a, IL_00aa, IL_00b8, IL_00bd are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008c, IL_009a, IL_00aa, IL_00b8, IL_00bd are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008c, IL_009a, IL_00aa, IL_00b8, IL_00bd are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0059, IL_0069, IL_0079, IL_0087, IL_008c, IL_009a, IL_00aa, IL_00b8, IL_00bd are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008c, IL_009a, IL_00aa, IL_00b8, IL_00bd are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008c, IL_009a, IL_00aa, IL_00b8, IL_00bd are reachable both inside and outside the pinned region starting at IL_0079. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_00bd are reachable both inside and outside the pinned region starting at IL_00aa. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper eventName2;
				int maxEventPerHour2;
				int maxItems2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				ref ManagedSpanWrapper vendorKey2;
				int ver2;
				ManagedSpanWrapper managedSpanWrapper3 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan3;
				ref ManagedSpanWrapper prefix2;
				ManagedSpanWrapper managedSpanWrapper4 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan4;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						eventName2 = ref managedSpanWrapper;
						maxEventPerHour2 = maxEventPerHour;
						maxItems2 = maxItems;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(vendorKey, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(vendorKey);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								vendorKey2 = ref managedSpanWrapper2;
								ver2 = ver;
								if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
								{
									readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
									fixed (char* begin3 = readOnlySpan3)
									{
										managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
										prefix2 = ref managedSpanWrapper3;
										if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
										{
											readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
											fixed (char* begin4 = readOnlySpan4)
											{
												managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
												return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
											}
										}
										return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
									}
								}
								prefix2 = ref managedSpanWrapper3;
								if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
								{
									readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
									fixed (char* begin4 = readOnlySpan4)
									{
										managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
										return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
									}
								}
								return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
							}
						}
						vendorKey2 = ref managedSpanWrapper2;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
						{
							readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin3 = readOnlySpan3)
							{
								managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
								prefix2 = ref managedSpanWrapper3;
								if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
								{
									readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
									fixed (char* begin4 = readOnlySpan4)
									{
										managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
										return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
									}
								}
								return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
							}
						}
						prefix2 = ref managedSpanWrapper3;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
						{
							readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
							fixed (char* begin4 = readOnlySpan4)
							{
								managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
								return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
							}
						}
						return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
					}
				}
				eventName2 = ref managedSpanWrapper;
				maxEventPerHour2 = maxEventPerHour;
				maxItems2 = maxItems;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(vendorKey, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(vendorKey);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						vendorKey2 = ref managedSpanWrapper2;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
						{
							readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin3 = readOnlySpan3)
							{
								managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
								prefix2 = ref managedSpanWrapper3;
								if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
								{
									readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
									fixed (char* begin4 = readOnlySpan4)
									{
										managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
										return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
									}
								}
								return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
							}
						}
						prefix2 = ref managedSpanWrapper3;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
						{
							readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
							fixed (char* begin4 = readOnlySpan4)
							{
								managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
								return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
							}
						}
						return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
					}
				}
				vendorKey2 = ref managedSpanWrapper2;
				ver2 = ver;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
				{
					readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
					fixed (char* begin3 = readOnlySpan3)
					{
						managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
						prefix2 = ref managedSpanWrapper3;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
						{
							readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
							fixed (char* begin4 = readOnlySpan4)
							{
								managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
								return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
							}
						}
						return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
					}
				}
				prefix2 = ref managedSpanWrapper3;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper4))
				{
					readOnlySpan4 = MemoryExtensions.AsSpan(assemblyInfo);
					fixed (char* begin4 = readOnlySpan4)
					{
						managedSpanWrapper4 = new ManagedSpanWrapper(begin4, readOnlySpan4.Length);
						return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
					}
				}
				return RegisterEventWithLimit_Injected(ref eventName2, maxEventPerHour2, maxItems2, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper4, notifyServer);
			}
			finally
			{
			}
		}

		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		internal unsafe static AnalyticsResult RegisterEventsWithLimit(string[] eventName, int maxEventPerHour, int maxItems, string vendorKey, int ver, string prefix, string assemblyInfo, bool notifyServer)
		{
			//The blocks IL_002c, IL_003c, IL_004b, IL_0059, IL_005e, IL_006c, IL_007c, IL_008a, IL_008f are reachable both inside and outside the pinned region starting at IL_001b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_005e, IL_006c, IL_007c, IL_008a, IL_008f are reachable both inside and outside the pinned region starting at IL_004b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008f are reachable both inside and outside the pinned region starting at IL_007c. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008f are reachable both inside and outside the pinned region starting at IL_007c. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_005e, IL_006c, IL_007c, IL_008a, IL_008f are reachable both inside and outside the pinned region starting at IL_004b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008f are reachable both inside and outside the pinned region starting at IL_007c. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_008f are reachable both inside and outside the pinned region starting at IL_007c. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper vendorKey2;
				int ver2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				ref ManagedSpanWrapper prefix2;
				ManagedSpanWrapper managedSpanWrapper3 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan3;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(vendorKey, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(vendorKey);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						vendorKey2 = ref managedSpanWrapper;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								prefix2 = ref managedSpanWrapper2;
								if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper3))
								{
									readOnlySpan3 = MemoryExtensions.AsSpan(assemblyInfo);
									fixed (char* begin3 = readOnlySpan3)
									{
										managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
										return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
									}
								}
								return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
							}
						}
						prefix2 = ref managedSpanWrapper2;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper3))
						{
							readOnlySpan3 = MemoryExtensions.AsSpan(assemblyInfo);
							fixed (char* begin3 = readOnlySpan3)
							{
								managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
								return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
							}
						}
						return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
					}
				}
				vendorKey2 = ref managedSpanWrapper;
				ver2 = ver;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						prefix2 = ref managedSpanWrapper2;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper3))
						{
							readOnlySpan3 = MemoryExtensions.AsSpan(assemblyInfo);
							fixed (char* begin3 = readOnlySpan3)
							{
								managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
								return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
							}
						}
						return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
					}
				}
				prefix2 = ref managedSpanWrapper2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(assemblyInfo, ref managedSpanWrapper3))
				{
					readOnlySpan3 = MemoryExtensions.AsSpan(assemblyInfo);
					fixed (char* begin3 = readOnlySpan3)
					{
						managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
						return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
					}
				}
				return RegisterEventsWithLimit_Injected(eventName, maxEventPerHour, maxItems, ref vendorKey2, ver2, ref prefix2, ref managedSpanWrapper3, notifyServer);
			}
			finally
			{
			}
		}

		[ThreadSafe]
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		internal unsafe static AnalyticsResult SendEventWithLimit(string eventName, object parameters, int ver, string prefix)
		{
			//The blocks IL_0029, IL_0038, IL_0046, IL_0054, IL_0059 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper eventName2;
				object parameters2;
				int ver2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						eventName2 = ref managedSpanWrapper;
						parameters2 = parameters;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								return SendEventWithLimit_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
							}
						}
						return SendEventWithLimit_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
					}
				}
				eventName2 = ref managedSpanWrapper;
				parameters2 = parameters;
				ver2 = ver;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						return SendEventWithLimit_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
					}
				}
				return SendEventWithLimit_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
			}
			finally
			{
			}
		}

		[ThreadSafe]
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		internal unsafe static AnalyticsResult SetEventWithLimitEndPoint(string eventName, string endPoint, int ver, string prefix)
		{
			//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057, IL_0065, IL_0074, IL_0082, IL_0087 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057, IL_0065, IL_0074, IL_0082, IL_0087 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0087 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0087 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057, IL_0065, IL_0074, IL_0082, IL_0087 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0087 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0087 are reachable both inside and outside the pinned region starting at IL_0074. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper eventName2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				ref ManagedSpanWrapper endPoint2;
				int ver2;
				ManagedSpanWrapper managedSpanWrapper3 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan3;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						eventName2 = ref managedSpanWrapper;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(endPoint, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(endPoint);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								endPoint2 = ref managedSpanWrapper2;
								ver2 = ver;
								if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
								{
									readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
									fixed (char* begin3 = readOnlySpan3)
									{
										managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
										return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
									}
								}
								return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
							}
						}
						endPoint2 = ref managedSpanWrapper2;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
						{
							readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin3 = readOnlySpan3)
							{
								managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
								return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
							}
						}
						return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
					}
				}
				eventName2 = ref managedSpanWrapper;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(endPoint, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(endPoint);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						endPoint2 = ref managedSpanWrapper2;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
						{
							readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin3 = readOnlySpan3)
							{
								managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
								return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
							}
						}
						return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
					}
				}
				endPoint2 = ref managedSpanWrapper2;
				ver2 = ver;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper3))
				{
					readOnlySpan3 = MemoryExtensions.AsSpan(prefix);
					fixed (char* begin3 = readOnlySpan3)
					{
						managedSpanWrapper3 = new ManagedSpanWrapper(begin3, readOnlySpan3.Length);
						return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
					}
				}
				return SetEventWithLimitEndPoint_Injected(ref eventName2, ref endPoint2, ver2, ref managedSpanWrapper3);
			}
			finally
			{
			}
		}

		[ThreadSafe]
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		internal unsafe static AnalyticsResult SetEventWithLimitPriority(string eventName, AnalyticsEventPriority eventPriority, int ver, string prefix)
		{
			//The blocks IL_0029, IL_0038, IL_0046, IL_0054, IL_0059 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper eventName2;
				AnalyticsEventPriority eventPriority2;
				int ver2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						eventName2 = ref managedSpanWrapper;
						eventPriority2 = eventPriority;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								return SetEventWithLimitPriority_Injected(ref eventName2, eventPriority2, ver2, ref managedSpanWrapper2);
							}
						}
						return SetEventWithLimitPriority_Injected(ref eventName2, eventPriority2, ver2, ref managedSpanWrapper2);
					}
				}
				eventName2 = ref managedSpanWrapper;
				eventPriority2 = eventPriority;
				ver2 = ver;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						return SetEventWithLimitPriority_Injected(ref eventName2, eventPriority2, ver2, ref managedSpanWrapper2);
					}
				}
				return SetEventWithLimitPriority_Injected(ref eventName2, eventPriority2, ver2, ref managedSpanWrapper2);
			}
			finally
			{
			}
		}

		[ThreadSafe]
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		internal unsafe static AnalyticsResult QueueEvent(string eventName, object parameters, int ver, string prefix)
		{
			//The blocks IL_0029, IL_0038, IL_0046, IL_0054, IL_0059 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0059 are reachable both inside and outside the pinned region starting at IL_0046. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper eventName2;
				object parameters2;
				int ver2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(eventName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(eventName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						eventName2 = ref managedSpanWrapper;
						parameters2 = parameters;
						ver2 = ver;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								return QueueEvent_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
							}
						}
						return QueueEvent_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
					}
				}
				eventName2 = ref managedSpanWrapper;
				parameters2 = parameters;
				ver2 = ver;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(prefix, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(prefix);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						return QueueEvent_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
					}
				}
				return QueueEvent_Injected(ref eventName2, parameters2, ver2, ref managedSpanWrapper2);
			}
			finally
			{
			}
		}

		public static AnalyticsResult FlushEvents()
		{
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return (!FlushArchivedEvents()) ? AnalyticsResult.NotInitialized : AnalyticsResult.Ok;
		}

		[Obsolete("SetUserId is no longer supported", true)]
		public static AnalyticsResult SetUserId(string userId)
		{
			if (string.IsNullOrEmpty(userId))
			{
				throw new ArgumentException("Cannot set userId to an empty or null string");
			}
			return AnalyticsResult.InvalidData;
		}

		[Obsolete("SetUserGender is no longer supported", true)]
		public static AnalyticsResult SetUserGender(Gender gender)
		{
			return AnalyticsResult.InvalidData;
		}

		[Obsolete("SetUserBirthYear is no longer supported", true)]
		public static AnalyticsResult SetUserBirthYear(int birthYear)
		{
			return AnalyticsResult.InvalidData;
		}

		[Obsolete("SendUserInfoEvent is no longer supported", true)]
		private static AnalyticsResult SendUserInfoEvent(object param)
		{
			return AnalyticsResult.InvalidData;
		}

		public static AnalyticsResult Transaction(string productId, decimal amount, string currency)
		{
			return Transaction(productId, amount, currency, null, null, usingIAPService: false);
		}

		public static AnalyticsResult Transaction(string productId, decimal amount, string currency, string receiptPurchaseData, string signature)
		{
			return Transaction(productId, amount, currency, receiptPurchaseData, signature, usingIAPService: false);
		}

		public static AnalyticsResult Transaction(string productId, decimal amount, string currency, string receiptPurchaseData, string signature, bool usingIAPService)
		{
			if (string.IsNullOrEmpty(productId))
			{
				throw new ArgumentException("Cannot set productId to an empty or null string");
			}
			if (string.IsNullOrEmpty(currency))
			{
				throw new ArgumentException("Cannot set currency to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			if (receiptPurchaseData == null)
			{
				receiptPurchaseData = string.Empty;
			}
			if (signature == null)
			{
				signature = string.Empty;
			}
			return Transaction(productId, Convert.ToDouble(amount), currency, receiptPurchaseData, signature, usingIAPService);
		}

		public static AnalyticsResult CustomEvent(string customEventName)
		{
			if (string.IsNullOrEmpty(customEventName))
			{
				throw new ArgumentException("Cannot set custom event name to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return SendCustomEventName(customEventName);
		}

		public static AnalyticsResult CustomEvent(string customEventName, Vector3 position)
		{
			if (string.IsNullOrEmpty(customEventName))
			{
				throw new ArgumentException("Cannot set custom event name to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			CustomEventData customEventData = new CustomEventData(customEventName);
			customEventData.AddDouble("x", (double)Convert.ToDecimal(position.x));
			customEventData.AddDouble("y", (double)Convert.ToDecimal(position.y));
			customEventData.AddDouble("z", (double)Convert.ToDecimal(position.z));
			AnalyticsResult result = SendCustomEvent(customEventData);
			customEventData.Dispose();
			return result;
		}

		public static AnalyticsResult CustomEvent(string customEventName, IDictionary<string, object> eventData)
		{
			if (string.IsNullOrEmpty(customEventName))
			{
				throw new ArgumentException("Cannot set custom event name to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			if (eventData == null)
			{
				return SendCustomEventName(customEventName);
			}
			CustomEventData customEventData = new CustomEventData(customEventName);
			AnalyticsResult result = AnalyticsResult.InvalidData;
			try
			{
				customEventData.AddDictionary(eventData);
				result = SendCustomEvent(customEventData);
			}
			finally
			{
				customEventData.Dispose();
			}
			return result;
		}

		public static AnalyticsResult EnableCustomEvent(string customEventName, bool enabled)
		{
			if (string.IsNullOrEmpty(customEventName))
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return EnableCustomEventWithLimit(customEventName, enabled);
		}

		public static AnalyticsResult IsCustomEventEnabled(string customEventName)
		{
			if (string.IsNullOrEmpty(customEventName))
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return IsCustomEventWithLimitEnabled(customEventName);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static AnalyticsResult RegisterEvent(string eventName, int maxEventPerHour, int maxItems, string vendorKey = "", string prefix = "")
		{
			string empty = string.Empty;
			empty = Assembly.GetCallingAssembly().FullName;
			return RegisterEvent(eventName, maxEventPerHour, maxItems, vendorKey, 1, prefix, empty);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static AnalyticsResult RegisterEvent(string eventName, int maxEventPerHour, int maxItems, string vendorKey, int ver, string prefix = "")
		{
			string empty = string.Empty;
			empty = Assembly.GetCallingAssembly().FullName;
			return RegisterEvent(eventName, maxEventPerHour, maxItems, vendorKey, ver, prefix, empty);
		}

		private static AnalyticsResult RegisterEvent(string eventName, int maxEventPerHour, int maxItems, string vendorKey, int ver, string prefix, string assemblyInfo)
		{
			if (string.IsNullOrEmpty(eventName))
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return RegisterEventWithLimit(eventName, maxEventPerHour, maxItems, vendorKey, ver, prefix, assemblyInfo, notifyServer: true);
		}

		public static AnalyticsResult SendEvent(string eventName, object parameters, int ver = 1, string prefix = "")
		{
			if (string.IsNullOrEmpty(eventName))
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			if (parameters == null)
			{
				throw new ArgumentException("Cannot set parameters to null");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return SendEventWithLimit(eventName, parameters, ver, prefix);
		}

		public static AnalyticsResult SetEventEndPoint(string eventName, string endPoint, int ver = 1, string prefix = "")
		{
			if (string.IsNullOrEmpty(eventName))
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			if (endPoint == null)
			{
				throw new ArgumentException("Cannot set parameters to null");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return SetEventWithLimitEndPoint(eventName, endPoint, ver, prefix);
		}

		public static AnalyticsResult SetEventPriority(string eventName, AnalyticsEventPriority eventPriority, int ver = 1, string prefix = "")
		{
			if (string.IsNullOrEmpty(eventName))
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return SetEventWithLimitPriority(eventName, eventPriority, ver, prefix);
		}

		public static AnalyticsResult EnableEvent(string eventName, bool enabled, int ver = 1, string prefix = "")
		{
			if (string.IsNullOrEmpty(eventName))
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return EnableEventWithLimit(eventName, enabled, ver, prefix);
		}

		public static AnalyticsResult IsEventEnabled(string eventName, int ver = 1, string prefix = "")
		{
			if (string.IsNullOrEmpty(eventName))
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			if (!IsInitialized())
			{
				return AnalyticsResult.NotInitialized;
			}
			return IsEventWithLimitEnabled(eventName, ver, prefix);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_eventUrlInternal_Injected(out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_configUrlInternal_Injected(out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_dashboardUrlInternal_Injected(out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult Transaction_Injected(ref ManagedSpanWrapper productId, double amount, ref ManagedSpanWrapper currency, ref ManagedSpanWrapper receiptPurchaseData, ref ManagedSpanWrapper signature, bool usingIAPService);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult SendCustomEventName_Injected(ref ManagedSpanWrapper customEventName);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult SendCustomEvent_Injected(IntPtr eventData);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult IsCustomEventWithLimitEnabled_Injected(ref ManagedSpanWrapper customEventName);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult EnableCustomEventWithLimit_Injected(ref ManagedSpanWrapper customEventName, bool enable);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult IsEventWithLimitEnabled_Injected(ref ManagedSpanWrapper eventName, int ver, ref ManagedSpanWrapper prefix);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult EnableEventWithLimit_Injected(ref ManagedSpanWrapper eventName, bool enable, int ver, ref ManagedSpanWrapper prefix);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult RegisterEventWithLimit_Injected(ref ManagedSpanWrapper eventName, int maxEventPerHour, int maxItems, ref ManagedSpanWrapper vendorKey, int ver, ref ManagedSpanWrapper prefix, ref ManagedSpanWrapper assemblyInfo, bool notifyServer);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult RegisterEventsWithLimit_Injected(string[] eventName, int maxEventPerHour, int maxItems, ref ManagedSpanWrapper vendorKey, int ver, ref ManagedSpanWrapper prefix, ref ManagedSpanWrapper assemblyInfo, bool notifyServer);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult SendEventWithLimit_Injected(ref ManagedSpanWrapper eventName, object parameters, int ver, ref ManagedSpanWrapper prefix);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult SetEventWithLimitEndPoint_Injected(ref ManagedSpanWrapper eventName, ref ManagedSpanWrapper endPoint, int ver, ref ManagedSpanWrapper prefix);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult SetEventWithLimitPriority_Injected(ref ManagedSpanWrapper eventName, AnalyticsEventPriority eventPriority, int ver, ref ManagedSpanWrapper prefix);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult QueueEvent_Injected(ref ManagedSpanWrapper eventName, object parameters, int ver, ref ManagedSpanWrapper prefix);
	}
	public enum Gender
	{
		Male,
		Female,
		Unknown
	}
	[Flags]
	public enum AnalyticsEventPriority
	{
		FlushQueueFlag = 1,
		CacheImmediatelyFlag = 2,
		AllowInStopModeFlag = 4,
		SendImmediateFlag = 8,
		NoCachingFlag = 0x10,
		NoRetryFlag = 0x20,
		NormalPriorityEvent = 0,
		NormalPriorityEvent_WithCaching = 2,
		NormalPriorityEvent_NoRetryNoCaching = 0x30,
		HighPriorityEvent = 1,
		HighPriorityEvent_InStopMode = 5,
		HighestPriorityEvent = 9,
		HighestPriorityEvent_NoRetryNoCaching = 0x31
	}
}
