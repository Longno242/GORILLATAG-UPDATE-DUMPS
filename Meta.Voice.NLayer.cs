using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Meta.Voice.NLayer.Decoder;

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
			FilePathsData = new byte[1929]
			{
				0, 0, 0, 1, 0, 0, 0, 114, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 118, 111, 105, 99,
				101, 64, 100, 51, 102, 54, 102, 51, 55, 98,
				56, 101, 49, 99, 92, 76, 105, 98, 92, 87,
				105, 116, 46, 97, 105, 92, 76, 105, 98, 92,
				116, 104, 105, 114, 100, 45, 112, 97, 114, 116,
				121, 92, 78, 76, 97, 121, 101, 114, 92, 68,
				101, 99, 111, 100, 101, 114, 92, 66, 105, 116,
				82, 101, 115, 101, 114, 118, 111, 105, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 111,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 118, 111,
				105, 99, 101, 64, 100, 51, 102, 54, 102, 51,
				55, 98, 56, 101, 49, 99, 92, 76, 105, 98,
				92, 87, 105, 116, 46, 97, 105, 92, 76, 105,
				98, 92, 116, 104, 105, 114, 100, 45, 112, 97,
				114, 116, 121, 92, 78, 76, 97, 121, 101, 114,
				92, 68, 101, 99, 111, 100, 101, 114, 92, 70,
				114, 97, 109, 101, 66, 97, 115, 101, 46, 99,
				115, 0, 0, 0, 2, 0, 0, 0, 109, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 118, 111, 105,
				99, 101, 64, 100, 51, 102, 54, 102, 51, 55,
				98, 56, 101, 49, 99, 92, 76, 105, 98, 92,
				87, 105, 116, 46, 97, 105, 92, 76, 105, 98,
				92, 116, 104, 105, 114, 100, 45, 112, 97, 114,
				116, 121, 92, 78, 76, 97, 121, 101, 114, 92,
				68, 101, 99, 111, 100, 101, 114, 92, 72, 117,
				102, 102, 109, 97, 110, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 110, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 118, 111, 105, 99, 101, 64,
				100, 51, 102, 54, 102, 51, 55, 98, 56, 101,
				49, 99, 92, 76, 105, 98, 92, 87, 105, 116,
				46, 97, 105, 92, 76, 105, 98, 92, 116, 104,
				105, 114, 100, 45, 112, 97, 114, 116, 121, 92,
				78, 76, 97, 121, 101, 114, 92, 68, 101, 99,
				111, 100, 101, 114, 92, 73, 68, 51, 70, 114,
				97, 109, 101, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 118, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 118, 111, 105, 99, 101, 64, 100, 51,
				102, 54, 102, 51, 55, 98, 56, 101, 49, 99,
				92, 76, 105, 98, 92, 87, 105, 116, 46, 97,
				105, 92, 76, 105, 98, 92, 116, 104, 105, 114,
				100, 45, 112, 97, 114, 116, 121, 92, 78, 76,
				97, 121, 101, 114, 92, 68, 101, 99, 111, 100,
				101, 114, 92, 76, 97, 121, 101, 114, 68, 101,
				99, 111, 100, 101, 114, 66, 97, 115, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 115,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 118, 111,
				105, 99, 101, 64, 100, 51, 102, 54, 102, 51,
				55, 98, 56, 101, 49, 99, 92, 76, 105, 98,
				92, 87, 105, 116, 46, 97, 105, 92, 76, 105,
				98, 92, 116, 104, 105, 114, 100, 45, 112, 97,
				114, 116, 121, 92, 78, 76, 97, 121, 101, 114,
				92, 68, 101, 99, 111, 100, 101, 114, 92, 76,
				97, 121, 101, 114, 73, 68, 101, 99, 111, 100,
				101, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 116, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 118, 111, 105, 99, 101, 64, 100, 51, 102,
				54, 102, 51, 55, 98, 56, 101, 49, 99, 92,
				76, 105, 98, 92, 87, 105, 116, 46, 97, 105,
				92, 76, 105, 98, 92, 116, 104, 105, 114, 100,
				45, 112, 97, 114, 116, 121, 92, 78, 76, 97,
				121, 101, 114, 92, 68, 101, 99, 111, 100, 101,
				114, 92, 76, 97, 121, 101, 114, 73, 73, 68,
				101, 99, 111, 100, 101, 114, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 120, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 118, 111, 105, 99, 101,
				64, 100, 51, 102, 54, 102, 51, 55, 98, 56,
				101, 49, 99, 92, 76, 105, 98, 92, 87, 105,
				116, 46, 97, 105, 92, 76, 105, 98, 92, 116,
				104, 105, 114, 100, 45, 112, 97, 114, 116, 121,
				92, 78, 76, 97, 121, 101, 114, 92, 68, 101,
				99, 111, 100, 101, 114, 92, 76, 97, 121, 101,
				114, 73, 73, 68, 101, 99, 111, 100, 101, 114,
				66, 97, 115, 101, 46, 99, 115, 0, 0, 0,
				2, 0, 0, 0, 117, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 118, 111, 105, 99, 101, 64, 100,
				51, 102, 54, 102, 51, 55, 98, 56, 101, 49,
				99, 92, 76, 105, 98, 92, 87, 105, 116, 46,
				97, 105, 92, 76, 105, 98, 92, 116, 104, 105,
				114, 100, 45, 112, 97, 114, 116, 121, 92, 78,
				76, 97, 121, 101, 114, 92, 68, 101, 99, 111,
				100, 101, 114, 92, 76, 97, 121, 101, 114, 73,
				73, 73, 68, 101, 99, 111, 100, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 111,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 118, 111,
				105, 99, 101, 64, 100, 51, 102, 54, 102, 51,
				55, 98, 56, 101, 49, 99, 92, 76, 105, 98,
				92, 87, 105, 116, 46, 97, 105, 92, 76, 105,
				98, 92, 116, 104, 105, 114, 100, 45, 112, 97,
				114, 116, 121, 92, 78, 76, 97, 121, 101, 114,
				92, 68, 101, 99, 111, 100, 101, 114, 92, 77,
				112, 101, 103, 70, 114, 97, 109, 101, 46, 99,
				115, 0, 0, 0, 2, 0, 0, 0, 118, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 118, 111, 105,
				99, 101, 64, 100, 51, 102, 54, 102, 51, 55,
				98, 56, 101, 49, 99, 92, 76, 105, 98, 92,
				87, 105, 116, 46, 97, 105, 92, 76, 105, 98,
				92, 116, 104, 105, 114, 100, 45, 112, 97, 114,
				116, 121, 92, 78, 76, 97, 121, 101, 114, 92,
				68, 101, 99, 111, 100, 101, 114, 92, 77, 112,
				101, 103, 83, 116, 114, 101, 97, 109, 82, 101,
				97, 100, 101, 114, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 117, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 118, 111, 105, 99, 101, 64, 100,
				51, 102, 54, 102, 51, 55, 98, 56, 101, 49,
				99, 92, 76, 105, 98, 92, 87, 105, 116, 46,
				97, 105, 92, 76, 105, 98, 92, 116, 104, 105,
				114, 100, 45, 112, 97, 114, 116, 121, 92, 78,
				76, 97, 121, 101, 114, 92, 68, 101, 99, 111,
				100, 101, 114, 92, 82, 105, 102, 102, 72, 101,
				97, 100, 101, 114, 70, 114, 97, 109, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 109,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 118, 111,
				105, 99, 101, 64, 100, 51, 102, 54, 102, 51,
				55, 98, 56, 101, 49, 99, 92, 76, 105, 98,
				92, 87, 105, 116, 46, 97, 105, 92, 76, 105,
				98, 92, 116, 104, 105, 114, 100, 45, 112, 97,
				114, 116, 121, 92, 78, 76, 97, 121, 101, 114,
				92, 68, 101, 99, 111, 100, 101, 114, 92, 86,
				66, 82, 73, 110, 102, 111, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 104, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 118, 111, 105, 99, 101,
				64, 100, 51, 102, 54, 102, 51, 55, 98, 56,
				101, 49, 99, 92, 76, 105, 98, 92, 87, 105,
				116, 46, 97, 105, 92, 76, 105, 98, 92, 116,
				104, 105, 114, 100, 45, 112, 97, 114, 116, 121,
				92, 78, 76, 97, 121, 101, 114, 92, 73, 77,
				112, 101, 103, 70, 114, 97, 109, 101, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 102, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 118, 111, 105,
				99, 101, 64, 100, 51, 102, 54, 102, 51, 55,
				98, 56, 101, 49, 99, 92, 76, 105, 98, 92,
				87, 105, 116, 46, 97, 105, 92, 76, 105, 98,
				92, 116, 104, 105, 114, 100, 45, 112, 97, 114,
				116, 121, 92, 78, 76, 97, 121, 101, 114, 92,
				77, 112, 101, 103, 70, 105, 108, 101, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 110, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 118, 111, 105,
				99, 101, 64, 100, 51, 102, 54, 102, 51, 55,
				98, 56, 101, 49, 99, 92, 76, 105, 98, 92,
				87, 105, 116, 46, 97, 105, 92, 76, 105, 98,
				92, 116, 104, 105, 114, 100, 45, 112, 97, 114,
				116, 121, 92, 78, 76, 97, 121, 101, 114, 92,
				77, 112, 101, 103, 70, 114, 97, 109, 101, 68,
				101, 99, 111, 100, 101, 114, 46, 99, 115
			},
			TypesData = new byte[834]
			{
				0, 0, 0, 0, 38, 77, 101, 116, 97, 46,
				86, 111, 105, 99, 101, 46, 78, 76, 97, 121,
				101, 114, 46, 68, 101, 99, 111, 100, 101, 114,
				124, 66, 105, 116, 82, 101, 115, 101, 114, 118,
				111, 105, 114, 0, 0, 0, 0, 35, 77, 101,
				116, 97, 46, 86, 111, 105, 99, 101, 46, 78,
				76, 97, 121, 101, 114, 46, 68, 101, 99, 111,
				100, 101, 114, 124, 70, 114, 97, 109, 101, 66,
				97, 115, 101, 0, 0, 0, 0, 33, 77, 101,
				116, 97, 46, 86, 111, 105, 99, 101, 46, 78,
				76, 97, 121, 101, 114, 46, 68, 101, 99, 111,
				100, 101, 114, 124, 72, 117, 102, 102, 109, 97,
				110, 0, 0, 0, 0, 49, 77, 101, 116, 97,
				46, 86, 111, 105, 99, 101, 46, 78, 76, 97,
				121, 101, 114, 46, 68, 101, 99, 111, 100, 101,
				114, 46, 72, 117, 102, 102, 109, 97, 110, 124,
				72, 117, 102, 102, 109, 97, 110, 76, 105, 115,
				116, 78, 111, 100, 101, 0, 0, 0, 0, 34,
				77, 101, 116, 97, 46, 86, 111, 105, 99, 101,
				46, 78, 76, 97, 121, 101, 114, 46, 68, 101,
				99, 111, 100, 101, 114, 124, 73, 68, 51, 70,
				114, 97, 109, 101, 0, 0, 0, 0, 42, 77,
				101, 116, 97, 46, 86, 111, 105, 99, 101, 46,
				78, 76, 97, 121, 101, 114, 46, 68, 101, 99,
				111, 100, 101, 114, 124, 76, 97, 121, 101, 114,
				68, 101, 99, 111, 100, 101, 114, 66, 97, 115,
				101, 0, 0, 0, 0, 39, 77, 101, 116, 97,
				46, 86, 111, 105, 99, 101, 46, 78, 76, 97,
				121, 101, 114, 46, 68, 101, 99, 111, 100, 101,
				114, 124, 76, 97, 121, 101, 114, 73, 68, 101,
				99, 111, 100, 101, 114, 0, 0, 0, 0, 40,
				77, 101, 116, 97, 46, 86, 111, 105, 99, 101,
				46, 78, 76, 97, 121, 101, 114, 46, 68, 101,
				99, 111, 100, 101, 114, 124, 76, 97, 121, 101,
				114, 73, 73, 68, 101, 99, 111, 100, 101, 114,
				0, 0, 0, 0, 44, 77, 101, 116, 97, 46,
				86, 111, 105, 99, 101, 46, 78, 76, 97, 121,
				101, 114, 46, 68, 101, 99, 111, 100, 101, 114,
				124, 76, 97, 121, 101, 114, 73, 73, 68, 101,
				99, 111, 100, 101, 114, 66, 97, 115, 101, 0,
				0, 0, 0, 41, 77, 101, 116, 97, 46, 86,
				111, 105, 99, 101, 46, 78, 76, 97, 121, 101,
				114, 46, 68, 101, 99, 111, 100, 101, 114, 124,
				76, 97, 121, 101, 114, 73, 73, 73, 68, 101,
				99, 111, 100, 101, 114, 0, 0, 0, 0, 52,
				77, 101, 116, 97, 46, 86, 111, 105, 99, 101,
				46, 78, 76, 97, 121, 101, 114, 46, 68, 101,
				99, 111, 100, 101, 114, 46, 76, 97, 121, 101,
				114, 73, 73, 73, 68, 101, 99, 111, 100, 101,
				114, 124, 72, 121, 98, 114, 105, 100, 77, 68,
				67, 84, 0, 0, 0, 0, 35, 77, 101, 116,
				97, 46, 86, 111, 105, 99, 101, 46, 78, 76,
				97, 121, 101, 114, 46, 68, 101, 99, 111, 100,
				101, 114, 124, 77, 112, 101, 103, 70, 114, 97,
				109, 101, 0, 0, 0, 0, 42, 77, 101, 116,
				97, 46, 86, 111, 105, 99, 101, 46, 78, 76,
				97, 121, 101, 114, 46, 68, 101, 99, 111, 100,
				101, 114, 124, 77, 112, 101, 103, 83, 116, 114,
				101, 97, 109, 82, 101, 97, 100, 101, 114, 0,
				0, 0, 0, 53, 77, 101, 116, 97, 46, 86,
				111, 105, 99, 101, 46, 78, 76, 97, 121, 101,
				114, 46, 68, 101, 99, 111, 100, 101, 114, 46,
				77, 112, 101, 103, 83, 116, 114, 101, 97, 109,
				82, 101, 97, 100, 101, 114, 124, 82, 101, 97,
				100, 66, 117, 102, 102, 101, 114, 0, 0, 0,
				0, 41, 77, 101, 116, 97, 46, 86, 111, 105,
				99, 101, 46, 78, 76, 97, 121, 101, 114, 46,
				68, 101, 99, 111, 100, 101, 114, 124, 82, 105,
				102, 102, 72, 101, 97, 100, 101, 114, 70, 114,
				97, 109, 101, 0, 0, 0, 0, 33, 77, 101,
				116, 97, 46, 86, 111, 105, 99, 101, 46, 78,
				76, 97, 121, 101, 114, 46, 68, 101, 99, 111,
				100, 101, 114, 124, 86, 66, 82, 73, 110, 102,
				111, 0, 0, 0, 0, 28, 77, 101, 116, 97,
				46, 86, 111, 105, 99, 101, 46, 78, 76, 97,
				121, 101, 114, 124, 73, 77, 112, 101, 103, 70,
				114, 97, 109, 101, 0, 0, 0, 0, 26, 77,
				101, 116, 97, 46, 86, 111, 105, 99, 101, 46,
				78, 76, 97, 121, 101, 114, 124, 77, 112, 101,
				103, 70, 105, 108, 101, 0, 0, 0, 0, 34,
				77, 101, 116, 97, 46, 86, 111, 105, 99, 101,
				46, 78, 76, 97, 121, 101, 114, 124, 77, 112,
				101, 103, 70, 114, 97, 109, 101, 68, 101, 99,
				111, 100, 101, 114
			},
			TotalFiles = 16,
			TotalTypes = 19,
			IsEditorOnly = false
		};
	}
}
namespace Meta.Voice.NLayer
{
	public enum MpegVersion
	{
		Unknown = 0,
		Version1 = 10,
		Version2 = 20,
		Version25 = 25
	}
	public enum MpegLayer
	{
		Unknown,
		LayerI,
		LayerII,
		LayerIII
	}
	public enum MpegChannelMode
	{
		Stereo,
		JointStereo,
		DualChannel,
		Mono
	}
	public enum StereoMode
	{
		Both,
		LeftOnly,
		RightOnly,
		DownmixToMono
	}
	public interface IMpegFrame
	{
		int SampleRate { get; }

		int SampleRateIndex { get; }

		int FrameLength { get; }

		int BitRate { get; }

		MpegVersion Version { get; }

		MpegLayer Layer { get; }

		MpegChannelMode ChannelMode { get; }

		int ChannelModeExtension { get; }

		int SampleCount { get; }

		int BitRateIndex { get; }

		bool IsCopyrighted { get; }

		bool HasCrc { get; }

		bool IsCorrupted { get; }

		void Reset();

		int ReadBits(int bitCount);
	}
	public class MpegFile : IDisposable
	{
		private Stream _stream;

		private bool _closeStream;

		private bool _eofFound;

		private MpegStreamReader _reader;

		private MpegFrameDecoder _decoder;

		private object _seekLock = new object();

		private long _position;

		private float[] _readBuf = new float[2304];

		private int _readBufLen;

		private int _readBufOfs;

		public int SampleRate => _reader.SampleRate;

		public int Channels => _reader.Channels;

		public bool CanSeek => _reader.CanSeek;

		public long Length => _reader.SampleCount * _reader.Channels * 4;

		public TimeSpan Duration
		{
			get
			{
				long sampleCount = _reader.SampleCount;
				if (sampleCount == -1)
				{
					return TimeSpan.Zero;
				}
				return TimeSpan.FromSeconds((double)sampleCount / (double)_reader.SampleRate);
			}
		}

		public long Position
		{
			get
			{
				return _position;
			}
			set
			{
				if (!_reader.CanSeek)
				{
					throw new InvalidOperationException("Cannot Seek!");
				}
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				long num = value / 4 / _reader.Channels;
				int num2 = 0;
				if (num >= _reader.FirstFrameSampleCount)
				{
					num2 = _reader.FirstFrameSampleCount;
					num -= num2;
				}
				lock (_seekLock)
				{
					long num3 = _reader.SeekTo(num);
					if (num3 == -1)
					{
						throw new ArgumentOutOfRangeException("value");
					}
					_decoder.Reset();
					if (num2 != 0)
					{
						_decoder.DecodeFrame(_reader.NextFrame(), _readBuf, 0);
						num3 += num2;
					}
					_position = num3 * 4 * _reader.Channels;
					_eofFound = false;
					_readBufOfs = (_readBufLen = 0);
				}
			}
		}

		public TimeSpan Time
		{
			get
			{
				return TimeSpan.FromSeconds((double)_position / 4.0 / (double)_reader.Channels / (double)_reader.SampleRate);
			}
			set
			{
				Position = (long)(value.TotalSeconds * (double)_reader.SampleRate * (double)_reader.Channels * 4.0);
			}
		}

		public StereoMode StereoMode
		{
			get
			{
				return _decoder.StereoMode;
			}
			set
			{
				_decoder.StereoMode = value;
			}
		}

		public MpegFile(string fileName)
		{
			Init(File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read), closeStream: true);
		}

		public MpegFile(Stream stream)
		{
			Init(stream, closeStream: false);
		}

		private void Init(Stream stream, bool closeStream)
		{
			_stream = stream;
			_closeStream = closeStream;
			_reader = new MpegStreamReader(_stream);
			_decoder = new MpegFrameDecoder();
		}

		public void Dispose()
		{
			if (_closeStream)
			{
				_stream.Dispose();
				_closeStream = false;
			}
		}

		public void SetEQ(float[] eq)
		{
			_decoder.SetEQ(eq);
		}

		public int ReadSamples(byte[] buffer, int index, int count)
		{
			if (index < 0 || index + count > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			count -= count % 4;
			return ReadSamplesImpl(buffer, index, count, 32);
		}

		public int ReadSamples(float[] buffer, int index, int count)
		{
			if (index < 0 || index + count > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ReadSamplesImpl(buffer, index * 4, count * 4, 32) / 4;
		}

		public int ReadSamplesInt16(byte[] buffer, int index, int count)
		{
			if (index < 0 || index + count > buffer.Length * 2)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ReadSamplesImpl(buffer, index, count, 16) * 2 / 4;
		}

		public int ReadSamplesInt8(byte[] buffer, int index, int count)
		{
			if (index < 0 || index + count > buffer.Length * 4)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ReadSamplesImpl(buffer, index, count, 8) / 4;
		}

		private int ReadSamplesImpl(Array buffer, int index, int count, int bitDepth)
		{
			int num = 0;
			lock (_seekLock)
			{
				while (count > 0)
				{
					if (_readBufLen > _readBufOfs)
					{
						int num2 = _readBufLen - _readBufOfs;
						if (num2 > count)
						{
							num2 = count;
						}
						if (bitDepth == 32)
						{
							Buffer.BlockCopy(_readBuf, _readBufOfs, buffer, index, num2);
						}
						else
						{
							for (int i = 0; i < num2 / 4; i++)
							{
								switch (bitDepth)
								{
								case 8:
									buffer.SetValue((byte)Math.Round(127.5f * _readBuf[_readBufOfs / 4 + i] + 127.5f), index / 4 + i);
									break;
								case 16:
								{
									int num3 = (int)Math.Round(32767.5f * _readBuf[_readBufOfs / 4 + i] - 0.5f);
									if (num3 < 0)
									{
										num3 += 65536;
									}
									buffer.SetValue((byte)(num3 % 256), 2 * (index / 4 + i));
									buffer.SetValue((byte)(num3 / 256), 2 * (index / 4 + i) + 1);
									break;
								}
								}
							}
						}
						num += num2;
						count -= num2;
						index += num2;
						_position += num2;
						_readBufOfs += num2;
						if (_readBufOfs == _readBufLen)
						{
							_readBufLen = 0;
						}
					}
					if (_readBufLen != 0)
					{
						continue;
					}
					if (_eofFound)
					{
						break;
					}
					MpegFrame mpegFrame = _reader.NextFrame();
					if (mpegFrame == null)
					{
						_eofFound = true;
						break;
					}
					try
					{
						_readBufLen = _decoder.DecodeFrame(mpegFrame, _readBuf, 0) * 4;
						_readBufOfs = 0;
					}
					catch (InvalidDataException)
					{
						_decoder.Reset();
						_readBufOfs = (_readBufLen = 0);
					}
					catch (EndOfStreamException)
					{
						_eofFound = true;
						break;
					}
					finally
					{
						mpegFrame.ClearBuffer();
					}
				}
			}
			return num;
		}
	}
	public class MpegFrameDecoder
	{
		private LayerIDecoder _layerIDecoder;

		private LayerIIDecoder _layerIIDecoder;

		private LayerIIIDecoder _layerIIIDecoder = new LayerIIIDecoder();

		private float[] _eqFactors;

		private float[] _ch0;

		private float[] _ch1;

		public StereoMode StereoMode { get; set; }

		public MpegFrameDecoder()
		{
			_ch0 = new float[1152];
			_ch1 = new float[1152];
		}

		public void SetEQ(float[] eq)
		{
			if (eq != null)
			{
				float[] array = new float[32];
				for (int i = 0; i < eq.Length; i++)
				{
					array[i] = (float)Math.Pow(2.0, eq[i] / 6f);
				}
				_eqFactors = array;
			}
			else
			{
				_eqFactors = null;
			}
		}

		public int DecodeFrame(IMpegFrame frame, byte[] dest, int destOffset)
		{
			if (frame == null)
			{
				throw new ArgumentNullException("frame");
			}
			if (dest == null)
			{
				throw new ArgumentNullException("dest");
			}
			if (destOffset % 4 != 0)
			{
				throw new ArgumentException("Must be an even multiple of 4", "destOffset");
			}
			if ((dest.Length - destOffset) / 4 < ((frame.ChannelMode == MpegChannelMode.Mono) ? 1 : 2) * frame.SampleCount)
			{
				throw new ArgumentException("Buffer not large enough!  Must be big enough to hold the frame's entire output.  This is up to 9,216 bytes.", "dest");
			}
			return DecodeFrameImpl(frame, dest, destOffset / 4) * 4;
		}

		public int DecodeFrame(IMpegFrame frame, float[] dest, int destOffset)
		{
			if (frame == null)
			{
				throw new ArgumentNullException("frame");
			}
			if (dest == null)
			{
				throw new ArgumentNullException("dest");
			}
			if (dest.Length - destOffset < ((frame.ChannelMode == MpegChannelMode.Mono) ? 1 : 2) * frame.SampleCount)
			{
				throw new ArgumentException("Buffer not large enough!  Must be big enough to hold the frame's entire output.  This is up to 2,304 elements.", "dest");
			}
			return DecodeFrameImpl(frame, dest, destOffset);
		}

		private int DecodeFrameImpl(IMpegFrame frame, Array dest, int destOffset)
		{
			frame.Reset();
			LayerDecoderBase layerDecoderBase = null;
			switch (frame.Layer)
			{
			case MpegLayer.LayerI:
				if (_layerIDecoder == null)
				{
					_layerIDecoder = new LayerIDecoder();
				}
				layerDecoderBase = _layerIDecoder;
				break;
			case MpegLayer.LayerII:
				if (_layerIIDecoder == null)
				{
					_layerIIDecoder = new LayerIIDecoder();
				}
				layerDecoderBase = _layerIIDecoder;
				break;
			case MpegLayer.LayerIII:
				if (_layerIIIDecoder == null)
				{
					_layerIIIDecoder = new LayerIIIDecoder();
				}
				layerDecoderBase = _layerIIIDecoder;
				break;
			}
			if (layerDecoderBase != null)
			{
				layerDecoderBase.SetEQ(_eqFactors);
				layerDecoderBase.StereoMode = StereoMode;
				int num = layerDecoderBase.DecodeFrame(frame, _ch0, _ch1);
				if (frame.ChannelMode == MpegChannelMode.Mono)
				{
					Buffer.BlockCopy(_ch0, 0, dest, destOffset * 4, num * 4);
				}
				else
				{
					for (int i = 0; i < num; i++)
					{
						Buffer.BlockCopy(_ch0, i * 4, dest, destOffset * 4, 4);
						destOffset++;
						Buffer.BlockCopy(_ch1, i * 4, dest, destOffset * 4, 4);
						destOffset++;
					}
					num *= 2;
				}
				return num;
			}
			return 0;
		}

		public void Reset()
		{
			if (_layerIDecoder != null)
			{
				_layerIDecoder.ResetForSeek();
			}
			if (_layerIIDecoder != null)
			{
				_layerIIDecoder.ResetForSeek();
			}
			if (_layerIIIDecoder != null)
			{
				_layerIIIDecoder.ResetForSeek();
			}
		}
	}
}
namespace Meta.Voice.NLayer.Decoder
{
	internal class BitReservoir
	{
		private byte[] _buf = new byte[8192];

		private int _start;

		private int _end = -1;

		private int _bitsLeft;

		private long _bitsRead;

		public int BitsAvailable
		{
			get
			{
				if (_bitsLeft > 0)
				{
					return (_end + _buf.Length - _start) % _buf.Length * 8 + _bitsLeft;
				}
				return 0;
			}
		}

		public long BitsRead => _bitsRead;

		private static int GetSlots(IMpegFrame frame)
		{
			int num = frame.FrameLength - 4;
			if (frame.HasCrc)
			{
				num -= 2;
			}
			if (frame.Version == MpegVersion.Version1 && frame.ChannelMode != MpegChannelMode.Mono)
			{
				return num - 32;
			}
			if (frame.Version > MpegVersion.Version1 && frame.ChannelMode == MpegChannelMode.Mono)
			{
				return num - 9;
			}
			return num - 17;
		}

		public bool AddBits(IMpegFrame frame, int overlap)
		{
			int end = _end;
			int num = GetSlots(frame);
			while (--num >= 0)
			{
				int num2 = frame.ReadBits(8);
				if (num2 == -1)
				{
					throw new InvalidDataException("Frame did not have enough bytes!");
				}
				_buf[++_end] = (byte)num2;
				if (_end == _buf.Length - 1)
				{
					_end = -1;
				}
			}
			_bitsLeft = 8;
			if (end == -1)
			{
				return overlap == 0;
			}
			if ((end + 1 - _start + _buf.Length) % _buf.Length >= overlap)
			{
				_start = (end + 1 - overlap + _buf.Length) % _buf.Length;
				return true;
			}
			_start = end + overlap;
			return false;
		}

		public int GetBits(int count)
		{
			int readCount;
			int result = TryPeekBits(count, out readCount);
			if (readCount < count)
			{
				throw new InvalidDataException("Reservoir did not have enough bytes!");
			}
			SkipBits(count);
			return result;
		}

		public int Get1Bit()
		{
			if (_bitsLeft == 0)
			{
				throw new InvalidDataException("Reservoir did not have enough bytes!");
			}
			_bitsLeft--;
			_bitsRead++;
			int result = (_buf[_start] >> _bitsLeft) & 1;
			if (_bitsLeft == 0 && (_start = (_start + 1) % _buf.Length) != _end + 1)
			{
				_bitsLeft = 8;
			}
			return result;
		}

		public int TryPeekBits(int count, out int readCount)
		{
			if (count < 0 || count > 32)
			{
				throw new ArgumentOutOfRangeException("count", "Must return between 0 and 32 bits!");
			}
			if (_bitsLeft == 0 || count == 0)
			{
				readCount = 0;
				return 0;
			}
			int num = _buf[_start];
			if (count < _bitsLeft)
			{
				num >>= _bitsLeft - count;
				num &= (1 << count) - 1;
				readCount = count;
				return num;
			}
			num &= (1 << _bitsLeft) - 1;
			count -= _bitsLeft;
			readCount = _bitsLeft;
			int num2 = _start;
			while (count > 0 && (num2 = (num2 + 1) % _buf.Length) != _end + 1)
			{
				int num3 = Math.Min(count, 8);
				num <<= num3;
				num |= _buf[num2] >> (8 - num3) % 8;
				count -= num3;
				readCount += num3;
			}
			return num;
		}

		public void SkipBits(int count)
		{
			if (count > 0)
			{
				if (count > BitsAvailable)
				{
					throw new ArgumentOutOfRangeException("count");
				}
				int num = 8 - _bitsLeft + count;
				_start = (num / 8 + _start) % _buf.Length;
				_bitsLeft = 8 - num % 8;
				_bitsRead += count;
			}
		}

		public void RewindBits(int count)
		{
			_bitsLeft += count;
			_bitsRead -= count;
			while (_bitsLeft > 8)
			{
				_start--;
				_bitsLeft -= 8;
			}
			while (_start < 0)
			{
				_start += _buf.Length;
			}
		}

		public void FlushBits()
		{
			if (_bitsLeft < 8)
			{
				SkipBits(_bitsLeft);
			}
		}

		public void Reset()
		{
			_start = 0;
			_end = -1;
			_bitsLeft = 0;
		}
	}
	internal abstract class FrameBase
	{
		private static int _totalAllocation;

		private MpegStreamReader _reader;

		private byte[] _savedBuffer;

		internal static int TotalAllocation => Interlocked.CompareExchange(ref _totalAllocation, 0, 0);

		internal long Offset { get; private set; }

		internal int Length { get; set; }

		internal bool Validate(long offset, MpegStreamReader reader)
		{
			Offset = offset;
			_reader = reader;
			int num = Validate();
			if (num > 0)
			{
				Length = num;
				return true;
			}
			return false;
		}

		protected int Read(int offset, byte[] buffer)
		{
			return Read(offset, buffer, 0, buffer.Length);
		}

		protected int Read(int offset, byte[] buffer, int index, int count)
		{
			if (_savedBuffer != null)
			{
				if (index < 0 || index + count > buffer.Length)
				{
					return 0;
				}
				if (offset < 0 || offset >= _savedBuffer.Length)
				{
					return 0;
				}
				if (offset + count > _savedBuffer.Length)
				{
					count = _savedBuffer.Length - index;
				}
				Array.Copy(_savedBuffer, offset, buffer, index, count);
				return count;
			}
			return _reader.Read(Offset + offset, buffer, index, count);
		}

		protected int ReadByte(int offset)
		{
			if (_savedBuffer != null)
			{
				if (offset < 0)
				{
					throw new ArgumentOutOfRangeException();
				}
				if (offset >= _savedBuffer.Length)
				{
					return -1;
				}
				return _savedBuffer[offset];
			}
			return _reader.ReadByte(Offset + offset);
		}

		protected abstract int Validate();

		internal void SaveBuffer()
		{
			_savedBuffer = new byte[Length];
			_reader.Read(Offset, _savedBuffer, 0, Length);
			Interlocked.Add(ref _totalAllocation, Length);
		}

		internal void ClearBuffer()
		{
			Interlocked.Add(ref _totalAllocation, -Length);
			_savedBuffer = null;
		}

		internal virtual void Parse()
		{
		}
	}
	internal class Huffman
	{
		private class HuffmanListNode
		{
			internal byte Value;

			internal int Length;

			internal int Bits;

			internal int Mask;

			internal HuffmanListNode Next;
		}

		private static readonly byte[][,] _codeTables;

		private static readonly float[] _floatLookup;

		private static HuffmanListNode[] _llCache;

		private static int[] _llCacheMaxBits;

		private static readonly int[] LIN_BITS;

		static Huffman()
		{
			_codeTables = new byte[17][,]
			{
				new byte[7, 2]
				{
					{ 2, 1 },
					{ 0, 0 },
					{ 2, 1 },
					{ 0, 16 },
					{ 2, 1 },
					{ 0, 1 },
					{ 0, 17 }
				},
				new byte[17, 2]
				{
					{ 2, 1 },
					{ 0, 0 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 16 },
					{ 0, 1 },
					{ 2, 1 },
					{ 0, 17 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 32 },
					{ 0, 33 },
					{ 2, 1 },
					{ 0, 18 },
					{ 2, 1 },
					{ 0, 2 },
					{ 0, 34 }
				},
				new byte[17, 2]
				{
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 0 },
					{ 0, 1 },
					{ 2, 1 },
					{ 0, 17 },
					{ 2, 1 },
					{ 0, 16 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 32 },
					{ 0, 33 },
					{ 2, 1 },
					{ 0, 18 },
					{ 2, 1 },
					{ 0, 2 },
					{ 0, 34 }
				},
				new byte[31, 2]
				{
					{ 2, 1 },
					{ 0, 0 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 16 },
					{ 0, 1 },
					{ 2, 1 },
					{ 0, 17 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 32 },
					{ 0, 2 },
					{ 2, 1 },
					{ 0, 33 },
					{ 0, 18 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 34 },
					{ 0, 48 },
					{ 2, 1 },
					{ 0, 3 },
					{ 0, 19 },
					{ 2, 1 },
					{ 0, 49 },
					{ 2, 1 },
					{ 0, 50 },
					{ 2, 1 },
					{ 0, 35 },
					{ 0, 51 }
				},
				new byte[31, 2]
				{
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 0 },
					{ 0, 16 },
					{ 0, 17 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 1 },
					{ 2, 1 },
					{ 0, 32 },
					{ 0, 33 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 18 },
					{ 2, 1 },
					{ 0, 2 },
					{ 0, 34 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 49 },
					{ 0, 19 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 48 },
					{ 0, 50 },
					{ 2, 1 },
					{ 0, 35 },
					{ 2, 1 },
					{ 0, 3 },
					{ 0, 51 }
				},
				new byte[71, 2]
				{
					{ 2, 1 },
					{ 0, 0 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 16 },
					{ 0, 1 },
					{ 8, 1 },
					{ 2, 1 },
					{ 0, 17 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 32 },
					{ 0, 2 },
					{ 0, 33 },
					{ 18, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 18 },
					{ 2, 1 },
					{ 0, 34 },
					{ 0, 48 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 49 },
					{ 0, 19 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 3 },
					{ 0, 50 },
					{ 2, 1 },
					{ 0, 35 },
					{ 0, 4 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 64 },
					{ 0, 65 },
					{ 2, 1 },
					{ 0, 20 },
					{ 2, 1 },
					{ 0, 66 },
					{ 0, 36 },
					{ 12, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 51 },
					{ 0, 67 },
					{ 0, 80 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 52 },
					{ 0, 5 },
					{ 0, 81 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 21 },
					{ 2, 1 },
					{ 0, 82 },
					{ 0, 37 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 68 },
					{ 0, 53 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 83 },
					{ 0, 84 },
					{ 2, 1 },
					{ 0, 69 },
					{ 0, 85 }
				},
				new byte[71, 2]
				{
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 0 },
					{ 2, 1 },
					{ 0, 16 },
					{ 0, 1 },
					{ 2, 1 },
					{ 0, 17 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 33 },
					{ 0, 18 },
					{ 14, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 32 },
					{ 0, 2 },
					{ 2, 1 },
					{ 0, 34 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 48 },
					{ 0, 3 },
					{ 2, 1 },
					{ 0, 49 },
					{ 0, 19 },
					{ 14, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 50 },
					{ 0, 35 },
					{ 2, 1 },
					{ 0, 64 },
					{ 0, 4 },
					{ 2, 1 },
					{ 0, 65 },
					{ 2, 1 },
					{ 0, 20 },
					{ 0, 66 },
					{ 12, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 36 },
					{ 2, 1 },
					{ 0, 51 },
					{ 0, 80 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 67 },
					{ 0, 52 },
					{ 0, 81 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 21 },
					{ 2, 1 },
					{ 0, 5 },
					{ 0, 82 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 37 },
					{ 2, 1 },
					{ 0, 68 },
					{ 0, 53 },
					{ 2, 1 },
					{ 0, 83 },
					{ 2, 1 },
					{ 0, 69 },
					{ 2, 1 },
					{ 0, 84 },
					{ 0, 85 }
				},
				new byte[71, 2]
				{
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 0 },
					{ 0, 16 },
					{ 2, 1 },
					{ 0, 1 },
					{ 0, 17 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 32 },
					{ 0, 33 },
					{ 2, 1 },
					{ 0, 18 },
					{ 2, 1 },
					{ 0, 2 },
					{ 0, 34 },
					{ 12, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 48 },
					{ 0, 3 },
					{ 0, 49 },
					{ 2, 1 },
					{ 0, 19 },
					{ 2, 1 },
					{ 0, 50 },
					{ 0, 35 },
					{ 12, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 65 },
					{ 0, 20 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 64 },
					{ 0, 51 },
					{ 2, 1 },
					{ 0, 66 },
					{ 0, 36 },
					{ 10, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 4 },
					{ 0, 80 },
					{ 0, 67 },
					{ 2, 1 },
					{ 0, 52 },
					{ 0, 81 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 21 },
					{ 0, 82 },
					{ 2, 1 },
					{ 0, 37 },
					{ 0, 68 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 5 },
					{ 0, 84 },
					{ 0, 83 },
					{ 2, 1 },
					{ 0, 53 },
					{ 2, 1 },
					{ 0, 69 },
					{ 0, 85 }
				},
				new byte[127, 2]
				{
					{ 2, 1 },
					{ 0, 0 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 16 },
					{ 0, 1 },
					{ 10, 1 },
					{ 2, 1 },
					{ 0, 17 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 32 },
					{ 0, 2 },
					{ 2, 1 },
					{ 0, 33 },
					{ 0, 18 },
					{ 28, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 34 },
					{ 0, 48 },
					{ 2, 1 },
					{ 0, 49 },
					{ 0, 19 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 3 },
					{ 0, 50 },
					{ 2, 1 },
					{ 0, 35 },
					{ 0, 64 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 65 },
					{ 0, 20 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 4 },
					{ 0, 51 },
					{ 2, 1 },
					{ 0, 66 },
					{ 0, 36 },
					{ 28, 1 },
					{ 10, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 80 },
					{ 0, 5 },
					{ 0, 96 },
					{ 2, 1 },
					{ 0, 97 },
					{ 0, 22 },
					{ 12, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 67 },
					{ 0, 52 },
					{ 0, 81 },
					{ 2, 1 },
					{ 0, 21 },
					{ 2, 1 },
					{ 0, 82 },
					{ 0, 37 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 38 },
					{ 0, 54 },
					{ 0, 113 },
					{ 20, 1 },
					{ 8, 1 },
					{ 2, 1 },
					{ 0, 23 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 68 },
					{ 0, 83 },
					{ 0, 6 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 53 },
					{ 0, 69 },
					{ 0, 98 },
					{ 2, 1 },
					{ 0, 112 },
					{ 2, 1 },
					{ 0, 7 },
					{ 0, 100 },
					{ 14, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 114 },
					{ 0, 39 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 99 },
					{ 2, 1 },
					{ 0, 84 },
					{ 0, 85 },
					{ 2, 1 },
					{ 0, 70 },
					{ 0, 115 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 55 },
					{ 0, 101 },
					{ 2, 1 },
					{ 0, 86 },
					{ 0, 116 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 71 },
					{ 2, 1 },
					{ 0, 102 },
					{ 0, 117 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 87 },
					{ 0, 118 },
					{ 2, 1 },
					{ 0, 103 },
					{ 0, 119 }
				},
				new byte[127, 2]
				{
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 0 },
					{ 2, 1 },
					{ 0, 16 },
					{ 0, 1 },
					{ 8, 1 },
					{ 2, 1 },
					{ 0, 17 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 32 },
					{ 0, 2 },
					{ 0, 18 },
					{ 24, 1 },
					{ 8, 1 },
					{ 2, 1 },
					{ 0, 33 },
					{ 2, 1 },
					{ 0, 34 },
					{ 2, 1 },
					{ 0, 48 },
					{ 0, 3 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 49 },
					{ 0, 19 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 50 },
					{ 0, 35 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 64 },
					{ 0, 4 },
					{ 2, 1 },
					{ 0, 65 },
					{ 0, 20 },
					{ 30, 1 },
					{ 16, 1 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 66 },
					{ 0, 36 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 51 },
					{ 0, 67 },
					{ 0, 80 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 52 },
					{ 0, 81 },
					{ 0, 97 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 22 },
					{ 2, 1 },
					{ 0, 6 },
					{ 0, 38 },
					{ 2, 1 },
					{ 0, 98 },
					{ 2, 1 },
					{ 0, 21 },
					{ 2, 1 },
					{ 0, 5 },
					{ 0, 82 },
					{ 16, 1 },
					{ 10, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 37 },
					{ 0, 68 },
					{ 0, 96 },
					{ 2, 1 },
					{ 0, 99 },
					{ 0, 54 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 112 },
					{ 0, 23 },
					{ 0, 113 },
					{ 16, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 7 },
					{ 0, 100 },
					{ 0, 114 },
					{ 2, 1 },
					{ 0, 39 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 83 },
					{ 0, 53 },
					{ 2, 1 },
					{ 0, 84 },
					{ 0, 69 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 70 },
					{ 0, 115 },
					{ 2, 1 },
					{ 0, 55 },
					{ 2, 1 },
					{ 0, 101 },
					{ 0, 86 },
					{ 10, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 85 },
					{ 0, 87 },
					{ 0, 116 },
					{ 2, 1 },
					{ 0, 71 },
					{ 0, 102 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 117 },
					{ 0, 118 },
					{ 2, 1 },
					{ 0, 103 },
					{ 0, 119 }
				},
				new byte[127, 2]
				{
					{ 12, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 16 },
					{ 0, 1 },
					{ 2, 1 },
					{ 0, 17 },
					{ 2, 1 },
					{ 0, 0 },
					{ 2, 1 },
					{ 0, 32 },
					{ 0, 2 },
					{ 16, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 33 },
					{ 0, 18 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 34 },
					{ 0, 49 },
					{ 2, 1 },
					{ 0, 19 },
					{ 2, 1 },
					{ 0, 48 },
					{ 2, 1 },
					{ 0, 3 },
					{ 0, 64 },
					{ 26, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 50 },
					{ 0, 35 },
					{ 2, 1 },
					{ 0, 65 },
					{ 0, 51 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 20 },
					{ 0, 66 },
					{ 2, 1 },
					{ 0, 36 },
					{ 2, 1 },
					{ 0, 4 },
					{ 0, 80 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 67 },
					{ 0, 52 },
					{ 2, 1 },
					{ 0, 81 },
					{ 0, 21 },
					{ 28, 1 },
					{ 14, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 82 },
					{ 0, 37 },
					{ 2, 1 },
					{ 0, 83 },
					{ 0, 53 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 96 },
					{ 0, 22 },
					{ 0, 97 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 98 },
					{ 0, 38 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 5 },
					{ 0, 6 },
					{ 0, 68 },
					{ 2, 1 },
					{ 0, 84 },
					{ 0, 69 },
					{ 18, 1 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 99 },
					{ 0, 54 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 112 },
					{ 0, 7 },
					{ 0, 113 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 23 },
					{ 0, 100 },
					{ 2, 1 },
					{ 0, 70 },
					{ 0, 114 },
					{ 10, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 39 },
					{ 2, 1 },
					{ 0, 85 },
					{ 0, 115 },
					{ 2, 1 },
					{ 0, 55 },
					{ 0, 86 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 101 },
					{ 0, 116 },
					{ 2, 1 },
					{ 0, 71 },
					{ 0, 102 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 117 },
					{ 0, 87 },
					{ 2, 1 },
					{ 0, 118 },
					{ 2, 1 },
					{ 0, 103 },
					{ 0, 119 }
				},
				new byte[511, 2]
				{
					{ 2, 1 },
					{ 0, 0 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 16 },
					{ 2, 1 },
					{ 0, 1 },
					{ 0, 17 },
					{ 28, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 32 },
					{ 0, 2 },
					{ 2, 1 },
					{ 0, 33 },
					{ 0, 18 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 34 },
					{ 0, 48 },
					{ 2, 1 },
					{ 0, 3 },
					{ 0, 49 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 19 },
					{ 2, 1 },
					{ 0, 50 },
					{ 0, 35 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 64 },
					{ 0, 4 },
					{ 0, 65 },
					{ 70, 1 },
					{ 28, 1 },
					{ 14, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 20 },
					{ 2, 1 },
					{ 0, 51 },
					{ 0, 66 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 36 },
					{ 0, 80 },
					{ 2, 1 },
					{ 0, 67 },
					{ 0, 52 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 81 },
					{ 0, 21 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 5 },
					{ 0, 82 },
					{ 2, 1 },
					{ 0, 37 },
					{ 2, 1 },
					{ 0, 68 },
					{ 0, 83 },
					{ 14, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 96 },
					{ 0, 6 },
					{ 2, 1 },
					{ 0, 97 },
					{ 0, 22 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 128 },
					{ 0, 8 },
					{ 0, 129 },
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 53 },
					{ 0, 98 },
					{ 2, 1 },
					{ 0, 38 },
					{ 0, 84 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 69 },
					{ 0, 99 },
					{ 2, 1 },
					{ 0, 54 },
					{ 0, 112 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 7 },
					{ 0, 85 },
					{ 0, 113 },
					{ 2, 1 },
					{ 0, 23 },
					{ 2, 1 },
					{ 0, 39 },
					{ 0, 55 },
					{ 72, 1 },
					{ 24, 1 },
					{ 12, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 24 },
					{ 0, 130 },
					{ 2, 1 },
					{ 0, 40 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 100 },
					{ 0, 70 },
					{ 0, 114 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 132 },
					{ 0, 72 },
					{ 2, 1 },
					{ 0, 144 },
					{ 0, 9 },
					{ 2, 1 },
					{ 0, 145 },
					{ 0, 25 },
					{ 24, 1 },
					{ 14, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 115 },
					{ 0, 101 },
					{ 2, 1 },
					{ 0, 86 },
					{ 0, 116 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 71 },
					{ 0, 102 },
					{ 0, 131 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 56 },
					{ 2, 1 },
					{ 0, 117 },
					{ 0, 87 },
					{ 2, 1 },
					{ 0, 146 },
					{ 0, 41 },
					{ 14, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 103 },
					{ 0, 133 },
					{ 2, 1 },
					{ 0, 88 },
					{ 0, 57 },
					{ 2, 1 },
					{ 0, 147 },
					{ 2, 1 },
					{ 0, 73 },
					{ 0, 134 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 160 },
					{ 2, 1 },
					{ 0, 104 },
					{ 0, 10 },
					{ 2, 1 },
					{ 0, 161 },
					{ 0, 26 },
					{ 68, 1 },
					{ 24, 1 },
					{ 12, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 162 },
					{ 0, 42 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 149 },
					{ 0, 89 },
					{ 2, 1 },
					{ 0, 163 },
					{ 0, 58 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 74 },
					{ 0, 150 },
					{ 2, 1 },
					{ 0, 176 },
					{ 0, 11 },
					{ 2, 1 },
					{ 0, 177 },
					{ 0, 27 },
					{ 20, 1 },
					{ 8, 1 },
					{ 2, 1 },
					{ 0, 178 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 118 },
					{ 0, 119 },
					{ 0, 148 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 135 },
					{ 0, 120 },
					{ 0, 164 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 105 },
					{ 0, 165 },
					{ 0, 43 },
					{ 12, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 90 },
					{ 0, 136 },
					{ 0, 179 },
					{ 2, 1 },
					{ 0, 59 },
					{ 2, 1 },
					{ 0, 121 },
					{ 0, 166 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 106 },
					{ 0, 180 },
					{ 0, 192 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 12 },
					{ 0, 152 },
					{ 0, 193 },
					{ 60, 1 },
					{ 22, 1 },
					{ 10, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 28 },
					{ 2, 1 },
					{ 0, 137 },
					{ 0, 181 },
					{ 2, 1 },
					{ 0, 91 },
					{ 0, 194 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 44 },
					{ 0, 60 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 182 },
					{ 0, 107 },
					{ 2, 1 },
					{ 0, 196 },
					{ 0, 76 },
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 168 },
					{ 0, 138 },
					{ 2, 1 },
					{ 0, 208 },
					{ 0, 13 },
					{ 2, 1 },
					{ 0, 209 },
					{ 2, 1 },
					{ 0, 75 },
					{ 2, 1 },
					{ 0, 151 },
					{ 0, 167 },
					{ 12, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 195 },
					{ 2, 1 },
					{ 0, 122 },
					{ 0, 153 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 197 },
					{ 0, 92 },
					{ 0, 183 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 29 },
					{ 0, 210 },
					{ 2, 1 },
					{ 0, 45 },
					{ 2, 1 },
					{ 0, 123 },
					{ 0, 211 },
					{ 52, 1 },
					{ 28, 1 },
					{ 12, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 61 },
					{ 0, 198 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 108 },
					{ 0, 169 },
					{ 2, 1 },
					{ 0, 154 },
					{ 0, 212 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 184 },
					{ 0, 139 },
					{ 2, 1 },
					{ 0, 77 },
					{ 0, 199 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 124 },
					{ 0, 213 },
					{ 2, 1 },
					{ 0, 93 },
					{ 0, 224 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 225 },
					{ 0, 30 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 14 },
					{ 0, 46 },
					{ 0, 226 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 227 },
					{ 0, 109 },
					{ 2, 1 },
					{ 0, 140 },
					{ 0, 228 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 229 },
					{ 0, 186 },
					{ 0, 240 },
					{ 38, 1 },
					{ 16, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 241 },
					{ 0, 31 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 170 },
					{ 0, 155 },
					{ 0, 185 },
					{ 2, 1 },
					{ 0, 62 },
					{ 2, 1 },
					{ 0, 214 },
					{ 0, 200 },
					{ 12, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 78 },
					{ 2, 1 },
					{ 0, 215 },
					{ 0, 125 },
					{ 2, 1 },
					{ 0, 171 },
					{ 2, 1 },
					{ 0, 94 },
					{ 0, 201 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 15 },
					{ 2, 1 },
					{ 0, 156 },
					{ 0, 110 },
					{ 2, 1 },
					{ 0, 242 },
					{ 0, 47 },
					{ 32, 1 },
					{ 16, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 216 },
					{ 0, 141 },
					{ 0, 63 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 243 },
					{ 2, 1 },
					{ 0, 230 },
					{ 0, 202 },
					{ 2, 1 },
					{ 0, 244 },
					{ 0, 79 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 187 },
					{ 0, 172 },
					{ 2, 1 },
					{ 0, 231 },
					{ 0, 245 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 217 },
					{ 0, 157 },
					{ 2, 1 },
					{ 0, 95 },
					{ 0, 232 },
					{ 30, 1 },
					{ 12, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 111 },
					{ 2, 1 },
					{ 0, 246 },
					{ 0, 203 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 188 },
					{ 0, 173 },
					{ 0, 218 },
					{ 8, 1 },
					{ 2, 1 },
					{ 0, 247 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 126 },
					{ 0, 127 },
					{ 0, 142 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 158 },
					{ 0, 174 },
					{ 0, 204 },
					{ 2, 1 },
					{ 0, 248 },
					{ 0, 143 },
					{ 18, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 219 },
					{ 0, 189 },
					{ 2, 1 },
					{ 0, 234 },
					{ 0, 249 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 159 },
					{ 0, 235 },
					{ 2, 1 },
					{ 0, 190 },
					{ 2, 1 },
					{ 0, 205 },
					{ 0, 250 },
					{ 14, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 221 },
					{ 0, 236 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 233 },
					{ 0, 175 },
					{ 0, 220 },
					{ 2, 1 },
					{ 0, 206 },
					{ 0, 251 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 191 },
					{ 0, 222 },
					{ 2, 1 },
					{ 0, 207 },
					{ 0, 238 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 223 },
					{ 0, 239 },
					{ 2, 1 },
					{ 0, 255 },
					{ 2, 1 },
					{ 0, 237 },
					{ 2, 1 },
					{ 0, 253 },
					{ 2, 1 },
					{ 0, 252 },
					{ 0, 254 }
				},
				new byte[511, 2]
				{
					{ 16, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 0 },
					{ 2, 1 },
					{ 0, 16 },
					{ 0, 1 },
					{ 2, 1 },
					{ 0, 17 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 32 },
					{ 0, 2 },
					{ 2, 1 },
					{ 0, 33 },
					{ 0, 18 },
					{ 50, 1 },
					{ 16, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 34 },
					{ 2, 1 },
					{ 0, 48 },
					{ 0, 49 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 19 },
					{ 2, 1 },
					{ 0, 3 },
					{ 0, 64 },
					{ 2, 1 },
					{ 0, 50 },
					{ 0, 35 },
					{ 14, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 4 },
					{ 0, 20 },
					{ 0, 65 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 51 },
					{ 0, 66 },
					{ 2, 1 },
					{ 0, 36 },
					{ 0, 67 },
					{ 10, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 52 },
					{ 2, 1 },
					{ 0, 80 },
					{ 0, 5 },
					{ 2, 1 },
					{ 0, 81 },
					{ 0, 21 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 82 },
					{ 0, 37 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 68 },
					{ 0, 83 },
					{ 0, 97 },
					{ 90, 1 },
					{ 36, 1 },
					{ 18, 1 },
					{ 10, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 53 },
					{ 2, 1 },
					{ 0, 96 },
					{ 0, 6 },
					{ 2, 1 },
					{ 0, 22 },
					{ 0, 98 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 38 },
					{ 0, 84 },
					{ 2, 1 },
					{ 0, 69 },
					{ 0, 99 },
					{ 10, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 54 },
					{ 2, 1 },
					{ 0, 112 },
					{ 0, 7 },
					{ 2, 1 },
					{ 0, 113 },
					{ 0, 85 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 23 },
					{ 0, 100 },
					{ 2, 1 },
					{ 0, 114 },
					{ 0, 39 },
					{ 24, 1 },
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 70 },
					{ 0, 115 },
					{ 2, 1 },
					{ 0, 55 },
					{ 0, 101 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 86 },
					{ 0, 128 },
					{ 2, 1 },
					{ 0, 8 },
					{ 0, 116 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 129 },
					{ 0, 24 },
					{ 2, 1 },
					{ 0, 130 },
					{ 0, 40 },
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 71 },
					{ 0, 102 },
					{ 2, 1 },
					{ 0, 131 },
					{ 0, 56 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 117 },
					{ 0, 87 },
					{ 2, 1 },
					{ 0, 132 },
					{ 0, 72 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 144 },
					{ 0, 25 },
					{ 0, 145 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 146 },
					{ 0, 118 },
					{ 2, 1 },
					{ 0, 103 },
					{ 0, 41 },
					{ 92, 1 },
					{ 36, 1 },
					{ 18, 1 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 133 },
					{ 0, 88 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 9 },
					{ 0, 119 },
					{ 0, 147 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 57 },
					{ 0, 148 },
					{ 2, 1 },
					{ 0, 73 },
					{ 0, 134 },
					{ 10, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 104 },
					{ 2, 1 },
					{ 0, 160 },
					{ 0, 10 },
					{ 2, 1 },
					{ 0, 161 },
					{ 0, 26 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 162 },
					{ 0, 42 },
					{ 2, 1 },
					{ 0, 149 },
					{ 0, 89 },
					{ 26, 1 },
					{ 14, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 163 },
					{ 2, 1 },
					{ 0, 58 },
					{ 0, 135 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 120 },
					{ 0, 164 },
					{ 2, 1 },
					{ 0, 74 },
					{ 0, 150 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 105 },
					{ 0, 176 },
					{ 0, 177 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 27 },
					{ 0, 165 },
					{ 0, 178 },
					{ 14, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 90 },
					{ 0, 43 },
					{ 2, 1 },
					{ 0, 136 },
					{ 0, 151 },
					{ 2, 1 },
					{ 0, 179 },
					{ 2, 1 },
					{ 0, 121 },
					{ 0, 59 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 106 },
					{ 0, 180 },
					{ 2, 1 },
					{ 0, 75 },
					{ 0, 193 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 152 },
					{ 0, 137 },
					{ 2, 1 },
					{ 0, 28 },
					{ 0, 181 },
					{ 80, 1 },
					{ 34, 1 },
					{ 16, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 91 },
					{ 0, 44 },
					{ 0, 194 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 11 },
					{ 0, 192 },
					{ 0, 166 },
					{ 2, 1 },
					{ 0, 167 },
					{ 0, 122 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 195 },
					{ 0, 60 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 12 },
					{ 0, 153 },
					{ 0, 182 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 107 },
					{ 0, 196 },
					{ 2, 1 },
					{ 0, 76 },
					{ 0, 168 },
					{ 20, 1 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 138 },
					{ 0, 197 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 208 },
					{ 0, 92 },
					{ 0, 209 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 183 },
					{ 0, 123 },
					{ 2, 1 },
					{ 0, 29 },
					{ 2, 1 },
					{ 0, 13 },
					{ 0, 45 },
					{ 12, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 210 },
					{ 0, 211 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 61 },
					{ 0, 198 },
					{ 2, 1 },
					{ 0, 108 },
					{ 0, 169 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 154 },
					{ 0, 184 },
					{ 0, 212 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 139 },
					{ 0, 77 },
					{ 2, 1 },
					{ 0, 199 },
					{ 0, 124 },
					{ 68, 1 },
					{ 34, 1 },
					{ 18, 1 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 213 },
					{ 0, 93 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 224 },
					{ 0, 14 },
					{ 0, 225 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 30 },
					{ 0, 226 },
					{ 2, 1 },
					{ 0, 170 },
					{ 0, 46 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 185 },
					{ 0, 155 },
					{ 2, 1 },
					{ 0, 227 },
					{ 0, 214 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 109 },
					{ 0, 62 },
					{ 2, 1 },
					{ 0, 200 },
					{ 0, 140 },
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 228 },
					{ 0, 78 },
					{ 2, 1 },
					{ 0, 215 },
					{ 0, 125 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 229 },
					{ 0, 186 },
					{ 2, 1 },
					{ 0, 171 },
					{ 0, 94 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 201 },
					{ 0, 156 },
					{ 2, 1 },
					{ 0, 241 },
					{ 0, 31 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 240 },
					{ 0, 110 },
					{ 0, 242 },
					{ 2, 1 },
					{ 0, 47 },
					{ 0, 230 },
					{ 38, 1 },
					{ 18, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 216 },
					{ 0, 243 },
					{ 2, 1 },
					{ 0, 63 },
					{ 0, 244 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 79 },
					{ 2, 1 },
					{ 0, 141 },
					{ 0, 217 },
					{ 2, 1 },
					{ 0, 187 },
					{ 0, 202 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 172 },
					{ 0, 231 },
					{ 2, 1 },
					{ 0, 126 },
					{ 0, 245 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 157 },
					{ 0, 95 },
					{ 2, 1 },
					{ 0, 232 },
					{ 0, 142 },
					{ 2, 1 },
					{ 0, 246 },
					{ 0, 203 },
					{ 34, 1 },
					{ 18, 1 },
					{ 10, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 15 },
					{ 0, 174 },
					{ 0, 111 },
					{ 2, 1 },
					{ 0, 188 },
					{ 0, 218 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 173 },
					{ 0, 247 },
					{ 2, 1 },
					{ 0, 127 },
					{ 0, 233 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 158 },
					{ 0, 204 },
					{ 2, 1 },
					{ 0, 248 },
					{ 0, 143 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 219 },
					{ 0, 189 },
					{ 2, 1 },
					{ 0, 234 },
					{ 0, 249 },
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 159 },
					{ 0, 220 },
					{ 2, 1 },
					{ 0, 205 },
					{ 0, 235 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 190 },
					{ 0, 250 },
					{ 2, 1 },
					{ 0, 175 },
					{ 0, 221 },
					{ 14, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 236 },
					{ 0, 206 },
					{ 0, 251 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 191 },
					{ 0, 237 },
					{ 2, 1 },
					{ 0, 222 },
					{ 0, 252 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 207 },
					{ 0, 253 },
					{ 0, 238 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 223 },
					{ 0, 254 },
					{ 2, 1 },
					{ 0, 239 },
					{ 0, 255 }
				},
				new byte[511, 2]
				{
					{ 2, 1 },
					{ 0, 0 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 16 },
					{ 2, 1 },
					{ 0, 1 },
					{ 0, 17 },
					{ 42, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 32 },
					{ 0, 2 },
					{ 2, 1 },
					{ 0, 33 },
					{ 0, 18 },
					{ 10, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 34 },
					{ 2, 1 },
					{ 0, 48 },
					{ 0, 3 },
					{ 2, 1 },
					{ 0, 49 },
					{ 0, 19 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 50 },
					{ 0, 35 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 64 },
					{ 0, 4 },
					{ 0, 65 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 20 },
					{ 2, 1 },
					{ 0, 51 },
					{ 0, 66 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 36 },
					{ 0, 80 },
					{ 2, 1 },
					{ 0, 67 },
					{ 0, 52 },
					{ 138, 1 },
					{ 40, 1 },
					{ 16, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 5 },
					{ 0, 21 },
					{ 0, 81 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 82 },
					{ 0, 37 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 68 },
					{ 0, 53 },
					{ 0, 83 },
					{ 10, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 96 },
					{ 0, 6 },
					{ 0, 97 },
					{ 2, 1 },
					{ 0, 22 },
					{ 0, 98 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 38 },
					{ 0, 84 },
					{ 2, 1 },
					{ 0, 69 },
					{ 0, 99 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 54 },
					{ 0, 112 },
					{ 0, 113 },
					{ 40, 1 },
					{ 18, 1 },
					{ 8, 1 },
					{ 2, 1 },
					{ 0, 23 },
					{ 2, 1 },
					{ 0, 7 },
					{ 2, 1 },
					{ 0, 85 },
					{ 0, 100 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 114 },
					{ 0, 39 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 70 },
					{ 0, 101 },
					{ 0, 115 },
					{ 10, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 55 },
					{ 2, 1 },
					{ 0, 86 },
					{ 0, 8 },
					{ 2, 1 },
					{ 0, 128 },
					{ 0, 129 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 24 },
					{ 2, 1 },
					{ 0, 116 },
					{ 0, 71 },
					{ 2, 1 },
					{ 0, 130 },
					{ 2, 1 },
					{ 0, 40 },
					{ 0, 102 },
					{ 24, 1 },
					{ 14, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 131 },
					{ 0, 56 },
					{ 2, 1 },
					{ 0, 117 },
					{ 0, 132 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 72 },
					{ 0, 144 },
					{ 0, 145 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 25 },
					{ 2, 1 },
					{ 0, 9 },
					{ 0, 118 },
					{ 2, 1 },
					{ 0, 146 },
					{ 0, 41 },
					{ 14, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 133 },
					{ 0, 88 },
					{ 2, 1 },
					{ 0, 147 },
					{ 0, 57 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 160 },
					{ 0, 10 },
					{ 0, 26 },
					{ 8, 1 },
					{ 2, 1 },
					{ 0, 162 },
					{ 2, 1 },
					{ 0, 103 },
					{ 2, 1 },
					{ 0, 87 },
					{ 0, 73 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 148 },
					{ 2, 1 },
					{ 0, 119 },
					{ 0, 134 },
					{ 2, 1 },
					{ 0, 161 },
					{ 2, 1 },
					{ 0, 104 },
					{ 0, 149 },
					{ 220, 1 },
					{ 126, 1 },
					{ 50, 1 },
					{ 26, 1 },
					{ 12, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 42 },
					{ 2, 1 },
					{ 0, 89 },
					{ 0, 58 },
					{ 2, 1 },
					{ 0, 163 },
					{ 2, 1 },
					{ 0, 135 },
					{ 0, 120 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 164 },
					{ 0, 74 },
					{ 2, 1 },
					{ 0, 150 },
					{ 0, 105 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 176 },
					{ 0, 11 },
					{ 0, 177 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 27 },
					{ 0, 178 },
					{ 2, 1 },
					{ 0, 43 },
					{ 2, 1 },
					{ 0, 165 },
					{ 0, 90 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 179 },
					{ 2, 1 },
					{ 0, 166 },
					{ 0, 106 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 180 },
					{ 0, 75 },
					{ 2, 1 },
					{ 0, 12 },
					{ 0, 193 },
					{ 30, 1 },
					{ 14, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 181 },
					{ 0, 194 },
					{ 0, 44 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 167 },
					{ 0, 195 },
					{ 2, 1 },
					{ 0, 107 },
					{ 0, 196 },
					{ 8, 1 },
					{ 2, 1 },
					{ 0, 29 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 136 },
					{ 0, 151 },
					{ 0, 59 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 209 },
					{ 0, 210 },
					{ 2, 1 },
					{ 0, 45 },
					{ 0, 211 },
					{ 18, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 30 },
					{ 0, 46 },
					{ 0, 226 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 121 },
					{ 0, 152 },
					{ 0, 192 },
					{ 2, 1 },
					{ 0, 28 },
					{ 2, 1 },
					{ 0, 137 },
					{ 0, 91 },
					{ 14, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 60 },
					{ 2, 1 },
					{ 0, 122 },
					{ 0, 182 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 76 },
					{ 0, 153 },
					{ 2, 1 },
					{ 0, 168 },
					{ 0, 138 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 13 },
					{ 2, 1 },
					{ 0, 197 },
					{ 0, 92 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 61 },
					{ 0, 198 },
					{ 2, 1 },
					{ 0, 108 },
					{ 0, 154 },
					{ 88, 1 },
					{ 86, 1 },
					{ 36, 1 },
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 139 },
					{ 0, 77 },
					{ 2, 1 },
					{ 0, 199 },
					{ 0, 124 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 213 },
					{ 0, 93 },
					{ 2, 1 },
					{ 0, 224 },
					{ 0, 14 },
					{ 8, 1 },
					{ 2, 1 },
					{ 0, 227 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 208 },
					{ 0, 183 },
					{ 0, 123 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 169 },
					{ 0, 184 },
					{ 0, 212 },
					{ 2, 1 },
					{ 0, 225 },
					{ 2, 1 },
					{ 0, 170 },
					{ 0, 185 },
					{ 24, 1 },
					{ 10, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 155 },
					{ 0, 214 },
					{ 0, 109 },
					{ 2, 1 },
					{ 0, 62 },
					{ 0, 200 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 140 },
					{ 0, 228 },
					{ 0, 78 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 215 },
					{ 0, 229 },
					{ 2, 1 },
					{ 0, 186 },
					{ 0, 171 },
					{ 12, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 156 },
					{ 0, 230 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 110 },
					{ 0, 216 },
					{ 2, 1 },
					{ 0, 141 },
					{ 0, 187 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 231 },
					{ 0, 157 },
					{ 2, 1 },
					{ 0, 232 },
					{ 0, 142 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 203 },
					{ 0, 188 },
					{ 0, 158 },
					{ 0, 241 },
					{ 2, 1 },
					{ 0, 31 },
					{ 2, 1 },
					{ 0, 15 },
					{ 0, 47 },
					{ 66, 1 },
					{ 56, 1 },
					{ 2, 1 },
					{ 0, 242 },
					{ 52, 1 },
					{ 50, 1 },
					{ 20, 1 },
					{ 8, 1 },
					{ 2, 1 },
					{ 0, 189 },
					{ 2, 1 },
					{ 0, 94 },
					{ 2, 1 },
					{ 0, 125 },
					{ 0, 201 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 202 },
					{ 2, 1 },
					{ 0, 172 },
					{ 0, 126 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 218 },
					{ 0, 173 },
					{ 0, 204 },
					{ 10, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 174 },
					{ 2, 1 },
					{ 0, 219 },
					{ 0, 220 },
					{ 2, 1 },
					{ 0, 205 },
					{ 0, 190 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 235 },
					{ 0, 237 },
					{ 0, 238 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 217 },
					{ 0, 234 },
					{ 0, 233 },
					{ 2, 1 },
					{ 0, 222 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 221 },
					{ 0, 236 },
					{ 0, 206 },
					{ 0, 63 },
					{ 0, 240 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 243 },
					{ 0, 244 },
					{ 2, 1 },
					{ 0, 79 },
					{ 2, 1 },
					{ 0, 245 },
					{ 0, 95 },
					{ 10, 1 },
					{ 2, 1 },
					{ 0, 255 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 246 },
					{ 0, 111 },
					{ 2, 1 },
					{ 0, 247 },
					{ 0, 127 },
					{ 12, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 143 },
					{ 2, 1 },
					{ 0, 248 },
					{ 0, 249 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 159 },
					{ 0, 250 },
					{ 0, 175 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 251 },
					{ 0, 191 },
					{ 2, 1 },
					{ 0, 252 },
					{ 0, 207 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 253 },
					{ 0, 223 },
					{ 2, 1 },
					{ 0, 254 },
					{ 0, 239 }
				},
				new byte[512, 2]
				{
					{ 60, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 0 },
					{ 0, 16 },
					{ 2, 1 },
					{ 0, 1 },
					{ 0, 17 },
					{ 14, 1 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 32 },
					{ 0, 2 },
					{ 0, 33 },
					{ 2, 1 },
					{ 0, 18 },
					{ 2, 1 },
					{ 0, 34 },
					{ 2, 1 },
					{ 0, 48 },
					{ 0, 3 },
					{ 14, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 49 },
					{ 0, 19 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 50 },
					{ 0, 35 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 64 },
					{ 0, 4 },
					{ 0, 65 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 20 },
					{ 0, 51 },
					{ 2, 1 },
					{ 0, 66 },
					{ 0, 36 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 67 },
					{ 0, 52 },
					{ 0, 81 },
					{ 6, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 80 },
					{ 0, 5 },
					{ 0, 21 },
					{ 2, 1 },
					{ 0, 82 },
					{ 0, 37 },
					{ 250, 1 },
					{ 98, 1 },
					{ 34, 1 },
					{ 18, 1 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 68 },
					{ 0, 83 },
					{ 2, 1 },
					{ 0, 53 },
					{ 2, 1 },
					{ 0, 96 },
					{ 0, 6 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 97 },
					{ 0, 22 },
					{ 2, 1 },
					{ 0, 98 },
					{ 0, 38 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 84 },
					{ 0, 69 },
					{ 2, 1 },
					{ 0, 99 },
					{ 0, 54 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 113 },
					{ 0, 85 },
					{ 2, 1 },
					{ 0, 100 },
					{ 0, 70 },
					{ 32, 1 },
					{ 14, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 114 },
					{ 2, 1 },
					{ 0, 39 },
					{ 0, 55 },
					{ 2, 1 },
					{ 0, 115 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 112 },
					{ 0, 7 },
					{ 0, 23 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 101 },
					{ 0, 86 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 128 },
					{ 0, 8 },
					{ 0, 129 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 116 },
					{ 0, 71 },
					{ 2, 1 },
					{ 0, 24 },
					{ 0, 130 },
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 40 },
					{ 0, 102 },
					{ 2, 1 },
					{ 0, 131 },
					{ 0, 56 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 117 },
					{ 0, 87 },
					{ 2, 1 },
					{ 0, 132 },
					{ 0, 72 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 145 },
					{ 0, 25 },
					{ 2, 1 },
					{ 0, 146 },
					{ 0, 118 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 103 },
					{ 0, 41 },
					{ 2, 1 },
					{ 0, 133 },
					{ 0, 88 },
					{ 92, 1 },
					{ 34, 1 },
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 147 },
					{ 0, 57 },
					{ 2, 1 },
					{ 0, 148 },
					{ 0, 73 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 119 },
					{ 0, 134 },
					{ 2, 1 },
					{ 0, 104 },
					{ 0, 161 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 162 },
					{ 0, 42 },
					{ 2, 1 },
					{ 0, 149 },
					{ 0, 89 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 163 },
					{ 0, 58 },
					{ 2, 1 },
					{ 0, 135 },
					{ 2, 1 },
					{ 0, 120 },
					{ 0, 74 },
					{ 22, 1 },
					{ 12, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 164 },
					{ 0, 150 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 105 },
					{ 0, 177 },
					{ 2, 1 },
					{ 0, 27 },
					{ 0, 165 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 178 },
					{ 2, 1 },
					{ 0, 90 },
					{ 0, 43 },
					{ 2, 1 },
					{ 0, 136 },
					{ 0, 179 },
					{ 16, 1 },
					{ 10, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 144 },
					{ 2, 1 },
					{ 0, 9 },
					{ 0, 160 },
					{ 2, 1 },
					{ 0, 151 },
					{ 0, 121 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 166 },
					{ 0, 106 },
					{ 0, 180 },
					{ 12, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 26 },
					{ 2, 1 },
					{ 0, 10 },
					{ 0, 176 },
					{ 2, 1 },
					{ 0, 59 },
					{ 2, 1 },
					{ 0, 11 },
					{ 0, 192 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 75 },
					{ 0, 193 },
					{ 2, 1 },
					{ 0, 152 },
					{ 0, 137 },
					{ 67, 1 },
					{ 34, 1 },
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 28 },
					{ 0, 181 },
					{ 2, 1 },
					{ 0, 91 },
					{ 0, 194 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 44 },
					{ 0, 167 },
					{ 2, 1 },
					{ 0, 122 },
					{ 0, 195 },
					{ 10, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 60 },
					{ 2, 1 },
					{ 0, 12 },
					{ 0, 208 },
					{ 2, 1 },
					{ 0, 182 },
					{ 0, 107 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 196 },
					{ 0, 76 },
					{ 2, 1 },
					{ 0, 153 },
					{ 0, 168 },
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 138 },
					{ 0, 197 },
					{ 2, 1 },
					{ 0, 92 },
					{ 0, 209 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 183 },
					{ 0, 123 },
					{ 2, 1 },
					{ 0, 29 },
					{ 0, 210 },
					{ 9, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 45 },
					{ 0, 211 },
					{ 2, 1 },
					{ 0, 61 },
					{ 0, 198 },
					{ 85, 250 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 108 },
					{ 0, 169 },
					{ 2, 1 },
					{ 0, 154 },
					{ 0, 212 },
					{ 32, 1 },
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 184 },
					{ 0, 139 },
					{ 2, 1 },
					{ 0, 77 },
					{ 0, 199 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 124 },
					{ 0, 213 },
					{ 2, 1 },
					{ 0, 93 },
					{ 0, 225 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 30 },
					{ 0, 226 },
					{ 2, 1 },
					{ 0, 170 },
					{ 0, 185 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 155 },
					{ 0, 227 },
					{ 2, 1 },
					{ 0, 214 },
					{ 0, 109 },
					{ 20, 1 },
					{ 10, 1 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 62 },
					{ 2, 1 },
					{ 0, 46 },
					{ 0, 78 },
					{ 2, 1 },
					{ 0, 200 },
					{ 0, 140 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 228 },
					{ 0, 215 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 125 },
					{ 0, 171 },
					{ 0, 229 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 186 },
					{ 0, 94 },
					{ 2, 1 },
					{ 0, 201 },
					{ 2, 1 },
					{ 0, 156 },
					{ 0, 110 },
					{ 8, 1 },
					{ 2, 1 },
					{ 0, 230 },
					{ 2, 1 },
					{ 0, 13 },
					{ 2, 1 },
					{ 0, 224 },
					{ 0, 14 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 216 },
					{ 0, 141 },
					{ 2, 1 },
					{ 0, 187 },
					{ 0, 202 },
					{ 74, 1 },
					{ 2, 1 },
					{ 0, 255 },
					{ 64, 1 },
					{ 58, 1 },
					{ 32, 1 },
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 172 },
					{ 0, 231 },
					{ 2, 1 },
					{ 0, 126 },
					{ 0, 217 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 157 },
					{ 0, 232 },
					{ 2, 1 },
					{ 0, 142 },
					{ 0, 203 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 188 },
					{ 0, 218 },
					{ 2, 1 },
					{ 0, 173 },
					{ 0, 233 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 158 },
					{ 0, 204 },
					{ 2, 1 },
					{ 0, 219 },
					{ 0, 189 },
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 234 },
					{ 0, 174 },
					{ 2, 1 },
					{ 0, 220 },
					{ 0, 205 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 235 },
					{ 0, 190 },
					{ 2, 1 },
					{ 0, 221 },
					{ 0, 236 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 206 },
					{ 0, 237 },
					{ 2, 1 },
					{ 0, 222 },
					{ 0, 238 },
					{ 0, 15 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 240 },
					{ 0, 31 },
					{ 0, 241 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 242 },
					{ 0, 47 },
					{ 2, 1 },
					{ 0, 243 },
					{ 0, 63 },
					{ 18, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 244 },
					{ 0, 79 },
					{ 2, 1 },
					{ 0, 245 },
					{ 0, 95 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 246 },
					{ 0, 111 },
					{ 2, 1 },
					{ 0, 247 },
					{ 2, 1 },
					{ 0, 127 },
					{ 0, 143 },
					{ 10, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 248 },
					{ 0, 249 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 159 },
					{ 0, 175 },
					{ 0, 250 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 251 },
					{ 0, 191 },
					{ 2, 1 },
					{ 0, 252 },
					{ 0, 207 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 253 },
					{ 0, 223 },
					{ 2, 1 },
					{ 0, 254 },
					{ 0, 239 }
				},
				new byte[31, 2]
				{
					{ 2, 1 },
					{ 0, 0 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 8 },
					{ 0, 4 },
					{ 2, 1 },
					{ 0, 1 },
					{ 0, 2 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 12 },
					{ 0, 10 },
					{ 2, 1 },
					{ 0, 3 },
					{ 0, 6 },
					{ 6, 1 },
					{ 2, 1 },
					{ 0, 9 },
					{ 2, 1 },
					{ 0, 5 },
					{ 0, 7 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 14 },
					{ 0, 13 },
					{ 2, 1 },
					{ 0, 15 },
					{ 0, 11 }
				},
				new byte[31, 2]
				{
					{ 16, 1 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 0 },
					{ 0, 1 },
					{ 2, 1 },
					{ 0, 2 },
					{ 0, 3 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 4 },
					{ 0, 5 },
					{ 2, 1 },
					{ 0, 6 },
					{ 0, 7 },
					{ 8, 1 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 8 },
					{ 0, 9 },
					{ 2, 1 },
					{ 0, 10 },
					{ 0, 11 },
					{ 4, 1 },
					{ 2, 1 },
					{ 0, 12 },
					{ 0, 13 },
					{ 2, 1 },
					{ 0, 14 },
					{ 0, 15 }
				}
			};
			_llCache = new HuffmanListNode[_codeTables.Length];
			_llCacheMaxBits = new int[_codeTables.Length];
			LIN_BITS = new int[32]
			{
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 1, 2, 3, 4,
				6, 8, 10, 13, 4, 5, 6, 7, 8, 9,
				11, 13
			};
			_floatLookup = new float[8207];
			for (int i = 0; i < 8207; i++)
			{
				_floatLookup[i] = (float)Math.Pow(i, 1.3333333333333333);
			}
		}

		internal static void Decode(BitReservoir br, int table, out float x, out float y)
		{
			if (table == 0 || table == 4 || table == 14)
			{
				x = (y = 0f);
				return;
			}
			byte num = DecodeSymbol(br, table);
			int num2 = num >> 4;
			int num3 = num & 0xF;
			int num4 = LIN_BITS[table];
			if (num4 > 0 && num2 == 15)
			{
				num2 += br.GetBits(num4);
			}
			if (num2 != 0 && br.Get1Bit() != 0)
			{
				x = 0f - _floatLookup[num2];
			}
			else
			{
				x = _floatLookup[num2];
			}
			if (num4 > 0 && num3 == 15)
			{
				num3 += br.GetBits(num4);
			}
			if (num3 != 0 && br.Get1Bit() != 0)
			{
				y = 0f - _floatLookup[num3];
			}
			else
			{
				y = _floatLookup[num3];
			}
		}

		internal static void Decode(BitReservoir br, int table, out float x, out float y, out float v, out float w)
		{
			byte num = DecodeSymbol(br, table);
			v = (w = (x = (y = 0f)));
			if ((num & 8) != 0)
			{
				if (br.Get1Bit() == 1)
				{
					v = 0f - _floatLookup[1];
				}
				else
				{
					v = _floatLookup[1];
				}
			}
			if ((num & 4) != 0)
			{
				if (br.Get1Bit() == 1)
				{
					w = 0f - _floatLookup[1];
				}
				else
				{
					w = _floatLookup[1];
				}
			}
			if ((num & 2) != 0)
			{
				if (br.Get1Bit() == 1)
				{
					x = 0f - _floatLookup[1];
				}
				else
				{
					x = _floatLookup[1];
				}
			}
			if ((num & 1) != 0)
			{
				if (br.Get1Bit() == 1)
				{
					y = 0f - _floatLookup[1];
				}
				else
				{
					y = _floatLookup[1];
				}
			}
		}

		private static byte DecodeSymbol(BitReservoir br, int table)
		{
			int maxBits;
			HuffmanListNode huffmanListNode = GetNode(table, out maxBits);
			int readCount;
			int num = br.TryPeekBits(maxBits, out readCount);
			if (readCount < maxBits)
			{
				num <<= maxBits - readCount;
			}
			while (huffmanListNode != null && huffmanListNode.Length <= readCount)
			{
				if ((num & huffmanListNode.Mask) == huffmanListNode.Bits)
				{
					br.SkipBits(huffmanListNode.Length);
					break;
				}
				huffmanListNode = huffmanListNode.Next;
			}
			if (huffmanListNode != null && huffmanListNode.Length <= readCount)
			{
				return huffmanListNode.Value;
			}
			return 0;
		}

		private static HuffmanListNode GetNode(int table, out int maxBits)
		{
			int num = table;
			if (num > 16)
			{
				num = ((num > 31) ? (num - 17) : ((num < 24) ? 13 : 14));
			}
			else
			{
				if (num > 13)
				{
					num--;
				}
				if (num > 3)
				{
					num--;
				}
				num--;
			}
			if (_llCache[num] == null)
			{
				_llCache[num] = InitTable(_codeTables[num], out maxBits);
				_llCacheMaxBits[num] = maxBits;
			}
			else
			{
				maxBits = _llCacheMaxBits[num];
			}
			return _llCache[num];
		}

		private static HuffmanListNode InitTable(byte[,] tree, out int maxBits)
		{
			List<byte> list = new List<byte>();
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			int length = tree.GetLength(0);
			for (int i = 0; i < length; i++)
			{
				if (tree[i, 0] == 0)
				{
					int num = 0;
					int item = 0;
					int num2 = i;
					do
					{
						num2 = FindPreviousNode(tree, num2, out var bit);
						num |= bit << item++;
					}
					while (num2 > 0);
					list.Add(tree[i, 1]);
					list2.Add(item);
					list3.Add(num);
				}
			}
			return BuildLinkedList(list, list2, list3, out maxBits);
		}

		private static int FindPreviousNode(byte[,] tree, int idx, out int bit)
		{
			for (int num = idx - 1; num >= 0; num--)
			{
				if (tree[num, 0] != 0)
				{
					for (int i = 0; i < 2; i++)
					{
						if (num + tree[num, i] != idx)
						{
							continue;
						}
						if (tree[num, i] >= 250)
						{
							int result = FindPreviousNode(tree, num, out bit);
							if (bit != i)
							{
								throw new InvalidOperationException();
							}
							return result;
						}
						bit = i;
						return num;
					}
				}
			}
			throw new InvalidOperationException();
		}

		private static HuffmanListNode BuildLinkedList(List<byte> values, List<int> lengthList, List<int> codeList, out int maxBits)
		{
			HuffmanListNode[] array = new HuffmanListNode[lengthList.Count];
			maxBits = lengthList.Max();
			for (int i = 0; i < array.Length; i++)
			{
				int num = maxBits - lengthList[i];
				array[i] = new HuffmanListNode
				{
					Value = values[i],
					Length = lengthList[i],
					Bits = codeList[i] << num,
					Mask = (1 << lengthList[i]) - 1 << num
				};
			}
			Array.Sort(array, (HuffmanListNode huffmanListNode, HuffmanListNode huffmanListNode2) => huffmanListNode.Length - huffmanListNode2.Length);
			for (int num2 = 1; num2 < array.Length && array[num2].Length < 99999; num2++)
			{
				array[num2 - 1].Next = array[num2];
			}
			return array[0];
		}
	}
	internal class ID3Frame : FrameBase
	{
		private int _version;

		internal int Version
		{
			get
			{
				if (_version == 0)
				{
					return 1;
				}
				return _version;
			}
		}

		internal static ID3Frame TrySync(uint syncMark)
		{
			if ((syncMark & 0xFFFFFF00u) == 1229206272)
			{
				return new ID3Frame
				{
					_version = 2
				};
			}
			if ((syncMark & 0xFFFFFF00u) == 1413564160)
			{
				if ((syncMark & 0xFF) == 43)
				{
					return new ID3Frame
					{
						_version = 1
					};
				}
				return new ID3Frame
				{
					_version = 0
				};
			}
			return null;
		}

		private ID3Frame()
		{
		}

		protected override int Validate()
		{
			switch (_version)
			{
			case 2:
			{
				byte[] array = new byte[7];
				if (Read(3, array) == 7)
				{
					byte b;
					switch (array[0])
					{
					case 2:
						b = 63;
						break;
					case 3:
						b = 31;
						break;
					case 4:
						b = 15;
						break;
					default:
						return -1;
					}
					int num = (array[3] << 21) | (array[4] << 14) | (array[5] << 7) | array[6];
					if (((array[2] & b) | (array[3] & 0x80) | (array[4] & 0x80) | (array[5] & 0x80) | (array[6] & 0x80)) == 0 && array[1] != byte.MaxValue)
					{
						return num + 10;
					}
				}
				break;
			}
			case 1:
				return 355;
			case 0:
				return 128;
			}
			return -1;
		}

		internal override void Parse()
		{
			switch (_version)
			{
			case 2:
				ParseV2();
				break;
			case 1:
				ParseV1Enh();
				break;
			case 0:
				ParseV1(3);
				break;
			}
		}

		private void ParseV1(int offset)
		{
		}

		private void ParseV1Enh()
		{
			ParseV1(230);
		}

		private void ParseV2()
		{
		}

		internal void Merge(ID3Frame newFrame)
		{
		}
	}
	internal abstract class LayerDecoderBase
	{
		protected const int SBLIMIT = 32;

		private const float INV_SQRT_2 = 0.70710677f;

		private static float[] DEWINDOW_TABLE = new float[512]
		{
			0f, -1.5259E-05f, -1.5259E-05f, -1.5259E-05f, -1.5259E-05f, -1.5259E-05f, -1.5259E-05f, -3.0518E-05f, -3.0518E-05f, -3.0518E-05f,
			-3.0518E-05f, -4.5776E-05f, -4.5776E-05f, -6.1035E-05f, -6.1035E-05f, -7.6294E-05f, -7.6294E-05f, -9.1553E-05f, -0.000106812f, -0.000106812f,
			-0.00012207f, -0.000137329f, -0.000152588f, -0.000167847f, -0.000198364f, -0.000213623f, -0.000244141f, -0.000259399f, -0.000289917f, -0.000320435f,
			-0.000366211f, -0.000396729f, -0.000442505f, -0.000473022f, -0.000534058f, -0.000579834f, -0.00062561f, -0.000686646f, -0.000747681f, -0.000808716f,
			-0.00088501f, -0.000961304f, -0.001037598f, -0.001113892f, -0.001205444f, -0.001296997f, -0.00138855f, -0.001480103f, -0.001586914f, -0.001693726f,
			-0.001785278f, -0.001907349f, -0.00201416f, -0.002120972f, -0.002243042f, -0.002349854f, -0.002456665f, -0.002578735f, -0.002685547f, -0.002792358f,
			-0.00289917f, -0.002990723f, -0.003082275f, -0.003173828f, 0.003250122f, 0.003326416f, 0.003387451f, 0.003433228f, 0.003463745f, 0.003479004f,
			0.003479004f, 0.003463745f, 0.003417969f, 0.003372192f, 0.00328064f, 0.003173828f, 0.003051758f, 0.002883911f, 0.002700806f, 0.002487183f,
			0.002227783f, 0.001937866f, 0.001617432f, 0.001266479f, 0.000869751f, 0.000442505f, -3.0518E-05f, -0.000549316f, -0.001098633f, -0.001693726f,
			-0.002334595f, -0.003005981f, -0.003723145f, -0.004486084f, -0.0052948f, -0.006118774f, -0.007003784f, -0.007919312f, -0.008865356f, -0.009841919f,
			-0.010848999f, -0.011886597f, -0.012939453f, -0.014022827f, -0.01512146f, -0.016235352f, -0.017349243f, -0.018463135f, -0.019577026f, -0.020690918f,
			-0.02178955f, -0.022857666f, -0.023910522f, -0.024932861f, -0.025909424f, -0.02684021f, -0.02772522f, -0.028533936f, -0.029281616f, -0.029937744f,
			-0.030532837f, -0.03100586f, -0.03138733f, -0.031661987f, -0.031814575f, -0.031845093f, -0.03173828f, -0.03147888f, 0.031082153f, 0.030517578f,
			0.029785156f, 0.028884888f, 0.027801514f, 0.026535034f, 0.02508545f, 0.023422241f, 0.021575928f, 0.01953125f, 0.01725769f, 0.014801025f,
			0.012115479f, 0.009231567f, 0.006134033f, 0.002822876f, -0.000686646f, -0.004394531f, -0.00831604f, -0.012420654f, -0.016708374f, -0.0211792f,
			-0.025817871f, -0.03060913f, -0.03555298f, -0.040634155f, -0.045837402f, -0.051132202f, -0.056533813f, -0.06199646f, -0.06752014f, -0.07305908f,
			-0.07862854f, -0.08418274f, -0.08970642f, -0.09516907f, -0.10054016f, -0.1058197f, -0.110946655f, -0.11592102f, -0.12069702f, -0.1252594f,
			-0.12956238f, -0.1335907f, -0.13729858f, -0.14067078f, -0.14367676f, -0.1462555f, -0.14842224f, -0.15011597f, -0.15130615f, -0.15196228f,
			-0.15206909f, -0.15159607f, -0.15049744f, -0.1487732f, -0.1463623f, -0.14326477f, -0.13945007f, -0.1348877f, -0.12957764f, -0.12347412f,
			-0.11657715f, -0.1088562f, 0.10031128f, 0.090927124f, 0.08068848f, 0.06959534f, 0.057617188f, 0.044784546f, 0.031082153f, 0.01651001f,
			0.001068115f, -0.015228271f, -0.03237915f, -0.050354004f, -0.06916809f, -0.088775635f, -0.10916138f, -0.13031006f, -0.15220642f, -0.17478943f,
			-0.19805908f, -0.22198486f, -0.24650574f, -0.2715912f, -0.2972107f, -0.32331848f, -0.34986877f, -0.37680054f, -0.40408325f, -0.43165588f,
			-0.45947266f, -0.48747253f, -0.51560974f, -0.54382324f, -0.57203674f, -0.6002197f, -0.6282959f, -0.6562195f, -0.6839142f, -0.71131897f,
			-0.7383728f, -0.7650299f, -0.791214f, -0.816864f, -0.84194946f, -0.8663635f, -0.89009094f, -0.9130554f, -0.9351959f, -0.95648193f,
			-0.9768524f, -0.99624634f, -1.0146179f, -1.0319366f, -1.0481567f, -1.0632172f, -1.0771179f, -1.0897827f, -1.1012115f, -1.1113739f,
			-1.120224f, -1.1277466f, -1.1339264f, -1.1387634f, -1.1422119f, -1.1442871f, 1.144989f, 1.1442871f, 1.1422119f, 1.1387634f,
			1.1339264f, 1.1277466f, 1.120224f, 1.1113739f, 1.1012115f, 1.0897827f, 1.0771179f, 1.0632172f, 1.0481567f, 1.0319366f,
			1.0146179f, 0.99624634f, 0.9768524f, 0.95648193f, 0.9351959f, 0.9130554f, 0.89009094f, 0.8663635f, 0.84194946f, 0.816864f,
			0.791214f, 0.7650299f, 0.7383728f, 0.71131897f, 0.6839142f, 0.6562195f, 0.6282959f, 0.6002197f, 0.57203674f, 0.54382324f,
			0.51560974f, 0.48747253f, 0.45947266f, 0.43165588f, 0.40408325f, 0.37680054f, 0.34986877f, 0.32331848f, 0.2972107f, 0.2715912f,
			0.24650574f, 0.22198486f, 0.19805908f, 0.17478943f, 0.15220642f, 0.13031006f, 0.10916138f, 0.088775635f, 0.06916809f, 0.050354004f,
			0.03237915f, 0.015228271f, -0.001068115f, -0.01651001f, -0.031082153f, -0.044784546f, -0.057617188f, -0.06959534f, -0.08068848f, -0.090927124f,
			0.10031128f, 0.1088562f, 0.11657715f, 0.12347412f, 0.12957764f, 0.1348877f, 0.13945007f, 0.14326477f, 0.1463623f, 0.1487732f,
			0.15049744f, 0.15159607f, 0.15206909f, 0.15196228f, 0.15130615f, 0.15011597f, 0.14842224f, 0.1462555f, 0.14367676f, 0.14067078f,
			0.13729858f, 0.1335907f, 0.12956238f, 0.1252594f, 0.12069702f, 0.11592102f, 0.110946655f, 0.1058197f, 0.10054016f, 0.09516907f,
			0.08970642f, 0.08418274f, 0.07862854f, 0.07305908f, 0.06752014f, 0.06199646f, 0.056533813f, 0.051132202f, 0.045837402f, 0.040634155f,
			0.03555298f, 0.03060913f, 0.025817871f, 0.0211792f, 0.016708374f, 0.012420654f, 0.00831604f, 0.004394531f, 0.000686646f, -0.002822876f,
			-0.006134033f, -0.009231567f, -0.012115479f, -0.014801025f, -0.01725769f, -0.01953125f, -0.021575928f, -0.023422241f, -0.02508545f, -0.026535034f,
			-0.027801514f, -0.028884888f, -0.029785156f, -0.030517578f, 0.031082153f, 0.03147888f, 0.03173828f, 0.031845093f, 0.031814575f, 0.031661987f,
			0.03138733f, 0.03100586f, 0.030532837f, 0.029937744f, 0.029281616f, 0.028533936f, 0.02772522f, 0.02684021f, 0.025909424f, 0.024932861f,
			0.023910522f, 0.022857666f, 0.02178955f, 0.020690918f, 0.019577026f, 0.018463135f, 0.017349243f, 0.016235352f, 0.01512146f, 0.014022827f,
			0.012939453f, 0.011886597f, 0.010848999f, 0.009841919f, 0.008865356f, 0.007919312f, 0.007003784f, 0.006118774f, 0.0052948f, 0.004486084f,
			0.003723145f, 0.003005981f, 0.002334595f, 0.001693726f, 0.001098633f, 0.000549316f, 3.0518E-05f, -0.000442505f, -0.000869751f, -0.001266479f,
			-0.001617432f, -0.001937866f, -0.002227783f, -0.002487183f, -0.002700806f, -0.002883911f, -0.003051758f, -0.003173828f, -0.00328064f, -0.003372192f,
			-0.003417969f, -0.003463745f, -0.003479004f, -0.003479004f, -0.003463745f, -0.003433228f, -0.003387451f, -0.003326416f, 0.003250122f, 0.003173828f,
			0.003082275f, 0.002990723f, 0.00289917f, 0.002792358f, 0.002685547f, 0.002578735f, 0.002456665f, 0.002349854f, 0.002243042f, 0.002120972f,
			0.00201416f, 0.001907349f, 0.001785278f, 0.001693726f, 0.001586914f, 0.001480103f, 0.00138855f, 0.001296997f, 0.001205444f, 0.001113892f,
			0.001037598f, 0.000961304f, 0.00088501f, 0.000808716f, 0.000747681f, 0.000686646f, 0.00062561f, 0.000579834f, 0.000534058f, 0.000473022f,
			0.000442505f, 0.000396729f, 0.000366211f, 0.000320435f, 0.000289917f, 0.000259399f, 0.000244141f, 0.000213623f, 0.000198364f, 0.000167847f,
			0.000152588f, 0.000137329f, 0.00012207f, 0.000106812f, 0.000106812f, 9.1553E-05f, 7.6294E-05f, 7.6294E-05f, 6.1035E-05f, 6.1035E-05f,
			4.5776E-05f, 4.5776E-05f, 3.0518E-05f, 3.0518E-05f, 3.0518E-05f, 3.0518E-05f, 1.5259E-05f, 1.5259E-05f, 1.5259E-05f, 1.5259E-05f,
			1.5259E-05f, 1.5259E-05f
		};

		private static float[] SYNTH_COS64_TABLE = new float[31]
		{
			0.500603f, 0.5024193f, 0.50547093f, 0.5097956f, 0.5154473f, 0.5224986f, 0.5310426f, 0.5411961f, 0.5531039f, 0.56694406f,
			0.582935f, 0.6013449f, 0.6225041f, 0.6468218f, 0.6748083f, 0.70710677f, 0.7445363f, 0.7881546f, 0.8393496f, 0.8999762f,
			0.9725682f, 1.0606776f, 1.1694399f, 1.306563f, 1.4841646f, 1.7224472f, 2.057781f, 2.5629156f, 3.4076085f, 5.1011486f,
			10.190008f
		};

		private List<float[]> _synBuf = new List<float[]>(2);

		private List<int> _bufOffset = new List<int>(2);

		private float[] _eq;

		private float[] ippuv = new float[512];

		private const int SynBufSize = 1024;

		private float[] _synBufFirst = new float[1024];

		private float[] ei32 = new float[16];

		private float[] eo32 = new float[16];

		private float[] oi32 = new float[16];

		private float[] oo32 = new float[16];

		private float[] ei16 = new float[8];

		private float[] eo16 = new float[8];

		private float[] oi16 = new float[8];

		private float[] oo16 = new float[8];

		private float[] ei8 = new float[4];

		private float[] tmp8 = new float[6];

		private float[] oi8 = new float[4];

		private float[] oo8 = new float[4];

		internal StereoMode StereoMode { get; set; }

		internal LayerDecoderBase()
		{
			StereoMode = StereoMode.Both;
		}

		internal abstract int DecodeFrame(IMpegFrame frame, float[] ch0, float[] ch1);

		internal void SetEQ(float[] eq)
		{
			if (eq == null || eq.Length == 32)
			{
				_eq = eq;
			}
		}

		internal virtual void ResetForSeek()
		{
			_synBuf.Clear();
			_bufOffset.Clear();
		}

		protected void InversePolyPhase(int channel, float[] data)
		{
			GetBufAndOffset(channel, out var synBuf, out var k);
			if (_eq != null)
			{
				for (int i = 0; i < 32; i++)
				{
					data[i] *= _eq[i];
				}
			}
			DCT32(data, synBuf, k);
			BuildUVec(ippuv, synBuf, k);
			DewindowOutput(ippuv, data);
		}

		private void GetBufAndOffset(int channel, out float[] synBuf, out int k)
		{
			while (_synBuf.Count <= channel)
			{
				if (_synBuf.Count == 0)
				{
					_synBuf.Add(_synBufFirst);
				}
				else
				{
					_synBuf.Add(new float[1024]);
				}
			}
			while (_bufOffset.Count <= channel)
			{
				_bufOffset.Add(0);
			}
			synBuf = _synBuf[channel];
			k = _bufOffset[channel];
			k = (k - 32) & 0x1FF;
			_bufOffset[channel] = k;
		}

		private void DCT32(float[] _in, float[] _out, int k)
		{
			for (int i = 0; i < 16; i++)
			{
				ei32[i] = _in[i] + _in[31 - i];
				oi32[i] = (_in[i] - _in[31 - i]) * SYNTH_COS64_TABLE[2 * i];
			}
			DCT16(ei32, eo32);
			DCT16(oi32, oo32);
			for (int i = 0; i < 15; i++)
			{
				_out[2 * i + k] = eo32[i];
				_out[2 * i + 1 + k] = oo32[i] + oo32[i + 1];
			}
			_out[30 + k] = eo32[15];
			_out[31 + k] = oo32[15];
		}

		private void DCT16(float[] _in, float[] _out)
		{
			float num = _in[0];
			float num2 = _in[15];
			ei16[0] = num + num2;
			oi16[0] = (num - num2) * SYNTH_COS64_TABLE[1];
			num = _in[1];
			num2 = _in[14];
			ei16[1] = num + num2;
			oi16[1] = (num - num2) * SYNTH_COS64_TABLE[5];
			num = _in[2];
			num2 = _in[13];
			ei16[2] = num + num2;
			oi16[2] = (num - num2) * SYNTH_COS64_TABLE[9];
			num = _in[3];
			num2 = _in[12];
			ei16[3] = num + num2;
			oi16[3] = (num - num2) * SYNTH_COS64_TABLE[13];
			num = _in[4];
			num2 = _in[11];
			ei16[4] = num + num2;
			oi16[4] = (num - num2) * SYNTH_COS64_TABLE[17];
			num = _in[5];
			num2 = _in[10];
			ei16[5] = num + num2;
			oi16[5] = (num - num2) * SYNTH_COS64_TABLE[21];
			num = _in[6];
			num2 = _in[9];
			ei16[6] = num + num2;
			oi16[6] = (num - num2) * SYNTH_COS64_TABLE[25];
			num = _in[7];
			num2 = _in[8];
			ei16[7] = num + num2;
			oi16[7] = (num - num2) * SYNTH_COS64_TABLE[29];
			DCT8(ei16, eo16);
			DCT8(oi16, oo16);
			_out[0] = eo16[0];
			_out[1] = oo16[0] + oo16[1];
			_out[2] = eo16[1];
			_out[3] = oo16[1] + oo16[2];
			_out[4] = eo16[2];
			_out[5] = oo16[2] + oo16[3];
			_out[6] = eo16[3];
			_out[7] = oo16[3] + oo16[4];
			_out[8] = eo16[4];
			_out[9] = oo16[4] + oo16[5];
			_out[10] = eo16[5];
			_out[11] = oo16[5] + oo16[6];
			_out[12] = eo16[6];
			_out[13] = oo16[6] + oo16[7];
			_out[14] = eo16[7];
			_out[15] = oo16[7];
		}

		private void DCT8(float[] _in, float[] _out)
		{
			ei8[0] = _in[0] + _in[7];
			ei8[1] = _in[3] + _in[4];
			ei8[2] = _in[1] + _in[6];
			ei8[3] = _in[2] + _in[5];
			tmp8[0] = ei8[0] + ei8[1];
			tmp8[1] = ei8[2] + ei8[3];
			tmp8[2] = (ei8[0] - ei8[1]) * SYNTH_COS64_TABLE[7];
			tmp8[3] = (ei8[2] - ei8[3]) * SYNTH_COS64_TABLE[23];
			tmp8[4] = (tmp8[2] - tmp8[3]) * 0.70710677f;
			_out[0] = tmp8[0] + tmp8[1];
			_out[2] = tmp8[2] + tmp8[3] + tmp8[4];
			_out[4] = (tmp8[0] - tmp8[1]) * 0.70710677f;
			_out[6] = tmp8[4];
			oi8[0] = (_in[0] - _in[7]) * SYNTH_COS64_TABLE[3];
			oi8[1] = (_in[1] - _in[6]) * SYNTH_COS64_TABLE[11];
			oi8[2] = (_in[2] - _in[5]) * SYNTH_COS64_TABLE[19];
			oi8[3] = (_in[3] - _in[4]) * SYNTH_COS64_TABLE[27];
			tmp8[0] = oi8[0] + oi8[3];
			tmp8[1] = oi8[1] + oi8[2];
			tmp8[2] = (oi8[0] - oi8[3]) * SYNTH_COS64_TABLE[7];
			tmp8[3] = (oi8[1] - oi8[2]) * SYNTH_COS64_TABLE[23];
			tmp8[4] = tmp8[2] + tmp8[3];
			tmp8[5] = (tmp8[2] - tmp8[3]) * 0.70710677f;
			oo8[0] = tmp8[0] + tmp8[1];
			oo8[1] = tmp8[4] + tmp8[5];
			oo8[2] = (tmp8[0] - tmp8[1]) * 0.70710677f;
			oo8[3] = tmp8[5];
			_out[1] = oo8[0] + oo8[1];
			_out[3] = oo8[1] + oo8[2];
			_out[5] = oo8[2] + oo8[3];
			_out[7] = oo8[3];
		}

		private void BuildUVec(float[] u_vec, float[] cur_synbuf, int k)
		{
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 16; j++)
				{
					u_vec[num + j] = cur_synbuf[k + j + 16];
					u_vec[num + j + 17] = 0f - cur_synbuf[k + 31 - j];
				}
				k = (k + 32) & 0x1FF;
				for (int j = 0; j < 16; j++)
				{
					u_vec[num + j + 32] = 0f - cur_synbuf[k + 16 - j];
					u_vec[num + j + 48] = 0f - cur_synbuf[k + j];
				}
				u_vec[num + 16] = 0f;
				k = (k + 32) & 0x1FF;
				num += 64;
			}
		}

		private void DewindowOutput(float[] u_vec, float[] samples)
		{
			for (int i = 0; i < 512; i++)
			{
				u_vec[i] *= DEWINDOW_TABLE[i];
			}
			for (int j = 0; j < 32; j++)
			{
				float num = u_vec[j];
				num += u_vec[j + 32];
				num += u_vec[j + 64];
				num += u_vec[j + 96];
				num += u_vec[j + 128];
				num += u_vec[j + 160];
				num += u_vec[j + 192];
				num += u_vec[j + 224];
				num += u_vec[j + 256];
				num += u_vec[j + 288];
				num += u_vec[j + 320];
				num += u_vec[j + 352];
				num += u_vec[j + 384];
				num += u_vec[j + 416];
				num += u_vec[j + 448];
				num += u_vec[j + 480];
				u_vec[j] = num;
			}
			for (int k = 0; k < 32; k++)
			{
				samples[k] = u_vec[k];
			}
		}
	}
	internal class LayerIDecoder : LayerIIDecoderBase
	{
		private static readonly int[] _rateTable = new int[32];

		private static readonly int[][] _allocLookupTable = new int[1][] { new int[17]
		{
			4, 0, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13, 14, 15, 16
		} };

		internal static bool GetCRC(MpegFrame frame, ref uint crc)
		{
			return LayerIIDecoderBase.GetCRC(frame, _rateTable, _allocLookupTable, readScfsiBits: false, ref crc);
		}

		internal LayerIDecoder()
			: base(_allocLookupTable, 1)
		{
		}

		protected override int[] GetRateTable(IMpegFrame frame)
		{
			return _rateTable;
		}

		protected override void ReadScaleFactorSelection(IMpegFrame frame, int[][] scfsi, int channels)
		{
		}
	}
	internal class LayerIIDecoder : LayerIIDecoderBase
	{
		private static readonly int[][] _rateLookupTable = new int[5][]
		{
			new int[27]
			{
				3, 3, 3, 2, 2, 2, 2, 2, 2, 2,
				2, 1, 1, 1, 1, 1, 1, 1, 1, 1,
				1, 1, 1, 0, 0, 0, 0
			},
			new int[30]
			{
				3, 3, 3, 2, 2, 2, 2, 2, 2, 2,
				2, 1, 1, 1, 1, 1, 1, 1, 1, 1,
				1, 1, 1, 0, 0, 0, 0, 0, 0, 0
			},
			new int[8] { 4, 4, 5, 5, 5, 5, 5, 5 },
			new int[12]
			{
				4, 4, 5, 5, 5, 5, 5, 5, 5, 5,
				5, 5
			},
			new int[30]
			{
				6, 6, 6, 6, 5, 5, 5, 5, 5, 5,
				5, 7, 7, 7, 7, 7, 7, 7, 7, 7,
				7, 7, 7, 7, 7, 7, 7, 7, 7, 7
			}
		};

		private static readonly int[][] _allocLookupTable = new int[8][]
		{
			new int[5] { 2, 0, -5, -7, 16 },
			new int[9] { 3, 0, -5, -7, 3, -10, 4, 5, 16 },
			new int[17]
			{
				4, 0, -5, -7, 3, -10, 4, 5, 6, 7,
				8, 9, 10, 11, 12, 13, 16
			},
			new int[17]
			{
				4, 0, -5, 3, 4, 5, 6, 7, 8, 9,
				10, 11, 12, 13, 14, 15, 16
			},
			new int[17]
			{
				4, 0, -5, -7, -10, 4, 5, 6, 7, 8,
				9, 10, 11, 12, 13, 14, 15
			},
			new int[9] { 3, 0, -5, -7, -10, 4, 5, 6, 9 },
			new int[17]
			{
				4, 0, -5, -7, 3, -10, 4, 5, 6, 7,
				8, 9, 10, 11, 12, 13, 14
			},
			new int[5] { 2, 0, -5, -7, 3 }
		};

		internal static bool GetCRC(MpegFrame frame, ref uint crc)
		{
			return LayerIIDecoderBase.GetCRC(frame, SelectTable(frame), _allocLookupTable, readScfsiBits: true, ref crc);
		}

		private static int[] SelectTable(IMpegFrame frame)
		{
			int num = frame.BitRate / ((frame.ChannelMode == MpegChannelMode.Mono) ? 1 : 2) / 1000;
			if (frame.Version == MpegVersion.Version1)
			{
				if ((num >= 56 && num <= 80) || (frame.SampleRate == 48000 && num >= 56))
				{
					return _rateLookupTable[0];
				}
				if (frame.SampleRate != 48000 && num >= 96)
				{
					return _rateLookupTable[1];
				}
				if (frame.SampleRate != 32000 && num <= 48)
				{
					return _rateLookupTable[2];
				}
				return _rateLookupTable[3];
			}
			return _rateLookupTable[4];
		}

		internal LayerIIDecoder()
			: base(_allocLookupTable, 3)
		{
		}

		protected override int[] GetRateTable(IMpegFrame frame)
		{
			return SelectTable(frame);
		}

		protected override void ReadScaleFactorSelection(IMpegFrame frame, int[][] scfsi, int channels)
		{
			for (int i = 0; i < 30; i++)
			{
				for (int j = 0; j < channels; j++)
				{
					if (scfsi[j][i] == 2)
					{
						scfsi[j][i] = frame.ReadBits(2);
					}
				}
			}
		}
	}
	internal abstract class LayerIIDecoderBase : LayerDecoderBase
	{
		protected const int SSLIMIT = 12;

		private static readonly float[] _groupedC = new float[5] { 0f, 0f, 1.3333334f, 1.6f, 1.7777778f };

		private static readonly float[] _groupedD = new float[5] { 0f, 0f, -0.5f, -0.5f, -0.5f };

		private static readonly float[] _C = new float[17]
		{
			0f, 0f, 1.3333334f, 1.1428572f, 1.0666667f, 1.032258f, 1.0158731f, 1.007874f, 1.0039216f, 1.0019569f,
			1.0009775f, 1.0004885f, 1.0002443f, 1.0001221f, 1.000061f, 1.0000305f, 1.0000153f
		};

		private static readonly float[] _D = new float[17]
		{
			0f,
			0f,
			-0.5f,
			-0.75f,
			-0.875f,
			-0.9375f,
			-31f / 32f,
			-63f / 64f,
			-127f / 128f,
			-0.99609375f,
			-0.9980469f,
			-0.99902344f,
			-0.9995117f,
			-0.99975586f,
			-0.9998779f,
			-0.99993896f,
			-0.9999695f
		};

		private static readonly float[] _denormalMultiplier = new float[64]
		{
			2f,
			1.587401f,
			1.2599211f,
			1f,
			0.7937005f,
			0.62996054f,
			0.5f,
			0.39685026f,
			0.31498027f,
			0.25f,
			0.19842513f,
			0.15749013f,
			0.125f,
			0.099212565f,
			0.07874507f,
			0.0625f,
			0.049606282f,
			0.039372534f,
			1f / 32f,
			0.024803141f,
			0.019686267f,
			1f / 64f,
			0.012401571f,
			0.009843133f,
			1f / 128f,
			0.0062007853f,
			0.0049215667f,
			0.00390625f,
			0.0031003926f,
			0.0024607833f,
			0.001953125f,
			0.0015501963f,
			0.0012303917f,
			0.0009765625f,
			0.00077509816f,
			0.00061519584f,
			0.00048828125f,
			0.00038754908f,
			0.00030759792f,
			0.00024414062f,
			0.00019377454f,
			0.00015379896f,
			0.00012207031f,
			9.688727E-05f,
			7.689948E-05f,
			6.1035156E-05f,
			4.8443635E-05f,
			3.844974E-05f,
			3.0517578E-05f,
			2.4221818E-05f,
			1.922487E-05f,
			1.5258789E-05f,
			1.2110909E-05f,
			9.612435E-06f,
			7.6293945E-06f,
			6.0554544E-06f,
			4.8062175E-06f,
			3.8146973E-06f,
			3.0277272E-06f,
			2.4031087E-06f,
			1.9073486E-06f,
			1.5138636E-06f,
			1.2015544E-06f,
			9.536743E-07f
		};

		private int _channels;

		private int _jsbound;

		private int _granuleCount;

		private int[][] _allocLookupTable;

		private int[][] _scfsi;

		private int[][] _samples;

		private int[][][] _scalefac;

		private float[] _polyPhaseBuf;

		private int[][] _allocation;

		protected static bool GetCRC(MpegFrame frame, int[] rateTable, int[][] allocLookupTable, bool readScfsiBits, ref uint crc)
		{
			int num = 0;
			int num2 = rateTable.Length;
			int num3 = num2;
			if (frame.ChannelMode == MpegChannelMode.JointStereo)
			{
				num3 = frame.ChannelModeExtension * 4 + 4;
			}
			int num4 = ((frame.ChannelMode == MpegChannelMode.Mono) ? 1 : 2);
			int i;
			for (i = 0; i < num3; i++)
			{
				int num5 = allocLookupTable[rateTable[i]][0];
				for (int j = 0; j < num4; j++)
				{
					int num6 = frame.ReadBits(num5);
					if (num6 > 0)
					{
						num += 2;
					}
					MpegFrame.UpdateCRC(num6, num5, ref crc);
				}
			}
			for (; i < num2; i++)
			{
				int num7 = allocLookupTable[rateTable[i]][0];
				int num8 = frame.ReadBits(num7);
				if (num8 > 0)
				{
					num += num4 * 2;
				}
				MpegFrame.UpdateCRC(num8, num7, ref crc);
			}
			if (readScfsiBits)
			{
				while (num >= 2)
				{
					MpegFrame.UpdateCRC(frame.ReadBits(2), 2, ref crc);
					num -= 2;
				}
			}
			return true;
		}

		protected LayerIIDecoderBase(int[][] allocLookupTable, int granuleCount)
		{
			_allocLookupTable = allocLookupTable;
			_granuleCount = granuleCount;
			_allocation = new int[2][]
			{
				new int[32],
				new int[32]
			};
			_scfsi = new int[2][]
			{
				new int[32],
				new int[32]
			};
			_samples = new int[2][]
			{
				new int[384 * _granuleCount],
				new int[384 * _granuleCount]
			};
			_scalefac = new int[2][][]
			{
				new int[3][],
				new int[3][]
			};
			for (int i = 0; i < 3; i++)
			{
				_scalefac[0][i] = new int[32];
				_scalefac[1][i] = new int[32];
			}
			_polyPhaseBuf = new float[32];
		}

		internal override int DecodeFrame(IMpegFrame frame, float[] ch0, float[] ch1)
		{
			InitFrame(frame);
			int[] rateTable = GetRateTable(frame);
			ReadAllocation(frame, rateTable);
			for (int i = 0; i < _scfsi[0].Length; i++)
			{
				_scfsi[0][i] = ((_allocation[0][i] != 0) ? 2 : (-1));
				_scfsi[1][i] = ((_allocation[1][i] != 0) ? 2 : (-1));
			}
			ReadScaleFactorSelection(frame, _scfsi, _channels);
			ReadScaleFactors(frame);
			ReadSamples(frame);
			return DecodeSamples(ch0, ch1);
		}

		private void InitFrame(IMpegFrame frame)
		{
			switch (frame.ChannelMode)
			{
			case MpegChannelMode.Mono:
				_channels = 1;
				_jsbound = 32;
				break;
			case MpegChannelMode.JointStereo:
				_channels = 2;
				_jsbound = frame.ChannelModeExtension * 4 + 4;
				break;
			default:
				_channels = 2;
				_jsbound = 32;
				break;
			}
		}

		protected abstract int[] GetRateTable(IMpegFrame frame);

		private void ReadAllocation(IMpegFrame frame, int[] rateTable)
		{
			int num = rateTable.Length;
			if (_jsbound > num)
			{
				_jsbound = num;
			}
			Array.Clear(_allocation[0], 0, 32);
			Array.Clear(_allocation[1], 0, 32);
			int i;
			for (i = 0; i < _jsbound; i++)
			{
				int[] array = _allocLookupTable[rateTable[i]];
				int bitCount = array[0];
				for (int j = 0; j < _channels; j++)
				{
					_allocation[j][i] = array[frame.ReadBits(bitCount) + 1];
				}
			}
			for (; i < num; i++)
			{
				int[] array2 = _allocLookupTable[rateTable[i]];
				_allocation[0][i] = (_allocation[1][i] = array2[frame.ReadBits(array2[0]) + 1]);
			}
		}

		protected abstract void ReadScaleFactorSelection(IMpegFrame frame, int[][] scfsi, int channels);

		private void ReadScaleFactors(IMpegFrame frame)
		{
			for (int i = 0; i < 32; i++)
			{
				for (int j = 0; j < _channels; j++)
				{
					switch (_scfsi[j][i])
					{
					case 0:
						_scalefac[j][0][i] = frame.ReadBits(6);
						_scalefac[j][1][i] = frame.ReadBits(6);
						_scalefac[j][2][i] = frame.ReadBits(6);
						break;
					case 1:
						_scalefac[j][0][i] = (_scalefac[j][1][i] = frame.ReadBits(6));
						_scalefac[j][2][i] = frame.ReadBits(6);
						break;
					case 2:
						_scalefac[j][0][i] = (_scalefac[j][1][i] = (_scalefac[j][2][i] = frame.ReadBits(6)));
						break;
					case 3:
						_scalefac[j][0][i] = frame.ReadBits(6);
						_scalefac[j][1][i] = (_scalefac[j][2][i] = frame.ReadBits(6));
						break;
					default:
						_scalefac[j][0][i] = 63;
						_scalefac[j][1][i] = 63;
						_scalefac[j][2][i] = 63;
						break;
					}
				}
			}
		}

		private void ReadSamples(IMpegFrame frame)
		{
			int num = 0;
			int num2 = 0;
			while (num < 12)
			{
				int num3 = 0;
				while (num3 < 32)
				{
					for (int i = 0; i < _channels; i++)
					{
						if (i == 0 || num3 < _jsbound)
						{
							int num4 = _allocation[i][num3];
							if (num4 != 0)
							{
								if (num4 < 0)
								{
									int num5 = frame.ReadBits(-num4);
									int num6 = (1 << -num4 / 2 + -num4 % 2 - 1) + 1;
									_samples[i][num2] = num5 % num6;
									num5 /= num6;
									_samples[i][num2 + 32] = num5 % num6;
									_samples[i][num2 + 64] = num5 / num6;
								}
								else
								{
									for (int j = 0; j < _granuleCount; j++)
									{
										_samples[i][num2 + 32 * j] = frame.ReadBits(num4);
									}
								}
							}
							else
							{
								for (int k = 0; k < _granuleCount; k++)
								{
									_samples[i][num2 + 32 * k] = 0;
								}
							}
						}
						else
						{
							for (int l = 0; l < _granuleCount; l++)
							{
								_samples[1][num2 + 32 * l] = _samples[0][num2 + 32 * l];
							}
						}
					}
					num3++;
					num2++;
				}
				num++;
				num2 += 32 * (_granuleCount - 1);
			}
		}

		private int DecodeSamples(float[] ch0, float[] ch1)
		{
			float[][] array = new float[2][];
			int num = 0;
			int num2 = _channels - 1;
			if (_channels == 1 || base.StereoMode == StereoMode.LeftOnly)
			{
				array[0] = ch0;
				num2 = 0;
			}
			else if (base.StereoMode == StereoMode.RightOnly)
			{
				array[1] = ch0;
				num = 1;
			}
			else
			{
				array[0] = ch0;
				array[1] = ch1;
			}
			int num3 = 0;
			for (int i = num; i <= num2; i++)
			{
				num3 = 0;
				for (int j = 0; j < _granuleCount; j++)
				{
					for (int k = 0; k < 12; k++)
					{
						int num4 = 0;
						while (num4 < 32)
						{
							int num5 = _allocation[i][num4];
							if (num5 != 0)
							{
								float[] array2;
								float[] array3;
								if (num5 < 0)
								{
									num5 = -num5 / 2 + -num5 % 2 - 1;
									array2 = _groupedC;
									array3 = _groupedD;
								}
								else
								{
									array2 = _C;
									array3 = _D;
								}
								_polyPhaseBuf[num4] = array2[num5] * ((float)(_samples[i][num3] << 16 - num5) / 32768f + array3[num5]) * _denormalMultiplier[_scalefac[i][j][num4]];
							}
							else
							{
								_polyPhaseBuf[num4] = 0f;
							}
							num4++;
							num3++;
						}
						InversePolyPhase(i, _polyPhaseBuf);
						Array.Copy(_polyPhaseBuf, 0, array[i], num3 - 32, 32);
					}
				}
			}
			if (_channels == 2 && base.StereoMode == StereoMode.DownmixToMono)
			{
				for (int l = 0; l < num3; l++)
				{
					ch0[l] = (ch0[l] + ch1[l]) / 2f;
				}
			}
			return num3;
		}
	}
	internal sealed class LayerIIIDecoder : LayerDecoderBase
	{
		private class HybridMDCT
		{
			private const float PI = MathF.PI;

			private static float[][] _swin;

			private static float[] icos72_table;

			private List<float[]> _prevBlock;

			private List<float[]> _nextBlock;

			private float[] _prevBlockFirst = new float[576];

			private float[] _nextBlockFirst = new float[576];

			private float[] _imdctTemp = new float[18];

			private float[] _imdctResult = new float[36];

			private readonly float[] _imdct_H = new float[17];

			private readonly float[] _imdct_h = new float[18];

			private readonly float[] _imdct_even = new float[9];

			private readonly float[] _imdct_odd = new float[9];

			private readonly float[] _imdct_even_idct = new float[9];

			private readonly float[] _imdct_odd_idct = new float[9];

			private readonly float[] _imdct_9pt_even_idct = new float[5];

			private readonly float[] _imdct_9pt_odd_idct = new float[4];

			private const float sqrt32 = 0.8660254f;

			private readonly float[] _ShortIMDCT_H = new float[6];

			private readonly float[] _ShortIMDCT_h = new float[6];

			private readonly float[] _ShortIMDCT_even_idct = new float[3];

			private readonly float[] _ShortIMDCT_odd_idct = new float[3];

			static HybridMDCT()
			{
				icos72_table = new float[35]
				{
					0.50047636f, 0.5019099f, 0.5043145f, 0.5077133f, 0.51213974f, 0.5176381f, 0.5242646f, 0.5320889f, 0.5411961f, 0.55168897f,
					0.56369096f, 0.57735026f, 0.59284455f, 0.61038727f, 0.6302362f, 0.65270364f, 0.67817086f, 0.70710677f, 0.7400936f, 0.7778619f,
					0.8213398f, 0.8717234f, 0.9305795f, 1f, 1.0828403f, 1.1831008f, 1.306563f, 1.4619021f, 1.6627548f, 1.9318516f,
					2.3101132f, 2.8793852f, 3.830649f, 5.7368565f, 11.462792f
				};
				_swin = new float[4][]
				{
					new float[36],
					new float[36],
					new float[36],
					new float[36]
				};
				for (int i = 0; i < 36; i++)
				{
					_swin[0][i] = (float)Math.Sin(0.0872664675116539 * ((double)i + 0.5));
				}
				for (int i = 0; i < 18; i++)
				{
					_swin[1][i] = (float)Math.Sin(0.0872664675116539 * ((double)i + 0.5));
				}
				for (int i = 18; i < 24; i++)
				{
					_swin[1][i] = 1f;
				}
				for (int i = 24; i < 30; i++)
				{
					_swin[1][i] = (float)Math.Sin(0.2617993950843811 * ((double)i + 0.5 - 18.0));
				}
				for (int i = 30; i < 36; i++)
				{
					_swin[1][i] = 0f;
				}
				for (int i = 0; i < 6; i++)
				{
					_swin[3][i] = 0f;
				}
				for (int i = 6; i < 12; i++)
				{
					_swin[3][i] = (float)Math.Sin(0.2617993950843811 * ((double)i + 0.5 - 6.0));
				}
				for (int i = 12; i < 18; i++)
				{
					_swin[3][i] = 1f;
				}
				for (int i = 18; i < 36; i++)
				{
					_swin[3][i] = (float)Math.Sin(0.0872664675116539 * ((double)i + 0.5));
				}
				for (int i = 0; i < 12; i++)
				{
					_swin[2][i] = (float)Math.Sin(0.2617993950843811 * ((double)i + 0.5));
				}
				for (int i = 12; i < 36; i++)
				{
					_swin[2][i] = 0f;
				}
			}

			internal HybridMDCT()
			{
				_prevBlock = new List<float[]>();
				_nextBlock = new List<float[]>();
			}

			internal void Reset()
			{
				_prevBlock.Clear();
				_nextBlock.Clear();
			}

			private void GetPrevBlock(int channel, out float[] prevBlock, out float[] nextBlock)
			{
				while (_prevBlock.Count <= channel)
				{
					if (_prevBlock.Count == 0)
					{
						_prevBlock.Add(_prevBlockFirst);
					}
					else
					{
						_prevBlock.Add(new float[576]);
					}
				}
				while (_nextBlock.Count <= channel)
				{
					if (_nextBlock.Count == 0)
					{
						_nextBlock.Add(_nextBlockFirst);
					}
					else
					{
						_nextBlock.Add(new float[576]);
					}
				}
				prevBlock = _prevBlock[channel];
				nextBlock = _nextBlock[channel];
				_nextBlock[channel] = prevBlock;
				_prevBlock[channel] = nextBlock;
			}

			internal void Apply(float[] fsIn, int channel, int blockType, bool doMixed)
			{
				GetPrevBlock(channel, out var prevBlock, out var nextBlock);
				int sbStart = 0;
				if (doMixed)
				{
					LongImpl(fsIn, 0, 2, nextBlock, 0);
					sbStart = 2;
				}
				if (blockType == 2)
				{
					ShortImpl(fsIn, sbStart, nextBlock);
				}
				else
				{
					LongImpl(fsIn, sbStart, 32, nextBlock, blockType);
				}
				for (int i = 0; i < 576; i++)
				{
					fsIn[i] += prevBlock[i];
				}
			}

			private void LongImpl(float[] fsIn, int sbStart, int sbLimit, float[] nextblck, int blockType)
			{
				int i = sbStart;
				int num = sbStart * 18;
				for (; i < sbLimit; i++)
				{
					Array.Copy(fsIn, num, _imdctTemp, 0, 18);
					LongIMDCT(_imdctTemp, _imdctResult);
					float[] array = _swin[blockType];
					int j;
					for (j = 0; j < 18; j++)
					{
						fsIn[num++] = _imdctResult[j] * array[j];
					}
					num -= 18;
					for (; j < 36; j++)
					{
						nextblck[num++] = _imdctResult[j] * array[j];
					}
				}
			}

			private void LongIMDCT(float[] invec, float[] outvec)
			{
				float[] imdct_H = _imdct_H;
				float[] imdct_h = _imdct_h;
				float[] imdct_even = _imdct_even;
				float[] imdct_odd = _imdct_odd;
				float[] imdct_even_idct = _imdct_even_idct;
				float[] imdct_odd_idct = _imdct_odd_idct;
				int i;
				for (i = 0; i < 17; i++)
				{
					imdct_H[i] = invec[i] + invec[i + 1];
				}
				imdct_even[0] = invec[0];
				imdct_odd[0] = imdct_H[0];
				int num = 0;
				i = 1;
				while (i < 9)
				{
					imdct_even[i] = imdct_H[num + 1];
					imdct_odd[i] = imdct_H[num] + imdct_H[num + 2];
					i++;
					num += 2;
				}
				imdct_9pt(imdct_even, imdct_even_idct);
				imdct_9pt(imdct_odd, imdct_odd_idct);
				for (i = 0; i < 9; i++)
				{
					imdct_odd_idct[i] *= ICOS36_A(i);
					imdct_h[i] = (imdct_even_idct[i] + imdct_odd_idct[i]) * ICOS72_A(i);
				}
				for (; i < 18; i++)
				{
					imdct_h[i] = (imdct_even_idct[17 - i] - imdct_odd_idct[17 - i]) * ICOS72_A(i);
				}
				outvec[0] = imdct_h[9];
				outvec[1] = imdct_h[10];
				outvec[2] = imdct_h[11];
				outvec[3] = imdct_h[12];
				outvec[4] = imdct_h[13];
				outvec[5] = imdct_h[14];
				outvec[6] = imdct_h[15];
				outvec[7] = imdct_h[16];
				outvec[8] = imdct_h[17];
				outvec[9] = 0f - imdct_h[17];
				outvec[10] = 0f - imdct_h[16];
				outvec[11] = 0f - imdct_h[15];
				outvec[12] = 0f - imdct_h[14];
				outvec[13] = 0f - imdct_h[13];
				outvec[14] = 0f - imdct_h[12];
				outvec[15] = 0f - imdct_h[11];
				outvec[16] = 0f - imdct_h[10];
				outvec[17] = 0f - imdct_h[9];
				outvec[35] = (outvec[18] = 0f - imdct_h[8]);
				outvec[34] = (outvec[19] = 0f - imdct_h[7]);
				outvec[33] = (outvec[20] = 0f - imdct_h[6]);
				outvec[32] = (outvec[21] = 0f - imdct_h[5]);
				outvec[31] = (outvec[22] = 0f - imdct_h[4]);
				outvec[30] = (outvec[23] = 0f - imdct_h[3]);
				outvec[29] = (outvec[24] = 0f - imdct_h[2]);
				outvec[28] = (outvec[25] = 0f - imdct_h[1]);
				outvec[27] = (outvec[26] = 0f - imdct_h[0]);
			}

			private static float ICOS72_A(int i)
			{
				return icos72_table[2 * i];
			}

			private static float ICOS36_A(int i)
			{
				return icos72_table[4 * i + 1];
			}

			private void imdct_9pt(float[] invec, float[] outvec)
			{
				float[] imdct_9pt_even_idct = _imdct_9pt_even_idct;
				float[] imdct_9pt_odd_idct = _imdct_9pt_odd_idct;
				float num = invec[6] / 2f + invec[0];
				float num2 = invec[0] - invec[6];
				float num3 = invec[2] - invec[4] - invec[8];
				imdct_9pt_even_idct[0] = num + invec[2] * 0.9396926f + invec[4] * 0.76604444f + invec[8] * 0.17364818f;
				imdct_9pt_even_idct[1] = num3 / 2f + num2;
				imdct_9pt_even_idct[2] = num - invec[2] * 0.17364818f - invec[4] * 0.9396926f + invec[8] * 0.76604444f;
				imdct_9pt_even_idct[3] = num - invec[2] * 0.76604444f + invec[4] * 0.17364818f - invec[8] * 0.9396926f;
				imdct_9pt_even_idct[4] = num2 - num3;
				float num4 = invec[1] + invec[3];
				float num5 = invec[3] + invec[5];
				num = (invec[5] + invec[7]) * 0.5f + invec[1];
				imdct_9pt_odd_idct[0] = num + num4 * 0.9396926f + num5 * 0.76604444f;
				imdct_9pt_odd_idct[1] = (invec[1] - invec[5]) * 1.5f - invec[7];
				imdct_9pt_odd_idct[2] = num - num4 * 0.17364818f - num5 * 0.9396926f;
				imdct_9pt_odd_idct[3] = num - num4 * 0.76604444f + num5 * 0.17364818f;
				imdct_9pt_odd_idct[0] += invec[7] * 0.17364818f;
				imdct_9pt_odd_idct[1] -= invec[7] * 0.5f;
				imdct_9pt_odd_idct[2] += invec[7] * 0.76604444f;
				imdct_9pt_odd_idct[3] -= invec[7] * 0.9396926f;
				imdct_9pt_odd_idct[0] *= 0.5077133f;
				imdct_9pt_odd_idct[1] *= 0.57735026f;
				imdct_9pt_odd_idct[2] *= 0.7778619f;
				imdct_9pt_odd_idct[3] *= 1.4619021f;
				for (int i = 0; i < 4; i++)
				{
					outvec[i] = imdct_9pt_even_idct[i] + imdct_9pt_odd_idct[i];
				}
				outvec[4] = imdct_9pt_even_idct[4];
				for (int i = 5; i < 9; i++)
				{
					outvec[i] = imdct_9pt_even_idct[8 - i] - imdct_9pt_odd_idct[8 - i];
				}
			}

			private void ShortImpl(float[] fsIn, int sbStart, float[] nextblck)
			{
				_ = _swin[2];
				int num = sbStart;
				int num2 = sbStart * 18;
				while (num < 32)
				{
					int i = 0;
					int num3 = 0;
					for (; i < 3; i++)
					{
						int num4 = num2 + i;
						for (int j = 0; j < 6; j++)
						{
							_imdctTemp[num3 + j] = fsIn[num4];
							num4 += 3;
						}
						num3 += 6;
					}
					Array.Clear(fsIn, num2, 6);
					ShortIMDCT(_imdctTemp, 0, _imdctResult);
					Array.Copy(_imdctResult, 0, fsIn, num2 + 6, 12);
					ShortIMDCT(_imdctTemp, 6, _imdctResult);
					for (int k = 0; k < 6; k++)
					{
						fsIn[num2 + k + 12] += _imdctResult[k];
					}
					Array.Copy(_imdctResult, 6, nextblck, num2, 6);
					ShortIMDCT(_imdctTemp, 12, _imdctResult);
					for (int l = 0; l < 6; l++)
					{
						nextblck[num2 + l] += _imdctResult[l];
					}
					Array.Copy(_imdctResult, 6, nextblck, num2 + 6, 6);
					Array.Clear(nextblck, num2 + 12, 6);
					num++;
					num2 += 18;
				}
			}

			private void ShortIMDCT(float[] invec, int inIdx, float[] outvec)
			{
				float[] shortIMDCT_H = _ShortIMDCT_H;
				float[] shortIMDCT_h = _ShortIMDCT_h;
				float[] shortIMDCT_even_idct = _ShortIMDCT_even_idct;
				float[] shortIMDCT_odd_idct = _ShortIMDCT_odd_idct;
				int num = inIdx;
				for (int i = 1; i < 6; i++)
				{
					shortIMDCT_H[i] = invec[num];
					shortIMDCT_H[i] += invec[++num];
				}
				float num2 = shortIMDCT_H[4] / 2f + invec[inIdx];
				float num3 = shortIMDCT_H[2] * 0.8660254f;
				shortIMDCT_even_idct[0] = num2 + num3;
				shortIMDCT_even_idct[1] = invec[inIdx] - shortIMDCT_H[4];
				shortIMDCT_even_idct[2] = num2 - num3;
				float num4 = shortIMDCT_H[3] + shortIMDCT_H[5];
				num2 = num4 / 2f + shortIMDCT_H[1];
				num3 = (shortIMDCT_H[1] + shortIMDCT_H[3]) * 0.8660254f;
				shortIMDCT_odd_idct[0] = num2 + num3;
				shortIMDCT_odd_idct[1] = shortIMDCT_H[1] - num4;
				shortIMDCT_odd_idct[2] = num2 - num3;
				shortIMDCT_odd_idct[0] *= 0.5176381f;
				shortIMDCT_odd_idct[1] *= 0.70710677f;
				shortIMDCT_odd_idct[2] *= 1.9318516f;
				shortIMDCT_h[0] = (shortIMDCT_even_idct[0] + shortIMDCT_odd_idct[0]) * 0.5043145f;
				shortIMDCT_h[1] = (shortIMDCT_even_idct[1] + shortIMDCT_odd_idct[1]) * 0.5411961f;
				shortIMDCT_h[2] = (shortIMDCT_even_idct[2] + shortIMDCT_odd_idct[2]) * 0.6302362f;
				shortIMDCT_h[3] = (shortIMDCT_even_idct[2] - shortIMDCT_odd_idct[2]) * 0.82133985f;
				shortIMDCT_h[4] = (shortIMDCT_even_idct[1] - shortIMDCT_odd_idct[1]) * 1.306563f;
				shortIMDCT_h[5] = (shortIMDCT_even_idct[0] - shortIMDCT_odd_idct[0]) * 3.830649f;
				outvec[0] = shortIMDCT_h[3] * _swin[2][0];
				outvec[1] = shortIMDCT_h[4] * _swin[2][1];
				outvec[2] = shortIMDCT_h[5] * _swin[2][2];
				outvec[3] = (0f - shortIMDCT_h[5]) * _swin[2][3];
				outvec[4] = (0f - shortIMDCT_h[4]) * _swin[2][4];
				outvec[5] = (0f - shortIMDCT_h[3]) * _swin[2][5];
				outvec[6] = (0f - shortIMDCT_h[2]) * _swin[2][6];
				outvec[7] = (0f - shortIMDCT_h[1]) * _swin[2][7];
				outvec[8] = (0f - shortIMDCT_h[0]) * _swin[2][8];
				outvec[9] = (0f - shortIMDCT_h[0]) * _swin[2][9];
				outvec[10] = (0f - shortIMDCT_h[1]) * _swin[2][10];
				outvec[11] = (0f - shortIMDCT_h[2]) * _swin[2][11];
			}
		}

		private const int SSLIMIT = 18;

		private readonly float[][] _chanBufs = new float[2][];

		private readonly int[] _readLsfScalefactorsSlen = new int[4];

		private readonly int[] _readLsfScalefactorsBuffer = new int[54];

		private readonly HybridMDCT _hybrid = new HybridMDCT();

		private BitReservoir _bitRes = new BitReservoir();

		private int _channels;

		private int _privBits;

		private int _mainDataBegin;

		private int[][] _scfsi = new int[2][]
		{
			new int[4],
			new int[4]
		};

		private int[][] _part23Length = new int[2][]
		{
			new int[2],
			new int[2]
		};

		private int[][] _bigValues = new int[2][]
		{
			new int[2],
			new int[2]
		};

		private float[][] _globalGain = new float[2][]
		{
			new float[2],
			new float[2]
		};

		private int[][] _scalefacCompress = new int[2][]
		{
			new int[2],
			new int[2]
		};

		private bool[][] _blockSplitFlag = new bool[2][]
		{
			new bool[2],
			new bool[2]
		};

		private bool[][] _mixedBlockFlag = new bool[2][]
		{
			new bool[2],
			new bool[2]
		};

		private int[][] _blockType = new int[2][]
		{
			new int[2],
			new int[2]
		};

		private int[][][] _tableSelect;

		private float[][][] _subblockGain;

		private int[][] _regionAddress1 = new int[2][]
		{
			new int[2],
			new int[2]
		};

		private int[][] _regionAddress2 = new int[2][]
		{
			new int[2],
			new int[2]
		};

		private int[][] _preflag = new int[2][]
		{
			new int[2],
			new int[2]
		};

		private float[][] _scalefacScale = new float[2][]
		{
			new float[2],
			new float[2]
		};

		private int[][] _count1TableSelect = new int[2][]
		{
			new int[2],
			new int[2]
		};

		private static float[] GAIN_TAB = new float[256]
		{
			1.5700924E-16f,
			1.8671652E-16f,
			2.220446E-16f,
			2.6405702E-16f,
			3.1401849E-16f,
			3.7343303E-16f,
			4.440892E-16f,
			5.2811403E-16f,
			6.2803697E-16f,
			7.4686606E-16f,
			8.881784E-16f,
			1.0562281E-15f,
			1.2560739E-15f,
			1.4937321E-15f,
			1.7763568E-15f,
			2.1124561E-15f,
			2.5121479E-15f,
			2.9874642E-15f,
			3.5527137E-15f,
			4.2249122E-15f,
			5.0242958E-15f,
			5.9749285E-15f,
			7.1054274E-15f,
			8.4498245E-15f,
			1.00485916E-14f,
			1.1949857E-14f,
			1.4210855E-14f,
			1.6899649E-14f,
			2.0097183E-14f,
			2.3899714E-14f,
			2.842171E-14f,
			3.3799298E-14f,
			4.0194366E-14f,
			4.7799428E-14f,
			5.684342E-14f,
			6.7598596E-14f,
			8.038873E-14f,
			9.5598856E-14f,
			1.1368684E-13f,
			1.3519719E-13f,
			1.6077747E-13f,
			1.9119771E-13f,
			2.2737368E-13f,
			2.7039438E-13f,
			3.2155493E-13f,
			3.8239542E-13f,
			4.5474735E-13f,
			5.4078877E-13f,
			6.4310986E-13f,
			7.6479085E-13f,
			9.094947E-13f,
			1.0815775E-12f,
			1.2862197E-12f,
			1.5295817E-12f,
			1.8189894E-12f,
			2.163155E-12f,
			2.5724394E-12f,
			3.0591634E-12f,
			3.637979E-12f,
			4.32631E-12f,
			5.144879E-12f,
			6.1183268E-12f,
			7.275958E-12f,
			8.65262E-12f,
			1.0289758E-11f,
			1.22366535E-11f,
			1.4551915E-11f,
			1.730524E-11f,
			2.0579516E-11f,
			2.4473307E-11f,
			2.910383E-11f,
			3.461048E-11f,
			4.115903E-11f,
			4.8946614E-11f,
			5.820766E-11f,
			6.922096E-11f,
			8.231806E-11f,
			9.789323E-11f,
			1.1641532E-10f,
			1.3844192E-10f,
			1.6463612E-10f,
			1.9578646E-10f,
			2.3283064E-10f,
			2.7688385E-10f,
			3.2927225E-10f,
			3.915729E-10f,
			4.656613E-10f,
			5.537677E-10f,
			6.585445E-10f,
			7.831458E-10f,
			9.313226E-10f,
			1.1075354E-09f,
			1.317089E-09f,
			1.5662917E-09f,
			1.8626451E-09f,
			2.2150708E-09f,
			2.634178E-09f,
			3.1325833E-09f,
			3.7252903E-09f,
			4.4301416E-09f,
			5.268356E-09f,
			6.2651666E-09f,
			7.450581E-09f,
			8.860283E-09f,
			1.0536712E-08f,
			1.2530333E-08f,
			1.4901161E-08f,
			1.7720566E-08f,
			2.1073424E-08f,
			2.5060666E-08f,
			2.9802322E-08f,
			3.5441133E-08f,
			4.2146848E-08f,
			5.0121333E-08f,
			5.9604645E-08f,
			7.0882265E-08f,
			8.4293696E-08f,
			1.00242666E-07f,
			1.1920929E-07f,
			1.4176453E-07f,
			1.6858739E-07f,
			2.0048533E-07f,
			2.3841858E-07f,
			2.8352906E-07f,
			3.3717478E-07f,
			4.0097066E-07f,
			4.7683716E-07f,
			5.670581E-07f,
			6.7434956E-07f,
			8.019413E-07f,
			9.536743E-07f,
			1.1341162E-06f,
			1.3486991E-06f,
			1.6038827E-06f,
			1.9073486E-06f,
			2.2682325E-06f,
			2.6973983E-06f,
			3.2077653E-06f,
			3.8146973E-06f,
			4.536465E-06f,
			5.3947965E-06f,
			6.4155306E-06f,
			7.6293945E-06f,
			9.07293E-06f,
			1.0789593E-05f,
			1.2831061E-05f,
			1.5258789E-05f,
			1.814586E-05f,
			2.1579186E-05f,
			2.5662122E-05f,
			3.0517578E-05f,
			3.629172E-05f,
			4.3158372E-05f,
			5.1324245E-05f,
			6.1035156E-05f,
			7.258344E-05f,
			8.6316744E-05f,
			0.00010264849f,
			0.00012207031f,
			0.00014516688f,
			0.00017263349f,
			0.00020529698f,
			0.00024414062f,
			0.00029033376f,
			0.00034526698f,
			0.00041059396f,
			0.00048828125f,
			0.0005806675f,
			0.00069053395f,
			0.0008211879f,
			0.0009765625f,
			0.001161335f,
			0.0013810679f,
			0.0016423758f,
			0.001953125f,
			0.00232267f,
			0.0027621358f,
			0.0032847517f,
			0.00390625f,
			0.00464534f,
			0.0055242716f,
			0.0065695033f,
			1f / 128f,
			0.00929068f,
			0.011048543f,
			0.013139007f,
			1f / 64f,
			0.01858136f,
			0.022097087f,
			0.026278013f,
			1f / 32f,
			0.03716272f,
			0.044194173f,
			0.052556027f,
			0.0625f,
			0.07432544f,
			0.088388346f,
			0.10511205f,
			0.125f,
			0.14865088f,
			0.17677669f,
			0.2102241f,
			0.25f,
			0.29730177f,
			0.35355338f,
			0.4204482f,
			0.5f,
			0.59460354f,
			0.70710677f,
			0.8408964f,
			1f,
			1.1892071f,
			1.4142135f,
			1.6817929f,
			2f,
			2.3784142f,
			2.828427f,
			3.3635857f,
			4f,
			4.7568283f,
			5.656854f,
			6.7271714f,
			8f,
			9.513657f,
			11.313708f,
			13.454343f,
			16f,
			19.027313f,
			22.627417f,
			26.908686f,
			32f,
			38.054626f,
			45.254833f,
			53.81737f,
			64f,
			76.10925f,
			90.50967f,
			107.63474f,
			128f,
			152.2185f,
			181.01933f,
			215.26949f,
			256f,
			304.437f,
			362.03867f,
			430.53897f,
			512f,
			608.874f,
			724.07733f,
			861.07794f,
			1024f,
			1217.748f,
			1448.1547f,
			1722.1559f,
			2048f,
			2435.496f
		};

		private int[] _sfBandIndexL;

		private int[] _sfBandIndexS;

		private byte[] _cbLookupL = new byte[576];

		private byte[] _cbLookupS = new byte[576];

		private byte[] _cbwLookupS = new byte[576];

		private int _cbLookupSR;

		private static readonly int[][] _sfBandIndexLTable = new int[9][]
		{
			new int[23]
			{
				0, 4, 8, 12, 16, 20, 24, 30, 36, 44,
				52, 62, 74, 90, 110, 134, 162, 196, 238, 288,
				342, 418, 576
			},
			new int[23]
			{
				0, 4, 8, 12, 16, 20, 24, 30, 36, 42,
				50, 60, 72, 88, 106, 128, 156, 190, 230, 276,
				330, 384, 576
			},
			new int[23]
			{
				0, 4, 8, 12, 16, 20, 24, 30, 36, 44,
				54, 66, 82, 102, 126, 156, 194, 240, 296, 364,
				448, 550, 576
			},
			new int[23]
			{
				0, 6, 12, 18, 24, 30, 36, 44, 54, 66,
				80, 96, 116, 140, 168, 200, 238, 284, 336, 396,
				464, 522, 576
			},
			new int[23]
			{
				0, 6, 12, 18, 24, 30, 36, 44, 54, 66,
				80, 96, 114, 136, 162, 194, 232, 278, 330, 394,
				464, 540, 576
			},
			new int[23]
			{
				0, 6, 12, 18, 24, 30, 36, 44, 54, 66,
				80, 96, 116, 140, 168, 200, 238, 284, 336, 396,
				464, 522, 576
			},
			new int[23]
			{
				0, 6, 12, 18, 24, 30, 36, 44, 54, 66,
				80, 96, 116, 140, 168, 200, 238, 284, 336, 396,
				464, 522, 576
			},
			new int[23]
			{
				0, 6, 12, 18, 24, 30, 36, 44, 54, 66,
				80, 96, 116, 140, 168, 200, 238, 284, 336, 396,
				464, 522, 576
			},
			new int[23]
			{
				0, 12, 24, 36, 48, 60, 72, 88, 108, 132,
				160, 192, 232, 280, 336, 400, 476, 566, 568, 570,
				572, 574, 576
			}
		};

		private static readonly int[][] _sfBandIndexSTable = new int[9][]
		{
			new int[14]
			{
				0, 4, 8, 12, 16, 22, 30, 40, 52, 66,
				84, 106, 136, 192
			},
			new int[14]
			{
				0, 4, 8, 12, 16, 22, 28, 38, 50, 64,
				80, 100, 126, 192
			},
			new int[14]
			{
				0, 4, 8, 12, 16, 22, 30, 42, 58, 78,
				104, 138, 180, 192
			},
			new int[14]
			{
				0, 4, 8, 12, 18, 24, 32, 42, 56, 74,
				100, 132, 174, 192
			},
			new int[14]
			{
				0, 4, 8, 12, 18, 26, 36, 48, 62, 80,
				104, 136, 180, 192
			},
			new int[14]
			{
				0, 4, 8, 12, 18, 26, 36, 48, 62, 80,
				104, 134, 174, 192
			},
			new int[14]
			{
				0, 4, 8, 12, 18, 26, 36, 48, 62, 80,
				104, 134, 174, 192
			},
			new int[14]
			{
				0, 4, 8, 12, 18, 26, 36, 48, 62, 80,
				104, 134, 174, 192
			},
			new int[14]
			{
				0, 8, 16, 24, 36, 52, 72, 96, 124, 160,
				162, 164, 166, 192
			}
		};

		private int[][][] _scalefac = new int[2][][]
		{
			new int[4][]
			{
				new int[13],
				new int[13],
				new int[13],
				new int[23]
			},
			new int[4][]
			{
				new int[13],
				new int[13],
				new int[13],
				new int[23]
			}
		};

		private static readonly int[][] _slen = new int[2][]
		{
			new int[16]
			{
				0, 0, 0, 0, 3, 1, 1, 1, 2, 2,
				2, 3, 3, 3, 4, 4
			},
			new int[16]
			{
				0, 1, 2, 3, 0, 1, 2, 3, 1, 2,
				3, 1, 2, 3, 2, 3
			}
		};

		private static readonly int[][][] _sfbBlockCntTab = new int[6][][]
		{
			new int[3][]
			{
				new int[4] { 6, 5, 5, 5 },
				new int[4] { 9, 9, 9, 9 },
				new int[4] { 6, 9, 9, 9 }
			},
			new int[3][]
			{
				new int[4] { 6, 5, 7, 3 },
				new int[4] { 9, 9, 12, 6 },
				new int[4] { 6, 9, 12, 6 }
			},
			new int[3][]
			{
				new int[4] { 11, 10, 0, 0 },
				new int[4] { 18, 18, 0, 0 },
				new int[4] { 15, 18, 0, 0 }
			},
			new int[3][]
			{
				new int[4] { 7, 7, 7, 0 },
				new int[4] { 12, 12, 12, 0 },
				new int[4] { 6, 15, 12, 0 }
			},
			new int[3][]
			{
				new int[4] { 6, 6, 6, 3 },
				new int[4] { 12, 9, 9, 6 },
				new int[4] { 6, 12, 9, 6 }
			},
			new int[3][]
			{
				new int[4] { 8, 8, 5, 0 },
				new int[4] { 15, 12, 9, 0 },
				new int[4] { 6, 18, 9, 0 }
			}
		};

		private float[][] _samples = new float[2][]
		{
			new float[579],
			new float[579]
		};

		private static readonly int[] PRETAB = new int[22]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 1, 1, 1, 2, 2, 3, 3, 3,
			2, 0
		};

		private static readonly float[] POW2_TAB = new float[64]
		{
			1f,
			0.70710677f,
			0.5f,
			0.35355338f,
			0.25f,
			0.17677669f,
			0.125f,
			0.088388346f,
			0.0625f,
			0.044194173f,
			1f / 32f,
			0.022097087f,
			1f / 64f,
			0.011048543f,
			1f / 128f,
			0.0055242716f,
			0.00390625f,
			0.0027621358f,
			0.001953125f,
			0.0013810679f,
			0.0009765625f,
			0.00069053395f,
			0.00048828125f,
			0.00034526698f,
			0.00024414062f,
			0.00017263349f,
			0.00012207031f,
			8.6316744E-05f,
			6.1035156E-05f,
			4.3158372E-05f,
			3.0517578E-05f,
			2.1579186E-05f,
			1.5258789E-05f,
			1.0789593E-05f,
			7.6293945E-06f,
			5.3947965E-06f,
			3.8146973E-06f,
			2.6973983E-06f,
			1.9073486E-06f,
			1.3486991E-06f,
			9.536743E-07f,
			6.7434956E-07f,
			4.7683716E-07f,
			3.3717478E-07f,
			2.3841858E-07f,
			1.6858739E-07f,
			1.1920929E-07f,
			8.4293696E-08f,
			5.9604645E-08f,
			4.2146848E-08f,
			2.9802322E-08f,
			2.1073424E-08f,
			1.4901161E-08f,
			1.0536712E-08f,
			7.450581E-09f,
			5.268356E-09f,
			3.7252903E-09f,
			2.634178E-09f,
			1.8626451E-09f,
			1.317089E-09f,
			9.313226E-10f,
			6.585445E-10f,
			4.656613E-10f,
			3.2927225E-10f
		};

		private static readonly float[][] _isRatio = new float[2][]
		{
			new float[7] { 0f, 0.21132487f, 0.36602542f, 0.5f, 0.6339746f, 0.7886751f, 1f },
			new float[7] { 1f, 0.7886751f, 0.6339746f, 0.5f, 0.36602542f, 0.21132487f, 0f }
		};

		private static readonly float[][][] _lsfRatio = new float[2][][]
		{
			new float[2][]
			{
				new float[32]
				{
					1f, 0.8408964f, 1f, 0.70710677f, 1f, 0.59460354f, 1f, 0.5f, 1f, 0.4204482f,
					1f, 0.35355338f, 1f, 0.29730177f, 1f, 0.25f, 1f, 0.2102241f, 1f, 0.17677669f,
					1f, 0.14865088f, 1f, 0.125f, 1f, 0.10511205f, 1f, 0.088388346f, 1f, 0.07432544f,
					1f, 0.0625f
				},
				new float[32]
				{
					1f, 1f, 0.8408964f, 1f, 0.70710677f, 1f, 0.59460354f, 1f, 0.5f, 1f,
					0.4204482f, 1f, 0.35355338f, 1f, 0.29730177f, 1f, 0.25f, 1f, 0.2102241f, 1f,
					0.17677669f, 1f, 0.14865088f, 1f, 0.125f, 1f, 0.10511205f, 1f, 0.088388346f, 1f,
					0.07432544f, 1f
				}
			},
			new float[2][]
			{
				new float[32]
				{
					1f,
					0.70710677f,
					1f,
					0.5f,
					1f,
					0.35355338f,
					1f,
					0.25f,
					1f,
					0.17677669f,
					1f,
					0.125f,
					1f,
					0.088388346f,
					1f,
					0.0625f,
					1f,
					0.044194173f,
					1f,
					1f / 32f,
					1f,
					0.022097087f,
					1f,
					1f / 64f,
					1f,
					0.011048543f,
					1f,
					1f / 128f,
					1f,
					0.0055242716f,
					1f,
					0.00390625f
				},
				new float[32]
				{
					1f,
					1f,
					0.70710677f,
					1f,
					0.5f,
					1f,
					0.35355338f,
					1f,
					0.25f,
					1f,
					0.17677669f,
					1f,
					0.125f,
					1f,
					0.088388346f,
					1f,
					0.0625f,
					1f,
					0.044194173f,
					1f,
					1f / 32f,
					1f,
					0.022097087f,
					1f,
					1f / 64f,
					1f,
					0.011048543f,
					1f,
					1f / 128f,
					1f,
					0.0055242716f,
					1f
				}
			}
		};

		private float[] _reorderBuf = new float[576];

		private static readonly float[] _scs = new float[8] { 0.8574929f, 0.881742f, 0.94962865f, 0.9833146f, 0.9955178f, 0.9991606f, 0.9998992f, 0.99999315f };

		private static readonly float[] _sca = new float[8] { -0.51449573f, -0.47173196f, -0.31337744f, -0.1819132f, -0.09457419f, -0.040965583f, -0.014198569f, -0.0036999746f };

		private float[] _polyPhase = new float[32];

		internal static bool GetCRC(MpegFrame frame, ref uint crc)
		{
			int num = frame.GetSideDataSize();
			while (--num >= 0)
			{
				MpegFrame.UpdateCRC(frame.ReadBits(8), 8, ref crc);
			}
			return true;
		}

		internal LayerIIIDecoder()
		{
			_tableSelect = new int[2][][]
			{
				new int[2][]
				{
					new int[3],
					new int[3]
				},
				new int[2][]
				{
					new int[3],
					new int[3]
				}
			};
			_subblockGain = new float[2][][]
			{
				new float[2][]
				{
					new float[3],
					new float[3]
				},
				new float[2][]
				{
					new float[3],
					new float[3]
				}
			};
		}

		internal override int DecodeFrame(IMpegFrame frame, float[] ch0, float[] ch1)
		{
			ReadSideInfo(frame);
			if (!_bitRes.AddBits(frame, _mainDataBegin))
			{
				return 0;
			}
			PrepTables(frame);
			int num = 0;
			int num2 = _channels - 1;
			if (_channels == 1 || base.StereoMode == StereoMode.LeftOnly || base.StereoMode == StereoMode.DownmixToMono)
			{
				_chanBufs[0] = ch0;
				num2 = 0;
			}
			else if (base.StereoMode == StereoMode.RightOnly)
			{
				_chanBufs[1] = ch0;
				num = 1;
			}
			else
			{
				_chanBufs[0] = ch0;
				_chanBufs[1] = ch1;
			}
			int num3 = ((frame.Version != MpegVersion.Version1) ? 1 : 2);
			int num4 = 0;
			for (int i = 0; i < num3; i++)
			{
				for (int j = 0; j < _channels; j++)
				{
					int sfBits = ((frame.Version != MpegVersion.Version1) ? ReadLsfScalefactors(i, j, frame.ChannelModeExtension) : ReadScalefactors(i, j));
					ReadSamples(sfBits, i, j);
				}
				Stereo(frame.ChannelMode, frame.ChannelModeExtension, i, frame.Version != MpegVersion.Version1);
				for (int k = num; k <= num2; k++)
				{
					float[] array = _samples[k];
					int num5 = _blockType[i][k];
					bool flag = _blockSplitFlag[i][k];
					bool flag2 = _mixedBlockFlag[i][k];
					if (flag && num5 == 2)
					{
						if (flag2)
						{
							Reorder(array, mixedBlock: true);
							AntiAlias(array, mixedBlock: true);
						}
						else
						{
							Reorder(array, mixedBlock: false);
						}
					}
					else
					{
						AntiAlias(array, mixedBlock: false);
					}
					_hybrid.Apply(array, k, num5, flag && flag2);
					FrequencyInversion(array);
					InversePolyphase(array, k, num4, _chanBufs[k]);
				}
				num4 += 576;
			}
			return num4;
		}

		internal override void ResetForSeek()
		{
			base.ResetForSeek();
			_hybrid.Reset();
			_bitRes.Reset();
		}

		private void ReadSideInfo(IMpegFrame frame)
		{
			if (frame.Version == MpegVersion.Version1)
			{
				_mainDataBegin = frame.ReadBits(9);
				if (frame.ChannelMode == MpegChannelMode.Mono)
				{
					_privBits = frame.ReadBits(5);
					_channels = 1;
				}
				else
				{
					_privBits = frame.ReadBits(3);
					_channels = 2;
				}
				for (int i = 0; i < _channels; i++)
				{
					_scfsi[i][0] = frame.ReadBits(1);
					_scfsi[i][1] = frame.ReadBits(1);
					_scfsi[i][2] = frame.ReadBits(1);
					_scfsi[i][3] = frame.ReadBits(1);
				}
				for (int j = 0; j < 2; j++)
				{
					for (int k = 0; k < _channels; k++)
					{
						_part23Length[j][k] = frame.ReadBits(12);
						_bigValues[j][k] = frame.ReadBits(9);
						_globalGain[j][k] = GAIN_TAB[frame.ReadBits(8)];
						_scalefacCompress[j][k] = frame.ReadBits(4);
						_blockSplitFlag[j][k] = frame.ReadBits(1) == 1;
						if (_blockSplitFlag[j][k])
						{
							_blockType[j][k] = frame.ReadBits(2);
							_mixedBlockFlag[j][k] = frame.ReadBits(1) == 1;
							_tableSelect[j][k][0] = frame.ReadBits(5);
							_tableSelect[j][k][1] = frame.ReadBits(5);
							_tableSelect[j][k][2] = 0;
							if (_blockType[j][k] == 2 && !_mixedBlockFlag[j][k])
							{
								_regionAddress1[j][k] = 8;
							}
							else
							{
								_regionAddress1[j][k] = 7;
							}
							_regionAddress2[j][k] = 20 - _regionAddress1[j][k];
							_subblockGain[j][k][0] = (float)frame.ReadBits(3) * -2f;
							_subblockGain[j][k][1] = (float)frame.ReadBits(3) * -2f;
							_subblockGain[j][k][2] = (float)frame.ReadBits(3) * -2f;
						}
						else
						{
							_tableSelect[j][k][0] = frame.ReadBits(5);
							_tableSelect[j][k][1] = frame.ReadBits(5);
							_tableSelect[j][k][2] = frame.ReadBits(5);
							_regionAddress1[j][k] = frame.ReadBits(4);
							_regionAddress2[j][k] = frame.ReadBits(3);
							_blockType[j][k] = 0;
							_subblockGain[j][k][0] = 0f;
							_subblockGain[j][k][1] = 0f;
							_subblockGain[j][k][2] = 0f;
						}
						_preflag[j][k] = frame.ReadBits(1);
						_scalefacScale[j][k] = 0.5f * (1f + (float)frame.ReadBits(1));
						_count1TableSelect[j][k] = frame.ReadBits(1);
					}
				}
				return;
			}
			_mainDataBegin = frame.ReadBits(8);
			if (frame.ChannelMode == MpegChannelMode.Mono)
			{
				_privBits = frame.ReadBits(1);
				_channels = 1;
			}
			else
			{
				_privBits = frame.ReadBits(2);
				_channels = 2;
			}
			int num = 0;
			for (int l = 0; l < _channels; l++)
			{
				_part23Length[num][l] = frame.ReadBits(12);
				_bigValues[num][l] = frame.ReadBits(9);
				_globalGain[num][l] = GAIN_TAB[frame.ReadBits(8)];
				_scalefacCompress[num][l] = frame.ReadBits(9);
				_blockSplitFlag[num][l] = frame.ReadBits(1) == 1;
				if (_blockSplitFlag[num][l])
				{
					_blockType[num][l] = frame.ReadBits(2);
					_mixedBlockFlag[num][l] = frame.ReadBits(1) == 1;
					_tableSelect[num][l][0] = frame.ReadBits(5);
					_tableSelect[num][l][1] = frame.ReadBits(5);
					_tableSelect[num][l][2] = 0;
					if (_blockType[num][l] == 2 && !_mixedBlockFlag[num][l])
					{
						_regionAddress1[num][l] = 8;
					}
					else
					{
						_regionAddress1[num][l] = 7;
					}
					_regionAddress2[num][l] = 20 - _regionAddress1[num][l];
					_subblockGain[num][l][0] = (float)frame.ReadBits(3) * -2f;
					_subblockGain[num][l][1] = (float)frame.ReadBits(3) * -2f;
					_subblockGain[num][l][2] = (float)frame.ReadBits(3) * -2f;
				}
				else
				{
					_tableSelect[num][l][0] = frame.ReadBits(5);
					_tableSelect[num][l][1] = frame.ReadBits(5);
					_tableSelect[num][l][2] = frame.ReadBits(5);
					_regionAddress1[num][l] = frame.ReadBits(4);
					_regionAddress2[num][l] = frame.ReadBits(3);
					_blockType[num][l] = 0;
					_subblockGain[num][l][0] = 0f;
					_subblockGain[num][l][1] = 0f;
					_subblockGain[num][l][2] = 0f;
				}
				_scalefacScale[num][l] = 0.5f * (1f + (float)frame.ReadBits(1));
				_count1TableSelect[num][l] = frame.ReadBits(1);
			}
		}

		private void PrepTables(IMpegFrame frame)
		{
			if (_cbLookupSR == frame.SampleRate)
			{
				return;
			}
			switch (frame.SampleRate)
			{
			case 44100:
				_sfBandIndexL = _sfBandIndexLTable[0];
				_sfBandIndexS = _sfBandIndexSTable[0];
				break;
			case 48000:
				_sfBandIndexL = _sfBandIndexLTable[1];
				_sfBandIndexS = _sfBandIndexSTable[1];
				break;
			case 32000:
				_sfBandIndexL = _sfBandIndexLTable[2];
				_sfBandIndexS = _sfBandIndexSTable[2];
				break;
			case 22050:
				_sfBandIndexL = _sfBandIndexLTable[3];
				_sfBandIndexS = _sfBandIndexSTable[3];
				break;
			case 24000:
				_sfBandIndexL = _sfBandIndexLTable[4];
				_sfBandIndexS = _sfBandIndexSTable[4];
				break;
			case 16000:
				_sfBandIndexL = _sfBandIndexLTable[5];
				_sfBandIndexS = _sfBandIndexSTable[5];
				break;
			case 11025:
				_sfBandIndexL = _sfBandIndexLTable[6];
				_sfBandIndexS = _sfBandIndexSTable[6];
				break;
			case 12000:
				_sfBandIndexL = _sfBandIndexLTable[7];
				_sfBandIndexS = _sfBandIndexSTable[7];
				break;
			case 8000:
				_sfBandIndexL = _sfBandIndexLTable[8];
				_sfBandIndexS = _sfBandIndexSTable[8];
				break;
			}
			int num = 0;
			int num2 = 0;
			int num3 = _sfBandIndexL[1];
			int num4 = _sfBandIndexS[1] * 3;
			for (int i = 0; i < 576; i++)
			{
				if (i == num3)
				{
					num++;
					num3 = _sfBandIndexL[num + 1];
				}
				if (i == num4)
				{
					num2++;
					num4 = _sfBandIndexS[num2 + 1] * 3;
				}
				_cbLookupL[i] = (byte)num;
				_cbLookupS[i] = (byte)num2;
			}
			int num5 = 0;
			for (num2 = 0; num2 < 12; num2++)
			{
				int num6 = _sfBandIndexS[num2 + 1] - _sfBandIndexS[num2];
				for (int j = 0; j < 3; j++)
				{
					int num7 = 0;
					while (num7 < num6)
					{
						_cbwLookupS[num5] = (byte)j;
						num7++;
						num5++;
					}
				}
			}
			_cbLookupSR = frame.SampleRate;
		}

		private int ReadScalefactors(int gr, int ch)
		{
			int num = _slen[0][_scalefacCompress[gr][ch]];
			int num2 = _slen[1][_scalefacCompress[gr][ch]];
			int i = 0;
			int num3;
			if (_blockSplitFlag[gr][ch] && _blockType[gr][ch] == 2)
			{
				if (num > 0)
				{
					num3 = num * 18;
					if (_mixedBlockFlag[gr][ch])
					{
						for (; i < 8; i++)
						{
							_scalefac[ch][3][i] = _bitRes.GetBits(num);
						}
						i = 3;
						num3 -= num;
					}
					for (; i < 6; i++)
					{
						_scalefac[ch][0][i] = _bitRes.GetBits(num);
						_scalefac[ch][1][i] = _bitRes.GetBits(num);
						_scalefac[ch][2][i] = _bitRes.GetBits(num);
					}
				}
				else
				{
					Array.Clear(_scalefac[ch][3], 0, 8);
					Array.Clear(_scalefac[ch][0], 0, 6);
					Array.Clear(_scalefac[ch][1], 0, 6);
					Array.Clear(_scalefac[ch][2], 0, 6);
					num3 = 0;
				}
				if (num2 > 0)
				{
					num3 += num2 * 18;
					for (i = 6; i < 12; i++)
					{
						_scalefac[ch][0][i] = _bitRes.GetBits(num2);
						_scalefac[ch][1][i] = _bitRes.GetBits(num2);
						_scalefac[ch][2][i] = _bitRes.GetBits(num2);
					}
				}
				else
				{
					Array.Clear(_scalefac[ch][0], 6, 6);
					Array.Clear(_scalefac[ch][1], 6, 6);
					Array.Clear(_scalefac[ch][2], 6, 6);
				}
			}
			else
			{
				num3 = 0;
				if (gr == 0 || _scfsi[ch][0] == 0)
				{
					if (num > 0)
					{
						num3 += num * 6;
						_scalefac[ch][3][0] = _bitRes.GetBits(num);
						_scalefac[ch][3][1] = _bitRes.GetBits(num);
						_scalefac[ch][3][2] = _bitRes.GetBits(num);
						_scalefac[ch][3][3] = _bitRes.GetBits(num);
						_scalefac[ch][3][4] = _bitRes.GetBits(num);
						_scalefac[ch][3][5] = _bitRes.GetBits(num);
					}
					else
					{
						Array.Clear(_scalefac[ch][3], 0, 6);
					}
				}
				if (gr == 0 || _scfsi[ch][1] == 0)
				{
					if (num > 0)
					{
						num3 += num * 5;
						_scalefac[ch][3][6] = _bitRes.GetBits(num);
						_scalefac[ch][3][7] = _bitRes.GetBits(num);
						_scalefac[ch][3][8] = _bitRes.GetBits(num);
						_scalefac[ch][3][9] = _bitRes.GetBits(num);
						_scalefac[ch][3][10] = _bitRes.GetBits(num);
					}
					else
					{
						Array.Clear(_scalefac[ch][3], 6, 5);
					}
				}
				if (gr == 0 || _scfsi[ch][2] == 0)
				{
					if (num2 > 0)
					{
						num3 += num2 * 5;
						_scalefac[ch][3][11] = _bitRes.GetBits(num2);
						_scalefac[ch][3][12] = _bitRes.GetBits(num2);
						_scalefac[ch][3][13] = _bitRes.GetBits(num2);
						_scalefac[ch][3][14] = _bitRes.GetBits(num2);
						_scalefac[ch][3][15] = _bitRes.GetBits(num2);
					}
					else
					{
						Array.Clear(_scalefac[ch][3], 11, 5);
					}
				}
				if (gr == 0 || _scfsi[ch][3] == 0)
				{
					if (num2 > 0)
					{
						num3 += num2 * 5;
						_scalefac[ch][3][16] = _bitRes.GetBits(num2);
						_scalefac[ch][3][17] = _bitRes.GetBits(num2);
						_scalefac[ch][3][18] = _bitRes.GetBits(num2);
						_scalefac[ch][3][19] = _bitRes.GetBits(num2);
						_scalefac[ch][3][20] = _bitRes.GetBits(num2);
					}
					else
					{
						Array.Clear(_scalefac[ch][3], 16, 5);
					}
				}
			}
			return num3;
		}

		private int ReadLsfScalefactors(int gr, int ch, int chanModeExt)
		{
			int num = _scalefacCompress[gr][ch];
			int num2 = ((_blockType[gr][ch] == 2) ? ((!_mixedBlockFlag[gr][ch]) ? 1 : 2) : 0);
			int num4;
			if ((chanModeExt & 1) == 1 && ch == 1)
			{
				int num3 = num >> 1;
				if (num3 < 180)
				{
					_readLsfScalefactorsSlen[0] = num3 / 36;
					_readLsfScalefactorsSlen[1] = num3 % 36 / 6;
					_readLsfScalefactorsSlen[2] = num3 % 6;
					_readLsfScalefactorsSlen[3] = 0;
					_preflag[gr][ch] = 0;
					num4 = 3;
				}
				else if (num3 < 244)
				{
					_readLsfScalefactorsSlen[0] = (num3 - 180) % 64 >> 4;
					_readLsfScalefactorsSlen[1] = (num3 - 180) % 16 >> 2;
					_readLsfScalefactorsSlen[2] = (num3 - 180) % 4;
					_readLsfScalefactorsSlen[3] = 0;
					_preflag[gr][ch] = 0;
					num4 = 4;
				}
				else if (num3 < 255)
				{
					_readLsfScalefactorsSlen[0] = (num3 - 244) / 3;
					_readLsfScalefactorsSlen[1] = (num3 - 244) % 3;
					_readLsfScalefactorsSlen[2] = 0;
					_readLsfScalefactorsSlen[3] = 0;
					_preflag[gr][ch] = 0;
					num4 = 5;
				}
				else
				{
					_readLsfScalefactorsSlen[0] = 0;
					_readLsfScalefactorsSlen[1] = 0;
					_readLsfScalefactorsSlen[2] = 0;
					_readLsfScalefactorsSlen[3] = 0;
					num4 = 0;
				}
			}
			else if (num < 400)
			{
				_readLsfScalefactorsSlen[0] = (num >> 4) / 5;
				_readLsfScalefactorsSlen[1] = (num >> 4) % 5;
				_readLsfScalefactorsSlen[2] = (num & 0xF) >> 2;
				_readLsfScalefactorsSlen[3] = num & 3;
				_preflag[gr][ch] = 0;
				num4 = 0;
			}
			else if (num < 500)
			{
				_readLsfScalefactorsSlen[0] = (num - 400 >> 2) / 5;
				_readLsfScalefactorsSlen[1] = (num - 400 >> 2) % 5;
				_readLsfScalefactorsSlen[2] = (num - 400) & 3;
				_readLsfScalefactorsSlen[3] = 0;
				_preflag[gr][ch] = 0;
				num4 = 1;
			}
			else if (num < 512)
			{
				_readLsfScalefactorsSlen[0] = (num - 500) / 3;
				_readLsfScalefactorsSlen[1] = (num - 500) % 3;
				_readLsfScalefactorsSlen[2] = 0;
				_readLsfScalefactorsSlen[3] = 0;
				_preflag[gr][ch] = 1;
				num4 = 2;
			}
			else
			{
				_readLsfScalefactorsSlen[0] = 0;
				_readLsfScalefactorsSlen[1] = 0;
				_readLsfScalefactorsSlen[2] = 0;
				_readLsfScalefactorsSlen[3] = 0;
				num4 = 0;
			}
			int num5 = 0;
			int[] array = _sfbBlockCntTab[num4][num2];
			for (int i = 0; i < 4; i++)
			{
				int num6 = 0;
				while (num6 < array[i])
				{
					_readLsfScalefactorsBuffer[num5] = ((_readLsfScalefactorsSlen[i] != 0) ? _bitRes.GetBits(_readLsfScalefactorsSlen[i]) : 0);
					num6++;
					num5++;
				}
			}
			num5 = 0;
			int j = 0;
			if (_blockSplitFlag[gr][ch] && _blockType[gr][ch] == 2)
			{
				if (_mixedBlockFlag[gr][ch])
				{
					for (; j < 8; j++)
					{
						_scalefac[ch][3][j] = _readLsfScalefactorsBuffer[num5++];
					}
					j = 3;
				}
				for (; j < 12; j++)
				{
					for (int k = 0; k < 3; k++)
					{
						_scalefac[ch][k][j] = _readLsfScalefactorsBuffer[num5++];
					}
				}
				_scalefac[ch][0][12] = 0;
				_scalefac[ch][1][12] = 0;
				_scalefac[ch][2][12] = 0;
			}
			else
			{
				for (; j < 21; j++)
				{
					_scalefac[ch][3][j] = _readLsfScalefactorsBuffer[num5++];
				}
				_scalefac[ch][3][22] = 0;
			}
			return _readLsfScalefactorsSlen[0] * array[0] + _readLsfScalefactorsSlen[1] * array[1] + _readLsfScalefactorsSlen[2] * array[2] + _readLsfScalefactorsSlen[3] * array[3];
		}

		private void ReadSamples(int sfBits, int gr, int ch)
		{
			int num;
			int num2;
			if (_blockSplitFlag[gr][ch] && _blockType[gr][ch] == 2)
			{
				num = 36;
				num2 = 576;
			}
			else
			{
				num = _sfBandIndexL[_regionAddress1[gr][ch] + 1];
				num2 = _sfBandIndexL[Math.Min(_regionAddress1[gr][ch] + _regionAddress2[gr][ch] + 2, 22)];
			}
			long num3 = _bitRes.BitsRead - sfBits + _part23Length[gr][ch];
			int num4 = 0;
			int table = _tableSelect[gr][ch][0];
			int num5 = _bigValues[gr][ch] * 2;
			float x;
			float y;
			while (num4 < num5 && num4 < num)
			{
				Huffman.Decode(_bitRes, table, out x, out y);
				_samples[ch][num4] = Dequantize(num4, x, gr, ch);
				num4++;
				_samples[ch][num4] = Dequantize(num4, y, gr, ch);
				num4++;
			}
			table = _tableSelect[gr][ch][1];
			while (num4 < num5 && num4 < num2)
			{
				Huffman.Decode(_bitRes, table, out x, out y);
				_samples[ch][num4] = Dequantize(num4, x, gr, ch);
				num4++;
				_samples[ch][num4] = Dequantize(num4, y, gr, ch);
				num4++;
			}
			table = _tableSelect[gr][ch][2];
			while (num4 < num5)
			{
				Huffman.Decode(_bitRes, table, out x, out y);
				_samples[ch][num4] = Dequantize(num4, x, gr, ch);
				num4++;
				_samples[ch][num4] = Dequantize(num4, y, gr, ch);
				num4++;
			}
			table = _count1TableSelect[gr][ch] + 32;
			while (num3 > _bitRes.BitsRead && num4 < 573)
			{
				Huffman.Decode(_bitRes, table, out x, out y, out var v, out var w);
				_samples[ch][num4] = Dequantize(num4, v, gr, ch);
				num4++;
				_samples[ch][num4] = Dequantize(num4, w, gr, ch);
				num4++;
				_samples[ch][num4] = Dequantize(num4, x, gr, ch);
				num4++;
				_samples[ch][num4] = Dequantize(num4, y, gr, ch);
				num4++;
			}
			if (_bitRes.BitsRead > num3)
			{
				_bitRes.RewindBits((int)(_bitRes.BitsRead - num3));
				num4 -= 4;
				if (num4 < 0)
				{
					num4 = 0;
				}
			}
			if (_bitRes.BitsRead < num3)
			{
				_bitRes.SkipBits((int)(num3 - _bitRes.BitsRead));
			}
			if (num4 < 576)
			{
				Array.Clear(_samples[ch], num4, 579 - num4);
			}
		}

		private float Dequantize(int idx, float val, int gr, int ch)
		{
			if (val != 0f)
			{
				int num;
				if (_blockSplitFlag[gr][ch] && _blockType[gr][ch] == 2 && (!_mixedBlockFlag[gr][ch] || idx >= _sfBandIndexL[8]))
				{
					num = _cbLookupS[idx];
					int num2 = _cbwLookupS[idx];
					return val * _globalGain[gr][ch] * POW2_TAB[(int)(-2f * (_subblockGain[gr][ch][num2] - _scalefacScale[gr][ch] * (float)_scalefac[ch][num2][num]))];
				}
				num = _cbLookupL[idx];
				return val * _globalGain[gr][ch] * POW2_TAB[(int)(2f * _scalefacScale[gr][ch] * (float)(_scalefac[ch][3][num] + _preflag[gr][ch] * PRETAB[num]))];
			}
			return 0f;
		}

		private void Stereo(MpegChannelMode channelMode, int chanModeExt, int gr, bool lsf)
		{
			if (channelMode == MpegChannelMode.JointStereo && chanModeExt != 0)
			{
				bool flag = (chanModeExt & 2) == 2;
				if ((chanModeExt & 1) == 1)
				{
					int num = -1;
					for (int num2 = 543; num2 >= 0; num2--)
					{
						if (_samples[1][num2] != 0f)
						{
							num = num2;
							break;
						}
					}
					int num3 = -1;
					int num4 = -1;
					if (_blockSplitFlag[gr][0] && _blockType[gr][0] == 2)
					{
						if (_mixedBlockFlag[gr][0])
						{
							if (num < _sfBandIndexL[8])
							{
								num3 = 8;
							}
							num4 = 3;
						}
						else
						{
							num4 = 0;
						}
					}
					else
					{
						num3 = 21;
					}
					int i = 0;
					if (num > -1)
					{
						i = _cbLookupL[num] + 1;
					}
					if (i > 0 && num4 == -1)
					{
						if (flag)
						{
							ApplyMidSide(0, _sfBandIndexL[i]);
						}
						else
						{
							ApplyFullStereo(0, _sfBandIndexL[i]);
						}
					}
					for (; i < num3; i++)
					{
						int i2 = _sfBandIndexL[i];
						int sb = _sfBandIndexL[i + 1] - _sfBandIndexL[i];
						int num5 = _scalefac[1][3][i];
						if (num5 == 7)
						{
							if (flag)
							{
								ApplyMidSide(i2, sb);
							}
							else
							{
								ApplyFullStereo(i2, sb);
							}
						}
						else if (lsf)
						{
							ApplyLsfIStereo(i2, sb, num5, _scalefacCompress[gr][0]);
						}
						else
						{
							ApplyIStereo(i2, sb, num5);
						}
					}
					if (num4 <= -1)
					{
						int num6 = _scalefac[1][3][20];
						if (num6 == 7)
						{
							if (flag)
							{
								ApplyMidSide(_sfBandIndexL[21], 576 - _sfBandIndexL[21]);
							}
							else
							{
								ApplyFullStereo(_sfBandIndexL[21], 576 - _sfBandIndexL[21]);
							}
						}
						else if (lsf)
						{
							ApplyLsfIStereo(_sfBandIndexL[21], 576 - _sfBandIndexL[21], num6, _scalefacCompress[gr][0]);
						}
						else
						{
							ApplyIStereo(_sfBandIndexL[21], 576 - _sfBandIndexL[21], num6);
						}
						return;
					}
					int[] array = new int[3] { -1, -1, -1 };
					int num7;
					if (num > -1)
					{
						i = _cbLookupS[num];
						num7 = _cbwLookupS[num];
						array[num7] = i;
					}
					else
					{
						i = 12;
						num7 = 3;
					}
					num7 = (num7 - 1) % 3;
					while (i >= num4 && num7 >= 0)
					{
						if (array[num7] != -1)
						{
							if (array[0] != -1 && array[1] != -1 && array[2] != -1)
							{
								break;
							}
						}
						else
						{
							int num8 = _sfBandIndexS[i + 1] - _sfBandIndexS[i];
							int num9 = _sfBandIndexS[i] * 3 + num8 * (num7 + 1);
							while (--num8 >= -1)
							{
								if (_samples[1][--num9] != 0f)
								{
									array[num7] = i;
									break;
								}
							}
							if (num7 == 0)
							{
								i--;
							}
						}
						num7 = (num7 - 1) % 3;
					}
					for (i = num4; i < 12; i++)
					{
						int num10 = _sfBandIndexS[i + 1] - _sfBandIndexS[i];
						int num11 = _sfBandIndexS[i] * 3;
						for (num7 = 0; num7 < 3; num7++)
						{
							if (i > array[num7])
							{
								int num12 = _scalefac[1][num7][i];
								if (num12 == 7)
								{
									if (flag)
									{
										ApplyMidSide(num11, num10);
									}
									else
									{
										ApplyFullStereo(num11, num10);
									}
								}
								else if (lsf)
								{
									ApplyLsfIStereo(num11, num10, num12, _scalefacCompress[gr][0]);
								}
								else
								{
									ApplyIStereo(num11, num10, num12);
								}
							}
							else if (flag)
							{
								ApplyMidSide(num11, num10);
							}
							else
							{
								ApplyFullStereo(num11, num10);
							}
							num11 += num10;
						}
					}
					int num13 = _sfBandIndexS[13] - _sfBandIndexS[12];
					for (num7 = 0; num7 < 3; num7++)
					{
						int num14 = _scalefac[1][num7][11];
						if (num14 == 7)
						{
							if (flag)
							{
								ApplyMidSide(_sfBandIndexS[11] * 3 + num13 * num7, num13);
							}
							else
							{
								ApplyFullStereo(_sfBandIndexS[11] * 3 + num13 * num7, num13);
							}
						}
						else if (lsf)
						{
							ApplyLsfIStereo(_sfBandIndexS[11] * 3 + num13 * num7, num13, num14, _scalefacCompress[gr][0]);
						}
						else
						{
							ApplyIStereo(_sfBandIndexS[11] * 3 + num13 * num7, num13, num14);
						}
					}
				}
				else if (flag)
				{
					ApplyMidSide(0, 576);
				}
				else
				{
					ApplyFullStereo(0, 576);
				}
			}
			else if (_channels != 1)
			{
				ApplyFullStereo(0, 576);
			}
		}

		private void ApplyIStereo(int i, int sb, int isPos)
		{
			if (base.StereoMode == StereoMode.DownmixToMono)
			{
				while (sb > 0)
				{
					_samples[0][i] /= 2f;
					sb--;
					i++;
				}
				return;
			}
			float num = _isRatio[0][isPos];
			float num2 = _isRatio[1][isPos];
			while (sb > 0)
			{
				_samples[1][i] = _samples[0][i] * num2;
				_samples[0][i] *= num;
				sb--;
				i++;
			}
		}

		private void ApplyLsfIStereo(int i, int sb, int isPos, int scalefacCompress)
		{
			float num = _lsfRatio[scalefacCompress % 1][isPos][0];
			float num2 = _lsfRatio[scalefacCompress % 1][isPos][1];
			if (base.StereoMode == StereoMode.DownmixToMono)
			{
				float num3 = 1f / (num + num2);
				while (sb > 0)
				{
					_samples[0][i] *= num3;
					sb--;
					i++;
				}
			}
			else
			{
				while (sb > 0)
				{
					_samples[1][i] = _samples[0][i] * num2;
					_samples[0][i] *= num;
					sb--;
					i++;
				}
			}
		}

		private void ApplyMidSide(int i, int sb)
		{
			if (base.StereoMode == StereoMode.DownmixToMono)
			{
				while (sb > 0)
				{
					_samples[0][i] *= 0.70710677f;
					sb--;
					i++;
				}
				return;
			}
			while (sb > 0)
			{
				float num = _samples[0][i];
				float num2 = _samples[1][i];
				_samples[0][i] = (num + num2) * 0.70710677f;
				_samples[1][i] = (num - num2) * 0.70710677f;
				sb--;
				i++;
			}
		}

		private void ApplyFullStereo(int i, int sb)
		{
			if (base.StereoMode == StereoMode.DownmixToMono)
			{
				while (sb > 0)
				{
					_samples[0][i] = (_samples[0][i] + _samples[1][i]) / 2f;
					sb--;
					i++;
				}
			}
		}

		private void Reorder(float[] buf, bool mixedBlock)
		{
			int i = 0;
			if (mixedBlock)
			{
				Array.Copy(buf, 0, _reorderBuf, 0, 36);
				i = 3;
			}
			for (; i < 13; i++)
			{
				int num = _sfBandIndexS[i];
				int num2 = _sfBandIndexS[i + 1] - num;
				for (int j = 0; j < 3; j++)
				{
					for (int k = 0; k < num2; k++)
					{
						int num3 = num * 3 + j * num2 + k;
						int num4 = num * 3 + j + k * 3;
						_reorderBuf[num4] = buf[num3];
					}
				}
			}
			Array.Copy(_reorderBuf, buf, 576);
		}

		private void AntiAlias(float[] buf, bool mixedBlock)
		{
			int num = (mixedBlock ? 1 : 31);
			int num2 = 0;
			int num3 = 0;
			while (num2 < num)
			{
				int num4 = 0;
				int num5 = num3 + 18 - 1;
				int num6 = num3 + 18;
				while (num4 < 8)
				{
					float num7 = buf[num5];
					float num8 = buf[num6];
					buf[num5] = num7 * _scs[num4] - num8 * _sca[num4];
					buf[num6] = num8 * _scs[num4] + num7 * _sca[num4];
					num4++;
					num5--;
					num6++;
				}
				num2++;
				num3 += 18;
			}
		}

		private void FrequencyInversion(float[] buf)
		{
			for (int i = 1; i < 18; i += 2)
			{
				for (int j = 1; j < 32; j += 2)
				{
					buf[j * 18 + i] = 0f - buf[j * 18 + i];
				}
			}
		}

		private void InversePolyphase(float[] buf, int ch, int ofs, float[] outBuf)
		{
			int num = 0;
			while (num < 18)
			{
				for (int i = 0; i < 32; i++)
				{
					_polyPhase[i] = buf[i * 18 + num];
				}
				InversePolyPhase(ch, _polyPhase);
				Array.Copy(_polyPhase, 0, outBuf, ofs, 32);
				num++;
				ofs += 32;
			}
		}
	}
	internal class MpegFrame : FrameBase, IMpegFrame
	{
		private static readonly int[][][] _bitRateTable = new int[2][][]
		{
			new int[3][]
			{
				new int[15]
				{
					0, 32, 64, 96, 128, 160, 192, 224, 256, 288,
					320, 352, 384, 416, 448
				},
				new int[15]
				{
					0, 32, 48, 56, 64, 80, 96, 112, 128, 160,
					192, 224, 256, 320, 384
				},
				new int[15]
				{
					0, 32, 40, 48, 56, 64, 80, 96, 112, 128,
					160, 192, 224, 256, 320
				}
			},
			new int[3][]
			{
				new int[15]
				{
					0, 32, 48, 56, 64, 80, 96, 112, 128, 144,
					160, 176, 192, 224, 256
				},
				new int[15]
				{
					0, 8, 16, 24, 32, 40, 48, 56, 64, 80,
					96, 112, 128, 144, 160
				},
				new int[15]
				{
					0, 8, 16, 24, 32, 40, 48, 56, 64, 80,
					96, 112, 128, 144, 160
				}
			}
		};

		internal MpegFrame Next;

		internal int Number;

		private int _syncBits;

		private int _readOffset;

		private int _bitsRead;

		private ulong _bitBucket;

		private long _offset;

		private bool _isMuted;

		public int FrameLength => base.Length;

		public MpegVersion Version => ((_syncBits >> 19) & 3) switch
		{
			0 => MpegVersion.Version25, 
			2 => MpegVersion.Version2, 
			3 => MpegVersion.Version1, 
			_ => MpegVersion.Unknown, 
		};

		public MpegLayer Layer => (MpegLayer)((4 - ((_syncBits >> 17) & 3)) % 4);

		public bool HasCrc => (_syncBits & 0x10000) == 0;

		public int BitRate
		{
			get
			{
				if (BitRateIndex > 0)
				{
					return _bitRateTable[(int)Version / 10 - 1][(int)(Layer - 1)][BitRateIndex] * 1000;
				}
				return (FrameLength * 8 * SampleRate / SampleCount + 499 + 500) / 1000 * 1000;
			}
		}

		public int BitRateIndex => (_syncBits >> 12) & 0xF;

		public int SampleRate
		{
			get
			{
				int num = SampleRateIndex switch
				{
					0 => 44100, 
					1 => 48000, 
					2 => 32000, 
					_ => 0, 
				};
				if (Version > MpegVersion.Version1)
				{
					num = ((Version != MpegVersion.Version25) ? (num / 2) : (num / 4));
				}
				return num;
			}
		}

		public int SampleRateIndex => (_syncBits >> 10) & 3;

		private int Padding => (_syncBits >> 9) & 1;

		public MpegChannelMode ChannelMode => (MpegChannelMode)((_syncBits >> 6) & 3);

		public int ChannelModeExtension => (_syncBits >> 4) & 3;

		internal int Channels
		{
			get
			{
				if (ChannelMode != MpegChannelMode.Mono)
				{
					return 2;
				}
				return 1;
			}
		}

		public bool IsCopyrighted => (_syncBits & 8) == 8;

		internal bool IsOriginal => (_syncBits & 4) == 4;

		internal int EmphasisMode => _syncBits & 3;

		public bool IsCorrupted => _isMuted;

		public int SampleCount
		{
			get
			{
				if (Layer == MpegLayer.LayerI)
				{
					return 384;
				}
				if (Layer == MpegLayer.LayerIII && Version > MpegVersion.Version1)
				{
					return 576;
				}
				return 1152;
			}
		}

		internal long SampleOffset
		{
			get
			{
				return _offset;
			}
			set
			{
				_offset = value;
			}
		}

		internal static MpegFrame TrySync(uint syncMark)
		{
			if ((syncMark & 0xFFE00000u) == 4292870144u && (syncMark & 0x180000) != 524288 && (syncMark & 0x60000) != 0 && (syncMark & 0xF000) != 61440 && (syncMark & 0xC00) != 3072)
			{
				switch ((syncMark >> 4) & 0xF)
				{
				case 0u:
				case 4u:
				case 5u:
				case 6u:
				case 7u:
				case 8u:
				case 12u:
					return new MpegFrame
					{
						_syncBits = (int)syncMark
					};
				}
			}
			return null;
		}

		private MpegFrame()
		{
		}

		protected override int Validate()
		{
			if (Layer == MpegLayer.LayerII)
			{
				switch (BitRate)
				{
				case 32000:
				case 48000:
				case 56000:
				case 80000:
					if (ChannelMode != MpegChannelMode.Mono)
					{
						return -1;
					}
					break;
				case 224000:
				case 256000:
				case 320000:
				case 384000:
					if (ChannelMode == MpegChannelMode.Mono)
					{
						return -1;
					}
					break;
				}
			}
			int result = ((BitRateIndex <= 0) ? (_readOffset + GetSideDataSize() + Padding) : ((Layer != MpegLayer.LayerI) ? (144 * BitRate / SampleRate + Padding) : ((12 * BitRate / SampleRate + Padding) * 4)));
			if (HasCrc)
			{
				_readOffset = 4 + (HasCrc ? 2 : 0);
				if (!ValidateCRC())
				{
					_isMuted = true;
					return 6;
				}
			}
			Reset();
			return result;
		}

		internal int GetSideDataSize()
		{
			switch (Layer)
			{
			case MpegLayer.LayerI:
				if (ChannelMode == MpegChannelMode.Mono)
				{
					return 16;
				}
				if (ChannelMode == MpegChannelMode.Stereo || ChannelMode == MpegChannelMode.DualChannel)
				{
					return 32;
				}
				switch (ChannelModeExtension)
				{
				case 0:
					return 18;
				case 1:
					return 20;
				case 2:
					return 22;
				case 3:
					return 24;
				}
				break;
			case MpegLayer.LayerII:
				return 0;
			case MpegLayer.LayerIII:
				if (ChannelMode == MpegChannelMode.Mono && Version >= MpegVersion.Version2)
				{
					return 9;
				}
				if (ChannelMode != MpegChannelMode.Mono && Version < MpegVersion.Version2)
				{
					return 32;
				}
				return 17;
			}
			return 0;
		}

		private bool ValidateCRC()
		{
			uint crc = 65535u;
			UpdateCRC(_syncBits, 16, ref crc);
			bool flag = false;
			switch (Layer)
			{
			case MpegLayer.LayerI:
				flag = LayerIDecoder.GetCRC(this, ref crc);
				break;
			case MpegLayer.LayerII:
				flag = LayerIIDecoder.GetCRC(this, ref crc);
				break;
			case MpegLayer.LayerIII:
				flag = LayerIIIDecoder.GetCRC(this, ref crc);
				break;
			}
			if (flag)
			{
				return ((ReadByte(4) << 8) | ReadByte(5)) == crc;
			}
			return true;
		}

		internal static void UpdateCRC(int data, int length, ref uint crc)
		{
			uint num = (uint)(1 << length);
			while ((num >>= 1) != 0)
			{
				uint num2 = crc & 0x8000;
				crc <<= 1;
				if ((num2 == 0) ^ ((data & num) == 0))
				{
					crc ^= 32773u;
				}
			}
			crc &= 65535u;
		}

		internal VBRInfo ParseVBR()
		{
			byte[] array = new byte[4];
			int num = ((Version == MpegVersion.Version1 && ChannelMode != MpegChannelMode.Mono) ? 36 : ((Version <= MpegVersion.Version1 || ChannelMode != MpegChannelMode.Mono) ? 21 : 13));
			if (Read(num, array) != 4)
			{
				return null;
			}
			if ((array[0] == 88 && array[1] == 105 && array[2] == 110 && array[3] == 103) || (array[0] == 73 && array[1] == 110 && array[2] == 102 && array[3] == 111))
			{
				return ParseXing(num + 4);
			}
			if (Read(36, array) != 4)
			{
				return null;
			}
			if (array[0] == 86 && array[1] == 66 && array[2] == 82 && array[3] == 73)
			{
				return ParseVBRI();
			}
			return null;
		}

		private VBRInfo ParseXing(int offset)
		{
			VBRInfo vBRInfo = new VBRInfo();
			vBRInfo.Channels = Channels;
			vBRInfo.SampleRate = SampleRate;
			vBRInfo.SampleCount = SampleCount;
			byte[] array = new byte[100];
			if (Read(offset, array, 0, 4) != 4)
			{
				return null;
			}
			offset += 4;
			int num = (array[0] << 24) | (array[1] << 16) | (array[2] << 8) | array[3];
			if ((num & 1) != 0)
			{
				if (Read(offset, array, 0, 4) != 4)
				{
					return null;
				}
				offset += 4;
				vBRInfo.VBRFrames = (array[0] << 24) | (array[1] << 16) | (array[2] << 8) | array[3];
			}
			if ((num & 2) != 0)
			{
				if (Read(offset, array, 0, 4) != 4)
				{
					return null;
				}
				offset += 4;
				vBRInfo.VBRBytes = (array[0] << 24) | (array[1] << 16) | (array[2] << 8) | array[3];
			}
			if ((num & 4) != 0)
			{
				if (Read(offset, array) != 100)
				{
					return null;
				}
				offset += 100;
			}
			if ((num & 8) != 0)
			{
				if (Read(offset, array, 0, 4) != 4)
				{
					return null;
				}
				offset += 4;
				vBRInfo.VBRQuality = (array[0] << 24) | (array[1] << 16) | (array[2] << 8) | array[3];
			}
			return vBRInfo;
		}

		private VBRInfo ParseVBRI()
		{
			VBRInfo vBRInfo = new VBRInfo();
			vBRInfo.Channels = Channels;
			vBRInfo.SampleRate = SampleRate;
			vBRInfo.SampleCount = SampleCount;
			byte[] array = new byte[26];
			if (Read(36, array) != 26)
			{
				return null;
			}
			_ = array[4];
			_ = array[5];
			vBRInfo.VBRDelay = (array[6] << 8) | array[7];
			vBRInfo.VBRQuality = (array[8] << 8) | array[9];
			vBRInfo.VBRBytes = (array[10] << 24) | (array[11] << 16) | (array[12] << 8) | array[13];
			vBRInfo.VBRFrames = (array[14] << 24) | (array[15] << 16) | (array[16] << 8) | array[17];
			int num = (array[18] << 8) | array[19];
			_ = array[20];
			_ = array[21];
			int num2 = (array[22] << 8) | array[23];
			_ = array[24];
			_ = array[25];
			int num3 = num * num2;
			byte[] buffer = new byte[num3];
			if (Read(62, buffer) != num3)
			{
				return null;
			}
			return vBRInfo;
		}

		public void Reset()
		{
			_readOffset = 4 + (HasCrc ? 2 : 0);
			_bitBucket = 0uL;
			_bitsRead = 0;
		}

		public int ReadBits(int bitCount)
		{
			if (bitCount < 1 || bitCount > 32)
			{
				throw new ArgumentOutOfRangeException("bitCount");
			}
			if (_isMuted)
			{
				return 0;
			}
			while (_bitsRead < bitCount)
			{
				int num = ReadByte(_readOffset);
				if (num == -1)
				{
					throw new EndOfStreamException();
				}
				_readOffset++;
				_bitBucket <<= 8;
				_bitBucket |= (byte)(num & 0xFF);
				_bitsRead += 8;
			}
			int result = (int)((long)(_bitBucket >> _bitsRead - bitCount) & ((1L << bitCount) - 1));
			_bitsRead -= bitCount;
			return result;
		}
	}
	internal class MpegStreamReader
	{
		private class ReadBuffer
		{
			public byte[] Data;

			public long BaseOffset;

			public int End;

			public int DiscardCount;

			private object _localLock = new object();

			public ReadBuffer(int initialSize)
			{
				initialSize = 2 << (int)Math.Log(initialSize, 2.0);
				Data = new byte[initialSize];
			}

			public int Read(MpegStreamReader reader, long offset, byte[] buffer, int index, int count)
			{
				lock (_localLock)
				{
					int srcOffset = EnsureFilled(reader, offset, ref count);
					Buffer.BlockCopy(Data, srcOffset, buffer, index, count);
					return count;
				}
			}

			public int ReadByte(MpegStreamReader reader, long offset)
			{
				lock (_localLock)
				{
					int count = 1;
					int num = EnsureFilled(reader, offset, ref count);
					if (count == 1)
					{
						return Data[num];
					}
				}
				return -1;
			}

			private int EnsureFilled(MpegStreamReader reader, long offset, ref int count)
			{
				int num = (int)(offset - BaseOffset);
				int num2 = num + count;
				if (num < 0 || num2 > End)
				{
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					long num6 = 0L;
					if (num < 0)
					{
						if (!reader._source.CanSeek)
						{
							throw new InvalidOperationException("Cannot seek backwards on a forward-only stream!");
						}
						if (End > 0 && (num + Data.Length > 0 || (Data.Length * 2 <= 16384 && num + Data.Length * 2 > 0)))
						{
							num2 = End;
						}
						num6 = offset;
						if (num2 < 0)
						{
							Truncate();
							BaseOffset = offset;
							num = 0;
							num2 = count;
							num4 = count;
						}
						else
						{
							num5 = -num2;
							num4 = -num;
						}
					}
					else if (num2 < Data.Length)
					{
						num4 = num2 - End;
						num3 = End;
						num6 = BaseOffset + num3;
					}
					else if (num2 - DiscardCount < Data.Length)
					{
						num5 = DiscardCount;
						num3 = End;
						num4 = num2 - num3;
						num6 = BaseOffset + num3;
					}
					else if (Data.Length * 2 <= 16384)
					{
						num5 = DiscardCount;
						num3 = End;
						num4 = num2 - End;
						num6 = BaseOffset + num3;
					}
					else
					{
						Truncate();
						BaseOffset = offset;
						num6 = offset;
						num = 0;
						num2 = count;
						num4 = count;
					}
					if (num2 - num5 > Data.Length || num3 + num4 - num5 > Data.Length)
					{
						int num7;
						for (num7 = Data.Length * 2; num7 < num2 - num5; num7 *= 2)
						{
						}
						byte[] array = new byte[num7];
						if (num5 < 0)
						{
							Buffer.BlockCopy(Data, 0, array, -num5, End + num5);
							DiscardCount = 0;
						}
						else
						{
							Buffer.BlockCopy(Data, num5, array, 0, End - num5);
							DiscardCount -= num5;
						}
						Data = array;
					}
					else if (num5 != 0)
					{
						if (num5 > 0)
						{
							Buffer.BlockCopy(Data, num5, Data, 0, End - num5);
							DiscardCount -= num5;
						}
						else
						{
							int num8 = 0;
							int num9 = Data.Length - 1;
							int num10 = Data.Length - 1 - num5;
							while (num8 < num5)
							{
								Data[num10] = Data[num9];
								num8++;
								num9--;
								num10--;
							}
							DiscardCount = 0;
						}
					}
					BaseOffset += num5;
					num3 -= num5;
					num -= num5;
					num2 -= num5;
					End -= num5;
					lock (reader._readLock)
					{
						if (num4 > 0 && reader._source.Position != num6 && num6 < reader._eofOffset)
						{
							if (reader._canSeek)
							{
								try
								{
									reader._source.Position = num6;
								}
								catch (EndOfStreamException)
								{
									reader._eofOffset = reader._source.Length;
									num4 = 0;
								}
							}
							else
							{
								long num11 = num6 - reader._source.Position;
								while (--num11 >= 0)
								{
									if (reader._source.ReadByte() == -1)
									{
										reader._eofOffset = reader._source.Position;
										num4 = 0;
										break;
									}
								}
							}
						}
						while (num4 > 0 && num6 < reader._eofOffset)
						{
							int num12 = reader._source.Read(Data, num3, num4);
							if (num12 == 0)
							{
								break;
							}
							num3 += num12;
							num6 += num12;
							num4 -= num12;
						}
						if (num3 > End)
						{
							End = num3;
						}
						if (End < num2)
						{
							count = Math.Max(0, End - num);
						}
						else if (End < Data.Length)
						{
							int num13 = reader._source.Read(Data, End, Data.Length - End);
							End += num13;
						}
					}
				}
				return num;
			}

			public void DiscardThrough(long offset)
			{
				lock (_localLock)
				{
					int val = (int)(offset - BaseOffset);
					DiscardCount = Math.Max(val, DiscardCount);
					if (DiscardCount >= Data.Length)
					{
						CommitDiscard();
					}
				}
			}

			private void Truncate()
			{
				End = 0;
				DiscardCount = 0;
			}

			private void CommitDiscard()
			{
				if (DiscardCount >= Data.Length || DiscardCount >= End)
				{
					BaseOffset += DiscardCount;
					End = 0;
				}
				else
				{
					Buffer.BlockCopy(Data, DiscardCount, Data, 0, End - DiscardCount);
					BaseOffset += DiscardCount;
					End -= DiscardCount;
				}
				DiscardCount = 0;
			}
		}

		private ID3Frame _id3Frame;

		private ID3Frame _id3v1Frame;

		private RiffHeaderFrame _riffHeaderFrame;

		private VBRInfo _vbrInfo;

		private MpegFrame _first;

		private MpegFrame _current;

		private MpegFrame _last;

		private MpegFrame _lastFree;

		private long _readOffset;

		private long _eofOffset;

		private Stream _source;

		private bool _canSeek;

		private bool _endFound;

		private bool _mixedFrameSize;

		private object _readLock = new object();

		private object _frameLock = new object();

		private ReadBuffer _readBuf = new ReadBuffer(2048);

		internal bool CanSeek => _canSeek;

		internal long SampleCount
		{
			get
			{
				if (_vbrInfo != null)
				{
					return _vbrInfo.VBRStreamSampleCount;
				}
				if (!_canSeek)
				{
					return -1L;
				}
				ReadToEnd();
				return _last.SampleCount + _last.SampleOffset;
			}
		}

		internal int SampleRate
		{
			get
			{
				if (_vbrInfo != null)
				{
					return _vbrInfo.SampleRate;
				}
				return _first.SampleRate;
			}
		}

		internal int Channels
		{
			get
			{
				if (_vbrInfo != null)
				{
					return _vbrInfo.Channels;
				}
				return _first.Channels;
			}
		}

		internal int FirstFrameSampleCount
		{
			get
			{
				if (_first == null)
				{
					return 0;
				}
				return _first.SampleCount;
			}
		}

		internal MpegStreamReader(Stream source)
		{
			_source = source;
			_canSeek = source.CanSeek;
			_readOffset = 0L;
			_eofOffset = long.MaxValue;
			FrameBase frameBase = FindNextFrame();
			while (frameBase != null && !(frameBase is MpegFrame))
			{
				frameBase = FindNextFrame();
			}
			if (frameBase == null)
			{
				throw new InvalidDataException("Not a valid MPEG file!");
			}
			frameBase = FindNextFrame();
			if (frameBase == null || !(frameBase is MpegFrame))
			{
				throw new InvalidDataException("Not a valid MPEG file!");
			}
			_current = _first;
		}

		private FrameBase FindNextFrame()
		{
			if (_endFound)
			{
				return null;
			}
			MpegFrame lastFree = _lastFree;
			long num = _readOffset;
			lock (_frameLock)
			{
				byte[] array = new byte[4];
				try
				{
					if (Read(_readOffset, array, 0, 4) == 4)
					{
						do
						{
							uint syncMark = (uint)((array[0] << 24) | (array[1] << 16) | (array[2] << 8) | array[3]);
							num = _readOffset;
							if (_id3Frame == null)
							{
								ID3Frame iD3Frame = ID3Frame.TrySync(syncMark);
								if (iD3Frame != null && iD3Frame.Validate(_readOffset, this))
								{
									if (!_canSeek)
									{
										iD3Frame.SaveBuffer();
									}
									_readOffset += iD3Frame.Length;
									DiscardThrough(_readOffset, minimalRead: true);
									return _id3Frame = iD3Frame;
								}
							}
							if (_first == null && _riffHeaderFrame == null)
							{
								RiffHeaderFrame riffHeaderFrame = RiffHeaderFrame.TrySync(syncMark);
								if (riffHeaderFrame != null && riffHeaderFrame.Validate(_readOffset, this))
								{
									_readOffset += riffHeaderFrame.Length;
									DiscardThrough(_readOffset, minimalRead: true);
									return _riffHeaderFrame = riffHeaderFrame;
								}
							}
							MpegFrame mpegFrame = MpegFrame.TrySync(syncMark);
							if (mpegFrame != null && mpegFrame.Validate(_readOffset, this) && (lastFree == null || (mpegFrame.Layer == lastFree.Layer && mpegFrame.Version == lastFree.Version && mpegFrame.SampleRate == lastFree.SampleRate && mpegFrame.BitRateIndex <= 0)))
							{
								if (!_canSeek)
								{
									mpegFrame.SaveBuffer();
									DiscardThrough(_readOffset + mpegFrame.FrameLength, minimalRead: true);
								}
								_readOffset += mpegFrame.FrameLength;
								if (_first == null)
								{
									if (_vbrInfo == null && (_vbrInfo = mpegFrame.ParseVBR()) != null)
									{
										return FindNextFrame();
									}
									mpegFrame.Number = 0;
									_first = (_last = mpegFrame);
								}
								else
								{
									if (mpegFrame.SampleCount != _first.SampleCount)
									{
										_mixedFrameSize = true;
									}
									mpegFrame.SampleOffset = _last.SampleCount + _last.SampleOffset;
									mpegFrame.Number = _last.Number + 1;
									_last = (_last.Next = mpegFrame);
								}
								if (mpegFrame.BitRateIndex == 0)
								{
									_lastFree = mpegFrame;
								}
								return mpegFrame;
							}
							if (_last != null)
							{
								ID3Frame iD3Frame2 = ID3Frame.TrySync(syncMark);
								if (iD3Frame2 != null && iD3Frame2.Validate(_readOffset, this))
								{
									if (!_canSeek)
									{
										iD3Frame2.SaveBuffer();
									}
									if (iD3Frame2.Version == 1)
									{
										_id3v1Frame = iD3Frame2;
									}
									else
									{
										_id3Frame.Merge(iD3Frame2);
									}
									_readOffset += iD3Frame2.Length;
									DiscardThrough(_readOffset, minimalRead: true);
									return iD3Frame2;
								}
							}
							_readOffset++;
							if (_first == null || !_canSeek)
							{
								DiscardThrough(_readOffset, minimalRead: true);
							}
							Buffer.BlockCopy(array, 1, array, 0, 3);
						}
						while (Read(_readOffset + 3, array, 3, 1) == 1);
					}
					num += 4;
					_endFound = true;
					return null;
				}
				finally
				{
					if (lastFree != null)
					{
						lastFree.Length = (int)(num - lastFree.Offset);
						if (!_canSeek)
						{
							throw new InvalidOperationException("Free frames cannot be read properly from forward-only streams!");
						}
						if (_lastFree == lastFree)
						{
							_lastFree = null;
						}
					}
				}
			}
		}

		internal int Read(long offset, byte[] buffer, int index, int count)
		{
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (index < 0 || index + count > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return _readBuf.Read(this, offset, buffer, index, count);
		}

		internal int ReadByte(long offset)
		{
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			return _readBuf.ReadByte(this, offset);
		}

		internal void DiscardThrough(long offset, bool minimalRead)
		{
			_readBuf.DiscardThrough(offset);
		}

		internal void ReadToEnd()
		{
			try
			{
				int num = 40000;
				if (_id3Frame != null)
				{
					num += _id3Frame.Length;
				}
				while (!_endFound)
				{
					FindNextFrame();
					while (!_canSeek && FrameBase.TotalAllocation >= num)
					{
						Task.Delay(500).Wait();
					}
				}
			}
			catch (ObjectDisposedException)
			{
			}
		}

		internal long SeekTo(long sampleNumber)
		{
			if (!_canSeek)
			{
				throw new InvalidOperationException("Cannot seek!");
			}
			int num = (int)(sampleNumber / _first.SampleCount);
			MpegFrame mpegFrame = _first;
			if (_current != null && _current.Number <= num && _current.SampleOffset <= sampleNumber)
			{
				mpegFrame = _current;
				num -= mpegFrame.Number;
			}
			while (!_mixedFrameSize && --num >= 0 && mpegFrame != null)
			{
				if (mpegFrame == _last && !_endFound)
				{
					do
					{
						FindNextFrame();
					}
					while (mpegFrame == _last && !_endFound);
				}
				if (_mixedFrameSize)
				{
					break;
				}
				mpegFrame = mpegFrame.Next;
			}
			while (mpegFrame != null && mpegFrame.SampleOffset + mpegFrame.SampleCount < sampleNumber)
			{
				if (mpegFrame == _last && !_endFound)
				{
					do
					{
						FindNextFrame();
					}
					while (mpegFrame == _last && !_endFound);
				}
				mpegFrame = mpegFrame.Next;
			}
			if (mpegFrame == null)
			{
				return -1L;
			}
			return (_current = mpegFrame).SampleOffset;
		}

		internal MpegFrame NextFrame()
		{
			MpegFrame current = _current;
			if (current != null)
			{
				if (_canSeek)
				{
					current.SaveBuffer();
					DiscardThrough(current.Offset + current.FrameLength, minimalRead: false);
				}
				if (current == _last && !_endFound)
				{
					do
					{
						FindNextFrame();
					}
					while (current == _last && !_endFound);
				}
				_current = current.Next;
				if (!_canSeek)
				{
					lock (_frameLock)
					{
						MpegFrame first = _first;
						_first = first.Next;
						first.Next = null;
					}
				}
			}
			return current;
		}

		internal MpegFrame GetCurrentFrame()
		{
			return _current;
		}
	}
	internal class RiffHeaderFrame : FrameBase
	{
		internal static RiffHeaderFrame TrySync(uint syncMark)
		{
			if (syncMark == 1380533830)
			{
				return new RiffHeaderFrame();
			}
			return null;
		}

		private RiffHeaderFrame()
		{
		}

		protected override int Validate()
		{
			byte[] array = new byte[4];
			if (Read(8, array) != 4)
			{
				return -1;
			}
			if (array[0] != 87 || array[1] != 65 || array[2] != 86 || array[3] != 69)
			{
				return -1;
			}
			if (Read(12, array) != 4)
			{
				return -1;
			}
			if (array[0] != 102 || array[1] != 109 || array[2] != 116 || array[3] != 32)
			{
				return -1;
			}
			int num = 16;
			do
			{
				if (Read(num, array) != 4)
				{
					return -1;
				}
				num += 4 + BitConverter.ToInt32(array, 0);
				if (Read(num, array) != 4)
				{
					return -1;
				}
				num += 4;
			}
			while (array[0] != 100 || array[1] != 97 || array[2] != 116 || array[3] != 97);
			return num + 4;
		}
	}
	internal class VBRInfo
	{
		internal int SampleCount { get; set; }

		internal int SampleRate { get; set; }

		internal int Channels { get; set; }

		internal int VBRFrames { get; set; }

		internal int VBRBytes { get; set; }

		internal int VBRQuality { get; set; }

		internal int VBRDelay { get; set; }

		internal long VBRStreamSampleCount => VBRFrames * SampleCount;

		internal int VBRAverageBitrate => (int)((double)VBRBytes / ((double)VBRStreamSampleCount / (double)SampleRate) * 8.0);

		internal VBRInfo()
		{
		}
	}
}
