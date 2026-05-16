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
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

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
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
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
[assembly: InternalsVisibleTo("UnityEngine.UIModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainPhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubsystemsModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.UnityConnectModule")]
[assembly: InternalsVisibleTo("UnityEngine.GridModule")]
[assembly: InternalsVisibleTo("UnityEngine.HierarchyCoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextRenderingModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.TerrainModule")]
[assembly: InternalsVisibleTo("UnityEngine.ARModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
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
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.021")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.008")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.007")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.006")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.001")]
[assembly: InternalsVisibleTo("UnityEngine.Core.Runtime.Tests")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.009")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.022")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.023")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.024")]
[assembly: InternalsVisibleTo("Unity.Testing.VisualEffectGraph.EditorTests")]
[assembly: InternalsVisibleTo("Unity.Testing.VisualEffectGraph.Editor-testable")]
[assembly: InternalsVisibleTo("Unity.Testing.VisualEffectGraph.Editor")]
[assembly: InternalsVisibleTo("Unity.Testing.VisualEffectGraph.Tests-testable")]
[assembly: InternalsVisibleTo("Unity.Testing.VisualEffectGraph.Tests")]
[assembly: InternalsVisibleTo("Unity.Testing.VisualEffectGraph-testable")]
[assembly: InternalsVisibleTo("Unity.Testing.VisualEffectGraph")]
[assembly: InternalsVisibleTo("Unity.Testing.VisualEffectGraph.PerformanceEditorTests-testable")]
[assembly: InternalsVisibleTo("Unity.Testing.VisualEffectGraph.PerformanceEditorTests")]
[assembly: InternalsVisibleTo("Unity.Testing.VisualEffectGraph.PerformanceRuntimeTests-testable")]
[assembly: InternalsVisibleTo("Unity.Testing.VisualEffectGraph.PerformanceRuntimeTests")]
[assembly: InternalsVisibleTo("Unity.VisualEffectGraph.Runtime")]
[assembly: InternalsVisibleTo("Unity.VisualEffectGraph.EditorTests-testable")]
[assembly: InternalsVisibleTo("Unity.VisualEffectGraph.EditorTests")]
[assembly: InternalsVisibleTo("Unity.VisualEffectGraph.Editor-testable")]
[assembly: InternalsVisibleTo("Unity.VisualEffectGraph.Editor")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: InternalsVisibleTo("Unity.Subsystem.Registration")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
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
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
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
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("Unity.Testing.VisualEffectGraph.EditorTests-testable")]
[assembly: InternalsVisibleTo("UnityEngine.InputModule")]
[assembly: InternalsVisibleTo("UnityEngine.PhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.AMDModule")]
[assembly: InternalsVisibleTo("UnityEngine.AIModule")]
[assembly: InternalsVisibleTo("UnityEngine.CoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.SharedInternalsModule")]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("UnityEngine.JSONSerializeModule")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine.Experimental.VFX
{
	internal static class VFXManager
	{
	}
}
namespace UnityEngine.VFX
{
	public enum VFXSpace
	{
		None = -1,
		Local,
		World
	}
	[Flags]
	internal enum VFXCullingFlags
	{
		CullNone = 0,
		CullSimulation = 1,
		CullBoundsUpdate = 2,
		CullDefault = 3
	}
	internal enum VFXExpressionOperation
	{
		None,
		Value,
		Combine2f,
		Combine3f,
		Combine4f,
		ExtractComponent,
		DeltaTime,
		TotalTime,
		SystemSeed,
		LocalToWorld,
		WorldToLocal,
		FrameIndex,
		PlayRate,
		UnscaledDeltaTime,
		ManagerMaxDeltaTime,
		ManagerFixedTimeStep,
		GameDeltaTime,
		GameUnscaledDeltaTime,
		GameSmoothDeltaTime,
		GameTotalTime,
		GameUnscaledTotalTime,
		GameTotalTimeSinceSceneLoad,
		GameTimeScale,
		Sin,
		Cos,
		Tan,
		ASin,
		ACos,
		ATan,
		Abs,
		Sign,
		Saturate,
		Ceil,
		Round,
		Frac,
		Floor,
		Log2,
		Mul,
		Divide,
		Add,
		Subtract,
		Min,
		Max,
		Pow,
		ATan2,
		TRSToMatrix,
		InverseMatrix,
		InverseTRSMatrix,
		TransposeMatrix,
		ExtractPositionFromMatrix,
		ExtractAnglesFromMatrix,
		ExtractScaleFromMatrix,
		TransformMatrix,
		TransformPos,
		TransformVec,
		TransformDir,
		TransformVector4,
		RowToMatrix,
		ColumnToMatrix,
		AxisToMatrix,
		MatrixToRow,
		MatrixToColumn,
		MatrixToAxis,
		SampleCurve,
		SampleGradient,
		SampleMeshVertexFloat,
		SampleMeshVertexFloat2,
		SampleMeshVertexFloat3,
		SampleMeshVertexFloat4,
		SampleMeshVertexColor,
		SampleMeshIndex,
		VertexBufferFromMesh,
		VertexBufferFromSkinnedMeshRenderer,
		IndexBufferFromMesh,
		MeshFromSkinnedMeshRenderer,
		RootBoneTransformFromSkinnedMeshRenderer,
		BakeCurve,
		BakeGradient,
		BitwiseLeftShift,
		BitwiseRightShift,
		BitwiseOr,
		BitwiseAnd,
		BitwiseXor,
		BitwiseComplement,
		CastUintToFloat,
		CastIntToFloat,
		CastFloatToUint,
		CastIntToUint,
		CastFloatToInt,
		CastUintToInt,
		CastIntToBool,
		CastUintToBool,
		CastFloatToBool,
		CastBoolToInt,
		CastBoolToUint,
		CastBoolToFloat,
		RGBtoHSV,
		HSVtoRGB,
		Condition,
		Branch,
		GenerateRandom,
		GenerateFixedRandom,
		ExtractMatrixFromMainCamera,
		ExtractFOVFromMainCamera,
		ExtractNearPlaneFromMainCamera,
		ExtractFarPlaneFromMainCamera,
		ExtractAspectRatioFromMainCamera,
		ExtractPixelDimensionsFromMainCamera,
		ExtractScaledPixelDimensionsFromMainCamera,
		ExtractLensShiftFromMainCamera,
		GetBufferFromMainCamera,
		IsMainCameraOrthographic,
		GetOrthographicSizeFromMainCamera,
		LogicalAnd,
		LogicalOr,
		LogicalNot,
		ValueNoise1D,
		ValueNoise2D,
		ValueNoise3D,
		ValueCurlNoise2D,
		ValueCurlNoise3D,
		PerlinNoise1D,
		PerlinNoise2D,
		PerlinNoise3D,
		PerlinCurlNoise2D,
		PerlinCurlNoise3D,
		CellularNoise1D,
		CellularNoise2D,
		CellularNoise3D,
		CellularCurlNoise2D,
		CellularCurlNoise3D,
		VoroNoise2D,
		MeshVertexCount,
		MeshChannelOffset,
		MeshChannelInfos,
		MeshVertexStride,
		MeshIndexCount,
		MeshIndexFormat,
		BufferStride,
		BufferCount,
		TextureWidth,
		TextureHeight,
		TextureDepth,
		TextureFormat,
		ReadEventAttribute,
		SpawnerStateNewLoop,
		SpawnerStateLoopState,
		SpawnerStateSpawnCount,
		SpawnerStateDeltaTime,
		SpawnerStateTotalTime,
		SpawnerStateDelayBeforeLoop,
		SpawnerStateLoopDuration,
		SpawnerStateDelayAfterLoop,
		SpawnerStateLoopIndex,
		SpawnerStateLoopCount
	}
	internal enum VFXValueType
	{
		None,
		Float,
		Float2,
		Float3,
		Float4,
		Int32,
		Uint32,
		Texture2D,
		Texture2DArray,
		Texture3D,
		TextureCube,
		TextureCubeArray,
		CameraBuffer,
		Matrix4x4,
		Curve,
		ColorGradient,
		Mesh,
		Spline,
		Boolean,
		Buffer,
		SkinnedMeshRenderer
	}
	internal enum VFXTaskType
	{
		None = 0,
		Spawner = 268435456,
		Initialize = 536870912,
		Update = 805306368,
		Output = 1073741824,
		CameraSort = 805306369,
		PerCameraUpdate = 805306370,
		PerCameraSort = 805306371,
		PerOutputSort = 805306372,
		GlobalSort = 805306373,
		ParticlePointOutput = 1073741824,
		ParticleLineOutput = 1073741825,
		ParticleQuadOutput = 1073741826,
		ParticleHexahedronOutput = 1073741827,
		ParticleMeshOutput = 1073741828,
		ParticleTriangleOutput = 1073741829,
		ParticleOctagonOutput = 1073741830,
		ConstantRateSpawner = 268435456,
		BurstSpawner = 268435457,
		PeriodicBurstSpawner = 268435458,
		VariableRateSpawner = 268435459,
		CustomCallbackSpawner = 268435460,
		SetAttributeSpawner = 268435461,
		EvaluateExpressionsSpawner = 268435462
	}
	internal enum VFXSystemType
	{
		Spawner,
		Particle,
		Mesh,
		OutputEvent
	}
	internal enum VFXSystemFlag
	{
		SystemDefault = 0,
		SystemHasKill = 1,
		SystemHasIndirectBuffer = 2,
		SystemReceivedEventGPU = 4,
		SystemHasStrips = 8,
		SystemNeedsComputeBounds = 0x10,
		SystemAutomaticBounds = 0x20,
		SystemInWorldSpace = 0x40,
		SystemHasDirectLink = 0x80,
		SystemHasAttributeBuffer = 0x100,
		SystemUsesInstancedRendering = 0x200,
		SystemIsRayTraced = 0x400
	}
	[Flags]
	internal enum VFXUpdateMode
	{
		FixedDeltaTime = 0,
		DeltaTime = 1,
		IgnoreTimeScale = 2,
		ExactFixedTimeStep = 4,
		DeltaTimeAndIgnoreTimeScale = 3,
		FixedDeltaAndExactTime = 4,
		FixedDeltaAndExactTimeAndIgnoreTimeScale = 6
	}
	[Flags]
	public enum VFXCameraBufferTypes
	{
		None = 0,
		Depth = 1,
		Color = 2,
		Normal = 4
	}
	internal enum VFXInstancingMode
	{
		Disabled = -1,
		[InspectorName("Automatic batch capacity")]
		Auto,
		[InspectorName("Custom batch capacity")]
		Custom
	}
	[Flags]
	internal enum VFXInstancingDisabledReason
	{
		None = 0,
		[Description("A system is using indirect draw.")]
		IndirectDraw = 1,
		[Description("The effect is using output events.")]
		OutputEvent = 2,
		[Description("The effect is using GPU events.")]
		GPUEvent = 4,
		[Description("An Initialize node has Bounds Mode set to 'Automatic'.")]
		AutomaticBounds = 8,
		[Description("The effect contains a mesh output.")]
		MeshOutput = 0x10,
		[Description("The effect has exposed texture, mesh or graphics buffer properties.")]
		ExposedObject = 0x20,
		[Description("The effect uses Shader Keywords in particle output.")]
		ShaderKeyword = 0x40,
		[Description("Unknown reason.")]
		Unknown = -1
	}
	internal enum VFXMainCameraBufferFallback
	{
		NoFallback,
		PreferMainCamera,
		PreferSceneCamera
	}
	internal enum VFXSkinnedMeshFrame
	{
		Current,
		Previous
	}
	internal enum VFXSkinnedTransform
	{
		LocalRootBoneTransform,
		WorldRootBoneTransform
	}
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode]
	[NativeType(Header = "Modules/VFX/Public/VFXEventAttribute.h")]
	public sealed class VFXEventAttribute : IDisposable
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(VFXEventAttribute eventAttibute)
			{
				return eventAttibute.m_Ptr;
			}

			public static VFXEventAttribute ConvertToManaged(IntPtr ptr)
			{
				return new VFXEventAttribute(ptr);
			}
		}

		private IntPtr m_Ptr;

		private bool m_Owner;

		private VisualEffectAsset m_VfxAsset;

		internal VisualEffectAsset vfxAsset => m_VfxAsset;

		private VFXEventAttribute(IntPtr ptr, bool owner, VisualEffectAsset vfxAsset)
		{
			m_Ptr = ptr;
			m_Owner = owner;
			m_VfxAsset = vfxAsset;
		}

		private VFXEventAttribute(IntPtr ptr)
		{
			m_Ptr = ptr;
		}

		private VFXEventAttribute()
			: this(IntPtr.Zero, owner: false, null)
		{
		}

		internal static VFXEventAttribute CreateEventAttributeWrapper()
		{
			return new VFXEventAttribute(IntPtr.Zero, owner: false, null);
		}

		internal void SetWrapValue(IntPtr ptrToEventAttribute)
		{
			if (m_Owner)
			{
				throw new Exception("VFXSpawnerState : SetWrapValue is reserved to CreateWrapper object");
			}
			m_Ptr = ptrToEventAttribute;
		}

		public VFXEventAttribute(VFXEventAttribute original)
		{
			if (original == null)
			{
				throw new ArgumentNullException("VFXEventAttribute expect a non null attribute");
			}
			m_Ptr = Internal_Create();
			m_VfxAsset = original.m_VfxAsset;
			Internal_InitFromEventAttribute(original);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr Internal_Create();

		internal static VFXEventAttribute Internal_InstanciateVFXEventAttribute(VisualEffectAsset vfxAsset)
		{
			VFXEventAttribute vFXEventAttribute = new VFXEventAttribute(Internal_Create(), owner: true, vfxAsset);
			vFXEventAttribute.Internal_InitFromAsset(vfxAsset);
			return vFXEventAttribute;
		}

		internal void Internal_InitFromAsset(VisualEffectAsset vfxAsset)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Internal_InitFromAsset_Injected(intPtr, Object.MarshalledUnityObject.Marshal(vfxAsset));
		}

		internal void Internal_InitFromEventAttribute(VFXEventAttribute vfxEventAttribute)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Internal_InitFromEventAttribute_Injected(intPtr, (vfxEventAttribute == null) ? ((IntPtr)0) : BindingsMarshaller.ConvertToNative(vfxEventAttribute));
		}

		private void Release()
		{
			if (m_Owner && m_Ptr != IntPtr.Zero)
			{
				Internal_Destroy(m_Ptr);
			}
			m_Ptr = IntPtr.Zero;
			m_VfxAsset = null;
		}

		~VFXEventAttribute()
		{
			Release();
		}

		public void Dispose()
		{
			Release();
			GC.SuppressFinalize(this);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		internal static extern void Internal_Destroy(IntPtr ptr);

		[NativeName("HasValueFromScript<bool>")]
		public bool HasBool(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasBool_Injected(intPtr, nameID);
		}

		[NativeName("HasValueFromScript<int>")]
		public bool HasInt(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasInt_Injected(intPtr, nameID);
		}

		[NativeName("HasValueFromScript<UInt32>")]
		public bool HasUint(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasUint_Injected(intPtr, nameID);
		}

		[NativeName("HasValueFromScript<float>")]
		public bool HasFloat(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasFloat_Injected(intPtr, nameID);
		}

		[NativeName("HasValueFromScript<Vector2f>")]
		public bool HasVector2(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasVector2_Injected(intPtr, nameID);
		}

		[NativeName("HasValueFromScript<Vector3f>")]
		public bool HasVector3(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasVector3_Injected(intPtr, nameID);
		}

		[NativeName("HasValueFromScript<Vector4f>")]
		public bool HasVector4(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasVector4_Injected(intPtr, nameID);
		}

		[NativeName("HasValueFromScript<Matrix4x4f>")]
		public bool HasMatrix4x4(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasMatrix4x4_Injected(intPtr, nameID);
		}

		[NativeName("SetValueFromScript<bool>")]
		public void SetBool(int nameID, bool b)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetBool_Injected(intPtr, nameID, b);
		}

		[NativeName("SetValueFromScript<int>")]
		public void SetInt(int nameID, int i)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetInt_Injected(intPtr, nameID, i);
		}

		[NativeName("SetValueFromScript<UInt32>")]
		public void SetUint(int nameID, uint i)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetUint_Injected(intPtr, nameID, i);
		}

		[NativeName("SetValueFromScript<float>")]
		public void SetFloat(int nameID, float f)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetFloat_Injected(intPtr, nameID, f);
		}

		[NativeName("SetValueFromScript<Vector2f>")]
		public void SetVector2(int nameID, Vector2 v)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetVector2_Injected(intPtr, nameID, ref v);
		}

		[NativeName("SetValueFromScript<Vector3f>")]
		public void SetVector3(int nameID, Vector3 v)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetVector3_Injected(intPtr, nameID, ref v);
		}

		[NativeName("SetValueFromScript<Vector4f>")]
		public void SetVector4(int nameID, Vector4 v)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetVector4_Injected(intPtr, nameID, ref v);
		}

		[NativeName("SetValueFromScript<Matrix4x4f>")]
		public void SetMatrix4x4(int nameID, Matrix4x4 v)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetMatrix4x4_Injected(intPtr, nameID, ref v);
		}

		[NativeName("GetValueFromScript<bool>")]
		public bool GetBool(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetBool_Injected(intPtr, nameID);
		}

		[NativeName("GetValueFromScript<int>")]
		public int GetInt(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetInt_Injected(intPtr, nameID);
		}

		[NativeName("GetValueFromScript<UInt32>")]
		public uint GetUint(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetUint_Injected(intPtr, nameID);
		}

		[NativeName("GetValueFromScript<float>")]
		public float GetFloat(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetFloat_Injected(intPtr, nameID);
		}

		[NativeName("GetValueFromScript<Vector2f>")]
		public Vector2 GetVector2(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetVector2_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		[NativeName("GetValueFromScript<Vector3f>")]
		public Vector3 GetVector3(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetVector3_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		[NativeName("GetValueFromScript<Vector4f>")]
		public Vector4 GetVector4(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetVector4_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		[NativeName("GetValueFromScript<Matrix4x4f>")]
		public Matrix4x4 GetMatrix4x4(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetMatrix4x4_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		public bool HasBool(string name)
		{
			return HasBool(Shader.PropertyToID(name));
		}

		public bool HasInt(string name)
		{
			return HasInt(Shader.PropertyToID(name));
		}

		public bool HasUint(string name)
		{
			return HasUint(Shader.PropertyToID(name));
		}

		public bool HasFloat(string name)
		{
			return HasFloat(Shader.PropertyToID(name));
		}

		public bool HasVector2(string name)
		{
			return HasVector2(Shader.PropertyToID(name));
		}

		public bool HasVector3(string name)
		{
			return HasVector3(Shader.PropertyToID(name));
		}

		public bool HasVector4(string name)
		{
			return HasVector4(Shader.PropertyToID(name));
		}

		public bool HasMatrix4x4(string name)
		{
			return HasMatrix4x4(Shader.PropertyToID(name));
		}

		public void SetBool(string name, bool b)
		{
			SetBool(Shader.PropertyToID(name), b);
		}

		public void SetInt(string name, int i)
		{
			SetInt(Shader.PropertyToID(name), i);
		}

		public void SetUint(string name, uint i)
		{
			SetUint(Shader.PropertyToID(name), i);
		}

		public void SetFloat(string name, float f)
		{
			SetFloat(Shader.PropertyToID(name), f);
		}

		public void SetVector2(string name, Vector2 v)
		{
			SetVector2(Shader.PropertyToID(name), v);
		}

		public void SetVector3(string name, Vector3 v)
		{
			SetVector3(Shader.PropertyToID(name), v);
		}

		public void SetVector4(string name, Vector4 v)
		{
			SetVector4(Shader.PropertyToID(name), v);
		}

		public void SetMatrix4x4(string name, Matrix4x4 v)
		{
			SetMatrix4x4(Shader.PropertyToID(name), v);
		}

		public bool GetBool(string name)
		{
			return GetBool(Shader.PropertyToID(name));
		}

		public int GetInt(string name)
		{
			return GetInt(Shader.PropertyToID(name));
		}

		public uint GetUint(string name)
		{
			return GetUint(Shader.PropertyToID(name));
		}

		public float GetFloat(string name)
		{
			return GetFloat(Shader.PropertyToID(name));
		}

		public Vector2 GetVector2(string name)
		{
			return GetVector2(Shader.PropertyToID(name));
		}

		public Vector3 GetVector3(string name)
		{
			return GetVector3(Shader.PropertyToID(name));
		}

		public Vector4 GetVector4(string name)
		{
			return GetVector4(Shader.PropertyToID(name));
		}

		public Matrix4x4 GetMatrix4x4(string name)
		{
			return GetMatrix4x4(Shader.PropertyToID(name));
		}

		public void CopyValuesFrom([NotNull] VFXEventAttribute eventAttibute)
		{
			if (eventAttibute == null)
			{
				ThrowHelper.ThrowArgumentNullException(eventAttibute, "eventAttibute");
			}
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = BindingsMarshaller.ConvertToNative(eventAttibute);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(eventAttibute, "eventAttibute");
			}
			CopyValuesFrom_Injected(intPtr, intPtr2);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_InitFromAsset_Injected(IntPtr _unity_self, IntPtr vfxAsset);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_InitFromEventAttribute_Injected(IntPtr _unity_self, IntPtr vfxEventAttribute);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasBool_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasInt_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasUint_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasFloat_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasVector2_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasVector3_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasVector4_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasMatrix4x4_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetBool_Injected(IntPtr _unity_self, int nameID, bool b);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetInt_Injected(IntPtr _unity_self, int nameID, int i);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetUint_Injected(IntPtr _unity_self, int nameID, uint i);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFloat_Injected(IntPtr _unity_self, int nameID, float f);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetVector2_Injected(IntPtr _unity_self, int nameID, [In] ref Vector2 v);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetVector3_Injected(IntPtr _unity_self, int nameID, [In] ref Vector3 v);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetVector4_Injected(IntPtr _unity_self, int nameID, [In] ref Vector4 v);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetMatrix4x4_Injected(IntPtr _unity_self, int nameID, [In] ref Matrix4x4 v);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetBool_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetInt_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetUint_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetFloat_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetVector2_Injected(IntPtr _unity_self, int nameID, out Vector2 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetVector3_Injected(IntPtr _unity_self, int nameID, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetVector4_Injected(IntPtr _unity_self, int nameID, out Vector4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetMatrix4x4_Injected(IntPtr _unity_self, int nameID, out Matrix4x4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CopyValuesFrom_Injected(IntPtr _unity_self, IntPtr eventAttibute);
	}
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode]
	[NativeType(Header = "Modules/VFX/Public/VFXExpressionValues.h")]
	public class VFXExpressionValues
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(VFXExpressionValues vFXExpressionValues)
			{
				return vFXExpressionValues.m_Ptr;
			}
		}

		internal IntPtr m_Ptr;

		private VFXExpressionValues()
		{
		}

		[RequiredByNativeCode]
		internal static VFXExpressionValues CreateExpressionValuesWrapper(IntPtr ptr)
		{
			VFXExpressionValues vFXExpressionValues = new VFXExpressionValues();
			vFXExpressionValues.m_Ptr = ptr;
			return vFXExpressionValues;
		}

		[NativeName("GetValueFromScript<bool>")]
		[NativeThrows]
		public bool GetBool(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetBool_Injected(intPtr, nameID);
		}

		[NativeThrows]
		[NativeName("GetValueFromScript<int>")]
		public int GetInt(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetInt_Injected(intPtr, nameID);
		}

		[NativeThrows]
		[NativeName("GetValueFromScript<UInt32>")]
		public uint GetUInt(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetUInt_Injected(intPtr, nameID);
		}

		[NativeThrows]
		[NativeName("GetValueFromScript<float>")]
		public float GetFloat(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetFloat_Injected(intPtr, nameID);
		}

		[NativeThrows]
		[NativeName("GetValueFromScript<Vector2f>")]
		public Vector2 GetVector2(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetVector2_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		[NativeName("GetValueFromScript<Vector3f>")]
		[NativeThrows]
		public Vector3 GetVector3(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetVector3_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		[NativeThrows]
		[NativeName("GetValueFromScript<Vector4f>")]
		public Vector4 GetVector4(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetVector4_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		[NativeThrows]
		[NativeName("GetValueFromScript<Matrix4x4f>")]
		public Matrix4x4 GetMatrix4x4(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetMatrix4x4_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		[NativeName("GetValueFromScript<Texture*>")]
		[NativeThrows]
		public Texture GetTexture(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Texture>(GetTexture_Injected(intPtr, nameID));
		}

		[NativeName("GetValueFromScript<Mesh*>")]
		[NativeThrows]
		public Mesh GetMesh(int nameID)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Mesh>(GetMesh_Injected(intPtr, nameID));
		}

		public AnimationCurve GetAnimationCurve(int nameID)
		{
			AnimationCurve animationCurve = new AnimationCurve();
			Internal_GetAnimationCurveFromScript(nameID, animationCurve);
			return animationCurve;
		}

		[NativeThrows]
		internal void Internal_GetAnimationCurveFromScript(int nameID, AnimationCurve curve)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Internal_GetAnimationCurveFromScript_Injected(intPtr, nameID, (curve == null) ? ((IntPtr)0) : AnimationCurve.BindingsMarshaller.ConvertToNative(curve));
		}

		public Gradient GetGradient(int nameID)
		{
			Gradient gradient = new Gradient();
			Internal_GetGradientFromScript(nameID, gradient);
			return gradient;
		}

		[NativeThrows]
		internal void Internal_GetGradientFromScript(int nameID, Gradient gradient)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Internal_GetGradientFromScript_Injected(intPtr, nameID, (gradient == null) ? ((IntPtr)0) : Gradient.BindingsMarshaller.ConvertToNative(gradient));
		}

		public bool GetBool(string name)
		{
			return GetBool(Shader.PropertyToID(name));
		}

		public int GetInt(string name)
		{
			return GetInt(Shader.PropertyToID(name));
		}

		public uint GetUInt(string name)
		{
			return GetUInt(Shader.PropertyToID(name));
		}

		public float GetFloat(string name)
		{
			return GetFloat(Shader.PropertyToID(name));
		}

		public Vector2 GetVector2(string name)
		{
			return GetVector2(Shader.PropertyToID(name));
		}

		public Vector3 GetVector3(string name)
		{
			return GetVector3(Shader.PropertyToID(name));
		}

		public Vector4 GetVector4(string name)
		{
			return GetVector4(Shader.PropertyToID(name));
		}

		public Matrix4x4 GetMatrix4x4(string name)
		{
			return GetMatrix4x4(Shader.PropertyToID(name));
		}

		public Texture GetTexture(string name)
		{
			return GetTexture(Shader.PropertyToID(name));
		}

		public AnimationCurve GetAnimationCurve(string name)
		{
			return GetAnimationCurve(Shader.PropertyToID(name));
		}

		public Gradient GetGradient(string name)
		{
			return GetGradient(Shader.PropertyToID(name));
		}

		public Mesh GetMesh(string name)
		{
			return GetMesh(Shader.PropertyToID(name));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetBool_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetInt_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetUInt_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetFloat_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetVector2_Injected(IntPtr _unity_self, int nameID, out Vector2 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetVector3_Injected(IntPtr _unity_self, int nameID, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetVector4_Injected(IntPtr _unity_self, int nameID, out Vector4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetMatrix4x4_Injected(IntPtr _unity_self, int nameID, out Matrix4x4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetTexture_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetMesh_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_GetAnimationCurveFromScript_Injected(IntPtr _unity_self, int nameID, IntPtr curve);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_GetGradientFromScript_Injected(IntPtr _unity_self, int nameID, IntPtr gradient);
	}
	[RequiredByNativeCode]
	public struct VFXCameraXRSettings
	{
		public uint viewTotal;

		public uint viewCount;

		public uint viewOffset;
	}
	[RequiredByNativeCode]
	public struct VFXBatchedEffectInfo
	{
		public VisualEffectAsset vfxAsset;

		public uint activeBatchCount;

		public uint inactiveBatchCount;

		public uint activeInstanceCount;

		public uint unbatchedInstanceCount;

		public uint totalInstanceCapacity;

		public uint maxInstancePerBatchCapacity;

		public ulong totalGPUSizeInBytes;

		public ulong totalCPUSizeInBytes;
	}
	[RequiredByNativeCode]
	internal struct VFXBatchInfo
	{
		public uint capacity;

		public uint activeInstanceCount;
	}
	[NativeHeader("Modules/VFX/Public/VFXManager.h")]
	[NativeHeader("Modules/VFX/Public/ScriptBindings/VFXManagerBindings.h")]
	[StaticAccessor("GetVFXManager()", StaticAccessorType.Dot)]
	[RequiredByNativeCode]
	public static class VFXManager
	{
		private static readonly VFXCameraXRSettings kDefaultCameraXRSettings = new VFXCameraXRSettings
		{
			viewTotal = 1u,
			viewCount = 1u,
			viewOffset = 0u
		};

		internal static ScriptableObject runtimeResources => Unmarshal.UnmarshalUnityObject<ScriptableObject>(get_runtimeResources_Injected());

		public static extern float fixedTimeStep
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public static extern float maxDeltaTime
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		internal static extern uint maxCapacity
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		internal static extern float maxScrubTime
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		internal static string renderPipeSettingsPath
		{
			get
			{
				ManagedSpanWrapper ret = default(ManagedSpanWrapper);
				string stringAndDispose;
				try
				{
					get_renderPipeSettingsPath_Injected(out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
		}

		internal static extern uint batchEmptyLifetime
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern VisualEffect[] GetComponents();

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void CleanupEmptyBatches(bool force = false);

		public static void FlushEmptyBatches()
		{
			CleanupEmptyBatches(force: true);
		}

		public static VFXBatchedEffectInfo GetBatchedEffectInfo([NotNull] VisualEffectAsset vfx)
		{
			if ((object)vfx == null)
			{
				ThrowHelper.ThrowArgumentNullException(vfx, "vfx");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(vfx);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(vfx, "vfx");
			}
			GetBatchedEffectInfo_Injected(intPtr, out var ret);
			return ret;
		}

		[FreeFunction(Name = "VFXManagerBindings::GetBatchedEffectInfos", HasExplicitThis = false)]
		public static void GetBatchedEffectInfos([NotNull] List<VFXBatchedEffectInfo> infos)
		{
			if (infos == null)
			{
				ThrowHelper.ThrowArgumentNullException(infos, "infos");
			}
			GetBatchedEffectInfos_Injected(infos);
		}

		internal static VFXBatchInfo GetBatchInfo(VisualEffectAsset vfx, uint batchIndex)
		{
			GetBatchInfo_Injected(Object.MarshalledUnityObject.Marshal(vfx), batchIndex, out var ret);
			return ret;
		}

		[Obsolete("Use explicit PrepareCamera and ProcessCameraCommand instead")]
		public static void ProcessCamera(Camera cam)
		{
			PrepareCamera(cam, kDefaultCameraXRSettings);
			Internal_ProcessCameraCommand(cam, null, kDefaultCameraXRSettings, IntPtr.Zero, IntPtr.Zero);
		}

		public static void PrepareCamera(Camera cam)
		{
			PrepareCamera(cam, kDefaultCameraXRSettings);
		}

		public static void PrepareCamera([NotNull] Camera cam, VFXCameraXRSettings camXRSettings)
		{
			if ((object)cam == null)
			{
				ThrowHelper.ThrowArgumentNullException(cam, "cam");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(cam);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(cam, "cam");
			}
			PrepareCamera_Injected(intPtr, ref camXRSettings);
		}

		[Obsolete("Use ProcessCameraCommand with CullingResults to allow culling of VFX per camera")]
		public static void ProcessCameraCommand(Camera cam, CommandBuffer cmd)
		{
			Internal_ProcessCameraCommand(cam, cmd, kDefaultCameraXRSettings, IntPtr.Zero, IntPtr.Zero);
		}

		[Obsolete("Use ProcessCameraCommand with CullingResults to allow culling of VFX per camera")]
		public static void ProcessCameraCommand(Camera cam, CommandBuffer cmd, VFXCameraXRSettings camXRSettings)
		{
			Internal_ProcessCameraCommand(cam, cmd, camXRSettings, IntPtr.Zero, IntPtr.Zero);
		}

		public static void ProcessCameraCommand(Camera cam, CommandBuffer cmd, VFXCameraXRSettings camXRSettings, CullingResults results)
		{
			Internal_ProcessCameraCommand(cam, cmd, camXRSettings, results.ptr, IntPtr.Zero);
		}

		public static void ProcessCameraCommand(Camera cam, CommandBuffer cmd, VFXCameraXRSettings camXRSettings, CullingResults results, CullingResults customPassResults)
		{
			Internal_ProcessCameraCommand(cam, cmd, camXRSettings, results.ptr, customPassResults.ptr);
		}

		private static void Internal_ProcessCameraCommand([NotNull] Camera cam, CommandBuffer cmd, VFXCameraXRSettings camXRSettings, IntPtr cullResults, IntPtr customPassCullResults)
		{
			if ((object)cam == null)
			{
				ThrowHelper.ThrowArgumentNullException(cam, "cam");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(cam);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(cam, "cam");
			}
			Internal_ProcessCameraCommand_Injected(intPtr, (cmd == null) ? ((IntPtr)0) : CommandBuffer.BindingsMarshaller.ConvertToNative(cmd), ref camXRSettings, cullResults, customPassCullResults);
		}

		public static VFXCameraBufferTypes IsCameraBufferNeeded([NotNull] Camera cam)
		{
			if ((object)cam == null)
			{
				ThrowHelper.ThrowArgumentNullException(cam, "cam");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(cam);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(cam, "cam");
			}
			return IsCameraBufferNeeded_Injected(intPtr);
		}

		public static void SetCameraBuffer([NotNull] Camera cam, VFXCameraBufferTypes type, Texture buffer, int x, int y, int width, int height)
		{
			if ((object)cam == null)
			{
				ThrowHelper.ThrowArgumentNullException(cam, "cam");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(cam);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(cam, "cam");
			}
			SetCameraBuffer_Injected(intPtr, type, Object.MarshalledUnityObject.Marshal(buffer), x, y, width, height);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetRayTracingEnabled(bool enabled);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void RequestRtasAabbConstruction();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_runtimeResources_Injected();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_renderPipeSettingsPath_Injected(out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetBatchedEffectInfo_Injected(IntPtr vfx, out VFXBatchedEffectInfo ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetBatchedEffectInfos_Injected(List<VFXBatchedEffectInfo> infos);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetBatchInfo_Injected(IntPtr vfx, uint batchIndex, out VFXBatchInfo ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PrepareCamera_Injected(IntPtr cam, [In] ref VFXCameraXRSettings camXRSettings);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_ProcessCameraCommand_Injected(IntPtr cam, IntPtr cmd, [In] ref VFXCameraXRSettings camXRSettings, IntPtr cullResults, IntPtr customPassCullResults);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern VFXCameraBufferTypes IsCameraBufferNeeded_Injected(IntPtr cam);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetCameraBuffer_Injected(IntPtr cam, VFXCameraBufferTypes type, IntPtr buffer, int x, int y, int width, int height);
	}
	[Serializable]
	[RequiredByNativeCode]
	public abstract class VFXSpawnerCallbacks : ScriptableObject
	{
		public abstract void OnPlay(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent);

		public abstract void OnUpdate(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent);

		public abstract void OnStop(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent);
	}
	public enum VFXSpawnerLoopState
	{
		Finished,
		DelayingBeforeLoop,
		Looping,
		DelayingAfterLoop
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeType(Header = "Modules/VFX/Public/VFXSpawnerState.h")]
	[RequiredByNativeCode]
	public sealed class VFXSpawnerState : IDisposable
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(VFXSpawnerState vfxSpawnerState)
			{
				return vfxSpawnerState.m_Ptr;
			}
		}

		private IntPtr m_Ptr;

		private bool m_Owner;

		private VFXEventAttribute m_WrapEventAttribute;

		public bool playing
		{
			get
			{
				return loopState == VFXSpawnerLoopState.Looping;
			}
			set
			{
				loopState = (value ? VFXSpawnerLoopState.Looping : VFXSpawnerLoopState.Finished);
			}
		}

		public bool newLoop
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_newLoop_Injected(intPtr);
			}
		}

		public VFXSpawnerLoopState loopState
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_loopState_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_loopState_Injected(intPtr, value);
			}
		}

		public float spawnCount
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_spawnCount_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_spawnCount_Injected(intPtr, value);
			}
		}

		public float deltaTime
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_deltaTime_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_deltaTime_Injected(intPtr, value);
			}
		}

		public float totalTime
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_totalTime_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_totalTime_Injected(intPtr, value);
			}
		}

		public float delayBeforeLoop
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_delayBeforeLoop_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_delayBeforeLoop_Injected(intPtr, value);
			}
		}

		public float loopDuration
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_loopDuration_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_loopDuration_Injected(intPtr, value);
			}
		}

		public float delayAfterLoop
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_delayAfterLoop_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_delayAfterLoop_Injected(intPtr, value);
			}
		}

		public int loopIndex
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_loopIndex_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_loopIndex_Injected(intPtr, value);
			}
		}

		public int loopCount
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_loopCount_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_loopCount_Injected(intPtr, value);
			}
		}

		public VFXEventAttribute vfxEventAttribute
		{
			get
			{
				if (!m_Owner && m_WrapEventAttribute != null)
				{
					return m_WrapEventAttribute;
				}
				return Internal_GetVFXEventAttribute();
			}
		}

		public VFXSpawnerState()
			: this(Internal_Create(), owner: true)
		{
		}

		internal VFXSpawnerState(IntPtr ptr, bool owner)
		{
			m_Ptr = ptr;
			m_Owner = owner;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr Internal_Create();

		[RequiredByNativeCode]
		internal static VFXSpawnerState CreateSpawnerStateWrapper()
		{
			VFXSpawnerState vFXSpawnerState = new VFXSpawnerState(IntPtr.Zero, owner: false);
			vFXSpawnerState.PrepareWrapper();
			return vFXSpawnerState;
		}

		private void PrepareWrapper()
		{
			if (m_Owner)
			{
				throw new Exception("VFXSpawnerState : SetWrapValue is reserved to CreateWrapper object");
			}
			if (m_WrapEventAttribute != null)
			{
				throw new Exception("VFXSpawnerState : Unexpected calling twice prepare wrapper");
			}
			m_WrapEventAttribute = VFXEventAttribute.CreateEventAttributeWrapper();
		}

		[RequiredByNativeCode]
		internal void SetWrapValue(IntPtr ptrToSpawnerState, IntPtr ptrToEventAttribute)
		{
			if (m_Owner)
			{
				throw new Exception("VFXSpawnerState : SetWrapValue is reserved to CreateWrapper object");
			}
			if (m_WrapEventAttribute == null)
			{
				throw new Exception("VFXSpawnerState : Missing PrepareWrapper");
			}
			m_Ptr = ptrToSpawnerState;
			m_WrapEventAttribute.SetWrapValue(ptrToEventAttribute);
		}

		internal IntPtr GetPtr()
		{
			return m_Ptr;
		}

		private void Release()
		{
			if (m_Ptr != IntPtr.Zero && m_Owner)
			{
				Internal_Destroy(m_Ptr);
			}
			m_Ptr = IntPtr.Zero;
			m_WrapEventAttribute = null;
		}

		~VFXSpawnerState()
		{
			Release();
		}

		public void Dispose()
		{
			Release();
			GC.SuppressFinalize(this);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private static extern void Internal_Destroy(IntPtr ptr);

		internal VFXEventAttribute Internal_GetVFXEventAttribute()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = Internal_GetVFXEventAttribute_Injected(intPtr);
			return (intPtr2 == (IntPtr)0) ? null : VFXEventAttribute.BindingsMarshaller.ConvertToManaged(intPtr2);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_newLoop_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern VFXSpawnerLoopState get_loopState_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_loopState_Injected(IntPtr _unity_self, VFXSpawnerLoopState value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_spawnCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_spawnCount_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_deltaTime_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_deltaTime_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_totalTime_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_totalTime_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_delayBeforeLoop_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_delayBeforeLoop_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_loopDuration_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_loopDuration_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_delayAfterLoop_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_delayAfterLoop_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_loopIndex_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_loopIndex_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_loopCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_loopCount_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Internal_GetVFXEventAttribute_Injected(IntPtr _unity_self);
	}
	[UsedByNativeCode]
	public struct VFXExposedProperty
	{
		public string name;

		public Type type;
	}
	[UsedByNativeCode]
	[NativeHeader("Modules/VFX/Public/ScriptBindings/VisualEffectAssetBindings.h")]
	[NativeHeader("Modules/VFX/Public/VisualEffectAsset.h")]
	[NativeHeader("VFXScriptingClasses.h")]
	public abstract class VisualEffectObject : Object
	{
	}
	[UsedByNativeCode]
	[NativeHeader("Modules/VFX/Public/VisualEffectAsset.h")]
	[NativeHeader("VFXScriptingClasses.h")]
	public class VisualEffectAsset : VisualEffectObject
	{
		public const string PlayEventName = "OnPlay";

		public const string StopEventName = "OnStop";

		public static readonly int PlayEventID = Shader.PropertyToID("OnPlay");

		public static readonly int StopEventID = Shader.PropertyToID("OnStop");

		[FreeFunction(Name = "VisualEffectAssetBindings::GetTextureDimension", HasExplicitThis = true)]
		public TextureDimension GetTextureDimension(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetTextureDimension_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectAssetBindings::GetExposedSpace", HasExplicitThis = true)]
		public VFXSpace GetExposedSpace(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetExposedSpace_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectAssetBindings::GetExposedProperties", HasExplicitThis = true)]
		public void GetExposedProperties([NotNull] List<VFXExposedProperty> exposedProperties)
		{
			if (exposedProperties == null)
			{
				ThrowHelper.ThrowArgumentNullException(exposedProperties, "exposedProperties");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetExposedProperties_Injected(intPtr, exposedProperties);
		}

		[FreeFunction(Name = "VisualEffectAssetBindings::GetEvents", HasExplicitThis = true)]
		public void GetEvents([NotNull] List<string> names)
		{
			if (names == null)
			{
				ThrowHelper.ThrowArgumentNullException(names, "names");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetEvents_Injected(intPtr, names);
		}

		[FreeFunction(Name = "VisualEffectAssetBindings::HasSystemFromScript", HasExplicitThis = true)]
		internal bool HasSystem(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasSystem_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectAssetBindings::GetSystemNamesFromScript", HasExplicitThis = true)]
		internal void GetSystemNames([NotNull] List<string> names)
		{
			if (names == null)
			{
				ThrowHelper.ThrowArgumentNullException(names, "names");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSystemNames_Injected(intPtr, names);
		}

		[FreeFunction(Name = "VisualEffectAssetBindings::GetParticleSystemNamesFromScript", HasExplicitThis = true)]
		internal void GetParticleSystemNames([NotNull] List<string> names)
		{
			if (names == null)
			{
				ThrowHelper.ThrowArgumentNullException(names, "names");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetParticleSystemNames_Injected(intPtr, names);
		}

		[FreeFunction(Name = "VisualEffectAssetBindings::GetOutputEventNamesFromScript", HasExplicitThis = true)]
		internal void GetOutputEventNames([NotNull] List<string> names)
		{
			if (names == null)
			{
				ThrowHelper.ThrowArgumentNullException(names, "names");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetOutputEventNames_Injected(intPtr, names);
		}

		[FreeFunction(Name = "VisualEffectAssetBindings::GetSpawnSystemNamesFromScript", HasExplicitThis = true)]
		internal void GetSpawnSystemNames([NotNull] List<string> names)
		{
			if (names == null)
			{
				ThrowHelper.ThrowArgumentNullException(names, "names");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSpawnSystemNames_Injected(intPtr, names);
		}

		public TextureDimension GetTextureDimension(string name)
		{
			return GetTextureDimension(Shader.PropertyToID(name));
		}

		public VFXSpace GetExposedSpace(string name)
		{
			return GetExposedSpace(Shader.PropertyToID(name));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern TextureDimension GetTextureDimension_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern VFXSpace GetExposedSpace_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetExposedProperties_Injected(IntPtr _unity_self, List<VFXExposedProperty> exposedProperties);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetEvents_Injected(IntPtr _unity_self, List<string> names);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasSystem_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSystemNames_Injected(IntPtr _unity_self, List<string> names);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetParticleSystemNames_Injected(IntPtr _unity_self, List<string> names);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetOutputEventNames_Injected(IntPtr _unity_self, List<string> names);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSpawnSystemNames_Injected(IntPtr _unity_self, List<string> names);
	}
	public struct VFXOutputEventArgs
	{
		public int nameId { get; }

		public VFXEventAttribute eventAttribute { get; }

		public VFXOutputEventArgs(int nameId, VFXEventAttribute eventAttribute)
		{
			this.nameId = nameId;
			this.eventAttribute = eventAttribute;
		}
	}
	[NativeHeader("Modules/VFX/Public/ScriptBindings/VisualEffectBindings.h")]
	[NativeHeader("Modules/VFX/Public/VisualEffect.h")]
	[RequireComponent(typeof(Transform))]
	public class VisualEffect : Behaviour
	{
		internal enum VFXCPUEffectMarkers
		{
			FullUpdate,
			ProcessUpdate,
			EvaluateExpressions
		}

		private VFXEventAttribute m_cachedEventAttribute;

		public Action<VFXOutputEventArgs> outputEventReceived;

		public bool pause
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_pause_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_pause_Injected(intPtr, value);
			}
		}

		public float playRate
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_playRate_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_playRate_Injected(intPtr, value);
			}
		}

		public uint startSeed
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_startSeed_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_startSeed_Injected(intPtr, value);
			}
		}

		public bool resetSeedOnPlay
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_resetSeedOnPlay_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_resetSeedOnPlay_Injected(intPtr, value);
			}
		}

		public int initialEventID
		{
			[FreeFunction(Name = "VisualEffectBindings::GetInitialEventID", HasExplicitThis = true)]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_initialEventID_Injected(intPtr);
			}
			[FreeFunction(Name = "VisualEffectBindings::SetInitialEventID", HasExplicitThis = true)]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_initialEventID_Injected(intPtr, value);
			}
		}

		public unsafe string initialEventName
		{
			[FreeFunction(Name = "VisualEffectBindings::GetInitialEventName", HasExplicitThis = true)]
			get
			{
				ManagedSpanWrapper ret = default(ManagedSpanWrapper);
				string stringAndDispose;
				try
				{
					IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
					if (intPtr == (IntPtr)0)
					{
						ThrowHelper.ThrowNullReferenceException(this);
					}
					get_initialEventName_Injected(intPtr, out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
			[FreeFunction(Name = "VisualEffectBindings::SetInitialEventName", HasExplicitThis = true)]
			set
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
					if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
					{
						ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
						fixed (char* begin = readOnlySpan)
						{
							managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
							set_initialEventName_Injected(intPtr, ref managedSpanWrapper);
							return;
						}
					}
					set_initialEventName_Injected(intPtr, ref managedSpanWrapper);
				}
				finally
				{
				}
			}
		}

		public bool culled
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_culled_Injected(intPtr);
			}
		}

		public VisualEffectAsset visualEffectAsset
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<VisualEffectAsset>(get_visualEffectAsset_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_visualEffectAsset_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public int aliveParticleCount
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_aliveParticleCount_Injected(intPtr);
			}
		}

		internal float time
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_time_Injected(intPtr);
			}
		}

		public VFXEventAttribute CreateVFXEventAttribute()
		{
			if (visualEffectAsset == null)
			{
				return null;
			}
			return VFXEventAttribute.Internal_InstanciateVFXEventAttribute(visualEffectAsset);
		}

		private void CheckValidVFXEventAttribute(VFXEventAttribute eventAttribute)
		{
			if (eventAttribute != null && eventAttribute.vfxAsset != visualEffectAsset)
			{
				throw new InvalidOperationException("Invalid VFXEventAttribute provided to VisualEffect. It has been created with another VisualEffectAsset. Use CreateVFXEventAttribute.");
			}
		}

		[FreeFunction(Name = "VisualEffectBindings::SendEventFromScript", HasExplicitThis = true)]
		private void SendEventFromScript(int eventNameID, VFXEventAttribute eventAttribute)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SendEventFromScript_Injected(intPtr, eventNameID, (eventAttribute == null) ? ((IntPtr)0) : VFXEventAttribute.BindingsMarshaller.ConvertToNative(eventAttribute));
		}

		public void SendEvent(int eventNameID, VFXEventAttribute eventAttribute)
		{
			CheckValidVFXEventAttribute(eventAttribute);
			SendEventFromScript(eventNameID, eventAttribute);
		}

		public void SendEvent(string eventName, VFXEventAttribute eventAttribute)
		{
			SendEvent(Shader.PropertyToID(eventName), eventAttribute);
		}

		public void SendEvent(int eventNameID)
		{
			SendEventFromScript(eventNameID, null);
		}

		public void SendEvent(string eventName)
		{
			SendEvent(Shader.PropertyToID(eventName), null);
		}

		public void Play(VFXEventAttribute eventAttribute)
		{
			SendEvent(VisualEffectAsset.PlayEventID, eventAttribute);
		}

		public void Play()
		{
			SendEvent(VisualEffectAsset.PlayEventID);
		}

		public void Stop(VFXEventAttribute eventAttribute)
		{
			SendEvent(VisualEffectAsset.StopEventID, eventAttribute);
		}

		public void Stop()
		{
			SendEvent(VisualEffectAsset.StopEventID);
		}

		public void Reinit()
		{
			Reinit(true);
		}

		internal void Reinit(bool sendInitialEventAndPrewarm = true)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Reinit_Injected(intPtr, sendInitialEventAndPrewarm);
		}

		public void AdvanceOneFrame()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AdvanceOneFrame_Injected(intPtr);
		}

		internal void RecreateData()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			RecreateData_Injected(intPtr);
		}

		[NativeConditional("ENABLE_PROFILER")]
		[FreeFunction(Name = "VisualEffectBindings::GetGPUTaskMarkerName", HasExplicitThis = true, ThrowsException = true)]
		private string GetGPUTaskMarkerName(int nameID, int taskIndex)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetGPUTaskMarkerName_Injected(intPtr, nameID, taskIndex, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[NativeConditional("ENABLE_PROFILER")]
		[FreeFunction(Name = "VisualEffectBindings::GetCPUEffectMarkerName", HasExplicitThis = true, ThrowsException = true)]
		internal string GetCPUEffectMarkerName(int markerIndex)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetCPUEffectMarkerName_Injected(intPtr, markerIndex, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[FreeFunction(Name = "VisualEffectBindings::GetCPUSystemMarkerName", HasExplicitThis = true, ThrowsException = true)]
		[NativeConditional("ENABLE_PROFILER")]
		private string GetCPUSystemMarkerName(int nameID)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetCPUSystemMarkerName_Injected(intPtr, nameID, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[FreeFunction(Name = "VisualEffectBindings::RegisterForProfiling", HasExplicitThis = true, ThrowsException = false)]
		[NativeConditional("ENABLE_PROFILER")]
		internal void RegisterForProfiling()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			RegisterForProfiling_Injected(intPtr);
		}

		[NativeConditional("ENABLE_PROFILER")]
		[FreeFunction(Name = "VisualEffectBindings::UnregisterForProfiling", HasExplicitThis = true, ThrowsException = false)]
		internal void UnregisterForProfiling()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			UnregisterForProfiling_Injected(intPtr);
		}

		[NativeConditional("ENABLE_PROFILER")]
		[FreeFunction(Name = "VisualEffectBindings::IsRegisteredForProfiling", HasExplicitThis = true, ThrowsException = false)]
		internal bool IsRegisteredForProfiling()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IsRegisteredForProfiling_Injected(intPtr);
		}

		[FreeFunction(Name = "VisualEffectBindings::ResetOverrideFromScript", HasExplicitThis = true)]
		public void ResetOverride(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ResetOverride_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::GetTextureDimensionFromScript", HasExplicitThis = true)]
		public TextureDimension GetTextureDimension(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetTextureDimension_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<bool>", HasExplicitThis = true)]
		public bool HasBool(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasBool_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<int>", HasExplicitThis = true)]
		public bool HasInt(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasInt_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<UInt32>", HasExplicitThis = true)]
		public bool HasUInt(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasUInt_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<float>", HasExplicitThis = true)]
		public bool HasFloat(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasFloat_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<Vector2f>", HasExplicitThis = true)]
		public bool HasVector2(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasVector2_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<Vector3f>", HasExplicitThis = true)]
		public bool HasVector3(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasVector3_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<Vector4f>", HasExplicitThis = true)]
		public bool HasVector4(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasVector4_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<Matrix4x4f>", HasExplicitThis = true)]
		public bool HasMatrix4x4(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasMatrix4x4_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<Texture*>", HasExplicitThis = true)]
		public bool HasTexture(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasTexture_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<AnimationCurve*>", HasExplicitThis = true)]
		public bool HasAnimationCurve(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasAnimationCurve_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<Gradient*>", HasExplicitThis = true)]
		public bool HasGradient(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasGradient_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<Mesh*>", HasExplicitThis = true)]
		public bool HasMesh(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasMesh_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<SkinnedMeshRenderer*>", HasExplicitThis = true)]
		public bool HasSkinnedMeshRenderer(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasSkinnedMeshRenderer_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::HasValueFromScript<GraphicsBuffer*>", HasExplicitThis = true)]
		public bool HasGraphicsBuffer(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasGraphicsBuffer_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<bool>", HasExplicitThis = true)]
		public void SetBool(int nameID, bool b)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetBool_Injected(intPtr, nameID, b);
		}

		[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<int>", HasExplicitThis = true)]
		public void SetInt(int nameID, int i)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetInt_Injected(intPtr, nameID, i);
		}

		[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<UInt32>", HasExplicitThis = true)]
		public void SetUInt(int nameID, uint i)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetUInt_Injected(intPtr, nameID, i);
		}

		[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<float>", HasExplicitThis = true)]
		public void SetFloat(int nameID, float f)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetFloat_Injected(intPtr, nameID, f);
		}

		[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<Vector2f>", HasExplicitThis = true)]
		public void SetVector2(int nameID, Vector2 v)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetVector2_Injected(intPtr, nameID, ref v);
		}

		[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<Vector3f>", HasExplicitThis = true)]
		public void SetVector3(int nameID, Vector3 v)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetVector3_Injected(intPtr, nameID, ref v);
		}

		[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<Vector4f>", HasExplicitThis = true)]
		public void SetVector4(int nameID, Vector4 v)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetVector4_Injected(intPtr, nameID, ref v);
		}

		[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<Matrix4x4f>", HasExplicitThis = true)]
		public void SetMatrix4x4(int nameID, Matrix4x4 v)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetMatrix4x4_Injected(intPtr, nameID, ref v);
		}

		[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<Texture*>", HasExplicitThis = true)]
		public void SetTexture(int nameID, [NotNull] Texture t)
		{
			if ((object)t == null)
			{
				ThrowHelper.ThrowArgumentNullException(t, "t");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(t);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(t, "t");
			}
			SetTexture_Injected(intPtr, nameID, intPtr2);
		}

		[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<AnimationCurve*>", HasExplicitThis = true)]
		public void SetAnimationCurve(int nameID, [NotNull] AnimationCurve c)
		{
			if (c == null)
			{
				ThrowHelper.ThrowArgumentNullException(c, "c");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = AnimationCurve.BindingsMarshaller.ConvertToNative(c);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(c, "c");
			}
			SetAnimationCurve_Injected(intPtr, nameID, intPtr2);
		}

		[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<Gradient*>", HasExplicitThis = true)]
		public void SetGradient(int nameID, [NotNull] Gradient g)
		{
			if (g == null)
			{
				ThrowHelper.ThrowArgumentNullException(g, "g");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = Gradient.BindingsMarshaller.ConvertToNative(g);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(g, "g");
			}
			SetGradient_Injected(intPtr, nameID, intPtr2);
		}

		[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<Mesh*>", HasExplicitThis = true)]
		public void SetMesh(int nameID, [NotNull] Mesh m)
		{
			if ((object)m == null)
			{
				ThrowHelper.ThrowArgumentNullException(m, "m");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(m);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(m, "m");
			}
			SetMesh_Injected(intPtr, nameID, intPtr2);
		}

		[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<SkinnedMeshRenderer*>", HasExplicitThis = true)]
		public void SetSkinnedMeshRenderer(int nameID, SkinnedMeshRenderer m)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetSkinnedMeshRenderer_Injected(intPtr, nameID, MarshalledUnityObject.Marshal(m));
		}

		[FreeFunction(Name = "VisualEffectBindings::SetValueFromScript<GraphicsBuffer*>", HasExplicitThis = true)]
		public void SetGraphicsBuffer(int nameID, GraphicsBuffer g)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetGraphicsBuffer_Injected(intPtr, nameID, (g == null) ? ((IntPtr)0) : GraphicsBuffer.BindingsMarshaller.ConvertToNative(g));
		}

		[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<bool>", HasExplicitThis = true)]
		public bool GetBool(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetBool_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<int>", HasExplicitThis = true)]
		public int GetInt(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetInt_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<UInt32>", HasExplicitThis = true)]
		public uint GetUInt(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetUInt_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<float>", HasExplicitThis = true)]
		public float GetFloat(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetFloat_Injected(intPtr, nameID);
		}

		[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<Vector2f>", HasExplicitThis = true)]
		public Vector2 GetVector2(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetVector2_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<Vector3f>", HasExplicitThis = true)]
		public Vector3 GetVector3(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetVector3_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<Vector4f>", HasExplicitThis = true)]
		public Vector4 GetVector4(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetVector4_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<Matrix4x4f>", HasExplicitThis = true)]
		public Matrix4x4 GetMatrix4x4(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetMatrix4x4_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<Texture*>", HasExplicitThis = true)]
		public Texture GetTexture(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Texture>(GetTexture_Injected(intPtr, nameID));
		}

		[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<Mesh*>", HasExplicitThis = true)]
		public Mesh GetMesh(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Mesh>(GetMesh_Injected(intPtr, nameID));
		}

		[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<SkinnedMeshRenderer*>", HasExplicitThis = true)]
		public SkinnedMeshRenderer GetSkinnedMeshRenderer(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<SkinnedMeshRenderer>(GetSkinnedMeshRenderer_Injected(intPtr, nameID));
		}

		[FreeFunction(Name = "VisualEffectBindings::GetValueFromScript<GraphicsBuffer*>", HasExplicitThis = true)]
		internal GraphicsBuffer GetGraphicsBuffer(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr graphicsBuffer_Injected = GetGraphicsBuffer_Injected(intPtr, nameID);
			return (graphicsBuffer_Injected == (IntPtr)0) ? null : GraphicsBuffer.BindingsMarshaller.ConvertToManaged(graphicsBuffer_Injected);
		}

		public Gradient GetGradient(int nameID)
		{
			Gradient gradient = new Gradient();
			Internal_GetGradient(nameID, gradient);
			return gradient;
		}

		[FreeFunction(Name = "VisualEffectBindings::Internal_GetGradientFromScript", HasExplicitThis = true)]
		private void Internal_GetGradient(int nameID, Gradient gradient)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Internal_GetGradient_Injected(intPtr, nameID, (gradient == null) ? ((IntPtr)0) : Gradient.BindingsMarshaller.ConvertToNative(gradient));
		}

		public AnimationCurve GetAnimationCurve(int nameID)
		{
			AnimationCurve animationCurve = new AnimationCurve();
			Internal_GetAnimationCurve(nameID, animationCurve);
			return animationCurve;
		}

		[FreeFunction(Name = "VisualEffectBindings::Internal_GetAnimationCurveFromScript", HasExplicitThis = true)]
		private void Internal_GetAnimationCurve(int nameID, AnimationCurve curve)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Internal_GetAnimationCurve_Injected(intPtr, nameID, (curve == null) ? ((IntPtr)0) : AnimationCurve.BindingsMarshaller.ConvertToNative(curve));
		}

		[FreeFunction(Name = "VisualEffectBindings::GetParticleSystemInfo", HasExplicitThis = true, ThrowsException = true)]
		public VFXParticleSystemInfo GetParticleSystemInfo(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetParticleSystemInfo_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		[FreeFunction(Name = "VisualEffectBindings::GetSpawnSystemInfo", HasExplicitThis = true, ThrowsException = true)]
		private void GetSpawnSystemInfo(int nameID, IntPtr spawnerState)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSpawnSystemInfo_Injected(intPtr, nameID, spawnerState);
		}

		public bool HasAnySystemAwake()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasAnySystemAwake_Injected(intPtr);
		}

		[FreeFunction(Name = "VisualEffectBindings::GetComputedBounds", HasExplicitThis = true)]
		internal Bounds GetComputedBounds(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetComputedBounds_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		[FreeFunction(Name = "VisualEffectBindings::GetCurrentBoundsPadding", HasExplicitThis = true)]
		internal Vector3 GetCurrentBoundsPadding(int nameID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetCurrentBoundsPadding_Injected(intPtr, nameID, out var ret);
			return ret;
		}

		public void GetSpawnSystemInfo(int nameID, VFXSpawnerState spawnState)
		{
			if (spawnState == null)
			{
				throw new NullReferenceException("GetSpawnSystemInfo expects a non null VFXSpawnerState.");
			}
			IntPtr ptr = spawnState.GetPtr();
			if (ptr == IntPtr.Zero)
			{
				throw new NullReferenceException("GetSpawnSystemInfo use an unexpected not owned VFXSpawnerState.");
			}
			GetSpawnSystemInfo(nameID, ptr);
		}

		public VFXSpawnerState GetSpawnSystemInfo(int nameID)
		{
			VFXSpawnerState vFXSpawnerState = new VFXSpawnerState();
			GetSpawnSystemInfo(nameID, vFXSpawnerState);
			return vFXSpawnerState;
		}

		public bool HasSystem(int nameID)
		{
			VisualEffectAsset visualEffectAsset = this.visualEffectAsset;
			return visualEffectAsset != null && visualEffectAsset.HasSystem(nameID);
		}

		public void GetSystemNames(List<string> names)
		{
			if (names == null)
			{
				throw new ArgumentNullException("names");
			}
			VisualEffectAsset visualEffectAsset = this.visualEffectAsset;
			if ((bool)visualEffectAsset)
			{
				visualEffectAsset.GetSystemNames(names);
			}
			else
			{
				names.Clear();
			}
		}

		public void GetParticleSystemNames(List<string> names)
		{
			if (names == null)
			{
				throw new ArgumentNullException("names");
			}
			VisualEffectAsset visualEffectAsset = this.visualEffectAsset;
			if ((bool)visualEffectAsset)
			{
				visualEffectAsset.GetParticleSystemNames(names);
			}
			else
			{
				names.Clear();
			}
		}

		public void GetOutputEventNames(List<string> names)
		{
			if (names == null)
			{
				throw new ArgumentNullException("names");
			}
			VisualEffectAsset visualEffectAsset = this.visualEffectAsset;
			if ((bool)visualEffectAsset)
			{
				visualEffectAsset.GetOutputEventNames(names);
			}
			else
			{
				names.Clear();
			}
		}

		public void GetSpawnSystemNames(List<string> names)
		{
			if (names == null)
			{
				throw new ArgumentNullException("names");
			}
			VisualEffectAsset visualEffectAsset = this.visualEffectAsset;
			if ((bool)visualEffectAsset)
			{
				visualEffectAsset.GetSpawnSystemNames(names);
			}
			else
			{
				names.Clear();
			}
		}

		public void ResetOverride(string name)
		{
			ResetOverride(Shader.PropertyToID(name));
		}

		public bool HasInt(string name)
		{
			return HasInt(Shader.PropertyToID(name));
		}

		public bool HasUInt(string name)
		{
			return HasUInt(Shader.PropertyToID(name));
		}

		public bool HasFloat(string name)
		{
			return HasFloat(Shader.PropertyToID(name));
		}

		public bool HasVector2(string name)
		{
			return HasVector2(Shader.PropertyToID(name));
		}

		public bool HasVector3(string name)
		{
			return HasVector3(Shader.PropertyToID(name));
		}

		public bool HasVector4(string name)
		{
			return HasVector4(Shader.PropertyToID(name));
		}

		public bool HasMatrix4x4(string name)
		{
			return HasMatrix4x4(Shader.PropertyToID(name));
		}

		public bool HasTexture(string name)
		{
			return HasTexture(Shader.PropertyToID(name));
		}

		public TextureDimension GetTextureDimension(string name)
		{
			return GetTextureDimension(Shader.PropertyToID(name));
		}

		public bool HasAnimationCurve(string name)
		{
			return HasAnimationCurve(Shader.PropertyToID(name));
		}

		public bool HasGradient(string name)
		{
			return HasGradient(Shader.PropertyToID(name));
		}

		public bool HasMesh(string name)
		{
			return HasMesh(Shader.PropertyToID(name));
		}

		public bool HasSkinnedMeshRenderer(string name)
		{
			return HasSkinnedMeshRenderer(Shader.PropertyToID(name));
		}

		public bool HasGraphicsBuffer(string name)
		{
			return HasGraphicsBuffer(Shader.PropertyToID(name));
		}

		public bool HasBool(string name)
		{
			return HasBool(Shader.PropertyToID(name));
		}

		public void SetInt(string name, int i)
		{
			SetInt(Shader.PropertyToID(name), i);
		}

		public void SetUInt(string name, uint i)
		{
			SetUInt(Shader.PropertyToID(name), i);
		}

		public void SetFloat(string name, float f)
		{
			SetFloat(Shader.PropertyToID(name), f);
		}

		public void SetVector2(string name, Vector2 v)
		{
			SetVector2(Shader.PropertyToID(name), v);
		}

		public void SetVector3(string name, Vector3 v)
		{
			SetVector3(Shader.PropertyToID(name), v);
		}

		public void SetVector4(string name, Vector4 v)
		{
			SetVector4(Shader.PropertyToID(name), v);
		}

		public void SetMatrix4x4(string name, Matrix4x4 v)
		{
			SetMatrix4x4(Shader.PropertyToID(name), v);
		}

		public void SetTexture(string name, Texture t)
		{
			SetTexture(Shader.PropertyToID(name), t);
		}

		public void SetAnimationCurve(string name, AnimationCurve c)
		{
			SetAnimationCurve(Shader.PropertyToID(name), c);
		}

		public void SetGradient(string name, Gradient g)
		{
			SetGradient(Shader.PropertyToID(name), g);
		}

		public void SetMesh(string name, Mesh m)
		{
			SetMesh(Shader.PropertyToID(name), m);
		}

		public void SetSkinnedMeshRenderer(string name, SkinnedMeshRenderer m)
		{
			SetSkinnedMeshRenderer(Shader.PropertyToID(name), m);
		}

		public void SetGraphicsBuffer(string name, GraphicsBuffer g)
		{
			SetGraphicsBuffer(Shader.PropertyToID(name), g);
		}

		public void SetBool(string name, bool b)
		{
			SetBool(Shader.PropertyToID(name), b);
		}

		public int GetInt(string name)
		{
			return GetInt(Shader.PropertyToID(name));
		}

		public uint GetUInt(string name)
		{
			return GetUInt(Shader.PropertyToID(name));
		}

		public float GetFloat(string name)
		{
			return GetFloat(Shader.PropertyToID(name));
		}

		public Vector2 GetVector2(string name)
		{
			return GetVector2(Shader.PropertyToID(name));
		}

		public Vector3 GetVector3(string name)
		{
			return GetVector3(Shader.PropertyToID(name));
		}

		public Vector4 GetVector4(string name)
		{
			return GetVector4(Shader.PropertyToID(name));
		}

		public Matrix4x4 GetMatrix4x4(string name)
		{
			return GetMatrix4x4(Shader.PropertyToID(name));
		}

		public Texture GetTexture(string name)
		{
			return GetTexture(Shader.PropertyToID(name));
		}

		public Mesh GetMesh(string name)
		{
			return GetMesh(Shader.PropertyToID(name));
		}

		public SkinnedMeshRenderer GetSkinnedMeshRenderer(string name)
		{
			return GetSkinnedMeshRenderer(Shader.PropertyToID(name));
		}

		internal GraphicsBuffer GetGraphicsBuffer(string name)
		{
			return GetGraphicsBuffer(Shader.PropertyToID(name));
		}

		public bool GetBool(string name)
		{
			return GetBool(Shader.PropertyToID(name));
		}

		public AnimationCurve GetAnimationCurve(string name)
		{
			return GetAnimationCurve(Shader.PropertyToID(name));
		}

		public Gradient GetGradient(string name)
		{
			return GetGradient(Shader.PropertyToID(name));
		}

		public bool HasSystem(string name)
		{
			return HasSystem(Shader.PropertyToID(name));
		}

		public VFXParticleSystemInfo GetParticleSystemInfo(string name)
		{
			return GetParticleSystemInfo(Shader.PropertyToID(name));
		}

		internal string GetGPUTaskMarkerName(string systemName, int taskIndex)
		{
			return GetGPUTaskMarkerName(Shader.PropertyToID(systemName), taskIndex);
		}

		internal string GetCPUSystemMarkerName(string systemName)
		{
			return GetCPUSystemMarkerName(Shader.PropertyToID(systemName));
		}

		internal string GetCPUEffectMarkerName(VFXCPUEffectMarkers markerId)
		{
			return GetCPUEffectMarkerName((int)markerId);
		}

		public VFXSpawnerState GetSpawnSystemInfo(string name)
		{
			return GetSpawnSystemInfo(Shader.PropertyToID(name));
		}

		internal Bounds GetComputedBounds(string name)
		{
			return GetComputedBounds(Shader.PropertyToID(name));
		}

		internal Vector3 GetCurrentBoundsPadding(string name)
		{
			return GetCurrentBoundsPadding(Shader.PropertyToID(name));
		}

		public void Simulate(float stepDeltaTime, uint stepCount = 1u)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Simulate_Injected(intPtr, stepDeltaTime, stepCount);
		}

		[RequiredByNativeCode]
		private static VFXEventAttribute InvokeGetCachedEventAttributeForOutputEvent_Internal(VisualEffect source)
		{
			if (source.outputEventReceived == null)
			{
				return null;
			}
			if (source.m_cachedEventAttribute == null)
			{
				source.m_cachedEventAttribute = source.CreateVFXEventAttribute();
			}
			return source.m_cachedEventAttribute;
		}

		[RequiredByNativeCode]
		private static void InvokeOutputEventReceived_Internal(VisualEffect source, int eventNameId)
		{
			VFXOutputEventArgs obj = new VFXOutputEventArgs(eventNameId, source.m_cachedEventAttribute);
			source.outputEventReceived(obj);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_pause_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_pause_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_playRate_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_playRate_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint get_startSeed_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_startSeed_Injected(IntPtr _unity_self, uint value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_resetSeedOnPlay_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_resetSeedOnPlay_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_initialEventID_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_initialEventID_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_initialEventName_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_initialEventName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_culled_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_visualEffectAsset_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_visualEffectAsset_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SendEventFromScript_Injected(IntPtr _unity_self, int eventNameID, IntPtr eventAttribute);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Reinit_Injected(IntPtr _unity_self, bool sendInitialEventAndPrewarm);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AdvanceOneFrame_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RecreateData_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetGPUTaskMarkerName_Injected(IntPtr _unity_self, int nameID, int taskIndex, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetCPUEffectMarkerName_Injected(IntPtr _unity_self, int markerIndex, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetCPUSystemMarkerName_Injected(IntPtr _unity_self, int nameID, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RegisterForProfiling_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UnregisterForProfiling_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsRegisteredForProfiling_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResetOverride_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern TextureDimension GetTextureDimension_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasBool_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasInt_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasUInt_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasFloat_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasVector2_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasVector3_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasVector4_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasMatrix4x4_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasTexture_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasAnimationCurve_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasGradient_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasMesh_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasSkinnedMeshRenderer_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasGraphicsBuffer_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetBool_Injected(IntPtr _unity_self, int nameID, bool b);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetInt_Injected(IntPtr _unity_self, int nameID, int i);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetUInt_Injected(IntPtr _unity_self, int nameID, uint i);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFloat_Injected(IntPtr _unity_self, int nameID, float f);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetVector2_Injected(IntPtr _unity_self, int nameID, [In] ref Vector2 v);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetVector3_Injected(IntPtr _unity_self, int nameID, [In] ref Vector3 v);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetVector4_Injected(IntPtr _unity_self, int nameID, [In] ref Vector4 v);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetMatrix4x4_Injected(IntPtr _unity_self, int nameID, [In] ref Matrix4x4 v);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTexture_Injected(IntPtr _unity_self, int nameID, IntPtr t);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetAnimationCurve_Injected(IntPtr _unity_self, int nameID, IntPtr c);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetGradient_Injected(IntPtr _unity_self, int nameID, IntPtr g);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetMesh_Injected(IntPtr _unity_self, int nameID, IntPtr m);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSkinnedMeshRenderer_Injected(IntPtr _unity_self, int nameID, IntPtr m);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetGraphicsBuffer_Injected(IntPtr _unity_self, int nameID, IntPtr g);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetBool_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetInt_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetUInt_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetFloat_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetVector2_Injected(IntPtr _unity_self, int nameID, out Vector2 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetVector3_Injected(IntPtr _unity_self, int nameID, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetVector4_Injected(IntPtr _unity_self, int nameID, out Vector4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetMatrix4x4_Injected(IntPtr _unity_self, int nameID, out Matrix4x4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetTexture_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetMesh_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetSkinnedMeshRenderer_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetGraphicsBuffer_Injected(IntPtr _unity_self, int nameID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_GetGradient_Injected(IntPtr _unity_self, int nameID, IntPtr gradient);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_GetAnimationCurve_Injected(IntPtr _unity_self, int nameID, IntPtr curve);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetParticleSystemInfo_Injected(IntPtr _unity_self, int nameID, out VFXParticleSystemInfo ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSpawnSystemInfo_Injected(IntPtr _unity_self, int nameID, IntPtr spawnerState);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasAnySystemAwake_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetComputedBounds_Injected(IntPtr _unity_self, int nameID, out Bounds ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetCurrentBoundsPadding_Injected(IntPtr _unity_self, int nameID, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_aliveParticleCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_time_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Simulate_Injected(IntPtr _unity_self, float stepDeltaTime, uint stepCount);
	}
	[RejectDragAndDropMaterial]
	[NativeType(Header = "Modules/VFX/Public/VFXRenderer.h")]
	[RequiredByNativeCode]
	public sealed class VFXRenderer : Renderer
	{
		[UnityEngine.Scripting.RequiredMember]
		public VFXRenderer()
		{
		}
	}
	[NativeHeader("Modules/VFX/Public/Systems/VFXParticleSystem.h")]
	[UsedByNativeCode]
	public struct VFXParticleSystemInfo(uint aliveCount, uint capacity, bool sleeping, Bounds bounds)
	{
		public uint aliveCount = aliveCount;

		public uint capacity = capacity;

		public bool sleeping = sleeping;

		public Bounds bounds = bounds;
	}
}
