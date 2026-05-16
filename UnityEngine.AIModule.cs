using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

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
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.UIModule")]
[assembly: InternalsVisibleTo("UnityEngine.RuntimeInitializeOnLoadManagerInitializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
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
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.PropertiesModule")]
[assembly: InternalsVisibleTo("UnityEngine.Physics2DModule")]
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.ARModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Tooling")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.CommonUtils")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Application")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.007")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.006")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.001")]
[assembly: InternalsVisibleTo("UnityEngine.Core.Runtime.Tests")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.008")]
[assembly: InternalsVisibleTo("Unity.Collections")]
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
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.009")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
[assembly: InternalsVisibleTo("Unity.AI.Navigation.Editor")]
[assembly: InternalsVisibleTo("Unity.AI.HeightMesh.Tests")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: InternalsVisibleTo("Unity.Subsystem.Registration")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.024")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.023")]
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
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.022")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
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
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
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
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("Unity.AI.Navigation.Updater")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine.Experimental.AI
{
	[Obsolete("The experimental PolygonId struct has been deprecated without replacement.")]
	public struct PolygonId : IEquatable<PolygonId>
	{
		internal ulong polyRef;

		public bool IsNull()
		{
			return polyRef == 0;
		}

		public static bool operator ==(PolygonId x, PolygonId y)
		{
			return x.polyRef == y.polyRef;
		}

		public static bool operator !=(PolygonId x, PolygonId y)
		{
			return x.polyRef != y.polyRef;
		}

		public override int GetHashCode()
		{
			return polyRef.GetHashCode();
		}

		public bool Equals(PolygonId rhs)
		{
			return rhs == this;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is PolygonId))
			{
				return false;
			}
			PolygonId polygonId = (PolygonId)obj;
			return polygonId == this;
		}
	}
	[Obsolete("The experimental NavMeshLocation struct has been deprecated without replacement.")]
	public struct NavMeshLocation
	{
		public PolygonId polygon { get; }

		public Vector3 position { get; }

		internal NavMeshLocation(Vector3 position, PolygonId polygon)
		{
			this.position = position;
			this.polygon = polygon;
		}
	}
	[Obsolete("The experimental PathQueryStatus struct has been deprecated without replacement.")]
	[Flags]
	public enum PathQueryStatus
	{
		Failure = int.MinValue,
		Success = 0x40000000,
		InProgress = 0x20000000,
		StatusDetailMask = 0xFFFFFF,
		WrongMagic = 1,
		WrongVersion = 2,
		OutOfMemory = 4,
		InvalidParam = 8,
		BufferTooSmall = 0x10,
		OutOfNodes = 0x20,
		PartialResult = 0x40
	}
	[Obsolete("The experimental NavMeshPolyTypes enum has been deprecated without replacement.")]
	public enum NavMeshPolyTypes
	{
		Ground,
		OffMeshConnection
	}
	[StaticAccessor("NavMeshWorldBindings", StaticAccessorType.DoubleColon)]
	[Obsolete("The experimental NavMeshWorld struct has been deprecated without replacement.")]
	public struct NavMeshWorld
	{
		internal IntPtr world;

		public bool IsValid()
		{
			return world != IntPtr.Zero;
		}

		public static NavMeshWorld GetDefaultWorld()
		{
			GetDefaultWorld_Injected(out var ret);
			return ret;
		}

		private static void AddDependencyInternal(IntPtr navmesh, JobHandle handle)
		{
			AddDependencyInternal_Injected(navmesh, ref handle);
		}

		public void AddDependency(JobHandle job)
		{
			AddDependencyInternal(world, job);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetDefaultWorld_Injected(out NavMeshWorld ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddDependencyInternal_Injected(IntPtr navmesh, [In] ref JobHandle handle);
	}
	[NativeContainer]
	[NativeHeader("Modules/AI/NavMeshExperimental.bindings.h")]
	[NativeHeader("Modules/AI/Public/NavMeshBindingTypes.h")]
	[StaticAccessor("NavMeshQueryBindings", StaticAccessorType.DoubleColon)]
	[NativeHeader("Runtime/Math/Matrix4x4.h")]
	[Obsolete("The experimental NavMeshQuery struct has been deprecated without replacement.")]
	public struct NavMeshQuery : IDisposable
	{
		[NativeDisableUnsafePtrRestriction]
		internal IntPtr m_NavMeshQuery;

		public NavMeshQuery(NavMeshWorld world, Allocator allocator, int pathNodePoolSize = 0)
		{
			m_NavMeshQuery = Create(world, pathNodePoolSize);
			UnsafeUtility.LeakRecord(m_NavMeshQuery, LeakCategory.NavMeshQuery, 0);
		}

		public void Dispose()
		{
			UnsafeUtility.LeakErase(m_NavMeshQuery, LeakCategory.NavMeshQuery);
			Destroy(m_NavMeshQuery);
			m_NavMeshQuery = IntPtr.Zero;
		}

		private static IntPtr Create(NavMeshWorld world, int nodePoolSize)
		{
			return Create_Injected(ref world, nodePoolSize);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Destroy(IntPtr navMeshQuery);

		public unsafe PathQueryStatus BeginFindPath(NavMeshLocation start, NavMeshLocation end, int areaMask = -1, NativeArray<float> costs = default(NativeArray<float>))
		{
			void* costs2 = ((costs.Length > 0) ? costs.GetUnsafePtr() : null);
			return BeginFindPath(m_NavMeshQuery, start, end, areaMask, costs2);
		}

		public PathQueryStatus UpdateFindPath(int iterations, out int iterationsPerformed)
		{
			return UpdateFindPath(m_NavMeshQuery, iterations, out iterationsPerformed);
		}

		public PathQueryStatus EndFindPath(out int pathSize)
		{
			return EndFindPath(m_NavMeshQuery, out pathSize);
		}

		public unsafe int GetPathResult(NativeSlice<PolygonId> path)
		{
			return GetPathResult(m_NavMeshQuery, path.GetUnsafePtr(), path.Length);
		}

		[ThreadSafe]
		private unsafe static PathQueryStatus BeginFindPath(IntPtr navMeshQuery, NavMeshLocation start, NavMeshLocation end, int areaMask, void* costs)
		{
			return BeginFindPath_Injected(navMeshQuery, ref start, ref end, areaMask, costs);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		private static extern PathQueryStatus UpdateFindPath(IntPtr navMeshQuery, int iterations, out int iterationsPerformed);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		private static extern PathQueryStatus EndFindPath(IntPtr navMeshQuery, out int pathSize);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		private unsafe static extern int GetPathResult(IntPtr navMeshQuery, void* path, int maxPath);

		[ThreadSafe]
		private static bool IsValidPolygon(IntPtr navMeshQuery, PolygonId polygon)
		{
			return IsValidPolygon_Injected(navMeshQuery, ref polygon);
		}

		public bool IsValid(PolygonId polygon)
		{
			return polygon.polyRef != 0L && IsValidPolygon(m_NavMeshQuery, polygon);
		}

		public bool IsValid(NavMeshLocation location)
		{
			return IsValid(location.polygon);
		}

		[ThreadSafe]
		private static int GetAgentTypeIdForPolygon(IntPtr navMeshQuery, PolygonId polygon)
		{
			return GetAgentTypeIdForPolygon_Injected(navMeshQuery, ref polygon);
		}

		public int GetAgentTypeIdForPolygon(PolygonId polygon)
		{
			return GetAgentTypeIdForPolygon(m_NavMeshQuery, polygon);
		}

		[ThreadSafe]
		private static bool IsPositionInPolygon(IntPtr navMeshQuery, Vector3 position, PolygonId polygon)
		{
			return IsPositionInPolygon_Injected(navMeshQuery, ref position, ref polygon);
		}

		[ThreadSafe]
		private static PathQueryStatus GetClosestPointOnPoly(IntPtr navMeshQuery, PolygonId polygon, Vector3 position, out Vector3 nearest)
		{
			return GetClosestPointOnPoly_Injected(navMeshQuery, ref polygon, ref position, out nearest);
		}

		public NavMeshLocation CreateLocation(Vector3 position, PolygonId polygon)
		{
			Vector3 nearest;
			PathQueryStatus closestPointOnPoly = GetClosestPointOnPoly(m_NavMeshQuery, polygon, position, out nearest);
			return ((closestPointOnPoly & PathQueryStatus.Success) != 0) ? new NavMeshLocation(nearest, polygon) : default(NavMeshLocation);
		}

		[ThreadSafe]
		private static NavMeshLocation MapLocation(IntPtr navMeshQuery, Vector3 position, Vector3 extents, int agentTypeID, int areaMask = -1)
		{
			MapLocation_Injected(navMeshQuery, ref position, ref extents, agentTypeID, areaMask, out var ret);
			return ret;
		}

		public NavMeshLocation MapLocation(Vector3 position, Vector3 extents, int agentTypeID, int areaMask = -1)
		{
			return MapLocation(m_NavMeshQuery, position, extents, agentTypeID, areaMask);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		private unsafe static extern void MoveLocations(IntPtr navMeshQuery, void* locations, void* targets, void* areaMasks, int count);

		public unsafe void MoveLocations(NativeSlice<NavMeshLocation> locations, NativeSlice<Vector3> targets, NativeSlice<int> areaMasks)
		{
			MoveLocations(m_NavMeshQuery, locations.GetUnsafePtr(), targets.GetUnsafeReadOnlyPtr(), areaMasks.GetUnsafeReadOnlyPtr(), locations.Length);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		private unsafe static extern void MoveLocationsInSameAreas(IntPtr navMeshQuery, void* locations, void* targets, int count, int areaMask);

		public unsafe void MoveLocationsInSameAreas(NativeSlice<NavMeshLocation> locations, NativeSlice<Vector3> targets, int areaMask = -1)
		{
			MoveLocationsInSameAreas(m_NavMeshQuery, locations.GetUnsafePtr(), targets.GetUnsafeReadOnlyPtr(), locations.Length, areaMask);
		}

		[ThreadSafe]
		private static NavMeshLocation MoveLocation(IntPtr navMeshQuery, NavMeshLocation location, Vector3 target, int areaMask)
		{
			MoveLocation_Injected(navMeshQuery, ref location, ref target, areaMask, out var ret);
			return ret;
		}

		public NavMeshLocation MoveLocation(NavMeshLocation location, Vector3 target, int areaMask = -1)
		{
			return MoveLocation(m_NavMeshQuery, location, target, areaMask);
		}

		[ThreadSafe]
		private static bool GetPortalPoints(IntPtr navMeshQuery, PolygonId polygon, PolygonId neighbourPolygon, out Vector3 left, out Vector3 right)
		{
			return GetPortalPoints_Injected(navMeshQuery, ref polygon, ref neighbourPolygon, out left, out right);
		}

		public bool GetPortalPoints(PolygonId polygon, PolygonId neighbourPolygon, out Vector3 left, out Vector3 right)
		{
			return GetPortalPoints(m_NavMeshQuery, polygon, neighbourPolygon, out left, out right);
		}

		[ThreadSafe]
		private static Matrix4x4 PolygonLocalToWorldMatrix(IntPtr navMeshQuery, PolygonId polygon)
		{
			PolygonLocalToWorldMatrix_Injected(navMeshQuery, ref polygon, out var ret);
			return ret;
		}

		public Matrix4x4 PolygonLocalToWorldMatrix(PolygonId polygon)
		{
			return PolygonLocalToWorldMatrix(m_NavMeshQuery, polygon);
		}

		[ThreadSafe]
		private static Matrix4x4 PolygonWorldToLocalMatrix(IntPtr navMeshQuery, PolygonId polygon)
		{
			PolygonWorldToLocalMatrix_Injected(navMeshQuery, ref polygon, out var ret);
			return ret;
		}

		public Matrix4x4 PolygonWorldToLocalMatrix(PolygonId polygon)
		{
			return PolygonWorldToLocalMatrix(m_NavMeshQuery, polygon);
		}

		[ThreadSafe]
		private static NavMeshPolyTypes GetPolygonType(IntPtr navMeshQuery, PolygonId polygon)
		{
			return GetPolygonType_Injected(navMeshQuery, ref polygon);
		}

		public NavMeshPolyTypes GetPolygonType(PolygonId polygon)
		{
			return GetPolygonType(m_NavMeshQuery, polygon);
		}

		[ThreadSafe]
		private unsafe static PathQueryStatus Raycast(IntPtr navMeshQuery, NavMeshLocation start, Vector3 targetPosition, int areaMask, void* costs, out NavMeshHit hit, void* path, out int pathCount, int maxPath)
		{
			return Raycast_Injected(navMeshQuery, ref start, ref targetPosition, areaMask, costs, out hit, path, out pathCount, maxPath);
		}

		public unsafe PathQueryStatus Raycast(out NavMeshHit hit, NavMeshLocation start, Vector3 targetPosition, int areaMask = -1, NativeArray<float> costs = default(NativeArray<float>))
		{
			void* costs2 = ((costs.Length == 32) ? costs.GetUnsafePtr() : null);
			int pathCount;
			PathQueryStatus pathQueryStatus = Raycast(m_NavMeshQuery, start, targetPosition, areaMask, costs2, out hit, null, out pathCount, 0);
			return pathQueryStatus & ~PathQueryStatus.BufferTooSmall;
		}

		public unsafe PathQueryStatus Raycast(out NavMeshHit hit, NativeSlice<PolygonId> path, out int pathCount, NavMeshLocation start, Vector3 targetPosition, int areaMask = -1, NativeArray<float> costs = default(NativeArray<float>))
		{
			void* costs2 = ((costs.Length == 32) ? costs.GetUnsafePtr() : null);
			void* ptr = ((path.Length > 0) ? path.GetUnsafePtr() : null);
			int maxPath = ((ptr != null) ? path.Length : 0);
			return Raycast(m_NavMeshQuery, start, targetPosition, areaMask, costs2, out hit, ptr, out pathCount, maxPath);
		}

		[ThreadSafe]
		private unsafe static PathQueryStatus GetEdgesAndNeighbors(IntPtr navMeshQuery, PolygonId node, int maxVerts, int maxNei, void* verts, void* neighbors, void* edgeIndices, out int vertCount, out int neighborsCount)
		{
			return GetEdgesAndNeighbors_Injected(navMeshQuery, ref node, maxVerts, maxNei, verts, neighbors, edgeIndices, out vertCount, out neighborsCount);
		}

		public unsafe PathQueryStatus GetEdgesAndNeighbors(PolygonId node, NativeSlice<Vector3> edgeVertices, NativeSlice<PolygonId> neighbors, NativeSlice<byte> edgeIndices, out int verticesCount, out int neighborsCount)
		{
			void* verts = ((edgeVertices.Length > 0) ? edgeVertices.GetUnsafePtr() : null);
			void* neighbors2 = ((neighbors.Length > 0) ? neighbors.GetUnsafePtr() : null);
			void* edgeIndices2 = ((edgeIndices.Length > 0) ? edgeIndices.GetUnsafePtr() : null);
			int length = edgeVertices.Length;
			int maxNei = ((neighbors.Length > 0) ? neighbors.Length : edgeIndices.Length);
			return GetEdgesAndNeighbors(m_NavMeshQuery, node, length, maxNei, verts, neighbors2, edgeIndices2, out verticesCount, out neighborsCount);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Create_Injected([In] ref NavMeshWorld world, int nodePoolSize);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern PathQueryStatus BeginFindPath_Injected(IntPtr navMeshQuery, [In] ref NavMeshLocation start, [In] ref NavMeshLocation end, int areaMask, void* costs);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsValidPolygon_Injected(IntPtr navMeshQuery, [In] ref PolygonId polygon);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetAgentTypeIdForPolygon_Injected(IntPtr navMeshQuery, [In] ref PolygonId polygon);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsPositionInPolygon_Injected(IntPtr navMeshQuery, [In] ref Vector3 position, [In] ref PolygonId polygon);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern PathQueryStatus GetClosestPointOnPoly_Injected(IntPtr navMeshQuery, [In] ref PolygonId polygon, [In] ref Vector3 position, out Vector3 nearest);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void MapLocation_Injected(IntPtr navMeshQuery, [In] ref Vector3 position, [In] ref Vector3 extents, int agentTypeID, int areaMask, out NavMeshLocation ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void MoveLocation_Injected(IntPtr navMeshQuery, [In] ref NavMeshLocation location, [In] ref Vector3 target, int areaMask, out NavMeshLocation ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetPortalPoints_Injected(IntPtr navMeshQuery, [In] ref PolygonId polygon, [In] ref PolygonId neighbourPolygon, out Vector3 left, out Vector3 right);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PolygonLocalToWorldMatrix_Injected(IntPtr navMeshQuery, [In] ref PolygonId polygon, out Matrix4x4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PolygonWorldToLocalMatrix_Injected(IntPtr navMeshQuery, [In] ref PolygonId polygon, out Matrix4x4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern NavMeshPolyTypes GetPolygonType_Injected(IntPtr navMeshQuery, [In] ref PolygonId polygon);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern PathQueryStatus Raycast_Injected(IntPtr navMeshQuery, [In] ref NavMeshLocation start, [In] ref Vector3 targetPosition, int areaMask, void* costs, out NavMeshHit hit, void* path, out int pathCount, int maxPath);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern PathQueryStatus GetEdgesAndNeighbors_Injected(IntPtr navMeshQuery, [In] ref PolygonId node, int maxVerts, int maxNei, void* verts, void* neighbors, void* edgeIndices, out int vertCount, out int neighborsCount);
	}
}
namespace UnityEngine.AI
{
	[StaticAccessor("NavMeshBuilderBindings", StaticAccessorType.DoubleColon)]
	[NativeHeader("Modules/AI/Builder/NavMeshBuilder.bindings.h")]
	public static class NavMeshBuilder
	{
		public static void CollectSources(Bounds includedWorldBounds, int includedLayerMask, NavMeshCollectGeometry geometry, int defaultArea, bool generateLinksByDefault, List<NavMeshBuildMarkup> markups, bool includeOnlyMarkedObjects, List<NavMeshBuildSource> results)
		{
			if (markups == null)
			{
				throw new ArgumentNullException("markups");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			includedWorldBounds.extents = Vector3.Max(includedWorldBounds.extents, 0.001f * Vector3.one);
			NavMeshBuildSource[] collection = CollectSourcesInternal(includedLayerMask, includedWorldBounds, null, useBounds: true, geometry, defaultArea, generateLinksByDefault, markups.ToArray(), includeOnlyMarkedObjects);
			results.Clear();
			results.AddRange(collection);
		}

		public static void CollectSources(Bounds includedWorldBounds, int includedLayerMask, NavMeshCollectGeometry geometry, int defaultArea, List<NavMeshBuildMarkup> markups, List<NavMeshBuildSource> results)
		{
			CollectSources(includedWorldBounds, includedLayerMask, geometry, defaultArea, generateLinksByDefault: false, markups, includeOnlyMarkedObjects: false, results);
		}

		public static void CollectSources(Transform root, int includedLayerMask, NavMeshCollectGeometry geometry, int defaultArea, bool generateLinksByDefault, List<NavMeshBuildMarkup> markups, bool includeOnlyMarkedObjects, List<NavMeshBuildSource> results)
		{
			if (markups == null)
			{
				throw new ArgumentNullException("markups");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			NavMeshBuildSource[] collection = CollectSourcesInternal(includedLayerMask, default(Bounds), root, useBounds: false, geometry, defaultArea, generateLinksByDefault, markups.ToArray(), includeOnlyMarkedObjects);
			results.Clear();
			results.AddRange(collection);
		}

		public static void CollectSources(Transform root, int includedLayerMask, NavMeshCollectGeometry geometry, int defaultArea, List<NavMeshBuildMarkup> markups, List<NavMeshBuildSource> results)
		{
			CollectSources(root, includedLayerMask, geometry, defaultArea, generateLinksByDefault: false, markups, includeOnlyMarkedObjects: false, results);
		}

		private unsafe static NavMeshBuildSource[] CollectSourcesInternal(int includedLayerMask, Bounds includedWorldBounds, Transform root, bool useBounds, NavMeshCollectGeometry geometry, int defaultArea, bool generateLinksByDefault, NavMeshBuildMarkup[] markups, bool includeOnlyMarkedObjects)
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			NavMeshBuildSource[] result;
			try
			{
				IntPtr root2 = Object.MarshalledUnityObject.Marshal(root);
				Span<NavMeshBuildMarkup> span = new Span<NavMeshBuildMarkup>(markups);
				fixed (NavMeshBuildMarkup* begin = span)
				{
					ManagedSpanWrapper markups2 = new ManagedSpanWrapper(begin, span.Length);
					CollectSourcesInternal_Injected(includedLayerMask, ref includedWorldBounds, root2, useBounds, geometry, defaultArea, generateLinksByDefault, ref markups2, includeOnlyMarkedObjects, out ret);
				}
			}
			finally
			{
				NavMeshBuildSource[] array = default(NavMeshBuildSource[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}

		public static NavMeshData BuildNavMeshData(NavMeshBuildSettings buildSettings, List<NavMeshBuildSource> sources, Bounds localBounds, Vector3 position, Quaternion rotation)
		{
			if (sources == null)
			{
				throw new ArgumentNullException("sources");
			}
			NavMeshData navMeshData = new NavMeshData(buildSettings.agentTypeID)
			{
				position = position,
				rotation = rotation
			};
			UpdateNavMeshDataListInternal(navMeshData, buildSettings, sources, localBounds);
			return navMeshData;
		}

		public static bool UpdateNavMeshData(NavMeshData data, NavMeshBuildSettings buildSettings, List<NavMeshBuildSource> sources, Bounds localBounds)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (sources == null)
			{
				throw new ArgumentNullException("sources");
			}
			return UpdateNavMeshDataListInternal(data, buildSettings, sources, localBounds);
		}

		private static bool UpdateNavMeshDataListInternal(NavMeshData data, NavMeshBuildSettings buildSettings, object sources, Bounds localBounds)
		{
			return UpdateNavMeshDataListInternal_Injected(Object.MarshalledUnityObject.Marshal(data), ref buildSettings, sources, ref localBounds);
		}

		public static AsyncOperation UpdateNavMeshDataAsync(NavMeshData data, NavMeshBuildSettings buildSettings, List<NavMeshBuildSource> sources, Bounds localBounds)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (sources == null)
			{
				throw new ArgumentNullException("sources");
			}
			return UpdateNavMeshDataAsyncListInternal(data, buildSettings, sources, localBounds);
		}

		[NativeHeader("Modules/AI/NavMeshManager.h")]
		[StaticAccessor("GetNavMeshManager().GetNavMeshBuildManager()", StaticAccessorType.Arrow)]
		[NativeMethod("Purge")]
		public static void Cancel(NavMeshData data)
		{
			Cancel_Injected(Object.MarshalledUnityObject.Marshal(data));
		}

		private static AsyncOperation UpdateNavMeshDataAsyncListInternal(NavMeshData data, NavMeshBuildSettings buildSettings, object sources, Bounds localBounds)
		{
			IntPtr intPtr = UpdateNavMeshDataAsyncListInternal_Injected(Object.MarshalledUnityObject.Marshal(data), ref buildSettings, sources, ref localBounds);
			return (intPtr == (IntPtr)0) ? null : AsyncOperation.BindingsMarshaller.ConvertToManaged(intPtr);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CollectSourcesInternal_Injected(int includedLayerMask, [In] ref Bounds includedWorldBounds, IntPtr root, bool useBounds, NavMeshCollectGeometry geometry, int defaultArea, bool generateLinksByDefault, ref ManagedSpanWrapper markups, bool includeOnlyMarkedObjects, out BlittableArrayWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool UpdateNavMeshDataListInternal_Injected(IntPtr data, [In] ref NavMeshBuildSettings buildSettings, object sources, [In] ref Bounds localBounds);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Cancel_Injected(IntPtr data);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr UpdateNavMeshDataAsyncListInternal_Injected(IntPtr data, [In] ref NavMeshBuildSettings buildSettings, object sources, [In] ref Bounds localBounds);
	}
	[MovedFrom("UnityEngine")]
	public enum ObstacleAvoidanceType
	{
		NoObstacleAvoidance,
		LowQualityObstacleAvoidance,
		MedQualityObstacleAvoidance,
		GoodQualityObstacleAvoidance,
		HighQualityObstacleAvoidance
	}
	[MovedFrom("UnityEngine")]
	[NativeHeader("Modules/AI/Components/NavMeshAgent.bindings.h")]
	[NativeHeader("Modules/AI/NavMesh/NavMesh.bindings.h")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ai.navigation@2.0/manual/NavMeshAgent.html")]
	public sealed class NavMeshAgent : Behaviour
	{
		public Vector3 destination
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_destination_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_destination_Injected(intPtr, ref value);
			}
		}

		public float stoppingDistance
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_stoppingDistance_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_stoppingDistance_Injected(intPtr, value);
			}
		}

		public Vector3 velocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_velocity_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_velocity_Injected(intPtr, ref value);
			}
		}

		[NativeProperty("Position")]
		public Vector3 nextPosition
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_nextPosition_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_nextPosition_Injected(intPtr, ref value);
			}
		}

		public Vector3 steeringTarget
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_steeringTarget_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public Vector3 desiredVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_desiredVelocity_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public float remainingDistance
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_remainingDistance_Injected(intPtr);
			}
		}

		public float baseOffset
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_baseOffset_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_baseOffset_Injected(intPtr, value);
			}
		}

		public bool isOnOffMeshLink
		{
			[NativeName("IsOnOffMeshLink")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isOnOffMeshLink_Injected(intPtr);
			}
		}

		public OffMeshLinkData currentOffMeshLinkData => GetCurrentOffMeshLinkDataInternal();

		public OffMeshLinkData nextOffMeshLinkData => GetNextOffMeshLinkDataInternal();

		public bool autoTraverseOffMeshLink
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_autoTraverseOffMeshLink_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_autoTraverseOffMeshLink_Injected(intPtr, value);
			}
		}

		public bool autoBraking
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_autoBraking_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_autoBraking_Injected(intPtr, value);
			}
		}

		public bool autoRepath
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_autoRepath_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_autoRepath_Injected(intPtr, value);
			}
		}

		public bool hasPath
		{
			[NativeName("HasPath")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_hasPath_Injected(intPtr);
			}
		}

		public bool pathPending
		{
			[NativeName("PathPending")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_pathPending_Injected(intPtr);
			}
		}

		public bool isPathStale
		{
			[NativeName("IsPathStale")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isPathStale_Injected(intPtr);
			}
		}

		public NavMeshPathStatus pathStatus
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_pathStatus_Injected(intPtr);
			}
		}

		[NativeProperty("EndPositionOfCurrentPath")]
		public Vector3 pathEndPosition
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_pathEndPosition_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public bool isStopped
		{
			[FreeFunction("NavMeshAgentScriptBindings::GetIsStopped", HasExplicitThis = true)]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isStopped_Injected(intPtr);
			}
			[FreeFunction("NavMeshAgentScriptBindings::SetIsStopped", HasExplicitThis = true)]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_isStopped_Injected(intPtr, value);
			}
		}

		public NavMeshPath path
		{
			get
			{
				NavMeshPath result = new NavMeshPath();
				CopyPathTo(result);
				return result;
			}
			set
			{
				if (value == null)
				{
					throw new NullReferenceException();
				}
				SetPath(value);
			}
		}

		public Object navMeshOwner => GetOwnerInternal();

		public int agentTypeID
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_agentTypeID_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_agentTypeID_Injected(intPtr, value);
			}
		}

		[Obsolete("Use areaMask instead.")]
		public int walkableMask
		{
			get
			{
				return areaMask;
			}
			set
			{
				areaMask = value;
			}
		}

		public int areaMask
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_areaMask_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_areaMask_Injected(intPtr, value);
			}
		}

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

		public float angularSpeed
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_angularSpeed_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_angularSpeed_Injected(intPtr, value);
			}
		}

		public float acceleration
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_acceleration_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_acceleration_Injected(intPtr, value);
			}
		}

		public bool updatePosition
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_updatePosition_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_updatePosition_Injected(intPtr, value);
			}
		}

		public bool updateRotation
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_updateRotation_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_updateRotation_Injected(intPtr, value);
			}
		}

		public bool updateUpAxis
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_updateUpAxis_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_updateUpAxis_Injected(intPtr, value);
			}
		}

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

		public float height
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_height_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_height_Injected(intPtr, value);
			}
		}

		public ObstacleAvoidanceType obstacleAvoidanceType
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_obstacleAvoidanceType_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_obstacleAvoidanceType_Injected(intPtr, value);
			}
		}

		public int avoidancePriority
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_avoidancePriority_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_avoidancePriority_Injected(intPtr, value);
			}
		}

		public bool isOnNavMesh
		{
			[NativeName("InCrowdSystem")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isOnNavMesh_Injected(intPtr);
			}
		}

		public bool SetDestination(Vector3 target)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetDestination_Injected(intPtr, ref target);
		}

		public void ActivateCurrentOffMeshLink(bool activated)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ActivateCurrentOffMeshLink_Injected(intPtr, activated);
		}

		[FreeFunction("NavMeshAgentScriptBindings::GetCurrentOffMeshLinkDataInternal", HasExplicitThis = true)]
		internal OffMeshLinkData GetCurrentOffMeshLinkDataInternal()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetCurrentOffMeshLinkDataInternal_Injected(intPtr, out var ret);
			return ret;
		}

		[FreeFunction("NavMeshAgentScriptBindings::GetNextOffMeshLinkDataInternal", HasExplicitThis = true)]
		internal OffMeshLinkData GetNextOffMeshLinkDataInternal()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetNextOffMeshLinkDataInternal_Injected(intPtr, out var ret);
			return ret;
		}

		public void CompleteOffMeshLink()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			CompleteOffMeshLink_Injected(intPtr);
		}

		public bool Warp(Vector3 newPosition)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Warp_Injected(intPtr, ref newPosition);
		}

		public void Move(Vector3 offset)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Move_Injected(intPtr, ref offset);
		}

		[Obsolete("Set isStopped to true instead.")]
		public void Stop()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Stop_Injected(intPtr);
		}

		[Obsolete("Set isStopped to true instead.")]
		public void Stop(bool stopUpdates)
		{
			Stop();
		}

		[Obsolete("Set isStopped to false instead.")]
		public void Resume()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Resume_Injected(intPtr);
		}

		public void ResetPath()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ResetPath_Injected(intPtr);
		}

		public bool SetPath([NotNull] NavMeshPath path)
		{
			if (path == null)
			{
				ThrowHelper.ThrowArgumentNullException(path, "path");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = NavMeshPath.BindingsMarshaller.ConvertToNative(path);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(path, "path");
			}
			return SetPath_Injected(intPtr, intPtr2);
		}

		[NativeMethod("CopyPath")]
		internal void CopyPathTo([NotNull] NavMeshPath path)
		{
			if (path == null)
			{
				ThrowHelper.ThrowArgumentNullException(path, "path");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = NavMeshPath.BindingsMarshaller.ConvertToNative(path);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(path, "path");
			}
			CopyPathTo_Injected(intPtr, intPtr2);
		}

		[NativeName("DistanceToEdge")]
		public bool FindClosestEdge(out NavMeshHit hit)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return FindClosestEdge_Injected(intPtr, out hit);
		}

		public bool Raycast(Vector3 targetPosition, out NavMeshHit hit)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Raycast_Injected(intPtr, ref targetPosition, out hit);
		}

		public bool CalculatePath(Vector3 targetPosition, NavMeshPath path)
		{
			path.ClearCorners();
			return CalculatePathInternal(targetPosition, path);
		}

		[FreeFunction("NavMeshAgentScriptBindings::CalculatePathInternal", HasExplicitThis = true)]
		private bool CalculatePathInternal(Vector3 targetPosition, [NotNull] NavMeshPath path)
		{
			if (path == null)
			{
				ThrowHelper.ThrowArgumentNullException(path, "path");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = NavMeshPath.BindingsMarshaller.ConvertToNative(path);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(path, "path");
			}
			return CalculatePathInternal_Injected(intPtr, ref targetPosition, intPtr2);
		}

		public bool SamplePathPosition(int areaMask, float maxDistance, out NavMeshHit hit)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SamplePathPosition_Injected(intPtr, areaMask, maxDistance, out hit);
		}

		[NativeMethod("SetAreaCost")]
		[Obsolete("Use SetAreaCost instead.")]
		public void SetLayerCost(int layer, float cost)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetLayerCost_Injected(intPtr, layer, cost);
		}

		[Obsolete("Use GetAreaCost instead.")]
		[NativeMethod("GetAreaCost")]
		public float GetLayerCost(int layer)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetLayerCost_Injected(intPtr, layer);
		}

		public void SetAreaCost(int areaIndex, float areaCost)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetAreaCost_Injected(intPtr, areaIndex, areaCost);
		}

		public float GetAreaCost(int areaIndex)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAreaCost_Injected(intPtr, areaIndex);
		}

		[NativeName("GetCurrentPolygonOwner")]
		private Object GetOwnerInternal()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Object>(GetOwnerInternal_Injected(intPtr));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetDestination_Injected(IntPtr _unity_self, [In] ref Vector3 target);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_destination_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_destination_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_stoppingDistance_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_stoppingDistance_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_velocity_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_velocity_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_nextPosition_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_nextPosition_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_steeringTarget_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_desiredVelocity_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_remainingDistance_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_baseOffset_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_baseOffset_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isOnOffMeshLink_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ActivateCurrentOffMeshLink_Injected(IntPtr _unity_self, bool activated);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetCurrentOffMeshLinkDataInternal_Injected(IntPtr _unity_self, out OffMeshLinkData ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetNextOffMeshLinkDataInternal_Injected(IntPtr _unity_self, out OffMeshLinkData ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CompleteOffMeshLink_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_autoTraverseOffMeshLink_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_autoTraverseOffMeshLink_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_autoBraking_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_autoBraking_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_autoRepath_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_autoRepath_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_hasPath_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_pathPending_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isPathStale_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern NavMeshPathStatus get_pathStatus_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_pathEndPosition_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Warp_Injected(IntPtr _unity_self, [In] ref Vector3 newPosition);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Move_Injected(IntPtr _unity_self, [In] ref Vector3 offset);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Stop_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Resume_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isStopped_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_isStopped_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResetPath_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetPath_Injected(IntPtr _unity_self, IntPtr path);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CopyPathTo_Injected(IntPtr _unity_self, IntPtr path);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool FindClosestEdge_Injected(IntPtr _unity_self, out NavMeshHit hit);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Raycast_Injected(IntPtr _unity_self, [In] ref Vector3 targetPosition, out NavMeshHit hit);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CalculatePathInternal_Injected(IntPtr _unity_self, [In] ref Vector3 targetPosition, IntPtr path);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SamplePathPosition_Injected(IntPtr _unity_self, int areaMask, float maxDistance, out NavMeshHit hit);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLayerCost_Injected(IntPtr _unity_self, int layer, float cost);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetLayerCost_Injected(IntPtr _unity_self, int layer);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetAreaCost_Injected(IntPtr _unity_self, int areaIndex, float areaCost);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetAreaCost_Injected(IntPtr _unity_self, int areaIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_agentTypeID_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_agentTypeID_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetOwnerInternal_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_areaMask_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_areaMask_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_speed_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_speed_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_angularSpeed_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_angularSpeed_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_acceleration_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_acceleration_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_updatePosition_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_updatePosition_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_updateRotation_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_updateRotation_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_updateUpAxis_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_updateUpAxis_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_radius_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_radius_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_height_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_height_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ObstacleAvoidanceType get_obstacleAvoidanceType_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_obstacleAvoidanceType_Injected(IntPtr _unity_self, ObstacleAvoidanceType value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_avoidancePriority_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_avoidancePriority_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isOnNavMesh_Injected(IntPtr _unity_self);
	}
	[MovedFrom("UnityEngine")]
	public enum NavMeshObstacleShape
	{
		Capsule,
		Box
	}
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ai.navigation@2.0/manual/NavMeshObstacle.html")]
	[NativeHeader("Modules/AI/Components/NavMeshObstacle.bindings.h")]
	[MovedFrom("UnityEngine")]
	public sealed class NavMeshObstacle : Behaviour
	{
		public float height
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_height_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_height_Injected(intPtr, value);
			}
		}

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

		public Vector3 velocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_velocity_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_velocity_Injected(intPtr, ref value);
			}
		}

		public bool carving
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_carving_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_carving_Injected(intPtr, value);
			}
		}

		public bool carveOnlyStationary
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_carveOnlyStationary_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_carveOnlyStationary_Injected(intPtr, value);
			}
		}

		[NativeProperty("MoveThreshold")]
		public float carvingMoveThreshold
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_carvingMoveThreshold_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_carvingMoveThreshold_Injected(intPtr, value);
			}
		}

		[NativeProperty("TimeToStationary")]
		public float carvingTimeToStationary
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_carvingTimeToStationary_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_carvingTimeToStationary_Injected(intPtr, value);
			}
		}

		public NavMeshObstacleShape shape
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_shape_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_shape_Injected(intPtr, value);
			}
		}

		public Vector3 center
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_center_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_center_Injected(intPtr, ref value);
			}
		}

		public Vector3 size
		{
			[FreeFunction("NavMeshObstacleScriptBindings::GetSize", HasExplicitThis = true)]
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
			[FreeFunction("NavMeshObstacleScriptBindings::SetSize", HasExplicitThis = true)]
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

		[FreeFunction("NavMeshObstacleScriptBindings::FitExtents", HasExplicitThis = true)]
		internal void FitExtents()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			FitExtents_Injected(intPtr);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_height_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_height_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_radius_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_radius_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_velocity_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_velocity_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_carving_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_carving_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_carveOnlyStationary_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_carveOnlyStationary_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_carvingMoveThreshold_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_carvingMoveThreshold_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_carvingTimeToStationary_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_carvingTimeToStationary_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern NavMeshObstacleShape get_shape_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_shape_Injected(IntPtr _unity_self, NavMeshObstacleShape value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_center_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_center_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_size_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_size_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FitExtents_Injected(IntPtr _unity_self);
	}
	[MovedFrom("UnityEngine")]
	public enum OffMeshLinkType
	{
		LinkTypeManual,
		LinkTypeDropDown,
		LinkTypeJumpAcross
	}
	[MovedFrom("UnityEngine")]
	[NativeHeader("Modules/AI/Components/OffMeshLink.bindings.h")]
	public struct OffMeshLinkData
	{
		internal int m_Valid;

		internal int m_Activated;

		internal int m_InstanceID;

		internal OffMeshLinkType m_LinkType;

		internal Vector3 m_StartPos;

		internal Vector3 m_EndPos;

		public bool valid => m_Valid != 0;

		public bool activated => m_Activated != 0;

		public OffMeshLinkType linkType => m_LinkType;

		public Vector3 startPos => m_StartPos;

		public Vector3 endPos => m_EndPos;

		public Object owner => GetLinkOwnerInternal(m_InstanceID);

		[Obsolete("offMeshLink has been deprecated. Use 'owner' instead.")]
		public OffMeshLink offMeshLink => GetOffMeshLinkInternal(m_InstanceID);

		[FreeFunction("OffMeshLinkScriptBindings::GetLinkOwnerInternal")]
		private static Object GetLinkOwnerInternal(int instanceID)
		{
			return Unmarshal.UnmarshalUnityObject<Object>(GetLinkOwnerInternal_Injected(instanceID));
		}

		[FreeFunction("OffMeshLinkScriptBindings::GetOffMeshLinkInternal")]
		private static OffMeshLink GetOffMeshLinkInternal(int instanceID)
		{
			return Unmarshal.UnmarshalUnityObject<OffMeshLink>(GetOffMeshLinkInternal_Injected(instanceID));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetLinkOwnerInternal_Injected(int instanceID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetOffMeshLinkInternal_Injected(int instanceID);
	}
	[MovedFrom("UnityEngine")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ai.navigation@2.0/manual/OffMeshLink.html")]
	[Obsolete("The OffMeshLink component is no longer supported and will be removed. Use NavMeshLink instead.")]
	public sealed class OffMeshLink : Behaviour
	{
		[Obsolete("activated has been deprecated together with the class. Declare the object as NavMeshLink and use activated as before.")]
		public bool activated
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_activated_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_activated_Injected(intPtr, value);
			}
		}

		[Obsolete("occupied has been deprecated together with the class. Declare the object as NavMeshLink and use occupied as before.")]
		public bool occupied
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_occupied_Injected(intPtr);
			}
		}

		[Obsolete("costOverride has been deprecated together with the class. Declare the object as NavMeshLink and use costModifier instead.")]
		public float costOverride
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_costOverride_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_costOverride_Injected(intPtr, value);
			}
		}

		[Obsolete("biDirectional has been deprecated together with the class. Declare the object as NavMeshLink and use bidirectional instead.")]
		public bool biDirectional
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_biDirectional_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_biDirectional_Injected(intPtr, value);
			}
		}

		[Obsolete("navMeshLayer has been deprecated together with the class. Declare the object as NavMeshLink and use area instead. (UnityUpgradable) -> area")]
		public int navMeshLayer
		{
			get
			{
				return area;
			}
			set
			{
				area = value;
			}
		}

		[Obsolete("area has been deprecated together with the class. Declare the object as NavMeshLink and use area as before.")]
		public int area
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_area_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_area_Injected(intPtr, value);
			}
		}

		[Obsolete("autoUpdatePositions has been deprecated together with the class. Declare the object as NavMeshLink and use autoUpdate instead.")]
		public bool autoUpdatePositions
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_autoUpdatePositions_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_autoUpdatePositions_Injected(intPtr, value);
			}
		}

		[Obsolete("startTransform has been deprecated together with the class. Declare the object as NavMeshLink and use startTransform as before.")]
		public Transform startTransform
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<Transform>(get_startTransform_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_startTransform_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		[Obsolete("endTransform has been deprecated together with the class. Declare the object as NavMeshLink and use endTransform as before.")]
		public Transform endTransform
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<Transform>(get_endTransform_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_endTransform_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		[Obsolete("UpdatePositions() has been deprecated together with the class. Declare the object as NavMeshLink and use UpdateLink() instead.")]
		public void UpdatePositions()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			UpdatePositions_Injected(intPtr);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_activated_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_activated_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_occupied_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_costOverride_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_costOverride_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_biDirectional_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_biDirectional_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UpdatePositions_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_area_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_area_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_autoUpdatePositions_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_autoUpdatePositions_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_startTransform_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_startTransform_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_endTransform_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_endTransform_Injected(IntPtr _unity_self, IntPtr value);
	}
	[MovedFrom("UnityEngine")]
	public struct NavMeshHit
	{
		private Vector3 m_Position;

		private Vector3 m_Normal;

		private float m_Distance;

		private int m_Mask;

		private int m_Hit;

		public Vector3 position
		{
			get
			{
				return m_Position;
			}
			set
			{
				m_Position = value;
			}
		}

		public Vector3 normal
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

		public int mask
		{
			get
			{
				return m_Mask;
			}
			set
			{
				m_Mask = value;
			}
		}

		public bool hit
		{
			get
			{
				return m_Hit != 0;
			}
			set
			{
				m_Hit = (value ? 1 : 0);
			}
		}
	}
	[MovedFrom("UnityEngine")]
	[UsedByNativeCode]
	public struct NavMeshTriangulation
	{
		public Vector3[] vertices;

		public int[] indices;

		public int[] areas;

		[Obsolete("Use areas instead.")]
		public int[] layers => areas;
	}
	[NativeHeader("Modules/AI/NavMesh/NavMesh.bindings.h")]
	public sealed class NavMeshData : Object
	{
		public Bounds sourceBounds
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_sourceBounds_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public Vector3 position
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

		public Quaternion rotation
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_rotation_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rotation_Injected(intPtr, ref value);
			}
		}

		internal bool hasHeightMeshData
		{
			[NativeMethod("HasHeightMeshData")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_hasHeightMeshData_Injected(intPtr);
			}
		}

		internal NavMeshBuildSettings buildSettings
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_buildSettings_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public NavMeshData()
		{
			Internal_Create(this, 0);
		}

		public NavMeshData(int agentTypeID)
		{
			Internal_Create(this, agentTypeID);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("NavMeshDataBindings", StaticAccessorType.DoubleColon)]
		private static extern void Internal_Create([Writable] NavMeshData mono, int agentTypeID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_sourceBounds_Injected(IntPtr _unity_self, out Bounds ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_position_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_position_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_rotation_Injected(IntPtr _unity_self, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rotation_Injected(IntPtr _unity_self, [In] ref Quaternion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_hasHeightMeshData_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_buildSettings_Injected(IntPtr _unity_self, out NavMeshBuildSettings ret);
	}
	public struct NavMeshDataInstance
	{
		public bool valid => id != 0 && NavMesh.IsValidNavMeshDataHandle(id);

		internal int id { get; set; }

		public Object owner
		{
			get
			{
				return NavMesh.InternalGetOwner(id);
			}
			set
			{
				int ownerID = ((value != null) ? value.GetInstanceID() : 0);
				if (!NavMesh.InternalSetOwner(id, ownerID))
				{
					Debug.LogError("Cannot set 'owner' on an invalid NavMeshDataInstance");
				}
			}
		}

		public void Remove()
		{
			NavMesh.RemoveNavMeshDataInternal(id);
		}
	}
	public struct NavMeshLinkData
	{
		private Vector3 m_StartPosition;

		private Vector3 m_EndPosition;

		private float m_CostModifier;

		private int m_Bidirectional;

		private float m_Width;

		private int m_Area;

		private int m_AgentTypeID;

		public Vector3 startPosition
		{
			get
			{
				return m_StartPosition;
			}
			set
			{
				m_StartPosition = value;
			}
		}

		public Vector3 endPosition
		{
			get
			{
				return m_EndPosition;
			}
			set
			{
				m_EndPosition = value;
			}
		}

		public float costModifier
		{
			get
			{
				return m_CostModifier;
			}
			set
			{
				m_CostModifier = value;
			}
		}

		public bool bidirectional
		{
			get
			{
				return m_Bidirectional != 0;
			}
			set
			{
				m_Bidirectional = (value ? 1 : 0);
			}
		}

		public float width
		{
			get
			{
				return m_Width;
			}
			set
			{
				m_Width = value;
			}
		}

		public int area
		{
			get
			{
				return m_Area;
			}
			set
			{
				m_Area = value;
			}
		}

		public int agentTypeID
		{
			get
			{
				return m_AgentTypeID;
			}
			set
			{
				m_AgentTypeID = value;
			}
		}
	}
	public struct NavMeshLinkInstance
	{
		internal int id { get; set; }

		[Obsolete("valid has been deprecated. Use NavMesh.IsLinkValid() instead.")]
		public bool valid => NavMesh.IsValidLinkHandle(id);

		[Obsolete("owner has been deprecated. Use NavMesh.GetLinkOwner() and NavMesh.SetLinkOwner() instead.")]
		public Object owner
		{
			get
			{
				return NavMesh.InternalGetLinkOwner(id);
			}
			set
			{
				int ownerID = ((value != null) ? value.GetInstanceID() : 0);
				if (!NavMesh.InternalSetLinkOwner(id, ownerID))
				{
					Debug.LogError("Cannot set 'owner' on an invalid NavMeshLinkInstance");
				}
			}
		}

		[Obsolete("Remove() has been deprecated. Use NavMesh.RemoveLink() instead.")]
		public void Remove()
		{
			NavMesh.RemoveLinkInternal(id);
		}
	}
	public struct NavMeshQueryFilter
	{
		private const int k_AreaCostElementCount = 32;

		internal float[] costs { get; private set; }

		public int areaMask { get; set; }

		public int agentTypeID { get; set; }

		public float GetAreaCost(int areaIndex)
		{
			if (costs == null)
			{
				if (areaIndex < 0 || areaIndex >= 32)
				{
					string message = $"The valid range is [0:{31}]";
					throw new IndexOutOfRangeException(message);
				}
				return 1f;
			}
			return costs[areaIndex];
		}

		public void SetAreaCost(int areaIndex, float cost)
		{
			if (costs == null)
			{
				costs = new float[32];
				for (int i = 0; i < 32; i++)
				{
					costs[i] = 1f;
				}
			}
			costs[areaIndex] = cost;
		}
	}
	[NativeHeader("Modules/AI/NavMeshManager.h")]
	[NativeHeader("Modules/AI/NavMesh/NavMesh.bindings.h")]
	[StaticAccessor("NavMeshBindings", StaticAccessorType.DoubleColon)]
	[MovedFrom("UnityEngine")]
	public static class NavMesh
	{
		public delegate void OnNavMeshPreUpdate();

		public const int AllAreas = -1;

		public static OnNavMeshPreUpdate onPreUpdate;

		[StaticAccessor("GetNavMeshManager()")]
		public static extern float avoidancePredictionTime
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		[StaticAccessor("GetNavMeshManager()")]
		public static extern int pathfindingIterationsPerFrame
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void ClearPreUpdateListeners()
		{
			onPreUpdate = null;
		}

		[RequiredByNativeCode]
		private static void Internal_CallOnNavMeshPreUpdate()
		{
			if (onPreUpdate != null)
			{
				onPreUpdate();
			}
		}

		public static bool Raycast(Vector3 sourcePosition, Vector3 targetPosition, out NavMeshHit hit, int areaMask)
		{
			return Raycast_Injected(ref sourcePosition, ref targetPosition, out hit, areaMask);
		}

		public static bool CalculatePath(Vector3 sourcePosition, Vector3 targetPosition, int areaMask, NavMeshPath path)
		{
			path.ClearCorners();
			return CalculatePathInternal(sourcePosition, targetPosition, areaMask, path);
		}

		private static bool CalculatePathInternal(Vector3 sourcePosition, Vector3 targetPosition, int areaMask, NavMeshPath path)
		{
			return CalculatePathInternal_Injected(ref sourcePosition, ref targetPosition, areaMask, (path == null) ? ((IntPtr)0) : NavMeshPath.BindingsMarshaller.ConvertToNative(path));
		}

		public static bool FindClosestEdge(Vector3 sourcePosition, out NavMeshHit hit, int areaMask)
		{
			return FindClosestEdge_Injected(ref sourcePosition, out hit, areaMask);
		}

		public static bool SamplePosition(Vector3 sourcePosition, out NavMeshHit hit, float maxDistance, int areaMask)
		{
			return SamplePosition_Injected(ref sourcePosition, out hit, maxDistance, areaMask);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[Obsolete("Use SetAreaCost instead.")]
		[NativeName("SetAreaCost")]
		[StaticAccessor("GetNavMeshProjectSettings()")]
		public static extern void SetLayerCost(int layer, float cost);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[Obsolete("Use GetAreaCost instead.")]
		[StaticAccessor("GetNavMeshProjectSettings()")]
		[NativeName("GetAreaCost")]
		public static extern float GetLayerCost(int layer);

		[Obsolete("Use GetAreaFromName instead.")]
		[StaticAccessor("GetNavMeshProjectSettings()")]
		[NativeName("GetAreaFromName")]
		public unsafe static int GetNavMeshLayerFromName(string layerName)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(layerName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(layerName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetNavMeshLayerFromName_Injected(ref managedSpanWrapper);
					}
				}
				return GetNavMeshLayerFromName_Injected(ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("GetNavMeshProjectSettings()")]
		[NativeName("SetAreaCost")]
		public static extern void SetAreaCost(int areaIndex, float cost);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeName("GetAreaCost")]
		[StaticAccessor("GetNavMeshProjectSettings()")]
		public static extern float GetAreaCost(int areaIndex);

		[NativeName("GetAreaFromName")]
		[StaticAccessor("GetNavMeshProjectSettings()")]
		public unsafe static int GetAreaFromName(string areaName)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(areaName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(areaName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetAreaFromName_Injected(ref managedSpanWrapper);
					}
				}
				return GetAreaFromName_Injected(ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("GetNavMeshProjectSettings()")]
		[NativeName("GetAreaNames")]
		public static extern string[] GetAreaNames();

		public static NavMeshTriangulation CalculateTriangulation()
		{
			CalculateTriangulation_Injected(out var ret);
			return ret;
		}

		[Obsolete("use NavMesh.CalculateTriangulation() instead.")]
		public static void Triangulate(out Vector3[] vertices, out int[] indices)
		{
			NavMeshTriangulation navMeshTriangulation = CalculateTriangulation();
			vertices = navMeshTriangulation.vertices;
			indices = navMeshTriangulation.indices;
		}

		[Obsolete("AddOffMeshLinks has no effect and is deprecated.")]
		public static void AddOffMeshLinks()
		{
		}

		[Obsolete("RestoreNavMesh has no effect and is deprecated.")]
		public static void RestoreNavMesh()
		{
		}

		public static NavMeshDataInstance AddNavMeshData(NavMeshData navMeshData)
		{
			if (navMeshData == null)
			{
				throw new ArgumentNullException("navMeshData");
			}
			return new NavMeshDataInstance
			{
				id = AddNavMeshDataInternal(navMeshData)
			};
		}

		public static NavMeshDataInstance AddNavMeshData(NavMeshData navMeshData, Vector3 position, Quaternion rotation)
		{
			if (navMeshData == null)
			{
				throw new ArgumentNullException("navMeshData");
			}
			return new NavMeshDataInstance
			{
				id = AddNavMeshDataTransformedInternal(navMeshData, position, rotation)
			};
		}

		public static void RemoveNavMeshData(NavMeshDataInstance handle)
		{
			RemoveNavMeshDataInternal(handle.id);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeName("IsValidSurfaceID")]
		[StaticAccessor("GetNavMeshManager()")]
		internal static extern bool IsValidNavMeshDataHandle(int handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("GetNavMeshManager()")]
		internal static extern bool IsValidLinkHandle(int handle);

		internal static Object InternalGetOwner(int dataID)
		{
			return Unmarshal.UnmarshalUnityObject<Object>(InternalGetOwner_Injected(dataID));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("GetNavMeshManager()")]
		[NativeName("SetSurfaceUserID")]
		internal static extern bool InternalSetOwner(int dataID, int ownerID);

		internal static Object InternalGetLinkOwner(int linkID)
		{
			return Unmarshal.UnmarshalUnityObject<Object>(InternalGetLinkOwner_Injected(linkID));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeName("SetLinkUserID")]
		[StaticAccessor("GetNavMeshManager()")]
		internal static extern bool InternalSetLinkOwner(int linkID, int ownerID);

		[StaticAccessor("GetNavMeshManager()")]
		[NativeName("LoadData")]
		internal static int AddNavMeshDataInternal(NavMeshData navMeshData)
		{
			return AddNavMeshDataInternal_Injected(Object.MarshalledUnityObject.Marshal(navMeshData));
		}

		[StaticAccessor("GetNavMeshManager()")]
		[NativeName("LoadData")]
		internal static int AddNavMeshDataTransformedInternal(NavMeshData navMeshData, Vector3 position, Quaternion rotation)
		{
			return AddNavMeshDataTransformedInternal_Injected(Object.MarshalledUnityObject.Marshal(navMeshData), ref position, ref rotation);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("GetNavMeshManager()")]
		[NativeName("UnloadData")]
		internal static extern void RemoveNavMeshDataInternal(int handle);

		public static NavMeshLinkInstance AddLink(NavMeshLinkData link)
		{
			return new NavMeshLinkInstance
			{
				id = AddLinkInternal(link, Vector3.zero, Quaternion.identity)
			};
		}

		public static NavMeshLinkInstance AddLink(NavMeshLinkData link, Vector3 position, Quaternion rotation)
		{
			return new NavMeshLinkInstance
			{
				id = AddLinkInternal(link, position, rotation)
			};
		}

		public static void RemoveLink(NavMeshLinkInstance handle)
		{
			RemoveLinkInternal(handle.id);
		}

		public static bool IsLinkActive(NavMeshLinkInstance handle)
		{
			return IsOffMeshConnectionActive(handle.id);
		}

		public static void SetLinkActive(NavMeshLinkInstance handle, bool value)
		{
			SetOffMeshConnectionActive(handle.id, value);
		}

		public static bool IsLinkOccupied(NavMeshLinkInstance handle)
		{
			return IsOffMeshConnectionOccupied(handle.id);
		}

		public static bool IsLinkValid(NavMeshLinkInstance handle)
		{
			return IsValidLinkHandle(handle.id);
		}

		public static Object GetLinkOwner(NavMeshLinkInstance handle)
		{
			return InternalGetLinkOwner(handle.id);
		}

		public static void SetLinkOwner(NavMeshLinkInstance handle, Object owner)
		{
			int ownerID = ((owner != null) ? owner.GetInstanceID() : 0);
			if (!InternalSetLinkOwner(handle.id, ownerID))
			{
				Debug.LogError("Cannot set 'owner' on an invalid NavMeshLinkInstance");
			}
		}

		[StaticAccessor("GetNavMeshManager()")]
		[NativeName("AddLink")]
		internal static int AddLinkInternal(NavMeshLinkData link, Vector3 position, Quaternion rotation)
		{
			return AddLinkInternal_Injected(ref link, ref position, ref rotation);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("GetNavMeshManager()")]
		[NativeName("RemoveLink")]
		internal static extern void RemoveLinkInternal(int handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("GetNavMeshManager()")]
		internal static extern bool IsOffMeshConnectionOccupied(int handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("GetNavMeshManager()")]
		internal static extern bool IsOffMeshConnectionActive(int linkHandle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("GetNavMeshManager()")]
		internal static extern void SetOffMeshConnectionActive(int linkHandle, bool activated);

		public static bool SamplePosition(Vector3 sourcePosition, out NavMeshHit hit, float maxDistance, NavMeshQueryFilter filter)
		{
			return SamplePositionFilter(sourcePosition, out hit, maxDistance, filter.agentTypeID, filter.areaMask);
		}

		private static bool SamplePositionFilter(Vector3 sourcePosition, out NavMeshHit hit, float maxDistance, int type, int mask)
		{
			return SamplePositionFilter_Injected(ref sourcePosition, out hit, maxDistance, type, mask);
		}

		public static bool FindClosestEdge(Vector3 sourcePosition, out NavMeshHit hit, NavMeshQueryFilter filter)
		{
			return FindClosestEdgeFilter(sourcePosition, out hit, filter.agentTypeID, filter.areaMask);
		}

		private static bool FindClosestEdgeFilter(Vector3 sourcePosition, out NavMeshHit hit, int type, int mask)
		{
			return FindClosestEdgeFilter_Injected(ref sourcePosition, out hit, type, mask);
		}

		public static bool Raycast(Vector3 sourcePosition, Vector3 targetPosition, out NavMeshHit hit, NavMeshQueryFilter filter)
		{
			return RaycastFilter(sourcePosition, targetPosition, out hit, filter.agentTypeID, filter.areaMask);
		}

		private static bool RaycastFilter(Vector3 sourcePosition, Vector3 targetPosition, out NavMeshHit hit, int type, int mask)
		{
			return RaycastFilter_Injected(ref sourcePosition, ref targetPosition, out hit, type, mask);
		}

		public static bool CalculatePath(Vector3 sourcePosition, Vector3 targetPosition, NavMeshQueryFilter filter, NavMeshPath path)
		{
			path.ClearCorners();
			return CalculatePathFilterInternal(sourcePosition, targetPosition, path, filter.agentTypeID, filter.areaMask, filter.costs);
		}

		private unsafe static bool CalculatePathFilterInternal(Vector3 sourcePosition, Vector3 targetPosition, NavMeshPath path, int type, int mask, float[] costs)
		{
			IntPtr path2 = ((path == null) ? ((IntPtr)0) : NavMeshPath.BindingsMarshaller.ConvertToNative(path));
			Span<float> span = new Span<float>(costs);
			bool result;
			fixed (float* begin = span)
			{
				ManagedSpanWrapper costs2 = new ManagedSpanWrapper(begin, span.Length);
				result = CalculatePathFilterInternal_Injected(ref sourcePosition, ref targetPosition, path2, type, mask, ref costs2);
			}
			return result;
		}

		[StaticAccessor("GetNavMeshProjectSettings()")]
		public static NavMeshBuildSettings CreateSettings()
		{
			CreateSettings_Injected(out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("GetNavMeshProjectSettings()")]
		public static extern void RemoveSettings(int agentTypeID);

		public static NavMeshBuildSettings GetSettingsByID(int agentTypeID)
		{
			GetSettingsByID_Injected(agentTypeID, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("GetNavMeshProjectSettings()")]
		public static extern int GetSettingsCount();

		public static NavMeshBuildSettings GetSettingsByIndex(int index)
		{
			GetSettingsByIndex_Injected(index, out var ret);
			return ret;
		}

		public static string GetSettingsNameFromID(int agentTypeID)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				GetSettingsNameFromID_Injected(agentTypeID, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[StaticAccessor("GetNavMeshManager()")]
		[NativeName("CleanupAfterCarving")]
		public static extern void RemoveAllNavMeshData();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Raycast_Injected([In] ref Vector3 sourcePosition, [In] ref Vector3 targetPosition, out NavMeshHit hit, int areaMask);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CalculatePathInternal_Injected([In] ref Vector3 sourcePosition, [In] ref Vector3 targetPosition, int areaMask, IntPtr path);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool FindClosestEdge_Injected([In] ref Vector3 sourcePosition, out NavMeshHit hit, int areaMask);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SamplePosition_Injected([In] ref Vector3 sourcePosition, out NavMeshHit hit, float maxDistance, int areaMask);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetNavMeshLayerFromName_Injected(ref ManagedSpanWrapper layerName);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetAreaFromName_Injected(ref ManagedSpanWrapper areaName);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CalculateTriangulation_Injected(out NavMeshTriangulation ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr InternalGetOwner_Injected(int dataID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr InternalGetLinkOwner_Injected(int linkID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int AddNavMeshDataInternal_Injected(IntPtr navMeshData);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int AddNavMeshDataTransformedInternal_Injected(IntPtr navMeshData, [In] ref Vector3 position, [In] ref Quaternion rotation);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int AddLinkInternal_Injected([In] ref NavMeshLinkData link, [In] ref Vector3 position, [In] ref Quaternion rotation);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SamplePositionFilter_Injected([In] ref Vector3 sourcePosition, out NavMeshHit hit, float maxDistance, int type, int mask);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool FindClosestEdgeFilter_Injected([In] ref Vector3 sourcePosition, out NavMeshHit hit, int type, int mask);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool RaycastFilter_Injected([In] ref Vector3 sourcePosition, [In] ref Vector3 targetPosition, out NavMeshHit hit, int type, int mask);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CalculatePathFilterInternal_Injected([In] ref Vector3 sourcePosition, [In] ref Vector3 targetPosition, IntPtr path, int type, int mask, ref ManagedSpanWrapper costs);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CreateSettings_Injected(out NavMeshBuildSettings ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSettingsByID_Injected(int agentTypeID, out NavMeshBuildSettings ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSettingsByIndex_Injected(int index, out NavMeshBuildSettings ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSettingsNameFromID_Injected(int agentTypeID, out ManagedSpanWrapper ret);
	}
	[MovedFrom("UnityEngine")]
	public enum NavMeshPathStatus
	{
		PathComplete,
		PathPartial,
		PathInvalid
	}
	[StructLayout(LayoutKind.Sequential)]
	[MovedFrom("UnityEngine")]
	[NativeHeader("Modules/AI/NavMeshPath.bindings.h")]
	public sealed class NavMeshPath
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(NavMeshPath navMeshPath)
			{
				return navMeshPath.m_Ptr;
			}
		}

		internal IntPtr m_Ptr;

		internal Vector3[] m_Corners;

		public Vector3[] corners
		{
			get
			{
				CalculateCorners();
				return m_Corners;
			}
		}

		public NavMeshPathStatus status
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_status_Injected(intPtr);
			}
		}

		public NavMeshPath()
		{
			m_Ptr = InitializeNavMeshPath();
		}

		~NavMeshPath()
		{
			DestroyNavMeshPath(m_Ptr);
			m_Ptr = IntPtr.Zero;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("NavMeshPathScriptBindings::InitializeNavMeshPath")]
		private static extern IntPtr InitializeNavMeshPath();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("NavMeshPathScriptBindings::DestroyNavMeshPath", IsThreadSafe = true)]
		private static extern void DestroyNavMeshPath(IntPtr ptr);

		[FreeFunction("NavMeshPathScriptBindings::GetCornersNonAlloc", HasExplicitThis = true)]
		public unsafe int GetCornersNonAlloc([Out] Vector3[] results)
		{
			//The blocks IL_002b are reachable both inside and outside the pinned region starting at IL_0014. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			BlittableArrayWrapper results2 = default(BlittableArrayWrapper);
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				if (results != null)
				{
					fixed (Vector3[] array = results)
					{
						if (array.Length != 0)
						{
							results2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						return GetCornersNonAlloc_Injected(intPtr, out results2);
					}
				}
				return GetCornersNonAlloc_Injected(intPtr, out results2);
			}
			finally
			{
				results2.Unmarshal(ref array);
			}
		}

		[FreeFunction("NavMeshPathScriptBindings::CalculateCornersInternal", HasExplicitThis = true)]
		private Vector3[] CalculateCornersInternal()
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			Vector3[] result;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				CalculateCornersInternal_Injected(intPtr, out ret);
			}
			finally
			{
				Vector3[] array = default(Vector3[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}

		[FreeFunction("NavMeshPathScriptBindings::ClearCornersInternal", HasExplicitThis = true)]
		private void ClearCornersInternal()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ClearCornersInternal_Injected(intPtr);
		}

		public void ClearCorners()
		{
			ClearCornersInternal();
			m_Corners = null;
		}

		private void CalculateCorners()
		{
			if (m_Corners == null)
			{
				m_Corners = CalculateCornersInternal();
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetCornersNonAlloc_Injected(IntPtr _unity_self, out BlittableArrayWrapper results);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CalculateCornersInternal_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ClearCornersInternal_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern NavMeshPathStatus get_status_Injected(IntPtr _unity_self);
	}
	[Flags]
	public enum NavMeshBuildDebugFlags
	{
		None = 0,
		InputGeometry = 1,
		Voxels = 2,
		Regions = 4,
		RawContours = 8,
		SimplifiedContours = 0x10,
		PolygonMeshes = 0x20,
		PolygonMeshesDetail = 0x40,
		All = 0x7F
	}
	public enum NavMeshBuildSourceShape
	{
		Mesh,
		Terrain,
		Box,
		Sphere,
		Capsule,
		ModifierBox
	}
	public enum NavMeshCollectGeometry
	{
		RenderMeshes,
		PhysicsColliders
	}
	[UsedByNativeCode]
	[NativeHeader("Modules/AI/Public/NavMeshBindingTypes.h")]
	public struct NavMeshBuildSource
	{
		private Matrix4x4 m_Transform;

		private Vector3 m_Size;

		private NavMeshBuildSourceShape m_Shape;

		private int m_Area;

		private int m_InstanceID;

		private int m_ComponentID;

		private int m_GenerateLinks;

		public Matrix4x4 transform
		{
			get
			{
				return m_Transform;
			}
			set
			{
				m_Transform = value;
			}
		}

		public Vector3 size
		{
			get
			{
				return m_Size;
			}
			set
			{
				m_Size = value;
			}
		}

		public NavMeshBuildSourceShape shape
		{
			get
			{
				return m_Shape;
			}
			set
			{
				m_Shape = value;
			}
		}

		public int area
		{
			get
			{
				return m_Area;
			}
			set
			{
				m_Area = value;
			}
		}

		public bool generateLinks
		{
			get
			{
				return m_GenerateLinks != 0;
			}
			set
			{
				m_GenerateLinks = (value ? 1 : 0);
			}
		}

		public Object sourceObject
		{
			get
			{
				return InternalGetObject(m_InstanceID);
			}
			set
			{
				m_InstanceID = ((value != null) ? value.GetInstanceID() : 0);
			}
		}

		public Component component
		{
			get
			{
				return InternalGetComponent(m_ComponentID);
			}
			set
			{
				m_ComponentID = ((value != null) ? value.GetInstanceID() : 0);
			}
		}

		[StaticAccessor("NavMeshBuildSource", StaticAccessorType.DoubleColon)]
		private static Component InternalGetComponent(int instanceID)
		{
			return Unmarshal.UnmarshalUnityObject<Component>(InternalGetComponent_Injected(instanceID));
		}

		[StaticAccessor("NavMeshBuildSource", StaticAccessorType.DoubleColon)]
		private static Object InternalGetObject(int instanceID)
		{
			return Unmarshal.UnmarshalUnityObject<Object>(InternalGetObject_Injected(instanceID));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr InternalGetComponent_Injected(int instanceID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr InternalGetObject_Injected(int instanceID);
	}
	[NativeHeader("Modules/AI/Public/NavMeshBindingTypes.h")]
	public struct NavMeshBuildMarkup
	{
		private int m_OverrideArea;

		private int m_Area;

		private int m_InheritIgnoreFromBuild;

		private int m_IgnoreFromBuild;

		private int m_OverrideGenerateLinks;

		private int m_GenerateLinks;

		private int m_InstanceID;

		private int m_IgnoreChildren;

		public bool overrideArea
		{
			get
			{
				return m_OverrideArea != 0;
			}
			set
			{
				m_OverrideArea = (value ? 1 : 0);
			}
		}

		public int area
		{
			get
			{
				return m_Area;
			}
			set
			{
				m_Area = value;
			}
		}

		public bool overrideIgnore
		{
			get
			{
				return m_InheritIgnoreFromBuild == 0;
			}
			set
			{
				m_InheritIgnoreFromBuild = ((!value) ? 1 : 0);
			}
		}

		public bool ignoreFromBuild
		{
			get
			{
				return m_IgnoreFromBuild != 0;
			}
			set
			{
				m_IgnoreFromBuild = (value ? 1 : 0);
			}
		}

		public bool overrideGenerateLinks
		{
			get
			{
				return m_OverrideGenerateLinks != 0;
			}
			set
			{
				m_OverrideGenerateLinks = (value ? 1 : 0);
			}
		}

		public bool generateLinks
		{
			get
			{
				return m_GenerateLinks != 0;
			}
			set
			{
				m_GenerateLinks = (value ? 1 : 0);
			}
		}

		public bool applyToChildren
		{
			get
			{
				return m_IgnoreChildren == 0;
			}
			set
			{
				m_IgnoreChildren = ((!value) ? 1 : 0);
			}
		}

		public Transform root
		{
			get
			{
				return InternalGetRootGO(m_InstanceID);
			}
			set
			{
				m_InstanceID = ((value != null) ? value.GetInstanceID() : 0);
			}
		}

		[StaticAccessor("NavMeshBuildMarkup", StaticAccessorType.DoubleColon)]
		private static Transform InternalGetRootGO(int instanceID)
		{
			return Unmarshal.UnmarshalUnityObject<Transform>(InternalGetRootGO_Injected(instanceID));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr InternalGetRootGO_Injected(int instanceID);
	}
	[NativeHeader("Modules/AI/Public/NavMeshBuildSettings.h")]
	public struct NavMeshBuildSettings
	{
		private int m_AgentTypeID;

		private float m_AgentRadius;

		private float m_AgentHeight;

		private float m_AgentSlope;

		private float m_AgentClimb;

		private float m_LedgeDropHeight;

		private float m_MaxJumpAcrossDistance;

		private float m_MinRegionArea;

		private int m_OverrideVoxelSize;

		private float m_VoxelSize;

		private int m_OverrideTileSize;

		private int m_TileSize;

		private int m_BuildHeightMesh;

		private uint m_MaxJobWorkers;

		private int m_PreserveTilesOutsideBounds;

		private NavMeshBuildDebugSettings m_Debug;

		public int agentTypeID
		{
			get
			{
				return m_AgentTypeID;
			}
			set
			{
				m_AgentTypeID = value;
			}
		}

		public float agentRadius
		{
			get
			{
				return m_AgentRadius;
			}
			set
			{
				m_AgentRadius = value;
			}
		}

		public float agentHeight
		{
			get
			{
				return m_AgentHeight;
			}
			set
			{
				m_AgentHeight = value;
			}
		}

		public float agentSlope
		{
			get
			{
				return m_AgentSlope;
			}
			set
			{
				m_AgentSlope = value;
			}
		}

		public float agentClimb
		{
			get
			{
				return m_AgentClimb;
			}
			set
			{
				m_AgentClimb = value;
			}
		}

		public float ledgeDropHeight
		{
			get
			{
				return m_LedgeDropHeight;
			}
			set
			{
				m_LedgeDropHeight = value;
			}
		}

		public float maxJumpAcrossDistance
		{
			get
			{
				return m_MaxJumpAcrossDistance;
			}
			set
			{
				m_MaxJumpAcrossDistance = value;
			}
		}

		public float minRegionArea
		{
			get
			{
				return m_MinRegionArea;
			}
			set
			{
				m_MinRegionArea = value;
			}
		}

		public bool overrideVoxelSize
		{
			get
			{
				return m_OverrideVoxelSize != 0;
			}
			set
			{
				m_OverrideVoxelSize = (value ? 1 : 0);
			}
		}

		public float voxelSize
		{
			get
			{
				return m_VoxelSize;
			}
			set
			{
				m_VoxelSize = value;
			}
		}

		public bool overrideTileSize
		{
			get
			{
				return m_OverrideTileSize != 0;
			}
			set
			{
				m_OverrideTileSize = (value ? 1 : 0);
			}
		}

		public int tileSize
		{
			get
			{
				return m_TileSize;
			}
			set
			{
				m_TileSize = value;
			}
		}

		public uint maxJobWorkers
		{
			get
			{
				return m_MaxJobWorkers;
			}
			set
			{
				m_MaxJobWorkers = value;
			}
		}

		public bool preserveTilesOutsideBounds
		{
			get
			{
				return m_PreserveTilesOutsideBounds != 0;
			}
			set
			{
				m_PreserveTilesOutsideBounds = (value ? 1 : 0);
			}
		}

		public bool buildHeightMesh
		{
			get
			{
				return m_BuildHeightMesh != 0;
			}
			set
			{
				m_BuildHeightMesh = (value ? 1 : 0);
			}
		}

		public NavMeshBuildDebugSettings debug
		{
			get
			{
				return m_Debug;
			}
			set
			{
				m_Debug = value;
			}
		}

		public string[] ValidationReport(Bounds buildBounds)
		{
			return InternalValidationReport(this, buildBounds);
		}

		[FreeFunction]
		[NativeHeader("Modules/AI/Public/NavMeshBuildSettings.h")]
		private static string[] InternalValidationReport(NavMeshBuildSettings buildSettings, Bounds buildBounds)
		{
			return InternalValidationReport_Injected(ref buildSettings, ref buildBounds);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string[] InternalValidationReport_Injected([In] ref NavMeshBuildSettings buildSettings, [In] ref Bounds buildBounds);
	}
	[NativeHeader("Modules/AI/Public/NavMeshBuildDebugSettings.h")]
	public struct NavMeshBuildDebugSettings
	{
		private byte m_Flags;

		public NavMeshBuildDebugFlags flags
		{
			get
			{
				return (NavMeshBuildDebugFlags)m_Flags;
			}
			set
			{
				m_Flags = (byte)value;
			}
		}
	}
}
