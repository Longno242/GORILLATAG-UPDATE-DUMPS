using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Technie.PhysicsCreator.QHull;
using Technie.PhysicsCreator.Rigid;
using UnityEngine;
using UnityEngine.Rendering;

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
			FilePathsData = new byte[2872]
			{
				0, 0, 0, 1, 0, 0, 0, 49, 92, 65,
				115, 115, 101, 116, 115, 92, 84, 101, 99, 104,
				110, 105, 101, 92, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 67, 111, 110,
				115, 111, 108, 101, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 70, 92, 65, 115, 115, 101,
				116, 115, 92, 84, 101, 99, 104, 110, 105, 101,
				92, 80, 104, 121, 115, 105, 99, 115, 67, 114,
				101, 97, 116, 111, 114, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 70, 105, 116, 116, 101, 114,
				115, 92, 65, 108, 105, 103, 110, 101, 100, 67,
				97, 112, 115, 117, 108, 101, 70, 105, 116, 116,
				101, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 70, 92, 65, 115, 115, 101, 116, 115,
				92, 84, 101, 99, 104, 110, 105, 101, 92, 80,
				104, 121, 115, 105, 99, 115, 67, 114, 101, 97,
				116, 111, 114, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 70, 105, 116, 116, 101, 114, 115, 92,
				65, 120, 105, 115, 65, 108, 105, 103, 110, 101,
				100, 66, 111, 120, 70, 105, 116, 116, 101, 114,
				46, 99, 115, 0, 0, 0, 6, 0, 0, 0,
				72, 92, 65, 115, 115, 101, 116, 115, 92, 84,
				101, 99, 104, 110, 105, 101, 92, 80, 104, 121,
				115, 105, 99, 115, 67, 114, 101, 97, 116, 111,
				114, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				70, 105, 116, 116, 101, 114, 115, 92, 70, 97,
				99, 101, 65, 108, 105, 103, 110, 109, 101, 110,
				116, 66, 111, 120, 70, 105, 116, 116, 101, 114,
				46, 99, 115, 0, 0, 0, 4, 0, 0, 0,
				66, 92, 65, 115, 115, 101, 116, 115, 92, 84,
				101, 99, 104, 110, 105, 101, 92, 80, 104, 121,
				115, 105, 99, 115, 67, 114, 101, 97, 116, 111,
				114, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				70, 105, 116, 116, 101, 114, 115, 92, 82, 111,
				116, 97, 116, 101, 100, 66, 111, 120, 70, 105,
				116, 116, 101, 114, 46, 99, 115, 0, 0, 0,
				2, 0, 0, 0, 70, 92, 65, 115, 115, 101,
				116, 115, 92, 84, 101, 99, 104, 110, 105, 101,
				92, 80, 104, 121, 115, 105, 99, 115, 67, 114,
				101, 97, 116, 111, 114, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 70, 105, 116, 116, 101, 114,
				115, 92, 82, 111, 116, 97, 116, 101, 100, 67,
				97, 112, 115, 117, 108, 101, 70, 105, 116, 116,
				101, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 62, 92, 65, 115, 115, 101, 116, 115,
				92, 84, 101, 99, 104, 110, 105, 101, 92, 80,
				104, 121, 115, 105, 99, 115, 67, 114, 101, 97,
				116, 111, 114, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 70, 105, 116, 116, 101, 114, 115, 92,
				83, 112, 104, 101, 114, 101, 70, 105, 116, 116,
				101, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 52, 92, 65, 115, 115, 101, 116, 115,
				92, 84, 101, 99, 104, 110, 105, 101, 92, 80,
				104, 121, 115, 105, 99, 115, 67, 114, 101, 97,
				116, 111, 114, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 71, 105, 122, 109, 111, 85, 116, 105,
				108, 115, 46, 99, 115, 0, 0, 0, 2, 0,
				0, 0, 50, 92, 65, 115, 115, 101, 116, 115,
				92, 84, 101, 99, 104, 110, 105, 101, 92, 80,
				104, 121, 115, 105, 99, 115, 67, 114, 101, 97,
				116, 111, 114, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 72, 97, 115, 104, 85, 116, 105, 108,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				59, 92, 65, 115, 115, 101, 116, 115, 92, 84,
				101, 99, 104, 110, 105, 101, 92, 80, 104, 121,
				115, 105, 99, 115, 67, 114, 101, 97, 116, 111,
				114, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				73, 67, 114, 101, 97, 116, 111, 114, 67, 111,
				109, 112, 111, 110, 101, 110, 116, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 53, 92, 65,
				115, 115, 101, 116, 115, 92, 84, 101, 99, 104,
				110, 105, 101, 92, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 73, 69, 100,
				105, 116, 111, 114, 68, 97, 116, 97, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 47, 92,
				65, 115, 115, 101, 116, 115, 92, 84, 101, 99,
				104, 110, 105, 101, 92, 80, 104, 121, 115, 105,
				99, 115, 67, 114, 101, 97, 116, 111, 114, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 73, 72,
				117, 108, 108, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 65, 92, 65, 115, 115, 101, 116,
				115, 92, 84, 101, 99, 104, 110, 105, 101, 92,
				80, 104, 121, 115, 105, 99, 115, 67, 114, 101,
				97, 116, 111, 114, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 77, 101, 115, 104, 67, 117, 116,
				116, 101, 114, 92, 67, 117, 116, 116, 97, 98,
				108, 101, 77, 101, 115, 104, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 68, 92, 65, 115,
				115, 101, 116, 115, 92, 84, 101, 99, 104, 110,
				105, 101, 92, 80, 104, 121, 115, 105, 99, 115,
				67, 114, 101, 97, 116, 111, 114, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 77, 101, 115, 104,
				67, 117, 116, 116, 101, 114, 92, 67, 117, 116,
				116, 97, 98, 108, 101, 83, 117, 98, 77, 101,
				115, 104, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 63, 92, 65, 115, 115, 101, 116, 115,
				92, 84, 101, 99, 104, 110, 105, 101, 92, 80,
				104, 121, 115, 105, 99, 115, 67, 114, 101, 97,
				116, 111, 114, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 77, 101, 115, 104, 67, 117, 116, 116,
				101, 114, 92, 77, 101, 115, 104, 67, 117, 116,
				116, 101, 114, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 66, 92, 65, 115, 115, 101, 116,
				115, 92, 84, 101, 99, 104, 110, 105, 101, 92,
				80, 104, 121, 115, 105, 99, 115, 67, 114, 101,
				97, 116, 111, 114, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 80, 104, 121, 115, 105, 99, 115,
				67, 114, 101, 97, 116, 111, 114, 72, 117, 108,
				108, 70, 111, 108, 100, 101, 114, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 67, 92, 65,
				115, 115, 101, 116, 115, 92, 84, 101, 99, 104,
				110, 105, 101, 92, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 80, 104, 121,
				115, 105, 99, 115, 67, 114, 101, 97, 116, 111,
				114, 73, 110, 115, 116, 97, 108, 108, 82, 111,
				111, 116, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 52, 92, 65, 115, 115, 101, 116, 115,
				92, 84, 101, 99, 104, 110, 105, 101, 92, 80,
				104, 121, 115, 105, 99, 115, 67, 114, 101, 97,
				116, 111, 114, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 81, 72, 117, 108, 108, 92, 70, 97,
				99, 101, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 56, 92, 65, 115, 115, 101, 116, 115,
				92, 84, 101, 99, 104, 110, 105, 101, 92, 80,
				104, 121, 115, 105, 99, 115, 67, 114, 101, 97,
				116, 111, 114, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 81, 72, 117, 108, 108, 92, 70, 97,
				99, 101, 76, 105, 115, 116, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 56, 92, 65, 115,
				115, 101, 116, 115, 92, 84, 101, 99, 104, 110,
				105, 101, 92, 80, 104, 121, 115, 105, 99, 115,
				67, 114, 101, 97, 116, 111, 114, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 81, 72, 117, 108,
				108, 92, 72, 97, 108, 102, 69, 100, 103, 101,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				70, 92, 65, 115, 115, 101, 116, 115, 92, 84,
				101, 99, 104, 110, 105, 101, 92, 80, 104, 121,
				115, 105, 99, 115, 67, 114, 101, 97, 116, 111,
				114, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				81, 72, 117, 108, 108, 92, 73, 110, 116, 101,
				114, 110, 97, 108, 69, 114, 114, 111, 114, 69,
				120, 99, 101, 112, 116, 105, 111, 110, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 55, 92,
				65, 115, 115, 101, 116, 115, 92, 84, 101, 99,
				104, 110, 105, 101, 92, 80, 104, 121, 115, 105,
				99, 115, 67, 114, 101, 97, 116, 111, 114, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 81, 72,
				117, 108, 108, 92, 80, 111, 105, 110, 116, 51,
				100, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 57, 92, 65, 115, 115, 101, 116, 115, 92,
				84, 101, 99, 104, 110, 105, 101, 92, 80, 104,
				121, 115, 105, 99, 115, 67, 114, 101, 97, 116,
				111, 114, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 81, 72, 117, 108, 108, 92, 81, 72, 117,
				108, 108, 85, 116, 105, 108, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 59, 92, 65, 115,
				115, 101, 116, 115, 92, 84, 101, 99, 104, 110,
				105, 101, 92, 80, 104, 121, 115, 105, 99, 115,
				67, 114, 101, 97, 116, 111, 114, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 81, 72, 117, 108,
				108, 92, 81, 117, 105, 99, 107, 72, 117, 108,
				108, 51, 68, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 56, 92, 65, 115, 115, 101, 116,
				115, 92, 84, 101, 99, 104, 110, 105, 101, 92,
				80, 104, 121, 115, 105, 99, 115, 67, 114, 101,
				97, 116, 111, 114, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 81, 72, 117, 108, 108, 92, 86,
				101, 99, 116, 111, 114, 51, 100, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 54, 92, 65,
				115, 115, 101, 116, 115, 92, 84, 101, 99, 104,
				110, 105, 101, 92, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 81, 72, 117,
				108, 108, 92, 86, 101, 114, 116, 101, 120, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 58,
				92, 65, 115, 115, 101, 116, 115, 92, 84, 101,
				99, 104, 110, 105, 101, 92, 80, 104, 121, 115,
				105, 99, 115, 67, 114, 101, 97, 116, 111, 114,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 81,
				72, 117, 108, 108, 92, 86, 101, 114, 116, 101,
				120, 76, 105, 115, 116, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 52, 92, 65, 115, 115,
				101, 116, 115, 92, 84, 101, 99, 104, 110, 105,
				101, 92, 80, 104, 121, 115, 105, 99, 115, 67,
				114, 101, 97, 116, 111, 114, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 82, 105, 103, 105, 100,
				92, 72, 117, 108, 108, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 56, 92, 65, 115, 115,
				101, 116, 115, 92, 84, 101, 99, 104, 110, 105,
				101, 92, 80, 104, 121, 115, 105, 99, 115, 67,
				114, 101, 97, 116, 111, 114, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 82, 105, 103, 105, 100,
				92, 72, 117, 108, 108, 68, 97, 116, 97, 46,
				99, 115, 0, 0, 0, 3, 0, 0, 0, 60,
				92, 65, 115, 115, 101, 116, 115, 92, 84, 101,
				99, 104, 110, 105, 101, 92, 80, 104, 121, 115,
				105, 99, 115, 67, 114, 101, 97, 116, 111, 114,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 82,
				105, 103, 105, 100, 92, 80, 97, 105, 110, 116,
				105, 110, 103, 68, 97, 116, 97, 46, 99, 115,
				0, 0, 0, 2, 0, 0, 0, 68, 92, 65,
				115, 115, 101, 116, 115, 92, 84, 101, 99, 104,
				110, 105, 101, 92, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 82, 105, 103,
				105, 100, 92, 82, 105, 103, 105, 100, 67, 111,
				108, 108, 105, 100, 101, 114, 67, 114, 101, 97,
				116, 111, 114, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 73, 92, 65, 115, 115, 101, 116,
				115, 92, 84, 101, 99, 104, 110, 105, 101, 92,
				80, 104, 121, 115, 105, 99, 115, 67, 114, 101,
				97, 116, 111, 114, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 82, 105, 103, 105, 100, 92, 82,
				105, 103, 105, 100, 67, 111, 108, 108, 105, 100,
				101, 114, 67, 114, 101, 97, 116, 111, 114, 67,
				104, 105, 108, 100, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 62, 92, 65, 115, 115, 101,
				116, 115, 92, 84, 101, 99, 104, 110, 105, 101,
				92, 80, 104, 121, 115, 105, 99, 115, 67, 114,
				101, 97, 116, 111, 114, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 83, 107, 105, 110, 110, 101,
				100, 92, 66, 111, 110, 101, 72, 117, 108, 108,
				68, 97, 116, 97, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 72, 92, 65, 115, 115, 101,
				116, 115, 92, 84, 101, 99, 104, 110, 105, 101,
				92, 80, 104, 121, 115, 105, 99, 115, 67, 114,
				101, 97, 116, 111, 114, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 83, 107, 105, 110, 110, 101,
				100, 92, 83, 107, 105, 110, 110, 101, 100, 67,
				111, 108, 108, 105, 100, 101, 114, 67, 114, 101,
				97, 116, 111, 114, 46, 99, 115, 0, 0, 0,
				2, 0, 0, 0, 75, 92, 65, 115, 115, 101,
				116, 115, 92, 84, 101, 99, 104, 110, 105, 101,
				92, 80, 104, 121, 115, 105, 99, 115, 67, 114,
				101, 97, 116, 111, 114, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 83, 107, 105, 110, 110, 101,
				100, 92, 83, 107, 105, 110, 110, 101, 100, 67,
				111, 108, 108, 105, 100, 101, 114, 69, 100, 105,
				116, 111, 114, 68, 97, 116, 97, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 76, 92, 65,
				115, 115, 101, 116, 115, 92, 84, 101, 99, 104,
				110, 105, 101, 92, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 83, 107, 105,
				110, 110, 101, 100, 92, 83, 107, 105, 110, 110,
				101, 100, 67, 111, 108, 108, 105, 100, 101, 114,
				82, 117, 110, 116, 105, 109, 101, 68, 97, 116,
				97, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 48, 92, 65, 115, 115, 101, 116, 115, 92,
				84, 101, 99, 104, 110, 105, 101, 92, 80, 104,
				121, 115, 105, 99, 115, 67, 114, 101, 97, 116,
				111, 114, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 83, 112, 104, 101, 114, 101, 46, 99, 115,
				0, 0, 0, 2, 0, 0, 0, 53, 92, 65,
				115, 115, 101, 116, 115, 92, 84, 101, 99, 104,
				110, 105, 101, 92, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 83, 112, 104,
				101, 114, 101, 85, 116, 105, 108, 115, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 55, 92,
				65, 115, 115, 101, 116, 115, 92, 84, 101, 99,
				104, 110, 105, 101, 92, 80, 104, 121, 115, 105,
				99, 115, 67, 114, 101, 97, 116, 111, 114, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 84, 111,
				111, 108, 71, 85, 73, 76, 97, 121, 111, 117,
				116, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 54, 92, 65, 115, 115, 101, 116, 115, 92,
				84, 101, 99, 104, 110, 105, 101, 92, 80, 104,
				121, 115, 105, 99, 115, 67, 114, 101, 97, 116,
				111, 114, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 85, 110, 112, 97, 99, 107, 101, 100, 77,
				101, 115, 104, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 47, 92, 65, 115, 115, 101, 116,
				115, 92, 84, 101, 99, 104, 110, 105, 101, 92,
				80, 104, 121, 115, 105, 99, 115, 67, 114, 101,
				97, 116, 111, 114, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 85, 116, 105, 108, 115, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 63, 92,
				65, 115, 115, 101, 116, 115, 92, 84, 101, 99,
				104, 110, 105, 101, 92, 80, 104, 121, 115, 105,
				99, 115, 67, 114, 101, 97, 116, 111, 114, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 86, 104,
				97, 99, 100, 92, 86, 104, 97, 99, 100, 80,
				97, 114, 97, 109, 101, 116, 101, 114, 115, 46,
				99, 115
			},
			TypesData = new byte[2437]
			{
				0, 0, 0, 0, 30, 84, 101, 99, 104, 110,
				105, 101, 46, 80, 104, 121, 115, 105, 99, 115,
				67, 114, 101, 97, 116, 111, 114, 124, 67, 111,
				110, 115, 111, 108, 101, 0, 0, 0, 0, 43,
				84, 101, 99, 104, 110, 105, 101, 46, 80, 104,
				121, 115, 105, 99, 115, 67, 114, 101, 97, 116,
				111, 114, 124, 65, 108, 105, 103, 110, 101, 100,
				67, 97, 112, 115, 117, 108, 101, 70, 105, 116,
				116, 101, 114, 0, 0, 0, 0, 43, 84, 101,
				99, 104, 110, 105, 101, 46, 80, 104, 121, 115,
				105, 99, 115, 67, 114, 101, 97, 116, 111, 114,
				124, 65, 120, 105, 115, 65, 108, 105, 103, 110,
				101, 100, 66, 111, 120, 70, 105, 116, 116, 101,
				114, 0, 0, 0, 0, 27, 84, 101, 99, 104,
				110, 105, 101, 46, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 124, 80,
				111, 115, 101, 0, 0, 0, 0, 31, 84, 101,
				99, 104, 110, 105, 101, 46, 80, 104, 121, 115,
				105, 99, 115, 67, 114, 101, 97, 116, 111, 114,
				124, 84, 114, 105, 97, 110, 103, 108, 101, 0,
				0, 0, 0, 37, 84, 101, 99, 104, 110, 105,
				101, 46, 80, 104, 121, 115, 105, 99, 115, 67,
				114, 101, 97, 116, 111, 114, 124, 84, 114, 105,
				97, 110, 103, 108, 101, 66, 117, 99, 107, 101,
				116, 0, 0, 0, 0, 41, 84, 101, 99, 104,
				110, 105, 101, 46, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 124, 84,
				114, 105, 97, 110, 103, 108, 101, 65, 114, 101,
				97, 83, 111, 114, 116, 101, 114, 0, 0, 0,
				0, 43, 84, 101, 99, 104, 110, 105, 101, 46,
				80, 104, 121, 115, 105, 99, 115, 67, 114, 101,
				97, 116, 111, 114, 124, 84, 114, 105, 97, 110,
				103, 108, 101, 66, 117, 99, 107, 101, 116, 83,
				111, 114, 116, 101, 114, 0, 0, 0, 0, 45,
				84, 101, 99, 104, 110, 105, 101, 46, 80, 104,
				121, 115, 105, 99, 115, 67, 114, 101, 97, 116,
				111, 114, 124, 70, 97, 99, 101, 65, 108, 105,
				103, 110, 109, 101, 110, 116, 66, 111, 120, 70,
				105, 116, 116, 101, 114, 0, 0, 0, 0, 40,
				84, 101, 99, 104, 110, 105, 101, 46, 80, 104,
				121, 115, 105, 99, 115, 67, 114, 101, 97, 116,
				111, 114, 124, 67, 111, 110, 115, 116, 114, 117,
				99, 116, 105, 111, 110, 80, 108, 97, 110, 101,
				0, 0, 0, 0, 33, 84, 101, 99, 104, 110,
				105, 101, 46, 80, 104, 121, 115, 105, 99, 115,
				67, 114, 101, 97, 116, 111, 114, 124, 82, 111,
				116, 97, 116, 101, 100, 66, 111, 120, 0, 0,
				0, 0, 35, 84, 101, 99, 104, 110, 105, 101,
				46, 80, 104, 121, 115, 105, 99, 115, 67, 114,
				101, 97, 116, 111, 114, 124, 86, 111, 108, 117,
				109, 101, 83, 111, 114, 116, 101, 114, 0, 0,
				0, 0, 39, 84, 101, 99, 104, 110, 105, 101,
				46, 80, 104, 121, 115, 105, 99, 115, 67, 114,
				101, 97, 116, 111, 114, 124, 82, 111, 116, 97,
				116, 101, 100, 66, 111, 120, 70, 105, 116, 116,
				101, 114, 0, 0, 0, 0, 37, 84, 101, 99,
				104, 110, 105, 101, 46, 80, 104, 121, 115, 105,
				99, 115, 67, 114, 101, 97, 116, 111, 114, 124,
				82, 111, 116, 97, 116, 101, 100, 67, 97, 112,
				115, 117, 108, 101, 0, 0, 0, 0, 43, 84,
				101, 99, 104, 110, 105, 101, 46, 80, 104, 121,
				115, 105, 99, 115, 67, 114, 101, 97, 116, 111,
				114, 124, 82, 111, 116, 97, 116, 101, 100, 67,
				97, 112, 115, 117, 108, 101, 70, 105, 116, 116,
				101, 114, 0, 0, 0, 0, 35, 84, 101, 99,
				104, 110, 105, 101, 46, 80, 104, 121, 115, 105,
				99, 115, 67, 114, 101, 97, 116, 111, 114, 124,
				83, 112, 104, 101, 114, 101, 70, 105, 116, 116,
				101, 114, 0, 0, 0, 0, 33, 84, 101, 99,
				104, 110, 105, 101, 46, 80, 104, 121, 115, 105,
				99, 115, 67, 114, 101, 97, 116, 111, 114, 124,
				71, 105, 122, 109, 111, 85, 116, 105, 108, 115,
				0, 0, 0, 0, 30, 84, 101, 99, 104, 110,
				105, 101, 46, 80, 104, 121, 115, 105, 99, 115,
				67, 114, 101, 97, 116, 111, 114, 124, 72, 97,
				115, 104, 49, 54, 48, 0, 0, 0, 0, 31,
				84, 101, 99, 104, 110, 105, 101, 46, 80, 104,
				121, 115, 105, 99, 115, 67, 114, 101, 97, 116,
				111, 114, 124, 72, 97, 115, 104, 85, 116, 105,
				108, 0, 0, 0, 0, 40, 84, 101, 99, 104,
				110, 105, 101, 46, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 124, 73,
				67, 114, 101, 97, 116, 111, 114, 67, 111, 109,
				112, 111, 110, 101, 110, 116, 0, 0, 0, 0,
				34, 84, 101, 99, 104, 110, 105, 101, 46, 80,
				104, 121, 115, 105, 99, 115, 67, 114, 101, 97,
				116, 111, 114, 124, 73, 69, 100, 105, 116, 111,
				114, 68, 97, 116, 97, 0, 0, 0, 0, 28,
				84, 101, 99, 104, 110, 105, 101, 46, 80, 104,
				121, 115, 105, 99, 115, 67, 114, 101, 97, 116,
				111, 114, 124, 73, 72, 117, 108, 108, 0, 0,
				0, 0, 35, 84, 101, 99, 104, 110, 105, 101,
				46, 80, 104, 121, 115, 105, 99, 115, 67, 114,
				101, 97, 116, 111, 114, 124, 67, 117, 116, 116,
				97, 98, 108, 101, 77, 101, 115, 104, 0, 0,
				0, 0, 38, 84, 101, 99, 104, 110, 105, 101,
				46, 80, 104, 121, 115, 105, 99, 115, 67, 114,
				101, 97, 116, 111, 114, 124, 67, 117, 116, 116,
				97, 98, 108, 101, 83, 117, 98, 77, 101, 115,
				104, 0, 0, 0, 0, 33, 84, 101, 99, 104,
				110, 105, 101, 46, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 124, 77,
				101, 115, 104, 67, 117, 116, 116, 101, 114, 0,
				0, 0, 0, 47, 84, 101, 99, 104, 110, 105,
				101, 46, 80, 104, 121, 115, 105, 99, 115, 67,
				114, 101, 97, 116, 111, 114, 124, 80, 104, 121,
				115, 105, 99, 115, 67, 114, 101, 97, 116, 111,
				114, 72, 117, 108, 108, 70, 111, 108, 100, 101,
				114, 0, 0, 0, 0, 48, 84, 101, 99, 104,
				110, 105, 101, 46, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 124, 80,
				104, 121, 115, 105, 99, 115, 67, 114, 101, 97,
				116, 111, 114, 73, 110, 115, 116, 97, 108, 108,
				82, 111, 111, 116, 0, 0, 0, 0, 33, 84,
				101, 99, 104, 110, 105, 101, 46, 80, 104, 121,
				115, 105, 99, 115, 67, 114, 101, 97, 116, 111,
				114, 46, 81, 72, 117, 108, 108, 124, 70, 97,
				99, 101, 0, 0, 0, 0, 37, 84, 101, 99,
				104, 110, 105, 101, 46, 80, 104, 121, 115, 105,
				99, 115, 67, 114, 101, 97, 116, 111, 114, 46,
				81, 72, 117, 108, 108, 124, 70, 97, 99, 101,
				76, 105, 115, 116, 0, 0, 0, 0, 37, 84,
				101, 99, 104, 110, 105, 101, 46, 80, 104, 121,
				115, 105, 99, 115, 67, 114, 101, 97, 116, 111,
				114, 46, 81, 72, 117, 108, 108, 124, 72, 97,
				108, 102, 69, 100, 103, 101, 0, 0, 0, 0,
				51, 84, 101, 99, 104, 110, 105, 101, 46, 80,
				104, 121, 115, 105, 99, 115, 67, 114, 101, 97,
				116, 111, 114, 46, 81, 72, 117, 108, 108, 124,
				73, 110, 116, 101, 114, 110, 97, 108, 69, 114,
				114, 111, 114, 69, 120, 99, 101, 112, 116, 105,
				111, 110, 0, 0, 0, 0, 36, 84, 101, 99,
				104, 110, 105, 101, 46, 80, 104, 121, 115, 105,
				99, 115, 67, 114, 101, 97, 116, 111, 114, 46,
				81, 72, 117, 108, 108, 124, 80, 111, 105, 110,
				116, 51, 100, 0, 0, 0, 0, 32, 84, 101,
				99, 104, 110, 105, 101, 46, 80, 104, 121, 115,
				105, 99, 115, 67, 114, 101, 97, 116, 111, 114,
				124, 81, 72, 117, 108, 108, 85, 116, 105, 108,
				0, 0, 0, 0, 40, 84, 101, 99, 104, 110,
				105, 101, 46, 80, 104, 121, 115, 105, 99, 115,
				67, 114, 101, 97, 116, 111, 114, 46, 81, 72,
				117, 108, 108, 124, 81, 117, 105, 99, 107, 72,
				117, 108, 108, 51, 68, 0, 0, 0, 0, 37,
				84, 101, 99, 104, 110, 105, 101, 46, 80, 104,
				121, 115, 105, 99, 115, 67, 114, 101, 97, 116,
				111, 114, 46, 81, 72, 117, 108, 108, 124, 86,
				101, 99, 116, 111, 114, 51, 100, 0, 0, 0,
				0, 35, 84, 101, 99, 104, 110, 105, 101, 46,
				80, 104, 121, 115, 105, 99, 115, 67, 114, 101,
				97, 116, 111, 114, 46, 81, 72, 117, 108, 108,
				124, 86, 101, 114, 116, 101, 120, 0, 0, 0,
				0, 39, 84, 101, 99, 104, 110, 105, 101, 46,
				80, 104, 121, 115, 105, 99, 115, 67, 114, 101,
				97, 116, 111, 114, 46, 81, 72, 117, 108, 108,
				124, 86, 101, 114, 116, 101, 120, 76, 105, 115,
				116, 0, 0, 0, 0, 33, 84, 101, 99, 104,
				110, 105, 101, 46, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 46, 82,
				105, 103, 105, 100, 124, 72, 117, 108, 108, 0,
				0, 0, 0, 31, 84, 101, 99, 104, 110, 105,
				101, 46, 80, 104, 121, 115, 105, 99, 115, 67,
				114, 101, 97, 116, 111, 114, 124, 72, 117, 108,
				108, 68, 97, 116, 97, 0, 0, 0, 0, 29,
				84, 101, 99, 104, 110, 105, 101, 46, 80, 104,
				121, 115, 105, 99, 115, 67, 114, 101, 97, 116,
				111, 114, 124, 66, 111, 120, 68, 101, 102, 0,
				0, 0, 0, 33, 84, 101, 99, 104, 110, 105,
				101, 46, 80, 104, 121, 115, 105, 99, 115, 67,
				114, 101, 97, 116, 111, 114, 124, 67, 97, 112,
				115, 117, 108, 101, 68, 101, 102, 0, 0, 0,
				0, 35, 84, 101, 99, 104, 110, 105, 101, 46,
				80, 104, 121, 115, 105, 99, 115, 67, 114, 101,
				97, 116, 111, 114, 124, 80, 97, 105, 110, 116,
				105, 110, 103, 68, 97, 116, 97, 0, 0, 0,
				0, 34, 84, 101, 99, 104, 110, 105, 101, 46,
				80, 104, 121, 115, 105, 99, 115, 67, 114, 101,
				97, 116, 111, 114, 124, 72, 117, 108, 108, 77,
				97, 112, 112, 105, 110, 103, 0, 0, 0, 0,
				43, 84, 101, 99, 104, 110, 105, 101, 46, 80,
				104, 121, 115, 105, 99, 115, 67, 114, 101, 97,
				116, 111, 114, 124, 82, 105, 103, 105, 100, 67,
				111, 108, 108, 105, 100, 101, 114, 67, 114, 101,
				97, 116, 111, 114, 0, 0, 0, 0, 48, 84,
				101, 99, 104, 110, 105, 101, 46, 80, 104, 121,
				115, 105, 99, 115, 67, 114, 101, 97, 116, 111,
				114, 124, 82, 105, 103, 105, 100, 67, 111, 108,
				108, 105, 100, 101, 114, 67, 114, 101, 97, 116,
				111, 114, 67, 104, 105, 108, 100, 0, 0, 0,
				0, 43, 84, 101, 99, 104, 110, 105, 101, 46,
				80, 104, 121, 115, 105, 99, 115, 67, 114, 101,
				97, 116, 111, 114, 46, 83, 107, 105, 110, 110,
				101, 100, 124, 66, 111, 110, 101, 72, 117, 108,
				108, 68, 97, 116, 97, 0, 0, 0, 0, 53,
				84, 101, 99, 104, 110, 105, 101, 46, 80, 104,
				121, 115, 105, 99, 115, 67, 114, 101, 97, 116,
				111, 114, 46, 83, 107, 105, 110, 110, 101, 100,
				124, 83, 107, 105, 110, 110, 101, 100, 67, 111,
				108, 108, 105, 100, 101, 114, 67, 114, 101, 97,
				116, 111, 114, 0, 0, 0, 0, 39, 84, 101,
				99, 104, 110, 105, 101, 46, 80, 104, 121, 115,
				105, 99, 115, 67, 114, 101, 97, 116, 111, 114,
				46, 83, 107, 105, 110, 110, 101, 100, 124, 66,
				111, 110, 101, 68, 97, 116, 97, 0, 0, 0,
				0, 56, 84, 101, 99, 104, 110, 105, 101, 46,
				80, 104, 121, 115, 105, 99, 115, 67, 114, 101,
				97, 116, 111, 114, 46, 83, 107, 105, 110, 110,
				101, 100, 124, 83, 107, 105, 110, 110, 101, 100,
				67, 111, 108, 108, 105, 100, 101, 114, 69, 100,
				105, 116, 111, 114, 68, 97, 116, 97, 0, 0,
				0, 0, 57, 84, 101, 99, 104, 110, 105, 101,
				46, 80, 104, 121, 115, 105, 99, 115, 67, 114,
				101, 97, 116, 111, 114, 46, 83, 107, 105, 110,
				110, 101, 100, 124, 83, 107, 105, 110, 110, 101,
				100, 67, 111, 108, 108, 105, 100, 101, 114, 82,
				117, 110, 116, 105, 109, 101, 68, 97, 116, 97,
				0, 0, 0, 0, 29, 84, 101, 99, 104, 110,
				105, 101, 46, 80, 104, 121, 115, 105, 99, 115,
				67, 114, 101, 97, 116, 111, 114, 124, 83, 112,
				104, 101, 114, 101, 0, 0, 0, 0, 34, 84,
				101, 99, 104, 110, 105, 101, 46, 80, 104, 121,
				115, 105, 99, 115, 67, 114, 101, 97, 116, 111,
				114, 124, 83, 112, 104, 101, 114, 101, 85, 116,
				105, 108, 115, 0, 0, 0, 0, 42, 84, 101,
				99, 104, 110, 105, 101, 46, 80, 104, 121, 115,
				105, 99, 115, 67, 114, 101, 97, 116, 111, 114,
				46, 83, 112, 104, 101, 114, 101, 85, 116, 105,
				108, 115, 124, 83, 117, 112, 112, 111, 114, 116,
				0, 0, 0, 0, 36, 84, 101, 99, 104, 110,
				105, 101, 46, 80, 104, 121, 115, 105, 99, 115,
				67, 114, 101, 97, 116, 111, 114, 124, 84, 111,
				111, 108, 71, 85, 73, 76, 97, 121, 111, 117,
				116, 0, 0, 0, 0, 35, 84, 101, 99, 104,
				110, 105, 101, 46, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 124, 85,
				110, 112, 97, 99, 107, 101, 100, 77, 101, 115,
				104, 0, 0, 0, 0, 28, 84, 101, 99, 104,
				110, 105, 101, 46, 80, 104, 121, 115, 105, 99,
				115, 67, 114, 101, 97, 116, 111, 114, 124, 85,
				116, 105, 108, 115, 0, 0, 0, 0, 38, 84,
				101, 99, 104, 110, 105, 101, 46, 80, 104, 121,
				115, 105, 99, 115, 67, 114, 101, 97, 116, 111,
				114, 124, 86, 104, 97, 99, 100, 80, 97, 114,
				97, 109, 101, 116, 101, 114, 115
			},
			TotalFiles = 42,
			TotalTypes = 57,
			IsEditorOnly = false
		};
	}
}
namespace Technie.PhysicsCreator
{
	public static class Console
	{
		public const bool IS_DEBUG_OUTPUT_ENABLED = false;

		public const bool SHOW_SHADOW_HIERARCHY = false;

		public const bool ENABLE_JOINT_SUPPORT = false;

		public static string Technie;

		public static Logger output;

		static Console()
		{
			Technie = "Technie.PhysicsCreator";
			output = new Logger(UnityEngine.Debug.unityLogger.logHandler);
			output.logEnabled = false;
		}
	}
	public class AlignedCapsuleFitter
	{
		public CapsuleDef Fit(Hull hull, Vector3[] meshVertices, int[] meshIndices)
		{
			hull.FindConvexHull(meshVertices, meshIndices, out var hullVertices, out var hullIndices, showErrorInLog: false);
			if (hullVertices == null || hullVertices.Length == 0)
			{
				return default(CapsuleDef);
			}
			return Fit(hullVertices, hullIndices);
		}

		public CapsuleDef Fit(Vector3[] hullVertices, int[] hullIndices)
		{
			if (hullVertices == null || hullVertices.Length == 0 || hullIndices == null || hullIndices.Length == 0)
			{
				return default(CapsuleDef);
			}
			RotatedBox rotatedBox = RotatedBoxFitter.FindTightestBox(new ConstructionPlane(Vector3.zero), hullVertices);
			ConstructionPlane constructionPlane;
			CapsuleAxis capsuleDirection;
			if (rotatedBox.size.x > rotatedBox.size.y && rotatedBox.size.x > rotatedBox.size.z)
			{
				constructionPlane = new ConstructionPlane(rotatedBox.center, Vector3.right, Vector3.forward);
				capsuleDirection = CapsuleAxis.X;
			}
			else if (rotatedBox.size.y > rotatedBox.size.z)
			{
				constructionPlane = new ConstructionPlane(rotatedBox.center, Vector3.up, Vector3.right);
				capsuleDirection = CapsuleAxis.Y;
			}
			else
			{
				constructionPlane = new ConstructionPlane(rotatedBox.center, Vector3.forward, Vector3.right);
				capsuleDirection = CapsuleAxis.Z;
			}
			RotatedCapsuleFitter.Refine(RotatedCapsuleFitter.FitCapsule(constructionPlane, hullVertices), constructionPlane, hullVertices, out var bestCapsule, out var _);
			return new CapsuleDef
			{
				capsuleDirection = capsuleDirection,
				capsuleRadius = bestCapsule.radius,
				capsuleHeight = bestCapsule.height,
				capsuleCenter = bestCapsule.center,
				capsulePosition = Vector3.zero,
				capsuleRotation = Quaternion.identity
			};
		}
	}
	public class AxisAlignedBoxFitter
	{
		public void Fit(Hull hull, Vector3[] meshVertices, int[] meshIndices)
		{
			Vector3[] selectedVertices = hull.GetSelectedVertices(meshVertices, meshIndices);
			RotatedBoxFitter.ApplyToHull(RotatedBoxFitter.FindTightestBox(new ConstructionPlane(Vector3.zero, Vector3.up, Vector3.right), selectedVertices), hull);
		}
	}
	public class Pose
	{
		public Vector3 forward;

		public Vector3 up;

		public Vector3 right;
	}
	public class Triangle
	{
		public Vector3 normal;

		public float area;

		public Vector3 center;

		public Triangle(Vector3 p0, Vector3 p1, Vector3 p2)
		{
			Vector3 lhs = p1 - p0;
			Vector3 rhs = p2 - p0;
			Vector3 vector = Vector3.Cross(lhs, rhs);
			area = vector.magnitude * 0.5f;
			normal = vector.normalized;
			center = (p0 + p1 + p2) / 3f;
		}
	}
	public class TriangleBucket
	{
		private List<Triangle> triangles;

		private Vector3 averagedNormal;

		private Vector3 averagedCenter;

		private float totalArea;

		public float Area => totalArea;

		public TriangleBucket(Triangle initialTriangle)
		{
			triangles = new List<Triangle>();
			triangles.Add(initialTriangle);
			CalculateNormal();
			CalcTotalArea();
		}

		public void Add(Triangle t)
		{
			triangles.Add(t);
			CalculateNormal();
			CalcTotalArea();
		}

		public void Add(TriangleBucket otherBucket)
		{
			foreach (Triangle triangle in otherBucket.triangles)
			{
				triangles.Add(triangle);
			}
			CalculateNormal();
			CalcTotalArea();
		}

		private void CalculateNormal()
		{
			averagedNormal = Vector3.zero;
			foreach (Triangle triangle in triangles)
			{
				averagedNormal += triangle.normal * triangle.area;
			}
			averagedNormal.Normalize();
		}

		public Vector3 GetAverageNormal()
		{
			return averagedNormal;
		}

		public Vector3 GetAverageCenter()
		{
			return triangles[0].center;
		}

		private void CalcTotalArea()
		{
			totalArea = 0f;
			foreach (Triangle triangle in triangles)
			{
				totalArea += triangle.area;
			}
		}
	}
	public class TriangleAreaSorter : IComparer<Triangle>
	{
		public int Compare(Triangle lhs, Triangle rhs)
		{
			if (lhs.area < rhs.area)
			{
				return 1;
			}
			if (lhs.area > rhs.area)
			{
				return -1;
			}
			return 0;
		}
	}
	public class TriangleBucketSorter : IComparer<TriangleBucket>
	{
		public int Compare(TriangleBucket lhs, TriangleBucket rhs)
		{
			if (lhs.Area < rhs.Area)
			{
				return 1;
			}
			if (lhs.Area > rhs.Area)
			{
				return -1;
			}
			return 0;
		}
	}
	public class FaceAlignmentBoxFitter
	{
		public void Fit(Hull hull, Vector3[] meshVertices, int[] meshIndices)
		{
			if (meshIndices.Length < 3)
			{
				return;
			}
			List<Triangle> list = hull.FindSelectedTriangles(meshVertices, meshIndices);
			list.Sort(new TriangleAreaSorter());
			List<TriangleBucket> list2 = new List<TriangleBucket>();
			foreach (Triangle item in list)
			{
				TriangleBucket triangleBucket = FindBestBucket(item, 30f, list2);
				if (triangleBucket != null)
				{
					triangleBucket.Add(item);
					continue;
				}
				triangleBucket = new TriangleBucket(item);
				list2.Add(triangleBucket);
			}
			while (list2.Count > 3)
			{
				MergeClosestBuckets(list2);
			}
			list2.Sort(new TriangleBucketSorter());
			Vector3[] selectedVertices = hull.GetSelectedVertices(meshVertices, meshIndices);
			RotatedBoxFitter.ApplyToHull(RotatedBoxFitter.FindTightestBox(CreateConstructionPlane(list2[0], (list2.Count > 1) ? list2[1] : null, (list2.Count > 2) ? list2[2] : null), selectedVertices), hull);
		}

		private TriangleBucket FindBestBucket(Triangle tri, float thresholdAngleDeg, List<TriangleBucket> buckets)
		{
			TriangleBucket result = null;
			float num = float.PositiveInfinity;
			foreach (TriangleBucket bucket in buckets)
			{
				float num2 = Vector3.Angle(tri.normal, bucket.GetAverageNormal());
				if (num2 < thresholdAngleDeg && num2 < num)
				{
					num = num2;
					result = bucket;
					continue;
				}
				float num3 = Vector3.Angle(tri.normal * -1f, bucket.GetAverageNormal());
				if (num3 < thresholdAngleDeg && num3 < num)
				{
					tri.normal *= -1f;
					num = num3;
					result = bucket;
				}
			}
			return result;
		}

		private void MergeClosestBuckets(List<TriangleBucket> buckets)
		{
			TriangleBucket triangleBucket = null;
			TriangleBucket triangleBucket2 = null;
			float num = float.PositiveInfinity;
			for (int i = 0; i < buckets.Count; i++)
			{
				for (int j = i + 1; j < buckets.Count; j++)
				{
					TriangleBucket triangleBucket3 = buckets[i];
					TriangleBucket triangleBucket4 = buckets[j];
					float num2 = Vector3.Angle(triangleBucket3.GetAverageNormal(), triangleBucket4.GetAverageNormal());
					if (num2 < num)
					{
						num = num2;
						triangleBucket = triangleBucket3;
						triangleBucket2 = triangleBucket4;
					}
				}
			}
			if (triangleBucket != null && triangleBucket2 != null)
			{
				buckets.Remove(triangleBucket2);
				triangleBucket.Add(triangleBucket2);
			}
		}

		private ConstructionPlane CreateConstructionPlane(TriangleBucket primaryBucket, TriangleBucket secondaryBucket, TriangleBucket tertiaryBucket)
		{
			if (primaryBucket != null && secondaryBucket != null)
			{
				Vector3 averageNormal = primaryBucket.GetAverageNormal();
				Vector3 t = Vector3.Cross(averageNormal, secondaryBucket.GetAverageNormal());
				return new ConstructionPlane(primaryBucket.GetAverageCenter(), averageNormal, t);
			}
			if (primaryBucket != null)
			{
				Vector3 averageNormal2 = primaryBucket.GetAverageNormal();
				Vector3 averageCenter = primaryBucket.GetAverageCenter();
				Vector3 t2 = Vector3.Cross(averageNormal2, (Vector3.Dot(averageNormal2, Vector3.up) > 0.5f) ? Vector3.right : Vector3.up);
				return new ConstructionPlane(averageCenter, averageNormal2, t2);
			}
			return null;
		}
	}
	public enum BoxFitMethod
	{
		AxisAligned,
		MinimumVolume,
		AlignFaces
	}
	public class ConstructionPlane
	{
		public Vector3 center;

		public Vector3 normal;

		public Vector3 tangent;

		public Quaternion rotation;

		public Matrix4x4 planeToWorld;

		public Matrix4x4 worldToPlane;

		public ConstructionPlane(Vector3 c)
		{
			center = c;
			normal = Vector3.forward;
			tangent = Vector3.up;
			Init();
		}

		public ConstructionPlane(Vector3 c, Vector3 n, Vector3 t)
		{
			center = c;
			normal = n;
			tangent = t;
			Init();
		}

		public ConstructionPlane(ConstructionPlane basePlane, float angle)
		{
			Vector3 vector = Quaternion.AngleAxis(angle, basePlane.normal) * basePlane.tangent;
			center = basePlane.center;
			normal = basePlane.normal;
			tangent = vector;
			Init();
		}

		public ConstructionPlane(ConstructionPlane basePlane, Vector3 positionOffset)
		{
			center = basePlane.center + positionOffset;
			normal = basePlane.normal;
			tangent = basePlane.tangent;
			Init();
		}

		private void Init()
		{
			if (normal.magnitude < 0.01f)
			{
				UnityEngine.Debug.LogError("!");
			}
			rotation = Quaternion.LookRotation(normal, tangent);
			planeToWorld = Matrix4x4.TRS(center, rotation, Vector3.one);
			worldToPlane = planeToWorld.inverse;
		}
	}
	public class RotatedBox
	{
		public ConstructionPlane plane;

		public Vector3 localCenter;

		public Vector3 center;

		public Vector3 size;

		public float volume;

		public float VolumeCm3 => volume * 1000000f;

		public RotatedBox(ConstructionPlane p, Vector3 localCenter, Vector3 c, Vector3 s)
		{
			plane = p;
			this.localCenter = localCenter;
			center = c;
			size = s;
			volume = size.x * size.y * size.z;
		}

		public void DrawWireframe()
		{
			Gizmos.matrix = Matrix4x4.TRS(center, plane.rotation, Vector3.one);
			Gizmos.DrawWireCube(Vector3.zero, size);
			Gizmos.matrix = Matrix4x4.identity;
		}
	}
	public class VolumeSorter : IComparer<RotatedBox>
	{
		public int Compare(RotatedBox lhs, RotatedBox rhs)
		{
			if (Mathf.Approximately(lhs.volume, rhs.volume))
			{
				return 0;
			}
			if (lhs.volume > rhs.volume)
			{
				return 1;
			}
			return -1;
		}
	}
	public class RotatedBoxFitter
	{
		public BoxDef Fit(Hull hull, Vector3[] meshVertices, int[] meshIndices)
		{
			hull.FindConvexHull(meshVertices, meshIndices, out var hullVertices, out var hullIndices, showErrorInLog: false);
			if (hullVertices == null || hullVertices.Length == 0)
			{
				hull.FindTriangles(meshVertices, meshIndices, out hullVertices, out hullIndices);
			}
			return Fit(hullVertices, hullIndices);
		}

		public BoxDef Fit(Vector3[] hullVertices, int[] hullIndices)
		{
			List<ConstructionPlane> list = new List<ConstructionPlane>();
			int num = 64;
			int numVariants = 128;
			float angleRange = 360f / (float)num;
			list.Add(new ConstructionPlane(Vector3.zero));
			for (int i = 0; i < hullIndices.Length; i += 3)
			{
				int num2 = hullIndices[i];
				int num3 = hullIndices[i + 1];
				int num4 = hullIndices[i + 2];
				Vector3 vector = hullVertices[num2];
				Vector3 vector2 = hullVertices[num3];
				Vector3 vector3 = hullVertices[num4];
				Vector3 c = (vector + vector2 + vector3) / 3f;
				Vector3 vector4 = Vector3.Cross((vector2 - vector).normalized, (vector3 - vector).normalized);
				Vector3 rhs = ((Mathf.Abs(Vector3.Dot(vector4, Vector3.up)) > 0.9f) ? Vector3.right : Vector3.up);
				Vector3 t = Vector3.Cross(vector4, rhs);
				if (vector4.magnitude > 0.0001f)
				{
					ConstructionPlane basePlane = new ConstructionPlane(c, vector4, t);
					for (int j = 0; j < num; j++)
					{
						float angle = (float)j / (float)(num - 1) * 360f;
						ConstructionPlane item = new ConstructionPlane(basePlane, angle);
						list.Add(item);
					}
				}
			}
			List<RotatedBox> list2 = FindTightestBoxes(list, hullVertices);
			if (list2.Count > 0)
			{
				list2.Sort(new VolumeSorter());
				_ = list2[0];
				List<ConstructionPlane> list3 = new List<ConstructionPlane>();
				GeneratePlaneVariants(list2[0].plane, numVariants, angleRange, list3);
				List<RotatedBox> list4 = FindTightestBoxes(list3, hullVertices);
				list4.Sort(new VolumeSorter());
				RotatedBox rotatedBox = list4[0];
				UnifyOffsets(rotatedBox);
				return ToBoxDef(rotatedBox);
			}
			UnityEngine.Debug.LogError("Couldn't fit box rotation to hull");
			return default(BoxDef);
		}

		private static void GeneratePlaneVariants(ConstructionPlane basePlane, int numVariants, float angleRange, List<ConstructionPlane> variantPlanes)
		{
			variantPlanes.Add(basePlane);
			for (int i = 0; i < numVariants; i++)
			{
				float t = (float)i / (float)(numVariants - 1);
				float angle = Mathf.Lerp(0f - angleRange, angleRange, t);
				variantPlanes.Add(new ConstructionPlane(basePlane, angle));
			}
		}

		private static void UnifyOffsets(RotatedBox inputBox)
		{
			Vector3 vector = inputBox.plane.rotation * inputBox.localCenter;
			inputBox.plane.center += vector;
			inputBox.localCenter = Vector3.zero;
		}

		public static BoxDef ToBoxDef(RotatedBox computedBox)
		{
			return new BoxDef
			{
				boxPosition = computedBox.plane.center,
				boxRotation = computedBox.plane.rotation,
				collisionBox = 
				{
					center = computedBox.localCenter,
					size = computedBox.size
				}
			};
		}

		public static void ApplyToHull(RotatedBox computedBox, Hull targetHull)
		{
			targetHull.collisionBox = ToBoxDef(computedBox);
		}

		private static List<RotatedBox> FindTightestBoxes(List<ConstructionPlane> planes, Vector3[] inputVertices)
		{
			if (inputVertices == null || inputVertices.Length == 0)
			{
				return new List<RotatedBox>();
			}
			List<RotatedBox> list = new List<RotatedBox>();
			foreach (ConstructionPlane plane in planes)
			{
				RotatedBox item = FindTightestBox(plane, inputVertices);
				list.Add(item);
			}
			return list;
		}

		public static RotatedBox FindTightestBox(ConstructionPlane plane, Vector3[] inputVertices)
		{
			if (inputVertices == null || inputVertices.Length == 0)
			{
				return null;
			}
			Vector3 vector2;
			Vector3 vector = (vector2 = plane.worldToPlane.MultiplyPoint(inputVertices[0]));
			foreach (Vector3 point in inputVertices)
			{
				Vector3 lhs = plane.worldToPlane.MultiplyPoint(point);
				vector = Vector3.Min(lhs, vector);
				vector2 = Vector3.Max(lhs, vector2);
			}
			Vector3 vector3 = Vector3.Lerp(vector, vector2, 0.5f);
			Vector3 c = plane.planeToWorld.MultiplyPoint(vector3);
			Vector3 s = vector2 - vector;
			return new RotatedBox(plane, vector3, c, s);
		}
	}
	public struct RotatedCapsule
	{
		public Vector3 center;

		public Vector3 dir;

		public float radius;

		public float height;

		public float CalcVolume()
		{
			float num = Mathf.Max(height - radius * 2f, 0f);
			return MathF.PI * (radius * radius) * (1.3333334f * radius * num);
		}

		public void DrawWireframe()
		{
			Vector3 vector = center - dir * Mathf.Max(height * 0.5f - radius, 0f);
			Vector3 vector2 = center + dir * Mathf.Max(height * 0.5f - radius, 0f);
			float num = (vector2 - vector).magnitude * 0.5f;
			Vector3 vector3 = Vector3.Cross(dir, (Mathf.Abs(Vector3.Dot(dir, Vector3.up)) > 0.9f) ? Vector3.right : Vector3.up);
			Vector3 vector4 = Vector3.Cross(dir, vector3);
			Gizmos.DrawWireSphere(vector, radius);
			Gizmos.DrawWireSphere(vector2, radius);
			Gizmos.DrawLine(center + vector3 * radius - dir * num, center + vector3 * radius + dir * num);
			Gizmos.DrawLine(center - vector3 * radius - dir * num, center - vector3 * radius + dir * num);
			Gizmos.DrawLine(center + vector4 * radius - dir * num, center + vector4 * radius + dir * num);
			Gizmos.DrawLine(center - vector4 * radius - dir * num, center - vector4 * radius + dir * num);
		}
	}
	public class RotatedCapsuleFitter
	{
		public CapsuleDef Fit(Hull hull, Vector3[] meshVertices, int[] meshIndices)
		{
			hull.FindConvexHull(meshVertices, meshIndices, out var hullVertices, out var hullIndices, showErrorInLog: false);
			if (hullVertices == null || hullVertices.Length == 0)
			{
				return default(CapsuleDef);
			}
			ConstructionPlane constructionPlane = FindBestCapsulePlane(hullVertices, hullIndices);
			Refine(FitCapsule(constructionPlane, hullVertices), constructionPlane, hullVertices, out var bestCapsule, out var bestPlane);
			return ToDef(bestCapsule, bestPlane);
		}

		public CapsuleDef Fit(Vector3[] hullVertices, int[] hullIndices)
		{
			if (hullVertices == null || hullVertices.Length == 0 || hullIndices == null || hullIndices.Length == 0)
			{
				return default(CapsuleDef);
			}
			ConstructionPlane constructionPlane = FindBestCapsulePlane(hullVertices, hullIndices);
			Refine(FitCapsule(constructionPlane, hullVertices), constructionPlane, hullVertices, out var bestCapsule, out var bestPlane);
			return ToDef(bestCapsule, bestPlane);
		}

		public ConstructionPlane FindBestCapsulePlane(Vector3[] hullVertices, int[] hullIndices)
		{
			BoxDef boxDef = new RotatedBoxFitter().Fit(hullVertices, hullIndices);
			Vector3 c = boxDef.boxPosition + boxDef.boxRotation * boxDef.collisionBox.center;
			if (boxDef.collisionBox.size.x > boxDef.collisionBox.size.y && boxDef.collisionBox.size.x > boxDef.collisionBox.size.z)
			{
				return new ConstructionPlane(c, boxDef.boxRotation * Vector3.right, boxDef.boxRotation * Vector3.forward);
			}
			if (boxDef.collisionBox.size.y > boxDef.collisionBox.size.z)
			{
				return new ConstructionPlane(c, boxDef.boxRotation * Vector3.up, boxDef.boxRotation * Vector3.right);
			}
			return new ConstructionPlane(c, boxDef.boxRotation * Vector3.forward, boxDef.boxRotation * Vector3.right);
		}

		public static CapsuleDef ToDef(RotatedCapsule capsule, ConstructionPlane plane)
		{
			return new CapsuleDef
			{
				capsuleCenter = Vector3.zero,
				capsuleDirection = CapsuleAxis.Z,
				capsuleRadius = capsule.radius,
				capsuleHeight = capsule.height,
				capsulePosition = plane.center,
				capsuleRotation = plane.rotation
			};
		}

		public static void Refine(RotatedCapsule inputCapule, ConstructionPlane inputPlane, Vector3[] hullVertices, out RotatedCapsule bestCapsule, out ConstructionPlane bestPlane)
		{
			bestPlane = inputPlane;
			bestCapsule = inputCapule;
			System.Random random = new System.Random(1234);
			int num = 1024;
			for (int i = 0; i < num; i++)
			{
				float magnitude = Mathf.Min(bestCapsule.height, bestCapsule.radius) * 0.01f;
				ConstructionPlane constructionPlane = new ConstructionPlane(bestPlane, new Vector3(Jitter(magnitude, random), Jitter(magnitude, random), Jitter(magnitude, random)));
				RotatedCapsule rotatedCapsule = FitCapsule(constructionPlane, hullVertices);
				if (rotatedCapsule.CalcVolume() < bestCapsule.CalcVolume())
				{
					bestCapsule = rotatedCapsule;
					bestPlane = constructionPlane;
				}
			}
		}

		private static float Jitter(float magnitude, System.Random random)
		{
			return (float)(random.NextDouble() * (double)(magnitude * 2f) - (double)magnitude);
		}

		public static RotatedCapsule FitCapsule(ConstructionPlane plane, Vector3[] points)
		{
			RotatedCapsule result = new RotatedCapsule
			{
				center = plane.center,
				dir = plane.normal
			};
			foreach (Vector3 vector in points)
			{
				Vector3 vector2 = ProjectOntoAxis(plane, vector);
				float b = Vector3.Distance(vector2, vector);
				float num = Vector3.Distance(plane.center, vector2);
				result.radius = Mathf.Max(result.radius, b);
				result.height = Mathf.Max(result.height, num * 2f);
			}
			return result;
		}

		private static Vector3 ProjectOntoAxis(ConstructionPlane plane, Vector3 point)
		{
			Vector3 rhs = point - plane.center;
			float num = Vector3.Dot(plane.normal, rhs);
			return plane.center + plane.normal * num;
		}

		public static Vector3 FindCenter(Vector3[] vertices)
		{
			if (vertices == null || vertices.Length == 0)
			{
				return Vector3.zero;
			}
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < vertices.Length; i++)
			{
				zero += vertices[i];
			}
			return zero / vertices.Length;
		}
	}
	public class SphereFitter
	{
		public Sphere Fit(Hull hull, Vector3[] meshVertices, int[] meshIndices)
		{
			Sphere sphere = new Sphere();
			if (CalculateBoundingSphere(hull, meshVertices, meshIndices, out var sphereCenter, out var sphereRadius))
			{
				sphere.center = sphereCenter;
				sphere.radius = sphereRadius;
			}
			else
			{
				sphere.center = Vector3.zero;
				sphere.radius = 0f;
			}
			return sphere;
		}

		public Sphere Fit(Vector3[] hullVertices, int[] hullIndices)
		{
			if (hullVertices == null || hullVertices.Length == 0)
			{
				return new Sphere();
			}
			return SphereUtils.MinSphere(new List<Vector3>(hullVertices));
		}

		private bool CalculateBoundingSphere(Hull hull, Vector3[] meshVertices, int[] meshIndices, out Vector3 sphereCenter, out float sphereRadius)
		{
			int[] selectedFaces = hull.GetSelectedFaces();
			if (selectedFaces.Length == 0)
			{
				sphereCenter = Vector3.zero;
				sphereRadius = 0f;
				return false;
			}
			List<Vector3> list = new List<Vector3>();
			foreach (int num in selectedFaces)
			{
				Vector3 item = meshVertices[meshIndices[num * 3]];
				Vector3 item2 = meshVertices[meshIndices[num * 3 + 1]];
				Vector3 item3 = meshVertices[meshIndices[num * 3 + 2]];
				list.Add(item);
				list.Add(item2);
				list.Add(item3);
			}
			Sphere sphere = SphereUtils.MinSphere(list);
			sphereCenter = sphere.center;
			sphereRadius = sphere.radius;
			return true;
		}
	}
	public class GizmoUtils
	{
		public static readonly Color[] HULL_COLOURS = new Color[12]
		{
			new Color(0f, 1f, 1f, 0.7f),
			new Color(1f, 0f, 1f, 0.7f),
			new Color(1f, 1f, 0f, 0.7f),
			new Color(1f, 0f, 0f, 0.7f),
			new Color(0f, 1f, 0f, 0.7f),
			new Color(0f, 0f, 1f, 0.7f),
			new Color(1f, 0.5f, 0f, 0.7f),
			new Color(1f, 0f, 0.5f, 0.7f),
			new Color(0.5f, 1f, 0f, 0.7f),
			new Color(0f, 1f, 0.5f, 0.7f),
			new Color(0.5f, 0f, 1f, 0.7f),
			new Color(0f, 0.5f, 1f, 0.7f)
		};

		public static Color GetHullColour(int index)
		{
			return HULL_COLOURS[index % HULL_COLOURS.Length];
		}

		public static void ToggleGizmos(bool gizmosOn)
		{
		}
	}
	[Serializable]
	public class Hash160
	{
		public byte[] data;

		public Hash160()
		{
			data = new byte[0];
		}

		public Hash160(byte[] data)
		{
			this.data = data;
		}

		public bool IsValid()
		{
			if (data != null)
			{
				return data.Length != 0;
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (data == null)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < data.Length; i += 4)
			{
				num |= data[i + 1];
				num |= data[i + 1] << 8;
				num |= data[i + 1] << 16;
				num |= data[i + 1] << 24;
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			Hash160 hash = obj as Hash160;
			if (hash == null)
			{
				return false;
			}
			if (data == hash.data)
			{
				return true;
			}
			if (data == null || hash.data == null)
			{
				return false;
			}
			if (data.Length != hash.data.Length)
			{
				return false;
			}
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] != hash.data[i])
				{
					return false;
				}
			}
			return true;
		}

		public static bool operator ==(Hash160 lhs, Hash160 rhs)
		{
			if ((object)lhs == null)
			{
				if ((object)rhs == null)
				{
					return true;
				}
				return false;
			}
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Hash160 lhs, Hash160 rhs)
		{
			return !(lhs == rhs);
		}
	}
	public class HashUtil
	{
		public static Hash160 CalcHash(Mesh srcMesh)
		{
			if (srcMesh == null)
			{
				return new Hash160();
			}
			DateTime now = DateTime.Now;
			HashAlgorithm hashAlgorithm = SHA1.Create();
			Vector3[] vertices = srcMesh.vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				byte[] array = ToBytes(vertices[i]);
				hashAlgorithm.TransformBlock(array, 0, array.Length, null, 0);
			}
			for (int j = 0; j < srcMesh.subMeshCount; j++)
			{
				int[] triangles = srcMesh.GetTriangles(j);
				for (int k = 0; k < triangles.Length; k++)
				{
					byte[] bytes = BitConverter.GetBytes(triangles[k]);
					hashAlgorithm.TransformBlock(bytes, 0, bytes.Length, null, 0);
				}
			}
			hashAlgorithm.TransformFinalBlock(new byte[0], 0, 0);
			byte[] hash = hashAlgorithm.Hash;
			_ = (DateTime.Now - now).TotalSeconds;
			return new Hash160(hash);
		}

		public static Hash160 CalcHash(string input)
		{
			SHA1 sHA = SHA1.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			sHA.TransformFinalBlock(bytes, 0, bytes.Length);
			return new Hash160(sHA.Hash);
		}

		private static byte[] ToBytes(Vector3 vec)
		{
			byte[] array = new byte[12];
			byte[] bytes = BitConverter.GetBytes(vec.x);
			byte[] bytes2 = BitConverter.GetBytes(vec.x);
			byte[] bytes3 = BitConverter.GetBytes(vec.x);
			bytes.CopyTo(array, 0);
			bytes2.CopyTo(array, 4);
			bytes3.CopyTo(array, 8);
			return array;
		}
	}
	public interface ICreatorComponent
	{
		GameObject GetGameObject();

		bool HasEditorData();

		IEditorData GetEditorData();
	}
	public interface IEditorData
	{
		bool HasCachedData { get; }

		Mesh SourceMesh { get; }

		Hash160 CachedHash { get; set; }

		IHull[] Hulls { get; }

		bool HasSuppressMeshModificationWarning { get; }

		void SetAssetDirty();
	}
	public interface IHull
	{
		string Name { get; }

		Vector3[] CachedTriangleVertices { get; set; }

		int NumSelectedTriangles { get; }

		bool IsTriangleSelected(int triIndex, Renderer renderer, Mesh targetMesh);

		int[] GetSelectedFaces();

		void ClearSelectedFaces();

		void SetSelectedFaces(List<int> newSelectedFaceIndices, Mesh srcMesh);
	}
	public class CuttableMesh
	{
		private MeshRenderer inputMeshRenderer;

		private bool hasUvs;

		private bool hasUv1s;

		private bool hasColours;

		private List<CuttableSubMesh> subMeshes;

		public CuttableMesh(Mesh inputMesh)
		{
			Init(inputMesh, inputMesh.name);
		}

		public CuttableMesh(MeshRenderer input)
		{
			inputMeshRenderer = input;
			Mesh sharedMesh = input.GetComponent<MeshFilter>().sharedMesh;
			Init(sharedMesh, input.name);
		}

		private void Init(Mesh inputMesh, string debugName)
		{
			subMeshes = new List<CuttableSubMesh>();
			if (inputMesh.isReadable)
			{
				Vector3[] vertices = inputMesh.vertices;
				Vector3[] normals = inputMesh.normals;
				Vector2[] uv = inputMesh.uv;
				Vector2[] uv2 = inputMesh.uv2;
				Color32[] colors = inputMesh.colors32;
				hasUvs = uv != null && uv.Length != 0;
				hasUv1s = uv2 != null && uv2.Length != 0;
				hasColours = colors != null && colors.Length != 0;
				for (int i = 0; i < inputMesh.subMeshCount; i++)
				{
					CuttableSubMesh item = new CuttableSubMesh(inputMesh.GetIndices(i), vertices, normals, colors, uv, uv2);
					subMeshes.Add(item);
				}
			}
			else
			{
				UnityEngine.Debug.LogError("CuttableMesh's input mesh is not readable: " + debugName, inputMesh);
			}
		}

		public CuttableMesh(CuttableMesh inputMesh, List<CuttableSubMesh> newSubMeshes)
		{
			inputMeshRenderer = inputMesh.inputMeshRenderer;
			hasUvs = inputMesh.hasUvs;
			hasUv1s = inputMesh.hasUv1s;
			hasColours = inputMesh.hasColours;
			subMeshes = new List<CuttableSubMesh>();
			subMeshes.AddRange(newSubMeshes);
		}

		public void Add(CuttableMesh other)
		{
			if (subMeshes.Count != other.subMeshes.Count)
			{
				throw new Exception("Mismatched submesh count");
			}
			for (int i = 0; i < subMeshes.Count; i++)
			{
				subMeshes[i].Add(other.subMeshes[i]);
			}
		}

		public int NumSubMeshes()
		{
			return subMeshes.Count;
		}

		public bool HasUvs()
		{
			return hasUvs;
		}

		public bool HasColours()
		{
			return hasColours;
		}

		public List<CuttableSubMesh> GetSubMeshes()
		{
			return subMeshes;
		}

		public CuttableSubMesh GetSubMesh(int index)
		{
			return subMeshes[index];
		}

		public Transform GetTransform()
		{
			if (inputMeshRenderer != null)
			{
				return inputMeshRenderer.transform;
			}
			return null;
		}

		public MeshRenderer ConvertToRenderer(string newObjectName)
		{
			Mesh mesh = CreateMesh();
			if (mesh.vertexCount == 0)
			{
				return null;
			}
			GameObject gameObject = new GameObject(newObjectName);
			gameObject.transform.SetParent(inputMeshRenderer.transform);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = Vector3.one;
			gameObject.AddComponent<MeshFilter>().mesh = mesh;
			MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
			meshRenderer.shadowCastingMode = inputMeshRenderer.shadowCastingMode;
			meshRenderer.reflectionProbeUsage = inputMeshRenderer.reflectionProbeUsage;
			meshRenderer.lightProbeUsage = inputMeshRenderer.lightProbeUsage;
			meshRenderer.sharedMaterials = inputMeshRenderer.sharedMaterials;
			return meshRenderer;
		}

		public Mesh CreateMesh()
		{
			Mesh mesh = new Mesh();
			int num = 0;
			for (int i = 0; i < subMeshes.Count; i++)
			{
				num += subMeshes[i].NumIndices();
			}
			mesh.indexFormat = ((num > 65535) ? IndexFormat.UInt32 : IndexFormat.UInt16);
			List<Vector3> list = new List<Vector3>();
			List<Vector3> list2 = new List<Vector3>();
			List<Color32> list3 = (hasColours ? new List<Color32>() : null);
			List<Vector2> list4 = (hasUvs ? new List<Vector2>() : null);
			List<Vector2> list5 = (hasUv1s ? new List<Vector2>() : null);
			List<int> list6 = new List<int>();
			foreach (CuttableSubMesh subMesh in subMeshes)
			{
				list6.Add(list.Count);
				subMesh.AddTo(list, list2, list3, list4, list5);
			}
			mesh.vertices = list.ToArray();
			mesh.normals = list2.ToArray();
			mesh.colors32 = (hasColours ? list3.ToArray() : null);
			mesh.uv = (hasUvs ? list4.ToArray() : null);
			mesh.uv2 = (hasUv1s ? list5.ToArray() : null);
			mesh.subMeshCount = subMeshes.Count;
			for (int j = 0; j < subMeshes.Count; j++)
			{
				CuttableSubMesh cuttableSubMesh = subMeshes[j];
				int baseVertex = list6[j];
				int[] triangles = cuttableSubMesh.GenIndices();
				mesh.SetTriangles(triangles, j, calculateBounds: true, baseVertex);
			}
			return mesh;
		}
	}
	public class CuttableSubMesh
	{
		private List<Vector3> vertices;

		private List<Vector3> normals;

		private List<Color32> colours;

		private List<Vector2> uvs;

		private List<Vector2> uv1s;

		public CuttableSubMesh(bool hasNormals, bool hasColours, bool hasUvs, bool hasUv1)
		{
			vertices = new List<Vector3>();
			if (hasNormals)
			{
				normals = new List<Vector3>();
			}
			if (hasColours)
			{
				colours = new List<Color32>();
			}
			if (hasUvs)
			{
				uvs = new List<Vector2>();
			}
			if (hasUv1)
			{
				uv1s = new List<Vector2>();
			}
		}

		public CuttableSubMesh(int[] indices, Vector3[] inputVertices, Vector3[] inputNormals, Color32[] inputColours, Vector2[] inputUvs, Vector2[] inputUv1)
		{
			vertices = new List<Vector3>();
			if (inputNormals != null && inputNormals.Length != 0)
			{
				normals = new List<Vector3>();
			}
			if (inputColours != null && inputColours.Length != 0)
			{
				colours = new List<Color32>();
			}
			if (inputUvs != null && inputUvs.Length != 0)
			{
				uvs = new List<Vector2>();
			}
			if (inputUv1 != null && inputUv1.Length != 0)
			{
				uv1s = new List<Vector2>();
			}
			foreach (int num in indices)
			{
				vertices.Add(inputVertices[num]);
				if (normals != null)
				{
					normals.Add(inputNormals[num]);
				}
				if (colours != null)
				{
					colours.Add(inputColours[num]);
				}
				if (uvs != null)
				{
					uvs.Add(inputUvs[num]);
				}
				if (uv1s != null)
				{
					uv1s.Add(inputUv1[num]);
				}
			}
		}

		public void Add(CuttableSubMesh other)
		{
			for (int i = 0; i < other.vertices.Count; i++)
			{
				CopyVertex(i, other);
			}
		}

		public int NumVertices()
		{
			return vertices.Count;
		}

		public Vector3 GetVertex(int index)
		{
			return vertices[index];
		}

		public bool HasNormals()
		{
			return normals != null;
		}

		public bool HasColours()
		{
			return colours != null;
		}

		public bool HasUvs()
		{
			return uvs != null;
		}

		public bool HasUv1()
		{
			return uv1s != null;
		}

		public void CopyVertex(int srcIndex, CuttableSubMesh srcMesh)
		{
			vertices.Add(srcMesh.vertices[srcIndex]);
			if (normals != null)
			{
				normals.Add(srcMesh.normals[srcIndex]);
			}
			if (colours != null)
			{
				colours.Add(srcMesh.colours[srcIndex]);
			}
			if (uvs != null)
			{
				uvs.Add(srcMesh.uvs[srcIndex]);
			}
			if (uv1s != null)
			{
				uv1s.Add(srcMesh.uv1s[srcIndex]);
			}
		}

		public void AddInterpolatedVertex(int i0, int i1, float weight, CuttableSubMesh srcMesh)
		{
			Vector3 vertex = srcMesh.GetVertex(i0);
			Vector3 vertex2 = srcMesh.GetVertex(i1);
			vertices.Add(Vector3.Lerp(vertex, vertex2, weight));
			if (normals != null)
			{
				normals.Add(Vector3.Lerp(srcMesh.normals[i0], srcMesh.normals[i1], weight).normalized);
			}
			if (colours != null)
			{
				colours.Add(Color32.Lerp(srcMesh.colours[i0], srcMesh.colours[i1], weight));
			}
			if (uvs != null)
			{
				uvs.Add(Vector2.Lerp(srcMesh.uvs[i0], srcMesh.uvs[i1], weight));
			}
			if (uv1s != null)
			{
				uv1s.Add(Vector2.Lerp(srcMesh.uv1s[i0], srcMesh.uv1s[i1], weight));
			}
		}

		public void AddTo(List<Vector3> destVertices, List<Vector3> destNormals, List<Color32> destColours, List<Vector2> destUvs, List<Vector2> destUv1s)
		{
			destVertices.AddRange(vertices);
			if (normals != null)
			{
				destNormals.AddRange(normals);
			}
			if (colours != null)
			{
				destColours.AddRange(colours);
			}
			if (uvs != null)
			{
				destUvs.AddRange(uvs);
			}
			if (uv1s != null)
			{
				destUv1s.AddRange(uv1s);
			}
		}

		public int NumIndices()
		{
			return vertices.Count;
		}

		public int[] GenIndices()
		{
			int[] array = new int[vertices.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = i;
			}
			return array;
		}
	}
	public enum VertexClassification
	{
		Front = 1,
		Back = 2,
		OnPlane = 4
	}
	public class MeshCutter
	{
		private CuttableMesh inputMesh;

		private List<CuttableSubMesh> outputFrontSubMeshes;

		private List<CuttableSubMesh> outputBackSubMeshes;

		public void Cut(CuttableMesh input, Plane worldCutPlane)
		{
			inputMesh = input;
			outputFrontSubMeshes = new List<CuttableSubMesh>();
			outputBackSubMeshes = new List<CuttableSubMesh>();
			Transform transform = inputMesh.GetTransform();
			Plane cutPlane;
			if (transform != null)
			{
				Vector3 inPoint = transform.InverseTransformPoint(ClosestPointOnPlane(worldCutPlane, Vector3.zero));
				Vector3 inNormal = transform.InverseTransformDirection(worldCutPlane.normal);
				cutPlane = new Plane(inNormal, inPoint);
			}
			else
			{
				cutPlane = worldCutPlane;
			}
			foreach (CuttableSubMesh subMesh in input.GetSubMeshes())
			{
				Cut(subMesh, cutPlane);
			}
		}

		private static Vector3 ClosestPointOnPlane(Plane plane, Vector3 point)
		{
			return plane.ClosestPointOnPlane(point);
		}

		public CuttableMesh GetFrontOutput()
		{
			return new CuttableMesh(inputMesh, outputFrontSubMeshes);
		}

		public CuttableMesh GetBackOutput()
		{
			return new CuttableMesh(inputMesh, outputBackSubMeshes);
		}

		private void Cut(CuttableSubMesh inputSubMesh, Plane cutPlane)
		{
			bool hasNormals = inputSubMesh.HasNormals();
			bool hasColours = inputSubMesh.HasColours();
			bool hasUvs = inputSubMesh.HasUvs();
			bool hasUv = inputSubMesh.HasUv1();
			CuttableSubMesh cuttableSubMesh = new CuttableSubMesh(hasNormals, hasColours, hasUvs, hasUv);
			CuttableSubMesh cuttableSubMesh2 = new CuttableSubMesh(hasNormals, hasColours, hasUvs, hasUv);
			for (int i = 0; i < inputSubMesh.NumVertices(); i += 3)
			{
				int num = i;
				int num2 = i + 1;
				int num3 = i + 2;
				Vector3 vertex = inputSubMesh.GetVertex(num);
				Vector3 vertex2 = inputSubMesh.GetVertex(num2);
				Vector3 vertex3 = inputSubMesh.GetVertex(num3);
				VertexClassification vertexClassification = Classify(vertex, cutPlane);
				VertexClassification vertexClassification2 = Classify(vertex2, cutPlane);
				VertexClassification vertexClassification3 = Classify(vertex3, cutPlane);
				int numFront = 0;
				int numBehind = 0;
				CountSides(vertexClassification, ref numFront, ref numBehind);
				CountSides(vertexClassification2, ref numFront, ref numBehind);
				CountSides(vertexClassification3, ref numFront, ref numBehind);
				if (numFront > 0 && numBehind == 0)
				{
					KeepTriangle(num, num2, num3, inputSubMesh, cuttableSubMesh);
				}
				else if (numFront == 0 && numBehind > 0)
				{
					KeepTriangle(num, num2, num3, inputSubMesh, cuttableSubMesh2);
				}
				else if (numFront == 2 && numBehind == 1)
				{
					if (vertexClassification == VertexClassification.Back)
					{
						SplitA(num, num2, num3, inputSubMesh, cutPlane, cuttableSubMesh2, cuttableSubMesh);
					}
					else if (vertexClassification2 == VertexClassification.Back)
					{
						SplitA(num2, num3, num, inputSubMesh, cutPlane, cuttableSubMesh2, cuttableSubMesh);
					}
					else
					{
						SplitA(num3, num, num2, inputSubMesh, cutPlane, cuttableSubMesh2, cuttableSubMesh);
					}
				}
				else if (numFront == 1 && numBehind == 2)
				{
					if (vertexClassification == VertexClassification.Front)
					{
						SplitA(num, num2, num3, inputSubMesh, cutPlane, cuttableSubMesh, cuttableSubMesh2);
					}
					else if (vertexClassification2 == VertexClassification.Front)
					{
						SplitA(num2, num3, num, inputSubMesh, cutPlane, cuttableSubMesh, cuttableSubMesh2);
					}
					else
					{
						SplitA(num3, num, num2, inputSubMesh, cutPlane, cuttableSubMesh, cuttableSubMesh2);
					}
				}
				else if (numFront == 1 && numBehind == 1)
				{
					if (vertexClassification == VertexClassification.OnPlane)
					{
						if (vertexClassification3 == VertexClassification.Front)
						{
							SplitB(num3, num, num2, inputSubMesh, cutPlane, cuttableSubMesh, cuttableSubMesh2);
						}
						else
						{
							SplitBFlipped(num2, num3, num, inputSubMesh, cutPlane, cuttableSubMesh, cuttableSubMesh2);
						}
						continue;
					}
					switch (vertexClassification2)
					{
					case VertexClassification.OnPlane:
						if (vertexClassification == VertexClassification.Front)
						{
							SplitB(num, num2, num3, inputSubMesh, cutPlane, cuttableSubMesh, cuttableSubMesh2);
						}
						else
						{
							SplitBFlipped(num3, num, num2, inputSubMesh, cutPlane, cuttableSubMesh, cuttableSubMesh2);
						}
						break;
					case VertexClassification.Front:
						SplitB(num2, num3, num, inputSubMesh, cutPlane, cuttableSubMesh, cuttableSubMesh2);
						break;
					default:
						SplitBFlipped(num, num2, num3, inputSubMesh, cutPlane, cuttableSubMesh, cuttableSubMesh2);
						break;
					}
				}
				else if (numFront == 0 && numBehind == 0)
				{
					Vector3 lhs = vertex2 - vertex;
					Vector3 rhs = vertex3 - vertex;
					if (Vector3.Dot(Vector3.Cross(lhs, rhs), cutPlane.normal) > 0f)
					{
						KeepTriangle(num, num2, num3, inputSubMesh, cuttableSubMesh2);
					}
					else
					{
						KeepTriangle(num, num2, num3, inputSubMesh, cuttableSubMesh);
					}
				}
			}
			outputFrontSubMeshes.Add(cuttableSubMesh);
			outputBackSubMeshes.Add(cuttableSubMesh2);
		}

		private VertexClassification Classify(Vector3 vertex, Plane cutPlane)
		{
			Vector3 point = new Vector3(vertex.x, vertex.y, vertex.z);
			float distanceToPoint = cutPlane.GetDistanceToPoint(point);
			double num = 9.999999747378752E-06;
			if ((double)distanceToPoint > 0.0 - num && (double)distanceToPoint < num)
			{
				return VertexClassification.OnPlane;
			}
			if (distanceToPoint > 0f)
			{
				return VertexClassification.Front;
			}
			return VertexClassification.Back;
		}

		private void CountSides(VertexClassification c, ref int numFront, ref int numBehind)
		{
			switch (c)
			{
			case VertexClassification.Front:
				numFront++;
				break;
			case VertexClassification.Back:
				numBehind++;
				break;
			}
		}

		private void KeepTriangle(int i0, int i1, int i2, CuttableSubMesh inputSubMesh, CuttableSubMesh destSubMesh)
		{
			destSubMesh.CopyVertex(i0, inputSubMesh);
			destSubMesh.CopyVertex(i1, inputSubMesh);
			destSubMesh.CopyVertex(i2, inputSubMesh);
		}

		private void SplitA(int i0, int i1, int i2, CuttableSubMesh inputSubMesh, Plane cutPlane, CuttableSubMesh frontSubMesh, CuttableSubMesh backSubMesh)
		{
			Vector3 vertex = inputSubMesh.GetVertex(i0);
			Vector3 vertex2 = inputSubMesh.GetVertex(i1);
			Vector3 vertex3 = inputSubMesh.GetVertex(i2);
			CalcIntersection(vertex, vertex2, cutPlane, out var weight);
			CalcIntersection(vertex3, vertex, cutPlane, out var weight2);
			frontSubMesh.CopyVertex(i0, inputSubMesh);
			frontSubMesh.AddInterpolatedVertex(i0, i1, weight, inputSubMesh);
			frontSubMesh.AddInterpolatedVertex(i2, i0, weight2, inputSubMesh);
			backSubMesh.AddInterpolatedVertex(i0, i1, weight, inputSubMesh);
			backSubMesh.CopyVertex(i1, inputSubMesh);
			backSubMesh.CopyVertex(i2, inputSubMesh);
			backSubMesh.CopyVertex(i2, inputSubMesh);
			backSubMesh.AddInterpolatedVertex(i2, i0, weight2, inputSubMesh);
			backSubMesh.AddInterpolatedVertex(i0, i1, weight, inputSubMesh);
		}

		private void SplitB(int i0, int i1, int i2, CuttableSubMesh inputSubMesh, Plane cutPlane, CuttableSubMesh frontSubMesh, CuttableSubMesh backSubMesh)
		{
			Vector3 vertex = inputSubMesh.GetVertex(i0);
			Vector3 vertex2 = inputSubMesh.GetVertex(i2);
			CalcIntersection(vertex2, vertex, cutPlane, out var weight);
			frontSubMesh.CopyVertex(i0, inputSubMesh);
			frontSubMesh.CopyVertex(i1, inputSubMesh);
			frontSubMesh.AddInterpolatedVertex(i2, i0, weight, inputSubMesh);
			backSubMesh.CopyVertex(i1, inputSubMesh);
			backSubMesh.CopyVertex(i2, inputSubMesh);
			backSubMesh.AddInterpolatedVertex(i2, i0, weight, inputSubMesh);
		}

		private void SplitBFlipped(int i0, int i1, int i2, CuttableSubMesh inputSubMesh, Plane cutPlane, CuttableSubMesh frontSubMesh, CuttableSubMesh backSubMesh)
		{
			Vector3 vertex = inputSubMesh.GetVertex(i0);
			Vector3 vertex2 = inputSubMesh.GetVertex(i1);
			CalcIntersection(vertex, vertex2, cutPlane, out var weight);
			frontSubMesh.CopyVertex(i0, inputSubMesh);
			frontSubMesh.AddInterpolatedVertex(i0, i1, weight, inputSubMesh);
			frontSubMesh.CopyVertex(i2, inputSubMesh);
			backSubMesh.CopyVertex(i1, inputSubMesh);
			backSubMesh.CopyVertex(i2, inputSubMesh);
			backSubMesh.AddInterpolatedVertex(i0, i1, weight, inputSubMesh);
		}

		private Vector3 CalcIntersection(Vector3 v0, Vector3 v1, Plane plane, out float weight)
		{
			Vector3 vector = v1 - v0;
			float magnitude = vector.magnitude;
			Ray ray = new Ray(v0, vector / magnitude);
			plane.Raycast(ray, out var enter);
			Vector3 result = ray.origin + ray.direction * enter;
			weight = enter / magnitude;
			return result;
		}
	}
	[CreateAssetMenu]
	public class PhysicsCreatorHullFolder : ScriptableObject
	{
	}
	public class PhysicsCreatorInstallRoot : ScriptableObject
	{
	}
	public class QHullUtil
	{
		public static Mesh FindConvexHull(string debugName, Mesh inputMesh, bool showErrorInLog)
		{
			Vector3[] vertices = inputMesh.vertices;
			int[] triangles = inputMesh.triangles;
			Point3d[] array = new Point3d[triangles.Length];
			for (int i = 0; i < triangles.Length; i += 3)
			{
				Vector3 vector = vertices[triangles[i]];
				Vector3 vector2 = vertices[triangles[i + 1]];
				Vector3 vector3 = vertices[triangles[i + 2]];
				array[i] = new Point3d(vector.x, vector.y, vector.z);
				array[i + 1] = new Point3d(vector2.x, vector2.y, vector2.z);
				array[i + 2] = new Point3d(vector3.x, vector3.y, vector3.z);
			}
			QuickHull3D quickHull3D = new QuickHull3D();
			try
			{
				quickHull3D.build(array);
			}
			catch (Exception)
			{
				if (showErrorInLog)
				{
					UnityEngine.Debug.LogError("Could not generate convex hull for " + debugName);
				}
			}
			Point3d[] vertices2 = quickHull3D.getVertices();
			int[][] faces = quickHull3D.getFaces();
			Vector3[] array2 = new Vector3[vertices2.Length];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = new Vector3((float)vertices2[j].x, (float)vertices2[j].y, (float)vertices2[j].z);
			}
			List<int> list = new List<int>();
			for (int k = 0; k < faces.Length; k++)
			{
				int num = faces[k].Length;
				for (int l = 1; l < num - 1; l++)
				{
					list.Add(faces[k][0]);
					list.Add(faces[k][l]);
					list.Add(faces[k][l + 1]);
				}
			}
			int[] triangles2 = list.ToArray();
			return new Mesh
			{
				vertices = array2,
				triangles = triangles2
			};
		}

		public static void FindConvexHull(string debugName, int[] selectedFaces, Vector3[] meshVertices, int[] meshIndices, out Vector3[] hullVertices, out int[] hullIndices, bool showErrorInLog)
		{
			if (selectedFaces.Length == 0)
			{
				hullVertices = new Vector3[0];
				hullIndices = new int[0];
				return;
			}
			Point3d[] array = new Point3d[selectedFaces.Length * 3];
			for (int i = 0; i < selectedFaces.Length; i++)
			{
				int num = selectedFaces[i];
				Vector3 vector = meshVertices[meshIndices[num * 3]];
				Vector3 vector2 = meshVertices[meshIndices[num * 3 + 1]];
				Vector3 vector3 = meshVertices[meshIndices[num * 3 + 2]];
				array[i * 3] = new Point3d(vector.x, vector.y, vector.z);
				array[i * 3 + 1] = new Point3d(vector2.x, vector2.y, vector2.z);
				array[i * 3 + 2] = new Point3d(vector3.x, vector3.y, vector3.z);
			}
			QuickHull3D quickHull3D = new QuickHull3D();
			try
			{
				quickHull3D.build(array);
			}
			catch (Exception)
			{
				if (showErrorInLog)
				{
					UnityEngine.Debug.LogError("Could not generate convex hull for " + debugName);
				}
			}
			Point3d[] vertices = quickHull3D.getVertices();
			int[][] faces = quickHull3D.getFaces();
			hullVertices = new Vector3[vertices.Length];
			for (int j = 0; j < hullVertices.Length; j++)
			{
				hullVertices[j] = new Vector3((float)vertices[j].x, (float)vertices[j].y, (float)vertices[j].z);
			}
			List<int> list = new List<int>();
			for (int k = 0; k < faces.Length; k++)
			{
				int num2 = faces[k].Length;
				for (int l = 1; l < num2 - 1; l++)
				{
					list.Add(faces[k][0]);
					list.Add(faces[k][l]);
					list.Add(faces[k][l + 1]);
				}
			}
			hullIndices = list.ToArray();
		}
	}
	public class HullData : ScriptableObject
	{
	}
	public enum HullType
	{
		Box,
		ConvexHull,
		Sphere,
		Face,
		FaceAsBox,
		Auto,
		Capsule
	}
	public enum AutoHullPreset
	{
		Low,
		Medium,
		High,
		Placebo,
		Custom
	}
	public enum CapsuleAxis
	{
		X,
		Y,
		Z
	}
	public struct BoxDef
	{
		public Bounds collisionBox;

		public Vector3 boxPosition;

		public Quaternion boxRotation;
	}
	public struct CapsuleDef
	{
		public Vector3 capsuleCenter;

		public CapsuleAxis capsuleDirection;

		public float capsuleRadius;

		public float capsuleHeight;

		public Vector3 capsulePosition;

		public Quaternion capsuleRotation;
	}
	public class PaintingData : ScriptableObject, IEditorData
	{
		public HullData hullData;

		public Mesh sourceMesh;

		public Hash160 sourceMeshHash;

		public int activeHull = -1;

		public float faceThickness = 0.1f;

		public List<Hull> hulls = new List<Hull>();

		public AutoHullPreset autoHullPreset = AutoHullPreset.Medium;

		public VhacdParameters vhacdParams = new VhacdParameters();

		public bool hasLastVhacdTimings;

		public AutoHullPreset lastVhacdPreset = AutoHullPreset.Medium;

		public float lastVhacdDurationSecs;

		public bool suppressMeshModificationWarning;

		public int TotalOutputColliders
		{
			get
			{
				int num = 0;
				foreach (Hull hull in hulls)
				{
					num = ((hull.type != HullType.Auto) ? (num + 1) : (num + ((hull.autoMeshes != null) ? hull.autoMeshes.Length : 0)));
				}
				return num;
			}
		}

		public Hash160 CachedHash
		{
			get
			{
				return sourceMeshHash;
			}
			set
			{
				sourceMeshHash = value;
			}
		}

		public bool HasCachedData
		{
			get
			{
				if (sourceMeshHash != null)
				{
					return sourceMeshHash.IsValid();
				}
				return false;
			}
		}

		public Mesh SourceMesh => sourceMesh;

		public IHull[] Hulls => hulls.ToArray();

		public bool HasSuppressMeshModificationWarning => suppressMeshModificationWarning;

		public void AddHull(HullType type, PhysicsMaterial material, bool isChild, bool isTrigger)
		{
			hulls.Add(new Hull());
			hulls[hulls.Count - 1].name = "Hull " + hulls.Count;
			activeHull = hulls.Count - 1;
			hulls[hulls.Count - 1].colour = GizmoUtils.GetHullColour(activeHull);
			hulls[hulls.Count - 1].type = type;
			hulls[hulls.Count - 1].material = material;
			hulls[hulls.Count - 1].isTrigger = isTrigger;
			hulls[hulls.Count - 1].isChildCollider = isChild;
		}

		public void RemoveHull(int index)
		{
			if (index >= 0 && index < hulls.Count)
			{
				hulls[index].Destroy();
				hulls.RemoveAt(index);
			}
		}

		public void RemoveAllHulls()
		{
			for (int i = 0; i < hulls.Count; i++)
			{
				hulls[i].Destroy();
			}
			hulls.Clear();
		}

		public bool HasActiveHull()
		{
			if (activeHull >= 0)
			{
				return activeHull < hulls.Count;
			}
			return false;
		}

		public Hull GetActiveHull()
		{
			if (activeHull < 0 || activeHull >= hulls.Count)
			{
				return null;
			}
			return hulls[activeHull];
		}

		public bool ContainsMesh(Mesh m)
		{
			foreach (Hull hull in hulls)
			{
				if (hull.collisionMesh == m)
				{
					return true;
				}
				if (hull.faceCollisionMesh == m)
				{
					return true;
				}
				if (hull.autoMeshes == null)
				{
					continue;
				}
				Mesh[] autoMeshes = hull.autoMeshes;
				for (int i = 0; i < autoMeshes.Length; i++)
				{
					if (autoMeshes[i] == m)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool HasAutoHulls()
		{
			foreach (Hull hull in hulls)
			{
				if (hull.type == HullType.Auto)
				{
					return true;
				}
			}
			return false;
		}

		public void SetAssetDirty()
		{
		}
	}
	public class HullMapping
	{
		public Hull sourceHull;

		public Collider generatedCollider;

		public MeshCollider[] autoGeneratedColliders;

		public RigidColliderCreatorChild targetChild;

		public RigidColliderCreatorChild[] targetAutoGeneratedChilds;

		public void AddAutoChild(RigidColliderCreatorChild newChild, MeshCollider newCollider)
		{
			if (newChild != null)
			{
				List<RigidColliderCreatorChild> list = new List<RigidColliderCreatorChild>();
				if (targetAutoGeneratedChilds != null)
				{
					list.AddRange(targetAutoGeneratedChilds);
				}
				if (!list.Contains(newChild))
				{
					list.Add(newChild);
					targetAutoGeneratedChilds = list.ToArray();
				}
			}
			if (newCollider != null)
			{
				List<MeshCollider> list2 = new List<MeshCollider>();
				if (autoGeneratedColliders != null)
				{
					list2.AddRange(autoGeneratedColliders);
				}
				if (!list2.Contains(newCollider))
				{
					list2.Add(newCollider);
					autoGeneratedColliders = list2.ToArray();
				}
			}
		}
	}
	public class RigidColliderCreator : MonoBehaviour, ICreatorComponent
	{
		public PaintingData paintingData;

		public HullData hullData;

		private List<HullMapping> hullMapping;

		private Mesh debugMesh;

		private void OnDestroy()
		{
		}

		public GameObject GetGameObject()
		{
			return base.gameObject;
		}

		public bool HasEditorData()
		{
			return paintingData != null;
		}

		public IEditorData GetEditorData()
		{
			return paintingData;
		}

		public void CreateColliderComponents(Mesh[] autoHulls)
		{
			CreateHullMapping();
			foreach (Hull hull in paintingData.hulls)
			{
				UpdateCollider(hull);
			}
			foreach (Hull hull2 in paintingData.hulls)
			{
				CreateAutoHulls(hull2, autoHulls);
			}
		}

		public void RemoveAllColliders()
		{
			if (hullMapping == null)
			{
				return;
			}
			foreach (HullMapping item in hullMapping)
			{
				DestroyImmediateWithUndo(item.generatedCollider);
				if (item.autoGeneratedColliders != null)
				{
					MeshCollider[] autoGeneratedColliders = item.autoGeneratedColliders;
					for (int i = 0; i < autoGeneratedColliders.Length; i++)
					{
						DestroyImmediateWithUndo(autoGeneratedColliders[i]);
					}
				}
			}
			for (int num = hullMapping.Count - 1; num >= 0; num--)
			{
				if (hullMapping[num].targetChild != null)
				{
					hullMapping.RemoveAt(num);
				}
			}
		}

		public void RemoveAllGenerated()
		{
			CreateHullMapping();
			foreach (HullMapping item in hullMapping)
			{
				DestroyImmediateWithUndo(item.generatedCollider);
				if (item.targetChild != null)
				{
					DestroyImmediateWithUndo(item.targetChild.gameObject);
				}
				if (item.autoGeneratedColliders != null)
				{
					MeshCollider[] autoGeneratedColliders = item.autoGeneratedColliders;
					for (int i = 0; i < autoGeneratedColliders.Length; i++)
					{
						DestroyImmediateWithUndo(autoGeneratedColliders[i]);
					}
				}
				if (item.targetAutoGeneratedChilds == null)
				{
					continue;
				}
				RigidColliderCreatorChild[] targetAutoGeneratedChilds = item.targetAutoGeneratedChilds;
				foreach (RigidColliderCreatorChild obj in targetAutoGeneratedChilds)
				{
					GameObject gameObject = obj.gameObject;
					DestroyImmediateWithUndo(obj);
					if (gameObject.transform.childCount == 0 && gameObject.GetComponents<UnityEngine.Component>().Length == 1)
					{
						DestroyImmediateWithUndo(gameObject);
					}
				}
			}
		}

		private static bool IsDeletable(GameObject obj)
		{
			UnityEngine.Component[] components = obj.GetComponents<UnityEngine.Component>();
			int num = 0;
			UnityEngine.Component[] array = components;
			foreach (UnityEngine.Component component in array)
			{
				if (component is Transform || component is Collider || component is RigidColliderCreator || component is RigidColliderCreatorChild)
				{
					num++;
				}
			}
			return components.Length == num;
		}

		private static void DestroyImmediateWithUndo(UnityEngine.Object obj)
		{
			if (!(obj == null))
			{
				UnityEngine.Object.DestroyImmediate(obj);
			}
		}

		private void CreateHullMapping()
		{
			if (this.hullMapping == null)
			{
				this.hullMapping = new List<HullMapping>();
			}
			for (int num = this.hullMapping.Count - 1; num >= 0; num--)
			{
				HullMapping hullMapping = this.hullMapping[num];
				if (hullMapping == null || hullMapping.sourceHull == null || (hullMapping.generatedCollider == null && hullMapping.targetChild == null))
				{
					this.hullMapping.RemoveAt(num);
				}
			}
			foreach (Hull hull3 in paintingData.hulls)
			{
				if (IsMapped(hull3))
				{
					Collider collider = FindExistingCollider(this.hullMapping, hull3);
					bool num2 = hull3.type == HullType.ConvexHull && collider is MeshCollider;
					bool flag = hull3.type == HullType.Box && collider is BoxCollider;
					bool flag2 = hull3.type == HullType.Capsule && collider is CapsuleCollider;
					bool flag3 = hull3.type == HullType.Sphere && collider is SphereCollider;
					bool flag4 = hull3.type == HullType.Face && collider is MeshCollider;
					bool flag5 = hull3.type == HullType.FaceAsBox && collider is BoxCollider;
					bool flag6 = hull3.type == HullType.Auto && collider is MeshCollider && hull3.autoMeshes != null && hull3.autoMeshes.Length != 0;
					bool num3 = num2 || flag || flag2 || flag3 || flag4 || flag5 || flag6;
					bool flag7 = collider == null || hull3.isChildCollider == (collider.transform.parent == base.transform) || hull3.type == HullType.Auto;
					if (!(num3 && flag7))
					{
						DestroyImmediateWithUndo(collider);
						RemoveMapping(hull3);
					}
				}
			}
			List<Hull> list = new List<Hull>();
			List<Collider> list2 = new List<Collider>();
			List<RigidColliderCreatorChild> list3 = new List<RigidColliderCreatorChild>();
			foreach (Hull hull4 in paintingData.hulls)
			{
				if (!IsMapped(hull4))
				{
					list.Add(hull4);
				}
			}
			foreach (Collider item in FindLocal<Collider>())
			{
				if (!IsMapped(item))
				{
					list2.Add(item);
				}
			}
			foreach (RigidColliderCreatorChild item2 in FindLocal<RigidColliderCreatorChild>())
			{
				if (!IsMapped(item2))
				{
					list3.Add(item2);
				}
			}
			for (int num4 = list.Count - 1; num4 >= 0; num4--)
			{
				Hull hull = list[num4];
				bool flag8 = false;
				for (int num5 = list2.Count - 1; num5 >= 0; num5--)
				{
					Collider collider2 = list2[num5];
					MeshCollider meshCollider = collider2 as MeshCollider;
					BoxCollider boxCollider = collider2 as BoxCollider;
					CapsuleCollider capsuleCollider = collider2 as CapsuleCollider;
					SphereCollider sphereCollider = collider2 as SphereCollider;
					RigidColliderCreatorChild rigidColliderCreatorChild = null;
					if (collider2.transform.parent == base.transform)
					{
						rigidColliderCreatorChild = collider2.gameObject.GetComponent<RigidColliderCreatorChild>();
					}
					bool flag9 = hull.isChildCollider && collider2.transform.parent == base.transform;
					if (rigidColliderCreatorChild != null && rigidColliderCreatorChild.isAutoHull && hull.type == HullType.Auto && meshCollider != null && hull.ContainsAutoMesh(meshCollider.sharedMesh))
					{
						HullMapping hullMapping2 = FindMapping(hull);
						if (hullMapping2 == null)
						{
							hullMapping2 = new HullMapping();
							hullMapping2.sourceHull = hull;
							this.hullMapping.Add(hullMapping2);
						}
						hullMapping2.AddAutoChild(rigidColliderCreatorChild, collider2 as MeshCollider);
						rigidColliderCreatorChild.parent = this;
						list2.RemoveAt(num5);
						list3.Remove(rigidColliderCreatorChild);
						flag8 = true;
					}
					else if (flag9)
					{
						bool num6 = hull.type == HullType.Box && collider2 is BoxCollider && Approximately(hull.collisionBox.collisionBox.center, boxCollider.center) && Approximately(hull.collisionBox.collisionBox.size, boxCollider.size);
						bool flag10 = hull.type == HullType.Sphere && collider2 is SphereCollider && hull.collisionSphere != null && Approximately(hull.collisionSphere.center, sphereCollider.center) && Approximately(hull.collisionSphere.radius, sphereCollider.radius);
						bool flag11 = hull.type == HullType.Capsule && collider2 is CapsuleCollider && Approximately(hull.collisionCapsule.capsuleCenter, capsuleCollider.center) && hull.collisionCapsule.capsuleDirection == (CapsuleAxis)capsuleCollider.direction && Approximately(hull.collisionCapsule.capsuleRadius, capsuleCollider.radius) && Approximately(hull.collisionCapsule.capsuleHeight, capsuleCollider.radius);
						bool flag12 = hull.type == HullType.ConvexHull && collider2 is MeshCollider && meshCollider.sharedMesh == hull.collisionMesh;
						bool flag13 = hull.type == HullType.Face && collider2 is MeshCollider && meshCollider.sharedMesh == hull.faceCollisionMesh;
						bool flag14 = hull.type == HullType.FaceAsBox && collider2 is BoxCollider && Approximately(hull.faceBoxCenter, boxCollider.center) && Approximately(hull.faceBoxSize, boxCollider.size);
						if (num6 || flag10 || flag11 || flag12 || flag13 || flag14)
						{
							AddMapping(hull, collider2, rigidColliderCreatorChild);
							list.RemoveAt(num4);
							list2.RemoveAt(num5);
							for (int i = 0; i < list3.Count; i++)
							{
								if (list3[i] == rigidColliderCreatorChild)
								{
									list3.RemoveAt(i);
									break;
								}
							}
							break;
						}
					}
				}
				if (flag8)
				{
					list.RemoveAt(num4);
				}
			}
			for (int num7 = list.Count - 1; num7 >= 0; num7--)
			{
				if (list[num7].isChildCollider)
				{
					for (int num8 = list3.Count - 1; num8 >= 0; num8--)
					{
						RigidColliderCreatorChild child = list3[num8];
						HullMapping hullMapping3 = FindMapping(child);
						if (hullMapping3 != null && hullMapping3.sourceHull != null)
						{
							if (hullMapping3.generatedCollider == null)
							{
								RecreateChildCollider(hullMapping3);
							}
							list.RemoveAt(num7);
							list3.RemoveAt(num8);
							break;
						}
					}
				}
			}
			for (int num9 = list.Count - 1; num9 >= 0; num9--)
			{
				Hull hull2 = list[num9];
				if (hull2.isChildCollider && hull2.type == HullType.Auto)
				{
					bool flag15 = false;
					for (int num10 = list3.Count - 1; num10 >= 0; num10--)
					{
						RigidColliderCreatorChild rigidColliderCreatorChild2 = list3[num10];
						if (rigidColliderCreatorChild2.isAutoHull && rigidColliderCreatorChild2.gameObject.name.StartsWith(hull2.name))
						{
							HullMapping hullMapping4 = FindMapping(hull2);
							if (hullMapping4 == null)
							{
								hullMapping4 = new HullMapping();
								hullMapping4.sourceHull = hull2;
								this.hullMapping.Add(hullMapping4);
							}
							hullMapping4.AddAutoChild(rigidColliderCreatorChild2, null);
							list3.RemoveAt(num10);
							flag15 = true;
						}
					}
					if (flag15)
					{
						list.RemoveAt(num9);
					}
				}
			}
			foreach (HullMapping item3 in this.hullMapping)
			{
				if (item3.targetChild != null && item3.generatedCollider == null)
				{
					RecreateChildCollider(item3);
				}
			}
			foreach (HullMapping item4 in this.hullMapping)
			{
				if (item4.targetChild == null && item4.generatedCollider != null && item4.generatedCollider.transform.parent == base.transform)
				{
					RigidColliderCreatorChild rigidColliderCreatorChild3 = AddComponent<RigidColliderCreatorChild>(item4.generatedCollider.gameObject);
					rigidColliderCreatorChild3.parent = this;
					item4.targetChild = rigidColliderCreatorChild3;
				}
			}
			foreach (Hull item5 in list)
			{
				if (item5.type == HullType.Box)
				{
					CreateCollider<BoxCollider>(item5);
				}
				else if (item5.type == HullType.Sphere)
				{
					CreateCollider<SphereCollider>(item5);
				}
				else if (item5.type == HullType.ConvexHull)
				{
					CreateCollider<MeshCollider>(item5);
				}
				else if (item5.type == HullType.Face)
				{
					CreateCollider<MeshCollider>(item5);
				}
				else if (item5.type == HullType.FaceAsBox)
				{
					CreateCollider<BoxCollider>(item5);
				}
				else if (item5.type == HullType.Capsule)
				{
					CreateCollider<CapsuleCollider>(item5);
				}
			}
			foreach (Collider item6 in list2)
			{
				if (item6 == null)
				{
					continue;
				}
				if (item6.gameObject == base.gameObject)
				{
					DestroyImmediateWithUndo(item6);
					continue;
				}
				GameObject gameObject = item6.gameObject;
				DestroyImmediateWithUndo(item6);
				DestroyImmediateWithUndo(gameObject.GetComponent<RigidColliderCreatorChild>());
				if (IsDeletable(gameObject))
				{
					DestroyImmediateWithUndo(gameObject);
				}
			}
			foreach (RigidColliderCreatorChild item7 in list3)
			{
				if (!(item7 == null))
				{
					GameObject gameObject2 = item7.gameObject;
					DestroyImmediateWithUndo(item7);
					DestroyImmediateWithUndo(gameObject2.GetComponent<Collider>());
					if (IsDeletable(gameObject2))
					{
						DestroyImmediateWithUndo(gameObject2);
					}
				}
			}
		}

		private static bool Approximately(Vector3 lhs, Vector3 rhs)
		{
			if (Mathf.Approximately(lhs.x, rhs.x) && Mathf.Approximately(lhs.y, rhs.y))
			{
				return Mathf.Approximately(lhs.z, rhs.z);
			}
			return false;
		}

		private static bool Approximately(float lhs, float rhs)
		{
			return Mathf.Approximately(lhs, rhs);
		}

		private void CreateCollider<T>(Hull sourceHull) where T : Collider
		{
			if (sourceHull.isChildCollider)
			{
				GameObject obj = CreateGameObject(sourceHull.name);
				obj.transform.SetParent(base.transform, worldPositionStays: false);
				obj.transform.localPosition = Vector3.zero;
				obj.transform.localRotation = Quaternion.identity;
				obj.transform.localScale = Vector3.one;
				RigidColliderCreatorChild rigidColliderCreatorChild = AddComponent<RigidColliderCreatorChild>(obj);
				rigidColliderCreatorChild.parent = this;
				T col = AddComponent<T>(obj);
				AddMapping(sourceHull, col, rigidColliderCreatorChild);
			}
			else
			{
				T col2 = AddComponent<T>(base.gameObject);
				AddMapping(sourceHull, col2, null);
			}
		}

		private void RecreateChildCollider(HullMapping mapping)
		{
			if (mapping != null && mapping.sourceHull != null && mapping.sourceHull.isChildCollider)
			{
				if (mapping.sourceHull.type == HullType.Box)
				{
					RecreateChildCollider<BoxCollider>(mapping);
				}
				else if (mapping.sourceHull.type == HullType.Sphere)
				{
					RecreateChildCollider<SphereCollider>(mapping);
				}
				else if (mapping.sourceHull.type == HullType.ConvexHull)
				{
					RecreateChildCollider<MeshCollider>(mapping);
				}
				else if (mapping.sourceHull.type == HullType.Face)
				{
					RecreateChildCollider<MeshCollider>(mapping);
				}
				else if (mapping.sourceHull.type == HullType.FaceAsBox)
				{
					RecreateChildCollider<BoxCollider>(mapping);
				}
				else if (mapping.sourceHull.type == HullType.Capsule)
				{
					RecreateChildCollider<CapsuleCollider>(mapping);
				}
			}
		}

		private void RecreateChildCollider<T>(HullMapping mapping) where T : Collider
		{
			if (mapping.sourceHull != null && mapping.sourceHull.isChildCollider)
			{
				T generatedCollider = AddComponent<T>(mapping.targetChild.gameObject);
				mapping.generatedCollider = generatedCollider;
			}
		}

		private void UpdateCollider(Hull hull)
		{
			Collider collider = null;
			if (hull.type == HullType.Box)
			{
				BoxCollider boxCollider = FindExistingCollider(hullMapping, hull) as BoxCollider;
				boxCollider.center = hull.collisionBox.collisionBox.center;
				boxCollider.size = hull.collisionBox.collisionBox.size + (hull.enableInflation ? (Vector3.one * hull.inflationAmount) : Vector3.zero);
				if (hull.isChildCollider)
				{
					boxCollider.transform.localPosition = hull.collisionBox.boxPosition;
					boxCollider.transform.localRotation = hull.collisionBox.boxRotation;
				}
				collider = boxCollider;
			}
			else if (hull.type == HullType.Sphere)
			{
				SphereCollider sphereCollider = FindExistingCollider(hullMapping, hull) as SphereCollider;
				sphereCollider.radius = hull.collisionSphere.radius + (hull.enableInflation ? hull.inflationAmount : 0f);
				if (hull.isChildCollider)
				{
					sphereCollider.transform.localPosition = hull.collisionSphere.center;
				}
				else
				{
					sphereCollider.center = hull.collisionSphere.center;
				}
				collider = sphereCollider;
			}
			else if (hull.type == HullType.Capsule)
			{
				CapsuleCollider capsuleCollider = FindExistingCollider(hullMapping, hull) as CapsuleCollider;
				capsuleCollider.center = hull.collisionCapsule.capsuleCenter;
				capsuleCollider.direction = (int)hull.collisionCapsule.capsuleDirection;
				capsuleCollider.radius = hull.collisionCapsule.capsuleRadius;
				capsuleCollider.height = hull.collisionCapsule.capsuleHeight;
				if (hull.isChildCollider)
				{
					capsuleCollider.transform.localPosition = hull.collisionCapsule.capsulePosition;
					capsuleCollider.transform.localRotation = hull.collisionCapsule.capsuleRotation;
				}
				collider = capsuleCollider;
			}
			else if (hull.type == HullType.ConvexHull)
			{
				MeshCollider obj = FindExistingCollider(hullMapping, hull) as MeshCollider;
				obj.sharedMesh = hull.collisionMesh;
				obj.convex = true;
				obj.cookingOptions &= ~MeshColliderCookingOptions.EnableMeshCleaning;
				collider = obj;
			}
			else if (hull.type == HullType.Face)
			{
				MeshCollider obj2 = FindExistingCollider(hullMapping, hull) as MeshCollider;
				obj2.sharedMesh = hull.faceCollisionMesh;
				obj2.convex = true;
				collider = obj2;
			}
			else if (hull.type == HullType.FaceAsBox)
			{
				BoxCollider boxCollider2 = FindExistingCollider(hullMapping, hull) as BoxCollider;
				boxCollider2.size = hull.faceBoxSize + (hull.enableInflation ? (Vector3.one * hull.inflationAmount) : Vector3.zero);
				if (hull.isChildCollider)
				{
					boxCollider2.transform.localPosition = hull.faceBoxCenter;
					boxCollider2.transform.localRotation = hull.faceAsBoxRotation;
				}
				else
				{
					boxCollider2.center = hull.faceBoxCenter;
				}
				collider = boxCollider2;
			}
			else
			{
				_ = hull.type;
				_ = 5;
			}
			if (collider != null)
			{
				collider.material = hull.material;
				collider.isTrigger = hull.isTrigger;
				if (hull.isChildCollider)
				{
					collider.gameObject.name = hull.name;
				}
			}
		}

		public void SetAllTypes(HullType newType)
		{
			foreach (Hull hull in paintingData.hulls)
			{
				hull.type = newType;
			}
		}

		public void SetAllMaterials(PhysicsMaterial newMaterial)
		{
			foreach (Hull hull in paintingData.hulls)
			{
				hull.material = newMaterial;
			}
		}

		public void SetAllAsChild(bool isChild)
		{
			foreach (Hull hull in paintingData.hulls)
			{
				hull.isChildCollider = isChild;
			}
		}

		public void SetAllAsTrigger(bool isTrigger)
		{
			foreach (Hull hull in paintingData.hulls)
			{
				hull.isTrigger = isTrigger;
			}
		}

		private List<T> FindLocal<T>() where T : UnityEngine.Component
		{
			List<T> list = new List<T>();
			list.AddRange(base.gameObject.GetComponents<T>());
			for (int i = 0; i < base.transform.childCount; i++)
			{
				list.AddRange(base.transform.GetChild(i).GetComponents<T>());
			}
			return list;
		}

		private bool IsMapped(Hull hull)
		{
			if (hullMapping == null)
			{
				return false;
			}
			foreach (HullMapping item in hullMapping)
			{
				if (item.sourceHull == hull)
				{
					return true;
				}
			}
			return false;
		}

		private bool IsMapped(Collider col)
		{
			if (hullMapping == null)
			{
				return false;
			}
			foreach (HullMapping item in hullMapping)
			{
				if (item.generatedCollider == col)
				{
					return true;
				}
			}
			return false;
		}

		private bool IsMapped(RigidColliderCreatorChild child)
		{
			if (hullMapping == null)
			{
				return false;
			}
			foreach (HullMapping item in hullMapping)
			{
				if (item.targetChild == child)
				{
					return true;
				}
			}
			return false;
		}

		private void AddMapping(Hull hull, Collider col, RigidColliderCreatorChild painterChild)
		{
			HullMapping item = new HullMapping
			{
				sourceHull = hull,
				generatedCollider = col,
				targetChild = painterChild
			};
			hullMapping.Add(item);
		}

		private void RemoveMapping(Hull hull)
		{
			for (int i = 0; i < hullMapping.Count; i++)
			{
				if (hullMapping[i].sourceHull == hull)
				{
					hullMapping.RemoveAt(i);
					break;
				}
			}
		}

		private HullMapping FindMapping(RigidColliderCreatorChild child)
		{
			if (hullMapping == null)
			{
				return null;
			}
			foreach (HullMapping item in hullMapping)
			{
				if (item.targetChild == child)
				{
					return item;
				}
			}
			return null;
		}

		private HullMapping FindMapping(Hull hull)
		{
			if (hullMapping == null)
			{
				return null;
			}
			foreach (HullMapping item in hullMapping)
			{
				if (item.sourceHull == hull)
				{
					return item;
				}
			}
			return null;
		}

		public Hull FindSourceHull(RigidColliderCreatorChild child)
		{
			if (hullMapping == null)
			{
				return null;
			}
			foreach (HullMapping item in hullMapping)
			{
				if (item.targetChild == child)
				{
					return item.sourceHull;
				}
				if (item.targetAutoGeneratedChilds == null)
				{
					continue;
				}
				RigidColliderCreatorChild[] targetAutoGeneratedChilds = item.targetAutoGeneratedChilds;
				for (int i = 0; i < targetAutoGeneratedChilds.Length; i++)
				{
					if (targetAutoGeneratedChilds[i] == child)
					{
						return item.sourceHull;
					}
				}
			}
			return null;
		}

		private static Collider FindExistingCollider(List<HullMapping> mappings, Hull hull)
		{
			foreach (HullMapping mapping in mappings)
			{
				if (mapping.sourceHull == hull)
				{
					return mapping.generatedCollider;
				}
			}
			return null;
		}

		private void CreateAutoHulls(Hull hull, Mesh[] autoHulls)
		{
			if (hull.type != HullType.Auto)
			{
				return;
			}
			HullMapping hullMapping = FindMapping(hull);
			if (hullMapping == null)
			{
				hullMapping = new HullMapping();
				hullMapping.sourceHull = hull;
				this.hullMapping.Add(hullMapping);
			}
			Mesh[] autoMeshes = hull.autoMeshes;
			List<MeshCollider> list = new List<MeshCollider>();
			if (hullMapping.targetAutoGeneratedChilds != null)
			{
				for (int i = 0; i < hullMapping.targetAutoGeneratedChilds.Length; i++)
				{
					if (hullMapping.autoGeneratedColliders != null && i < hullMapping.autoGeneratedColliders.Length)
					{
						list.Add(hullMapping.autoGeneratedColliders[i]);
						continue;
					}
					MeshCollider meshCollider = hullMapping.targetAutoGeneratedChilds[i].gameObject.AddComponent<MeshCollider>();
					meshCollider.convex = true;
					list.Add(meshCollider);
				}
			}
			for (int num = list.Count - 1; num >= 0; num--)
			{
				bool flag = list[num].transform != base.transform;
				if (flag != (bool)base.transform && hull.isChildCollider)
				{
					if (flag)
					{
						UnityEngine.Object.DestroyImmediate(list[num].gameObject);
					}
					else
					{
						UnityEngine.Object.DestroyImmediate(list[num]);
					}
					list.RemoveAt(num);
				}
			}
			for (int j = 0; j < autoMeshes.Length; j++)
			{
				Mesh sharedMesh = autoMeshes[j];
				MeshCollider meshCollider2;
				if (j < list.Count)
				{
					meshCollider2 = list[j];
				}
				else if (hull.isChildCollider)
				{
					GameObject obj = CreateGameObject("New child");
					obj.transform.SetParent(base.transform, worldPositionStays: false);
					RigidColliderCreatorChild rigidColliderCreatorChild = obj.AddComponent<RigidColliderCreatorChild>();
					rigidColliderCreatorChild.parent = this;
					rigidColliderCreatorChild.isAutoHull = true;
					meshCollider2 = obj.AddComponent<MeshCollider>();
					list.Add(meshCollider2);
				}
				else
				{
					meshCollider2 = base.gameObject.AddComponent<MeshCollider>();
					list.Add(meshCollider2);
				}
				meshCollider2.sharedMesh = sharedMesh;
				meshCollider2.convex = true;
				meshCollider2.isTrigger = hull.isTrigger;
				meshCollider2.material = hull.material;
			}
			if (hull.isChildCollider)
			{
				for (int k = 0; k < list.Count; k++)
				{
					list[k].gameObject.name = $"{hull.name}.{k + 1}";
				}
			}
			List<RigidColliderCreatorChild> list2 = new List<RigidColliderCreatorChild>();
			foreach (MeshCollider item in list)
			{
				list2.Add(item.GetComponent<RigidColliderCreatorChild>());
			}
			hullMapping.autoGeneratedColliders = list.ToArray();
			hullMapping.targetAutoGeneratedChilds = list2.ToArray();
		}

		private static GameObject CreateGameObject(string goName)
		{
			return new GameObject(goName);
		}

		private static T AddComponent<T>(GameObject targetObj) where T : UnityEngine.Component
		{
			return targetObj.AddComponent<T>();
		}

		private void OnDrawGizmos()
		{
		}
	}
	public class RigidColliderCreatorChild : MonoBehaviour
	{
		public RigidColliderCreator parent;

		public bool isAutoHull;
	}
	public class Sphere
	{
		public Vector3 center;

		public float radius = 1f;
	}
	public class SphereUtils
	{
		public class Support
		{
			public int m_iQuantity;

			public int[] m_aiIndex = new int[4];

			public bool Contains(int iIndex, List<Vector3> points)
			{
				for (int i = 0; i < m_iQuantity; i++)
				{
					if ((points[iIndex] - points[m_aiIndex[i]]).sqrMagnitude < 0.001f)
					{
						return true;
					}
				}
				return false;
			}
		}

		private const float kEpsilon = 0.001f;

		private const float kOnePlusEpsilon = 1.001f;

		private static bool PointInsideSphere(Vector3 rkP, Sphere rkS)
		{
			return (rkP - rkS.center).sqrMagnitude <= 1.001f * rkS.radius;
		}

		private static Sphere ExactSphere1(Vector3 rkP)
		{
			return new Sphere
			{
				center = rkP,
				radius = 0f
			};
		}

		private static Sphere ExactSphere2(Vector3 rkP0, Vector3 rkP1)
		{
			return new Sphere
			{
				center = 0.5f * (rkP0 + rkP1),
				radius = 0.25f * (rkP1 - rkP0).sqrMagnitude
			};
		}

		private static Sphere ExactSphere3(Vector3 rkP0, Vector3 rkP1, Vector3 rkP2)
		{
			Vector3 vector = rkP0 - rkP2;
			Vector3 vector2 = rkP1 - rkP2;
			float num = Vector3.Dot(vector, vector);
			float num2 = Vector3.Dot(vector, vector2);
			float num3 = Vector3.Dot(vector2, vector2);
			float num4 = num * num3 - num2 * num2;
			Sphere sphere = new Sphere();
			float num5 = 0.5f / num4;
			float num6 = num5 * num3 * (num - num2);
			float num7 = num5 * num * (num3 - num2);
			float num8 = 1f - num6 - num7;
			sphere.center = num6 * rkP0 + num7 * rkP1 + num8 * rkP2;
			sphere.radius = (num6 * vector + num7 * vector2).sqrMagnitude;
			return sphere;
		}

		private static Sphere ExactSphere4(Vector3 rkP0, Vector3 rkP1, Vector3 rkP2, Vector3 rkP3)
		{
			Vector3 vector = rkP0 - rkP3;
			Vector3 vector2 = rkP1 - rkP3;
			Vector3 vector3 = rkP2 - rkP3;
			float[,] array = new float[3, 3];
			array[0, 0] = Vector3.Dot(vector, vector);
			array[0, 1] = Vector3.Dot(vector, vector2);
			array[0, 2] = Vector3.Dot(vector, vector3);
			array[1, 0] = array[0, 1];
			array[1, 1] = Vector3.Dot(vector2, vector2);
			array[1, 2] = Vector3.Dot(vector2, vector3);
			array[2, 0] = array[0, 2];
			array[2, 1] = array[1, 2];
			array[2, 2] = Vector3.Dot(vector3, vector3);
			float[] array2 = new float[3]
			{
				0.5f * array[0, 0],
				0.5f * array[1, 1],
				0.5f * array[2, 2]
			};
			float[,] array3 = new float[3, 3]
			{
				{
					array[1, 1] * array[2, 2] - array[1, 2] * array[2, 1],
					array[0, 2] * array[2, 1] - array[0, 1] * array[2, 2],
					array[0, 1] * array[1, 2] - array[0, 2] * array[1, 1]
				},
				{
					array[1, 2] * array[2, 0] - array[1, 0] * array[2, 2],
					array[0, 0] * array[2, 2] - array[0, 2] * array[2, 0],
					array[0, 2] * array[1, 0] - array[0, 0] * array[1, 2]
				},
				{
					array[1, 0] * array[2, 1] - array[1, 1] * array[2, 0],
					array[0, 1] * array[2, 0] - array[0, 0] * array[2, 1],
					array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0]
				}
			};
			float num = array[0, 0] * array3[0, 0] + array[0, 1] * array3[1, 0] + array[0, 2] * array3[2, 0];
			Sphere sphere = new Sphere();
			float num2 = 1f / num;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					array3[i, j] *= num2;
				}
			}
			float[] array4 = new float[4];
			for (int i = 0; i < 3; i++)
			{
				array4[i] = 0f;
				for (int j = 0; j < 3; j++)
				{
					array4[i] += array3[i, j] * array2[j];
				}
			}
			array4[3] = 1f - array4[0] - array4[1] - array4[2];
			sphere.center = array4[0] * rkP0 + array4[1] * rkP1 + array4[2] * rkP2 + array4[3] * rkP3;
			sphere.radius = (array4[0] * vector + array4[1] * vector2 + array4[2] * vector3).sqrMagnitude;
			return sphere;
		}

		private static Sphere UpdateSupport1(int i, List<Vector3> apkPerm, Support rkSupp)
		{
			Vector3 rkP = apkPerm[rkSupp.m_aiIndex[0]];
			Vector3 rkP2 = apkPerm[i];
			Sphere result = ExactSphere2(rkP, rkP2);
			rkSupp.m_iQuantity = 2;
			rkSupp.m_aiIndex[1] = i;
			return result;
		}

		private static Sphere UpdateSupport2(int i, List<Vector3> apkPerm, Support rkSupp)
		{
			Vector3 vector = apkPerm[rkSupp.m_aiIndex[0]];
			Vector3 vector2 = apkPerm[rkSupp.m_aiIndex[1]];
			Vector3 vector3 = apkPerm[i];
			Sphere[] array = new Sphere[3];
			float num = float.PositiveInfinity;
			int num2 = -1;
			array[0] = ExactSphere2(vector, vector3);
			if (PointInsideSphere(vector2, array[0]))
			{
				num = array[0].radius;
				num2 = 0;
			}
			array[1] = ExactSphere2(vector2, vector3);
			if (PointInsideSphere(vector, array[1]) && array[1].radius < num)
			{
				num = array[1].radius;
				num2 = 1;
			}
			Sphere result;
			if (num2 != -1)
			{
				result = array[num2];
				rkSupp.m_aiIndex[1 - num2] = i;
			}
			else
			{
				result = ExactSphere3(vector, vector2, vector3);
				rkSupp.m_iQuantity = 3;
				rkSupp.m_aiIndex[2] = i;
			}
			return result;
		}

		private static Sphere UpdateSupport3(int i, List<Vector3> apkPerm, Support rkSupp)
		{
			Vector3 vector = apkPerm[rkSupp.m_aiIndex[0]];
			Vector3 vector2 = apkPerm[rkSupp.m_aiIndex[1]];
			Vector3 vector3 = apkPerm[rkSupp.m_aiIndex[2]];
			Vector3 vector4 = apkPerm[i];
			Sphere[] array = new Sphere[6];
			float num = float.PositiveInfinity;
			int num2 = -1;
			array[0] = ExactSphere2(vector, vector4);
			if (PointInsideSphere(vector2, array[0]) && PointInsideSphere(vector3, array[0]))
			{
				num = array[0].radius;
				num2 = 0;
			}
			array[1] = ExactSphere2(vector2, vector4);
			if (PointInsideSphere(vector, array[1]) && PointInsideSphere(vector3, array[1]) && array[1].radius < num)
			{
				num = array[1].radius;
				num2 = 1;
			}
			array[2] = ExactSphere2(vector3, vector4);
			if (PointInsideSphere(vector, array[2]) && PointInsideSphere(vector2, array[2]) && array[2].radius < num)
			{
				num = array[2].radius;
				num2 = 2;
			}
			array[3] = ExactSphere3(vector, vector2, vector4);
			if (PointInsideSphere(vector3, array[3]) && array[3].radius < num)
			{
				num = array[3].radius;
				num2 = 3;
			}
			array[4] = ExactSphere3(vector, vector3, vector4);
			if (PointInsideSphere(vector2, array[4]) && array[4].radius < num)
			{
				num = array[4].radius;
				num2 = 4;
			}
			array[5] = ExactSphere3(vector2, vector3, vector4);
			if (PointInsideSphere(vector, array[5]) && array[5].radius < num)
			{
				num = array[5].radius;
				num2 = 5;
			}
			Sphere result;
			switch (num2)
			{
			case 0:
				result = array[0];
				rkSupp.m_iQuantity = 2;
				rkSupp.m_aiIndex[1] = i;
				break;
			case 1:
				result = array[1];
				rkSupp.m_iQuantity = 2;
				rkSupp.m_aiIndex[0] = i;
				break;
			case 2:
				result = array[2];
				rkSupp.m_iQuantity = 2;
				rkSupp.m_aiIndex[0] = rkSupp.m_aiIndex[2];
				rkSupp.m_aiIndex[1] = i;
				break;
			case 3:
				result = array[3];
				rkSupp.m_aiIndex[2] = i;
				break;
			case 4:
				result = array[4];
				rkSupp.m_aiIndex[1] = i;
				break;
			case 5:
				result = array[5];
				rkSupp.m_aiIndex[0] = i;
				break;
			default:
				result = ExactSphere4(vector, vector2, vector3, vector4);
				rkSupp.m_iQuantity = 4;
				rkSupp.m_aiIndex[3] = i;
				break;
			}
			return result;
		}

		public static Sphere UpdateSupport4(int i, List<Vector3> apkPerm, Support rkSupp)
		{
			Vector3 vector = apkPerm[rkSupp.m_aiIndex[0]];
			Vector3 vector2 = apkPerm[rkSupp.m_aiIndex[1]];
			Vector3 vector3 = apkPerm[rkSupp.m_aiIndex[2]];
			Vector3 vector4 = apkPerm[rkSupp.m_aiIndex[3]];
			Vector3 vector5 = apkPerm[i];
			Sphere[] array = new Sphere[14];
			float num = float.PositiveInfinity;
			int num2 = -1;
			array[0] = ExactSphere2(vector, vector5);
			if (PointInsideSphere(vector2, array[0]) && PointInsideSphere(vector3, array[0]) && PointInsideSphere(vector4, array[0]))
			{
				num = array[0].radius;
				num2 = 0;
			}
			array[1] = ExactSphere2(vector2, vector5);
			if (PointInsideSphere(vector, array[1]) && PointInsideSphere(vector3, array[1]) && PointInsideSphere(vector4, array[1]) && array[1].radius < num)
			{
				num = array[1].radius;
				num2 = 1;
			}
			array[2] = ExactSphere2(vector3, vector5);
			if (PointInsideSphere(vector, array[2]) && PointInsideSphere(vector2, array[2]) && PointInsideSphere(vector4, array[2]) && array[2].radius < num)
			{
				num = array[2].radius;
				num2 = 2;
			}
			array[3] = ExactSphere2(vector4, vector5);
			if (PointInsideSphere(vector, array[3]) && PointInsideSphere(vector2, array[3]) && PointInsideSphere(vector3, array[3]) && array[3].radius < num)
			{
				num = array[3].radius;
				num2 = 3;
			}
			array[4] = ExactSphere3(vector, vector2, vector5);
			if (PointInsideSphere(vector3, array[4]) && PointInsideSphere(vector4, array[4]) && array[4].radius < num)
			{
				num = array[4].radius;
				num2 = 4;
			}
			array[5] = ExactSphere3(vector, vector3, vector5);
			if (PointInsideSphere(vector2, array[5]) && PointInsideSphere(vector4, array[5]) && array[5].radius < num)
			{
				num = array[5].radius;
				num2 = 5;
			}
			array[6] = ExactSphere3(vector, vector4, vector5);
			if (PointInsideSphere(vector2, array[6]) && PointInsideSphere(vector3, array[6]) && array[6].radius < num)
			{
				num = array[6].radius;
				num2 = 6;
			}
			array[7] = ExactSphere3(vector2, vector3, vector5);
			if (PointInsideSphere(vector, array[7]) && PointInsideSphere(vector4, array[7]) && array[7].radius < num)
			{
				num = array[7].radius;
				num2 = 7;
			}
			array[8] = ExactSphere3(vector2, vector4, vector5);
			if (PointInsideSphere(vector, array[8]) && PointInsideSphere(vector3, array[8]) && array[8].radius < num)
			{
				num = array[8].radius;
				num2 = 8;
			}
			array[9] = ExactSphere3(vector3, vector4, vector5);
			if (PointInsideSphere(vector, array[9]) && PointInsideSphere(vector2, array[9]) && array[9].radius < num)
			{
				num = array[9].radius;
				num2 = 9;
			}
			array[10] = ExactSphere4(vector, vector2, vector3, vector5);
			if (PointInsideSphere(vector4, array[10]) && array[10].radius < num)
			{
				num = array[10].radius;
				num2 = 10;
			}
			array[11] = ExactSphere4(vector, vector2, vector4, vector5);
			if (PointInsideSphere(vector3, array[11]) && array[11].radius < num)
			{
				num = array[11].radius;
				num2 = 11;
			}
			array[12] = ExactSphere4(vector, vector3, vector4, vector5);
			if (PointInsideSphere(vector2, array[12]) && array[12].radius < num)
			{
				num = array[12].radius;
				num2 = 12;
			}
			array[13] = ExactSphere4(vector2, vector3, vector4, vector5);
			if (PointInsideSphere(vector, array[13]) && array[13].radius < num)
			{
				num = array[13].radius;
				num2 = 13;
			}
			Sphere result = array[num2];
			switch (num2)
			{
			case 0:
				rkSupp.m_iQuantity = 2;
				rkSupp.m_aiIndex[1] = i;
				break;
			case 1:
				rkSupp.m_iQuantity = 2;
				rkSupp.m_aiIndex[0] = i;
				break;
			case 2:
				rkSupp.m_iQuantity = 2;
				rkSupp.m_aiIndex[0] = rkSupp.m_aiIndex[2];
				rkSupp.m_aiIndex[1] = i;
				break;
			case 3:
				rkSupp.m_iQuantity = 2;
				rkSupp.m_aiIndex[0] = rkSupp.m_aiIndex[3];
				rkSupp.m_aiIndex[1] = i;
				break;
			case 4:
				rkSupp.m_iQuantity = 3;
				rkSupp.m_aiIndex[2] = i;
				break;
			case 5:
				rkSupp.m_iQuantity = 3;
				rkSupp.m_aiIndex[1] = i;
				break;
			case 6:
				rkSupp.m_iQuantity = 3;
				rkSupp.m_aiIndex[1] = rkSupp.m_aiIndex[3];
				rkSupp.m_aiIndex[2] = i;
				break;
			case 7:
				rkSupp.m_iQuantity = 3;
				rkSupp.m_aiIndex[0] = i;
				break;
			case 8:
				rkSupp.m_iQuantity = 3;
				rkSupp.m_aiIndex[0] = rkSupp.m_aiIndex[3];
				rkSupp.m_aiIndex[2] = i;
				break;
			case 9:
				rkSupp.m_iQuantity = 3;
				rkSupp.m_aiIndex[0] = rkSupp.m_aiIndex[3];
				rkSupp.m_aiIndex[1] = i;
				break;
			case 10:
				rkSupp.m_aiIndex[3] = i;
				break;
			case 11:
				rkSupp.m_aiIndex[2] = i;
				break;
			case 12:
				rkSupp.m_aiIndex[1] = i;
				break;
			case 13:
				rkSupp.m_aiIndex[0] = i;
				break;
			}
			return result;
		}

		private static Sphere Update(int funcIndex, int numPoints, List<Vector3> points, Support support)
		{
			return funcIndex switch
			{
				0 => null, 
				1 => UpdateSupport1(numPoints, points, support), 
				2 => UpdateSupport2(numPoints, points, support), 
				3 => UpdateSupport3(numPoints, points, support), 
				4 => UpdateSupport4(numPoints, points, support), 
				_ => null, 
			};
		}

		public static Sphere MinSphere(List<Vector3> inputPoints)
		{
			Sphere sphere = new Sphere();
			Support support = new Support();
			if (inputPoints.Count >= 1)
			{
				List<Vector3> list = new List<Vector3>(inputPoints);
				Shuffle(list);
				sphere = ExactSphere1(list[0]);
				support.m_iQuantity = 1;
				support.m_aiIndex[0] = 0;
				int num = 1;
				while (num < inputPoints.Count)
				{
					if (!support.Contains(num, list) && !PointInsideSphere(list[num], sphere))
					{
						sphere = Update(support.m_iQuantity, num, list, support);
						num = 0;
					}
					else
					{
						num++;
					}
				}
			}
			sphere.radius = Mathf.Sqrt(sphere.radius);
			return sphere;
		}

		public static void Shuffle(List<Vector3> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				int index = i + UnityEngine.Random.Range(0, list.Count - i);
				Vector3 value = list[index];
				list[index] = list[i];
				list[i] = value;
			}
		}
	}
	public class ToolGUILayout
	{
		public static Dictionary<string, Vector2> buttonPositions = new Dictionary<string, Vector2>();

		public static bool Button(string buttonName, ref Vector2 buttonPos)
		{
			bool result = GUILayout.Button(buttonName);
			if (Event.current.type == EventType.Repaint)
			{
				buttonPos = GUIUtility.GUIToScreenPoint(GUILayoutUtility.GetLastRect().center);
			}
			return result;
		}

		public static bool Button(string buttonId, Rect rect, GUIContent content, GUIStyle style)
		{
			bool result = GUI.Button(rect, content, style);
			if (Event.current.type == EventType.Repaint)
			{
				buttonPositions[buttonId] = GUIUtility.GUIToScreenPoint(rect.center);
			}
			return result;
		}

		public static bool Button(string buttonId, GUIContent content, GUIStyle style, params GUILayoutOption[] options)
		{
			bool result = GUILayout.Button(content, style, options);
			if (Event.current.type == EventType.Repaint)
			{
				Rect lastRect = GUILayoutUtility.GetLastRect();
				buttonPositions[buttonId] = GUIUtility.GUIToScreenPoint(lastRect.center);
			}
			return result;
		}

		public static bool Button(string buttonId, string buttonName)
		{
			bool result = GUILayout.Button(buttonName);
			if (Event.current.type == EventType.Repaint)
			{
				Vector2 value = GUIUtility.GUIToScreenPoint(GUILayoutUtility.GetLastRect().center);
				buttonPositions[buttonId] = value;
			}
			return result;
		}

		public static Vector2 GetButtonPosition(string buttonId)
		{
			return buttonPositions[buttonId];
		}
	}
	public class UnpackedMesh
	{
		private MeshRenderer rigidRenderer;

		private SkinnedMeshRenderer skinnedRenderer;

		private Mesh srcMesh;

		private Vector3[] vertices;

		private Vector3[] normals;

		private BoneWeight[] weights;

		private int[] indices;

		private Vector3[] modelSpaceVertices;

		public SkinnedMeshRenderer SkinnedRenderer => skinnedRenderer;

		public Mesh Mesh => srcMesh;

		public Transform ModelSpaceTransform
		{
			get
			{
				if (skinnedRenderer != null)
				{
					return skinnedRenderer.rootBone.parent;
				}
				return rigidRenderer.transform;
			}
		}

		public Vector3[] RawVertices => vertices;

		public Vector3[] ModelSpaceVertices => modelSpaceVertices;

		public BoneWeight[] BoneWeights => weights;

		public int NumVertices => vertices.Length;

		public int[] Indices => indices;

		public static UnpackedMesh Create(Renderer renderer)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = renderer as SkinnedMeshRenderer;
			MeshRenderer meshRenderer = renderer as MeshRenderer;
			if (skinnedMeshRenderer != null)
			{
				return new UnpackedMesh(skinnedMeshRenderer);
			}
			if (meshRenderer != null)
			{
				return new UnpackedMesh(meshRenderer);
			}
			return null;
		}

		public UnpackedMesh(MeshRenderer rigidRenderer)
		{
			this.rigidRenderer = rigidRenderer;
			MeshFilter component = rigidRenderer.GetComponent<MeshFilter>();
			srcMesh = ((component != null) ? component.sharedMesh : null);
			if (srcMesh != null)
			{
				vertices = srcMesh.vertices;
				normals = srcMesh.normals;
				indices = srcMesh.triangles;
				weights = null;
				modelSpaceVertices = srcMesh.vertices;
			}
		}

		public UnpackedMesh(SkinnedMeshRenderer skinnedRenderer)
		{
			this.skinnedRenderer = skinnedRenderer;
			srcMesh = skinnedRenderer.sharedMesh;
			vertices = srcMesh.vertices;
			normals = srcMesh.normals;
			weights = srcMesh.boneWeights;
			indices = srcMesh.triangles;
			Transform[] bones = skinnedRenderer.bones;
			Transform parent = skinnedRenderer.rootBone.parent;
			Matrix4x4[] bindposes = srcMesh.bindposes;
			modelSpaceVertices = new Vector3[vertices.Length];
			for (int i = 0; i < vertices.Length; i++)
			{
				modelSpaceVertices[i] = ApplyBindPoseWeighted(vertices[i], weights[i], bindposes, bones, parent);
			}
		}

		private static Vector3 ApplyBindPoseWeighted(Vector3 inputVertex, BoneWeight weight, Matrix4x4[] bindPoses, Transform[] bones, Transform outputLocalSpace)
		{
			Vector3 position = bindPoses[weight.boneIndex0].MultiplyPoint(inputVertex);
			Vector3 position2 = bindPoses[weight.boneIndex1].MultiplyPoint(inputVertex);
			Vector3 position3 = bindPoses[weight.boneIndex2].MultiplyPoint(inputVertex);
			Vector3 position4 = bindPoses[weight.boneIndex3].MultiplyPoint(inputVertex);
			Vector3 vector = bones[weight.boneIndex0].TransformPoint(position);
			Vector3 vector2 = bones[weight.boneIndex1].TransformPoint(position2);
			Vector3 vector3 = bones[weight.boneIndex2].TransformPoint(position3);
			Vector3 vector4 = bones[weight.boneIndex3].TransformPoint(position4);
			Vector3 position5 = vector * weight.weight0 + vector2 * weight.weight1 + vector3 * weight.weight2 + vector4 * weight.weight3;
			return outputLocalSpace.InverseTransformPoint(position5);
		}
	}
	public static class Utils
	{
		public static Matrix4x4 CreateSkewableTRS(Transform target)
		{
			if (target.parent == null)
			{
				return Matrix4x4.TRS(target.localPosition, target.localRotation, target.localScale);
			}
			Matrix4x4 matrix4x = CreateSkewableTRS(target.parent);
			Matrix4x4 matrix4x2 = Matrix4x4.TRS(target.localPosition, target.localRotation, target.localScale);
			return matrix4x * matrix4x2;
		}

		public static void Inflate(Vector3 point, ref Vector3 min, ref Vector3 max)
		{
			min.x = Mathf.Min(min.x, point.x);
			min.y = Mathf.Min(min.y, point.y);
			min.z = Mathf.Min(min.z, point.z);
			max.x = Mathf.Max(max.x, point.x);
			max.y = Mathf.Max(max.y, point.y);
			max.z = Mathf.Max(max.z, point.z);
		}

		public static Plane[] ConvertToPlanes(Mesh convexMesh, bool show)
		{
			List<Plane> list = new List<Plane>();
			Vector3[] vertices = convexMesh.vertices;
			int[] triangles = convexMesh.triangles;
			for (int i = 0; i < triangles.Length; i += 3)
			{
				Vector3 vector = vertices[triangles[i]];
				Vector3 vector2 = vertices[triangles[i + 1]];
				Vector3 vector3 = vertices[triangles[i + 2]];
				Vector3 normalized = (vector2 - vector).normalized;
				Vector3 normalized2 = (vector3 - vector).normalized;
				Vector3 normalized3 = Vector3.Cross(normalized, normalized2).normalized;
				if (!(normalized3.magnitude > 0.01f))
				{
					continue;
				}
				Plane plane = new Plane(normalized3, vector);
				if (!Contains(plane, list))
				{
					list.Add(plane);
					if (show)
					{
						GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
						gameObject.name = $"{i} : {triangles[i]} / {triangles[i + 1]} / {triangles[i + 2]}";
						gameObject.transform.SetPositionAndRotation(vector, Quaternion.LookRotation(normalized3));
					}
				}
			}
			return list.ToArray();
		}

		public static bool Contains(Plane toTest, List<Plane> planes)
		{
			foreach (Plane plane in planes)
			{
				if (Mathf.Abs(toTest.distance - plane.distance) < 0.01f && Vector3.Angle(toTest.normal, plane.normal) < 0.01f)
				{
					return true;
				}
			}
			return false;
		}

		public static Mesh Clip(Mesh boundingMesh, Mesh inputMesh)
		{
			if (boundingMesh == null || boundingMesh.triangles.Length == 0)
			{
				return null;
			}
			if (inputMesh == null || inputMesh.triangles.Length == 0)
			{
				return null;
			}
			CuttableMesh cuttableMesh = new CuttableMesh(inputMesh);
			MeshCutter meshCutter = new MeshCutter();
			Plane[] array = ConvertToPlanes(boundingMesh, show: false);
			foreach (Plane worldCutPlane in array)
			{
				meshCutter.Cut(cuttableMesh, worldCutPlane);
				Mesh inputMesh2 = meshCutter.GetBackOutput().CreateMesh();
				cuttableMesh = new CuttableMesh(QHullUtil.FindConvexHull("", inputMesh2, showErrorInLog: false));
			}
			Mesh mesh = cuttableMesh.CreateMesh();
			if (mesh.triangles.Length != 0)
			{
				return mesh;
			}
			return null;
		}

		public static float CalcTriangleArea(Vector3 p0, Vector3 p1, Vector3 p2)
		{
			Vector3 lhs = p1 - p0;
			Vector3 rhs = p2 - p0;
			return 0.5f * Vector3.Cross(lhs, rhs).magnitude;
		}

		public static float TimeProgression(float elapsedTime, float maxTime)
		{
			float num = elapsedTime / maxTime;
			return 0f - (0f - num) / (num + 0.5f);
		}

		public static float AsymtopicProgression(float inputProgress, float maxProgression, float rate)
		{
			return 0f - maxProgression * (0f - inputProgress) / (inputProgress + rate);
		}

		public static int FindBoneIndex(SkinnedMeshRenderer skinnedRenderer, Transform bone)
		{
			Transform[] bones = skinnedRenderer.bones;
			for (int i = 0; i < bones.Length; i++)
			{
				if (bones[i] == bone)
				{
					return i;
				}
			}
			return -1;
		}

		public static bool IsWeightAboveThreshold(BoneWeight weights, int ownBoneIndex, float minThreshold, float maxThreshold)
		{
			if (!IsWeightAboveThreshold(weights.boneIndex0, weights.weight0, ownBoneIndex, minThreshold, maxThreshold) && !IsWeightAboveThreshold(weights.boneIndex1, weights.weight1, ownBoneIndex, minThreshold, maxThreshold) && !IsWeightAboveThreshold(weights.boneIndex2, weights.weight2, ownBoneIndex, minThreshold, maxThreshold))
			{
				return IsWeightAboveThreshold(weights.boneIndex3, weights.weight3, ownBoneIndex, minThreshold, maxThreshold);
			}
			return true;
		}

		public static bool IsWeightAboveThreshold(int boneIndex, float boneWeight, int ourIndex, float minThreshold, float maxThreshold)
		{
			if (boneIndex == ourIndex && boneWeight >= minThreshold)
			{
				return boneWeight <= maxThreshold;
			}
			return false;
		}

		public static int NumVerticesForBone(UnpackedMesh mesh, Transform bone, float minThreshold, float maxThreshold)
		{
			int num = 0;
			int ownBoneIndex = FindBoneIndex(mesh.SkinnedRenderer, bone);
			for (int i = 0; i < mesh.NumVertices; i++)
			{
				if (IsWeightAboveThreshold(mesh.BoneWeights[i], ownBoneIndex, minThreshold, maxThreshold))
				{
					num++;
				}
			}
			return num;
		}

		public static void UpdateCachedVertices(IHull hull, Mesh srcMesh)
		{
			Vector3[] vertices = srcMesh.vertices;
			int[] triangles = srcMesh.triangles;
			List<Vector3> list = new List<Vector3>();
			int[] selectedFaces = hull.GetSelectedFaces();
			for (int i = 0; i < hull.NumSelectedTriangles; i++)
			{
				int num = selectedFaces[i];
				int num2 = num * 3;
				int num3 = num * 3 + 1;
				int num4 = num * 3 + 2;
				Vector3 item = vertices[triangles[num2]];
				Vector3 item2 = vertices[triangles[num3]];
				Vector3 item3 = vertices[triangles[num4]];
				list.Add(item);
				list.Add(item2);
				list.Add(item3);
			}
			hull.CachedTriangleVertices = list.ToArray();
		}
	}
	[Serializable]
	public class VhacdParameters
	{
		[Tooltip("maximum concavity")]
		[Range(0f, 1f)]
		public float concavity;

		[Tooltip("controls the bias toward clipping along symmetry planes")]
		[Range(0f, 1f)]
		public float alpha;

		[Tooltip("controls the bias toward clipping along revolution axes")]
		[Range(0f, 1f)]
		public float beta;

		[Tooltip("controls the adaptive sampling of the generated convex-hulls")]
		[Range(0f, 0.01f)]
		public float minVolumePerCH;

		[Tooltip("maximum number of voxels generated during the voxelization stage")]
		[Range(10000f, 64000000f)]
		public uint resolution;

		[Tooltip("controls the maximum number of triangles per convex-hull")]
		[Range(4f, 1024f)]
		public uint maxNumVerticesPerCH;

		[Tooltip("controls the granularity of the search for the \"best\" clipping plane")]
		[Range(1f, 16f)]
		public uint planeDownsampling;

		[Tooltip("controls the precision of the convex-hull generation process during the clipping plane selection stage")]
		[Range(1f, 16f)]
		public uint convexhullDownsampling;

		[Tooltip("enable/disable normalizing the mesh before applying the convex decomposition")]
		[Range(0f, 1f)]
		public uint pca;

		[Tooltip("0: voxel-based (recommended), 1: tetrahedron-based")]
		[Range(0f, 1f)]
		public uint mode;

		[Range(0f, 1f)]
		public uint convexhullApproximation;

		[Tooltip("Enable OpenCL acceleration")]
		[Range(0f, 1f)]
		public uint oclAcceleration;

		public uint maxConvexHulls;

		[Tooltip("This will project the output convex hull vertices onto the original source mesh to increase the floating point accuracy of the results")]
		public bool projectHullVertices;

		public VhacdParameters()
		{
			resolution = 100000u;
			concavity = 0.001f;
			planeDownsampling = 4u;
			convexhullDownsampling = 4u;
			alpha = 0.05f;
			beta = 0.05f;
			pca = 0u;
			mode = 0u;
			maxNumVerticesPerCH = 64u;
			minVolumePerCH = 0.0001f;
			convexhullApproximation = 1u;
			oclAcceleration = 0u;
			maxConvexHulls = 1024u;
			projectHullVertices = true;
		}
	}
}
namespace Technie.PhysicsCreator.Skinned
{
	[Serializable]
	public class BoneHullData : IHull
	{
		public string targetBoneName;

		public HullType type;

		public ColliderType colliderType;

		public Color previewColour;

		public Mesh hullMesh;

		public PhysicsMaterial material;

		public bool isTrigger;

		[SerializeField]
		private float minThreshold;

		[SerializeField]
		private float maxThreshold;

		[SerializeField]
		private List<int> selectedFaces = new List<int>();

		public List<Vector3> cachedTriangleVertices = new List<Vector3>();

		public string Name => targetBoneName;

		public float MinThreshold => minThreshold;

		public float MaxThreshold => maxThreshold;

		public int NumSelectedTriangles => selectedFaces.Count;

		public Vector3[] CachedTriangleVertices
		{
			get
			{
				return cachedTriangleVertices.ToArray();
			}
			set
			{
				cachedTriangleVertices.Clear();
				cachedTriangleVertices.AddRange(value);
			}
		}

		public bool IsTriangleSelected(int triIndex, Renderer renderer, Mesh targetMesh)
		{
			if (type == HullType.Manual)
			{
				return selectedFaces.Contains(triIndex);
			}
			if (type == HullType.Auto)
			{
				SkinnedMeshRenderer skinnedRenderer = renderer as SkinnedMeshRenderer;
				BoneWeight[] boneWeights = targetMesh.boneWeights;
				int[] triangles = targetMesh.triangles;
				int num = triangles[triIndex * 3];
				int num2 = triangles[triIndex * 3 + 1];
				int num3 = triangles[triIndex * 3 + 2];
				BoneWeight weights = boneWeights[num];
				BoneWeight weights2 = boneWeights[num2];
				BoneWeight weights3 = boneWeights[num3];
				Transform bone = SkinnedColliderCreator.FindBone(skinnedRenderer, targetBoneName);
				int ownBoneIndex = Utils.FindBoneIndex(skinnedRenderer, bone);
				if (Utils.IsWeightAboveThreshold(weights, ownBoneIndex, minThreshold, maxThreshold) && Utils.IsWeightAboveThreshold(weights2, ownBoneIndex, minThreshold, maxThreshold) && Utils.IsWeightAboveThreshold(weights3, ownBoneIndex, minThreshold, maxThreshold))
				{
					return true;
				}
			}
			return false;
		}

		public int[] GetSelectedFaces()
		{
			return selectedFaces.ToArray();
		}

		public void AddToSelection(int newTriangleIndex, Mesh srcMesh)
		{
			if (!selectedFaces.Contains(newTriangleIndex))
			{
				selectedFaces.Add(newTriangleIndex);
				Utils.UpdateCachedVertices(this, srcMesh);
			}
		}

		public void RemoveFromSelection(int existingTriangleIndex, Mesh srcMesh)
		{
			selectedFaces.Remove(existingTriangleIndex);
			Utils.UpdateCachedVertices(this, srcMesh);
		}

		public void SetMinThreshold(float newMinThreshold)
		{
			minThreshold = newMinThreshold;
		}

		public void SetMaxThreshold(float newMaxThreshold)
		{
			maxThreshold = newMaxThreshold;
		}

		public void SetThresholds(float newMinThreshold, float newMaxThreshold, SkinnedMeshRenderer renderer, Mesh targetMesh)
		{
			minThreshold = newMinThreshold;
			maxThreshold = newMaxThreshold;
		}

		public void ClearSelectedFaces()
		{
			if (type == HullType.Manual)
			{
				selectedFaces.Clear();
				cachedTriangleVertices.Clear();
			}
		}

		public void SetSelectedFaces(List<int> newSelectedFaceIndices, Mesh srcMesh)
		{
			if (type == HullType.Manual)
			{
				selectedFaces.Clear();
				selectedFaces.AddRange(newSelectedFaceIndices);
				Utils.UpdateCachedVertices(this, srcMesh);
			}
		}

		public Vector3[] GetCachedTriangleVertices()
		{
			return cachedTriangleVertices.ToArray();
		}
	}
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class SkinnedColliderCreator : MonoBehaviour, ICreatorComponent
	{
		public SkinnedMeshRenderer targetSkinnedRenderer;

		public SkinnedColliderEditorData editorData;

		private void OnDestroy()
		{
		}

		private void OnEnable()
		{
			targetSkinnedRenderer = base.gameObject.GetComponent<SkinnedMeshRenderer>();
		}

		public GameObject GetGameObject()
		{
			return base.gameObject;
		}

		public bool HasEditorData()
		{
			return editorData != null;
		}

		public IEditorData GetEditorData()
		{
			return editorData;
		}

		public Transform FindBone(BoneData boneData)
		{
			if (boneData == null)
			{
				return null;
			}
			return FindBone(targetSkinnedRenderer, boneData.targetBoneName);
		}

		public Transform FindBone(BoneHullData hullData)
		{
			if (hullData == null)
			{
				return null;
			}
			return FindBone(targetSkinnedRenderer, hullData.targetBoneName);
		}

		public static Transform FindBone(SkinnedMeshRenderer skinnedRenderer, string nameToFind)
		{
			if (skinnedRenderer == null)
			{
				return null;
			}
			if (nameToFind == null)
			{
				return null;
			}
			Transform[] bones = skinnedRenderer.bones;
			foreach (Transform transform in bones)
			{
				if (transform.name == nameToFind)
				{
					return transform;
				}
			}
			return null;
		}
	}
	public enum BoneJointType
	{
		Fixed,
		Hinge,
		BallAndSocket,
		Tentacle
	}
	public enum AxisType
	{
		XAxis,
		YAxis,
		ZAxis,
		Custom
	}
	[Serializable]
	public class BoneData
	{
		public string targetBoneName;

		public bool addRigidbody;

		public float mass = 1f;

		public float linearDrag;

		public float angularDrag = 0.05f;

		public bool isKinematic;

		public bool addJoint;

		public BoneJointType jointType;

		public Vector3 primaryAxis = Vector3.forward;

		public Vector3 secondaryAxis = Vector3.up;

		public float primaryLowerAngularLimit;

		public float primaryUpperAngularLimit;

		public float secondaryAngularLimit;

		public float tertiaryAngularLimit;

		public float translationLimit;

		public float linearDamping;

		public float angularDamping;

		public BoneData(Transform src)
		{
			targetBoneName = src.name;
		}

		public Vector3 GetThirdAxis()
		{
			return Vector3.Cross(primaryAxis, secondaryAxis);
		}
	}
	public enum HullType
	{
		Auto,
		Manual
	}
	public enum ColliderType
	{
		Convex,
		Capsule,
		Box,
		Sphere
	}
	public class SkinnedColliderEditorData : ScriptableObject, IEditorData
	{
		public const int INVALID_INDEX = -1;

		public SkinnedColliderRuntimeData runtimeData;

		public float defaultMass = 1f;

		public float defaultLinearDrag;

		public float defaultAngularDrag = 0.05f;

		public float defaultLinearDamping;

		public float defaultAngularDamping;

		public PhysicsMaterial defaultMaterial;

		public ColliderType defaultColliderType;

		public List<BoneData> boneData = new List<BoneData>();

		public List<BoneHullData> boneHullData = new List<BoneHullData>();

		private int selectedBoneIndex = -1;

		private int selectedHullIndex = -1;

		private int lastModifiedFrame;

		public Mesh sourceMesh;

		public Hash160 sourceMeshHash;

		public bool suppressMeshModificationWarning;

		public Hash160 CachedHash
		{
			get
			{
				return sourceMeshHash;
			}
			set
			{
				sourceMeshHash = value;
			}
		}

		public bool HasCachedData
		{
			get
			{
				if (sourceMeshHash != null)
				{
					return sourceMeshHash.IsValid();
				}
				return false;
			}
		}

		public Mesh SourceMesh => sourceMesh;

		public IHull[] Hulls => boneHullData.ToArray();

		public bool HasSuppressMeshModificationWarning => suppressMeshModificationWarning;

		public void SetSelection(BoneData bone)
		{
			for (int i = 0; i < boneData.Count; i++)
			{
				if (boneData[i] == bone)
				{
					selectedBoneIndex = i;
					selectedHullIndex = -1;
					break;
				}
			}
			MarkDirty();
		}

		public void SetSelection(BoneHullData hull)
		{
			for (int i = 0; i < boneHullData.Count; i++)
			{
				if (boneHullData[i] == hull)
				{
					selectedHullIndex = i;
					selectedBoneIndex = -1;
					break;
				}
			}
			MarkDirty();
		}

		public void ClearSelection()
		{
			selectedBoneIndex = -1;
			selectedHullIndex = -1;
			MarkDirty();
		}

		public BoneData GetSelectedBone()
		{
			if (selectedBoneIndex >= 0 && selectedBoneIndex < boneData.Count)
			{
				return boneData[selectedBoneIndex];
			}
			return null;
		}

		public BoneHullData GetSelectedHull()
		{
			if (selectedHullIndex >= 0 && selectedHullIndex < boneHullData.Count)
			{
				return boneHullData[selectedHullIndex];
			}
			return null;
		}

		public BoneData GetBoneData(Transform bone)
		{
			if (bone == null)
			{
				return null;
			}
			return GetBoneData(bone.name);
		}

		public BoneData GetBoneData(string boneName)
		{
			foreach (BoneData boneDatum in boneData)
			{
				if (boneDatum.targetBoneName == boneName)
				{
					return boneDatum;
				}
			}
			return null;
		}

		public BoneHullData[] GetBoneHullData(Transform bone)
		{
			if (bone == null)
			{
				return new BoneHullData[0];
			}
			return GetBoneHullData(bone.name);
		}

		public BoneHullData[] GetBoneHullData(string boneName)
		{
			List<BoneHullData> list = new List<BoneHullData>();
			foreach (BoneHullData boneHullDatum in boneHullData)
			{
				if (boneHullDatum.targetBoneName == boneName)
				{
					list.Add(boneHullDatum);
				}
			}
			return list.ToArray();
		}

		public void SetAssetDirty()
		{
			MarkDirty();
		}

		public void MarkDirty()
		{
		}

		public int GetLastModifiedFrame()
		{
			return lastModifiedFrame;
		}

		public void Add(BoneData data)
		{
			boneData.Add(data);
			MarkDirty();
		}

		public void Remove(BoneData data)
		{
			boneData.Remove(data);
			MarkDirty();
		}

		public void Add(BoneHullData data)
		{
			boneHullData.Add(data);
			MarkDirty();
		}

		public void Remove(BoneHullData data)
		{
			boneHullData.Remove(data);
			MarkDirty();
		}
	}
	public class SkinnedColliderRuntimeData : ScriptableObject
	{
	}
}
namespace Technie.PhysicsCreator.Rigid
{
	[Serializable]
	public class Hull : IHull
	{
		public string name = "<unnamed hull>";

		public bool isVisible = true;

		public HullType type = HullType.ConvexHull;

		public Color colour = Color.white;

		public PhysicsMaterial material;

		public bool enableInflation;

		public float inflationAmount = 0.01f;

		public BoxFitMethod boxFitMethod = BoxFitMethod.MinimumVolume;

		public bool isTrigger;

		public bool isChildCollider;

		[SerializeField]
		private List<int> selectedFaces = new List<int>();

		public List<Vector3> cachedTriangleVertices = new List<Vector3>();

		public Mesh collisionMesh;

		public BoxDef collisionBox;

		public Sphere collisionSphere;

		public Mesh faceCollisionMesh;

		public Vector3 faceBoxCenter;

		public Vector3 faceBoxSize;

		public Quaternion faceAsBoxRotation;

		public CapsuleDef collisionCapsule;

		public Mesh[] autoMeshes = new Mesh[0];

		public bool hasColliderError;

		public int numColliderFaces;

		public bool noInputError;

		public string Name => name;

		public int NumSelectedTriangles => selectedFaces.Count;

		public Vector3[] CachedTriangleVertices
		{
			get
			{
				return cachedTriangleVertices.ToArray();
			}
			set
			{
				cachedTriangleVertices.Clear();
				cachedTriangleVertices.AddRange(value);
			}
		}

		public void Destroy()
		{
		}

		public bool ContainsAutoMesh(Mesh m)
		{
			if (autoMeshes != null)
			{
				Mesh[] array = autoMeshes;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == m)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool IsTriangleSelected(int triIndex, Renderer renderer, Mesh targetMesh)
		{
			return selectedFaces.Contains(triIndex);
		}

		public int[] GetSelectedFaces()
		{
			return selectedFaces.ToArray();
		}

		public void ClearSelectedFaces()
		{
			selectedFaces.Clear();
			cachedTriangleVertices.Clear();
		}

		public void AddToSelection(int newTriangleIndex, Mesh srcMesh)
		{
			if (!selectedFaces.Contains(newTriangleIndex))
			{
				selectedFaces.Add(newTriangleIndex);
				Utils.UpdateCachedVertices(this, srcMesh);
			}
		}

		public void RemoveFromSelection(int existingTriangleIndex, Mesh srcMesh)
		{
			selectedFaces.Remove(existingTriangleIndex);
			Utils.UpdateCachedVertices(this, srcMesh);
		}

		public void SetSelectedFaces(List<int> newSelectedFaceIndices, Mesh srcMesh)
		{
			selectedFaces.Clear();
			selectedFaces.AddRange(newSelectedFaceIndices);
			Utils.UpdateCachedVertices(this, srcMesh);
		}

		public int GetSelectedFaceIndex(int index)
		{
			return selectedFaces[index];
		}

		public void FindConvexHull(Vector3[] meshVertices, int[] meshIndices, out Vector3[] hullVertices, out int[] hullIndices, bool showErrorInLog)
		{
			QHullUtil.FindConvexHull(name, selectedFaces.ToArray(), meshVertices, meshIndices, out hullVertices, out hullIndices, showErrorInLog: false);
		}

		public List<Triangle> FindSelectedTriangles(Vector3[] meshVertices, int[] meshIndices)
		{
			List<Triangle> list = new List<Triangle>();
			foreach (int selectedFace in selectedFaces)
			{
				int num = meshIndices[selectedFace * 3];
				int num2 = meshIndices[selectedFace * 3 + 1];
				int num3 = meshIndices[selectedFace * 3 + 2];
				Vector3 p = meshVertices[num];
				Vector3 p2 = meshVertices[num2];
				Vector3 p3 = meshVertices[num3];
				Triangle item = new Triangle(p, p2, p3);
				list.Add(item);
			}
			return list;
		}

		public void FindTriangles(Vector3[] meshVertices, int[] meshIndices, out Vector3[] hullVertices, out int[] hullIndices)
		{
			List<Vector3> list = new List<Vector3>();
			foreach (int selectedFace in selectedFaces)
			{
				int num = meshIndices[selectedFace * 3];
				int num2 = meshIndices[selectedFace * 3 + 1];
				int num3 = meshIndices[selectedFace * 3 + 2];
				Vector3 item = meshVertices[num];
				Vector3 item2 = meshVertices[num2];
				Vector3 item3 = meshVertices[num3];
				list.Add(item);
				list.Add(item2);
				list.Add(item3);
			}
			hullVertices = list.ToArray();
			hullIndices = new int[hullVertices.Length];
			for (int i = 0; i < hullIndices.Length; i++)
			{
				hullIndices[i] = i;
			}
		}

		public Vector3[] GetSelectedVertices(Vector3[] meshVertices, int[] meshIndices)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (int selectedFace in selectedFaces)
			{
				int num = meshIndices[selectedFace * 3];
				int num2 = meshIndices[selectedFace * 3 + 1];
				int num3 = meshIndices[selectedFace * 3 + 2];
				dictionary[num] = num;
				dictionary[num2] = num2;
				dictionary[num3] = num3;
			}
			List<Vector3> list = new List<Vector3>();
			foreach (int key in dictionary.Keys)
			{
				list.Add(meshVertices[key]);
			}
			return list.ToArray();
		}

		public void GenerateCollisionMesh(Vector3[] meshVertices, int[] meshIndices, Mesh[] autoHulls, float faceThickness)
		{
			hasColliderError = false;
			noInputError = false;
			if (selectedFaces.Count == 0)
			{
				noInputError = true;
			}
			if (type == HullType.Box)
			{
				if (selectedFaces.Count <= 0)
				{
					return;
				}
				if (isChildCollider)
				{
					if (boxFitMethod == BoxFitMethod.MinimumVolume)
					{
						RotatedBoxFitter rotatedBoxFitter = new RotatedBoxFitter();
						collisionBox = rotatedBoxFitter.Fit(this, meshVertices, meshIndices);
					}
					else if (boxFitMethod == BoxFitMethod.AlignFaces)
					{
						new FaceAlignmentBoxFitter().Fit(this, meshVertices, meshIndices);
					}
					else if (boxFitMethod == BoxFitMethod.AxisAligned)
					{
						new AxisAlignedBoxFitter().Fit(this, meshVertices, meshIndices);
					}
					return;
				}
				Vector3 min;
				Vector3 max = (min = meshVertices[meshIndices[selectedFaces[0] * 3]]);
				for (int i = 0; i < selectedFaces.Count; i++)
				{
					int num = selectedFaces[i];
					Vector3 point = meshVertices[meshIndices[num * 3]];
					Vector3 point2 = meshVertices[meshIndices[num * 3 + 1]];
					Vector3 point3 = meshVertices[meshIndices[num * 3 + 2]];
					Utils.Inflate(point, ref min, ref max);
					Utils.Inflate(point2, ref min, ref max);
					Utils.Inflate(point3, ref min, ref max);
				}
				collisionBox.collisionBox.center = (min + max) * 0.5f;
				collisionBox.collisionBox.size = max - min;
				collisionBox.boxRotation = Quaternion.identity;
			}
			else if (type == HullType.Capsule)
			{
				if (isChildCollider)
				{
					RotatedCapsuleFitter rotatedCapsuleFitter = new RotatedCapsuleFitter();
					collisionCapsule = rotatedCapsuleFitter.Fit(this, meshVertices, meshIndices);
				}
				else
				{
					AlignedCapsuleFitter alignedCapsuleFitter = new AlignedCapsuleFitter();
					collisionCapsule = alignedCapsuleFitter.Fit(this, meshVertices, meshIndices);
				}
			}
			else if (type == HullType.Sphere)
			{
				SphereFitter sphereFitter = new SphereFitter();
				collisionSphere = sphereFitter.Fit(this, meshVertices, meshIndices);
			}
			else if (type == HullType.ConvexHull)
			{
				if (collisionMesh == null)
				{
					collisionMesh = new Mesh();
				}
				collisionMesh.name = name;
				collisionMesh.triangles = new int[0];
				collisionMesh.vertices = new Vector3[0];
				GenerateConvexHull(this, meshVertices, meshIndices, collisionMesh);
			}
			else if (type == HullType.Face)
			{
				if (faceCollisionMesh == null)
				{
					faceCollisionMesh = new Mesh();
				}
				faceCollisionMesh.name = name;
				faceCollisionMesh.triangles = new int[0];
				faceCollisionMesh.vertices = new Vector3[0];
				GenerateFace(this, meshVertices, meshIndices, faceThickness);
			}
			else if (type == HullType.FaceAsBox)
			{
				if (selectedFaces.Count <= 0)
				{
					return;
				}
				if (isChildCollider)
				{
					Vector3[] vertices = ExtractUniqueVertices(this, meshVertices, meshIndices);
					Vector3 vector = CalcPrimaryAxis(this, meshVertices, meshIndices, !isChildCollider);
					Vector3 rhs = ((Vector3.Dot(vector, Vector3.up) > 0.8f) ? Vector3.right : Vector3.up);
					Vector3 rhs2 = Vector3.Cross(vector, rhs);
					Vector3 primaryUp = Vector3.Cross(vector, rhs2);
					float num2 = 0f;
					float num3 = float.MaxValue;
					Vector3 vector2 = Vector3.zero;
					Vector3 vector3 = Vector3.zero;
					Quaternion quaternion = Quaternion.identity;
					float num4 = 5f;
					float num5 = 0.05f;
					for (float num6 = 0f; num6 <= 360f; num6 += num4)
					{
						Vector3 min2;
						Vector3 max2;
						Quaternion outBasis;
						float num7 = CalcRequiredArea(num6, vector, primaryUp, vertices, out min2, out max2, out outBasis);
						if (num7 < num3)
						{
							num2 = num6;
							num3 = num7;
							vector2 = min2;
							vector3 = max2;
							quaternion = outBasis;
						}
					}
					float num8 = num2 - num4;
					float num9 = num2 + num4;
					for (float num10 = num8; num10 <= num9; num10 += num5)
					{
						Vector3 min3;
						Vector3 max3;
						Quaternion outBasis2;
						float num11 = CalcRequiredArea(num10, vector, primaryUp, vertices, out min3, out max3, out outBasis2);
						if (num11 < num3)
						{
							num2 = num10;
							num3 = num11;
							vector2 = min3;
							vector3 = max3;
							quaternion = outBasis2;
						}
					}
					Vector3 vector4 = (vector2 + vector3) / 2f;
					Vector3 vector5 = vector3 - vector2;
					float num12 = vector5.z - faceThickness;
					vector4.z += num12 * 0.5f;
					vector5.z += num12;
					faceBoxCenter = quaternion * vector4;
					faceBoxSize = vector5;
					faceAsBoxRotation = quaternion;
				}
				else
				{
					Vector3[] array = ExtractUniqueVertices(this, meshVertices, meshIndices);
					Vector3 vector6 = CalcPrimaryAxis(this, meshVertices, meshIndices, !isChildCollider);
					Vector3 min4;
					Vector3 max4 = (min4 = array[0]);
					Vector3[] array2 = array;
					for (int j = 0; j < array2.Length; j++)
					{
						Utils.Inflate(array2[j], ref min4, ref max4);
					}
					Vector3 vector7 = (min4 + max4) / 2f;
					Vector3 vector8 = max4 - min4;
					if (Mathf.Abs(vector6.x) > 0f)
					{
						float num13 = ((vector6.x > 0f) ? 1f : (-1f));
						float num14 = vector8.x - faceThickness;
						vector7.x += num14 * 0.5f * num13;
						vector8.x += num14;
					}
					else if (Mathf.Abs(vector6.y) > 0f)
					{
						float num15 = ((vector6.y > 0f) ? 1f : (-1f));
						float num16 = vector8.y - faceThickness;
						vector7.y += num16 * 0.5f * num15;
						vector8.y += num16;
					}
					else
					{
						float num17 = ((vector6.z > 0f) ? 1f : (-1f));
						float num18 = vector8.z - faceThickness;
						vector7.z += num18 * 0.5f * num17;
						vector8.z += num18;
					}
					faceBoxCenter = vector7;
					faceBoxSize = vector8;
					faceAsBoxRotation = Quaternion.identity;
				}
			}
			else
			{
				if (type != HullType.Auto)
				{
					return;
				}
				if (collisionMesh == null)
				{
					collisionMesh = new Mesh();
				}
				collisionMesh.name = $"{name} bounds";
				collisionMesh.triangles = new int[0];
				collisionMesh.vertices = new Vector3[0];
				GenerateConvexHull(this, meshVertices, meshIndices, collisionMesh);
				List<Mesh> list = new List<Mesh>();
				if (selectedFaces.Count == meshIndices.Length / 3)
				{
					list.AddRange(autoHulls);
				}
				else
				{
					foreach (Mesh inputMesh in autoHulls)
					{
						Mesh mesh = Utils.Clip(collisionMesh, inputMesh);
						if (mesh != null)
						{
							list.Add(mesh);
						}
					}
				}
				for (int k = 0; k < list.Count; k++)
				{
					list[k].name = $"{name}.{k + 1}";
				}
				List<Mesh> list2 = new List<Mesh>();
				if (autoMeshes != null)
				{
					list2.AddRange(autoMeshes);
				}
				while (list2.Count > list.Count)
				{
					list2.RemoveAt(list2.Count - 1);
				}
				while (list2.Count < list.Count)
				{
					list2.Add(new Mesh());
				}
				for (int l = 0; l < list.Count; l++)
				{
					list2[l].Clear();
					list2[l].name = list[l].name;
					list2[l].vertices = list[l].vertices;
					list2[l].triangles = list[l].triangles;
				}
				autoMeshes = list2.ToArray();
			}
		}

		private Vector3[] ExtractUniqueVertices(Hull hull, Vector3[] meshVertices, int[] meshIndices)
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < hull.selectedFaces.Count; i++)
			{
				int num = hull.selectedFaces[i];
				Vector3 vector = meshVertices[meshIndices[num * 3]];
				Vector3 vector2 = meshVertices[meshIndices[num * 3 + 1]];
				Vector3 vector3 = meshVertices[meshIndices[num * 3 + 2]];
				if (!Contains(list, vector))
				{
					list.Add(vector);
				}
				if (!Contains(list, vector2))
				{
					list.Add(vector2);
				}
				if (!Contains(list, vector3))
				{
					list.Add(vector3);
				}
			}
			return list.ToArray();
		}

		private static bool Contains(List<Vector3> list, Vector3 p)
		{
			foreach (Vector3 item in list)
			{
				if (Vector3.Distance(item, p) < 0.0001f)
				{
					return true;
				}
			}
			return false;
		}

		private void GenerateConvexHull(Hull hull, Vector3[] meshVertices, int[] meshIndices, Mesh destMesh)
		{
			QHullUtil.FindConvexHull(hull.name, hull.selectedFaces.ToArray(), meshVertices, meshIndices, out var hullVertices, out var hullIndices, showErrorInLog: true);
			hull.numColliderFaces = hullIndices.Length / 3;
			Console.output.Log("Calculated collider for '" + hull.name + "' has " + hull.numColliderFaces + " faces");
			if (hull.numColliderFaces >= 256)
			{
				hull.hasColliderError = true;
				hull.enableInflation = true;
			}
			hull.collisionMesh.vertices = hullVertices;
			hull.collisionMesh.triangles = hullIndices;
			hull.collisionMesh.RecalculateBounds();
			hull.faceCollisionMesh = null;
		}

		private void GenerateFace(Hull hull, Vector3[] meshVertices, int[] meshIndices, float faceThickness)
		{
			int count = hull.selectedFaces.Count;
			Vector3[] array = new Vector3[count * 3 * 2];
			for (int i = 0; i < hull.selectedFaces.Count; i++)
			{
				int num = hull.selectedFaces[i];
				Vector3 vector = meshVertices[meshIndices[num * 3]];
				Vector3 vector2 = meshVertices[meshIndices[num * 3 + 1]];
				Vector3 vector3 = meshVertices[meshIndices[num * 3 + 2]];
				Vector3 normalized = (vector2 - vector).normalized;
				Vector3 vector4 = Vector3.Cross((vector3 - vector).normalized, normalized);
				int num2 = i * 3 * 2;
				array[num2] = vector;
				array[num2 + 1] = vector2;
				array[num2 + 2] = vector3;
				array[num2 + 3] = vector + vector4 * faceThickness;
				array[num2 + 4] = vector2 + vector4 * faceThickness;
				array[num2 + 5] = vector3 + vector4 * faceThickness;
			}
			int[] array2 = new int[count * 3 * 2];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = j;
			}
			hull.faceCollisionMesh.vertices = array;
			hull.faceCollisionMesh.triangles = array2;
			hull.faceCollisionMesh.RecalculateBounds();
			hull.collisionMesh = null;
		}

		private static float CalcRequiredArea(float angleDeg, Vector3 primaryAxis, Vector3 primaryUp, Vector3[] vertices, out Vector3 min, out Vector3 max, out Quaternion outBasis)
		{
			if (vertices.Length == 0)
			{
				min = Vector3.zero;
				max = Vector3.zero;
				outBasis = Quaternion.identity;
				return 0f;
			}
			Vector3 upwards = Quaternion.AngleAxis(angleDeg, primaryAxis) * primaryUp;
			Quaternion quaternion = Quaternion.LookRotation(primaryAxis, upwards);
			Quaternion quaternion2 = Quaternion.Inverse(quaternion);
			max = (min = quaternion2 * vertices[0]);
			foreach (Vector3 vector in vertices)
			{
				Utils.Inflate(quaternion2 * vector, ref min, ref max);
			}
			outBasis = quaternion;
			Vector3 vector2 = max - min;
			return vector2.x * vector2.y;
		}

		private static Vector3 CalcPrimaryAxis(Hull hull, Vector3[] meshVertices, int[] meshIndices, bool snapToAxies)
		{
			int num = 0;
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < hull.selectedFaces.Count; i++)
			{
				int num2 = hull.selectedFaces[i];
				Vector3 vector = meshVertices[meshIndices[num2 * 3]];
				Vector3 vector2 = meshVertices[meshIndices[num2 * 3 + 1]];
				Vector3 vector3 = meshVertices[meshIndices[num2 * 3 + 2]];
				Vector3 normalized = (vector2 - vector).normalized;
				Vector3 normalized2 = (vector3 - vector).normalized;
				Vector3 vector4 = Vector3.Cross(normalized, normalized2);
				zero += vector4;
				num++;
			}
			Vector3 vector5 = zero / num;
			if (vector5.magnitude < 0.0001f)
			{
				return Vector3.up;
			}
			if (snapToAxies)
			{
				float num3 = Mathf.Abs(vector5.x);
				float num4 = Mathf.Abs(vector5.y);
				float num5 = Mathf.Abs(vector5.z);
				if (num3 > num4 && num3 > num5)
				{
					return new Vector3(((double)vector5.x > 0.0) ? 1f : (-1f), 0f, 0f);
				}
				if (num4 > num5)
				{
					return new Vector3(0f, ((double)vector5.y > 0.0) ? 1f : (-1f), 0f);
				}
				return new Vector3(0f, 0f, ((double)vector5.z > 0.0) ? 1f : (-1f));
			}
			return vector5.normalized;
		}
	}
}
namespace Technie.PhysicsCreator.QHull
{
	public class Face
	{
		public HalfEdge he0;

		private Vector3d normal;

		public double area;

		private Point3d centroid;

		public double planeOffset;

		public int index;

		public int numVerts;

		public Face next;

		public const int VISIBLE = 1;

		public const int NON_CONVEX = 2;

		public const int DELETED = 3;

		public int mark = 1;

		public Vertex outside;

		public void computeCentroid(Point3d centroid)
		{
			centroid.setZero();
			HalfEdge halfEdge = he0;
			do
			{
				centroid.add(halfEdge.head().pnt);
				halfEdge = halfEdge.next;
			}
			while (halfEdge != he0);
			centroid.scale(1.0 / (double)numVerts);
		}

		public void computeNormal(Vector3d normal, double minArea)
		{
			computeNormal(normal);
			if (!(area < minArea))
			{
				return;
			}
			HalfEdge halfEdge = null;
			double num = 0.0;
			HalfEdge halfEdge2 = he0;
			do
			{
				double num2 = halfEdge2.lengthSquared();
				if (num2 > num)
				{
					halfEdge = halfEdge2;
					num = num2;
				}
				halfEdge2 = halfEdge2.next;
			}
			while (halfEdge2 != he0);
			Point3d pnt = halfEdge.head().pnt;
			Point3d pnt2 = halfEdge.tail().pnt;
			double num3 = Math.Sqrt(num);
			double num4 = (pnt.x - pnt2.x) / num3;
			double num5 = (pnt.y - pnt2.y) / num3;
			double num6 = (pnt.z - pnt2.z) / num3;
			double num7 = normal.x * num4 + normal.y * num5 + normal.z * num6;
			normal.x -= num7 * num4;
			normal.y -= num7 * num5;
			normal.z -= num7 * num6;
			normal.normalize();
		}

		public void computeNormal(Vector3d normal)
		{
			HalfEdge halfEdge = he0.next;
			HalfEdge halfEdge2 = halfEdge.next;
			Point3d pnt = he0.head().pnt;
			Point3d pnt2 = halfEdge.head().pnt;
			double num = pnt2.x - pnt.x;
			double num2 = pnt2.y - pnt.y;
			double num3 = pnt2.z - pnt.z;
			normal.setZero();
			numVerts = 2;
			while (halfEdge2 != he0)
			{
				double num4 = num;
				double num5 = num2;
				double num6 = num3;
				Point3d pnt3 = halfEdge2.head().pnt;
				num = pnt3.x - pnt.x;
				num2 = pnt3.y - pnt.y;
				num3 = pnt3.z - pnt.z;
				normal.x += num5 * num3 - num6 * num2;
				normal.y += num6 * num - num4 * num3;
				normal.z += num4 * num2 - num5 * num;
				halfEdge2 = halfEdge2.next;
				numVerts++;
			}
			area = normal.norm();
			normal.scale(1.0 / area);
		}

		private void computeNormalAndCentroid()
		{
			computeNormal(normal);
			computeCentroid(centroid);
			planeOffset = normal.dot(centroid);
			int num = 0;
			HalfEdge halfEdge = he0;
			do
			{
				num++;
				halfEdge = halfEdge.next;
			}
			while (halfEdge != he0);
			if (num != numVerts)
			{
				throw new InternalErrorException("face " + getVertexString() + " numVerts=" + numVerts + " should be " + num);
			}
		}

		private void computeNormalAndCentroid(double minArea)
		{
			computeNormal(normal, minArea);
			computeCentroid(centroid);
			planeOffset = normal.dot(centroid);
		}

		public static Face createTriangle(Vertex v0, Vertex v1, Vertex v2)
		{
			return createTriangle(v0, v1, v2, 0.0);
		}

		public static Face createTriangle(Vertex v0, Vertex v1, Vertex v2, double minArea)
		{
			Face face = new Face();
			HalfEdge halfEdge = new HalfEdge(v0, face);
			HalfEdge halfEdge2 = new HalfEdge(v1, face);
			HalfEdge halfEdge3 = (halfEdge.prev = new HalfEdge(v2, face));
			halfEdge.next = halfEdge2;
			halfEdge2.prev = halfEdge;
			halfEdge2.next = halfEdge3;
			halfEdge3.prev = halfEdge2;
			halfEdge3.next = halfEdge;
			face.he0 = halfEdge;
			face.computeNormalAndCentroid(minArea);
			return face;
		}

		public static Face create(Vertex[] vtxArray, int[] indices)
		{
			Face face = new Face();
			HalfEdge halfEdge = null;
			for (int i = 0; i < indices.Length; i++)
			{
				HalfEdge halfEdge2 = new HalfEdge(vtxArray[indices[i]], face);
				if (halfEdge != null)
				{
					halfEdge2.setPrev(halfEdge);
					halfEdge.setNext(halfEdge2);
				}
				else
				{
					face.he0 = halfEdge2;
				}
				halfEdge = halfEdge2;
			}
			face.he0.setPrev(halfEdge);
			halfEdge.setNext(face.he0);
			face.computeNormalAndCentroid();
			return face;
		}

		public Face()
		{
			normal = new Vector3d();
			centroid = new Point3d();
			mark = 1;
		}

		public HalfEdge getEdge(int i)
		{
			HalfEdge prev = he0;
			while (i > 0)
			{
				prev = prev.next;
				i--;
			}
			while (i < 0)
			{
				prev = prev.prev;
				i++;
			}
			return prev;
		}

		public HalfEdge getFirstEdge()
		{
			return he0;
		}

		public HalfEdge findEdge(Vertex vt, Vertex vh)
		{
			HalfEdge halfEdge = he0;
			do
			{
				if (halfEdge.head() == vh && halfEdge.tail() == vt)
				{
					return halfEdge;
				}
				halfEdge = halfEdge.next;
			}
			while (halfEdge != he0);
			return null;
		}

		public double distanceToPlane(Point3d p)
		{
			return normal.x * p.x + normal.y * p.y + normal.z * p.z - planeOffset;
		}

		public Vector3d getNormal()
		{
			return normal;
		}

		public Point3d getCentroid()
		{
			return centroid;
		}

		public int numVertices()
		{
			return numVerts;
		}

		public string getVertexString()
		{
			string text = null;
			HalfEdge halfEdge = he0;
			do
			{
				text = ((text != null) ? (text + " " + halfEdge.head().index) : (halfEdge.head().index.ToString() ?? ""));
				halfEdge = halfEdge.next;
			}
			while (halfEdge != he0);
			return text;
		}

		public void getVertexIndices(int[] idxs)
		{
			HalfEdge halfEdge = he0;
			int num = 0;
			do
			{
				idxs[num++] = halfEdge.head().index;
				halfEdge = halfEdge.next;
			}
			while (halfEdge != he0);
		}

		private Face connectHalfEdges(HalfEdge hedgePrev, HalfEdge hedge)
		{
			Face result = null;
			if (hedgePrev.oppositeFace() == hedge.oppositeFace())
			{
				Face face = hedge.oppositeFace();
				if (hedgePrev == he0)
				{
					he0 = hedge;
				}
				HalfEdge opposite;
				if (face.numVertices() == 3)
				{
					opposite = hedge.getOpposite().prev.getOpposite();
					face.mark = 3;
					result = face;
				}
				else
				{
					opposite = hedge.getOpposite().next;
					if (face.he0 == opposite.prev)
					{
						face.he0 = opposite;
					}
					opposite.prev = opposite.prev.prev;
					opposite.prev.next = opposite;
				}
				hedge.prev = hedgePrev.prev;
				hedge.prev.next = hedge;
				hedge.opposite = opposite;
				opposite.opposite = hedge;
				face.computeNormalAndCentroid();
			}
			else
			{
				hedgePrev.next = hedge;
				hedge.prev = hedgePrev;
			}
			return result;
		}

		public void checkConsistency()
		{
			HalfEdge halfEdge = he0;
			double num = 0.0;
			int num2 = 0;
			if (numVerts < 3)
			{
				throw new InternalErrorException("degenerate face: " + getVertexString());
			}
			do
			{
				HalfEdge opposite = halfEdge.getOpposite();
				if (opposite == null)
				{
					throw new InternalErrorException("face " + getVertexString() + ": unreflected half edge " + halfEdge.getVertexString());
				}
				if (opposite.getOpposite() != halfEdge)
				{
					throw new InternalErrorException("face " + getVertexString() + ": opposite half edge " + opposite.getVertexString() + " has opposite " + opposite.getOpposite().getVertexString());
				}
				if (opposite.head() != halfEdge.tail() || halfEdge.head() != opposite.tail())
				{
					throw new InternalErrorException("face " + getVertexString() + ": half edge " + halfEdge.getVertexString() + " reflected by " + opposite.getVertexString());
				}
				Face face = opposite.face;
				if (face == null)
				{
					throw new InternalErrorException("face " + getVertexString() + ": no face on half edge " + opposite.getVertexString());
				}
				if (face.mark == 3)
				{
					throw new InternalErrorException("face " + getVertexString() + ": opposite face " + face.getVertexString() + " not on hull");
				}
				double num3 = Math.Abs(distanceToPlane(halfEdge.head().pnt));
				if (num3 > num)
				{
					num = num3;
				}
				num2++;
				halfEdge = halfEdge.next;
			}
			while (halfEdge != he0);
			if (num2 != numVerts)
			{
				throw new InternalErrorException("face " + getVertexString() + " numVerts=" + numVerts + " should be " + num2);
			}
		}

		public int mergeAdjacentFace(HalfEdge hedgeAdj, Face[] discarded)
		{
			Face face = hedgeAdj.oppositeFace();
			int result = 0;
			discarded[result++] = face;
			face.mark = 3;
			HalfEdge opposite = hedgeAdj.getOpposite();
			HalfEdge prev = hedgeAdj.prev;
			HalfEdge halfEdge = hedgeAdj.next;
			HalfEdge prev2 = opposite.prev;
			HalfEdge halfEdge2 = opposite.next;
			while (prev.oppositeFace() == face)
			{
				prev = prev.prev;
				halfEdge2 = halfEdge2.next;
			}
			while (halfEdge.oppositeFace() == face)
			{
				prev2 = prev2.prev;
				halfEdge = halfEdge.next;
			}
			for (HalfEdge halfEdge3 = halfEdge2; halfEdge3 != prev2.next; halfEdge3 = halfEdge3.next)
			{
				halfEdge3.face = this;
			}
			if (hedgeAdj == he0)
			{
				he0 = halfEdge;
			}
			Face face2 = connectHalfEdges(prev2, halfEdge);
			if (face2 != null)
			{
				discarded[result++] = face2;
			}
			face2 = connectHalfEdges(prev, halfEdge2);
			if (face2 != null)
			{
				discarded[result++] = face2;
			}
			computeNormalAndCentroid();
			checkConsistency();
			return result;
		}

		private double areaSquared(HalfEdge hedge0, HalfEdge hedge1)
		{
			Point3d pnt = hedge0.tail().pnt;
			Point3d pnt2 = hedge0.head().pnt;
			Point3d pnt3 = hedge1.head().pnt;
			double num = pnt2.x - pnt.x;
			double num2 = pnt2.y - pnt.y;
			double num3 = pnt2.z - pnt.z;
			double num4 = pnt3.x - pnt.x;
			double num5 = pnt3.y - pnt.y;
			double num6 = pnt3.z - pnt.z;
			double num7 = num2 * num6 - num3 * num5;
			double num8 = num3 * num4 - num * num6;
			double num9 = num * num5 - num2 * num4;
			return num7 * num7 + num8 * num8 + num9 * num9;
		}

		public void triangulate(FaceList newFaces, double minArea)
		{
			if (numVertices() < 4)
			{
				return;
			}
			Vertex v = he0.head();
			HalfEdge halfEdge = he0.next;
			HalfEdge opposite = halfEdge.opposite;
			Face face = null;
			for (halfEdge = halfEdge.next; halfEdge != he0.prev; halfEdge = halfEdge.next)
			{
				Face face2 = createTriangle(v, halfEdge.prev.head(), halfEdge.head(), minArea);
				face2.he0.next.setOpposite(opposite);
				face2.he0.prev.setOpposite(halfEdge.opposite);
				opposite = face2.he0;
				newFaces.add(face2);
				if (face == null)
				{
					face = face2;
				}
			}
			halfEdge = new HalfEdge(he0.prev.prev.head(), this);
			halfEdge.setOpposite(opposite);
			halfEdge.prev = he0;
			halfEdge.prev.next = halfEdge;
			halfEdge.next = he0.prev;
			halfEdge.next.prev = halfEdge;
			computeNormalAndCentroid(minArea);
			checkConsistency();
			for (Face face3 = face; face3 != null; face3 = face3.next)
			{
				face3.checkConsistency();
			}
		}
	}
	public class FaceList
	{
		private Face head;

		private Face tail;

		public void clear()
		{
			head = (tail = null);
		}

		public void add(Face vtx)
		{
			if (head == null)
			{
				head = vtx;
			}
			else
			{
				tail.next = vtx;
			}
			vtx.next = null;
			tail = vtx;
		}

		public Face first()
		{
			return head;
		}

		public bool isEmpty()
		{
			return head == null;
		}
	}
	public class HalfEdge
	{
		public Vertex vertex;

		public Face face;

		public HalfEdge next;

		public HalfEdge prev;

		public HalfEdge opposite;

		public HalfEdge(Vertex v, Face f)
		{
			vertex = v;
			face = f;
		}

		public HalfEdge()
		{
		}

		public void setNext(HalfEdge edge)
		{
			next = edge;
		}

		public HalfEdge getNext()
		{
			return next;
		}

		public void setPrev(HalfEdge edge)
		{
			prev = edge;
		}

		public HalfEdge getPrev()
		{
			return prev;
		}

		public Face getFace()
		{
			return face;
		}

		public HalfEdge getOpposite()
		{
			return opposite;
		}

		public void setOpposite(HalfEdge edge)
		{
			opposite = edge;
			edge.opposite = this;
		}

		public Vertex head()
		{
			return vertex;
		}

		public Vertex tail()
		{
			if (prev == null)
			{
				return null;
			}
			return prev.vertex;
		}

		public Face oppositeFace()
		{
			if (opposite == null)
			{
				return null;
			}
			return opposite.face;
		}

		public string getVertexString()
		{
			if (tail() != null)
			{
				return tail().index + "-" + head().index;
			}
			return "?-" + head().index;
		}

		public double length()
		{
			if (tail() != null)
			{
				return head().pnt.distance(tail().pnt);
			}
			return -1.0;
		}

		public double lengthSquared()
		{
			if (tail() != null)
			{
				return head().pnt.distanceSquared(tail().pnt);
			}
			return -1.0;
		}
	}
	public class InternalErrorException : SystemException
	{
		public InternalErrorException(string msg)
			: base(msg)
		{
		}
	}
	public class Point3d : Vector3d
	{
		public Point3d()
		{
		}

		public Point3d(Vector3d v)
		{
			set(v);
		}

		public Point3d(double x, double y, double z)
		{
			set(x, y, z);
		}
	}
	public class QuickHull3D
	{
		public const int CLOCKWISE = 1;

		public const int INDEXED_FROM_ONE = 2;

		public const int INDEXED_FROM_ZERO = 4;

		public const int POINT_RELATIVE = 8;

		public const double AUTOMATIC_TOLERANCE = -1.0;

		protected int findIndex = -1;

		protected double charLength;

		protected bool debug;

		protected Vertex[] pointBuffer = new Vertex[0];

		protected int[] vertexPointIndices = new int[0];

		private Face[] discardedFaces = new Face[3];

		private Vertex[] maxVtxs = new Vertex[3];

		private Vertex[] minVtxs = new Vertex[3];

		protected List<Face> faces = new List<Face>(16);

		protected List<HalfEdge> horizon = new List<HalfEdge>(16);

		private FaceList newFaces = new FaceList();

		private VertexList unclaimed = new VertexList();

		private VertexList claimed = new VertexList();

		protected int numVertices;

		protected int numFaces;

		protected int numPoints;

		protected double explicitTolerance = -1.0;

		protected double tolerance;

		private const double DOUBLE_PREC = 2.220446049250313E-16;

		private const int NONCONVEX_WRT_LARGER_FACE = 1;

		private const int NONCONVEX = 2;

		public bool getDebug()
		{
			return debug;
		}

		public void setDebug(bool enable)
		{
			debug = enable;
		}

		public double getDistanceTolerance()
		{
			return tolerance;
		}

		public void setExplicitDistanceTolerance(double tol)
		{
			explicitTolerance = tol;
		}

		public double getExplicitDistanceTolerance()
		{
			return explicitTolerance;
		}

		private void addPointToFace(Vertex vtx, Face face)
		{
			vtx.face = face;
			if (face.outside == null)
			{
				claimed.add(vtx);
			}
			else
			{
				claimed.insertBefore(vtx, face.outside);
			}
			face.outside = vtx;
		}

		private void removePointFromFace(Vertex vtx, Face face)
		{
			if (vtx == face.outside)
			{
				if (vtx.next != null && vtx.next.face == face)
				{
					face.outside = vtx.next;
				}
				else
				{
					face.outside = null;
				}
			}
			claimed.delete(vtx);
		}

		private Vertex removeAllPointsFromFace(Face face)
		{
			if (face.outside != null)
			{
				Vertex vertex = face.outside;
				while (vertex.next != null && vertex.next.face == face)
				{
					vertex = vertex.next;
				}
				claimed.delete(face.outside, vertex);
				vertex.next = null;
				return face.outside;
			}
			return null;
		}

		public QuickHull3D()
		{
		}

		public QuickHull3D(double[] coords)
		{
			build(coords, coords.Length / 3);
		}

		public QuickHull3D(Point3d[] points)
		{
			build(points, points.Length);
		}

		private HalfEdge findHalfEdge(Vertex tail, Vertex head)
		{
			foreach (Face face in faces)
			{
				HalfEdge halfEdge = face.findEdge(tail, head);
				if (halfEdge != null)
				{
					return halfEdge;
				}
			}
			return null;
		}

		protected void setHull(double[] coords, int nump, int[][] faceIndices, int numf)
		{
			initBuffers(nump);
			setPoints(coords, nump);
			computeMaxAndMin();
			for (int i = 0; i < numf; i++)
			{
				Face face = Face.create(pointBuffer, faceIndices[i]);
				HalfEdge halfEdge = face.he0;
				do
				{
					HalfEdge halfEdge2 = findHalfEdge(halfEdge.head(), halfEdge.tail());
					if (halfEdge2 != null)
					{
						halfEdge.setOpposite(halfEdge2);
					}
					halfEdge = halfEdge.next;
				}
				while (halfEdge != face.he0);
				faces.Add(face);
			}
		}

		public void build(double[] coords)
		{
			build(coords, coords.Length / 3);
		}

		public void build(double[] coords, int nump)
		{
			if (nump < 4)
			{
				throw new SystemException("Less than four input points specified");
			}
			if (coords.Length / 3 < nump)
			{
				throw new SystemException("Coordinate array too small for specified number of points");
			}
			initBuffers(nump);
			setPoints(coords, nump);
			buildHull();
		}

		public void build(Point3d[] points)
		{
			build(points, points.Length);
		}

		public void build(Point3d[] points, int nump)
		{
			if (nump < 4)
			{
				throw new SystemException("Less than four input points specified");
			}
			if (points.Length < nump)
			{
				throw new SystemException("Point array too small for specified number of points");
			}
			initBuffers(nump);
			setPoints(points, nump);
			buildHull();
		}

		public void triangulate()
		{
			double minArea = 1000.0 * charLength * 2.220446049250313E-16;
			newFaces.clear();
			foreach (Face face2 in faces)
			{
				if (face2.mark == 1)
				{
					face2.triangulate(newFaces, minArea);
				}
			}
			for (Face face = newFaces.first(); face != null; face = face.next)
			{
				faces.Add(face);
			}
		}

		protected void initBuffers(int nump)
		{
			if (pointBuffer.Length < nump)
			{
				Vertex[] array = new Vertex[nump];
				vertexPointIndices = new int[nump];
				for (int i = 0; i < pointBuffer.Length; i++)
				{
					array[i] = pointBuffer[i];
				}
				for (int j = pointBuffer.Length; j < nump; j++)
				{
					array[j] = new Vertex();
				}
				pointBuffer = array;
			}
			faces.Clear();
			claimed.clear();
			numFaces = 0;
			numPoints = nump;
		}

		protected void setPoints(double[] coords, int nump)
		{
			for (int i = 0; i < nump; i++)
			{
				Vertex obj = pointBuffer[i];
				obj.pnt.set(coords[i * 3], coords[i * 3 + 1], coords[i * 3 + 2]);
				obj.index = i;
			}
		}

		protected void setPoints(Point3d[] pnts, int nump)
		{
			for (int i = 0; i < nump; i++)
			{
				Vertex obj = pointBuffer[i];
				obj.pnt.set(pnts[i]);
				obj.index = i;
			}
		}

		protected void computeMaxAndMin()
		{
			Vector3d vector3d = new Vector3d();
			Vector3d vector3d2 = new Vector3d();
			for (int i = 0; i < 3; i++)
			{
				maxVtxs[i] = (minVtxs[i] = pointBuffer[0]);
			}
			vector3d.set(pointBuffer[0].pnt);
			vector3d2.set(pointBuffer[0].pnt);
			for (int j = 1; j < numPoints; j++)
			{
				Point3d pnt = pointBuffer[j].pnt;
				if (pnt.x > vector3d.x)
				{
					vector3d.x = pnt.x;
					maxVtxs[0] = pointBuffer[j];
				}
				else if (pnt.x < vector3d2.x)
				{
					vector3d2.x = pnt.x;
					minVtxs[0] = pointBuffer[j];
				}
				if (pnt.y > vector3d.y)
				{
					vector3d.y = pnt.y;
					maxVtxs[1] = pointBuffer[j];
				}
				else if (pnt.y < vector3d2.y)
				{
					vector3d2.y = pnt.y;
					minVtxs[1] = pointBuffer[j];
				}
				if (pnt.z > vector3d.z)
				{
					vector3d.z = pnt.z;
					maxVtxs[2] = pointBuffer[j];
				}
				else if (pnt.z < vector3d2.z)
				{
					vector3d2.z = pnt.z;
					minVtxs[2] = pointBuffer[j];
				}
			}
			charLength = Math.Max(vector3d.x - vector3d2.x, vector3d.y - vector3d2.y);
			charLength = Math.Max(vector3d.z - vector3d2.z, charLength);
			if (explicitTolerance == -1.0)
			{
				tolerance = 6.661338147750939E-16 * (Math.Max(Math.Abs(vector3d.x), Math.Abs(vector3d2.x)) + Math.Max(Math.Abs(vector3d.y), Math.Abs(vector3d2.y)) + Math.Max(Math.Abs(vector3d.z), Math.Abs(vector3d2.z)));
			}
			else
			{
				tolerance = explicitTolerance;
			}
		}

		protected void createInitialSimplex()
		{
			double num = 0.0;
			int num2 = 0;
			for (int i = 0; i < 3; i++)
			{
				double num3 = maxVtxs[i].pnt.get(i) - minVtxs[i].pnt.get(i);
				if (num3 > num)
				{
					num = num3;
					num2 = i;
				}
			}
			if (num <= tolerance)
			{
				throw new SystemException("Input points appear to be coincident");
			}
			Vertex[] array = new Vertex[4]
			{
				maxVtxs[num2],
				minVtxs[num2],
				null,
				null
			};
			Vector3d vector3d = new Vector3d();
			Vector3d vector3d2 = new Vector3d();
			Vector3d vector3d3 = new Vector3d();
			Vector3d vector3d4 = new Vector3d();
			double num4 = 0.0;
			vector3d.sub(array[1].pnt, array[0].pnt);
			vector3d.normalize();
			for (int j = 0; j < numPoints; j++)
			{
				vector3d2.sub(pointBuffer[j].pnt, array[0].pnt);
				vector3d4.cross(vector3d, vector3d2);
				double num5 = vector3d4.normSquared();
				if (num5 > num4 && pointBuffer[j] != array[0] && pointBuffer[j] != array[1])
				{
					num4 = num5;
					array[2] = pointBuffer[j];
					vector3d3.set(vector3d4);
				}
			}
			if (Math.Sqrt(num4) <= 100.0 * tolerance)
			{
				throw new SystemException("Input points appear to be colinear");
			}
			vector3d3.normalize();
			double num6 = 0.0;
			double num7 = array[2].pnt.dot(vector3d3);
			for (int k = 0; k < numPoints; k++)
			{
				double num8 = Math.Abs(pointBuffer[k].pnt.dot(vector3d3) - num7);
				if (num8 > num6 && pointBuffer[k] != array[0] && pointBuffer[k] != array[1] && pointBuffer[k] != array[2])
				{
					num6 = num8;
					array[3] = pointBuffer[k];
				}
			}
			if (Math.Abs(num6) <= 100.0 * tolerance)
			{
				throw new SystemException("Input points appear to be coplanar");
			}
			Face[] array2 = new Face[4];
			if (array[3].pnt.dot(vector3d3) - num7 < 0.0)
			{
				array2[0] = Face.createTriangle(array[0], array[1], array[2]);
				array2[1] = Face.createTriangle(array[3], array[1], array[0]);
				array2[2] = Face.createTriangle(array[3], array[2], array[1]);
				array2[3] = Face.createTriangle(array[3], array[0], array[2]);
				for (int l = 0; l < 3; l++)
				{
					int num9 = (l + 1) % 3;
					array2[l + 1].getEdge(1).setOpposite(array2[num9 + 1].getEdge(0));
					array2[l + 1].getEdge(2).setOpposite(array2[0].getEdge(num9));
				}
			}
			else
			{
				array2[0] = Face.createTriangle(array[0], array[2], array[1]);
				array2[1] = Face.createTriangle(array[3], array[0], array[1]);
				array2[2] = Face.createTriangle(array[3], array[1], array[2]);
				array2[3] = Face.createTriangle(array[3], array[2], array[0]);
				for (int m = 0; m < 3; m++)
				{
					int num10 = (m + 1) % 3;
					array2[m + 1].getEdge(0).setOpposite(array2[num10 + 1].getEdge(1));
					array2[m + 1].getEdge(2).setOpposite(array2[0].getEdge((3 - m) % 3));
				}
			}
			for (int n = 0; n < 4; n++)
			{
				faces.Add(array2[n]);
			}
			for (int num11 = 0; num11 < numPoints; num11++)
			{
				Vertex vertex = pointBuffer[num11];
				if (vertex == array[0] || vertex == array[1] || vertex == array[2] || vertex == array[3])
				{
					continue;
				}
				num6 = tolerance;
				Face face = null;
				for (int num12 = 0; num12 < 4; num12++)
				{
					double num13 = array2[num12].distanceToPlane(vertex.pnt);
					if (num13 > num6)
					{
						face = array2[num12];
						num6 = num13;
					}
				}
				if (face != null)
				{
					addPointToFace(vertex, face);
				}
			}
		}

		public int getNumVertices()
		{
			return numVertices;
		}

		public Point3d[] getVertices()
		{
			Point3d[] array = new Point3d[numVertices];
			for (int i = 0; i < numVertices; i++)
			{
				array[i] = pointBuffer[vertexPointIndices[i]].pnt;
			}
			return array;
		}

		public int getVertices(double[] coords)
		{
			for (int i = 0; i < numVertices; i++)
			{
				Point3d pnt = pointBuffer[vertexPointIndices[i]].pnt;
				coords[i * 3] = pnt.x;
				coords[i * 3 + 1] = pnt.y;
				coords[i * 3 + 2] = pnt.z;
			}
			return numVertices;
		}

		public int[] getVertexPointIndices()
		{
			int[] array = new int[numVertices];
			for (int i = 0; i < numVertices; i++)
			{
				array[i] = vertexPointIndices[i];
			}
			return array;
		}

		public int getNumFaces()
		{
			return faces.Count;
		}

		public int[][] getFaces()
		{
			return getFaces(0);
		}

		public int[][] getFaces(int indexFlags)
		{
			int[][] array = new int[faces.Count][];
			int num = 0;
			foreach (Face face in faces)
			{
				array[num] = new int[face.numVertices()];
				getFaceIndices(array[num], face, indexFlags);
				num++;
			}
			return array;
		}

		private void getFaceIndices(int[] indices, Face face, int flags)
		{
			bool flag = (flags & 1) == 0;
			bool flag2 = (flags & 2) != 0;
			bool flag3 = (flags & 8) != 0;
			HalfEdge halfEdge = face.he0;
			int num = 0;
			do
			{
				int num2 = halfEdge.head().index;
				if (flag3)
				{
					num2 = vertexPointIndices[num2];
				}
				if (flag2)
				{
					num2++;
				}
				indices[num++] = num2;
				halfEdge = (flag ? halfEdge.next : halfEdge.prev);
			}
			while (halfEdge != face.he0);
		}

		protected void resolveUnclaimedPoints(FaceList newFaces)
		{
			Vertex vertex = unclaimed.first();
			for (Vertex vertex2 = vertex; vertex2 != null; vertex2 = vertex)
			{
				vertex = vertex2.next;
				double num = tolerance;
				Face face = null;
				for (Face face2 = newFaces.first(); face2 != null; face2 = face2.next)
				{
					if (face2.mark == 1)
					{
						double num2 = face2.distanceToPlane(vertex2.pnt);
						if (num2 > num)
						{
							num = num2;
							face = face2;
						}
						if (num > 1000.0 * tolerance)
						{
							break;
						}
					}
				}
				if (face != null)
				{
					addPointToFace(vertex2, face);
				}
			}
		}

		protected void deleteFacePoints(Face face, Face absorbingFace)
		{
			Vertex vertex = removeAllPointsFromFace(face);
			if (vertex == null)
			{
				return;
			}
			if (absorbingFace == null)
			{
				unclaimed.addAll(vertex);
				return;
			}
			Vertex vertex2 = vertex;
			for (Vertex vertex3 = vertex2; vertex3 != null; vertex3 = vertex2)
			{
				vertex2 = vertex3.next;
				if (absorbingFace.distanceToPlane(vertex3.pnt) > tolerance)
				{
					addPointToFace(vertex3, absorbingFace);
				}
				else
				{
					unclaimed.add(vertex3);
				}
			}
		}

		protected double oppFaceDistance(HalfEdge he)
		{
			return he.face.distanceToPlane(he.opposite.face.getCentroid());
		}

		private bool doAdjacentMerge(Face face, int mergeType)
		{
			HalfEdge halfEdge = face.he0;
			bool flag = true;
			do
			{
				Face face2 = halfEdge.oppositeFace();
				bool flag2 = false;
				if (mergeType == 2)
				{
					if (oppFaceDistance(halfEdge) > 0.0 - tolerance || oppFaceDistance(halfEdge.opposite) > 0.0 - tolerance)
					{
						flag2 = true;
					}
				}
				else if (face.area > face2.area)
				{
					if (oppFaceDistance(halfEdge) > 0.0 - tolerance)
					{
						flag2 = true;
					}
					else if (oppFaceDistance(halfEdge.opposite) > 0.0 - tolerance)
					{
						flag = false;
					}
				}
				else if (oppFaceDistance(halfEdge.opposite) > 0.0 - tolerance)
				{
					flag2 = true;
				}
				else if (oppFaceDistance(halfEdge) > 0.0 - tolerance)
				{
					flag = false;
				}
				if (flag2)
				{
					int num = face.mergeAdjacentFace(halfEdge, discardedFaces);
					for (int i = 0; i < num; i++)
					{
						deleteFacePoints(discardedFaces[i], face);
					}
					return true;
				}
				halfEdge = halfEdge.next;
			}
			while (halfEdge != face.he0);
			if (!flag)
			{
				face.mark = 2;
			}
			return false;
		}

		protected void calculateHorizon(Point3d eyePnt, HalfEdge edge0, Face face, List<HalfEdge> horizon)
		{
			deleteFacePoints(face, null);
			face.mark = 3;
			HalfEdge halfEdge;
			if (edge0 == null)
			{
				edge0 = face.getEdge(0);
				halfEdge = edge0;
			}
			else
			{
				halfEdge = edge0.getNext();
			}
			do
			{
				Face face2 = halfEdge.oppositeFace();
				if (face2.mark == 1)
				{
					if (face2.distanceToPlane(eyePnt) > tolerance)
					{
						calculateHorizon(eyePnt, halfEdge.getOpposite(), face2, horizon);
					}
					else
					{
						horizon.Add(halfEdge);
					}
				}
				halfEdge = halfEdge.getNext();
			}
			while (halfEdge != edge0);
		}

		private HalfEdge addAdjoiningFace(Vertex eyeVtx, HalfEdge he)
		{
			Face face = Face.createTriangle(eyeVtx, he.tail(), he.head());
			faces.Add(face);
			face.getEdge(-1).setOpposite(he.getOpposite());
			return face.getEdge(0);
		}

		protected void addNewFaces(FaceList newFaces, Vertex eyeVtx, List<HalfEdge> horizon)
		{
			newFaces.clear();
			HalfEdge halfEdge = null;
			HalfEdge halfEdge2 = null;
			foreach (HalfEdge item in horizon)
			{
				HalfEdge halfEdge3 = addAdjoiningFace(eyeVtx, item);
				if (halfEdge != null)
				{
					halfEdge3.next.setOpposite(halfEdge);
				}
				else
				{
					halfEdge2 = halfEdge3;
				}
				newFaces.add(halfEdge3.getFace());
				halfEdge = halfEdge3;
			}
			halfEdge2.next.setOpposite(halfEdge);
		}

		protected Vertex nextPointToAdd()
		{
			if (!claimed.isEmpty())
			{
				Face face = claimed.first().face;
				Vertex result = null;
				double num = 0.0;
				Vertex vertex = face.outside;
				while (vertex != null && vertex.face == face)
				{
					double num2 = face.distanceToPlane(vertex.pnt);
					if (num2 > num)
					{
						num = num2;
						result = vertex;
					}
					vertex = vertex.next;
				}
				return result;
			}
			return null;
		}

		protected void addPointToHull(Vertex eyeVtx)
		{
			horizon.Clear();
			unclaimed.clear();
			removePointFromFace(eyeVtx, eyeVtx.face);
			calculateHorizon(eyeVtx.pnt, null, eyeVtx.face, horizon);
			newFaces.clear();
			addNewFaces(newFaces, eyeVtx, horizon);
			for (Face face = newFaces.first(); face != null; face = face.next)
			{
				if (face.mark == 1)
				{
					while (doAdjacentMerge(face, 1))
					{
					}
				}
			}
			for (Face face2 = newFaces.first(); face2 != null; face2 = face2.next)
			{
				if (face2.mark == 2)
				{
					face2.mark = 1;
					while (doAdjacentMerge(face2, 2))
					{
					}
				}
			}
			resolveUnclaimedPoints(newFaces);
		}

		protected void buildHull()
		{
			int num = 0;
			computeMaxAndMin();
			createInitialSimplex();
			Vertex eyeVtx;
			while ((eyeVtx = nextPointToAdd()) != null)
			{
				addPointToHull(eyeVtx);
				num++;
			}
			reindexFacesAndVertices();
		}

		private void markFaceVertices(Face face, int mark)
		{
			HalfEdge firstEdge = face.getFirstEdge();
			HalfEdge halfEdge = firstEdge;
			do
			{
				halfEdge.head().index = mark;
				halfEdge = halfEdge.next;
			}
			while (halfEdge != firstEdge);
		}

		protected void reindexFacesAndVertices()
		{
			for (int i = 0; i < numPoints; i++)
			{
				pointBuffer[i].index = -1;
			}
			numFaces = 0;
			for (int j = 0; j < faces.Count; j++)
			{
				Face face = faces[j];
				if (face.mark != 1)
				{
					faces.RemoveAt(j);
					j--;
				}
				else
				{
					markFaceVertices(face, 0);
					numFaces++;
				}
			}
			numVertices = 0;
			for (int k = 0; k < numPoints; k++)
			{
				Vertex vertex = pointBuffer[k];
				if (vertex.index == 0)
				{
					vertexPointIndices[numVertices] = k;
					vertex.index = numVertices++;
				}
			}
		}

		protected bool checkFaceConvexity(Face face, double tol)
		{
			HalfEdge halfEdge = face.he0;
			do
			{
				face.checkConsistency();
				if (oppFaceDistance(halfEdge) > tol)
				{
					return false;
				}
				if (oppFaceDistance(halfEdge.opposite) > tol)
				{
					return false;
				}
				if (halfEdge.next.oppositeFace() == halfEdge.oppositeFace())
				{
					return false;
				}
				halfEdge = halfEdge.next;
			}
			while (halfEdge != face.he0);
			return true;
		}

		protected bool checkFaces(double tol)
		{
			bool result = true;
			foreach (Face face in faces)
			{
				if (face.mark == 1 && !checkFaceConvexity(face, tol))
				{
					result = false;
				}
			}
			return result;
		}

		public bool check()
		{
			return check(getDistanceTolerance());
		}

		public bool check(double tol)
		{
			double num = 10.0 * tol;
			if (!checkFaces(tolerance))
			{
				return false;
			}
			for (int i = 0; i < numPoints; i++)
			{
				Point3d pnt = pointBuffer[i].pnt;
				foreach (Face face in faces)
				{
					if (face.mark == 1 && face.distanceToPlane(pnt) > num)
					{
						return false;
					}
				}
			}
			return true;
		}
	}
	public class Vector3d
	{
		private const double DOUBLE_PREC = 2.220446049250313E-16;

		public double x;

		public double y;

		public double z;

		public Vector3d()
		{
		}

		public Vector3d(Vector3d v)
		{
			set(v);
		}

		public Vector3d(double x, double y, double z)
		{
			set(x, y, z);
		}

		public double get(int i)
		{
			return i switch
			{
				0 => x, 
				1 => y, 
				2 => z, 
				_ => throw new IndexOutOfRangeException(i.ToString() ?? ""), 
			};
		}

		public void set(int i, double value)
		{
			switch (i)
			{
			case 0:
				x = value;
				break;
			case 1:
				y = value;
				break;
			case 2:
				z = value;
				break;
			default:
				throw new IndexOutOfRangeException(i.ToString() ?? "");
			}
		}

		public void set(Vector3d v1)
		{
			x = v1.x;
			y = v1.y;
			z = v1.z;
		}

		public void add(Vector3d v1, Vector3d v2)
		{
			x = v1.x + v2.x;
			y = v1.y + v2.y;
			z = v1.z + v2.z;
		}

		public void add(Vector3d v1)
		{
			x += v1.x;
			y += v1.y;
			z += v1.z;
		}

		public void sub(Vector3d v1, Vector3d v2)
		{
			x = v1.x - v2.x;
			y = v1.y - v2.y;
			z = v1.z - v2.z;
		}

		public void sub(Vector3d v1)
		{
			x -= v1.x;
			y -= v1.y;
			z -= v1.z;
		}

		public void scale(double s)
		{
			x = s * x;
			y = s * y;
			z = s * z;
		}

		public void scale(double s, Vector3d v1)
		{
			x = s * v1.x;
			y = s * v1.y;
			z = s * v1.z;
		}

		public double norm()
		{
			return Math.Sqrt(x * x + y * y + z * z);
		}

		public double normSquared()
		{
			return x * x + y * y + z * z;
		}

		public double distance(Vector3d v)
		{
			double num = x - v.x;
			double num2 = y - v.y;
			double num3 = z - v.z;
			return Math.Sqrt(num * num + num2 * num2 + num3 * num3);
		}

		public double distanceSquared(Vector3d v)
		{
			double num = x - v.x;
			double num2 = y - v.y;
			double num3 = z - v.z;
			return num * num + num2 * num2 + num3 * num3;
		}

		public double dot(Vector3d v1)
		{
			return x * v1.x + y * v1.y + z * v1.z;
		}

		public void normalize()
		{
			double num = x * x + y * y + z * z;
			double num2 = num - 1.0;
			if (num2 > 4.440892098500626E-16 || num2 < -4.440892098500626E-16)
			{
				double num3 = Math.Sqrt(num);
				x /= num3;
				y /= num3;
				z /= num3;
			}
		}

		public void setZero()
		{
			x = 0.0;
			y = 0.0;
			z = 0.0;
		}

		public void set(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public void cross(Vector3d v1, Vector3d v2)
		{
			double num = v1.y * v2.z - v1.z * v2.y;
			double num2 = v1.z * v2.x - v1.x * v2.z;
			double num3 = v1.x * v2.y - v1.y * v2.x;
			x = num;
			y = num2;
			z = num3;
		}

		protected void setRandom(double lower, double upper, System.Random generator)
		{
			double num = upper - lower;
			x = generator.NextDouble() * num + lower;
			y = generator.NextDouble() * num + lower;
			z = generator.NextDouble() * num + lower;
		}

		public string toString()
		{
			return x + " " + y + " " + z;
		}
	}
	public class Vertex
	{
		public Point3d pnt;

		public int index;

		public Vertex prev;

		public Vertex next;

		public Face face;

		public Vertex()
		{
			pnt = new Point3d();
		}

		public Vertex(double x, double y, double z, int idx)
		{
			pnt = new Point3d(x, y, z);
			index = idx;
		}
	}
	internal class VertexList
	{
		private Vertex head;

		private Vertex tail;

		public void clear()
		{
			head = (tail = null);
		}

		public void add(Vertex vtx)
		{
			if (head == null)
			{
				head = vtx;
			}
			else
			{
				tail.next = vtx;
			}
			vtx.prev = tail;
			vtx.next = null;
			tail = vtx;
		}

		public void addAll(Vertex vtx)
		{
			if (head == null)
			{
				head = vtx;
			}
			else
			{
				tail.next = vtx;
			}
			vtx.prev = tail;
			while (vtx.next != null)
			{
				vtx = vtx.next;
			}
			tail = vtx;
		}

		public void delete(Vertex vtx)
		{
			if (vtx.prev == null)
			{
				head = vtx.next;
			}
			else
			{
				vtx.prev.next = vtx.next;
			}
			if (vtx.next == null)
			{
				tail = vtx.prev;
			}
			else
			{
				vtx.next.prev = vtx.prev;
			}
		}

		public void delete(Vertex vtx1, Vertex vtx2)
		{
			if (vtx1.prev == null)
			{
				head = vtx2.next;
			}
			else
			{
				vtx1.prev.next = vtx2.next;
			}
			if (vtx2.next == null)
			{
				tail = vtx1.prev;
			}
			else
			{
				vtx2.next.prev = vtx1.prev;
			}
		}

		public void insertBefore(Vertex vtx, Vertex next)
		{
			vtx.prev = next.prev;
			if (next.prev == null)
			{
				head = vtx;
			}
			else
			{
				next.prev.next = vtx;
			}
			vtx.next = next;
			next.prev = vtx;
		}

		public Vertex first()
		{
			return head;
		}

		public bool isEmpty()
		{
			return head == null;
		}
	}
}
