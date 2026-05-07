using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using KID.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

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
			FilePathsData = new byte[2938]
			{
				0, 0, 0, 1, 0, 0, 0, 50, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 75, 73, 68, 92, 67, 108,
				105, 101, 110, 116, 92, 79, 112, 101, 110, 65,
				80, 73, 68, 97, 116, 101, 67, 111, 110, 118,
				101, 114, 116, 101, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 50, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 75, 73, 68, 92, 77, 111, 100, 101,
				108, 92, 65, 98, 115, 116, 114, 97, 99, 116,
				79, 112, 101, 110, 65, 80, 73, 83, 99, 104,
				101, 109, 97, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 40, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				75, 73, 68, 92, 77, 111, 100, 101, 108, 92,
				65, 103, 101, 67, 114, 105, 116, 101, 114, 105,
				97, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 37, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 75, 73,
				68, 92, 77, 111, 100, 101, 108, 92, 65, 103,
				101, 82, 97, 110, 103, 101, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 39, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 75, 73, 68, 92, 77, 111, 100,
				101, 108, 92, 65, 103, 101, 82, 97, 110, 103,
				101, 86, 50, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 51, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				75, 73, 68, 92, 77, 111, 100, 101, 108, 92,
				65, 119, 97, 105, 116, 67, 104, 97, 108, 108,
				101, 110, 103, 101, 82, 101, 115, 112, 111, 110,
				115, 101, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 38, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 75,
				73, 68, 92, 77, 111, 100, 101, 108, 92, 67,
				104, 97, 108, 108, 101, 110, 103, 101, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 50, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 75, 73, 68, 92, 77,
				111, 100, 101, 108, 92, 67, 104, 101, 99, 107,
				65, 103, 101, 65, 112, 112, 101, 97, 108, 82,
				101, 113, 117, 101, 115, 116, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 51, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 75, 73, 68, 92, 77, 111, 100,
				101, 108, 92, 67, 104, 101, 99, 107, 65, 103,
				101, 65, 112, 112, 101, 97, 108, 82, 101, 115,
				112, 111, 110, 115, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 48, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 75, 73, 68, 92, 77, 111, 100, 101,
				108, 92, 67, 104, 101, 99, 107, 65, 103, 101,
				71, 97, 116, 101, 82, 101, 113, 117, 101, 115,
				116, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 49, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 75, 73,
				68, 92, 77, 111, 100, 101, 108, 92, 67, 104,
				101, 99, 107, 65, 103, 101, 71, 97, 116, 101,
				82, 101, 115, 112, 111, 110, 115, 101, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 48, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 75, 73, 68, 92, 77,
				111, 100, 101, 108, 92, 67, 108, 105, 101, 110,
				116, 69, 114, 114, 111, 114, 82, 101, 115, 112,
				111, 110, 115, 101, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 59, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 75, 73, 68, 92, 77, 111, 100, 101, 108,
				92, 67, 114, 101, 97, 116, 101, 65, 100, 117,
				108, 116, 86, 101, 114, 105, 102, 105, 99, 97,
				116, 105, 111, 110, 82, 101, 113, 117, 101, 115,
				116, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 60, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 75, 73,
				68, 92, 77, 111, 100, 101, 108, 92, 67, 114,
				101, 97, 116, 101, 65, 100, 117, 108, 116, 86,
				101, 114, 105, 102, 105, 99, 97, 116, 105, 111,
				110, 82, 101, 115, 112, 111, 110, 115, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 66,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 75, 73, 68, 92,
				77, 111, 100, 101, 108, 92, 67, 114, 101, 97,
				116, 101, 65, 103, 101, 65, 115, 115, 117, 114,
				97, 110, 99, 101, 86, 101, 114, 105, 102, 105,
				99, 97, 116, 105, 111, 110, 82, 101, 113, 117,
				101, 115, 116, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 67, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				75, 73, 68, 92, 77, 111, 100, 101, 108, 92,
				67, 114, 101, 97, 116, 101, 65, 103, 101, 65,
				115, 115, 117, 114, 97, 110, 99, 101, 86, 101,
				114, 105, 102, 105, 99, 97, 116, 105, 111, 110,
				82, 101, 115, 112, 111, 110, 115, 101, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 57, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 75, 73, 68, 92, 77,
				111, 100, 101, 108, 92, 67, 114, 101, 97, 116,
				101, 65, 103, 101, 86, 101, 114, 105, 102, 105,
				99, 97, 116, 105, 111, 110, 82, 101, 113, 117,
				101, 115, 116, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 58, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				75, 73, 68, 92, 77, 111, 100, 101, 108, 92,
				67, 114, 101, 97, 116, 101, 65, 103, 101, 86,
				101, 114, 105, 102, 105, 99, 97, 116, 105, 111,
				110, 82, 101, 115, 112, 111, 110, 115, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 57,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 75, 73, 68, 92,
				77, 111, 100, 101, 108, 92, 67, 114, 101, 97,
				116, 101, 67, 108, 105, 101, 110, 116, 65, 117,
				116, 104, 84, 111, 107, 101, 110, 82, 101, 113,
				117, 101, 115, 116, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 63, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 75, 73, 68, 92, 77, 111, 100, 101, 108,
				92, 67, 114, 101, 97, 116, 101, 67, 117, 115,
				116, 111, 109, 65, 103, 101, 86, 101, 114, 105,
				102, 105, 99, 97, 116, 105, 111, 110, 82, 101,
				113, 117, 101, 115, 116, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 66, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 75, 73, 68, 92, 77, 111, 100, 101,
				108, 92, 67, 114, 101, 97, 116, 101, 80, 97,
				114, 101, 110, 116, 97, 108, 67, 111, 110, 115,
				101, 110, 116, 67, 104, 97, 108, 108, 101, 110,
				103, 101, 82, 101, 113, 117, 101, 115, 116, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 67,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 75, 73, 68, 92,
				77, 111, 100, 101, 108, 92, 67, 114, 101, 97,
				116, 101, 80, 97, 114, 101, 110, 116, 97, 108,
				67, 111, 110, 115, 101, 110, 116, 67, 104, 97,
				108, 108, 101, 110, 103, 101, 82, 101, 115, 112,
				111, 110, 115, 101, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 54, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 75, 73, 68, 92, 77, 111, 100, 101, 108,
				92, 67, 114, 101, 97, 116, 101, 86, 101, 114,
				105, 102, 105, 99, 97, 116, 105, 111, 110, 82,
				101, 113, 117, 101, 115, 116, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 55, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 75, 73, 68, 92, 77, 111, 100,
				101, 108, 92, 67, 114, 101, 97, 116, 101, 86,
				101, 114, 105, 102, 105, 99, 97, 116, 105, 111,
				110, 82, 101, 115, 112, 111, 110, 115, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 56,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 75, 73, 68, 92,
				77, 111, 100, 101, 108, 92, 71, 101, 110, 101,
				114, 97, 116, 101, 67, 104, 97, 108, 108, 101,
				110, 103, 101, 79, 84, 80, 82, 101, 113, 117,
				101, 115, 116, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 57, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				75, 73, 68, 92, 77, 111, 100, 101, 108, 92,
				71, 101, 110, 101, 114, 97, 116, 101, 67, 104,
				97, 108, 108, 101, 110, 103, 101, 79, 84, 80,
				82, 101, 115, 112, 111, 110, 115, 101, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 70, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 75, 73, 68, 92, 77,
				111, 100, 101, 108, 92, 71, 101, 116, 65, 100,
				117, 108, 116, 86, 101, 114, 105, 102, 105, 99,
				97, 116, 105, 111, 110, 82, 101, 113, 117, 101,
				115, 116, 83, 116, 97, 116, 117, 115, 82, 101,
				115, 112, 111, 110, 115, 101, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 77, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 75, 73, 68, 92, 77, 111, 100,
				101, 108, 92, 71, 101, 116, 65, 103, 101, 65,
				115, 115, 117, 114, 97, 110, 99, 101, 86, 101,
				114, 105, 102, 105, 99, 97, 116, 105, 111, 110,
				82, 101, 113, 117, 101, 115, 116, 83, 116, 97,
				116, 117, 115, 82, 101, 115, 112, 111, 110, 115,
				101, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 59, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 75, 73,
				68, 92, 77, 111, 100, 101, 108, 92, 71, 101,
				116, 65, 103, 101, 71, 97, 116, 101, 82, 101,
				113, 117, 105, 114, 101, 109, 101, 110, 116, 115,
				82, 101, 115, 112, 111, 110, 115, 101, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 61, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 75, 73, 68, 92, 77,
				111, 100, 101, 108, 92, 71, 101, 116, 65, 103,
				101, 86, 101, 114, 105, 102, 105, 99, 97, 116,
				105, 111, 110, 83, 116, 97, 116, 117, 115, 82,
				101, 115, 112, 111, 110, 115, 101, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 55, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 75, 73, 68, 92, 77, 111,
				100, 101, 108, 92, 71, 101, 116, 67, 104, 97,
				108, 108, 101, 110, 103, 101, 83, 116, 97, 116,
				117, 115, 82, 101, 115, 112, 111, 110, 115, 101,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				58, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 75, 73, 68,
				92, 77, 111, 100, 101, 108, 92, 71, 101, 116,
				68, 101, 102, 97, 117, 108, 116, 80, 101, 114,
				109, 105, 115, 115, 105, 111, 110, 115, 82, 101,
				115, 112, 111, 110, 115, 101, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 51, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 75, 73, 68, 92, 77, 111, 100,
				101, 108, 92, 73, 115, 115, 117, 101, 65, 117,
				116, 104, 84, 111, 107, 101, 110, 82, 101, 115,
				112, 111, 110, 115, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 39, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 75, 73, 68, 92, 77, 111, 100, 101,
				108, 92, 80, 101, 114, 109, 105, 115, 115, 105,
				111, 110, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 58, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 75,
				73, 68, 92, 77, 111, 100, 101, 108, 92, 82,
				101, 102, 114, 101, 115, 104, 67, 108, 105, 101,
				110, 116, 65, 117, 116, 104, 84, 111, 107, 101,
				110, 82, 101, 113, 117, 101, 115, 116, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 48, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 75, 73, 68, 92, 77,
				111, 100, 101, 108, 92, 82, 101, 113, 117, 101,
				115, 116, 101, 100, 80, 101, 114, 109, 105, 115,
				115, 105, 111, 110, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 45, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 75, 73, 68, 92, 77, 111, 100, 101, 108,
				92, 83, 101, 110, 100, 69, 109, 97, 105, 108,
				82, 101, 113, 117, 101, 115, 116, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 36, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 75, 73, 68, 92, 77, 111,
				100, 101, 108, 92, 83, 101, 115, 115, 105, 111,
				110, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 54, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 75, 73,
				68, 92, 77, 111, 100, 101, 108, 92, 83, 101,
				116, 67, 104, 97, 108, 108, 101, 110, 103, 101,
				83, 116, 97, 116, 117, 115, 82, 101, 113, 117,
				101, 115, 116, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 72, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				75, 73, 68, 92, 77, 111, 100, 101, 108, 92,
				83, 101, 116, 71, 117, 97, 114, 100, 105, 97,
				110, 77, 97, 110, 97, 103, 101, 100, 83, 101,
				115, 115, 105, 111, 110, 80, 101, 114, 109, 105,
				115, 115, 105, 111, 110, 115, 82, 101, 113, 117,
				101, 115, 116, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 73, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				75, 73, 68, 92, 77, 111, 100, 101, 108, 92,
				83, 101, 116, 71, 117, 97, 114, 100, 105, 97,
				110, 77, 97, 110, 97, 103, 101, 100, 83, 101,
				115, 115, 105, 111, 110, 80, 101, 114, 109, 105,
				115, 115, 105, 111, 110, 115, 82, 101, 115, 112,
				111, 110, 115, 101, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 57, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 75, 73, 68, 92, 77, 111, 100, 101, 108,
				92, 83, 104, 111, 117, 108, 100, 68, 105, 115,
				112, 108, 97, 121, 65, 103, 101, 71, 97, 116,
				101, 82, 101, 115, 112, 111, 110, 115, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 59,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 75, 73, 68, 92,
				77, 111, 100, 101, 108, 92, 84, 101, 115, 116,
				86, 101, 114, 105, 102, 105, 99, 97, 116, 105,
				111, 110, 87, 101, 98, 104, 111, 111, 107, 82,
				101, 113, 117, 101, 115, 116, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 50, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 75, 73, 68, 92, 77, 111, 100,
				101, 108, 92, 85, 112, 103, 114, 97, 100, 101,
				83, 101, 115, 115, 105, 111, 110, 82, 101, 113,
				117, 101, 115, 116, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 51, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 75, 73, 68, 92, 77, 111, 100, 101, 108,
				92, 85, 112, 103, 114, 97, 100, 101, 83, 101,
				115, 115, 105, 111, 110, 82, 101, 115, 112, 111,
				110, 115, 101, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 48, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				75, 73, 68, 92, 77, 111, 100, 101, 108, 92,
				86, 101, 114, 105, 102, 105, 99, 97, 116, 105,
				111, 110, 79, 112, 116, 105, 111, 110, 115, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 48,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 75, 73, 68, 92,
				77, 111, 100, 101, 108, 92, 86, 101, 114, 105,
				102, 105, 99, 97, 116, 105, 111, 110, 83, 117,
				98, 106, 101, 99, 116, 46, 99, 115
			},
			TypesData = new byte[1904]
			{
				0, 0, 0, 0, 31, 75, 73, 68, 46, 67,
				108, 105, 101, 110, 116, 124, 79, 112, 101, 110,
				65, 80, 73, 68, 97, 116, 101, 67, 111, 110,
				118, 101, 114, 116, 101, 114, 0, 0, 0, 0,
				31, 75, 73, 68, 46, 77, 111, 100, 101, 108,
				124, 65, 98, 115, 116, 114, 97, 99, 116, 79,
				112, 101, 110, 65, 80, 73, 83, 99, 104, 101,
				109, 97, 0, 0, 0, 0, 21, 75, 73, 68,
				46, 77, 111, 100, 101, 108, 124, 65, 103, 101,
				67, 114, 105, 116, 101, 114, 105, 97, 0, 0,
				0, 0, 18, 75, 73, 68, 46, 77, 111, 100,
				101, 108, 124, 65, 103, 101, 82, 97, 110, 103,
				101, 0, 0, 0, 0, 20, 75, 73, 68, 46,
				77, 111, 100, 101, 108, 124, 65, 103, 101, 82,
				97, 110, 103, 101, 86, 50, 0, 0, 0, 0,
				32, 75, 73, 68, 46, 77, 111, 100, 101, 108,
				124, 65, 119, 97, 105, 116, 67, 104, 97, 108,
				108, 101, 110, 103, 101, 82, 101, 115, 112, 111,
				110, 115, 101, 0, 0, 0, 0, 19, 75, 73,
				68, 46, 77, 111, 100, 101, 108, 124, 67, 104,
				97, 108, 108, 101, 110, 103, 101, 0, 0, 0,
				0, 31, 75, 73, 68, 46, 77, 111, 100, 101,
				108, 124, 67, 104, 101, 99, 107, 65, 103, 101,
				65, 112, 112, 101, 97, 108, 82, 101, 113, 117,
				101, 115, 116, 0, 0, 0, 0, 32, 75, 73,
				68, 46, 77, 111, 100, 101, 108, 124, 67, 104,
				101, 99, 107, 65, 103, 101, 65, 112, 112, 101,
				97, 108, 82, 101, 115, 112, 111, 110, 115, 101,
				0, 0, 0, 0, 29, 75, 73, 68, 46, 77,
				111, 100, 101, 108, 124, 67, 104, 101, 99, 107,
				65, 103, 101, 71, 97, 116, 101, 82, 101, 113,
				117, 101, 115, 116, 0, 0, 0, 0, 30, 75,
				73, 68, 46, 77, 111, 100, 101, 108, 124, 67,
				104, 101, 99, 107, 65, 103, 101, 71, 97, 116,
				101, 82, 101, 115, 112, 111, 110, 115, 101, 0,
				0, 0, 0, 29, 75, 73, 68, 46, 77, 111,
				100, 101, 108, 124, 67, 108, 105, 101, 110, 116,
				69, 114, 114, 111, 114, 82, 101, 115, 112, 111,
				110, 115, 101, 0, 0, 0, 0, 40, 75, 73,
				68, 46, 77, 111, 100, 101, 108, 124, 67, 114,
				101, 97, 116, 101, 65, 100, 117, 108, 116, 86,
				101, 114, 105, 102, 105, 99, 97, 116, 105, 111,
				110, 82, 101, 113, 117, 101, 115, 116, 0, 0,
				0, 0, 41, 75, 73, 68, 46, 77, 111, 100,
				101, 108, 124, 67, 114, 101, 97, 116, 101, 65,
				100, 117, 108, 116, 86, 101, 114, 105, 102, 105,
				99, 97, 116, 105, 111, 110, 82, 101, 115, 112,
				111, 110, 115, 101, 0, 0, 0, 0, 47, 75,
				73, 68, 46, 77, 111, 100, 101, 108, 124, 67,
				114, 101, 97, 116, 101, 65, 103, 101, 65, 115,
				115, 117, 114, 97, 110, 99, 101, 86, 101, 114,
				105, 102, 105, 99, 97, 116, 105, 111, 110, 82,
				101, 113, 117, 101, 115, 116, 0, 0, 0, 0,
				48, 75, 73, 68, 46, 77, 111, 100, 101, 108,
				124, 67, 114, 101, 97, 116, 101, 65, 103, 101,
				65, 115, 115, 117, 114, 97, 110, 99, 101, 86,
				101, 114, 105, 102, 105, 99, 97, 116, 105, 111,
				110, 82, 101, 115, 112, 111, 110, 115, 101, 0,
				0, 0, 0, 38, 75, 73, 68, 46, 77, 111,
				100, 101, 108, 124, 67, 114, 101, 97, 116, 101,
				65, 103, 101, 86, 101, 114, 105, 102, 105, 99,
				97, 116, 105, 111, 110, 82, 101, 113, 117, 101,
				115, 116, 0, 0, 0, 0, 39, 75, 73, 68,
				46, 77, 111, 100, 101, 108, 124, 67, 114, 101,
				97, 116, 101, 65, 103, 101, 86, 101, 114, 105,
				102, 105, 99, 97, 116, 105, 111, 110, 82, 101,
				115, 112, 111, 110, 115, 101, 0, 0, 0, 0,
				38, 75, 73, 68, 46, 77, 111, 100, 101, 108,
				124, 67, 114, 101, 97, 116, 101, 67, 108, 105,
				101, 110, 116, 65, 117, 116, 104, 84, 111, 107,
				101, 110, 82, 101, 113, 117, 101, 115, 116, 0,
				0, 0, 0, 44, 75, 73, 68, 46, 77, 111,
				100, 101, 108, 124, 67, 114, 101, 97, 116, 101,
				67, 117, 115, 116, 111, 109, 65, 103, 101, 86,
				101, 114, 105, 102, 105, 99, 97, 116, 105, 111,
				110, 82, 101, 113, 117, 101, 115, 116, 0, 0,
				0, 0, 47, 75, 73, 68, 46, 77, 111, 100,
				101, 108, 124, 67, 114, 101, 97, 116, 101, 80,
				97, 114, 101, 110, 116, 97, 108, 67, 111, 110,
				115, 101, 110, 116, 67, 104, 97, 108, 108, 101,
				110, 103, 101, 82, 101, 113, 117, 101, 115, 116,
				0, 0, 0, 0, 48, 75, 73, 68, 46, 77,
				111, 100, 101, 108, 124, 67, 114, 101, 97, 116,
				101, 80, 97, 114, 101, 110, 116, 97, 108, 67,
				111, 110, 115, 101, 110, 116, 67, 104, 97, 108,
				108, 101, 110, 103, 101, 82, 101, 115, 112, 111,
				110, 115, 101, 0, 0, 0, 0, 35, 75, 73,
				68, 46, 77, 111, 100, 101, 108, 124, 67, 114,
				101, 97, 116, 101, 86, 101, 114, 105, 102, 105,
				99, 97, 116, 105, 111, 110, 82, 101, 113, 117,
				101, 115, 116, 0, 0, 0, 0, 36, 75, 73,
				68, 46, 77, 111, 100, 101, 108, 124, 67, 114,
				101, 97, 116, 101, 86, 101, 114, 105, 102, 105,
				99, 97, 116, 105, 111, 110, 82, 101, 115, 112,
				111, 110, 115, 101, 0, 0, 0, 0, 37, 75,
				73, 68, 46, 77, 111, 100, 101, 108, 124, 71,
				101, 110, 101, 114, 97, 116, 101, 67, 104, 97,
				108, 108, 101, 110, 103, 101, 79, 84, 80, 82,
				101, 113, 117, 101, 115, 116, 0, 0, 0, 0,
				38, 75, 73, 68, 46, 77, 111, 100, 101, 108,
				124, 71, 101, 110, 101, 114, 97, 116, 101, 67,
				104, 97, 108, 108, 101, 110, 103, 101, 79, 84,
				80, 82, 101, 115, 112, 111, 110, 115, 101, 0,
				0, 0, 0, 51, 75, 73, 68, 46, 77, 111,
				100, 101, 108, 124, 71, 101, 116, 65, 100, 117,
				108, 116, 86, 101, 114, 105, 102, 105, 99, 97,
				116, 105, 111, 110, 82, 101, 113, 117, 101, 115,
				116, 83, 116, 97, 116, 117, 115, 82, 101, 115,
				112, 111, 110, 115, 101, 0, 0, 0, 0, 58,
				75, 73, 68, 46, 77, 111, 100, 101, 108, 124,
				71, 101, 116, 65, 103, 101, 65, 115, 115, 117,
				114, 97, 110, 99, 101, 86, 101, 114, 105, 102,
				105, 99, 97, 116, 105, 111, 110, 82, 101, 113,
				117, 101, 115, 116, 83, 116, 97, 116, 117, 115,
				82, 101, 115, 112, 111, 110, 115, 101, 0, 0,
				0, 0, 40, 75, 73, 68, 46, 77, 111, 100,
				101, 108, 124, 71, 101, 116, 65, 103, 101, 71,
				97, 116, 101, 82, 101, 113, 117, 105, 114, 101,
				109, 101, 110, 116, 115, 82, 101, 115, 112, 111,
				110, 115, 101, 0, 0, 0, 0, 42, 75, 73,
				68, 46, 77, 111, 100, 101, 108, 124, 71, 101,
				116, 65, 103, 101, 86, 101, 114, 105, 102, 105,
				99, 97, 116, 105, 111, 110, 83, 116, 97, 116,
				117, 115, 82, 101, 115, 112, 111, 110, 115, 101,
				0, 0, 0, 0, 36, 75, 73, 68, 46, 77,
				111, 100, 101, 108, 124, 71, 101, 116, 67, 104,
				97, 108, 108, 101, 110, 103, 101, 83, 116, 97,
				116, 117, 115, 82, 101, 115, 112, 111, 110, 115,
				101, 0, 0, 0, 0, 39, 75, 73, 68, 46,
				77, 111, 100, 101, 108, 124, 71, 101, 116, 68,
				101, 102, 97, 117, 108, 116, 80, 101, 114, 109,
				105, 115, 115, 105, 111, 110, 115, 82, 101, 115,
				112, 111, 110, 115, 101, 0, 0, 0, 0, 32,
				75, 73, 68, 46, 77, 111, 100, 101, 108, 124,
				73, 115, 115, 117, 101, 65, 117, 116, 104, 84,
				111, 107, 101, 110, 82, 101, 115, 112, 111, 110,
				115, 101, 0, 0, 0, 0, 20, 75, 73, 68,
				46, 77, 111, 100, 101, 108, 124, 80, 101, 114,
				109, 105, 115, 115, 105, 111, 110, 0, 0, 0,
				0, 39, 75, 73, 68, 46, 77, 111, 100, 101,
				108, 124, 82, 101, 102, 114, 101, 115, 104, 67,
				108, 105, 101, 110, 116, 65, 117, 116, 104, 84,
				111, 107, 101, 110, 82, 101, 113, 117, 101, 115,
				116, 0, 0, 0, 0, 29, 75, 73, 68, 46,
				77, 111, 100, 101, 108, 124, 82, 101, 113, 117,
				101, 115, 116, 101, 100, 80, 101, 114, 109, 105,
				115, 115, 105, 111, 110, 0, 0, 0, 0, 26,
				75, 73, 68, 46, 77, 111, 100, 101, 108, 124,
				83, 101, 110, 100, 69, 109, 97, 105, 108, 82,
				101, 113, 117, 101, 115, 116, 0, 0, 0, 0,
				17, 75, 73, 68, 46, 77, 111, 100, 101, 108,
				124, 83, 101, 115, 115, 105, 111, 110, 0, 0,
				0, 0, 35, 75, 73, 68, 46, 77, 111, 100,
				101, 108, 124, 83, 101, 116, 67, 104, 97, 108,
				108, 101, 110, 103, 101, 83, 116, 97, 116, 117,
				115, 82, 101, 113, 117, 101, 115, 116, 0, 0,
				0, 0, 53, 75, 73, 68, 46, 77, 111, 100,
				101, 108, 124, 83, 101, 116, 71, 117, 97, 114,
				100, 105, 97, 110, 77, 97, 110, 97, 103, 101,
				100, 83, 101, 115, 115, 105, 111, 110, 80, 101,
				114, 109, 105, 115, 115, 105, 111, 110, 115, 82,
				101, 113, 117, 101, 115, 116, 0, 0, 0, 0,
				54, 75, 73, 68, 46, 77, 111, 100, 101, 108,
				124, 83, 101, 116, 71, 117, 97, 114, 100, 105,
				97, 110, 77, 97, 110, 97, 103, 101, 100, 83,
				101, 115, 115, 105, 111, 110, 80, 101, 114, 109,
				105, 115, 115, 105, 111, 110, 115, 82, 101, 115,
				112, 111, 110, 115, 101, 0, 0, 0, 0, 38,
				75, 73, 68, 46, 77, 111, 100, 101, 108, 124,
				83, 104, 111, 117, 108, 100, 68, 105, 115, 112,
				108, 97, 121, 65, 103, 101, 71, 97, 116, 101,
				82, 101, 115, 112, 111, 110, 115, 101, 0, 0,
				0, 0, 40, 75, 73, 68, 46, 77, 111, 100,
				101, 108, 124, 84, 101, 115, 116, 86, 101, 114,
				105, 102, 105, 99, 97, 116, 105, 111, 110, 87,
				101, 98, 104, 111, 111, 107, 82, 101, 113, 117,
				101, 115, 116, 0, 0, 0, 0, 31, 75, 73,
				68, 46, 77, 111, 100, 101, 108, 124, 85, 112,
				103, 114, 97, 100, 101, 83, 101, 115, 115, 105,
				111, 110, 82, 101, 113, 117, 101, 115, 116, 0,
				0, 0, 0, 32, 75, 73, 68, 46, 77, 111,
				100, 101, 108, 124, 85, 112, 103, 114, 97, 100,
				101, 83, 101, 115, 115, 105, 111, 110, 82, 101,
				115, 112, 111, 110, 115, 101, 0, 0, 0, 0,
				29, 75, 73, 68, 46, 77, 111, 100, 101, 108,
				124, 86, 101, 114, 105, 102, 105, 99, 97, 116,
				105, 111, 110, 79, 112, 116, 105, 111, 110, 115,
				0, 0, 0, 0, 29, 75, 73, 68, 46, 77,
				111, 100, 101, 108, 124, 86, 101, 114, 105, 102,
				105, 99, 97, 116, 105, 111, 110, 83, 117, 98,
				106, 101, 99, 116
			},
			TotalFiles = 47,
			TotalTypes = 47,
			IsEditorOnly = false
		};
	}
}
namespace KID.Model
{
	public abstract class AbstractOpenAPISchema
	{
		public static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
		{
			ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
			MissingMemberHandling = MissingMemberHandling.Error,
			ContractResolver = new DefaultContractResolver
			{
				NamingStrategy = new CamelCaseNamingStrategy
				{
					OverrideSpecifiedNames = false
				}
			}
		};

		public static readonly JsonSerializerSettings AdditionalPropertiesSerializerSettings = new JsonSerializerSettings
		{
			ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
			MissingMemberHandling = MissingMemberHandling.Ignore,
			ContractResolver = new DefaultContractResolver
			{
				NamingStrategy = new CamelCaseNamingStrategy
				{
					OverrideSpecifiedNames = false
				}
			}
		};

		public abstract object ActualInstance { get; set; }

		public bool IsNullable { get; protected set; }

		public string SchemaType { get; protected set; }

		public abstract string ToJson();
	}
	[JsonConverter(typeof(StringEnumConverter))]
	public enum AgeCategory
	{
		[EnumMember(Value = "DIGITAL_YOUTH_OR_ADULT")]
		DIGITALYOUTHORADULT = 1,
		[EnumMember(Value = "ADULT")]
		ADULT
	}
	[JsonConverter(typeof(StringEnumConverter))]
	public enum AgeCategoryV2
	{
		[EnumMember(Value = "digital-minor")]
		DigitalMinor = 1,
		[EnumMember(Value = "digital-youth")]
		DigitalYouth,
		[EnumMember(Value = "adult")]
		Adult
	}
	[DataContract(Name = "AgeCriteria")]
	public class AgeCriteria
	{
		[DataMember(Name = "ageCategory", EmitDefaultValue = false)]
		public AgeCategory? AgeCategory { get; set; }

		[DataMember(Name = "age", EmitDefaultValue = false)]
		public int Age { get; set; }

		public AgeCriteria(int age = 0, AgeCategory? ageCategory = null)
		{
			Age = age;
			AgeCategory = ageCategory;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class AgeCriteria {\n");
			stringBuilder.Append("  Age: ").Append(Age).Append("\n");
			stringBuilder.Append("  AgeCategory: ").Append(AgeCategory).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "AgeRange")]
	public class AgeRange
	{
		[DataMember(Name = "minAge", EmitDefaultValue = false)]
		public int MinAge { get; set; }

		[DataMember(Name = "maxAge", EmitDefaultValue = false)]
		public int MaxAge { get; set; }

		[DataMember(Name = "confidence", EmitDefaultValue = false)]
		public decimal Confidence { get; set; }

		public AgeRange(int minAge = 0, int maxAge = 0, decimal confidence = 0m)
		{
			MinAge = minAge;
			MaxAge = maxAge;
			Confidence = confidence;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class AgeRange {\n");
			stringBuilder.Append("  MinAge: ").Append(MinAge).Append("\n");
			stringBuilder.Append("  MaxAge: ").Append(MaxAge).Append("\n");
			stringBuilder.Append("  Confidence: ").Append(Confidence).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "AgeRangeV2")]
	public class AgeRangeV2
	{
		[DataMember(Name = "low", EmitDefaultValue = false)]
		public int Low { get; set; }

		[DataMember(Name = "high", EmitDefaultValue = false)]
		public int High { get; set; }

		[DataMember(Name = "confidence", EmitDefaultValue = false)]
		public decimal Confidence { get; set; }

		public AgeRangeV2(int low = 0, int high = 0, decimal confidence = 0m)
		{
			Low = low;
			High = high;
			Confidence = confidence;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class AgeRangeV2 {\n");
			stringBuilder.Append("  Low: ").Append(Low).Append("\n");
			stringBuilder.Append("  High: ").Append(High).Append("\n");
			stringBuilder.Append("  Confidence: ").Append(Confidence).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[JsonConverter(typeof(StringEnumConverter))]
	public enum AgeStatusType
	{
		[EnumMember(Value = "DIGITAL_MINOR")]
		DIGITALMINOR = 1,
		[EnumMember(Value = "DIGITAL_YOUTH")]
		DIGITALYOUTH,
		[EnumMember(Value = "LEGAL_ADULT")]
		LEGALADULT
	}
	[DataContract(Name = "AwaitChallengeResponse")]
	public class AwaitChallengeResponse
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public enum StatusEnum
		{
			[EnumMember(Value = "PASS")]
			PASS = 1,
			[EnumMember(Value = "FAIL")]
			FAIL,
			[EnumMember(Value = "POLL_TIMEOUT")]
			POLLTIMEOUT,
			[EnumMember(Value = "IN_PROGRESS")]
			INPROGRESS
		}

		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		public StatusEnum Status { get; set; }

		[DataMember(Name = "sessionId", EmitDefaultValue = false)]
		public Guid SessionId { get; set; }

		[DataMember(Name = "approverEmail", EmitDefaultValue = false)]
		public string ApproverEmail { get; set; }

		[JsonConstructor]
		protected AwaitChallengeResponse()
		{
		}

		public AwaitChallengeResponse(StatusEnum status = (StatusEnum)0, Guid sessionId = default(Guid), string approverEmail = null)
		{
			Status = status;
			SessionId = sessionId;
			ApproverEmail = approverEmail;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class AwaitChallengeResponse {\n");
			stringBuilder.Append("  Status: ").Append(Status).Append("\n");
			stringBuilder.Append("  SessionId: ").Append(SessionId).Append("\n");
			stringBuilder.Append("  ApproverEmail: ").Append(ApproverEmail).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "Challenge")]
	public class Challenge
	{
		[DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
		public ChallengeType Type { get; set; }

		[DataMember(Name = "challengeId", IsRequired = true, EmitDefaultValue = true)]
		public Guid ChallengeId { get; set; }

		[DataMember(Name = "url", EmitDefaultValue = false)]
		public string Url { get; set; }

		[DataMember(Name = "oneTimePassword", EmitDefaultValue = false)]
		public string OneTimePassword { get; set; }

		[DataMember(Name = "childLiteAccessEnabled", IsRequired = true, EmitDefaultValue = true)]
		public bool ChildLiteAccessEnabled { get; set; }

		[JsonConstructor]
		protected Challenge()
		{
		}

		public Challenge(Guid challengeId = default(Guid), ChallengeType type = (ChallengeType)0, string url = null, string oneTimePassword = null, bool childLiteAccessEnabled = false)
		{
			ChallengeId = challengeId;
			Type = type;
			ChildLiteAccessEnabled = childLiteAccessEnabled;
			Url = url;
			OneTimePassword = oneTimePassword;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class Challenge {\n");
			stringBuilder.Append("  ChallengeId: ").Append(ChallengeId).Append("\n");
			stringBuilder.Append("  Type: ").Append(Type).Append("\n");
			stringBuilder.Append("  Url: ").Append(Url).Append("\n");
			stringBuilder.Append("  OneTimePassword: ").Append(OneTimePassword).Append("\n");
			stringBuilder.Append("  ChildLiteAccessEnabled: ").Append(ChildLiteAccessEnabled).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ChallengeType
	{
		[EnumMember(Value = "CHALLENGE_PARENTAL_CONSENT")]
		PARENTALCONSENT = 1,
		[EnumMember(Value = "CHALLENGE_SESSION_UPGRADE")]
		SESSIONUPGRADE
	}
	[DataContract(Name = "CheckAgeAppealRequest")]
	public class CheckAgeAppealRequest
	{
		[DataMember(Name = "email", EmitDefaultValue = false)]
		public string Email { get; set; }

		[DataMember(Name = "playerId", EmitDefaultValue = false)]
		public Guid PlayerId { get; set; }

		[DataMember(Name = "jurisdiction", IsRequired = true, EmitDefaultValue = true)]
		public string Jurisdiction { get; set; }

		[JsonConstructor]
		protected CheckAgeAppealRequest()
		{
		}

		public CheckAgeAppealRequest(string email = null, Guid playerId = default(Guid), string jurisdiction = null)
		{
			if (jurisdiction == null)
			{
				throw new ArgumentNullException("jurisdiction is a required property for CheckAgeAppealRequest and cannot be null");
			}
			Jurisdiction = jurisdiction;
			Email = email;
			PlayerId = playerId;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CheckAgeAppealRequest {\n");
			stringBuilder.Append("  Email: ").Append(Email).Append("\n");
			stringBuilder.Append("  PlayerId: ").Append(PlayerId).Append("\n");
			stringBuilder.Append("  Jurisdiction: ").Append(Jurisdiction).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CheckAgeAppealResponse")]
	public class CheckAgeAppealResponse
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public enum StatusEnum
		{
			[EnumMember(Value = "PASS")]
			PASS = 1,
			[EnumMember(Value = "FAIL")]
			FAIL,
			[EnumMember(Value = "CHALLENGE")]
			CHALLENGE
		}

		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		public StatusEnum Status { get; set; }

		[DataMember(Name = "url", EmitDefaultValue = false)]
		public string Url { get; set; }

		[JsonConstructor]
		protected CheckAgeAppealResponse()
		{
		}

		public CheckAgeAppealResponse(StatusEnum status = (StatusEnum)0, string url = null)
		{
			Status = status;
			Url = url;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CheckAgeAppealResponse {\n");
			stringBuilder.Append("  Status: ").Append(Status).Append("\n");
			stringBuilder.Append("  Url: ").Append(Url).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CheckAgeGateRequest")]
	public class CheckAgeGateRequest
	{
		[DataMember(Name = "jurisdiction", IsRequired = true, EmitDefaultValue = true)]
		public string Jurisdiction { get; set; }

		[DataMember(Name = "dateOfBirth", EmitDefaultValue = false)]
		[JsonConverter(typeof(OpenAPIDateConverter))]
		public DateTime DateOfBirth { get; set; }

		[DataMember(Name = "age", EmitDefaultValue = false)]
		public int Age { get; set; }

		[JsonConstructor]
		protected CheckAgeGateRequest()
		{
		}

		public CheckAgeGateRequest(string jurisdiction = null, DateTime dateOfBirth = default(DateTime), int age = 0)
		{
			if (jurisdiction == null)
			{
				throw new ArgumentNullException("jurisdiction is a required property for CheckAgeGateRequest and cannot be null");
			}
			Jurisdiction = jurisdiction;
			DateOfBirth = dateOfBirth;
			Age = age;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CheckAgeGateRequest {\n");
			stringBuilder.Append("  Jurisdiction: ").Append(Jurisdiction).Append("\n");
			stringBuilder.Append("  DateOfBirth: ").Append(DateOfBirth).Append("\n");
			stringBuilder.Append("  Age: ").Append(Age).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CheckAgeGateResponse")]
	public class CheckAgeGateResponse
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public enum StatusEnum
		{
			[EnumMember(Value = "PASS")]
			PASS = 1,
			[EnumMember(Value = "PROHIBITED")]
			PROHIBITED,
			[EnumMember(Value = "CHALLENGE")]
			CHALLENGE
		}

		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		public StatusEnum Status { get; set; }

		[DataMember(Name = "session", EmitDefaultValue = false)]
		public Session Session { get; set; }

		[DataMember(Name = "challenge", EmitDefaultValue = false)]
		public Challenge Challenge { get; set; }

		[JsonConstructor]
		protected CheckAgeGateResponse()
		{
		}

		public CheckAgeGateResponse(StatusEnum status = (StatusEnum)0, Session session = null, Challenge challenge = null)
		{
			Status = status;
			Session = session;
			Challenge = challenge;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CheckAgeGateResponse {\n");
			stringBuilder.Append("  Status: ").Append(Status).Append("\n");
			stringBuilder.Append("  Session: ").Append(Session).Append("\n");
			stringBuilder.Append("  Challenge: ").Append(Challenge).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "ClientErrorResponse")]
	public class ClientErrorResponse
	{
		[DataMember(Name = "error", IsRequired = true, EmitDefaultValue = true)]
		public string Error { get; set; }

		[DataMember(Name = "errorMessage", EmitDefaultValue = false)]
		public string ErrorMessage { get; set; }

		[JsonConstructor]
		protected ClientErrorResponse()
		{
		}

		public ClientErrorResponse(string error = null, string errorMessage = null)
		{
			if (error == null)
			{
				throw new ArgumentNullException("error is a required property for ClientErrorResponse and cannot be null");
			}
			Error = error;
			ErrorMessage = errorMessage;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class ClientErrorResponse {\n");
			stringBuilder.Append("  Error: ").Append(Error).Append("\n");
			stringBuilder.Append("  ErrorMessage: ").Append(ErrorMessage).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CreateAdultVerificationRequest")]
	public class CreateAdultVerificationRequest
	{
		[DataMember(Name = "email", IsRequired = true, EmitDefaultValue = true)]
		public string Email { get; set; }

		[DataMember(Name = "jurisdiction", IsRequired = true, EmitDefaultValue = true)]
		public string Jurisdiction { get; set; }

		[DataMember(Name = "allowedMethods", EmitDefaultValue = false)]
		public List<VerificationMethod> AllowedMethods { get; set; }

		[DataMember(Name = "locale", EmitDefaultValue = false)]
		public string Locale { get; set; }

		[JsonConstructor]
		protected CreateAdultVerificationRequest()
		{
		}

		public CreateAdultVerificationRequest(string email = null, string jurisdiction = null, List<VerificationMethod> allowedMethods = null, string locale = null)
		{
			if (email == null)
			{
				throw new ArgumentNullException("email is a required property for CreateAdultVerificationRequest and cannot be null");
			}
			Email = email;
			if (jurisdiction == null)
			{
				throw new ArgumentNullException("jurisdiction is a required property for CreateAdultVerificationRequest and cannot be null");
			}
			Jurisdiction = jurisdiction;
			AllowedMethods = allowedMethods;
			Locale = locale;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CreateAdultVerificationRequest {\n");
			stringBuilder.Append("  Email: ").Append(Email).Append("\n");
			stringBuilder.Append("  Jurisdiction: ").Append(Jurisdiction).Append("\n");
			stringBuilder.Append("  AllowedMethods: ").Append(AllowedMethods).Append("\n");
			stringBuilder.Append("  Locale: ").Append(Locale).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CreateAdultVerificationResponse")]
	public class CreateAdultVerificationResponse
	{
		[DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
		public Guid Id { get; set; }

		[DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
		public string Url { get; set; }

		[JsonConstructor]
		protected CreateAdultVerificationResponse()
		{
		}

		public CreateAdultVerificationResponse(Guid id = default(Guid), string url = null)
		{
			Id = id;
			if (url == null)
			{
				throw new ArgumentNullException("url is a required property for CreateAdultVerificationResponse and cannot be null");
			}
			Url = url;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CreateAdultVerificationResponse {\n");
			stringBuilder.Append("  Id: ").Append(Id).Append("\n");
			stringBuilder.Append("  Url: ").Append(Url).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CreateAgeAssuranceVerificationRequest")]
	public class CreateAgeAssuranceVerificationRequest
	{
		[DataMember(Name = "ageCategory", EmitDefaultValue = false)]
		public AgeCategory? AgeCategory { get; set; }

		[DataMember(Name = "email", EmitDefaultValue = false)]
		public string Email { get; set; }

		[DataMember(Name = "jurisdiction", IsRequired = true, EmitDefaultValue = true)]
		public string Jurisdiction { get; set; }

		[DataMember(Name = "locale", EmitDefaultValue = false)]
		public string Locale { get; set; }

		[DataMember(Name = "age", EmitDefaultValue = false)]
		public int Age { get; set; }

		[DataMember(Name = "disableInstructions", EmitDefaultValue = true)]
		public bool DisableInstructions { get; set; }

		[JsonConstructor]
		protected CreateAgeAssuranceVerificationRequest()
		{
		}

		public CreateAgeAssuranceVerificationRequest(string email = null, string jurisdiction = null, string locale = null, int age = 0, AgeCategory? ageCategory = null, bool disableInstructions = false)
		{
			if (jurisdiction == null)
			{
				throw new ArgumentNullException("jurisdiction is a required property for CreateAgeAssuranceVerificationRequest and cannot be null");
			}
			Jurisdiction = jurisdiction;
			Email = email;
			Locale = locale;
			Age = age;
			AgeCategory = ageCategory;
			DisableInstructions = disableInstructions;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CreateAgeAssuranceVerificationRequest {\n");
			stringBuilder.Append("  Email: ").Append(Email).Append("\n");
			stringBuilder.Append("  Jurisdiction: ").Append(Jurisdiction).Append("\n");
			stringBuilder.Append("  Locale: ").Append(Locale).Append("\n");
			stringBuilder.Append("  Age: ").Append(Age).Append("\n");
			stringBuilder.Append("  AgeCategory: ").Append(AgeCategory).Append("\n");
			stringBuilder.Append("  DisableInstructions: ").Append(DisableInstructions).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CreateAgeAssuranceVerificationResponse")]
	public class CreateAgeAssuranceVerificationResponse
	{
		[DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
		public Guid Id { get; set; }

		[DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
		public string Url { get; set; }

		[JsonConstructor]
		protected CreateAgeAssuranceVerificationResponse()
		{
		}

		public CreateAgeAssuranceVerificationResponse(Guid id = default(Guid), string url = null)
		{
			Id = id;
			if (url == null)
			{
				throw new ArgumentNullException("url is a required property for CreateAgeAssuranceVerificationResponse and cannot be null");
			}
			Url = url;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CreateAgeAssuranceVerificationResponse {\n");
			stringBuilder.Append("  Id: ").Append(Id).Append("\n");
			stringBuilder.Append("  Url: ").Append(Url).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CreateAgeVerificationRequest")]
	public class CreateAgeVerificationRequest
	{
		[DataMember(Name = "jurisdiction", IsRequired = true, EmitDefaultValue = true)]
		public string Jurisdiction { get; set; }

		[DataMember(Name = "locale", EmitDefaultValue = false)]
		public string Locale { get; set; }

		[DataMember(Name = "subject", EmitDefaultValue = false)]
		public VerificationSubject Subject { get; set; }

		[DataMember(Name = "criteria", IsRequired = true, EmitDefaultValue = true)]
		public AgeCriteria Criteria { get; set; }

		[DataMember(Name = "options", EmitDefaultValue = false)]
		public VerificationOptions Options { get; set; }

		[JsonConstructor]
		protected CreateAgeVerificationRequest()
		{
		}

		public CreateAgeVerificationRequest(string jurisdiction = null, string locale = null, VerificationSubject subject = null, AgeCriteria criteria = null, VerificationOptions options = null)
		{
			if (jurisdiction == null)
			{
				throw new ArgumentNullException("jurisdiction is a required property for CreateAgeVerificationRequest and cannot be null");
			}
			Jurisdiction = jurisdiction;
			if (criteria == null)
			{
				throw new ArgumentNullException("criteria is a required property for CreateAgeVerificationRequest and cannot be null");
			}
			Criteria = criteria;
			Locale = locale;
			Subject = subject;
			Options = options;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CreateAgeVerificationRequest {\n");
			stringBuilder.Append("  Jurisdiction: ").Append(Jurisdiction).Append("\n");
			stringBuilder.Append("  Locale: ").Append(Locale).Append("\n");
			stringBuilder.Append("  Subject: ").Append(Subject).Append("\n");
			stringBuilder.Append("  Criteria: ").Append(Criteria).Append("\n");
			stringBuilder.Append("  Options: ").Append(Options).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CreateAgeVerificationResponse")]
	public class CreateAgeVerificationResponse
	{
		[DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
		public Guid Id { get; set; }

		[DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
		public string Url { get; set; }

		[JsonConstructor]
		protected CreateAgeVerificationResponse()
		{
		}

		public CreateAgeVerificationResponse(Guid id = default(Guid), string url = null)
		{
			Id = id;
			if (url == null)
			{
				throw new ArgumentNullException("url is a required property for CreateAgeVerificationResponse and cannot be null");
			}
			Url = url;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CreateAgeVerificationResponse {\n");
			stringBuilder.Append("  Id: ").Append(Id).Append("\n");
			stringBuilder.Append("  Url: ").Append(Url).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CreateClientAuthTokenRequest")]
	public class CreateClientAuthTokenRequest
	{
		[DataMember(Name = "clientId", IsRequired = true, EmitDefaultValue = true)]
		public string ClientId { get; set; }

		[JsonConstructor]
		protected CreateClientAuthTokenRequest()
		{
		}

		public CreateClientAuthTokenRequest(string clientId = null)
		{
			if (clientId == null)
			{
				throw new ArgumentNullException("clientId is a required property for CreateClientAuthTokenRequest and cannot be null");
			}
			ClientId = clientId;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CreateClientAuthTokenRequest {\n");
			stringBuilder.Append("  ClientId: ").Append(ClientId).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CreateCustomAgeVerificationRequest")]
	public class CreateCustomAgeVerificationRequest
	{
		[DataMember(Name = "scenarioId", IsRequired = true, EmitDefaultValue = true)]
		public Guid ScenarioId { get; set; }

		[DataMember(Name = "jurisdiction", IsRequired = true, EmitDefaultValue = true)]
		public string Jurisdiction { get; set; }

		[DataMember(Name = "subject", EmitDefaultValue = false)]
		public VerificationSubject Subject { get; set; }

		[DataMember(Name = "criteria", IsRequired = true, EmitDefaultValue = true)]
		public AgeCriteria Criteria { get; set; }

		[JsonConstructor]
		protected CreateCustomAgeVerificationRequest()
		{
		}

		public CreateCustomAgeVerificationRequest(Guid scenarioId = default(Guid), string jurisdiction = null, VerificationSubject subject = null, AgeCriteria criteria = null)
		{
			ScenarioId = scenarioId;
			if (jurisdiction == null)
			{
				throw new ArgumentNullException("jurisdiction is a required property for CreateCustomAgeVerificationRequest and cannot be null");
			}
			Jurisdiction = jurisdiction;
			if (criteria == null)
			{
				throw new ArgumentNullException("criteria is a required property for CreateCustomAgeVerificationRequest and cannot be null");
			}
			Criteria = criteria;
			Subject = subject;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CreateCustomAgeVerificationRequest {\n");
			stringBuilder.Append("  ScenarioId: ").Append(ScenarioId).Append("\n");
			stringBuilder.Append("  Jurisdiction: ").Append(Jurisdiction).Append("\n");
			stringBuilder.Append("  Subject: ").Append(Subject).Append("\n");
			stringBuilder.Append("  Criteria: ").Append(Criteria).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CreateParentalConsentChallengeRequest")]
	public class CreateParentalConsentChallengeRequest
	{
		[DataMember(Name = "scenarioId", IsRequired = true, EmitDefaultValue = true)]
		public Guid ScenarioId { get; set; }

		[DataMember(Name = "jurisdiction", IsRequired = true, EmitDefaultValue = true)]
		public string Jurisdiction { get; set; }

		[JsonConstructor]
		protected CreateParentalConsentChallengeRequest()
		{
		}

		public CreateParentalConsentChallengeRequest(Guid scenarioId = default(Guid), string jurisdiction = null)
		{
			ScenarioId = scenarioId;
			if (jurisdiction == null)
			{
				throw new ArgumentNullException("jurisdiction is a required property for CreateParentalConsentChallengeRequest and cannot be null");
			}
			Jurisdiction = jurisdiction;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CreateParentalConsentChallengeRequest {\n");
			stringBuilder.Append("  ScenarioId: ").Append(ScenarioId).Append("\n");
			stringBuilder.Append("  Jurisdiction: ").Append(Jurisdiction).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CreateParentalConsentChallengeResponse")]
	public class CreateParentalConsentChallengeResponse
	{
		[DataMember(Name = "challengeId", IsRequired = true, EmitDefaultValue = true)]
		public Guid ChallengeId { get; set; }

		[DataMember(Name = "longUrl", IsRequired = true, EmitDefaultValue = true)]
		public string LongUrl { get; set; }

		[JsonConstructor]
		protected CreateParentalConsentChallengeResponse()
		{
		}

		public CreateParentalConsentChallengeResponse(Guid challengeId = default(Guid), string longUrl = null)
		{
			ChallengeId = challengeId;
			if (longUrl == null)
			{
				throw new ArgumentNullException("longUrl is a required property for CreateParentalConsentChallengeResponse and cannot be null");
			}
			LongUrl = longUrl;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CreateParentalConsentChallengeResponse {\n");
			stringBuilder.Append("  ChallengeId: ").Append(ChallengeId).Append("\n");
			stringBuilder.Append("  LongUrl: ").Append(LongUrl).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CreateVerificationRequest")]
	public class CreateVerificationRequest
	{
		[DataMember(Name = "scenarioId", IsRequired = true, EmitDefaultValue = true)]
		public Guid ScenarioId { get; set; }

		[DataMember(Name = "jurisdiction", IsRequired = true, EmitDefaultValue = true)]
		public string Jurisdiction { get; set; }

		[DataMember(Name = "email", EmitDefaultValue = false)]
		public string Email { get; set; }

		[DataMember(Name = "criteria", EmitDefaultValue = false)]
		public AgeCriteria Criteria { get; set; }

		[DataMember(Name = "claimedDateOfBirth", EmitDefaultValue = false)]
		[JsonConverter(typeof(OpenAPIDateConverter))]
		public DateTime ClaimedDateOfBirth { get; set; }

		[DataMember(Name = "claimedAge", EmitDefaultValue = false)]
		public int ClaimedAge { get; set; }

		[JsonConstructor]
		protected CreateVerificationRequest()
		{
		}

		public CreateVerificationRequest(Guid scenarioId = default(Guid), string jurisdiction = null, string email = null, AgeCriteria criteria = null, DateTime claimedDateOfBirth = default(DateTime), int claimedAge = 0)
		{
			ScenarioId = scenarioId;
			if (jurisdiction == null)
			{
				throw new ArgumentNullException("jurisdiction is a required property for CreateVerificationRequest and cannot be null");
			}
			Jurisdiction = jurisdiction;
			Email = email;
			Criteria = criteria;
			ClaimedDateOfBirth = claimedDateOfBirth;
			ClaimedAge = claimedAge;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CreateVerificationRequest {\n");
			stringBuilder.Append("  ScenarioId: ").Append(ScenarioId).Append("\n");
			stringBuilder.Append("  Jurisdiction: ").Append(Jurisdiction).Append("\n");
			stringBuilder.Append("  Email: ").Append(Email).Append("\n");
			stringBuilder.Append("  Criteria: ").Append(Criteria).Append("\n");
			stringBuilder.Append("  ClaimedDateOfBirth: ").Append(ClaimedDateOfBirth).Append("\n");
			stringBuilder.Append("  ClaimedAge: ").Append(ClaimedAge).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "CreateVerificationResponse")]
	public class CreateVerificationResponse
	{
		[DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
		public Guid Id { get; set; }

		[DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
		public string Url { get; set; }

		[JsonConstructor]
		protected CreateVerificationResponse()
		{
		}

		public CreateVerificationResponse(Guid id = default(Guid), string url = null)
		{
			Id = id;
			if (url == null)
			{
				throw new ArgumentNullException("url is a required property for CreateVerificationResponse and cannot be null");
			}
			Url = url;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class CreateVerificationResponse {\n");
			stringBuilder.Append("  Id: ").Append(Id).Append("\n");
			stringBuilder.Append("  Url: ").Append(Url).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "GenerateChallengeOTPRequest")]
	public class GenerateChallengeOTPRequest
	{
		[DataMember(Name = "challengeId", IsRequired = true, EmitDefaultValue = true)]
		public Guid ChallengeId { get; set; }

		[JsonConstructor]
		protected GenerateChallengeOTPRequest()
		{
		}

		public GenerateChallengeOTPRequest(Guid challengeId = default(Guid))
		{
			ChallengeId = challengeId;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class GenerateChallengeOTPRequest {\n");
			stringBuilder.Append("  ChallengeId: ").Append(ChallengeId).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "GenerateChallengeOTPResponse")]
	public class GenerateChallengeOTPResponse
	{
		[DataMember(Name = "otp", IsRequired = true, EmitDefaultValue = true)]
		public string Otp { get; set; }

		[DataMember(Name = "expiresAt", IsRequired = true, EmitDefaultValue = true)]
		public string ExpiresAt { get; set; }

		[JsonConstructor]
		protected GenerateChallengeOTPResponse()
		{
		}

		public GenerateChallengeOTPResponse(string otp = null, string expiresAt = null)
		{
			if (otp == null)
			{
				throw new ArgumentNullException("otp is a required property for GenerateChallengeOTPResponse and cannot be null");
			}
			Otp = otp;
			if (expiresAt == null)
			{
				throw new ArgumentNullException("expiresAt is a required property for GenerateChallengeOTPResponse and cannot be null");
			}
			ExpiresAt = expiresAt;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class GenerateChallengeOTPResponse {\n");
			stringBuilder.Append("  Otp: ").Append(Otp).Append("\n");
			stringBuilder.Append("  ExpiresAt: ").Append(ExpiresAt).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "GetAdultVerificationRequestStatusResponse")]
	public class GetAdultVerificationRequestStatusResponse
	{
		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		public VerificationStatus Status { get; set; }

		[DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
		public Guid Id { get; set; }

		[DataMember(Name = "ageRange", EmitDefaultValue = false)]
		public AgeRange AgeRange { get; set; }

		[JsonConstructor]
		protected GetAdultVerificationRequestStatusResponse()
		{
		}

		public GetAdultVerificationRequestStatusResponse(Guid id = default(Guid), VerificationStatus status = (VerificationStatus)0, AgeRange ageRange = null)
		{
			Id = id;
			Status = status;
			AgeRange = ageRange;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class GetAdultVerificationRequestStatusResponse {\n");
			stringBuilder.Append("  Id: ").Append(Id).Append("\n");
			stringBuilder.Append("  Status: ").Append(Status).Append("\n");
			stringBuilder.Append("  AgeRange: ").Append(AgeRange).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "GetAgeAssuranceVerificationRequestStatusResponse")]
	public class GetAgeAssuranceVerificationRequestStatusResponse
	{
		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		public VerificationStatus Status { get; set; }

		[DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
		public Guid Id { get; set; }

		[DataMember(Name = "ageRange", EmitDefaultValue = false)]
		public AgeRange AgeRange { get; set; }

		[JsonConstructor]
		protected GetAgeAssuranceVerificationRequestStatusResponse()
		{
		}

		public GetAgeAssuranceVerificationRequestStatusResponse(Guid id = default(Guid), VerificationStatus status = (VerificationStatus)0, AgeRange ageRange = null)
		{
			Id = id;
			Status = status;
			AgeRange = ageRange;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class GetAgeAssuranceVerificationRequestStatusResponse {\n");
			stringBuilder.Append("  Id: ").Append(Id).Append("\n");
			stringBuilder.Append("  Status: ").Append(Status).Append("\n");
			stringBuilder.Append("  AgeRange: ").Append(AgeRange).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "GetAgeGateRequirementsResponse")]
	public class GetAgeGateRequirementsResponse
	{
		[DataMember(Name = "shouldDisplay", IsRequired = true, EmitDefaultValue = true)]
		public bool ShouldDisplay { get; set; }

		[DataMember(Name = "ageAssuranceRequired", IsRequired = true, EmitDefaultValue = true)]
		public bool AgeAssuranceRequired { get; set; }

		[DataMember(Name = "digitalConsentAge", IsRequired = true, EmitDefaultValue = true)]
		public int DigitalConsentAge { get; set; }

		[DataMember(Name = "civilAge", IsRequired = true, EmitDefaultValue = true)]
		public int CivilAge { get; set; }

		[DataMember(Name = "minimumAge", IsRequired = true, EmitDefaultValue = true)]
		public int MinimumAge { get; set; }

		[DataMember(Name = "approvedAgeCollectionMethods", IsRequired = true, EmitDefaultValue = true)]
		public List<string> ApprovedAgeCollectionMethods { get; set; }

		[JsonConstructor]
		protected GetAgeGateRequirementsResponse()
		{
		}

		public GetAgeGateRequirementsResponse(bool shouldDisplay = false, bool ageAssuranceRequired = false, int digitalConsentAge = 0, int civilAge = 0, int minimumAge = 0, List<string> approvedAgeCollectionMethods = null)
		{
			ShouldDisplay = shouldDisplay;
			AgeAssuranceRequired = ageAssuranceRequired;
			DigitalConsentAge = digitalConsentAge;
			CivilAge = civilAge;
			MinimumAge = minimumAge;
			if (approvedAgeCollectionMethods == null)
			{
				throw new ArgumentNullException("approvedAgeCollectionMethods is a required property for GetAgeGateRequirementsResponse and cannot be null");
			}
			ApprovedAgeCollectionMethods = approvedAgeCollectionMethods;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class GetAgeGateRequirementsResponse {\n");
			stringBuilder.Append("  ShouldDisplay: ").Append(ShouldDisplay).Append("\n");
			stringBuilder.Append("  AgeAssuranceRequired: ").Append(AgeAssuranceRequired).Append("\n");
			stringBuilder.Append("  DigitalConsentAge: ").Append(DigitalConsentAge).Append("\n");
			stringBuilder.Append("  CivilAge: ").Append(CivilAge).Append("\n");
			stringBuilder.Append("  MinimumAge: ").Append(MinimumAge).Append("\n");
			stringBuilder.Append("  ApprovedAgeCollectionMethods: ").Append(ApprovedAgeCollectionMethods).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "GetAgeVerificationStatusResponse")]
	public class GetAgeVerificationStatusResponse
	{
		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		public VerificationStatusV2 Status { get; set; }

		[DataMember(Name = "ageCategory", EmitDefaultValue = false)]
		public AgeCategoryV2? AgeCategory { get; set; }

		[DataMember(Name = "method", EmitDefaultValue = false)]
		public VerificationMethod? Method { get; set; }

		[DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
		public Guid Id { get; set; }

		[DataMember(Name = "age", EmitDefaultValue = false)]
		public AgeRangeV2 Age { get; set; }

		[JsonConstructor]
		protected GetAgeVerificationStatusResponse()
		{
		}

		public GetAgeVerificationStatusResponse(Guid id = default(Guid), VerificationStatusV2 status = (VerificationStatusV2)0, AgeRangeV2 age = null, AgeCategoryV2? ageCategory = null, VerificationMethod? method = null)
		{
			Id = id;
			Status = status;
			Age = age;
			AgeCategory = ageCategory;
			Method = method;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class GetAgeVerificationStatusResponse {\n");
			stringBuilder.Append("  Id: ").Append(Id).Append("\n");
			stringBuilder.Append("  Status: ").Append(Status).Append("\n");
			stringBuilder.Append("  Age: ").Append(Age).Append("\n");
			stringBuilder.Append("  AgeCategory: ").Append(AgeCategory).Append("\n");
			stringBuilder.Append("  Method: ").Append(Method).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "GetChallengeStatusResponse")]
	public class GetChallengeStatusResponse
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public enum StatusEnum
		{
			[EnumMember(Value = "PASS")]
			PASS = 1,
			[EnumMember(Value = "FAIL")]
			FAIL,
			[EnumMember(Value = "PENDING")]
			PENDING,
			[EnumMember(Value = "IN_PROGRESS")]
			INPROGRESS
		}

		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		public StatusEnum Status { get; set; }

		[DataMember(Name = "sessionId", EmitDefaultValue = false)]
		public Guid SessionId { get; set; }

		[DataMember(Name = "approverEmail", EmitDefaultValue = false)]
		public string ApproverEmail { get; set; }

		[JsonConstructor]
		protected GetChallengeStatusResponse()
		{
		}

		public GetChallengeStatusResponse(StatusEnum status = (StatusEnum)0, Guid sessionId = default(Guid), string approverEmail = null)
		{
			Status = status;
			SessionId = sessionId;
			ApproverEmail = approverEmail;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class GetChallengeStatusResponse {\n");
			stringBuilder.Append("  Status: ").Append(Status).Append("\n");
			stringBuilder.Append("  SessionId: ").Append(SessionId).Append("\n");
			stringBuilder.Append("  ApproverEmail: ").Append(ApproverEmail).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "GetDefaultPermissionsResponse")]
	public class GetDefaultPermissionsResponse
	{
		[DataMember(Name = "ageStatus", IsRequired = true, EmitDefaultValue = true)]
		public AgeStatusType AgeStatus { get; set; }

		[DataMember(Name = "ageCategory", IsRequired = true, EmitDefaultValue = true)]
		public AgeCategoryV2 AgeCategory { get; set; }

		[DataMember(Name = "requiresParentConsentForDataProcessing", IsRequired = true, EmitDefaultValue = true)]
		public bool RequiresParentConsentForDataProcessing { get; set; }

		[DataMember(Name = "permissions", IsRequired = true, EmitDefaultValue = true)]
		public List<Permission> Permissions { get; set; }

		[JsonConstructor]
		protected GetDefaultPermissionsResponse()
		{
		}

		public GetDefaultPermissionsResponse(bool requiresParentConsentForDataProcessing = false, List<Permission> permissions = null, AgeStatusType ageStatus = (AgeStatusType)0, AgeCategoryV2 ageCategory = (AgeCategoryV2)0)
		{
			RequiresParentConsentForDataProcessing = requiresParentConsentForDataProcessing;
			if (permissions == null)
			{
				throw new ArgumentNullException("permissions is a required property for GetDefaultPermissionsResponse and cannot be null");
			}
			Permissions = permissions;
			AgeStatus = ageStatus;
			AgeCategory = ageCategory;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class GetDefaultPermissionsResponse {\n");
			stringBuilder.Append("  RequiresParentConsentForDataProcessing: ").Append(RequiresParentConsentForDataProcessing).Append("\n");
			stringBuilder.Append("  Permissions: ").Append(Permissions).Append("\n");
			stringBuilder.Append("  AgeStatus: ").Append(AgeStatus).Append("\n");
			stringBuilder.Append("  AgeCategory: ").Append(AgeCategory).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "IssueAuthTokenResponse")]
	public class IssueAuthTokenResponse
	{
		[DataMember(Name = "accessToken", EmitDefaultValue = false)]
		public string AccessToken { get; set; }

		[DataMember(Name = "refreshToken", EmitDefaultValue = false)]
		public string RefreshToken { get; set; }

		public IssueAuthTokenResponse(string accessToken = null, string refreshToken = null)
		{
			AccessToken = accessToken;
			RefreshToken = refreshToken;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class IssueAuthTokenResponse {\n");
			stringBuilder.Append("  AccessToken: ").Append(AccessToken).Append("\n");
			stringBuilder.Append("  RefreshToken: ").Append(RefreshToken).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "Permission")]
	public class Permission
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public enum ManagedByEnum
		{
			[EnumMember(Value = "PLAYER")]
			PLAYER = 1,
			[EnumMember(Value = "GUARDIAN")]
			GUARDIAN,
			[EnumMember(Value = "PROHIBITED")]
			PROHIBITED
		}

		[DataMember(Name = "managedBy", IsRequired = true, EmitDefaultValue = true)]
		public ManagedByEnum ManagedBy { get; set; }

		[DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
		public string Name { get; set; }

		[DataMember(Name = "enabled", IsRequired = true, EmitDefaultValue = true)]
		public bool Enabled { get; set; }

		[JsonConstructor]
		protected Permission()
		{
		}

		public Permission(string name = null, bool enabled = false, ManagedByEnum managedBy = (ManagedByEnum)0)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name is a required property for Permission and cannot be null");
			}
			Name = name;
			Enabled = enabled;
			ManagedBy = managedBy;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class Permission {\n");
			stringBuilder.Append("  Name: ").Append(Name).Append("\n");
			stringBuilder.Append("  Enabled: ").Append(Enabled).Append("\n");
			stringBuilder.Append("  ManagedBy: ").Append(ManagedBy).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "refreshClientAuthToken_request")]
	public class RefreshClientAuthTokenRequest
	{
		[DataMember(Name = "refreshToken", IsRequired = true, EmitDefaultValue = true)]
		public string RefreshToken { get; set; }

		[JsonConstructor]
		protected RefreshClientAuthTokenRequest()
		{
		}

		public RefreshClientAuthTokenRequest(string refreshToken = null)
		{
			if (refreshToken == null)
			{
				throw new ArgumentNullException("refreshToken is a required property for RefreshClientAuthTokenRequest and cannot be null");
			}
			RefreshToken = refreshToken;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class RefreshClientAuthTokenRequest {\n");
			stringBuilder.Append("  RefreshToken: ").Append(RefreshToken).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "RequestedPermission")]
	public class RequestedPermission
	{
		[DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
		public string Name { get; set; }

		[JsonConstructor]
		protected RequestedPermission()
		{
		}

		public RequestedPermission(string name = null)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name is a required property for RequestedPermission and cannot be null");
			}
			Name = name;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class RequestedPermission {\n");
			stringBuilder.Append("  Name: ").Append(Name).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "SendEmailRequest")]
	public class SendEmailRequest
	{
		[DataMember(Name = "challengeId", IsRequired = true, EmitDefaultValue = true)]
		public Guid ChallengeId { get; set; }

		[DataMember(Name = "email", EmitDefaultValue = false)]
		public string Email { get; set; }

		[DataMember(Name = "locale", EmitDefaultValue = false)]
		public string Locale { get; set; }

		[JsonConstructor]
		protected SendEmailRequest()
		{
		}

		public SendEmailRequest(Guid challengeId = default(Guid), string email = null, string locale = null)
		{
			ChallengeId = challengeId;
			Email = email;
			Locale = locale;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class SendEmailRequest {\n");
			stringBuilder.Append("  ChallengeId: ").Append(ChallengeId).Append("\n");
			stringBuilder.Append("  Email: ").Append(Email).Append("\n");
			stringBuilder.Append("  Locale: ").Append(Locale).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "Session")]
	public class Session
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public enum StatusEnum
		{
			[EnumMember(Value = "ACTIVE")]
			ACTIVE = 1,
			[EnumMember(Value = "HOLD")]
			HOLD
		}

		[JsonConverter(typeof(StringEnumConverter))]
		public enum ManagedByEnum
		{
			[EnumMember(Value = "PLAYER")]
			PLAYER = 1,
			[EnumMember(Value = "GUARDIAN")]
			GUARDIAN
		}

		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		public StatusEnum Status { get; set; }

		[DataMember(Name = "ageStatus", IsRequired = true, EmitDefaultValue = true)]
		public AgeStatusType AgeStatus { get; set; }

		[DataMember(Name = "ageCategory", IsRequired = true, EmitDefaultValue = true)]
		public AgeCategoryV2 AgeCategory { get; set; }

		[DataMember(Name = "managedBy", IsRequired = true, EmitDefaultValue = true)]
		public ManagedByEnum ManagedBy { get; set; }

		[DataMember(Name = "sessionId", IsRequired = true, EmitDefaultValue = true)]
		public Guid SessionId { get; set; }

		[DataMember(Name = "kuid", EmitDefaultValue = false)]
		public string Kuid { get; set; }

		[DataMember(Name = "etag", IsRequired = true, EmitDefaultValue = true)]
		public string Etag { get; set; }

		[DataMember(Name = "permissions", EmitDefaultValue = false)]
		public List<Permission> Permissions { get; set; }

		[DataMember(Name = "dateOfBirth", IsRequired = true, EmitDefaultValue = true)]
		[JsonConverter(typeof(OpenAPIDateConverter))]
		public DateTime DateOfBirth { get; set; }

		[DataMember(Name = "jurisdiction", IsRequired = true, EmitDefaultValue = true)]
		public string Jurisdiction { get; set; }

		[JsonConstructor]
		protected Session()
		{
		}

		public Session(Guid sessionId = default(Guid), string kuid = null, string etag = null, StatusEnum status = (StatusEnum)0, List<Permission> permissions = null, AgeStatusType ageStatus = (AgeStatusType)0, AgeCategoryV2 ageCategory = (AgeCategoryV2)0, DateTime dateOfBirth = default(DateTime), string jurisdiction = null, ManagedByEnum managedBy = (ManagedByEnum)0)
		{
			SessionId = sessionId;
			if (etag == null)
			{
				throw new ArgumentNullException("etag is a required property for Session and cannot be null");
			}
			Etag = etag;
			Status = status;
			AgeStatus = ageStatus;
			AgeCategory = ageCategory;
			DateOfBirth = dateOfBirth;
			if (jurisdiction == null)
			{
				throw new ArgumentNullException("jurisdiction is a required property for Session and cannot be null");
			}
			Jurisdiction = jurisdiction;
			ManagedBy = managedBy;
			Kuid = kuid;
			Permissions = permissions;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class Session {\n");
			stringBuilder.Append("  SessionId: ").Append(SessionId).Append("\n");
			stringBuilder.Append("  Kuid: ").Append(Kuid).Append("\n");
			stringBuilder.Append("  Etag: ").Append(Etag).Append("\n");
			stringBuilder.Append("  Status: ").Append(Status).Append("\n");
			stringBuilder.Append("  Permissions: ").Append(Permissions).Append("\n");
			stringBuilder.Append("  AgeStatus: ").Append(AgeStatus).Append("\n");
			stringBuilder.Append("  AgeCategory: ").Append(AgeCategory).Append("\n");
			stringBuilder.Append("  DateOfBirth: ").Append(DateOfBirth).Append("\n");
			stringBuilder.Append("  Jurisdiction: ").Append(Jurisdiction).Append("\n");
			stringBuilder.Append("  ManagedBy: ").Append(ManagedBy).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "SetChallengeStatusRequest")]
	public class SetChallengeStatusRequest
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public enum StatusEnum
		{
			[EnumMember(Value = "PASS")]
			PASS = 1,
			[EnumMember(Value = "FAIL")]
			FAIL
		}

		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		public StatusEnum Status { get; set; }

		[DataMember(Name = "challengeId", IsRequired = true, EmitDefaultValue = true)]
		public Guid ChallengeId { get; set; }

		[DataMember(Name = "age", IsRequired = true, EmitDefaultValue = true)]
		public int Age { get; set; }

		[DataMember(Name = "jurisdiction", IsRequired = true, EmitDefaultValue = true)]
		public string Jurisdiction { get; set; }

		[DataMember(Name = "approverEmail", EmitDefaultValue = false)]
		public string ApproverEmail { get; set; }

		[JsonConstructor]
		protected SetChallengeStatusRequest()
		{
		}

		public SetChallengeStatusRequest(Guid challengeId = default(Guid), StatusEnum status = (StatusEnum)0, int age = 0, string jurisdiction = null, string approverEmail = null)
		{
			ChallengeId = challengeId;
			Status = status;
			Age = age;
			if (jurisdiction == null)
			{
				throw new ArgumentNullException("jurisdiction is a required property for SetChallengeStatusRequest and cannot be null");
			}
			Jurisdiction = jurisdiction;
			ApproverEmail = approverEmail;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class SetChallengeStatusRequest {\n");
			stringBuilder.Append("  ChallengeId: ").Append(ChallengeId).Append("\n");
			stringBuilder.Append("  Status: ").Append(Status).Append("\n");
			stringBuilder.Append("  Age: ").Append(Age).Append("\n");
			stringBuilder.Append("  Jurisdiction: ").Append(Jurisdiction).Append("\n");
			stringBuilder.Append("  ApproverEmail: ").Append(ApproverEmail).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "SetGuardianManagedSessionPermissionsRequest")]
	public class SetGuardianManagedSessionPermissionsRequest
	{
		[DataMember(Name = "sessionId", IsRequired = true, EmitDefaultValue = true)]
		public Guid SessionId { get; set; }

		[DataMember(Name = "enabledPermissions", IsRequired = true, EmitDefaultValue = true)]
		public List<string> EnabledPermissions { get; set; }

		[JsonConstructor]
		protected SetGuardianManagedSessionPermissionsRequest()
		{
		}

		public SetGuardianManagedSessionPermissionsRequest(Guid sessionId = default(Guid), List<string> enabledPermissions = null)
		{
			SessionId = sessionId;
			if (enabledPermissions == null)
			{
				throw new ArgumentNullException("enabledPermissions is a required property for SetGuardianManagedSessionPermissionsRequest and cannot be null");
			}
			EnabledPermissions = enabledPermissions;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class SetGuardianManagedSessionPermissionsRequest {\n");
			stringBuilder.Append("  SessionId: ").Append(SessionId).Append("\n");
			stringBuilder.Append("  EnabledPermissions: ").Append(EnabledPermissions).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "SetGuardianManagedSessionPermissionsResponse")]
	public class SetGuardianManagedSessionPermissionsResponse
	{
		[DataMember(Name = "sessionId", IsRequired = true, EmitDefaultValue = true)]
		public Guid SessionId { get; set; }

		[DataMember(Name = "enabledPermissions", IsRequired = true, EmitDefaultValue = true)]
		public List<string> EnabledPermissions { get; set; }

		[JsonConstructor]
		protected SetGuardianManagedSessionPermissionsResponse()
		{
		}

		public SetGuardianManagedSessionPermissionsResponse(Guid sessionId = default(Guid), List<string> enabledPermissions = null)
		{
			SessionId = sessionId;
			if (enabledPermissions == null)
			{
				throw new ArgumentNullException("enabledPermissions is a required property for SetGuardianManagedSessionPermissionsResponse and cannot be null");
			}
			EnabledPermissions = enabledPermissions;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class SetGuardianManagedSessionPermissionsResponse {\n");
			stringBuilder.Append("  SessionId: ").Append(SessionId).Append("\n");
			stringBuilder.Append("  EnabledPermissions: ").Append(EnabledPermissions).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "ShouldDisplayAgeGateResponse")]
	public class ShouldDisplayAgeGateResponse
	{
		[DataMember(Name = "shouldDisplay", IsRequired = true, EmitDefaultValue = true)]
		public bool ShouldDisplay { get; set; }

		[DataMember(Name = "ageAssuranceRequired", IsRequired = true, EmitDefaultValue = true)]
		public bool AgeAssuranceRequired { get; set; }

		[DataMember(Name = "digitalConsentAge", IsRequired = true, EmitDefaultValue = true)]
		public int DigitalConsentAge { get; set; }

		[DataMember(Name = "civilAge", IsRequired = true, EmitDefaultValue = true)]
		public int CivilAge { get; set; }

		[JsonConstructor]
		protected ShouldDisplayAgeGateResponse()
		{
		}

		public ShouldDisplayAgeGateResponse(bool shouldDisplay = false, bool ageAssuranceRequired = false, int digitalConsentAge = 0, int civilAge = 0)
		{
			ShouldDisplay = shouldDisplay;
			AgeAssuranceRequired = ageAssuranceRequired;
			DigitalConsentAge = digitalConsentAge;
			CivilAge = civilAge;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class ShouldDisplayAgeGateResponse {\n");
			stringBuilder.Append("  ShouldDisplay: ").Append(ShouldDisplay).Append("\n");
			stringBuilder.Append("  AgeAssuranceRequired: ").Append(AgeAssuranceRequired).Append("\n");
			stringBuilder.Append("  DigitalConsentAge: ").Append(DigitalConsentAge).Append("\n");
			stringBuilder.Append("  CivilAge: ").Append(CivilAge).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "TestVerificationWebhookRequest")]
	public class TestVerificationWebhookRequest
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public enum EventTypeEnum
		{
			[EnumMember(Value = "adultVerificationResult")]
			AdultVerificationResult = 1,
			[EnumMember(Value = "ageAssuranceVerificationResult")]
			AgeAssuranceVerificationResult
		}

		[DataMember(Name = "eventType", EmitDefaultValue = false)]
		public EventTypeEnum? EventType { get; set; }

		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		public VerificationStatus Status { get; set; }

		[DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
		public Guid Id { get; set; }

		[DataMember(Name = "ageRange", EmitDefaultValue = false)]
		public AgeRange AgeRange { get; set; }

		[JsonConstructor]
		protected TestVerificationWebhookRequest()
		{
		}

		public TestVerificationWebhookRequest(EventTypeEnum? eventType = null, Guid id = default(Guid), AgeRange ageRange = null, VerificationStatus status = (VerificationStatus)0)
		{
			Id = id;
			Status = status;
			EventType = eventType;
			AgeRange = ageRange;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class TestVerificationWebhookRequest {\n");
			stringBuilder.Append("  EventType: ").Append(EventType).Append("\n");
			stringBuilder.Append("  Id: ").Append(Id).Append("\n");
			stringBuilder.Append("  AgeRange: ").Append(AgeRange).Append("\n");
			stringBuilder.Append("  Status: ").Append(Status).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "UpgradeSessionRequest")]
	public class UpgradeSessionRequest
	{
		[DataMember(Name = "sessionId", IsRequired = true, EmitDefaultValue = true)]
		public Guid SessionId { get; set; }

		[DataMember(Name = "requestedPermissions", IsRequired = true, EmitDefaultValue = true)]
		public List<RequestedPermission> RequestedPermissions { get; set; }

		[JsonConstructor]
		protected UpgradeSessionRequest()
		{
		}

		public UpgradeSessionRequest(Guid sessionId = default(Guid), List<RequestedPermission> requestedPermissions = null)
		{
			SessionId = sessionId;
			if (requestedPermissions == null)
			{
				throw new ArgumentNullException("requestedPermissions is a required property for UpgradeSessionRequest and cannot be null");
			}
			RequestedPermissions = requestedPermissions;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class UpgradeSessionRequest {\n");
			stringBuilder.Append("  SessionId: ").Append(SessionId).Append("\n");
			stringBuilder.Append("  RequestedPermissions: ").Append(RequestedPermissions).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[DataContract(Name = "UpgradeSessionResponse")]
	public class UpgradeSessionResponse
	{
		[DataMember(Name = "session", IsRequired = true, EmitDefaultValue = true)]
		public Session Session { get; set; }

		[DataMember(Name = "challenge", EmitDefaultValue = false)]
		public Challenge Challenge { get; set; }

		[JsonConstructor]
		protected UpgradeSessionResponse()
		{
		}

		public UpgradeSessionResponse(Session session = null, Challenge challenge = null)
		{
			if (session == null)
			{
				throw new ArgumentNullException("session is a required property for UpgradeSessionResponse and cannot be null");
			}
			Session = session;
			Challenge = challenge;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class UpgradeSessionResponse {\n");
			stringBuilder.Append("  Session: ").Append(Session).Append("\n");
			stringBuilder.Append("  Challenge: ").Append(Challenge).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[JsonConverter(typeof(StringEnumConverter))]
	public enum VerificationMethod
	{
		[EnumMember(Value = "age-estimation")]
		AgeEstimation = 1,
		[EnumMember(Value = "id-document")]
		IdDocument,
		[EnumMember(Value = "credit-card")]
		CreditCard,
		[EnumMember(Value = "personal-details")]
		PersonalDetails,
		[EnumMember(Value = "kws")]
		Kws,
		[EnumMember(Value = "age-attestation")]
		AgeAttestation
	}
	[DataContract(Name = "VerificationOptions")]
	public class VerificationOptions
	{
		[DataMember(Name = "sendEmail", EmitDefaultValue = true)]
		public bool SendEmail { get; set; }

		public VerificationOptions(bool sendEmail = false)
		{
			SendEmail = sendEmail;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class VerificationOptions {\n");
			stringBuilder.Append("  SendEmail: ").Append(SendEmail).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
	[JsonConverter(typeof(StringEnumConverter))]
	public enum VerificationStatus
	{
		[EnumMember(Value = "PASS")]
		PASS = 1,
		[EnumMember(Value = "FAIL")]
		FAIL,
		[EnumMember(Value = "PENDING")]
		PENDING,
		[EnumMember(Value = "INCONCLUSIVE")]
		INCONCLUSIVE,
		[EnumMember(Value = "TIMED_OUT")]
		TIMEDOUT
	}
	[JsonConverter(typeof(StringEnumConverter))]
	public enum VerificationStatusV2
	{
		[EnumMember(Value = "PASS")]
		PASS = 1,
		[EnumMember(Value = "FAIL")]
		FAIL,
		[EnumMember(Value = "PENDING")]
		PENDING,
		[EnumMember(Value = "IN_PROGRESS")]
		INPROGRESS
	}
	[DataContract(Name = "VerificationSubject")]
	public class VerificationSubject
	{
		[DataMember(Name = "email", EmitDefaultValue = false)]
		public string Email { get; set; }

		[DataMember(Name = "claimedAge", EmitDefaultValue = false)]
		public int ClaimedAge { get; set; }

		[DataMember(Name = "claimedDateOfBirth", EmitDefaultValue = false)]
		[JsonConverter(typeof(OpenAPIDateConverter))]
		public DateTime ClaimedDateOfBirth { get; set; }

		public VerificationSubject(string email = null, int claimedAge = 0, DateTime claimedDateOfBirth = default(DateTime))
		{
			Email = email;
			ClaimedAge = claimedAge;
			ClaimedDateOfBirth = claimedDateOfBirth;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("class VerificationSubject {\n");
			stringBuilder.Append("  Email: ").Append(Email).Append("\n");
			stringBuilder.Append("  ClaimedAge: ").Append(ClaimedAge).Append("\n");
			stringBuilder.Append("  ClaimedDateOfBirth: ").Append(ClaimedDateOfBirth).Append("\n");
			stringBuilder.Append("}\n");
			return stringBuilder.ToString();
		}

		public virtual string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
}
namespace KID.Client
{
	public class OpenAPIDateConverter : IsoDateTimeConverter
	{
		public OpenAPIDateConverter()
		{
			base.DateTimeFormat = "yyyy-MM-dd";
		}
	}
}
