using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine.Networking;

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
			FilePathsData = new byte[337]
			{
				0, 0, 0, 17, 0, 0, 0, 78, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				103, 103, 46, 110, 101, 120, 117, 115, 46, 110,
				101, 120, 117, 115, 115, 100, 107, 64, 57, 52,
				97, 50, 52, 101, 52, 50, 55, 49, 55, 51,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 65,
				116, 116, 114, 105, 98, 117, 116, 105, 111, 110,
				65, 80, 73, 46, 99, 115, 0, 0, 0, 35,
				0, 0, 0, 73, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 103, 103, 46, 110,
				101, 120, 117, 115, 46, 110, 101, 120, 117, 115,
				115, 100, 107, 64, 57, 52, 97, 50, 52, 101,
				52, 50, 55, 49, 55, 51, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 66, 111, 117, 110, 116,
				121, 65, 80, 73, 46, 99, 115, 0, 0, 0,
				13, 0, 0, 0, 76, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 103, 103, 46,
				110, 101, 120, 117, 115, 46, 110, 101, 120, 117,
				115, 115, 100, 107, 64, 57, 52, 97, 50, 52,
				101, 52, 50, 55, 49, 55, 51, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 82, 101, 102, 101,
				114, 114, 97, 108, 115, 65, 80, 73, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 78, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 103, 103, 46, 110, 101, 120, 117, 115, 46,
				110, 101, 120, 117, 115, 115, 100, 107, 64, 57,
				52, 97, 50, 52, 101, 52, 50, 55, 49, 55,
				51, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				83, 68, 75, 73, 110, 105, 116, 105, 97, 108,
				105, 122, 101, 114, 46, 99, 115
			},
			TypesData = new byte[3050]
			{
				0, 0, 0, 0, 23, 78, 101, 120, 117, 115,
				83, 68, 75, 124, 65, 116, 116, 114, 105, 98,
				117, 116, 105, 111, 110, 65, 80, 73, 0, 0,
				0, 0, 28, 78, 101, 120, 117, 115, 83, 68,
				75, 46, 65, 116, 116, 114, 105, 98, 117, 116,
				105, 111, 110, 65, 80, 73, 124, 67, 111, 100,
				101, 0, 0, 0, 0, 31, 78, 101, 120, 117,
				115, 83, 68, 75, 46, 65, 116, 116, 114, 105,
				98, 117, 116, 105, 111, 110, 65, 80, 73, 124,
				77, 101, 116, 114, 105, 99, 115, 0, 0, 0,
				0, 42, 78, 101, 120, 117, 115, 83, 68, 75,
				46, 65, 116, 116, 114, 105, 98, 117, 116, 105,
				111, 110, 65, 80, 73, 43, 124, 99, 111, 110,
				118, 101, 114, 115, 105, 111, 110, 95, 83, 116,
				114, 117, 99, 116, 0, 0, 0, 0, 49, 78,
				101, 120, 117, 115, 83, 68, 75, 46, 65, 116,
				116, 114, 105, 98, 117, 116, 105, 111, 110, 65,
				80, 73, 43, 46, 124, 116, 111, 116, 97, 108,
				83, 112, 101, 110, 100, 84, 111, 68, 97, 116,
				101, 95, 83, 116, 114, 117, 99, 116, 0, 0,
				0, 0, 35, 78, 101, 120, 117, 115, 83, 68,
				75, 46, 65, 116, 116, 114, 105, 98, 117, 116,
				105, 111, 110, 65, 80, 73, 124, 84, 114, 97,
				110, 115, 97, 99, 116, 105, 111, 110, 0, 0,
				0, 0, 30, 78, 101, 120, 117, 115, 83, 68,
				75, 46, 65, 116, 116, 114, 105, 98, 117, 116,
				105, 111, 110, 65, 80, 73, 124, 77, 101, 109,
				98, 101, 114, 0, 0, 0, 0, 38, 78, 101,
				120, 117, 115, 83, 68, 75, 46, 65, 116, 116,
				114, 105, 98, 117, 116, 105, 111, 110, 65, 80,
				73, 124, 80, 108, 97, 121, 101, 114, 77, 101,
				116, 97, 100, 97, 116, 97, 0, 0, 0, 0,
				36, 78, 101, 120, 117, 115, 83, 68, 75, 46,
				65, 116, 116, 114, 105, 98, 117, 116, 105, 111,
				110, 65, 80, 73, 124, 67, 114, 101, 97, 116,
				111, 114, 71, 114, 111, 117, 112, 0, 0, 0,
				0, 41, 78, 101, 120, 117, 115, 83, 68, 75,
				46, 65, 116, 116, 114, 105, 98, 117, 116, 105,
				111, 110, 65, 80, 73, 124, 83, 99, 104, 101,
				100, 117, 108, 101, 100, 82, 101, 118, 83, 104,
				97, 114, 101, 0, 0, 0, 0, 40, 78, 101,
				120, 117, 115, 83, 68, 75, 46, 65, 116, 116,
				114, 105, 98, 117, 116, 105, 111, 110, 65, 80,
				73, 124, 67, 114, 101, 97, 116, 111, 114, 71,
				114, 111, 117, 112, 84, 105, 101, 114, 0, 0,
				0, 0, 40, 78, 101, 120, 117, 115, 83, 68,
				75, 46, 65, 116, 116, 114, 105, 98, 117, 116,
				105, 111, 110, 65, 80, 73, 124, 84, 105, 101,
				114, 82, 101, 118, 101, 110, 117, 101, 83, 104,
				97, 114, 101, 0, 0, 0, 0, 32, 78, 101,
				120, 117, 115, 83, 68, 75, 46, 65, 116, 116,
				114, 105, 98, 117, 116, 105, 111, 110, 65, 80,
				73, 124, 65, 80, 73, 69, 114, 114, 111, 114,
				0, 0, 0, 0, 47, 78, 101, 120, 117, 115,
				83, 68, 75, 46, 65, 116, 116, 114, 105, 98,
				117, 116, 105, 111, 110, 65, 80, 73, 124, 71,
				101, 116, 77, 101, 109, 98, 101, 114, 115, 82,
				101, 113, 117, 101, 115, 116, 80, 97, 114, 97,
				109, 115, 0, 0, 0, 0, 45, 78, 101, 120,
				117, 115, 83, 68, 75, 46, 65, 116, 116, 114,
				105, 98, 117, 116, 105, 111, 110, 65, 80, 73,
				124, 71, 101, 116, 77, 101, 109, 98, 101, 114,
				115, 50, 48, 48, 82, 101, 115, 112, 111, 110,
				115, 101, 0, 0, 0, 0, 58, 78, 101, 120,
				117, 115, 83, 68, 75, 46, 65, 116, 116, 114,
				105, 98, 117, 116, 105, 111, 110, 65, 80, 73,
				124, 71, 101, 116, 77, 101, 109, 98, 101, 114,
				66, 121, 67, 111, 100, 101, 79, 114, 85, 117,
				105, 100, 82, 101, 113, 117, 101, 115, 116, 80,
				97, 114, 97, 109, 115, 0, 0, 0, 0, 56,
				78, 101, 120, 117, 115, 83, 68, 75, 46, 65,
				116, 116, 114, 105, 98, 117, 116, 105, 111, 110,
				65, 80, 73, 124, 71, 101, 116, 77, 101, 109,
				98, 101, 114, 66, 121, 80, 108, 97, 121, 101,
				114, 73, 100, 82, 101, 113, 117, 101, 115, 116,
				80, 97, 114, 97, 109, 115, 0, 0, 0, 0,
				18, 78, 101, 120, 117, 115, 83, 68, 75, 124,
				66, 111, 117, 110, 116, 121, 65, 80, 73, 0,
				0, 0, 0, 25, 78, 101, 120, 117, 115, 83,
				68, 75, 46, 66, 111, 117, 110, 116, 121, 65,
				80, 73, 124, 66, 111, 117, 110, 116, 121, 0,
				0, 0, 0, 45, 78, 101, 120, 117, 115, 83,
				68, 75, 46, 66, 111, 117, 110, 116, 121, 65,
				80, 73, 43, 124, 100, 101, 112, 101, 110, 100,
				97, 110, 116, 115, 95, 83, 116, 114, 117, 99,
				116, 95, 69, 108, 101, 109, 101, 110, 116, 0,
				0, 0, 0, 48, 78, 101, 120, 117, 115, 83,
				68, 75, 46, 66, 111, 117, 110, 116, 121, 65,
				80, 73, 43, 124, 112, 114, 101, 114, 101, 113,
				117, 105, 115, 105, 116, 101, 115, 95, 83, 116,
				114, 117, 99, 116, 95, 69, 108, 101, 109, 101,
				110, 116, 0, 0, 0, 0, 28, 78, 101, 120,
				117, 115, 83, 68, 75, 46, 66, 111, 117, 110,
				116, 121, 65, 80, 73, 124, 66, 111, 117, 110,
				116, 121, 83, 107, 117, 0, 0, 0, 0, 34,
				78, 101, 120, 117, 115, 83, 68, 75, 46, 66,
				111, 117, 110, 116, 121, 65, 80, 73, 124, 66,
				111, 117, 110, 116, 121, 79, 98, 106, 101, 99,
				116, 105, 118, 101, 0, 0, 0, 0, 35, 78,
				101, 120, 117, 115, 83, 68, 75, 46, 66, 111,
				117, 110, 116, 121, 65, 80, 73, 43, 124, 99,
				97, 116, 101, 103, 111, 114, 121, 95, 83, 116,
				114, 117, 99, 116, 0, 0, 0, 0, 36, 78,
				101, 120, 117, 115, 83, 68, 75, 46, 66, 111,
				117, 110, 116, 121, 65, 80, 73, 43, 124, 112,
				117, 98, 108, 105, 115, 104, 101, 114, 95, 83,
				116, 114, 117, 99, 116, 0, 0, 0, 0, 31,
				78, 101, 120, 117, 115, 83, 68, 75, 46, 66,
				111, 117, 110, 116, 121, 65, 80, 73, 124, 66,
				111, 117, 110, 116, 121, 82, 101, 119, 97, 114,
				100, 0, 0, 0, 0, 33, 78, 101, 120, 117,
				115, 83, 68, 75, 46, 66, 111, 117, 110, 116,
				121, 65, 80, 73, 124, 66, 111, 117, 110, 116,
				121, 80, 114, 111, 103, 114, 101, 115, 115, 0,
				0, 0, 0, 54, 78, 101, 120, 117, 115, 83,
				68, 75, 46, 66, 111, 117, 110, 116, 121, 65,
				80, 73, 43, 124, 99, 111, 109, 112, 108, 101,
				116, 101, 100, 79, 98, 106, 101, 99, 116, 105,
				118, 101, 115, 95, 83, 116, 114, 117, 99, 116,
				95, 69, 108, 101, 109, 101, 110, 116, 0, 0,
				0, 0, 33, 78, 101, 120, 117, 115, 83, 68,
				75, 46, 66, 111, 117, 110, 116, 121, 65, 80,
				73, 43, 124, 109, 101, 109, 98, 101, 114, 95,
				83, 116, 114, 117, 99, 116, 0, 0, 0, 0,
				23, 78, 101, 120, 117, 115, 83, 68, 75, 46,
				66, 111, 117, 110, 116, 121, 65, 80, 73, 124,
				67, 111, 100, 101, 0, 0, 0, 0, 42, 78,
				101, 120, 117, 115, 83, 68, 75, 46, 66, 111,
				117, 110, 116, 121, 65, 80, 73, 124, 66, 111,
				117, 110, 116, 121, 79, 98, 106, 101, 99, 116,
				105, 118, 101, 80, 114, 111, 103, 114, 101, 115,
				115, 0, 0, 0, 0, 36, 78, 101, 120, 117,
				115, 83, 68, 75, 46, 66, 111, 117, 110, 116,
				121, 65, 80, 73, 43, 124, 111, 98, 106, 101,
				99, 116, 105, 118, 101, 95, 83, 116, 114, 117,
				99, 116, 0, 0, 0, 0, 39, 78, 101, 120,
				117, 115, 83, 68, 75, 46, 66, 111, 117, 110,
				116, 121, 65, 80, 73, 124, 66, 111, 117, 110,
				116, 121, 80, 114, 111, 103, 114, 101, 115, 115,
				82, 101, 119, 97, 114, 100, 0, 0, 0, 0,
				26, 78, 101, 120, 117, 115, 83, 68, 75, 46,
				66, 111, 117, 110, 116, 121, 65, 80, 73, 124,
				67, 114, 101, 97, 116, 111, 114, 0, 0, 0,
				0, 36, 78, 101, 120, 117, 115, 83, 68, 75,
				46, 66, 111, 117, 110, 116, 121, 65, 80, 73,
				124, 67, 114, 101, 97, 116, 111, 114, 71, 114,
				111, 117, 112, 69, 118, 101, 110, 116, 0, 0,
				0, 0, 30, 78, 101, 120, 117, 115, 83, 68,
				75, 46, 66, 111, 117, 110, 116, 121, 65, 80,
				73, 124, 66, 111, 117, 110, 116, 121, 69, 114,
				114, 111, 114, 0, 0, 0, 0, 43, 78, 101,
				120, 117, 115, 83, 68, 75, 46, 66, 111, 117,
				110, 116, 121, 65, 80, 73, 124, 71, 101, 116,
				66, 111, 117, 110, 116, 105, 101, 115, 82, 101,
				113, 117, 101, 115, 116, 80, 97, 114, 97, 109,
				115, 0, 0, 0, 0, 41, 78, 101, 120, 117,
				115, 83, 68, 75, 46, 66, 111, 117, 110, 116,
				121, 65, 80, 73, 124, 71, 101, 116, 66, 111,
				117, 110, 116, 105, 101, 115, 50, 48, 48, 82,
				101, 115, 112, 111, 110, 115, 101, 0, 0, 0,
				0, 47, 78, 101, 120, 117, 115, 83, 68, 75,
				46, 66, 111, 117, 110, 116, 121, 65, 80, 73,
				124, 71, 101, 116, 66, 111, 117, 110, 116, 105,
				101, 115, 82, 101, 115, 112, 111, 110, 115, 101,
				67, 97, 108, 108, 98, 97, 99, 107, 115, 0,
				0, 0, 0, 41, 78, 101, 120, 117, 115, 83,
				68, 75, 46, 66, 111, 117, 110, 116, 121, 65,
				80, 73, 124, 71, 101, 116, 66, 111, 117, 110,
				116, 121, 82, 101, 113, 117, 101, 115, 116, 80,
				97, 114, 97, 109, 115, 0, 0, 0, 0, 39,
				78, 101, 120, 117, 115, 83, 68, 75, 46, 66,
				111, 117, 110, 116, 121, 65, 80, 73, 124, 71,
				101, 116, 66, 111, 117, 110, 116, 121, 50, 48,
				48, 82, 101, 115, 112, 111, 110, 115, 101, 0,
				0, 0, 0, 35, 78, 101, 120, 117, 115, 83,
				68, 75, 46, 66, 111, 117, 110, 116, 121, 65,
				80, 73, 43, 124, 112, 114, 111, 103, 114, 101,
				115, 115, 95, 83, 116, 114, 117, 99, 116, 0,
				0, 0, 0, 40, 78, 101, 120, 117, 115, 83,
				68, 75, 46, 66, 111, 117, 110, 116, 121, 65,
				80, 73, 43, 46, 124, 100, 97, 116, 97, 95,
				83, 116, 114, 117, 99, 116, 95, 69, 108, 101,
				109, 101, 110, 116, 0, 0, 0, 0, 56, 78,
				101, 120, 117, 115, 83, 68, 75, 46, 66, 111,
				117, 110, 116, 121, 65, 80, 73, 43, 46, 46,
				124, 99, 111, 109, 112, 108, 101, 116, 101, 100,
				79, 98, 106, 101, 99, 116, 105, 118, 101, 115,
				95, 83, 116, 114, 117, 99, 116, 95, 69, 108,
				101, 109, 101, 110, 116, 0, 0, 0, 0, 35,
				78, 101, 120, 117, 115, 83, 68, 75, 46, 66,
				111, 117, 110, 116, 121, 65, 80, 73, 43, 46,
				46, 124, 109, 101, 109, 98, 101, 114, 95, 83,
				116, 114, 117, 99, 116, 0, 0, 0, 0, 45,
				78, 101, 120, 117, 115, 83, 68, 75, 46, 66,
				111, 117, 110, 116, 121, 65, 80, 73, 124, 71,
				101, 116, 66, 111, 117, 110, 116, 121, 82, 101,
				115, 112, 111, 110, 115, 101, 67, 97, 108, 108,
				98, 97, 99, 107, 115, 0, 0, 0, 0, 53,
				78, 101, 120, 117, 115, 83, 68, 75, 46, 66,
				111, 117, 110, 116, 121, 65, 80, 73, 124, 71,
				101, 116, 77, 101, 109, 98, 101, 114, 66, 111,
				117, 110, 116, 105, 101, 115, 66, 121, 73, 68,
				82, 101, 113, 117, 101, 115, 116, 80, 97, 114,
				97, 109, 115, 0, 0, 0, 0, 51, 78, 101,
				120, 117, 115, 83, 68, 75, 46, 66, 111, 117,
				110, 116, 121, 65, 80, 73, 124, 71, 101, 116,
				77, 101, 109, 98, 101, 114, 66, 111, 117, 110,
				116, 105, 101, 115, 66, 121, 73, 68, 50, 48,
				48, 82, 101, 115, 112, 111, 110, 115, 101, 0,
				0, 0, 0, 43, 78, 101, 120, 117, 115, 83,
				68, 75, 46, 66, 111, 117, 110, 116, 121, 65,
				80, 73, 43, 124, 112, 114, 111, 103, 114, 101,
				115, 115, 95, 83, 116, 114, 117, 99, 116, 95,
				69, 108, 101, 109, 101, 110, 116, 0, 0, 0,
				0, 55, 78, 101, 120, 117, 115, 83, 68, 75,
				46, 66, 111, 117, 110, 116, 121, 65, 80, 73,
				43, 46, 124, 99, 111, 109, 112, 108, 101, 116,
				101, 100, 79, 98, 106, 101, 99, 116, 105, 118,
				101, 115, 95, 83, 116, 114, 117, 99, 116, 95,
				69, 108, 101, 109, 101, 110, 116, 0, 0, 0,
				0, 34, 78, 101, 120, 117, 115, 83, 68, 75,
				46, 66, 111, 117, 110, 116, 121, 65, 80, 73,
				43, 46, 124, 109, 101, 109, 98, 101, 114, 95,
				83, 116, 114, 117, 99, 116, 0, 0, 0, 0,
				57, 78, 101, 120, 117, 115, 83, 68, 75, 46,
				66, 111, 117, 110, 116, 121, 65, 80, 73, 124,
				71, 101, 116, 77, 101, 109, 98, 101, 114, 66,
				111, 117, 110, 116, 105, 101, 115, 66, 121, 73,
				68, 82, 101, 115, 112, 111, 110, 115, 101, 67,
				97, 108, 108, 98, 97, 99, 107, 115, 0, 0,
				0, 0, 21, 78, 101, 120, 117, 115, 83, 68,
				75, 124, 82, 101, 102, 101, 114, 114, 97, 108,
				115, 65, 80, 73, 0, 0, 0, 0, 30, 78,
				101, 120, 117, 115, 83, 68, 75, 46, 82, 101,
				102, 101, 114, 114, 97, 108, 115, 65, 80, 73,
				124, 82, 101, 102, 101, 114, 114, 97, 108, 0,
				0, 0, 0, 35, 78, 101, 120, 117, 115, 83,
				68, 75, 46, 82, 101, 102, 101, 114, 114, 97,
				108, 115, 65, 80, 73, 124, 82, 101, 102, 101,
				114, 114, 97, 108, 69, 114, 114, 111, 114, 0,
				0, 0, 0, 42, 78, 101, 120, 117, 115, 83,
				68, 75, 46, 82, 101, 102, 101, 114, 114, 97,
				108, 115, 65, 80, 73, 124, 82, 101, 102, 101,
				114, 114, 97, 108, 67, 111, 100, 101, 82, 101,
				115, 112, 111, 110, 115, 101, 0, 0, 0, 0,
				60, 78, 101, 120, 117, 115, 83, 68, 75, 46,
				82, 101, 102, 101, 114, 114, 97, 108, 115, 65,
				80, 73, 124, 71, 101, 116, 82, 101, 102, 101,
				114, 114, 97, 108, 73, 110, 102, 111, 66, 121,
				80, 108, 97, 121, 101, 114, 73, 100, 82, 101,
				113, 117, 101, 115, 116, 80, 97, 114, 97, 109,
				115, 0, 0, 0, 0, 58, 78, 101, 120, 117,
				115, 83, 68, 75, 46, 82, 101, 102, 101, 114,
				114, 97, 108, 115, 65, 80, 73, 124, 71, 101,
				116, 82, 101, 102, 101, 114, 114, 97, 108, 73,
				110, 102, 111, 66, 121, 80, 108, 97, 121, 101,
				114, 73, 100, 50, 48, 48, 82, 101, 115, 112,
				111, 110, 115, 101, 0, 0, 0, 0, 64, 78,
				101, 120, 117, 115, 83, 68, 75, 46, 82, 101,
				102, 101, 114, 114, 97, 108, 115, 65, 80, 73,
				124, 71, 101, 116, 82, 101, 102, 101, 114, 114,
				97, 108, 73, 110, 102, 111, 66, 121, 80, 108,
				97, 121, 101, 114, 73, 100, 82, 101, 115, 112,
				111, 110, 115, 101, 67, 97, 108, 108, 98, 97,
				99, 107, 115, 0, 0, 0, 0, 59, 78, 101,
				120, 117, 115, 83, 68, 75, 46, 82, 101, 102,
				101, 114, 114, 97, 108, 115, 65, 80, 73, 124,
				71, 101, 116, 80, 108, 97, 121, 101, 114, 67,
				117, 114, 114, 101, 110, 116, 82, 101, 102, 101,
				114, 114, 97, 108, 82, 101, 113, 117, 101, 115,
				116, 80, 97, 114, 97, 109, 115, 0, 0, 0,
				0, 57, 78, 101, 120, 117, 115, 83, 68, 75,
				46, 82, 101, 102, 101, 114, 114, 97, 108, 115,
				65, 80, 73, 124, 71, 101, 116, 80, 108, 97,
				121, 101, 114, 67, 117, 114, 114, 101, 110, 116,
				82, 101, 102, 101, 114, 114, 97, 108, 52, 48,
				52, 82, 101, 115, 112, 111, 110, 115, 101, 0,
				0, 0, 0, 63, 78, 101, 120, 117, 115, 83,
				68, 75, 46, 82, 101, 102, 101, 114, 114, 97,
				108, 115, 65, 80, 73, 124, 71, 101, 116, 80,
				108, 97, 121, 101, 114, 67, 117, 114, 114, 101,
				110, 116, 82, 101, 102, 101, 114, 114, 97, 108,
				82, 101, 115, 112, 111, 110, 115, 101, 67, 97,
				108, 108, 98, 97, 99, 107, 115, 0, 0, 0,
				0, 56, 78, 101, 120, 117, 115, 83, 68, 75,
				46, 82, 101, 102, 101, 114, 114, 97, 108, 115,
				65, 80, 73, 124, 71, 101, 116, 82, 101, 102,
				101, 114, 114, 97, 108, 73, 110, 102, 111, 66,
				121, 67, 111, 100, 101, 82, 101, 113, 117, 101,
				115, 116, 80, 97, 114, 97, 109, 115, 0, 0,
				0, 0, 54, 78, 101, 120, 117, 115, 83, 68,
				75, 46, 82, 101, 102, 101, 114, 114, 97, 108,
				115, 65, 80, 73, 124, 71, 101, 116, 82, 101,
				102, 101, 114, 114, 97, 108, 73, 110, 102, 111,
				66, 121, 67, 111, 100, 101, 50, 48, 48, 82,
				101, 115, 112, 111, 110, 115, 101, 0, 0, 0,
				0, 60, 78, 101, 120, 117, 115, 83, 68, 75,
				46, 82, 101, 102, 101, 114, 114, 97, 108, 115,
				65, 80, 73, 124, 71, 101, 116, 82, 101, 102,
				101, 114, 114, 97, 108, 73, 110, 102, 111, 66,
				121, 67, 111, 100, 101, 82, 101, 115, 112, 111,
				110, 115, 101, 67, 97, 108, 108, 98, 97, 99,
				107, 115, 0, 0, 0, 0, 23, 78, 101, 120,
				117, 115, 83, 68, 75, 124, 83, 68, 75, 73,
				110, 105, 116, 105, 97, 108, 105, 122, 101, 114
			},
			TotalFiles = 4,
			TotalTypes = 66,
			IsEditorOnly = false
		};
	}
}
namespace NexusSDK;

public static class AttributionAPI
{
	public struct Code
	{
		public string code { get; set; }

		public bool isPrimary { get; set; }

		public bool isGenerated { get; set; }

		public bool isManaged { get; set; }
	}

	public enum Currency
	{
		AED,
		AFN,
		ALL,
		AMD,
		ANG,
		AOA,
		ARS,
		AUD,
		AWG,
		AZN,
		BAM,
		BBD,
		BDT,
		BGN,
		BHD,
		BIF,
		BMD,
		BND,
		BOB,
		BRL,
		BSD,
		BTC,
		BTN,
		BWP,
		BYN,
		BYR,
		BZD,
		CAD,
		CDF,
		CHF,
		CLF,
		CLP,
		CNY,
		COP,
		CRC,
		CUC,
		CUP,
		CVE,
		CZK,
		DJF,
		DKK,
		DOP,
		DZD,
		EGP,
		ERN,
		ETB,
		EUR,
		FJD,
		FKP,
		GBP,
		GEL,
		GGP,
		GHS,
		GIP,
		GMD,
		GNF,
		GTQ,
		GYD,
		HKD,
		HNL,
		HRK,
		HTG,
		HUF,
		IDR,
		ILS,
		IMP,
		INR,
		IQD,
		IRR,
		ISK,
		JEP,
		JMD,
		JOD,
		JPY,
		KES,
		KGS,
		KHR,
		KMF,
		KPW,
		KRW,
		KWD,
		KYD,
		KZT,
		LAK,
		LBP,
		LKR,
		LRD,
		LSL,
		LTL,
		LVL,
		LYD,
		MAD,
		MDL,
		MGA,
		MKD,
		MMK,
		MNT,
		MOP,
		MRO,
		MUR,
		MVR,
		MWK,
		MXN,
		MYR,
		MZN,
		NAD,
		NGN,
		NIO,
		NOK,
		NPR,
		NZD,
		OMR,
		PAB,
		PEN,
		PGK,
		PHP,
		PKR,
		PLN,
		PYG,
		QAR,
		RON,
		RSD,
		RUB,
		RWF,
		SAR,
		SBD,
		SCR,
		SDG,
		SEK,
		SGD,
		SHP,
		SLL,
		SOS,
		SRD,
		STD,
		SVC,
		SYP,
		SZL,
		THB,
		TJS,
		TMT,
		TND,
		TOP,
		TRY,
		TTD,
		TWD,
		TZS,
		UAH,
		UGX,
		USD,
		UYU,
		UZS,
		VEF,
		VND,
		VUV,
		WST,
		XAF,
		XAG,
		XAU,
		XCD,
		XDR,
		XOF,
		XPF,
		YER,
		ZAR,
		ZMK,
		ZMW,
		ZWL
	}

	public struct Metrics
	{
		public struct conversion_Struct
		{
			public struct totalSpendToDate_Struct
			{
				public double total { get; set; }

				public string currency { get; set; }
			}

			public DateTime lastPurchaseDate { get; set; }

			public totalSpendToDate_Struct totalSpendToDate { get; set; }
		}

		public DateTime joinDate { get; set; }

		public conversion_Struct conversion { get; set; }
	}

	public struct Transaction
	{
		public string id { get; set; }

		public string memberId { get; set; }

		public string code { get; set; }

		public string memberPlayerId { get; set; }

		public string description { get; set; }

		public string status { get; set; }

		public double subtotal { get; set; }

		public string currency { get; set; }

		public double total { get; set; }

		public string totalCurrency { get; set; }

		public string transactionId { get; set; }

		public DateTime transactionDate { get; set; }

		public string platform { get; set; }

		public string playerId { get; set; }

		public string playerName { get; set; }

		public Metrics metrics { get; set; }

		public double memberShareAmount { get; set; }

		public double memberSharePercent { get; set; }

		public bool memberPaid { get; set; }

		public string skuId { get; set; }
	}

	public struct Member
	{
		public string id { get; set; }

		public string name { get; set; }

		public string playerId { get; set; }

		public PlayerMetadata playerMetadata { get; set; }

		public string logoImage { get; set; }

		public string profileImage { get; set; }

		public Code[] codes { get; set; }
	}

	public struct PlayerMetadata
	{
		public string displayName { get; set; }
	}

	public struct CreatorGroup
	{
		public string name { get; set; }

		public string id { get; set; }

		public bool isDefault { get; set; }
	}

	public struct ScheduledRevShare
	{
		public string id { get; set; }

		public double revShare { get; set; }

		public DateTime startDate { get; set; }

		public DateTime endDate { get; set; }

		public string groupId { get; set; }

		public string groupName { get; set; }

		public TierRevenueShare[] tierRevenueShares { get; set; }
	}

	public struct CreatorGroupTier
	{
		public string id { get; set; }

		public string name { get; set; }

		public double revShare { get; set; }

		public double memberCount { get; set; }
	}

	public struct TierRevenueShare
	{
		public double revShare { get; set; }

		public string tierId { get; set; }

		public string tierName { get; set; }
	}

	public struct APIError
	{
		public string code { get; set; }

		public string message { get; set; }
	}

	public delegate void ErrorDelegate(long ErrorCode);

	public struct GetMembersRequestParams
	{
		public int page { get; set; }

		public int pageSize { get; set; }

		public string groupId { get; set; }
	}

	public struct GetMembers200Response
	{
		public string groupId { get; set; }

		public string groupName { get; set; }

		public int currentPage { get; set; }

		public int currentPageSize { get; set; }

		public int totalCount { get; set; }

		public Member[] members { get; set; }
	}

	public delegate void OnGetMembers200ResponseDelegate(GetMembers200Response Param0);

	public struct GetMemberByCodeOrUuidRequestParams
	{
		public string memberCodeOrID { get; set; }

		public string groupId { get; set; }
	}

	public delegate void OnGetMemberByCodeOrUuid200ResponseDelegate(Member Param0);

	public struct GetMemberByPlayerIdRequestParams
	{
		public string playerId { get; set; }

		public string groupId { get; set; }
	}

	public delegate void OnGetMemberByPlayerId200ResponseDelegate(Member Param0);

	public delegate void OnGetAttributionsPing200ResponseDelegate();

	public static IEnumerator StartGetMembersRequest(GetMembersRequestParams RequestParams, OnGetMembers200ResponseDelegate ResponseCallback, ErrorDelegate ErrorCallback)
	{
		if (RequestParams.page > 9999 || RequestParams.page < 1 || RequestParams.pageSize > 100 || RequestParams.pageSize < 1)
		{
			yield break;
		}
		string text = SDKInitializer.ApiBaseUrl + "/manage/members";
		List<string> list = new List<string>();
		list.Add("page=" + RequestParams.page);
		list.Add("pageSize=" + RequestParams.pageSize);
		if (RequestParams.groupId != "")
		{
			list.Add("groupId=" + RequestParams.groupId);
		}
		text += "?";
		text += string.Join("&", list);
		using UnityWebRequest webRequest = UnityWebRequest.Get(text);
		webRequest.SetRequestHeader("x-shared-secret", SDKInitializer.ApiKey);
		yield return webRequest.SendWebRequest();
		if (webRequest.responseCode == 200)
		{
			if (ResponseCallback != null)
			{
				GetMembers200Response param = JsonConvert.DeserializeObject<GetMembers200Response>(webRequest.downloadHandler.text, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				ResponseCallback?.Invoke(param);
			}
		}
		else
		{
			ErrorCallback?.Invoke(webRequest.responseCode);
		}
	}

	public static IEnumerator StartGetMemberByCodeOrUuidRequest(GetMemberByCodeOrUuidRequestParams RequestParams, OnGetMemberByCodeOrUuid200ResponseDelegate ResponseCallback, ErrorDelegate ErrorCallback)
	{
		string text = SDKInitializer.ApiBaseUrl + "/manage/members/{memberCodeOrID}";
		text = text.Replace("{memberCodeOrID}", RequestParams.memberCodeOrID);
		List<string> list = new List<string>();
		if (RequestParams.groupId != "")
		{
			list.Add("groupId=" + RequestParams.groupId);
		}
		text += "?";
		text += string.Join("&", list);
		using UnityWebRequest webRequest = UnityWebRequest.Get(text);
		webRequest.SetRequestHeader("x-shared-secret", SDKInitializer.ApiKey);
		yield return webRequest.SendWebRequest();
		if (webRequest.responseCode == 200)
		{
			if (ResponseCallback != null)
			{
				Member param = JsonConvert.DeserializeObject<Member>(webRequest.downloadHandler.text, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				ResponseCallback?.Invoke(param);
			}
		}
		else
		{
			ErrorCallback?.Invoke(webRequest.responseCode);
		}
	}

	public static IEnumerator StartGetMemberByPlayerIdRequest(GetMemberByPlayerIdRequestParams RequestParams, OnGetMemberByPlayerId200ResponseDelegate ResponseCallback, ErrorDelegate ErrorCallback)
	{
		string text = SDKInitializer.ApiBaseUrl + "/manage/members/player/{playerId}";
		text = text.Replace("{playerId}", RequestParams.playerId);
		List<string> list = new List<string>();
		if (RequestParams.groupId != "")
		{
			list.Add("groupId=" + RequestParams.groupId);
		}
		text += "?";
		text += string.Join("&", list);
		using UnityWebRequest webRequest = UnityWebRequest.Get(text);
		webRequest.SetRequestHeader("x-shared-secret", SDKInitializer.ApiKey);
		yield return webRequest.SendWebRequest();
		if (webRequest.responseCode == 200)
		{
			if (ResponseCallback != null)
			{
				Member param = JsonConvert.DeserializeObject<Member>(webRequest.downloadHandler.text, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				ResponseCallback?.Invoke(param);
			}
		}
		else
		{
			ErrorCallback?.Invoke(webRequest.responseCode);
		}
	}

	public static IEnumerator StartGetAttributionsPingRequest(OnGetAttributionsPing200ResponseDelegate ResponseCallback, ErrorDelegate ErrorCallback)
	{
		string uri = SDKInitializer.ApiBaseUrl + "/attributions/ping";
		using UnityWebRequest webRequest = UnityWebRequest.Get(uri);
		webRequest.SetRequestHeader("x-shared-secret", SDKInitializer.ApiKey);
		yield return webRequest.SendWebRequest();
		if (webRequest.responseCode == 200)
		{
			if (ResponseCallback != null)
			{
				ResponseCallback?.Invoke();
			}
		}
		else
		{
			ErrorCallback?.Invoke(webRequest.responseCode);
		}
	}
}
public static class BountyAPI
{
	public struct Bounty
	{
		public struct dependants_Struct_Element
		{
			public string id { get; set; }

			public string name { get; set; }
		}

		public struct prerequisites_Struct_Element
		{
			public string id { get; set; }

			public string name { get; set; }
		}

		public string id { get; set; }

		public string name { get; set; }

		public string description { get; set; }

		public string imageSrc { get; set; }

		public string rewardDescription { get; set; }

		public double limit { get; set; }

		public DateTime startsAt { get; set; }

		public DateTime endsAt { get; set; }

		public DateTime lastProgressCheck { get; set; }

		public BountyObjective[] objectives { get; set; }

		public BountyReward[] rewards { get; set; }

		public dependants_Struct_Element[] dependants { get; set; }

		public prerequisites_Struct_Element[] prerequisites { get; set; }
	}

	public struct BountySku
	{
		public string id { get; set; }

		public string name { get; set; }

		public string slug { get; set; }
	}

	public struct BountyObjective
	{
		public struct category_Struct
		{
			public string id { get; set; }

			public string name { get; set; }

			public string slug { get; set; }
		}

		public struct publisher_Struct
		{
			public string id { get; set; }

			public string name { get; set; }
		}

		public string id { get; set; }

		public string name { get; set; }

		public string type { get; set; }

		public string condition { get; set; }

		public double count { get; set; }

		public string eventType { get; set; }

		public string eventCode { get; set; }

		public string nexusPurchaseObjectiveType { get; set; }

		public BountySku[] skus { get; set; }

		public category_Struct category { get; set; }

		public publisher_Struct publisher { get; set; }
	}

	public struct BountyReward
	{
		public string id { get; set; }

		public string name { get; set; }

		public string type { get; set; }

		public BountySku sku { get; set; }

		public double amount { get; set; }

		public string currency { get; set; }

		public string externalId { get; set; }
	}

	public struct BountyProgress
	{
		public struct completedObjectives_Struct_Element
		{
			public string objectiveGroupId { get; set; }

			public BountyObjectiveProgress[] objectives { get; set; }

			public BountyProgressReward[] rewards { get; set; }
		}

		public struct member_Struct
		{
			public string id { get; set; }

			public string playerId { get; set; }

			public string name { get; set; }

			public Code[] codes { get; set; }
		}

		public string id { get; set; }

		public bool completed { get; set; }

		public double completionCount { get; set; }

		public DateTime lastProgressCheck { get; set; }

		public string currentObjectiveGroupId { get; set; }

		public BountyObjectiveProgress[] currentObjectives { get; set; }

		public completedObjectives_Struct_Element[] completedObjectives { get; set; }

		public member_Struct member { get; set; }
	}

	public struct Code
	{
		public string code { get; set; }

		public bool isPrimary { get; set; }

		public bool isGenerated { get; set; }

		public bool isManaged { get; set; }
	}

	public struct BountyObjectiveProgress
	{
		public struct objective_Struct
		{
			public string id { get; set; }

			public string name { get; set; }

			public double count { get; set; }

			public string condition { get; set; }
		}

		public string id { get; set; }

		public bool completed { get; set; }

		public double count { get; set; }

		public objective_Struct objective { get; set; }
	}

	public struct BountyProgressReward
	{
		public string id { get; set; }

		public string name { get; set; }

		public string externalId { get; set; }

		public bool rewardCompleted { get; set; }

		public string rewardReferenceId { get; set; }
	}

	public struct Creator
	{
		public string id { get; set; }

		public string playerId { get; set; }

		public string name { get; set; }

		public string[] slugs { get; set; }
	}

	public struct CreatorGroupEvent
	{
		public string eventCode { get; set; }

		public string playerId { get; set; }

		public string referralCode { get; set; }
	}

	public enum Currency
	{
		AED,
		AFN,
		ALL,
		AMD,
		ANG,
		AOA,
		ARS,
		AUD,
		AWG,
		AZN,
		BAM,
		BBD,
		BDT,
		BGN,
		BHD,
		BIF,
		BMD,
		BND,
		BOB,
		BRL,
		BSD,
		BTC,
		BTN,
		BWP,
		BYN,
		BYR,
		BZD,
		CAD,
		CDF,
		CHF,
		CLF,
		CLP,
		CNY,
		COP,
		CRC,
		CUC,
		CUP,
		CVE,
		CZK,
		DJF,
		DKK,
		DOP,
		DZD,
		EGP,
		ERN,
		ETB,
		EUR,
		FJD,
		FKP,
		GBP,
		GEL,
		GGP,
		GHS,
		GIP,
		GMD,
		GNF,
		GTQ,
		GYD,
		HKD,
		HNL,
		HRK,
		HTG,
		HUF,
		IDR,
		ILS,
		IMP,
		INR,
		IQD,
		IRR,
		ISK,
		JEP,
		JMD,
		JOD,
		JPY,
		KES,
		KGS,
		KHR,
		KMF,
		KPW,
		KRW,
		KWD,
		KYD,
		KZT,
		LAK,
		LBP,
		LKR,
		LRD,
		LSL,
		LTL,
		LVL,
		LYD,
		MAD,
		MDL,
		MGA,
		MKD,
		MMK,
		MNT,
		MOP,
		MRO,
		MUR,
		MVR,
		MWK,
		MXN,
		MYR,
		MZN,
		NAD,
		NGN,
		NIO,
		NOK,
		NPR,
		NZD,
		OMR,
		PAB,
		PEN,
		PGK,
		PHP,
		PKR,
		PLN,
		PYG,
		QAR,
		RON,
		RSD,
		RUB,
		RWF,
		SAR,
		SBD,
		SCR,
		SDG,
		SEK,
		SGD,
		SHP,
		SLL,
		SOS,
		SRD,
		STD,
		SVC,
		SYP,
		SZL,
		THB,
		TJS,
		TMT,
		TND,
		TOP,
		TRY,
		TTD,
		TWD,
		TZS,
		UAH,
		UGX,
		USD,
		UYU,
		UZS,
		VEF,
		VND,
		VUV,
		WST,
		XAF,
		XAG,
		XAU,
		XCD,
		XDR,
		XOF,
		XPF,
		YER,
		ZAR,
		ZMK,
		ZMW,
		ZWL
	}

	public struct BountyError
	{
		public string code { get; set; }

		public string message { get; set; }
	}

	public delegate void ErrorDelegate(long ErrorCode);

	public struct GetBountiesRequestParams
	{
		public string groupId { get; set; }

		public int page { get; set; }

		public int pageSize { get; set; }
	}

	public struct GetBounties200Response
	{
		public string groupId { get; set; }

		public string groupName { get; set; }

		public int currentPage { get; set; }

		public int currentPageSize { get; set; }

		public int totalCount { get; set; }

		public Bounty[] bounties { get; set; }
	}

	public delegate void OnGetBounties200ResponseDelegate(GetBounties200Response Param0);

	public delegate void OnGetBounties400ResponseDelegate(BountyError Param0);

	public struct GetBountiesResponseCallbacks
	{
		public OnGetBounties200ResponseDelegate OnGetBounties200Response { get; set; }

		public OnGetBounties400ResponseDelegate OnGetBounties400Response { get; set; }
	}

	public struct GetBountyRequestParams
	{
		public string groupId { get; set; }

		public bool includeProgress { get; set; }

		public int page { get; set; }

		public int pageSize { get; set; }

		public string bountyId { get; set; }
	}

	public struct GetBounty200Response
	{
		public struct progress_Struct
		{
			public struct data_Struct_Element
			{
				public struct completedObjectives_Struct_Element
				{
					public string objectiveGroupId { get; set; }

					public BountyObjectiveProgress[] objectives { get; set; }

					public BountyProgressReward[] rewards { get; set; }
				}

				public struct member_Struct
				{
					public string id { get; set; }

					public string playerId { get; set; }

					public string name { get; set; }

					public Code[] codes { get; set; }
				}

				public string id { get; set; }

				public bool completed { get; set; }

				public double completionCount { get; set; }

				public DateTime lastProgressCheck { get; set; }

				public string currentObjectiveGroupId { get; set; }

				public BountyObjectiveProgress[] currentObjectives { get; set; }

				public BountyProgress.completedObjectives_Struct_Element[] completedObjectives { get; set; }

				public BountyProgress.member_Struct member { get; set; }

				public Creator creator { get; set; }
			}

			public int currentPage { get; set; }

			public int currentPageSize { get; set; }

			public int totalCount { get; set; }

			public data_Struct_Element[] data { get; set; }
		}

		public string groupId { get; set; }

		public string groupName { get; set; }

		public Bounty bounty { get; set; }

		public progress_Struct progress { get; set; }
	}

	public delegate void OnGetBounty200ResponseDelegate(GetBounty200Response Param0);

	public delegate void OnGetBounty400ResponseDelegate(BountyError Param0);

	public struct GetBountyResponseCallbacks
	{
		public OnGetBounty200ResponseDelegate OnGetBounty200Response { get; set; }

		public OnGetBounty400ResponseDelegate OnGetBounty400Response { get; set; }
	}

	public struct GetMemberBountiesByIDRequestParams
	{
		public string groupId { get; set; }

		public int page { get; set; }

		public int pageSize { get; set; }

		public string memberId { get; set; }
	}

	public struct GetMemberBountiesByID200Response
	{
		public struct progress_Struct_Element
		{
			public struct completedObjectives_Struct_Element
			{
				public string objectiveGroupId { get; set; }

				public BountyObjectiveProgress[] objectives { get; set; }

				public BountyProgressReward[] rewards { get; set; }
			}

			public struct member_Struct
			{
				public string id { get; set; }

				public string playerId { get; set; }

				public string name { get; set; }

				public Code[] codes { get; set; }
			}

			public string id { get; set; }

			public bool completed { get; set; }

			public double completionCount { get; set; }

			public DateTime lastProgressCheck { get; set; }

			public string currentObjectiveGroupId { get; set; }

			public BountyObjectiveProgress[] currentObjectives { get; set; }

			public BountyProgress.completedObjectives_Struct_Element[] completedObjectives { get; set; }

			public BountyProgress.member_Struct member { get; set; }

			public string name { get; set; }

			public double limit { get; set; }
		}

		public string groupId { get; set; }

		public string groupName { get; set; }

		public int currentPage { get; set; }

		public int currentPageSize { get; set; }

		public int totalCount { get; set; }

		public string memberId { get; set; }

		public string playerId { get; set; }

		public progress_Struct_Element[] progress { get; set; }
	}

	public delegate void OnGetMemberBountiesByID200ResponseDelegate(GetMemberBountiesByID200Response Param0);

	public delegate void OnGetMemberBountiesByID400ResponseDelegate(BountyError Param0);

	public struct GetMemberBountiesByIDResponseCallbacks
	{
		public OnGetMemberBountiesByID200ResponseDelegate OnGetMemberBountiesByID200Response { get; set; }

		public OnGetMemberBountiesByID400ResponseDelegate OnGetMemberBountiesByID400Response { get; set; }
	}

	public static IEnumerator StartGetBountiesRequest(GetBountiesRequestParams RequestParams, GetBountiesResponseCallbacks ResponseCallback, ErrorDelegate ErrorCallback)
	{
		if (RequestParams.page > 9999 || RequestParams.page < 1 || RequestParams.pageSize > 100 || RequestParams.pageSize < 1)
		{
			yield break;
		}
		string text = SDKInitializer.ApiBaseUrl + "/";
		List<string> list = new List<string>();
		if (RequestParams.groupId != "")
		{
			list.Add("groupId=" + RequestParams.groupId);
		}
		list.Add("page=" + RequestParams.page);
		list.Add("pageSize=" + RequestParams.pageSize);
		text += "?";
		text += string.Join("&", list);
		using UnityWebRequest webRequest = UnityWebRequest.Get(text);
		webRequest.SetRequestHeader("x-shared-secret", SDKInitializer.ApiKey);
		yield return webRequest.SendWebRequest();
		switch (webRequest.responseCode)
		{
		case 200L:
			if (ResponseCallback.OnGetBounties200Response != null)
			{
				GetBounties200Response param = JsonConvert.DeserializeObject<GetBounties200Response>(webRequest.downloadHandler.text, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				ResponseCallback.OnGetBounties200Response(param);
			}
			break;
		case 400L:
			if (ResponseCallback.OnGetBounties400Response != null)
			{
				BountyError param2 = JsonConvert.DeserializeObject<BountyError>(webRequest.downloadHandler.text, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				ResponseCallback.OnGetBounties400Response(param2);
			}
			break;
		default:
			ErrorCallback?.Invoke(webRequest.responseCode);
			break;
		}
	}

	public static IEnumerator StartGetBountyRequest(GetBountyRequestParams RequestParams, GetBountyResponseCallbacks ResponseCallback, ErrorDelegate ErrorCallback)
	{
		if (RequestParams.page > 9999 || RequestParams.page < 1 || RequestParams.pageSize > 100 || RequestParams.pageSize < 1)
		{
			yield break;
		}
		string text = SDKInitializer.ApiBaseUrl + "/{bountyId}";
		text = text.Replace("{bountyId}", RequestParams.bountyId);
		List<string> list = new List<string>();
		if (RequestParams.groupId != "")
		{
			list.Add("groupId=" + RequestParams.groupId);
		}
		list.Add("includeProgress=" + RequestParams.includeProgress);
		list.Add("page=" + RequestParams.page);
		list.Add("pageSize=" + RequestParams.pageSize);
		text += "?";
		text += string.Join("&", list);
		using UnityWebRequest webRequest = UnityWebRequest.Get(text);
		webRequest.SetRequestHeader("x-shared-secret", SDKInitializer.ApiKey);
		yield return webRequest.SendWebRequest();
		switch (webRequest.responseCode)
		{
		case 200L:
			if (ResponseCallback.OnGetBounty200Response != null)
			{
				GetBounty200Response param = JsonConvert.DeserializeObject<GetBounty200Response>(webRequest.downloadHandler.text, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				ResponseCallback.OnGetBounty200Response(param);
			}
			break;
		case 400L:
			if (ResponseCallback.OnGetBounty400Response != null)
			{
				BountyError param2 = JsonConvert.DeserializeObject<BountyError>(webRequest.downloadHandler.text, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				ResponseCallback.OnGetBounty400Response(param2);
			}
			break;
		default:
			ErrorCallback?.Invoke(webRequest.responseCode);
			break;
		}
	}

	public static IEnumerator StartGetMemberBountiesByIDRequest(GetMemberBountiesByIDRequestParams RequestParams, GetMemberBountiesByIDResponseCallbacks ResponseCallback, ErrorDelegate ErrorCallback)
	{
		if (RequestParams.page > 9999 || RequestParams.page < 1 || RequestParams.pageSize > 100 || RequestParams.pageSize < 1)
		{
			yield break;
		}
		string text = SDKInitializer.ApiBaseUrl + "/member/id/{memberId}";
		text = text.Replace("{memberId}", RequestParams.memberId);
		List<string> list = new List<string>();
		if (RequestParams.groupId != "")
		{
			list.Add("groupId=" + RequestParams.groupId);
		}
		list.Add("page=" + RequestParams.page);
		list.Add("pageSize=" + RequestParams.pageSize);
		text += "?";
		text += string.Join("&", list);
		using UnityWebRequest webRequest = UnityWebRequest.Get(text);
		webRequest.SetRequestHeader("x-shared-secret", SDKInitializer.ApiKey);
		yield return webRequest.SendWebRequest();
		switch (webRequest.responseCode)
		{
		case 200L:
			if (ResponseCallback.OnGetMemberBountiesByID200Response != null)
			{
				GetMemberBountiesByID200Response param = JsonConvert.DeserializeObject<GetMemberBountiesByID200Response>(webRequest.downloadHandler.text, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				ResponseCallback.OnGetMemberBountiesByID200Response(param);
			}
			break;
		case 400L:
			if (ResponseCallback.OnGetMemberBountiesByID400Response != null)
			{
				BountyError param2 = JsonConvert.DeserializeObject<BountyError>(webRequest.downloadHandler.text, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				ResponseCallback.OnGetMemberBountiesByID400Response(param2);
			}
			break;
		default:
			ErrorCallback?.Invoke(webRequest.responseCode);
			break;
		}
	}
}
public static class ReferralsAPI
{
	public struct Referral
	{
		public string id { get; set; }

		public string code { get; set; }

		public string playerId { get; set; }

		public string playerName { get; set; }

		public DateTime referralDate { get; set; }
	}

	public struct ReferralError
	{
		public string code { get; set; }

		public string message { get; set; }
	}

	public struct ReferralCodeResponse
	{
		public string code { get; set; }

		public bool isPrimary { get; set; }

		public bool isGenerated { get; set; }

		public bool isManaged { get; set; }
	}

	public delegate void ErrorDelegate(long ErrorCode);

	public struct GetReferralInfoByPlayerIdRequestParams
	{
		public string playerId { get; set; }

		public string groupId { get; set; }

		public int page { get; set; }

		public int pageSize { get; set; }

		public bool excludeReferralList { get; set; }
	}

	public struct GetReferralInfoByPlayerId200Response
	{
		public string groupId { get; set; }

		public string groupName { get; set; }

		public ReferralCodeResponse[] codes { get; set; }

		public string playerId { get; set; }

		public string memberId { get; set; }

		public int currentPage { get; set; }

		public int currentPageSize { get; set; }

		public int totalCount { get; set; }

		public Referral[] referrals { get; set; }
	}

	public delegate void OnGetReferralInfoByPlayerId200ResponseDelegate(GetReferralInfoByPlayerId200Response Param0);

	public delegate void OnGetReferralInfoByPlayerId400ResponseDelegate(ReferralError Param0);

	public struct GetReferralInfoByPlayerIdResponseCallbacks
	{
		public OnGetReferralInfoByPlayerId200ResponseDelegate OnGetReferralInfoByPlayerId200Response { get; set; }

		public OnGetReferralInfoByPlayerId400ResponseDelegate OnGetReferralInfoByPlayerId400Response { get; set; }
	}

	public struct GetPlayerCurrentReferralRequestParams
	{
		public string playerId { get; set; }

		public string groupId { get; set; }
	}

	public delegate void OnGetPlayerCurrentReferral200ResponseDelegate(string Param0);

	public struct GetPlayerCurrentReferral404Response
	{
		public string code { get; set; }
	}

	public delegate void OnGetPlayerCurrentReferral404ResponseDelegate(GetPlayerCurrentReferral404Response Param0);

	public struct GetPlayerCurrentReferralResponseCallbacks
	{
		public OnGetPlayerCurrentReferral200ResponseDelegate OnGetPlayerCurrentReferral200Response { get; set; }

		public OnGetPlayerCurrentReferral404ResponseDelegate OnGetPlayerCurrentReferral404Response { get; set; }
	}

	public struct GetReferralInfoByCodeRequestParams
	{
		public string code { get; set; }

		public string groupId { get; set; }

		public int page { get; set; }

		public int pageSize { get; set; }

		public bool excludeReferralList { get; set; }
	}

	public struct GetReferralInfoByCode200Response
	{
		public string groupId { get; set; }

		public string groupName { get; set; }

		public ReferralCodeResponse[] referralCodes { get; set; }

		public string playerId { get; set; }

		public int currentPage { get; set; }

		public int currentPageSize { get; set; }

		public int totalCount { get; set; }

		public Referral[] referrals { get; set; }
	}

	public delegate void OnGetReferralInfoByCode200ResponseDelegate(GetReferralInfoByCode200Response Param0);

	public delegate void OnGetReferralInfoByCode400ResponseDelegate(ReferralError Param0);

	public struct GetReferralInfoByCodeResponseCallbacks
	{
		public OnGetReferralInfoByCode200ResponseDelegate OnGetReferralInfoByCode200Response { get; set; }

		public OnGetReferralInfoByCode400ResponseDelegate OnGetReferralInfoByCode400Response { get; set; }
	}

	public static IEnumerator StartGetReferralInfoByPlayerIdRequest(GetReferralInfoByPlayerIdRequestParams RequestParams, GetReferralInfoByPlayerIdResponseCallbacks ResponseCallback, ErrorDelegate ErrorCallback)
	{
		if (RequestParams.page > 9999 || RequestParams.page < 1 || RequestParams.pageSize > 100 || RequestParams.pageSize < 1)
		{
			yield break;
		}
		string text = SDKInitializer.ApiBaseUrl + "/player/{playerId}";
		text = text.Replace("{playerId}", RequestParams.playerId);
		List<string> list = new List<string>();
		if (RequestParams.groupId != "")
		{
			list.Add("groupId=" + RequestParams.groupId);
		}
		list.Add("page=" + RequestParams.page);
		list.Add("pageSize=" + RequestParams.pageSize);
		list.Add("excludeReferralList=" + RequestParams.excludeReferralList);
		text += "?";
		text += string.Join("&", list);
		using UnityWebRequest webRequest = UnityWebRequest.Get(text);
		webRequest.SetRequestHeader("x-shared-secret", SDKInitializer.ApiKey);
		yield return webRequest.SendWebRequest();
		switch (webRequest.responseCode)
		{
		case 200L:
			if (ResponseCallback.OnGetReferralInfoByPlayerId200Response != null)
			{
				GetReferralInfoByPlayerId200Response param = JsonConvert.DeserializeObject<GetReferralInfoByPlayerId200Response>(webRequest.downloadHandler.text, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				ResponseCallback.OnGetReferralInfoByPlayerId200Response(param);
			}
			break;
		case 400L:
			if (ResponseCallback.OnGetReferralInfoByPlayerId400Response != null)
			{
				ReferralError param2 = JsonConvert.DeserializeObject<ReferralError>(webRequest.downloadHandler.text, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				ResponseCallback.OnGetReferralInfoByPlayerId400Response(param2);
			}
			break;
		default:
			ErrorCallback?.Invoke(webRequest.responseCode);
			break;
		}
	}

	public static IEnumerator StartGetPlayerCurrentReferralRequest(GetPlayerCurrentReferralRequestParams RequestParams, GetPlayerCurrentReferralResponseCallbacks ResponseCallback, ErrorDelegate ErrorCallback)
	{
		string text = SDKInitializer.ApiBaseUrl + "/player/{playerId}/code";
		text = text.Replace("{playerId}", RequestParams.playerId);
		List<string> list = new List<string>();
		if (RequestParams.groupId != "")
		{
			list.Add("groupId=" + RequestParams.groupId);
		}
		text += "?";
		text += string.Join("&", list);
		using UnityWebRequest webRequest = UnityWebRequest.Get(text);
		webRequest.SetRequestHeader("x-shared-secret", SDKInitializer.ApiKey);
		yield return webRequest.SendWebRequest();
		switch (webRequest.responseCode)
		{
		case 200L:
			if (ResponseCallback.OnGetPlayerCurrentReferral200Response != null)
			{
				string text2 = webRequest.downloadHandler.text;
				ResponseCallback.OnGetPlayerCurrentReferral200Response(text2);
			}
			break;
		case 404L:
			if (ResponseCallback.OnGetPlayerCurrentReferral404Response != null)
			{
				GetPlayerCurrentReferral404Response param = JsonConvert.DeserializeObject<GetPlayerCurrentReferral404Response>(webRequest.downloadHandler.text, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				ResponseCallback.OnGetPlayerCurrentReferral404Response(param);
			}
			break;
		default:
			ErrorCallback?.Invoke(webRequest.responseCode);
			break;
		}
	}

	public static IEnumerator StartGetReferralInfoByCodeRequest(GetReferralInfoByCodeRequestParams RequestParams, GetReferralInfoByCodeResponseCallbacks ResponseCallback, ErrorDelegate ErrorCallback)
	{
		if (RequestParams.page > 9999 || RequestParams.page < 1 || RequestParams.pageSize > 100 || RequestParams.pageSize < 1)
		{
			yield break;
		}
		string text = SDKInitializer.ApiBaseUrl + "/code/{code}";
		text = text.Replace("{code}", RequestParams.code);
		List<string> list = new List<string>();
		if (RequestParams.groupId != "")
		{
			list.Add("groupId=" + RequestParams.groupId);
		}
		list.Add("page=" + RequestParams.page);
		list.Add("pageSize=" + RequestParams.pageSize);
		list.Add("excludeReferralList=" + RequestParams.excludeReferralList);
		text += "?";
		text += string.Join("&", list);
		using UnityWebRequest webRequest = UnityWebRequest.Get(text);
		webRequest.SetRequestHeader("x-shared-secret", SDKInitializer.ApiKey);
		yield return webRequest.SendWebRequest();
		switch (webRequest.responseCode)
		{
		case 200L:
			if (ResponseCallback.OnGetReferralInfoByCode200Response != null)
			{
				GetReferralInfoByCode200Response param = JsonConvert.DeserializeObject<GetReferralInfoByCode200Response>(webRequest.downloadHandler.text, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				ResponseCallback.OnGetReferralInfoByCode200Response(param);
			}
			break;
		case 400L:
			if (ResponseCallback.OnGetReferralInfoByCode400Response != null)
			{
				ReferralError param2 = JsonConvert.DeserializeObject<ReferralError>(webRequest.downloadHandler.text, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				ResponseCallback.OnGetReferralInfoByCode400Response(param2);
			}
			break;
		default:
			ErrorCallback?.Invoke(webRequest.responseCode);
			break;
		}
	}
}
public static class SDKInitializer
{
	public static string ApiKey { get; private set; }

	public static string ApiBaseUrl { get; private set; }

	public static void Init(string apiKey, string environment = "sandbox")
	{
		if (string.IsNullOrEmpty(apiKey))
		{
			throw new ArgumentException("API Key cannot be null or empty", "apiKey");
		}
		ApiKey = apiKey;
		if (string.Equals(environment, "production", StringComparison.OrdinalIgnoreCase))
		{
			ApiBaseUrl = "https://api.nexus.gg/v1";
		}
		else
		{
			ApiBaseUrl = "https://api.nexus-dev.gg/v1";
		}
	}
}
