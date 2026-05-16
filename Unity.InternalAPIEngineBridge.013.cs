using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.Events;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Unity.Localization")]
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
			FilePathsData = new byte[227]
			{
				0, 0, 0, 1, 0, 0, 0, 111, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				108, 111, 99, 97, 108, 105, 122, 97, 116, 105,
				111, 110, 64, 55, 101, 101, 99, 55, 101, 98,
				102, 55, 52, 57, 100, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 73, 110, 116, 101, 114, 110,
				97, 108, 66, 114, 105, 100, 103, 101, 92, 68,
				114, 105, 118, 101, 110, 80, 114, 111, 112, 101,
				114, 116, 121, 77, 97, 110, 97, 103, 101, 114,
				66, 114, 105, 100, 103, 101, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 100, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 117, 110, 105, 116, 121, 46, 108,
				111, 99, 97, 108, 105, 122, 97, 116, 105, 111,
				110, 64, 55, 101, 101, 99, 55, 101, 98, 102,
				55, 52, 57, 100, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 73, 110, 116, 101, 114, 110, 97,
				108, 66, 114, 105, 100, 103, 101, 92, 85, 110,
				105, 116, 121, 69, 118, 101, 110, 116, 66, 114,
				105, 100, 103, 101, 46, 99, 115
			},
			TypesData = new byte[117]
			{
				0, 0, 0, 0, 59, 85, 110, 105, 116, 121,
				69, 110, 103, 105, 110, 101, 46, 76, 111, 99,
				97, 108, 105, 122, 97, 116, 105, 111, 110, 46,
				66, 114, 105, 100, 103, 101, 124, 68, 114, 105,
				118, 101, 110, 80, 114, 111, 112, 101, 114, 116,
				121, 77, 97, 110, 97, 103, 101, 114, 66, 114,
				105, 100, 103, 101, 0, 0, 0, 0, 48, 85,
				110, 105, 116, 121, 69, 110, 103, 105, 110, 101,
				46, 76, 111, 99, 97, 108, 105, 122, 97, 116,
				105, 111, 110, 46, 66, 114, 105, 100, 103, 101,
				124, 85, 110, 105, 116, 121, 69, 118, 101, 110,
				116, 66, 114, 105, 100, 103, 101
			},
			TotalFiles = 2,
			TotalTypes = 2,
			IsEditorOnly = false
		};
	}
}
namespace UnityEngine.Localization.Bridge;

internal class DrivenPropertyManagerBridge
{
	public static void RegisterProperty(Object driver, Object target, string propertyPath)
	{
	}

	public static void UnregisterProperty(Object driver, Object target, string propertyPath)
	{
	}

	public static void UnregisterProperties(Object driver)
	{
	}
}
internal static class UnityEventBridge
{
	private static readonly FieldInfo k_PersistenCallGroup = typeof(UnityEventBase).GetField("m_PersistentCalls", BindingFlags.Instance | BindingFlags.NonPublic);

	public static UnityEventCallState GetPersistentListenerState(this UnityEventBase unityEvent, int index)
	{
		return ((PersistentCallGroup)k_PersistenCallGroup.GetValue(unityEvent)).GetListener(index).callState;
	}
}
