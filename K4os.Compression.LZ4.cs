using System;
using System.Buffers;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using K4os.Compression.LZ4.Engine;
using K4os.Compression.LZ4.Internal;
using Microsoft.CodeAnalysis;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Milosz Krajewski")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Milosz Krajewski")]
[assembly: AssemblyDescription("Port of LZ4 compression algorithm for .NET")]
[assembly: AssemblyFileVersion("1.3.8.0")]
[assembly: AssemblyInformationalVersion("1.3.8")]
[assembly: AssemblyProduct("K4os.Compression.LZ4")]
[assembly: AssemblyTitle("K4os.Compression.LZ4")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/MiloszKrajewski/K4os.Compression.LZ4")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.3.8.0")]
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
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute(byte P_0)
		{
			NullableFlags = new byte[1] { P_0 };
		}

		public NullableAttribute(byte[] P_0)
		{
			NullableFlags = P_0;
		}
	}
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableContextAttribute : Attribute
	{
		public readonly byte Flag;

		public NullableContextAttribute(byte P_0)
		{
			Flag = P_0;
		}
	}
}
namespace System
{
	internal static class Extensions
	{
		internal static T Required<T>([NotNull] this T? value, [CallerArgumentExpression("value")] string name = null)
		{
			if (value == null)
			{
				return ThrowArgumentNullException<T>(name);
			}
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		public static void AssertTrue(this bool value, [CallerArgumentExpression("value")] string? name = null)
		{
			if (!value)
			{
				ThrowAssertionFailed(name);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DoesNotReturn]
		private static void ThrowAssertionFailed(string? name)
		{
			throw new ArgumentException((name ?? "<unknown>") + " assertion failed");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DoesNotReturn]
		private static T ThrowArgumentNullException<T>(string name)
		{
			throw new ArgumentNullException(name);
		}

		internal static void Validate<T>(this T[]? buffer, int offset, int length, bool allowNullIfEmpty = false)
		{
			if (!allowNullIfEmpty || buffer != null || offset != 0 || length != 0)
			{
				if (buffer == null)
				{
					throw new ArgumentNullException("buffer", "cannot be null");
				}
				if (offset < 0 || length < 0 || offset + length > buffer.Length)
				{
					throw new ArgumentException($"invalid offset/length combination: {offset}/{length}");
				}
			}
		}
	}
}
namespace System.Runtime.Versioning
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
	[ExcludeFromCodeCoverage]
	internal sealed class RequiresPreviewFeaturesAttribute : Attribute
	{
		public string? Message { get; }

		public string? Url { get; set; }

		public RequiresPreviewFeaturesAttribute()
		{
		}

		public RequiresPreviewFeaturesAttribute(string? message)
		{
			Message = message;
		}
	}
}
namespace System.Runtime.CompilerServices
{
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
	[ExcludeFromCodeCoverage]
	internal sealed class CallerArgumentExpressionAttribute : Attribute
	{
		public string ParameterName { get; }

		public CallerArgumentExpressionAttribute(string parameterName)
		{
			ParameterName = parameterName;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	[ExcludeFromCodeCoverage]
	internal sealed class CompilerFeatureRequiredAttribute : Attribute
	{
		public const string RefStructs = "RefStructs";

		public const string RequiredMembers = "RequiredMembers";

		public string FeatureName { get; }

		public bool IsOptional { get; set; }

		public CompilerFeatureRequiredAttribute(string featureName)
		{
			FeatureName = featureName;
		}
	}
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
	[ExcludeFromCodeCoverage]
	internal sealed class InterpolatedStringHandlerArgumentAttribute : Attribute
	{
		public string[] Arguments { get; }

		public InterpolatedStringHandlerArgumentAttribute(string argument)
		{
			Arguments = new string[1] { argument };
		}

		public InterpolatedStringHandlerArgumentAttribute(params string[] arguments)
		{
			Arguments = arguments;
		}
	}
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
	[ExcludeFromCodeCoverage]
	internal sealed class InterpolatedStringHandlerAttribute : Attribute
	{
	}
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExcludeFromCodeCoverage]
	internal static class IsExternalInit
	{
	}
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	[ExcludeFromCodeCoverage]
	internal sealed class ModuleInitializerAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
	[ExcludeFromCodeCoverage]
	internal sealed class RequiredMemberAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event | AttributeTargets.Interface, Inherited = false)]
	[ExcludeFromCodeCoverage]
	internal sealed class SkipLocalsInitAttribute : Attribute
	{
	}
}
namespace System.Diagnostics.CodeAnalysis
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
	[ExcludeFromCodeCoverage]
	internal sealed class MemberNotNullAttribute : Attribute
	{
		public string[] Members { get; }

		public MemberNotNullAttribute(string member)
		{
			Members = new string[1] { member };
		}

		public MemberNotNullAttribute(params string[] members)
		{
			Members = members;
		}
	}
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
	[ExcludeFromCodeCoverage]
	internal sealed class MemberNotNullWhenAttribute : Attribute
	{
		public bool ReturnValue { get; }

		public string[] Members { get; }

		public MemberNotNullWhenAttribute(bool returnValue, string member)
		{
			ReturnValue = returnValue;
			Members = new string[1] { member };
		}

		public MemberNotNullWhenAttribute(bool returnValue, params string[] members)
		{
			ReturnValue = returnValue;
			Members = members;
		}
	}
	[AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
	[ExcludeFromCodeCoverage]
	internal sealed class SetsRequiredMembersAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
	[ExcludeFromCodeCoverage]
	internal sealed class StringSyntaxAttribute : Attribute
	{
		public const string CompositeFormat = "CompositeFormat";

		public const string DateOnlyFormat = "DateOnlyFormat";

		public const string DateTimeFormat = "DateTimeFormat";

		public const string EnumFormat = "EnumFormat";

		public const string GuidFormat = "GuidFormat";

		public const string Json = "Json";

		public const string NumericFormat = "NumericFormat";

		public const string Regex = "Regex";

		public const string TimeOnlyFormat = "TimeOnlyFormat";

		public const string TimeSpanFormat = "TimeSpanFormat";

		public const string Uri = "Uri";

		public const string Xml = "Xml";

		public string Syntax { get; }

		public object?[] Arguments { get; }

		public StringSyntaxAttribute(string syntax)
		{
			Syntax = syntax;
			Arguments = new object[0];
		}

		public StringSyntaxAttribute(string syntax, params object?[] arguments)
		{
			Syntax = syntax;
			Arguments = arguments;
		}
	}
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
	[ExcludeFromCodeCoverage]
	internal sealed class UnscopedRefAttribute : Attribute
	{
	}
}
namespace K4os.Compression.LZ4
{
	internal class AssemblyHook
	{
		private AssemblyHook()
		{
		}
	}
	public static class LZ4Codec
	{
		public const int Version = 192;

		public static bool Enforce32
		{
			get
			{
				return LL.Enforce32;
			}
			set
			{
				LL.Enforce32 = value;
			}
		}

		public static int MaximumOutputSize(int length)
		{
			return LL.LZ4_compressBound(length);
		}

		public unsafe static int Encode(byte* source, int sourceLength, byte* target, int targetLength, LZ4Level level = LZ4Level.L00_FAST)
		{
			if (sourceLength <= 0)
			{
				return 0;
			}
			int num = ((level < LZ4Level.L03_HC) ? LLxx.LZ4_compress_fast(source, target, sourceLength, targetLength, 1) : LLxx.LZ4_compress_HC(source, target, sourceLength, targetLength, (int)level));
			if (num > 0)
			{
				return num;
			}
			return -1;
		}

		public unsafe static int Encode(ReadOnlySpan<byte> source, Span<byte> target, LZ4Level level = LZ4Level.L00_FAST)
		{
			int length = source.Length;
			if (length <= 0)
			{
				return 0;
			}
			int length2 = target.Length;
			fixed (byte* source2 = source)
			{
				fixed (byte* target2 = target)
				{
					return Encode(source2, length, target2, length2, level);
				}
			}
		}

		public unsafe static int Encode(byte[] source, int sourceOffset, int sourceLength, byte[] target, int targetOffset, int targetLength, LZ4Level level = LZ4Level.L00_FAST)
		{
			source.Validate(sourceOffset, sourceLength);
			target.Validate(targetOffset, targetLength);
			fixed (byte* ptr = source)
			{
				fixed (byte* ptr2 = target)
				{
					return Encode(ptr + sourceOffset, sourceLength, ptr2 + targetOffset, targetLength, level);
				}
			}
		}

		public unsafe static int Decode(byte* source, int sourceLength, byte* target, int targetLength)
		{
			if (sourceLength <= 0)
			{
				return 0;
			}
			int num = LLxx.LZ4_decompress_safe(source, target, sourceLength, targetLength);
			if (num > 0)
			{
				return num;
			}
			return -1;
		}

		public unsafe static int PartialDecode(byte* source, int sourceLength, byte* target, int targetLength)
		{
			if (sourceLength <= 0)
			{
				return 0;
			}
			int num = LLxx.LZ4_decompress_safe_partial(source, target, sourceLength, targetLength);
			if (num > 0)
			{
				return num;
			}
			return -1;
		}

		public unsafe static int Decode(byte* source, int sourceLength, byte* target, int targetLength, byte* dictionary, int dictionaryLength)
		{
			if (sourceLength <= 0)
			{
				return 0;
			}
			int num = LLxx.LZ4_decompress_safe_usingDict(source, target, sourceLength, targetLength, dictionary, dictionaryLength);
			if (num > 0)
			{
				return num;
			}
			return -1;
		}

		public unsafe static int PartialDecode(ReadOnlySpan<byte> source, Span<byte> target)
		{
			int length = source.Length;
			if (length <= 0)
			{
				return 0;
			}
			fixed (byte* source2 = source)
			{
				fixed (byte* target2 = target)
				{
					return PartialDecode(source2, length, target2, target.Length);
				}
			}
		}

		public unsafe static int Decode(ReadOnlySpan<byte> source, Span<byte> target)
		{
			int length = source.Length;
			if (length <= 0)
			{
				return 0;
			}
			int length2 = target.Length;
			fixed (byte* source2 = source)
			{
				fixed (byte* target2 = target)
				{
					return Decode(source2, length, target2, length2);
				}
			}
		}

		public unsafe static int Decode(ReadOnlySpan<byte> source, Span<byte> target, ReadOnlySpan<byte> dictionary)
		{
			int length = source.Length;
			if (length <= 0)
			{
				return 0;
			}
			int length2 = target.Length;
			int length3 = dictionary.Length;
			fixed (byte* source2 = source)
			{
				fixed (byte* target2 = target)
				{
					fixed (byte* dictionary2 = dictionary)
					{
						return Decode(source2, length, target2, length2, dictionary2, length3);
					}
				}
			}
		}

		public unsafe static int Decode(byte[] source, int sourceOffset, int sourceLength, byte[] target, int targetOffset, int targetLength)
		{
			source.Validate(sourceOffset, sourceLength);
			target.Validate(targetOffset, targetLength);
			fixed (byte* ptr = source)
			{
				fixed (byte* ptr2 = target)
				{
					return Decode(ptr + sourceOffset, sourceLength, ptr2 + targetOffset, targetLength);
				}
			}
		}

		public unsafe static int Decode(byte[] source, int sourceOffset, int sourceLength, byte[] target, int targetOffset, int targetLength, byte[]? dictionary, int dictionaryOffset, int dictionaryLength)
		{
			source.Validate(sourceOffset, sourceLength);
			target.Validate(targetOffset, targetLength);
			dictionary.Validate(dictionaryOffset, dictionaryLength, allowNullIfEmpty: true);
			fixed (byte* ptr = source)
			{
				fixed (byte* ptr2 = target)
				{
					fixed (byte* ptr3 = dictionary)
					{
						return Decode(ptr + sourceOffset, sourceLength, ptr2 + targetOffset, targetLength, ptr3 + dictionaryOffset, dictionaryLength);
					}
				}
			}
		}
	}
	public enum LZ4Level
	{
		L00_FAST = 0,
		L03_HC = 3,
		L04_HC = 4,
		L05_HC = 5,
		L06_HC = 6,
		L07_HC = 7,
		L08_HC = 8,
		L09_HC = 9,
		L10_OPT = 10,
		L11_OPT = 11,
		L12_MAX = 12
	}
	public static class LZ4Pickler
	{
		private const int MAX_STACKALLOC = 1024;

		private const byte VersionMask = 7;

		public static byte[] Pickle(byte[] source, LZ4Level level = LZ4Level.L00_FAST)
		{
			return Pickle(MemoryExtensions.AsSpan(source), level);
		}

		public static byte[] Pickle(byte[] source, int sourceIndex, int sourceLength, LZ4Level level = LZ4Level.L00_FAST)
		{
			return Pickle(MemoryExtensions.AsSpan(source, sourceIndex, sourceLength), level);
		}

		public unsafe static byte[] Pickle(byte* source, int length, LZ4Level level = LZ4Level.L00_FAST)
		{
			return Pickle(new Span<byte>(source, length), level);
		}

		public static byte[] Pickle(ReadOnlySpan<byte> source, LZ4Level level = LZ4Level.L00_FAST)
		{
			int length = source.Length;
			if (length == 0)
			{
				return Mem.Empty;
			}
			if (length <= 1024)
			{
				Span<byte> buffer = stackalloc byte[1024];
				return PickleWithBuffer(source, level, buffer);
			}
			PinnedMemory.Alloc(out var memory, length, zero: false);
			try
			{
				return PickleWithBuffer(source, level, memory.Span);
			}
			finally
			{
				memory.Free();
			}
		}

		private static byte[] PickleWithBuffer(ReadOnlySpan<byte> source, LZ4Level level, Span<byte> buffer)
		{
			int length = source.Length;
			int num = LZ4Codec.Encode(source, buffer, level);
			if (num <= 0 || num >= length)
			{
				byte[] array = new byte[GetUncompressedHeaderSize(0, length) + length];
				Span<byte> target = MemoryExtensions.AsSpan(array);
				int start = EncodeUncompressedHeader(target, 0, length);
				source.CopyTo(target.Slice(start));
				return array;
			}
			int compressedHeaderSize = GetCompressedHeaderSize(0, length, num);
			byte[] array2 = new byte[compressedHeaderSize + num];
			Span<byte> target2 = MemoryExtensions.AsSpan(array2);
			int start2 = EncodeCompressedHeader(target2, 0, compressedHeaderSize, length, num);
			buffer.Slice(0, num).CopyTo(target2.Slice(start2));
			return array2;
		}

		public static void Pickle<TBufferWriter>(ReadOnlySpan<byte> source, TBufferWriter writer, LZ4Level level = LZ4Level.L00_FAST) where TBufferWriter : IBufferWriter<byte>
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			int length = source.Length;
			if (length != 0)
			{
				int pessimisticHeaderSize = GetPessimisticHeaderSize(0, length);
				Span<byte> span = writer.GetSpan(pessimisticHeaderSize + length);
				int num = LZ4Codec.Encode(source, span.Slice(pessimisticHeaderSize, length), level);
				if (num <= 0 || num >= length)
				{
					int num2 = EncodeUncompressedHeader(span, 0, length);
					source.CopyTo(span.Slice(num2));
					writer.Advance(num2 + length);
				}
				else
				{
					int num3 = EncodeCompressedHeader(span, 0, pessimisticHeaderSize, length, num);
					writer.Advance(num3 + num);
				}
			}
		}

		public static void Pickle(ReadOnlySpan<byte> source, IBufferWriter<byte> writer, LZ4Level level = LZ4Level.L00_FAST)
		{
			LZ4Pickler.Pickle<IBufferWriter<byte>>(source, writer, level);
		}

		private static int GetPessimisticHeaderSize(int version, int sourceLength)
		{
			if (version == 0)
			{
				return 1 + EffectiveSizeOf(sourceLength);
			}
			throw UnexpectedVersion(version);
		}

		private static int GetUncompressedHeaderSize(int version, int sourceLength)
		{
			if (version == 0)
			{
				return 1;
			}
			throw UnexpectedVersion(version);
		}

		private static int GetCompressedHeaderSize(int version, int sourceLength, int encodedLength)
		{
			if (version == 0)
			{
				return 1 + EffectiveSizeOf(sourceLength - encodedLength);
			}
			throw UnexpectedVersion(version);
		}

		private static int EncodeUncompressedHeader(Span<byte> target, int version, int sourceLength)
		{
			if (version == 0)
			{
				return EncodeUncompressedHeaderV0(target);
			}
			throw UnexpectedVersion(version);
		}

		private static int EncodeUncompressedHeaderV0(Span<byte> target)
		{
			target[0] = 0;
			return 1;
		}

		private static int EncodeCompressedHeader(Span<byte> target, int version, int headerSize, int sourceLength, int encodedLength)
		{
			if (version == 0)
			{
				return EncodeCompressedHeaderV0(target, headerSize, sourceLength, encodedLength);
			}
			throw UnexpectedVersion(version);
		}

		private static int EncodeCompressedHeaderV0(Span<byte> target, int headerSize, int sourceLength, int encodedLength)
		{
			int value = sourceLength - encodedLength;
			int num = headerSize - 1;
			target[0] = EncodeHeaderByteV0(num);
			PokeN(target.Slice(1), value, num);
			return 1 + num;
		}

		private unsafe static void PokeN(Span<byte> target, int value, int size)
		{
			if (size < 0 || size > 4 || target.Length < size)
			{
				throw new ArgumentException($"Unexpected size: {size}");
			}
			Unsafe.CopyBlockUnaligned(ref target[0], ref *(byte*)(&value), (uint)size);
		}

		private static byte EncodeHeaderByteV0(int sizeOfDiff)
		{
			return (byte)(0 | ((EncodeSizeOf(sizeOfDiff) & 3) << 6));
		}

		private static int EffectiveSizeOf(int value)
		{
			if (value > 255)
			{
				if (value <= 65535)
				{
					return 2;
				}
			}
			else if (value >= 0)
			{
				return 1;
			}
			return 4;
		}

		private static int EncodeSizeOf(int size)
		{
			if (size == 4)
			{
				return 3;
			}
			return size;
		}

		private static Exception UnexpectedVersion(int version)
		{
			return new ArgumentException($"Unexpected pickle version: {version}");
		}

		public static byte[] Unpickle(byte[] source)
		{
			return Unpickle(MemoryExtensions.AsSpan(source));
		}

		public static byte[] Unpickle(byte[] source, int index, int count)
		{
			return Unpickle(MemoryExtensions.AsSpan(source, index, count));
		}

		public unsafe static byte[] Unpickle(byte* source, int count)
		{
			return Unpickle(new Span<byte>(source, count));
		}

		public static byte[] Unpickle(ReadOnlySpan<byte> source)
		{
			if (source.Length == 0)
			{
				return Mem.Empty;
			}
			PickleHeader header = DecodeHeader(source);
			int num = UnpickledSize(in header);
			if (num == 0)
			{
				return Mem.Empty;
			}
			byte[] array = new byte[num];
			UnpickleCore(in header, source, array);
			return array;
		}

		public static void Unpickle<TBufferWriter>(ReadOnlySpan<byte> source, TBufferWriter writer) where TBufferWriter : IBufferWriter<byte>
		{
			writer.Required("writer");
			if (source.Length != 0)
			{
				PickleHeader header = DecodeHeader(source);
				int num = UnpickledSize(in header);
				Span<byte> target = writer.GetSpan(num).Slice(0, num);
				UnpickleCore(in header, source, target);
				writer.Advance(num);
			}
		}

		public static void Unpickle(ReadOnlySpan<byte> source, IBufferWriter<byte> writer)
		{
			LZ4Pickler.Unpickle<IBufferWriter<byte>>(source, writer);
		}

		public static int UnpickledSize(ReadOnlySpan<byte> source)
		{
			return UnpickledSize(DecodeHeader(source));
		}

		private static int UnpickledSize(in PickleHeader header)
		{
			return header.ResultLength;
		}

		public static void Unpickle(ReadOnlySpan<byte> source, Span<byte> output)
		{
			if (source.Length != 0)
			{
				UnpickleCore(DecodeHeader(source), source, output);
			}
		}

		private static void UnpickleCore(in PickleHeader header, ReadOnlySpan<byte> source, Span<byte> target)
		{
			ReadOnlySpan<byte> source2 = source.Slice(header.DataOffset);
			int num = UnpickledSize(in header);
			int length = target.Length;
			if (length != num)
			{
				throw CorruptedPickle($"Output buffer size ({length}) does not match expected value ({num})");
			}
			if (!header.IsCompressed)
			{
				source2.CopyTo(target);
				return;
			}
			int num2 = LZ4Codec.Decode(source2, target);
			if (num2 == num)
			{
				return;
			}
			throw CorruptedPickle($"Expected to decode {num} bytes but {num2} has been decoded");
		}

		private static PickleHeader DecodeHeader(ReadOnlySpan<byte> source)
		{
			int num = source[0] & 7;
			if (num == 0)
			{
				return DecodeHeaderV0(source);
			}
			throw CorruptedPickle($"Version {num} is not recognized");
		}

		private static PickleHeader DecodeHeaderV0(ReadOnlySpan<byte> source)
		{
			int num = (source[0] >> 6) & 3;
			int num2 = ((num != 3) ? num : 4);
			int num3 = num2;
			ushort num4 = (ushort)(1 + num3);
			int num5 = source.Length - num4;
			if (num5 < 0)
			{
				throw CorruptedPickle($"Unexpected data length: {num5}");
			}
			int num6 = ((num3 != 0) ? PeekN(source.Slice(1), num3) : 0);
			int resultLength = num5 + num6;
			return new PickleHeader(num4, resultLength, num6 != 0);
		}

		private unsafe static int PeekN(ReadOnlySpan<byte> bytes, int size)
		{
			int result = 0;
			if (size < 0 || size > 4 || size > bytes.Length)
			{
				throw CorruptedPickle($"Unexpected field size: {size}");
			}
			fixed (byte* source = bytes)
			{
				Unsafe.CopyBlockUnaligned(&result, source, (uint)size);
			}
			return result;
		}

		private static Exception CorruptedPickle(string message)
		{
			return new InvalidDataException("Pickle is corrupted: " + message);
		}
	}
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal readonly struct PickleHeader
	{
		public ushort DataOffset { get; }

		public ushort Flags { get; }

		public int ResultLength { get; }

		public bool IsCompressed => (Flags & 1) != 0;

		public PickleHeader(ushort dataOffset, int resultLength, bool compressed)
		{
			DataOffset = dataOffset;
			ResultLength = resultLength;
			Flags = (ushort)((compressed ? 1 : 0) | 0);
		}
	}
}
namespace K4os.Compression.LZ4.Internal
{
	public static class BufferPool
	{
		public const int MinPooledSize = 512;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool ShouldBePooled(int length)
		{
			return length >= 512;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static byte[] Rent(int size, bool zero)
		{
			byte[] array = ArrayPool<byte>.Shared.Rent(size);
			if (zero)
			{
				MemoryExtensions.AsSpan(array, 0, size).Clear();
			}
			return array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte[] Alloc(int size, bool zero = false)
		{
			if (!ShouldBePooled(size))
			{
				return new byte[size];
			}
			return Rent(size, zero);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsPooled(byte[] buffer)
		{
			return ShouldBePooled(buffer.Length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Free(byte[]? buffer)
		{
			if (buffer != null && IsPooled(buffer))
			{
				ArrayPool<byte>.Shared.Return(buffer);
			}
		}
	}
	public class Mem
	{
		public const int K1 = 1024;

		public const int K2 = 2048;

		public const int K4 = 4096;

		public const int K8 = 8192;

		public const int K16 = 16384;

		public const int K32 = 32768;

		public const int K64 = 65536;

		public const int K128 = 131072;

		public const int K256 = 262144;

		public const int K512 = 524288;

		public const int M1 = 1048576;

		public const int M4 = 4194304;

		public static readonly byte[] Empty = Array.Empty<byte>();

		public unsafe static bool System32
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return sizeof(void*) < 8;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int RoundUp(int value, int step)
		{
			return (value + step - 1) / step * step;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe static void CpBlk(void* target, void* source, uint length)
		{
			Unsafe.CopyBlockUnaligned(target, source, length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe static void ZBlk(void* target, byte value, uint length)
		{
			Unsafe.InitBlockUnaligned(target, value, length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy(byte* target, byte* source, int length)
		{
			if (length > 0)
			{
				CpBlk(target, source, (uint)length);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Move(byte* target, byte* source, int length)
		{
			Buffer.MemoryCopy(source, target, length, length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void* Alloc(int size)
		{
			return Marshal.AllocHGlobal(size).ToPointer();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static byte* Zero(byte* target, int length)
		{
			return Fill(target, 0, length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static byte* Fill(byte* target, byte value, int length)
		{
			if (length > 0)
			{
				ZBlk(target, value, (uint)length);
			}
			return target;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void* AllocZero(int size)
		{
			return Zero((byte*)Alloc(size), size);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Free(void* ptr)
		{
			Marshal.FreeHGlobal(new IntPtr(ptr));
		}

		public unsafe static T* CloneArray<T>(T[] array) where T : unmanaged
		{
			int num = Unsafe.SizeOf<T>() * array.Length;
			void* intPtr = Alloc(num);
			fixed (byte* ptr = &Unsafe.As<T, byte>(ref array[0]))
			{
				void* source = ptr;
				Copy((byte*)intPtr, (byte*)source, num);
			}
			return (T*)intPtr;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static byte Peek1(void* p)
		{
			return *(byte*)p;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Poke1(void* p, byte v)
		{
			*(byte*)p = v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ushort Peek2(void* p)
		{
			ushort result = default(ushort);
			CpBlk(&result, p, 2u);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Poke2(void* p, ushort v)
		{
			CpBlk(p, &v, 2u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint Peek4(void* p)
		{
			uint result = default(uint);
			CpBlk(&result, p, 4u);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Poke4(void* p, uint v)
		{
			CpBlk(p, &v, 4u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ulong Peek8(void* p)
		{
			ulong result = default(ulong);
			CpBlk(&result, p, 8u);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Poke8(void* p, ulong v)
		{
			CpBlk(p, &v, 8u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy1(byte* target, byte* source)
		{
			*target = *source;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy2(byte* target, byte* source)
		{
			CpBlk(target, source, 2u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy4(byte* target, byte* source)
		{
			CpBlk(target, source, 4u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy8(byte* target, byte* source)
		{
			CpBlk(target, source, 8u);
		}
	}
	public struct PinnedMemory
	{
		private unsafe byte* _pointer;

		private GCHandle _handle;

		private int _size;

		public static int MaxPooledSize { get; set; } = 1048576;

		public unsafe readonly byte* Pointer
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _pointer;
			}
		}

		public unsafe Span<byte> Span
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new Span<byte>(Pointer, _size);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe readonly T* Reference<T>() where T : unmanaged
		{
			return (T*)_pointer;
		}

		public static PinnedMemory Alloc(int size, bool zero = true)
		{
			Alloc(out var memory, size, zero);
			return memory;
		}

		public static void Alloc(out PinnedMemory memory, int size, bool zero = true)
		{
			if (size <= 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			if (size > MaxPooledSize)
			{
				AllocateNative(out memory, size, zero);
			}
			else
			{
				RentManagedFromPool(out memory, size, zero);
			}
		}

		public unsafe static void Alloc<T>(out PinnedMemory memory, bool zero = true) where T : unmanaged
		{
			Alloc(out memory, sizeof(T), zero);
		}

		private unsafe static void AllocateNative(out PinnedMemory memory, int size, bool zero)
		{
			void* pointer = (zero ? Mem.AllocZero(size) : Mem.Alloc(size));
			GC.AddMemoryPressure(size);
			memory._pointer = (byte*)pointer;
			memory._handle = default(GCHandle);
			memory._size = size;
		}

		private unsafe static void RentManagedFromPool(out PinnedMemory memory, int size, bool zero)
		{
			GCHandle handle = GCHandle.Alloc(BufferPool.Alloc(size, zero), GCHandleType.Pinned);
			byte* pointer = (byte*)(void*)handle.AddrOfPinnedObject();
			memory._pointer = pointer;
			memory._handle = handle;
			memory._size = size;
		}

		public unsafe void Clear()
		{
			if (_size > 0 && _pointer != null)
			{
				Mem.Zero(_pointer, _size);
			}
		}

		public unsafe void Free()
		{
			if (_handle.IsAllocated)
			{
				ReleaseManaged();
			}
			else if (_pointer != null)
			{
				ReleaseNative();
			}
			ClearFields();
		}

		private void ReleaseManaged()
		{
			byte[] buffer = (_handle.IsAllocated ? ((byte[])_handle.Target) : null);
			_handle.Free();
			BufferPool.Free(buffer);
		}

		private unsafe void ReleaseNative()
		{
			GC.RemoveMemoryPressure(_size);
			Mem.Free(_pointer);
		}

		private unsafe void ClearFields()
		{
			_pointer = null;
			_handle = default(GCHandle);
			_size = 0;
		}
	}
	public abstract class UnmanagedResources : IDisposable
	{
		private int _disposed;

		public bool IsDisposed => Interlocked.CompareExchange(ref _disposed, 0, 0) != 0;

		protected void ThrowIfDisposed()
		{
			if (IsDisposed)
			{
				throw new ObjectDisposedException(GetType().FullName + " is already disposed");
			}
		}

		protected virtual void ReleaseUnmanaged()
		{
		}

		protected virtual void ReleaseManaged()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
			if (Interlocked.CompareExchange(ref _disposed, 1, 0) == 0)
			{
				ReleaseUnmanaged();
				if (disposing)
				{
					ReleaseManaged();
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~UnmanagedResources()
		{
			Dispose(disposing: false);
		}
	}
	public class Mem32 : Mem
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint PeekW(void* p)
		{
			return Mem.Peek4(p);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void PokeW(void* p, uint v)
		{
			Mem.Poke4(p, v);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy16(byte* target, byte* source)
		{
			Mem.Copy8(target, source);
			Mem.Copy8(target + 8, source + 8);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy18(byte* target, byte* source)
		{
			Mem.Copy8(target, source);
			Mem.Copy8(target + 8, source + 8);
			Mem.Copy2(target + 16, source + 16);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void WildCopy8(byte* target, byte* source, void* limit)
		{
			do
			{
				Mem.Copy8(target, source);
				target += 8;
				source += 8;
			}
			while (target < limit);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void WildCopy32(byte* target, byte* source, void* limit)
		{
			do
			{
				Copy16(target, source);
				Copy16(target + 16, source + 16);
				target += 32;
				source += 32;
			}
			while (target < limit);
		}
	}
	public class Mem64 : Mem
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static ushort Peek2(void* p)
		{
			return *(ushort*)p;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static void Poke2(void* p, ushort v)
		{
			*(ushort*)p = v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static uint Peek4(void* p)
		{
			return *(uint*)p;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static void Poke4(void* p, uint v)
		{
			*(uint*)p = v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static void Copy1(byte* target, byte* source)
		{
			*target = *source;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static void Copy2(byte* target, byte* source)
		{
			*(short*)target = *(short*)source;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static void Copy4(byte* target, byte* source)
		{
			*(int*)target = *(int*)source;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static ulong Peek8(void* p)
		{
			return *(ulong*)p;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static void Poke8(void* p, ulong v)
		{
			*(ulong*)p = v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static void Copy8(byte* target, byte* source)
		{
			*(long*)target = *(long*)source;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ulong PeekW(void* p)
		{
			return Peek8(p);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void PokeW(void* p, ulong v)
		{
			Poke8(p, v);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy16(byte* target, byte* source)
		{
			Copy8(target, source);
			Copy8(target + 8, source + 8);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy18(byte* target, byte* source)
		{
			Copy8(target, source);
			Copy8(target + 8, source + 8);
			Copy2(target + 16, source + 16);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void WildCopy8(byte* target, byte* source, void* limit)
		{
			do
			{
				Copy8(target, source);
				target += 8;
				source += 8;
			}
			while (target < limit);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void WildCopy32(byte* target, byte* source, void* limit)
		{
			do
			{
				Copy16(target, source);
				Copy16(target + 16, source + 16);
				target += 32;
				source += 32;
			}
			while (target < limit);
		}
	}
}
namespace K4os.Compression.LZ4.Engine
{
	public enum Algorithm
	{
		X32,
		X64
	}
	internal class LL
	{
		public struct LZ4_stream_t
		{
			public unsafe fixed uint hashTable[4096];

			public uint currentOffset;

			public bool dirty;

			public tableType_t tableType;

			public unsafe byte* dictionary;

			public unsafe LZ4_stream_t* dictCtx;

			public uint dictSize;
		}

		public struct LZ4_streamDecode_t
		{
			public unsafe byte* externalDict;

			public uint extDictSize;

			public unsafe byte* prefixEnd;

			public uint prefixSize;
		}

		public enum limitedOutput_directive
		{
			notLimited,
			limitedOutput,
			fillOutput
		}

		public enum tableType_t
		{
			clearedTable,
			byPtr,
			byU32,
			byU16
		}

		public enum dict_directive
		{
			noDict,
			withPrefix64k,
			usingExtDict,
			usingDictCtx
		}

		public enum dictIssue_directive
		{
			noDictIssue,
			dictSmall
		}

		public enum endCondition_directive
		{
			endOnOutputSize,
			endOnInputSize
		}

		public enum earlyEnd_directive
		{
			full,
			partial
		}

		protected enum variable_length_error
		{
			loop_error = -2,
			initial_error,
			ok
		}

		public enum dictCtx_directive
		{
			noDictCtx,
			usingDictCtxHc
		}

		public struct LZ4_streamHC_t
		{
			public unsafe fixed uint hashTable[32768];

			public unsafe fixed ushort chainTable[65536];

			public unsafe byte* end;

			public unsafe byte* @base;

			public unsafe byte* dictBase;

			public uint dictLimit;

			public uint lowLimit;

			public uint nextToUpdate;

			public short compressionLevel;

			public bool favorDecSpeed;

			public bool dirty;

			public unsafe LZ4_streamHC_t* dictCtx;
		}

		protected enum repeat_state_e
		{
			rep_untested,
			rep_not,
			rep_confirmed
		}

		public enum HCfavor_e
		{
			favorCompressionRatio,
			favorDecompressionSpeed
		}

		public struct LZ4HC_match_t
		{
			public int off;

			public int len;
		}

		public struct LZ4HC_optimal_t
		{
			public int price;

			public int off;

			public int mlen;

			public int litlen;
		}

		public enum lz4hc_strat_e
		{
			lz4hc,
			lz4opt
		}

		public struct cParams_t(lz4hc_strat_e strat, uint nbSearches, uint targetLength)
		{
			public lz4hc_strat_e strat = strat;

			public uint nbSearches = nbSearches;

			public uint targetLength = targetLength;
		}

		private static readonly uint[] _inc32table = new uint[8] { 0u, 1u, 2u, 1u, 0u, 4u, 4u, 4u };

		private static readonly int[] _dec64table = new int[8] { 0, 0, 0, -1, -4, 1, 2, 3 };

		protected unsafe static readonly uint* inc32table = Mem.CloneArray(_inc32table);

		protected unsafe static readonly int* dec64table = Mem.CloneArray(_dec64table);

		protected const int LZ4_MEMORY_USAGE = 14;

		protected const int LZ4_MAX_INPUT_SIZE = 2113929216;

		protected const int LZ4_DISTANCE_MAX = 65535;

		protected const int LZ4_DISTANCE_ABSOLUTE_MAX = 65535;

		protected const int LZ4_HASHLOG = 12;

		protected const int LZ4_HASHTABLESIZE = 16384;

		protected const int LZ4_HASH_SIZE_U32 = 4096;

		protected const int ACCELERATION_DEFAULT = 1;

		protected const int MINMATCH = 4;

		protected const int WILDCOPYLENGTH = 8;

		protected const int LASTLITERALS = 5;

		protected const int MFLIMIT = 12;

		protected const int MATCH_SAFEGUARD_DISTANCE = 12;

		protected const int FASTLOOP_SAFE_DISTANCE = 64;

		protected const int LZ4_minLength = 13;

		protected const int KB = 1024;

		protected const int MB = 1048576;

		protected const uint GB = 1073741824u;

		protected const int ML_BITS = 4;

		protected const uint ML_MASK = 15u;

		protected const int RUN_BITS = 4;

		protected const uint RUN_MASK = 15u;

		protected const int OPTIMAL_ML = 18;

		protected const int LZ4_OPT_NUM = 4096;

		protected const int LZ4_64Klimit = 65547;

		protected const int LZ4_skipTrigger = 6;

		protected const int LZ4HC_DICTIONARY_LOGSIZE = 16;

		protected const int LZ4HC_MAXD = 65536;

		protected const int LZ4HC_MAXD_MASK = 65535;

		protected const int LZ4HC_HASH_LOG = 15;

		protected const int LZ4HC_HASHTABLESIZE = 32768;

		protected const int LZ4HC_HASH_MASK = 32767;

		protected const int LZ4HC_CLEVEL_MIN = 3;

		protected const int LZ4HC_CLEVEL_DEFAULT = 9;

		protected const int LZ4HC_CLEVEL_OPT_MIN = 10;

		protected const int LZ4HC_CLEVEL_MAX = 12;

		public static bool Enforce32 { get; set; } = false;

		public static Algorithm Algorithm
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (!Enforce32 && !Mem.System32)
				{
					return Algorithm.X64;
				}
				return Algorithm.X32;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4_sizeofStateHC()
		{
			return sizeof(LZ4_streamHC_t);
		}

		public unsafe static void LZ4_setCompressionLevel(LZ4_streamHC_t* LZ4_streamHCPtr, int compressionLevel)
		{
			if (compressionLevel < 1)
			{
				compressionLevel = 9;
			}
			if (compressionLevel > 12)
			{
				compressionLevel = 12;
			}
			LZ4_streamHCPtr->compressionLevel = (short)compressionLevel;
		}

		public unsafe static void LZ4_favorDecompressionSpeed(LZ4_streamHC_t* LZ4_streamHCPtr, int favor)
		{
			LZ4_streamHCPtr->favorDecSpeed = favor != 0;
		}

		public unsafe static LZ4_streamHC_t* LZ4_initStreamHC(void* buffer, int size)
		{
			if (buffer == null)
			{
				return null;
			}
			if (size < sizeof(LZ4_streamHC_t))
			{
				return null;
			}
			((LZ4_streamHC_t*)buffer)->end = (byte*)(-1);
			((LZ4_streamHC_t*)buffer)->@base = null;
			((LZ4_streamHC_t*)buffer)->dictCtx = null;
			((LZ4_streamHC_t*)buffer)->favorDecSpeed = false;
			((LZ4_streamHC_t*)buffer)->dirty = false;
			LZ4_setCompressionLevel((LZ4_streamHC_t*)buffer, 9);
			return (LZ4_streamHC_t*)buffer;
		}

		public unsafe static LZ4_streamHC_t* LZ4_initStreamHC(LZ4_streamHC_t* stream)
		{
			return LZ4_initStreamHC(stream, sizeof(LZ4_streamHC_t));
		}

		public unsafe static void LZ4_resetStreamHC_fast(LZ4_streamHC_t* LZ4_streamHCPtr, int compressionLevel)
		{
			if (LZ4_streamHCPtr->dirty)
			{
				LZ4_initStreamHC(LZ4_streamHCPtr);
			}
			else
			{
				byte** end = &LZ4_streamHCPtr->end;
				*end -= LZ4_streamHCPtr->@base;
				LZ4_streamHCPtr->@base = null;
				LZ4_streamHCPtr->dictCtx = null;
			}
			LZ4_setCompressionLevel(LZ4_streamHCPtr, compressionLevel);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint HASH_FUNCTION(uint value)
		{
			return (uint)((int)value * -1640531535) >> 17;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static ref ushort DELTANEXTU16(ushort* table, uint pos)
		{
			return ref table[(int)(ushort)pos];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint LZ4HC_hashPtr(void* ptr)
		{
			return HASH_FUNCTION(Mem.Peek4(ptr));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void LZ4HC_Insert(LZ4_streamHC_t* hc4, byte* ip)
		{
			ushort* table = hc4->chainTable;
			uint* ptr = hc4->hashTable;
			byte* ptr2 = hc4->@base;
			uint num = (uint)(ip - ptr2);
			for (uint num2 = hc4->nextToUpdate; num2 < num; num2++)
			{
				uint num3 = LZ4HC_hashPtr(ptr2 + num2);
				uint num4 = num2 - ptr[num3];
				if (num4 > 65535)
				{
					num4 = 65535u;
				}
				DELTANEXTU16(table, num2) = (ushort)num4;
				ptr[num3] = num2;
			}
			hc4->nextToUpdate = num;
		}

		public unsafe static void LZ4HC_setExternalDict(LZ4_streamHC_t* ctxPtr, byte* newBlock)
		{
			if (ctxPtr->end >= ctxPtr->@base + ctxPtr->dictLimit + 4)
			{
				LZ4HC_Insert(ctxPtr, ctxPtr->end - 3);
			}
			ctxPtr->lowLimit = ctxPtr->dictLimit;
			ctxPtr->dictLimit = (uint)(ctxPtr->end - ctxPtr->@base);
			ctxPtr->dictBase = ctxPtr->@base;
			ctxPtr->@base = newBlock - ctxPtr->dictLimit;
			ctxPtr->end = newBlock;
			ctxPtr->nextToUpdate = ctxPtr->dictLimit;
			ctxPtr->dictCtx = null;
		}

		public unsafe static void LZ4HC_clearTables(LZ4_streamHC_t* hc4)
		{
			Mem.Fill((byte*)hc4->hashTable, 0, 131072);
			Mem.Fill((byte*)hc4->chainTable, byte.MaxValue, 131072);
		}

		public unsafe static void LZ4HC_init_internal(LZ4_streamHC_t* hc4, byte* start)
		{
			long num = hc4->end - hc4->@base;
			if (num < 0 || num > 1073741824)
			{
				LZ4HC_clearTables(hc4);
				num = 0L;
			}
			num += 65536;
			hc4->nextToUpdate = (uint)num;
			hc4->@base = start - num;
			hc4->end = start;
			hc4->dictBase = start - num;
			hc4->dictLimit = (uint)num;
			hc4->lowLimit = (uint)num;
		}

		public unsafe static int LZ4_saveDictHC(LZ4_streamHC_t* LZ4_streamHCPtr, byte* safeBuffer, int dictSize)
		{
			int num = (int)(LZ4_streamHCPtr->end - (LZ4_streamHCPtr->@base + LZ4_streamHCPtr->dictLimit));
			if (dictSize > 65536)
			{
				dictSize = 65536;
			}
			if (dictSize < 4)
			{
				dictSize = 0;
			}
			if (dictSize > num)
			{
				dictSize = num;
			}
			Mem.Move(safeBuffer, LZ4_streamHCPtr->end - dictSize, dictSize);
			uint num2 = (uint)(LZ4_streamHCPtr->end - LZ4_streamHCPtr->@base);
			LZ4_streamHCPtr->end = safeBuffer + dictSize;
			LZ4_streamHCPtr->@base = LZ4_streamHCPtr->end - num2;
			LZ4_streamHCPtr->dictLimit = num2 - (uint)dictSize;
			LZ4_streamHCPtr->lowLimit = num2 - (uint)dictSize;
			if (LZ4_streamHCPtr->nextToUpdate < LZ4_streamHCPtr->dictLimit)
			{
				LZ4_streamHCPtr->nextToUpdate = LZ4_streamHCPtr->dictLimit;
			}
			return dictSize;
		}

		public unsafe static int LZ4_loadDictHC(LZ4_streamHC_t* LZ4_streamHCPtr, byte* dictionary, int dictSize)
		{
			if (dictSize > 65536)
			{
				dictionary += dictSize - 65536;
				dictSize = 65536;
			}
			int compressionLevel = LZ4_streamHCPtr->compressionLevel;
			LZ4_initStreamHC(LZ4_streamHCPtr);
			LZ4_setCompressionLevel(LZ4_streamHCPtr, compressionLevel);
			LZ4HC_init_internal(LZ4_streamHCPtr, dictionary);
			LZ4_streamHCPtr->end = dictionary + dictSize;
			if (dictSize >= 4)
			{
				LZ4HC_Insert(LZ4_streamHCPtr, LZ4_streamHCPtr->end - 3);
			}
			return dictSize;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint LZ4HC_rotl32(uint x, int r)
		{
			return (x << r) | (x >> 32 - r);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool LZ4HC_protectDictEnd(uint dictLimit, uint matchIndex)
		{
			return dictLimit - 1 - matchIndex >= 3;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_countBack(byte* ip, byte* match, byte* iMin, byte* mMin)
		{
			int num = 0;
			int num2 = (int)MAX(iMin - ip, mMin - match);
			while (num > num2 && ip[num - 1] == match[num - 1])
			{
				num--;
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint LZ4HC_reverseCountPattern(byte* ip, byte* iLow, uint pattern)
		{
			byte* ptr = ip;
			while (ip >= iLow + 4 && Mem.Peek4(ip - 4) == pattern)
			{
				ip -= 4;
			}
			byte* ptr2 = (byte*)(&pattern) + 3;
			while (ip > iLow && ip[-1] == *ptr2)
			{
				ip--;
				ptr2--;
			}
			return (uint)(ptr - ip);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint LZ4HC_rotatePattern(uint rotate, uint pattern)
		{
			uint num = (rotate & 3) << 3;
			if (num == 0)
			{
				return pattern;
			}
			return LZ4HC_rotl32(pattern, (int)num);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int LZ4HC_literalsPrice(int litlen)
		{
			int num = litlen;
			if (litlen >= 15)
			{
				num += 1 + (litlen - 15) / 255;
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int LZ4HC_sequencePrice(int litlen, int mlen)
		{
			int num = 3;
			num += LZ4HC_literalsPrice(litlen);
			if (mlen >= 19)
			{
				num += 1 + (mlen - 19) / 255;
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		public static void Assert(bool value, [CallerArgumentExpression("value")] string message = null)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int LZ4_compressBound(int isize)
		{
			if (isize <= 2113929216)
			{
				return isize + isize / 255 + 16;
			}
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int LZ4_decoderRingBufferSize(int isize)
		{
			return 65550 + isize;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected static uint LZ4_hash4(uint sequence, tableType_t tableType)
		{
			int num = ((tableType == tableType_t.byU16) ? 13 : 12);
			return (uint)((int)sequence * -1640531535) >> 32 - num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected static uint LZ4_hash5(ulong sequence, tableType_t tableType)
		{
			int num = ((tableType == tableType_t.byU16) ? 13 : 12);
			return (uint)((sequence << 24) * 889523592379L >> 64 - num);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static void LZ4_clearHash(uint h, void* tableBase, tableType_t tableType)
		{
			switch (tableType)
			{
			case tableType_t.byPtr:
				*(IntPtr*)((byte*)tableBase + h * sizeof(byte*)) = (nint)0;
				break;
			case tableType_t.byU32:
				((int*)tableBase)[h] = 0;
				break;
			case tableType_t.byU16:
				((short*)tableBase)[h] = 0;
				break;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static void LZ4_putIndexOnHash(uint idx, uint h, void* tableBase, tableType_t tableType)
		{
			switch (tableType)
			{
			case tableType_t.byU32:
				((int*)tableBase)[h] = (int)idx;
				break;
			case tableType_t.byU16:
				((short*)tableBase)[h] = (short)(ushort)idx;
				break;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static void LZ4_putPositionOnHash(byte* p, uint h, void* tableBase, tableType_t tableType, byte* srcBase)
		{
			switch (tableType)
			{
			case tableType_t.byPtr:
				*(byte**)((byte*)tableBase + h * sizeof(byte*)) = p;
				break;
			case tableType_t.byU32:
				((int*)tableBase)[h] = (int)(p - srcBase);
				break;
			case tableType_t.byU16:
				((short*)tableBase)[h] = (short)(ushort)(p - srcBase);
				break;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static uint LZ4_getIndexOnHash(uint h, void* tableBase, tableType_t tableType)
		{
			return tableType switch
			{
				tableType_t.byU32 => ((uint*)tableBase)[h], 
				tableType_t.byU16 => ((ushort*)tableBase)[h], 
				_ => 0u, 
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static byte* LZ4_getPositionOnHash(uint h, void* tableBase, tableType_t tableType, byte* srcBase)
		{
			return tableType switch
			{
				tableType_t.byPtr => ((byte**)tableBase)[h], 
				tableType_t.byU32 => (uint)((int*)tableBase)[h] + srcBase, 
				_ => (int)((ushort*)tableBase)[h] + srcBase, 
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int MIN(int a, int b)
		{
			if (a >= b)
			{
				return b;
			}
			return a;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint MIN(uint a, uint b)
		{
			if (a >= b)
			{
				return b;
			}
			return a;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint MAX(uint a, uint b)
		{
			if (a >= b)
			{
				return a;
			}
			return b;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long MAX(long a, long b)
		{
			if (a >= b)
			{
				return a;
			}
			return b;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long MIN(long a, long b)
		{
			if (a >= b)
			{
				return b;
			}
			return a;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static uint LZ4_readVLE(byte** ip, byte* lencheck, bool loop_check, bool initial_check, variable_length_error* error)
		{
			uint num = 0u;
			if (initial_check && *ip >= lencheck)
			{
				*error = variable_length_error.initial_error;
				return num;
			}
			uint num2;
			do
			{
				num2 = *(*ip);
				(*ip)++;
				num += num2;
				if (loop_check && *ip >= lencheck)
				{
					*error = variable_length_error.loop_error;
					return num;
				}
			}
			while (num2 == 255);
			return num;
		}

		public unsafe static int LZ4_saveDict(LZ4_stream_t* LZ4_dict, byte* safeBuffer, int dictSize)
		{
			byte* ptr = LZ4_dict->dictionary + LZ4_dict->dictSize;
			if ((uint)dictSize > 65536u)
			{
				dictSize = 65536;
			}
			if ((uint)dictSize > LZ4_dict->dictSize)
			{
				dictSize = (int)LZ4_dict->dictSize;
			}
			Mem.Move(safeBuffer, ptr - dictSize, dictSize);
			LZ4_dict->dictionary = safeBuffer;
			LZ4_dict->dictSize = (uint)dictSize;
			return dictSize;
		}

		public unsafe static LZ4_stream_t* LZ4_initStream(LZ4_stream_t* buffer)
		{
			Mem.Zero((byte*)buffer, sizeof(LZ4_stream_t));
			return buffer;
		}

		public unsafe static void LZ4_setStreamDecode(LZ4_streamDecode_t* LZ4_streamDecode, byte* dictionary, int dictSize)
		{
			LZ4_streamDecode->prefixSize = (uint)dictSize;
			LZ4_streamDecode->prefixEnd = dictionary + dictSize;
			LZ4_streamDecode->externalDict = null;
			LZ4_streamDecode->extDictSize = 0u;
		}
	}
	internal static class LLxx
	{
		private static NotImplementedException AlgorithmNotImplemented(string action)
		{
			return new NotImplementedException($"Algorithm {LL.Algorithm} not implemented for {action}");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_decompress_safe(byte* source, byte* target, int sourceLength, int targetLength)
		{
			return LL.Algorithm switch
			{
				Algorithm.X64 => LL64.LZ4_decompress_safe(source, target, sourceLength, targetLength), 
				Algorithm.X32 => LL32.LZ4_decompress_safe(source, target, sourceLength, targetLength), 
				_ => throw AlgorithmNotImplemented("LZ4_decompress_safe"), 
			};
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_decompress_safe_partial(byte* source, byte* target, int sourceLength, int targetLength)
		{
			return LL.Algorithm switch
			{
				Algorithm.X64 => LL64.LZ4_decompress_safe_partial(source, target, sourceLength, targetLength, targetLength), 
				Algorithm.X32 => LL32.LZ4_decompress_safe_partial(source, target, sourceLength, targetLength, targetLength), 
				_ => throw AlgorithmNotImplemented("LZ4_decompress_safe_partial"), 
			};
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_decompress_safe_usingDict(byte* source, byte* target, int sourceLength, int targetLength, byte* dictionary, int dictionaryLength)
		{
			return LL.Algorithm switch
			{
				Algorithm.X64 => LL64.LZ4_decompress_safe_usingDict(source, target, sourceLength, targetLength, dictionary, dictionaryLength), 
				Algorithm.X32 => LL32.LZ4_decompress_safe_usingDict(source, target, sourceLength, targetLength, dictionary, dictionaryLength), 
				_ => throw AlgorithmNotImplemented("LZ4_decompress_safe_usingDict"), 
			};
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_decompress_safe_continue(LL.LZ4_streamDecode_t* context, byte* source, byte* target, int sourceLength, int targetLength)
		{
			return LL.Algorithm switch
			{
				Algorithm.X64 => LL64.LZ4_decompress_safe_continue(context, source, target, sourceLength, targetLength), 
				Algorithm.X32 => LL32.LZ4_decompress_safe_continue(context, source, target, sourceLength, targetLength), 
				_ => throw AlgorithmNotImplemented("LZ4_decompress_safe_continue"), 
			};
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_compress_fast(byte* source, byte* target, int sourceLength, int targetLength, int acceleration)
		{
			return LL.Algorithm switch
			{
				Algorithm.X64 => LL64.LZ4_compress_fast(source, target, sourceLength, targetLength, acceleration), 
				Algorithm.X32 => LL32.LZ4_compress_fast(source, target, sourceLength, targetLength, acceleration), 
				_ => throw AlgorithmNotImplemented("LZ4_compress_fast"), 
			};
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_compress_fast_continue(LL.LZ4_stream_t* context, byte* source, byte* target, int sourceLength, int targetLength, int acceleration)
		{
			return LL.Algorithm switch
			{
				Algorithm.X64 => LL64.LZ4_compress_fast_continue(context, source, target, sourceLength, targetLength, acceleration), 
				Algorithm.X32 => LL32.LZ4_compress_fast_continue(context, source, target, sourceLength, targetLength, acceleration), 
				_ => throw AlgorithmNotImplemented("LZ4_compress_fast_continue"), 
			};
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_compress_HC(byte* source, byte* target, int sourceLength, int targetLength, int level)
		{
			return LL.Algorithm switch
			{
				Algorithm.X64 => LL64.LZ4_compress_HC(source, target, sourceLength, targetLength, level), 
				Algorithm.X32 => LL32.LZ4_compress_HC(source, target, sourceLength, targetLength, level), 
				_ => throw AlgorithmNotImplemented("LZ4_compress_HC"), 
			};
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_compress_HC_continue(LL.LZ4_streamHC_t* context, byte* source, byte* target, int sourceLength, int targetLength)
		{
			return LL.Algorithm switch
			{
				Algorithm.X64 => LL64.LZ4_compress_HC_continue(context, source, target, sourceLength, targetLength), 
				Algorithm.X32 => LL32.LZ4_compress_HC_continue(context, source, target, sourceLength, targetLength), 
				_ => throw AlgorithmNotImplemented("LZ4_compress_HC_continue"), 
			};
		}
	}
	public static class Pubternal
	{
		public class FastContext : UnmanagedResources
		{
			internal unsafe LL.LZ4_stream_t* Context { get; }

			public unsafe FastContext()
			{
				Context = (LL.LZ4_stream_t*)Mem.AllocZero(sizeof(LL.LZ4_stream_t));
			}

			protected unsafe override void ReleaseUnmanaged()
			{
				Mem.Free(Context);
			}
		}

		public unsafe static int CompressFast(FastContext context, byte* source, byte* target, int sourceLength, int targetLength, int acceleration)
		{
			return LLxx.LZ4_compress_fast_continue(context.Context, source, target, sourceLength, targetLength, acceleration);
		}
	}
	internal class LL32 : LL
	{
		protected static cParams_t[] clTable = new cParams_t[13]
		{
			new cParams_t(lz4hc_strat_e.lz4hc, 2u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 2u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 2u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 4u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 8u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 16u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 32u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 64u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 128u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 256u, 16u),
			new cParams_t(lz4hc_strat_e.lz4opt, 96u, 64u),
			new cParams_t(lz4hc_strat_e.lz4opt, 512u, 128u),
			new cParams_t(lz4hc_strat_e.lz4opt, 16384u, 4096u)
		};

		protected const int ALGORITHM_ARCH = 4;

		private static readonly uint[] _DeBruijnBytePos = new uint[32]
		{
			0u, 0u, 3u, 0u, 3u, 1u, 3u, 0u, 3u, 2u,
			2u, 1u, 3u, 2u, 0u, 1u, 3u, 3u, 1u, 2u,
			2u, 2u, 2u, 0u, 3u, 1u, 2u, 0u, 1u, 0u,
			1u, 1u
		};

		private unsafe static readonly uint* DeBruijnBytePos = Mem.CloneArray(_DeBruijnBytePos);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4_decompress_generic(byte* src, byte* dst, int srcSize, int outputSize, endCondition_directive endOnInput, earlyEnd_directive partialDecoding, dict_directive dict, byte* lowPrefix, byte* dictStart, uint dictSize)
		{
			return LZ4_decompress_generic(src, dst, srcSize, outputSize, endOnInput == endCondition_directive.endOnInputSize, partialDecoding == earlyEnd_directive.partial, dict, lowPrefix, dictStart, dictSize);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4_decompress_generic(byte* src, byte* dst, int srcSize, int outputSize, bool endOnInput, bool partialDecoding, dict_directive dict, byte* lowPrefix, byte* dictStart, uint dictSize)
		{
			if (src == null)
			{
				return -1;
			}
			byte* ptr = src;
			byte* ptr2 = ptr + srcSize;
			byte* ptr3 = dst;
			byte* ptr4 = ptr3 + outputSize;
			byte* ptr5 = ((dictStart == null) ? null : (dictStart + dictSize));
			bool flag = endOnInput;
			bool flag2 = flag && dictSize < 65536;
			byte* ptr6 = ptr2 - (endOnInput ? 14 : 8) - 2;
			byte* ptr7 = ptr4 - (endOnInput ? 14 : 8) - 18;
			if (endOnInput && outputSize == 0)
			{
				if (partialDecoding)
				{
					return 0;
				}
				if (srcSize != 1 || *ptr != 0)
				{
					return -1;
				}
				return 0;
			}
			if (!endOnInput && outputSize == 0)
			{
				if (*ptr != 0)
				{
					return -1;
				}
				return 1;
			}
			if (endOnInput && srcSize == 0)
			{
				return -1;
			}
			while (true)
			{
				uint num = *(ptr++);
				uint num2 = num >> 4;
				uint num3;
				byte* ptr9;
				byte* ptr8;
				if ((endOnInput ? (num2 != 15) : (num2 <= 8)) && (!endOnInput || ptr < ptr6) && ptr3 <= ptr7)
				{
					if (endOnInput)
					{
						Mem32.Copy16(ptr3, ptr);
					}
					else
					{
						Mem.Copy8(ptr3, ptr);
					}
					ptr3 += num2;
					ptr += num2;
					num2 = num & 0xF;
					num3 = Mem.Peek2(ptr);
					ptr += 2;
					ptr8 = ptr3 - num3;
					if (num2 != 15 && num3 >= 8 && (dict == dict_directive.withPrefix64k || ptr8 >= lowPrefix))
					{
						Mem32.Copy18(ptr3, ptr8);
						ptr3 += num2 + 4;
						continue;
					}
				}
				else
				{
					if (num2 == 15)
					{
						variable_length_error variable_length_error = variable_length_error.ok;
						num2 += LL.LZ4_readVLE(&ptr, ptr2 - 15, endOnInput, endOnInput, &variable_length_error);
						if (variable_length_error == variable_length_error.initial_error || (flag && ptr3 + num2 < ptr3) || (flag && ptr + num2 < ptr))
						{
							break;
						}
					}
					ptr9 = ptr3 + num2;
					if ((endOnInput && (ptr9 > ptr4 - 12 || ptr + num2 > ptr2 - 8)) || (!endOnInput && ptr9 > ptr4 - 8))
					{
						if (partialDecoding)
						{
							if (ptr + num2 > ptr2 - 8 && ptr + num2 != ptr2)
							{
								break;
							}
							if (ptr9 > ptr4)
							{
								ptr9 = ptr4;
								num2 = (uint)(ptr4 - ptr3);
							}
						}
						else if ((!endOnInput && ptr9 != ptr4) || (endOnInput && (ptr + num2 != ptr2 || ptr9 > ptr4)))
						{
							break;
						}
						Mem.Move(ptr3, ptr, (int)num2);
						ptr += num2;
						ptr3 += num2;
						if (!partialDecoding || ptr9 == ptr4 || ptr == ptr2)
						{
							goto IL_04a7;
						}
					}
					else
					{
						Mem32.WildCopy8(ptr3, ptr, ptr9);
						ptr += num2;
						ptr3 = ptr9;
					}
					num3 = Mem.Peek2(ptr);
					ptr += 2;
					ptr8 = ptr3 - num3;
					num2 = num & 0xF;
				}
				if (num2 == 15)
				{
					variable_length_error variable_length_error2 = variable_length_error.ok;
					num2 += LL.LZ4_readVLE(&ptr, ptr2 - 5 + 1, endOnInput, initial_check: false, &variable_length_error2);
					if (variable_length_error2 != variable_length_error.ok || (flag && ptr3 + num2 < ptr3))
					{
						break;
					}
				}
				num2 += 4;
				if (flag2 && ptr8 + dictSize < lowPrefix)
				{
					break;
				}
				if (dict == dict_directive.usingExtDict && ptr8 < lowPrefix)
				{
					if (ptr3 + num2 > ptr4 - 5)
					{
						if (!partialDecoding)
						{
							break;
						}
						num2 = LL.MIN(num2, (uint)(ptr4 - ptr3));
					}
					if (num2 <= (uint)(lowPrefix - ptr8))
					{
						Mem.Move(ptr3, ptr5 - (lowPrefix - ptr8), (int)num2);
						ptr3 += num2;
						continue;
					}
					uint num4 = (uint)(lowPrefix - ptr8);
					uint num5 = num2 - num4;
					Mem.Copy(ptr3, ptr5 - num4, (int)num4);
					ptr3 += num4;
					if (num5 > (uint)(ptr3 - lowPrefix))
					{
						byte* ptr10 = ptr3 + num5;
						byte* ptr11 = lowPrefix;
						while (ptr3 < ptr10)
						{
							*(ptr3++) = *(ptr11++);
						}
					}
					else
					{
						Mem.Copy(ptr3, lowPrefix, (int)num5);
						ptr3 += num5;
					}
					continue;
				}
				ptr9 = ptr3 + num2;
				if (partialDecoding && ptr9 > ptr4 - 12)
				{
					uint num6 = LL.MIN(num2, (uint)(ptr4 - ptr3));
					byte* num7 = ptr8 + num6;
					byte* ptr12 = ptr3 + num6;
					if (num7 > ptr3)
					{
						while (ptr3 < ptr12)
						{
							*(ptr3++) = *(ptr8++);
						}
					}
					else
					{
						Mem.Copy(ptr3, ptr8, (int)num6);
					}
					ptr3 = ptr12;
					if (ptr3 != ptr4)
					{
						continue;
					}
					goto IL_04a7;
				}
				if (num3 < 8)
				{
					*ptr3 = *ptr8;
					ptr3[1] = ptr8[1];
					ptr3[2] = ptr8[2];
					ptr3[3] = ptr8[3];
					ptr8 += LL.inc32table[num3];
					Mem.Copy4(ptr3 + 4, ptr8);
					ptr8 -= LL.dec64table[num3];
				}
				else
				{
					Mem.Copy8(ptr3, ptr8);
					ptr8 += 8;
				}
				ptr3 += 8;
				if (ptr9 > ptr4 - 12)
				{
					byte* ptr13 = ptr4 - 7;
					if (ptr9 > ptr4 - 5)
					{
						break;
					}
					if (ptr3 < ptr13)
					{
						Mem32.WildCopy8(ptr3, ptr8, ptr13);
						ptr8 += ptr13 - ptr3;
						ptr3 = ptr13;
					}
					while (ptr3 < ptr9)
					{
						*(ptr3++) = *(ptr8++);
					}
				}
				else
				{
					Mem.Copy8(ptr3, ptr8);
					if (num2 > 16)
					{
						Mem32.WildCopy8(ptr3 + 8, ptr8 + 8, ptr9);
					}
				}
				ptr3 = ptr9;
				continue;
				IL_04a7:
				if (endOnInput)
				{
					return (int)(ptr3 - dst);
				}
				return (int)(ptr - src);
			}
			return (int)(-(ptr - src)) - 1;
		}

		public unsafe static int LZ4_decompress_safe(byte* source, byte* dest, int compressedSize, int maxDecompressedSize)
		{
			return LZ4_decompress_generic(source, dest, compressedSize, maxDecompressedSize, endCondition_directive.endOnInputSize, earlyEnd_directive.full, dict_directive.noDict, dest, null, 0u);
		}

		public unsafe static int LZ4_decompress_safe_withPrefix64k(byte* source, byte* dest, int compressedSize, int maxOutputSize)
		{
			return LZ4_decompress_generic(source, dest, compressedSize, maxOutputSize, endCondition_directive.endOnInputSize, earlyEnd_directive.full, dict_directive.withPrefix64k, dest - 65536, null, 0u);
		}

		public unsafe static int LZ4_decompress_safe_withSmallPrefix(byte* source, byte* dest, int compressedSize, int maxOutputSize, uint prefixSize)
		{
			return LZ4_decompress_generic(source, dest, compressedSize, maxOutputSize, endCondition_directive.endOnInputSize, earlyEnd_directive.full, dict_directive.noDict, dest - prefixSize, null, 0u);
		}

		public unsafe static int LZ4_decompress_safe_doubleDict(byte* source, byte* dest, int compressedSize, int maxOutputSize, uint prefixSize, void* dictStart, uint dictSize)
		{
			return LZ4_decompress_generic(source, dest, compressedSize, maxOutputSize, endCondition_directive.endOnInputSize, earlyEnd_directive.full, dict_directive.usingExtDict, dest - prefixSize, (byte*)dictStart, dictSize);
		}

		public unsafe static int LZ4_decompress_safe_forceExtDict(byte* source, byte* dest, int compressedSize, int maxOutputSize, void* dictStart, uint dictSize)
		{
			return LZ4_decompress_generic(source, dest, compressedSize, maxOutputSize, endCondition_directive.endOnInputSize, earlyEnd_directive.full, dict_directive.usingExtDict, dest, (byte*)dictStart, dictSize);
		}

		public unsafe static int LZ4_decompress_safe_usingDict(byte* source, byte* dest, int compressedSize, int maxOutputSize, byte* dictStart, int dictSize)
		{
			if (dictSize == 0)
			{
				return LZ4_decompress_safe(source, dest, compressedSize, maxOutputSize);
			}
			if (dictStart + dictSize == dest)
			{
				if (dictSize >= 65535)
				{
					return LZ4_decompress_safe_withPrefix64k(source, dest, compressedSize, maxOutputSize);
				}
				return LZ4_decompress_safe_withSmallPrefix(source, dest, compressedSize, maxOutputSize, (uint)dictSize);
			}
			return LZ4_decompress_safe_forceExtDict(source, dest, compressedSize, maxOutputSize, dictStart, (uint)dictSize);
		}

		public unsafe static int LZ4_decompress_safe_partial(byte* src, byte* dst, int compressedSize, int targetOutputSize, int dstCapacity)
		{
			uint outputSize = LL.MIN((uint)targetOutputSize, (uint)dstCapacity);
			return LZ4_decompress_generic(src, dst, compressedSize, (int)outputSize, endCondition_directive.endOnInputSize, earlyEnd_directive.partial, dict_directive.noDict, dst, null, 0u);
		}

		public unsafe static int LZ4_decompress_safe_continue(LZ4_streamDecode_t* LZ4_streamDecode, byte* source, byte* dest, int compressedSize, int maxOutputSize)
		{
			int num;
			if (LZ4_streamDecode->prefixSize == 0)
			{
				num = LZ4_decompress_safe(source, dest, compressedSize, maxOutputSize);
				if (num <= 0)
				{
					return num;
				}
				LZ4_streamDecode->prefixSize = (uint)num;
				LZ4_streamDecode->prefixEnd = dest + num;
			}
			else if (LZ4_streamDecode->prefixEnd == dest)
			{
				num = ((LZ4_streamDecode->prefixSize >= 65535) ? LZ4_decompress_safe_withPrefix64k(source, dest, compressedSize, maxOutputSize) : ((LZ4_streamDecode->extDictSize != 0) ? LZ4_decompress_safe_doubleDict(source, dest, compressedSize, maxOutputSize, LZ4_streamDecode->prefixSize, LZ4_streamDecode->externalDict, LZ4_streamDecode->extDictSize) : LZ4_decompress_safe_withSmallPrefix(source, dest, compressedSize, maxOutputSize, LZ4_streamDecode->prefixSize)));
				if (num <= 0)
				{
					return num;
				}
				LZ4_streamDecode->prefixSize += (uint)num;
				LZ4_streamDecode->prefixEnd += num;
			}
			else
			{
				LZ4_streamDecode->extDictSize = LZ4_streamDecode->prefixSize;
				LZ4_streamDecode->externalDict = LZ4_streamDecode->prefixEnd - LZ4_streamDecode->extDictSize;
				num = LZ4_decompress_safe_forceExtDict(source, dest, compressedSize, maxOutputSize, LZ4_streamDecode->externalDict, LZ4_streamDecode->extDictSize);
				if (num <= 0)
				{
					return num;
				}
				LZ4_streamDecode->prefixSize = (uint)num;
				LZ4_streamDecode->prefixEnd = dest + num;
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static int LZ4_compress_generic(LZ4_stream_t* cctx, byte* source, byte* dest, int inputSize, int* inputConsumed, int maxOutputSize, limitedOutput_directive outputDirective, tableType_t tableType, dict_directive dictDirective, dictIssue_directive dictIssue, int acceleration)
		{
			byte* ptr = source;
			uint currentOffset = cctx->currentOffset;
			byte* ptr2 = source - currentOffset;
			LZ4_stream_t* dictCtx = cctx->dictCtx;
			byte* ptr3 = ((dictDirective == dict_directive.usingDictCtx) ? dictCtx->dictionary : cctx->dictionary);
			uint num = ((dictDirective == dict_directive.usingDictCtx) ? dictCtx->dictSize : cctx->dictSize);
			uint num2 = ((dictDirective == dict_directive.usingDictCtx) ? (currentOffset - dictCtx->currentOffset) : 0u);
			bool flag = dictDirective == dict_directive.usingExtDict || dictDirective == dict_directive.usingDictCtx;
			uint num3 = currentOffset - num;
			byte* ptr4 = ptr3 + num;
			byte* ptr5 = source;
			byte* ptr6 = ptr + inputSize;
			byte* ptr7 = ptr6 - 12 + 1;
			byte* ptr8 = ptr6 - 5;
			byte* ptr9 = ((dictDirective == dict_directive.usingDictCtx) ? (ptr3 + num - dictCtx->currentOffset) : (ptr3 + num - currentOffset));
			byte* ptr10 = dest;
			byte* ptr11 = ptr10 + maxOutputSize;
			uint num4 = 0u;
			if (outputDirective == limitedOutput_directive.fillOutput && maxOutputSize < 1)
			{
				return 0;
			}
			if ((uint)inputSize > 2113929216u)
			{
				return 0;
			}
			if (tableType == tableType_t.byU16 && inputSize >= 65547)
			{
				return 0;
			}
			_ = 1;
			byte* ptr12 = source - ((dictDirective == dict_directive.withPrefix64k) ? num : 0);
			if (dictDirective == dict_directive.usingDictCtx)
			{
				cctx->dictCtx = null;
				cctx->dictSize = (uint)inputSize;
			}
			else
			{
				cctx->dictSize += (uint)inputSize;
			}
			cctx->currentOffset += (uint)inputSize;
			cctx->tableType = tableType;
			if (inputSize >= 13)
			{
				LZ4_putPosition(ptr, cctx->hashTable, tableType, ptr2);
				ptr++;
				uint num5 = LZ4_hashPosition(ptr, tableType);
				while (true)
				{
					byte* ptr14;
					if (tableType == tableType_t.byPtr)
					{
						byte* ptr13 = ptr;
						int num6 = 1;
						int num7 = acceleration << 6;
						while (true)
						{
							uint h = num5;
							ptr = ptr13;
							ptr13 += num6;
							num6 = num7++ >> 6;
							if (ptr13 > ptr7)
							{
								break;
							}
							ptr14 = LL.LZ4_getPositionOnHash(h, cctx->hashTable, tableType, ptr2);
							num5 = LZ4_hashPosition(ptr13, tableType);
							LL.LZ4_putPositionOnHash(ptr, h, cctx->hashTable, tableType, ptr2);
							if (ptr14 + 65535 < ptr || Mem.Peek4(ptr14) != Mem.Peek4(ptr))
							{
								continue;
							}
							goto IL_02f6;
						}
						break;
					}
					byte* ptr15 = ptr;
					int num8 = 1;
					int num9 = acceleration << 6;
					uint num10;
					uint num11;
					while (true)
					{
						uint h2 = num5;
						num10 = (uint)(ptr15 - ptr2);
						num11 = LL.LZ4_getIndexOnHash(h2, cctx->hashTable, tableType);
						ptr = ptr15;
						ptr15 += num8;
						num8 = num9++ >> 6;
						if (ptr15 > ptr7)
						{
							break;
						}
						switch (dictDirective)
						{
						case dict_directive.usingDictCtx:
							if (num11 < currentOffset)
							{
								num11 = LL.LZ4_getIndexOnHash(h2, dictCtx->hashTable, tableType_t.byU32);
								ptr14 = ptr9 + num11;
								num11 += num2;
								ptr12 = ptr3;
							}
							else
							{
								ptr14 = ptr2 + num11;
								ptr12 = source;
							}
							break;
						case dict_directive.usingExtDict:
							if (num11 < currentOffset)
							{
								ptr14 = ptr9 + num11;
								ptr12 = ptr3;
							}
							else
							{
								ptr14 = ptr2 + num11;
								ptr12 = source;
							}
							break;
						default:
							ptr14 = ptr2 + num11;
							break;
						}
						num5 = LZ4_hashPosition(ptr15, tableType);
						LL.LZ4_putIndexOnHash(num10, h2, cctx->hashTable, tableType);
						if ((dictIssue == dictIssue_directive.dictSmall && num11 < num3) || (tableType != tableType_t.byU16 && num11 + 65535 < num10) || Mem.Peek4(ptr14) != Mem.Peek4(ptr))
						{
							continue;
						}
						goto IL_02eb;
					}
					break;
					IL_02f6:
					byte* ptr16 = ptr;
					while (ptr > ptr5 && ptr14 > ptr12 && ptr[-1] == ptr14[-1])
					{
						ptr--;
						ptr14--;
					}
					uint num12 = (uint)(ptr - ptr5);
					byte* ptr17 = ptr10++;
					if (outputDirective == limitedOutput_directive.limitedOutput && ptr10 + num12 + 8 + num12 / 255 > ptr11)
					{
						return 0;
					}
					if (outputDirective == limitedOutput_directive.fillOutput && ptr10 + (num12 + 240) / 255 + num12 + 2 + 1 + 12 - 4 > ptr11)
					{
						ptr10--;
						break;
					}
					if (num12 >= 15)
					{
						int num13 = (int)(num12 - 15);
						*ptr17 = 240;
						while (num13 >= 255)
						{
							*(ptr10++) = byte.MaxValue;
							num13 -= 255;
						}
						*(ptr10++) = (byte)num13;
					}
					else
					{
						*ptr17 = (byte)(num12 << 4);
					}
					Mem32.WildCopy8(ptr10, ptr5, ptr10 + num12);
					ptr10 += num12;
					while (true)
					{
						if (outputDirective == limitedOutput_directive.fillOutput && ptr10 + 2 + 1 + 12 - 4 > ptr11)
						{
							ptr10 = ptr17;
							break;
						}
						if (flag)
						{
							Mem.Poke2(ptr10, (ushort)num4);
							ptr10 += 2;
						}
						else
						{
							Mem.Poke2(ptr10, (ushort)(ptr - ptr14));
							ptr10 += 2;
						}
						uint num14;
						if ((dictDirective == dict_directive.usingExtDict || dictDirective == dict_directive.usingDictCtx) && ptr12 == ptr3)
						{
							byte* ptr18 = ptr + (ptr4 - ptr14);
							if (ptr18 > ptr8)
							{
								ptr18 = ptr8;
							}
							num14 = LZ4_count(ptr + 4, ptr14 + 4, ptr18);
							ptr += num14 + 4;
							if (ptr == ptr18)
							{
								uint num15 = LZ4_count(ptr18, source, ptr8);
								num14 += num15;
								ptr += num15;
							}
						}
						else
						{
							num14 = LZ4_count(ptr + 4, ptr14 + 4, ptr8);
							ptr += num14 + 4;
						}
						if (outputDirective != limitedOutput_directive.notLimited && ptr10 + 6 + (num14 + 240) / 255 > ptr11)
						{
							if (outputDirective != limitedOutput_directive.fillOutput)
							{
								return 0;
							}
							uint num16 = (uint)(14 + ((int)(ptr11 - ptr10) - 1 - 5) * 255);
							ptr -= num14 - num16;
							num14 = num16;
							if (ptr <= ptr16)
							{
								for (byte* ptr19 = ptr; ptr19 <= ptr16; ptr19++)
								{
									LL.LZ4_clearHash(LZ4_hashPosition(ptr19, tableType), cctx->hashTable, tableType);
								}
							}
						}
						if (num14 >= 15)
						{
							byte* intPtr = ptr17;
							*intPtr += 15;
							num14 -= 15;
							Mem.Poke4(ptr10, uint.MaxValue);
							while (num14 >= 1020)
							{
								ptr10 += 4;
								Mem.Poke4(ptr10, uint.MaxValue);
								num14 -= 1020;
							}
							ptr10 += num14 / 255;
							*(ptr10++) = (byte)(num14 % 255);
						}
						else
						{
							byte* intPtr2 = ptr17;
							*intPtr2 += (byte)num14;
						}
						ptr5 = ptr;
						if (ptr >= ptr7)
						{
							break;
						}
						LZ4_putPosition(ptr - 2, cctx->hashTable, tableType, ptr2);
						if (tableType == tableType_t.byPtr)
						{
							ptr14 = LZ4_getPosition(ptr, cctx->hashTable, tableType, ptr2);
							LZ4_putPosition(ptr, cctx->hashTable, tableType, ptr2);
							if (ptr14 + 65535 >= ptr && Mem.Peek4(ptr14) == Mem.Peek4(ptr))
							{
								ptr17 = ptr10++;
								*ptr17 = 0;
								continue;
							}
						}
						else
						{
							uint h3 = LZ4_hashPosition(ptr, tableType);
							uint num17 = (uint)(ptr - ptr2);
							uint num18 = LL.LZ4_getIndexOnHash(h3, cctx->hashTable, tableType);
							switch (dictDirective)
							{
							case dict_directive.usingDictCtx:
								if (num18 < currentOffset)
								{
									num18 = LL.LZ4_getIndexOnHash(h3, dictCtx->hashTable, tableType_t.byU32);
									ptr14 = ptr9 + num18;
									ptr12 = ptr3;
									num18 += num2;
								}
								else
								{
									ptr14 = ptr2 + num18;
									ptr12 = source;
								}
								break;
							case dict_directive.usingExtDict:
								if (num18 < currentOffset)
								{
									ptr14 = ptr9 + num18;
									ptr12 = ptr3;
								}
								else
								{
									ptr14 = ptr2 + num18;
									ptr12 = source;
								}
								break;
							default:
								ptr14 = ptr2 + num18;
								break;
							}
							LL.LZ4_putIndexOnHash(num17, h3, cctx->hashTable, tableType);
							if ((dictIssue != dictIssue_directive.dictSmall || num18 >= num3) && (tableType == tableType_t.byU16 || num18 + 65535 >= num17) && Mem.Peek4(ptr14) == Mem.Peek4(ptr))
							{
								ptr17 = ptr10++;
								*ptr17 = 0;
								if (flag)
								{
									num4 = num17 - num18;
								}
								continue;
							}
						}
						goto IL_0703;
					}
					break;
					IL_0703:
					num5 = LZ4_hashPosition(++ptr, tableType);
					continue;
					IL_02eb:
					if (flag)
					{
						num4 = num10 - num11;
					}
					goto IL_02f6;
				}
			}
			uint num19 = (uint)(ptr6 - ptr5);
			if (outputDirective != limitedOutput_directive.notLimited && ptr10 + num19 + 1 + (num19 + 255 - 15) / 255 > ptr11)
			{
				if (outputDirective != limitedOutput_directive.fillOutput)
				{
					return 0;
				}
				num19 = (uint)((int)(ptr11 - ptr10) - 1);
				num19 -= (num19 + 240) / 255;
			}
			if (num19 >= 15)
			{
				uint num20 = num19 - 15;
				*(ptr10++) = 240;
				while (num20 >= 255)
				{
					*(ptr10++) = byte.MaxValue;
					num20 -= 255;
				}
				*(ptr10++) = (byte)num20;
			}
			else
			{
				*(ptr10++) = (byte)(num19 << 4);
			}
			Mem.Copy(ptr10, ptr5, (int)num19);
			ptr = ptr5 + num19;
			ptr10 += num19;
			if (outputDirective == limitedOutput_directive.fillOutput)
			{
				*inputConsumed = (int)(ptr - source);
			}
			return (int)(ptr10 - dest);
		}

		public unsafe static int LZ4_compress_fast_extState(LZ4_stream_t* state, byte* source, byte* dest, int inputSize, int maxOutputSize, int acceleration)
		{
			LZ4_stream_t* cctx = LL.LZ4_initStream(state);
			if (acceleration < 1)
			{
				acceleration = 1;
			}
			if (maxOutputSize >= LL.LZ4_compressBound(inputSize))
			{
				if (inputSize < 65547)
				{
					return LZ4_compress_generic(cctx, source, dest, inputSize, null, 0, limitedOutput_directive.notLimited, tableType_t.byU16, dict_directive.noDict, dictIssue_directive.noDictIssue, acceleration);
				}
				tableType_t tableType = ((sizeof(void*) < 8 && (nuint)source > (nuint)65535u) ? tableType_t.byPtr : tableType_t.byU32);
				return LZ4_compress_generic(cctx, source, dest, inputSize, null, 0, limitedOutput_directive.notLimited, tableType, dict_directive.noDict, dictIssue_directive.noDictIssue, acceleration);
			}
			if (inputSize < 65547)
			{
				return LZ4_compress_generic(cctx, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType_t.byU16, dict_directive.noDict, dictIssue_directive.noDictIssue, acceleration);
			}
			tableType_t tableType2 = ((sizeof(void*) < 8 && (nuint)source > (nuint)65535u) ? tableType_t.byPtr : tableType_t.byU32);
			return LZ4_compress_generic(cctx, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType2, dict_directive.noDict, dictIssue_directive.noDictIssue, acceleration);
		}

		public unsafe static int LZ4_compress_fast(byte* source, byte* dest, int inputSize, int maxOutputSize, int acceleration)
		{
			LZ4_stream_t lZ4_stream_t = default(LZ4_stream_t);
			return LZ4_compress_fast_extState(&lZ4_stream_t, source, dest, inputSize, maxOutputSize, acceleration);
		}

		public unsafe static int LZ4_compress_default(byte* src, byte* dst, int srcSize, int maxOutputSize)
		{
			return LZ4_compress_fast(src, dst, srcSize, maxOutputSize, 1);
		}

		public unsafe static int LZ4_compress_fast_continue(LZ4_stream_t* LZ4_stream, byte* source, byte* dest, int inputSize, int maxOutputSize, int acceleration)
		{
			byte* ptr = LZ4_stream->dictionary + LZ4_stream->dictSize;
			if (LZ4_stream->dirty)
			{
				return 0;
			}
			LZ4_renormDictT(LZ4_stream, inputSize);
			if (acceleration < 1)
			{
				acceleration = 1;
			}
			if (LZ4_stream->dictSize - 1 < 3 && ptr != source)
			{
				LZ4_stream->dictSize = 0u;
				LZ4_stream->dictionary = source;
				ptr = source;
			}
			byte* ptr2 = source + inputSize;
			if (ptr2 > LZ4_stream->dictionary && ptr2 < ptr)
			{
				LZ4_stream->dictSize = (uint)(ptr - ptr2);
				if (LZ4_stream->dictSize > 65536)
				{
					LZ4_stream->dictSize = 65536u;
				}
				if (LZ4_stream->dictSize < 4)
				{
					LZ4_stream->dictSize = 0u;
				}
				LZ4_stream->dictionary = ptr - LZ4_stream->dictSize;
			}
			if (ptr == source)
			{
				if (LZ4_stream->dictSize < 65536 && LZ4_stream->dictSize < LZ4_stream->currentOffset)
				{
					return LZ4_compress_generic(LZ4_stream, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType_t.byU32, dict_directive.withPrefix64k, dictIssue_directive.dictSmall, acceleration);
				}
				return LZ4_compress_generic(LZ4_stream, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType_t.byU32, dict_directive.withPrefix64k, dictIssue_directive.noDictIssue, acceleration);
			}
			int result;
			if (LZ4_stream->dictCtx == null)
			{
				result = ((LZ4_stream->dictSize >= 65536 || LZ4_stream->dictSize >= LZ4_stream->currentOffset) ? LZ4_compress_generic(LZ4_stream, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType_t.byU32, dict_directive.usingExtDict, dictIssue_directive.noDictIssue, acceleration) : LZ4_compress_generic(LZ4_stream, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType_t.byU32, dict_directive.usingExtDict, dictIssue_directive.dictSmall, acceleration));
			}
			else if (inputSize > 4096)
			{
				Mem.Copy((byte*)LZ4_stream, (byte*)LZ4_stream->dictCtx, sizeof(LZ4_stream_t));
				result = LZ4_compress_generic(LZ4_stream, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType_t.byU32, dict_directive.usingExtDict, dictIssue_directive.noDictIssue, acceleration);
			}
			else
			{
				result = LZ4_compress_generic(LZ4_stream, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType_t.byU32, dict_directive.usingDictCtx, dictIssue_directive.noDictIssue, acceleration);
			}
			LZ4_stream->dictionary = source;
			LZ4_stream->dictSize = (uint)inputSize;
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint LZ4HC_countPattern(byte* ip, byte* iEnd, uint pattern32)
		{
			byte* ptr = ip;
			while (ip < iEnd - 3)
			{
				uint num = Mem32.PeekW(ip) ^ pattern32;
				if (num == 0)
				{
					ip += 4;
					continue;
				}
				ip += LZ4_NbCommonBytes(num);
				return (uint)(ip - ptr);
			}
			uint num2 = pattern32;
			while (ip < iEnd && *ip == (byte)num2)
			{
				ip++;
				num2 >>= 8;
			}
			return (uint)(ip - ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_InsertAndGetWiderMatch(LZ4_streamHC_t* hc4, byte* ip, byte* iLowLimit, byte* iHighLimit, int longest, byte** matchpos, byte** startpos, int maxNbAttempts, bool patternAnalysis, bool chainSwap, dictCtx_directive dict, HCfavor_e favorDecSpeed)
		{
			ushort* table = hc4->chainTable;
			uint* num = hc4->hashTable;
			LZ4_streamHC_t* dictCtx = hc4->dictCtx;
			byte* ptr = hc4->@base;
			uint dictLimit = hc4->dictLimit;
			byte* ptr2 = ptr + dictLimit;
			uint num2 = (uint)(ip - ptr);
			uint num3 = ((hc4->lowLimit + 65536 > num2) ? hc4->lowLimit : (num2 - 65535));
			byte* dictBase = hc4->dictBase;
			int num4 = (int)(ip - iLowLimit);
			int num5 = maxNbAttempts;
			uint num6 = 0u;
			uint num7 = Mem.Peek4(ip);
			repeat_state_e repeat_state_e = repeat_state_e.rep_untested;
			uint num8 = 0u;
			LL.LZ4HC_Insert(hc4, ip);
			uint num9 = num[LL.LZ4HC_hashPtr(ip)];
			while (num9 >= num3 && num5 != 0)
			{
				int num10 = 0;
				num5--;
				if (favorDecSpeed == HCfavor_e.favorCompressionRatio || num2 - num9 >= 8)
				{
					if (num9 >= dictLimit)
					{
						byte* ptr3 = ptr + num9;
						if (Mem.Peek2(iLowLimit + longest - 1) == Mem.Peek2(ptr3 - num4 + longest - 1) && Mem.Peek4(ptr3) == num7)
						{
							int num11 = ((num4 != 0) ? LL.LZ4HC_countBack(ip, ptr3, iLowLimit, ptr2) : 0);
							num10 = (int)(4 + LZ4_count(ip + 4, ptr3 + 4, iHighLimit));
							num10 -= num11;
							if (num10 > longest)
							{
								longest = num10;
								*matchpos = ptr3 + num11;
								*startpos = ip + num11;
							}
						}
					}
					else
					{
						byte* ptr4 = dictBase + num9;
						if (Mem.Peek4(ptr4) == num7)
						{
							byte* mMin = dictBase + hc4->lowLimit;
							int num12 = 0;
							byte* ptr5 = ip + (dictLimit - num9);
							if (ptr5 > iHighLimit)
							{
								ptr5 = iHighLimit;
							}
							num10 = (int)(LZ4_count(ip + 4, ptr4 + 4, ptr5) + 4);
							if (ip + num10 == ptr5 && ptr5 < iHighLimit)
							{
								num10 += (int)LZ4_count(ip + num10, ptr2, iHighLimit);
							}
							num12 = ((num4 != 0) ? LL.LZ4HC_countBack(ip, ptr4, iLowLimit, mMin) : 0);
							num10 -= num12;
							if (num10 > longest)
							{
								longest = num10;
								*matchpos = ptr + num9 + num12;
								*startpos = ip + num12;
							}
						}
					}
				}
				if (chainSwap && num10 == longest && (uint)((int)num9 + longest) <= num2)
				{
					int num13 = 4;
					uint num14 = 1u;
					int num15 = longest - 4 + 1;
					int num16 = 1;
					int num17 = 1 << num13;
					for (int i = 0; i < num15; i += num16)
					{
						uint num18 = LL.DELTANEXTU16(table, num9 + (uint)i);
						num16 = num17++ >> num13;
						if (num18 > num14)
						{
							num14 = num18;
							num6 = (uint)i;
							num17 = 1 << num13;
						}
					}
					if (num14 > 1)
					{
						if (num14 > num9)
						{
							break;
						}
						num9 -= num14;
						continue;
					}
				}
				uint num19 = LL.DELTANEXTU16(table, num9);
				if (patternAnalysis && num19 == 1 && num6 == 0)
				{
					uint num20 = num9 - 1;
					if (repeat_state_e == repeat_state_e.rep_untested)
					{
						if ((num7 & 0xFFFF) == num7 >> 16 && (num7 & 0xFF) == num7 >> 24)
						{
							repeat_state_e = repeat_state_e.rep_confirmed;
							num8 = LZ4HC_countPattern(ip + 4, iHighLimit, num7) + 4;
						}
						else
						{
							repeat_state_e = repeat_state_e.rep_not;
						}
					}
					if (repeat_state_e == repeat_state_e.rep_confirmed && num20 >= num3 && LL.LZ4HC_protectDictEnd(dictLimit, num20))
					{
						bool flag = num20 < dictLimit;
						byte* ptr6 = (flag ? dictBase : ptr) + num20;
						if (Mem.Peek4(ptr6) == num7)
						{
							byte* ptr7 = dictBase + hc4->lowLimit;
							byte* ptr8 = (flag ? (dictBase + dictLimit) : iHighLimit);
							uint num21 = LZ4HC_countPattern(ptr6 + 4, ptr8, num7) + 4;
							if (flag && ptr6 + num21 == ptr8)
							{
								uint pattern = LL.LZ4HC_rotatePattern(num21, num7);
								num21 += LZ4HC_countPattern(ptr2, iHighLimit, pattern);
							}
							byte* iLow = (flag ? ptr7 : ptr2);
							uint num22 = LL.LZ4HC_reverseCountPattern(ptr6, iLow, num7);
							if (!flag && ptr6 - num22 == ptr2 && hc4->lowLimit < dictLimit)
							{
								uint pattern2 = LL.LZ4HC_rotatePattern(0 - num22, num7);
								num22 += LL.LZ4HC_reverseCountPattern(dictBase + dictLimit, ptr7, pattern2);
							}
							num22 = num20 - LL.MAX(num20 - num22, num3);
							uint num23 = num22 + num21;
							if (num23 >= num8 && num21 <= num8)
							{
								uint num24 = num20 + num21 - num8;
								num9 = ((!LL.LZ4HC_protectDictEnd(dictLimit, num24)) ? dictLimit : num24);
								continue;
							}
							uint num25 = num20 - num22;
							if (!LL.LZ4HC_protectDictEnd(dictLimit, num25))
							{
								num9 = dictLimit;
								continue;
							}
							num9 = num25;
							if (num4 != 0)
							{
								continue;
							}
							uint num26 = LL.MIN(num23, num8);
							if ((uint)longest < num26)
							{
								if ((uint)((int)(ip - ptr) - (int)num9) > 65535u)
								{
									break;
								}
								longest = (int)num26;
								*matchpos = ptr + num9;
								*startpos = ip;
							}
							uint num27 = LL.DELTANEXTU16(table, num9);
							if (num27 > num9)
							{
								break;
							}
							num9 -= num27;
							continue;
						}
					}
				}
				num9 -= LL.DELTANEXTU16(table, num9 + num6);
			}
			if (dict == dictCtx_directive.usingDictCtxHc && num5 != 0 && num2 - num3 < 65535)
			{
				uint num28 = (uint)(dictCtx->end - dictCtx->@base);
				uint num29 = dictCtx->hashTable[LL.LZ4HC_hashPtr(ip)];
				num9 = num29 + num3 - num28;
				while (num2 - num9 <= 65535 && num5-- != 0)
				{
					byte* ptr9 = dictCtx->@base + num29;
					if (Mem.Peek4(ptr9) == num7)
					{
						int num30 = 0;
						byte* ptr10 = ip + (num28 - num29);
						if (ptr10 > iHighLimit)
						{
							ptr10 = iHighLimit;
						}
						int num31 = (int)(LZ4_count(ip + 4, ptr9 + 4, ptr10) + 4);
						num30 = ((num4 != 0) ? LL.LZ4HC_countBack(ip, ptr9, iLowLimit, dictCtx->@base + dictCtx->dictLimit) : 0);
						num31 -= num30;
						if (num31 > longest)
						{
							longest = num31;
							*matchpos = ptr + num9 + num30;
							*startpos = ip + num30;
						}
					}
					uint num32 = LL.DELTANEXTU16(dictCtx->chainTable, num29);
					num29 -= num32;
					num9 -= num32;
				}
			}
			return longest;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_InsertAndFindBestMatch(LZ4_streamHC_t* hc4, byte* ip, byte* iLimit, byte** matchpos, int maxNbAttempts, bool patternAnalysis, dictCtx_directive dict)
		{
			byte* ptr = ip;
			return LZ4HC_InsertAndGetWiderMatch(hc4, ip, ip, iLimit, 3, matchpos, &ptr, maxNbAttempts, patternAnalysis, chainSwap: false, dict, HCfavor_e.favorCompressionRatio);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static LZ4HC_match_t LZ4HC_FindLongerMatch(LZ4_streamHC_t* ctx, byte* ip, byte* iHighLimit, int minLen, int nbSearches, dictCtx_directive dict, HCfavor_e favorDecSpeed)
		{
			LZ4HC_match_t result = default(LZ4HC_match_t);
			result.len = 0;
			result.off = 0;
			byte* ptr = null;
			int num = LZ4HC_InsertAndGetWiderMatch(ctx, ip, ip, iHighLimit, minLen, &ptr, &ip, nbSearches, patternAnalysis: true, chainSwap: true, dict, favorDecSpeed);
			if (num <= minLen)
			{
				return result;
			}
			if (favorDecSpeed != HCfavor_e.favorCompressionRatio && num > 18 && num <= 36)
			{
				num = 18;
			}
			result.len = num;
			result.off = (int)(ip - ptr);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_encodeSequence(byte** ip, byte** op, byte** anchor, int matchLength, byte* match, limitedOutput_directive limit, byte* oend)
		{
			byte* ptr = (*op)++;
			uint num = (uint)(*ip - *anchor);
			if (limit != limitedOutput_directive.notLimited && *op + num / 255 + num + 8 > oend)
			{
				return 1;
			}
			if (num >= 15)
			{
				uint num2 = num - 15;
				*ptr = 240;
				while (num2 >= 255)
				{
					*((*op)++) = byte.MaxValue;
					num2 -= 255;
				}
				*((*op)++) = (byte)num2;
			}
			else
			{
				*ptr = (byte)(num << 4);
			}
			Mem32.WildCopy8(*op, *anchor, *op + num);
			*op += num;
			Mem.Poke2(*op, (ushort)(*ip - match));
			*op += 2;
			num = (uint)(matchLength - 4);
			if (limit != limitedOutput_directive.notLimited && *op + num / 255 + 6 > oend)
			{
				return 1;
			}
			if (num >= 15)
			{
				*ptr += 15;
				for (num -= 15; num >= 510; num -= 510)
				{
					*((*op)++) = byte.MaxValue;
					*((*op)++) = byte.MaxValue;
				}
				if (num >= 255)
				{
					num -= 255;
					*((*op)++) = byte.MaxValue;
				}
				*((*op)++) = (byte)num;
			}
			else
			{
				*ptr += (byte)num;
			}
			*ip += matchLength;
			*anchor = *ip;
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_compress_hashChain(LZ4_streamHC_t* ctx, byte* source, byte* dest, int* srcSizePtr, int maxOutputSize, int maxNbAttempts, limitedOutput_directive limit, dictCtx_directive dict)
		{
			int num = *srcSizePtr;
			bool patternAnalysis = maxNbAttempts > 128;
			byte* ptr = source;
			byte* ptr2 = ptr;
			byte* ptr3 = ptr + num;
			byte* ptr4 = ptr3 - 12;
			byte* ptr5 = ptr3 - 5;
			byte* ptr6 = dest;
			byte* ptr7 = dest;
			byte* ptr8 = ptr7 + maxOutputSize;
			byte* ptr9 = null;
			byte* ptr10 = null;
			byte* ptr11 = null;
			byte* ptr12 = null;
			byte* ptr13 = null;
			*srcSizePtr = 0;
			if (limit == limitedOutput_directive.fillOutput)
			{
				ptr8 -= 5;
			}
			if (num >= 13)
			{
				while (ptr <= ptr4)
				{
					int num2 = LZ4HC_InsertAndFindBestMatch(ctx, ptr, ptr5, &ptr9, maxNbAttempts, patternAnalysis, dict);
					if (num2 < 4)
					{
						ptr++;
						continue;
					}
					byte* ptr14 = ptr;
					byte* ptr15 = ptr9;
					int num3 = num2;
					while (true)
					{
						int num4 = ((ptr + num2 > ptr4) ? num2 : LZ4HC_InsertAndGetWiderMatch(ctx, ptr + num2 - 2, ptr, ptr5, num2, &ptr11, &ptr10, maxNbAttempts, patternAnalysis, chainSwap: false, dict, HCfavor_e.favorCompressionRatio));
						int num7;
						if (num4 == num2)
						{
							ptr6 = ptr7;
							if (LZ4HC_encodeSequence(&ptr, &ptr7, &ptr2, num2, ptr9, limit, ptr8) == 0)
							{
								break;
							}
						}
						else
						{
							if (ptr14 < ptr && ptr10 < ptr + num3)
							{
								ptr = ptr14;
								ptr9 = ptr15;
								num2 = num3;
							}
							if (ptr10 - ptr < 3)
							{
								num2 = num4;
								ptr = ptr10;
								ptr9 = ptr11;
								continue;
							}
							while (true)
							{
								if (ptr10 - ptr < 18)
								{
									int num5 = num2;
									if (num5 > 18)
									{
										num5 = 18;
									}
									if (ptr + num5 > ptr10 + num4 - 4)
									{
										num5 = (int)(ptr10 - ptr) + num4 - 4;
									}
									int num6 = num5 - (int)(ptr10 - ptr);
									if (num6 > 0)
									{
										ptr10 += num6;
										ptr11 += num6;
										num4 -= num6;
									}
								}
								num7 = ((ptr10 + num4 > ptr4) ? num4 : LZ4HC_InsertAndGetWiderMatch(ctx, ptr10 + num4 - 3, ptr10, ptr5, num4, &ptr13, &ptr12, maxNbAttempts, patternAnalysis, chainSwap: false, dict, HCfavor_e.favorCompressionRatio));
								if (num7 == num4)
								{
									break;
								}
								if (ptr12 < ptr + num2 + 3)
								{
									if (ptr12 < ptr + num2)
									{
										ptr10 = ptr12;
										ptr11 = ptr13;
										num4 = num7;
										continue;
									}
									goto IL_0217;
								}
								if (ptr10 < ptr + num2)
								{
									if (ptr10 - ptr < 18)
									{
										if (num2 > 18)
										{
											num2 = 18;
										}
										if (ptr + num2 > ptr10 + num4 - 4)
										{
											num2 = (int)(ptr10 - ptr) + num4 - 4;
										}
										int num8 = num2 - (int)(ptr10 - ptr);
										if (num8 > 0)
										{
											ptr10 += num8;
											ptr11 += num8;
											num4 -= num8;
										}
									}
									else
									{
										num2 = (int)(ptr10 - ptr);
									}
								}
								ptr6 = ptr7;
								if (LZ4HC_encodeSequence(&ptr, &ptr7, &ptr2, num2, ptr9, limit, ptr8) == 0)
								{
									ptr = ptr10;
									ptr9 = ptr11;
									num2 = num4;
									ptr10 = ptr12;
									ptr11 = ptr13;
									num4 = num7;
									continue;
								}
								goto IL_043b;
							}
							if (ptr10 < ptr + num2)
							{
								num2 = (int)(ptr10 - ptr);
							}
							ptr6 = ptr7;
							if (LZ4HC_encodeSequence(&ptr, &ptr7, &ptr2, num2, ptr9, limit, ptr8) == 0)
							{
								ptr = ptr10;
								ptr6 = ptr7;
								if (LZ4HC_encodeSequence(&ptr, &ptr7, &ptr2, num4, ptr11, limit, ptr8) == 0)
								{
									break;
								}
							}
						}
						goto IL_043b;
						IL_043b:
						if (limit != limitedOutput_directive.fillOutput)
						{
							return 0;
						}
						goto IL_0440;
						IL_0217:
						if (ptr10 < ptr + num2)
						{
							int num9 = (int)(ptr + num2 - ptr10);
							ptr10 += num9;
							ptr11 += num9;
							num4 -= num9;
							if (num4 < 4)
							{
								ptr10 = ptr12;
								ptr11 = ptr13;
								num4 = num7;
							}
						}
						ptr6 = ptr7;
						if (LZ4HC_encodeSequence(&ptr, &ptr7, &ptr2, num2, ptr9, limit, ptr8) == 0)
						{
							ptr = ptr12;
							ptr9 = ptr13;
							num2 = num7;
							ptr14 = ptr10;
							ptr15 = ptr11;
							num3 = num4;
							continue;
						}
						goto IL_043b;
					}
					continue;
					IL_0440:
					ptr7 = ptr6;
					break;
				}
			}
			uint num10 = (uint)(ptr3 - ptr2);
			uint num11 = (num10 + 255 - 15) / 255;
			uint num12 = 1 + num11 + num10;
			if (limit == limitedOutput_directive.fillOutput)
			{
				ptr8 += 5;
			}
			if (limit != limitedOutput_directive.notLimited && ptr7 + num12 > ptr8)
			{
				if (limit == limitedOutput_directive.limitedOutput)
				{
					return 0;
				}
				num10 = (uint)((int)(ptr8 - ptr7) - 1);
				num11 = (num10 + 255 - 15) / 255;
				num10 -= num11;
			}
			ptr = ptr2 + num10;
			if (num10 >= 15)
			{
				uint num13 = num10 - 15;
				*(ptr7++) = 240;
				while (num13 >= 255)
				{
					*(ptr7++) = byte.MaxValue;
					num13 -= 255;
				}
				*(ptr7++) = (byte)num13;
			}
			else
			{
				*(ptr7++) = (byte)(num10 << 4);
			}
			Mem.Copy(ptr7, ptr2, (int)num10);
			ptr7 += num10;
			*srcSizePtr = (int)(ptr - source);
			return (int)(ptr7 - dest);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_compress_optimal(LZ4_streamHC_t* ctx, byte* source, byte* dst, int* srcSizePtr, int dstCapacity, int nbSearches, uint sufficient_len, limitedOutput_directive limit, bool fullUpdate, dictCtx_directive dict, HCfavor_e favorDecSpeed)
		{
			LZ4HC_optimal_t* ptr = stackalloc LZ4HC_optimal_t[4099];
			byte* ptr2 = source;
			byte* ptr3 = ptr2;
			byte* ptr4 = ptr2 + *srcSizePtr;
			byte* ptr5 = ptr4 - 12;
			byte* iHighLimit = ptr4 - 5;
			byte* ptr6 = dst;
			byte* ptr7 = dst;
			byte* ptr8 = ptr6 + dstCapacity;
			*srcSizePtr = 0;
			if (limit == limitedOutput_directive.fillOutput)
			{
				ptr8 -= 5;
			}
			if (sufficient_len >= 4096)
			{
				sufficient_len = 4095u;
			}
			while (true)
			{
				if (ptr2 > ptr5)
				{
					goto IL_06aa;
				}
				int num = (int)(ptr2 - ptr3);
				int num2 = 0;
				LZ4HC_match_t lZ4HC_match_t = LZ4HC_FindLongerMatch(ctx, ptr2, iHighLimit, 3, nbSearches, dict, favorDecSpeed);
				if (lZ4HC_match_t.len == 0)
				{
					ptr2++;
					continue;
				}
				if ((uint)lZ4HC_match_t.len > sufficient_len)
				{
					int len = lZ4HC_match_t.len;
					byte* match = ptr2 - lZ4HC_match_t.off;
					ptr7 = ptr6;
					if (LZ4HC_encodeSequence(&ptr2, &ptr6, &ptr3, len, match, limit, ptr8) == 0)
					{
						continue;
					}
					goto IL_0796;
				}
				for (int i = 0; i < 4; i++)
				{
					int price = LL.LZ4HC_literalsPrice(num + i);
					ptr[i].mlen = 1;
					ptr[i].off = 0;
					ptr[i].litlen = num + i;
					ptr[i].price = price;
				}
				int j = 4;
				int len2 = lZ4HC_match_t.len;
				int off = lZ4HC_match_t.off;
				for (; j <= len2; j++)
				{
					int price2 = LL.LZ4HC_sequencePrice(num, j);
					ptr[j].mlen = j;
					ptr[j].off = off;
					ptr[j].litlen = num;
					ptr[j].price = price2;
				}
				num2 = lZ4HC_match_t.len;
				for (int k = 1; k <= 3; k++)
				{
					ptr[num2 + k].mlen = 1;
					ptr[num2 + k].off = 0;
					ptr[num2 + k].litlen = k;
					ptr[num2 + k].price = ptr[num2].price + LL.LZ4HC_literalsPrice(k);
				}
				int num3 = 1;
				int num4;
				int off2;
				while (true)
				{
					if (num3 < num2)
					{
						byte* ptr9 = ptr2 + num3;
						if (ptr9 <= ptr5)
						{
							if (fullUpdate)
							{
								if (ptr[num3 + 1].price <= ptr[num3].price && ptr[num3 + 4].price < ptr[num3].price + 3)
								{
									goto IL_0591;
								}
							}
							else if (ptr[num3 + 1].price <= ptr[num3].price)
							{
								goto IL_0591;
							}
							LZ4HC_match_t lZ4HC_match_t2 = ((!fullUpdate) ? LZ4HC_FindLongerMatch(ctx, ptr9, iHighLimit, num2 - num3, nbSearches, dict, favorDecSpeed) : LZ4HC_FindLongerMatch(ctx, ptr9, iHighLimit, 3, nbSearches, dict, favorDecSpeed));
							if (lZ4HC_match_t2.len != 0)
							{
								if ((uint)lZ4HC_match_t2.len > sufficient_len || lZ4HC_match_t2.len + num3 >= 4096)
								{
									num4 = lZ4HC_match_t2.len;
									off2 = lZ4HC_match_t2.off;
									num2 = num3 + 1;
									break;
								}
								int litlen = ptr[num3].litlen;
								for (int l = 1; l < 4; l++)
								{
									int num5 = ptr[num3].price - LL.LZ4HC_literalsPrice(litlen) + LL.LZ4HC_literalsPrice(litlen + l);
									int num6 = num3 + l;
									if (num5 < ptr[num6].price)
									{
										ptr[num6].mlen = 1;
										ptr[num6].off = 0;
										ptr[num6].litlen = litlen + l;
										ptr[num6].price = num5;
									}
								}
								int len3 = lZ4HC_match_t2.len;
								for (int m = 4; m <= len3; m++)
								{
									int num7 = num3 + m;
									int off3 = lZ4HC_match_t2.off;
									int num8;
									int num9;
									if (ptr[num3].mlen == 1)
									{
										num8 = ptr[num3].litlen;
										num9 = ((num3 > num8) ? ptr[num3 - num8].price : 0) + LL.LZ4HC_sequencePrice(num8, m);
									}
									else
									{
										num8 = 0;
										num9 = ptr[num3].price + LL.LZ4HC_sequencePrice(0, m);
									}
									if (num7 > num2 + 3 || num9 <= (int)(ptr[num7].price - favorDecSpeed))
									{
										if (m == len3 && num2 < num7)
										{
											num2 = num7;
										}
										ptr[num7].mlen = m;
										ptr[num7].off = off3;
										ptr[num7].litlen = num8;
										ptr[num7].price = num9;
									}
								}
								for (int n = 1; n <= 3; n++)
								{
									ptr[num2 + n].mlen = 1;
									ptr[num2 + n].off = 0;
									ptr[num2 + n].litlen = n;
									ptr[num2 + n].price = ptr[num2].price + LL.LZ4HC_literalsPrice(n);
								}
							}
							goto IL_0591;
						}
					}
					num4 = ptr[num2].mlen;
					off2 = ptr[num2].off;
					num3 = num2 - num4;
					break;
					IL_0591:
					num3++;
				}
				int num10 = num3;
				int mlen = num4;
				int off4 = off2;
				while (true)
				{
					int mlen2 = ptr[num10].mlen;
					int off5 = ptr[num10].off;
					ptr[num10].mlen = mlen;
					ptr[num10].off = off4;
					mlen = mlen2;
					off4 = off5;
					if (mlen2 > num10)
					{
						break;
					}
					num10 -= mlen2;
				}
				int num11 = 0;
				while (num11 < num2)
				{
					int mlen3 = ptr[num11].mlen;
					int off6 = ptr[num11].off;
					if (mlen3 == 1)
					{
						ptr2++;
						num11++;
						continue;
					}
					num11 += mlen3;
					ptr7 = ptr6;
					if (LZ4HC_encodeSequence(&ptr2, &ptr6, &ptr3, mlen3, ptr2 - off6, limit, ptr8) == 0)
					{
						continue;
					}
					goto IL_0796;
				}
				continue;
				IL_0796:
				if (limit != limitedOutput_directive.fillOutput)
				{
					break;
				}
				ptr6 = ptr7;
				goto IL_06aa;
				IL_06aa:
				uint num12 = (uint)(ptr4 - ptr3);
				uint num13 = (num12 + 255 - 15) / 255;
				uint num14 = 1 + num13 + num12;
				if (limit == limitedOutput_directive.fillOutput)
				{
					ptr8 += 5;
				}
				if (limit != limitedOutput_directive.notLimited && ptr6 + num14 > ptr8)
				{
					if (limit == limitedOutput_directive.limitedOutput)
					{
						return 0;
					}
					num12 = (uint)((int)(ptr8 - ptr6) - 1);
					num13 = (num12 + 255 - 15) / 255;
					num12 -= num13;
				}
				ptr2 = ptr3 + num12;
				if (num12 >= 15)
				{
					uint num15 = num12 - 15;
					*(ptr6++) = 240;
					while (num15 >= 255)
					{
						*(ptr6++) = byte.MaxValue;
						num15 -= 255;
					}
					*(ptr6++) = (byte)num15;
				}
				else
				{
					*(ptr6++) = (byte)(num12 << 4);
				}
				Mem.Copy(ptr6, ptr3, (int)num12);
				ptr6 += num12;
				*srcSizePtr = (int)(ptr2 - source);
				return (int)(ptr6 - dst);
			}
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_compress_generic_internal(LZ4_streamHC_t* ctx, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, int cLevel, limitedOutput_directive limit, dictCtx_directive dict)
		{
			if (limit == limitedOutput_directive.fillOutput && dstCapacity < 1)
			{
				return 0;
			}
			if ((uint)(*srcSizePtr) > 2113929216u)
			{
				return 0;
			}
			ctx->end += *srcSizePtr;
			if (cLevel < 1)
			{
				cLevel = 9;
			}
			cLevel = LL.MIN(12, cLevel);
			cParams_t cParams_t = clTable[cLevel];
			HCfavor_e favorDecSpeed = (ctx->favorDecSpeed ? HCfavor_e.favorDecompressionSpeed : HCfavor_e.favorCompressionRatio);
			int num = ((cParams_t.strat != lz4hc_strat_e.lz4hc) ? LZ4HC_compress_optimal(ctx, src, dst, srcSizePtr, dstCapacity, (int)cParams_t.nbSearches, cParams_t.targetLength, limit, cLevel == 12, dict, favorDecSpeed) : LZ4HC_compress_hashChain(ctx, src, dst, srcSizePtr, dstCapacity, (int)cParams_t.nbSearches, limit, dict));
			if (num <= 0)
			{
				ctx->dirty = true;
			}
			return num;
		}

		public unsafe static int LZ4HC_compress_generic_noDictCtx(LZ4_streamHC_t* ctx, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, int cLevel, limitedOutput_directive limit)
		{
			return LZ4HC_compress_generic_internal(ctx, src, dst, srcSizePtr, dstCapacity, cLevel, limit, dictCtx_directive.noDictCtx);
		}

		public unsafe static int LZ4HC_compress_generic_dictCtx(LZ4_streamHC_t* ctx, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, int cLevel, limitedOutput_directive limit)
		{
			uint num = (uint)(int)(ctx->end - ctx->@base) - ctx->lowLimit;
			if (num >= 65536)
			{
				ctx->dictCtx = null;
				return LZ4HC_compress_generic_noDictCtx(ctx, src, dst, srcSizePtr, dstCapacity, cLevel, limit);
			}
			if (num == 0 && *srcSizePtr > 4096)
			{
				Mem.Copy((byte*)ctx, (byte*)ctx->dictCtx, sizeof(LZ4_streamHC_t));
				LL.LZ4HC_setExternalDict(ctx, src);
				ctx->compressionLevel = (short)cLevel;
				return LZ4HC_compress_generic_noDictCtx(ctx, src, dst, srcSizePtr, dstCapacity, cLevel, limit);
			}
			return LZ4HC_compress_generic_internal(ctx, src, dst, srcSizePtr, dstCapacity, cLevel, limit, dictCtx_directive.usingDictCtxHc);
		}

		public unsafe static int LZ4HC_compress_generic(LZ4_streamHC_t* ctx, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, int cLevel, limitedOutput_directive limit)
		{
			if (ctx->dictCtx == null)
			{
				return LZ4HC_compress_generic_noDictCtx(ctx, src, dst, srcSizePtr, dstCapacity, cLevel, limit);
			}
			return LZ4HC_compress_generic_dictCtx(ctx, src, dst, srcSizePtr, dstCapacity, cLevel, limit);
		}

		public unsafe static int LZ4_compressHC_continue_generic(LZ4_streamHC_t* LZ4_streamHCPtr, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, limitedOutput_directive limit)
		{
			if (LZ4_streamHCPtr->@base == null)
			{
				LL.LZ4HC_init_internal(LZ4_streamHCPtr, src);
			}
			if ((uint)(LZ4_streamHCPtr->end - LZ4_streamHCPtr->@base) > 2147483648u)
			{
				uint num = (uint)(int)(LZ4_streamHCPtr->end - LZ4_streamHCPtr->@base) - LZ4_streamHCPtr->dictLimit;
				if (num > 65536)
				{
					num = 65536u;
				}
				LL.LZ4_loadDictHC(LZ4_streamHCPtr, LZ4_streamHCPtr->end - num, (int)num);
			}
			if (src != LZ4_streamHCPtr->end)
			{
				LL.LZ4HC_setExternalDict(LZ4_streamHCPtr, src);
			}
			byte* ptr = src + *srcSizePtr;
			byte* ptr2 = LZ4_streamHCPtr->dictBase + LZ4_streamHCPtr->lowLimit;
			byte* ptr3 = LZ4_streamHCPtr->dictBase + LZ4_streamHCPtr->dictLimit;
			if (ptr > ptr2 && src < ptr3)
			{
				if (ptr > ptr3)
				{
					ptr = ptr3;
				}
				LZ4_streamHCPtr->lowLimit = (uint)(ptr - LZ4_streamHCPtr->dictBase);
				if (LZ4_streamHCPtr->dictLimit - LZ4_streamHCPtr->lowLimit < 4)
				{
					LZ4_streamHCPtr->lowLimit = LZ4_streamHCPtr->dictLimit;
				}
			}
			return LZ4HC_compress_generic(LZ4_streamHCPtr, src, dst, srcSizePtr, dstCapacity, LZ4_streamHCPtr->compressionLevel, limit);
		}

		public unsafe static int LZ4_compress_HC_continue(LZ4_streamHC_t* LZ4_streamHCPtr, byte* src, byte* dst, int srcSize, int dstCapacity)
		{
			if (dstCapacity < LL.LZ4_compressBound(srcSize))
			{
				return LZ4_compressHC_continue_generic(LZ4_streamHCPtr, src, dst, &srcSize, dstCapacity, limitedOutput_directive.limitedOutput);
			}
			return LZ4_compressHC_continue_generic(LZ4_streamHCPtr, src, dst, &srcSize, dstCapacity, limitedOutput_directive.notLimited);
		}

		public unsafe static int LZ4_compress_HC_continue_destSize(LZ4_streamHC_t* LZ4_streamHCPtr, byte* src, byte* dst, int* srcSizePtr, int targetDestSize)
		{
			return LZ4_compressHC_continue_generic(LZ4_streamHCPtr, src, dst, srcSizePtr, targetDestSize, limitedOutput_directive.fillOutput);
		}

		public unsafe static int LZ4_compress_HC_destSize(LZ4_streamHC_t* state, byte* source, byte* dest, int* sourceSizePtr, int targetDestSize, int cLevel)
		{
			LZ4_streamHC_t* ptr = LL.LZ4_initStreamHC(state);
			if (ptr == null)
			{
				return 0;
			}
			LL.LZ4HC_init_internal(ptr, source);
			LL.LZ4_setCompressionLevel(ptr, cLevel);
			return LZ4HC_compress_generic(ptr, source, dest, sourceSizePtr, targetDestSize, cLevel, limitedOutput_directive.fillOutput);
		}

		public unsafe static int LZ4_compress_HC_extStateHC_fastReset(LZ4_streamHC_t* state, byte* src, byte* dst, int srcSize, int dstCapacity, int compressionLevel)
		{
			if (((uint)state & (sizeof(void*) - 1)) != 0L)
			{
				return 0;
			}
			LL.LZ4_resetStreamHC_fast(state, compressionLevel);
			LL.LZ4HC_init_internal(state, src);
			if (dstCapacity < LL.LZ4_compressBound(srcSize))
			{
				return LZ4HC_compress_generic(state, src, dst, &srcSize, dstCapacity, compressionLevel, limitedOutput_directive.limitedOutput);
			}
			return LZ4HC_compress_generic(state, src, dst, &srcSize, dstCapacity, compressionLevel, limitedOutput_directive.notLimited);
		}

		public unsafe static int LZ4_compress_HC_extStateHC(LZ4_streamHC_t* state, byte* src, byte* dst, int srcSize, int dstCapacity, int compressionLevel)
		{
			if (LL.LZ4_initStreamHC(state) == null)
			{
				return 0;
			}
			return LZ4_compress_HC_extStateHC_fastReset(state, src, dst, srcSize, dstCapacity, compressionLevel);
		}

		public unsafe static int LZ4_compress_HC(byte* src, byte* dst, int srcSize, int dstCapacity, int compressionLevel)
		{
			PinnedMemory.Alloc(out var memory, sizeof(LZ4_streamHC_t), zero: false);
			try
			{
				return LZ4_compress_HC_extStateHC(memory.Reference<LZ4_streamHC_t>(), src, dst, srcSize, dstCapacity, compressionLevel);
			}
			finally
			{
				memory.Free();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static uint LZ4_NbCommonBytes(uint val)
		{
			return DeBruijnBytePos[(val & (0 - val)) * 125613361 >> 27];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static uint LZ4_count(byte* pIn, byte* pMatch, byte* pInLimit)
		{
			byte* ptr = pIn;
			if (pIn < pInLimit - 3)
			{
				uint num = Mem32.PeekW(pMatch) ^ Mem32.PeekW(pIn);
				if (num != 0)
				{
					return LZ4_NbCommonBytes(num);
				}
				pIn += 4;
				pMatch += 4;
			}
			while (pIn < pInLimit - 3)
			{
				uint num2 = Mem32.PeekW(pMatch) ^ Mem32.PeekW(pIn);
				if (num2 != 0)
				{
					return (uint)(pIn + LZ4_NbCommonBytes(num2) - ptr);
				}
				pIn += 4;
				pMatch += 4;
			}
			if (pIn < pInLimit - 1 && Mem.Peek2(pMatch) == Mem.Peek2(pIn))
			{
				pIn += 2;
				pMatch += 2;
			}
			if (pIn < pInLimit && *pMatch == *pIn)
			{
				pIn++;
			}
			return (uint)(pIn - ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static uint LZ4_hashPosition(void* p, tableType_t tableType)
		{
			return LL.LZ4_hash4(Mem.Peek4(p), tableType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static void LZ4_putPosition(byte* p, void* tableBase, tableType_t tableType, byte* srcBase)
		{
			LL.LZ4_putPositionOnHash(p, LZ4_hashPosition(p, tableType), tableBase, tableType, srcBase);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static byte* LZ4_getPosition(byte* p, void* tableBase, tableType_t tableType, byte* srcBase)
		{
			return LL.LZ4_getPositionOnHash(LZ4_hashPosition(p, tableType), tableBase, tableType, srcBase);
		}

		protected unsafe static void LZ4_renormDictT(LZ4_stream_t* LZ4_dict, int nextSize)
		{
			if ((uint)((int)LZ4_dict->currentOffset + nextSize) <= 2147483648u)
			{
				return;
			}
			uint num = LZ4_dict->currentOffset - 65536;
			byte* ptr = LZ4_dict->dictionary + LZ4_dict->dictSize;
			for (int i = 0; i < 4096; i++)
			{
				if (LZ4_dict->hashTable[i] < num)
				{
					LZ4_dict->hashTable[i] = 0u;
				}
				else
				{
					LZ4_dict->hashTable[i] -= num;
				}
			}
			LZ4_dict->currentOffset = 65536u;
			if (LZ4_dict->dictSize > 65536)
			{
				LZ4_dict->dictSize = 65536u;
			}
			LZ4_dict->dictionary = ptr - LZ4_dict->dictSize;
		}

		public unsafe int LZ4_loadDict(LZ4_stream_t* LZ4_dict, byte* dictionary, int dictSize)
		{
			byte* ptr = dictionary;
			byte* ptr2 = ptr + dictSize;
			LL.LZ4_initStream(LZ4_dict);
			LZ4_dict->currentOffset += 65536u;
			if (dictSize < 4)
			{
				return 0;
			}
			if (ptr2 - ptr > 65536)
			{
				ptr = ptr2 - 65536;
			}
			byte* srcBase = ptr2 - LZ4_dict->currentOffset;
			LZ4_dict->dictionary = ptr;
			LZ4_dict->dictSize = (uint)(ptr2 - ptr);
			LZ4_dict->tableType = tableType_t.byU32;
			for (; ptr <= ptr2 - 4; ptr += 3)
			{
				LZ4_putPosition(ptr, LZ4_dict->hashTable, tableType_t.byU32, srcBase);
			}
			return (int)LZ4_dict->dictSize;
		}
	}
	internal class LL64 : LL
	{
		protected static cParams_t[] clTable = new cParams_t[13]
		{
			new cParams_t(lz4hc_strat_e.lz4hc, 2u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 2u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 2u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 4u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 8u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 16u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 32u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 64u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 128u, 16u),
			new cParams_t(lz4hc_strat_e.lz4hc, 256u, 16u),
			new cParams_t(lz4hc_strat_e.lz4opt, 96u, 64u),
			new cParams_t(lz4hc_strat_e.lz4opt, 512u, 128u),
			new cParams_t(lz4hc_strat_e.lz4opt, 16384u, 4096u)
		};

		protected const int ALGORITHM_ARCH = 8;

		private static readonly uint[] _DeBruijnBytePos = new uint[64]
		{
			0u, 0u, 0u, 0u, 0u, 1u, 1u, 2u, 0u, 3u,
			1u, 3u, 1u, 4u, 2u, 7u, 0u, 2u, 3u, 6u,
			1u, 5u, 3u, 5u, 1u, 3u, 4u, 4u, 2u, 5u,
			6u, 7u, 7u, 0u, 1u, 2u, 3u, 3u, 4u, 6u,
			2u, 6u, 5u, 5u, 3u, 4u, 5u, 6u, 7u, 1u,
			2u, 4u, 6u, 4u, 4u, 5u, 7u, 2u, 6u, 5u,
			7u, 6u, 7u, 7u
		};

		private unsafe static readonly uint* DeBruijnBytePos = Mem.CloneArray(_DeBruijnBytePos);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4_decompress_generic(byte* src, byte* dst, int srcSize, int outputSize, endCondition_directive endOnInput, earlyEnd_directive partialDecoding, dict_directive dict, byte* lowPrefix, byte* dictStart, uint dictSize)
		{
			return LZ4_decompress_generic(src, dst, srcSize, outputSize, endOnInput == endCondition_directive.endOnInputSize, partialDecoding == earlyEnd_directive.partial, dict, lowPrefix, dictStart, dictSize);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4_decompress_generic(byte* src, byte* dst, int srcSize, int outputSize, bool endOnInput, bool partialDecoding, dict_directive dict, byte* lowPrefix, byte* dictStart, uint dictSize)
		{
			if (src == null)
			{
				return -1;
			}
			byte* ptr = src;
			byte* ptr2 = ptr + srcSize;
			byte* ptr3 = dst;
			byte* ptr4 = ptr3 + outputSize;
			byte* ptr5 = ((dictStart == null) ? null : (dictStart + dictSize));
			bool flag = endOnInput;
			bool flag2 = flag && dictSize < 65536;
			byte* ptr6 = ptr2 - (endOnInput ? 14 : 8) - 2;
			byte* ptr7 = ptr4 - (endOnInput ? 14 : 8) - 18;
			if (endOnInput && outputSize == 0)
			{
				if (partialDecoding)
				{
					return 0;
				}
				if (srcSize != 1 || *ptr != 0)
				{
					return -1;
				}
				return 0;
			}
			if (!endOnInput && outputSize == 0)
			{
				if (*ptr != 0)
				{
					return -1;
				}
				return 1;
			}
			if (endOnInput && srcSize == 0)
			{
				return -1;
			}
			while (true)
			{
				uint num = *(ptr++);
				uint num2 = num >> 4;
				uint num3;
				byte* ptr9;
				byte* ptr8;
				if ((endOnInput ? (num2 != 15) : (num2 <= 8)) && (!endOnInput || ptr < ptr6) && ptr3 <= ptr7)
				{
					if (endOnInput)
					{
						Mem64.Copy16(ptr3, ptr);
					}
					else
					{
						Mem64.Copy8(ptr3, ptr);
					}
					ptr3 += num2;
					ptr += num2;
					num2 = num & 0xF;
					num3 = Mem64.Peek2(ptr);
					ptr += 2;
					ptr8 = ptr3 - num3;
					if (num2 != 15 && num3 >= 8 && (dict == dict_directive.withPrefix64k || ptr8 >= lowPrefix))
					{
						Mem64.Copy18(ptr3, ptr8);
						ptr3 += num2 + 4;
						continue;
					}
				}
				else
				{
					if (num2 == 15)
					{
						variable_length_error variable_length_error = variable_length_error.ok;
						num2 += LL.LZ4_readVLE(&ptr, ptr2 - 15, endOnInput, endOnInput, &variable_length_error);
						if (variable_length_error == variable_length_error.initial_error || (flag && ptr3 + num2 < ptr3) || (flag && ptr + num2 < ptr))
						{
							break;
						}
					}
					ptr9 = ptr3 + num2;
					if ((endOnInput && (ptr9 > ptr4 - 12 || ptr + num2 > ptr2 - 8)) || (!endOnInput && ptr9 > ptr4 - 8))
					{
						if (partialDecoding)
						{
							if (ptr + num2 > ptr2 - 8 && ptr + num2 != ptr2)
							{
								break;
							}
							if (ptr9 > ptr4)
							{
								ptr9 = ptr4;
								num2 = (uint)(ptr4 - ptr3);
							}
						}
						else if ((!endOnInput && ptr9 != ptr4) || (endOnInput && (ptr + num2 != ptr2 || ptr9 > ptr4)))
						{
							break;
						}
						Mem.Move(ptr3, ptr, (int)num2);
						ptr += num2;
						ptr3 += num2;
						if (!partialDecoding || ptr9 == ptr4 || ptr == ptr2)
						{
							goto IL_04a7;
						}
					}
					else
					{
						Mem64.WildCopy8(ptr3, ptr, ptr9);
						ptr += num2;
						ptr3 = ptr9;
					}
					num3 = Mem64.Peek2(ptr);
					ptr += 2;
					ptr8 = ptr3 - num3;
					num2 = num & 0xF;
				}
				if (num2 == 15)
				{
					variable_length_error variable_length_error2 = variable_length_error.ok;
					num2 += LL.LZ4_readVLE(&ptr, ptr2 - 5 + 1, endOnInput, initial_check: false, &variable_length_error2);
					if (variable_length_error2 != variable_length_error.ok || (flag && ptr3 + num2 < ptr3))
					{
						break;
					}
				}
				num2 += 4;
				if (flag2 && ptr8 + dictSize < lowPrefix)
				{
					break;
				}
				if (dict == dict_directive.usingExtDict && ptr8 < lowPrefix)
				{
					if (ptr3 + num2 > ptr4 - 5)
					{
						if (!partialDecoding)
						{
							break;
						}
						num2 = LL.MIN(num2, (uint)(ptr4 - ptr3));
					}
					if (num2 <= (uint)(lowPrefix - ptr8))
					{
						Mem.Move(ptr3, ptr5 - (lowPrefix - ptr8), (int)num2);
						ptr3 += num2;
						continue;
					}
					uint num4 = (uint)(lowPrefix - ptr8);
					uint num5 = num2 - num4;
					Mem.Copy(ptr3, ptr5 - num4, (int)num4);
					ptr3 += num4;
					if (num5 > (uint)(ptr3 - lowPrefix))
					{
						byte* ptr10 = ptr3 + num5;
						byte* ptr11 = lowPrefix;
						while (ptr3 < ptr10)
						{
							*(ptr3++) = *(ptr11++);
						}
					}
					else
					{
						Mem.Copy(ptr3, lowPrefix, (int)num5);
						ptr3 += num5;
					}
					continue;
				}
				ptr9 = ptr3 + num2;
				if (partialDecoding && ptr9 > ptr4 - 12)
				{
					uint num6 = LL.MIN(num2, (uint)(ptr4 - ptr3));
					byte* num7 = ptr8 + num6;
					byte* ptr12 = ptr3 + num6;
					if (num7 > ptr3)
					{
						while (ptr3 < ptr12)
						{
							*(ptr3++) = *(ptr8++);
						}
					}
					else
					{
						Mem.Copy(ptr3, ptr8, (int)num6);
					}
					ptr3 = ptr12;
					if (ptr3 != ptr4)
					{
						continue;
					}
					goto IL_04a7;
				}
				if (num3 < 8)
				{
					*ptr3 = *ptr8;
					ptr3[1] = ptr8[1];
					ptr3[2] = ptr8[2];
					ptr3[3] = ptr8[3];
					ptr8 += LL.inc32table[num3];
					Mem64.Copy4(ptr3 + 4, ptr8);
					ptr8 -= LL.dec64table[num3];
				}
				else
				{
					Mem64.Copy8(ptr3, ptr8);
					ptr8 += 8;
				}
				ptr3 += 8;
				if (ptr9 > ptr4 - 12)
				{
					byte* ptr13 = ptr4 - 7;
					if (ptr9 > ptr4 - 5)
					{
						break;
					}
					if (ptr3 < ptr13)
					{
						Mem64.WildCopy8(ptr3, ptr8, ptr13);
						ptr8 += ptr13 - ptr3;
						ptr3 = ptr13;
					}
					while (ptr3 < ptr9)
					{
						*(ptr3++) = *(ptr8++);
					}
				}
				else
				{
					Mem64.Copy8(ptr3, ptr8);
					if (num2 > 16)
					{
						Mem64.WildCopy8(ptr3 + 8, ptr8 + 8, ptr9);
					}
				}
				ptr3 = ptr9;
				continue;
				IL_04a7:
				if (endOnInput)
				{
					return (int)(ptr3 - dst);
				}
				return (int)(ptr - src);
			}
			return (int)(-(ptr - src)) - 1;
		}

		public unsafe static int LZ4_decompress_safe(byte* source, byte* dest, int compressedSize, int maxDecompressedSize)
		{
			return LZ4_decompress_generic(source, dest, compressedSize, maxDecompressedSize, endCondition_directive.endOnInputSize, earlyEnd_directive.full, dict_directive.noDict, dest, null, 0u);
		}

		public unsafe static int LZ4_decompress_safe_withPrefix64k(byte* source, byte* dest, int compressedSize, int maxOutputSize)
		{
			return LZ4_decompress_generic(source, dest, compressedSize, maxOutputSize, endCondition_directive.endOnInputSize, earlyEnd_directive.full, dict_directive.withPrefix64k, dest - 65536, null, 0u);
		}

		public unsafe static int LZ4_decompress_safe_withSmallPrefix(byte* source, byte* dest, int compressedSize, int maxOutputSize, uint prefixSize)
		{
			return LZ4_decompress_generic(source, dest, compressedSize, maxOutputSize, endCondition_directive.endOnInputSize, earlyEnd_directive.full, dict_directive.noDict, dest - prefixSize, null, 0u);
		}

		public unsafe static int LZ4_decompress_safe_doubleDict(byte* source, byte* dest, int compressedSize, int maxOutputSize, uint prefixSize, void* dictStart, uint dictSize)
		{
			return LZ4_decompress_generic(source, dest, compressedSize, maxOutputSize, endCondition_directive.endOnInputSize, earlyEnd_directive.full, dict_directive.usingExtDict, dest - prefixSize, (byte*)dictStart, dictSize);
		}

		public unsafe static int LZ4_decompress_safe_forceExtDict(byte* source, byte* dest, int compressedSize, int maxOutputSize, void* dictStart, uint dictSize)
		{
			return LZ4_decompress_generic(source, dest, compressedSize, maxOutputSize, endCondition_directive.endOnInputSize, earlyEnd_directive.full, dict_directive.usingExtDict, dest, (byte*)dictStart, dictSize);
		}

		public unsafe static int LZ4_decompress_safe_usingDict(byte* source, byte* dest, int compressedSize, int maxOutputSize, byte* dictStart, int dictSize)
		{
			if (dictSize == 0)
			{
				return LZ4_decompress_safe(source, dest, compressedSize, maxOutputSize);
			}
			if (dictStart + dictSize == dest)
			{
				if (dictSize >= 65535)
				{
					return LZ4_decompress_safe_withPrefix64k(source, dest, compressedSize, maxOutputSize);
				}
				return LZ4_decompress_safe_withSmallPrefix(source, dest, compressedSize, maxOutputSize, (uint)dictSize);
			}
			return LZ4_decompress_safe_forceExtDict(source, dest, compressedSize, maxOutputSize, dictStart, (uint)dictSize);
		}

		public unsafe static int LZ4_decompress_safe_partial(byte* src, byte* dst, int compressedSize, int targetOutputSize, int dstCapacity)
		{
			uint outputSize = LL.MIN((uint)targetOutputSize, (uint)dstCapacity);
			return LZ4_decompress_generic(src, dst, compressedSize, (int)outputSize, endCondition_directive.endOnInputSize, earlyEnd_directive.partial, dict_directive.noDict, dst, null, 0u);
		}

		public unsafe static int LZ4_decompress_safe_continue(LZ4_streamDecode_t* LZ4_streamDecode, byte* source, byte* dest, int compressedSize, int maxOutputSize)
		{
			int num;
			if (LZ4_streamDecode->prefixSize == 0)
			{
				num = LZ4_decompress_safe(source, dest, compressedSize, maxOutputSize);
				if (num <= 0)
				{
					return num;
				}
				LZ4_streamDecode->prefixSize = (uint)num;
				LZ4_streamDecode->prefixEnd = dest + num;
			}
			else if (LZ4_streamDecode->prefixEnd == dest)
			{
				num = ((LZ4_streamDecode->prefixSize >= 65535) ? LZ4_decompress_safe_withPrefix64k(source, dest, compressedSize, maxOutputSize) : ((LZ4_streamDecode->extDictSize != 0) ? LZ4_decompress_safe_doubleDict(source, dest, compressedSize, maxOutputSize, LZ4_streamDecode->prefixSize, LZ4_streamDecode->externalDict, LZ4_streamDecode->extDictSize) : LZ4_decompress_safe_withSmallPrefix(source, dest, compressedSize, maxOutputSize, LZ4_streamDecode->prefixSize)));
				if (num <= 0)
				{
					return num;
				}
				LZ4_streamDecode->prefixSize += (uint)num;
				LZ4_streamDecode->prefixEnd += num;
			}
			else
			{
				LZ4_streamDecode->extDictSize = LZ4_streamDecode->prefixSize;
				LZ4_streamDecode->externalDict = LZ4_streamDecode->prefixEnd - LZ4_streamDecode->extDictSize;
				num = LZ4_decompress_safe_forceExtDict(source, dest, compressedSize, maxOutputSize, LZ4_streamDecode->externalDict, LZ4_streamDecode->extDictSize);
				if (num <= 0)
				{
					return num;
				}
				LZ4_streamDecode->prefixSize = (uint)num;
				LZ4_streamDecode->prefixEnd = dest + num;
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static int LZ4_compress_generic(LZ4_stream_t* cctx, byte* source, byte* dest, int inputSize, int* inputConsumed, int maxOutputSize, limitedOutput_directive outputDirective, tableType_t tableType, dict_directive dictDirective, dictIssue_directive dictIssue, int acceleration)
		{
			byte* ptr = source;
			uint currentOffset = cctx->currentOffset;
			byte* ptr2 = source - currentOffset;
			LZ4_stream_t* dictCtx = cctx->dictCtx;
			byte* ptr3 = ((dictDirective == dict_directive.usingDictCtx) ? dictCtx->dictionary : cctx->dictionary);
			uint num = ((dictDirective == dict_directive.usingDictCtx) ? dictCtx->dictSize : cctx->dictSize);
			uint num2 = ((dictDirective == dict_directive.usingDictCtx) ? (currentOffset - dictCtx->currentOffset) : 0u);
			bool flag = dictDirective == dict_directive.usingExtDict || dictDirective == dict_directive.usingDictCtx;
			uint num3 = currentOffset - num;
			byte* ptr4 = ptr3 + num;
			byte* ptr5 = source;
			byte* ptr6 = ptr + inputSize;
			byte* ptr7 = ptr6 - 12 + 1;
			byte* ptr8 = ptr6 - 5;
			byte* ptr9 = ((dictDirective == dict_directive.usingDictCtx) ? (ptr3 + num - dictCtx->currentOffset) : (ptr3 + num - currentOffset));
			byte* ptr10 = dest;
			byte* ptr11 = ptr10 + maxOutputSize;
			uint num4 = 0u;
			if (outputDirective == limitedOutput_directive.fillOutput && maxOutputSize < 1)
			{
				return 0;
			}
			if ((uint)inputSize > 2113929216u)
			{
				return 0;
			}
			if (tableType == tableType_t.byU16 && inputSize >= 65547)
			{
				return 0;
			}
			_ = 1;
			byte* ptr12 = source - ((dictDirective == dict_directive.withPrefix64k) ? num : 0);
			if (dictDirective == dict_directive.usingDictCtx)
			{
				cctx->dictCtx = null;
				cctx->dictSize = (uint)inputSize;
			}
			else
			{
				cctx->dictSize += (uint)inputSize;
			}
			cctx->currentOffset += (uint)inputSize;
			cctx->tableType = tableType;
			if (inputSize >= 13)
			{
				LZ4_putPosition(ptr, cctx->hashTable, tableType, ptr2);
				ptr++;
				uint num5 = LZ4_hashPosition(ptr, tableType);
				while (true)
				{
					byte* ptr14;
					if (tableType == tableType_t.byPtr)
					{
						byte* ptr13 = ptr;
						int num6 = 1;
						int num7 = acceleration << 6;
						while (true)
						{
							uint h = num5;
							ptr = ptr13;
							ptr13 += num6;
							num6 = num7++ >> 6;
							if (ptr13 > ptr7)
							{
								break;
							}
							ptr14 = LL.LZ4_getPositionOnHash(h, cctx->hashTable, tableType, ptr2);
							num5 = LZ4_hashPosition(ptr13, tableType);
							LL.LZ4_putPositionOnHash(ptr, h, cctx->hashTable, tableType, ptr2);
							if (ptr14 + 65535 < ptr || Mem64.Peek4(ptr14) != Mem64.Peek4(ptr))
							{
								continue;
							}
							goto IL_02f6;
						}
						break;
					}
					byte* ptr15 = ptr;
					int num8 = 1;
					int num9 = acceleration << 6;
					uint num10;
					uint num11;
					while (true)
					{
						uint h2 = num5;
						num10 = (uint)(ptr15 - ptr2);
						num11 = LL.LZ4_getIndexOnHash(h2, cctx->hashTable, tableType);
						ptr = ptr15;
						ptr15 += num8;
						num8 = num9++ >> 6;
						if (ptr15 > ptr7)
						{
							break;
						}
						switch (dictDirective)
						{
						case dict_directive.usingDictCtx:
							if (num11 < currentOffset)
							{
								num11 = LL.LZ4_getIndexOnHash(h2, dictCtx->hashTable, tableType_t.byU32);
								ptr14 = ptr9 + num11;
								num11 += num2;
								ptr12 = ptr3;
							}
							else
							{
								ptr14 = ptr2 + num11;
								ptr12 = source;
							}
							break;
						case dict_directive.usingExtDict:
							if (num11 < currentOffset)
							{
								ptr14 = ptr9 + num11;
								ptr12 = ptr3;
							}
							else
							{
								ptr14 = ptr2 + num11;
								ptr12 = source;
							}
							break;
						default:
							ptr14 = ptr2 + num11;
							break;
						}
						num5 = LZ4_hashPosition(ptr15, tableType);
						LL.LZ4_putIndexOnHash(num10, h2, cctx->hashTable, tableType);
						if ((dictIssue == dictIssue_directive.dictSmall && num11 < num3) || (tableType != tableType_t.byU16 && num11 + 65535 < num10) || Mem64.Peek4(ptr14) != Mem64.Peek4(ptr))
						{
							continue;
						}
						goto IL_02eb;
					}
					break;
					IL_02f6:
					byte* ptr16 = ptr;
					while (ptr > ptr5 && ptr14 > ptr12 && ptr[-1] == ptr14[-1])
					{
						ptr--;
						ptr14--;
					}
					uint num12 = (uint)(ptr - ptr5);
					byte* ptr17 = ptr10++;
					if (outputDirective == limitedOutput_directive.limitedOutput && ptr10 + num12 + 8 + num12 / 255 > ptr11)
					{
						return 0;
					}
					if (outputDirective == limitedOutput_directive.fillOutput && ptr10 + (num12 + 240) / 255 + num12 + 2 + 1 + 12 - 4 > ptr11)
					{
						ptr10--;
						break;
					}
					if (num12 >= 15)
					{
						int num13 = (int)(num12 - 15);
						*ptr17 = 240;
						while (num13 >= 255)
						{
							*(ptr10++) = byte.MaxValue;
							num13 -= 255;
						}
						*(ptr10++) = (byte)num13;
					}
					else
					{
						*ptr17 = (byte)(num12 << 4);
					}
					Mem64.WildCopy8(ptr10, ptr5, ptr10 + num12);
					ptr10 += num12;
					while (true)
					{
						if (outputDirective == limitedOutput_directive.fillOutput && ptr10 + 2 + 1 + 12 - 4 > ptr11)
						{
							ptr10 = ptr17;
							break;
						}
						if (flag)
						{
							Mem64.Poke2(ptr10, (ushort)num4);
							ptr10 += 2;
						}
						else
						{
							Mem64.Poke2(ptr10, (ushort)(ptr - ptr14));
							ptr10 += 2;
						}
						uint num14;
						if ((dictDirective == dict_directive.usingExtDict || dictDirective == dict_directive.usingDictCtx) && ptr12 == ptr3)
						{
							byte* ptr18 = ptr + (ptr4 - ptr14);
							if (ptr18 > ptr8)
							{
								ptr18 = ptr8;
							}
							num14 = LZ4_count(ptr + 4, ptr14 + 4, ptr18);
							ptr += num14 + 4;
							if (ptr == ptr18)
							{
								uint num15 = LZ4_count(ptr18, source, ptr8);
								num14 += num15;
								ptr += num15;
							}
						}
						else
						{
							num14 = LZ4_count(ptr + 4, ptr14 + 4, ptr8);
							ptr += num14 + 4;
						}
						if (outputDirective != limitedOutput_directive.notLimited && ptr10 + 6 + (num14 + 240) / 255 > ptr11)
						{
							if (outputDirective != limitedOutput_directive.fillOutput)
							{
								return 0;
							}
							uint num16 = (uint)(14 + ((int)(ptr11 - ptr10) - 1 - 5) * 255);
							ptr -= num14 - num16;
							num14 = num16;
							if (ptr <= ptr16)
							{
								for (byte* ptr19 = ptr; ptr19 <= ptr16; ptr19++)
								{
									LL.LZ4_clearHash(LZ4_hashPosition(ptr19, tableType), cctx->hashTable, tableType);
								}
							}
						}
						if (num14 >= 15)
						{
							byte* intPtr = ptr17;
							*intPtr += 15;
							num14 -= 15;
							Mem64.Poke4(ptr10, uint.MaxValue);
							while (num14 >= 1020)
							{
								ptr10 += 4;
								Mem64.Poke4(ptr10, uint.MaxValue);
								num14 -= 1020;
							}
							ptr10 += num14 / 255;
							*(ptr10++) = (byte)(num14 % 255);
						}
						else
						{
							byte* intPtr2 = ptr17;
							*intPtr2 += (byte)num14;
						}
						ptr5 = ptr;
						if (ptr >= ptr7)
						{
							break;
						}
						LZ4_putPosition(ptr - 2, cctx->hashTable, tableType, ptr2);
						if (tableType == tableType_t.byPtr)
						{
							ptr14 = LZ4_getPosition(ptr, cctx->hashTable, tableType, ptr2);
							LZ4_putPosition(ptr, cctx->hashTable, tableType, ptr2);
							if (ptr14 + 65535 >= ptr && Mem64.Peek4(ptr14) == Mem64.Peek4(ptr))
							{
								ptr17 = ptr10++;
								*ptr17 = 0;
								continue;
							}
						}
						else
						{
							uint h3 = LZ4_hashPosition(ptr, tableType);
							uint num17 = (uint)(ptr - ptr2);
							uint num18 = LL.LZ4_getIndexOnHash(h3, cctx->hashTable, tableType);
							switch (dictDirective)
							{
							case dict_directive.usingDictCtx:
								if (num18 < currentOffset)
								{
									num18 = LL.LZ4_getIndexOnHash(h3, dictCtx->hashTable, tableType_t.byU32);
									ptr14 = ptr9 + num18;
									ptr12 = ptr3;
									num18 += num2;
								}
								else
								{
									ptr14 = ptr2 + num18;
									ptr12 = source;
								}
								break;
							case dict_directive.usingExtDict:
								if (num18 < currentOffset)
								{
									ptr14 = ptr9 + num18;
									ptr12 = ptr3;
								}
								else
								{
									ptr14 = ptr2 + num18;
									ptr12 = source;
								}
								break;
							default:
								ptr14 = ptr2 + num18;
								break;
							}
							LL.LZ4_putIndexOnHash(num17, h3, cctx->hashTable, tableType);
							if ((dictIssue != dictIssue_directive.dictSmall || num18 >= num3) && (tableType == tableType_t.byU16 || num18 + 65535 >= num17) && Mem64.Peek4(ptr14) == Mem64.Peek4(ptr))
							{
								ptr17 = ptr10++;
								*ptr17 = 0;
								if (flag)
								{
									num4 = num17 - num18;
								}
								continue;
							}
						}
						goto IL_0703;
					}
					break;
					IL_0703:
					num5 = LZ4_hashPosition(++ptr, tableType);
					continue;
					IL_02eb:
					if (flag)
					{
						num4 = num10 - num11;
					}
					goto IL_02f6;
				}
			}
			uint num19 = (uint)(ptr6 - ptr5);
			if (outputDirective != limitedOutput_directive.notLimited && ptr10 + num19 + 1 + (num19 + 255 - 15) / 255 > ptr11)
			{
				if (outputDirective != limitedOutput_directive.fillOutput)
				{
					return 0;
				}
				num19 = (uint)((int)(ptr11 - ptr10) - 1);
				num19 -= (num19 + 240) / 255;
			}
			if (num19 >= 15)
			{
				uint num20 = num19 - 15;
				*(ptr10++) = 240;
				while (num20 >= 255)
				{
					*(ptr10++) = byte.MaxValue;
					num20 -= 255;
				}
				*(ptr10++) = (byte)num20;
			}
			else
			{
				*(ptr10++) = (byte)(num19 << 4);
			}
			Mem.Copy(ptr10, ptr5, (int)num19);
			ptr = ptr5 + num19;
			ptr10 += num19;
			if (outputDirective == limitedOutput_directive.fillOutput)
			{
				*inputConsumed = (int)(ptr - source);
			}
			return (int)(ptr10 - dest);
		}

		public unsafe static int LZ4_compress_fast_extState(LZ4_stream_t* state, byte* source, byte* dest, int inputSize, int maxOutputSize, int acceleration)
		{
			LZ4_stream_t* cctx = LL.LZ4_initStream(state);
			if (acceleration < 1)
			{
				acceleration = 1;
			}
			if (maxOutputSize >= LL.LZ4_compressBound(inputSize))
			{
				if (inputSize < 65547)
				{
					return LZ4_compress_generic(cctx, source, dest, inputSize, null, 0, limitedOutput_directive.notLimited, tableType_t.byU16, dict_directive.noDict, dictIssue_directive.noDictIssue, acceleration);
				}
				tableType_t tableType = ((sizeof(void*) < 8 && (nuint)source > (nuint)65535u) ? tableType_t.byPtr : tableType_t.byU32);
				return LZ4_compress_generic(cctx, source, dest, inputSize, null, 0, limitedOutput_directive.notLimited, tableType, dict_directive.noDict, dictIssue_directive.noDictIssue, acceleration);
			}
			if (inputSize < 65547)
			{
				return LZ4_compress_generic(cctx, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType_t.byU16, dict_directive.noDict, dictIssue_directive.noDictIssue, acceleration);
			}
			tableType_t tableType2 = ((sizeof(void*) < 8 && (nuint)source > (nuint)65535u) ? tableType_t.byPtr : tableType_t.byU32);
			return LZ4_compress_generic(cctx, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType2, dict_directive.noDict, dictIssue_directive.noDictIssue, acceleration);
		}

		public unsafe static int LZ4_compress_fast(byte* source, byte* dest, int inputSize, int maxOutputSize, int acceleration)
		{
			LZ4_stream_t lZ4_stream_t = default(LZ4_stream_t);
			return LZ4_compress_fast_extState(&lZ4_stream_t, source, dest, inputSize, maxOutputSize, acceleration);
		}

		public unsafe static int LZ4_compress_default(byte* src, byte* dst, int srcSize, int maxOutputSize)
		{
			return LZ4_compress_fast(src, dst, srcSize, maxOutputSize, 1);
		}

		public unsafe static int LZ4_compress_fast_continue(LZ4_stream_t* LZ4_stream, byte* source, byte* dest, int inputSize, int maxOutputSize, int acceleration)
		{
			byte* ptr = LZ4_stream->dictionary + LZ4_stream->dictSize;
			if (LZ4_stream->dirty)
			{
				return 0;
			}
			LZ4_renormDictT(LZ4_stream, inputSize);
			if (acceleration < 1)
			{
				acceleration = 1;
			}
			if (LZ4_stream->dictSize - 1 < 3 && ptr != source)
			{
				LZ4_stream->dictSize = 0u;
				LZ4_stream->dictionary = source;
				ptr = source;
			}
			byte* ptr2 = source + inputSize;
			if (ptr2 > LZ4_stream->dictionary && ptr2 < ptr)
			{
				LZ4_stream->dictSize = (uint)(ptr - ptr2);
				if (LZ4_stream->dictSize > 65536)
				{
					LZ4_stream->dictSize = 65536u;
				}
				if (LZ4_stream->dictSize < 4)
				{
					LZ4_stream->dictSize = 0u;
				}
				LZ4_stream->dictionary = ptr - LZ4_stream->dictSize;
			}
			if (ptr == source)
			{
				if (LZ4_stream->dictSize < 65536 && LZ4_stream->dictSize < LZ4_stream->currentOffset)
				{
					return LZ4_compress_generic(LZ4_stream, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType_t.byU32, dict_directive.withPrefix64k, dictIssue_directive.dictSmall, acceleration);
				}
				return LZ4_compress_generic(LZ4_stream, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType_t.byU32, dict_directive.withPrefix64k, dictIssue_directive.noDictIssue, acceleration);
			}
			int result;
			if (LZ4_stream->dictCtx == null)
			{
				result = ((LZ4_stream->dictSize >= 65536 || LZ4_stream->dictSize >= LZ4_stream->currentOffset) ? LZ4_compress_generic(LZ4_stream, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType_t.byU32, dict_directive.usingExtDict, dictIssue_directive.noDictIssue, acceleration) : LZ4_compress_generic(LZ4_stream, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType_t.byU32, dict_directive.usingExtDict, dictIssue_directive.dictSmall, acceleration));
			}
			else if (inputSize > 4096)
			{
				Mem.Copy((byte*)LZ4_stream, (byte*)LZ4_stream->dictCtx, sizeof(LZ4_stream_t));
				result = LZ4_compress_generic(LZ4_stream, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType_t.byU32, dict_directive.usingExtDict, dictIssue_directive.noDictIssue, acceleration);
			}
			else
			{
				result = LZ4_compress_generic(LZ4_stream, source, dest, inputSize, null, maxOutputSize, limitedOutput_directive.limitedOutput, tableType_t.byU32, dict_directive.usingDictCtx, dictIssue_directive.noDictIssue, acceleration);
			}
			LZ4_stream->dictionary = source;
			LZ4_stream->dictSize = (uint)inputSize;
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint LZ4HC_countPattern(byte* ip, byte* iEnd, uint pattern32)
		{
			byte* ptr = ip;
			ulong num = pattern32;
			num |= num << 32;
			while (ip < iEnd - 7)
			{
				ulong num2 = Mem64.PeekW(ip) ^ num;
				if (num2 == 0L)
				{
					ip += 8;
					continue;
				}
				ip += LZ4_NbCommonBytes(num2);
				return (uint)(ip - ptr);
			}
			ulong num3 = num;
			while (ip < iEnd && *ip == (byte)num3)
			{
				ip++;
				num3 >>= 8;
			}
			return (uint)(ip - ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_InsertAndGetWiderMatch(LZ4_streamHC_t* hc4, byte* ip, byte* iLowLimit, byte* iHighLimit, int longest, byte** matchpos, byte** startpos, int maxNbAttempts, bool patternAnalysis, bool chainSwap, dictCtx_directive dict, HCfavor_e favorDecSpeed)
		{
			ushort* table = hc4->chainTable;
			uint* num = hc4->hashTable;
			LZ4_streamHC_t* dictCtx = hc4->dictCtx;
			byte* ptr = hc4->@base;
			uint dictLimit = hc4->dictLimit;
			byte* ptr2 = ptr + dictLimit;
			uint num2 = (uint)(ip - ptr);
			uint num3 = ((hc4->lowLimit + 65536 > num2) ? hc4->lowLimit : (num2 - 65535));
			byte* dictBase = hc4->dictBase;
			int num4 = (int)(ip - iLowLimit);
			int num5 = maxNbAttempts;
			uint num6 = 0u;
			uint num7 = Mem64.Peek4(ip);
			repeat_state_e repeat_state_e = repeat_state_e.rep_untested;
			uint num8 = 0u;
			LL.LZ4HC_Insert(hc4, ip);
			uint num9 = num[LL.LZ4HC_hashPtr(ip)];
			while (num9 >= num3 && num5 != 0)
			{
				int num10 = 0;
				num5--;
				if (favorDecSpeed == HCfavor_e.favorCompressionRatio || num2 - num9 >= 8)
				{
					if (num9 >= dictLimit)
					{
						byte* ptr3 = ptr + num9;
						if (Mem64.Peek2(iLowLimit + longest - 1) == Mem64.Peek2(ptr3 - num4 + longest - 1) && Mem64.Peek4(ptr3) == num7)
						{
							int num11 = ((num4 != 0) ? LL.LZ4HC_countBack(ip, ptr3, iLowLimit, ptr2) : 0);
							num10 = (int)(4 + LZ4_count(ip + 4, ptr3 + 4, iHighLimit));
							num10 -= num11;
							if (num10 > longest)
							{
								longest = num10;
								*matchpos = ptr3 + num11;
								*startpos = ip + num11;
							}
						}
					}
					else
					{
						byte* ptr4 = dictBase + num9;
						if (Mem64.Peek4(ptr4) == num7)
						{
							byte* mMin = dictBase + hc4->lowLimit;
							int num12 = 0;
							byte* ptr5 = ip + (dictLimit - num9);
							if (ptr5 > iHighLimit)
							{
								ptr5 = iHighLimit;
							}
							num10 = (int)(LZ4_count(ip + 4, ptr4 + 4, ptr5) + 4);
							if (ip + num10 == ptr5 && ptr5 < iHighLimit)
							{
								num10 += (int)LZ4_count(ip + num10, ptr2, iHighLimit);
							}
							num12 = ((num4 != 0) ? LL.LZ4HC_countBack(ip, ptr4, iLowLimit, mMin) : 0);
							num10 -= num12;
							if (num10 > longest)
							{
								longest = num10;
								*matchpos = ptr + num9 + num12;
								*startpos = ip + num12;
							}
						}
					}
				}
				if (chainSwap && num10 == longest && (uint)((int)num9 + longest) <= num2)
				{
					int num13 = 4;
					uint num14 = 1u;
					int num15 = longest - 4 + 1;
					int num16 = 1;
					int num17 = 1 << num13;
					for (int i = 0; i < num15; i += num16)
					{
						uint num18 = LL.DELTANEXTU16(table, num9 + (uint)i);
						num16 = num17++ >> num13;
						if (num18 > num14)
						{
							num14 = num18;
							num6 = (uint)i;
							num17 = 1 << num13;
						}
					}
					if (num14 > 1)
					{
						if (num14 > num9)
						{
							break;
						}
						num9 -= num14;
						continue;
					}
				}
				uint num19 = LL.DELTANEXTU16(table, num9);
				if (patternAnalysis && num19 == 1 && num6 == 0)
				{
					uint num20 = num9 - 1;
					if (repeat_state_e == repeat_state_e.rep_untested)
					{
						if ((num7 & 0xFFFF) == num7 >> 16 && (num7 & 0xFF) == num7 >> 24)
						{
							repeat_state_e = repeat_state_e.rep_confirmed;
							num8 = LZ4HC_countPattern(ip + 4, iHighLimit, num7) + 4;
						}
						else
						{
							repeat_state_e = repeat_state_e.rep_not;
						}
					}
					if (repeat_state_e == repeat_state_e.rep_confirmed && num20 >= num3 && LL.LZ4HC_protectDictEnd(dictLimit, num20))
					{
						bool flag = num20 < dictLimit;
						byte* ptr6 = (flag ? dictBase : ptr) + num20;
						if (Mem64.Peek4(ptr6) == num7)
						{
							byte* ptr7 = dictBase + hc4->lowLimit;
							byte* ptr8 = (flag ? (dictBase + dictLimit) : iHighLimit);
							uint num21 = LZ4HC_countPattern(ptr6 + 4, ptr8, num7) + 4;
							if (flag && ptr6 + num21 == ptr8)
							{
								uint pattern = LL.LZ4HC_rotatePattern(num21, num7);
								num21 += LZ4HC_countPattern(ptr2, iHighLimit, pattern);
							}
							byte* iLow = (flag ? ptr7 : ptr2);
							uint num22 = LL.LZ4HC_reverseCountPattern(ptr6, iLow, num7);
							if (!flag && ptr6 - num22 == ptr2 && hc4->lowLimit < dictLimit)
							{
								uint pattern2 = LL.LZ4HC_rotatePattern(0 - num22, num7);
								num22 += LL.LZ4HC_reverseCountPattern(dictBase + dictLimit, ptr7, pattern2);
							}
							num22 = num20 - LL.MAX(num20 - num22, num3);
							uint num23 = num22 + num21;
							if (num23 >= num8 && num21 <= num8)
							{
								uint num24 = num20 + num21 - num8;
								num9 = ((!LL.LZ4HC_protectDictEnd(dictLimit, num24)) ? dictLimit : num24);
								continue;
							}
							uint num25 = num20 - num22;
							if (!LL.LZ4HC_protectDictEnd(dictLimit, num25))
							{
								num9 = dictLimit;
								continue;
							}
							num9 = num25;
							if (num4 != 0)
							{
								continue;
							}
							uint num26 = LL.MIN(num23, num8);
							if ((uint)longest < num26)
							{
								if ((uint)((int)(ip - ptr) - (int)num9) > 65535u)
								{
									break;
								}
								longest = (int)num26;
								*matchpos = ptr + num9;
								*startpos = ip;
							}
							uint num27 = LL.DELTANEXTU16(table, num9);
							if (num27 > num9)
							{
								break;
							}
							num9 -= num27;
							continue;
						}
					}
				}
				num9 -= LL.DELTANEXTU16(table, num9 + num6);
			}
			if (dict == dictCtx_directive.usingDictCtxHc && num5 != 0 && num2 - num3 < 65535)
			{
				uint num28 = (uint)(dictCtx->end - dictCtx->@base);
				uint num29 = dictCtx->hashTable[LL.LZ4HC_hashPtr(ip)];
				num9 = num29 + num3 - num28;
				while (num2 - num9 <= 65535 && num5-- != 0)
				{
					byte* ptr9 = dictCtx->@base + num29;
					if (Mem64.Peek4(ptr9) == num7)
					{
						int num30 = 0;
						byte* ptr10 = ip + (num28 - num29);
						if (ptr10 > iHighLimit)
						{
							ptr10 = iHighLimit;
						}
						int num31 = (int)(LZ4_count(ip + 4, ptr9 + 4, ptr10) + 4);
						num30 = ((num4 != 0) ? LL.LZ4HC_countBack(ip, ptr9, iLowLimit, dictCtx->@base + dictCtx->dictLimit) : 0);
						num31 -= num30;
						if (num31 > longest)
						{
							longest = num31;
							*matchpos = ptr + num9 + num30;
							*startpos = ip + num30;
						}
					}
					uint num32 = LL.DELTANEXTU16(dictCtx->chainTable, num29);
					num29 -= num32;
					num9 -= num32;
				}
			}
			return longest;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_InsertAndFindBestMatch(LZ4_streamHC_t* hc4, byte* ip, byte* iLimit, byte** matchpos, int maxNbAttempts, bool patternAnalysis, dictCtx_directive dict)
		{
			byte* ptr = ip;
			return LZ4HC_InsertAndGetWiderMatch(hc4, ip, ip, iLimit, 3, matchpos, &ptr, maxNbAttempts, patternAnalysis, chainSwap: false, dict, HCfavor_e.favorCompressionRatio);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static LZ4HC_match_t LZ4HC_FindLongerMatch(LZ4_streamHC_t* ctx, byte* ip, byte* iHighLimit, int minLen, int nbSearches, dictCtx_directive dict, HCfavor_e favorDecSpeed)
		{
			LZ4HC_match_t result = default(LZ4HC_match_t);
			result.len = 0;
			result.off = 0;
			byte* ptr = null;
			int num = LZ4HC_InsertAndGetWiderMatch(ctx, ip, ip, iHighLimit, minLen, &ptr, &ip, nbSearches, patternAnalysis: true, chainSwap: true, dict, favorDecSpeed);
			if (num <= minLen)
			{
				return result;
			}
			if (favorDecSpeed != HCfavor_e.favorCompressionRatio && num > 18 && num <= 36)
			{
				num = 18;
			}
			result.len = num;
			result.off = (int)(ip - ptr);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_encodeSequence(byte** ip, byte** op, byte** anchor, int matchLength, byte* match, limitedOutput_directive limit, byte* oend)
		{
			byte* ptr = (*op)++;
			uint num = (uint)(*ip - *anchor);
			if (limit != limitedOutput_directive.notLimited && *op + num / 255 + num + 8 > oend)
			{
				return 1;
			}
			if (num >= 15)
			{
				uint num2 = num - 15;
				*ptr = 240;
				while (num2 >= 255)
				{
					*((*op)++) = byte.MaxValue;
					num2 -= 255;
				}
				*((*op)++) = (byte)num2;
			}
			else
			{
				*ptr = (byte)(num << 4);
			}
			Mem64.WildCopy8(*op, *anchor, *op + num);
			*op += num;
			Mem64.Poke2(*op, (ushort)(*ip - match));
			*op += 2;
			num = (uint)(matchLength - 4);
			if (limit != limitedOutput_directive.notLimited && *op + num / 255 + 6 > oend)
			{
				return 1;
			}
			if (num >= 15)
			{
				*ptr += 15;
				for (num -= 15; num >= 510; num -= 510)
				{
					*((*op)++) = byte.MaxValue;
					*((*op)++) = byte.MaxValue;
				}
				if (num >= 255)
				{
					num -= 255;
					*((*op)++) = byte.MaxValue;
				}
				*((*op)++) = (byte)num;
			}
			else
			{
				*ptr += (byte)num;
			}
			*ip += matchLength;
			*anchor = *ip;
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_compress_hashChain(LZ4_streamHC_t* ctx, byte* source, byte* dest, int* srcSizePtr, int maxOutputSize, int maxNbAttempts, limitedOutput_directive limit, dictCtx_directive dict)
		{
			int num = *srcSizePtr;
			bool patternAnalysis = maxNbAttempts > 128;
			byte* ptr = source;
			byte* ptr2 = ptr;
			byte* ptr3 = ptr + num;
			byte* ptr4 = ptr3 - 12;
			byte* ptr5 = ptr3 - 5;
			byte* ptr6 = dest;
			byte* ptr7 = dest;
			byte* ptr8 = ptr7 + maxOutputSize;
			byte* ptr9 = null;
			byte* ptr10 = null;
			byte* ptr11 = null;
			byte* ptr12 = null;
			byte* ptr13 = null;
			*srcSizePtr = 0;
			if (limit == limitedOutput_directive.fillOutput)
			{
				ptr8 -= 5;
			}
			if (num >= 13)
			{
				while (ptr <= ptr4)
				{
					int num2 = LZ4HC_InsertAndFindBestMatch(ctx, ptr, ptr5, &ptr9, maxNbAttempts, patternAnalysis, dict);
					if (num2 < 4)
					{
						ptr++;
						continue;
					}
					byte* ptr14 = ptr;
					byte* ptr15 = ptr9;
					int num3 = num2;
					while (true)
					{
						int num4 = ((ptr + num2 > ptr4) ? num2 : LZ4HC_InsertAndGetWiderMatch(ctx, ptr + num2 - 2, ptr, ptr5, num2, &ptr11, &ptr10, maxNbAttempts, patternAnalysis, chainSwap: false, dict, HCfavor_e.favorCompressionRatio));
						int num7;
						if (num4 == num2)
						{
							ptr6 = ptr7;
							if (LZ4HC_encodeSequence(&ptr, &ptr7, &ptr2, num2, ptr9, limit, ptr8) == 0)
							{
								break;
							}
						}
						else
						{
							if (ptr14 < ptr && ptr10 < ptr + num3)
							{
								ptr = ptr14;
								ptr9 = ptr15;
								num2 = num3;
							}
							if (ptr10 - ptr < 3)
							{
								num2 = num4;
								ptr = ptr10;
								ptr9 = ptr11;
								continue;
							}
							while (true)
							{
								if (ptr10 - ptr < 18)
								{
									int num5 = num2;
									if (num5 > 18)
									{
										num5 = 18;
									}
									if (ptr + num5 > ptr10 + num4 - 4)
									{
										num5 = (int)(ptr10 - ptr) + num4 - 4;
									}
									int num6 = num5 - (int)(ptr10 - ptr);
									if (num6 > 0)
									{
										ptr10 += num6;
										ptr11 += num6;
										num4 -= num6;
									}
								}
								num7 = ((ptr10 + num4 > ptr4) ? num4 : LZ4HC_InsertAndGetWiderMatch(ctx, ptr10 + num4 - 3, ptr10, ptr5, num4, &ptr13, &ptr12, maxNbAttempts, patternAnalysis, chainSwap: false, dict, HCfavor_e.favorCompressionRatio));
								if (num7 == num4)
								{
									break;
								}
								if (ptr12 < ptr + num2 + 3)
								{
									if (ptr12 < ptr + num2)
									{
										ptr10 = ptr12;
										ptr11 = ptr13;
										num4 = num7;
										continue;
									}
									goto IL_0217;
								}
								if (ptr10 < ptr + num2)
								{
									if (ptr10 - ptr < 18)
									{
										if (num2 > 18)
										{
											num2 = 18;
										}
										if (ptr + num2 > ptr10 + num4 - 4)
										{
											num2 = (int)(ptr10 - ptr) + num4 - 4;
										}
										int num8 = num2 - (int)(ptr10 - ptr);
										if (num8 > 0)
										{
											ptr10 += num8;
											ptr11 += num8;
											num4 -= num8;
										}
									}
									else
									{
										num2 = (int)(ptr10 - ptr);
									}
								}
								ptr6 = ptr7;
								if (LZ4HC_encodeSequence(&ptr, &ptr7, &ptr2, num2, ptr9, limit, ptr8) == 0)
								{
									ptr = ptr10;
									ptr9 = ptr11;
									num2 = num4;
									ptr10 = ptr12;
									ptr11 = ptr13;
									num4 = num7;
									continue;
								}
								goto IL_043b;
							}
							if (ptr10 < ptr + num2)
							{
								num2 = (int)(ptr10 - ptr);
							}
							ptr6 = ptr7;
							if (LZ4HC_encodeSequence(&ptr, &ptr7, &ptr2, num2, ptr9, limit, ptr8) == 0)
							{
								ptr = ptr10;
								ptr6 = ptr7;
								if (LZ4HC_encodeSequence(&ptr, &ptr7, &ptr2, num4, ptr11, limit, ptr8) == 0)
								{
									break;
								}
							}
						}
						goto IL_043b;
						IL_043b:
						if (limit != limitedOutput_directive.fillOutput)
						{
							return 0;
						}
						goto IL_0440;
						IL_0217:
						if (ptr10 < ptr + num2)
						{
							int num9 = (int)(ptr + num2 - ptr10);
							ptr10 += num9;
							ptr11 += num9;
							num4 -= num9;
							if (num4 < 4)
							{
								ptr10 = ptr12;
								ptr11 = ptr13;
								num4 = num7;
							}
						}
						ptr6 = ptr7;
						if (LZ4HC_encodeSequence(&ptr, &ptr7, &ptr2, num2, ptr9, limit, ptr8) == 0)
						{
							ptr = ptr12;
							ptr9 = ptr13;
							num2 = num7;
							ptr14 = ptr10;
							ptr15 = ptr11;
							num3 = num4;
							continue;
						}
						goto IL_043b;
					}
					continue;
					IL_0440:
					ptr7 = ptr6;
					break;
				}
			}
			uint num10 = (uint)(ptr3 - ptr2);
			uint num11 = (num10 + 255 - 15) / 255;
			uint num12 = 1 + num11 + num10;
			if (limit == limitedOutput_directive.fillOutput)
			{
				ptr8 += 5;
			}
			if (limit != limitedOutput_directive.notLimited && ptr7 + num12 > ptr8)
			{
				if (limit == limitedOutput_directive.limitedOutput)
				{
					return 0;
				}
				num10 = (uint)((int)(ptr8 - ptr7) - 1);
				num11 = (num10 + 255 - 15) / 255;
				num10 -= num11;
			}
			ptr = ptr2 + num10;
			if (num10 >= 15)
			{
				uint num13 = num10 - 15;
				*(ptr7++) = 240;
				while (num13 >= 255)
				{
					*(ptr7++) = byte.MaxValue;
					num13 -= 255;
				}
				*(ptr7++) = (byte)num13;
			}
			else
			{
				*(ptr7++) = (byte)(num10 << 4);
			}
			Mem.Copy(ptr7, ptr2, (int)num10);
			ptr7 += num10;
			*srcSizePtr = (int)(ptr - source);
			return (int)(ptr7 - dest);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_compress_optimal(LZ4_streamHC_t* ctx, byte* source, byte* dst, int* srcSizePtr, int dstCapacity, int nbSearches, uint sufficient_len, limitedOutput_directive limit, bool fullUpdate, dictCtx_directive dict, HCfavor_e favorDecSpeed)
		{
			LZ4HC_optimal_t* ptr = stackalloc LZ4HC_optimal_t[4099];
			byte* ptr2 = source;
			byte* ptr3 = ptr2;
			byte* ptr4 = ptr2 + *srcSizePtr;
			byte* ptr5 = ptr4 - 12;
			byte* iHighLimit = ptr4 - 5;
			byte* ptr6 = dst;
			byte* ptr7 = dst;
			byte* ptr8 = ptr6 + dstCapacity;
			*srcSizePtr = 0;
			if (limit == limitedOutput_directive.fillOutput)
			{
				ptr8 -= 5;
			}
			if (sufficient_len >= 4096)
			{
				sufficient_len = 4095u;
			}
			while (true)
			{
				if (ptr2 > ptr5)
				{
					goto IL_06aa;
				}
				int num = (int)(ptr2 - ptr3);
				int num2 = 0;
				LZ4HC_match_t lZ4HC_match_t = LZ4HC_FindLongerMatch(ctx, ptr2, iHighLimit, 3, nbSearches, dict, favorDecSpeed);
				if (lZ4HC_match_t.len == 0)
				{
					ptr2++;
					continue;
				}
				if ((uint)lZ4HC_match_t.len > sufficient_len)
				{
					int len = lZ4HC_match_t.len;
					byte* match = ptr2 - lZ4HC_match_t.off;
					ptr7 = ptr6;
					if (LZ4HC_encodeSequence(&ptr2, &ptr6, &ptr3, len, match, limit, ptr8) == 0)
					{
						continue;
					}
					goto IL_0796;
				}
				for (int i = 0; i < 4; i++)
				{
					int price = LL.LZ4HC_literalsPrice(num + i);
					ptr[i].mlen = 1;
					ptr[i].off = 0;
					ptr[i].litlen = num + i;
					ptr[i].price = price;
				}
				int j = 4;
				int len2 = lZ4HC_match_t.len;
				int off = lZ4HC_match_t.off;
				for (; j <= len2; j++)
				{
					int price2 = LL.LZ4HC_sequencePrice(num, j);
					ptr[j].mlen = j;
					ptr[j].off = off;
					ptr[j].litlen = num;
					ptr[j].price = price2;
				}
				num2 = lZ4HC_match_t.len;
				for (int k = 1; k <= 3; k++)
				{
					ptr[num2 + k].mlen = 1;
					ptr[num2 + k].off = 0;
					ptr[num2 + k].litlen = k;
					ptr[num2 + k].price = ptr[num2].price + LL.LZ4HC_literalsPrice(k);
				}
				int num3 = 1;
				int num4;
				int off2;
				while (true)
				{
					if (num3 < num2)
					{
						byte* ptr9 = ptr2 + num3;
						if (ptr9 <= ptr5)
						{
							if (fullUpdate)
							{
								if (ptr[num3 + 1].price <= ptr[num3].price && ptr[num3 + 4].price < ptr[num3].price + 3)
								{
									goto IL_0591;
								}
							}
							else if (ptr[num3 + 1].price <= ptr[num3].price)
							{
								goto IL_0591;
							}
							LZ4HC_match_t lZ4HC_match_t2 = ((!fullUpdate) ? LZ4HC_FindLongerMatch(ctx, ptr9, iHighLimit, num2 - num3, nbSearches, dict, favorDecSpeed) : LZ4HC_FindLongerMatch(ctx, ptr9, iHighLimit, 3, nbSearches, dict, favorDecSpeed));
							if (lZ4HC_match_t2.len != 0)
							{
								if ((uint)lZ4HC_match_t2.len > sufficient_len || lZ4HC_match_t2.len + num3 >= 4096)
								{
									num4 = lZ4HC_match_t2.len;
									off2 = lZ4HC_match_t2.off;
									num2 = num3 + 1;
									break;
								}
								int litlen = ptr[num3].litlen;
								for (int l = 1; l < 4; l++)
								{
									int num5 = ptr[num3].price - LL.LZ4HC_literalsPrice(litlen) + LL.LZ4HC_literalsPrice(litlen + l);
									int num6 = num3 + l;
									if (num5 < ptr[num6].price)
									{
										ptr[num6].mlen = 1;
										ptr[num6].off = 0;
										ptr[num6].litlen = litlen + l;
										ptr[num6].price = num5;
									}
								}
								int len3 = lZ4HC_match_t2.len;
								for (int m = 4; m <= len3; m++)
								{
									int num7 = num3 + m;
									int off3 = lZ4HC_match_t2.off;
									int num8;
									int num9;
									if (ptr[num3].mlen == 1)
									{
										num8 = ptr[num3].litlen;
										num9 = ((num3 > num8) ? ptr[num3 - num8].price : 0) + LL.LZ4HC_sequencePrice(num8, m);
									}
									else
									{
										num8 = 0;
										num9 = ptr[num3].price + LL.LZ4HC_sequencePrice(0, m);
									}
									if (num7 > num2 + 3 || num9 <= (int)(ptr[num7].price - favorDecSpeed))
									{
										if (m == len3 && num2 < num7)
										{
											num2 = num7;
										}
										ptr[num7].mlen = m;
										ptr[num7].off = off3;
										ptr[num7].litlen = num8;
										ptr[num7].price = num9;
									}
								}
								for (int n = 1; n <= 3; n++)
								{
									ptr[num2 + n].mlen = 1;
									ptr[num2 + n].off = 0;
									ptr[num2 + n].litlen = n;
									ptr[num2 + n].price = ptr[num2].price + LL.LZ4HC_literalsPrice(n);
								}
							}
							goto IL_0591;
						}
					}
					num4 = ptr[num2].mlen;
					off2 = ptr[num2].off;
					num3 = num2 - num4;
					break;
					IL_0591:
					num3++;
				}
				int num10 = num3;
				int mlen = num4;
				int off4 = off2;
				while (true)
				{
					int mlen2 = ptr[num10].mlen;
					int off5 = ptr[num10].off;
					ptr[num10].mlen = mlen;
					ptr[num10].off = off4;
					mlen = mlen2;
					off4 = off5;
					if (mlen2 > num10)
					{
						break;
					}
					num10 -= mlen2;
				}
				int num11 = 0;
				while (num11 < num2)
				{
					int mlen3 = ptr[num11].mlen;
					int off6 = ptr[num11].off;
					if (mlen3 == 1)
					{
						ptr2++;
						num11++;
						continue;
					}
					num11 += mlen3;
					ptr7 = ptr6;
					if (LZ4HC_encodeSequence(&ptr2, &ptr6, &ptr3, mlen3, ptr2 - off6, limit, ptr8) == 0)
					{
						continue;
					}
					goto IL_0796;
				}
				continue;
				IL_0796:
				if (limit != limitedOutput_directive.fillOutput)
				{
					break;
				}
				ptr6 = ptr7;
				goto IL_06aa;
				IL_06aa:
				uint num12 = (uint)(ptr4 - ptr3);
				uint num13 = (num12 + 255 - 15) / 255;
				uint num14 = 1 + num13 + num12;
				if (limit == limitedOutput_directive.fillOutput)
				{
					ptr8 += 5;
				}
				if (limit != limitedOutput_directive.notLimited && ptr6 + num14 > ptr8)
				{
					if (limit == limitedOutput_directive.limitedOutput)
					{
						return 0;
					}
					num12 = (uint)((int)(ptr8 - ptr6) - 1);
					num13 = (num12 + 255 - 15) / 255;
					num12 -= num13;
				}
				ptr2 = ptr3 + num12;
				if (num12 >= 15)
				{
					uint num15 = num12 - 15;
					*(ptr6++) = 240;
					while (num15 >= 255)
					{
						*(ptr6++) = byte.MaxValue;
						num15 -= 255;
					}
					*(ptr6++) = (byte)num15;
				}
				else
				{
					*(ptr6++) = (byte)(num12 << 4);
				}
				Mem.Copy(ptr6, ptr3, (int)num12);
				ptr6 += num12;
				*srcSizePtr = (int)(ptr2 - source);
				return (int)(ptr6 - dst);
			}
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_compress_generic_internal(LZ4_streamHC_t* ctx, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, int cLevel, limitedOutput_directive limit, dictCtx_directive dict)
		{
			if (limit == limitedOutput_directive.fillOutput && dstCapacity < 1)
			{
				return 0;
			}
			if ((uint)(*srcSizePtr) > 2113929216u)
			{
				return 0;
			}
			ctx->end += *srcSizePtr;
			if (cLevel < 1)
			{
				cLevel = 9;
			}
			cLevel = LL.MIN(12, cLevel);
			cParams_t cParams_t = clTable[cLevel];
			HCfavor_e favorDecSpeed = (ctx->favorDecSpeed ? HCfavor_e.favorDecompressionSpeed : HCfavor_e.favorCompressionRatio);
			int num = ((cParams_t.strat != lz4hc_strat_e.lz4hc) ? LZ4HC_compress_optimal(ctx, src, dst, srcSizePtr, dstCapacity, (int)cParams_t.nbSearches, cParams_t.targetLength, limit, cLevel == 12, dict, favorDecSpeed) : LZ4HC_compress_hashChain(ctx, src, dst, srcSizePtr, dstCapacity, (int)cParams_t.nbSearches, limit, dict));
			if (num <= 0)
			{
				ctx->dirty = true;
			}
			return num;
		}

		public unsafe static int LZ4HC_compress_generic_noDictCtx(LZ4_streamHC_t* ctx, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, int cLevel, limitedOutput_directive limit)
		{
			return LZ4HC_compress_generic_internal(ctx, src, dst, srcSizePtr, dstCapacity, cLevel, limit, dictCtx_directive.noDictCtx);
		}

		public unsafe static int LZ4HC_compress_generic_dictCtx(LZ4_streamHC_t* ctx, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, int cLevel, limitedOutput_directive limit)
		{
			uint num = (uint)(int)(ctx->end - ctx->@base) - ctx->lowLimit;
			if (num >= 65536)
			{
				ctx->dictCtx = null;
				return LZ4HC_compress_generic_noDictCtx(ctx, src, dst, srcSizePtr, dstCapacity, cLevel, limit);
			}
			if (num == 0 && *srcSizePtr > 4096)
			{
				Mem.Copy((byte*)ctx, (byte*)ctx->dictCtx, sizeof(LZ4_streamHC_t));
				LL.LZ4HC_setExternalDict(ctx, src);
				ctx->compressionLevel = (short)cLevel;
				return LZ4HC_compress_generic_noDictCtx(ctx, src, dst, srcSizePtr, dstCapacity, cLevel, limit);
			}
			return LZ4HC_compress_generic_internal(ctx, src, dst, srcSizePtr, dstCapacity, cLevel, limit, dictCtx_directive.usingDictCtxHc);
		}

		public unsafe static int LZ4HC_compress_generic(LZ4_streamHC_t* ctx, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, int cLevel, limitedOutput_directive limit)
		{
			if (ctx->dictCtx == null)
			{
				return LZ4HC_compress_generic_noDictCtx(ctx, src, dst, srcSizePtr, dstCapacity, cLevel, limit);
			}
			return LZ4HC_compress_generic_dictCtx(ctx, src, dst, srcSizePtr, dstCapacity, cLevel, limit);
		}

		public unsafe static int LZ4_compressHC_continue_generic(LZ4_streamHC_t* LZ4_streamHCPtr, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, limitedOutput_directive limit)
		{
			if (LZ4_streamHCPtr->@base == null)
			{
				LL.LZ4HC_init_internal(LZ4_streamHCPtr, src);
			}
			if ((uint)(LZ4_streamHCPtr->end - LZ4_streamHCPtr->@base) > 2147483648u)
			{
				uint num = (uint)(int)(LZ4_streamHCPtr->end - LZ4_streamHCPtr->@base) - LZ4_streamHCPtr->dictLimit;
				if (num > 65536)
				{
					num = 65536u;
				}
				LL.LZ4_loadDictHC(LZ4_streamHCPtr, LZ4_streamHCPtr->end - num, (int)num);
			}
			if (src != LZ4_streamHCPtr->end)
			{
				LL.LZ4HC_setExternalDict(LZ4_streamHCPtr, src);
			}
			byte* ptr = src + *srcSizePtr;
			byte* ptr2 = LZ4_streamHCPtr->dictBase + LZ4_streamHCPtr->lowLimit;
			byte* ptr3 = LZ4_streamHCPtr->dictBase + LZ4_streamHCPtr->dictLimit;
			if (ptr > ptr2 && src < ptr3)
			{
				if (ptr > ptr3)
				{
					ptr = ptr3;
				}
				LZ4_streamHCPtr->lowLimit = (uint)(ptr - LZ4_streamHCPtr->dictBase);
				if (LZ4_streamHCPtr->dictLimit - LZ4_streamHCPtr->lowLimit < 4)
				{
					LZ4_streamHCPtr->lowLimit = LZ4_streamHCPtr->dictLimit;
				}
			}
			return LZ4HC_compress_generic(LZ4_streamHCPtr, src, dst, srcSizePtr, dstCapacity, LZ4_streamHCPtr->compressionLevel, limit);
		}

		public unsafe static int LZ4_compress_HC_continue(LZ4_streamHC_t* LZ4_streamHCPtr, byte* src, byte* dst, int srcSize, int dstCapacity)
		{
			if (dstCapacity < LL.LZ4_compressBound(srcSize))
			{
				return LZ4_compressHC_continue_generic(LZ4_streamHCPtr, src, dst, &srcSize, dstCapacity, limitedOutput_directive.limitedOutput);
			}
			return LZ4_compressHC_continue_generic(LZ4_streamHCPtr, src, dst, &srcSize, dstCapacity, limitedOutput_directive.notLimited);
		}

		public unsafe static int LZ4_compress_HC_continue_destSize(LZ4_streamHC_t* LZ4_streamHCPtr, byte* src, byte* dst, int* srcSizePtr, int targetDestSize)
		{
			return LZ4_compressHC_continue_generic(LZ4_streamHCPtr, src, dst, srcSizePtr, targetDestSize, limitedOutput_directive.fillOutput);
		}

		public unsafe static int LZ4_compress_HC_destSize(LZ4_streamHC_t* state, byte* source, byte* dest, int* sourceSizePtr, int targetDestSize, int cLevel)
		{
			LZ4_streamHC_t* ptr = LL.LZ4_initStreamHC(state);
			if (ptr == null)
			{
				return 0;
			}
			LL.LZ4HC_init_internal(ptr, source);
			LL.LZ4_setCompressionLevel(ptr, cLevel);
			return LZ4HC_compress_generic(ptr, source, dest, sourceSizePtr, targetDestSize, cLevel, limitedOutput_directive.fillOutput);
		}

		public unsafe static int LZ4_compress_HC_extStateHC_fastReset(LZ4_streamHC_t* state, byte* src, byte* dst, int srcSize, int dstCapacity, int compressionLevel)
		{
			if (((uint)state & (sizeof(void*) - 1)) != 0L)
			{
				return 0;
			}
			LL.LZ4_resetStreamHC_fast(state, compressionLevel);
			LL.LZ4HC_init_internal(state, src);
			if (dstCapacity < LL.LZ4_compressBound(srcSize))
			{
				return LZ4HC_compress_generic(state, src, dst, &srcSize, dstCapacity, compressionLevel, limitedOutput_directive.limitedOutput);
			}
			return LZ4HC_compress_generic(state, src, dst, &srcSize, dstCapacity, compressionLevel, limitedOutput_directive.notLimited);
		}

		public unsafe static int LZ4_compress_HC_extStateHC(LZ4_streamHC_t* state, byte* src, byte* dst, int srcSize, int dstCapacity, int compressionLevel)
		{
			if (LL.LZ4_initStreamHC(state) == null)
			{
				return 0;
			}
			return LZ4_compress_HC_extStateHC_fastReset(state, src, dst, srcSize, dstCapacity, compressionLevel);
		}

		public unsafe static int LZ4_compress_HC(byte* src, byte* dst, int srcSize, int dstCapacity, int compressionLevel)
		{
			PinnedMemory.Alloc(out var memory, sizeof(LZ4_streamHC_t), zero: false);
			try
			{
				return LZ4_compress_HC_extStateHC(memory.Reference<LZ4_streamHC_t>(), src, dst, srcSize, dstCapacity, compressionLevel);
			}
			finally
			{
				memory.Free();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static uint LZ4_NbCommonBytes(ulong val)
		{
			return DeBruijnBytePos[(uint)((val & (0L - val)) * 151050438428048703L >> 58)];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static uint LZ4_count(byte* pIn, byte* pMatch, byte* pInLimit)
		{
			byte* ptr = pIn;
			if (pIn < pInLimit - 7)
			{
				ulong num = Mem64.PeekW(pMatch) ^ Mem64.PeekW(pIn);
				if (num != 0L)
				{
					return LZ4_NbCommonBytes(num);
				}
				pIn += 8;
				pMatch += 8;
			}
			while (pIn < pInLimit - 7)
			{
				ulong num2 = Mem64.PeekW(pMatch) ^ Mem64.PeekW(pIn);
				if (num2 != 0L)
				{
					return (uint)(pIn + LZ4_NbCommonBytes(num2) - ptr);
				}
				pIn += 8;
				pMatch += 8;
			}
			if (pIn < pInLimit - 3 && Mem64.Peek4(pMatch) == Mem64.Peek4(pIn))
			{
				pIn += 4;
				pMatch += 4;
			}
			if (pIn < pInLimit - 1 && Mem64.Peek2(pMatch) == Mem64.Peek2(pIn))
			{
				pIn += 2;
				pMatch += 2;
			}
			if (pIn < pInLimit && *pMatch == *pIn)
			{
				pIn++;
			}
			return (uint)(pIn - ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static uint LZ4_hashPosition(void* p, tableType_t tableType)
		{
			if (tableType != tableType_t.byU16)
			{
				return LL.LZ4_hash5(Mem64.PeekW(p), tableType);
			}
			return LL.LZ4_hash4(Mem64.Peek4(p), tableType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static void LZ4_putPosition(byte* p, void* tableBase, tableType_t tableType, byte* srcBase)
		{
			LL.LZ4_putPositionOnHash(p, LZ4_hashPosition(p, tableType), tableBase, tableType, srcBase);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static byte* LZ4_getPosition(byte* p, void* tableBase, tableType_t tableType, byte* srcBase)
		{
			return LL.LZ4_getPositionOnHash(LZ4_hashPosition(p, tableType), tableBase, tableType, srcBase);
		}

		protected unsafe static void LZ4_renormDictT(LZ4_stream_t* LZ4_dict, int nextSize)
		{
			if ((uint)((int)LZ4_dict->currentOffset + nextSize) <= 2147483648u)
			{
				return;
			}
			uint num = LZ4_dict->currentOffset - 65536;
			byte* ptr = LZ4_dict->dictionary + LZ4_dict->dictSize;
			for (int i = 0; i < 4096; i++)
			{
				if (LZ4_dict->hashTable[i] < num)
				{
					LZ4_dict->hashTable[i] = 0u;
				}
				else
				{
					LZ4_dict->hashTable[i] -= num;
				}
			}
			LZ4_dict->currentOffset = 65536u;
			if (LZ4_dict->dictSize > 65536)
			{
				LZ4_dict->dictSize = 65536u;
			}
			LZ4_dict->dictionary = ptr - LZ4_dict->dictSize;
		}

		public unsafe int LZ4_loadDict(LZ4_stream_t* LZ4_dict, byte* dictionary, int dictSize)
		{
			byte* ptr = dictionary;
			byte* ptr2 = ptr + dictSize;
			LL.LZ4_initStream(LZ4_dict);
			LZ4_dict->currentOffset += 65536u;
			if (dictSize < 8)
			{
				return 0;
			}
			if (ptr2 - ptr > 65536)
			{
				ptr = ptr2 - 65536;
			}
			byte* srcBase = ptr2 - LZ4_dict->currentOffset;
			LZ4_dict->dictionary = ptr;
			LZ4_dict->dictSize = (uint)(ptr2 - ptr);
			LZ4_dict->tableType = tableType_t.byU32;
			for (; ptr <= ptr2 - 8; ptr += 3)
			{
				LZ4_putPosition(ptr, LZ4_dict->hashTable, tableType_t.byU32, srcBase);
			}
			return (int)LZ4_dict->dictSize;
		}
	}
}
namespace K4os.Compression.LZ4.Encoders
{
	public enum EncoderAction
	{
		None,
		Loaded,
		Copied,
		Encoded
	}
	public interface ILZ4Decoder : IDisposable
	{
		int BlockSize { get; }

		int BytesReady { get; }

		unsafe int Decode(byte* source, int length, int blockSize = 0);

		unsafe int Inject(byte* source, int length);

		unsafe void Drain(byte* target, int offset, int length);

		unsafe byte* Peek(int offset);
	}
	public interface ILZ4Encoder : IDisposable
	{
		int BlockSize { get; }

		int BytesReady { get; }

		unsafe int Topup(byte* source, int length);

		unsafe int Encode(byte* target, int length, bool allowCopy);
	}
	public class LZ4BlockDecoder : UnmanagedResources, ILZ4Decoder, IDisposable
	{
		private PinnedMemory _outputBufferPin;

		private readonly int _outputLength;

		private int _outputIndex;

		private readonly int _blockSize;

		private unsafe byte* OutputBuffer => _outputBufferPin.Pointer;

		public int BlockSize => _blockSize;

		public int BytesReady => _outputIndex;

		public LZ4BlockDecoder(int blockSize)
		{
			blockSize = Mem.RoundUp(Math.Max(blockSize, 1024), 1024);
			_blockSize = blockSize;
			_outputLength = _blockSize + 8;
			_outputIndex = 0;
			PinnedMemory.Alloc(out _outputBufferPin, _outputLength + 8, zero: false);
		}

		public unsafe int Decode(byte* source, int length, int blockSize = 0)
		{
			ThrowIfDisposed();
			if (blockSize <= 0)
			{
				blockSize = _blockSize;
			}
			if (blockSize > _blockSize)
			{
				throw new InvalidOperationException();
			}
			int num = LZ4Codec.Decode(source, length, OutputBuffer, _outputLength);
			if (num < 0)
			{
				throw new InvalidOperationException();
			}
			_outputIndex = num;
			return _outputIndex;
		}

		public unsafe int Inject(byte* source, int length)
		{
			ThrowIfDisposed();
			if (length <= 0)
			{
				return _outputIndex = 0;
			}
			if (length > _outputLength)
			{
				throw new InvalidOperationException();
			}
			Mem.Move(OutputBuffer, source, length);
			_outputIndex = length;
			return length;
		}

		public unsafe void Drain(byte* target, int offset, int length)
		{
			ThrowIfDisposed();
			offset = _outputIndex + offset;
			if (offset < 0 || length < 0 || offset + length > _outputIndex)
			{
				throw new InvalidOperationException();
			}
			Mem.Move(target, OutputBuffer + offset, length);
		}

		public unsafe byte* Peek(int offset)
		{
			ThrowIfDisposed();
			offset = _outputIndex + offset;
			if (offset < 0 || offset > _outputIndex)
			{
				throw new InvalidOperationException();
			}
			return OutputBuffer + offset;
		}

		protected override void ReleaseUnmanaged()
		{
			base.ReleaseUnmanaged();
			_outputBufferPin.Free();
		}
	}
	public class LZ4BlockEncoder : LZ4EncoderBase
	{
		private readonly LZ4Level _level;

		public LZ4BlockEncoder(LZ4Level level, int blockSize)
			: base(chaining: false, blockSize, 0)
		{
			_level = level;
		}

		protected unsafe override int EncodeBlock(byte* source, int sourceLength, byte* target, int targetLength)
		{
			return LZ4Codec.Encode(source, sourceLength, target, targetLength, _level);
		}

		protected unsafe override int CopyDict(byte* target, int dictionaryLength)
		{
			return 0;
		}
	}
	public class LZ4ChainDecoder : UnmanagedResources, ILZ4Decoder, IDisposable
	{
		private PinnedMemory _outputBufferPin;

		private PinnedMemory _contextPin;

		private readonly int _blockSize;

		private readonly int _outputLength;

		private int _outputIndex;

		private unsafe byte* OutputBuffer => _outputBufferPin.Pointer;

		private unsafe LL.LZ4_streamDecode_t* Context => _contextPin.Reference<LL.LZ4_streamDecode_t>();

		public int BlockSize => _blockSize;

		public int BytesReady => _outputIndex;

		public LZ4ChainDecoder(int blockSize, int extraBlocks)
		{
			blockSize = Mem.RoundUp(Math.Max(blockSize, 1024), 1024);
			extraBlocks = Math.Max(extraBlocks, 0);
			_blockSize = blockSize;
			_outputLength = 65536 + (1 + extraBlocks) * _blockSize + 32;
			_outputIndex = 0;
			PinnedMemory.Alloc<LL.LZ4_streamDecode_t>(out _contextPin);
			PinnedMemory.Alloc(out _outputBufferPin, _outputLength + 8, zero: false);
		}

		public unsafe int Decode(byte* source, int length, int blockSize)
		{
			if (blockSize <= 0)
			{
				blockSize = _blockSize;
			}
			Prepare(blockSize);
			int num = DecodeBlock(source, length, OutputBuffer + _outputIndex, blockSize);
			if (num < 0)
			{
				throw new InvalidOperationException();
			}
			_outputIndex += num;
			return num;
		}

		public unsafe int Inject(byte* source, int length)
		{
			if (length <= 0)
			{
				return 0;
			}
			if (length > Math.Max(_blockSize, 65536))
			{
				throw new InvalidOperationException();
			}
			byte* outputBuffer = OutputBuffer;
			if (_outputIndex + length < _outputLength)
			{
				Mem.Move(outputBuffer + _outputIndex, source, length);
				_outputIndex = ApplyDict(_outputIndex + length);
			}
			else if (length >= 65536)
			{
				Mem.Move(outputBuffer, source, length);
				_outputIndex = ApplyDict(length);
			}
			else
			{
				int num = Math.Min(65536 - length, _outputIndex);
				Mem.Move(outputBuffer, outputBuffer + _outputIndex - num, num);
				Mem.Move(outputBuffer + num, source, length);
				_outputIndex = ApplyDict(num + length);
			}
			return length;
		}

		public unsafe void Drain(byte* target, int offset, int length)
		{
			offset = _outputIndex + offset;
			if (offset < 0 || length < 0 || offset + length > _outputIndex)
			{
				throw new InvalidOperationException();
			}
			Mem.Move(target, OutputBuffer + offset, length);
		}

		public unsafe byte* Peek(int offset)
		{
			ThrowIfDisposed();
			offset = _outputIndex + offset;
			if (offset < 0 || offset > _outputIndex)
			{
				throw new InvalidOperationException();
			}
			return OutputBuffer + offset;
		}

		private void Prepare(int blockSize)
		{
			if (_outputIndex + blockSize > _outputLength)
			{
				_outputIndex = CopyDict(_outputIndex);
			}
		}

		private unsafe int CopyDict(int index)
		{
			int num = Math.Max(index - 65536, 0);
			int num2 = index - num;
			Mem.Move(OutputBuffer, OutputBuffer + num, num2);
			LL.LZ4_setStreamDecode(Context, OutputBuffer, num2);
			return num2;
		}

		private unsafe int ApplyDict(int index)
		{
			int num = Math.Max(index - 65536, 0);
			int dictSize = index - num;
			LL.LZ4_setStreamDecode(Context, OutputBuffer + num, dictSize);
			return index;
		}

		private unsafe int DecodeBlock(byte* source, int sourceLength, byte* target, int targetLength)
		{
			return LLxx.LZ4_decompress_safe_continue(Context, source, target, sourceLength, targetLength);
		}

		protected override void ReleaseUnmanaged()
		{
			base.ReleaseUnmanaged();
			_contextPin.Free();
			_outputBufferPin.Free();
		}
	}
	public static class LZ4Decoder
	{
		public static ILZ4Decoder Create(bool chaining, int blockSize, int extraBlocks = 0)
		{
			if (chaining)
			{
				return CreateChainDecoder(blockSize, extraBlocks);
			}
			return CreateBlockDecoder(blockSize);
		}

		private static ILZ4Decoder CreateChainDecoder(int blockSize, int extraBlocks)
		{
			return new LZ4ChainDecoder(blockSize, extraBlocks);
		}

		private static ILZ4Decoder CreateBlockDecoder(int blockSize)
		{
			return new LZ4BlockDecoder(blockSize);
		}
	}
	public static class LZ4Encoder
	{
		public static ILZ4Encoder Create(bool chaining, LZ4Level level, int blockSize, int extraBlocks = 0)
		{
			if (chaining)
			{
				if (level >= LZ4Level.L03_HC)
				{
					return CreateHighEncoder(level, blockSize, extraBlocks);
				}
				return CreateFastEncoder(blockSize, extraBlocks);
			}
			return CreateBlockEncoder(level, blockSize);
		}

		private static ILZ4Encoder CreateBlockEncoder(LZ4Level level, int blockSize)
		{
			return new LZ4BlockEncoder(level, blockSize);
		}

		private static ILZ4Encoder CreateFastEncoder(int blockSize, int extraBlocks)
		{
			return new LZ4FastChainEncoder(blockSize, extraBlocks);
		}

		private static ILZ4Encoder CreateHighEncoder(LZ4Level level, int blockSize, int extraBlocks)
		{
			return new LZ4HighChainEncoder(level, blockSize, extraBlocks);
		}
	}
	public abstract class LZ4EncoderBase : UnmanagedResources, ILZ4Encoder, IDisposable
	{
		private PinnedMemory _inputBufferPin;

		private readonly int _inputLength;

		private readonly int _blockSize;

		private int _inputIndex;

		private int _inputPointer;

		private unsafe byte* InputBuffer => _inputBufferPin.Pointer;

		public int BlockSize => _blockSize;

		public int BytesReady => _inputPointer - _inputIndex;

		protected LZ4EncoderBase(bool chaining, int blockSize, int extraBlocks)
		{
			blockSize = Mem.RoundUp(Math.Max(blockSize, 1024), 1024);
			extraBlocks = Math.Max(extraBlocks, 0);
			int num = (chaining ? 65536 : 0);
			_blockSize = blockSize;
			_inputLength = num + (1 + extraBlocks) * blockSize + 32;
			_inputIndex = (_inputPointer = 0);
			PinnedMemory.Alloc(out _inputBufferPin, _inputLength + 8, zero: false);
		}

		public unsafe int Topup(byte* source, int length)
		{
			ThrowIfDisposed();
			if (length == 0)
			{
				return 0;
			}
			int num = _inputIndex + _blockSize - _inputPointer;
			if (num <= 0)
			{
				return 0;
			}
			int num2 = Math.Min(num, length);
			Mem.Move(InputBuffer + _inputPointer, source, num2);
			_inputPointer += num2;
			return num2;
		}

		public unsafe int Encode(byte* target, int length, bool allowCopy)
		{
			ThrowIfDisposed();
			int num = _inputPointer - _inputIndex;
			if (num <= 0)
			{
				return 0;
			}
			int num2 = EncodeBlock(InputBuffer + _inputIndex, num, target, length);
			if (num2 <= 0)
			{
				throw new InvalidOperationException("Failed to encode chunk. Target buffer too small.");
			}
			if (allowCopy && num2 >= num)
			{
				Mem.Move(target, InputBuffer + _inputIndex, num);
				num2 = -num;
			}
			Commit();
			return num2;
		}

		private unsafe void Commit()
		{
			_inputIndex = _inputPointer;
			if (_inputIndex + _blockSize > _inputLength)
			{
				_inputIndex = (_inputPointer = CopyDict(InputBuffer, _inputPointer));
			}
		}

		protected unsafe abstract int EncodeBlock(byte* source, int sourceLength, byte* target, int targetLength);

		protected unsafe abstract int CopyDict(byte* target, int dictionaryLength);

		protected override void ReleaseUnmanaged()
		{
			base.ReleaseUnmanaged();
			_inputBufferPin.Free();
		}
	}
	public static class LZ4EncoderExtensions
	{
		public unsafe static bool Topup(this ILZ4Encoder encoder, ref byte* source, int length)
		{
			int num = encoder.Topup(source, length);
			source += num;
			return num != 0;
		}

		public unsafe static int Topup(this ILZ4Encoder encoder, byte[] source, int offset, int length)
		{
			fixed (byte* ptr = source)
			{
				return encoder.Topup(ptr + offset, length);
			}
		}

		public static bool Topup(this ILZ4Encoder encoder, byte[] source, ref int offset, int length)
		{
			int num = encoder.Topup(source, offset, length);
			offset += num;
			return num != 0;
		}

		public unsafe static int Encode(this ILZ4Encoder encoder, byte[] target, int offset, int length, bool allowCopy)
		{
			fixed (byte* ptr = target)
			{
				return encoder.Encode(ptr + offset, length, allowCopy);
			}
		}

		public static EncoderAction Encode(this ILZ4Encoder encoder, byte[] target, ref int offset, int length, bool allowCopy)
		{
			int num = encoder.Encode(target, offset, length, allowCopy);
			offset += Math.Abs(num);
			if (num != 0)
			{
				if (num >= 0)
				{
					return EncoderAction.Encoded;
				}
				return EncoderAction.Copied;
			}
			return EncoderAction.None;
		}

		public unsafe static EncoderAction Encode(this ILZ4Encoder encoder, ref byte* target, int length, bool allowCopy)
		{
			int num = encoder.Encode(target, length, allowCopy);
			target += Math.Abs(num);
			if (num != 0)
			{
				if (num >= 0)
				{
					return EncoderAction.Encoded;
				}
				return EncoderAction.Copied;
			}
			return EncoderAction.None;
		}

		public unsafe static EncoderAction TopupAndEncode(this ILZ4Encoder encoder, byte* source, int sourceLength, byte* target, int targetLength, bool forceEncode, bool allowCopy, out int loaded, out int encoded)
		{
			loaded = 0;
			encoded = 0;
			if (sourceLength > 0)
			{
				loaded = encoder.Topup(source, sourceLength);
			}
			return encoder.FlushAndEncode(target, targetLength, forceEncode, allowCopy, loaded, out encoded);
		}

		public unsafe static EncoderAction TopupAndEncode(this ILZ4Encoder encoder, byte[] source, int sourceOffset, int sourceLength, byte[] target, int targetOffset, int targetLength, bool forceEncode, bool allowCopy, out int loaded, out int encoded)
		{
			fixed (byte* ptr = source)
			{
				fixed (byte* ptr2 = target)
				{
					return encoder.TopupAndEncode(ptr + sourceOffset, sourceLength, ptr2 + targetOffset, targetLength, forceEncode, allowCopy, out loaded, out encoded);
				}
			}
		}

		public unsafe static EncoderAction TopupAndEncode(this ILZ4Encoder encoder, ReadOnlySpan<byte> source, Span<byte> target, bool forceEncode, bool allowCopy, out int loaded, out int encoded)
		{
			fixed (byte* source2 = source)
			{
				fixed (byte* target2 = target)
				{
					return encoder.TopupAndEncode(source2, source.Length, target2, target.Length, forceEncode, allowCopy, out loaded, out encoded);
				}
			}
		}

		private unsafe static EncoderAction FlushAndEncode(this ILZ4Encoder encoder, byte* target, int targetLength, bool forceEncode, bool allowCopy, int loaded, out int encoded)
		{
			encoded = 0;
			int blockSize = encoder.BlockSize;
			if (encoder.BytesReady < (forceEncode ? 1 : blockSize))
			{
				if (loaded <= 0)
				{
					return EncoderAction.None;
				}
				return EncoderAction.Loaded;
			}
			encoded = encoder.Encode(target, targetLength, allowCopy);
			if (!allowCopy || encoded >= 0)
			{
				return EncoderAction.Encoded;
			}
			encoded = -encoded;
			return EncoderAction.Copied;
		}

		public unsafe static EncoderAction FlushAndEncode(this ILZ4Encoder encoder, byte* target, int targetLength, bool allowCopy, out int encoded)
		{
			return encoder.FlushAndEncode(target, targetLength, forceEncode: true, allowCopy, 0, out encoded);
		}

		public unsafe static EncoderAction FlushAndEncode(this ILZ4Encoder encoder, byte[] target, int targetOffset, int targetLength, bool allowCopy, out int encoded)
		{
			fixed (byte* ptr = target)
			{
				return encoder.FlushAndEncode(ptr + targetOffset, targetLength, forceEncode: true, allowCopy, 0, out encoded);
			}
		}

		public unsafe static EncoderAction FlushAndEncode(this ILZ4Encoder encoder, Span<byte> target, bool allowCopy, out int encoded)
		{
			fixed (byte* target2 = target)
			{
				return encoder.FlushAndEncode(target2, target.Length, forceEncode: true, allowCopy, 0, out encoded);
			}
		}

		public unsafe static void Drain(this ILZ4Decoder decoder, byte[] target, int targetOffset, int offset, int length)
		{
			fixed (byte* ptr = target)
			{
				decoder.Drain(ptr + targetOffset, offset, length);
			}
		}

		public unsafe static void Drain(this ILZ4Decoder decoder, Span<byte> target, int offset, int length)
		{
			fixed (byte* target2 = target)
			{
				decoder.Drain(target2, offset, length);
			}
		}

		public unsafe static bool DecodeAndDrain(this ILZ4Decoder decoder, byte* source, int sourceLength, byte* target, int targetLength, out int decoded)
		{
			decoded = 0;
			if (sourceLength <= 0)
			{
				return false;
			}
			decoded = decoder.Decode(source, sourceLength);
			if (decoded <= 0 || targetLength < decoded)
			{
				return false;
			}
			decoder.Drain(target, -decoded, decoded);
			return true;
		}

		public unsafe static bool DecodeAndDrain(this ILZ4Decoder decoder, byte[] source, int sourceOffset, int sourceLength, byte[] target, int targetOffset, int targetLength, out int decoded)
		{
			fixed (byte* ptr = source)
			{
				fixed (byte* ptr2 = target)
				{
					return decoder.DecodeAndDrain(ptr + sourceOffset, sourceLength, ptr2 + targetOffset, targetLength, out decoded);
				}
			}
		}

		public unsafe static bool DecodeAndDrain(this ILZ4Decoder decoder, ReadOnlySpan<byte> source, Span<byte> target, out int decoded)
		{
			fixed (byte* source2 = source)
			{
				fixed (byte* target2 = target)
				{
					return decoder.DecodeAndDrain(source2, source.Length, target2, target.Length, out decoded);
				}
			}
		}

		public unsafe static int Inject(this ILZ4Decoder decoder, byte[] buffer, int offset, int length)
		{
			fixed (byte* ptr = buffer)
			{
				return decoder.Inject(ptr + offset, length);
			}
		}

		public unsafe static int Decode(this ILZ4Decoder decoder, byte[] buffer, int offset, int length, int blockSize = 0)
		{
			fixed (byte* ptr = buffer)
			{
				return decoder.Decode(ptr + offset, length, blockSize);
			}
		}
	}
	public class LZ4FastChainEncoder : LZ4EncoderBase
	{
		private PinnedMemory _contextPin;

		private unsafe LL.LZ4_stream_t* Context => _contextPin.Reference<LL.LZ4_stream_t>();

		public LZ4FastChainEncoder(int blockSize, int extraBlocks = 0)
			: base(chaining: true, blockSize, extraBlocks)
		{
			PinnedMemory.Alloc<LL.LZ4_stream_t>(out _contextPin);
		}

		protected override void ReleaseUnmanaged()
		{
			base.ReleaseUnmanaged();
			_contextPin.Free();
		}

		protected unsafe override int EncodeBlock(byte* source, int sourceLength, byte* target, int targetLength)
		{
			return LLxx.LZ4_compress_fast_continue(Context, source, target, sourceLength, targetLength, 1);
		}

		protected unsafe override int CopyDict(byte* target, int length)
		{
			return LL.LZ4_saveDict(Context, target, length);
		}
	}
	public class LZ4HighChainEncoder : LZ4EncoderBase
	{
		private PinnedMemory _contextPin;

		private unsafe LL.LZ4_streamHC_t* Context => _contextPin.Reference<LL.LZ4_streamHC_t>();

		public unsafe LZ4HighChainEncoder(LZ4Level level, int blockSize, int extraBlocks = 0)
			: base(chaining: true, blockSize, extraBlocks)
		{
			if (level < LZ4Level.L03_HC)
			{
				level = LZ4Level.L03_HC;
			}
			if (level > LZ4Level.L12_MAX)
			{
				level = LZ4Level.L12_MAX;
			}
			PinnedMemory.Alloc<LL.LZ4_streamHC_t>(out _contextPin, zero: false);
			LL.LZ4_initStreamHC(Context);
			LL.LZ4_resetStreamHC_fast(Context, (int)level);
		}

		protected override void ReleaseUnmanaged()
		{
			base.ReleaseUnmanaged();
			_contextPin.Free();
		}

		protected unsafe override int EncodeBlock(byte* source, int sourceLength, byte* target, int targetLength)
		{
			return LLxx.LZ4_compress_HC_continue(Context, source, target, sourceLength, targetLength);
		}

		protected unsafe override int CopyDict(byte* target, int length)
		{
			return LL.LZ4_saveDictHC(Context, target, length);
		}
	}
}
