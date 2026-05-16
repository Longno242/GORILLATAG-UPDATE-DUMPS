using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Playables;

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
			FilePathsData = new byte[233]
			{
				0, 0, 0, 1, 0, 0, 0, 110, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				97, 110, 105, 109, 97, 116, 105, 111, 110, 46,
				114, 105, 103, 103, 105, 110, 103, 64, 101, 49,
				48, 54, 100, 49, 102, 55, 56, 50, 50, 56,
				92, 68, 111, 99, 67, 111, 100, 101, 69, 120,
				97, 109, 112, 108, 101, 115, 92, 67, 117, 115,
				116, 111, 109, 80, 108, 97, 121, 97, 98, 108,
				101, 71, 114, 97, 112, 104, 69, 118, 97, 108,
				117, 97, 116, 111, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 107, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 117, 110, 105, 116, 121, 46, 97, 110,
				105, 109, 97, 116, 105, 111, 110, 46, 114, 105,
				103, 103, 105, 110, 103, 64, 101, 49, 48, 54,
				100, 49, 102, 55, 56, 50, 50, 56, 92, 68,
				111, 99, 67, 111, 100, 101, 69, 120, 97, 109,
				112, 108, 101, 115, 92, 67, 117, 115, 116, 111,
				109, 82, 105, 103, 66, 117, 105, 108, 100, 101,
				114, 69, 118, 97, 108, 117, 97, 116, 111, 114,
				46, 99, 115
			},
			TypesData = new byte[95]
			{
				0, 0, 0, 0, 44, 68, 111, 99, 67, 111,
				100, 101, 69, 120, 97, 109, 112, 108, 101, 115,
				124, 67, 117, 115, 116, 111, 109, 80, 108, 97,
				121, 97, 98, 108, 101, 71, 114, 97, 112, 104,
				69, 118, 97, 108, 117, 97, 116, 111, 114, 0,
				0, 0, 0, 41, 68, 111, 99, 67, 111, 100,
				101, 69, 120, 97, 109, 112, 108, 101, 115, 124,
				67, 117, 115, 116, 111, 109, 82, 105, 103, 66,
				117, 105, 108, 100, 101, 114, 69, 118, 97, 108,
				117, 97, 116, 111, 114
			},
			TotalFiles = 2,
			TotalTypes = 2,
			IsEditorOnly = false
		};
	}
}
namespace DocCodeExamples;

[RequireComponent(typeof(RigBuilder))]
public class CustomPlayableGraphEvaluator : MonoBehaviour
{
	private RigBuilder m_RigBuilder;

	private PlayableGraph m_PlayableGraph;

	private void OnEnable()
	{
		m_RigBuilder = GetComponent<RigBuilder>();
		m_PlayableGraph = PlayableGraph.Create();
		m_PlayableGraph.SetTimeUpdateMode(DirectorUpdateMode.Manual);
		m_RigBuilder.Build(m_PlayableGraph);
	}

	private void OnDisable()
	{
		if (m_PlayableGraph.IsValid())
		{
			m_PlayableGraph.Destroy();
		}
	}

	private void LateUpdate()
	{
		m_RigBuilder.SyncLayers();
		m_PlayableGraph.Evaluate(Time.deltaTime);
	}
}
[RequireComponent(typeof(RigBuilder))]
public class CustomRigBuilderEvaluator : MonoBehaviour
{
	private RigBuilder m_RigBuilder;

	private void OnEnable()
	{
		m_RigBuilder = GetComponent<RigBuilder>();
		m_RigBuilder.enabled = false;
		if (m_RigBuilder.Build())
		{
			m_RigBuilder.graph.SetTimeUpdateMode(DirectorUpdateMode.Manual);
		}
	}

	private void LateUpdate()
	{
		m_RigBuilder.Evaluate(Time.deltaTime);
	}
}
