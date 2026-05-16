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
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

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
			FilePathsData = new byte[2468]
			{
				0, 0, 0, 4, 0, 0, 0, 71, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 85,
				110, 105, 116, 121, 78, 101, 116, 119, 111, 114,
				107, 105, 110, 103, 92, 85, 116, 105, 108, 105,
				116, 121, 83, 99, 114, 105, 112, 116, 115, 92,
				67, 117, 108, 108, 105, 110, 103, 92, 67, 117,
				108, 108, 65, 114, 101, 97, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 77, 92, 65, 115,
				115, 101, 116, 115, 92, 80, 104, 111, 116, 111,
				110, 92, 80, 104, 111, 116, 111, 110, 85, 110,
				105, 116, 121, 78, 101, 116, 119, 111, 114, 107,
				105, 110, 103, 92, 85, 116, 105, 108, 105, 116,
				121, 83, 99, 114, 105, 112, 116, 115, 92, 67,
				117, 108, 108, 105, 110, 103, 92, 67, 117, 108,
				108, 105, 110, 103, 72, 97, 110, 100, 108, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 87, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 85, 110, 105, 116, 121, 78, 101,
				116, 119, 111, 114, 107, 105, 110, 103, 92, 85,
				116, 105, 108, 105, 116, 121, 83, 99, 114, 105,
				112, 116, 115, 92, 68, 101, 98, 117, 103, 103,
				105, 110, 103, 92, 80, 104, 111, 116, 111, 110,
				76, 97, 103, 83, 105, 109, 117, 108, 97, 116,
				105, 111, 110, 71, 117, 105, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 79, 92, 65, 115,
				115, 101, 116, 115, 92, 80, 104, 111, 116, 111,
				110, 92, 80, 104, 111, 116, 111, 110, 85, 110,
				105, 116, 121, 78, 101, 116, 119, 111, 114, 107,
				105, 110, 103, 92, 85, 116, 105, 108, 105, 116,
				121, 83, 99, 114, 105, 112, 116, 115, 92, 68,
				101, 98, 117, 103, 103, 105, 110, 103, 92, 80,
				104, 111, 116, 111, 110, 83, 116, 97, 116, 115,
				71, 117, 105, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 88, 92, 65, 115, 115, 101, 116,
				115, 92, 80, 104, 111, 116, 111, 110, 92, 80,
				104, 111, 116, 111, 110, 85, 110, 105, 116, 121,
				78, 101, 116, 119, 111, 114, 107, 105, 110, 103,
				92, 85, 116, 105, 108, 105, 116, 121, 83, 99,
				114, 105, 112, 116, 115, 92, 68, 101, 98, 117,
				103, 103, 105, 110, 103, 92, 80, 111, 105, 110,
				116, 101, 100, 65, 116, 71, 97, 109, 101, 79,
				98, 106, 101, 99, 116, 73, 110, 102, 111, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 74,
				92, 65, 115, 115, 101, 116, 115, 92, 80, 104,
				111, 116, 111, 110, 92, 80, 104, 111, 116, 111,
				110, 85, 110, 105, 116, 121, 78, 101, 116, 119,
				111, 114, 107, 105, 110, 103, 92, 85, 116, 105,
				108, 105, 116, 121, 83, 99, 114, 105, 112, 116,
				115, 92, 68, 101, 98, 117, 103, 103, 105, 110,
				103, 92, 83, 116, 97, 116, 101, 115, 71, 117,
				105, 46, 99, 115, 0, 0, 0, 3, 0, 0,
				0, 86, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 85, 110, 105, 116, 121, 78, 101,
				116, 119, 111, 114, 107, 105, 110, 103, 92, 85,
				116, 105, 108, 105, 116, 121, 83, 99, 114, 105,
				112, 116, 115, 92, 80, 104, 111, 116, 111, 110,
				80, 108, 97, 121, 101, 114, 92, 80, 104, 111,
				116, 111, 110, 84, 101, 97, 109, 115, 77, 97,
				110, 97, 103, 101, 114, 46, 99, 115, 0, 0,
				0, 2, 0, 0, 0, 83, 92, 65, 115, 115,
				101, 116, 115, 92, 80, 104, 111, 116, 111, 110,
				92, 80, 104, 111, 116, 111, 110, 85, 110, 105,
				116, 121, 78, 101, 116, 119, 111, 114, 107, 105,
				110, 103, 92, 85, 116, 105, 108, 105, 116, 121,
				83, 99, 114, 105, 112, 116, 115, 92, 80, 104,
				111, 116, 111, 110, 80, 108, 97, 121, 101, 114,
				92, 80, 108, 97, 121, 101, 114, 78, 117, 109,
				98, 101, 114, 105, 110, 103, 46, 99, 115, 0,
				0, 0, 2, 0, 0, 0, 83, 92, 65, 115,
				115, 101, 116, 115, 92, 80, 104, 111, 116, 111,
				110, 92, 80, 104, 111, 116, 111, 110, 85, 110,
				105, 116, 121, 78, 101, 116, 119, 111, 114, 107,
				105, 110, 103, 92, 85, 116, 105, 108, 105, 116,
				121, 83, 99, 114, 105, 112, 116, 115, 92, 80,
				104, 111, 116, 111, 110, 80, 108, 97, 121, 101,
				114, 92, 80, 117, 110, 80, 108, 97, 121, 101,
				114, 83, 99, 111, 114, 101, 115, 46, 99, 115,
				0, 0, 0, 2, 0, 0, 0, 76, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 85,
				110, 105, 116, 121, 78, 101, 116, 119, 111, 114,
				107, 105, 110, 103, 92, 85, 116, 105, 108, 105,
				116, 121, 83, 99, 114, 105, 112, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 80, 108, 97, 121,
				101, 114, 92, 80, 117, 110, 84, 101, 97, 109,
				115, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 84, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 85, 110, 105, 116, 121, 78, 101,
				116, 119, 111, 114, 107, 105, 110, 103, 92, 85,
				116, 105, 108, 105, 116, 121, 83, 99, 114, 105,
				112, 116, 115, 92, 80, 104, 111, 116, 111, 110,
				86, 105, 101, 119, 92, 83, 109, 111, 111, 116,
				104, 83, 121, 110, 99, 77, 111, 118, 101, 109,
				101, 110, 116, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 87, 92, 65, 115, 115, 101, 116,
				115, 92, 80, 104, 111, 116, 111, 110, 92, 80,
				104, 111, 116, 111, 110, 85, 110, 105, 116, 121,
				78, 101, 116, 119, 111, 114, 107, 105, 110, 103,
				92, 85, 116, 105, 108, 105, 116, 121, 83, 99,
				114, 105, 112, 116, 115, 92, 80, 114, 111, 116,
				111, 116, 121, 112, 105, 110, 103, 92, 67, 111,
				110, 110, 101, 99, 116, 65, 110, 100, 74, 111,
				105, 110, 82, 97, 110, 100, 111, 109, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 77, 92,
				65, 115, 115, 101, 116, 115, 92, 80, 104, 111,
				116, 111, 110, 92, 80, 104, 111, 116, 111, 110,
				85, 110, 105, 116, 121, 78, 101, 116, 119, 111,
				114, 107, 105, 110, 103, 92, 85, 116, 105, 108,
				105, 116, 121, 83, 99, 114, 105, 112, 116, 115,
				92, 80, 114, 111, 116, 111, 116, 121, 112, 105,
				110, 103, 92, 77, 111, 118, 101, 66, 121, 75,
				101, 121, 115, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 81, 92, 65, 115, 115, 101, 116,
				115, 92, 80, 104, 111, 116, 111, 110, 92, 80,
				104, 111, 116, 111, 110, 85, 110, 105, 116, 121,
				78, 101, 116, 119, 111, 114, 107, 105, 110, 103,
				92, 85, 116, 105, 108, 105, 116, 121, 83, 99,
				114, 105, 112, 116, 115, 92, 80, 114, 111, 116,
				111, 116, 121, 112, 105, 110, 103, 92, 79, 110,
				67, 108, 105, 99, 107, 68, 101, 115, 116, 114,
				111, 121, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 85, 92, 65, 115, 115, 101, 116, 115,
				92, 80, 104, 111, 116, 111, 110, 92, 80, 104,
				111, 116, 111, 110, 85, 110, 105, 116, 121, 78,
				101, 116, 119, 111, 114, 107, 105, 110, 103, 92,
				85, 116, 105, 108, 105, 116, 121, 83, 99, 114,
				105, 112, 116, 115, 92, 80, 114, 111, 116, 111,
				116, 121, 112, 105, 110, 103, 92, 79, 110, 67,
				108, 105, 99, 107, 73, 110, 115, 116, 97, 110,
				116, 105, 97, 116, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 77, 92, 65, 115, 115,
				101, 116, 115, 92, 80, 104, 111, 116, 111, 110,
				92, 80, 104, 111, 116, 111, 110, 85, 110, 105,
				116, 121, 78, 101, 116, 119, 111, 114, 107, 105,
				110, 103, 92, 85, 116, 105, 108, 105, 116, 121,
				83, 99, 114, 105, 112, 116, 115, 92, 80, 114,
				111, 116, 111, 116, 121, 112, 105, 110, 103, 92,
				79, 110, 67, 108, 105, 99, 107, 82, 112, 99,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				79, 92, 65, 115, 115, 101, 116, 115, 92, 80,
				104, 111, 116, 111, 110, 92, 80, 104, 111, 116,
				111, 110, 85, 110, 105, 116, 121, 78, 101, 116,
				119, 111, 114, 107, 105, 110, 103, 92, 85, 116,
				105, 108, 105, 116, 121, 83, 99, 114, 105, 112,
				116, 115, 92, 80, 114, 111, 116, 111, 116, 121,
				112, 105, 110, 103, 92, 79, 110, 69, 115, 99,
				97, 112, 101, 81, 117, 105, 116, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 86, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 85,
				110, 105, 116, 121, 78, 101, 116, 119, 111, 114,
				107, 105, 110, 103, 92, 85, 116, 105, 108, 105,
				116, 121, 83, 99, 114, 105, 112, 116, 115, 92,
				80, 114, 111, 116, 111, 116, 121, 112, 105, 110,
				103, 92, 79, 110, 74, 111, 105, 110, 101, 100,
				73, 110, 115, 116, 97, 110, 116, 105, 97, 116,
				101, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 80, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 85, 110, 105, 116, 121, 78, 101,
				116, 119, 111, 114, 107, 105, 110, 103, 92, 85,
				116, 105, 108, 105, 116, 121, 83, 99, 114, 105,
				112, 116, 115, 92, 80, 114, 111, 116, 111, 116,
				121, 112, 105, 110, 103, 92, 79, 110, 83, 116,
				97, 114, 116, 68, 101, 108, 101, 116, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 74,
				92, 65, 115, 115, 101, 116, 115, 92, 80, 104,
				111, 116, 111, 110, 92, 80, 104, 111, 116, 111,
				110, 85, 110, 105, 116, 121, 78, 101, 116, 119,
				111, 114, 107, 105, 110, 103, 92, 85, 116, 105,
				108, 105, 116, 121, 83, 99, 114, 105, 112, 116,
				115, 92, 82, 111, 111, 109, 92, 67, 111, 117,
				110, 116, 100, 111, 119, 110, 84, 105, 109, 101,
				114, 46, 99, 115, 0, 0, 0, 3, 0, 0,
				0, 79, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 85, 110, 105, 116, 121, 78, 101,
				116, 119, 111, 114, 107, 105, 110, 103, 92, 85,
				116, 105, 108, 105, 116, 121, 83, 99, 114, 105,
				112, 116, 115, 92, 84, 117, 114, 110, 66, 97,
				115, 101, 100, 92, 80, 117, 110, 84, 117, 114,
				110, 77, 97, 110, 97, 103, 101, 114, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 80, 92,
				65, 115, 115, 101, 116, 115, 92, 80, 104, 111,
				116, 111, 110, 92, 80, 104, 111, 116, 111, 110,
				85, 110, 105, 116, 121, 78, 101, 116, 119, 111,
				114, 107, 105, 110, 103, 92, 85, 116, 105, 108,
				105, 116, 121, 83, 99, 114, 105, 112, 116, 115,
				92, 85, 73, 92, 66, 117, 116, 116, 111, 110,
				73, 110, 115, 105, 100, 101, 83, 99, 114, 111,
				108, 108, 76, 105, 115, 116, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 76, 92, 65, 115,
				115, 101, 116, 115, 92, 80, 104, 111, 116, 111,
				110, 92, 80, 104, 111, 116, 111, 110, 85, 110,
				105, 116, 121, 78, 101, 116, 119, 111, 114, 107,
				105, 110, 103, 92, 85, 116, 105, 108, 105, 116,
				121, 83, 99, 114, 105, 112, 116, 115, 92, 85,
				73, 92, 69, 118, 101, 110, 116, 83, 121, 115,
				116, 101, 109, 83, 112, 97, 119, 110, 101, 114,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				85, 92, 65, 115, 115, 101, 116, 115, 92, 80,
				104, 111, 116, 111, 110, 92, 80, 104, 111, 116,
				111, 110, 85, 110, 105, 116, 121, 78, 101, 116,
				119, 111, 114, 107, 105, 110, 103, 92, 85, 116,
				105, 108, 105, 116, 121, 83, 99, 114, 105, 112,
				116, 115, 92, 85, 73, 92, 71, 114, 97, 112,
				104, 105, 99, 84, 111, 103, 103, 108, 101, 73,
				115, 79, 110, 84, 114, 97, 110, 115, 105, 116,
				105, 111, 110, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 78, 92, 65, 115, 115, 101, 116,
				115, 92, 80, 104, 111, 116, 111, 110, 92, 80,
				104, 111, 116, 111, 110, 85, 110, 105, 116, 121,
				78, 101, 116, 119, 111, 114, 107, 105, 110, 103,
				92, 85, 116, 105, 108, 105, 116, 121, 83, 99,
				114, 105, 112, 116, 115, 92, 85, 73, 92, 79,
				110, 80, 111, 105, 110, 116, 101, 114, 79, 118,
				101, 114, 84, 111, 111, 108, 116, 105, 112, 46,
				99, 115, 0, 0, 0, 3, 0, 0, 0, 72,
				92, 65, 115, 115, 101, 116, 115, 92, 80, 104,
				111, 116, 111, 110, 92, 80, 104, 111, 116, 111,
				110, 85, 110, 105, 116, 121, 78, 101, 116, 119,
				111, 114, 107, 105, 110, 103, 92, 85, 116, 105,
				108, 105, 116, 121, 83, 99, 114, 105, 112, 116,
				115, 92, 85, 73, 92, 84, 97, 98, 86, 105,
				101, 119, 77, 97, 110, 97, 103, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 78,
				92, 65, 115, 115, 101, 116, 115, 92, 80, 104,
				111, 116, 111, 110, 92, 80, 104, 111, 116, 111,
				110, 85, 110, 105, 116, 121, 78, 101, 116, 119,
				111, 114, 107, 105, 110, 103, 92, 85, 116, 105,
				108, 105, 116, 121, 83, 99, 114, 105, 112, 116,
				115, 92, 85, 73, 92, 84, 101, 120, 116, 66,
				117, 116, 116, 111, 110, 84, 114, 97, 110, 115,
				105, 116, 105, 111, 110, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 82, 92, 65, 115, 115,
				101, 116, 115, 92, 80, 104, 111, 116, 111, 110,
				92, 80, 104, 111, 116, 111, 110, 85, 110, 105,
				116, 121, 78, 101, 116, 119, 111, 114, 107, 105,
				110, 103, 92, 85, 116, 105, 108, 105, 116, 121,
				83, 99, 114, 105, 112, 116, 115, 92, 85, 73,
				92, 84, 101, 120, 116, 84, 111, 103, 103, 108,
				101, 73, 115, 79, 110, 84, 114, 97, 110, 115,
				105, 116, 105, 111, 110, 46, 99, 115
			},
			TypesData = new byte[1894]
			{
				0, 0, 0, 0, 34, 80, 104, 111, 116, 111,
				110, 46, 80, 117, 110, 46, 85, 116, 105, 108,
				105, 116, 121, 83, 99, 114, 105, 112, 116, 115,
				124, 67, 117, 108, 108, 65, 114, 101, 97, 0,
				0, 0, 0, 34, 80, 104, 111, 116, 111, 110,
				46, 80, 117, 110, 46, 85, 116, 105, 108, 105,
				116, 121, 83, 99, 114, 105, 112, 116, 115, 124,
				67, 101, 108, 108, 84, 114, 101, 101, 0, 0,
				0, 0, 38, 80, 104, 111, 116, 111, 110, 46,
				80, 117, 110, 46, 85, 116, 105, 108, 105, 116,
				121, 83, 99, 114, 105, 112, 116, 115, 124, 67,
				101, 108, 108, 84, 114, 101, 101, 78, 111, 100,
				101, 0, 0, 0, 0, 38, 80, 104, 111, 116,
				111, 110, 46, 80, 117, 110, 46, 85, 116, 105,
				108, 105, 116, 121, 83, 99, 114, 105, 112, 116,
				115, 124, 66, 121, 116, 101, 67, 111, 109, 112,
				97, 114, 101, 114, 0, 0, 0, 0, 40, 80,
				104, 111, 116, 111, 110, 46, 80, 117, 110, 46,
				85, 116, 105, 108, 105, 116, 121, 83, 99, 114,
				105, 112, 116, 115, 124, 67, 117, 108, 108, 105,
				110, 103, 72, 97, 110, 100, 108, 101, 114, 0,
				0, 0, 0, 48, 80, 104, 111, 116, 111, 110,
				46, 80, 117, 110, 46, 85, 116, 105, 108, 105,
				116, 121, 83, 99, 114, 105, 112, 116, 115, 124,
				80, 104, 111, 116, 111, 110, 76, 97, 103, 83,
				105, 109, 117, 108, 97, 116, 105, 111, 110, 71,
				117, 105, 0, 0, 0, 0, 40, 80, 104, 111,
				116, 111, 110, 46, 80, 117, 110, 46, 85, 116,
				105, 108, 105, 116, 121, 83, 99, 114, 105, 112,
				116, 115, 124, 80, 104, 111, 116, 111, 110, 83,
				116, 97, 116, 115, 71, 117, 105, 0, 0, 0,
				0, 49, 80, 104, 111, 116, 111, 110, 46, 80,
				117, 110, 46, 85, 116, 105, 108, 105, 116, 121,
				83, 99, 114, 105, 112, 116, 115, 124, 80, 111,
				105, 110, 116, 101, 100, 65, 116, 71, 97, 109,
				101, 79, 98, 106, 101, 99, 116, 73, 110, 102,
				111, 0, 0, 0, 0, 35, 80, 104, 111, 116,
				111, 110, 46, 80, 117, 110, 46, 85, 116, 105,
				108, 105, 116, 121, 83, 99, 114, 105, 112, 116,
				115, 124, 83, 116, 97, 116, 101, 115, 71, 117,
				105, 0, 0, 0, 0, 36, 80, 104, 111, 116,
				111, 110, 46, 80, 117, 110, 46, 85, 116, 105,
				108, 105, 116, 121, 83, 99, 114, 105, 112, 116,
				115, 124, 80, 104, 111, 116, 111, 110, 84, 101,
				97, 109, 0, 0, 0, 0, 44, 80, 104, 111,
				116, 111, 110, 46, 80, 117, 110, 46, 85, 116,
				105, 108, 105, 116, 121, 83, 99, 114, 105, 112,
				116, 115, 124, 80, 104, 111, 116, 111, 110, 84,
				101, 97, 109, 115, 77, 97, 110, 97, 103, 101,
				114, 0, 0, 0, 0, 46, 80, 104, 111, 116,
				111, 110, 46, 80, 117, 110, 46, 85, 116, 105,
				108, 105, 116, 121, 83, 99, 114, 105, 112, 116,
				115, 124, 80, 104, 111, 116, 111, 110, 84, 101,
				97, 109, 69, 120, 116, 101, 110, 115, 105, 111,
				110, 115, 0, 0, 0, 0, 41, 80, 104, 111,
				116, 111, 110, 46, 80, 117, 110, 46, 85, 116,
				105, 108, 105, 116, 121, 83, 99, 114, 105, 112,
				116, 115, 124, 80, 108, 97, 121, 101, 114, 78,
				117, 109, 98, 101, 114, 105, 110, 103, 0, 0,
				0, 0, 51, 80, 104, 111, 116, 111, 110, 46,
				80, 117, 110, 46, 85, 116, 105, 108, 105, 116,
				121, 83, 99, 114, 105, 112, 116, 115, 124, 80,
				108, 97, 121, 101, 114, 78, 117, 109, 98, 101,
				114, 105, 110, 103, 69, 120, 116, 101, 110, 115,
				105, 111, 110, 115, 0, 0, 0, 0, 41, 80,
				104, 111, 116, 111, 110, 46, 80, 117, 110, 46,
				85, 116, 105, 108, 105, 116, 121, 83, 99, 114,
				105, 112, 116, 115, 124, 80, 117, 110, 80, 108,
				97, 121, 101, 114, 83, 99, 111, 114, 101, 115,
				0, 0, 0, 0, 41, 80, 104, 111, 116, 111,
				110, 46, 80, 117, 110, 46, 85, 116, 105, 108,
				105, 116, 121, 83, 99, 114, 105, 112, 116, 115,
				124, 83, 99, 111, 114, 101, 69, 120, 116, 101,
				110, 115, 105, 111, 110, 115, 0, 0, 0, 0,
				34, 80, 104, 111, 116, 111, 110, 46, 80, 117,
				110, 46, 85, 116, 105, 108, 105, 116, 121, 83,
				99, 114, 105, 112, 116, 115, 124, 80, 117, 110,
				84, 101, 97, 109, 115, 0, 0, 0, 0, 40,
				80, 104, 111, 116, 111, 110, 46, 80, 117, 110,
				46, 85, 116, 105, 108, 105, 116, 121, 83, 99,
				114, 105, 112, 116, 115, 124, 84, 101, 97, 109,
				69, 120, 116, 101, 110, 115, 105, 111, 110, 115,
				0, 0, 0, 0, 44, 80, 104, 111, 116, 111,
				110, 46, 80, 117, 110, 46, 85, 116, 105, 108,
				105, 116, 121, 83, 99, 114, 105, 112, 116, 115,
				124, 83, 109, 111, 111, 116, 104, 83, 121, 110,
				99, 77, 111, 118, 101, 109, 101, 110, 116, 0,
				0, 0, 0, 46, 80, 104, 111, 116, 111, 110,
				46, 80, 117, 110, 46, 85, 116, 105, 108, 105,
				116, 121, 83, 99, 114, 105, 112, 116, 115, 124,
				67, 111, 110, 110, 101, 99, 116, 65, 110, 100,
				74, 111, 105, 110, 82, 97, 110, 100, 111, 109,
				0, 0, 0, 0, 36, 80, 104, 111, 116, 111,
				110, 46, 80, 117, 110, 46, 85, 116, 105, 108,
				105, 116, 121, 83, 99, 114, 105, 112, 116, 115,
				124, 77, 111, 118, 101, 66, 121, 75, 101, 121,
				115, 0, 0, 0, 0, 40, 80, 104, 111, 116,
				111, 110, 46, 80, 117, 110, 46, 85, 116, 105,
				108, 105, 116, 121, 83, 99, 114, 105, 112, 116,
				115, 124, 79, 110, 67, 108, 105, 99, 107, 68,
				101, 115, 116, 114, 111, 121, 0, 0, 0, 0,
				44, 80, 104, 111, 116, 111, 110, 46, 80, 117,
				110, 46, 85, 116, 105, 108, 105, 116, 121, 83,
				99, 114, 105, 112, 116, 115, 124, 79, 110, 67,
				108, 105, 99, 107, 73, 110, 115, 116, 97, 110,
				116, 105, 97, 116, 101, 0, 0, 0, 0, 36,
				80, 104, 111, 116, 111, 110, 46, 80, 117, 110,
				46, 85, 116, 105, 108, 105, 116, 121, 83, 99,
				114, 105, 112, 116, 115, 124, 79, 110, 67, 108,
				105, 99, 107, 82, 112, 99, 0, 0, 0, 0,
				38, 80, 104, 111, 116, 111, 110, 46, 80, 117,
				110, 46, 85, 116, 105, 108, 105, 116, 121, 83,
				99, 114, 105, 112, 116, 115, 124, 79, 110, 69,
				115, 99, 97, 112, 101, 81, 117, 105, 116, 0,
				0, 0, 0, 45, 80, 104, 111, 116, 111, 110,
				46, 80, 117, 110, 46, 85, 116, 105, 108, 105,
				116, 121, 83, 99, 114, 105, 112, 116, 115, 124,
				79, 110, 74, 111, 105, 110, 101, 100, 73, 110,
				115, 116, 97, 110, 116, 105, 97, 116, 101, 0,
				0, 0, 0, 39, 80, 104, 111, 116, 111, 110,
				46, 80, 117, 110, 46, 85, 116, 105, 108, 105,
				116, 121, 83, 99, 114, 105, 112, 116, 115, 124,
				79, 110, 83, 116, 97, 114, 116, 68, 101, 108,
				101, 116, 101, 0, 0, 0, 0, 40, 80, 104,
				111, 116, 111, 110, 46, 80, 117, 110, 46, 85,
				116, 105, 108, 105, 116, 121, 83, 99, 114, 105,
				112, 116, 115, 124, 67, 111, 117, 110, 116, 100,
				111, 119, 110, 84, 105, 109, 101, 114, 0, 0,
				0, 0, 40, 80, 104, 111, 116, 111, 110, 46,
				80, 117, 110, 46, 85, 116, 105, 108, 105, 116,
				121, 83, 99, 114, 105, 112, 116, 115, 124, 80,
				117, 110, 84, 117, 114, 110, 77, 97, 110, 97,
				103, 101, 114, 0, 0, 0, 0, 50, 80, 104,
				111, 116, 111, 110, 46, 80, 117, 110, 46, 85,
				116, 105, 108, 105, 116, 121, 83, 99, 114, 105,
				112, 116, 115, 124, 73, 80, 117, 110, 84, 117,
				114, 110, 77, 97, 110, 97, 103, 101, 114, 67,
				97, 108, 108, 98, 97, 99, 107, 115, 0, 0,
				0, 0, 40, 80, 104, 111, 116, 111, 110, 46,
				80, 117, 110, 46, 85, 116, 105, 108, 105, 116,
				121, 83, 99, 114, 105, 112, 116, 115, 124, 84,
				117, 114, 110, 69, 120, 116, 101, 110, 115, 105,
				111, 110, 115, 0, 0, 0, 0, 48, 80, 104,
				111, 116, 111, 110, 46, 80, 117, 110, 46, 85,
				116, 105, 108, 105, 116, 121, 83, 99, 114, 105,
				112, 116, 115, 124, 66, 117, 116, 116, 111, 110,
				73, 110, 115, 105, 100, 101, 83, 99, 114, 111,
				108, 108, 76, 105, 115, 116, 0, 0, 0, 0,
				44, 80, 104, 111, 116, 111, 110, 46, 80, 117,
				110, 46, 85, 116, 105, 108, 105, 116, 121, 83,
				99, 114, 105, 112, 116, 115, 124, 69, 118, 101,
				110, 116, 83, 121, 115, 116, 101, 109, 83, 112,
				97, 119, 110, 101, 114, 0, 0, 0, 0, 53,
				80, 104, 111, 116, 111, 110, 46, 80, 117, 110,
				46, 85, 116, 105, 108, 105, 116, 121, 83, 99,
				114, 105, 112, 116, 115, 124, 71, 114, 97, 112,
				104, 105, 99, 84, 111, 103, 103, 108, 101, 73,
				115, 79, 110, 84, 114, 97, 110, 115, 105, 116,
				105, 111, 110, 0, 0, 0, 0, 46, 80, 104,
				111, 116, 111, 110, 46, 80, 117, 110, 46, 85,
				116, 105, 108, 105, 116, 121, 83, 99, 114, 105,
				112, 116, 115, 124, 79, 110, 80, 111, 105, 110,
				116, 101, 114, 79, 118, 101, 114, 84, 111, 111,
				108, 116, 105, 112, 0, 0, 0, 0, 40, 80,
				104, 111, 116, 111, 110, 46, 80, 117, 110, 46,
				85, 116, 105, 108, 105, 116, 121, 83, 99, 114,
				105, 112, 116, 115, 124, 84, 97, 98, 86, 105,
				101, 119, 77, 97, 110, 97, 103, 101, 114, 0,
				0, 0, 0, 55, 80, 104, 111, 116, 111, 110,
				46, 80, 117, 110, 46, 85, 116, 105, 108, 105,
				116, 121, 83, 99, 114, 105, 112, 116, 115, 46,
				84, 97, 98, 86, 105, 101, 119, 77, 97, 110,
				97, 103, 101, 114, 124, 84, 97, 98, 67, 104,
				97, 110, 103, 101, 69, 118, 101, 110, 116, 0,
				0, 0, 0, 44, 80, 104, 111, 116, 111, 110,
				46, 80, 117, 110, 46, 85, 116, 105, 108, 105,
				116, 121, 83, 99, 114, 105, 112, 116, 115, 46,
				84, 97, 98, 86, 105, 101, 119, 77, 97, 110,
				97, 103, 101, 114, 124, 84, 97, 98, 0, 0,
				0, 0, 46, 80, 104, 111, 116, 111, 110, 46,
				80, 117, 110, 46, 85, 116, 105, 108, 105, 116,
				121, 83, 99, 114, 105, 112, 116, 115, 124, 84,
				101, 120, 116, 66, 117, 116, 116, 111, 110, 84,
				114, 97, 110, 115, 105, 116, 105, 111, 110, 0,
				0, 0, 0, 50, 80, 104, 111, 116, 111, 110,
				46, 80, 117, 110, 46, 85, 116, 105, 108, 105,
				116, 121, 83, 99, 114, 105, 112, 116, 115, 124,
				84, 101, 120, 116, 84, 111, 103, 103, 108, 101,
				73, 115, 79, 110, 84, 114, 97, 110, 115, 105,
				116, 105, 111, 110
			},
			TotalFiles = 28,
			TotalTypes = 40,
			IsEditorOnly = false
		};
	}
}
namespace Photon.Pun.UtilityScripts;

public class CullArea : MonoBehaviour
{
	private const int MAX_NUMBER_OF_ALLOWED_CELLS = 250;

	public const int MAX_NUMBER_OF_SUBDIVISIONS = 3;

	public readonly byte FIRST_GROUP_ID = 1;

	public readonly int[] SUBDIVISION_FIRST_LEVEL_ORDER = new int[4] { 0, 1, 1, 1 };

	public readonly int[] SUBDIVISION_SECOND_LEVEL_ORDER = new int[8] { 0, 2, 1, 2, 0, 2, 1, 2 };

	public readonly int[] SUBDIVISION_THIRD_LEVEL_ORDER = new int[12]
	{
		0, 3, 2, 3, 1, 3, 2, 3, 1, 3,
		2, 3
	};

	public Vector2 Center;

	public Vector2 Size = new Vector2(25f, 25f);

	public Vector2[] Subdivisions = new Vector2[3];

	public int NumberOfSubdivisions;

	public bool YIsUpAxis;

	public bool RecreateCellHierarchy;

	private byte idCounter;

	public int CellCount { get; private set; }

	public CellTree CellTree { get; private set; }

	public Dictionary<int, GameObject> Map { get; private set; }

	private void Awake()
	{
		idCounter = FIRST_GROUP_ID;
		CreateCellHierarchy();
	}

	public void OnDrawGizmos()
	{
		idCounter = FIRST_GROUP_ID;
		if (RecreateCellHierarchy)
		{
			CreateCellHierarchy();
		}
		DrawCells();
	}

	private void CreateCellHierarchy()
	{
		if (!IsCellCountAllowed())
		{
			if (UnityEngine.Debug.isDebugBuild)
			{
				UnityEngine.Debug.LogError("There are too many cells created by your subdivision options. Maximum allowed number of cells is " + (250 - FIRST_GROUP_ID) + ". Current number of cells is " + CellCount + ".");
				return;
			}
			Application.Quit();
		}
		CellTreeNode cellTreeNode = new CellTreeNode(idCounter++, CellTreeNode.ENodeType.Root, null);
		if (YIsUpAxis)
		{
			Center = new Vector2(base.transform.position.x, base.transform.position.y);
			Size = new Vector2(base.transform.localScale.x, base.transform.localScale.y);
			cellTreeNode.Center = new Vector3(Center.x, Center.y, 0f);
			cellTreeNode.Size = new Vector3(Size.x, Size.y, 0f);
			cellTreeNode.TopLeft = new Vector3(Center.x - Size.x / 2f, Center.y - Size.y / 2f, 0f);
			cellTreeNode.BottomRight = new Vector3(Center.x + Size.x / 2f, Center.y + Size.y / 2f, 0f);
		}
		else
		{
			Center = new Vector2(base.transform.position.x, base.transform.position.z);
			Size = new Vector2(base.transform.localScale.x, base.transform.localScale.z);
			cellTreeNode.Center = new Vector3(Center.x, 0f, Center.y);
			cellTreeNode.Size = new Vector3(Size.x, 0f, Size.y);
			cellTreeNode.TopLeft = new Vector3(Center.x - Size.x / 2f, 0f, Center.y - Size.y / 2f);
			cellTreeNode.BottomRight = new Vector3(Center.x + Size.x / 2f, 0f, Center.y + Size.y / 2f);
		}
		CreateChildCells(cellTreeNode, 1);
		CellTree = new CellTree(cellTreeNode);
		RecreateCellHierarchy = false;
	}

	private void CreateChildCells(CellTreeNode parent, int cellLevelInHierarchy)
	{
		if (cellLevelInHierarchy > NumberOfSubdivisions)
		{
			return;
		}
		int num = (int)Subdivisions[cellLevelInHierarchy - 1].x;
		int num2 = (int)Subdivisions[cellLevelInHierarchy - 1].y;
		float num3 = parent.Center.x - parent.Size.x / 2f;
		float num4 = parent.Size.x / (float)num;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				float num5 = num3 + (float)i * num4 + num4 / 2f;
				CellTreeNode cellTreeNode = new CellTreeNode(idCounter++, (NumberOfSubdivisions != cellLevelInHierarchy) ? CellTreeNode.ENodeType.Node : CellTreeNode.ENodeType.Leaf, parent);
				if (YIsUpAxis)
				{
					float num6 = parent.Center.y - parent.Size.y / 2f;
					float num7 = parent.Size.y / (float)num2;
					float num8 = num6 + (float)j * num7 + num7 / 2f;
					cellTreeNode.Center = new Vector3(num5, num8, 0f);
					cellTreeNode.Size = new Vector3(num4, num7, 0f);
					cellTreeNode.TopLeft = new Vector3(num5 - num4 / 2f, num8 - num7 / 2f, 0f);
					cellTreeNode.BottomRight = new Vector3(num5 + num4 / 2f, num8 + num7 / 2f, 0f);
				}
				else
				{
					float num9 = parent.Center.z - parent.Size.z / 2f;
					float num10 = parent.Size.z / (float)num2;
					float num11 = num9 + (float)j * num10 + num10 / 2f;
					cellTreeNode.Center = new Vector3(num5, 0f, num11);
					cellTreeNode.Size = new Vector3(num4, 0f, num10);
					cellTreeNode.TopLeft = new Vector3(num5 - num4 / 2f, 0f, num11 - num10 / 2f);
					cellTreeNode.BottomRight = new Vector3(num5 + num4 / 2f, 0f, num11 + num10 / 2f);
				}
				parent.AddChild(cellTreeNode);
				CreateChildCells(cellTreeNode, cellLevelInHierarchy + 1);
			}
		}
	}

	private void DrawCells()
	{
		if (CellTree != null && CellTree.RootNode != null)
		{
			CellTree.RootNode.Draw();
		}
		else
		{
			RecreateCellHierarchy = true;
		}
	}

	private bool IsCellCountAllowed()
	{
		int num = 1;
		int num2 = 1;
		Vector2[] subdivisions = Subdivisions;
		for (int i = 0; i < subdivisions.Length; i++)
		{
			Vector2 vector = subdivisions[i];
			num *= (int)vector.x;
			num2 *= (int)vector.y;
		}
		CellCount = num * num2;
		return CellCount <= 250 - FIRST_GROUP_ID;
	}

	public List<byte> GetActiveCells(Vector3 position)
	{
		List<byte> list = new List<byte>(0);
		CellTree.RootNode.GetActiveCells(list, YIsUpAxis, position);
		int num = NumberOfSubdivisions + 1;
		int num2 = list.Count - num;
		if (num2 > 0)
		{
			list.Sort(num, num2, new ByteComparer());
		}
		return list;
	}
}
public class CellTree
{
	public CellTreeNode RootNode { get; private set; }

	public CellTree()
	{
	}

	public CellTree(CellTreeNode root)
	{
		RootNode = root;
	}
}
public class CellTreeNode
{
	public enum ENodeType : byte
	{
		Root,
		Node,
		Leaf
	}

	public byte Id;

	public Vector3 Center;

	public Vector3 Size;

	public Vector3 TopLeft;

	public Vector3 BottomRight;

	public ENodeType NodeType;

	public CellTreeNode Parent;

	public List<CellTreeNode> Childs;

	private float maxDistance;

	public CellTreeNode()
	{
	}

	public CellTreeNode(byte id, ENodeType nodeType, CellTreeNode parent)
	{
		Id = id;
		NodeType = nodeType;
		Parent = parent;
	}

	public void AddChild(CellTreeNode child)
	{
		if (Childs == null)
		{
			Childs = new List<CellTreeNode>(1);
		}
		Childs.Add(child);
	}

	public void Draw()
	{
	}

	public void GetActiveCells(List<byte> activeCells, bool yIsUpAxis, Vector3 position)
	{
		if (NodeType != ENodeType.Leaf)
		{
			foreach (CellTreeNode child in Childs)
			{
				child.GetActiveCells(activeCells, yIsUpAxis, position);
			}
			return;
		}
		if (!IsPointNearCell(yIsUpAxis, position))
		{
			return;
		}
		if (IsPointInsideCell(yIsUpAxis, position))
		{
			activeCells.Insert(0, Id);
			for (CellTreeNode parent = Parent; parent != null; parent = parent.Parent)
			{
				activeCells.Insert(0, parent.Id);
			}
		}
		else
		{
			activeCells.Add(Id);
		}
	}

	public bool IsPointInsideCell(bool yIsUpAxis, Vector3 point)
	{
		if (point.x < TopLeft.x || point.x > BottomRight.x)
		{
			return false;
		}
		if (yIsUpAxis)
		{
			if (point.y >= TopLeft.y && point.y <= BottomRight.y)
			{
				return true;
			}
		}
		else if (point.z >= TopLeft.z && point.z <= BottomRight.z)
		{
			return true;
		}
		return false;
	}

	public bool IsPointNearCell(bool yIsUpAxis, Vector3 point)
	{
		if (maxDistance == 0f)
		{
			maxDistance = (Size.x + Size.y + Size.z) / 2f;
		}
		return (point - Center).sqrMagnitude <= maxDistance * maxDistance;
	}
}
public class ByteComparer : IComparer<byte>
{
	public int Compare(byte x, byte y)
	{
		if (x != y)
		{
			if (x >= y)
			{
				return 1;
			}
			return -1;
		}
		return 0;
	}
}
[RequireComponent(typeof(PhotonView))]
public class CullingHandler : MonoBehaviour, IPunObservable
{
	private int orderIndex;

	private CullArea cullArea;

	private List<byte> previousActiveCells;

	private List<byte> activeCells;

	private PhotonView pView;

	private Vector3 lastPosition;

	private Vector3 currentPosition;

	private float timeSinceUpdate;

	private float timeBetweenUpdatesMin = 0.33f;

	private void OnEnable()
	{
		if (pView == null)
		{
			pView = GetComponent<PhotonView>();
			if (!pView.IsMine)
			{
				return;
			}
		}
		if (cullArea == null)
		{
			cullArea = UnityEngine.Object.FindObjectOfType<CullArea>();
		}
		previousActiveCells = new List<byte>(0);
		activeCells = new List<byte>(0);
		currentPosition = (lastPosition = base.transform.position);
	}

	private void Start()
	{
		if (pView.IsMine && PhotonNetwork.InRoom)
		{
			if (cullArea.NumberOfSubdivisions == 0)
			{
				pView.Group = cullArea.FIRST_GROUP_ID;
				PhotonNetwork.SetInterestGroups(cullArea.FIRST_GROUP_ID, enabled: true);
			}
			else
			{
				pView.ObservedComponents.Add(this);
			}
		}
	}

	private void Update()
	{
		if (!pView.IsMine)
		{
			return;
		}
		timeSinceUpdate += Time.deltaTime;
		if (!(timeSinceUpdate < timeBetweenUpdatesMin))
		{
			lastPosition = currentPosition;
			currentPosition = base.transform.position;
			if (currentPosition != lastPosition && HaveActiveCellsChanged())
			{
				UpdateInterestGroups();
				timeSinceUpdate = 0f;
			}
		}
	}

	private void OnGUI()
	{
		if (!pView.IsMine)
		{
			return;
		}
		string text = "Inside cells:\n";
		string text2 = "Subscribed cells:\n";
		for (int i = 0; i < activeCells.Count; i++)
		{
			if (i <= cullArea.NumberOfSubdivisions)
			{
				text = text + activeCells[i] + " | ";
			}
			text2 = text2 + activeCells[i] + " | ";
		}
		GUI.Label(new Rect(20f, (float)Screen.height - 120f, 200f, 40f), "<color=white>PhotonView Group: " + pView.Group + "</color>", new GUIStyle
		{
			alignment = TextAnchor.UpperLeft,
			fontSize = 16
		});
		GUI.Label(new Rect(20f, (float)Screen.height - 100f, 200f, 40f), "<color=white>" + text + "</color>", new GUIStyle
		{
			alignment = TextAnchor.UpperLeft,
			fontSize = 16
		});
		GUI.Label(new Rect(20f, (float)Screen.height - 60f, 200f, 40f), "<color=white>" + text2 + "</color>", new GUIStyle
		{
			alignment = TextAnchor.UpperLeft,
			fontSize = 16
		});
	}

	private bool HaveActiveCellsChanged()
	{
		if (cullArea.NumberOfSubdivisions == 0)
		{
			return false;
		}
		previousActiveCells = new List<byte>(activeCells);
		activeCells = cullArea.GetActiveCells(base.transform.position);
		while (activeCells.Count <= cullArea.NumberOfSubdivisions)
		{
			activeCells.Add(cullArea.FIRST_GROUP_ID);
		}
		if (activeCells.Count != previousActiveCells.Count)
		{
			return true;
		}
		if (activeCells[cullArea.NumberOfSubdivisions] != previousActiveCells[cullArea.NumberOfSubdivisions])
		{
			return true;
		}
		return false;
	}

	private void UpdateInterestGroups()
	{
		List<byte> list = new List<byte>(0);
		foreach (byte previousActiveCell in previousActiveCells)
		{
			if (!activeCells.Contains(previousActiveCell))
			{
				list.Add(previousActiveCell);
			}
		}
		PhotonNetwork.SetInterestGroups(list.ToArray(), activeCells.ToArray());
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		while (activeCells.Count <= cullArea.NumberOfSubdivisions)
		{
			activeCells.Add(cullArea.FIRST_GROUP_ID);
		}
		if (cullArea.NumberOfSubdivisions == 1)
		{
			orderIndex = ++orderIndex % cullArea.SUBDIVISION_FIRST_LEVEL_ORDER.Length;
			pView.Group = activeCells[cullArea.SUBDIVISION_FIRST_LEVEL_ORDER[orderIndex]];
		}
		else if (cullArea.NumberOfSubdivisions == 2)
		{
			orderIndex = ++orderIndex % cullArea.SUBDIVISION_SECOND_LEVEL_ORDER.Length;
			pView.Group = activeCells[cullArea.SUBDIVISION_SECOND_LEVEL_ORDER[orderIndex]];
		}
		else if (cullArea.NumberOfSubdivisions == 3)
		{
			orderIndex = ++orderIndex % cullArea.SUBDIVISION_THIRD_LEVEL_ORDER.Length;
			pView.Group = activeCells[cullArea.SUBDIVISION_THIRD_LEVEL_ORDER[orderIndex]];
		}
	}
}
public class PhotonLagSimulationGui : MonoBehaviour
{
	public Rect WindowRect = new Rect(0f, 100f, 120f, 100f);

	public int WindowId = 101;

	public bool Visible = true;

	public PhotonPeer Peer { get; set; }

	public void Start()
	{
		Peer = PhotonNetwork.NetworkingClient.LoadBalancingPeer;
	}

	public void OnGUI()
	{
		if (Visible)
		{
			if (Peer == null)
			{
				WindowRect = GUILayout.Window(WindowId, WindowRect, NetSimHasNoPeerWindow, "Netw. Sim.");
			}
			else
			{
				WindowRect = GUILayout.Window(WindowId, WindowRect, NetSimWindow, "Netw. Sim.");
			}
		}
	}

	private void NetSimHasNoPeerWindow(int windowId)
	{
		GUILayout.Label("No peer to communicate with. ");
	}

	private void NetSimWindow(int windowId)
	{
		GUILayout.Label($"Rtt:{Peer.RoundTripTime,4} +/-{Peer.RoundTripTimeVariance,3}");
		bool isSimulationEnabled = Peer.IsSimulationEnabled;
		bool flag = GUILayout.Toggle(isSimulationEnabled, "Simulate");
		if (flag != isSimulationEnabled)
		{
			Peer.IsSimulationEnabled = flag;
		}
		float value = Peer.NetworkSimulationSettings.IncomingLag;
		GUILayout.Label("Lag " + value);
		value = GUILayout.HorizontalSlider(value, 0f, 500f);
		Peer.NetworkSimulationSettings.IncomingLag = (int)value;
		Peer.NetworkSimulationSettings.OutgoingLag = (int)value;
		float value2 = Peer.NetworkSimulationSettings.IncomingJitter;
		GUILayout.Label("Jit " + value2);
		value2 = GUILayout.HorizontalSlider(value2, 0f, 100f);
		Peer.NetworkSimulationSettings.IncomingJitter = (int)value2;
		Peer.NetworkSimulationSettings.OutgoingJitter = (int)value2;
		float value3 = Peer.NetworkSimulationSettings.IncomingLossPercentage;
		GUILayout.Label("Loss " + value3);
		value3 = GUILayout.HorizontalSlider(value3, 0f, 10f);
		Peer.NetworkSimulationSettings.IncomingLossPercentage = (int)value3;
		Peer.NetworkSimulationSettings.OutgoingLossPercentage = (int)value3;
		if (GUI.changed)
		{
			WindowRect.height = 100f;
		}
		GUI.DragWindow();
	}
}
public class PhotonStatsGui : MonoBehaviour
{
	public bool statsWindowOn = true;

	public bool statsOn = true;

	public bool healthStatsVisible;

	public bool trafficStatsOn;

	public bool buttonsOn;

	public Rect statsRect = new Rect(0f, 100f, 200f, 50f);

	public int WindowId = 100;

	public bool turnOn;

	public void Start()
	{
		if (statsRect.x <= 0f)
		{
			statsRect.x = (float)Screen.width - statsRect.width;
		}
	}

	public void Update()
	{
		if (turnOn)
		{
			turnOn = false;
			statsWindowOn = !statsWindowOn;
			statsOn = true;
		}
	}

	public void OnGUI()
	{
		if (PhotonNetwork.NetworkingClient.LoadBalancingPeer.TrafficStatsEnabled != statsOn)
		{
			PhotonNetwork.NetworkingClient.LoadBalancingPeer.TrafficStatsEnabled = statsOn;
		}
		if (statsWindowOn)
		{
			statsRect = GUILayout.Window(WindowId, statsRect, TrafficStatsWindow, "Messages (shift+tab)");
		}
	}

	public void TrafficStatsWindow(int windowID)
	{
		bool flag = false;
		TrafficStatsGameLevel trafficStatsGameLevel = PhotonNetwork.NetworkingClient.LoadBalancingPeer.TrafficStatsGameLevel;
		long num = PhotonNetwork.NetworkingClient.LoadBalancingPeer.TrafficStatsElapsedMs / 1000;
		if (num == 0L)
		{
			num = 1L;
		}
		GUILayout.BeginHorizontal();
		buttonsOn = GUILayout.Toggle(buttonsOn, "buttons");
		healthStatsVisible = GUILayout.Toggle(healthStatsVisible, "health");
		trafficStatsOn = GUILayout.Toggle(trafficStatsOn, "traffic");
		GUILayout.EndHorizontal();
		string text = $"Out {trafficStatsGameLevel.TotalOutgoingByteCount,4} | In {trafficStatsGameLevel.TotalIncomingByteCount,4} | Sum {trafficStatsGameLevel.TotalByteCount,4}";
		string text2 = $"{num}sec average:";
		string text3 = $"Out {trafficStatsGameLevel.TotalOutgoingByteCount / num,4} | In {trafficStatsGameLevel.TotalIncomingByteCount / num,4} | Sum {trafficStatsGameLevel.TotalByteCount / num,4}";
		GUILayout.Label(text);
		GUILayout.Label(text2);
		GUILayout.Label(text3);
		if (buttonsOn)
		{
			GUILayout.BeginHorizontal();
			statsOn = GUILayout.Toggle(statsOn, "stats on");
			if (GUILayout.Button("Reset"))
			{
				PhotonNetwork.NetworkingClient.LoadBalancingPeer.TrafficStatsReset();
				PhotonNetwork.NetworkingClient.LoadBalancingPeer.TrafficStatsEnabled = true;
			}
			flag = GUILayout.Button("To Log");
			GUILayout.EndHorizontal();
		}
		string text4 = string.Empty;
		string text5 = string.Empty;
		if (trafficStatsOn)
		{
			GUILayout.Box("Traffic Stats");
			text4 = "Incoming: \n" + PhotonNetwork.NetworkingClient.LoadBalancingPeer.TrafficStatsIncoming.ToString();
			text5 = "Outgoing: \n" + PhotonNetwork.NetworkingClient.LoadBalancingPeer.TrafficStatsOutgoing.ToString();
			GUILayout.Label(text4);
			GUILayout.Label(text5);
		}
		string text6 = string.Empty;
		if (healthStatsVisible)
		{
			GUILayout.Box("Health Stats");
			text6 = string.Format("ping: {6}[+/-{7}]ms resent:{8} \n\nmax ms between\nsend: {0,4} \ndispatch: {1,4} \n\nlongest dispatch for: \nev({3}):{2,3}ms \nop({5}):{4,3}ms", trafficStatsGameLevel.LongestDeltaBetweenSending, trafficStatsGameLevel.LongestDeltaBetweenDispatching, trafficStatsGameLevel.LongestEventCallback, trafficStatsGameLevel.LongestEventCallbackCode, trafficStatsGameLevel.LongestOpResponseCallback, trafficStatsGameLevel.LongestOpResponseCallbackOpCode, PhotonNetwork.NetworkingClient.LoadBalancingPeer.RoundTripTime, PhotonNetwork.NetworkingClient.LoadBalancingPeer.RoundTripTimeVariance, PhotonNetwork.NetworkingClient.LoadBalancingPeer.ResentReliableCommands);
			GUILayout.Label(text6);
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
public class PointedAtGameObjectInfo : MonoBehaviour
{
	public static PointedAtGameObjectInfo Instance;

	public Text text;

	private Transform focus;

	private void Start()
	{
		if (Instance != null)
		{
			UnityEngine.Debug.LogWarning("PointedAtGameObjectInfo is already featured in the scene, gameobject is destroyed");
			UnityEngine.Object.Destroy(base.gameObject);
		}
		Instance = this;
	}

	public void SetFocus(PhotonView pv)
	{
		focus = ((pv != null) ? pv.transform : null);
		if (pv != null)
		{
			text.text = string.Format("id {0} own: {1} {2}{3}", pv.ViewID, pv.OwnerActorNr, pv.IsRoomView ? "scn" : "", pv.IsMine ? " mine" : "");
		}
		else
		{
			text.text = string.Empty;
		}
	}

	public void RemoveFocus(PhotonView pv)
	{
		if (pv == null)
		{
			text.text = string.Empty;
		}
		else if (pv.transform == focus)
		{
			text.text = string.Empty;
		}
	}

	private void LateUpdate()
	{
		if (focus != null)
		{
			base.transform.position = Camera.main.WorldToScreenPoint(focus.position);
		}
	}
}
public class StatesGui : MonoBehaviour
{
	public Rect GuiOffset = new Rect(250f, 0f, 300f, 300f);

	public bool DontDestroy = true;

	public bool ServerTimestamp;

	public bool DetailedConnection;

	public bool Server;

	public bool AppVersion;

	public bool UserId;

	public bool Room;

	public bool RoomProps;

	public bool EventsIn;

	public bool LocalPlayer;

	public bool PlayerProps;

	public bool Others;

	public bool Buttons;

	public bool ExpectedUsers;

	private Rect GuiRect;

	private static StatesGui Instance;

	private float native_width = 800f;

	private float native_height = 480f;

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.DestroyImmediate(base.gameObject);
			return;
		}
		if (DontDestroy)
		{
			Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
		if (EventsIn)
		{
			PhotonNetwork.NetworkingClient.LoadBalancingPeer.TrafficStatsEnabled = true;
		}
	}

	private void OnDisable()
	{
		if (DontDestroy && Instance == this)
		{
			Instance = null;
		}
	}

	private void OnGUI()
	{
		if (PhotonNetwork.NetworkingClient == null || PhotonNetwork.NetworkingClient.LoadBalancingPeer == null || PhotonNetwork.NetworkingClient.LoadBalancingPeer.TrafficStatsIncoming == null)
		{
			return;
		}
		float x = (float)Screen.width / native_width;
		float y = (float)Screen.height / native_height;
		GUI.matrix = Matrix4x4.TRS(new Vector3(0f, 0f, 0f), Quaternion.identity, new Vector3(x, y, 1f));
		Rect rect = new Rect(GuiOffset);
		if (rect.x < 0f)
		{
			rect.x = (float)Screen.width - rect.width;
		}
		GuiRect.xMin = rect.x;
		GuiRect.yMin = rect.y;
		GuiRect.xMax = rect.x + rect.width;
		GuiRect.yMax = rect.y + rect.height;
		GUILayout.BeginArea(GuiRect);
		GUILayout.BeginHorizontal();
		if (ServerTimestamp)
		{
			GUILayout.Label(((double)PhotonNetwork.ServerTimestamp / 1000.0).ToString("F3"));
		}
		if (Server)
		{
			GUILayout.Label(PhotonNetwork.ServerAddress + " " + PhotonNetwork.Server);
		}
		if (DetailedConnection)
		{
			GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
		}
		if (AppVersion)
		{
			GUILayout.Label(PhotonNetwork.NetworkingClient.AppVersion);
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		if (UserId)
		{
			GUILayout.Label("UID: " + ((PhotonNetwork.AuthValues != null) ? PhotonNetwork.AuthValues.UserId : "no UserId"));
			GUILayout.Label("UserId:" + PhotonNetwork.LocalPlayer.UserId);
		}
		GUILayout.EndHorizontal();
		if (Room)
		{
			if (PhotonNetwork.InRoom)
			{
				GUILayout.Label(RoomProps ? PhotonNetwork.CurrentRoom.ToStringFull() : PhotonNetwork.CurrentRoom.ToString());
			}
			else
			{
				GUILayout.Label("not in room");
			}
		}
		if (EventsIn)
		{
			int fragmentCommandCount = PhotonNetwork.NetworkingClient.LoadBalancingPeer.TrafficStatsIncoming.FragmentCommandCount;
			GUILayout.Label("Events Received: " + PhotonNetwork.NetworkingClient.LoadBalancingPeer.TrafficStatsGameLevel.EventCount + " Fragments: " + fragmentCommandCount);
		}
		if (LocalPlayer)
		{
			GUILayout.Label(PlayerToString(PhotonNetwork.LocalPlayer));
		}
		if (Others)
		{
			Player[] playerListOthers = PhotonNetwork.PlayerListOthers;
			foreach (Player player in playerListOthers)
			{
				GUILayout.Label(PlayerToString(player));
			}
		}
		if (ExpectedUsers && PhotonNetwork.InRoom)
		{
			GUILayout.Label("Expected: " + ((PhotonNetwork.CurrentRoom.ExpectedUsers != null) ? PhotonNetwork.CurrentRoom.ExpectedUsers.Length : 0) + " " + ((PhotonNetwork.CurrentRoom.ExpectedUsers != null) ? string.Join(",", PhotonNetwork.CurrentRoom.ExpectedUsers) : ""));
		}
		if (Buttons)
		{
			if (!PhotonNetwork.IsConnected && GUILayout.Button("Connect"))
			{
				PhotonNetwork.ConnectUsingSettings();
			}
			GUILayout.BeginHorizontal();
			if (PhotonNetwork.IsConnected && GUILayout.Button("Disconnect"))
			{
				PhotonNetwork.Disconnect();
			}
			if (PhotonNetwork.IsConnected && GUILayout.Button("Close Socket"))
			{
				PhotonNetwork.NetworkingClient.LoadBalancingPeer.StopThread();
			}
			GUILayout.EndHorizontal();
			if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom && GUILayout.Button("Leave"))
			{
				PhotonNetwork.LeaveRoom();
			}
			if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom && PhotonNetwork.CurrentRoom.PlayerTtl > 0 && GUILayout.Button("Leave(abandon)"))
			{
				PhotonNetwork.LeaveRoom(becomeInactive: false);
			}
			if (PhotonNetwork.IsConnected && !PhotonNetwork.InRoom && GUILayout.Button("Join Random"))
			{
				PhotonNetwork.JoinRandomRoom();
			}
			if (PhotonNetwork.IsConnected && !PhotonNetwork.InRoom && GUILayout.Button("Create Room"))
			{
				PhotonNetwork.CreateRoom(null);
			}
		}
		GUILayout.EndArea();
	}

	private string PlayerToString(Player player)
	{
		if (PhotonNetwork.NetworkingClient == null)
		{
			UnityEngine.Debug.LogError("nwp is null");
			return "";
		}
		return string.Format("#{0:00} '{1}'{5} {4}{2} {3} {6}", player.ActorNumber + "/userId:<" + player.UserId + ">", player.NickName, player.IsMasterClient ? "(master)" : "", PlayerProps ? player.CustomProperties.ToStringFull() : "", (PhotonNetwork.LocalPlayer.ActorNumber == player.ActorNumber) ? "(you)" : "", player.UserId, player.IsInactive ? " / Is Inactive" : "");
	}
}
[Serializable]
public class PhotonTeam
{
	public string Name;

	public byte Code;

	public override string ToString()
	{
		return $"{Name} [{Code}]";
	}
}
[DisallowMultipleComponent]
public class PhotonTeamsManager : MonoBehaviour, IMatchmakingCallbacks, IInRoomCallbacks
{
	[SerializeField]
	private List<PhotonTeam> teamsList = new List<PhotonTeam>
	{
		new PhotonTeam
		{
			Name = "Blue",
			Code = 1
		},
		new PhotonTeam
		{
			Name = "Red",
			Code = 2
		}
	};

	private Dictionary<byte, PhotonTeam> teamsByCode;

	private Dictionary<string, PhotonTeam> teamsByName;

	private Dictionary<byte, HashSet<Player>> playersPerTeam;

	public const string TeamPlayerProp = "_pt";

	private static PhotonTeamsManager instance;

	public static PhotonTeamsManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = UnityEngine.Object.FindObjectOfType<PhotonTeamsManager>();
				if (instance == null)
				{
					instance = new GameObject
					{
						name = "PhotonTeamsManager"
					}.AddComponent<PhotonTeamsManager>();
				}
				instance.Init();
			}
			return instance;
		}
	}

	public static event Action<Player, PhotonTeam> PlayerJoinedTeam;

	public static event Action<Player, PhotonTeam> PlayerLeftTeam;

	private void Awake()
	{
		if (instance == null || (object)this == instance)
		{
			Init();
			instance = this;
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	private void OnEnable()
	{
		PhotonNetwork.AddCallbackTarget(this);
	}

	private void OnDisable()
	{
		PhotonNetwork.RemoveCallbackTarget(this);
		ClearTeams();
	}

	private void Init()
	{
		teamsByCode = new Dictionary<byte, PhotonTeam>(teamsList.Count);
		teamsByName = new Dictionary<string, PhotonTeam>(teamsList.Count);
		playersPerTeam = new Dictionary<byte, HashSet<Player>>(teamsList.Count);
		for (int i = 0; i < teamsList.Count; i++)
		{
			teamsByCode[teamsList[i].Code] = teamsList[i];
			teamsByName[teamsList[i].Name] = teamsList[i];
			playersPerTeam[teamsList[i].Code] = new HashSet<Player>();
		}
	}

	void IMatchmakingCallbacks.OnJoinedRoom()
	{
		UpdateTeams();
	}

	void IMatchmakingCallbacks.OnLeftRoom()
	{
		ClearTeams();
	}

	void IMatchmakingCallbacks.OnPreLeavingRoom()
	{
	}

	void IInRoomCallbacks.OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
	{
		if (!changedProps.TryGetValue("_pt", out var value))
		{
			return;
		}
		if (value == null)
		{
			foreach (byte key in playersPerTeam.Keys)
			{
				if (playersPerTeam[key].Remove(targetPlayer))
				{
					if (PhotonTeamsManager.PlayerLeftTeam != null)
					{
						PhotonTeamsManager.PlayerLeftTeam(targetPlayer, teamsByCode[key]);
					}
					break;
				}
			}
			return;
		}
		if (value is byte b)
		{
			foreach (byte key2 in playersPerTeam.Keys)
			{
				if (key2 != b && playersPerTeam[key2].Remove(targetPlayer))
				{
					if (PhotonTeamsManager.PlayerLeftTeam != null)
					{
						PhotonTeamsManager.PlayerLeftTeam(targetPlayer, teamsByCode[key2]);
					}
					break;
				}
			}
			PhotonTeam photonTeam = teamsByCode[b];
			if (!playersPerTeam[b].Add(targetPlayer))
			{
				UnityEngine.Debug.LogWarningFormat("Unexpected situation while setting team {0} for player {1}, updating teams for all", photonTeam, targetPlayer);
				UpdateTeams();
			}
			if (PhotonTeamsManager.PlayerJoinedTeam != null)
			{
				PhotonTeamsManager.PlayerJoinedTeam(targetPlayer, photonTeam);
			}
		}
		else
		{
			UnityEngine.Debug.LogErrorFormat("Unexpected: custom property key {0} should have of type byte, instead we got {1} of type {2}. Player: {3}", "_pt", value, value.GetType(), targetPlayer);
		}
	}

	void IInRoomCallbacks.OnPlayerLeftRoom(Player otherPlayer)
	{
		if (!otherPlayer.IsInactive)
		{
			PhotonTeam photonTeam = otherPlayer.GetPhotonTeam();
			if (photonTeam != null && !playersPerTeam[photonTeam.Code].Remove(otherPlayer))
			{
				UnityEngine.Debug.LogWarningFormat("Unexpected situation while removing player {0} who left from team {1}, updating teams for all", otherPlayer, photonTeam);
				UpdateTeams();
			}
		}
	}

	void IInRoomCallbacks.OnPlayerEnteredRoom(Player newPlayer)
	{
		PhotonTeam photonTeam = newPlayer.GetPhotonTeam();
		if (photonTeam == null || playersPerTeam[photonTeam.Code].Contains(newPlayer))
		{
			return;
		}
		foreach (byte key in teamsByCode.Keys)
		{
			if (playersPerTeam[key].Remove(newPlayer))
			{
				break;
			}
		}
		if (!playersPerTeam[photonTeam.Code].Add(newPlayer))
		{
			UnityEngine.Debug.LogWarningFormat("Unexpected situation while adding player {0} who joined to team {1}, updating teams for all", newPlayer, photonTeam);
			UpdateTeams();
		}
	}

	private void UpdateTeams()
	{
		ClearTeams();
		for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
		{
			Player player = PhotonNetwork.PlayerList[i];
			PhotonTeam photonTeam = player.GetPhotonTeam();
			if (photonTeam != null)
			{
				playersPerTeam[photonTeam.Code].Add(player);
			}
		}
	}

	private void ClearTeams()
	{
		foreach (byte key in playersPerTeam.Keys)
		{
			playersPerTeam[key].Clear();
		}
	}

	public bool TryGetTeamByCode(byte code, out PhotonTeam team)
	{
		return teamsByCode.TryGetValue(code, out team);
	}

	public bool TryGetTeamByName(string teamName, out PhotonTeam team)
	{
		return teamsByName.TryGetValue(teamName, out team);
	}

	public PhotonTeam[] GetAvailableTeams()
	{
		if (teamsList != null)
		{
			return teamsList.ToArray();
		}
		return null;
	}

	public bool TryGetTeamMembers(byte code, out Player[] members)
	{
		members = null;
		if (playersPerTeam.TryGetValue(code, out var value))
		{
			members = new Player[value.Count];
			int num = 0;
			foreach (Player item in value)
			{
				members[num] = item;
				num++;
			}
			return true;
		}
		return false;
	}

	public bool TryGetTeamMembers(string teamName, out Player[] members)
	{
		members = null;
		if (TryGetTeamByName(teamName, out var team))
		{
			return TryGetTeamMembers(team.Code, out members);
		}
		return false;
	}

	public bool TryGetTeamMembers(PhotonTeam team, out Player[] members)
	{
		members = null;
		if (team != null)
		{
			return TryGetTeamMembers(team.Code, out members);
		}
		return false;
	}

	public bool TryGetTeamMatesOfPlayer(Player player, out Player[] teamMates)
	{
		teamMates = null;
		if (player == null)
		{
			return false;
		}
		PhotonTeam photonTeam = player.GetPhotonTeam();
		if (photonTeam == null)
		{
			return false;
		}
		if (playersPerTeam.TryGetValue(photonTeam.Code, out var value))
		{
			if (!value.Contains(player))
			{
				UnityEngine.Debug.LogWarningFormat("Unexpected situation while getting team mates of player {0} who is joined to team {1}, updating teams for all", player, photonTeam);
				UpdateTeams();
			}
			teamMates = new Player[value.Count - 1];
			int num = 0;
			foreach (Player item in value)
			{
				if (!item.Equals(player))
				{
					teamMates[num] = item;
					num++;
				}
			}
			return true;
		}
		return false;
	}

	public int GetTeamMembersCount(byte code)
	{
		if (TryGetTeamByCode(code, out var team))
		{
			return GetTeamMembersCount(team);
		}
		return 0;
	}

	public int GetTeamMembersCount(string name)
	{
		if (TryGetTeamByName(name, out var team))
		{
			return GetTeamMembersCount(team);
		}
		return 0;
	}

	public int GetTeamMembersCount(PhotonTeam team)
	{
		if (team != null && playersPerTeam.TryGetValue(team.Code, out var value) && value != null)
		{
			return value.Count;
		}
		return 0;
	}

	void IMatchmakingCallbacks.OnFriendListUpdate(List<FriendInfo> friendList)
	{
	}

	void IMatchmakingCallbacks.OnCreatedRoom()
	{
	}

	void IMatchmakingCallbacks.OnCreateRoomFailed(short returnCode, string message)
	{
	}

	void IMatchmakingCallbacks.OnJoinRoomFailed(short returnCode, string message)
	{
	}

	void IMatchmakingCallbacks.OnJoinRandomFailed(short returnCode, string message)
	{
	}

	void IInRoomCallbacks.OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
	{
	}

	void IInRoomCallbacks.OnMasterClientSwitched(Player newMasterClient)
	{
	}
}
public static class PhotonTeamExtensions
{
	public static PhotonTeam GetPhotonTeam(this Player player)
	{
		if (player.CustomProperties.TryGetValue("_pt", out var value) && PhotonTeamsManager.Instance.TryGetTeamByCode((byte)value, out var team))
		{
			return team;
		}
		return null;
	}

	public static bool JoinTeam(this Player player, PhotonTeam team)
	{
		if (team == null)
		{
			UnityEngine.Debug.LogWarning("JoinTeam failed: PhotonTeam provided is null");
			return false;
		}
		if (player.GetPhotonTeam() != null)
		{
			UnityEngine.Debug.LogWarningFormat("JoinTeam failed: player ({0}) is already joined to a team ({1}), call SwitchTeam instead", player, team);
			return false;
		}
		return player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { { "_pt", team.Code } });
	}

	public static bool JoinTeam(this Player player, byte teamCode)
	{
		if (PhotonTeamsManager.Instance.TryGetTeamByCode(teamCode, out var team))
		{
			return player.JoinTeam(team);
		}
		return false;
	}

	public static bool JoinTeam(this Player player, string teamName)
	{
		if (PhotonTeamsManager.Instance.TryGetTeamByName(teamName, out var team))
		{
			return player.JoinTeam(team);
		}
		return false;
	}

	public static bool SwitchTeam(this Player player, PhotonTeam team)
	{
		if (team == null)
		{
			UnityEngine.Debug.LogWarning("SwitchTeam failed: PhotonTeam provided is null");
			return false;
		}
		PhotonTeam photonTeam = player.GetPhotonTeam();
		if (photonTeam == null)
		{
			UnityEngine.Debug.LogWarningFormat("SwitchTeam failed: player ({0}) was not joined to any team, call JoinTeam instead", player);
			return false;
		}
		if (photonTeam.Code == team.Code)
		{
			UnityEngine.Debug.LogWarningFormat("SwitchTeam failed: player ({0}) is already joined to the same team {1}", player, team);
			return false;
		}
		return player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { { "_pt", team.Code } }, new ExitGames.Client.Photon.Hashtable { { "_pt", photonTeam.Code } });
	}

	public static bool SwitchTeam(this Player player, byte teamCode)
	{
		if (PhotonTeamsManager.Instance.TryGetTeamByCode(teamCode, out var team))
		{
			return player.SwitchTeam(team);
		}
		return false;
	}

	public static bool SwitchTeam(this Player player, string teamName)
	{
		if (PhotonTeamsManager.Instance.TryGetTeamByName(teamName, out var team))
		{
			return player.SwitchTeam(team);
		}
		return false;
	}

	public static bool LeaveCurrentTeam(this Player player)
	{
		PhotonTeam photonTeam = player.GetPhotonTeam();
		if (photonTeam == null)
		{
			UnityEngine.Debug.LogWarningFormat("LeaveCurrentTeam failed: player ({0}) was not joined to any team", player);
			return false;
		}
		return player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { { "_pt", null } }, new ExitGames.Client.Photon.Hashtable { { "_pt", photonTeam.Code } });
	}

	public static bool TryGetTeamMates(this Player player, out Player[] teamMates)
	{
		return PhotonTeamsManager.Instance.TryGetTeamMatesOfPlayer(player, out teamMates);
	}
}
public class PlayerNumbering : MonoBehaviourPunCallbacks
{
	public delegate void PlayerNumberingChanged();

	public static PlayerNumbering instance;

	public static Player[] SortedPlayers;

	public const string RoomPlayerIndexedProp = "pNr";

	public bool dontDestroyOnLoad;

	public static event PlayerNumberingChanged OnPlayerNumberingChanged;

	public void Awake()
	{
		if (instance != null && instance != this && instance.gameObject != null)
		{
			UnityEngine.Object.DestroyImmediate(instance.gameObject);
		}
		instance = this;
		if (dontDestroyOnLoad)
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
		RefreshData();
	}

	public override void OnJoinedRoom()
	{
		RefreshData();
	}

	public override void OnLeftRoom()
	{
		PhotonNetwork.LocalPlayer.CustomProperties.Remove("pNr");
	}

	public override void OnPlayerEnteredRoom(Player newPlayer)
	{
		RefreshData();
	}

	public override void OnPlayerLeftRoom(Player otherPlayer)
	{
		RefreshData();
	}

	public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
	{
		if (changedProps != null && changedProps.ContainsKey("pNr"))
		{
			RefreshData();
		}
	}

	public void RefreshData()
	{
		if (PhotonNetwork.CurrentRoom == null)
		{
			return;
		}
		if (PhotonNetwork.LocalPlayer.GetPlayerNumber() >= 0)
		{
			SortedPlayers = PhotonNetwork.CurrentRoom.Players.Values.OrderBy((Player p) => p.GetPlayerNumber()).ToArray();
			if (PlayerNumbering.OnPlayerNumberingChanged != null)
			{
				PlayerNumbering.OnPlayerNumberingChanged();
			}
			return;
		}
		HashSet<int> hashSet = new HashSet<int>();
		Player[] array = PhotonNetwork.PlayerList.OrderBy((Player p) => p.ActorNumber).ToArray();
		string text = "all players: ";
		Player[] array2 = array;
		foreach (Player player in array2)
		{
			text = text + player.ActorNumber + "=pNr:" + player.GetPlayerNumber() + ", ";
			int playerNumber = player.GetPlayerNumber();
			if (player.IsLocal)
			{
				UnityEngine.Debug.Log("PhotonNetwork.CurrentRoom.PlayerCount = " + PhotonNetwork.CurrentRoom.PlayerCount);
				for (int num2 = 0; num2 < PhotonNetwork.CurrentRoom.PlayerCount; num2++)
				{
					if (!hashSet.Contains(num2))
					{
						player.SetPlayerNumber(num2);
						break;
					}
				}
				break;
			}
			if (playerNumber < 0)
			{
				break;
			}
			hashSet.Add(playerNumber);
		}
		SortedPlayers = PhotonNetwork.CurrentRoom.Players.Values.OrderBy((Player p) => p.GetPlayerNumber()).ToArray();
		if (PlayerNumbering.OnPlayerNumberingChanged != null)
		{
			PlayerNumbering.OnPlayerNumberingChanged();
		}
	}
}
public static class PlayerNumberingExtensions
{
	public static int GetPlayerNumber(this Player player)
	{
		if (player == null)
		{
			return -1;
		}
		if (PhotonNetwork.OfflineMode)
		{
			return 0;
		}
		if (!PhotonNetwork.IsConnectedAndReady)
		{
			return -1;
		}
		if (player.CustomProperties.TryGetValue("pNr", out var value))
		{
			return (byte)value;
		}
		return -1;
	}

	public static void SetPlayerNumber(this Player player, int playerNumber)
	{
		if (player != null && !PhotonNetwork.OfflineMode)
		{
			if (playerNumber < 0)
			{
				UnityEngine.Debug.LogWarning("Setting invalid playerNumber: " + playerNumber + " for: " + player.ToStringFull());
			}
			if (!PhotonNetwork.IsConnectedAndReady)
			{
				UnityEngine.Debug.LogWarning("SetPlayerNumber was called in state: " + PhotonNetwork.NetworkClientState.ToString() + ". Not IsConnectedAndReady.");
			}
			else if (player.GetPlayerNumber() != playerNumber)
			{
				UnityEngine.Debug.Log("PlayerNumbering: Set number " + playerNumber);
				player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { 
				{
					"pNr",
					(byte)playerNumber
				} });
			}
		}
	}
}
public class PunPlayerScores : MonoBehaviour
{
	public const string PlayerScoreProp = "score";
}
public static class ScoreExtensions
{
	public static void SetScore(this Player player, int newScore)
	{
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable["score"] = newScore;
		player.SetCustomProperties(hashtable);
	}

	public static void AddScore(this Player player, int scoreToAddToCurrent)
	{
		int score = player.GetScore();
		score += scoreToAddToCurrent;
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable["score"] = score;
		player.SetCustomProperties(hashtable);
	}

	public static int GetScore(this Player player)
	{
		if (player.CustomProperties.TryGetValue("score", out var value))
		{
			return (int)value;
		}
		return 0;
	}
}
[Obsolete("do not use this or add it to the scene. use PhotonTeamsManager instead")]
public class PunTeams : MonoBehaviourPunCallbacks
{
	[Obsolete("use custom PhotonTeam instead")]
	public enum Team : byte
	{
		none,
		red,
		blue
	}

	[Obsolete("use PhotonTeamsManager.Instance.TryGetTeamMembers instead")]
	public static Dictionary<Team, List<Player>> PlayersPerTeam;

	[Obsolete("do not use this. PhotonTeamsManager.TeamPlayerProp is used internally instead.")]
	public const string TeamPlayerProp = "team";

	public void Start()
	{
		PlayersPerTeam = new Dictionary<Team, List<Player>>();
		foreach (object value in Enum.GetValues(typeof(Team)))
		{
			PlayersPerTeam[(Team)value] = new List<Player>();
		}
	}

	public override void OnDisable()
	{
		base.OnDisable();
		Start();
	}

	public override void OnJoinedRoom()
	{
		UpdateTeams();
	}

	public override void OnLeftRoom()
	{
		Start();
	}

	public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
	{
		UpdateTeams();
	}

	public override void OnPlayerLeftRoom(Player otherPlayer)
	{
		UpdateTeams();
	}

	public override void OnPlayerEnteredRoom(Player newPlayer)
	{
		UpdateTeams();
	}

	[Obsolete("do not call this.")]
	public void UpdateTeams()
	{
		foreach (object value in Enum.GetValues(typeof(Team)))
		{
			PlayersPerTeam[(Team)value].Clear();
		}
		for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
		{
			Player player = PhotonNetwork.PlayerList[i];
			Team team = player.GetTeam();
			PlayersPerTeam[team].Add(player);
		}
	}
}
public static class TeamExtensions
{
	[Obsolete("Use player.GetPhotonTeam")]
	public static PunTeams.Team GetTeam(this Player player)
	{
		if (player.CustomProperties.TryGetValue("team", out var value))
		{
			return (PunTeams.Team)value;
		}
		return PunTeams.Team.none;
	}

	[Obsolete("Use player.JoinTeam")]
	public static void SetTeam(this Player player, PunTeams.Team team)
	{
		if (!PhotonNetwork.IsConnectedAndReady)
		{
			UnityEngine.Debug.LogWarning("JoinTeam was called in state: " + PhotonNetwork.NetworkClientState.ToString() + ". Not IsConnectedAndReady.");
		}
		else if (player.GetTeam() != team)
		{
			player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { 
			{
				"team",
				(byte)team
			} });
		}
	}
}
[RequireComponent(typeof(PhotonView))]
public class SmoothSyncMovement : MonoBehaviourPun, IPunObservable
{
	public float SmoothingDelay = 5f;

	private Vector3 correctPlayerPos = Vector3.zero;

	private Quaternion correctPlayerRot = Quaternion.identity;

	public void Awake()
	{
		bool flag = false;
		foreach (UnityEngine.Component observedComponent in base.photonView.ObservedComponents)
		{
			if (observedComponent == this)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			UnityEngine.Debug.LogWarning(this?.ToString() + " is not observed by this object's photonView! OnPhotonSerializeView() in this class won't be used.");
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			stream.SendNext(base.transform.position);
			stream.SendNext(base.transform.rotation);
		}
		else
		{
			correctPlayerPos = (Vector3)stream.ReceiveNext();
			correctPlayerRot = (Quaternion)stream.ReceiveNext();
		}
	}

	public void Update()
	{
		if (!base.photonView.IsMine)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, correctPlayerPos, Time.deltaTime * SmoothingDelay);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, correctPlayerRot, Time.deltaTime * SmoothingDelay);
		}
	}
}
public class ConnectAndJoinRandom : MonoBehaviourPunCallbacks
{
	public bool AutoConnect = true;

	public byte Version = 1;

	[Tooltip("The max number of players allowed in room. Once full, a new room will be created by the next connection attemping to join.")]
	public byte MaxPlayers = 4;

	public int playerTTL = -1;

	public void Start()
	{
		if (AutoConnect)
		{
			ConnectNow();
		}
	}

	public void ConnectNow()
	{
		UnityEngine.Debug.Log("ConnectAndJoinRandom.ConnectNow() will now call: PhotonNetwork.ConnectUsingSettings().");
		PhotonNetwork.ConnectUsingSettings();
		PhotonNetwork.GameVersion = Version + "." + SceneManagerHelper.ActiveSceneBuildIndex;
	}

	public override void OnConnectedToMaster()
	{
		UnityEngine.Debug.Log("OnConnectedToMaster() was called by PUN. This client is now connected to Master Server in region [" + PhotonNetwork.CloudRegion + "] and can join a room. Calling: PhotonNetwork.JoinRandomRoom();");
		PhotonNetwork.JoinRandomRoom();
	}

	public override void OnJoinedLobby()
	{
		UnityEngine.Debug.Log("OnJoinedLobby(). This client is now connected to Relay in region [" + PhotonNetwork.CloudRegion + "]. This script now calls: PhotonNetwork.JoinRandomRoom();");
		PhotonNetwork.JoinRandomRoom();
	}

	public override void OnJoinRandomFailed(short returnCode, string message)
	{
		UnityEngine.Debug.Log("OnJoinRandomFailed() was called by PUN. No random room available in region [" + PhotonNetwork.CloudRegion + "], so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
		RoomOptions roomOptions = new RoomOptions
		{
			MaxPlayers = MaxPlayers
		};
		if (playerTTL >= 0)
		{
			roomOptions.PlayerTtl = playerTTL;
		}
		PhotonNetwork.CreateRoom(null, roomOptions);
	}

	public override void OnDisconnected(DisconnectCause cause)
	{
		UnityEngine.Debug.Log("OnDisconnected(" + cause.ToString() + ")");
	}

	public override void OnJoinedRoom()
	{
		UnityEngine.Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room in region [" + PhotonNetwork.CloudRegion + "]. Game is now running.");
	}
}
[RequireComponent(typeof(PhotonView))]
public class MoveByKeys : MonoBehaviourPun
{
	public float Speed = 10f;

	public float JumpForce = 200f;

	public float JumpTimeout = 0.5f;

	private bool isSprite;

	private float jumpingTime;

	private Rigidbody body;

	private Rigidbody2D body2d;

	public void Start()
	{
		isSprite = GetComponent<SpriteRenderer>() != null;
		body2d = GetComponent<Rigidbody2D>();
		body = GetComponent<Rigidbody>();
	}

	public void FixedUpdate()
	{
		if (!base.photonView.IsMine)
		{
			return;
		}
		if (Input.GetAxisRaw("Horizontal") < -0.1f || Input.GetAxisRaw("Horizontal") > 0.1f)
		{
			base.transform.position += Vector3.right * (Speed * Time.deltaTime) * Input.GetAxisRaw("Horizontal");
		}
		if (jumpingTime <= 0f)
		{
			if ((body != null || body2d != null) && Input.GetKey(KeyCode.Space))
			{
				jumpingTime = JumpTimeout;
				Vector2 vector = Vector2.up * JumpForce;
				if (body2d != null)
				{
					body2d.AddForce(vector);
				}
				else if (body != null)
				{
					body.AddForce(vector);
				}
			}
		}
		else
		{
			jumpingTime -= Time.deltaTime;
		}
		if (!isSprite && (Input.GetAxisRaw("Vertical") < -0.1f || Input.GetAxisRaw("Vertical") > 0.1f))
		{
			base.transform.position += Vector3.forward * (Speed * Time.deltaTime) * Input.GetAxisRaw("Vertical");
		}
	}
}
public class OnClickDestroy : MonoBehaviourPun, IPointerClickHandler, IEventSystemHandler
{
	public PointerEventData.InputButton Button;

	public KeyCode ModifierKey;

	public bool DestroyByRpc;

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		if (PhotonNetwork.InRoom && (ModifierKey == KeyCode.None || Input.GetKey(ModifierKey)) && eventData.button == Button)
		{
			if (DestroyByRpc)
			{
				base.photonView.RPC("DestroyRpc", RpcTarget.AllBuffered);
			}
			else
			{
				PhotonNetwork.Destroy(base.gameObject);
			}
		}
	}

	[PunRPC]
	public IEnumerator DestroyRpc()
	{
		UnityEngine.Object.Destroy(base.gameObject);
		yield return 0;
	}
}
public class OnClickInstantiate : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public enum InstantiateOption
	{
		Mine,
		Scene
	}

	public PointerEventData.InputButton Button;

	public KeyCode ModifierKey;

	public GameObject Prefab;

	[SerializeField]
	private InstantiateOption InstantiateType;

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		if (PhotonNetwork.InRoom && (ModifierKey == KeyCode.None || Input.GetKey(ModifierKey)) && eventData.button == Button)
		{
			switch (InstantiateType)
			{
			case InstantiateOption.Mine:
				PhotonNetwork.Instantiate(Prefab.name, eventData.pointerCurrentRaycast.worldPosition + new Vector3(0f, 0.5f, 0f), Quaternion.identity, 0);
				break;
			case InstantiateOption.Scene:
				PhotonNetwork.InstantiateRoomObject(Prefab.name, eventData.pointerCurrentRaycast.worldPosition + new Vector3(0f, 0.5f, 0f), Quaternion.identity, 0);
				break;
			}
		}
	}
}
public class OnClickRpc : MonoBehaviourPun, IPointerClickHandler, IEventSystemHandler
{
	public PointerEventData.InputButton Button;

	public KeyCode ModifierKey;

	public RpcTarget Target;

	private Material originalMaterial;

	private Color originalColor;

	private bool isFlashing;

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		if (PhotonNetwork.InRoom && (ModifierKey == KeyCode.None || Input.GetKey(ModifierKey)) && eventData.button == Button)
		{
			base.photonView.RPC("ClickRpc", Target);
		}
	}

	[PunRPC]
	public void ClickRpc()
	{
		StartCoroutine(ClickFlash());
	}

	public IEnumerator ClickFlash()
	{
		if (isFlashing)
		{
			yield break;
		}
		isFlashing = true;
		originalMaterial = GetComponent<Renderer>().material;
		if (!originalMaterial.HasProperty("_EmissionColor"))
		{
			UnityEngine.Debug.LogWarning("Doesn't have emission, can't flash " + base.gameObject);
			yield break;
		}
		bool wasEmissive = originalMaterial.IsKeywordEnabled("_EMISSION");
		originalMaterial.EnableKeyword("_EMISSION");
		originalColor = originalMaterial.GetColor("_EmissionColor");
		originalMaterial.SetColor("_EmissionColor", Color.white);
		for (float f = 0f; f <= 1f; f += 0.08f)
		{
			Color value = Color.Lerp(Color.white, originalColor, f);
			originalMaterial.SetColor("_EmissionColor", value);
			yield return null;
		}
		originalMaterial.SetColor("_EmissionColor", originalColor);
		if (!wasEmissive)
		{
			originalMaterial.DisableKeyword("_EMISSION");
		}
		isFlashing = false;
	}
}
public class OnEscapeQuit : MonoBehaviour
{
	[Conditional("UNITY_ANDROID")]
	[Conditional("UNITY_IOS")]
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
public class OnJoinedInstantiate : MonoBehaviour, IMatchmakingCallbacks
{
	public enum SpawnSequence
	{
		Connection,
		Random,
		RoundRobin
	}

	[HideInInspector]
	private Transform SpawnPosition;

	[HideInInspector]
	public SpawnSequence Sequence;

	[HideInInspector]
	public List<Transform> SpawnPoints = new List<Transform>(1) { null };

	[Tooltip("Add a random variance to a spawn point position. GetRandomOffset() can be overridden with your own method for producing offsets.")]
	[HideInInspector]
	public bool UseRandomOffset = true;

	[Tooltip("Radius of the RandomOffset.")]
	[FormerlySerializedAs("PositionOffset")]
	[HideInInspector]
	public float RandomOffset = 2f;

	[Tooltip("Disables the Y axis of RandomOffset. The Y value of the spawn point will be used.")]
	[HideInInspector]
	public bool ClampY = true;

	[HideInInspector]
	public List<GameObject> PrefabsToInstantiate = new List<GameObject>(1) { null };

	[FormerlySerializedAs("autoSpawnObjects")]
	[HideInInspector]
	public bool AutoSpawnObjects = true;

	public Stack<GameObject> SpawnedObjects = new Stack<GameObject>();

	protected int spawnedAsActorId;

	protected int lastUsedSpawnPointIndex = -1;

	public virtual void OnEnable()
	{
		PhotonNetwork.AddCallbackTarget(this);
	}

	public virtual void OnDisable()
	{
		PhotonNetwork.RemoveCallbackTarget(this);
	}

	public virtual void OnJoinedRoom()
	{
		if (AutoSpawnObjects && !PhotonNetwork.LocalPlayer.HasRejoined)
		{
			SpawnObjects();
		}
	}

	public virtual void SpawnObjects()
	{
		if (PrefabsToInstantiate == null)
		{
			return;
		}
		foreach (GameObject item2 in PrefabsToInstantiate)
		{
			if (!(item2 == null))
			{
				GetSpawnPoint(out var spawnPos, out var spawnRot);
				GameObject item = PhotonNetwork.Instantiate(item2.name, spawnPos, spawnRot, 0);
				SpawnedObjects.Push(item);
			}
		}
	}

	public virtual void DespawnObjects(bool localOnly)
	{
		while (SpawnedObjects.Count > 0)
		{
			GameObject gameObject = SpawnedObjects.Pop();
			if ((bool)gameObject)
			{
				if (localOnly)
				{
					UnityEngine.Object.Destroy(gameObject);
				}
				else
				{
					PhotonNetwork.Destroy(gameObject);
				}
			}
		}
	}

	public virtual void OnFriendListUpdate(List<FriendInfo> friendList)
	{
	}

	public virtual void OnCreatedRoom()
	{
	}

	public virtual void OnCreateRoomFailed(short returnCode, string message)
	{
	}

	public virtual void OnJoinRoomFailed(short returnCode, string message)
	{
	}

	public virtual void OnJoinRandomFailed(short returnCode, string message)
	{
	}

	public virtual void OnLeftRoom()
	{
	}

	public virtual void OnPreLeavingRoom()
	{
	}

	public virtual void GetSpawnPoint(out Vector3 spawnPos, out Quaternion spawnRot)
	{
		Transform spawnPoint = GetSpawnPoint();
		if (spawnPoint != null)
		{
			spawnPos = spawnPoint.position;
			spawnRot = spawnPoint.rotation;
		}
		else
		{
			spawnPos = new Vector3(0f, 0f, 0f);
			spawnRot = new Quaternion(0f, 0f, 0f, 1f);
		}
		if (UseRandomOffset)
		{
			UnityEngine.Random.InitState((int)(Time.time * 10000f));
			spawnPos += GetRandomOffset();
		}
	}

	protected virtual Transform GetSpawnPoint()
	{
		if (SpawnPoints == null || SpawnPoints.Count == 0)
		{
			return null;
		}
		switch (Sequence)
		{
		case SpawnSequence.Connection:
		{
			int actorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
			return SpawnPoints[(actorNumber != -1) ? (actorNumber % SpawnPoints.Count) : 0];
		}
		case SpawnSequence.RoundRobin:
			lastUsedSpawnPointIndex++;
			if (lastUsedSpawnPointIndex >= SpawnPoints.Count)
			{
				lastUsedSpawnPointIndex = 0;
			}
			if (SpawnPoints != null && SpawnPoints.Count != 0)
			{
				return SpawnPoints[lastUsedSpawnPointIndex];
			}
			return null;
		case SpawnSequence.Random:
			return SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Count)];
		default:
			return null;
		}
	}

	protected virtual Vector3 GetRandomOffset()
	{
		Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
		if (ClampY)
		{
			insideUnitSphere.y = 0f;
		}
		return RandomOffset * insideUnitSphere.normalized;
	}
}
public class OnStartDelete : MonoBehaviour
{
	private void Start()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
public class CountdownTimer : MonoBehaviourPunCallbacks
{
	public delegate void CountdownTimerHasExpired();

	public const string CountdownStartTime = "StartTime";

	[Header("Countdown time in seconds")]
	public float Countdown = 5f;

	private bool isTimerRunning;

	private int startTime;

	[Header("Reference to a Text component for visualizing the countdown")]
	public Text Text;

	public static event CountdownTimerHasExpired OnCountdownTimerHasExpired;

	public void Start()
	{
		if (Text == null)
		{
			UnityEngine.Debug.LogError("Reference to 'Text' is not set. Please set a valid reference.", this);
		}
	}

	public override void OnEnable()
	{
		UnityEngine.Debug.Log("OnEnable CountdownTimer");
		base.OnEnable();
		Initialize();
	}

	public override void OnDisable()
	{
		base.OnDisable();
		UnityEngine.Debug.Log("OnDisable CountdownTimer");
	}

	public void Update()
	{
		if (isTimerRunning)
		{
			float num = TimeRemaining();
			Text.text = string.Format("Game starts in {0} seconds", num.ToString("n0"));
			if (!(num > 0f))
			{
				OnTimerEnds();
			}
		}
	}

	private void OnTimerRuns()
	{
		isTimerRunning = true;
		base.enabled = true;
	}

	private void OnTimerEnds()
	{
		isTimerRunning = false;
		base.enabled = false;
		UnityEngine.Debug.Log("Emptying info text.", Text);
		Text.text = string.Empty;
		if (CountdownTimer.OnCountdownTimerHasExpired != null)
		{
			CountdownTimer.OnCountdownTimerHasExpired();
		}
	}

	public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
	{
		UnityEngine.Debug.Log("CountdownTimer.OnRoomPropertiesUpdate " + propertiesThatChanged.ToStringFull());
		Initialize();
	}

	private void Initialize()
	{
		if (TryGetStartTime(out var startTimestamp))
		{
			startTime = startTimestamp;
			UnityEngine.Debug.Log("Initialize sets StartTime " + startTime + " server time now: " + PhotonNetwork.ServerTimestamp + " remain: " + TimeRemaining());
			isTimerRunning = TimeRemaining() > 0f;
			if (isTimerRunning)
			{
				OnTimerRuns();
			}
			else
			{
				OnTimerEnds();
			}
		}
	}

	private float TimeRemaining()
	{
		int num = PhotonNetwork.ServerTimestamp - startTime;
		return Countdown - (float)num / 1000f;
	}

	public static bool TryGetStartTime(out int startTimestamp)
	{
		startTimestamp = PhotonNetwork.ServerTimestamp;
		if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("StartTime", out var value))
		{
			startTimestamp = (int)value;
			return true;
		}
		return false;
	}

	public static void SetStartTime()
	{
		int startTimestamp = 0;
		bool flag = TryGetStartTime(out startTimestamp);
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable { 
		{
			"StartTime",
			PhotonNetwork.ServerTimestamp
		} };
		PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable);
		UnityEngine.Debug.Log("Set Custom Props for Time: " + hashtable.ToStringFull() + " wasSet: " + flag);
	}
}
public class PunTurnManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
	private Player sender;

	public float TurnDuration = 20f;

	public IPunTurnManagerCallbacks TurnManagerListener;

	private readonly HashSet<Player> finishedPlayers = new HashSet<Player>();

	public const byte TurnManagerEventOffset = 0;

	public const byte EvMove = 1;

	public const byte EvFinalMove = 2;

	private bool _isOverCallProcessed;

	public int Turn
	{
		get
		{
			return PhotonNetwork.CurrentRoom.GetTurn();
		}
		private set
		{
			_isOverCallProcessed = false;
			PhotonNetwork.CurrentRoom.SetTurn(value, setStartTime: true);
		}
	}

	public float ElapsedTimeInTurn => (float)(PhotonNetwork.ServerTimestamp - PhotonNetwork.CurrentRoom.GetTurnStart()) / 1000f;

	public float RemainingSecondsInTurn => Mathf.Max(0f, TurnDuration - ElapsedTimeInTurn);

	public bool IsCompletedByAll
	{
		get
		{
			if (PhotonNetwork.CurrentRoom != null && Turn > 0)
			{
				return finishedPlayers.Count == PhotonNetwork.CurrentRoom.PlayerCount;
			}
			return false;
		}
	}

	public bool IsFinishedByMe => finishedPlayers.Contains(PhotonNetwork.LocalPlayer);

	public bool IsOver => RemainingSecondsInTurn <= 0f;

	private void Start()
	{
	}

	private void Update()
	{
		if (Turn > 0 && IsOver && !_isOverCallProcessed)
		{
			_isOverCallProcessed = true;
			TurnManagerListener.OnTurnTimeEnds(Turn);
		}
	}

	public void BeginTurn()
	{
		Turn++;
	}

	public void SendMove(object move, bool finished)
	{
		if (IsFinishedByMe)
		{
			UnityEngine.Debug.LogWarning("Can't SendMove. Turn is finished by this player.");
			return;
		}
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable.Add("turn", Turn);
		hashtable.Add("move", move);
		byte eventCode = (byte)((!finished) ? 1 : 2);
		PhotonNetwork.RaiseEvent(eventCode, hashtable, new RaiseEventOptions
		{
			CachingOption = EventCaching.AddToRoomCache
		}, SendOptions.SendReliable);
		if (finished)
		{
			PhotonNetwork.LocalPlayer.SetFinishedTurn(Turn);
		}
		ProcessOnEvent(eventCode, hashtable, PhotonNetwork.LocalPlayer.ActorNumber);
	}

	public bool GetPlayerFinishedTurn(Player player)
	{
		if (player != null && finishedPlayers != null && finishedPlayers.Contains(player))
		{
			return true;
		}
		return false;
	}

	private void ProcessOnEvent(byte eventCode, object content, int senderId)
	{
		if (senderId == -1)
		{
			return;
		}
		sender = PhotonNetwork.CurrentRoom.GetPlayer(senderId);
		switch (eventCode)
		{
		case 1:
		{
			ExitGames.Client.Photon.Hashtable obj2 = content as ExitGames.Client.Photon.Hashtable;
			int turn = (int)obj2["turn"];
			object move2 = obj2["move"];
			TurnManagerListener.OnPlayerMove(sender, turn, move2);
			break;
		}
		case 2:
		{
			ExitGames.Client.Photon.Hashtable obj = content as ExitGames.Client.Photon.Hashtable;
			int num = (int)obj["turn"];
			object move = obj["move"];
			if (num == Turn)
			{
				finishedPlayers.Add(sender);
				TurnManagerListener.OnPlayerFinished(sender, num, move);
			}
			if (IsCompletedByAll)
			{
				TurnManagerListener.OnTurnCompleted(Turn);
			}
			break;
		}
		}
	}

	public void OnEvent(EventData photonEvent)
	{
		ProcessOnEvent(photonEvent.Code, photonEvent.CustomData, photonEvent.Sender);
	}

	public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
	{
		if (propertiesThatChanged.ContainsKey("Turn"))
		{
			_isOverCallProcessed = false;
			finishedPlayers.Clear();
			TurnManagerListener.OnTurnBegins(Turn);
		}
	}
}
public interface IPunTurnManagerCallbacks
{
	void OnTurnBegins(int turn);

	void OnTurnCompleted(int turn);

	void OnPlayerMove(Player player, int turn, object move);

	void OnPlayerFinished(Player player, int turn, object move);

	void OnTurnTimeEnds(int turn);
}
public static class TurnExtensions
{
	public static readonly string TurnPropKey = "Turn";

	public static readonly string TurnStartPropKey = "TStart";

	public static readonly string FinishedTurnPropKey = "FToA";

	public static void SetTurn(this Room room, int turn, bool setStartTime = false)
	{
		if (room != null && room.CustomProperties != null)
		{
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			hashtable[TurnPropKey] = turn;
			if (setStartTime)
			{
				hashtable[TurnStartPropKey] = PhotonNetwork.ServerTimestamp;
			}
			room.SetCustomProperties(hashtable);
		}
	}

	public static int GetTurn(this RoomInfo room)
	{
		if (room == null || room.CustomProperties == null || !room.CustomProperties.ContainsKey(TurnPropKey))
		{
			return 0;
		}
		return (int)room.CustomProperties[TurnPropKey];
	}

	public static int GetTurnStart(this RoomInfo room)
	{
		if (room == null || room.CustomProperties == null || !room.CustomProperties.ContainsKey(TurnStartPropKey))
		{
			return 0;
		}
		return (int)room.CustomProperties[TurnStartPropKey];
	}

	public static int GetFinishedTurn(this Player player)
	{
		Room currentRoom = PhotonNetwork.CurrentRoom;
		if (currentRoom == null || currentRoom.CustomProperties == null || !currentRoom.CustomProperties.ContainsKey(TurnPropKey))
		{
			return 0;
		}
		string key = FinishedTurnPropKey + player.ActorNumber;
		return (int)currentRoom.CustomProperties[key];
	}

	public static void SetFinishedTurn(this Player player, int turn)
	{
		Room currentRoom = PhotonNetwork.CurrentRoom;
		if (currentRoom != null && currentRoom.CustomProperties != null)
		{
			string key = FinishedTurnPropKey + player.ActorNumber;
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			hashtable[key] = turn;
			currentRoom.SetCustomProperties(hashtable);
		}
	}
}
public class ButtonInsideScrollList : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	private ScrollRect scrollRect;

	private void Start()
	{
		scrollRect = GetComponentInParent<ScrollRect>();
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		if (scrollRect != null)
		{
			scrollRect.StopMovement();
			scrollRect.enabled = false;
		}
	}

	void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
	{
		if (scrollRect != null && !scrollRect.enabled)
		{
			scrollRect.enabled = true;
		}
	}
}
public class EventSystemSpawner : MonoBehaviour
{
	private void OnEnable()
	{
		UnityEngine.Debug.LogError("PUN Demos are not compatible with the New Input System, unless you enable \"Both\" in: Edit > Project Settings > Player > Active Input Handling. Pausing App.");
		UnityEngine.Debug.Break();
	}
}
[RequireComponent(typeof(Graphic))]
public class GraphicToggleIsOnTransition : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Toggle toggle;

	private Graphic _graphic;

	public Color NormalOnColor = Color.white;

	public Color NormalOffColor = Color.black;

	public Color HoverOnColor = Color.black;

	public Color HoverOffColor = Color.black;

	private bool isHover;

	public void OnPointerEnter(PointerEventData eventData)
	{
		isHover = true;
		_graphic.color = (toggle.isOn ? HoverOnColor : HoverOffColor);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isHover = false;
		_graphic.color = (toggle.isOn ? NormalOnColor : NormalOffColor);
	}

	public void OnEnable()
	{
		_graphic = GetComponent<Graphic>();
		OnValueChanged(toggle.isOn);
		toggle.onValueChanged.AddListener(OnValueChanged);
	}

	public void OnDisable()
	{
		toggle.onValueChanged.RemoveListener(OnValueChanged);
	}

	public void OnValueChanged(bool isOn)
	{
		_graphic.color = ((!isOn) ? (isHover ? NormalOffColor : NormalOffColor) : (isHover ? HoverOnColor : HoverOnColor));
	}
}
public class OnPointerOverTooltip : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private void OnDestroy()
	{
		PointedAtGameObjectInfo.Instance.RemoveFocus(GetComponent<PhotonView>());
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		PointedAtGameObjectInfo.Instance.RemoveFocus(GetComponent<PhotonView>());
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		PointedAtGameObjectInfo.Instance.SetFocus(GetComponent<PhotonView>());
	}
}
public class TabViewManager : MonoBehaviour
{
	[Serializable]
	public class TabChangeEvent : UnityEvent<string>
	{
	}

	[Serializable]
	public class Tab
	{
		public string ID = "";

		public Toggle Toggle;

		public RectTransform View;
	}

	public ToggleGroup ToggleGroup;

	public Tab[] Tabs;

	public TabChangeEvent OnTabChanged;

	protected Tab CurrentTab;

	private Dictionary<Toggle, Tab> Tab_lut;

	private void Start()
	{
		Tab_lut = new Dictionary<Toggle, Tab>();
		Tab[] tabs = Tabs;
		foreach (Tab _tab in tabs)
		{
			Tab_lut[_tab.Toggle] = _tab;
			_tab.View.gameObject.SetActive(_tab.Toggle.isOn);
			if (_tab.Toggle.isOn)
			{
				CurrentTab = _tab;
			}
			_tab.Toggle.onValueChanged.AddListener(delegate(bool isSelected)
			{
				if (isSelected)
				{
					OnTabSelected(_tab);
				}
			});
		}
	}

	public void SelectTab(string id)
	{
		Tab[] tabs = Tabs;
		foreach (Tab tab in tabs)
		{
			if (tab.ID == id)
			{
				tab.Toggle.isOn = true;
				break;
			}
		}
	}

	private void OnTabSelected(Tab tab)
	{
		CurrentTab.View.gameObject.SetActive(value: false);
		CurrentTab = Tab_lut[ToggleGroup.ActiveToggles().FirstOrDefault()];
		CurrentTab.View.gameObject.SetActive(value: true);
		OnTabChanged.Invoke(CurrentTab.ID);
	}
}
[RequireComponent(typeof(Text))]
public class TextButtonTransition : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private Text _text;

	public Selectable Selectable;

	public Color NormalColor = Color.white;

	public Color HoverColor = Color.black;

	public void Awake()
	{
		_text = GetComponent<Text>();
	}

	public void OnEnable()
	{
		_text.color = NormalColor;
	}

	public void OnDisable()
	{
		_text.color = NormalColor;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (Selectable == null || Selectable.IsInteractable())
		{
			_text.color = HoverColor;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (Selectable == null || Selectable.IsInteractable())
		{
			_text.color = NormalColor;
		}
	}
}
[RequireComponent(typeof(Text))]
public class TextToggleIsOnTransition : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Toggle toggle;

	private Text _text;

	public Color NormalOnColor = Color.white;

	public Color NormalOffColor = Color.black;

	public Color HoverOnColor = Color.black;

	public Color HoverOffColor = Color.black;

	private bool isHover;

	public void OnEnable()
	{
		_text = GetComponent<Text>();
		OnValueChanged(toggle.isOn);
		toggle.onValueChanged.AddListener(OnValueChanged);
	}

	public void OnDisable()
	{
		toggle.onValueChanged.RemoveListener(OnValueChanged);
	}

	public void OnValueChanged(bool isOn)
	{
		_text.color = ((!isOn) ? (isHover ? NormalOffColor : NormalOffColor) : (isHover ? HoverOnColor : HoverOnColor));
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		isHover = true;
		_text.color = (toggle.isOn ? HoverOnColor : HoverOffColor);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isHover = false;
		_text.color = (toggle.isOn ? NormalOnColor : NormalOffColor);
	}
}
