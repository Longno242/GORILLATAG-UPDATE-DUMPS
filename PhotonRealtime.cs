#define SUPPORTED_UNITY
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using ExitGames.Client.Photon;
using UnityEngine;

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
			FilePathsData = new byte[856]
			{
				0, 0, 0, 1, 0, 0, 0, 49, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 82,
				101, 97, 108, 116, 105, 109, 101, 92, 67, 111,
				100, 101, 92, 65, 112, 112, 83, 101, 116, 116,
				105, 110, 103, 115, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 55, 92, 65, 115, 115, 101,
				116, 115, 92, 80, 104, 111, 116, 111, 110, 92,
				80, 104, 111, 116, 111, 110, 82, 101, 97, 108,
				116, 105, 109, 101, 92, 67, 111, 100, 101, 92,
				67, 111, 110, 110, 101, 99, 116, 105, 111, 110,
				72, 97, 110, 100, 108, 101, 114, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 54, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 82,
				101, 97, 108, 116, 105, 109, 101, 92, 67, 111,
				100, 101, 92, 67, 117, 115, 116, 111, 109, 84,
				121, 112, 101, 115, 85, 110, 105, 116, 121, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 48,
				92, 65, 115, 115, 101, 116, 115, 92, 80, 104,
				111, 116, 111, 110, 92, 80, 104, 111, 116, 111,
				110, 82, 101, 97, 108, 116, 105, 109, 101, 92,
				67, 111, 100, 101, 92, 69, 120, 116, 101, 110,
				115, 105, 111, 110, 115, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 48, 92, 65, 115, 115,
				101, 116, 115, 92, 80, 104, 111, 116, 111, 110,
				92, 80, 104, 111, 116, 111, 110, 82, 101, 97,
				108, 116, 105, 109, 101, 92, 67, 111, 100, 101,
				92, 70, 114, 105, 101, 110, 100, 73, 110, 102,
				111, 46, 99, 115, 0, 0, 0, 18, 0, 0,
				0, 57, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 82, 101, 97, 108, 116, 105, 109,
				101, 92, 67, 111, 100, 101, 92, 76, 111, 97,
				100, 66, 97, 108, 97, 110, 99, 105, 110, 103,
				67, 108, 105, 101, 110, 116, 46, 99, 115, 0,
				0, 0, 15, 0, 0, 0, 55, 92, 65, 115,
				115, 101, 116, 115, 92, 80, 104, 111, 116, 111,
				110, 92, 80, 104, 111, 116, 111, 110, 82, 101,
				97, 108, 116, 105, 109, 101, 92, 67, 111, 100,
				101, 92, 76, 111, 97, 100, 98, 97, 108, 97,
				110, 99, 105, 110, 103, 80, 101, 101, 114, 46,
				99, 115, 0, 0, 0, 2, 0, 0, 0, 48,
				92, 65, 115, 115, 101, 116, 115, 92, 80, 104,
				111, 116, 111, 110, 92, 80, 104, 111, 116, 111,
				110, 82, 101, 97, 108, 116, 105, 109, 101, 92,
				67, 111, 100, 101, 92, 80, 104, 111, 116, 111,
				110, 80, 105, 110, 103, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 44, 92, 65, 115, 115,
				101, 116, 115, 92, 80, 104, 111, 116, 111, 110,
				92, 80, 104, 111, 116, 111, 110, 82, 101, 97,
				108, 116, 105, 109, 101, 92, 67, 111, 100, 101,
				92, 80, 108, 97, 121, 101, 114, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 44, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 82,
				101, 97, 108, 116, 105, 109, 101, 92, 67, 111,
				100, 101, 92, 82, 101, 103, 105, 111, 110, 46,
				99, 115, 0, 0, 0, 2, 0, 0, 0, 51,
				92, 65, 115, 115, 101, 116, 115, 92, 80, 104,
				111, 116, 111, 110, 92, 80, 104, 111, 116, 111,
				110, 82, 101, 97, 108, 116, 105, 109, 101, 92,
				67, 111, 100, 101, 92, 82, 101, 103, 105, 111,
				110, 72, 97, 110, 100, 108, 101, 114, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 42, 92,
				65, 115, 115, 101, 116, 115, 92, 80, 104, 111,
				116, 111, 110, 92, 80, 104, 111, 116, 111, 110,
				82, 101, 97, 108, 116, 105, 109, 101, 92, 67,
				111, 100, 101, 92, 82, 111, 111, 109, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 46, 92,
				65, 115, 115, 101, 116, 115, 92, 80, 104, 111,
				116, 111, 110, 92, 80, 104, 111, 116, 111, 110,
				82, 101, 97, 108, 116, 105, 109, 101, 92, 67,
				111, 100, 101, 92, 82, 111, 111, 109, 73, 110,
				102, 111, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 51, 92, 65, 115, 115, 101, 116, 115,
				92, 80, 104, 111, 116, 111, 110, 92, 80, 104,
				111, 116, 111, 110, 82, 101, 97, 108, 116, 105,
				109, 101, 92, 67, 111, 100, 101, 92, 83, 117,
				112, 112, 111, 114, 116, 76, 111, 103, 103, 101,
				114, 46, 99, 115, 0, 0, 0, 2, 0, 0,
				0, 44, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 82, 101, 97, 108, 116, 105, 109,
				101, 92, 67, 111, 100, 101, 92, 87, 101, 98,
				82, 112, 99, 46, 99, 115
			},
			TypesData = new byte[1821]
			{
				0, 0, 0, 0, 27, 80, 104, 111, 116, 111,
				110, 46, 82, 101, 97, 108, 116, 105, 109, 101,
				124, 65, 112, 112, 83, 101, 116, 116, 105, 110,
				103, 115, 0, 0, 0, 0, 33, 80, 104, 111,
				116, 111, 110, 46, 82, 101, 97, 108, 116, 105,
				109, 101, 124, 67, 111, 110, 110, 101, 99, 116,
				105, 111, 110, 72, 97, 110, 100, 108, 101, 114,
				0, 0, 0, 0, 32, 80, 104, 111, 116, 111,
				110, 46, 82, 101, 97, 108, 116, 105, 109, 101,
				124, 67, 117, 115, 116, 111, 109, 84, 121, 112,
				101, 115, 85, 110, 105, 116, 121, 0, 0, 0,
				0, 26, 80, 104, 111, 116, 111, 110, 46, 82,
				101, 97, 108, 116, 105, 109, 101, 124, 69, 120,
				116, 101, 110, 115, 105, 111, 110, 115, 0, 0,
				0, 0, 26, 80, 104, 111, 116, 111, 110, 46,
				82, 101, 97, 108, 116, 105, 109, 101, 124, 70,
				114, 105, 101, 110, 100, 73, 110, 102, 111, 0,
				0, 0, 0, 36, 80, 104, 111, 116, 111, 110,
				46, 82, 101, 97, 108, 116, 105, 109, 101, 124,
				80, 104, 111, 116, 111, 110, 80, 111, 114, 116,
				68, 101, 102, 105, 110, 105, 116, 105, 111, 110,
				0, 0, 0, 0, 35, 80, 104, 111, 116, 111,
				110, 46, 82, 101, 97, 108, 116, 105, 109, 101,
				124, 76, 111, 97, 100, 66, 97, 108, 97, 110,
				99, 105, 110, 103, 67, 108, 105, 101, 110, 116,
				0, 0, 0, 0, 60, 80, 104, 111, 116, 111,
				110, 46, 82, 101, 97, 108, 116, 105, 109, 101,
				46, 76, 111, 97, 100, 66, 97, 108, 97, 110,
				99, 105, 110, 103, 67, 108, 105, 101, 110, 116,
				124, 69, 110, 99, 114, 121, 112, 116, 105, 111,
				110, 68, 97, 116, 97, 80, 97, 114, 97, 109,
				101, 116, 101, 114, 115, 0, 0, 0, 0, 56,
				80, 104, 111, 116, 111, 110, 46, 82, 101, 97,
				108, 116, 105, 109, 101, 46, 76, 111, 97, 100,
				66, 97, 108, 97, 110, 99, 105, 110, 103, 67,
				108, 105, 101, 110, 116, 124, 67, 97, 108, 108,
				98, 97, 99, 107, 84, 97, 114, 103, 101, 116,
				67, 104, 97, 110, 103, 101, 0, 0, 0, 0,
				36, 80, 104, 111, 116, 111, 110, 46, 82, 101,
				97, 108, 116, 105, 109, 101, 124, 73, 67, 111,
				110, 110, 101, 99, 116, 105, 111, 110, 67, 97,
				108, 108, 98, 97, 99, 107, 115, 0, 0, 0,
				0, 31, 80, 104, 111, 116, 111, 110, 46, 82,
				101, 97, 108, 116, 105, 109, 101, 124, 73, 76,
				111, 98, 98, 121, 67, 97, 108, 108, 98, 97,
				99, 107, 115, 0, 0, 0, 0, 37, 80, 104,
				111, 116, 111, 110, 46, 82, 101, 97, 108, 116,
				105, 109, 101, 124, 73, 77, 97, 116, 99, 104,
				109, 97, 107, 105, 110, 103, 67, 97, 108, 108,
				98, 97, 99, 107, 115, 0, 0, 0, 0, 32,
				80, 104, 111, 116, 111, 110, 46, 82, 101, 97,
				108, 116, 105, 109, 101, 124, 73, 73, 110, 82,
				111, 111, 109, 67, 97, 108, 108, 98, 97, 99,
				107, 115, 0, 0, 0, 0, 32, 80, 104, 111,
				116, 111, 110, 46, 82, 101, 97, 108, 116, 105,
				109, 101, 124, 73, 79, 110, 69, 118, 101, 110,
				116, 67, 97, 108, 108, 98, 97, 99, 107, 0,
				0, 0, 0, 31, 80, 104, 111, 116, 111, 110,
				46, 82, 101, 97, 108, 116, 105, 109, 101, 124,
				73, 87, 101, 98, 82, 112, 99, 67, 97, 108,
				108, 98, 97, 99, 107, 0, 0, 0, 0, 34,
				80, 104, 111, 116, 111, 110, 46, 82, 101, 97,
				108, 116, 105, 109, 101, 124, 73, 69, 114, 114,
				111, 114, 73, 110, 102, 111, 67, 97, 108, 108,
				98, 97, 99, 107, 0, 0, 0, 0, 44, 80,
				104, 111, 116, 111, 110, 46, 82, 101, 97, 108,
				116, 105, 109, 101, 124, 67, 111, 110, 110, 101,
				99, 116, 105, 111, 110, 67, 97, 108, 108, 98,
				97, 99, 107, 115, 67, 111, 110, 116, 97, 105,
				110, 101, 114, 0, 0, 0, 0, 45, 80, 104,
				111, 116, 111, 110, 46, 82, 101, 97, 108, 116,
				105, 109, 101, 124, 77, 97, 116, 99, 104, 77,
				97, 107, 105, 110, 103, 67, 97, 108, 108, 98,
				97, 99, 107, 115, 67, 111, 110, 116, 97, 105,
				110, 101, 114, 0, 0, 0, 0, 40, 80, 104,
				111, 116, 111, 110, 46, 82, 101, 97, 108, 116,
				105, 109, 101, 124, 73, 110, 82, 111, 111, 109,
				67, 97, 108, 108, 98, 97, 99, 107, 115, 67,
				111, 110, 116, 97, 105, 110, 101, 114, 0, 0,
				0, 0, 39, 80, 104, 111, 116, 111, 110, 46,
				82, 101, 97, 108, 116, 105, 109, 101, 124, 76,
				111, 98, 98, 121, 67, 97, 108, 108, 98, 97,
				99, 107, 115, 67, 111, 110, 116, 97, 105, 110,
				101, 114, 0, 0, 0, 0, 40, 80, 104, 111,
				116, 111, 110, 46, 82, 101, 97, 108, 116, 105,
				109, 101, 124, 87, 101, 98, 82, 112, 99, 67,
				97, 108, 108, 98, 97, 99, 107, 115, 67, 111,
				110, 116, 97, 105, 110, 101, 114, 0, 0, 0,
				0, 43, 80, 104, 111, 116, 111, 110, 46, 82,
				101, 97, 108, 116, 105, 109, 101, 124, 69, 114,
				114, 111, 114, 73, 110, 102, 111, 67, 97, 108,
				108, 98, 97, 99, 107, 115, 67, 111, 110, 116,
				97, 105, 110, 101, 114, 0, 0, 0, 0, 25,
				80, 104, 111, 116, 111, 110, 46, 82, 101, 97,
				108, 116, 105, 109, 101, 124, 69, 114, 114, 111,
				114, 73, 110, 102, 111, 0, 0, 0, 0, 33,
				80, 104, 111, 116, 111, 110, 46, 82, 101, 97,
				108, 116, 105, 109, 101, 124, 76, 111, 97, 100,
				66, 97, 108, 97, 110, 99, 105, 110, 103, 80,
				101, 101, 114, 0, 0, 0, 0, 34, 80, 104,
				111, 116, 111, 110, 46, 82, 101, 97, 108, 116,
				105, 109, 101, 124, 70, 105, 110, 100, 70, 114,
				105, 101, 110, 100, 115, 79, 112, 116, 105, 111,
				110, 115, 0, 0, 0, 0, 38, 80, 104, 111,
				116, 111, 110, 46, 82, 101, 97, 108, 116, 105,
				109, 101, 124, 79, 112, 74, 111, 105, 110, 82,
				97, 110, 100, 111, 109, 82, 111, 111, 109, 80,
				97, 114, 97, 109, 115, 0, 0, 0, 0, 31,
				80, 104, 111, 116, 111, 110, 46, 82, 101, 97,
				108, 116, 105, 109, 101, 124, 69, 110, 116, 101,
				114, 82, 111, 111, 109, 80, 97, 114, 97, 109,
				115, 0, 0, 0, 0, 25, 80, 104, 111, 116,
				111, 110, 46, 82, 101, 97, 108, 116, 105, 109,
				101, 124, 69, 114, 114, 111, 114, 67, 111, 100,
				101, 0, 0, 0, 0, 31, 80, 104, 111, 116,
				111, 110, 46, 82, 101, 97, 108, 116, 105, 109,
				101, 124, 65, 99, 116, 111, 114, 80, 114, 111,
				112, 101, 114, 116, 105, 101, 115, 0, 0, 0,
				0, 31, 80, 104, 111, 116, 111, 110, 46, 82,
				101, 97, 108, 116, 105, 109, 101, 124, 71, 97,
				109, 101, 80, 114, 111, 112, 101, 114, 116, 121,
				75, 101, 121, 0, 0, 0, 0, 25, 80, 104,
				111, 116, 111, 110, 46, 82, 101, 97, 108, 116,
				105, 109, 101, 124, 69, 118, 101, 110, 116, 67,
				111, 100, 101, 0, 0, 0, 0, 29, 80, 104,
				111, 116, 111, 110, 46, 82, 101, 97, 108, 116,
				105, 109, 101, 124, 80, 97, 114, 97, 109, 101,
				116, 101, 114, 67, 111, 100, 101, 0, 0, 0,
				0, 29, 80, 104, 111, 116, 111, 110, 46, 82,
				101, 97, 108, 116, 105, 109, 101, 124, 79, 112,
				101, 114, 97, 116, 105, 111, 110, 67, 111, 100,
				101, 0, 0, 0, 0, 27, 80, 104, 111, 116,
				111, 110, 46, 82, 101, 97, 108, 116, 105, 109,
				101, 124, 82, 111, 111, 109, 79, 112, 116, 105,
				111, 110, 115, 0, 0, 0, 0, 33, 80, 104,
				111, 116, 111, 110, 46, 82, 101, 97, 108, 116,
				105, 109, 101, 124, 82, 97, 105, 115, 101, 69,
				118, 101, 110, 116, 79, 112, 116, 105, 111, 110,
				115, 0, 0, 0, 0, 26, 80, 104, 111, 116,
				111, 110, 46, 82, 101, 97, 108, 116, 105, 109,
				101, 124, 84, 121, 112, 101, 100, 76, 111, 98,
				98, 121, 0, 0, 0, 0, 30, 80, 104, 111,
				116, 111, 110, 46, 82, 101, 97, 108, 116, 105,
				109, 101, 124, 84, 121, 112, 101, 100, 76, 111,
				98, 98, 121, 73, 110, 102, 111, 0, 0, 0,
				0, 36, 80, 104, 111, 116, 111, 110, 46, 82,
				101, 97, 108, 116, 105, 109, 101, 124, 65, 117,
				116, 104, 101, 110, 116, 105, 99, 97, 116, 105,
				111, 110, 86, 97, 108, 117, 101, 115, 0, 0,
				0, 0, 26, 80, 104, 111, 116, 111, 110, 46,
				82, 101, 97, 108, 116, 105, 109, 101, 124, 80,
				104, 111, 116, 111, 110, 80, 105, 110, 103, 0,
				0, 0, 0, 24, 80, 104, 111, 116, 111, 110,
				46, 82, 101, 97, 108, 116, 105, 109, 101, 124,
				80, 105, 110, 103, 77, 111, 110, 111, 0, 0,
				0, 0, 22, 80, 104, 111, 116, 111, 110, 46,
				82, 101, 97, 108, 116, 105, 109, 101, 124, 80,
				108, 97, 121, 101, 114, 0, 0, 0, 0, 22,
				80, 104, 111, 116, 111, 110, 46, 82, 101, 97,
				108, 116, 105, 109, 101, 124, 82, 101, 103, 105,
				111, 110, 0, 0, 0, 0, 29, 80, 104, 111,
				116, 111, 110, 46, 82, 101, 97, 108, 116, 105,
				109, 101, 124, 82, 101, 103, 105, 111, 110, 72,
				97, 110, 100, 108, 101, 114, 0, 0, 0, 0,
				28, 80, 104, 111, 116, 111, 110, 46, 82, 101,
				97, 108, 116, 105, 109, 101, 124, 82, 101, 103,
				105, 111, 110, 80, 105, 110, 103, 101, 114, 0,
				0, 0, 0, 20, 80, 104, 111, 116, 111, 110,
				46, 82, 101, 97, 108, 116, 105, 109, 101, 124,
				82, 111, 111, 109, 0, 0, 0, 0, 24, 80,
				104, 111, 116, 111, 110, 46, 82, 101, 97, 108,
				116, 105, 109, 101, 124, 82, 111, 111, 109, 73,
				110, 102, 111, 0, 0, 0, 0, 29, 80, 104,
				111, 116, 111, 110, 46, 82, 101, 97, 108, 116,
				105, 109, 101, 124, 83, 117, 112, 112, 111, 114,
				116, 76, 111, 103, 103, 101, 114, 0, 0, 0,
				0, 30, 80, 104, 111, 116, 111, 110, 46, 82,
				101, 97, 108, 116, 105, 109, 101, 124, 87, 101,
				98, 82, 112, 99, 82, 101, 115, 112, 111, 110,
				115, 101, 0, 0, 0, 0, 24, 80, 104, 111,
				116, 111, 110, 46, 82, 101, 97, 108, 116, 105,
				109, 101, 124, 87, 101, 98, 70, 108, 97, 103,
				115
			},
			TotalFiles = 15,
			TotalTypes = 49,
			IsEditorOnly = false
		};
	}
}
namespace Photon.Realtime;

[Serializable]
public class AppSettings
{
	public string AppIdRealtime;

	public string AppIdFusion;

	public string AppIdChat;

	public string AppIdVoice;

	public string AppVersion;

	public bool UseNameServer = true;

	public string FixedRegion;

	[NonSerialized]
	public string BestRegionSummaryFromStorage;

	public string Server;

	public int Port;

	public string ProxyServer;

	public ConnectionProtocol Protocol;

	public bool EnableProtocolFallback = true;

	public AuthModeOption AuthMode;

	public bool EnableLobbyStatistics;

	public DebugLevel NetworkLogging = DebugLevel.ERROR;

	public bool IsMasterServerAddress => !UseNameServer;

	public bool IsBestRegion
	{
		get
		{
			if (UseNameServer)
			{
				return string.IsNullOrEmpty(FixedRegion);
			}
			return false;
		}
	}

	public bool IsDefaultNameServer
	{
		get
		{
			if (UseNameServer)
			{
				return string.IsNullOrEmpty(Server);
			}
			return false;
		}
	}

	public bool IsDefaultPort => Port <= 0;

	public string ToStringFull()
	{
		return string.Format("appId {0}{1}{2}{3}use ns: {4}, reg: {5}, {9}, {6}{7}{8}auth: {10}", string.IsNullOrEmpty(AppIdRealtime) ? string.Empty : ("Realtime/PUN: " + HideAppId(AppIdRealtime) + ", "), string.IsNullOrEmpty(AppIdFusion) ? string.Empty : ("Fusion: " + HideAppId(AppIdFusion) + ", "), string.IsNullOrEmpty(AppIdChat) ? string.Empty : ("Chat: " + HideAppId(AppIdChat) + ", "), string.IsNullOrEmpty(AppIdVoice) ? string.Empty : ("Voice: " + HideAppId(AppIdVoice) + ", "), string.IsNullOrEmpty(AppVersion) ? string.Empty : ("AppVersion: " + AppVersion + ", "), "UseNameServer: " + UseNameServer + ", ", "Fixed Region: " + FixedRegion + ", ", string.IsNullOrEmpty(Server) ? string.Empty : ("Server: " + Server + ", "), IsDefaultPort ? string.Empty : ("Port: " + Port + ", "), string.IsNullOrEmpty(ProxyServer) ? string.Empty : ("Proxy: " + ProxyServer + ", "), Protocol, AuthMode);
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

	private string HideAppId(string appId)
	{
		if (!string.IsNullOrEmpty(appId) && appId.Length >= 8)
		{
			return appId.Substring(0, 8) + "***";
		}
		return appId;
	}

	public AppSettings CopyTo(AppSettings d)
	{
		d.AppIdRealtime = AppIdRealtime;
		d.AppIdFusion = AppIdFusion;
		d.AppIdChat = AppIdChat;
		d.AppIdVoice = AppIdVoice;
		d.AppVersion = AppVersion;
		d.UseNameServer = UseNameServer;
		d.FixedRegion = FixedRegion;
		d.BestRegionSummaryFromStorage = BestRegionSummaryFromStorage;
		d.Server = Server;
		d.Port = Port;
		d.ProxyServer = ProxyServer;
		d.Protocol = Protocol;
		d.AuthMode = AuthMode;
		d.EnableLobbyStatistics = EnableLobbyStatistics;
		d.NetworkLogging = NetworkLogging;
		d.EnableProtocolFallback = EnableProtocolFallback;
		return d;
	}
}
public class ConnectionHandler : MonoBehaviour
{
	public bool DisconnectAfterKeepAlive;

	public int KeepAliveInBackground = 60000;

	public bool ApplyDontDestroyOnLoad = true;

	[NonSerialized]
	public static bool AppQuits;

	private byte fallbackThreadId = byte.MaxValue;

	private bool didSendAcks;

	private readonly Stopwatch backgroundStopwatch = new Stopwatch();

	public LoadBalancingClient Client { get; set; }

	public int CountSendAcksOnly { get; private set; }

	public bool FallbackThreadRunning => fallbackThreadId < byte.MaxValue;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void StaticReset()
	{
		AppQuits = false;
	}

	protected void OnApplicationQuit()
	{
		AppQuits = true;
	}

	protected virtual void Awake()
	{
		if (ApplyDontDestroyOnLoad)
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
	}

	protected virtual void OnDisable()
	{
		StopFallbackSendAckThread();
		if (AppQuits)
		{
			if (Client != null && Client.IsConnected)
			{
				Client.Disconnect();
				Client.LoadBalancingPeer.StopThread();
			}
			SupportClass.StopAllBackgroundCalls();
		}
	}

	public void StartFallbackSendAckThread()
	{
		if (!FallbackThreadRunning)
		{
			fallbackThreadId = SupportClass.StartBackgroundCalls(RealtimeFallbackThread, 50, "RealtimeFallbackThread");
		}
	}

	public void StopFallbackSendAckThread()
	{
		if (FallbackThreadRunning)
		{
			SupportClass.StopBackgroundCalls(fallbackThreadId);
			fallbackThreadId = byte.MaxValue;
		}
	}

	public bool RealtimeFallbackThread()
	{
		if (Client != null)
		{
			if (!Client.IsConnected)
			{
				didSendAcks = false;
				return true;
			}
			if (Client.LoadBalancingPeer.ConnectionTime - Client.LoadBalancingPeer.LastSendOutgoingTime > 100)
			{
				if (!didSendAcks)
				{
					backgroundStopwatch.Reset();
					backgroundStopwatch.Start();
				}
				if (backgroundStopwatch.ElapsedMilliseconds > KeepAliveInBackground)
				{
					if (DisconnectAfterKeepAlive)
					{
						Client.Disconnect();
					}
					return true;
				}
				didSendAcks = true;
				CountSendAcksOnly++;
				Client.LoadBalancingPeer.SendAcksOnly();
			}
			else
			{
				didSendAcks = false;
			}
		}
		return true;
	}
}
internal static class CustomTypesUnity
{
	private const int SizeV2 = 8;

	private const int SizeV3 = 12;

	private const int SizeQuat = 16;

	public static readonly byte[] memVector3 = new byte[12];

	public static readonly byte[] memVector2 = new byte[8];

	public static readonly byte[] memQuarternion = new byte[16];

	internal static void Register()
	{
		PhotonPeer.RegisterType(typeof(Vector2), 87, SerializeVector2, DeserializeVector2);
		PhotonPeer.RegisterType(typeof(Vector3), 86, SerializeVector3, DeserializeVector3);
		PhotonPeer.RegisterType(typeof(Quaternion), 81, SerializeQuaternion, DeserializeQuaternion);
	}

	private static short SerializeVector3(StreamBuffer outStream, object customobject)
	{
		Vector3 vector = (Vector3)customobject;
		int targetOffset = 0;
		lock (memVector3)
		{
			byte[] array = memVector3;
			Protocol.Serialize(vector.x, array, ref targetOffset);
			Protocol.Serialize(vector.y, array, ref targetOffset);
			Protocol.Serialize(vector.z, array, ref targetOffset);
			outStream.Write(array, 0, 12);
		}
		return 12;
	}

	private static object DeserializeVector3(StreamBuffer inStream, short length)
	{
		Vector3 vector = default(Vector3);
		if (length != 12)
		{
			return vector;
		}
		lock (memVector3)
		{
			inStream.Read(memVector3, 0, 12);
			int offset = 0;
			Protocol.Deserialize(out vector.x, memVector3, ref offset);
			Protocol.Deserialize(out vector.y, memVector3, ref offset);
			Protocol.Deserialize(out vector.z, memVector3, ref offset);
		}
		return vector;
	}

	private static short SerializeVector2(StreamBuffer outStream, object customobject)
	{
		Vector2 vector = (Vector2)customobject;
		lock (memVector2)
		{
			byte[] array = memVector2;
			int targetOffset = 0;
			Protocol.Serialize(vector.x, array, ref targetOffset);
			Protocol.Serialize(vector.y, array, ref targetOffset);
			outStream.Write(array, 0, 8);
		}
		return 8;
	}

	private static object DeserializeVector2(StreamBuffer inStream, short length)
	{
		Vector2 vector = default(Vector2);
		if (length != 8)
		{
			return vector;
		}
		lock (memVector2)
		{
			inStream.Read(memVector2, 0, 8);
			int offset = 0;
			Protocol.Deserialize(out vector.x, memVector2, ref offset);
			Protocol.Deserialize(out vector.y, memVector2, ref offset);
		}
		return vector;
	}

	private static short SerializeQuaternion(StreamBuffer outStream, object customobject)
	{
		Quaternion quaternion = (Quaternion)customobject;
		lock (memQuarternion)
		{
			byte[] array = memQuarternion;
			int targetOffset = 0;
			Protocol.Serialize(quaternion.w, array, ref targetOffset);
			Protocol.Serialize(quaternion.x, array, ref targetOffset);
			Protocol.Serialize(quaternion.y, array, ref targetOffset);
			Protocol.Serialize(quaternion.z, array, ref targetOffset);
			outStream.Write(array, 0, 16);
		}
		return 16;
	}

	private static object DeserializeQuaternion(StreamBuffer inStream, short length)
	{
		Quaternion identity = Quaternion.identity;
		if (length != 16)
		{
			return identity;
		}
		lock (memQuarternion)
		{
			inStream.Read(memQuarternion, 0, 16);
			int offset = 0;
			Protocol.Deserialize(out identity.w, memQuarternion, ref offset);
			Protocol.Deserialize(out identity.x, memQuarternion, ref offset);
			Protocol.Deserialize(out identity.y, memQuarternion, ref offset);
			Protocol.Deserialize(out identity.z, memQuarternion, ref offset);
		}
		return identity;
	}
}
public static class Extensions
{
	private static readonly List<object> keysWithNullValue = new List<object>();

	public static void Merge(this IDictionary target, IDictionary addHash)
	{
		if (addHash == null || target.Equals(addHash))
		{
			return;
		}
		foreach (object key in addHash.Keys)
		{
			target[key] = addHash[key];
		}
	}

	public static void MergeStringKeys(this IDictionary target, IDictionary addHash)
	{
		if (addHash == null || target.Equals(addHash))
		{
			return;
		}
		foreach (object key in addHash.Keys)
		{
			if (key is string)
			{
				target[key] = addHash[key];
			}
		}
	}

	public static string ToStringFull(this IDictionary origin)
	{
		return SupportClass.DictionaryToString(origin, includeTypes: false);
	}

	public static string ToStringFull<T>(this List<T> data)
	{
		if (data == null)
		{
			return "null";
		}
		string[] array = new string[data.Count];
		for (int i = 0; i < data.Count; i++)
		{
			object obj = data[i];
			array[i] = ((obj != null) ? obj.ToString() : "null");
		}
		return string.Join(", ", array);
	}

	public static string ToStringFull(this object[] data)
	{
		if (data == null)
		{
			return "null";
		}
		string[] array = new string[data.Length];
		for (int i = 0; i < data.Length; i++)
		{
			object obj = data[i];
			array[i] = ((obj != null) ? obj.ToString() : "null");
		}
		return string.Join(", ", array);
	}

	public static ExitGames.Client.Photon.Hashtable StripToStringKeys(this IDictionary original)
	{
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		if (original != null)
		{
			foreach (object key in original.Keys)
			{
				if (key is string)
				{
					hashtable[key] = original[key];
				}
			}
		}
		return hashtable;
	}

	public static ExitGames.Client.Photon.Hashtable StripToStringKeys(this ExitGames.Client.Photon.Hashtable original)
	{
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		if (original != null)
		{
			foreach (DictionaryEntry item in original)
			{
				if (item.Key is string)
				{
					hashtable[item.Key] = original[item.Key];
				}
			}
		}
		return hashtable;
	}

	public static void StripKeysWithNullValues(this IDictionary original)
	{
		lock (keysWithNullValue)
		{
			keysWithNullValue.Clear();
			foreach (DictionaryEntry item in original)
			{
				if (item.Value == null)
				{
					keysWithNullValue.Add(item.Key);
				}
			}
			for (int i = 0; i < keysWithNullValue.Count; i++)
			{
				object key = keysWithNullValue[i];
				original.Remove(key);
			}
		}
	}

	public static void StripKeysWithNullValues(this ExitGames.Client.Photon.Hashtable original)
	{
		lock (keysWithNullValue)
		{
			keysWithNullValue.Clear();
			foreach (DictionaryEntry item in original)
			{
				if (item.Value == null)
				{
					keysWithNullValue.Add(item.Key);
				}
			}
			for (int i = 0; i < keysWithNullValue.Count; i++)
			{
				object key = keysWithNullValue[i];
				original.Remove(key);
			}
		}
	}

	public static bool Contains(this int[] target, int nr)
	{
		if (target == null)
		{
			return false;
		}
		for (int i = 0; i < target.Length; i++)
		{
			if (target[i] == nr)
			{
				return true;
			}
		}
		return false;
	}
}
public class FriendInfo
{
	[Obsolete("Use UserId.")]
	public string Name => UserId;

	public string UserId { get; protected internal set; }

	public bool IsOnline { get; protected internal set; }

	public string Room { get; protected internal set; }

	public bool IsInRoom
	{
		get
		{
			if (IsOnline)
			{
				return !string.IsNullOrEmpty(Room);
			}
			return false;
		}
	}

	public override string ToString()
	{
		return string.Format("{0}\t is: {1}", UserId, (!IsOnline) ? "offline" : (IsInRoom ? "playing" : "on master"));
	}
}
public enum ClientState
{
	PeerCreated = 0,
	Authenticating = 1,
	Authenticated = 2,
	JoiningLobby = 3,
	JoinedLobby = 4,
	DisconnectingFromMasterServer = 5,
	[Obsolete("Renamed to DisconnectingFromMasterServer")]
	DisconnectingFromMasterserver = 5,
	ConnectingToGameServer = 6,
	[Obsolete("Renamed to ConnectingToGameServer")]
	ConnectingToGameserver = 6,
	ConnectedToGameServer = 7,
	[Obsolete("Renamed to ConnectedToGameServer")]
	ConnectedToGameserver = 7,
	Joining = 8,
	Joined = 9,
	Leaving = 10,
	DisconnectingFromGameServer = 11,
	[Obsolete("Renamed to DisconnectingFromGameServer")]
	DisconnectingFromGameserver = 11,
	ConnectingToMasterServer = 12,
	[Obsolete("Renamed to ConnectingToMasterServer.")]
	ConnectingToMasterserver = 12,
	Disconnecting = 13,
	Disconnected = 14,
	ConnectedToMasterServer = 15,
	[Obsolete("Renamed to ConnectedToMasterServer.")]
	ConnectedToMasterserver = 15,
	[Obsolete("Renamed to ConnectedToMasterServer.")]
	ConnectedToMaster = 15,
	ConnectingToNameServer = 16,
	ConnectedToNameServer = 17,
	DisconnectingFromNameServer = 18,
	ConnectWithFallbackProtocol = 19
}
internal enum JoinType
{
	CreateRoom,
	JoinRoom,
	JoinRandomRoom,
	JoinRandomOrCreateRoom,
	JoinOrCreateRoom
}
public enum DisconnectCause
{
	None,
	ExceptionOnConnect,
	DnsExceptionOnConnect,
	ServerAddressInvalid,
	Exception,
	ServerTimeout,
	ClientTimeout,
	DisconnectByServerLogic,
	DisconnectByServerReasonUnknown,
	InvalidAuthentication,
	CustomAuthenticationFailed,
	AuthenticationTicketExpired,
	MaxCcuReached,
	InvalidRegion,
	OperationNotAllowedInCurrentState,
	DisconnectByClientLogic,
	DisconnectByOperationLimit,
	DisconnectByDisconnectMessage
}
public enum ServerConnection
{
	MasterServer,
	GameServer,
	NameServer
}
public enum ClientAppType
{
	Realtime,
	Voice,
	Fusion
}
public enum EncryptionMode
{
	PayloadEncryption = 0,
	DatagramEncryption = 10,
	DatagramEncryptionRandomSequence = 11,
	DatagramEncryptionGCM = 13
}
public struct PhotonPortDefinition
{
	public static readonly PhotonPortDefinition AlternativeUdpPorts = new PhotonPortDefinition
	{
		NameServerPort = 27000,
		MasterServerPort = 27001,
		GameServerPort = 27002
	};

	public ushort NameServerPort;

	public ushort MasterServerPort;

	public ushort GameServerPort;
}
public class LoadBalancingClient : IPhotonPeerListener
{
	private class EncryptionDataParameters
	{
		public const byte Mode = 0;

		public const byte Secret1 = 1;

		public const byte Secret2 = 2;
	}

	private class CallbackTargetChange
	{
		public readonly object Target;

		public readonly bool AddTarget;

		public CallbackTargetChange(object target, bool addTarget)
		{
			Target = target;
			AddTarget = addTarget;
		}
	}

	public AuthModeOption AuthMode;

	public EncryptionMode EncryptionMode;

	private object tokenCache;

	public string NameServerHost = "ns.photonengine.io";

	private static readonly Dictionary<ConnectionProtocol, int> ProtocolToNameServerPort = new Dictionary<ConnectionProtocol, int>
	{
		{
			ConnectionProtocol.Udp,
			5058
		},
		{
			ConnectionProtocol.Tcp,
			4533
		},
		{
			ConnectionProtocol.WebSocket,
			9093
		},
		{
			ConnectionProtocol.WebSocketSecure,
			19093
		}
	};

	public PhotonPortDefinition ServerPortOverrides;

	public string ProxyServerAddress;

	private ClientState state;

	public ConnectionCallbacksContainer ConnectionCallbackTargets;

	public MatchMakingCallbacksContainer MatchMakingCallbackTargets;

	internal InRoomCallbacksContainer InRoomCallbackTargets;

	internal LobbyCallbacksContainer LobbyCallbackTargets;

	internal WebRpcCallbacksContainer WebRpcCallbackTargets;

	internal ErrorInfoCallbacksContainer ErrorInfoCallbackTargets;

	public bool EnableLobbyStatistics;

	private readonly List<TypedLobbyInfo> lobbyStatistics = new List<TypedLobbyInfo>();

	private JoinType lastJoinType;

	private EnterRoomParams enterRoomParamsCache;

	private OperationResponse failedRoomEntryOperation;

	private const int FriendRequestListMax = 512;

	private string[] friendListRequested;

	public RegionHandler RegionHandler;

	private string bestRegionSummaryFromStorage;

	public string SummaryToCache;

	private bool connectToBestRegion = true;

	private readonly Queue<CallbackTargetChange> callbackTargetChanges = new Queue<CallbackTargetChange>();

	private readonly HashSet<object> callbackTargets = new HashSet<object>();

	public int NameServerPortInAppSettings;

	public LoadBalancingPeer LoadBalancingPeer { get; private set; }

	public SerializationProtocol SerializationProtocol
	{
		get
		{
			return LoadBalancingPeer.SerializationProtocolType;
		}
		set
		{
			LoadBalancingPeer.SerializationProtocolType = value;
		}
	}

	public string AppVersion { get; set; }

	public string AppId { get; set; }

	public ClientAppType ClientType { get; set; }

	public AuthenticationValues AuthValues { get; set; }

	public ConnectionProtocol? ExpectedProtocol { get; set; }

	private object TokenForInit
	{
		get
		{
			if (AuthMode == AuthModeOption.Auth)
			{
				return null;
			}
			if (AuthValues == null)
			{
				return null;
			}
			return AuthValues.Token;
		}
	}

	public bool IsUsingNameServer { get; set; }

	public string NameServerAddress => GetNameServerAddress();

	[Obsolete("Set port overrides in ServerPortOverrides. Not used anymore!")]
	public bool UseAlternativeUdpPorts { get; set; }

	public bool EnableProtocolFallback { get; set; }

	public string CurrentServerAddress => LoadBalancingPeer.ServerAddress;

	public string MasterServerAddress { get; set; }

	public string GameServerAddress { get; protected internal set; }

	public ServerConnection Server { get; private set; }

	public ClientState State
	{
		get
		{
			return state;
		}
		set
		{
			if (state != value)
			{
				ClientState arg = state;
				state = value;
				if (this.StateChanged != null)
				{
					this.StateChanged(arg, state);
				}
			}
		}
	}

	public bool IsConnected
	{
		get
		{
			if (LoadBalancingPeer != null && State != ClientState.PeerCreated)
			{
				return State != ClientState.Disconnected;
			}
			return false;
		}
	}

	public bool IsConnectedAndReady
	{
		get
		{
			if (LoadBalancingPeer == null)
			{
				return false;
			}
			switch (State)
			{
			case ClientState.PeerCreated:
			case ClientState.Authenticating:
			case ClientState.DisconnectingFromMasterServer:
			case ClientState.ConnectingToGameServer:
			case ClientState.Joining:
			case ClientState.Leaving:
			case ClientState.DisconnectingFromGameServer:
			case ClientState.ConnectingToMasterServer:
			case ClientState.Disconnecting:
			case ClientState.Disconnected:
			case ClientState.ConnectingToNameServer:
			case ClientState.DisconnectingFromNameServer:
				return false;
			default:
				return true;
			}
		}
	}

	public DisconnectCause DisconnectedCause { get; protected set; }

	public bool InLobby => State == ClientState.JoinedLobby;

	public TypedLobby CurrentLobby { get; internal set; }

	public Player LocalPlayer { get; internal set; }

	public string NickName
	{
		get
		{
			return LocalPlayer.NickName;
		}
		set
		{
			if (LocalPlayer != null)
			{
				LocalPlayer.NickName = value;
			}
		}
	}

	public string UserId
	{
		get
		{
			if (AuthValues != null)
			{
				return AuthValues.UserId;
			}
			return null;
		}
		set
		{
			if (AuthValues == null)
			{
				AuthValues = new AuthenticationValues();
			}
			AuthValues.UserId = value;
		}
	}

	public Room CurrentRoom { get; set; }

	public bool InRoom
	{
		get
		{
			if (state == ClientState.Joined)
			{
				return CurrentRoom != null;
			}
			return false;
		}
	}

	public int PlayersOnMasterCount { get; internal set; }

	public int PlayersInRoomsCount { get; internal set; }

	public int RoomsCount { get; internal set; }

	public bool IsFetchingFriendList => friendListRequested != null;

	public string CloudRegion { get; private set; }

	public string CurrentCluster { get; private set; }

	public event Action<ClientState, ClientState> StateChanged;

	public event Action<EventData> EventReceived;

	public event Action<OperationResponse> OpResponseReceived;

	public LoadBalancingClient(ConnectionProtocol protocol = ConnectionProtocol.Udp)
	{
		ConnectionCallbackTargets = new ConnectionCallbacksContainer(this);
		MatchMakingCallbackTargets = new MatchMakingCallbacksContainer(this);
		InRoomCallbackTargets = new InRoomCallbacksContainer(this);
		LobbyCallbackTargets = new LobbyCallbacksContainer(this);
		WebRpcCallbackTargets = new WebRpcCallbacksContainer(this);
		ErrorInfoCallbackTargets = new ErrorInfoCallbacksContainer(this);
		LoadBalancingPeer = new LoadBalancingPeer(this, protocol);
		LoadBalancingPeer.OnDisconnectMessage += OnDisconnectMessageReceived;
		SerializationProtocol = SerializationProtocol.GpBinaryV18;
		LocalPlayer = CreatePlayer(string.Empty, -1, isLocal: true, null);
		CustomTypesUnity.Register();
		State = ClientState.PeerCreated;
	}

	public LoadBalancingClient(string masterAddress, string appId, string gameVersion, ConnectionProtocol protocol = ConnectionProtocol.Udp)
		: this(protocol)
	{
		MasterServerAddress = masterAddress;
		AppId = appId;
		AppVersion = gameVersion;
	}

	private string GetNameServerAddress()
	{
		int value = 0;
		ProtocolToNameServerPort.TryGetValue(LoadBalancingPeer.TransportProtocol, out value);
		if (NameServerPortInAppSettings != 0)
		{
			DebugReturn(DebugLevel.INFO, $"Using NameServerPortInAppSettings: {NameServerPortInAppSettings}");
			value = NameServerPortInAppSettings;
		}
		if (ServerPortOverrides.NameServerPort > 0)
		{
			value = ServerPortOverrides.NameServerPort;
		}
		switch (LoadBalancingPeer.TransportProtocol)
		{
		case ConnectionProtocol.Udp:
		case ConnectionProtocol.Tcp:
			return $"{NameServerHost}:{value}";
		case ConnectionProtocol.WebSocket:
			return $"ws://{NameServerHost}:{value}";
		case ConnectionProtocol.WebSocketSecure:
			return $"wss://{NameServerHost}:{value}";
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public virtual bool ConnectUsingSettings(AppSettings appSettings)
	{
		if (LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
		{
			DebugReturn(DebugLevel.WARNING, "ConnectUsingSettings() failed. Can only connect while in state 'Disconnected'. Current state: " + LoadBalancingPeer.PeerState);
			return false;
		}
		if (appSettings == null)
		{
			DebugReturn(DebugLevel.ERROR, "ConnectUsingSettings failed. The appSettings can't be null.'");
			return false;
		}
		switch (ClientType)
		{
		case ClientAppType.Realtime:
			AppId = appSettings.AppIdRealtime;
			break;
		case ClientAppType.Voice:
			AppId = appSettings.AppIdVoice;
			break;
		case ClientAppType.Fusion:
			AppId = appSettings.AppIdFusion;
			break;
		}
		AppVersion = appSettings.AppVersion;
		IsUsingNameServer = appSettings.UseNameServer;
		CloudRegion = appSettings.FixedRegion;
		connectToBestRegion = string.IsNullOrEmpty(CloudRegion);
		EnableLobbyStatistics = appSettings.EnableLobbyStatistics;
		LoadBalancingPeer.DebugOut = appSettings.NetworkLogging;
		AuthMode = appSettings.AuthMode;
		if (appSettings.AuthMode == AuthModeOption.AuthOnceWss)
		{
			LoadBalancingPeer.TransportProtocol = ConnectionProtocol.WebSocketSecure;
			ExpectedProtocol = appSettings.Protocol;
		}
		else
		{
			LoadBalancingPeer.TransportProtocol = appSettings.Protocol;
			ExpectedProtocol = null;
		}
		EnableProtocolFallback = appSettings.EnableProtocolFallback;
		bestRegionSummaryFromStorage = appSettings.BestRegionSummaryFromStorage;
		DisconnectedCause = DisconnectCause.None;
		if (IsUsingNameServer)
		{
			Server = ServerConnection.NameServer;
			if (!appSettings.IsDefaultNameServer)
			{
				NameServerHost = appSettings.Server;
			}
			ProxyServerAddress = appSettings.ProxyServer;
			NameServerPortInAppSettings = appSettings.Port;
			if (!LoadBalancingPeer.Connect(NameServerAddress, ProxyServerAddress, AppId, TokenForInit))
			{
				return false;
			}
			State = ClientState.ConnectingToNameServer;
		}
		else
		{
			Server = ServerConnection.MasterServer;
			int num = (appSettings.IsDefaultPort ? 5055 : appSettings.Port);
			MasterServerAddress = $"{appSettings.Server}:{num}";
			if (!LoadBalancingPeer.Connect(MasterServerAddress, ProxyServerAddress, AppId, TokenForInit))
			{
				return false;
			}
			State = ClientState.ConnectingToMasterServer;
		}
		return true;
	}

	[Obsolete("Use ConnectToMasterServer() instead.")]
	public bool Connect()
	{
		return ConnectToMasterServer();
	}

	public virtual bool ConnectToMasterServer()
	{
		if (LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
		{
			DebugReturn(DebugLevel.WARNING, "ConnectToMasterServer() failed. Can only connect while in state 'Disconnected'. Current state: " + LoadBalancingPeer.PeerState);
			return false;
		}
		if (AuthMode != AuthModeOption.Auth && TokenForInit == null)
		{
			DebugReturn(DebugLevel.ERROR, "Connect() failed. Can't connect to MasterServer with Token == null in AuthMode: " + AuthMode);
			return false;
		}
		if (LoadBalancingPeer.Connect(MasterServerAddress, ProxyServerAddress, AppId, TokenForInit))
		{
			DisconnectedCause = DisconnectCause.None;
			connectToBestRegion = false;
			State = ClientState.ConnectingToMasterServer;
			Server = ServerConnection.MasterServer;
			return true;
		}
		return false;
	}

	public bool ConnectToNameServer()
	{
		if (LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
		{
			DebugReturn(DebugLevel.WARNING, "ConnectToNameServer() failed. Can only connect while in state 'Disconnected'. Current state: " + LoadBalancingPeer.PeerState);
			return false;
		}
		IsUsingNameServer = true;
		CloudRegion = null;
		if (AuthMode == AuthModeOption.AuthOnceWss)
		{
			if (!ExpectedProtocol.HasValue)
			{
				ExpectedProtocol = LoadBalancingPeer.TransportProtocol;
			}
			LoadBalancingPeer.TransportProtocol = ConnectionProtocol.WebSocketSecure;
		}
		if (LoadBalancingPeer.Connect(NameServerAddress, ProxyServerAddress, "NameServer", TokenForInit))
		{
			DisconnectedCause = DisconnectCause.None;
			connectToBestRegion = false;
			State = ClientState.ConnectingToNameServer;
			Server = ServerConnection.NameServer;
			return true;
		}
		return false;
	}

	public bool ConnectToRegionMaster(string region)
	{
		if (string.IsNullOrEmpty(region))
		{
			DebugReturn(DebugLevel.ERROR, "ConnectToRegionMaster() failed. The region can not be null or empty.");
			return false;
		}
		IsUsingNameServer = true;
		if (State == ClientState.Authenticating)
		{
			if ((int)LoadBalancingPeer.DebugOut >= 3)
			{
				DebugReturn(DebugLevel.INFO, "ConnectToRegionMaster() will skip calling authenticate, as the current state is 'Authenticating'. Just wait for the result.");
			}
			return true;
		}
		if (State == ClientState.ConnectedToNameServer)
		{
			CloudRegion = region;
			bool num = CallAuthenticate();
			if (num)
			{
				State = ClientState.Authenticating;
			}
			return num;
		}
		LoadBalancingPeer.Disconnect();
		if (!string.IsNullOrEmpty(region) && !region.Contains("/"))
		{
			region += "/*";
		}
		CloudRegion = region;
		if (AuthMode == AuthModeOption.AuthOnceWss)
		{
			if (!ExpectedProtocol.HasValue)
			{
				ExpectedProtocol = LoadBalancingPeer.TransportProtocol;
			}
			LoadBalancingPeer.TransportProtocol = ConnectionProtocol.WebSocketSecure;
		}
		connectToBestRegion = false;
		DisconnectedCause = DisconnectCause.None;
		if (!LoadBalancingPeer.Connect(NameServerAddress, ProxyServerAddress, "NameServer", null))
		{
			return false;
		}
		State = ClientState.ConnectingToNameServer;
		Server = ServerConnection.NameServer;
		return true;
	}

	[Conditional("UNITY_WEBGL")]
	private void CheckConnectSetupWebGl()
	{
	}

	private bool Connect(string serverAddress, string proxyServerAddress, ServerConnection serverType)
	{
		if (State == ClientState.Disconnecting)
		{
			DebugReturn(DebugLevel.ERROR, "Connect() failed. Can't connect while disconnecting (still). Current state: " + State);
			return false;
		}
		if (AuthMode != AuthModeOption.Auth && serverType != ServerConnection.NameServer && TokenForInit == null)
		{
			DebugReturn(DebugLevel.ERROR, "Connect() failed. Can't connect to " + serverType.ToString() + " with Token == null in AuthMode: " + AuthMode);
			return false;
		}
		bool flag = LoadBalancingPeer.Connect(serverAddress, proxyServerAddress, AppId, TokenForInit);
		if (flag)
		{
			DisconnectedCause = DisconnectCause.None;
			Server = serverType;
			switch (serverType)
			{
			case ServerConnection.NameServer:
				State = ClientState.ConnectingToNameServer;
				break;
			case ServerConnection.MasterServer:
				State = ClientState.ConnectingToMasterServer;
				break;
			case ServerConnection.GameServer:
				State = ClientState.ConnectingToGameServer;
				break;
			}
		}
		return flag;
	}

	public bool ReconnectToMaster()
	{
		if (LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
		{
			DebugReturn(DebugLevel.WARNING, "ReconnectToMaster() failed. Can only connect while in state 'Disconnected'. Current state: " + LoadBalancingPeer.PeerState);
			return false;
		}
		if (string.IsNullOrEmpty(MasterServerAddress))
		{
			DebugReturn(DebugLevel.WARNING, "ReconnectToMaster() failed. MasterServerAddress is null or empty.");
			return false;
		}
		if (tokenCache == null)
		{
			DebugReturn(DebugLevel.WARNING, "ReconnectToMaster() failed. It seems the client doesn't have any previous authentication token to re-connect.");
			return false;
		}
		if (AuthValues == null)
		{
			DebugReturn(DebugLevel.WARNING, "ReconnectToMaster() with AuthValues == null is not correct!");
			AuthValues = new AuthenticationValues();
		}
		AuthValues.Token = tokenCache;
		return Connect(MasterServerAddress, ProxyServerAddress, ServerConnection.MasterServer);
	}

	public bool ReconnectAndRejoin()
	{
		if (LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
		{
			DebugReturn(DebugLevel.WARNING, "ReconnectAndRejoin() failed. Can only connect while in state 'Disconnected'. Current state: " + LoadBalancingPeer.PeerState);
			return false;
		}
		if (string.IsNullOrEmpty(GameServerAddress))
		{
			DebugReturn(DebugLevel.WARNING, "ReconnectAndRejoin() failed. It seems the client wasn't connected to a game server before (no address).");
			return false;
		}
		if (enterRoomParamsCache == null)
		{
			DebugReturn(DebugLevel.WARNING, "ReconnectAndRejoin() failed. It seems the client doesn't have any previous room to re-join.");
			return false;
		}
		if (tokenCache == null)
		{
			DebugReturn(DebugLevel.WARNING, "ReconnectAndRejoin() failed. It seems the client doesn't have any previous authentication token to re-connect.");
			return false;
		}
		if (AuthValues == null)
		{
			AuthValues = new AuthenticationValues();
		}
		AuthValues.Token = tokenCache;
		if (!string.IsNullOrEmpty(GameServerAddress) && enterRoomParamsCache != null)
		{
			lastJoinType = JoinType.JoinRoom;
			enterRoomParamsCache.JoinMode = JoinMode.RejoinOnly;
			return Connect(GameServerAddress, ProxyServerAddress, ServerConnection.GameServer);
		}
		return false;
	}

	public void Disconnect(DisconnectCause cause = DisconnectCause.DisconnectByClientLogic)
	{
		if (State == ClientState.Disconnecting || State == ClientState.PeerCreated)
		{
			DebugReturn(DebugLevel.INFO, "Disconnect() call gets skipped due to State " + State.ToString() + ". DisconnectedCause: " + DisconnectedCause.ToString() + " Parameter cause: " + cause);
		}
		else if (State != ClientState.Disconnected)
		{
			MatchMakingCallbackTargets.OnPreLeavingRoom();
			State = ClientState.Disconnecting;
			DisconnectedCause = cause;
			LoadBalancingPeer.Disconnect();
		}
	}

	private void DisconnectToReconnect()
	{
		switch (Server)
		{
		case ServerConnection.NameServer:
			State = ClientState.DisconnectingFromNameServer;
			break;
		case ServerConnection.MasterServer:
			State = ClientState.DisconnectingFromMasterServer;
			break;
		case ServerConnection.GameServer:
			State = ClientState.DisconnectingFromGameServer;
			break;
		}
		LoadBalancingPeer.Disconnect();
	}

	public void SimulateConnectionLoss(bool simulateTimeout)
	{
		DebugReturn(DebugLevel.WARNING, "SimulateConnectionLoss() set to: " + simulateTimeout);
		if (simulateTimeout)
		{
			LoadBalancingPeer.NetworkSimulationSettings.IncomingLossPercentage = 100;
			LoadBalancingPeer.NetworkSimulationSettings.OutgoingLossPercentage = 100;
		}
		LoadBalancingPeer.IsSimulationEnabled = simulateTimeout;
	}

	private bool CallAuthenticate()
	{
		if (IsUsingNameServer && Server != ServerConnection.NameServer && (AuthValues == null || AuthValues.Token == null))
		{
			DebugReturn(DebugLevel.ERROR, "Authenticate without Token is only allowed on Name Server. Connecting to: " + Server.ToString() + " on: " + CurrentServerAddress + ". State: " + State);
			return false;
		}
		if (AuthMode == AuthModeOption.Auth)
		{
			if (!CheckIfOpCanBeSent(230, Server, "Authenticate"))
			{
				return false;
			}
			return LoadBalancingPeer.OpAuthenticate(AppId, AppVersion, AuthValues, CloudRegion, EnableLobbyStatistics && Server == ServerConnection.MasterServer);
		}
		if (!CheckIfOpCanBeSent(231, Server, "AuthenticateOnce"))
		{
			return false;
		}
		ConnectionProtocol expectedProtocol = (ExpectedProtocol.HasValue ? ExpectedProtocol.Value : LoadBalancingPeer.TransportProtocol);
		return LoadBalancingPeer.OpAuthenticateOnce(AppId, AppVersion, AuthValues, CloudRegion, EncryptionMode, expectedProtocol);
	}

	public void Service()
	{
		if (LoadBalancingPeer != null)
		{
			LoadBalancingPeer.Service();
		}
	}

	private bool OpGetRegions()
	{
		if (!CheckIfOpCanBeSent(220, Server, "GetRegions"))
		{
			return false;
		}
		return LoadBalancingPeer.OpGetRegions(AppId);
	}

	public bool OpFindFriends(string[] friendsToFind, FindFriendsOptions options = null)
	{
		if (!CheckIfOpCanBeSent(222, Server, "FindFriends"))
		{
			return false;
		}
		if (IsFetchingFriendList)
		{
			DebugReturn(DebugLevel.WARNING, "OpFindFriends skipped: already fetching friends list.");
			return false;
		}
		if (friendsToFind == null || friendsToFind.Length == 0)
		{
			DebugReturn(DebugLevel.ERROR, "OpFindFriends skipped: friendsToFind array is null or empty.");
			return false;
		}
		if (friendsToFind.Length > 512)
		{
			DebugReturn(DebugLevel.ERROR, $"OpFindFriends skipped: friendsToFind array exceeds allowed length of {512}.");
			return false;
		}
		List<string> list = new List<string>(friendsToFind.Length);
		for (int i = 0; i < friendsToFind.Length; i++)
		{
			string text = friendsToFind[i];
			if (string.IsNullOrEmpty(text))
			{
				DebugReturn(DebugLevel.WARNING, $"friendsToFind array contains a null or empty UserId, element at position {i} skipped.");
			}
			else if (text.Equals(UserId))
			{
				DebugReturn(DebugLevel.WARNING, $"friendsToFind array contains local player's UserId \"{text}\", element at position {i} skipped.");
			}
			else if (list.Contains(text))
			{
				DebugReturn(DebugLevel.WARNING, $"friendsToFind array contains duplicate UserId \"{text}\", element at position {i} skipped.");
			}
			else
			{
				list.Add(text);
			}
		}
		if (list.Count == 0)
		{
			DebugReturn(DebugLevel.ERROR, "OpFindFriends skipped: friends list to find is empty.");
			return false;
		}
		string[] array = list.ToArray();
		bool flag = LoadBalancingPeer.OpFindFriends(array, options);
		friendListRequested = (flag ? array : null);
		return flag;
	}

	public bool OpJoinLobby(TypedLobby lobby)
	{
		if (!CheckIfOpCanBeSent(229, Server, "JoinLobby"))
		{
			return false;
		}
		if (lobby == null)
		{
			lobby = TypedLobby.Default;
		}
		bool num = LoadBalancingPeer.OpJoinLobby(lobby);
		if (num)
		{
			CurrentLobby = lobby;
			State = ClientState.JoiningLobby;
		}
		return num;
	}

	public bool OpLeaveLobby()
	{
		if (!CheckIfOpCanBeSent(228, Server, "LeaveLobby"))
		{
			return false;
		}
		return LoadBalancingPeer.OpLeaveLobby();
	}

	public bool OpJoinRandomRoom(OpJoinRandomRoomParams opJoinRandomRoomParams = null)
	{
		if (!CheckIfOpCanBeSent(225, Server, "JoinRandomGame"))
		{
			return false;
		}
		if (opJoinRandomRoomParams == null)
		{
			opJoinRandomRoomParams = new OpJoinRandomRoomParams();
		}
		enterRoomParamsCache = new EnterRoomParams();
		enterRoomParamsCache.Lobby = opJoinRandomRoomParams.TypedLobby;
		enterRoomParamsCache.ExpectedUsers = opJoinRandomRoomParams.ExpectedUsers;
		bool num = LoadBalancingPeer.OpJoinRandomRoom(opJoinRandomRoomParams);
		if (num)
		{
			lastJoinType = JoinType.JoinRandomRoom;
			State = ClientState.Joining;
		}
		return num;
	}

	public bool OpJoinRandomOrCreateRoom(OpJoinRandomRoomParams opJoinRandomRoomParams, EnterRoomParams createRoomParams)
	{
		if (!CheckIfOpCanBeSent(225, Server, "OpJoinRandomOrCreateRoom"))
		{
			return false;
		}
		if (opJoinRandomRoomParams == null)
		{
			opJoinRandomRoomParams = new OpJoinRandomRoomParams();
		}
		if (createRoomParams == null)
		{
			createRoomParams = new EnterRoomParams();
		}
		createRoomParams.JoinMode = JoinMode.CreateIfNotExists;
		enterRoomParamsCache = createRoomParams;
		enterRoomParamsCache.Lobby = opJoinRandomRoomParams.TypedLobby;
		enterRoomParamsCache.ExpectedUsers = opJoinRandomRoomParams.ExpectedUsers;
		bool num = LoadBalancingPeer.OpJoinRandomOrCreateRoom(opJoinRandomRoomParams, createRoomParams);
		if (num)
		{
			lastJoinType = JoinType.JoinRandomOrCreateRoom;
			State = ClientState.Joining;
		}
		return num;
	}

	public bool OpCreateRoom(EnterRoomParams enterRoomParams)
	{
		if (!CheckIfOpCanBeSent(227, Server, "CreateGame"))
		{
			return false;
		}
		if (!(enterRoomParams.OnGameServer = Server == ServerConnection.GameServer))
		{
			enterRoomParamsCache = enterRoomParams;
		}
		bool num = LoadBalancingPeer.OpCreateRoom(enterRoomParams);
		if (num)
		{
			lastJoinType = JoinType.CreateRoom;
			State = ClientState.Joining;
		}
		return num;
	}

	public bool OpJoinOrCreateRoom(EnterRoomParams enterRoomParams)
	{
		if (!CheckIfOpCanBeSent(226, Server, "JoinOrCreateRoom"))
		{
			return false;
		}
		bool flag = Server == ServerConnection.GameServer;
		enterRoomParams.JoinMode = JoinMode.CreateIfNotExists;
		enterRoomParams.OnGameServer = flag;
		if (!flag)
		{
			enterRoomParamsCache = enterRoomParams;
		}
		bool num = LoadBalancingPeer.OpJoinRoom(enterRoomParams);
		if (num)
		{
			lastJoinType = JoinType.JoinOrCreateRoom;
			State = ClientState.Joining;
		}
		return num;
	}

	public bool OpJoinRoom(EnterRoomParams enterRoomParams)
	{
		if (!CheckIfOpCanBeSent(226, Server, "JoinRoom"))
		{
			return false;
		}
		if (!(enterRoomParams.OnGameServer = Server == ServerConnection.GameServer))
		{
			enterRoomParamsCache = enterRoomParams;
		}
		bool num = LoadBalancingPeer.OpJoinRoom(enterRoomParams);
		if (num)
		{
			lastJoinType = ((enterRoomParams.JoinMode != JoinMode.CreateIfNotExists) ? JoinType.JoinRoom : JoinType.JoinOrCreateRoom);
			State = ClientState.Joining;
		}
		return num;
	}

	public bool OpRejoinRoom(string roomName)
	{
		if (!CheckIfOpCanBeSent(226, Server, "RejoinRoom"))
		{
			return false;
		}
		bool onGameServer = Server == ServerConnection.GameServer;
		EnterRoomParams enterRoomParams = (enterRoomParamsCache = new EnterRoomParams());
		enterRoomParams.RoomName = roomName;
		enterRoomParams.OnGameServer = onGameServer;
		enterRoomParams.JoinMode = JoinMode.RejoinOnly;
		bool num = LoadBalancingPeer.OpJoinRoom(enterRoomParams);
		if (num)
		{
			lastJoinType = JoinType.JoinRoom;
			State = ClientState.Joining;
		}
		return num;
	}

	public bool OpLeaveRoom(bool becomeInactive, bool sendAuthCookie = false)
	{
		if (!CheckIfOpCanBeSent(254, Server, "LeaveRoom"))
		{
			return false;
		}
		State = ClientState.Leaving;
		GameServerAddress = string.Empty;
		enterRoomParamsCache = null;
		return LoadBalancingPeer.OpLeaveRoom(becomeInactive, sendAuthCookie);
	}

	public bool OpGetGameList(TypedLobby typedLobby, string sqlLobbyFilter)
	{
		if (!CheckIfOpCanBeSent(217, Server, "GetGameList"))
		{
			return false;
		}
		if (string.IsNullOrEmpty(sqlLobbyFilter))
		{
			DebugReturn(DebugLevel.ERROR, "Operation GetGameList requires a filter.");
			return false;
		}
		if (typedLobby.Type != LobbyType.SqlLobby)
		{
			DebugReturn(DebugLevel.ERROR, "Operation GetGameList can only be used for lobbies of type SqlLobby.");
			return false;
		}
		return LoadBalancingPeer.OpGetGameList(typedLobby, sqlLobbyFilter);
	}

	public bool OpSetCustomPropertiesOfActor(int actorNr, ExitGames.Client.Photon.Hashtable propertiesToSet, ExitGames.Client.Photon.Hashtable expectedProperties = null, WebFlags webFlags = null)
	{
		if (propertiesToSet == null || propertiesToSet.Count == 0)
		{
			DebugReturn(DebugLevel.ERROR, "OpSetCustomPropertiesOfActor() failed. propertiesToSet must not be null nor empty.");
			return false;
		}
		if (CurrentRoom == null)
		{
			if (expectedProperties == null && webFlags == null && LocalPlayer != null && LocalPlayer.ActorNumber == actorNr)
			{
				return LocalPlayer.SetCustomProperties(propertiesToSet);
			}
			if ((int)LoadBalancingPeer.DebugOut >= 1)
			{
				DebugReturn(DebugLevel.ERROR, "OpSetCustomPropertiesOfActor() failed. To use expectedProperties or webForward, you have to be in a room. State: " + State);
			}
			return false;
		}
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable.MergeStringKeys(propertiesToSet);
		if (hashtable.Count == 0)
		{
			DebugReturn(DebugLevel.ERROR, "OpSetCustomPropertiesOfActor() failed. Only string keys allowed for custom properties.");
			return false;
		}
		return OpSetPropertiesOfActor(actorNr, hashtable, expectedProperties, webFlags);
	}

	protected internal bool OpSetPropertiesOfActor(int actorNr, ExitGames.Client.Photon.Hashtable actorProperties, ExitGames.Client.Photon.Hashtable expectedProperties = null, WebFlags webFlags = null)
	{
		if (!CheckIfOpCanBeSent(252, Server, "SetProperties"))
		{
			return false;
		}
		if (actorProperties == null || actorProperties.Count == 0)
		{
			DebugReturn(DebugLevel.ERROR, "OpSetPropertiesOfActor() failed. actorProperties must not be null nor empty.");
			return false;
		}
		bool num = LoadBalancingPeer.OpSetPropertiesOfActor(actorNr, actorProperties, expectedProperties, webFlags);
		if (num && !CurrentRoom.BroadcastPropertiesChangeToAll && (expectedProperties == null || expectedProperties.Count == 0))
		{
			Player player = CurrentRoom.GetPlayer(actorNr);
			if (player != null)
			{
				player.InternalCacheProperties(actorProperties);
				InRoomCallbackTargets.OnPlayerPropertiesUpdate(player, actorProperties);
			}
		}
		return num;
	}

	public bool OpSetCustomPropertiesOfRoom(ExitGames.Client.Photon.Hashtable propertiesToSet, ExitGames.Client.Photon.Hashtable expectedProperties = null, WebFlags webFlags = null)
	{
		if (propertiesToSet == null || propertiesToSet.Count == 0)
		{
			DebugReturn(DebugLevel.ERROR, "OpSetCustomPropertiesOfRoom() failed. propertiesToSet must not be null nor empty.");
			return false;
		}
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable.MergeStringKeys(propertiesToSet);
		if (hashtable.Count == 0)
		{
			DebugReturn(DebugLevel.ERROR, "OpSetCustomPropertiesOfRoom() failed. Only string keys are allowed for custom properties.");
			return false;
		}
		return OpSetPropertiesOfRoom(hashtable, expectedProperties, webFlags);
	}

	protected internal bool OpSetPropertyOfRoom(byte propCode, object value)
	{
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable[propCode] = value;
		return OpSetPropertiesOfRoom(hashtable);
	}

	protected internal bool OpSetPropertiesOfRoom(ExitGames.Client.Photon.Hashtable gameProperties, ExitGames.Client.Photon.Hashtable expectedProperties = null, WebFlags webFlags = null)
	{
		if (!CheckIfOpCanBeSent(252, Server, "SetProperties"))
		{
			return false;
		}
		if (gameProperties == null || gameProperties.Count == 0)
		{
			DebugReturn(DebugLevel.ERROR, "OpSetPropertiesOfRoom() failed. gameProperties must not be null nor empty.");
			return false;
		}
		bool num = LoadBalancingPeer.OpSetPropertiesOfRoom(gameProperties, expectedProperties, webFlags);
		if (num && !CurrentRoom.BroadcastPropertiesChangeToAll && (expectedProperties == null || expectedProperties.Count == 0))
		{
			CurrentRoom.InternalCacheProperties(gameProperties);
			InRoomCallbackTargets.OnRoomPropertiesUpdate(gameProperties);
		}
		return num;
	}

	public virtual bool OpRaiseEvent(byte eventCode, object customEventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
	{
		if (!CheckIfOpCanBeSent(253, Server, "RaiseEvent"))
		{
			return false;
		}
		return LoadBalancingPeer.OpRaiseEvent(eventCode, customEventContent, raiseEventOptions, sendOptions);
	}

	public virtual bool OpChangeGroups(byte[] groupsToRemove, byte[] groupsToAdd)
	{
		if (!CheckIfOpCanBeSent(248, Server, "ChangeGroups"))
		{
			return false;
		}
		return LoadBalancingPeer.OpChangeGroups(groupsToRemove, groupsToAdd);
	}

	private void ReadoutProperties(ExitGames.Client.Photon.Hashtable gameProperties, ExitGames.Client.Photon.Hashtable actorProperties, int targetActorNr)
	{
		if (CurrentRoom != null && gameProperties != null)
		{
			CurrentRoom.InternalCacheProperties(gameProperties);
			if (InRoom)
			{
				InRoomCallbackTargets.OnRoomPropertiesUpdate(gameProperties);
			}
		}
		if (actorProperties == null || actorProperties.Count <= 0)
		{
			return;
		}
		if (targetActorNr > 0)
		{
			Player player = CurrentRoom.GetPlayer(targetActorNr);
			if (player != null)
			{
				ExitGames.Client.Photon.Hashtable hashtable = ReadoutPropertiesForActorNr(actorProperties, targetActorNr);
				player.InternalCacheProperties(hashtable);
				InRoomCallbackTargets.OnPlayerPropertiesUpdate(player, hashtable);
			}
			return;
		}
		foreach (object key in actorProperties.Keys)
		{
			int num = (int)key;
			if (num != 0)
			{
				ExitGames.Client.Photon.Hashtable hashtable2 = (ExitGames.Client.Photon.Hashtable)actorProperties[key];
				string actorName = (string)hashtable2[byte.MaxValue];
				Player player2 = CurrentRoom.GetPlayer(num);
				if (player2 == null)
				{
					player2 = CreatePlayer(actorName, num, isLocal: false, hashtable2);
					CurrentRoom.StorePlayer(player2);
				}
				player2.InternalCacheProperties(hashtable2);
			}
		}
	}

	private ExitGames.Client.Photon.Hashtable ReadoutPropertiesForActorNr(ExitGames.Client.Photon.Hashtable actorProperties, int actorNr)
	{
		if (actorProperties.ContainsKey(actorNr))
		{
			return (ExitGames.Client.Photon.Hashtable)actorProperties[actorNr];
		}
		return actorProperties;
	}

	public void ChangeLocalID(int newID)
	{
		if (LocalPlayer == null)
		{
			DebugReturn(DebugLevel.WARNING, $"Local actor is null or not in mActors! mLocalActor: {LocalPlayer} mActors==null: {CurrentRoom.Players == null} newID: {newID}");
		}
		if (CurrentRoom == null)
		{
			LocalPlayer.ChangeLocalID(newID);
			LocalPlayer.RoomReference = null;
		}
		else
		{
			CurrentRoom.RemovePlayer(LocalPlayer);
			LocalPlayer.ChangeLocalID(newID);
			CurrentRoom.StorePlayer(LocalPlayer);
		}
	}

	private void GameEnteredOnGameServer(OperationResponse operationResponse)
	{
		CurrentRoom = CreateRoom(enterRoomParamsCache.RoomName, enterRoomParamsCache.RoomOptions);
		CurrentRoom.LoadBalancingClient = this;
		int newID = (int)operationResponse[254];
		ChangeLocalID(newID);
		if (operationResponse.Parameters.ContainsKey(252))
		{
			int[] actorsInGame = (int[])operationResponse.Parameters[252];
			UpdatedActorList(actorsInGame);
			if (LoadBalancingPeer.enterRoomParams != null)
			{
				if (LoadBalancingPeer.enterRoomParams.RoomOptions != null)
				{
					if (LoadBalancingPeer.enterRoomParams.RoomOptions.IsVisible)
					{
						DebugReturn(DebugLevel.INFO, $"Room option IsVisible is true");
					}
					else
					{
						DebugReturn(DebugLevel.INFO, $"Room option IsVisible is false");
					}
					if (LoadBalancingPeer.enterRoomParams.RoomOptions.IsOpen)
					{
						DebugReturn(DebugLevel.INFO, $"Room option IsOpen is true");
					}
					else
					{
						DebugReturn(DebugLevel.INFO, $"Room option IsOpen is false");
					}
					if (LoadBalancingPeer.enterRoomParams.RoomOptions.DeleteNullProperties)
					{
						DebugReturn(DebugLevel.INFO, $"Room option DeleteNullProperties is true");
					}
					else
					{
						DebugReturn(DebugLevel.INFO, $"Room option DeleteNullProperties is false");
					}
				}
				WebFlags webFlags = new WebFlags(1);
				Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
				dictionary.Add(244, (byte)195);
				dictionary.Add(234, webFlags.WebhookFlags);
				LoadBalancingPeer.SendOperation(253, dictionary, SendOptions.SendReliable);
			}
		}
		ExitGames.Client.Photon.Hashtable actorProperties = (ExitGames.Client.Photon.Hashtable)operationResponse[249];
		ExitGames.Client.Photon.Hashtable gameProperties = (ExitGames.Client.Photon.Hashtable)operationResponse[248];
		ReadoutProperties(gameProperties, actorProperties, 0);
		if (operationResponse.Parameters.TryGetValue(191, out var value))
		{
			CurrentRoom.InternalCacheRoomFlags((int)value);
		}
		State = ClientState.Joined;
		if (CurrentRoom.SuppressRoomEvents)
		{
			if (lastJoinType == JoinType.CreateRoom || (lastJoinType == JoinType.JoinOrCreateRoom && LocalPlayer.ActorNumber == 1))
			{
				MatchMakingCallbackTargets.OnCreatedRoom();
			}
			MatchMakingCallbackTargets.OnJoinedRoom();
		}
	}

	private void UpdatedActorList(int[] actorsInGame)
	{
		if (actorsInGame == null)
		{
			return;
		}
		foreach (int num in actorsInGame)
		{
			if (num != 0 && CurrentRoom.GetPlayer(num) == null)
			{
				CurrentRoom.StorePlayer(CreatePlayer(string.Empty, num, isLocal: false, null));
			}
		}
	}

	protected internal virtual Player CreatePlayer(string actorName, int actorNumber, bool isLocal, ExitGames.Client.Photon.Hashtable actorProperties)
	{
		return new Player(actorName, actorNumber, isLocal, actorProperties);
	}

	protected internal virtual Room CreateRoom(string roomName, RoomOptions opt)
	{
		return new Room(roomName, opt);
	}

	private bool CheckIfOpAllowedOnServer(byte opCode, ServerConnection serverConnection)
	{
		switch (serverConnection)
		{
		case ServerConnection.MasterServer:
			switch (opCode)
			{
			case 217:
			case 218:
			case 219:
			case 221:
			case 222:
			case 225:
			case 226:
			case 227:
			case 228:
			case 229:
			case 230:
			case 231:
				return true;
			}
			break;
		case ServerConnection.GameServer:
			switch (opCode)
			{
			case 218:
			case 219:
			case 226:
			case 227:
			case 230:
			case 231:
			case 248:
			case 251:
			case 252:
			case 253:
			case 254:
				return true;
			}
			break;
		case ServerConnection.NameServer:
			if (opCode == 218 || opCode == 220 || (uint)(opCode - 230) <= 1u)
			{
				return true;
			}
			break;
		default:
			throw new ArgumentOutOfRangeException("serverConnection", serverConnection, null);
		}
		return false;
	}

	private bool CheckIfOpCanBeSent(byte opCode, ServerConnection serverConnection, string opName)
	{
		if (LoadBalancingPeer == null)
		{
			DebugReturn(DebugLevel.ERROR, $"Operation {opName} ({opCode}) can't be sent because peer is null");
			return false;
		}
		if (!CheckIfOpAllowedOnServer(opCode, serverConnection))
		{
			if ((int)LoadBalancingPeer.DebugOut >= 1)
			{
				DebugReturn(DebugLevel.ERROR, $"Operation {opName} ({opCode}) not allowed on current server ({serverConnection})");
			}
			return false;
		}
		if (!CheckIfClientIsReadyToCallOperation(opCode))
		{
			DebugLevel debugLevel = DebugLevel.ERROR;
			if (opCode == 253 && (State == ClientState.Leaving || State == ClientState.Disconnecting || State == ClientState.DisconnectingFromGameServer))
			{
				debugLevel = DebugLevel.INFO;
			}
			if ((int)LoadBalancingPeer.DebugOut >= (int)debugLevel)
			{
				DebugReturn(debugLevel, $"Operation {opName} ({opCode}) not called because client is not connected or not ready yet, client state: {Enum.GetName(typeof(ClientState), State)}");
			}
			return false;
		}
		if (LoadBalancingPeer.PeerState != PeerStateValue.Connected)
		{
			DebugReturn(DebugLevel.ERROR, $"Operation {opName} ({opCode}) can't be sent because peer is not connected, peer state: {LoadBalancingPeer.PeerState}");
			return false;
		}
		return true;
	}

	private bool CheckIfClientIsReadyToCallOperation(byte opCode)
	{
		switch (opCode)
		{
		case 230:
		case 231:
			if (!IsConnectedAndReady && State != ClientState.ConnectingToNameServer && State != ClientState.ConnectingToMasterServer)
			{
				return State == ClientState.ConnectingToGameServer;
			}
			return true;
		case 248:
		case 251:
		case 252:
		case 253:
		case 254:
			return InRoom;
		case 226:
		case 227:
			if (State != ClientState.ConnectedToMasterServer && !InLobby)
			{
				return State == ClientState.ConnectedToGameServer;
			}
			return true;
		case 228:
			return InLobby;
		case 222:
			LoadBalancingPeer.enterRoomParams = new EnterRoomParams();
			goto case 217;
		case 217:
		case 221:
		case 225:
		case 229:
			if (State != ClientState.ConnectedToMasterServer)
			{
				return InLobby;
			}
			return true;
		case 220:
			return State == ClientState.ConnectedToNameServer;
		default:
			return IsConnected;
		}
	}

	public virtual void DebugReturn(DebugLevel level, string message)
	{
		if (LoadBalancingPeer.DebugOut == DebugLevel.ALL || (int)level <= (int)LoadBalancingPeer.DebugOut)
		{
			switch (level)
			{
			case DebugLevel.ERROR:
				UnityEngine.Debug.LogError(message);
				break;
			case DebugLevel.WARNING:
				UnityEngine.Debug.LogWarning(message);
				break;
			case DebugLevel.INFO:
				UnityEngine.Debug.Log(message);
				break;
			case DebugLevel.ALL:
				UnityEngine.Debug.Log(message);
				break;
			}
		}
	}

	private void CallbackRoomEnterFailed(OperationResponse operationResponse)
	{
		if (operationResponse.ReturnCode != 0)
		{
			if (operationResponse.OperationCode == 226)
			{
				MatchMakingCallbackTargets.OnJoinRoomFailed(operationResponse.ReturnCode, operationResponse.DebugMessage);
			}
			else if (operationResponse.OperationCode == 227)
			{
				MatchMakingCallbackTargets.OnCreateRoomFailed(operationResponse.ReturnCode, operationResponse.DebugMessage);
			}
			else if (operationResponse.OperationCode == 225)
			{
				MatchMakingCallbackTargets.OnJoinRandomFailed(operationResponse.ReturnCode, operationResponse.DebugMessage);
			}
		}
	}

	public virtual void OnOperationResponse(OperationResponse operationResponse)
	{
		if (operationResponse.Parameters.ContainsKey(221))
		{
			if (AuthValues == null)
			{
				AuthValues = new AuthenticationValues();
			}
			AuthValues.Token = operationResponse[221] as string;
			tokenCache = AuthValues.Token;
		}
		if (operationResponse.ReturnCode == 32743)
		{
			Disconnect(DisconnectCause.DisconnectByOperationLimit);
		}
		switch (operationResponse.OperationCode)
		{
		case 230:
		case 231:
		{
			if (operationResponse.ReturnCode != 0)
			{
				DebugReturn(DebugLevel.WARNING, operationResponse.ToStringFull() + " Server: " + Server.ToString() + " Address: " + LoadBalancingPeer.ServerAddress);
				switch (operationResponse.ReturnCode)
				{
				case short.MaxValue:
					DisconnectedCause = DisconnectCause.InvalidAuthentication;
					break;
				case 32755:
					DisconnectedCause = DisconnectCause.CustomAuthenticationFailed;
					ConnectionCallbackTargets.OnCustomAuthenticationFailed(operationResponse.DebugMessage);
					break;
				case 32756:
					DisconnectedCause = DisconnectCause.InvalidRegion;
					break;
				case 32757:
					DisconnectedCause = DisconnectCause.MaxCcuReached;
					break;
				case -3:
				case -2:
					DisconnectedCause = DisconnectCause.OperationNotAllowedInCurrentState;
					break;
				case 32753:
					DisconnectedCause = DisconnectCause.AuthenticationTicketExpired;
					break;
				}
				Disconnect(DisconnectedCause);
				break;
			}
			if (Server == ServerConnection.NameServer || Server == ServerConnection.MasterServer)
			{
				if (operationResponse.Parameters.ContainsKey(225))
				{
					string text3 = (string)operationResponse.Parameters[225];
					if (!string.IsNullOrEmpty(text3))
					{
						UserId = text3;
						LocalPlayer.UserId = text3;
						DebugReturn(DebugLevel.INFO, $"Received your UserID from server. Updating local value to: {UserId}");
					}
				}
				if (operationResponse.Parameters.ContainsKey(202))
				{
					NickName = (string)operationResponse.Parameters[202];
					DebugReturn(DebugLevel.INFO, $"Received your NickName from server. Updating local value to: {NickName}");
				}
				if (operationResponse.Parameters.ContainsKey(192))
				{
					SetupEncryption((Dictionary<byte, object>)operationResponse.Parameters[192]);
				}
			}
			if (Server == ServerConnection.NameServer)
			{
				string text4 = operationResponse[196] as string;
				if (!string.IsNullOrEmpty(text4))
				{
					CurrentCluster = text4;
				}
				MasterServerAddress = operationResponse[230] as string;
				if (ServerPortOverrides.MasterServerPort != 0)
				{
					MasterServerAddress = ReplacePortWithAlternative(MasterServerAddress, ServerPortOverrides.MasterServerPort);
				}
				if (AuthMode == AuthModeOption.AuthOnceWss && ExpectedProtocol.HasValue)
				{
					DebugReturn(DebugLevel.INFO, $"AuthOnceWss mode. Auth response switches TransportProtocol to ExpectedProtocol: {ExpectedProtocol}.");
					LoadBalancingPeer.TransportProtocol = ExpectedProtocol.Value;
					ExpectedProtocol = null;
				}
				DisconnectToReconnect();
			}
			else if (Server == ServerConnection.MasterServer)
			{
				State = ClientState.ConnectedToMasterServer;
				if (failedRoomEntryOperation == null)
				{
					ConnectionCallbackTargets.OnConnectedToMaster();
				}
				else
				{
					CallbackRoomEnterFailed(failedRoomEntryOperation);
					failedRoomEntryOperation = null;
				}
				if (AuthMode != AuthModeOption.Auth)
				{
					LoadBalancingPeer.OpSettings(EnableLobbyStatistics);
				}
			}
			else if (Server == ServerConnection.GameServer)
			{
				State = ClientState.Joining;
				if (enterRoomParamsCache.JoinMode == JoinMode.RejoinOnly)
				{
					enterRoomParamsCache.PlayerProperties = null;
				}
				else
				{
					ExitGames.Client.Photon.Hashtable hashtable2 = new ExitGames.Client.Photon.Hashtable();
					hashtable2.Merge(LocalPlayer.CustomProperties);
					if (!string.IsNullOrEmpty(LocalPlayer.NickName))
					{
						hashtable2[byte.MaxValue] = LocalPlayer.NickName;
					}
					enterRoomParamsCache.PlayerProperties = hashtable2;
				}
				enterRoomParamsCache.OnGameServer = true;
				if (lastJoinType == JoinType.JoinRoom || lastJoinType == JoinType.JoinRandomRoom || lastJoinType == JoinType.JoinRandomOrCreateRoom || lastJoinType == JoinType.JoinOrCreateRoom)
				{
					LoadBalancingPeer.OpJoinRoom(enterRoomParamsCache);
				}
				else if (lastJoinType == JoinType.CreateRoom)
				{
					LoadBalancingPeer.OpCreateRoom(enterRoomParamsCache);
				}
				break;
			}
			Dictionary<string, object> dictionary = (Dictionary<string, object>)operationResponse[245];
			if (dictionary != null)
			{
				ConnectionCallbackTargets.OnCustomAuthenticationResponse(dictionary);
			}
			break;
		}
		case 220:
			if (operationResponse.ReturnCode == short.MaxValue)
			{
				DebugReturn(DebugLevel.ERROR, string.Format("GetRegions failed. AppId is unknown on the (cloud) server. " + operationResponse.DebugMessage));
				Disconnect(DisconnectCause.InvalidAuthentication);
				break;
			}
			if (operationResponse.ReturnCode != 0)
			{
				DebugReturn(DebugLevel.ERROR, "GetRegions failed. Can't provide regions list. ReturnCode: " + operationResponse.ReturnCode + ": " + operationResponse.DebugMessage);
				Disconnect(DisconnectCause.InvalidAuthentication);
				break;
			}
			if (RegionHandler == null)
			{
				RegionHandler = new RegionHandler(ServerPortOverrides.MasterServerPort);
			}
			if (RegionHandler.IsPinging)
			{
				DebugReturn(DebugLevel.WARNING, "Received an response for OpGetRegions while the RegionHandler is pinging regions already. Skipping this response in favor of completing the current region-pinging.");
				return;
			}
			RegionHandler.SetRegions(operationResponse);
			ConnectionCallbackTargets.OnRegionListReceived(RegionHandler);
			if (connectToBestRegion)
			{
				RegionHandler.PingMinimumOfRegions(OnRegionPingCompleted, bestRegionSummaryFromStorage);
			}
			break;
		case 225:
		case 226:
		case 227:
		{
			if (operationResponse.ReturnCode != 0)
			{
				if (Server == ServerConnection.GameServer)
				{
					failedRoomEntryOperation = operationResponse;
					DisconnectToReconnect();
				}
				else
				{
					State = (InLobby ? ClientState.JoinedLobby : ClientState.ConnectedToMasterServer);
					CallbackRoomEnterFailed(operationResponse);
				}
				break;
			}
			if (Server == ServerConnection.GameServer)
			{
				GameEnteredOnGameServer(operationResponse);
				break;
			}
			GameServerAddress = (string)operationResponse[230];
			if (ServerPortOverrides.GameServerPort != 0)
			{
				GameServerAddress = ReplacePortWithAlternative(GameServerAddress, ServerPortOverrides.GameServerPort);
			}
			string text2 = operationResponse[byte.MaxValue] as string;
			if (!string.IsNullOrEmpty(text2))
			{
				enterRoomParamsCache.RoomName = text2;
			}
			DisconnectToReconnect();
			break;
		}
		case 217:
		{
			if (operationResponse.ReturnCode != 0)
			{
				DebugReturn(DebugLevel.ERROR, "GetGameList failed: " + operationResponse.ToStringFull());
				break;
			}
			List<RoomInfo> list2 = new List<RoomInfo>();
			ExitGames.Client.Photon.Hashtable hashtable = (ExitGames.Client.Photon.Hashtable)operationResponse[222];
			foreach (string key in hashtable.Keys)
			{
				list2.Add(new RoomInfo(key, (ExitGames.Client.Photon.Hashtable)hashtable[key]));
			}
			LobbyCallbackTargets.OnRoomListUpdate(list2);
			break;
		}
		case 229:
			State = ClientState.JoinedLobby;
			LobbyCallbackTargets.OnJoinedLobby();
			break;
		case 228:
			State = ClientState.ConnectedToMasterServer;
			LobbyCallbackTargets.OnLeftLobby();
			break;
		case 254:
			DisconnectToReconnect();
			break;
		case 223:
		{
			if (operationResponse.ReturnCode != 0)
			{
				DebugReturn(DebugLevel.ERROR, "OpFindFriends failed: " + operationResponse.ToStringFull());
				friendListRequested = null;
				break;
			}
			bool[] array = operationResponse[1] as bool[];
			string[] array2 = operationResponse[2] as string[];
			List<FriendInfo> list = new List<FriendInfo>(friendListRequested.Length);
			for (int i = 0; i < friendListRequested.Length; i++)
			{
				FriendInfo friendInfo = new FriendInfo();
				friendInfo.UserId = friendListRequested[i];
				friendInfo.Room = array2[i];
				friendInfo.IsOnline = array[i];
				list.Insert(i, friendInfo);
			}
			friendListRequested = null;
			MatchMakingCallbackTargets.OnFriendListUpdate(list);
			break;
		}
		case 219:
			WebRpcCallbackTargets.OnWebRpcResponse(operationResponse);
			break;
		}
		if (this.OpResponseReceived != null)
		{
			this.OpResponseReceived(operationResponse);
		}
	}

	public virtual void OnStatusChanged(StatusCode statusCode)
	{
		switch (statusCode)
		{
		case StatusCode.Connect:
			if (State == ClientState.ConnectingToNameServer)
			{
				if ((int)LoadBalancingPeer.DebugOut >= 5)
				{
					DebugReturn(DebugLevel.ALL, "Connected to nameserver.");
				}
				Server = ServerConnection.NameServer;
				if (AuthValues != null)
				{
					AuthValues.Token = null;
				}
			}
			if (State == ClientState.ConnectingToGameServer)
			{
				if ((int)LoadBalancingPeer.DebugOut >= 5)
				{
					DebugReturn(DebugLevel.ALL, "Connected to gameserver.");
				}
				Server = ServerConnection.GameServer;
			}
			if (State == ClientState.ConnectingToMasterServer)
			{
				if ((int)LoadBalancingPeer.DebugOut >= 5)
				{
					DebugReturn(DebugLevel.ALL, "Connected to masterserver.");
				}
				Server = ServerConnection.MasterServer;
				ConnectionCallbackTargets.OnConnected();
			}
			if (LoadBalancingPeer.TransportProtocol != ConnectionProtocol.WebSocketSecure)
			{
				if (Server == ServerConnection.NameServer || AuthMode == AuthModeOption.Auth)
				{
					LoadBalancingPeer.EstablishEncryption();
				}
				break;
			}
			goto case StatusCode.EncryptionEstablished;
		case StatusCode.EncryptionEstablished:
			if (Server == ServerConnection.NameServer)
			{
				State = ClientState.ConnectedToNameServer;
				if (string.IsNullOrEmpty(CloudRegion))
				{
					OpGetRegions();
					break;
				}
			}
			else if (AuthMode == AuthModeOption.AuthOnce || AuthMode == AuthModeOption.AuthOnceWss)
			{
				break;
			}
			if (CallAuthenticate())
			{
				State = ClientState.Authenticating;
			}
			else
			{
				DebugReturn(DebugLevel.ERROR, "OpAuthenticate failed. Check log output and AuthValues. State: " + State);
			}
			break;
		case StatusCode.Disconnect:
		{
			friendListRequested = null;
			bool flag = CurrentRoom != null;
			CurrentRoom = null;
			ChangeLocalID(-1);
			if (Server == ServerConnection.GameServer && flag)
			{
				MatchMakingCallbackTargets.OnLeftRoom();
			}
			if (ExpectedProtocol.HasValue && LoadBalancingPeer.TransportProtocol != ExpectedProtocol)
			{
				DebugReturn(DebugLevel.INFO, $"On disconnect switches TransportProtocol to ExpectedProtocol: {ExpectedProtocol}.");
				LoadBalancingPeer.TransportProtocol = ExpectedProtocol.Value;
				ExpectedProtocol = null;
			}
			switch (State)
			{
			case ClientState.ConnectWithFallbackProtocol:
				EnableProtocolFallback = false;
				LoadBalancingPeer.TransportProtocol = ((LoadBalancingPeer.TransportProtocol != ConnectionProtocol.Tcp) ? ConnectionProtocol.Tcp : ConnectionProtocol.Udp);
				NameServerPortInAppSettings = 0;
				ServerPortOverrides = default(PhotonPortDefinition);
				if (LoadBalancingPeer.Connect(NameServerAddress, ProxyServerAddress, AppId, TokenForInit))
				{
					State = ClientState.ConnectingToNameServer;
				}
				break;
			case ClientState.PeerCreated:
			case ClientState.Disconnecting:
				if (AuthValues != null)
				{
					AuthValues.Token = null;
				}
				State = ClientState.Disconnected;
				ConnectionCallbackTargets.OnDisconnected(DisconnectedCause);
				break;
			case ClientState.DisconnectingFromGameServer:
			case ClientState.DisconnectingFromNameServer:
				ConnectToMasterServer();
				break;
			case ClientState.DisconnectingFromMasterServer:
				Connect(GameServerAddress, ProxyServerAddress, ServerConnection.GameServer);
				break;
			default:
			{
				string text = "";
				DebugReturn(DebugLevel.WARNING, "Got a unexpected Disconnect in LoadBalancingClient State: " + State.ToString() + ". Server: " + Server.ToString() + " Trace: " + text);
				if (AuthValues != null)
				{
					AuthValues.Token = null;
				}
				State = ClientState.Disconnected;
				ConnectionCallbackTargets.OnDisconnected(DisconnectedCause);
				break;
			}
			case ClientState.Disconnected:
				break;
			}
			break;
		}
		case StatusCode.DisconnectByServerUserLimit:
			DebugReturn(DebugLevel.ERROR, "This connection was rejected due to the apps CCU limit.");
			DisconnectedCause = DisconnectCause.MaxCcuReached;
			State = ClientState.Disconnecting;
			break;
		case StatusCode.DnsExceptionOnConnect:
			DisconnectedCause = DisconnectCause.DnsExceptionOnConnect;
			State = ClientState.Disconnecting;
			break;
		case StatusCode.ServerAddressInvalid:
			DisconnectedCause = DisconnectCause.ServerAddressInvalid;
			State = ClientState.Disconnecting;
			break;
		case StatusCode.SecurityExceptionOnConnect:
		case StatusCode.ExceptionOnConnect:
		case StatusCode.EncryptionFailedToEstablish:
			DisconnectedCause = DisconnectCause.ExceptionOnConnect;
			if (EnableProtocolFallback && State == ClientState.ConnectingToNameServer)
			{
				State = ClientState.ConnectWithFallbackProtocol;
			}
			else
			{
				State = ClientState.Disconnecting;
			}
			break;
		case StatusCode.Exception:
		case StatusCode.SendError:
		case StatusCode.ExceptionOnReceive:
			DisconnectedCause = DisconnectCause.Exception;
			State = ClientState.Disconnecting;
			break;
		case StatusCode.DisconnectByServerTimeout:
			DisconnectedCause = DisconnectCause.ServerTimeout;
			State = ClientState.Disconnecting;
			break;
		case StatusCode.DisconnectByServerLogic:
			DisconnectedCause = DisconnectCause.DisconnectByServerLogic;
			State = ClientState.Disconnecting;
			break;
		case StatusCode.DisconnectByServerReasonUnknown:
			DisconnectedCause = DisconnectCause.DisconnectByServerReasonUnknown;
			State = ClientState.Disconnecting;
			break;
		case StatusCode.TimeoutDisconnect:
			DisconnectedCause = DisconnectCause.ClientTimeout;
			if (EnableProtocolFallback && State == ClientState.ConnectingToNameServer)
			{
				State = ClientState.ConnectWithFallbackProtocol;
			}
			else
			{
				State = ClientState.Disconnecting;
			}
			break;
		case (StatusCode)1027:
		case (StatusCode)1028:
		case (StatusCode)1029:
		case (StatusCode)1031:
		case (StatusCode)1032:
		case (StatusCode)1033:
		case (StatusCode)1034:
		case (StatusCode)1035:
		case (StatusCode)1036:
		case (StatusCode)1037:
		case (StatusCode)1038:
		case (StatusCode)1045:
		case (StatusCode)1046:
		case (StatusCode)1047:
			break;
		}
	}

	public virtual void OnEvent(EventData photonEvent)
	{
		int sender = photonEvent.Sender;
		Player player = ((CurrentRoom != null) ? CurrentRoom.GetPlayer(sender) : null);
		switch (photonEvent.Code)
		{
		case 229:
		case 230:
		{
			List<RoomInfo> list = new List<RoomInfo>();
			ExitGames.Client.Photon.Hashtable hashtable4 = (ExitGames.Client.Photon.Hashtable)photonEvent[222];
			foreach (string key in hashtable4.Keys)
			{
				list.Add(new RoomInfo(key, (ExitGames.Client.Photon.Hashtable)hashtable4[key]));
			}
			LobbyCallbackTargets.OnRoomListUpdate(list);
			break;
		}
		case byte.MaxValue:
		{
			ExitGames.Client.Photon.Hashtable hashtable = (ExitGames.Client.Photon.Hashtable)photonEvent[249];
			if (player == null)
			{
				if (sender > 0)
				{
					player = CreatePlayer(string.Empty, sender, isLocal: false, hashtable);
					CurrentRoom.StorePlayer(player);
				}
			}
			else
			{
				player.InternalCacheProperties(hashtable);
				player.IsInactive = false;
				player.HasRejoined = sender != LocalPlayer.ActorNumber;
			}
			if (sender == LocalPlayer.ActorNumber)
			{
				int[] actorsInGame = (int[])photonEvent[252];
				UpdatedActorList(actorsInGame);
				player.HasRejoined = enterRoomParamsCache.JoinMode == JoinMode.RejoinOnly;
				if (lastJoinType == JoinType.CreateRoom || (lastJoinType == JoinType.JoinOrCreateRoom && LocalPlayer.ActorNumber == 1))
				{
					MatchMakingCallbackTargets.OnCreatedRoom();
				}
				MatchMakingCallbackTargets.OnJoinedRoom();
			}
			else
			{
				InRoomCallbackTargets.OnPlayerEnteredRoom(player);
			}
			break;
		}
		case 254:
			if (player != null)
			{
				bool flag2 = false;
				if (photonEvent.Parameters.ContainsKey(233))
				{
					flag2 = (bool)photonEvent.Parameters[233];
				}
				if (flag2)
				{
					player.IsInactive = true;
				}
				else
				{
					player.IsInactive = false;
					CurrentRoom.RemovePlayer(sender);
				}
			}
			if (photonEvent.Parameters.ContainsKey(203))
			{
				int num3 = (int)photonEvent[203];
				if (num3 != 0)
				{
					CurrentRoom.masterClientId = num3;
					InRoomCallbackTargets.OnMasterClientSwitched(CurrentRoom.GetPlayer(num3));
				}
			}
			InRoomCallbackTargets.OnPlayerLeftRoom(player);
			break;
		case 253:
		{
			int num = 0;
			if (photonEvent.Parameters.ContainsKey(253))
			{
				if (!(photonEvent[253] is int num2))
				{
					return;
				}
				num = num2;
			}
			ExitGames.Client.Photon.Hashtable gameProperties = null;
			ExitGames.Client.Photon.Hashtable actorProperties = null;
			if (num == 0)
			{
				if (!(photonEvent[251] is ExitGames.Client.Photon.Hashtable hashtable2))
				{
					return;
				}
				gameProperties = hashtable2;
			}
			else
			{
				if (!(photonEvent[251] is ExitGames.Client.Photon.Hashtable hashtable3))
				{
					return;
				}
				actorProperties = hashtable3;
			}
			ReadoutProperties(gameProperties, actorProperties, num);
			break;
		}
		case 226:
			PlayersInRoomsCount = (int)photonEvent[229];
			RoomsCount = (int)photonEvent[228];
			PlayersOnMasterCount = (int)photonEvent[227];
			break;
		case 224:
		{
			string[] array = photonEvent[213] as string[];
			int[] array2 = photonEvent[229] as int[];
			int[] array3 = photonEvent[228] as int[];
			ByteArraySlice byteArraySlice = photonEvent[212] as ByteArraySlice;
			bool flag = byteArraySlice != null;
			byte[] array4 = ((!flag) ? (photonEvent[212] as byte[]) : byteArraySlice.Buffer);
			lobbyStatistics.Clear();
			for (int i = 0; i < array.Length; i++)
			{
				TypedLobbyInfo typedLobbyInfo = new TypedLobbyInfo();
				typedLobbyInfo.Name = array[i];
				typedLobbyInfo.Type = (LobbyType)array4[i];
				typedLobbyInfo.PlayerCount = array2[i];
				typedLobbyInfo.RoomCount = array3[i];
				lobbyStatistics.Add(typedLobbyInfo);
			}
			if (flag)
			{
				byteArraySlice.Release();
			}
			LobbyCallbackTargets.OnLobbyStatisticsUpdate(lobbyStatistics);
			break;
		}
		case 251:
			ErrorInfoCallbackTargets.OnErrorInfo(new ErrorInfo(photonEvent));
			break;
		case 223:
			if (AuthValues == null)
			{
				AuthValues = new AuthenticationValues();
			}
			AuthValues.Token = photonEvent[221] as string;
			tokenCache = AuthValues.Token;
			break;
		}
		UpdateCallbackTargets();
		if (this.EventReceived != null)
		{
			this.EventReceived(photonEvent);
		}
	}

	public virtual void OnMessage(object message)
	{
		DebugReturn(DebugLevel.ALL, $"got OnMessage {message}");
	}

	private void OnDisconnectMessageReceived(DisconnectMessage obj)
	{
		DebugReturn(DebugLevel.ERROR, $"Got DisconnectMessage. Code: {obj.Code} Msg: \"{obj.DebugMessage}\". Debug Info: {obj.Parameters.ToStringFull()}");
		Disconnect(DisconnectCause.DisconnectByDisconnectMessage);
	}

	private void OnRegionPingCompleted(RegionHandler regionHandler)
	{
		SummaryToCache = regionHandler.SummaryToCache;
		ConnectToRegionMaster(regionHandler.BestRegion.Code);
	}

	protected internal static string ReplacePortWithAlternative(string address, ushort replacementPort)
	{
		if (address.StartsWith("ws"))
		{
			return new UriBuilder(address)
			{
				Port = replacementPort
			}.ToString();
		}
		UriBuilder uriBuilder = new UriBuilder($"scheme://{address}");
		return $"{uriBuilder.Host}:{replacementPort}";
	}

	private void SetupEncryption(Dictionary<byte, object> encryptionData)
	{
		EncryptionMode encryptionMode = (EncryptionMode)(byte)encryptionData[0];
		switch (encryptionMode)
		{
		case EncryptionMode.PayloadEncryption:
		{
			byte[] secret = (byte[])encryptionData[1];
			LoadBalancingPeer.InitPayloadEncryption(secret);
			break;
		}
		case EncryptionMode.DatagramEncryption:
		case EncryptionMode.DatagramEncryptionRandomSequence:
		{
			byte[] encryptionSecret2 = (byte[])encryptionData[1];
			byte[] hmacSecret = (byte[])encryptionData[2];
			LoadBalancingPeer.InitDatagramEncryption(encryptionSecret2, hmacSecret, encryptionMode == EncryptionMode.DatagramEncryptionRandomSequence);
			break;
		}
		case EncryptionMode.DatagramEncryptionGCM:
		{
			byte[] encryptionSecret = (byte[])encryptionData[1];
			LoadBalancingPeer.InitDatagramEncryption(encryptionSecret, null, randomizedSequenceNumbers: true, chainingModeGCM: true);
			break;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public bool OpWebRpc(string uriPath, object parameters, bool sendAuthCookie = false)
	{
		if (string.IsNullOrEmpty(uriPath))
		{
			DebugReturn(DebugLevel.ERROR, "WebRPC method name must not be null nor empty.");
			return false;
		}
		if (!CheckIfOpCanBeSent(219, Server, "WebRpc"))
		{
			return false;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary.Add(209, uriPath);
		if (parameters != null)
		{
			dictionary.Add(208, parameters);
		}
		if (sendAuthCookie)
		{
			dictionary.Add(234, (byte)2);
		}
		return LoadBalancingPeer.SendOperation(219, dictionary, SendOptions.SendReliable);
	}

	public void AddCallbackTarget(object target)
	{
		callbackTargetChanges.Enqueue(new CallbackTargetChange(target, addTarget: true));
	}

	public void RemoveCallbackTarget(object target)
	{
		callbackTargetChanges.Enqueue(new CallbackTargetChange(target, addTarget: false));
	}

	protected internal void UpdateCallbackTargets()
	{
		while (callbackTargetChanges.Count > 0)
		{
			CallbackTargetChange callbackTargetChange = callbackTargetChanges.Dequeue();
			if (callbackTargetChange.AddTarget)
			{
				if (callbackTargets.Contains(callbackTargetChange.Target))
				{
					continue;
				}
				callbackTargets.Add(callbackTargetChange.Target);
			}
			else
			{
				if (!callbackTargets.Contains(callbackTargetChange.Target))
				{
					continue;
				}
				callbackTargets.Remove(callbackTargetChange.Target);
			}
			UpdateCallbackTarget(callbackTargetChange, InRoomCallbackTargets);
			UpdateCallbackTarget(callbackTargetChange, ConnectionCallbackTargets);
			UpdateCallbackTarget(callbackTargetChange, MatchMakingCallbackTargets);
			UpdateCallbackTarget(callbackTargetChange, LobbyCallbackTargets);
			UpdateCallbackTarget(callbackTargetChange, WebRpcCallbackTargets);
			UpdateCallbackTarget(callbackTargetChange, ErrorInfoCallbackTargets);
			if (callbackTargetChange.Target is IOnEventCallback onEventCallback)
			{
				if (callbackTargetChange.AddTarget)
				{
					EventReceived += onEventCallback.OnEvent;
				}
				else
				{
					EventReceived -= onEventCallback.OnEvent;
				}
			}
		}
	}

	private void UpdateCallbackTarget<T>(CallbackTargetChange change, List<T> container) where T : class
	{
		if (change.Target is T item)
		{
			if (change.AddTarget)
			{
				container.Add(item);
			}
			else
			{
				container.Remove(item);
			}
		}
	}
}
public interface IConnectionCallbacks
{
	void OnConnected();

	void OnConnectedToMaster();

	void OnDisconnected(DisconnectCause cause);

	void OnRegionListReceived(RegionHandler regionHandler);

	void OnCustomAuthenticationResponse(Dictionary<string, object> data);

	void OnCustomAuthenticationFailed(string debugMessage);
}
public interface ILobbyCallbacks
{
	void OnJoinedLobby();

	void OnLeftLobby();

	void OnRoomListUpdate(List<RoomInfo> roomList);

	void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics);
}
public interface IMatchmakingCallbacks
{
	void OnFriendListUpdate(List<FriendInfo> friendList);

	void OnCreatedRoom();

	void OnCreateRoomFailed(short returnCode, string message);

	void OnJoinedRoom();

	void OnJoinRoomFailed(short returnCode, string message);

	void OnJoinRandomFailed(short returnCode, string message);

	void OnLeftRoom();

	void OnPreLeavingRoom();
}
public interface IInRoomCallbacks
{
	void OnPlayerEnteredRoom(Player newPlayer);

	void OnPlayerLeftRoom(Player otherPlayer);

	void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged);

	void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps);

	void OnMasterClientSwitched(Player newMasterClient);
}
public interface IOnEventCallback
{
	void OnEvent(EventData photonEvent);
}
public interface IWebRpcCallback
{
	void OnWebRpcResponse(OperationResponse response);
}
public interface IErrorInfoCallback
{
	void OnErrorInfo(ErrorInfo errorInfo);
}
public class ConnectionCallbacksContainer : List<IConnectionCallbacks>, IConnectionCallbacks
{
	private readonly LoadBalancingClient client;

	public ConnectionCallbacksContainer(LoadBalancingClient client)
	{
		this.client = client;
	}

	public void OnConnected()
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnConnected();
		}
	}

	public void OnConnectedToMaster()
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnConnectedToMaster();
		}
	}

	public void OnRegionListReceived(RegionHandler regionHandler)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnRegionListReceived(regionHandler);
		}
	}

	public void OnDisconnected(DisconnectCause cause)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnDisconnected(cause);
		}
	}

	public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnCustomAuthenticationResponse(data);
		}
	}

	public void OnCustomAuthenticationFailed(string debugMessage)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnCustomAuthenticationFailed(debugMessage);
		}
	}
}
public class MatchMakingCallbacksContainer : List<IMatchmakingCallbacks>, IMatchmakingCallbacks
{
	private readonly LoadBalancingClient client;

	public MatchMakingCallbacksContainer(LoadBalancingClient client)
	{
		this.client = client;
	}

	public void OnCreatedRoom()
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnCreatedRoom();
		}
	}

	public void OnJoinedRoom()
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnJoinedRoom();
		}
	}

	public void OnCreateRoomFailed(short returnCode, string message)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnCreateRoomFailed(returnCode, message);
		}
	}

	public void OnJoinRandomFailed(short returnCode, string message)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnJoinRandomFailed(returnCode, message);
		}
	}

	public void OnJoinRoomFailed(short returnCode, string message)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnJoinRoomFailed(returnCode, message);
		}
	}

	public void OnLeftRoom()
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			IMatchmakingCallbacks current = enumerator.Current;
			try
			{
				current.OnLeftRoom();
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
		}
	}

	public void OnPreLeavingRoom()
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			IMatchmakingCallbacks current = enumerator.Current;
			try
			{
				current.OnPreLeavingRoom();
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
		}
	}

	public void OnFriendListUpdate(List<FriendInfo> friendList)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnFriendListUpdate(friendList);
		}
	}
}
internal class InRoomCallbacksContainer : List<IInRoomCallbacks>, IInRoomCallbacks
{
	private readonly LoadBalancingClient client;

	public InRoomCallbacksContainer(LoadBalancingClient client)
	{
		this.client = client;
	}

	public void OnPlayerEnteredRoom(Player newPlayer)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnPlayerEnteredRoom(newPlayer);
		}
	}

	public void OnPlayerLeftRoom(Player otherPlayer)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnPlayerLeftRoom(otherPlayer);
		}
	}

	public void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnRoomPropertiesUpdate(propertiesThatChanged);
		}
	}

	public void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProp)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnPlayerPropertiesUpdate(targetPlayer, changedProp);
		}
	}

	public void OnMasterClientSwitched(Player newMasterClient)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnMasterClientSwitched(newMasterClient);
		}
	}
}
internal class LobbyCallbacksContainer : List<ILobbyCallbacks>, ILobbyCallbacks
{
	private readonly LoadBalancingClient client;

	public LobbyCallbacksContainer(LoadBalancingClient client)
	{
		this.client = client;
	}

	public void OnJoinedLobby()
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnJoinedLobby();
		}
	}

	public void OnLeftLobby()
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnLeftLobby();
		}
	}

	public void OnRoomListUpdate(List<RoomInfo> roomList)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnRoomListUpdate(roomList);
		}
	}

	public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnLobbyStatisticsUpdate(lobbyStatistics);
		}
	}
}
internal class WebRpcCallbacksContainer : List<IWebRpcCallback>, IWebRpcCallback
{
	private LoadBalancingClient client;

	public WebRpcCallbacksContainer(LoadBalancingClient client)
	{
		this.client = client;
	}

	public void OnWebRpcResponse(OperationResponse response)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnWebRpcResponse(response);
		}
	}
}
internal class ErrorInfoCallbacksContainer : List<IErrorInfoCallback>, IErrorInfoCallback
{
	private LoadBalancingClient client;

	public ErrorInfoCallbacksContainer(LoadBalancingClient client)
	{
		this.client = client;
	}

	public void OnErrorInfo(ErrorInfo errorInfo)
	{
		client.UpdateCallbackTargets();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnErrorInfo(errorInfo);
		}
	}
}
public class ErrorInfo
{
	public readonly string Info;

	public ErrorInfo(EventData eventData)
	{
		Info = eventData[218] as string;
	}

	public override string ToString()
	{
		return $"ErrorInfo: {Info}";
	}
}
public class LoadBalancingPeer : PhotonPeer
{
	private readonly Pool<ParameterDictionary> paramDictionaryPool = new Pool<ParameterDictionary>(() => new ParameterDictionary(), delegate(ParameterDictionary x)
	{
		x.Clear();
	}, 1);

	public EnterRoomParams enterRoomParams;

	[Obsolete("Use RegionHandler.PingImplementation directly.")]
	protected internal static Type PingImplementation
	{
		get
		{
			return RegionHandler.PingImplementation;
		}
		set
		{
			RegionHandler.PingImplementation = value;
		}
	}

	public LoadBalancingPeer(ConnectionProtocol protocolType)
		: base(protocolType)
	{
		ConfigUnitySockets();
	}

	public LoadBalancingPeer(IPhotonPeerListener listener, ConnectionProtocol protocolType)
		: this(protocolType)
	{
		base.Listener = listener;
	}

	[Conditional("SUPPORTED_UNITY")]
	private void ConfigUnitySockets()
	{
		Type type = null;
		type = Type.GetType("ExitGames.Client.Photon.SocketWebTcp, PhotonWebSocket", throwOnError: false);
		if (type == null)
		{
			type = Type.GetType("ExitGames.Client.Photon.SocketWebTcp, Assembly-CSharp-firstpass", throwOnError: false);
		}
		if (type == null)
		{
			type = Type.GetType("ExitGames.Client.Photon.SocketWebTcp, Assembly-CSharp", throwOnError: false);
		}
		if (type != null)
		{
			SocketImplementationConfig[ConnectionProtocol.WebSocket] = type;
			SocketImplementationConfig[ConnectionProtocol.WebSocketSecure] = type;
		}
	}

	public virtual bool OpGetRegions(string appId)
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>(1);
		dictionary[224] = appId;
		return SendOperation(220, dictionary, new SendOptions
		{
			Reliability = true,
			Encrypt = true
		});
	}

	public virtual bool OpJoinLobby(TypedLobby lobby = null)
	{
		if ((int)DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinLobby()");
		}
		Dictionary<byte, object> dictionary = null;
		if (lobby != null && !lobby.IsDefault)
		{
			dictionary = new Dictionary<byte, object>();
			dictionary[213] = lobby.Name;
			dictionary[212] = (byte)lobby.Type;
		}
		return SendOperation(229, dictionary, SendOptions.SendReliable);
	}

	public virtual bool OpLeaveLobby()
	{
		if ((int)DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpLeaveLobby()");
		}
		return SendOperation((byte)228, (Dictionary<byte, object>)null, SendOptions.SendReliable);
	}

	private void RoomOptionsToOpParameters(Dictionary<byte, object> op, RoomOptions roomOptions, bool usePropertiesKey = false)
	{
		if (roomOptions == null)
		{
			roomOptions = new RoomOptions();
		}
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable[253] = roomOptions.IsOpen;
		hashtable[254] = roomOptions.IsVisible;
		hashtable[250] = ((roomOptions.CustomRoomPropertiesForLobby == null) ? new string[0] : roomOptions.CustomRoomPropertiesForLobby);
		hashtable.MergeStringKeys(roomOptions.CustomRoomProperties);
		if (roomOptions.MaxPlayers > 0)
		{
			hashtable[byte.MaxValue] = roomOptions.MaxPlayers;
		}
		if (!usePropertiesKey)
		{
			op[248] = hashtable;
		}
		else
		{
			op[251] = hashtable;
		}
		int num = 0;
		if (roomOptions.CleanupCacheOnLeave)
		{
			op[241] = true;
			num |= 2;
		}
		else
		{
			op[241] = false;
			hashtable[249] = false;
		}
		num |= 1;
		op[232] = true;
		if (roomOptions.PlayerTtl > 0 || roomOptions.PlayerTtl == -1)
		{
			op[235] = roomOptions.PlayerTtl;
		}
		if (roomOptions.EmptyRoomTtl > 0)
		{
			op[236] = roomOptions.EmptyRoomTtl;
		}
		if (roomOptions.SuppressRoomEvents)
		{
			num |= 4;
			op[237] = true;
		}
		if (roomOptions.SuppressPlayerInfo)
		{
			num |= 0x40;
		}
		if (roomOptions.Plugins != null)
		{
			op[204] = roomOptions.Plugins;
		}
		if (roomOptions.PublishUserId)
		{
			num |= 8;
			op[239] = true;
		}
		if (roomOptions.DeleteNullProperties)
		{
			num |= 0x10;
		}
		if (roomOptions.BroadcastPropsChangeToAll)
		{
			num |= 0x20;
		}
		op[191] = num;
	}

	public virtual bool OpCreateRoom(EnterRoomParams opParams)
	{
		if ((int)DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpCreateRoom()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (!string.IsNullOrEmpty(opParams.RoomName))
		{
			dictionary[byte.MaxValue] = opParams.RoomName;
		}
		if (opParams.Lobby != null && !opParams.Lobby.IsDefault)
		{
			dictionary[213] = opParams.Lobby.Name;
			dictionary[212] = (byte)opParams.Lobby.Type;
		}
		if (opParams.ExpectedUsers != null && opParams.ExpectedUsers.Length != 0)
		{
			dictionary[238] = opParams.ExpectedUsers;
		}
		if (opParams.OnGameServer)
		{
			if (opParams.PlayerProperties != null && opParams.PlayerProperties.Count > 0)
			{
				dictionary[249] = opParams.PlayerProperties;
			}
			dictionary[250] = true;
			RoomOptionsToOpParameters(dictionary, opParams.RoomOptions);
		}
		return SendOperation(227, dictionary, SendOptions.SendReliable);
	}

	public virtual bool OpJoinRoom(EnterRoomParams opParams)
	{
		if ((int)DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinRoom()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (!string.IsNullOrEmpty(opParams.RoomName))
		{
			dictionary[byte.MaxValue] = opParams.RoomName;
		}
		if (opParams.JoinMode == JoinMode.CreateIfNotExists)
		{
			dictionary[215] = (byte)1;
			if (opParams.Lobby != null && !opParams.Lobby.IsDefault)
			{
				dictionary[213] = opParams.Lobby.Name;
				dictionary[212] = (byte)opParams.Lobby.Type;
			}
		}
		else if (opParams.JoinMode == JoinMode.RejoinOnly)
		{
			dictionary[215] = (byte)3;
		}
		if (opParams.ExpectedUsers != null && opParams.ExpectedUsers.Length != 0)
		{
			dictionary[238] = opParams.ExpectedUsers;
		}
		if (opParams.OnGameServer)
		{
			if (opParams.PlayerProperties != null && opParams.PlayerProperties.Count > 0)
			{
				dictionary[249] = opParams.PlayerProperties;
			}
			dictionary[250] = true;
		}
		if (opParams.OnGameServer || opParams.JoinMode == JoinMode.CreateIfNotExists)
		{
			RoomOptionsToOpParameters(dictionary, opParams.RoomOptions);
		}
		return SendOperation(226, dictionary, SendOptions.SendReliable);
	}

	public virtual bool OpJoinRandomRoom(OpJoinRandomRoomParams opJoinRandomRoomParams)
	{
		if ((int)DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinRandomRoom()");
		}
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable.MergeStringKeys(opJoinRandomRoomParams.ExpectedCustomRoomProperties);
		if (opJoinRandomRoomParams.ExpectedMaxPlayers > 0)
		{
			hashtable[byte.MaxValue] = opJoinRandomRoomParams.ExpectedMaxPlayers;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (hashtable.Count > 0)
		{
			dictionary[248] = hashtable;
		}
		if (opJoinRandomRoomParams.MatchingType != MatchmakingMode.FillRoom)
		{
			dictionary[223] = (byte)opJoinRandomRoomParams.MatchingType;
		}
		if (opJoinRandomRoomParams.TypedLobby != null && !opJoinRandomRoomParams.TypedLobby.IsDefault)
		{
			dictionary[213] = opJoinRandomRoomParams.TypedLobby.Name;
			dictionary[212] = (byte)opJoinRandomRoomParams.TypedLobby.Type;
		}
		if (!string.IsNullOrEmpty(opJoinRandomRoomParams.SqlLobbyFilter))
		{
			dictionary[245] = opJoinRandomRoomParams.SqlLobbyFilter;
		}
		if (opJoinRandomRoomParams.ExpectedUsers != null && opJoinRandomRoomParams.ExpectedUsers.Length != 0)
		{
			dictionary[238] = opJoinRandomRoomParams.ExpectedUsers;
		}
		return SendOperation(225, dictionary, SendOptions.SendReliable);
	}

	public virtual bool OpJoinRandomOrCreateRoom(OpJoinRandomRoomParams opJoinRandomRoomParams, EnterRoomParams createRoomParams)
	{
		if ((int)DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinRandomOrCreateRoom()");
		}
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable.MergeStringKeys(opJoinRandomRoomParams.ExpectedCustomRoomProperties);
		if (opJoinRandomRoomParams.ExpectedMaxPlayers > 0)
		{
			hashtable[byte.MaxValue] = opJoinRandomRoomParams.ExpectedMaxPlayers;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (hashtable.Count > 0)
		{
			dictionary[248] = hashtable;
		}
		if (opJoinRandomRoomParams.MatchingType != MatchmakingMode.FillRoom)
		{
			dictionary[223] = (byte)opJoinRandomRoomParams.MatchingType;
		}
		if (opJoinRandomRoomParams.TypedLobby != null && !opJoinRandomRoomParams.TypedLobby.IsDefault)
		{
			dictionary[213] = opJoinRandomRoomParams.TypedLobby.Name;
			dictionary[212] = (byte)opJoinRandomRoomParams.TypedLobby.Type;
		}
		if (!string.IsNullOrEmpty(opJoinRandomRoomParams.SqlLobbyFilter))
		{
			dictionary[245] = opJoinRandomRoomParams.SqlLobbyFilter;
		}
		if (opJoinRandomRoomParams.ExpectedUsers != null && opJoinRandomRoomParams.ExpectedUsers.Length != 0)
		{
			dictionary[238] = opJoinRandomRoomParams.ExpectedUsers;
		}
		dictionary[215] = (byte)1;
		if (createRoomParams != null)
		{
			if (!string.IsNullOrEmpty(createRoomParams.RoomName))
			{
				dictionary[byte.MaxValue] = createRoomParams.RoomName;
			}
			RoomOptionsToOpParameters(dictionary, createRoomParams.RoomOptions, usePropertiesKey: true);
		}
		return SendOperation(225, dictionary, SendOptions.SendReliable);
	}

	public virtual bool OpLeaveRoom(bool becomeInactive, bool sendAuthCookie = false)
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (becomeInactive)
		{
			dictionary[233] = true;
		}
		if (sendAuthCookie)
		{
			dictionary[234] = (byte)2;
		}
		return SendOperation(254, dictionary, SendOptions.SendReliable);
	}

	public virtual bool OpGetGameList(TypedLobby lobby, string queryData)
	{
		if ((int)DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpGetGameList()");
		}
		if (lobby == null)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpGetGameList not sent. Lobby cannot be null.");
			}
			return false;
		}
		if (lobby.Type != LobbyType.SqlLobby)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpGetGameList not sent. LobbyType must be SqlLobby.");
			}
			return false;
		}
		if (lobby.IsDefault)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpGetGameList not sent. LobbyName must be not null and not empty.");
			}
			return false;
		}
		if (string.IsNullOrEmpty(queryData))
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpGetGameList not sent. queryData must be not null and not empty.");
			}
			return false;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[213] = lobby.Name;
		dictionary[212] = (byte)lobby.Type;
		dictionary[245] = queryData;
		return SendOperation(217, dictionary, SendOptions.SendReliable);
	}

	public virtual bool OpFindFriends(string[] friendsToFind, FindFriendsOptions options)
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (friendsToFind != null && friendsToFind.Length != 0)
		{
			dictionary[1] = friendsToFind;
		}
		if (options == null)
		{
			options = new FindFriendsOptions();
		}
		dictionary[2] = options.ToIntFlags();
		return SendOperation(222, dictionary, SendOptions.SendReliable);
	}

	public bool OpSetCustomPropertiesOfActor(int actorNr, ExitGames.Client.Photon.Hashtable actorProperties)
	{
		return OpSetPropertiesOfActor(actorNr, actorProperties.StripToStringKeys());
	}

	protected internal bool OpSetPropertiesOfActor(int actorNr, ExitGames.Client.Photon.Hashtable actorProperties, ExitGames.Client.Photon.Hashtable expectedProperties = null, WebFlags webflags = null)
	{
		if ((int)DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfActor()");
		}
		if (actorNr <= 0 || actorProperties == null || actorProperties.Count == 0)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfActor not sent. ActorNr must be > 0 and actorProperties must be not null nor empty.");
			}
			return false;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary.Add(251, actorProperties);
		dictionary.Add(254, actorNr);
		dictionary.Add(250, true);
		if (expectedProperties != null && expectedProperties.Count != 0)
		{
			dictionary.Add(231, expectedProperties);
		}
		if (webflags != null && webflags.HttpForward)
		{
			dictionary[234] = webflags.WebhookFlags;
		}
		return SendOperation(252, dictionary, SendOptions.SendReliable);
	}

	protected bool OpSetPropertyOfRoom(byte propCode, object value)
	{
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable[propCode] = value;
		return OpSetPropertiesOfRoom(hashtable);
	}

	public bool OpSetCustomPropertiesOfRoom(ExitGames.Client.Photon.Hashtable gameProperties)
	{
		return OpSetPropertiesOfRoom(gameProperties.StripToStringKeys());
	}

	protected internal bool OpSetPropertiesOfRoom(ExitGames.Client.Photon.Hashtable gameProperties, ExitGames.Client.Photon.Hashtable expectedProperties = null, WebFlags webflags = null)
	{
		if ((int)DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfRoom()");
		}
		if (gameProperties == null || gameProperties.Count == 0)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfRoom not sent. gameProperties must be not null nor empty.");
			}
			return false;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary.Add(251, gameProperties);
		dictionary.Add(250, true);
		if (expectedProperties != null && expectedProperties.Count != 0)
		{
			dictionary.Add(231, expectedProperties);
		}
		if (webflags != null && webflags.HttpForward)
		{
			dictionary[234] = webflags.WebhookFlags;
		}
		return SendOperation(252, dictionary, SendOptions.SendReliable);
	}

	public virtual bool OpAuthenticate(string appId, string appVersion, AuthenticationValues authValues, string regionCode, bool getLobbyStatistics)
	{
		if ((int)DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpAuthenticate()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (getLobbyStatistics)
		{
			dictionary[211] = true;
		}
		if (authValues != null && authValues.Token != null)
		{
			dictionary[221] = authValues.Token;
			return SendOperation(230, dictionary, SendOptions.SendReliable);
		}
		dictionary[220] = appVersion;
		dictionary[224] = appId;
		if (!string.IsNullOrEmpty(regionCode))
		{
			dictionary[210] = regionCode;
		}
		if (authValues != null)
		{
			if (!string.IsNullOrEmpty(authValues.UserId))
			{
				dictionary[225] = authValues.UserId;
			}
			if (authValues.AuthType != CustomAuthenticationType.None)
			{
				dictionary[217] = (byte)authValues.AuthType;
				if (!string.IsNullOrEmpty(authValues.AuthGetParameters))
				{
					dictionary[216] = authValues.AuthGetParameters;
				}
				if (authValues.AuthPostData != null)
				{
					dictionary[214] = authValues.AuthPostData;
				}
			}
		}
		return SendOperation(230, dictionary, new SendOptions
		{
			Reliability = true,
			Encrypt = true
		});
	}

	public virtual bool OpAuthenticateOnce(string appId, string appVersion, AuthenticationValues authValues, string regionCode, EncryptionMode encryptionMode, ConnectionProtocol expectedProtocol)
	{
		if ((int)DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpAuthenticateOnce(): authValues = " + authValues?.ToString() + ", region = " + regionCode + ", encryption = " + encryptionMode);
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (authValues != null && authValues.Token != null)
		{
			dictionary[221] = authValues.Token;
			return SendOperation(231, dictionary, SendOptions.SendReliable);
		}
		if (encryptionMode == EncryptionMode.DatagramEncryption && expectedProtocol != ConnectionProtocol.Udp)
		{
			throw new NotSupportedException("Expected protocol set to UDP, due to encryption mode DatagramEncryption.");
		}
		dictionary[195] = (byte)expectedProtocol;
		dictionary[193] = (byte)encryptionMode;
		dictionary[220] = appVersion;
		dictionary[224] = appId;
		if (!string.IsNullOrEmpty(regionCode))
		{
			dictionary[210] = regionCode;
		}
		if (authValues != null)
		{
			if (!string.IsNullOrEmpty(authValues.UserId))
			{
				dictionary[225] = authValues.UserId;
			}
			if (authValues.AuthType != CustomAuthenticationType.None)
			{
				dictionary[217] = (byte)authValues.AuthType;
				if (authValues.Token != null)
				{
					dictionary[221] = authValues.Token;
				}
				else
				{
					if (!string.IsNullOrEmpty(authValues.AuthGetParameters))
					{
						dictionary[216] = authValues.AuthGetParameters;
					}
					if (authValues.AuthPostData != null)
					{
						dictionary[214] = authValues.AuthPostData;
					}
				}
			}
		}
		return SendOperation(231, dictionary, new SendOptions
		{
			Reliability = true,
			Encrypt = true
		});
	}

	public virtual bool OpChangeGroups(byte[] groupsToRemove, byte[] groupsToAdd)
	{
		if ((int)DebugOut >= 5)
		{
			base.Listener.DebugReturn(DebugLevel.ALL, "OpChangeGroups()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (groupsToRemove != null)
		{
			dictionary[239] = groupsToRemove;
		}
		if (groupsToAdd != null)
		{
			dictionary[238] = groupsToAdd;
		}
		return SendOperation(248, dictionary, SendOptions.SendReliable);
	}

	public virtual bool OpRaiseEvent(byte eventCode, object customEventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
	{
		ParameterDictionary parameterDictionary = paramDictionaryPool.Acquire();
		try
		{
			if (raiseEventOptions != null)
			{
				if (raiseEventOptions.CachingOption != EventCaching.DoNotCache)
				{
					parameterDictionary.Add(247, (byte)raiseEventOptions.CachingOption);
				}
				switch (raiseEventOptions.CachingOption)
				{
				case EventCaching.SliceSetIndex:
				case EventCaching.SlicePurgeIndex:
				case EventCaching.SlicePurgeUpToIndex:
					return SendOperation(253, parameterDictionary, sendOptions);
				case EventCaching.RemoveFromRoomCacheForActorsLeft:
				case EventCaching.SliceIncreaseIndex:
					return SendOperation(253, parameterDictionary, sendOptions);
				case EventCaching.RemoveFromRoomCache:
					if (raiseEventOptions.TargetActors != null)
					{
						parameterDictionary.Add(252, raiseEventOptions.TargetActors);
					}
					break;
				default:
					if (raiseEventOptions.TargetActors != null)
					{
						parameterDictionary.Add(252, raiseEventOptions.TargetActors);
					}
					else if (raiseEventOptions.InterestGroup != 0)
					{
						parameterDictionary.Add(240, raiseEventOptions.InterestGroup);
					}
					else if (raiseEventOptions.Receivers != ReceiverGroup.Others)
					{
						parameterDictionary.Add(246, (byte)raiseEventOptions.Receivers);
					}
					if (raiseEventOptions.Flags.HttpForward)
					{
						parameterDictionary.Add(234, raiseEventOptions.Flags.WebhookFlags);
					}
					break;
				}
			}
			parameterDictionary.Add(244, eventCode);
			if (customEventContent != null)
			{
				parameterDictionary.Add(245, customEventContent);
			}
			return SendOperation(253, parameterDictionary, sendOptions);
		}
		finally
		{
			paramDictionaryPool.Release(parameterDictionary);
		}
	}

	public virtual bool OpSettings(bool receiveLobbyStats)
	{
		if ((int)DebugOut >= 5)
		{
			base.Listener.DebugReturn(DebugLevel.ALL, "OpSettings()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (receiveLobbyStats)
		{
			dictionary[0] = receiveLobbyStats;
		}
		if (dictionary.Count == 0)
		{
			return true;
		}
		return SendOperation(218, dictionary, SendOptions.SendReliable);
	}
}
internal enum RoomOptionBit
{
	CheckUserOnJoin = 1,
	DeleteCacheOnLeave = 2,
	SuppressRoomEvents = 4,
	PublishUserId = 8,
	DeleteNullProps = 0x10,
	BroadcastPropsChangeToAll = 0x20,
	SuppressPlayerInfo = 0x40
}
public class FindFriendsOptions
{
	public bool CreatedOnGs;

	public bool Visible = true;

	public bool Open = true;

	internal int ToIntFlags()
	{
		int num = 0;
		if (CreatedOnGs)
		{
			num |= 1;
		}
		if (Visible)
		{
			num |= 2;
		}
		if (Open)
		{
			num |= 4;
		}
		return num;
	}
}
public class OpJoinRandomRoomParams
{
	public ExitGames.Client.Photon.Hashtable ExpectedCustomRoomProperties;

	public byte ExpectedMaxPlayers;

	public MatchmakingMode MatchingType;

	public TypedLobby TypedLobby;

	public string SqlLobbyFilter;

	public string[] ExpectedUsers;
}
public class EnterRoomParams
{
	public string RoomName;

	public RoomOptions RoomOptions;

	public TypedLobby Lobby;

	public ExitGames.Client.Photon.Hashtable PlayerProperties;

	protected internal bool OnGameServer = true;

	protected internal JoinMode JoinMode;

	public string[] ExpectedUsers;
}
public class ErrorCode
{
	public const int Ok = 0;

	public const int OperationNotAllowedInCurrentState = -3;

	[Obsolete("Use InvalidOperation.")]
	public const int InvalidOperationCode = -2;

	public const int InvalidOperation = -2;

	public const int InternalServerError = -1;

	public const int InvalidAuthentication = 32767;

	public const int GameIdAlreadyExists = 32766;

	public const int GameFull = 32765;

	public const int GameClosed = 32764;

	[Obsolete("No longer used, cause random matchmaking is no longer a process.")]
	public const int AlreadyMatched = 32763;

	public const int ServerFull = 32762;

	public const int UserBlocked = 32761;

	public const int NoRandomMatchFound = 32760;

	public const int GameDoesNotExist = 32758;

	public const int MaxCcuReached = 32757;

	public const int InvalidRegion = 32756;

	public const int CustomAuthenticationFailed = 32755;

	public const int AuthenticationTicketExpired = 32753;

	public const int PluginReportedError = 32752;

	public const int PluginMismatch = 32751;

	public const int JoinFailedPeerAlreadyJoined = 32750;

	public const int JoinFailedFoundInactiveJoiner = 32749;

	public const int JoinFailedWithRejoinerNotFound = 32748;

	public const int JoinFailedFoundExcludedUserId = 32747;

	public const int JoinFailedFoundActiveJoiner = 32746;

	public const int HttpLimitReached = 32745;

	public const int ExternalHttpCallFailed = 32744;

	public const int OperationLimitReached = 32743;

	public const int SlotError = 32742;

	public const int InvalidEncryptionParameters = 32741;
}
public class ActorProperties
{
	public const byte PlayerName = byte.MaxValue;

	public const byte IsInactive = 254;

	public const byte UserId = 253;
}
public class GamePropertyKey
{
	public const byte MaxPlayers = byte.MaxValue;

	public const byte IsVisible = 254;

	public const byte IsOpen = 253;

	public const byte PlayerCount = 252;

	public const byte Removed = 251;

	public const byte PropsListedInLobby = 250;

	public const byte CleanupCacheOnLeave = 249;

	public const byte MasterClientId = 248;

	public const byte ExpectedUsers = 247;

	public const byte PlayerTtl = 246;

	public const byte EmptyRoomTtl = 245;
}
public class EventCode
{
	public const byte GameList = 230;

	public const byte GameListUpdate = 229;

	public const byte QueueState = 228;

	public const byte Match = 227;

	public const byte AppStats = 226;

	public const byte LobbyStats = 224;

	[Obsolete("TCP routing was removed after becoming obsolete.")]
	public const byte AzureNodeInfo = 210;

	public const byte Join = byte.MaxValue;

	public const byte Leave = 254;

	public const byte PropertiesChanged = 253;

	[Obsolete("Use PropertiesChanged now.")]
	public const byte SetProperties = 253;

	public const byte ErrorInfo = 251;

	public const byte CacheSliceChanged = 250;

	public const byte AuthEvent = 223;
}
public class ParameterCode
{
	public const byte SuppressRoomEvents = 237;

	public const byte EmptyRoomTTL = 236;

	public const byte PlayerTTL = 235;

	public const byte EventForward = 234;

	[Obsolete("Use: IsInactive")]
	public const byte IsComingBack = 233;

	public const byte IsInactive = 233;

	public const byte CheckUserOnJoin = 232;

	public const byte ExpectedValues = 231;

	public const byte Address = 230;

	public const byte PeerCount = 229;

	public const byte GameCount = 228;

	public const byte MasterPeerCount = 227;

	public const byte UserId = 225;

	public const byte ApplicationId = 224;

	public const byte Position = 223;

	public const byte MatchMakingType = 223;

	public const byte GameList = 222;

	public const byte Token = 221;

	public const byte AppVersion = 220;

	[Obsolete("TCP routing was removed after becoming obsolete.")]
	public const byte AzureNodeInfo = 210;

	[Obsolete("TCP routing was removed after becoming obsolete.")]
	public const byte AzureLocalNodeId = 209;

	[Obsolete("TCP routing was removed after becoming obsolete.")]
	public const byte AzureMasterNodeId = 208;

	public const byte RoomName = byte.MaxValue;

	public const byte Broadcast = 250;

	public const byte ActorList = 252;

	public const byte ActorNr = 254;

	public const byte PlayerProperties = 249;

	public const byte CustomEventContent = 245;

	public const byte Data = 245;

	public const byte Code = 244;

	public const byte GameProperties = 248;

	public const byte Properties = 251;

	public const byte TargetActorNr = 253;

	public const byte ReceiverGroup = 246;

	public const byte Cache = 247;

	public const byte CleanupCacheOnLeave = 241;

	public const byte Group = 240;

	public const byte Remove = 239;

	public const byte PublishUserId = 239;

	public const byte Add = 238;

	public const byte Info = 218;

	public const byte ClientAuthenticationType = 217;

	public const byte ClientAuthenticationParams = 216;

	public const byte JoinMode = 215;

	public const byte ClientAuthenticationData = 214;

	public const byte MasterClientId = 203;

	public const byte FindFriendsRequestList = 1;

	public const byte FindFriendsOptions = 2;

	public const byte FindFriendsResponseOnlineList = 1;

	public const byte FindFriendsResponseRoomIdList = 2;

	public const byte LobbyName = 213;

	public const byte LobbyType = 212;

	public const byte LobbyStats = 211;

	public const byte Region = 210;

	public const byte UriPath = 209;

	public const byte WebRpcParameters = 208;

	public const byte WebRpcReturnCode = 207;

	public const byte WebRpcReturnMessage = 206;

	public const byte CacheSliceIndex = 205;

	public const byte Plugins = 204;

	public const byte NickName = 202;

	public const byte PluginName = 201;

	public const byte PluginVersion = 200;

	public const byte Cluster = 196;

	public const byte ExpectedProtocol = 195;

	public const byte CustomInitData = 194;

	public const byte EncryptionMode = 193;

	public const byte EncryptionData = 192;

	public const byte RoomOptionFlags = 191;
}
public class OperationCode
{
	[Obsolete("Exchanging encrpytion keys is done internally in the lib now. Don't expect this operation-result.")]
	public const byte ExchangeKeysForEncryption = 250;

	[Obsolete]
	public const byte Join = byte.MaxValue;

	public const byte AuthenticateOnce = 231;

	public const byte Authenticate = 230;

	public const byte JoinLobby = 229;

	public const byte LeaveLobby = 228;

	public const byte CreateGame = 227;

	public const byte JoinGame = 226;

	public const byte JoinRandomGame = 225;

	public const byte Leave = 254;

	public const byte RaiseEvent = 253;

	public const byte SetProperties = 252;

	public const byte GetProperties = 251;

	public const byte ChangeGroups = 248;

	public const byte FindFriends = 222;

	public const byte FindFriendsUpdate = 223;

	public const byte GetLobbyStats = 221;

	public const byte GetRegions = 220;

	public const byte WebRpc = 219;

	public const byte ServerSettings = 218;

	public const byte GetGameList = 217;
}
public enum JoinMode : byte
{
	Default,
	CreateIfNotExists,
	JoinOrRejoin,
	RejoinOnly
}
public enum MatchmakingMode : byte
{
	FillRoom,
	SerialMatching,
	RandomMatching
}
public enum ReceiverGroup : byte
{
	Others,
	All,
	MasterClient
}
public enum EventCaching : byte
{
	DoNotCache = 0,
	[Obsolete]
	MergeCache = 1,
	[Obsolete]
	ReplaceCache = 2,
	[Obsolete]
	RemoveCache = 3,
	AddToRoomCache = 4,
	AddToRoomCacheGlobal = 5,
	RemoveFromRoomCache = 6,
	RemoveFromRoomCacheForActorsLeft = 7,
	SliceIncreaseIndex = 10,
	SliceSetIndex = 11,
	SlicePurgeIndex = 12,
	SlicePurgeUpToIndex = 13
}
[Flags]
public enum PropertyTypeFlag : byte
{
	None = 0,
	Game = 1,
	Actor = 2,
	GameAndActor = 3
}
public class RoomOptions
{
	private bool isVisible = true;

	private bool isOpen = true;

	public byte MaxPlayers;

	public int PlayerTtl;

	public int EmptyRoomTtl;

	private bool cleanupCacheOnLeave = true;

	public ExitGames.Client.Photon.Hashtable CustomRoomProperties;

	public string[] CustomRoomPropertiesForLobby = new string[0];

	public string[] Plugins;

	private bool broadcastPropsChangeToAll = true;

	public bool IsVisible
	{
		get
		{
			return isVisible;
		}
		set
		{
			isVisible = value;
		}
	}

	public bool IsOpen
	{
		get
		{
			return isOpen;
		}
		set
		{
			isOpen = value;
		}
	}

	public bool CleanupCacheOnLeave
	{
		get
		{
			return cleanupCacheOnLeave;
		}
		set
		{
			cleanupCacheOnLeave = value;
		}
	}

	public bool SuppressRoomEvents { get; set; }

	public bool SuppressPlayerInfo { get; set; }

	public bool PublishUserId { get; set; }

	public bool DeleteNullProperties { get; set; }

	public bool BroadcastPropsChangeToAll
	{
		get
		{
			return broadcastPropsChangeToAll;
		}
		set
		{
			broadcastPropsChangeToAll = value;
		}
	}
}
public class RaiseEventOptions
{
	public static readonly RaiseEventOptions Default = new RaiseEventOptions();

	public EventCaching CachingOption;

	public byte InterestGroup;

	public int[] TargetActors;

	public ReceiverGroup Receivers;

	[Obsolete("Not used where SendOptions are a parameter too. Use SendOptions.Channel instead.")]
	public byte SequenceChannel;

	public WebFlags Flags = WebFlags.Default;
}
public enum LobbyType : byte
{
	Default = 0,
	SqlLobby = 2,
	AsyncRandomLobby = 3
}
public class TypedLobby
{
	public string Name;

	public LobbyType Type;

	public static readonly TypedLobby Default = new TypedLobby();

	public bool IsDefault => string.IsNullOrEmpty(Name);

	internal TypedLobby()
	{
	}

	public TypedLobby(string name, LobbyType type)
	{
		Name = name;
		Type = type;
	}

	public override string ToString()
	{
		return $"lobby '{Name}'[{Type}]";
	}
}
public class TypedLobbyInfo : TypedLobby
{
	public int PlayerCount;

	public int RoomCount;

	public override string ToString()
	{
		return $"TypedLobbyInfo '{Name}'[{Type}] rooms: {RoomCount} players: {PlayerCount}";
	}
}
public enum AuthModeOption
{
	Auth,
	AuthOnce,
	AuthOnceWss
}
public enum CustomAuthenticationType : byte
{
	Custom = 0,
	Steam = 1,
	Facebook = 2,
	Oculus = 3,
	PlayStation4 = 4,
	[Obsolete("Use PlayStation4 or PlayStation5 as needed")]
	PlayStation = 4,
	Xbox = 5,
	Viveport = 10,
	NintendoSwitch = 11,
	PlayStation5 = 12,
	[Obsolete("Use PlayStation4 or PlayStation5 as needed")]
	Playstation5 = 12,
	Epic = 13,
	FacebookGaming = 15,
	None = byte.MaxValue
}
public class AuthenticationValues
{
	private CustomAuthenticationType authType = CustomAuthenticationType.None;

	public CustomAuthenticationType AuthType
	{
		get
		{
			return authType;
		}
		set
		{
			authType = value;
		}
	}

	public string AuthGetParameters { get; set; }

	public object AuthPostData { get; private set; }

	public object Token { get; protected internal set; }

	public string UserId { get; set; }

	public AuthenticationValues()
	{
	}

	public AuthenticationValues(string userId)
	{
		UserId = userId;
	}

	public virtual void SetAuthPostData(string stringData)
	{
		AuthPostData = (string.IsNullOrEmpty(stringData) ? null : stringData);
	}

	public virtual void SetAuthPostData(byte[] byteData)
	{
		AuthPostData = byteData;
	}

	public virtual void SetAuthPostData(Dictionary<string, object> dictData)
	{
		AuthPostData = dictData;
	}

	public virtual void AddAuthParameter(string key, string value)
	{
		string text = (string.IsNullOrEmpty(AuthGetParameters) ? "" : "&");
		AuthGetParameters = $"{AuthGetParameters}{text}{Uri.EscapeDataString(key)}={Uri.EscapeDataString(value)}";
	}

	public override string ToString()
	{
		return string.Format("AuthenticationValues = AuthType: {0} UserId: {1}{2}{3}{4}", AuthType, UserId, string.IsNullOrEmpty(AuthGetParameters) ? " GetParameters: yes" : "", (AuthPostData == null) ? "" : " PostData: yes", (Token == null) ? "" : " Token: yes");
	}

	public AuthenticationValues CopyTo(AuthenticationValues copy)
	{
		copy.AuthType = AuthType;
		copy.AuthGetParameters = AuthGetParameters;
		copy.AuthPostData = AuthPostData;
		copy.UserId = UserId;
		return copy;
	}
}
public abstract class PhotonPing : IDisposable
{
	public string DebugString = "";

	public bool Successful;

	protected internal bool GotResult;

	protected internal int PingLength = 13;

	protected internal byte[] PingBytes = new byte[13]
	{
		125, 125, 125, 125, 125, 125, 125, 125, 125, 125,
		125, 125, 0
	};

	protected internal byte PingId;

	private static readonly System.Random RandomIdProvider = new System.Random();

	public virtual bool StartPing(string ip)
	{
		throw new NotImplementedException();
	}

	public virtual bool Done()
	{
		throw new NotImplementedException();
	}

	public virtual void Dispose()
	{
		throw new NotImplementedException();
	}

	protected internal void Init()
	{
		GotResult = false;
		Successful = false;
		PingId = (byte)RandomIdProvider.Next(255);
	}
}
public class PingMono : PhotonPing
{
	private Socket sock;

	public override bool StartPing(string ip)
	{
		Init();
		try
		{
			if (sock == null)
			{
				if (ip.Contains("."))
				{
					sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				}
				else
				{
					sock = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
				}
				sock.ReceiveTimeout = 5000;
				int port = ((RegionHandler.PortToPingOverride != 0) ? RegionHandler.PortToPingOverride : 5055);
				sock.Connect(ip, port);
			}
			PingBytes[PingBytes.Length - 1] = PingId;
			sock.Send(PingBytes);
			PingBytes[PingBytes.Length - 1] = (byte)(PingId + 1);
		}
		catch (Exception value)
		{
			sock = null;
			Console.WriteLine(value);
		}
		return false;
	}

	public override bool Done()
	{
		if (GotResult || sock == null)
		{
			return true;
		}
		int num = 0;
		try
		{
			if (!sock.Poll(0, SelectMode.SelectRead))
			{
				return false;
			}
			num = sock.Receive(PingBytes, SocketFlags.None);
		}
		catch (Exception ex)
		{
			if (sock != null)
			{
				sock.Close();
				sock = null;
			}
			DebugString = DebugString + " Exception of socket! " + ex.GetType()?.ToString() + " ";
			return true;
		}
		bool flag = PingBytes[PingBytes.Length - 1] == PingId && num == PingLength;
		if (!flag)
		{
			DebugString += " ReplyMatch is false! ";
		}
		Successful = flag;
		GotResult = true;
		return true;
	}

	public override void Dispose()
	{
		try
		{
			sock.Close();
		}
		catch
		{
		}
		sock = null;
	}
}
public class Player
{
	private int actorNumber = -1;

	public readonly bool IsLocal;

	private string nickName = string.Empty;

	private bool isDefaultGorillaNameSet;

	private string defaultName = "gorilla????";

	public object TagObject;

	protected internal Room RoomReference { get; set; }

	public int ActorNumber => actorNumber;

	public bool HasRejoined { get; internal set; }

	public string NickName
	{
		get
		{
			return nickName;
		}
		set
		{
			if (string.IsNullOrEmpty(nickName) || !nickName.Equals(value))
			{
				nickName = value;
				if (IsLocal)
				{
					SetPlayerNameProperty();
				}
			}
		}
	}

	public string DefaultName
	{
		get
		{
			if (Application.isPlaying && !isDefaultGorillaNameSet)
			{
				isDefaultGorillaNameSet = true;
				defaultName = "gorilla" + UnityEngine.Random.Range(0, 9999).ToString().PadLeft(4, '0');
			}
			return defaultName;
		}
	}

	public string UserId { get; internal set; }

	public bool IsMasterClient
	{
		get
		{
			if (RoomReference == null)
			{
				return false;
			}
			return ActorNumber == RoomReference.MasterClientId;
		}
	}

	public bool IsInactive { get; protected internal set; }

	public ExitGames.Client.Photon.Hashtable CustomProperties { get; set; }

	protected internal Player(string nickName, int actorNumber, bool isLocal)
		: this(nickName, actorNumber, isLocal, null)
	{
	}

	protected internal Player(string nickName, int actorNumber, bool isLocal, ExitGames.Client.Photon.Hashtable playerProperties)
	{
		IsLocal = isLocal;
		this.actorNumber = actorNumber;
		NickName = nickName;
		CustomProperties = new ExitGames.Client.Photon.Hashtable();
		InternalCacheProperties(playerProperties);
	}

	public Player Get(int id)
	{
		if (RoomReference == null)
		{
			return null;
		}
		return RoomReference.GetPlayer(id);
	}

	public Player GetNext()
	{
		return GetNextFor(ActorNumber);
	}

	public Player GetNextFor(Player currentPlayer)
	{
		if (currentPlayer == null)
		{
			return null;
		}
		return GetNextFor(currentPlayer.ActorNumber);
	}

	public Player GetNextFor(int currentPlayerId)
	{
		if (RoomReference == null || RoomReference.Players == null || RoomReference.Players.Count < 2)
		{
			return null;
		}
		Dictionary<int, Player> players = RoomReference.Players;
		int num = int.MaxValue;
		int num2 = currentPlayerId;
		foreach (int key in players.Keys)
		{
			if (key < num2)
			{
				num2 = key;
			}
			else if (key > currentPlayerId && key < num)
			{
				num = key;
			}
		}
		if (num == int.MaxValue)
		{
			return players[num2];
		}
		return players[num];
	}

	protected internal virtual void InternalCacheProperties(ExitGames.Client.Photon.Hashtable properties)
	{
		if (properties == null || properties.Count == 0 || CustomProperties.Equals(properties))
		{
			return;
		}
		if (properties.ContainsKey(byte.MaxValue) && properties[byte.MaxValue] is string text)
		{
			if (IsLocal)
			{
				if (!text.Equals(nickName))
				{
					SetPlayerNameProperty();
				}
			}
			else
			{
				NickName = text;
			}
		}
		if (properties.ContainsKey(253))
		{
			UserId = (string)properties[253];
		}
		if (properties.ContainsKey(254))
		{
			IsInactive = (bool)properties[254];
		}
		CustomProperties.MergeStringKeys(properties);
		CustomProperties.StripKeysWithNullValues();
	}

	public override string ToString()
	{
		return $"#{ActorNumber:00} '{NickName}'";
	}

	public string ToStringFull()
	{
		return string.Format("#{0:00} '{1}'{2} {3}", ActorNumber, NickName, IsInactive ? " (inactive)" : "", CustomProperties.ToStringFull());
	}

	public override bool Equals(object p)
	{
		if (p is Player player)
		{
			return GetHashCode() == player.GetHashCode();
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ActorNumber;
	}

	protected internal void ChangeLocalID(int newID)
	{
		if (IsLocal)
		{
			actorNumber = newID;
		}
	}

	public bool SetCustomProperties(ExitGames.Client.Photon.Hashtable propertiesToSet, ExitGames.Client.Photon.Hashtable expectedValues = null, WebFlags webFlags = null)
	{
		if (propertiesToSet == null || propertiesToSet.Count == 0)
		{
			return false;
		}
		ExitGames.Client.Photon.Hashtable hashtable = propertiesToSet.StripToStringKeys();
		if (RoomReference != null)
		{
			if (RoomReference.IsOffline)
			{
				if (hashtable.Count == 0)
				{
					return false;
				}
				CustomProperties.Merge(hashtable);
				CustomProperties.StripKeysWithNullValues();
				RoomReference.LoadBalancingClient.InRoomCallbackTargets.OnPlayerPropertiesUpdate(this, hashtable);
				return true;
			}
			ExitGames.Client.Photon.Hashtable expectedProperties = expectedValues.StripToStringKeys();
			return RoomReference.LoadBalancingClient.OpSetPropertiesOfActor(actorNumber, hashtable, expectedProperties, webFlags);
		}
		if (IsLocal)
		{
			if (hashtable.Count == 0)
			{
				return false;
			}
			if (expectedValues == null && webFlags == null)
			{
				CustomProperties.Merge(hashtable);
				CustomProperties.StripKeysWithNullValues();
				return true;
			}
		}
		return false;
	}

	private bool SetPlayerNameProperty()
	{
		if (RoomReference != null && !RoomReference.IsOffline)
		{
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			hashtable[byte.MaxValue] = nickName;
			return RoomReference.LoadBalancingClient.OpSetPropertiesOfActor(ActorNumber, hashtable);
		}
		return false;
	}
}
public class Region
{
	public string Code { get; private set; }

	public string Cluster { get; private set; }

	public string HostAndPort { get; protected internal set; }

	public int Ping { get; set; }

	public bool WasPinged => Ping != int.MaxValue;

	public Region(string code, string address)
	{
		SetCodeAndCluster(code);
		HostAndPort = address;
		Ping = int.MaxValue;
	}

	public Region(string code, int ping)
	{
		SetCodeAndCluster(code);
		Ping = ping;
	}

	private void SetCodeAndCluster(string codeAsString)
	{
		if (codeAsString == null)
		{
			Code = "";
			Cluster = "";
			return;
		}
		codeAsString = codeAsString.ToLower();
		int num = codeAsString.IndexOf('/');
		Code = ((num <= 0) ? codeAsString : codeAsString.Substring(0, num));
		Cluster = ((num <= 0) ? "" : codeAsString.Substring(num + 1, codeAsString.Length - num - 1));
	}

	public override string ToString()
	{
		return ToString();
	}

	public string ToString(bool compact = false)
	{
		string text = Code;
		if (!string.IsNullOrEmpty(Cluster))
		{
			text = text + "/" + Cluster;
		}
		if (compact)
		{
			return $"{text}:{Ping}";
		}
		return string.Format("{0}[{2}]: {1}ms", text, Ping, HostAndPort);
	}
}
public class RegionHandler
{
	public static Type PingImplementation;

	private string availableRegionCodes;

	private Region bestRegionCache;

	private List<RegionPinger> pingerList = new List<RegionPinger>();

	private Action<RegionHandler> onCompleteCall;

	private int previousPing;

	private string previousSummaryProvided;

	protected internal static ushort PortToPingOverride;

	public List<Region> EnabledRegions { get; protected internal set; }

	public Region BestRegion
	{
		get
		{
			if (EnabledRegions == null)
			{
				return null;
			}
			if (bestRegionCache != null)
			{
				return bestRegionCache;
			}
			EnabledRegions.Sort((Region a, Region b) => a.Ping.CompareTo(b.Ping));
			bestRegionCache = EnabledRegions[0];
			return bestRegionCache;
		}
	}

	public string SummaryToCache
	{
		get
		{
			if (BestRegion != null)
			{
				return BestRegion.Code + ";" + BestRegion.Ping + ";" + availableRegionCodes;
			}
			return availableRegionCodes;
		}
	}

	public bool IsPinging { get; private set; }

	public string GetResults()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Region Pinging Result: {0}\n", BestRegion.ToString());
		foreach (RegionPinger pinger in pingerList)
		{
			stringBuilder.AppendFormat(pinger.GetResults() + "\n");
		}
		stringBuilder.AppendFormat("Previous summary: {0}", previousSummaryProvided);
		return stringBuilder.ToString();
	}

	public void SetRegions(OperationResponse opGetRegions)
	{
		if (opGetRegions.OperationCode != 220 || opGetRegions.ReturnCode != 0)
		{
			return;
		}
		string[] array = opGetRegions[210] as string[];
		string[] array2 = opGetRegions[230] as string[];
		if (array == null || array2 == null || array.Length != array2.Length)
		{
			return;
		}
		bestRegionCache = null;
		EnabledRegions = new List<Region>(array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			string address = array2[i];
			if (PortToPingOverride != 0)
			{
				address = LoadBalancingClient.ReplacePortWithAlternative(array2[i], PortToPingOverride);
			}
			Region region = new Region(array[i], address);
			if (!string.IsNullOrEmpty(region.Code))
			{
				EnabledRegions.Add(region);
			}
		}
		Array.Sort(array);
		availableRegionCodes = string.Join(",", array);
	}

	public RegionHandler(ushort masterServerPortOverride = 0)
	{
		PortToPingOverride = masterServerPortOverride;
	}

	public bool PingMinimumOfRegions(Action<RegionHandler> onCompleteCallback, string previousSummary)
	{
		if (EnabledRegions == null || EnabledRegions.Count == 0)
		{
			return false;
		}
		if (IsPinging)
		{
			return false;
		}
		IsPinging = true;
		onCompleteCall = onCompleteCallback;
		previousSummaryProvided = previousSummary;
		if (string.IsNullOrEmpty(previousSummary))
		{
			return PingEnabledRegions();
		}
		string[] array = previousSummary.Split(';');
		if (array.Length < 3)
		{
			return PingEnabledRegions();
		}
		if (!int.TryParse(array[1], out var result))
		{
			return PingEnabledRegions();
		}
		string prevBestRegionCode = array[0];
		string value = array[2];
		if (string.IsNullOrEmpty(prevBestRegionCode))
		{
			return PingEnabledRegions();
		}
		if (string.IsNullOrEmpty(value))
		{
			return PingEnabledRegions();
		}
		if (!availableRegionCodes.Equals(value) || !availableRegionCodes.Contains(prevBestRegionCode))
		{
			return PingEnabledRegions();
		}
		if (result >= RegionPinger.PingWhenFailed)
		{
			return PingEnabledRegions();
		}
		previousPing = result;
		RegionPinger regionPinger = new RegionPinger(EnabledRegions.Find((Region r) => r.Code.Equals(prevBestRegionCode)), OnPreferredRegionPinged);
		lock (pingerList)
		{
			pingerList.Add(regionPinger);
		}
		regionPinger.Start();
		return true;
	}

	private void OnPreferredRegionPinged(Region preferredRegion)
	{
		if ((float)preferredRegion.Ping > (float)previousPing * 1.5f)
		{
			PingEnabledRegions();
			return;
		}
		IsPinging = false;
		onCompleteCall(this);
	}

	private bool PingEnabledRegions()
	{
		if (EnabledRegions == null || EnabledRegions.Count == 0)
		{
			return false;
		}
		lock (pingerList)
		{
			pingerList.Clear();
			foreach (Region enabledRegion in EnabledRegions)
			{
				RegionPinger regionPinger = new RegionPinger(enabledRegion, OnRegionDone);
				pingerList.Add(regionPinger);
				regionPinger.Start();
			}
		}
		return true;
	}

	private void OnRegionDone(Region region)
	{
		lock (pingerList)
		{
			if (!IsPinging)
			{
				return;
			}
			bestRegionCache = null;
			foreach (RegionPinger pinger in pingerList)
			{
				if (!pinger.Done)
				{
					return;
				}
			}
			IsPinging = false;
		}
		onCompleteCall(this);
	}
}
public class RegionPinger
{
	public static int Attempts = 5;

	public static bool IgnoreInitialAttempt = true;

	public static int MaxMilliseconsPerPing = 800;

	public static int PingWhenFailed = Attempts * MaxMilliseconsPerPing;

	private Region region;

	private string regionAddress;

	public int CurrentAttempt;

	private Action<Region> onDoneCall;

	private PhotonPing ping;

	private List<int> rttResults;

	public bool Done { get; private set; }

	public RegionPinger(Region region, Action<Region> onDoneCallback)
	{
		this.region = region;
		this.region.Ping = PingWhenFailed;
		Done = false;
		onDoneCall = onDoneCallback;
	}

	private PhotonPing GetPingImplementation()
	{
		PhotonPing photonPing = null;
		if (RegionHandler.PingImplementation == null || RegionHandler.PingImplementation == typeof(PingMono))
		{
			photonPing = new PingMono();
		}
		if (photonPing == null && RegionHandler.PingImplementation != null)
		{
			photonPing = (PhotonPing)Activator.CreateInstance(RegionHandler.PingImplementation);
		}
		return photonPing;
	}

	public bool Start()
	{
		string text = region.HostAndPort;
		int num = text.LastIndexOf(':');
		if (num > 1)
		{
			text = text.Substring(0, num);
		}
		regionAddress = ResolveHost(text);
		ping = GetPingImplementation();
		Done = false;
		CurrentAttempt = 0;
		rttResults = new List<int>(Attempts);
		bool flag = false;
		try
		{
			flag = ThreadPool.QueueUserWorkItem(RegionPingPooled);
		}
		catch
		{
			flag = false;
		}
		if (!flag)
		{
			SupportClass.StartBackgroundCalls(RegionPingThreaded, 0, "RegionPing_" + region.Code + "_" + region.Cluster);
		}
		return true;
	}

	protected internal void RegionPingPooled(object context)
	{
		RegionPingThreaded();
	}

	protected internal bool RegionPingThreaded()
	{
		region.Ping = PingWhenFailed;
		float num = 0f;
		int num2 = 0;
		Stopwatch stopwatch = new Stopwatch();
		for (CurrentAttempt = 0; CurrentAttempt < Attempts; CurrentAttempt++)
		{
			bool flag = false;
			stopwatch.Reset();
			stopwatch.Start();
			try
			{
				ping.StartPing(regionAddress);
			}
			catch (Exception)
			{
				break;
			}
			while (!ping.Done())
			{
				if (stopwatch.ElapsedMilliseconds >= MaxMilliseconsPerPing)
				{
					flag = true;
					break;
				}
				Thread.Sleep(0);
			}
			stopwatch.Stop();
			int num3 = (int)stopwatch.ElapsedMilliseconds;
			rttResults.Add(num3);
			if ((!IgnoreInitialAttempt || CurrentAttempt != 0) && ping.Successful && !flag)
			{
				num += (float)num3;
				num2++;
				region.Ping = (int)(num / (float)num2);
			}
			Thread.Sleep(10);
		}
		Done = true;
		ping.Dispose();
		onDoneCall(region);
		return false;
	}

	protected internal IEnumerator RegionPingCoroutine()
	{
		region.Ping = PingWhenFailed;
		float rttSum = 0f;
		int replyCount = 0;
		Stopwatch sw = new Stopwatch();
		for (CurrentAttempt = 0; CurrentAttempt < Attempts; CurrentAttempt++)
		{
			bool overtime = false;
			sw.Reset();
			sw.Start();
			try
			{
				ping.StartPing(regionAddress);
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.Log("catched: " + ex);
				break;
			}
			while (!ping.Done())
			{
				if (sw.ElapsedMilliseconds >= MaxMilliseconsPerPing)
				{
					overtime = true;
					break;
				}
				yield return 0;
			}
			sw.Stop();
			int num = (int)sw.ElapsedMilliseconds;
			rttResults.Add(num);
			if ((!IgnoreInitialAttempt || CurrentAttempt != 0) && ping.Successful && !overtime)
			{
				rttSum += (float)num;
				replyCount++;
				region.Ping = (int)(rttSum / (float)replyCount);
			}
			yield return new WaitForSeconds(0.1f);
		}
		Done = true;
		ping.Dispose();
		onDoneCall(region);
		yield return null;
	}

	public string GetResults()
	{
		return $"{region.Code}: {region.Ping} ({rttResults.ToStringFull()})";
	}

	public static string ResolveHost(string hostName)
	{
		if (hostName.StartsWith("wss://"))
		{
			hostName = hostName.Substring(6);
		}
		if (hostName.StartsWith("ws://"))
		{
			hostName = hostName.Substring(5);
		}
		string text = string.Empty;
		try
		{
			IPAddress[] hostAddresses = Dns.GetHostAddresses(hostName);
			if (hostAddresses.Length == 1)
			{
				return hostAddresses[0].ToString();
			}
			foreach (IPAddress iPAddress in hostAddresses)
			{
				if (iPAddress != null)
				{
					if (iPAddress.ToString().Contains(":"))
					{
						return iPAddress.ToString();
					}
					if (string.IsNullOrEmpty(text))
					{
						text = hostAddresses.ToString();
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return text;
	}
}
public class Room : RoomInfo
{
	private bool isOffline;

	private Dictionary<int, Player> players = new Dictionary<int, Player>();

	public LoadBalancingClient LoadBalancingClient { get; set; }

	public new string Name
	{
		get
		{
			return name;
		}
		internal set
		{
			name = value;
		}
	}

	public bool IsOffline
	{
		get
		{
			return isOffline;
		}
		private set
		{
			isOffline = value;
		}
	}

	public new bool IsOpen
	{
		get
		{
			return isOpen;
		}
		set
		{
			if (value != isOpen && !isOffline)
			{
				LoadBalancingClient.OpSetPropertiesOfRoom(new ExitGames.Client.Photon.Hashtable { { 253, value } });
			}
			isOpen = value;
		}
	}

	public new bool IsVisible
	{
		get
		{
			return isVisible;
		}
		set
		{
			if (value != isVisible && !isOffline)
			{
				LoadBalancingClient.OpSetPropertiesOfRoom(new ExitGames.Client.Photon.Hashtable { { 254, value } });
			}
			isVisible = value;
		}
	}

	public new byte MaxPlayers
	{
		get
		{
			return maxPlayers;
		}
		set
		{
			if (value != maxPlayers && !isOffline)
			{
				LoadBalancingClient.OpSetPropertiesOfRoom(new ExitGames.Client.Photon.Hashtable { 
				{
					byte.MaxValue,
					value
				} });
			}
			maxPlayers = value;
		}
	}

	public new byte PlayerCount
	{
		get
		{
			if (Players == null)
			{
				return 0;
			}
			return (byte)Players.Count;
		}
	}

	public Dictionary<int, Player> Players
	{
		get
		{
			return players;
		}
		private set
		{
			players = value;
		}
	}

	public string[] ExpectedUsers => expectedUsers;

	public int PlayerTtl
	{
		get
		{
			return playerTtl;
		}
		set
		{
			if (value != playerTtl && !isOffline)
			{
				LoadBalancingClient.OpSetPropertyOfRoom(246, value);
			}
			playerTtl = value;
		}
	}

	public int EmptyRoomTtl
	{
		get
		{
			return emptyRoomTtl;
		}
		set
		{
			if (value != emptyRoomTtl && !isOffline)
			{
				LoadBalancingClient.OpSetPropertyOfRoom(245, value);
			}
			emptyRoomTtl = value;
		}
	}

	public int MasterClientId => masterClientId;

	public string[] PropertiesListedInLobby
	{
		get
		{
			return propertiesListedInLobby;
		}
		private set
		{
			propertiesListedInLobby = value;
		}
	}

	public bool AutoCleanUp => autoCleanUp;

	public bool BroadcastPropertiesChangeToAll { get; private set; }

	public bool SuppressRoomEvents { get; private set; }

	public bool SuppressPlayerInfo { get; private set; }

	public bool PublishUserId { get; private set; }

	public bool DeleteNullProperties { get; private set; }

	public Room(string roomName, RoomOptions options, bool isOffline = false)
		: base(roomName, options?.CustomRoomProperties)
	{
		if (options != null)
		{
			isVisible = options.IsVisible;
			isOpen = options.IsOpen;
			maxPlayers = options.MaxPlayers;
			propertiesListedInLobby = options.CustomRoomPropertiesForLobby;
		}
		this.isOffline = isOffline;
	}

	internal void InternalCacheRoomFlags(int roomFlags)
	{
		BroadcastPropertiesChangeToAll = (roomFlags & 0x20) != 0;
		SuppressRoomEvents = (roomFlags & 4) != 0;
		SuppressPlayerInfo = (roomFlags & 0x40) != 0;
		PublishUserId = (roomFlags & 8) != 0;
		DeleteNullProperties = (roomFlags & 0x10) != 0;
		autoCleanUp = (roomFlags & 2) != 0;
	}

	protected internal override void InternalCacheProperties(ExitGames.Client.Photon.Hashtable propertiesToCache)
	{
		int num = masterClientId;
		base.InternalCacheProperties(propertiesToCache);
		if (num != 0 && masterClientId != num)
		{
			LoadBalancingClient.InRoomCallbackTargets.OnMasterClientSwitched(GetPlayer(masterClientId));
		}
	}

	public virtual bool SetCustomProperties(ExitGames.Client.Photon.Hashtable propertiesToSet, ExitGames.Client.Photon.Hashtable expectedProperties = null, WebFlags webFlags = null)
	{
		if (propertiesToSet == null || propertiesToSet.Count == 0)
		{
			return false;
		}
		ExitGames.Client.Photon.Hashtable hashtable = propertiesToSet.StripToStringKeys();
		if (isOffline)
		{
			if (hashtable.Count == 0)
			{
				return false;
			}
			base.CustomProperties.Merge(hashtable);
			base.CustomProperties.StripKeysWithNullValues();
			LoadBalancingClient.InRoomCallbackTargets.OnRoomPropertiesUpdate(propertiesToSet);
			return true;
		}
		return LoadBalancingClient.OpSetPropertiesOfRoom(hashtable, expectedProperties, webFlags);
	}

	public bool SetPropertiesListedInLobby(string[] lobbyProps)
	{
		if (isOffline)
		{
			return false;
		}
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable[250] = lobbyProps;
		return LoadBalancingClient.OpSetPropertiesOfRoom(hashtable);
	}

	protected internal virtual void RemovePlayer(Player player)
	{
		Players.Remove(player.ActorNumber);
		player.RoomReference = null;
	}

	protected internal virtual void RemovePlayer(int id)
	{
		RemovePlayer(GetPlayer(id));
	}

	public bool SetMasterClient(Player masterClientPlayer)
	{
		if (isOffline)
		{
			return false;
		}
		ExitGames.Client.Photon.Hashtable gameProperties = new ExitGames.Client.Photon.Hashtable { { 248, masterClientPlayer.ActorNumber } };
		ExitGames.Client.Photon.Hashtable expectedProperties = new ExitGames.Client.Photon.Hashtable { { 248, MasterClientId } };
		return LoadBalancingClient.OpSetPropertiesOfRoom(gameProperties, expectedProperties);
	}

	public virtual bool AddPlayer(Player player)
	{
		if (!Players.ContainsKey(player.ActorNumber))
		{
			StorePlayer(player);
			return true;
		}
		return false;
	}

	public virtual Player StorePlayer(Player player)
	{
		Players[player.ActorNumber] = player;
		player.RoomReference = this;
		return player;
	}

	public virtual Player GetPlayer(int id, bool findMaster = false)
	{
		int key = ((findMaster && id == 0) ? MasterClientId : id);
		Player value = null;
		Players.TryGetValue(key, out value);
		return value;
	}

	public bool ClearExpectedUsers()
	{
		if (ExpectedUsers == null || ExpectedUsers.Length == 0)
		{
			return false;
		}
		return SetExpectedUsers(new string[0], ExpectedUsers);
	}

	public bool SetExpectedUsers(string[] newExpectedUsers)
	{
		if (newExpectedUsers == null || newExpectedUsers.Length == 0)
		{
			LoadBalancingClient.DebugReturn(DebugLevel.ERROR, "newExpectedUsers array is null or empty, call Room.ClearExpectedUsers() instead if this is what you want.");
			return false;
		}
		return SetExpectedUsers(newExpectedUsers, ExpectedUsers);
	}

	private bool SetExpectedUsers(string[] newExpectedUsers, string[] oldExpectedUsers)
	{
		if (isOffline)
		{
			return false;
		}
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable(1);
		hashtable.Add(247, newExpectedUsers);
		ExitGames.Client.Photon.Hashtable hashtable2 = null;
		if (oldExpectedUsers != null)
		{
			hashtable2 = new ExitGames.Client.Photon.Hashtable(1);
			hashtable2.Add(247, oldExpectedUsers);
		}
		return LoadBalancingClient.OpSetPropertiesOfRoom(hashtable, hashtable2);
	}

	public override string ToString()
	{
		return string.Format("Room: '{0}' {1},{2} {4}/{3} players.", name, isVisible ? "visible" : "hidden", isOpen ? "open" : "closed", maxPlayers, PlayerCount);
	}

	public new string ToStringFull()
	{
		return string.Format("Room: '{0}' {1},{2} {4}/{3} players.\ncustomProps: {5}", name, isVisible ? "visible" : "hidden", isOpen ? "open" : "closed", maxPlayers, PlayerCount, base.CustomProperties.ToStringFull());
	}
}
public class RoomInfo
{
	public bool RemovedFromList;

	private ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();

	protected byte maxPlayers;

	protected int emptyRoomTtl;

	protected int playerTtl;

	protected string[] expectedUsers;

	protected bool isOpen = true;

	protected bool isVisible = true;

	protected bool autoCleanUp = true;

	protected string name;

	public int masterClientId;

	protected string[] propertiesListedInLobby;

	public ExitGames.Client.Photon.Hashtable CustomProperties => customProperties;

	public string Name => name;

	public int PlayerCount { get; private set; }

	public byte MaxPlayers => maxPlayers;

	public bool IsOpen => isOpen;

	public bool IsVisible => isVisible;

	protected internal RoomInfo(string roomName, ExitGames.Client.Photon.Hashtable roomProperties)
	{
		InternalCacheProperties(roomProperties);
		name = roomName;
	}

	public override bool Equals(object other)
	{
		if (other is RoomInfo roomInfo)
		{
			return Name.Equals(roomInfo.name);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return name.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format("Room: '{0}' {1},{2} {4}/{3} players.", name, isVisible ? "visible" : "hidden", isOpen ? "open" : "closed", maxPlayers, PlayerCount);
	}

	public string ToStringFull()
	{
		return string.Format("Room: '{0}' {1},{2} {4}/{3} players.\ncustomProps: {5}", name, isVisible ? "visible" : "hidden", isOpen ? "open" : "closed", maxPlayers, PlayerCount, customProperties.ToStringFull());
	}

	protected internal virtual void InternalCacheProperties(ExitGames.Client.Photon.Hashtable propertiesToCache)
	{
		if (propertiesToCache == null || propertiesToCache.Count == 0 || customProperties.Equals(propertiesToCache))
		{
			return;
		}
		if (propertiesToCache.ContainsKey(251) && propertiesToCache[251] is bool removedFromList)
		{
			RemovedFromList = removedFromList;
			if (RemovedFromList)
			{
				return;
			}
		}
		if (propertiesToCache.ContainsKey(byte.MaxValue) && propertiesToCache[byte.MaxValue] is byte b)
		{
			maxPlayers = b;
		}
		if (propertiesToCache.ContainsKey(253) && propertiesToCache[253] is bool flag)
		{
			isOpen = flag;
		}
		if (propertiesToCache.ContainsKey(254) && propertiesToCache[254] is bool flag2)
		{
			isVisible = flag2;
		}
		if (propertiesToCache.ContainsKey(252) && (propertiesToCache[252] is int || propertiesToCache[252] is byte))
		{
			PlayerCount = (byte)propertiesToCache[252];
		}
		if (propertiesToCache.ContainsKey(249) && propertiesToCache[249] is bool flag3)
		{
			autoCleanUp = flag3;
		}
		if (propertiesToCache.ContainsKey(248) && propertiesToCache[248] is int num)
		{
			masterClientId = num;
		}
		if (propertiesToCache.ContainsKey(250))
		{
			propertiesListedInLobby = propertiesToCache[250] as string[];
		}
		if (propertiesToCache.ContainsKey(247))
		{
			expectedUsers = propertiesToCache[247] as string[];
		}
		if (propertiesToCache.ContainsKey(245) && propertiesToCache[245] is int num2)
		{
			emptyRoomTtl = num2;
		}
		if (propertiesToCache.ContainsKey(246) && propertiesToCache[246] is int num3)
		{
			playerTtl = num3;
		}
		customProperties.MergeStringKeys(propertiesToCache);
		customProperties.StripKeysWithNullValues();
	}
}
[DisallowMultipleComponent]
[AddComponentMenu("")]
public class SupportLogger : MonoBehaviour, IConnectionCallbacks, IMatchmakingCallbacks, IInRoomCallbacks, ILobbyCallbacks, IErrorInfoCallback
{
	public bool LogTrafficStats = true;

	private bool loggedStillOfflineMessage;

	private LoadBalancingClient client;

	private Stopwatch startStopwatch;

	private bool initialOnApplicationPauseSkipped;

	private int pingMax;

	private int pingMin;

	public LoadBalancingClient Client
	{
		get
		{
			return client;
		}
		set
		{
			if (client != value)
			{
				if (client != null)
				{
					client.RemoveCallbackTarget(this);
				}
				client = value;
				if (client != null)
				{
					client.AddCallbackTarget(this);
				}
			}
		}
	}

	protected void Start()
	{
		LogBasics();
		if (startStopwatch == null)
		{
			startStopwatch = new Stopwatch();
			startStopwatch.Start();
		}
	}

	protected void OnDestroy()
	{
		Client = null;
	}

	protected void OnApplicationPause(bool pause)
	{
		if (!initialOnApplicationPauseSkipped)
		{
			initialOnApplicationPauseSkipped = true;
		}
		else
		{
			UnityEngine.Debug.Log(string.Format("{0} SupportLogger OnApplicationPause({1}). Client: {2}.", GetFormattedTimestamp(), pause, (client == null) ? "null" : client.State.ToString()));
		}
	}

	protected void OnApplicationQuit()
	{
		CancelInvoke();
	}

	public void StartLogStats()
	{
		InvokeRepeating("LogStats", 10f, 10f);
	}

	public void StopLogStats()
	{
		CancelInvoke("LogStats");
	}

	private void StartTrackValues()
	{
		InvokeRepeating("TrackValues", 0.5f, 0.5f);
	}

	private void StopTrackValues()
	{
		CancelInvoke("TrackValues");
	}

	private string GetFormattedTimestamp()
	{
		if (startStopwatch == null)
		{
			startStopwatch = new Stopwatch();
			startStopwatch.Start();
		}
		TimeSpan elapsed = startStopwatch.Elapsed;
		if (elapsed.Minutes > 0)
		{
			return string.Format("[{0}:{1}.{1}]", elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds);
		}
		return $"[{elapsed.Seconds}.{elapsed.Milliseconds}]";
	}

	private void TrackValues()
	{
		if (client != null)
		{
			int roundTripTime = client.LoadBalancingPeer.RoundTripTime;
			if (roundTripTime > pingMax)
			{
				pingMax = roundTripTime;
			}
			if (roundTripTime < pingMin)
			{
				pingMin = roundTripTime;
			}
		}
	}

	public void LogStats()
	{
		if (client != null && client.State != ClientState.PeerCreated && LogTrafficStats)
		{
			UnityEngine.Debug.Log($"{GetFormattedTimestamp()} SupportLogger {client.LoadBalancingPeer.VitalStatsToString(all: false)} Ping min/max: {pingMin}/{pingMax}");
		}
	}

	private void LogBasics()
	{
		if (client != null)
		{
			List<string> list = new List<string>(10);
			list.Add(Application.unityVersion);
			list.Add(Application.platform.ToString());
			list.Add("ENABLE_MONO");
			list.Add("NET_STANDARD_2_0");
			list.Add("UNITY_64");
			StringBuilder stringBuilder = new StringBuilder();
			string text = ((string.IsNullOrEmpty(client.AppId) || client.AppId.Length < 8) ? client.AppId : (client.AppId.Substring(0, 8) + "***"));
			stringBuilder.AppendFormat("{0} SupportLogger Info: ", GetFormattedTimestamp());
			stringBuilder.AppendFormat("AppID: \"{0}\" AppVersion: \"{1}\" Client: v{2} ({4}) Build: {3} ", text, client.AppVersion, PhotonPeer.Version, string.Join(", ", list.ToArray()), client.LoadBalancingPeer.TargetFramework);
			if (client != null && client.LoadBalancingPeer != null && client.LoadBalancingPeer.SocketImplementation != null)
			{
				stringBuilder.AppendFormat("Socket: {0} ", client.LoadBalancingPeer.SocketImplementation.Name);
			}
			stringBuilder.AppendFormat("UserId: \"{0}\" AuthType: {1} AuthMode: {2} {3} ", client.UserId, (client.AuthValues != null) ? client.AuthValues.AuthType.ToString() : "N/A", client.AuthMode, client.EncryptionMode);
			stringBuilder.AppendFormat("State: {0} ", client.State);
			stringBuilder.AppendFormat("PeerID: {0} ", client.LoadBalancingPeer.PeerID);
			stringBuilder.AppendFormat("NameServer: {0} Current Server: {1} IP: {2} Region: {3} ", client.NameServerHost, client.CurrentServerAddress, client.LoadBalancingPeer.ServerIpAddress, client.CloudRegion);
			UnityEngine.Debug.LogWarning(stringBuilder.ToString());
		}
	}

	public void OnConnected()
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnConnected().");
		pingMax = 0;
		pingMin = client.LoadBalancingPeer.RoundTripTime;
		LogBasics();
		if (LogTrafficStats)
		{
			client.LoadBalancingPeer.TrafficStatsEnabled = false;
			client.LoadBalancingPeer.TrafficStatsEnabled = true;
			StartLogStats();
		}
		StartTrackValues();
	}

	public void OnConnectedToMaster()
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnConnectedToMaster().");
	}

	public void OnFriendListUpdate(List<FriendInfo> friendList)
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnFriendListUpdate(friendList).");
	}

	public void OnJoinedLobby()
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnJoinedLobby(" + client.CurrentLobby?.ToString() + ").");
	}

	public void OnLeftLobby()
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnLeftLobby().");
	}

	public void OnCreateRoomFailed(short returnCode, string message)
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnCreateRoomFailed(" + returnCode + "," + message + ").");
	}

	public void OnJoinedRoom()
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnJoinedRoom(" + client.CurrentRoom?.ToString() + "). " + client.CurrentLobby?.ToString() + " GameServer:" + client.GameServerAddress);
	}

	public void OnJoinRoomFailed(short returnCode, string message)
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnJoinRoomFailed(" + returnCode + "," + message + ").");
	}

	public void OnJoinRandomFailed(short returnCode, string message)
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnJoinRandomFailed(" + returnCode + "," + message + ").");
	}

	public void OnCreatedRoom()
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnCreatedRoom(" + client.CurrentRoom?.ToString() + "). " + client.CurrentLobby?.ToString() + " GameServer:" + client.GameServerAddress);
	}

	public void OnLeftRoom()
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnLeftRoom().");
	}

	public void OnPreLeavingRoom()
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnPreLeavingRoom()");
	}

	public void OnDisconnected(DisconnectCause cause)
	{
		StopLogStats();
		StopTrackValues();
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnDisconnected(" + cause.ToString() + ").");
		LogBasics();
		LogStats();
	}

	public void OnRegionListReceived(RegionHandler regionHandler)
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnRegionListReceived(regionHandler).");
	}

	public void OnRoomListUpdate(List<RoomInfo> roomList)
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnRoomListUpdate(roomList). roomList.Count: " + roomList.Count);
	}

	public void OnPlayerEnteredRoom(Player newPlayer)
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnPlayerEnteredRoom(" + newPlayer?.ToString() + ").");
	}

	public void OnPlayerLeftRoom(Player otherPlayer)
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnPlayerLeftRoom(" + otherPlayer?.ToString() + ").");
	}

	public void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnRoomPropertiesUpdate(propertiesThatChanged).");
	}

	public void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnPlayerPropertiesUpdate(targetPlayer,changedProps).");
	}

	public void OnMasterClientSwitched(Player newMasterClient)
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnMasterClientSwitched(" + newMasterClient?.ToString() + ").");
	}

	public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnCustomAuthenticationResponse(" + data.ToStringFull() + ").");
	}

	public void OnCustomAuthenticationFailed(string debugMessage)
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnCustomAuthenticationFailed(" + debugMessage + ").");
	}

	public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
	{
		UnityEngine.Debug.Log(GetFormattedTimestamp() + " SupportLogger OnLobbyStatisticsUpdate(lobbyStatistics).");
	}

	public void OnErrorInfo(ErrorInfo errorInfo)
	{
		UnityEngine.Debug.LogError(errorInfo.ToString());
	}
}
public class WebRpcResponse
{
	public string Name { get; private set; }

	public int ResultCode { get; private set; }

	[Obsolete("Use ResultCode instead")]
	public int ReturnCode => ResultCode;

	public string Message { get; private set; }

	[Obsolete("Use Message instead")]
	public string DebugMessage => Message;

	public Dictionary<string, object> Parameters { get; private set; }

	public WebRpcResponse(OperationResponse response)
	{
		if (response.Parameters.TryGetValue(209, out var value))
		{
			Name = value as string;
		}
		ResultCode = -1;
		if (response.Parameters.TryGetValue(207, out value))
		{
			ResultCode = (byte)value;
		}
		if (response.Parameters.TryGetValue(208, out value))
		{
			Parameters = value as Dictionary<string, object>;
		}
		if (response.Parameters.TryGetValue(206, out value))
		{
			Message = value as string;
		}
	}

	public string ToStringFull()
	{
		return string.Format("{0}={2}: {1} \"{3}\"", Name, SupportClass.DictionaryToString(Parameters), ResultCode, Message);
	}
}
public class WebFlags
{
	public static readonly WebFlags Default = new WebFlags(0);

	public byte WebhookFlags;

	public const byte HttpForwardConst = 1;

	public const byte SendAuthCookieConst = 2;

	public const byte SendSyncConst = 4;

	public const byte SendStateConst = 8;

	public bool HttpForward
	{
		get
		{
			return (WebhookFlags & 1) != 0;
		}
		set
		{
			if (value)
			{
				WebhookFlags |= 1;
			}
			else
			{
				WebhookFlags = (byte)(WebhookFlags & -2);
			}
		}
	}

	public bool SendAuthCookie
	{
		get
		{
			return (WebhookFlags & 2) != 0;
		}
		set
		{
			if (value)
			{
				WebhookFlags |= 2;
			}
			else
			{
				WebhookFlags = (byte)(WebhookFlags & -3);
			}
		}
	}

	public bool SendSync
	{
		get
		{
			return (WebhookFlags & 4) != 0;
		}
		set
		{
			if (value)
			{
				WebhookFlags |= 4;
			}
			else
			{
				WebhookFlags = (byte)(WebhookFlags & -5);
			}
		}
	}

	public bool SendState
	{
		get
		{
			return (WebhookFlags & 8) != 0;
		}
		set
		{
			if (value)
			{
				WebhookFlags |= 8;
			}
			else
			{
				WebhookFlags = (byte)(WebhookFlags & -9);
			}
		}
	}

	public WebFlags(byte webhookFlags)
	{
		WebhookFlags = webhookFlags;
	}
}
