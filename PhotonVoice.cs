using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using CSCore;
using CSCore.Codecs.WAV;
using ExitGames.Client.Photon;
using POpusCodec.Enums;
using Photon.Realtime;
using Photon.Voice.Windows;
using UnityEngine;
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
			FilePathsData = new byte[2395]
			{
				0, 0, 0, 1, 0, 0, 0, 54, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 86,
				111, 105, 99, 101, 92, 67, 111, 100, 101, 92,
				65, 117, 100, 105, 111, 67, 104, 97, 110, 103,
				101, 115, 72, 97, 110, 100, 108, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 54,
				92, 65, 115, 115, 101, 116, 115, 92, 80, 104,
				111, 116, 111, 110, 92, 80, 104, 111, 116, 111,
				110, 86, 111, 105, 99, 101, 92, 67, 111, 100,
				101, 92, 65, 117, 100, 105, 111, 73, 110, 69,
				110, 117, 109, 101, 114, 97, 116, 111, 114, 69,
				120, 46, 99, 115, 0, 0, 0, 2, 0, 0,
				0, 44, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 86, 111, 105, 99, 101, 92, 67,
				111, 100, 101, 92, 73, 76, 111, 103, 103, 97,
				98, 108, 101, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 66, 92, 65, 115, 115, 101, 116,
				115, 92, 80, 104, 111, 116, 111, 110, 92, 80,
				104, 111, 116, 111, 110, 86, 111, 105, 99, 101,
				92, 67, 111, 100, 101, 92, 78, 97, 116, 105,
				118, 101, 65, 110, 100, 114, 111, 105, 100, 77,
				105, 99, 114, 111, 112, 104, 111, 110, 101, 83,
				101, 116, 116, 105, 110, 103, 115, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 56, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 86,
				111, 105, 99, 101, 92, 67, 111, 100, 101, 92,
				80, 108, 97, 121, 98, 97, 99, 107, 68, 101,
				108, 97, 121, 83, 101, 116, 116, 105, 110, 103,
				115, 46, 99, 115, 0, 0, 0, 2, 0, 0,
				0, 43, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 86, 111, 105, 99, 101, 92, 67,
				111, 100, 101, 92, 82, 101, 99, 111, 114, 100,
				101, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 50, 92, 65, 115, 115, 101, 116, 115,
				92, 80, 104, 111, 116, 111, 110, 92, 80, 104,
				111, 116, 111, 110, 86, 111, 105, 99, 101, 92,
				67, 111, 100, 101, 92, 82, 101, 109, 111, 116,
				101, 86, 111, 105, 99, 101, 76, 105, 110, 107,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				42, 92, 65, 115, 115, 101, 116, 115, 92, 80,
				104, 111, 116, 111, 110, 92, 80, 104, 111, 116,
				111, 110, 86, 111, 105, 99, 101, 92, 67, 111,
				100, 101, 92, 83, 112, 101, 97, 107, 101, 114,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				87, 92, 65, 115, 115, 101, 116, 115, 92, 80,
				104, 111, 116, 111, 110, 92, 80, 104, 111, 116,
				111, 110, 86, 111, 105, 99, 101, 92, 67, 111,
				100, 101, 92, 85, 116, 105, 108, 105, 116, 121,
				83, 99, 114, 105, 112, 116, 115, 92, 65, 117,
				100, 105, 111, 85, 116, 105, 108, 115, 92, 67,
				83, 67, 111, 114, 101, 92, 65, 117, 100, 105,
				111, 83, 117, 98, 84, 121, 112, 101, 115, 46,
				85, 116, 105, 108, 115, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 81, 92, 65, 115, 115,
				101, 116, 115, 92, 80, 104, 111, 116, 111, 110,
				92, 80, 104, 111, 116, 111, 110, 86, 111, 105,
				99, 101, 92, 67, 111, 100, 101, 92, 85, 116,
				105, 108, 105, 116, 121, 83, 99, 114, 105, 112,
				116, 115, 92, 65, 117, 100, 105, 111, 85, 116,
				105, 108, 115, 92, 67, 83, 67, 111, 114, 101,
				92, 65, 117, 100, 105, 111, 83, 121, 98, 84,
				121, 112, 101, 115, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 78, 92, 65, 115, 115, 101,
				116, 115, 92, 80, 104, 111, 116, 111, 110, 92,
				80, 104, 111, 116, 111, 110, 86, 111, 105, 99,
				101, 92, 67, 111, 100, 101, 92, 85, 116, 105,
				108, 105, 116, 121, 83, 99, 114, 105, 112, 116,
				115, 92, 65, 117, 100, 105, 111, 85, 116, 105,
				108, 115, 92, 67, 83, 67, 111, 114, 101, 92,
				69, 120, 116, 101, 110, 115, 105, 111, 110, 115,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				80, 92, 65, 115, 115, 101, 116, 115, 92, 80,
				104, 111, 116, 111, 110, 92, 80, 104, 111, 116,
				111, 110, 86, 111, 105, 99, 101, 92, 67, 111,
				100, 101, 92, 85, 116, 105, 108, 105, 116, 121,
				83, 99, 114, 105, 112, 116, 115, 92, 65, 117,
				100, 105, 111, 85, 116, 105, 108, 115, 92, 67,
				83, 67, 111, 114, 101, 92, 73, 65, 117, 100,
				105, 111, 83, 111, 117, 114, 99, 101, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 88, 92,
				65, 115, 115, 101, 116, 115, 92, 80, 104, 111,
				116, 111, 110, 92, 80, 104, 111, 116, 111, 110,
				86, 111, 105, 99, 101, 92, 67, 111, 100, 101,
				92, 85, 116, 105, 108, 105, 116, 121, 83, 99,
				114, 105, 112, 116, 115, 92, 65, 117, 100, 105,
				111, 85, 116, 105, 108, 115, 92, 67, 83, 67,
				111, 114, 101, 92, 73, 82, 101, 97, 100, 97,
				98, 108, 101, 65, 117, 100, 105, 111, 83, 111,
				117, 114, 99, 101, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 79, 92, 65, 115, 115, 101,
				116, 115, 92, 80, 104, 111, 116, 111, 110, 92,
				80, 104, 111, 116, 111, 110, 86, 111, 105, 99,
				101, 92, 67, 111, 100, 101, 92, 85, 116, 105,
				108, 105, 116, 121, 83, 99, 114, 105, 112, 116,
				115, 92, 65, 117, 100, 105, 111, 85, 116, 105,
				108, 115, 92, 67, 83, 67, 111, 114, 101, 92,
				73, 87, 97, 118, 101, 83, 111, 117, 114, 99,
				101, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 78, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 86, 111, 105, 99, 101, 92, 67,
				111, 100, 101, 92, 85, 116, 105, 108, 105, 116,
				121, 83, 99, 114, 105, 112, 116, 115, 92, 65,
				117, 100, 105, 111, 85, 116, 105, 108, 115, 92,
				67, 83, 67, 111, 114, 101, 92, 73, 87, 114,
				105, 116, 101, 97, 98, 108, 101, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 78, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 86,
				111, 105, 99, 101, 92, 67, 111, 100, 101, 92,
				85, 116, 105, 108, 105, 116, 121, 83, 99, 114,
				105, 112, 116, 115, 92, 65, 117, 100, 105, 111,
				85, 116, 105, 108, 115, 92, 67, 83, 67, 111,
				114, 101, 92, 87, 97, 118, 101, 70, 111, 114,
				109, 97, 116, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 88, 92, 65, 115, 115, 101, 116,
				115, 92, 80, 104, 111, 116, 111, 110, 92, 80,
				104, 111, 116, 111, 110, 86, 111, 105, 99, 101,
				92, 67, 111, 100, 101, 92, 85, 116, 105, 108,
				105, 116, 121, 83, 99, 114, 105, 112, 116, 115,
				92, 65, 117, 100, 105, 111, 85, 116, 105, 108,
				115, 92, 67, 83, 67, 111, 114, 101, 92, 87,
				97, 118, 101, 70, 111, 114, 109, 97, 116, 69,
				120, 116, 101, 110, 115, 105, 98, 108, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 78,
				92, 65, 115, 115, 101, 116, 115, 92, 80, 104,
				111, 116, 111, 110, 92, 80, 104, 111, 116, 111,
				110, 86, 111, 105, 99, 101, 92, 67, 111, 100,
				101, 92, 85, 116, 105, 108, 105, 116, 121, 83,
				99, 114, 105, 112, 116, 115, 92, 65, 117, 100,
				105, 111, 85, 116, 105, 108, 115, 92, 67, 83,
				67, 111, 114, 101, 92, 87, 97, 118, 101, 87,
				114, 105, 116, 101, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 64, 92, 65, 115, 115,
				101, 116, 115, 92, 80, 104, 111, 116, 111, 110,
				92, 80, 104, 111, 116, 111, 110, 86, 111, 105,
				99, 101, 92, 67, 111, 100, 101, 92, 85, 116,
				105, 108, 105, 116, 121, 83, 99, 114, 105, 112,
				116, 115, 92, 67, 111, 110, 110, 101, 99, 116,
				65, 110, 100, 74, 111, 105, 110, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 75, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 86,
				111, 105, 99, 101, 92, 67, 111, 100, 101, 92,
				85, 116, 105, 108, 105, 116, 121, 83, 99, 114,
				105, 112, 116, 115, 92, 77, 105, 99, 65, 109,
				112, 108, 105, 102, 105, 101, 114, 92, 77, 105,
				99, 65, 109, 112, 108, 105, 102, 105, 101, 114,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				80, 92, 65, 115, 115, 101, 116, 115, 92, 80,
				104, 111, 116, 111, 110, 92, 80, 104, 111, 116,
				111, 110, 86, 111, 105, 99, 101, 92, 67, 111,
				100, 101, 92, 85, 116, 105, 108, 105, 116, 121,
				83, 99, 114, 105, 112, 116, 115, 92, 77, 105,
				99, 65, 109, 112, 108, 105, 102, 105, 101, 114,
				92, 77, 105, 99, 65, 109, 112, 108, 105, 102,
				105, 101, 114, 70, 108, 111, 97, 116, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 80, 92,
				65, 115, 115, 101, 116, 115, 92, 80, 104, 111,
				116, 111, 110, 92, 80, 104, 111, 116, 111, 110,
				86, 111, 105, 99, 101, 92, 67, 111, 100, 101,
				92, 85, 116, 105, 108, 105, 116, 121, 83, 99,
				114, 105, 112, 116, 115, 92, 77, 105, 99, 65,
				109, 112, 108, 105, 102, 105, 101, 114, 92, 77,
				105, 99, 65, 109, 112, 108, 105, 102, 105, 101,
				114, 83, 104, 111, 114, 116, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 70, 92, 65, 115,
				115, 101, 116, 115, 92, 80, 104, 111, 116, 111,
				110, 92, 80, 104, 111, 116, 111, 110, 86, 111,
				105, 99, 101, 92, 67, 111, 100, 101, 92, 85,
				116, 105, 108, 105, 116, 121, 83, 99, 114, 105,
				112, 116, 115, 92, 77, 105, 99, 114, 111, 112,
				104, 111, 110, 101, 80, 101, 114, 109, 105, 115,
				115, 105, 111, 110, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 77, 92, 65, 115, 115, 101,
				116, 115, 92, 80, 104, 111, 116, 111, 110, 92,
				80, 104, 111, 116, 111, 110, 86, 111, 105, 99,
				101, 92, 67, 111, 100, 101, 92, 85, 116, 105,
				108, 105, 116, 121, 83, 99, 114, 105, 112, 116,
				115, 92, 80, 104, 111, 116, 111, 110, 86, 111,
				105, 99, 101, 76, 97, 103, 83, 105, 109, 117,
				108, 97, 116, 105, 111, 110, 71, 117, 105, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 69,
				92, 65, 115, 115, 101, 116, 115, 92, 80, 104,
				111, 116, 111, 110, 92, 80, 104, 111, 116, 111,
				110, 86, 111, 105, 99, 101, 92, 67, 111, 100,
				101, 92, 85, 116, 105, 108, 105, 116, 121, 83,
				99, 114, 105, 112, 116, 115, 92, 80, 104, 111,
				116, 111, 110, 86, 111, 105, 99, 101, 83, 116,
				97, 116, 115, 71, 117, 105, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 74, 92, 65, 115,
				115, 101, 116, 115, 92, 80, 104, 111, 116, 111,
				110, 92, 80, 104, 111, 116, 111, 110, 86, 111,
				105, 99, 101, 92, 67, 111, 100, 101, 92, 85,
				116, 105, 108, 105, 116, 121, 83, 99, 114, 105,
				112, 116, 115, 92, 83, 97, 118, 101, 73, 110,
				99, 111, 109, 105, 110, 103, 83, 116, 114, 101,
				97, 109, 84, 111, 70, 105, 108, 101, 46, 99,
				115, 0, 0, 0, 3, 0, 0, 0, 74, 92,
				65, 115, 115, 101, 116, 115, 92, 80, 104, 111,
				116, 111, 110, 92, 80, 104, 111, 116, 111, 110,
				86, 111, 105, 99, 101, 92, 67, 111, 100, 101,
				92, 85, 116, 105, 108, 105, 116, 121, 83, 99,
				114, 105, 112, 116, 115, 92, 83, 97, 118, 101,
				79, 117, 116, 103, 111, 105, 110, 103, 83, 116,
				114, 101, 97, 109, 84, 111, 70, 105, 108, 101,
				46, 99, 115, 0, 0, 0, 2, 0, 0, 0,
				58, 92, 65, 115, 115, 101, 116, 115, 92, 80,
				104, 111, 116, 111, 110, 92, 80, 104, 111, 116,
				111, 110, 86, 111, 105, 99, 101, 92, 67, 111,
				100, 101, 92, 85, 116, 105, 108, 105, 116, 121,
				83, 99, 114, 105, 112, 116, 115, 92, 84, 101,
				115, 116, 84, 111, 110, 101, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 49, 92, 65, 115,
				115, 101, 116, 115, 92, 80, 104, 111, 116, 111,
				110, 92, 80, 104, 111, 116, 111, 110, 86, 111,
				105, 99, 101, 92, 67, 111, 100, 101, 92, 86,
				111, 105, 99, 101, 67, 111, 109, 112, 111, 110,
				101, 110, 116, 46, 99, 115, 0, 0, 0, 2,
				0, 0, 0, 50, 92, 65, 115, 115, 101, 116,
				115, 92, 80, 104, 111, 116, 111, 110, 92, 80,
				104, 111, 116, 111, 110, 86, 111, 105, 99, 101,
				92, 67, 111, 100, 101, 92, 86, 111, 105, 99,
				101, 67, 111, 110, 110, 101, 99, 116, 105, 111,
				110, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 46, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 86, 111, 105, 99, 101, 92, 67,
				111, 100, 101, 92, 86, 111, 105, 99, 101, 76,
				111, 103, 103, 101, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 49, 92, 65, 115, 115,
				101, 116, 115, 92, 80, 104, 111, 116, 111, 110,
				92, 80, 104, 111, 116, 111, 110, 86, 111, 105,
				99, 101, 92, 67, 111, 100, 101, 92, 87, 101,
				98, 82, 116, 99, 65, 117, 100, 105, 111, 68,
				115, 112, 46, 99, 115
			},
			TypesData = new byte[1671]
			{
				0, 0, 0, 0, 38, 80, 104, 111, 116, 111,
				110, 46, 86, 111, 105, 99, 101, 46, 85, 110,
				105, 116, 121, 124, 65, 117, 100, 105, 111, 67,
				104, 97, 110, 103, 101, 115, 72, 97, 110, 100,
				108, 101, 114, 0, 0, 0, 0, 38, 80, 104,
				111, 116, 111, 110, 46, 86, 111, 105, 99, 101,
				46, 85, 110, 105, 116, 121, 124, 65, 117, 100,
				105, 111, 73, 110, 69, 110, 117, 109, 101, 114,
				97, 116, 111, 114, 69, 120, 0, 0, 0, 0,
				28, 80, 104, 111, 116, 111, 110, 46, 86, 111,
				105, 99, 101, 46, 85, 110, 105, 116, 121, 124,
				73, 76, 111, 103, 103, 97, 98, 108, 101, 0,
				0, 0, 0, 37, 80, 104, 111, 116, 111, 110,
				46, 86, 111, 105, 99, 101, 46, 85, 110, 105,
				116, 121, 124, 73, 76, 111, 103, 103, 97, 98,
				108, 101, 68, 101, 112, 101, 110, 100, 101, 110,
				116, 0, 0, 0, 0, 50, 80, 104, 111, 116,
				111, 110, 46, 86, 111, 105, 99, 101, 46, 85,
				110, 105, 116, 121, 124, 78, 97, 116, 105, 118,
				101, 65, 110, 100, 114, 111, 105, 100, 77, 105,
				99, 114, 111, 112, 104, 111, 110, 101, 83, 101,
				116, 116, 105, 110, 103, 115, 0, 0, 0, 0,
				40, 80, 104, 111, 116, 111, 110, 46, 86, 111,
				105, 99, 101, 46, 85, 110, 105, 116, 121, 124,
				80, 108, 97, 121, 98, 97, 99, 107, 68, 101,
				108, 97, 121, 83, 101, 116, 116, 105, 110, 103,
				115, 0, 0, 0, 0, 27, 80, 104, 111, 116,
				111, 110, 46, 86, 111, 105, 99, 101, 46, 85,
				110, 105, 116, 121, 124, 82, 101, 99, 111, 114,
				100, 101, 114, 0, 0, 0, 0, 52, 80, 104,
				111, 116, 111, 110, 46, 86, 111, 105, 99, 101,
				46, 85, 110, 105, 116, 121, 46, 82, 101, 99,
				111, 114, 100, 101, 114, 124, 80, 104, 111, 116,
				111, 110, 86, 111, 105, 99, 101, 67, 114, 101,
				97, 116, 101, 100, 80, 97, 114, 97, 109, 115,
				0, 0, 0, 0, 34, 80, 104, 111, 116, 111,
				110, 46, 86, 111, 105, 99, 101, 46, 85, 110,
				105, 116, 121, 124, 82, 101, 109, 111, 116, 101,
				86, 111, 105, 99, 101, 76, 105, 110, 107, 0,
				0, 0, 0, 26, 80, 104, 111, 116, 111, 110,
				46, 86, 111, 105, 99, 101, 46, 85, 110, 105,
				116, 121, 124, 83, 112, 101, 97, 107, 101, 114,
				1, 0, 0, 0, 20, 67, 83, 67, 111, 114,
				101, 124, 65, 117, 100, 105, 111, 83, 117, 98,
				84, 121, 112, 101, 115, 1, 0, 0, 0, 20,
				67, 83, 67, 111, 114, 101, 124, 65, 117, 100,
				105, 111, 83, 117, 98, 84, 121, 112, 101, 115,
				0, 0, 0, 0, 17, 67, 83, 67, 111, 114,
				101, 124, 69, 120, 116, 101, 110, 115, 105, 111,
				110, 115, 0, 0, 0, 0, 19, 67, 83, 67,
				111, 114, 101, 124, 73, 65, 117, 100, 105, 111,
				83, 111, 117, 114, 99, 101, 0, 0, 0, 0,
				27, 67, 83, 67, 111, 114, 101, 124, 73, 82,
				101, 97, 100, 97, 98, 108, 101, 65, 117, 100,
				105, 111, 83, 111, 117, 114, 99, 101, 0, 0,
				0, 0, 18, 67, 83, 67, 111, 114, 101, 124,
				73, 87, 97, 118, 101, 83, 111, 117, 114, 99,
				101, 0, 0, 0, 0, 17, 67, 83, 67, 111,
				114, 101, 124, 73, 87, 114, 105, 116, 101, 97,
				98, 108, 101, 0, 0, 0, 0, 17, 67, 83,
				67, 111, 114, 101, 124, 87, 97, 118, 101, 70,
				111, 114, 109, 97, 116, 0, 0, 0, 0, 27,
				67, 83, 67, 111, 114, 101, 124, 87, 97, 118,
				101, 70, 111, 114, 109, 97, 116, 69, 120, 116,
				101, 110, 115, 105, 98, 108, 101, 0, 0, 0,
				0, 28, 67, 83, 67, 111, 114, 101, 46, 67,
				111, 100, 101, 99, 115, 46, 87, 65, 86, 124,
				87, 97, 118, 101, 87, 114, 105, 116, 101, 114,
				0, 0, 0, 0, 48, 80, 104, 111, 116, 111,
				110, 46, 86, 111, 105, 99, 101, 46, 85, 110,
				105, 116, 121, 46, 85, 116, 105, 108, 105, 116,
				121, 83, 99, 114, 105, 112, 116, 115, 124, 67,
				111, 110, 110, 101, 99, 116, 65, 110, 100, 74,
				111, 105, 110, 0, 0, 0, 0, 46, 80, 104,
				111, 116, 111, 110, 46, 86, 111, 105, 99, 101,
				46, 85, 110, 105, 116, 121, 46, 85, 116, 105,
				108, 105, 116, 121, 83, 99, 114, 105, 112, 116,
				115, 124, 77, 105, 99, 65, 109, 112, 108, 105,
				102, 105, 101, 114, 0, 0, 0, 0, 51, 80,
				104, 111, 116, 111, 110, 46, 86, 111, 105, 99,
				101, 46, 85, 110, 105, 116, 121, 46, 85, 116,
				105, 108, 105, 116, 121, 83, 99, 114, 105, 112,
				116, 115, 124, 77, 105, 99, 65, 109, 112, 108,
				105, 102, 105, 101, 114, 70, 108, 111, 97, 116,
				0, 0, 0, 0, 51, 80, 104, 111, 116, 111,
				110, 46, 86, 111, 105, 99, 101, 46, 85, 110,
				105, 116, 121, 46, 85, 116, 105, 108, 105, 116,
				121, 83, 99, 114, 105, 112, 116, 115, 124, 77,
				105, 99, 65, 109, 112, 108, 105, 102, 105, 101,
				114, 83, 104, 111, 114, 116, 0, 0, 0, 0,
				54, 80, 104, 111, 116, 111, 110, 46, 86, 111,
				105, 99, 101, 46, 85, 110, 105, 116, 121, 46,
				85, 116, 105, 108, 105, 116, 121, 83, 99, 114,
				105, 112, 116, 115, 124, 77, 105, 99, 114, 111,
				112, 104, 111, 110, 101, 80, 101, 114, 109, 105,
				115, 115, 105, 111, 110, 0, 0, 0, 0, 61,
				80, 104, 111, 116, 111, 110, 46, 86, 111, 105,
				99, 101, 46, 85, 110, 105, 116, 121, 46, 85,
				116, 105, 108, 105, 116, 121, 83, 99, 114, 105,
				112, 116, 115, 124, 80, 104, 111, 116, 111, 110,
				86, 111, 105, 99, 101, 76, 97, 103, 83, 105,
				109, 117, 108, 97, 116, 105, 111, 110, 71, 117,
				105, 0, 0, 0, 0, 53, 80, 104, 111, 116,
				111, 110, 46, 86, 111, 105, 99, 101, 46, 85,
				110, 105, 116, 121, 46, 85, 116, 105, 108, 105,
				116, 121, 83, 99, 114, 105, 112, 116, 115, 124,
				80, 104, 111, 116, 111, 110, 86, 111, 105, 99,
				101, 83, 116, 97, 116, 115, 71, 117, 105, 0,
				0, 0, 0, 58, 80, 104, 111, 116, 111, 110,
				46, 86, 111, 105, 99, 101, 46, 85, 110, 105,
				116, 121, 46, 85, 116, 105, 108, 105, 116, 121,
				83, 99, 114, 105, 112, 116, 115, 124, 83, 97,
				118, 101, 73, 110, 99, 111, 109, 105, 110, 103,
				83, 116, 114, 101, 97, 109, 84, 111, 70, 105,
				108, 101, 0, 0, 0, 0, 58, 80, 104, 111,
				116, 111, 110, 46, 86, 111, 105, 99, 101, 46,
				85, 110, 105, 116, 121, 46, 85, 116, 105, 108,
				105, 116, 121, 83, 99, 114, 105, 112, 116, 115,
				124, 83, 97, 118, 101, 79, 117, 116, 103, 111,
				105, 110, 103, 83, 116, 114, 101, 97, 109, 84,
				111, 70, 105, 108, 101, 0, 0, 0, 0, 83,
				80, 104, 111, 116, 111, 110, 46, 86, 111, 105,
				99, 101, 46, 85, 110, 105, 116, 121, 46, 85,
				116, 105, 108, 105, 116, 121, 83, 99, 114, 105,
				112, 116, 115, 46, 83, 97, 118, 101, 79, 117,
				116, 103, 111, 105, 110, 103, 83, 116, 114, 101,
				97, 109, 84, 111, 70, 105, 108, 101, 124, 79,
				117, 116, 103, 111, 105, 110, 103, 83, 116, 114,
				101, 97, 109, 83, 97, 118, 101, 114, 70, 108,
				111, 97, 116, 0, 0, 0, 0, 83, 80, 104,
				111, 116, 111, 110, 46, 86, 111, 105, 99, 101,
				46, 85, 110, 105, 116, 121, 46, 85, 116, 105,
				108, 105, 116, 121, 83, 99, 114, 105, 112, 116,
				115, 46, 83, 97, 118, 101, 79, 117, 116, 103,
				111, 105, 110, 103, 83, 116, 114, 101, 97, 109,
				84, 111, 70, 105, 108, 101, 124, 79, 117, 116,
				103, 111, 105, 110, 103, 83, 116, 114, 101, 97,
				109, 83, 97, 118, 101, 114, 83, 104, 111, 114,
				116, 0, 0, 0, 0, 42, 80, 104, 111, 116,
				111, 110, 46, 86, 111, 105, 99, 101, 46, 85,
				110, 105, 116, 121, 46, 85, 116, 105, 108, 105,
				116, 121, 83, 99, 114, 105, 112, 116, 115, 124,
				84, 101, 115, 116, 84, 111, 110, 101, 0, 0,
				0, 0, 49, 80, 104, 111, 116, 111, 110, 46,
				86, 111, 105, 99, 101, 46, 85, 110, 105, 116,
				121, 46, 85, 116, 105, 108, 105, 116, 121, 83,
				99, 114, 105, 112, 116, 115, 124, 84, 111, 110,
				101, 65, 117, 100, 105, 111, 82, 101, 97, 100,
				101, 114, 0, 0, 0, 0, 33, 80, 104, 111,
				116, 111, 110, 46, 86, 111, 105, 99, 101, 46,
				85, 110, 105, 116, 121, 124, 86, 111, 105, 99,
				101, 67, 111, 109, 112, 111, 110, 101, 110, 116,
				0, 0, 0, 0, 34, 80, 104, 111, 116, 111,
				110, 46, 86, 111, 105, 99, 101, 46, 85, 110,
				105, 116, 121, 124, 86, 111, 105, 99, 101, 67,
				111, 110, 110, 101, 99, 116, 105, 111, 110, 0,
				0, 0, 0, 34, 80, 104, 111, 116, 111, 110,
				46, 86, 111, 105, 99, 101, 124, 76, 111, 97,
				100, 66, 97, 108, 97, 110, 99, 105, 110, 103,
				70, 114, 111, 110, 116, 101, 110, 100, 0, 0,
				0, 0, 30, 80, 104, 111, 116, 111, 110, 46,
				86, 111, 105, 99, 101, 46, 85, 110, 105, 116,
				121, 124, 86, 111, 105, 99, 101, 76, 111, 103,
				103, 101, 114, 0, 0, 0, 0, 33, 80, 104,
				111, 116, 111, 110, 46, 86, 111, 105, 99, 101,
				46, 85, 110, 105, 116, 121, 124, 87, 101, 98,
				82, 116, 99, 65, 117, 100, 105, 111, 68, 115,
				112
			},
			TotalFiles = 32,
			TotalTypes = 38,
			IsEditorOnly = false
		};
	}
}
namespace CSCore
{
	public enum AudioEncoding : short
	{
		Unknown = 0,
		Pcm = 1,
		Adpcm = 2,
		IeeeFloat = 3,
		Vselp = 4,
		IbmCvsd = 5,
		ALaw = 6,
		MuLaw = 7,
		Dts = 8,
		Drm = 9,
		WmaVoice9 = 10,
		OkiAdpcm = 16,
		DviAdpcm = 17,
		ImaAdpcm = 17,
		MediaspaceAdpcm = 18,
		SierraAdpcm = 19,
		G723Adpcm = 20,
		DigiStd = 21,
		DigiFix = 22,
		DialogicOkiAdpcm = 23,
		MediaVisionAdpcm = 24,
		CUCodec = 25,
		YamahaAdpcm = 32,
		SonarC = 33,
		DspGroupTrueSpeech = 34,
		EchoSpeechCorporation1 = 35,
		AudioFileAf36 = 36,
		Aptx = 37,
		AudioFileAf10 = 38,
		Prosody1612 = 39,
		Lrc = 40,
		DolbyAc2 = 48,
		Gsm610 = 49,
		MsnAudio = 50,
		AntexAdpcme = 51,
		ControlResVqlpc = 52,
		DigiReal = 53,
		DigiAdpcm = 54,
		ControlResCr10 = 55,
		WAVE_FORMAT_NMS_VBXADPCM = 56,
		WAVE_FORMAT_CS_IMAADPCM = 57,
		WAVE_FORMAT_ECHOSC3 = 58,
		WAVE_FORMAT_ROCKWELL_ADPCM = 59,
		WAVE_FORMAT_ROCKWELL_DIGITALK = 60,
		WAVE_FORMAT_XEBEC = 61,
		WAVE_FORMAT_G721_ADPCM = 64,
		WAVE_FORMAT_G728_CELP = 65,
		WAVE_FORMAT_MSG723 = 66,
		Mpeg = 80,
		WAVE_FORMAT_RT24 = 82,
		WAVE_FORMAT_PAC = 83,
		MpegLayer3 = 85,
		WAVE_FORMAT_LUCENT_G723 = 89,
		WAVE_FORMAT_CIRRUS = 96,
		WAVE_FORMAT_ESPCM = 97,
		WAVE_FORMAT_VOXWARE = 98,
		WAVE_FORMAT_CANOPUS_ATRAC = 99,
		WAVE_FORMAT_G726_ADPCM = 100,
		WAVE_FORMAT_G722_ADPCM = 101,
		WAVE_FORMAT_DSAT_DISPLAY = 103,
		WAVE_FORMAT_VOXWARE_BYTE_ALIGNED = 105,
		WAVE_FORMAT_VOXWARE_AC8 = 112,
		WAVE_FORMAT_VOXWARE_AC10 = 113,
		WAVE_FORMAT_VOXWARE_AC16 = 114,
		WAVE_FORMAT_VOXWARE_AC20 = 115,
		WAVE_FORMAT_VOXWARE_RT24 = 116,
		WAVE_FORMAT_VOXWARE_RT29 = 117,
		WAVE_FORMAT_VOXWARE_RT29HW = 118,
		WAVE_FORMAT_VOXWARE_VR12 = 119,
		WAVE_FORMAT_VOXWARE_VR18 = 120,
		WAVE_FORMAT_VOXWARE_TQ40 = 121,
		WAVE_FORMAT_SOFTSOUND = 128,
		WAVE_FORMAT_VOXWARE_TQ60 = 129,
		WAVE_FORMAT_MSRT24 = 130,
		WAVE_FORMAT_G729A = 131,
		WAVE_FORMAT_MVI_MVI2 = 132,
		WAVE_FORMAT_DF_G726 = 133,
		WAVE_FORMAT_DF_GSM610 = 134,
		WAVE_FORMAT_ISIAUDIO = 136,
		WAVE_FORMAT_ONLIVE = 137,
		WAVE_FORMAT_SBC24 = 145,
		WAVE_FORMAT_DOLBY_AC3_SPDIF = 146,
		WAVE_FORMAT_MEDIASONIC_G723 = 147,
		WAVE_FORMAT_PROSODY_8KBPS = 148,
		WAVE_FORMAT_ZYXEL_ADPCM = 151,
		WAVE_FORMAT_PHILIPS_LPCBB = 152,
		WAVE_FORMAT_PACKED = 153,
		WAVE_FORMAT_MALDEN_PHONYTALK = 160,
		Gsm = 161,
		G729 = 162,
		G723 = 163,
		Acelp = 164,
		RawAac = 255,
		WAVE_FORMAT_RHETOREX_ADPCM = 256,
		WAVE_FORMAT_IRAT = 257,
		WAVE_FORMAT_VIVO_G723 = 273,
		WAVE_FORMAT_VIVO_SIREN = 274,
		WAVE_FORMAT_DIGITAL_G723 = 291,
		WAVE_FORMAT_SANYO_LD_ADPCM = 293,
		WAVE_FORMAT_SIPROLAB_ACEPLNET = 304,
		WAVE_FORMAT_SIPROLAB_ACELP4800 = 305,
		WAVE_FORMAT_SIPROLAB_ACELP8V3 = 306,
		WAVE_FORMAT_SIPROLAB_G729 = 307,
		WAVE_FORMAT_SIPROLAB_G729A = 308,
		WAVE_FORMAT_SIPROLAB_KELVIN = 309,
		WAVE_FORMAT_G726ADPCM = 320,
		WAVE_FORMAT_QUALCOMM_PUREVOICE = 336,
		WAVE_FORMAT_QUALCOMM_HALFRATE = 337,
		WAVE_FORMAT_TUBGSM = 341,
		WAVE_FORMAT_MSAUDIO1 = 352,
		WindowsMediaAudio = 353,
		WindowsMediaAudioProfessional = 354,
		WindowsMediaAudioLosseless = 355,
		WindowsMediaAudioSpdif = 356,
		WAVE_FORMAT_UNISYS_NAP_ADPCM = 368,
		WAVE_FORMAT_UNISYS_NAP_ULAW = 369,
		WAVE_FORMAT_UNISYS_NAP_ALAW = 370,
		WAVE_FORMAT_UNISYS_NAP_16K = 371,
		WAVE_FORMAT_CREATIVE_ADPCM = 512,
		WAVE_FORMAT_CREATIVE_FASTSPEECH8 = 514,
		WAVE_FORMAT_CREATIVE_FASTSPEECH10 = 515,
		WAVE_FORMAT_UHER_ADPCM = 528,
		WAVE_FORMAT_QUARTERDECK = 544,
		WAVE_FORMAT_ILINK_VC = 560,
		WAVE_FORMAT_RAW_SPORT = 576,
		WAVE_FORMAT_ESST_AC3 = 577,
		WAVE_FORMAT_IPI_HSX = 592,
		WAVE_FORMAT_IPI_RPELP = 593,
		WAVE_FORMAT_CS2 = 608,
		WAVE_FORMAT_SONY_SCX = 624,
		WAVE_FORMAT_FM_TOWNS_SND = 768,
		WAVE_FORMAT_BTV_DIGITAL = 1024,
		WAVE_FORMAT_QDESIGN_MUSIC = 1104,
		WAVE_FORMAT_VME_VMPCM = 1664,
		WAVE_FORMAT_TPC = 1665,
		WAVE_FORMAT_OLIGSM = 4096,
		WAVE_FORMAT_OLIADPCM = 4097,
		WAVE_FORMAT_OLICELP = 4098,
		WAVE_FORMAT_OLISBC = 4099,
		WAVE_FORMAT_OLIOPR = 4100,
		WAVE_FORMAT_LH_CODEC = 4352,
		WAVE_FORMAT_NORRIS = 5120,
		WAVE_FORMAT_SOUNDSPACE_MUSICOMPRESS = 5376,
		MPEG_ADTS_AAC = 5632,
		MPEG_RAW_AAC = 5633,
		MPEG_LOAS = 5634,
		NOKIA_MPEG_ADTS_AAC = 5640,
		NOKIA_MPEG_RAW_AAC = 5641,
		VODAFONE_MPEG_ADTS_AAC = 5642,
		VODAFONE_MPEG_RAW_AAC = 5643,
		MPEG_HEAAC = 5648,
		WAVE_FORMAT_DVM = 8192,
		Vorbis1 = 26447,
		Vorbis2 = 26448,
		Vorbis3 = 26449,
		Vorbis1P = 26479,
		Vorbis2P = 26480,
		Vorbis3P = 26481,
		WAVE_FORMAT_RAW_AAC1 = 255,
		WAVE_FORMAT_WMAVOICE9 = 10,
		Extensible = -2,
		WAVE_FORMAT_DEVELOPMENT = -1,
		WAVE_FORMAT_FLAC = -3668
	}
	public static class AudioSubTypes
	{
		public static readonly Guid MediaTypeAudio = new Guid("73647561-0000-0010-8000-00AA00389B71");

		public static readonly Guid Unknown = new Guid(0, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Pcm = new Guid(1, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Adpcm = new Guid(2, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid IeeeFloat = new Guid(3, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Vselp = new Guid(4, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid IbmCvsd = new Guid(5, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid ALaw = new Guid(6, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid MuLaw = new Guid(7, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Dts = new Guid(8, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Drm = new Guid(9, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WmaVoice9 = new Guid(10, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid OkiAdpcm = new Guid(16, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid DviAdpcm = new Guid(17, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid ImaAdpcm = new Guid(17, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid MediaspaceAdpcm = new Guid(18, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid SierraAdpcm = new Guid(19, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid G723Adpcm = new Guid(20, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid DigiStd = new Guid(21, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid DigiFix = new Guid(22, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid DialogicOkiAdpcm = new Guid(23, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid MediaVisionAdpcm = new Guid(24, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid CUCodec = new Guid(25, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid YamahaAdpcm = new Guid(32, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid SonarC = new Guid(33, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid DspGroupTrueSpeech = new Guid(34, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid EchoSpeechCorporation1 = new Guid(35, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid AudioFileAf36 = new Guid(36, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Aptx = new Guid(37, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid AudioFileAf10 = new Guid(38, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Prosody1612 = new Guid(39, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Lrc = new Guid(40, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid DolbyAc2 = new Guid(48, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Gsm610 = new Guid(49, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid MsnAudio = new Guid(50, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid AntexAdpcme = new Guid(51, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid ControlResVqlpc = new Guid(52, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid DigiReal = new Guid(53, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid DigiAdpcm = new Guid(54, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid ControlResCr10 = new Guid(55, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_NMS_VBXADPCM = new Guid(56, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_CS_IMAADPCM = new Guid(57, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_ECHOSC3 = new Guid(58, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_ROCKWELL_ADPCM = new Guid(59, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_ROCKWELL_DIGITALK = new Guid(60, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_XEBEC = new Guid(61, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_G721_ADPCM = new Guid(64, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_G728_CELP = new Guid(65, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_MSG723 = new Guid(66, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Mpeg = new Guid(80, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_RT24 = new Guid(82, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_PAC = new Guid(83, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid MpegLayer3 = new Guid(85, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_LUCENT_G723 = new Guid(89, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_CIRRUS = new Guid(96, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_ESPCM = new Guid(97, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VOXWARE = new Guid(98, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_CANOPUS_ATRAC = new Guid(99, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_G726_ADPCM = new Guid(100, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_G722_ADPCM = new Guid(101, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_DSAT_DISPLAY = new Guid(103, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VOXWARE_BYTE_ALIGNED = new Guid(105, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VOXWARE_AC8 = new Guid(112, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VOXWARE_AC10 = new Guid(113, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VOXWARE_AC16 = new Guid(114, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VOXWARE_AC20 = new Guid(115, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VOXWARE_RT24 = new Guid(116, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VOXWARE_RT29 = new Guid(117, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VOXWARE_RT29HW = new Guid(118, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VOXWARE_VR12 = new Guid(119, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VOXWARE_VR18 = new Guid(120, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VOXWARE_TQ40 = new Guid(121, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_SOFTSOUND = new Guid(128, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VOXWARE_TQ60 = new Guid(129, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_MSRT24 = new Guid(130, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_G729A = new Guid(131, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_MVI_MVI2 = new Guid(132, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_DF_G726 = new Guid(133, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_DF_GSM610 = new Guid(134, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_ISIAUDIO = new Guid(136, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_ONLIVE = new Guid(137, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_SBC24 = new Guid(145, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_DOLBY_AC3_SPDIF = new Guid(146, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_MEDIASONIC_G723 = new Guid(147, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_PROSODY_8KBPS = new Guid(148, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_ZYXEL_ADPCM = new Guid(151, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_PHILIPS_LPCBB = new Guid(152, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_PACKED = new Guid(153, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_MALDEN_PHONYTALK = new Guid(160, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Gsm = new Guid(161, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid G729 = new Guid(162, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid G723 = new Guid(163, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Acelp = new Guid(164, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid RawAac = new Guid(255, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_RHETOREX_ADPCM = new Guid(256, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_IRAT = new Guid(257, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VIVO_G723 = new Guid(273, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VIVO_SIREN = new Guid(274, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_DIGITAL_G723 = new Guid(291, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_SANYO_LD_ADPCM = new Guid(293, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_SIPROLAB_ACEPLNET = new Guid(304, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_SIPROLAB_ACELP4800 = new Guid(305, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_SIPROLAB_ACELP8V3 = new Guid(306, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_SIPROLAB_G729 = new Guid(307, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_SIPROLAB_G729A = new Guid(308, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_SIPROLAB_KELVIN = new Guid(309, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_G726ADPCM = new Guid(320, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_QUALCOMM_PUREVOICE = new Guid(336, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_QUALCOMM_HALFRATE = new Guid(337, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_TUBGSM = new Guid(341, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_MSAUDIO1 = new Guid(352, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WindowsMediaAudio = new Guid(353, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WindowsMediaAudioProfessional = new Guid(354, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WindowsMediaAudioLosseless = new Guid(355, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WindowsMediaAudioSpdif = new Guid(356, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_UNISYS_NAP_ADPCM = new Guid(368, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_UNISYS_NAP_ULAW = new Guid(369, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_UNISYS_NAP_ALAW = new Guid(370, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_UNISYS_NAP_16K = new Guid(371, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_CREATIVE_ADPCM = new Guid(512, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_CREATIVE_FASTSPEECH8 = new Guid(514, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_CREATIVE_FASTSPEECH10 = new Guid(515, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_UHER_ADPCM = new Guid(528, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_QUARTERDECK = new Guid(544, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_ILINK_VC = new Guid(560, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_RAW_SPORT = new Guid(576, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_ESST_AC3 = new Guid(577, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_IPI_HSX = new Guid(592, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_IPI_RPELP = new Guid(593, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_CS2 = new Guid(608, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_SONY_SCX = new Guid(624, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_FM_TOWNS_SND = new Guid(768, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_BTV_DIGITAL = new Guid(1024, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_QDESIGN_MUSIC = new Guid(1104, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_VME_VMPCM = new Guid(1664, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_TPC = new Guid(1665, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_OLIGSM = new Guid(4096, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_OLIADPCM = new Guid(4097, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_OLICELP = new Guid(4098, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_OLISBC = new Guid(4099, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_OLIOPR = new Guid(4100, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_LH_CODEC = new Guid(4352, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_NORRIS = new Guid(5120, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_SOUNDSPACE_MUSICOMPRESS = new Guid(5376, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid MPEG_ADTS_AAC = new Guid(5632, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid MPEG_RAW_AAC = new Guid(5633, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid MPEG_LOAS = new Guid(5634, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid NOKIA_MPEG_ADTS_AAC = new Guid(5640, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid NOKIA_MPEG_RAW_AAC = new Guid(5641, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid VODAFONE_MPEG_ADTS_AAC = new Guid(5642, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid VODAFONE_MPEG_RAW_AAC = new Guid(5643, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid MPEG_HEAAC = new Guid(5648, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_DVM = new Guid(8192, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Vorbis1 = new Guid(26447, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Vorbis2 = new Guid(26448, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Vorbis3 = new Guid(26449, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Vorbis1P = new Guid(26479, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Vorbis2P = new Guid(26480, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Vorbis3P = new Guid(26481, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_RAW_AAC1 = new Guid(255, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_WMAVOICE9 = new Guid(10, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid Extensible = new Guid(65534, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_DEVELOPMENT = new Guid(65535, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static readonly Guid WAVE_FORMAT_FLAC = new Guid(61868, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);

		public static AudioEncoding EncodingFromSubType(Guid audioSubType)
		{
			int num = BitConverter.ToInt32(audioSubType.ToByteArray(), 0);
			if (Enum.IsDefined(typeof(AudioEncoding), (short)num))
			{
				return (AudioEncoding)num;
			}
			throw new ArgumentException("Invalid audioSubType.", "audioSubType");
		}

		public static Guid SubTypeFromEncoding(AudioEncoding audioEncoding)
		{
			if (Enum.IsDefined(typeof(AudioEncoding), (short)audioEncoding))
			{
				return new Guid((int)audioEncoding, 0, 16, 128, 0, 0, 170, 0, 56, 155, 113);
			}
			throw new ArgumentException("Invalid encoding.", "audioEncoding");
		}
	}
	[Flags]
	public enum ChannelMask
	{
		SpeakerFrontLeft = 1,
		SpeakerFrontRight = 2,
		SpeakerFrontCenter = 4,
		SpeakerLowFrequency = 8,
		SpeakerBackLeft = 0x10,
		SpeakerBackRight = 0x20,
		SpeakerFrontLeftOfCenter = 0x40,
		SpeakerFrontRightOfCenter = 0x80,
		SpeakerBackCenter = 0x100,
		SpeakerSideLeft = 0x200,
		SpeakerSideRight = 0x400,
		SpeakerTopCenter = 0x800,
		SpeakerTopFrontLeft = 0x1000,
		SpeakerTopFrontCenter = 0x2000,
		SpeakerTopFrontRight = 0x4000,
		SpeakerTopBackLeft = 0x8000,
		SpeakerTopBackCenter = 0x10000,
		SpeakerTopBackRight = 0x20000
	}
	public static class Extensions
	{
		internal static bool IsPCM(this WaveFormat waveFormat)
		{
			if (waveFormat == null)
			{
				throw new ArgumentNullException("waveFormat");
			}
			if (waveFormat is WaveFormatExtensible)
			{
				return ((WaveFormatExtensible)waveFormat).SubFormat == AudioSubTypes.Pcm;
			}
			return waveFormat.WaveFormatTag == AudioEncoding.Pcm;
		}

		internal static bool IsIeeeFloat(this WaveFormat waveFormat)
		{
			if (waveFormat == null)
			{
				throw new ArgumentNullException("waveFormat");
			}
			if (waveFormat is WaveFormatExtensible)
			{
				return ((WaveFormatExtensible)waveFormat).SubFormat == AudioSubTypes.IeeeFloat;
			}
			return waveFormat.WaveFormatTag == AudioEncoding.IeeeFloat;
		}
	}
	public interface IAudioSource : IDisposable
	{
		bool CanSeek { get; }

		WaveFormat WaveFormat { get; }

		long Position { get; set; }

		long Length { get; }
	}
	public interface IReadableAudioSource<in T> : IAudioSource, IDisposable
	{
		int Read(T[] buffer, int offset, int count);
	}
	public interface IWaveSource : IReadableAudioSource<byte>, IAudioSource, IDisposable
	{
	}
	public interface IWriteable
	{
		void Write(byte[] buffer, int offset, int count);
	}
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	public class WaveFormat : ICloneable, IEquatable<WaveFormat>
	{
		private AudioEncoding _encoding;

		private short _channels;

		private int _sampleRate;

		private int _bytesPerSecond;

		private short _blockAlign;

		private short _bitsPerSample;

		private short _extraSize;

		public virtual int Channels
		{
			get
			{
				return _channels;
			}
			protected internal set
			{
				_channels = (short)value;
				UpdateProperties();
			}
		}

		public virtual int SampleRate
		{
			get
			{
				return _sampleRate;
			}
			protected internal set
			{
				_sampleRate = value;
				UpdateProperties();
			}
		}

		public virtual int BytesPerSecond
		{
			get
			{
				return _bytesPerSecond;
			}
			protected internal set
			{
				_bytesPerSecond = value;
			}
		}

		public virtual int BlockAlign
		{
			get
			{
				return _blockAlign;
			}
			protected internal set
			{
				_blockAlign = (short)value;
			}
		}

		public virtual int BitsPerSample
		{
			get
			{
				return _bitsPerSample;
			}
			protected internal set
			{
				_bitsPerSample = (short)value;
				UpdateProperties();
			}
		}

		public virtual int ExtraSize
		{
			get
			{
				return _extraSize;
			}
			protected internal set
			{
				_extraSize = (short)value;
			}
		}

		public virtual int BytesPerSample => BitsPerSample / 8;

		public virtual int BytesPerBlock => BytesPerSample * Channels;

		public virtual AudioEncoding WaveFormatTag
		{
			get
			{
				return _encoding;
			}
			protected internal set
			{
				_encoding = value;
			}
		}

		public WaveFormat()
			: this(44100, 16, 2)
		{
		}

		public WaveFormat(int sampleRate, int bits, int channels)
			: this(sampleRate, bits, channels, AudioEncoding.Pcm)
		{
		}

		public WaveFormat(int sampleRate, int bits, int channels, AudioEncoding encoding)
			: this(sampleRate, bits, channels, encoding, 0)
		{
		}

		public WaveFormat(int sampleRate, int bits, int channels, AudioEncoding encoding, int extraSize)
		{
			if (sampleRate < 1)
			{
				throw new ArgumentOutOfRangeException("sampleRate");
			}
			if (bits < 0)
			{
				throw new ArgumentOutOfRangeException("bits");
			}
			if (channels < 1)
			{
				throw new ArgumentOutOfRangeException("channels", "Number of channels has to be bigger than 0.");
			}
			_sampleRate = sampleRate;
			_bitsPerSample = (short)bits;
			_channels = (short)channels;
			_encoding = encoding;
			_extraSize = (short)extraSize;
			UpdateProperties();
		}

		public long MillisecondsToBytes(double milliseconds)
		{
			long num = (long)((double)BytesPerSecond / 1000.0 * milliseconds);
			return num - num % BlockAlign;
		}

		public double BytesToMilliseconds(long bytes)
		{
			bytes -= bytes % BlockAlign;
			return (double)bytes / (double)BytesPerSecond * 1000.0;
		}

		public virtual bool Equals(WaveFormat other)
		{
			if (Channels == other.Channels && SampleRate == other.SampleRate && BytesPerSecond == other.BytesPerSecond && BlockAlign == other.BlockAlign && BitsPerSample == other.BitsPerSample && ExtraSize == other.ExtraSize)
			{
				return WaveFormatTag == other.WaveFormatTag;
			}
			return false;
		}

		public override string ToString()
		{
			return GetInformation().ToString();
		}

		public virtual object Clone()
		{
			return MemberwiseClone();
		}

		internal virtual void SetWaveFormatTagInternal(AudioEncoding waveFormatTag)
		{
			WaveFormatTag = waveFormatTag;
		}

		internal virtual void SetBitsPerSampleAndFormatProperties(int bitsPerSample)
		{
			BitsPerSample = bitsPerSample;
			UpdateProperties();
		}

		protected internal virtual void UpdateProperties()
		{
			BlockAlign = BitsPerSample / 8 * Channels;
			BytesPerSecond = BlockAlign * SampleRate;
		}

		[DebuggerStepThrough]
		private StringBuilder GetInformation()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("ChannelsAvailable: " + Channels);
			stringBuilder.Append("|SampleRate: " + SampleRate);
			stringBuilder.Append("|Bps: " + BytesPerSecond);
			stringBuilder.Append("|BlockAlign: " + BlockAlign);
			stringBuilder.Append("|BitsPerSample: " + BitsPerSample);
			stringBuilder.Append("|Encoding: " + _encoding);
			return stringBuilder;
		}
	}
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	public class WaveFormatExtensible : WaveFormat
	{
		internal const int WaveFormatExtensibleExtraSize = 22;

		private short _samplesUnion;

		private ChannelMask _channelMask;

		private Guid _subFormat;

		public int ValidBitsPerSample
		{
			get
			{
				return _samplesUnion;
			}
			protected internal set
			{
				_samplesUnion = (short)value;
			}
		}

		public int SamplesPerBlock
		{
			get
			{
				return _samplesUnion;
			}
			protected internal set
			{
				_samplesUnion = (short)value;
			}
		}

		public ChannelMask ChannelMask
		{
			get
			{
				return _channelMask;
			}
			protected internal set
			{
				_channelMask = value;
			}
		}

		public Guid SubFormat
		{
			get
			{
				return _subFormat;
			}
			protected internal set
			{
				_subFormat = value;
			}
		}

		public static Guid SubTypeFromWaveFormat(WaveFormat waveFormat)
		{
			if (waveFormat == null)
			{
				throw new ArgumentNullException("waveFormat");
			}
			if (waveFormat is WaveFormatExtensible)
			{
				return ((WaveFormatExtensible)waveFormat).SubFormat;
			}
			return AudioSubTypes.SubTypeFromEncoding(waveFormat.WaveFormatTag);
		}

		internal WaveFormatExtensible()
		{
		}

		public WaveFormatExtensible(int sampleRate, int bits, int channels, Guid subFormat)
			: base(sampleRate, bits, channels, AudioEncoding.Extensible, 22)
		{
			_samplesUnion = (short)bits;
			_subFormat = SubTypeFromWaveFormat(this);
			int num = 0;
			for (int i = 0; i < channels; i++)
			{
				num |= 1 << i;
			}
			_channelMask = (ChannelMask)num;
			_subFormat = subFormat;
		}

		public WaveFormatExtensible(int sampleRate, int bits, int channels, Guid subFormat, ChannelMask channelMask)
			: this(sampleRate, bits, channels, subFormat)
		{
			Array values = Enum.GetValues(typeof(ChannelMask));
			int num = 0;
			for (int i = 0; i < values.Length; i++)
			{
				if ((channelMask & (ChannelMask)values.GetValue(i)) == (ChannelMask)values.GetValue(i))
				{
					num++;
				}
			}
			if (channels != num)
			{
				throw new ArgumentException("Channels has to equal the set flags in the channelmask.");
			}
			_channelMask = channelMask;
		}

		public WaveFormat ToWaveFormat()
		{
			return new WaveFormat(SampleRate, BitsPerSample, Channels, AudioSubTypes.EncodingFromSubType(SubFormat));
		}

		public override object Clone()
		{
			return MemberwiseClone();
		}

		internal override void SetWaveFormatTagInternal(AudioEncoding waveFormatTag)
		{
			SubFormat = AudioSubTypes.SubTypeFromEncoding(waveFormatTag);
		}

		[DebuggerStepThrough]
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			stringBuilder.Append("|SubFormat: " + SubFormat.ToString());
			stringBuilder.Append("|ChannelMask: " + ChannelMask);
			return stringBuilder.ToString();
		}
	}
}
namespace CSCore.Codecs.WAV
{
	public class WaveWriter : IDisposable, IWriteable
	{
		private readonly WaveFormat _waveFormat;

		private readonly long _waveStartPosition;

		private int _dataLength;

		private bool _isDisposed;

		private Stream _stream;

		private BinaryWriter _writer;

		private bool _isDisposing;

		private readonly bool _closeStream;

		public bool IsDisposed => _isDisposed;

		public bool IsDisposing => _isDisposing;

		public WaveWriter(string fileName, WaveFormat waveFormat)
			: this(File.OpenWrite(fileName), waveFormat)
		{
			_closeStream = true;
		}

		public WaveWriter(Stream stream, WaveFormat waveFormat)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanWrite)
			{
				throw new ArgumentException("Stream not writeable.", "stream");
			}
			if (!stream.CanSeek)
			{
				throw new ArgumentException("Stream not seekable.", "stream");
			}
			_isDisposing = false;
			_isDisposed = false;
			_stream = stream;
			_waveStartPosition = stream.Position;
			_writer = new BinaryWriter(stream);
			for (int i = 0; i < 44; i++)
			{
				_writer.Write((byte)0);
			}
			_waveFormat = waveFormat;
			WriteHeader();
			_closeStream = false;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		[Obsolete("Use the Extensions.WriteToWaveStream extension instead.")]
		public static void WriteToFile(string filename, IWaveSource source, bool deleteFileIfAlreadyExists, int maxlength = -1)
		{
			if (deleteFileIfAlreadyExists && File.Exists(filename))
			{
				File.Delete(filename);
			}
			int num = 0;
			byte[] array = new byte[source.WaveFormat.BytesPerSecond];
			using WaveWriter waveWriter = new WaveWriter(filename, source.WaveFormat);
			int num2;
			while ((num2 = source.Read(array, 0, array.Length)) > 0)
			{
				waveWriter.Write(array, 0, num2);
				num += num2;
				if (maxlength != -1 && num > maxlength)
				{
					break;
				}
			}
		}

		public void WriteSample(float sample)
		{
			CheckObjectDisposed();
			if (sample < -1f || sample > 1f)
			{
				sample = Math.Max(-1f, Math.Min(1f, sample));
			}
			if (_waveFormat.IsPCM())
			{
				switch (_waveFormat.BitsPerSample)
				{
				case 8:
					Write((byte)(255f * sample));
					break;
				case 16:
					Write((short)(32767f * sample));
					break;
				case 24:
				{
					byte[] bytes = BitConverter.GetBytes((int)(8388607f * sample));
					Write(new byte[3]
					{
						bytes[0],
						bytes[1],
						bytes[2]
					}, 0, 3);
					break;
				}
				case 32:
					Write((int)(2.1474836E+09f * sample));
					break;
				default:
					throw new InvalidOperationException("Invalid Waveformat", new InvalidOperationException("Invalid BitsPerSample while using PCM encoding."));
				}
			}
			else if (_waveFormat.IsIeeeFloat())
			{
				Write(sample);
			}
			else
			{
				if (_waveFormat.WaveFormatTag != AudioEncoding.Extensible || _waveFormat.BitsPerSample != 32)
				{
					throw new InvalidOperationException("Invalid Waveformat: Waveformat has to be PCM[8, 16, 24, 32] or IeeeFloat[32]");
				}
				Write(65535 * (int)sample);
			}
		}

		public void WriteSamples(float[] samples, int offset, int count)
		{
			CheckObjectDisposed();
			for (int i = offset; i < offset + count; i++)
			{
				WriteSample(samples[i]);
			}
		}

		public void Write(byte[] buffer, int offset, int count)
		{
			CheckObjectDisposed();
			_stream.Write(buffer, offset, count);
			_dataLength += count;
		}

		public void Write(byte value)
		{
			CheckObjectDisposed();
			_writer.Write(value);
			_dataLength++;
		}

		public void Write(short value)
		{
			CheckObjectDisposed();
			_writer.Write(value);
			_dataLength += 2;
		}

		public void Write(int value)
		{
			CheckObjectDisposed();
			_writer.Write(value);
			_dataLength += 4;
		}

		public void Write(float value)
		{
			CheckObjectDisposed();
			_writer.Write(value);
			_dataLength += 4;
		}

		private void WriteHeader()
		{
			_writer.Flush();
			long position = _stream.Position;
			_stream.Position = _waveStartPosition;
			WriteRiffHeader();
			WriteFmtChunk();
			WriteDataChunk();
			_writer.Flush();
			_stream.Position = position;
		}

		private void WriteRiffHeader()
		{
			_writer.Write(Encoding.UTF8.GetBytes("RIFF"));
			_writer.Write((int)(_stream.Length - 8));
			_writer.Write(Encoding.UTF8.GetBytes("WAVE"));
		}

		private void WriteFmtChunk()
		{
			AudioEncoding audioEncoding = _waveFormat.WaveFormatTag;
			if (audioEncoding == AudioEncoding.Extensible && _waveFormat is WaveFormatExtensible)
			{
				audioEncoding = AudioSubTypes.EncodingFromSubType((_waveFormat as WaveFormatExtensible).SubFormat);
			}
			_writer.Write(Encoding.UTF8.GetBytes("fmt "));
			_writer.Write(16);
			_writer.Write((short)audioEncoding);
			_writer.Write((short)_waveFormat.Channels);
			_writer.Write(_waveFormat.SampleRate);
			_writer.Write(_waveFormat.BytesPerSecond);
			_writer.Write((short)_waveFormat.BlockAlign);
			_writer.Write((short)_waveFormat.BitsPerSample);
		}

		private void WriteDataChunk()
		{
			_writer.Write(Encoding.UTF8.GetBytes("data"));
			_writer.Write(_dataLength);
		}

		private void CheckObjectDisposed()
		{
			if (_isDisposed)
			{
				throw new ObjectDisposedException("WaveWriter");
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_isDisposed || !disposing)
			{
				return;
			}
			try
			{
				_isDisposing = true;
				WriteHeader();
			}
			catch (Exception)
			{
			}
			finally
			{
				if (_closeStream)
				{
					if (_writer != null)
					{
						_writer.Close();
						_writer = null;
					}
					if (_stream != null)
					{
						_stream.Dispose();
						_stream = null;
					}
				}
				_isDisposing = false;
			}
			_isDisposed = true;
		}

		~WaveWriter()
		{
			Dispose(disposing: false);
		}
	}
}
namespace Photon.Voice
{
	[Obsolete("Class renamed. Use LoadBalancingTransport instead.")]
	public class LoadBalancingFrontend : LoadBalancingTransport
	{
	}
}
namespace Photon.Voice.Unity
{
	[RequireComponent(typeof(Recorder))]
	public class AudioChangesHandler : VoiceComponent
	{
		private IAudioInChangeNotifier photonMicChangeNotifier;

		private AudioConfiguration audioConfiguration;

		private Recorder recorder;

		[Tooltip("Try to start recording when we get devices change notification and recording is not started.")]
		public bool StartWhenDeviceChange = true;

		[Tooltip("Try to react to device change notification when Recorder is started.")]
		public bool HandleDeviceChange = true;

		[Tooltip("Try to react to audio config change notification when Recorder is started.")]
		public bool HandleConfigChange = true;

		[Tooltip("Whether or not to make use of Photon's AudioInChangeNotifier native plugin.")]
		public bool UseNativePluginChangeNotifier = true;

		[Tooltip("Whether or not to make use of Unity's OnAudioConfigurationChanged.")]
		public bool UseOnAudioConfigurationChanged = true;

		private bool subscribedToSystemChangesPhoton;

		private bool subscribedToSystemChangesUnity;

		protected override void Awake()
		{
			base.Awake();
			recorder = GetComponent<Recorder>();
			recorder.ReactOnSystemChanges = false;
			audioConfiguration = AudioSettings.GetConfiguration();
			SubscribeToSystemChanges();
		}

		private void OnDestroy()
		{
			UnsubscribeFromSystemChanges();
		}

		private void OnDeviceChange()
		{
			if (!recorder.IsRecording)
			{
				if (StartWhenDeviceChange)
				{
					recorder.MicrophoneDeviceChangeDetected = true;
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("An attempt to auto start recording should follow shortly.");
					}
				}
				else if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Device change detected but will not try to start recording as StartWhenDeviceChange is false.");
				}
			}
			else if (HandleDeviceChange)
			{
				recorder.MicrophoneDeviceChangeDetected = true;
			}
			else if (base.Logger.IsInfoEnabled)
			{
				base.Logger.LogInfo("Device change detected but will not try to handle this as HandleDeviceChange is false.");
			}
		}

		private void SubscribeToSystemChanges()
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("Subscribing to system (audio) changes.");
			}
			if (base.Logger.IsInfoEnabled)
			{
				base.Logger.LogInfo("Skipped subscribing to audio change notifications via Photon's AudioInChangeNotifier as not supported on current platform: {0}", VoiceComponent.CurrentPlatform);
			}
			if (subscribedToSystemChangesPhoton && base.Logger.IsErrorEnabled)
			{
				base.Logger.LogError("Unexpected: subscribedToSystemChangesPhoton is set to true while platform is not supported!.");
			}
			if (subscribedToSystemChangesUnity)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Already subscribed to audio changes via Unity OnAudioConfigurationChanged callback.");
				}
				return;
			}
			AudioSettings.OnAudioConfigurationChanged += OnAudioConfigChanged;
			subscribedToSystemChangesUnity = true;
			if (base.Logger.IsInfoEnabled)
			{
				base.Logger.LogInfo("Subscribed to audio configuration changes via Unity OnAudioConfigurationChanged callback.");
			}
		}

		private void OnAudioConfigChanged(bool deviceWasChanged)
		{
			if (base.Logger.IsInfoEnabled)
			{
				base.Logger.LogInfo("OnAudioConfigurationChanged: {0}", deviceWasChanged ? "Device was changed." : "AudioSettings.Reset was called.");
			}
			AudioConfiguration configuration = AudioSettings.GetConfiguration();
			bool flag = false;
			if (configuration.dspBufferSize != audioConfiguration.dspBufferSize)
			{
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("OnAudioConfigurationChanged: dspBufferSize old={0} new={1}", audioConfiguration.dspBufferSize, configuration.dspBufferSize);
				}
				flag = true;
			}
			if (configuration.numRealVoices != audioConfiguration.numRealVoices)
			{
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("OnAudioConfigurationChanged: numRealVoices old={0} new={1}", audioConfiguration.numRealVoices, configuration.numRealVoices);
				}
				flag = true;
			}
			if (configuration.numVirtualVoices != audioConfiguration.numVirtualVoices)
			{
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("OnAudioConfigurationChanged: numVirtualVoices old={0} new={1}", audioConfiguration.numVirtualVoices, configuration.numVirtualVoices);
				}
				flag = true;
			}
			if (configuration.sampleRate != audioConfiguration.sampleRate)
			{
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("OnAudioConfigurationChanged: sampleRate old={0} new={1}", audioConfiguration.sampleRate, configuration.sampleRate);
				}
				flag = true;
			}
			if (configuration.speakerMode != audioConfiguration.speakerMode)
			{
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("OnAudioConfigurationChanged: speakerMode old={0} new={1}", audioConfiguration.speakerMode, configuration.speakerMode);
				}
				flag = true;
			}
			if (flag)
			{
				audioConfiguration = configuration;
			}
			if (recorder.MicrophoneDeviceChangeDetected)
			{
				return;
			}
			if (flag)
			{
				if (recorder.IsRecording)
				{
					if (HandleConfigChange)
					{
						if (base.Logger.IsInfoEnabled)
						{
							base.Logger.LogInfo("Config change detected; an attempt to auto start recording should follow shortly.");
						}
						recorder.MicrophoneDeviceChangeDetected = true;
					}
					else if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("Config change detected but will not try to handle this as HandleConfigChange is false.");
					}
				}
				else if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Config change detected but ignored as recording not started.");
				}
			}
			else if (deviceWasChanged)
			{
				if (UseOnAudioConfigurationChanged)
				{
					OnDeviceChange();
				}
				else if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Device change detected but will not try to handle this as UseOnAudioConfigurationChanged is false.");
				}
			}
		}

		private void UnsubscribeFromSystemChanges()
		{
			if (subscribedToSystemChangesUnity)
			{
				AudioSettings.OnAudioConfigurationChanged -= OnAudioConfigChanged;
				subscribedToSystemChangesUnity = false;
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Unsubscribed from audio changes via Unity OnAudioConfigurationChanged callback.");
				}
			}
			if (!subscribedToSystemChangesPhoton)
			{
				return;
			}
			if (photonMicChangeNotifier == null)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Unexpected: photonMicChangeNotifier is null while subscribedToSystemChangesPhoton is true.");
				}
			}
			else
			{
				photonMicChangeNotifier.Dispose();
				photonMicChangeNotifier = null;
			}
			subscribedToSystemChangesPhoton = false;
			if (base.Logger.IsInfoEnabled)
			{
				base.Logger.LogInfo("Unsubscribed from audio in change notifications via Photon plugin.");
			}
		}
	}
	public static class AudioInEnumeratorEx
	{
		public static bool IDIsValid(this IDeviceEnumerator en, int id)
		{
			return en.Any((DeviceInfo d) => d.IDInt == id);
		}

		public static string NameAtIndex(this IDeviceEnumerator en, int index)
		{
			return en.ElementAtOrDefault(index).Name;
		}

		public static int IDAtIndex(this IDeviceEnumerator en, int index)
		{
			if (index >= 0 && index < en.Count())
			{
				return en.ElementAt(index).IDInt;
			}
			return -1;
		}
	}
	public interface ILoggable
	{
		DebugLevel LogLevel { get; set; }

		VoiceLogger Logger { get; }
	}
	public interface ILoggableDependent : ILoggable
	{
		bool IgnoreGlobalLogLevel { get; set; }
	}
	[Serializable]
	public struct NativeAndroidMicrophoneSettings
	{
		public bool AcousticEchoCancellation;

		public bool AutomaticGainControl;

		public bool NoiseSuppression;
	}
	[Serializable]
	public struct PlaybackDelaySettings
	{
		public const int DEFAULT_LOW = 200;

		public const int DEFAULT_HIGH = 400;

		public const int DEFAULT_MAX = 1000;

		public int MinDelaySoft;

		public int MaxDelaySoft;

		public int MaxDelayHard;

		public override string ToString()
		{
			return $"[low={MinDelaySoft}ms,high={MaxDelaySoft}ms,max={MaxDelayHard}ms]";
		}
	}
	[AddComponentMenu("Photon Voice/Recorder")]
	[HelpURL("https://doc.photonengine.com/en-us/voice/v2/getting-started/recorder")]
	[DisallowMultipleComponent]
	public class Recorder : VoiceComponent
	{
		public enum InputSourceType
		{
			Microphone,
			AudioClip,
			Factory
		}

		public enum MicType
		{
			Unity,
			Photon
		}

		[Obsolete("No longer needed. Implicit conversion is done internally when needed.")]
		public enum SampleTypeConv
		{
			None,
			Short
		}

		[Obsolete("Use Photon.Voice.Unity.PhotonVoiceCreatedParams")]
		public class PhotonVoiceCreatedParams : Photon.Voice.Unity.PhotonVoiceCreatedParams
		{
		}

		public const int MIN_OPUS_BITRATE = 6000;

		public const int MAX_OPUS_BITRATE = 510000;

		private static readonly Array samplingRateValues = Enum.GetValues(typeof(SamplingRate));

		[SerializeField]
		private bool voiceDetection;

		[SerializeField]
		private float voiceDetectionThreshold = 0.01f;

		[SerializeField]
		private int voiceDetectionDelayMs = 500;

		private object userData;

		private LocalVoice voice = LocalVoiceAudioDummy.Dummy;

		private string unityMicrophoneDevice;

		private int photonMicrophoneDeviceId = -1;

		private IAudioDesc inputSource;

		private VoiceClient client;

		private VoiceConnection voiceConnection;

		[SerializeField]
		[FormerlySerializedAs("audioGroup")]
		private byte interestGroup;

		[SerializeField]
		private bool debugEchoMode;

		[SerializeField]
		private bool reliableMode;

		[SerializeField]
		private bool encrypt;

		[SerializeField]
		private bool transmitEnabled;

		[SerializeField]
		private SamplingRate samplingRate = SamplingRate.Sampling24000;

		[SerializeField]
		private OpusCodec.FrameDuration frameDuration = OpusCodec.FrameDuration.Frame20ms;

		[SerializeField]
		[Range(6000f, 510000f)]
		private int bitrate = 30000;

		[SerializeField]
		private InputSourceType sourceType;

		[SerializeField]
		private MicType microphoneType;

		[SerializeField]
		private AudioClip audioClip;

		[SerializeField]
		private bool loopAudioClip = true;

		private bool isRecording;

		private Func<IAudioDesc> inputFactory;

		[Obsolete]
		private static IDeviceEnumerator photonMicrophoneEnumerator;

		private IAudioInChangeNotifier photonMicChangeNotifier;

		[SerializeField]
		private bool reactOnSystemChanges;

		private bool subscribedToSystemChangesPhoton;

		private bool subscribedToSystemChangesUnity;

		[SerializeField]
		private bool autoStart = true;

		[SerializeField]
		private bool recordOnlyWhenEnabled;

		[SerializeField]
		private bool skipDeviceChangeChecks;

		private bool wasRecordingBeforePause;

		private bool isPausedOrInBackground;

		[SerializeField]
		private bool stopRecordingWhenPaused;

		[SerializeField]
		private bool useOnAudioFilterRead;

		[SerializeField]
		private bool trySamplingRateMatch;

		[SerializeField]
		private bool useMicrophoneTypeFallback = true;

		[SerializeField]
		private bool recordOnlyWhenJoined = true;

		private bool recordingStoppedExplicitly;

		private IDeviceEnumerator photonMicrophonesEnumerator;

		private AudioInEnumerator unityMicrophonesEnumerator;

		private object microphoneDeviceChangeDetectedLock = new object();

		internal bool microphoneDeviceChangeDetected;

		public LocalVoice Voice => voice;

		public IAudioDesc InputSource => inputSource;

		internal bool MicrophoneDeviceChangeDetected
		{
			get
			{
				lock (microphoneDeviceChangeDetectedLock)
				{
					return microphoneDeviceChangeDetected;
				}
			}
			set
			{
				lock (microphoneDeviceChangeDetectedLock)
				{
					if (microphoneDeviceChangeDetected == value)
					{
						if (base.Logger.IsWarningEnabled)
						{
							base.Logger.LogWarning("Unexpected: MicrophoneDeviceChangeDetected to be overriden with same value: {0}", value);
						}
					}
					else
					{
						microphoneDeviceChangeDetected = value;
					}
				}
			}
		}

		private bool subscribedToSystemChanges
		{
			get
			{
				if (!subscribedToSystemChangesUnity)
				{
					return subscribedToSystemChangesPhoton;
				}
				return true;
			}
		}

		[Obsolete("Use the generic unified non-static MicrophonesEnumerator")]
		public static IDeviceEnumerator PhotonMicrophoneEnumerator
		{
			get
			{
				if (photonMicrophoneEnumerator == null)
				{
					photonMicrophoneEnumerator = CreatePhotonDeviceEnumerator(new VoiceLogger("PhotonMicrophoneEnumerator"));
				}
				return photonMicrophoneEnumerator;
			}
		}

		public bool IsInitialized => client != null;

		[Obsolete("Renamed to RequiresRestart")]
		public bool RequiresInit => RequiresRestart;

		public bool RequiresRestart { get; protected set; }

		public bool TransmitEnabled
		{
			get
			{
				return transmitEnabled;
			}
			set
			{
				if (value != transmitEnabled)
				{
					transmitEnabled = value;
					if (voice != LocalVoiceAudioDummy.Dummy)
					{
						voice.TransmitEnabled = value;
					}
				}
			}
		}

		public bool Encrypt
		{
			get
			{
				return encrypt;
			}
			set
			{
				if (encrypt != value)
				{
					encrypt = value;
					voice.Encrypt = value;
				}
			}
		}

		public bool DebugEchoMode
		{
			get
			{
				if (debugEchoMode && InterestGroup != 0)
				{
					voice.DebugEchoMode = false;
					debugEchoMode = false;
				}
				return debugEchoMode;
			}
			set
			{
				if (debugEchoMode == value)
				{
					return;
				}
				if (InterestGroup != 0)
				{
					if (base.Logger.IsWarningEnabled)
					{
						base.Logger.LogWarning("Cannot enable DebugEchoMode when InterestGroup value ({0}) is different than 0.", interestGroup);
					}
				}
				else
				{
					debugEchoMode = value;
					voice.DebugEchoMode = value;
				}
			}
		}

		public bool ReliableMode
		{
			get
			{
				return reliableMode;
			}
			set
			{
				if (voice != LocalVoiceAudioDummy.Dummy)
				{
					voice.Reliable = value;
				}
				reliableMode = value;
			}
		}

		public bool VoiceDetection
		{
			get
			{
				GetStatusFromDetector();
				return voiceDetection;
			}
			set
			{
				voiceDetection = value;
				if (VoiceDetector != null)
				{
					VoiceDetector.On = value;
				}
			}
		}

		public float VoiceDetectionThreshold
		{
			get
			{
				GetThresholdFromDetector();
				return voiceDetectionThreshold;
			}
			set
			{
				if (voiceDetectionThreshold.Equals(value))
				{
					return;
				}
				if (value < 0f || value > 1f)
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("Value out of range: VAD Threshold needs to be between [0..1], requested value: {0}", value);
					}
				}
				else
				{
					voiceDetectionThreshold = value;
					if (VoiceDetector != null)
					{
						VoiceDetector.Threshold = voiceDetectionThreshold;
					}
				}
			}
		}

		public int VoiceDetectionDelayMs
		{
			get
			{
				GetActivityDelayFromDetector();
				return voiceDetectionDelayMs;
			}
			set
			{
				if (voiceDetectionDelayMs != value)
				{
					voiceDetectionDelayMs = value;
					if (VoiceDetector != null)
					{
						VoiceDetector.ActivityDelayMs = value;
					}
				}
			}
		}

		public object UserData
		{
			get
			{
				return userData;
			}
			set
			{
				if (userData != value)
				{
					userData = value;
					if (IsRecording)
					{
						RequiresRestart = true;
						_ = base.Logger.IsInfoEnabled;
					}
				}
			}
		}

		public Func<IAudioDesc> InputFactory
		{
			get
			{
				return inputFactory;
			}
			set
			{
				if (!(inputFactory != value))
				{
					return;
				}
				inputFactory = value;
				if (IsRecording && SourceType == InputSourceType.Factory)
				{
					RequiresRestart = true;
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("Recorder.{0} changed, Recorder requires restart for this to take effect.", "InputFactory");
					}
				}
			}
		}

		public AudioUtil.IVoiceDetector VoiceDetector
		{
			get
			{
				if (voiceAudio == null)
				{
					return null;
				}
				return voiceAudio.VoiceDetector;
			}
		}

		public string UnityMicrophoneDevice
		{
			get
			{
				if (!IsValidUnityMic(unityMicrophoneDevice))
				{
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("\"{0}\" is not a valid Unity microphone device, switching to default", unityMicrophoneDevice);
					}
					unityMicrophoneDevice = null;
					if (UnityMicrophone.devices.Length != 0)
					{
						unityMicrophoneDevice = UnityMicrophone.devices[0];
					}
				}
				return unityMicrophoneDevice;
			}
			set
			{
				if (!IsValidUnityMic(value))
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("\"{0}\" is not a valid Unity microphone device", value);
					}
				}
				else
				{
					if (CompareUnityMicNames(unityMicrophoneDevice, value))
					{
						return;
					}
					unityMicrophoneDevice = value;
					if (string.IsNullOrEmpty(unityMicrophoneDevice) && UnityMicrophone.devices.Length != 0)
					{
						unityMicrophoneDevice = UnityMicrophone.devices[0];
					}
					if (IsRecording && SourceType == InputSourceType.Microphone && MicrophoneType == MicType.Unity)
					{
						RequiresRestart = true;
						if (base.Logger.IsInfoEnabled)
						{
							base.Logger.LogInfo("Recorder.{0} changed, Recorder requires restart for this to take effect.", "UnityMicrophoneDevice");
						}
					}
					CheckAndSetSamplingRate();
				}
			}
		}

		public int PhotonMicrophoneDeviceId
		{
			get
			{
				if (!IsValidPhotonMic())
				{
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("\"{0}\" is not a valid Photon microphone device ID, switching to default (-1)", photonMicrophoneDeviceId);
					}
					photonMicrophoneDeviceId = -1;
				}
				return photonMicrophoneDeviceId;
			}
			set
			{
				if (!IsValidPhotonMic(value))
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("\"{0}\" is not a valid Photon microphone device ID", value);
					}
				}
				else
				{
					if (photonMicrophoneDeviceId == value)
					{
						return;
					}
					photonMicrophoneDeviceId = value;
					if (IsRecording && SourceType == InputSourceType.Microphone && MicrophoneType == MicType.Photon)
					{
						RequiresRestart = true;
						if (base.Logger.IsInfoEnabled)
						{
							base.Logger.LogInfo("Recorder.{0} changed, Recorder requires restart for this to take effect.", "PhotonMicrophoneDeviceId");
						}
					}
				}
			}
		}

		[Obsolete("Use InterestGroup instead")]
		public byte AudioGroup
		{
			get
			{
				return InterestGroup;
			}
			set
			{
				InterestGroup = value;
			}
		}

		public byte InterestGroup
		{
			get
			{
				if (isRecording && voice.InterestGroup != interestGroup)
				{
					interestGroup = voice.InterestGroup;
					if (debugEchoMode && interestGroup != 0)
					{
						debugEchoMode = false;
					}
				}
				return interestGroup;
			}
			set
			{
				if (interestGroup == value)
				{
					return;
				}
				if (debugEchoMode && value != 0)
				{
					debugEchoMode = false;
					if (base.Logger.IsWarningEnabled)
					{
						base.Logger.LogWarning("DebugEchoMode disabled because InterestGroup changed to {0}. DebugEchoMode works only with Interest Group 0.", value);
					}
				}
				interestGroup = value;
				voice.InterestGroup = value;
			}
		}

		public bool IsCurrentlyTransmitting
		{
			get
			{
				if (IsRecording && TransmitEnabled)
				{
					return voice.IsCurrentlyTransmitting;
				}
				return false;
			}
		}

		public AudioUtil.ILevelMeter LevelMeter
		{
			get
			{
				if (voiceAudio == null)
				{
					return null;
				}
				return voiceAudio.LevelMeter;
			}
		}

		public bool VoiceDetectorCalibrating
		{
			get
			{
				if (voiceAudio != null && TransmitEnabled)
				{
					return voiceAudio.VoiceDetectorCalibrating;
				}
				return false;
			}
		}

		protected ILocalVoiceAudio voiceAudio => voice as ILocalVoiceAudio;

		public InputSourceType SourceType
		{
			get
			{
				return sourceType;
			}
			set
			{
				if (sourceType == value)
				{
					return;
				}
				sourceType = value;
				if (IsRecording)
				{
					RequiresRestart = true;
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("Recorder.{0} changed, Recorder requires restart for this to take effect.", "Source");
					}
				}
				CheckAndSetSamplingRate();
			}
		}

		public MicType MicrophoneType
		{
			get
			{
				return microphoneType;
			}
			set
			{
				if (microphoneType == value)
				{
					return;
				}
				microphoneType = value;
				if (IsRecording && SourceType == InputSourceType.Microphone)
				{
					RequiresRestart = true;
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("Recorder.{0} changed, Recorder requires restart for this to take effect.", "MicrophoneType");
					}
				}
				CheckAndSetSamplingRate();
			}
		}

		[Obsolete("No longer used. Implicit conversion is done internally when needed.")]
		public SampleTypeConv TypeConvert { get; set; }

		public AudioClip AudioClip
		{
			get
			{
				return audioClip;
			}
			set
			{
				if (!(audioClip != value))
				{
					return;
				}
				audioClip = value;
				if (IsRecording && SourceType == InputSourceType.AudioClip)
				{
					RequiresRestart = true;
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("Recorder.{0} changed, Recorder requires restart for this to take effect.", "AudioClip");
					}
				}
				CheckAndSetSamplingRate();
			}
		}

		public bool LoopAudioClip
		{
			get
			{
				return loopAudioClip;
			}
			set
			{
				if (loopAudioClip == value)
				{
					return;
				}
				loopAudioClip = value;
				if (IsRecording && SourceType == InputSourceType.AudioClip)
				{
					if (inputSource is AudioClipWrapper audioClipWrapper)
					{
						audioClipWrapper.Loop = value;
					}
					else if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("Unexpected: Recorder inputSource is not of AudioClipWrapper type or is null.");
					}
				}
			}
		}

		public SamplingRate SamplingRate
		{
			get
			{
				return samplingRate;
			}
			set
			{
				CheckAndSetSamplingRate(value);
			}
		}

		public OpusCodec.FrameDuration FrameDuration
		{
			get
			{
				return frameDuration;
			}
			set
			{
				if (frameDuration == value)
				{
					return;
				}
				frameDuration = value;
				if (IsRecording)
				{
					RequiresRestart = true;
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("Recorder.{0} changed, Recorder requires restart for this to take effect.", "FrameDuration");
					}
				}
			}
		}

		public int Bitrate
		{
			get
			{
				return bitrate;
			}
			set
			{
				if (bitrate == value)
				{
					return;
				}
				if (value < 6000 || value > 510000)
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("Unsupported bitrate value {0}, valid range: {1}-{2}", value, 6000, 510000);
					}
					return;
				}
				bitrate = value;
				if (IsRecording)
				{
					RequiresRestart = true;
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("Recorder.{0} changed, Recorder requires restart for this to take effect.", "Bitrate");
					}
				}
			}
		}

		public bool IsRecording
		{
			get
			{
				return isRecording;
			}
			set
			{
				if (isRecording != value)
				{
					if (isRecording)
					{
						StopRecording();
					}
					else
					{
						StartRecording();
					}
				}
			}
		}

		public bool ReactOnSystemChanges
		{
			get
			{
				return reactOnSystemChanges;
			}
			set
			{
				if (reactOnSystemChanges == value)
				{
					return;
				}
				reactOnSystemChanges = value;
				if (!IsRecording)
				{
					return;
				}
				if (reactOnSystemChanges)
				{
					if (!subscribedToSystemChanges)
					{
						SubscribeToSystemChanges();
					}
				}
				else if (subscribedToSystemChanges)
				{
					UnsubscribeFromSystemChanges();
				}
			}
		}

		public bool AutoStart
		{
			get
			{
				return autoStart;
			}
			set
			{
				if (autoStart != value)
				{
					autoStart = value;
					CheckAndAutoStart();
				}
			}
		}

		public bool RecordOnlyWhenEnabled
		{
			get
			{
				return recordOnlyWhenEnabled;
			}
			set
			{
				if (recordOnlyWhenEnabled == value)
				{
					return;
				}
				recordOnlyWhenEnabled = value;
				if (recordOnlyWhenEnabled)
				{
					if (!base.isActiveAndEnabled && IsRecording)
					{
						StopRecordingInternal();
					}
				}
				else
				{
					CheckAndAutoStart();
				}
			}
		}

		public bool SkipDeviceChangeChecks
		{
			get
			{
				return skipDeviceChangeChecks;
			}
			set
			{
				skipDeviceChangeChecks = value;
			}
		}

		public bool StopRecordingWhenPaused
		{
			get
			{
				return stopRecordingWhenPaused;
			}
			set
			{
				stopRecordingWhenPaused = value;
			}
		}

		public bool UseOnAudioFilterRead
		{
			get
			{
				return useOnAudioFilterRead;
			}
			set
			{
				if (useOnAudioFilterRead == value)
				{
					return;
				}
				useOnAudioFilterRead = value;
				if (IsRecording && SourceType == InputSourceType.Microphone && MicrophoneType == MicType.Unity)
				{
					RequiresRestart = true;
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("Recorder.{0} changed, Recorder requires restart for this to take effect.", "UseOnAudioFilterRead");
					}
				}
			}
		}

		public bool TrySamplingRateMatch
		{
			get
			{
				return trySamplingRateMatch;
			}
			set
			{
				if (trySamplingRateMatch != value)
				{
					trySamplingRateMatch = value;
					if (trySamplingRateMatch)
					{
						CheckAndSetSamplingRate();
					}
				}
			}
		}

		public bool UseMicrophoneTypeFallback
		{
			get
			{
				return useMicrophoneTypeFallback;
			}
			set
			{
				useMicrophoneTypeFallback = value;
			}
		}

		public bool RecordOnlyWhenJoined
		{
			get
			{
				return recordOnlyWhenJoined;
			}
			set
			{
				if (recordOnlyWhenJoined == value)
				{
					return;
				}
				recordOnlyWhenJoined = value;
				if (recordOnlyWhenJoined)
				{
					if (IsRecording && voiceConnection.Client != null && !voiceConnection.Client.InRoom)
					{
						StopRecordingInternal();
					}
				}
				else
				{
					CheckAndAutoStart();
				}
			}
		}

		public IDeviceEnumerator MicrophonesEnumerator => GetMicrophonesEnumerator(MicrophoneType);

		public DeviceInfo MicrophoneDevice
		{
			get
			{
				switch (MicrophoneType)
				{
				case MicType.Unity:
				{
					string text = UnityMicrophoneDevice;
					if (string.IsNullOrEmpty(text))
					{
						return MicrophonesEnumerator.First();
					}
					return GetDeviceById(text);
				}
				case MicType.Photon:
				{
					int num = PhotonMicrophoneDeviceId;
					if (num != -1)
					{
						return GetDeviceById(num);
					}
					break;
				}
				}
				return DeviceInfo.Default;
			}
			set
			{
				switch (MicrophoneType)
				{
				case MicType.Unity:
					UnityMicrophoneDevice = value.IDString;
					break;
				case MicType.Photon:
					PhotonMicrophoneDeviceId = (value.IsDefault ? (-1) : value.IDInt);
					break;
				}
			}
		}

		public void Init(VoiceConnection connection)
		{
			if ((object)connection == null)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("voiceConnection is null.");
				}
				return;
			}
			if (!connection)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("voiceConnection is destroyed.");
				}
				return;
			}
			if (!base.IgnoreGlobalLogLevel)
			{
				base.LogLevel = connection.GlobalRecordersLogLevel;
			}
			if (IsInitialized)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Recorder already initialized.");
				}
			}
			else if (connection.VoiceClient == null)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("voiceConnection.VoiceClient is null.");
				}
			}
			else
			{
				voiceConnection = connection;
				client = connection.VoiceClient;
				voiceConnection.AddInitializedRecorder(this);
				CheckAndAutoStart();
			}
		}

		[Obsolete("Renamed to RestartRecording")]
		public void ReInit()
		{
			RestartRecording();
		}

		public void RestartRecording(bool force = false)
		{
			if (!force && !RequiresRestart)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Recorder does not require restart.");
				}
				return;
			}
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("Restarting recording, RequiresRestart?={0} forcedRestart?={1}", RequiresRestart, force);
			}
			StopRecording();
			StartRecording();
		}

		public void VoiceDetectorCalibrate(int durationMs, Action<float> detectionEndedCallback = null)
		{
			if (voiceAudio == null)
			{
				return;
			}
			if (!TransmitEnabled)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Cannot start voice detection calibration when transmission is not enabled");
				}
				return;
			}
			voiceAudio.VoiceDetectorCalibrate(durationMs, delegate
			{
				GetThresholdFromDetector();
				if (detectionEndedCallback != null)
				{
					detectionEndedCallback(voiceDetectionThreshold);
				}
			});
		}

		public void StartRecording()
		{
			if (IsRecording)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Recorder is already started.");
				}
			}
			else if (!IsInitialized)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Recording can't be started if Recorder is not initialized. Call Recorder.Init(VoiceConnection) first.");
				}
			}
			else if (RecordOnlyWhenEnabled && !base.isActiveAndEnabled)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Recording can't be started because RecordOnlyWhenEnabled is true and Recorder is not enabled or its GameObject is not active in hierarchy.");
				}
			}
			else if (RecordOnlyWhenJoined && voiceConnection.Client != null && !voiceConnection.Client.InRoom)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Recording can't be started because RecordOnlyWhenJoined is true and voice networking client is not joined to a room.");
				}
			}
			else
			{
				StartRecordingInternal();
			}
		}

		public void StopRecording()
		{
			wasRecordingBeforePause = false;
			if (!IsRecording)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Recorder is not started.");
				}
			}
			else
			{
				StopRecordingInternal();
				recordingStoppedExplicitly = true;
			}
		}

		public bool ResetLocalAudio()
		{
			if (inputSource != null && inputSource is IResettable)
			{
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Resetting local audio.");
				}
				(inputSource as IResettable).Reset();
				return true;
			}
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("InputSource is null or not resettable.");
			}
			return false;
		}

		public static bool CompareUnityMicNames(string mic1, string mic2)
		{
			if (IsDefaultUnityMic(mic1) && IsDefaultUnityMic(mic2))
			{
				return true;
			}
			if (mic1 != null && mic1.Equals(mic2))
			{
				return true;
			}
			return false;
		}

		public static bool IsDefaultUnityMic(string mic)
		{
			if (!string.IsNullOrEmpty(mic))
			{
				return Array.IndexOf(UnityMicrophone.devices, mic) == 0;
			}
			return true;
		}

		private void Setup()
		{
			voice = CreateLocalVoiceAudioAndSource();
			if (voice == LocalVoiceAudioDummy.Dummy)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Local input source setup and voice stream creation failed. No recording or transmission will be happening. See previous error log messages for more details.");
				}
				if (inputSource != null)
				{
					inputSource.Dispose();
					inputSource = null;
				}
				if (MicrophoneDeviceChangeDetected)
				{
					MicrophoneDeviceChangeDetected = false;
				}
				return;
			}
			SubscribeToSystemChanges();
			if (VoiceDetector != null)
			{
				VoiceDetector.Threshold = voiceDetectionThreshold;
				VoiceDetector.ActivityDelayMs = voiceDetectionDelayMs;
				VoiceDetector.On = voiceDetection;
			}
			voice.InterestGroup = InterestGroup;
			voice.DebugEchoMode = DebugEchoMode;
			voice.Encrypt = Encrypt;
			voice.Reliable = ReliableMode;
			RequiresRestart = false;
			isRecording = true;
			SendPhotonVoiceCreatedMessage();
			voice.TransmitEnabled = TransmitEnabled;
		}

		private LocalVoice CreateLocalVoiceAudioAndSource()
		{
			SamplingRate samplingRate = this.samplingRate;
			int num = (int)samplingRate;
			bool flag;
			DeviceInfo microphoneDevice;
			int deviceID;
			string text;
			switch (SourceType)
			{
			case InputSourceType.Microphone:
			{
				if (!CheckIfThereIsAtLeastOneMic())
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("No microphone detected.");
					}
					return LocalVoiceAudioDummy.Dummy;
				}
				flag = false;
				MicType micType = MicrophoneType;
				if (micType == MicType.Unity)
				{
					goto IL_0075;
				}
				if (micType != MicType.Photon)
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("unknown MicrophoneType value {0}", MicrophoneType);
					}
					return LocalVoiceAudioDummy.Dummy;
				}
				goto IL_014d;
			}
			case InputSourceType.AudioClip:
			{
				if ((object)AudioClip == null)
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("AudioClip property must be set for AudioClip audio source");
					}
					return LocalVoiceAudioDummy.Dummy;
				}
				AudioClipWrapper audioClipWrapper = new AudioClipWrapper(AudioClip);
				audioClipWrapper.Loop = LoopAudioClip;
				inputSource = audioClipWrapper;
				break;
			}
			case InputSourceType.Factory:
				if (InputFactory == null)
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("Recorder.InputFactory must be specified if Recorder.Source set to Factory");
					}
					return LocalVoiceAudioDummy.Dummy;
				}
				inputSource = InputFactory();
				if (inputSource.Error != null && base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("InputFactory creation failure: {0}.", inputSource.Error);
				}
				break;
			default:
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("unknown Source value {0}", SourceType);
					}
					return LocalVoiceAudioDummy.Dummy;
				}
				IL_014d:
				microphoneDevice = MicrophoneDevice;
				deviceID = (microphoneDevice.IsDefault ? (-1) : microphoneDevice.IDInt);
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Setting recorder's source to Photon microphone device={0}", microphoneDevice);
				}
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Setting recorder's source to WindowsAudioInPusher");
				}
				inputSource = new WindowsAudioInPusher(deviceID, base.Logger);
				if (inputSource != null)
				{
					if (inputSource.Error == null)
					{
						break;
					}
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("Photon microphone input source creation failure: {0}", inputSource.Error);
					}
				}
				if (!UseMicrophoneTypeFallback || flag)
				{
					break;
				}
				flag = true;
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Photon microphone failed. Falling back to Unity microphone");
				}
				goto IL_0075;
				IL_0075:
				text = UnityMicrophoneDevice;
				_ = base.Logger.IsInfoEnabled;
				if (UseOnAudioFilterRead)
				{
					UnityEngine.Debug.Log("Using MicWrapperPusher");
					inputSource = new MicWrapperPusher(text, base.transform, num, base.Logger);
				}
				else
				{
					inputSource = CreateMicWrapper(text, num, base.Logger);
				}
				if (inputSource != null)
				{
					if (inputSource.Error == null)
					{
						break;
					}
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("Unity microphone input source creation failure: {0}", inputSource.Error);
					}
				}
				if (!UseMicrophoneTypeFallback || flag)
				{
					break;
				}
				flag = true;
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Unity microphone failed. Falling back to Photon microphone");
				}
				goto IL_014d;
			}
			if (inputSource == null || inputSource.Error != null)
			{
				return LocalVoiceAudioDummy.Dummy;
			}
			if (inputSource.Channels == 0)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("inputSource.Channels is zero");
				}
				return LocalVoiceAudioDummy.Dummy;
			}
			if (TrySamplingRateMatch && inputSource.SamplingRate != num)
			{
				samplingRate = GetSupportedSamplingRate(inputSource.SamplingRate);
				if (samplingRate != this.samplingRate && base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Sampling rate requested ({0}Hz) is not used, input source is expecting {1}Hz instead so switching to the closest supported value: {1}Hz.", num, inputSource.SamplingRate, (int)samplingRate);
				}
			}
			AudioSampleType sampleType = AudioSampleType.Source;
			WebRtcAudioDsp component = GetComponent<WebRtcAudioDsp>();
			if ((object)component != null && (bool)component && component.enabled)
			{
				sampleType = AudioSampleType.Short;
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Type Conversion set to Short. Audio samples will be converted if source samples types differ.");
				}
				num = (int)samplingRate;
				switch (samplingRate)
				{
				case SamplingRate.Sampling12000:
					if (base.Logger.IsWarningEnabled)
					{
						base.Logger.LogWarning("Sampling rate requested (12kHz) is not supported by WebRTC Audio DSP, switching to the closest supported value: 16kHz.");
					}
					samplingRate = SamplingRate.Sampling16000;
					break;
				case SamplingRate.Sampling24000:
					if (base.Logger.IsWarningEnabled)
					{
						base.Logger.LogWarning("Sampling rate requested (24kHz) is not supported by WebRTC Audio DSP, switching to the closest supported value: 48kHz.");
					}
					samplingRate = SamplingRate.Sampling48000;
					break;
				}
				OpusCodec.FrameDuration frameDuration = FrameDuration;
				if (frameDuration == OpusCodec.FrameDuration.Frame2dot5ms || frameDuration == OpusCodec.FrameDuration.Frame5ms)
				{
					if (base.Logger.IsWarningEnabled)
					{
						base.Logger.LogWarning("Frame duration requested ({0}ms) is not supported by WebRTC Audio DSP (it needs to be N x 10ms), switching to the closest supported value: 10ms.", (int)FrameDuration / 1000);
					}
					FrameDuration = OpusCodec.FrameDuration.Frame10ms;
				}
			}
			this.samplingRate = samplingRate;
			VoiceInfo voiceInfo = VoiceInfo.CreateAudioOpus(samplingRate, inputSource.Channels, FrameDuration, Bitrate, UserData);
			return client.CreateLocalVoiceAudioFromSource(voiceInfo, inputSource, sampleType);
		}

		protected virtual MicWrapper CreateMicWrapper(string micDev, int samplingRateInt, VoiceLogger logger)
		{
			return new MicWrapper(micDev, samplingRateInt, logger);
		}

		protected virtual void SendPhotonVoiceCreatedMessage()
		{
			base.gameObject.SendMessage("PhotonVoiceCreated", new Photon.Voice.Unity.PhotonVoiceCreatedParams
			{
				Voice = voice,
				AudioDesc = inputSource
			}, SendMessageOptions.DontRequireReceiver);
		}

		private void OnDestroy()
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("Recorder is about to be destroyed, removing local voice.");
			}
			RemoveVoice();
			if (IsInitialized)
			{
				voiceConnection.RemoveInitializedRecorder(this);
			}
		}

		private void RemoveVoice()
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("RemovingVoice()");
			}
			if (subscribedToSystemChanges)
			{
				UnsubscribeFromSystemChanges();
			}
			GetThresholdFromDetector();
			GetStatusFromDetector();
			GetActivityDelayFromDetector();
			if (voice != LocalVoiceAudioDummy.Dummy)
			{
				interestGroup = voice.InterestGroup;
				if (debugEchoMode && interestGroup != 0)
				{
					debugEchoMode = false;
				}
				voice.RemoveSelf();
				voice = LocalVoiceAudioDummy.Dummy;
			}
			if (inputSource != null)
			{
				inputSource.Dispose();
				inputSource = null;
			}
			base.gameObject.SendMessage("PhotonVoiceRemoved", SendMessageOptions.DontRequireReceiver);
			isRecording = false;
			RequiresRestart = false;
		}

		private void OnAudioConfigChanged(bool deviceWasChanged)
		{
			if (base.Logger.IsInfoEnabled)
			{
				base.Logger.LogInfo("OnAudioConfigChanged deviceWasChanged={0}", deviceWasChanged);
			}
			if (SkipDeviceChangeChecks || deviceWasChanged)
			{
				MicrophoneDeviceChangeDetected = true;
			}
		}

		private void PhotonMicrophoneChangeDetected()
		{
			if (base.Logger.IsInfoEnabled)
			{
				base.Logger.LogInfo("Microphones change detected by Photon native plugin");
			}
			MicrophoneDeviceChangeDetected = true;
		}

		internal void HandleDeviceChange()
		{
			if (!MicrophoneDeviceChangeDetected && base.Logger.IsWarningEnabled)
			{
				base.Logger.LogWarning("Unexpected: HandleDeviceChange called while MicrophoneDeviceChangedDetected is false.");
			}
			if (photonMicrophoneEnumerator != null)
			{
				photonMicrophoneEnumerator.Refresh();
			}
			if (photonMicrophonesEnumerator != null)
			{
				photonMicrophonesEnumerator.Refresh();
			}
			if (unityMicrophonesEnumerator != null)
			{
				unityMicrophonesEnumerator.Refresh();
			}
			if (IsRecording)
			{
				bool flag = false;
				if (SkipDeviceChangeChecks)
				{
					flag = true;
				}
				else if (SourceType == InputSourceType.Microphone)
				{
					flag = ((MicrophoneType != MicType.Photon) ? (string.IsNullOrEmpty(unityMicrophoneDevice) || !IsValidUnityMic(unityMicrophoneDevice)) : (photonMicrophoneDeviceId == -1 || !IsValidPhotonMic()));
				}
				if (!flag)
				{
					return;
				}
				if (ResetLocalAudio())
				{
					MicrophoneDeviceChangeDetected = false;
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("Local audio reset as a result of audio config/device change.");
					}
					return;
				}
				RequiresRestart = true;
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Restarting Recording as a result of audio config/device change.");
				}
				RestartRecording();
			}
			else
			{
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("A microphone device may have been made available: will check auto start conditions and if all good will attempt to start recording.");
				}
				CheckAndAutoStart(autoStartFlag: true);
			}
		}

		private void SubscribeToSystemChanges()
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("Subscribing to system (audio) changes.");
			}
			if (!ReactOnSystemChanges)
			{
				if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("ReactOnSystemChanges is false, not subscribed to system (audio) changes.");
				}
				return;
			}
			if (subscribedToSystemChanges)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Already subscribed to system (audio) changes.");
				}
				return;
			}
			photonMicChangeNotifier = Platform.CreateAudioInChangeNotifier(PhotonMicrophoneChangeDetected, base.Logger);
			if (photonMicChangeNotifier.IsSupported)
			{
				if (photonMicChangeNotifier.Error == null)
				{
					subscribedToSystemChangesPhoton = true;
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("Subscribed to audio in change notifications via Photon plugin.");
					}
					return;
				}
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Error creating instance of photonMicChangeNotifier: {0}", photonMicChangeNotifier.Error);
				}
			}
			photonMicChangeNotifier.Dispose();
			photonMicChangeNotifier = null;
			AudioSettings.OnAudioConfigurationChanged += OnAudioConfigChanged;
			subscribedToSystemChangesUnity = true;
			if (base.Logger.IsInfoEnabled)
			{
				base.Logger.LogInfo("Subscribed to audio configuration changes via Unity callback.");
			}
		}

		private void UnsubscribeFromSystemChanges()
		{
			if (subscribedToSystemChangesUnity)
			{
				AudioSettings.OnAudioConfigurationChanged -= OnAudioConfigChanged;
				subscribedToSystemChangesUnity = false;
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Unsubscribed from audio configuration changes via Unity callback.");
				}
			}
			if (!subscribedToSystemChangesPhoton)
			{
				return;
			}
			if (photonMicChangeNotifier == null)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Unexpected: photonMicChangeNotifier is null while subscribedToSystemChangesPhoton is true.");
				}
			}
			else
			{
				photonMicChangeNotifier.Dispose();
				photonMicChangeNotifier = null;
			}
			subscribedToSystemChangesPhoton = false;
			if (base.Logger.IsInfoEnabled)
			{
				base.Logger.LogInfo("Unsubscribed from audio in change notifications via Photon plugin.");
			}
		}

		private void GetThresholdFromDetector()
		{
			if (!IsRecording || VoiceDetector == null || voiceDetectionThreshold.Equals(VoiceDetector.Threshold))
			{
				return;
			}
			if (VoiceDetector.Threshold <= 1f && VoiceDetector.Threshold >= 0f)
			{
				if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("VoiceDetectionThreshold automatically changed from {0} to {1}", voiceDetectionThreshold, VoiceDetector.Threshold);
				}
				voiceDetectionThreshold = VoiceDetector.Threshold;
			}
			else if (base.Logger.IsWarningEnabled)
			{
				base.Logger.LogWarning("VoiceDetector.Threshold has unexpected value {0}", VoiceDetector.Threshold);
			}
		}

		private void GetActivityDelayFromDetector()
		{
			if (IsRecording && VoiceDetector != null && voiceDetectionDelayMs != VoiceDetector.ActivityDelayMs)
			{
				if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("VoiceDetectionDelayMs automatically changed from {0} to {1}", voiceDetectionDelayMs, VoiceDetector.ActivityDelayMs);
				}
				voiceDetectionDelayMs = VoiceDetector.ActivityDelayMs;
			}
		}

		private void GetStatusFromDetector()
		{
			if (IsRecording && VoiceDetector != null && voiceDetection != VoiceDetector.On)
			{
				if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("VoiceDetection automatically changed from {0} to {1}", voiceDetection, VoiceDetector.On);
				}
				voiceDetection = VoiceDetector.On;
			}
		}

		private static bool IsValidUnityMic(string mic)
		{
			if (!string.IsNullOrEmpty(mic))
			{
				return Enumerable.Contains(UnityMicrophone.devices, mic);
			}
			return true;
		}

		private void OnEnable()
		{
			wasRecordingBeforePause = false;
			isPausedOrInBackground = false;
			CheckAndAutoStart();
		}

		private void OnDisable()
		{
			if (RecordOnlyWhenEnabled && IsRecording)
			{
				StopRecordingInternal();
			}
		}

		private bool IsValidPhotonMic()
		{
			return IsValidPhotonMic(photonMicrophoneDeviceId);
		}

		public static bool CheckIfMicrophoneIdIsValid(IDeviceEnumerator audioInEnumerator, int id)
		{
			if (id == -1)
			{
				return true;
			}
			if (audioInEnumerator.IsSupported && audioInEnumerator.Error == null)
			{
				foreach (DeviceInfo item in audioInEnumerator)
				{
					if (item.IDInt == id)
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool IsValidPhotonMic(int id)
		{
			return CheckIfMicrophoneIdIsValid(GetMicrophonesEnumerator(MicType.Photon), id);
		}

		private void OnApplicationPause(bool paused)
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("OnApplicationPause({0})", paused);
			}
			HandleApplicationPause(paused);
		}

		private void OnApplicationFocus(bool focused)
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("OnApplicationFocus({0})", focused);
			}
			HandleApplicationPause(!focused);
		}

		private void HandleApplicationPause(bool paused)
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("App paused?= {0}, isPausedOrInBackground = {1}, wasRecordingBeforePause = {2}, StopRecordingWhenPaused = {3}, IsRecording = {4}", paused, isPausedOrInBackground, wasRecordingBeforePause, StopRecordingWhenPaused, IsRecording);
			}
			if (isPausedOrInBackground == paused)
			{
				return;
			}
			if (paused)
			{
				wasRecordingBeforePause = IsRecording;
				isPausedOrInBackground = true;
				if (StopRecordingWhenPaused && IsRecording)
				{
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("Stopping recording as application went to background or paused");
					}
					RemoveVoice();
				}
				return;
			}
			if (!StopRecordingWhenPaused)
			{
				if (ResetLocalAudio() && base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Local audio reset as application is back from background or unpaused");
				}
			}
			else if (wasRecordingBeforePause)
			{
				if (!IsRecording)
				{
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("Starting recording as application is back from background or unpaused");
					}
					Setup();
				}
				else if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Unexpected: Application back from background or unpaused, isPausedOrInBackground = true, wasRecordingBeforePause = true, StopRecordingWhenPaused = true, IsRecording = true");
				}
			}
			wasRecordingBeforePause = false;
			isPausedOrInBackground = false;
		}

		private SamplingRate GetSupportedSamplingRate(int requested)
		{
			if (Enum.IsDefined(typeof(SamplingRate), requested))
			{
				return (SamplingRate)requested;
			}
			int num = int.MaxValue;
			SamplingRate result = SamplingRate.Sampling48000;
			foreach (SamplingRate samplingRateValue in samplingRateValues)
			{
				int num2 = Math.Abs((int)(samplingRateValue - requested));
				if (num2 < num)
				{
					num = num2;
					result = samplingRateValue;
				}
			}
			return result;
		}

		private SamplingRate GetSupportedSamplingRateForUnityMicrophone(SamplingRate requested)
		{
			UnityMicrophone.GetDeviceCaps(UnityMicrophoneDevice, out var minFreq, out var maxFreq);
			return GetSupportedSamplingRate(requested, minFreq, maxFreq);
		}

		private SamplingRate GetSupportedSamplingRate(SamplingRate requested, int minFreq, int maxFreq)
		{
			SamplingRate result = requested;
			int num = (int)this.samplingRate;
			if (num < minFreq || (maxFreq != 0 && num > maxFreq))
			{
				if (Enum.IsDefined(typeof(SamplingRate), maxFreq))
				{
					result = (SamplingRate)maxFreq;
				}
				else
				{
					num = maxFreq;
					int num2 = int.MaxValue;
					foreach (SamplingRate samplingRateValue in samplingRateValues)
					{
						int num3 = (int)samplingRateValue;
						if (num3 >= minFreq && (maxFreq == 0 || num3 <= maxFreq))
						{
							int num4 = Math.Abs(num3 - num);
							if (num4 < num2)
							{
								num2 = num4;
								result = samplingRateValue;
							}
						}
					}
				}
			}
			return result;
		}

		private SamplingRate GetSupportedSamplingRate(SamplingRate sR)
		{
			switch (SourceType)
			{
			case InputSourceType.Microphone:
				return MicrophoneType switch
				{
					MicType.Unity => GetSupportedSamplingRateForUnityMicrophone(sR), 
					MicType.Photon => SamplingRate.Sampling16000, 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			case InputSourceType.AudioClip:
				if (AudioClip != null)
				{
					return GetSupportedSamplingRate(AudioClip.frequency);
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case InputSourceType.Factory:
				break;
			}
			return sR;
		}

		private void CheckAndSetSamplingRate(SamplingRate sR)
		{
			if (TrySamplingRateMatch)
			{
				SamplingRate supportedSamplingRate = GetSupportedSamplingRate(sR);
				if (supportedSamplingRate == samplingRate)
				{
					return;
				}
				if (supportedSamplingRate != sR && base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Sampling rate requested ({0}Hz) not supported using closest value ({1}Hz)", (int)sR, (int)supportedSamplingRate);
				}
				samplingRate = supportedSamplingRate;
			}
			else
			{
				if (sR == samplingRate)
				{
					return;
				}
				samplingRate = sR;
			}
			if (IsRecording)
			{
				RequiresRestart = true;
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Recorder.{0} changed, Recorder requires restart for this to take effect.", "SamplingRate");
				}
			}
		}

		private void CheckAndSetSamplingRate()
		{
			CheckAndSetSamplingRate(samplingRate);
		}

		internal void StopRecordingInternal()
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("Stopping recording");
			}
			wasRecordingBeforePause = false;
			RemoveVoice();
			if (MicrophoneDeviceChangeDetected)
			{
				MicrophoneDeviceChangeDetected = false;
			}
		}

		internal void CheckAndAutoStart()
		{
			CheckAndAutoStart(autoStart);
		}

		internal void CheckAndAutoStart(bool autoStartFlag)
		{
			bool flag = true;
			if (!autoStartFlag)
			{
				flag = false;
				if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("Auto start check failure: autoStart flag is false.");
				}
			}
			if (!IsInitialized)
			{
				flag = false;
				if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("Auto start check failure: recorder not initialized.");
				}
			}
			if (isRecording)
			{
				flag = false;
				if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("Auto start check failure: recorder is already started.");
				}
			}
			if (recordingStoppedExplicitly)
			{
				flag = false;
				if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("Auto start check failure: recorder was previously stopped explicitly.");
				}
			}
			if (recordOnlyWhenEnabled && !base.isActiveAndEnabled)
			{
				flag = false;
				if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("Auto start check failure: recorder not enabled and this is required.");
				}
			}
			if (recordOnlyWhenJoined && ((object)voiceConnection == null || !voiceConnection || voiceConnection.Client == null || !voiceConnection.Client.InRoom))
			{
				flag = false;
				if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("Auto start check failure: voice client not joined to a room yet and this is required.");
				}
			}
			if (SourceType == InputSourceType.Microphone && !CheckIfThereIsAtLeastOneMic())
			{
				flag = false;
				if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("Auto start check failure: no microphone detected.");
				}
			}
			if (flag)
			{
				if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("AutoStart requirements met: going to auto start recording");
				}
				StartRecordingInternal();
			}
			else if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("AutoStart requirements NOT met: NOT going to auto start recording");
			}
		}

		internal void StartRecordingInternal()
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("Starting recording");
			}
			wasRecordingBeforePause = false;
			recordingStoppedExplicitly = false;
			Setup();
		}

		private IDeviceEnumerator GetMicrophonesEnumerator(MicType micType)
		{
			switch (micType)
			{
			case MicType.Unity:
				if (unityMicrophonesEnumerator == null)
				{
					unityMicrophonesEnumerator = new AudioInEnumerator(base.Logger);
					if (!unityMicrophonesEnumerator.IsSupported && base.Logger.IsWarningEnabled)
					{
						base.Logger.LogWarning("UnityMicrophonesEnumerator is not supported on this platform {0}.", VoiceComponent.CurrentPlatform);
					}
					else if (unityMicrophonesEnumerator.Error != null && base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError(unityMicrophonesEnumerator.Error);
					}
				}
				return unityMicrophonesEnumerator;
			case MicType.Photon:
				if (photonMicrophonesEnumerator == null)
				{
					photonMicrophonesEnumerator = CreatePhotonDeviceEnumerator(base.Logger);
				}
				return photonMicrophonesEnumerator;
			default:
				return null;
			}
		}

		private DeviceInfo GetDeviceById(int id)
		{
			foreach (DeviceInfo item in MicrophonesEnumerator)
			{
				if (item.IDInt == id)
				{
					return item;
				}
			}
			return DeviceInfo.Default;
		}

		private DeviceInfo GetDeviceById(string id)
		{
			foreach (DeviceInfo item in MicrophonesEnumerator)
			{
				if (string.Equals(item.IDString, id))
				{
					return item;
				}
			}
			return DeviceInfo.Default;
		}

		private bool CheckIfThereIsAtLeastOneMic()
		{
			if (MicrophoneType == MicType.Photon)
			{
				IDeviceEnumerator microphonesEnumerator = MicrophonesEnumerator;
				if (microphonesEnumerator != null)
				{
					return microphonesEnumerator.Any();
				}
			}
			return UnityMicrophone.devices.Length != 0;
		}

		private static IDeviceEnumerator CreatePhotonDeviceEnumerator(VoiceLogger voiceLogger)
		{
			IDeviceEnumerator deviceEnumerator = Platform.CreateAudioInEnumerator(voiceLogger);
			if (!deviceEnumerator.IsSupported && voiceLogger.IsWarningEnabled)
			{
				voiceLogger.LogWarning("PhotonMicrophonesEnumerator is not supported on this platform {0}.", VoiceComponent.CurrentPlatform);
			}
			else if (deviceEnumerator.Error != null && voiceLogger.IsErrorEnabled)
			{
				voiceLogger.LogError(deviceEnumerator.Error);
			}
			return deviceEnumerator;
		}
	}
	public class RemoteVoiceLink : IEquatable<RemoteVoiceLink>
	{
		public readonly VoiceInfo Info;

		public readonly int PlayerId;

		public readonly int VoiceId;

		public readonly int ChannelId;

		private string cached;

		public event Action<FrameOut<float>> FloatFrameDecoded;

		public event Action RemoteVoiceRemoved;

		public RemoteVoiceLink(VoiceInfo info, int playerId, int voiceId, int channelId)
		{
			Info = info;
			PlayerId = playerId;
			VoiceId = voiceId;
			ChannelId = channelId;
		}

		public void Init(ref RemoteVoiceOptions options)
		{
			options.SetOutput(OnDecodedFrameFloatAction);
			options.OnRemoteVoiceRemoveAction = OnRemoteVoiceRemoveAction;
		}

		private void OnRemoteVoiceRemoveAction()
		{
			if (this.RemoteVoiceRemoved != null)
			{
				this.RemoteVoiceRemoved();
			}
		}

		private void OnDecodedFrameFloatAction(FrameOut<float> floats)
		{
			if (this.FloatFrameDecoded != null)
			{
				this.FloatFrameDecoded(floats);
			}
		}

		public override string ToString()
		{
			if (string.IsNullOrEmpty(cached))
			{
				cached = $"[p#:{PlayerId},v#:{VoiceId},c#:{ChannelId},i:{{{Info}}}]";
			}
			return cached;
		}

		public bool Equals(RemoteVoiceLink other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (PlayerId != other.PlayerId || VoiceId != other.VoiceId)
			{
				return Info.UserData == other.Info.UserData;
			}
			return true;
		}
	}
	[RequireComponent(typeof(AudioSource))]
	[AddComponentMenu("Photon Voice/Speaker")]
	[DisallowMultipleComponent]
	public class Speaker : VoiceComponent
	{
		private IAudioOut<float> audioOutput;

		private RemoteVoiceLink remoteVoiceLink;

		[SerializeField]
		private bool playbackOnlyWhenEnabled;

		[SerializeField]
		[HideInInspector]
		private int playDelayMs = 200;

		[SerializeField]
		protected PlaybackDelaySettings playbackDelaySettings = new PlaybackDelaySettings
		{
			MinDelaySoft = 200,
			MaxDelaySoft = 400,
			MaxDelayHard = 1000
		};

		private bool playbackExplicitlyStopped;

		public Func<IAudioOut<float>> CustomAudioOutFactory;

		[Obsolete("Use SetPlaybackDelaySettings methods instead")]
		public int PlayDelayMs
		{
			get
			{
				return playbackDelaySettings.MinDelaySoft;
			}
			set
			{
				if (value >= 0 && value < playbackDelaySettings.MaxDelaySoft)
				{
					playbackDelaySettings.MinDelaySoft = value;
				}
			}
		}

		public bool IsPlaying
		{
			get
			{
				if (IsInitialized)
				{
					return audioOutput.IsPlaying;
				}
				return false;
			}
		}

		public int Lag
		{
			get
			{
				if (!IsPlaying)
				{
					return -1;
				}
				return audioOutput.Lag;
			}
		}

		public Action<Speaker> OnRemoteVoiceRemoveAction { get; set; }

		public Player Actor { get; protected internal set; }

		public bool IsLinked => remoteVoiceLink != null;

		internal RemoteVoiceLink RemoteVoiceLink => remoteVoiceLink;

		public bool PlaybackOnlyWhenEnabled
		{
			get
			{
				return playbackOnlyWhenEnabled;
			}
			set
			{
				if (playbackOnlyWhenEnabled == value)
				{
					return;
				}
				playbackOnlyWhenEnabled = value;
				if (!IsLinked)
				{
					return;
				}
				if (playbackOnlyWhenEnabled)
				{
					if (base.isActiveAndEnabled == PlaybackStarted)
					{
						return;
					}
					if (base.isActiveAndEnabled)
					{
						if (!playbackExplicitlyStopped)
						{
							StartPlaying();
						}
					}
					else
					{
						StopPlaying();
					}
				}
				else if (!PlaybackStarted && !playbackExplicitlyStopped)
				{
					StartPlaying();
				}
			}
		}

		public bool PlaybackStarted { get; private set; }

		public int PlaybackDelayMinSoft => playbackDelaySettings.MinDelaySoft;

		public int PlaybackDelayMaxSoft => playbackDelaySettings.MaxDelaySoft;

		public int PlaybackDelayMaxHard => playbackDelaySettings.MaxDelayHard;

		protected bool IsInitialized => audioOutput != null;

		private void OnEnable()
		{
			if (IsLinked && !PlaybackStarted && !playbackExplicitlyStopped)
			{
				StartPlaying();
			}
		}

		private void OnDisable()
		{
			if (PlaybackOnlyWhenEnabled && PlaybackStarted)
			{
				StopPlaying();
			}
		}

		protected virtual void Initialize()
		{
			if (IsInitialized)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Already initialized.");
				}
				return;
			}
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("Initializing.");
			}
			Func<IAudioOut<float>> func = ((CustomAudioOutFactory == null) ? GetDefaultAudioOutFactory() : CustomAudioOutFactory);
			audioOutput = func();
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("Initialized.");
			}
		}

		internal Func<IAudioOut<float>> GetDefaultAudioOutFactory()
		{
			AudioOutDelayControl.PlayDelayConfig pdc = new AudioOutDelayControl.PlayDelayConfig
			{
				Low = playbackDelaySettings.MinDelaySoft,
				High = playbackDelaySettings.MaxDelaySoft,
				Max = playbackDelaySettings.MaxDelayHard
			};
			return () => new UnityAudioOut(GetComponent<AudioSource>(), pdc, base.Logger, string.Empty, base.Logger.IsDebugEnabled);
		}

		internal bool OnRemoteVoiceInfo(RemoteVoiceLink stream)
		{
			if (stream == null)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("RemoteVoiceLink is null, cancelled linking");
				}
				return false;
			}
			if (!IsInitialized)
			{
				Initialize();
			}
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("OnRemoteVoiceInfo {0}", stream);
			}
			if (IsLinked)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Speaker already linked to {0}, cancelled linking to {1}", remoteVoiceLink, stream);
				}
				return false;
			}
			if (stream.Info.Channels <= 0)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Received voice info channels is not expected (<= 0), cancelled linking to {0}", stream);
				}
				return false;
			}
			remoteVoiceLink = stream;
			remoteVoiceLink.RemoteVoiceRemoved += OnRemoteVoiceRemove;
			if (IsInitialized)
			{
				if (!PlaybackOnlyWhenEnabled || base.isActiveAndEnabled)
				{
					return StartPlayback();
				}
				return true;
			}
			return false;
		}

		internal void OnRemoteVoiceRemove()
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("OnRemoteVoiceRemove {0}", remoteVoiceLink);
			}
			StopPlaying();
			if (OnRemoteVoiceRemoveAction != null)
			{
				OnRemoteVoiceRemoveAction(this);
			}
			CleanUp();
		}

		protected virtual void OnAudioFrame(FrameOut<float> frame)
		{
			audioOutput.Push(frame.Buf);
			if (frame.EndOfStream)
			{
				audioOutput.Flush();
			}
		}

		private bool StartPlaying()
		{
			if (!IsLinked)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Cannot start playback because speaker is not linked");
				}
				return false;
			}
			if (PlaybackStarted)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Playback is already started");
				}
				return false;
			}
			if (!IsInitialized)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Cannot start playback because not initialized yet");
				}
				return false;
			}
			if (!base.isActiveAndEnabled && PlaybackOnlyWhenEnabled)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Cannot start playback because PlaybackOnlyWhenEnabled is true and Speaker is not enabled or its GameObject is not active in the hierarchy.");
				}
				return false;
			}
			VoiceInfo info = remoteVoiceLink.Info;
			if (info.Channels == 0)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Cannot start playback because Channels == 0, stream {0}", remoteVoiceLink);
				}
				return false;
			}
			if (base.Logger.IsInfoEnabled)
			{
				base.Logger.LogInfo("Speaker about to start playback stream {0}, delay {1}", remoteVoiceLink, playbackDelaySettings);
			}
			AudioOutputStart(info.SamplingRate, info.Channels, info.FrameDurationSamples);
			remoteVoiceLink.FloatFrameDecoded += OnAudioFrame;
			PlaybackStarted = true;
			playbackExplicitlyStopped = false;
			return true;
		}

		protected virtual void AudioOutputStart(int frequency, int channels, int frameSamplesPerChannel)
		{
			audioOutput.Start(frequency, channels, frameSamplesPerChannel);
		}

		private void OnDestroy()
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("OnDestroy");
			}
			StopPlaying(force: true);
			CleanUp();
		}

		private bool StopPlaying(bool force = false)
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("StopPlaying");
			}
			if (!force && !PlaybackStarted)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Cannot stop playback because it's not started");
				}
				return false;
			}
			if (IsLinked)
			{
				remoteVoiceLink.FloatFrameDecoded -= OnAudioFrame;
			}
			else if (!force && base.Logger.IsWarningEnabled)
			{
				base.Logger.LogWarning("Speaker not linked while stopping playback");
			}
			if (IsInitialized)
			{
				AudioOutputStop();
			}
			else if (!force && base.Logger.IsWarningEnabled)
			{
				base.Logger.LogWarning("audioOutput is null while stopping playback");
			}
			PlaybackStarted = false;
			return true;
		}

		protected virtual void AudioOutputStop()
		{
			audioOutput.Stop();
		}

		private void CleanUp()
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("CleanUp");
			}
			if (remoteVoiceLink != null)
			{
				remoteVoiceLink.RemoteVoiceRemoved -= OnRemoteVoiceRemove;
				remoteVoiceLink = null;
			}
			Actor = null;
		}

		internal void Service()
		{
			if (PlaybackStarted)
			{
				AudioOutputService();
			}
		}

		protected virtual void AudioOutputService()
		{
			audioOutput.Service();
		}

		public bool StartPlayback()
		{
			return StartPlaying();
		}

		public bool StopPlayback()
		{
			if (playbackExplicitlyStopped)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Cannot stop playback because it was already been explicitly stopped.");
				}
				return false;
			}
			playbackExplicitlyStopped = StopPlaying();
			return playbackExplicitlyStopped;
		}

		public bool RestartPlayback(bool reinit = false)
		{
			if (!StopPlayback())
			{
				return false;
			}
			if (reinit)
			{
				audioOutput = null;
				Initialize();
			}
			return StartPlayback();
		}

		public bool SetPlaybackDelaySettings(PlaybackDelaySettings pdc)
		{
			return SetPlaybackDelaySettings(pdc.MinDelaySoft, pdc.MaxDelaySoft, pdc.MaxDelayHard);
		}

		public bool SetPlaybackDelaySettings(int low, int high, int max)
		{
			if (low >= 0 && low < high)
			{
				if (playbackDelaySettings.MaxDelaySoft != high || playbackDelaySettings.MinDelaySoft != low || playbackDelaySettings.MaxDelayHard != max)
				{
					if (max < high)
					{
						max = high;
					}
					playbackDelaySettings.MaxDelaySoft = high;
					playbackDelaySettings.MinDelaySoft = low;
					playbackDelaySettings.MaxDelayHard = max;
					if (IsPlaying)
					{
						RestartPlayback(reinit: true);
					}
					else if (IsInitialized)
					{
						audioOutput = null;
						Initialize();
					}
					return true;
				}
			}
			else if (base.Logger.IsErrorEnabled)
			{
				base.Logger.LogError("Wrong playback delay config values, make sure 0 <= Low < High, low={0}, high={1}, max={2}", low, high, max);
			}
			return false;
		}
	}
	[HelpURL("https://doc.photonengine.com/en-us/voice/v2")]
	public abstract class VoiceComponent : MonoBehaviour, ILoggableDependent, ILoggable
	{
		private VoiceLogger logger;

		[SerializeField]
		protected DebugLevel logLevel = DebugLevel.WARNING;

		[SerializeField]
		[HideInInspector]
		private bool ignoreGlobalLogLevel;

		private static string currentPlatform;

		public VoiceLogger Logger
		{
			get
			{
				if (logger == null)
				{
					logger = new VoiceLogger(this, $"{base.name}.{GetType().Name}", logLevel);
				}
				return logger;
			}
			protected set
			{
				logger = value;
			}
		}

		public DebugLevel LogLevel
		{
			get
			{
				if (Logger != null)
				{
					logLevel = Logger.LogLevel;
				}
				return logLevel;
			}
			set
			{
				logLevel = value;
				if (Logger != null)
				{
					Logger.LogLevel = logLevel;
				}
			}
		}

		public bool IgnoreGlobalLogLevel
		{
			get
			{
				return ignoreGlobalLogLevel;
			}
			set
			{
				ignoreGlobalLogLevel = value;
			}
		}

		public static string CurrentPlatform
		{
			get
			{
				if (string.IsNullOrEmpty(currentPlatform))
				{
					currentPlatform = Enum.GetName(typeof(RuntimePlatform), Application.platform);
				}
				return currentPlatform;
			}
		}

		protected virtual void Awake()
		{
			if (logger == null)
			{
				logger = new VoiceLogger(this, $"{base.name}.{GetType().Name}", logLevel);
			}
		}
	}
	[AddComponentMenu("Photon Voice/Voice Connection")]
	[DisallowMultipleComponent]
	[HelpURL("https://doc.photonengine.com/en-us/voice/v2/getting-started/voice-intro")]
	public class VoiceConnection : ConnectionHandler, ILoggable
	{
		public delegate bool ValidateRemoteLinkDelegate(RemoteVoiceLink link);

		private VoiceLogger logger;

		[SerializeField]
		private DebugLevel logLevel = DebugLevel.INFO;

		private const string PlayerPrefsKey = "VoiceCloudBestRegion";

		private LoadBalancingTransport client;

		[SerializeField]
		private bool enableSupportLogger;

		private SupportLogger supportLoggerComponent;

		[SerializeField]
		private int updateInterval = 50;

		private int nextSendTickCount;

		[SerializeField]
		private bool runInBackground = true;

		[SerializeField]
		private int statsResetInterval = 1000;

		private int nextStatsTickCount;

		private float statsReferenceTime;

		private int referenceFramesLost;

		private int referenceFramesReceived;

		[SerializeField]
		private GameObject speakerPrefab;

		private bool cleanedUp;

		protected List<RemoteVoiceLink> cachedRemoteVoices = new List<RemoteVoiceLink>();

		[SerializeField]
		[FormerlySerializedAs("PrimaryRecorder")]
		private Recorder primaryRecorder;

		private bool primaryRecorderInitialized;

		[SerializeField]
		private DebugLevel globalRecordersLogLevel = DebugLevel.INFO;

		[SerializeField]
		private DebugLevel globalSpeakersLogLevel = DebugLevel.INFO;

		[SerializeField]
		[HideInInspector]
		private int globalPlaybackDelay = 200;

		[SerializeField]
		private PlaybackDelaySettings globalPlaybackDelaySettings = new PlaybackDelaySettings
		{
			MinDelaySoft = 200,
			MaxDelaySoft = 400,
			MaxDelayHard = 1000
		};

		private List<Speaker> linkedSpeakers = new List<Speaker>();

		private List<Recorder> initializedRecorders = new List<Recorder>();

		public AppSettings Settings;

		public Func<int, byte, object, Speaker> SpeakerFactory;

		public ValidateRemoteLinkDelegate RemoteLinkValidator;

		public float MinimalTimeScaleToDispatchInFixedUpdate = -1f;

		public bool AutoCreateSpeakerIfNotFound = true;

		public int MaxDatagrams = 3;

		public bool SendAsap;

		public VoiceLogger Logger
		{
			get
			{
				if (logger == null)
				{
					logger = new VoiceLogger(this, $"{base.name}.{GetType().Name}", logLevel);
				}
				return logger;
			}
			protected set
			{
				logger = value;
			}
		}

		public DebugLevel LogLevel
		{
			get
			{
				if (Logger != null)
				{
					logLevel = Logger.LogLevel;
				}
				return logLevel;
			}
			set
			{
				logLevel = value;
				if (Logger != null)
				{
					Logger.LogLevel = logLevel;
				}
			}
		}

		public new LoadBalancingTransport Client
		{
			get
			{
				if (client == null)
				{
					client = new LoadBalancingTransport2(Logger);
					client.ClientType = ClientAppType.Voice;
					VoiceClient voiceClient = client.VoiceClient;
					voiceClient.OnRemoteVoiceInfoAction = (VoiceClient.RemoteVoiceInfoDelegate)Delegate.Combine(voiceClient.OnRemoteVoiceInfoAction, new VoiceClient.RemoteVoiceInfoDelegate(OnRemoteVoiceInfo));
					client.StateChanged += OnVoiceStateChanged;
					client.OpResponseReceived += OnOperationResponseReceived;
					base.Client = client;
					StartFallbackSendAckThread();
				}
				return client;
			}
		}

		public VoiceClient VoiceClient => Client.VoiceClient;

		public ClientState ClientState => Client.State;

		public float FramesReceivedPerSecond { get; private set; }

		public float FramesLostPerSecond { get; private set; }

		public float FramesLostPercent { get; private set; }

		public GameObject SpeakerPrefab
		{
			get
			{
				return speakerPrefab;
			}
			set
			{
				if (!(value != speakerPrefab))
				{
					return;
				}
				if ((object)value != null && (bool)value)
				{
					Speaker componentInChildren = value.GetComponentInChildren<Speaker>(includeInactive: true);
					if ((object)componentInChildren == null || !componentInChildren)
					{
						if (Logger.IsErrorEnabled)
						{
							Logger.LogError("SpeakerPrefab must have a component of type Speaker in its hierarchy.");
						}
						return;
					}
				}
				speakerPrefab = value;
			}
		}

		public Recorder PrimaryRecorder
		{
			get
			{
				if (!primaryRecorderInitialized)
				{
					TryInitializePrimaryRecorder();
				}
				return primaryRecorder;
			}
			set
			{
				primaryRecorder = value;
				primaryRecorderInitialized = false;
				TryInitializePrimaryRecorder();
			}
		}

		public DebugLevel GlobalRecordersLogLevel
		{
			get
			{
				return globalRecordersLogLevel;
			}
			set
			{
				globalRecordersLogLevel = value;
				for (int i = 0; i < initializedRecorders.Count; i++)
				{
					Recorder recorder = initializedRecorders[i];
					if (!recorder.IgnoreGlobalLogLevel)
					{
						recorder.LogLevel = globalRecordersLogLevel;
					}
				}
			}
		}

		public DebugLevel GlobalSpeakersLogLevel
		{
			get
			{
				return globalSpeakersLogLevel;
			}
			set
			{
				globalSpeakersLogLevel = value;
				for (int i = 0; i < linkedSpeakers.Count; i++)
				{
					Speaker speaker = linkedSpeakers[i];
					if (!speaker.IgnoreGlobalLogLevel)
					{
						speaker.LogLevel = globalSpeakersLogLevel;
					}
				}
			}
		}

		[Obsolete("Use SetGlobalPlaybackDelayConfiguration methods instead")]
		public int GlobalPlaybackDelay
		{
			get
			{
				return globalPlaybackDelaySettings.MinDelaySoft;
			}
			set
			{
				if (value >= 0 && value <= globalPlaybackDelaySettings.MaxDelaySoft)
				{
					globalPlaybackDelaySettings.MinDelaySoft = value;
				}
			}
		}

		public string BestRegionSummaryInPreferences
		{
			get
			{
				return PlayerPrefs.GetString("VoiceCloudBestRegion", null);
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					PlayerPrefs.DeleteKey("VoiceCloudBestRegion");
				}
				else
				{
					PlayerPrefs.SetString("VoiceCloudBestRegion", value);
				}
			}
		}

		public int GlobalPlaybackDelayMinSoft => globalPlaybackDelaySettings.MinDelaySoft;

		public int GlobalPlaybackDelayMaxSoft => globalPlaybackDelaySettings.MaxDelaySoft;

		public int GlobalPlaybackDelayMaxHard => globalPlaybackDelaySettings.MaxDelayHard;

		public event Action<Speaker> SpeakerLinked;

		public event Action<RemoteVoiceLink> RemoteVoiceAdded;

		public bool ConnectUsingSettings(AppSettings overwriteSettings = null)
		{
			if (Client.LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
			{
				if (Logger.IsWarningEnabled)
				{
					Logger.LogWarning("ConnectUsingSettings() failed. Can only connect while in state 'Disconnected'. Current state: {0}", Client.LoadBalancingPeer.PeerState);
				}
				return false;
			}
			if (ConnectionHandler.AppQuits)
			{
				if (Logger.IsWarningEnabled)
				{
					Logger.LogWarning("Can't connect: Application is closing. Unity called OnApplicationQuit().");
				}
				return false;
			}
			if (overwriteSettings != null)
			{
				Settings = overwriteSettings;
			}
			if (Settings == null)
			{
				if (Logger.IsErrorEnabled)
				{
					Logger.LogError("Settings are null");
				}
				return false;
			}
			if (string.IsNullOrEmpty(Settings.AppIdVoice) && string.IsNullOrEmpty(Settings.Server))
			{
				if (Logger.IsErrorEnabled)
				{
					Logger.LogError("Provide an AppId or a Server address in Settings to be able to connect");
				}
				return false;
			}
			if (Settings.IsMasterServerAddress && string.IsNullOrEmpty(Client.UserId))
			{
				Client.UserId = Guid.NewGuid().ToString();
			}
			if (string.IsNullOrEmpty(Settings.BestRegionSummaryFromStorage))
			{
				Settings.BestRegionSummaryFromStorage = BestRegionSummaryInPreferences;
			}
			return client.ConnectUsingSettings(Settings);
		}

		public void InitRecorder(Recorder rec)
		{
			if ((object)rec == null)
			{
				if (Logger.IsErrorEnabled)
				{
					Logger.LogError("rec is null.");
				}
			}
			else if (!rec)
			{
				if (Logger.IsErrorEnabled)
				{
					Logger.LogError("rec is destroyed.");
				}
			}
			else
			{
				rec.Init(this);
			}
		}

		public void SetPlaybackDelaySettings(PlaybackDelaySettings gpds)
		{
			SetGlobalPlaybackDelaySettings(gpds.MinDelaySoft, gpds.MaxDelaySoft, gpds.MaxDelayHard);
		}

		public void SetGlobalPlaybackDelaySettings(int low, int high, int max)
		{
			if (low >= 0 && low < high)
			{
				if (max < high)
				{
					max = high;
				}
				globalPlaybackDelaySettings.MinDelaySoft = low;
				globalPlaybackDelaySettings.MaxDelaySoft = high;
				globalPlaybackDelaySettings.MaxDelayHard = max;
				for (int i = 0; i < linkedSpeakers.Count; i++)
				{
					linkedSpeakers[i].SetPlaybackDelaySettings(globalPlaybackDelaySettings);
				}
			}
			else if (Logger.IsErrorEnabled)
			{
				Logger.LogError("Wrong playback delay config values, make sure 0 <= Low < High, low={0}, high={1}, max={2}", low, high, max);
			}
		}

		public virtual bool TryLateLinkingUsingUserData(Speaker speaker, object userData)
		{
			if ((object)speaker == null || !speaker)
			{
				if (Logger.IsWarningEnabled)
				{
					Logger.LogWarning("Speaker is null or destroyed.");
				}
				return false;
			}
			if (speaker.IsLinked)
			{
				if (Logger.IsWarningEnabled)
				{
					Logger.LogWarning("Speaker already linked.");
				}
				return false;
			}
			if (!Client.InRoom)
			{
				if (Logger.IsWarningEnabled)
				{
					Logger.LogWarning("Client not joined to a voice room, client state: {0}.", Enum.GetName(typeof(ClientState), ClientState));
				}
				return false;
			}
			if (TryGetFirstVoiceStreamByUserData(userData, out var remoteVoiceLink))
			{
				if (Logger.IsInfoEnabled)
				{
					Logger.LogInfo("Speaker 'late-linking' for remoteVoice {0}.", remoteVoiceLink);
				}
				LinkSpeaker(speaker, remoteVoiceLink);
				return speaker.IsLinked;
			}
			return false;
		}

		protected override void Awake()
		{
			base.Awake();
			if (enableSupportLogger)
			{
				supportLoggerComponent = base.gameObject.AddComponent<SupportLogger>();
				supportLoggerComponent.Client = Client;
				supportLoggerComponent.LogTrafficStats = true;
			}
			if (runInBackground)
			{
				Application.runInBackground = runInBackground;
			}
			if (!primaryRecorderInitialized)
			{
				TryInitializePrimaryRecorder();
			}
		}

		protected virtual void Update()
		{
			VoiceClient.Service();
			for (int i = 0; i < linkedSpeakers.Count; i++)
			{
				linkedSpeakers[i].Service();
			}
			for (int j = 0; j < initializedRecorders.Count; j++)
			{
				Recorder recorder = initializedRecorders[j];
				if (recorder.MicrophoneDeviceChangeDetected)
				{
					recorder.HandleDeviceChange();
				}
			}
		}

		protected virtual void FixedUpdate()
		{
			if (Time.timeScale > MinimalTimeScaleToDispatchInFixedUpdate)
			{
				Dispatch();
			}
		}

		protected void Dispatch()
		{
			bool flag = true;
			while (flag)
			{
				flag = Client.LoadBalancingPeer.DispatchIncomingCommands();
			}
		}

		private void LateUpdate()
		{
			if (Time.timeScale <= MinimalTimeScaleToDispatchInFixedUpdate)
			{
				Dispatch();
			}
			int num = (int)(Time.realtimeSinceStartup * 1000f);
			if (SendAsap || num > nextSendTickCount)
			{
				SendAsap = false;
				bool flag = true;
				int num2 = 0;
				while (flag && num2 < MaxDatagrams)
				{
					flag = Client.LoadBalancingPeer.SendOutgoingCommands();
					num2++;
				}
				nextSendTickCount = num + updateInterval;
			}
			if (num > nextStatsTickCount && statsResetInterval > 0)
			{
				CalcStatistics();
				nextStatsTickCount = num + statsResetInterval;
			}
		}

		protected override void OnDisable()
		{
			if (ConnectionHandler.AppQuits)
			{
				CleanUp();
				SupportClass.StopAllBackgroundCalls();
			}
		}

		protected virtual void OnDestroy()
		{
			CleanUp();
		}

		protected virtual Speaker SimpleSpeakerFactory(int playerId, byte voiceId, object userData)
		{
			Speaker speaker = null;
			bool flag = false;
			if ((object)SpeakerPrefab != null && (bool)SpeakerPrefab)
			{
				Speaker[] componentsInChildren = UnityEngine.Object.Instantiate(SpeakerPrefab).GetComponentsInChildren<Speaker>(includeInactive: true);
				if (componentsInChildren.Length != 0)
				{
					speaker = componentsInChildren[0];
					if (componentsInChildren.Length > 1 && Logger.IsWarningEnabled)
					{
						Logger.LogWarning("Multiple Speaker components found attached to the GameObject (VoiceConnection.SpeakerPrefab) or its children. Using the first one we found.");
					}
				}
				if ((object)speaker == null)
				{
					if (Logger.IsErrorEnabled)
					{
						Logger.LogError("Unexpected: SpeakerPrefab does not have a component of type Speaker in its hierarchy.");
					}
				}
				else
				{
					flag = true;
				}
			}
			if (!flag)
			{
				if (!AutoCreateSpeakerIfNotFound)
				{
					return null;
				}
				if (Logger.IsInfoEnabled)
				{
					Logger.LogInfo("Auto creating a new Speaker as none found");
				}
				speaker = new GameObject().AddComponent<Speaker>();
			}
			speaker.Actor = ((Client.CurrentRoom != null) ? Client.CurrentRoom.GetPlayer(playerId) : null);
			speaker.name = ((speaker.Actor != null && !string.IsNullOrEmpty(speaker.Actor.NickName)) ? speaker.Actor.NickName : $"Speaker for Player {playerId} Voice #{voiceId}");
			Speaker speaker2 = speaker;
			speaker2.OnRemoteVoiceRemoveAction = (Action<Speaker>)Delegate.Combine(speaker2.OnRemoteVoiceRemoveAction, new Action<Speaker>(DeleteVoiceOnRemoteVoiceRemove));
			return speaker;
		}

		internal void DeleteVoiceOnRemoteVoiceRemove(Speaker speaker)
		{
			if (speaker != null)
			{
				if (Logger.IsInfoEnabled)
				{
					Logger.LogInfo("Remote voice removed, delete speaker");
				}
				UnityEngine.Object.Destroy(speaker.gameObject);
			}
		}

		private void OnRemoteVoiceInfo(int channelId, int playerId, byte voiceId, VoiceInfo voiceInfo, ref RemoteVoiceOptions options)
		{
			RemoteVoiceLink remoteVoice = new RemoteVoiceLink(voiceInfo, playerId, voiceId, channelId);
			if (RemoteLinkValidator != null && !RemoteLinkValidator(remoteVoice))
			{
				return;
			}
			if (voiceInfo.Codec != Codec.AudioOpus)
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.LogInfo("OnRemoteVoiceInfo skipped as codec is not Opus, {0}", remoteVoice);
				}
				return;
			}
			remoteVoice.Init(ref options);
			if (Logger.IsInfoEnabled)
			{
				Logger.LogInfo("OnRemoteVoiceInfo {0}", remoteVoice);
			}
			for (int i = 0; i < cachedRemoteVoices.Count; i++)
			{
				RemoteVoiceLink remoteVoiceLink = cachedRemoteVoices[i];
				if (remoteVoiceLink.Equals(remoteVoice) && Logger.IsWarningEnabled)
				{
					Logger.LogWarning("Possible duplicate remoteVoiceInfo cached:{0} vs. received:{1}", remoteVoiceLink, remoteVoice);
				}
			}
			cachedRemoteVoices.Add(remoteVoice);
			if (this.RemoteVoiceAdded != null)
			{
				this.RemoteVoiceAdded(remoteVoice);
			}
			remoteVoice.RemoteVoiceRemoved += delegate
			{
				if (Logger.IsInfoEnabled)
				{
					Logger.LogInfo("RemoteVoiceRemoved {0}", remoteVoice);
				}
				if (!cachedRemoteVoices.Remove(remoteVoice) && Logger.IsWarningEnabled)
				{
					Logger.LogWarning("Cached remote voice not removed {0}", remoteVoice);
				}
			};
			Speaker speaker = null;
			if (SpeakerFactory != null)
			{
				speaker = SpeakerFactory(playerId, voiceId, voiceInfo.UserData);
			}
			if ((object)speaker == null)
			{
				speaker = SimpleSpeakerFactory(playerId, voiceId, voiceInfo.UserData);
			}
			else if (speaker.IsLinked)
			{
				if (Logger.IsWarningEnabled)
				{
					Logger.LogWarning("Overriding speaker link, old:{0} new:{1}", speaker.RemoteVoiceLink, remoteVoice);
				}
				speaker.OnRemoteVoiceRemove();
			}
			LinkSpeaker(speaker, remoteVoice);
		}

		protected virtual void OnVoiceStateChanged(ClientState fromState, ClientState toState)
		{
			if (Logger.IsDebugEnabled)
			{
				Logger.LogDebug("OnVoiceStateChanged from {0} to {1}", fromState, toState);
			}
			if (fromState == ClientState.Joined)
			{
				StopInitializedRecorders();
				ClearRemoteVoicesCache();
			}
			switch (toState)
			{
			case ClientState.ConnectedToMasterServer:
				if (Client.RegionHandler != null)
				{
					if (Settings != null)
					{
						Settings.BestRegionSummaryFromStorage = Client.RegionHandler.SummaryToCache;
					}
					BestRegionSummaryInPreferences = Client.RegionHandler.SummaryToCache;
				}
				break;
			case ClientState.Joined:
				StartInitializedRecorders();
				break;
			}
		}

		protected void CalcStatistics()
		{
			float time = Time.time;
			int num = VoiceClient.FramesReceived - referenceFramesReceived;
			int num2 = VoiceClient.FramesLost - referenceFramesLost;
			float num3 = time - statsReferenceTime;
			if (num3 > 0f)
			{
				if (num + num2 > 0)
				{
					FramesReceivedPerSecond = (float)num / num3;
					FramesLostPerSecond = (float)num2 / num3;
					FramesLostPercent = 100f * (float)num2 / (float)(num + num2);
				}
				else
				{
					FramesReceivedPerSecond = 0f;
					FramesLostPerSecond = 0f;
					FramesLostPercent = 0f;
				}
			}
			referenceFramesReceived = VoiceClient.FramesReceived;
			referenceFramesLost = VoiceClient.FramesLost;
			statsReferenceTime = time;
		}

		private void CleanUp()
		{
			bool flag = client != null;
			if (Logger.IsDebugEnabled)
			{
				Logger.LogDebug("Client exists? {0}, already cleaned up? {1}", flag, cleanedUp);
			}
			if (cleanedUp)
			{
				return;
			}
			StopFallbackSendAckThread();
			if (flag)
			{
				client.StateChanged -= OnVoiceStateChanged;
				client.OpResponseReceived -= OnOperationResponseReceived;
				client.Disconnect();
				if (client.LoadBalancingPeer != null)
				{
					client.LoadBalancingPeer.Disconnect();
					client.LoadBalancingPeer.StopThread();
				}
				client.Dispose();
			}
			cleanedUp = true;
		}

		protected void LinkSpeaker(Speaker speaker, RemoteVoiceLink remoteVoice)
		{
			if (speaker != null)
			{
				if (!speaker.IgnoreGlobalLogLevel)
				{
					speaker.LogLevel = GlobalSpeakersLogLevel;
				}
				speaker.SetPlaybackDelaySettings(globalPlaybackDelaySettings);
				if (!speaker.OnRemoteVoiceInfo(remoteVoice))
				{
					return;
				}
				if (speaker.Actor == null)
				{
					if (Client.CurrentRoom == null)
					{
						if (Logger.IsErrorEnabled)
						{
							Logger.LogError("RemoteVoiceInfo event received while CurrentRoom is null");
						}
					}
					else
					{
						Player player = Client.CurrentRoom.GetPlayer(remoteVoice.PlayerId);
						if (player == null)
						{
							if (Logger.IsErrorEnabled)
							{
								Logger.LogError("RemoteVoiceInfo event received while respective actor not found in the room, {0}", remoteVoice);
							}
						}
						else
						{
							speaker.Actor = player;
						}
					}
				}
				if (Logger.IsInfoEnabled)
				{
					Logger.LogInfo("Speaker linked with remote voice {0}", remoteVoice);
				}
				linkedSpeakers.Add(speaker);
				remoteVoice.RemoteVoiceRemoved += delegate
				{
					linkedSpeakers.Remove(speaker);
				};
				if (this.SpeakerLinked != null)
				{
					this.SpeakerLinked(speaker);
				}
			}
			else if (Logger.IsWarningEnabled)
			{
				Logger.LogWarning("Speaker is null. Remote voice {0} not linked.", remoteVoice);
			}
		}

		private void ClearRemoteVoicesCache()
		{
			if (cachedRemoteVoices.Count > 0)
			{
				if (Logger.IsInfoEnabled)
				{
					Logger.LogInfo("{0} cached remote voices info cleared", cachedRemoteVoices.Count);
				}
				cachedRemoteVoices.Clear();
			}
		}

		private void TryInitializePrimaryRecorder()
		{
			if (primaryRecorder != null)
			{
				if (!primaryRecorder.IsInitialized)
				{
					primaryRecorder.Init(this);
				}
				primaryRecorderInitialized = primaryRecorder.IsInitialized;
			}
		}

		internal void AddInitializedRecorder(Recorder rec)
		{
			initializedRecorders.Add(rec);
		}

		internal void RemoveInitializedRecorder(Recorder rec)
		{
			initializedRecorders.Remove(rec);
		}

		private void StartInitializedRecorders()
		{
			for (int i = 0; i < initializedRecorders.Count; i++)
			{
				initializedRecorders[i].CheckAndAutoStart();
			}
		}

		private void StopInitializedRecorders()
		{
			for (int i = 0; i < initializedRecorders.Count; i++)
			{
				Recorder recorder = initializedRecorders[i];
				if (recorder.IsRecording && recorder.RecordOnlyWhenJoined)
				{
					recorder.StopRecordingInternal();
				}
			}
		}

		private bool TryGetFirstVoiceStreamByUserData(object userData, out RemoteVoiceLink remoteVoiceLink)
		{
			remoteVoiceLink = null;
			if (userData == null)
			{
				return false;
			}
			if (Logger.IsWarningEnabled)
			{
				int num = 0;
				for (int i = 0; i < cachedRemoteVoices.Count; i++)
				{
					RemoteVoiceLink remoteVoiceLink2 = cachedRemoteVoices[i];
					if (!userData.Equals(remoteVoiceLink2.Info.UserData))
					{
						continue;
					}
					num++;
					if (num == 1)
					{
						remoteVoiceLink = remoteVoiceLink2;
						if (Logger.IsDebugEnabled)
						{
							Logger.LogWarning("(first) remote voice stream found by UserData:{0}", userData, remoteVoiceLink2);
						}
					}
					else
					{
						Logger.LogWarning("{0} remote voice stream found (so far) using same UserData:{0}", num, remoteVoiceLink2);
					}
				}
				return num > 0;
			}
			for (int j = 0; j < cachedRemoteVoices.Count; j++)
			{
				RemoteVoiceLink remoteVoiceLink3 = cachedRemoteVoices[j];
				if (userData.Equals(remoteVoiceLink3.Info.UserData))
				{
					remoteVoiceLink = remoteVoiceLink3;
					if (Logger.IsDebugEnabled)
					{
						Logger.LogWarning("(first) remote voice stream found by UserData:{0}", userData, remoteVoiceLink3);
					}
					return true;
				}
			}
			return false;
		}

		protected virtual void OnOperationResponseReceived(OperationResponse operationResponse)
		{
			if (Logger.IsErrorEnabled && operationResponse.ReturnCode != 0 && (operationResponse.OperationCode != 225 || operationResponse.ReturnCode == 32760))
			{
				Logger.LogError("Operation {0} response error code {1} message {2}", operationResponse.OperationCode, operationResponse.ReturnCode, operationResponse.DebugMessage);
			}
		}
	}
	public class VoiceLogger : ILogger
	{
		private readonly UnityEngine.Object context;

		public string Tag { get; set; }

		public DebugLevel LogLevel { get; set; }

		public bool IsErrorEnabled => (int)LogLevel >= 1;

		public bool IsWarningEnabled => (int)LogLevel >= 2;

		public bool IsInfoEnabled => (int)LogLevel >= 3;

		public bool IsDebugEnabled => LogLevel == DebugLevel.ALL;

		public VoiceLogger(UnityEngine.Object context, string tag, DebugLevel level = DebugLevel.ERROR)
		{
			this.context = context;
			Tag = tag;
			LogLevel = level;
		}

		public VoiceLogger(string tag, DebugLevel level = DebugLevel.ERROR)
		{
			Tag = tag;
			LogLevel = level;
		}

		public void LogError(string fmt, params object[] args)
		{
			if (IsErrorEnabled)
			{
				fmt = GetFormatString(fmt);
				if (context == null)
				{
					UnityEngine.Debug.LogErrorFormat(fmt, args);
				}
				else
				{
					UnityEngine.Debug.LogErrorFormat(context, fmt, args);
				}
			}
		}

		public void LogWarning(string fmt, params object[] args)
		{
			if (IsWarningEnabled)
			{
				fmt = GetFormatString(fmt);
				if (context == null)
				{
					UnityEngine.Debug.LogWarningFormat(fmt, args);
				}
				else
				{
					UnityEngine.Debug.LogWarningFormat(context, fmt, args);
				}
			}
		}

		public void LogInfo(string fmt, params object[] args)
		{
			if (IsInfoEnabled)
			{
				fmt = GetFormatString(fmt);
				if (context == null)
				{
					UnityEngine.Debug.LogFormat(fmt, args);
				}
				else
				{
					UnityEngine.Debug.LogFormat(context, fmt, args);
				}
			}
		}

		public void LogDebug(string fmt, params object[] args)
		{
			if (IsDebugEnabled)
			{
				LogInfo(fmt, args);
			}
		}

		private string GetFormatString(string fmt)
		{
			return $"[{Tag}] {GetTimestamp()}:{fmt}";
		}

		private string GetTimestamp()
		{
			return DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss", new CultureInfo("en-US"));
		}
	}
	[RequireComponent(typeof(Recorder))]
	[DisallowMultipleComponent]
	public class WebRtcAudioDsp : VoiceComponent
	{
		[SerializeField]
		private bool aec = true;

		[SerializeField]
		private bool aecHighPass;

		[SerializeField]
		private bool agc = true;

		[SerializeField]
		private int agcCompressionGain = 9;

		[SerializeField]
		private bool vad = true;

		[SerializeField]
		private bool highPass;

		[SerializeField]
		private bool bypass;

		[SerializeField]
		private bool noiseSuppression;

		[SerializeField]
		private int reverseStreamDelayMs = 120;

		private int reverseChannels;

		private WebRTCAudioProcessor proc;

		private AudioListener audioListener;

		private AudioOutCapture audioOutCapture;

		private bool aecStarted;

		private bool autoDestroyAudioOutCapture;

		private static readonly Dictionary<AudioSpeakerMode, int> channelsMap = new Dictionary<AudioSpeakerMode, int>
		{
			{
				AudioSpeakerMode.Mono,
				1
			},
			{
				AudioSpeakerMode.Stereo,
				2
			},
			{
				AudioSpeakerMode.Quad,
				4
			},
			{
				AudioSpeakerMode.Surround,
				5
			},
			{
				AudioSpeakerMode.Mode5point1,
				6
			},
			{
				AudioSpeakerMode.Mode7point1,
				8
			},
			{
				AudioSpeakerMode.Prologic,
				2
			}
		};

		private LocalVoiceAudioShort localVoice;

		private int outputSampleRate;

		private Recorder recorder;

		[SerializeField]
		private bool aecOnlyWhenEnabled = true;

		public bool AutoRestartOnAudioChannelsMismatch = true;

		private object threadSafety = new object();

		[Obsolete("Obsolete as it's not recommended to set this to true. https://forum.photonengine.com/discussion/comment/48017/#Comment_48017")]
		public bool AECMobileComfortNoise;

		public bool AEC
		{
			get
			{
				lock (threadSafety)
				{
					if (IsInitialized && (!aecOnlyWhenEnabled || base.isActiveAndEnabled))
					{
						return aecStarted;
					}
				}
				return aec;
			}
			set
			{
				if (value == aec)
				{
					return;
				}
				aec = value;
				lock (threadSafety)
				{
					ToggleAec();
				}
			}
		}

		[Obsolete("Use AEC instead on all platforms, internally according AEC will be used either mobile or not.")]
		public bool AECMobile
		{
			get
			{
				return AEC;
			}
			set
			{
				AEC = value;
			}
		}

		public bool AecHighPass
		{
			get
			{
				return aecHighPass;
			}
			set
			{
				if (value == aecHighPass)
				{
					return;
				}
				aecHighPass = value;
				lock (threadSafety)
				{
					if (IsInitialized)
					{
						proc.AECHighPass = aecHighPass;
					}
				}
			}
		}

		public int ReverseStreamDelayMs
		{
			get
			{
				return reverseStreamDelayMs;
			}
			set
			{
				if (reverseStreamDelayMs == value)
				{
					return;
				}
				reverseStreamDelayMs = value;
				lock (threadSafety)
				{
					if (IsInitialized)
					{
						proc.AECStreamDelayMs = reverseStreamDelayMs;
					}
				}
			}
		}

		public bool NoiseSuppression
		{
			get
			{
				return noiseSuppression;
			}
			set
			{
				if (value == noiseSuppression)
				{
					return;
				}
				noiseSuppression = value;
				lock (threadSafety)
				{
					if (IsInitialized)
					{
						proc.NoiseSuppression = noiseSuppression;
					}
				}
			}
		}

		public bool HighPass
		{
			get
			{
				return highPass;
			}
			set
			{
				if (value == highPass)
				{
					return;
				}
				highPass = value;
				lock (threadSafety)
				{
					if (IsInitialized)
					{
						proc.HighPass = highPass;
					}
				}
			}
		}

		public bool Bypass
		{
			get
			{
				return bypass;
			}
			set
			{
				if (value != bypass)
				{
					bypass = value;
					if (IsInitialized)
					{
						proc.Bypass = bypass;
					}
				}
			}
		}

		public bool AGC
		{
			get
			{
				return agc;
			}
			set
			{
				if (value == agc)
				{
					return;
				}
				agc = value;
				lock (threadSafety)
				{
					if (IsInitialized)
					{
						proc.AGC = agc;
					}
				}
			}
		}

		public int AgcCompressionGain
		{
			get
			{
				return agcCompressionGain;
			}
			set
			{
				if (agcCompressionGain == value)
				{
					return;
				}
				if (value < 0 || value > 90)
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("AgcCompressionGain value {0} not in range [0..90]", value);
					}
					return;
				}
				agcCompressionGain = value;
				lock (threadSafety)
				{
					if (IsInitialized)
					{
						proc.AGCCompressionGain = agcCompressionGain;
					}
				}
			}
		}

		public bool VAD
		{
			get
			{
				return vad;
			}
			set
			{
				if (value == vad)
				{
					return;
				}
				vad = value;
				lock (threadSafety)
				{
					if (IsInitialized)
					{
						proc.VAD = vad;
					}
				}
			}
		}

		public bool IsInitialized => proc != null;

		public bool AecOnlyWhenEnabled
		{
			get
			{
				return aecOnlyWhenEnabled;
			}
			set
			{
				if (aecOnlyWhenEnabled != value)
				{
					aecOnlyWhenEnabled = value;
					lock (threadSafety)
					{
						ToggleAec();
					}
				}
			}
		}

		protected override void Awake()
		{
			base.Awake();
			AudioSettings.OnAudioConfigurationChanged += OnAudioConfigurationChanged;
			if (!SupportedPlatformCheck())
			{
				return;
			}
			recorder = GetComponent<Recorder>();
			if ((object)recorder == null || !recorder)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("A Recorder component needs to be attached to the same GameObject");
				}
				base.enabled = false;
			}
			else if (!base.IgnoreGlobalLogLevel)
			{
				base.LogLevel = recorder.LogLevel;
			}
		}

		private void OnEnable()
		{
			lock (threadSafety)
			{
				if (!SupportedPlatformCheck())
				{
					return;
				}
				if (IsInitialized)
				{
					ToggleAec();
				}
				else if (recorder.IsRecording)
				{
					if (base.Logger.IsWarningEnabled)
					{
						base.Logger.LogWarning("WebRtcAudioDsp is added after recording has started, restarting recording to take effect");
					}
					recorder.RestartRecording(force: true);
				}
			}
		}

		private void OnDisable()
		{
			lock (threadSafety)
			{
				if (aecOnlyWhenEnabled && aecStarted)
				{
					ToggleAecOutputListener(on: false);
				}
			}
		}

		private bool SupportedPlatformCheck()
		{
			return true;
		}

		private void ToggleAec()
		{
			if (!IsInitialized || (aecOnlyWhenEnabled && !base.isActiveAndEnabled) || aec == aecStarted)
			{
				return;
			}
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("Toggling AEC to {0}", aec);
			}
			if (!ToggleAecOutputListener(aec))
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("AEC failed to be toggled to {0}", aec);
				}
			}
			else if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("AEC successfully toggled to {0}", aec);
			}
		}

		private bool ToggleAecOutputListener(bool on)
		{
			if (on != aecStarted)
			{
				if (on)
				{
					if (aecOnlyWhenEnabled && !base.isActiveAndEnabled)
					{
						if (base.Logger.IsErrorEnabled)
						{
							base.Logger.LogError("Could not start AEC because AecOnlyWhenEnabled is true and isActiveAndEnabled is false");
						}
						return false;
					}
					if ((object)audioOutCapture == null || !audioOutCapture)
					{
						if (!InitAudioOutCapture())
						{
							if (base.Logger.IsErrorEnabled)
							{
								base.Logger.LogError("Could not start AEC OutputListener because a valid AudioOutCapture could not be set.");
							}
							return false;
						}
					}
					else
					{
						if (!AudioOutCaptureChecks(audioOutCapture, listenerChecks: true))
						{
							if (base.Logger.IsErrorEnabled)
							{
								base.Logger.LogError("Could not start AEC OutputListener because AudioOutCapture provided is not valid.");
							}
							return false;
						}
						AudioListener component = audioOutCapture.GetComponent<AudioListener>();
						if (audioListener != component)
						{
							if (base.Logger.IsWarningEnabled)
							{
								base.Logger.LogWarning("Unexpected: AudioListener changed but AudioOutCapture did not.");
							}
							audioListener = component;
						}
					}
					if (IsInitialized)
					{
						StartAec();
					}
				}
				else
				{
					if (UnsubscribeFromAudioOutCapture(autoDestroyAudioOutCapture))
					{
						if (base.Logger.IsDebugEnabled)
						{
							base.Logger.LogDebug("AEC OutputListener stopped.");
						}
					}
					else if (base.Logger.IsWarningEnabled)
					{
						base.Logger.LogWarning("Unexpected: AudioOutCapture is null but aecStarted == true");
					}
					if (IsInitialized)
					{
						proc.AEC = false;
						proc.AECMobile = false;
					}
					else if (base.Logger.IsWarningEnabled)
					{
						base.Logger.LogWarning("Unexpected: proc is null but aecStarted was true.");
					}
					aecStarted = false;
				}
				return true;
			}
			return false;
		}

		private void StartAec()
		{
			proc.AECStreamDelayMs = reverseStreamDelayMs;
			proc.AECHighPass = aecHighPass;
			proc.AEC = true;
			proc.AECMobile = false;
			aecStarted = true;
			audioOutCapture.OnAudioFrame += OnAudioOutFrameFloat;
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("AEC OutputListener started.");
			}
		}

		private void OnAudioConfigurationChanged(bool deviceWasChanged)
		{
			lock (threadSafety)
			{
				if (!IsInitialized)
				{
					return;
				}
				bool flag = false;
				if (outputSampleRate != AudioSettings.outputSampleRate)
				{
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("AudioConfigChange: outputSampleRate from {0} to {1}. WebRtcAudioDsp will be restarted.", outputSampleRate, AudioSettings.outputSampleRate);
					}
					outputSampleRate = AudioSettings.outputSampleRate;
					flag = true;
				}
				if (reverseChannels != channelsMap[AudioSettings.speakerMode])
				{
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("AudioConfigChange: speakerMode channels from {0} to {1}. WebRtcAudioDsp will be restarted.", reverseChannels, channelsMap[AudioSettings.speakerMode]);
					}
					reverseChannels = channelsMap[AudioSettings.speakerMode];
					flag = true;
				}
				if (flag)
				{
					Restart();
				}
			}
		}

		private void OnAudioOutFrameFloat(float[] data, int outChannels)
		{
			lock (threadSafety)
			{
				if (!IsInitialized)
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("Unexpected: OnAudioOutFrame called while WebRtcAudioDsp is not initialized (proc == null).");
					}
					return;
				}
				if (!aecStarted && base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Unexpected: OnAudioOutFrame called while aecStarted is false.");
				}
				if (outChannels != reverseChannels)
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("Unexpected: OnAudioOutFrame channel count {0} != initialized {1}. Switching channels and restarting.", outChannels, reverseChannels);
					}
					if (AutoRestartOnAudioChannelsMismatch)
					{
						reverseChannels = outChannels;
						Restart();
					}
				}
				else
				{
					proc.OnAudioOutFrameFloat(data);
				}
			}
		}

		private void PhotonVoiceCreated(PhotonVoiceCreatedParams p)
		{
			lock (threadSafety)
			{
				if (!base.enabled)
				{
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("Skipped PhotonVoiceCreated message because component is disabled.");
					}
					return;
				}
				if (recorder != null && recorder.SourceType != Recorder.InputSourceType.Microphone && base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("WebRtcAudioDsp is better suited to be used with Microphone as Recorder Input Source Type.");
				}
				if (p.Voice.Info.Channels != 1)
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("Only mono audio signals supported. WebRtcAudioDsp component will be disabled.");
					}
					base.enabled = false;
				}
				else if (p.Voice is LocalVoiceAudioShort localVoiceAudioShort)
				{
					localVoice = localVoiceAudioShort;
					reverseChannels = channelsMap[AudioSettings.speakerMode];
					outputSampleRate = AudioSettings.outputSampleRate;
					Init();
					localVoice.AddPostProcessor(proc);
					ToggleAec();
				}
				else
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("Only short audio voice supported. WebRtcAudioDsp component will be disabled.");
					}
					base.enabled = false;
				}
			}
		}

		private void PhotonVoiceRemoved()
		{
			StopAllProcessing();
		}

		private void OnDestroy()
		{
			StopAllProcessing();
			AudioSettings.OnAudioConfigurationChanged -= OnAudioConfigurationChanged;
		}

		private void StopAllProcessing()
		{
			lock (threadSafety)
			{
				ToggleAecOutputListener(on: false);
				if (IsInitialized)
				{
					proc.Dispose();
					proc = null;
				}
				localVoice = null;
			}
		}

		private void Restart()
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("Restarting");
			}
			if (IsInitialized)
			{
				bool flag = false;
				if (aecStarted)
				{
					if (UnsubscribeFromAudioOutCapture(destroy: false))
					{
						if (base.Logger.IsDebugEnabled)
						{
							base.Logger.LogDebug("AEC OutputListener stopped.");
						}
						flag = true;
						aecStarted = false;
					}
					else if (base.Logger.IsWarningEnabled)
					{
						base.Logger.LogWarning("Unexpected: AudioOutCapture is null but aecStarted == true");
					}
				}
				proc.Dispose();
				proc = null;
				if (Init())
				{
					localVoice.AddPostProcessor(proc);
					if (flag)
					{
						StartAec();
					}
					if (base.Logger.IsInfoEnabled)
					{
						base.Logger.LogInfo("Restart complete successfully.");
					}
				}
				else if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Restart failed because processor could not be re initialized.");
				}
			}
			else if (base.Logger.IsErrorEnabled)
			{
				base.Logger.LogError("Cannot restart if not initialized.");
			}
		}

		private bool Init()
		{
			if (IsInitialized)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Already initialized");
				}
				return false;
			}
			proc = new WebRTCAudioProcessor(base.Logger, localVoice.Info.FrameSize, localVoice.Info.SamplingRate, localVoice.Info.Channels, outputSampleRate, reverseChannels);
			proc.HighPass = highPass;
			proc.NoiseSuppression = noiseSuppression;
			proc.AGC = agc;
			proc.AGCCompressionGain = agcCompressionGain;
			proc.VAD = vad;
			proc.Bypass = bypass;
			if (base.Logger.IsInfoEnabled)
			{
				base.Logger.LogInfo("Initialized");
			}
			return true;
		}

		private bool SetOrSwitchAudioListener(AudioListener listener, bool extraChecks, bool log = true)
		{
			if (extraChecks && !AudioListenerChecks(listener))
			{
				return false;
			}
			AudioOutCapture[] components = listener.GetComponents<AudioOutCapture>();
			if (components.Length > 1 && base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("{0} AudioOutCapture components attached to the same GameObject, is this expected?", components.Length);
			}
			for (int i = 0; i < components.Length; i++)
			{
				if (SetOrSwitchAudioOutCapture(components[i], extraChecks: false, log: false))
				{
					autoDestroyAudioOutCapture = false;
					return true;
				}
			}
			AudioOutCapture audioOutCapture = listener.gameObject.AddComponent<AudioOutCapture>();
			if (SetOrSwitchAudioOutCapture(audioOutCapture, extraChecks: false, log))
			{
				if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("AudioOutCapture component added to same GameObject as AudioListener.");
				}
				autoDestroyAudioOutCapture = true;
				return true;
			}
			UnityEngine.Object.Destroy(audioOutCapture);
			return false;
		}

		private bool SetOrSwitchAudioOutCapture(AudioOutCapture capture, bool extraChecks, bool log = true)
		{
			if (!AudioOutCaptureChecks(capture, extraChecks, log))
			{
				return false;
			}
			bool flag = aecStarted;
			bool flag2 = false;
			if ((object)audioOutCapture != null && (bool)audioOutCapture)
			{
				if (audioOutCapture != capture)
				{
					if (!UnsubscribeFromAudioOutCapture(autoDestroyAudioOutCapture))
					{
						if (base.Logger.IsErrorEnabled)
						{
							base.Logger.LogError("Could not unsubscribe from previous AudioOutCapture. Switching to a new one won't happen.");
						}
						return false;
					}
					flag2 = true;
				}
				else if (extraChecks)
				{
					if (log && base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("The same AudioOutCapture is being used already");
					}
					return false;
				}
			}
			audioOutCapture = capture;
			audioListener = capture.GetComponent<AudioListener>();
			if (flag && flag2)
			{
				audioOutCapture.OnAudioFrame += OnAudioOutFrameFloat;
			}
			return true;
		}

		private bool InitAudioOutCapture()
		{
			if ((object)audioOutCapture != null && (bool)audioOutCapture)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("AudioOutCapture is already initialized.");
				}
				return false;
			}
			if ((object)audioListener == null)
			{
				AudioOutCapture[] array = UnityEngine.Object.FindObjectsOfType<AudioOutCapture>();
				if (array.Length > 1 && base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("{0} AudioOutCapture components found, is this expected?", array.Length);
				}
				foreach (AudioOutCapture capture in array)
				{
					if (SetOrSwitchAudioOutCapture(capture, extraChecks: true, log: false))
					{
						autoDestroyAudioOutCapture = false;
						return true;
					}
				}
				AudioListener[] array2 = UnityEngine.Object.FindObjectsOfType<AudioListener>();
				if (array2.Length == 0)
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("No AudioListener component found, is this expected?");
					}
				}
				else if (array2.Length > 1 && base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("{0} AudioListener components found, is this expected?", array2.Length);
				}
				foreach (AudioListener listener in array2)
				{
					if (SetOrSwitchAudioListener(listener, extraChecks: true, log: false))
					{
						return true;
					}
				}
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("AudioListener and AudioOutCapture components are required for AEC to work.");
				}
				return false;
			}
			return SetOrSwitchAudioListener(audioListener, extraChecks: true);
		}

		private bool UnsubscribeFromAudioOutCapture(bool destroy)
		{
			if ((object)audioOutCapture != null)
			{
				if (aecStarted)
				{
					audioOutCapture.OnAudioFrame -= OnAudioOutFrameFloat;
					if (base.Logger.IsDebugEnabled)
					{
						base.Logger.LogDebug("OnAudioFrame event unsubscribed.");
					}
				}
				if (destroy)
				{
					UnityEngine.Object.Destroy(audioOutCapture);
					if (base.Logger.IsDebugEnabled)
					{
						base.Logger.LogDebug("AudioOutCapture component destroyed.");
					}
					audioOutCapture = null;
				}
				return true;
			}
			if (aecStarted && base.Logger.IsErrorEnabled)
			{
				base.Logger.LogError("Unexpected: audioOutCapture is null but aecStarted is true");
			}
			return false;
		}

		private bool AudioListenerChecks(AudioListener listener, bool log = true)
		{
			if ((object)listener == null)
			{
				if (log && base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("AudioListener is null.");
				}
				return false;
			}
			if (!listener)
			{
				if (log && base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("AudioListener is destroyed.");
				}
				return false;
			}
			if (!listener.gameObject.activeInHierarchy)
			{
				if (log && base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("The GameObject to which the AudioListener is attached is not active in hierarchy.");
				}
				return false;
			}
			if (!listener.enabled)
			{
				if (log && base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("AudioListener is disabled.");
				}
				return false;
			}
			return true;
		}

		private bool AudioOutCaptureChecks(AudioOutCapture capture, bool listenerChecks, bool log = true)
		{
			if ((object)capture == null)
			{
				if (log && base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("AudioOutCapture is null.");
				}
				return false;
			}
			if (!capture)
			{
				if (log && base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("AudioOutCapture is destroyed.");
				}
				return false;
			}
			if (!listenerChecks && !capture.gameObject.activeInHierarchy)
			{
				if (log && base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("The GameObject to which the AudioOutCapture is attached is not active in hierarchy.");
				}
				return false;
			}
			if (!capture.enabled)
			{
				if (log && base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("AudioOutCapture is disabled.");
				}
				return false;
			}
			if (listenerChecks)
			{
				return AudioListenerChecks(capture.GetComponent<AudioListener>(), log);
			}
			return true;
		}

		public bool SetOrSwitchAudioListener(AudioListener listener)
		{
			lock (threadSafety)
			{
				return SetOrSwitchAudioListener(listener, extraChecks: true);
			}
		}

		public bool SetOrSwitchAudioOutCapture(AudioOutCapture capture)
		{
			lock (threadSafety)
			{
				if (SetOrSwitchAudioOutCapture(capture, extraChecks: true))
				{
					autoDestroyAudioOutCapture = false;
					return true;
				}
				return false;
			}
		}
	}
}
namespace Photon.Voice.Unity.UtilityScripts
{
	[RequireComponent(typeof(VoiceConnection))]
	public class ConnectAndJoin : MonoBehaviour, IConnectionCallbacks, IMatchmakingCallbacks
	{
		private VoiceConnection voiceConnection;

		public bool RandomRoom = true;

		[SerializeField]
		private bool autoConnect = true;

		[SerializeField]
		private bool autoTransmit = true;

		[SerializeField]
		private bool publishUserId;

		public string RoomName;

		private readonly EnterRoomParams enterRoomParams = new EnterRoomParams
		{
			RoomOptions = new RoomOptions()
		};

		public bool IsConnected => voiceConnection.Client.IsConnected;

		private void Awake()
		{
			voiceConnection = GetComponent<VoiceConnection>();
		}

		private void OnEnable()
		{
			voiceConnection.Client.AddCallbackTarget(this);
			if (autoConnect)
			{
				ConnectNow();
			}
		}

		private void OnDisable()
		{
			voiceConnection.Client.RemoveCallbackTarget(this);
		}

		public void ConnectNow()
		{
			voiceConnection.ConnectUsingSettings();
		}

		public void OnCreatedRoom()
		{
		}

		public void OnCreateRoomFailed(short returnCode, string message)
		{
			UnityEngine.Debug.LogErrorFormat("OnCreateRoomFailed errorCode={0} errorMessage={1}", returnCode, message);
		}

		public void OnFriendListUpdate(List<FriendInfo> friendList)
		{
		}

		public void OnJoinedRoom()
		{
			if (voiceConnection.PrimaryRecorder == null)
			{
				voiceConnection.PrimaryRecorder = base.gameObject.AddComponent<Recorder>();
			}
			if (autoTransmit)
			{
				voiceConnection.PrimaryRecorder.TransmitEnabled = autoTransmit;
			}
		}

		public void OnJoinRandomFailed(short returnCode, string message)
		{
			UnityEngine.Debug.LogErrorFormat("OnJoinRandomFailed errorCode={0} errorMessage={1}", returnCode, message);
		}

		public void OnJoinRoomFailed(short returnCode, string message)
		{
			UnityEngine.Debug.LogErrorFormat("OnJoinRoomFailed roomName={0} errorCode={1} errorMessage={2}", RoomName, returnCode, message);
		}

		public void OnLeftRoom()
		{
		}

		public void OnPreLeavingRoom()
		{
		}

		public void OnConnected()
		{
		}

		public void OnConnectedToMaster()
		{
			enterRoomParams.RoomOptions.PublishUserId = publishUserId;
			if (RandomRoom)
			{
				enterRoomParams.RoomName = null;
				voiceConnection.Client.OpJoinRandomOrCreateRoom(new OpJoinRandomRoomParams(), enterRoomParams);
			}
			else
			{
				enterRoomParams.RoomName = RoomName;
				voiceConnection.Client.OpJoinOrCreateRoom(enterRoomParams);
			}
		}

		public void OnDisconnected(DisconnectCause cause)
		{
			if (cause != DisconnectCause.None && cause != DisconnectCause.DisconnectByClientLogic)
			{
				UnityEngine.Debug.LogErrorFormat("OnDisconnected cause={0}", cause);
			}
		}

		public void OnRegionListReceived(RegionHandler regionHandler)
		{
		}

		public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
		{
		}

		public void OnCustomAuthenticationFailed(string debugMessage)
		{
		}
	}
	[RequireComponent(typeof(Recorder))]
	public class MicAmplifier : VoiceComponent
	{
		[SerializeField]
		private float boostValue;

		[SerializeField]
		private float amplificationFactor = 1f;

		private MicAmplifierFloat floatProcessor;

		private MicAmplifierShort shortProcessor;

		public float AmplificationFactor
		{
			get
			{
				return amplificationFactor;
			}
			set
			{
				if (!amplificationFactor.Equals(value))
				{
					amplificationFactor = value;
					if (floatProcessor != null)
					{
						floatProcessor.AmplificationFactor = amplificationFactor;
					}
					if (shortProcessor != null)
					{
						shortProcessor.AmplificationFactor = (short)amplificationFactor;
					}
				}
			}
		}

		public float BoostValue
		{
			get
			{
				return boostValue;
			}
			set
			{
				if (!boostValue.Equals(value))
				{
					boostValue = value;
					if (floatProcessor != null)
					{
						floatProcessor.BoostValue = boostValue;
					}
					if (shortProcessor != null)
					{
						shortProcessor.BoostValue = (short)boostValue;
					}
				}
			}
		}

		private void OnEnable()
		{
			if (floatProcessor != null)
			{
				floatProcessor.Disabled = false;
			}
			if (shortProcessor != null)
			{
				shortProcessor.Disabled = false;
			}
		}

		private void OnDisable()
		{
			if (floatProcessor != null)
			{
				floatProcessor.Disabled = true;
			}
			if (shortProcessor != null)
			{
				shortProcessor.Disabled = true;
			}
		}

		private void PhotonVoiceCreated(PhotonVoiceCreatedParams p)
		{
			if (p.Voice is LocalVoiceAudioFloat)
			{
				LocalVoiceAudioFloat obj = p.Voice as LocalVoiceAudioFloat;
				floatProcessor = new MicAmplifierFloat(AmplificationFactor, BoostValue);
				obj.AddPostProcessor(floatProcessor);
			}
			else if (p.Voice is LocalVoiceAudioShort)
			{
				LocalVoiceAudioShort obj2 = p.Voice as LocalVoiceAudioShort;
				shortProcessor = new MicAmplifierShort((short)AmplificationFactor, (short)BoostValue);
				obj2.AddPostProcessor(shortProcessor);
			}
			else if (base.Logger.IsErrorEnabled)
			{
				base.Logger.LogError("LocalVoice object has unexpected value/type: {0}", (p.Voice == null) ? "null" : p.Voice.GetType().ToString());
			}
		}
	}
	public class MicAmplifierFloat : IProcessor<float>, IDisposable
	{
		public float AmplificationFactor { get; set; }

		public float BoostValue { get; set; }

		public float MaxBefore { get; private set; }

		public float MaxAfter { get; private set; }

		public bool Disabled { get; set; }

		public MicAmplifierFloat(float amplificationFactor, float boostValue)
		{
			AmplificationFactor = amplificationFactor;
			BoostValue = boostValue;
		}

		public float[] Process(float[] buf)
		{
			if (Disabled)
			{
				return buf;
			}
			for (int i = 0; i < buf.Length; i++)
			{
				float num = buf[i];
				buf[i] *= AmplificationFactor;
				buf[i] += BoostValue;
				if (MaxBefore < num)
				{
					MaxBefore = num;
					MaxAfter = buf[i];
				}
			}
			return buf;
		}

		public void Dispose()
		{
		}
	}
	public class MicAmplifierShort : IProcessor<short>, IDisposable
	{
		public short AmplificationFactor { get; set; }

		public short BoostValue { get; set; }

		public short MaxBefore { get; private set; }

		public short MaxAfter { get; private set; }

		public bool Disabled { get; set; }

		public MicAmplifierShort(short amplificationFactor, short boostValue)
		{
			AmplificationFactor = amplificationFactor;
			BoostValue = boostValue;
		}

		public short[] Process(short[] buf)
		{
			if (Disabled)
			{
				return buf;
			}
			for (int i = 0; i < buf.Length; i++)
			{
				short num = buf[i];
				buf[i] *= AmplificationFactor;
				buf[i] += BoostValue;
				if (MaxBefore < num)
				{
					MaxBefore = num;
					MaxAfter = buf[i];
				}
			}
			return buf;
		}

		public void Dispose()
		{
		}
	}
	[RequireComponent(typeof(Recorder))]
	public class MicrophonePermission : VoiceComponent
	{
		private Recorder recorder;

		private bool hasPermission;

		[SerializeField]
		private bool autoStart = true;

		public bool HasPermission
		{
			get
			{
				return hasPermission;
			}
			private set
			{
				base.Logger.LogInfo("Microphone Permission Granted: {0}", value);
				MicrophonePermission.MicrophonePermissionCallback?.Invoke(value);
				if (hasPermission != value)
				{
					hasPermission = value;
					if (hasPermission)
					{
						recorder.AutoStart = autoStart;
					}
				}
			}
		}

		public static event Action<bool> MicrophonePermissionCallback;

		protected override void Awake()
		{
			base.Awake();
			recorder = GetComponent<Recorder>();
			recorder.AutoStart = false;
			InitVoice();
		}

		public void InitVoice()
		{
			HasPermission = true;
		}
	}
	[RequireComponent(typeof(VoiceConnection))]
	public class PhotonVoiceLagSimulationGui : MonoBehaviour
	{
		private VoiceConnection voiceConnection;

		private Rect windowRect = new Rect(0f, 100f, 200f, 100f);

		private int windowId = 201;

		private bool visible = true;

		private PhotonPeer peer;

		private float debugLostPercent;

		public void OnEnable()
		{
			VoiceConnection[] components = GetComponents<VoiceConnection>();
			if (components == null || components.Length == 0)
			{
				UnityEngine.Debug.LogError("No VoiceConnection component found, PhotonVoiceStatsGui disabled", this);
				base.enabled = false;
				return;
			}
			if (components.Length > 1)
			{
				UnityEngine.Debug.LogWarningFormat(this, "Multiple VoiceConnection components found, using first occurrence attached to GameObject {0}", components[0].name);
			}
			voiceConnection = components[0];
			peer = voiceConnection.Client.LoadBalancingPeer;
			debugLostPercent = voiceConnection.VoiceClient.DebugLostPercent;
		}

		private void OnGUI()
		{
			if (visible)
			{
				if (peer == null)
				{
					windowRect = GUILayout.Window(windowId, windowRect, NetSimHasNoPeerWindow, "Voice Network Simulation");
				}
				else
				{
					windowRect = GUILayout.Window(windowId, windowRect, NetSimWindow, "Voice Network Simulation");
				}
			}
		}

		private void NetSimHasNoPeerWindow(int windowId)
		{
			GUILayout.Label("No voice peer to communicate with. ");
		}

		private void NetSimWindow(int windowId)
		{
			GUILayout.Label($"Rtt:{peer.RoundTripTime,4} +/-{peer.RoundTripTimeVariance,3}");
			bool isSimulationEnabled = peer.IsSimulationEnabled;
			bool flag = GUILayout.Toggle(isSimulationEnabled, "Simulate");
			if (flag != isSimulationEnabled)
			{
				peer.IsSimulationEnabled = flag;
			}
			float num = peer.NetworkSimulationSettings.IncomingLag;
			GUILayout.Label($"Lag {num}");
			num = GUILayout.HorizontalSlider(num, 0f, 500f);
			peer.NetworkSimulationSettings.IncomingLag = (int)num;
			peer.NetworkSimulationSettings.OutgoingLag = (int)num;
			float num2 = peer.NetworkSimulationSettings.IncomingJitter;
			GUILayout.Label($"Jit {num2}");
			num2 = GUILayout.HorizontalSlider(num2, 0f, 100f);
			peer.NetworkSimulationSettings.IncomingJitter = (int)num2;
			peer.NetworkSimulationSettings.OutgoingJitter = (int)num2;
			float num3 = peer.NetworkSimulationSettings.IncomingLossPercentage;
			GUILayout.Label($"Loss {num3}");
			num3 = GUILayout.HorizontalSlider(num3, 0f, 10f);
			peer.NetworkSimulationSettings.IncomingLossPercentage = (int)num3;
			peer.NetworkSimulationSettings.OutgoingLossPercentage = (int)num3;
			GUILayout.Label($"Lost Audio Frames {(int)debugLostPercent}%");
			debugLostPercent = GUILayout.HorizontalSlider(debugLostPercent, 0f, 100f);
			if (flag)
			{
				voiceConnection.VoiceClient.DebugLostPercent = (int)debugLostPercent;
			}
			else
			{
				voiceConnection.VoiceClient.DebugLostPercent = 0;
			}
			if (GUI.changed)
			{
				windowRect.height = 100f;
			}
			GUI.DragWindow();
		}
	}
	public class PhotonVoiceStatsGui : MonoBehaviour
	{
		private bool statsWindowOn = true;

		private bool statsOn;

		private bool healthStatsVisible;

		private bool trafficStatsOn;

		private bool buttonsOn;

		private bool voiceStatsOn = true;

		private Rect statsRect = new Rect(0f, 100f, 300f, 50f);

		private int windowId = 200;

		private PhotonPeer peer;

		private VoiceConnection voiceConnection;

		private VoiceClient voiceClient;

		private void OnEnable()
		{
			VoiceConnection[] components = GetComponents<VoiceConnection>();
			if (components == null || components.Length == 0)
			{
				UnityEngine.Debug.LogError("No VoiceConnection component found, PhotonVoiceStatsGui disabled", this);
				base.enabled = false;
				return;
			}
			if (components.Length > 1)
			{
				UnityEngine.Debug.LogWarningFormat(this, "Multiple VoiceConnection components found, using first occurrence attached to GameObject {0}", components[0].name);
			}
			voiceConnection = components[0];
			voiceClient = voiceConnection.VoiceClient;
			peer = voiceConnection.Client.LoadBalancingPeer;
			if (statsRect.x <= 0f)
			{
				statsRect.x = (float)Screen.width - statsRect.width;
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
			{
				statsWindowOn = !statsWindowOn;
				statsOn = true;
			}
		}

		private void OnGUI()
		{
			if (peer.TrafficStatsEnabled != statsOn)
			{
				peer.TrafficStatsEnabled = statsOn;
			}
			if (statsWindowOn)
			{
				statsRect = GUILayout.Window(windowId, statsRect, TrafficStatsWindow, "Voice Client Messages (shift+tab)");
			}
		}

		private void TrafficStatsWindow(int windowId)
		{
			bool flag = false;
			TrafficStatsGameLevel trafficStatsGameLevel = peer.TrafficStatsGameLevel;
			long num = peer.TrafficStatsElapsedMs / 1000;
			if (num == 0L)
			{
				num = 1L;
			}
			GUILayout.BeginHorizontal();
			buttonsOn = GUILayout.Toggle(buttonsOn, "buttons");
			healthStatsVisible = GUILayout.Toggle(healthStatsVisible, "health");
			trafficStatsOn = GUILayout.Toggle(trafficStatsOn, "traffic");
			voiceStatsOn = GUILayout.Toggle(voiceStatsOn, "voice stats");
			GUILayout.EndHorizontal();
			string text = $"Out {trafficStatsGameLevel.TotalOutgoingMessageCount,4} | In {trafficStatsGameLevel.TotalIncomingMessageCount,4} | Sum {trafficStatsGameLevel.TotalMessageCount,4}";
			string text2 = $"{num}sec average:";
			string text3 = $"Out {trafficStatsGameLevel.TotalOutgoingMessageCount / num,4} | In {trafficStatsGameLevel.TotalIncomingMessageCount / num,4} | Sum {trafficStatsGameLevel.TotalMessageCount / num,4}";
			GUILayout.Label(text);
			GUILayout.Label(text2);
			GUILayout.Label(text3);
			if (buttonsOn)
			{
				GUILayout.BeginHorizontal();
				statsOn = GUILayout.Toggle(statsOn, "stats on");
				if (GUILayout.Button("Reset"))
				{
					peer.TrafficStatsReset();
					peer.TrafficStatsEnabled = true;
				}
				flag = GUILayout.Button("To Log");
				GUILayout.EndHorizontal();
			}
			string text4 = string.Empty;
			string text5 = string.Empty;
			if (trafficStatsOn)
			{
				GUILayout.Box("Voice Client Traffic Stats");
				text4 = "Incoming: \n" + peer.TrafficStatsIncoming;
				text5 = "Outgoing: \n" + peer.TrafficStatsOutgoing;
				GUILayout.Label(text4);
				GUILayout.Label(text5);
			}
			string text6 = string.Empty;
			if (healthStatsVisible)
			{
				GUILayout.Box("Voice Client Health Stats");
				text6 = string.Format("ping: {6}|{9}[+/-{7}|{10}]ms resent:{8} \n\nmax ms between\nsend: {0,4} \ndispatch: {1,4} \n\nlongest dispatch for: \nev({3}):{2,3}ms \nop({5}):{4,3}ms", trafficStatsGameLevel.LongestDeltaBetweenSending, trafficStatsGameLevel.LongestDeltaBetweenDispatching, trafficStatsGameLevel.LongestEventCallback, trafficStatsGameLevel.LongestEventCallbackCode, trafficStatsGameLevel.LongestOpResponseCallback, trafficStatsGameLevel.LongestOpResponseCallbackOpCode, peer.RoundTripTime, peer.RoundTripTimeVariance, peer.ResentReliableCommands, voiceClient.RoundTripTime, voiceClient.RoundTripTimeVariance);
				GUILayout.Label(text6);
			}
			_ = string.Empty;
			if (voiceStatsOn)
			{
				GUILayout.Box("Voice Frames Stats");
				GUILayout.Label($"received: {voiceClient.FramesReceived}, {voiceConnection.FramesReceivedPerSecond:F2}/s \n\nlost: {voiceClient.FramesLost}, {voiceConnection.FramesLostPerSecond:F2}/s ({voiceConnection.FramesLostPercent:F2}%) \n\nsent: {voiceClient.FramesSent} ({voiceClient.FramesSentBytes} bytes)");
			}
			if (flag)
			{
				UnityEngine.Debug.Log($"{text}\n{text2}\n{text3}\n{text4}\n{text5}\n{text6}");
			}
			if (GUI.changed)
			{
				statsRect.height = 100f;
			}
			GUI.DragWindow();
		}
	}
	[RequireComponent(typeof(VoiceConnection))]
	[DisallowMultipleComponent]
	public class SaveIncomingStreamToFile : VoiceComponent
	{
		private VoiceConnection voiceConnection;

		[SerializeField]
		private bool muteLocalSpeaker;

		protected override void Awake()
		{
			base.Awake();
			voiceConnection = GetComponent<VoiceConnection>();
			voiceConnection.RemoteVoiceAdded += OnRemoteVoiceAdded;
			voiceConnection.SpeakerLinked += OnSpeakerLinked;
		}

		private void OnSpeakerLinked(Speaker speaker)
		{
			if (muteLocalSpeaker && speaker.Actor != null && speaker.Actor.IsLocal)
			{
				AudioSource component = speaker.GetComponent<AudioSource>();
				component.mute = true;
				component.volume = 0f;
			}
		}

		private void OnDestroy()
		{
			voiceConnection.SpeakerLinked -= OnSpeakerLinked;
			voiceConnection.RemoteVoiceAdded -= OnRemoteVoiceAdded;
		}

		private void OnRemoteVoiceAdded(RemoteVoiceLink remoteVoiceLink)
		{
			int bits = 32;
			string filePath = GetFilePath(remoteVoiceLink);
			if (base.Logger.IsInfoEnabled)
			{
				base.Logger.LogInfo("Incoming stream, output file path: {0}", filePath);
			}
			WaveWriter waveWriter = new WaveWriter(filePath, new WaveFormat(remoteVoiceLink.Info.SamplingRate, bits, remoteVoiceLink.Info.Channels));
			remoteVoiceLink.FloatFrameDecoded += delegate(FrameOut<float> f)
			{
				waveWriter.WriteSamples(f.Buf, 0, f.Buf.Length);
			};
			remoteVoiceLink.RemoteVoiceRemoved += delegate
			{
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Remote voice stream removed: Saving wav file.");
				}
				waveWriter.Dispose();
			};
		}

		private string GetFilePath(RemoteVoiceLink remoteVoiceLink)
		{
			string path = string.Format("in_{0}_{1}_{2}_{3}_{4}.wav", DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-ffff"), UnityEngine.Random.Range(0, 1000), remoteVoiceLink.ChannelId, remoteVoiceLink.PlayerId, remoteVoiceLink.VoiceId);
			return Path.Combine(Application.persistentDataPath, path);
		}
	}
	[RequireComponent(typeof(Recorder))]
	[DisallowMultipleComponent]
	public class SaveOutgoingStreamToFile : VoiceComponent
	{
		private class OutgoingStreamSaverFloat : IProcessor<float>, IDisposable
		{
			private WaveWriter wavWriter;

			public OutgoingStreamSaverFloat(WaveWriter waveWriter)
			{
				wavWriter = waveWriter;
			}

			public float[] Process(float[] buf)
			{
				wavWriter.WriteSamples(buf, 0, buf.Length);
				return buf;
			}

			public void Dispose()
			{
				if (!wavWriter.IsDisposed && !wavWriter.IsDisposing)
				{
					wavWriter.Dispose();
				}
			}
		}

		private class OutgoingStreamSaverShort : IProcessor<short>, IDisposable
		{
			private WaveWriter wavWriter;

			public OutgoingStreamSaverShort(WaveWriter waveWriter)
			{
				wavWriter = waveWriter;
			}

			public short[] Process(short[] buf)
			{
				for (int i = 0; i < buf.Length; i++)
				{
					wavWriter.Write(buf[i]);
				}
				return buf;
			}

			public void Dispose()
			{
				if (!wavWriter.IsDisposed && !wavWriter.IsDisposing)
				{
					wavWriter.Dispose();
				}
			}
		}

		private WaveWriter wavWriter;

		private void PhotonVoiceCreated(PhotonVoiceCreatedParams photonVoiceCreatedParams)
		{
			VoiceInfo info = photonVoiceCreatedParams.Voice.Info;
			int bits = 32;
			if (photonVoiceCreatedParams.Voice is LocalVoiceAudioShort)
			{
				bits = 16;
			}
			string filePath = GetFilePath();
			wavWriter = new WaveWriter(filePath, new WaveFormat(info.SamplingRate, bits, info.Channels));
			if (base.Logger.IsInfoEnabled)
			{
				base.Logger.LogInfo("Outgoing stream, output file path: {0}", filePath);
			}
			if (photonVoiceCreatedParams.Voice is LocalVoiceAudioFloat)
			{
				(photonVoiceCreatedParams.Voice as LocalVoiceAudioFloat).AddPreProcessor(new OutgoingStreamSaverFloat(wavWriter));
			}
			else if (photonVoiceCreatedParams.Voice is LocalVoiceAudioShort)
			{
				(photonVoiceCreatedParams.Voice as LocalVoiceAudioShort).AddPreProcessor(new OutgoingStreamSaverShort(wavWriter));
			}
		}

		private string GetFilePath()
		{
			string path = string.Format("out_{0}_{1}.wav", DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-ffff"), UnityEngine.Random.Range(0, 1000));
			return Path.Combine(Application.persistentDataPath, path);
		}

		private void PhotonVoiceRemoved()
		{
			wavWriter.Dispose();
			if (base.Logger.IsInfoEnabled)
			{
				base.Logger.LogInfo("Recording stopped: Saving wav file.");
			}
		}
	}
	[RequireComponent(typeof(Recorder))]
	public class TestTone : MonoBehaviour
	{
		private void Start()
		{
			Recorder component = base.gameObject.GetComponent<Recorder>();
			component.SourceType = Recorder.InputSourceType.Factory;
			component.InputFactory = () => new ToneAudioReader();
		}
	}
	internal class ToneAudioReader : IAudioReader<float>, IDataReader<float>, IDisposable, IAudioDesc
	{
		private double k;

		private long timeSamples;

		public int Channels => 2;

		public int SamplingRate => 24000;

		public string Error => null;

		public ToneAudioReader()
		{
			k = Math.PI * 880.0 / (double)SamplingRate;
		}

		public void Dispose()
		{
		}

		public bool Read(float[] buf)
		{
			int num = buf.Length / Channels;
			long num2 = (long)(AudioSettings.dspTime * (double)SamplingRate);
			long num3 = num2 - timeSamples;
			if (Math.Abs(num3) > SamplingRate / 4)
			{
				UnityEngine.Debug.LogWarningFormat("ToneAudioReader sample time is out: {0} / {1}", timeSamples, num2);
				num3 = num;
				timeSamples = num2 - num;
			}
			if (num3 < num)
			{
				return false;
			}
			int num4 = 0;
			for (int i = 0; i < num; i++)
			{
				float num5 = (float)Math.Sin((double)timeSamples++ * k) * 0.2f;
				for (int j = 0; j < Channels; j++)
				{
					buf[num4++] = num5;
				}
			}
			return true;
		}
	}
}
