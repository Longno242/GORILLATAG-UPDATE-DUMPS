using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AOT;
using Liv.Lck.Core.FFI;
using Liv.Lck.Core.Serialization;
using Newtonsoft.Json;
using SouthPointe.Serialization.MessagePack;
using UnityEngine;
using UnityEngine.Scripting;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("LIV.LCK")]
[assembly: InternalsVisibleTo("LIV.LCK.Streaming")]
[assembly: InternalsVisibleTo("LIV.LCK.Tests.Common")]
[assembly: InternalsVisibleTo("LIV.LCK.PlayModeTests")]
[assembly: InternalsVisibleTo("LIV.LCK.EditModeTests")]
[assembly: InternalsVisibleTo("LIV.LCK.Streaming.PlayModeTests")]
[assembly: InternalsVisibleTo("LIV.LCK.Streaming.EditModeTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
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
			FilePathsData = new byte[1656]
			{
				0, 0, 0, 1, 0, 0, 0, 95, 92, 80,
				97, 99, 107, 97, 103, 101, 115, 92, 116, 118,
				46, 108, 105, 118, 46, 108, 99, 107, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 76, 99, 107, 67, 111,
				114, 101, 92, 67, 111, 115, 109, 101, 116, 105,
				99, 115, 92, 73, 76, 99, 107, 67, 111, 115,
				109, 101, 116, 105, 99, 68, 101, 112, 101, 110,
				100, 97, 110, 116, 80, 108, 97, 121, 101, 114,
				73, 100, 83, 117, 112, 112, 108, 105, 101, 114,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				82, 92, 80, 97, 99, 107, 97, 103, 101, 115,
				92, 116, 118, 46, 108, 105, 118, 46, 108, 99,
				107, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 76, 99,
				107, 67, 111, 114, 101, 92, 67, 111, 115, 109,
				101, 116, 105, 99, 115, 92, 73, 76, 99, 107,
				67, 111, 115, 109, 101, 116, 105, 99, 115, 67,
				111, 111, 114, 100, 105, 110, 97, 116, 111, 114,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				82, 92, 80, 97, 99, 107, 97, 103, 101, 115,
				92, 116, 118, 46, 108, 105, 118, 46, 108, 99,
				107, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 76, 99,
				107, 67, 111, 114, 101, 92, 67, 111, 115, 109,
				101, 116, 105, 99, 115, 92, 73, 76, 99, 107,
				67, 111, 115, 109, 101, 116, 105, 99, 115, 70,
				101, 97, 116, 117, 114, 101, 70, 108, 97, 103,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				82, 92, 80, 97, 99, 107, 97, 103, 101, 115,
				92, 116, 118, 46, 108, 105, 118, 46, 108, 99,
				107, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 76, 99,
				107, 67, 111, 114, 101, 92, 67, 111, 115, 109,
				101, 116, 105, 99, 115, 92, 76, 99, 107, 65,
				118, 97, 105, 108, 97, 98, 108, 101, 67, 111,
				115, 109, 101, 116, 105, 99, 73, 110, 102, 111,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				85, 92, 80, 97, 99, 107, 97, 103, 101, 115,
				92, 116, 118, 46, 108, 105, 118, 46, 108, 99,
				107, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 76, 99,
				107, 67, 111, 114, 101, 92, 67, 111, 115, 109,
				101, 116, 105, 99, 115, 92, 76, 99, 107, 67,
				111, 114, 101, 67, 111, 115, 109, 101, 116, 105,
				99, 115, 67, 111, 111, 114, 100, 105, 110, 97,
				116, 111, 114, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 73, 92, 80, 97, 99, 107, 97,
				103, 101, 115, 92, 116, 118, 46, 108, 105, 118,
				46, 108, 99, 107, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 76, 99, 107, 67, 111, 114, 101, 92, 67,
				111, 115, 109, 101, 116, 105, 99, 115, 92, 76,
				99, 107, 67, 111, 115, 109, 101, 116, 105, 99,
				73, 110, 102, 111, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 99, 92, 80, 97, 99, 107,
				97, 103, 101, 115, 92, 116, 118, 46, 108, 105,
				118, 46, 108, 99, 107, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 76, 99, 107, 67, 111, 114, 101, 92,
				67, 111, 115, 109, 101, 116, 105, 99, 115, 92,
				76, 99, 107, 76, 111, 99, 97, 108, 67, 111,
				115, 109, 101, 116, 105, 99, 68, 101, 112, 101,
				110, 100, 97, 110, 116, 80, 108, 97, 121, 101,
				114, 73, 100, 83, 117, 112, 112, 108, 105, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 84, 92, 80, 97, 99, 107, 97, 103, 101,
				115, 92, 116, 118, 46, 108, 105, 118, 46, 108,
				99, 107, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 76,
				99, 107, 67, 111, 114, 101, 92, 67, 111, 115,
				109, 101, 116, 105, 99, 115, 92, 78, 117, 108,
				108, 76, 99, 107, 67, 111, 115, 109, 101, 116,
				105, 99, 67, 111, 111, 114, 100, 105, 110, 97,
				116, 111, 114, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 56, 92, 80, 97, 99, 107, 97,
				103, 101, 115, 92, 116, 118, 46, 108, 105, 118,
				46, 108, 99, 107, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 76, 99, 107, 67, 111, 114, 101, 92, 73,
				76, 99, 107, 67, 111, 114, 101, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 76, 92, 80,
				97, 99, 107, 97, 103, 101, 115, 92, 116, 118,
				46, 108, 105, 118, 46, 108, 99, 107, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 76, 99, 107, 67, 111,
				114, 101, 92, 73, 76, 99, 107, 84, 101, 108,
				101, 109, 101, 116, 114, 121, 67, 111, 110, 116,
				101, 120, 116, 80, 114, 111, 118, 105, 100, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 64, 92, 80, 97, 99, 107, 97, 103, 101,
				115, 92, 116, 118, 46, 108, 105, 118, 46, 108,
				99, 107, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 76,
				99, 107, 67, 111, 114, 101, 92, 73, 110, 116,
				101, 114, 111, 112, 85, 116, 105, 108, 105, 116,
				105, 101, 115, 46, 99, 115, 0, 0, 0, 6,
				0, 0, 0, 55, 92, 80, 97, 99, 107, 97,
				103, 101, 115, 92, 116, 118, 46, 108, 105, 118,
				46, 108, 99, 107, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 76, 99, 107, 67, 111, 114, 101, 92, 76,
				99, 107, 67, 111, 114, 101, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 57, 92, 80, 97,
				99, 107, 97, 103, 101, 115, 92, 116, 118, 46,
				108, 105, 118, 46, 108, 99, 107, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 76, 99, 107, 67, 111, 114,
				101, 92, 76, 99, 107, 67, 111, 114, 101, 46,
				103, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 66, 92, 80, 97, 99, 107, 97, 103, 101,
				115, 92, 116, 118, 46, 108, 105, 118, 46, 108,
				99, 107, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 76,
				99, 107, 67, 111, 114, 101, 92, 76, 99, 107,
				67, 111, 114, 101, 67, 111, 115, 109, 101, 116,
				105, 99, 115, 46, 103, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 66, 92, 80, 97, 99,
				107, 97, 103, 101, 115, 92, 116, 118, 46, 108,
				105, 118, 46, 108, 99, 107, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 76, 99, 107, 67, 111, 114, 101,
				92, 76, 99, 107, 67, 111, 114, 101, 84, 101,
				108, 101, 109, 101, 116, 114, 121, 46, 103, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 62,
				92, 80, 97, 99, 107, 97, 103, 101, 115, 92,
				116, 118, 46, 108, 105, 118, 46, 108, 99, 107,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 76, 99, 107,
				67, 111, 114, 101, 92, 76, 99, 107, 67, 111,
				114, 101, 87, 114, 97, 112, 112, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 75,
				92, 80, 97, 99, 107, 97, 103, 101, 115, 92,
				116, 118, 46, 108, 105, 118, 46, 108, 99, 107,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 76, 99, 107,
				67, 111, 114, 101, 92, 76, 99, 107, 84, 101,
				108, 101, 109, 101, 116, 114, 121, 67, 111, 110,
				116, 101, 120, 116, 80, 114, 111, 118, 105, 100,
				101, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 76, 92, 80, 97, 99, 107, 97, 103,
				101, 115, 92, 116, 118, 46, 108, 105, 118, 46,
				108, 99, 107, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				76, 99, 107, 67, 111, 114, 101, 92, 83, 101,
				114, 105, 97, 108, 105, 122, 97, 116, 105, 111,
				110, 92, 73, 76, 99, 107, 83, 101, 114, 105,
				97, 108, 105, 122, 101, 114, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 79, 92, 80, 97,
				99, 107, 97, 103, 101, 115, 92, 116, 118, 46,
				108, 105, 118, 46, 108, 99, 107, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 76, 99, 107, 67, 111, 114,
				101, 92, 83, 101, 114, 105, 97, 108, 105, 122,
				97, 116, 105, 111, 110, 92, 76, 99, 107, 74,
				115, 111, 110, 83, 101, 114, 105, 97, 108, 105,
				122, 101, 114, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 82, 92, 80, 97, 99, 107, 97,
				103, 101, 115, 92, 116, 118, 46, 108, 105, 118,
				46, 108, 99, 107, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 76, 99, 107, 67, 111, 114, 101, 92, 83,
				101, 114, 105, 97, 108, 105, 122, 97, 116, 105,
				111, 110, 92, 76, 99, 107, 77, 115, 103, 80,
				97, 99, 107, 83, 101, 114, 105, 97, 108, 105,
				122, 101, 114, 46, 99, 115
			},
			TypesData = new byte[1029]
			{
				0, 0, 0, 0, 55, 76, 105, 118, 46, 76,
				99, 107, 46, 67, 111, 115, 109, 101, 116, 105,
				99, 115, 124, 73, 76, 99, 107, 67, 111, 115,
				109, 101, 116, 105, 99, 68, 101, 112, 101, 110,
				100, 97, 110, 116, 80, 108, 97, 121, 101, 114,
				73, 100, 83, 117, 112, 112, 108, 105, 101, 114,
				0, 0, 0, 0, 47, 76, 105, 118, 46, 76,
				99, 107, 46, 67, 111, 114, 101, 46, 67, 111,
				115, 109, 101, 116, 105, 99, 115, 124, 73, 76,
				99, 107, 67, 111, 115, 109, 101, 116, 105, 99,
				115, 67, 111, 111, 114, 100, 105, 110, 97, 116,
				111, 114, 0, 0, 0, 0, 39, 76, 105, 118,
				46, 76, 99, 107, 124, 73, 76, 99, 107, 67,
				111, 115, 109, 101, 116, 105, 99, 115, 70, 101,
				97, 116, 117, 114, 101, 70, 108, 97, 103, 77,
				97, 110, 97, 103, 101, 114, 0, 0, 0, 0,
				47, 76, 105, 118, 46, 76, 99, 107, 46, 67,
				111, 114, 101, 46, 67, 111, 115, 109, 101, 116,
				105, 99, 115, 124, 76, 99, 107, 65, 118, 97,
				105, 108, 97, 98, 108, 101, 67, 111, 115, 109,
				101, 116, 105, 99, 73, 110, 102, 111, 0, 0,
				0, 0, 50, 76, 105, 118, 46, 76, 99, 107,
				46, 67, 111, 114, 101, 46, 67, 111, 115, 109,
				101, 116, 105, 99, 115, 124, 76, 99, 107, 67,
				111, 114, 101, 67, 111, 115, 109, 101, 116, 105,
				99, 115, 67, 111, 111, 114, 100, 105, 110, 97,
				116, 111, 114, 0, 0, 0, 0, 38, 76, 105,
				118, 46, 76, 99, 107, 46, 67, 111, 114, 101,
				46, 67, 111, 115, 109, 101, 116, 105, 99, 115,
				124, 76, 99, 107, 67, 111, 115, 109, 101, 116,
				105, 99, 73, 110, 102, 111, 0, 0, 0, 0,
				59, 76, 105, 118, 46, 76, 99, 107, 46, 67,
				111, 115, 109, 101, 116, 105, 99, 115, 124, 76,
				99, 107, 76, 111, 99, 97, 108, 67, 111, 115,
				109, 101, 116, 105, 99, 68, 101, 112, 101, 110,
				100, 97, 110, 116, 80, 108, 97, 121, 101, 114,
				73, 100, 83, 117, 112, 112, 108, 105, 101, 114,
				0, 0, 0, 0, 50, 76, 105, 118, 46, 76,
				99, 107, 46, 67, 111, 114, 101, 46, 67, 111,
				115, 109, 101, 116, 105, 99, 115, 124, 78, 117,
				108, 108, 76, 99, 107, 67, 111, 115, 109, 101,
				116, 105, 99, 115, 67, 111, 111, 114, 100, 105,
				110, 97, 116, 111, 114, 0, 0, 0, 0, 21,
				76, 105, 118, 46, 76, 99, 107, 46, 67, 111,
				114, 101, 124, 73, 76, 99, 107, 67, 111, 114,
				101, 0, 0, 0, 0, 41, 76, 105, 118, 46,
				76, 99, 107, 46, 67, 111, 114, 101, 124, 73,
				76, 99, 107, 84, 101, 108, 101, 109, 101, 116,
				114, 121, 67, 111, 110, 116, 101, 120, 116, 80,
				114, 111, 118, 105, 100, 101, 114, 0, 0, 0,
				0, 29, 76, 105, 118, 46, 76, 99, 107, 46,
				67, 111, 114, 101, 124, 73, 110, 116, 101, 114,
				111, 112, 85, 116, 105, 108, 105, 116, 105, 101,
				115, 0, 0, 0, 0, 25, 76, 105, 118, 46,
				76, 99, 107, 46, 67, 111, 114, 101, 46, 70,
				70, 73, 124, 71, 97, 109, 101, 73, 110, 102,
				111, 0, 0, 0, 0, 24, 76, 105, 118, 46,
				76, 99, 107, 46, 67, 111, 114, 101, 46, 70,
				70, 73, 124, 76, 99, 107, 73, 110, 102, 111,
				0, 0, 0, 0, 21, 76, 105, 118, 46, 76,
				99, 107, 46, 67, 111, 114, 101, 124, 71, 97,
				109, 101, 73, 110, 102, 111, 0, 0, 0, 0,
				20, 76, 105, 118, 46, 76, 99, 107, 46, 67,
				111, 114, 101, 124, 76, 99, 107, 73, 110, 102,
				111, 0, 0, 0, 0, 19, 76, 105, 118, 46,
				76, 99, 107, 46, 67, 111, 114, 101, 124, 82,
				101, 115, 117, 108, 116, 0, 0, 0, 0, 20,
				76, 105, 118, 46, 76, 99, 107, 46, 67, 111,
				114, 101, 124, 76, 99, 107, 67, 111, 114, 101,
				0, 0, 0, 0, 30, 76, 105, 118, 46, 76,
				99, 107, 46, 67, 111, 114, 101, 46, 70, 70,
				73, 124, 76, 99, 107, 67, 111, 114, 101, 78,
				97, 116, 105, 118, 101, 0, 0, 0, 0, 35,
				76, 105, 118, 46, 76, 99, 107, 46, 67, 111,
				114, 101, 124, 76, 99, 107, 67, 111, 114, 101,
				67, 111, 115, 109, 101, 116, 105, 99, 115, 78,
				97, 116, 105, 118, 101, 0, 0, 0, 0, 35,
				76, 105, 118, 46, 76, 99, 107, 46, 67, 111,
				114, 101, 124, 76, 99, 107, 67, 111, 114, 101,
				84, 101, 108, 101, 109, 101, 116, 114, 121, 78,
				97, 116, 105, 118, 101, 0, 0, 0, 0, 27,
				76, 105, 118, 46, 76, 99, 107, 46, 67, 111,
				114, 101, 124, 76, 99, 107, 67, 111, 114, 101,
				87, 114, 97, 112, 112, 101, 114, 0, 0, 0,
				0, 40, 76, 105, 118, 46, 76, 99, 107, 46,
				67, 111, 114, 101, 124, 76, 99, 107, 84, 101,
				108, 101, 109, 101, 116, 114, 121, 67, 111, 110,
				116, 101, 120, 116, 80, 114, 111, 118, 105, 100,
				101, 114, 0, 0, 0, 0, 41, 76, 105, 118,
				46, 76, 99, 107, 46, 67, 111, 114, 101, 46,
				83, 101, 114, 105, 97, 108, 105, 122, 97, 116,
				105, 111, 110, 124, 73, 76, 99, 107, 83, 101,
				114, 105, 97, 108, 105, 122, 101, 114, 0, 0,
				0, 0, 44, 76, 105, 118, 46, 76, 99, 107,
				46, 67, 111, 114, 101, 46, 83, 101, 114, 105,
				97, 108, 105, 122, 97, 116, 105, 111, 110, 124,
				76, 99, 107, 74, 115, 111, 110, 83, 101, 114,
				105, 97, 108, 105, 122, 101, 114, 0, 0, 0,
				0, 47, 76, 105, 118, 46, 76, 99, 107, 46,
				67, 111, 114, 101, 46, 83, 101, 114, 105, 97,
				108, 105, 122, 97, 116, 105, 111, 110, 124, 76,
				99, 107, 77, 115, 103, 80, 97, 99, 107, 83,
				101, 114, 105, 97, 108, 105, 122, 101, 114
			},
			TotalFiles = 20,
			TotalTypes = 25,
			IsEditorOnly = false
		};
	}
}
namespace Liv.Lck
{
	public interface ILckCosmeticsFeatureFlagManager
	{
		Task<bool> IsEnabledAsync();
	}
}
namespace Liv.Lck.Core
{
	public interface ILckCore
	{
		Task<Result<bool>> HasUserConfiguredStreaming();

		Task<Result<bool>> IsUserSubscribed();

		Task<Result<string>> StartLoginAttemptAsync();

		Task<Result<bool>> CheckLoginCompletedAsync();

		Task<Result<float>> GetRemainingBackoffTimeSeconds();
	}
	internal interface ILckTelemetryContextProvider
	{
		void SetTelemetryContext(LckTelemetryContextType contextType, Dictionary<string, object> context);

		void ClearTelemetryContext(LckTelemetryContextType contextType);
	}
	public static class InteropUtilities
	{
		public static IReadOnlyCollection<IntPtr> AllocateUnmanagedStringPointers(IEnumerable<string> strings, Encoding targetEncoding)
		{
			List<IntPtr> list = new List<IntPtr>();
			foreach (string @string in strings)
			{
				byte[] bytes = targetEncoding.GetBytes(@string + "\0");
				IntPtr intPtr = Marshal.AllocHGlobal(bytes.Length);
				Marshal.Copy(bytes, 0, intPtr, bytes.Length);
				list.Add(intPtr);
			}
			return list;
		}

		public static IntPtr AllocateUnmanagedArray(IReadOnlyCollection<IntPtr> ptrs)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(IntPtr.Size * ptrs.Count);
			for (int i = 0; i < ptrs.Count; i++)
			{
				Marshal.WriteIntPtr(intPtr, i * IntPtr.Size, ptrs.ElementAt(i));
			}
			return intPtr;
		}

		public static byte[] CopyUnmanagedByteArray(IntPtr byteArrayStartPtr, int byteArrayLength)
		{
			byte[] array = new byte[byteArrayLength];
			Marshal.Copy(byteArrayStartPtr, array, 0, byteArrayLength);
			return array;
		}

		public static string UTF8PointerToString(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			int i;
			for (i = 0; Marshal.ReadByte(ptr, i) != 0; i++)
			{
			}
			byte[] array = new byte[i];
			Marshal.Copy(ptr, array, 0, i);
			return Encoding.UTF8.GetString(array);
		}

		public static IntPtr StringToUTF8Pointer(string str)
		{
			if (str == null)
			{
				return IntPtr.Zero;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(str + "\0");
			IntPtr intPtr = Marshal.AllocHGlobal(bytes.Length);
			Marshal.Copy(bytes, 0, intPtr, bytes.Length);
			return intPtr;
		}

		public static void Free(IntPtr ptr)
		{
			Marshal.FreeHGlobal(ptr);
		}
	}
	public struct GameInfo
	{
		public string GameName;

		public string GameVersion;

		public string ProjectName;

		public string CompanyName;

		public string EngineVersion;

		public string RenderPipeline;

		public string GraphicsAPI;

		public string Platform;

		public string PersistentDataPath;

		public string InteractionSystems;
	}
	public struct LckInfo
	{
		public string Version;

		public int BuildNumber;
	}
	public enum LevelFilter
	{
		Off,
		Error,
		Warn,
		Info,
		Debug,
		Trace
	}
	public enum LogType
	{
		Error,
		Warning,
		Info,
		Trace
	}
	public enum CoreError
	{
		InternalError,
		MissingTrackingId,
		InvalidArgument,
		UserNotLoggedIn,
		FailedToCacheCosmetics,
		ServiceUnavailable,
		RateLimiterBackoff,
		LoginAttemptExpired,
		InvalidTrackingId
	}
	public class Result<T>
	{
		private readonly bool _success;

		private readonly string _message;

		private readonly CoreError? _error;

		private readonly T _result;

		public bool IsOk => _success;

		public string Message => _message;

		public CoreError? Err => _error;

		public T Ok => _result;

		private Result(bool success, string message, CoreError? error, T result)
		{
			_success = success;
			_message = message;
			_error = error;
			_result = result;
		}

		public static Result<T> NewSuccess(T result)
		{
			return new Result<T>(success: true, null, null, result);
		}

		public static Result<T> NewError(CoreError error, string message)
		{
			return new Result<T>(success: false, message, error, default(T));
		}
	}
	public static class LckCore
	{
		private static readonly object _loginLock = new object();

		private static ReturnCode _lastReturnCode;

		private static string _loginCode;

		[MonoPInvokeCallback(typeof(LckCoreNative.start_login_attempt_callback_delegate))]
		private static void StartLoginAttemptCallback(ReturnCode returnCode, IntPtr loginCodePtr)
		{
			lock (_loginLock)
			{
				_lastReturnCode = returnCode;
				if (returnCode == ReturnCode.Ok)
				{
					_loginCode = InteropUtilities.UTF8PointerToString(loginCodePtr);
				}
			}
		}

		public static void SetMaxLogLevel(LevelFilter levelFilter)
		{
			LckCoreNative.set_max_log_level(levelFilter);
		}

		public static Result<bool> Initialize(string trackingId, GameInfo gameInfo, LckInfo lckInfo)
		{
			if (string.IsNullOrEmpty(trackingId))
			{
				return Result<bool>.NewError(CoreError.MissingTrackingId, "Tracking ID cannot be null or empty.");
			}
			IntPtr intPtr = InteropUtilities.StringToUTF8Pointer(trackingId);
			Liv.Lck.Core.FFI.GameInfo game_info = Liv.Lck.Core.FFI.GameInfo.AllocateFromGameInfo(gameInfo);
			Liv.Lck.Core.FFI.LckInfo lck_info = Liv.Lck.Core.FFI.LckInfo.AllocateFromLckInfo(lckInfo);
			ReturnCode returnCode;
			try
			{
				returnCode = LckCoreNative.initialize(intPtr, game_info, lck_info);
			}
			finally
			{
				InteropUtilities.Free(intPtr);
				game_info.Free();
				lck_info.Free();
			}
			return returnCode switch
			{
				ReturnCode.Ok => Result<bool>.NewSuccess(result: true), 
				ReturnCode.InvalidArgument => Result<bool>.NewError(CoreError.InvalidArgument, "Invalid argument provided to initialize LckCore."), 
				ReturnCode.InvalidTrackingId => Result<bool>.NewError(CoreError.InvalidTrackingId, "Provided Tracking ID is not valid."), 
				_ => Result<bool>.NewError(CoreError.InternalError, $"Failed to initialize LckCore: {returnCode}"), 
			};
		}

		public static async Task<Result<bool>> HasUserConfiguredStreaming()
		{
			ReturnCode returnCode = ReturnCode.Ok;
			bool hasConfigured = false;
			IntPtr hasConfiguredPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bool)));
			Marshal.WriteByte(hasConfiguredPtr, 0);
			await Task.Run(delegate
			{
				returnCode = LckCoreNative.has_user_configured_streaming(hasConfiguredPtr);
			});
			if (returnCode == ReturnCode.Ok)
			{
				hasConfigured = Marshal.ReadByte(hasConfiguredPtr) != 0;
			}
			Marshal.FreeHGlobal(hasConfiguredPtr);
			if (returnCode != ReturnCode.Ok)
			{
				var (error, message) = MapReturnCodeToCoreError(returnCode);
				return Result<bool>.NewError(error, message);
			}
			return Result<bool>.NewSuccess(hasConfigured);
		}

		private static (CoreError, string) MapReturnCodeToCoreError(ReturnCode returnCode)
		{
			return returnCode switch
			{
				ReturnCode.UserNotLoggedIn => (CoreError.UserNotLoggedIn, "User is not logged in."), 
				ReturnCode.BackendUnavailable => (CoreError.ServiceUnavailable, "LIV backend service is unavailable."), 
				ReturnCode.RateLimiterBackoff => (CoreError.RateLimiterBackoff, "Client is in rate limiter backoff due to previous errors."), 
				_ => (CoreError.InternalError, $"Operation failed with return code: {returnCode}"), 
			};
		}

		public static async Task<Result<bool>> IsUserSubscribed()
		{
			ReturnCode returnCode = ReturnCode.Ok;
			bool isSubscribed = false;
			IntPtr isSubscribedPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bool)));
			Marshal.WriteByte(isSubscribedPtr, 0);
			await Task.Run(delegate
			{
				returnCode = LckCoreNative.is_user_subscribed(isSubscribedPtr);
			});
			if (returnCode == ReturnCode.Ok)
			{
				isSubscribed = Marshal.ReadByte(isSubscribedPtr) != 0;
			}
			Marshal.FreeHGlobal(isSubscribedPtr);
			if (returnCode != ReturnCode.Ok)
			{
				var (error, message) = MapReturnCodeToCoreError(returnCode);
				return Result<bool>.NewError(error, message);
			}
			return Result<bool>.NewSuccess(isSubscribed);
		}

		public static async Task<Result<string>> StartLoginAttemptAsync()
		{
			UnityEngine.Debug.Log("LCK: Starting login attempt task...");
			await Task.Run(delegate
			{
				lock (_loginLock)
				{
					_loginCode = null;
					_lastReturnCode = ReturnCode.Ok;
				}
				LckCoreNative.start_login_attempt(StartLoginAttemptCallback);
			});
			ReturnCode lastReturnCode;
			string loginCode;
			lock (_loginLock)
			{
				lastReturnCode = _lastReturnCode;
				loginCode = _loginCode;
			}
			UnityEngine.Debug.Log($"LCK: Login attempt task completed with return code: {lastReturnCode}");
			if (lastReturnCode != ReturnCode.Ok || loginCode == null)
			{
				var (error, message) = MapReturnCodeToCoreError(lastReturnCode);
				return Result<string>.NewError(error, message);
			}
			return Result<string>.NewSuccess(loginCode);
		}

		public static async Task<Result<bool>> CheckLoginCompletedAsync()
		{
			ReturnCode returnCode = ReturnCode.Ok;
			bool isComplete = false;
			UnityEngine.Debug.Log("LCK: Starting check login completed task...");
			await Task.Run(delegate
			{
				IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bool)));
				Marshal.WriteByte(intPtr, 0);
				ReturnCode returnCode2 = LckCoreNative.check_login_attempt_completed(intPtr);
				if (returnCode2 != ReturnCode.Ok)
				{
					returnCode = returnCode2;
				}
				else
				{
					isComplete = Marshal.ReadByte(intPtr) != 0;
				}
				Marshal.FreeHGlobal(intPtr);
			});
			UnityEngine.Debug.Log($"LCK: Check login completed task finished with return code: {returnCode}, isComplete: {isComplete}");
			if (returnCode != ReturnCode.Ok)
			{
				var (error, message) = MapReturnCodeToCoreError(returnCode);
				return Result<bool>.NewError(error, message);
			}
			return Result<bool>.NewSuccess(isComplete);
		}

		public static async Task<Result<float>> GetRemainingBackoffTimeSeconds()
		{
			ReturnCode returnCode = ReturnCode.Error;
			float remainingTime = 0f;
			await Task.Run(delegate
			{
				IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(float)));
				Marshal.WriteInt32(intPtr, 0);
				ReturnCode returnCode2 = LckCoreNative.get_remaining_backoff_time_seconds(intPtr);
				if (returnCode2 != ReturnCode.Ok)
				{
					returnCode = returnCode2;
				}
				else
				{
					remainingTime = Marshal.ReadInt32(intPtr);
				}
				Marshal.FreeHGlobal(intPtr);
			});
			if (returnCode != ReturnCode.Ok)
			{
				var (error, message) = MapReturnCodeToCoreError(returnCode);
				return Result<float>.NewError(error, message);
			}
			return Result<float>.NewSuccess(remainingTime);
		}

		public static void Log(LogType level, string message, string memberName = "", string filePath = "", int lineNumber = 0)
		{
			IntPtr intPtr = InteropUtilities.StringToUTF8Pointer(message);
			IntPtr intPtr2 = InteropUtilities.StringToUTF8Pointer(memberName);
			IntPtr intPtr3 = InteropUtilities.StringToUTF8Pointer(filePath);
			try
			{
				LckCoreNative.log(level, intPtr, intPtr2, intPtr3, lineNumber);
			}
			finally
			{
				InteropUtilities.Free(intPtr);
				InteropUtilities.Free(intPtr2);
				InteropUtilities.Free(intPtr3);
			}
		}

		public static void Dispose()
		{
			ReturnCode returnCode = LckCoreNative.dispose();
			if (returnCode != ReturnCode.Ok)
			{
				throw new InvalidOperationException($"Failed to dispose LckCore: {returnCode}");
			}
		}
	}
	internal static class LckCoreCosmeticsNative
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void announce_player_presence_for_session_on_presence_expiry_received_delegate(ulong time_until_expiration_seconds);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void get_local_user_cosmetics_on_cosmetic_available_delegate(IntPtr serialized_cosmetic_data_ptr, UIntPtr serialized_data_length, SerializationType serialization_type);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void get_user_cosmetics_for_session_on_cosmetic_available_delegate(IntPtr serialized_cosmetic_data_ptr, UIntPtr serialized_data_length, SerializationType serialization_type);

		private const string __DllName = "lck_core";

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern CosmeticsReturnCode get_user_cosmetics_for_session(IntPtr player_ids_array_ptr, UIntPtr player_ids_len, IntPtr session_id, get_user_cosmetics_for_session_on_cosmetic_available_delegate on_cosmetic_available);

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern CosmeticsReturnCode get_local_user_cosmetics(get_local_user_cosmetics_on_cosmetic_available_delegate on_cosmetic_available);

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern CosmeticsReturnCode announce_player_presence_for_session(IntPtr player_id, IntPtr session_id, announce_player_presence_for_session_on_presence_expiry_received_delegate on_presence_expiry_received);
	}
	internal enum CosmeticsReturnCode : uint
	{
		Ok,
		Panic,
		FailedToRetrieveState,
		InvalidArgument,
		BackendError,
		FailedToCacheCosmetics,
		FailedToNotifyOnCosmeticAvailable,
		MutexLockError,
		Unauthorized
	}
	public enum SerializationType : uint
	{
		MsgPack,
		JsonUTF8
	}
	internal static class LckCoreTelemetryNative
	{
		private const string __DllName = "lck_core";

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern TelemetryReturnCode send_telemetry_event_without_context(LckTelemetryEventType telemetry_event_type);

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern TelemetryReturnCode send_telemetry_event_with_context(LckTelemetryEventType telemetry_event_type, IntPtr serialized_context_data_ptr, UIntPtr len, SerializationType serialization_type);

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern TelemetryReturnCode clear_context(LckTelemetryContextType context_type);

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern TelemetryReturnCode set_telemetry_context_from_serialized_data(LckTelemetryContextType context_type, IntPtr serialized_context_data_ptr, UIntPtr len, SerializationType serialization_type);
	}
	internal enum TelemetryReturnCode : uint
	{
		Ok,
		Panic,
		FailedToClearContext,
		FailedToSetContext,
		FailedToRetrieveState,
		FailedToDeserializeContext,
		InvalidArgument
	}
	internal enum LckTelemetryContextType : uint
	{
		RecordingContext,
		StreamingContext
	}
	public enum LckTelemetryEventType : uint
	{
		GameInitialized,
		RecordingStarted,
		StreamingStarted,
		ServiceCreated,
		ServiceDisposed,
		CameraEnabled,
		CameraDisabled,
		RecordingStopped,
		StreamingStopped,
		StreamingError,
		PhotoCaptured,
		RecorderError,
		PhotoCaptureError,
		SdkError,
		Performance,
		EchoEnabled,
		EchoSaved
	}
	[Preserve]
	public class LckCoreWrapper : ILckCore
	{
		[Preserve]
		public LckCoreWrapper()
		{
		}

		Task<Result<bool>> ILckCore.CheckLoginCompletedAsync()
		{
			return LckCore.CheckLoginCompletedAsync();
		}

		Task<Result<bool>> ILckCore.HasUserConfiguredStreaming()
		{
			return LckCore.HasUserConfiguredStreaming();
		}

		Task<Result<string>> ILckCore.StartLoginAttemptAsync()
		{
			return LckCore.StartLoginAttemptAsync();
		}

		Task<Result<bool>> ILckCore.IsUserSubscribed()
		{
			return LckCore.IsUserSubscribed();
		}

		Task<Result<float>> ILckCore.GetRemainingBackoffTimeSeconds()
		{
			return LckCore.GetRemainingBackoffTimeSeconds();
		}
	}
	[Preserve]
	internal class LckTelemetryContextProvider : ILckTelemetryContextProvider
	{
		private readonly ILckSerializer _serializer = new LckMsgPackSerializer();

		[Preserve]
		public LckTelemetryContextProvider()
		{
		}

		public void SetTelemetryContext(LckTelemetryContextType contextType, Dictionary<string, object> context)
		{
			if (context == null || !context.Any())
			{
				ClearTelemetryContext(contextType);
				return;
			}
			byte[] array = _serializer.Serialize(context);
			IntPtr intPtr = Marshal.AllocHGlobal(array.Length);
			try
			{
				Marshal.Copy(array, 0, intPtr, array.Length);
				TelemetryReturnCode telemetryReturnCode = LckCoreTelemetryNative.set_telemetry_context_from_serialized_data(contextType, intPtr, (UIntPtr)(ulong)array.Length, _serializer.SerializationType);
				if (telemetryReturnCode != TelemetryReturnCode.Ok)
				{
					UnityEngine.Debug.LogError($"Failed to set telemetry context (return code={telemetryReturnCode})");
				}
			}
			catch (Exception arg)
			{
				UnityEngine.Debug.LogError($"Failed to set telemetry context: {arg}");
			}
			finally
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}

		public void ClearTelemetryContext(LckTelemetryContextType contextType)
		{
			TelemetryReturnCode telemetryReturnCode = LckCoreTelemetryNative.clear_context(contextType);
			if (telemetryReturnCode != TelemetryReturnCode.Ok)
			{
				UnityEngine.Debug.LogError($"Failed to clear telemetry context (return code={telemetryReturnCode})");
			}
		}
	}
}
namespace Liv.Lck.Core.Serialization
{
	public interface ILckSerializer
	{
		SerializationType SerializationType { get; }

		byte[] Serialize(object data);

		T Deserialize<T>(byte[] data);
	}
	[Preserve]
	internal class LckJsonSerializer : ILckSerializer
	{
		public SerializationType SerializationType => SerializationType.JsonUTF8;

		[Preserve]
		public LckJsonSerializer()
		{
		}

		public byte[] Serialize(object data)
		{
			string s = JsonConvert.SerializeObject(data);
			return Encoding.UTF8.GetBytes(s);
		}

		public T Deserialize<T>(byte[] data)
		{
			return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(data));
		}
	}
	[Preserve]
	internal class LckMsgPackSerializer : ILckSerializer
	{
		private readonly MessagePackFormatter _formatter = new MessagePackFormatter();

		public SerializationType SerializationType => SerializationType.MsgPack;

		[Preserve]
		public LckMsgPackSerializer()
		{
		}

		public byte[] Serialize(object data)
		{
			return _formatter.Serialize(data);
		}

		public T Deserialize<T>(byte[] data)
		{
			return _formatter.Deserialize<T>(data);
		}
	}
}
namespace Liv.Lck.Core.FFI
{
	internal struct GameInfo
	{
		public IntPtr GameName;

		public IntPtr GameVersion;

		public IntPtr ProjectName;

		public IntPtr CompanyName;

		public IntPtr EngineVersion;

		public IntPtr RenderPipeline;

		public IntPtr GraphicsAPI;

		public IntPtr Platform;

		public IntPtr PersistentDataPath;

		public IntPtr InteractionSystems;

		public static GameInfo AllocateFromGameInfo(Liv.Lck.Core.GameInfo gameInfo)
		{
			return new GameInfo(gameInfo);
		}

		public void Free()
		{
			InteropUtilities.Free(GameName);
			InteropUtilities.Free(GameVersion);
			InteropUtilities.Free(ProjectName);
			InteropUtilities.Free(CompanyName);
			InteropUtilities.Free(EngineVersion);
			InteropUtilities.Free(RenderPipeline);
			InteropUtilities.Free(GraphicsAPI);
			InteropUtilities.Free(Platform);
			InteropUtilities.Free(PersistentDataPath);
			InteropUtilities.Free(InteractionSystems);
		}

		private GameInfo(Liv.Lck.Core.GameInfo gameInfo)
		{
			GameName = InteropUtilities.StringToUTF8Pointer(gameInfo.GameName);
			GameVersion = InteropUtilities.StringToUTF8Pointer(gameInfo.GameVersion);
			ProjectName = InteropUtilities.StringToUTF8Pointer(gameInfo.ProjectName);
			CompanyName = InteropUtilities.StringToUTF8Pointer(gameInfo.CompanyName);
			EngineVersion = InteropUtilities.StringToUTF8Pointer(gameInfo.EngineVersion);
			RenderPipeline = InteropUtilities.StringToUTF8Pointer(gameInfo.RenderPipeline);
			GraphicsAPI = InteropUtilities.StringToUTF8Pointer(gameInfo.GraphicsAPI);
			Platform = InteropUtilities.StringToUTF8Pointer(gameInfo.Platform);
			PersistentDataPath = InteropUtilities.StringToUTF8Pointer(gameInfo.PersistentDataPath);
			InteractionSystems = InteropUtilities.StringToUTF8Pointer(gameInfo.InteractionSystems);
		}
	}
	internal struct LckInfo
	{
		public IntPtr Version;

		public int BuildNumber;

		public static LckInfo AllocateFromLckInfo(Liv.Lck.Core.LckInfo lckInfo)
		{
			return new LckInfo(lckInfo);
		}

		public void Free()
		{
			InteropUtilities.Free(Version);
		}

		private LckInfo(Liv.Lck.Core.LckInfo lckInfo)
		{
			Version = InteropUtilities.StringToUTF8Pointer(lckInfo.Version);
			BuildNumber = lckInfo.BuildNumber;
		}
	}
	internal static class LckCoreNative
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void start_login_attempt_callback_delegate(ReturnCode return_code, IntPtr login_code);

		private const string __DllName = "lck_core";

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern void set_max_log_level(LevelFilter level);

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern ReturnCode initialize_android(IntPtr context);

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern ReturnCode initialize(IntPtr tracking_id, GameInfo game_info, LckInfo lck_info);

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern ReturnCode check_login_attempt_completed(IntPtr complete);

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern ReturnCode get_remaining_backoff_time_seconds(IntPtr remaining);

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern ReturnCode is_user_subscribed(IntPtr subscribed);

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern ReturnCode has_user_configured_streaming(IntPtr configured);

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern ReturnCode start_login_attempt(start_login_attempt_callback_delegate callback);

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern ReturnCode dispose();

		[DllImport("lck_core", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern void log(LogType level, IntPtr message, IntPtr member_name, IntPtr file_path, int line_number);
	}
	internal enum ReturnCode : uint
	{
		Ok,
		Error,
		Panic,
		InvalidArgument,
		BackendUnavailable,
		Uninitialized,
		BackendDataParsingError,
		BackendClientError,
		UserNotLoggedIn,
		NullPointer,
		LoginAttemptExpired,
		Fatal,
		RateLimiterBackoff,
		InvalidTrackingId
	}
}
namespace Liv.Lck.Core.Cosmetics
{
	public interface ILckCosmeticsCoordinator
	{
		event Action<LckAvailableCosmeticInfo> OnCosmeticAvailable;

		Task InitializeLocalCosmeticsAsync();

		Task<Result<bool>> GetUserCosmeticsForSessionAsync(IEnumerable<string> playerIds, string sessionId);

		Task<Result<bool>> AnnouncePlayerPresenceForSessionAsync(string playerId, string sessionId);
	}
	[Serializable]
	public struct LckAvailableCosmeticInfo
	{
		public LckCosmeticInfo CosmeticInfo;

		public string[] PlayerIds;
	}
	[Preserve]
	public class LckCoreCosmeticsCoordinator : ILckCosmeticsCoordinator
	{
		private readonly ILckSerializer _serializer;

		private readonly ILckCosmeticsFeatureFlagManager _featureFlagManager;

		private CancellationTokenSource _reannounceCancellationTokenSource;

		private Task _requestLocalUserCosmeticsTask;

		private readonly object _lock = new object();

		private string _playerId;

		private string _sessionId;

		private static LckCoreCosmeticsCoordinator Instance { get; set; }

		public event Action<LckAvailableCosmeticInfo> OnCosmeticAvailable;

		[Preserve]
		public LckCoreCosmeticsCoordinator(ILckSerializer serializer, ILckCosmeticsFeatureFlagManager featureFlagManager)
		{
			Instance = this;
			_serializer = serializer;
			_featureFlagManager = featureFlagManager;
			InitializeLocalCosmeticsAsync();
		}

		public Task InitializeLocalCosmeticsAsync()
		{
			lock (_lock)
			{
				if (_requestLocalUserCosmeticsTask == null || _requestLocalUserCosmeticsTask.IsCompleted)
				{
					_requestLocalUserCosmeticsTask = RequestLocalUserCosmeticsAsyncDelayed();
				}
				return _requestLocalUserCosmeticsTask;
			}
		}

		private async Task RequestLocalUserCosmeticsAsyncDelayed()
		{
			_ = 2;
			try
			{
				await Task.Delay(3000);
				if (!(await _featureFlagManager.IsEnabledAsync()))
				{
					UnityEngine.Debug.Log("LCK: Cosmetics feature is disabled by feature flag. Local cosmetics will not be loaded.");
					return;
				}
				Result<bool> result = await GetLocalUserCosmeticsAsync();
				if (!result.IsOk)
				{
					UnityEngine.Debug.LogError("LCK: The initial, delayed fetch for local user cosmetics failed. Error: " + result.Message);
				}
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogError("LCK: RequestLocalUserCosmeticsAsyncDelayed failed with exception: " + ex.Message);
			}
		}

		private async Task<Result<bool>> GetLocalUserCosmeticsAsync()
		{
			if (!(await _featureFlagManager.IsEnabledAsync()))
			{
				return Result<bool>.NewSuccess(result: true);
			}
			return await Task.Run(delegate
			{
				CosmeticsReturnCode cosmeticsReturnCode = LckCoreCosmeticsNative.get_local_user_cosmetics(OnCosmeticAvailableStatic);
				switch (cosmeticsReturnCode)
				{
				case CosmeticsReturnCode.Ok:
					return Result<bool>.NewSuccess(result: true);
				case CosmeticsReturnCode.Unauthorized:
					return Result<bool>.NewSuccess(result: false);
				case CosmeticsReturnCode.FailedToCacheCosmetics:
					return Result<bool>.NewError(CoreError.FailedToCacheCosmetics, "Failed to cache one or more local user cosmetics");
				default:
				{
					string message = $"Failed to get local user cosmetics (return code = {cosmeticsReturnCode})";
					UnityEngine.Debug.LogError(message);
					return Result<bool>.NewError(CoreError.InternalError, message);
				}
				}
			});
		}

		public async Task<Result<bool>> GetUserCosmeticsForSessionAsync(IEnumerable<string> playerIds, string sessionId)
		{
			if (!(await _featureFlagManager.IsEnabledAsync()))
			{
				return Result<bool>.NewSuccess(result: true);
			}
			IReadOnlyCollection<IntPtr> playerIdUtf8StringPtrs = InteropUtilities.AllocateUnmanagedStringPointers(playerIds, Encoding.UTF8);
			IntPtr playerIdsArrayPointer = InteropUtilities.AllocateUnmanagedArray(playerIdUtf8StringPtrs);
			return await Task.Run(delegate
			{
				try
				{
					IntPtr intPtr = InteropUtilities.StringToUTF8Pointer(sessionId);
					CosmeticsReturnCode cosmeticsReturnCode = LckCoreCosmeticsNative.get_user_cosmetics_for_session(playerIdsArrayPointer, (UIntPtr)(ulong)playerIdUtf8StringPtrs.Count, intPtr, OnCosmeticAvailableStatic);
					InteropUtilities.Free(intPtr);
					switch (cosmeticsReturnCode)
					{
					case CosmeticsReturnCode.Ok:
						return Result<bool>.NewSuccess(result: true);
					case CosmeticsReturnCode.FailedToCacheCosmetics:
						return Result<bool>.NewError(CoreError.FailedToCacheCosmetics, "Failed to cache one or more cosmetics");
					default:
					{
						string message = $"Failed to get user cosmetics for session (return code = {cosmeticsReturnCode})";
						UnityEngine.Debug.LogError(message);
						return Result<bool>.NewError(CoreError.InternalError, message);
					}
					}
				}
				catch (Exception ex)
				{
					UnityEngine.Debug.LogException(ex);
					return Result<bool>.NewError(CoreError.InternalError, ex.Message);
				}
				finally
				{
					foreach (IntPtr item in playerIdUtf8StringPtrs)
					{
						Marshal.FreeHGlobal(item);
					}
					Marshal.FreeHGlobal(playerIdsArrayPointer);
				}
			});
		}

		public async Task<Result<bool>> AnnouncePlayerPresenceForSessionAsync(string playerId, string sessionId)
		{
			if (!(await _featureFlagManager.IsEnabledAsync()))
			{
				return Result<bool>.NewSuccess(result: true);
			}
			_sessionId = sessionId;
			return await Task.Run(delegate
			{
				IntPtr intPtr = InteropUtilities.StringToUTF8Pointer(playerId);
				IntPtr intPtr2 = InteropUtilities.StringToUTF8Pointer(sessionId);
				CosmeticsReturnCode cosmeticsReturnCode = LckCoreCosmeticsNative.announce_player_presence_for_session(intPtr, intPtr2, OnPresenceAnnouncementExpiryReceivedStatic);
				InteropUtilities.Free(intPtr);
				InteropUtilities.Free(intPtr2);
				switch (cosmeticsReturnCode)
				{
				case CosmeticsReturnCode.Ok:
					return Result<bool>.NewSuccess(result: true);
				case CosmeticsReturnCode.Unauthorized:
					return Result<bool>.NewSuccess(result: false);
				default:
				{
					string message = $"Failed to announce player presence for session (return code = {cosmeticsReturnCode})";
					UnityEngine.Debug.LogError(message);
					return Result<bool>.NewError(CoreError.InternalError, message);
				}
				}
			});
		}

		[MonoPInvokeCallback(typeof(LckCoreCosmeticsNative.get_user_cosmetics_for_session_on_cosmetic_available_delegate))]
		private static void OnCosmeticAvailableStatic(IntPtr serializedCosmeticDataPtr, UIntPtr serializedDataLength, SerializationType serializationType)
		{
			if (Instance == null)
			{
				UnityEngine.Debug.LogError("Cosmetic became available while LckCoreCosmeticsCoordinator is uninitialized");
			}
			else
			{
				Instance.HandleOnCosmeticAvailable(serializedCosmeticDataPtr, serializedDataLength, serializationType);
			}
		}

		private void HandleOnCosmeticAvailable(IntPtr serializedCosmeticDataPtr, UIntPtr serializedDataLength, SerializationType serializationType)
		{
			if (_serializer.SerializationType != serializationType)
			{
				UnityEngine.Debug.LogError($"Received cosmetic data in unexpected serialization format: {serializationType} " + $"(expected {_serializer.SerializationType})");
				return;
			}
			byte[] data = InteropUtilities.CopyUnmanagedByteArray(serializedCosmeticDataPtr, (int)(uint)serializedDataLength);
			LckAvailableCosmeticInfo obj = _serializer.Deserialize<LckAvailableCosmeticInfo>(data);
			string seed = "Cosmetic available at " + obj.CosmeticInfo.CosmeticFilepath + " for players:\n";
			seed = obj.PlayerIds.Aggregate(seed, (string current, string playerId) => current + "  - " + playerId);
			UnityEngine.Debug.Log(seed);
			this.OnCosmeticAvailable?.Invoke(obj);
		}

		[MonoPInvokeCallback(typeof(LckCoreCosmeticsNative.announce_player_presence_for_session_on_presence_expiry_received_delegate))]
		private static void OnPresenceAnnouncementExpiryReceivedStatic(ulong timeUntilExpirationSeconds)
		{
			if (Instance == null)
			{
				UnityEngine.Debug.LogError("Player presence was announced while LckCoreCosmeticsCoordinator is uninitialized");
			}
			else
			{
				Instance.HandlePresenceAnnouncement(timeUntilExpirationSeconds);
			}
		}

		private void HandlePresenceAnnouncement(ulong expirationTimeSeconds)
		{
			_reannounceCancellationTokenSource?.Cancel();
			_reannounceCancellationTokenSource = new CancellationTokenSource();
			TimeSpan reannounceDelay = TimeSpan.FromSeconds((double)expirationTimeSeconds * 0.9);
			ReannouncePresenceAfterDelay(reannounceDelay, _reannounceCancellationTokenSource.Token);
		}

		private async Task ReannouncePresenceAfterDelay(TimeSpan reannounceDelay, CancellationToken cancellationToken)
		{
			_ = 1;
			try
			{
				await Task.Delay(reannounceDelay, cancellationToken);
				if (!cancellationToken.IsCancellationRequested)
				{
					Result<bool> result = await AnnouncePlayerPresenceForSessionAsync(_playerId, _sessionId);
					if (!result.IsOk)
					{
						UnityEngine.Debug.LogError($"Failed to re-announce player presence: {result.Err}");
					}
				}
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
		}
	}
	[Serializable]
	public struct LckCosmeticInfo
	{
		public string CosmeticId;

		public string CosmeticFilepath;

		public Dictionary<string, object> CosmeticMetadata;
	}
	[Preserve]
	public class NullLckCosmeticsCoordinator : ILckCosmeticsCoordinator
	{
		public event Action<LckAvailableCosmeticInfo> OnCosmeticAvailable;

		[Preserve]
		public NullLckCosmeticsCoordinator()
		{
		}

		public Task InitializeLocalCosmeticsAsync()
		{
			return Task.CompletedTask;
		}

		public Task<Result<bool>> GetUserCosmeticsForSessionAsync(IEnumerable<string> playerIds, string sessionId)
		{
			return Task.FromResult(Result<bool>.NewSuccess(result: true));
		}

		public Task<Result<bool>> AnnouncePlayerPresenceForSessionAsync(string playerId, string sessionId)
		{
			return Task.FromResult(Result<bool>.NewSuccess(result: true));
		}
	}
}
namespace Liv.Lck.Cosmetics
{
	public delegate void PlayerIdUpdatedEvent();
	public interface ILckCosmeticDependantPlayerIdSupplier
	{
		event PlayerIdUpdatedEvent PlayerIdUpdated;

		string GetPlayerId();

		void UpdatePlayerId();
	}
	public class LckLocalCosmeticDependantPlayerIdSupplier : MonoBehaviour, ILckCosmeticDependantPlayerIdSupplier
	{
		[SerializeField]
		private string _playerId;

		public event PlayerIdUpdatedEvent PlayerIdUpdated;

		private void Start()
		{
			this.PlayerIdUpdated?.Invoke();
		}

		public virtual string GetPlayerId()
		{
			return _playerId;
		}

		public void UpdatePlayerId()
		{
			this.PlayerIdUpdated?.Invoke();
		}
	}
}
