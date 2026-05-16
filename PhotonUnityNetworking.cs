using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

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
			FilePathsData = new byte[1175]
			{
				0, 0, 0, 1, 0, 0, 0, 56, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 85,
				110, 105, 116, 121, 78, 101, 116, 119, 111, 114,
				107, 105, 110, 103, 92, 67, 111, 100, 101, 92,
				67, 117, 115, 116, 111, 109, 84, 121, 112, 101,
				115, 46, 99, 115, 0, 0, 0, 4, 0, 0,
				0, 76, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 85, 110, 105, 116, 121, 78, 101,
				116, 119, 111, 114, 107, 105, 110, 103, 92, 67,
				111, 100, 101, 92, 73, 110, 116, 101, 114, 102,
				97, 99, 101, 115, 92, 73, 80, 104, 111, 116,
				111, 110, 86, 105, 101, 119, 67, 97, 108, 108,
				98, 97, 99, 107, 115, 46, 99, 115, 0, 0,
				0, 5, 0, 0, 0, 69, 92, 65, 115, 115,
				101, 116, 115, 92, 80, 104, 111, 116, 111, 110,
				92, 80, 104, 111, 116, 111, 110, 85, 110, 105,
				116, 121, 78, 101, 116, 119, 111, 114, 107, 105,
				110, 103, 92, 67, 111, 100, 101, 92, 73, 110,
				116, 101, 114, 102, 97, 99, 101, 115, 92, 73,
				80, 117, 110, 67, 97, 108, 108, 98, 97, 99,
				107, 115, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 58, 92, 65, 115, 115, 101, 116, 115,
				92, 80, 104, 111, 116, 111, 110, 92, 80, 104,
				111, 116, 111, 110, 85, 110, 105, 116, 121, 78,
				101, 116, 119, 111, 114, 107, 105, 110, 103, 92,
				67, 111, 100, 101, 92, 80, 104, 111, 116, 111,
				110, 72, 97, 110, 100, 108, 101, 114, 46, 99,
				115, 0, 0, 0, 2, 0, 0, 0, 58, 92,
				65, 115, 115, 101, 116, 115, 92, 80, 104, 111,
				116, 111, 110, 92, 80, 104, 111, 116, 111, 110,
				85, 110, 105, 116, 121, 78, 101, 116, 119, 111,
				114, 107, 105, 110, 103, 92, 67, 111, 100, 101,
				92, 80, 104, 111, 116, 111, 110, 78, 101, 116,
				119, 111, 114, 107, 46, 99, 115, 0, 0, 0,
				3, 0, 0, 0, 62, 92, 65, 115, 115, 101,
				116, 115, 92, 80, 104, 111, 116, 111, 110, 92,
				80, 104, 111, 116, 111, 110, 85, 110, 105, 116,
				121, 78, 101, 116, 119, 111, 114, 107, 105, 110,
				103, 92, 67, 111, 100, 101, 92, 80, 104, 111,
				116, 111, 110, 78, 101, 116, 119, 111, 114, 107,
				80, 97, 114, 116, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 62, 92, 65, 115, 115, 101,
				116, 115, 92, 80, 104, 111, 116, 111, 110, 92,
				80, 104, 111, 116, 111, 110, 85, 110, 105, 116,
				121, 78, 101, 116, 119, 111, 114, 107, 105, 110,
				103, 92, 67, 111, 100, 101, 92, 80, 104, 111,
				116, 111, 110, 83, 116, 114, 101, 97, 109, 81,
				117, 101, 117, 101, 46, 99, 115, 0, 0, 0,
				2, 0, 0, 0, 55, 92, 65, 115, 115, 101,
				116, 115, 92, 80, 104, 111, 116, 111, 110, 92,
				80, 104, 111, 116, 111, 110, 85, 110, 105, 116,
				121, 78, 101, 116, 119, 111, 114, 107, 105, 110,
				103, 92, 67, 111, 100, 101, 92, 80, 104, 111,
				116, 111, 110, 86, 105, 101, 119, 46, 99, 115,
				0, 0, 0, 9, 0, 0, 0, 55, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 85,
				110, 105, 116, 121, 78, 101, 116, 119, 111, 114,
				107, 105, 110, 103, 92, 67, 111, 100, 101, 92,
				80, 117, 110, 67, 108, 97, 115, 115, 101, 115,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				59, 92, 65, 115, 115, 101, 116, 115, 92, 80,
				104, 111, 116, 111, 110, 92, 80, 104, 111, 116,
				111, 110, 85, 110, 105, 116, 121, 78, 101, 116,
				119, 111, 114, 107, 105, 110, 103, 92, 67, 111,
				100, 101, 92, 83, 101, 114, 118, 101, 114, 83,
				101, 116, 116, 105, 110, 103, 115, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 79, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 85,
				110, 105, 116, 121, 78, 101, 116, 119, 111, 114,
				107, 105, 110, 103, 92, 67, 111, 100, 101, 92,
				85, 116, 105, 108, 105, 116, 105, 101, 115, 92,
				78, 101, 115, 116, 101, 100, 67, 111, 109, 112,
				111, 110, 101, 110, 116, 85, 116, 105, 108, 105,
				116, 105, 101, 115, 46, 99, 115, 0, 0, 0,
				3, 0, 0, 0, 69, 92, 65, 115, 115, 101,
				116, 115, 92, 80, 104, 111, 116, 111, 110, 92,
				80, 104, 111, 116, 111, 110, 85, 110, 105, 116,
				121, 78, 101, 116, 119, 111, 114, 107, 105, 110,
				103, 92, 67, 111, 100, 101, 92, 86, 105, 101,
				119, 115, 92, 80, 104, 111, 116, 111, 110, 65,
				110, 105, 109, 97, 116, 111, 114, 86, 105, 101,
				119, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 72, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 85, 110, 105, 116, 121, 78, 101,
				116, 119, 111, 114, 107, 105, 110, 103, 92, 67,
				111, 100, 101, 92, 86, 105, 101, 119, 115, 92,
				80, 104, 111, 116, 111, 110, 82, 105, 103, 105,
				100, 98, 111, 100, 121, 50, 68, 86, 105, 101,
				119, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 70, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 85, 110, 105, 116, 121, 78, 101,
				116, 119, 111, 114, 107, 105, 110, 103, 92, 67,
				111, 100, 101, 92, 86, 105, 101, 119, 115, 92,
				80, 104, 111, 116, 111, 110, 82, 105, 103, 105,
				100, 98, 111, 100, 121, 86, 105, 101, 119, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 70,
				92, 65, 115, 115, 101, 116, 115, 92, 80, 104,
				111, 116, 111, 110, 92, 80, 104, 111, 116, 111,
				110, 85, 110, 105, 116, 121, 78, 101, 116, 119,
				111, 114, 107, 105, 110, 103, 92, 67, 111, 100,
				101, 92, 86, 105, 101, 119, 115, 92, 80, 104,
				111, 116, 111, 110, 84, 114, 97, 110, 115, 102,
				111, 114, 109, 86, 105, 101, 119, 46, 99, 115,
				0, 0, 0, 7, 0, 0, 0, 77, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 85,
				110, 105, 116, 121, 78, 101, 116, 119, 111, 114,
				107, 105, 110, 103, 92, 67, 111, 100, 101, 92,
				86, 105, 101, 119, 115, 92, 80, 104, 111, 116,
				111, 110, 84, 114, 97, 110, 115, 102, 111, 114,
				109, 86, 105, 101, 119, 67, 108, 97, 115, 115,
				105, 99, 46, 99, 115
			},
			TypesData = new byte[1609]
			{
				0, 0, 0, 0, 22, 80, 104, 111, 116, 111,
				110, 46, 80, 117, 110, 124, 67, 117, 115, 116,
				111, 109, 84, 121, 112, 101, 115, 0, 0, 0,
				0, 30, 80, 104, 111, 116, 111, 110, 46, 80,
				117, 110, 124, 73, 80, 104, 111, 116, 111, 110,
				86, 105, 101, 119, 67, 97, 108, 108, 98, 97,
				99, 107, 0, 0, 0, 0, 37, 80, 104, 111,
				116, 111, 110, 46, 80, 117, 110, 124, 73, 79,
				110, 80, 104, 111, 116, 111, 110, 86, 105, 101,
				119, 80, 114, 101, 78, 101, 116, 68, 101, 115,
				116, 114, 111, 121, 0, 0, 0, 0, 35, 80,
				104, 111, 116, 111, 110, 46, 80, 117, 110, 124,
				73, 79, 110, 80, 104, 111, 116, 111, 110, 86,
				105, 101, 119, 79, 119, 110, 101, 114, 67, 104,
				97, 110, 103, 101, 0, 0, 0, 0, 40, 80,
				104, 111, 116, 111, 110, 46, 80, 117, 110, 124,
				73, 79, 110, 80, 104, 111, 116, 111, 110, 86,
				105, 101, 119, 67, 111, 110, 116, 114, 111, 108,
				108, 101, 114, 67, 104, 97, 110, 103, 101, 0,
				0, 0, 0, 25, 80, 104, 111, 116, 111, 110,
				46, 80, 117, 110, 124, 73, 80, 117, 110, 79,
				98, 115, 101, 114, 118, 97, 98, 108, 101, 0,
				0, 0, 0, 33, 80, 104, 111, 116, 111, 110,
				46, 80, 117, 110, 124, 73, 80, 117, 110, 79,
				119, 110, 101, 114, 115, 104, 105, 112, 67, 97,
				108, 108, 98, 97, 99, 107, 115, 0, 0, 0,
				0, 39, 80, 104, 111, 116, 111, 110, 46, 80,
				117, 110, 124, 73, 80, 117, 110, 73, 110, 115,
				116, 97, 110, 116, 105, 97, 116, 101, 77, 97,
				103, 105, 99, 67, 97, 108, 108, 98, 97, 99,
				107, 0, 0, 0, 0, 25, 80, 104, 111, 116,
				111, 110, 46, 80, 117, 110, 124, 73, 80, 117,
				110, 80, 114, 101, 102, 97, 98, 80, 111, 111,
				108, 0, 0, 0, 0, 31, 80, 104, 111, 116,
				111, 110, 46, 80, 117, 110, 124, 73, 80, 117,
				110, 80, 114, 101, 102, 97, 98, 80, 111, 111,
				108, 86, 101, 114, 105, 102, 121, 0, 0, 0,
				0, 24, 80, 104, 111, 116, 111, 110, 46, 80,
				117, 110, 124, 80, 104, 111, 116, 111, 110, 72,
				97, 110, 100, 108, 101, 114, 0, 0, 0, 0,
				32, 80, 104, 111, 116, 111, 110, 46, 80, 117,
				110, 124, 73, 110, 115, 116, 97, 110, 116, 105,
				97, 116, 101, 80, 97, 114, 97, 109, 101, 116,
				101, 114, 115, 1, 0, 0, 0, 24, 80, 104,
				111, 116, 111, 110, 46, 80, 117, 110, 124, 80,
				104, 111, 116, 111, 110, 78, 101, 116, 119, 111,
				114, 107, 1, 0, 0, 0, 24, 80, 104, 111,
				116, 111, 110, 46, 80, 117, 110, 124, 80, 104,
				111, 116, 111, 110, 78, 101, 116, 119, 111, 114,
				107, 0, 0, 0, 0, 40, 80, 104, 111, 116,
				111, 110, 46, 80, 117, 110, 46, 80, 104, 111,
				116, 111, 110, 78, 101, 116, 119, 111, 114, 107,
				124, 82, 97, 105, 115, 101, 69, 118, 101, 110,
				116, 66, 97, 116, 99, 104, 0, 0, 0, 0,
				43, 80, 104, 111, 116, 111, 110, 46, 80, 117,
				110, 46, 80, 104, 111, 116, 111, 110, 78, 101,
				116, 119, 111, 114, 107, 124, 83, 101, 114, 105,
				97, 108, 105, 122, 101, 86, 105, 101, 119, 66,
				97, 116, 99, 104, 0, 0, 0, 0, 28, 80,
				104, 111, 116, 111, 110, 46, 80, 117, 110, 124,
				80, 104, 111, 116, 111, 110, 83, 116, 114, 101,
				97, 109, 81, 117, 101, 117, 101, 0, 0, 0,
				0, 21, 80, 104, 111, 116, 111, 110, 46, 80,
				117, 110, 124, 80, 104, 111, 116, 111, 110, 86,
				105, 101, 119, 0, 0, 0, 0, 42, 80, 104,
				111, 116, 111, 110, 46, 80, 117, 110, 46, 80,
				104, 111, 116, 111, 110, 86, 105, 101, 119, 124,
				67, 97, 108, 108, 98, 97, 99, 107, 84, 97,
				114, 103, 101, 116, 67, 104, 97, 110, 103, 101,
				0, 0, 0, 0, 17, 80, 104, 111, 116, 111,
				110, 46, 80, 117, 110, 124, 80, 117, 110, 82,
				80, 67, 0, 0, 0, 0, 27, 80, 104, 111,
				116, 111, 110, 46, 80, 117, 110, 124, 77, 111,
				110, 111, 66, 101, 104, 97, 118, 105, 111, 117,
				114, 80, 117, 110, 0, 0, 0, 0, 36, 80,
				104, 111, 116, 111, 110, 46, 80, 117, 110, 124,
				77, 111, 110, 111, 66, 101, 104, 97, 118, 105,
				111, 117, 114, 80, 117, 110, 67, 97, 108, 108,
				98, 97, 99, 107, 115, 0, 0, 0, 0, 28,
				80, 104, 111, 116, 111, 110, 46, 80, 117, 110,
				124, 80, 104, 111, 116, 111, 110, 77, 101, 115,
				115, 97, 103, 101, 73, 110, 102, 111, 0, 0,
				0, 0, 19, 80, 104, 111, 116, 111, 110, 46,
				80, 117, 110, 124, 80, 117, 110, 69, 118, 101,
				110, 116, 0, 0, 0, 0, 23, 80, 104, 111,
				116, 111, 110, 46, 80, 117, 110, 124, 80, 104,
				111, 116, 111, 110, 83, 116, 114, 101, 97, 109,
				0, 0, 0, 0, 29, 80, 104, 111, 116, 111,
				110, 46, 80, 117, 110, 124, 83, 99, 101, 110,
				101, 77, 97, 110, 97, 103, 101, 114, 72, 101,
				108, 112, 101, 114, 0, 0, 0, 0, 22, 80,
				104, 111, 116, 111, 110, 46, 80, 117, 110, 124,
				68, 101, 102, 97, 117, 108, 116, 80, 111, 111,
				108, 0, 0, 0, 0, 24, 80, 104, 111, 116,
				111, 110, 46, 80, 117, 110, 124, 80, 117, 110,
				69, 120, 116, 101, 110, 115, 105, 111, 110, 115,
				0, 0, 0, 0, 25, 80, 104, 111, 116, 111,
				110, 46, 80, 117, 110, 124, 83, 101, 114, 118,
				101, 114, 83, 101, 116, 116, 105, 110, 103, 115,
				0, 0, 0, 0, 35, 80, 104, 111, 116, 111,
				110, 46, 80, 117, 110, 124, 78, 101, 115, 116,
				101, 100, 67, 111, 109, 112, 111, 110, 101, 110,
				116, 85, 116, 105, 108, 105, 116, 105, 101, 115,
				0, 0, 0, 0, 29, 80, 104, 111, 116, 111,
				110, 46, 80, 117, 110, 124, 80, 104, 111, 116,
				111, 110, 65, 110, 105, 109, 97, 116, 111, 114,
				86, 105, 101, 119, 0, 0, 0, 0, 51, 80,
				104, 111, 116, 111, 110, 46, 80, 117, 110, 46,
				80, 104, 111, 116, 111, 110, 65, 110, 105, 109,
				97, 116, 111, 114, 86, 105, 101, 119, 124, 83,
				121, 110, 99, 104, 114, 111, 110, 105, 122, 101,
				100, 80, 97, 114, 97, 109, 101, 116, 101, 114,
				0, 0, 0, 0, 47, 80, 104, 111, 116, 111,
				110, 46, 80, 117, 110, 46, 80, 104, 111, 116,
				111, 110, 65, 110, 105, 109, 97, 116, 111, 114,
				86, 105, 101, 119, 124, 83, 121, 110, 99, 104,
				114, 111, 110, 105, 122, 101, 100, 76, 97, 121,
				101, 114, 0, 0, 0, 0, 32, 80, 104, 111,
				116, 111, 110, 46, 80, 117, 110, 124, 80, 104,
				111, 116, 111, 110, 82, 105, 103, 105, 100, 98,
				111, 100, 121, 50, 68, 86, 105, 101, 119, 0,
				0, 0, 0, 30, 80, 104, 111, 116, 111, 110,
				46, 80, 117, 110, 124, 80, 104, 111, 116, 111,
				110, 82, 105, 103, 105, 100, 98, 111, 100, 121,
				86, 105, 101, 119, 0, 0, 0, 0, 30, 80,
				104, 111, 116, 111, 110, 46, 80, 117, 110, 124,
				80, 104, 111, 116, 111, 110, 84, 114, 97, 110,
				115, 102, 111, 114, 109, 86, 105, 101, 119, 0,
				0, 0, 0, 37, 80, 104, 111, 116, 111, 110,
				46, 80, 117, 110, 124, 80, 104, 111, 116, 111,
				110, 84, 114, 97, 110, 115, 102, 111, 114, 109,
				86, 105, 101, 119, 67, 108, 97, 115, 115, 105,
				99, 0, 0, 0, 0, 43, 80, 104, 111, 116,
				111, 110, 46, 80, 117, 110, 124, 80, 104, 111,
				116, 111, 110, 84, 114, 97, 110, 115, 102, 111,
				114, 109, 86, 105, 101, 119, 80, 111, 115, 105,
				116, 105, 111, 110, 77, 111, 100, 101, 108, 0,
				0, 0, 0, 45, 80, 104, 111, 116, 111, 110,
				46, 80, 117, 110, 124, 80, 104, 111, 116, 111,
				110, 84, 114, 97, 110, 115, 102, 111, 114, 109,
				86, 105, 101, 119, 80, 111, 115, 105, 116, 105,
				111, 110, 67, 111, 110, 116, 114, 111, 108, 0,
				0, 0, 0, 43, 80, 104, 111, 116, 111, 110,
				46, 80, 117, 110, 124, 80, 104, 111, 116, 111,
				110, 84, 114, 97, 110, 115, 102, 111, 114, 109,
				86, 105, 101, 119, 82, 111, 116, 97, 116, 105,
				111, 110, 77, 111, 100, 101, 108, 0, 0, 0,
				0, 45, 80, 104, 111, 116, 111, 110, 46, 80,
				117, 110, 124, 80, 104, 111, 116, 111, 110, 84,
				114, 97, 110, 115, 102, 111, 114, 109, 86, 105,
				101, 119, 82, 111, 116, 97, 116, 105, 111, 110,
				67, 111, 110, 116, 114, 111, 108, 0, 0, 0,
				0, 40, 80, 104, 111, 116, 111, 110, 46, 80,
				117, 110, 124, 80, 104, 111, 116, 111, 110, 84,
				114, 97, 110, 115, 102, 111, 114, 109, 86, 105,
				101, 119, 83, 99, 97, 108, 101, 77, 111, 100,
				101, 108, 0, 0, 0, 0, 42, 80, 104, 111,
				116, 111, 110, 46, 80, 117, 110, 124, 80, 104,
				111, 116, 111, 110, 84, 114, 97, 110, 115, 102,
				111, 114, 109, 86, 105, 101, 119, 83, 99, 97,
				108, 101, 67, 111, 110, 116, 114, 111, 108
			},
			TotalFiles = 16,
			TotalTypes = 43,
			IsEditorOnly = false
		};
	}
}
namespace Photon.Pun;

internal static class CustomTypes
{
	public static readonly byte[] memPlayer = new byte[4];

	internal static void Register()
	{
		PhotonPeer.RegisterType(typeof(Player), 80, SerializePhotonPlayer, DeserializePhotonPlayer);
	}

	private static short SerializePhotonPlayer(StreamBuffer outStream, object customobject)
	{
		int actorNumber = ((Player)customobject).ActorNumber;
		lock (memPlayer)
		{
			byte[] array = memPlayer;
			int targetOffset = 0;
			Protocol.Serialize(actorNumber, array, ref targetOffset);
			outStream.Write(array, 0, 4);
			return 4;
		}
	}

	private static object DeserializePhotonPlayer(StreamBuffer inStream, short length)
	{
		if (length != 4)
		{
			return null;
		}
		int value;
		lock (memPlayer)
		{
			inStream.Read(memPlayer, 0, length);
			int offset = 0;
			Protocol.Deserialize(out value, memPlayer, ref offset);
		}
		if (PhotonNetwork.CurrentRoom != null)
		{
			return PhotonNetwork.CurrentRoom.GetPlayer(value);
		}
		return null;
	}
}
public enum ConnectMethod
{
	NotCalled,
	ConnectToMaster,
	ConnectToRegion,
	ConnectToBest
}
public enum PunLogLevel
{
	ErrorsOnly,
	Informational,
	Full
}
public enum RpcTarget
{
	All,
	Others,
	MasterClient,
	AllBuffered,
	OthersBuffered,
	AllViaServer,
	AllBufferedViaServer
}
public enum ViewSynchronization
{
	Off,
	ReliableDeltaCompressed,
	Unreliable,
	UnreliableOnChange
}
public enum OwnershipOption
{
	Fixed,
	Takeover,
	Request
}
public interface IPhotonViewCallback
{
}
public interface IOnPhotonViewPreNetDestroy : IPhotonViewCallback
{
	void OnPreNetDestroy(PhotonView rootView);
}
public interface IOnPhotonViewOwnerChange : IPhotonViewCallback
{
	void OnOwnerChange(Player newOwner, Player previousOwner);
}
public interface IOnPhotonViewControllerChange : IPhotonViewCallback
{
	void OnControllerChange(Player newController, Player previousController);
}
public interface IPunObservable
{
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info);
}
public interface IPunOwnershipCallbacks
{
	void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer);

	void OnOwnershipTransfered(PhotonView targetView, Player previousOwner);

	void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest);
}
public interface IPunInstantiateMagicCallback
{
	void OnPhotonInstantiate(PhotonMessageInfo info);
}
public interface IPunPrefabPool
{
	GameObject Instantiate(string prefabId, Vector3 position, Quaternion rotation);

	void Destroy(GameObject gameObject);
}
public interface IPunPrefabPoolVerify : IPunPrefabPool
{
	bool VerifyInstantiation(Player sender, string prefabId, Vector3 position, Quaternion rotation, int[] viewIds, out GameObject prefab);

	GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation);
}
public class PhotonHandler : ConnectionHandler, IInRoomCallbacks, IMatchmakingCallbacks
{
	private static PhotonHandler instance;

	public static int MaxDatagrams = 3;

	public static bool SendAsap;

	private const int SerializeRateFrameCorrection = 8;

	protected internal int UpdateInterval;

	protected internal int UpdateIntervalOnSerialize;

	private int nextSendTickCount;

	private int nextSendTickCountOnSerialize;

	private SupportLogger supportLoggerComponent;

	protected List<int> reusableIntList = new List<int>();

	internal static PhotonHandler Instance
	{
		get
		{
			if (instance == null)
			{
				instance = UnityEngine.Object.FindObjectOfType<PhotonHandler>();
				if (instance == null)
				{
					instance = new GameObject
					{
						name = "PhotonMono"
					}.AddComponent<PhotonHandler>();
				}
			}
			return instance;
		}
	}

	protected override void Awake()
	{
		if (instance == null || (object)this == instance)
		{
			instance = this;
			base.Awake();
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	protected virtual void OnEnable()
	{
		if (Instance != this)
		{
			UnityEngine.Debug.LogError("PhotonHandler is a singleton but there are multiple instances. this != Instance.");
			return;
		}
		base.Client = PhotonNetwork.NetworkingClient;
		if (PhotonNetwork.PhotonServerSettings.EnableSupportLogger)
		{
			SupportLogger supportLogger = base.gameObject.GetComponent<SupportLogger>();
			if (supportLogger == null)
			{
				supportLogger = base.gameObject.AddComponent<SupportLogger>();
			}
			if (supportLoggerComponent != null && supportLogger.GetInstanceID() != supportLoggerComponent.GetInstanceID())
			{
				UnityEngine.Debug.LogWarningFormat("Cached SupportLogger component is different from the one attached to PhotonMono GameObject");
			}
			supportLoggerComponent = supportLogger;
			supportLoggerComponent.Client = PhotonNetwork.NetworkingClient;
		}
		UpdateInterval = 1000 / PhotonNetwork.SendRate;
		UpdateIntervalOnSerialize = 1000 / PhotonNetwork.SerializationRate;
		PhotonNetwork.AddCallbackTarget(this);
		StartFallbackSendAckThread();
	}

	protected void Start()
	{
		SceneManager.sceneLoaded += delegate
		{
		};
	}

	protected override void OnDisable()
	{
		PhotonNetwork.RemoveCallbackTarget(this);
		base.OnDisable();
	}

	protected void FixedUpdate()
	{
		if (Time.timeScale > PhotonNetwork.MinimalTimeScaleToDispatchInFixedUpdate)
		{
			Dispatch();
		}
	}

	protected void LateUpdate()
	{
		if (Time.timeScale <= PhotonNetwork.MinimalTimeScaleToDispatchInFixedUpdate)
		{
			Dispatch();
		}
		int num = (int)(Time.realtimeSinceStartup * 1000f);
		if (PhotonNetwork.IsMessageQueueRunning && num > nextSendTickCountOnSerialize)
		{
			PhotonNetwork.RunViewUpdate();
			nextSendTickCountOnSerialize = num + UpdateIntervalOnSerialize - 8;
			nextSendTickCount = 0;
		}
		num = (int)(Time.realtimeSinceStartup * 1000f);
		if (SendAsap || num > nextSendTickCount)
		{
			SendAsap = false;
			bool flag = true;
			int num2 = 0;
			while (PhotonNetwork.IsMessageQueueRunning && flag && num2 < MaxDatagrams)
			{
				flag = PhotonNetwork.NetworkingClient.LoadBalancingPeer.SendOutgoingCommands();
				num2++;
			}
			nextSendTickCount = num + UpdateInterval;
		}
	}

	protected void Dispatch()
	{
		if (PhotonNetwork.NetworkingClient == null)
		{
			UnityEngine.Debug.LogError("NetworkPeer broke!");
			return;
		}
		bool flag = true;
		Exception ex = null;
		int num = 0;
		while (PhotonNetwork.IsMessageQueueRunning && flag)
		{
			try
			{
				flag = PhotonNetwork.NetworkingClient.LoadBalancingPeer.DispatchIncomingCommands();
			}
			catch (Exception ex2)
			{
				num++;
				if (ex == null)
				{
					ex = ex2;
				}
			}
		}
		if (ex == null)
		{
			return;
		}
		throw new AggregateException("Caught " + num + " exception(s) in methods called by DispatchIncomingCommands(). Rethrowing first only (see above).", ex);
	}

	public void OnCreatedRoom()
	{
		PhotonNetwork.SetLevelInPropsIfSynced(SceneManagerHelper.ActiveSceneName);
	}

	public void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
	{
		PhotonNetwork.LoadLevelIfSynced();
	}

	public void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
	{
	}

	public void OnMasterClientSwitched(Player newMasterClient)
	{
		foreach (PhotonView item in PhotonNetwork.PhotonViewCollection)
		{
			if (item.IsRoomView)
			{
				item.OwnerActorNr = newMasterClient.ActorNumber;
				item.ControllerActorNr = newMasterClient.ActorNumber;
			}
		}
	}

	public void OnFriendListUpdate(List<FriendInfo> friendList)
	{
	}

	public void OnCreateRoomFailed(short returnCode, string message)
	{
	}

	public void OnJoinRoomFailed(short returnCode, string message)
	{
	}

	public void OnJoinRandomFailed(short returnCode, string message)
	{
	}

	public void OnJoinedRoom()
	{
		if (PhotonNetwork.ViewCount == 0)
		{
			return;
		}
		foreach (PhotonView item in PhotonNetwork.PhotonViewCollection)
		{
			item.RebuildControllerCache();
		}
	}

	public void OnLeftRoom()
	{
		PhotonNetwork.LocalCleanupAnythingInstantiated(destroyInstantiatedGameObjects: true);
	}

	public void OnPreLeavingRoom()
	{
	}

	public void OnPlayerEnteredRoom(Player newPlayer)
	{
	}

	public void OnPlayerLeftRoom(Player otherPlayer)
	{
		NonAllocDictionary<int, PhotonView>.ValueIterator photonViewCollection = PhotonNetwork.PhotonViewCollection;
		int actorNumber = otherPlayer.ActorNumber;
		if (otherPlayer.IsInactive)
		{
			foreach (PhotonView item in photonViewCollection)
			{
				if (item.ControllerActorNr == actorNumber)
				{
					item.ControllerActorNr = PhotonNetwork.MasterClient.ActorNumber;
				}
			}
			return;
		}
		bool autoCleanUp = PhotonNetwork.CurrentRoom.AutoCleanUp;
		foreach (PhotonView item2 in photonViewCollection)
		{
			if ((!autoCleanUp || item2.CreatorActorNr != actorNumber) && (item2.OwnerActorNr == actorNumber || item2.ControllerActorNr == actorNumber))
			{
				item2.OwnerActorNr = 0;
				item2.ControllerActorNr = PhotonNetwork.MasterClient.ActorNumber;
			}
		}
	}
}
public struct InstantiateParameters(string prefabName, Vector3 position, Quaternion rotation, byte group, object[] data, byte objLevelPrefix, int[] viewIDs, Player creator, int timestamp)
{
	public int[] viewIDs = viewIDs;

	public byte objLevelPrefix = objLevelPrefix;

	public object[] data = data;

	public byte group = group;

	public Quaternion rotation = rotation;

	public Vector3 position = position;

	public string prefabName = prefabName;

	public Player creator = creator;

	public int timestamp = timestamp;
}
public static class PhotonNetwork
{
	private struct RaiseEventBatch : IEquatable<RaiseEventBatch>
	{
		public byte Group;

		public bool Reliable;

		public override int GetHashCode()
		{
			return (Group << 1) + (Reliable ? 1 : 0);
		}

		public bool Equals(RaiseEventBatch other)
		{
			if (Reliable == other.Reliable)
			{
				return Group == other.Group;
			}
			return false;
		}
	}

	private class SerializeViewBatch : IEquatable<SerializeViewBatch>, IEquatable<RaiseEventBatch>
	{
		public readonly RaiseEventBatch Batch;

		public List<object> ObjectUpdates;

		private int defaultSize = ObjectsInOneUpdate;

		private int offset;

		public SerializeViewBatch(RaiseEventBatch batch, int offset)
		{
			Batch = batch;
			ObjectUpdates = new List<object>(defaultSize);
			this.offset = offset;
			for (int i = 0; i < offset; i++)
			{
				ObjectUpdates.Add(null);
			}
		}

		public override int GetHashCode()
		{
			return (Batch.Group << 1) + (Batch.Reliable ? 1 : 0);
		}

		public bool Equals(SerializeViewBatch other)
		{
			return Equals(other.Batch);
		}

		public bool Equals(RaiseEventBatch other)
		{
			if (Batch.Reliable == other.Reliable)
			{
				return Batch.Group == other.Group;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is SerializeViewBatch serializeViewBatch)
			{
				return Batch.Equals(serializeViewBatch.Batch);
			}
			return false;
		}

		public void Clear()
		{
			ObjectUpdates.Clear();
			for (int i = 0; i < offset; i++)
			{
				ObjectUpdates.Add(null);
			}
		}

		public void Add(List<object> viewData)
		{
			if (ObjectUpdates.Count >= ObjectUpdates.Capacity)
			{
				throw new Exception("Can't add. Size exceeded.");
			}
			ObjectUpdates.Add(viewData);
		}
	}

	public const string PunVersion = "2.40";

	private static string gameVersion;

	public static LoadBalancingClient NetworkingClient;

	public static readonly int MAX_VIEW_IDS;

	public const string ServerSettingsFileName = "PhotonServerSettings";

	private static ServerSettings photonServerSettings;

	private const string PlayerPrefsKey = "PUNCloudBestRegion";

	public static ConnectMethod ConnectMethod;

	public static PunLogLevel LogLevel;

	public static bool EnableCloseConnection;

	public static float PrecisionForVectorSynchronization;

	public static float PrecisionForQuaternionSynchronization;

	public static float PrecisionForFloatSynchronization;

	private static bool offlineMode;

	private static Room offlineModeRoom;

	private static bool automaticallySyncScene;

	private static int sendFrequency;

	private static int serializationFrequency;

	private static bool isMessageQueueRunning;

	private static double frametime;

	private static int frame;

	private static Stopwatch StartupStopwatch;

	public static float MinimalTimeScaleToDispatchInFixedUpdate;

	private static int lastUsedViewSubId;

	private static int lastUsedViewSubIdStatic;

	private static readonly HashSet<string> PrefabsWithoutMagicCallback;

	private static readonly ExitGames.Client.Photon.Hashtable SendInstantiateEvHashtable;

	private static readonly RaiseEventOptions SendInstantiateRaiseEventOptions;

	private static HashSet<byte> allowedReceivingGroups;

	private static HashSet<byte> blockedSendingGroups;

	private static HashSet<PhotonView> reusablePVHashset;

	private static NonAllocDictionary<int, PhotonView> photonViewList;

	internal static byte currentLevelPrefix;

	internal static bool loadingLevelAndPausedNetwork;

	internal const string CurrentSceneProperty = "curScn";

	internal const string CurrentScenePropertyLoadAsync = "curScnLa";

	private static IPunPrefabPool prefabPool;

	public static bool UseRpcMonoBehaviourCache;

	private static readonly Dictionary<Type, List<MethodInfo>> monoRPCMethodsCache;

	private static Dictionary<string, int> rpcShortcuts;

	public static bool RunRpcCoroutines;

	private static UnityEngine.AsyncOperation _AsyncLevelLoadingOperation;

	private static float _levelLoadingProgress;

	private static readonly Type typePunRPC;

	private static readonly Type typePhotonMessageInfo;

	private static readonly object keyByteZero;

	private static readonly object keyByteOne;

	private static readonly object keyByteTwo;

	private static readonly object keyByteThree;

	private static readonly object keyByteFour;

	private static readonly object keyByteFive;

	private static readonly object keyByteSix;

	private static readonly object keyByteSeven;

	private static readonly object keyByteEight;

	private static readonly object[] emptyObjectArray;

	private static readonly Type[] emptyTypeArray;

	internal static List<PhotonView> foundPVs;

	private static readonly ExitGames.Client.Photon.Hashtable removeFilter;

	private static readonly ExitGames.Client.Photon.Hashtable ServerCleanDestroyEvent;

	private static readonly RaiseEventOptions ServerCleanOptions;

	internal static RaiseEventOptions SendToAllOptions;

	internal static RaiseEventOptions SendToOthersOptions;

	internal static RaiseEventOptions SendToSingleOptions;

	private static readonly ExitGames.Client.Photon.Hashtable rpcFilterByViewId;

	private static readonly RaiseEventOptions OpCleanRpcBufferOptions;

	private static ExitGames.Client.Photon.Hashtable rpcEvent;

	private static RaiseEventOptions RpcOptionsToAll;

	public static int ObjectsInOneUpdate;

	private static readonly PhotonStream serializeStreamOut;

	private static readonly PhotonStream serializeStreamIn;

	private static RaiseEventOptions serializeRaiseEvOptions;

	private static readonly Dictionary<RaiseEventBatch, SerializeViewBatch> serializeViewBatches;

	private static Dictionary<int, Dictionary<int, Queue<object[]>>> cachedData;

	public const int SyncViewId = 0;

	public const int SyncCompressed = 1;

	public const int SyncNullValues = 2;

	public const int SyncFirstValue = 3;

	public static Action<EventData, Exception> InternalEventError;

	private static RegionHandler _cachedRegionHandler;

	public static string GameVersion
	{
		get
		{
			return gameVersion;
		}
		set
		{
			gameVersion = value;
			NetworkingClient.AppVersion = string.Format("{0}_{1}", value, "2.40");
		}
	}

	public static string AppVersion => NetworkingClient.AppVersion;

	public static ServerSettings PhotonServerSettings
	{
		get
		{
			if (photonServerSettings == null)
			{
				LoadOrCreateSettings();
			}
			return photonServerSettings;
		}
		private set
		{
			photonServerSettings = value;
		}
	}

	public static string ServerAddress
	{
		get
		{
			if (NetworkingClient == null)
			{
				return "<not connected>";
			}
			return NetworkingClient.CurrentServerAddress;
		}
	}

	public static string CloudRegion
	{
		get
		{
			if (NetworkingClient == null || !IsConnected || Server == ServerConnection.NameServer)
			{
				return null;
			}
			return NetworkingClient.CloudRegion;
		}
	}

	public static string CurrentCluster
	{
		get
		{
			if (NetworkingClient == null)
			{
				return null;
			}
			return NetworkingClient.CurrentCluster;
		}
	}

	public static string BestRegionSummaryInPreferences
	{
		get
		{
			return PlayerPrefs.GetString("PUNCloudBestRegion", null);
		}
		internal set
		{
			if (string.IsNullOrEmpty(value))
			{
				PlayerPrefs.DeleteKey("PUNCloudBestRegion");
			}
			else
			{
				PlayerPrefs.SetString("PUNCloudBestRegion", value.ToString());
			}
		}
	}

	public static bool IsConnected
	{
		get
		{
			if (OfflineMode)
			{
				return true;
			}
			if (NetworkingClient == null)
			{
				return false;
			}
			return NetworkingClient.IsConnected;
		}
	}

	public static bool IsConnectedAndReady
	{
		get
		{
			if (OfflineMode)
			{
				return true;
			}
			if (NetworkingClient == null)
			{
				return false;
			}
			return NetworkingClient.IsConnectedAndReady;
		}
	}

	public static ClientState NetworkClientState
	{
		get
		{
			if (OfflineMode)
			{
				if (offlineModeRoom == null)
				{
					return ClientState.ConnectedToMasterServer;
				}
				return ClientState.Joined;
			}
			if (NetworkingClient == null)
			{
				return ClientState.Disconnected;
			}
			return NetworkingClient.State;
		}
	}

	public static ServerConnection Server
	{
		get
		{
			if (OfflineMode)
			{
				if (CurrentRoom != null)
				{
					return ServerConnection.GameServer;
				}
				return ServerConnection.MasterServer;
			}
			if (NetworkingClient == null)
			{
				return ServerConnection.NameServer;
			}
			return NetworkingClient.Server;
		}
	}

	public static AuthenticationValues AuthValues
	{
		get
		{
			if (NetworkingClient == null)
			{
				return null;
			}
			return NetworkingClient.AuthValues;
		}
		set
		{
			if (NetworkingClient != null)
			{
				NetworkingClient.AuthValues = value;
			}
		}
	}

	public static TypedLobby CurrentLobby => NetworkingClient.CurrentLobby;

	public static Room CurrentRoom
	{
		get
		{
			if (offlineMode)
			{
				return offlineModeRoom;
			}
			if (NetworkingClient != null)
			{
				return NetworkingClient.CurrentRoom;
			}
			return null;
		}
	}

	public static Player LocalPlayer
	{
		get
		{
			if (NetworkingClient == null)
			{
				return null;
			}
			return NetworkingClient.LocalPlayer;
		}
	}

	public static string NickName
	{
		get
		{
			return NetworkingClient.NickName;
		}
		set
		{
			NetworkingClient.NickName = value;
		}
	}

	public static Player[] PlayerList
	{
		get
		{
			Room currentRoom = CurrentRoom;
			if (currentRoom != null)
			{
				return currentRoom.Players.Values.OrderBy((Player x) => x.ActorNumber).ToArray();
			}
			return new Player[0];
		}
	}

	public static Player[] PlayerListOthers
	{
		get
		{
			Room currentRoom = CurrentRoom;
			if (currentRoom != null)
			{
				return (from x in currentRoom.Players.Values
					orderby x.ActorNumber
					where !x.IsLocal
					select x).ToArray();
			}
			return new Player[0];
		}
	}

	public static bool OfflineMode
	{
		get
		{
			return offlineMode;
		}
		set
		{
			if (value == offlineMode)
			{
				return;
			}
			if (value && IsConnected)
			{
				UnityEngine.Debug.LogError("Can't start OFFLINE mode while connected!");
				return;
			}
			if (NetworkingClient.IsConnected)
			{
				NetworkingClient.Disconnect();
			}
			offlineMode = value;
			if (offlineMode)
			{
				NetworkingClient.ChangeLocalID(-1);
				NetworkingClient.ConnectionCallbackTargets.OnConnectedToMaster();
				return;
			}
			bool num = offlineModeRoom != null;
			if (num)
			{
				LeftRoomCleanup();
			}
			offlineModeRoom = null;
			NetworkingClient.CurrentRoom = null;
			NetworkingClient.ChangeLocalID(-1);
			if (num)
			{
				NetworkingClient.MatchMakingCallbackTargets.OnLeftRoom();
			}
		}
	}

	public static bool AutomaticallySyncScene
	{
		get
		{
			return automaticallySyncScene;
		}
		set
		{
			automaticallySyncScene = value;
			if (automaticallySyncScene && CurrentRoom != null)
			{
				LoadLevelIfSynced();
			}
		}
	}

	public static bool EnableLobbyStatistics => NetworkingClient.EnableLobbyStatistics;

	public static bool InLobby => NetworkingClient.InLobby;

	public static int SendRate
	{
		get
		{
			return 1000 / sendFrequency;
		}
		set
		{
			sendFrequency = 1000 / value;
			if (PhotonHandler.Instance != null)
			{
				PhotonHandler.Instance.UpdateInterval = sendFrequency;
			}
		}
	}

	public static int SerializationRate
	{
		get
		{
			return 1000 / serializationFrequency;
		}
		set
		{
			serializationFrequency = 1000 / value;
			if (PhotonHandler.Instance != null)
			{
				PhotonHandler.Instance.UpdateIntervalOnSerialize = serializationFrequency;
			}
		}
	}

	public static bool IsMessageQueueRunning
	{
		get
		{
			return isMessageQueueRunning;
		}
		set
		{
			isMessageQueueRunning = value;
		}
	}

	public static double Time
	{
		get
		{
			if (UnityEngine.Time.frameCount == frame)
			{
				return frametime;
			}
			frametime = (double)(uint)ServerTimestamp / 1000.0;
			frame = UnityEngine.Time.frameCount;
			return frametime;
		}
	}

	public static double CurrentTime => (double)(uint)ServerTimestamp / 1000.0;

	public static int ServerTimestamp
	{
		get
		{
			if (OfflineMode)
			{
				if (StartupStopwatch != null && StartupStopwatch.IsRunning)
				{
					return (int)StartupStopwatch.ElapsedMilliseconds;
				}
				return Environment.TickCount;
			}
			return NetworkingClient.LoadBalancingPeer.ServerTimeInMilliSeconds;
		}
	}

	public static float KeepAliveInBackground
	{
		get
		{
			if (!(PhotonHandler.Instance != null))
			{
				return 60f;
			}
			return Mathf.Round((float)PhotonHandler.Instance.KeepAliveInBackground / 1000f);
		}
		set
		{
			if (PhotonHandler.Instance != null)
			{
				PhotonHandler.Instance.KeepAliveInBackground = (int)Mathf.Round(value * 1000f);
			}
		}
	}

	public static bool IsMasterClient
	{
		get
		{
			if (OfflineMode)
			{
				return true;
			}
			if (NetworkingClient.CurrentRoom != null)
			{
				return NetworkingClient.CurrentRoom.MasterClientId == LocalPlayer.ActorNumber;
			}
			return false;
		}
	}

	public static Player MasterClient
	{
		get
		{
			if (OfflineMode)
			{
				return LocalPlayer;
			}
			if (NetworkingClient == null || NetworkingClient.CurrentRoom == null)
			{
				return null;
			}
			return NetworkingClient.CurrentRoom.GetPlayer(NetworkingClient.CurrentRoom.MasterClientId);
		}
	}

	public static bool InRoom => NetworkClientState == ClientState.Joined;

	public static int CountOfPlayersOnMaster => NetworkingClient.PlayersOnMasterCount;

	public static int CountOfPlayersInRooms => NetworkingClient.PlayersInRoomsCount;

	public static int CountOfPlayers => NetworkingClient.PlayersInRoomsCount + NetworkingClient.PlayersOnMasterCount;

	public static int CountOfRooms => NetworkingClient.RoomsCount;

	public static bool NetworkStatisticsEnabled
	{
		get
		{
			return NetworkingClient.LoadBalancingPeer.TrafficStatsEnabled;
		}
		set
		{
			NetworkingClient.LoadBalancingPeer.TrafficStatsEnabled = value;
		}
	}

	public static int ResentReliableCommands => NetworkingClient.LoadBalancingPeer.ResentReliableCommands;

	public static bool CrcCheckEnabled
	{
		get
		{
			return NetworkingClient.LoadBalancingPeer.CrcEnabled;
		}
		set
		{
			if (!IsConnected)
			{
				NetworkingClient.LoadBalancingPeer.CrcEnabled = value;
			}
			else
			{
				UnityEngine.Debug.Log("Can't change CrcCheckEnabled while being connected. CrcCheckEnabled stays " + NetworkingClient.LoadBalancingPeer.CrcEnabled);
			}
		}
	}

	public static int PacketLossByCrcCheck => NetworkingClient.LoadBalancingPeer.PacketLossByCrc;

	public static int MaxResendsBeforeDisconnect
	{
		get
		{
			return NetworkingClient.LoadBalancingPeer.SentCountAllowance;
		}
		set
		{
			if (value < 3)
			{
				value = 3;
			}
			if (value > 10)
			{
				value = 10;
			}
			NetworkingClient.LoadBalancingPeer.SentCountAllowance = value;
		}
	}

	public static int QuickResends
	{
		get
		{
			return NetworkingClient.LoadBalancingPeer.QuickResendAttempts;
		}
		set
		{
			if (value < 0)
			{
				value = 0;
			}
			if (value > 3)
			{
				value = 3;
			}
			NetworkingClient.LoadBalancingPeer.QuickResendAttempts = (byte)value;
		}
	}

	[Obsolete("Set port overrides in ServerPortOverrides. Not used anymore!")]
	public static bool UseAlternativeUdpPorts { get; set; }

	public static PhotonPortDefinition ServerPortOverrides
	{
		get
		{
			if (NetworkingClient != null)
			{
				return NetworkingClient.ServerPortOverrides;
			}
			return default(PhotonPortDefinition);
		}
		set
		{
			if (NetworkingClient != null)
			{
				NetworkingClient.ServerPortOverrides = value;
			}
		}
	}

	[Obsolete("Use PhotonViewCollection instead for an iterable collection of current photonViews.")]
	public static PhotonView[] PhotonViews
	{
		get
		{
			PhotonView[] array = new PhotonView[photonViewList.Count];
			int num = 0;
			foreach (PhotonView value in photonViewList.Values)
			{
				array[num] = value;
				num++;
			}
			return array;
		}
	}

	public static NonAllocDictionary<int, PhotonView>.ValueIterator PhotonViewCollection => photonViewList.Values;

	public static int ViewCount => photonViewList.Count;

	public static IPunPrefabPool PrefabPool
	{
		get
		{
			return prefabPool;
		}
		set
		{
			if (value == null)
			{
				UnityEngine.Debug.LogWarning("PhotonNetwork.PrefabPool cannot be set to null. It will default back to using the 'DefaultPool' Pool");
				prefabPool = new DefaultPool();
			}
			else
			{
				prefabPool = value;
			}
		}
	}

	public static float LevelLoadingProgress
	{
		get
		{
			if (_AsyncLevelLoadingOperation != null)
			{
				_levelLoadingProgress = _AsyncLevelLoadingOperation.progress;
			}
			else if (_levelLoadingProgress > 0f)
			{
				_levelLoadingProgress = 1f;
			}
			return _levelLoadingProgress;
		}
	}

	private static event Action<PhotonView, Player> OnOwnershipRequestEv;

	private static event Action<PhotonView, Player> OnOwnershipTransferedEv;

	private static event Action<PhotonView, Player> OnOwnershipTransferFailedEv;

	static PhotonNetwork()
	{
		MAX_VIEW_IDS = 1000;
		ConnectMethod = ConnectMethod.NotCalled;
		LogLevel = PunLogLevel.ErrorsOnly;
		EnableCloseConnection = false;
		PrecisionForVectorSynchronization = 9.9E-05f;
		PrecisionForQuaternionSynchronization = 1f;
		PrecisionForFloatSynchronization = 0.01f;
		offlineMode = false;
		offlineModeRoom = null;
		automaticallySyncScene = false;
		sendFrequency = 33;
		serializationFrequency = 100;
		isMessageQueueRunning = true;
		MinimalTimeScaleToDispatchInFixedUpdate = -1f;
		lastUsedViewSubId = 0;
		lastUsedViewSubIdStatic = 0;
		PrefabsWithoutMagicCallback = new HashSet<string>();
		SendInstantiateEvHashtable = new ExitGames.Client.Photon.Hashtable();
		SendInstantiateRaiseEventOptions = new RaiseEventOptions();
		allowedReceivingGroups = new HashSet<byte>();
		blockedSendingGroups = new HashSet<byte>();
		reusablePVHashset = new HashSet<PhotonView>();
		photonViewList = new NonAllocDictionary<int, PhotonView>();
		currentLevelPrefix = 0;
		loadingLevelAndPausedNetwork = false;
		monoRPCMethodsCache = new Dictionary<Type, List<MethodInfo>>();
		RunRpcCoroutines = true;
		_levelLoadingProgress = 0f;
		typePunRPC = typeof(PunRPC);
		typePhotonMessageInfo = typeof(PhotonMessageInfo);
		keyByteZero = (byte)0;
		keyByteOne = (byte)1;
		keyByteTwo = (byte)2;
		keyByteThree = (byte)3;
		keyByteFour = (byte)4;
		keyByteFive = (byte)5;
		keyByteSix = (byte)6;
		keyByteSeven = (byte)7;
		keyByteEight = (byte)8;
		emptyObjectArray = new object[0];
		emptyTypeArray = new Type[0];
		foundPVs = new List<PhotonView>();
		removeFilter = new ExitGames.Client.Photon.Hashtable();
		ServerCleanDestroyEvent = new ExitGames.Client.Photon.Hashtable();
		ServerCleanOptions = new RaiseEventOptions
		{
			CachingOption = EventCaching.RemoveFromRoomCache
		};
		SendToAllOptions = new RaiseEventOptions
		{
			Receivers = ReceiverGroup.All
		};
		SendToOthersOptions = new RaiseEventOptions
		{
			Receivers = ReceiverGroup.Others
		};
		SendToSingleOptions = new RaiseEventOptions
		{
			TargetActors = new int[1]
		};
		rpcFilterByViewId = new ExitGames.Client.Photon.Hashtable();
		OpCleanRpcBufferOptions = new RaiseEventOptions
		{
			CachingOption = EventCaching.RemoveFromRoomCache
		};
		rpcEvent = new ExitGames.Client.Photon.Hashtable();
		RpcOptionsToAll = new RaiseEventOptions();
		ObjectsInOneUpdate = 20;
		serializeStreamOut = new PhotonStream(write: true, null);
		serializeStreamIn = new PhotonStream(write: false, null);
		serializeRaiseEvOptions = new RaiseEventOptions();
		serializeViewBatches = new Dictionary<RaiseEventBatch, SerializeViewBatch>();
		cachedData = new Dictionary<int, Dictionary<int, Queue<object[]>>>();
		StaticReset();
	}

	private static void StaticReset()
	{
		monoRPCMethodsCache.Clear();
		OfflineMode = false;
		NetworkingClient = new LoadBalancingClient(PhotonServerSettings.AppSettings.Protocol);
		NetworkingClient.LoadBalancingPeer.QuickResendAttempts = 2;
		NetworkingClient.LoadBalancingPeer.SentCountAllowance = 9;
		NetworkingClient.EventReceived -= OnEvent;
		NetworkingClient.EventReceived += OnEvent;
		NetworkingClient.OpResponseReceived -= OnOperation;
		NetworkingClient.OpResponseReceived += OnOperation;
		NetworkingClient.StateChanged -= OnClientStateChanged;
		NetworkingClient.StateChanged += OnClientStateChanged;
		StartupStopwatch = new Stopwatch();
		StartupStopwatch.Start();
		PhotonHandler.Instance.Client = NetworkingClient;
		Application.runInBackground = PhotonServerSettings.RunInBackground;
		PrefabPool = new DefaultPool();
		rpcShortcuts = new Dictionary<string, int>(PhotonServerSettings.RpcList.Count);
		for (int i = 0; i < PhotonServerSettings.RpcList.Count; i++)
		{
			string key = PhotonServerSettings.RpcList[i];
			rpcShortcuts[key] = i;
		}
		CustomTypes.Register();
	}

	public static bool ConnectUsingSettings()
	{
		if (PhotonServerSettings == null)
		{
			UnityEngine.Debug.LogError("Can't connect: Loading settings failed. ServerSettings asset must be in any 'Resources' folder as: PhotonServerSettings");
			return false;
		}
		return ConnectUsingSettings(PhotonServerSettings.AppSettings, PhotonServerSettings.StartInOfflineMode);
	}

	public static bool ConnectUsingSettings(AppSettings appSettings, bool startInOfflineMode = false)
	{
		if (NetworkingClient.LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
		{
			UnityEngine.Debug.LogWarning("ConnectUsingSettings() failed. Can only connect while in state 'Disconnected'. Current state: " + NetworkingClient.LoadBalancingPeer.PeerState);
			return false;
		}
		if (ConnectionHandler.AppQuits)
		{
			UnityEngine.Debug.LogWarning("Can't connect: Application is closing. Unity called OnApplicationQuit().");
			return false;
		}
		if (PhotonServerSettings == null)
		{
			UnityEngine.Debug.LogError("Can't connect: Loading settings failed. ServerSettings asset must be in any 'Resources' folder as: PhotonServerSettings");
			return false;
		}
		SetupLogging();
		NetworkingClient.LoadBalancingPeer.TransportProtocol = appSettings.Protocol;
		NetworkingClient.ExpectedProtocol = null;
		NetworkingClient.EnableProtocolFallback = appSettings.EnableProtocolFallback;
		NetworkingClient.AuthMode = appSettings.AuthMode;
		IsMessageQueueRunning = true;
		NetworkingClient.AppId = appSettings.AppIdRealtime;
		GameVersion = appSettings.AppVersion;
		if (startInOfflineMode)
		{
			OfflineMode = true;
			return true;
		}
		if (OfflineMode)
		{
			OfflineMode = false;
			UnityEngine.Debug.LogWarning("ConnectUsingSettings() disabled the offline mode. No longer offline.");
		}
		NetworkingClient.EnableLobbyStatistics = appSettings.EnableLobbyStatistics;
		NetworkingClient.ProxyServerAddress = appSettings.ProxyServer;
		if (appSettings.IsMasterServerAddress)
		{
			if (AuthValues == null)
			{
				AuthValues = new AuthenticationValues(Guid.NewGuid().ToString());
			}
			else if (string.IsNullOrEmpty(AuthValues.UserId))
			{
				AuthValues.UserId = Guid.NewGuid().ToString();
			}
			return ConnectToMaster(appSettings.Server, appSettings.Port, appSettings.AppIdRealtime);
		}
		NetworkingClient.NameServerPortInAppSettings = appSettings.Port;
		if (!appSettings.IsDefaultNameServer)
		{
			NetworkingClient.NameServerHost = appSettings.Server;
		}
		if (appSettings.IsBestRegion)
		{
			return ConnectToBestCloudServer();
		}
		return ConnectToRegion(appSettings.FixedRegion);
	}

	public static bool ConnectToMaster(string masterServerAddress, int port, string appID)
	{
		if (NetworkingClient.LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
		{
			UnityEngine.Debug.LogWarning("ConnectToMaster() failed. Can only connect while in state 'Disconnected'. Current state: " + NetworkingClient.LoadBalancingPeer.PeerState);
			return false;
		}
		if (ConnectionHandler.AppQuits)
		{
			UnityEngine.Debug.LogWarning("Can't connect: Application is closing. Unity called OnApplicationQuit().");
			return false;
		}
		if (OfflineMode)
		{
			OfflineMode = false;
			UnityEngine.Debug.LogWarning("ConnectToMaster() disabled the offline mode. No longer offline.");
		}
		if (!IsMessageQueueRunning)
		{
			IsMessageQueueRunning = true;
			UnityEngine.Debug.LogWarning("ConnectToMaster() enabled IsMessageQueueRunning. Needs to be able to dispatch incoming messages.");
		}
		SetupLogging();
		ConnectMethod = ConnectMethod.ConnectToMaster;
		NetworkingClient.IsUsingNameServer = false;
		NetworkingClient.MasterServerAddress = ((port == 0) ? masterServerAddress : (masterServerAddress + ":" + port));
		NetworkingClient.AppId = appID;
		return NetworkingClient.ConnectToMasterServer();
	}

	public static bool ConnectToBestCloudServer()
	{
		if (NetworkingClient.LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
		{
			UnityEngine.Debug.LogWarning("ConnectToBestCloudServer() failed. Can only connect while in state 'Disconnected'. Current state: " + NetworkingClient.LoadBalancingPeer.PeerState);
			return false;
		}
		if (ConnectionHandler.AppQuits)
		{
			UnityEngine.Debug.LogWarning("Can't connect: Application is closing. Unity called OnApplicationQuit().");
			return false;
		}
		SetupLogging();
		ConnectMethod = ConnectMethod.ConnectToBest;
		return NetworkingClient.ConnectToNameServer();
	}

	public static bool ConnectToRegion(string region)
	{
		if (NetworkingClient.LoadBalancingPeer.PeerState != PeerStateValue.Disconnected && NetworkingClient.Server != ServerConnection.NameServer)
		{
			UnityEngine.Debug.LogWarning("ConnectToRegion() failed. Can only connect while in state 'Disconnected'. Current state: " + NetworkingClient.LoadBalancingPeer.PeerState);
			return false;
		}
		if (ConnectionHandler.AppQuits)
		{
			UnityEngine.Debug.LogWarning("Can't connect: Application is closing. Unity called OnApplicationQuit().");
			return false;
		}
		SetupLogging();
		ConnectMethod = ConnectMethod.ConnectToRegion;
		if (!string.IsNullOrEmpty(region))
		{
			return NetworkingClient.ConnectToRegionMaster(region);
		}
		return false;
	}

	public static void Disconnect()
	{
		if (OfflineMode)
		{
			OfflineMode = false;
			offlineModeRoom = null;
			NetworkingClient.State = ClientState.Disconnecting;
			NetworkingClient.OnStatusChanged(StatusCode.Disconnect);
		}
		else if (NetworkingClient != null)
		{
			NetworkingClient.Disconnect();
		}
	}

	public static bool Reconnect()
	{
		if (string.IsNullOrEmpty(NetworkingClient.MasterServerAddress))
		{
			UnityEngine.Debug.LogWarning("Reconnect() failed. It seems the client wasn't connected before?! Current state: " + NetworkingClient.LoadBalancingPeer.PeerState);
			return false;
		}
		if (NetworkingClient.LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
		{
			UnityEngine.Debug.LogWarning("Reconnect() failed. Can only connect while in state 'Disconnected'. Current state: " + NetworkingClient.LoadBalancingPeer.PeerState);
			return false;
		}
		if (OfflineMode)
		{
			OfflineMode = false;
			UnityEngine.Debug.LogWarning("Reconnect() disabled the offline mode. No longer offline.");
		}
		if (!IsMessageQueueRunning)
		{
			IsMessageQueueRunning = true;
			UnityEngine.Debug.LogWarning("Reconnect() enabled IsMessageQueueRunning. Needs to be able to dispatch incoming messages.");
		}
		NetworkingClient.IsUsingNameServer = false;
		return NetworkingClient.ReconnectToMaster();
	}

	public static void NetworkStatisticsReset()
	{
		NetworkingClient.LoadBalancingPeer.TrafficStatsReset();
	}

	public static string NetworkStatisticsToString()
	{
		if (NetworkingClient == null || OfflineMode)
		{
			return "Offline or in OfflineMode. No VitalStats available.";
		}
		return NetworkingClient.LoadBalancingPeer.VitalStatsToString(all: false);
	}

	private static bool VerifyCanUseNetwork()
	{
		if (IsConnected)
		{
			return true;
		}
		UnityEngine.Debug.LogError("Cannot send messages when not connected. Either connect to Photon OR use offline mode!");
		return false;
	}

	public static int GetPing()
	{
		return NetworkingClient.LoadBalancingPeer.RoundTripTime;
	}

	public static void FetchServerTimestamp()
	{
		if (NetworkingClient != null)
		{
			NetworkingClient.LoadBalancingPeer.FetchServerTimestamp();
		}
	}

	public static void SendAllOutgoingCommands()
	{
		if (VerifyCanUseNetwork())
		{
			while (NetworkingClient.LoadBalancingPeer.SendOutgoingCommands())
			{
			}
		}
	}

	public static bool CloseConnection(Player kickPlayer)
	{
		if (!VerifyCanUseNetwork())
		{
			return false;
		}
		if (!EnableCloseConnection)
		{
			UnityEngine.Debug.LogError("CloseConnection is disabled. No need to call it.");
			return false;
		}
		if (!LocalPlayer.IsMasterClient)
		{
			UnityEngine.Debug.LogError("CloseConnection: Only the masterclient can kick another player.");
			return false;
		}
		if (kickPlayer == null)
		{
			UnityEngine.Debug.LogError("CloseConnection: No such player connected!");
			return false;
		}
		RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
		raiseEventOptions.TargetActors = new int[1] { kickPlayer.ActorNumber };
		RaiseEventOptions raiseEventOptions2 = raiseEventOptions;
		return NetworkingClient.OpRaiseEvent(203, null, raiseEventOptions2, SendOptions.SendReliable);
	}

	public static bool SetMasterClient(Player masterClientPlayer)
	{
		if (!InRoom || !VerifyCanUseNetwork() || OfflineMode)
		{
			if (LogLevel == PunLogLevel.Informational)
			{
				UnityEngine.Debug.Log("Can not SetMasterClient(). Not in room or in OfflineMode.");
			}
			return false;
		}
		return CurrentRoom.SetMasterClient(masterClientPlayer);
	}

	public static bool JoinRandomRoom()
	{
		return JoinRandomRoom(null, 0, MatchmakingMode.FillRoom, null, null);
	}

	public static bool JoinRandomRoom(ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties, byte expectedMaxPlayers)
	{
		return JoinRandomRoom(expectedCustomRoomProperties, expectedMaxPlayers, MatchmakingMode.FillRoom, null, null);
	}

	public static bool JoinRandomRoom(ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties, byte expectedMaxPlayers, MatchmakingMode matchingType, TypedLobby typedLobby, string sqlLobbyFilter, string[] expectedUsers = null)
	{
		if (OfflineMode)
		{
			if (offlineModeRoom != null)
			{
				UnityEngine.Debug.LogError("JoinRandomRoom failed. In offline mode you still have to leave a room to enter another.");
				return false;
			}
			EnterOfflineRoom("offline room", null, createdRoom: true);
			return true;
		}
		if (NetworkingClient.Server != ServerConnection.MasterServer || !IsConnectedAndReady)
		{
			UnityEngine.Debug.LogError("JoinRandomRoom failed. Client is on " + NetworkingClient.Server.ToString() + " (must be Master Server for matchmaking)" + (IsConnectedAndReady ? " and ready" : (" but not ready for operations (State: " + NetworkingClient.State.ToString() + ")")) + ". Wait for callback: OnJoinedLobby or OnConnectedToMaster.");
			return false;
		}
		typedLobby = typedLobby ?? (NetworkingClient.InLobby ? NetworkingClient.CurrentLobby : null);
		OpJoinRandomRoomParams opJoinRandomRoomParams = new OpJoinRandomRoomParams();
		opJoinRandomRoomParams.ExpectedCustomRoomProperties = expectedCustomRoomProperties;
		opJoinRandomRoomParams.ExpectedMaxPlayers = expectedMaxPlayers;
		opJoinRandomRoomParams.MatchingType = matchingType;
		opJoinRandomRoomParams.TypedLobby = typedLobby;
		opJoinRandomRoomParams.SqlLobbyFilter = sqlLobbyFilter;
		opJoinRandomRoomParams.ExpectedUsers = expectedUsers;
		return NetworkingClient.OpJoinRandomRoom(opJoinRandomRoomParams);
	}

	public static bool JoinRandomOrCreateRoom(ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = null, byte expectedMaxPlayers = 0, MatchmakingMode matchingType = MatchmakingMode.FillRoom, TypedLobby typedLobby = null, string sqlLobbyFilter = null, string roomName = null, RoomOptions roomOptions = null, string[] expectedUsers = null)
	{
		if (OfflineMode)
		{
			if (offlineModeRoom != null)
			{
				UnityEngine.Debug.LogError("JoinRandomOrCreateRoom failed. In offline mode you still have to leave a room to enter another.");
				return false;
			}
			EnterOfflineRoom("offline room", null, createdRoom: true);
			return true;
		}
		if (NetworkingClient.Server != ServerConnection.MasterServer || !IsConnectedAndReady)
		{
			UnityEngine.Debug.LogError("JoinRandomOrCreateRoom failed. Client is on " + NetworkingClient.Server.ToString() + " (must be Master Server for matchmaking)" + (IsConnectedAndReady ? " and ready" : (" but not ready for operations (State: " + NetworkingClient.State.ToString() + ")")) + ". Wait for callback: OnJoinedLobby or OnConnectedToMaster.");
			return false;
		}
		typedLobby = typedLobby ?? (NetworkingClient.InLobby ? NetworkingClient.CurrentLobby : null);
		OpJoinRandomRoomParams opJoinRandomRoomParams = new OpJoinRandomRoomParams();
		opJoinRandomRoomParams.ExpectedCustomRoomProperties = expectedCustomRoomProperties;
		opJoinRandomRoomParams.ExpectedMaxPlayers = expectedMaxPlayers;
		opJoinRandomRoomParams.MatchingType = matchingType;
		opJoinRandomRoomParams.TypedLobby = typedLobby;
		opJoinRandomRoomParams.SqlLobbyFilter = sqlLobbyFilter;
		opJoinRandomRoomParams.ExpectedUsers = expectedUsers;
		EnterRoomParams enterRoomParams = new EnterRoomParams();
		enterRoomParams.RoomName = roomName;
		enterRoomParams.RoomOptions = roomOptions;
		enterRoomParams.Lobby = typedLobby;
		enterRoomParams.ExpectedUsers = expectedUsers;
		return NetworkingClient.OpJoinRandomOrCreateRoom(opJoinRandomRoomParams, enterRoomParams);
	}

	public static bool CreateRoom(string roomName, RoomOptions roomOptions = null, TypedLobby typedLobby = null, string[] expectedUsers = null)
	{
		if (OfflineMode)
		{
			if (offlineModeRoom != null)
			{
				UnityEngine.Debug.LogError("CreateRoom failed. In offline mode you still have to leave a room to enter another.");
				return false;
			}
			EnterOfflineRoom(roomName, roomOptions, createdRoom: true);
			return true;
		}
		if (NetworkingClient.Server != ServerConnection.MasterServer || !IsConnectedAndReady)
		{
			UnityEngine.Debug.LogError("CreateRoom failed. Client is on " + NetworkingClient.Server.ToString() + " (must be Master Server for matchmaking)" + (IsConnectedAndReady ? " and ready" : ("but not ready for operations (State: " + NetworkingClient.State.ToString() + ")")) + ". Wait for callback: OnJoinedLobby or OnConnectedToMaster.");
			return false;
		}
		typedLobby = typedLobby ?? (NetworkingClient.InLobby ? NetworkingClient.CurrentLobby : null);
		EnterRoomParams enterRoomParams = new EnterRoomParams();
		enterRoomParams.RoomName = roomName;
		enterRoomParams.RoomOptions = roomOptions;
		enterRoomParams.Lobby = typedLobby;
		enterRoomParams.ExpectedUsers = expectedUsers;
		return NetworkingClient.OpCreateRoom(enterRoomParams);
	}

	public static bool JoinOrCreateRoom(string roomName, RoomOptions roomOptions, TypedLobby typedLobby, string[] expectedUsers = null)
	{
		if (OfflineMode)
		{
			if (offlineModeRoom != null)
			{
				UnityEngine.Debug.LogError("JoinOrCreateRoom failed. In offline mode you still have to leave a room to enter another.");
				return false;
			}
			EnterOfflineRoom(roomName, roomOptions, createdRoom: true);
			return true;
		}
		if (NetworkingClient.Server != ServerConnection.MasterServer || !IsConnectedAndReady)
		{
			UnityEngine.Debug.LogError("JoinOrCreateRoom failed. Client is on " + NetworkingClient.Server.ToString() + " (must be Master Server for matchmaking)" + (IsConnectedAndReady ? " and ready" : ("but not ready for operations (State: " + NetworkingClient.State.ToString() + ")")) + ". Wait for callback: OnJoinedLobby or OnConnectedToMaster.");
			return false;
		}
		if (string.IsNullOrEmpty(roomName))
		{
			UnityEngine.Debug.LogError("JoinOrCreateRoom failed. A roomname is required. If you don't know one, how will you join?");
			return false;
		}
		typedLobby = typedLobby ?? (NetworkingClient.InLobby ? NetworkingClient.CurrentLobby : null);
		EnterRoomParams enterRoomParams = new EnterRoomParams();
		enterRoomParams.RoomName = roomName;
		enterRoomParams.RoomOptions = roomOptions;
		enterRoomParams.Lobby = typedLobby;
		enterRoomParams.PlayerProperties = LocalPlayer.CustomProperties;
		enterRoomParams.ExpectedUsers = expectedUsers;
		return NetworkingClient.OpJoinOrCreateRoom(enterRoomParams);
	}

	public static bool JoinRoom(string roomName, string[] expectedUsers = null)
	{
		if (OfflineMode)
		{
			if (offlineModeRoom != null)
			{
				UnityEngine.Debug.LogError("JoinRoom failed. In offline mode you still have to leave a room to enter another.");
				return false;
			}
			EnterOfflineRoom(roomName, null, createdRoom: true);
			return true;
		}
		if (NetworkingClient.Server != ServerConnection.MasterServer || !IsConnectedAndReady)
		{
			UnityEngine.Debug.LogError("JoinRoom failed. Client is on " + NetworkingClient.Server.ToString() + " (must be Master Server for matchmaking)" + (IsConnectedAndReady ? " and ready" : ("but not ready for operations (State: " + NetworkingClient.State.ToString() + ")")) + ". Wait for callback: OnJoinedLobby or OnConnectedToMaster.");
			return false;
		}
		if (string.IsNullOrEmpty(roomName))
		{
			UnityEngine.Debug.LogError("JoinRoom failed. A roomname is required. If you don't know one, how will you join?");
			return false;
		}
		EnterRoomParams enterRoomParams = new EnterRoomParams();
		enterRoomParams.RoomName = roomName;
		enterRoomParams.ExpectedUsers = expectedUsers;
		return NetworkingClient.OpJoinRoom(enterRoomParams);
	}

	public static bool RejoinRoom(string roomName)
	{
		if (OfflineMode)
		{
			UnityEngine.Debug.LogError("RejoinRoom failed due to offline mode.");
			return false;
		}
		if (NetworkingClient.Server != ServerConnection.MasterServer || !IsConnectedAndReady)
		{
			UnityEngine.Debug.LogError("RejoinRoom failed. Client is on " + NetworkingClient.Server.ToString() + " (must be Master Server for matchmaking)" + (IsConnectedAndReady ? " and ready" : ("but not ready for operations (State: " + NetworkingClient.State.ToString() + ")")) + ". Wait for callback: OnJoinedLobby or OnConnectedToMaster.");
			return false;
		}
		if (string.IsNullOrEmpty(roomName))
		{
			UnityEngine.Debug.LogError("RejoinRoom failed. A roomname is required. If you don't know one, how will you join?");
			return false;
		}
		return NetworkingClient.OpRejoinRoom(roomName);
	}

	public static bool ReconnectAndRejoin()
	{
		if (NetworkingClient.LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
		{
			UnityEngine.Debug.LogWarning("ReconnectAndRejoin() failed. Can only connect while in state 'Disconnected'. Current state: " + NetworkingClient.LoadBalancingPeer.PeerState);
			return false;
		}
		if (OfflineMode)
		{
			OfflineMode = false;
			UnityEngine.Debug.LogWarning("ReconnectAndRejoin() disabled the offline mode. No longer offline.");
		}
		if (!IsMessageQueueRunning)
		{
			IsMessageQueueRunning = true;
			UnityEngine.Debug.LogWarning("ReconnectAndRejoin() enabled IsMessageQueueRunning. Needs to be able to dispatch incoming messages.");
		}
		return NetworkingClient.ReconnectAndRejoin();
	}

	public static bool LeaveRoom(bool becomeInactive = true)
	{
		if (OfflineMode)
		{
			offlineModeRoom = null;
			NetworkingClient.MatchMakingCallbackTargets.OnLeftRoom();
			NetworkingClient.ConnectionCallbackTargets.OnConnectedToMaster();
			return true;
		}
		if (CurrentRoom == null)
		{
			UnityEngine.Debug.LogWarning("PhotonNetwork.CurrentRoom is null. You don't have to call LeaveRoom() when you're not in one. State: " + NetworkClientState);
		}
		else
		{
			becomeInactive = becomeInactive && CurrentRoom.PlayerTtl != 0;
		}
		return NetworkingClient.OpLeaveRoom(becomeInactive);
	}

	private static void EnterOfflineRoom(string roomName, RoomOptions roomOptions, bool createdRoom)
	{
		offlineModeRoom = new Room(roomName, roomOptions, isOffline: true);
		NetworkingClient.ChangeLocalID(1);
		offlineModeRoom.masterClientId = 1;
		offlineModeRoom.AddPlayer(LocalPlayer);
		offlineModeRoom.LoadBalancingClient = NetworkingClient;
		NetworkingClient.CurrentRoom = offlineModeRoom;
		if (createdRoom)
		{
			NetworkingClient.MatchMakingCallbackTargets.OnCreatedRoom();
		}
		NetworkingClient.MatchMakingCallbackTargets.OnJoinedRoom();
	}

	public static bool JoinLobby()
	{
		return JoinLobby(null);
	}

	public static bool JoinLobby(TypedLobby typedLobby)
	{
		if (IsConnected && Server == ServerConnection.MasterServer)
		{
			return NetworkingClient.OpJoinLobby(typedLobby);
		}
		return false;
	}

	public static bool LeaveLobby()
	{
		if (IsConnected && Server == ServerConnection.MasterServer)
		{
			return NetworkingClient.OpLeaveLobby();
		}
		return false;
	}

	public static bool FindFriends(string[] friendsToFind)
	{
		if (NetworkingClient == null || offlineMode)
		{
			return false;
		}
		return NetworkingClient.OpFindFriends(friendsToFind);
	}

	public static bool GetCustomRoomList(TypedLobby typedLobby, string sqlLobbyFilter)
	{
		return NetworkingClient.OpGetGameList(typedLobby, sqlLobbyFilter);
	}

	public static bool SetPlayerCustomProperties(ExitGames.Client.Photon.Hashtable customProperties)
	{
		if (customProperties == null)
		{
			customProperties = new ExitGames.Client.Photon.Hashtable();
			foreach (object key in LocalPlayer.CustomProperties.Keys)
			{
				customProperties[(string)key] = null;
			}
		}
		return LocalPlayer.SetCustomProperties(customProperties);
	}

	public static void RemovePlayerCustomProperties(string[] customPropertiesToDelete)
	{
		if (customPropertiesToDelete == null || customPropertiesToDelete.Length == 0 || LocalPlayer.CustomProperties == null)
		{
			LocalPlayer.CustomProperties = new ExitGames.Client.Photon.Hashtable();
			return;
		}
		foreach (string key in customPropertiesToDelete)
		{
			if (LocalPlayer.CustomProperties.ContainsKey(key))
			{
				LocalPlayer.CustomProperties.Remove(key);
			}
		}
	}

	public static bool RaiseEvent(byte eventCode, object eventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
	{
		if (offlineMode)
		{
			if (raiseEventOptions.Receivers == ReceiverGroup.Others)
			{
				return true;
			}
			EventData eventData = new EventData
			{
				Code = eventCode
			};
			eventData.Parameters[245] = eventContent;
			eventData.Parameters[254] = 1;
			NetworkingClient.OnEvent(eventData);
			return true;
		}
		if (!InRoom || eventCode >= 200)
		{
			UnityEngine.Debug.LogWarning("RaiseEvent(" + eventCode + ") failed. Your event is not being sent! Check if your are in a Room and the eventCode must be less than 200 (0..199).");
			return false;
		}
		return NetworkingClient.OpRaiseEvent(eventCode, eventContent, raiseEventOptions, sendOptions);
	}

	private static bool RaiseEventInternal(byte eventCode, object eventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
	{
		if (offlineMode)
		{
			return false;
		}
		if (!InRoom)
		{
			UnityEngine.Debug.LogWarning("RaiseEvent(" + eventCode + ") failed. Your event is not being sent! Check if your are in a Room");
			return false;
		}
		return NetworkingClient.OpRaiseEvent(eventCode, eventContent, raiseEventOptions, sendOptions);
	}

	public static bool AllocateViewID(PhotonView view)
	{
		if (view.ViewID != 0)
		{
			UnityEngine.Debug.LogError("AllocateViewID() can't be used for PhotonViews that already have a viewID. This view is: " + view.ToString());
			return false;
		}
		int viewID = AllocateViewID(LocalPlayer.ActorNumber);
		view.ViewID = viewID;
		return true;
	}

	[Obsolete("Renamed. Use AllocateRoomViewID instead")]
	public static bool AllocateSceneViewID(PhotonView view)
	{
		return AllocateRoomViewID(view);
	}

	public static bool AllocateRoomViewID(PhotonView view)
	{
		if (!IsMasterClient)
		{
			UnityEngine.Debug.LogError("Only the Master Client can AllocateRoomViewID(). Check PhotonNetwork.IsMasterClient!");
			return false;
		}
		if (view.ViewID != 0)
		{
			UnityEngine.Debug.LogError("AllocateRoomViewID() can't be used for PhotonViews that already have a viewID. This view is: " + view.ToString());
			return false;
		}
		int viewID = AllocateViewID(0);
		view.ViewID = viewID;
		return true;
	}

	public static int AllocateViewID(bool roomObject)
	{
		if (roomObject && !LocalPlayer.IsMasterClient)
		{
			UnityEngine.Debug.LogError("Only a Master Client can AllocateViewID() for room objects. This client/player is not a Master Client. Returning an invalid viewID: -1.");
			return 0;
		}
		return AllocateViewID((!roomObject) ? LocalPlayer.ActorNumber : 0);
	}

	public static int AllocateViewID(int ownerId)
	{
		if (ownerId == 0)
		{
			int num = lastUsedViewSubIdStatic;
			int num2 = ownerId * MAX_VIEW_IDS;
			for (int i = 1; i < MAX_VIEW_IDS; i++)
			{
				num = (num + 1) % MAX_VIEW_IDS;
				if (num != 0)
				{
					int num3 = num + num2;
					if (!photonViewList.ContainsKey(num3))
					{
						lastUsedViewSubIdStatic = num;
						return num3;
					}
				}
			}
			throw new Exception($"AllocateViewID() failed. The room (user {ownerId}) is out of 'room' viewIDs. It seems all available are in use.");
		}
		int num4 = lastUsedViewSubId;
		int num5 = ownerId * MAX_VIEW_IDS;
		for (int j = 1; j <= MAX_VIEW_IDS; j++)
		{
			num4 = (num4 + 1) % MAX_VIEW_IDS;
			if (num4 != 0)
			{
				int num6 = num4 + num5;
				if (!photonViewList.ContainsKey(num6))
				{
					lastUsedViewSubId = num4;
					return num6;
				}
			}
		}
		throw new Exception($"AllocateViewID() failed. User {ownerId} is out of viewIDs. It seems all available are in use.");
	}

	public static GameObject Instantiate(string prefabName, Vector3 position, Quaternion rotation, byte group = 0, object[] data = null)
	{
		if (CurrentRoom == null)
		{
			UnityEngine.Debug.LogError("Can not Instantiate before the client joined/created a room. State: " + NetworkClientState);
			return null;
		}
		return NetworkInstantiate(new InstantiateParameters(prefabName, position, rotation, group, data, currentLevelPrefix, null, LocalPlayer, ServerTimestamp));
	}

	[Obsolete("Renamed. Use InstantiateRoomObject instead")]
	public static GameObject InstantiateSceneObject(string prefabName, Vector3 position, Quaternion rotation, byte group = 0, object[] data = null)
	{
		return InstantiateRoomObject(prefabName, position, rotation, group, data);
	}

	public static GameObject InstantiateRoomObject(string prefabName, Vector3 position, Quaternion rotation, byte group = 0, object[] data = null)
	{
		if (CurrentRoom == null)
		{
			UnityEngine.Debug.LogError("Can not Instantiate before the client joined/created a room.");
			return null;
		}
		if (LocalPlayer.IsMasterClient)
		{
			return NetworkInstantiate(new InstantiateParameters(prefabName, position, rotation, group, data, currentLevelPrefix, null, LocalPlayer, ServerTimestamp), roomObject: true);
		}
		return null;
	}

	private static GameObject NetworkInstantiate(ExitGames.Client.Photon.Hashtable networkEvent, Player creator)
	{
		if (networkEvent == null)
		{
			return null;
		}
		string text = (string)networkEvent[keyByteZero];
		if (text == null)
		{
			return null;
		}
		int timestamp = (int)networkEvent[keyByteSix];
		int num = (int)networkEvent[keyByteSeven];
		Vector3 position = ((!networkEvent.ContainsKey(keyByteOne)) ? Vector3.zero : ((Vector3)networkEvent[keyByteOne]));
		Quaternion rotation = Quaternion.identity;
		if (networkEvent.ContainsKey(keyByteTwo))
		{
			rotation = (Quaternion)networkEvent[keyByteTwo];
		}
		byte b = 0;
		if (networkEvent.ContainsKey(keyByteThree))
		{
			b = (byte)networkEvent[keyByteThree];
		}
		byte objLevelPrefix = 0;
		if (networkEvent.ContainsKey(keyByteEight))
		{
			objLevelPrefix = (byte)networkEvent[keyByteEight];
		}
		int[] viewIDs = ((!networkEvent.ContainsKey(keyByteFour)) ? new int[1] { num } : ((int[])networkEvent[keyByteFour]));
		object[] data = ((!networkEvent.ContainsKey(keyByteFive)) ? null : ((object[])networkEvent[keyByteFive]));
		if (b != 0 && !allowedReceivingGroups.Contains(b))
		{
			return null;
		}
		return NetworkInstantiate(new InstantiateParameters(text, position, rotation, b, data, objLevelPrefix, viewIDs, creator, timestamp), roomObject: false, instantiateEvent: true);
	}

	private static GameObject NetworkInstantiate(InstantiateParameters parameters, bool roomObject = false, bool instantiateEvent = false)
	{
		GameObject gameObject = null;
		bool flag = !instantiateEvent && LocalPlayer.Equals(parameters.creator);
		IPunPrefabPoolVerify punPrefabPoolVerify = prefabPool as IPunPrefabPoolVerify;
		bool flag2 = punPrefabPoolVerify != null;
		if (!flag && flag2)
		{
			Vector3 position = parameters.position;
			Quaternion rotation = parameters.rotation;
			if (punPrefabPoolVerify.VerifyInstantiation(parameters.creator, parameters.prefabName, position, rotation, parameters.viewIDs, out var prefab))
			{
				gameObject = punPrefabPoolVerify.Instantiate(prefab, position, rotation);
			}
		}
		else
		{
			gameObject = prefabPool.Instantiate(parameters.prefabName, parameters.position, parameters.rotation);
		}
		if (gameObject == null)
		{
			return null;
		}
		if (gameObject.activeSelf)
		{
			UnityEngine.Debug.LogWarning("PrefabPool.Instantiate() should return an inactive GameObject. " + prefabPool.GetType().Name + " returned an active object. PrefabId: " + parameters.prefabName);
		}
		PhotonView[] photonViewsInChildren = gameObject.GetPhotonViewsInChildren();
		if (photonViewsInChildren.Length == 0)
		{
			UnityEngine.Debug.LogError("PhotonNetwork.Instantiate() can only instantiate objects with a PhotonView component. This prefab does not have one: " + parameters.prefabName);
			return null;
		}
		int[] array = null;
		if (flag)
		{
			array = (parameters.viewIDs = new int[photonViewsInChildren.Length]);
		}
		else
		{
			array = parameters.viewIDs;
			if (!flag2 && (array == null || array.Length != photonViewsInChildren.Length))
			{
				prefabPool.Destroy(gameObject);
				return null;
			}
		}
		for (int i = 0; i < photonViewsInChildren.Length; i++)
		{
			if (flag)
			{
				array[i] = (roomObject ? AllocateViewID(0) : AllocateViewID(parameters.creator.ActorNumber));
			}
			PhotonView obj = photonViewsInChildren[i];
			obj.ViewID = 0;
			obj.sceneViewId = 0;
			obj.isRuntimeInstantiated = true;
			obj.lastOnSerializeDataSent = null;
			obj.lastOnSerializeDataReceived = null;
			obj.Prefix = parameters.objLevelPrefix;
			obj.InstantiationId = array[0];
			obj.InstantiationData = parameters.data;
			obj.ViewID = array[i];
			obj.Group = parameters.group;
		}
		if (flag)
		{
			SendInstantiate(parameters, roomObject);
		}
		gameObject.SetActive(value: true);
		if (!PrefabsWithoutMagicCallback.Contains(parameters.prefabName))
		{
			IPunInstantiateMagicCallback[] components = gameObject.GetComponents<IPunInstantiateMagicCallback>();
			if (components.Length != 0)
			{
				PhotonMessageInfo info = new PhotonMessageInfo(parameters.creator, parameters.timestamp, photonViewsInChildren[0]);
				IPunInstantiateMagicCallback[] array2 = components;
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j].OnPhotonInstantiate(info);
				}
			}
			else
			{
				PrefabsWithoutMagicCallback.Add(parameters.prefabName);
			}
		}
		return gameObject;
	}

	internal static bool SendInstantiate(InstantiateParameters parameters, bool roomObject = false)
	{
		int num = parameters.viewIDs[0];
		SendInstantiateEvHashtable.Clear();
		SendInstantiateEvHashtable[keyByteZero] = parameters.prefabName;
		if (parameters.position != Vector3.zero)
		{
			SendInstantiateEvHashtable[keyByteOne] = parameters.position;
		}
		if (parameters.rotation != Quaternion.identity)
		{
			SendInstantiateEvHashtable[keyByteTwo] = parameters.rotation;
		}
		if (parameters.group != 0)
		{
			SendInstantiateEvHashtable[keyByteThree] = parameters.group;
		}
		if (parameters.viewIDs.Length > 1)
		{
			SendInstantiateEvHashtable[keyByteFour] = parameters.viewIDs;
		}
		if (parameters.data != null)
		{
			SendInstantiateEvHashtable[keyByteFive] = parameters.data;
		}
		if (currentLevelPrefix > 0)
		{
			SendInstantiateEvHashtable[keyByteEight] = currentLevelPrefix;
		}
		SendInstantiateEvHashtable[keyByteSix] = ServerTimestamp;
		SendInstantiateEvHashtable[keyByteSeven] = num;
		SendInstantiateRaiseEventOptions.CachingOption = (roomObject ? EventCaching.AddToRoomCacheGlobal : EventCaching.AddToRoomCache);
		return RaiseEventInternal(202, SendInstantiateEvHashtable, SendInstantiateRaiseEventOptions, SendOptions.SendReliable);
	}

	public static void Destroy(PhotonView targetView)
	{
		if (targetView != null)
		{
			RemoveInstantiatedGO(targetView.gameObject, !InRoom);
		}
		else
		{
			UnityEngine.Debug.LogError("Destroy(targetPhotonView) failed, cause targetPhotonView is null.");
		}
	}

	public static void Destroy(GameObject targetGo)
	{
		RemoveInstantiatedGO(targetGo, !InRoom);
	}

	public static void DestroyPlayerObjects(Player targetPlayer)
	{
		if (targetPlayer == null)
		{
			UnityEngine.Debug.LogError("DestroyPlayerObjects() failed, cause parameter 'targetPlayer' was null.");
		}
		DestroyPlayerObjects(targetPlayer.ActorNumber);
	}

	public static void DestroyPlayerObjects(int targetPlayerId)
	{
		if (VerifyCanUseNetwork())
		{
			if (LocalPlayer.IsMasterClient || targetPlayerId == LocalPlayer.ActorNumber)
			{
				DestroyPlayerObjects(targetPlayerId, localOnly: false);
			}
			else
			{
				UnityEngine.Debug.LogError("DestroyPlayerObjects() failed, cause players can only destroy their own GameObjects. A Master Client can destroy anyone's. This is master: " + IsMasterClient);
			}
		}
	}

	public static void DestroyAll()
	{
		if (IsMasterClient)
		{
			DestroyAll(localOnly: false);
		}
		else
		{
			UnityEngine.Debug.LogError("Couldn't call DestroyAll() as only the master client is allowed to call this.");
		}
	}

	public static void RemoveRPCs(Player targetPlayer)
	{
		if (VerifyCanUseNetwork())
		{
			if (!targetPlayer.IsLocal && !IsMasterClient)
			{
				UnityEngine.Debug.LogError("Error; Only the MasterClient can call RemoveRPCs for other players.");
			}
			else
			{
				OpCleanActorRpcBuffer(targetPlayer.ActorNumber);
			}
		}
	}

	public static void RemoveRPCs(PhotonView targetPhotonView)
	{
		if (VerifyCanUseNetwork())
		{
			CleanRpcBufferIfMine(targetPhotonView);
		}
	}

	internal static void RPC(PhotonView view, string methodName, RpcTarget target, bool encrypt, params object[] parameters)
	{
		if (string.IsNullOrEmpty(methodName))
		{
			UnityEngine.Debug.LogError("RPC method name cannot be null or empty.");
		}
		else if (VerifyCanUseNetwork())
		{
			if (CurrentRoom == null)
			{
				UnityEngine.Debug.LogWarning("RPCs can only be sent in rooms. Call of \"" + methodName + "\" gets executed locally only, if at all.");
			}
			else if (NetworkingClient != null)
			{
				RPC(view, methodName, target, null, encrypt, parameters);
			}
			else
			{
				UnityEngine.Debug.LogWarning("Could not execute RPC " + methodName + ". Possible scene loading in progress?");
			}
		}
	}

	internal static void RPC(PhotonView view, string methodName, Player targetPlayer, bool encrypt, params object[] parameters)
	{
		if (!VerifyCanUseNetwork())
		{
			return;
		}
		if (CurrentRoom == null)
		{
			UnityEngine.Debug.LogWarning("RPCs can only be sent in rooms. Call of \"" + methodName + "\" gets executed locally only, if at all.");
			return;
		}
		if (LocalPlayer == null)
		{
			UnityEngine.Debug.LogError("RPC can't be sent to target Player being null! Did not send \"" + methodName + "\" call.");
		}
		if (NetworkingClient != null)
		{
			RPC(view, methodName, RpcTarget.Others, targetPlayer, encrypt, parameters);
		}
		else
		{
			UnityEngine.Debug.LogWarning("Could not execute RPC " + methodName + ". Possible scene loading in progress?");
		}
	}

	public static HashSet<GameObject> FindGameObjectsWithComponent(Type type)
	{
		HashSet<GameObject> hashSet = new HashSet<GameObject>();
		UnityEngine.Component[] array = (UnityEngine.Component[])UnityEngine.Object.FindObjectsOfType(type);
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != null)
			{
				hashSet.Add(array[i].gameObject);
			}
		}
		return hashSet;
	}

	public static void SetInterestGroups(byte group, bool enabled)
	{
		if (VerifyCanUseNetwork())
		{
			if (enabled)
			{
				byte[] enableGroups = new byte[1] { group };
				SetInterestGroups(null, enableGroups);
			}
			else
			{
				SetInterestGroups(new byte[1] { group }, null);
			}
		}
	}

	public static void LoadLevel(int levelNumber)
	{
		if (!ConnectionHandler.AppQuits)
		{
			if (AutomaticallySyncScene)
			{
				SetLevelInPropsIfSynced(levelNumber);
			}
			IsMessageQueueRunning = false;
			loadingLevelAndPausedNetwork = true;
			_AsyncLevelLoadingOperation = SceneManager.LoadSceneAsync(levelNumber, LoadSceneMode.Single);
		}
	}

	public static void LoadLevel(string levelName)
	{
		if (!ConnectionHandler.AppQuits)
		{
			if (AutomaticallySyncScene)
			{
				SetLevelInPropsIfSynced(levelName);
			}
			IsMessageQueueRunning = false;
			loadingLevelAndPausedNetwork = true;
			_AsyncLevelLoadingOperation = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
		}
	}

	public static bool WebRpc(string name, object parameters, bool sendAuthCookie = false)
	{
		return NetworkingClient.OpWebRpc(name, parameters, sendAuthCookie);
	}

	private static void SetupLogging()
	{
		if (LogLevel == PunLogLevel.ErrorsOnly)
		{
			LogLevel = PhotonServerSettings.PunLogging;
		}
		if (NetworkingClient.LoadBalancingPeer.DebugOut == DebugLevel.ERROR)
		{
			NetworkingClient.LoadBalancingPeer.DebugOut = PhotonServerSettings.AppSettings.NetworkLogging;
		}
	}

	public static void LoadOrCreateSettings(bool reload = false)
	{
		if (reload)
		{
			photonServerSettings = null;
		}
		else if (photonServerSettings != null)
		{
			UnityEngine.Debug.LogWarning("photonServerSettings is not null. Will not LoadOrCreateSettings().");
			return;
		}
		photonServerSettings = (ServerSettings)Resources.Load("PhotonServerSettings", typeof(ServerSettings));
		if (!(photonServerSettings != null) && photonServerSettings == null)
		{
			photonServerSettings = (ServerSettings)ScriptableObject.CreateInstance("ServerSettings");
			if (photonServerSettings == null)
			{
				UnityEngine.Debug.LogError("Failed to create ServerSettings. PUN is unable to run this way. If you deleted it from the project, reload the Editor.");
			}
		}
	}

	public static void AddCallbackTarget(object target)
	{
		if (!(target is PhotonView))
		{
			if (target is IPunOwnershipCallbacks punOwnershipCallbacks)
			{
				OnOwnershipRequestEv += punOwnershipCallbacks.OnOwnershipRequest;
				OnOwnershipTransferedEv += punOwnershipCallbacks.OnOwnershipTransfered;
				OnOwnershipTransferFailedEv += punOwnershipCallbacks.OnOwnershipTransferFailed;
			}
			NetworkingClient.AddCallbackTarget(target);
		}
	}

	public static void RemoveCallbackTarget(object target)
	{
		if (!(target is PhotonView) && NetworkingClient != null)
		{
			if (target is IPunOwnershipCallbacks punOwnershipCallbacks)
			{
				OnOwnershipRequestEv -= punOwnershipCallbacks.OnOwnershipRequest;
				OnOwnershipTransferedEv -= punOwnershipCallbacks.OnOwnershipTransfered;
				OnOwnershipTransferFailedEv -= punOwnershipCallbacks.OnOwnershipTransferFailed;
			}
			NetworkingClient.RemoveCallbackTarget(target);
		}
	}

	internal static string CallbacksToString()
	{
		string[] value = NetworkingClient.ConnectionCallbackTargets.Select((IConnectionCallbacks m) => m.ToString()).ToArray();
		return string.Join(", ", value);
	}

	private static void LeftRoomCleanup()
	{
		if (_AsyncLevelLoadingOperation != null)
		{
			_AsyncLevelLoadingOperation.allowSceneActivation = false;
			_AsyncLevelLoadingOperation = null;
		}
		bool num = NetworkingClient.CurrentRoom != null && CurrentRoom.AutoCleanUp;
		allowedReceivingGroups = new HashSet<byte>();
		blockedSendingGroups = new HashSet<byte>();
		if (num || offlineModeRoom != null)
		{
			LocalCleanupAnythingInstantiated(destroyInstantiatedGameObjects: true);
		}
	}

	internal static void LocalCleanupAnythingInstantiated(bool destroyInstantiatedGameObjects)
	{
		if (destroyInstantiatedGameObjects)
		{
			HashSet<GameObject> hashSet = new HashSet<GameObject>();
			foreach (PhotonView value in photonViewList.Values)
			{
				if (value.isRuntimeInstantiated)
				{
					hashSet.Add(value.gameObject);
				}
				else
				{
					value.ResetPhotonView(resetOwner: true);
				}
			}
			foreach (GameObject item in hashSet)
			{
				RemoveInstantiatedGO(item, localOnly: true);
			}
		}
		lastUsedViewSubId = 0;
		lastUsedViewSubIdStatic = 0;
		cachedData.Clear();
	}

	private static void ResetPhotonViewsOnSerialize()
	{
		foreach (PhotonView value in photonViewList.Values)
		{
			value.lastOnSerializeDataSent = null;
		}
	}

	internal static void ExecuteRpc(ExitGames.Client.Photon.Hashtable rpcData, Player sender)
	{
		if (rpcData == null || !rpcData.ContainsKey(keyByteZero))
		{
			return;
		}
		int num = (int)rpcData[keyByteZero];
		int num2 = 0;
		if (rpcData.ContainsKey(keyByteOne))
		{
			num2 = (short)rpcData[keyByteOne];
		}
		if (!rpcData.ContainsKey(keyByteFive))
		{
			return;
		}
		int num3 = (byte)rpcData[keyByteFive];
		if (num3 > PhotonServerSettings.RpcList.Count - 1)
		{
			return;
		}
		string text = PhotonServerSettings.RpcList[num3];
		object[] array = null;
		if (rpcData.ContainsKey(keyByteFour))
		{
			array = (object[])rpcData[keyByteFour];
		}
		PhotonView photonView = GetPhotonView(num);
		if (photonView == null)
		{
			int num4 = num / MAX_VIEW_IDS;
			_ = num4 == NetworkingClient.LocalPlayer.ActorNumber;
			if (sender != null)
			{
				_ = num4 == sender.ActorNumber;
			}
			else
				_ = 0;
		}
		else
		{
			if (photonView.Prefix != num2 || string.IsNullOrEmpty(text))
			{
				return;
			}
			if (LogLevel >= PunLogLevel.Full)
			{
				UnityEngine.Debug.Log("Received RPC: " + text + ". Sender is " + sender.UserId);
			}
			if (photonView.Group != 0 && !allowedReceivingGroups.Contains(photonView.Group))
			{
				return;
			}
			Type[] array2 = null;
			if (array != null && array.Length != 0)
			{
				array2 = new Type[array.Length];
				int num5 = 0;
				foreach (object obj in array)
				{
					if (obj == null)
					{
						array2[num5] = null;
					}
					else
					{
						array2[num5] = obj.GetType();
					}
					num5++;
				}
			}
			int num6 = 0;
			int num7 = 0;
			if (!UseRpcMonoBehaviourCache || photonView.RpcMonoBehaviours == null || photonView.RpcMonoBehaviours.Length == 0)
			{
				photonView.RefreshRpcMonoBehaviourCache();
			}
			for (int j = 0; j < photonView.RpcMonoBehaviours.Length; j++)
			{
				MonoBehaviour monoBehaviour = photonView.RpcMonoBehaviours[j];
				if (monoBehaviour == null)
				{
					continue;
				}
				Type type = monoBehaviour.GetType();
				List<MethodInfo> value = null;
				if (!monoRPCMethodsCache.TryGetValue(type, out value))
				{
					List<MethodInfo> methods = SupportClass.GetMethods(type, typePunRPC);
					monoRPCMethodsCache[type] = methods;
					value = methods;
				}
				if (value == null)
				{
					continue;
				}
				for (int k = 0; k < value.Count; k++)
				{
					MethodInfo methodInfo = value[k];
					if (!methodInfo.Name.Equals(text))
					{
						continue;
					}
					ParameterInfo[] cachedParemeters = methodInfo.GetCachedParemeters();
					num7++;
					bool flag = false;
					int num8 = cachedParemeters.Length;
					if (num8 > 0 && cachedParemeters[num8 - 1].ParameterType == typeof(PhotonMessageInfo))
					{
						num8--;
						flag = true;
					}
					if (array == null)
					{
						if (num8 != 0)
						{
							continue;
						}
						if (!flag)
						{
							num6++;
							object obj2 = methodInfo.Invoke(monoBehaviour, null);
							if (RunRpcCoroutines)
							{
								IEnumerator enumerator = null;
								if (obj2 is IEnumerator routine)
								{
									PhotonHandler.Instance.StartCoroutine(routine);
								}
							}
							continue;
						}
						int timestamp = (int)rpcData[keyByteTwo];
						num6++;
						object obj3 = methodInfo.Invoke(monoBehaviour, new object[1]
						{
							new PhotonMessageInfo(sender, timestamp, photonView)
						});
						if (RunRpcCoroutines)
						{
							IEnumerator enumerator2 = null;
							if (obj3 is IEnumerator routine2)
							{
								PhotonHandler.Instance.StartCoroutine(routine2);
							}
						}
					}
					else if (num8 == array.Length && CheckTypeMatch(cachedParemeters, array2))
					{
						object[] parameters = array;
						if (flag)
						{
							int timestamp2 = (int)rpcData[keyByteTwo];
							object[] array3 = new object[array.Length + 1];
							array.CopyTo(array3, 0);
							array3[^1] = new PhotonMessageInfo(sender, timestamp2, photonView);
							parameters = array3;
						}
						num6++;
						object obj4 = methodInfo.Invoke(monoBehaviour, parameters);
						if (RunRpcCoroutines)
						{
							IEnumerator enumerator3 = null;
							if (obj4 is IEnumerator routine3)
							{
								PhotonHandler.Instance.StartCoroutine(routine3);
							}
						}
					}
					else
					{
						if (cachedParemeters.Length != 1 || !cachedParemeters[0].ParameterType.IsArray)
						{
							continue;
						}
						num6++;
						object obj5 = methodInfo.Invoke(monoBehaviour, new object[1] { array });
						if (RunRpcCoroutines)
						{
							IEnumerator enumerator4 = null;
							if (obj5 is IEnumerator routine4)
							{
								PhotonHandler.Instance.StartCoroutine(routine4);
							}
						}
					}
				}
			}
			if (num6 == 1)
			{
				return;
			}
			string text2 = string.Empty;
			if (array2 != null)
			{
				_ = array2.Length;
				foreach (Type type2 in array2)
				{
					if (text2 != string.Empty)
					{
						text2 += ", ";
					}
					text2 = ((!(type2 == null)) ? (text2 + type2.Name) : (text2 + "null"));
				}
			}
			GameObject context = ((photonView != null) ? photonView.gameObject : null);
			if (num6 == 0)
			{
				if (num7 == 0)
				{
					UnityEngine.Debug.LogErrorFormat(context, "RPC method '{0}({2})' not found on object with PhotonView {1}. Implement as non-static. Apply [PunRPC]. Components on children are not found. Return type must be void or IEnumerator (if you enable RunRpcCoroutines). RPCs are a one-way message.. Sender is " + sender.UserId, text, num, text2);
				}
				else
				{
					UnityEngine.Debug.LogErrorFormat(context, "RPC method '{0}' found on object with PhotonView {1} but has wrong parameters. Implement as '{0}({2})'. PhotonMessageInfo is optional as final parameter.Return type must be void or IEnumerator (if you enable RunRpcCoroutines).. Sender is " + sender.UserId, text, num, text2);
				}
			}
			else
			{
				UnityEngine.Debug.LogErrorFormat(context, "RPC method '{0}({2})' found {3}x on object with PhotonView {1}. Only one component should implement it.Return type must be void or IEnumerator (if you enable RunRpcCoroutines).. Sender is " + sender.UserId, text, num, text2, num7);
			}
		}
	}

	private static bool CheckTypeMatch(ParameterInfo[] methodParameters, Type[] callParameterTypes)
	{
		if (methodParameters.Length < callParameterTypes.Length)
		{
			return false;
		}
		for (int i = 0; i < callParameterTypes.Length; i++)
		{
			Type parameterType = methodParameters[i].ParameterType;
			if (callParameterTypes[i] != null && !parameterType.IsAssignableFrom(callParameterTypes[i]) && (!parameterType.IsEnum || !Enum.GetUnderlyingType(parameterType).IsAssignableFrom(callParameterTypes[i])))
			{
				return false;
			}
		}
		return true;
	}

	public static void DestroyPlayerObjects(int playerId, bool localOnly)
	{
		if (playerId <= 0)
		{
			UnityEngine.Debug.LogError("Failed to Destroy objects of playerId: " + playerId);
			return;
		}
		if (!localOnly)
		{
			OpRemoveFromServerInstantiationsOfPlayer(playerId);
			OpCleanActorRpcBuffer(playerId);
			SendDestroyOfPlayer(playerId);
		}
		HashSet<GameObject> hashSet = new HashSet<GameObject>();
		foreach (PhotonView value in photonViewList.Values)
		{
			if (value == null)
			{
				UnityEngine.Debug.LogError("Null view");
			}
			else if (value.CreatorActorNr == playerId)
			{
				hashSet.Add(value.gameObject);
			}
			else if (value.OwnerActorNr == playerId)
			{
				Player owner = value.Owner;
				value.OwnerActorNr = value.CreatorActorNr;
				value.ControllerActorNr = value.CreatorActorNr;
				if (PhotonNetwork.OnOwnershipTransferedEv != null)
				{
					PhotonNetwork.OnOwnershipTransferedEv(value, owner);
				}
			}
		}
		foreach (GameObject item in hashSet)
		{
			RemoveInstantiatedGO(item, localOnly: true);
		}
	}

	public static void DestroyAll(bool localOnly)
	{
		if (!localOnly)
		{
			OpRemoveCompleteCache();
			SendDestroyOfAll();
		}
		LocalCleanupAnythingInstantiated(destroyInstantiatedGameObjects: true);
	}

	public static void RemoveInstantiatedGO(GameObject go, bool localOnly)
	{
		if (ConnectionHandler.AppQuits || go == null)
		{
			return;
		}
		go.GetComponentsInChildren(includeInactive: true, foundPVs);
		if (foundPVs.Count <= 0)
		{
			UnityEngine.Debug.LogError("Failed to 'network-remove' GameObject because has no PhotonView components: " + go);
			return;
		}
		PhotonView photonView = foundPVs[0];
		if (!localOnly && !photonView.IsMine)
		{
			UnityEngine.Debug.LogError("Failed to 'network-remove' GameObject. Client is neither owner nor MasterClient taking over for owner who left: " + photonView);
			foundPVs.Clear();
			return;
		}
		if (!localOnly)
		{
			ServerCleanInstantiateAndDestroy(photonView);
		}
		int creatorActorNr = photonView.CreatorActorNr;
		for (int num = foundPVs.Count - 1; num >= 0; num--)
		{
			PhotonView photonView2 = foundPVs[num];
			if (!(photonView2 == null))
			{
				if (num != 0 && photonView2.CreatorActorNr != creatorActorNr)
				{
					photonView2.transform.SetParent(null, worldPositionStays: true);
				}
				else
				{
					photonView2.OnPreNetDestroy(photonView);
					if (photonView2.InstantiationId >= 1)
					{
						LocalCleanPhotonView(photonView2);
					}
					if (!localOnly)
					{
						OpCleanRpcBuffer(photonView2);
					}
				}
			}
		}
		if (LogLevel >= PunLogLevel.Full)
		{
			UnityEngine.Debug.Log("Network destroy Instantiated GO: " + go.name);
		}
		foundPVs.Clear();
		go.SetActive(value: false);
		prefabPool.Destroy(go);
	}

	private static void ServerCleanInstantiateAndDestroy(PhotonView photonView)
	{
		int num;
		if (photonView.isRuntimeInstantiated)
		{
			num = photonView.InstantiationId;
			removeFilter[keyByteSeven] = num;
			ServerCleanOptions.CachingOption = EventCaching.RemoveFromRoomCache;
			RaiseEventInternal(202, removeFilter, ServerCleanOptions, SendOptions.SendReliable);
		}
		else
		{
			num = photonView.ViewID;
		}
		ServerCleanDestroyEvent[keyByteZero] = num;
		ServerCleanOptions.CachingOption = ((!photonView.isRuntimeInstantiated) ? EventCaching.AddToRoomCacheGlobal : EventCaching.DoNotCache);
		RaiseEventInternal(204, ServerCleanDestroyEvent, ServerCleanOptions, SendOptions.SendReliable);
	}

	private static void SendDestroyOfPlayer(int actorNr)
	{
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable[keyByteZero] = actorNr;
		RaiseEventInternal(207, hashtable, null, SendOptions.SendReliable);
	}

	private static void SendDestroyOfAll()
	{
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable[keyByteZero] = -1;
		RaiseEventInternal(207, hashtable, null, SendOptions.SendReliable);
	}

	private static void OpRemoveFromServerInstantiationsOfPlayer(int actorNr)
	{
		RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
		raiseEventOptions.CachingOption = EventCaching.RemoveFromRoomCache;
		raiseEventOptions.TargetActors = new int[1] { actorNr };
		RaiseEventOptions raiseEventOptions2 = raiseEventOptions;
		RaiseEventInternal(202, null, raiseEventOptions2, SendOptions.SendReliable);
	}

	internal static void RequestOwnership(int viewID, int fromOwner)
	{
		RaiseEventInternal(209, new int[2] { viewID, fromOwner }, SendToAllOptions, SendOptions.SendReliable);
	}

	internal static void TransferOwnership(int viewID, int playerID)
	{
		RaiseEventInternal(210, new int[2] { viewID, playerID }, SendToAllOptions, SendOptions.SendReliable);
	}

	internal static void OwnershipUpdate(int[] viewOwnerPairs, int targetActor = -1)
	{
		RaiseEventOptions raiseEventOptions;
		if (targetActor == -1)
		{
			raiseEventOptions = SendToOthersOptions;
		}
		else
		{
			SendToSingleOptions.TargetActors[0] = targetActor;
			raiseEventOptions = SendToSingleOptions;
		}
		RaiseEventInternal(212, viewOwnerPairs, raiseEventOptions, SendOptions.SendReliable);
	}

	public static bool LocalCleanPhotonView(PhotonView view)
	{
		view.removedFromLocalViewList = true;
		return photonViewList.Remove(view.ViewID);
	}

	public static PhotonView GetPhotonView(int viewID)
	{
		PhotonView val = null;
		photonViewList.TryGetValue(viewID, out val);
		return val;
	}

	public static bool ViewIDExists(int viewID)
	{
		return photonViewList.ContainsKey(viewID);
	}

	public static void RegisterPhotonView(PhotonView netView)
	{
		if (!Application.isPlaying)
		{
			photonViewList = new NonAllocDictionary<int, PhotonView>();
			return;
		}
		if (netView.ViewID == 0)
		{
			UnityEngine.Debug.Log("PhotonView register is ignored, because viewID is 0. No id assigned yet to: " + netView);
			return;
		}
		PhotonView val = null;
		if (photonViewList.TryGetValue(netView.ViewID, out val))
		{
			if (!(netView != val))
			{
				return;
			}
			RemoveInstantiatedGO(val.gameObject, localOnly: true);
		}
		photonViewList[netView.ViewID] = netView;
		netView.removedFromLocalViewList = false;
		if (LogLevel >= PunLogLevel.Full)
		{
			UnityEngine.Debug.Log("Registered PhotonView: " + netView.ViewID);
		}
		if (!cachedData.TryGetValue(netView.CreatorActorNr, out var value) || !value.TryGetValue(netView.ViewID, out var value2))
		{
			return;
		}
		value.Remove(netView.ViewID);
		foreach (object[] item in value2)
		{
			OnSerializeRead((object[])item[0], (Player)item[1], (int)item[2], (short)item[3]);
		}
	}

	public static void OpCleanActorRpcBuffer(int actorNumber)
	{
		RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
		raiseEventOptions.CachingOption = EventCaching.RemoveFromRoomCache;
		raiseEventOptions.TargetActors = new int[1] { actorNumber };
		RaiseEventOptions raiseEventOptions2 = raiseEventOptions;
		RaiseEventInternal(200, null, raiseEventOptions2, SendOptions.SendReliable);
	}

	public static void OpRemoveCompleteCacheOfPlayer(int actorNumber)
	{
		RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
		raiseEventOptions.CachingOption = EventCaching.RemoveFromRoomCache;
		raiseEventOptions.TargetActors = new int[1] { actorNumber };
		RaiseEventOptions raiseEventOptions2 = raiseEventOptions;
		RaiseEventInternal(0, null, raiseEventOptions2, SendOptions.SendReliable);
	}

	public static void OpRemoveCompleteCache()
	{
		RaiseEventOptions raiseEventOptions = new RaiseEventOptions
		{
			CachingOption = EventCaching.RemoveFromRoomCache,
			Receivers = ReceiverGroup.MasterClient
		};
		RaiseEventInternal(0, null, raiseEventOptions, SendOptions.SendReliable);
	}

	private static void RemoveCacheOfLeftPlayers()
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[244] = (byte)0;
		dictionary[247] = (byte)7;
		NetworkingClient.LoadBalancingPeer.SendOperation(253, dictionary, SendOptions.SendReliable);
	}

	public static void CleanRpcBufferIfMine(PhotonView view)
	{
		if (view.OwnerActorNr != NetworkingClient.LocalPlayer.ActorNumber && !NetworkingClient.LocalPlayer.IsMasterClient)
		{
			UnityEngine.Debug.LogError("Cannot remove cached RPCs on a PhotonView thats not ours! " + view.Owner?.ToString() + " scene: " + view.IsRoomView);
		}
		else
		{
			OpCleanRpcBuffer(view);
		}
	}

	public static void OpCleanRpcBuffer(PhotonView view)
	{
		rpcFilterByViewId[keyByteZero] = view.ViewID;
		RaiseEventInternal(200, rpcFilterByViewId, OpCleanRpcBufferOptions, SendOptions.SendReliable);
	}

	public static void RemoveRPCsInGroup(int group)
	{
		foreach (PhotonView value in photonViewList.Values)
		{
			if (value.Group == group)
			{
				CleanRpcBufferIfMine(value);
			}
		}
	}

	public static bool RemoveBufferedRPCs(int viewId = 0, string methodName = null, int[] callersActorNumbers = null)
	{
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable(2);
		if (viewId != 0)
		{
			hashtable[keyByteZero] = viewId;
		}
		if (!string.IsNullOrEmpty(methodName))
		{
			if (rpcShortcuts.TryGetValue(methodName, out var value))
			{
				hashtable[keyByteFive] = (byte)value;
			}
			else
			{
				hashtable[keyByteThree] = methodName;
			}
		}
		RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
		raiseEventOptions.CachingOption = EventCaching.RemoveFromRoomCache;
		if (callersActorNumbers != null)
		{
			raiseEventOptions.TargetActors = callersActorNumbers;
		}
		return RaiseEventInternal(200, hashtable, raiseEventOptions, SendOptions.SendReliable);
	}

	public static void SetLevelPrefix(byte prefix)
	{
		currentLevelPrefix = prefix;
	}

	internal static void RPC(PhotonView view, string methodName, RpcTarget target, Player player, bool encrypt, params object[] parameters)
	{
		if (blockedSendingGroups.Contains(view.Group))
		{
			return;
		}
		if (view.ViewID < 1)
		{
			UnityEngine.Debug.LogError("Illegal view ID:" + view.ViewID + " method: " + methodName + " GO:" + view.gameObject.name);
		}
		if (LogLevel >= PunLogLevel.Full)
		{
			UnityEngine.Debug.Log("Sending RPC \"" + methodName + "\" to target: " + target.ToString() + " or player:" + player?.ToString() + ".");
		}
		rpcEvent.Clear();
		rpcEvent[keyByteZero] = view.ViewID;
		if (view.Prefix > 0)
		{
			rpcEvent[keyByteOne] = (short)view.Prefix;
		}
		rpcEvent[keyByteTwo] = ServerTimestamp;
		int value = 0;
		if (rpcShortcuts.TryGetValue(methodName, out value))
		{
			rpcEvent[keyByteFive] = (byte)value;
		}
		else
		{
			rpcEvent[keyByteThree] = methodName;
		}
		if (parameters != null && parameters.Length != 0)
		{
			rpcEvent[keyByteFour] = parameters;
		}
		SendOptions sendOptions = new SendOptions
		{
			Reliability = true,
			Encrypt = encrypt
		};
		if (player != null)
		{
			if (NetworkingClient.LocalPlayer.ActorNumber == player.ActorNumber)
			{
				ExecuteRpc(rpcEvent, player);
				return;
			}
			RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
			raiseEventOptions.TargetActors = new int[1] { player.ActorNumber };
			RaiseEventOptions raiseEventOptions2 = raiseEventOptions;
			RaiseEventInternal(200, rpcEvent, raiseEventOptions2, sendOptions);
			return;
		}
		switch (target)
		{
		case RpcTarget.All:
			RpcOptionsToAll.InterestGroup = view.Group;
			RaiseEventInternal(200, rpcEvent, RpcOptionsToAll, sendOptions);
			ExecuteRpc(rpcEvent, NetworkingClient.LocalPlayer);
			break;
		case RpcTarget.Others:
		{
			RaiseEventOptions raiseEventOptions8 = new RaiseEventOptions
			{
				InterestGroup = view.Group
			};
			RaiseEventInternal(200, rpcEvent, raiseEventOptions8, sendOptions);
			break;
		}
		case RpcTarget.AllBuffered:
		{
			RaiseEventOptions raiseEventOptions6 = new RaiseEventOptions
			{
				CachingOption = EventCaching.AddToRoomCache
			};
			RaiseEventInternal(200, rpcEvent, raiseEventOptions6, sendOptions);
			ExecuteRpc(rpcEvent, NetworkingClient.LocalPlayer);
			break;
		}
		case RpcTarget.OthersBuffered:
		{
			RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
			{
				CachingOption = EventCaching.AddToRoomCache
			};
			RaiseEventInternal(200, rpcEvent, raiseEventOptions4, sendOptions);
			break;
		}
		case RpcTarget.MasterClient:
		{
			if (NetworkingClient.LocalPlayer.IsMasterClient)
			{
				ExecuteRpc(rpcEvent, NetworkingClient.LocalPlayer);
				break;
			}
			RaiseEventOptions raiseEventOptions7 = new RaiseEventOptions
			{
				Receivers = ReceiverGroup.MasterClient
			};
			RaiseEventInternal(200, rpcEvent, raiseEventOptions7, sendOptions);
			break;
		}
		case RpcTarget.AllViaServer:
		{
			RaiseEventOptions raiseEventOptions5 = new RaiseEventOptions
			{
				InterestGroup = view.Group,
				Receivers = ReceiverGroup.All
			};
			RaiseEventInternal(200, rpcEvent, raiseEventOptions5, sendOptions);
			if (OfflineMode)
			{
				ExecuteRpc(rpcEvent, NetworkingClient.LocalPlayer);
			}
			break;
		}
		case RpcTarget.AllBufferedViaServer:
		{
			RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
			{
				InterestGroup = view.Group,
				Receivers = ReceiverGroup.All,
				CachingOption = EventCaching.AddToRoomCache
			};
			RaiseEventInternal(200, rpcEvent, raiseEventOptions3, sendOptions);
			if (OfflineMode)
			{
				ExecuteRpc(rpcEvent, NetworkingClient.LocalPlayer);
			}
			break;
		}
		default:
			UnityEngine.Debug.LogError("Unsupported target enum: " + target);
			break;
		}
	}

	public static void SetInterestGroups(byte[] disableGroups, byte[] enableGroups)
	{
		if (disableGroups != null)
		{
			if (disableGroups.Length == 0)
			{
				allowedReceivingGroups.Clear();
			}
			else
			{
				for (int i = 0; i < disableGroups.Length; i++)
				{
					byte b = disableGroups[i];
					if (b <= 0)
					{
						UnityEngine.Debug.LogError("Error: PhotonNetwork.SetInterestGroups was called with an illegal group number: " + b + ". The Group number should be at least 1.");
					}
					else if (allowedReceivingGroups.Contains(b))
					{
						allowedReceivingGroups.Remove(b);
					}
				}
			}
		}
		if (enableGroups != null)
		{
			if (enableGroups.Length == 0)
			{
				for (byte b2 = 0; b2 < byte.MaxValue; b2++)
				{
					allowedReceivingGroups.Add(b2);
				}
				allowedReceivingGroups.Add(byte.MaxValue);
			}
			else
			{
				for (int j = 0; j < enableGroups.Length; j++)
				{
					byte b3 = enableGroups[j];
					if (b3 <= 0)
					{
						UnityEngine.Debug.LogError("Error: PhotonNetwork.SetInterestGroups was called with an illegal group number: " + b3 + ". The Group number should be at least 1.");
					}
					else
					{
						allowedReceivingGroups.Add(b3);
					}
				}
			}
		}
		if (!offlineMode)
		{
			NetworkingClient.OpChangeGroups(disableGroups, enableGroups);
		}
	}

	public static void SetSendingEnabled(byte group, bool enabled)
	{
		if (!enabled)
		{
			blockedSendingGroups.Add(group);
		}
		else
		{
			blockedSendingGroups.Remove(group);
		}
	}

	public static void SetSendingEnabled(byte[] disableGroups, byte[] enableGroups)
	{
		if (disableGroups != null)
		{
			foreach (byte item in disableGroups)
			{
				blockedSendingGroups.Add(item);
			}
		}
		if (enableGroups != null)
		{
			foreach (byte item2 in enableGroups)
			{
				blockedSendingGroups.Remove(item2);
			}
		}
	}

	internal static void NewSceneLoaded()
	{
		if (loadingLevelAndPausedNetwork)
		{
			_AsyncLevelLoadingOperation = null;
			loadingLevelAndPausedNetwork = false;
			IsMessageQueueRunning = true;
		}
		else
		{
			SetLevelInPropsIfSynced(SceneManagerHelper.ActiveSceneName);
		}
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, PhotonView> photonView in photonViewList)
		{
			if (photonView.Value == null)
			{
				list.Add(photonView.Key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			int key = list[i];
			photonViewList.Remove(key);
		}
		if (list.Count > 0 && LogLevel >= PunLogLevel.Informational)
		{
			UnityEngine.Debug.Log("New level loaded. Removed " + list.Count + " scene view IDs from last level.");
		}
	}

	internal static void RunViewUpdate()
	{
		if (OfflineMode || CurrentRoom == null || CurrentRoom.Players == null || CurrentRoom.Players.Count <= 1)
		{
			return;
		}
		NonAllocDictionary<int, PhotonView>.PairIterator enumerator = photonViewList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			PhotonView value = enumerator.Current.Value;
			if (value.Synchronization == ViewSynchronization.Off || !value.IsMine || !value.isActiveAndEnabled || blockedSendingGroups.Contains(value.Group))
			{
				continue;
			}
			List<object> list = OnSerializeWrite(value);
			if (list != null)
			{
				RaiseEventBatch raiseEventBatch = new RaiseEventBatch
				{
					Reliable = (value.Synchronization == ViewSynchronization.ReliableDeltaCompressed || value.mixedModeIsReliable),
					Group = value.Group
				};
				SerializeViewBatch value2 = null;
				if (!serializeViewBatches.TryGetValue(raiseEventBatch, out value2))
				{
					value2 = new SerializeViewBatch(raiseEventBatch, 2);
					serializeViewBatches.Add(raiseEventBatch, value2);
				}
				value2.Add(list);
				if (value2.ObjectUpdates.Count == value2.ObjectUpdates.Capacity)
				{
					SendSerializeViewBatch(value2);
				}
			}
		}
		Dictionary<RaiseEventBatch, SerializeViewBatch>.Enumerator enumerator2 = serializeViewBatches.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			SendSerializeViewBatch(enumerator2.Current.Value);
		}
	}

	private static void SendSerializeViewBatch(SerializeViewBatch batch)
	{
		if (batch != null && batch.ObjectUpdates.Count > 2)
		{
			serializeRaiseEvOptions.InterestGroup = batch.Batch.Group;
			batch.ObjectUpdates[0] = ServerTimestamp;
			batch.ObjectUpdates[1] = ((currentLevelPrefix != 0) ? ((object)currentLevelPrefix) : null);
			RaiseEventInternal((byte)(batch.Batch.Reliable ? 206 : 201), batch.ObjectUpdates, serializeRaiseEvOptions, batch.Batch.Reliable ? SendOptions.SendReliable : SendOptions.SendUnreliable);
			batch.Clear();
		}
	}

	private static List<object> OnSerializeWrite(PhotonView view)
	{
		if (view.Synchronization == ViewSynchronization.Off)
		{
			return null;
		}
		PhotonMessageInfo info = new PhotonMessageInfo(NetworkingClient.LocalPlayer, ServerTimestamp, view);
		if (view.syncValues == null)
		{
			view.syncValues = new List<object>();
		}
		view.syncValues.Clear();
		serializeStreamOut.SetWriteStream(view.syncValues);
		serializeStreamOut.SendNext(null);
		serializeStreamOut.SendNext(null);
		serializeStreamOut.SendNext(null);
		view.SerializeView(serializeStreamOut, info);
		if (serializeStreamOut.Count <= 3)
		{
			return null;
		}
		List<object> writeStream = serializeStreamOut.GetWriteStream();
		writeStream[0] = view.ViewID;
		writeStream[1] = false;
		writeStream[2] = null;
		if (view.Synchronization == ViewSynchronization.Unreliable)
		{
			return writeStream;
		}
		if (view.Synchronization == ViewSynchronization.UnreliableOnChange)
		{
			if (AlmostEquals(writeStream, view.lastOnSerializeDataSent))
			{
				if (view.mixedModeIsReliable)
				{
					return null;
				}
				view.mixedModeIsReliable = true;
				List<object> lastOnSerializeDataSent = view.lastOnSerializeDataSent;
				view.lastOnSerializeDataSent = writeStream;
				view.syncValues = lastOnSerializeDataSent;
			}
			else
			{
				view.mixedModeIsReliable = false;
				List<object> lastOnSerializeDataSent2 = view.lastOnSerializeDataSent;
				view.lastOnSerializeDataSent = writeStream;
				view.syncValues = lastOnSerializeDataSent2;
			}
			return writeStream;
		}
		if (view.Synchronization == ViewSynchronization.ReliableDeltaCompressed)
		{
			List<object> result = DeltaCompressionWrite(view.lastOnSerializeDataSent, writeStream);
			List<object> lastOnSerializeDataSent3 = view.lastOnSerializeDataSent;
			view.lastOnSerializeDataSent = writeStream;
			view.syncValues = lastOnSerializeDataSent3;
			return result;
		}
		return null;
	}

	private static void OnSerializeRead(object[] data, Player sender, int networkTime, short correctPrefix)
	{
		int num = (int)data[0];
		PhotonView photonView = GetPhotonView(num);
		if (photonView == null)
		{
			int key = num / MAX_VIEW_IDS;
			if (CurrentRoom != null && CurrentRoom.Players.ContainsKey(key))
			{
				if (!cachedData.TryGetValue(key, out var value))
				{
					value = new Dictionary<int, Queue<object[]>>(5);
					cachedData[key] = value;
				}
				if (!value.TryGetValue(num, out var value2))
				{
					value2 = new Queue<object[]>();
					value.Add(num, value2);
				}
				if (value2.Count < 10)
				{
					value2.Enqueue(new object[4] { data, sender, networkTime, correctPrefix });
				}
			}
		}
		else if (photonView.Prefix > 0 && correctPrefix != photonView.Prefix)
		{
			UnityEngine.Debug.LogError("Received OnSerialization for view ID " + num + " with prefix " + correctPrefix + ". Our prefix is " + photonView.Prefix);
		}
		else
		{
			if (photonView.Group != 0 && !allowedReceivingGroups.Contains(photonView.Group))
			{
				return;
			}
			if (photonView.Synchronization == ViewSynchronization.ReliableDeltaCompressed)
			{
				object[] array = DeltaCompressionRead(photonView.lastOnSerializeDataReceived, data);
				if (array == null)
				{
					if (LogLevel >= PunLogLevel.Informational)
					{
						UnityEngine.Debug.Log("Skipping packet for " + photonView.name + " [" + photonView.ViewID + "] as we haven't received a full packet for delta compression yet. This is OK if it happens for the first few frames after joining a game.");
					}
					return;
				}
				photonView.lastOnSerializeDataReceived = array;
				data = array;
			}
			serializeStreamIn.SetReadStream(data, 3);
			photonView.DeserializeView(info: new PhotonMessageInfo(sender, networkTime, photonView), stream: serializeStreamIn);
		}
	}

	private static List<object> DeltaCompressionWrite(List<object> previousContent, List<object> currentContent)
	{
		if (currentContent == null || previousContent == null || previousContent.Count != currentContent.Count)
		{
			return currentContent;
		}
		if (currentContent.Count <= 3)
		{
			return null;
		}
		previousContent[1] = false;
		int num = 0;
		Queue<int> queue = null;
		for (int i = 3; i < currentContent.Count; i++)
		{
			object obj = currentContent[i];
			object two = previousContent[i];
			if (AlmostEquals(obj, two))
			{
				num++;
				previousContent[i] = null;
				continue;
			}
			previousContent[i] = obj;
			if (obj == null)
			{
				if (queue == null)
				{
					queue = new Queue<int>(currentContent.Count);
				}
				queue.Enqueue(i);
			}
		}
		if (num > 0)
		{
			if (num == currentContent.Count - 3)
			{
				return null;
			}
			previousContent[1] = true;
			if (queue != null)
			{
				previousContent[2] = queue.ToArray();
			}
		}
		previousContent[0] = currentContent[0];
		return previousContent;
	}

	private static object[] DeltaCompressionRead(object[] lastOnSerializeDataReceived, object[] incomingData)
	{
		if (!(bool)incomingData[1])
		{
			return incomingData;
		}
		if (lastOnSerializeDataReceived == null)
		{
			return null;
		}
		int[] array = incomingData[2] as int[];
		int num = lastOnSerializeDataReceived.Length;
		for (int i = 3; i < incomingData.Length; i++)
		{
			if ((array == null || !array.Contains(i)) && incomingData[i] == null && i < num)
			{
				object obj = lastOnSerializeDataReceived[i];
				incomingData[i] = obj;
			}
		}
		return incomingData;
	}

	private static bool AlmostEquals(IList<object> lastData, IList<object> currentContent)
	{
		if (lastData == null && currentContent == null)
		{
			return true;
		}
		if (lastData == null || currentContent == null || lastData.Count != currentContent.Count)
		{
			return false;
		}
		for (int i = 0; i < currentContent.Count; i++)
		{
			object one = currentContent[i];
			object two = lastData[i];
			if (!AlmostEquals(one, two))
			{
				return false;
			}
		}
		return true;
	}

	private static bool AlmostEquals(object one, object two)
	{
		if (one == null || two == null)
		{
			if (one == null)
			{
				return two == null;
			}
			return false;
		}
		if (!one.Equals(two))
		{
			if (one is object target)
			{
				Vector3 second = (Vector3)two;
				if (((Vector3)target).AlmostEquals(second, PrecisionForVectorSynchronization))
				{
					return true;
				}
			}
			else if (one is object target2)
			{
				Vector2 second2 = (Vector2)two;
				if (((Vector2)target2).AlmostEquals(second2, PrecisionForVectorSynchronization))
				{
					return true;
				}
			}
			else if (one is object target3)
			{
				Quaternion second3 = (Quaternion)two;
				if (((Quaternion)target3).AlmostEquals(second3, PrecisionForQuaternionSynchronization))
				{
					return true;
				}
			}
			else if (one is float target4)
			{
				float second4 = (float)two;
				if (target4.AlmostEquals(second4, PrecisionForFloatSynchronization))
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}

	internal static bool GetMethod(MonoBehaviour monob, string methodType, out MethodInfo mi)
	{
		mi = null;
		if (monob == null || string.IsNullOrEmpty(methodType))
		{
			return false;
		}
		List<MethodInfo> methods = SupportClass.GetMethods(monob.GetType(), null);
		for (int i = 0; i < methods.Count; i++)
		{
			MethodInfo methodInfo = methods[i];
			if (methodInfo.Name.Equals(methodType))
			{
				mi = methodInfo;
				return true;
			}
		}
		return false;
	}

	internal static void LoadLevelIfSynced()
	{
		if (!AutomaticallySyncScene || IsMasterClient || CurrentRoom == null || !CurrentRoom.CustomProperties.ContainsKey("curScn"))
		{
			return;
		}
		object obj = CurrentRoom.CustomProperties["curScn"];
		if (obj is int)
		{
			if (SceneManagerHelper.ActiveSceneBuildIndex != (int)obj)
			{
				LoadLevel((int)obj);
			}
		}
		else if (obj is string && SceneManagerHelper.ActiveSceneName != (string)obj)
		{
			LoadLevel((string)obj);
		}
	}

	internal static void SetLevelInPropsIfSynced(object levelId)
	{
		if (!AutomaticallySyncScene || !IsMasterClient || CurrentRoom == null)
		{
			return;
		}
		if (levelId == null)
		{
			UnityEngine.Debug.LogError("Parameter levelId can't be null!");
			return;
		}
		if (CurrentRoom.CustomProperties.ContainsKey("curScn"))
		{
			object obj = CurrentRoom.CustomProperties["curScn"];
			if (levelId.Equals(obj))
			{
				return;
			}
			int activeSceneBuildIndex = SceneManagerHelper.ActiveSceneBuildIndex;
			string activeSceneName = SceneManagerHelper.ActiveSceneName;
			if ((levelId.Equals(activeSceneBuildIndex) && obj.Equals(activeSceneName)) || (levelId.Equals(activeSceneName) && obj.Equals(activeSceneBuildIndex)))
			{
				return;
			}
		}
		if (_AsyncLevelLoadingOperation != null)
		{
			if (!_AsyncLevelLoadingOperation.isDone)
			{
				UnityEngine.Debug.LogWarning("PUN cancels an ongoing async level load, as another scene should be loaded. Next scene to load: " + levelId);
			}
			_AsyncLevelLoadingOperation.allowSceneActivation = false;
			_AsyncLevelLoadingOperation = null;
		}
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		if (levelId is int)
		{
			hashtable["curScn"] = (int)levelId;
		}
		else if (levelId is string)
		{
			hashtable["curScn"] = (string)levelId;
		}
		else
		{
			UnityEngine.Debug.LogError("Parameter levelId must be int or string!");
		}
		CurrentRoom.SetCustomProperties(hashtable);
		SendAllOutgoingCommands();
	}

	private static void OnEvent(EventData photonEvent)
	{
		try
		{
			int sender = photonEvent.Sender;
			Player player = null;
			if (sender > 0 && NetworkingClient.CurrentRoom != null)
			{
				player = NetworkingClient.CurrentRoom.GetPlayer(sender);
			}
			switch (photonEvent.Code)
			{
			case byte.MaxValue:
				ResetPhotonViewsOnSerialize();
				break;
			case 200:
				ExecuteRpc(photonEvent.CustomData as ExitGames.Client.Photon.Hashtable, player);
				break;
			case 201:
			case 206:
			{
				if (!(photonEvent[245] is object[] array) || array.Length < 3)
				{
					break;
				}
				int networkTime = (int)array[0];
				short correctPrefix = (short)((array[1] != null) ? ((byte)array[1]) : 0);
				object[] array2 = null;
				for (int i = 2; i < array.Length && array[i] is object[] array3; i++)
				{
					if (array3.Length < 4)
					{
						break;
					}
					OnSerializeRead(array3, player, networkTime, correctPrefix);
				}
				break;
			}
			case 202:
				NetworkInstantiate((ExitGames.Client.Photon.Hashtable)photonEvent.CustomData, player);
				break;
			case 207:
			{
				if (!(photonEvent.CustomData is ExitGames.Client.Photon.Hashtable))
				{
					break;
				}
				ExitGames.Client.Photon.Hashtable hashtable = (ExitGames.Client.Photon.Hashtable)photonEvent.CustomData;
				if (hashtable != null)
				{
					int num = (int)hashtable[keyByteZero];
					if (num >= 0)
					{
						DestroyPlayerObjects(num, localOnly: true);
					}
					else
					{
						DestroyAll(localOnly: true);
					}
				}
				break;
			}
			case 254:
				if (CurrentRoom != null && CurrentRoom.AutoCleanUp && (player == null || !player.IsInactive))
				{
					DestroyPlayerObjects(sender, localOnly: true);
				}
				if (cachedData.ContainsKey(sender))
				{
					cachedData.Remove(sender);
				}
				break;
			case 204:
			{
				if (!(photonEvent.CustomData is ExitGames.Client.Photon.Hashtable))
				{
					break;
				}
				ExitGames.Client.Photon.Hashtable hashtable = (ExitGames.Client.Photon.Hashtable)photonEvent.CustomData;
				if (hashtable != null)
				{
					int key = (int)hashtable[keyByteZero];
					PhotonView val = null;
					if (photonViewList.TryGetValue(key, out val))
					{
						RemoveInstantiatedGO(val.gameObject, localOnly: true);
					}
				}
				break;
			}
			}
		}
		catch (Exception arg)
		{
			InternalEventError?.Invoke(photonEvent, arg);
		}
	}

	private static void OnOperation(OperationResponse opResponse)
	{
		switch (opResponse.OperationCode)
		{
		case 220:
			if (opResponse.ReturnCode != 0)
			{
				if (LogLevel >= PunLogLevel.Full)
				{
					UnityEngine.Debug.Log("OpGetRegions failed. Will not ping any. ReturnCode: " + opResponse.ReturnCode);
				}
			}
			else if (ConnectMethod == ConnectMethod.ConnectToBest)
			{
				string bestRegionSummaryInPreferences = BestRegionSummaryInPreferences;
				if (LogLevel >= PunLogLevel.Informational)
				{
					UnityEngine.Debug.Log("PUN got region list. Going to ping minimum regions, based on this previous result summary: " + bestRegionSummaryInPreferences);
				}
				NetworkingClient.RegionHandler.PingMinimumOfRegions(OnRegionsPinged, bestRegionSummaryInPreferences);
			}
			break;
		case 226:
			if (Server == ServerConnection.GameServer)
			{
				LoadLevelIfSynced();
			}
			break;
		}
	}

	private static void OnClientStateChanged(ClientState previousState, ClientState state)
	{
		if ((previousState == ClientState.Joined && state == ClientState.Disconnected) || (Server == ServerConnection.GameServer && (state == ClientState.Disconnecting || state == ClientState.DisconnectingFromGameServer)))
		{
			LeftRoomCleanup();
		}
		if (state == ClientState.ConnectedToMasterServer && _cachedRegionHandler != null)
		{
			BestRegionSummaryInPreferences = _cachedRegionHandler.SummaryToCache;
			_cachedRegionHandler = null;
		}
	}

	private static void OnRegionsPinged(RegionHandler regionHandler)
	{
		if (LogLevel >= PunLogLevel.Informational)
		{
			UnityEngine.Debug.Log(regionHandler.GetResults());
		}
		_cachedRegionHandler = regionHandler;
		if (NetworkClientState == ClientState.ConnectedToNameServer)
		{
			NetworkingClient.ConnectToRegionMaster(regionHandler.BestRegion.Code);
		}
	}
}
public class PhotonStreamQueue
{
	private int m_SampleRate;

	private int m_SampleCount;

	private int m_ObjectsPerSample = -1;

	private float m_LastSampleTime = float.NegativeInfinity;

	private int m_LastFrameCount = -1;

	private int m_NextObjectIndex = -1;

	private List<object> m_Objects = new List<object>();

	private bool m_IsWriting;

	public PhotonStreamQueue(int sampleRate)
	{
		m_SampleRate = sampleRate;
	}

	private void BeginWritePackage()
	{
		if (Time.realtimeSinceStartup < m_LastSampleTime + 1f / (float)m_SampleRate)
		{
			m_IsWriting = false;
			return;
		}
		if (m_SampleCount == 1)
		{
			m_ObjectsPerSample = m_Objects.Count;
		}
		else if (m_SampleCount > 1 && m_Objects.Count / m_SampleCount != m_ObjectsPerSample)
		{
			UnityEngine.Debug.LogWarning("The number of objects sent via a PhotonStreamQueue has to be the same each frame");
			UnityEngine.Debug.LogWarning("Objects in List: " + m_Objects.Count + " / Sample Count: " + m_SampleCount + " = " + m_Objects.Count / m_SampleCount + " != " + m_ObjectsPerSample);
		}
		m_IsWriting = true;
		m_SampleCount++;
		m_LastSampleTime = Time.realtimeSinceStartup;
	}

	public void Reset()
	{
		m_SampleCount = 0;
		m_ObjectsPerSample = -1;
		m_LastSampleTime = float.NegativeInfinity;
		m_LastFrameCount = -1;
		m_Objects.Clear();
	}

	public void SendNext(object obj)
	{
		if (Time.frameCount != m_LastFrameCount)
		{
			BeginWritePackage();
		}
		m_LastFrameCount = Time.frameCount;
		if (m_IsWriting)
		{
			m_Objects.Add(obj);
		}
	}

	public bool HasQueuedObjects()
	{
		return m_NextObjectIndex != -1;
	}

	public object ReceiveNext()
	{
		if (m_NextObjectIndex == -1)
		{
			return null;
		}
		if (m_NextObjectIndex >= m_Objects.Count)
		{
			m_NextObjectIndex -= m_ObjectsPerSample;
		}
		return m_Objects[m_NextObjectIndex++];
	}

	public void Serialize(PhotonStream stream)
	{
		if (m_Objects.Count > 0 && m_ObjectsPerSample < 0)
		{
			m_ObjectsPerSample = m_Objects.Count;
		}
		stream.SendNext(m_SampleCount);
		stream.SendNext(m_ObjectsPerSample);
		for (int i = 0; i < m_Objects.Count; i++)
		{
			stream.SendNext(m_Objects[i]);
		}
		m_Objects.Clear();
		m_SampleCount = 0;
	}

	public void Deserialize(PhotonStream stream)
	{
		m_Objects.Clear();
		m_SampleCount = (int)stream.ReceiveNext();
		m_ObjectsPerSample = (int)stream.ReceiveNext();
		for (int i = 0; i < m_SampleCount * m_ObjectsPerSample; i++)
		{
			m_Objects.Add(stream.ReceiveNext());
		}
		if (m_Objects.Count > 0)
		{
			m_NextObjectIndex = 0;
		}
		else
		{
			m_NextObjectIndex = -1;
		}
	}
}
[AddComponentMenu("Photon Networking/Photon View")]
public class PhotonView : MonoBehaviour
{
	public enum ObservableSearch
	{
		Manual,
		AutoFindActive,
		AutoFindAll
	}

	private struct CallbackTargetChange(IPhotonViewCallback obj, Type type, bool add)
	{
		public IPhotonViewCallback obj = obj;

		public Type type = type;

		public bool add = add;
	}

	[FormerlySerializedAs("group")]
	public byte Group;

	[FormerlySerializedAs("prefixBackup")]
	public int prefixField = -1;

	internal object[] instantiationDataField;

	protected internal List<object> lastOnSerializeDataSent;

	protected internal List<object> syncValues;

	protected internal object[] lastOnSerializeDataReceived;

	[FormerlySerializedAs("synchronization")]
	public ViewSynchronization Synchronization = ViewSynchronization.UnreliableOnChange;

	protected internal bool mixedModeIsReliable;

	[FormerlySerializedAs("ownershipTransfer")]
	public OwnershipOption OwnershipTransfer;

	public ObservableSearch observableSearch;

	public List<UnityEngine.Component> ObservedComponents;

	internal MonoBehaviour[] RpcMonoBehaviours;

	[NonSerialized]
	private int ownerActorNr;

	[NonSerialized]
	private int controllerActorNr;

	[SerializeField]
	[FormerlySerializedAs("viewIdField")]
	[HideInInspector]
	public int sceneViewId;

	[NonSerialized]
	private int viewIdField;

	[FormerlySerializedAs("instantiationId")]
	public int InstantiationId;

	[SerializeField]
	[HideInInspector]
	public bool isRuntimeInstantiated;

	protected internal bool removedFromLocalViewList;

	private Queue<CallbackTargetChange> CallbackChangeQueue = new Queue<CallbackTargetChange>();

	private List<IOnPhotonViewPreNetDestroy> OnPreNetDestroyCallbacks;

	private List<IOnPhotonViewOwnerChange> OnOwnerChangeCallbacks;

	private List<IOnPhotonViewControllerChange> OnControllerChangeCallbacks;

	public int Prefix
	{
		get
		{
			if (prefixField == -1 && PhotonNetwork.NetworkingClient != null)
			{
				prefixField = PhotonNetwork.currentLevelPrefix;
			}
			return prefixField;
		}
		set
		{
			prefixField = value;
		}
	}

	public object[] InstantiationData
	{
		get
		{
			return instantiationDataField;
		}
		protected internal set
		{
			instantiationDataField = value;
		}
	}

	[Obsolete("Renamed. Use IsRoomView instead")]
	public bool IsSceneView => IsRoomView;

	public bool IsRoomView => CreatorActorNr == 0;

	public bool IsOwnerActive
	{
		get
		{
			if (Owner != null)
			{
				return !Owner.IsInactive;
			}
			return false;
		}
	}

	public bool IsMine { get; private set; }

	public bool AmController => IsMine;

	public Player Controller { get; private set; }

	public int CreatorActorNr { get; private set; }

	public bool AmOwner { get; private set; }

	public Player Owner { get; private set; }

	public int OwnerActorNr
	{
		get
		{
			return ownerActorNr;
		}
		set
		{
			if (value != 0 && ownerActorNr == value)
			{
				return;
			}
			Player owner = Owner;
			Owner = ((PhotonNetwork.CurrentRoom == null) ? null : PhotonNetwork.CurrentRoom.GetPlayer(value, findMaster: true));
			ownerActorNr = ((Owner != null) ? Owner.ActorNumber : value);
			AmOwner = PhotonNetwork.LocalPlayer != null && ownerActorNr == PhotonNetwork.LocalPlayer.ActorNumber;
			UpdateCallbackLists();
			if (OnOwnerChangeCallbacks != null)
			{
				int i = 0;
				for (int count = OnOwnerChangeCallbacks.Count; i < count; i++)
				{
					OnOwnerChangeCallbacks[i].OnOwnerChange(Owner, owner);
				}
			}
		}
	}

	public int ControllerActorNr
	{
		get
		{
			return controllerActorNr;
		}
		set
		{
			Player controller = Controller;
			Controller = ((PhotonNetwork.CurrentRoom == null) ? null : PhotonNetwork.CurrentRoom.GetPlayer(value, findMaster: true));
			if (Controller != null && Controller.IsInactive)
			{
				Controller = PhotonNetwork.MasterClient;
			}
			controllerActorNr = ((Controller != null) ? Controller.ActorNumber : value);
			IsMine = PhotonNetwork.LocalPlayer != null && controllerActorNr == PhotonNetwork.LocalPlayer.ActorNumber;
			if (Controller == controller)
			{
				return;
			}
			UpdateCallbackLists();
			if (OnControllerChangeCallbacks != null)
			{
				int i = 0;
				for (int count = OnControllerChangeCallbacks.Count; i < count; i++)
				{
					OnControllerChangeCallbacks[i].OnControllerChange(Controller, controller);
				}
			}
		}
	}

	public int ViewID
	{
		get
		{
			return viewIdField;
		}
		set
		{
			if (value != 0 && viewIdField != 0)
			{
				UnityEngine.Debug.LogWarning("Changing a ViewID while it's in use is not possible (except setting it to 0 (not being used). Current ViewID: " + viewIdField);
				return;
			}
			if (value == 0 && viewIdField != 0)
			{
				PhotonNetwork.LocalCleanPhotonView(this);
			}
			viewIdField = value;
			CreatorActorNr = value / PhotonNetwork.MAX_VIEW_IDS;
			OwnerActorNr = CreatorActorNr;
			ControllerActorNr = CreatorActorNr;
			RebuildControllerCache();
			if (value != 0)
			{
				PhotonNetwork.RegisterPhotonView(this);
			}
		}
	}

	protected internal void Awake()
	{
		if (ViewID == 0)
		{
			if (sceneViewId != 0)
			{
				ViewID = sceneViewId;
			}
			FindObservables();
		}
	}

	internal void ResetPhotonView(bool resetOwner)
	{
		lastOnSerializeDataSent = null;
	}

	internal void RebuildControllerCache(bool ownerHasChanged = false)
	{
		if (controllerActorNr == 0 || OwnerActorNr == 0 || Owner == null || Owner.IsInactive)
		{
			int num = (ControllerActorNr = PhotonNetwork.MasterClient?.ActorNumber ?? (-1));
			OwnerActorNr = num;
		}
		else
		{
			ControllerActorNr = OwnerActorNr;
		}
	}

	public void OnPreNetDestroy(PhotonView rootView)
	{
		UpdateCallbackLists();
		if (OnPreNetDestroyCallbacks != null)
		{
			int i = 0;
			for (int count = OnPreNetDestroyCallbacks.Count; i < count; i++)
			{
				OnPreNetDestroyCallbacks[i].OnPreNetDestroy(rootView);
			}
		}
	}

	protected internal void OnDestroy()
	{
		if (!removedFromLocalViewList && PhotonNetwork.LocalCleanPhotonView(this) && InstantiationId > 0 && !ConnectionHandler.AppQuits && PhotonNetwork.LogLevel >= PunLogLevel.Informational)
		{
			UnityEngine.Debug.Log("PUN-instantiated '" + base.gameObject.name + "' got destroyed by engine. This is OK when loading levels. Otherwise use: PhotonNetwork.Destroy().");
		}
	}

	[Obsolete("Use RequestableOwnershipGuard")]
	public void RequestOwnership()
	{
	}

	[Obsolete("Use RequestableOwnershipGuard")]
	public void TransferOwnership(Player newOwner)
	{
	}

	[Obsolete("Use RequestableOwnershipGuard")]
	public void TransferOwnership(int newOwnerId)
	{
	}

	public void FindObservables(bool force = false)
	{
		if (force || observableSearch != ObservableSearch.Manual)
		{
			if (ObservedComponents == null)
			{
				ObservedComponents = new List<UnityEngine.Component>();
			}
			else
			{
				ObservedComponents.Clear();
			}
			base.transform.GetNestedComponentsInChildren<UnityEngine.Component, IPunObservable, PhotonView>(force || observableSearch == ObservableSearch.AutoFindAll, ObservedComponents);
		}
	}

	public void SerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (ObservedComponents == null || ObservedComponents.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < ObservedComponents.Count; i++)
		{
			if (ObservedComponents[i] != null)
			{
				SerializeComponent(ObservedComponents[i], stream, info);
			}
		}
	}

	public void DeserializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (ObservedComponents == null || ObservedComponents.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < ObservedComponents.Count; i++)
		{
			UnityEngine.Component component = ObservedComponents[i];
			if (component != null)
			{
				DeserializeComponent(component, stream, info);
			}
		}
	}

	protected internal void DeserializeComponent(UnityEngine.Component component, PhotonStream stream, PhotonMessageInfo info)
	{
		if (component is IPunObservable punObservable)
		{
			punObservable.OnPhotonSerializeView(stream, info);
		}
		else
		{
			UnityEngine.Debug.LogError("Observed scripts have to implement IPunObservable. " + component?.ToString() + " does not. It is Type: " + component.GetType(), component.gameObject);
		}
	}

	protected internal void SerializeComponent(UnityEngine.Component component, PhotonStream stream, PhotonMessageInfo info)
	{
		if (component is IPunObservable punObservable)
		{
			punObservable.OnPhotonSerializeView(stream, info);
		}
		else
		{
			UnityEngine.Debug.LogError("Observed scripts have to implement IPunObservable. " + component?.ToString() + " does not. It is Type: " + component.GetType(), component.gameObject);
		}
	}

	public void RefreshRpcMonoBehaviourCache()
	{
		RpcMonoBehaviours = GetComponents<MonoBehaviour>();
	}

	public void RPC(string methodName, RpcTarget target, params object[] parameters)
	{
		PhotonNetwork.RPC(this, methodName, target, encrypt: false, parameters);
	}

	public void RpcSecure(string methodName, RpcTarget target, bool encrypt, params object[] parameters)
	{
		PhotonNetwork.RPC(this, methodName, target, encrypt, parameters);
	}

	public void RPC(string methodName, Player targetPlayer, params object[] parameters)
	{
		PhotonNetwork.RPC(this, methodName, targetPlayer, encrypt: false, parameters);
	}

	public void RpcSecure(string methodName, Player targetPlayer, bool encrypt, params object[] parameters)
	{
		PhotonNetwork.RPC(this, methodName, targetPlayer, encrypt, parameters);
	}

	public static PhotonView Get(UnityEngine.Component component)
	{
		return component.transform.GetParentComponent<PhotonView>();
	}

	public static PhotonView Get(GameObject gameObj)
	{
		return gameObj.transform.GetParentComponent<PhotonView>();
	}

	public static PhotonView Find(int viewID)
	{
		return PhotonNetwork.GetPhotonView(viewID);
	}

	public void AddCallbackTarget(IPhotonViewCallback obj)
	{
		CallbackChangeQueue.Enqueue(new CallbackTargetChange(obj, null, add: true));
	}

	public void RemoveCallbackTarget(IPhotonViewCallback obj)
	{
		CallbackChangeQueue.Enqueue(new CallbackTargetChange(obj, null, add: false));
	}

	public void AddCallback<T>(IPhotonViewCallback obj) where T : class, IPhotonViewCallback
	{
		CallbackChangeQueue.Enqueue(new CallbackTargetChange(obj, typeof(T), add: true));
	}

	public void RemoveCallback<T>(IPhotonViewCallback obj) where T : class, IPhotonViewCallback
	{
		CallbackChangeQueue.Enqueue(new CallbackTargetChange(obj, typeof(T), add: false));
	}

	private void UpdateCallbackLists()
	{
		while (CallbackChangeQueue.Count > 0)
		{
			CallbackTargetChange callbackTargetChange = CallbackChangeQueue.Dequeue();
			IPhotonViewCallback obj = callbackTargetChange.obj;
			Type type = callbackTargetChange.type;
			bool add = callbackTargetChange.add;
			if (type == null)
			{
				TryRegisterCallback(obj, ref OnPreNetDestroyCallbacks, add);
				TryRegisterCallback(obj, ref OnOwnerChangeCallbacks, add);
				TryRegisterCallback(obj, ref OnControllerChangeCallbacks, add);
			}
			else if (type == typeof(IOnPhotonViewPreNetDestroy))
			{
				RegisterCallback(obj as IOnPhotonViewPreNetDestroy, ref OnPreNetDestroyCallbacks, add);
			}
			else if (type == typeof(IOnPhotonViewOwnerChange))
			{
				RegisterCallback(obj as IOnPhotonViewOwnerChange, ref OnOwnerChangeCallbacks, add);
			}
			else if (type == typeof(IOnPhotonViewControllerChange))
			{
				RegisterCallback(obj as IOnPhotonViewControllerChange, ref OnControllerChangeCallbacks, add);
			}
		}
	}

	private void TryRegisterCallback<T>(IPhotonViewCallback obj, ref List<T> list, bool add) where T : class, IPhotonViewCallback
	{
		if (obj is T obj2)
		{
			RegisterCallback(obj2, ref list, add);
		}
	}

	private void RegisterCallback<T>(T obj, ref List<T> list, bool add) where T : class, IPhotonViewCallback
	{
		if (list == null)
		{
			list = new List<T>();
		}
		if (add)
		{
			if (!list.Contains(obj))
			{
				list.Add(obj);
			}
		}
		else if (list.Contains(obj))
		{
			list.Remove(obj);
		}
	}

	public override string ToString()
	{
		return string.Format("View {0}{3} on {1} {2}", ViewID, (base.gameObject != null) ? base.gameObject.name : "GO==null", IsRoomView ? "(scene)" : string.Empty, (Prefix > 0) ? ("lvl" + Prefix) : "");
	}
}
public class PunRPC : Attribute
{
}
public class MonoBehaviourPun : MonoBehaviour
{
	private PhotonView pvCache;

	public PhotonView photonView
	{
		get
		{
			if (pvCache == null)
			{
				pvCache = PhotonView.Get(this);
			}
			return pvCache;
		}
	}
}
public class MonoBehaviourPunCallbacks : MonoBehaviourPun, IConnectionCallbacks, IMatchmakingCallbacks, IInRoomCallbacks, ILobbyCallbacks, IWebRpcCallback, IErrorInfoCallback
{
	public virtual void OnEnable()
	{
		PhotonNetwork.AddCallbackTarget(this);
	}

	public virtual void OnDisable()
	{
		PhotonNetwork.RemoveCallbackTarget(this);
	}

	public virtual void OnConnected()
	{
	}

	public virtual void OnLeftRoom()
	{
	}

	public virtual void OnMasterClientSwitched(Player newMasterClient)
	{
	}

	public virtual void OnCreateRoomFailed(short returnCode, string message)
	{
	}

	public virtual void OnJoinRoomFailed(short returnCode, string message)
	{
	}

	public virtual void OnCreatedRoom()
	{
	}

	public virtual void OnJoinedLobby()
	{
	}

	public virtual void OnLeftLobby()
	{
	}

	public virtual void OnDisconnected(DisconnectCause cause)
	{
	}

	public virtual void OnRegionListReceived(RegionHandler regionHandler)
	{
	}

	public virtual void OnRoomListUpdate(List<RoomInfo> roomList)
	{
	}

	public virtual void OnJoinedRoom()
	{
	}

	public virtual void OnPlayerEnteredRoom(Player newPlayer)
	{
	}

	public virtual void OnPlayerLeftRoom(Player otherPlayer)
	{
	}

	public virtual void OnJoinRandomFailed(short returnCode, string message)
	{
	}

	public virtual void OnConnectedToMaster()
	{
	}

	public virtual void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
	{
	}

	public virtual void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
	{
	}

	public virtual void OnFriendListUpdate(List<FriendInfo> friendList)
	{
	}

	public virtual void OnCustomAuthenticationResponse(Dictionary<string, object> data)
	{
	}

	public virtual void OnCustomAuthenticationFailed(string debugMessage)
	{
	}

	public virtual void OnWebRpcResponse(OperationResponse response)
	{
	}

	public virtual void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
	{
	}

	public virtual void OnErrorInfo(ErrorInfo errorInfo)
	{
	}

	public virtual void OnPreLeavingRoom()
	{
	}
}
public struct PhotonMessageInfo(Player player, int timestamp, PhotonView view)
{
	private readonly int timeInt = timestamp;

	public readonly Player Sender = player;

	public readonly PhotonView photonView = view;

	[Obsolete("Use SentServerTime instead.")]
	public double timestamp => (double)(uint)timeInt / 1000.0;

	public double SentServerTime => (double)(uint)timeInt / 1000.0;

	public int SentServerTimestamp => timeInt;

	public override string ToString()
	{
		return string.Format("[PhotonMessageInfo: Sender='{1}' Senttime={0}]", SentServerTime, Sender);
	}
}
public class PunEvent
{
	public const byte RPC = 200;

	public const byte SendSerialize = 201;

	public const byte Instantiation = 202;

	public const byte CloseConnection = 203;

	public const byte Destroy = 204;

	public const byte RemoveCachedRPCs = 205;

	public const byte SendSerializeReliable = 206;

	public const byte DestroyPlayer = 207;

	public const byte OwnershipRequest = 209;

	public const byte OwnershipTransfer = 210;

	public const byte VacantViewIds = 211;

	public const byte OwnershipUpdate = 212;
}
public class PhotonStream
{
	private List<object> writeData;

	private object[] readData;

	private int currentItem;

	public bool IsWriting { get; private set; }

	public bool IsReading => !IsWriting;

	public int Count
	{
		get
		{
			if (!IsWriting)
			{
				return readData.Length;
			}
			return writeData.Count;
		}
	}

	public PhotonStream(bool write, object[] incomingData)
	{
		IsWriting = write;
		if (!write && incomingData != null)
		{
			readData = incomingData;
		}
	}

	public void SetReadStream(object[] incomingData, int pos = 0)
	{
		readData = incomingData;
		currentItem = pos;
		IsWriting = false;
	}

	internal void SetWriteStream(List<object> newWriteData, int pos = 0)
	{
		if (pos != newWriteData.Count)
		{
			throw new Exception("SetWriteStream failed, because count does not match position value. pos: " + pos + " newWriteData.Count:" + newWriteData.Count);
		}
		writeData = newWriteData;
		currentItem = pos;
		IsWriting = true;
	}

	internal List<object> GetWriteStream()
	{
		return writeData;
	}

	[Obsolete("Either SET the writeData with an empty List or use Clear().")]
	internal void ResetWriteStream()
	{
		writeData.Clear();
	}

	public object ReceiveNext()
	{
		if (IsWriting)
		{
			UnityEngine.Debug.LogError("Error: you cannot read this stream that you are writing!");
			return null;
		}
		object result = readData[currentItem];
		currentItem++;
		return result;
	}

	public object PeekNext()
	{
		if (IsWriting)
		{
			UnityEngine.Debug.LogError("Error: you cannot read this stream that you are writing!");
			return null;
		}
		return readData[currentItem];
	}

	public void SendNext(object obj)
	{
		if (!IsWriting)
		{
			UnityEngine.Debug.LogError("Error: you cannot write/send to this stream that you are reading!");
		}
		else
		{
			writeData.Add(obj);
		}
	}

	[Obsolete("writeData is a list now. Use and re-use it directly.")]
	public bool CopyToListAndClear(List<object> target)
	{
		if (!IsWriting)
		{
			return false;
		}
		target.AddRange(writeData);
		writeData.Clear();
		return true;
	}

	public object[] ToArray()
	{
		if (!IsWriting)
		{
			return readData;
		}
		return writeData.ToArray();
	}

	public void Serialize(ref bool myBool)
	{
		if (IsWriting)
		{
			writeData.Add(myBool);
		}
		else if (readData.Length > currentItem)
		{
			myBool = (bool)readData[currentItem];
			currentItem++;
		}
	}

	public void Serialize(ref int myInt)
	{
		if (IsWriting)
		{
			writeData.Add(myInt);
		}
		else if (readData.Length > currentItem)
		{
			myInt = (int)readData[currentItem];
			currentItem++;
		}
	}

	public void Serialize(ref string value)
	{
		if (IsWriting)
		{
			writeData.Add(value);
		}
		else if (readData.Length > currentItem)
		{
			value = (string)readData[currentItem];
			currentItem++;
		}
	}

	public void Serialize(ref char value)
	{
		if (IsWriting)
		{
			writeData.Add(value);
		}
		else if (readData.Length > currentItem)
		{
			value = (char)readData[currentItem];
			currentItem++;
		}
	}

	public void Serialize(ref short value)
	{
		if (IsWriting)
		{
			writeData.Add(value);
		}
		else if (readData.Length > currentItem)
		{
			value = (short)readData[currentItem];
			currentItem++;
		}
	}

	public void Serialize(ref float obj)
	{
		if (IsWriting)
		{
			writeData.Add(obj);
		}
		else if (readData.Length > currentItem)
		{
			obj = (float)readData[currentItem];
			currentItem++;
		}
	}

	public void Serialize(ref Player obj)
	{
		if (IsWriting)
		{
			writeData.Add(obj);
		}
		else if (readData.Length > currentItem)
		{
			obj = (Player)readData[currentItem];
			currentItem++;
		}
	}

	public void Serialize(ref Vector3 obj)
	{
		if (IsWriting)
		{
			writeData.Add(obj);
		}
		else if (readData.Length > currentItem)
		{
			obj = (Vector3)readData[currentItem];
			currentItem++;
		}
	}

	public void Serialize(ref Vector2 obj)
	{
		if (IsWriting)
		{
			writeData.Add(obj);
		}
		else if (readData.Length > currentItem)
		{
			obj = (Vector2)readData[currentItem];
			currentItem++;
		}
	}

	public void Serialize(ref Quaternion obj)
	{
		if (IsWriting)
		{
			writeData.Add(obj);
		}
		else if (readData.Length > currentItem)
		{
			obj = (Quaternion)readData[currentItem];
			currentItem++;
		}
	}
}
public class SceneManagerHelper
{
	public static string ActiveSceneName => SceneManager.GetActiveScene().name;

	public static int ActiveSceneBuildIndex => SceneManager.GetActiveScene().buildIndex;
}
public class DefaultPool : IPunPrefabPool
{
	public readonly Dictionary<string, GameObject> ResourceCache = new Dictionary<string, GameObject>();

	GameObject IPunPrefabPool.Instantiate(string prefabId, Vector3 position, Quaternion rotation)
	{
		GameObject value = null;
		if (!ResourceCache.TryGetValue(prefabId, out value))
		{
			value = Resources.Load<GameObject>(prefabId);
			if (value == null)
			{
				UnityEngine.Debug.LogError("DefaultPool failed to load \"" + prefabId + "\". Make sure it's in a \"Resources\" folder. Or use a custom IPunPrefabPool.");
			}
			else
			{
				ResourceCache.Add(prefabId, value);
			}
		}
		bool activeSelf = value.activeSelf;
		if (activeSelf)
		{
			value.SetActive(value: false);
		}
		GameObject result = UnityEngine.Object.Instantiate(value, position, rotation);
		if (activeSelf)
		{
			value.SetActive(value: true);
		}
		return result;
	}

	public void Destroy(GameObject gameObject)
	{
		UnityEngine.Object.Destroy(gameObject);
	}
}
public static class PunExtensions
{
	public static Dictionary<MethodInfo, ParameterInfo[]> ParametersOfMethods = new Dictionary<MethodInfo, ParameterInfo[]>();

	public static ParameterInfo[] GetCachedParemeters(this MethodInfo mo)
	{
		if (!ParametersOfMethods.TryGetValue(mo, out var value))
		{
			value = mo.GetParameters();
			ParametersOfMethods[mo] = value;
		}
		return value;
	}

	public static PhotonView[] GetPhotonViewsInChildren(this GameObject go)
	{
		return go.GetComponentsInChildren<PhotonView>(includeInactive: true);
	}

	public static PhotonView GetPhotonView(this GameObject go)
	{
		return go.GetComponent<PhotonView>();
	}

	public static bool AlmostEquals(this Vector3 target, Vector3 second, float sqrMagnitudePrecision)
	{
		return (target - second).sqrMagnitude < sqrMagnitudePrecision;
	}

	public static bool AlmostEquals(this Vector2 target, Vector2 second, float sqrMagnitudePrecision)
	{
		return (target - second).sqrMagnitude < sqrMagnitudePrecision;
	}

	public static bool AlmostEquals(this Quaternion target, Quaternion second, float maxAngle)
	{
		return Quaternion.Angle(target, second) < maxAngle;
	}

	public static bool AlmostEquals(this float target, float second, float floatDiff)
	{
		return Mathf.Abs(target - second) < floatDiff;
	}

	public static bool CheckIsAssignableFrom(this Type to, Type from)
	{
		return to.IsAssignableFrom(from);
	}

	public static bool CheckIsInterface(this Type to)
	{
		return to.IsInterface;
	}
}
[Serializable]
[HelpURL("https://doc.photonengine.com/en-us/pun/v2/getting-started/initial-setup")]
public class ServerSettings : ScriptableObject
{
	[Tooltip("Core Photon Server/Cloud settings.")]
	public AppSettings AppSettings;

	[Tooltip("Developer build override for Best Region.")]
	public string DevRegion;

	[Tooltip("Log output by PUN.")]
	public PunLogLevel PunLogging;

	[Tooltip("Logs additional info for debugging.")]
	public bool EnableSupportLogger;

	[Tooltip("Enables apps to keep the connection without focus.")]
	public bool RunInBackground = true;

	[Tooltip("Simulates an online connection.\nPUN can be used as usual.")]
	public bool StartInOfflineMode;

	[Tooltip("RPC name list.\nUsed as shortcut when sending calls.")]
	public List<string> RpcList = new List<string>();

	public static string BestRegionSummaryInPreferences => PhotonNetwork.BestRegionSummaryInPreferences;

	public void UseCloud(string cloudAppid, string code = "")
	{
		AppSettings.AppIdRealtime = cloudAppid;
		AppSettings.Server = null;
		AppSettings.FixedRegion = (string.IsNullOrEmpty(code) ? null : code);
	}

	public static bool IsAppId(string val)
	{
		try
		{
			new Guid(val);
		}
		catch
		{
			return false;
		}
		return true;
	}

	public static void ResetBestRegionCodeInPreferences()
	{
		PhotonNetwork.BestRegionSummaryInPreferences = null;
	}

	public override string ToString()
	{
		return "ServerSettings: " + AppSettings.ToStringFull();
	}
}
public static class NestedComponentUtilities
{
	private static Queue<Transform> nodesQueue = new Queue<Transform>();

	public static Dictionary<Type, ICollection> searchLists = new Dictionary<Type, ICollection>();

	private static Stack<Transform> nodeStack = new Stack<Transform>();

	public static T EnsureRootComponentExists<T, NestedT>(this Transform transform) where T : UnityEngine.Component where NestedT : UnityEngine.Component
	{
		NestedT parentComponent = transform.GetParentComponent<NestedT>();
		if ((bool)parentComponent)
		{
			T component = parentComponent.GetComponent<T>();
			if ((bool)component)
			{
				return component;
			}
			return parentComponent.gameObject.AddComponent<T>();
		}
		return null;
	}

	public static T GetParentComponent<T>(this Transform t) where T : UnityEngine.Component
	{
		T component = t.GetComponent<T>();
		if ((bool)component)
		{
			return component;
		}
		Transform parent = t.parent;
		while ((bool)parent)
		{
			component = parent.GetComponent<T>();
			if ((bool)component)
			{
				return component;
			}
			parent = parent.parent;
		}
		return null;
	}

	public static void GetNestedComponentsInParents<T>(this Transform t, List<T> list) where T : UnityEngine.Component
	{
		list.Clear();
		while (t != null)
		{
			T component = t.GetComponent<T>();
			if ((bool)component)
			{
				list.Add(component);
			}
			t = t.parent;
		}
	}

	public static T GetNestedComponentInChildren<T, NestedT>(this Transform t, bool includeInactive) where T : class where NestedT : class
	{
		T component = t.GetComponent<T>();
		if (component != null)
		{
			return component;
		}
		nodesQueue.Clear();
		nodesQueue.Enqueue(t);
		while (nodesQueue.Count > 0)
		{
			Transform transform = nodesQueue.Dequeue();
			int i = 0;
			for (int childCount = transform.childCount; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((includeInactive || child.gameObject.activeSelf) && child.GetComponent<NestedT>() == null)
				{
					component = child.GetComponent<T>();
					if (component != null)
					{
						return component;
					}
					nodesQueue.Enqueue(child);
				}
			}
		}
		return component;
	}

	public static T GetNestedComponentInParent<T, NestedT>(this Transform t) where T : class where NestedT : class
	{
		T val = null;
		Transform transform = t;
		do
		{
			val = transform.GetComponent<T>();
			if (val != null)
			{
				return val;
			}
			if (transform.GetComponent<NestedT>() != null)
			{
				return null;
			}
			transform = transform.parent;
		}
		while ((object)transform != null);
		return null;
	}

	public static T GetNestedComponentInParents<T, NestedT>(this Transform t) where T : class where NestedT : class
	{
		T component = t.GetComponent<T>();
		if (component != null)
		{
			return component;
		}
		Transform parent = t.parent;
		while ((object)parent != null)
		{
			component = parent.GetComponent<T>();
			if (component != null)
			{
				return component;
			}
			if (parent.GetComponent<NestedT>() != null)
			{
				return null;
			}
			parent = parent.parent;
		}
		return null;
	}

	public static void GetNestedComponentsInParents<T, NestedT>(this Transform t, List<T> list) where T : class where NestedT : class
	{
		t.GetComponents(list);
		if (t.GetComponent<NestedT>() != null)
		{
			return;
		}
		Transform parent = t.parent;
		if ((object)parent == null)
		{
			return;
		}
		nodeStack.Clear();
		do
		{
			nodeStack.Push(parent);
			if (parent.GetComponent<NestedT>() != null)
			{
				break;
			}
			parent = parent.parent;
		}
		while ((object)parent != null);
		if (nodeStack.Count != 0)
		{
			Type typeFromHandle = typeof(T);
			List<T> list2;
			if (!searchLists.ContainsKey(typeFromHandle))
			{
				list2 = new List<T>();
				searchLists.Add(typeFromHandle, list2);
			}
			else
			{
				list2 = searchLists[typeFromHandle] as List<T>;
			}
			while (nodeStack.Count > 0)
			{
				nodeStack.Pop().GetComponents(list2);
				list.AddRange(list2);
			}
		}
	}

	public static List<T> GetNestedComponentsInChildren<T, NestedT>(this Transform t, List<T> list, bool includeInactive = true) where T : class where NestedT : class
	{
		Type typeFromHandle = typeof(T);
		List<T> list2;
		if (!searchLists.ContainsKey(typeFromHandle))
		{
			searchLists.Add(typeFromHandle, list2 = new List<T>());
		}
		else
		{
			list2 = searchLists[typeFromHandle] as List<T>;
		}
		nodesQueue.Clear();
		if (list == null)
		{
			list = new List<T>();
		}
		t.GetComponents(list);
		int i = 0;
		for (int childCount = t.childCount; i < childCount; i++)
		{
			Transform child = t.GetChild(i);
			if ((includeInactive || child.gameObject.activeSelf) && child.GetComponent<NestedT>() == null)
			{
				nodesQueue.Enqueue(child);
			}
		}
		while (nodesQueue.Count > 0)
		{
			Transform transform = nodesQueue.Dequeue();
			transform.GetComponents(list2);
			list.AddRange(list2);
			int j = 0;
			for (int childCount2 = transform.childCount; j < childCount2; j++)
			{
				Transform child2 = transform.GetChild(j);
				if ((includeInactive || child2.gameObject.activeSelf) && child2.GetComponent<NestedT>() == null)
				{
					nodesQueue.Enqueue(child2);
				}
			}
		}
		return list;
	}

	public static List<T> GetNestedComponentsInChildren<T>(this Transform t, List<T> list, bool includeInactive = true, params Type[] stopOn) where T : class
	{
		Type typeFromHandle = typeof(T);
		List<T> list2;
		if (!searchLists.ContainsKey(typeFromHandle))
		{
			searchLists.Add(typeFromHandle, list2 = new List<T>());
		}
		else
		{
			list2 = searchLists[typeFromHandle] as List<T>;
		}
		nodesQueue.Clear();
		t.GetComponents(list);
		int i = 0;
		for (int childCount = t.childCount; i < childCount; i++)
		{
			Transform child = t.GetChild(i);
			if (!includeInactive && !child.gameObject.activeSelf)
			{
				continue;
			}
			bool flag = false;
			int j = 0;
			for (int num = stopOn.Length; j < num; j++)
			{
				if ((object)child.GetComponent(stopOn[j]) != null)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				nodesQueue.Enqueue(child);
			}
		}
		while (nodesQueue.Count > 0)
		{
			Transform transform = nodesQueue.Dequeue();
			transform.GetComponents(list2);
			list.AddRange(list2);
			int k = 0;
			for (int childCount2 = transform.childCount; k < childCount2; k++)
			{
				Transform child2 = transform.GetChild(k);
				if (!includeInactive && !child2.gameObject.activeSelf)
				{
					continue;
				}
				bool flag2 = false;
				int l = 0;
				for (int num2 = stopOn.Length; l < num2; l++)
				{
					if ((object)child2.GetComponent(stopOn[l]) != null)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					nodesQueue.Enqueue(child2);
				}
			}
		}
		return list;
	}

	public static void GetNestedComponentsInChildren<T, SearchT, NestedT>(this Transform t, bool includeInactive, List<T> list) where T : class where SearchT : class
	{
		list.Clear();
		if (!includeInactive && !t.gameObject.activeSelf)
		{
			return;
		}
		Type typeFromHandle = typeof(SearchT);
		List<SearchT> list2;
		if (!searchLists.ContainsKey(typeFromHandle))
		{
			searchLists.Add(typeFromHandle, list2 = new List<SearchT>());
		}
		else
		{
			list2 = searchLists[typeFromHandle] as List<SearchT>;
		}
		nodesQueue.Clear();
		nodesQueue.Enqueue(t);
		while (nodesQueue.Count > 0)
		{
			Transform transform = nodesQueue.Dequeue();
			list2.Clear();
			transform.GetComponents(list2);
			foreach (SearchT item2 in list2)
			{
				if (item2 is T item)
				{
					list.Add(item);
				}
			}
			int i = 0;
			for (int childCount = transform.childCount; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((includeInactive || child.gameObject.activeSelf) && child.GetComponent<NestedT>() == null)
				{
					nodesQueue.Enqueue(child);
				}
			}
		}
	}
}
[AddComponentMenu("Photon Networking/Photon Animator View")]
public class PhotonAnimatorView : MonoBehaviourPun, IPunObservable
{
	public enum ParameterType
	{
		Float = 1,
		Int = 3,
		Bool = 4,
		Trigger = 9
	}

	public enum SynchronizeType
	{
		Disabled,
		Discrete,
		Continuous
	}

	[Serializable]
	public class SynchronizedParameter
	{
		public ParameterType Type;

		public SynchronizeType SynchronizeType;

		public string Name;
	}

	[Serializable]
	public class SynchronizedLayer
	{
		public SynchronizeType SynchronizeType;

		public int LayerIndex;
	}

	private bool TriggerUsageWarningDone;

	private Animator m_Animator;

	private PhotonStreamQueue m_StreamQueue = new PhotonStreamQueue(120);

	[HideInInspector]
	[SerializeField]
	private bool ShowLayerWeightsInspector = true;

	[HideInInspector]
	[SerializeField]
	private bool ShowParameterInspector = true;

	[HideInInspector]
	[SerializeField]
	private List<SynchronizedParameter> m_SynchronizeParameters = new List<SynchronizedParameter>();

	[HideInInspector]
	[SerializeField]
	private List<SynchronizedLayer> m_SynchronizeLayers = new List<SynchronizedLayer>();

	private Vector3 m_ReceiverPosition;

	private float m_LastDeserializeTime;

	private bool m_WasSynchronizeTypeChanged = true;

	private List<string> m_raisedDiscreteTriggersCache = new List<string>();

	private void Awake()
	{
		m_Animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (m_Animator.applyRootMotion && !base.photonView.IsMine && PhotonNetwork.IsConnected)
		{
			m_Animator.applyRootMotion = false;
		}
		if (!PhotonNetwork.InRoom || PhotonNetwork.CurrentRoom.PlayerCount <= 1)
		{
			m_StreamQueue.Reset();
		}
		else if (base.photonView.IsMine)
		{
			SerializeDataContinuously();
			CacheDiscreteTriggers();
		}
		else
		{
			DeserializeDataContinuously();
		}
	}

	public void CacheDiscreteTriggers()
	{
		for (int i = 0; i < m_SynchronizeParameters.Count; i++)
		{
			SynchronizedParameter synchronizedParameter = m_SynchronizeParameters[i];
			if (synchronizedParameter.SynchronizeType == SynchronizeType.Discrete && synchronizedParameter.Type == ParameterType.Trigger && m_Animator.GetBool(synchronizedParameter.Name) && synchronizedParameter.Type == ParameterType.Trigger)
			{
				m_raisedDiscreteTriggersCache.Add(synchronizedParameter.Name);
				break;
			}
		}
	}

	public bool DoesLayerSynchronizeTypeExist(int layerIndex)
	{
		return m_SynchronizeLayers.FindIndex((SynchronizedLayer item) => item.LayerIndex == layerIndex) != -1;
	}

	public bool DoesParameterSynchronizeTypeExist(string name)
	{
		return m_SynchronizeParameters.FindIndex((SynchronizedParameter item) => item.Name == name) != -1;
	}

	public List<SynchronizedLayer> GetSynchronizedLayers()
	{
		return m_SynchronizeLayers;
	}

	public List<SynchronizedParameter> GetSynchronizedParameters()
	{
		return m_SynchronizeParameters;
	}

	public SynchronizeType GetLayerSynchronizeType(int layerIndex)
	{
		int num = m_SynchronizeLayers.FindIndex((SynchronizedLayer item) => item.LayerIndex == layerIndex);
		if (num == -1)
		{
			return SynchronizeType.Disabled;
		}
		return m_SynchronizeLayers[num].SynchronizeType;
	}

	public SynchronizeType GetParameterSynchronizeType(string name)
	{
		int num = m_SynchronizeParameters.FindIndex((SynchronizedParameter item) => item.Name == name);
		if (num == -1)
		{
			return SynchronizeType.Disabled;
		}
		return m_SynchronizeParameters[num].SynchronizeType;
	}

	public void SetLayerSynchronized(int layerIndex, SynchronizeType synchronizeType)
	{
		if (Application.isPlaying)
		{
			m_WasSynchronizeTypeChanged = true;
		}
		int num = m_SynchronizeLayers.FindIndex((SynchronizedLayer item) => item.LayerIndex == layerIndex);
		if (num == -1)
		{
			m_SynchronizeLayers.Add(new SynchronizedLayer
			{
				LayerIndex = layerIndex,
				SynchronizeType = synchronizeType
			});
		}
		else
		{
			m_SynchronizeLayers[num].SynchronizeType = synchronizeType;
		}
	}

	public void SetParameterSynchronized(string name, ParameterType type, SynchronizeType synchronizeType)
	{
		if (Application.isPlaying)
		{
			m_WasSynchronizeTypeChanged = true;
		}
		int num = m_SynchronizeParameters.FindIndex((SynchronizedParameter item) => item.Name == name);
		if (num == -1)
		{
			m_SynchronizeParameters.Add(new SynchronizedParameter
			{
				Name = name,
				Type = type,
				SynchronizeType = synchronizeType
			});
		}
		else
		{
			m_SynchronizeParameters[num].SynchronizeType = synchronizeType;
		}
	}

	private void SerializeDataContinuously()
	{
		if (m_Animator == null)
		{
			return;
		}
		for (int i = 0; i < m_SynchronizeLayers.Count; i++)
		{
			if (m_SynchronizeLayers[i].SynchronizeType == SynchronizeType.Continuous)
			{
				m_StreamQueue.SendNext(m_Animator.GetLayerWeight(m_SynchronizeLayers[i].LayerIndex));
			}
		}
		for (int j = 0; j < m_SynchronizeParameters.Count; j++)
		{
			SynchronizedParameter synchronizedParameter = m_SynchronizeParameters[j];
			if (synchronizedParameter.SynchronizeType != SynchronizeType.Continuous)
			{
				continue;
			}
			switch (synchronizedParameter.Type)
			{
			case ParameterType.Bool:
				m_StreamQueue.SendNext(m_Animator.GetBool(synchronizedParameter.Name));
				break;
			case ParameterType.Float:
				m_StreamQueue.SendNext(m_Animator.GetFloat(synchronizedParameter.Name));
				break;
			case ParameterType.Int:
				m_StreamQueue.SendNext(m_Animator.GetInteger(synchronizedParameter.Name));
				break;
			case ParameterType.Trigger:
				if (!TriggerUsageWarningDone)
				{
					TriggerUsageWarningDone = true;
					UnityEngine.Debug.Log("PhotonAnimatorView: When using triggers, make sure this component is last in the stack.\nIf you still experience issues, implement triggers as a regular RPC \nor in custom IPunObservable component instead", this);
				}
				m_StreamQueue.SendNext(m_Animator.GetBool(synchronizedParameter.Name));
				break;
			}
		}
	}

	private void DeserializeDataContinuously()
	{
		if (!m_StreamQueue.HasQueuedObjects())
		{
			return;
		}
		for (int i = 0; i < m_SynchronizeLayers.Count; i++)
		{
			if (m_SynchronizeLayers[i].SynchronizeType == SynchronizeType.Continuous)
			{
				m_Animator.SetLayerWeight(m_SynchronizeLayers[i].LayerIndex, (float)m_StreamQueue.ReceiveNext());
			}
		}
		for (int j = 0; j < m_SynchronizeParameters.Count; j++)
		{
			SynchronizedParameter synchronizedParameter = m_SynchronizeParameters[j];
			if (synchronizedParameter.SynchronizeType == SynchronizeType.Continuous)
			{
				switch (synchronizedParameter.Type)
				{
				case ParameterType.Bool:
					m_Animator.SetBool(synchronizedParameter.Name, (bool)m_StreamQueue.ReceiveNext());
					break;
				case ParameterType.Float:
					m_Animator.SetFloat(synchronizedParameter.Name, (float)m_StreamQueue.ReceiveNext());
					break;
				case ParameterType.Int:
					m_Animator.SetInteger(synchronizedParameter.Name, (int)m_StreamQueue.ReceiveNext());
					break;
				case ParameterType.Trigger:
					m_Animator.SetBool(synchronizedParameter.Name, (bool)m_StreamQueue.ReceiveNext());
					break;
				}
			}
		}
	}

	private void SerializeDataDiscretly(PhotonStream stream)
	{
		for (int i = 0; i < m_SynchronizeLayers.Count; i++)
		{
			if (m_SynchronizeLayers[i].SynchronizeType == SynchronizeType.Discrete)
			{
				stream.SendNext(m_Animator.GetLayerWeight(m_SynchronizeLayers[i].LayerIndex));
			}
		}
		for (int j = 0; j < m_SynchronizeParameters.Count; j++)
		{
			SynchronizedParameter synchronizedParameter = m_SynchronizeParameters[j];
			if (synchronizedParameter.SynchronizeType != SynchronizeType.Discrete)
			{
				continue;
			}
			switch (synchronizedParameter.Type)
			{
			case ParameterType.Bool:
				stream.SendNext(m_Animator.GetBool(synchronizedParameter.Name));
				break;
			case ParameterType.Float:
				stream.SendNext(m_Animator.GetFloat(synchronizedParameter.Name));
				break;
			case ParameterType.Int:
				stream.SendNext(m_Animator.GetInteger(synchronizedParameter.Name));
				break;
			case ParameterType.Trigger:
				if (!TriggerUsageWarningDone)
				{
					TriggerUsageWarningDone = true;
					UnityEngine.Debug.Log("PhotonAnimatorView: When using triggers, make sure this component is last in the stack.\nIf you still experience issues, implement triggers as a regular RPC \nor in custom IPunObservable component instead", this);
				}
				stream.SendNext(m_raisedDiscreteTriggersCache.Contains(synchronizedParameter.Name));
				break;
			}
		}
		m_raisedDiscreteTriggersCache.Clear();
	}

	private void DeserializeDataDiscretly(PhotonStream stream)
	{
		for (int i = 0; i < m_SynchronizeLayers.Count; i++)
		{
			if (m_SynchronizeLayers[i].SynchronizeType == SynchronizeType.Discrete)
			{
				m_Animator.SetLayerWeight(m_SynchronizeLayers[i].LayerIndex, (float)stream.ReceiveNext());
			}
		}
		for (int j = 0; j < m_SynchronizeParameters.Count; j++)
		{
			SynchronizedParameter synchronizedParameter = m_SynchronizeParameters[j];
			if (synchronizedParameter.SynchronizeType != SynchronizeType.Discrete)
			{
				continue;
			}
			switch (synchronizedParameter.Type)
			{
			case ParameterType.Bool:
				if (!(stream.PeekNext() is bool))
				{
					return;
				}
				m_Animator.SetBool(synchronizedParameter.Name, (bool)stream.ReceiveNext());
				break;
			case ParameterType.Float:
				if (!(stream.PeekNext() is float))
				{
					return;
				}
				m_Animator.SetFloat(synchronizedParameter.Name, (float)stream.ReceiveNext());
				break;
			case ParameterType.Int:
				if (!(stream.PeekNext() is int))
				{
					return;
				}
				m_Animator.SetInteger(synchronizedParameter.Name, (int)stream.ReceiveNext());
				break;
			case ParameterType.Trigger:
				if (!(stream.PeekNext() is bool))
				{
					return;
				}
				if ((bool)stream.ReceiveNext())
				{
					m_Animator.SetTrigger(synchronizedParameter.Name);
				}
				break;
			}
		}
	}

	private void SerializeSynchronizationTypeState(PhotonStream stream)
	{
		byte[] array = new byte[m_SynchronizeLayers.Count + m_SynchronizeParameters.Count];
		for (int i = 0; i < m_SynchronizeLayers.Count; i++)
		{
			array[i] = (byte)m_SynchronizeLayers[i].SynchronizeType;
		}
		for (int j = 0; j < m_SynchronizeParameters.Count; j++)
		{
			array[m_SynchronizeLayers.Count + j] = (byte)m_SynchronizeParameters[j].SynchronizeType;
		}
		stream.SendNext(array);
	}

	private void DeserializeSynchronizationTypeState(PhotonStream stream)
	{
		byte[] array = (byte[])stream.ReceiveNext();
		for (int i = 0; i < m_SynchronizeLayers.Count; i++)
		{
			m_SynchronizeLayers[i].SynchronizeType = (SynchronizeType)array[i];
		}
		for (int j = 0; j < m_SynchronizeParameters.Count; j++)
		{
			m_SynchronizeParameters[j].SynchronizeType = (SynchronizeType)array[m_SynchronizeLayers.Count + j];
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (m_Animator == null)
		{
			return;
		}
		if (stream.IsWriting)
		{
			if (m_WasSynchronizeTypeChanged)
			{
				m_StreamQueue.Reset();
				SerializeSynchronizationTypeState(stream);
				m_WasSynchronizeTypeChanged = false;
			}
			m_StreamQueue.Serialize(stream);
			SerializeDataDiscretly(stream);
		}
		else
		{
			if (stream.PeekNext() is byte[])
			{
				DeserializeSynchronizationTypeState(stream);
			}
			m_StreamQueue.Deserialize(stream);
			DeserializeDataDiscretly(stream);
		}
	}
}
[RequireComponent(typeof(Rigidbody2D))]
[AddComponentMenu("Photon Networking/Photon Rigidbody 2D View")]
public class PhotonRigidbody2DView : MonoBehaviourPun, IPunObservable
{
	private float m_Distance;

	private float m_Angle;

	private Rigidbody2D m_Body;

	private Vector2 m_NetworkPosition;

	private float m_NetworkRotation;

	[HideInInspector]
	public bool m_SynchronizeVelocity = true;

	[HideInInspector]
	public bool m_SynchronizeAngularVelocity;

	[HideInInspector]
	public bool m_TeleportEnabled;

	[HideInInspector]
	public float m_TeleportIfDistanceGreaterThan = 3f;

	public void Awake()
	{
		m_Body = GetComponent<Rigidbody2D>();
		m_NetworkPosition = default(Vector2);
	}

	public void FixedUpdate()
	{
		if (!base.photonView.IsMine)
		{
			m_Body.position = Vector2.MoveTowards(m_Body.position, m_NetworkPosition, m_Distance * (1f / (float)PhotonNetwork.SerializationRate));
			m_Body.rotation = Mathf.MoveTowards(m_Body.rotation, m_NetworkRotation, m_Angle * (1f / (float)PhotonNetwork.SerializationRate));
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			stream.SendNext(m_Body.position);
			stream.SendNext(m_Body.rotation);
			if (m_SynchronizeVelocity)
			{
				stream.SendNext(m_Body.linearVelocity);
			}
			if (m_SynchronizeAngularVelocity)
			{
				stream.SendNext(m_Body.angularVelocity);
			}
			return;
		}
		m_NetworkPosition = (Vector2)stream.ReceiveNext();
		m_NetworkRotation = (float)stream.ReceiveNext();
		if (m_TeleportEnabled && Vector3.Distance(m_Body.position, m_NetworkPosition) > m_TeleportIfDistanceGreaterThan)
		{
			m_Body.position = m_NetworkPosition;
		}
		if (m_SynchronizeVelocity || m_SynchronizeAngularVelocity)
		{
			float num = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
			if (m_SynchronizeVelocity)
			{
				m_Body.linearVelocity = (Vector2)stream.ReceiveNext();
				m_NetworkPosition += m_Body.linearVelocity * num;
				m_Distance = Vector2.Distance(m_Body.position, m_NetworkPosition);
			}
			if (m_SynchronizeAngularVelocity)
			{
				m_Body.angularVelocity = (float)stream.ReceiveNext();
				m_NetworkRotation += m_Body.angularVelocity * num;
				m_Angle = Mathf.Abs(m_Body.rotation - m_NetworkRotation);
			}
		}
	}
}
[RequireComponent(typeof(Rigidbody))]
[AddComponentMenu("Photon Networking/Photon Rigidbody View")]
public class PhotonRigidbodyView : MonoBehaviourPun, IPunObservable
{
	private float m_Distance;

	private float m_Angle;

	private Rigidbody m_Body;

	private Vector3 m_NetworkPosition;

	private Quaternion m_NetworkRotation;

	[HideInInspector]
	public bool m_SynchronizeVelocity = true;

	[HideInInspector]
	public bool m_SynchronizeAngularVelocity;

	[HideInInspector]
	public bool m_TeleportEnabled;

	[HideInInspector]
	public float m_TeleportIfDistanceGreaterThan = 3f;

	public void Awake()
	{
		m_Body = GetComponent<Rigidbody>();
		m_NetworkPosition = default(Vector3);
		m_NetworkRotation = default(Quaternion);
	}

	public void FixedUpdate()
	{
		if (!base.photonView.IsMine)
		{
			m_Body.position = Vector3.MoveTowards(m_Body.position, m_NetworkPosition, m_Distance * (1f / (float)PhotonNetwork.SerializationRate));
			m_Body.rotation = Quaternion.RotateTowards(m_Body.rotation, m_NetworkRotation, m_Angle * (1f / (float)PhotonNetwork.SerializationRate));
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			stream.SendNext(m_Body.position);
			stream.SendNext(m_Body.rotation);
			if (m_SynchronizeVelocity)
			{
				stream.SendNext(m_Body.linearVelocity);
			}
			if (m_SynchronizeAngularVelocity)
			{
				stream.SendNext(m_Body.angularVelocity);
			}
			return;
		}
		m_NetworkPosition = (Vector3)stream.ReceiveNext();
		m_NetworkRotation = (Quaternion)stream.ReceiveNext();
		if (m_TeleportEnabled && Vector3.Distance(m_Body.position, m_NetworkPosition) > m_TeleportIfDistanceGreaterThan)
		{
			m_Body.position = m_NetworkPosition;
		}
		if (m_SynchronizeVelocity || m_SynchronizeAngularVelocity)
		{
			float num = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
			if (m_SynchronizeVelocity)
			{
				m_Body.linearVelocity = (Vector3)stream.ReceiveNext();
				m_NetworkPosition += m_Body.linearVelocity * num;
				m_Distance = Vector3.Distance(m_Body.position, m_NetworkPosition);
			}
			if (m_SynchronizeAngularVelocity)
			{
				m_Body.angularVelocity = (Vector3)stream.ReceiveNext();
				m_NetworkRotation = Quaternion.Euler(m_Body.angularVelocity * num) * m_NetworkRotation;
				m_Angle = Quaternion.Angle(m_Body.rotation, m_NetworkRotation);
			}
		}
	}
}
[AddComponentMenu("Photon Networking/Photon Transform View")]
[HelpURL("https://doc.photonengine.com/en-us/pun/v2/gameplay/synchronization-and-state")]
public class PhotonTransformView : MonoBehaviourPun, IPunObservable
{
	private float m_Distance;

	private float m_Angle;

	private Vector3 m_Direction;

	private Vector3 m_NetworkPosition;

	private Vector3 m_StoredPosition;

	private Quaternion m_NetworkRotation;

	public bool m_SynchronizePosition = true;

	public bool m_SynchronizeRotation = true;

	public bool m_SynchronizeScale;

	[Tooltip("Indicates if localPosition and localRotation should be used. Scale ignores this setting, and always uses localScale to avoid issues with lossyScale.")]
	public bool m_UseLocal;

	private bool m_firstTake;

	public void Awake()
	{
		m_StoredPosition = base.transform.localPosition;
		m_NetworkPosition = Vector3.zero;
		m_NetworkRotation = Quaternion.identity;
	}

	private void Reset()
	{
		m_UseLocal = true;
	}

	private void OnEnable()
	{
		m_firstTake = true;
	}

	public void Update()
	{
		Transform transform = base.transform;
		if (!base.photonView.IsMine && IsValid(m_NetworkPosition) && IsValid(m_NetworkRotation))
		{
			if (m_UseLocal)
			{
				transform.localPosition = Vector3.MoveTowards(transform.localPosition, m_NetworkPosition, m_Distance * Time.deltaTime * (float)PhotonNetwork.SerializationRate);
				transform.localRotation = Quaternion.RotateTowards(transform.localRotation, m_NetworkRotation, m_Angle * Time.deltaTime * (float)PhotonNetwork.SerializationRate);
			}
			else
			{
				transform.position = Vector3.MoveTowards(transform.position, m_NetworkPosition, m_Distance * Time.deltaTime * (float)PhotonNetwork.SerializationRate);
				transform.rotation = Quaternion.RotateTowards(transform.rotation, m_NetworkRotation, m_Angle * Time.deltaTime * (float)PhotonNetwork.SerializationRate);
			}
		}
	}

	private bool IsValid(Vector3 v)
	{
		if (!float.IsNaN(v.x) && !float.IsNaN(v.y) && !float.IsNaN(v.z) && !float.IsInfinity(v.x) && !float.IsInfinity(v.y))
		{
			return !float.IsInfinity(v.z);
		}
		return false;
	}

	private bool IsValid(Quaternion q)
	{
		if (!float.IsNaN(q.x) && !float.IsNaN(q.y) && !float.IsNaN(q.z) && !float.IsNaN(q.w) && !float.IsInfinity(q.x) && !float.IsInfinity(q.y) && !float.IsInfinity(q.z))
		{
			return !float.IsInfinity(q.w);
		}
		return false;
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		Transform transform = base.transform;
		if (stream.IsWriting)
		{
			if (m_SynchronizePosition)
			{
				if (m_UseLocal)
				{
					m_Direction = transform.localPosition - m_StoredPosition;
					m_StoredPosition = transform.localPosition;
					stream.SendNext(transform.localPosition);
					stream.SendNext(m_Direction);
				}
				else
				{
					m_Direction = transform.position - m_StoredPosition;
					m_StoredPosition = transform.position;
					stream.SendNext(transform.position);
					stream.SendNext(m_Direction);
				}
			}
			if (m_SynchronizeRotation)
			{
				if (m_UseLocal)
				{
					stream.SendNext(transform.localRotation);
				}
				else
				{
					stream.SendNext(transform.rotation);
				}
			}
			if (m_SynchronizeScale)
			{
				stream.SendNext(transform.localScale);
			}
			return;
		}
		if (m_SynchronizePosition)
		{
			m_NetworkPosition = (Vector3)stream.ReceiveNext();
			if (!IsValid(m_NetworkPosition))
			{
				m_NetworkPosition = Vector3.zero;
			}
			m_Direction = (Vector3)stream.ReceiveNext();
			if (!IsValid(m_Direction))
			{
				m_Direction = Vector3.zero;
			}
			if (m_firstTake)
			{
				if (m_UseLocal)
				{
					transform.localPosition = m_NetworkPosition;
				}
				else
				{
					transform.position = m_NetworkPosition;
				}
				m_Distance = 0f;
			}
			else
			{
				float num = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
				m_NetworkPosition += m_Direction * num;
				if (m_UseLocal)
				{
					m_Distance = Vector3.Distance(transform.localPosition, m_NetworkPosition);
				}
				else
				{
					m_Distance = Vector3.Distance(transform.position, m_NetworkPosition);
				}
			}
		}
		if (m_SynchronizeRotation)
		{
			m_NetworkRotation = (Quaternion)stream.ReceiveNext();
			if (!IsValid(m_NetworkRotation))
			{
				m_NetworkRotation = Quaternion.identity;
			}
			if (m_firstTake)
			{
				m_Angle = 0f;
				if (m_UseLocal)
				{
					transform.localRotation = m_NetworkRotation;
				}
				else
				{
					transform.rotation = m_NetworkRotation;
				}
			}
			else if (m_UseLocal)
			{
				m_Angle = Quaternion.Angle(transform.localRotation, m_NetworkRotation);
			}
			else
			{
				m_Angle = Quaternion.Angle(transform.rotation, m_NetworkRotation);
			}
		}
		if (m_SynchronizeScale)
		{
			transform.localScale = (Vector3)stream.ReceiveNext();
			if (!IsValid(transform.localScale))
			{
				transform.localScale = Vector3.one;
			}
		}
		if (m_firstTake)
		{
			m_firstTake = false;
		}
	}

	public void GTAddition_DoTeleport()
	{
		m_firstTake = true;
	}
}
[AddComponentMenu("Photon Networking/Photon Transform View Classic")]
public class PhotonTransformViewClassic : MonoBehaviourPun, IPunObservable
{
	[HideInInspector]
	public PhotonTransformViewPositionModel m_PositionModel = new PhotonTransformViewPositionModel();

	[HideInInspector]
	public PhotonTransformViewRotationModel m_RotationModel = new PhotonTransformViewRotationModel();

	[HideInInspector]
	public PhotonTransformViewScaleModel m_ScaleModel = new PhotonTransformViewScaleModel();

	private PhotonTransformViewPositionControl m_PositionControl;

	private PhotonTransformViewRotationControl m_RotationControl;

	private PhotonTransformViewScaleControl m_ScaleControl;

	private PhotonView m_PhotonView;

	private bool m_ReceivedNetworkUpdate;

	private bool m_firstTake;

	private void Awake()
	{
		m_PhotonView = GetComponent<PhotonView>();
		m_PositionControl = new PhotonTransformViewPositionControl(m_PositionModel);
		m_RotationControl = new PhotonTransformViewRotationControl(m_RotationModel);
		m_ScaleControl = new PhotonTransformViewScaleControl(m_ScaleModel);
	}

	private void OnEnable()
	{
		m_firstTake = true;
	}

	private void Update()
	{
		if (!(m_PhotonView == null) && !m_PhotonView.IsMine && PhotonNetwork.IsConnectedAndReady)
		{
			UpdatePosition();
			UpdateRotation();
			UpdateScale();
		}
	}

	private void UpdatePosition()
	{
		if (m_PositionModel.SynchronizeEnabled && m_ReceivedNetworkUpdate)
		{
			base.transform.localPosition = m_PositionControl.UpdatePosition(base.transform.localPosition);
		}
	}

	private void UpdateRotation()
	{
		if (m_RotationModel.SynchronizeEnabled && m_ReceivedNetworkUpdate)
		{
			base.transform.localRotation = m_RotationControl.GetRotation(base.transform.localRotation);
		}
	}

	private void UpdateScale()
	{
		if (m_ScaleModel.SynchronizeEnabled && m_ReceivedNetworkUpdate)
		{
			base.transform.localScale = m_ScaleControl.GetScale(base.transform.localScale);
		}
	}

	public void SetSynchronizedValues(Vector3 speed, float turnSpeed)
	{
		m_PositionControl.SetSynchronizedValues(speed, turnSpeed);
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		m_PositionControl.OnPhotonSerializeView(base.transform.localPosition, stream, info);
		m_RotationControl.OnPhotonSerializeView(base.transform.localRotation, stream, info);
		m_ScaleControl.OnPhotonSerializeView(base.transform.localScale, stream, info);
		if (!stream.IsReading)
		{
			return;
		}
		m_ReceivedNetworkUpdate = true;
		if (m_firstTake)
		{
			m_firstTake = false;
			if (m_PositionModel.SynchronizeEnabled)
			{
				base.transform.localPosition = m_PositionControl.GetNetworkPosition();
			}
			if (m_RotationModel.SynchronizeEnabled)
			{
				base.transform.localRotation = m_RotationControl.GetNetworkRotation();
			}
			if (m_ScaleModel.SynchronizeEnabled)
			{
				base.transform.localScale = m_ScaleControl.GetNetworkScale();
			}
		}
	}
}
[Serializable]
public class PhotonTransformViewPositionModel
{
	public enum InterpolateOptions
	{
		Disabled,
		FixedSpeed,
		EstimatedSpeed,
		SynchronizeValues,
		Lerp
	}

	public enum ExtrapolateOptions
	{
		Disabled,
		SynchronizeValues,
		EstimateSpeedAndTurn,
		FixedSpeed
	}

	public bool SynchronizeEnabled;

	public bool TeleportEnabled = true;

	public float TeleportIfDistanceGreaterThan = 3f;

	public InterpolateOptions InterpolateOption = InterpolateOptions.EstimatedSpeed;

	public float InterpolateMoveTowardsSpeed = 1f;

	public float InterpolateLerpSpeed = 1f;

	public ExtrapolateOptions ExtrapolateOption;

	public float ExtrapolateSpeed = 1f;

	public bool ExtrapolateIncludingRoundTripTime = true;

	public int ExtrapolateNumberOfStoredPositions = 1;
}
public class PhotonTransformViewPositionControl
{
	private PhotonTransformViewPositionModel m_Model;

	private float m_CurrentSpeed;

	private double m_LastSerializeTime;

	private Vector3 m_SynchronizedSpeed = Vector3.zero;

	private float m_SynchronizedTurnSpeed;

	private Vector3 m_NetworkPosition;

	private Queue<Vector3> m_OldNetworkPositions = new Queue<Vector3>();

	private bool m_UpdatedPositionAfterOnSerialize = true;

	public PhotonTransformViewPositionControl(PhotonTransformViewPositionModel model)
	{
		m_Model = model;
	}

	private Vector3 GetOldestStoredNetworkPosition()
	{
		Vector3 result = m_NetworkPosition;
		if (m_OldNetworkPositions.Count > 0)
		{
			result = m_OldNetworkPositions.Peek();
		}
		return result;
	}

	public void SetSynchronizedValues(Vector3 speed, float turnSpeed)
	{
		m_SynchronizedSpeed = speed;
		m_SynchronizedTurnSpeed = turnSpeed;
	}

	public Vector3 UpdatePosition(Vector3 currentPosition)
	{
		Vector3 vector = GetNetworkPosition() + GetExtrapolatedPositionOffset();
		switch (m_Model.InterpolateOption)
		{
		case PhotonTransformViewPositionModel.InterpolateOptions.Disabled:
			if (!m_UpdatedPositionAfterOnSerialize)
			{
				currentPosition = vector;
				m_UpdatedPositionAfterOnSerialize = true;
			}
			break;
		case PhotonTransformViewPositionModel.InterpolateOptions.FixedSpeed:
			currentPosition = Vector3.MoveTowards(currentPosition, vector, Time.deltaTime * m_Model.InterpolateMoveTowardsSpeed);
			break;
		case PhotonTransformViewPositionModel.InterpolateOptions.EstimatedSpeed:
			if (m_OldNetworkPositions.Count != 0)
			{
				float num = Vector3.Distance(m_NetworkPosition, GetOldestStoredNetworkPosition()) / (float)m_OldNetworkPositions.Count * (float)PhotonNetwork.SerializationRate;
				currentPosition = Vector3.MoveTowards(currentPosition, vector, Time.deltaTime * num);
			}
			break;
		case PhotonTransformViewPositionModel.InterpolateOptions.SynchronizeValues:
			currentPosition = ((m_SynchronizedSpeed.magnitude != 0f) ? Vector3.MoveTowards(currentPosition, vector, Time.deltaTime * m_SynchronizedSpeed.magnitude) : vector);
			break;
		case PhotonTransformViewPositionModel.InterpolateOptions.Lerp:
			currentPosition = Vector3.Lerp(currentPosition, vector, Time.deltaTime * m_Model.InterpolateLerpSpeed);
			break;
		}
		if (m_Model.TeleportEnabled && Vector3.Distance(currentPosition, GetNetworkPosition()) > m_Model.TeleportIfDistanceGreaterThan)
		{
			currentPosition = GetNetworkPosition();
		}
		return currentPosition;
	}

	public Vector3 GetNetworkPosition()
	{
		return m_NetworkPosition;
	}

	public Vector3 GetExtrapolatedPositionOffset()
	{
		float num = (float)(PhotonNetwork.Time - m_LastSerializeTime);
		if (m_Model.ExtrapolateIncludingRoundTripTime)
		{
			num += (float)PhotonNetwork.GetPing() / 1000f;
		}
		Vector3 result = Vector3.zero;
		switch (m_Model.ExtrapolateOption)
		{
		case PhotonTransformViewPositionModel.ExtrapolateOptions.SynchronizeValues:
			result = Quaternion.Euler(0f, m_SynchronizedTurnSpeed * num, 0f) * (m_SynchronizedSpeed * num);
			break;
		case PhotonTransformViewPositionModel.ExtrapolateOptions.FixedSpeed:
			result = (m_NetworkPosition - GetOldestStoredNetworkPosition()).normalized * m_Model.ExtrapolateSpeed * num;
			break;
		case PhotonTransformViewPositionModel.ExtrapolateOptions.EstimateSpeedAndTurn:
			result = (m_NetworkPosition - GetOldestStoredNetworkPosition()) * PhotonNetwork.SerializationRate * num;
			break;
		}
		return result;
	}

	public void OnPhotonSerializeView(Vector3 currentPosition, PhotonStream stream, PhotonMessageInfo info)
	{
		if (m_Model.SynchronizeEnabled)
		{
			if (stream.IsWriting)
			{
				SerializeData(currentPosition, stream, info);
			}
			else
			{
				DeserializeData(stream, info);
			}
			m_LastSerializeTime = PhotonNetwork.Time;
			m_UpdatedPositionAfterOnSerialize = false;
		}
	}

	private void SerializeData(Vector3 currentPosition, PhotonStream stream, PhotonMessageInfo info)
	{
		stream.SendNext(currentPosition);
		m_NetworkPosition = currentPosition;
		if (m_Model.ExtrapolateOption == PhotonTransformViewPositionModel.ExtrapolateOptions.SynchronizeValues || m_Model.InterpolateOption == PhotonTransformViewPositionModel.InterpolateOptions.SynchronizeValues)
		{
			stream.SendNext(m_SynchronizedSpeed);
			stream.SendNext(m_SynchronizedTurnSpeed);
		}
	}

	private void DeserializeData(PhotonStream stream, PhotonMessageInfo info)
	{
		Vector3 networkPosition = (Vector3)stream.ReceiveNext();
		if (m_Model.ExtrapolateOption == PhotonTransformViewPositionModel.ExtrapolateOptions.SynchronizeValues || m_Model.InterpolateOption == PhotonTransformViewPositionModel.InterpolateOptions.SynchronizeValues)
		{
			m_SynchronizedSpeed = (Vector3)stream.ReceiveNext();
			m_SynchronizedTurnSpeed = (float)stream.ReceiveNext();
		}
		if (m_OldNetworkPositions.Count == 0)
		{
			m_NetworkPosition = networkPosition;
		}
		m_OldNetworkPositions.Enqueue(m_NetworkPosition);
		m_NetworkPosition = networkPosition;
		while (m_OldNetworkPositions.Count > m_Model.ExtrapolateNumberOfStoredPositions)
		{
			m_OldNetworkPositions.Dequeue();
		}
	}
}
[Serializable]
public class PhotonTransformViewRotationModel
{
	public enum InterpolateOptions
	{
		Disabled,
		RotateTowards,
		Lerp
	}

	public bool SynchronizeEnabled;

	public InterpolateOptions InterpolateOption = InterpolateOptions.RotateTowards;

	public float InterpolateRotateTowardsSpeed = 180f;

	public float InterpolateLerpSpeed = 5f;
}
public class PhotonTransformViewRotationControl
{
	private PhotonTransformViewRotationModel m_Model;

	private Quaternion m_NetworkRotation;

	public PhotonTransformViewRotationControl(PhotonTransformViewRotationModel model)
	{
		m_Model = model;
	}

	public Quaternion GetNetworkRotation()
	{
		return m_NetworkRotation;
	}

	public Quaternion GetRotation(Quaternion currentRotation)
	{
		return m_Model.InterpolateOption switch
		{
			PhotonTransformViewRotationModel.InterpolateOptions.RotateTowards => Quaternion.RotateTowards(currentRotation, m_NetworkRotation, m_Model.InterpolateRotateTowardsSpeed * Time.deltaTime), 
			PhotonTransformViewRotationModel.InterpolateOptions.Lerp => Quaternion.Lerp(currentRotation, m_NetworkRotation, m_Model.InterpolateLerpSpeed * Time.deltaTime), 
			_ => m_NetworkRotation, 
		};
	}

	public void OnPhotonSerializeView(Quaternion currentRotation, PhotonStream stream, PhotonMessageInfo info)
	{
		if (m_Model.SynchronizeEnabled)
		{
			if (stream.IsWriting)
			{
				stream.SendNext(currentRotation);
				m_NetworkRotation = currentRotation;
			}
			else
			{
				m_NetworkRotation = (Quaternion)stream.ReceiveNext();
			}
		}
	}
}
[Serializable]
public class PhotonTransformViewScaleModel
{
	public enum InterpolateOptions
	{
		Disabled,
		MoveTowards,
		Lerp
	}

	public bool SynchronizeEnabled;

	public InterpolateOptions InterpolateOption;

	public float InterpolateMoveTowardsSpeed = 1f;

	public float InterpolateLerpSpeed;
}
public class PhotonTransformViewScaleControl
{
	private PhotonTransformViewScaleModel m_Model;

	private Vector3 m_NetworkScale = Vector3.one;

	public PhotonTransformViewScaleControl(PhotonTransformViewScaleModel model)
	{
		m_Model = model;
	}

	public Vector3 GetNetworkScale()
	{
		return m_NetworkScale;
	}

	public Vector3 GetScale(Vector3 currentScale)
	{
		return m_Model.InterpolateOption switch
		{
			PhotonTransformViewScaleModel.InterpolateOptions.MoveTowards => Vector3.MoveTowards(currentScale, m_NetworkScale, m_Model.InterpolateMoveTowardsSpeed * Time.deltaTime), 
			PhotonTransformViewScaleModel.InterpolateOptions.Lerp => Vector3.Lerp(currentScale, m_NetworkScale, m_Model.InterpolateLerpSpeed * Time.deltaTime), 
			_ => m_NetworkScale, 
		};
	}

	public void OnPhotonSerializeView(Vector3 currentScale, PhotonStream stream, PhotonMessageInfo info)
	{
		if (m_Model.SynchronizeEnabled)
		{
			if (stream.IsWriting)
			{
				stream.SendNext(currentScale);
				m_NetworkScale = currentScale;
			}
			else
			{
				m_NetworkScale = (Vector3)stream.ReceiveNext();
			}
		}
	}
}
