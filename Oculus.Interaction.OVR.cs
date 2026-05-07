using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using Meta.XR.Util;
using Oculus.Interaction.Body.Input;
using Oculus.Interaction.Input;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.XR;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
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
			FilePathsData = new byte[2483]
			{
				0, 0, 0, 1, 0, 0, 0, 93, 92, 80,
				97, 99, 107, 97, 103, 101, 115, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 105, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 46, 111, 118, 114, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 66, 111, 100, 121,
				92, 73, 110, 112, 117, 116, 92, 70, 114, 111,
				109, 79, 86, 82, 66, 111, 100, 121, 68, 97,
				116, 97, 83, 111, 117, 114, 99, 101, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 99, 92,
				80, 97, 99, 107, 97, 103, 101, 115, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 111, 118, 114,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 66, 111, 100,
				121, 92, 73, 110, 112, 117, 116, 92, 79, 86,
				82, 66, 111, 100, 121, 80, 111, 115, 101, 83,
				107, 101, 108, 101, 116, 111, 110, 80, 114, 111,
				118, 105, 100, 101, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 90, 92, 80, 97, 99,
				107, 97, 103, 101, 115, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 105, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 111, 118, 114, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 66, 111, 100, 121, 92, 73,
				110, 112, 117, 116, 92, 79, 86, 82, 83, 107,
				101, 108, 101, 116, 111, 110, 77, 97, 112, 112,
				105, 110, 103, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 82, 92, 80, 97, 99, 107, 97,
				103, 101, 115, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				105, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 46, 111, 118, 114, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 73, 110, 112, 117, 116, 92, 65, 110,
				105, 109, 97, 116, 101, 100, 72, 97, 110, 100,
				79, 86, 82, 46, 99, 115, 0, 0, 0, 7,
				0, 0, 0, 94, 92, 80, 97, 99, 107, 97,
				103, 101, 115, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				105, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 46, 111, 118, 114, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 73, 110, 112, 117, 116, 92, 70, 114,
				111, 109, 79, 86, 82, 67, 111, 110, 116, 114,
				111, 108, 108, 101, 114, 68, 97, 116, 97, 83,
				111, 117, 114, 99, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 88, 92, 80, 97, 99,
				107, 97, 103, 101, 115, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 105, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 111, 118, 114, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 73, 110, 112, 117, 116, 92,
				70, 114, 111, 109, 79, 86, 82, 72, 97, 110,
				100, 68, 97, 116, 97, 83, 111, 117, 114, 99,
				101, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 87, 92, 80, 97, 99, 107, 97, 103, 101,
				115, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 105, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				111, 118, 114, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				73, 110, 112, 117, 116, 92, 70, 114, 111, 109,
				79, 86, 82, 72, 109, 100, 68, 97, 116, 97,
				83, 111, 117, 114, 99, 101, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 82, 92, 80, 97,
				99, 107, 97, 103, 101, 115, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 105, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 111, 118, 114, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 73, 110, 112, 117, 116,
				92, 72, 97, 110, 100, 83, 107, 101, 108, 101,
				116, 111, 110, 79, 86, 82, 46, 99, 115, 0,
				0, 0, 2, 0, 0, 0, 76, 92, 80, 97,
				99, 107, 97, 103, 101, 115, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 105, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 111, 118, 114, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 73, 110, 112, 117, 116,
				92, 79, 86, 82, 65, 120, 105, 115, 49, 68,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				76, 92, 80, 97, 99, 107, 97, 103, 101, 115,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 105, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 46, 111,
				118, 114, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 73,
				110, 112, 117, 116, 92, 79, 86, 82, 65, 120,
				105, 115, 50, 68, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 76, 92, 80, 97, 99, 107,
				97, 103, 101, 115, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 105, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 46, 111, 118, 114, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 73, 110, 112, 117, 116, 92, 79,
				86, 82, 66, 117, 116, 116, 111, 110, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 87, 92,
				80, 97, 99, 107, 97, 103, 101, 115, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 111, 118, 114,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 73, 110, 112,
				117, 116, 92, 79, 86, 82, 66, 117, 116, 116,
				111, 110, 65, 99, 116, 105, 118, 101, 83, 116,
				97, 116, 101, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 82, 92, 80, 97, 99, 107, 97,
				103, 101, 115, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				105, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 46, 111, 118, 114, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 73, 110, 112, 117, 116, 92, 79, 86,
				82, 66, 117, 116, 116, 111, 110, 65, 120, 105,
				115, 49, 68, 46, 99, 115, 0, 0, 0, 2,
				0, 0, 0, 82, 92, 80, 97, 99, 107, 97,
				103, 101, 115, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				105, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 46, 111, 118, 114, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 73, 110, 112, 117, 116, 92, 79, 86,
				82, 67, 97, 109, 101, 114, 97, 82, 105, 103,
				82, 101, 102, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 97, 92, 80, 97, 99, 107, 97,
				103, 101, 115, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				105, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 46, 111, 118, 114, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 73, 110, 112, 117, 116, 92, 79, 86,
				82, 67, 111, 110, 116, 114, 111, 108, 108, 101,
				114, 73, 110, 72, 97, 110, 100, 65, 99, 116,
				105, 118, 101, 83, 116, 97, 116, 101, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 105, 92,
				80, 97, 99, 107, 97, 103, 101, 115, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 111, 118, 114,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 73, 110, 112,
				117, 116, 92, 79, 86, 82, 67, 111, 110, 116,
				114, 111, 108, 108, 101, 114, 77, 97, 116, 99,
				104, 101, 115, 80, 114, 111, 102, 105, 108, 101,
				65, 99, 116, 105, 118, 101, 83, 116, 97, 116,
				101, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 87, 92, 80, 97, 99, 107, 97, 103, 101,
				115, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 105, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				111, 118, 114, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				73, 110, 112, 117, 116, 92, 79, 86, 82, 67,
				111, 110, 116, 114, 111, 108, 108, 101, 114, 85,
				116, 105, 108, 105, 116, 121, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 86, 92, 80, 97,
				99, 107, 97, 103, 101, 115, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 105, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 111, 118, 114, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 73, 110, 112, 117, 116,
				92, 79, 86, 82, 67, 111, 110, 116, 114, 111,
				108, 108, 101, 114, 86, 105, 115, 117, 97, 108,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				92, 92, 80, 97, 99, 107, 97, 103, 101, 115,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 105, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 46, 111,
				118, 114, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 73,
				110, 112, 117, 116, 92, 79, 86, 82, 73, 110,
				112, 117, 116, 68, 101, 118, 105, 99, 101, 65,
				99, 116, 105, 118, 101, 83, 116, 97, 116, 101,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				79, 92, 80, 97, 99, 107, 97, 103, 101, 115,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 105, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 46, 111,
				118, 114, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 73,
				110, 112, 117, 116, 92, 79, 86, 82, 78, 101,
				97, 114, 84, 111, 117, 99, 104, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 82, 92, 80,
				97, 99, 107, 97, 103, 101, 115, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 105, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 46, 111, 118, 114, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 73, 110, 112, 117,
				116, 92, 79, 86, 82, 83, 107, 101, 108, 101,
				116, 111, 110, 68, 97, 116, 97, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 75, 92, 80,
				97, 99, 107, 97, 103, 101, 115, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 105, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 46, 111, 118, 114, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 73, 110, 112, 117,
				116, 92, 79, 86, 82, 84, 111, 117, 99, 104,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				84, 92, 80, 97, 99, 107, 97, 103, 101, 115,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 105, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 46, 111,
				118, 114, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 73,
				110, 112, 117, 116, 92, 83, 101, 116, 68, 105,
				115, 112, 108, 97, 121, 82, 101, 102, 114, 101,
				115, 104, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 96, 92, 80, 97, 99, 107, 97, 103,
				101, 115, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 105,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				46, 111, 118, 114, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 73, 110, 112, 117, 116, 92, 84, 114, 97,
				99, 107, 105, 110, 103, 84, 111, 87, 111, 114,
				108, 100, 84, 114, 97, 110, 115, 102, 111, 114,
				109, 101, 114, 79, 86, 82, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 104, 92, 80, 97,
				99, 107, 97, 103, 101, 115, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 105, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 111, 118, 114, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 77, 105, 99, 114, 111,
				103, 101, 115, 116, 117, 114, 101, 115, 92, 77,
				105, 99, 114, 111, 71, 101, 115, 116, 117, 114,
				101, 85, 110, 105, 116, 121, 69, 118, 101, 110,
				116, 87, 114, 97, 112, 112, 101, 114, 46, 99,
				115, 0, 0, 0, 2, 0, 0, 0, 94, 92,
				80, 97, 99, 107, 97, 103, 101, 115, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 111, 118, 114,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 85, 110, 105,
				116, 121, 67, 97, 110, 118, 97, 115, 92, 79,
				86, 82, 67, 97, 110, 118, 97, 115, 77, 101,
				115, 104, 82, 101, 110, 100, 101, 114, 101, 114,
				46, 99, 115
			},
			TypesData = new byte[1765]
			{
				0, 0, 0, 0, 51, 79, 99, 117, 108, 117,
				115, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 66, 111, 100, 121, 46, 73,
				110, 112, 117, 116, 124, 70, 114, 111, 109, 79,
				86, 82, 66, 111, 100, 121, 68, 97, 116, 97,
				83, 111, 117, 114, 99, 101, 0, 0, 0, 0,
				65, 79, 99, 117, 108, 117, 115, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				66, 111, 100, 121, 46, 80, 111, 115, 101, 68,
				101, 116, 101, 99, 116, 105, 111, 110, 124, 79,
				86, 82, 66, 111, 100, 121, 80, 111, 115, 101,
				83, 107, 101, 108, 101, 116, 111, 110, 80, 114,
				111, 118, 105, 100, 101, 114, 0, 0, 0, 0,
				48, 79, 99, 117, 108, 117, 115, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				66, 111, 100, 121, 46, 73, 110, 112, 117, 116,
				124, 79, 86, 82, 83, 107, 101, 108, 101, 116,
				111, 110, 77, 97, 112, 112, 105, 110, 103, 0,
				0, 0, 0, 40, 79, 99, 117, 108, 117, 115,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 46, 73, 110, 112, 117, 116, 124, 65,
				110, 105, 109, 97, 116, 101, 100, 72, 97, 110,
				100, 79, 86, 82, 0, 0, 0, 0, 31, 79,
				99, 117, 108, 117, 115, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 46, 73, 110,
				112, 117, 116, 124, 73, 85, 115, 97, 103, 101,
				0, 0, 0, 0, 42, 79, 99, 117, 108, 117,
				115, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 73, 110, 112, 117, 116, 124,
				85, 115, 97, 103, 101, 84, 111, 117, 99, 104,
				77, 97, 112, 112, 105, 110, 103, 0, 0, 0,
				0, 43, 79, 99, 117, 108, 117, 115, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				46, 73, 110, 112, 117, 116, 124, 85, 115, 97,
				103, 101, 66, 117, 116, 116, 111, 110, 77, 97,
				112, 112, 105, 110, 103, 0, 0, 0, 0, 43,
				79, 99, 117, 108, 117, 115, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 46, 73,
				110, 112, 117, 116, 124, 85, 115, 97, 103, 101,
				65, 120, 105, 115, 49, 68, 77, 97, 112, 112,
				105, 110, 103, 0, 0, 0, 0, 43, 79, 99,
				117, 108, 117, 115, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 73, 110, 112,
				117, 116, 124, 85, 115, 97, 103, 101, 65, 120,
				105, 115, 50, 68, 77, 97, 112, 112, 105, 110,
				103, 0, 0, 0, 0, 47, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 73, 110, 112, 117, 116,
				124, 79, 86, 82, 80, 111, 105, 110, 116, 101,
				114, 80, 111, 115, 101, 83, 101, 108, 101, 99,
				116, 111, 114, 0, 0, 0, 0, 52, 79, 99,
				117, 108, 117, 115, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 73, 110, 112,
				117, 116, 124, 70, 114, 111, 109, 79, 86, 82,
				67, 111, 110, 116, 114, 111, 108, 108, 101, 114,
				68, 97, 116, 97, 83, 111, 117, 114, 99, 101,
				0, 0, 0, 0, 46, 79, 99, 117, 108, 117,
				115, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 73, 110, 112, 117, 116, 124,
				70, 114, 111, 109, 79, 86, 82, 72, 97, 110,
				100, 68, 97, 116, 97, 83, 111, 117, 114, 99,
				101, 0, 0, 0, 0, 45, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 73, 110, 112, 117, 116,
				124, 70, 114, 111, 109, 79, 86, 82, 72, 109,
				100, 68, 97, 116, 97, 83, 111, 117, 114, 99,
				101, 0, 0, 0, 0, 40, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 73, 110, 112, 117, 116,
				124, 72, 97, 110, 100, 83, 107, 101, 108, 101,
				116, 111, 110, 79, 86, 82, 0, 0, 0, 0,
				38, 79, 99, 117, 108, 117, 115, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				79, 86, 82, 46, 73, 110, 112, 117, 116, 124,
				79, 86, 82, 65, 120, 105, 115, 49, 68, 0,
				0, 0, 0, 50, 79, 99, 117, 108, 117, 115,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 46, 79, 86, 82, 46, 73, 110, 112,
				117, 116, 46, 79, 86, 82, 65, 120, 105, 115,
				49, 68, 124, 82, 101, 109, 97, 112, 67, 111,
				110, 102, 105, 103, 0, 0, 0, 0, 38, 79,
				99, 117, 108, 117, 115, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 46, 79, 86,
				82, 46, 73, 110, 112, 117, 116, 124, 79, 86,
				82, 65, 120, 105, 115, 50, 68, 0, 0, 0,
				0, 38, 79, 99, 117, 108, 117, 115, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				46, 79, 86, 82, 46, 73, 110, 112, 117, 116,
				124, 79, 86, 82, 66, 117, 116, 116, 111, 110,
				0, 0, 0, 0, 49, 79, 99, 117, 108, 117,
				115, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 79, 86, 82, 46, 73, 110,
				112, 117, 116, 124, 79, 86, 82, 66, 117, 116,
				116, 111, 110, 65, 99, 116, 105, 118, 101, 83,
				116, 97, 116, 101, 0, 0, 0, 0, 34, 79,
				99, 117, 108, 117, 115, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 124, 79, 86,
				82, 66, 117, 116, 116, 111, 110, 65, 120, 105,
				115, 49, 68, 0, 0, 0, 0, 41, 79, 99,
				117, 108, 117, 115, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 73, 110, 112,
				117, 116, 124, 73, 79, 86, 82, 67, 97, 109,
				101, 114, 97, 82, 105, 103, 82, 101, 102, 0,
				0, 0, 0, 40, 79, 99, 117, 108, 117, 115,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 46, 73, 110, 112, 117, 116, 124, 79,
				86, 82, 67, 97, 109, 101, 114, 97, 82, 105,
				103, 82, 101, 102, 0, 0, 0, 0, 53, 79,
				99, 117, 108, 117, 115, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 46, 79, 86,
				82, 124, 79, 86, 82, 67, 111, 110, 116, 114,
				111, 108, 108, 101, 114, 73, 110, 72, 97, 110,
				100, 65, 99, 116, 105, 118, 101, 83, 116, 97,
				116, 101, 0, 0, 0, 0, 57, 79, 99, 117,
				108, 117, 115, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 124, 79, 86, 82, 67,
				111, 110, 116, 114, 111, 108, 108, 101, 114, 77,
				97, 116, 99, 104, 101, 115, 80, 114, 111, 102,
				105, 108, 101, 65, 99, 116, 105, 118, 101, 83,
				116, 97, 116, 101, 0, 0, 0, 0, 45, 79,
				99, 117, 108, 117, 115, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 46, 73, 110,
				112, 117, 116, 124, 79, 86, 82, 67, 111, 110,
				116, 114, 111, 108, 108, 101, 114, 85, 116, 105,
				108, 105, 116, 121, 0, 0, 0, 0, 52, 79,
				99, 117, 108, 117, 115, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 46, 73, 110,
				112, 117, 116, 46, 86, 105, 115, 117, 97, 108,
				115, 124, 79, 86, 82, 67, 111, 110, 116, 114,
				111, 108, 108, 101, 114, 86, 105, 115, 117, 97,
				108, 0, 0, 0, 0, 50, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 73, 110, 112, 117, 116,
				124, 79, 86, 82, 73, 110, 112, 117, 116, 68,
				101, 118, 105, 99, 101, 65, 99, 116, 105, 118,
				101, 83, 116, 97, 116, 101, 0, 0, 0, 0,
				37, 79, 99, 117, 108, 117, 115, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				73, 110, 112, 117, 116, 124, 79, 86, 82, 78,
				101, 97, 114, 84, 111, 117, 99, 104, 0, 0,
				0, 0, 40, 79, 99, 117, 108, 117, 115, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 46, 73, 110, 112, 117, 116, 124, 79, 86,
				82, 83, 107, 101, 108, 101, 116, 111, 110, 68,
				97, 116, 97, 0, 0, 0, 0, 33, 79, 99,
				117, 108, 117, 115, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 73, 110, 112,
				117, 116, 124, 79, 86, 82, 84, 111, 117, 99,
				104, 0, 0, 0, 0, 42, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 73, 110, 112, 117, 116,
				124, 83, 101, 116, 68, 105, 115, 112, 108, 97,
				121, 82, 101, 102, 114, 101, 115, 104, 0, 0,
				0, 0, 54, 79, 99, 117, 108, 117, 115, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 46, 73, 110, 112, 117, 116, 124, 84, 114,
				97, 99, 107, 105, 110, 103, 84, 111, 87, 111,
				114, 108, 100, 84, 114, 97, 110, 115, 102, 111,
				114, 109, 101, 114, 79, 86, 82, 0, 0, 0,
				0, 48, 79, 99, 117, 108, 117, 115, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				124, 77, 105, 99, 114, 111, 71, 101, 115, 116,
				117, 114, 101, 85, 110, 105, 116, 121, 69, 118,
				101, 110, 116, 87, 114, 97, 112, 112, 101, 114,
				0, 0, 0, 0, 52, 79, 99, 117, 108, 117,
				115, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 85, 110, 105, 116, 121, 67,
				97, 110, 118, 97, 115, 124, 79, 86, 82, 67,
				97, 110, 118, 97, 115, 77, 101, 115, 104, 82,
				101, 110, 100, 101, 114, 101, 114, 0, 0, 0,
				0, 63, 79, 99, 117, 108, 117, 115, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				46, 85, 110, 105, 116, 121, 67, 97, 110, 118,
				97, 115, 46, 79, 86, 82, 67, 97, 110, 118,
				97, 115, 77, 101, 115, 104, 82, 101, 110, 100,
				101, 114, 101, 114, 124, 80, 114, 111, 112, 101,
				114, 116, 105, 101, 115
			},
			TotalFiles = 26,
			TotalTypes = 35,
			IsEditorOnly = false
		};
	}
}
namespace Oculus.Interaction
{
	[Feature(Feature.Interaction)]
	public class OVRButtonAxis1D : MonoBehaviour, IAxis1D
	{
		[SerializeField]
		private OVRInput.Controller _controller;

		[SerializeField]
		private OVRInput.Button _near;

		[SerializeField]
		private OVRInput.Button _touch;

		[SerializeField]
		private OVRInput.Button _button;

		[SerializeField]
		private float _nearValue = 0.1f;

		[SerializeField]
		private float _touchValue = 0.5f;

		[SerializeField]
		private float _buttonValue = 1f;

		[SerializeField]
		private ProgressCurve _curve = new ProgressCurve(AnimationCurve.EaseInOut(0f, 0f, 1f, 1f), 0.1f);

		private float _baseValue;

		private float _value;

		private float _currentTarget;

		public float NearValue
		{
			get
			{
				return _nearValue;
			}
			set
			{
				_nearValue = value;
			}
		}

		public float TouchValue
		{
			get
			{
				return _touchValue;
			}
			set
			{
				_touchValue = value;
			}
		}

		public float ButtonValue
		{
			get
			{
				return _buttonValue;
			}
			set
			{
				_buttonValue = value;
			}
		}

		private float Target
		{
			get
			{
				if (OVRInput.Get(_button, _controller))
				{
					return _buttonValue;
				}
				if (OVRInput.Get(_touch, _controller))
				{
					return _touchValue;
				}
				if (OVRInput.Get(_near, _controller))
				{
					return _nearValue;
				}
				return 0f;
			}
		}

		public float Value()
		{
			return _value;
		}

		protected virtual void Update()
		{
			float target = Target;
			if (_currentTarget != target)
			{
				_baseValue = _value;
				_currentTarget = target;
				_curve.Start();
			}
			_value = _curve.Progress() * (_currentTarget - _baseValue);
		}

		public void InjectAllOVRButtonAxis1D(OVRInput.Controller controller, OVRInput.Button near, OVRInput.Button touch, OVRInput.Button button)
		{
			_controller = controller;
			_near = near;
			_touch = touch;
			_button = button;
		}

		public void InjectOptionalCurve(ProgressCurve progressCurve)
		{
			_curve = progressCurve;
		}
	}
	[Feature(Feature.Interaction)]
	public class OVRControllerMatchesProfileActiveState : MonoBehaviour, IActiveState
	{
		[SerializeField]
		private OVRInput.Controller _controller;

		[SerializeField]
		private OVRInput.InteractionProfile _profile;

		public bool Active => OVRInput.GetCurrentInteractionProfile((!_controller.HasFlag(OVRInput.Controller.LTouch) && !_controller.HasFlag(OVRInput.Controller.LHand)) ? OVRInput.Hand.HandRight : OVRInput.Hand.HandLeft) == _profile;

		public void InjectAllOVRControllerSupportsPressure(OVRInput.Controller controller)
		{
			_controller = controller;
		}
	}
	internal class MicroGestureUnityEventWrapper : MonoBehaviour
	{
		[SerializeField]
		private OVRMicrogestureEventSource _ovrMicrogestureEventSource;

		[SerializeField]
		private UnityEvent _whenTapCenter;

		[SerializeField]
		private UnityEvent _whenSwipeUp;

		[SerializeField]
		private UnityEvent _whenSwipeDown;

		[SerializeField]
		private UnityEvent _whenSwipeLeft;

		[SerializeField]
		private UnityEvent _whenSwipeRight;

		private bool _started;

		public UnityEvent WhenTapCenter => _whenTapCenter;

		public UnityEvent WhenSwipeUp => _whenSwipeUp;

		public UnityEvent WhenSwipeDown => _whenSwipeDown;

		public UnityEvent WhenSwipeLeft => _whenSwipeLeft;

		public UnityEvent WhenSwipeRight => _whenSwipeRight;

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			this.EndStart(ref _started);
		}

		protected virtual void OnEnable()
		{
			if (_started)
			{
				OVRMicrogestureEventSource ovrMicrogestureEventSource = _ovrMicrogestureEventSource;
				ovrMicrogestureEventSource.WhenGestureRecognized = (Action<OVRHand.MicrogestureType>)Delegate.Combine(ovrMicrogestureEventSource.WhenGestureRecognized, new Action<OVRHand.MicrogestureType>(HandleGesture));
			}
		}

		protected virtual void OnDisable()
		{
			if (_started)
			{
				OVRMicrogestureEventSource ovrMicrogestureEventSource = _ovrMicrogestureEventSource;
				ovrMicrogestureEventSource.WhenGestureRecognized = (Action<OVRHand.MicrogestureType>)Delegate.Remove(ovrMicrogestureEventSource.WhenGestureRecognized, new Action<OVRHand.MicrogestureType>(HandleGesture));
			}
		}

		private void HandleGesture(OVRHand.MicrogestureType gesture)
		{
			switch (gesture)
			{
			case OVRHand.MicrogestureType.SwipeRight:
				_whenSwipeRight.Invoke();
				break;
			case OVRHand.MicrogestureType.SwipeLeft:
				_whenSwipeLeft.Invoke();
				break;
			case OVRHand.MicrogestureType.SwipeForward:
				_whenSwipeUp.Invoke();
				break;
			case OVRHand.MicrogestureType.SwipeBackward:
				_whenSwipeDown.Invoke();
				break;
			case OVRHand.MicrogestureType.ThumbTap:
				_whenTapCenter.Invoke();
				break;
			}
		}

		public void InjectAllMicroGestureUnityEventWrapper(OVRMicrogestureEventSource ovrMicrogestureEventSource)
		{
			InjectOvrMicrogestureEventSource(ovrMicrogestureEventSource);
		}

		public void InjectOvrMicrogestureEventSource(OVRMicrogestureEventSource ovrMicrogestureEventSource)
		{
			_ovrMicrogestureEventSource = ovrMicrogestureEventSource;
		}
	}
}
namespace Oculus.Interaction.UnityCanvas
{
	[Feature(Feature.Interaction)]
	public class OVRCanvasMeshRenderer : CanvasMeshRenderer
	{
		public new static class Properties
		{
			public static readonly string CanvasRenderTexture = "_canvasRenderTexture";

			public static readonly string CanvasMesh = "_canvasMesh";

			public static readonly string EnableSuperSampling = "_enableSuperSampling";

			public static readonly string EmulateWhileInEditor = "_emulateWhileInEditor";

			public static readonly string DoUnderlayAntiAliasing = "_doUnderlayAntiAliasing";

			public static readonly string RuntimeOffset = "_runtimeOffset";
		}

		[SerializeField]
		protected CanvasMesh _canvasMesh;

		[Tooltip("If non-zero it will cause the position of the overlay to be offset by this amount at runtime, while the renderer will remain where it was at edit time. This can be used to prevent the two representations from overlapping.")]
		[SerializeField]
		protected Vector3 _runtimeOffset = new Vector3(0f, 0f, 0f);

		[Tooltip("Uses a more expensive image sampling technique for improved quality at the cost of performance.")]
		[SerializeField]
		protected bool _enableSuperSampling = true;

		[Tooltip("Attempts to anti-alias the edges of the underlay by using alpha blending.  Can cause borders of darkness around partially transparent objects.")]
		[SerializeField]
		private bool _doUnderlayAntiAliasing;

		[Tooltip("OVR Layers can provide a buggy or less ideal workflow while in the editor.  This option allows you emulate the layer rendering while in the editor, while still using the OVR Layer rendering in a build.")]
		[SerializeField]
		private bool _emulateWhileInEditor = true;

		protected OVROverlay _overlay;

		private OVRRenderingMode RenderingMode => (OVRRenderingMode)_renderingMode;

		public bool ShouldUseOVROverlay
		{
			get
			{
				OVRRenderingMode renderingMode = RenderingMode;
				if ((uint)(renderingMode - 100) <= 1u)
				{
					return !UseEditorEmulation();
				}
				return false;
			}
		}

		protected override string GetShaderName()
		{
			switch (RenderingMode)
			{
			case OVRRenderingMode.Overlay:
				return "Hidden/Imposter_AlphaCutout";
			case OVRRenderingMode.Underlay:
				if (UseEditorEmulation())
				{
					return "Hidden/Imposter_AlphaCutout";
				}
				if (_doUnderlayAntiAliasing)
				{
					return "Hidden/Imposter_Underlay_AA";
				}
				return "Hidden/Imposter_Underlay";
			default:
				return base.GetShaderName();
			}
		}

		protected override float GetAlphaCutoutThreshold()
		{
			switch (RenderingMode)
			{
			case OVRRenderingMode.Overlay:
				return 1f;
			case OVRRenderingMode.Underlay:
				if (!UseEditorEmulation())
				{
					return 1f;
				}
				return 0.5f;
			default:
				return base.GetAlphaCutoutThreshold();
			}
		}

		protected override void HandleUpdateRenderTexture(Texture texture)
		{
			base.HandleUpdateRenderTexture(texture);
			UpdateOverlay(texture);
		}

		private bool UseEditorEmulation()
		{
			if (!Application.isEditor)
			{
				return false;
			}
			return _emulateWhileInEditor;
		}

		private bool GetOverlayParameters(out OVROverlay.OverlayShape shape, out Vector3 position, out Vector3 scale)
		{
			if (_canvasMesh is CanvasCylinder canvasCylinder)
			{
				shape = OVROverlay.OverlayShape.Cylinder;
				Vector2Int baseResolutionToUse = _canvasRenderTexture.GetBaseResolutionToUse();
				position = new Vector3(0f, 0f, 0f - canvasCylinder.Radius) - _runtimeOffset;
				scale = new Vector3(_canvasRenderTexture.PixelsToUnits(baseResolutionToUse.x) / canvasCylinder.transform.lossyScale.x, _canvasRenderTexture.PixelsToUnits(baseResolutionToUse.y) / canvasCylinder.transform.lossyScale.y, canvasCylinder.Radius);
				return true;
			}
			if (_canvasMesh is CanvasRect)
			{
				shape = OVROverlay.OverlayShape.Quad;
				Vector2Int baseResolutionToUse2 = _canvasRenderTexture.GetBaseResolutionToUse();
				position = -_runtimeOffset;
				scale = new Vector3(_canvasRenderTexture.PixelsToUnits(baseResolutionToUse2.x), _canvasRenderTexture.PixelsToUnits(baseResolutionToUse2.y), 1f);
				return true;
			}
			shape = OVROverlay.OverlayShape.Quad;
			position = Vector3.zero;
			scale = Vector3.zero;
			return false;
		}

		protected override void Start()
		{
			this.BeginStart(ref _started, delegate
			{
				base.Start();
			});
			this.EndStart(ref _started);
		}

		protected void UpdateOverlay(Texture texture)
		{
			try
			{
				if (!ShouldUseOVROverlay)
				{
					_overlay?.gameObject?.SetActive(value: false);
					return;
				}
				if (_overlay == null)
				{
					GameObject gameObject = CreateChildObject("__Overlay");
					_overlay = gameObject.AddComponent<OVROverlay>();
					_overlay.isAlphaPremultiplied = !Application.isMobilePlatform;
				}
				else
				{
					_overlay.gameObject.SetActive(value: true);
				}
				if (!GetOverlayParameters(out var shape, out var position, out var scale))
				{
					_overlay.gameObject.SetActive(value: false);
					return;
				}
				bool flag = RenderingMode == OVRRenderingMode.Underlay;
				_overlay.textures = new Texture[1] { texture };
				_overlay.noDepthBufferTesting = flag;
				_overlay.currentOverlayType = (flag ? OVROverlay.OverlayType.Underlay : OVROverlay.OverlayType.Overlay);
				_overlay.currentOverlayShape = shape;
				_overlay.useExpensiveSuperSample = _enableSuperSampling;
				_overlay.transform.localPosition = position;
				_overlay.transform.localScale = scale;
			}
			finally
			{
			}
		}

		protected GameObject CreateChildObject(string name)
		{
			GameObject obj = new GameObject(name);
			obj.transform.SetParent(base.transform);
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localRotation = Quaternion.identity;
			obj.transform.localScale = Vector3.one;
			return obj;
		}

		public void InjectAllOVRCanvasMeshRenderer(CanvasRenderTexture canvasRenderTexture, MeshRenderer meshRenderer, CanvasMesh canvasMesh)
		{
			InjectAllCanvasMeshRenderer(canvasRenderTexture, meshRenderer);
			InjectCanvasMesh(canvasMesh);
		}

		public void InjectCanvasMesh(CanvasMesh canvasMesh)
		{
			_canvasMesh = canvasMesh;
		}

		public void InjectOptionalRenderingMode(OVRRenderingMode ovrRenderingMode)
		{
			_renderingMode = (int)ovrRenderingMode;
		}

		public void InjectOptionalDoUnderlayAntiAliasing(bool doUnderlayAntiAliasing)
		{
			_doUnderlayAntiAliasing = doUnderlayAntiAliasing;
		}

		public void InjectOptionalEnableSuperSampling(bool enableSuperSampling)
		{
			_enableSuperSampling = enableSuperSampling;
		}
	}
	public enum OVRRenderingMode
	{
		[InspectorName("Alpha-Blended")]
		AlphaBlended = 0,
		[InspectorName("Alpha-Cutout")]
		AlphaCutout = 1,
		[InspectorName("Opaque")]
		Opaque = 2,
		[InspectorName("OVR/Overlay")]
		Overlay = 100,
		[InspectorName("OVR/Underlay")]
		Underlay = 101
	}
}
namespace Oculus.Interaction.OVR
{
	[Feature(Feature.Interaction)]
	public class OVRControllerInHandActiveState : MonoBehaviour, IActiveState
	{
		[SerializeField]
		private OVRInput.Hand _handType;

		[SerializeField]
		[Tooltip("Determines if the ActiveState should be enabled or disabled when the hand is grabbing a controller")]
		[HelpBox("Ensure you have enabled ConformingHandsToControllers or/and Concurrent Hands/Controller Support in the OVRCameraRig.ControllerDrivenHandPosesType and that the OVRHand component ShowState is as permissive as this.", HelpBoxAttribute.MessageType.Info, OVRInput.InputDeviceShowState.ControllerNotInHand, ConditionalHideAttribute.DisplayMode.HideIfTrue)]
		private OVRInput.InputDeviceShowState _showState = OVRInput.InputDeviceShowState.ControllerNotInHand;

		public OVRInput.Hand HandType
		{
			get
			{
				return _handType;
			}
			set
			{
				_handType = value;
			}
		}

		public OVRInput.InputDeviceShowState ShowState
		{
			get
			{
				return _showState;
			}
			set
			{
				_showState = value;
			}
		}

		public bool Active
		{
			get
			{
				OVRInput.ControllerInHandState controllerIsInHandState = OVRInput.GetControllerIsInHandState(_handType);
				switch (_showState)
				{
				case OVRInput.InputDeviceShowState.Always:
					return true;
				case OVRInput.InputDeviceShowState.ControllerInHand:
					return controllerIsInHandState == OVRInput.ControllerInHandState.ControllerInHand;
				case OVRInput.InputDeviceShowState.ControllerInHandOrNoHand:
					if (controllerIsInHandState != OVRInput.ControllerInHandState.ControllerInHand)
					{
						return controllerIsInHandState == OVRInput.ControllerInHandState.NoHand;
					}
					return true;
				case OVRInput.InputDeviceShowState.ControllerNotInHand:
					return controllerIsInHandState == OVRInput.ControllerInHandState.ControllerNotInHand;
				case OVRInput.InputDeviceShowState.NoHand:
					return controllerIsInHandState == OVRInput.ControllerInHandState.NoHand;
				default:
					return false;
				}
			}
		}
	}
}
namespace Oculus.Interaction.OVR.Input
{
	[Feature(Feature.Interaction)]
	public class OVRAxis1D : MonoBehaviour, IAxis1D
	{
		[Serializable]
		public class RemapConfig
		{
			public bool Enabled;

			public AnimationCurve Curve;
		}

		[SerializeField]
		private OVRInput.Controller _controller;

		[SerializeField]
		private OVRInput.Axis1D _axis1D;

		[SerializeField]
		private RemapConfig _remapConfig = new RemapConfig
		{
			Enabled = false,
			Curve = AnimationCurve.Linear(0f, 0f, 1f, 1f)
		};

		public float Value()
		{
			float num = OVRInput.Get(_axis1D, _controller);
			if (_remapConfig.Enabled)
			{
				num = _remapConfig.Curve.Evaluate(num);
			}
			return num;
		}
	}
	[Feature(Feature.Interaction)]
	public class OVRAxis2D : MonoBehaviour, IAxis2D
	{
		[SerializeField]
		private OVRInput.Controller _controller;

		[SerializeField]
		private OVRInput.Axis2D _axis2D;

		public Vector2 Value()
		{
			return OVRInput.Get(_axis2D, _controller);
		}
	}
	[Feature(Feature.Interaction)]
	public class OVRButton : MonoBehaviour, IButton
	{
		[SerializeField]
		private OVRInput.Controller _controller;

		[SerializeField]
		private OVRInput.Button _button;

		public bool Value()
		{
			return OVRInput.Get(_button, _controller);
		}
	}
	[Feature(Feature.Interaction)]
	public class OVRButtonActiveState : MonoBehaviour, IActiveState
	{
		[SerializeField]
		private OVRInput.Button _button;

		public bool Active => OVRInput.Get(_button);
	}
}
namespace Oculus.Interaction.Input
{
	[Feature(Feature.Interaction)]
	public class AnimatedHandOVR : MonoBehaviour, IDeltaTimeConsumer
	{
		public enum AllowThumbUp
		{
			Always,
			GripRequired,
			TriggerAndGripRequired
		}

		[SerializeField]
		private OVRInput.Controller _controller;

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		[Tooltip("Indicates the input needed in order to perform a thumbs-up when the fist is closed")]
		private AllowThumbUp _allowThumbUp = AllowThumbUp.TriggerAndGripRequired;

		[Header("Animation Speed")]
		[SerializeField]
		[FormerlySerializedAs("_animFlexhGain")]
		[Tooltip("Speed of the index flex animation")]
		private float _animFlexGain = 35f;

		[SerializeField]
		[Tooltip("Speed of the pinch animation")]
		private float _animPinchGain = 35f;

		[SerializeField]
		[Tooltip("Speed of the point, slide and thumbs up animation")]
		private float _animPointAndThumbsUpGain = 20f;

		private const string ANIM_LAYER_NAME_POINT = "Point Layer";

		private const string ANIM_LAYER_NAME_THUMB = "Thumb Layer";

		private const string ANIM_PARAM_NAME_FLEX = "Flex";

		private const string ANIM_PARAM_NAME_PINCH = "Pinch";

		private const string ANIM_PARAM_NAME_INDEX_SLIDE = "IndexSlide";

		private const float TRIGGER_MAX = 0.95f;

		private int _animLayerIndexThumb = -1;

		private int _animLayerIndexPoint = -1;

		private int _animParamIndexFlex = Animator.StringToHash("Flex");

		private int _animParamPinch = Animator.StringToHash("Pinch");

		private int _animParamIndexSlide = Animator.StringToHash("IndexSlide");

		private bool _isGivingThumbsUp;

		private float _pointBlend;

		private float _slideBlend;

		private float _thumbsUpBlend;

		private float _pointTarget;

		private float _slideTarget;

		private float _animFlex;

		private float _animPinch;

		private Func<float> _deltaTimeProvider = () => Time.deltaTime;

		public AllowThumbUp AllowThumbUpMode
		{
			get
			{
				return _allowThumbUp;
			}
			set
			{
				_allowThumbUp = value;
			}
		}

		public float AnimFlexGain
		{
			get
			{
				return _animFlexGain;
			}
			set
			{
				_animFlexGain = value;
			}
		}

		public float AnimPinchGain
		{
			get
			{
				return _animPinchGain;
			}
			set
			{
				_animPinchGain = value;
			}
		}

		public float AnimPointAndThumbsUpGain
		{
			get
			{
				return _animPointAndThumbsUpGain;
			}
			set
			{
				_animPointAndThumbsUpGain = value;
			}
		}

		public Func<float> DeltaTimeProvider { get; set; } = () => Time.deltaTime;

		public void SetDeltaTimeProvider(Func<float> deltaTimeProvider)
		{
			_deltaTimeProvider = deltaTimeProvider;
		}

		protected virtual void Start()
		{
			_animLayerIndexPoint = _animator.GetLayerIndex("Point Layer");
			_animLayerIndexThumb = _animator.GetLayerIndex("Thumb Layer");
		}

		protected virtual void Update()
		{
			UpdateCapTouchStates();
			_pointBlend = Mathf.Lerp(_pointBlend, _pointTarget, _animPointAndThumbsUpGain * _deltaTimeProvider());
			_slideBlend = Mathf.Lerp(_slideBlend, _slideTarget, _animPointAndThumbsUpGain * _deltaTimeProvider());
			_thumbsUpBlend = Mathf.Lerp(_thumbsUpBlend, _isGivingThumbsUp ? 1 : 0, _animPointAndThumbsUpGain * _deltaTimeProvider());
			UpdateAnimStates();
		}

		private void UpdateCapTouchStates()
		{
			float indexCurl = OVRControllerUtility.GetIndexCurl(_controller);
			float indexSlide = OVRControllerUtility.GetIndexSlide(_controller);
			_pointTarget = 1f - indexCurl;
			_slideTarget = indexSlide;
			bool flag = _allowThumbUp == AllowThumbUp.Always || (_allowThumbUp == AllowThumbUp.GripRequired && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, _controller) >= 0.95f) || (_allowThumbUp == AllowThumbUp.TriggerAndGripRequired && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, _controller) >= 0.95f && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, _controller) >= 0.95f);
			_isGivingThumbsUp = flag && !OVRInput.Get(OVRInput.NearTouch.PrimaryThumbButtons, _controller);
		}

		private void UpdateAnimStates()
		{
			float b = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, _controller);
			_animFlex = Mathf.Lerp(_animFlex, b, _animFlexGain * DeltaTimeProvider());
			_animator.SetFloat(_animParamIndexFlex, _animFlex);
			float b2 = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, _controller);
			_animPinch = Mathf.Lerp(_animPinch, b2, _animPinchGain * DeltaTimeProvider());
			_animator.SetFloat(_animParamPinch, _animPinch);
			_animator.SetLayerWeight(_animLayerIndexPoint, _pointBlend);
			_animator.SetFloat(_animParamIndexSlide, _slideBlend);
			_animator.SetLayerWeight(_animLayerIndexThumb, _thumbsUpBlend);
		}

		public void InjectAllAnimatedHandOVR(OVRInput.Controller controller, Animator animator)
		{
			InjectController(controller);
			InjectAnimator(animator);
		}

		public void InjectController(OVRInput.Controller controller)
		{
			_controller = controller;
		}

		public void InjectAnimator(Animator animator)
		{
			_animator = animator;
		}
	}
	internal interface IUsage
	{
		void Apply(ControllerDataAsset controllerDataAsset, OVRInput.Controller controllerMask);
	}
	internal class UsageTouchMapping : IUsage
	{
		public ControllerButtonUsage Usage { get; }

		public OVRInput.Touch Touch { get; }

		public UsageTouchMapping(ControllerButtonUsage usage, OVRInput.Touch touch)
		{
			Usage = usage;
			Touch = touch;
		}

		public void Apply(ControllerDataAsset controllerDataAsset, OVRInput.Controller controllerMask)
		{
			bool value = OVRInput.Get(Touch, controllerMask);
			controllerDataAsset.Input.SetButton(Usage, value);
		}
	}
	internal class UsageButtonMapping : IUsage
	{
		public ControllerButtonUsage Usage { get; }

		public OVRInput.Button Button { get; }

		public UsageButtonMapping(ControllerButtonUsage usage, OVRInput.Button button)
		{
			Usage = usage;
			Button = button;
		}

		public void Apply(ControllerDataAsset controllerDataAsset, OVRInput.Controller controllerMask)
		{
			bool value = OVRInput.Get(Button, controllerMask);
			controllerDataAsset.Input.SetButton(Usage, value);
		}
	}
	internal class UsageAxis1DMapping : IUsage
	{
		public ControllerAxis1DUsage Usage { get; }

		public OVRInput.Axis1D Axis1D { get; }

		public UsageAxis1DMapping(ControllerAxis1DUsage usage, OVRInput.Axis1D axis1D)
		{
			Usage = usage;
			Axis1D = axis1D;
		}

		public void Apply(ControllerDataAsset controllerDataAsset, OVRInput.Controller controllerMask)
		{
			float value = OVRInput.Get(Axis1D, controllerMask);
			controllerDataAsset.Input.SetAxis1D(Usage, value);
		}
	}
	internal class UsageAxis2DMapping : IUsage
	{
		public ControllerAxis2DUsage Usage { get; }

		public OVRInput.Axis2D Axis2D { get; }

		public UsageAxis2DMapping(ControllerAxis2DUsage usage, OVRInput.Axis2D axis2D)
		{
			Usage = usage;
			Axis2D = axis2D;
		}

		public void Apply(ControllerDataAsset controllerDataAsset, OVRInput.Controller controllerMask)
		{
			Vector2 value = OVRInput.Get(Axis2D, controllerMask);
			controllerDataAsset.Input.SetAxis2D(Usage, value);
		}
	}
	internal struct OVRPointerPoseSelector
	{
		private static readonly Pose[] QUEST1_POINTERS = new Pose[2]
		{
			new Pose(new Vector3(-0.0078f, -0.0041f, 0.0375f), Quaternion.Euler(359.20953f, 6.4519606f, 6.955446f)),
			new Pose(new Vector3(0.0078f, -0.0041f, 0.0375f), Quaternion.Euler(359.20953f, 353.54803f, 353.04456f))
		};

		private static readonly Pose[] QUEST2_POINTERS = new Pose[2]
		{
			new Pose(new Vector3(0.009f, -0.0032102852f, 0.030869998f), Quaternion.Euler(359.20953f, 6.4519606f, 6.955446f)),
			new Pose(new Vector3(-0.009f, -0.0032102852f, 0.030869998f), Quaternion.Euler(359.20953f, 353.54803f, 353.04456f))
		};

		public Pose LocalPointerPose { get; private set; }

		public OVRPointerPoseSelector(Handedness handedness)
		{
			OVRPlugin.SystemHeadset systemHeadsetType = OVRPlugin.GetSystemHeadsetType();
			if (systemHeadsetType == OVRPlugin.SystemHeadset.Oculus_Quest_2 || systemHeadsetType == OVRPlugin.SystemHeadset.Oculus_Link_Quest_2)
			{
				LocalPointerPose = QUEST2_POINTERS[(int)handedness];
			}
			else
			{
				LocalPointerPose = QUEST1_POINTERS[(int)handedness];
			}
		}
	}
	[Feature(Feature.Interaction)]
	public class FromOVRControllerDataSource : DataSource<ControllerDataAsset>
	{
		[Header("OVR Data Source")]
		[SerializeField]
		[Interface(typeof(IOVRCameraRigRef), new Type[] { })]
		private UnityEngine.Object _cameraRigRef;

		[SerializeField]
		private bool _processLateUpdates;

		[Header("Shared Configuration")]
		[SerializeField]
		private Handedness _handedness;

		[SerializeField]
		[Interface(typeof(ITrackingToWorldTransformer), new Type[] { })]
		private UnityEngine.Object _trackingToWorldTransformer;

		private ITrackingToWorldTransformer TrackingToWorldTransformer;

		private readonly ControllerDataAsset _controllerDataAsset = new ControllerDataAsset();

		private OVRInput.Controller _ovrController;

		private ControllerDataSourceConfig _config;

		private OVRPointerPoseSelector _pointerPoseSelector;

		private static readonly IUsage[] ControllerUsageMappings = new IUsage[13]
		{
			new UsageButtonMapping(ControllerButtonUsage.PrimaryButton, OVRInput.Button.One),
			new UsageTouchMapping(ControllerButtonUsage.PrimaryTouch, OVRInput.Touch.One),
			new UsageButtonMapping(ControllerButtonUsage.SecondaryButton, OVRInput.Button.Two),
			new UsageTouchMapping(ControllerButtonUsage.SecondaryTouch, OVRInput.Touch.Two),
			new UsageButtonMapping(ControllerButtonUsage.GripButton, OVRInput.Button.PrimaryHandTrigger),
			new UsageButtonMapping(ControllerButtonUsage.TriggerButton, OVRInput.Button.PrimaryIndexTrigger),
			new UsageButtonMapping(ControllerButtonUsage.MenuButton, OVRInput.Button.Start),
			new UsageButtonMapping(ControllerButtonUsage.Primary2DAxisClick, OVRInput.Button.PrimaryThumbstick),
			new UsageTouchMapping(ControllerButtonUsage.Primary2DAxisTouch, OVRInput.Touch.PrimaryThumbstick),
			new UsageTouchMapping(ControllerButtonUsage.Thumbrest, OVRInput.Touch.PrimaryThumbRest),
			new UsageAxis1DMapping(ControllerAxis1DUsage.Trigger, OVRInput.Axis1D.PrimaryIndexTrigger),
			new UsageAxis1DMapping(ControllerAxis1DUsage.Grip, OVRInput.Axis1D.PrimaryHandTrigger),
			new UsageAxis2DMapping(ControllerAxis2DUsage.Primary2DAxis, OVRInput.Axis2D.PrimaryThumbstick)
		};

		public IOVRCameraRigRef CameraRigRef { get; private set; }

		public bool ProcessLateUpdates
		{
			get
			{
				return _processLateUpdates;
			}
			set
			{
				_processLateUpdates = value;
			}
		}

		private ControllerDataSourceConfig Config
		{
			get
			{
				if (_config != null)
				{
					return _config;
				}
				_config = new ControllerDataSourceConfig
				{
					Handedness = _handedness
				};
				return _config;
			}
		}

		protected override ControllerDataAsset DataAsset => _controllerDataAsset;

		protected void Awake()
		{
			TrackingToWorldTransformer = _trackingToWorldTransformer as ITrackingToWorldTransformer;
			CameraRigRef = _cameraRigRef as IOVRCameraRigRef;
			UpdateConfig();
		}

		protected override void Start()
		{
			this.BeginStart(ref _started, delegate
			{
				base.Start();
			});
			if (_handedness == Handedness.Left)
			{
				_ovrController = OVRInput.Controller.LTouch;
			}
			else
			{
				_ovrController = OVRInput.Controller.RTouch;
			}
			_pointerPoseSelector = new OVRPointerPoseSelector(_handedness);
			UpdateConfig();
			this.EndStart(ref _started);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (_started)
			{
				CameraRigRef.WhenInputDataDirtied += HandleInputDataDirtied;
			}
		}

		protected override void OnDisable()
		{
			if (_started)
			{
				CameraRigRef.WhenInputDataDirtied -= HandleInputDataDirtied;
			}
			base.OnDisable();
			MarkInputDataRequiresUpdate();
		}

		private void HandleInputDataDirtied(bool isLateUpdate)
		{
			if (!isLateUpdate || _processLateUpdates)
			{
				MarkInputDataRequiresUpdate();
			}
		}

		private void UpdateConfig()
		{
			Config.Handedness = _handedness;
			Config.TrackingToWorldTransformer = TrackingToWorldTransformer;
		}

		protected override void UpdateData()
		{
			_controllerDataAsset.Config = Config;
			_controllerDataAsset.IsDataValid = true;
			_controllerDataAsset.IsConnected = (OVRInput.GetConnectedControllers() & _ovrController) > OVRInput.Controller.None;
			if (!_controllerDataAsset.IsConnected || !base.isActiveAndEnabled)
			{
				_controllerDataAsset.IsConnected = false;
				_controllerDataAsset.IsTracked = false;
				_controllerDataAsset.Input = default(ControllerInput);
				_controllerDataAsset.RootPoseOrigin = PoseOrigin.None;
				return;
			}
			_controllerDataAsset.IsTracked = true;
			OVRInput.Handedness dominantHand = OVRInput.GetDominantHand();
			_controllerDataAsset.IsDominantHand = (dominantHand == OVRInput.Handedness.LeftHanded && _handedness == Handedness.Left) || (dominantHand == OVRInput.Handedness.RightHanded && _handedness == Handedness.Right);
			_controllerDataAsset.Input.Clear();
			OVRInput.Controller ovrController = _ovrController;
			IUsage[] controllerUsageMappings = ControllerUsageMappings;
			for (int i = 0; i < controllerUsageMappings.Length; i++)
			{
				controllerUsageMappings[i].Apply(_controllerDataAsset, ovrController);
			}
			_controllerDataAsset.RootPose = new Pose(OVRInput.GetLocalControllerPosition(_ovrController), OVRInput.GetLocalControllerRotation(_ovrController));
			_controllerDataAsset.RootPoseOrigin = PoseOrigin.RawTrackedPose;
			Matrix4x4 matrix4x = Matrix4x4.TRS(_controllerDataAsset.RootPose.position, _controllerDataAsset.RootPose.rotation, Vector3.one);
			_controllerDataAsset.PointerPose = new Pose(matrix4x.MultiplyPoint3x4(_pointerPoseSelector.LocalPointerPose.position), _controllerDataAsset.RootPose.rotation * _pointerPoseSelector.LocalPointerPose.rotation);
			_controllerDataAsset.PointerPoseOrigin = PoseOrigin.RawTrackedPose;
		}

		public void InjectAllFromOVRControllerDataSource(UpdateModeFlags updateMode, IDataSource updateAfter, Handedness handedness, ITrackingToWorldTransformer trackingToWorldTransformer)
		{
			InjectAllDataSource(updateMode, updateAfter);
			InjectHandedness(handedness);
			InjectTrackingToWorldTransformer(trackingToWorldTransformer);
		}

		public void InjectHandedness(Handedness handedness)
		{
			_handedness = handedness;
		}

		public void InjectTrackingToWorldTransformer(ITrackingToWorldTransformer trackingToWorldTransformer)
		{
			_trackingToWorldTransformer = trackingToWorldTransformer as UnityEngine.Object;
			TrackingToWorldTransformer = trackingToWorldTransformer;
		}
	}
	[Feature(Feature.Interaction)]
	public class FromOVRHandDataSource : DataSource<HandDataAsset>
	{
		[Header("OVR Data Source")]
		[SerializeField]
		[Interface(typeof(IOVRCameraRigRef), new Type[] { })]
		private UnityEngine.Object _cameraRigRef;

		[SerializeField]
		private bool _processLateUpdates;

		[Header("Shared Configuration")]
		[SerializeField]
		private Handedness _handedness;

		[SerializeField]
		[Optional(OptionalAttribute.Flag.AutoGenerated)]
		private OVRHand _ovrHand;

		[SerializeField]
		[Interface(typeof(ITrackingToWorldTransformer), new Type[] { })]
		private UnityEngine.Object _trackingToWorldTransformer;

		private ITrackingToWorldTransformer TrackingToWorldTransformer;

		[SerializeField]
		[Interface(typeof(IHandSkeletonProvider), new Type[] { })]
		private UnityEngine.Object _handSkeletonProvider;

		private IHandSkeletonProvider HandSkeletonProvider;

		private readonly HandDataAsset _handDataAsset = new HandDataAsset();

		private float _lastHandScale;

		private HandDataSourceConfig _config;

		private IOVRCameraRigRef CameraRigRef;

		public bool ProcessLateUpdates
		{
			get
			{
				return _processLateUpdates;
			}
			set
			{
				_processLateUpdates = value;
			}
		}

		protected override HandDataAsset DataAsset => _handDataAsset;

		public static Quaternion WristFixupRotation { get; } = new Quaternion(0f, 1f, 0f, 0f);

		private HandDataSourceConfig Config
		{
			get
			{
				if (_config != null)
				{
					return _config;
				}
				_config = new HandDataSourceConfig
				{
					Handedness = _handedness
				};
				return _config;
			}
		}

		protected virtual void Awake()
		{
			TrackingToWorldTransformer = _trackingToWorldTransformer as ITrackingToWorldTransformer;
			CameraRigRef = _cameraRigRef as IOVRCameraRigRef;
			HandSkeletonProvider = _handSkeletonProvider as IHandSkeletonProvider;
			UpdateConfig();
		}

		protected override void Start()
		{
			this.BeginStart(ref _started, delegate
			{
				base.Start();
			});
			if (_ovrHand == null)
			{
				_ovrHand = ((_handedness == Handedness.Left) ? CameraRigRef.LeftHand : CameraRigRef.RightHand);
			}
			UpdateConfig();
			_ = OVRRuntimeSettings.GetRuntimeSettings().HandSkeletonVersion;
			this.EndStart(ref _started);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (_started)
			{
				CameraRigRef.WhenInputDataDirtied += HandleInputDataDirtied;
			}
		}

		protected override void OnDisable()
		{
			if (_started)
			{
				CameraRigRef.WhenInputDataDirtied -= HandleInputDataDirtied;
			}
			base.OnDisable();
			MarkInputDataRequiresUpdate();
		}

		private void HandleInputDataDirtied(bool isLateUpdate)
		{
			if (!isLateUpdate || _processLateUpdates)
			{
				MarkInputDataRequiresUpdate();
			}
		}

		private void UpdateConfig()
		{
			Config.Handedness = _handedness;
			Config.TrackingToWorldTransformer = TrackingToWorldTransformer;
			Config.HandSkeleton = HandSkeletonProvider[_handedness];
		}

		protected override void UpdateData()
		{
			_handDataAsset.Config = Config;
			_handDataAsset.IsDataValid = true;
			_handDataAsset.IsConnected = false;
			if (_ovrHand != null && _ovrHand.isActiveAndEnabled && base.isActiveAndEnabled)
			{
				OVRSkeleton.SkeletonPoseData skeletonPoseData = ((OVRSkeleton.IOVRSkeletonDataProvider)_ovrHand).GetSkeletonPoseData();
				_handDataAsset.IsConnected = skeletonPoseData.IsDataValid && skeletonPoseData.RootScale > 0f;
				if (!_handDataAsset.IsConnected)
				{
					if (_lastHandScale <= 0f)
					{
						skeletonPoseData.IsDataValid = false;
					}
					else
					{
						skeletonPoseData.RootScale = _lastHandScale;
					}
				}
				else
				{
					_lastHandScale = skeletonPoseData.RootScale;
				}
				if (skeletonPoseData.IsDataValid && _handDataAsset.IsConnected)
				{
					UpdateDataPoses(skeletonPoseData);
					return;
				}
			}
			_handDataAsset.IsConnected = false;
			_handDataAsset.IsTracked = false;
			_handDataAsset.RootPoseOrigin = PoseOrigin.None;
			_handDataAsset.PointerPoseOrigin = PoseOrigin.None;
			_handDataAsset.IsHighConfidence = false;
			for (int i = 0; i < 5; i++)
			{
				_handDataAsset.IsFingerPinching[i] = false;
				_handDataAsset.IsFingerHighConfidence[i] = false;
			}
		}

		private void UpdateDataPoses(OVRSkeleton.SkeletonPoseData poseData)
		{
			_handDataAsset.HandScale = poseData.RootScale;
			_handDataAsset.IsTracked = _ovrHand.IsTracked;
			_handDataAsset.IsHighConfidence = poseData.IsDataHighConfidence;
			_handDataAsset.IsDominantHand = _ovrHand.IsDominantHand;
			_handDataAsset.RootPoseOrigin = (_handDataAsset.IsTracked ? PoseOrigin.RawTrackedPose : PoseOrigin.None);
			for (int i = 0; i < 5; i++)
			{
				OVRHand.HandFinger finger = (OVRHand.HandFinger)i;
				bool fingerIsPinching = _ovrHand.GetFingerIsPinching(finger);
				_handDataAsset.IsFingerPinching[i] = fingerIsPinching;
				bool flag = _ovrHand.GetFingerConfidence(finger) == OVRHand.TrackingConfidence.High;
				_handDataAsset.IsFingerHighConfidence[i] = flag;
				float fingerPinchStrength = _ovrHand.GetFingerPinchStrength(finger);
				_handDataAsset.FingerPinchStrength[i] = fingerPinchStrength;
			}
			_handDataAsset.Root = new Pose
			{
				position = poseData.RootPose.Position.FromFlippedZVector3f(),
				rotation = poseData.RootPose.Orientation.FromFlippedZQuatf()
			};
			if (_ovrHand.IsPointerPoseValid)
			{
				_handDataAsset.PointerPoseOrigin = PoseOrigin.RawTrackedPose;
				_handDataAsset.PointerPose = new Pose(_ovrHand.PointerPose.localPosition, _ovrHand.PointerPose.localRotation);
			}
			else
			{
				_handDataAsset.PointerPoseOrigin = PoseOrigin.None;
			}
			float num = ((_handDataAsset.HandScale > 0f) ? (1f / _handDataAsset.HandScale) : 0f);
			OVRPlugin.Skeleton2 ovrSkeleton = ((_handedness == Handedness.Left) ? OVRSkeletonData.LeftSkeleton : OVRSkeletonData.RightSkeleton);
			for (int j = 0; j < 26; j++)
			{
				Pose to = new Pose(poseData.BoneTranslations[j].FromFlippedZVector3f(), poseData.BoneRotations[j].FromFlippedZQuatf());
				Pose pose = PoseUtils.Delta(in _handDataAsset.Root, in to);
				pose.position *= num;
				_handDataAsset.JointPoses[j] = pose;
				_handDataAsset.JointRadii[j] = HandSkeletonOVR.GetBoneRadius(in ovrSkeleton, j);
			}
			HandJointUtils.WristJointPosesToLocalRotations(_handDataAsset.JointPoses, ref _handDataAsset.Joints);
		}

		public void InjectAllFromOVRHandDataSource(UpdateModeFlags updateMode, IDataSource updateAfter, Handedness handedness, ITrackingToWorldTransformer trackingToWorldTransformer, IHandSkeletonProvider handSkeletonProvider)
		{
			InjectAllDataSource(updateMode, updateAfter);
			InjectHandedness(handedness);
			InjectTrackingToWorldTransformer(trackingToWorldTransformer);
			InjectHandSkeletonProvider(handSkeletonProvider);
		}

		public void InjectHandedness(Handedness handedness)
		{
			_handedness = handedness;
		}

		public void InjectTrackingToWorldTransformer(ITrackingToWorldTransformer trackingToWorldTransformer)
		{
			_trackingToWorldTransformer = trackingToWorldTransformer as UnityEngine.Object;
			TrackingToWorldTransformer = trackingToWorldTransformer;
		}

		public void InjectHandSkeletonProvider(IHandSkeletonProvider handSkeletonProvider)
		{
			_handSkeletonProvider = handSkeletonProvider as UnityEngine.Object;
			HandSkeletonProvider = handSkeletonProvider;
		}

		public void InjectOptionalOVRHand(OVRHand ovrHand)
		{
			_ovrHand = ovrHand;
		}
	}
	[Feature(Feature.Interaction)]
	public class FromOVRHmdDataSource : DataSource<HmdDataAsset>
	{
		[Header("OVR Data Source")]
		[SerializeField]
		[Interface(typeof(IOVRCameraRigRef), new Type[] { })]
		private UnityEngine.Object _cameraRigRef;

		[SerializeField]
		private bool _processLateUpdates;

		[SerializeField]
		[Tooltip("If true, uses OVRManager.headPoseRelativeOffset rather than sensor data for HMD pose.")]
		private bool _useOvrManagerEmulatedPose;

		[Header("Shared Configuration")]
		[SerializeField]
		[Interface(typeof(ITrackingToWorldTransformer), new Type[] { })]
		private UnityEngine.Object _trackingToWorldTransformer;

		private ITrackingToWorldTransformer TrackingToWorldTransformer;

		private HmdDataAsset _hmdDataAsset = new HmdDataAsset();

		private HmdDataSourceConfig _config;

		public IOVRCameraRigRef CameraRigRef { get; private set; }

		public bool ProcessLateUpdates
		{
			get
			{
				return _processLateUpdates;
			}
			set
			{
				_processLateUpdates = value;
			}
		}

		private HmdDataSourceConfig Config
		{
			get
			{
				if (_config != null)
				{
					return _config;
				}
				_config = new HmdDataSourceConfig
				{
					TrackingToWorldTransformer = TrackingToWorldTransformer
				};
				return _config;
			}
		}

		protected override HmdDataAsset DataAsset => _hmdDataAsset;

		protected void Awake()
		{
			CameraRigRef = _cameraRigRef as IOVRCameraRigRef;
			TrackingToWorldTransformer = _trackingToWorldTransformer as ITrackingToWorldTransformer;
		}

		protected override void Start()
		{
			this.BeginStart(ref _started, delegate
			{
				base.Start();
			});
			this.EndStart(ref _started);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (_started)
			{
				CameraRigRef.WhenInputDataDirtied += HandleInputDataDirtied;
			}
		}

		protected override void OnDisable()
		{
			if (_started)
			{
				CameraRigRef.WhenInputDataDirtied -= HandleInputDataDirtied;
			}
			base.OnDisable();
			MarkInputDataRequiresUpdate();
		}

		private void HandleInputDataDirtied(bool isLateUpdate)
		{
			if (!isLateUpdate || _processLateUpdates)
			{
				MarkInputDataRequiresUpdate();
			}
		}

		protected override void UpdateData()
		{
			_hmdDataAsset.Config = Config;
			bool flag = OVRNodeStateProperties.IsHmdPresent() && base.isActiveAndEnabled;
			ref Pose root = ref _hmdDataAsset.Root;
			if (_useOvrManagerEmulatedPose)
			{
				Quaternion rotation = Quaternion.Euler(0f - OVRManager.instance.headPoseRelativeOffsetRotation.x, 0f - OVRManager.instance.headPoseRelativeOffsetRotation.y, OVRManager.instance.headPoseRelativeOffsetRotation.z);
				root.rotation = rotation;
				root.position = OVRManager.instance.headPoseRelativeOffsetTranslation;
				flag = true;
			}
			else
			{
				Pose pose = Pose.identity;
				if (_hmdDataAsset.IsTracked)
				{
					pose = _hmdDataAsset.Root;
				}
				if (flag)
				{
					if (!OVRNodeStateProperties.GetNodeStatePropertyVector3(XRNode.CenterEye, NodeStatePropertyType.Position, OVRPlugin.Node.EyeCenter, OVRPlugin.Step.Render, out root.position))
					{
						root.position = pose.position;
					}
					if (!OVRNodeStateProperties.GetNodeStatePropertyQuaternion(XRNode.CenterEye, NodeStatePropertyType.Orientation, OVRPlugin.Node.EyeCenter, OVRPlugin.Step.Render, out root.rotation))
					{
						root.rotation = pose.rotation;
					}
				}
				else
				{
					root = pose;
				}
			}
			_hmdDataAsset.IsTracked = flag;
			_hmdDataAsset.FrameId = Time.frameCount;
		}

		public void InjectAllFromOVRHmdDataSource(UpdateModeFlags updateMode, IDataSource updateAfter, bool useOvrManagerEmulatedPose, ITrackingToWorldTransformer trackingToWorldTransformer)
		{
			InjectAllDataSource(updateMode, updateAfter);
			InjectUseOvrManagerEmulatedPose(useOvrManagerEmulatedPose);
			InjectTrackingToWorldTransformer(trackingToWorldTransformer);
		}

		public void InjectUseOvrManagerEmulatedPose(bool useOvrManagerEmulatedPose)
		{
			_useOvrManagerEmulatedPose = useOvrManagerEmulatedPose;
		}

		public void InjectTrackingToWorldTransformer(ITrackingToWorldTransformer trackingToWorldTransformer)
		{
			_trackingToWorldTransformer = trackingToWorldTransformer as UnityEngine.Object;
			TrackingToWorldTransformer = trackingToWorldTransformer;
		}
	}
	[Feature(Feature.Interaction)]
	public class HandSkeletonOVR : MonoBehaviour, IHandSkeletonProvider
	{
		private readonly HandSkeleton[] _skeletons = new HandSkeleton[2]
		{
			new HandSkeleton(),
			new HandSkeleton()
		};

		public HandSkeleton this[Handedness handedness] => _skeletons[(int)handedness];

		protected void Awake()
		{
			ApplyToSkeleton(in OVRSkeletonData.LeftSkeleton, _skeletons[0]);
			ApplyToSkeleton(in OVRSkeletonData.RightSkeleton, _skeletons[1]);
		}

		public static HandSkeleton CreateSkeletonData(Handedness handedness)
		{
			HandSkeleton handSkeleton = new HandSkeleton();
			if (handedness == Handedness.Left)
			{
				ApplyToSkeleton(in OVRSkeletonData.LeftSkeleton, handSkeleton);
			}
			else
			{
				ApplyToSkeleton(in OVRSkeletonData.RightSkeleton, handSkeleton);
			}
			return handSkeleton;
		}

		private static void ApplyToSkeleton(in OVRPlugin.Skeleton2 ovrSkeleton, HandSkeleton handSkeleton)
		{
			int num = handSkeleton.joints.Length;
			for (int i = 0; i < num; i++)
			{
				ref OVRPlugin.Posef pose = ref ovrSkeleton.Bones[i].Pose;
				handSkeleton.joints[i] = new HandSkeletonJoint
				{
					pose = new Pose
					{
						position = pose.Position.FromFlippedZVector3f(),
						rotation = pose.Orientation.FromFlippedZQuatf()
					},
					parent = ovrSkeleton.Bones[i].ParentBoneIndex
				};
			}
		}

		internal static float GetBoneRadius(in OVRPlugin.Skeleton2 ovrSkeleton, int boneIndex)
		{
			if (boneIndex == 6)
			{
				boneIndex = 7;
			}
			else if (boneIndex == 11)
			{
				boneIndex = 12;
			}
			else if (boneIndex == 16)
			{
				boneIndex = 17;
			}
			else if (boneIndex == 21)
			{
				boneIndex = 22;
			}
			int num = Array.FindIndex(ovrSkeleton.BoneCapsules, (OVRPlugin.BoneCapsule c) => c.BoneIndex == boneIndex);
			if (num >= 0)
			{
				return ovrSkeleton.BoneCapsules[num].Radius;
			}
			return 0f;
		}
	}
	public interface IOVRCameraRigRef
	{
		OVRCameraRig CameraRig { get; }

		OVRHand LeftHand { get; }

		OVRHand RightHand { get; }

		Transform LeftController { get; }

		Transform RightController { get; }

		event Action<bool> WhenInputDataDirtied;
	}
	[DefaultExecutionOrder(-90)]
	[Feature(Feature.Interaction)]
	public class OVRCameraRigRef : MonoBehaviour, IOVRCameraRigRef
	{
		[Header("Configuration")]
		[SerializeField]
		private OVRCameraRig _ovrCameraRig;

		[SerializeField]
		private OVRHand _leftHand;

		[SerializeField]
		private OVRHand _rightHand;

		[SerializeField]
		private bool _requireOvrHands = true;

		protected bool _started;

		private bool _isLateUpdate;

		public OVRCameraRig CameraRig => _ovrCameraRig;

		public OVRHand LeftHand => GetHandCached(ref _leftHand, _ovrCameraRig.leftHandAnchor);

		public OVRHand RightHand => GetHandCached(ref _rightHand, _ovrCameraRig.rightHandAnchor);

		public Transform LeftController => _ovrCameraRig.leftControllerAnchor;

		public Transform RightController => _ovrCameraRig.rightControllerAnchor;

		public event Action<bool> WhenInputDataDirtied = delegate
		{
		};

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			this.EndStart(ref _started);
		}

		protected virtual void FixedUpdate()
		{
			_isLateUpdate = false;
		}

		protected virtual void Update()
		{
			_isLateUpdate = false;
		}

		protected virtual void LateUpdate()
		{
			_isLateUpdate = true;
		}

		protected virtual void OnEnable()
		{
			if (_started)
			{
				CameraRig.UpdatedAnchors += HandleInputDataDirtied;
			}
		}

		protected virtual void OnDisable()
		{
			if (_started)
			{
				CameraRig.UpdatedAnchors -= HandleInputDataDirtied;
			}
		}

		private OVRHand GetHandCached(ref OVRHand cachedValue, Transform handAnchor)
		{
			if (cachedValue != null)
			{
				return cachedValue;
			}
			cachedValue = handAnchor.GetComponentInChildren<OVRHand>(includeInactive: true);
			_ = _requireOvrHands;
			return cachedValue;
		}

		private void HandleInputDataDirtied(OVRCameraRig cameraRig)
		{
			this.WhenInputDataDirtied(_isLateUpdate);
		}

		public void InjectAllOVRCameraRigRef(OVRCameraRig ovrCameraRig, bool requireHands)
		{
			InjectInteractionOVRCameraRig(ovrCameraRig);
			InjectRequireHands(requireHands);
		}

		public void InjectInteractionOVRCameraRig(OVRCameraRig ovrCameraRig)
		{
			_ovrCameraRig = ovrCameraRig;
			_leftHand = null;
			_rightHand = null;
		}

		public void InjectRequireHands(bool requireHands)
		{
			_requireOvrHands = requireHands;
		}
	}
	[Feature(Feature.Interaction)]
	public static class OVRControllerUtility
	{
		public static float GetPinchAmount(OVRInput.Controller ovrController)
		{
			return OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, ovrController);
		}

		public static float GetIndexCurl(OVRInput.Controller ovrController)
		{
			if (SupportsAnalogIndex(ovrController))
			{
				return OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTriggerCurl, ovrController);
			}
			return (OVRInput.Get(OVRInput.NearTouch.PrimaryIndexTrigger, ovrController) || OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, ovrController) != 0f) ? 1 : 0;
		}

		public static float GetIndexSlide(OVRInput.Controller ovrController)
		{
			if (SupportsAnalogIndex(ovrController))
			{
				return OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTriggerSlide, ovrController);
			}
			return 0f;
		}

		private static bool SupportsAnalogIndex(OVRInput.Controller ovrController)
		{
			if (ovrController != OVRInput.Controller.LTouch && ovrController != OVRInput.Controller.RTouch)
			{
				return false;
			}
			return OVRInput.GetCurrentInteractionProfile((ovrController != OVRInput.Controller.LTouch) ? OVRInput.Hand.HandRight : OVRInput.Hand.HandLeft) != OVRInput.InteractionProfile.Touch;
		}
	}
	[Feature(Feature.Interaction)]
	public class OVRInputDeviceActiveState : MonoBehaviour, IActiveState
	{
		[SerializeField]
		private List<OVRInput.Controller> _controllerTypes;

		public bool Active
		{
			get
			{
				foreach (OVRInput.Controller controllerType in _controllerTypes)
				{
					if (OVRInput.GetConnectedControllers() == controllerType)
					{
						return true;
					}
				}
				return false;
			}
		}

		public void InjectAllOVRInputDeviceActiveState(List<OVRInput.Controller> controllerTypes)
		{
			InjectControllerTypes(controllerTypes);
		}

		public void InjectControllerTypes(List<OVRInput.Controller> controllerTypes)
		{
			_controllerTypes = controllerTypes;
		}
	}
	[Feature(Feature.Interaction)]
	public class OVRNearTouch : MonoBehaviour, IButton
	{
		[SerializeField]
		private OVRInput.Controller _controller;

		[SerializeField]
		private OVRInput.NearTouch _nearTouch;

		public bool Value()
		{
			return OVRInput.Get(_nearTouch, _controller);
		}
	}
	[Feature(Feature.Interaction)]
	public class OVRSkeletonData
	{
		public static readonly OVRPlugin.Skeleton2 LeftSkeleton = new OVRPlugin.Skeleton2
		{
			Type = OVRPlugin.SkeletonType.XRHandLeft,
			NumBones = 26u,
			NumBoneCapsules = 19u,
			Bones = new OVRPlugin.Bone[26]
			{
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Start,
					ParentBoneIndex = 1,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0.002120435f,
							y = -0.00547956f,
							z = -0.0653313f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 0f,
							z = 0f,
							w = 0.9999999f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_ForearmStub,
					ParentBoneIndex = -1,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0f,
							y = 0f,
							z = 0f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.7071068f,
							y = 3.090862E-08f,
							z = -0.7071068f,
							w = -3.090862E-08f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Thumb0,
					ParentBoneIndex = 1,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0.0280285f,
							y = -0.01915772f,
							z = -0.03595843f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.005259067f,
							y = -0.3771799f,
							z = -0.6271985f,
							w = 0.6814173f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Thumb1,
					ParentBoneIndex = 2,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0f,
							y = 4.190952E-09f,
							z = -0.0325129f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.08406219f,
							y = 0.07696168f,
							z = 0.08270374f,
							w = 0.9900356f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Thumb2,
					ParentBoneIndex = 3,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -2.793968E-09f,
							y = -5.587935E-09f,
							z = -0.03379309f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.05827412f,
							y = -0.06501578f,
							z = -0.08350593f,
							w = 0.9926752f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Thumb3,
					ParentBoneIndex = 4,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -0.000670366f,
							y = 0.001026981f,
							z = -0.02459078f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 1.490116E-08f,
							z = 0f,
							w = 1f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Index1,
					ParentBoneIndex = 1,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0.01872439f,
							y = -0.01104215f,
							z = -0.03717846f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 0f,
							z = 0f,
							w = 0.9999999f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Index2,
					ParentBoneIndex = 6,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0.004826289f,
							y = 0.003725696f,
							z = -0.05881777f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = -0.04328144f,
							y = 0.01885557f,
							z = -0.03068309f,
							w = 0.9984136f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Index3,
					ParentBoneIndex = 7,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 1.862645E-09f,
							y = 4.656613E-10f,
							z = -0.0379273f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = -0.003292942f,
							y = 0.007116079f,
							z = 0.02585241f,
							w = 0.9996351f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Middle1,
					ParentBoneIndex = 8,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -5.587935E-09f,
							y = 1.629815E-09f,
							z = -0.02430366f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.07203402f,
							y = 0.02714875f,
							z = 0.016056f,
							w = 0.9969035f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Middle2,
					ParentBoneIndex = 9,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -0.0002956167f,
							y = 0.00102507f,
							z = -0.02236339f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 0f,
							z = -9.313226E-10f,
							w = 1f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Middle3,
					ParentBoneIndex = 1,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0.002514964f,
							y = -0.008415965f,
							z = -0.03501599f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 0f,
							z = 0f,
							w = 0.9999999f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Ring1,
					ParentBoneIndex = 11,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -0.0007890596f,
							y = 0.005872811f,
							z = -0.06063062f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = -0.05183575f,
							y = 0.0514656f,
							z = 0.009066325f,
							w = 0.9972874f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Ring2,
					ParentBoneIndex = 12,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 1.303852E-08f,
							y = 4.656613E-10f,
							z = -0.042927f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.001978267f,
							y = 0.004378915f,
							z = 0.01122824f,
							w = 0.9999254f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Ring3,
					ParentBoneIndex = 13,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -2.793968E-09f,
							y = -4.656613E-10f,
							z = -0.02754958f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.093007f,
							y = 0.00461179f,
							z = 0.03431955f,
							w = 0.995063f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Pinky0,
					ParentBoneIndex = 14,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -0.000308645f,
							y = 0.001137298f,
							z = -0.02496493f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 0f,
							z = -4.656613E-10f,
							w = 0.9999999f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Pinky1,
					ParentBoneIndex = 1,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -0.01499234f,
							y = -0.00601578f,
							z = -0.03477554f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 0f,
							z = 0f,
							w = 0.9999999f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Pinky2,
					ParentBoneIndex = 16,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -0.002472909f,
							y = -0.0005135289f,
							z = -0.05391826f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = -0.04981351f,
							y = 0.1231034f,
							z = 0.05315936f,
							w = 0.9897162f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Pinky3,
					ParentBoneIndex = 17,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -9.313226E-10f,
							y = 1.629815E-09f,
							z = -0.03899609f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = -0.005676018f,
							y = 0.002789885f,
							z = 0.03363252f,
							w = 0.9994141f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_MaxSkinnable,
					ParentBoneIndex = 18,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -5.587935E-09f,
							y = -9.313226E-10f,
							z = -0.02657339f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.02502854f,
							y = -0.02917945f,
							z = 0.003477454f,
							w = 0.9992546f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_IndexTip,
					ParentBoneIndex = 19,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -0.0002579107f,
							y = 0.001608172f,
							z = -0.02432613f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 0f,
							z = 0f,
							w = 1f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_MiddleTip,
					ParentBoneIndex = 1,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -0.02299858f,
							y = -0.009419838f,
							z = -0.03407356f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = -0.0183118f,
							y = 0.1403429f,
							z = 0.207036f,
							w = 0.9680417f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_RingTip,
					ParentBoneIndex = 21,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 2.196059E-06f,
							y = -9.993091E-07f,
							z = -0.04565054f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = -0.02812923f,
							y = -0.004071385f,
							z = -0.09111302f,
							w = 0.9954348f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_PinkyTip,
					ParentBoneIndex = 22,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0f,
							y = 4.656613E-10f,
							z = -0.0307204f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.01328605f,
							y = 0.04293776f,
							z = 0.03761665f,
							w = 0.9982808f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_End,
					ParentBoneIndex = 23,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 1.490116E-08f,
							y = -1.862645E-09f,
							z = -0.02031136f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.02401882f,
							y = -0.04917067f,
							z = -0.0006447211f,
							w = 0.9985011f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.XRHand_LittleTip,
					ParentBoneIndex = 24,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0.0002464727f,
							y = 0.001216088f,
							z = -0.02192238f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 0f,
							z = 0f,
							w = 0.9999997f
						}
					}
				}
			},
			BoneCapsules = new OVRPlugin.BoneCapsule[19]
			{
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 1,
					Radius = 0.01822828f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0.01685145f,
						y = -0.01404148f,
						z = -0.02755879f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 0.02178326f,
						y = -0.009090677f,
						z = -0.07794081f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 1,
					Radius = 0.02323196f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0.006531342f,
						y = -0.008661011f,
						z = -0.02632602f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 0.003326345f,
						y = -0.004580691f,
						z = -0.07255958f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 1,
					Radius = 0.01608828f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = -0.01111641f,
						y = -0.009206061f,
						z = -0.0297035f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -0.01574543f,
						y = -0.007254404f,
						z = -0.07271415f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 1,
					Radius = 0.02346085f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = -0.01446979f,
						y = -0.008827155f,
						z = -0.02844799f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -0.02133043f,
						y = -0.009573799f,
						z = -0.06036391f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 2,
					Radius = 0.01838252f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = -3.72529E-09f,
						y = -3.259629E-09f,
						z = 3.72529E-09f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 4.656613E-09f,
						y = 3.259629E-09f,
						z = -0.03251291f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 3,
					Radius = 0.01028295f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 1.862645E-09f,
						y = -5.587935E-09f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 8.381903E-09f,
						y = -9.313226E-10f,
						z = -0.03379309f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 4,
					Radius = 0.009768805f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 5.587935E-09f,
						y = -3.72529E-09f,
						z = -7.450581E-09f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -0.0005929563f,
						y = 0.0006525218f,
						z = -0.01500077f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 7,
					Radius = 0.01029526f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 3.72529E-09f,
						y = -2.328306E-10f,
						z = 7.450581E-09f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 5.587935E-09f,
						y = -1.629815E-09f,
						z = -0.03792728f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 8,
					Radius = 0.008038102f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = 6.984919E-10f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -5.587935E-09f,
						y = 1.164153E-09f,
						z = -0.02430364f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 9,
					Radius = 0.007636196f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = -3.72529E-09f,
						y = 0f,
						z = 1.490116E-08f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -6.049871E-05f,
						y = 0.0005028695f,
						z = -0.01507758f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 12,
					Radius = 0.01117394f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = -3.72529E-09f,
						y = 1.396984E-09f,
						z = -7.450581E-09f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 1.303852E-08f,
						y = 3.259629E-09f,
						z = -0.042927f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 13,
					Radius = 0.008030958f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 7.450581E-09f,
						y = -4.656613E-10f,
						z = -2.980232E-08f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 4.656613E-09f,
						y = -1.396984E-09f,
						z = -0.02754961f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 14,
					Radius = 0.007629411f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = 3.72529E-09f,
						z = -2.980232E-08f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -0.0004036417f,
						y = 0.0007450115f,
						z = -0.01719157f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 17,
					Radius = 0.009922137f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = -6.984919E-10f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 1.024455E-08f,
						y = 1.629815E-09f,
						z = -0.03899611f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 18,
					Radius = 0.007611672f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = -3.72529E-09f,
						y = 0f,
						z = -1.490116E-08f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -5.587935E-09f,
						y = -9.313226E-10f,
						z = -0.02657339f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 19,
					Radius = 0.007231089f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = 9.313226E-10f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -0.0001235802f,
						y = 0.001288095f,
						z = -0.01632452f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 22,
					Radius = 0.008483353f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = 0f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = 2.328306E-09f,
						z = -0.0307204f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 23,
					Radius = 0.006764194f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = 1.862645E-09f,
						z = 1.490116E-08f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 3.72529E-09f,
						y = 0f,
						z = -0.02031135f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 24,
					Radius = 0.006425985f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = 0f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 2.491102E-05f,
						y = 0.000605626f,
						z = -0.01507002f
					}
				}
			}
		};

		public static readonly OVRPlugin.Skeleton2 RightSkeleton = new OVRPlugin.Skeleton2
		{
			Type = OVRPlugin.SkeletonType.XRHandRight,
			NumBones = 26u,
			NumBoneCapsules = 19u,
			Bones = new OVRPlugin.Bone[26]
			{
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Start,
					ParentBoneIndex = 1,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -0.002120435f,
							y = -0.00547956f,
							z = -0.0653313f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 0f,
							z = 0f,
							w = 0.9999999f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_ForearmStub,
					ParentBoneIndex = -1,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0f,
							y = 0f,
							z = 0f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 0.7071068f,
							z = 0f,
							w = 0.7071068f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Thumb0,
					ParentBoneIndex = 1,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -0.0280285f,
							y = -0.01915772f,
							z = -0.03595843f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.005259037f,
							y = 0.3771799f,
							z = 0.6271985f,
							w = 0.6814173f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Thumb1,
					ParentBoneIndex = 2,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0f,
							y = -9.313226E-10f,
							z = -0.03251291f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.08406219f,
							y = -0.07696167f,
							z = -0.0827037f,
							w = 0.9900356f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Thumb2,
					ParentBoneIndex = 3,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -1.862645E-09f,
							y = -6.519258E-09f,
							z = -0.03379311f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.05827411f,
							y = 0.06501578f,
							z = 0.08350589f,
							w = 0.9926752f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Thumb3,
					ParentBoneIndex = 4,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0.0006703734f,
							y = 0.001026981f,
							z = -0.02459077f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = -1.490116E-08f,
							z = -3.72529E-09f,
							w = 1f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Index1,
					ParentBoneIndex = 1,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -0.01872439f,
							y = -0.01104215f,
							z = -0.03717846f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 0f,
							z = 0f,
							w = 0.9999999f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Index2,
					ParentBoneIndex = 6,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -0.004826291f,
							y = 0.003725695f,
							z = -0.05881777f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = -0.04328144f,
							y = -0.01885557f,
							z = 0.03068309f,
							w = 0.9984136f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Index3,
					ParentBoneIndex = 7,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0f,
							y = -2.328306E-10f,
							z = -0.0379273f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = -0.003292941f,
							y = -0.007116065f,
							z = -0.02585241f,
							w = 0.999635f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Middle1,
					ParentBoneIndex = 8,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 1.117587E-08f,
							y = 2.095476E-09f,
							z = -0.02430366f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.07203402f,
							y = -0.02714874f,
							z = -0.016056f,
							w = 0.9969035f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Middle2,
					ParentBoneIndex = 9,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0.0002956092f,
							y = 0.00102507f,
							z = -0.02236339f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = -1.688022E-09f,
							z = 0f,
							w = 1f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Middle3,
					ParentBoneIndex = 1,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -0.002514964f,
							y = -0.008415964f,
							z = -0.03501599f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 0f,
							z = 0f,
							w = 0.9999999f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Ring1,
					ParentBoneIndex = 11,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0.0007890593f,
							y = 0.00587281f,
							z = -0.06063062f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = -0.05183575f,
							y = -0.0514656f,
							z = -0.009066325f,
							w = 0.9972874f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Ring2,
					ParentBoneIndex = 12,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -7.450581E-09f,
							y = 9.313226E-10f,
							z = -0.042927f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.001978267f,
							y = -0.004378904f,
							z = -0.01122824f,
							w = 0.9999253f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Ring3,
					ParentBoneIndex = 13,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 7.450581E-09f,
							y = 0f,
							z = -0.02754958f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.09300701f,
							y = -0.004611799f,
							z = -0.03431955f,
							w = 0.995063f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Pinky0,
					ParentBoneIndex = 14,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0.0003086478f,
							y = 0.001137299f,
							z = -0.02496493f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 5.209586E-09f,
							z = 0f,
							w = 0.9999999f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Pinky1,
					ParentBoneIndex = 1,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0.01499234f,
							y = -0.006015779f,
							z = -0.03477554f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 0f,
							z = 0f,
							w = 0.9999999f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Pinky2,
					ParentBoneIndex = 16,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0.002472909f,
							y = -0.0005135285f,
							z = -0.05391826f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = -0.04981349f,
							y = -0.1231034f,
							z = -0.05315936f,
							w = 0.9897162f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_Pinky3,
					ParentBoneIndex = 17,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0f,
							y = 9.313226E-10f,
							z = -0.0389961f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = -0.005676013f,
							y = -0.002789889f,
							z = -0.03363252f,
							w = 0.9994141f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_MaxSkinnable,
					ParentBoneIndex = 18,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -7.450581E-09f,
							y = -1.862645E-09f,
							z = -0.02657339f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.02502853f,
							y = 0.02917946f,
							z = -0.003477456f,
							w = 0.9992546f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_IndexTip,
					ParentBoneIndex = 19,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0.0002579093f,
							y = 0.001608171f,
							z = -0.02432612f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = -1.117587E-08f,
							z = 0f,
							w = 1f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_MiddleTip,
					ParentBoneIndex = 1,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 0.02299858f,
							y = -0.009419835f,
							z = -0.03407356f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = -0.01831179f,
							y = -0.1403429f,
							z = -0.207036f,
							w = 0.9680417f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_RingTip,
					ParentBoneIndex = 21,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -2.194196E-06f,
							y = -1.00024E-06f,
							z = -0.04565054f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = -0.02812924f,
							y = 0.004071368f,
							z = 0.09111303f,
							w = 0.9954348f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_PinkyTip,
					ParentBoneIndex = 22,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = 1.862645E-09f,
							y = 0f,
							z = -0.03072041f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.01328605f,
							y = -0.04293777f,
							z = -0.03761665f,
							w = 0.9982808f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.Hand_End,
					ParentBoneIndex = 23,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -3.72529E-09f,
							y = -2.793968E-09f,
							z = -0.02031137f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0.02401883f,
							y = 0.04917067f,
							z = 0.0006447285f,
							w = 0.9985011f
						}
					}
				},
				new OVRPlugin.Bone
				{
					Id = OVRPlugin.BoneId.XRHand_LittleTip,
					ParentBoneIndex = 24,
					Pose = new OVRPlugin.Posef
					{
						Position = new OVRPlugin.Vector3f
						{
							x = -0.0002464727f,
							y = 0.001216089f,
							z = -0.02192238f
						},
						Orientation = new OVRPlugin.Quatf
						{
							x = 0f,
							y = 2.793968E-09f,
							z = 0f,
							w = 0.9999997f
						}
					}
				}
			},
			BoneCapsules = new OVRPlugin.BoneCapsule[19]
			{
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 1,
					Radius = 0.01822828f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = -0.01685145f,
						y = -0.01404148f,
						z = -0.02755879f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -0.02178326f,
						y = -0.009090677f,
						z = -0.07794081f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 1,
					Radius = 0.02323196f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = -0.006531343f,
						y = -0.008661012f,
						z = -0.02632602f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -0.003326345f,
						y = -0.004580691f,
						z = -0.07255958f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 1,
					Radius = 0.01608828f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0.01111641f,
						y = -0.00920606f,
						z = -0.0297035f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 0.01574543f,
						y = -0.007254402f,
						z = -0.07271415f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 1,
					Radius = 0.02346085f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0.01446979f,
						y = -0.008827152f,
						z = -0.02844799f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 0.02133043f,
						y = -0.009573797f,
						z = -0.06036392f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 2,
					Radius = 0.01838251f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 5.587935E-09f,
						y = 9.313226E-10f,
						z = 3.72529E-09f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -2.793968E-09f,
						y = -9.313226E-10f,
						z = -0.03251291f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 3,
					Radius = 0.01028296f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = -7.450581E-09f,
						y = 0f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -1.490116E-08f,
						y = -2.793968E-09f,
						z = -0.03379309f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 4,
					Radius = 0.009768807f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = -1.862645E-09f,
						y = 3.72529E-09f,
						z = -7.450581E-09f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 0.0005929582f,
						y = 0.0006525703f,
						z = -0.0150008f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 7,
					Radius = 0.01029526f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = -3.72529E-09f,
						y = 2.328306E-10f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -3.72529E-09f,
						y = -1.396984E-09f,
						z = -0.03792728f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 8,
					Radius = 0.008038101f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = 9.313226E-10f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -3.72529E-09f,
						y = 2.328306E-09f,
						z = -0.02430366f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 9,
					Radius = 0.007636196f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = 0f,
						z = 2.980232E-08f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 6.053597E-05f,
						y = 0.0005028695f,
						z = -0.01507759f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 12,
					Radius = 0.01117394f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 3.72529E-09f,
						y = 0f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -7.450581E-09f,
						y = 1.396984E-09f,
						z = -0.042927f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 13,
					Radius = 0.008030958f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = -7.450581E-09f,
						y = 0f,
						z = -2.980232E-08f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = 0f,
						z = -0.02754962f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 14,
					Radius = 0.00762941f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = 3.72529E-09f,
						z = -1.490116E-08f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 0.0004036501f,
						y = 0.0007450059f,
						z = -0.01719154f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 17,
					Radius = 0.009922139f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = -2.328306E-10f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -1.117587E-08f,
						y = 9.313226E-10f,
						z = -0.03899612f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 18,
					Radius = 0.007611674f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 3.72529E-09f,
						y = 1.862645E-09f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -7.450581E-09f,
						y = 4.656613E-10f,
						z = -0.02657339f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 19,
					Radius = 0.00723109f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = 1.862645E-09f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = 0.0001235828f,
						y = 0.001288087f,
						z = -0.01632456f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 22,
					Radius = 0.008483353f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = 0f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -1.862645E-09f,
						y = 2.793968E-09f,
						z = -0.03072041f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 23,
					Radius = 0.006764191f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = -1.117587E-08f,
						y = 0f,
						z = 1.490116E-08f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -3.72529E-09f,
						y = -9.313226E-10f,
						z = -0.02031137f
					}
				},
				new OVRPlugin.BoneCapsule
				{
					BoneIndex = 24,
					Radius = 0.006425982f,
					StartPoint = new OVRPlugin.Vector3f
					{
						x = 0f,
						y = 0f,
						z = 0f
					},
					EndPoint = new OVRPlugin.Vector3f
					{
						x = -2.489984E-05f,
						y = 0.0006056232f,
						z = -0.01507002f
					}
				}
			}
		};
	}
	[Feature(Feature.Interaction)]
	public class OVRTouch : MonoBehaviour, IButton
	{
		[SerializeField]
		private OVRInput.Controller _controller;

		[SerializeField]
		private OVRInput.Touch _touch;

		public bool Value()
		{
			return OVRInput.Get(_touch, _controller);
		}
	}
	[Feature(Feature.Interaction)]
	public class SetDisplayRefresh : MonoBehaviour
	{
		[SerializeField]
		private float _desiredDisplayFrequency = 90f;

		public void SetDesiredDisplayFrequency(float desiredDisplayFrequency)
		{
			if (Enumerable.Contains(OVRPlugin.systemDisplayFrequenciesAvailable, _desiredDisplayFrequency))
			{
				UnityEngine.Debug.Log("[Oculus.Interaction] Setting desired display frequency to " + _desiredDisplayFrequency);
				OVRPlugin.systemDisplayFrequency = _desiredDisplayFrequency;
			}
		}

		protected virtual void Awake()
		{
			SetDesiredDisplayFrequency(_desiredDisplayFrequency);
		}
	}
	[Feature(Feature.Interaction)]
	public class TrackingToWorldTransformerOVR : MonoBehaviour, ITrackingToWorldTransformer
	{
		[SerializeField]
		[Interface(typeof(IOVRCameraRigRef), new Type[] { })]
		private UnityEngine.Object _cameraRigRef;

		public IOVRCameraRigRef CameraRigRef { get; private set; }

		public Transform Transform => CameraRigRef.CameraRig.trackingSpace;

		public Quaternion WorldToTrackingWristJointFixup => FromOVRHandDataSource.WristFixupRotation;

		public Pose ToWorldPose(Pose pose)
		{
			Transform transform = Transform;
			pose.position = transform.TransformPoint(pose.position);
			pose.rotation = transform.rotation * pose.rotation;
			return pose;
		}

		public Pose ToTrackingPose(in Pose worldPose)
		{
			Transform obj = Transform;
			Vector3 position = obj.InverseTransformPoint(worldPose.position);
			Quaternion rotation = Quaternion.Inverse(obj.rotation) * worldPose.rotation;
			return new Pose(position, rotation);
		}

		protected virtual void Awake()
		{
			CameraRigRef = _cameraRigRef as IOVRCameraRigRef;
		}

		protected virtual void Start()
		{
		}

		public void InjectAllTrackingToWorldTransformerOVR(IOVRCameraRigRef cameraRigRef)
		{
			InjectCameraRigRef(cameraRigRef);
		}

		public void InjectCameraRigRef(IOVRCameraRigRef cameraRigRef)
		{
			_cameraRigRef = cameraRigRef as UnityEngine.Object;
			CameraRigRef = cameraRigRef;
		}

		Pose ITrackingToWorldTransformer.ToTrackingPose(in Pose worldPose)
		{
			return ToTrackingPose(in worldPose);
		}
	}
}
namespace Oculus.Interaction.Input.Visuals
{
	[Obsolete("Use ControllerVisual instead.")]
	[Feature(Feature.Interaction)]
	public class OVRControllerVisual : MonoBehaviour
	{
		[SerializeField]
		[Interface(typeof(IController), new Type[] { })]
		private UnityEngine.Object _controller;

		public IController Controller;

		[SerializeField]
		private OVRControllerHelper _ovrControllerHelper;

		protected bool _started;

		public bool ForceOffVisibility { get; set; }

		protected virtual void Awake()
		{
			Controller = _controller as IController;
		}

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			switch (Controller.Handedness)
			{
			case Handedness.Left:
				_ovrControllerHelper.m_controller = OVRInput.Controller.LTouch;
				break;
			case Handedness.Right:
				_ovrControllerHelper.m_controller = OVRInput.Controller.RTouch;
				break;
			}
			this.EndStart(ref _started);
		}

		protected virtual void OnEnable()
		{
			if (_started)
			{
				Controller.WhenUpdated += HandleUpdated;
			}
		}

		protected virtual void OnDisable()
		{
			if (_started && _controller != null)
			{
				Controller.WhenUpdated -= HandleUpdated;
			}
		}

		private void HandleUpdated()
		{
			if (!Controller.IsConnected || ForceOffVisibility || !Controller.TryGetPose(out var pose))
			{
				_ovrControllerHelper.gameObject.SetActive(value: false);
				return;
			}
			_ovrControllerHelper.gameObject.SetActive(value: true);
			base.transform.position = pose.position;
			base.transform.rotation = pose.rotation;
			float num = ((base.transform.parent != null) ? base.transform.parent.lossyScale.x : 1f);
			base.transform.localScale = Controller.Scale / num * Vector3.one;
		}

		public void InjectAllOVRControllerVisual(IController controller, OVRControllerHelper ovrControllerHelper)
		{
			InjectController(controller);
			InjectAllOVRControllerHelper(ovrControllerHelper);
		}

		public void InjectController(IController controller)
		{
			_controller = controller as UnityEngine.Object;
			Controller = controller;
		}

		public void InjectAllOVRControllerHelper(OVRControllerHelper ovrControllerHelper)
		{
			_ovrControllerHelper = ovrControllerHelper;
		}
	}
}
namespace Oculus.Interaction.Body.PoseDetection
{
	[Feature(Feature.Interaction)]
	public class OVRBodyPoseSkeletonProvider : MonoBehaviour, OVRSkeleton.IOVRSkeletonDataProvider
	{
		private const int OVR_NUM_JOINTS = 84;

		[SerializeField]
		[Interface(typeof(IBodyPose), new Type[] { })]
		private UnityEngine.Object _bodyPose;

		private IBodyPose BodyPose;

		[SerializeField]
		private OVRPlugin.BodyJointSet _bodyJointSet;

		private OVRPlugin.Quatf[] _boneRotations = new OVRPlugin.Quatf[84];

		private OVRPlugin.Vector3f[] _boneTranslations = new OVRPlugin.Vector3f[84];

		private OVRSkeletonMapping _mapping;

		protected virtual void Awake()
		{
			BodyPose = _bodyPose as IBodyPose;
		}

		protected virtual void Start()
		{
			_mapping = new OVRSkeletonMapping(_bodyJointSet);
		}

		OVRSkeleton.SkeletonPoseData OVRSkeleton.IOVRSkeletonDataProvider.GetSkeletonPoseData()
		{
			_boneRotations = EnsureLength<OVRPlugin.Quatf>(_boneRotations, 84);
			_boneTranslations = EnsureLength<OVRPlugin.Vector3f>(_boneTranslations, 84);
			for (int i = 0; i < 84; i++)
			{
				OVRPlugin.BoneId jointId = (OVRPlugin.BoneId)i;
				if (_mapping.TryGetBodyJointId(jointId, out var bodyJointId) && BodyPose.GetJointPoseFromRoot(bodyJointId, out var pose))
				{
					_boneRotations[i] = pose.rotation.ToFlippedZQuatf();
					_boneTranslations[i] = pose.position.ToFlippedZVector3f();
				}
			}
			Pose pose2;
			OVRPlugin.Posef rootPose = ((!BodyPose.GetJointPoseFromRoot(BodyJointId.Body_Start, out pose2)) ? default(OVRPlugin.Posef) : new OVRPlugin.Posef
			{
				Orientation = pose2.rotation.ToFlippedXQuatf(),
				Position = pose2.position.ToFlippedZVector3f()
			});
			return new OVRSkeleton.SkeletonPoseData
			{
				IsDataValid = true,
				IsDataHighConfidence = true,
				RootPose = rootPose,
				RootScale = 1f,
				BoneRotations = _boneRotations,
				BoneTranslations = _boneTranslations
			};
			static T[] EnsureLength<T>(T[] array, int length)
			{
				if (array == null || array.Length != length)
				{
					return new T[length];
				}
				return array;
			}
		}

		public OVRSkeleton.SkeletonType GetSkeletonType()
		{
			return _bodyJointSet switch
			{
				OVRPlugin.BodyJointSet.UpperBody => OVRSkeleton.SkeletonType.Body, 
				OVRPlugin.BodyJointSet.FullBody => OVRSkeleton.SkeletonType.FullBody, 
				_ => OVRSkeleton.SkeletonType.None, 
			};
		}
	}
}
namespace Oculus.Interaction.Body.Input
{
	[Feature(Feature.Interaction)]
	public class FromOVRBodyDataSource : DataSource<BodyDataAsset>
	{
		[Header("OVR Data Source")]
		[SerializeField]
		[Interface(typeof(OVRSkeleton.IOVRSkeletonDataProvider), new Type[] { })]
		private UnityEngine.Object _dataProvider;

		private OVRSkeleton.IOVRSkeletonDataProvider DataProvider;

		[SerializeField]
		[Interface(typeof(IOVRCameraRigRef), new Type[] { })]
		private UnityEngine.Object _cameraRigRef;

		private IOVRCameraRigRef CameraRigRef;

		[SerializeField]
		private bool _processLateUpdates;

		private readonly BodyDataAsset _bodyDataAsset = new BodyDataAsset();

		private OVRSkeletonMapping _mapping;

		protected override BodyDataAsset DataAsset => _bodyDataAsset;

		private static OVRPlugin.BodyJointSet GetJointSet(OVRSkeleton.IOVRSkeletonDataProvider provider)
		{
			return provider.GetSkeletonType() switch
			{
				OVRSkeleton.SkeletonType.Body => OVRPlugin.BodyJointSet.UpperBody, 
				OVRSkeleton.SkeletonType.FullBody => OVRPlugin.BodyJointSet.FullBody, 
				_ => OVRPlugin.BodyJointSet.None, 
			};
		}

		protected void Awake()
		{
			CameraRigRef = _cameraRigRef as IOVRCameraRigRef;
			DataProvider = _dataProvider as OVRSkeleton.IOVRSkeletonDataProvider;
		}

		protected override void Start()
		{
			base.Start();
			_mapping = new OVRSkeletonMapping(GetJointSet(DataProvider));
			_bodyDataAsset.SkeletonMapping = _mapping;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (_started)
			{
				CameraRigRef.WhenInputDataDirtied += HandleInputDataDirtied;
			}
		}

		protected override void OnDisable()
		{
			if (_started)
			{
				CameraRigRef.WhenInputDataDirtied -= HandleInputDataDirtied;
			}
			base.OnDisable();
		}

		private void HandleInputDataDirtied(bool isLateUpdate)
		{
			if (!isLateUpdate || _processLateUpdates)
			{
				MarkInputDataRequiresUpdate();
			}
		}

		protected override void UpdateData()
		{
			OVRSkeleton.SkeletonPoseData skeletonPoseData = DataProvider.GetSkeletonPoseData();
			if (!skeletonPoseData.IsDataValid)
			{
				return;
			}
			_bodyDataAsset.SkeletonMapping = _mapping;
			_bodyDataAsset.IsDataHighConfidence = skeletonPoseData.IsDataHighConfidence;
			_bodyDataAsset.IsDataValid = skeletonPoseData.IsDataValid;
			_bodyDataAsset.SkeletonChangedCount = skeletonPoseData.SkeletonChangedCount;
			_bodyDataAsset.RootScale = skeletonPoseData.RootScale;
			_bodyDataAsset.Root = new Pose
			{
				position = skeletonPoseData.RootPose.Position.FromFlippedZVector3f(),
				rotation = skeletonPoseData.RootPose.Orientation.FromFlippedZQuatf()
			};
			foreach (BodyJointId joint in _mapping.Joints)
			{
				Pose to = default(Pose);
				if (_mapping.TryGetSourceJointId(joint, out var sourceJointId))
				{
					int num = (int)sourceJointId;
					to = new Pose
					{
						rotation = (float.IsNaN(skeletonPoseData.BoneRotations[num].w) ? default(Quaternion) : skeletonPoseData.BoneRotations[num].FromFlippedZQuatf()),
						position = skeletonPoseData.BoneTranslations[num].FromFlippedZVector3f()
					};
				}
				_bodyDataAsset.JointPoses[(int)joint] = PoseUtils.Delta(_bodyDataAsset.Root, in to);
			}
		}
	}
	[Feature(Feature.Interaction)]
	public class OVRSkeletonMapping : BodySkeletonMapping<OVRPlugin.BoneId>, ISkeletonMapping
	{
		private static readonly Dictionary<BodyJointId, JointInfo> _upperBodyJoints = new Dictionary<BodyJointId, JointInfo>
		{
			[BodyJointId.Body_Start] = new JointInfo(OVRPlugin.BoneId.Hand_Start, OVRPlugin.BoneId.Hand_Start),
			[BodyJointId.Body_Hips] = new JointInfo(OVRPlugin.BoneId.Hand_ForearmStub, OVRPlugin.BoneId.Hand_Start),
			[BodyJointId.Body_SpineLower] = new JointInfo(OVRPlugin.BoneId.Hand_Thumb0, OVRPlugin.BoneId.Hand_ForearmStub),
			[BodyJointId.Body_SpineMiddle] = new JointInfo(OVRPlugin.BoneId.Hand_Thumb1, OVRPlugin.BoneId.Hand_Thumb0),
			[BodyJointId.Body_SpineUpper] = new JointInfo(OVRPlugin.BoneId.Hand_Thumb2, OVRPlugin.BoneId.Hand_Thumb1),
			[BodyJointId.Body_Chest] = new JointInfo(OVRPlugin.BoneId.Hand_Thumb3, OVRPlugin.BoneId.Hand_Thumb2),
			[BodyJointId.Body_Neck] = new JointInfo(OVRPlugin.BoneId.Hand_Index1, OVRPlugin.BoneId.Hand_Thumb3),
			[BodyJointId.Body_Head] = new JointInfo(OVRPlugin.BoneId.Hand_Index2, OVRPlugin.BoneId.Hand_Index1),
			[BodyJointId.Body_LeftShoulder] = new JointInfo(OVRPlugin.BoneId.Hand_Index3, OVRPlugin.BoneId.Hand_Thumb3),
			[BodyJointId.Body_LeftScapula] = new JointInfo(OVRPlugin.BoneId.Hand_Middle1, OVRPlugin.BoneId.Hand_Index3),
			[BodyJointId.Body_LeftArmUpper] = new JointInfo(OVRPlugin.BoneId.Hand_Middle2, OVRPlugin.BoneId.Hand_Middle1),
			[BodyJointId.Body_LeftArmLower] = new JointInfo(OVRPlugin.BoneId.Hand_Middle3, OVRPlugin.BoneId.Hand_Middle2),
			[BodyJointId.Body_LeftHandWristTwist] = new JointInfo(OVRPlugin.BoneId.Hand_Ring1, OVRPlugin.BoneId.Hand_Middle3),
			[BodyJointId.Body_RightShoulder] = new JointInfo(OVRPlugin.BoneId.Hand_Ring2, OVRPlugin.BoneId.Hand_Thumb3),
			[BodyJointId.Body_RightScapula] = new JointInfo(OVRPlugin.BoneId.Hand_Ring3, OVRPlugin.BoneId.Hand_Ring2),
			[BodyJointId.Body_RightArmUpper] = new JointInfo(OVRPlugin.BoneId.Hand_Pinky0, OVRPlugin.BoneId.Hand_Ring3),
			[BodyJointId.Body_RightArmLower] = new JointInfo(OVRPlugin.BoneId.Hand_Pinky1, OVRPlugin.BoneId.Hand_Pinky0),
			[BodyJointId.Body_RightHandWristTwist] = new JointInfo(OVRPlugin.BoneId.Hand_Pinky2, OVRPlugin.BoneId.Hand_Pinky1),
			[BodyJointId.Body_LeftHandPalm] = new JointInfo(OVRPlugin.BoneId.Hand_Pinky3, OVRPlugin.BoneId.Hand_MaxSkinnable),
			[BodyJointId.Body_LeftHandWrist] = new JointInfo(OVRPlugin.BoneId.Hand_MaxSkinnable, OVRPlugin.BoneId.Hand_Middle3),
			[BodyJointId.Body_LeftHandThumbMetacarpal] = new JointInfo(OVRPlugin.BoneId.Hand_IndexTip, OVRPlugin.BoneId.Hand_MaxSkinnable),
			[BodyJointId.Body_LeftHandThumbProximal] = new JointInfo(OVRPlugin.BoneId.Hand_MiddleTip, OVRPlugin.BoneId.Hand_IndexTip),
			[BodyJointId.Body_LeftHandThumbDistal] = new JointInfo(OVRPlugin.BoneId.Hand_RingTip, OVRPlugin.BoneId.Hand_MiddleTip),
			[BodyJointId.Body_LeftHandThumbTip] = new JointInfo(OVRPlugin.BoneId.Hand_PinkyTip, OVRPlugin.BoneId.Hand_RingTip),
			[BodyJointId.Body_LeftHandIndexMetacarpal] = new JointInfo(OVRPlugin.BoneId.Hand_End, OVRPlugin.BoneId.Hand_MaxSkinnable),
			[BodyJointId.Body_LeftHandIndexProximal] = new JointInfo(OVRPlugin.BoneId.XRHand_LittleTip, OVRPlugin.BoneId.Hand_End),
			[BodyJointId.Body_LeftHandIndexIntermediate] = new JointInfo(OVRPlugin.BoneId.XRHand_Max, OVRPlugin.BoneId.XRHand_LittleTip),
			[BodyJointId.Body_LeftHandIndexDistal] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandIndexDistal, OVRPlugin.BoneId.XRHand_Max),
			[BodyJointId.Body_LeftHandIndexTip] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandIndexTip, OVRPlugin.BoneId.Body_LeftHandIndexDistal),
			[BodyJointId.Body_LeftHandMiddleMetacarpal] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandMiddleMetacarpal, OVRPlugin.BoneId.Hand_MaxSkinnable),
			[BodyJointId.Body_LeftHandMiddleProximal] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandMiddleProximal, OVRPlugin.BoneId.Body_LeftHandMiddleMetacarpal),
			[BodyJointId.Body_LeftHandMiddleIntermediate] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandMiddleIntermediate, OVRPlugin.BoneId.Body_LeftHandMiddleProximal),
			[BodyJointId.Body_LeftHandMiddleDistal] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandMiddleDistal, OVRPlugin.BoneId.Body_LeftHandMiddleIntermediate),
			[BodyJointId.Body_LeftHandMiddleTip] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandMiddleTip, OVRPlugin.BoneId.Body_LeftHandMiddleDistal),
			[BodyJointId.Body_LeftHandRingMetacarpal] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandRingMetacarpal, OVRPlugin.BoneId.Hand_MaxSkinnable),
			[BodyJointId.Body_LeftHandRingProximal] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandRingProximal, OVRPlugin.BoneId.Body_LeftHandRingMetacarpal),
			[BodyJointId.Body_LeftHandRingIntermediate] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandRingIntermediate, OVRPlugin.BoneId.Body_LeftHandRingProximal),
			[BodyJointId.Body_LeftHandRingDistal] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandRingDistal, OVRPlugin.BoneId.Body_LeftHandRingIntermediate),
			[BodyJointId.Body_LeftHandRingTip] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandRingTip, OVRPlugin.BoneId.Body_LeftHandRingDistal),
			[BodyJointId.Body_LeftHandLittleMetacarpal] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandLittleMetacarpal, OVRPlugin.BoneId.Hand_MaxSkinnable),
			[BodyJointId.Body_LeftHandLittleProximal] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandLittleProximal, OVRPlugin.BoneId.Body_LeftHandLittleMetacarpal),
			[BodyJointId.Body_LeftHandLittleIntermediate] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandLittleIntermediate, OVRPlugin.BoneId.Body_LeftHandLittleProximal),
			[BodyJointId.Body_LeftHandLittleDistal] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandLittleDistal, OVRPlugin.BoneId.Body_LeftHandLittleIntermediate),
			[BodyJointId.Body_LeftHandLittleTip] = new JointInfo(OVRPlugin.BoneId.Body_LeftHandLittleTip, OVRPlugin.BoneId.Body_LeftHandLittleDistal),
			[BodyJointId.Body_RightHandPalm] = new JointInfo(OVRPlugin.BoneId.Body_RightHandPalm, OVRPlugin.BoneId.Body_RightHandWrist),
			[BodyJointId.Body_RightHandWrist] = new JointInfo(OVRPlugin.BoneId.Body_RightHandWrist, OVRPlugin.BoneId.Hand_Pinky1),
			[BodyJointId.Body_RightHandThumbMetacarpal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandThumbMetacarpal, OVRPlugin.BoneId.Body_RightHandWrist),
			[BodyJointId.Body_RightHandThumbProximal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandThumbProximal, OVRPlugin.BoneId.Body_RightHandThumbMetacarpal),
			[BodyJointId.Body_RightHandThumbDistal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandThumbDistal, OVRPlugin.BoneId.Body_RightHandThumbProximal),
			[BodyJointId.Body_RightHandThumbTip] = new JointInfo(OVRPlugin.BoneId.Body_RightHandThumbTip, OVRPlugin.BoneId.Body_RightHandThumbDistal),
			[BodyJointId.Body_RightHandIndexMetacarpal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandIndexMetacarpal, OVRPlugin.BoneId.Body_RightHandWrist),
			[BodyJointId.Body_RightHandIndexProximal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandIndexProximal, OVRPlugin.BoneId.Body_RightHandIndexMetacarpal),
			[BodyJointId.Body_RightHandIndexIntermediate] = new JointInfo(OVRPlugin.BoneId.Body_RightHandIndexIntermediate, OVRPlugin.BoneId.Body_RightHandIndexProximal),
			[BodyJointId.Body_RightHandIndexDistal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandIndexDistal, OVRPlugin.BoneId.Body_RightHandIndexIntermediate),
			[BodyJointId.Body_RightHandIndexTip] = new JointInfo(OVRPlugin.BoneId.Body_RightHandIndexTip, OVRPlugin.BoneId.Body_RightHandIndexDistal),
			[BodyJointId.Body_RightHandMiddleMetacarpal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandMiddleMetacarpal, OVRPlugin.BoneId.Body_RightHandWrist),
			[BodyJointId.Body_RightHandMiddleProximal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandMiddleProximal, OVRPlugin.BoneId.Body_RightHandMiddleMetacarpal),
			[BodyJointId.Body_RightHandMiddleIntermediate] = new JointInfo(OVRPlugin.BoneId.Body_RightHandMiddleIntermediate, OVRPlugin.BoneId.Body_RightHandMiddleProximal),
			[BodyJointId.Body_RightHandMiddleDistal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandMiddleDistal, OVRPlugin.BoneId.Body_RightHandMiddleIntermediate),
			[BodyJointId.Body_RightHandMiddleTip] = new JointInfo(OVRPlugin.BoneId.Body_RightHandMiddleTip, OVRPlugin.BoneId.Body_RightHandMiddleDistal),
			[BodyJointId.Body_RightHandRingMetacarpal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandRingMetacarpal, OVRPlugin.BoneId.Body_RightHandWrist),
			[BodyJointId.Body_RightHandRingProximal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandRingProximal, OVRPlugin.BoneId.Body_RightHandRingMetacarpal),
			[BodyJointId.Body_RightHandRingIntermediate] = new JointInfo(OVRPlugin.BoneId.Body_RightHandRingIntermediate, OVRPlugin.BoneId.Body_RightHandRingProximal),
			[BodyJointId.Body_RightHandRingDistal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandRingDistal, OVRPlugin.BoneId.Body_RightHandRingIntermediate),
			[BodyJointId.Body_RightHandRingTip] = new JointInfo(OVRPlugin.BoneId.Body_RightHandRingTip, OVRPlugin.BoneId.Body_RightHandRingDistal),
			[BodyJointId.Body_RightHandLittleMetacarpal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandLittleMetacarpal, OVRPlugin.BoneId.Body_RightHandWrist),
			[BodyJointId.Body_RightHandLittleProximal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandLittleProximal, OVRPlugin.BoneId.Body_RightHandLittleMetacarpal),
			[BodyJointId.Body_RightHandLittleIntermediate] = new JointInfo(OVRPlugin.BoneId.Body_RightHandLittleIntermediate, OVRPlugin.BoneId.Body_RightHandLittleProximal),
			[BodyJointId.Body_RightHandLittleDistal] = new JointInfo(OVRPlugin.BoneId.Body_RightHandLittleDistal, OVRPlugin.BoneId.Body_RightHandLittleIntermediate),
			[BodyJointId.Body_RightHandLittleTip] = new JointInfo(OVRPlugin.BoneId.Body_RightHandLittleTip, OVRPlugin.BoneId.Body_RightHandLittleDistal)
		};

		private static readonly Dictionary<BodyJointId, JointInfo> _lowerBodyJoints = new Dictionary<BodyJointId, JointInfo>
		{
			[BodyJointId.Body_LeftLegUpper] = new JointInfo(OVRPlugin.BoneId.Body_End, OVRPlugin.BoneId.Hand_ForearmStub),
			[BodyJointId.Body_LeftLegLower] = new JointInfo(OVRPlugin.BoneId.FullBody_LeftLowerLeg, OVRPlugin.BoneId.Body_End),
			[BodyJointId.Body_LeftFootAnkleTwist] = new JointInfo(OVRPlugin.BoneId.FullBody_LeftFootAnkleTwist, OVRPlugin.BoneId.FullBody_LeftLowerLeg),
			[BodyJointId.Body_LeftFootAnkle] = new JointInfo(OVRPlugin.BoneId.FullBody_LeftFootAnkle, OVRPlugin.BoneId.FullBody_LeftFootAnkleTwist),
			[BodyJointId.Body_LeftFootSubtalar] = new JointInfo(OVRPlugin.BoneId.FullBody_LeftFootSubtalar, OVRPlugin.BoneId.FullBody_LeftFootAnkle),
			[BodyJointId.Body_LeftFootTransverse] = new JointInfo(OVRPlugin.BoneId.FullBody_LeftFootTransverse, OVRPlugin.BoneId.FullBody_LeftFootSubtalar),
			[BodyJointId.Body_LeftFootBall] = new JointInfo(OVRPlugin.BoneId.FullBody_LeftFootBall, OVRPlugin.BoneId.FullBody_LeftFootTransverse),
			[BodyJointId.Body_RightLegUpper] = new JointInfo(OVRPlugin.BoneId.FullBody_RightUpperLeg, OVRPlugin.BoneId.Hand_ForearmStub),
			[BodyJointId.Body_RightLegLower] = new JointInfo(OVRPlugin.BoneId.FullBody_RightLowerLeg, OVRPlugin.BoneId.FullBody_RightUpperLeg),
			[BodyJointId.Body_RightFootAnkleTwist] = new JointInfo(OVRPlugin.BoneId.FullBody_RightFootAnkleTwist, OVRPlugin.BoneId.FullBody_RightLowerLeg),
			[BodyJointId.Body_RightFootAnkle] = new JointInfo(OVRPlugin.BoneId.FullBody_RightFootAnkle, OVRPlugin.BoneId.FullBody_RightFootAnkleTwist),
			[BodyJointId.Body_RightFootSubtalar] = new JointInfo(OVRPlugin.BoneId.FullBody_RightFootSubtalar, OVRPlugin.BoneId.FullBody_RightFootAnkle),
			[BodyJointId.Body_RightFootTransverse] = new JointInfo(OVRPlugin.BoneId.FullBody_RightFootTransverse, OVRPlugin.BoneId.FullBody_RightFootSubtalar),
			[BodyJointId.Body_RightFootBall] = new JointInfo(OVRPlugin.BoneId.FullBody_RightFootBall, OVRPlugin.BoneId.FullBody_RightFootTransverse)
		};

		[Obsolete("Use the parameterized constructor instead", true)]
		public OVRSkeletonMapping()
			: base(OVRPlugin.BoneId.Hand_Start, (IReadOnlyDictionary<BodyJointId, JointInfo>)_upperBodyJoints)
		{
		}

		public OVRSkeletonMapping(OVRPlugin.BodyJointSet skeletonType)
			: base(GetRoot(), GetJointMapping(skeletonType))
		{
		}

		private static IReadOnlyDictionary<BodyJointId, JointInfo> GetJointMapping(OVRPlugin.BodyJointSet jointSet)
		{
			Dictionary<BodyJointId, JointInfo> dictionary = new Dictionary<BodyJointId, JointInfo>();
			foreach (KeyValuePair<BodyJointId, JointInfo> upperBodyJoint in _upperBodyJoints)
			{
				dictionary.Add(upperBodyJoint.Key, upperBodyJoint.Value);
			}
			if (jointSet == OVRPlugin.BodyJointSet.FullBody)
			{
				foreach (KeyValuePair<BodyJointId, JointInfo> lowerBodyJoint in _lowerBodyJoints)
				{
					dictionary.Add(lowerBodyJoint.Key, lowerBodyJoint.Value);
				}
			}
			return dictionary;
		}

		private static OVRPlugin.BoneId GetRoot()
		{
			return OVRPlugin.BoneId.Hand_Start;
		}
	}
}
