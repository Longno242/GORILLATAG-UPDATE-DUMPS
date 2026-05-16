using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fusion;
using Fusion.CodeGen;
using Fusion.Sockets;
using Meta.XR.BuildingBlocks;
using Meta.XR.MultiplayerBlocks.Colocation;
using Meta.XR.MultiplayerBlocks.Colocation.Fusion;
using Meta.XR.MultiplayerBlocks.Shared;
using POpusCodec.Enums;
using Photon.Voice.Fusion;
using Photon.Voice.Unity;
using Photon.Voice.Unity.UtilityScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngine.UI;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NetworkAssemblyWeaved]
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
			FilePathsData = new byte[2592]
			{
				0, 0, 0, 1, 0, 0, 0, 144, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 99, 111, 114, 101,
				64, 53, 48, 51, 97, 55, 50, 99, 97, 53,
				52, 57, 54, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 66, 117, 105, 108, 100, 105, 110, 103,
				66, 108, 111, 99, 107, 115, 92, 77, 117, 108,
				116, 105, 112, 108, 97, 121, 101, 114, 66, 108,
				111, 99, 107, 115, 92, 80, 104, 111, 116, 111,
				110, 70, 117, 115, 105, 111, 110, 92, 67, 111,
				108, 111, 99, 97, 116, 105, 111, 110, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 70, 117, 115,
				105, 111, 110, 65, 110, 99, 104, 111, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 147,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 99, 111,
				114, 101, 64, 53, 48, 51, 97, 55, 50, 99,
				97, 53, 52, 57, 54, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 66, 117, 105, 108, 100, 105,
				110, 103, 66, 108, 111, 99, 107, 115, 92, 77,
				117, 108, 116, 105, 112, 108, 97, 121, 101, 114,
				66, 108, 111, 99, 107, 115, 92, 80, 104, 111,
				116, 111, 110, 70, 117, 115, 105, 111, 110, 92,
				67, 111, 108, 111, 99, 97, 116, 105, 111, 110,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 70,
				117, 115, 105, 111, 110, 77, 101, 115, 115, 101,
				110, 103, 101, 114, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 157, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 99, 111, 114, 101, 64, 53, 48,
				51, 97, 55, 50, 99, 97, 53, 52, 57, 54,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 66,
				117, 105, 108, 100, 105, 110, 103, 66, 108, 111,
				99, 107, 115, 92, 77, 117, 108, 116, 105, 112,
				108, 97, 121, 101, 114, 66, 108, 111, 99, 107,
				115, 92, 80, 104, 111, 116, 111, 110, 70, 117,
				115, 105, 111, 110, 92, 67, 111, 108, 111, 99,
				97, 116, 105, 111, 110, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 70, 117, 115, 105, 111, 110,
				78, 101, 116, 119, 111, 114, 107, 66, 111, 111,
				116, 115, 116, 114, 97, 112, 112, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 149,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 99, 111,
				114, 101, 64, 53, 48, 51, 97, 55, 50, 99,
				97, 53, 52, 57, 54, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 66, 117, 105, 108, 100, 105,
				110, 103, 66, 108, 111, 99, 107, 115, 92, 77,
				117, 108, 116, 105, 112, 108, 97, 121, 101, 114,
				66, 108, 111, 99, 107, 115, 92, 80, 104, 111,
				116, 111, 110, 70, 117, 115, 105, 111, 110, 92,
				67, 111, 108, 111, 99, 97, 116, 105, 111, 110,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 70,
				117, 115, 105, 111, 110, 78, 101, 116, 119, 111,
				114, 107, 68, 97, 116, 97, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 144, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 99, 111, 114, 101, 64,
				53, 48, 51, 97, 55, 50, 99, 97, 53, 52,
				57, 54, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 66, 117, 105, 108, 100, 105, 110, 103, 66,
				108, 111, 99, 107, 115, 92, 77, 117, 108, 116,
				105, 112, 108, 97, 121, 101, 114, 66, 108, 111,
				99, 107, 115, 92, 80, 104, 111, 116, 111, 110,
				70, 117, 115, 105, 111, 110, 92, 67, 111, 108,
				111, 99, 97, 116, 105, 111, 110, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 70, 117, 115, 105,
				111, 110, 80, 108, 97, 121, 101, 114, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 160, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 99, 111, 114,
				101, 64, 53, 48, 51, 97, 55, 50, 99, 97,
				53, 52, 57, 54, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 66, 117, 105, 108, 100, 105, 110,
				103, 66, 108, 111, 99, 107, 115, 92, 77, 117,
				108, 116, 105, 112, 108, 97, 121, 101, 114, 66,
				108, 111, 99, 107, 115, 92, 80, 104, 111, 116,
				111, 110, 70, 117, 115, 105, 111, 110, 92, 67,
				111, 108, 111, 99, 97, 116, 105, 111, 110, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 70, 117,
				115, 105, 111, 110, 83, 104, 97, 114, 101, 65,
				110, 100, 76, 111, 99, 97, 108, 105, 122, 101,
				80, 97, 114, 97, 109, 115, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 154, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 99, 111, 114, 101, 64,
				53, 48, 51, 97, 55, 50, 99, 97, 53, 52,
				57, 54, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 66, 117, 105, 108, 100, 105, 110, 103, 66,
				108, 111, 99, 107, 115, 92, 77, 117, 108, 116,
				105, 112, 108, 97, 121, 101, 114, 66, 108, 111,
				99, 107, 115, 92, 80, 104, 111, 116, 111, 110,
				70, 117, 115, 105, 111, 110, 92, 67, 117, 115,
				116, 111, 109, 77, 97, 116, 99, 104, 109, 97,
				107, 105, 110, 103, 92, 67, 117, 115, 116, 111,
				109, 77, 97, 116, 99, 104, 109, 97, 107, 105,
				110, 103, 70, 117, 115, 105, 111, 110, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 158, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 99, 111, 114,
				101, 64, 53, 48, 51, 97, 55, 50, 99, 97,
				53, 52, 57, 54, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 66, 117, 105, 108, 100, 105, 110,
				103, 66, 108, 111, 99, 107, 115, 92, 77, 117,
				108, 116, 105, 112, 108, 97, 121, 101, 114, 66,
				108, 111, 99, 107, 115, 92, 80, 104, 111, 116,
				111, 110, 70, 117, 115, 105, 111, 110, 92, 78,
				101, 116, 119, 111, 114, 107, 101, 100, 65, 118,
				97, 116, 97, 114, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 65, 118, 97, 116, 97, 114, 66,
				101, 104, 97, 118, 105, 111, 117, 114, 70, 117,
				115, 105, 111, 110, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 156, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 99, 111, 114, 101, 64, 53, 48,
				51, 97, 55, 50, 99, 97, 53, 52, 57, 54,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 66,
				117, 105, 108, 100, 105, 110, 103, 66, 108, 111,
				99, 107, 115, 92, 77, 117, 108, 116, 105, 112,
				108, 97, 121, 101, 114, 66, 108, 111, 99, 107,
				115, 92, 80, 104, 111, 116, 111, 110, 70, 117,
				115, 105, 111, 110, 92, 78, 101, 116, 119, 111,
				114, 107, 101, 100, 65, 118, 97, 116, 97, 114,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 65,
				118, 97, 116, 97, 114, 83, 112, 97, 119, 110,
				101, 114, 70, 117, 115, 105, 111, 110, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 169, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 99, 111, 114,
				101, 64, 53, 48, 51, 97, 55, 50, 99, 97,
				53, 52, 57, 54, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 66, 117, 105, 108, 100, 105, 110,
				103, 66, 108, 111, 99, 107, 115, 92, 77, 117,
				108, 116, 105, 112, 108, 97, 121, 101, 114, 66,
				108, 111, 99, 107, 115, 92, 80, 104, 111, 116,
				111, 110, 70, 117, 115, 105, 111, 110, 92, 78,
				101, 116, 119, 111, 114, 107, 101, 100, 71, 114,
				97, 98, 98, 97, 98, 108, 101, 79, 98, 106,
				101, 99, 116, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 84, 114, 97, 110, 115, 102, 101, 114,
				79, 119, 110, 101, 114, 115, 104, 105, 112, 70,
				117, 115, 105, 111, 110, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 162, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 99, 111, 114, 101, 64, 53,
				48, 51, 97, 55, 50, 99, 97, 53, 52, 57,
				54, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				66, 117, 105, 108, 100, 105, 110, 103, 66, 108,
				111, 99, 107, 115, 92, 77, 117, 108, 116, 105,
				112, 108, 97, 121, 101, 114, 66, 108, 111, 99,
				107, 115, 92, 80, 104, 111, 116, 111, 110, 70,
				117, 115, 105, 111, 110, 92, 78, 101, 116, 119,
				111, 114, 107, 82, 117, 110, 110, 101, 114, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 67, 117,
				115, 116, 111, 109, 78, 101, 116, 119, 111, 114,
				107, 79, 98, 106, 101, 99, 116, 80, 114, 111,
				118, 105, 100, 101, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 149, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 99, 111, 114, 101, 64, 53,
				48, 51, 97, 55, 50, 99, 97, 53, 52, 57,
				54, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				66, 117, 105, 108, 100, 105, 110, 103, 66, 108,
				111, 99, 107, 115, 92, 77, 117, 108, 116, 105,
				112, 108, 97, 121, 101, 114, 66, 108, 111, 99,
				107, 115, 92, 80, 104, 111, 116, 111, 110, 70,
				117, 115, 105, 111, 110, 92, 78, 101, 116, 119,
				111, 114, 107, 82, 117, 110, 110, 101, 114, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 70, 117,
				115, 105, 111, 110, 66, 66, 69, 118, 101, 110,
				116, 115, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 154, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 99, 111, 114, 101, 64, 53, 48, 51, 97,
				55, 50, 99, 97, 53, 52, 57, 54, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 66, 117, 105,
				108, 100, 105, 110, 103, 66, 108, 111, 99, 107,
				115, 92, 77, 117, 108, 116, 105, 112, 108, 97,
				121, 101, 114, 66, 108, 111, 99, 107, 115, 92,
				80, 104, 111, 116, 111, 110, 70, 117, 115, 105,
				111, 110, 92, 80, 108, 97, 121, 101, 114, 78,
				97, 109, 101, 84, 97, 103, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 80, 108, 97, 121, 101,
				114, 78, 97, 109, 101, 84, 97, 103, 70, 117,
				115, 105, 111, 110, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 161, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 99, 111, 114, 101, 64, 53, 48,
				51, 97, 55, 50, 99, 97, 53, 52, 57, 54,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 66,
				117, 105, 108, 100, 105, 110, 103, 66, 108, 111,
				99, 107, 115, 92, 77, 117, 108, 116, 105, 112,
				108, 97, 121, 101, 114, 66, 108, 111, 99, 107,
				115, 92, 80, 104, 111, 116, 111, 110, 70, 117,
				115, 105, 111, 110, 92, 80, 108, 97, 121, 101,
				114, 78, 97, 109, 101, 84, 97, 103, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 80, 108, 97,
				121, 101, 114, 78, 97, 109, 101, 84, 97, 103,
				83, 112, 97, 119, 110, 101, 114, 70, 117, 115,
				105, 111, 110, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 153, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 99, 111, 114, 101, 64, 53, 48, 51,
				97, 55, 50, 99, 97, 53, 52, 57, 54, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 66, 117,
				105, 108, 100, 105, 110, 103, 66, 108, 111, 99,
				107, 115, 92, 77, 117, 108, 116, 105, 112, 108,
				97, 121, 101, 114, 66, 108, 111, 99, 107, 115,
				92, 80, 104, 111, 116, 111, 110, 70, 117, 115,
				105, 111, 110, 92, 80, 108, 97, 121, 101, 114,
				86, 111, 105, 99, 101, 67, 104, 97, 116, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 76, 105,
				112, 83, 121, 110, 99, 80, 104, 111, 116, 111,
				110, 70, 105, 120, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 147, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 99, 111, 114, 101, 64, 53, 48,
				51, 97, 55, 50, 99, 97, 53, 52, 57, 54,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 66,
				117, 105, 108, 100, 105, 110, 103, 66, 108, 111,
				99, 107, 115, 92, 77, 117, 108, 116, 105, 112,
				108, 97, 121, 101, 114, 66, 108, 111, 99, 107,
				115, 92, 80, 104, 111, 116, 111, 110, 70, 117,
				115, 105, 111, 110, 92, 80, 108, 97, 121, 101,
				114, 86, 111, 105, 99, 101, 67, 104, 97, 116,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 86,
				111, 105, 99, 101, 83, 101, 116, 117, 112, 46,
				99, 115
			},
			TypesData = new byte[970]
			{
				0, 0, 0, 0, 56, 77, 101, 116, 97, 46,
				88, 82, 46, 77, 117, 108, 116, 105, 112, 108,
				97, 121, 101, 114, 66, 108, 111, 99, 107, 115,
				46, 67, 111, 108, 111, 99, 97, 116, 105, 111,
				110, 46, 70, 117, 115, 105, 111, 110, 124, 70,
				117, 115, 105, 111, 110, 65, 110, 99, 104, 111,
				114, 0, 0, 0, 0, 59, 77, 101, 116, 97,
				46, 88, 82, 46, 77, 117, 108, 116, 105, 112,
				108, 97, 121, 101, 114, 66, 108, 111, 99, 107,
				115, 46, 67, 111, 108, 111, 99, 97, 116, 105,
				111, 110, 46, 70, 117, 115, 105, 111, 110, 124,
				70, 117, 115, 105, 111, 110, 77, 101, 115, 115,
				101, 110, 103, 101, 114, 0, 0, 0, 0, 58,
				77, 101, 116, 97, 46, 88, 82, 46, 77, 117,
				108, 116, 105, 112, 108, 97, 121, 101, 114, 66,
				108, 111, 99, 107, 115, 46, 70, 117, 115, 105,
				111, 110, 124, 70, 117, 115, 105, 111, 110, 78,
				101, 116, 119, 111, 114, 107, 66, 111, 111, 116,
				115, 116, 114, 97, 112, 112, 101, 114, 0, 0,
				0, 0, 61, 77, 101, 116, 97, 46, 88, 82,
				46, 77, 117, 108, 116, 105, 112, 108, 97, 121,
				101, 114, 66, 108, 111, 99, 107, 115, 46, 67,
				111, 108, 111, 99, 97, 116, 105, 111, 110, 46,
				70, 117, 115, 105, 111, 110, 124, 70, 117, 115,
				105, 111, 110, 78, 101, 116, 119, 111, 114, 107,
				68, 97, 116, 97, 0, 0, 0, 0, 56, 77,
				101, 116, 97, 46, 88, 82, 46, 77, 117, 108,
				116, 105, 112, 108, 97, 121, 101, 114, 66, 108,
				111, 99, 107, 115, 46, 67, 111, 108, 111, 99,
				97, 116, 105, 111, 110, 46, 70, 117, 115, 105,
				111, 110, 124, 70, 117, 115, 105, 111, 110, 80,
				108, 97, 121, 101, 114, 0, 0, 0, 0, 72,
				77, 101, 116, 97, 46, 88, 82, 46, 77, 117,
				108, 116, 105, 112, 108, 97, 121, 101, 114, 66,
				108, 111, 99, 107, 115, 46, 67, 111, 108, 111,
				99, 97, 116, 105, 111, 110, 46, 70, 117, 115,
				105, 111, 110, 124, 70, 117, 115, 105, 111, 110,
				83, 104, 97, 114, 101, 65, 110, 100, 76, 111,
				99, 97, 108, 105, 122, 101, 80, 97, 114, 97,
				109, 115, 0, 0, 0, 0, 56, 77, 101, 116,
				97, 46, 88, 82, 46, 77, 117, 108, 116, 105,
				112, 108, 97, 121, 101, 114, 66, 108, 111, 99,
				107, 115, 46, 70, 117, 115, 105, 111, 110, 124,
				67, 117, 115, 116, 111, 109, 77, 97, 116, 99,
				104, 109, 97, 107, 105, 110, 103, 70, 117, 115,
				105, 111, 110, 0, 0, 0, 0, 54, 77, 101,
				116, 97, 46, 88, 82, 46, 77, 117, 108, 116,
				105, 112, 108, 97, 121, 101, 114, 66, 108, 111,
				99, 107, 115, 46, 70, 117, 115, 105, 111, 110,
				124, 65, 118, 97, 116, 97, 114, 66, 101, 104,
				97, 118, 105, 111, 117, 114, 70, 117, 115, 105,
				111, 110, 0, 0, 0, 0, 52, 77, 101, 116,
				97, 46, 88, 82, 46, 77, 117, 108, 116, 105,
				112, 108, 97, 121, 101, 114, 66, 108, 111, 99,
				107, 115, 46, 70, 117, 115, 105, 111, 110, 124,
				65, 118, 97, 116, 97, 114, 83, 112, 97, 119,
				110, 101, 114, 70, 117, 115, 105, 111, 110, 0,
				0, 0, 0, 56, 77, 101, 116, 97, 46, 88,
				82, 46, 77, 117, 108, 116, 105, 112, 108, 97,
				121, 101, 114, 66, 108, 111, 99, 107, 115, 46,
				70, 117, 115, 105, 111, 110, 124, 84, 114, 97,
				110, 115, 102, 101, 114, 79, 119, 110, 101, 114,
				115, 104, 105, 112, 70, 117, 115, 105, 111, 110,
				0, 0, 0, 0, 60, 77, 101, 116, 97, 46,
				88, 82, 46, 77, 117, 108, 116, 105, 112, 108,
				97, 121, 101, 114, 66, 108, 111, 99, 107, 115,
				46, 70, 117, 115, 105, 111, 110, 124, 67, 117,
				115, 116, 111, 109, 78, 101, 116, 119, 111, 114,
				107, 79, 98, 106, 101, 99, 116, 80, 114, 111,
				118, 105, 100, 101, 114, 0, 0, 0, 0, 47,
				77, 101, 116, 97, 46, 88, 82, 46, 77, 117,
				108, 116, 105, 112, 108, 97, 121, 101, 114, 66,
				108, 111, 99, 107, 115, 46, 70, 117, 115, 105,
				111, 110, 124, 70, 117, 115, 105, 111, 110, 66,
				66, 69, 118, 101, 110, 116, 115, 0, 0, 0,
				0, 52, 77, 101, 116, 97, 46, 88, 82, 46,
				77, 117, 108, 116, 105, 112, 108, 97, 121, 101,
				114, 66, 108, 111, 99, 107, 115, 46, 70, 117,
				115, 105, 111, 110, 124, 80, 108, 97, 121, 101,
				114, 78, 97, 109, 101, 84, 97, 103, 70, 117,
				115, 105, 111, 110, 0, 0, 0, 0, 59, 77,
				101, 116, 97, 46, 88, 82, 46, 77, 117, 108,
				116, 105, 112, 108, 97, 121, 101, 114, 66, 108,
				111, 99, 107, 115, 46, 70, 117, 115, 105, 111,
				110, 124, 80, 108, 97, 121, 101, 114, 78, 97,
				109, 101, 84, 97, 103, 83, 112, 97, 119, 110,
				101, 114, 70, 117, 115, 105, 111, 110, 0, 0,
				0, 0, 49, 77, 101, 116, 97, 46, 88, 82,
				46, 77, 117, 108, 116, 105, 112, 108, 97, 121,
				101, 114, 66, 108, 111, 99, 107, 115, 46, 70,
				117, 115, 105, 111, 110, 124, 76, 105, 112, 83,
				121, 110, 99, 80, 104, 111, 116, 111, 110, 70,
				105, 120, 0, 0, 0, 0, 43, 77, 101, 116,
				97, 46, 88, 82, 46, 77, 117, 108, 116, 105,
				112, 108, 97, 121, 101, 114, 66, 108, 111, 99,
				107, 115, 46, 70, 117, 115, 105, 111, 110, 124,
				86, 111, 105, 99, 101, 83, 101, 116, 117, 112
			},
			TotalFiles = 16,
			TotalTypes = 16,
			IsEditorOnly = false
		};
	}
}
namespace Meta.XR.MultiplayerBlocks.Fusion
{
	[NetworkBehaviourWeaved(0)]
	public class FusionNetworkBootstrapper : NetworkBehaviour
	{
		[SerializeField]
		private GameObject anchorPrefab;

		[SerializeField]
		private FusionNetworkData networkData;

		[SerializeField]
		private FusionMessenger networkMessenger;

		private NetworkBootstrapperParams _params;

		private void Awake()
		{
			_params.ovrCameraRig = UnityEngine.Object.FindObjectOfType<OVRCameraRig>();
			_params.colocationController = UnityEngine.Object.FindObjectOfType<ColocationController>();
			_params.setupColocationReadyEvents = delegate
			{
				_params.colocationLauncher.ColocationReady += OnColocationReady;
			};
		}

		public override void Spawned()
		{
			PlatformInit.GetEntitlementInformation(delegate(PlatformInfo info)
			{
				if (info.OculusUser != null)
				{
					NetworkBootstrapperUtils.SetEntitlementIds(info, ref _params);
					NetworkBootstrapperUtils.SetUpAndStartAutomaticColocation(ref _params, anchorPrefab, networkData, networkMessenger);
				}
			});
		}

		private void OnColocationReady()
		{
			if (_params.colocationController != null)
			{
				_params.colocationController.ColocationReadyCallbacks.Invoke();
			}
			Meta.XR.MultiplayerBlocks.Colocation.Logger.Log("FusionNetworkBootstrapper: Colocation is successful and ready", LogLevel.Info);
		}

		[WeaverGenerated]
		public override void CopyBackingFieldsToState(bool P_0)
		{
		}

		[WeaverGenerated]
		public override void CopyStateToBackingFields()
		{
		}
	}
	public class CustomMatchmakingFusion : MonoBehaviour, CustomMatchmaking.ICustomMatchmakingBehaviour
	{
		[SerializeField]
		[Tooltip("Indicates the chosen game mode to be used.")]
		private GameMode gameMode = GameMode.Shared;

		[SerializeField]
		[Tooltip("Amount of time in seconds to wait for receiving the session list of a lobby before timing out.")]
		private int getSessionListTimeoutS = 10;

		private NetworkRunner _runnerPrefab;

		private List<SessionInfo> _sessionList;

		public GameMode GameMode
		{
			get
			{
				return gameMode;
			}
			set
			{
				gameMode = value;
			}
		}

		public bool SupportsRoomPassword => false;

		public bool IsConnected => GetActiveNetworkRunner() != null;

		public string ConnectedRoomToken => GetActiveNetworkRunner()?.SessionInfo.Name;

		private void Awake()
		{
			_runnerPrefab = UnityEngine.Object.FindFirstObjectByType<NetworkRunner>();
			if (_runnerPrefab == null)
			{
				throw new InvalidOperationException("Fusion NetworkRunner not found");
			}
		}

		private void OnEnable()
		{
			FusionBBEvents.OnSessionListUpdated += OnSessionListUpdated;
		}

		private void OnDisable()
		{
			FusionBBEvents.OnSessionListUpdated -= OnSessionListUpdated;
		}

		private NetworkRunner InitializeNetworkRunner()
		{
			_runnerPrefab.gameObject.SetActive(value: false);
			NetworkRunner networkRunner = UnityEngine.Object.Instantiate(_runnerPrefab);
			networkRunner.gameObject.SetActive(value: true);
			UnityEngine.Object.DontDestroyOnLoad(networkRunner);
			networkRunner.name = "Temporary Runner Prefab";
			return networkRunner;
		}

		public async Task<CustomMatchmaking.RoomOperationResult> CreateRoom(CustomMatchmaking.RoomCreationOptions options)
		{
			string sessionName = RunTimeUtils.GenerateRandomString(6, includeLowercase: false, includeUppercase: true, includeNumeric: false);
			StartGameResult startGameResult = await InitializeNetworkRunner().StartGame(new StartGameArgs
			{
				GameMode = gameMode,
				Scene = GetSceneInfo(),
				CustomLobbyName = options.LobbyName,
				SessionName = sessionName,
				PlayerCount = options.MaxPlayersPerRoom,
				IsVisible = !options.IsPrivate
			});
			return new CustomMatchmaking.RoomOperationResult
			{
				ErrorMessage = (startGameResult.Ok ? null : $"Failed to Start: {startGameResult.ShutdownReason}, Error Message: {startGameResult.ErrorMessage}"),
				RoomToken = sessionName
			};
		}

		public async Task<CustomMatchmaking.RoomOperationResult> JoinRoom(string roomToken, string roomPassword = null)
		{
			StartGameResult startGameResult = await InitializeNetworkRunner().StartGame(new StartGameArgs
			{
				GameMode = gameMode,
				Scene = GetSceneInfo(),
				SessionName = roomToken
			});
			return new CustomMatchmaking.RoomOperationResult
			{
				ErrorMessage = (startGameResult.Ok ? null : $"Failed to Start: {startGameResult.ShutdownReason}, Error Message: {startGameResult.ErrorMessage}"),
				RoomToken = roomToken,
				RoomPassword = roomPassword
			};
		}

		public async Task<CustomMatchmaking.RoomOperationResult> JoinOpenRoom(string lobbyName)
		{
			ClearSessionList();
			NetworkRunner runner = InitializeNetworkRunner();
			StartGameResult startGameResult = await runner.JoinSessionLobby(SessionLobby.Custom, lobbyName, null, null, false);
			if (!startGameResult.Ok)
			{
				return new CustomMatchmaking.RoomOperationResult
				{
					ErrorMessage = $"Failed to Start: {startGameResult.ShutdownReason}, Error Message: {startGameResult.ErrorMessage}"
				};
			}
			List<SessionInfo> list = await GetSessionList(getSessionListTimeoutS);
			if (list == null)
			{
				return new CustomMatchmaking.RoomOperationResult
				{
					ErrorMessage = "Failed to fetch the session list from the Lobby " + lobbyName
				};
			}
			if (list.Count == 0)
			{
				return new CustomMatchmaking.RoomOperationResult
				{
					ErrorMessage = "No available sessions to join in Lobby " + lobbyName
				};
			}
			SessionInfo session = SelectSessionToJoinFromList(list);
			if (session == null)
			{
				return new CustomMatchmaking.RoomOperationResult
				{
					ErrorMessage = "Failed to select a session to join from the session list"
				};
			}
			StartGameResult startGameResult2 = await runner.StartGame(new StartGameArgs
			{
				GameMode = gameMode,
				Scene = GetSceneInfo(),
				SessionName = session.Name
			});
			return new CustomMatchmaking.RoomOperationResult
			{
				ErrorMessage = (startGameResult2.Ok ? null : $"Failed to Start: {startGameResult2.ShutdownReason}, Error Message: {startGameResult2.ErrorMessage}"),
				RoomToken = session.Name
			};
		}

		public void LeaveRoom()
		{
			for (int num = NetworkRunner.Instances.Count - 1; num >= 0; num--)
			{
				NetworkRunner networkRunner = NetworkRunner.Instances[num];
				if (!(networkRunner == null) && networkRunner.IsRunning)
				{
					networkRunner.Shutdown();
					UnityEngine.Object.Destroy(networkRunner.gameObject);
				}
			}
		}

		private static NetworkRunner GetActiveNetworkRunner()
		{
			for (int num = NetworkRunner.Instances.Count - 1; num >= 0; num--)
			{
				NetworkRunner networkRunner = NetworkRunner.Instances[num];
				if (networkRunner != null && networkRunner.IsRunning)
				{
					return networkRunner;
				}
			}
			return null;
		}

		private static NetworkSceneInfo GetSceneInfo()
		{
			SceneRef sceneRef = default(SceneRef);
			if (TryGetActiveSceneRef(out var sceneRef2))
			{
				sceneRef = sceneRef2;
			}
			NetworkSceneInfo result = default(NetworkSceneInfo);
			if (sceneRef.IsValid)
			{
				result.AddSceneRef(sceneRef, LoadSceneMode.Additive);
			}
			return result;
		}

		private static bool TryGetActiveSceneRef(out SceneRef sceneRef)
		{
			Scene activeScene = SceneManager.GetActiveScene();
			if (activeScene.buildIndex < 0 || activeScene.buildIndex >= SceneManager.sceneCountInBuildSettings)
			{
				sceneRef = default(SceneRef);
				return false;
			}
			sceneRef = SceneRef.FromIndex(activeScene.buildIndex);
			return true;
		}

		private void ClearSessionList()
		{
			_sessionList = null;
		}

		private async Task<List<SessionInfo>> GetSessionList(float timeoutS)
		{
			TaskCompletionSource<List<SessionInfo>> tcs = new TaskCompletionSource<List<SessionInfo>>();
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(timeoutS));
			cancellationTokenSource.Token.Register(delegate
			{
				tcs.TrySetResult(null);
			});
			while (_sessionList == null && !cancellationTokenSource.Token.IsCancellationRequested)
			{
				await Task.Delay(100);
			}
			if (_sessionList != null)
			{
				tcs.TrySetResult(_sessionList);
			}
			return await tcs.Task;
		}

		protected virtual SessionInfo SelectSessionToJoinFromList(List<SessionInfo> sessionList)
		{
			if (sessionList.Count != 0)
			{
				return sessionList[0];
			}
			return null;
		}

		private void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
		{
			_sessionList = sessionList;
		}
	}
	[NetworkBehaviourWeaved(904)]
	public class AvatarBehaviourFusion : NetworkBehaviour, IAvatarBehaviour
	{
		private const float LERP_TIME = 0.5f;

		private const int AvatarDataStreamMaxCapacity = 900;

		private Transform _cameraRig;

		private byte[] _buffer;

		[WeaverGenerated]
		[SerializeField]
		[DefaultForProperty("OculusId", 0, 2)]
		[DrawIf("IsEditorWritable", true, CompareOperator.Equal, DrawIfMode.ReadOnly)]
		private ulong _OculusId;

		[WeaverGenerated]
		[SerializeField]
		[DefaultForProperty("LocalAvatarIndex", 2, 1)]
		[DrawIf("IsEditorWritable", true, CompareOperator.Equal, DrawIfMode.ReadOnly)]
		private int _LocalAvatarIndex;

		[WeaverGenerated]
		[DefaultForProperty("AvatarDataStreamLength", 3, 1)]
		[DrawIf("IsEditorWritable", true, CompareOperator.Equal, DrawIfMode.ReadOnly)]
		private int _AvatarDataStreamLength;

		[WeaverGenerated]
		[DefaultForProperty("AvatarDataStream", 4, 900)]
		[DrawIf("IsEditorWritable", true, CompareOperator.Equal, DrawIfMode.ReadOnly)]
		private byte[] _AvatarDataStream;

		[Networked]
		[OnChangedRender("OnAvatarIdChanged")]
		[NetworkedWeaved(0, 2)]
		public unsafe ulong OculusId
		{
			get
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing AvatarBehaviourFusion.OculusId. Networked properties can only be accessed when Spawned() has been called.");
				}
				return *(ulong*)((byte*)base.Ptr + 0);
			}
			set
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing AvatarBehaviourFusion.OculusId. Networked properties can only be accessed when Spawned() has been called.");
				}
				*(ulong*)((byte*)base.Ptr + 0) = value;
			}
		}

		[Networked]
		[OnChangedRender("OnAvatarIdChanged")]
		[NetworkedWeaved(2, 1)]
		public unsafe int LocalAvatarIndex
		{
			get
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing AvatarBehaviourFusion.LocalAvatarIndex. Networked properties can only be accessed when Spawned() has been called.");
				}
				return base.Ptr[2];
			}
			set
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing AvatarBehaviourFusion.LocalAvatarIndex. Networked properties can only be accessed when Spawned() has been called.");
				}
				base.Ptr[2] = value;
			}
		}

		[Networked]
		[NetworkedWeaved(3, 1)]
		private unsafe int AvatarDataStreamLength
		{
			get
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing AvatarBehaviourFusion.AvatarDataStreamLength. Networked properties can only be accessed when Spawned() has been called.");
				}
				return base.Ptr[3];
			}
			set
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing AvatarBehaviourFusion.AvatarDataStreamLength. Networked properties can only be accessed when Spawned() has been called.");
				}
				base.Ptr[3] = value;
			}
		}

		[Networked]
		[Capacity(900)]
		[OnChangedRender("OnAvatarDataStreamChanged")]
		[NetworkedWeaved(4, 900)]
		[NetworkedWeavedArray(900, 1, typeof(global::Fusion.ElementReaderWriterByte))]
		private unsafe NetworkArray<byte> AvatarDataStream
		{
			get
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing AvatarBehaviourFusion.AvatarDataStream. Networked properties can only be accessed when Spawned() has been called.");
				}
				return new NetworkArray<byte>((byte*)base.Ptr + 16, 900, global::Fusion.ElementReaderWriterByte.GetInstance());
			}
		}

		public override void Spawned()
		{
			if ((bool)OVRManager.instance)
			{
				_cameraRig = OVRManager.instance.GetComponentInChildren<OVRCameraRig>().transform;
			}
		}

		private void OnAvatarIdChanged()
		{
		}

		private void OnAvatarDataStreamChanged()
		{
		}

		public override void FixedUpdateNetwork()
		{
			if (base.Object.HasStateAuthority && !(_cameraRig == null))
			{
				Transform transform = base.transform;
				base.transform.position = Vector3.Lerp(transform.position, _cameraRig.position, 0.5f);
				base.transform.rotation = Quaternion.Lerp(transform.rotation, _cameraRig.rotation, 0.5f);
			}
		}

		public void ReceiveStreamData(byte[] bytes)
		{
			if (bytes.Length > 900)
			{
				UnityEngine.Debug.LogError(string.Format("[{0}] Cannot send a stream data of length {1} greater than the max capacity of {2}", "AvatarBehaviourFusion", bytes.Length, 900));
				return;
			}
			AvatarDataStreamLength = bytes.Length;
			AvatarDataStream.CopyFrom(bytes, 0, bytes.Length);
		}

		[WeaverGenerated]
		public override void CopyBackingFieldsToState(bool P_0)
		{
			OculusId = _OculusId;
			LocalAvatarIndex = _LocalAvatarIndex;
			AvatarDataStreamLength = _AvatarDataStreamLength;
			NetworkBehaviourUtils.InitializeNetworkArray(AvatarDataStream, _AvatarDataStream, "AvatarDataStream");
		}

		[WeaverGenerated]
		public override void CopyStateToBackingFields()
		{
			_OculusId = OculusId;
			_LocalAvatarIndex = LocalAvatarIndex;
			_AvatarDataStreamLength = AvatarDataStreamLength;
			NetworkBehaviourUtils.CopyFromNetworkArray(AvatarDataStream, ref _AvatarDataStream);
		}
	}
	public class AvatarSpawnerFusion : MonoBehaviour
	{
		[Tooltip("Control when you want to load the avatar.")]
		[SerializeField]
		private bool loadAvatarWhenConnected = true;

		[SerializeField]
		private GameObject avatarBehavior;

		[SerializeField]
		private GameObject avatarBehaviorSdk28Plus;

		[Tooltip("Specify the number of preset avatars available in the project. The maximum size depends on the SDK version.")]
		[SerializeField]
		private int preloadedSampleAvatarSize = 6;

		[Tooltip("Adjust the level of detail used when streaming the avatars.")]
		[SerializeField]
		private AvatarStreamLOD avatarStreamLOD = AvatarStreamLOD.Medium;

		[Tooltip("Adjust the update interval used when streaming the avatars.")]
		[SerializeField]
		private float avatarUpdateIntervalInSec = 0.08f;
	}
	[NetworkBehaviourWeaved(0)]
	public class TransferOwnershipFusion : NetworkBehaviour, ITransferOwnership
	{
		public void TransferOwnershipToLocalPlayer()
		{
			base.Object.RequestStateAuthority();
		}

		public bool HasOwnership()
		{
			return base.HasStateAuthority;
		}

		[WeaverGenerated]
		public override void CopyBackingFieldsToState(bool P_0)
		{
		}

		[WeaverGenerated]
		public override void CopyStateToBackingFields()
		{
		}
	}
	public class CustomNetworkObjectProvider : NetworkObjectProviderDefault
	{
		private static NetworkObjectBaker _baker;

		private static readonly Dictionary<uint, Func<GameObject>> CustomSpawnDict = new Dictionary<uint, Func<GameObject>>();

		private static NetworkObjectBaker Baker => _baker ?? (_baker = new NetworkObjectBaker());

		public static void RegisterCustomNetworkObject(uint customPrefabID, Func<GameObject> func)
		{
			if (CustomSpawnDict.ContainsKey(customPrefabID))
			{
				UnityEngine.Debug.LogError($"The requested customPrefabID {customPrefabID} already existed, aborting registration");
			}
			CustomSpawnDict[customPrefabID] = func;
		}

		public override NetworkObjectAcquireResult AcquirePrefabInstance(NetworkRunner runner, in NetworkPrefabAcquireContext context, out NetworkObject result)
		{
			if (CustomSpawnDict.TryGetValue(context.PrefabId.RawValue, out var value))
			{
				GameObject gameObject = value();
				NetworkObject networkObject = gameObject.GetComponent<NetworkObject>();
				if (networkObject == null)
				{
					networkObject = gameObject.AddComponent<NetworkObject>();
				}
				Baker.Bake(gameObject);
				if (context.DontDestroyOnLoad)
				{
					runner.MakeDontDestroyOnLoad(gameObject);
				}
				else
				{
					runner.MoveToRunnerScene(gameObject);
				}
				result = networkObject;
				return NetworkObjectAcquireResult.Success;
			}
			return base.AcquirePrefabInstance(runner, in context, out result);
		}
	}
	public class FusionBBEvents : MonoBehaviour, INetworkRunnerCallbacks, IPublicFacingInterface
	{
		public static event Action<NetworkRunner> OnConnectedToServer;

		public static event Action<NetworkRunner, PlayerRef> OnPlayerJoined;

		public static event Action<NetworkRunner, NetworkInput> OnInput;

		public static event Action<NetworkRunner, NetAddress, NetConnectFailedReason> OnConnectFailed;

		public static event Action<NetworkRunner, NetworkRunnerCallbackArgs.ConnectRequest, byte[]> OnConnectRequest;

		public static event Action<NetworkRunner, Dictionary<string, object>> OnCustomAuthenticationResponse;

		public static event Action<NetworkRunner, HostMigrationToken> OnHostMigration;

		public static event Action<NetworkRunner, PlayerRef, NetworkInput> OnInputMissing;

		public static event Action<NetworkRunner, PlayerRef> OnPlayerLeft;

		public static event Action<NetworkRunner> OnSceneLoadDone;

		public static event Action<NetworkRunner> OnSceneLoadStart;

		public static event Action<NetworkRunner, List<SessionInfo>> OnSessionListUpdated;

		public static event Action<NetworkRunner, ShutdownReason> OnShutdown;

		public static event Action<NetworkRunner, SimulationMessagePtr> OnUserSimulationMessage;

		public static event Action<NetworkRunner, NetworkObject, PlayerRef> OnObjectExitAOI;

		public static event Action<NetworkRunner, NetworkObject, PlayerRef> OnObjectEnterAOI;

		public static event Action<NetworkRunner, NetDisconnectReason> OnDisconnectedFromServer;

		public static event Action<NetworkRunner, PlayerRef, ReliableKey, ArraySegment<byte>> OnReliableDataReceived;

		public static event Action<NetworkRunner, PlayerRef, ReliableKey, float> OnReliableDataProgress;

		void INetworkRunnerCallbacks.OnConnectedToServer(NetworkRunner runner)
		{
			FusionBBEvents.OnConnectedToServer?.Invoke(runner);
		}

		void INetworkRunnerCallbacks.OnPlayerJoined(NetworkRunner runner, PlayerRef player)
		{
			FusionBBEvents.OnPlayerJoined?.Invoke(runner, player);
		}

		void INetworkRunnerCallbacks.OnInput(NetworkRunner runner, NetworkInput input)
		{
			FusionBBEvents.OnInput?.Invoke(runner, input);
		}

		void INetworkRunnerCallbacks.OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
		{
			UnityEngine.Debug.LogWarning("OnConnectFailed");
			FusionBBEvents.OnConnectFailed?.Invoke(runner, remoteAddress, reason);
		}

		void INetworkRunnerCallbacks.OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
		{
			UnityEngine.Debug.LogWarning("OnConnectRequest");
			FusionBBEvents.OnConnectRequest?.Invoke(runner, request, token);
		}

		void INetworkRunnerCallbacks.OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
		{
			FusionBBEvents.OnCustomAuthenticationResponse?.Invoke(runner, data);
		}

		void INetworkRunnerCallbacks.OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
		{
			FusionBBEvents.OnHostMigration?.Invoke(runner, hostMigrationToken);
		}

		void INetworkRunnerCallbacks.OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
		{
			FusionBBEvents.OnInputMissing?.Invoke(runner, player, input);
		}

		void INetworkRunnerCallbacks.OnPlayerLeft(NetworkRunner runner, PlayerRef player)
		{
			FusionBBEvents.OnPlayerLeft?.Invoke(runner, player);
		}

		void INetworkRunnerCallbacks.OnSceneLoadDone(NetworkRunner runner)
		{
			FusionBBEvents.OnSceneLoadDone?.Invoke(runner);
		}

		void INetworkRunnerCallbacks.OnSceneLoadStart(NetworkRunner runner)
		{
			FusionBBEvents.OnSceneLoadStart?.Invoke(runner);
		}

		void INetworkRunnerCallbacks.OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
		{
			FusionBBEvents.OnSessionListUpdated?.Invoke(runner, sessionList);
		}

		void INetworkRunnerCallbacks.OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
		{
			FusionBBEvents.OnShutdown?.Invoke(runner, shutdownReason);
		}

		void INetworkRunnerCallbacks.OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
		{
			FusionBBEvents.OnUserSimulationMessage?.Invoke(runner, message);
		}

		void INetworkRunnerCallbacks.OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
		{
			FusionBBEvents.OnObjectExitAOI?.Invoke(runner, obj, player);
		}

		void INetworkRunnerCallbacks.OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
		{
			FusionBBEvents.OnObjectEnterAOI?.Invoke(runner, obj, player);
		}

		void INetworkRunnerCallbacks.OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
		{
			FusionBBEvents.OnDisconnectedFromServer?.Invoke(runner, reason);
		}

		void INetworkRunnerCallbacks.OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
		{
			FusionBBEvents.OnReliableDataReceived?.Invoke(runner, player, key, data);
		}

		void INetworkRunnerCallbacks.OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
		{
			FusionBBEvents.OnReliableDataProgress?.Invoke(runner, player, key, progress);
		}
	}
	[NetworkBehaviourWeaved(65)]
	public class PlayerNameTagFusion : NetworkBehaviour
	{
		[WeaverGenerated]
		[SerializeField]
		[DefaultForProperty("OculusName", 0, 65)]
		[DrawIf("IsEditorWritable", true, CompareOperator.Equal, DrawIfMode.ReadOnly)]
		private NetworkString<_64> _OculusName;

		[SerializeField]
		private Text nameTag;

		[SerializeField]
		private GameObject nameTagGO;

		[SerializeField]
		private GameObject nameTagPanel;

		[SerializeField]
		private Transform nameTagContainer;

		[SerializeField]
		private float heightOffset = 0.3f;

		private Transform _centerEye;

		[Networked]
		[OnChangedRender("OnPlayerNameChange")]
		[NetworkedWeaved(0, 65)]
		public unsafe NetworkString<_64> OculusName
		{
			get
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing PlayerNameTagFusion.OculusName. Networked properties can only be accessed when Spawned() has been called.");
				}
				return *(NetworkString<_64>*)((byte*)base.Ptr + 0);
			}
			set
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing PlayerNameTagFusion.OculusName. Networked properties can only be accessed when Spawned() has been called.");
				}
				*(NetworkString<_64>*)((byte*)base.Ptr + 0) = value;
			}
		}

		private void Start()
		{
			nameTagGO.SetActive(!base.Object.HasStateAuthority);
			OnPlayerNameChange();
			if ((bool)OVRManager.instance)
			{
				_centerEye = OVRManager.instance.GetComponentInChildren<OVRCameraRig>().centerEyeAnchor;
			}
		}

		private IEnumerator UpdateNameUI(string playerName)
		{
			nameTag.text = playerName;
			yield return new WaitForFixedUpdate();
			VerticalLayoutGroup component = nameTagPanel.GetComponent<VerticalLayoutGroup>();
			component.enabled = false;
			component.enabled = true;
		}

		private void OnPlayerNameChange()
		{
			StartCoroutine(UpdateNameUI(OculusName.ToString()));
		}

		public override void FixedUpdateNetwork()
		{
			if (base.Object.HasStateAuthority)
			{
				Vector3 position = base.transform.position;
				nameTagContainer.localPosition = new Vector3(position.x, Mathf.Sin(Time.time * 2f), position.z) * 0.005f;
				Vector3 position2 = _centerEye.transform.position;
				position2.y += heightOffset;
				position = Vector3.Lerp(position, position2, 0.1f);
				base.transform.position = position;
			}
		}

		private void Update()
		{
			if (!base.Object.HasStateAuthority && _centerEye != null)
			{
				nameTagGO.transform.LookAt(_centerEye.position, Vector3.up);
			}
		}

		[WeaverGenerated]
		public override void CopyBackingFieldsToState(bool P_0)
		{
			OculusName = _OculusName;
		}

		[WeaverGenerated]
		public override void CopyStateToBackingFields()
		{
			_OculusName = OculusName;
		}
	}
	public class PlayerNameTagSpawnerFusion : MonoBehaviour, INameTagSpawner
	{
		[SerializeField]
		private GameObject playerNameTagPrefab;

		private NetworkRunner _networkRunner;

		private bool _sceneLoaded;

		public bool IsConnected
		{
			get
			{
				if (_networkRunner != null)
				{
					return _sceneLoaded;
				}
				return false;
			}
		}

		private void OnEnable()
		{
			FusionBBEvents.OnSceneLoadDone += OnLoaded;
		}

		private void OnDisable()
		{
			FusionBBEvents.OnSceneLoadDone -= OnLoaded;
		}

		private void OnLoaded(NetworkRunner networkRunner)
		{
			_sceneLoaded = true;
			_networkRunner = networkRunner;
		}

		public void Spawn(string playerName)
		{
			_networkRunner.Spawn(playerNameTagPrefab, Vector3.zero, Quaternion.identity, _networkRunner.LocalPlayer).GetComponent<PlayerNameTagFusion>().OculusName = playerName;
		}
	}
	[RequireComponent(typeof(Recorder))]
	public class LipSyncPhotonFix : MonoBehaviour
	{
	}
	public class VoiceSetup : MonoBehaviour
	{
		public Transform centerEyeAnchor;

		private const uint CustomSpeakerPrefabID = 100000u;

		public GameObject Speaker { get; private set; }

		private void Awake()
		{
			CustomNetworkObjectProvider.RegisterCustomNetworkObject(100000u, delegate
			{
				GameObject obj = new GameObject("Voice");
				AudioSource audioSource = obj.AddComponent<AudioSource>();
				audioSource.bypassReverbZones = true;
				audioSource.spatialBlend = 1f;
				Recorder recorder = obj.AddComponent<Recorder>();
				recorder.StopRecordingWhenPaused = true;
				recorder.SamplingRate = SamplingRate.Sampling48000;
				obj.AddComponent<Speaker>();
				obj.AddComponent<LipSyncPhotonFix>();
				obj.AddComponent<MicAmplifier>().AmplificationFactor = 2f;
				obj.AddComponent<VoiceNetworkObject>();
				obj.AddComponent<NetworkTransform>();
				NetworkObject obj2 = obj.AddComponent<NetworkObject>();
				FieldInfo field = typeof(NetworkObject).GetField("ObjectInterest", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				FieldInfo field2 = typeof(NetworkObject).GetNestedType("ObjectInterestModes", BindingFlags.NonPublic).GetField("AreaOfInterest");
				if (field != null && field2 != null)
				{
					field.SetValue(obj2, (int)field2.GetValue(null));
				}
				return obj;
			});
		}

		private void OnEnable()
		{
			FusionBBEvents.OnSceneLoadDone += OnLoaded;
		}

		private void OnDisable()
		{
			FusionBBEvents.OnSceneLoadDone -= OnLoaded;
		}

		private void OnLoaded(NetworkRunner networkRunner)
		{
			StartCoroutine(SpawnSpeaker(networkRunner));
		}

		private IEnumerator SpawnSpeaker(NetworkRunner networkRunner)
		{
			while (networkRunner == null)
			{
				yield return null;
			}
			NetworkObject networkObject = networkRunner.Spawn(NetworkPrefabId.FromRaw(100000u), centerEyeAnchor.position, centerEyeAnchor.rotation, networkRunner.LocalPlayer);
			networkObject.transform.SetParent(centerEyeAnchor.transform);
			Speaker = networkObject.gameObject;
		}
	}
}
namespace Meta.XR.MultiplayerBlocks.Colocation.Fusion
{
	[Serializable]
	[StructLayout(LayoutKind.Explicit, Size = 280)]
	[NetworkStructWeaved(70)]
	internal struct FusionAnchor(Anchor anchor) : INetworkStruct, IEquatable<FusionAnchor>
	{
		[FieldOffset(0)]
		public NetworkBool isAutomaticAnchor = anchor.isAutomaticAnchor;

		[FieldOffset(4)]
		public NetworkBool isAlignmentAnchor = anchor.isAlignmentAnchor;

		[FieldOffset(8)]
		public ulong ownerOculusId = anchor.ownerOculusId;

		[FieldOffset(16)]
		public uint colocationGroupId = anchor.colocationGroupId;

		[FieldOffset(20)]
		public NetworkString<_64> automaticAnchorUuid = anchor.automaticAnchorUuid.ToString();

		public Anchor GetAnchor()
		{
			if (!Guid.TryParse(automaticAnchorUuid.ToString(), out var result))
			{
				Logger.Log("Failed to parse Anchor UUID string", LogLevel.Error);
			}
			return new Anchor(isAutomaticAnchor, isAlignmentAnchor, ownerOculusId, colocationGroupId, result);
		}

		public bool Equals(FusionAnchor other)
		{
			return GetAnchor().Equals(other.GetAnchor());
		}
	}
	[NetworkBehaviourWeaved(76)]
	internal class FusionMessenger : NetworkBehaviour, INetworkMessenger
	{
		private enum MessageEvent
		{
			AnchorShareRequest,
			AnchorShareComplete
		}

		[WeaverGenerated]
		[DefaultForProperty("_networkIds", 0, 33)]
		[DrawIf("IsEditorWritable", true, CompareOperator.Equal, DrawIfMode.ReadOnly)]
		private int[] __networkIds;

		[WeaverGenerated]
		[DefaultForProperty("_playerIds", 33, 43)]
		[DrawIf("IsEditorWritable", true, CompareOperator.Equal, DrawIfMode.ReadOnly)]
		private ulong[] __playerIds;

		[Networked]
		[Capacity(10)]
		[NetworkedWeaved(0, 33)]
		[NetworkedWeavedLinkedList(10, 1, typeof(global::Fusion.ElementReaderWriterInt32))]
		private unsafe NetworkLinkedList<int> _networkIds
		{
			get
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing FusionMessenger._networkIds. Networked properties can only be accessed when Spawned() has been called.");
				}
				return new NetworkLinkedList<int>((byte*)base.Ptr + 0, 10, global::Fusion.ElementReaderWriterInt32.GetInstance());
			}
		}

		[Networked]
		[Capacity(10)]
		[NetworkedWeaved(33, 43)]
		[NetworkedWeavedLinkedList(10, 2, typeof(global::Fusion.ElementReaderWriterUInt64))]
		private unsafe NetworkLinkedList<ulong> _playerIds
		{
			get
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing FusionMessenger._playerIds. Networked properties can only be accessed when Spawned() has been called.");
				}
				return new NetworkLinkedList<ulong>((byte*)base.Ptr + 132, 10, global::Fusion.ElementReaderWriterUInt64.GetInstance());
			}
		}

		public event Action<ShareAndLocalizeParams> AnchorShareRequestReceived;

		public event Action<ShareAndLocalizeParams> AnchorShareRequestCompleted;

		public void RegisterLocalPlayer(ulong localPlayerId)
		{
			Logger.Log(string.Format("{0}: RegisterLocalPlayer: localPlayerId {1}", "FusionMessenger", localPlayerId), LogLevel.Verbose);
			Logger.Log(string.Format("{0} RegisterLocalPlayer: fusionId {1}", "FusionMessenger", base.Runner.LocalPlayer.PlayerId), LogLevel.Verbose);
			AddPlayerIdHostRPC(localPlayerId, base.Runner.LocalPlayer.PlayerId);
		}

		[Rpc(RpcSources.All, RpcTargets.StateAuthority)]
		private unsafe void AddPlayerIdHostRPC(ulong localPlayerId, int localNetworkId)
		{
			if (base.InvokeRpc)
			{
				base.InvokeRpc = false;
			}
			else
			{
				NetworkBehaviourUtils.ThrowIfBehaviourNotInitialized(this);
				if (base.Runner.Stage == SimulationStages.Resimulate)
				{
					return;
				}
				int localAuthorityMask = base.Object.GetLocalAuthorityMask();
				if ((localAuthorityMask & 7) == 0)
				{
					NetworkBehaviourUtils.NotifyLocalSimulationNotAllowedToSendRpc("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionMessenger::AddPlayerIdHostRPC(System.UInt64,System.Int32)", base.Object, 7);
					return;
				}
				if ((localAuthorityMask & 1) != 1)
				{
					int num = 8;
					num += 8;
					num += 4;
					if (!SimulationMessage.CanAllocateUserPayload(num))
					{
						NetworkBehaviourUtils.NotifyRpcPayloadSizeExceeded("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionMessenger::AddPlayerIdHostRPC(System.UInt64,System.Int32)", num);
						return;
					}
					if (base.Runner.HasAnyActiveConnections())
					{
						SimulationMessage* ptr = SimulationMessage.Allocate(base.Runner.Simulation, num);
						byte* ptr2 = (byte*)ptr + 28;
						*(RpcHeader*)ptr2 = RpcHeader.Create(base.Object.Id, base.ObjectIndex, 1);
						int num2 = 8;
						*(ulong*)(ptr2 + num2) = localPlayerId;
						num2 += 8;
						*(int*)(ptr2 + num2) = localNetworkId;
						num2 += 4;
						ptr->Offset = num2 * 8;
						base.Runner.SendRpc(ptr);
					}
					if ((localAuthorityMask & 1) == 0)
					{
						return;
					}
				}
			}
			Logger.Log("Add Player Id Host RPC: player id", LogLevel.Verbose);
			_playerIds.Add(localPlayerId);
			Logger.Log("Add Player Id Host RPC: network id", LogLevel.Verbose);
			_networkIds.Add(localNetworkId);
			PrintIDDictionary();
		}

		private bool TryGetNetworkId(ulong playerId, out int networkId)
		{
			for (int i = 0; i < _playerIds.Count; i++)
			{
				if (playerId == _playerIds[i])
				{
					networkId = _networkIds[i];
					return true;
				}
			}
			networkId = 0;
			Logger.Log($"FusionMessenger: playerId {playerId} got invalid networkId {networkId}", LogLevel.Error);
			return false;
		}

		public void SendAnchorShareRequest(ulong targetPlayerId, ShareAndLocalizeParams shareAndLocalizeParams)
		{
			Logger.Log(string.Format("{0}: Sending anchor share request to player {1}. (anchorID {2})", "FusionMessenger", targetPlayerId, shareAndLocalizeParams.anchorUUID), LogLevel.Verbose);
			FusionShareAndLocalizeParams fusionData = new FusionShareAndLocalizeParams(shareAndLocalizeParams);
			SendMessageToPlayer(MessageEvent.AnchorShareRequest, targetPlayerId, fusionData);
		}

		public void SendAnchorShareCompleted(ulong targetPlayerId, ShareAndLocalizeParams shareAndLocalizeParams)
		{
			Logger.Log(string.Format("{0}: Sending anchor share completed to player {1}. (anchorID {2})", "FusionMessenger", targetPlayerId, shareAndLocalizeParams.anchorUUID), LogLevel.Verbose);
			FusionShareAndLocalizeParams fusionData = new FusionShareAndLocalizeParams(shareAndLocalizeParams);
			SendMessageToPlayer(MessageEvent.AnchorShareComplete, targetPlayerId, fusionData);
		}

		private void SendMessageToPlayer(MessageEvent eventCode, ulong playerId, FusionShareAndLocalizeParams fusionData)
		{
			Logger.Log($"Calling SendMessageToPlayer with MessageEvent: {eventCode}, to playerId {playerId}", LogLevel.Verbose);
			if (TryGetNetworkId(playerId, out var networkId))
			{
				Logger.Log($"Calling FindRPCToCallServerRPC playerId {playerId} maps to fusionId {networkId}", LogLevel.Verbose);
				FindRPCToCallServerRPC(eventCode, networkId, fusionData);
			}
			else
			{
				Logger.Log($"Could not find fusionId for playerId {playerId}", LogLevel.Error);
			}
		}

		[Rpc(RpcSources.All, RpcTargets.StateAuthority)]
		private unsafe void FindRPCToCallServerRPC(MessageEvent eventCode, int fusionId, FusionShareAndLocalizeParams fusionData, RpcInfo info = default(RpcInfo))
		{
			if (base.InvokeRpc)
			{
				base.InvokeRpc = false;
			}
			else
			{
				NetworkBehaviourUtils.ThrowIfBehaviourNotInitialized(this);
				if (base.Runner.Stage == SimulationStages.Resimulate)
				{
					return;
				}
				int localAuthorityMask = base.Object.GetLocalAuthorityMask();
				if ((localAuthorityMask & 7) == 0)
				{
					NetworkBehaviourUtils.NotifyLocalSimulationNotAllowedToSendRpc("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionMessenger::FindRPCToCallServerRPC(Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionMessenger/MessageEvent,System.Int32,Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionShareAndLocalizeParams,Fusion.RpcInfo)", base.Object, 7);
					return;
				}
				if ((localAuthorityMask & 1) != 1)
				{
					int num = 8;
					num += 4;
					num += 4;
					num += 280;
					if (!SimulationMessage.CanAllocateUserPayload(num))
					{
						NetworkBehaviourUtils.NotifyRpcPayloadSizeExceeded("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionMessenger::FindRPCToCallServerRPC(Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionMessenger/MessageEvent,System.Int32,Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionShareAndLocalizeParams,Fusion.RpcInfo)", num);
						return;
					}
					if (base.Runner.HasAnyActiveConnections())
					{
						SimulationMessage* ptr = SimulationMessage.Allocate(base.Runner.Simulation, num);
						byte* ptr2 = (byte*)ptr + 28;
						*(RpcHeader*)ptr2 = RpcHeader.Create(base.Object.Id, base.ObjectIndex, 2);
						int num2 = 8;
						*(MessageEvent*)(ptr2 + num2) = eventCode;
						num2 += 4;
						*(int*)(ptr2 + num2) = fusionId;
						num2 += 4;
						*(FusionShareAndLocalizeParams*)(ptr2 + num2) = fusionData;
						num2 += 280;
						ptr->Offset = num2 * 8;
						base.Runner.SendRpc(ptr);
					}
					if ((localAuthorityMask & 1) == 0)
					{
						return;
					}
				}
				info = RpcInfo.FromLocal(base.Runner, RpcChannel.Reliable, RpcHostMode.SourceIsServer);
			}
			Logger.Log("FindRPCToCallServerRPC called", LogLevel.Verbose);
			PlayerRef playerRef = PlayerRef.FromIndex(fusionId);
			Logger.Log("Created PlayerRef right before calling HandleMessageClientRPC", LogLevel.Verbose);
			HandleMessageClientRPC(playerRef, eventCode, fusionData);
		}

		[Rpc(RpcSources.All, RpcTargets.All)]
		private unsafe void HandleMessageClientRPC([RpcTarget] PlayerRef playerRef, MessageEvent eventCode, FusionShareAndLocalizeParams fusionData)
		{
			if (base.InvokeRpc)
			{
				base.InvokeRpc = false;
			}
			else
			{
				NetworkBehaviourUtils.ThrowIfBehaviourNotInitialized(this);
				if (base.Runner.Stage == SimulationStages.Resimulate)
				{
					return;
				}
				int localAuthorityMask = base.Object.GetLocalAuthorityMask();
				RpcTargetStatus rpcTargetStatus = base.Runner.GetRpcTargetStatus(playerRef);
				if (rpcTargetStatus == RpcTargetStatus.Unreachable)
				{
					NetworkBehaviourUtils.NotifyRpcTargetUnreachable(playerRef, "System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionMessenger::HandleMessageClientRPC(Fusion.PlayerRef,Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionMessenger/MessageEvent,Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionShareAndLocalizeParams)");
					return;
				}
				if (rpcTargetStatus != RpcTargetStatus.Self)
				{
					if ((localAuthorityMask & 7) == 0)
					{
						NetworkBehaviourUtils.NotifyLocalSimulationNotAllowedToSendRpc("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionMessenger::HandleMessageClientRPC(Fusion.PlayerRef,Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionMessenger/MessageEvent,Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionShareAndLocalizeParams)", base.Object, 7);
						return;
					}
					int num = 8;
					num += 4;
					num += 280;
					if (!SimulationMessage.CanAllocateUserPayload(num))
					{
						NetworkBehaviourUtils.NotifyRpcPayloadSizeExceeded("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionMessenger::HandleMessageClientRPC(Fusion.PlayerRef,Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionMessenger/MessageEvent,Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionShareAndLocalizeParams)", num);
						return;
					}
					SimulationMessage* ptr = SimulationMessage.Allocate(base.Runner.Simulation, num);
					byte* ptr2 = (byte*)ptr + 28;
					*(RpcHeader*)ptr2 = RpcHeader.Create(base.Object.Id, base.ObjectIndex, 3);
					int num2 = 8;
					*(MessageEvent*)(ptr2 + num2) = eventCode;
					num2 += 4;
					*(FusionShareAndLocalizeParams*)(ptr2 + num2) = fusionData;
					num2 += 280;
					ptr->Offset = num2 * 8;
					NetworkRunner runner = base.Runner;
					ptr->SetTarget(playerRef);
					runner.SendRpc(ptr);
					return;
				}
				if ((localAuthorityMask & 7) == 0)
				{
					return;
				}
			}
			Logger.Log("HandleMessageClientRPC: " + eventCode, LogLevel.Verbose);
			switch (eventCode)
			{
			case MessageEvent.AnchorShareRequest:
				this.AnchorShareRequestReceived?.Invoke(fusionData.GetShareAndLocalizeParams());
				break;
			case MessageEvent.AnchorShareComplete:
				this.AnchorShareRequestCompleted?.Invoke(fusionData.GetShareAndLocalizeParams());
				break;
			default:
				throw new ArgumentOutOfRangeException("eventCode", eventCode, null);
			}
		}

		private void PrintIDDictionary()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < _playerIds.Count; i++)
			{
				stringBuilder.Append($"[{_playerIds[i]},{_networkIds[i]}]");
				if (i < _playerIds.Count - 1)
				{
					stringBuilder.Append(",");
				}
			}
			Logger.Log("FusionMessenger: ID dictionary is " + stringBuilder.ToString(), LogLevel.Verbose);
		}

		[WeaverGenerated]
		public override void CopyBackingFieldsToState(bool P_0)
		{
			NetworkBehaviourUtils.InitializeNetworkList(_networkIds, __networkIds, "_networkIds");
			NetworkBehaviourUtils.InitializeNetworkList(_playerIds, __playerIds, "_playerIds");
		}

		[WeaverGenerated]
		public override void CopyStateToBackingFields()
		{
			NetworkBehaviourUtils.CopyFromNetworkList(_networkIds, ref __networkIds);
			NetworkBehaviourUtils.CopyFromNetworkList(_playerIds, ref __playerIds);
		}

		[NetworkRpcWeavedInvoker(1, 7, 1)]
		[Preserve]
		[WeaverGenerated]
		protected unsafe static void AddPlayerIdHostRPC@Invoker(NetworkBehaviour behaviour, SimulationMessage* message)
		{
			byte* ptr = (byte*)message + 28;
			int num = 8;
			long num2 = *(long*)(ptr + num);
			num += 8;
			ulong localPlayerId = (ulong)num2;
			int num3 = *(int*)(ptr + num);
			num += 4;
			int localNetworkId = num3;
			behaviour.InvokeRpc = true;
			((FusionMessenger)behaviour).AddPlayerIdHostRPC(localPlayerId, localNetworkId);
		}

		[NetworkRpcWeavedInvoker(2, 7, 1)]
		[Preserve]
		[WeaverGenerated]
		protected unsafe static void FindRPCToCallServerRPC@Invoker(NetworkBehaviour behaviour, SimulationMessage* message)
		{
			byte* ptr = (byte*)message + 28;
			int num = 8;
			int num2 = *(int*)(ptr + num);
			num += 4;
			MessageEvent eventCode = (MessageEvent)num2;
			int num3 = *(int*)(ptr + num);
			num += 4;
			int fusionId = num3;
			FusionShareAndLocalizeParams fusionShareAndLocalizeParams = *(FusionShareAndLocalizeParams*)(ptr + num);
			num += 280;
			FusionShareAndLocalizeParams fusionData = fusionShareAndLocalizeParams;
			RpcInfo info = RpcInfo.FromMessage(behaviour.Runner, message, RpcHostMode.SourceIsServer);
			behaviour.InvokeRpc = true;
			((FusionMessenger)behaviour).FindRPCToCallServerRPC(eventCode, fusionId, fusionData, info);
		}

		[NetworkRpcWeavedInvoker(3, 7, 7)]
		[Preserve]
		[WeaverGenerated]
		protected unsafe static void HandleMessageClientRPC@Invoker(NetworkBehaviour behaviour, SimulationMessage* message)
		{
			byte* ptr = (byte*)message + 28;
			int num = 8;
			PlayerRef target = message->Target;
			int num2 = *(int*)(ptr + num);
			num += 4;
			MessageEvent eventCode = (MessageEvent)num2;
			FusionShareAndLocalizeParams fusionShareAndLocalizeParams = *(FusionShareAndLocalizeParams*)(ptr + num);
			num += 280;
			FusionShareAndLocalizeParams fusionData = fusionShareAndLocalizeParams;
			behaviour.InvokeRpc = true;
			((FusionMessenger)behaviour).HandleMessageClientRPC(target, eventCode, fusionData);
		}
	}
	[NetworkBehaviourWeaved(797)]
	internal class FusionNetworkData : NetworkBehaviour, INetworkData
	{
		[WeaverGenerated]
		[DefaultForProperty("ColocationGroupCount", 0, 1)]
		[DrawIf("IsEditorWritable", true, CompareOperator.Equal, DrawIfMode.ReadOnly)]
		private uint _ColocationGroupCount;

		[WeaverGenerated]
		[DefaultForProperty("AnchorList", 1, 723)]
		[DrawIf("IsEditorWritable", true, CompareOperator.Equal, DrawIfMode.ReadOnly)]
		private FusionAnchor[] _AnchorList;

		[WeaverGenerated]
		[DefaultForProperty("PlayerList", 724, 73)]
		[DrawIf("IsEditorWritable", true, CompareOperator.Equal, DrawIfMode.ReadOnly)]
		private FusionPlayer[] _PlayerList;

		[Networked]
		[NetworkedWeaved(0, 1)]
		private unsafe uint ColocationGroupCount
		{
			get
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing FusionNetworkData.ColocationGroupCount. Networked properties can only be accessed when Spawned() has been called.");
				}
				return *(uint*)((byte*)base.Ptr + 0);
			}
			set
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing FusionNetworkData.ColocationGroupCount. Networked properties can only be accessed when Spawned() has been called.");
				}
				*(uint*)((byte*)base.Ptr + 0) = value;
			}
		}

		[Networked]
		[Capacity(10)]
		[NetworkedWeaved(1, 723)]
		[NetworkedWeavedLinkedList(10, 70, typeof(ReaderWriter@Meta_XR_MultiplayerBlocks_Colocation_Fusion_FusionAnchor))]
		private unsafe NetworkLinkedList<FusionAnchor> AnchorList
		{
			get
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing FusionNetworkData.AnchorList. Networked properties can only be accessed when Spawned() has been called.");
				}
				return new NetworkLinkedList<FusionAnchor>((byte*)base.Ptr + 4, 10, ReaderWriter@Meta_XR_MultiplayerBlocks_Colocation_Fusion_FusionAnchor.GetInstance());
			}
		}

		[Networked]
		[Capacity(10)]
		[NetworkedWeaved(724, 73)]
		[NetworkedWeavedLinkedList(10, 5, typeof(ReaderWriter@Meta_XR_MultiplayerBlocks_Colocation_Fusion_FusionPlayer))]
		private unsafe NetworkLinkedList<FusionPlayer> PlayerList
		{
			get
			{
				if (base.Ptr == null)
				{
					throw new InvalidOperationException("Error when accessing FusionNetworkData.PlayerList. Networked properties can only be accessed when Spawned() has been called.");
				}
				return new NetworkLinkedList<FusionPlayer>((byte*)base.Ptr + 2896, 10, ReaderWriter@Meta_XR_MultiplayerBlocks_Colocation_Fusion_FusionPlayer.GetInstance());
			}
		}

		public void AddPlayer(Player player)
		{
			AddFusionPlayer(new FusionPlayer(player));
		}

		public void RemovePlayer(Player player)
		{
			RemoveFusionPlayer(new FusionPlayer(player));
		}

		public Player? GetPlayerWithPlayerId(ulong playerId)
		{
			foreach (FusionPlayer player in PlayerList)
			{
				if (player.GetPlayer().playerId == playerId)
				{
					return player.GetPlayer();
				}
			}
			return null;
		}

		public Player? GetPlayerWithOculusId(ulong oculusId)
		{
			foreach (FusionPlayer player in PlayerList)
			{
				if (player.GetPlayer().oculusId == oculusId)
				{
					return player.GetPlayer();
				}
			}
			return null;
		}

		public List<Player> GetAllPlayers()
		{
			List<Player> list = new List<Player>();
			foreach (FusionPlayer player in PlayerList)
			{
				list.Add(player.GetPlayer());
			}
			return list;
		}

		public void AddAnchor(Anchor anchor)
		{
			AnchorList.Add(new FusionAnchor(anchor));
		}

		public void RemoveAnchor(Anchor anchor)
		{
			AnchorList.Remove(new FusionAnchor(anchor));
		}

		public Anchor? GetAnchor(ulong ownerOculusId)
		{
			foreach (FusionAnchor anchor in AnchorList)
			{
				if (anchor.GetAnchor().ownerOculusId == ownerOculusId)
				{
					return anchor.GetAnchor();
				}
			}
			return null;
		}

		public List<Anchor> GetAllAnchors()
		{
			List<Anchor> list = new List<Anchor>();
			foreach (FusionAnchor anchor in AnchorList)
			{
				list.Add(anchor.GetAnchor());
			}
			return list;
		}

		public uint GetColocationGroupCount()
		{
			return ColocationGroupCount;
		}

		public void IncrementColocationGroupCount()
		{
			if (base.HasStateAuthority)
			{
				ColocationGroupCount++;
			}
			else
			{
				IncrementColocationGroupCountRpc();
			}
		}

		private void AddFusionPlayer(FusionPlayer player)
		{
			if (base.HasStateAuthority)
			{
				PlayerList.Add(player);
			}
			else
			{
				AddPlayerRpc(player);
			}
		}

		private void RemoveFusionPlayer(FusionPlayer player)
		{
			if (base.HasStateAuthority)
			{
				PlayerList.Remove(player);
			}
			else
			{
				RemovePlayerRpc(player);
			}
		}

		private void AddFusionAnchor(FusionAnchor anchor)
		{
			if (base.HasStateAuthority)
			{
				AnchorList.Add(anchor);
			}
			else
			{
				AddAnchorRpc(anchor);
			}
		}

		private void RemoveFusionAnchor(FusionAnchor anchor)
		{
			if (base.HasStateAuthority)
			{
				AnchorList.Remove(anchor);
			}
			else
			{
				RemoveAnchorRpc(anchor);
			}
		}

		[Rpc(RpcSources.All, RpcTargets.StateAuthority)]
		private unsafe void AddPlayerRpc(FusionPlayer player)
		{
			if (base.InvokeRpc)
			{
				base.InvokeRpc = false;
			}
			else
			{
				NetworkBehaviourUtils.ThrowIfBehaviourNotInitialized(this);
				if (base.Runner.Stage == SimulationStages.Resimulate)
				{
					return;
				}
				int localAuthorityMask = base.Object.GetLocalAuthorityMask();
				if ((localAuthorityMask & 7) == 0)
				{
					NetworkBehaviourUtils.NotifyLocalSimulationNotAllowedToSendRpc("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionNetworkData::AddPlayerRpc(Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionPlayer)", base.Object, 7);
					return;
				}
				if ((localAuthorityMask & 1) != 1)
				{
					int num = 8;
					num += 20;
					if (!SimulationMessage.CanAllocateUserPayload(num))
					{
						NetworkBehaviourUtils.NotifyRpcPayloadSizeExceeded("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionNetworkData::AddPlayerRpc(Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionPlayer)", num);
						return;
					}
					if (base.Runner.HasAnyActiveConnections())
					{
						SimulationMessage* ptr = SimulationMessage.Allocate(base.Runner.Simulation, num);
						byte* ptr2 = (byte*)ptr + 28;
						*(RpcHeader*)ptr2 = RpcHeader.Create(base.Object.Id, base.ObjectIndex, 1);
						int num2 = 8;
						*(FusionPlayer*)(ptr2 + num2) = player;
						num2 += 20;
						ptr->Offset = num2 * 8;
						base.Runner.SendRpc(ptr);
					}
					if ((localAuthorityMask & 1) == 0)
					{
						return;
					}
				}
			}
			AddFusionPlayer(player);
		}

		[Rpc(RpcSources.All, RpcTargets.StateAuthority)]
		private unsafe void RemovePlayerRpc(FusionPlayer player)
		{
			if (base.InvokeRpc)
			{
				base.InvokeRpc = false;
			}
			else
			{
				NetworkBehaviourUtils.ThrowIfBehaviourNotInitialized(this);
				if (base.Runner.Stage == SimulationStages.Resimulate)
				{
					return;
				}
				int localAuthorityMask = base.Object.GetLocalAuthorityMask();
				if ((localAuthorityMask & 7) == 0)
				{
					NetworkBehaviourUtils.NotifyLocalSimulationNotAllowedToSendRpc("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionNetworkData::RemovePlayerRpc(Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionPlayer)", base.Object, 7);
					return;
				}
				if ((localAuthorityMask & 1) != 1)
				{
					int num = 8;
					num += 20;
					if (!SimulationMessage.CanAllocateUserPayload(num))
					{
						NetworkBehaviourUtils.NotifyRpcPayloadSizeExceeded("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionNetworkData::RemovePlayerRpc(Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionPlayer)", num);
						return;
					}
					if (base.Runner.HasAnyActiveConnections())
					{
						SimulationMessage* ptr = SimulationMessage.Allocate(base.Runner.Simulation, num);
						byte* ptr2 = (byte*)ptr + 28;
						*(RpcHeader*)ptr2 = RpcHeader.Create(base.Object.Id, base.ObjectIndex, 2);
						int num2 = 8;
						*(FusionPlayer*)(ptr2 + num2) = player;
						num2 += 20;
						ptr->Offset = num2 * 8;
						base.Runner.SendRpc(ptr);
					}
					if ((localAuthorityMask & 1) == 0)
					{
						return;
					}
				}
			}
			RemoveFusionPlayer(player);
		}

		[Rpc(RpcSources.All, RpcTargets.StateAuthority)]
		private unsafe void AddAnchorRpc(FusionAnchor anchor)
		{
			if (base.InvokeRpc)
			{
				base.InvokeRpc = false;
			}
			else
			{
				NetworkBehaviourUtils.ThrowIfBehaviourNotInitialized(this);
				if (base.Runner.Stage == SimulationStages.Resimulate)
				{
					return;
				}
				int localAuthorityMask = base.Object.GetLocalAuthorityMask();
				if ((localAuthorityMask & 7) == 0)
				{
					NetworkBehaviourUtils.NotifyLocalSimulationNotAllowedToSendRpc("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionNetworkData::AddAnchorRpc(Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionAnchor)", base.Object, 7);
					return;
				}
				if ((localAuthorityMask & 1) != 1)
				{
					int num = 8;
					num += 280;
					if (!SimulationMessage.CanAllocateUserPayload(num))
					{
						NetworkBehaviourUtils.NotifyRpcPayloadSizeExceeded("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionNetworkData::AddAnchorRpc(Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionAnchor)", num);
						return;
					}
					if (base.Runner.HasAnyActiveConnections())
					{
						SimulationMessage* ptr = SimulationMessage.Allocate(base.Runner.Simulation, num);
						byte* ptr2 = (byte*)ptr + 28;
						*(RpcHeader*)ptr2 = RpcHeader.Create(base.Object.Id, base.ObjectIndex, 3);
						int num2 = 8;
						*(FusionAnchor*)(ptr2 + num2) = anchor;
						num2 += 280;
						ptr->Offset = num2 * 8;
						base.Runner.SendRpc(ptr);
					}
					if ((localAuthorityMask & 1) == 0)
					{
						return;
					}
				}
			}
			AddFusionAnchor(anchor);
		}

		[Rpc(RpcSources.All, RpcTargets.StateAuthority)]
		private unsafe void RemoveAnchorRpc(FusionAnchor anchor)
		{
			if (base.InvokeRpc)
			{
				base.InvokeRpc = false;
			}
			else
			{
				NetworkBehaviourUtils.ThrowIfBehaviourNotInitialized(this);
				if (base.Runner.Stage == SimulationStages.Resimulate)
				{
					return;
				}
				int localAuthorityMask = base.Object.GetLocalAuthorityMask();
				if ((localAuthorityMask & 7) == 0)
				{
					NetworkBehaviourUtils.NotifyLocalSimulationNotAllowedToSendRpc("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionNetworkData::RemoveAnchorRpc(Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionAnchor)", base.Object, 7);
					return;
				}
				if ((localAuthorityMask & 1) != 1)
				{
					int num = 8;
					num += 280;
					if (!SimulationMessage.CanAllocateUserPayload(num))
					{
						NetworkBehaviourUtils.NotifyRpcPayloadSizeExceeded("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionNetworkData::RemoveAnchorRpc(Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionAnchor)", num);
						return;
					}
					if (base.Runner.HasAnyActiveConnections())
					{
						SimulationMessage* ptr = SimulationMessage.Allocate(base.Runner.Simulation, num);
						byte* ptr2 = (byte*)ptr + 28;
						*(RpcHeader*)ptr2 = RpcHeader.Create(base.Object.Id, base.ObjectIndex, 4);
						int num2 = 8;
						*(FusionAnchor*)(ptr2 + num2) = anchor;
						num2 += 280;
						ptr->Offset = num2 * 8;
						base.Runner.SendRpc(ptr);
					}
					if ((localAuthorityMask & 1) == 0)
					{
						return;
					}
				}
			}
			RemoveFusionAnchor(anchor);
		}

		[Rpc(RpcSources.All, RpcTargets.StateAuthority)]
		private unsafe void IncrementColocationGroupCountRpc()
		{
			if (base.InvokeRpc)
			{
				base.InvokeRpc = false;
			}
			else
			{
				NetworkBehaviourUtils.ThrowIfBehaviourNotInitialized(this);
				if (base.Runner.Stage == SimulationStages.Resimulate)
				{
					return;
				}
				int localAuthorityMask = base.Object.GetLocalAuthorityMask();
				if ((localAuthorityMask & 7) == 0)
				{
					NetworkBehaviourUtils.NotifyLocalSimulationNotAllowedToSendRpc("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionNetworkData::IncrementColocationGroupCountRpc()", base.Object, 7);
					return;
				}
				if ((localAuthorityMask & 1) != 1)
				{
					int num = 8;
					if (!SimulationMessage.CanAllocateUserPayload(num))
					{
						NetworkBehaviourUtils.NotifyRpcPayloadSizeExceeded("System.Void Meta.XR.MultiplayerBlocks.Colocation.Fusion.FusionNetworkData::IncrementColocationGroupCountRpc()", num);
						return;
					}
					if (base.Runner.HasAnyActiveConnections())
					{
						SimulationMessage* ptr = SimulationMessage.Allocate(base.Runner.Simulation, num);
						byte* ptr2 = (byte*)ptr + 28;
						*(RpcHeader*)ptr2 = RpcHeader.Create(base.Object.Id, base.ObjectIndex, 5);
						int num2 = 8;
						ptr->Offset = num2 * 8;
						base.Runner.SendRpc(ptr);
					}
					if ((localAuthorityMask & 1) == 0)
					{
						return;
					}
				}
			}
			IncrementColocationGroupCount();
		}

		[WeaverGenerated]
		public override void CopyBackingFieldsToState(bool P_0)
		{
			ColocationGroupCount = _ColocationGroupCount;
			NetworkBehaviourUtils.InitializeNetworkList(AnchorList, _AnchorList, "AnchorList");
			NetworkBehaviourUtils.InitializeNetworkList(PlayerList, _PlayerList, "PlayerList");
		}

		[WeaverGenerated]
		public override void CopyStateToBackingFields()
		{
			_ColocationGroupCount = ColocationGroupCount;
			NetworkBehaviourUtils.CopyFromNetworkList(AnchorList, ref _AnchorList);
			NetworkBehaviourUtils.CopyFromNetworkList(PlayerList, ref _PlayerList);
		}

		[NetworkRpcWeavedInvoker(1, 7, 1)]
		[Preserve]
		[WeaverGenerated]
		protected unsafe static void AddPlayerRpc@Invoker(NetworkBehaviour behaviour, SimulationMessage* message)
		{
			byte* ptr = (byte*)message + 28;
			int num = 8;
			FusionPlayer fusionPlayer = *(FusionPlayer*)(ptr + num);
			num += 20;
			FusionPlayer player = fusionPlayer;
			behaviour.InvokeRpc = true;
			((FusionNetworkData)behaviour).AddPlayerRpc(player);
		}

		[NetworkRpcWeavedInvoker(2, 7, 1)]
		[Preserve]
		[WeaverGenerated]
		protected unsafe static void RemovePlayerRpc@Invoker(NetworkBehaviour behaviour, SimulationMessage* message)
		{
			byte* ptr = (byte*)message + 28;
			int num = 8;
			FusionPlayer fusionPlayer = *(FusionPlayer*)(ptr + num);
			num += 20;
			FusionPlayer player = fusionPlayer;
			behaviour.InvokeRpc = true;
			((FusionNetworkData)behaviour).RemovePlayerRpc(player);
		}

		[NetworkRpcWeavedInvoker(3, 7, 1)]
		[Preserve]
		[WeaverGenerated]
		protected unsafe static void AddAnchorRpc@Invoker(NetworkBehaviour behaviour, SimulationMessage* message)
		{
			byte* ptr = (byte*)message + 28;
			int num = 8;
			FusionAnchor fusionAnchor = *(FusionAnchor*)(ptr + num);
			num += 280;
			FusionAnchor anchor = fusionAnchor;
			behaviour.InvokeRpc = true;
			((FusionNetworkData)behaviour).AddAnchorRpc(anchor);
		}

		[NetworkRpcWeavedInvoker(4, 7, 1)]
		[Preserve]
		[WeaverGenerated]
		protected unsafe static void RemoveAnchorRpc@Invoker(NetworkBehaviour behaviour, SimulationMessage* message)
		{
			byte* ptr = (byte*)message + 28;
			int num = 8;
			FusionAnchor fusionAnchor = *(FusionAnchor*)(ptr + num);
			num += 280;
			FusionAnchor anchor = fusionAnchor;
			behaviour.InvokeRpc = true;
			((FusionNetworkData)behaviour).RemoveAnchorRpc(anchor);
		}

		[NetworkRpcWeavedInvoker(5, 7, 1)]
		[Preserve]
		[WeaverGenerated]
		protected unsafe static void IncrementColocationGroupCountRpc@Invoker(NetworkBehaviour behaviour, SimulationMessage* message)
		{
			byte* ptr = (byte*)message + 28;
			int num = 8;
			behaviour.InvokeRpc = true;
			((FusionNetworkData)behaviour).IncrementColocationGroupCountRpc();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Explicit, Size = 20)]
	[NetworkStructWeaved(5)]
	internal struct FusionPlayer(Player player) : INetworkStruct, IEquatable<FusionPlayer>
	{
		[FieldOffset(0)]
		public ulong playerId = player.playerId;

		[FieldOffset(8)]
		public ulong oculusId = player.oculusId;

		[FieldOffset(16)]
		public uint colocationGroupId = player.colocationGroupId;

		public Player GetPlayer()
		{
			return new Player(playerId, oculusId, colocationGroupId);
		}

		public bool Equals(FusionPlayer other)
		{
			return GetPlayer().Equals(other.GetPlayer());
		}
	}
	[StructLayout(LayoutKind.Explicit, Size = 280)]
	[NetworkStructWeaved(70)]
	internal struct FusionShareAndLocalizeParams(ShareAndLocalizeParams data) : INetworkStruct
	{
		[FieldOffset(0)]
		public ulong requestingPlayerId = data.requestingPlayerId;

		[FieldOffset(8)]
		public ulong requestingPlayerOculusId = data.requestingPlayerOculusId;

		[FieldOffset(16)]
		public NetworkString<_64> anchorUUID = data.anchorUUID.ToString();

		[FieldOffset(276)]
		public NetworkBool anchorFlowSucceeded = data.anchorFlowSucceeded;

		public ShareAndLocalizeParams GetShareAndLocalizeParams()
		{
			if (!Guid.TryParse(anchorUUID.ToString(), out var result))
			{
				Logger.Log("Failed to parse shared Anchor UUID string from network", LogLevel.Error);
			}
			return new ShareAndLocalizeParams(requestingPlayerId, requestingPlayerOculusId, result, anchorFlowSucceeded);
		}
	}
}
namespace Fusion.CodeGen
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[WeaverGenerated]
	internal struct ReaderWriter@Meta_XR_MultiplayerBlocks_Colocation_Fusion_FusionAnchor : IElementReaderWriter<FusionAnchor>
	{
		[WeaverGenerated]
		public static IElementReaderWriter<FusionAnchor> Instance;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[WeaverGenerated]
		public unsafe FusionAnchor Read(byte* data, int index)
		{
			return *(FusionAnchor*)(data + index * 280);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[WeaverGenerated]
		public unsafe ref FusionAnchor ReadRef(byte* data, int index)
		{
			return ref *(FusionAnchor*)(data + index * 280);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[WeaverGenerated]
		public unsafe void Write(byte* data, int index, FusionAnchor val)
		{
			*(FusionAnchor*)(data + index * 280) = val;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[WeaverGenerated]
		public int GetElementWordCount()
		{
			return 70;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[WeaverGenerated]
		public int GetElementHashCode(FusionAnchor val)
		{
			return val.GetHashCode();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[WeaverGenerated]
		public static IElementReaderWriter<FusionAnchor> GetInstance()
		{
			if (Instance == null)
			{
				Instance = default(ReaderWriter@Meta_XR_MultiplayerBlocks_Colocation_Fusion_FusionAnchor);
			}
			return Instance;
		}
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[WeaverGenerated]
	internal struct ReaderWriter@Meta_XR_MultiplayerBlocks_Colocation_Fusion_FusionPlayer : IElementReaderWriter<FusionPlayer>
	{
		[WeaverGenerated]
		public static IElementReaderWriter<FusionPlayer> Instance;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[WeaverGenerated]
		public unsafe FusionPlayer Read(byte* data, int index)
		{
			return *(FusionPlayer*)(data + index * 20);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[WeaverGenerated]
		public unsafe ref FusionPlayer ReadRef(byte* data, int index)
		{
			return ref *(FusionPlayer*)(data + index * 20);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[WeaverGenerated]
		public unsafe void Write(byte* data, int index, FusionPlayer val)
		{
			*(FusionPlayer*)(data + index * 20) = val;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[WeaverGenerated]
		public int GetElementWordCount()
		{
			return 5;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[WeaverGenerated]
		public int GetElementHashCode(FusionPlayer val)
		{
			return val.GetHashCode();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[WeaverGenerated]
		public static IElementReaderWriter<FusionPlayer> GetInstance()
		{
			if (Instance == null)
			{
				Instance = default(ReaderWriter@Meta_XR_MultiplayerBlocks_Colocation_Fusion_FusionPlayer);
			}
			return Instance;
		}
	}
}
