using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Meta.Voice.Hub.Interfaces;

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
			FilePathsData = new byte[476]
			{
				0, 0, 0, 1, 0, 0, 0, 118, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 118, 111, 105, 99,
				101, 64, 100, 51, 102, 54, 102, 51, 55, 98,
				56, 101, 49, 99, 92, 76, 105, 98, 92, 72,
				117, 98, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 65,
				116, 116, 114, 105, 98, 117, 116, 101, 115, 92,
				77, 101, 116, 97, 72, 117, 98, 67, 111, 110,
				116, 101, 120, 116, 65, 116, 116, 114, 105, 98,
				117, 116, 101, 46, 99, 115, 0, 0, 0, 2,
				0, 0, 0, 115, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 118, 111, 105, 99, 101, 64, 100, 51,
				102, 54, 102, 51, 55, 98, 56, 101, 49, 99,
				92, 76, 105, 98, 92, 72, 117, 98, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 65, 116, 116, 114, 105,
				98, 117, 116, 101, 115, 92, 77, 101, 116, 97,
				72, 117, 98, 80, 97, 103, 101, 65, 116, 116,
				114, 105, 98, 117, 116, 101, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 107, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 118, 111, 105, 99, 101,
				64, 100, 51, 102, 54, 102, 51, 55, 98, 56,
				101, 49, 99, 92, 76, 105, 98, 92, 72, 117,
				98, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 73, 110,
				116, 101, 114, 102, 97, 99, 101, 115, 92, 73,
				77, 101, 116, 97, 72, 117, 98, 80, 97, 103,
				101, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 104, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				118, 111, 105, 99, 101, 64, 100, 51, 102, 54,
				102, 51, 55, 98, 56, 101, 49, 99, 92, 76,
				105, 98, 92, 72, 117, 98, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 73, 110, 116, 101, 114, 102, 97,
				99, 101, 115, 92, 73, 80, 97, 103, 101, 73,
				110, 102, 111, 46, 99, 115
			},
			TypesData = new byte[255]
			{
				0, 0, 0, 0, 49, 77, 101, 116, 97, 46,
				86, 111, 105, 99, 101, 46, 72, 117, 98, 46,
				65, 116, 116, 114, 105, 98, 117, 116, 101, 115,
				124, 77, 101, 116, 97, 72, 117, 98, 67, 111,
				110, 116, 101, 120, 116, 65, 116, 116, 114, 105,
				98, 117, 116, 101, 0, 0, 0, 0, 46, 77,
				101, 116, 97, 46, 86, 111, 105, 99, 101, 46,
				72, 117, 98, 46, 65, 116, 116, 114, 105, 98,
				117, 116, 101, 115, 124, 77, 101, 116, 97, 72,
				117, 98, 80, 97, 103, 101, 65, 116, 116, 114,
				105, 98, 117, 116, 101, 0, 0, 0, 0, 62,
				77, 101, 116, 97, 46, 86, 111, 105, 99, 101,
				46, 72, 117, 98, 46, 65, 116, 116, 114, 105,
				98, 117, 116, 101, 115, 124, 77, 101, 116, 97,
				72, 117, 98, 80, 97, 103, 101, 83, 99, 114,
				105, 112, 116, 97, 98, 108, 101, 79, 98, 106,
				101, 99, 116, 65, 116, 116, 114, 105, 98, 117,
				116, 101, 0, 0, 0, 0, 38, 77, 101, 116,
				97, 46, 86, 111, 105, 99, 101, 46, 72, 117,
				98, 46, 73, 110, 116, 101, 114, 102, 97, 99,
				101, 115, 124, 73, 77, 101, 116, 97, 72, 117,
				98, 80, 97, 103, 101, 0, 0, 0, 0, 35,
				77, 101, 116, 97, 46, 86, 111, 105, 99, 101,
				46, 72, 117, 98, 46, 73, 110, 116, 101, 114,
				102, 97, 99, 101, 115, 124, 73, 80, 97, 103,
				101, 73, 110, 102, 111
			},
			TotalFiles = 4,
			TotalTypes = 5,
			IsEditorOnly = false
		};
	}
}
namespace Meta.Voice.Hub.Interfaces
{
	public interface IMetaHubPage
	{
		void OnGUI();
	}
	public interface IPageInfo
	{
		string Name { get; }

		string Context { get; }

		int Priority { get; }

		string Prefix { get; }
	}
}
namespace Meta.Voice.Hub.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class MetaHubContextAttribute : Attribute
	{
		public string Context { get; private set; }

		public int Priority { get; private set; }

		public string LogoPath { get; private set; }

		public MetaHubContextAttribute(string context, int priority = 1000, string pathToLogo = "")
		{
			Context = context;
			Priority = priority;
			LogoPath = pathToLogo;
		}
	}
	public class MetaHubPageAttribute : Attribute, IPageInfo
	{
		public string Name { get; private set; }

		public string Context { get; private set; }

		public int Priority { get; private set; }

		public string Prefix { get; private set; }

		public MetaHubPageAttribute(string name = null, string context = "", string prefix = "", int priority = 0)
		{
			Name = name;
			Context = context;
			Priority = priority;
			Prefix = prefix;
		}
	}
	public class MetaHubPageScriptableObjectAttribute : MetaHubPageAttribute
	{
		public MetaHubPageScriptableObjectAttribute(string context = "")
			: base(null, context)
		{
		}
	}
}
