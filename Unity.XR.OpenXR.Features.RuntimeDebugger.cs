using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Networking.PlayerConnection;

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
			FilePathsData = new byte[118]
			{
				0, 0, 0, 1, 0, 0, 0, 110, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				120, 114, 46, 111, 112, 101, 110, 120, 114, 64,
				48, 53, 102, 98, 49, 97, 55, 100, 55, 53,
				100, 49, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 82, 117, 110, 116, 105, 109, 101, 68, 101,
				98, 117, 103, 103, 101, 114, 92, 82, 117, 110,
				116, 105, 109, 101, 68, 101, 98, 117, 103, 103,
				101, 114, 79, 112, 101, 110, 88, 82, 70, 101,
				97, 116, 117, 114, 101, 46, 99, 115
			},
			TypesData = new byte[80]
			{
				0, 0, 0, 0, 75, 85, 110, 105, 116, 121,
				69, 110, 103, 105, 110, 101, 46, 88, 82, 46,
				79, 112, 101, 110, 88, 82, 46, 70, 101, 97,
				116, 117, 114, 101, 115, 46, 82, 117, 110, 116,
				105, 109, 101, 68, 101, 98, 117, 103, 103, 101,
				114, 124, 82, 117, 110, 116, 105, 109, 101, 68,
				101, 98, 117, 103, 103, 101, 114, 79, 112, 101,
				110, 88, 82, 70, 101, 97, 116, 117, 114, 101
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
namespace UnityEngine.XR.OpenXR.Features.RuntimeDebugger;

public class RuntimeDebuggerOpenXRFeature : OpenXRFeature
{
	internal static readonly Guid kEditorToPlayerRequestDebuggerOutput = new Guid("B3E6DED1-C6C7-411C-BE58-86031A0877E7");

	internal static readonly Guid kPlayerToEditorSendDebuggerOutput = new Guid("B3E6DED1-C6C7-411C-BE58-86031A0877E8");

	public uint cacheSize = 1048576u;

	public uint perThreadCacheSize = 51200u;

	private uint lutOffset;

	private const string Library = "openxr_runtime_debugger";

	protected override IntPtr HookGetInstanceProcAddr(IntPtr func)
	{
		PlayerConnection.instance.Register(kEditorToPlayerRequestDebuggerOutput, RecvMsg);
		Native_StartDataAccess();
		Native_EndDataAccess();
		lutOffset = 0u;
		return Native_HookGetInstanceProcAddr(func, cacheSize, perThreadCacheSize);
	}

	internal void RecvMsg(MessageEventArgs args)
	{
		Native_StartDataAccess();
		Native_GetLUTData(out var ptr, out var size, lutOffset);
		byte[] array = new byte[size];
		if (size != 0)
		{
			lutOffset = size;
			Marshal.Copy(ptr, array, 0, (int)size);
		}
		Native_GetDataForRead(out var ptr2, out var size2);
		Native_GetDataForRead(out var ptr3, out var size3);
		byte[] array2 = new byte[size2 + size3];
		if (size2 != 0)
		{
			Marshal.Copy(ptr2, array2, 0, (int)size2);
		}
		if (size3 != 0)
		{
			Marshal.Copy(ptr3, array2, (int)size2, (int)size3);
		}
		Native_EndDataAccess();
		PlayerConnection.instance.Send(kPlayerToEditorSendDebuggerOutput, array);
		PlayerConnection.instance.Send(kPlayerToEditorSendDebuggerOutput, array2);
	}

	[DllImport("openxr_runtime_debugger", EntryPoint = "HookXrInstanceProcAddr")]
	private static extern IntPtr Native_HookGetInstanceProcAddr(IntPtr func, uint cacheSize, uint perThreadCacheSize);

	[DllImport("openxr_runtime_debugger", EntryPoint = "GetDataForRead")]
	[return: MarshalAs(UnmanagedType.U1)]
	private static extern bool Native_GetDataForRead(out IntPtr ptr, out uint size);

	[DllImport("openxr_runtime_debugger", EntryPoint = "GetLUTData")]
	private static extern void Native_GetLUTData(out IntPtr ptr, out uint size, uint offset);

	[DllImport("openxr_runtime_debugger", EntryPoint = "StartDataAccess")]
	private static extern void Native_StartDataAccess();

	[DllImport("openxr_runtime_debugger", EntryPoint = "EndDataAccess")]
	private static extern void Native_EndDataAccess();
}
