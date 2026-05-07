using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;

[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
[assembly: InternalsVisibleTo("UnityEngine.Advertisements")]
[assembly: InternalsVisibleTo("UnityEngine.Purchasing")]
[assembly: InternalsVisibleTo("UnityEngine.TestRunner")]
[assembly: InternalsVisibleTo("Unity.Automation")]
[assembly: InternalsVisibleTo("Unity.Burst")]
[assembly: InternalsVisibleTo("Unity.Burst.Editor")]
[assembly: InternalsVisibleTo("Unity.DeploymentTests.Services")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.2D")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Tooling")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.CommonUtils")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Application")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Deployment")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.006")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.007")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.008")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.009")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.012")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.013")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.014")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.015")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.016")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.017")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.018")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.020")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.021")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.022")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.023")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.024")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.Subsystem.Registration")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.019")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.002")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.003")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("UnityEngine.Core.Runtime.Tests")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.001")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.ImageConversionTests")]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.ContentLoadModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConnectModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterRendererModule")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.GIModule")]
[assembly: InternalsVisibleTo("UnityEngine.ImageConversionModule")]
[assembly: InternalsVisibleTo("UnityEngine.GameCenterModule")]
[assembly: InternalsVisibleTo("UnityEngine.GraphicsStateCollectionSerializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.GridModule")]
[assembly: InternalsVisibleTo("UnityEngine.HierarchyCoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextRenderingModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputLegacyModule")]
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreFontEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterInputModule")]
[assembly: InternalsVisibleTo("UnityEngine.AudioModule")]
[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: InternalsVisibleTo("UnityEngine.SharedInternalsModule")]
[assembly: InternalsVisibleTo("UnityEngine.CoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.AIModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClothModule")]
[assembly: InternalsVisibleTo("UnityEngine.AMDModule")]
[assembly: InternalsVisibleTo("UnityEngine.JSONSerializeModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputModule")]
[assembly: InternalsVisibleTo("UnityEngine.ARModule")]
[assembly: InternalsVisibleTo("UnityEngine.AccessibilityModule")]
[assembly: InternalsVisibleTo("UnityEngine.AndroidJNIModule")]
[assembly: InternalsVisibleTo("UnityEngine.AnimationModule")]
[assembly: InternalsVisibleTo("UnityEngine.HotReloadModule")]
[assembly: InternalsVisibleTo("UnityEngine.AssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.PhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreTextEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputForUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.UmbraModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityCurlModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityTestProtocolModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestTextureModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestWWWModule")]
[assembly: InternalsVisibleTo("UnityEngine.VFXModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsModule")]
[assembly: InternalsVisibleTo("UnityEngine.XRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("UnityEngine.IMGUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.SwitchModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS4VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConsentModule")]
[assembly: InternalsVisibleTo("UnityEngine.InsightsModule")]
[assembly: InternalsVisibleTo("UnityEngine.LocalizationModule")]
[assembly: InternalsVisibleTo("UnityEngine.MarshallingModule")]
[assembly: InternalsVisibleTo("UnityEngine.MultiplayerModule")]
[assembly: InternalsVisibleTo("UnityEngine.NVIDIAModule")]
[assembly: InternalsVisibleTo("UnityEngine.ParticleSystemModule")]
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.PropertiesModule")]
[assembly: InternalsVisibleTo("UnityEngine.Physics2DModule")]
[assembly: InternalsVisibleTo("UnityEngine.ScreenCaptureModule")]
[assembly: InternalsVisibleTo("UnityEngine.ShaderVariantAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteShapeModule")]
[assembly: InternalsVisibleTo("UnityEngine.TilemapModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteMaskModule")]
[assembly: InternalsVisibleTo("UnityEngine.StreamingModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubstanceModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubsystemsModule")]
[assembly: InternalsVisibleTo("UnityEngine.RuntimeInitializeOnLoadManagerInitializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainPhysicsModule")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine;

[NativeHeader("Modules/ImageConversion/ScriptBindings/ImageConversion.bindings.h")]
public static class ImageConversion
{
	public static bool EnableLegacyPngGammaRuntimeLoadBehavior
	{
		get
		{
			return GetEnableLegacyPngGammaRuntimeLoadBehavior();
		}
		set
		{
			SetEnableLegacyPngGammaRuntimeLoadBehavior(value);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "ImageConversionBindings::GetEnableLegacyPngGammaRuntimeLoadBehavior", IsFreeFunction = true, ThrowsException = false)]
	private static extern bool GetEnableLegacyPngGammaRuntimeLoadBehavior();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(Name = "ImageConversionBindings::SetEnableLegacyPngGammaRuntimeLoadBehavior", IsFreeFunction = true, ThrowsException = false)]
	private static extern void SetEnableLegacyPngGammaRuntimeLoadBehavior(bool enable);

	[NativeMethod(Name = "ImageConversionBindings::EncodeToTGA", IsFreeFunction = true, ThrowsException = true)]
	public static byte[] EncodeToTGA(this Texture2D tex)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeToTGA_Injected(Object.MarshalledUnityObject.Marshal(tex), out ret);
		}
		finally
		{
			byte[] array = default(byte[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeMethod(Name = "ImageConversionBindings::EncodeToPNG", IsFreeFunction = true, ThrowsException = true)]
	public static byte[] EncodeToPNG(this Texture2D tex)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeToPNG_Injected(Object.MarshalledUnityObject.Marshal(tex), out ret);
		}
		finally
		{
			byte[] array = default(byte[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeMethod(Name = "ImageConversionBindings::EncodeToJPG", IsFreeFunction = true, ThrowsException = true)]
	public static byte[] EncodeToJPG(this Texture2D tex, int quality)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeToJPG_Injected(Object.MarshalledUnityObject.Marshal(tex), quality, out ret);
		}
		finally
		{
			byte[] array = default(byte[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static byte[] EncodeToJPG(this Texture2D tex)
	{
		return tex.EncodeToJPG(75);
	}

	[NativeMethod(Name = "ImageConversionBindings::EncodeToEXR", IsFreeFunction = true, ThrowsException = true)]
	public static byte[] EncodeToEXR(this Texture2D tex, Texture2D.EXRFlags flags)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeToEXR_Injected(Object.MarshalledUnityObject.Marshal(tex), flags, out ret);
		}
		finally
		{
			byte[] array = default(byte[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static byte[] EncodeToEXR(this Texture2D tex)
	{
		return tex.EncodeToEXR(Texture2D.EXRFlags.None);
	}

	[NativeMethod(Name = "ImageConversionBindings::EncodeToR2D", IsFreeFunction = true, ThrowsException = true)]
	internal static byte[] EncodeToR2DInternal(this Texture2D tex)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeToR2DInternal_Injected(Object.MarshalledUnityObject.Marshal(tex), out ret);
		}
		finally
		{
			byte[] array = default(byte[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeMethod(Name = "ImageConversionBindings::LoadImage", IsFreeFunction = true)]
	public unsafe static bool LoadImage([NotNull] this Texture2D tex, ReadOnlySpan<byte> data, bool markNonReadable)
	{
		if ((object)tex == null)
		{
			ThrowHelper.ThrowArgumentNullException(tex, "tex");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(tex);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(tex, "tex");
		}
		ReadOnlySpan<byte> readOnlySpan = data;
		bool result;
		fixed (byte* begin = readOnlySpan)
		{
			ManagedSpanWrapper data2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			result = LoadImage_Injected(intPtr, ref data2, markNonReadable);
		}
		return result;
	}

	public static bool LoadImage(this Texture2D tex, ReadOnlySpan<byte> data)
	{
		return tex.LoadImage(data, markNonReadable: false);
	}

	public static bool LoadImage(this Texture2D tex, byte[] data, bool markNonReadable)
	{
		return tex.LoadImage(new ReadOnlySpan<byte>(data), markNonReadable);
	}

	public static bool LoadImage(this Texture2D tex, byte[] data)
	{
		return tex.LoadImage(new ReadOnlySpan<byte>(data), markNonReadable: false);
	}

	[FreeFunction("ImageConversionBindings::EncodeArrayToTGA", true)]
	public static byte[] EncodeArrayToTGA(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeArrayToTGA_Injected(array, format, width, height, rowBytes, out ret);
		}
		finally
		{
			byte[] array2 = default(byte[]);
			ret.Unmarshal(ref array2);
			result = array2;
		}
		return result;
	}

	[FreeFunction("ImageConversionBindings::EncodeArrayToPNG", true)]
	public static byte[] EncodeArrayToPNG(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeArrayToPNG_Injected(array, format, width, height, rowBytes, out ret);
		}
		finally
		{
			byte[] array2 = default(byte[]);
			ret.Unmarshal(ref array2);
			result = array2;
		}
		return result;
	}

	[FreeFunction("ImageConversionBindings::EncodeArrayToJPG", true)]
	public static byte[] EncodeArrayToJPG(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u, int quality = 75)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeArrayToJPG_Injected(array, format, width, height, rowBytes, quality, out ret);
		}
		finally
		{
			byte[] array2 = default(byte[]);
			ret.Unmarshal(ref array2);
			result = array2;
		}
		return result;
	}

	[FreeFunction("ImageConversionBindings::EncodeArrayToEXR", true)]
	public static byte[] EncodeArrayToEXR(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u, Texture2D.EXRFlags flags = Texture2D.EXRFlags.None)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeArrayToEXR_Injected(array, format, width, height, rowBytes, flags, out ret);
		}
		finally
		{
			byte[] array2 = default(byte[]);
			ret.Unmarshal(ref array2);
			result = array2;
		}
		return result;
	}

	[FreeFunction("ImageConversionBindings::EncodeArrayToR2D", true)]
	internal static byte[] EncodeArrayToR2DInternal(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		byte[] result;
		try
		{
			EncodeArrayToR2DInternal_Injected(array, format, width, height, rowBytes, out ret);
		}
		finally
		{
			byte[] array2 = default(byte[]);
			ret.Unmarshal(ref array2);
			result = array2;
		}
		return result;
	}

	public unsafe static NativeArray<byte> EncodeNativeArrayToTGA<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u) where T : struct
	{
		int sizeInBytes = input.Length * UnsafeUtility.SizeOf<T>();
		void* dataPointer = UnsafeEncodeNativeArrayToTGA(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(input), ref sizeInBytes, format, width, height, rowBytes);
		return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(dataPointer, sizeInBytes, Allocator.Persistent);
	}

	public unsafe static NativeArray<byte> EncodeNativeArrayToPNG<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u) where T : struct
	{
		int sizeInBytes = input.Length * UnsafeUtility.SizeOf<T>();
		void* dataPointer = UnsafeEncodeNativeArrayToPNG(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(input), ref sizeInBytes, format, width, height, rowBytes);
		return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(dataPointer, sizeInBytes, Allocator.Persistent);
	}

	public unsafe static NativeArray<byte> EncodeNativeArrayToJPG<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u, int quality = 75) where T : struct
	{
		int sizeInBytes = input.Length * UnsafeUtility.SizeOf<T>();
		void* dataPointer = UnsafeEncodeNativeArrayToJPG(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(input), ref sizeInBytes, format, width, height, rowBytes, quality);
		return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(dataPointer, sizeInBytes, Allocator.Persistent);
	}

	public unsafe static NativeArray<byte> EncodeNativeArrayToEXR<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u, Texture2D.EXRFlags flags = Texture2D.EXRFlags.None) where T : struct
	{
		int sizeInBytes = input.Length * UnsafeUtility.SizeOf<T>();
		void* dataPointer = UnsafeEncodeNativeArrayToEXR(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(input), ref sizeInBytes, format, width, height, rowBytes, flags);
		return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(dataPointer, sizeInBytes, Allocator.Persistent);
	}

	internal unsafe static NativeArray<byte> EncodeNativeArrayToR2DInternal<T>(NativeArray<T> input, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u) where T : struct
	{
		int sizeInBytes = input.Length * UnsafeUtility.SizeOf<T>();
		void* dataPointer = UnsafeEncodeNativeArrayToR2D(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(input), ref sizeInBytes, format, width, height, rowBytes);
		return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(dataPointer, sizeInBytes, Allocator.Persistent);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("ImageConversionBindings::UnsafeEncodeNativeArrayToTGA", true)]
	private unsafe static extern void* UnsafeEncodeNativeArrayToTGA(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("ImageConversionBindings::UnsafeEncodeNativeArrayToPNG", true)]
	private unsafe static extern void* UnsafeEncodeNativeArrayToPNG(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("ImageConversionBindings::UnsafeEncodeNativeArrayToJPG", true)]
	private unsafe static extern void* UnsafeEncodeNativeArrayToJPG(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u, int quality = 75);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("ImageConversionBindings::UnsafeEncodeNativeArrayToEXR", true)]
	private unsafe static extern void* UnsafeEncodeNativeArrayToEXR(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u, Texture2D.EXRFlags flags = Texture2D.EXRFlags.None);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("ImageConversionBindings::UnsafeEncodeNativeArrayToR2D", true)]
	private unsafe static extern void* UnsafeEncodeNativeArrayToR2D(void* array, ref int sizeInBytes, GraphicsFormat format, uint width, uint height, uint rowBytes = 0u);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeToTGA_Injected(IntPtr tex, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeToPNG_Injected(IntPtr tex, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeToJPG_Injected(IntPtr tex, int quality, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeToEXR_Injected(IntPtr tex, Texture2D.EXRFlags flags, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeToR2DInternal_Injected(IntPtr tex, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool LoadImage_Injected(IntPtr tex, ref ManagedSpanWrapper data, bool markNonReadable);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeArrayToTGA_Injected(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeArrayToPNG_Injected(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeArrayToJPG_Injected(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes, int quality, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeArrayToEXR_Injected(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes, Texture2D.EXRFlags flags, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EncodeArrayToR2DInternal_Injected(Array array, GraphicsFormat format, uint width, uint height, uint rowBytes, out BlittableArrayWrapper ret);
}
