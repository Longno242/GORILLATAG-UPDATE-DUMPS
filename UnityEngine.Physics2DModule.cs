using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

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
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestWWWModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubsystemsModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.SubstanceModule")]
[assembly: InternalsVisibleTo("UnityEngine.ParticleSystemModule")]
[assembly: InternalsVisibleTo("UnityEngine.VFXModule")]
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("Unity.DeploymentTests.Services")]
[assembly: InternalsVisibleTo("Unity.Burst.Editor")]
[assembly: InternalsVisibleTo("Unity.Burst")]
[assembly: InternalsVisibleTo("UnityEngine.TestRunner")]
[assembly: InternalsVisibleTo("UnityEngine.Purchasing")]
[assembly: InternalsVisibleTo("UnityEngine.Advertisements")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("UnityEngine.XRModule")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
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
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.2D")]
[assembly: InternalsVisibleTo("UnityEngine.NVIDIAModule")]
[assembly: InternalsVisibleTo("UnityEngine.MarshallingModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.ClusterRendererModule")]
[assembly: InternalsVisibleTo("UnityEngine.JSONSerializeModule")]
[assembly: InternalsVisibleTo("UnityEngine.AMDModule")]
[assembly: InternalsVisibleTo("UnityEngine.AIModule")]
[assembly: InternalsVisibleTo("UnityEngine.CoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.SharedInternalsModule")]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.PhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.MultiplayerModule")]
[assembly: InternalsVisibleTo("UnityEngine.ContentLoadModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.UnityConnectModule")]
[assembly: InternalsVisibleTo("UnityEngine.GridModule")]
[assembly: InternalsVisibleTo("UnityEngine.GameCenterModule")]
[assembly: InternalsVisibleTo("UnityEngine.ImageConversionModule")]
[assembly: InternalsVisibleTo("UnityEngine.GIModule")]
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("UnityEngine.GraphicsStateCollectionSerializerModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android")]
[assembly: InternalsVisibleTo("Unity.Automation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Tooling")]
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
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Deployment")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.006")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.007")]
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
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.009")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.008")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
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
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine;

[NativeHeader("Modules/Physics2D/Public/PhysicsSceneHandle2D.h")]
public struct PhysicsScene2D : IEquatable<PhysicsScene2D>
{
	private int m_Handle;

	public int subStepCount => SubStepCount_Internal(this);

	public float subStepLostTime => SubStepLostTime_Internal(this);

	public override string ToString()
	{
		return $"({m_Handle})";
	}

	public static bool operator ==(PhysicsScene2D lhs, PhysicsScene2D rhs)
	{
		return lhs.m_Handle == rhs.m_Handle;
	}

	public static bool operator !=(PhysicsScene2D lhs, PhysicsScene2D rhs)
	{
		return lhs.m_Handle != rhs.m_Handle;
	}

	public override int GetHashCode()
	{
		return m_Handle;
	}

	public override bool Equals(object other)
	{
		if (!(other is PhysicsScene2D physicsScene2D))
		{
			return false;
		}
		return m_Handle == physicsScene2D.m_Handle;
	}

	public bool Equals(PhysicsScene2D other)
	{
		return m_Handle == other.m_Handle;
	}

	public bool IsValid()
	{
		return IsValid_Internal(this);
	}

	[StaticAccessor("GetPhysicsManager2D()", StaticAccessorType.Arrow)]
	[NativeMethod("IsPhysicsSceneValid")]
	private static bool IsValid_Internal(PhysicsScene2D physicsScene)
	{
		return IsValid_Internal_Injected(ref physicsScene);
	}

	public bool IsEmpty()
	{
		if (IsValid())
		{
			return IsEmpty_Internal(this);
		}
		throw new InvalidOperationException("Cannot check if physics scene is empty as it is invalid.");
	}

	[NativeMethod("IsPhysicsWorldEmpty")]
	[StaticAccessor("GetPhysicsManager2D()", StaticAccessorType.Arrow)]
	private static bool IsEmpty_Internal(PhysicsScene2D physicsScene)
	{
		return IsEmpty_Internal_Injected(ref physicsScene);
	}

	[StaticAccessor("GetPhysicsManager2D()", StaticAccessorType.Arrow)]
	[NativeMethod("GetSubStepCount")]
	private static int SubStepCount_Internal(PhysicsScene2D physicsScene)
	{
		return SubStepCount_Internal_Injected(ref physicsScene);
	}

	[NativeMethod("GetSubStepLostTime")]
	[StaticAccessor("GetPhysicsManager2D()", StaticAccessorType.Arrow)]
	private static float SubStepLostTime_Internal(PhysicsScene2D physicsScene)
	{
		return SubStepLostTime_Internal_Injected(ref physicsScene);
	}

	[ExcludeFromDocs]
	public bool Simulate(float deltaTime)
	{
		return Simulate(deltaTime, -1);
	}

	public bool Simulate(float deltaTime, [UnityEngine.Internal.DefaultValue("Physics2D.AllLayers")] int simulationLayers = -1)
	{
		if (IsValid())
		{
			return Physics2D.Simulate_Internal(this, deltaTime, simulationLayers);
		}
		throw new InvalidOperationException("Cannot simulate the physics scene as it is invalid.");
	}

	public RaycastHit2D Linecast(Vector2 start, Vector2 end, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return Linecast_Internal(this, start, end, contactFilter);
	}

	public RaycastHit2D Linecast(Vector2 start, Vector2 end, ContactFilter2D contactFilter)
	{
		return Linecast_Internal(this, start, end, contactFilter);
	}

	public int Linecast(Vector2 start, Vector2 end, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return LinecastArray_Internal(this, start, end, contactFilter, results);
	}

	public int Linecast(Vector2 start, Vector2 end, ContactFilter2D contactFilter, RaycastHit2D[] results)
	{
		return LinecastArray_Internal(this, start, end, contactFilter, results);
	}

	public int Linecast(Vector2 start, Vector2 end, ContactFilter2D contactFilter, List<RaycastHit2D> results)
	{
		return LinecastList_Internal(this, start, end, contactFilter, results);
	}

	[NativeMethod("Linecast_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static RaycastHit2D Linecast_Internal(PhysicsScene2D physicsScene, Vector2 start, Vector2 end, ContactFilter2D contactFilter)
	{
		Linecast_Internal_Injected(ref physicsScene, ref start, ref end, ref contactFilter, out var ret);
		return ret;
	}

	[NativeMethod("LinecastArray_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private unsafe static int LinecastArray_Internal(PhysicsScene2D physicsScene, Vector2 start, Vector2 end, ContactFilter2D contactFilter, [NotNull] RaycastHit2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		Span<RaycastHit2D> span = new Span<RaycastHit2D>(results);
		int result;
		fixed (RaycastHit2D* begin = span)
		{
			ManagedSpanWrapper results2 = new ManagedSpanWrapper(begin, span.Length);
			result = LinecastArray_Internal_Injected(ref physicsScene, ref start, ref end, ref contactFilter, ref results2);
		}
		return result;
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("LinecastList_Binding")]
	private unsafe static int LinecastList_Internal(PhysicsScene2D physicsScene, Vector2 start, Vector2 end, ContactFilter2D contactFilter, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return LinecastList_Internal_Injected(ref physicsScene, ref start, ref end, ref contactFilter, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	public RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return Raycast_Internal(this, origin, direction, distance, contactFilter);
	}

	public RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter)
	{
		return Raycast_Internal(this, origin, direction, distance, contactFilter);
	}

	public int Raycast(Vector2 origin, Vector2 direction, float distance, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return RaycastArray_Internal(this, origin, direction, distance, contactFilter, results);
	}

	public int Raycast(Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter, RaycastHit2D[] results)
	{
		return RaycastArray_Internal(this, origin, direction, distance, contactFilter, results);
	}

	public int Raycast(Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter, List<RaycastHit2D> results)
	{
		return RaycastList_Internal(this, origin, direction, distance, contactFilter, results);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("Raycast_Binding")]
	private static RaycastHit2D Raycast_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter)
	{
		Raycast_Internal_Injected(ref physicsScene, ref origin, ref direction, distance, ref contactFilter, out var ret);
		return ret;
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("RaycastArray_Binding")]
	private unsafe static int RaycastArray_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter, [NotNull] RaycastHit2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		Span<RaycastHit2D> span = new Span<RaycastHit2D>(results);
		int result;
		fixed (RaycastHit2D* begin = span)
		{
			ManagedSpanWrapper results2 = new ManagedSpanWrapper(begin, span.Length);
			result = RaycastArray_Internal_Injected(ref physicsScene, ref origin, ref direction, distance, ref contactFilter, ref results2);
		}
		return result;
	}

	[NativeMethod("RaycastList_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private unsafe static int RaycastList_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return RaycastList_Internal_Injected(ref physicsScene, ref origin, ref direction, distance, ref contactFilter, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	public RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return CircleCast_Internal(this, origin, radius, direction, distance, contactFilter);
	}

	public RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, ContactFilter2D contactFilter)
	{
		return CircleCast_Internal(this, origin, radius, direction, distance, contactFilter);
	}

	public int CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return CircleCastArray_Internal(this, origin, radius, direction, distance, contactFilter, results);
	}

	public int CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, ContactFilter2D contactFilter, RaycastHit2D[] results)
	{
		return CircleCastArray_Internal(this, origin, radius, direction, distance, contactFilter, results);
	}

	public int CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, ContactFilter2D contactFilter, List<RaycastHit2D> results)
	{
		return CircleCastList_Internal(this, origin, radius, direction, distance, contactFilter, results);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("CircleCast_Binding")]
	private static RaycastHit2D CircleCast_Internal(PhysicsScene2D physicsScene, Vector2 origin, float radius, Vector2 direction, float distance, ContactFilter2D contactFilter)
	{
		CircleCast_Internal_Injected(ref physicsScene, ref origin, radius, ref direction, distance, ref contactFilter, out var ret);
		return ret;
	}

	[NativeMethod("CircleCastArray_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private unsafe static int CircleCastArray_Internal(PhysicsScene2D physicsScene, Vector2 origin, float radius, Vector2 direction, float distance, ContactFilter2D contactFilter, [NotNull] RaycastHit2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		Span<RaycastHit2D> span = new Span<RaycastHit2D>(results);
		int result;
		fixed (RaycastHit2D* begin = span)
		{
			ManagedSpanWrapper results2 = new ManagedSpanWrapper(begin, span.Length);
			result = CircleCastArray_Internal_Injected(ref physicsScene, ref origin, radius, ref direction, distance, ref contactFilter, ref results2);
		}
		return result;
	}

	[NativeMethod("CircleCastList_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private unsafe static int CircleCastList_Internal(PhysicsScene2D physicsScene, Vector2 origin, float radius, Vector2 direction, float distance, ContactFilter2D contactFilter, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return CircleCastList_Internal_Injected(ref physicsScene, ref origin, radius, ref direction, distance, ref contactFilter, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	public RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return BoxCast_Internal(this, origin, size, angle, direction, distance, contactFilter);
	}

	public RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter)
	{
		return BoxCast_Internal(this, origin, size, angle, direction, distance, contactFilter);
	}

	public int BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return BoxCastArray_Internal(this, origin, size, angle, direction, distance, contactFilter, results);
	}

	public int BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter, RaycastHit2D[] results)
	{
		return BoxCastArray_Internal(this, origin, size, angle, direction, distance, contactFilter, results);
	}

	public int BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter, List<RaycastHit2D> results)
	{
		return BoxCastList_Internal(this, origin, size, angle, direction, distance, contactFilter, results);
	}

	[NativeMethod("BoxCast_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static RaycastHit2D BoxCast_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter)
	{
		BoxCast_Internal_Injected(ref physicsScene, ref origin, ref size, angle, ref direction, distance, ref contactFilter, out var ret);
		return ret;
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("BoxCastArray_Binding")]
	private unsafe static int BoxCastArray_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter, [NotNull] RaycastHit2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		Span<RaycastHit2D> span = new Span<RaycastHit2D>(results);
		int result;
		fixed (RaycastHit2D* begin = span)
		{
			ManagedSpanWrapper results2 = new ManagedSpanWrapper(begin, span.Length);
			result = BoxCastArray_Internal_Injected(ref physicsScene, ref origin, ref size, angle, ref direction, distance, ref contactFilter, ref results2);
		}
		return result;
	}

	[NativeMethod("BoxCastList_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private unsafe static int BoxCastList_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return BoxCastList_Internal_Injected(ref physicsScene, ref origin, ref size, angle, ref direction, distance, ref contactFilter, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	public RaycastHit2D CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return CapsuleCast_Internal(this, origin, size, capsuleDirection, angle, direction, distance, contactFilter);
	}

	public RaycastHit2D CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter)
	{
		return CapsuleCast_Internal(this, origin, size, capsuleDirection, angle, direction, distance, contactFilter);
	}

	public int CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return CapsuleCastArray_Internal(this, origin, size, capsuleDirection, angle, direction, distance, contactFilter, results);
	}

	public int CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter, RaycastHit2D[] results)
	{
		return CapsuleCastArray_Internal(this, origin, size, capsuleDirection, angle, direction, distance, contactFilter, results);
	}

	public int CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter, List<RaycastHit2D> results)
	{
		return CapsuleCastList_Internal(this, origin, size, capsuleDirection, angle, direction, distance, contactFilter, results);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("CapsuleCast_Binding")]
	private static RaycastHit2D CapsuleCast_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter)
	{
		CapsuleCast_Internal_Injected(ref physicsScene, ref origin, ref size, capsuleDirection, angle, ref direction, distance, ref contactFilter, out var ret);
		return ret;
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("CapsuleCastArray_Binding")]
	private unsafe static int CapsuleCastArray_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter, [NotNull] RaycastHit2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		Span<RaycastHit2D> span = new Span<RaycastHit2D>(results);
		int result;
		fixed (RaycastHit2D* begin = span)
		{
			ManagedSpanWrapper results2 = new ManagedSpanWrapper(begin, span.Length);
			result = CapsuleCastArray_Internal_Injected(ref physicsScene, ref origin, ref size, capsuleDirection, angle, ref direction, distance, ref contactFilter, ref results2);
		}
		return result;
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("CapsuleCastList_Binding")]
	private unsafe static int CapsuleCastList_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return CapsuleCastList_Internal_Injected(ref physicsScene, ref origin, ref size, capsuleDirection, angle, ref direction, distance, ref contactFilter, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	public RaycastHit2D GetRayIntersection(Ray ray, float distance, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		return GetRayIntersection_Internal(this, ray.origin, ray.direction, distance, layerMask);
	}

	public int GetRayIntersection(Ray ray, float distance, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		return GetRayIntersectionArray_Internal(this, ray.origin, ray.direction, distance, layerMask, results);
	}

	public int GetRayIntersection(Ray ray, float distance, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		return GetRayIntersectionList_Internal(this, ray.origin, ray.direction, distance, layerMask, results);
	}

	[NativeMethod("GetRayIntersection_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static RaycastHit2D GetRayIntersection_Internal(PhysicsScene2D physicsScene, Vector3 origin, Vector3 direction, float distance, int layerMask)
	{
		GetRayIntersection_Internal_Injected(ref physicsScene, ref origin, ref direction, distance, layerMask, out var ret);
		return ret;
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("GetRayIntersectionArray_Binding")]
	private unsafe static int GetRayIntersectionArray_Internal(PhysicsScene2D physicsScene, Vector3 origin, Vector3 direction, float distance, int layerMask, [NotNull] RaycastHit2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		Span<RaycastHit2D> span = new Span<RaycastHit2D>(results);
		int rayIntersectionArray_Internal_Injected;
		fixed (RaycastHit2D* begin = span)
		{
			ManagedSpanWrapper results2 = new ManagedSpanWrapper(begin, span.Length);
			rayIntersectionArray_Internal_Injected = GetRayIntersectionArray_Internal_Injected(ref physicsScene, ref origin, ref direction, distance, layerMask, ref results2);
		}
		return rayIntersectionArray_Internal_Injected;
	}

	[NativeMethod("GetRayIntersectionList_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private unsafe static int GetRayIntersectionList_Internal(PhysicsScene2D physicsScene, Vector3 origin, Vector3 direction, float distance, int layerMask, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return GetRayIntersectionList_Internal_Injected(ref physicsScene, ref origin, ref direction, distance, layerMask, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	public Collider2D OverlapPoint(Vector2 point, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapPoint_Internal(this, point, contactFilter);
	}

	public Collider2D OverlapPoint(Vector2 point, ContactFilter2D contactFilter)
	{
		return OverlapPoint_Internal(this, point, contactFilter);
	}

	public int OverlapPoint(Vector2 point, Collider2D[] results, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapPointArray_Internal(this, point, contactFilter, results);
	}

	public int OverlapPoint(Vector2 point, ContactFilter2D contactFilter, Collider2D[] results)
	{
		return OverlapPointArray_Internal(this, point, contactFilter, results);
	}

	public int OverlapPoint(Vector2 point, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return OverlapPointList_Internal(this, point, contactFilter, results);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("OverlapPoint_Binding")]
	private static Collider2D OverlapPoint_Internal(PhysicsScene2D physicsScene, Vector2 point, ContactFilter2D contactFilter)
	{
		return Unmarshal.UnmarshalUnityObject<Collider2D>(OverlapPoint_Internal_Injected(ref physicsScene, ref point, ref contactFilter));
	}

	[NativeMethod("OverlapPointArray_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static int OverlapPointArray_Internal(PhysicsScene2D physicsScene, Vector2 point, ContactFilter2D contactFilter, [Unmarshalled][NotNull] Collider2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		return OverlapPointArray_Internal_Injected(ref physicsScene, ref point, ref contactFilter, results);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("OverlapPointList_Binding")]
	private static int OverlapPointList_Internal(PhysicsScene2D physicsScene, Vector2 point, ContactFilter2D contactFilter, [NotNull] List<Collider2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		return OverlapPointList_Internal_Injected(ref physicsScene, ref point, ref contactFilter, results);
	}

	public Collider2D OverlapCircle(Vector2 point, float radius, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapCircle_Internal(this, point, radius, contactFilter);
	}

	public Collider2D OverlapCircle(Vector2 point, float radius, ContactFilter2D contactFilter)
	{
		return OverlapCircle_Internal(this, point, radius, contactFilter);
	}

	public int OverlapCircle(Vector2 point, float radius, Collider2D[] results, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapCircleArray_Internal(this, point, radius, contactFilter, results);
	}

	public int OverlapCircle(Vector2 point, float radius, ContactFilter2D contactFilter, Collider2D[] results)
	{
		return OverlapCircleArray_Internal(this, point, radius, contactFilter, results);
	}

	public int OverlapCircle(Vector2 point, float radius, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return OverlapCircleList_Internal(this, point, radius, contactFilter, results);
	}

	[NativeMethod("OverlapCircle_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static Collider2D OverlapCircle_Internal(PhysicsScene2D physicsScene, Vector2 point, float radius, ContactFilter2D contactFilter)
	{
		return Unmarshal.UnmarshalUnityObject<Collider2D>(OverlapCircle_Internal_Injected(ref physicsScene, ref point, radius, ref contactFilter));
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("OverlapCircleArray_Binding")]
	private static int OverlapCircleArray_Internal(PhysicsScene2D physicsScene, Vector2 point, float radius, ContactFilter2D contactFilter, [Unmarshalled][NotNull] Collider2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		return OverlapCircleArray_Internal_Injected(ref physicsScene, ref point, radius, ref contactFilter, results);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("OverlapCircleList_Binding")]
	private static int OverlapCircleList_Internal(PhysicsScene2D physicsScene, Vector2 point, float radius, ContactFilter2D contactFilter, [NotNull] List<Collider2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		return OverlapCircleList_Internal_Injected(ref physicsScene, ref point, radius, ref contactFilter, results);
	}

	public Collider2D OverlapBox(Vector2 point, Vector2 size, float angle, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapBox_Internal(this, point, size, angle, contactFilter);
	}

	public Collider2D OverlapBox(Vector2 point, Vector2 size, float angle, ContactFilter2D contactFilter)
	{
		return OverlapBox_Internal(this, point, size, angle, contactFilter);
	}

	public int OverlapBox(Vector2 point, Vector2 size, float angle, Collider2D[] results, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapBoxArray_Internal(this, point, size, angle, contactFilter, results);
	}

	public int OverlapBox(Vector2 point, Vector2 size, float angle, ContactFilter2D contactFilter, Collider2D[] results)
	{
		return OverlapBoxArray_Internal(this, point, size, angle, contactFilter, results);
	}

	public int OverlapBox(Vector2 point, Vector2 size, float angle, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return OverlapBoxList_Internal(this, point, size, angle, contactFilter, results);
	}

	[NativeMethod("OverlapBox_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static Collider2D OverlapBox_Internal(PhysicsScene2D physicsScene, Vector2 point, Vector2 size, float angle, ContactFilter2D contactFilter)
	{
		return Unmarshal.UnmarshalUnityObject<Collider2D>(OverlapBox_Internal_Injected(ref physicsScene, ref point, ref size, angle, ref contactFilter));
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("OverlapBoxArray_Binding")]
	private static int OverlapBoxArray_Internal(PhysicsScene2D physicsScene, Vector2 point, Vector2 size, float angle, ContactFilter2D contactFilter, [NotNull][Unmarshalled] Collider2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		return OverlapBoxArray_Internal_Injected(ref physicsScene, ref point, ref size, angle, ref contactFilter, results);
	}

	[NativeMethod("OverlapBoxList_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static int OverlapBoxList_Internal(PhysicsScene2D physicsScene, Vector2 point, Vector2 size, float angle, ContactFilter2D contactFilter, [NotNull] List<Collider2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		return OverlapBoxList_Internal_Injected(ref physicsScene, ref point, ref size, angle, ref contactFilter, results);
	}

	public Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapAreaToBoxArray_Internal(pointA, pointB, contactFilter);
	}

	public Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, ContactFilter2D contactFilter)
	{
		return OverlapAreaToBoxArray_Internal(pointA, pointB, contactFilter);
	}

	private Collider2D OverlapAreaToBoxArray_Internal(Vector2 pointA, Vector2 pointB, ContactFilter2D contactFilter)
	{
		Vector2 point = (pointA + pointB) * 0.5f;
		Vector2 size = new Vector2(Mathf.Abs(pointA.x - pointB.x), Math.Abs(pointA.y - pointB.y));
		return OverlapBox(point, size, 0f, contactFilter);
	}

	public int OverlapArea(Vector2 pointA, Vector2 pointB, Collider2D[] results, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapAreaToBoxArray_Internal(pointA, pointB, contactFilter, results);
	}

	public int OverlapArea(Vector2 pointA, Vector2 pointB, ContactFilter2D contactFilter, Collider2D[] results)
	{
		return OverlapAreaToBoxArray_Internal(pointA, pointB, contactFilter, results);
	}

	private int OverlapAreaToBoxArray_Internal(Vector2 pointA, Vector2 pointB, ContactFilter2D contactFilter, Collider2D[] results)
	{
		Vector2 point = (pointA + pointB) * 0.5f;
		Vector2 size = new Vector2(Mathf.Abs(pointA.x - pointB.x), Math.Abs(pointA.y - pointB.y));
		return OverlapBox(point, size, 0f, contactFilter, results);
	}

	public int OverlapArea(Vector2 pointA, Vector2 pointB, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return OverlapAreaToBoxList_Internal(pointA, pointB, contactFilter, results);
	}

	private int OverlapAreaToBoxList_Internal(Vector2 pointA, Vector2 pointB, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		Vector2 point = (pointA + pointB) * 0.5f;
		Vector2 size = new Vector2(Mathf.Abs(pointA.x - pointB.x), Math.Abs(pointA.y - pointB.y));
		return OverlapBox(point, size, 0f, contactFilter, results);
	}

	public Collider2D OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapCapsule_Internal(this, point, size, direction, angle, contactFilter);
	}

	public Collider2D OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, ContactFilter2D contactFilter)
	{
		return OverlapCapsule_Internal(this, point, size, direction, angle, contactFilter);
	}

	public int OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, Collider2D[] results, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapCapsuleArray_Internal(this, point, size, direction, angle, contactFilter, results);
	}

	public int OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, ContactFilter2D contactFilter, Collider2D[] results)
	{
		return OverlapCapsuleArray_Internal(this, point, size, direction, angle, contactFilter, results);
	}

	public int OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return OverlapCapsuleList_Internal(this, point, size, direction, angle, contactFilter, results);
	}

	[NativeMethod("OverlapCapsule_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static Collider2D OverlapCapsule_Internal(PhysicsScene2D physicsScene, Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, ContactFilter2D contactFilter)
	{
		return Unmarshal.UnmarshalUnityObject<Collider2D>(OverlapCapsule_Internal_Injected(ref physicsScene, ref point, ref size, direction, angle, ref contactFilter));
	}

	[NativeMethod("OverlapCapsuleArray_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static int OverlapCapsuleArray_Internal(PhysicsScene2D physicsScene, Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, ContactFilter2D contactFilter, [NotNull][Unmarshalled] Collider2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		return OverlapCapsuleArray_Internal_Injected(ref physicsScene, ref point, ref size, direction, angle, ref contactFilter, results);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("OverlapCapsuleList_Binding")]
	private static int OverlapCapsuleList_Internal(PhysicsScene2D physicsScene, Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, ContactFilter2D contactFilter, [NotNull] List<Collider2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		return OverlapCapsuleList_Internal_Injected(ref physicsScene, ref point, ref size, direction, angle, ref contactFilter, results);
	}

	public static int OverlapCollider(Collider2D collider, Collider2D[] results, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapColliderFilteredArray_Internal(collider, contactFilter, results);
	}

	public static int OverlapCollider(Collider2D collider, ContactFilter2D contactFilter, Collider2D[] results)
	{
		return OverlapColliderFilteredArray_Internal(collider, contactFilter, results);
	}

	public static int OverlapCollider(Collider2D collider, List<Collider2D> results)
	{
		return OverlapColliderList_Internal(collider, results);
	}

	public static int OverlapCollider(Collider2D collider, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return OverlapColliderFilteredList_Internal(collider, contactFilter, results);
	}

	public static int OverlapCollider(Vector2 position, float angle, Collider2D collider, List<Collider2D> results)
	{
		if ((bool)collider.attachedRigidbody)
		{
			return OverlapColliderFromList_Internal(position, angle, collider, results);
		}
		throw new InvalidOperationException("Cannot perform a Collider Overlap at a specific position and angle if the Collider is not attached to a Rigidbody2D.");
	}

	public static int OverlapCollider(Vector2 position, float angle, Collider2D collider, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		if ((bool)collider.attachedRigidbody)
		{
			return OverlapColliderFromFilteredList_Internal(position, angle, collider, contactFilter, results);
		}
		throw new InvalidOperationException("Cannot perform a Collider Overlap at a specific position and angle if the Collider is not attached to a Rigidbody2D.");
	}

	[NativeMethod("OverlapColliderFilteredArray_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static int OverlapColliderFilteredArray_Internal([NotNull] Collider2D collider, ContactFilter2D contactFilter, [NotNull][Unmarshalled] Collider2D[] results)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		return OverlapColliderFilteredArray_Internal_Injected(intPtr, ref contactFilter, results);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("OverlapColliderList_Binding")]
	private static int OverlapColliderList_Internal([NotNull] Collider2D collider, [NotNull] List<Collider2D> results)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		return OverlapColliderList_Internal_Injected(intPtr, results);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("OverlapColliderFilteredList_Binding")]
	private static int OverlapColliderFilteredList_Internal([NotNull] Collider2D collider, ContactFilter2D contactFilter, [NotNull] List<Collider2D> results)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		return OverlapColliderFilteredList_Internal_Injected(intPtr, ref contactFilter, results);
	}

	[NativeMethod("OverlapColliderFromList_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static int OverlapColliderFromList_Internal(Vector2 position, float angle, [NotNull] Collider2D collider, [NotNull] List<Collider2D> results)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		return OverlapColliderFromList_Internal_Injected(ref position, angle, intPtr, results);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("OverlapColliderFromFilteredList_Binding")]
	private static int OverlapColliderFromFilteredList_Internal(Vector2 position, float angle, [NotNull] Collider2D collider, ContactFilter2D contactFilter, [NotNull] List<Collider2D> results)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		return OverlapColliderFromFilteredList_Internal_Injected(ref position, angle, intPtr, ref contactFilter, results);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsValid_Internal_Injected([In] ref PhysicsScene2D physicsScene);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsEmpty_Internal_Injected([In] ref PhysicsScene2D physicsScene);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int SubStepCount_Internal_Injected([In] ref PhysicsScene2D physicsScene);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float SubStepLostTime_Internal_Injected([In] ref PhysicsScene2D physicsScene);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Linecast_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 start, [In] ref Vector2 end, [In] ref ContactFilter2D contactFilter, out RaycastHit2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int LinecastArray_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 start, [In] ref Vector2 end, [In] ref ContactFilter2D contactFilter, ref ManagedSpanWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int LinecastList_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 start, [In] ref Vector2 end, [In] ref ContactFilter2D contactFilter, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Raycast_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, out RaycastHit2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int RaycastArray_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, ref ManagedSpanWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int RaycastList_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CircleCast_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, float radius, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, out RaycastHit2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CircleCastArray_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, float radius, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, ref ManagedSpanWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CircleCastList_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, float radius, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void BoxCast_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, [In] ref Vector2 size, float angle, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, out RaycastHit2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int BoxCastArray_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, [In] ref Vector2 size, float angle, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, ref ManagedSpanWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int BoxCastList_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, [In] ref Vector2 size, float angle, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CapsuleCast_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, [In] ref Vector2 size, CapsuleDirection2D capsuleDirection, float angle, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, out RaycastHit2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CapsuleCastArray_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, [In] ref Vector2 size, CapsuleDirection2D capsuleDirection, float angle, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, ref ManagedSpanWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CapsuleCastList_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, [In] ref Vector2 size, CapsuleDirection2D capsuleDirection, float angle, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetRayIntersection_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector3 origin, [In] ref Vector3 direction, float distance, int layerMask, out RaycastHit2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetRayIntersectionArray_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector3 origin, [In] ref Vector3 direction, float distance, int layerMask, ref ManagedSpanWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetRayIntersectionList_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector3 origin, [In] ref Vector3 direction, float distance, int layerMask, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr OverlapPoint_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, [In] ref ContactFilter2D contactFilter);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapPointArray_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, [In] ref ContactFilter2D contactFilter, Collider2D[] results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapPointList_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, [In] ref ContactFilter2D contactFilter, List<Collider2D> results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr OverlapCircle_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, float radius, [In] ref ContactFilter2D contactFilter);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapCircleArray_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, float radius, [In] ref ContactFilter2D contactFilter, Collider2D[] results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapCircleList_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, float radius, [In] ref ContactFilter2D contactFilter, List<Collider2D> results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr OverlapBox_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, [In] ref Vector2 size, float angle, [In] ref ContactFilter2D contactFilter);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapBoxArray_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, [In] ref Vector2 size, float angle, [In] ref ContactFilter2D contactFilter, Collider2D[] results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapBoxList_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, [In] ref Vector2 size, float angle, [In] ref ContactFilter2D contactFilter, List<Collider2D> results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr OverlapCapsule_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, [In] ref Vector2 size, CapsuleDirection2D direction, float angle, [In] ref ContactFilter2D contactFilter);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapCapsuleArray_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, [In] ref Vector2 size, CapsuleDirection2D direction, float angle, [In] ref ContactFilter2D contactFilter, Collider2D[] results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapCapsuleList_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, [In] ref Vector2 size, CapsuleDirection2D direction, float angle, [In] ref ContactFilter2D contactFilter, List<Collider2D> results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapColliderFilteredArray_Internal_Injected(IntPtr collider, [In] ref ContactFilter2D contactFilter, Collider2D[] results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapColliderList_Internal_Injected(IntPtr collider, List<Collider2D> results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapColliderFilteredList_Internal_Injected(IntPtr collider, [In] ref ContactFilter2D contactFilter, List<Collider2D> results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapColliderFromList_Internal_Injected([In] ref Vector2 position, float angle, IntPtr collider, List<Collider2D> results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapColliderFromFilteredList_Internal_Injected([In] ref Vector2 position, float angle, IntPtr collider, [In] ref ContactFilter2D contactFilter, List<Collider2D> results);
}
public static class PhysicsSceneExtensions2D
{
	public static PhysicsScene2D GetPhysicsScene2D(this Scene scene)
	{
		if (!scene.IsValid())
		{
			throw new ArgumentException("Cannot get physics scene; Unity scene is invalid.", "scene");
		}
		PhysicsScene2D physicsScene_Internal = GetPhysicsScene_Internal(scene);
		if (physicsScene_Internal.IsValid())
		{
			return physicsScene_Internal;
		}
		throw new Exception("The physics scene associated with the Unity scene is invalid.");
	}

	[StaticAccessor("GetPhysicsManager2D()", StaticAccessorType.Arrow)]
	[NativeMethod("GetPhysicsSceneFromUnityScene")]
	private static PhysicsScene2D GetPhysicsScene_Internal(Scene scene)
	{
		GetPhysicsScene_Internal_Injected(ref scene, out var ret);
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetPhysicsScene_Internal_Injected([In] ref Scene scene, out PhysicsScene2D ret);
}
[StaticAccessor("GetPhysicsManager2D()", StaticAccessorType.Arrow)]
[NativeHeader("Physics2DScriptingClasses.h")]
[NativeHeader("Modules/Physics2D/PhysicsManager2D.h")]
[NativeHeader("Physics2DScriptingClasses.h")]
public class Physics2D
{
	[Flags]
	internal enum GizmoOptions
	{
		AllColliders = 1,
		CollidersOutlined = 2,
		CollidersFilled = 4,
		CollidersSleeping = 8,
		ColliderContacts = 0x10,
		ColliderBounds = 0x20
	}

	public const int IgnoreRaycastLayer = 4;

	public const int DefaultRaycastLayers = -5;

	public const int AllLayers = -1;

	public const int MaxPolygonShapeVertices = 8;

	private static List<Rigidbody2D> m_LastDisabledRigidbody2D = new List<Rigidbody2D>();

	public static PhysicsScene2D defaultPhysicsScene => default(PhysicsScene2D);

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern int velocityIterations
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern int positionIterations
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static Vector2 gravity
	{
		get
		{
			get_gravity_Injected(out var ret);
			return ret;
		}
		set
		{
			set_gravity_Injected(ref value);
		}
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern bool queriesHitTriggers
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern bool queriesStartInColliders
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern bool callbacksOnDisable
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern bool reuseCollisionCallbacks
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern bool autoSyncTransforms
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern SimulationMode2D simulationMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static LayerMask simulationLayers
	{
		get
		{
			get_simulationLayers_Injected(out var ret);
			return ret;
		}
		set
		{
			set_simulationLayers_Injected(ref value);
		}
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern bool useSubStepping
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern bool useSubStepContacts
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern float minSubStepFPS
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern int maxSubStepCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static PhysicsJobOptions2D jobOptions
	{
		get
		{
			get_jobOptions_Injected(out var ret);
			return ret;
		}
		set
		{
			set_jobOptions_Injected(ref value);
		}
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern float bounceThreshold
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern float contactThreshold
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern float maxLinearCorrection
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern float maxAngularCorrection
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern float maxTranslationSpeed
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern float maxRotationSpeed
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern float defaultContactOffset
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern float baumgarteScale
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern float baumgarteTOIScale
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern float timeToSleep
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern float linearSleepTolerance
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[StaticAccessor("GetPhysics2DSettings()")]
	public static extern float angularSleepTolerance
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	[Obsolete("Physics2D.raycastsHitTriggers is obsolete. Use Physics2D.queriesHitTriggers instead. (UnityUpgradable) -> queriesHitTriggers", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static bool raycastsHitTriggers
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Physics2D.raycastsStartInColliders is obsolete. Use Physics2D.queriesStartInColliders instead. (UnityUpgradable) -> queriesStartInColliders", true)]
	public static bool raycastsStartInColliders
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[Obsolete("Physics2D.deleteStopsCallbacks is obsolete.(UnityUpgradable) -> changeStopsCallbacks", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static bool deleteStopsCallbacks
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[Obsolete("Physics2D.changeStopsCallbacks is obsolete and will always return false.", true)]
	public static bool changeStopsCallbacks
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[Obsolete("Physics2D.minPenetrationForPenalty is obsolete. Use Physics2D.defaultContactOffset instead. (UnityUpgradable) -> defaultContactOffset", true)]
	public static float minPenetrationForPenalty
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[Obsolete("Physics2D.velocityThreshold is obsolete. Use Physics2D.bounceThreshold instead. (UnityUpgradable) -> bounceThreshold", true)]
	[ExcludeFromDocs]
	public static float velocityThreshold
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Physics2D.autoSimulation is obsolete. Use Physics2D.simulationMode instead.", true)]
	public static bool autoSimulation
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[ExcludeFromDocs]
	[Obsolete("Physics2D.colliderAwakeColor is obsolete. This options has been moved to 2D Preferences.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Color colliderAwakeColor
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[Obsolete("Physics2D.colliderAsleepColor is obsolete. This options has been moved to 2D Preferences.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static Color colliderAsleepColor
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Physics2D.colliderContactColor is obsolete. This options has been moved to 2D Preferences.", true)]
	public static Color colliderContactColor
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[Obsolete("Physics2D.colliderAABBColor is obsolete. All Physics 2D colors moved to Preferences. This is now known as 'Collider Bounds Color'.", true)]
	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Color colliderAABBColor
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[Obsolete("Physics2D.contactArrowScale is obsolete. This options has been moved to 2D Preferences.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static float contactArrowScale
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Physics2D.alwaysShowColliders is obsolete. It is no longer available in the Editor or Builds.", true)]
	[ExcludeFromDocs]
	public static bool alwaysShowColliders
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Physics2D.showCollidersFilled is obsolete. It is no longer available in the Editor or Builds.", true)]
	public static bool showCollidersFilled
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Physics2D.showColliderSleep is obsolete. It is no longer available in the Editor or Builds.", true)]
	public static bool showColliderSleep
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[Obsolete("Physics2D.showColliderContacts is obsolete. It is no longer available in the Editor or Builds.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static bool showColliderContacts
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[Obsolete("Physics2D.showColliderAABB is obsolete. It is no longer available in the Editor or Builds.", true)]
	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static bool showColliderAABB
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[ExcludeFromDocs]
	public static bool Simulate(float deltaTime)
	{
		return Simulate_Internal(defaultPhysicsScene, deltaTime, -1);
	}

	public static bool Simulate(float deltaTime, [UnityEngine.Internal.DefaultValue("Physics2D.AllLayers")] int simulationLayers = -1)
	{
		return Simulate_Internal(defaultPhysicsScene, deltaTime, simulationLayers);
	}

	[NativeMethod("Simulate_Binding")]
	internal static bool Simulate_Internal(PhysicsScene2D physicsScene, float deltaTime, int simulationLayers)
	{
		return Simulate_Internal_Injected(ref physicsScene, deltaTime, simulationLayers);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void SyncTransforms();

	[ExcludeFromDocs]
	public static void IgnoreCollision(Collider2D collider1, Collider2D collider2)
	{
		IgnoreCollision(collider1, collider2, ignore: true);
	}

	[StaticAccessor("PhysicsScene2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("IgnoreCollision_Binding")]
	public static void IgnoreCollision([NotNull] Collider2D collider1, [NotNull] Collider2D collider2, [UnityEngine.Internal.DefaultValue("true")] bool ignore)
	{
		if ((object)collider1 == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
		}
		if ((object)collider2 == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider1);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
		}
		IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(collider2);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
		}
		IgnoreCollision_Injected(intPtr, intPtr2, ignore);
	}

	[StaticAccessor("PhysicsScene2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("GetIgnoreCollision_Binding")]
	public static bool GetIgnoreCollision([NotNull] Collider2D collider1, [NotNull] Collider2D collider2)
	{
		if ((object)collider1 == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
		}
		if ((object)collider2 == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider1);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
		}
		IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(collider2);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
		}
		return GetIgnoreCollision_Injected(intPtr, intPtr2);
	}

	[ExcludeFromDocs]
	public static void IgnoreLayerCollision(int layer1, int layer2)
	{
		IgnoreLayerCollision(layer1, layer2, ignore: true);
	}

	public static void IgnoreLayerCollision(int layer1, int layer2, bool ignore)
	{
		if (layer1 < 0 || layer1 > 31)
		{
			throw new ArgumentOutOfRangeException("layer1 is out of range. Layer numbers must be in the range 0 to 31.");
		}
		if (layer2 < 0 || layer2 > 31)
		{
			throw new ArgumentOutOfRangeException("layer2 is out of range. Layer numbers must be in the range 0 to 31.");
		}
		IgnoreLayerCollision_Internal(layer1, layer2, ignore);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetPhysics2DSettings()")]
	[NativeMethod("IgnoreLayerCollision")]
	private static extern void IgnoreLayerCollision_Internal(int layer1, int layer2, bool ignore);

	public static bool GetIgnoreLayerCollision(int layer1, int layer2)
	{
		if (layer1 < 0 || layer1 > 31)
		{
			throw new ArgumentOutOfRangeException("layer1 is out of range. Layer numbers must be in the range 0 to 31.");
		}
		if (layer2 < 0 || layer2 > 31)
		{
			throw new ArgumentOutOfRangeException("layer2 is out of range. Layer numbers must be in the range 0 to 31.");
		}
		return GetIgnoreLayerCollision_Internal(layer1, layer2);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetPhysics2DSettings()")]
	[NativeMethod("GetIgnoreLayerCollision")]
	private static extern bool GetIgnoreLayerCollision_Internal(int layer1, int layer2);

	public static void SetLayerCollisionMask(int layer, int layerMask)
	{
		if (layer < 0 || layer > 31)
		{
			throw new ArgumentOutOfRangeException("layer1 is out of range. Layer numbers must be in the range 0 to 31.");
		}
		SetLayerCollisionMask_Internal(layer, layerMask);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod("SetLayerCollisionMask")]
	[StaticAccessor("GetPhysics2DSettings()")]
	private static extern void SetLayerCollisionMask_Internal(int layer, int layerMask);

	public static int GetLayerCollisionMask(int layer)
	{
		if (layer < 0 || layer > 31)
		{
			throw new ArgumentOutOfRangeException("layer1 is out of range. Layer numbers must be in the range 0 to 31.");
		}
		return GetLayerCollisionMask_Internal(layer);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[StaticAccessor("GetPhysics2DSettings()")]
	[NativeMethod("GetLayerCollisionMask")]
	private static extern int GetLayerCollisionMask_Internal(int layer);

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	public static bool IsTouching([NotNull] Collider2D collider1, [NotNull] Collider2D collider2)
	{
		if ((object)collider1 == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
		}
		if ((object)collider2 == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider1);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
		}
		IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(collider2);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
		}
		return IsTouching_Injected(intPtr, intPtr2);
	}

	public static bool IsTouching(Collider2D collider1, Collider2D collider2, ContactFilter2D contactFilter)
	{
		return IsTouching_TwoCollidersWithFilter(collider1, collider2, contactFilter);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("IsTouching")]
	private static bool IsTouching_TwoCollidersWithFilter([NotNull] Collider2D collider1, [NotNull] Collider2D collider2, ContactFilter2D contactFilter)
	{
		if ((object)collider1 == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
		}
		if ((object)collider2 == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider1);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
		}
		IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(collider2);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
		}
		return IsTouching_TwoCollidersWithFilter_Injected(intPtr, intPtr2, ref contactFilter);
	}

	public static bool IsTouching(Collider2D collider, ContactFilter2D contactFilter)
	{
		return IsTouching_SingleColliderWithFilter(collider, contactFilter);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("IsTouching")]
	private static bool IsTouching_SingleColliderWithFilter([NotNull] Collider2D collider, ContactFilter2D contactFilter)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		return IsTouching_SingleColliderWithFilter_Injected(intPtr, ref contactFilter);
	}

	[ExcludeFromDocs]
	public static bool IsTouchingLayers(Collider2D collider)
	{
		return IsTouchingLayers(collider, -1);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	public static bool IsTouchingLayers([NotNull] Collider2D collider, [UnityEngine.Internal.DefaultValue("Physics2D.AllLayers")] int layerMask)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		return IsTouchingLayers_Injected(intPtr, layerMask);
	}

	public static ColliderDistance2D Distance(Collider2D colliderA, Collider2D colliderB)
	{
		if (colliderA == colliderB)
		{
			throw new ArgumentException("Cannot calculate the distance between the same collider.");
		}
		return Distance_Internal(colliderA, colliderB);
	}

	public static ColliderDistance2D Distance(Collider2D colliderA, Vector2 positionA, float angleA, Collider2D colliderB, Vector2 positionB, float angleB)
	{
		if (colliderA == colliderB)
		{
			throw new ArgumentException("Cannot calculate the distance between the same collider.");
		}
		if (!colliderA.attachedRigidbody || !colliderB.attachedRigidbody)
		{
			throw new InvalidOperationException("Cannot perform a Collider Distance at a specific position and angle if the Collider is not attached to a Rigidbody2D.");
		}
		return DistanceFrom_Internal(colliderA, positionA, angleA, colliderB, positionB, angleB);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("Distance")]
	private static ColliderDistance2D Distance_Internal([NotNull] Collider2D colliderA, [NotNull] Collider2D colliderB)
	{
		if ((object)colliderA == null)
		{
			ThrowHelper.ThrowArgumentNullException(colliderA, "colliderA");
		}
		if ((object)colliderB == null)
		{
			ThrowHelper.ThrowArgumentNullException(colliderB, "colliderB");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(colliderA);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(colliderA, "colliderA");
		}
		IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(colliderB);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(colliderB, "colliderB");
		}
		Distance_Internal_Injected(intPtr, intPtr2, out var ret);
		return ret;
	}

	[NativeMethod("DistanceFrom")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static ColliderDistance2D DistanceFrom_Internal([NotNull] Collider2D colliderA, Vector2 positionA, float angleA, [NotNull] Collider2D colliderB, Vector2 positionB, float angleB)
	{
		if ((object)colliderA == null)
		{
			ThrowHelper.ThrowArgumentNullException(colliderA, "colliderA");
		}
		if ((object)colliderB == null)
		{
			ThrowHelper.ThrowArgumentNullException(colliderB, "colliderB");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(colliderA);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(colliderA, "colliderA");
		}
		IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(colliderB);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(colliderB, "colliderB");
		}
		DistanceFrom_Internal_Injected(intPtr, ref positionA, angleA, intPtr2, ref positionB, angleB, out var ret);
		return ret;
	}

	public static Vector2 ClosestPoint(Vector2 position, Collider2D collider)
	{
		if (collider == null)
		{
			throw new ArgumentNullException("Collider cannot be NULL.");
		}
		return ClosestPoint_Collider(position, collider);
	}

	public static Vector2 ClosestPoint(Vector2 position, Rigidbody2D rigidbody)
	{
		if (rigidbody == null)
		{
			throw new ArgumentNullException("Rigidbody cannot be NULL.");
		}
		return ClosestPoint_Rigidbody(position, rigidbody);
	}

	[NativeMethod("ClosestPoint")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static Vector2 ClosestPoint_Collider(Vector2 position, [NotNull] Collider2D collider)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		ClosestPoint_Collider_Injected(ref position, intPtr, out var ret);
		return ret;
	}

	[NativeMethod("ClosestPoint")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static Vector2 ClosestPoint_Rigidbody(Vector2 position, [NotNull] Rigidbody2D rigidbody)
	{
		if ((object)rigidbody == null)
		{
			ThrowHelper.ThrowArgumentNullException(rigidbody, "rigidbody");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(rigidbody);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(rigidbody, "rigidbody");
		}
		ClosestPoint_Rigidbody_Injected(ref position, intPtr, out var ret);
		return ret;
	}

	[ExcludeFromDocs]
	public static RaycastHit2D Linecast(Vector2 start, Vector2 end)
	{
		return defaultPhysicsScene.Linecast(start, end);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D Linecast(Vector2 start, Vector2 end, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.Linecast(start, end, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D Linecast(Vector2 start, Vector2 end, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.Linecast(start, end, contactFilter);
	}

	public static RaycastHit2D Linecast(Vector2 start, Vector2 end, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.Linecast(start, end, contactFilter);
	}

	public static int Linecast(Vector2 start, Vector2 end, ContactFilter2D contactFilter, RaycastHit2D[] results)
	{
		return defaultPhysicsScene.Linecast(start, end, contactFilter, results);
	}

	public static int Linecast(Vector2 start, Vector2 end, ContactFilter2D contactFilter, List<RaycastHit2D> results)
	{
		return defaultPhysicsScene.Linecast(start, end, contactFilter, results);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-5, float.NegativeInfinity, float.PositiveInfinity);
		return LinecastAll_Internal(defaultPhysicsScene, start, end, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return LinecastAll_Internal(defaultPhysicsScene, start, end, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return LinecastAll_Internal(defaultPhysicsScene, start, end, contactFilter);
	}

	public static RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return LinecastAll_Internal(defaultPhysicsScene, start, end, contactFilter);
	}

	[NativeMethod("LinecastAll_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static RaycastHit2D[] LinecastAll_Internal(PhysicsScene2D physicsScene, Vector2 start, Vector2 end, ContactFilter2D contactFilter)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		RaycastHit2D[] result;
		try
		{
			LinecastAll_Internal_Injected(ref physicsScene, ref start, ref end, ref contactFilter, out ret);
		}
		finally
		{
			RaycastHit2D[] array = default(RaycastHit2D[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[ExcludeFromDocs]
	public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.Raycast(origin, direction, distance, contactFilter, results);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction)
	{
		return defaultPhysicsScene.Raycast(origin, direction, float.PositiveInfinity);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance)
	{
		return defaultPhysicsScene.Raycast(origin, direction, distance);
	}

	[ExcludeFromDocs]
	[RequiredByNativeCode]
	public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.Raycast(origin, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.Raycast(origin, direction, distance, contactFilter);
	}

	public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.Raycast(origin, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static int Raycast(Vector2 origin, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results)
	{
		return defaultPhysicsScene.Raycast(origin, direction, float.PositiveInfinity, contactFilter, results);
	}

	public static int Raycast(Vector2 origin, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance)
	{
		return defaultPhysicsScene.Raycast(origin, direction, distance, contactFilter, results);
	}

	public static int Raycast(Vector2 origin, Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance = float.PositiveInfinity)
	{
		return defaultPhysicsScene.Raycast(origin, direction, distance, contactFilter, results);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-5, float.NegativeInfinity, float.PositiveInfinity);
		return RaycastAll_Internal(defaultPhysicsScene, origin, direction, float.PositiveInfinity, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-5, float.NegativeInfinity, float.PositiveInfinity);
		return RaycastAll_Internal(defaultPhysicsScene, origin, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return RaycastAll_Internal(defaultPhysicsScene, origin, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return RaycastAll_Internal(defaultPhysicsScene, origin, direction, distance, contactFilter);
	}

	public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return RaycastAll_Internal(defaultPhysicsScene, origin, direction, distance, contactFilter);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("RaycastAll_Binding")]
	private static RaycastHit2D[] RaycastAll_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		RaycastHit2D[] result;
		try
		{
			RaycastAll_Internal_Injected(ref physicsScene, ref origin, ref direction, distance, ref contactFilter, out ret);
		}
		finally
		{
			RaycastHit2D[] array = default(RaycastHit2D[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[ExcludeFromDocs]
	public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction)
	{
		return defaultPhysicsScene.CircleCast(origin, radius, direction, float.PositiveInfinity);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance)
	{
		return defaultPhysicsScene.CircleCast(origin, radius, direction, distance);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.CircleCast(origin, radius, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.CircleCast(origin, radius, direction, distance, contactFilter);
	}

	public static RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.CircleCast(origin, radius, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static int CircleCast(Vector2 origin, float radius, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results)
	{
		return defaultPhysicsScene.CircleCast(origin, radius, direction, float.PositiveInfinity, contactFilter, results);
	}

	public static int CircleCast(Vector2 origin, float radius, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance)
	{
		return defaultPhysicsScene.CircleCast(origin, radius, direction, distance, contactFilter, results);
	}

	public static int CircleCast(Vector2 origin, float radius, Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance = float.PositiveInfinity)
	{
		return defaultPhysicsScene.CircleCast(origin, radius, direction, distance, contactFilter, results);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-5, float.NegativeInfinity, float.PositiveInfinity);
		return CircleCastAll_Internal(defaultPhysicsScene, origin, radius, direction, float.PositiveInfinity, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-5, float.NegativeInfinity, float.PositiveInfinity);
		return CircleCastAll_Internal(defaultPhysicsScene, origin, radius, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return CircleCastAll_Internal(defaultPhysicsScene, origin, radius, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return CircleCastAll_Internal(defaultPhysicsScene, origin, radius, direction, distance, contactFilter);
	}

	public static RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return CircleCastAll_Internal(defaultPhysicsScene, origin, radius, direction, distance, contactFilter);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("CircleCastAll_Binding")]
	private static RaycastHit2D[] CircleCastAll_Internal(PhysicsScene2D physicsScene, Vector2 origin, float radius, Vector2 direction, float distance, ContactFilter2D contactFilter)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		RaycastHit2D[] result;
		try
		{
			CircleCastAll_Internal_Injected(ref physicsScene, ref origin, radius, ref direction, distance, ref contactFilter, out ret);
		}
		finally
		{
			RaycastHit2D[] array = default(RaycastHit2D[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[ExcludeFromDocs]
	public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction)
	{
		return defaultPhysicsScene.BoxCast(origin, size, angle, direction, float.PositiveInfinity);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance)
	{
		return defaultPhysicsScene.BoxCast(origin, size, angle, direction, distance);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.BoxCast(origin, size, angle, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.BoxCast(origin, size, angle, direction, distance, contactFilter);
	}

	public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("Physics2D.AllLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.BoxCast(origin, size, angle, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static int BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results)
	{
		return defaultPhysicsScene.BoxCast(origin, size, angle, direction, float.PositiveInfinity, contactFilter, results);
	}

	public static int BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance)
	{
		return defaultPhysicsScene.BoxCast(origin, size, angle, direction, distance, contactFilter, results);
	}

	public static int BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance = float.PositiveInfinity)
	{
		return defaultPhysicsScene.BoxCast(origin, size, angle, direction, distance, contactFilter, results);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-5, float.NegativeInfinity, float.PositiveInfinity);
		return BoxCastAll_Internal(defaultPhysicsScene, origin, size, angle, direction, float.PositiveInfinity, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-5, float.NegativeInfinity, float.PositiveInfinity);
		return BoxCastAll_Internal(defaultPhysicsScene, origin, size, angle, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return BoxCastAll_Internal(defaultPhysicsScene, origin, size, angle, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return BoxCastAll_Internal(defaultPhysicsScene, origin, size, angle, direction, distance, contactFilter);
	}

	public static RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return BoxCastAll_Internal(defaultPhysicsScene, origin, size, angle, direction, distance, contactFilter);
	}

	[NativeMethod("BoxCastAll_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static RaycastHit2D[] BoxCastAll_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		RaycastHit2D[] result;
		try
		{
			BoxCastAll_Internal_Injected(ref physicsScene, ref origin, ref size, angle, ref direction, distance, ref contactFilter, out ret);
		}
		finally
		{
			RaycastHit2D[] array = default(RaycastHit2D[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[ExcludeFromDocs]
	public static RaycastHit2D CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction)
	{
		return defaultPhysicsScene.CapsuleCast(origin, size, capsuleDirection, angle, direction, float.PositiveInfinity);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance)
	{
		return defaultPhysicsScene.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, contactFilter);
	}

	public static RaycastHit2D CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static int CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results)
	{
		return defaultPhysicsScene.CapsuleCast(origin, size, capsuleDirection, angle, direction, float.PositiveInfinity, contactFilter, results);
	}

	public static int CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance)
	{
		return defaultPhysicsScene.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, contactFilter, results);
	}

	public static int CapsuleCast(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance = float.PositiveInfinity)
	{
		return defaultPhysicsScene.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, contactFilter, results);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] CapsuleCastAll(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-5, float.NegativeInfinity, float.PositiveInfinity);
		return CapsuleCastAll_Internal(defaultPhysicsScene, origin, size, capsuleDirection, angle, direction, float.PositiveInfinity, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] CapsuleCastAll(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-5, float.NegativeInfinity, float.PositiveInfinity);
		return CapsuleCastAll_Internal(defaultPhysicsScene, origin, size, capsuleDirection, angle, direction, distance, contactFilter);
	}

	[NativeMethod("CapsuleCastAll_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static RaycastHit2D[] CapsuleCastAll_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		RaycastHit2D[] result;
		try
		{
			CapsuleCastAll_Internal_Injected(ref physicsScene, ref origin, ref size, capsuleDirection, angle, ref direction, distance, ref contactFilter, out ret);
		}
		finally
		{
			RaycastHit2D[] array = default(RaycastHit2D[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] CapsuleCastAll(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return CapsuleCastAll_Internal(defaultPhysicsScene, origin, size, capsuleDirection, angle, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] CapsuleCastAll(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, float distance, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return CapsuleCastAll_Internal(defaultPhysicsScene, origin, size, capsuleDirection, angle, direction, distance, contactFilter);
	}

	public static RaycastHit2D[] CapsuleCastAll(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return CapsuleCastAll_Internal(defaultPhysicsScene, origin, size, capsuleDirection, angle, direction, distance, contactFilter);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D GetRayIntersection(Ray ray)
	{
		return defaultPhysicsScene.GetRayIntersection(ray, float.PositiveInfinity);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D GetRayIntersection(Ray ray, float distance)
	{
		return defaultPhysicsScene.GetRayIntersection(ray, distance);
	}

	public static RaycastHit2D GetRayIntersection(Ray ray, float distance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask = -5)
	{
		return defaultPhysicsScene.GetRayIntersection(ray, distance, layerMask);
	}

	public static int GetRayIntersection(Ray ray, float distance, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5)
	{
		return defaultPhysicsScene.GetRayIntersection(ray, distance, results, layerMask);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] GetRayIntersectionAll(Ray ray)
	{
		return GetRayIntersectionAll_Internal(defaultPhysicsScene, ray.origin, ray.direction, float.PositiveInfinity, -5);
	}

	[ExcludeFromDocs]
	public static RaycastHit2D[] GetRayIntersectionAll(Ray ray, float distance)
	{
		return GetRayIntersectionAll_Internal(defaultPhysicsScene, ray.origin, ray.direction, distance, -5);
	}

	[RequiredByNativeCode]
	public static RaycastHit2D[] GetRayIntersectionAll(Ray ray, float distance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask = -5)
	{
		return GetRayIntersectionAll_Internal(defaultPhysicsScene, ray.origin, ray.direction, distance, layerMask);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("GetRayIntersectionAll_Binding")]
	private static RaycastHit2D[] GetRayIntersectionAll_Internal(PhysicsScene2D physicsScene, Vector3 origin, Vector3 direction, float distance, int layerMask)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		RaycastHit2D[] result;
		try
		{
			GetRayIntersectionAll_Internal_Injected(ref physicsScene, ref origin, ref direction, distance, layerMask, out ret);
		}
		finally
		{
			RaycastHit2D[] array = default(RaycastHit2D[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[RequiredByNativeCode]
	[ExcludeFromDocs]
	public static int GetRayIntersectionNonAlloc(Ray ray, RaycastHit2D[] results, float distance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask = -5)
	{
		return defaultPhysicsScene.GetRayIntersection(ray, distance, results, layerMask);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapPoint(Vector2 point)
	{
		return defaultPhysicsScene.OverlapPoint(point);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapPoint(Vector2 point, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapPoint(point, contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapPoint(Vector2 point, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapPoint(point, contactFilter);
	}

	public static Collider2D OverlapPoint(Vector2 point, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.OverlapPoint(point, contactFilter);
	}

	public static int OverlapPoint(Vector2 point, ContactFilter2D contactFilter, [Unmarshalled] Collider2D[] results)
	{
		return defaultPhysicsScene.OverlapPoint(point, contactFilter, results);
	}

	public static int OverlapPoint(Vector2 point, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return defaultPhysicsScene.OverlapPoint(point, contactFilter, results);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapPointAll(Vector2 point)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-5, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapPointAll_Internal(defaultPhysicsScene, point, contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapPointAll(Vector2 point, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapPointAll_Internal(defaultPhysicsScene, point, contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapPointAll(Vector2 point, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return OverlapPointAll_Internal(defaultPhysicsScene, point, contactFilter);
	}

	public static Collider2D[] OverlapPointAll(Vector2 point, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return OverlapPointAll_Internal(defaultPhysicsScene, point, contactFilter);
	}

	[NativeMethod("OverlapPointAll_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static Collider2D[] OverlapPointAll_Internal(PhysicsScene2D physicsScene, Vector2 point, ContactFilter2D contactFilter)
	{
		return OverlapPointAll_Internal_Injected(ref physicsScene, ref point, ref contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapCircle(Vector2 point, float radius)
	{
		return defaultPhysicsScene.OverlapCircle(point, radius);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapCircle(Vector2 point, float radius, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapCircle(point, radius, contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapCircle(Vector2 point, float radius, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapCircle(point, radius, contactFilter);
	}

	public static Collider2D OverlapCircle(Vector2 point, float radius, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.OverlapCircle(point, radius, contactFilter);
	}

	public static int OverlapCircle(Vector2 point, float radius, ContactFilter2D contactFilter, Collider2D[] results)
	{
		return defaultPhysicsScene.OverlapCircle(point, radius, contactFilter, results);
	}

	public static int OverlapCircle(Vector2 point, float radius, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return defaultPhysicsScene.OverlapCircle(point, radius, contactFilter, results);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapCircleAll(Vector2 point, float radius)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-5, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapCircleAll_Internal(defaultPhysicsScene, point, radius, contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapCircleAll(Vector2 point, float radius, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapCircleAll_Internal(defaultPhysicsScene, point, radius, contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapCircleAll(Vector2 point, float radius, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return OverlapCircleAll_Internal(defaultPhysicsScene, point, radius, contactFilter);
	}

	public static Collider2D[] OverlapCircleAll(Vector2 point, float radius, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return OverlapCircleAll_Internal(defaultPhysicsScene, point, radius, contactFilter);
	}

	[NativeMethod("OverlapCircleAll_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static Collider2D[] OverlapCircleAll_Internal(PhysicsScene2D physicsScene, Vector2 point, float radius, ContactFilter2D contactFilter)
	{
		return OverlapCircleAll_Internal_Injected(ref physicsScene, ref point, radius, ref contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapBox(Vector2 point, Vector2 size, float angle)
	{
		return defaultPhysicsScene.OverlapBox(point, size, angle);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapBox(Vector2 point, Vector2 size, float angle, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapBox(point, size, angle, contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapBox(Vector2 point, Vector2 size, float angle, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapBox(point, size, angle, contactFilter);
	}

	public static Collider2D OverlapBox(Vector2 point, Vector2 size, float angle, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.OverlapBox(point, size, angle, contactFilter);
	}

	public static int OverlapBox(Vector2 point, Vector2 size, float angle, ContactFilter2D contactFilter, Collider2D[] results)
	{
		return defaultPhysicsScene.OverlapBox(point, size, angle, contactFilter, results);
	}

	public static int OverlapBox(Vector2 point, Vector2 size, float angle, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return defaultPhysicsScene.OverlapBox(point, size, angle, contactFilter, results);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapBoxAll(Vector2 point, Vector2 size, float angle)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-5, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapBoxAll_Internal(defaultPhysicsScene, point, size, angle, contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapBoxAll(Vector2 point, Vector2 size, float angle, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapBoxAll_Internal(defaultPhysicsScene, point, size, angle, contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapBoxAll(Vector2 point, Vector2 size, float angle, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return OverlapBoxAll_Internal(defaultPhysicsScene, point, size, angle, contactFilter);
	}

	public static Collider2D[] OverlapBoxAll(Vector2 point, Vector2 size, float angle, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return OverlapBoxAll_Internal(defaultPhysicsScene, point, size, angle, contactFilter);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("OverlapBoxAll_Binding")]
	private static Collider2D[] OverlapBoxAll_Internal(PhysicsScene2D physicsScene, Vector2 point, Vector2 size, float angle, ContactFilter2D contactFilter)
	{
		return OverlapBoxAll_Internal_Injected(ref physicsScene, ref point, ref size, angle, ref contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapArea(Vector2 pointA, Vector2 pointB)
	{
		return defaultPhysicsScene.OverlapArea(pointA, pointB);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapArea(pointA, pointB, contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapArea(pointA, pointB, contactFilter);
	}

	public static Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.OverlapArea(pointA, pointB, contactFilter);
	}

	public static int OverlapArea(Vector2 pointA, Vector2 pointB, ContactFilter2D contactFilter, Collider2D[] results)
	{
		return defaultPhysicsScene.OverlapArea(pointA, pointB, contactFilter, results);
	}

	public static int OverlapArea(Vector2 pointA, Vector2 pointB, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return defaultPhysicsScene.OverlapArea(pointA, pointB, contactFilter, results);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB)
	{
		return OverlapAreaAllToBox_Internal(pointA, pointB, -5, float.NegativeInfinity, float.PositiveInfinity);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB, int layerMask)
	{
		return OverlapAreaAllToBox_Internal(pointA, pointB, layerMask, float.NegativeInfinity, float.PositiveInfinity);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth)
	{
		return OverlapAreaAllToBox_Internal(pointA, pointB, layerMask, minDepth, float.PositiveInfinity);
	}

	public static Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		return OverlapAreaAllToBox_Internal(pointA, pointB, layerMask, minDepth, maxDepth);
	}

	private static Collider2D[] OverlapAreaAllToBox_Internal(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth, float maxDepth)
	{
		Vector2 point = (pointA + pointB) * 0.5f;
		Vector2 size = new Vector2(Mathf.Abs(pointA.x - pointB.x), Math.Abs(pointA.y - pointB.y));
		return OverlapBoxAll(point, size, 0f, layerMask, minDepth, maxDepth);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle)
	{
		return defaultPhysicsScene.OverlapCapsule(point, size, direction, angle);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapCapsule(point, size, direction, angle, contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapCapsule(point, size, direction, angle, contactFilter);
	}

	public static Collider2D OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.OverlapCapsule(point, size, direction, angle, contactFilter);
	}

	public static int OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, ContactFilter2D contactFilter, Collider2D[] results)
	{
		return defaultPhysicsScene.OverlapCapsule(point, size, direction, angle, contactFilter, results);
	}

	public static int OverlapCapsule(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return defaultPhysicsScene.OverlapCapsule(point, size, direction, angle, contactFilter, results);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapCapsuleAll(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-5, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapCapsuleAll_Internal(defaultPhysicsScene, point, size, direction, angle, contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapCapsuleAll(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return OverlapCapsuleAll_Internal(defaultPhysicsScene, point, size, direction, angle, contactFilter);
	}

	[ExcludeFromDocs]
	public static Collider2D[] OverlapCapsuleAll(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return OverlapCapsuleAll_Internal(defaultPhysicsScene, point, size, direction, angle, contactFilter);
	}

	public static Collider2D[] OverlapCapsuleAll(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return OverlapCapsuleAll_Internal(defaultPhysicsScene, point, size, direction, angle, contactFilter);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("OverlapCapsuleAll_Binding")]
	private static Collider2D[] OverlapCapsuleAll_Internal(PhysicsScene2D physicsScene, Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, ContactFilter2D contactFilter)
	{
		return OverlapCapsuleAll_Internal_Injected(ref physicsScene, ref point, ref size, direction, angle, ref contactFilter);
	}

	public static int OverlapCollider(Collider2D collider, ContactFilter2D contactFilter, Collider2D[] results)
	{
		return PhysicsScene2D.OverlapCollider(collider, contactFilter, results);
	}

	public static int OverlapCollider(Collider2D collider, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return PhysicsScene2D.OverlapCollider(collider, contactFilter, results);
	}

	public static int OverlapCollider(Collider2D collider, List<Collider2D> results)
	{
		return PhysicsScene2D.OverlapCollider(collider, results);
	}

	public static int GetContacts(Collider2D collider1, Collider2D collider2, ContactFilter2D contactFilter, ContactPoint2D[] contacts)
	{
		return GetColliderColliderContactsArray(collider1, collider2, contactFilter, contacts);
	}

	public static int GetContacts(Collider2D collider, ContactPoint2D[] contacts)
	{
		return GetColliderContactsArray(collider, ContactFilter2D.noFilter, contacts);
	}

	public static int GetContacts(Collider2D collider, ContactFilter2D contactFilter, ContactPoint2D[] contacts)
	{
		return GetColliderContactsArray(collider, contactFilter, contacts);
	}

	public static int GetContacts(Collider2D collider, Collider2D[] colliders)
	{
		return GetColliderContactsCollidersOnlyArray(collider, ContactFilter2D.noFilter, colliders);
	}

	public static int GetContacts(Collider2D collider, ContactFilter2D contactFilter, Collider2D[] colliders)
	{
		return GetColliderContactsCollidersOnlyArray(collider, contactFilter, colliders);
	}

	public static int GetContacts(Rigidbody2D rigidbody, ContactPoint2D[] contacts)
	{
		return GetRigidbodyContactsArray(rigidbody, ContactFilter2D.noFilter, contacts);
	}

	public static int GetContacts(Rigidbody2D rigidbody, ContactFilter2D contactFilter, ContactPoint2D[] contacts)
	{
		return GetRigidbodyContactsArray(rigidbody, contactFilter, contacts);
	}

	public static int GetContacts(Rigidbody2D rigidbody, Collider2D[] colliders)
	{
		return GetRigidbodyContactsCollidersOnlyArray(rigidbody, ContactFilter2D.noFilter, colliders);
	}

	public static int GetContacts(Rigidbody2D rigidbody, ContactFilter2D contactFilter, Collider2D[] colliders)
	{
		return GetRigidbodyContactsCollidersOnlyArray(rigidbody, contactFilter, colliders);
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("GetColliderContactsArray_Binding")]
	private unsafe static int GetColliderContactsArray([NotNull] Collider2D collider, ContactFilter2D contactFilter, [NotNull] ContactPoint2D[] results)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		Span<ContactPoint2D> span = new Span<ContactPoint2D>(results);
		int colliderContactsArray_Injected;
		fixed (ContactPoint2D* begin = span)
		{
			ManagedSpanWrapper results2 = new ManagedSpanWrapper(begin, span.Length);
			colliderContactsArray_Injected = GetColliderContactsArray_Injected(intPtr, ref contactFilter, ref results2);
		}
		return colliderContactsArray_Injected;
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("GetColliderColliderContactsArray_Binding")]
	private unsafe static int GetColliderColliderContactsArray([NotNull] Collider2D collider1, [NotNull] Collider2D collider2, ContactFilter2D contactFilter, [NotNull] ContactPoint2D[] results)
	{
		if ((object)collider1 == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
		}
		if ((object)collider2 == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider1);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
		}
		IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(collider2);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
		}
		Span<ContactPoint2D> span = new Span<ContactPoint2D>(results);
		int colliderColliderContactsArray_Injected;
		fixed (ContactPoint2D* begin = span)
		{
			ManagedSpanWrapper results2 = new ManagedSpanWrapper(begin, span.Length);
			colliderColliderContactsArray_Injected = GetColliderColliderContactsArray_Injected(intPtr, intPtr2, ref contactFilter, ref results2);
		}
		return colliderColliderContactsArray_Injected;
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("GetRigidbodyContactsArray_Binding")]
	private unsafe static int GetRigidbodyContactsArray([NotNull] Rigidbody2D rigidbody, ContactFilter2D contactFilter, [NotNull] ContactPoint2D[] results)
	{
		if ((object)rigidbody == null)
		{
			ThrowHelper.ThrowArgumentNullException(rigidbody, "rigidbody");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(rigidbody);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(rigidbody, "rigidbody");
		}
		Span<ContactPoint2D> span = new Span<ContactPoint2D>(results);
		int rigidbodyContactsArray_Injected;
		fixed (ContactPoint2D* begin = span)
		{
			ManagedSpanWrapper results2 = new ManagedSpanWrapper(begin, span.Length);
			rigidbodyContactsArray_Injected = GetRigidbodyContactsArray_Injected(intPtr, ref contactFilter, ref results2);
		}
		return rigidbodyContactsArray_Injected;
	}

	[NativeMethod("GetColliderContactsCollidersOnlyArray_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static int GetColliderContactsCollidersOnlyArray([NotNull] Collider2D collider, ContactFilter2D contactFilter, [NotNull][Unmarshalled] Collider2D[] results)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		return GetColliderContactsCollidersOnlyArray_Injected(intPtr, ref contactFilter, results);
	}

	[NativeMethod("GetRigidbodyContactsCollidersOnlyArray_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static int GetRigidbodyContactsCollidersOnlyArray([NotNull] Rigidbody2D rigidbody, ContactFilter2D contactFilter, [NotNull][Unmarshalled] Collider2D[] results)
	{
		if ((object)rigidbody == null)
		{
			ThrowHelper.ThrowArgumentNullException(rigidbody, "rigidbody");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(rigidbody);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(rigidbody, "rigidbody");
		}
		return GetRigidbodyContactsCollidersOnlyArray_Injected(intPtr, ref contactFilter, results);
	}

	public static int GetContacts(Collider2D collider1, Collider2D collider2, ContactFilter2D contactFilter, List<ContactPoint2D> contacts)
	{
		return GetColliderColliderContactsList(collider1, collider2, contactFilter, contacts);
	}

	public static int GetContacts(Collider2D collider, List<ContactPoint2D> contacts)
	{
		return GetColliderContactsList(collider, ContactFilter2D.noFilter, contacts);
	}

	public static int GetContacts(Collider2D collider, ContactFilter2D contactFilter, List<ContactPoint2D> contacts)
	{
		return GetColliderContactsList(collider, contactFilter, contacts);
	}

	public static int GetContacts(Collider2D collider, List<Collider2D> colliders)
	{
		return GetColliderContactsCollidersOnlyList(collider, ContactFilter2D.noFilter, colliders);
	}

	public static int GetContacts(Collider2D collider, ContactFilter2D contactFilter, List<Collider2D> colliders)
	{
		return GetColliderContactsCollidersOnlyList(collider, contactFilter, colliders);
	}

	public static int GetContacts(Rigidbody2D rigidbody, List<ContactPoint2D> contacts)
	{
		return GetRigidbodyContactsList(rigidbody, ContactFilter2D.noFilter, contacts);
	}

	public static int GetContacts(Rigidbody2D rigidbody, ContactFilter2D contactFilter, List<ContactPoint2D> contacts)
	{
		return GetRigidbodyContactsList(rigidbody, contactFilter, contacts);
	}

	public static int GetContacts(Rigidbody2D rigidbody, List<Collider2D> colliders)
	{
		return GetRigidbodyContactsCollidersOnlyList(rigidbody, ContactFilter2D.noFilter, colliders);
	}

	public static int GetContacts(Rigidbody2D rigidbody, ContactFilter2D contactFilter, List<Collider2D> colliders)
	{
		return GetRigidbodyContactsCollidersOnlyList(rigidbody, contactFilter, colliders);
	}

	[NativeMethod("GetColliderContactsList_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private unsafe static int GetColliderContactsList([NotNull] Collider2D collider, ContactFilter2D contactFilter, [NotNull] List<ContactPoint2D> results)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<ContactPoint2D> list = default(List<ContactPoint2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(collider, "collider");
			}
			list = results;
			fixed (ContactPoint2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return GetColliderContactsList_Injected(intPtr, ref contactFilter, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("GetColliderColliderContactsList_Binding")]
	private unsafe static int GetColliderColliderContactsList([NotNull] Collider2D collider1, [NotNull] Collider2D collider2, ContactFilter2D contactFilter, [NotNull] List<ContactPoint2D> results)
	{
		if ((object)collider1 == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
		}
		if ((object)collider2 == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<ContactPoint2D> list = default(List<ContactPoint2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider1);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(collider1, "collider1");
			}
			IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(collider2);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(collider2, "collider2");
			}
			list = results;
			fixed (ContactPoint2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return GetColliderColliderContactsList_Injected(intPtr, intPtr2, ref contactFilter, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("GetRigidbodyContactsList_Binding")]
	private unsafe static int GetRigidbodyContactsList([NotNull] Rigidbody2D rigidbody, ContactFilter2D contactFilter, [NotNull] List<ContactPoint2D> results)
	{
		if ((object)rigidbody == null)
		{
			ThrowHelper.ThrowArgumentNullException(rigidbody, "rigidbody");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<ContactPoint2D> list = default(List<ContactPoint2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(rigidbody);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(rigidbody, "rigidbody");
			}
			list = results;
			fixed (ContactPoint2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return GetRigidbodyContactsList_Injected(intPtr, ref contactFilter, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	[NativeMethod("GetColliderContactsCollidersOnlyList_Binding")]
	private static int GetColliderContactsCollidersOnlyList([NotNull] Collider2D collider, ContactFilter2D contactFilter, [NotNull] List<Collider2D> results)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		return GetColliderContactsCollidersOnlyList_Injected(intPtr, ref contactFilter, results);
	}

	[NativeMethod("GetRigidbodyContactsCollidersOnlyList_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
	private static int GetRigidbodyContactsCollidersOnlyList([NotNull] Rigidbody2D rigidbody, ContactFilter2D contactFilter, [NotNull] List<Collider2D> results)
	{
		if ((object)rigidbody == null)
		{
			ThrowHelper.ThrowArgumentNullException(rigidbody, "rigidbody");
		}
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(rigidbody);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(rigidbody, "rigidbody");
		}
		return GetRigidbodyContactsCollidersOnlyList_Injected(intPtr, ref contactFilter, results);
	}

	internal static void SetEditorDragMovement(bool dragging, GameObject[] objs)
	{
		foreach (Rigidbody2D item in m_LastDisabledRigidbody2D)
		{
			if (item != null)
			{
				item.SetDragBehaviour(dragged: false);
			}
		}
		m_LastDisabledRigidbody2D.Clear();
		if (!dragging)
		{
			return;
		}
		foreach (GameObject gameObject in objs)
		{
			Rigidbody2D[] componentsInChildren = gameObject.GetComponentsInChildren<Rigidbody2D>(includeInactive: false);
			Rigidbody2D[] array = componentsInChildren;
			foreach (Rigidbody2D rigidbody2D in array)
			{
				m_LastDisabledRigidbody2D.Add(rigidbody2D);
				rigidbody2D.SetDragBehaviour(dragged: true);
			}
		}
	}

	[Obsolete("LinecastNonAlloc has neen deprecated. Please use Linecast.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results)
	{
		return defaultPhysicsScene.Linecast(start, end, results);
	}

	[Obsolete("LinecastNonAlloc has been deprecated. Please use Linecast.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.Linecast(start, end, contactFilter, results);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	[Obsolete("LinecastNonAlloc has been deprecated. Please use Linecast.", false)]
	public static int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.Linecast(start, end, contactFilter, results);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	[Obsolete("LinecastNonAlloc has been deprecated. Please use Linecast.", false)]
	public static int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.Linecast(start, end, contactFilter, results);
	}

	[Obsolete("RaycastNonAlloc has been deprecated. Please use Raycast.", false)]
	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results)
	{
		return defaultPhysicsScene.Raycast(origin, direction, float.PositiveInfinity, results);
	}

	[ExcludeFromDocs]
	[Obsolete("RaycastNonAlloc has been deprecated. Please use Raycast.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance)
	{
		return defaultPhysicsScene.Raycast(origin, direction, distance, results);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	[Obsolete("RaycastNonAlloc has been deprecated. Please use Raycast.", false)]
	public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.Raycast(origin, direction, distance, contactFilter, results);
	}

	[Obsolete("RaycastNonAlloc has been deprecated. Please use Raycast.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.Raycast(origin, direction, distance, contactFilter, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("CircleCastNonAlloc has been deprecated. Please use CircleCast instead.", false)]
	public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results)
	{
		return defaultPhysicsScene.CircleCast(origin, radius, direction, float.PositiveInfinity, results);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("CircleCastNonAlloc has been deprecated. Please use CircleCast instead.", false)]
	[ExcludeFromDocs]
	public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance)
	{
		return defaultPhysicsScene.CircleCast(origin, radius, direction, distance, results);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("CircleCastNonAlloc has been deprecated. Please use CircleCast instead.", false)]
	[ExcludeFromDocs]
	public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.CircleCast(origin, radius, direction, distance, contactFilter, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("CircleCastNonAlloc has been deprecated. Please use CircleCast instead.", false)]
	public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.CircleCast(origin, radius, direction, distance, contactFilter, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("CircleCastNonAlloc has been deprecated. Please use CircleCast instead.", false)]
	public static int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.CircleCast(origin, radius, direction, distance, contactFilter, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("BoxCastNonAlloc has been deprecated. Please use BoxCast.", false)]
	public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results)
	{
		return defaultPhysicsScene.BoxCast(origin, size, angle, direction, float.PositiveInfinity, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("BoxCastNonAlloc has been deprecated. Please use BoxCast.", false)]
	public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance)
	{
		return defaultPhysicsScene.BoxCast(origin, size, angle, direction, distance, results);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("BoxCastNonAlloc has been deprecated. Please use BoxCast.", false)]
	[ExcludeFromDocs]
	public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.BoxCast(origin, size, angle, direction, distance, contactFilter, results);
	}

	[Obsolete("BoxCastNonAlloc has been deprecated. Please use BoxCast.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.BoxCast(origin, size, angle, direction, distance, contactFilter, results);
	}

	[Obsolete("BoxCastNonAlloc has been deprecated. Please use BoxCast.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.BoxCast(origin, size, angle, direction, distance, contactFilter, results);
	}

	[Obsolete("CapsuleCastNonAlloc has been deprecated. Please use CapsuleCast.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static int CapsuleCastNonAlloc(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, RaycastHit2D[] results)
	{
		return defaultPhysicsScene.CapsuleCast(origin, size, capsuleDirection, angle, direction, float.PositiveInfinity, results);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	[Obsolete("CapsuleCastNonAlloc has been deprecated. Please use CapsuleCast.", false)]
	public static int CapsuleCastNonAlloc(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, RaycastHit2D[] results, float distance)
	{
		return defaultPhysicsScene.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("CapsuleCastNonAlloc has been deprecated. Please use CapsuleCast.", false)]
	public static int CapsuleCastNonAlloc(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, contactFilter, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("CapsuleCastNonAlloc has been deprecated. Please use CapsuleCast.", false)]
	public static int CapsuleCastNonAlloc(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, contactFilter, results);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("CapsuleCastNonAlloc has been deprecated. Please use CapsuleCast.", false)]
	[ExcludeFromDocs]
	public static int CapsuleCastNonAlloc(Vector2 origin, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Vector2 direction, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, contactFilter, results);
	}

	[Obsolete("GetRayIntersectionNonAlloc is deprecated. Please use GetRayIntersection.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static int GetRayIntersectionNonAlloc(Ray ray, RaycastHit2D[] results)
	{
		return defaultPhysicsScene.GetRayIntersection(ray, float.PositiveInfinity, results);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("GetRayIntersectionNonAlloc is deprecated. Please use GetRayIntersection.", false)]
	[ExcludeFromDocs]
	public static int GetRayIntersectionNonAlloc(Ray ray, RaycastHit2D[] results, float distance)
	{
		return defaultPhysicsScene.GetRayIntersection(ray, distance, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("OverlapPointNonAlloc has been deprecated. Please use OverlapPoint.", false)]
	public static int OverlapPointNonAlloc(Vector2 point, Collider2D[] results)
	{
		return defaultPhysicsScene.OverlapPoint(point, results);
	}

	[Obsolete("OverlapPointNonAlloc has been deprecated. Please use OverlapPoint.", false)]
	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static int OverlapPointNonAlloc(Vector2 point, Collider2D[] results, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapPoint(point, contactFilter, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("OverlapPointNonAlloc has been deprecated. Please use OverlapPoint.", false)]
	public static int OverlapPointNonAlloc(Vector2 point, Collider2D[] results, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapPoint(point, contactFilter, results);
	}

	[Obsolete("OverlapPointNonAlloc has been deprecated. Please use OverlapPoint.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static int OverlapPointNonAlloc(Vector2 point, Collider2D[] results, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.OverlapPoint(point, contactFilter, results);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	[Obsolete("OverlapCircleNonAlloc has been deprecated. Please use OverlapCircle.", false)]
	public static int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results)
	{
		return defaultPhysicsScene.OverlapCircle(point, radius, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("OverlapCircleNonAlloc has been deprecated. Please use OverlapCircle.", false)]
	public static int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapCircle(point, radius, contactFilter, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("OverlapCircleNonAlloc has been deprecated. Please use OverlapCircle.", false)]
	public static int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapCircle(point, radius, contactFilter, results);
	}

	[Obsolete("OverlapCircleNonAlloc has been deprecated. Please use OverlapCircle.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.OverlapCircle(point, radius, contactFilter, results);
	}

	[Obsolete("OverlapBoxNonAlloc has been deprecated. Please use OverlapBox.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static int OverlapBoxNonAlloc(Vector2 point, Vector2 size, float angle, Collider2D[] results)
	{
		return defaultPhysicsScene.OverlapBox(point, size, angle, results);
	}

	[Obsolete("OverlapBoxNonAlloc has been deprecated. Please use OverlapBox.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static int OverlapBoxNonAlloc(Vector2 point, Vector2 size, float angle, Collider2D[] results, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapBox(point, size, angle, contactFilter, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("OverlapBoxNonAlloc has been deprecated. Please use OverlapBox.", false)]
	public static int OverlapBoxNonAlloc(Vector2 point, Vector2 size, float angle, Collider2D[] results, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapBox(point, size, angle, contactFilter, results);
	}

	[Obsolete("OverlapBoxNonAlloc has been deprecated. Please use OverlapBox.", false)]
	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static int OverlapBoxNonAlloc(Vector2 point, Vector2 size, float angle, Collider2D[] results, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.OverlapBox(point, size, angle, contactFilter, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("OverlapAreaNonAlloc has been deprecated. Please use OverlapArea.", false)]
	public static int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results)
	{
		return defaultPhysicsScene.OverlapArea(pointA, pointB, results);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("OverlapAreaNonAlloc has been deprecated. Please use OverlapArea.", false)]
	[ExcludeFromDocs]
	public static int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapArea(pointA, pointB, contactFilter, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("OverlapAreaNonAlloc has been deprecated. Please use OverlapArea.", false)]
	public static int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapArea(pointA, pointB, contactFilter, results);
	}

	[ExcludeFromDocs]
	[Obsolete("OverlapAreaNonAlloc has been deprecated. Please use OverlapArea.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.OverlapArea(pointA, pointB, contactFilter, results);
	}

	[Obsolete("OverlapCapsuleNonAlloc has been deprecated. Please use OverlapCapsule.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static int OverlapCapsuleNonAlloc(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, Collider2D[] results)
	{
		return defaultPhysicsScene.OverlapCapsule(point, size, direction, angle, results);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("OverlapCapsuleNonAlloc has been deprecated. Please use OverlapCapsule.", false)]
	[ExcludeFromDocs]
	public static int OverlapCapsuleNonAlloc(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, Collider2D[] results, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapCapsule(point, size, direction, angle, contactFilter, results);
	}

	[Obsolete("OverlapCapsuleNonAlloc has been deprecated. Please use OverlapCapsule.", false)]
	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static int OverlapCapsuleNonAlloc(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, Collider2D[] results, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return defaultPhysicsScene.OverlapCapsule(point, size, direction, angle, contactFilter, results);
	}

	[Obsolete("OverlapCapsuleNonAlloc has been deprecated. Please use OverlapCapsule.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public static int OverlapCapsuleNonAlloc(Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, Collider2D[] results, [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return defaultPhysicsScene.OverlapCapsule(point, size, direction, angle, contactFilter, results);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_gravity_Injected(out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_gravity_Injected([In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_simulationLayers_Injected(out LayerMask ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_simulationLayers_Injected([In] ref LayerMask value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_jobOptions_Injected(out PhysicsJobOptions2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_jobOptions_Injected([In] ref PhysicsJobOptions2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Simulate_Internal_Injected([In] ref PhysicsScene2D physicsScene, float deltaTime, int simulationLayers);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void IgnoreCollision_Injected(IntPtr collider1, IntPtr collider2, [UnityEngine.Internal.DefaultValue("true")] bool ignore);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetIgnoreCollision_Injected(IntPtr collider1, IntPtr collider2);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsTouching_Injected(IntPtr collider1, IntPtr collider2);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsTouching_TwoCollidersWithFilter_Injected(IntPtr collider1, IntPtr collider2, [In] ref ContactFilter2D contactFilter);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsTouching_SingleColliderWithFilter_Injected(IntPtr collider, [In] ref ContactFilter2D contactFilter);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsTouchingLayers_Injected(IntPtr collider, [UnityEngine.Internal.DefaultValue("Physics2D.AllLayers")] int layerMask);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Distance_Internal_Injected(IntPtr colliderA, IntPtr colliderB, out ColliderDistance2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void DistanceFrom_Internal_Injected(IntPtr colliderA, [In] ref Vector2 positionA, float angleA, IntPtr colliderB, [In] ref Vector2 positionB, float angleB, out ColliderDistance2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ClosestPoint_Collider_Injected([In] ref Vector2 position, IntPtr collider, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ClosestPoint_Rigidbody_Injected([In] ref Vector2 position, IntPtr rigidbody, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void LinecastAll_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 start, [In] ref Vector2 end, [In] ref ContactFilter2D contactFilter, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RaycastAll_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CircleCastAll_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, float radius, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void BoxCastAll_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, [In] ref Vector2 size, float angle, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CapsuleCastAll_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 origin, [In] ref Vector2 size, CapsuleDirection2D capsuleDirection, float angle, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetRayIntersectionAll_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector3 origin, [In] ref Vector3 direction, float distance, int layerMask, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Collider2D[] OverlapPointAll_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, [In] ref ContactFilter2D contactFilter);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Collider2D[] OverlapCircleAll_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, float radius, [In] ref ContactFilter2D contactFilter);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Collider2D[] OverlapBoxAll_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, [In] ref Vector2 size, float angle, [In] ref ContactFilter2D contactFilter);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Collider2D[] OverlapCapsuleAll_Internal_Injected([In] ref PhysicsScene2D physicsScene, [In] ref Vector2 point, [In] ref Vector2 size, CapsuleDirection2D direction, float angle, [In] ref ContactFilter2D contactFilter);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetColliderContactsArray_Injected(IntPtr collider, [In] ref ContactFilter2D contactFilter, ref ManagedSpanWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetColliderColliderContactsArray_Injected(IntPtr collider1, IntPtr collider2, [In] ref ContactFilter2D contactFilter, ref ManagedSpanWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetRigidbodyContactsArray_Injected(IntPtr rigidbody, [In] ref ContactFilter2D contactFilter, ref ManagedSpanWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetColliderContactsCollidersOnlyArray_Injected(IntPtr collider, [In] ref ContactFilter2D contactFilter, Collider2D[] results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetRigidbodyContactsCollidersOnlyArray_Injected(IntPtr rigidbody, [In] ref ContactFilter2D contactFilter, Collider2D[] results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetColliderContactsList_Injected(IntPtr collider, [In] ref ContactFilter2D contactFilter, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetColliderColliderContactsList_Injected(IntPtr collider1, IntPtr collider2, [In] ref ContactFilter2D contactFilter, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetRigidbodyContactsList_Injected(IntPtr rigidbody, [In] ref ContactFilter2D contactFilter, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetColliderContactsCollidersOnlyList_Injected(IntPtr collider, [In] ref ContactFilter2D contactFilter, List<Collider2D> results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetRigidbodyContactsCollidersOnlyList_Injected(IntPtr rigidbody, [In] ref ContactFilter2D contactFilter, List<Collider2D> results);
}
public enum SimulationMode2D
{
	FixedUpdate,
	Update,
	Script
}
public enum CapsuleDirection2D
{
	Vertical,
	Horizontal
}
[Flags]
public enum RigidbodyConstraints2D
{
	None = 0,
	FreezePositionX = 1,
	FreezePositionY = 2,
	FreezeRotation = 4,
	FreezePosition = 3,
	FreezeAll = 7
}
public enum RigidbodyInterpolation2D
{
	None,
	Interpolate,
	Extrapolate
}
public enum RigidbodySleepMode2D
{
	NeverSleep,
	StartAwake,
	StartAsleep
}
public enum CollisionDetectionMode2D
{
	[Obsolete("Enum member CollisionDetectionMode2D.None has been deprecated. Use CollisionDetectionMode2D.Discrete instead (UnityUpgradable) -> Discrete", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	None = 0,
	Discrete = 0,
	Continuous = 1
}
public enum RigidbodyType2D
{
	Dynamic,
	Kinematic,
	Static
}
public enum ForceMode2D
{
	Force,
	Impulse
}
public enum ColliderErrorState2D
{
	None,
	NoShapes,
	RemovedShapes
}
public enum JointLimitState2D
{
	Inactive,
	LowerLimit,
	UpperLimit,
	EqualLimits
}
public enum JointBreakAction2D
{
	Ignore,
	CallbackOnly,
	Disable,
	Destroy
}
public enum EffectorSelection2D
{
	Rigidbody,
	Collider
}
public enum EffectorForceMode2D
{
	Constant,
	InverseLinear,
	InverseSquared
}
public enum PhysicsShapeType2D
{
	Circle,
	Capsule,
	Polygon,
	Edges
}
public enum PhysicsMaterialCombine2D
{
	Average,
	Mean,
	Multiply,
	Minimum,
	Maximum
}
[UsedByNativeCode]
[NativeHeader(Header = "Modules/Physics2D/Public/PhysicsScripting2D.h")]
public struct PhysicsShape2D
{
	private PhysicsShapeType2D m_ShapeType;

	private float m_Radius;

	private int m_VertexStartIndex;

	private int m_VertexCount;

	private int m_UseAdjacentStart;

	private int m_UseAdjacentEnd;

	private Vector2 m_AdjacentStart;

	private Vector2 m_AdjacentEnd;

	public PhysicsShapeType2D shapeType
	{
		get
		{
			return m_ShapeType;
		}
		set
		{
			m_ShapeType = value;
		}
	}

	public float radius
	{
		get
		{
			return m_Radius;
		}
		set
		{
			if (value < 0f)
			{
				throw new ArgumentOutOfRangeException("radius cannot be negative.");
			}
			if (float.IsNaN(value) || float.IsInfinity(value))
			{
				throw new ArgumentException("radius contains an invalid value.");
			}
			m_Radius = value;
		}
	}

	public int vertexStartIndex
	{
		get
		{
			return m_VertexStartIndex;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("vertexStartIndex cannot be negative.");
			}
			m_VertexStartIndex = value;
		}
	}

	public int vertexCount
	{
		get
		{
			return m_VertexCount;
		}
		set
		{
			if (value < 1)
			{
				throw new ArgumentOutOfRangeException("vertexCount cannot be less than one.");
			}
			m_VertexCount = value;
		}
	}

	public bool useAdjacentStart
	{
		get
		{
			return m_UseAdjacentStart != 0;
		}
		set
		{
			m_UseAdjacentStart = (value ? 1 : 0);
		}
	}

	public bool useAdjacentEnd
	{
		get
		{
			return m_UseAdjacentEnd != 0;
		}
		set
		{
			m_UseAdjacentEnd = (value ? 1 : 0);
		}
	}

	public Vector2 adjacentStart
	{
		get
		{
			return m_AdjacentStart;
		}
		set
		{
			if (float.IsNaN(value.x) || float.IsNaN(value.y) || float.IsInfinity(value.x) || float.IsInfinity(value.y))
			{
				throw new ArgumentException("adjacentStart contains an invalid value.");
			}
			m_AdjacentStart = value;
		}
	}

	public Vector2 adjacentEnd
	{
		get
		{
			return m_AdjacentEnd;
		}
		set
		{
			if (float.IsNaN(value.x) || float.IsNaN(value.y) || float.IsInfinity(value.x) || float.IsInfinity(value.y))
			{
				throw new ArgumentException("adjacentEnd contains an invalid value.");
			}
			m_AdjacentEnd = value;
		}
	}
}
public class PhysicsShapeGroup2D
{
	[NativeHeader(Header = "Modules/Physics2D/Public/PhysicsScripting2D.h")]
	internal struct GroupState
	{
		[NativeName("shapesList")]
		public List<PhysicsShape2D> m_Shapes;

		[NativeName("verticesList")]
		public List<Vector2> m_Vertices;

		[NativeName("localToWorld")]
		public Matrix4x4 m_LocalToWorld;

		public void ClearGeometry()
		{
			m_Shapes.Clear();
			m_Vertices.Clear();
		}
	}

	internal GroupState m_GroupState;

	private const float MinVertexSeparation = 0.0025f;

	internal List<Vector2> groupVertices => m_GroupState.m_Vertices;

	internal List<PhysicsShape2D> groupShapes => m_GroupState.m_Shapes;

	public int shapeCount => m_GroupState.m_Shapes.Count;

	public int vertexCount => m_GroupState.m_Vertices.Count;

	public Matrix4x4 localToWorldMatrix
	{
		get
		{
			return m_GroupState.m_LocalToWorld;
		}
		set
		{
			m_GroupState.m_LocalToWorld = value;
		}
	}

	public PhysicsShapeGroup2D([UnityEngine.Internal.DefaultValue("1")] int shapeCapacity = 1, [UnityEngine.Internal.DefaultValue("8")] int vertexCapacity = 8)
	{
		m_GroupState = new GroupState
		{
			m_Shapes = new List<PhysicsShape2D>(shapeCapacity),
			m_Vertices = new List<Vector2>(vertexCapacity),
			m_LocalToWorld = Matrix4x4.identity
		};
	}

	public void Clear()
	{
		m_GroupState.ClearGeometry();
		m_GroupState.m_LocalToWorld = Matrix4x4.identity;
	}

	public void Add(PhysicsShapeGroup2D physicsShapeGroup)
	{
		if (physicsShapeGroup == null)
		{
			throw new ArgumentNullException("Cannot merge a NULL PhysicsShapeGroup2D.");
		}
		if (physicsShapeGroup == this)
		{
			throw new ArgumentException("Cannot merge a PhysicsShapeGroup2D with itself.");
		}
		if (physicsShapeGroup.shapeCount == 0)
		{
			return;
		}
		int count = groupShapes.Count;
		int count2 = m_GroupState.m_Vertices.Count;
		groupShapes.AddRange(physicsShapeGroup.groupShapes);
		groupVertices.AddRange(physicsShapeGroup.groupVertices);
		if (count > 0)
		{
			for (int i = count; i < m_GroupState.m_Shapes.Count; i++)
			{
				PhysicsShape2D value = m_GroupState.m_Shapes[i];
				value.vertexStartIndex += count2;
				m_GroupState.m_Shapes[i] = value;
			}
		}
	}

	public void GetShapeData(List<PhysicsShape2D> shapes, List<Vector2> vertices)
	{
		shapes.AddRange(groupShapes);
		vertices.AddRange(groupVertices);
	}

	public void GetShapeData(NativeArray<PhysicsShape2D> shapes, NativeArray<Vector2> vertices)
	{
		if (!shapes.IsCreated || shapes.Length != shapeCount)
		{
			throw new ArgumentException($"Cannot get shape data as the native shapes array length must be identical to the current custom shape count of {shapeCount}.", "shapes");
		}
		if (!vertices.IsCreated || vertices.Length != vertexCount)
		{
			throw new ArgumentException($"Cannot get shape data as the native vertices array length must be identical to the current custom vertex count of {shapeCount}.", "vertices");
		}
		for (int i = 0; i < shapeCount; i++)
		{
			shapes[i] = m_GroupState.m_Shapes[i];
		}
		for (int j = 0; j < vertexCount; j++)
		{
			vertices[j] = m_GroupState.m_Vertices[j];
		}
	}

	public void GetShapeVertices(int shapeIndex, List<Vector2> vertices)
	{
		PhysicsShape2D shape = GetShape(shapeIndex);
		int num = shape.vertexCount;
		vertices.Clear();
		if (vertices.Capacity < num)
		{
			vertices.Capacity = num;
		}
		List<Vector2> list = groupVertices;
		int vertexStartIndex = shape.vertexStartIndex;
		for (int i = 0; i < num; i++)
		{
			vertices.Add(list[vertexStartIndex++]);
		}
	}

	public Vector2 GetShapeVertex(int shapeIndex, int vertexIndex)
	{
		int num = GetShape(shapeIndex).vertexStartIndex + vertexIndex;
		if (num < 0 || num >= groupVertices.Count)
		{
			throw new ArgumentOutOfRangeException($"Cannot get shape-vertex at index {num}. There are {shapeCount} shape-vertices.");
		}
		return groupVertices[num];
	}

	public void SetShapeVertex(int shapeIndex, int vertexIndex, Vector2 vertex)
	{
		int num = GetShape(shapeIndex).vertexStartIndex + vertexIndex;
		if (num < 0 || num >= groupVertices.Count)
		{
			throw new ArgumentOutOfRangeException($"Cannot set shape-vertex at index {num}. There are {shapeCount} shape-vertices.");
		}
		groupVertices[num] = vertex;
	}

	public void SetShapeRadius(int shapeIndex, float radius)
	{
		PhysicsShape2D shape = GetShape(shapeIndex);
		switch (shape.shapeType)
		{
		case PhysicsShapeType2D.Circle:
			if (radius <= 0f)
			{
				throw new ArgumentException($"Circle radius {radius} must be greater than zero.");
			}
			break;
		case PhysicsShapeType2D.Capsule:
			if (radius <= 1E-05f)
			{
				throw new ArgumentException($"Capsule radius: {radius} is too small.");
			}
			break;
		case PhysicsShapeType2D.Polygon:
		case PhysicsShapeType2D.Edges:
			radius = Mathf.Max(0f, radius);
			break;
		}
		shape.radius = radius;
		groupShapes[shapeIndex] = shape;
	}

	public void SetShapeAdjacentVertices(int shapeIndex, bool useAdjacentStart, bool useAdjacentEnd, Vector2 adjacentStart, Vector2 adjacentEnd)
	{
		if (shapeIndex < 0 || shapeIndex >= shapeCount)
		{
			throw new ArgumentOutOfRangeException($"Cannot set shape adjacent vertices at index {shapeIndex}. There are {shapeCount} shapes(s).");
		}
		PhysicsShape2D value = groupShapes[shapeIndex];
		if (value.shapeType != PhysicsShapeType2D.Edges)
		{
			throw new InvalidOperationException($"Cannot set shape adjacent vertices at index {shapeIndex}. The shape must be of type {PhysicsShapeType2D.Edges} but it is of typee {value.shapeType}.");
		}
		value.useAdjacentStart = useAdjacentStart;
		value.useAdjacentEnd = useAdjacentEnd;
		value.adjacentStart = adjacentStart;
		value.adjacentEnd = adjacentEnd;
		groupShapes[shapeIndex] = value;
	}

	public void DeleteShape(int shapeIndex)
	{
		if (shapeIndex < 0 || shapeIndex >= shapeCount)
		{
			throw new ArgumentOutOfRangeException($"Cannot delete shape at index {shapeIndex}. There are {shapeCount} shapes(s).");
		}
		PhysicsShape2D physicsShape2D = groupShapes[shapeIndex];
		int num = physicsShape2D.vertexCount;
		groupShapes.RemoveAt(shapeIndex);
		groupVertices.RemoveRange(physicsShape2D.vertexStartIndex, num);
		while (shapeIndex < groupShapes.Count)
		{
			PhysicsShape2D value = m_GroupState.m_Shapes[shapeIndex];
			value.vertexStartIndex -= num;
			m_GroupState.m_Shapes[shapeIndex++] = value;
		}
	}

	public PhysicsShape2D GetShape(int shapeIndex)
	{
		if (shapeIndex < 0 || shapeIndex >= shapeCount)
		{
			throw new ArgumentOutOfRangeException($"Cannot get shape at index {shapeIndex}. There are {shapeCount} shapes(s).");
		}
		return groupShapes[shapeIndex];
	}

	public int AddCircle(Vector2 center, float radius)
	{
		if (radius <= 0f)
		{
			throw new ArgumentException($"radius {radius} must be greater than zero.");
		}
		int count = groupVertices.Count;
		groupVertices.Add(center);
		groupShapes.Add(new PhysicsShape2D
		{
			shapeType = PhysicsShapeType2D.Circle,
			radius = radius,
			vertexStartIndex = count,
			vertexCount = 1
		});
		return groupShapes.Count - 1;
	}

	public int AddCapsule(Vector2 vertex0, Vector2 vertex1, float radius)
	{
		if (radius <= 1E-05f)
		{
			throw new ArgumentException($"radius: {radius} is too small.");
		}
		int count = groupVertices.Count;
		groupVertices.Add(vertex0);
		groupVertices.Add(vertex1);
		groupShapes.Add(new PhysicsShape2D
		{
			shapeType = PhysicsShapeType2D.Capsule,
			radius = radius,
			vertexStartIndex = count,
			vertexCount = 2
		});
		return groupShapes.Count - 1;
	}

	public int AddBox(Vector2 center, Vector2 size, [UnityEngine.Internal.DefaultValue("0f")] float angle = 0f, [UnityEngine.Internal.DefaultValue("0f")] float edgeRadius = 0f)
	{
		if (size.x <= 0.0025f || size.y <= 0.0025f)
		{
			throw new ArgumentException($"size: {size} is too small. Vertex need to be separated by at least {0.0025f}");
		}
		edgeRadius = Mathf.Max(0f, edgeRadius);
		angle *= MathF.PI / 180f;
		float cos = Mathf.Cos(angle);
		float sin = Mathf.Sin(angle);
		Vector2 vector = size * 0.5f;
		Vector2 item = center + Rotate(cos, sin, -vector);
		Vector2 item2 = center + Rotate(cos, sin, new Vector2(vector.x, 0f - vector.y));
		Vector2 item3 = center + Rotate(cos, sin, vector);
		Vector2 item4 = center + Rotate(cos, sin, new Vector2(0f - vector.x, vector.y));
		int count = groupVertices.Count;
		groupVertices.Add(item);
		groupVertices.Add(item2);
		groupVertices.Add(item3);
		groupVertices.Add(item4);
		groupShapes.Add(new PhysicsShape2D
		{
			shapeType = PhysicsShapeType2D.Polygon,
			radius = edgeRadius,
			vertexStartIndex = count,
			vertexCount = 4
		});
		return groupShapes.Count - 1;
		static Vector2 Rotate(float num, float num2, Vector2 value)
		{
			return new Vector2(num * value.x - num2 * value.y, num2 * value.x + num * value.y);
		}
	}

	public int AddPolygon(List<Vector2> vertices)
	{
		int count = vertices.Count;
		if (count < 3 || count > 8)
		{
			throw new ArgumentException($"Vertex Count {count} must be >= 3 and <= {8}.");
		}
		float num = 6.25E-06f;
		for (int i = 1; i < count; i++)
		{
			Vector2 vector = vertices[i - 1];
			Vector2 vector2 = vertices[i];
			if ((vector2 - vector).sqrMagnitude <= num)
			{
				throw new ArgumentException($"vertices: {vector} and {vector2} are too close. Vertices need to be separated by at least {num}");
			}
		}
		int count2 = groupVertices.Count;
		groupVertices.AddRange(vertices);
		groupShapes.Add(new PhysicsShape2D
		{
			shapeType = PhysicsShapeType2D.Polygon,
			radius = 0f,
			vertexStartIndex = count2,
			vertexCount = count
		});
		return groupShapes.Count - 1;
	}

	public int AddEdges(List<Vector2> vertices, [UnityEngine.Internal.DefaultValue("0f")] float edgeRadius = 0f)
	{
		return AddEdges(vertices, useAdjacentStart: false, useAdjacentEnd: false, Vector2.zero, Vector2.zero, edgeRadius);
	}

	public int AddEdges(List<Vector2> vertices, bool useAdjacentStart, bool useAdjacentEnd, Vector2 adjacentStart, Vector2 adjacentEnd, [UnityEngine.Internal.DefaultValue("0f")] float edgeRadius = 0f)
	{
		int count = vertices.Count;
		if (count < 2)
		{
			throw new ArgumentOutOfRangeException($"Vertex Count {count} must be >= 2.");
		}
		edgeRadius = Mathf.Max(0f, edgeRadius);
		int count2 = groupVertices.Count;
		groupVertices.AddRange(vertices);
		groupShapes.Add(new PhysicsShape2D
		{
			shapeType = PhysicsShapeType2D.Edges,
			radius = edgeRadius,
			vertexStartIndex = count2,
			vertexCount = count,
			useAdjacentStart = useAdjacentStart,
			useAdjacentEnd = useAdjacentEnd,
			adjacentStart = adjacentStart,
			adjacentEnd = adjacentEnd
		});
		return groupShapes.Count - 1;
	}
}
public struct ColliderDistance2D
{
	private Vector2 m_PointA;

	private Vector2 m_PointB;

	private Vector2 m_Normal;

	private float m_Distance;

	private int m_IsValid;

	public Vector2 pointA
	{
		get
		{
			return m_PointA;
		}
		set
		{
			m_PointA = value;
		}
	}

	public Vector2 pointB
	{
		get
		{
			return m_PointB;
		}
		set
		{
			m_PointB = value;
		}
	}

	public Vector2 normal => m_Normal;

	public float distance
	{
		get
		{
			return m_Distance;
		}
		set
		{
			m_Distance = value;
		}
	}

	public bool isOverlapped => m_Distance < 0f;

	public bool isValid
	{
		get
		{
			return m_IsValid != 0;
		}
		set
		{
			m_IsValid = (value ? 1 : 0);
		}
	}
}
[Serializable]
[NativeClass("ContactFilter", "struct ContactFilter;")]
[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
[NativeHeader("Modules/Physics2D/Public/Collider2D.h")]
public struct ContactFilter2D
{
	private static ContactFilter2D _noFilter = new ContactFilter2D
	{
		useTriggers = true,
		useLayerMask = false,
		layerMask = -1,
		useDepth = false,
		useOutsideDepth = false,
		minDepth = float.NegativeInfinity,
		maxDepth = float.PositiveInfinity,
		useNormalAngle = false,
		useOutsideNormalAngle = false,
		minNormalAngle = 0f,
		maxNormalAngle = 359.9999f
	};

	[NativeName("m_UseTriggers")]
	public bool useTriggers;

	[NativeName("m_UseLayerMask")]
	public bool useLayerMask;

	[NativeName("m_UseDepth")]
	public bool useDepth;

	[NativeName("m_UseOutsideDepth")]
	public bool useOutsideDepth;

	[NativeName("m_UseNormalAngle")]
	public bool useNormalAngle;

	[NativeName("m_UseOutsideNormalAngle")]
	public bool useOutsideNormalAngle;

	[NativeName("m_LayerMask")]
	public LayerMask layerMask;

	[NativeName("m_MinDepth")]
	public float minDepth;

	[NativeName("m_MaxDepth")]
	public float maxDepth;

	[NativeName("m_MinNormalAngle")]
	public float minNormalAngle;

	[NativeName("m_MaxNormalAngle")]
	public float maxNormalAngle;

	public const float NormalAngleUpperLimit = 359.9999f;

	public static ContactFilter2D noFilter => _noFilter;

	public bool isFiltering => !useTriggers || useLayerMask || useDepth || useNormalAngle;

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern void CheckConsistency();

	public void ClearLayerMask()
	{
		useLayerMask = false;
	}

	public void SetLayerMask(LayerMask layerMask)
	{
		this.layerMask = layerMask;
		useLayerMask = true;
	}

	public void ClearDepth()
	{
		useDepth = false;
	}

	public void SetDepth(float minDepth, float maxDepth)
	{
		this.minDepth = minDepth;
		this.maxDepth = maxDepth;
		useDepth = true;
		CheckConsistency();
	}

	public void ClearNormalAngle()
	{
		useNormalAngle = false;
	}

	public void SetNormalAngle(float minNormalAngle, float maxNormalAngle)
	{
		this.minNormalAngle = minNormalAngle;
		this.maxNormalAngle = maxNormalAngle;
		useNormalAngle = true;
		CheckConsistency();
	}

	public bool IsFilteringTrigger(Collider2D collider)
	{
		return !useTriggers && collider.isTrigger;
	}

	public bool IsFilteringLayerMask(GameObject obj)
	{
		return useLayerMask && ((int)layerMask & (1 << obj.layer)) == 0;
	}

	public bool IsFilteringDepth(GameObject obj)
	{
		if (!useDepth)
		{
			return false;
		}
		if (minDepth > maxDepth)
		{
			float num = minDepth;
			minDepth = maxDepth;
			maxDepth = num;
		}
		float z = obj.transform.position.z;
		bool flag = z < minDepth || z > maxDepth;
		if (useOutsideDepth)
		{
			return !flag;
		}
		return flag;
	}

	public bool IsFilteringNormalAngle(Vector2 normal)
	{
		return IsFilteringNormalAngle_Injected(ref this, ref normal);
	}

	public bool IsFilteringNormalAngle(float angle)
	{
		return IsFilteringNormalAngleUsingAngle(angle);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern bool IsFilteringNormalAngleUsingAngle(float angle);

	internal static ContactFilter2D CreateLegacyFilter(int layerMask, float minDepth, float maxDepth)
	{
		ContactFilter2D result = default(ContactFilter2D);
		result.useTriggers = Physics2D.queriesHitTriggers;
		result.SetLayerMask(layerMask);
		result.SetDepth(minDepth, maxDepth);
		return result;
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("ContactFilter2D.NoFilter method has been deprecated. Please use the static ContactFilter2D.noFilter property.", false)]
	public ContactFilter2D NoFilter()
	{
		return noFilter;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsFilteringNormalAngle_Injected(ref ContactFilter2D _unity_self, [In] ref Vector2 normal);
}
[StructLayout(LayoutKind.Sequential)]
[RequiredByNativeCode]
public class Collision2D
{
	internal int m_Collider;

	internal int m_OtherCollider;

	internal int m_Rigidbody;

	internal int m_OtherRigidbody;

	internal Vector2 m_RelativeVelocity;

	internal int m_Enabled;

	internal int m_ContactCount;

	internal ContactPoint2D[] m_ReusedContacts;

	internal ContactPoint2D[] m_LegacyContacts;

	public Collider2D collider => Object.FindObjectFromInstanceID(m_Collider) as Collider2D;

	public Collider2D otherCollider => Object.FindObjectFromInstanceID(m_OtherCollider) as Collider2D;

	public Rigidbody2D rigidbody => Object.FindObjectFromInstanceID(m_Rigidbody) as Rigidbody2D;

	public Rigidbody2D otherRigidbody => Object.FindObjectFromInstanceID(m_OtherRigidbody) as Rigidbody2D;

	public Transform transform => (rigidbody != null) ? rigidbody.transform : collider.transform;

	public GameObject gameObject => (rigidbody != null) ? rigidbody.gameObject : collider.gameObject;

	public Vector2 relativeVelocity => m_RelativeVelocity;

	public bool enabled => m_Enabled == 1;

	public ContactPoint2D[] contacts
	{
		get
		{
			if (m_LegacyContacts == null)
			{
				m_LegacyContacts = new ContactPoint2D[m_ContactCount];
				Array.Copy(m_ReusedContacts, m_LegacyContacts, m_ContactCount);
			}
			return m_LegacyContacts;
		}
	}

	public int contactCount => m_ContactCount;

	private ContactPoint2D[] GetContacts_Internal()
	{
		return (m_LegacyContacts == null) ? m_ReusedContacts : m_LegacyContacts;
	}

	public ContactPoint2D GetContact(int index)
	{
		if (index < 0 || index >= m_ContactCount)
		{
			throw new ArgumentOutOfRangeException($"Cannot get contact at index {index}. There are {m_ContactCount} contact(s).");
		}
		return GetContacts_Internal()[index];
	}

	public int GetContacts(ContactPoint2D[] contacts)
	{
		if (contacts == null)
		{
			throw new NullReferenceException("Cannot get contacts as the provided array is NULL.");
		}
		int num = Mathf.Min(m_ContactCount, contacts.Length);
		Array.Copy(GetContacts_Internal(), contacts, num);
		return num;
	}

	public int GetContacts(List<ContactPoint2D> contacts)
	{
		if (contacts == null)
		{
			throw new NullReferenceException("Cannot get contacts as the provided list is NULL.");
		}
		contacts.Clear();
		ContactPoint2D[] contacts_Internal = GetContacts_Internal();
		for (int i = 0; i < m_ContactCount; i++)
		{
			contacts.Add(contacts_Internal[i]);
		}
		return m_ContactCount;
	}
}
[RequiredByNativeCode(Optional = false, GenerateProxy = true)]
[NativeClass("ScriptingContactPoint2D", "struct ScriptingContactPoint2D;")]
[NativeHeader("Modules/Physics2D/Public/PhysicsScripting2D.h")]
public struct ContactPoint2D
{
	[NativeName("point")]
	private Vector2 m_Point;

	[NativeName("normal")]
	private Vector2 m_Normal;

	[NativeName("relativeVelocity")]
	private Vector2 m_RelativeVelocity;

	[NativeName("friction")]
	private float m_Friction;

	[NativeName("bounciness")]
	private float m_Bounciness;

	[NativeName("separation")]
	private float m_Separation;

	[NativeName("normalImpulse")]
	private float m_NormalImpulse;

	[NativeName("tangentImpulse")]
	private float m_TangentImpulse;

	[NativeName("collider")]
	private int m_Collider;

	[NativeName("otherCollider")]
	private int m_OtherCollider;

	[NativeName("rigidbody")]
	private int m_Rigidbody;

	[NativeName("otherRigidbody")]
	private int m_OtherRigidbody;

	[NativeName("enabled")]
	private int m_Enabled;

	public Vector2 point => m_Point;

	public Vector2 normal => m_Normal;

	public float separation => m_Separation;

	public float normalImpulse => m_NormalImpulse;

	public float tangentImpulse => m_TangentImpulse;

	public Vector2 relativeVelocity => m_RelativeVelocity;

	public float friction => m_Friction;

	public float bounciness => m_Bounciness;

	public Collider2D collider => Object.FindObjectFromInstanceID(m_Collider) as Collider2D;

	public Collider2D otherCollider => Object.FindObjectFromInstanceID(m_OtherCollider) as Collider2D;

	public Rigidbody2D rigidbody => Object.FindObjectFromInstanceID(m_Rigidbody) as Rigidbody2D;

	public Rigidbody2D otherRigidbody => Object.FindObjectFromInstanceID(m_OtherRigidbody) as Rigidbody2D;

	public bool enabled => m_Enabled == 1;
}
public struct JointAngleLimits2D
{
	private float m_LowerAngle;

	private float m_UpperAngle;

	public float min
	{
		get
		{
			return m_LowerAngle;
		}
		set
		{
			m_LowerAngle = value;
		}
	}

	public float max
	{
		get
		{
			return m_UpperAngle;
		}
		set
		{
			m_UpperAngle = value;
		}
	}
}
public struct JointTranslationLimits2D
{
	private float m_LowerTranslation;

	private float m_UpperTranslation;

	public float min
	{
		get
		{
			return m_LowerTranslation;
		}
		set
		{
			m_LowerTranslation = value;
		}
	}

	public float max
	{
		get
		{
			return m_UpperTranslation;
		}
		set
		{
			m_UpperTranslation = value;
		}
	}
}
public struct JointMotor2D
{
	private float m_MotorSpeed;

	private float m_MaximumMotorTorque;

	public float motorSpeed
	{
		get
		{
			return m_MotorSpeed;
		}
		set
		{
			m_MotorSpeed = value;
		}
	}

	public float maxMotorTorque
	{
		get
		{
			return m_MaximumMotorTorque;
		}
		set
		{
			m_MaximumMotorTorque = value;
		}
	}
}
public struct JointSuspension2D
{
	private float m_DampingRatio;

	private float m_Frequency;

	private float m_Angle;

	public float dampingRatio
	{
		get
		{
			return m_DampingRatio;
		}
		set
		{
			m_DampingRatio = value;
		}
	}

	public float frequency
	{
		get
		{
			return m_Frequency;
		}
		set
		{
			m_Frequency = value;
		}
	}

	public float angle
	{
		get
		{
			return m_Angle;
		}
		set
		{
			m_Angle = value;
		}
	}
}
[NativeHeader("Runtime/Interfaces/IPhysics2D.h")]
[NativeClass("RaycastHit2D", "struct RaycastHit2D;")]
[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
public struct RaycastHit2D
{
	[NativeName("centroid")]
	private Vector2 m_Centroid;

	[NativeName("point")]
	private Vector2 m_Point;

	[NativeName("normal")]
	private Vector2 m_Normal;

	[NativeName("distance")]
	private float m_Distance;

	[NativeName("fraction")]
	private float m_Fraction;

	[NativeName("collider")]
	private int m_Collider;

	public Vector2 centroid
	{
		get
		{
			return m_Centroid;
		}
		set
		{
			m_Centroid = value;
		}
	}

	public Vector2 point
	{
		get
		{
			return m_Point;
		}
		set
		{
			m_Point = value;
		}
	}

	public Vector2 normal
	{
		get
		{
			return m_Normal;
		}
		set
		{
			m_Normal = value;
		}
	}

	public float distance
	{
		get
		{
			return m_Distance;
		}
		set
		{
			m_Distance = value;
		}
	}

	public float fraction
	{
		get
		{
			return m_Fraction;
		}
		set
		{
			m_Fraction = value;
		}
	}

	public Collider2D collider => Object.FindObjectFromInstanceID(m_Collider) as Collider2D;

	public Rigidbody2D rigidbody => (collider != null) ? collider.attachedRigidbody : null;

	public Transform transform
	{
		get
		{
			Rigidbody2D rigidbody2D = rigidbody;
			if (rigidbody2D != null)
			{
				return rigidbody2D.transform;
			}
			if (collider != null)
			{
				return collider.transform;
			}
			return null;
		}
	}

	public static implicit operator bool(RaycastHit2D hit)
	{
		return hit.collider != null;
	}

	public int CompareTo(RaycastHit2D other)
	{
		if (collider == null)
		{
			return 1;
		}
		if (other.collider == null)
		{
			return -1;
		}
		return fraction.CompareTo(other.fraction);
	}
}
[NativeHeader("Modules/Physics2D/Public/Physics2DSettings.h")]
[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
[NativeClass("PhysicsJobOptions2D", "struct PhysicsJobOptions2D;")]
public struct PhysicsJobOptions2D
{
	private bool m_UseMultithreading;

	private bool m_UseConsistencySorting;

	private int m_InterpolationPosesPerJob;

	private int m_NewContactsPerJob;

	private int m_CollideContactsPerJob;

	private int m_ClearFlagsPerJob;

	private int m_ClearBodyForcesPerJob;

	private int m_SyncDiscreteFixturesPerJob;

	private int m_SyncContinuousFixturesPerJob;

	private int m_FindNearestContactsPerJob;

	private int m_UpdateTriggerContactsPerJob;

	private int m_IslandSolverCostThreshold;

	private int m_IslandSolverBodyCostScale;

	private int m_IslandSolverContactCostScale;

	private int m_IslandSolverJointCostScale;

	private int m_IslandSolverBodiesPerJob;

	private int m_IslandSolverContactsPerJob;

	public bool useMultithreading
	{
		get
		{
			return m_UseMultithreading;
		}
		set
		{
			m_UseMultithreading = value;
		}
	}

	public bool useConsistencySorting
	{
		get
		{
			return m_UseConsistencySorting;
		}
		set
		{
			m_UseConsistencySorting = value;
		}
	}

	public int interpolationPosesPerJob
	{
		get
		{
			return m_InterpolationPosesPerJob;
		}
		set
		{
			m_InterpolationPosesPerJob = value;
		}
	}

	public int newContactsPerJob
	{
		get
		{
			return m_NewContactsPerJob;
		}
		set
		{
			m_NewContactsPerJob = value;
		}
	}

	public int collideContactsPerJob
	{
		get
		{
			return m_CollideContactsPerJob;
		}
		set
		{
			m_CollideContactsPerJob = value;
		}
	}

	public int clearFlagsPerJob
	{
		get
		{
			return m_ClearFlagsPerJob;
		}
		set
		{
			m_ClearFlagsPerJob = value;
		}
	}

	public int clearBodyForcesPerJob
	{
		get
		{
			return m_ClearBodyForcesPerJob;
		}
		set
		{
			m_ClearBodyForcesPerJob = value;
		}
	}

	public int syncDiscreteFixturesPerJob
	{
		get
		{
			return m_SyncDiscreteFixturesPerJob;
		}
		set
		{
			m_SyncDiscreteFixturesPerJob = value;
		}
	}

	public int syncContinuousFixturesPerJob
	{
		get
		{
			return m_SyncContinuousFixturesPerJob;
		}
		set
		{
			m_SyncContinuousFixturesPerJob = value;
		}
	}

	public int findNearestContactsPerJob
	{
		get
		{
			return m_FindNearestContactsPerJob;
		}
		set
		{
			m_FindNearestContactsPerJob = value;
		}
	}

	public int updateTriggerContactsPerJob
	{
		get
		{
			return m_UpdateTriggerContactsPerJob;
		}
		set
		{
			m_UpdateTriggerContactsPerJob = value;
		}
	}

	public int islandSolverCostThreshold
	{
		get
		{
			return m_IslandSolverCostThreshold;
		}
		set
		{
			m_IslandSolverCostThreshold = value;
		}
	}

	public int islandSolverBodyCostScale
	{
		get
		{
			return m_IslandSolverBodyCostScale;
		}
		set
		{
			m_IslandSolverBodyCostScale = value;
		}
	}

	public int islandSolverContactCostScale
	{
		get
		{
			return m_IslandSolverContactCostScale;
		}
		set
		{
			m_IslandSolverContactCostScale = value;
		}
	}

	public int islandSolverJointCostScale
	{
		get
		{
			return m_IslandSolverJointCostScale;
		}
		set
		{
			m_IslandSolverJointCostScale = value;
		}
	}

	public int islandSolverBodiesPerJob
	{
		get
		{
			return m_IslandSolverBodiesPerJob;
		}
		set
		{
			m_IslandSolverBodiesPerJob = value;
		}
	}

	public int islandSolverContactsPerJob
	{
		get
		{
			return m_IslandSolverContactsPerJob;
		}
		set
		{
			m_IslandSolverContactsPerJob = value;
		}
	}
}
[NativeHeader("Modules/Physics2D/Public/Rigidbody2D.h")]
[RequireComponent(typeof(Transform))]
public sealed class Rigidbody2D : Component
{
	[Serializable]
	[NativeHeader(Header = "Modules/Physics2D/Public/Rigidbody2D.h")]
	public struct SlideMovement
	{
		[field: SerializeField]
		public int maxIterations { get; set; } = 3;

		[field: SerializeField]
		public float surfaceSlideAngle { get; set; } = 90f;

		[field: SerializeField]
		public float gravitySlipAngle { get; set; } = 90f;

		[field: SerializeField]
		public Vector2 surfaceUp { get; set; } = Vector2.up;

		[field: SerializeField]
		public Vector2 surfaceAnchor { get; set; } = Vector2.down;

		[field: SerializeField]
		public Vector2 gravity { get; set; } = new Vector2(0f, -9.81f);

		[field: SerializeField]
		public Vector2 startPosition { get; set; } = Vector2.zero;

		[field: SerializeField]
		public Collider2D selectedCollider { get; set; } = null;

		[field: SerializeField]
		public LayerMask layerMask { get; set; } = -1;

		[field: SerializeField]
		public bool useLayerMask { get; set; } = false;

		[field: SerializeField]
		public bool useStartPosition { get; set; } = false;

		[field: SerializeField]
		public bool useNoMove { get; set; } = false;

		[field: SerializeField]
		public bool useSimulationMove { get; set; } = false;

		[field: SerializeField]
		public bool useAttachedTriggers { get; set; } = false;

		public SlideMovement()
		{
		}

		public void SetLayerMask(LayerMask mask)
		{
			layerMask = mask;
			useLayerMask = true;
		}

		public void SetStartPosition(Vector2 position)
		{
			startPosition = position;
			useStartPosition = true;
		}
	}

	[Serializable]
	[NativeHeader(Header = "Modules/Physics2D/Public/Rigidbody2D.h")]
	public struct SlideResults
	{
		[field: SerializeField]
		public Vector2 remainingVelocity { get; set; }

		[field: SerializeField]
		public Vector2 position { get; set; }

		[field: SerializeField]
		public int iterationsUsed { get; set; }

		[field: SerializeField]
		public RaycastHit2D slideHit { get; set; }

		[field: SerializeField]
		public RaycastHit2D surfaceHit { get; set; }
	}

	public Vector2 position
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_position_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_position_Injected(intPtr, ref value);
		}
	}

	public float rotation
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_rotation_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_rotation_Injected(intPtr, value);
		}
	}

	public Vector2 linearVelocity
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_linearVelocity_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_linearVelocity_Injected(intPtr, ref value);
		}
	}

	public float linearVelocityX
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_linearVelocityX_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_linearVelocityX_Injected(intPtr, value);
		}
	}

	public float linearVelocityY
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_linearVelocityY_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_linearVelocityY_Injected(intPtr, value);
		}
	}

	public float angularVelocity
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_angularVelocity_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_angularVelocity_Injected(intPtr, value);
		}
	}

	public bool useAutoMass
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useAutoMass_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useAutoMass_Injected(intPtr, value);
		}
	}

	public float mass
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_mass_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_mass_Injected(intPtr, value);
		}
	}

	[NativeMethod("Material")]
	public PhysicsMaterial2D sharedMaterial
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<PhysicsMaterial2D>(get_sharedMaterial_Injected(intPtr));
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_sharedMaterial_Injected(intPtr, MarshalledUnityObject.Marshal(value));
		}
	}

	public Vector2 centerOfMass
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_centerOfMass_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_centerOfMass_Injected(intPtr, ref value);
		}
	}

	public Vector2 worldCenterOfMass
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_worldCenterOfMass_Injected(intPtr, out var ret);
			return ret;
		}
	}

	public float inertia
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_inertia_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_inertia_Injected(intPtr, value);
		}
	}

	public float linearDamping
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_linearDamping_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_linearDamping_Injected(intPtr, value);
		}
	}

	public float angularDamping
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_angularDamping_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_angularDamping_Injected(intPtr, value);
		}
	}

	public float gravityScale
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_gravityScale_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_gravityScale_Injected(intPtr, value);
		}
	}

	public RigidbodyType2D bodyType
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_bodyType_Injected(intPtr);
		}
		[NativeMethod("SetBodyType_Binding")]
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_bodyType_Injected(intPtr, value);
		}
	}

	public bool useFullKinematicContacts
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useFullKinematicContacts_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useFullKinematicContacts_Injected(intPtr, value);
		}
	}

	public bool freezeRotation
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_freezeRotation_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_freezeRotation_Injected(intPtr, value);
		}
	}

	public RigidbodyConstraints2D constraints
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_constraints_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_constraints_Injected(intPtr, value);
		}
	}

	public bool simulated
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_simulated_Injected(intPtr);
		}
		[NativeMethod("SetSimulated_Binding")]
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_simulated_Injected(intPtr, value);
		}
	}

	public RigidbodyInterpolation2D interpolation
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_interpolation_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_interpolation_Injected(intPtr, value);
		}
	}

	public RigidbodySleepMode2D sleepMode
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_sleepMode_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_sleepMode_Injected(intPtr, value);
		}
	}

	public CollisionDetectionMode2D collisionDetectionMode
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_collisionDetectionMode_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_collisionDetectionMode_Injected(intPtr, value);
		}
	}

	public int attachedColliderCount => GetAttachedColliderCount_Internal(findTriggers: true);

	public Vector2 totalForce
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_totalForce_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_totalForce_Injected(intPtr, ref value);
		}
	}

	public float totalTorque
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_totalTorque_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_totalTorque_Injected(intPtr, value);
		}
	}

	public LayerMask excludeLayers
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_excludeLayers_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_excludeLayers_Injected(intPtr, ref value);
		}
	}

	public LayerMask includeLayers
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_includeLayers_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_includeLayers_Injected(intPtr, ref value);
		}
	}

	public Matrix4x4 localToWorldMatrix
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_localToWorldMatrix_Injected(intPtr, out var ret);
			return ret;
		}
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Rigidbody2D.fixedAngle is obsolete. Use Rigidbody2D.constraints instead.", true)]
	public bool fixedAngle
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[Obsolete("isKinematic has been deprecated. Please use bodyType.", false)]
	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool isKinematic
	{
		get
		{
			return bodyType == RigidbodyType2D.Kinematic;
		}
		set
		{
			bodyType = (value ? RigidbodyType2D.Kinematic : RigidbodyType2D.Dynamic);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("drag has been deprecated. Please use linearDamping. (UnityUpgradable) -> linearDamping", false)]
	[ExcludeFromDocs]
	public float drag
	{
		get
		{
			return linearDamping;
		}
		set
		{
			linearDamping = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	[Obsolete("angularDrag has been deprecated. Please use angularDamping. (UnityUpgradable) -> angularDamping", false)]
	public float angularDrag
	{
		get
		{
			return angularDamping;
		}
		set
		{
			angularDamping = value;
		}
	}

	[Obsolete("velocity has been deprecated. Please use linearVelocity. (UnityUpgradable) -> linearVelocity", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromDocs]
	public Vector2 velocity
	{
		get
		{
			return linearVelocity;
		}
		set
		{
			linearVelocity = value;
		}
	}

	[ExcludeFromDocs]
	[Obsolete("velocityX has been deprecated. Please use linearVelocityX. (UnityUpgradable) -> linearVelocityX", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public float velocityX
	{
		get
		{
			return linearVelocityX;
		}
		set
		{
			linearVelocityX = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("velocityY has been deprecated. Please use linearVelocityY (UnityUpgradable) -> linearVelocityY", false)]
	[ExcludeFromDocs]
	public float velocityY
	{
		get
		{
			return linearVelocityY;
		}
		set
		{
			linearVelocityY = value;
		}
	}

	public void SetRotation(float angle)
	{
		SetRotation_Angle(angle);
	}

	[NativeMethod("SetRotation")]
	private void SetRotation_Angle(float angle)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetRotation_Angle_Injected(intPtr, angle);
	}

	public void SetRotation(Quaternion rotation)
	{
		SetRotation_Quaternion(rotation);
	}

	[NativeMethod("SetRotation")]
	private void SetRotation_Quaternion(Quaternion rotation)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetRotation_Quaternion_Injected(intPtr, ref rotation);
	}

	public void MovePosition(Vector2 position)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		MovePosition_Injected(intPtr, ref position);
	}

	public void MoveRotation(float angle)
	{
		MoveRotation_Angle(angle);
	}

	[NativeMethod("MoveRotation")]
	private void MoveRotation_Angle(float angle)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		MoveRotation_Angle_Injected(intPtr, angle);
	}

	public void MoveRotation(Quaternion rotation)
	{
		MoveRotation_Quaternion(rotation);
	}

	[NativeMethod("MoveRotation")]
	private void MoveRotation_Quaternion(Quaternion rotation)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		MoveRotation_Quaternion_Injected(intPtr, ref rotation);
	}

	[NativeMethod("MovePositionAndRotation")]
	public void MovePositionAndRotation(Vector2 position, float angle)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		MovePositionAndRotation_Injected(intPtr, ref position, angle);
	}

	public void MovePositionAndRotation(Vector2 position, Quaternion rotation)
	{
		MovePositionAndRotation_Quaternion(position, rotation);
	}

	[NativeMethod("MovePositionAndRotation")]
	private void MovePositionAndRotation_Quaternion(Vector2 position, Quaternion rotation)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		MovePositionAndRotation_Quaternion_Injected(intPtr, ref position, ref rotation);
	}

	public SlideResults Slide(Vector2 velocity, float deltaTime, SlideMovement slideMovement)
	{
		if (deltaTime < 0f)
		{
			throw new ArgumentException($"Time cannot be negative. It is {deltaTime}.", "deltaTime");
		}
		if (Mathf.Approximately(deltaTime, 0f))
		{
			return new SlideResults
			{
				position = (slideMovement.useStartPosition ? slideMovement.startPosition : position),
				remainingVelocity = velocity
			};
		}
		if (slideMovement.useSimulationMove && bodyType == RigidbodyType2D.Static)
		{
			throw new ArgumentException($"Cannot use simulation move when the body type is Static. It is {slideMovement.useSimulationMove}.", "SlideMovement.useSimulationMove");
		}
		if (slideMovement.useNoMove && slideMovement.useSimulationMove)
		{
			throw new ArgumentException($"Cannot use no move and simulation move at the same time; the two are conflicting options. It is {slideMovement.useNoMove}.", "SlideMovement.useNoMove");
		}
		if (slideMovement.maxIterations < 1)
		{
			throw new ArgumentException($"Maximum Iterations must be greater than zero. It is {slideMovement.maxIterations}.", "SlideMovement.maxIterations");
		}
		if (!float.IsFinite(slideMovement.surfaceSlideAngle) || slideMovement.surfaceSlideAngle < 0f || slideMovement.surfaceSlideAngle > 90f)
		{
			throw new ArgumentException($"Surface Slide Angle must be in the range of 0 to 90 degrees. It is {slideMovement.surfaceSlideAngle}.", "SlideMovement.surfaceSlideAngle");
		}
		if (!float.IsFinite(slideMovement.gravitySlipAngle) || slideMovement.gravitySlipAngle < 0f || slideMovement.gravitySlipAngle > 90f)
		{
			throw new ArgumentException($"Gravity Slip Angle must be in the range of 0 to 90 degrees. It is {slideMovement.gravitySlipAngle}.", "SlideMovement.gravitySlipAngle");
		}
		if (!float.IsFinite(slideMovement.surfaceUp.x) || !float.IsFinite(slideMovement.surfaceUp.y))
		{
			throw new ArgumentException($"Surface Up is invalid. It is {slideMovement.surfaceUp}.", "SlideMovement.surfaceUp");
		}
		if (!float.IsFinite(slideMovement.surfaceAnchor.x) || !float.IsFinite(slideMovement.surfaceAnchor.y))
		{
			throw new ArgumentException($"Surface Anchor is invalid. It is {slideMovement.surfaceAnchor}.", "SlideMovement.surfaceAnchor");
		}
		if (!float.IsFinite(slideMovement.gravity.x) || !float.IsFinite(slideMovement.gravity.y))
		{
			throw new ArgumentException($"Gravity is invalid. It is {slideMovement.gravity}.", "SlideMovement.gravity");
		}
		if (!float.IsFinite(slideMovement.startPosition.x) || !float.IsFinite(slideMovement.startPosition.y))
		{
			throw new ArgumentException($"Start Position is invalid. It is {slideMovement.gravity}.", "SlideMovement.startPosition");
		}
		if ((bool)slideMovement.selectedCollider && slideMovement.selectedCollider.attachedRigidbody != this)
		{
			throw new ArgumentException($"Selected Collider must be attached to the Slide Rigidbody2D. It is {slideMovement.selectedCollider}.", "SlideMovement.selectedCollider");
		}
		return Slide_Internal(velocity, deltaTime, slideMovement);
	}

	[NativeMethod("Slide")]
	private SlideResults Slide_Internal(Vector2 velocity, float deltaTime, SlideMovement slideMovement)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Slide_Internal_Injected(intPtr, ref velocity, deltaTime, ref slideMovement, out var ret);
		return ret;
	}

	internal void SetDragBehaviour(bool dragged)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetDragBehaviour_Injected(intPtr, dragged);
	}

	public bool IsSleeping()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return IsSleeping_Injected(intPtr);
	}

	public bool IsAwake()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return IsAwake_Injected(intPtr);
	}

	public void Sleep()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Sleep_Injected(intPtr);
	}

	[NativeMethod("Wake")]
	public void WakeUp()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		WakeUp_Injected(intPtr);
	}

	[NativeMethod("GetAttachedColliderCount")]
	private int GetAttachedColliderCount_Internal(bool findTriggers)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAttachedColliderCount_Internal_Injected(intPtr, findTriggers);
	}

	public bool IsTouching([NotNull] Collider2D collider)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		return IsTouching_Injected(intPtr, intPtr2);
	}

	public bool IsTouching(Collider2D collider, ContactFilter2D contactFilter)
	{
		return IsTouching_OtherColliderWithFilter_Internal(collider, contactFilter);
	}

	[NativeMethod("IsTouching")]
	private bool IsTouching_OtherColliderWithFilter_Internal([NotNull] Collider2D collider, ContactFilter2D contactFilter)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		return IsTouching_OtherColliderWithFilter_Internal_Injected(intPtr, intPtr2, ref contactFilter);
	}

	public bool IsTouching(ContactFilter2D contactFilter)
	{
		return IsTouching_AnyColliderWithFilter_Internal(contactFilter);
	}

	[NativeMethod("IsTouching")]
	private bool IsTouching_AnyColliderWithFilter_Internal(ContactFilter2D contactFilter)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return IsTouching_AnyColliderWithFilter_Internal_Injected(intPtr, ref contactFilter);
	}

	[ExcludeFromDocs]
	public bool IsTouchingLayers()
	{
		return IsTouchingLayers(-1);
	}

	public bool IsTouchingLayers([UnityEngine.Internal.DefaultValue("Physics2D.AllLayers")] int layerMask = -1)
	{
		ContactFilter2D contactFilter = default(ContactFilter2D);
		contactFilter.SetLayerMask(layerMask);
		contactFilter.useTriggers = Physics2D.queriesHitTriggers;
		return IsTouching(contactFilter);
	}

	public bool OverlapPoint(Vector2 point)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return OverlapPoint_Injected(intPtr, ref point);
	}

	public ColliderDistance2D Distance(Collider2D collider)
	{
		if (collider == null)
		{
			throw new ArgumentNullException("Collider cannot be null.");
		}
		if (collider.attachedRigidbody == this)
		{
			throw new ArgumentException("The collider cannot be attached to the Rigidbody2D being searched.");
		}
		return Distance_Internal(collider);
	}

	public ColliderDistance2D Distance(Vector2 thisPosition, float thisAngle, Collider2D collider, Vector2 position, float angle)
	{
		if (!collider.attachedRigidbody)
		{
			throw new InvalidOperationException("Cannot perform a Collider Distance at a specific position and angle if the Collider is not attached to a Rigidbody2D.");
		}
		return DistanceFrom_Internal(thisPosition, thisAngle, collider, position, angle);
	}

	[NativeMethod("Distance")]
	private ColliderDistance2D Distance_Internal([NotNull] Collider2D collider)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		Distance_Internal_Injected(intPtr, intPtr2, out var ret);
		return ret;
	}

	[NativeMethod("DistanceFrom")]
	private ColliderDistance2D DistanceFrom_Internal(Vector2 thisPosition, float thisAngle, [NotNull] Collider2D collider, Vector2 position, float angle)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		DistanceFrom_Internal_Injected(intPtr, ref thisPosition, thisAngle, intPtr2, ref position, angle, out var ret);
		return ret;
	}

	public Vector2 ClosestPoint(Vector2 position)
	{
		return Physics2D.ClosestPoint(position, this);
	}

	[ExcludeFromDocs]
	public void AddForce(Vector2 force)
	{
		AddForce_Internal(force, ForceMode2D.Force);
	}

	public void AddForce(Vector2 force, [UnityEngine.Internal.DefaultValue("ForceMode2D.Force")] ForceMode2D mode = ForceMode2D.Force)
	{
		AddForce_Internal(force, mode);
	}

	public void AddForceX(float force, [UnityEngine.Internal.DefaultValue("ForceMode2D.Force")] ForceMode2D mode = ForceMode2D.Force)
	{
		AddForce_Internal(new Vector2(force, 0f), mode);
	}

	public void AddForceY(float force, [UnityEngine.Internal.DefaultValue("ForceMode2D.Force")] ForceMode2D mode = ForceMode2D.Force)
	{
		AddForce_Internal(new Vector2(0f, force), mode);
	}

	[NativeMethod("AddForce")]
	private void AddForce_Internal(Vector2 force, [UnityEngine.Internal.DefaultValue("ForceMode2D.Force")] ForceMode2D mode)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		AddForce_Internal_Injected(intPtr, ref force, mode);
	}

	[ExcludeFromDocs]
	public void AddRelativeForce(Vector2 relativeForce)
	{
		AddRelativeForce_Internal(relativeForce, ForceMode2D.Force);
	}

	public void AddRelativeForce(Vector2 relativeForce, [UnityEngine.Internal.DefaultValue("ForceMode2D.Force")] ForceMode2D mode = ForceMode2D.Force)
	{
		AddRelativeForce_Internal(relativeForce, mode);
	}

	public void AddRelativeForceX(float force, [UnityEngine.Internal.DefaultValue("ForceMode2D.Force")] ForceMode2D mode = ForceMode2D.Force)
	{
		AddRelativeForce_Internal(new Vector2(force, 0f), mode);
	}

	public void AddRelativeForceY(float force, [UnityEngine.Internal.DefaultValue("ForceMode2D.Force")] ForceMode2D mode = ForceMode2D.Force)
	{
		AddRelativeForce_Internal(new Vector2(0f, force), mode);
	}

	[NativeMethod("AddRelativeForce")]
	private void AddRelativeForce_Internal(Vector2 relativeForce, [UnityEngine.Internal.DefaultValue("ForceMode2D.Force")] ForceMode2D mode)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		AddRelativeForce_Internal_Injected(intPtr, ref relativeForce, mode);
	}

	[ExcludeFromDocs]
	public void AddForceAtPosition(Vector2 force, Vector2 position)
	{
		AddForceAtPosition(force, position, ForceMode2D.Force);
	}

	public void AddForceAtPosition(Vector2 force, Vector2 position, [UnityEngine.Internal.DefaultValue("ForceMode2D.Force")] ForceMode2D mode)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		AddForceAtPosition_Injected(intPtr, ref force, ref position, mode);
	}

	[ExcludeFromDocs]
	public void AddTorque(float torque)
	{
		AddTorque(torque, ForceMode2D.Force);
	}

	public void AddTorque(float torque, [UnityEngine.Internal.DefaultValue("ForceMode2D.Force")] ForceMode2D mode)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		AddTorque_Injected(intPtr, torque, mode);
	}

	public Vector2 GetPoint(Vector2 point)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetPoint_Injected(intPtr, ref point, out var ret);
		return ret;
	}

	public Vector2 GetRelativePoint(Vector2 relativePoint)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetRelativePoint_Injected(intPtr, ref relativePoint, out var ret);
		return ret;
	}

	public Vector2 GetVector(Vector2 vector)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetVector_Injected(intPtr, ref vector, out var ret);
		return ret;
	}

	public Vector2 GetRelativeVector(Vector2 relativeVector)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetRelativeVector_Injected(intPtr, ref relativeVector, out var ret);
		return ret;
	}

	public Vector2 GetPointVelocity(Vector2 point)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetPointVelocity_Injected(intPtr, ref point, out var ret);
		return ret;
	}

	public Vector2 GetRelativePointVelocity(Vector2 relativePoint)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetRelativePointVelocity_Injected(intPtr, ref relativePoint, out var ret);
		return ret;
	}

	public int GetContacts(ContactPoint2D[] contacts)
	{
		return Physics2D.GetContacts(this, ContactFilter2D.noFilter, contacts);
	}

	public int GetContacts(List<ContactPoint2D> contacts)
	{
		return Physics2D.GetContacts(this, ContactFilter2D.noFilter, contacts);
	}

	public int GetContacts(ContactFilter2D contactFilter, ContactPoint2D[] contacts)
	{
		return Physics2D.GetContacts(this, contactFilter, contacts);
	}

	public int GetContacts(ContactFilter2D contactFilter, List<ContactPoint2D> contacts)
	{
		return Physics2D.GetContacts(this, contactFilter, contacts);
	}

	public int GetContacts(Collider2D[] colliders)
	{
		return Physics2D.GetContacts(this, ContactFilter2D.noFilter, colliders);
	}

	public int GetContacts(List<Collider2D> colliders)
	{
		return Physics2D.GetContacts(this, ContactFilter2D.noFilter, colliders);
	}

	public int GetContacts(ContactFilter2D contactFilter, Collider2D[] colliders)
	{
		return Physics2D.GetContacts(this, contactFilter, colliders);
	}

	public int GetContacts(ContactFilter2D contactFilter, List<Collider2D> colliders)
	{
		return Physics2D.GetContacts(this, contactFilter, colliders);
	}

	[ExcludeFromDocs]
	public int GetAttachedColliders([Out] Collider2D[] results)
	{
		return GetAttachedCollidersArray_Internal(results, findTriggers: true);
	}

	[ExcludeFromDocs]
	public int GetAttachedColliders(List<Collider2D> results)
	{
		return GetAttachedCollidersList_Internal(results, findTriggers: true);
	}

	public int GetAttachedColliders([Out] Collider2D[] results, [UnityEngine.Internal.DefaultValue("true")] bool findTriggers = true)
	{
		return GetAttachedCollidersArray_Internal(results, findTriggers);
	}

	public int GetAttachedColliders(List<Collider2D> results, [UnityEngine.Internal.DefaultValue("true")] bool findTriggers = true)
	{
		return GetAttachedCollidersList_Internal(results, findTriggers);
	}

	public int GetShapes(PhysicsShapeGroup2D physicsShapeGroup)
	{
		return GetShapes_Internal(ref physicsShapeGroup.m_GroupState);
	}

	[ExcludeFromDocs]
	public int Cast(Vector2 direction, RaycastHit2D[] results)
	{
		return CastArray_Internal(direction, float.PositiveInfinity, checkIgnoreColliders: false, results);
	}

	public int Cast(Vector2 direction, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance)
	{
		return CastArray_Internal(direction, distance, checkIgnoreColliders: false, results);
	}

	public int Cast(Vector2 direction, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance = float.PositiveInfinity)
	{
		return CastList_Internal(direction, distance, checkIgnoreColliders: false, results);
	}

	[ExcludeFromDocs]
	public int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results)
	{
		return CastFilteredArray_Internal(direction, float.PositiveInfinity, checkIgnoreColliders: false, contactFilter, results);
	}

	public int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance = float.PositiveInfinity)
	{
		return CastFilteredArray_Internal(direction, distance, checkIgnoreColliders: false, contactFilter, results);
	}

	public int Cast(Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance = float.PositiveInfinity)
	{
		return CastFilteredList_Internal(direction, distance, checkIgnoreColliders: false, contactFilter, results);
	}

	public int Cast(Vector2 position, float angle, Vector2 direction, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance = float.PositiveInfinity)
	{
		return CastFrom_Internal(position, angle, direction, distance, checkIgnoreColliders: false, results);
	}

	public int Cast(Vector2 position, float angle, Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance = float.PositiveInfinity)
	{
		return CastFromFiltered_Internal(position, angle, direction, distance, checkIgnoreColliders: false, contactFilter, results);
	}

	public int Overlap(ContactFilter2D contactFilter, [Out] Collider2D[] results)
	{
		return OverlapArray_Internal(contactFilter, results);
	}

	public int Overlap(List<Collider2D> results)
	{
		return OverlapList_Internal(results);
	}

	public int Overlap(ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return OverlapFilteredList_Internal(contactFilter, results);
	}

	public int Overlap(Vector2 position, float angle, List<Collider2D> results)
	{
		return OverlapFromList_Internal(position, angle, results);
	}

	public int Overlap(Vector2 position, float angle, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return OverlapFromFilteredList_Internal(position, angle, contactFilter, results);
	}

	[NativeMethod("GetAttachedCollidersArray_Binding")]
	private int GetAttachedCollidersArray_Internal([Unmarshalled][NotNull] Collider2D[] results, bool findTriggers)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAttachedCollidersArray_Internal_Injected(intPtr, results, findTriggers);
	}

	[NativeMethod("GetAttachedCollidersList_Binding")]
	private int GetAttachedCollidersList_Internal([NotNull] List<Collider2D> results, bool findTriggers)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetAttachedCollidersList_Internal_Injected(intPtr, results, findTriggers);
	}

	[NativeMethod("GetShapes_Binding")]
	private int GetShapes_Internal(ref PhysicsShapeGroup2D.GroupState physicsShapeGroupState)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetShapes_Internal_Injected(intPtr, ref physicsShapeGroupState);
	}

	[NativeMethod("CastArray_Binding")]
	private unsafe int CastArray_Internal(Vector2 direction, float distance, bool checkIgnoreColliders, [NotNull] RaycastHit2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<RaycastHit2D> span = new Span<RaycastHit2D>(results);
		int result;
		fixed (RaycastHit2D* begin = span)
		{
			ManagedSpanWrapper results2 = new ManagedSpanWrapper(begin, span.Length);
			result = CastArray_Internal_Injected(intPtr, ref direction, distance, checkIgnoreColliders, ref results2);
		}
		return result;
	}

	[NativeMethod("CastList_Binding")]
	private unsafe int CastList_Internal(Vector2 direction, float distance, bool checkIgnoreColliders, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return CastList_Internal_Injected(intPtr, ref direction, distance, checkIgnoreColliders, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	[NativeMethod("CastFilteredArray_Binding")]
	private unsafe int CastFilteredArray_Internal(Vector2 direction, float distance, bool checkIgnoreColliders, ContactFilter2D contactFilter, [NotNull] RaycastHit2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<RaycastHit2D> span = new Span<RaycastHit2D>(results);
		int result;
		fixed (RaycastHit2D* begin = span)
		{
			ManagedSpanWrapper results2 = new ManagedSpanWrapper(begin, span.Length);
			result = CastFilteredArray_Internal_Injected(intPtr, ref direction, distance, checkIgnoreColliders, ref contactFilter, ref results2);
		}
		return result;
	}

	[NativeMethod("CastFilteredList_Binding")]
	private unsafe int CastFilteredList_Internal(Vector2 direction, float distance, bool checkIgnoreColliders, ContactFilter2D contactFilter, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return CastFilteredList_Internal_Injected(intPtr, ref direction, distance, checkIgnoreColliders, ref contactFilter, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	[NativeMethod("CastFrom_Binding")]
	private unsafe int CastFrom_Internal(Vector2 position, float angle, Vector2 direction, float distance, bool checkIgnoreColliders, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return CastFrom_Internal_Injected(intPtr, ref position, angle, ref direction, distance, checkIgnoreColliders, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	[NativeMethod("CastFromFiltered_Binding")]
	private unsafe int CastFromFiltered_Internal(Vector2 position, float angle, Vector2 direction, float distance, bool checkIgnoreColliders, ContactFilter2D contactFilter, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return CastFromFiltered_Internal_Injected(intPtr, ref position, angle, ref direction, distance, checkIgnoreColliders, ref contactFilter, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	[NativeMethod("OverlapArray_Binding")]
	private int OverlapArray_Internal(ContactFilter2D contactFilter, [NotNull][Unmarshalled] Collider2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return OverlapArray_Internal_Injected(intPtr, ref contactFilter, results);
	}

	[NativeMethod("OverlapList_Binding")]
	private int OverlapList_Internal([NotNull] List<Collider2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return OverlapList_Internal_Injected(intPtr, results);
	}

	[NativeMethod("OverlapFilteredList_Binding")]
	private int OverlapFilteredList_Internal(ContactFilter2D contactFilter, [NotNull] List<Collider2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return OverlapFilteredList_Internal_Injected(intPtr, ref contactFilter, results);
	}

	[NativeMethod("OverlapFromList_Binding")]
	private int OverlapFromList_Internal(Vector2 position, float angle, [NotNull] List<Collider2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return OverlapFromList_Internal_Injected(intPtr, ref position, angle, results);
	}

	[NativeMethod("OverlapFromFilteredList_Binding")]
	private int OverlapFromFilteredList_Internal(Vector2 position, float angle, ContactFilter2D contactFilter, [NotNull] List<Collider2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return OverlapFromFilteredList_Internal_Injected(intPtr, ref position, angle, ref contactFilter, results);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("OverlapCollider has been deprecated. Please use Overlap (UnityUpgradable) -> Overlap(*)", false)]
	[ExcludeFromDocs]
	public int OverlapCollider(ContactFilter2D contactFilter, [Out] Collider2D[] results)
	{
		return Overlap(contactFilter, results);
	}

	[ExcludeFromDocs]
	[Obsolete("OverlapCollider has been deprecated. Please use Overlap (UnityUpgradable) -> Overlap(*)", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int OverlapCollider(ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return Overlap(contactFilter, results);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_position_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_position_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_rotation_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_rotation_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetRotation_Angle_Injected(IntPtr _unity_self, float angle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetRotation_Quaternion_Injected(IntPtr _unity_self, [In] ref Quaternion rotation);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void MovePosition_Injected(IntPtr _unity_self, [In] ref Vector2 position);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void MoveRotation_Angle_Injected(IntPtr _unity_self, float angle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void MoveRotation_Quaternion_Injected(IntPtr _unity_self, [In] ref Quaternion rotation);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void MovePositionAndRotation_Injected(IntPtr _unity_self, [In] ref Vector2 position, float angle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void MovePositionAndRotation_Quaternion_Injected(IntPtr _unity_self, [In] ref Vector2 position, [In] ref Quaternion rotation);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Slide_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 velocity, float deltaTime, [In] ref SlideMovement slideMovement, out SlideResults ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_linearVelocity_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_linearVelocity_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_linearVelocityX_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_linearVelocityX_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_linearVelocityY_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_linearVelocityY_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_angularVelocity_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_angularVelocity_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useAutoMass_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useAutoMass_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_mass_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_mass_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_sharedMaterial_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_sharedMaterial_Injected(IntPtr _unity_self, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_centerOfMass_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_centerOfMass_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_worldCenterOfMass_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_inertia_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_inertia_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_linearDamping_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_linearDamping_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_angularDamping_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_angularDamping_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_gravityScale_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_gravityScale_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern RigidbodyType2D get_bodyType_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_bodyType_Injected(IntPtr _unity_self, RigidbodyType2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetDragBehaviour_Injected(IntPtr _unity_self, bool dragged);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useFullKinematicContacts_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useFullKinematicContacts_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_freezeRotation_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_freezeRotation_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern RigidbodyConstraints2D get_constraints_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_constraints_Injected(IntPtr _unity_self, RigidbodyConstraints2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsSleeping_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsAwake_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Sleep_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void WakeUp_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_simulated_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_simulated_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern RigidbodyInterpolation2D get_interpolation_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_interpolation_Injected(IntPtr _unity_self, RigidbodyInterpolation2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern RigidbodySleepMode2D get_sleepMode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_sleepMode_Injected(IntPtr _unity_self, RigidbodySleepMode2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern CollisionDetectionMode2D get_collisionDetectionMode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_collisionDetectionMode_Injected(IntPtr _unity_self, CollisionDetectionMode2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetAttachedColliderCount_Internal_Injected(IntPtr _unity_self, bool findTriggers);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_totalForce_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_totalForce_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_totalTorque_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_totalTorque_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_excludeLayers_Injected(IntPtr _unity_self, out LayerMask ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_excludeLayers_Injected(IntPtr _unity_self, [In] ref LayerMask value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_includeLayers_Injected(IntPtr _unity_self, out LayerMask ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_includeLayers_Injected(IntPtr _unity_self, [In] ref LayerMask value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_localToWorldMatrix_Injected(IntPtr _unity_self, out Matrix4x4 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsTouching_Injected(IntPtr _unity_self, IntPtr collider);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsTouching_OtherColliderWithFilter_Internal_Injected(IntPtr _unity_self, IntPtr collider, [In] ref ContactFilter2D contactFilter);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsTouching_AnyColliderWithFilter_Internal_Injected(IntPtr _unity_self, [In] ref ContactFilter2D contactFilter);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool OverlapPoint_Injected(IntPtr _unity_self, [In] ref Vector2 point);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Distance_Internal_Injected(IntPtr _unity_self, IntPtr collider, out ColliderDistance2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void DistanceFrom_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 thisPosition, float thisAngle, IntPtr collider, [In] ref Vector2 position, float angle, out ColliderDistance2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void AddForce_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 force, [UnityEngine.Internal.DefaultValue("ForceMode2D.Force")] ForceMode2D mode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void AddRelativeForce_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 relativeForce, [UnityEngine.Internal.DefaultValue("ForceMode2D.Force")] ForceMode2D mode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void AddForceAtPosition_Injected(IntPtr _unity_self, [In] ref Vector2 force, [In] ref Vector2 position, [UnityEngine.Internal.DefaultValue("ForceMode2D.Force")] ForceMode2D mode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void AddTorque_Injected(IntPtr _unity_self, float torque, [UnityEngine.Internal.DefaultValue("ForceMode2D.Force")] ForceMode2D mode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetPoint_Injected(IntPtr _unity_self, [In] ref Vector2 point, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetRelativePoint_Injected(IntPtr _unity_self, [In] ref Vector2 relativePoint, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetVector_Injected(IntPtr _unity_self, [In] ref Vector2 vector, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetRelativeVector_Injected(IntPtr _unity_self, [In] ref Vector2 relativeVector, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetPointVelocity_Injected(IntPtr _unity_self, [In] ref Vector2 point, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetRelativePointVelocity_Injected(IntPtr _unity_self, [In] ref Vector2 relativePoint, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetAttachedCollidersArray_Internal_Injected(IntPtr _unity_self, Collider2D[] results, bool findTriggers);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetAttachedCollidersList_Internal_Injected(IntPtr _unity_self, List<Collider2D> results, bool findTriggers);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetShapes_Internal_Injected(IntPtr _unity_self, ref PhysicsShapeGroup2D.GroupState physicsShapeGroupState);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CastArray_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 direction, float distance, bool checkIgnoreColliders, ref ManagedSpanWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CastList_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 direction, float distance, bool checkIgnoreColliders, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CastFilteredArray_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 direction, float distance, bool checkIgnoreColliders, [In] ref ContactFilter2D contactFilter, ref ManagedSpanWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CastFilteredList_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 direction, float distance, bool checkIgnoreColliders, [In] ref ContactFilter2D contactFilter, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CastFrom_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 position, float angle, [In] ref Vector2 direction, float distance, bool checkIgnoreColliders, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CastFromFiltered_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 position, float angle, [In] ref Vector2 direction, float distance, bool checkIgnoreColliders, [In] ref ContactFilter2D contactFilter, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapArray_Internal_Injected(IntPtr _unity_self, [In] ref ContactFilter2D contactFilter, Collider2D[] results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapList_Internal_Injected(IntPtr _unity_self, List<Collider2D> results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapFilteredList_Internal_Injected(IntPtr _unity_self, [In] ref ContactFilter2D contactFilter, List<Collider2D> results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapFromList_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 position, float angle, List<Collider2D> results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int OverlapFromFilteredList_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 position, float angle, [In] ref ContactFilter2D contactFilter, List<Collider2D> results);
}
[RequiredByNativeCode(Optional = true)]
[NativeHeader("Modules/Physics2D/Public/Collider2D.h")]
[RequireComponent(typeof(Transform))]
public class Collider2D : Behaviour
{
	public enum CompositeOperation
	{
		None,
		Merge,
		Intersect,
		Difference,
		Flip
	}

	public float density
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_density_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_density_Injected(intPtr, value);
		}
	}

	public bool isTrigger
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_isTrigger_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_isTrigger_Injected(intPtr, value);
		}
	}

	public bool usedByEffector
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_usedByEffector_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_usedByEffector_Injected(intPtr, value);
		}
	}

	public CompositeOperation compositeOperation
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_compositeOperation_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_compositeOperation_Injected(intPtr, value);
		}
	}

	public int compositeOrder
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_compositeOrder_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_compositeOrder_Injected(intPtr, value);
		}
	}

	public CompositeCollider2D composite
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<CompositeCollider2D>(get_composite_Injected(intPtr));
		}
	}

	public Vector2 offset
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_offset_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_offset_Injected(intPtr, ref value);
		}
	}

	public Rigidbody2D attachedRigidbody
	{
		[NativeMethod("GetAttachedRigidbody_Binding")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Rigidbody2D>(get_attachedRigidbody_Injected(intPtr));
		}
	}

	public Matrix4x4 localToWorldMatrix
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_localToWorldMatrix_Injected(intPtr, out var ret);
			return ret;
		}
	}

	public int shapeCount
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_shapeCount_Injected(intPtr);
		}
	}

	public Bounds bounds
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_bounds_Injected(intPtr, out var ret);
			return ret;
		}
	}

	public ColliderErrorState2D errorState
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_errorState_Injected(intPtr);
		}
	}

	public bool compositeCapable
	{
		[NativeMethod("GetCompositeCapable_Binding")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_compositeCapable_Injected(intPtr);
		}
	}

	public PhysicsMaterial2D sharedMaterial
	{
		[NativeMethod("GetMaterial")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<PhysicsMaterial2D>(get_sharedMaterial_Injected(intPtr));
		}
		[NativeMethod("SetMaterial")]
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_sharedMaterial_Injected(intPtr, MarshalledUnityObject.Marshal(value));
		}
	}

	public int layerOverridePriority
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_layerOverridePriority_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_layerOverridePriority_Injected(intPtr, value);
		}
	}

	public LayerMask excludeLayers
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_excludeLayers_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_excludeLayers_Injected(intPtr, ref value);
		}
	}

	public LayerMask includeLayers
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_includeLayers_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_includeLayers_Injected(intPtr, ref value);
		}
	}

	public LayerMask forceSendLayers
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_forceSendLayers_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_forceSendLayers_Injected(intPtr, ref value);
		}
	}

	public LayerMask forceReceiveLayers
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_forceReceiveLayers_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_forceReceiveLayers_Injected(intPtr, ref value);
		}
	}

	public LayerMask contactCaptureLayers
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_contactCaptureLayers_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_contactCaptureLayers_Injected(intPtr, ref value);
		}
	}

	public LayerMask callbackLayers
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_callbackLayers_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_callbackLayers_Injected(intPtr, ref value);
		}
	}

	public float friction
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_friction_Injected(intPtr);
		}
	}

	public float bounciness
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_bounciness_Injected(intPtr);
		}
	}

	public PhysicsMaterialCombine2D frictionCombine
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_frictionCombine_Injected(intPtr);
		}
	}

	public PhysicsMaterialCombine2D bounceCombine
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_bounceCombine_Injected(intPtr);
		}
	}

	public LayerMask contactMask
	{
		[NativeMethod("GetContactMask_Binding")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_contactMask_Injected(intPtr, out var ret);
			return ret;
		}
	}

	[ExcludeFromDocs]
	[Obsolete("usedByComposite has been deprecated. Please use compositeOperation.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool usedByComposite
	{
		get
		{
			return compositeOperation != CompositeOperation.None;
		}
		set
		{
			compositeOperation = (value ? CompositeOperation.Merge : CompositeOperation.None);
		}
	}

	[ExcludeFromDocs]
	public Mesh CreateMesh(bool useBodyPosition, bool useBodyRotation)
	{
		return CreateMesh(useBodyPosition, useBodyRotation, true);
	}

	[NativeMethod("CreateMesh_Binding")]
	public Mesh CreateMesh(bool useBodyPosition, bool useBodyRotation, [UnityEngine.Internal.DefaultValue("true")] bool useDelaunay = true)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<Mesh>(CreateMesh_Injected(intPtr, useBodyPosition, useBodyRotation, useDelaunay));
	}

	[NativeMethod("GetShapeHash_Binding")]
	public uint GetShapeHash()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetShapeHash_Injected(intPtr);
	}

	public int GetShapes(PhysicsShapeGroup2D physicsShapeGroup)
	{
		return GetShapes_Internal(ref physicsShapeGroup.m_GroupState, 0, shapeCount);
	}

	public int GetShapes(PhysicsShapeGroup2D physicsShapeGroup, int shapeIndex, [UnityEngine.Internal.DefaultValue("1")] int shapeCount = 1)
	{
		int num = this.shapeCount;
		if (shapeIndex < 0 || shapeIndex >= num || shapeCount < 1 || shapeIndex + shapeCount > num)
		{
			throw new ArgumentOutOfRangeException($"Cannot get shape range from {shapeIndex} to {shapeIndex + shapeCount - 1} as Collider2D only has {num} shape(s).");
		}
		return GetShapes_Internal(ref physicsShapeGroup.m_GroupState, shapeIndex, shapeCount);
	}

	[NativeMethod("GetShapes_Binding")]
	private int GetShapes_Internal(ref PhysicsShapeGroup2D.GroupState physicsShapeGroupState, int shapeIndex, int shapeCount)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetShapes_Internal_Injected(intPtr, ref physicsShapeGroupState, shapeIndex, shapeCount);
	}

	[NativeMethod("GetShapeBounds_Binding")]
	public unsafe Bounds GetShapeBounds(List<Bounds> bounds, bool useRadii, bool useWorldSpace)
	{
		//The blocks IL_0041 are reachable both inside and outside the pinned region starting at IL_001d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<Bounds> list = default(List<Bounds>);
		BlittableListWrapper blittableListWrapper = default(BlittableListWrapper);
		Bounds ret = default(Bounds);
		Bounds result;
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = bounds;
			if (list != null)
			{
				fixed (Bounds[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					blittableListWrapper = new BlittableListWrapper(arrayWrapper, list.Count);
					GetShapeBounds_Injected(intPtr, ref blittableListWrapper, useRadii, useWorldSpace, out ret);
				}
			}
			else
			{
				GetShapeBounds_Injected(intPtr, ref blittableListWrapper, useRadii, useWorldSpace, out ret);
			}
		}
		finally
		{
			blittableListWrapper.Unmarshal(list);
			result = ret;
		}
		return result;
	}

	[NativeMethod("CanContact_Binding")]
	public bool CanContact([NotNull] Collider2D collider)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		return CanContact_Injected(intPtr, intPtr2);
	}

	public bool IsTouching([NotNull] Collider2D collider)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		return IsTouching_Injected(intPtr, intPtr2);
	}

	public bool IsTouching(Collider2D collider, ContactFilter2D contactFilter)
	{
		return IsTouching_OtherColliderWithFilter(collider, contactFilter);
	}

	[NativeMethod("IsTouching")]
	private bool IsTouching_OtherColliderWithFilter([NotNull] Collider2D collider, ContactFilter2D contactFilter)
	{
		if ((object)collider == null)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(collider);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(collider, "collider");
		}
		return IsTouching_OtherColliderWithFilter_Injected(intPtr, intPtr2, ref contactFilter);
	}

	public bool IsTouching(ContactFilter2D contactFilter)
	{
		return IsTouching_AnyColliderWithFilter(contactFilter);
	}

	[NativeMethod("IsTouching")]
	private bool IsTouching_AnyColliderWithFilter(ContactFilter2D contactFilter)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return IsTouching_AnyColliderWithFilter_Injected(intPtr, ref contactFilter);
	}

	[ExcludeFromDocs]
	public bool IsTouchingLayers()
	{
		return IsTouchingLayers(-1);
	}

	public bool IsTouchingLayers([UnityEngine.Internal.DefaultValue("Physics2D.AllLayers")] int layerMask)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return IsTouchingLayers_Injected(intPtr, layerMask);
	}

	public bool OverlapPoint(Vector2 point)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return OverlapPoint_Injected(intPtr, ref point);
	}

	public int Overlap(ContactFilter2D contactFilter, Collider2D[] results)
	{
		return PhysicsScene2D.OverlapCollider(this, contactFilter, results);
	}

	public int Overlap(List<Collider2D> results)
	{
		return PhysicsScene2D.OverlapCollider(this, results);
	}

	public int Overlap(ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return PhysicsScene2D.OverlapCollider(this, contactFilter, results);
	}

	public int Overlap(Vector2 position, float angle, List<Collider2D> results)
	{
		if ((bool)attachedRigidbody)
		{
			return PhysicsScene2D.OverlapCollider(position, angle, this, results);
		}
		throw new InvalidOperationException("Cannot perform a Collider Overlap at a specific position and angle if the Collider is not attached to a Rigidbody2D.");
	}

	public int Overlap(Vector2 position, float angle, ContactFilter2D contactFilter, List<Collider2D> results)
	{
		if ((bool)attachedRigidbody)
		{
			return PhysicsScene2D.OverlapCollider(position, angle, this, contactFilter, results);
		}
		throw new InvalidOperationException("Cannot perform a Collider Overlap at a specific position and angle if the Collider is not attached to a Rigidbody2D.");
	}

	[ExcludeFromDocs]
	public int Cast(Vector2 direction, RaycastHit2D[] results)
	{
		ContactFilter2D contactFilter = default(ContactFilter2D);
		contactFilter.useTriggers = Physics2D.queriesHitTriggers;
		contactFilter.SetLayerMask(contactMask);
		return CastArray_Internal(direction, float.PositiveInfinity, contactFilter, ignoreSiblingColliders: true, checkIgnoreColliders: false, results);
	}

	[ExcludeFromDocs]
	public int Cast(Vector2 direction, RaycastHit2D[] results, float distance)
	{
		ContactFilter2D contactFilter = default(ContactFilter2D);
		contactFilter.useTriggers = Physics2D.queriesHitTriggers;
		contactFilter.SetLayerMask(contactMask);
		return CastArray_Internal(direction, distance, contactFilter, ignoreSiblingColliders: true, checkIgnoreColliders: false, results);
	}

	public int Cast(Vector2 direction, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("true")] bool ignoreSiblingColliders)
	{
		ContactFilter2D contactFilter = default(ContactFilter2D);
		contactFilter.useTriggers = Physics2D.queriesHitTriggers;
		contactFilter.SetLayerMask(contactMask);
		return CastArray_Internal(direction, distance, contactFilter, ignoreSiblingColliders, checkIgnoreColliders: false, results);
	}

	[ExcludeFromDocs]
	public int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results)
	{
		return CastArray_Internal(direction, float.PositiveInfinity, contactFilter, ignoreSiblingColliders: true, checkIgnoreColliders: false, results);
	}

	[ExcludeFromDocs]
	public int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance)
	{
		return CastArray_Internal(direction, distance, contactFilter, ignoreSiblingColliders: true, checkIgnoreColliders: false, results);
	}

	public int Cast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("true")] bool ignoreSiblingColliders)
	{
		return CastArray_Internal(direction, distance, contactFilter, ignoreSiblingColliders, checkIgnoreColliders: false, results);
	}

	public int Cast(Vector2 direction, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance = float.PositiveInfinity, [UnityEngine.Internal.DefaultValue("true")] bool ignoreSiblingColliders = true)
	{
		return CastList_Internal(direction, distance, ignoreSiblingColliders, checkIgnoreColliders: false, results);
	}

	public int Cast(Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance = float.PositiveInfinity, [UnityEngine.Internal.DefaultValue("true")] bool ignoreSiblingColliders = true)
	{
		return CastListFiltered_Internal(direction, distance, contactFilter, ignoreSiblingColliders, checkIgnoreColliders: false, results);
	}

	public int Cast(Vector2 position, float angle, Vector2 direction, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance = float.PositiveInfinity, [UnityEngine.Internal.DefaultValue("true")] bool ignoreSiblingColliders = true)
	{
		if ((bool)attachedRigidbody)
		{
			return CastFrom_Internal(position, angle, direction, distance, ignoreSiblingColliders, checkIgnoreColliders: false, results);
		}
		throw new InvalidOperationException("Cannot perform a Collider Cast from a specific position and angle if the Collider is not attached to a Rigidbody2D.");
	}

	public int Cast(Vector2 position, float angle, Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance = float.PositiveInfinity, [UnityEngine.Internal.DefaultValue("true")] bool ignoreSiblingColliders = true)
	{
		if ((bool)attachedRigidbody)
		{
			return CastFromFiltered_Internal(position, angle, direction, distance, contactFilter, ignoreSiblingColliders, checkIgnoreColliders: false, results);
		}
		throw new InvalidOperationException("Cannot perform a Collider Cast from a specific position and angle if the Collider is not attached to a Rigidbody2D.");
	}

	[NativeMethod("CastArray_Binding")]
	private unsafe int CastArray_Internal(Vector2 direction, float distance, ContactFilter2D contactFilter, bool ignoreSiblingColliders, bool checkIgnoreColliders, [NotNull] RaycastHit2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<RaycastHit2D> span = new Span<RaycastHit2D>(results);
		int result;
		fixed (RaycastHit2D* begin = span)
		{
			ManagedSpanWrapper results2 = new ManagedSpanWrapper(begin, span.Length);
			result = CastArray_Internal_Injected(intPtr, ref direction, distance, ref contactFilter, ignoreSiblingColliders, checkIgnoreColliders, ref results2);
		}
		return result;
	}

	[NativeMethod("CastList_Binding")]
	private unsafe int CastList_Internal(Vector2 direction, float distance, bool ignoreSiblingColliders, bool checkIgnoreColliders, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return CastList_Internal_Injected(intPtr, ref direction, distance, ignoreSiblingColliders, checkIgnoreColliders, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	[NativeMethod("CastListFiltered_Binding")]
	private unsafe int CastListFiltered_Internal(Vector2 direction, float distance, ContactFilter2D contactFilter, bool ignoreSiblingColliders, bool checkIgnoreColliders, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return CastListFiltered_Internal_Injected(intPtr, ref direction, distance, ref contactFilter, ignoreSiblingColliders, checkIgnoreColliders, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	[NativeMethod("CastFrom_Binding")]
	private unsafe int CastFrom_Internal(Vector2 position, float angle, Vector2 direction, float distance, bool ignoreSiblingColliders, bool checkIgnoreColliders, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return CastFrom_Internal_Injected(intPtr, ref position, angle, ref direction, distance, ignoreSiblingColliders, checkIgnoreColliders, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	[NativeMethod("CastFromFiltered_Binding")]
	private unsafe int CastFromFiltered_Internal(Vector2 position, float angle, Vector2 direction, float distance, ContactFilter2D contactFilter, bool ignoreSiblingColliders, bool checkIgnoreColliders, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return CastFromFiltered_Internal_Injected(intPtr, ref position, angle, ref direction, distance, ref contactFilter, ignoreSiblingColliders, checkIgnoreColliders, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	[ExcludeFromDocs]
	public int Raycast(Vector2 direction, RaycastHit2D[] results)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-1, float.NegativeInfinity, float.PositiveInfinity);
		return RaycastArray_Internal(direction, float.PositiveInfinity, contactFilter, results);
	}

	[ExcludeFromDocs]
	public int Raycast(Vector2 direction, RaycastHit2D[] results, float distance)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(-1, float.NegativeInfinity, float.PositiveInfinity);
		return RaycastArray_Internal(direction, distance, contactFilter, results);
	}

	[ExcludeFromDocs]
	public int Raycast(Vector2 direction, RaycastHit2D[] results, float distance, int layerMask)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, float.NegativeInfinity, float.PositiveInfinity);
		return RaycastArray_Internal(direction, distance, contactFilter, results);
	}

	[ExcludeFromDocs]
	public int Raycast(Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, float.PositiveInfinity);
		return RaycastArray_Internal(direction, distance, contactFilter, results);
	}

	public int Raycast(Vector2 direction, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance, [UnityEngine.Internal.DefaultValue("Physics2D.AllLayers")] int layerMask, [UnityEngine.Internal.DefaultValue("-Mathf.Infinity")] float minDepth, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDepth)
	{
		ContactFilter2D contactFilter = ContactFilter2D.CreateLegacyFilter(layerMask, minDepth, maxDepth);
		return RaycastArray_Internal(direction, distance, contactFilter, results);
	}

	[ExcludeFromDocs]
	public int Raycast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results)
	{
		return RaycastArray_Internal(direction, float.PositiveInfinity, contactFilter, results);
	}

	public int Raycast(Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance)
	{
		return RaycastArray_Internal(direction, distance, contactFilter, results);
	}

	[NativeMethod("RaycastArray_Binding")]
	private unsafe int RaycastArray_Internal(Vector2 direction, float distance, ContactFilter2D contactFilter, [NotNull] RaycastHit2D[] results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<RaycastHit2D> span = new Span<RaycastHit2D>(results);
		int result;
		fixed (RaycastHit2D* begin = span)
		{
			ManagedSpanWrapper results2 = new ManagedSpanWrapper(begin, span.Length);
			result = RaycastArray_Internal_Injected(intPtr, ref direction, distance, ref contactFilter, ref results2);
		}
		return result;
	}

	public int Raycast(Vector2 direction, ContactFilter2D contactFilter, List<RaycastHit2D> results, [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float distance = float.PositiveInfinity)
	{
		return RaycastList_Internal(direction, distance, contactFilter, results);
	}

	[NativeMethod("RaycastList_Binding")]
	private unsafe int RaycastList_Internal(Vector2 direction, float distance, ContactFilter2D contactFilter, [NotNull] List<RaycastHit2D> results)
	{
		if (results == null)
		{
			ThrowHelper.ThrowArgumentNullException(results, "results");
		}
		List<RaycastHit2D> list = default(List<RaycastHit2D>);
		BlittableListWrapper results2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = results;
			fixed (RaycastHit2D[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				results2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return RaycastList_Internal_Injected(intPtr, ref direction, distance, ref contactFilter, ref results2);
			}
		}
		finally
		{
			results2.Unmarshal(list);
		}
	}

	public ColliderDistance2D Distance(Collider2D collider)
	{
		return Physics2D.Distance(this, collider);
	}

	public ColliderDistance2D Distance(Vector2 thisPosition, float thisAngle, Collider2D collider, Vector2 position, float angle)
	{
		return Physics2D.Distance(this, thisPosition, thisAngle, collider, position, angle);
	}

	public Vector2 ClosestPoint(Vector2 position)
	{
		return Physics2D.ClosestPoint(position, this);
	}

	public int GetContacts(ContactPoint2D[] contacts)
	{
		return Physics2D.GetContacts(this, ContactFilter2D.noFilter, contacts);
	}

	public int GetContacts(List<ContactPoint2D> contacts)
	{
		return Physics2D.GetContacts(this, ContactFilter2D.noFilter, contacts);
	}

	public int GetContacts(ContactFilter2D contactFilter, ContactPoint2D[] contacts)
	{
		return Physics2D.GetContacts(this, contactFilter, contacts);
	}

	public int GetContacts(ContactFilter2D contactFilter, List<ContactPoint2D> contacts)
	{
		return Physics2D.GetContacts(this, contactFilter, contacts);
	}

	public int GetContacts(Collider2D[] colliders)
	{
		return Physics2D.GetContacts(this, ContactFilter2D.noFilter, colliders);
	}

	public int GetContacts(List<Collider2D> colliders)
	{
		return Physics2D.GetContacts(this, ContactFilter2D.noFilter, colliders);
	}

	public int GetContacts(ContactFilter2D contactFilter, Collider2D[] colliders)
	{
		return Physics2D.GetContacts(this, contactFilter, colliders);
	}

	public int GetContacts(ContactFilter2D contactFilter, List<Collider2D> colliders)
	{
		return Physics2D.GetContacts(this, contactFilter, colliders);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("OverlapCollider has been deprecated. Please use Overlap. (UnityUpgradable) -> Overlap(*)", false)]
	[ExcludeFromDocs]
	public int OverlapCollider(ContactFilter2D contactFilter, Collider2D[] results)
	{
		return Overlap(contactFilter, results);
	}

	[ExcludeFromDocs]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("OverlapCollider has been deprecated. Please use Overlap. (UnityUpgradable) -> Overlap(*)", false)]
	public int OverlapCollider(ContactFilter2D contactFilter, List<Collider2D> results)
	{
		return Overlap(contactFilter, results);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_density_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_density_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_isTrigger_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_isTrigger_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_usedByEffector_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_usedByEffector_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern CompositeOperation get_compositeOperation_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_compositeOperation_Injected(IntPtr _unity_self, CompositeOperation value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_compositeOrder_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_compositeOrder_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_composite_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_offset_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_offset_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_attachedRigidbody_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_localToWorldMatrix_Injected(IntPtr _unity_self, out Matrix4x4 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_shapeCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr CreateMesh_Injected(IntPtr _unity_self, bool useBodyPosition, bool useBodyRotation, [UnityEngine.Internal.DefaultValue("true")] bool useDelaunay);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern uint GetShapeHash_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetShapes_Internal_Injected(IntPtr _unity_self, ref PhysicsShapeGroup2D.GroupState physicsShapeGroupState, int shapeIndex, int shapeCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetShapeBounds_Injected(IntPtr _unity_self, ref BlittableListWrapper bounds, bool useRadii, bool useWorldSpace, out Bounds ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_bounds_Injected(IntPtr _unity_self, out Bounds ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ColliderErrorState2D get_errorState_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_compositeCapable_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_sharedMaterial_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_sharedMaterial_Injected(IntPtr _unity_self, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_layerOverridePriority_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_layerOverridePriority_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_excludeLayers_Injected(IntPtr _unity_self, out LayerMask ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_excludeLayers_Injected(IntPtr _unity_self, [In] ref LayerMask value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_includeLayers_Injected(IntPtr _unity_self, out LayerMask ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_includeLayers_Injected(IntPtr _unity_self, [In] ref LayerMask value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_forceSendLayers_Injected(IntPtr _unity_self, out LayerMask ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_forceSendLayers_Injected(IntPtr _unity_self, [In] ref LayerMask value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_forceReceiveLayers_Injected(IntPtr _unity_self, out LayerMask ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_forceReceiveLayers_Injected(IntPtr _unity_self, [In] ref LayerMask value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_contactCaptureLayers_Injected(IntPtr _unity_self, out LayerMask ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_contactCaptureLayers_Injected(IntPtr _unity_self, [In] ref LayerMask value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_callbackLayers_Injected(IntPtr _unity_self, out LayerMask ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_callbackLayers_Injected(IntPtr _unity_self, [In] ref LayerMask value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_friction_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_bounciness_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern PhysicsMaterialCombine2D get_frictionCombine_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern PhysicsMaterialCombine2D get_bounceCombine_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_contactMask_Injected(IntPtr _unity_self, out LayerMask ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool CanContact_Injected(IntPtr _unity_self, IntPtr collider);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsTouching_Injected(IntPtr _unity_self, IntPtr collider);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsTouching_OtherColliderWithFilter_Injected(IntPtr _unity_self, IntPtr collider, [In] ref ContactFilter2D contactFilter);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsTouching_AnyColliderWithFilter_Injected(IntPtr _unity_self, [In] ref ContactFilter2D contactFilter);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsTouchingLayers_Injected(IntPtr _unity_self, [UnityEngine.Internal.DefaultValue("Physics2D.AllLayers")] int layerMask);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool OverlapPoint_Injected(IntPtr _unity_self, [In] ref Vector2 point);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CastArray_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, bool ignoreSiblingColliders, bool checkIgnoreColliders, ref ManagedSpanWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CastList_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 direction, float distance, bool ignoreSiblingColliders, bool checkIgnoreColliders, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CastListFiltered_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, bool ignoreSiblingColliders, bool checkIgnoreColliders, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CastFrom_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 position, float angle, [In] ref Vector2 direction, float distance, bool ignoreSiblingColliders, bool checkIgnoreColliders, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int CastFromFiltered_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 position, float angle, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, bool ignoreSiblingColliders, bool checkIgnoreColliders, ref BlittableListWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int RaycastArray_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, ref ManagedSpanWrapper results);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int RaycastList_Internal_Injected(IntPtr _unity_self, [In] ref Vector2 direction, float distance, [In] ref ContactFilter2D contactFilter, ref BlittableListWrapper results);
}
[NativeHeader("Modules/Physics2D/Public/CustomCollider2D.h")]
public sealed class CustomCollider2D : Collider2D
{
	[NativeMethod("CustomShapeCount_Binding")]
	public int customShapeCount
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_customShapeCount_Injected(intPtr);
		}
	}

	[NativeMethod("CustomVertexCount_Binding")]
	public int customVertexCount
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_customVertexCount_Injected(intPtr);
		}
	}

	public int GetCustomShapes(PhysicsShapeGroup2D physicsShapeGroup)
	{
		int num = customShapeCount;
		if (num > 0)
		{
			return GetCustomShapes_Internal(ref physicsShapeGroup.m_GroupState, 0, num);
		}
		physicsShapeGroup.Clear();
		return 0;
	}

	public int GetCustomShapes(PhysicsShapeGroup2D physicsShapeGroup, int shapeIndex, [UnityEngine.Internal.DefaultValue("1")] int shapeCount = 1)
	{
		int num = customShapeCount;
		if (shapeIndex < 0 || shapeIndex >= num || shapeCount < 1 || shapeIndex + shapeCount > num)
		{
			throw new ArgumentOutOfRangeException($"Cannot get shape range from {shapeIndex} to {shapeIndex + shapeCount - 1} as CustomCollider2D only has {num} shape(s).");
		}
		return GetCustomShapes_Internal(ref physicsShapeGroup.m_GroupState, shapeIndex, shapeCount);
	}

	[NativeMethod("GetCustomShapes_Binding")]
	private int GetCustomShapes_Internal(ref PhysicsShapeGroup2D.GroupState physicsShapeGroupState, int shapeIndex, int shapeCount)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetCustomShapes_Internal_Injected(intPtr, ref physicsShapeGroupState, shapeIndex, shapeCount);
	}

	public unsafe int GetCustomShapes(NativeArray<PhysicsShape2D> shapes, NativeArray<Vector2> vertices)
	{
		if (!shapes.IsCreated || shapes.Length != customShapeCount)
		{
			throw new ArgumentException($"Cannot get custom shapes as the native shapes array length must be identical to the current custom shape count of {customShapeCount}.", "shapes");
		}
		if (!vertices.IsCreated || vertices.Length != customVertexCount)
		{
			throw new ArgumentException($"Cannot get custom shapes as the native vertices array length must be identical to the current custom vertex count of {customVertexCount}.", "vertices");
		}
		return GetCustomShapesNative_Internal((IntPtr)shapes.GetUnsafeReadOnlyPtr(), shapes.Length, (IntPtr)vertices.GetUnsafeReadOnlyPtr(), vertices.Length);
	}

	[NativeMethod("GetCustomShapesAllNative_Binding")]
	private int GetCustomShapesNative_Internal(IntPtr shapesPtr, int shapeCount, IntPtr verticesPtr, int vertexCount)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetCustomShapesNative_Internal_Injected(intPtr, shapesPtr, shapeCount, verticesPtr, vertexCount);
	}

	public void SetCustomShapes(PhysicsShapeGroup2D physicsShapeGroup)
	{
		if (physicsShapeGroup.shapeCount > 0)
		{
			SetCustomShapesAll_Internal(ref physicsShapeGroup.m_GroupState);
		}
		else
		{
			ClearCustomShapes();
		}
	}

	[NativeMethod("SetCustomShapesAll_Binding")]
	private void SetCustomShapesAll_Internal(ref PhysicsShapeGroup2D.GroupState physicsShapeGroupState)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetCustomShapesAll_Internal_Injected(intPtr, ref physicsShapeGroupState);
	}

	public unsafe void SetCustomShapes(NativeArray<PhysicsShape2D> shapes, NativeArray<Vector2> vertices)
	{
		if (!shapes.IsCreated || shapes.Length == 0)
		{
			throw new ArgumentException("Cannot set custom shapes as the native shapes array is empty.", "shapes");
		}
		if (!vertices.IsCreated || vertices.Length == 0)
		{
			throw new ArgumentException("Cannot set custom shapes as the native vertices array is empty.", "vertices");
		}
		SetCustomShapesNative_Internal((IntPtr)shapes.GetUnsafeReadOnlyPtr(), shapes.Length, (IntPtr)vertices.GetUnsafeReadOnlyPtr(), vertices.Length);
	}

	[NativeMethod("SetCustomShapesAllNative_Binding", ThrowsException = true)]
	private void SetCustomShapesNative_Internal(IntPtr shapesPtr, int shapeCount, IntPtr verticesPtr, int vertexCount)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetCustomShapesNative_Internal_Injected(intPtr, shapesPtr, shapeCount, verticesPtr, vertexCount);
	}

	public void SetCustomShape(PhysicsShapeGroup2D physicsShapeGroup, int srcShapeIndex, int dstShapeIndex)
	{
		if (srcShapeIndex < 0 || srcShapeIndex >= physicsShapeGroup.shapeCount)
		{
			throw new ArgumentOutOfRangeException($"Cannot set custom shape at {srcShapeIndex} as the shape group only has {physicsShapeGroup.shapeCount} shape(s).");
		}
		PhysicsShape2D shape = physicsShapeGroup.GetShape(srcShapeIndex);
		if (shape.vertexStartIndex < 0 || shape.vertexStartIndex >= physicsShapeGroup.vertexCount || shape.vertexCount < 1 || shape.vertexStartIndex + shape.vertexCount > physicsShapeGroup.vertexCount)
		{
			throw new ArgumentOutOfRangeException($"Cannot set custom shape at {srcShapeIndex} as its shape indices are out of the available vertices ranges.");
		}
		if (dstShapeIndex < 0 || dstShapeIndex >= customShapeCount)
		{
			throw new ArgumentOutOfRangeException($"Cannot set custom shape at destination {dstShapeIndex} as CustomCollider2D only has {customShapeCount} custom shape(s). The destination index must be within the existing shape range.");
		}
		SetCustomShape_Internal(ref physicsShapeGroup.m_GroupState, srcShapeIndex, dstShapeIndex);
	}

	[NativeMethod("SetCustomShape_Binding")]
	private void SetCustomShape_Internal(ref PhysicsShapeGroup2D.GroupState physicsShapeGroupState, int srcShapeIndex, int dstShapeIndex)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetCustomShape_Internal_Injected(intPtr, ref physicsShapeGroupState, srcShapeIndex, dstShapeIndex);
	}

	public unsafe void SetCustomShape(NativeArray<PhysicsShape2D> shapes, NativeArray<Vector2> vertices, int srcShapeIndex, int dstShapeIndex)
	{
		if (!shapes.IsCreated || shapes.Length == 0)
		{
			throw new ArgumentException("Cannot set custom shapes as the native shapes array is empty.", "shapes");
		}
		if (!vertices.IsCreated || vertices.Length == 0)
		{
			throw new ArgumentException("Cannot set custom shapes as the native vertices array is empty.", "vertices");
		}
		if (srcShapeIndex < 0 || srcShapeIndex >= shapes.Length)
		{
			throw new ArgumentOutOfRangeException($"Cannot set custom shape at {srcShapeIndex} as the shape native array only has {shapes.Length} shape(s).");
		}
		PhysicsShape2D physicsShape2D = shapes[srcShapeIndex];
		if (physicsShape2D.vertexStartIndex < 0 || physicsShape2D.vertexStartIndex >= vertices.Length || physicsShape2D.vertexCount < 1 || physicsShape2D.vertexStartIndex + physicsShape2D.vertexCount > vertices.Length)
		{
			throw new ArgumentOutOfRangeException($"Cannot set custom shape at {srcShapeIndex} as its shape indices are out of the available vertices ranges.");
		}
		if (dstShapeIndex < 0 || dstShapeIndex >= customShapeCount)
		{
			throw new ArgumentOutOfRangeException($"Cannot set custom shape at destination {dstShapeIndex} as CustomCollider2D only has {customShapeCount} custom shape(s). The destination index must be within the existing shape range.");
		}
		SetCustomShapeNative_Internal((IntPtr)shapes.GetUnsafeReadOnlyPtr(), shapes.Length, (IntPtr)vertices.GetUnsafeReadOnlyPtr(), vertices.Length, srcShapeIndex, dstShapeIndex);
	}

	[NativeMethod("SetCustomShapeNative_Binding", ThrowsException = true)]
	private void SetCustomShapeNative_Internal(IntPtr shapesPtr, int shapeCount, IntPtr verticesPtr, int vertexCount, int srcShapeIndex, int dstShapeIndex)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetCustomShapeNative_Internal_Injected(intPtr, shapesPtr, shapeCount, verticesPtr, vertexCount, srcShapeIndex, dstShapeIndex);
	}

	public void ClearCustomShapes(int shapeIndex, int shapeCount)
	{
		int num = customShapeCount;
		if (shapeIndex < 0 || shapeIndex >= num)
		{
			throw new ArgumentOutOfRangeException($"Cannot clear custom shape(s) at index {shapeIndex} as the CustomCollider2D only has {num} shape(s).");
		}
		if (shapeIndex + shapeCount < 0 || shapeIndex + shapeCount > customShapeCount)
		{
			throw new ArgumentOutOfRangeException($"Cannot clear custom shape(s) in the range (index {shapeIndex}, count {shapeCount}) as this range is outside range of the existing {customShapeCount} shape(s).");
		}
		ClearCustomShapes_Internal(shapeIndex, shapeCount);
	}

	[NativeMethod("ClearCustomShapes_Binding")]
	private void ClearCustomShapes_Internal(int shapeIndex, int shapeCount)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ClearCustomShapes_Internal_Injected(intPtr, shapeIndex, shapeCount);
	}

	[NativeMethod("ClearCustomShapes_Binding")]
	public void ClearCustomShapes()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ClearCustomShapes_Injected(intPtr);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_customShapeCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_customVertexCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetCustomShapes_Internal_Injected(IntPtr _unity_self, ref PhysicsShapeGroup2D.GroupState physicsShapeGroupState, int shapeIndex, int shapeCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetCustomShapesNative_Internal_Injected(IntPtr _unity_self, IntPtr shapesPtr, int shapeCount, IntPtr verticesPtr, int vertexCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetCustomShapesAll_Internal_Injected(IntPtr _unity_self, ref PhysicsShapeGroup2D.GroupState physicsShapeGroupState);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetCustomShapesNative_Internal_Injected(IntPtr _unity_self, IntPtr shapesPtr, int shapeCount, IntPtr verticesPtr, int vertexCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetCustomShape_Internal_Injected(IntPtr _unity_self, ref PhysicsShapeGroup2D.GroupState physicsShapeGroupState, int srcShapeIndex, int dstShapeIndex);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetCustomShapeNative_Internal_Injected(IntPtr _unity_self, IntPtr shapesPtr, int shapeCount, IntPtr verticesPtr, int vertexCount, int srcShapeIndex, int dstShapeIndex);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ClearCustomShapes_Internal_Injected(IntPtr _unity_self, int shapeIndex, int shapeCount);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ClearCustomShapes_Injected(IntPtr _unity_self);
}
[NativeHeader("Modules/Physics2D/Public/CircleCollider2D.h")]
public sealed class CircleCollider2D : Collider2D
{
	public float radius
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_radius_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_radius_Injected(intPtr, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("CircleCollider2D.center has been obsolete. Use CircleCollider2D.offset instead (UnityUpgradable) -> offset", true)]
	public Vector2 center
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_radius_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_radius_Injected(IntPtr _unity_self, float value);
}
[NativeHeader("Modules/Physics2D/Public/CapsuleCollider2D.h")]
public sealed class CapsuleCollider2D : Collider2D
{
	public Vector2 size
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_size_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_size_Injected(intPtr, ref value);
		}
	}

	public CapsuleDirection2D direction
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_direction_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_direction_Injected(intPtr, value);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_size_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_size_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern CapsuleDirection2D get_direction_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_direction_Injected(IntPtr _unity_self, CapsuleDirection2D value);
}
[NativeHeader("Modules/Physics2D/Public/EdgeCollider2D.h")]
public sealed class EdgeCollider2D : Collider2D
{
	public float edgeRadius
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_edgeRadius_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_edgeRadius_Injected(intPtr, value);
		}
	}

	public int edgeCount
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_edgeCount_Injected(intPtr);
		}
	}

	public int pointCount
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_pointCount_Injected(intPtr);
		}
	}

	public unsafe Vector2[] points
	{
		get
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			Vector2[] result;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_points_Injected(intPtr, out ret);
			}
			finally
			{
				Vector2[] array = default(Vector2[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<Vector2> span = new Span<Vector2>(value);
			fixed (Vector2* begin = span)
			{
				ManagedSpanWrapper value2 = new ManagedSpanWrapper(begin, span.Length);
				set_points_Injected(intPtr, ref value2);
			}
		}
	}

	public bool useAdjacentStartPoint
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useAdjacentStartPoint_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useAdjacentStartPoint_Injected(intPtr, value);
		}
	}

	public bool useAdjacentEndPoint
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useAdjacentEndPoint_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useAdjacentEndPoint_Injected(intPtr, value);
		}
	}

	public Vector2 adjacentStartPoint
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_adjacentStartPoint_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_adjacentStartPoint_Injected(intPtr, ref value);
		}
	}

	public Vector2 adjacentEndPoint
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_adjacentEndPoint_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_adjacentEndPoint_Injected(intPtr, ref value);
		}
	}

	public void Reset()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Reset_Injected(intPtr);
	}

	[NativeMethod("GetPoints_Binding")]
	public unsafe int GetPoints([NotNull] List<Vector2> points)
	{
		if (points == null)
		{
			ThrowHelper.ThrowArgumentNullException(points, "points");
		}
		List<Vector2> list = default(List<Vector2>);
		BlittableListWrapper blittableListWrapper = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = points;
			fixed (Vector2[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				blittableListWrapper = new BlittableListWrapper(arrayWrapper, list.Count);
				return GetPoints_Injected(intPtr, ref blittableListWrapper);
			}
		}
		finally
		{
			blittableListWrapper.Unmarshal(list);
		}
	}

	[NativeMethod("SetPoints_Binding")]
	public unsafe bool SetPoints([NotNull] List<Vector2> points)
	{
		if (points == null)
		{
			ThrowHelper.ThrowArgumentNullException(points, "points");
		}
		List<Vector2> list = default(List<Vector2>);
		BlittableListWrapper blittableListWrapper = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = points;
			fixed (Vector2[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				blittableListWrapper = new BlittableListWrapper(arrayWrapper, list.Count);
				return SetPoints_Injected(intPtr, ref blittableListWrapper);
			}
		}
		finally
		{
			blittableListWrapper.Unmarshal(list);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Reset_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_edgeRadius_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_edgeRadius_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_edgeCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_pointCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_points_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_points_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetPoints_Injected(IntPtr _unity_self, ref BlittableListWrapper points);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool SetPoints_Injected(IntPtr _unity_self, ref BlittableListWrapper points);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useAdjacentStartPoint_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useAdjacentStartPoint_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useAdjacentEndPoint_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useAdjacentEndPoint_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_adjacentStartPoint_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_adjacentStartPoint_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_adjacentEndPoint_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_adjacentEndPoint_Injected(IntPtr _unity_self, [In] ref Vector2 value);
}
[NativeHeader("Modules/Physics2D/Public/BoxCollider2D.h")]
public sealed class BoxCollider2D : Collider2D
{
	public Vector2 size
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_size_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_size_Injected(intPtr, ref value);
		}
	}

	public float edgeRadius
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_edgeRadius_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_edgeRadius_Injected(intPtr, value);
		}
	}

	public bool autoTiling
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_autoTiling_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_autoTiling_Injected(intPtr, value);
		}
	}

	[Obsolete("BoxCollider2D.center has been obsolete. Use BoxCollider2D.offset instead (UnityUpgradable) -> offset", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Vector2 center
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_size_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_size_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_edgeRadius_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_edgeRadius_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_autoTiling_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_autoTiling_Injected(IntPtr _unity_self, bool value);
}
[NativeHeader("Modules/Physics2D/Public/PolygonCollider2D.h")]
public sealed class PolygonCollider2D : Collider2D
{
	public bool useDelaunayMesh
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useDelaunayMesh_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useDelaunayMesh_Injected(intPtr, value);
		}
	}

	public bool autoTiling
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_autoTiling_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_autoTiling_Injected(intPtr, value);
		}
	}

	public unsafe Vector2[] points
	{
		[NativeMethod("GetPoints_Binding")]
		get
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			Vector2[] result;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_points_Injected(intPtr, out ret);
			}
			finally
			{
				Vector2[] array = default(Vector2[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}
		[NativeMethod("SetPoints_Binding")]
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<Vector2> span = new Span<Vector2>(value);
			fixed (Vector2* begin = span)
			{
				ManagedSpanWrapper value2 = new ManagedSpanWrapper(begin, span.Length);
				set_points_Injected(intPtr, ref value2);
			}
		}
	}

	public int pathCount
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_pathCount_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_pathCount_Injected(intPtr, value);
		}
	}

	[NativeMethod("GetPointCount")]
	public int GetTotalPointCount()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetTotalPointCount_Injected(intPtr);
	}

	public Vector2[] GetPath(int index)
	{
		if (index >= pathCount)
		{
			throw new ArgumentOutOfRangeException($"Path {index} does not exist.");
		}
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException($"Path {index} does not exist; negative path index is invalid.");
		}
		return GetPath_Internal(index);
	}

	[NativeMethod("GetPath_Binding")]
	private Vector2[] GetPath_Internal(int index)
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		Vector2[] result;
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetPath_Internal_Injected(intPtr, index, out ret);
		}
		finally
		{
			Vector2[] array = default(Vector2[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public void SetPath(int index, Vector2[] points)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException($"Negative path index {index} is invalid.");
		}
		SetPath_Internal(index, points);
	}

	[NativeMethod("SetPath_Binding")]
	private unsafe void SetPath_Internal(int index, [NotNull] Vector2[] points)
	{
		if (points == null)
		{
			ThrowHelper.ThrowArgumentNullException(points, "points");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<Vector2> span = new Span<Vector2>(points);
		fixed (Vector2* begin = span)
		{
			ManagedSpanWrapper managedSpanWrapper = new ManagedSpanWrapper(begin, span.Length);
			SetPath_Internal_Injected(intPtr, index, ref managedSpanWrapper);
		}
	}

	public int GetPath(int index, List<Vector2> points)
	{
		if (index < 0 || index >= pathCount)
		{
			throw new ArgumentOutOfRangeException("index", $"Path index {index} must be in the range of 0 to {pathCount - 1}.");
		}
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		return GetPathList_Internal(index, points);
	}

	[NativeMethod("GetPathList_Binding")]
	private unsafe int GetPathList_Internal(int index, [NotNull] List<Vector2> points)
	{
		if (points == null)
		{
			ThrowHelper.ThrowArgumentNullException(points, "points");
		}
		List<Vector2> list = default(List<Vector2>);
		BlittableListWrapper blittableListWrapper = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = points;
			fixed (Vector2[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				blittableListWrapper = new BlittableListWrapper(arrayWrapper, list.Count);
				return GetPathList_Internal_Injected(intPtr, index, ref blittableListWrapper);
			}
		}
		finally
		{
			blittableListWrapper.Unmarshal(list);
		}
	}

	public void SetPath(int index, List<Vector2> points)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException($"Negative path index {index} is invalid.");
		}
		SetPathList_Internal(index, points);
	}

	[NativeMethod("SetPathList_Binding")]
	private unsafe void SetPathList_Internal(int index, [NotNull] List<Vector2> points)
	{
		if (points == null)
		{
			ThrowHelper.ThrowArgumentNullException(points, "points");
		}
		List<Vector2> list = default(List<Vector2>);
		BlittableListWrapper blittableListWrapper = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = points;
			fixed (Vector2[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				blittableListWrapper = new BlittableListWrapper(arrayWrapper, list.Count);
				SetPathList_Internal_Injected(intPtr, index, ref blittableListWrapper);
			}
		}
		finally
		{
			blittableListWrapper.Unmarshal(list);
		}
	}

	[ExcludeFromDocs]
	public void CreatePrimitive(int sides)
	{
		CreatePrimitive(sides, Vector2.one, Vector2.zero);
	}

	[ExcludeFromDocs]
	public void CreatePrimitive(int sides, Vector2 scale)
	{
		CreatePrimitive(sides, scale, Vector2.zero);
	}

	public void CreatePrimitive(int sides, [UnityEngine.Internal.DefaultValue("Vector2.one")] Vector2 scale, [UnityEngine.Internal.DefaultValue("Vector2.zero")] Vector2 offset)
	{
		if (sides < 3)
		{
			Debug.LogWarning("Cannot create a 2D polygon primitive collider with less than two sides.", this);
		}
		else if (!(scale.x > 0f) || !(scale.y > 0f))
		{
			Debug.LogWarning("Cannot create a 2D polygon primitive collider with an axis scale less than or equal to zero.", this);
		}
		else
		{
			CreatePrimitive_Internal(sides, scale, offset, recreateCollider: true);
		}
	}

	[NativeMethod("CreatePrimitive")]
	private void CreatePrimitive_Internal(int sides, Vector2 scale, Vector2 offset, bool recreateCollider)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		CreatePrimitive_Internal_Injected(intPtr, sides, ref scale, ref offset, recreateCollider);
	}

	public bool CreateFromSprite(Sprite sprite, [UnityEngine.Internal.DefaultValue("0.25f")] float detail = 0.25f, [UnityEngine.Internal.DefaultValue("200")] byte alphaTolerance = 200, [UnityEngine.Internal.DefaultValue("true")] bool holeDetection = true)
	{
		if (sprite == null)
		{
			Debug.LogWarning("Sprite cannot be NULL.", this);
			return false;
		}
		if (detail < 0f || detail > 1f)
		{
			Debug.LogWarning("Detail must be in the range [0, 1].", this);
			return false;
		}
		return CreateFromSprite_Internal(sprite, detail, alphaTolerance, holeDetection, recreateCollider: true);
	}

	[NativeMethod("CreateFromSprite")]
	private bool CreateFromSprite_Internal([NotNull] Sprite sprite, float detail, byte alphaTolerance, bool holeDetection, bool recreateCollider)
	{
		if ((object)sprite == null)
		{
			ThrowHelper.ThrowArgumentNullException(sprite, "sprite");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(sprite);
		if (intPtr2 == (IntPtr)0)
		{
			ThrowHelper.ThrowArgumentNullException(sprite, "sprite");
		}
		return CreateFromSprite_Internal_Injected(intPtr, intPtr2, detail, alphaTolerance, holeDetection, recreateCollider);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useDelaunayMesh_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useDelaunayMesh_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_autoTiling_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_autoTiling_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetTotalPointCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_points_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_points_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_pathCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_pathCount_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetPath_Internal_Injected(IntPtr _unity_self, int index, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetPath_Internal_Injected(IntPtr _unity_self, int index, ref ManagedSpanWrapper points);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetPathList_Internal_Injected(IntPtr _unity_self, int index, ref BlittableListWrapper points);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetPathList_Internal_Injected(IntPtr _unity_self, int index, ref BlittableListWrapper points);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void CreatePrimitive_Internal_Injected(IntPtr _unity_self, int sides, [In] ref Vector2 scale, [In] ref Vector2 offset, bool recreateCollider);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool CreateFromSprite_Internal_Injected(IntPtr _unity_self, IntPtr sprite, float detail, byte alphaTolerance, bool holeDetection, bool recreateCollider);
}
[RequireComponent(typeof(Rigidbody2D))]
[NativeHeader("Modules/Physics2D/Public/CompositeCollider2D.h")]
public sealed class CompositeCollider2D : Collider2D
{
	public enum GeometryType
	{
		Outlines,
		Polygons
	}

	public enum GenerationType
	{
		Synchronous,
		Manual
	}

	public GeometryType geometryType
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_geometryType_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_geometryType_Injected(intPtr, value);
		}
	}

	public GenerationType generationType
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_generationType_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_generationType_Injected(intPtr, value);
		}
	}

	public bool useDelaunayMesh
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useDelaunayMesh_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useDelaunayMesh_Injected(intPtr, value);
		}
	}

	public float vertexDistance
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_vertexDistance_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_vertexDistance_Injected(intPtr, value);
		}
	}

	public float edgeRadius
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_edgeRadius_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_edgeRadius_Injected(intPtr, value);
		}
	}

	public float offsetDistance
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_offsetDistance_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_offsetDistance_Injected(intPtr, value);
		}
	}

	public int pathCount
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_pathCount_Injected(intPtr);
		}
	}

	public int pointCount
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_pointCount_Injected(intPtr);
		}
	}

	public void GenerateGeometry()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GenerateGeometry_Injected(intPtr);
	}

	[NativeMethod("GetCompositedColliders_Binding")]
	public int GetCompositedColliders([NotNull] List<Collider2D> colliders)
	{
		if (colliders == null)
		{
			ThrowHelper.ThrowArgumentNullException(colliders, "colliders");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetCompositedColliders_Injected(intPtr, colliders);
	}

	public int GetPathPointCount(int index)
	{
		int num = pathCount - 1;
		if (index < 0 || index > num)
		{
			throw new ArgumentOutOfRangeException("index", $"Path index {index} must be in the range of 0 to {num}.");
		}
		return GetPathPointCount_Internal(index);
	}

	[NativeMethod("GetPathPointCount_Binding")]
	private int GetPathPointCount_Internal(int index)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetPathPointCount_Internal_Injected(intPtr, index);
	}

	public int GetPath(int index, Vector2[] points)
	{
		if (index < 0 || index >= pathCount)
		{
			throw new ArgumentOutOfRangeException("index", $"Path index {index} must be in the range of 0 to {pathCount - 1}.");
		}
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		return GetPathArray_Internal(index, points);
	}

	[NativeMethod("GetPathArray_Binding")]
	private unsafe int GetPathArray_Internal(int index, [NotNull] Vector2[] points)
	{
		if (points == null)
		{
			ThrowHelper.ThrowArgumentNullException(points, "points");
		}
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Span<Vector2> span = new Span<Vector2>(points);
		int pathArray_Internal_Injected;
		fixed (Vector2* begin = span)
		{
			ManagedSpanWrapper points2 = new ManagedSpanWrapper(begin, span.Length);
			pathArray_Internal_Injected = GetPathArray_Internal_Injected(intPtr, index, ref points2);
		}
		return pathArray_Internal_Injected;
	}

	public int GetPath(int index, List<Vector2> points)
	{
		if (index < 0 || index >= pathCount)
		{
			throw new ArgumentOutOfRangeException("index", $"Path index {index} must be in the range of 0 to {pathCount - 1}.");
		}
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		return GetPathList_Internal(index, points);
	}

	[NativeMethod("GetPathList_Binding")]
	private unsafe int GetPathList_Internal(int index, [NotNull] List<Vector2> points)
	{
		if (points == null)
		{
			ThrowHelper.ThrowArgumentNullException(points, "points");
		}
		List<Vector2> list = default(List<Vector2>);
		BlittableListWrapper points2 = default(BlittableListWrapper);
		try
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			list = points;
			fixed (Vector2[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				points2 = new BlittableListWrapper(arrayWrapper, list.Count);
				return GetPathList_Internal_Injected(intPtr, index, ref points2);
			}
		}
		finally
		{
			points2.Unmarshal(list);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern GeometryType get_geometryType_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_geometryType_Injected(IntPtr _unity_self, GeometryType value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern GenerationType get_generationType_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_generationType_Injected(IntPtr _unity_self, GenerationType value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useDelaunayMesh_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useDelaunayMesh_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_vertexDistance_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_vertexDistance_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_edgeRadius_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_edgeRadius_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_offsetDistance_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_offsetDistance_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GenerateGeometry_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetCompositedColliders_Injected(IntPtr _unity_self, List<Collider2D> colliders);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetPathPointCount_Internal_Injected(IntPtr _unity_self, int index);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_pathCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_pointCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetPathArray_Internal_Injected(IntPtr _unity_self, int index, ref ManagedSpanWrapper points);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetPathList_Internal_Injected(IntPtr _unity_self, int index, ref BlittableListWrapper points);
}
[NativeHeader("Modules/Physics2D/Joint2D.h")]
[RequireComponent(typeof(Transform), typeof(Rigidbody2D))]
public class Joint2D : Behaviour
{
	public Rigidbody2D attachedRigidbody
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Rigidbody2D>(get_attachedRigidbody_Injected(intPtr));
		}
	}

	public Rigidbody2D connectedBody
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Rigidbody2D>(get_connectedBody_Injected(intPtr));
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_connectedBody_Injected(intPtr, MarshalledUnityObject.Marshal(value));
		}
	}

	public bool enableCollision
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_enableCollision_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_enableCollision_Injected(intPtr, value);
		}
	}

	public float breakForce
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_breakForce_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_breakForce_Injected(intPtr, value);
		}
	}

	public float breakTorque
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_breakTorque_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_breakTorque_Injected(intPtr, value);
		}
	}

	public JointBreakAction2D breakAction
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_breakAction_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_breakAction_Injected(intPtr, value);
		}
	}

	public Vector2 reactionForce
	{
		[NativeMethod("GetReactionForceFixedTime")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_reactionForce_Injected(intPtr, out var ret);
			return ret;
		}
	}

	public float reactionTorque
	{
		[NativeMethod("GetReactionTorqueFixedTime")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_reactionTorque_Injected(intPtr);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Joint2D.collideConnected has been obsolete. Use Joint2D.enableCollision instead (UnityUpgradable) -> enableCollision", true)]
	public bool collideConnected
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public Vector2 GetReactionForce(float timeStep)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetReactionForce_Injected(intPtr, timeStep, out var ret);
		return ret;
	}

	public float GetReactionTorque(float timeStep)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetReactionTorque_Injected(intPtr, timeStep);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_attachedRigidbody_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_connectedBody_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_connectedBody_Injected(IntPtr _unity_self, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_enableCollision_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_enableCollision_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_breakForce_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_breakForce_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_breakTorque_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_breakTorque_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern JointBreakAction2D get_breakAction_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_breakAction_Injected(IntPtr _unity_self, JointBreakAction2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_reactionForce_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_reactionTorque_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetReactionForce_Injected(IntPtr _unity_self, float timeStep, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetReactionTorque_Injected(IntPtr _unity_self, float timeStep);
}
[NativeHeader("Modules/Physics2D/AnchoredJoint2D.h")]
public class AnchoredJoint2D : Joint2D
{
	public Vector2 anchor
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_anchor_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_anchor_Injected(intPtr, ref value);
		}
	}

	public Vector2 connectedAnchor
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_connectedAnchor_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_connectedAnchor_Injected(intPtr, ref value);
		}
	}

	public bool autoConfigureConnectedAnchor
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_autoConfigureConnectedAnchor_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_autoConfigureConnectedAnchor_Injected(intPtr, value);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_anchor_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_anchor_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_connectedAnchor_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_connectedAnchor_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_autoConfigureConnectedAnchor_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_autoConfigureConnectedAnchor_Injected(IntPtr _unity_self, bool value);
}
[NativeHeader("Modules/Physics2D/SpringJoint2D.h")]
public sealed class SpringJoint2D : AnchoredJoint2D
{
	public bool autoConfigureDistance
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_autoConfigureDistance_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_autoConfigureDistance_Injected(intPtr, value);
		}
	}

	public float distance
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_distance_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_distance_Injected(intPtr, value);
		}
	}

	public float dampingRatio
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_dampingRatio_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_dampingRatio_Injected(intPtr, value);
		}
	}

	public float frequency
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_frequency_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_frequency_Injected(intPtr, value);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_autoConfigureDistance_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_autoConfigureDistance_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_distance_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_distance_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_dampingRatio_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_dampingRatio_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_frequency_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_frequency_Injected(IntPtr _unity_self, float value);
}
[NativeHeader("Modules/Physics2D/DistanceJoint2D.h")]
public sealed class DistanceJoint2D : AnchoredJoint2D
{
	public bool autoConfigureDistance
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_autoConfigureDistance_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_autoConfigureDistance_Injected(intPtr, value);
		}
	}

	public float distance
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_distance_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_distance_Injected(intPtr, value);
		}
	}

	public bool maxDistanceOnly
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_maxDistanceOnly_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_maxDistanceOnly_Injected(intPtr, value);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_autoConfigureDistance_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_autoConfigureDistance_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_distance_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_distance_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_maxDistanceOnly_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_maxDistanceOnly_Injected(IntPtr _unity_self, bool value);
}
[NativeHeader("Modules/Physics2D/FrictionJoint2D.h")]
public sealed class FrictionJoint2D : AnchoredJoint2D
{
	public float maxForce
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_maxForce_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_maxForce_Injected(intPtr, value);
		}
	}

	public float maxTorque
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_maxTorque_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_maxTorque_Injected(intPtr, value);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_maxForce_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_maxForce_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_maxTorque_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_maxTorque_Injected(IntPtr _unity_self, float value);
}
[NativeHeader("Modules/Physics2D/HingeJoint2D.h")]
public sealed class HingeJoint2D : AnchoredJoint2D
{
	public bool useMotor
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useMotor_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useMotor_Injected(intPtr, value);
		}
	}

	public bool useLimits
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useLimits_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useLimits_Injected(intPtr, value);
		}
	}

	public bool useConnectedAnchor
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useConnectedAnchor_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useConnectedAnchor_Injected(intPtr, value);
		}
	}

	public JointMotor2D motor
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_motor_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_motor_Injected(intPtr, ref value);
		}
	}

	public JointAngleLimits2D limits
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_limits_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_limits_Injected(intPtr, ref value);
		}
	}

	public JointLimitState2D limitState
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_limitState_Injected(intPtr);
		}
	}

	public float referenceAngle
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_referenceAngle_Injected(intPtr);
		}
	}

	public float jointAngle
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_jointAngle_Injected(intPtr);
		}
	}

	public float jointSpeed
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_jointSpeed_Injected(intPtr);
		}
	}

	public float GetMotorTorque(float timeStep)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetMotorTorque_Injected(intPtr, timeStep);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useMotor_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useMotor_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useLimits_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useLimits_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useConnectedAnchor_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useConnectedAnchor_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_motor_Injected(IntPtr _unity_self, out JointMotor2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_motor_Injected(IntPtr _unity_self, [In] ref JointMotor2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_limits_Injected(IntPtr _unity_self, out JointAngleLimits2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_limits_Injected(IntPtr _unity_self, [In] ref JointAngleLimits2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern JointLimitState2D get_limitState_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_referenceAngle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_jointAngle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_jointSpeed_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetMotorTorque_Injected(IntPtr _unity_self, float timeStep);
}
[NativeHeader("Modules/Physics2D/RelativeJoint2D.h")]
public sealed class RelativeJoint2D : Joint2D
{
	public float maxForce
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_maxForce_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_maxForce_Injected(intPtr, value);
		}
	}

	public float maxTorque
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_maxTorque_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_maxTorque_Injected(intPtr, value);
		}
	}

	public float correctionScale
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_correctionScale_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_correctionScale_Injected(intPtr, value);
		}
	}

	public bool autoConfigureOffset
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_autoConfigureOffset_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_autoConfigureOffset_Injected(intPtr, value);
		}
	}

	public Vector2 linearOffset
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_linearOffset_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_linearOffset_Injected(intPtr, ref value);
		}
	}

	public float angularOffset
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_angularOffset_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_angularOffset_Injected(intPtr, value);
		}
	}

	public Vector2 target
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_target_Injected(intPtr, out var ret);
			return ret;
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_maxForce_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_maxForce_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_maxTorque_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_maxTorque_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_correctionScale_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_correctionScale_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_autoConfigureOffset_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_autoConfigureOffset_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_linearOffset_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_linearOffset_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_angularOffset_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_angularOffset_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_target_Injected(IntPtr _unity_self, out Vector2 ret);
}
[NativeHeader("Modules/Physics2D/SliderJoint2D.h")]
public sealed class SliderJoint2D : AnchoredJoint2D
{
	public bool autoConfigureAngle
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_autoConfigureAngle_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_autoConfigureAngle_Injected(intPtr, value);
		}
	}

	public float angle
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_angle_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_angle_Injected(intPtr, value);
		}
	}

	public bool useMotor
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useMotor_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useMotor_Injected(intPtr, value);
		}
	}

	public bool useLimits
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useLimits_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useLimits_Injected(intPtr, value);
		}
	}

	public JointMotor2D motor
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_motor_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_motor_Injected(intPtr, ref value);
		}
	}

	public JointTranslationLimits2D limits
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_limits_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_limits_Injected(intPtr, ref value);
		}
	}

	public JointLimitState2D limitState
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_limitState_Injected(intPtr);
		}
	}

	public float referenceAngle
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_referenceAngle_Injected(intPtr);
		}
	}

	public float jointTranslation
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_jointTranslation_Injected(intPtr);
		}
	}

	public float jointSpeed
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_jointSpeed_Injected(intPtr);
		}
	}

	public float GetMotorForce(float timeStep)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetMotorForce_Injected(intPtr, timeStep);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_autoConfigureAngle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_autoConfigureAngle_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_angle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_angle_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useMotor_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useMotor_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useLimits_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useLimits_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_motor_Injected(IntPtr _unity_self, out JointMotor2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_motor_Injected(IntPtr _unity_self, [In] ref JointMotor2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_limits_Injected(IntPtr _unity_self, out JointTranslationLimits2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_limits_Injected(IntPtr _unity_self, [In] ref JointTranslationLimits2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern JointLimitState2D get_limitState_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_referenceAngle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_jointTranslation_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_jointSpeed_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetMotorForce_Injected(IntPtr _unity_self, float timeStep);
}
[NativeHeader("Modules/Physics2D/TargetJoint2D.h")]
public sealed class TargetJoint2D : Joint2D
{
	public Vector2 anchor
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_anchor_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_anchor_Injected(intPtr, ref value);
		}
	}

	public Vector2 target
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_target_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_target_Injected(intPtr, ref value);
		}
	}

	public bool autoConfigureTarget
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_autoConfigureTarget_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_autoConfigureTarget_Injected(intPtr, value);
		}
	}

	public float maxForce
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_maxForce_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_maxForce_Injected(intPtr, value);
		}
	}

	public float dampingRatio
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_dampingRatio_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_dampingRatio_Injected(intPtr, value);
		}
	}

	public float frequency
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_frequency_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_frequency_Injected(intPtr, value);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_anchor_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_anchor_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_target_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_target_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_autoConfigureTarget_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_autoConfigureTarget_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_maxForce_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_maxForce_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_dampingRatio_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_dampingRatio_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_frequency_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_frequency_Injected(IntPtr _unity_self, float value);
}
[NativeHeader("Modules/Physics2D/FixedJoint2D.h")]
public sealed class FixedJoint2D : AnchoredJoint2D
{
	public float dampingRatio
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_dampingRatio_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_dampingRatio_Injected(intPtr, value);
		}
	}

	public float frequency
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_frequency_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_frequency_Injected(intPtr, value);
		}
	}

	public float referenceAngle
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_referenceAngle_Injected(intPtr);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_dampingRatio_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_dampingRatio_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_frequency_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_frequency_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_referenceAngle_Injected(IntPtr _unity_self);
}
[NativeHeader("Modules/Physics2D/WheelJoint2D.h")]
public sealed class WheelJoint2D : AnchoredJoint2D
{
	public JointSuspension2D suspension
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_suspension_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_suspension_Injected(intPtr, ref value);
		}
	}

	public bool useMotor
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useMotor_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useMotor_Injected(intPtr, value);
		}
	}

	public JointMotor2D motor
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_motor_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_motor_Injected(intPtr, ref value);
		}
	}

	public float jointTranslation
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_jointTranslation_Injected(intPtr);
		}
	}

	public float jointLinearSpeed
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_jointLinearSpeed_Injected(intPtr);
		}
	}

	public float jointSpeed
	{
		[NativeMethod("GetJointAngularSpeed")]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_jointSpeed_Injected(intPtr);
		}
	}

	public float jointAngle
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_jointAngle_Injected(intPtr);
		}
	}

	public float GetMotorTorque(float timeStep)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetMotorTorque_Injected(intPtr, timeStep);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_suspension_Injected(IntPtr _unity_self, out JointSuspension2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_suspension_Injected(IntPtr _unity_self, [In] ref JointSuspension2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useMotor_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useMotor_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_motor_Injected(IntPtr _unity_self, out JointMotor2D ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_motor_Injected(IntPtr _unity_self, [In] ref JointMotor2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_jointTranslation_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_jointLinearSpeed_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_jointSpeed_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_jointAngle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetMotorTorque_Injected(IntPtr _unity_self, float timeStep);
}
[NativeHeader("Modules/Physics2D/Effector2D.h")]
public class Effector2D : Behaviour
{
	public bool useColliderMask
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useColliderMask_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useColliderMask_Injected(intPtr, value);
		}
	}

	public int colliderMask
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_colliderMask_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_colliderMask_Injected(intPtr, value);
		}
	}

	internal bool requiresCollider
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_requiresCollider_Injected(intPtr);
		}
	}

	internal bool designedForTrigger
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_designedForTrigger_Injected(intPtr);
		}
	}

	internal bool designedForNonTrigger
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_designedForNonTrigger_Injected(intPtr);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useColliderMask_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useColliderMask_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_colliderMask_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_colliderMask_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_requiresCollider_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_designedForTrigger_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_designedForNonTrigger_Injected(IntPtr _unity_self);
}
[NativeHeader("Modules/Physics2D/AreaEffector2D.h")]
public class AreaEffector2D : Effector2D
{
	public float forceAngle
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_forceAngle_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_forceAngle_Injected(intPtr, value);
		}
	}

	public bool useGlobalAngle
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useGlobalAngle_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useGlobalAngle_Injected(intPtr, value);
		}
	}

	public float forceMagnitude
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_forceMagnitude_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_forceMagnitude_Injected(intPtr, value);
		}
	}

	public float forceVariation
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_forceVariation_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_forceVariation_Injected(intPtr, value);
		}
	}

	public float linearDamping
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_linearDamping_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_linearDamping_Injected(intPtr, value);
		}
	}

	public float angularDamping
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_angularDamping_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_angularDamping_Injected(intPtr, value);
		}
	}

	public EffectorSelection2D forceTarget
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_forceTarget_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_forceTarget_Injected(intPtr, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("AreaEffector2D.forceDirection has been obsolete. Use AreaEffector2D.forceAngle instead (UnityUpgradable) -> forceAngle", true)]
	public float forceDirection
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[Obsolete("AreaEffector2D.drag has been obsolete. Use AreaEffector2D.linearDamping instead (UnityUpgradable) -> linearDamping", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public float drag
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("AreaEffector2D.angularDrag has been obsolete. Use AreaEffector2D.angularDamping instead (UnityUpgradable) -> angularDamping", true)]
	public float angularDrag
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_forceAngle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_forceAngle_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useGlobalAngle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useGlobalAngle_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_forceMagnitude_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_forceMagnitude_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_forceVariation_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_forceVariation_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_linearDamping_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_linearDamping_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_angularDamping_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_angularDamping_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern EffectorSelection2D get_forceTarget_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_forceTarget_Injected(IntPtr _unity_self, EffectorSelection2D value);
}
[NativeHeader("Modules/Physics2D/BuoyancyEffector2D.h")]
public class BuoyancyEffector2D : Effector2D
{
	public float surfaceLevel
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_surfaceLevel_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_surfaceLevel_Injected(intPtr, value);
		}
	}

	public float density
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_density_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_density_Injected(intPtr, value);
		}
	}

	public float linearDamping
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_linearDamping_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_linearDamping_Injected(intPtr, value);
		}
	}

	public float angularDamping
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_angularDamping_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_angularDamping_Injected(intPtr, value);
		}
	}

	public float flowAngle
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_flowAngle_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_flowAngle_Injected(intPtr, value);
		}
	}

	public float flowMagnitude
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_flowMagnitude_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_flowMagnitude_Injected(intPtr, value);
		}
	}

	public float flowVariation
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_flowVariation_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_flowVariation_Injected(intPtr, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("BuoyancyEffector2D.drag has been obsolete. Use BuoyancyEffector2D.linearDamping instead (UnityUpgradable) -> linearDamping", true)]
	public float drag
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[Obsolete("BuoyancyEffector2D.angularDrag has been obsolete. Use BuoyancyEffector2D.angularDamping instead (UnityUpgradable) -> angularDamping", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public float angularDrag
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_surfaceLevel_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_surfaceLevel_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_density_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_density_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_linearDamping_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_linearDamping_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_angularDamping_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_angularDamping_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_flowAngle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_flowAngle_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_flowMagnitude_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_flowMagnitude_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_flowVariation_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_flowVariation_Injected(IntPtr _unity_self, float value);
}
[NativeHeader("Modules/Physics2D/PointEffector2D.h")]
public class PointEffector2D : Effector2D
{
	public float forceMagnitude
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_forceMagnitude_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_forceMagnitude_Injected(intPtr, value);
		}
	}

	public float forceVariation
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_forceVariation_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_forceVariation_Injected(intPtr, value);
		}
	}

	public float distanceScale
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_distanceScale_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_distanceScale_Injected(intPtr, value);
		}
	}

	public float linearDamping
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_linearDamping_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_linearDamping_Injected(intPtr, value);
		}
	}

	public float angularDamping
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_angularDamping_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_angularDamping_Injected(intPtr, value);
		}
	}

	public EffectorSelection2D forceSource
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_forceSource_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_forceSource_Injected(intPtr, value);
		}
	}

	public EffectorSelection2D forceTarget
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_forceTarget_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_forceTarget_Injected(intPtr, value);
		}
	}

	public EffectorForceMode2D forceMode
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_forceMode_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_forceMode_Injected(intPtr, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("PointEffector2D.drag has been obsolete. Use PointEffector2D.linearDamping instead (UnityUpgradable) -> linearDamping", true)]
	public float drag
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("PointEffector2D.angularDrag has been obsolete. Use PointEffector2D.angularDamping instead (UnityUpgradable) -> angularDamping", true)]
	public float angularDrag
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_forceMagnitude_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_forceMagnitude_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_forceVariation_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_forceVariation_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_distanceScale_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_distanceScale_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_linearDamping_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_linearDamping_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_angularDamping_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_angularDamping_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern EffectorSelection2D get_forceSource_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_forceSource_Injected(IntPtr _unity_self, EffectorSelection2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern EffectorSelection2D get_forceTarget_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_forceTarget_Injected(IntPtr _unity_self, EffectorSelection2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern EffectorForceMode2D get_forceMode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_forceMode_Injected(IntPtr _unity_self, EffectorForceMode2D value);
}
[NativeHeader("Modules/Physics2D/PlatformEffector2D.h")]
public class PlatformEffector2D : Effector2D
{
	public bool useOneWay
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useOneWay_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useOneWay_Injected(intPtr, value);
		}
	}

	public bool useOneWayGrouping
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useOneWayGrouping_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useOneWayGrouping_Injected(intPtr, value);
		}
	}

	public bool useSideFriction
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useSideFriction_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useSideFriction_Injected(intPtr, value);
		}
	}

	public bool useSideBounce
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useSideBounce_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useSideBounce_Injected(intPtr, value);
		}
	}

	public float surfaceArc
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_surfaceArc_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_surfaceArc_Injected(intPtr, value);
		}
	}

	public float sideArc
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_sideArc_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_sideArc_Injected(intPtr, value);
		}
	}

	public float rotationalOffset
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_rotationalOffset_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_rotationalOffset_Injected(intPtr, value);
		}
	}

	[Obsolete("PlatformEffector2D.oneWay has been obsolete. Use PlatformEffector2D.useOneWay instead (UnityUpgradable) -> useOneWay", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool oneWay
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[Obsolete("PlatformEffector2D.sideFriction has been obsolete. Use PlatformEffector2D.useSideFriction instead (UnityUpgradable) -> useSideFriction", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool sideFriction
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("PlatformEffector2D.sideBounce has been obsolete. Use PlatformEffector2D.useSideBounce instead (UnityUpgradable) -> useSideBounce", true)]
	public bool sideBounce
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("PlatformEffector2D.sideAngleVariance has been obsolete. Use PlatformEffector2D.sideArc instead (UnityUpgradable) -> sideArc", true)]
	public float sideAngleVariance
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useOneWay_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useOneWay_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useOneWayGrouping_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useOneWayGrouping_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useSideFriction_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useSideFriction_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useSideBounce_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useSideBounce_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_surfaceArc_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_surfaceArc_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_sideArc_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_sideArc_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_rotationalOffset_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_rotationalOffset_Injected(IntPtr _unity_self, float value);
}
[NativeHeader("Modules/Physics2D/SurfaceEffector2D.h")]
public class SurfaceEffector2D : Effector2D
{
	public float speed
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_speed_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_speed_Injected(intPtr, value);
		}
	}

	public float speedVariation
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_speedVariation_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_speedVariation_Injected(intPtr, value);
		}
	}

	public float forceScale
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_forceScale_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_forceScale_Injected(intPtr, value);
		}
	}

	public bool useContactForce
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useContactForce_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useContactForce_Injected(intPtr, value);
		}
	}

	public bool useFriction
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useFriction_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useFriction_Injected(intPtr, value);
		}
	}

	public bool useBounce
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_useBounce_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_useBounce_Injected(intPtr, value);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_speed_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_speed_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_speedVariation_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_speedVariation_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_forceScale_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_forceScale_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useContactForce_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useContactForce_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useFriction_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useFriction_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_useBounce_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_useBounce_Injected(IntPtr _unity_self, bool value);
}
[NativeHeader("Modules/Physics2D/PhysicsUpdateBehaviour2D.h")]
public class PhysicsUpdateBehaviour2D : Behaviour
{
}
[NativeHeader("Modules/Physics2D/ConstantForce2D.h")]
[RequireComponent(typeof(Rigidbody2D))]
public sealed class ConstantForce2D : PhysicsUpdateBehaviour2D
{
	public Vector2 force
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_force_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_force_Injected(intPtr, ref value);
		}
	}

	public Vector2 relativeForce
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_relativeForce_Injected(intPtr, out var ret);
			return ret;
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_relativeForce_Injected(intPtr, ref value);
		}
	}

	public float torque
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_torque_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_torque_Injected(intPtr, value);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_force_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_force_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_relativeForce_Injected(IntPtr _unity_self, out Vector2 ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_relativeForce_Injected(IntPtr _unity_self, [In] ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_torque_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_torque_Injected(IntPtr _unity_self, float value);
}
[NativeHeader("Modules/Physics2D/Public/PhysicsMaterial2D.h")]
public sealed class PhysicsMaterial2D : Object
{
	public float bounciness
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_bounciness_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_bounciness_Injected(intPtr, value);
		}
	}

	public float friction
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_friction_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_friction_Injected(intPtr, value);
		}
	}

	public PhysicsMaterialCombine2D frictionCombine
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_frictionCombine_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_frictionCombine_Injected(intPtr, value);
		}
	}

	public PhysicsMaterialCombine2D bounceCombine
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_bounceCombine_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_bounceCombine_Injected(intPtr, value);
		}
	}

	public PhysicsMaterial2D()
	{
		Create_Internal(this, null);
	}

	public PhysicsMaterial2D(string name)
	{
		Create_Internal(this, name);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern float GetCombinedValues(float valueA, float valueB, PhysicsMaterialCombine2D materialCombineA, PhysicsMaterialCombine2D materialCombineB);

	[NativeMethod("Create_Binding")]
	private unsafe static void Create_Internal([Writable] PhysicsMaterial2D scriptMaterial, string name)
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
					Create_Internal_Injected(scriptMaterial, ref managedSpanWrapper);
					return;
				}
			}
			Create_Internal_Injected(scriptMaterial, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Create_Internal_Injected([Writable] PhysicsMaterial2D scriptMaterial, ref ManagedSpanWrapper name);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_bounciness_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_bounciness_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_friction_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_friction_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern PhysicsMaterialCombine2D get_frictionCombine_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_frictionCombine_Injected(IntPtr _unity_self, PhysicsMaterialCombine2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern PhysicsMaterialCombine2D get_bounceCombine_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_bounceCombine_Injected(IntPtr _unity_self, PhysicsMaterialCombine2D value);
}
