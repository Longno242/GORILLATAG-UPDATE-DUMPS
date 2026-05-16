using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Meta.Voice;
using Meta.WitAi;
using Meta.WitAi.Configuration;
using Meta.WitAi.Data;
using Meta.WitAi.Data.Configuration;
using Meta.WitAi.Events;
using Meta.WitAi.Interfaces;
using Meta.WitAi.Json;
using Meta.WitAi.Requests;
using Meta.WitAi.TTS;
using Meta.WitAi.TTS.Data;
using Oculus.Voice;
using Oculus.Voice.Bindings.Android;
using Oculus.Voice.Core.Bindings.Android;
using Oculus.Voice.Core.Bindings.Android.PlatformLogger;
using Oculus.Voice.Core.Bindings.Interfaces;
using Oculus.Voice.Core.Utilities;
using Oculus.Voice.Interfaces;
using Oculus.VoiceSDK.Utilities;
using UnityEngine;
using UnityEngine.Scripting;
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
			FilePathsData = new byte[2040]
			{
				0, 0, 0, 1, 0, 0, 0, 109, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 118, 111, 105, 99,
				101, 64, 100, 51, 102, 54, 102, 51, 55, 98,
				56, 101, 49, 99, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 66, 105, 110, 100, 105, 110, 103, 115, 92,
				65, 110, 100, 114, 111, 105, 100, 92, 73, 86,
				67, 66, 105, 110, 100, 105, 110, 103, 69, 118,
				101, 110, 116, 115, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 108, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 118, 111, 105, 99, 101, 64, 100,
				51, 102, 54, 102, 51, 55, 98, 56, 101, 49,
				99, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 66, 105,
				110, 100, 105, 110, 103, 115, 92, 65, 110, 100,
				114, 111, 105, 100, 92, 86, 111, 105, 99, 101,
				83, 68, 75, 66, 105, 110, 100, 105, 110, 103,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				114, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 118,
				111, 105, 99, 101, 64, 100, 51, 102, 54, 102,
				51, 55, 98, 56, 101, 49, 99, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 66, 105, 110, 100, 105, 110,
				103, 115, 92, 65, 110, 100, 114, 111, 105, 100,
				92, 86, 111, 105, 99, 101, 83, 68, 75, 67,
				111, 110, 102, 105, 103, 66, 105, 110, 100, 105,
				110, 103, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 105, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 118, 111, 105, 99, 101, 64, 100, 51, 102,
				54, 102, 51, 55, 98, 56, 101, 49, 99, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 66, 105, 110, 100,
				105, 110, 103, 115, 92, 65, 110, 100, 114, 111,
				105, 100, 92, 86, 111, 105, 99, 101, 83, 68,
				75, 73, 109, 112, 108, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 112, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 118, 111, 105, 99, 101, 64,
				100, 51, 102, 54, 102, 51, 55, 98, 56, 101,
				49, 99, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 66,
				105, 110, 100, 105, 110, 103, 115, 92, 65, 110,
				100, 114, 111, 105, 100, 92, 86, 111, 105, 99,
				101, 83, 68, 75, 73, 109, 112, 108, 82, 101,
				113, 117, 101, 115, 116, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 116, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 118, 111, 105, 99, 101, 64,
				100, 51, 102, 54, 102, 51, 55, 98, 56, 101,
				49, 99, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 66,
				105, 110, 100, 105, 110, 103, 115, 92, 65, 110,
				100, 114, 111, 105, 100, 92, 86, 111, 105, 99,
				101, 83, 68, 75, 76, 105, 115, 116, 101, 110,
				101, 114, 66, 105, 110, 100, 105, 110, 103, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 108,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 118, 111,
				105, 99, 101, 64, 100, 51, 102, 54, 102, 51,
				55, 98, 56, 101, 49, 99, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 73, 110, 116, 101, 114, 102, 97,
				99, 101, 115, 92, 73, 80, 108, 97, 116, 102,
				111, 114, 109, 86, 111, 105, 99, 101, 83, 101,
				114, 118, 105, 99, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 116, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 118, 111, 105, 99, 101, 64,
				100, 51, 102, 54, 102, 51, 55, 98, 56, 101,
				49, 99, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 73,
				110, 116, 101, 114, 102, 97, 99, 101, 115, 92,
				73, 80, 108, 97, 116, 102, 111, 114, 109, 86,
				111, 105, 99, 101, 83, 101, 114, 118, 105, 99,
				101, 79, 118, 101, 114, 114, 105, 100, 101, 46,
				99, 115, 0, 0, 0, 2, 0, 0, 0, 101,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 118, 111,
				105, 99, 101, 64, 100, 51, 102, 54, 102, 51,
				55, 98, 56, 101, 49, 99, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 76, 111, 103, 103, 105, 110, 103,
				92, 84, 84, 83, 83, 101, 114, 118, 105, 99,
				101, 76, 111, 103, 103, 105, 110, 103, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 95, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 118, 111, 105,
				99, 101, 64, 100, 51, 102, 54, 102, 51, 55,
				98, 56, 101, 49, 99, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 83, 101, 114, 118, 105, 99, 101, 92,
				65, 112, 112, 66, 117, 105, 108, 116, 73, 110,
				115, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 102, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				118, 111, 105, 99, 101, 64, 100, 51, 102, 54,
				102, 51, 55, 98, 56, 101, 49, 99, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 83, 101, 114, 118, 105,
				99, 101, 92, 65, 112, 112, 86, 111, 105, 99,
				101, 69, 120, 112, 101, 114, 105, 101, 110, 99,
				101, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 105, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				118, 111, 105, 99, 101, 64, 100, 51, 102, 54,
				102, 51, 55, 98, 56, 101, 49, 99, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 83, 101, 114, 118, 105,
				99, 101, 92, 79, 98, 106, 101, 99, 116, 86,
				111, 105, 99, 101, 69, 120, 112, 101, 114, 105,
				101, 110, 99, 101, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 107, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 118, 111, 105, 99, 101, 64, 100,
				51, 102, 54, 102, 51, 55, 98, 56, 101, 49,
				99, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 85, 116,
				105, 108, 105, 116, 105, 101, 115, 92, 77, 105,
				99, 80, 101, 114, 109, 105, 115, 115, 105, 111,
				110, 115, 77, 97, 110, 97, 103, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 105,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 118, 111,
				105, 99, 101, 64, 100, 51, 102, 54, 102, 51,
				55, 98, 56, 101, 49, 99, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 85, 116, 105, 108, 105, 116, 105,
				101, 115, 92, 86, 111, 105, 99, 101, 69, 114,
				114, 111, 114, 83, 105, 109, 117, 108, 97, 116,
				111, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 98, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 118, 111, 105, 99, 101, 64, 100, 51, 102,
				54, 102, 51, 55, 98, 56, 101, 49, 99, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 85, 88, 92, 72,
				105, 101, 114, 97, 114, 99, 104, 121, 83, 105,
				109, 112, 108, 105, 102, 105, 101, 114, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 100, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 118, 111, 105,
				99, 101, 64, 100, 51, 102, 54, 102, 51, 55,
				98, 56, 101, 49, 99, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 85, 88, 92, 86, 111, 105, 99, 101,
				65, 99, 116, 105, 118, 97, 116, 105, 111, 110,
				66, 117, 116, 116, 111, 110, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 102, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 118, 111, 105, 99, 101,
				64, 100, 51, 102, 54, 102, 51, 55, 98, 56,
				101, 49, 99, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				85, 88, 92, 86, 111, 105, 99, 101, 84, 114,
				97, 110, 115, 99, 114, 105, 112, 116, 105, 111,
				110, 76, 97, 98, 101, 108, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 93, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 118, 111, 105, 99, 101,
				64, 100, 51, 102, 54, 102, 51, 55, 98, 56,
				101, 49, 99, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				86, 111, 105, 99, 101, 83, 68, 75, 67, 111,
				110, 115, 116, 97, 110, 116, 115, 46, 99, 115
			},
			TypesData = new byte[901]
			{
				0, 0, 0, 0, 46, 79, 99, 117, 108, 117,
				115, 46, 86, 111, 105, 99, 101, 46, 66, 105,
				110, 100, 105, 110, 103, 115, 46, 65, 110, 100,
				114, 111, 105, 100, 124, 73, 86, 67, 66, 105,
				110, 100, 105, 110, 103, 69, 118, 101, 110, 116,
				115, 0, 0, 0, 0, 45, 79, 99, 117, 108,
				117, 115, 46, 86, 111, 105, 99, 101, 46, 66,
				105, 110, 100, 105, 110, 103, 115, 46, 65, 110,
				100, 114, 111, 105, 100, 124, 86, 111, 105, 99,
				101, 83, 68, 75, 66, 105, 110, 100, 105, 110,
				103, 0, 0, 0, 0, 51, 79, 99, 117, 108,
				117, 115, 46, 86, 111, 105, 99, 101, 46, 66,
				105, 110, 100, 105, 110, 103, 115, 46, 65, 110,
				100, 114, 111, 105, 100, 124, 86, 111, 105, 99,
				101, 83, 68, 75, 67, 111, 110, 102, 105, 103,
				66, 105, 110, 100, 105, 110, 103, 0, 0, 0,
				0, 42, 79, 99, 117, 108, 117, 115, 46, 86,
				111, 105, 99, 101, 46, 66, 105, 110, 100, 105,
				110, 103, 115, 46, 65, 110, 100, 114, 111, 105,
				100, 124, 86, 111, 105, 99, 101, 83, 68, 75,
				73, 109, 112, 108, 0, 0, 0, 0, 49, 79,
				99, 117, 108, 117, 115, 46, 86, 111, 105, 99,
				101, 46, 66, 105, 110, 100, 105, 110, 103, 115,
				46, 65, 110, 100, 114, 111, 105, 100, 124, 86,
				111, 105, 99, 101, 83, 68, 75, 73, 109, 112,
				108, 82, 101, 113, 117, 101, 115, 116, 0, 0,
				0, 0, 53, 79, 99, 117, 108, 117, 115, 46,
				86, 111, 105, 99, 101, 46, 66, 105, 110, 100,
				105, 110, 103, 115, 46, 65, 110, 100, 114, 111,
				105, 100, 124, 86, 111, 105, 99, 101, 83, 68,
				75, 76, 105, 115, 116, 101, 110, 101, 114, 66,
				105, 110, 100, 105, 110, 103, 0, 0, 0, 0,
				45, 79, 99, 117, 108, 117, 115, 46, 86, 111,
				105, 99, 101, 46, 73, 110, 116, 101, 114, 102,
				97, 99, 101, 115, 124, 73, 80, 108, 97, 116,
				102, 111, 114, 109, 86, 111, 105, 99, 101, 83,
				101, 114, 118, 105, 99, 101, 0, 0, 0, 0,
				50, 77, 101, 116, 97, 46, 87, 105, 116, 65,
				105, 46, 73, 110, 116, 101, 114, 102, 97, 99,
				101, 115, 124, 73, 80, 108, 97, 116, 102, 111,
				114, 109, 73, 110, 116, 101, 103, 114, 97, 116,
				105, 111, 110, 79, 118, 101, 114, 114, 105, 100,
				101, 0, 0, 0, 0, 38, 79, 99, 117, 108,
				117, 115, 46, 86, 111, 105, 99, 101, 46, 76,
				111, 103, 103, 105, 110, 103, 124, 84, 84, 83,
				83, 101, 114, 118, 105, 99, 101, 76, 111, 103,
				103, 105, 110, 103, 0, 0, 0, 0, 59, 79,
				99, 117, 108, 117, 115, 46, 86, 111, 105, 99,
				101, 46, 76, 111, 103, 103, 105, 110, 103, 46,
				84, 84, 83, 83, 101, 114, 118, 105, 99, 101,
				76, 111, 103, 103, 105, 110, 103, 124, 84, 84,
				83, 83, 101, 114, 118, 105, 99, 101, 82, 101,
				113, 117, 101, 115, 116, 76, 111, 103, 0, 0,
				0, 0, 24, 79, 99, 117, 108, 117, 115, 46,
				86, 111, 105, 99, 101, 124, 65, 112, 112, 66,
				117, 105, 108, 116, 73, 110, 115, 0, 0, 0,
				0, 31, 79, 99, 117, 108, 117, 115, 46, 86,
				111, 105, 99, 101, 124, 65, 112, 112, 86, 111,
				105, 99, 101, 69, 120, 112, 101, 114, 105, 101,
				110, 99, 101, 0, 0, 0, 0, 34, 79, 99,
				117, 108, 117, 115, 46, 86, 111, 105, 99, 101,
				124, 79, 98, 106, 101, 99, 116, 86, 111, 105,
				99, 101, 69, 120, 112, 101, 114, 105, 101, 110,
				99, 101, 0, 0, 0, 0, 47, 79, 99, 117,
				108, 117, 115, 46, 86, 111, 105, 99, 101, 83,
				68, 75, 46, 85, 116, 105, 108, 105, 116, 105,
				101, 115, 124, 77, 105, 99, 80, 101, 114, 109,
				105, 115, 115, 105, 111, 110, 115, 77, 97, 110,
				97, 103, 101, 114, 0, 0, 0, 0, 45, 79,
				99, 117, 108, 117, 115, 46, 86, 111, 105, 99,
				101, 83, 68, 75, 46, 85, 116, 105, 108, 105,
				116, 105, 101, 115, 124, 86, 111, 105, 99, 101,
				69, 114, 114, 111, 114, 83, 105, 109, 117, 108,
				97, 116, 111, 114, 0, 0, 0, 0, 35, 79,
				99, 117, 108, 117, 115, 46, 86, 111, 105, 99,
				101, 46, 85, 88, 124, 72, 105, 101, 114, 97,
				114, 99, 104, 121, 83, 105, 109, 112, 108, 105,
				102, 105, 101, 114, 0, 0, 0, 0, 40, 79,
				99, 117, 108, 117, 115, 46, 86, 111, 105, 99,
				101, 83, 68, 75, 46, 85, 88, 124, 86, 111,
				105, 99, 101, 65, 99, 116, 105, 118, 97, 116,
				105, 111, 110, 66, 117, 116, 116, 111, 110, 0,
				0, 0, 0, 42, 79, 99, 117, 108, 117, 115,
				46, 86, 111, 105, 99, 101, 83, 68, 75, 46,
				85, 88, 124, 86, 111, 105, 99, 101, 84, 114,
				97, 110, 115, 99, 114, 105, 112, 116, 105, 111,
				110, 76, 97, 98, 101, 108, 0, 0, 0, 0,
				30, 79, 99, 117, 108, 117, 115, 46, 86, 111,
				105, 99, 101, 124, 86, 111, 105, 99, 101, 83,
				68, 75, 67, 111, 110, 115, 116, 97, 110, 116,
				115
			},
			TotalFiles = 18,
			TotalTypes = 19,
			IsEditorOnly = false
		};
	}
}
namespace Meta.WitAi.Interfaces
{
	public interface IPlatformIntegrationOverride : IVoiceService, IVoiceEventProvider, ITelemetryEventsProvider, IVoiceActivationHandler
	{
	}
}
namespace Oculus.VoiceSDK.UX
{
	[RequireComponent(typeof(Button))]
	public class VoiceActivationButton : MonoBehaviour
	{
		[Tooltip("Reference to the current voice service")]
		[SerializeField]
		private VoiceService _voiceService;

		[Tooltip("Text to be shown while the voice service is not actively recording")]
		[SerializeField]
		private string _activateText = "Activate";

		[Tooltip("Whether to immediately send data to service or to wait for the audio threshold")]
		[SerializeField]
		private bool _activateImmediately;

		[Tooltip("Text to be shown while the voice service is actively recording")]
		[SerializeField]
		private string _deactivateText = "Deactivate";

		[Tooltip("Whether to immediately abort request activation on deactivate")]
		[SerializeField]
		private bool _deactivateAndAbort;

		private Button _button;

		private Text _buttonLabel;

		private VoiceServiceRequest _request;

		private bool _isActive;

		private void Awake()
		{
			_buttonLabel = GetComponentInChildren<Text>();
			_button = GetComponent<Button>();
			if (_voiceService == null)
			{
				_voiceService = UnityEngine.Object.FindAnyObjectByType<VoiceService>();
			}
		}

		private void OnEnable()
		{
			RefreshActive();
			if (_voiceService != null)
			{
				_voiceService.VoiceEvents.OnStartListening.AddListener(OnStartListening);
				_voiceService.VoiceEvents.OnStoppedListening.AddListener(OnStopListening);
			}
			if (_button != null)
			{
				_button.onClick.AddListener(OnClick);
			}
		}

		private void OnDisable()
		{
			_isActive = false;
			if (_voiceService != null)
			{
				_voiceService.VoiceEvents.OnStartListening.RemoveListener(OnStartListening);
				_voiceService.VoiceEvents.OnStoppedListening.RemoveListener(OnStopListening);
			}
			if (_button != null)
			{
				_button.onClick.RemoveListener(OnClick);
			}
		}

		private void OnClick()
		{
			if (!_isActive)
			{
				Activate();
			}
			else
			{
				Deactivate();
			}
		}

		private void Activate()
		{
			if (!_activateImmediately)
			{
				_request = _voiceService.Activate(new WitRequestOptions(), new VoiceServiceRequestEvents());
			}
			else
			{
				_request = _voiceService.ActivateImmediately(new WitRequestOptions(), new VoiceServiceRequestEvents());
			}
		}

		private void Deactivate()
		{
			if (!_deactivateAndAbort)
			{
				if (_request != null)
				{
					_request.DeactivateAudio();
				}
				else
				{
					_voiceService.Deactivate();
				}
			}
			else if (_request != null)
			{
				_request.Cancel();
			}
		}

		private void OnStartListening()
		{
			_isActive = true;
			RefreshActive();
		}

		private void OnStopListening()
		{
			_isActive = false;
			_request = null;
			RefreshActive();
		}

		private void RefreshActive()
		{
			if (_buttonLabel != null)
			{
				_buttonLabel.text = (_isActive ? _deactivateText : _activateText);
			}
		}
	}
	[RequireComponent(typeof(Text))]
	[ExecuteInEditMode]
	public class VoiceTranscriptionLabel : MonoBehaviour
	{
		private Text _label;

		[Header("Listen Settings")]
		[Tooltip("Various voice services to be observed")]
		[SerializeField]
		private VoiceService[] _voiceServices;

		[Tooltip("Text color while receiving text")]
		[SerializeField]
		private Color _transcriptionColor = Color.black;

		[Header("Prompt Settings")]
		[Tooltip("Color to be used for prompt text")]
		[SerializeField]
		private Color _promptColor = new Color(0.2f, 0.2f, 0.2f);

		[Tooltip("Prompt text that displays while listening but prior to completion")]
		[SerializeField]
		private string _promptDefault = "Press activate to begin listening";

		[Tooltip("Prompt text that displays while listening but prior to completion")]
		[SerializeField]
		private string _promptListening = "Listening...";

		[Header("Error Settings")]
		[Tooltip("Color to be used for error text")]
		[SerializeField]
		private Color _errorColor = new Color(0.8f, 0.2f, 0.2f);

		public Text Label
		{
			get
			{
				if (_label == null)
				{
					_label = base.gameObject.GetComponent<Text>();
				}
				return _label;
			}
		}

		private void Awake()
		{
			if (_voiceServices == null || _voiceServices.Length == 0)
			{
				_voiceServices = UnityEngine.Object.FindObjectsByType<VoiceService>(FindObjectsSortMode.None);
			}
		}

		private void OnEnable()
		{
			if (_voiceServices != null)
			{
				VoiceService[] voiceServices = _voiceServices;
				foreach (VoiceService obj in voiceServices)
				{
					obj.VoiceEvents.OnStartListening.AddListener(OnStartListening);
					obj.VoiceEvents.OnPartialTranscription.AddListener(OnTranscriptionChange);
					obj.VoiceEvents.OnFullTranscription.AddListener(OnTranscriptionChange);
					obj.VoiceEvents.OnError.AddListener(OnError);
					obj.VoiceEvents.OnComplete.AddListener(OnComplete);
				}
			}
		}

		private void OnDisable()
		{
			if (_voiceServices != null)
			{
				VoiceService[] voiceServices = _voiceServices;
				foreach (VoiceService obj in voiceServices)
				{
					obj.VoiceEvents.OnStartListening.RemoveListener(OnStartListening);
					obj.VoiceEvents.OnPartialTranscription.RemoveListener(OnTranscriptionChange);
					obj.VoiceEvents.OnFullTranscription.RemoveListener(OnTranscriptionChange);
					obj.VoiceEvents.OnError.RemoveListener(OnError);
					obj.VoiceEvents.OnComplete.RemoveListener(OnComplete);
				}
			}
		}

		private void OnStartListening()
		{
			SetText(_promptListening, _promptColor);
		}

		private void OnTranscriptionChange(string text)
		{
			SetText(text, _transcriptionColor);
		}

		private void OnError(string status, string error)
		{
			SetText("[" + status + "] " + error, _errorColor);
		}

		private void OnComplete(VoiceServiceRequest request)
		{
			if (Label != null && string.Equals(Label?.text, _promptListening))
			{
				SetText(_promptDefault, _promptColor);
			}
		}

		private void SetText(string newText, Color newColor)
		{
			if (!(Label == null) && (!string.Equals(newText, Label.text) || !(newColor == Label.color)))
			{
				_label.text = newText;
				_label.color = newColor;
			}
		}
	}
}
namespace Oculus.VoiceSDK.Utilities
{
	public static class MicPermissionsManager
	{
		public static bool HasMicPermission()
		{
			return true;
		}

		public static void RequestMicPermission(Action<string> permissionGrantedCallback = null)
		{
			permissionGrantedCallback?.Invoke("android.permission.RECORD_AUDIO");
		}
	}
	public enum VoiceErrorRequestType
	{
		AudioInputAnalysisRequest,
		TextInputAnalysisRequest,
		TextToSpeechRequest
	}
	public class VoiceErrorSimulator : MonoBehaviour
	{
		public VoiceService[] voiceServices;

		public TTSService ttsService;

		private ConcurrentDictionary<VoiceErrorRequestType, VoiceErrorSimulationType> _requests = new ConcurrentDictionary<VoiceErrorRequestType, VoiceErrorSimulationType>();

		protected virtual void OnEnable()
		{
			RefreshServices();
			SetListeners(add: true);
		}

		protected virtual void RefreshServices()
		{
			if (voiceServices == null)
			{
				VoiceService[] componentsInChildren = base.gameObject.GetComponentsInChildren<AppVoiceExperience>(includeInactive: true);
				voiceServices = componentsInChildren;
			}
			if (ttsService == null)
			{
				ttsService = base.gameObject.GetComponentInChildren<TTSService>(includeInactive: true);
			}
		}

		private void SetListeners(bool add)
		{
			if (voiceServices != null)
			{
				VoiceService[] array = voiceServices;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].VoiceEvents.OnRequestInitialized.SetListener(SimulateVoiceRequestError, add);
				}
			}
		}

		protected virtual void OnDisable()
		{
			SetListeners(add: false);
		}

		public void SimulateError(VoiceErrorRequestType requestType, VoiceErrorSimulationType simulationType)
		{
			if (requestType == VoiceErrorRequestType.TextToSpeechRequest)
			{
				ttsService.SimulatedErrorType = simulationType;
			}
			else
			{
				_requests[requestType] = simulationType;
			}
		}

		private void SimulateVoiceRequestError(VoiceServiceRequest request)
		{
			if (request.IsLocalRequest)
			{
				VoiceErrorRequestType voiceErrorRequestType = (VoiceErrorRequestType)(-1);
				VoiceErrorSimulationType value = (VoiceErrorSimulationType)(-1);
				if (request.InputType == NLPRequestInputType.Audio && _requests.ContainsKey(VoiceErrorRequestType.AudioInputAnalysisRequest))
				{
					voiceErrorRequestType = VoiceErrorRequestType.AudioInputAnalysisRequest;
					_requests.TryRemove(voiceErrorRequestType, out value);
				}
				else if (request.InputType == NLPRequestInputType.Text && _requests.ContainsKey(VoiceErrorRequestType.TextInputAnalysisRequest))
				{
					voiceErrorRequestType = VoiceErrorRequestType.TextInputAnalysisRequest;
					_requests.TryRemove(voiceErrorRequestType, out value);
				}
				if (voiceErrorRequestType != (VoiceErrorRequestType)(-1) && value != (VoiceErrorSimulationType)(-1))
				{
					request.SimulateError(value);
				}
			}
		}
	}
}
namespace Oculus.Voice
{
	public static class AppBuiltIns
	{
		public static string builtInPrefix = "builtin:";

		private static string modelName = "Built-in Models";

		public static readonly Dictionary<string, Dictionary<string, string>> apps = new Dictionary<string, Dictionary<string, string>>
		{
			{
				"Chinese",
				new Dictionary<string, string>
				{
					{ "id", "voiceSDK_zh" },
					{ "name", modelName },
					{ "lang", "zh" },
					{ "clientToken", "3KQH33637TAT7WD4TG7T65SDRO73WZGY" }
				}
			},
			{
				"Dutch",
				new Dictionary<string, string>
				{
					{ "id", "voiceSDK_nl" },
					{ "name", modelName },
					{ "lang", "nl" },
					{ "clientToken", "ZCD6HCNCL6GTJKZ3QKWNKQVEDI4GUL7C" }
				}
			},
			{
				"English",
				new Dictionary<string, string>
				{
					{ "id", "voiceSDK_en" },
					{ "name", modelName },
					{ "lang", "en" },
					{ "clientToken", "HOKEABS7HPIQVSRSVWRPTTV75TQJ5QBP" }
				}
			},
			{
				"French",
				new Dictionary<string, string>
				{
					{ "id", "voiceSDK_fr" },
					{ "name", modelName },
					{ "lang", "fr" },
					{ "clientToken", "7PP7NK2QAH67MREGZV6SB6RIEWAYDNRY" }
				}
			},
			{
				"German",
				new Dictionary<string, string>
				{
					{ "id", "voiceSDK_de" },
					{ "name", modelName },
					{ "lang", "de" },
					{ "clientToken", "7LXOOB4JC7MXPUTTGQHDVQMHGEEJT6LE" }
				}
			},
			{
				"Italian",
				new Dictionary<string, string>
				{
					{ "id", "voiceSDK_it" },
					{ "name", modelName },
					{ "lang", "it" },
					{ "clientToken", "KELCNR4DCCPPOCF2RDFS4M6JOCWWIFII" }
				}
			},
			{
				"Japanese",
				new Dictionary<string, string>
				{
					{ "id", "voiceSDK_ja" },
					{ "name", modelName },
					{ "lang", "ja" },
					{ "clientToken", "TPJGLBBCHJ5F7BVVN5XLEGP6YDQRUE3P" }
				}
			},
			{
				"Korean",
				new Dictionary<string, string>
				{
					{ "id", "voiceSDK_ko" },
					{ "name", modelName },
					{ "lang", "ko" },
					{ "clientToken", "NT4WJLL7ACMFBXS4B7W5GRLTKDZQ36R4" }
				}
			},
			{
				"Polish",
				new Dictionary<string, string>
				{
					{ "id", "voiceSDK_pl" },
					{ "name", modelName },
					{ "lang", "pl" },
					{ "clientToken", "DMDRHGYDYN33D3IKCX5BG5R57EL2IIC4" }
				}
			},
			{
				"Portuguese",
				new Dictionary<string, string>
				{
					{ "id", "voiceSDK_pt" },
					{ "name", modelName },
					{ "lang", "pt" },
					{ "clientToken", "W4W3BSKL72HZC5MXLILONJUCG732SQQN" }
				}
			},
			{
				"Russian",
				new Dictionary<string, string>
				{
					{ "id", "voiceSDK_ru" },
					{ "name", modelName },
					{ "lang", "ru" },
					{ "clientToken", "W67HLUWA3MBYVEKRW3VVWUKSNZGAOFBI" }
				}
			},
			{
				"Spanish",
				new Dictionary<string, string>
				{
					{ "id", "voiceSDK_es" },
					{ "name", modelName },
					{ "lang", "es" },
					{ "clientToken", "YW7AM5OOVSW5XKGYKFE2S2HLC2WHC3UI" }
				}
			},
			{
				"Swedish",
				new Dictionary<string, string>
				{
					{ "id", "voiceSDK_sv" },
					{ "name", modelName },
					{ "lang", "sv" },
					{ "clientToken", "NPE3UJ7Y4NIVTUOZ7QPPAP3TY6FYPXJY" }
				}
			},
			{
				"Turkish",
				new Dictionary<string, string>
				{
					{ "id", "voiceSDK_tr" },
					{ "name", modelName },
					{ "lang", "tr" },
					{ "clientToken", "ZCISEDXESLYJOROLNOODCGGPZXHLUAEE" }
				}
			}
		};

		public static string[] appNames
		{
			get
			{
				string[] array = new string[apps.Keys.Count];
				apps.Keys.CopyTo(array, 0);
				return array;
			}
		}
	}
	[HelpURL("https://developer.oculus.com/experimental/voice-sdk/tutorial-overview/")]
	public class AppVoiceExperience : VoiceService, IWitRuntimeConfigProvider, IWitConfigurationProvider
	{
		[SerializeField]
		private WitRuntimeConfiguration witRuntimeConfiguration;

		[Tooltip("Uses platform services to access wit.ai instead of accessing wit directly from within the application.")]
		[SerializeField]
		private bool usePlatformServices;

		[Tooltip("Enables logs related to the interaction to be displayed on console")]
		[SerializeField]
		private bool enableConsoleLogging;

		[Tooltip("If true, the OnFullTranscriptionEvent events will be triggered when calling Activate(string)")]
		[SerializeField]
		private bool sendTranscriptionEventsForMessages;

		private IVoiceService voiceServiceImpl;

		private IVoiceSDKLogger voiceSDKLoggerImpl;

		public WitRuntimeConfiguration RuntimeConfiguration
		{
			get
			{
				return witRuntimeConfiguration;
			}
			set
			{
				witRuntimeConfiguration = value;
				if (voiceServiceImpl is IWitRuntimeConfigSetter witRuntimeConfigSetter)
				{
					witRuntimeConfigSetter.RuntimeConfiguration = witRuntimeConfiguration;
				}
			}
		}

		public WitConfiguration Configuration => witRuntimeConfiguration?.witConfiguration;

		private static string PACKAGE_VERSION => VoiceSDKConstants.SdkVersion;

		private bool Initialized => voiceServiceImpl != null;

		public override bool Active
		{
			get
			{
				if (!base.Active)
				{
					if (voiceServiceImpl != null)
					{
						return voiceServiceImpl.Active;
					}
					return false;
				}
				return true;
			}
		}

		public override bool IsRequestActive
		{
			get
			{
				if (!base.IsRequestActive)
				{
					if (voiceServiceImpl != null)
					{
						return voiceServiceImpl.IsRequestActive;
					}
					return false;
				}
				return true;
			}
		}

		public override ITranscriptionProvider TranscriptionProvider
		{
			get
			{
				return voiceServiceImpl?.TranscriptionProvider;
			}
			set
			{
				if (voiceServiceImpl != null)
				{
					voiceServiceImpl.TranscriptionProvider = value;
				}
			}
		}

		public override bool MicActive
		{
			get
			{
				if (voiceServiceImpl != null)
				{
					return voiceServiceImpl.MicActive;
				}
				return false;
			}
		}

		protected override bool ShouldSendMicData
		{
			get
			{
				if (!witRuntimeConfiguration.sendAudioToWit)
				{
					return TranscriptionProvider == null;
				}
				return true;
			}
		}

		public bool HasPlatformIntegrations => false;

		public bool EnableConsoleLogging => enableConsoleLogging;

		public override bool UsePlatformIntegrations
		{
			get
			{
				return usePlatformServices;
			}
			set
			{
				if (usePlatformServices != value || HasPlatformIntegrations != value)
				{
					usePlatformServices = value;
				}
			}
		}

		public event Action OnInitialized;

		public override bool CanSend()
		{
			if (base.CanSend() && voiceServiceImpl != null)
			{
				return voiceServiceImpl.CanSend();
			}
			return false;
		}

		public override async Task<VoiceServiceRequest> Activate(string text, WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents)
		{
			if (CanSend())
			{
				SetupRequestParameters(ref requestOptions, ref requestEvents);
				VoiceServiceRequest request = await voiceServiceImpl.Activate(text, requestOptions, requestEvents);
				if (sendTranscriptionEventsForMessages && !string.IsNullOrEmpty(text))
				{
					request.Events.OnFullResponse.AddListener(delegate(WitResponseNode r)
					{
						if (string.IsNullOrEmpty(r.GetTranscription()))
						{
							r["text"] = text;
						}
					});
					request.Events.OnSend.AddListener(delegate
					{
						request.Events?.OnFullTranscription?.Invoke(text);
						VoiceEvents.OnFullTranscription?.Invoke(text);
					});
				}
				return request;
			}
			return null;
		}

		public override bool CanActivateAudio()
		{
			if (base.CanActivateAudio() && voiceServiceImpl != null)
			{
				return voiceServiceImpl.CanActivateAudio();
			}
			return false;
		}

		public override string GetActivateAudioError()
		{
			if (!HasPlatformIntegrations && !AudioBuffer.Instance.IsInputAvailable)
			{
				return "No Microphone(s)/recording devices found.  You will be unable to capture audio on this device.";
			}
			return base.GetActivateAudioError();
		}

		public override VoiceServiceRequest Activate(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents)
		{
			SetupRequestParameters(ref requestOptions, ref requestEvents);
			if (CanActivateAudio() && CanSend())
			{
				return voiceServiceImpl.Activate(requestOptions, requestEvents);
			}
			if (voiceServiceImpl == null)
			{
				VLog.D("Voice is not initialized. Attempting to initialize before activating.");
				InitVoiceSDK();
				if (CanActivateAudio() && CanSend())
				{
					return voiceServiceImpl?.Activate(requestOptions, requestEvents);
				}
			}
			VLog.W("Cannot currently activate\nAudio Activation Error: " + GetActivateAudioError() + "\nSend Error: " + GetSendError());
			return null;
		}

		public override VoiceServiceRequest ActivateImmediately(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents)
		{
			SetupRequestParameters(ref requestOptions, ref requestEvents);
			if (CanActivateAudio() && CanSend())
			{
				return voiceServiceImpl.ActivateImmediately(requestOptions, requestEvents);
			}
			if (voiceServiceImpl == null)
			{
				VLog.D("Voice is not initialized. Attempting to initialize before immediate activation");
				InitVoiceSDK();
				if (CanActivateAudio() && CanSend())
				{
					return voiceServiceImpl?.ActivateImmediately(requestOptions, requestEvents);
				}
			}
			VLog.W("Cannot currently activate\nAudio Activation Error: " + GetActivateAudioError() + "\nSend Error: " + GetSendError());
			return null;
		}

		public override void Deactivate()
		{
			voiceServiceImpl?.Deactivate();
		}

		public override void DeactivateAndAbortRequest()
		{
			voiceServiceImpl?.DeactivateAndAbortRequest();
		}

		private void InitVoiceSDK()
		{
			if (string.IsNullOrEmpty(PACKAGE_VERSION))
			{
				VLog.E("No SDK Version Set");
			}
			if (!UsePlatformIntegrations)
			{
				if (voiceServiceImpl is VoiceSDKImpl)
				{
					((VoiceSDKImpl)voiceServiceImpl).Disconnect();
				}
				if (voiceSDKLoggerImpl is VoiceSDKPlatformLoggerImpl)
				{
					try
					{
						((VoiceSDKPlatformLoggerImpl)voiceSDKLoggerImpl).Disconnect();
					}
					catch (Exception ex)
					{
						VLog.E("Disconnection error: " + ex.Message);
					}
				}
			}
			bool flag = voiceServiceImpl != null;
			if (!flag)
			{
				voiceServiceImpl = base.gameObject.GetComponent<IPlatformIntegrationOverride>();
				flag = voiceServiceImpl != null;
				if (flag)
				{
					VLog.I($"Using PI override\nClass: {voiceServiceImpl.GetType()}");
					UsePlatformIntegrations = false;
				}
			}
			voiceSDKLoggerImpl = new VoiceSDKConsoleLoggerImpl();
			if (!flag)
			{
				RevertToWitUnity();
			}
			if (voiceServiceImpl is IWitRuntimeConfigSetter witRuntimeConfigSetter)
			{
				witRuntimeConfigSetter.RuntimeConfiguration = witRuntimeConfiguration;
			}
			voiceServiceImpl.VoiceEvents = VoiceEvents;
			voiceServiceImpl.TelemetryEvents = TelemetryEvents;
			voiceSDKLoggerImpl.IsUsingPlatformIntegration = UsePlatformIntegrations;
			voiceSDKLoggerImpl.WitApplication = RuntimeConfiguration?.witConfiguration?.GetLoggerAppId();
			voiceSDKLoggerImpl.ShouldLogToConsole = EnableConsoleLogging;
			this.OnInitialized?.Invoke();
		}

		private void RevertToWitUnity()
		{
			VLog.I("Initializing Wit Unity...");
			Wit wit = GetComponent<Wit>();
			if (null == wit)
			{
				wit = base.gameObject.AddComponent<Wit>();
				wit.hideFlags = HideFlags.HideInInspector;
			}
			wit.ShouldWrap = false;
			voiceServiceImpl = wit;
			UsePlatformIntegrations = false;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (MicPermissionsManager.HasMicPermission())
			{
				InitVoiceSDK();
			}
			else
			{
				MicPermissionsManager.RequestMicPermission();
			}
			VoiceEvents.OnMinimumWakeThresholdHit?.AddListener(OnMinimumWakeThresholdHit);
			VoiceEvents.OnMicDataSent?.AddListener(OnMicDataSent);
			VoiceEvents.OnStoppedListeningDueToTimeout?.AddListener(OnStoppedListeningDueToTimeout);
			VoiceEvents.OnStoppedListeningDueToInactivity?.AddListener(OnStoppedListeningDueToInactivity);
			VoiceEvents.OnStoppedListeningDueToDeactivation?.AddListener(OnStoppedListeningDueToDeactivation);
			TelemetryEvents.OnAudioTrackerFinished?.AddListener(OnAudioDurationTrackerFinished);
			StartCoroutine(RetryInit());
		}

		private IEnumerator RetryInit()
		{
			int waitSeconds = 1;
			while (voiceServiceImpl == null)
			{
				VLog.W($"Voice Service still not initialized yet. Retrying in {waitSeconds} seconds.");
				yield return new WaitForSeconds(waitSeconds);
				if (voiceServiceImpl == null)
				{
					InitVoiceSDK();
					waitSeconds++;
					if (waitSeconds == 10)
					{
						waitSeconds = 1;
					}
					continue;
				}
				break;
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			voiceServiceImpl = null;
			voiceSDKLoggerImpl = null;
			VoiceEvents.OnMinimumWakeThresholdHit?.RemoveListener(OnMinimumWakeThresholdHit);
			VoiceEvents.OnMicDataSent?.RemoveListener(OnMicDataSent);
			VoiceEvents.OnStoppedListeningDueToTimeout?.RemoveListener(OnStoppedListeningDueToTimeout);
			VoiceEvents.OnStoppedListeningDueToInactivity?.RemoveListener(OnStoppedListeningDueToInactivity);
			VoiceEvents.OnStoppedListeningDueToDeactivation?.RemoveListener(OnStoppedListeningDueToDeactivation);
			TelemetryEvents.OnAudioTrackerFinished?.RemoveListener(OnAudioDurationTrackerFinished);
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			if (base.enabled && hasFocus && !Initialized && MicPermissionsManager.HasMicPermission())
			{
				InitVoiceSDK();
			}
		}

		protected override void OnRequestInit(VoiceServiceRequest request)
		{
			base.OnRequestInit(request);
			_waitingForFirstPartialAudio = true;
			voiceSDKLoggerImpl.LogInteractionStart(request.Options?.RequestId, (request.InputType == NLPRequestInputType.Text) ? "message" : "speech");
			voiceSDKLoggerImpl.LogAnnotation("minWakeThreshold", RuntimeConfiguration?.soundWakeThreshold.ToString(CultureInfo.InvariantCulture));
			voiceSDKLoggerImpl.LogAnnotation("minKeepAliveTimeSec", RuntimeConfiguration?.minKeepAliveTimeInSeconds.ToString(CultureInfo.InvariantCulture));
			voiceSDKLoggerImpl.LogAnnotation("minTranscriptionKeepAliveTimeSec", RuntimeConfiguration?.minTranscriptionKeepAliveTimeInSeconds.ToString(CultureInfo.InvariantCulture));
			voiceSDKLoggerImpl.LogAnnotation("maxRecordingTime", RuntimeConfiguration?.maxRecordingTime.ToString(CultureInfo.InvariantCulture));
		}

		protected override void OnRequestStartListening(VoiceServiceRequest request)
		{
			base.OnRequestStartListening(request);
			voiceSDKLoggerImpl.LogInteractionPoint("startedListening");
		}

		protected override void OnRequestStopListening(VoiceServiceRequest request)
		{
			base.OnRequestStopListening(request);
			voiceSDKLoggerImpl.LogInteractionPoint("stoppedListening");
		}

		protected override void OnRequestSend(VoiceServiceRequest request)
		{
			base.OnRequestSend(request);
			voiceSDKLoggerImpl.LogInteractionPoint("witRequestCreated");
			if (request != null)
			{
				voiceSDKLoggerImpl.LogAnnotation("requestIdOverride", request.Options?.RequestId);
			}
		}

		protected override void OnRequestPartialTranscription(VoiceServiceRequest request, string transcription)
		{
			base.OnRequestPartialTranscription(request, transcription);
			voiceSDKLoggerImpl.LogFirstTranscriptionTime();
		}

		protected override void OnRequestFullTranscription(VoiceServiceRequest request, string transcription)
		{
			base.OnRequestFullTranscription(request, transcription);
			voiceSDKLoggerImpl.LogInteractionPoint("fullTranscriptionTime");
		}

		private void OnMinimumWakeThresholdHit()
		{
			voiceSDKLoggerImpl.LogInteractionPoint("minWakeThresholdHit");
		}

		private void OnStoppedListeningDueToTimeout()
		{
			voiceSDKLoggerImpl.LogInteractionPoint("stoppedListeningTimeout");
		}

		private void OnStoppedListeningDueToInactivity()
		{
			voiceSDKLoggerImpl.LogInteractionPoint("stoppedListeningInactivity");
		}

		private void OnStoppedListeningDueToDeactivation()
		{
			voiceSDKLoggerImpl.LogInteractionPoint("stoppedListeningDeactivate");
		}

		private void OnMicDataSent()
		{
			voiceSDKLoggerImpl.LogInteractionPoint("micDataSent");
		}

		private void OnAudioDurationTrackerFinished(long timestamp, double audioDuration)
		{
			voiceSDKLoggerImpl.LogAnnotation("adt_duration", audioDuration.ToString(CultureInfo.InvariantCulture));
			voiceSDKLoggerImpl.LogAnnotation("adt_finished", timestamp.ToString());
		}

		protected override void OnRequestSuccess(VoiceServiceRequest request)
		{
			base.OnRequestSuccess(request);
			WitResponseNode witResponseNode = (request?.ResponseData)?["speech"]?["tokens"];
			if (witResponseNode != null)
			{
				int count = witResponseNode.Count;
				string annotationValue = witResponseNode[count - 1]?["end"]?.Value;
				voiceSDKLoggerImpl.LogAnnotation("audioLength", annotationValue);
			}
		}

		protected override void OnRequestComplete(VoiceServiceRequest request)
		{
			base.OnRequestComplete(request);
			if (voiceSDKLoggerImpl == null)
			{
				VLog.W("voiceSDKLoggerImpl is null");
			}
			else if (request.State == VoiceRequestState.Failed)
			{
				voiceSDKLoggerImpl.LogInteractionEndFailure(request.Results.Message);
			}
			else if (request.State == VoiceRequestState.Canceled)
			{
				voiceSDKLoggerImpl.LogInteractionEndFailure("aborted");
			}
			else
			{
				voiceSDKLoggerImpl.LogInteractionEndSuccess();
			}
		}
	}
	public class ObjectVoiceExperience : MonoBehaviour
	{
		[FormerlySerializedAs("voiceEvents")]
		[SerializeField]
		private VoiceEvents _voiceEvents = new VoiceEvents();

		private AppVoiceExperience _voice;

		private VoiceServiceRequest _activation;

		private VoiceServiceRequestEvents _events = new VoiceServiceRequestEvents();

		private void OnEnable()
		{
			if (!_voice)
			{
				_voice = UnityEngine.Object.FindAnyObjectByType<AppVoiceExperience>();
			}
			_events.OnCancel.AddListener(HandleCancel);
			_events.OnComplete.AddListener(HandleComplete);
			_events.OnFailed.AddListener(HandleFailed);
			_events.OnInit.AddListener(HandleInit);
			_events.OnSend.AddListener(HandleSend);
			_events.OnSuccess.AddListener(HandleSuccess);
			_events.OnAudioActivation.AddListener(HandleAudioActivation);
			_events.OnAudioDeactivation.AddListener(HandleAudioDeactivation);
			_events.OnPartialTranscription.AddListener(HandlePartialTranscription);
			_events.OnFullTranscription.AddListener(HandleFullTranscription);
			_events.OnStateChange.AddListener(HandleStateChange);
			_events.OnStartListening.AddListener(HandleStartListening);
			_events.OnStopListening.AddListener(HandleStopListening);
			_events.OnDownloadProgressChange.AddListener(HandleDownloadProgressChange);
			_events.OnUploadProgressChange.AddListener(HandleUploadProgressChange);
			_events.OnAudioInputStateChange.AddListener(HandleAudioInputStateChange);
		}

		private void OnDisable()
		{
			_events.OnCancel.RemoveListener(HandleCancel);
			_events.OnComplete.RemoveListener(HandleComplete);
			_events.OnFailed.RemoveListener(HandleFailed);
			_events.OnInit.RemoveListener(HandleInit);
			_events.OnSend.RemoveListener(HandleSend);
			_events.OnSuccess.RemoveListener(HandleSuccess);
			_events.OnAudioActivation.RemoveListener(HandleAudioActivation);
			_events.OnAudioDeactivation.RemoveListener(HandleAudioDeactivation);
			_events.OnFullTranscription.RemoveListener(HandleFullTranscription);
			_events.OnPartialTranscription.RemoveListener(HandlePartialTranscription);
			_events.OnStateChange.RemoveListener(HandleStateChange);
			_events.OnStartListening.RemoveListener(HandleStartListening);
			_events.OnStopListening.RemoveListener(HandleStopListening);
			_events.OnDownloadProgressChange.RemoveListener(HandleDownloadProgressChange);
			_events.OnUploadProgressChange.RemoveListener(HandleUploadProgressChange);
			_events.OnAudioInputStateChange.RemoveListener(HandleAudioInputStateChange);
		}

		private void HandleAudioInputStateChange(VoiceServiceRequest request)
		{
			SendMessage("OnAudioInputStateChange", request, SendMessageOptions.DontRequireReceiver);
		}

		private void HandleUploadProgressChange(VoiceServiceRequest request)
		{
			SendMessage("OnUploadProgressChange", request, SendMessageOptions.DontRequireReceiver);
		}

		private void HandleDownloadProgressChange(VoiceServiceRequest request)
		{
			SendMessage("OnDownloadProgressChange", request, SendMessageOptions.DontRequireReceiver);
		}

		private void HandleStopListening(VoiceServiceRequest request)
		{
			SendMessage("OnStopListening", request, SendMessageOptions.DontRequireReceiver);
		}

		private void HandleStartListening(VoiceServiceRequest request)
		{
			SendMessage("OnStartListening", request, SendMessageOptions.DontRequireReceiver);
		}

		private void HandleStateChange(VoiceServiceRequest request)
		{
			SendMessage("OnStateChange", request, SendMessageOptions.DontRequireReceiver);
		}

		private void HandleFullTranscription(string transcription)
		{
			SendMessage("OnFullTranscription", transcription, SendMessageOptions.DontRequireReceiver);
		}

		private void HandlePartialTranscription(string transcription)
		{
			SendMessage("OnPartialTranscription", transcription, SendMessageOptions.DontRequireReceiver);
		}

		private void HandleAudioDeactivation(VoiceServiceRequest request)
		{
			SendMessage("OnAudioDeactivation", request, SendMessageOptions.DontRequireReceiver);
		}

		private void HandleAudioActivation(VoiceServiceRequest request)
		{
			SendMessage("OnAudioActivation", request, SendMessageOptions.DontRequireReceiver);
		}

		private void HandleSuccess(VoiceServiceRequest request)
		{
			SendMessage("OnSuccess", request, SendMessageOptions.DontRequireReceiver);
		}

		private void HandleSend(VoiceServiceRequest request)
		{
			SendMessage("OnSend", request, SendMessageOptions.DontRequireReceiver);
		}

		private void HandleInit(VoiceServiceRequest request)
		{
			SendMessage("OnInit", request, SendMessageOptions.DontRequireReceiver);
		}

		private void HandleFailed(VoiceServiceRequest request)
		{
			SendMessage("OnFailed", request, SendMessageOptions.DontRequireReceiver);
		}

		private void HandleComplete(VoiceServiceRequest request)
		{
			_voiceEvents?.OnComplete?.Invoke(request);
			SendMessage("OnComplete", request, SendMessageOptions.DontRequireReceiver);
		}

		private void HandleCancel(VoiceServiceRequest request)
		{
			_voiceEvents?.OnCanceled?.Invoke("");
			SendMessage("OnCancel", request, SendMessageOptions.DontRequireReceiver);
		}

		public void Activate()
		{
			_activation = _voice.Activate(new WitRequestOptions(), _events);
		}

		public void Deactivate()
		{
			_activation.Cancel();
		}
	}
	public static class VoiceSDKConstants
	{
		private static bool _isInitialized;

		private static string _sdkVersion;

		private const string _userAgentPrefix = "voice-sdk-";

		public static string SdkVersion
		{
			get
			{
				if (string.IsNullOrEmpty(_sdkVersion))
				{
					_sdkVersion = "78.0.0";
				}
				return _sdkVersion;
			}
		}

		static VoiceSDKConstants()
		{
			_isInitialized = false;
			_sdkVersion = "78.0.0.8.295";
			Init();
		}

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
			if (!_isInitialized)
			{
				_isInitialized = true;
				WitRequestSettings.OnProvideCustomUserAgent = (Action<StringBuilder>)Delegate.Combine(WitRequestSettings.OnProvideCustomUserAgent, new Action<StringBuilder>(OnCustomUserAgent));
			}
		}

		private static void OnCustomUserAgent(StringBuilder sb)
		{
			if (!sb.ToString().StartsWith("voice-sdk-"))
			{
				sb.Insert(0, "voice-sdk-" + SdkVersion + ",");
			}
		}
	}
}
namespace Oculus.Voice.UX
{
	public class HierarchySimplifier : MonoBehaviour
	{
		[Tooltip("Whether to hide the object on startup, by default.")]
		[SerializeField]
		public bool hideByDefault = true;

		public static void HideSubObjects(GameObject obj, bool hideObjects)
		{
			HierarchySimplifier[] componentsInChildren = obj.GetComponentsInChildren<HierarchySimplifier>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				ToggleShowInHierarchyFlag(componentsInChildren[i].gameObject, hideObjects);
			}
		}

		private void OnValidate()
		{
			ToggleShowInHierarchyFlag(base.gameObject, hideByDefault);
		}

		public static void ToggleShowInHierarchyFlag(GameObject obj, bool hideObject)
		{
			obj.hideFlags = (hideObject ? (obj.hideFlags | HideFlags.HideInHierarchy) : (obj.hideFlags & ~HideFlags.HideInHierarchy));
		}
	}
}
namespace Oculus.Voice.Logging
{
	internal class TTSServiceLogging : MonoBehaviour
	{
		private struct TTSServiceRequestLog
		{
			public DateTime startTime;

			public Dictionary<string, string> annotations;
		}

		public bool EnableConsoleLogging;

		private IVoiceSDKLogger _voiceSDKLoggerImpl;

		private Dictionary<string, TTSServiceRequestLog> _requests = new Dictionary<string, TTSServiceRequestLog>();

		private const string TTS_FILETYPE_ANNOTATION = "ttsFileType";

		private const string TTS_FILESTREAM_ANNOTATION = "ttsFileStream";

		private const string TTS_START_TIME_ANNOTATION = "ttsStartTime";

		private const string TTS_FIRST_TIME_ANNOTATION = "ttsFirstResponseTime";

		private const string TTS_READY_TIME_ANNOTATION = "ttsReadyTime";

		private const string TTS_FINISH_TIME_ANNOTATION = "ttsFinishedTime";

		private const string TTS_ERROR_ANNOTATION = "ttsError";

		private static bool _initialized;

		public TTSService Service { get; private set; }

		private void Awake()
		{
			Service = base.gameObject.GetComponent<TTSService>();
			InitLogger();
		}

		private void InitLogger()
		{
			_voiceSDKLoggerImpl = new VoiceSDKConsoleLoggerImpl();
			WitConfiguration witConfiguration = Service.GetComponent<IWitConfigurationProvider>()?.Configuration;
			if (witConfiguration != null)
			{
				_voiceSDKLoggerImpl.WitApplication = witConfiguration.GetLoggerAppId();
			}
		}

		private void OnEnable()
		{
			if (_voiceSDKLoggerImpl != null)
			{
				_voiceSDKLoggerImpl.ShouldLogToConsole = EnableConsoleLogging;
			}
			if ((bool)Service)
			{
				Service.Events.WebRequest.OnRequestBegin.AddListener(OnRequestBegin);
				Service.Events.WebRequest.OnRequestCancel.AddListener(OnRequestCancel);
				Service.Events.WebRequest.OnRequestError.AddListener(OnRequestError);
				Service.Events.WebRequest.OnRequestFirstResponse.AddListener(OnRequestFirstResponse);
				Service.Events.WebRequest.OnRequestReady.AddListener(OnRequestReady);
				Service.Events.WebRequest.OnRequestComplete.AddListener(OnRequestComplete);
			}
		}

		private void OnDisable()
		{
			if ((bool)Service)
			{
				Service.Events.WebRequest.OnRequestBegin.RemoveListener(OnRequestBegin);
				Service.Events.WebRequest.OnRequestCancel.RemoveListener(OnRequestCancel);
				Service.Events.WebRequest.OnRequestError.RemoveListener(OnRequestError);
				Service.Events.WebRequest.OnRequestFirstResponse.RemoveListener(OnRequestFirstResponse);
				Service.Events.WebRequest.OnRequestReady.RemoveListener(OnRequestReady);
				Service.Events.WebRequest.OnRequestComplete.RemoveListener(OnRequestComplete);
			}
		}

		private void OnRequestBegin(TTSClipData clipData)
		{
			LogStart(clipData);
		}

		private void OnRequestCancel(TTSClipData clipData)
		{
			LogComplete(clipData, "aborted");
		}

		private void OnRequestError(TTSClipData clipData, string error)
		{
			LogComplete(clipData, error);
		}

		private void OnRequestFirstResponse(TTSClipData clipData)
		{
			LogTimestamp(clipData, "ttsFirstResponseTime");
		}

		private void OnRequestReady(TTSClipData clipData)
		{
			LogTimestamp(clipData, "ttsReadyTime");
		}

		private void OnRequestComplete(TTSClipData clipData)
		{
			LogComplete(clipData);
		}

		private void LogStart(TTSClipData clipData)
		{
			TTSServiceRequestLog requestData = GetRequestData(clipData);
			requestData.startTime = DateTime.UtcNow;
			requestData.annotations = new Dictionary<string, string>();
			LogTimestamp(requestData, "ttsStartTime");
			LogAnnotate(requestData, "ttsFileType", clipData.extension);
			LogAnnotate(requestData, "ttsFileStream", clipData.queryStream.ToString(CultureInfo.InvariantCulture));
			_requests[clipData.queryRequestId] = requestData;
		}

		private TTSServiceRequestLog GetRequestData(TTSClipData clipData)
		{
			if (_requests.ContainsKey(clipData.queryRequestId))
			{
				return _requests[clipData.queryRequestId];
			}
			return default(TTSServiceRequestLog);
		}

		private void LogTimestamp(TTSClipData clipData, string key)
		{
			LogTimestamp(GetRequestData(clipData), key);
		}

		private void LogTimestamp(TTSServiceRequestLog requestData, string key)
		{
			LogAnnotate(requestData, key, DateTimeUtility.ElapsedMilliseconds.ToString());
		}

		private void LogAnnotate(TTSServiceRequestLog requestData, string key, string value)
		{
			if (requestData.annotations != null)
			{
				requestData.annotations[key] = value;
			}
		}

		private void LogComplete(TTSClipData clipData, string error = null)
		{
			TTSServiceRequestLog requestData = GetRequestData(clipData);
			if (requestData.annotations == null)
			{
				return;
			}
			if (!string.IsNullOrEmpty(error))
			{
				LogAnnotate(requestData, "ttsError", error);
			}
			LogTimestamp(requestData, "ttsFinishedTime");
			if (_voiceSDKLoggerImpl != null)
			{
				_voiceSDKLoggerImpl.LogInteractionStart(clipData.queryRequestId, "synthesize");
				foreach (string key in requestData.annotations.Keys)
				{
					_voiceSDKLoggerImpl.LogAnnotation(key, requestData.annotations[key]);
				}
				if (string.IsNullOrEmpty(error))
				{
					_voiceSDKLoggerImpl.LogInteractionEndSuccess();
				}
				else
				{
					_voiceSDKLoggerImpl.LogInteractionEndFailure(error);
				}
			}
			_requests.Remove(clipData.queryRequestId);
		}

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
			if (!_initialized)
			{
				_initialized = true;
				TTSService.OnServiceStart += OnServiceStart;
			}
		}

		private static void OnServiceStart(TTSService service)
		{
			if (service != null && service.GetComponent<TTSServiceLogging>() == null)
			{
				service.gameObject.AddComponent<TTSServiceLogging>();
			}
		}
	}
}
namespace Oculus.Voice.Interfaces
{
	public interface IPlatformVoiceService : IVoiceService, IVoiceEventProvider, ITelemetryEventsProvider, IVoiceActivationHandler
	{
		bool PlatformSupportsWit { get; }

		void SetRuntimeConfiguration(WitRuntimeConfiguration configuration);
	}
}
namespace Oculus.Voice.Bindings.Android
{
	public interface IVCBindingEvents
	{
		void OnServiceNotAvailable(string error, string message);
	}
	public class VoiceSDKBinding : BaseServiceBinding
	{
		public bool Active => binding.Call<bool>("isActive", Array.Empty<object>());

		public bool IsRequestActive => binding.Call<bool>("isRequestActive", Array.Empty<object>());

		public bool MicActive => binding.Call<bool>("isMicActive", Array.Empty<object>());

		public bool PlatformSupportsWit => binding.Call<bool>("isSupported", Array.Empty<object>());

		[Preserve]
		public VoiceSDKBinding(AndroidJavaObject sdkInstance)
			: base(sdkInstance)
		{
		}

		public void Activate(string text, WitRequestOptions options)
		{
			binding.Call("activate", text, options.ToJsonString());
		}

		public void Activate(WitRequestOptions options)
		{
			binding.Call("activate", options.ToJsonString());
		}

		public void ActivateImmediately(WitRequestOptions options)
		{
			binding.Call("activateImmediately", options.ToJsonString());
		}

		public void Deactivate()
		{
			binding.Call("deactivate");
		}

		public void DeactivateAndAbortRequest()
		{
			binding.Call("deactivateAndAbortRequest");
		}

		public void Deactivate(string requestID)
		{
			binding.Call("deactivate", requestID);
		}

		public void DeactivateAndAbortRequest(string requestID)
		{
			binding.Call("deactivateAndAbortRequest", requestID);
		}

		public void SetRuntimeConfiguration(WitRuntimeConfiguration configuration)
		{
			binding.Call("setRuntimeConfig", new VoiceSDKConfigBinding(configuration).ToJavaObject());
		}

		public void SetListener(VoiceSDKListenerBinding listener)
		{
			binding.Call("setListener", listener);
		}

		public void Connect()
		{
			binding.Call<bool>("connect", Array.Empty<object>());
		}
	}
	public class VoiceSDKConfigBinding
	{
		private WitRuntimeConfiguration configuration;

		public VoiceSDKConfigBinding(WitRuntimeConfiguration config)
		{
			configuration = config;
		}

		public AndroidJavaObject ToJavaObject()
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.oculus.assistant.api.voicesdk.immersivevoicecommands.WitConfiguration");
			androidJavaObject.Set("clientAccessToken", configuration.witConfiguration.GetClientAccessToken());
			AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("com.oculus.assistant.api.voicesdk.immersivevoicecommands.WitRuntimeConfiguration");
			androidJavaObject2.Set("witConfiguration", androidJavaObject);
			androidJavaObject2.Set("minKeepAliveVolume", configuration.minKeepAliveVolume);
			androidJavaObject2.Set("minKeepAliveTimeInSeconds", configuration.minKeepAliveTimeInSeconds);
			androidJavaObject2.Set("minTranscriptionKeepAliveTimeInSeconds", configuration.minTranscriptionKeepAliveTimeInSeconds);
			androidJavaObject2.Set("maxRecordingTime", configuration.maxRecordingTime);
			androidJavaObject2.Set("soundWakeThreshold", configuration.soundWakeThreshold);
			androidJavaObject2.Set("sampleLengthInMs", configuration.sampleLengthInMs);
			androidJavaObject2.Set("micBufferLengthInSeconds", configuration.micBufferLengthInSeconds);
			androidJavaObject2.Set("sendAudioToWit", configuration.sendAudioToWit);
			androidJavaObject2.Set("preferredActivationOffset", configuration.preferredActivationOffset);
			androidJavaObject2.Set("clientName", "wit-unity");
			androidJavaObject2.Set("serverVersion", "20250213");
			return androidJavaObject2;
		}
	}
	public class VoiceSDKImpl : BaseAndroidConnectionImpl<VoiceSDKBinding>, IPlatformVoiceService, IVoiceService, IVoiceEventProvider, ITelemetryEventsProvider, IVoiceActivationHandler, IVCBindingEvents
	{
		private bool _isServiceAvailable = true;

		public Action OnServiceNotAvailableEvent;

		private IVoiceService _baseVoiceService;

		private bool _isActive;

		private VoiceSDKListenerBinding eventBinding;

		public bool UsePlatformIntegrations
		{
			get
			{
				return true;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public bool PlatformSupportsWit
		{
			get
			{
				if (service.PlatformSupportsWit)
				{
					return _isServiceAvailable;
				}
				return false;
			}
		}

		public bool Active
		{
			get
			{
				if (service.Active)
				{
					return _isActive;
				}
				return false;
			}
		}

		public bool IsRequestActive => service.IsRequestActive;

		public bool MicActive => service.MicActive;

		public HashSet<VoiceServiceRequest> Requests { get; } = new HashSet<VoiceServiceRequest>();

		public ITranscriptionProvider TranscriptionProvider { get; set; }

		public VoiceEvents VoiceEvents
		{
			get
			{
				return _baseVoiceService.VoiceEvents;
			}
			set
			{
				_baseVoiceService.VoiceEvents = value;
			}
		}

		public TelemetryEvents TelemetryEvents
		{
			get
			{
				return _baseVoiceService.TelemetryEvents;
			}
			set
			{
				_baseVoiceService.TelemetryEvents = value;
			}
		}

		public VoiceSDKImpl(IVoiceService baseVoiceService)
			: base("com.oculus.assistant.api.unity.immersivevoicecommands.UnityIVCServiceFragment")
		{
			_baseVoiceService = baseVoiceService;
		}

		public void SetRuntimeConfiguration(WitRuntimeConfiguration configuration)
		{
			service.SetRuntimeConfiguration(configuration);
		}

		public bool CanActivateAudio()
		{
			return true;
		}

		public bool CanSend()
		{
			return true;
		}

		public override void Connect(string version)
		{
			base.Connect(version);
			eventBinding = new VoiceSDKListenerBinding(this, this);
			eventBinding.VoiceEvents.OnStoppedListening.AddListener(OnStoppedListening);
			service.SetListener(eventBinding);
			service.Connect();
			UnityEngine.Debug.Log("Platform integration initialization complete. Platform integrations are " + (PlatformSupportsWit ? "active" : "inactive"));
		}

		public override void Disconnect()
		{
			base.Disconnect();
			if (eventBinding != null)
			{
				eventBinding.VoiceEvents.OnStoppedListening.RemoveListener(OnStoppedListening);
			}
		}

		private void OnStoppedListening()
		{
			_isActive = false;
		}

		public Task<VoiceServiceRequest> Activate(string text, WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents)
		{
			if (requestOptions == null)
			{
				requestOptions = new WitRequestOptions();
			}
			requestOptions.Text = text;
			VoiceServiceRequest request = GetRequest(requestOptions, requestEvents, NLPRequestInputType.Text);
			request.Send();
			return Task.FromResult(request);
		}

		public VoiceServiceRequest Activate(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents)
		{
			if (_isActive)
			{
				return null;
			}
			_isActive = true;
			if (requestOptions == null)
			{
				requestOptions = new WitRequestOptions();
			}
			VoiceServiceRequest request = GetRequest(requestOptions, requestEvents, NLPRequestInputType.Audio);
			request.ActivateAudio();
			return request;
		}

		public VoiceServiceRequest ActivateImmediately(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents)
		{
			if (_isActive)
			{
				return null;
			}
			_isActive = true;
			if (requestOptions == null)
			{
				requestOptions = new WitRequestOptions();
			}
			VoiceServiceRequest request = GetRequest(requestOptions, requestEvents, NLPRequestInputType.Audio, audioImmediate: true);
			request.ActivateAudio();
			return request;
		}

		public void Deactivate()
		{
			_isActive = false;
			foreach (VoiceServiceRequest request in Requests)
			{
				if (request.InputType == NLPRequestInputType.Audio)
				{
					request.DeactivateAudio();
				}
			}
		}

		public void DeactivateAndAbortRequest()
		{
			_isActive = false;
			foreach (VoiceServiceRequest request in Requests)
			{
				if (request.InputType == NLPRequestInputType.Audio)
				{
					request.Cancel();
				}
			}
		}

		public void DeactivateAndAbortRequest(VoiceServiceRequest request)
		{
			if (Requests.Contains(request))
			{
				request.Cancel();
			}
		}

		public void OnServiceNotAvailable(string error, string message)
		{
			_isActive = false;
			_isServiceAvailable = false;
			OnServiceNotAvailableEvent?.Invoke();
		}

		private VoiceServiceRequest GetRequest(WitRequestOptions requestOptions, VoiceServiceRequestEvents requestEvents, NLPRequestInputType inputType, bool audioImmediate = false)
		{
			VoiceSDKImplRequest voiceSDKImplRequest = new VoiceSDKImplRequest(service, inputType, audioImmediate, requestOptions, requestEvents);
			Requests.Add(voiceSDKImplRequest);
			return voiceSDKImplRequest;
		}
	}
	public class VoiceSDKImplRequest : VoiceServiceRequest
	{
		public VoiceSDKBinding Service { get; private set; }

		public bool Immediately { get; private set; }

		protected override bool DecodeRawResponses => true;

		public VoiceSDKImplRequest(VoiceSDKBinding newService, NLPRequestInputType newInputType, bool newImmediately, WitRequestOptions newOptions, VoiceServiceRequestEvents newEvents)
			: base(newInputType, newOptions, newEvents)
		{
			Service = newService;
			Immediately = newImmediately;
		}

		protected override void HandleAudioActivation()
		{
			if (Immediately)
			{
				Service.ActivateImmediately(base.Options);
			}
			else
			{
				Service.Activate(base.Options);
			}
			SetAudioInputState(VoiceAudioInputState.On);
		}

		protected override void HandleAudioDeactivation()
		{
			Service.Deactivate(base.Options.RequestId);
			SetAudioInputState(VoiceAudioInputState.Off);
		}

		protected override void HandleSend()
		{
			if (base.InputType == NLPRequestInputType.Text)
			{
				Service.Activate(base.Options.Text, base.Options);
			}
		}

		protected override void HandleCancel()
		{
			Service.DeactivateAndAbortRequest(base.Options.RequestId);
		}

		public void HandlePartialResponse(string responseJson)
		{
			HandleRawResponse(responseJson, final: false);
		}

		public void HandlePartialTranscription(string transcription)
		{
			ApplyTranscription(transcription, full: false);
		}

		public void HandleFullTranscription(string transcription)
		{
			ApplyTranscription(transcription, full: true);
		}

		public void HandleTransmissionBegan()
		{
			if (base.InputType == NLPRequestInputType.Audio)
			{
				Send();
			}
		}

		public void HandleCanceled()
		{
			HandleCancel();
		}

		public void HandleError(string error, string message, string errorBody)
		{
			HandleFailure(error + " - " + message);
		}

		public void HandleResponse(string responseJson)
		{
			HandleRawResponse(responseJson, final: true);
		}
	}
	public class VoiceSDKListenerBinding : AndroidJavaProxy
	{
		public enum StoppedListeningReason
		{
			NoReasonProvided,
			Inactivity,
			Timeout,
			Deactivation
		}

		private IVoiceService _voiceService;

		private readonly IVCBindingEvents _bindingEvents;

		public VoiceEvents VoiceEvents => _voiceService.VoiceEvents;

		public TelemetryEvents TelemetryEvents => _voiceService.TelemetryEvents;

		public VoiceSDKListenerBinding(IVoiceService voiceService, IVCBindingEvents bindingEvents)
			: base("com.oculus.assistant.api.voicesdk.immersivevoicecommands.IVCEventsListener")
		{
			_voiceService = voiceService;
			_bindingEvents = bindingEvents;
		}

		private VoiceServiceRequest GetRequest(string requestId)
		{
			HashSet<VoiceServiceRequest> requests = _voiceService.Requests;
			if (requests == null || requests.Count == 0)
			{
				return null;
			}
			foreach (VoiceServiceRequest item in requests)
			{
				string b = item?.Options?.RequestId;
				if (string.Equals(requestId, b))
				{
					return item;
				}
			}
			return requests.First();
		}

		public void onStartListening(string requestId)
		{
			VoiceEvents.OnStartListening?.Invoke();
		}

		public void onStartListening()
		{
			onStartListening(null);
		}

		public void onStoppedListening(int reason, string requestId)
		{
			VoiceServiceRequest request = GetRequest(requestId);
			VoiceEvents.OnStoppedListening?.Invoke();
			switch ((StoppedListeningReason)reason)
			{
			case StoppedListeningReason.Inactivity:
				VoiceEvents.OnStoppedListeningDueToInactivity?.Invoke();
				request.Cancel();
				break;
			case StoppedListeningReason.Timeout:
				VoiceEvents.OnStoppedListeningDueToTimeout?.Invoke();
				request.Cancel();
				break;
			case StoppedListeningReason.Deactivation:
				VoiceEvents.OnStoppedListeningDueToDeactivation?.Invoke();
				break;
			case StoppedListeningReason.NoReasonProvided:
				break;
			}
		}

		public void onStoppedListening(int reason)
		{
			onStoppedListening(reason, null);
		}

		public void onRequestCreated(string requestId)
		{
			if (GetRequest(requestId) is VoiceSDKImplRequest voiceSDKImplRequest)
			{
				voiceSDKImplRequest.HandleTransmissionBegan();
			}
		}

		private void onRequestCreated()
		{
			onRequestCreated(null);
		}

		public void onPartialTranscription(string transcription, string requestId)
		{
			if (GetRequest(requestId) is VoiceSDKImplRequest voiceSDKImplRequest)
			{
				voiceSDKImplRequest.HandlePartialTranscription(transcription);
			}
		}

		public void onPartialTranscription(string transcription)
		{
			onPartialTranscription(transcription, null);
		}

		public void onFullTranscription(string transcription, string requestId)
		{
			if (GetRequest(requestId) is VoiceSDKImplRequest voiceSDKImplRequest)
			{
				voiceSDKImplRequest.HandleFullTranscription(transcription);
			}
		}

		public void onFullTranscription(string transcription)
		{
			onFullTranscription(transcription, null);
		}

		public void onPartialResponse(string responseJson, string requestId)
		{
			if (GetRequest(requestId) is VoiceSDKImplRequest voiceSDKImplRequest)
			{
				voiceSDKImplRequest.HandlePartialResponse(responseJson);
			}
		}

		public void onPartialResponse(string responseJson)
		{
			onPartialResponse(responseJson, null);
		}

		public void onAborted(string requestId)
		{
			if (GetRequest(requestId) is VoiceSDKImplRequest voiceSDKImplRequest)
			{
				voiceSDKImplRequest.HandleCanceled();
			}
		}

		public void onAborted()
		{
			onAborted(null);
		}

		public void onError(string error, string message, string errorBody, string requestId)
		{
			if (GetRequest(requestId) is VoiceSDKImplRequest voiceSDKImplRequest)
			{
				voiceSDKImplRequest.HandleError(error, message, errorBody);
			}
		}

		public void onError(string error, string message, string errorBody)
		{
			onError(error, message, errorBody, null);
		}

		public void onResponse(string responseJson, string requestId)
		{
			if (GetRequest(requestId) is VoiceSDKImplRequest voiceSDKImplRequest)
			{
				voiceSDKImplRequest.HandleResponse(responseJson);
			}
		}

		public void onResponse(string responseJson)
		{
			onResponse(responseJson, null);
		}

		public void onMicLevelChanged(float level, string requestId)
		{
			VoiceEvents.OnMicLevelChanged?.Invoke(level);
		}

		public void onMicLevelChanged(float level)
		{
			onMicLevelChanged(level, null);
		}

		public void onMicDataSent(string requestId)
		{
			VoiceEvents.OnMicDataSent?.Invoke();
		}

		public void onMicDataSent()
		{
			onMicDataSent(null);
		}

		public void onMinimumWakeThresholdHit(string requestId)
		{
			VoiceEvents.OnMinimumWakeThresholdHit?.Invoke();
		}

		public void onMinimumWakeThresholdHit()
		{
			onMinimumWakeThresholdHit(null);
		}

		public void onRequestCompleted(string requestId)
		{
		}

		public void onRequestCompleted()
		{
			onRequestCompleted(null);
		}

		public void onServiceNotAvailable(string error, string message)
		{
			VLog.W("Platform service is not available: " + error + " - " + message);
			_bindingEvents.OnServiceNotAvailable(error, message);
		}

		public void onAudioDurationTrackerFinished(long timestamp, double duration)
		{
			long arg = NativeTimestampToDateTime(timestamp).Ticks / 10000;
			TelemetryEvents.OnAudioTrackerFinished?.Invoke(arg, duration);
		}

		private DateTime NativeTimestampToDateTime(long javaTimestamp)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(javaTimestamp);
		}
	}
}
