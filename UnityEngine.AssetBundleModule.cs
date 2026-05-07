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
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngineInternal;

[assembly: InternalsVisibleTo("UnityEngine.SubsystemsModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
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
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.2D")]
[assembly: InternalsVisibleTo("Unity.DeploymentTests.Services")]
[assembly: InternalsVisibleTo("Unity.Burst.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.XRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VFXModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestWWWModule")]
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestTextureModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityTestProtocolModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityCurlModule")]
[assembly: InternalsVisibleTo("UnityEngine.UmbraModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
[assembly: InternalsVisibleTo("UnityEngine.SwitchModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4Module")]
[assembly: InternalsVisibleTo("Unity.Burst")]
[assembly: InternalsVisibleTo("Unity.Automation")]
[assembly: InternalsVisibleTo("UnityEngine.TestRunner")]
[assembly: InternalsVisibleTo("UnityEngine.Purchasing")]
[assembly: InternalsVisibleTo("UnityEngine.Advertisements")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS4VRModule")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.013")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.012")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.009")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.008")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.014")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.007")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.001")]
[assembly: InternalsVisibleTo("UnityEngine.Core.Runtime.Tests")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.006")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.015")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.017")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: InternalsVisibleTo("Unity.Subsystem.Registration")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.016")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.023")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.022")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.021")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.020")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.019")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.018")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.024")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainPhysicsModule")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubstanceModule")]
[assembly: InternalsVisibleTo("Assembly-CSharp-Editor-testable")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.AccessibilityModule")]
[assembly: InternalsVisibleTo("UnityEngine.ARModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("UnityEngine.GIModule")]
[assembly: InternalsVisibleTo("UnityEngine.StreamingModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteMaskModule")]
[assembly: InternalsVisibleTo("UnityEngine.TilemapModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteShapeModule")]
[assembly: InternalsVisibleTo("UnityEngine.ShaderVariantAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.ScreenCaptureModule")]
[assembly: InternalsVisibleTo("UnityEngine.RuntimeInitializeOnLoadManagerInitializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.PropertiesModule")]
[assembly: InternalsVisibleTo("UnityEngine.Physics2DModule")]
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: InternalsVisibleTo("UnityEngine.ParticleSystemModule")]
[assembly: InternalsVisibleTo("UnityEngine.NVIDIAModule")]
[assembly: InternalsVisibleTo("UnityEngine.MultiplayerModule")]
[assembly: InternalsVisibleTo("UnityEngine.MarshallingModule")]
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.InsightsModule")]
[assembly: InternalsVisibleTo("UnityEngine.ImageConversionModule")]
[assembly: InternalsVisibleTo("UnityEngine.LocalizationModule")]
[assembly: InternalsVisibleTo("UnityEngine.GraphicsStateCollectionSerializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.GridModule")]
[assembly: InternalsVisibleTo("UnityEngine.HierarchyCoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextRenderingModule")]
[assembly: InternalsVisibleTo("UnityEngine.GameCenterModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreFontEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreTextEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.IMGUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputForUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConsentModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputLegacyModule")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine
{
	public enum AssetBundleLoadResult
	{
		Success,
		Cancelled,
		NotMatchingCrc,
		FailedCache,
		NotValidAssetBundle,
		NoSerializedData,
		NotCompatible,
		AlreadyLoaded,
		FailedRead,
		FailedDecompression,
		FailedWrite,
		FailedDeleteRecompressionTarget,
		RecompressionTargetIsLoaded,
		RecompressionTargetExistsButNotArchive
	}
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadAssetUtility.h")]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleUtility.h")]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleSaveAndLoadHelper.h")]
	[NativeHeader("AssetBundleScriptingClasses.h")]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromManagedStreamAsyncOperation.h")]
	[NativeHeader("Runtime/Scripting/ScriptingExportUtility.h")]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadAssetOperation.h")]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromMemoryAsyncOperation.h")]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromFileAsyncOperation.h")]
	[NativeHeader("Runtime/Scripting/ScriptingUtility.h")]
	[ExcludeFromPreset]
	public class AssetBundle : Object
	{
		[Obsolete("mainAsset has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
		public Object mainAsset => returnMainAsset(this);

		public bool isStreamedSceneAssetBundle
		{
			[NativeMethod("GetIsStreamedSceneAssetBundle")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isStreamedSceneAssetBundle_Injected(intPtr);
			}
		}

		public static uint memoryBudgetKB
		{
			get
			{
				return AssetBundleLoadingCache.memoryBudgetKB;
			}
			set
			{
				AssetBundleLoadingCache.memoryBudgetKB = value;
			}
		}

		private AssetBundle()
		{
		}

		[FreeFunction("LoadMainObjectFromAssetBundle", true)]
		internal static Object returnMainAsset([NotNull] AssetBundle bundle)
		{
			if ((object)bundle == null)
			{
				ThrowHelper.ThrowArgumentNullException(bundle, "bundle");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(bundle);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(bundle, "bundle");
			}
			return Unmarshal.UnmarshalUnityObject<Object>(returnMainAsset_Injected(intPtr));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("UnloadAllAssetBundles")]
		public static extern void UnloadAllAssetBundles(bool unloadAllObjects);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("GetAllAssetBundles")]
		internal static extern AssetBundle[] GetAllLoadedAssetBundles_Native();

		public static IEnumerable<AssetBundle> GetAllLoadedAssetBundles()
		{
			return GetAllLoadedAssetBundles_Native();
		}

		[FreeFunction("LoadFromFileAsync")]
		internal unsafe static AssetBundleCreateRequest LoadFromFileAsync_Internal(string path, uint crc, ulong offset)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			IntPtr intPtr = default(IntPtr);
			AssetBundleCreateRequest result;
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(path, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(path);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						intPtr = LoadFromFileAsync_Internal_Injected(ref managedSpanWrapper, crc, offset);
					}
				}
				else
				{
					intPtr = LoadFromFileAsync_Internal_Injected(ref managedSpanWrapper, crc, offset);
				}
			}
			finally
			{
				IntPtr intPtr2 = intPtr;
				result = ((intPtr2 == (IntPtr)0) ? null : AssetBundleCreateRequest.BindingsMarshaller.ConvertToManaged(intPtr2));
			}
			return result;
		}

		public static AssetBundleCreateRequest LoadFromFileAsync(string path)
		{
			return LoadFromFileAsync_Internal(path, 0u, 0uL);
		}

		public static AssetBundleCreateRequest LoadFromFileAsync(string path, uint crc)
		{
			return LoadFromFileAsync_Internal(path, crc, 0uL);
		}

		public static AssetBundleCreateRequest LoadFromFileAsync(string path, uint crc, ulong offset)
		{
			return LoadFromFileAsync_Internal(path, crc, offset);
		}

		[FreeFunction("LoadFromFile")]
		internal unsafe static AssetBundle LoadFromFile_Internal(string path, uint crc, ulong offset)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			IntPtr gcHandlePtr = default(IntPtr);
			AssetBundle result;
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(path, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(path);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						gcHandlePtr = LoadFromFile_Internal_Injected(ref managedSpanWrapper, crc, offset);
					}
				}
				else
				{
					gcHandlePtr = LoadFromFile_Internal_Injected(ref managedSpanWrapper, crc, offset);
				}
			}
			finally
			{
				result = Unmarshal.UnmarshalUnityObject<AssetBundle>(gcHandlePtr);
			}
			return result;
		}

		public static AssetBundle LoadFromFile(string path)
		{
			return LoadFromFile_Internal(path, 0u, 0uL);
		}

		public static AssetBundle LoadFromFile(string path, uint crc)
		{
			return LoadFromFile_Internal(path, crc, 0uL);
		}

		public static AssetBundle LoadFromFile(string path, uint crc, ulong offset)
		{
			return LoadFromFile_Internal(path, crc, offset);
		}

		[FreeFunction("LoadFromMemoryAsync")]
		internal unsafe static AssetBundleCreateRequest LoadFromMemoryAsync_Internal(byte[] binary, uint crc)
		{
			Span<byte> span = new Span<byte>(binary);
			AssetBundleCreateRequest result;
			fixed (byte* begin = span)
			{
				ManagedSpanWrapper binary2 = new ManagedSpanWrapper(begin, span.Length);
				IntPtr intPtr = LoadFromMemoryAsync_Internal_Injected(ref binary2, crc);
				result = ((intPtr == (IntPtr)0) ? null : AssetBundleCreateRequest.BindingsMarshaller.ConvertToManaged(intPtr));
			}
			return result;
		}

		public static AssetBundleCreateRequest LoadFromMemoryAsync(byte[] binary)
		{
			return LoadFromMemoryAsync_Internal(binary, 0u);
		}

		public static AssetBundleCreateRequest LoadFromMemoryAsync(byte[] binary, uint crc)
		{
			return LoadFromMemoryAsync_Internal(binary, crc);
		}

		[FreeFunction("LoadFromMemory")]
		internal unsafe static AssetBundle LoadFromMemory_Internal(byte[] binary, uint crc)
		{
			Span<byte> span = new Span<byte>(binary);
			AssetBundle result;
			fixed (byte* begin = span)
			{
				ManagedSpanWrapper binary2 = new ManagedSpanWrapper(begin, span.Length);
				result = Unmarshal.UnmarshalUnityObject<AssetBundle>(LoadFromMemory_Internal_Injected(ref binary2, crc));
			}
			return result;
		}

		public static AssetBundle LoadFromMemory(byte[] binary)
		{
			return LoadFromMemory_Internal(binary, 0u);
		}

		public static AssetBundle LoadFromMemory(byte[] binary, uint crc)
		{
			return LoadFromMemory_Internal(binary, crc);
		}

		internal static void ValidateLoadFromStream(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("ManagedStream object must be non-null", "stream");
			}
			if (!stream.CanRead)
			{
				throw new ArgumentException("ManagedStream object must be readable (stream.CanRead must return true)", "stream");
			}
			if (!stream.CanSeek)
			{
				throw new ArgumentException("ManagedStream object must be seekable (stream.CanSeek must return true)", "stream");
			}
		}

		public static AssetBundleCreateRequest LoadFromStreamAsync(Stream stream, uint crc, uint managedReadBufferSize)
		{
			ValidateLoadFromStream(stream);
			return LoadFromStreamAsyncInternal(stream, crc, managedReadBufferSize);
		}

		public static AssetBundleCreateRequest LoadFromStreamAsync(Stream stream, uint crc)
		{
			ValidateLoadFromStream(stream);
			return LoadFromStreamAsyncInternal(stream, crc, 0u);
		}

		public static AssetBundleCreateRequest LoadFromStreamAsync(Stream stream)
		{
			ValidateLoadFromStream(stream);
			return LoadFromStreamAsyncInternal(stream, 0u, 0u);
		}

		public static AssetBundle LoadFromStream(Stream stream, uint crc, uint managedReadBufferSize)
		{
			ValidateLoadFromStream(stream);
			return LoadFromStreamInternal(stream, crc, managedReadBufferSize);
		}

		public static AssetBundle LoadFromStream(Stream stream, uint crc)
		{
			ValidateLoadFromStream(stream);
			return LoadFromStreamInternal(stream, crc, 0u);
		}

		public static AssetBundle LoadFromStream(Stream stream)
		{
			ValidateLoadFromStream(stream);
			return LoadFromStreamInternal(stream, 0u, 0u);
		}

		[FreeFunction("LoadFromStreamAsyncInternal")]
		internal static AssetBundleCreateRequest LoadFromStreamAsyncInternal(Stream stream, uint crc, uint managedReadBufferSize)
		{
			IntPtr intPtr = LoadFromStreamAsyncInternal_Injected(stream, crc, managedReadBufferSize);
			return (intPtr == (IntPtr)0) ? null : AssetBundleCreateRequest.BindingsMarshaller.ConvertToManaged(intPtr);
		}

		[FreeFunction("LoadFromStreamInternal")]
		internal static AssetBundle LoadFromStreamInternal(Stream stream, uint crc, uint managedReadBufferSize)
		{
			return Unmarshal.UnmarshalUnityObject<AssetBundle>(LoadFromStreamInternal_Injected(stream, crc, managedReadBufferSize));
		}

		[NativeMethod("Contains")]
		public unsafe bool Contains(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
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
						return Contains_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return Contains_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Method Load has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAsset instead and check the documentation for details.", true)]
		public Object Load(string name)
		{
			return null;
		}

		[Obsolete("Method Load has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAsset instead and check the documentation for details.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Object Load<T>(string name)
		{
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Method Load has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAsset instead and check the documentation for details.", true)]
		private Object Load(string name, Type type)
		{
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Method LoadAsync has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAssetAsync instead and check the documentation for details.", true)]
		private AssetBundleRequest LoadAsync(string name, Type type)
		{
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Method LoadAll has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAllAssets instead and check the documentation for details.", true)]
		private Object[] LoadAll(Type type)
		{
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Method LoadAll has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAllAssets instead and check the documentation for details.", true)]
		public Object[] LoadAll()
		{
			return null;
		}

		[Obsolete("Method LoadAll has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAllAssets instead and check the documentation for details.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public T[] LoadAll<T>() where T : Object
		{
			return null;
		}

		public Object LoadAsset(string name)
		{
			return LoadAsset(name, typeof(Object));
		}

		public T LoadAsset<T>(string name) where T : Object
		{
			return (T)LoadAsset(name, typeof(T));
		}

		[TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
		public Object LoadAsset(string name, Type type)
		{
			if (name == null)
			{
				throw new NullReferenceException("The input asset name cannot be null.");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException("The input asset name cannot be empty.");
			}
			if (type == null)
			{
				throw new NullReferenceException("The input type cannot be null.");
			}
			return LoadAsset_Internal(name, type);
		}

		[TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
		[NativeMethod("LoadAsset_Internal")]
		[NativeThrows]
		private unsafe Object LoadAsset_Internal(string name, Type type)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			IntPtr gcHandlePtr = default(IntPtr);
			Object result;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
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
						gcHandlePtr = LoadAsset_Internal_Injected(intPtr, ref managedSpanWrapper, type);
					}
				}
				else
				{
					gcHandlePtr = LoadAsset_Internal_Injected(intPtr, ref managedSpanWrapper, type);
				}
			}
			finally
			{
				result = Unmarshal.UnmarshalUnityObject<Object>(gcHandlePtr);
			}
			return result;
		}

		public AssetBundleRequest LoadAssetAsync(string name)
		{
			return LoadAssetAsync(name, typeof(Object));
		}

		public AssetBundleRequest LoadAssetAsync<T>(string name)
		{
			return LoadAssetAsync(name, typeof(T));
		}

		public AssetBundleRequest LoadAssetAsync(string name, Type type)
		{
			if (name == null)
			{
				throw new NullReferenceException("The input asset name cannot be null.");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException("The input asset name cannot be empty.");
			}
			if (type == null)
			{
				throw new NullReferenceException("The input type cannot be null.");
			}
			return LoadAssetAsync_Internal(name, type);
		}

		public Object[] LoadAssetWithSubAssets(string name)
		{
			return LoadAssetWithSubAssets(name, typeof(Object));
		}

		internal static T[] ConvertObjects<T>(Object[] rawObjects) where T : Object
		{
			if (rawObjects == null)
			{
				return null;
			}
			T[] array = new T[rawObjects.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (T)rawObjects[i];
			}
			return array;
		}

		public T[] LoadAssetWithSubAssets<T>(string name) where T : Object
		{
			return ConvertObjects<T>(LoadAssetWithSubAssets(name, typeof(T)));
		}

		public Object[] LoadAssetWithSubAssets(string name, Type type)
		{
			if (name == null)
			{
				throw new NullReferenceException("The input asset name cannot be null.");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException("The input asset name cannot be empty.");
			}
			if (type == null)
			{
				throw new NullReferenceException("The input type cannot be null.");
			}
			return LoadAssetWithSubAssets_Internal(name, type);
		}

		public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name)
		{
			return LoadAssetWithSubAssetsAsync(name, typeof(Object));
		}

		public AssetBundleRequest LoadAssetWithSubAssetsAsync<T>(string name)
		{
			return LoadAssetWithSubAssetsAsync(name, typeof(T));
		}

		public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name, Type type)
		{
			if (name == null)
			{
				throw new NullReferenceException("The input asset name cannot be null.");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException("The input asset name cannot be empty.");
			}
			if (type == null)
			{
				throw new NullReferenceException("The input type cannot be null.");
			}
			return LoadAssetWithSubAssetsAsync_Internal(name, type);
		}

		public Object[] LoadAllAssets()
		{
			return LoadAllAssets(typeof(Object));
		}

		public T[] LoadAllAssets<T>() where T : Object
		{
			return ConvertObjects<T>(LoadAllAssets(typeof(T)));
		}

		public Object[] LoadAllAssets(Type type)
		{
			if (type == null)
			{
				throw new NullReferenceException("The input type cannot be null.");
			}
			return LoadAssetWithSubAssets_Internal("", type);
		}

		public AssetBundleRequest LoadAllAssetsAsync()
		{
			return LoadAllAssetsAsync(typeof(Object));
		}

		public AssetBundleRequest LoadAllAssetsAsync<T>()
		{
			return LoadAllAssetsAsync(typeof(T));
		}

		public AssetBundleRequest LoadAllAssetsAsync(Type type)
		{
			if (type == null)
			{
				throw new NullReferenceException("The input type cannot be null.");
			}
			return LoadAssetWithSubAssetsAsync_Internal("", type);
		}

		[Obsolete("This method is deprecated.Use GetAllAssetNames() instead.", false)]
		public string[] AllAssetNames()
		{
			return GetAllAssetNames();
		}

		[NativeMethod("LoadAssetAsync_Internal")]
		[NativeThrows]
		private unsafe AssetBundleRequest LoadAssetAsync_Internal(string name, Type type)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			IntPtr intPtr2 = default(IntPtr);
			AssetBundleRequest result;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
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
						intPtr2 = LoadAssetAsync_Internal_Injected(intPtr, ref managedSpanWrapper, type);
					}
				}
				else
				{
					intPtr2 = LoadAssetAsync_Internal_Injected(intPtr, ref managedSpanWrapper, type);
				}
			}
			finally
			{
				IntPtr intPtr3 = intPtr2;
				result = ((intPtr3 == (IntPtr)0) ? null : AssetBundleRequest.BindingsMarshaller.ConvertToManaged(intPtr3));
			}
			return result;
		}

		[NativeMethod("Unload")]
		[NativeThrows]
		public void Unload(bool unloadAllLoadedObjects)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Unload_Injected(intPtr, unloadAllLoadedObjects);
		}

		[NativeMethod("UnloadAsync")]
		[NativeThrows]
		public AssetBundleUnloadOperation UnloadAsync(bool unloadAllLoadedObjects)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = UnloadAsync_Injected(intPtr, unloadAllLoadedObjects);
			return (intPtr2 == (IntPtr)0) ? null : AssetBundleUnloadOperation.BindingsMarshaller.ConvertToManaged(intPtr2);
		}

		[NativeMethod("GetAllAssetNames")]
		public string[] GetAllAssetNames()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAllAssetNames_Injected(intPtr);
		}

		[NativeMethod("GetAllScenePaths")]
		public string[] GetAllScenePaths()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAllScenePaths_Injected(intPtr);
		}

		[NativeThrows]
		[NativeMethod("LoadAssetWithSubAssets_Internal")]
		internal unsafe Object[] LoadAssetWithSubAssets_Internal(string name, Type type)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
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
						return LoadAssetWithSubAssets_Internal_Injected(intPtr, ref managedSpanWrapper, type);
					}
				}
				return LoadAssetWithSubAssets_Internal_Injected(intPtr, ref managedSpanWrapper, type);
			}
			finally
			{
			}
		}

		[NativeThrows]
		[NativeMethod("LoadAssetWithSubAssetsAsync_Internal")]
		private unsafe AssetBundleRequest LoadAssetWithSubAssetsAsync_Internal(string name, Type type)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			IntPtr intPtr2 = default(IntPtr);
			AssetBundleRequest result;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
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
						intPtr2 = LoadAssetWithSubAssetsAsync_Internal_Injected(intPtr, ref managedSpanWrapper, type);
					}
				}
				else
				{
					intPtr2 = LoadAssetWithSubAssetsAsync_Internal_Injected(intPtr, ref managedSpanWrapper, type);
				}
			}
			finally
			{
				IntPtr intPtr3 = intPtr2;
				result = ((intPtr3 == (IntPtr)0) ? null : AssetBundleRequest.BindingsMarshaller.ConvertToManaged(intPtr3));
			}
			return result;
		}

		public static AssetBundleRecompressOperation RecompressAssetBundleAsync(string inputPath, string outputPath, BuildCompression method, uint expectedCRC = 0u, ThreadPriority priority = ThreadPriority.Low)
		{
			return RecompressAssetBundleAsync_Internal(inputPath, outputPath, method, expectedCRC, priority);
		}

		[FreeFunction("RecompressAssetBundleAsync_Internal")]
		[NativeThrows]
		internal unsafe static AssetBundleRecompressOperation RecompressAssetBundleAsync_Internal(string inputPath, string outputPath, BuildCompression method, uint expectedCRC, ThreadPriority priority)
		{
			//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			IntPtr intPtr = default(IntPtr);
			AssetBundleRecompressOperation result;
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper inputPath2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(inputPath, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(inputPath);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						inputPath2 = ref managedSpanWrapper;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(outputPath, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(outputPath);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								intPtr = RecompressAssetBundleAsync_Internal_Injected(ref inputPath2, ref managedSpanWrapper2, ref method, expectedCRC, priority);
							}
						}
						else
						{
							intPtr = RecompressAssetBundleAsync_Internal_Injected(ref inputPath2, ref managedSpanWrapper2, ref method, expectedCRC, priority);
						}
					}
				}
				else
				{
					inputPath2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(outputPath, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(outputPath);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							intPtr = RecompressAssetBundleAsync_Internal_Injected(ref inputPath2, ref managedSpanWrapper2, ref method, expectedCRC, priority);
						}
					}
					else
					{
						intPtr = RecompressAssetBundleAsync_Internal_Injected(ref inputPath2, ref managedSpanWrapper2, ref method, expectedCRC, priority);
					}
				}
			}
			finally
			{
				IntPtr intPtr2 = intPtr;
				result = ((intPtr2 == (IntPtr)0) ? null : AssetBundleRecompressOperation.BindingsMarshaller.ConvertToManaged(intPtr2));
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr returnMainAsset_Injected(IntPtr bundle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr LoadFromFileAsync_Internal_Injected(ref ManagedSpanWrapper path, uint crc, ulong offset);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr LoadFromFile_Internal_Injected(ref ManagedSpanWrapper path, uint crc, ulong offset);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr LoadFromMemoryAsync_Internal_Injected(ref ManagedSpanWrapper binary, uint crc);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr LoadFromMemory_Internal_Injected(ref ManagedSpanWrapper binary, uint crc);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr LoadFromStreamAsyncInternal_Injected(Stream stream, uint crc, uint managedReadBufferSize);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr LoadFromStreamInternal_Injected(Stream stream, uint crc, uint managedReadBufferSize);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isStreamedSceneAssetBundle_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Contains_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr LoadAsset_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, Type type);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr LoadAssetAsync_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, Type type);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Unload_Injected(IntPtr _unity_self, bool unloadAllLoadedObjects);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr UnloadAsync_Injected(IntPtr _unity_self, bool unloadAllLoadedObjects);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string[] GetAllAssetNames_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string[] GetAllScenePaths_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Object[] LoadAssetWithSubAssets_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, Type type);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr LoadAssetWithSubAssetsAsync_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, Type type);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr RecompressAssetBundleAsync_Internal_Injected(ref ManagedSpanWrapper inputPath, ref ManagedSpanWrapper outputPath, [In] ref BuildCompression method, uint expectedCRC, ThreadPriority priority);
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromAsyncOperation.h")]
	[RequiredByNativeCode]
	public class AssetBundleCreateRequest : AsyncOperation
	{
		internal new static class BindingsMarshaller
		{
			public static AssetBundleCreateRequest ConvertToManaged(IntPtr ptr)
			{
				return new AssetBundleCreateRequest(ptr);
			}

			public static IntPtr ConvertToNative(AssetBundleCreateRequest assetBundleCreateRequest)
			{
				return assetBundleCreateRequest.m_Ptr;
			}
		}

		public AssetBundle assetBundle
		{
			[NativeMethod("GetAssetBundleBlocking")]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<AssetBundle>(get_assetBundle_Injected(intPtr));
			}
		}

		[NativeMethod("SetEnableCompatibilityChecks")]
		private void SetEnableCompatibilityChecks(bool set)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetEnableCompatibilityChecks_Injected(intPtr, set);
		}

		internal void DisableCompatibilityChecks()
		{
			SetEnableCompatibilityChecks(set: false);
		}

		public AssetBundleCreateRequest()
		{
		}

		private AssetBundleCreateRequest(IntPtr ptr)
			: base(ptr)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_assetBundle_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetEnableCompatibilityChecks_Injected(IntPtr _unity_self, bool set);
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[UsedByNativeCode]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadingCache.h")]
	internal static class AssetBundleLoadingCache
	{
		internal const int kMinAllowedBlockCount = 2;

		internal const int kMinAllowedMaxBlocksPerFile = 2;

		internal static extern uint maxBlocksPerFile
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		internal static extern uint blockCount
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		internal static extern uint blockSize
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		internal static uint memoryBudgetKB
		{
			get
			{
				return blockCount * blockSize;
			}
			set
			{
				uint num = Math.Max(value / blockSize, 2u);
				uint num2 = Math.Max(blockCount / 4, 2u);
				if (num != blockCount || num2 != maxBlocksPerFile)
				{
					blockCount = num;
					maxBlocksPerFile = num2;
				}
			}
		}
	}
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleManifest.h")]
	public class AssetBundleManifest : Object
	{
		private AssetBundleManifest()
		{
		}

		[NativeMethod("GetAllAssetBundles")]
		public string[] GetAllAssetBundles()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAllAssetBundles_Injected(intPtr);
		}

		[NativeMethod("GetAllAssetBundlesWithVariant")]
		public string[] GetAllAssetBundlesWithVariant()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAllAssetBundlesWithVariant_Injected(intPtr);
		}

		[NativeMethod("GetAssetBundleHash")]
		public unsafe Hash128 GetAssetBundleHash(string assetBundleName)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			Hash128 ret = default(Hash128);
			Hash128 result;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(assetBundleName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(assetBundleName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						GetAssetBundleHash_Injected(intPtr, ref managedSpanWrapper, out ret);
					}
				}
				else
				{
					GetAssetBundleHash_Injected(intPtr, ref managedSpanWrapper, out ret);
				}
			}
			finally
			{
				result = ret;
			}
			return result;
		}

		[NativeMethod("GetDirectDependencies")]
		public unsafe string[] GetDirectDependencies(string assetBundleName)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(assetBundleName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(assetBundleName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetDirectDependencies_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return GetDirectDependencies_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[NativeMethod("GetAllDependencies")]
		public unsafe string[] GetAllDependencies(string assetBundleName)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(assetBundleName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(assetBundleName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetAllDependencies_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return GetAllDependencies_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string[] GetAllAssetBundles_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string[] GetAllAssetBundlesWithVariant_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAssetBundleHash_Injected(IntPtr _unity_self, ref ManagedSpanWrapper assetBundleName, out Hash128 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string[] GetDirectDependencies_Injected(IntPtr _unity_self, ref ManagedSpanWrapper assetBundleName);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string[] GetAllDependencies_Injected(IntPtr _unity_self, ref ManagedSpanWrapper assetBundleName);
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleRecompressOperation.h")]
	[RequiredByNativeCode]
	public class AssetBundleRecompressOperation : AsyncOperation
	{
		internal new static class BindingsMarshaller
		{
			public static AssetBundleRecompressOperation ConvertToManaged(IntPtr ptr)
			{
				return new AssetBundleRecompressOperation(ptr);
			}

			public static IntPtr ConvertToNative(AssetBundleRecompressOperation op)
			{
				return op.m_Ptr;
			}
		}

		public string humanReadableResult
		{
			[NativeMethod("GetResultStr")]
			get
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
					get_humanReadableResult_Injected(intPtr, out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
		}

		public string inputPath
		{
			[NativeMethod("GetInputPath")]
			get
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
					get_inputPath_Injected(intPtr, out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
		}

		public string outputPath
		{
			[NativeMethod("GetOutputPath")]
			get
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
					get_outputPath_Injected(intPtr, out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
		}

		public AssetBundleLoadResult result
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

		public bool success
		{
			[NativeMethod("GetSuccess")]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_success_Injected(intPtr);
			}
		}

		public AssetBundleRecompressOperation()
		{
		}

		private AssetBundleRecompressOperation(IntPtr ptr)
			: base(ptr)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_humanReadableResult_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_inputPath_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_outputPath_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AssetBundleLoadResult get_result_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_success_Injected(IntPtr _unity_self);
	}
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadAssetOperation.h")]
	public class AssetBundleRequest : ResourceRequest
	{
		internal new static class BindingsMarshaller
		{
			public static AssetBundleRequest ConvertToManaged(IntPtr ptr)
			{
				return new AssetBundleRequest(ptr);
			}

			public static IntPtr ConvertToNative(AssetBundleRequest request)
			{
				return request.m_Ptr;
			}
		}

		public new Object asset => GetResult();

		public Object[] allAssets
		{
			[NativeMethod("GetAllLoadedAssets")]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_allAssets_Injected(intPtr);
			}
		}

		[NativeMethod("GetLoadedAsset")]
		protected override Object GetResult()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Object>(GetResult_Injected(intPtr));
		}

		public AssetBundleRequest()
		{
		}

		private AssetBundleRequest(IntPtr ptr)
			: base(ptr)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetResult_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Object[] get_allAssets_Injected(IntPtr _unity_self);
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleUnloadOperation.h")]
	[RequiredByNativeCode]
	public class AssetBundleUnloadOperation : AsyncOperation
	{
		internal new static class BindingsMarshaller
		{
			public static AssetBundleUnloadOperation ConvertToManaged(IntPtr ptr)
			{
				return new AssetBundleUnloadOperation(ptr);
			}

			public static IntPtr ConvertToNative(AssetBundleUnloadOperation assetBundleUnloadOperation)
			{
				return assetBundleUnloadOperation.m_Ptr;
			}
		}

		[NativeMethod("WaitForCompletion")]
		public void WaitForCompletion()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			WaitForCompletion_Injected(intPtr);
		}

		public AssetBundleUnloadOperation()
		{
		}

		private AssetBundleUnloadOperation(IntPtr ptr)
			: base(ptr)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void WaitForCompletion_Injected(IntPtr _unity_self);
	}
}
namespace UnityEngine.Experimental.AssetBundlePatching
{
	[NativeHeader("Modules/AssetBundle/Public/AssetBundlePatching.h")]
	public static class AssetBundleUtility
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction]
		public static extern void PatchAssetBundles(AssetBundle[] bundles, string[] filenames);
	}
}
