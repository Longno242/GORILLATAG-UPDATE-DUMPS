using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
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
			FilePathsData = new byte[110]
			{
				0, 0, 0, 1, 0, 0, 0, 102, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				114, 101, 110, 100, 101, 114, 45, 112, 105, 112,
				101, 108, 105, 110, 101, 115, 46, 117, 110, 105,
				118, 101, 114, 115, 97, 108, 45, 99, 111, 110,
				102, 105, 103, 64, 56, 100, 99, 49, 97, 97,
				98, 52, 97, 102, 49, 100, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 83, 104, 97, 100, 101,
				114, 67, 111, 110, 102, 105, 103, 46, 99, 115
			},
			TypesData = new byte[50]
			{
				0, 0, 0, 0, 45, 85, 110, 105, 116, 121,
				69, 110, 103, 105, 110, 101, 46, 82, 101, 110,
				100, 101, 114, 105, 110, 103, 46, 85, 110, 105,
				118, 101, 114, 115, 97, 108, 124, 83, 104, 97,
				100, 101, 114, 79, 112, 116, 105, 111, 110, 115
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
namespace UnityEngine.Rendering.Universal;

[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal-config@8dc1aab4af1d\\Runtime\\ShaderConfig.cs")]
public static class ShaderOptions
{
	public const int k_MaxVisibleLightCountLowEndMobile = 16;

	public const int k_MaxVisibleLightCountMobile = 32;

	public const int k_MaxVisibleLightCountDesktop = 256;

	public const int k_UseDynamicBranchFogKeyword = 0;
}
