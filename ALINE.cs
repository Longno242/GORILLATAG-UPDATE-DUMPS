using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using AOT;
using Drawing;
using Drawing.Examples;
using Drawing.Text;
using Microsoft.CodeAnalysis;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class IsUnmanagedAttribute : Attribute
	{
	}
}
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
			FilePathsData = new byte[1064]
			{
				0, 0, 0, 3, 0, 0, 0, 42, 92, 65,
				115, 115, 101, 116, 115, 92, 65, 76, 73, 78,
				69, 92, 65, 108, 105, 110, 101, 85, 82, 80,
				82, 101, 110, 100, 101, 114, 80, 97, 115, 115,
				70, 101, 97, 116, 117, 114, 101, 46, 99, 115,
				0, 0, 0, 22, 0, 0, 0, 31, 92, 65,
				115, 115, 101, 116, 115, 92, 65, 76, 73, 78,
				69, 92, 67, 111, 109, 109, 97, 110, 100, 66,
				117, 105, 108, 100, 101, 114, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 33, 92, 65, 115,
				115, 101, 116, 115, 92, 65, 76, 73, 78, 69,
				92, 67, 111, 109, 109, 97, 110, 100, 66, 117,
				105, 108, 100, 101, 114, 50, 68, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 43, 92, 65,
				115, 115, 101, 116, 115, 92, 65, 76, 73, 78,
				69, 92, 67, 111, 109, 109, 97, 110, 100, 66,
				117, 105, 108, 100, 101, 114, 50, 68, 69, 120,
				116, 101, 110, 115, 105, 111, 110, 115, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 41, 92,
				65, 115, 115, 101, 116, 115, 92, 65, 76, 73,
				78, 69, 92, 67, 111, 109, 109, 97, 110, 100,
				66, 117, 105, 108, 100, 101, 114, 69, 120, 116,
				101, 110, 115, 105, 111, 110, 115, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 21, 92, 65,
				115, 115, 101, 116, 115, 92, 65, 76, 73, 78,
				69, 92, 68, 114, 97, 119, 46, 99, 115, 0,
				0, 0, 19, 0, 0, 0, 28, 92, 65, 115,
				115, 101, 116, 115, 92, 65, 76, 73, 78, 69,
				92, 68, 114, 97, 119, 105, 110, 103, 68, 97,
				116, 97, 46, 99, 115, 0, 0, 0, 3, 0,
				0, 0, 31, 92, 65, 115, 115, 101, 116, 115,
				92, 65, 76, 73, 78, 69, 92, 68, 114, 97,
				119, 105, 110, 103, 77, 97, 110, 97, 103, 101,
				114, 46, 99, 115, 0, 0, 0, 2, 0, 0,
				0, 32, 92, 65, 115, 115, 101, 116, 115, 92,
				65, 76, 73, 78, 69, 92, 68, 114, 97, 119,
				105, 110, 103, 83, 101, 116, 116, 105, 110, 103,
				115, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 33, 92, 65, 115, 115, 101, 116, 115, 92,
				65, 76, 73, 78, 69, 92, 68, 114, 97, 119,
				105, 110, 103, 85, 116, 105, 108, 105, 116, 105,
				101, 115, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 68, 92, 65, 115, 115, 101, 116, 115,
				92, 65, 76, 73, 78, 69, 92, 69, 120, 97,
				109, 112, 108, 101, 83, 99, 101, 110, 101, 115,
				92, 69, 120, 97, 109, 112, 108, 101, 49, 95,
				71, 105, 122, 109, 111, 115, 92, 71, 105, 122,
				109, 111, 67, 104, 97, 114, 97, 99, 116, 101,
				114, 69, 120, 97, 109, 112, 108, 101, 46, 99,
				115, 0, 0, 0, 2, 0, 0, 0, 65, 92,
				65, 115, 115, 101, 116, 115, 92, 65, 76, 73,
				78, 69, 92, 69, 120, 97, 109, 112, 108, 101,
				83, 99, 101, 110, 101, 115, 92, 69, 120, 97,
				109, 112, 108, 101, 49, 95, 71, 105, 122, 109,
				111, 115, 92, 71, 105, 122, 109, 111, 83, 112,
				104, 101, 114, 101, 69, 120, 97, 109, 112, 108,
				101, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 59, 92, 65, 115, 115, 101, 116, 115, 92,
				65, 76, 73, 78, 69, 92, 69, 120, 97, 109,
				112, 108, 101, 83, 99, 101, 110, 101, 115, 92,
				69, 120, 97, 109, 112, 108, 101, 49, 95, 71,
				105, 122, 109, 111, 115, 92, 84, 105, 109, 101,
				100, 83, 112, 97, 119, 110, 101, 114, 46, 99,
				115, 0, 0, 0, 2, 0, 0, 0, 63, 92,
				65, 115, 115, 101, 116, 115, 92, 65, 76, 73,
				78, 69, 92, 69, 120, 97, 109, 112, 108, 101,
				83, 99, 101, 110, 101, 115, 92, 69, 120, 97,
				109, 112, 108, 101, 50, 95, 67, 117, 114, 118,
				101, 69, 100, 105, 116, 111, 114, 92, 67, 117,
				114, 118, 101, 69, 100, 105, 116, 111, 114, 46,
				99, 115, 0, 0, 0, 2, 0, 0, 0, 58,
				92, 65, 115, 115, 101, 116, 115, 92, 65, 76,
				73, 78, 69, 92, 69, 120, 97, 109, 112, 108,
				101, 83, 99, 101, 110, 101, 115, 92, 69, 120,
				97, 109, 112, 108, 101, 51, 95, 66, 117, 114,
				115, 116, 92, 66, 117, 114, 115, 116, 69, 120,
				97, 109, 112, 108, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 60, 92, 65, 115, 115,
				101, 116, 115, 92, 65, 76, 73, 78, 69, 92,
				69, 120, 97, 109, 112, 108, 101, 83, 99, 101,
				110, 101, 115, 92, 69, 120, 97, 109, 112, 108,
				101, 52, 95, 83, 116, 121, 108, 105, 110, 103,
				92, 65, 108, 105, 110, 101, 83, 116, 121, 108,
				105, 110, 103, 46, 99, 115, 0, 0, 0, 6,
				0, 0, 0, 32, 92, 65, 115, 115, 101, 116,
				115, 92, 65, 76, 73, 78, 69, 92, 71, 101,
				111, 109, 101, 116, 114, 121, 66, 117, 105, 108,
				100, 101, 114, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 36, 92, 65, 115, 115, 101, 116,
				115, 92, 65, 76, 73, 78, 69, 92, 77, 111,
				110, 111, 66, 101, 104, 97, 118, 105, 111, 117,
				114, 71, 105, 122, 109, 111, 115, 46, 99, 115,
				0, 0, 0, 5, 0, 0, 0, 24, 92, 65,
				115, 115, 101, 116, 115, 92, 65, 76, 73, 78,
				69, 92, 80, 97, 108, 101, 116, 116, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 33,
				92, 65, 115, 115, 101, 116, 115, 92, 65, 76,
				73, 78, 69, 92, 80, 101, 114, 115, 105, 115,
				116, 101, 110, 116, 70, 105, 108, 116, 101, 114,
				46, 99, 115, 0, 0, 0, 4, 0, 0, 0,
				24, 92, 65, 115, 115, 101, 116, 115, 92, 65,
				76, 73, 78, 69, 92, 83, 68, 70, 70, 111,
				110, 116, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 31, 92, 65, 115, 115, 101, 116, 115,
				92, 65, 76, 73, 78, 69, 92, 83, 116, 114,
				101, 97, 109, 83, 112, 108, 105, 116, 116, 101,
				114, 46, 99, 115
			},
			TypesData = new byte[2596]
			{
				0, 0, 0, 0, 33, 68, 114, 97, 119, 105,
				110, 103, 124, 65, 108, 105, 110, 101, 85, 82,
				80, 82, 101, 110, 100, 101, 114, 80, 97, 115,
				115, 70, 101, 97, 116, 117, 114, 101, 0, 0,
				0, 0, 52, 68, 114, 97, 119, 105, 110, 103,
				46, 65, 108, 105, 110, 101, 85, 82, 80, 82,
				101, 110, 100, 101, 114, 80, 97, 115, 115, 70,
				101, 97, 116, 117, 114, 101, 124, 65, 108, 105,
				110, 101, 85, 82, 80, 82, 101, 110, 100, 101,
				114, 80, 97, 115, 115, 0, 0, 0, 0, 61,
				68, 114, 97, 119, 105, 110, 103, 46, 65, 108,
				105, 110, 101, 85, 82, 80, 82, 101, 110, 100,
				101, 114, 80, 97, 115, 115, 70, 101, 97, 116,
				117, 114, 101, 43, 65, 108, 105, 110, 101, 85,
				82, 80, 82, 101, 110, 100, 101, 114, 80, 97,
				115, 115, 124, 80, 97, 115, 115, 68, 97, 116,
				97, 0, 0, 0, 0, 22, 68, 114, 97, 119,
				105, 110, 103, 124, 76, 97, 98, 101, 108, 65,
				108, 105, 103, 110, 109, 101, 110, 116, 0, 0,
				0, 0, 30, 68, 114, 97, 119, 105, 110, 103,
				124, 67, 111, 109, 109, 97, 110, 100, 66, 117,
				105, 108, 100, 101, 114, 83, 97, 109, 112, 108,
				101, 114, 115, 1, 0, 0, 0, 22, 68, 114,
				97, 119, 105, 110, 103, 124, 67, 111, 109, 109,
				97, 110, 100, 66, 117, 105, 108, 100, 101, 114,
				0, 0, 0, 0, 21, 68, 114, 97, 119, 105,
				110, 103, 46, 124, 84, 114, 105, 97, 110, 103,
				108, 101, 68, 97, 116, 97, 0, 0, 0, 0,
				17, 68, 114, 97, 119, 105, 110, 103, 46, 124,
				76, 105, 110, 101, 68, 97, 116, 97, 0, 0,
				0, 0, 19, 68, 114, 97, 119, 105, 110, 103,
				46, 124, 76, 105, 110, 101, 68, 97, 116, 97,
				86, 51, 0, 0, 0, 0, 21, 68, 114, 97,
				119, 105, 110, 103, 46, 124, 67, 105, 114, 99,
				108, 101, 88, 90, 68, 97, 116, 97, 0, 0,
				0, 0, 19, 68, 114, 97, 119, 105, 110, 103,
				46, 124, 67, 105, 114, 99, 108, 101, 68, 97,
				116, 97, 0, 0, 0, 0, 19, 68, 114, 97,
				119, 105, 110, 103, 46, 124, 83, 112, 104, 101,
				114, 101, 68, 97, 116, 97, 0, 0, 0, 0,
				16, 68, 114, 97, 119, 105, 110, 103, 46, 124,
				66, 111, 120, 68, 97, 116, 97, 0, 0, 0,
				0, 18, 68, 114, 97, 119, 105, 110, 103, 46,
				124, 80, 108, 97, 110, 101, 68, 97, 116, 97,
				0, 0, 0, 0, 20, 68, 114, 97, 119, 105,
				110, 103, 46, 124, 80, 101, 114, 115, 105, 115,
				116, 68, 97, 116, 97, 0, 0, 0, 0, 22,
				68, 114, 97, 119, 105, 110, 103, 46, 124, 76,
				105, 110, 101, 87, 105, 100, 116, 104, 68, 97,
				116, 97, 0, 0, 0, 0, 17, 68, 114, 97,
				119, 105, 110, 103, 46, 124, 84, 101, 120, 116,
				68, 97, 116, 97, 0, 0, 0, 0, 19, 68,
				114, 97, 119, 105, 110, 103, 46, 124, 84, 101,
				120, 116, 68, 97, 116, 97, 51, 68, 0, 0,
				0, 0, 20, 68, 114, 97, 119, 105, 110, 103,
				46, 124, 83, 99, 111, 112, 101, 77, 97, 116,
				114, 105, 120, 0, 0, 0, 0, 19, 68, 114,
				97, 119, 105, 110, 103, 46, 124, 83, 99, 111,
				112, 101, 67, 111, 108, 111, 114, 0, 0, 0,
				0, 21, 68, 114, 97, 119, 105, 110, 103, 46,
				124, 83, 99, 111, 112, 101, 80, 101, 114, 115,
				105, 115, 116, 0, 0, 0, 0, 19, 68, 114,
				97, 119, 105, 110, 103, 46, 124, 83, 99, 111,
				112, 101, 69, 109, 112, 116, 121, 0, 0, 0,
				0, 23, 68, 114, 97, 119, 105, 110, 103, 46,
				124, 83, 99, 111, 112, 101, 76, 105, 110, 101,
				87, 105, 100, 116, 104, 0, 0, 0, 0, 27,
				68, 114, 97, 119, 105, 110, 103, 46, 124, 80,
				111, 108, 121, 108, 105, 110, 101, 87, 105, 116,
				104, 83, 121, 109, 98, 111, 108, 0, 0, 0,
				0, 20, 68, 114, 97, 119, 105, 110, 103, 46,
				124, 74, 111, 98, 87, 105, 114, 101, 77, 101,
				115, 104, 1, 0, 0, 0, 24, 68, 114, 97,
				119, 105, 110, 103, 124, 67, 111, 109, 109, 97,
				110, 100, 66, 117, 105, 108, 100, 101, 114, 50,
				68, 1, 0, 0, 0, 24, 68, 114, 97, 119,
				105, 110, 103, 124, 67, 111, 109, 109, 97, 110,
				100, 66, 117, 105, 108, 100, 101, 114, 50, 68,
				1, 0, 0, 0, 22, 68, 114, 97, 119, 105,
				110, 103, 124, 67, 111, 109, 109, 97, 110, 100,
				66, 117, 105, 108, 100, 101, 114, 0, 0, 0,
				0, 12, 68, 114, 97, 119, 105, 110, 103, 124,
				68, 114, 97, 119, 0, 0, 0, 0, 25, 68,
				114, 97, 119, 105, 110, 103, 124, 83, 104, 97,
				114, 101, 100, 68, 114, 97, 119, 105, 110, 103,
				68, 97, 116, 97, 0, 0, 0, 0, 38, 68,
				114, 97, 119, 105, 110, 103, 46, 83, 104, 97,
				114, 101, 100, 68, 114, 97, 119, 105, 110, 103,
				68, 97, 116, 97, 124, 66, 117, 114, 115, 116,
				84, 105, 109, 101, 75, 101, 121, 0, 0, 0,
				0, 19, 68, 114, 97, 119, 105, 110, 103, 124,
				82, 101, 100, 114, 97, 119, 83, 99, 111, 112,
				101, 0, 0, 0, 0, 19, 68, 114, 97, 119,
				105, 110, 103, 124, 68, 114, 97, 119, 105, 110,
				103, 68, 97, 116, 97, 0, 0, 0, 0, 26,
				68, 114, 97, 119, 105, 110, 103, 46, 68, 114,
				97, 119, 105, 110, 103, 68, 97, 116, 97, 124,
				72, 97, 115, 104, 101, 114, 0, 0, 0, 0,
				40, 68, 114, 97, 119, 105, 110, 103, 46, 68,
				114, 97, 119, 105, 110, 103, 68, 97, 116, 97,
				124, 80, 114, 111, 99, 101, 115, 115, 101, 100,
				66, 117, 105, 108, 100, 101, 114, 68, 97, 116,
				97, 0, 0, 0, 0, 34, 68, 114, 97, 119,
				105, 110, 103, 46, 68, 114, 97, 119, 105, 110,
				103, 68, 97, 116, 97, 43, 124, 67, 97, 112,
				116, 117, 114, 101, 100, 83, 116, 97, 116, 101,
				0, 0, 0, 0, 32, 68, 114, 97, 119, 105,
				110, 103, 46, 68, 114, 97, 119, 105, 110, 103,
				68, 97, 116, 97, 43, 124, 77, 101, 115, 104,
				66, 117, 102, 102, 101, 114, 115, 0, 0, 0,
				0, 33, 68, 114, 97, 119, 105, 110, 103, 46,
				68, 114, 97, 119, 105, 110, 103, 68, 97, 116,
				97, 124, 83, 117, 98, 109, 105, 116, 116, 101,
				100, 77, 101, 115, 104, 0, 0, 0, 0, 31,
				68, 114, 97, 119, 105, 110, 103, 46, 68, 114,
				97, 119, 105, 110, 103, 68, 97, 116, 97, 124,
				66, 117, 105, 108, 100, 101, 114, 68, 97, 116,
				97, 0, 0, 0, 0, 25, 68, 114, 97, 119,
				105, 110, 103, 46, 68, 114, 97, 119, 105, 110,
				103, 68, 97, 116, 97, 43, 124, 77, 101, 116,
				97, 0, 0, 0, 0, 34, 68, 114, 97, 119,
				105, 110, 103, 46, 68, 114, 97, 119, 105, 110,
				103, 68, 97, 116, 97, 43, 124, 66, 105, 116,
				80, 97, 99, 107, 101, 100, 77, 101, 116, 97,
				0, 0, 0, 0, 40, 68, 114, 97, 119, 105,
				110, 103, 46, 68, 114, 97, 119, 105, 110, 103,
				68, 97, 116, 97, 124, 66, 117, 105, 108, 100,
				101, 114, 68, 97, 116, 97, 67, 111, 110, 116,
				97, 105, 110, 101, 114, 0, 0, 0, 0, 49,
				68, 114, 97, 119, 105, 110, 103, 46, 68, 114,
				97, 119, 105, 110, 103, 68, 97, 116, 97, 124,
				80, 114, 111, 99, 101, 115, 115, 101, 100, 66,
				117, 105, 108, 100, 101, 114, 68, 97, 116, 97,
				67, 111, 110, 116, 97, 105, 110, 101, 114, 0,
				0, 0, 0, 32, 68, 114, 97, 119, 105, 110,
				103, 46, 68, 114, 97, 119, 105, 110, 103, 68,
				97, 116, 97, 124, 77, 101, 115, 104, 87, 105,
				116, 104, 84, 121, 112, 101, 0, 0, 0, 0,
				40, 68, 114, 97, 119, 105, 110, 103, 46, 68,
				114, 97, 119, 105, 110, 103, 68, 97, 116, 97,
				124, 82, 101, 110, 100, 101, 114, 101, 100, 77,
				101, 115, 104, 87, 105, 116, 104, 84, 121, 112,
				101, 0, 0, 0, 0, 25, 68, 114, 97, 119,
				105, 110, 103, 46, 68, 114, 97, 119, 105, 110,
				103, 68, 97, 116, 97, 124, 82, 97, 110, 103,
				101, 0, 0, 0, 0, 45, 68, 114, 97, 119,
				105, 110, 103, 46, 68, 114, 97, 119, 105, 110,
				103, 68, 97, 116, 97, 124, 77, 101, 115, 104,
				67, 111, 109, 112, 97, 114, 101, 66, 121, 68,
				114, 97, 119, 105, 110, 103, 79, 114, 100, 101,
				114, 0, 0, 0, 0, 40, 68, 114, 97, 119,
				105, 110, 103, 46, 68, 114, 97, 119, 105, 110,
				103, 68, 97, 116, 97, 124, 67, 111, 109, 109,
				97, 110, 100, 66, 117, 102, 102, 101, 114, 87,
				114, 97, 112, 112, 101, 114, 0, 0, 0, 0,
				20, 68, 114, 97, 119, 105, 110, 103, 124, 71,
				105, 122, 109, 111, 67, 111, 110, 116, 101, 120,
				116, 0, 0, 0, 0, 19, 68, 114, 97, 119,
				105, 110, 103, 124, 73, 68, 114, 97, 119, 71,
				105, 122, 109, 111, 115, 0, 0, 0, 0, 22,
				68, 114, 97, 119, 105, 110, 103, 124, 68, 114,
				97, 119, 105, 110, 103, 77, 97, 110, 97, 103,
				101, 114, 0, 0, 0, 0, 23, 68, 114, 97,
				119, 105, 110, 103, 124, 68, 114, 97, 119, 105,
				110, 103, 83, 101, 116, 116, 105, 110, 103, 115,
				0, 0, 0, 0, 32, 68, 114, 97, 119, 105,
				110, 103, 46, 68, 114, 97, 119, 105, 110, 103,
				83, 101, 116, 116, 105, 110, 103, 115, 124, 83,
				101, 116, 116, 105, 110, 103, 115, 0, 0, 0,
				0, 24, 68, 114, 97, 119, 105, 110, 103, 124,
				68, 114, 97, 119, 105, 110, 103, 85, 116, 105,
				108, 105, 116, 105, 101, 115, 0, 0, 0, 0,
				38, 68, 114, 97, 119, 105, 110, 103, 46, 69,
				120, 97, 109, 112, 108, 101, 115, 124, 71, 105,
				122, 109, 111, 67, 104, 97, 114, 97, 99, 116,
				101, 114, 69, 120, 97, 109, 112, 108, 101, 0,
				0, 0, 0, 35, 68, 114, 97, 119, 105, 110,
				103, 46, 69, 120, 97, 109, 112, 108, 101, 115,
				124, 71, 105, 122, 109, 111, 83, 112, 104, 101,
				114, 101, 69, 120, 97, 109, 112, 108, 101, 0,
				0, 0, 0, 43, 68, 114, 97, 119, 105, 110,
				103, 46, 69, 120, 97, 109, 112, 108, 101, 115,
				46, 71, 105, 122, 109, 111, 83, 112, 104, 101,
				114, 101, 69, 120, 97, 109, 112, 108, 101, 124,
				67, 111, 110, 116, 97, 99, 116, 0, 0, 0,
				0, 29, 68, 114, 97, 119, 105, 110, 103, 46,
				69, 120, 97, 109, 112, 108, 101, 115, 124, 84,
				105, 109, 101, 100, 83, 112, 97, 119, 110, 101,
				114, 0, 0, 0, 0, 28, 68, 114, 97, 119,
				105, 110, 103, 46, 69, 120, 97, 109, 112, 108,
				101, 115, 124, 67, 117, 114, 118, 101, 69, 100,
				105, 116, 111, 114, 0, 0, 0, 0, 39, 68,
				114, 97, 119, 105, 110, 103, 46, 69, 120, 97,
				109, 112, 108, 101, 115, 46, 67, 117, 114, 118,
				101, 69, 100, 105, 116, 111, 114, 124, 67, 117,
				114, 118, 101, 80, 111, 105, 110, 116, 0, 0,
				0, 0, 29, 68, 114, 97, 119, 105, 110, 103,
				46, 69, 120, 97, 109, 112, 108, 101, 115, 124,
				66, 117, 114, 115, 116, 69, 120, 97, 109, 112,
				108, 101, 0, 0, 0, 0, 40, 68, 114, 97,
				119, 105, 110, 103, 46, 69, 120, 97, 109, 112,
				108, 101, 115, 46, 66, 117, 114, 115, 116, 69,
				120, 97, 109, 112, 108, 101, 124, 68, 114, 97,
				119, 105, 110, 103, 74, 111, 98, 0, 0, 0,
				0, 29, 68, 114, 97, 119, 105, 110, 103, 46,
				69, 120, 97, 109, 112, 108, 101, 115, 124, 65,
				108, 105, 110, 101, 83, 116, 121, 108, 105, 110,
				103, 0, 0, 0, 0, 23, 68, 114, 97, 119,
				105, 110, 103, 124, 71, 101, 111, 109, 101, 116,
				114, 121, 66, 117, 105, 108, 100, 101, 114, 0,
				0, 0, 0, 34, 68, 114, 97, 119, 105, 110,
				103, 46, 71, 101, 111, 109, 101, 116, 114, 121,
				66, 117, 105, 108, 100, 101, 114, 124, 67, 97,
				109, 101, 114, 97, 73, 110, 102, 111, 0, 0,
				0, 0, 19, 68, 114, 97, 119, 105, 110, 103,
				124, 77, 101, 115, 104, 76, 97, 121, 111, 117,
				116, 115, 0, 0, 0, 0, 26, 68, 114, 97,
				119, 105, 110, 103, 124, 71, 101, 111, 109, 101,
				116, 114, 121, 66, 117, 105, 108, 100, 101, 114,
				74, 111, 98, 0, 0, 0, 0, 15, 68, 114,
				97, 119, 105, 110, 103, 46, 124, 86, 101, 114,
				116, 101, 120, 0, 0, 0, 0, 19, 68, 114,
				97, 119, 105, 110, 103, 46, 124, 84, 101, 120,
				116, 86, 101, 114, 116, 101, 120, 0, 0, 0,
				0, 27, 68, 114, 97, 119, 105, 110, 103, 124,
				77, 111, 110, 111, 66, 101, 104, 97, 118, 105,
				111, 117, 114, 71, 105, 122, 109, 111, 115, 0,
				0, 0, 0, 15, 68, 114, 97, 119, 105, 110,
				103, 124, 80, 97, 108, 101, 116, 116, 101, 0,
				0, 0, 0, 20, 68, 114, 97, 119, 105, 110,
				103, 46, 80, 97, 108, 101, 116, 116, 101, 124,
				80, 117, 114, 101, 0, 0, 0, 0, 27, 68,
				114, 97, 119, 105, 110, 103, 46, 80, 97, 108,
				101, 116, 116, 101, 124, 67, 111, 108, 111, 114,
				98, 114, 101, 119, 101, 114, 0, 0, 0, 0,
				32, 68, 114, 97, 119, 105, 110, 103, 46, 80,
				97, 108, 101, 116, 116, 101, 43, 67, 111, 108,
				111, 114, 98, 114, 101, 119, 101, 114, 124, 83,
				101, 116, 49, 0, 0, 0, 0, 33, 68, 114,
				97, 119, 105, 110, 103, 46, 80, 97, 108, 101,
				116, 116, 101, 43, 67, 111, 108, 111, 114, 98,
				114, 101, 119, 101, 114, 124, 66, 108, 117, 101,
				115, 0, 0, 0, 0, 27, 68, 114, 97, 119,
				105, 110, 103, 124, 80, 101, 114, 115, 105, 115,
				116, 101, 110, 116, 70, 105, 108, 116, 101, 114,
				74, 111, 98, 0, 0, 0, 0, 25, 68, 114,
				97, 119, 105, 110, 103, 46, 84, 101, 120, 116,
				124, 83, 68, 70, 67, 104, 97, 114, 97, 99,
				116, 101, 114, 0, 0, 0, 0, 20, 68, 114,
				97, 119, 105, 110, 103, 46, 84, 101, 120, 116,
				124, 83, 68, 70, 70, 111, 110, 116, 0, 0,
				0, 0, 26, 68, 114, 97, 119, 105, 110, 103,
				46, 84, 101, 120, 116, 124, 83, 68, 70, 76,
				111, 111, 107, 117, 112, 68, 97, 116, 97, 0,
				0, 0, 0, 25, 68, 114, 97, 119, 105, 110,
				103, 46, 84, 101, 120, 116, 124, 68, 101, 102,
				97, 117, 108, 116, 70, 111, 110, 116, 115, 0,
				0, 0, 0, 22, 68, 114, 97, 119, 105, 110,
				103, 124, 83, 116, 114, 101, 97, 109, 83, 112,
				108, 105, 116, 116, 101, 114
			},
			TotalFiles = 22,
			TotalTypes = 81,
			IsEditorOnly = false
		};
	}
}
namespace Drawing
{
	public class AlineURPRenderPassFeature : ScriptableRendererFeature
	{
		public class AlineURPRenderPass : ScriptableRenderPass
		{
			private class PassData
			{
				public Camera camera;
			}

			[Obsolete]
			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
			}

			[Obsolete]
			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				DrawingManager.instance.ExecuteCustomRenderPass(context, renderingData.cameraData.camera);
			}

			public AlineURPRenderPass()
			{
				base.profilingSampler = new ProfilingSampler("ALINE");
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				PassData passData;
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>("ALINE", out passData, base.profilingSampler, "C:\\Users\\root\\GT\\Assets\\ALINE\\AlineURPRenderPassFeature.cs", 41);
				bool allowDisablingWireframe = false;
				if (Application.isEditor && (universalCameraData.cameraType & (CameraType.SceneView | CameraType.Preview)) != 0)
				{
					rasterRenderGraphBuilder.AllowGlobalStateModification(value: true);
					allowDisablingWireframe = true;
				}
				rasterRenderGraphBuilder.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
				rasterRenderGraphBuilder.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture);
				passData.camera = universalCameraData.camera;
				rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
				{
					DrawingManager.instance.ExecuteCustomRenderGraphPass(new DrawingData.CommandBufferWrapper
					{
						cmd2 = context.cmd,
						allowDisablingWireframe = allowDisablingWireframe
					}, data.camera);
				});
			}

			public override void FrameCleanup(CommandBuffer cmd)
			{
			}
		}

		private AlineURPRenderPass m_ScriptablePass;

		public override void Create()
		{
			m_ScriptablePass = new AlineURPRenderPass();
			m_ScriptablePass.renderPassEvent = (RenderPassEvent)549;
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			AddRenderPasses(renderer);
		}

		public void AddRenderPasses(ScriptableRenderer renderer)
		{
			renderer.EnqueuePass(m_ScriptablePass);
		}
	}
	public struct LabelAlignment
	{
		public float2 relativePivot;

		public float2 pixelOffset;

		public static readonly LabelAlignment TopLeft = new LabelAlignment
		{
			relativePivot = new float2(0f, 1f),
			pixelOffset = new float2(0f, 0f)
		};

		public static readonly LabelAlignment MiddleLeft = new LabelAlignment
		{
			relativePivot = new float2(0f, 0.5f),
			pixelOffset = new float2(0f, 0f)
		};

		public static readonly LabelAlignment BottomLeft = new LabelAlignment
		{
			relativePivot = new float2(0f, 0f),
			pixelOffset = new float2(0f, 0f)
		};

		public static readonly LabelAlignment BottomCenter = new LabelAlignment
		{
			relativePivot = new float2(0.5f, 0f),
			pixelOffset = new float2(0f, 0f)
		};

		public static readonly LabelAlignment BottomRight = new LabelAlignment
		{
			relativePivot = new float2(1f, 0f),
			pixelOffset = new float2(0f, 0f)
		};

		public static readonly LabelAlignment MiddleRight = new LabelAlignment
		{
			relativePivot = new float2(1f, 0.5f),
			pixelOffset = new float2(0f, 0f)
		};

		public static readonly LabelAlignment TopRight = new LabelAlignment
		{
			relativePivot = new float2(1f, 1f),
			pixelOffset = new float2(0f, 0f)
		};

		public static readonly LabelAlignment TopCenter = new LabelAlignment
		{
			relativePivot = new float2(0.5f, 1f),
			pixelOffset = new float2(0f, 0f)
		};

		public static readonly LabelAlignment Center = new LabelAlignment
		{
			relativePivot = new float2(0.5f, 0.5f),
			pixelOffset = new float2(0f, 0f)
		};

		public LabelAlignment withPixelOffset(float x, float y)
		{
			return new LabelAlignment
			{
				relativePivot = relativePivot,
				pixelOffset = new float2(x, y)
			};
		}
	}
	public enum AllowedDelay
	{
		EndOfFrame,
		Infinite
	}
	internal static class CommandBuilderSamplers
	{
		internal static readonly ProfilerMarker MarkerConvert = new ProfilerMarker("Convert");

		internal static readonly ProfilerMarker MarkerSetLayout = new ProfilerMarker("SetLayout");

		internal static readonly ProfilerMarker MarkerUpdateVertices = new ProfilerMarker("UpdateVertices");

		internal static readonly ProfilerMarker MarkerUpdateIndices = new ProfilerMarker("UpdateIndices");

		internal static readonly ProfilerMarker MarkerSubmesh = new ProfilerMarker("Submesh");

		internal static readonly ProfilerMarker MarkerUpdateBuffer = new ProfilerMarker("UpdateComputeBuffer");

		internal static readonly ProfilerMarker MarkerProcessCommands = new ProfilerMarker("Commands");

		internal static readonly ProfilerMarker MarkerCreateTriangles = new ProfilerMarker("CreateTriangles");
	}
	[BurstCompile]
	public struct CommandBuilder : IDisposable
	{
		[Flags]
		internal enum Command
		{
			PushColorInline = 0x100,
			PushColor = 0,
			PopColor = 1,
			PushMatrix = 2,
			PushSetMatrix = 3,
			PopMatrix = 4,
			Line = 5,
			Circle = 6,
			CircleXZ = 7,
			Disc = 8,
			DiscXZ = 9,
			SphereOutline = 0xA,
			Box = 0xB,
			WirePlane = 0xC,
			WireBox = 0xD,
			SolidTriangle = 0xE,
			PushPersist = 0xF,
			PopPersist = 0x10,
			Text = 0x11,
			Text3D = 0x12,
			PushLineWidth = 0x13,
			PopLineWidth = 0x14,
			CaptureState = 0x15
		}

		internal struct TriangleData
		{
			public float3 a;

			public float3 b;

			public float3 c;
		}

		internal struct LineData
		{
			public float3 a;

			public float3 b;
		}

		internal struct LineDataV3
		{
			public Vector3 a;

			public Vector3 b;
		}

		internal struct CircleXZData
		{
			public float3 center;

			public float radius;

			public float startAngle;

			public float endAngle;
		}

		internal struct CircleData
		{
			public float3 center;

			public float3 normal;

			public float radius;
		}

		internal struct SphereData
		{
			public float3 center;

			public float radius;
		}

		internal struct BoxData
		{
			public float3 center;

			public float3 size;
		}

		internal struct PlaneData
		{
			public float3 center;

			public quaternion rotation;

			public float2 size;
		}

		internal struct PersistData
		{
			public float endTime;
		}

		internal struct LineWidthData
		{
			public float pixels;

			public bool automaticJoins;
		}

		internal struct TextData
		{
			public float3 center;

			public LabelAlignment alignment;

			public float sizeInPixels;

			public int numCharacters;
		}

		internal struct TextData3D
		{
			public float3 center;

			public quaternion rotation;

			public LabelAlignment alignment;

			public float size;

			public int numCharacters;
		}

		public struct ScopeMatrix : IDisposable
		{
			internal CommandBuilder builder;

			public unsafe void Dispose()
			{
				builder.PopMatrix();
				builder.buffer = null;
			}
		}

		public struct ScopeColor : IDisposable
		{
			internal CommandBuilder builder;

			public unsafe void Dispose()
			{
				builder.PopColor();
				builder.buffer = null;
			}
		}

		public struct ScopePersist : IDisposable
		{
			internal CommandBuilder builder;

			public unsafe void Dispose()
			{
				builder.PopDuration();
				builder.buffer = null;
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct ScopeEmpty : IDisposable
		{
			public void Dispose()
			{
			}
		}

		public struct ScopeLineWidth : IDisposable
		{
			internal CommandBuilder builder;

			public unsafe void Dispose()
			{
				builder.PopLineWidth();
				builder.buffer = null;
			}
		}

		public enum SymbolDecoration
		{
			None,
			ArrowHead,
			Circle
		}

		public struct PolylineWithSymbol
		{
			private float3 prev;

			private float offset;

			private readonly float symbolSize;

			private readonly float symbolSpacing;

			private readonly float symbolPadding;

			private readonly float symbolOffset;

			private readonly SymbolDecoration symbol;

			private readonly bool reverseSymbols;

			private bool odd;

			public PolylineWithSymbol(SymbolDecoration symbol, float symbolSize, float symbolPadding, float symbolSpacing, bool reverseSymbols = false)
			{
				if (symbolSpacing <= 1.1754944E-38f)
				{
					throw new ArgumentOutOfRangeException("symbolSpacing", "Symbol spacing must be greater than zero");
				}
				if (symbolSize <= 1.1754944E-38f)
				{
					throw new ArgumentOutOfRangeException("symbolSize", "Symbol size must be greater than zero");
				}
				if (symbolPadding < 0f)
				{
					throw new ArgumentOutOfRangeException("symbolPadding", "Symbol padding must non-negative");
				}
				prev = float3.zero;
				this.symbol = symbol;
				this.symbolSize = symbolSize;
				this.symbolPadding = symbolPadding;
				this.symbolSpacing = math.max(0f, symbolSpacing - symbolPadding * 2f - symbolSize);
				this.reverseSymbols = reverseSymbols;
				symbolOffset = ((symbol == SymbolDecoration.ArrowHead) ? (-0.25f * symbolSize) : 0f);
				if (reverseSymbols)
				{
					symbolOffset = 0f - symbolOffset;
				}
				symbolOffset += 0.5f * symbolSize;
				offset = -1f;
				odd = false;
			}

			public void MoveTo(ref CommandBuilder draw, float3 next)
			{
				if (offset == -1f)
				{
					offset = symbolSpacing * 0.5f;
					prev = next;
					return;
				}
				float num = math.length(next - prev);
				float num2 = math.rcp(num);
				float3 float5 = next - prev;
				float3 float6 = default(float3);
				if (symbol != SymbolDecoration.None)
				{
					float6 = math.normalizesafe(math.cross(float5, math.cross(float5, new float3(0f, 1f, 0f))));
					if (math.all(float6 == 0f))
					{
						float6 = new float3(0f, 0f, 1f);
					}
				}
				if (reverseSymbols)
				{
					float5 = -float5;
				}
				if (offset > 0f && !odd)
				{
					draw.Line(prev, math.lerp(prev, next, math.min(offset * num2, 1f)));
				}
				while (offset < num)
				{
					if (odd)
					{
						float3 a = math.lerp(prev, next, offset * num2);
						offset += symbolSpacing;
						float3 b = math.lerp(prev, next, math.min(offset * num2, 1f));
						draw.Line(a, b);
						offset += symbolPadding;
					}
					else
					{
						float3 center = math.lerp(prev, next, (offset + symbolOffset) * num2);
						switch (symbol)
						{
						case SymbolDecoration.ArrowHead:
							draw.Arrowhead(center, float5, float6, symbolSize);
							break;
						default:
							draw.Circle(center, float6, symbolSize * 0.5f);
							break;
						case SymbolDecoration.None:
							break;
						}
						offset += symbolSize + symbolPadding;
					}
					odd = !odd;
				}
				offset -= num;
				prev = next;
			}
		}

		[BurstCompile]
		private class JobWireMesh
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate void JobWireMeshDelegate(ref Mesh.MeshData rawMeshData, ref CommandBuilder draw);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal unsafe delegate void WireMesh_00000109$PostfixBurstDelegate(float3* verts, int* indices, int vertexCount, int indexCount, ref CommandBuilder draw);

			internal static class WireMesh_00000109$BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<WireMesh_00000109$PostfixBurstDelegate>(WireMesh).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static void Invoke(float3* verts, int* indices, int vertexCount, int indexCount, ref CommandBuilder draw)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<float3*, int*, int, int, ref CommandBuilder, void>)functionPointer)(verts, indices, vertexCount, indexCount, ref draw);
							return;
						}
					}
					WireMesh$BurstManaged(verts, indices, vertexCount, indexCount, ref draw);
				}
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void Execute_0000010A$PostfixBurstDelegate(ref Mesh.MeshData rawMeshData, ref CommandBuilder draw);

			internal static class Execute_0000010A$BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<Execute_0000010A$PostfixBurstDelegate>(Execute).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static void Invoke(ref Mesh.MeshData rawMeshData, ref CommandBuilder draw)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<ref Mesh.MeshData, ref CommandBuilder, void>)functionPointer)(ref rawMeshData, ref draw);
							return;
						}
					}
					Execute$BurstManaged(ref rawMeshData, ref draw);
				}
			}

			public static readonly JobWireMeshDelegate JobWireMeshFunctionPointer = BurstCompiler.CompileFunctionPointer<JobWireMeshDelegate>(Execute).Invoke;

			[BurstCompile]
			[MonoPInvokeCallback(typeof(WireMesh_00000109$PostfixBurstDelegate))]
			public unsafe static void WireMesh(float3* verts, int* indices, int vertexCount, int indexCount, ref CommandBuilder draw)
			{
				WireMesh_00000109$BurstDirectCall.Invoke(verts, indices, vertexCount, indexCount, ref draw);
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(JobWireMeshDelegate))]
			private static void Execute(ref Mesh.MeshData rawMeshData, ref CommandBuilder draw)
			{
				Execute_0000010A$BurstDirectCall.Invoke(ref rawMeshData, ref draw);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal unsafe static void WireMesh$BurstManaged(float3* verts, int* indices, int vertexCount, int indexCount, ref CommandBuilder draw)
			{
				NativeHashMap<int2, bool> nativeHashMap = new NativeHashMap<int2, bool>(indexCount, Allocator.Temp);
				for (int i = 0; i < indexCount; i += 3)
				{
					int num = indices[i];
					int num2 = indices[i + 1];
					int num3 = indices[i + 2];
					if (num < 0 || num2 < 0 || num3 < 0 || num >= vertexCount || num2 >= vertexCount || num3 >= vertexCount)
					{
						throw new Exception("Invalid vertex index. Index out of bounds");
					}
					int num4 = math.min(num, num2);
					int num5 = math.max(num, num2);
					if (!nativeHashMap.ContainsKey(new int2(num4, num5)))
					{
						nativeHashMap.Add(new int2(num4, num5), item: true);
						draw.Line(verts[num4], verts[num5]);
					}
					num4 = math.min(num2, num3);
					num5 = math.max(num2, num3);
					if (!nativeHashMap.ContainsKey(new int2(num4, num5)))
					{
						nativeHashMap.Add(new int2(num4, num5), item: true);
						draw.Line(verts[num4], verts[num5]);
					}
					num4 = math.min(num3, num);
					num5 = math.max(num3, num);
					if (!nativeHashMap.ContainsKey(new int2(num4, num5)))
					{
						nativeHashMap.Add(new int2(num4, num5), item: true);
						draw.Line(verts[num4], verts[num5]);
					}
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[MonoPInvokeCallback(typeof(JobWireMeshDelegate))]
			internal unsafe static void Execute$BurstManaged(ref Mesh.MeshData rawMeshData, ref CommandBuilder draw)
			{
				int num = 0;
				for (int i = 0; i < rawMeshData.subMeshCount; i++)
				{
					num = math.max(num, rawMeshData.GetSubMesh(i).indexCount);
				}
				NativeArray<int> nativeArray = new NativeArray<int>(num, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				NativeArray<Vector3> nativeArray2 = new NativeArray<Vector3>(rawMeshData.vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				rawMeshData.GetVertices(nativeArray2);
				for (int j = 0; j < rawMeshData.subMeshCount; j++)
				{
					SubMeshDescriptor subMesh = rawMeshData.GetSubMesh(j);
					rawMeshData.GetIndices(nativeArray, j);
					WireMesh((float3*)nativeArray2.GetUnsafeReadOnlyPtr(), (int*)nativeArray.GetUnsafeReadOnlyPtr(), nativeArray2.Length, subMesh.indexCount, ref draw);
				}
			}
		}

		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeAppendBuffer* buffer;

		private GCHandle gizmos;

		[NativeSetThreadIndex]
		private int threadIndex;

		private DrawingData.BuilderData.BitPackedMeta uniqueID;

		private static readonly float3 DEFAULT_UP;

		internal static readonly float4x4 XZtoXYPlaneMatrix;

		internal static readonly float4x4 XZtoYZPlaneMatrix;

		internal unsafe int BufferSize
		{
			get
			{
				return buffer->Length;
			}
			set
			{
				buffer->Length = value;
			}
		}

		public CommandBuilder2D xy => new CommandBuilder2D(this, xy: true);

		public CommandBuilder2D xz => new CommandBuilder2D(this, xy: false);

		public Camera[] cameraTargets
		{
			get
			{
				if (gizmos.IsAllocated && gizmos.Target != null)
				{
					DrawingData drawingData = gizmos.Target as DrawingData;
					if (drawingData.data.StillExists(uniqueID))
					{
						return drawingData.data.Get(uniqueID).meta.cameraTargets;
					}
				}
				throw new Exception("Cannot get cameraTargets because the command builder has already been disposed or does not exist.");
			}
			set
			{
				if (uniqueID.isBuiltInCommandBuilder)
				{
					throw new Exception("You cannot set the camera targets for a built-in command builder. Create a custom command builder instead.");
				}
				if (gizmos.IsAllocated && gizmos.Target != null)
				{
					DrawingData obj = gizmos.Target as DrawingData;
					if (!obj.data.StillExists(uniqueID))
					{
						throw new Exception("Cannot set cameraTargets because the command builder has already been disposed or does not exist.");
					}
					obj.data.Get(uniqueID).meta.cameraTargets = value;
				}
			}
		}

		internal unsafe CommandBuilder(UnsafeAppendBuffer* buffer, GCHandle gizmos, int threadIndex, DrawingData.BuilderData.BitPackedMeta uniqueID)
		{
			this.buffer = buffer;
			this.gizmos = gizmos;
			this.threadIndex = threadIndex;
			this.uniqueID = uniqueID;
		}

		internal unsafe CommandBuilder(DrawingData gizmos, DrawingData.Hasher hasher, RedrawScope frameRedrawScope, RedrawScope customRedrawScope, bool isGizmos, bool isBuiltInCommandBuilder, int sceneModeVersion)
		{
			this.gizmos = GCHandle.Alloc(gizmos, GCHandleType.Normal);
			threadIndex = 0;
			uniqueID = gizmos.data.Reserve(isBuiltInCommandBuilder);
			gizmos.data.Get(uniqueID).Init(hasher, frameRedrawScope, customRedrawScope, isGizmos, gizmos.GetNextDrawOrderIndex(), sceneModeVersion);
			buffer = gizmos.data.Get(uniqueID).bufferPtr;
		}

		public void Dispose()
		{
			if (uniqueID.isBuiltInCommandBuilder)
			{
				throw new Exception("You cannot dispose a built-in command builder");
			}
			DisposeInternal();
		}

		public void DisposeAfter(JobHandle dependency, AllowedDelay allowedDelay = AllowedDelay.EndOfFrame)
		{
			if (!gizmos.IsAllocated)
			{
				throw new Exception("You cannot dispose an invalid command builder. Are you trying to dispose it twice?");
			}
			try
			{
				if (gizmos.IsAllocated && gizmos.Target != null)
				{
					DrawingData obj = gizmos.Target as DrawingData;
					if (!obj.data.StillExists(uniqueID))
					{
						throw new Exception("Cannot dispose the command builder because the drawing manager has been destroyed");
					}
					obj.data.Get(uniqueID).SubmitWithDependency(gizmos, dependency, allowedDelay);
				}
			}
			finally
			{
				this = default(CommandBuilder);
			}
		}

		internal void DisposeInternal()
		{
			if (!gizmos.IsAllocated)
			{
				throw new Exception("You cannot dispose an invalid command builder. Are you trying to dispose it twice?");
			}
			try
			{
				if (gizmos.IsAllocated && gizmos.Target != null)
				{
					DrawingData obj = gizmos.Target as DrawingData;
					if (!obj.data.StillExists(uniqueID))
					{
						throw new Exception("Cannot dispose the command builder because the drawing manager has been destroyed");
					}
					obj.data.Get(uniqueID).Submit(gizmos.Target as DrawingData);
				}
			}
			finally
			{
				gizmos.Free();
				this = default(CommandBuilder);
			}
		}

		public void DiscardAndDispose()
		{
			if (uniqueID.isBuiltInCommandBuilder)
			{
				throw new Exception("You cannot dispose a built-in command builder");
			}
			DiscardAndDisposeInternal();
		}

		internal void DiscardAndDisposeInternal()
		{
			try
			{
				if (gizmos.IsAllocated && gizmos.Target != null)
				{
					DrawingData obj = gizmos.Target as DrawingData;
					if (!obj.data.StillExists(uniqueID))
					{
						throw new Exception("Cannot dispose the command builder because the drawing manager has been destroyed");
					}
					obj.data.Release(uniqueID);
				}
			}
			finally
			{
				if (gizmos.IsAllocated)
				{
					gizmos.Free();
				}
				this = default(CommandBuilder);
			}
		}

		public void Preallocate(int size)
		{
			Reserve(size);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void Reserve(int additionalSpace)
		{
			if (Hint.Unlikely(threadIndex >= 0))
			{
				buffer += threadIndex;
				threadIndex = -1;
			}
			int num = buffer->Length + additionalSpace;
			if (num > buffer->Capacity)
			{
				buffer->SetCapacity(math.max(num, buffer->Length * 2));
			}
		}

		[BurstDiscard]
		private void AssertBufferExists()
		{
			if (!gizmos.IsAllocated || gizmos.Target == null || !(gizmos.Target as DrawingData).data.StillExists(uniqueID))
			{
				this = default(CommandBuilder);
				throw new Exception("This command builder no longer exists. Are you trying to draw to a command builder which has already been disposed?");
			}
		}

		[BurstDiscard]
		private static void AssertNotRendering()
		{
			if (!GizmoContext.drawingGizmos && !JobsUtility.IsExecutingJob && (Time.renderedFrameCount & 0x7F) == 0 && StackTraceUtility.ExtractStackTrace().Contains("OnDrawGizmos"))
			{
				throw new Exception("You are trying to use Draw.* functions from within Unity's OnDrawGizmos function. Use this package's gizmo callbacks instead (see the documentation).");
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Reserve<A>() where A : struct
		{
			Reserve(UnsafeUtility.SizeOf<Command>() + UnsafeUtility.SizeOf<A>());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Reserve<A, B>() where A : struct where B : struct
		{
			Reserve(UnsafeUtility.SizeOf<Command>() * 2 + UnsafeUtility.SizeOf<A>() + UnsafeUtility.SizeOf<B>());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Reserve<A, B, C>() where A : struct where B : struct where C : struct
		{
			Reserve(UnsafeUtility.SizeOf<Command>() * 3 + UnsafeUtility.SizeOf<A>() + UnsafeUtility.SizeOf<B>() + UnsafeUtility.SizeOf<C>());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static uint ConvertColor(Color color)
		{
			if (X86.Sse2.IsSse2Supported)
			{
				int4 int5 = (int4)(255f * new float4(color.r, color.g, color.b, color.a) + 0.5f);
				v128 obj = new v128(int5.x, int5.y, int5.z, int5.w);
				v128 obj2 = X86.Sse2.packs_epi32(obj, obj);
				return X86.Sse2.packus_epi16(obj2, obj2).UInt0;
			}
			uint num = (uint)Mathf.Clamp((int)(color.r * 255f + 0.5f), 0, 255);
			uint num2 = (uint)Mathf.Clamp((int)(color.g * 255f + 0.5f), 0, 255);
			uint num3 = (uint)Mathf.Clamp((int)(color.b * 255f + 0.5f), 0, 255);
			return (uint)(Mathf.Clamp((int)(color.a * 255f + 0.5f), 0, 255) << 24) | (num3 << 16) | (num2 << 8) | num;
		}

		internal unsafe void Add<T>(T value) where T : struct
		{
			int num = UnsafeUtility.SizeOf<T>();
			UnsafeAppendBuffer* ptr = buffer;
			int length = ptr->Length;
			Hint.Assume(ptr->Ptr != null);
			Hint.Assume(ptr->Ptr + length != null);
			UnsafeUtility.CopyStructureToPtr(ref value, ptr->Ptr + length);
			ptr->Length = length + num;
		}

		[BurstDiscard]
		public ScopeMatrix WithMatrix(Matrix4x4 matrix)
		{
			PushMatrix(matrix);
			return new ScopeMatrix
			{
				builder = this
			};
		}

		[BurstDiscard]
		public ScopeMatrix WithMatrix(float3x3 matrix)
		{
			PushMatrix(new float4x4(matrix, float3.zero));
			return new ScopeMatrix
			{
				builder = this
			};
		}

		[BurstDiscard]
		public ScopeColor WithColor(Color color)
		{
			PushColor(color);
			return new ScopeColor
			{
				builder = this
			};
		}

		[BurstDiscard]
		public ScopePersist WithDuration(float duration)
		{
			PushDuration(duration);
			return new ScopePersist
			{
				builder = this
			};
		}

		[BurstDiscard]
		public ScopeLineWidth WithLineWidth(float pixels, bool automaticJoins = true)
		{
			PushLineWidth(pixels, automaticJoins);
			return new ScopeLineWidth
			{
				builder = this
			};
		}

		[BurstDiscard]
		public ScopeMatrix InLocalSpace(Transform transform)
		{
			return WithMatrix(transform.localToWorldMatrix);
		}

		[BurstDiscard]
		public ScopeMatrix InScreenSpace(Camera camera)
		{
			return WithMatrix(camera.cameraToWorldMatrix * camera.nonJitteredProjectionMatrix.inverse * Matrix4x4.TRS(new Vector3(-1f, -1f, 0f), Quaternion.identity, new Vector3(2f / (float)camera.pixelWidth, 2f / (float)camera.pixelHeight, 1f)));
		}

		public void PushMatrix(Matrix4x4 matrix)
		{
			Reserve<float4x4>();
			Add(Command.PushMatrix);
			Add(matrix);
		}

		public void PushMatrix(float4x4 matrix)
		{
			Reserve<float4x4>();
			Add(Command.PushMatrix);
			Add(matrix);
		}

		public void PushSetMatrix(Matrix4x4 matrix)
		{
			Reserve<float4x4>();
			Add(Command.PushSetMatrix);
			Add((float4x4)matrix);
		}

		public void PushSetMatrix(float4x4 matrix)
		{
			Reserve<float4x4>();
			Add(Command.PushSetMatrix);
			Add(matrix);
		}

		public void PopMatrix()
		{
			Reserve(4);
			Add(Command.PopMatrix);
		}

		public void PushColor(Color color)
		{
			Reserve<Color32>();
			Add(Command.PushColor);
			Add(ConvertColor(color));
		}

		public void PopColor()
		{
			Reserve(4);
			Add(Command.PopColor);
		}

		public void PushDuration(float duration)
		{
			Reserve<PersistData>();
			Add(Command.PushPersist);
			Add(new PersistData
			{
				endTime = SharedDrawingData.BurstTime.Data + duration
			});
		}

		public void PopDuration()
		{
			Reserve(4);
			Add(Command.PopPersist);
		}

		[Obsolete("Renamed to PushDuration for consistency")]
		public void PushPersist(float duration)
		{
			PushDuration(duration);
		}

		[Obsolete("Renamed to PopDuration for consistency")]
		public void PopPersist()
		{
			PopDuration();
		}

		public void PushLineWidth(float pixels, bool automaticJoins = true)
		{
			if (pixels < 0f)
			{
				throw new ArgumentOutOfRangeException("pixels", "Line width must be positive");
			}
			Reserve<LineWidthData>();
			Add(Command.PushLineWidth);
			Add(new LineWidthData
			{
				pixels = pixels,
				automaticJoins = automaticJoins
			});
		}

		public void PopLineWidth()
		{
			Reserve(4);
			Add(Command.PopLineWidth);
		}

		public void Line(float3 a, float3 b)
		{
			Reserve<LineData>();
			Add(Command.Line);
			Add(new LineData
			{
				a = a,
				b = b
			});
		}

		public unsafe void Line(Vector3 a, Vector3 b)
		{
			Reserve<LineData>();
			int bufferSize = BufferSize;
			int length = bufferSize + 4 + 24;
			byte* num = buffer->Ptr + bufferSize;
			*(int*)num = 5;
			LineDataV3* ptr = (LineDataV3*)(num + 4);
			ptr->a = a;
			ptr->b = b;
			buffer->Length = length;
		}

		public unsafe void Line(Vector3 a, Vector3 b, Color color)
		{
			Reserve<Color32, LineData>();
			int bufferSize = BufferSize;
			int length = bufferSize + 4 + 24 + 4;
			byte* num = buffer->Ptr + bufferSize;
			*(int*)num = 261;
			((int*)num)[1] = (int)ConvertColor(color);
			LineDataV3* ptr = (LineDataV3*)(num + 8);
			ptr->a = a;
			ptr->b = b;
			buffer->Length = length;
		}

		public void Ray(float3 origin, float3 direction)
		{
			Line(origin, origin + direction);
		}

		public void Ray(Ray ray, float length)
		{
			Line(ray.origin, ray.origin + ray.direction * length);
		}

		public void Arc(float3 center, float3 start, float3 end)
		{
			float3 float5 = start - center;
			float3 float6 = end - center;
			float3 float7 = math.cross(float6, float5);
			if (math.any(float7 != 0f) && math.all(math.isfinite(float7)))
			{
				Matrix4x4 matrix = Matrix4x4.TRS(center, Quaternion.LookRotation(float5, float7), Vector3.one);
				float num = Vector3.SignedAngle(float5, float6, float7) * (MathF.PI / 180f);
				PushMatrix(matrix);
				CircleXZInternal(float3.zero, math.length(float5), MathF.PI / 2f, MathF.PI / 2f - num);
				PopMatrix();
			}
		}

		[Obsolete("Use Draw.xz.Circle instead")]
		public void CircleXZ(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			CircleXZInternal(center, radius, startAngle, endAngle);
		}

		internal void CircleXZInternal(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			Reserve<CircleXZData>();
			Add(Command.CircleXZ);
			Add(new CircleXZData
			{
				center = center,
				radius = radius,
				startAngle = startAngle,
				endAngle = endAngle
			});
		}

		internal void CircleXZInternal(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
			Reserve<Color32, CircleXZData>();
			Add(Command.CircleXZ | Command.PushColorInline);
			Add(ConvertColor(color));
			Add(new CircleXZData
			{
				center = center,
				radius = radius,
				startAngle = startAngle,
				endAngle = endAngle
			});
		}

		[Obsolete("Use Draw.xy.Circle instead")]
		public void CircleXY(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			PushMatrix(XZtoXYPlaneMatrix);
			CircleXZ(new float3(center.x, 0f - center.z, center.y), radius, startAngle, endAngle);
			PopMatrix();
		}

		public void Circle(float3 center, float3 normal, float radius)
		{
			Reserve<CircleData>();
			Add(Command.Circle);
			Add(new CircleData
			{
				center = center,
				normal = normal,
				radius = radius
			});
		}

		public void SolidArc(float3 center, float3 start, float3 end)
		{
			float3 float5 = start - center;
			float3 float6 = end - center;
			float3 float7 = math.cross(float6, float5);
			if (math.any(float7))
			{
				Matrix4x4 matrix = Matrix4x4.TRS(center, Quaternion.LookRotation(float5, float7), Vector3.one);
				float num = Vector3.SignedAngle(float5, float6, float7) * (MathF.PI / 180f);
				PushMatrix(matrix);
				SolidCircleXZInternal(float3.zero, math.length(float5), MathF.PI / 2f, MathF.PI / 2f - num);
				PopMatrix();
			}
		}

		[Obsolete("Use Draw.xz.SolidCircle instead")]
		public void SolidCircleXZ(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			SolidCircleXZInternal(center, radius, startAngle, endAngle);
		}

		internal void SolidCircleXZInternal(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			Reserve<CircleXZData>();
			Add(Command.DiscXZ);
			Add(new CircleXZData
			{
				center = center,
				radius = radius,
				startAngle = startAngle,
				endAngle = endAngle
			});
		}

		internal void SolidCircleXZInternal(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
			Reserve<Color32, CircleXZData>();
			Add(Command.DiscXZ | Command.PushColorInline);
			Add(ConvertColor(color));
			Add(new CircleXZData
			{
				center = center,
				radius = radius,
				startAngle = startAngle,
				endAngle = endAngle
			});
		}

		[Obsolete("Use Draw.xy.SolidCircle instead")]
		public void SolidCircleXY(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			PushMatrix(XZtoXYPlaneMatrix);
			SolidCircleXZInternal(new float3(center.x, 0f - center.z, center.y), radius, startAngle, endAngle);
			PopMatrix();
		}

		public void SolidCircle(float3 center, float3 normal, float radius)
		{
			Reserve<CircleData>();
			Add(Command.Disc);
			Add(new CircleData
			{
				center = center,
				normal = normal,
				radius = radius
			});
		}

		public void SphereOutline(float3 center, float radius)
		{
			Reserve<SphereData>();
			Add(Command.SphereOutline);
			Add(new SphereData
			{
				center = center,
				radius = radius
			});
		}

		public void WireCylinder(float3 bottom, float3 top, float radius)
		{
			WireCylinder(bottom, top - bottom, math.length(top - bottom), radius);
		}

		public void WireCylinder(float3 position, float3 up, float height, float radius)
		{
			up = math.normalizesafe(up);
			if (!math.all(up == 0f) && !math.any(math.isnan(up)) && !math.isnan(height) && !math.isnan(radius))
			{
				OrthonormalBasis(up, out var basis, out var basis2);
				PushMatrix(new float4x4(new float4(basis * radius, 0f), new float4(up * height, 0f), new float4(basis2 * radius, 0f), new float4(position, 1f)));
				CircleXZInternal(float3.zero, 1f);
				if (height > 0f)
				{
					CircleXZInternal(new float3(0f, 1f, 0f), 1f);
					Line(new float3(1f, 0f, 0f), new float3(1f, 1f, 0f));
					Line(new float3(-1f, 0f, 0f), new float3(-1f, 1f, 0f));
					Line(new float3(0f, 0f, 1f), new float3(0f, 1f, 1f));
					Line(new float3(0f, 0f, -1f), new float3(0f, 1f, -1f));
				}
				PopMatrix();
			}
		}

		private static void OrthonormalBasis(float3 normal, out float3 basis1, out float3 basis2)
		{
			basis1 = math.cross(normal, new float3(1f, 1f, 1f));
			if (math.all(basis1 == 0f))
			{
				basis1 = math.cross(normal, new float3(-1f, 1f, 1f));
			}
			basis1 = math.normalizesafe(basis1);
			basis2 = math.cross(normal, basis1);
		}

		public void WireCapsule(float3 start, float3 end, float radius)
		{
			float3 float5 = end - start;
			float num = math.length(float5);
			if ((double)num < 0.0001)
			{
				WireSphere(start, radius);
				return;
			}
			float3 float6 = float5 / num;
			WireCapsule(start - float6 * radius, float6, num + 2f * radius, radius);
		}

		public void WireCapsule(float3 position, float3 direction, float length, float radius)
		{
			direction = math.normalizesafe(direction);
			if (math.all(direction == 0f) || math.any(math.isnan(direction)) || math.isnan(length) || math.isnan(radius))
			{
				return;
			}
			if (radius <= 0f)
			{
				Line(position, position + direction * length);
				return;
			}
			length = math.max(length, radius * 2f);
			OrthonormalBasis(direction, out var basis, out var basis2);
			PushMatrix(new float4x4(new float4(basis, 0f), new float4(direction, 0f), new float4(basis2, 0f), new float4(position, 1f)));
			CircleXZInternal(new float3(0f, radius, 0f), radius);
			PushMatrix(XZtoXYPlaneMatrix);
			CircleXZInternal(new float3(0f, 0f, radius), radius, MathF.PI);
			PopMatrix();
			PushMatrix(XZtoYZPlaneMatrix);
			CircleXZInternal(new float3(radius, 0f, 0f), radius, MathF.PI / 2f, 4.712389f);
			PopMatrix();
			if (length > 0f)
			{
				float num = length - radius;
				CircleXZInternal(new float3(0f, num, 0f), radius);
				PushMatrix(XZtoXYPlaneMatrix);
				CircleXZInternal(new float3(0f, 0f, num), radius, 0f, MathF.PI);
				PopMatrix();
				PushMatrix(XZtoYZPlaneMatrix);
				CircleXZInternal(new float3(num, 0f, 0f), radius, -MathF.PI / 2f, MathF.PI / 2f);
				PopMatrix();
				Line(new float3(radius, radius, 0f), new float3(radius, num, 0f));
				Line(new float3(0f - radius, radius, 0f), new float3(0f - radius, num, 0f));
				Line(new float3(0f, radius, radius), new float3(0f, num, radius));
				Line(new float3(0f, radius, 0f - radius), new float3(0f, num, 0f - radius));
			}
			PopMatrix();
		}

		public void WireSphere(float3 position, float radius)
		{
			SphereOutline(position, radius);
			Circle(position, new float3(1f, 0f, 0f), radius);
			Circle(position, new float3(0f, 1f, 0f), radius);
			Circle(position, new float3(0f, 0f, 1f), radius);
		}

		[BurstDiscard]
		public void Polyline(List<Vector3> points, bool cycle = false)
		{
			for (int i = 0; i < points.Count - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Count > 1)
			{
				Line(points[points.Count - 1], points[0]);
			}
		}

		public void Polyline<T>(T points, bool cycle = false) where T : IReadOnlyList<float3>
		{
			for (int i = 0; i < points.Count - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Count > 1)
			{
				int index = points.Count - 1;
				Line(points[index], points[0]);
			}
		}

		[BurstDiscard]
		public void Polyline(Vector3[] points, bool cycle = false)
		{
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[^1], points[0]);
			}
		}

		[BurstDiscard]
		public void Polyline(float3[] points, bool cycle = false)
		{
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[^1], points[0]);
			}
		}

		public void Polyline(NativeArray<float3> points, bool cycle = false)
		{
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[points.Length - 1], points[0]);
			}
		}

		public void DashedLine(float3 a, float3 b, float dash, float gap)
		{
			PolylineWithSymbol polylineWithSymbol = new PolylineWithSymbol(SymbolDecoration.None, gap, 0f, dash + gap);
			polylineWithSymbol.MoveTo(ref this, a);
			polylineWithSymbol.MoveTo(ref this, b);
		}

		public void DashedPolyline(List<Vector3> points, float dash, float gap)
		{
			PolylineWithSymbol polylineWithSymbol = new PolylineWithSymbol(SymbolDecoration.None, gap, 0f, dash + gap);
			for (int i = 0; i < points.Count; i++)
			{
				polylineWithSymbol.MoveTo(ref this, points[i]);
			}
		}

		public void WireBox(float3 center, float3 size)
		{
			Reserve<BoxData>();
			Add(Command.WireBox);
			Add(new BoxData
			{
				center = center,
				size = size
			});
		}

		public void WireBox(float3 center, quaternion rotation, float3 size)
		{
			PushMatrix(float4x4.TRS(center, rotation, size));
			WireBox(float3.zero, new float3(1f, 1f, 1f));
			PopMatrix();
		}

		public void WireBox(Bounds bounds)
		{
			WireBox(bounds.center, bounds.size);
		}

		public void WireMesh(Mesh mesh)
		{
			if (mesh == null)
			{
				throw new ArgumentNullException();
			}
			Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(mesh);
			Mesh.MeshData rawMeshData = meshDataArray[0];
			JobWireMesh.JobWireMeshFunctionPointer(ref rawMeshData, ref this);
			meshDataArray.Dispose();
		}

		public unsafe void WireMesh(NativeArray<float3> vertices, NativeArray<int> triangles)
		{
			JobWireMesh.WireMesh((float3*)vertices.GetUnsafeReadOnlyPtr(), (int*)triangles.GetUnsafeReadOnlyPtr(), vertices.Length, triangles.Length, ref this);
		}

		public void SolidMesh(Mesh mesh)
		{
			SolidMeshInternal(mesh, temporary: false);
		}

		private void SolidMeshInternal(Mesh mesh, bool temporary, Color color)
		{
			PushColor(color);
			SolidMeshInternal(mesh, temporary);
			PopColor();
		}

		private void SolidMeshInternal(Mesh mesh, bool temporary)
		{
			(gizmos.Target as DrawingData).data.Get(uniqueID).meshes.Add(new DrawingData.SubmittedMesh
			{
				mesh = mesh,
				temporary = temporary
			});
			Reserve(4);
			Add(Command.CaptureState);
		}

		[BurstDiscard]
		public void SolidMesh(List<Vector3> vertices, List<int> triangles, List<Color> colors)
		{
			if (vertices.Count != colors.Count)
			{
				throw new ArgumentException("Number of colors must be the same as the number of vertices");
			}
			Mesh mesh = (gizmos.Target as DrawingData).GetMesh(vertices.Count);
			mesh.Clear();
			mesh.SetVertices(vertices);
			mesh.SetTriangles(triangles, 0);
			mesh.SetColors(colors);
			mesh.UploadMeshData(markNoLongerReadable: false);
			SolidMeshInternal(mesh, temporary: true);
		}

		[BurstDiscard]
		public void SolidMesh(Vector3[] vertices, int[] triangles, Color[] colors, int vertexCount, int indexCount)
		{
			if (vertices.Length != colors.Length)
			{
				throw new ArgumentException("Number of colors must be the same as the number of vertices");
			}
			Mesh mesh = (gizmos.Target as DrawingData).GetMesh(vertices.Length);
			mesh.Clear();
			mesh.SetVertices(vertices, 0, vertexCount);
			mesh.SetTriangles(triangles, 0, indexCount, 0);
			mesh.SetColors(colors, 0, vertexCount);
			mesh.UploadMeshData(markNoLongerReadable: false);
			SolidMeshInternal(mesh, temporary: true);
		}

		public void Cross(float3 position, float size = 1f)
		{
			size *= 0.5f;
			Line(position - new float3(size, 0f, 0f), position + new float3(size, 0f, 0f));
			Line(position - new float3(0f, size, 0f), position + new float3(0f, size, 0f));
			Line(position - new float3(0f, 0f, size), position + new float3(0f, 0f, size));
		}

		[Obsolete("Use Draw.xz.Cross instead")]
		public void CrossXZ(float3 position, float size = 1f)
		{
			size *= 0.5f;
			Line(position - new float3(size, 0f, 0f), position + new float3(size, 0f, 0f));
			Line(position - new float3(0f, 0f, size), position + new float3(0f, 0f, size));
		}

		[Obsolete("Use Draw.xy.Cross instead")]
		public void CrossXY(float3 position, float size = 1f)
		{
			size *= 0.5f;
			Line(position - new float3(size, 0f, 0f), position + new float3(size, 0f, 0f));
			Line(position - new float3(0f, size, 0f), position + new float3(0f, size, 0f));
		}

		public static float3 EvaluateCubicBezier(float3 p0, float3 p1, float3 p2, float3 p3, float t)
		{
			t = math.clamp(t, 0f, 1f);
			float num = 1f - t;
			return num * num * num * p0 + 3f * num * num * t * p1 + 3f * num * t * t * p2 + t * t * t * p3;
		}

		public void Bezier(float3 p0, float3 p1, float3 p2, float3 p3)
		{
			float3 a = p0;
			for (int i = 1; i <= 20; i++)
			{
				float t = (float)i / 20f;
				float3 float5 = EvaluateCubicBezier(p0, p1, p2, p3, t);
				Line(a, float5);
				a = float5;
			}
		}

		public void CatmullRom(List<Vector3> points)
		{
			if (points.Count < 2)
			{
				return;
			}
			if (points.Count == 2)
			{
				Line(points[0], points[1]);
				return;
			}
			int count = points.Count;
			CatmullRom(points[0], points[0], points[1], points[2]);
			for (int i = 0; i + 3 < count; i++)
			{
				CatmullRom(points[i], points[i + 1], points[i + 2], points[i + 3]);
			}
			CatmullRom(points[count - 3], points[count - 2], points[count - 1], points[count - 1]);
		}

		public void CatmullRom(float3 p0, float3 p1, float3 p2, float3 p3)
		{
			float3 p4 = (-p0 + 6f * p1 + 1f * p2) * (1f / 6f);
			float3 p5 = (p1 + 6f * p2 - p3) * (1f / 6f);
			Bezier(p1, p4, p5, p2);
		}

		public void Arrow(float3 from, float3 to)
		{
			ArrowRelativeSizeHead(from, to, DEFAULT_UP, 0.2f);
		}

		public void Arrow(float3 from, float3 to, float3 up, float headSize)
		{
			float num = math.lengthsq(to - from);
			if (num > 1E-06f)
			{
				ArrowRelativeSizeHead(from, to, up, headSize * math.rsqrt(num));
			}
		}

		public void ArrowRelativeSizeHead(float3 from, float3 to, float3 up, float headFraction)
		{
			Line(from, to);
			float3 float5 = to - from;
			float3 float6 = math.cross(float5, up);
			if (math.all(float6 == 0f))
			{
				float6 = math.cross(new float3(1f, 0f, 0f), float5);
			}
			if (math.all(float6 == 0f))
			{
				float6 = math.cross(new float3(0f, 1f, 0f), float5);
			}
			float6 = math.normalizesafe(float6) * math.length(float5);
			Line(to, to - (float5 + float6) * headFraction);
			Line(to, to - (float5 - float6) * headFraction);
		}

		public void Arrowhead(float3 center, float3 direction, float radius)
		{
			Arrowhead(center, direction, DEFAULT_UP, radius);
		}

		public void Arrowhead(float3 center, float3 direction, float3 up, float radius)
		{
			if (!math.all(direction == 0f))
			{
				direction = math.normalizesafe(direction);
				float3 float5 = math.cross(direction, up);
				float3 float6 = center - radius * 0.5f * 0.5f * direction;
				float3 float7 = float6 + radius * direction;
				float3 float8 = float6 - radius * 0.5f * direction + radius * 0.866025f * float5;
				float3 float9 = float6 - radius * 0.5f * direction - radius * 0.866025f * float5;
				Line(float7, float8);
				Line(float8, float6);
				Line(float6, float9);
				Line(float9, float7);
			}
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, float width = 60f)
		{
			if (math.any(direction))
			{
				if (offset < 0f)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (offset != 0f)
				{
					Quaternion q = Quaternion.LookRotation(direction, DEFAULT_UP);
					PushMatrix(Matrix4x4.TRS(origin, q, Vector3.one));
					float num = MathF.PI / 2f - width * (MathF.PI / 360f);
					float num2 = MathF.PI / 2f + width * (MathF.PI / 360f);
					CircleXZInternal(float3.zero, offset, num, num2);
					float3 a = new float3(math.cos(num), 0f, math.sin(num)) * offset;
					float3 b = new float3(math.cos(num2), 0f, math.sin(num2)) * offset;
					float3 float5 = new float3(0f, 0f, 1.4142f * offset);
					Line(a, float5);
					Line(float5, b);
					PopMatrix();
				}
			}
		}

		public void WireGrid(float3 center, quaternion rotation, int2 cells, float2 totalSize)
		{
			cells = math.max(cells, new int2(1, 1));
			PushMatrix(float4x4.TRS(center, rotation, new Vector3(totalSize.x, 0f, totalSize.y)));
			int x = cells.x;
			int y = cells.y;
			for (int i = 0; i <= x; i++)
			{
				Line(new float3((float)i / (float)x - 0.5f, 0f, -0.5f), new float3((float)i / (float)x - 0.5f, 0f, 0.5f));
			}
			for (int j = 0; j <= y; j++)
			{
				Line(new float3(-0.5f, 0f, (float)j / (float)y - 0.5f), new float3(0.5f, 0f, (float)j / (float)y - 0.5f));
			}
			PopMatrix();
		}

		public void WireTriangle(float3 a, float3 b, float3 c)
		{
			Line(a, b);
			Line(b, c);
			Line(c, a);
		}

		[Obsolete("Use Draw.xz.WireRectangle instead")]
		public void WireRectangleXZ(float3 center, float2 size)
		{
			WireRectangle(center, quaternion.identity, size);
		}

		public void WireRectangle(float3 center, quaternion rotation, float2 size)
		{
			WirePlane(center, rotation, size);
		}

		[Obsolete("Use Draw.xy.WireRectangle instead")]
		public void WireRectangle(Rect rect)
		{
			xy.WireRectangle(rect);
		}

		public void WireTriangle(float3 center, quaternion rotation, float radius)
		{
			WirePolygon(center, 3, rotation, radius);
		}

		public void WirePentagon(float3 center, quaternion rotation, float radius)
		{
			WirePolygon(center, 5, rotation, radius);
		}

		public void WireHexagon(float3 center, quaternion rotation, float radius)
		{
			WirePolygon(center, 6, rotation, radius);
		}

		public void WirePolygon(float3 center, int vertices, quaternion rotation, float radius)
		{
			PushMatrix(float4x4.TRS(center, rotation, new float3(radius, radius, radius)));
			float3 a = new float3(0f, 0f, 1f);
			for (int i = 1; i <= vertices; i++)
			{
				float x = MathF.PI * 2f * ((float)i / (float)vertices);
				float3 float5 = new float3(math.sin(x), 0f, math.cos(x));
				Line(a, float5);
				a = float5;
			}
			PopMatrix();
		}

		[Obsolete("Use Draw.xy.SolidRectangle instead")]
		public void SolidRectangle(Rect rect)
		{
			xy.SolidRectangle(rect);
		}

		public void SolidPlane(float3 center, float3 normal, float2 size)
		{
			if (math.any(normal))
			{
				SolidPlane(center, Quaternion.LookRotation(calculateTangent(normal), normal), size);
			}
		}

		public void SolidPlane(float3 center, quaternion rotation, float2 size)
		{
			PushMatrix(float4x4.TRS(center, rotation, new float3(size.x, 0f, size.y)));
			Reserve<BoxData>();
			Add(Command.Box);
			Add(new BoxData
			{
				center = 0,
				size = 1
			});
			PopMatrix();
		}

		private static float3 calculateTangent(float3 normal)
		{
			float3 float5 = math.cross(new float3(0f, 1f, 0f), normal);
			if (math.all(float5 == 0f))
			{
				float5 = math.cross(new float3(1f, 0f, 0f), normal);
			}
			return float5;
		}

		public void WirePlane(float3 center, float3 normal, float2 size)
		{
			if (math.any(normal))
			{
				WirePlane(center, Quaternion.LookRotation(calculateTangent(normal), normal), size);
			}
		}

		public void WirePlane(float3 center, quaternion rotation, float2 size)
		{
			Reserve<PlaneData>();
			Add(Command.WirePlane);
			Add(new PlaneData
			{
				center = center,
				rotation = rotation,
				size = size
			});
		}

		public void PlaneWithNormal(float3 center, float3 normal, float2 size)
		{
			if (math.any(normal))
			{
				PlaneWithNormal(center, Quaternion.LookRotation(calculateTangent(normal), normal), size);
			}
		}

		public void PlaneWithNormal(float3 center, quaternion rotation, float2 size)
		{
			SolidPlane(center, rotation, size);
			WirePlane(center, rotation, size);
			ArrowRelativeSizeHead(center, center + math.mul(rotation, new float3(0f, 1f, 0f)) * 0.5f, math.mul(rotation, new float3(0f, 0f, 1f)), 0.2f);
		}

		public void SolidTriangle(float3 a, float3 b, float3 c)
		{
			Reserve<TriangleData>();
			Add(Command.SolidTriangle);
			Add(new TriangleData
			{
				a = a,
				b = b,
				c = c
			});
		}

		public void SolidBox(float3 center, float3 size)
		{
			Reserve<BoxData>();
			Add(Command.Box);
			Add(new BoxData
			{
				center = center,
				size = size
			});
		}

		public void SolidBox(Bounds bounds)
		{
			SolidBox(bounds.center, bounds.size);
		}

		public void SolidBox(float3 center, quaternion rotation, float3 size)
		{
			PushMatrix(float4x4.TRS(center, rotation, size));
			SolidBox(float3.zero, Vector3.one);
			PopMatrix();
		}

		public void Label3D(float3 position, quaternion rotation, string text, float size)
		{
			Label3D(position, rotation, text, size, LabelAlignment.MiddleLeft);
		}

		public void Label3D(float3 position, quaternion rotation, string text, float size, LabelAlignment alignment)
		{
			AssertBufferExists();
			DrawingData drawingData = gizmos.Target as DrawingData;
			Reserve<TextData3D>();
			Add(Command.Text3D);
			Add(new TextData3D
			{
				center = position,
				rotation = rotation,
				numCharacters = text.Length,
				size = size,
				alignment = alignment
			});
			Reserve(UnsafeUtility.SizeOf<ushort>() * text.Length);
			foreach (char c in text)
			{
				ushort value = (ushort)drawingData.fontData.GetIndex(c);
				Add(value);
			}
		}

		public void Label2D(float3 position, string text, float sizeInPixels = 14f)
		{
			Label2D(position, text, sizeInPixels, LabelAlignment.MiddleLeft);
		}

		public void Label2D(float3 position, string text, float sizeInPixels, LabelAlignment alignment)
		{
			AssertBufferExists();
			DrawingData drawingData = gizmos.Target as DrawingData;
			Reserve<TextData>();
			Add(Command.Text);
			Add(new TextData
			{
				center = position,
				numCharacters = text.Length,
				sizeInPixels = sizeInPixels,
				alignment = alignment
			});
			Reserve(UnsafeUtility.SizeOf<ushort>() * text.Length);
			foreach (char c in text)
			{
				ushort value = (ushort)drawingData.fontData.GetIndex(c);
				Add(value);
			}
		}

		public void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels = 14f)
		{
			Label2D(position, ref text, sizeInPixels, LabelAlignment.MiddleLeft);
		}

		public void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels = 14f)
		{
			Label2D(position, ref text, sizeInPixels, LabelAlignment.MiddleLeft);
		}

		public void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels = 14f)
		{
			Label2D(position, ref text, sizeInPixels, LabelAlignment.MiddleLeft);
		}

		public void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels = 14f)
		{
			Label2D(position, ref text, sizeInPixels, LabelAlignment.MiddleLeft);
		}

		public unsafe void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
			Label2D(position, text.GetUnsafePtr(), text.Length, sizeInPixels, alignment);
		}

		public unsafe void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
			Label2D(position, text.GetUnsafePtr(), text.Length, sizeInPixels, alignment);
		}

		public unsafe void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
			Label2D(position, text.GetUnsafePtr(), text.Length, sizeInPixels, alignment);
		}

		public unsafe void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
			Label2D(position, text.GetUnsafePtr(), text.Length, sizeInPixels, alignment);
		}

		internal unsafe void Label2D(float3 position, byte* text, int byteCount, float sizeInPixels, LabelAlignment alignment)
		{
			AssertBufferExists();
			Reserve<TextData>();
			Add(Command.Text);
			Add(new TextData
			{
				center = position,
				numCharacters = byteCount,
				sizeInPixels = sizeInPixels,
				alignment = alignment
			});
			Reserve(UnsafeUtility.SizeOf<ushort>() * byteCount);
			for (int i = 0; i < byteCount; i++)
			{
				ushort num = text[i];
				if (num >= 128)
				{
					num = 63;
				}
				if (num == 10)
				{
					num = ushort.MaxValue;
				}
				if (num != 13)
				{
					Add(num);
				}
			}
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString32Bytes text, float size)
		{
			Label3D(position, rotation, ref text, size, LabelAlignment.MiddleLeft);
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString64Bytes text, float size)
		{
			Label3D(position, rotation, ref text, size, LabelAlignment.MiddleLeft);
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString128Bytes text, float size)
		{
			Label3D(position, rotation, ref text, size, LabelAlignment.MiddleLeft);
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString512Bytes text, float size)
		{
			Label3D(position, rotation, ref text, size, LabelAlignment.MiddleLeft);
		}

		public unsafe void Label3D(float3 position, quaternion rotation, ref FixedString32Bytes text, float size, LabelAlignment alignment)
		{
			Label3D(position, rotation, text.GetUnsafePtr(), text.Length, size, alignment);
		}

		public unsafe void Label3D(float3 position, quaternion rotation, ref FixedString64Bytes text, float size, LabelAlignment alignment)
		{
			Label3D(position, rotation, text.GetUnsafePtr(), text.Length, size, alignment);
		}

		public unsafe void Label3D(float3 position, quaternion rotation, ref FixedString128Bytes text, float size, LabelAlignment alignment)
		{
			Label3D(position, rotation, text.GetUnsafePtr(), text.Length, size, alignment);
		}

		public unsafe void Label3D(float3 position, quaternion rotation, ref FixedString512Bytes text, float size, LabelAlignment alignment)
		{
			Label3D(position, rotation, text.GetUnsafePtr(), text.Length, size, alignment);
		}

		internal unsafe void Label3D(float3 position, quaternion rotation, byte* text, int byteCount, float size, LabelAlignment alignment)
		{
			AssertBufferExists();
			Reserve<TextData3D>();
			Add(Command.Text3D);
			Add(new TextData3D
			{
				center = position,
				rotation = rotation,
				numCharacters = byteCount,
				size = size,
				alignment = alignment
			});
			Reserve(UnsafeUtility.SizeOf<ushort>() * byteCount);
			for (int i = 0; i < byteCount; i++)
			{
				ushort num = text[i];
				if (num >= 128)
				{
					num = 63;
				}
				if (num == 10)
				{
					num = ushort.MaxValue;
				}
				Add(num);
			}
		}

		public void Line(float3 a, float3 b, Color color)
		{
			Reserve<Color32, LineData>();
			Add(Command.Line | Command.PushColorInline);
			Add(ConvertColor(color));
			Add(new LineData
			{
				a = a,
				b = b
			});
		}

		public void Ray(float3 origin, float3 direction, Color color)
		{
			Line(origin, origin + direction, color);
		}

		public void Ray(Ray ray, float length, Color color)
		{
			Line(ray.origin, ray.origin + ray.direction * length, color);
		}

		public void Arc(float3 center, float3 start, float3 end, Color color)
		{
			PushColor(color);
			float3 float5 = start - center;
			float3 float6 = end - center;
			float3 float7 = math.cross(float6, float5);
			if (math.any(float7 != 0f) && math.all(math.isfinite(float7)))
			{
				Matrix4x4 matrix = Matrix4x4.TRS(center, Quaternion.LookRotation(float5, float7), Vector3.one);
				float num = Vector3.SignedAngle(float5, float6, float7) * (MathF.PI / 180f);
				PushMatrix(matrix);
				CircleXZInternal(float3.zero, math.length(float5), MathF.PI / 2f, MathF.PI / 2f - num);
				PopMatrix();
			}
			PopColor();
		}

		[Obsolete("Use Draw.xz.Circle instead")]
		public void CircleXZ(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
			CircleXZInternal(center, radius, startAngle, endAngle, color);
		}

		[Obsolete("Use Draw.xz.Circle instead")]
		public void CircleXZ(float3 center, float radius, Color color)
		{
			CircleXZ(center, radius, 0f, MathF.PI * 2f, color);
		}

		[Obsolete("Use Draw.xy.Circle instead")]
		public void CircleXY(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
			PushColor(color);
			PushMatrix(XZtoXYPlaneMatrix);
			CircleXZ(new float3(center.x, 0f - center.z, center.y), radius, startAngle, endAngle);
			PopMatrix();
			PopColor();
		}

		[Obsolete("Use Draw.xy.Circle instead")]
		public void CircleXY(float3 center, float radius, Color color)
		{
			CircleXY(center, radius, 0f, MathF.PI * 2f, color);
		}

		public void Circle(float3 center, float3 normal, float radius, Color color)
		{
			Reserve<Color32, CircleData>();
			Add(Command.Circle | Command.PushColorInline);
			Add(ConvertColor(color));
			Add(new CircleData
			{
				center = center,
				normal = normal,
				radius = radius
			});
		}

		public void SolidArc(float3 center, float3 start, float3 end, Color color)
		{
			PushColor(color);
			float3 float5 = start - center;
			float3 float6 = end - center;
			float3 float7 = math.cross(float6, float5);
			if (math.any(float7))
			{
				Matrix4x4 matrix = Matrix4x4.TRS(center, Quaternion.LookRotation(float5, float7), Vector3.one);
				float num = Vector3.SignedAngle(float5, float6, float7) * (MathF.PI / 180f);
				PushMatrix(matrix);
				SolidCircleXZInternal(float3.zero, math.length(float5), MathF.PI / 2f, MathF.PI / 2f - num);
				PopMatrix();
			}
			PopColor();
		}

		[Obsolete("Use Draw.xz.SolidCircle instead")]
		public void SolidCircleXZ(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
			SolidCircleXZInternal(center, radius, startAngle, endAngle, color);
		}

		[Obsolete("Use Draw.xz.SolidCircle instead")]
		public void SolidCircleXZ(float3 center, float radius, Color color)
		{
			SolidCircleXZ(center, radius, 0f, MathF.PI * 2f, color);
		}

		[Obsolete("Use Draw.xy.SolidCircle instead")]
		public void SolidCircleXY(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
			PushColor(color);
			PushMatrix(XZtoXYPlaneMatrix);
			SolidCircleXZInternal(new float3(center.x, 0f - center.z, center.y), radius, startAngle, endAngle);
			PopMatrix();
			PopColor();
		}

		[Obsolete("Use Draw.xy.SolidCircle instead")]
		public void SolidCircleXY(float3 center, float radius, Color color)
		{
			SolidCircleXY(center, radius, 0f, MathF.PI * 2f, color);
		}

		public void SolidCircle(float3 center, float3 normal, float radius, Color color)
		{
			Reserve<Color32, CircleData>();
			Add(Command.PushColorInline | Command.Disc);
			Add(ConvertColor(color));
			Add(new CircleData
			{
				center = center,
				normal = normal,
				radius = radius
			});
		}

		public void SphereOutline(float3 center, float radius, Color color)
		{
			Reserve<Color32, SphereData>();
			Add(Command.SphereOutline | Command.PushColorInline);
			Add(ConvertColor(color));
			Add(new SphereData
			{
				center = center,
				radius = radius
			});
		}

		public void WireCylinder(float3 bottom, float3 top, float radius, Color color)
		{
			WireCylinder(bottom, top - bottom, math.length(top - bottom), radius, color);
		}

		public void WireCylinder(float3 position, float3 up, float height, float radius, Color color)
		{
			up = math.normalizesafe(up);
			if (!math.all(up == 0f) && !math.any(math.isnan(up)) && !math.isnan(height) && !math.isnan(radius))
			{
				PushColor(color);
				OrthonormalBasis(up, out var basis, out var basis2);
				PushMatrix(new float4x4(new float4(basis * radius, 0f), new float4(up * height, 0f), new float4(basis2 * radius, 0f), new float4(position, 1f)));
				CircleXZInternal(float3.zero, 1f);
				if (height > 0f)
				{
					CircleXZInternal(new float3(0f, 1f, 0f), 1f);
					Line(new float3(1f, 0f, 0f), new float3(1f, 1f, 0f));
					Line(new float3(-1f, 0f, 0f), new float3(-1f, 1f, 0f));
					Line(new float3(0f, 0f, 1f), new float3(0f, 1f, 1f));
					Line(new float3(0f, 0f, -1f), new float3(0f, 1f, -1f));
				}
				PopMatrix();
				PopColor();
			}
		}

		public void WireCapsule(float3 start, float3 end, float radius, Color color)
		{
			PushColor(color);
			float3 float5 = end - start;
			float num = math.length(float5);
			if ((double)num < 0.0001)
			{
				WireSphere(start, radius);
			}
			else
			{
				float3 float6 = float5 / num;
				WireCapsule(start - float6 * radius, float6, num + 2f * radius, radius);
			}
			PopColor();
		}

		public void WireCapsule(float3 position, float3 direction, float length, float radius, Color color)
		{
			direction = math.normalizesafe(direction);
			if (math.all(direction == 0f) || math.any(math.isnan(direction)) || math.isnan(length) || math.isnan(radius))
			{
				return;
			}
			PushColor(color);
			if (radius <= 0f)
			{
				Line(position, position + direction * length);
			}
			else
			{
				length = math.max(length, radius * 2f);
				OrthonormalBasis(direction, out var basis, out var basis2);
				PushMatrix(new float4x4(new float4(basis, 0f), new float4(direction, 0f), new float4(basis2, 0f), new float4(position, 1f)));
				CircleXZInternal(new float3(0f, radius, 0f), radius);
				PushMatrix(XZtoXYPlaneMatrix);
				CircleXZInternal(new float3(0f, 0f, radius), radius, MathF.PI);
				PopMatrix();
				PushMatrix(XZtoYZPlaneMatrix);
				CircleXZInternal(new float3(radius, 0f, 0f), radius, MathF.PI / 2f, 4.712389f);
				PopMatrix();
				if (length > 0f)
				{
					float num = length - radius;
					CircleXZInternal(new float3(0f, num, 0f), radius);
					PushMatrix(XZtoXYPlaneMatrix);
					CircleXZInternal(new float3(0f, 0f, num), radius, 0f, MathF.PI);
					PopMatrix();
					PushMatrix(XZtoYZPlaneMatrix);
					CircleXZInternal(new float3(num, 0f, 0f), radius, -MathF.PI / 2f, MathF.PI / 2f);
					PopMatrix();
					Line(new float3(radius, radius, 0f), new float3(radius, num, 0f));
					Line(new float3(0f - radius, radius, 0f), new float3(0f - radius, num, 0f));
					Line(new float3(0f, radius, radius), new float3(0f, num, radius));
					Line(new float3(0f, radius, 0f - radius), new float3(0f, num, 0f - radius));
				}
				PopMatrix();
			}
			PopColor();
		}

		public void WireSphere(float3 position, float radius, Color color)
		{
			PushColor(color);
			SphereOutline(position, radius);
			Circle(position, new float3(1f, 0f, 0f), radius);
			Circle(position, new float3(0f, 1f, 0f), radius);
			Circle(position, new float3(0f, 0f, 1f), radius);
			PopColor();
		}

		[BurstDiscard]
		public void Polyline(List<Vector3> points, bool cycle, Color color)
		{
			PushColor(color);
			for (int i = 0; i < points.Count - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Count > 1)
			{
				Line(points[points.Count - 1], points[0]);
			}
			PopColor();
		}

		[BurstDiscard]
		public void Polyline(List<Vector3> points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		[BurstDiscard]
		public void Polyline(Vector3[] points, bool cycle, Color color)
		{
			PushColor(color);
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[^1], points[0]);
			}
			PopColor();
		}

		[BurstDiscard]
		public void Polyline(Vector3[] points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		[BurstDiscard]
		public void Polyline(float3[] points, bool cycle, Color color)
		{
			PushColor(color);
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[^1], points[0]);
			}
			PopColor();
		}

		[BurstDiscard]
		public void Polyline(float3[] points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		public void Polyline(NativeArray<float3> points, bool cycle, Color color)
		{
			PushColor(color);
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[points.Length - 1], points[0]);
			}
			PopColor();
		}

		public void Polyline(NativeArray<float3> points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		public void DashedLine(float3 a, float3 b, float dash, float gap, Color color)
		{
			PushColor(color);
			PolylineWithSymbol polylineWithSymbol = new PolylineWithSymbol(SymbolDecoration.None, gap, 0f, dash + gap);
			polylineWithSymbol.MoveTo(ref this, a);
			polylineWithSymbol.MoveTo(ref this, b);
			PopColor();
		}

		public void DashedPolyline(List<Vector3> points, float dash, float gap, Color color)
		{
			PushColor(color);
			PolylineWithSymbol polylineWithSymbol = new PolylineWithSymbol(SymbolDecoration.None, gap, 0f, dash + gap);
			for (int i = 0; i < points.Count; i++)
			{
				polylineWithSymbol.MoveTo(ref this, points[i]);
			}
			PopColor();
		}

		public void WireBox(float3 center, float3 size, Color color)
		{
			Reserve<Color32, BoxData>();
			Add(Command.WireBox | Command.PushColorInline);
			Add(ConvertColor(color));
			Add(new BoxData
			{
				center = center,
				size = size
			});
		}

		public void WireBox(float3 center, quaternion rotation, float3 size, Color color)
		{
			PushColor(color);
			PushMatrix(float4x4.TRS(center, rotation, size));
			WireBox(float3.zero, new float3(1f, 1f, 1f));
			PopMatrix();
			PopColor();
		}

		public void WireBox(Bounds bounds, Color color)
		{
			WireBox(bounds.center, bounds.size, color);
		}

		public void WireMesh(Mesh mesh, Color color)
		{
			if (mesh == null)
			{
				throw new ArgumentNullException();
			}
			PushColor(color);
			Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(mesh);
			Mesh.MeshData rawMeshData = meshDataArray[0];
			JobWireMesh.JobWireMeshFunctionPointer(ref rawMeshData, ref this);
			meshDataArray.Dispose();
			PopColor();
		}

		public unsafe void WireMesh(NativeArray<float3> vertices, NativeArray<int> triangles, Color color)
		{
			PushColor(color);
			JobWireMesh.WireMesh((float3*)vertices.GetUnsafeReadOnlyPtr(), (int*)triangles.GetUnsafeReadOnlyPtr(), vertices.Length, triangles.Length, ref this);
			PopColor();
		}

		public void SolidMesh(Mesh mesh, Color color)
		{
			SolidMeshInternal(mesh, temporary: false, color);
		}

		public void Cross(float3 position, float size, Color color)
		{
			PushColor(color);
			size *= 0.5f;
			Line(position - new float3(size, 0f, 0f), position + new float3(size, 0f, 0f));
			Line(position - new float3(0f, size, 0f), position + new float3(0f, size, 0f));
			Line(position - new float3(0f, 0f, size), position + new float3(0f, 0f, size));
			PopColor();
		}

		public void Cross(float3 position, Color color)
		{
			Cross(position, 1f, color);
		}

		[Obsolete("Use Draw.xz.Cross instead")]
		public void CrossXZ(float3 position, float size, Color color)
		{
			PushColor(color);
			size *= 0.5f;
			Line(position - new float3(size, 0f, 0f), position + new float3(size, 0f, 0f));
			Line(position - new float3(0f, 0f, size), position + new float3(0f, 0f, size));
			PopColor();
		}

		[Obsolete("Use Draw.xz.Cross instead")]
		public void CrossXZ(float3 position, Color color)
		{
			CrossXZ(position, 1f, color);
		}

		[Obsolete("Use Draw.xy.Cross instead")]
		public void CrossXY(float3 position, float size, Color color)
		{
			PushColor(color);
			size *= 0.5f;
			Line(position - new float3(size, 0f, 0f), position + new float3(size, 0f, 0f));
			Line(position - new float3(0f, size, 0f), position + new float3(0f, size, 0f));
			PopColor();
		}

		[Obsolete("Use Draw.xy.Cross instead")]
		public void CrossXY(float3 position, Color color)
		{
			CrossXY(position, 1f, color);
		}

		public void Bezier(float3 p0, float3 p1, float3 p2, float3 p3, Color color)
		{
			PushColor(color);
			float3 a = p0;
			for (int i = 1; i <= 20; i++)
			{
				float t = (float)i / 20f;
				float3 float5 = EvaluateCubicBezier(p0, p1, p2, p3, t);
				Line(a, float5);
				a = float5;
			}
			PopColor();
		}

		public void CatmullRom(List<Vector3> points, Color color)
		{
			if (points.Count < 2)
			{
				return;
			}
			PushColor(color);
			if (points.Count == 2)
			{
				Line(points[0], points[1]);
			}
			else
			{
				int count = points.Count;
				CatmullRom(points[0], points[0], points[1], points[2]);
				for (int i = 0; i + 3 < count; i++)
				{
					CatmullRom(points[i], points[i + 1], points[i + 2], points[i + 3]);
				}
				CatmullRom(points[count - 3], points[count - 2], points[count - 1], points[count - 1]);
			}
			PopColor();
		}

		public void CatmullRom(float3 p0, float3 p1, float3 p2, float3 p3, Color color)
		{
			PushColor(color);
			float3 p4 = (-p0 + 6f * p1 + 1f * p2) * (1f / 6f);
			float3 p5 = (p1 + 6f * p2 - p3) * (1f / 6f);
			Bezier(p1, p4, p5, p2);
			PopColor();
		}

		public void Arrow(float3 from, float3 to, Color color)
		{
			ArrowRelativeSizeHead(from, to, DEFAULT_UP, 0.2f, color);
		}

		public void Arrow(float3 from, float3 to, float3 up, float headSize, Color color)
		{
			PushColor(color);
			float num = math.lengthsq(to - from);
			if (num > 1E-06f)
			{
				ArrowRelativeSizeHead(from, to, up, headSize * math.rsqrt(num));
			}
			PopColor();
		}

		public void ArrowRelativeSizeHead(float3 from, float3 to, float3 up, float headFraction, Color color)
		{
			PushColor(color);
			Line(from, to);
			float3 float5 = to - from;
			float3 float6 = math.cross(float5, up);
			if (math.all(float6 == 0f))
			{
				float6 = math.cross(new float3(1f, 0f, 0f), float5);
			}
			if (math.all(float6 == 0f))
			{
				float6 = math.cross(new float3(0f, 1f, 0f), float5);
			}
			float6 = math.normalizesafe(float6) * math.length(float5);
			Line(to, to - (float5 + float6) * headFraction);
			Line(to, to - (float5 - float6) * headFraction);
			PopColor();
		}

		public void Arrowhead(float3 center, float3 direction, float radius, Color color)
		{
			Arrowhead(center, direction, DEFAULT_UP, radius, color);
		}

		public void Arrowhead(float3 center, float3 direction, float3 up, float radius, Color color)
		{
			if (!math.all(direction == 0f))
			{
				PushColor(color);
				direction = math.normalizesafe(direction);
				float3 float5 = math.cross(direction, up);
				float3 float6 = center - radius * 0.5f * 0.5f * direction;
				float3 float7 = float6 + radius * direction;
				float3 float8 = float6 - radius * 0.5f * direction + radius * 0.866025f * float5;
				float3 float9 = float6 - radius * 0.5f * direction - radius * 0.866025f * float5;
				Line(float7, float8);
				Line(float8, float6);
				Line(float6, float9);
				Line(float9, float7);
				PopColor();
			}
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, float width, Color color)
		{
			if (math.any(direction))
			{
				if (offset < 0f)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (offset != 0f)
				{
					PushColor(color);
					Quaternion q = Quaternion.LookRotation(direction, DEFAULT_UP);
					PushMatrix(Matrix4x4.TRS(origin, q, Vector3.one));
					float num = MathF.PI / 2f - width * (MathF.PI / 360f);
					float num2 = MathF.PI / 2f + width * (MathF.PI / 360f);
					CircleXZInternal(float3.zero, offset, num, num2);
					float3 a = new float3(math.cos(num), 0f, math.sin(num)) * offset;
					float3 b = new float3(math.cos(num2), 0f, math.sin(num2)) * offset;
					float3 float5 = new float3(0f, 0f, 1.4142f * offset);
					Line(a, float5);
					Line(float5, b);
					PopMatrix();
					PopColor();
				}
			}
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, Color color)
		{
			ArrowheadArc(origin, direction, offset, 60f, color);
		}

		public void WireGrid(float3 center, quaternion rotation, int2 cells, float2 totalSize, Color color)
		{
			PushColor(color);
			cells = math.max(cells, new int2(1, 1));
			PushMatrix(float4x4.TRS(center, rotation, new Vector3(totalSize.x, 0f, totalSize.y)));
			int x = cells.x;
			int y = cells.y;
			for (int i = 0; i <= x; i++)
			{
				Line(new float3((float)i / (float)x - 0.5f, 0f, -0.5f), new float3((float)i / (float)x - 0.5f, 0f, 0.5f));
			}
			for (int j = 0; j <= y; j++)
			{
				Line(new float3(-0.5f, 0f, (float)j / (float)y - 0.5f), new float3(0.5f, 0f, (float)j / (float)y - 0.5f));
			}
			PopMatrix();
			PopColor();
		}

		public void WireTriangle(float3 a, float3 b, float3 c, Color color)
		{
			PushColor(color);
			Line(a, b);
			Line(b, c);
			Line(c, a);
			PopColor();
		}

		[Obsolete("Use Draw.xz.WireRectangle instead")]
		public void WireRectangleXZ(float3 center, float2 size, Color color)
		{
			WireRectangle(center, quaternion.identity, size, color);
		}

		public void WireRectangle(float3 center, quaternion rotation, float2 size, Color color)
		{
			WirePlane(center, rotation, size, color);
		}

		[Obsolete("Use Draw.xy.WireRectangle instead")]
		public void WireRectangle(Rect rect, Color color)
		{
			xy.WireRectangle(rect, color);
		}

		public void WireTriangle(float3 center, quaternion rotation, float radius, Color color)
		{
			WirePolygon(center, 3, rotation, radius, color);
		}

		public void WirePentagon(float3 center, quaternion rotation, float radius, Color color)
		{
			WirePolygon(center, 5, rotation, radius, color);
		}

		public void WireHexagon(float3 center, quaternion rotation, float radius, Color color)
		{
			WirePolygon(center, 6, rotation, radius, color);
		}

		public void WirePolygon(float3 center, int vertices, quaternion rotation, float radius, Color color)
		{
			PushColor(color);
			PushMatrix(float4x4.TRS(center, rotation, new float3(radius, radius, radius)));
			float3 a = new float3(0f, 0f, 1f);
			for (int i = 1; i <= vertices; i++)
			{
				float x = MathF.PI * 2f * ((float)i / (float)vertices);
				float3 float5 = new float3(math.sin(x), 0f, math.cos(x));
				Line(a, float5);
				a = float5;
			}
			PopMatrix();
			PopColor();
		}

		[Obsolete("Use Draw.xy.SolidRectangle instead")]
		public void SolidRectangle(Rect rect, Color color)
		{
			xy.SolidRectangle(rect, color);
		}

		public void SolidPlane(float3 center, float3 normal, float2 size, Color color)
		{
			PushColor(color);
			if (math.any(normal))
			{
				SolidPlane(center, Quaternion.LookRotation(calculateTangent(normal), normal), size);
			}
			PopColor();
		}

		public void SolidPlane(float3 center, quaternion rotation, float2 size, Color color)
		{
			PushMatrix(float4x4.TRS(center, rotation, new float3(size.x, 0f, size.y)));
			Reserve<Color32, BoxData>();
			Add(Command.Box | Command.PushColorInline);
			Add(ConvertColor(color));
			Add(new BoxData
			{
				center = 0,
				size = 1
			});
			PopMatrix();
		}

		public void WirePlane(float3 center, float3 normal, float2 size, Color color)
		{
			PushColor(color);
			if (math.any(normal))
			{
				WirePlane(center, Quaternion.LookRotation(calculateTangent(normal), normal), size);
			}
			PopColor();
		}

		public void WirePlane(float3 center, quaternion rotation, float2 size, Color color)
		{
			Reserve<Color32, PlaneData>();
			Add(Command.WirePlane | Command.PushColorInline);
			Add(ConvertColor(color));
			Add(new PlaneData
			{
				center = center,
				rotation = rotation,
				size = size
			});
		}

		public void PlaneWithNormal(float3 center, float3 normal, float2 size, Color color)
		{
			PushColor(color);
			if (math.any(normal))
			{
				PlaneWithNormal(center, Quaternion.LookRotation(calculateTangent(normal), normal), size);
			}
			PopColor();
		}

		public void PlaneWithNormal(float3 center, quaternion rotation, float2 size, Color color)
		{
			PushColor(color);
			SolidPlane(center, rotation, size);
			WirePlane(center, rotation, size);
			ArrowRelativeSizeHead(center, center + math.mul(rotation, new float3(0f, 1f, 0f)) * 0.5f, math.mul(rotation, new float3(0f, 0f, 1f)), 0.2f);
			PopColor();
		}

		public void SolidTriangle(float3 a, float3 b, float3 c, Color color)
		{
			Reserve<Color32, TriangleData>();
			Add(Command.SolidTriangle | Command.PushColorInline);
			Add(ConvertColor(color));
			Add(new TriangleData
			{
				a = a,
				b = b,
				c = c
			});
		}

		public void SolidBox(float3 center, float3 size, Color color)
		{
			Reserve<Color32, BoxData>();
			Add(Command.Box | Command.PushColorInline);
			Add(ConvertColor(color));
			Add(new BoxData
			{
				center = center,
				size = size
			});
		}

		public void SolidBox(Bounds bounds, Color color)
		{
			SolidBox(bounds.center, bounds.size, color);
		}

		public void SolidBox(float3 center, quaternion rotation, float3 size, Color color)
		{
			PushColor(color);
			PushMatrix(float4x4.TRS(center, rotation, size));
			SolidBox(float3.zero, Vector3.one);
			PopMatrix();
			PopColor();
		}

		public void Label3D(float3 position, quaternion rotation, string text, float size, Color color)
		{
			Label3D(position, rotation, text, size, LabelAlignment.MiddleLeft, color);
		}

		public void Label3D(float3 position, quaternion rotation, string text, float size, LabelAlignment alignment, Color color)
		{
			AssertBufferExists();
			DrawingData drawingData = gizmos.Target as DrawingData;
			Reserve<Color32, TextData3D>();
			Add(Command.Text3D | Command.PushColorInline);
			Add(ConvertColor(color));
			Add(new TextData3D
			{
				center = position,
				rotation = rotation,
				numCharacters = text.Length,
				size = size,
				alignment = alignment
			});
			Reserve(UnsafeUtility.SizeOf<ushort>() * text.Length);
			foreach (char c in text)
			{
				ushort value = (ushort)drawingData.fontData.GetIndex(c);
				Add(value);
			}
		}

		public void Label2D(float3 position, string text, float sizeInPixels, Color color)
		{
			Label2D(position, text, sizeInPixels, LabelAlignment.MiddleLeft, color);
		}

		public void Label2D(float3 position, string text, Color color)
		{
			Label2D(position, text, 14f, color);
		}

		public void Label2D(float3 position, string text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			AssertBufferExists();
			DrawingData drawingData = gizmos.Target as DrawingData;
			Reserve<Color32, TextData>();
			Add(Command.Text | Command.PushColorInline);
			Add(ConvertColor(color));
			Add(new TextData
			{
				center = position,
				numCharacters = text.Length,
				sizeInPixels = sizeInPixels,
				alignment = alignment
			});
			Reserve(UnsafeUtility.SizeOf<ushort>() * text.Length);
			foreach (char c in text)
			{
				ushort value = (ushort)drawingData.fontData.GetIndex(c);
				Add(value);
			}
		}

		public void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels, Color color)
		{
			Label2D(position, ref text, sizeInPixels, LabelAlignment.MiddleLeft, color);
		}

		public void Label2D(float3 position, ref FixedString32Bytes text, Color color)
		{
			Label2D(position, ref text, 14f, color);
		}

		public void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels, Color color)
		{
			Label2D(position, ref text, sizeInPixels, LabelAlignment.MiddleLeft, color);
		}

		public void Label2D(float3 position, ref FixedString64Bytes text, Color color)
		{
			Label2D(position, ref text, 14f, color);
		}

		public void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels, Color color)
		{
			Label2D(position, ref text, sizeInPixels, LabelAlignment.MiddleLeft, color);
		}

		public void Label2D(float3 position, ref FixedString128Bytes text, Color color)
		{
			Label2D(position, ref text, 14f, color);
		}

		public void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels, Color color)
		{
			Label2D(position, ref text, sizeInPixels, LabelAlignment.MiddleLeft, color);
		}

		public void Label2D(float3 position, ref FixedString512Bytes text, Color color)
		{
			Label2D(position, ref text, 14f, color);
		}

		public unsafe void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			PushColor(color);
			Label2D(position, text.GetUnsafePtr(), text.Length, sizeInPixels, alignment);
			PopColor();
		}

		public unsafe void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			PushColor(color);
			Label2D(position, text.GetUnsafePtr(), text.Length, sizeInPixels, alignment);
			PopColor();
		}

		public unsafe void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			PushColor(color);
			Label2D(position, text.GetUnsafePtr(), text.Length, sizeInPixels, alignment);
			PopColor();
		}

		public unsafe void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			PushColor(color);
			Label2D(position, text.GetUnsafePtr(), text.Length, sizeInPixels, alignment);
			PopColor();
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString32Bytes text, float size, Color color)
		{
			Label3D(position, rotation, ref text, size, LabelAlignment.MiddleLeft, color);
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString64Bytes text, float size, Color color)
		{
			Label3D(position, rotation, ref text, size, LabelAlignment.MiddleLeft, color);
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString128Bytes text, float size, Color color)
		{
			Label3D(position, rotation, ref text, size, LabelAlignment.MiddleLeft, color);
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString512Bytes text, float size, Color color)
		{
			Label3D(position, rotation, ref text, size, LabelAlignment.MiddleLeft, color);
		}

		public unsafe void Label3D(float3 position, quaternion rotation, ref FixedString32Bytes text, float size, LabelAlignment alignment, Color color)
		{
			PushColor(color);
			Label3D(position, rotation, text.GetUnsafePtr(), text.Length, size, alignment);
			PopColor();
		}

		public unsafe void Label3D(float3 position, quaternion rotation, ref FixedString64Bytes text, float size, LabelAlignment alignment, Color color)
		{
			PushColor(color);
			Label3D(position, rotation, text.GetUnsafePtr(), text.Length, size, alignment);
			PopColor();
		}

		public unsafe void Label3D(float3 position, quaternion rotation, ref FixedString128Bytes text, float size, LabelAlignment alignment, Color color)
		{
			PushColor(color);
			Label3D(position, rotation, text.GetUnsafePtr(), text.Length, size, alignment);
			PopColor();
		}

		public unsafe void Label3D(float3 position, quaternion rotation, ref FixedString512Bytes text, float size, LabelAlignment alignment, Color color)
		{
			PushColor(color);
			Label3D(position, rotation, text.GetUnsafePtr(), text.Length, size, alignment);
			PopColor();
		}

		static CommandBuilder()
		{
			DEFAULT_UP = new float3(0f, 1f, 0f);
			XZtoXYPlaneMatrix = float4x4.RotateX(-MathF.PI / 2f);
			XZtoYZPlaneMatrix = float4x4.RotateZ(MathF.PI / 2f);
		}
	}
	public struct CommandBuilder2D(CommandBuilder draw, bool xy)
	{
		private CommandBuilder draw = draw;

		private bool xy = xy;

		private static readonly float3 XY_UP = new float3(0f, 0f, 1f);

		private static readonly float3 XZ_UP = new float3(0f, 1f, 0f);

		private static readonly quaternion XY_TO_XZ_ROTATION = quaternion.RotateX(-MathF.PI / 2f);

		private static readonly quaternion XZ_TO_XZ_ROTATION = quaternion.identity;

		private static readonly float4x4 XZ_TO_XY_MATRIX = new float4x4(new float4(1f, 0f, 0f, 0f), new float4(0f, 0f, 1f, 0f), new float4(0f, 1f, 0f, 0f), new float4(0f, 0f, 0f, 1f));

		public unsafe void Line(float2 a, float2 b)
		{
			draw.Reserve<CommandBuilder.LineData>();
			UnsafeAppendBuffer* buffer = draw.buffer;
			int length = buffer->Length;
			int length2 = length + 4 + 24;
			byte* num = buffer->Ptr + length;
			*(int*)num = 5;
			CommandBuilder.LineData* ptr = (CommandBuilder.LineData*)(num + 4);
			if (xy)
			{
				ptr->a = new float3(a, 0f);
				ptr->b = new float3(b, 0f);
			}
			else
			{
				ptr->a = new float3(a.x, 0f, a.y);
				ptr->b = new float3(b.x, 0f, b.y);
			}
			buffer->Length = length2;
		}

		public unsafe void Line(float2 a, float2 b, Color color)
		{
			draw.Reserve<Color32, CommandBuilder.LineData>();
			UnsafeAppendBuffer* buffer = draw.buffer;
			int length = buffer->Length;
			int length2 = length + 4 + 24 + 4;
			byte* num = buffer->Ptr + length;
			*(int*)num = 261;
			((int*)num)[1] = (int)CommandBuilder.ConvertColor(color);
			CommandBuilder.LineData* ptr = (CommandBuilder.LineData*)(num + 8);
			if (xy)
			{
				ptr->a = new float3(a, 0f);
				ptr->b = new float3(b, 0f);
			}
			else
			{
				ptr->a = new float3(a.x, 0f, a.y);
				ptr->b = new float3(b.x, 0f, b.y);
			}
			buffer->Length = length2;
		}

		public void Line(float3 a, float3 b)
		{
			draw.Line(a, b);
		}

		public void Circle(float2 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			Circle(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), radius, startAngle, endAngle);
		}

		public void Circle(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			if (xy)
			{
				draw.PushMatrix(XZ_TO_XY_MATRIX);
				draw.CircleXZInternal(new float3(center.x, center.z, center.y), radius, startAngle, endAngle);
				draw.PopMatrix();
			}
			else
			{
				draw.CircleXZInternal(center, radius, startAngle, endAngle);
			}
		}

		public void SolidCircle(float2 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			SolidCircle(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), radius, startAngle, endAngle);
		}

		public void SolidCircle(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			if (xy)
			{
				draw.PushMatrix(XZ_TO_XY_MATRIX);
			}
			draw.SolidCircleXZInternal(new float3(center.x, 0f - center.z, center.y), radius, startAngle, endAngle);
			if (xy)
			{
				draw.PopMatrix();
			}
		}

		public void WirePill(float2 a, float2 b, float radius)
		{
			WirePill(a, b - a, math.length(b - a), radius);
		}

		public void WirePill(float2 position, float2 direction, float length, float radius)
		{
			direction = math.normalizesafe(direction);
			if (radius <= 0f)
			{
				Line(position, position + direction * length);
				return;
			}
			if (length <= 0f || math.all(direction == 0f))
			{
				Circle(position, radius);
				return;
			}
			float4x4 matrix = ((!xy) ? new float4x4(new float4(direction.x, 0f, direction.y, 0f), new float4(0f, 1f, 0f, 0f), new float4(math.cross(new float3(direction.x, 0f, direction.y), XZ_UP), 0f), new float4(position.x, 0f, position.y, 1f)) : new float4x4(new float4(direction, 0f, 0f), new float4(math.cross(new float3(direction, 0f), XY_UP), 0f), new float4(0f, 0f, 1f, 0f), new float4(position, 0f, 1f)));
			draw.PushMatrix(matrix);
			Circle(new float2(0f, 0f), radius, MathF.PI / 2f, 4.712389f);
			Line(new float2(0f, 0f - radius), new float2(length, 0f - radius));
			Circle(new float2(length, 0f), radius, -MathF.PI / 2f, MathF.PI / 2f);
			Line(new float2(0f, radius), new float2(length, radius));
			draw.PopMatrix();
		}

		[BurstDiscard]
		public void Polyline(List<Vector2> points, bool cycle = false)
		{
			for (int i = 0; i < points.Count - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Count > 1)
			{
				Line(points[points.Count - 1], points[0]);
			}
		}

		[BurstDiscard]
		public void Polyline(Vector2[] points, bool cycle = false)
		{
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[^1], points[0]);
			}
		}

		[BurstDiscard]
		public void Polyline(float2[] points, bool cycle = false)
		{
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[^1], points[0]);
			}
		}

		public void Polyline(NativeArray<float2> points, bool cycle = false)
		{
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[points.Length - 1], points[0]);
			}
		}

		public void Cross(float2 position, float size = 1f)
		{
			size *= 0.5f;
			Line(position - new float2(size, 0f), position + new float2(size, 0f));
			Line(position - new float2(0f, size), position + new float2(0f, size));
		}

		public void WireRectangle(float3 center, float2 size)
		{
			draw.WirePlane(center, xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, size);
		}

		public void WireRectangle(Rect rect)
		{
			float2 float5 = rect.min;
			float2 float6 = rect.max;
			Line(new float2(float5.x, float5.y), new float2(float6.x, float5.y));
			Line(new float2(float6.x, float5.y), new float2(float6.x, float6.y));
			Line(new float2(float6.x, float6.y), new float2(float5.x, float6.y));
			Line(new float2(float5.x, float6.y), new float2(float5.x, float5.y));
		}

		public void SolidRectangle(Rect rect)
		{
			draw.SolidPlane(new float3(rect.center.x, rect.center.y, 0f), xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, new float2(rect.width, rect.height));
		}

		public void WireGrid(float2 center, int2 cells, float2 totalSize)
		{
			draw.WireGrid(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, cells, totalSize);
		}

		public void WireGrid(float3 center, int2 cells, float2 totalSize)
		{
			draw.WireGrid(center, xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, cells, totalSize);
		}

		[BurstDiscard]
		public CommandBuilder.ScopeMatrix WithMatrix(Matrix4x4 matrix)
		{
			return draw.WithMatrix(matrix);
		}

		[BurstDiscard]
		public CommandBuilder.ScopeMatrix WithMatrix(float3x3 matrix)
		{
			return draw.WithMatrix(matrix);
		}

		[BurstDiscard]
		public CommandBuilder.ScopeColor WithColor(Color color)
		{
			return draw.WithColor(color);
		}

		[BurstDiscard]
		public CommandBuilder.ScopePersist WithDuration(float duration)
		{
			return draw.WithDuration(duration);
		}

		[BurstDiscard]
		public CommandBuilder.ScopeLineWidth WithLineWidth(float pixels, bool automaticJoins = true)
		{
			return draw.WithLineWidth(pixels, automaticJoins);
		}

		[BurstDiscard]
		public CommandBuilder.ScopeMatrix InLocalSpace(Transform transform)
		{
			return draw.InLocalSpace(transform);
		}

		[BurstDiscard]
		public CommandBuilder.ScopeMatrix InScreenSpace(Camera camera)
		{
			return draw.InScreenSpace(camera);
		}

		public void PushMatrix(Matrix4x4 matrix)
		{
			draw.PushMatrix(matrix);
		}

		public void PushMatrix(float4x4 matrix)
		{
			draw.PushMatrix(matrix);
		}

		public void PushSetMatrix(Matrix4x4 matrix)
		{
			draw.PushSetMatrix(matrix);
		}

		public void PushSetMatrix(float4x4 matrix)
		{
			draw.PushSetMatrix(matrix);
		}

		public void PopMatrix()
		{
			draw.PopMatrix();
		}

		public void PushColor(Color color)
		{
			draw.PushColor(color);
		}

		public void PopColor()
		{
			draw.PopColor();
		}

		public void PushDuration(float duration)
		{
			draw.PushDuration(duration);
		}

		public void PopDuration()
		{
			draw.PopDuration();
		}

		[Obsolete("Renamed to PushDuration for consistency")]
		public void PushPersist(float duration)
		{
			draw.PushPersist(duration);
		}

		[Obsolete("Renamed to PopDuration for consistency")]
		public void PopPersist()
		{
			draw.PopPersist();
		}

		public void PushLineWidth(float pixels, bool automaticJoins = true)
		{
			draw.PushLineWidth(pixels, automaticJoins);
		}

		public void PopLineWidth()
		{
			draw.PopLineWidth();
		}

		public void Line(Vector3 a, Vector3 b)
		{
			draw.Line(a, b);
		}

		public void Line(Vector2 a, Vector2 b)
		{
			Line(xy ? new Vector3(a.x, a.y, 0f) : new Vector3(a.x, 0f, a.y), xy ? new Vector3(b.x, b.y, 0f) : new Vector3(b.x, 0f, b.y));
		}

		public void Line(Vector3 a, Vector3 b, Color color)
		{
			draw.Line(a, b, color);
		}

		public void Line(Vector2 a, Vector2 b, Color color)
		{
			Line(xy ? new Vector3(a.x, a.y, 0f) : new Vector3(a.x, 0f, a.y), xy ? new Vector3(b.x, b.y, 0f) : new Vector3(b.x, 0f, b.y), color);
		}

		public void Ray(float3 origin, float3 direction)
		{
			draw.Ray(origin, direction);
		}

		public void Ray(float2 origin, float2 direction)
		{
			Ray(xy ? new float3(origin, 0f) : new float3(origin.x, 0f, origin.y), xy ? new float3(direction, 0f) : new float3(direction.x, 0f, direction.y));
		}

		public void Ray(Ray ray, float length)
		{
			draw.Ray(ray, length);
		}

		public void Arc(float3 center, float3 start, float3 end)
		{
			draw.Arc(center, start, end);
		}

		public void Arc(float2 center, float2 start, float2 end)
		{
			Arc(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), xy ? new float3(start, 0f) : new float3(start.x, 0f, start.y), xy ? new float3(end, 0f) : new float3(end.x, 0f, end.y));
		}

		[Obsolete("Use Draw.xy.Circle instead")]
		public void CircleXY(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			draw.CircleXY(center, radius, startAngle, endAngle);
		}

		[Obsolete("Use Draw.xy.Circle instead")]
		public void CircleXY(float2 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			CircleXY(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), radius, startAngle, endAngle);
		}

		public void SolidArc(float3 center, float3 start, float3 end)
		{
			draw.SolidArc(center, start, end);
		}

		public void SolidArc(float2 center, float2 start, float2 end)
		{
			SolidArc(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), xy ? new float3(start, 0f) : new float3(start.x, 0f, start.y), xy ? new float3(end, 0f) : new float3(end.x, 0f, end.y));
		}

		[BurstDiscard]
		public void Polyline(List<Vector3> points, bool cycle = false)
		{
			draw.Polyline(points, cycle);
		}

		[BurstDiscard]
		public void Polyline(Vector3[] points, bool cycle = false)
		{
			draw.Polyline(points, cycle);
		}

		[BurstDiscard]
		public void Polyline(float3[] points, bool cycle = false)
		{
			draw.Polyline(points, cycle);
		}

		public void Polyline(NativeArray<float3> points, bool cycle = false)
		{
			draw.Polyline(points, cycle);
		}

		public void DashedLine(float3 a, float3 b, float dash, float gap)
		{
			draw.DashedLine(a, b, dash, gap);
		}

		public void DashedLine(float2 a, float2 b, float dash, float gap)
		{
			DashedLine(xy ? new float3(a, 0f) : new float3(a.x, 0f, a.y), xy ? new float3(b, 0f) : new float3(b.x, 0f, b.y), dash, gap);
		}

		public void DashedPolyline(List<Vector3> points, float dash, float gap)
		{
			draw.DashedPolyline(points, dash, gap);
		}

		public void Cross(float3 position, float size = 1f)
		{
			draw.Cross(position, size);
		}

		public void Bezier(float3 p0, float3 p1, float3 p2, float3 p3)
		{
			draw.Bezier(p0, p1, p2, p3);
		}

		public void Bezier(float2 p0, float2 p1, float2 p2, float2 p3)
		{
			Bezier(xy ? new float3(p0, 0f) : new float3(p0.x, 0f, p0.y), xy ? new float3(p1, 0f) : new float3(p1.x, 0f, p1.y), xy ? new float3(p2, 0f) : new float3(p2.x, 0f, p2.y), xy ? new float3(p3, 0f) : new float3(p3.x, 0f, p3.y));
		}

		public void CatmullRom(List<Vector3> points)
		{
			draw.CatmullRom(points);
		}

		public void CatmullRom(float3 p0, float3 p1, float3 p2, float3 p3)
		{
			draw.CatmullRom(p0, p1, p2, p3);
		}

		public void CatmullRom(float2 p0, float2 p1, float2 p2, float2 p3)
		{
			CatmullRom(xy ? new float3(p0, 0f) : new float3(p0.x, 0f, p0.y), xy ? new float3(p1, 0f) : new float3(p1.x, 0f, p1.y), xy ? new float3(p2, 0f) : new float3(p2.x, 0f, p2.y), xy ? new float3(p3, 0f) : new float3(p3.x, 0f, p3.y));
		}

		public void Arrow(float3 from, float3 to)
		{
			ArrowRelativeSizeHead(from, to, xy ? XY_UP : XZ_UP, 0.2f);
		}

		public void Arrow(float2 from, float2 to)
		{
			Arrow(xy ? new float3(from, 0f) : new float3(from.x, 0f, from.y), xy ? new float3(to, 0f) : new float3(to.x, 0f, to.y));
		}

		public void Arrow(float3 from, float3 to, float3 up, float headSize)
		{
			draw.Arrow(from, to, up, headSize);
		}

		public void Arrow(float2 from, float2 to, float2 up, float headSize)
		{
			Arrow(xy ? new float3(from, 0f) : new float3(from.x, 0f, from.y), xy ? new float3(to, 0f) : new float3(to.x, 0f, to.y), xy ? new float3(up, 0f) : new float3(up.x, 0f, up.y), headSize);
		}

		public void ArrowRelativeSizeHead(float3 from, float3 to, float3 up, float headFraction)
		{
			draw.ArrowRelativeSizeHead(from, to, up, headFraction);
		}

		public void ArrowRelativeSizeHead(float2 from, float2 to, float2 up, float headFraction)
		{
			ArrowRelativeSizeHead(xy ? new float3(from, 0f) : new float3(from.x, 0f, from.y), xy ? new float3(to, 0f) : new float3(to.x, 0f, to.y), xy ? new float3(up, 0f) : new float3(up.x, 0f, up.y), headFraction);
		}

		public void Arrowhead(float3 center, float3 direction, float radius)
		{
			Arrowhead(center, direction, xy ? XY_UP : XZ_UP, radius);
		}

		public void Arrowhead(float2 center, float2 direction, float radius)
		{
			Arrowhead(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), xy ? new float3(direction, 0f) : new float3(direction.x, 0f, direction.y), radius);
		}

		public void Arrowhead(float3 center, float3 direction, float3 up, float radius)
		{
			draw.Arrowhead(center, direction, up, radius);
		}

		public void Arrowhead(float2 center, float2 direction, float2 up, float radius)
		{
			Arrowhead(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), xy ? new float3(direction, 0f) : new float3(direction.x, 0f, direction.y), xy ? new float3(up, 0f) : new float3(up.x, 0f, up.y), radius);
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, float width = 60f)
		{
			if (math.any(direction))
			{
				if (offset < 0f)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (offset != 0f)
				{
					Quaternion q = Quaternion.LookRotation(direction, xy ? XY_UP : XZ_UP);
					PushMatrix(Matrix4x4.TRS(origin, q, Vector3.one));
					float num = MathF.PI / 2f - width * (MathF.PI / 360f);
					float num2 = MathF.PI / 2f + width * (MathF.PI / 360f);
					draw.CircleXZInternal(float3.zero, offset, num, num2);
					float3 a = new float3(math.cos(num), 0f, math.sin(num)) * offset;
					float3 b = new float3(math.cos(num2), 0f, math.sin(num2)) * offset;
					float3 float5 = new float3(0f, 0f, 1.4142f * offset);
					Line(a, float5);
					Line(float5, b);
					PopMatrix();
				}
			}
		}

		public void ArrowheadArc(float2 origin, float2 direction, float offset, float width = 60f)
		{
			ArrowheadArc(xy ? new float3(origin, 0f) : new float3(origin.x, 0f, origin.y), xy ? new float3(direction, 0f) : new float3(direction.x, 0f, direction.y), offset, width);
		}

		public void WireTriangle(float3 a, float3 b, float3 c)
		{
			draw.WireTriangle(a, b, c);
		}

		public void WireTriangle(float2 a, float2 b, float2 c)
		{
			WireTriangle(xy ? new float3(a, 0f) : new float3(a.x, 0f, a.y), xy ? new float3(b, 0f) : new float3(b.x, 0f, b.y), xy ? new float3(c, 0f) : new float3(c.x, 0f, c.y));
		}

		public void WireRectangle(float3 center, quaternion rotation, float2 size)
		{
			draw.WireRectangle(center, rotation, size);
		}

		public void WireRectangle(float2 center, quaternion rotation, float2 size)
		{
			WireRectangle(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), rotation, size);
		}

		public void WireTriangle(float3 center, quaternion rotation, float radius)
		{
			draw.WireTriangle(center, rotation, radius);
		}

		public void WireTriangle(float2 center, quaternion rotation, float radius)
		{
			WireTriangle(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), rotation, radius);
		}

		public void SolidTriangle(float3 a, float3 b, float3 c)
		{
			draw.SolidTriangle(a, b, c);
		}

		public void SolidTriangle(float2 a, float2 b, float2 c)
		{
			SolidTriangle(xy ? new float3(a, 0f) : new float3(a.x, 0f, a.y), xy ? new float3(b, 0f) : new float3(b.x, 0f, b.y), xy ? new float3(c, 0f) : new float3(c.x, 0f, c.y));
		}

		public void Label2D(float3 position, string text, float sizeInPixels = 14f)
		{
			draw.Label2D(position, text, sizeInPixels);
		}

		public void Label2D(float2 position, string text, float sizeInPixels = 14f)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), text, sizeInPixels);
		}

		public void Label2D(float3 position, string text, float sizeInPixels, LabelAlignment alignment)
		{
			draw.Label2D(position, text, sizeInPixels, alignment);
		}

		public void Label2D(float2 position, string text, float sizeInPixels, LabelAlignment alignment)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), text, sizeInPixels, alignment);
		}

		public void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels = 14f)
		{
			draw.Label2D(position, ref text, sizeInPixels);
		}

		public void Label2D(float2 position, ref FixedString32Bytes text, float sizeInPixels = 14f)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels);
		}

		public void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels = 14f)
		{
			draw.Label2D(position, ref text, sizeInPixels);
		}

		public void Label2D(float2 position, ref FixedString64Bytes text, float sizeInPixels = 14f)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels);
		}

		public void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels = 14f)
		{
			draw.Label2D(position, ref text, sizeInPixels);
		}

		public void Label2D(float2 position, ref FixedString128Bytes text, float sizeInPixels = 14f)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels);
		}

		public void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels = 14f)
		{
			draw.Label2D(position, ref text, sizeInPixels);
		}

		public void Label2D(float2 position, ref FixedString512Bytes text, float sizeInPixels = 14f)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels);
		}

		public void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
			draw.Label2D(position, ref text, sizeInPixels, alignment);
		}

		public void Label2D(float2 position, ref FixedString32Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels, alignment);
		}

		public void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
			draw.Label2D(position, ref text, sizeInPixels, alignment);
		}

		public void Label2D(float2 position, ref FixedString64Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels, alignment);
		}

		public void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
			draw.Label2D(position, ref text, sizeInPixels, alignment);
		}

		public void Label2D(float2 position, ref FixedString128Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels, alignment);
		}

		public void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
			draw.Label2D(position, ref text, sizeInPixels, alignment);
		}

		public void Label2D(float2 position, ref FixedString512Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels, alignment);
		}

		public void Ray(float3 origin, float3 direction, Color color)
		{
			draw.Ray(origin, direction, color);
		}

		public void Ray(float2 origin, float2 direction, Color color)
		{
			Ray(xy ? new float3(origin, 0f) : new float3(origin.x, 0f, origin.y), xy ? new float3(direction, 0f) : new float3(direction.x, 0f, direction.y), color);
		}

		public void Ray(Ray ray, float length, Color color)
		{
			draw.Ray(ray, length, color);
		}

		public void Arc(float3 center, float3 start, float3 end, Color color)
		{
			draw.Arc(center, start, end, color);
		}

		public void Arc(float2 center, float2 start, float2 end, Color color)
		{
			Arc(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), xy ? new float3(start, 0f) : new float3(start.x, 0f, start.y), xy ? new float3(end, 0f) : new float3(end.x, 0f, end.y), color);
		}

		[Obsolete("Use Draw.xy.Circle instead")]
		public void CircleXY(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
			draw.CircleXY(center, radius, startAngle, endAngle, color);
		}

		[Obsolete("Use Draw.xy.Circle instead")]
		public void CircleXY(float3 center, float radius, Color color)
		{
			CircleXY(center, radius, 0f, MathF.PI * 2f, color);
		}

		[Obsolete("Use Draw.xy.Circle instead")]
		public void CircleXY(float2 center, float radius, float startAngle, float endAngle, Color color)
		{
			CircleXY(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), radius, startAngle, endAngle, color);
		}

		[Obsolete("Use Draw.xy.Circle instead")]
		public void CircleXY(float2 center, float radius, Color color)
		{
			CircleXY(center, radius, 0f, MathF.PI * 2f, color);
		}

		public void SolidArc(float3 center, float3 start, float3 end, Color color)
		{
			draw.SolidArc(center, start, end, color);
		}

		public void SolidArc(float2 center, float2 start, float2 end, Color color)
		{
			SolidArc(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), xy ? new float3(start, 0f) : new float3(start.x, 0f, start.y), xy ? new float3(end, 0f) : new float3(end.x, 0f, end.y), color);
		}

		[BurstDiscard]
		public void Polyline(List<Vector3> points, bool cycle, Color color)
		{
			draw.Polyline(points, cycle, color);
		}

		[BurstDiscard]
		public void Polyline(List<Vector3> points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		[BurstDiscard]
		public void Polyline(Vector3[] points, bool cycle, Color color)
		{
			draw.Polyline(points, cycle, color);
		}

		[BurstDiscard]
		public void Polyline(Vector3[] points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		[BurstDiscard]
		public void Polyline(float3[] points, bool cycle, Color color)
		{
			draw.Polyline(points, cycle, color);
		}

		[BurstDiscard]
		public void Polyline(float3[] points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		public void Polyline(NativeArray<float3> points, bool cycle, Color color)
		{
			draw.Polyline(points, cycle, color);
		}

		public void Polyline(NativeArray<float3> points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		public void DashedLine(float3 a, float3 b, float dash, float gap, Color color)
		{
			draw.DashedLine(a, b, dash, gap, color);
		}

		public void DashedLine(float2 a, float2 b, float dash, float gap, Color color)
		{
			DashedLine(xy ? new float3(a, 0f) : new float3(a.x, 0f, a.y), xy ? new float3(b, 0f) : new float3(b.x, 0f, b.y), dash, gap, color);
		}

		public void DashedPolyline(List<Vector3> points, float dash, float gap, Color color)
		{
			draw.DashedPolyline(points, dash, gap, color);
		}

		public void Cross(float3 position, float size, Color color)
		{
			draw.Cross(position, size, color);
		}

		public void Cross(float3 position, Color color)
		{
			Cross(position, 1f, color);
		}

		public void Bezier(float3 p0, float3 p1, float3 p2, float3 p3, Color color)
		{
			draw.Bezier(p0, p1, p2, p3, color);
		}

		public void Bezier(float2 p0, float2 p1, float2 p2, float2 p3, Color color)
		{
			Bezier(xy ? new float3(p0, 0f) : new float3(p0.x, 0f, p0.y), xy ? new float3(p1, 0f) : new float3(p1.x, 0f, p1.y), xy ? new float3(p2, 0f) : new float3(p2.x, 0f, p2.y), xy ? new float3(p3, 0f) : new float3(p3.x, 0f, p3.y), color);
		}

		public void CatmullRom(List<Vector3> points, Color color)
		{
			draw.CatmullRom(points, color);
		}

		public void CatmullRom(float3 p0, float3 p1, float3 p2, float3 p3, Color color)
		{
			draw.CatmullRom(p0, p1, p2, p3, color);
		}

		public void CatmullRom(float2 p0, float2 p1, float2 p2, float2 p3, Color color)
		{
			CatmullRom(xy ? new float3(p0, 0f) : new float3(p0.x, 0f, p0.y), xy ? new float3(p1, 0f) : new float3(p1.x, 0f, p1.y), xy ? new float3(p2, 0f) : new float3(p2.x, 0f, p2.y), xy ? new float3(p3, 0f) : new float3(p3.x, 0f, p3.y), color);
		}

		public void Arrow(float3 from, float3 to, Color color)
		{
			ArrowRelativeSizeHead(from, to, xy ? XY_UP : XZ_UP, 0.2f, color);
		}

		public void Arrow(float2 from, float2 to, Color color)
		{
			Arrow(xy ? new float3(from, 0f) : new float3(from.x, 0f, from.y), xy ? new float3(to, 0f) : new float3(to.x, 0f, to.y), color);
		}

		public void Arrow(float3 from, float3 to, float3 up, float headSize, Color color)
		{
			draw.Arrow(from, to, up, headSize, color);
		}

		public void Arrow(float2 from, float2 to, float2 up, float headSize, Color color)
		{
			Arrow(xy ? new float3(from, 0f) : new float3(from.x, 0f, from.y), xy ? new float3(to, 0f) : new float3(to.x, 0f, to.y), xy ? new float3(up, 0f) : new float3(up.x, 0f, up.y), headSize, color);
		}

		public void ArrowRelativeSizeHead(float3 from, float3 to, float3 up, float headFraction, Color color)
		{
			draw.ArrowRelativeSizeHead(from, to, up, headFraction, color);
		}

		public void ArrowRelativeSizeHead(float2 from, float2 to, float2 up, float headFraction, Color color)
		{
			ArrowRelativeSizeHead(xy ? new float3(from, 0f) : new float3(from.x, 0f, from.y), xy ? new float3(to, 0f) : new float3(to.x, 0f, to.y), xy ? new float3(up, 0f) : new float3(up.x, 0f, up.y), headFraction, color);
		}

		public void Arrowhead(float3 center, float3 direction, float radius, Color color)
		{
			Arrowhead(center, direction, xy ? XY_UP : XZ_UP, radius, color);
		}

		public void Arrowhead(float2 center, float2 direction, float radius, Color color)
		{
			Arrowhead(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), xy ? new float3(direction, 0f) : new float3(direction.x, 0f, direction.y), radius, color);
		}

		public void Arrowhead(float3 center, float3 direction, float3 up, float radius, Color color)
		{
			draw.Arrowhead(center, direction, up, radius, color);
		}

		public void Arrowhead(float2 center, float2 direction, float2 up, float radius, Color color)
		{
			Arrowhead(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), xy ? new float3(direction, 0f) : new float3(direction.x, 0f, direction.y), xy ? new float3(up, 0f) : new float3(up.x, 0f, up.y), radius, color);
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, float width, Color color)
		{
			if (math.any(direction))
			{
				if (offset < 0f)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (offset != 0f)
				{
					draw.PushColor(color);
					Quaternion q = Quaternion.LookRotation(direction, xy ? XY_UP : XZ_UP);
					PushMatrix(Matrix4x4.TRS(origin, q, Vector3.one));
					float num = MathF.PI / 2f - width * (MathF.PI / 360f);
					float num2 = MathF.PI / 2f + width * (MathF.PI / 360f);
					draw.CircleXZInternal(float3.zero, offset, num, num2);
					float3 a = new float3(math.cos(num), 0f, math.sin(num)) * offset;
					float3 b = new float3(math.cos(num2), 0f, math.sin(num2)) * offset;
					float3 float5 = new float3(0f, 0f, 1.4142f * offset);
					Line(a, float5);
					Line(float5, b);
					PopMatrix();
					draw.PopColor();
				}
			}
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, Color color)
		{
			ArrowheadArc(origin, direction, offset, 60f, color);
		}

		public void ArrowheadArc(float2 origin, float2 direction, float offset, float width, Color color)
		{
			ArrowheadArc(xy ? new float3(origin, 0f) : new float3(origin.x, 0f, origin.y), xy ? new float3(direction, 0f) : new float3(direction.x, 0f, direction.y), offset, width, color);
		}

		public void ArrowheadArc(float2 origin, float2 direction, float offset, Color color)
		{
			ArrowheadArc(origin, direction, offset, 60f, color);
		}

		public void WireTriangle(float3 a, float3 b, float3 c, Color color)
		{
			draw.WireTriangle(a, b, c, color);
		}

		public void WireTriangle(float2 a, float2 b, float2 c, Color color)
		{
			WireTriangle(xy ? new float3(a, 0f) : new float3(a.x, 0f, a.y), xy ? new float3(b, 0f) : new float3(b.x, 0f, b.y), xy ? new float3(c, 0f) : new float3(c.x, 0f, c.y), color);
		}

		public void WireRectangle(float3 center, quaternion rotation, float2 size, Color color)
		{
			draw.WireRectangle(center, rotation, size, color);
		}

		public void WireRectangle(float2 center, quaternion rotation, float2 size, Color color)
		{
			WireRectangle(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), rotation, size, color);
		}

		public void WireTriangle(float3 center, quaternion rotation, float radius, Color color)
		{
			draw.WireTriangle(center, rotation, radius, color);
		}

		public void WireTriangle(float2 center, quaternion rotation, float radius, Color color)
		{
			WireTriangle(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), rotation, radius, color);
		}

		public void SolidTriangle(float3 a, float3 b, float3 c, Color color)
		{
			draw.SolidTriangle(a, b, c, color);
		}

		public void SolidTriangle(float2 a, float2 b, float2 c, Color color)
		{
			SolidTriangle(xy ? new float3(a, 0f) : new float3(a.x, 0f, a.y), xy ? new float3(b, 0f) : new float3(b.x, 0f, b.y), xy ? new float3(c, 0f) : new float3(c.x, 0f, c.y), color);
		}

		public void Label2D(float3 position, string text, float sizeInPixels, Color color)
		{
			draw.Label2D(position, text, sizeInPixels, color);
		}

		public void Label2D(float3 position, string text, Color color)
		{
			Label2D(position, text, 14f, color);
		}

		public void Label2D(float2 position, string text, float sizeInPixels, Color color)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), text, sizeInPixels, color);
		}

		public void Label2D(float2 position, string text, Color color)
		{
			Label2D(position, text, 14f, color);
		}

		public void Label2D(float3 position, string text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			draw.Label2D(position, text, sizeInPixels, alignment, color);
		}

		public void Label2D(float2 position, string text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), text, sizeInPixels, alignment, color);
		}

		public void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels, Color color)
		{
			draw.Label2D(position, ref text, sizeInPixels, color);
		}

		public void Label2D(float3 position, ref FixedString32Bytes text, Color color)
		{
			Label2D(position, ref text, 14f, color);
		}

		public void Label2D(float2 position, ref FixedString32Bytes text, float sizeInPixels, Color color)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels, color);
		}

		public void Label2D(float2 position, ref FixedString32Bytes text, Color color)
		{
			Label2D(position, ref text, 14f, color);
		}

		public void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels, Color color)
		{
			draw.Label2D(position, ref text, sizeInPixels, color);
		}

		public void Label2D(float3 position, ref FixedString64Bytes text, Color color)
		{
			Label2D(position, ref text, 14f, color);
		}

		public void Label2D(float2 position, ref FixedString64Bytes text, float sizeInPixels, Color color)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels, color);
		}

		public void Label2D(float2 position, ref FixedString64Bytes text, Color color)
		{
			Label2D(position, ref text, 14f, color);
		}

		public void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels, Color color)
		{
			draw.Label2D(position, ref text, sizeInPixels, color);
		}

		public void Label2D(float3 position, ref FixedString128Bytes text, Color color)
		{
			Label2D(position, ref text, 14f, color);
		}

		public void Label2D(float2 position, ref FixedString128Bytes text, float sizeInPixels, Color color)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels, color);
		}

		public void Label2D(float2 position, ref FixedString128Bytes text, Color color)
		{
			Label2D(position, ref text, 14f, color);
		}

		public void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels, Color color)
		{
			draw.Label2D(position, ref text, sizeInPixels, color);
		}

		public void Label2D(float3 position, ref FixedString512Bytes text, Color color)
		{
			Label2D(position, ref text, 14f, color);
		}

		public void Label2D(float2 position, ref FixedString512Bytes text, float sizeInPixels, Color color)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels, color);
		}

		public void Label2D(float2 position, ref FixedString512Bytes text, Color color)
		{
			Label2D(position, ref text, 14f, color);
		}

		public void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			draw.Label2D(position, ref text, sizeInPixels, alignment, color);
		}

		public void Label2D(float2 position, ref FixedString32Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels, alignment, color);
		}

		public void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			draw.Label2D(position, ref text, sizeInPixels, alignment, color);
		}

		public void Label2D(float2 position, ref FixedString64Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels, alignment, color);
		}

		public void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			draw.Label2D(position, ref text, sizeInPixels, alignment, color);
		}

		public void Label2D(float2 position, ref FixedString128Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels, alignment, color);
		}

		public void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			draw.Label2D(position, ref text, sizeInPixels, alignment, color);
		}

		public void Label2D(float2 position, ref FixedString512Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
			Label2D(xy ? new float3(position, 0f) : new float3(position.x, 0f, position.y), ref text, sizeInPixels, alignment, color);
		}

		public void Line(float3 a, float3 b, Color color)
		{
			draw.Line(a, b, color);
		}

		public void Circle(float2 center, float radius, float startAngle, float endAngle, Color color)
		{
			Circle(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), radius, startAngle, endAngle, color);
		}

		public void Circle(float2 center, float radius, Color color)
		{
			Circle(center, radius, 0f, MathF.PI * 2f, color);
		}

		public void Circle(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
			draw.PushColor(color);
			if (xy)
			{
				draw.PushMatrix(XZ_TO_XY_MATRIX);
				draw.CircleXZInternal(new float3(center.x, center.z, center.y), radius, startAngle, endAngle);
				draw.PopMatrix();
			}
			else
			{
				draw.CircleXZInternal(center, radius, startAngle, endAngle);
			}
			draw.PopColor();
		}

		public void Circle(float3 center, float radius, Color color)
		{
			Circle(center, radius, 0f, MathF.PI * 2f, color);
		}

		public void SolidCircle(float2 center, float radius, float startAngle, float endAngle, Color color)
		{
			SolidCircle(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), radius, startAngle, endAngle, color);
		}

		public void SolidCircle(float2 center, float radius, Color color)
		{
			SolidCircle(center, radius, 0f, MathF.PI * 2f, color);
		}

		public void SolidCircle(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
			draw.PushColor(color);
			if (xy)
			{
				draw.PushMatrix(XZ_TO_XY_MATRIX);
			}
			draw.SolidCircleXZInternal(new float3(center.x, 0f - center.z, center.y), radius, startAngle, endAngle);
			if (xy)
			{
				draw.PopMatrix();
			}
			draw.PopColor();
		}

		public void SolidCircle(float3 center, float radius, Color color)
		{
			SolidCircle(center, radius, 0f, MathF.PI * 2f, color);
		}

		public void WirePill(float2 a, float2 b, float radius, Color color)
		{
			WirePill(a, b - a, math.length(b - a), radius, color);
		}

		public void WirePill(float2 position, float2 direction, float length, float radius, Color color)
		{
			draw.PushColor(color);
			direction = math.normalizesafe(direction);
			if (radius <= 0f)
			{
				Line(position, position + direction * length);
			}
			else if (length <= 0f || math.all(direction == 0f))
			{
				Circle(position, radius);
			}
			else
			{
				float4x4 matrix = ((!xy) ? new float4x4(new float4(direction.x, 0f, direction.y, 0f), new float4(0f, 1f, 0f, 0f), new float4(math.cross(new float3(direction.x, 0f, direction.y), XZ_UP), 0f), new float4(position.x, 0f, position.y, 1f)) : new float4x4(new float4(direction, 0f, 0f), new float4(math.cross(new float3(direction, 0f), XY_UP), 0f), new float4(0f, 0f, 1f, 0f), new float4(position, 0f, 1f)));
				draw.PushMatrix(matrix);
				Circle(new float2(0f, 0f), radius, MathF.PI / 2f, 4.712389f);
				Line(new float2(0f, 0f - radius), new float2(length, 0f - radius));
				Circle(new float2(length, 0f), radius, -MathF.PI / 2f, MathF.PI / 2f);
				Line(new float2(0f, radius), new float2(length, radius));
				draw.PopMatrix();
			}
			draw.PopColor();
		}

		[BurstDiscard]
		public void Polyline(List<Vector2> points, bool cycle, Color color)
		{
			draw.PushColor(color);
			for (int i = 0; i < points.Count - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Count > 1)
			{
				Line(points[points.Count - 1], points[0]);
			}
			draw.PopColor();
		}

		[BurstDiscard]
		public void Polyline(List<Vector2> points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		[BurstDiscard]
		public void Polyline(Vector2[] points, bool cycle, Color color)
		{
			draw.PushColor(color);
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[^1], points[0]);
			}
			draw.PopColor();
		}

		[BurstDiscard]
		public void Polyline(Vector2[] points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		[BurstDiscard]
		public void Polyline(float2[] points, bool cycle, Color color)
		{
			draw.PushColor(color);
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[^1], points[0]);
			}
			draw.PopColor();
		}

		[BurstDiscard]
		public void Polyline(float2[] points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		public void Polyline(NativeArray<float2> points, bool cycle, Color color)
		{
			draw.PushColor(color);
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[points.Length - 1], points[0]);
			}
			draw.PopColor();
		}

		public void Polyline(NativeArray<float2> points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		public void Cross(float2 position, float size, Color color)
		{
			draw.PushColor(color);
			size *= 0.5f;
			Line(position - new float2(size, 0f), position + new float2(size, 0f));
			Line(position - new float2(0f, size), position + new float2(0f, size));
			draw.PopColor();
		}

		public void Cross(float2 position, Color color)
		{
			Cross(position, 1f, color);
		}

		public void WireRectangle(float3 center, float2 size, Color color)
		{
			draw.WirePlane(center, xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, size, color);
		}

		public void WireRectangle(Rect rect, Color color)
		{
			draw.PushColor(color);
			float2 float5 = rect.min;
			float2 float6 = rect.max;
			Line(new float2(float5.x, float5.y), new float2(float6.x, float5.y));
			Line(new float2(float6.x, float5.y), new float2(float6.x, float6.y));
			Line(new float2(float6.x, float6.y), new float2(float5.x, float6.y));
			Line(new float2(float5.x, float6.y), new float2(float5.x, float5.y));
			draw.PopColor();
		}

		public void SolidRectangle(Rect rect, Color color)
		{
			draw.SolidPlane(new float3(rect.center.x, rect.center.y, 0f), xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, new float2(rect.width, rect.height), color);
		}

		public void WireGrid(float2 center, int2 cells, float2 totalSize, Color color)
		{
			draw.WireGrid(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, cells, totalSize, color);
		}

		public void WireGrid(float3 center, int2 cells, float2 totalSize, Color color)
		{
			draw.WireGrid(center, xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, cells, totalSize, color);
		}
	}
	public static class Draw
	{
		internal static CommandBuilder builder;

		internal static CommandBuilder ingame_builder;

		public static ref CommandBuilder ingame
		{
			get
			{
				DrawingManager.Init();
				return ref ingame_builder;
			}
		}

		public static ref CommandBuilder editor
		{
			get
			{
				DrawingManager.Init();
				return ref builder;
			}
		}

		public static CommandBuilder2D xy
		{
			get
			{
				DrawingManager.Init();
				return new CommandBuilder2D(builder, xy: true);
			}
		}

		public static CommandBuilder2D xz
		{
			get
			{
				DrawingManager.Init();
				return new CommandBuilder2D(builder, xy: false);
			}
		}

		[BurstDiscard]
		public static CommandBuilder.ScopeEmpty WithMatrix(Matrix4x4 matrix)
		{
			return default(CommandBuilder.ScopeEmpty);
		}

		[BurstDiscard]
		public static CommandBuilder.ScopeEmpty WithMatrix(float3x3 matrix)
		{
			return default(CommandBuilder.ScopeEmpty);
		}

		[BurstDiscard]
		public static CommandBuilder.ScopeEmpty WithColor(Color color)
		{
			return default(CommandBuilder.ScopeEmpty);
		}

		[BurstDiscard]
		public static CommandBuilder.ScopeEmpty WithDuration(float duration)
		{
			return default(CommandBuilder.ScopeEmpty);
		}

		[BurstDiscard]
		public static CommandBuilder.ScopeEmpty WithLineWidth(float pixels, bool automaticJoins = true)
		{
			return default(CommandBuilder.ScopeEmpty);
		}

		[BurstDiscard]
		public static CommandBuilder.ScopeEmpty InLocalSpace(Transform transform)
		{
			return default(CommandBuilder.ScopeEmpty);
		}

		[BurstDiscard]
		public static CommandBuilder.ScopeEmpty InScreenSpace(Camera camera)
		{
			return default(CommandBuilder.ScopeEmpty);
		}

		[BurstDiscard]
		public static void PushMatrix(Matrix4x4 matrix)
		{
		}

		[BurstDiscard]
		public static void PushMatrix(float4x4 matrix)
		{
		}

		[BurstDiscard]
		public static void PushSetMatrix(Matrix4x4 matrix)
		{
		}

		[BurstDiscard]
		public static void PushSetMatrix(float4x4 matrix)
		{
		}

		[BurstDiscard]
		public static void PopMatrix()
		{
		}

		[BurstDiscard]
		public static void PushColor(Color color)
		{
		}

		[BurstDiscard]
		public static void PopColor()
		{
		}

		[BurstDiscard]
		public static void PushDuration(float duration)
		{
		}

		[BurstDiscard]
		public static void PopDuration()
		{
		}

		[BurstDiscard]
		[Obsolete("Renamed to PushDuration for consistency")]
		public static void PushPersist(float duration)
		{
		}

		[BurstDiscard]
		[Obsolete("Renamed to PopDuration for consistency")]
		public static void PopPersist()
		{
		}

		[BurstDiscard]
		public static void PushLineWidth(float pixels, bool automaticJoins = true)
		{
		}

		[BurstDiscard]
		public static void PopLineWidth()
		{
		}

		[BurstDiscard]
		public static void Line(float3 a, float3 b)
		{
		}

		[BurstDiscard]
		public static void Line(Vector3 a, Vector3 b)
		{
		}

		[BurstDiscard]
		public static void Line(Vector3 a, Vector3 b, Color color)
		{
		}

		[BurstDiscard]
		public static void Ray(float3 origin, float3 direction)
		{
		}

		[BurstDiscard]
		public static void Ray(Ray ray, float length)
		{
		}

		[BurstDiscard]
		public static void Arc(float3 center, float3 start, float3 end)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.Circle instead")]
		public static void CircleXZ(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.Circle instead")]
		public static void CircleXY(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
		}

		[BurstDiscard]
		public static void Circle(float3 center, float3 normal, float radius)
		{
		}

		[BurstDiscard]
		public static void SolidArc(float3 center, float3 start, float3 end)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.SolidCircle instead")]
		public static void SolidCircleXZ(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.SolidCircle instead")]
		public static void SolidCircleXY(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
		}

		[BurstDiscard]
		public static void SolidCircle(float3 center, float3 normal, float radius)
		{
		}

		[BurstDiscard]
		public static void SphereOutline(float3 center, float radius)
		{
		}

		[BurstDiscard]
		public static void WireCylinder(float3 bottom, float3 top, float radius)
		{
		}

		[BurstDiscard]
		public static void WireCylinder(float3 position, float3 up, float height, float radius)
		{
		}

		[BurstDiscard]
		public static void WireCapsule(float3 start, float3 end, float radius)
		{
		}

		[BurstDiscard]
		public static void WireCapsule(float3 position, float3 direction, float length, float radius)
		{
		}

		[BurstDiscard]
		public static void WireSphere(float3 position, float radius)
		{
		}

		[BurstDiscard]
		public static void Polyline(List<Vector3> points, bool cycle = false)
		{
		}

		[BurstDiscard]
		public static void Polyline(Vector3[] points, bool cycle = false)
		{
		}

		[BurstDiscard]
		public static void Polyline(float3[] points, bool cycle = false)
		{
		}

		[BurstDiscard]
		public static void Polyline(NativeArray<float3> points, bool cycle = false)
		{
		}

		[BurstDiscard]
		public static void DashedLine(float3 a, float3 b, float dash, float gap)
		{
		}

		[BurstDiscard]
		public static void DashedPolyline(List<Vector3> points, float dash, float gap)
		{
		}

		[BurstDiscard]
		public static void WireBox(float3 center, float3 size)
		{
		}

		[BurstDiscard]
		public static void WireBox(float3 center, quaternion rotation, float3 size)
		{
		}

		[BurstDiscard]
		public static void WireBox(Bounds bounds)
		{
		}

		[BurstDiscard]
		public static void WireMesh(Mesh mesh)
		{
		}

		[BurstDiscard]
		public static void WireMesh(NativeArray<float3> vertices, NativeArray<int> triangles)
		{
		}

		[BurstDiscard]
		public static void SolidMesh(Mesh mesh)
		{
		}

		[BurstDiscard]
		public static void SolidMesh(List<Vector3> vertices, List<int> triangles, List<Color> colors)
		{
		}

		[BurstDiscard]
		public static void SolidMesh(Vector3[] vertices, int[] triangles, Color[] colors, int vertexCount, int indexCount)
		{
		}

		[BurstDiscard]
		public static void Cross(float3 position, float size = 1f)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.Cross instead")]
		public static void CrossXZ(float3 position, float size = 1f)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.Cross instead")]
		public static void CrossXY(float3 position, float size = 1f)
		{
		}

		[BurstDiscard]
		public static void Bezier(float3 p0, float3 p1, float3 p2, float3 p3)
		{
		}

		[BurstDiscard]
		public static void CatmullRom(List<Vector3> points)
		{
		}

		[BurstDiscard]
		public static void CatmullRom(float3 p0, float3 p1, float3 p2, float3 p3)
		{
		}

		[BurstDiscard]
		public static void Arrow(float3 from, float3 to)
		{
		}

		[BurstDiscard]
		public static void Arrow(float3 from, float3 to, float3 up, float headSize)
		{
		}

		[BurstDiscard]
		public static void ArrowRelativeSizeHead(float3 from, float3 to, float3 up, float headFraction)
		{
		}

		[BurstDiscard]
		public static void Arrowhead(float3 center, float3 direction, float radius)
		{
		}

		[BurstDiscard]
		public static void Arrowhead(float3 center, float3 direction, float3 up, float radius)
		{
		}

		[BurstDiscard]
		public static void ArrowheadArc(float3 origin, float3 direction, float offset, float width = 60f)
		{
		}

		[BurstDiscard]
		public static void WireGrid(float3 center, quaternion rotation, int2 cells, float2 totalSize)
		{
		}

		[BurstDiscard]
		public static void WireTriangle(float3 a, float3 b, float3 c)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.WireRectangle instead")]
		public static void WireRectangleXZ(float3 center, float2 size)
		{
		}

		[BurstDiscard]
		public static void WireRectangle(float3 center, quaternion rotation, float2 size)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.WireRectangle instead")]
		public static void WireRectangle(Rect rect)
		{
		}

		[BurstDiscard]
		public static void WireTriangle(float3 center, quaternion rotation, float radius)
		{
		}

		[BurstDiscard]
		public static void WirePentagon(float3 center, quaternion rotation, float radius)
		{
		}

		[BurstDiscard]
		public static void WireHexagon(float3 center, quaternion rotation, float radius)
		{
		}

		[BurstDiscard]
		public static void WirePolygon(float3 center, int vertices, quaternion rotation, float radius)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.SolidRectangle instead")]
		public static void SolidRectangle(Rect rect)
		{
		}

		[BurstDiscard]
		public static void SolidPlane(float3 center, float3 normal, float2 size)
		{
		}

		[BurstDiscard]
		public static void SolidPlane(float3 center, quaternion rotation, float2 size)
		{
		}

		[BurstDiscard]
		public static void WirePlane(float3 center, float3 normal, float2 size)
		{
		}

		[BurstDiscard]
		public static void WirePlane(float3 center, quaternion rotation, float2 size)
		{
		}

		[BurstDiscard]
		public static void PlaneWithNormal(float3 center, float3 normal, float2 size)
		{
		}

		[BurstDiscard]
		public static void PlaneWithNormal(float3 center, quaternion rotation, float2 size)
		{
		}

		[BurstDiscard]
		public static void SolidTriangle(float3 a, float3 b, float3 c)
		{
		}

		[BurstDiscard]
		public static void SolidBox(float3 center, float3 size)
		{
		}

		[BurstDiscard]
		public static void SolidBox(Bounds bounds)
		{
		}

		[BurstDiscard]
		public static void SolidBox(float3 center, quaternion rotation, float3 size)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, string text, float size)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, string text, float size, LabelAlignment alignment)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, string text, float sizeInPixels = 14f)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, string text, float sizeInPixels, LabelAlignment alignment)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels = 14f)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels = 14f)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels = 14f)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels = 14f)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString32Bytes text, float size)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString64Bytes text, float size)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString128Bytes text, float size)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString512Bytes text, float size)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString32Bytes text, float size, LabelAlignment alignment)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString64Bytes text, float size, LabelAlignment alignment)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString128Bytes text, float size, LabelAlignment alignment)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString512Bytes text, float size, LabelAlignment alignment)
		{
		}

		[BurstDiscard]
		public static void Line(float3 a, float3 b, Color color)
		{
		}

		[BurstDiscard]
		public static void Ray(float3 origin, float3 direction, Color color)
		{
		}

		[BurstDiscard]
		public static void Ray(Ray ray, float length, Color color)
		{
		}

		[BurstDiscard]
		public static void Arc(float3 center, float3 start, float3 end, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.Circle instead")]
		public static void CircleXZ(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.Circle instead")]
		public static void CircleXZ(float3 center, float radius, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.Circle instead")]
		public static void CircleXY(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.Circle instead")]
		public static void CircleXY(float3 center, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void Circle(float3 center, float3 normal, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void SolidArc(float3 center, float3 start, float3 end, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.SolidCircle instead")]
		public static void SolidCircleXZ(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.SolidCircle instead")]
		public static void SolidCircleXZ(float3 center, float radius, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.SolidCircle instead")]
		public static void SolidCircleXY(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.SolidCircle instead")]
		public static void SolidCircleXY(float3 center, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void SolidCircle(float3 center, float3 normal, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void SphereOutline(float3 center, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void WireCylinder(float3 bottom, float3 top, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void WireCylinder(float3 position, float3 up, float height, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void WireCapsule(float3 start, float3 end, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void WireCapsule(float3 position, float3 direction, float length, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void WireSphere(float3 position, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(List<Vector3> points, bool cycle, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(List<Vector3> points, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(Vector3[] points, bool cycle, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(Vector3[] points, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(float3[] points, bool cycle, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(float3[] points, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(NativeArray<float3> points, bool cycle, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(NativeArray<float3> points, Color color)
		{
		}

		[BurstDiscard]
		public static void DashedLine(float3 a, float3 b, float dash, float gap, Color color)
		{
		}

		[BurstDiscard]
		public static void DashedPolyline(List<Vector3> points, float dash, float gap, Color color)
		{
		}

		[BurstDiscard]
		public static void WireBox(float3 center, float3 size, Color color)
		{
		}

		[BurstDiscard]
		public static void WireBox(float3 center, quaternion rotation, float3 size, Color color)
		{
		}

		[BurstDiscard]
		public static void WireBox(Bounds bounds, Color color)
		{
		}

		[BurstDiscard]
		public static void WireMesh(Mesh mesh, Color color)
		{
		}

		[BurstDiscard]
		public static void WireMesh(NativeArray<float3> vertices, NativeArray<int> triangles, Color color)
		{
		}

		[BurstDiscard]
		public static void SolidMesh(Mesh mesh, Color color)
		{
		}

		[BurstDiscard]
		public static void Cross(float3 position, float size, Color color)
		{
		}

		[BurstDiscard]
		public static void Cross(float3 position, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.Cross instead")]
		public static void CrossXZ(float3 position, float size, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.Cross instead")]
		public static void CrossXZ(float3 position, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.Cross instead")]
		public static void CrossXY(float3 position, float size, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.Cross instead")]
		public static void CrossXY(float3 position, Color color)
		{
		}

		[BurstDiscard]
		public static void Bezier(float3 p0, float3 p1, float3 p2, float3 p3, Color color)
		{
		}

		[BurstDiscard]
		public static void CatmullRom(List<Vector3> points, Color color)
		{
		}

		[BurstDiscard]
		public static void CatmullRom(float3 p0, float3 p1, float3 p2, float3 p3, Color color)
		{
		}

		[BurstDiscard]
		public static void Arrow(float3 from, float3 to, Color color)
		{
		}

		[BurstDiscard]
		public static void Arrow(float3 from, float3 to, float3 up, float headSize, Color color)
		{
		}

		[BurstDiscard]
		public static void ArrowRelativeSizeHead(float3 from, float3 to, float3 up, float headFraction, Color color)
		{
		}

		[BurstDiscard]
		public static void Arrowhead(float3 center, float3 direction, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void Arrowhead(float3 center, float3 direction, float3 up, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void ArrowheadArc(float3 origin, float3 direction, float offset, float width, Color color)
		{
		}

		[BurstDiscard]
		public static void ArrowheadArc(float3 origin, float3 direction, float offset, Color color)
		{
		}

		[BurstDiscard]
		public static void WireGrid(float3 center, quaternion rotation, int2 cells, float2 totalSize, Color color)
		{
		}

		[BurstDiscard]
		public static void WireTriangle(float3 a, float3 b, float3 c, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.WireRectangle instead")]
		public static void WireRectangleXZ(float3 center, float2 size, Color color)
		{
		}

		[BurstDiscard]
		public static void WireRectangle(float3 center, quaternion rotation, float2 size, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.WireRectangle instead")]
		public static void WireRectangle(Rect rect, Color color)
		{
		}

		[BurstDiscard]
		public static void WireTriangle(float3 center, quaternion rotation, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void WirePentagon(float3 center, quaternion rotation, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void WireHexagon(float3 center, quaternion rotation, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void WirePolygon(float3 center, int vertices, quaternion rotation, float radius, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.SolidRectangle instead")]
		public static void SolidRectangle(Rect rect, Color color)
		{
		}

		[BurstDiscard]
		public static void SolidPlane(float3 center, float3 normal, float2 size, Color color)
		{
		}

		[BurstDiscard]
		public static void SolidPlane(float3 center, quaternion rotation, float2 size, Color color)
		{
		}

		[BurstDiscard]
		public static void WirePlane(float3 center, float3 normal, float2 size, Color color)
		{
		}

		[BurstDiscard]
		public static void WirePlane(float3 center, quaternion rotation, float2 size, Color color)
		{
		}

		[BurstDiscard]
		public static void PlaneWithNormal(float3 center, float3 normal, float2 size, Color color)
		{
		}

		[BurstDiscard]
		public static void PlaneWithNormal(float3 center, quaternion rotation, float2 size, Color color)
		{
		}

		[BurstDiscard]
		public static void SolidTriangle(float3 a, float3 b, float3 c, Color color)
		{
		}

		[BurstDiscard]
		public static void SolidBox(float3 center, float3 size, Color color)
		{
		}

		[BurstDiscard]
		public static void SolidBox(Bounds bounds, Color color)
		{
		}

		[BurstDiscard]
		public static void SolidBox(float3 center, quaternion rotation, float3 size, Color color)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, string text, float size, Color color)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, string text, float size, LabelAlignment alignment, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, string text, float sizeInPixels, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, string text, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, string text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString32Bytes text, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString64Bytes text, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString128Bytes text, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString512Bytes text, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
		}

		[BurstDiscard]
		public static void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString32Bytes text, float size, Color color)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString64Bytes text, float size, Color color)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString128Bytes text, float size, Color color)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString512Bytes text, float size, Color color)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString32Bytes text, float size, LabelAlignment alignment, Color color)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString64Bytes text, float size, LabelAlignment alignment, Color color)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString128Bytes text, float size, LabelAlignment alignment, Color color)
		{
		}

		[BurstDiscard]
		public static void Label3D(float3 position, quaternion rotation, ref FixedString512Bytes text, float size, LabelAlignment alignment, Color color)
		{
		}
	}
	public static class SharedDrawingData
	{
		private class BurstTimeKey
		{
		}

		public static readonly SharedStatic<float> BurstTime = SharedStatic<float>.GetOrCreateUnsafe(4u, 527447541831459905L, -5918529866343830416L);
	}
	public struct RedrawScope : IDisposable
	{
		internal GCHandle gizmos;

		internal int id;

		private static int idCounter;

		internal RedrawScope(DrawingData gizmos, int id)
		{
			this.gizmos = gizmos.gizmosHandle;
			this.id = id;
		}

		internal RedrawScope(DrawingData gizmos)
		{
			this.gizmos = gizmos.gizmosHandle;
			id = idCounter++;
		}

		internal void Draw()
		{
			if (gizmos.IsAllocated && gizmos.Target is DrawingData drawingData)
			{
				drawingData.Draw(this);
			}
		}

		public void Rewind()
		{
			Dispose();
			this = DrawingManager.GetRedrawScope();
		}

		internal void DrawUntilDispose()
		{
			if (gizmos.Target is DrawingData drawingData)
			{
				drawingData.DrawUntilDisposed(this);
			}
		}

		public void Dispose()
		{
			if (gizmos.IsAllocated && gizmos.Target is DrawingData drawingData)
			{
				drawingData.DisposeRedrawScope(this);
			}
			gizmos = default(GCHandle);
		}

		static RedrawScope()
		{
			idCounter = 1;
		}
	}
	public class DrawingData
	{
		public struct Hasher : IEquatable<Hasher>
		{
			private ulong hash;

			public static Hasher NotSupplied => new Hasher
			{
				hash = ulong.MaxValue
			};

			public ulong Hash => hash;

			public static Hasher Create<T>(T init)
			{
				Hasher result = default(Hasher);
				result.Add(init);
				return result;
			}

			public void Add<T>(T hash)
			{
				this.hash = (1572869 * this.hash) ^ (ulong)((long)hash.GetHashCode() + 12289L);
			}

			public override int GetHashCode()
			{
				return (int)hash;
			}

			public bool Equals(Hasher other)
			{
				return hash == other.hash;
			}
		}

		internal struct ProcessedBuilderData
		{
			public enum Type
			{
				Invalid,
				Static,
				Dynamic,
				Persistent
			}

			public struct CapturedState
			{
				public Matrix4x4 matrix;

				public Color color;
			}

			public struct MeshBuffers(Allocator allocator)
			{
				public UnsafeAppendBuffer splitterOutput = new UnsafeAppendBuffer(0, 4, allocator);

				public UnsafeAppendBuffer vertices = new UnsafeAppendBuffer(0, 4, allocator);

				public UnsafeAppendBuffer triangles = new UnsafeAppendBuffer(0, 4, allocator);

				public UnsafeAppendBuffer solidVertices = new UnsafeAppendBuffer(0, 4, allocator);

				public UnsafeAppendBuffer solidTriangles = new UnsafeAppendBuffer(0, 4, allocator);

				public UnsafeAppendBuffer textVertices = new UnsafeAppendBuffer(0, 4, allocator);

				public UnsafeAppendBuffer textTriangles = new UnsafeAppendBuffer(0, 4, allocator);

				public UnsafeAppendBuffer capturedState = new UnsafeAppendBuffer(0, 4, allocator);

				public Bounds bounds = default(Bounds);

				public void Dispose()
				{
					splitterOutput.Dispose();
					vertices.Dispose();
					triangles.Dispose();
					solidVertices.Dispose();
					solidTriangles.Dispose();
					textVertices.Dispose();
					textTriangles.Dispose();
					capturedState.Dispose();
				}

				private static void DisposeIfLarge(ref UnsafeAppendBuffer ls)
				{
					if (ls.Length * 3 < ls.Capacity && ls.Capacity > 1024)
					{
						AllocatorManager.AllocatorHandle allocator = ls.Allocator;
						ls.Dispose();
						ls = new UnsafeAppendBuffer(0, 4, allocator);
					}
				}

				public void DisposeIfLarge()
				{
					DisposeIfLarge(ref splitterOutput);
					DisposeIfLarge(ref vertices);
					DisposeIfLarge(ref triangles);
					DisposeIfLarge(ref solidVertices);
					DisposeIfLarge(ref solidTriangles);
					DisposeIfLarge(ref textVertices);
					DisposeIfLarge(ref textTriangles);
					DisposeIfLarge(ref capturedState);
				}
			}

			public Type type;

			public BuilderData.Meta meta;

			private bool submitted;

			public NativeArray<MeshBuffers> temporaryMeshBuffers;

			private JobHandle buildJob;

			private JobHandle splitterJob;

			public List<MeshWithType> meshes;

			private static int SubmittedJobs;

			public bool isValid => type != Type.Invalid;

			public unsafe UnsafeAppendBuffer* splitterOutputPtr => &((MeshBuffers*)temporaryMeshBuffers.GetUnsafePtr())->splitterOutput;

			public void Init(Type type, BuilderData.Meta meta)
			{
				submitted = false;
				this.type = type;
				this.meta = meta;
				if (meshes == null)
				{
					meshes = new List<MeshWithType>();
				}
				if (!temporaryMeshBuffers.IsCreated)
				{
					temporaryMeshBuffers = new NativeArray<MeshBuffers>(1, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
					temporaryMeshBuffers[0] = new MeshBuffers(Allocator.Persistent);
				}
			}

			public unsafe void SetSplitterJob(DrawingData gizmos, JobHandle splitterJob)
			{
				this.splitterJob = splitterJob;
				if (type == Type.Static)
				{
					GeometryBuilder.CameraInfo cameraInfo = new GeometryBuilder.CameraInfo(null);
					buildJob = GeometryBuilder.Build(gizmos, (MeshBuffers*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(temporaryMeshBuffers), ref cameraInfo, splitterJob);
					SubmittedJobs++;
					if (SubmittedJobs % 8 == 0)
					{
						JobHandle.ScheduleBatchedJobs();
					}
				}
			}

			public unsafe void SchedulePersistFilter(int version, int lastTickVersion, float time, int sceneModeVersion)
			{
				if (type != Type.Persistent)
				{
					throw new InvalidOperationException();
				}
				if (meta.sceneModeVersion != sceneModeVersion)
				{
					meta.version = -1;
				}
				else if (meta.version < lastTickVersion || submitted)
				{
					splitterJob.Complete();
					meta.version = version;
					if (temporaryMeshBuffers[0].splitterOutput.Length == 0)
					{
						meta.version = -1;
						return;
					}
					buildJob.Complete();
					splitterJob = new PersistentFilterJob
					{
						buffer = &((MeshBuffers*)temporaryMeshBuffers.GetUnsafePtr())->splitterOutput,
						time = time
					}.Schedule(splitterJob);
				}
			}

			public bool IsValidForCamera(Camera camera, bool allowGizmos, bool allowCameraDefault)
			{
				if (!allowGizmos && meta.isGizmos)
				{
					return false;
				}
				if (meta.cameraTargets != null)
				{
					return Enumerable.Contains(meta.cameraTargets, camera);
				}
				return allowCameraDefault;
			}

			public unsafe void Schedule(DrawingData gizmos, ref GeometryBuilder.CameraInfo cameraInfo)
			{
				if (type != Type.Static)
				{
					buildJob = GeometryBuilder.Build(gizmos, (MeshBuffers*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(temporaryMeshBuffers), ref cameraInfo, splitterJob);
				}
			}

			public unsafe void BuildMeshes(DrawingData gizmos)
			{
				if (type != Type.Static || !submitted)
				{
					buildJob.Complete();
					GeometryBuilder.BuildMesh(gizmos, meshes, (MeshBuffers*)temporaryMeshBuffers.GetUnsafePtr());
					submitted = true;
				}
			}

			public unsafe void CollectMeshes(List<RenderedMeshWithType> meshes)
			{
				List<MeshWithType> list = this.meshes;
				int num = 0;
				UnsafeAppendBuffer capturedState = temporaryMeshBuffers[0].capturedState;
				_ = capturedState.Length / UnsafeUtility.SizeOf<CapturedState>();
				for (int i = 0; i < list.Count; i++)
				{
					Color color;
					Matrix4x4 matrix;
					int drawingOrderIndex;
					if ((list[i].type & MeshType.Custom) != 0)
					{
						CapturedState capturedState2 = ((CapturedState*)capturedState.Ptr)[num];
						color = capturedState2.color;
						matrix = capturedState2.matrix;
						num++;
						drawingOrderIndex = meta.drawOrderIndex + 1;
					}
					else
					{
						color = Color.white;
						matrix = Matrix4x4.identity;
						drawingOrderIndex = meta.drawOrderIndex;
					}
					meshes.Add(new RenderedMeshWithType
					{
						mesh = list[i].mesh,
						type = list[i].type,
						drawingOrderIndex = drawingOrderIndex,
						color = color,
						matrix = matrix
					});
				}
			}

			private void PoolMeshes(DrawingData gizmos, bool includeCustom)
			{
				if (!isValid)
				{
					throw new InvalidOperationException();
				}
				int num = 0;
				for (int i = 0; i < meshes.Count; i++)
				{
					if ((meshes[i].type & MeshType.Custom) == 0 || (includeCustom && (meshes[i].type & MeshType.Pool) != 0))
					{
						gizmos.PoolMesh(meshes[i].mesh);
						continue;
					}
					meshes[num] = meshes[i];
					num++;
				}
				meshes.RemoveRange(num, meshes.Count - num);
			}

			public void PoolDynamicMeshes(DrawingData gizmos)
			{
				if (type != Type.Static || !submitted)
				{
					PoolMeshes(gizmos, includeCustom: false);
				}
			}

			public void Release(DrawingData gizmos)
			{
				if (!isValid)
				{
					throw new InvalidOperationException();
				}
				PoolMeshes(gizmos, includeCustom: true);
				meshes.Clear();
				type = Type.Invalid;
				splitterJob.Complete();
				buildJob.Complete();
				MeshBuffers value = temporaryMeshBuffers[0];
				value.DisposeIfLarge();
				temporaryMeshBuffers[0] = value;
			}

			public void Dispose()
			{
				if (isValid)
				{
					throw new InvalidOperationException();
				}
				splitterJob.Complete();
				buildJob.Complete();
				if (temporaryMeshBuffers.IsCreated)
				{
					temporaryMeshBuffers[0].Dispose();
					temporaryMeshBuffers.Dispose();
				}
			}
		}

		internal struct SubmittedMesh
		{
			public Mesh mesh;

			public bool temporary;
		}

		[BurstCompile]
		internal struct BuilderData : IDisposable
		{
			public enum State
			{
				Free,
				Reserved,
				Initialized,
				WaitingForSplitter,
				WaitingForUserDefinedJob
			}

			public struct Meta
			{
				public Hasher hasher;

				public RedrawScope redrawScope1;

				public RedrawScope redrawScope2;

				public int version;

				public bool isGizmos;

				public int sceneModeVersion;

				public int drawOrderIndex;

				public Camera[] cameraTargets;
			}

			public struct BitPackedMeta
			{
				private uint flags;

				private const int UniqueIDBitshift = 17;

				private const int IsBuiltInFlagIndex = 16;

				private const int IndexMask = 65535;

				private const int MaxDataIndex = 65535;

				public const int UniqueIdMask = 32767;

				public int dataIndex => (int)(flags & 0xFFFF);

				public int uniqueID => (int)(flags >> 17);

				public bool isBuiltInCommandBuilder => (flags & 0x10000) != 0;

				public BitPackedMeta(int dataIndex, int uniqueID, bool isBuiltInCommandBuilder)
				{
					if (dataIndex > 65535)
					{
						throw new Exception("Too many command builders active. Are some command builders not being disposed?");
					}
					flags = (uint)(dataIndex | (uniqueID << 17) | (isBuiltInCommandBuilder ? 65536 : 0));
				}

				public static bool operator ==(BitPackedMeta lhs, BitPackedMeta rhs)
				{
					return lhs.flags == rhs.flags;
				}

				public static bool operator !=(BitPackedMeta lhs, BitPackedMeta rhs)
				{
					return lhs.flags != rhs.flags;
				}

				public override bool Equals(object obj)
				{
					if (obj is BitPackedMeta bitPackedMeta)
					{
						return flags == bitPackedMeta.flags;
					}
					return false;
				}

				public override int GetHashCode()
				{
					return (int)flags;
				}
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			private unsafe delegate bool AnyBuffersWrittenToDelegate(UnsafeAppendBuffer* buffers, int numBuffers);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			private unsafe delegate void ResetAllBuffersToDelegate(UnsafeAppendBuffer* buffers, int numBuffers);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal unsafe delegate bool AnyBuffersWrittenTo_000002FB$PostfixBurstDelegate(UnsafeAppendBuffer* buffers, int numBuffers);

			internal static class AnyBuffersWrittenTo_000002FB$BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<AnyBuffersWrittenTo_000002FB$PostfixBurstDelegate>(AnyBuffersWrittenTo).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static bool Invoke(UnsafeAppendBuffer* buffers, int numBuffers)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							return ((delegate* unmanaged[Cdecl]<UnsafeAppendBuffer*, int, bool>)functionPointer)(buffers, numBuffers);
						}
					}
					return AnyBuffersWrittenTo$BurstManaged(buffers, numBuffers);
				}
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal unsafe delegate void ResetAllBuffers_000002FC$PostfixBurstDelegate(UnsafeAppendBuffer* buffers, int numBuffers);

			internal static class ResetAllBuffers_000002FC$BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<ResetAllBuffers_000002FC$PostfixBurstDelegate>(ResetAllBuffers).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static void Invoke(UnsafeAppendBuffer* buffers, int numBuffers)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<UnsafeAppendBuffer*, int, void>)functionPointer)(buffers, numBuffers);
							return;
						}
					}
					ResetAllBuffers$BurstManaged(buffers, numBuffers);
				}
			}

			public BitPackedMeta packedMeta;

			public List<SubmittedMesh> meshes;

			public NativeArray<UnsafeAppendBuffer> commandBuffers;

			public bool preventDispose;

			private JobHandle splitterJob;

			private JobHandle disposeDependency;

			private AllowedDelay disposeDependencyDelay;

			private GCHandle disposeGCHandle;

			public Meta meta;

			private static int UniqueIDCounter = 0;

			private unsafe static readonly AnyBuffersWrittenToDelegate AnyBuffersWrittenToInvoke = BurstCompiler.CompileFunctionPointer<AnyBuffersWrittenToDelegate>(AnyBuffersWrittenTo).Invoke;

			private unsafe static readonly ResetAllBuffersToDelegate ResetAllBuffersToInvoke = BurstCompiler.CompileFunctionPointer<ResetAllBuffersToDelegate>(ResetAllBuffers).Invoke;

			public State state { get; private set; }

			public unsafe UnsafeAppendBuffer* bufferPtr => (UnsafeAppendBuffer*)commandBuffers.GetUnsafePtr();

			public void Reserve(int dataIndex, bool isBuiltInCommandBuilder)
			{
				if (state != State.Free)
				{
					throw new InvalidOperationException();
				}
				state = State.Reserved;
				packedMeta = new BitPackedMeta(dataIndex, UniqueIDCounter++ & 0x7FFF, isBuiltInCommandBuilder);
			}

			public void Init(Hasher hasher, RedrawScope frameRedrawScope, RedrawScope customRedrawScope, bool isGizmos, int drawOrderIndex, int sceneModeVersion)
			{
				if (state != State.Reserved)
				{
					throw new InvalidOperationException();
				}
				meta = new Meta
				{
					hasher = hasher,
					redrawScope1 = frameRedrawScope,
					redrawScope2 = customRedrawScope,
					isGizmos = isGizmos,
					version = 0,
					drawOrderIndex = drawOrderIndex,
					sceneModeVersion = sceneModeVersion,
					cameraTargets = null
				};
				if (meshes == null)
				{
					meshes = new List<SubmittedMesh>();
				}
				if (!commandBuffers.IsCreated)
				{
					commandBuffers = new NativeArray<UnsafeAppendBuffer>(JobsUtility.ThreadIndexCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
					for (int i = 0; i < commandBuffers.Length; i++)
					{
						commandBuffers[i] = new UnsafeAppendBuffer(0, 4, Allocator.Persistent);
					}
				}
				state = State.Initialized;
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(AnyBuffersWrittenToDelegate))]
			private unsafe static bool AnyBuffersWrittenTo(UnsafeAppendBuffer* buffers, int numBuffers)
			{
				return AnyBuffersWrittenTo_000002FB$BurstDirectCall.Invoke(buffers, numBuffers);
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(AnyBuffersWrittenToDelegate))]
			private unsafe static void ResetAllBuffers(UnsafeAppendBuffer* buffers, int numBuffers)
			{
				ResetAllBuffers_000002FC$BurstDirectCall.Invoke(buffers, numBuffers);
			}

			public void SubmitWithDependency(GCHandle gcHandle, JobHandle dependency, AllowedDelay allowedDelay)
			{
				state = State.WaitingForUserDefinedJob;
				disposeDependency = dependency;
				disposeDependencyDelay = allowedDelay;
				disposeGCHandle = gcHandle;
			}

			public unsafe void Submit(DrawingData gizmos)
			{
				if (state != State.Initialized)
				{
					throw new InvalidOperationException();
				}
				if (meshes.Count == 0 && !AnyBuffersWrittenToInvoke((UnsafeAppendBuffer*)commandBuffers.GetUnsafeReadOnlyPtr(), commandBuffers.Length))
				{
					Release();
					return;
				}
				this.meta.version = gizmos.version;
				Meta meta = this.meta;
				meta.drawOrderIndex = this.meta.drawOrderIndex * 3;
				int index = gizmos.processedData.Reserve(ProcessedBuilderData.Type.Static, meta);
				meta.drawOrderIndex = this.meta.drawOrderIndex * 3 + 1;
				int index2 = gizmos.processedData.Reserve(ProcessedBuilderData.Type.Dynamic, meta);
				meta.drawOrderIndex = this.meta.drawOrderIndex + 1000000;
				int index3 = gizmos.processedData.Reserve(ProcessedBuilderData.Type.Persistent, meta);
				splitterJob = new StreamSplitter
				{
					inputBuffers = commandBuffers,
					staticBuffer = gizmos.processedData.Get(index).splitterOutputPtr,
					dynamicBuffer = gizmos.processedData.Get(index2).splitterOutputPtr,
					persistentBuffer = gizmos.processedData.Get(index3).splitterOutputPtr
				}.Schedule();
				gizmos.processedData.Get(index).SetSplitterJob(gizmos, splitterJob);
				gizmos.processedData.Get(index2).SetSplitterJob(gizmos, splitterJob);
				gizmos.processedData.Get(index3).SetSplitterJob(gizmos, splitterJob);
				if (meshes.Count > 0)
				{
					List<MeshWithType> list = gizmos.processedData.Get(index2).meshes;
					for (int i = 0; i < meshes.Count; i++)
					{
						list.Add(new MeshWithType
						{
							mesh = meshes[i].mesh,
							type = (MeshType)(9 | (meshes[i].temporary ? 16 : 0))
						});
					}
					meshes.Clear();
				}
				state = State.WaitingForSplitter;
			}

			public void CheckJobDependency(DrawingData gizmos, bool allowBlocking)
			{
				if (state == State.WaitingForUserDefinedJob && (disposeDependency.IsCompleted || (allowBlocking && disposeDependencyDelay == AllowedDelay.EndOfFrame)))
				{
					disposeDependency.Complete();
					disposeDependency = default(JobHandle);
					disposeGCHandle.Free();
					state = State.Initialized;
					Submit(gizmos);
				}
			}

			public void Release()
			{
				if (state == State.Free)
				{
					throw new InvalidOperationException();
				}
				state = State.Free;
				ClearData();
			}

			private unsafe void ClearData()
			{
				disposeDependency.Complete();
				splitterJob.Complete();
				meta = default(Meta);
				disposeDependency = default(JobHandle);
				preventDispose = false;
				meshes.Clear();
				ResetAllBuffers((UnsafeAppendBuffer*)commandBuffers.GetUnsafePtr(), commandBuffers.Length);
			}

			public void Dispose()
			{
				if (state == State.WaitingForUserDefinedJob)
				{
					disposeDependency.Complete();
					disposeGCHandle.Free();
					state = State.WaitingForSplitter;
				}
				if (state == State.Reserved || state == State.Initialized || state == State.WaitingForUserDefinedJob)
				{
					UnityEngine.Debug.LogError("Drawing data is being destroyed, but a drawing instance is still active. Are you sure you have called Dispose on all drawing instances? This will cause a memory leak!");
					return;
				}
				splitterJob.Complete();
				if (commandBuffers.IsCreated)
				{
					for (int i = 0; i < commandBuffers.Length; i++)
					{
						commandBuffers[i].Dispose();
					}
					commandBuffers.Dispose();
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[MonoPInvokeCallback(typeof(AnyBuffersWrittenToDelegate))]
			internal unsafe static bool AnyBuffersWrittenTo$BurstManaged(UnsafeAppendBuffer* buffers, int numBuffers)
			{
				bool flag = false;
				for (int i = 0; i < numBuffers; i++)
				{
					flag |= buffers[i].Length > 0;
				}
				return flag;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[MonoPInvokeCallback(typeof(AnyBuffersWrittenToDelegate))]
			internal unsafe static void ResetAllBuffers$BurstManaged(UnsafeAppendBuffer* buffers, int numBuffers)
			{
				for (int i = 0; i < numBuffers; i++)
				{
					buffers[i].Reset();
				}
			}
		}

		internal struct BuilderDataContainer : IDisposable
		{
			private BuilderData[] data;

			public unsafe int memoryUsage
			{
				get
				{
					int num = 0;
					if (data != null)
					{
						for (int i = 0; i < data.Length; i++)
						{
							NativeArray<UnsafeAppendBuffer> commandBuffers = data[i].commandBuffers;
							for (int j = 0; j < commandBuffers.Length; j++)
							{
								num += commandBuffers[j].Capacity;
							}
							num += data[i].commandBuffers.Length * sizeof(UnsafeAppendBuffer);
						}
					}
					return num;
				}
			}

			public BuilderData.BitPackedMeta Reserve(bool isBuiltInCommandBuilder)
			{
				if (data == null)
				{
					data = new BuilderData[1];
				}
				for (int i = 0; i < data.Length; i++)
				{
					if (data[i].state == BuilderData.State.Free)
					{
						data[i].Reserve(i, isBuiltInCommandBuilder);
						return data[i].packedMeta;
					}
				}
				BuilderData[] array = new BuilderData[data.Length * 2];
				data.CopyTo(array, 0);
				data = array;
				return Reserve(isBuiltInCommandBuilder);
			}

			public void Release(BuilderData.BitPackedMeta meta)
			{
				data[meta.dataIndex].Release();
			}

			public bool StillExists(BuilderData.BitPackedMeta meta)
			{
				int dataIndex = meta.dataIndex;
				if (data == null || dataIndex >= data.Length)
				{
					return false;
				}
				return data[dataIndex].packedMeta == meta;
			}

			public ref BuilderData Get(BuilderData.BitPackedMeta meta)
			{
				int dataIndex = meta.dataIndex;
				if (data[dataIndex].state == BuilderData.State.Free)
				{
					throw new ArgumentException("Data is not reserved");
				}
				if (data[dataIndex].packedMeta != meta)
				{
					throw new ArgumentException("This command builder has already been disposed");
				}
				return ref data[dataIndex];
			}

			public void DisposeCommandBuildersWithJobDependencies(DrawingData gizmos)
			{
				if (data != null)
				{
					for (int i = 0; i < data.Length; i++)
					{
						data[i].CheckJobDependency(gizmos, allowBlocking: false);
					}
					for (int j = 0; j < data.Length; j++)
					{
						data[j].CheckJobDependency(gizmos, allowBlocking: true);
					}
				}
			}

			public void ReleaseAllUnused()
			{
				if (data == null)
				{
					return;
				}
				for (int i = 0; i < data.Length; i++)
				{
					if (data[i].state == BuilderData.State.WaitingForSplitter)
					{
						data[i].Release();
					}
				}
			}

			public void Dispose()
			{
				if (data != null)
				{
					for (int i = 0; i < data.Length; i++)
					{
						data[i].Dispose();
					}
				}
				data = null;
			}
		}

		internal struct ProcessedBuilderDataContainer
		{
			private ProcessedBuilderData[] data;

			private Dictionary<ulong, List<int>> hash2index;

			private Stack<int> freeSlots;

			private Stack<List<int>> freeLists;

			public int memoryUsage
			{
				get
				{
					int num = 0;
					if (data != null)
					{
						for (int i = 0; i < data.Length; i++)
						{
							NativeArray<ProcessedBuilderData.MeshBuffers> temporaryMeshBuffers = data[i].temporaryMeshBuffers;
							for (int j = 0; j < temporaryMeshBuffers.Length; j++)
							{
								int num2 = 0;
								num2 += temporaryMeshBuffers[j].textVertices.Capacity;
								num2 += temporaryMeshBuffers[j].textTriangles.Capacity;
								num2 += temporaryMeshBuffers[j].solidVertices.Capacity;
								num2 += temporaryMeshBuffers[j].solidTriangles.Capacity;
								num2 += temporaryMeshBuffers[j].vertices.Capacity;
								num2 += temporaryMeshBuffers[j].triangles.Capacity;
								num2 += temporaryMeshBuffers[j].capturedState.Capacity;
								num2 += temporaryMeshBuffers[j].splitterOutput.Capacity;
								num += num2;
								UnityEngine.Debug.Log(i + ":" + j + " " + num2);
							}
						}
					}
					return num;
				}
			}

			public int Reserve(ProcessedBuilderData.Type type, BuilderData.Meta meta)
			{
				if (data == null)
				{
					data = new ProcessedBuilderData[0];
					freeSlots = new Stack<int>();
					freeLists = new Stack<List<int>>();
					hash2index = new Dictionary<ulong, List<int>>();
				}
				if (freeSlots.Count == 0)
				{
					ProcessedBuilderData[] array = new ProcessedBuilderData[math.max(4, data.Length * 2)];
					data.CopyTo(array, 0);
					for (int i = data.Length; i < array.Length; i++)
					{
						freeSlots.Push(i);
					}
					data = array;
				}
				int num = freeSlots.Pop();
				data[num].Init(type, meta);
				if (!meta.hasher.Equals(Hasher.NotSupplied))
				{
					if (!hash2index.TryGetValue(meta.hasher.Hash, out var value))
					{
						if (freeLists.Count == 0)
						{
							freeLists.Push(new List<int>());
						}
						List<int> list = (hash2index[meta.hasher.Hash] = freeLists.Pop());
						value = list;
					}
					value.Add(num);
				}
				return num;
			}

			public ref ProcessedBuilderData Get(int index)
			{
				if (!data[index].isValid)
				{
					throw new ArgumentException();
				}
				return ref data[index];
			}

			private void Release(DrawingData gizmos, int i)
			{
				ulong hash = data[i].meta.hasher.Hash;
				if (!data[i].meta.hasher.Equals(Hasher.NotSupplied) && hash2index.TryGetValue(hash, out var value))
				{
					value.Remove(i);
					if (value.Count == 0)
					{
						freeLists.Push(value);
						hash2index.Remove(hash);
					}
				}
				data[i].Release(gizmos);
				freeSlots.Push(i);
			}

			public void SubmitMeshes(DrawingData gizmos, Camera camera, int versionThreshold, bool allowGizmos, bool allowCameraDefault)
			{
				if (data == null)
				{
					return;
				}
				GeometryBuilder.CameraInfo cameraInfo = new GeometryBuilder.CameraInfo(camera);
				int num = 0;
				for (int i = 0; i < data.Length; i++)
				{
					if (data[i].isValid && data[i].meta.version >= versionThreshold && data[i].IsValidForCamera(camera, allowGizmos, allowCameraDefault))
					{
						num++;
						data[i].Schedule(gizmos, ref cameraInfo);
					}
				}
				JobHandle.ScheduleBatchedJobs();
				for (int j = 0; j < data.Length; j++)
				{
					if (data[j].isValid && data[j].meta.version >= versionThreshold && data[j].IsValidForCamera(camera, allowGizmos, allowCameraDefault))
					{
						data[j].BuildMeshes(gizmos);
					}
				}
			}

			public void PoolDynamicMeshes(DrawingData gizmos)
			{
				if (data == null)
				{
					return;
				}
				for (int i = 0; i < data.Length; i++)
				{
					if (data[i].isValid)
					{
						data[i].PoolDynamicMeshes(gizmos);
					}
				}
			}

			public void CollectMeshes(int versionThreshold, List<RenderedMeshWithType> meshes, Camera camera, bool allowGizmos, bool allowCameraDefault)
			{
				if (data == null)
				{
					return;
				}
				for (int i = 0; i < data.Length; i++)
				{
					if (data[i].isValid && data[i].meta.version >= versionThreshold && data[i].IsValidForCamera(camera, allowGizmos, allowCameraDefault))
					{
						data[i].CollectMeshes(meshes);
					}
				}
			}

			public void FilterOldPersistentCommands(int version, int lastTickVersion, float time, int sceneModeVersion)
			{
				if (data == null)
				{
					return;
				}
				for (int i = 0; i < data.Length; i++)
				{
					if (data[i].isValid && data[i].type == ProcessedBuilderData.Type.Persistent)
					{
						data[i].SchedulePersistFilter(version, lastTickVersion, time, sceneModeVersion);
					}
				}
			}

			public bool SetVersion(Hasher hasher, int version)
			{
				if (data == null)
				{
					return false;
				}
				if (hash2index.TryGetValue(hasher.Hash, out var value))
				{
					for (int i = 0; i < value.Count; i++)
					{
						int num = value[i];
						data[num].meta.version = version;
					}
					return true;
				}
				return false;
			}

			public bool SetVersion(RedrawScope scope, int version)
			{
				if (data == null)
				{
					return false;
				}
				bool result = false;
				for (int i = 0; i < data.Length; i++)
				{
					if (data[i].isValid && (data[i].meta.redrawScope1.id == scope.id || data[i].meta.redrawScope2.id == scope.id))
					{
						data[i].meta.version = version;
						result = true;
					}
				}
				return result;
			}

			public bool SetCustomScope(Hasher hasher, RedrawScope scope)
			{
				if (data == null)
				{
					return false;
				}
				if (hash2index.TryGetValue(hasher.Hash, out var value))
				{
					for (int i = 0; i < value.Count; i++)
					{
						int num = value[i];
						data[num].meta.redrawScope2 = scope;
					}
					return true;
				}
				return false;
			}

			public void ReleaseDataOlderThan(DrawingData gizmos, int version)
			{
				if (data == null)
				{
					return;
				}
				for (int i = 0; i < data.Length; i++)
				{
					if (data[i].isValid && data[i].meta.version < version)
					{
						Release(gizmos, i);
					}
				}
			}

			public void ReleaseAllWithHash(DrawingData gizmos, Hasher hasher)
			{
				if (data == null)
				{
					return;
				}
				for (int i = 0; i < data.Length; i++)
				{
					if (data[i].isValid && data[i].meta.hasher.Hash == hasher.Hash)
					{
						Release(gizmos, i);
					}
				}
			}

			public void Dispose(DrawingData gizmos)
			{
				if (data == null)
				{
					return;
				}
				for (int i = 0; i < data.Length; i++)
				{
					if (data[i].isValid)
					{
						Release(gizmos, i);
					}
					data[i].Dispose();
				}
				data = null;
			}
		}

		[Flags]
		internal enum MeshType
		{
			Solid = 1,
			Lines = 2,
			Text = 4,
			Custom = 8,
			Pool = 0x10,
			BaseType = 7
		}

		internal struct MeshWithType
		{
			public Mesh mesh;

			public MeshType type;
		}

		internal struct RenderedMeshWithType
		{
			public Mesh mesh;

			public MeshType type;

			public int drawingOrderIndex;

			public Color color;

			public Matrix4x4 matrix;
		}

		private struct Range
		{
			public int start;

			public int end;
		}

		private class MeshCompareByDrawingOrder : IComparer<RenderedMeshWithType>
		{
			public int Compare(RenderedMeshWithType a, RenderedMeshWithType b)
			{
				int num = (int)(a.type & MeshType.BaseType);
				int num2 = (int)(b.type & MeshType.BaseType);
				if (num == num2)
				{
					return a.drawingOrderIndex - b.drawingOrderIndex;
				}
				return num - num2;
			}
		}

		public struct CommandBufferWrapper
		{
			public CommandBuffer cmd;

			public bool allowDisablingWireframe;

			public RasterCommandBuffer cmd2;

			public void SetWireframe(bool enable)
			{
				if (cmd != null)
				{
					cmd.SetWireframe(enable);
				}
				else if (cmd2 != null && allowDisablingWireframe)
				{
					cmd2.SetWireframe(enable);
				}
			}

			public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass, MaterialPropertyBlock properties)
			{
				if (cmd != null)
				{
					cmd.DrawMesh(mesh, matrix, material, submeshIndex, shaderPass, properties);
				}
				else if (cmd2 != null)
				{
					cmd2.DrawMesh(mesh, matrix, material, submeshIndex, shaderPass, properties);
				}
			}
		}

		internal BuilderDataContainer data;

		internal ProcessedBuilderDataContainer processedData;

		private List<RenderedMeshWithType> meshes = new List<RenderedMeshWithType>();

		private List<Mesh> cachedMeshes = new List<Mesh>();

		private List<Mesh> stagingCachedMeshes = new List<Mesh>();

		private int lastTimeLargestCachedMeshWasUsed;

		internal SDFLookupData fontData;

		private int currentDrawOrderIndex;

		internal int sceneModeVersion;

		public Material surfaceMaterial;

		public Material lineMaterial;

		public Material textMaterial;

		public DrawingSettings settingsAsset;

		private int lastTickVersion;

		private int lastTickVersion2;

		private HashSet<int> persistentRedrawScopes = new HashSet<int>();

		internal GCHandle gizmosHandle;

		public RedrawScope frameRedrawScope;

		private Dictionary<Camera, Range> cameraVersions = new Dictionary<Camera, Range>();

		internal static readonly ProfilerMarker MarkerScheduleJobs = new ProfilerMarker("ScheduleJobs");

		internal static readonly ProfilerMarker MarkerAwaitUserDependencies = new ProfilerMarker("Await user dependencies");

		internal static readonly ProfilerMarker MarkerSchedule = new ProfilerMarker("Schedule");

		internal static readonly ProfilerMarker MarkerBuild = new ProfilerMarker("Build");

		internal static readonly ProfilerMarker MarkerPool = new ProfilerMarker("Pool");

		internal static readonly ProfilerMarker MarkerRelease = new ProfilerMarker("Release");

		internal static readonly ProfilerMarker MarkerBuildMeshes = new ProfilerMarker("Build Meshes");

		internal static readonly ProfilerMarker MarkerCollectMeshes = new ProfilerMarker("Collect Meshes");

		internal static readonly ProfilerMarker MarkerSortMeshes = new ProfilerMarker("Sort Meshes");

		internal static readonly ProfilerMarker LeakTracking = new ProfilerMarker("RedrawScope Leak Tracking");

		private static readonly MeshCompareByDrawingOrder meshSorter = new MeshCompareByDrawingOrder();

		private Plane[] frustrumPlanes = new Plane[6];

		private MaterialPropertyBlock customMaterialProperties = new MaterialPropertyBlock();

		private int adjustedSceneModeVersion => sceneModeVersion + (Application.isPlaying ? 1000 : 0);

		private static float CurrentTime
		{
			get
			{
				if (!Application.isPlaying)
				{
					return Time.realtimeSinceStartup;
				}
				return Time.time;
			}
		}

		public DrawingSettings.Settings settingsRef
		{
			get
			{
				if (settingsAsset == null)
				{
					settingsAsset = DrawingSettings.GetSettingsAsset();
					if (settingsAsset == null)
					{
						throw new InvalidOperationException("ALINE settings could not be found");
					}
				}
				return settingsAsset.settings;
			}
		}

		public int version { get; private set; } = 1;

		private int totalMemoryUsage => data.memoryUsage + processedData.memoryUsage;

		internal int GetNextDrawOrderIndex()
		{
			currentDrawOrderIndex++;
			return currentDrawOrderIndex;
		}

		internal void PoolMesh(Mesh mesh)
		{
			stagingCachedMeshes.Add(mesh);
		}

		private void SortPooledMeshes()
		{
			cachedMeshes.Sort((Mesh a, Mesh b) => b.vertexCount - a.vertexCount);
		}

		internal Mesh GetMesh(int desiredVertexCount)
		{
			if (cachedMeshes.Count > 0)
			{
				int num = 0;
				int num2 = cachedMeshes.Count;
				while (num2 > num + 1)
				{
					int num3 = (num + num2) / 2;
					if (cachedMeshes[num3].vertexCount < desiredVertexCount)
					{
						num2 = num3;
					}
					else
					{
						num = num3;
					}
				}
				Mesh result = cachedMeshes[num];
				if (num == 0)
				{
					lastTimeLargestCachedMeshWasUsed = version;
				}
				cachedMeshes.RemoveAt(num);
				return result;
			}
			Mesh mesh = new Mesh();
			mesh.hideFlags = HideFlags.DontSave;
			mesh.MarkDynamic();
			return mesh;
		}

		internal void LoadFontDataIfNecessary()
		{
			if (fontData.material == null)
			{
				SDFFont font = DefaultFonts.LoadDefaultFont();
				fontData.Dispose();
				fontData = new SDFLookupData(font);
			}
		}

		private static void UpdateTime()
		{
			SharedDrawingData.BurstTime.Data = CurrentTime;
		}

		public CommandBuilder GetBuilder(bool renderInGame = false)
		{
			UpdateTime();
			return new CommandBuilder(this, Hasher.NotSupplied, frameRedrawScope, default(RedrawScope), !renderInGame, isBuiltInCommandBuilder: false, adjustedSceneModeVersion);
		}

		internal CommandBuilder GetBuiltInBuilder(bool renderInGame = false)
		{
			UpdateTime();
			return new CommandBuilder(this, Hasher.NotSupplied, frameRedrawScope, default(RedrawScope), !renderInGame, isBuiltInCommandBuilder: true, adjustedSceneModeVersion);
		}

		public CommandBuilder GetBuilder(RedrawScope redrawScope, bool renderInGame = false)
		{
			UpdateTime();
			return new CommandBuilder(this, Hasher.NotSupplied, frameRedrawScope, redrawScope, !renderInGame, isBuiltInCommandBuilder: false, adjustedSceneModeVersion);
		}

		public CommandBuilder GetBuilder(Hasher hasher, RedrawScope redrawScope = default(RedrawScope), bool renderInGame = false)
		{
			if (!hasher.Equals(Hasher.NotSupplied))
			{
				DiscardData(hasher);
			}
			UpdateTime();
			return new CommandBuilder(this, hasher, frameRedrawScope, redrawScope, !renderInGame, isBuiltInCommandBuilder: false, adjustedSceneModeVersion);
		}

		private void DiscardData(Hasher hasher)
		{
			processedData.ReleaseAllWithHash(this, hasher);
		}

		internal void OnChangingPlayMode()
		{
			sceneModeVersion++;
		}

		public bool Draw(Hasher hasher)
		{
			if (hasher.Equals(Hasher.NotSupplied))
			{
				throw new ArgumentException("Invalid hash value");
			}
			return processedData.SetVersion(hasher, version);
		}

		public bool Draw(Hasher hasher, RedrawScope scope)
		{
			if (hasher.Equals(Hasher.NotSupplied))
			{
				throw new ArgumentException("Invalid hash value");
			}
			processedData.SetCustomScope(hasher, scope);
			return processedData.SetVersion(hasher, version);
		}

		internal void Draw(RedrawScope scope)
		{
			if (scope.id != 0)
			{
				processedData.SetVersion(scope, version);
			}
		}

		internal void DrawUntilDisposed(RedrawScope scope)
		{
			if (scope.id != 0)
			{
				Draw(scope);
				persistentRedrawScopes.Add(scope.id);
			}
		}

		internal void DisposeRedrawScope(RedrawScope scope)
		{
			if (scope.id != 0)
			{
				processedData.SetVersion(scope, -1);
				persistentRedrawScopes.Remove(scope.id);
			}
		}

		public void TickFramePreRender()
		{
			data.DisposeCommandBuildersWithJobDependencies(this);
			processedData.FilterOldPersistentCommands(version, lastTickVersion, CurrentTime, adjustedSceneModeVersion);
			foreach (int persistentRedrawScope in persistentRedrawScopes)
			{
				processedData.SetVersion(new RedrawScope(this, persistentRedrawScope), version);
			}
			processedData.ReleaseDataOlderThan(this, lastTickVersion2 + 1);
			lastTickVersion2 = lastTickVersion;
			lastTickVersion = version;
			currentDrawOrderIndex = 0;
			cachedMeshes.AddRange(stagingCachedMeshes);
			stagingCachedMeshes.Clear();
			SortPooledMeshes();
			if (version - lastTimeLargestCachedMeshWasUsed > 60 && cachedMeshes.Count > 0)
			{
				UnityEngine.Object.DestroyImmediate(cachedMeshes[0]);
				cachedMeshes.RemoveAt(0);
				lastTimeLargestCachedMeshWasUsed = version;
			}
		}

		public void PostRenderCleanup()
		{
			data.ReleaseAllUnused();
			version++;
		}

		private void LoadMaterials()
		{
			if (surfaceMaterial == null)
			{
				surfaceMaterial = Resources.Load<Material>("aline_surface_mat");
			}
			if (lineMaterial == null)
			{
				lineMaterial = Resources.Load<Material>("aline_outline_mat");
			}
			if (fontData.material == null)
			{
				SDFFont font = DefaultFonts.LoadDefaultFont();
				fontData.Dispose();
				fontData = new SDFLookupData(font);
			}
		}

		public DrawingData()
		{
			gizmosHandle = GCHandle.Alloc(this, GCHandleType.Weak);
			LoadMaterials();
		}

		private static int CeilLog2(int x)
		{
			return (int)math.ceil(math.log2(x));
		}

		public void Render(Camera cam, bool allowGizmos, CommandBufferWrapper commandBuffer, bool allowCameraDefault)
		{
			LoadMaterials();
			if (surfaceMaterial == null || lineMaterial == null)
			{
				return;
			}
			Plane[] planes = frustrumPlanes;
			GeometryUtility.CalculateFrustumPlanes(cam, planes);
			if (!cameraVersions.TryGetValue(cam, out var value))
			{
				value = new Range
				{
					start = int.MinValue,
					end = int.MinValue
				};
			}
			if (value.end > lastTickVersion)
			{
				value.end = version + 1;
			}
			else
			{
				value = new Range
				{
					start = value.end,
					end = version + 1
				};
			}
			value.start = Mathf.Max(value.start, lastTickVersion2 + 1);
			DrawingSettings.Settings settings = settingsRef;
			commandBuffer.SetWireframe(enable: false);
			if (0 == 0)
			{
				processedData.SubmitMeshes(this, cam, value.start, allowGizmos, allowCameraDefault);
				meshes.Clear();
				processedData.CollectMeshes(value.start, meshes, cam, allowGizmos, allowCameraDefault);
				processedData.PoolDynamicMeshes(this);
				meshes.Sort(meshSorter);
				int nameID = Shader.PropertyToID("_Color");
				int nameID2 = Shader.PropertyToID("_FadeColor");
				Color color = new Color(1f, 1f, 1f, settings.solidOpacity);
				Color value2 = new Color(1f, 1f, 1f, settings.solidOpacityBehindObjects);
				Color value3 = new Color(1f, 1f, 1f, settings.lineOpacity);
				Color value4 = new Color(1f, 1f, 1f, settings.lineOpacityBehindObjects);
				Color value5 = new Color(1f, 1f, 1f, settings.textOpacity);
				Color value6 = new Color(1f, 1f, 1f, settings.textOpacityBehindObjects);
				int num = 0;
				while (num < meshes.Count)
				{
					int i = num + 1;
					MeshType meshType;
					for (meshType = meshes[num].type & MeshType.BaseType; i < meshes.Count && (meshes[i].type & MeshType.BaseType) == meshType; i++)
					{
					}
					customMaterialProperties.Clear();
					Material material;
					switch (meshType)
					{
					case MeshType.Solid:
						material = surfaceMaterial;
						customMaterialProperties.SetColor(nameID, color);
						customMaterialProperties.SetColor(nameID2, value2);
						break;
					case MeshType.Lines:
						material = lineMaterial;
						customMaterialProperties.SetColor(nameID, value3);
						customMaterialProperties.SetColor(nameID2, value4);
						break;
					case MeshType.Text:
						material = fontData.material;
						customMaterialProperties.SetColor(nameID, value5);
						customMaterialProperties.SetColor(nameID2, value6);
						break;
					default:
						throw new InvalidOperationException("Invalid mesh type");
					}
					for (int j = 0; j < material.passCount; j++)
					{
						for (int k = num; k < i; k++)
						{
							RenderedMeshWithType renderedMeshWithType = meshes[k];
							if ((renderedMeshWithType.type & MeshType.Custom) != 0)
							{
								if (GeometryUtility.TestPlanesAABB(planes, TransformBoundingBox(renderedMeshWithType.matrix, renderedMeshWithType.mesh.bounds)))
								{
									customMaterialProperties.SetColor(nameID, color * renderedMeshWithType.color);
									commandBuffer.DrawMesh(renderedMeshWithType.mesh, renderedMeshWithType.matrix, material, 0, j, customMaterialProperties);
									customMaterialProperties.SetColor(nameID, color);
								}
							}
							else if (GeometryUtility.TestPlanesAABB(planes, renderedMeshWithType.mesh.bounds))
							{
								commandBuffer.DrawMesh(renderedMeshWithType.mesh, Matrix4x4.identity, material, 0, j, customMaterialProperties);
							}
						}
					}
					num = i;
				}
				meshes.Clear();
			}
			cameraVersions[cam] = value;
		}

		private static Bounds TransformBoundingBox(Matrix4x4 matrix, Bounds bounds)
		{
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			Bounds result = new Bounds(matrix.MultiplyPoint(min), Vector3.zero);
			result.Encapsulate(matrix.MultiplyPoint(new Vector3(min.x, min.y, max.z)));
			result.Encapsulate(matrix.MultiplyPoint(new Vector3(min.x, max.y, min.z)));
			result.Encapsulate(matrix.MultiplyPoint(new Vector3(min.x, max.y, max.z)));
			result.Encapsulate(matrix.MultiplyPoint(new Vector3(max.x, min.y, min.z)));
			result.Encapsulate(matrix.MultiplyPoint(new Vector3(max.x, min.y, max.z)));
			result.Encapsulate(matrix.MultiplyPoint(new Vector3(max.x, max.y, min.z)));
			result.Encapsulate(matrix.MultiplyPoint(new Vector3(max.x, max.y, max.z)));
			return result;
		}

		public void ClearData()
		{
			gizmosHandle.Free();
			data.Dispose();
			processedData.Dispose(this);
			for (int i = 0; i < cachedMeshes.Count; i++)
			{
				UnityEngine.Object.DestroyImmediate(cachedMeshes[i]);
			}
			cachedMeshes.Clear();
			fontData.Dispose();
		}
	}
	public static class GizmoContext
	{
		private static HashSet<Transform> selectedTransforms = new HashSet<Transform>();

		internal static bool drawingGizmos;

		internal static bool dirty;

		private static int selectionSizeInternal;

		public static int selectionSize
		{
			get
			{
				Refresh();
				return selectionSizeInternal;
			}
			private set
			{
				selectionSizeInternal = value;
			}
		}

		internal static void SetDirty()
		{
			dirty = true;
		}

		private static void Refresh()
		{
		}

		public static bool InSelection(UnityEngine.Component c)
		{
			return InSelection(c.transform);
		}

		public static bool InSelection(Transform tr)
		{
			Refresh();
			Transform item = tr;
			while (tr != null)
			{
				if (selectedTransforms.Contains(tr))
				{
					selectedTransforms.Add(item);
					return true;
				}
				tr = tr.parent;
			}
			return false;
		}

		public static bool InActiveSelection(UnityEngine.Component c)
		{
			return InActiveSelection(c.transform);
		}

		public static bool InActiveSelection(Transform tr)
		{
			return false;
		}
	}
	public interface IDrawGizmos
	{
		void DrawGizmos();
	}
	public enum DetectedRenderPipeline
	{
		BuiltInOrCustom,
		HDRP,
		URP
	}
	[ExecuteAlways]
	[AddComponentMenu("")]
	public class DrawingManager : MonoBehaviour
	{
		public DrawingData gizmos;

		private static List<IDrawGizmos> gizmoDrawers = new List<IDrawGizmos>();

		private static Dictionary<Type, bool> gizmoDrawerTypes = new Dictionary<Type, bool>();

		private static DrawingManager _instance;

		private bool framePassed;

		private int lastFrameCount = int.MinValue;

		private float lastFrameTime = float.PositiveInfinity;

		private int lastFilterFrame;

		[SerializeField]
		private bool actuallyEnabled;

		private RedrawScope previousFrameRedrawScope;

		public static bool allowRenderToRenderTextures = false;

		public static bool drawToAllCameras = false;

		public static float lineWidthMultiplier = 1f;

		private CommandBuffer commandBuffer;

		[NonSerialized]
		private DetectedRenderPipeline detectedRenderPipeline;

		private HashSet<ScriptableRenderer> scriptableRenderersWithPass = new HashSet<ScriptableRenderer>();

		private AlineURPRenderPassFeature renderPassFeature;

		private static readonly ProfilerMarker MarkerALINE = new ProfilerMarker("ALINE");

		private static readonly ProfilerMarker MarkerCommandBuffer = new ProfilerMarker("Executing command buffer");

		private static readonly ProfilerMarker MarkerFrameTick = new ProfilerMarker("Frame Tick");

		private static readonly ProfilerMarker MarkerFilterDestroyedObjects = new ProfilerMarker("Filter destroyed objects");

		internal static readonly ProfilerMarker MarkerRefreshSelectionCache = new ProfilerMarker("Refresh Selection Cache");

		private static readonly ProfilerMarker MarkerGizmosAllowed = new ProfilerMarker("GizmosAllowed");

		private static readonly ProfilerMarker MarkerDrawGizmos = new ProfilerMarker("DrawGizmos");

		private static readonly ProfilerMarker MarkerSubmitGizmos = new ProfilerMarker("Submit Gizmos");

		private const float NO_DRAWING_TIMEOUT_SECS = 10f;

		private readonly Dictionary<Type, bool> typeToGizmosEnabled = new Dictionary<Type, bool>();

		public static DrawingManager instance
		{
			get
			{
				if (_instance == null)
				{
					Init();
				}
				return _instance;
			}
		}

		public static void Init()
		{
			if (!(_instance != null))
			{
				GameObject gameObject = new GameObject("RetainedGizmos")
				{
					hideFlags = (HideFlags.HideAndDontSave | HideFlags.HideInInspector)
				};
				_instance = gameObject.AddComponent<DrawingManager>();
				if (Application.isPlaying)
				{
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
				}
			}
		}

		private void RefreshRenderPipelineMode()
		{
			if (((RenderPipelineManager.currentPipeline != null) ? RenderPipelineManager.currentPipeline.GetType() : null) == typeof(UniversalRenderPipeline))
			{
				detectedRenderPipeline = DetectedRenderPipeline.URP;
			}
			else
			{
				detectedRenderPipeline = DetectedRenderPipeline.BuiltInOrCustom;
			}
		}

		private void OnEnable()
		{
			if (_instance == null)
			{
				_instance = this;
			}
			if (!(_instance != this))
			{
				actuallyEnabled = true;
				if (gizmos == null)
				{
					gizmos = new DrawingData();
				}
				gizmos.frameRedrawScope = new RedrawScope(gizmos);
				Draw.builder = gizmos.GetBuiltInBuilder();
				Draw.ingame_builder = gizmos.GetBuiltInBuilder(renderInGame: true);
				commandBuffer = new CommandBuffer();
				commandBuffer.name = "ALINE Gizmos";
				Camera.onPostRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPostRender, new Camera.CameraCallback(PostRender));
				RenderPipelineManager.beginContextRendering += BeginContextRendering;
				RenderPipelineManager.beginCameraRendering += BeginCameraRendering;
				RenderPipelineManager.endCameraRendering += EndCameraRendering;
			}
		}

		private void BeginContextRendering(ScriptableRenderContext context, List<Camera> cameras)
		{
			RefreshRenderPipelineMode();
		}

		private void BeginFrameRendering(ScriptableRenderContext context, Camera[] cameras)
		{
			RefreshRenderPipelineMode();
		}

		private void BeginCameraRendering(ScriptableRenderContext context, Camera camera)
		{
			if (detectedRenderPipeline != DetectedRenderPipeline.URP)
			{
				return;
			}
			UniversalAdditionalCameraData universalAdditionalCameraData = camera.GetUniversalAdditionalCameraData();
			if (universalAdditionalCameraData != null)
			{
				ScriptableRenderer scriptableRenderer = universalAdditionalCameraData.scriptableRenderer;
				if (renderPassFeature == null)
				{
					renderPassFeature = ScriptableObject.CreateInstance<AlineURPRenderPassFeature>();
				}
				renderPassFeature.AddRenderPasses(scriptableRenderer);
			}
		}

		private void OnDisable()
		{
			if (actuallyEnabled)
			{
				actuallyEnabled = false;
				commandBuffer.Dispose();
				commandBuffer = null;
				Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(PostRender));
				RenderPipelineManager.beginContextRendering -= BeginContextRendering;
				RenderPipelineManager.beginCameraRendering -= BeginCameraRendering;
				RenderPipelineManager.endCameraRendering -= EndCameraRendering;
				if (gizmos != null)
				{
					Draw.builder.DiscardAndDisposeInternal();
					Draw.ingame_builder.DiscardAndDisposeInternal();
					gizmos.ClearData();
				}
				if (renderPassFeature != null)
				{
					UnityEngine.Object.DestroyImmediate(renderPassFeature);
					renderPassFeature = null;
				}
			}
		}

		private void OnEditorUpdate()
		{
			framePassed = true;
			CleanupIfNoCameraRendered();
		}

		private void Update()
		{
			if (actuallyEnabled)
			{
				CleanupIfNoCameraRendered();
			}
		}

		private void CleanupIfNoCameraRendered()
		{
			if (Time.frameCount > lastFrameCount + 1)
			{
				CheckFrameTicking();
				gizmos.PostRenderCleanup();
			}
			if (Time.realtimeSinceStartup - lastFrameTime > 10f)
			{
				Draw.builder.DiscardAndDisposeInternal();
				Draw.ingame_builder.DiscardAndDisposeInternal();
				Draw.builder = gizmos.GetBuiltInBuilder();
				Draw.ingame_builder = gizmos.GetBuiltInBuilder(renderInGame: true);
				lastFrameTime = Time.realtimeSinceStartup;
				RemoveDestroyedGizmoDrawers();
			}
			if (lastFilterFrame - Time.frameCount > 5)
			{
				lastFilterFrame = Time.frameCount;
				RemoveDestroyedGizmoDrawers();
			}
		}

		internal void ExecuteCustomRenderPass(ScriptableRenderContext context, Camera camera)
		{
			commandBuffer.Clear();
			SubmitFrame(camera, new DrawingData.CommandBufferWrapper
			{
				cmd = commandBuffer
			}, usingRenderPipeline: true);
			context.ExecuteCommandBuffer(commandBuffer);
		}

		internal void ExecuteCustomRenderGraphPass(DrawingData.CommandBufferWrapper cmd, Camera camera)
		{
			SubmitFrame(camera, cmd, usingRenderPipeline: true);
		}

		private void EndCameraRendering(ScriptableRenderContext context, Camera camera)
		{
			if (detectedRenderPipeline == DetectedRenderPipeline.BuiltInOrCustom)
			{
				ExecuteCustomRenderPass(context, camera);
			}
		}

		private void PostRender(Camera camera)
		{
			commandBuffer.Clear();
			SubmitFrame(camera, new DrawingData.CommandBufferWrapper
			{
				cmd = commandBuffer
			}, usingRenderPipeline: false);
			Graphics.ExecuteCommandBuffer(commandBuffer);
		}

		private void CheckFrameTicking()
		{
			if (Time.frameCount != lastFrameCount)
			{
				framePassed = true;
				lastFrameCount = Time.frameCount;
				lastFrameTime = Time.realtimeSinceStartup;
				previousFrameRedrawScope = gizmos.frameRedrawScope;
				gizmos.frameRedrawScope = new RedrawScope(gizmos);
				Draw.builder.DisposeInternal();
				Draw.ingame_builder.DisposeInternal();
				Draw.builder = gizmos.GetBuiltInBuilder();
				Draw.ingame_builder = gizmos.GetBuiltInBuilder(renderInGame: true);
			}
			else if (framePassed && Application.isPlaying)
			{
				previousFrameRedrawScope.Draw();
			}
			if (framePassed)
			{
				gizmos.TickFramePreRender();
				framePassed = false;
			}
		}

		internal void SubmitFrame(Camera camera, DrawingData.CommandBufferWrapper cmd, bool usingRenderPipeline)
		{
			bool flag = false;
			bool allowCameraDefault = allowRenderToRenderTextures || drawToAllCameras || camera.targetTexture == null || flag;
			CheckFrameTicking();
			Submit(camera, cmd, usingRenderPipeline, allowCameraDefault);
			gizmos.PostRenderCleanup();
		}

		private bool ShouldDrawGizmos(UnityEngine.Object obj)
		{
			return true;
		}

		private static void RemoveDestroyedGizmoDrawers()
		{
			int num = 0;
			for (int i = 0; i < gizmoDrawers.Count; i++)
			{
				IDrawGizmos drawGizmos = gizmoDrawers[i];
				if ((bool)(drawGizmos as MonoBehaviour))
				{
					gizmoDrawers[num] = drawGizmos;
					num++;
				}
			}
			gizmoDrawers.RemoveRange(num, gizmoDrawers.Count - num);
		}

		private void Submit(Camera camera, DrawingData.CommandBufferWrapper cmd, bool usingRenderPipeline, bool allowCameraDefault)
		{
			bool allowGizmos = false;
			Draw.builder.DisposeInternal();
			Draw.ingame_builder.DisposeInternal();
			gizmos.Render(camera, allowGizmos, cmd, allowCameraDefault);
			Draw.builder = gizmos.GetBuiltInBuilder();
			Draw.ingame_builder = gizmos.GetBuiltInBuilder(renderInGame: true);
		}

		public static void Register(IDrawGizmos item)
		{
			Type type = item.GetType();
			if (!gizmoDrawerTypes.TryGetValue(type, out var value))
			{
				BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
				MethodInfo obj = type.GetMethod("DrawGizmos", bindingAttr) ?? type.GetMethod("Pathfinding.Drawing.IDrawGizmos.DrawGizmos", bindingAttr) ?? type.GetMethod("Drawing.IDrawGizmos.DrawGizmos", bindingAttr);
				if (obj == null)
				{
					throw new Exception("Could not find the DrawGizmos method in type " + type.Name);
				}
				value = obj.DeclaringType != typeof(MonoBehaviourGizmos);
				gizmoDrawerTypes[type] = value;
			}
			if (value)
			{
				gizmoDrawers.Add(item);
			}
		}

		public static CommandBuilder GetBuilder(bool renderInGame = false)
		{
			return instance.gizmos.GetBuilder(renderInGame);
		}

		public static CommandBuilder GetBuilder(RedrawScope redrawScope, bool renderInGame = false)
		{
			return instance.gizmos.GetBuilder(redrawScope, renderInGame);
		}

		public static CommandBuilder GetBuilder(DrawingData.Hasher hasher, RedrawScope redrawScope = default(RedrawScope), bool renderInGame = false)
		{
			return instance.gizmos.GetBuilder(hasher, redrawScope, renderInGame);
		}

		public static RedrawScope GetRedrawScope()
		{
			RedrawScope result = new RedrawScope(instance.gizmos);
			result.DrawUntilDispose();
			return result;
		}
	}
	public class DrawingSettings : ScriptableObject
	{
		[Serializable]
		public class Settings
		{
			public float lineOpacity = 1f;

			public float solidOpacity = 0.55f;

			public float textOpacity = 1f;

			public float lineOpacityBehindObjects = 0.12f;

			public float solidOpacityBehindObjects = 0.45f;

			public float textOpacityBehindObjects = 0.9f;

			public float curveResolution = 1f;
		}

		public const string SettingsPathCompatibility = "Assets/Settings/ALINE.asset";

		public const string SettingsName = "ALINE";

		public const string SettingsPath = "Assets/Settings/Resources/ALINE.asset";

		[SerializeField]
		private int version;

		public Settings settings;

		public static Settings DefaultSettings => new Settings();

		public static DrawingSettings GetSettingsAsset()
		{
			return Resources.Load<DrawingSettings>("ALINE");
		}
	}
	public static class DrawingUtilities
	{
		private static List<UnityEngine.Component> componentBuffer = new List<UnityEngine.Component>();

		public static Bounds BoundsFrom(GameObject gameObject)
		{
			return BoundsFrom(gameObject.transform);
		}

		public static Bounds BoundsFrom(Transform transform)
		{
			transform.gameObject.GetComponents(componentBuffer);
			Bounds result = new Bounds(transform.position, Vector3.zero);
			for (int i = 0; i < componentBuffer.Count; i++)
			{
				UnityEngine.Component component = componentBuffer[i];
				if (component is Collider collider)
				{
					result.Encapsulate(collider.bounds);
				}
				else if (component is Collider2D collider2D)
				{
					result.Encapsulate(collider2D.bounds);
				}
				else if (component is MeshRenderer meshRenderer)
				{
					result.Encapsulate(meshRenderer.bounds);
				}
				else if (component is SpriteRenderer spriteRenderer)
				{
					result.Encapsulate(spriteRenderer.bounds);
				}
			}
			componentBuffer.Clear();
			int childCount = transform.childCount;
			for (int j = 0; j < childCount; j++)
			{
				result.Encapsulate(BoundsFrom(transform.GetChild(j)));
			}
			return result;
		}

		public static Bounds BoundsFrom(List<Vector3> points)
		{
			if (points.Count == 0)
			{
				throw new ArgumentException("At least 1 point is required");
			}
			Vector3 vector = points[0];
			Vector3 vector2 = points[0];
			for (int i = 0; i < points.Count; i++)
			{
				vector = Vector3.Min(vector, points[i]);
				vector2 = Vector3.Max(vector2, points[i]);
			}
			return new Bounds((vector2 + vector) * 0.5f, (vector2 - vector) * 0.5f);
		}

		public static Bounds BoundsFrom(Vector3[] points)
		{
			if (points.Length == 0)
			{
				throw new ArgumentException("At least 1 point is required");
			}
			Vector3 vector = points[0];
			Vector3 vector2 = points[0];
			for (int i = 0; i < points.Length; i++)
			{
				vector = Vector3.Min(vector, points[i]);
				vector2 = Vector3.Max(vector2, points[i]);
			}
			return new Bounds((vector2 + vector) * 0.5f, (vector2 - vector) * 0.5f);
		}

		public static Bounds BoundsFrom(NativeArray<float3> points)
		{
			if (points.Length == 0)
			{
				throw new ArgumentException("At least 1 point is required");
			}
			float3 float5 = points[0];
			float3 float6 = points[0];
			for (int i = 0; i < points.Length; i++)
			{
				float5 = math.min(float5, points[i]);
				float6 = math.max(float6, points[i]);
			}
			return new Bounds((float6 + float5) * 0.5f, (float6 - float5) * 0.5f);
		}
	}
	internal static class GeometryBuilder
	{
		public struct CameraInfo
		{
			public float3 cameraPosition;

			public quaternion cameraRotation;

			public float2 cameraDepthToPixelSize;

			public bool cameraIsOrthographic;

			public CameraInfo(Camera camera)
			{
				Transform transform = camera?.transform;
				cameraPosition = ((transform != null) ? ((float3)transform.position) : float3.zero);
				cameraRotation = ((transform != null) ? ((quaternion)transform.rotation) : quaternion.identity);
				cameraDepthToPixelSize = ((camera != null) ? CameraDepthToPixelSize(camera) : ((float2)0));
				cameraIsOrthographic = camera != null && camera.orthographic;
			}
		}

		internal unsafe static JobHandle Build(DrawingData gizmos, DrawingData.ProcessedBuilderData.MeshBuffers* buffers, ref CameraInfo cameraInfo, JobHandle dependency)
		{
			return new GeometryBuilderJob
			{
				buffers = buffers,
				currentMatrix = Matrix4x4.identity,
				currentLineWidthData = new CommandBuilder.LineWidthData
				{
					pixels = 1f,
					automaticJoins = false
				},
				lineWidthMultiplier = DrawingManager.lineWidthMultiplier,
				currentColor = Color.white,
				cameraPosition = cameraInfo.cameraPosition,
				cameraRotation = cameraInfo.cameraRotation,
				cameraDepthToPixelSize = cameraInfo.cameraDepthToPixelSize,
				cameraIsOrthographic = cameraInfo.cameraIsOrthographic,
				characterInfo = (SDFCharacter*)gizmos.fontData.characters.GetUnsafeReadOnlyPtr(),
				characterInfoLength = gizmos.fontData.characters.Length,
				maxPixelError = 0.5f / math.max(0.1f, gizmos.settingsRef.curveResolution)
			}.Schedule(dependency);
		}

		private static float2 CameraDepthToPixelSize(Camera camera)
		{
			if (camera.orthographic)
			{
				return new float2(0f, 2f * camera.orthographicSize / (float)camera.pixelHeight);
			}
			return new float2(Mathf.Tan(camera.fieldOfView * (MathF.PI / 180f) * 0.5f) / (0.5f * (float)camera.pixelHeight), 0f);
		}

		private unsafe static NativeArray<T> ConvertExistingDataToNativeArray<T>(UnsafeAppendBuffer data) where T : struct
		{
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>(data.Ptr, data.Length / UnsafeUtility.SizeOf<T>(), Allocator.Invalid);
		}

		internal unsafe static void BuildMesh(DrawingData gizmos, List<DrawingData.MeshWithType> meshes, DrawingData.ProcessedBuilderData.MeshBuffers* inputBuffers)
		{
			if (inputBuffers->triangles.Length > 0)
			{
				Mesh mesh = AssignMeshData<GeometryBuilderJob.Vertex>(gizmos, inputBuffers->bounds, inputBuffers->vertices, inputBuffers->triangles, MeshLayouts.MeshLayout);
				meshes.Add(new DrawingData.MeshWithType
				{
					mesh = mesh,
					type = DrawingData.MeshType.Lines
				});
			}
			if (inputBuffers->solidTriangles.Length > 0)
			{
				Mesh mesh2 = AssignMeshData<GeometryBuilderJob.Vertex>(gizmos, inputBuffers->bounds, inputBuffers->solidVertices, inputBuffers->solidTriangles, MeshLayouts.MeshLayout);
				meshes.Add(new DrawingData.MeshWithType
				{
					mesh = mesh2,
					type = DrawingData.MeshType.Solid
				});
			}
			if (inputBuffers->textTriangles.Length > 0)
			{
				Mesh mesh3 = AssignMeshData<GeometryBuilderJob.TextVertex>(gizmos, inputBuffers->bounds, inputBuffers->textVertices, inputBuffers->textTriangles, MeshLayouts.MeshLayoutText);
				meshes.Add(new DrawingData.MeshWithType
				{
					mesh = mesh3,
					type = DrawingData.MeshType.Text
				});
			}
		}

		private static Mesh AssignMeshData<VertexType>(DrawingData gizmos, Bounds bounds, UnsafeAppendBuffer vertices, UnsafeAppendBuffer triangles, VertexAttributeDescriptor[] layout) where VertexType : struct
		{
			NativeArray<VertexType> data = ConvertExistingDataToNativeArray<VertexType>(vertices);
			NativeArray<int> data2 = ConvertExistingDataToNativeArray<int>(triangles);
			Mesh mesh = gizmos.GetMesh(data.Length);
			mesh.SetVertexBufferParams(math.ceilpow2(data.Length), layout);
			mesh.SetIndexBufferParams(math.ceilpow2(data2.Length), IndexFormat.UInt32);
			mesh.SetVertexBufferData(data, 0, 0, data.Length);
			mesh.SetIndexBufferData(data2, 0, 0, data2.Length, MeshUpdateFlags.DontValidateIndices);
			mesh.subMeshCount = 1;
			SubMeshDescriptor desc = new SubMeshDescriptor(0, data2.Length)
			{
				vertexCount = data.Length,
				bounds = bounds
			};
			mesh.SetSubMesh(0, desc, MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
			mesh.bounds = bounds;
			return mesh;
		}
	}
	internal static class MeshLayouts
	{
		internal static readonly VertexAttributeDescriptor[] MeshLayout = new VertexAttributeDescriptor[4]
		{
			new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0),
			new VertexAttributeDescriptor(VertexAttribute.Normal),
			new VertexAttributeDescriptor(VertexAttribute.Color, VertexAttributeFormat.UNorm8, 4),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2)
		};

		internal static readonly VertexAttributeDescriptor[] MeshLayoutText = new VertexAttributeDescriptor[3]
		{
			new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0),
			new VertexAttributeDescriptor(VertexAttribute.Color, VertexAttributeFormat.UNorm8, 4),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2)
		};
	}
	[BurstCompile(FloatMode = FloatMode.Default)]
	internal struct GeometryBuilderJob : IJob
	{
		public struct Vertex
		{
			public float3 position;

			public float3 uv2;

			public Color32 color;

			public float2 uv;
		}

		public struct TextVertex
		{
			public float3 position;

			public Color32 color;

			public float2 uv;
		}

		[NativeDisableUnsafePtrRestriction]
		public unsafe DrawingData.ProcessedBuilderData.MeshBuffers* buffers;

		[NativeDisableUnsafePtrRestriction]
		public unsafe SDFCharacter* characterInfo;

		public int characterInfoLength;

		public Color32 currentColor;

		public float4x4 currentMatrix;

		public CommandBuilder.LineWidthData currentLineWidthData;

		public float lineWidthMultiplier;

		private float3 minBounds;

		private float3 maxBounds;

		public float3 cameraPosition;

		public quaternion cameraRotation;

		public float2 cameraDepthToPixelSize;

		public float maxPixelError;

		public bool cameraIsOrthographic;

		private float3 lastNormalizedLineDir;

		private float lastLineWidth;

		public const float MaxCirclePixelError = 0.5f;

		public const int VerticesPerCharacter = 4;

		public const int TrianglesPerCharacter = 6;

		internal static readonly float4[] BoxVertices = new float4[8]
		{
			new float4(-1f, -1f, -1f, 1f),
			new float4(-1f, -1f, 1f, 1f),
			new float4(-1f, 1f, -1f, 1f),
			new float4(-1f, 1f, 1f, 1f),
			new float4(1f, -1f, -1f, 1f),
			new float4(1f, -1f, 1f, 1f),
			new float4(1f, 1f, -1f, 1f),
			new float4(1f, 1f, 1f, 1f)
		};

		internal static readonly int[] BoxTriangles = new int[36]
		{
			0, 1, 5, 0, 5, 4, 7, 3, 2, 7,
			2, 6, 0, 1, 3, 0, 3, 2, 4, 5,
			7, 4, 7, 6, 1, 3, 7, 1, 7, 5,
			0, 2, 6, 0, 6, 4
		};

		public const int MaxStackSize = 32;

		private unsafe static void Add<T>(UnsafeAppendBuffer* buffer, T value) where T : unmanaged
		{
			int num = UnsafeUtility.SizeOf<T>();
			*(T*)(buffer->Ptr + buffer->Length) = value;
			buffer->Length += num;
		}

		private unsafe static void Reserve(UnsafeAppendBuffer* buffer, int size)
		{
			int num = buffer->Length + size;
			if (num > buffer->Capacity)
			{
				buffer->SetCapacity(math.max(num, buffer->Capacity * 2));
			}
		}

		internal static float3 PerspectiveDivide(float4 p)
		{
			return p.xyz * math.rcp(p.w);
		}

		private unsafe void AddText(ushort* text, CommandBuilder.TextData textData, Color32 color)
		{
			float3 pivot = PerspectiveDivide(math.mul(currentMatrix, new float4(textData.center, 1f)));
			AddTextInternal(text, pivot, math.mul(cameraRotation, new float3(1f, 0f, 0f)), math.mul(cameraRotation, new float3(0f, 1f, 0f)), textData.alignment, textData.sizeInPixels, sizeIsInPixels: true, textData.numCharacters, color);
		}

		private unsafe void AddText3D(ushort* text, CommandBuilder.TextData3D textData, Color32 color)
		{
			float3 pivot = PerspectiveDivide(math.mul(currentMatrix, new float4(textData.center, 1f)));
			float4x4 float4x5 = math.mul(currentMatrix, new float4x4(textData.rotation, float3.zero));
			AddTextInternal(text, pivot, float4x5.c0.xyz, float4x5.c1.xyz, textData.alignment, textData.size, sizeIsInPixels: false, textData.numCharacters, color);
		}

		private unsafe void AddTextInternal(ushort* text, float3 pivot, float3 right, float3 up, LabelAlignment alignment, float size, bool sizeIsInPixels, int numCharacters, Color32 color)
		{
			float num = math.abs(math.dot(pivot - cameraPosition, math.mul(cameraRotation, new float3(0f, 0f, 1f))));
			float num2 = cameraDepthToPixelSize.x * num + cameraDepthToPixelSize.y;
			float num3 = size;
			if (sizeIsInPixels)
			{
				num3 *= num2;
			}
			right *= num3;
			up *= num3;
			float x = 0f;
			float num4 = 0f;
			float num5 = 1f;
			for (int i = 0; i < numCharacters; i++)
			{
				ushort num6 = text[i];
				if (num6 == ushort.MaxValue)
				{
					x = math.max(x, num4);
					num4 = 0f;
					num5 += 1f;
				}
				else
				{
					num4 += characterInfo[(int)num6].advance;
				}
			}
			x = math.max(x, num4);
			float3 float5 = pivot;
			float5 -= right * x * alignment.relativePivot.x;
			float start = 1f - num5;
			float end = 0.75f;
			float num7 = math.lerp(start, end, alignment.relativePivot.y);
			float5 -= up * num7;
			float5 += math.mul(cameraRotation, new float3(1f, 0f, 0f)) * (num2 * alignment.pixelOffset.x);
			float5 += math.mul(cameraRotation, new float3(0f, 1f, 0f)) * (num2 * alignment.pixelOffset.y);
			UnsafeAppendBuffer* ptr = &buffers->textVertices;
			UnsafeAppendBuffer* buffer = &buffers->textTriangles;
			Reserve(ptr, numCharacters * 4 * UnsafeUtility.SizeOf<TextVertex>());
			Reserve(buffer, numCharacters * 6 * UnsafeUtility.SizeOf<int>());
			float3 float6 = float5;
			for (int j = 0; j < numCharacters; j++)
			{
				ushort num8 = text[j];
				if (num8 == ushort.MaxValue)
				{
					float6 -= up;
					float5 = float6;
					continue;
				}
				SDFCharacter sDFCharacter = characterInfo[(int)num8];
				int num9 = ptr->Length / UnsafeUtility.SizeOf<TextVertex>();
				float3 float7 = float5 + sDFCharacter.vertexTopLeft.x * right + sDFCharacter.vertexTopLeft.y * up;
				minBounds = math.min(minBounds, float7);
				maxBounds = math.max(maxBounds, float7);
				Add(ptr, new TextVertex
				{
					position = float7,
					uv = sDFCharacter.uvTopLeft,
					color = color
				});
				float7 = float5 + sDFCharacter.vertexTopRight.x * right + sDFCharacter.vertexTopRight.y * up;
				minBounds = math.min(minBounds, float7);
				maxBounds = math.max(maxBounds, float7);
				Add(ptr, new TextVertex
				{
					position = float7,
					uv = sDFCharacter.uvTopRight,
					color = color
				});
				float7 = float5 + sDFCharacter.vertexBottomRight.x * right + sDFCharacter.vertexBottomRight.y * up;
				minBounds = math.min(minBounds, float7);
				maxBounds = math.max(maxBounds, float7);
				Add(ptr, new TextVertex
				{
					position = float7,
					uv = sDFCharacter.uvBottomRight,
					color = color
				});
				float7 = float5 + sDFCharacter.vertexBottomLeft.x * right + sDFCharacter.vertexBottomLeft.y * up;
				minBounds = math.min(minBounds, float7);
				maxBounds = math.max(maxBounds, float7);
				Add(ptr, new TextVertex
				{
					position = float7,
					uv = sDFCharacter.uvBottomLeft,
					color = color
				});
				Add(buffer, num9);
				Add(buffer, num9 + 1);
				Add(buffer, num9 + 2);
				Add(buffer, num9);
				Add(buffer, num9 + 2);
				Add(buffer, num9 + 3);
				float5 += right * sDFCharacter.advance;
			}
		}

		private unsafe void AddLine(CommandBuilder.LineData line)
		{
			float3 float5 = PerspectiveDivide(math.mul(currentMatrix, new float4(line.a, 1f)));
			float3 float6 = PerspectiveDivide(math.mul(currentMatrix, new float4(line.b, 1f)));
			float pixels = currentLineWidthData.pixels;
			float3 float7 = math.normalizesafe(float6 - float5);
			if (math.any(math.isnan(float7)))
			{
				throw new Exception("Nan line coordinates");
			}
			if (pixels <= 0f)
			{
				return;
			}
			minBounds = math.min(minBounds, math.min(float5, float6));
			maxBounds = math.max(maxBounds, math.max(float5, float6));
			UnsafeAppendBuffer* ptr = &buffers->vertices;
			Reserve(ptr, 4 * UnsafeUtility.SizeOf<Vertex>());
			Vertex* ptr2 = (Vertex*)(ptr->Ptr + ptr->Length);
			float3 uv = float7 * pixels;
			float3 uv2 = float7 * pixels;
			if (pixels > 1f && currentLineWidthData.automaticJoins && ptr->Length > 2 * UnsafeUtility.SizeOf<Vertex>())
			{
				Vertex* ptr3 = ptr2 - 1;
				Vertex* ptr4 = ptr2 - 2;
				float num = math.dot(float7, lastNormalizedLineDir);
				if (math.all(ptr4->position == float5) && lastLineWidth == pixels && num >= -0.6f)
				{
					uv = (ptr4->uv2 = (ptr3->uv2 = (float7 + lastNormalizedLineDir) * pixels / (1f + num)));
				}
			}
			ptr->Length += 4 * UnsafeUtility.SizeOf<Vertex>();
			*(ptr2++) = new Vertex
			{
				position = float5,
				color = currentColor,
				uv = new float2(0f, 0f),
				uv2 = uv
			};
			*(ptr2++) = new Vertex
			{
				position = float5,
				color = currentColor,
				uv = new float2(1f, 0f),
				uv2 = uv
			};
			*(ptr2++) = new Vertex
			{
				position = float6,
				color = currentColor,
				uv = new float2(0f, 1f),
				uv2 = uv2
			};
			*(ptr2++) = new Vertex
			{
				position = float6,
				color = currentColor,
				uv = new float2(1f, 1f),
				uv2 = uv2
			};
			lastNormalizedLineDir = float7;
			lastLineWidth = pixels;
		}

		internal static int CircleSteps(float3 center, float radius, float maxPixelError, ref float4x4 currentMatrix, float2 cameraDepthToPixelSize, float3 cameraPosition)
		{
			float4 p = math.mul(currentMatrix, new float4(center, 1f));
			if (math.abs(p.w) < 1E-07f)
			{
				return 3;
			}
			float3 obj = PerspectiveDivide(p);
			float num = math.sqrt(math.max(math.max(math.lengthsq(currentMatrix.c0.xyz), math.lengthsq(currentMatrix.c1.xyz)), math.lengthsq(currentMatrix.c2.xyz))) / p.w;
			float num2 = radius * num;
			float num3 = math.length(obj - cameraPosition);
			float num4 = cameraDepthToPixelSize.x * num3 + cameraDepthToPixelSize.y;
			float num5 = 1f - maxPixelError * num4 / num2;
			if (!(num5 < 0f))
			{
				return (int)math.ceil(MathF.PI / math.acos(num5));
			}
			return 3;
		}

		private void AddCircle(CommandBuilder.CircleData circle)
		{
			if (!math.all(circle.normal == 0f))
			{
				circle.normal = math.normalize(circle.normal);
				if (circle.normal.y < 0f)
				{
					circle.normal = -circle.normal;
				}
				float3 float5 = ((!math.all(math.abs(circle.normal - new float3(0f, 1f, 0f)) < 0.001f)) ? math.normalizesafe(math.cross(circle.normal, new float3(0f, 1f, 0f))) : new float3(0f, 0f, 1f));
				float3 float6 = float5;
				float3 normal = circle.normal;
				float3 xyz = math.cross(normal, float6);
				float4x4 float4x5 = currentMatrix;
				currentMatrix = math.mul(currentMatrix, new float4x4(new float4(float6, 0f) * circle.radius, new float4(normal, 0f) * circle.radius, new float4(xyz, 0f) * circle.radius, new float4(circle.center, 1f)));
				AddCircle(new CommandBuilder.CircleXZData
				{
					center = new float3(0f, 0f, 0f),
					radius = 1f,
					startAngle = 0f,
					endAngle = MathF.PI * 2f
				});
				currentMatrix = float4x5;
			}
		}

		private unsafe void AddDisc(CommandBuilder.CircleData circle)
		{
			if (!math.all(circle.normal == 0f))
			{
				int num = CircleSteps(circle.center, circle.radius, maxPixelError, ref currentMatrix, cameraDepthToPixelSize, cameraPosition);
				circle.normal = math.normalize(circle.normal);
				float3 float5 = ((!math.all(math.abs(circle.normal - new float3(0f, 1f, 0f)) < 0.001f)) ? math.cross(circle.normal, new float3(0f, 1f, 0f)) : new float3(0f, 0f, 1f));
				float num2 = 1f / (float)num;
				UnsafeAppendBuffer* ptr = &buffers->solidVertices;
				UnsafeAppendBuffer* buffer = &buffers->solidTriangles;
				Reserve(ptr, num * UnsafeUtility.SizeOf<Vertex>());
				Reserve(buffer, 3 * (num - 2) * UnsafeUtility.SizeOf<int>());
				float4x4 a = math.mul(currentMatrix, Matrix4x4.TRS(circle.center, Quaternion.LookRotation(circle.normal, float5), new Vector3(circle.radius, circle.radius, circle.radius)));
				float3 x = minBounds;
				float3 x2 = maxBounds;
				int num3 = ptr->Length / UnsafeUtility.SizeOf<Vertex>();
				for (int i = 0; i < num; i++)
				{
					math.sincos(math.lerp(0f, MathF.PI * 2f, (float)i * num2), out var s, out var c);
					float3 float6 = PerspectiveDivide(math.mul(a, new float4(c, s, 0f, 1f)));
					x = math.min(x, float6);
					x2 = math.max(x2, float6);
					Add(ptr, new Vertex
					{
						position = float6,
						color = currentColor,
						uv = new float2(0f, 0f),
						uv2 = new float3(0f, 0f, 0f)
					});
				}
				minBounds = x;
				maxBounds = x2;
				for (int j = 0; j < num - 2; j++)
				{
					Add(buffer, num3);
					Add(buffer, num3 + j + 1);
					Add(buffer, num3 + j + 2);
				}
			}
		}

		private void AddSphereOutline(CommandBuilder.SphereData circle)
		{
			float4 p = math.mul(currentMatrix, new float4(circle.center, 1f));
			if (math.abs(p.w) < 1E-07f)
			{
				return;
			}
			float3 float5 = PerspectiveDivide(p);
			float num = math.sqrt(math.max(math.max(math.lengthsq(currentMatrix.c0.xyz), math.lengthsq(currentMatrix.c1.xyz)), math.lengthsq(currentMatrix.c2.xyz))) / p.w;
			float num2 = circle.radius * num;
			if (cameraIsOrthographic)
			{
				float4x4 float4x5 = currentMatrix;
				currentMatrix = float4x4.identity;
				AddCircle(new CommandBuilder.CircleData
				{
					center = float5,
					normal = math.mul(cameraRotation, new float3(0f, 0f, 1f)),
					radius = num2
				});
				currentMatrix = float4x5;
				return;
			}
			float num3 = math.length(cameraPosition - float5);
			if (!(num3 <= num2))
			{
				float num4 = num2 * num2 / num3;
				float radius = math.sqrt(num2 * num2 - num4 * num4);
				float3 float6 = math.normalize(cameraPosition - float5);
				float4x4 float4x6 = currentMatrix;
				currentMatrix = float4x4.identity;
				AddCircle(new CommandBuilder.CircleData
				{
					center = float5 + float6 * num4,
					normal = float6,
					radius = radius
				});
				currentMatrix = float4x6;
			}
		}

		private unsafe void AddCircle(CommandBuilder.CircleXZData circle)
		{
			circle.endAngle = math.clamp(circle.endAngle, circle.startAngle - MathF.PI * 2f, circle.startAngle + MathF.PI * 2f);
			float4x4 a = math.mul(currentMatrix, new float4x4(new float4(circle.radius, 0f, 0f, 0f), new float4(0f, circle.radius, 0f, 0f), new float4(0f, 0f, circle.radius, 0f), new float4(circle.center, 1f)));
			int num = CircleSteps(float3.zero, 1f, maxPixelError, ref a, cameraDepthToPixelSize, cameraPosition);
			float pixels = currentLineWidthData.pixels;
			if (!(pixels < 0f))
			{
				int num2 = num * 4 * UnsafeUtility.SizeOf<Vertex>();
				Reserve(&buffers->vertices, num2);
				Vertex* ptr = (Vertex*)(buffers->vertices.Ptr + buffers->vertices.Length);
				buffers->vertices.Length += num2;
				math.sincos(circle.startAngle, out var s, out var c);
				float3 position = PerspectiveDivide(math.mul(a, new float4(c, 0f, s, 1f)));
				float3 uv = math.normalizesafe(math.mul(a, new float4(0f - s, 0f, c, 0f)).xyz) * pixels;
				float num3 = math.rcp(num);
				for (int i = 1; i <= num; i++)
				{
					math.sincos(math.lerp(circle.startAngle, circle.endAngle, (float)i * num3), out var s2, out var c2);
					float3 float5 = PerspectiveDivide(math.mul(a, new float4(c2, 0f, s2, 1f)));
					float3 float6 = math.normalizesafe(math.mul(a, new float4(0f - s2, 0f, c2, 0f)).xyz) * pixels;
					*(ptr++) = new Vertex
					{
						position = position,
						color = currentColor,
						uv = new float2(0f, 0f),
						uv2 = uv
					};
					*(ptr++) = new Vertex
					{
						position = position,
						color = currentColor,
						uv = new float2(1f, 0f),
						uv2 = uv
					};
					*(ptr++) = new Vertex
					{
						position = float5,
						color = currentColor,
						uv = new float2(0f, 1f),
						uv2 = float6
					};
					*(ptr++) = new Vertex
					{
						position = float5,
						color = currentColor,
						uv = new float2(1f, 1f),
						uv2 = float6
					};
					position = float5;
					uv = float6;
				}
				float3 x = PerspectiveDivide(math.mul(a, new float4(-1f, 0f, 0f, 1f)));
				float3 y = PerspectiveDivide(math.mul(a, new float4(0f, -1f, 0f, 1f)));
				float3 y2 = PerspectiveDivide(math.mul(a, new float4(1f, 0f, 0f, 1f)));
				float3 y3 = PerspectiveDivide(math.mul(a, new float4(0f, 1f, 0f, 1f)));
				minBounds = math.min(math.min(math.min(math.min(x, y), y2), y3), minBounds);
				maxBounds = math.max(math.max(math.max(math.max(x, y), y2), y3), maxBounds);
			}
		}

		private unsafe void AddDisc(CommandBuilder.CircleXZData circle)
		{
			int num = CircleSteps(circle.center, circle.radius, maxPixelError, ref currentMatrix, cameraDepthToPixelSize, cameraPosition);
			circle.endAngle = math.clamp(circle.endAngle, circle.startAngle - MathF.PI * 2f, circle.startAngle + MathF.PI * 2f);
			float num2 = 1f / (float)num;
			UnsafeAppendBuffer* ptr = &buffers->solidVertices;
			UnsafeAppendBuffer* buffer = &buffers->solidTriangles;
			Reserve(ptr, (2 + num) * UnsafeUtility.SizeOf<Vertex>());
			Reserve(buffer, 3 * num * UnsafeUtility.SizeOf<int>());
			float4x4 a = math.mul(currentMatrix, Matrix4x4.Translate(circle.center) * Matrix4x4.Scale(new Vector3(circle.radius, circle.radius, circle.radius)));
			float3 float5 = PerspectiveDivide(math.mul(a, new float4(0f, 0f, 0f, 1f)));
			Add(ptr, new Vertex
			{
				position = float5,
				color = currentColor,
				uv = new float2(0f, 0f),
				uv2 = new float3(0f, 0f, 0f)
			});
			float3 x = math.min(minBounds, float5);
			float3 x2 = math.max(maxBounds, float5);
			int num3 = ptr->Length / UnsafeUtility.SizeOf<Vertex>();
			for (int i = 0; i <= num; i++)
			{
				math.sincos(math.lerp(circle.startAngle, circle.endAngle, (float)i * num2), out var s, out var c);
				float3 float6 = PerspectiveDivide(math.mul(a, new float4(c, 0f, s, 1f)));
				x = math.min(x, float6);
				x2 = math.max(x2, float6);
				Add(ptr, new Vertex
				{
					position = float6,
					color = currentColor,
					uv = new float2(0f, 0f),
					uv2 = new float3(0f, 0f, 0f)
				});
			}
			minBounds = x;
			maxBounds = x2;
			for (int j = 0; j < num; j++)
			{
				Add(buffer, num3 - 1);
				Add(buffer, num3 + j);
				Add(buffer, num3 + j + 1);
			}
		}

		private unsafe void AddSolidTriangle(CommandBuilder.TriangleData triangle)
		{
			UnsafeAppendBuffer* num = &buffers->solidVertices;
			UnsafeAppendBuffer* buffer = &buffers->solidTriangles;
			Reserve(num, 3 * UnsafeUtility.SizeOf<Vertex>());
			Reserve(buffer, 3 * UnsafeUtility.SizeOf<int>());
			float4x4 a = currentMatrix;
			float3 float5 = PerspectiveDivide(math.mul(a, new float4(triangle.a, 1f)));
			float3 float6 = PerspectiveDivide(math.mul(a, new float4(triangle.b, 1f)));
			float3 float7 = PerspectiveDivide(math.mul(a, new float4(triangle.c, 1f)));
			int num2 = num->Length / UnsafeUtility.SizeOf<Vertex>();
			minBounds = math.min(math.min(math.min(minBounds, float5), float6), float7);
			maxBounds = math.max(math.max(math.max(maxBounds, float5), float6), float7);
			Add(num, new Vertex
			{
				position = float5,
				color = currentColor,
				uv = new float2(0f, 0f),
				uv2 = new float3(0f, 0f, 0f)
			});
			Add(num, new Vertex
			{
				position = float6,
				color = currentColor,
				uv = new float2(0f, 0f),
				uv2 = new float3(0f, 0f, 0f)
			});
			Add(num, new Vertex
			{
				position = float7,
				color = currentColor,
				uv = new float2(0f, 0f),
				uv2 = new float3(0f, 0f, 0f)
			});
			Add(buffer, num2);
			Add(buffer, num2 + 1);
			Add(buffer, num2 + 2);
		}

		private void AddWireBox(CommandBuilder.BoxData box)
		{
			float3 float5 = box.center - box.size * 0.5f;
			float3 float6 = box.center + box.size * 0.5f;
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(float5.x, float5.y, float5.z),
				b = new float3(float6.x, float5.y, float5.z)
			});
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(float6.x, float5.y, float5.z),
				b = new float3(float6.x, float5.y, float6.z)
			});
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(float6.x, float5.y, float6.z),
				b = new float3(float5.x, float5.y, float6.z)
			});
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(float5.x, float5.y, float6.z),
				b = new float3(float5.x, float5.y, float5.z)
			});
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(float5.x, float6.y, float5.z),
				b = new float3(float6.x, float6.y, float5.z)
			});
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(float6.x, float6.y, float5.z),
				b = new float3(float6.x, float6.y, float6.z)
			});
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(float6.x, float6.y, float6.z),
				b = new float3(float5.x, float6.y, float6.z)
			});
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(float5.x, float6.y, float6.z),
				b = new float3(float5.x, float6.y, float5.z)
			});
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(float5.x, float5.y, float5.z),
				b = new float3(float5.x, float6.y, float5.z)
			});
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(float6.x, float5.y, float5.z),
				b = new float3(float6.x, float6.y, float5.z)
			});
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(float6.x, float5.y, float6.z),
				b = new float3(float6.x, float6.y, float6.z)
			});
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(float5.x, float5.y, float6.z),
				b = new float3(float5.x, float6.y, float6.z)
			});
		}

		private void AddPlane(CommandBuilder.PlaneData plane)
		{
			float4x4 float4x5 = currentMatrix;
			currentMatrix = math.mul(currentMatrix, float4x4.TRS(plane.center, plane.rotation, new float3(plane.size.x * 0.5f, 1f, plane.size.y * 0.5f)));
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(-1f, 0f, -1f),
				b = new float3(1f, 0f, -1f)
			});
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(1f, 0f, -1f),
				b = new float3(1f, 0f, 1f)
			});
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(1f, 0f, 1f),
				b = new float3(-1f, 0f, 1f)
			});
			AddLine(new CommandBuilder.LineData
			{
				a = new float3(-1f, 0f, 1f),
				b = new float3(-1f, 0f, -1f)
			});
			currentMatrix = float4x5;
		}

		private unsafe void AddBox(CommandBuilder.BoxData box)
		{
			UnsafeAppendBuffer* ptr = &buffers->solidVertices;
			UnsafeAppendBuffer* ptr2 = &buffers->solidTriangles;
			Reserve(ptr, BoxVertices.Length * UnsafeUtility.SizeOf<Vertex>());
			Reserve(ptr2, BoxTriangles.Length * UnsafeUtility.SizeOf<int>());
			float3 float5 = box.size * 0.5f;
			float4x4 a = math.mul(currentMatrix, new float4x4(new float4(float5.x, 0f, 0f, 0f), new float4(0f, float5.y, 0f, 0f), new float4(0f, 0f, float5.z, 0f), new float4(box.center, 1f)));
			float3 x = minBounds;
			float3 x2 = maxBounds;
			int num = ptr->Length / UnsafeUtility.SizeOf<Vertex>();
			Vertex* ptr3 = (Vertex*)(ptr->Ptr + ptr->Length);
			for (int i = 0; i < BoxVertices.Length; i++)
			{
				float3 float6 = PerspectiveDivide(math.mul(a, BoxVertices[i]));
				x = math.min(x, float6);
				x2 = math.max(x2, float6);
				*(ptr3++) = new Vertex
				{
					position = float6,
					color = currentColor,
					uv = new float2(0f, 0f),
					uv2 = new float3(0f, 0f, 0f)
				};
			}
			ptr->Length += BoxVertices.Length * UnsafeUtility.SizeOf<Vertex>();
			minBounds = x;
			maxBounds = x2;
			int* ptr4 = (int*)(ptr2->Ptr + ptr2->Length);
			for (int j = 0; j < BoxTriangles.Length; j++)
			{
				*(ptr4++) = num + BoxTriangles[j];
			}
			ptr2->Length += BoxTriangles.Length * UnsafeUtility.SizeOf<int>();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void Next(ref UnsafeAppendBuffer.Reader reader, ref NativeArray<float4x4> matrixStack, ref NativeArray<Color32> colorStack, ref NativeArray<CommandBuilder.LineWidthData> lineWidthStack, ref int matrixStackSize, ref int colorStackSize, ref int lineWidthStackSize)
		{
			CommandBuilder.Command command = reader.ReadNext<CommandBuilder.Command>();
			CommandBuilder.Command command2 = command & (CommandBuilder.Command)255;
			Color32 color = default(Color32);
			if ((command & CommandBuilder.Command.PushColorInline) != CommandBuilder.Command.PushColor)
			{
				color = currentColor;
				currentColor = reader.ReadNext<Color32>();
			}
			switch (command2)
			{
			case CommandBuilder.Command.PushColor:
				if (colorStackSize >= colorStack.Length)
				{
					colorStackSize--;
				}
				colorStack[colorStackSize] = currentColor;
				colorStackSize++;
				currentColor = reader.ReadNext<Color32>();
				break;
			case CommandBuilder.Command.PopColor:
				if (colorStackSize > 0)
				{
					colorStackSize--;
					currentColor = colorStack[colorStackSize];
				}
				break;
			case CommandBuilder.Command.PushMatrix:
				if (matrixStackSize >= matrixStack.Length)
				{
					matrixStackSize--;
				}
				matrixStack[matrixStackSize] = currentMatrix;
				matrixStackSize++;
				currentMatrix = math.mul(currentMatrix, reader.ReadNext<float4x4>());
				break;
			case CommandBuilder.Command.PushSetMatrix:
				if (matrixStackSize >= matrixStack.Length)
				{
					matrixStackSize--;
				}
				matrixStack[matrixStackSize] = currentMatrix;
				matrixStackSize++;
				currentMatrix = reader.ReadNext<float4x4>();
				break;
			case CommandBuilder.Command.PopMatrix:
				if (matrixStackSize > 0)
				{
					matrixStackSize--;
					currentMatrix = matrixStack[matrixStackSize];
				}
				break;
			case CommandBuilder.Command.PushLineWidth:
				if (lineWidthStackSize >= lineWidthStack.Length)
				{
					lineWidthStackSize--;
				}
				lineWidthStack[lineWidthStackSize] = currentLineWidthData;
				lineWidthStackSize++;
				currentLineWidthData = reader.ReadNext<CommandBuilder.LineWidthData>();
				currentLineWidthData.pixels *= lineWidthMultiplier;
				break;
			case CommandBuilder.Command.PopLineWidth:
				if (lineWidthStackSize > 0)
				{
					lineWidthStackSize--;
					currentLineWidthData = lineWidthStack[lineWidthStackSize];
				}
				break;
			case CommandBuilder.Command.Line:
				AddLine(reader.ReadNext<CommandBuilder.LineData>());
				break;
			case CommandBuilder.Command.SphereOutline:
				AddSphereOutline(reader.ReadNext<CommandBuilder.SphereData>());
				break;
			case CommandBuilder.Command.CircleXZ:
				AddCircle(reader.ReadNext<CommandBuilder.CircleXZData>());
				break;
			case CommandBuilder.Command.Circle:
				AddCircle(reader.ReadNext<CommandBuilder.CircleData>());
				break;
			case CommandBuilder.Command.DiscXZ:
				AddDisc(reader.ReadNext<CommandBuilder.CircleXZData>());
				break;
			case CommandBuilder.Command.Disc:
				AddDisc(reader.ReadNext<CommandBuilder.CircleData>());
				break;
			case CommandBuilder.Command.Box:
				AddBox(reader.ReadNext<CommandBuilder.BoxData>());
				break;
			case CommandBuilder.Command.WirePlane:
				AddPlane(reader.ReadNext<CommandBuilder.PlaneData>());
				break;
			case CommandBuilder.Command.WireBox:
				AddWireBox(reader.ReadNext<CommandBuilder.BoxData>());
				break;
			case CommandBuilder.Command.SolidTriangle:
				AddSolidTriangle(reader.ReadNext<CommandBuilder.TriangleData>());
				break;
			case CommandBuilder.Command.PushPersist:
				reader.ReadNext<CommandBuilder.PersistData>();
				break;
			case CommandBuilder.Command.Text:
			{
				CommandBuilder.TextData textData2 = reader.ReadNext<CommandBuilder.TextData>();
				ushort* text2 = (ushort*)reader.ReadNext(UnsafeUtility.SizeOf<ushort>() * textData2.numCharacters);
				AddText(text2, textData2, currentColor);
				break;
			}
			case CommandBuilder.Command.Text3D:
			{
				CommandBuilder.TextData3D textData = reader.ReadNext<CommandBuilder.TextData3D>();
				ushort* text = (ushort*)reader.ReadNext(UnsafeUtility.SizeOf<ushort>() * textData.numCharacters);
				AddText3D(text, textData, currentColor);
				break;
			}
			case CommandBuilder.Command.CaptureState:
				buffers->capturedState.Add(new DrawingData.ProcessedBuilderData.CapturedState
				{
					color = currentColor,
					matrix = currentMatrix
				});
				break;
			}
			if ((command & CommandBuilder.Command.PushColorInline) != CommandBuilder.Command.PushColor)
			{
				currentColor = color;
			}
		}

		private unsafe void CreateTriangles()
		{
			UnsafeAppendBuffer* num = &buffers->vertices;
			UnsafeAppendBuffer* ptr = &buffers->triangles;
			int num2 = num->Length / UnsafeUtility.SizeOf<Vertex>() / 4;
			int num3 = num2 * 6 * UnsafeUtility.SizeOf<int>();
			if (num3 >= ptr->Capacity)
			{
				ptr->SetCapacity(math.ceilpow2(num3));
			}
			int* ptr2 = (int*)ptr->Ptr;
			int num4 = 0;
			int num5 = 0;
			while (num4 < num2)
			{
				*(ptr2++) = num5;
				*(ptr2++) = num5 + 1;
				*(ptr2++) = num5 + 2;
				*(ptr2++) = num5 + 1;
				*(ptr2++) = num5 + 3;
				*(ptr2++) = num5 + 2;
				num4++;
				num5 += 4;
			}
			ptr->Length = num3;
		}

		public unsafe void Execute()
		{
			buffers->vertices.Reset();
			buffers->triangles.Reset();
			buffers->solidVertices.Reset();
			buffers->solidTriangles.Reset();
			buffers->textVertices.Reset();
			buffers->textTriangles.Reset();
			buffers->capturedState.Reset();
			currentLineWidthData.pixels *= lineWidthMultiplier;
			minBounds = new float3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
			maxBounds = new float3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
			NativeArray<float4x4> matrixStack = new NativeArray<float4x4>(32, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			NativeArray<Color32> colorStack = new NativeArray<Color32>(32, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			NativeArray<CommandBuilder.LineWidthData> lineWidthStack = new NativeArray<CommandBuilder.LineWidthData>(32, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			int matrixStackSize = 0;
			int colorStackSize = 0;
			int lineWidthStackSize = 0;
			UnsafeAppendBuffer.Reader reader = buffers->splitterOutput.AsReader();
			while (reader.Offset < reader.Size)
			{
				Next(ref reader, ref matrixStack, ref colorStack, ref lineWidthStack, ref matrixStackSize, ref colorStackSize, ref lineWidthStackSize);
			}
			CreateTriangles();
			Bounds* ptr = &buffers->bounds;
			*ptr = new Bounds((minBounds + maxBounds) * 0.5f, maxBounds - minBounds);
			if (math.any(math.isnan(ptr->min)) && (buffers->vertices.Length > 0 || buffers->solidTriangles.Length > 0))
			{
				*ptr = new Bounds(Vector3.zero, new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity));
			}
		}
	}
	public abstract class MonoBehaviourGizmos : MonoBehaviour, IDrawGizmos
	{
		public MonoBehaviourGizmos()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		public virtual void DrawGizmos()
		{
		}
	}
	public static class Palette
	{
		public static class Pure
		{
			public static readonly Color Yellow = new Color(1f, 1f, 0f, 1f);

			public static readonly Color Clear = new Color(0f, 0f, 0f, 0f);

			public static readonly Color Grey = new Color(0.5f, 0.5f, 0.5f, 1f);

			public static readonly Color Magenta = new Color(1f, 0f, 1f, 1f);

			public static readonly Color Cyan = new Color(0f, 1f, 1f, 1f);

			public static readonly Color Red = new Color(1f, 0f, 0f, 1f);

			public static readonly Color Black = new Color(0f, 0f, 0f, 1f);

			public static readonly Color White = new Color(1f, 1f, 1f, 1f);

			public static readonly Color Blue = new Color(0f, 0f, 1f, 1f);

			public static readonly Color Green = new Color(0f, 1f, 0f, 1f);
		}

		public static class Colorbrewer
		{
			public static class Set1
			{
				public static readonly Color Red = new Color(76f / 85f, 0.101960786f, 0.10980392f, 1f);

				public static readonly Color Blue = new Color(11f / 51f, 42f / 85f, 0.72156864f, 1f);

				public static readonly Color Green = new Color(0.3019608f, 35f / 51f, 0.2901961f, 1f);

				public static readonly Color Purple = new Color(0.59607846f, 26f / 85f, 0.6392157f, 1f);

				public static readonly Color Orange = new Color(1f, 0.49803922f, 0f, 1f);

				public static readonly Color Yellow = new Color(1f, 1f, 0.2f, 1f);

				public static readonly Color Brown = new Color(0.6509804f, 0.3372549f, 8f / 51f, 1f);

				public static readonly Color Pink = new Color(0.96862745f, 43f / 85f, 0.7490196f, 1f);

				public static readonly Color Grey = new Color(0.6f, 0.6f, 0.6f, 1f);
			}

			public static class Blues
			{
				private static readonly Color[] Colors = new Color[45]
				{
					new Color(0.16862746f, 28f / 51f, 38f / 51f),
					new Color(0.6509804f, 63f / 85f, 73f / 85f),
					new Color(0.16862746f, 28f / 51f, 38f / 51f),
					new Color(0.9254902f, 77f / 85f, 0.9490196f),
					new Color(0.6509804f, 63f / 85f, 73f / 85f),
					new Color(0.16862746f, 28f / 51f, 38f / 51f),
					new Color(0.94509804f, 14f / 15f, 82f / 85f),
					new Color(63f / 85f, 67f / 85f, 0.88235295f),
					new Color(0.45490196f, 0.6627451f, 69f / 85f),
					new Color(1f / 51f, 0.4392157f, 0.6901961f),
					new Color(0.94509804f, 14f / 15f, 82f / 85f),
					new Color(63f / 85f, 67f / 85f, 0.88235295f),
					new Color(0.45490196f, 0.6627451f, 69f / 85f),
					new Color(0.16862746f, 28f / 51f, 38f / 51f),
					new Color(0.015686275f, 0.3529412f, 47f / 85f),
					new Color(0.94509804f, 14f / 15f, 82f / 85f),
					new Color(0.8156863f, 0.81960785f, 46f / 51f),
					new Color(0.6509804f, 63f / 85f, 73f / 85f),
					new Color(0.45490196f, 0.6627451f, 69f / 85f),
					new Color(0.16862746f, 28f / 51f, 38f / 51f),
					new Color(0.015686275f, 0.3529412f, 47f / 85f),
					new Color(0.94509804f, 14f / 15f, 82f / 85f),
					new Color(0.8156863f, 0.81960785f, 46f / 51f),
					new Color(0.6509804f, 63f / 85f, 73f / 85f),
					new Color(0.45490196f, 0.6627451f, 69f / 85f),
					new Color(18f / 85f, 48f / 85f, 64f / 85f),
					new Color(1f / 51f, 0.4392157f, 0.6901961f),
					new Color(1f / 85f, 26f / 85f, 41f / 85f),
					new Color(1f, 0.96862745f, 0.9843137f),
					new Color(0.9254902f, 77f / 85f, 0.9490196f),
					new Color(0.8156863f, 0.81960785f, 46f / 51f),
					new Color(0.6509804f, 63f / 85f, 73f / 85f),
					new Color(0.45490196f, 0.6627451f, 69f / 85f),
					new Color(18f / 85f, 48f / 85f, 64f / 85f),
					new Color(1f / 51f, 0.4392157f, 0.6901961f),
					new Color(1f / 85f, 26f / 85f, 41f / 85f),
					new Color(1f, 0.96862745f, 0.9843137f),
					new Color(0.9254902f, 77f / 85f, 0.9490196f),
					new Color(0.8156863f, 0.81960785f, 46f / 51f),
					new Color(0.6509804f, 63f / 85f, 73f / 85f),
					new Color(0.45490196f, 0.6627451f, 69f / 85f),
					new Color(18f / 85f, 48f / 85f, 64f / 85f),
					new Color(1f / 51f, 0.4392157f, 0.6901961f),
					new Color(0.015686275f, 0.3529412f, 47f / 85f),
					new Color(0.007843138f, 0.21960784f, 0.34509805f)
				};

				public static Color GetColor(int classes, int index)
				{
					if (index < 0 || index >= classes)
					{
						throw new ArgumentOutOfRangeException("index", "Index must be less than classes and at least 0");
					}
					if (classes <= 0 || classes > 9)
					{
						throw new ArgumentOutOfRangeException("classes", "Only up to 9 classes are supported");
					}
					return Colors[(classes - 1) * classes / 2 + index];
				}
			}
		}
	}
	[BurstCompile]
	internal struct PersistentFilterJob : IJob
	{
		[NativeDisableUnsafePtrRestriction]
		public unsafe UnsafeAppendBuffer* buffer;

		public float time;

		public unsafe void Execute()
		{
			NativeArray<bool> nativeArray = new NativeArray<bool>(32, Allocator.Temp);
			NativeArray<int> nativeArray2 = new NativeArray<int>(32, Allocator.Temp);
			UnsafeAppendBuffer unsafeAppendBuffer = *buffer;
			long num = 0L;
			long num2 = 0L;
			bool flag = false;
			int num3 = 0;
			long num4 = -1L;
			int num6;
			for (; num2 < unsafeAppendBuffer.Length; num2 += num6)
			{
				CommandBuilder.Command command = *(CommandBuilder.Command*)(unsafeAppendBuffer.Ptr + num2);
				int num5 = 1 << (int)(command & (CommandBuilder.Command)255);
				bool flag2 = (num5 & StreamSplitter.MetaCommands) != 0;
				num6 = StreamSplitter.CommandSizes[(int)(command & (CommandBuilder.Command)255)] + (((command & CommandBuilder.Command.PushColorInline) != CommandBuilder.Command.PushColor) ? UnsafeUtility.SizeOf<Color32>() : 0);
				if ((command & (CommandBuilder.Command)255) == CommandBuilder.Command.Text)
				{
					CommandBuilder.TextData textData = *((CommandBuilder.TextData*)(unsafeAppendBuffer.Ptr + num2 + num6) - 1);
					num6 += textData.numCharacters * UnsafeUtility.SizeOf<ushort>();
				}
				else if ((command & (CommandBuilder.Command)255) == CommandBuilder.Command.Text3D)
				{
					CommandBuilder.TextData3D textData3D = *((CommandBuilder.TextData3D*)(unsafeAppendBuffer.Ptr + num2 + num6) - 1);
					num6 += textData3D.numCharacters * UnsafeUtility.SizeOf<ushort>();
				}
				if (flag || flag2)
				{
					if (!flag2)
					{
						num4 = num;
					}
					if (num != num2)
					{
						UnsafeUtility.MemMove(unsafeAppendBuffer.Ptr + num, unsafeAppendBuffer.Ptr + num2, num6);
					}
					num += num6;
				}
				if ((num5 & StreamSplitter.PushCommands) != 0)
				{
					if ((command & (CommandBuilder.Command)255) == CommandBuilder.Command.PushPersist)
					{
						CommandBuilder.PersistData persistData = *((CommandBuilder.PersistData*)(unsafeAppendBuffer.Ptr + num2 + num6) - 1);
						flag = time <= persistData.endTime;
					}
					nativeArray2[num3] = (int)(num - num6);
					nativeArray[num3] = flag;
					num3++;
					if (num3 >= 32)
					{
						buffer->Length = 0;
						return;
					}
				}
				else if ((num5 & StreamSplitter.PopCommands) != 0)
				{
					num3--;
					if (num3 < 0)
					{
						buffer->Length = 0;
						return;
					}
					if ((int)num4 < nativeArray2[num3])
					{
						num = nativeArray2[num3];
					}
					flag = nativeArray[num3];
				}
			}
			unsafeAppendBuffer.Length = (int)num;
			if (num3 != 0)
			{
				buffer->Length = 0;
			}
			else
			{
				*buffer = unsafeAppendBuffer;
			}
		}
	}
	[BurstCompile]
	internal struct StreamSplitter : IJob
	{
		public NativeArray<UnsafeAppendBuffer> inputBuffers;

		[NativeDisableUnsafePtrRestriction]
		public unsafe UnsafeAppendBuffer* staticBuffer;

		[NativeDisableUnsafePtrRestriction]
		public unsafe UnsafeAppendBuffer* dynamicBuffer;

		[NativeDisableUnsafePtrRestriction]
		public unsafe UnsafeAppendBuffer* persistentBuffer;

		internal static readonly int PushCommands;

		internal static readonly int PopCommands;

		internal static readonly int MetaCommands;

		internal static readonly int DynamicCommands;

		internal static readonly int StaticCommands;

		internal static readonly int[] CommandSizes;

		static StreamSplitter()
		{
			PushCommands = 557069;
			PopCommands = 1114130;
			MetaCommands = PushCommands | PopCommands;
			DynamicCommands = 0x2607C0 | MetaCommands;
			StaticCommands = 0x7820 | MetaCommands;
			CommandSizes = new int[22];
			CommandSizes[0] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<Color32>();
			CommandSizes[1] = UnsafeUtility.SizeOf<CommandBuilder.Command>();
			CommandSizes[2] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<float4x4>();
			CommandSizes[3] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<float4x4>();
			CommandSizes[4] = UnsafeUtility.SizeOf<CommandBuilder.Command>();
			CommandSizes[5] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<CommandBuilder.LineData>();
			CommandSizes[7] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<CommandBuilder.CircleXZData>();
			CommandSizes[10] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<CommandBuilder.SphereData>();
			CommandSizes[6] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<CommandBuilder.CircleData>();
			CommandSizes[8] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<CommandBuilder.CircleData>();
			CommandSizes[9] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<CommandBuilder.CircleXZData>();
			CommandSizes[11] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<CommandBuilder.BoxData>();
			CommandSizes[12] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<CommandBuilder.PlaneData>();
			CommandSizes[13] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<CommandBuilder.BoxData>();
			CommandSizes[14] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<CommandBuilder.TriangleData>();
			CommandSizes[15] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<CommandBuilder.PersistData>();
			CommandSizes[16] = UnsafeUtility.SizeOf<CommandBuilder.Command>();
			CommandSizes[17] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<CommandBuilder.TextData>();
			CommandSizes[18] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<CommandBuilder.TextData3D>();
			CommandSizes[19] = UnsafeUtility.SizeOf<CommandBuilder.Command>() + UnsafeUtility.SizeOf<CommandBuilder.LineWidthData>();
			CommandSizes[20] = UnsafeUtility.SizeOf<CommandBuilder.Command>();
			CommandSizes[21] = UnsafeUtility.SizeOf<CommandBuilder.Command>();
		}

		public unsafe void Execute()
		{
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			NativeArray<int> nativeArray = new NativeArray<int>(32, Allocator.Temp);
			NativeArray<int> nativeArray2 = new NativeArray<int>(32, Allocator.Temp);
			NativeArray<int> nativeArray3 = new NativeArray<int>(32, Allocator.Temp);
			UnsafeAppendBuffer unsafeAppendBuffer = *staticBuffer;
			UnsafeAppendBuffer unsafeAppendBuffer2 = *dynamicBuffer;
			UnsafeAppendBuffer unsafeAppendBuffer3 = *persistentBuffer;
			unsafeAppendBuffer.Reset();
			unsafeAppendBuffer2.Reset();
			unsafeAppendBuffer3.Reset();
			for (int i = 0; i < inputBuffers.Length; i++)
			{
				int num4 = 0;
				int num5 = 0;
				UnsafeAppendBuffer.Reader reader = inputBuffers[i].AsReader();
				if (unsafeAppendBuffer.Capacity < unsafeAppendBuffer.Length + reader.Size)
				{
					unsafeAppendBuffer.SetCapacity(math.ceilpow2(unsafeAppendBuffer.Length + reader.Size));
				}
				if (unsafeAppendBuffer2.Capacity < unsafeAppendBuffer2.Length + reader.Size)
				{
					unsafeAppendBuffer2.SetCapacity(math.ceilpow2(unsafeAppendBuffer2.Length + reader.Size));
				}
				if (unsafeAppendBuffer3.Capacity < unsafeAppendBuffer3.Length + reader.Size)
				{
					unsafeAppendBuffer3.SetCapacity(math.ceilpow2(unsafeAppendBuffer3.Length + reader.Size));
				}
				*staticBuffer = unsafeAppendBuffer;
				*dynamicBuffer = unsafeAppendBuffer2;
				*persistentBuffer = unsafeAppendBuffer3;
				while (reader.Offset < reader.Size)
				{
					CommandBuilder.Command command = *(CommandBuilder.Command*)(reader.Ptr + reader.Offset);
					int num6 = 1 << (int)(command & (CommandBuilder.Command)255);
					int num7 = CommandSizes[(int)(command & (CommandBuilder.Command)255)] + (((command & CommandBuilder.Command.PushColorInline) != CommandBuilder.Command.PushColor) ? UnsafeUtility.SizeOf<Color32>() : 0);
					bool flag = (num6 & MetaCommands) != 0;
					if ((command & (CommandBuilder.Command)255) == CommandBuilder.Command.Text)
					{
						CommandBuilder.TextData textData = *((CommandBuilder.TextData*)(reader.Ptr + reader.Offset + num7) - 1);
						num7 += textData.numCharacters * UnsafeUtility.SizeOf<ushort>();
					}
					else if ((command & (CommandBuilder.Command)255) == CommandBuilder.Command.Text3D)
					{
						CommandBuilder.TextData3D textData3D = *((CommandBuilder.TextData3D*)(reader.Ptr + reader.Offset + num7) - 1);
						num7 += textData3D.numCharacters * UnsafeUtility.SizeOf<ushort>();
					}
					if ((num6 & DynamicCommands) != 0 && num5 == 0)
					{
						if (!flag)
						{
							num2 = unsafeAppendBuffer2.Length;
						}
						UnsafeUtility.MemCpy(unsafeAppendBuffer2.Ptr + unsafeAppendBuffer2.Length, reader.Ptr + reader.Offset, num7);
						unsafeAppendBuffer2.Length += num7;
					}
					if ((num6 & StaticCommands) != 0 && num5 == 0)
					{
						if (!flag)
						{
							num = unsafeAppendBuffer.Length;
						}
						UnsafeUtility.MemCpy(unsafeAppendBuffer.Ptr + unsafeAppendBuffer.Length, reader.Ptr + reader.Offset, num7);
						unsafeAppendBuffer.Length += num7;
					}
					if ((num6 & MetaCommands) != 0 || num5 > 0)
					{
						if (num5 > 0 && !flag)
						{
							num3 = unsafeAppendBuffer3.Length;
						}
						UnsafeUtility.MemCpy(unsafeAppendBuffer3.Ptr + unsafeAppendBuffer3.Length, reader.Ptr + reader.Offset, num7);
						unsafeAppendBuffer3.Length += num7;
					}
					if ((num6 & PushCommands) != 0)
					{
						nativeArray[num4] = unsafeAppendBuffer.Length - num7;
						nativeArray2[num4] = unsafeAppendBuffer2.Length - num7;
						nativeArray3[num4] = unsafeAppendBuffer3.Length - num7;
						num4++;
						if ((command & (CommandBuilder.Command)255) == CommandBuilder.Command.PushPersist)
						{
							num5++;
						}
						if (num4 >= 32)
						{
							return;
						}
					}
					else if ((num6 & PopCommands) != 0)
					{
						num4--;
						if (num4 < 0)
						{
							return;
						}
						if (num < nativeArray[num4])
						{
							unsafeAppendBuffer.Length = nativeArray[num4];
						}
						if (num2 < nativeArray2[num4])
						{
							unsafeAppendBuffer2.Length = nativeArray2[num4];
						}
						if (num3 < nativeArray3[num4])
						{
							unsafeAppendBuffer3.Length = nativeArray3[num4];
						}
						if ((command & (CommandBuilder.Command)255) == CommandBuilder.Command.PopPersist)
						{
							num5--;
							if (num5 < 0)
							{
								return;
							}
						}
					}
					reader.Offset += num7;
				}
				if (num4 != 0 || reader.Offset != reader.Size)
				{
					return;
				}
			}
			*staticBuffer = unsafeAppendBuffer;
			*dynamicBuffer = unsafeAppendBuffer2;
			*persistentBuffer = unsafeAppendBuffer3;
		}
	}
}
namespace Drawing.Text
{
	internal struct SDFCharacter
	{
		public char codePoint;

		private float2 uvtopleft;

		private float2 uvbottomright;

		private float2 vtopleft;

		private float2 vbottomright;

		public float advance;

		public float2 uvTopLeft => uvtopleft;

		public float2 uvTopRight => new float2(uvbottomright.x, uvtopleft.y);

		public float2 uvBottomLeft => new float2(uvtopleft.x, uvbottomright.y);

		public float2 uvBottomRight => uvbottomright;

		public float2 vertexTopLeft => vtopleft;

		public float2 vertexTopRight => new float2(vbottomright.x, vtopleft.y);

		public float2 vertexBottomLeft => new float2(vtopleft.x, vbottomright.y);

		public float2 vertexBottomRight => vbottomright;

		public SDFCharacter(char codePoint, int x, int y, int width, int height, int originX, int originY, int advance, int textureWidth, int textureHeight, float defaultSize)
		{
			float2 float5 = new float2(textureWidth, textureHeight);
			this.codePoint = codePoint;
			float2 float6 = new float2(x, y) / float5;
			float2 float7 = new float2(x + width, y + height) / float5;
			uvtopleft = new float2(float6.x, 1f - float6.y);
			uvbottomright = new float2(float7.x, 1f - float7.y);
			float2 float8 = new float2(-originX, originY);
			vtopleft = (float8 + new float2(0f, 0f)) / defaultSize;
			vbottomright = (float8 + new float2(width, -height)) / defaultSize;
			this.advance = (float)advance / defaultSize;
		}
	}
	internal struct SDFFont
	{
		public string name;

		public int size;

		public int width;

		public int height;

		public bool bold;

		public bool italic;

		public SDFCharacter[] characters;

		public Material material;
	}
	internal struct SDFLookupData
	{
		public NativeArray<SDFCharacter> characters;

		private Dictionary<char, int> lookup;

		public Material material;

		public const ushort Newline = ushort.MaxValue;

		public SDFLookupData(SDFFont font)
		{
			int num = 0;
			SDFCharacter value = font.characters[0];
			for (int i = 0; i < font.characters.Length; i++)
			{
				if (font.characters[i].codePoint == '?')
				{
					value = font.characters[i];
				}
				if (font.characters[i].codePoint >= '\u0080')
				{
					num++;
				}
			}
			characters = new NativeArray<SDFCharacter>(128 + num, Allocator.Persistent);
			for (int j = 0; j < characters.Length; j++)
			{
				characters[j] = value;
			}
			lookup = new Dictionary<char, int>();
			material = font.material;
			num = 0;
			for (int k = 0; k < font.characters.Length; k++)
			{
				SDFCharacter value2 = font.characters[k];
				int num2 = value2.codePoint;
				if (value2.codePoint >= '\u0080')
				{
					num2 = 128 + num;
					num++;
				}
				characters[num2] = value2;
				lookup[value2.codePoint] = num2;
			}
		}

		public int GetIndex(char c)
		{
			if (lookup.TryGetValue(c, out var value))
			{
				return value;
			}
			if (c == '\n')
			{
				return 65535;
			}
			return lookup['?'];
		}

		public void Dispose()
		{
			if (characters.IsCreated)
			{
				characters.Dispose();
			}
		}
	}
	internal static class DefaultFonts
	{
		internal static SDFFont LoadDefaultFont()
		{
			SDFFont result = new SDFFont
			{
				name = "Droid Sans Mono",
				size = 32,
				bold = false,
				italic = false,
				width = 1024,
				height = 128,
				characters = null,
				material = Resources.Load<Material>("aline_text_mat")
			};
			SDFCharacter[] characters = new SDFCharacter[95]
			{
				new SDFCharacter(' ', 414, 79, 12, 12, 6, 6, 19, result.width, result.height, result.size),
				new SDFCharacter('!', 669, 44, 16, 35, -2, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('"', 258, 79, 23, 20, 2, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('#', 919, 0, 30, 35, 5, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('$', 231, 0, 26, 38, 3, 30, 19, result.width, result.height, result.size),
				new SDFCharacter('%', 393, 0, 31, 36, 6, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('&', 424, 0, 31, 36, 5, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('\'', 281, 79, 16, 20, -2, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('(', 115, 0, 22, 40, 1, 29, 19, result.width, result.height, result.size),
				new SDFCharacter(')', 137, 0, 22, 40, 1, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('*', 159, 79, 27, 26, 4, 30, 19, result.width, result.height, result.size),
				new SDFCharacter('+', 186, 79, 27, 26, 4, 24, 19, result.width, result.height, result.size),
				new SDFCharacter(',', 240, 79, 18, 21, -1, 10, 19, result.width, result.height, result.size),
				new SDFCharacter('-', 359, 79, 23, 15, 2, 16, 19, result.width, result.height, result.size),
				new SDFCharacter('.', 315, 79, 17, 17, -1, 11, 19, result.width, result.height, result.size),
				new SDFCharacter('/', 500, 44, 25, 35, 3, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('0', 569, 0, 27, 36, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('1', 649, 44, 20, 35, 2, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('2', 313, 44, 27, 35, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('3', 758, 0, 26, 36, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('4', 60, 44, 29, 35, 5, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('5', 448, 44, 26, 35, 3, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('6', 596, 0, 27, 36, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('7', 340, 44, 27, 35, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('8', 623, 0, 27, 36, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('9', 650, 0, 27, 36, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter(':', 861, 44, 16, 30, -2, 23, 19, result.width, result.height, result.size),
				new SDFCharacter(';', 711, 44, 18, 34, 0, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('<', 77, 79, 27, 28, 4, 25, 19, result.width, result.height, result.size),
				new SDFCharacter('=', 213, 79, 27, 21, 4, 22, 19, result.width, result.height, result.size),
				new SDFCharacter('>', 104, 79, 27, 28, 4, 25, 19, result.width, result.height, result.size),
				new SDFCharacter('?', 784, 0, 26, 36, 3, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('@', 200, 0, 31, 38, 6, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('A', 949, 0, 30, 35, 5, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('B', 89, 44, 28, 35, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('C', 513, 0, 28, 36, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('D', 117, 44, 28, 35, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('E', 474, 44, 26, 35, 3, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('F', 525, 44, 25, 35, 2, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('G', 541, 0, 28, 36, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('H', 367, 44, 27, 35, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('I', 625, 44, 24, 35, 2, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('J', 550, 44, 25, 35, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('K', 145, 44, 28, 35, 3, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('L', 575, 44, 25, 35, 2, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('M', 173, 44, 28, 35, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('N', 394, 44, 27, 35, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('O', 455, 0, 29, 36, 5, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('P', 421, 44, 27, 35, 3, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('Q', 38, 0, 29, 42, 5, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('R', 201, 44, 28, 35, 3, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('S', 677, 0, 27, 36, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('T', 229, 44, 28, 35, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('U', 257, 44, 28, 35, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('V', 979, 0, 30, 35, 5, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('W', 888, 0, 31, 35, 6, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('X', 0, 44, 30, 35, 5, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('Y', 30, 44, 30, 35, 5, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('Z', 285, 44, 28, 35, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('[', 159, 0, 21, 40, 0, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('\\', 600, 44, 25, 35, 3, 29, 19, result.width, result.height, result.size),
				new SDFCharacter(']', 180, 0, 20, 40, 1, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('^', 131, 79, 28, 26, 4, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('_', 382, 79, 32, 14, 6, 3, 19, result.width, result.height, result.size),
				new SDFCharacter('`', 297, 79, 18, 17, -1, 31, 19, result.width, result.height, result.size),
				new SDFCharacter('a', 784, 44, 26, 30, 4, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('b', 285, 0, 27, 37, 4, 30, 19, result.width, result.height, result.size),
				new SDFCharacter('c', 810, 44, 26, 30, 3, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('d', 312, 0, 27, 37, 4, 30, 19, result.width, result.height, result.size),
				new SDFCharacter('e', 757, 44, 27, 30, 4, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('f', 704, 0, 27, 36, 4, 30, 19, result.width, result.height, result.size),
				new SDFCharacter('g', 257, 0, 28, 37, 4, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('h', 810, 0, 26, 36, 3, 30, 19, result.width, result.height, result.size),
				new SDFCharacter('i', 836, 0, 26, 36, 3, 30, 19, result.width, result.height, result.size),
				new SDFCharacter('j', 0, 0, 23, 44, 4, 30, 19, result.width, result.height, result.size),
				new SDFCharacter('k', 731, 0, 27, 36, 3, 30, 19, result.width, result.height, result.size),
				new SDFCharacter('l', 862, 0, 26, 36, 3, 30, 19, result.width, result.height, result.size),
				new SDFCharacter('m', 909, 44, 29, 29, 5, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('n', 995, 44, 26, 29, 3, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('o', 729, 44, 28, 30, 4, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('p', 339, 0, 27, 37, 4, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('q', 366, 0, 27, 37, 4, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('r', 52, 79, 25, 29, 2, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('s', 836, 44, 25, 30, 3, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('t', 685, 44, 26, 34, 4, 28, 19, result.width, result.height, result.size),
				new SDFCharacter('u', 0, 79, 26, 29, 3, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('v', 938, 44, 29, 29, 5, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('w', 877, 44, 32, 29, 6, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('x', 967, 44, 28, 29, 4, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('y', 484, 0, 29, 36, 5, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('z', 26, 79, 26, 29, 3, 23, 19, result.width, result.height, result.size),
				new SDFCharacter('{', 67, 0, 24, 40, 2, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('|', 23, 0, 15, 44, -2, 30, 19, result.width, result.height, result.size),
				new SDFCharacter('}', 91, 0, 24, 40, 2, 29, 19, result.width, result.height, result.size),
				new SDFCharacter('~', 332, 79, 27, 16, 4, 19, 19, result.width, result.height, result.size)
			};
			result.characters = characters;
			return result;
		}
	}
}
namespace Drawing.Examples
{
	public class GizmoCharacterExample : MonoBehaviourGizmos
	{
		public Color gizmoColor = new Color(1f, 0.34509805f, 1f / 3f);

		public Color gizmoColor2 = new Color(0.30980393f, 0.8f, 79f / 85f);

		public float movementNoiseScale = 0.2f;

		public float startPointAttractionStrength = 0.05f;

		public int futurePathPlotSteps = 100;

		public int plotStartStep = 10;

		public int plotEveryNSteps = 10;

		private float seed;

		private Vector3 startPosition;

		private void Start()
		{
			seed = UnityEngine.Random.value * 1000f;
			startPosition = base.transform.position;
		}

		private Vector3 GetSmoothRandomVelocity(float time, Vector3 position)
		{
			float num = time * movementNoiseScale + seed;
			float x = 2f * Mathf.PerlinNoise(num, num + 5341.2314f) - 1f;
			float z = 2f * Mathf.PerlinNoise(num + 92.9842f, 0f - num + 231.85146f) - 1f;
			Vector3 result = new Vector3(x, 0f, z);
			result += (startPosition - position) * startPointAttractionStrength;
			result.y = 0f;
			return result;
		}

		private void PlotFuturePath(float time, Vector3 position)
		{
			float num = 0.05f;
			for (int i = 0; i < futurePathPlotSteps; i++)
			{
				Vector3 smoothRandomVelocity = GetSmoothRandomVelocity(time + (float)i * num, position);
				int num2 = i - plotStartStep;
				if (num2 >= 0 && num2 % plotEveryNSteps == 0)
				{
					Draw.Arrowhead(position, smoothRandomVelocity, 0.1f, gizmoColor);
				}
				position += smoothRandomVelocity.normalized * num;
			}
		}

		private void Update()
		{
			PlotFuturePath(Time.time, base.transform.position);
			Vector3 smoothRandomVelocity = GetSmoothRandomVelocity(Time.time, base.transform.position);
			base.transform.rotation = Quaternion.LookRotation(smoothRandomVelocity);
			base.transform.position += base.transform.forward * Time.deltaTime;
		}

		public override void DrawGizmos()
		{
			using (Draw.InLocalSpace(base.transform))
			{
				Draw.WireCylinder(Vector3.zero, Vector3.up, 2f, 0.5f, gizmoColor);
				Draw.ArrowheadArc(Vector3.zero, Vector3.forward, 0.55f, gizmoColor);
				Draw.Label2D(Vector3.zero, base.gameObject.name, 14f, LabelAlignment.TopCenter.withPixelOffset(0f, -20f), gizmoColor2);
			}
		}
	}
	public class GizmoSphereExample : MonoBehaviourGizmos
	{
		private struct Contact
		{
			public float impulse;

			public float smoothImpulse;

			public Vector3 lastPoint;

			public Vector3 lastNormal;
		}

		public Color gizmoColor = new Color(1f, 0.34509805f, 1f / 3f);

		public Color gizmoColor2 = new Color(0.30980393f, 0.8f, 79f / 85f);

		private Dictionary<Collider, Contact> contactForces = new Dictionary<Collider, Contact>();

		public override void DrawGizmos()
		{
			using (Draw.InLocalSpace(base.transform))
			{
				Draw.WireSphere(Vector3.zero, 0.5f, gizmoColor);
				foreach (Contact value in contactForces.Values)
				{
					Draw.Circle(value.lastPoint, value.lastNormal, 0.1f * value.impulse, gizmoColor2);
					Draw.SolidCircle(value.lastPoint, value.lastNormal, 0.1f * value.impulse, gizmoColor2);
				}
			}
		}

		private void FixedUpdate()
		{
			foreach (Collider item in contactForces.Keys.ToList())
			{
				Contact value = contactForces[item];
				if (value.impulse > 0.1f)
				{
					value.impulse = Mathf.Lerp(value.impulse, 0f, 10f * Time.fixedDeltaTime);
					value.smoothImpulse = Mathf.Lerp(value.impulse, value.smoothImpulse, 20f * Time.fixedDeltaTime);
					contactForces[item] = value;
				}
				else
				{
					contactForces.Remove(item);
				}
			}
		}

		private void OnCollisionStay(Collision collision)
		{
			ContactPoint[] contacts = collision.contacts;
			int num = 0;
			if (num < contacts.Length)
			{
				ContactPoint contactPoint = contacts[num];
				if (!contactForces.ContainsKey(collision.collider))
				{
					contactForces.Add(collision.collider, new Contact
					{
						impulse = 2f
					});
				}
				Contact value = contactForces[collision.collider];
				value.impulse = Mathf.Max(value.impulse, 1f);
				value.lastPoint = base.transform.InverseTransformPoint(contactPoint.point);
				value.lastNormal = base.transform.InverseTransformVector(contactPoint.normal);
				contactForces[collision.collider] = value;
			}
		}
	}
	public class TimedSpawner : MonoBehaviour
	{
		public float interval = 1f;

		public float lifeTime = 5f;

		public GameObject prefab;

		private IEnumerator Start()
		{
			while (true)
			{
				GameObject go = UnityEngine.Object.Instantiate(prefab, base.transform.position + UnityEngine.Random.insideUnitSphere * 0.01f, UnityEngine.Random.rotation);
				StartCoroutine(DestroyAfter(go, lifeTime));
				yield return new WaitForSeconds(interval);
			}
		}

		private IEnumerator DestroyAfter(GameObject go, float delay)
		{
			yield return new WaitForSeconds(delay);
			UnityEngine.Object.Destroy(go);
		}
	}
	public class CurveEditor : MonoBehaviour
	{
		private class CurvePoint
		{
			public Vector2 position;

			public Vector2 controlPoint0;

			public Vector2 controlPoint1;
		}

		private List<CurvePoint> curves = new List<CurvePoint>();

		private Camera cam;

		public Color curveColor;

		private void Awake()
		{
			cam = Camera.main;
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				curves.Add(new CurvePoint
				{
					position = Input.mousePosition,
					controlPoint0 = Vector2.zero,
					controlPoint1 = Vector2.zero
				});
			}
			if (curves.Count > 0 && Input.GetKey(KeyCode.Mouse0) && ((Vector2)Input.mousePosition - curves[curves.Count - 1].position).magnitude > 4f)
			{
				CurvePoint curvePoint = curves[curves.Count - 1];
				curvePoint.controlPoint1 = (Vector2)Input.mousePosition - curvePoint.position;
				curvePoint.controlPoint0 = -curvePoint.controlPoint1;
			}
			Render();
		}

		private void Render()
		{
			using CommandBuilder commandBuilder = DrawingManager.GetBuilder(renderInGame: true);
			using (commandBuilder.InScreenSpace(cam))
			{
				for (int i = 0; i < curves.Count; i++)
				{
					commandBuilder.xy.Circle((Vector3)curves[i].position, 2f, Color.blue);
				}
				for (int j = 0; j < curves.Count - 1; j++)
				{
					Vector2 position = curves[j].position;
					Vector2 vector = position + curves[j].controlPoint1;
					Vector2 position2 = curves[j + 1].position;
					Vector2 vector2 = position2 + curves[j + 1].controlPoint0;
					commandBuilder.Bezier((Vector3)position, (Vector3)vector, (Vector3)vector2, (Vector3)position2, curveColor);
				}
			}
		}
	}
	public class BurstExample : MonoBehaviour
	{
		[BurstCompile]
		private struct DrawingJob : IJob
		{
			public float2 offset;

			public CommandBuilder builder;

			private Color Colormap(float x)
			{
				float r = math.clamp(2.6666667f * x, 0f, 1f);
				float g = math.clamp(2.6666667f * x - 1f, 0f, 1f);
				float b = math.clamp(4f * x - 3f, 0f, 1f);
				return new Color(r, g, b, 1f);
			}

			public void Execute(int index)
			{
				int num = index / 100;
				int num2 = index % 100;
				float num3 = Mathf.PerlinNoise((float)num * 0.05f + offset.x, (float)num2 * 0.05f + offset.y);
				Bounds bounds = new Bounds(new float3(num, 0f, num2), new float3(1f, 14f * num3, 1f));
				builder.SolidBox(bounds, Colormap(num3));
			}

			public void Execute()
			{
				for (int i = 0; i < 10000; i++)
				{
					Execute(i);
				}
			}
		}

		public void Update()
		{
			CommandBuilder builder = DrawingManager.GetBuilder(renderInGame: true);
			JobHandle dependency = new DrawingJob
			{
				builder = builder,
				offset = new float2(Time.time * 0.2f, Time.time * 0.2f)
			}.Schedule();
			builder.DisposeAfter(dependency);
			dependency.Complete();
		}
	}
	public class AlineStyling : MonoBehaviour
	{
		public Color gizmoColor = new Color(1f, 0.34509805f, 1f / 3f);

		public Color gizmoColor2 = new Color(0.30980393f, 0.8f, 79f / 85f);

		private void Update()
		{
			CommandBuilder ingame = Draw.ingame;
			using (ingame.InScreenSpace(Camera.main))
			{
				using (ingame.WithMatrix(Matrix4x4.TRS(new Vector3((float)Screen.width / 2f, (float)Screen.height / 2f, 0f), Quaternion.identity, new Vector3(Screen.width, Screen.width, 1f))))
				{
					for (int i = 0; i < 4; i++)
					{
						using (ingame.WithLineWidth(i * i + 1))
						{
							float x = MathF.PI / 4f * (float)(i + 1) + Time.time * (float)i;
							Vector3 vector = new Vector3(-0.3f + (float)i * 0.2f, 0f, 0f);
							float num = 0.075f;
							ingame.Line(vector + new Vector3(math.cos(x) * num, math.sin(x) * num, 0f), vector, gizmoColor);
							ingame.Line(vector, vector + new Vector3(num, 0f, 0f), gizmoColor);
							ingame.xy.Circle(vector, num, gizmoColor2);
						}
					}
				}
			}
		}
	}
}
[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__3150089336157158032
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobExtensions.EarlyJobInit<GeometryBuilderJob>();
			IJobExtensions.EarlyJobInit<PersistentFilterJob>();
			IJobExtensions.EarlyJobInit<StreamSplitter>();
			IJobExtensions.EarlyJobInit<BurstExample.DrawingJob>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex);
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		CreateJobReflectionData();
	}
}
internal static class $BurstDirectCallInitializer
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	private static void Initialize()
	{
		BurstCompilerOptions options = BurstCompiler.Options;
	}
}
