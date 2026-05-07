using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.CodeAnalysis;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Profiling.LowLevel.Unsafe;

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
			FilePathsData = new byte[689]
			{
				0, 0, 0, 1, 0, 0, 0, 86, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				112, 114, 111, 102, 105, 108, 105, 110, 103, 46,
				99, 111, 114, 101, 64, 56, 97, 52, 57, 102,
				55, 48, 50, 55, 100, 48, 54, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 80, 114, 111, 102,
				105, 108, 101, 114, 67, 111, 117, 110, 116, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 91, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 117, 110,
				105, 116, 121, 46, 112, 114, 111, 102, 105, 108,
				105, 110, 103, 46, 99, 111, 114, 101, 64, 56,
				97, 52, 57, 102, 55, 48, 50, 55, 100, 48,
				54, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				80, 114, 111, 102, 105, 108, 101, 114, 67, 111,
				117, 110, 116, 101, 114, 86, 97, 108, 117, 101,
				46, 99, 115, 0, 0, 0, 2, 0, 0, 0,
				91, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 117, 110, 105,
				116, 121, 46, 112, 114, 111, 102, 105, 108, 105,
				110, 103, 46, 99, 111, 114, 101, 64, 56, 97,
				52, 57, 102, 55, 48, 50, 55, 100, 48, 54,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 80,
				114, 111, 102, 105, 108, 101, 114, 77, 97, 114,
				107, 101, 114, 49, 80, 97, 114, 97, 109, 46,
				99, 115, 0, 0, 0, 2, 0, 0, 0, 92,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 117, 110, 105, 116,
				121, 46, 112, 114, 111, 102, 105, 108, 105, 110,
				103, 46, 99, 111, 114, 101, 64, 56, 97, 52,
				57, 102, 55, 48, 50, 55, 100, 48, 54, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 80, 114,
				111, 102, 105, 108, 101, 114, 77, 97, 114, 107,
				101, 114, 50, 80, 97, 114, 97, 109, 115, 46,
				99, 115, 0, 0, 0, 2, 0, 0, 0, 92,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 117, 110, 105, 116,
				121, 46, 112, 114, 111, 102, 105, 108, 105, 110,
				103, 46, 99, 111, 114, 101, 64, 56, 97, 52,
				57, 102, 55, 48, 50, 55, 100, 48, 54, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 80, 114,
				111, 102, 105, 108, 101, 114, 77, 97, 114, 107,
				101, 114, 51, 80, 97, 114, 97, 109, 115, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 95,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 117, 110, 105, 116,
				121, 46, 112, 114, 111, 102, 105, 108, 105, 110,
				103, 46, 99, 111, 114, 101, 64, 56, 97, 52,
				57, 102, 55, 48, 50, 55, 100, 48, 54, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 80, 114,
				111, 102, 105, 108, 101, 114, 77, 97, 114, 107,
				101, 114, 69, 120, 116, 101, 110, 115, 105, 111,
				110, 115, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 86, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 117,
				110, 105, 116, 121, 46, 112, 114, 111, 102, 105,
				108, 105, 110, 103, 46, 99, 111, 114, 101, 64,
				56, 97, 52, 57, 102, 55, 48, 50, 55, 100,
				48, 54, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 80, 114, 111, 102, 105, 108, 101, 114, 85,
				116, 105, 108, 105, 116, 121, 46, 99, 115
			},
			TypesData = new byte[355]
			{
				0, 0, 0, 0, 31, 85, 110, 105, 116, 121,
				46, 80, 114, 111, 102, 105, 108, 105, 110, 103,
				124, 80, 114, 111, 102, 105, 108, 101, 114, 67,
				111, 117, 110, 116, 101, 114, 0, 0, 0, 0,
				36, 85, 110, 105, 116, 121, 46, 80, 114, 111,
				102, 105, 108, 105, 110, 103, 124, 80, 114, 111,
				102, 105, 108, 101, 114, 67, 111, 117, 110, 116,
				101, 114, 86, 97, 108, 117, 101, 1, 0, 0,
				0, 30, 85, 110, 105, 116, 121, 46, 80, 114,
				111, 102, 105, 108, 105, 110, 103, 124, 80, 114,
				111, 102, 105, 108, 101, 114, 77, 97, 114, 107,
				101, 114, 1, 0, 0, 0, 26, 85, 110, 105,
				116, 121, 46, 80, 114, 111, 102, 105, 108, 105,
				110, 103, 46, 124, 65, 117, 116, 111, 83, 99,
				111, 112, 101, 1, 0, 0, 0, 30, 85, 110,
				105, 116, 121, 46, 80, 114, 111, 102, 105, 108,
				105, 110, 103, 124, 80, 114, 111, 102, 105, 108,
				101, 114, 77, 97, 114, 107, 101, 114, 1, 0,
				0, 0, 26, 85, 110, 105, 116, 121, 46, 80,
				114, 111, 102, 105, 108, 105, 110, 103, 46, 124,
				65, 117, 116, 111, 83, 99, 111, 112, 101, 1,
				0, 0, 0, 30, 85, 110, 105, 116, 121, 46,
				80, 114, 111, 102, 105, 108, 105, 110, 103, 124,
				80, 114, 111, 102, 105, 108, 101, 114, 77, 97,
				114, 107, 101, 114, 1, 0, 0, 0, 26, 85,
				110, 105, 116, 121, 46, 80, 114, 111, 102, 105,
				108, 105, 110, 103, 46, 124, 65, 117, 116, 111,
				83, 99, 111, 112, 101, 0, 0, 0, 0, 39,
				85, 110, 105, 116, 121, 46, 80, 114, 111, 102,
				105, 108, 105, 110, 103, 124, 80, 114, 111, 102,
				105, 108, 101, 114, 77, 97, 114, 107, 101, 114,
				69, 120, 116, 101, 110, 115, 105, 111, 110, 0,
				0, 0, 0, 31, 85, 110, 105, 116, 121, 46,
				80, 114, 111, 102, 105, 108, 105, 110, 103, 124,
				80, 114, 111, 102, 105, 108, 101, 114, 85, 116,
				105, 108, 105, 116, 121
			},
			TotalFiles = 7,
			TotalTypes = 10,
			IsEditorOnly = false
		};
	}
}
namespace Unity.Profiling
{
	public readonly struct ProfilerCounter<T> where T : unmanaged
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ProfilerCounter(ProfilerCategory category, string name, ProfilerMarkerDataUnit dataUnit)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_PROFILER")]
		public void Sample(T value)
		{
		}
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct ProfilerCounterValue<T> where T : unmanaged
	{
		public T Value
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(T);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ProfilerCounterValue(string name)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ProfilerCounterValue(string name, ProfilerMarkerDataUnit dataUnit)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ProfilerCounterValue(string name, ProfilerMarkerDataUnit dataUnit, ProfilerCounterOptions counterOptions)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ProfilerCounterValue(ProfilerCategory category, string name, ProfilerMarkerDataUnit dataUnit)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ProfilerCounterValue(ProfilerCategory category, string name, ProfilerMarkerDataUnit dataUnit, ProfilerCounterOptions counterOptions)
		{
		}

		[Conditional("ENABLE_PROFILER")]
		public void Sample()
		{
		}
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct ProfilerMarker<TP1> where TP1 : unmanaged
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public readonly struct AutoScope : IDisposable
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal AutoScope(ProfilerMarker<TP1> marker, TP1 p1)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Dispose()
			{
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ProfilerMarker(string name, string param1Name)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ProfilerMarker(ProfilerCategory category, string name, string param1Name)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_PROFILER")]
		public void Begin(TP1 p1)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_PROFILER")]
		public void End()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public AutoScope Auto(TP1 p1)
		{
			return default(AutoScope);
		}
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct ProfilerMarker<TP1, TP2> where TP1 : unmanaged where TP2 : unmanaged
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public readonly struct AutoScope : IDisposable
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal AutoScope(ProfilerMarker<TP1, TP2> marker, TP1 p1, TP2 p2)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Dispose()
			{
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ProfilerMarker(string name, string param1Name, string param2Name)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ProfilerMarker(ProfilerCategory category, string name, string param1Name, string param2Name)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_PROFILER")]
		public void Begin(TP1 p1, TP2 p2)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_PROFILER")]
		public void End()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public AutoScope Auto(TP1 p1, TP2 p2)
		{
			return default(AutoScope);
		}
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct ProfilerMarker<TP1, TP2, TP3> where TP1 : unmanaged where TP2 : unmanaged where TP3 : unmanaged
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public readonly struct AutoScope : IDisposable
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal AutoScope(ProfilerMarker<TP1, TP2, TP3> marker, TP1 p1, TP2 p2, TP3 p3)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Dispose()
			{
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ProfilerMarker(string name, string param1Name, string param2Name, string param3Name)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ProfilerMarker(ProfilerCategory category, string name, string param1Name, string param2Name, string param3Name)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_PROFILER")]
		public void Begin(TP1 p1, TP2 p2, TP3 p3)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_PROFILER")]
		public void End()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public AutoScope Auto(TP1 p1, TP2 p2, TP3 p3)
		{
			return default(AutoScope);
		}
	}
	public static class ProfilerMarkerExtension
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_PROFILER")]
		public unsafe static void Begin(this ProfilerMarker marker, int metadata)
		{
			ProfilerMarkerData profilerMarkerData = new ProfilerMarkerData
			{
				Type = 2,
				Size = (uint)UnsafeUtility.SizeOf<int>(),
				Ptr = &metadata
			};
			ProfilerUnsafeUtility.BeginSampleWithMetadata(marker.Handle, 1, &profilerMarkerData);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_PROFILER")]
		public unsafe static void Begin(this ProfilerMarker marker, uint metadata)
		{
			ProfilerMarkerData profilerMarkerData = new ProfilerMarkerData
			{
				Type = 3,
				Size = (uint)UnsafeUtility.SizeOf<uint>(),
				Ptr = &metadata
			};
			ProfilerUnsafeUtility.BeginSampleWithMetadata(marker.Handle, 1, &profilerMarkerData);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_PROFILER")]
		public unsafe static void Begin(this ProfilerMarker marker, long metadata)
		{
			ProfilerMarkerData profilerMarkerData = new ProfilerMarkerData
			{
				Type = 4,
				Size = (uint)UnsafeUtility.SizeOf<long>(),
				Ptr = &metadata
			};
			ProfilerUnsafeUtility.BeginSampleWithMetadata(marker.Handle, 1, &profilerMarkerData);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_PROFILER")]
		public unsafe static void Begin(this ProfilerMarker marker, ulong metadata)
		{
			ProfilerMarkerData profilerMarkerData = new ProfilerMarkerData
			{
				Type = 5,
				Size = (uint)UnsafeUtility.SizeOf<ulong>(),
				Ptr = &metadata
			};
			ProfilerUnsafeUtility.BeginSampleWithMetadata(marker.Handle, 1, &profilerMarkerData);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_PROFILER")]
		public unsafe static void Begin(this ProfilerMarker marker, float metadata)
		{
			ProfilerMarkerData profilerMarkerData = new ProfilerMarkerData
			{
				Type = 6,
				Size = (uint)UnsafeUtility.SizeOf<float>(),
				Ptr = &metadata
			};
			ProfilerUnsafeUtility.BeginSampleWithMetadata(marker.Handle, 1, &profilerMarkerData);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_PROFILER")]
		public unsafe static void Begin(this ProfilerMarker marker, double metadata)
		{
			ProfilerMarkerData profilerMarkerData = new ProfilerMarkerData
			{
				Type = 7,
				Size = (uint)UnsafeUtility.SizeOf<double>(),
				Ptr = &metadata
			};
			ProfilerUnsafeUtility.BeginSampleWithMetadata(marker.Handle, 1, &profilerMarkerData);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("ENABLE_PROFILER")]
		public unsafe static void Begin(this ProfilerMarker marker, string metadata)
		{
			ProfilerMarkerData profilerMarkerData = new ProfilerMarkerData
			{
				Type = 9
			};
			fixed (char* ptr = metadata)
			{
				profilerMarkerData.Size = (uint)((metadata.Length + 1) * 2);
				profilerMarkerData.Ptr = ptr;
				ProfilerUnsafeUtility.BeginSampleWithMetadata(marker.Handle, 1, &profilerMarkerData);
			}
		}
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal struct ProfilerUtility
	{
		public static byte GetProfilerMarkerDataType<T>()
		{
			return Type.GetTypeCode(typeof(T)) switch
			{
				TypeCode.Int32 => 2, 
				TypeCode.UInt32 => 3, 
				TypeCode.Int64 => 4, 
				TypeCode.UInt64 => 5, 
				TypeCode.Single => 6, 
				TypeCode.Double => 7, 
				TypeCode.String => 9, 
				_ => throw new ArgumentException($"Type {typeof(T)} is unsupported by ProfilerCounter."), 
			};
		}
	}
}
