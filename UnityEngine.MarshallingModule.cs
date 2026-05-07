using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using AOT;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.007")]
[assembly: InternalsVisibleTo("UnityEngine.RuntimeInitializeOnLoadManagerInitializerModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.ScreenCaptureModule")]
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: InternalsVisibleTo("UnityEngine.ShaderVariantAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.TilemapModule")]
[assembly: InternalsVisibleTo("UnityEngine.SwitchModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.XRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VFXModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestWWWModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.SpriteShapeModule")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
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
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.018")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.019")]
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
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
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
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: InternalsVisibleTo("UnityEngine.PS4VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.001")]
[assembly: InternalsVisibleTo("UnityEngine.Core.Runtime.Tests")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Application")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
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
[assembly: InternalsVisibleTo("UnityEngine.Advertisements")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.006")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine;

[NativeHeader("MarshallingScriptingClasses.h")]
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal class PrimitiveTests
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterBool(bool param1, bool param2, int param3);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterInt(int param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void ParameterOutInt(out int param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void ParameterRefInt(ref int param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern int ReturnInt();

	[NativeThrows]
	public unsafe static void ParameterIntDynamicArray(int[] param)
	{
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterIntDynamicArray_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterIntNullableDynamicArray(int[] param)
	{
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterIntNullableDynamicArray_Injected(ref param2);
		}
	}

	public static int[] ReturnIntDynamicArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		int[] result;
		try
		{
			ReturnIntDynamicArray_Injected(out ret);
		}
		finally
		{
			int[] array = default(int[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static int[] ReturnNullIntDynamicArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		int[] result;
		try
		{
			ReturnNullIntDynamicArray_Injected(out ret);
		}
		finally
		{
			int[] array = default(int[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static bool[] ReturnBoolDynamicArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		bool[] result;
		try
		{
			ReturnBoolDynamicArray_Injected(out ret);
		}
		finally
		{
			bool[] array = default(bool[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static char[] ReturnCharDynamicArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		char[] result;
		try
		{
			ReturnCharDynamicArray_Injected(out ret);
		}
		finally
		{
			char[] array = default(char[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntDynamicArray_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntNullableDynamicArray_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnIntDynamicArray_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnNullIntDynamicArray_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnBoolDynamicArray_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnCharDynamicArray_Injected(out BlittableArrayWrapper ret);
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[NativeClass("StructCoreString", "struct StructCoreString;")]
[RequiredByNativeCode(GenerateProxy = true, Name = "StructCoreStringManaged", Optional = true)]
[ExcludeFromDocs]
internal struct StructCoreString
{
	public string field;

	public string GetField()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			GetField_Injected(ref this, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public unsafe void SetField(string value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					SetField_Injected(ref this, ref managedSpanWrapper);
					return;
				}
			}
			SetField_Injected(ref this, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetField_Injected(ref StructCoreString _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetField_Injected(ref StructCoreString _unity_self, ref ManagedSpanWrapper value);
}
[ExcludeFromDocs]
internal struct StructCoreStringVector
{
	public string[] field;
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal class StringTests
{
	public unsafe static void SetTestOutString(string testString)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(testString, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(testString);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					SetTestOutString_Injected(ref managedSpanWrapper);
					return;
				}
			}
			SetTestOutString_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ParameterICallString(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterICallString_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterICallString_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ParameterICallNullString(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterICallNullString_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterICallNullString_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ParameterCoreString(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterCoreString_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterCoreString_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ParameterConstCharPtr(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterConstCharPtr_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterConstCharPtr_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ParameterConstCharPtrNull(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterConstCharPtrNull_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterConstCharPtrNull_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ParameterConstCharPtrEmptyString(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterConstCharPtrEmptyString_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterConstCharPtrEmptyString_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterCoreStringVector(string[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterCoreStringDynamicArray(string[] param);

	[NativeThrows]
	public static void ParameterStructCoreString(StructCoreString param)
	{
		ParameterStructCoreString_Injected(ref param);
	}

	[NativeThrows]
	public static void ParameterStructCoreStringVector(StructCoreStringVector param)
	{
		ParameterStructCoreStringVector_Injected(ref param);
	}

	[NativeThrows]
	public static StructCoreString TestCoreStringViaProxy(StructCoreString param)
	{
		TestCoreStringViaProxy_Injected(ref param, out var ret);
		return ret;
	}

	public static string ReturnCoreString()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			ReturnCoreString_Injected(out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string ReturnCoreStringRef()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			ReturnCoreStringRef_Injected(out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string ReturnConstCharPtr()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			ReturnConstCharPtr_Injected(out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] ReturnCoreStringVector();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] ReturnCoreStringDynamicArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] ReturnNullStringDynamicArray();

	public static StructCoreString ReturnStructCoreString()
	{
		ReturnStructCoreString_Injected(out var ret);
		return ret;
	}

	[NativeConditional("FOO")]
	public static string FalseConditional()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			FalseConditional_Injected(out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static StructCoreStringVector ReturnStructCoreStringVector()
	{
		ReturnStructCoreStringVector_Injected(out var ret);
		return ret;
	}

	[NativeThrows]
	public static void ParameterOutString(out string param)
	{
		ManagedSpanWrapper param2 = default(ManagedSpanWrapper);
		try
		{
			ParameterOutString_Injected(out param2);
		}
		finally
		{
			param = OutStringMarshaller.GetStringAndDispose(param2);
		}
	}

	[NativeThrows]
	public static void ParameterOutStringInNull(out string param)
	{
		ManagedSpanWrapper param2 = default(ManagedSpanWrapper);
		try
		{
			ParameterOutStringInNull_Injected(out param2);
		}
		finally
		{
			param = OutStringMarshaller.GetStringAndDispose(param2);
		}
	}

	[NativeThrows]
	public static void ParameterOutStringNotSet(out string param)
	{
		ManagedSpanWrapper param2 = default(ManagedSpanWrapper);
		try
		{
			ParameterOutStringNotSet_Injected(out param2);
		}
		finally
		{
			param = OutStringMarshaller.GetStringAndDispose(param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterRefString(ref string param)
	{
		//The blocks IL_002b are reachable both inside and outside the pinned region starting at IL_001a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
		try
		{
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterRefString_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterRefString_Injected(ref managedSpanWrapper);
		}
		finally
		{
			param = OutStringMarshaller.GetStringAndDispose(managedSpanWrapper);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterRefStringInNull(ref string param)
	{
		//The blocks IL_002b are reachable both inside and outside the pinned region starting at IL_001a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
		try
		{
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterRefStringInNull_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterRefStringInNull_Injected(ref managedSpanWrapper);
		}
		finally
		{
			param = OutStringMarshaller.GetStringAndDispose(managedSpanWrapper);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterRefStringNotSet(ref string param)
	{
		//The blocks IL_002b are reachable both inside and outside the pinned region starting at IL_001a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
		try
		{
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ParameterRefStringNotSet_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ParameterRefStringNotSet_Injected(ref managedSpanWrapper);
		}
		finally
		{
			param = OutStringMarshaller.GetStringAndDispose(managedSpanWrapper);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetTestOutString_Injected(ref ManagedSpanWrapper testString);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterICallString_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterICallNullString_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterCoreString_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterConstCharPtr_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterConstCharPtrNull_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterConstCharPtrEmptyString_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructCoreString_Injected([In] ref StructCoreString param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructCoreStringVector_Injected([In] ref StructCoreStringVector param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void TestCoreStringViaProxy_Injected([In] ref StructCoreString param, out StructCoreString ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnCoreString_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnCoreStringRef_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnConstCharPtr_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructCoreString_Injected(out StructCoreString ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void FalseConditional_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructCoreStringVector_Injected(out StructCoreStringVector ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterOutString_Injected(out ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterOutStringInNull_Injected(out ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterOutStringNotSet_Injected(out ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterRefString_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterRefStringInNull_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterRefStringNotSet_Injected(ref ManagedSpanWrapper param);
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal struct StructInt
{
	public int field;
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal struct StructInt2
{
	public int field;
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal struct StructNestedBlittable
{
	public StructInt field;
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal struct StructFixedBuffer
{
	public unsafe fixed int SomeInts[4];
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal class BlittableStructTests
{
	public static StructInt structIntProperty
	{
		get
		{
			get_structIntProperty_Injected(out var ret);
			return ret;
		}
		set
		{
			set_structIntProperty_Injected(ref value);
		}
	}

	[NativeThrows]
	public static void ParameterStructInt(StructInt param)
	{
		ParameterStructInt_Injected(ref param);
	}

	public static void ParameterStructInt2(StructInt2 param)
	{
		ParameterStructInt2_Injected(ref param);
	}

	public static StructInt ReturnStructInt()
	{
		ReturnStructInt_Injected(out var ret);
		return ret;
	}

	[NativeThrows]
	public static void ParameterNestedBlittableStruct(StructNestedBlittable s)
	{
		ParameterNestedBlittableStruct_Injected(ref s);
	}

	public static StructNestedBlittable ReturnNestedBlittableStruct()
	{
		ReturnNestedBlittableStruct_Injected(out var ret);
		return ret;
	}

	[NativeThrows]
	public unsafe static void ParameterStructIntDynamicArray(StructInt[] param)
	{
		Span<StructInt> span = new Span<StructInt>(param);
		fixed (StructInt* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterStructIntDynamicArray_Injected(ref param2);
		}
	}

	public static StructInt[] ReturnStructIntDynamicArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		StructInt[] result;
		try
		{
			ReturnStructIntDynamicArray_Injected(out ret);
		}
		finally
		{
			StructInt[] array = default(StructInt[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeThrows]
	public unsafe static void ParameterStructNestedBlittableDynamicArray(StructNestedBlittable[] param)
	{
		Span<StructNestedBlittable> span = new Span<StructNestedBlittable>(param);
		fixed (StructNestedBlittable* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterStructNestedBlittableDynamicArray_Injected(ref param2);
		}
	}

	public static StructNestedBlittable[] ReturnStructNestedBlittableDynamicArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		StructNestedBlittable[] result;
		try
		{
			ReturnStructNestedBlittableDynamicArray_Injected(out ret);
		}
		finally
		{
			StructNestedBlittable[] array = default(StructNestedBlittable[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeThrows]
	public static void ParameterStructFixedBuffer(StructFixedBuffer param)
	{
		ParameterStructFixedBuffer_Injected(ref param);
	}

	public static StructFixedBuffer ReturnStructFixedBuffer()
	{
		ReturnStructFixedBuffer_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructInt_Injected([In] ref StructInt param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructInt2_Injected([In] ref StructInt2 param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructInt_Injected(out StructInt ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterNestedBlittableStruct_Injected([In] ref StructNestedBlittable s);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnNestedBlittableStruct_Injected(out StructNestedBlittable ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructIntDynamicArray_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructIntDynamicArray_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructNestedBlittableDynamicArray_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructNestedBlittableDynamicArray_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructFixedBuffer_Injected([In] ref StructFixedBuffer param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructFixedBuffer_Injected(out StructFixedBuffer ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_structIntProperty_Injected(out StructInt ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_structIntProperty_Injected([In] ref StructInt value);
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal struct StructIntPtrObject
{
	public MyIntPtrObject field;
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal struct StructIntPtrObjectVector
{
	public MyIntPtrObject[] field;
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal struct StructIntPtrObjectDynamicArray
{
	public MyIntPtrObject[] field;
}
[ExcludeFromDocs]
internal class MyIntPtrObject : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(MyIntPtrObject obj)
		{
			return obj.m_Ptr;
		}

		public static MyIntPtrObject ConvertToManaged(IntPtr ptr)
		{
			return new MyIntPtrObject(ptr);
		}
	}

	public IntPtr m_Ptr;

	public int MemberProperty
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_MemberProperty_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_MemberProperty_Injected(intPtr, value);
		}
	}

	internal MyIntPtrObject(IntPtr ptr)
	{
		m_Ptr = ptr;
	}

	public MyIntPtrObject()
	{
		m_Ptr = Internal_Create();
	}

	public void Dispose()
	{
		if (m_Ptr != IntPtr.Zero)
		{
			Internal_Destroy(m_Ptr);
			m_Ptr = IntPtr.Zero;
		}
	}

	public static MyIntPtrObject Create()
	{
		IntPtr intPtr = Create_Injected();
		return (intPtr == (IntPtr)0) ? null : BindingsMarshaller.ConvertToManaged(intPtr);
	}

	public int MemberFunction(int a)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return MemberFunction_Injected(intPtr, a);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Internal_Create();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_Destroy(IntPtr ptr);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Create_Injected();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int MemberFunction_Injected(IntPtr _unity_self, int a);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_MemberProperty_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_MemberProperty_Injected(IntPtr _unity_self, int value);
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal class IntPtrObjectTests
{
	[NativeThrows]
	public static void ParameterIntPtrObject(MyIntPtrObject param)
	{
		ParameterIntPtrObject_Injected((param == null) ? ((IntPtr)0) : MyIntPtrObject.BindingsMarshaller.ConvertToNative(param));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterIntPtrObjectDynamicArray(MyIntPtrObject[] param);

	[NativeThrows]
	public static void ParameterStructIntPtrObject(StructIntPtrObject param)
	{
		ParameterStructIntPtrObject_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MyIntPtrObject[] ReturnIntPtrObjectDynamicArray();

	[NativeThrows]
	public static void ParameterStructIntPtrObjectDynamicArray(StructIntPtrObjectDynamicArray param)
	{
		ParameterStructIntPtrObjectDynamicArray_Injected(ref param);
	}

	public static MyIntPtrObject ReturnIntPtrObject(int value)
	{
		IntPtr intPtr = ReturnIntPtrObject_Injected(value);
		return (intPtr == (IntPtr)0) ? null : MyIntPtrObject.BindingsMarshaller.ConvertToManaged(intPtr);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntPtrObject_Injected(IntPtr param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructIntPtrObject_Injected([In] ref StructIntPtrObject param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructIntPtrObjectDynamicArray_Injected([In] ref StructIntPtrObjectDynamicArray param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr ReturnIntPtrObject_Injected(int value);
}
[StructLayout(LayoutKind.Sequential)]
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal class MarshallingTestObject : Object
{
	[UnityEngine.Scripting.RequiredMember]
	[RequiredByNativeCode(Optional = true)]
	private int TestField;

	public int MemberProperty
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_MemberProperty_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_MemberProperty_Injected(intPtr, value);
		}
	}

	[NativeProperty("m_fieldBoundProp", false, TargetType.Field)]
	public int FieldBoundMemberProperty
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_FieldBoundMemberProperty_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_FieldBoundMemberProperty_Injected(intPtr, value);
		}
	}

	public MarshallingTestObject()
	{
		Internal_CreateMarshallingTestObject(this);
	}

	public int MemberFunction(int a)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return MemberFunction_Injected(intPtr, a);
	}

	public static MarshallingTestObject Create()
	{
		return Unmarshal.UnmarshalUnityObject<MarshallingTestObject>(Create_Injected());
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_CreateMarshallingTestObject([Writable] MarshallingTestObject notSelf);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int MemberFunction_Injected(IntPtr _unity_self, int a);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_MemberProperty_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_MemberProperty_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_FieldBoundMemberProperty_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_FieldBoundMemberProperty_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Create_Injected();
}
[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal class DifferentMarshallingTestObject : Object
{
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal struct StructUnityObject
{
	public MarshallingTestObject field;

	public int InstanceMethod([NotNull] object o)
	{
		if (o == null)
		{
			ThrowHelper.ThrowArgumentNullException(o, "o");
		}
		return InstanceMethod_Injected(ref this, o);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int InstanceMethod_Injected(ref StructUnityObject _unity_self, object o);
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal struct StructUnityObjectPPtr
{
	public MarshallingTestObject field;
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal struct StructUnityObjectVector
{
	public MarshallingTestObject[] field;
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal struct StructUnityObjectDynamicArray
{
	public MarshallingTestObject[] field;
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal class UnityObjectTests
{
	[NativeThrows]
	public static void ParameterUnityObject(MarshallingTestObject param)
	{
		ParameterUnityObject_Injected(Object.MarshalledUnityObject.Marshal(param));
	}

	[NativeThrows]
	public static void ParameterUnityObjectByRef(ref MarshallingTestObject param)
	{
		ParameterUnityObjectByRef_Injected(Object.MarshalledUnityObject.Marshal(param));
	}

	[NativeThrows]
	public static void ParameterUnityObjectPPtr(MarshallingTestObject param)
	{
		ParameterUnityObjectPPtr_Injected(Object.MarshalledUnityObject.Marshal(param));
	}

	[NativeThrows]
	public static void ParameterStructUnityObject(StructUnityObject param)
	{
		ParameterStructUnityObject_Injected(ref param);
	}

	[NativeThrows]
	public static void ParameterStructUnityObjectPPtr(StructUnityObjectPPtr param)
	{
		ParameterStructUnityObjectPPtr_Injected(ref param);
	}

	[NativeThrows]
	public static void ParameterStructUnityObjectDynamicArray(StructUnityObjectDynamicArray param)
	{
		ParameterStructUnityObjectDynamicArray_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterUnityObjectDynamicArray(MarshallingTestObject[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterUnityObjectPPtrDynamicArray(MarshallingTestObject[] param);

	public static MarshallingTestObject ReturnUnityObject()
	{
		return Unmarshal.UnmarshalUnityObject<MarshallingTestObject>(ReturnUnityObject_Injected());
	}

	public static MarshallingTestObject ReturnInUnityObject(MarshallingTestObject obj)
	{
		return Unmarshal.UnmarshalUnityObject<MarshallingTestObject>(ReturnInUnityObject_Injected(Object.MarshalledUnityObject.Marshal(obj)));
	}

	public static MarshallingTestObject ReturnUnityObjectFakeNull()
	{
		return Unmarshal.UnmarshalUnityObject<MarshallingTestObject>(ReturnUnityObjectFakeNull_Injected());
	}

	public static MarshallingTestObject ReturnUnassignedErrorObject()
	{
		return Unmarshal.UnmarshalUnityObject<MarshallingTestObject>(ReturnUnassignedErrorObject_Injected());
	}

	public static MarshallingTestObject ReturnUnityObjectPPtr()
	{
		return Unmarshal.UnmarshalUnityObject<MarshallingTestObject>(ReturnUnityObjectPPtr_Injected());
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MarshallingTestObject[] ReturnUnityObjectDynamicArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MarshallingTestObject[] ReturnUnityObjectPPtrDynamicArray();

	public static StructUnityObject ReturnStructUnityObject()
	{
		ReturnStructUnityObject_Injected(out var ret);
		return ret;
	}

	public static StructUnityObjectPPtr ReturnStructUnityObjectPPtr()
	{
		ReturnStructUnityObjectPPtr_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern StructUnityObject[] ReturnStructUnityObjectDynamicArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern StructUnityObjectPPtr[] ReturnStructUnityObjectPPtrDynamicArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern StructUnityObjectDynamicArray[] ReturnStructUnityObjectDynamicArrayDynamicArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterUnityObject_Injected(IntPtr param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterUnityObjectByRef_Injected(IntPtr param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterUnityObjectPPtr_Injected(IntPtr param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructUnityObject_Injected([In] ref StructUnityObject param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructUnityObjectPPtr_Injected([In] ref StructUnityObjectPPtr param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructUnityObjectDynamicArray_Injected([In] ref StructUnityObjectDynamicArray param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr ReturnUnityObject_Injected();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr ReturnInUnityObject_Injected(IntPtr obj);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr ReturnUnityObjectFakeNull_Injected();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr ReturnUnassignedErrorObject_Injected();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr ReturnUnityObjectPPtr_Injected();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructUnityObject_Injected(out StructUnityObject ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructUnityObjectPPtr_Injected(out StructUnityObjectPPtr ret);
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal class NullCheckTests
{
	public unsafe static void StringParameterNullAllowed(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					StringParameterNullAllowed_Injected(ref managedSpanWrapper);
					return;
				}
			}
			StringParameterNullAllowed_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	public unsafe static void StringParameterNullNotAllowed([NotNull] string param)
	{
		//The blocks IL_0038 are reachable both inside and outside the pinned region starting at IL_0027. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		if (param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					StringParameterNullNotAllowed_Injected(ref managedSpanWrapper);
					return;
				}
			}
			StringParameterNullNotAllowed_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	public unsafe static void ArrayParameterNullAllowed(int[] param)
	{
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ArrayParameterNullAllowed_Injected(ref param2);
		}
	}

	public unsafe static void ArrayParameterNullNotAllowed([NotNull] int[] param)
	{
		if (param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ArrayParameterNullNotAllowed_Injected(ref param2);
		}
	}

	[NativeThrows]
	public static void ObjectParameterNullAllowed(MarshallingTestObject param)
	{
		ObjectParameterNullAllowed_Injected(Object.MarshalledUnityObject.Marshal(param));
	}

	public static void ObjectParameterNullNotAllowed([NotNull] MarshallingTestObject param)
	{
		if ((object)param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(param);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		ObjectParameterNullNotAllowed_Injected(intPtr);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void WritableObjectParameterNullAllowed([Writable] MarshallingTestObject param);

	public static void WritableObjectParameterNullNotAllowed([Writable][NotNull] MarshallingTestObject param)
	{
		if ((object)param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		WritableObjectParameterNullNotAllowed_Injected(param);
	}

	[NativeThrows]
	public static void IntPtrObjectParameterNullAllowed(MyIntPtrObject param)
	{
		IntPtrObjectParameterNullAllowed_Injected((param == null) ? ((IntPtr)0) : MyIntPtrObject.BindingsMarshaller.ConvertToNative(param));
	}

	public static void IntPtrObjectParameterNullNotAllowed([NotNull] MyIntPtrObject param)
	{
		if (param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		IntPtr intPtr = MyIntPtrObject.BindingsMarshaller.ConvertToNative(param);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		IntPtrObjectParameterNullNotAllowed_Injected(intPtr);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void StringParameterNullAllowed_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void StringParameterNullNotAllowed_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ArrayParameterNullAllowed_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ArrayParameterNullNotAllowed_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ObjectParameterNullAllowed_Injected(IntPtr param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ObjectParameterNullNotAllowed_Injected(IntPtr param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void WritableObjectParameterNullNotAllowed_Injected([Writable] MarshallingTestObject param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void IntPtrObjectParameterNullAllowed_Injected(IntPtr param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void IntPtrObjectParameterNullNotAllowed_Injected(IntPtr param);
}
[StructLayout(LayoutKind.Sequential)]
[ExcludeFromDocs]
internal class MyManagedObject
{
	public int value = 42;
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal struct StructManagedObject
{
	public MyManagedObject field;
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal struct StructManagedObjectVector
{
	public MyManagedObject[] field;
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal class ManagedObjectTests
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern MyManagedObject ParameterManagedObject(MyManagedObject param);

	[NativeThrows]
	public static StructManagedObject ParameterStructManagedObject(StructManagedObject param)
	{
		ParameterStructManagedObject_Injected(ref param, out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MyManagedObject[] ReturnNullManagedObjectArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern MyManagedObject[] ParameterManagedObjectVector(MyManagedObject[] param);

	[NativeThrows]
	public static StructManagedObjectVector ParameterStructManagedObjectVector(StructManagedObjectVector param)
	{
		ParameterStructManagedObjectVector_Injected(ref param, out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructManagedObject_Injected([In] ref StructManagedObject param, out StructManagedObject ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructManagedObjectVector_Injected([In] ref StructManagedObjectVector param, out StructManagedObjectVector ret);
}
[ExcludeFromDocs]
internal struct StructSystemType
{
	public Type field;
}
[ExcludeFromDocs]
internal struct StructSystemTypeArray
{
	public Type[] field;
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/SystemTypeMarshallingTests.h")]
internal static class SystemTypeMarshallingTests
{
	public static string CanMarshallSystemTypeArgumentToScriptingClassPtr(Type param)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			CanMarshallSystemTypeArgumentToScriptingClassPtr_Injected(param, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string CanMarshallSystemTypeStructField(StructSystemType param)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			CanMarshallSystemTypeStructField_Injected(ref param, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string[] CanMarshallSystemTypeArrayStructField(StructSystemTypeArray param)
	{
		return CanMarshallSystemTypeArrayStructField_Injected(ref param);
	}

	public static StructSystemType CanUnmarshallSystemTypeStructField()
	{
		CanUnmarshallSystemTypeStructField_Injected(out var ret);
		return ret;
	}

	public static StructSystemTypeArray CanUnmarshallSystemTypeArrayStructField()
	{
		CanUnmarshallSystemTypeArrayStructField_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] CanUnmarshallArrayOfSystemTypeArgumentToDynamicArrayOfScriptingSystemTypeObjectPtr(Type[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] CanUnmarshallArrayOfSystemTypeArgumentToDynamicArrayOfUnityType(Type[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] CanUnmarshallArrayOfSystemTypeArgumentToDynamicArrayOfScriptingClassPtr(Type[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern Type CanUnmarshallScriptingSystemTypeObjectPtrToSystemType();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern Type CanUnmarshallUnityTypeToSystemType();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern Type CanUnmarshallScriptingClassPtrToSystemType();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern Type[] CanUnmarshallScriptingArrayPtrToSystemTypeArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern Type[] CanUnmarshallArrayOfScriptingSystemTypeObjectPtrToSystemTypeArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern Type[] CanUnmarshallArrayOfUnityTypeToSystemTypeArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern Type[] CanUnmarshallArrayOfScriptingClassPtrToSystemTypeArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanMarshallSystemTypeArgumentToScriptingClassPtr_Injected(Type param, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanMarshallSystemTypeStructField_Injected([In] ref StructSystemType param, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] CanMarshallSystemTypeArrayStructField_Injected([In] ref StructSystemTypeArray param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanUnmarshallSystemTypeStructField_Injected(out StructSystemType ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanUnmarshallSystemTypeArrayStructField_Injected(out StructSystemTypeArray ret);
}
[ExcludeFromDocs]
internal struct StructSystemReflectionFieldInfo
{
	public FieldInfo field;
}
[ExcludeFromDocs]
internal struct StructSystemReflectionFieldInfoArray
{
	public FieldInfo[] field;
}
[NativeHeader("Modules/Marshalling/SystemReflectionFieldInfoMarshallingTests.h")]
[ExcludeFromDocs]
internal static class SystemReflectionFieldInfoMarshallingTests
{
	public static string CanMarshallFieldInfoArgumentToScriptingFieldPtr(FieldInfo param)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			CanMarshallFieldInfoArgumentToScriptingFieldPtr_Injected(param, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string CanMarshallSystemReflectionFieldInfoStructField(StructSystemReflectionFieldInfo param)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			CanMarshallSystemReflectionFieldInfoStructField_Injected(ref param, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string[] CanMarshallSystemReflectionFieldInfoArrayStructField(StructSystemReflectionFieldInfoArray param)
	{
		return CanMarshallSystemReflectionFieldInfoArrayStructField_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] CanMarshallArrayOfFieldInfoArgumentToDynamicArrayOfScriptingFieldInfoObjectPtr(FieldInfo[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] CanMarshallArrayOfFieldInfoArgumentToDynamicArrayOfScriptingFieldPtr(FieldInfo[] param);

	public static StructSystemReflectionFieldInfo CanUnmarshallSystemReflectionFieldInfoStructField()
	{
		CanUnmarshallSystemReflectionFieldInfoStructField_Injected(out var ret);
		return ret;
	}

	public static StructSystemReflectionFieldInfoArray CanUnmarshallSystemReflectionFieldInfoArrayStructField()
	{
		CanUnmarshallSystemReflectionFieldInfoArrayStructField_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern FieldInfo CanUnmarshallScriptingFieldInfoObjectPtrToFieldInfo();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern FieldInfo CanUnmarshallScriptingFieldPtrToFieldInfo();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern FieldInfo[] CanUnmarshallScriptingArrayPtrToFieldInfoArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern FieldInfo[] CanUnmarshallArrayOfScriptingFieldInfoObjectPtrToFieldInfoArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern FieldInfo[] CanUnmarshallArrayOfScriptingFieldPtrToFieldInfoArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanMarshallFieldInfoArgumentToScriptingFieldPtr_Injected(FieldInfo param, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanMarshallSystemReflectionFieldInfoStructField_Injected([In] ref StructSystemReflectionFieldInfo param, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] CanMarshallSystemReflectionFieldInfoArrayStructField_Injected([In] ref StructSystemReflectionFieldInfoArray param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanUnmarshallSystemReflectionFieldInfoStructField_Injected(out StructSystemReflectionFieldInfo ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanUnmarshallSystemReflectionFieldInfoArrayStructField_Injected(out StructSystemReflectionFieldInfoArray ret);
}
[ExcludeFromDocs]
internal struct StructSystemReflectionMethodInfo
{
	public MethodInfo field;
}
[ExcludeFromDocs]
internal struct StructSystemReflectionMethodInfoArray
{
	public MethodInfo[] field;
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/SystemReflectionMethodInfoMarshallingTests.h")]
internal static class SystemReflectionMethodInfoMarshallingTests
{
	public static string CanMarshallMethodInfoArgumentToScriptingMethodPtr(MethodInfo param)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			CanMarshallMethodInfoArgumentToScriptingMethodPtr_Injected(param, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string CanMarshallSystemReflectionMethodInfoStructField(StructSystemReflectionMethodInfo param)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			CanMarshallSystemReflectionMethodInfoStructField_Injected(ref param, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static string[] CanMarshallSystemReflectionMethodInfoArrayStructField(StructSystemReflectionMethodInfoArray param)
	{
		return CanMarshallSystemReflectionMethodInfoArrayStructField_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] CanMarshallArrayOfMethodInfoArgumentToDynamicArrayOfScriptingMethodInfoObjectPtr(MethodInfo[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] CanMarshallArrayOfMethodInfoArgumentToDynamicArrayOfScriptingMethodPtr(MethodInfo[] param);

	public static StructSystemReflectionMethodInfo CanUnmarshallSystemReflectionMethodInfoStructField()
	{
		CanUnmarshallSystemReflectionMethodInfoStructField_Injected(out var ret);
		return ret;
	}

	public static StructSystemReflectionMethodInfoArray CanUnmarshallSystemReflectionMethodInfoArrayStructField()
	{
		CanUnmarshallSystemReflectionMethodInfoArrayStructField_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MethodInfo CanUnmarshallScriptingMethodInfoObjectPtrToMethodInfo();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MethodInfo CanUnmarshallScriptingMethodPtrToMethodInfo();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MethodInfo[] CanUnmarshallScriptingArrayPtrToMethodInfoArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MethodInfo[] CanUnmarshallArrayOfScriptingMethodInfoObjectPtrToMethodInfoArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern MethodInfo[] CanUnmarshallArrayOfScriptingMethodPtrToMethodInfoArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanMarshallMethodInfoArgumentToScriptingMethodPtr_Injected(MethodInfo param, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanMarshallSystemReflectionMethodInfoStructField_Injected([In] ref StructSystemReflectionMethodInfo param, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] CanMarshallSystemReflectionMethodInfoArrayStructField_Injected([In] ref StructSystemReflectionMethodInfoArray param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanUnmarshallSystemReflectionMethodInfoStructField_Injected(out StructSystemReflectionMethodInfo ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanUnmarshallSystemReflectionMethodInfoArrayStructField_Injected(out StructSystemReflectionMethodInfoArray ret);
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal struct StructWithExternTests
{
	public int a;

	[MethodImpl(MethodImplOptions.InternalCall)]
	public extern int GetTimesTwo();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public extern void SetTimesThree();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public extern int ParameterWritable([Writable] Object unityObject);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterInt(int param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern int ReturnInt();
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal class DelegateTests
{
	public delegate int SomeDelegate();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate int SomeDelegateFunctionPtr();

	public static int A()
	{
		return 882;
	}

	[MonoPInvokeCallback(typeof(SomeDelegateFunctionPtr))]
	public static int B()
	{
		return 883;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern int ReturnDelegate(SomeDelegate someDelegate);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern int ReturnDelegateFunctionPtr(SomeDelegateFunctionPtr SomeDelegateFunctionPtr);
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal class ExceptionTests
{
	[NativeThrows]
	public static extern int PropertyThatCanThrow
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	public static extern int PropertyGetThatCanThrow
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	public static extern int PropertySetThatCanThrow
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		set;
	}

	[NativeThrows]
	public unsafe static void VoidReturnStringParameter(string param)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(param, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(param);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					VoidReturnStringParameter_Injected(ref managedSpanWrapper);
					return;
				}
			}
			VoidReturnStringParameter_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern int NonUnmarshallingReturn();

	[NativeThrows]
	public static string UnmarshallingReturn()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			UnmarshallingReturn_Injected(out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[NativeThrows]
	public static StructInt BlittableStructReturn()
	{
		BlittableStructReturn_Injected(out var ret);
		return ret;
	}

	[NativeThrows]
	public static StructCoreString NonblittableStructReturn()
	{
		NonblittableStructReturn_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void VoidReturnStringParameter_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void UnmarshallingReturn_Injected(out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void BlittableStructReturn_Injected(out StructInt ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void NonblittableStructReturn_Injected(out StructCoreString ret);
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal class ExceptionTypeTests
{
	[NativeThrows]
	public unsafe static void NullReferenceException(string nativeFormat, string values)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper nativeFormat2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(nativeFormat, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(nativeFormat);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					nativeFormat2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(values, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(values);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							NullReferenceException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
							return;
						}
					}
					NullReferenceException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
					return;
				}
			}
			nativeFormat2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(values, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(values);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					NullReferenceException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
					return;
				}
			}
			NullReferenceException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ArgumentNullException(string argumentName)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(argumentName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(argumentName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ArgumentNullException_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ArgumentNullException_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ArgumentException(string nativeFormat, string values)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper nativeFormat2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(nativeFormat, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(nativeFormat);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					nativeFormat2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(values, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(values);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							ArgumentException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
							return;
						}
					}
					ArgumentException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
					return;
				}
			}
			nativeFormat2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(values, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(values);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					ArgumentException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
					return;
				}
			}
			ArgumentException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void InvalidOperationException(string nativeFormat, string values)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper nativeFormat2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(nativeFormat, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(nativeFormat);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					nativeFormat2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(values, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(values);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							InvalidOperationException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
							return;
						}
					}
					InvalidOperationException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
					return;
				}
			}
			nativeFormat2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(values, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(values);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					InvalidOperationException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
					return;
				}
			}
			InvalidOperationException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void IndexOutOfRangeException(string nativeFormat, int index)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(nativeFormat, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(nativeFormat);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					IndexOutOfRangeException_Injected(ref managedSpanWrapper, index);
					return;
				}
			}
			IndexOutOfRangeException_Injected(ref managedSpanWrapper, index);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void NullReferenceException_Injected(ref ManagedSpanWrapper nativeFormat, ref ManagedSpanWrapper values);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ArgumentNullException_Injected(ref ManagedSpanWrapper argumentName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ArgumentException_Injected(ref ManagedSpanWrapper nativeFormat, ref ManagedSpanWrapper values);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InvalidOperationException_Injected(ref ManagedSpanWrapper nativeFormat, ref ManagedSpanWrapper values);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void IndexOutOfRangeException_Injected(ref ManagedSpanWrapper nativeFormat, int index);
}
[ExcludeFromDocs]
internal enum SomeEnum
{
	A,
	B,
	C
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal class EnumTests
{
	[NativeThrows]
	public unsafe static void ParameterDynamicArrayEnum(SomeEnum[] enumArray)
	{
		Span<SomeEnum> span = new Span<SomeEnum>(enumArray);
		fixed (SomeEnum* begin = span)
		{
			ManagedSpanWrapper enumArray2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterDynamicArrayEnum_Injected(ref enumArray2);
		}
	}

	public unsafe static void ParameterOutDynamicArrayEnum([Out] SomeEnum[] enumArray)
	{
		//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper enumArray2 = default(BlittableArrayWrapper);
		try
		{
			if (enumArray != null)
			{
				fixed (SomeEnum[] array = enumArray)
				{
					if (array.Length != 0)
					{
						enumArray2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					ParameterOutDynamicArrayEnum_Injected(out enumArray2);
					return;
				}
			}
			ParameterOutDynamicArrayEnum_Injected(out enumArray2);
		}
		finally
		{
			enumArray2.Unmarshal(ref array);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterDynamicArrayEnum_Injected(ref ManagedSpanWrapper enumArray);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterOutDynamicArrayEnum_Injected(out BlittableArrayWrapper enumArray);
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal struct StructWithStringIntAndFloat
{
	public string a;

	public int b;

	public float c;

	public override bool Equals(object other)
	{
		if (other == null)
		{
			return false;
		}
		if (other is StructWithStringIntAndFloat structWithStringIntAndFloat)
		{
			return a.Equals(structWithStringIntAndFloat.a) && b == structWithStringIntAndFloat.b && c == structWithStringIntAndFloat.c;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return a.GetHashCode();
	}
}
[ExcludeFromDocs]
internal struct StructWithStringIntAndFloat2
{
	public string a;

	public int b;

	public float c;
}
[ExcludeFromDocs]
internal struct StructWithStringIgnoredIntAndFloat
{
	public string a;

	[Ignore]
	public int b;

	public float c;
}
[StructLayout(LayoutKind.Sequential)]
[NativeAsStruct]
[ExcludeFromDocs]
internal class ClassToStruct
{
	public int intField;

	public string stringField;
}
[ExcludeFromDocs]
internal struct StructWithClassToStruct
{
	public ClassToStruct classToStructField;
}
[ExcludeFromDocs]
internal struct StructWithNonBlittableArrayField
{
	public StructWithStringIntAndFloat[] field;
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal class NonBlittableStructTests
{
	[NativeThrows]
	public static void ParameterStructWithStringIntAndFloat(StructWithStringIntAndFloat param)
	{
		ParameterStructWithStringIntAndFloat_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void RefParameterStructWithStringIntAndFloat(ref StructWithStringIntAndFloat param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void OutParameterStructWithStringIntAndFloat(out StructWithStringIntAndFloat param);

	public static void ParameterStructWithStringIntAndFloat2(StructWithStringIntAndFloat2 param)
	{
		ParameterStructWithStringIntAndFloat2_Injected(ref param);
	}

	[NativeThrows]
	public static void ParameterStructWithStringIgnoredIntAndFloat(StructWithStringIgnoredIntAndFloat param)
	{
		ParameterStructWithStringIgnoredIntAndFloat_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void ParameterStructWithStringIntAndFloatArray(StructWithStringIntAndFloat[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern StructWithStringIntAndFloat[] ReturnStructWithStringIntAndFloatArray();

	[NativeThrows]
	public static void ParameterStructWithNonBlittableArrayField(StructWithNonBlittableArrayField param)
	{
		ParameterStructWithNonBlittableArrayField_Injected(ref param);
	}

	public static StructWithNonBlittableArrayField ReturnStructWithNonBlittableArrayField()
	{
		ReturnStructWithNonBlittableArrayField_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void CanMarshalManagedObjectToStruct(ClassToStruct param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void CanMarshalOutManagedObjectToStruct([Out] ClassToStruct param);

	[NativeThrows]
	public static void CanMarshalStructWithNativeAsStructField(StructWithClassToStruct param)
	{
		CanMarshalStructWithNativeAsStructField_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	public static extern void CanMarshalNativeAsStructArray(ClassToStruct[] param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern ClassToStruct CanUnmarshalManagedObjectFromStruct();

	public static StructWithClassToStruct CanUnmarshalStructWithNativeAsStructField()
	{
		CanUnmarshalStructWithNativeAsStructField_Injected(out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern ClassToStruct[] CanUnmarshalNativeAsStructArray();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructWithStringIntAndFloat_Injected([In] ref StructWithStringIntAndFloat param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructWithStringIntAndFloat2_Injected([In] ref StructWithStringIntAndFloat2 param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructWithStringIgnoredIntAndFloat_Injected([In] ref StructWithStringIgnoredIntAndFloat param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructWithNonBlittableArrayField_Injected([In] ref StructWithNonBlittableArrayField param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnStructWithNonBlittableArrayField_Injected(out StructWithNonBlittableArrayField ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanMarshalStructWithNativeAsStructField_Injected([In] ref StructWithClassToStruct param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CanUnmarshalStructWithNativeAsStructField_Injected(out StructWithClassToStruct ret);
}
[ExcludeFromDocs]
[NativeType]
internal struct StructWithTypedefManagedName
{
	private bool a;
}
[ExcludeFromDocs]
[NativeType(Header = "Modules/Marshalling/MarshallingTests.h")]
internal class TypedefManagedNameTests
{
	public static void ParameterStructWithTypedefManagedName(StructWithTypedefManagedName param)
	{
		ParameterStructWithTypedefManagedName_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructWithTypedefManagedName_Injected([In] ref StructWithTypedefManagedName param);
}
[NativeType("Modules/Marshalling/MarshallingTests.h")]
internal class FieldBoundPropertyTests
{
	[NativeProperty(TargetType = TargetType.Field)]
	public static extern int StaticProp
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[NativeProperty("foo", false, TargetType.Field)]
	[StaticAccessor("FieldBoundPropertyTests::GetNativeStaticPropContainer()", StaticAccessorType.Dot)]
	public static extern int StaticAccessorProp
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/OutArrayMarshallingTests.h")]
internal static class OutArrayMarshallingTests
{
	public unsafe static void OutArrayOfPrimitiveTypeWorks([Out] int[] array, int value)
	{
		//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper array3 = default(BlittableArrayWrapper);
		try
		{
			if (array != null)
			{
				fixed (int[] array2 = array)
				{
					if (array2.Length != 0)
					{
						array3 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
					}
					OutArrayOfPrimitiveTypeWorks_Injected(out array3, value);
					return;
				}
			}
			OutArrayOfPrimitiveTypeWorks_Injected(out array3, value);
		}
		finally
		{
			array3.Unmarshal(ref array2);
		}
	}

	public unsafe static void OutArrayOfStringTypeWorks([Out] string[] array, string value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					OutArrayOfStringTypeWorks_Injected(array, ref managedSpanWrapper);
					return;
				}
			}
			OutArrayOfStringTypeWorks_Injected(array, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	public unsafe static void OutArrayOfBlittableStructTypeWorks([Out] StructInt[] array, StructInt value)
	{
		//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper array3 = default(BlittableArrayWrapper);
		try
		{
			if (array != null)
			{
				fixed (StructInt[] array2 = array)
				{
					if (array2.Length != 0)
					{
						array3 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
					}
					OutArrayOfBlittableStructTypeWorks_Injected(out array3, ref value);
					return;
				}
			}
			OutArrayOfBlittableStructTypeWorks_Injected(out array3, ref value);
		}
		finally
		{
			array3.Unmarshal(ref array2);
		}
	}

	public static void OutArrayOfIntPtrObjectTypeWorks([Out] MyIntPtrObject[] array, MyIntPtrObject value)
	{
		OutArrayOfIntPtrObjectTypeWorks_Injected(array, (value == null) ? ((IntPtr)0) : MyIntPtrObject.BindingsMarshaller.ConvertToNative(value));
	}

	public unsafe static void OutArrayOfNestedBlittableStructTypeWorks([Out] StructNestedBlittable[] array, StructNestedBlittable value)
	{
		//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper array3 = default(BlittableArrayWrapper);
		try
		{
			if (array != null)
			{
				fixed (StructNestedBlittable[] array2 = array)
				{
					if (array2.Length != 0)
					{
						array3 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
					}
					OutArrayOfNestedBlittableStructTypeWorks_Injected(out array3, ref value);
					return;
				}
			}
			OutArrayOfNestedBlittableStructTypeWorks_Injected(out array3, ref value);
		}
		finally
		{
			array3.Unmarshal(ref array2);
		}
	}

	public static void OutArrayOfNonBlittableTypeWorks([Out] StructWithStringIntAndFloat[] array, StructWithStringIntAndFloat value)
	{
		OutArrayOfNonBlittableTypeWorks_Injected(array, ref value);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void OutArrayOfPrimitiveTypeWorks_Injected(out BlittableArrayWrapper array, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void OutArrayOfStringTypeWorks_Injected([Out] string[] array, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void OutArrayOfBlittableStructTypeWorks_Injected(out BlittableArrayWrapper array, [In] ref StructInt value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void OutArrayOfIntPtrObjectTypeWorks_Injected([Out] MyIntPtrObject[] array, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void OutArrayOfNestedBlittableStructTypeWorks_Injected(out BlittableArrayWrapper array, [In] ref StructNestedBlittable value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void OutArrayOfNonBlittableTypeWorks_Injected([Out] StructWithStringIntAndFloat[] array, [In] ref StructWithStringIntAndFloat value);
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/ReturnArrayMarshallingTests.h")]
internal static class ReturnArrayMarshallingTests
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	[return: Unmarshalled]
	public static extern float[] ReturnArrayOfPrimitiveTypeWorks_Float1D();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[return: Unmarshalled]
	public static extern float[,] ReturnArrayOfPrimitiveTypeWorks_Float2D();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[return: Unmarshalled]
	public static extern float[,,] ReturnArrayOfPrimitiveTypeWorks_Float3D();
}
internal class ParentOfNested
{
	internal class Nested
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int MethodInNested();
	}
}
[NativeType(Header = "Modules/Marshalling/MarshallingTests.h")]
internal abstract class AbstractClass
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern int MethodInAbstractClass();
}
internal struct StructWith8ByteAndBoolFields
{
	public long int64;

	public bool bool1;

	public bool bool2;

	public bool bool3;
}
[ExcludeFromDocs]
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
internal class BoolStructTests
{
	[NativeThrows]
	public static void ParameterStructWith8ByteAndBoolFields(StructWith8ByteAndBoolFields param)
	{
		ParameterStructWith8ByteAndBoolFields_Injected(ref param);
	}

	[NativeThrows]
	public unsafe static void ParameterStructWith8ByteAndBoolFieldsArray(StructWith8ByteAndBoolFields[] param)
	{
		Span<StructWith8ByteAndBoolFields> span = new Span<StructWith8ByteAndBoolFields>(param);
		fixed (StructWith8ByteAndBoolFields* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterStructWith8ByteAndBoolFieldsArray_Injected(ref param2);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructWith8ByteAndBoolFields_Injected([In] ref StructWith8ByteAndBoolFields param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterStructWith8ByteAndBoolFieldsArray_Injected(ref ManagedSpanWrapper param);
}
internal struct BlittableCornerCases
{
	public char cVal;

	public bool bVal;

	public SomeEnum eVal;
}
[NativeType("Modules/Marshalling/MarshallingTests.h")]
internal class ValueTypeArrayTests
{
	[NativeThrows]
	public unsafe static void ParameterIntArrayReadOnly(int[] param)
	{
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterIntArrayReadOnly_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterIntArrayWritable(int[] param)
	{
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterIntArrayWritable_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterIntArrayEmpty(int[] param, int[] param2)
	{
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param3 = new ManagedSpanWrapper(begin, span.Length);
			Span<int> span2 = new Span<int>(param2);
			fixed (int* begin2 = span2)
			{
				ManagedSpanWrapper param4 = new ManagedSpanWrapper(begin2, span2.Length);
				ParameterIntArrayEmpty_Injected(ref param3, ref param4);
			}
		}
	}

	public unsafe static void ParameterIntArrayNullExceptions([NotNull] int[] param)
	{
		if (param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		Span<int> span = new Span<int>(param);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterIntArrayNullExceptions_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterIntMultidimensionalArray(int[,] param)
	{
		fixed (int[,] array = param)
		{
			int length;
			nint begin;
			if (param == null || (length = array.Length) == 0)
			{
				length = 0;
				begin = 0;
			}
			else
			{
				begin = (nint)Unsafe.AsPointer(ref array[0, 0]);
			}
			ManagedSpanWrapper param2 = new ManagedSpanWrapper((void*)begin, length);
			ParameterIntMultidimensionalArray_Injected(ref param2);
		}
	}

	public unsafe static void ParameterIntMultidimensionalArrayNullExceptions([NotNull] int[,] param)
	{
		if (param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		fixed (int[,] array = param)
		{
			int length;
			nint begin;
			if (param == null || (length = array.Length) == 0)
			{
				length = 0;
				begin = 0;
			}
			else
			{
				begin = (nint)Unsafe.AsPointer(ref array[0, 0]);
			}
			ManagedSpanWrapper param2 = new ManagedSpanWrapper((void*)begin, length);
			ParameterIntMultidimensionalArrayNullExceptions_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterCharArrayReadOnly(char[] param)
	{
		Span<char> span = new Span<char>(param);
		fixed (char* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterCharArrayReadOnly_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterBlittableCornerCaseStructArrayReadOnly(BlittableCornerCases[] param)
	{
		Span<BlittableCornerCases> span = new Span<BlittableCornerCases>(param);
		fixed (BlittableCornerCases* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterBlittableCornerCaseStructArrayReadOnly_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterIntArrayOutAttr([Out] int[] param)
	{
		//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper param2 = default(BlittableArrayWrapper);
		try
		{
			if (param != null)
			{
				fixed (int[] array = param)
				{
					if (array.Length != 0)
					{
						param2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					ParameterIntArrayOutAttr_Injected(out param2);
					return;
				}
			}
			ParameterIntArrayOutAttr_Injected(out param2);
		}
		finally
		{
			param2.Unmarshal(ref array);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterCharArrayOutAttr([Out] char[] param)
	{
		//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper param2 = default(BlittableArrayWrapper);
		try
		{
			if (param != null)
			{
				fixed (char[] array = param)
				{
					if (array.Length != 0)
					{
						param2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					ParameterCharArrayOutAttr_Injected(out param2);
					return;
				}
			}
			ParameterCharArrayOutAttr_Injected(out param2);
		}
		finally
		{
			param2.Unmarshal(ref array);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterBlittableCornerCaseStructArrayOutAttr([Out] BlittableCornerCases[] param)
	{
		//The blocks IL_001b are reachable both inside and outside the pinned region starting at IL_0004. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		BlittableArrayWrapper param2 = default(BlittableArrayWrapper);
		try
		{
			if (param != null)
			{
				fixed (BlittableCornerCases[] array = param)
				{
					if (array.Length != 0)
					{
						param2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					ParameterBlittableCornerCaseStructArrayOutAttr_Injected(out param2);
					return;
				}
			}
			ParameterBlittableCornerCaseStructArrayOutAttr_Injected(out param2);
		}
		finally
		{
			param2.Unmarshal(ref array);
		}
	}

	public static int[] ParameterIntArrayReturn()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		int[] result;
		try
		{
			ParameterIntArrayReturn_Injected(out ret);
		}
		finally
		{
			int[] array = default(int[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static int[] ParameterIntArrayReturnEmpty()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		int[] result;
		try
		{
			ParameterIntArrayReturnEmpty_Injected(out ret);
		}
		finally
		{
			int[] array = default(int[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static int[] ParameterIntArrayReturnNull()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		int[] result;
		try
		{
			ParameterIntArrayReturnNull_Injected(out ret);
		}
		finally
		{
			int[] array = default(int[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static char[] ParameterCharArrayReturn()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		char[] result;
		try
		{
			ParameterCharArrayReturn_Injected(out ret);
		}
		finally
		{
			char[] array = default(char[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public static BlittableCornerCases[] ParameterBlittableCornerCaseStructArrayReturn()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		BlittableCornerCases[] result;
		try
		{
			ParameterBlittableCornerCaseStructArrayReturn_Injected(out ret);
		}
		finally
		{
			BlittableCornerCases[] array = default(BlittableCornerCases[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayReadOnly_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayWritable_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayEmpty_Injected(ref ManagedSpanWrapper param, ref ManagedSpanWrapper param2);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayNullExceptions_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntMultidimensionalArray_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntMultidimensionalArrayNullExceptions_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterCharArrayReadOnly_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterBlittableCornerCaseStructArrayReadOnly_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayOutAttr_Injected(out BlittableArrayWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterCharArrayOutAttr_Injected(out BlittableArrayWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterBlittableCornerCaseStructArrayOutAttr_Injected(out BlittableArrayWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayReturn_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayReturnEmpty_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntArrayReturnNull_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterCharArrayReturn_Injected(out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterBlittableCornerCaseStructArrayReturn_Injected(out BlittableArrayWrapper ret);
}
[NativeType("Modules/Marshalling/MarshallingTests.h")]
internal class ValueTypeSpanTests
{
	[NativeThrows]
	public unsafe static void ParameterIntReadOnlySpan(ReadOnlySpan<int> param)
	{
		ReadOnlySpan<int> readOnlySpan = param;
		fixed (int* begin = readOnlySpan)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			ParameterIntReadOnlySpan_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterIntSpan(Span<int> param)
	{
		Span<int> span = param;
		fixed (int* begin = span)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, span.Length);
			ParameterIntSpan_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterBoolReadOnlySpan(ReadOnlySpan<bool> param)
	{
		ReadOnlySpan<bool> readOnlySpan = param;
		fixed (bool* begin = readOnlySpan)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			ParameterBoolReadOnlySpan_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterCharReadOnlySpan(ReadOnlySpan<char> param)
	{
		ReadOnlySpan<char> readOnlySpan = param;
		fixed (char* begin = readOnlySpan)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			ParameterCharReadOnlySpan_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterEnumReadOnlySpan(ReadOnlySpan<SomeEnum> param)
	{
		ReadOnlySpan<SomeEnum> readOnlySpan = param;
		fixed (SomeEnum* begin = readOnlySpan)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			ParameterEnumReadOnlySpan_Injected(ref param2);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterBlittableCornerCaseStructReadOnlySpan(ReadOnlySpan<BlittableCornerCases> param)
	{
		ReadOnlySpan<BlittableCornerCases> readOnlySpan = param;
		fixed (BlittableCornerCases* begin = readOnlySpan)
		{
			ManagedSpanWrapper param2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
			ParameterBlittableCornerCaseStructReadOnlySpan_Injected(ref param2);
		}
	}

	public static Span<int> ReturnsArrayRefWritableAsSpan(int val1, int val2, int val3)
	{
		ReturnsArrayRefWritableAsSpan_Injected(val1, val2, val3, out var ret);
		return ManagedSpanWrapper.ToSpan<int>(ret);
	}

	public static Span<int> ReturnsCoreVectorRefAsSpan(int val1, int val2, int val3)
	{
		ReturnsCoreVectorRefAsSpan_Injected(val1, val2, val3, out var ret);
		return ManagedSpanWrapper.ToSpan<int>(ret);
	}

	public static Span<int> ReturnsScriptingSpanAsSpan(int val1, int val2, int val3)
	{
		ReturnsScriptingSpanAsSpan_Injected(val1, val2, val3, out var ret);
		return ManagedSpanWrapper.ToSpan<int>(ret);
	}

	public static ReadOnlySpan<int> ReturnsArrayRefWritableAsReadOnlySpan(int val1, int val2, int val3)
	{
		ReturnsArrayRefWritableAsReadOnlySpan_Injected(val1, val2, val3, out var ret);
		return ManagedSpanWrapper.ToReadOnlySpan<int>(ret);
	}

	public static ReadOnlySpan<int> ReturnsCoreVectorRefAsReadOnlySpan(int val1, int val2, int val3)
	{
		ReturnsCoreVectorRefAsReadOnlySpan_Injected(val1, val2, val3, out var ret);
		return ManagedSpanWrapper.ToReadOnlySpan<int>(ret);
	}

	public static ReadOnlySpan<int> ReturnsArrayRefAsReadOnlySpan(int val1, int val2, int val3)
	{
		ReturnsArrayRefAsReadOnlySpan_Injected(val1, val2, val3, out var ret);
		return ManagedSpanWrapper.ToReadOnlySpan<int>(ret);
	}

	public static ReadOnlySpan<int> ReturnsScriptingReadOnlySpanAsSpan(int val1, int val2, int val3)
	{
		ReturnsScriptingReadOnlySpanAsSpan_Injected(val1, val2, val3, out var ret);
		return ManagedSpanWrapper.ToReadOnlySpan<int>(ret);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntReadOnlySpan_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterIntSpan_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterBoolReadOnlySpan_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterCharReadOnlySpan_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterEnumReadOnlySpan_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterBlittableCornerCaseStructReadOnlySpan_Injected(ref ManagedSpanWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnsArrayRefWritableAsSpan_Injected(int val1, int val2, int val3, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnsCoreVectorRefAsSpan_Injected(int val1, int val2, int val3, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnsScriptingSpanAsSpan_Injected(int val1, int val2, int val3, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnsArrayRefWritableAsReadOnlySpan_Injected(int val1, int val2, int val3, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnsCoreVectorRefAsReadOnlySpan_Injected(int val1, int val2, int val3, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnsArrayRefAsReadOnlySpan_Injected(int val1, int val2, int val3, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ReturnsScriptingReadOnlySpanAsSpan_Injected(int val1, int val2, int val3, out ManagedSpanWrapper ret);
}
[NativeType("Modules/Marshalling/MarshallingTests.h")]
internal class ValueTypeListOfTTests
{
	[NativeThrows]
	public unsafe static void ParameterListOfIntRead(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntRead_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntRead_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntReadChangeVaules(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntReadChangeVaules_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntReadChangeVaules_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntAddNoGrow(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntAddNoGrow_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntAddNoGrow_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntAddAndGrow(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntAddAndGrow_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntAddAndGrow_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntPassNullThrow([NotNull] List<int> param)
	{
		if (param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				param2 = new BlittableListWrapper(arrayWrapper, list.Count);
				ParameterListOfIntPassNullThrow_Injected(ref param2);
			}
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntPassNullNoThrow(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntPassNullNoThrow_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntPassNullNoThrow_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntNativeAllocateSmaller(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntNativeAllocateSmaller_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntNativeAllocateSmaller_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntNativeAttachOtherMemoryBlock(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntNativeAttachOtherMemoryBlock_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntNativeAttachOtherMemoryBlock_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntNativeCallsClear(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntNativeCallsClear_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntNativeCallsClear_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfBoolReadWrite(List<bool> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<bool> list = default(List<bool>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (bool[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfBoolReadWrite_Injected(ref param2);
					return;
				}
			}
			ParameterListOfBoolReadWrite_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfCharReadWrite(List<char> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<char> list = default(List<char>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (char[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfCharReadWrite_Injected(ref param2);
					return;
				}
			}
			ParameterListOfCharReadWrite_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfEnumReadWrite(List<SomeEnum> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<SomeEnum> list = default(List<SomeEnum>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (SomeEnum[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfEnumReadWrite_Injected(ref param2);
					return;
				}
			}
			ParameterListOfEnumReadWrite_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfCornerCaseStructReadWrite(List<BlittableCornerCases> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<BlittableCornerCases> list = default(List<BlittableCornerCases>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (BlittableCornerCases[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfCornerCaseStructReadWrite_Injected(ref param2);
					return;
				}
			}
			ParameterListOfCornerCaseStructReadWrite_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntRead_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntReadChangeVaules_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntAddNoGrow_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntAddAndGrow_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntPassNullThrow_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntPassNullNoThrow_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntNativeAllocateSmaller_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntNativeAttachOtherMemoryBlock_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntNativeCallsClear_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfBoolReadWrite_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfCharReadWrite_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfEnumReadWrite_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfCornerCaseStructReadWrite_Injected(ref BlittableListWrapper param);
}
[NativeType("Modules/Marshalling/MarshallingTests.h")]
internal class InvokeTests
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern bool TestInvokeBool(bool arg);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern sbyte TestInvokeSByte(sbyte arg);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern byte TestInvokeByte(byte arg);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern char TestInvokeChar(char arg);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern short TestInvokeShort(short arg);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern ushort TestInvokeUShort(ushort arg);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern int TestInvokeInt(int arg);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern uint TestInvokeUInt(uint arg);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern long TestInvokeLong(long arg);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern ulong TestInvokeULong(ulong arg);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern IntPtr TestInvokeIntPtr(IntPtr arg);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern UIntPtr TestInvokeUIntPtr(UIntPtr arg);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern float TestInvokeFloat(float arg);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern double TestInvokeDouble(double arg);

	[RequiredByNativeCode(Optional = true)]
	[UnityEngine.Scripting.RequiredMember]
	private static bool InvokeBool(bool arg)
	{
		return arg;
	}

	[RequiredByNativeCode(Optional = true)]
	[UnityEngine.Scripting.RequiredMember]
	private static sbyte InvokeSByte(sbyte arg)
	{
		return arg;
	}

	[RequiredByNativeCode(Optional = true)]
	[UnityEngine.Scripting.RequiredMember]
	private static byte InvokeByte(byte arg)
	{
		return arg;
	}

	[UnityEngine.Scripting.RequiredMember]
	[RequiredByNativeCode(Optional = true)]
	private static char InvokeChar(char arg)
	{
		return arg;
	}

	[UnityEngine.Scripting.RequiredMember]
	[RequiredByNativeCode(Optional = true)]
	private static short InvokeShort(short arg)
	{
		return arg;
	}

	[UnityEngine.Scripting.RequiredMember]
	[RequiredByNativeCode(Optional = true)]
	private static ushort InvokeUShort(ushort arg)
	{
		return arg;
	}

	[UnityEngine.Scripting.RequiredMember]
	[RequiredByNativeCode(Optional = true)]
	private static int InvokeInt(int arg)
	{
		return arg;
	}

	[UnityEngine.Scripting.RequiredMember]
	[RequiredByNativeCode(Optional = true)]
	private static uint InvokeUInt(uint arg)
	{
		return arg;
	}

	[UnityEngine.Scripting.RequiredMember]
	[RequiredByNativeCode(Optional = true)]
	private static long InvokeLong(long arg)
	{
		return arg;
	}

	[UnityEngine.Scripting.RequiredMember]
	[RequiredByNativeCode(Optional = true)]
	private static ulong InvokeULong(ulong arg)
	{
		return arg;
	}

	[UnityEngine.Scripting.RequiredMember]
	[RequiredByNativeCode(Optional = true)]
	private static IntPtr InvokeIntPtr(IntPtr arg)
	{
		return arg;
	}

	[UnityEngine.Scripting.RequiredMember]
	[RequiredByNativeCode(Optional = true)]
	private static UIntPtr InvokeUIntPtr(UIntPtr arg)
	{
		return arg;
	}

	[UnityEngine.Scripting.RequiredMember]
	[RequiredByNativeCode(Optional = true)]
	private static float InvokeFloat(float arg)
	{
		return arg;
	}

	[UnityEngine.Scripting.RequiredMember]
	[RequiredByNativeCode(Optional = true)]
	private static double InvokeDouble(double arg)
	{
		return arg;
	}
}
internal static class MarshallingTests
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	[FreeFunction("MarshallingTest::DisableMarshallingTestsVerification")]
	public static extern void DisableMarshallingTestsVerification();
}
[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal class MarshallingTests2
{
	public static void ParameterNonBlittableStructReuse(StructCoreString param)
	{
		ParameterNonBlittableStructReuse_Injected(ref param);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterNonBlittableStructReuse_Injected([In] ref StructCoreString param);
}
