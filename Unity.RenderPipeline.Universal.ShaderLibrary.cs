using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

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
			FilePathsData = new byte[215]
			{
				0, 0, 0, 2, 0, 0, 0, 99, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				114, 101, 110, 100, 101, 114, 45, 112, 105, 112,
				101, 108, 105, 110, 101, 115, 46, 117, 110, 105,
				118, 101, 114, 115, 97, 108, 64, 98, 99, 54,
				102, 51, 53, 50, 98, 101, 54, 55, 50, 92,
				83, 104, 97, 100, 101, 114, 76, 105, 98, 114,
				97, 114, 121, 92, 68, 101, 112, 114, 101, 99,
				97, 116, 101, 100, 46, 99, 115, 0, 0, 0,
				2, 0, 0, 0, 100, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 117, 110, 105, 116, 121, 46, 114, 101, 110,
				100, 101, 114, 45, 112, 105, 112, 101, 108, 105,
				110, 101, 115, 46, 117, 110, 105, 118, 101, 114,
				115, 97, 108, 64, 98, 99, 54, 102, 51, 53,
				50, 98, 101, 54, 55, 50, 92, 83, 104, 97,
				100, 101, 114, 76, 105, 98, 114, 97, 114, 121,
				92, 83, 104, 97, 100, 101, 114, 84, 121, 112,
				101, 115, 46, 99, 115
			},
			TypesData = new byte[213]
			{
				1, 0, 0, 0, 43, 85, 110, 105, 116, 121,
				69, 110, 103, 105, 110, 101, 46, 82, 101, 110,
				100, 101, 114, 105, 110, 103, 46, 85, 110, 105,
				118, 101, 114, 115, 97, 108, 124, 83, 104, 97,
				100, 101, 114, 73, 110, 112, 117, 116, 0, 0,
				0, 0, 54, 85, 110, 105, 116, 121, 69, 110,
				103, 105, 110, 101, 46, 82, 101, 110, 100, 101,
				114, 105, 110, 103, 46, 85, 110, 105, 118, 101,
				114, 115, 97, 108, 46, 83, 104, 97, 100, 101,
				114, 73, 110, 112, 117, 116, 124, 83, 104, 97,
				100, 111, 119, 68, 97, 116, 97, 1, 0, 0,
				0, 43, 85, 110, 105, 116, 121, 69, 110, 103,
				105, 110, 101, 46, 82, 101, 110, 100, 101, 114,
				105, 110, 103, 46, 85, 110, 105, 118, 101, 114,
				115, 97, 108, 124, 83, 104, 97, 100, 101, 114,
				73, 110, 112, 117, 116, 0, 0, 0, 0, 53,
				85, 110, 105, 116, 121, 69, 110, 103, 105, 110,
				101, 46, 82, 101, 110, 100, 101, 114, 105, 110,
				103, 46, 85, 110, 105, 118, 101, 114, 115, 97,
				108, 46, 83, 104, 97, 100, 101, 114, 73, 110,
				112, 117, 116, 124, 76, 105, 103, 104, 116, 68,
				97, 116, 97
			},
			TotalFiles = 2,
			TotalTypes = 4,
			IsEditorOnly = false
		};
	}
}
namespace UnityEngine.Rendering.Universal;

[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum DebugMaterialMode
{
	None,
	Albedo,
	Specular,
	Alpha,
	Smoothness,
	AmbientOcclusion,
	Emission,
	NormalWorldSpace,
	NormalTangentSpace,
	LightingComplexity,
	Metallic,
	SpriteMask,
	RenderingLayerMasks
}
[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum DebugVertexAttributeMode
{
	None,
	Texcoord0,
	Texcoord1,
	Texcoord2,
	Texcoord3,
	Color,
	Tangent,
	Normal
}
[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum DebugMaterialValidationMode
{
	None,
	Albedo,
	Metallic
}
[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum DebugFullScreenMode
{
	None,
	Depth,
	[InspectorName("Motion Vector (100x, normalized)")]
	MotionVector,
	AdditionalLightsShadowMap,
	MainLightShadowMap,
	AdditionalLightsCookieAtlas,
	ReflectionProbeAtlas,
	STP
}
[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum DebugSceneOverrideMode
{
	None,
	Overdraw,
	Wireframe,
	SolidWireframe,
	ShadedWireframe
}
public enum DebugOverdrawMode
{
	None,
	Opaque,
	Transparent,
	All
}
[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum DebugMipInfoMode
{
	None,
	MipStreamingPerformance,
	MipStreamingStatus,
	MipStreamingActivity,
	MipStreamingPriority,
	MipCount,
	MipRatio
}
[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum DebugMipMapStatusMode
{
	Material,
	Texture
}
[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum DebugMipMapModeTerrainTexture
{
	Control,
	[InspectorName("Layer 0 - Diffuse")]
	Layer0,
	[InspectorName("Layer 1 - Diffuse")]
	Layer1,
	[InspectorName("Layer 2 - Diffuse")]
	Layer2,
	[InspectorName("Layer 3 - Diffuse")]
	Layer3
}
[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum DebugPostProcessingMode
{
	Disabled,
	Auto,
	Enabled
}
[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum DebugValidationMode
{
	None,
	[InspectorName("Highlight NaN, Inf and Negative Values")]
	HighlightNanInfNegative,
	[InspectorName("Highlight Values Outside Range")]
	HighlightOutsideOfRange
}
[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum PixelValidationChannels
{
	RGB,
	R,
	G,
	B,
	A
}
[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum DebugLightingMode
{
	None,
	ShadowCascades,
	LightingWithoutNormalMaps,
	LightingWithNormalMaps,
	Reflections,
	ReflectionsWithSmoothness,
	GlobalIllumination
}
[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum HDRDebugMode
{
	None,
	GamutView,
	GamutClip,
	ValuesAbovePaperWhite
}
[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
[Flags]
public enum DebugLightingFeatureFlags
{
	None = 0,
	GlobalIllumination = 1,
	MainLight = 2,
	AdditionalLights = 4,
	VertexLighting = 8,
	Emission = 0x10,
	AmbientOcclusion = 0x20
}
public static class ShaderInput
{
	[Obsolete("ShaderInput.ShadowData was deprecated. Shadow slice matrices and per-light shadow parameters are now passed to the GPU using entries in buffers m_AdditionalLightsWorldToShadow_SSBO and m_AdditionalShadowParams_SSBO", true)]
	public struct ShadowData
	{
		public Matrix4x4 worldToShadowMatrix;

		public Vector4 shadowParams;
	}

	[GenerateHLSL(PackingRules.Exact, false, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@bc6f352be672\\ShaderLibrary\\ShaderTypes.cs")]
	public struct LightData
	{
		public Vector4 position;

		public Vector4 color;

		public Vector4 attenuation;

		public Vector4 spotDirection;

		public Vector4 occlusionProbeChannels;

		public uint layerMask;
	}
}
