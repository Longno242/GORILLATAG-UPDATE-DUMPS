#define TRACE
#define DEBUG
#define ENABLE_PROFILER
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Profiling;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = ".NET Standard 2.1")]
[assembly: AssemblyCompany("Exit Games GmbH")]
[assembly: AssemblyConfiguration("Unity Debug")]
[assembly: AssemblyCopyright("? Exit Games GmbH")]
[assembly: AssemblyFileVersion("2.0.6.1034")]
[assembly: AssemblyInformationalVersion("2.0.6.1034+94e2793d")]
[assembly: AssemblyProduct("Fusion.Common")]
[assembly: AssemblyTitle("Fusion.Common (Unity Debug)")]
[assembly: InternalsVisibleTo("Fusion.Common.Tests")]
[assembly: InternalsVisibleTo("Fusion.Sockets")]
[assembly: InternalsVisibleTo("Fusion.Sockets.Tests")]
[assembly: InternalsVisibleTo("Fusion.Runtime")]
[assembly: InternalsVisibleTo("Fusion.Realtime")]
[assembly: InternalsVisibleTo("Fusion.Plugin")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("2.0.6.0")]
[module: UnverifiableCode]
[module: RefSafetyRules(11)]
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
	[AttributeUsage(AttributeTargets.Module, AllowMultiple = false, Inherited = false)]
	internal sealed class RefSafetyRulesAttribute : Attribute
	{
		public readonly int Version;

		public RefSafetyRulesAttribute(int P_0)
		{
			Version = P_0;
		}
	}
}
namespace Fusion
{
	public struct AtomicInt(int value)
	{
		private volatile int _value = value;

		public int Value => Thread.VolatileRead(ref _value);

		public int IncrementPost()
		{
			return Interlocked.Increment(ref _value) - 1;
		}

		public int IncrementPre()
		{
			return Interlocked.Increment(ref _value);
		}

		public int Decrement()
		{
			return Interlocked.Decrement(ref _value);
		}

		public int Exchange(int value)
		{
			return Interlocked.Exchange(ref _value, value);
		}

		public int CompareExchange(int value, int assumed)
		{
			return Interlocked.CompareExchange(ref _value, value, assumed);
		}
	}
	[AttributeUsage(AttributeTargets.Field)]
	public abstract class PropertyAttribute : UnityEngine.PropertyAttribute
	{
	}
	public static class BinUtils
	{
		private static readonly string[] _byteHexValue = new string[256]
		{
			"00", "01", "02", "03", "04", "05", "06", "07", "08", "09",
			"0A", "0B", "0C", "0D", "0E", "0F", "10", "11", "12", "13",
			"14", "15", "16", "17", "18", "19", "1A", "1B", "1C", "1D",
			"1E", "1F", "20", "21", "22", "23", "24", "25", "26", "27",
			"28", "29", "2A", "2B", "2C", "2D", "2E", "2F", "30", "31",
			"32", "33", "34", "35", "36", "37", "38", "39", "3A", "3B",
			"3C", "3D", "3E", "3F", "40", "41", "42", "43", "44", "45",
			"46", "47", "48", "49", "4A", "4B", "4C", "4D", "4E", "4F",
			"50", "51", "52", "53", "54", "55", "56", "57", "58", "59",
			"5A", "5B", "5C", "5D", "5E", "5F", "60", "61", "62", "63",
			"64", "65", "66", "67", "68", "69", "6A", "6B", "6C", "6D",
			"6E", "6F", "70", "71", "72", "73", "74", "75", "76", "77",
			"78", "79", "7A", "7B", "7C", "7D", "7E", "7F", "80", "81",
			"82", "83", "84", "85", "86", "87", "88", "89", "8A", "8B",
			"8C", "8D", "8E", "8F", "90", "91", "92", "93", "94", "95",
			"96", "97", "98", "99", "9A", "9B", "9C", "9D", "9E", "9F",
			"A0", "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9",
			"AA", "AB", "AC", "AD", "AE", "AF", "B0", "B1", "B2", "B3",
			"B4", "B5", "B6", "B7", "B8", "B9", "BA", "BB", "BC", "BD",
			"BE", "BF", "C0", "C1", "C2", "C3", "C4", "C5", "C6", "C7",
			"C8", "C9", "CA", "CB", "CC", "CD", "CE", "CF", "D0", "D1",
			"D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "DA", "DB",
			"DC", "DD", "DE", "DF", "E0", "E1", "E2", "E3", "E4", "E5",
			"E6", "E7", "E8", "E9", "EA", "EB", "EC", "ED", "EE", "EF",
			"F0", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9",
			"FA", "FB", "FC", "FD", "FE", "FF"
		};

		public static string ByteToHex(byte value)
		{
			return _byteHexValue[value];
		}

		public unsafe static string BytesToHex(byte* buffer, int length, int columns = 16, string rowSeparator = "\n", string columnSeparator = " ")
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			while (num < length)
			{
				stringBuilder.Append(_byteHexValue[buffer[num++]]);
				if (num == length)
				{
					break;
				}
				if (num % columns == 0)
				{
					stringBuilder.Append(rowSeparator);
				}
				else
				{
					stringBuilder.Append(columnSeparator);
				}
			}
			return stringBuilder.ToString();
		}

		public unsafe static string WordsToHex(int* buffer, int length, int columns = 4, string rowSeparator = "\n", string columnSeparator = " ")
		{
			return WordsToHex(new ReadOnlySpan<uint>(buffer, length), columns, rowSeparator, columnSeparator);
		}

		public unsafe static string WordsToHex(uint* buffer, int length, int columns = 4, string rowSeparator = "\n", string columnSeparator = " ")
		{
			return WordsToHex(new ReadOnlySpan<uint>(buffer, length), columns, rowSeparator, columnSeparator);
		}

		public static string WordsToHex(ReadOnlySpan<int> buffer, int columns = 4, string rowSeparator = "\n", string columnSeparator = " ")
		{
			return WordsToHex(MemoryMarshal.Cast<int, uint>(buffer), columns, rowSeparator, columnSeparator);
		}

		public static string WordsToHex(ReadOnlySpan<uint> buffer, int columns = 4, string rowSeparator = "\n", string columnSeparator = " ")
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			while (num < buffer.Length)
			{
				stringBuilder.Append(_byteHexValue[0xFF & (buffer[num] >> 24)]);
				stringBuilder.Append(_byteHexValue[0xFF & (buffer[num] >> 16)]);
				stringBuilder.Append(_byteHexValue[0xFF & (buffer[num] >> 8)]);
				stringBuilder.Append(_byteHexValue[0xFF & buffer[num]]);
				if (++num % columns == 0)
				{
					stringBuilder.Append(rowSeparator);
				}
				else
				{
					stringBuilder.Append(columnSeparator);
				}
			}
			return stringBuilder.ToString();
		}

		private static bool TryHexToByte(char c, out byte result)
		{
			if (c >= '0' && c <= '9')
			{
				result = (byte)(c - 48);
				return true;
			}
			if (c >= 'a' && c <= 'f')
			{
				result = (byte)(10 + c - 97);
				return true;
			}
			if (c >= 'A' && c <= 'F')
			{
				result = (byte)(10 + c - 65);
				return true;
			}
			result = 0;
			return false;
		}

		public unsafe static int HexToBytes(string str, byte* buffer, int length)
		{
			int i = 0;
			for (int num = 0; i < str.Length && num < length; i++)
			{
				if (TryHexToByte(str[i], out var result))
				{
					i++;
					if (i == str.Length)
					{
						buffer[num++] = result;
						break;
					}
					if (TryHexToByte(str[i], out var result2))
					{
						buffer[num++] = (byte)(16 * result + result2);
						continue;
					}
					buffer[num++] = result;
				}
				if (!char.IsWhiteSpace(str, i))
				{
					break;
				}
			}
			return i;
		}

		public unsafe static (int, int) HexToInts(string str, int* buffer, int length)
		{
			int i = 0;
			int j;
			for (j = 0; j < length; j++)
			{
				if (i >= str.Length)
				{
					break;
				}
				int num = 0;
				for (int k = 0; k < 8; k++)
				{
					if (i >= str.Length)
					{
						break;
					}
					char c = str[i++];
					if (TryHexToByte(c, out var result))
					{
						num = (num << 4) | result;
						continue;
					}
					if (!char.IsWhiteSpace(c))
					{
						return (i, j);
					}
					for (; i < str.Length && char.IsWhiteSpace(str[i]); i++)
					{
					}
					break;
				}
				buffer[j] = num;
			}
			return (i, j);
		}

		public unsafe static string BytesToHex(byte[] buffer, int columns = 16)
		{
			if (buffer == null)
			{
				return "<null>";
			}
			if (buffer.Length == 0)
			{
				return "<empty>";
			}
			fixed (byte* buffer2 = buffer)
			{
				return BytesToHex(buffer2, buffer.Length, columns);
			}
		}

		public unsafe static string BytesToHex(ReadOnlySpan<byte> buffer, int columns = 16)
		{
			if (buffer.Length == 0)
			{
				return "<empty>";
			}
			fixed (byte* buffer2 = buffer)
			{
				return BytesToHex(buffer2, buffer.Length, columns);
			}
		}

		internal static void RepeatingCopyTo(this ReadOnlySpan<byte> src, Span<byte> dst)
		{
			if (!src.IsEmpty)
			{
				while (dst.Length >= src.Length)
				{
					src.CopyTo(dst);
					int length = src.Length;
					dst = dst.Slice(length, dst.Length - length);
				}
				if (dst.Length > 0)
				{
					src.Slice(0, dst.Length).CopyTo(dst);
				}
			}
		}

		internal static bool RepeatingSequenceEqualTo(this ReadOnlySpan<byte> span, ReadOnlySpan<byte> other)
		{
			while (span.Length >= other.Length)
			{
				if (!span.Slice(0, other.Length).SequenceEqual(other))
				{
					return false;
				}
				int length = other.Length;
				span = span.Slice(length, span.Length - length);
			}
			if (span.Length > 0 && !span.SequenceEqual(other.Slice(0, span.Length)))
			{
				return false;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static T Read<T>(this Span<byte> source) where T : unmanaged
		{
			Assert.Always(source.Length >= sizeof(T), source.Length, sizeof(T));
			return Unsafe.As<byte, T>(ref source[0]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static T Read<T>(this Span<int> source) where T : unmanaged
		{
			Assert.Always(source.Length * 4 >= sizeof(T), source.Length, sizeof(T));
			return Unsafe.As<int, T>(ref source[0]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ref T AsRef<T>(this Span<byte> source) where T : unmanaged
		{
			Assert.Always(source.Length >= sizeof(T), source.Length, sizeof(T));
			return ref Unsafe.As<byte, T>(ref source[0]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ref T AsRef<T>(this Span<int> source) where T : unmanaged
		{
			Assert.Always(source.Length * 4 >= sizeof(T), source.Length, sizeof(T));
			return ref Unsafe.As<int, T>(ref source[0]);
		}

		public unsafe static T* AsPointer<T>(this Span<byte> source) where T : unmanaged
		{
			Assert.Always(source.Length >= sizeof(T), source.Length, sizeof(T));
			return (T*)Unsafe.AsPointer(ref source[0]);
		}

		public unsafe static T* AsPointer<T>(this Span<int> source) where T : unmanaged
		{
			Assert.Always(source.Length * 4 >= sizeof(T), source.Length, sizeof(T));
			return (T*)Unsafe.AsPointer(ref source[0]);
		}
	}
	internal static class CompressionUtils
	{
		public static byte[] Compress(byte[] data)
		{
			using MemoryStream memoryStream = new MemoryStream();
			using GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress);
			gZipStream.Write(data, 0, data.Length);
			gZipStream.Close();
			return memoryStream.ToArray();
		}

		public static byte[] Decompress(byte[] data)
		{
			using MemoryStream stream = new MemoryStream(data);
			using GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress);
			using MemoryStream memoryStream = new MemoryStream();
			gZipStream.CopyTo(memoryStream);
			return memoryStream.ToArray();
		}

		public unsafe static void SnapshotCompress(int* Current, int* Previous, int* Result, int totalLenght, out int count)
		{
			count = 0;
			for (int i = 0; i < totalLenght; i++)
			{
				if (Current[i] != Previous[i])
				{
					Result[count++] = i;
					Result[count++] = Current[i];
				}
			}
		}

		public unsafe static void SnapshotDecompress(int* previous, int* delta, int length)
		{
			int num = 0;
			while (num < length)
			{
				int num2 = delta[num++];
				int num3 = delta[num++];
				previous[num2] = num3;
			}
		}
	}
	public static class CRC64
	{
		private static readonly ulong[] _tab = new ulong[256]
		{
			0uL, 8851949072701294969uL, 17703898145402589938uL, 10333669153493130123uL, 13851072938616403599uL, 13465927519055396854uL, 3857338458010461309uL, 5715195658523061508uL, 12333367839138578037uL, 15127763206205961996uL,
			6816212484437830791uL, 2612226237385041406uL, 7714676916020922618uL, 1281407202545942915uL, 11430391317046123016uL, 16463076249205199729uL, 9009731685717012353uL, 563108230357313272uL, 9851657908567506291uL, 17465080730062222346uL,
			13632424968875661582uL, 14404880506683019383uL, 5224452474770082812uL, 3627802401766982277uL, 15429353832041845236uL, 12463821128841762957uL, 2562814405091885830uL, 6433535930597116543uL, 1592294032496338811uL, 7836410910743637506uL,
			16404387395731993993uL, 11056451039949864176uL, 18019463371434024706uL, 9280105458721969787uL, 1126216460714626544uL, 8464919223366468745uL, 4190910634541279629uL, 4679640014836523252uL, 14959263154764675967uL, 13060872525739979270uL,
			5852729821509460343uL, 3161916214005835790uL, 11856275032257016709uL, 16019730051968187132uL, 10448904949540165624uL, 16994763621833383553uL, 7255604803533964554uL, 2191395843288271987uL, 9734813498046853251uL, 18285020776702097914uL,
			8262382231073956465uL, 608425843627928328uL, 5125628810183771660uL, 4465764294926438261uL, 12867071861194233086uL, 14432195567501024647uL, 3184588064992677622uL, 6262709589572306831uL, 15672821821487275012uL, 11770576130456212861uL,
			17008134862606432377uL, 10867599606483677440uL, 1853769023980628619uL, 7161174014982448114uL, 16103423924954344815uL, 11935289383220651030uL, 3083341959784644509uL, 5769757520242456292uL, 2252432921429253088uL, 7321251034957484697uL,
			16929838446732937490uL, 10388307452745547883uL, 8381821269082559258uL, 1047727658635319907uL, 9359280029673046504uL, 18102965619612993681uL, 13000435797616977301uL, 14894146905688698092uL, 4745161141923116903uL, 4252033715651608094uL,
			11705459643018920686uL, 15612384854998895511uL, 6323832428011671580uL, 3250108949404244325uL, 7082685524280996961uL, 1770671381070249240uL, 10951102161764411027uL, 17087309740654948330uL, 674072313427442843uL, 8323419547594995170uL,
			18224423522563763817uL, 9669888565606754064uL, 14511209607067929108uL, 12950765422787986285uL, 4382791686576543974uL, 5047054248884015519uL, 2696289253709771373uL, 6895947823530343188uL, 15049839570318909599uL, 12250835051042597350uL,
			16524764462147912930uL, 11496477575961038235uL, 1216851687255856656uL, 7654800921679748969uL, 10251257620367543320uL, 17625884659327141217uL, 8931528589852876522uL, 84259039178430355uL, 5655163293556783767uL, 3792978414742418414uL,
			13532134484260726885uL, 13912670750543257884uL, 6369176129985355244uL, 2502782282785952917uL, 12525419179144613662uL, 15495561035627234919uL, 10978437246791527267uL, 16321975555527844378uL, 7920669638525335953uL, 1671873238255513832uL,
			17531166746306175897uL, 9913345878835194592uL, 503231997654823275uL, 8945175932061546514uL, 3707538047961257238uL, 5308515798192249967uL, 14322348029964896228uL, 13554501644362141341uL, 10785157014839085493uL, 17254666630495879372uL,
			6925536469308201799uL, 1928669229005230654uL, 6166683919569289018uL, 3408106242218915395uL, 11539515040484912584uL, 15779741191858611377uL, 4504865842858506176uL, 4925828954283753145uL, 14642502069914969394uL, 12820884771576065099uL,
			18355716529793696079uL, 9540007361421969462uL, 796147016248169405uL, 8202193697865996996uL, 16763642538165118516uL, 10555343349626187597uL, 2095455317270639814uL, 7479631577382337983uL, 2926364910754730171uL, 5928137516128508354uL,
			15937228569359352393uL, 12102324735718361904uL, 4867406749023426625uL, 4131191115536978232uL, 13131477498808912563uL, 14763945261529023434uL, 9490322283846233806uL, 17972763431062038455uL, 8504067431303216188uL, 926884511990314309uL,
			8051711962477172407uL, 1541670979892322254uL, 11100683476643087429uL, 16201132341218348348uL, 12647664856023343160uL, 15374718365700663617uL, 6500217898808488650uL, 2372580570961558451uL, 14165371048561993922uL, 13712881572587659707uL,
			3541342762140498480uL, 5475551080882205513uL, 337036156713721421uL, 9112211761281881908uL, 17374189211922025663uL, 10071726351451997638uL, 1348144626854885686uL, 7524919785159454799uL, 16646839095189990340uL, 11375251796044276413uL,
			15171913658969673657uL, 12129609824107054784uL, 2827581646778391883uL, 6766067242130363442uL, 13374985906044110659uL, 14070668113165684282uL, 5489218623395763633uL, 3960334819262667976uL, 8765583373153087948uL, 251615998827411637uL,
			10094108497768031038uL, 17783882574922426951uL, 5392578507419542746uL, 3462768234654100899uL, 13791895647060686376uL, 14249064643987996497uL, 10011129131143811669uL, 17309264314385947436uL, 9177858264896848039uL, 398073508124084702uL,
			16284634862666717871uL, 11179858319785628630uL, 1463182455377365085uL, 7968614284679676196uL, 2433703374511713312uL, 6565738749404456281uL, 15309601843359497938uL, 12587227855704700843uL, 4025855981238586203uL, 5550341738321543714uL,
			14010231419946703273uL, 13309869690798280912uL, 17863057179705753044uL, 10177610780853122221uL, 168518078356860710uL, 8687094605961012831uL, 11310326587113567534uL, 16586241563491499095uL, 7585956829484836828uL, 1413790823389195941uL,
			6687492953022055329uL, 2744609311697881816uL, 12213303662187237715uL, 15250927976100943914uL, 12738352259970710488uL, 14564578711588090529uL, 5005564565571905834uL, 4588929132448424019uL, 8142317431333358935uL, 731591227688682542uL,
			9606093343850471333uL, 18417404465172059868uL, 2012927990619293101uL, 7005115709973351636uL, 17176652871151048543uL, 10702745209522052646uL, 15841339277050671906uL, 11605722277885901403uL, 3343746476511027664uL, 6106651831093618857uL,
			14830152191845028953uL, 13193075276920315168uL, 4071158715666679467uL, 4803046671925235666uL, 1006463995309646550uL, 8588326435575524271uL, 17890351864123093028uL, 9412308762883553629uL, 7415076095922514476uL, 2035579357833339733uL,
			10617031596384499934uL, 16829728831969243559uL, 12024401134718426275uL, 15854695815076877786uL, 6012200567359213137uL, 3006100283679606568uL
		};

		public unsafe static ulong Compute(byte* data, int length)
		{
			return Compute(0uL, data, 0, length);
		}

		public unsafe static ulong Compute(ReadOnlySpan<int> data)
		{
			if (data.IsEmpty)
			{
				return 0uL;
			}
			fixed (int* data2 = data)
			{
				return Compute(0uL, (byte*)data2, 0, data.Length * 4);
			}
		}

		public unsafe static ulong Compute(ulong crc, byte* data, int offset, int length)
		{
			length += offset;
			for (int i = offset; i < length; i++)
			{
				crc = _tab[(byte)crc ^ data[i]] ^ (crc >> 8);
			}
			return crc;
		}
	}
	public static class EngineProfiler
	{
		public static Action<float> RoundTripTimeCallback;

		public static Action<int> ResimulationsCallback;

		public static Action<int> WorldSnapshotSizeCallback;

		public static Action<int> InputSizeCallback;

		public static Action<int> InputQueueCallback;

		public static Action<int> RpcInCallback;

		public static Action<int> RpcOutCallback;

		public static Action<float> StateRecvDeltaCallback;

		public static Action<float> StateRecvDeltaDeviationCallback;

		public static Action<float> InterpolationSpeedCallback;

		public static Action<float> InterpolationOffsetCallback;

		public static Action<float> InterpolationOffsetDeviationCallback;

		public static Action<float> InputRecvDeltaCallback;

		public static Action<float> SimulationSpeedCallback;

		public static Action<float> InputRecvDeltaDeviationCallback;

		public static Action<float> SimulationOffsetCallback;

		public static Action<float> SimulationOffsetDeviationCallback;

		[Conditional("ENABLE_PROFILER")]
		public static void Begin(string sample)
		{
			Profiler.BeginSample(sample);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void End()
		{
			Profiler.EndSample();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void RoundTripTime(float value)
		{
			RoundTripTimeCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void Resimulations(int value)
		{
			ResimulationsCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void WorldSnapshotSize(int value)
		{
			WorldSnapshotSizeCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void InputSize(int value)
		{
			InputSizeCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void InputQueue(int value)
		{
			InputQueueCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void RpcIn(int value)
		{
			RpcInCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void RpcOut(int value)
		{
			RpcOutCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void StateRecvDelta(float value)
		{
			StateRecvDeltaCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void StateRecvDeltaDeviation(float value)
		{
			StateRecvDeltaDeviationCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void InterpolationSpeed(float value)
		{
			InterpolationSpeedCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void InterpolationOffset(float value)
		{
			InterpolationOffsetCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void InterpolationOffsetDeviation(float value)
		{
			InterpolationOffsetDeviationCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void InputRecvDelta(float value)
		{
			InputRecvDeltaCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void InputRecvDeltaDeviation(float value)
		{
			InputRecvDeltaDeviationCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void SimulationSpeed(float value)
		{
			SimulationSpeedCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void SimulationOffset(float value)
		{
			SimulationOffsetCallback?.Invoke(value);
		}

		[Conditional("ENABLE_PROFILER")]
		public static void SimulationOffsetDeviation(float value)
		{
			SimulationOffsetDeviationCallback?.Invoke(value);
		}
	}
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public sealed class ArrayLengthAttribute : DecoratingPropertyAttribute
	{
		public int MinLength { get; }

		public int MaxLength { get; }

		public ArrayLengthAttribute(int length)
		{
			MinLength = (MaxLength = length);
		}

		public ArrayLengthAttribute(int minLength, int maxLength)
		{
			MinLength = minLength;
			MaxLength = maxLength;
		}
	}
	[AttributeUsage(AttributeTargets.Field)]
	public class AssemblyNameAttribute : DrawerPropertyAttribute
	{
		public bool RequiresUnsafeCode { get; set; }
	}
	[AttributeUsage(AttributeTargets.Field)]
	public class BinaryDataAttribute : DrawerPropertyAttribute
	{
	}
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public sealed class BitSetAttribute : DrawerPropertyAttribute
	{
		public int BitCount { get; }

		public BitSetAttribute(int bitCount)
		{
			BitCount = bitCount;
		}
	}
	public abstract class DecoratingPropertyAttribute : PropertyAttribute
	{
		public const int DefaultOrder = -10000;

		protected DecoratingPropertyAttribute()
		{
			base.order = -10000;
		}

		protected DecoratingPropertyAttribute(int order)
		{
			base.order = order;
		}
	}
	[AttributeUsage(AttributeTargets.Field)]
	public class DisplayAsEnumAttribute : DrawerPropertyAttribute
	{
		public Type EnumType { get; }

		public string EnumTypeMemberName { get; }

		public DisplayAsEnumAttribute(Type enumType)
		{
			EnumType = enumType;
		}

		public DisplayAsEnumAttribute(string enumTypeMemberName)
		{
			EnumTypeMemberName = enumTypeMemberName;
		}
	}
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class DisplayNameAttribute : DecoratingPropertyAttribute
	{
		public readonly string Name;

		public DisplayNameAttribute(string name)
		{
			Name = name;
		}
	}
	public enum CompareOperator
	{
		Equal,
		NotEqual,
		Less,
		LessOrEqual,
		GreaterOrEqual,
		Greater,
		NotZero,
		IsZero,
		BitwiseAndNotEqualZero
	}
	public abstract class DoIfAttributeBase : DecoratingPropertyAttribute
	{
		public double _doubleValue;

		public bool _isDouble;

		public long _longValue;

		public CompareOperator Compare;

		public string ConditionMember;

		public bool ErrorOnConditionMemberNotFound = true;

		protected DoIfAttributeBase(string conditionMember, double compareToValue, CompareOperator compare)
		{
			ConditionMember = conditionMember;
			Compare = compare;
			_doubleValue = compareToValue;
			_isDouble = true;
		}

		protected DoIfAttributeBase(string conditionMember, long compareToValue, CompareOperator compare)
		{
			ConditionMember = conditionMember;
			Compare = compare;
			_longValue = compareToValue;
			_isDouble = false;
		}

		protected DoIfAttributeBase(string conditionMember, bool compareToValue, CompareOperator compare)
		{
			ConditionMember = conditionMember;
			Compare = compare;
			_longValue = (compareToValue ? 1 : 0);
			_isDouble = false;
		}
	}
	public abstract class DrawerPropertyAttribute : PropertyAttribute
	{
	}
	public enum DrawIfMode
	{
		ReadOnly,
		Hide
	}
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = true)]
	public class DrawIfAttribute : DoIfAttributeBase
	{
		private new const int DefaultOrder = -11000;

		public DrawIfMode Mode;

		public bool Hide
		{
			get
			{
				return Mode == DrawIfMode.Hide;
			}
			set
			{
				Mode = (value ? DrawIfMode.Hide : DrawIfMode.ReadOnly);
			}
		}

		public DrawIfAttribute(string conditionMember, double compareToValue, CompareOperator compare = CompareOperator.Equal, DrawIfMode mode = DrawIfMode.ReadOnly)
			: base(conditionMember, compareToValue, compare)
		{
			Mode = mode;
			base.order = -11000;
		}

		public DrawIfAttribute(string conditionMember, bool compareToValue, CompareOperator compare = CompareOperator.Equal, DrawIfMode mode = DrawIfMode.ReadOnly)
			: base(conditionMember, compareToValue, compare)
		{
			Mode = mode;
			base.order = -11000;
		}

		public DrawIfAttribute(string conditionMember, long compareToValue, CompareOperator compare = CompareOperator.Equal, DrawIfMode mode = DrawIfMode.ReadOnly)
			: base(conditionMember, compareToValue, compare)
		{
			Mode = mode;
			base.order = -11000;
		}

		public DrawIfAttribute(string conditionMember)
			: this(conditionMember, 0L, CompareOperator.NotEqual)
		{
		}
	}
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class DrawInlineAttribute : DrawerPropertyAttribute
	{
	}
	[AttributeUsage(AttributeTargets.Method)]
	public class EditorButtonAttribute : Attribute
	{
		public string Label;

		public EditorButtonVisibility Visibility;

		public int Priority;

		public bool AllowMultipleTargets;

		public bool DirtyObject;

		public EditorButtonAttribute(string label, EditorButtonVisibility visibility = EditorButtonVisibility.Always, int priority = 0, bool dirtyObject = false)
		{
			Label = label;
			Visibility = visibility;
			Priority = priority;
			DirtyObject = dirtyObject;
		}

		public EditorButtonAttribute(EditorButtonVisibility visibility = EditorButtonVisibility.Always, int priority = 0, bool dirtyObject = false)
			: this(null, visibility, priority, dirtyObject)
		{
		}
	}
	public enum EditorButtonVisibility
	{
		PlayMode,
		EditMode,
		Always
	}
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class ErrorIfAttribute : DoIfAttributeBase
	{
		public string Message;

		public bool AsBox;

		public ErrorIfAttribute(string conditionMember, double compareToValue, string message, CompareOperator compare = CompareOperator.Equal)
			: base(conditionMember, compareToValue, compare)
		{
			base.order = -10000;
			Message = message;
		}

		public ErrorIfAttribute(string conditionMember, bool compareToValue, string message, CompareOperator compare = CompareOperator.Equal)
			: base(conditionMember, compareToValue, compare)
		{
			base.order = -10000;
			Message = message;
		}

		public ErrorIfAttribute(string conditionMember, long compareToValue, string message, CompareOperator compare = CompareOperator.Equal)
			: base(conditionMember, compareToValue, compare)
		{
			base.order = -10000;
			Message = message;
		}
	}
	[AttributeUsage(AttributeTargets.Field)]
	public class ExpandableEnumAttribute : DrawerPropertyAttribute
	{
		public bool AlwaysExpanded { get; set; } = false;

		public bool ShowFlagsButtons { get; set; } = true;

		public bool ShowInlineHelp { get; set; } = false;
	}
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class FieldEditorButtonAttribute : DecoratingPropertyAttribute
	{
		public string Label;

		public bool AllowMultipleTargets;

		public string TargetMethod;

		public FieldEditorButtonAttribute(string label, string targetMethod)
		{
			Label = label;
			TargetMethod = targetMethod;
		}
	}
	[AttributeUsage(AttributeTargets.Field)]
	public class HideArrayElementLabelAttribute : DecoratingPropertyAttribute
	{
		private new const int DefaultOrder = -11000;

		public HideArrayElementLabelAttribute()
			: base(-11000)
		{
		}
	}
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field)]
	public class InlineHelpAttribute : DecoratingPropertyAttribute
	{
		private new const int DefaultOrder = -9000;

		public bool ShowTypeHelp { get; set; } = true;

		public InlineHelpAttribute()
			: base(-9000)
		{
		}
	}
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class LayerAttribute : DrawerPropertyAttribute
	{
	}
	public class LayerMatrixAttribute : DrawerPropertyAttribute
	{
	}
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public sealed class MaxStringByteCountAttribute : DrawerPropertyAttribute
	{
		public int ByteCount { get; }

		public string Encoding { get; }

		public MaxStringByteCountAttribute(int count, string encoding)
		{
			ByteCount = count;
			Encoding = encoding;
		}
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class RangeExAttribute : DrawerPropertyAttribute
	{
		public bool ClampMin = true;

		public bool ClampMax = true;

		public bool UseSlider = true;

		public double Max { get; }

		public double Min { get; }

		public RangeExAttribute(double min, double max)
		{
			Max = max;
			Min = min;
		}
	}
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class ReadOnlyAttribute : DecoratingPropertyAttribute
	{
		public bool InPlayMode { get; set; } = true;

		public bool InEditMode { get; set; } = true;
	}
	[AttributeUsage(AttributeTargets.Field)]
	public class ScenePathAttribute : DrawerPropertyAttribute
	{
	}
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class ScriptHelpAttribute : PropertyAttribute
	{
		public bool Hide { get; set; }

		public string Url { get; set; }

		public ScriptHeaderBackColor BackColor { get; set; } = ScriptHeaderBackColor.Gray;

		public ScriptHeaderStyle Style { get; set; } = ScriptHeaderStyle.Photon;
	}
	public enum ScriptHeaderStyle
	{
		Unity,
		Photon
	}
	public enum ScriptHeaderIcon
	{
		None,
		Blue,
		Green,
		Gray
	}
	public enum ScriptHeaderBackColor
	{
		None,
		Gray,
		Blue,
		Red,
		Green,
		Orange,
		Black,
		Steel,
		Sand,
		Olive,
		Cyan,
		Violet
	}
	public class SerializableTypeAttribute : PropertyAttribute
	{
		public Type BaseType { get; set; }

		public bool UseFullAssemblyQualifiedName { get; set; }

		public bool WarnIfNoPreserveAttribute { get; set; }
	}
	[AttributeUsage(AttributeTargets.Field)]
	public class SerializeReferenceTypePickerAttribute : DecoratingPropertyAttribute
	{
		public bool GroupTypesByNamespace = true;

		public bool ShowFullName = false;

		public Type[] Types { get; private set; }

		public SerializeReferenceTypePickerAttribute(params Type[] types)
		{
			Types = types;
		}
	}
	[AttributeUsage(AttributeTargets.Field)]
	public class ToggleLeftAttribute : DrawerPropertyAttribute
	{
	}
	public enum Units
	{
		None,
		Ticks,
		Seconds,
		MilliSecs,
		Kilobytes,
		Megabytes,
		Normalized,
		Multiplier,
		Percentage,
		NormalizedPercentage,
		Degrees,
		PerSecond,
		DegreesPerSecond,
		Radians,
		RadiansPerSecond,
		TicksPerSecond,
		Units,
		Bytes,
		Count,
		Packets,
		Frames,
		FramesPerSecond,
		SquareMagnitude
	}
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class UnitAttribute : DecoratingPropertyAttribute
	{
		public Units Unit { get; }

		public UnitAttribute(Units units)
		{
			Unit = units;
		}
	}
	public class UnityAddressablesRuntimeKeyAttribute : PropertyAttribute
	{
	}
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class UnityAssetGuidAttribute : DrawerPropertyAttribute
	{
	}
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class UnityResourcePathAttribute : DrawerPropertyAttribute
	{
		public Type ResourceType { get; }

		public UnityResourcePathAttribute(Type resourceType)
		{
			ResourceType = resourceType;
		}
	}
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class WarnIfAttribute : DoIfAttributeBase
	{
		public string Message;

		public bool AsBox;

		public WarnIfAttribute(string conditionMember, double compareToValue, string message, CompareOperator compare = CompareOperator.Equal)
			: base(conditionMember, compareToValue, compare)
		{
			base.order = -10000;
			Message = message;
		}

		public WarnIfAttribute(string conditionMember, bool compareToValue, string message, CompareOperator compare = CompareOperator.Equal)
			: base(conditionMember, compareToValue, compare)
		{
			base.order = -10000;
			Message = message;
		}

		public WarnIfAttribute(string conditionMember, long compareToValue, string message, CompareOperator compare = CompareOperator.Equal)
			: base(conditionMember, compareToValue, compare)
		{
			base.order = -10000;
			Message = message;
		}

		public WarnIfAttribute(string conditionMember, string message)
			: this(conditionMember, 0L, message, CompareOperator.NotEqual)
		{
		}
	}
	[Serializable]
	public abstract class FieldsMask
	{
		public Mask256 Mask;

		protected FieldsMask(Mask256 mask)
		{
			Mask = mask;
		}

		protected FieldsMask(long a, long b, long c, long d)
		{
			Mask = default(Mask256);
		}

		protected FieldsMask()
		{
		}

		public static implicit operator Mask256(FieldsMask mask)
		{
			return mask.Mask;
		}
	}
	[Serializable]
	public class FieldsMask<T> : FieldsMask
	{
		public FieldsMask(Mask256 mask)
			: base(mask)
		{
		}

		public FieldsMask(long maskA, long maskB = 0L, long maskC = 0L, long maskD = 0L)
			: base(maskA, maskB, maskC, maskD)
		{
		}

		public FieldsMask()
		{
		}

		public FieldsMask(Func<Mask256> getDefaultsDelegate)
		{
			Mask = getDefaultsDelegate?.Invoke() ?? default(Mask256);
		}
	}
	[Serializable]
	public struct Mask256 : IEquatable<Mask256>
	{
		[SerializeField]
		private unsafe fixed long values[4];

		public unsafe long this[int i]
		{
			get
			{
				return values[i];
			}
			set
			{
				values[i] = value;
			}
		}

		public unsafe void Clear()
		{
			values[0] = 0L;
			values[1] = 0L;
			values[2] = 0L;
			values[3] = 0L;
		}

		public unsafe void SetBit(int bitIndex, bool set)
		{
			if (set)
			{
				if (bitIndex < 64)
				{
					values[0] |= 1L << bitIndex;
				}
				else if (bitIndex < 128)
				{
					ref long reference = ref values[1];
					reference |= 1L << bitIndex - 64;
				}
				else if (bitIndex < 192)
				{
					ref long reference2 = ref values[2];
					reference2 |= 1L << bitIndex - 128;
				}
				else if (bitIndex < 256)
				{
					ref long reference3 = ref values[3];
					reference3 |= 1L << bitIndex - 192;
				}
			}
			else if (bitIndex < 64)
			{
				values[0] &= ~(1L << bitIndex);
			}
			else if (bitIndex < 128)
			{
				ref long reference4 = ref values[1];
				reference4 &= ~(1L << bitIndex - 64);
			}
			else if (bitIndex < 192)
			{
				ref long reference5 = ref values[2];
				reference5 &= ~(1L << bitIndex - 128);
			}
			else if (bitIndex < 256)
			{
				ref long reference6 = ref values[3];
				reference6 &= ~(1L << bitIndex - 192);
			}
		}

		public unsafe bool GetBit(int bitIndex)
		{
			if (bitIndex < 64)
			{
				return (values[0] & (1L << bitIndex)) != 0;
			}
			if (bitIndex < 128)
			{
				return (values[1] & (1L << bitIndex - 64)) != 0;
			}
			if (bitIndex < 192)
			{
				return (values[2] & (1L << bitIndex - 128)) != 0;
			}
			if (bitIndex < 256)
			{
				return (values[3] & (1L << bitIndex - 192)) != 0;
			}
			return false;
		}

		public unsafe Mask256(long a, long b = 0L, long c = 0L, long d = 0L)
		{
			this = default(Mask256);
			values[0] = a;
			values[1] = b;
			values[2] = c;
			values[3] = d;
		}

		public unsafe static implicit operator long(Mask256 mask)
		{
			return mask.values[0];
		}

		public static implicit operator Mask256(long value)
		{
			return new Mask256(value, 0L, 0L, 0L);
		}

		public unsafe static Mask256 operator &(Mask256 a, Mask256 b)
		{
			return new Mask256(a.values[0] & b.values[0], a.values[1] & b.values[1], a.values[2] & b.values[2], a.values[3] & b.values[3]);
		}

		public unsafe static Mask256 operator |(Mask256 a, Mask256 b)
		{
			return new Mask256(a.values[0] | b.values[0], a.values[1] | b.values[1], a.values[2] | b.values[2], a.values[3] | b.values[3]);
		}

		public unsafe static Mask256 operator ~(Mask256 a)
		{
			return new Mask256(~a.values[0], ~a.values[1], ~a.values[2], ~a.values[3]);
		}

		public override bool Equals(object obj)
		{
			return obj is Mask256 other && Equals(other);
		}

		public unsafe override int GetHashCode()
		{
			return values[0].GetHashCode() ^ values[1].GetHashCode() ^ values[2].GetHashCode() ^ values[3].GetHashCode();
		}

		public unsafe bool Equals(Mask256 other)
		{
			return values[0] == other.values[0] && values[1] == other.values[1] && values[2] == other.values[2] && values[3] == other.values[3];
		}

		public unsafe bool IsNothing()
		{
			return values[0] == 0L && values[1] == 0L && values[2] == 0L && values[3] == 0;
		}

		public unsafe override string ToString()
		{
			return $"{values[0]}:{values[1]}:{values[2]}:{values[3]}";
		}
	}
	[Serializable]
	public struct SerializableType : IEquatable<SerializableType>
	{
		private static class Cache
		{
			public static Dictionary<string, object> Types = new Dictionary<string, object>();
		}

		public string AssemblyQualifiedName;

		private static readonly Regex s_shortNameRegex = new Regex(", (Version|Culture|PublicKeyToken)=[^, \\]]+", RegexOptions.Compiled);

		public bool IsValid => !string.IsNullOrEmpty(AssemblyQualifiedName);

		public Type Value
		{
			get
			{
				if (string.IsNullOrEmpty(AssemblyQualifiedName))
				{
					return null;
				}
				object value;
				lock (Cache.Types)
				{
					if (!Cache.Types.TryGetValue(AssemblyQualifiedName, out value))
					{
						try
						{
							value = Type.GetType(AssemblyQualifiedName, throwOnError: true);
						}
						catch (Exception source)
						{
							value = ExceptionDispatchInfo.Capture(source);
						}
						Cache.Types.Add(AssemblyQualifiedName, value);
					}
				}
				if (value is ExceptionDispatchInfo exceptionDispatchInfo)
				{
					exceptionDispatchInfo.Throw();
				}
				Type type = (Type)value;
				if (type == null)
				{
					throw new Exception("Type " + AssemblyQualifiedName + " not found");
				}
				return type;
			}
		}

		public SerializableType(Type type)
		{
			if (type == null)
			{
				AssemblyQualifiedName = string.Empty;
			}
			else
			{
				AssemblyQualifiedName = type.AssemblyQualifiedName;
			}
		}

		public SerializableType(string type)
		{
			if (string.IsNullOrEmpty(type))
			{
				AssemblyQualifiedName = string.Empty;
			}
			else
			{
				AssemblyQualifiedName = type;
			}
		}

		public SerializableType AsShort()
		{
			return new SerializableType
			{
				AssemblyQualifiedName = GetShortAssemblyQualifiedName(AssemblyQualifiedName)
			};
		}

		public static implicit operator SerializableType(Type type)
		{
			return new SerializableType(type);
		}

		public static implicit operator Type(SerializableType serializableType)
		{
			return serializableType.Value;
		}

		public bool Equals(SerializableType other)
		{
			return AssemblyQualifiedName == other.AssemblyQualifiedName;
		}

		public override bool Equals(object obj)
		{
			return obj is SerializableType other && Equals(other);
		}

		public override int GetHashCode()
		{
			return (AssemblyQualifiedName != null) ? AssemblyQualifiedName.GetHashCode() : 0;
		}

		public static string GetShortAssemblyQualifiedName(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			string assemblyQualifiedName = type.AssemblyQualifiedName;
			if (assemblyQualifiedName == null)
			{
				throw new InvalidOperationException($"Type {type} has no AssemblyQualifiedName");
			}
			return GetShortAssemblyQualifiedName(assemblyQualifiedName);
		}

		internal static string GetShortAssemblyQualifiedName(string assemblyQualifiedName)
		{
			return s_shortNameRegex.Replace(assemblyQualifiedName, string.Empty);
		}
	}
	[Serializable]
	public struct SerializableType<BaseType> : IEquatable<SerializableType<BaseType>>
	{
		public string AssemblyQualifiedName;

		public bool IsValid => !string.IsNullOrEmpty(AssemblyQualifiedName);

		public Type Value
		{
			get
			{
				SerializableType serializableType = new SerializableType
				{
					AssemblyQualifiedName = AssemblyQualifiedName
				};
				Type value = serializableType.Value;
				Assert.Check(value != null);
				if (!value.IsSubclassOf(typeof(BaseType)))
				{
					throw new Exception($"Type mismatch: {value} must inherit from {typeof(BaseType)}");
				}
				return value;
			}
		}

		public SerializableType(Type type)
		{
			AssemblyQualifiedName = type.AssemblyQualifiedName;
		}

		public SerializableType<BaseType> AsShort()
		{
			return new SerializableType<BaseType>
			{
				AssemblyQualifiedName = SerializableType.GetShortAssemblyQualifiedName(AssemblyQualifiedName)
			};
		}

		public static implicit operator SerializableType<BaseType>(Type type)
		{
			return new SerializableType<BaseType>(type);
		}

		public static implicit operator Type(SerializableType<BaseType> serializableType)
		{
			return serializableType.Value;
		}

		public bool Equals(SerializableType<BaseType> other)
		{
			return AssemblyQualifiedName == other.AssemblyQualifiedName;
		}

		public override bool Equals(object obj)
		{
			return obj is SerializableType<BaseType> other && Equals(other);
		}

		public override int GetHashCode()
		{
			return (AssemblyQualifiedName != null) ? AssemblyQualifiedName.GetHashCode() : 0;
		}
	}
	public abstract class FusionGlobalScriptableObject : FusionScriptableObject
	{
		private static readonly Lazy<FusionGlobalScriptableObjectSourceAttribute[]> s_sourceAttributes = new Lazy<FusionGlobalScriptableObjectSourceAttribute[]>(() => (from x in GetAssemblyAttributes<FusionGlobalScriptableObjectSourceAttribute>()
			orderby x.Order
			select x).ToArray());

		internal static FusionGlobalScriptableObjectSourceAttribute[] SourceAttributes => s_sourceAttributes.Value;

		private static IEnumerable<T> GetAssemblyAttributes<T>() where T : Attribute
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				foreach (T customAttribute in assembly.GetCustomAttributes<T>())
				{
					yield return customAttribute;
				}
			}
		}
	}
	public abstract class FusionGlobalScriptableObject<T> : FusionGlobalScriptableObject where T : FusionGlobalScriptableObject<T>
	{
		private static T s_instance;

		private static FusionGlobalScriptableObjectUnloadDelegate s_unloadHandler;

		public bool IsGlobal { get; private set; }

		private static string LogPrefix => "[Global " + typeof(T).Name + "]: ";

		protected static T GlobalInternal
		{
			get
			{
				T orLoadGlobalInstance = GetOrLoadGlobalInstance();
				if ((object)orLoadGlobalInstance == null)
				{
					throw new InvalidOperationException("Failed to load " + typeof(T).Name + ". If this happens in edit mode, make sure Fusion is properly installed in the Fusion HUB. Otherwise, if the default path does not exist or does not point to a Resource, you need to use FusionGlobalScriptableObjectAttribute attribute to point to a method that will perform the loading.");
				}
				return orLoadGlobalInstance;
			}
			set
			{
				if (!(value == s_instance))
				{
					SetGlobalInternal(value, null);
				}
			}
		}

		protected static bool IsGlobalLoadedInternal => s_instance != null;

		protected virtual void OnLoadedAsGlobal()
		{
		}

		protected virtual void OnUnloadedAsGlobal(bool destroyed)
		{
		}

		private static string AsId(FusionGlobalScriptableObject<T> obj)
		{
			return obj ? $"[IID:{obj.GetInstanceID()}]" : "null";
		}

		protected virtual void OnDisable()
		{
			if (!IsGlobal)
			{
				InternalLogStreams.LogTrace?.Log(LogPrefix + "OnDisable called for " + AsId(this) + ", but is not global");
				return;
			}
			if (s_unloadHandler != null)
			{
				InternalLogStreams.LogTrace?.Log(LogPrefix + "OnDisable called for " + AsId(this) + ", setting global instance to null. The unload handler is still set, not going to be used.");
			}
			else
			{
				InternalLogStreams.LogTrace?.Log(LogPrefix + "OnDisable called for " + AsId(this) + ", setting global instance to null.");
			}
			Assert.Check((object)this == s_instance, "Expected this to be the global instance");
			s_instance = null;
			s_unloadHandler = null;
			IsGlobal = false;
			OnUnloadedAsGlobal(destroyed: true);
		}

		protected static bool TryGetGlobalInternal(out T global)
		{
			T orLoadGlobalInstance = GetOrLoadGlobalInstance();
			if ((object)orLoadGlobalInstance == null)
			{
				global = null;
				return false;
			}
			global = orLoadGlobalInstance;
			return true;
		}

		protected static bool UnloadGlobalInternal()
		{
			T val = s_instance;
			if (!val)
			{
				return false;
			}
			Assert.Check(val.IsGlobal);
			try
			{
				if (s_unloadHandler != null)
				{
					InternalLogStreams.LogTrace?.Log(LogPrefix + " Unloading global instance " + AsId(val) + " with unloader");
					FusionGlobalScriptableObjectUnloadDelegate fusionGlobalScriptableObjectUnloadDelegate = s_unloadHandler;
					s_unloadHandler = null;
					fusionGlobalScriptableObjectUnloadDelegate(val);
				}
				else
				{
					InternalLogStreams.LogTrace?.Log(LogPrefix + " Instance " + AsId(val) + " has no unloader, simply nulling it out");
				}
			}
			finally
			{
				s_instance = null;
				if (val.IsGlobal)
				{
					val.IsGlobal = false;
					val.OnUnloadedAsGlobal(destroyed: false);
				}
			}
			return true;
		}

		private static T GetOrLoadGlobalInstance()
		{
			if ((bool)s_instance)
			{
				return s_instance;
			}
			T val = null;
			FusionGlobalScriptableObjectUnloadDelegate unloadHandler = null;
			val = LoadPlayerInstance(out unloadHandler);
			if ((bool)val)
			{
				SetGlobalInternal(val, unloadHandler);
			}
			return val;
		}

		private static T LoadPlayerInstance(out FusionGlobalScriptableObjectUnloadDelegate unloadHandler)
		{
			FusionGlobalScriptableObjectSourceAttribute[] sourceAttributes = FusionGlobalScriptableObject.SourceAttributes;
			foreach (FusionGlobalScriptableObjectSourceAttribute fusionGlobalScriptableObjectSourceAttribute in sourceAttributes)
			{
				if ((!Application.isEditor || Application.isPlaying || fusionGlobalScriptableObjectSourceAttribute.AllowEditMode) && (!(fusionGlobalScriptableObjectSourceAttribute.ObjectType != typeof(T)) || typeof(T).IsSubclassOf(fusionGlobalScriptableObjectSourceAttribute.ObjectType)))
				{
					FusionGlobalScriptableObjectLoadResult fusionGlobalScriptableObjectLoadResult = fusionGlobalScriptableObjectSourceAttribute.Load(typeof(T));
					if ((bool)fusionGlobalScriptableObjectLoadResult.Object)
					{
						T val = (T)fusionGlobalScriptableObjectLoadResult.Object;
						unloadHandler = fusionGlobalScriptableObjectLoadResult.Unloader;
						InternalLogStreams.LogTrace?.Log($"{LogPrefix} Loader {fusionGlobalScriptableObjectSourceAttribute} was used to load {AsId(val)}, has unloader: {unloadHandler != null}");
						return val;
					}
					if (!fusionGlobalScriptableObjectSourceAttribute.AllowFallback)
					{
						break;
					}
				}
			}
			InternalLogStreams.LogTrace?.Log(LogPrefix + " No source attribute was able to load the global instance");
			unloadHandler = null;
			return null;
		}

		private static void SetGlobalInternal(T value, FusionGlobalScriptableObjectUnloadDelegate unloadHandler)
		{
			if ((bool)s_instance)
			{
				throw new InvalidOperationException("Failed to set " + typeof(T).Name + " as global. A global instance is already loaded - it needs to be unloaded first");
			}
			Assert.Check(value, "Expected value to be non-null");
			if ((object)s_instance == null)
			{
				Assert.Check(s_unloadHandler == null, "Expected unload handler to be null");
			}
			if ((bool)value)
			{
				s_instance = value;
				s_unloadHandler = unloadHandler;
				s_instance.IsGlobal = true;
				s_instance.OnLoadedAsGlobal();
			}
		}
	}
	[AttributeUsage(AttributeTargets.Class)]
	public class FusionGlobalScriptableObjectAttribute : Attribute
	{
		public string DefaultPath { get; }

		public string DefaultContents { get; set; }

		public string DefaultContentsGeneratorMethod { get; set; }

		public FusionGlobalScriptableObjectAttribute(string defaultPath)
		{
			DefaultPath = defaultPath;
		}
	}
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public abstract class FusionGlobalScriptableObjectSourceAttribute : Attribute
	{
		public Type ObjectType { get; }

		public int Order { get; set; }

		public bool AllowEditMode { get; set; } = false;

		public bool AllowFallback { get; set; } = false;

		public FusionGlobalScriptableObjectSourceAttribute(Type objectType)
		{
			ObjectType = objectType;
		}

		public abstract FusionGlobalScriptableObjectLoadResult Load(Type type);
	}
	[Obsolete("Use one of FusionGlobalScriptableObjectSourceAttribute-derived types instead", true)]
	[AttributeUsage(AttributeTargets.Method)]
	public class FusionGlobalScriptableObjectLoaderMethodAttribute : Attribute
	{
		public int Order { get; set; }
	}
	public delegate void FusionGlobalScriptableObjectUnloadDelegate(FusionGlobalScriptableObject instance);
	public readonly struct FusionGlobalScriptableObjectLoadResult(FusionGlobalScriptableObject obj, FusionGlobalScriptableObjectUnloadDelegate unloader = null)
	{
		public readonly FusionGlobalScriptableObject Object = obj;

		public readonly FusionGlobalScriptableObjectUnloadDelegate Unloader = unloader;

		public static implicit operator FusionGlobalScriptableObjectLoadResult(FusionGlobalScriptableObject result)
		{
			return new FusionGlobalScriptableObjectLoadResult(result);
		}
	}
	public abstract class FusionMonoBehaviour : MonoBehaviour
	{
	}
	public abstract class FusionScriptableObject : ScriptableObject
	{
	}
	internal class JsonUtils
	{
		private static Regex ReferencesRegex = new Regex(",\"references\":", RegexOptions.IgnoreCase | RegexOptions.Compiled);

		public static string RemoveExtraReferences(string baseJson)
		{
			Match match = ReferencesRegex.Match(baseJson);
			if (match.Success)
			{
				int num = match.Index + match.Length;
				int num2 = num;
				int num3 = 0;
				bool flag = false;
				do
				{
					if (baseJson[num2] == '{')
					{
						num3++;
						flag = true;
					}
					if (baseJson[num2] == '}')
					{
						num3--;
					}
					num2++;
				}
				while (num2 < baseJson.Length && num3 > 0);
				if (num3 == 0 && flag)
				{
					baseJson = baseJson.Remove(match.Index, num2 - match.Index);
				}
			}
			return baseJson;
		}
	}
	public static class Maths
	{
		[StructLayout(LayoutKind.Explicit)]
		private struct FastAbs2
		{
			[FieldOffset(0)]
			public uint uint32;

			[FieldOffset(0)]
			public float single;
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct FastAbs
		{
			public const uint Mask = 2147483647u;

			[FieldOffset(0)]
			public uint UInt32;

			[FieldOffset(0)]
			public float Single;
		}

		private const float ENRANGE = 1.4142133f;

		private const float UNRANGE = 0.7071069f;

		private const uint HALF_ENCODED = 512u;

		private const float ENCODER = 724.0772f;

		private const float DECODER = 0.0013810681f;

		private const uint MASK10BITS = 1023u;

		private static byte[] _debruijnTable32 = new byte[32]
		{
			0, 9, 1, 10, 13, 21, 2, 29, 11, 14,
			16, 18, 22, 25, 3, 30, 8, 12, 20, 28,
			15, 17, 24, 7, 19, 27, 23, 6, 26, 5,
			4, 31
		};

		private static byte[] _debruijnTable64 = new byte[64]
		{
			63, 0, 58, 1, 59, 47, 53, 2, 60, 39,
			48, 27, 54, 33, 42, 3, 61, 51, 37, 40,
			49, 18, 28, 20, 55, 30, 34, 11, 43, 14,
			22, 4, 62, 57, 46, 52, 38, 26, 32, 41,
			50, 36, 17, 19, 29, 10, 13, 21, 56, 45,
			25, 31, 35, 16, 9, 12, 44, 24, 15, 8,
			23, 7, 6, 5
		};

		private static readonly int[] DeBruijnLookupLong = new int[128]
		{
			0, 48, -1, -1, 31, -1, 15, 51, -1, 63,
			5, -1, -1, -1, 19, -1, 23, 28, -1, -1,
			-1, 40, 36, 46, -1, 13, -1, -1, -1, 34,
			-1, 58, -1, 60, 2, 43, 55, -1, -1, -1,
			50, 62, 4, -1, 18, 27, -1, 39, 45, -1,
			-1, 33, 57, -1, 1, 54, -1, 49, -1, 17,
			-1, -1, 32, -1, 53, -1, 16, -1, -1, 52,
			-1, -1, -1, 64, 6, 7, 8, -1, 9, -1,
			-1, -1, 20, 10, -1, -1, 24, -1, 29, -1,
			-1, 21, -1, 11, -1, -1, 41, -1, 25, 37,
			-1, 47, -1, 30, 14, -1, -1, -1, -1, 22,
			-1, -1, 35, 12, -1, -1, -1, 59, 42, -1,
			-1, 61, 3, 26, 38, 44, -1, 56
		};

		public static uint QuaternionCompress(Quaternion rot)
		{
			FastAbs2 fastAbs = new FastAbs2
			{
				single = rot.x
			};
			fastAbs.uint32 &= 2147483647u;
			float single = fastAbs.single;
			fastAbs.single = rot.y;
			fastAbs.uint32 &= 2147483647u;
			float single2 = fastAbs.single;
			fastAbs.single = rot.z;
			fastAbs.uint32 &= 2147483647u;
			float single3 = fastAbs.single;
			fastAbs.single = rot.w;
			fastAbs.uint32 &= 2147483647u;
			float single4 = fastAbs.single;
			int num = ((!(single > single2)) ? 1 : 0);
			int num2 = ((single3 > single4) ? 2 : 3);
			int num3 = ((((num == 0) ? single : single2) > ((num2 == 2) ? single3 : single4)) ? num : num2);
			float num4;
			float num5;
			float num6;
			float num7;
			switch (num3)
			{
			case 0:
				num4 = rot.y;
				num5 = rot.z;
				num6 = rot.w;
				num7 = rot.x;
				break;
			case 1:
				num4 = rot.x;
				num5 = rot.z;
				num6 = rot.w;
				num7 = rot.y;
				break;
			case 2:
				num4 = rot.x;
				num5 = rot.y;
				num6 = rot.w;
				num7 = rot.z;
				break;
			default:
				num4 = rot.x;
				num5 = rot.y;
				num6 = rot.z;
				num7 = rot.w;
				break;
			}
			if (num7 > 0f)
			{
				return (uint)(num4 * 724.0772f + 512f) | ((uint)(num5 * 724.0772f + 512f) << 10) | ((uint)(num6 * 724.0772f + 512f) << 20) | (uint)(num3 << 30);
			}
			return (uint)((0f - num4) * 724.0772f + 512f) | ((uint)((0f - num5) * 724.0772f + 512f) << 10) | ((uint)((0f - num6) * 724.0772f + 512f) << 20) | (uint)(num3 << 30);
		}

		public static Quaternion QuaternionDecompress(uint buffer)
		{
			int num = (int)(0x3FF & buffer);
			int num2 = (int)(0x3FF & (buffer >> 10));
			int num3 = (int)(0x3FF & (buffer >> 20));
			int num4 = (int)(buffer >> 30);
			float num5 = (float)((long)num - 512L) * 0.0013810681f;
			float num6 = (float)((long)num2 - 512L) * 0.0013810681f;
			float num7 = (float)((long)num3 - 512L) * 0.0013810681f;
			float num8 = (float)Math.Sqrt(1.0 - (double)(num5 * num5 + num6 * num6 + num7 * num7));
			return num4 switch
			{
				0 => new Quaternion(num8, num5, num6, num7), 
				1 => new Quaternion(num5, num8, num6, num7), 
				2 => new Quaternion(num5, num6, num8, num7), 
				_ => new Quaternion(num5, num6, num7, num8), 
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int SizeOfBits<T>() where T : unmanaged
		{
			return sizeof(T) * 8;
		}

		public static int BytesRequiredForBits(int b)
		{
			return b + 7 >> 3;
		}

		public static int IntsRequiredForBits(int b)
		{
			return b + 31 >> 5;
		}

		public static short BytesRequiredForBits(short b)
		{
			return (short)(b + 7 >> 3);
		}

		public unsafe static string PrintBits(byte* data, int count)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[lo ");
			for (int i = 0; i < count; i++)
			{
				byte b = data[i];
				for (int j = 0; j < 8; j++)
				{
					stringBuilder.Append(((b & (1 << j)) == 1 << j) ? '1' : '0');
				}
				if (i + 1 < count)
				{
					stringBuilder.Append(" ");
				}
			}
			stringBuilder.Append(" hi]");
			return stringBuilder.ToString();
		}

		public static int BitsRequiredForNumber(int n)
		{
			for (int num = 31; num >= 0; num--)
			{
				int num2 = 1 << num;
				if ((n & num2) == num2)
				{
					return num + 1;
				}
			}
			return 0;
		}

		public static int FloorToInt(double value)
		{
			return (int)Math.Floor(value);
		}

		public static int CeilToInt(double value)
		{
			return (int)Math.Ceiling(value);
		}

		public static int CountUsedBitsMinOne(uint value)
		{
			Assert.Check(value != 0);
			int num = 0;
			do
			{
				num++;
				value >>= 1;
			}
			while (value != 0);
			return num;
		}

		public static int BitsRequiredForNumber(uint n)
		{
			for (int num = 31; num >= 0; num--)
			{
				int num2 = 1 << num;
				if ((n & num2) == num2)
				{
					return num + 1;
				}
			}
			return 0;
		}

		public static uint NextPowerOfTwo(uint v)
		{
			v--;
			v |= v >> 1;
			v |= v >> 2;
			v |= v >> 4;
			v |= v >> 8;
			v |= v >> 16;
			v++;
			return v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int CountSetBits(ulong x)
		{
			x -= (x >> 1) & 0x5555555555555555L;
			x = (x & 0x3333333333333333L) + ((x >> 2) & 0x3333333333333333L);
			x = (x + (x >> 4)) & 0xF0F0F0F0F0F0F0FL;
			return (int)(x * 72340172838076673L >> 56);
		}

		public static double MillisecondsToSeconds(double seconds)
		{
			return seconds / 1000.0;
		}

		public static long SecondsToMilliseconds(double seconds)
		{
			return (long)(seconds * 1000.0);
		}

		public static long SecondsToMicroseconds(double seconds)
		{
			return (long)(seconds * 1000000.0);
		}

		public static double MicrosecondsToSeconds(long microseconds)
		{
			return (double)microseconds / 1000000.0;
		}

		public static long MillisecondsToMicroseconds(long milliseconds)
		{
			return milliseconds * 1000;
		}

		public static double CosineInterpolate(double a, double b, double t)
		{
			double num = (1.0 - Math.Cos(t * Math.PI)) * 0.5;
			return a * (1.0 - num) + b * num;
		}

		public static byte ClampToByte(int v)
		{
			if (v < 0)
			{
				return 0;
			}
			if (v > 255)
			{
				return byte.MaxValue;
			}
			return (byte)v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int ZigZagEncode(int i)
		{
			return (i >> 31) ^ (i << 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int ZigZagDecode(int i)
		{
			return (i >> 1) ^ -(i & 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long ZigZagEncode(long i)
		{
			return (i >> 63) ^ (i << 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long ZigZagDecode(long i)
		{
			return (i >> 1) ^ -(i & 1);
		}

		public static int Clamp(int v, int min, int max)
		{
			if (v < min)
			{
				return min;
			}
			if (v > max)
			{
				return max;
			}
			return v;
		}

		public static uint Clamp(uint v, uint min, uint max)
		{
			if (v < min)
			{
				return min;
			}
			if (v > max)
			{
				return max;
			}
			return v;
		}

		public static double Clamp(double v, double min, double max)
		{
			if (v < min)
			{
				return min;
			}
			if (v > max)
			{
				return max;
			}
			return v;
		}

		public static float Clamp(float v, float min, float max)
		{
			if (v < min)
			{
				return min;
			}
			if (v > max)
			{
				return max;
			}
			return v;
		}

		public static double Clamp01(double v)
		{
			if (v < 0.0)
			{
				return 0.0;
			}
			if (v > 1.0)
			{
				return 1.0;
			}
			return v;
		}

		public static float Clamp01(float v)
		{
			if (v < 0f)
			{
				return 0f;
			}
			if (v > 1f)
			{
				return 1f;
			}
			return v;
		}

		public static float Lerp(float a, float b, float t)
		{
			return a + (b - a) * Clamp01(t);
		}

		public static double Lerp(double a, double b, double t)
		{
			return a + (b - a) * Clamp01(t);
		}

		public static uint Min(uint v, uint max)
		{
			if (v > max)
			{
				return max;
			}
			return v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int BitScanReverse(int v)
		{
			return BitScanReverse((uint)v);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int BitScanReverse(uint v)
		{
			v |= v >> 1;
			v |= v >> 2;
			v |= v >> 4;
			v |= v >> 8;
			v |= v >> 16;
			return _debruijnTable32[v * 130329821 >> 27];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int BitScanReverse(long v)
		{
			return BitScanReverse((ulong)v);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int BitScanReverse(ulong v)
		{
			v |= v >> 1;
			v |= v >> 2;
			v |= v >> 4;
			v |= v >> 8;
			v |= v >> 16;
			v |= v >> 32;
			return DeBruijnLookupLong[v * 7783611145303519083L >> 57];
		}
	}
	public static class Native
	{
		public const int ALIGNMENT = 8;

		public const int CACHE_LINE_SIZE = 64;

		private const int SentinelLeadingSize = 0;

		private const int SentinelTrailingSize = 0;

		private const ulong SentinelLeadingPattern = 15705636252112664309uL;

		private const ulong SentinelTrailingPattern = 12580085127939517179uL;

		public unsafe static void MemMove(void* destination, void* source, int size)
		{
			if (destination != null && source != null)
			{
				UnsafeUtility.MemMove(destination, source, size);
			}
		}

		public unsafe static void MemCpy(void* destination, void* source, int size)
		{
			if (destination != null && source != null)
			{
				UnsafeUtility.MemCpy(destination, source, size);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe static void MemCpy(Span<int> d, Span<int> s)
		{
			Assert.Always(s.Length <= d.Length, s.Length, d.Length);
			UnsafeUtility.MemCpy(d.AsPointer<byte>(), s.AsPointer<byte>(), 4 * d.Length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe static void MemCpy(Span<byte> d, Span<byte> s)
		{
			Assert.Always(s.Length <= d.Length, s.Length, d.Length);
			UnsafeUtility.MemCpy(d.AsPointer<byte>(), s.AsPointer<byte>(), d.Length);
		}

		public unsafe static void MemClear(void* ptr, int size)
		{
			if (ptr != null)
			{
				UnsafeUtility.MemClear(ptr, size);
			}
		}

		public unsafe static int MemCmp(void* ptr1, void* ptr2, int size)
		{
			if (ptr1 == null || ptr2 == null)
			{
				return 0;
			}
			return UnsafeUtility.MemCmp(ptr1, ptr2, size);
		}

		public unsafe static void* Malloc(int size)
		{
			if (size <= 0)
			{
				throw new Exception($"Trying to allocate <= bytes: {size}");
			}
			if (size > 1073741824)
			{
				throw new Exception($"Trying to allocate very large block: {size} bytes");
			}
			return UnsafeUtility.Malloc(size, 8, Allocator.Persistent);
		}

		private unsafe static void Free(void* memory)
		{
			if (memory != null)
			{
				UnsafeUtility.Free(memory, Allocator.Persistent);
			}
		}

		public static int SizeOf(Type t)
		{
			return UnsafeUtility.SizeOf(t);
		}

		public static int GetFieldOffset(FieldInfo fi)
		{
			return UnsafeUtility.GetFieldOffset(fi);
		}

		public unsafe static void Free(ref void* memory)
		{
			void* memory2 = memory;
			memory = null;
			Free(memory2);
		}

		public unsafe static void Free<T>(ref T* memory) where T : unmanaged
		{
			T* memory2 = memory;
			memory = null;
			Free(memory2);
		}

		public unsafe static void Free<T>(ref T** memory) where T : unmanaged
		{
			T** memory2 = memory;
			memory = null;
			Free(memory2);
		}

		public unsafe static void* MallocAndClear(int size)
		{
			void* ptr = Malloc(size);
			MemClear(ptr, size);
			return ptr;
		}

		public unsafe static T* MallocAndClear<T>() where T : unmanaged
		{
			T* ptr = Malloc<T>();
			MemClear(ptr, sizeof(T));
			return ptr;
		}

		public unsafe static T* Malloc<T>() where T : unmanaged
		{
			return (T*)Malloc(sizeof(T));
		}

		public unsafe static void* MallocAndClearArray(int stride, int length)
		{
			void* ptr = Malloc(stride * length);
			MemClear(ptr, stride * length);
			return ptr;
		}

		public unsafe static T* MallocAndClearArray<T>(int length) where T : unmanaged
		{
			return (T*)MallocAndClearArray(sizeof(T), length);
		}

		public unsafe static T* MallocAndClearArrayMin1<T>(int length) where T : unmanaged
		{
			return MallocAndClearArray<T>(Math.Max(1, length));
		}

		public unsafe static T** MallocAndClearPtrArray<T>(int length) where T : unmanaged
		{
			return (T**)MallocAndClearArray(sizeof(T*), length);
		}

		public unsafe static T** MallocAndClearPtrArrayMin1<T>(int length) where T : unmanaged
		{
			return MallocAndClearPtrArray<T>(Math.Max(1, length));
		}

		public unsafe static void ArrayCopy(void* source, int sourceIndex, void* destination, int destinationIndex, int count, int elementStride)
		{
			MemCpy((byte*)destination + destinationIndex * elementStride, (byte*)source + sourceIndex * elementStride, count * elementStride);
		}

		public unsafe static void ArrayClear<T>(T* ptr, int size) where T : unmanaged
		{
			MemClear(ptr, sizeof(T) * size);
		}

		public unsafe static int ArrayCompare<T>(T* ptr1, T* ptr2, int size) where T : unmanaged
		{
			return MemCmp(ptr1, ptr2, sizeof(T) * size);
		}

		public unsafe static T* DoubleArray<T>(T* array, int currentLength) where T : unmanaged
		{
			Assert.Check(currentLength > 0);
			return ExpandArray(array, currentLength, currentLength * 2);
		}

		public unsafe static T* ExpandArray<T>(T* array, int currentLength, int newLength) where T : unmanaged
		{
			Assert.Check(newLength > currentLength);
			T* ptr = MallocAndClearArray<T>(newLength);
			MemCpy(ptr, array, sizeof(T) * currentLength);
			Free(array);
			return ptr;
		}

		public unsafe static T** DoublePtrArray<T>(T** array, int currentLength) where T : unmanaged
		{
			return ExpandPtrArray(array, currentLength, currentLength * 2);
		}

		public unsafe static T** ExpandPtrArray<T>(T** array, int currentLength, int newLength) where T : unmanaged
		{
			Assert.Check(newLength > currentLength);
			T** ptr = MallocAndClearPtrArray<T>(newLength);
			MemCpy(ptr, array, sizeof(T*) * currentLength);
			Free(array);
			return ptr;
		}

		public unsafe static void* Expand(void* buffer, int currentSize, int newSize)
		{
			Assert.Check(newSize > currentSize);
			void* ptr = MallocAndClear(newSize);
			MemCpy(ptr, buffer, currentSize);
			Free(buffer);
			return ptr;
		}

		public unsafe static void MemCpyFast(void* d, void* s, int size)
		{
			switch (size)
			{
			case 4:
				*(int*)d = *(int*)s;
				break;
			case 8:
				*(long*)d = *(long*)s;
				break;
			case 12:
				*(long*)d = *(long*)s;
				((int*)d)[2] = ((int*)s)[2];
				break;
			case 16:
				*(long*)d = *(long*)s;
				((long*)d)[1] = ((long*)s)[1];
				break;
			default:
				MemCpy(d, s, size);
				break;
			}
		}

		public unsafe static int CopyFromArray<T>(void* destination, T[] source) where T : unmanaged
		{
			fixed (T* source2 = source)
			{
				MemCpy(destination, source2, source.Length * sizeof(T));
				return source.Length * sizeof(T);
			}
		}

		public unsafe static int CopyToArray<T>(T[] destination, void* source) where T : unmanaged
		{
			fixed (T* destination2 = destination)
			{
				MemCpy(destination2, source, destination.Length * sizeof(T));
				return destination.Length * sizeof(T);
			}
		}

		public static int GetLengthPrefixedUTF8ByteCount(string str)
		{
			return 4 + Encoding.UTF8.GetByteCount(str);
		}

		public unsafe static int WriteLengthPrefixedUTF8(void* destination, string str)
		{
			fixed (char* chars = str)
			{
				int byteCount = Encoding.UTF8.GetByteCount(str);
				int bytes = Encoding.UTF8.GetBytes(chars, str.Length, (byte*)destination + 4, byteCount);
				Assert.Check(byteCount == bytes, "Expected byte count mismatch {0} {1}", byteCount, bytes);
				*(int*)destination = bytes;
				return 4 + bytes;
			}
		}

		public unsafe static int ReadLengthPrefixedUTF8(void* source, out string result)
		{
			int num = *(int*)source;
			result = Encoding.UTF8.GetString((byte*)source + 4, num);
			return num + 4;
		}

		public unsafe static bool IsPointerAligned(void* pointer, int alignment)
		{
			return (long)pointer % (long)alignment == 0;
		}

		public unsafe static void* AlignPointer(void* pointer, int alignment)
		{
			long num = (long)pointer;
			if (num % alignment != 0)
			{
				return (byte*)pointer + (alignment - num % alignment);
			}
			return pointer;
		}

		public static int RoundToMaxAlignment(int stride)
		{
			return RoundToAlignment(stride, 8);
		}

		public static int WordCount(int stride, int wordSize)
		{
			return RoundToAlignment(stride, wordSize) / wordSize;
		}

		public static bool IsAligned(int stride, int alignment)
		{
			return RoundToAlignment(stride, alignment) == stride;
		}

		public static int RoundToAlignment(int stride, int alignment)
		{
			return alignment switch
			{
				1 => stride, 
				2 => (stride + 1 >> 1) * 2, 
				4 => (stride + 3 >> 2) * 4, 
				8 => (stride + 7 >> 3) * 8, 
				16 => (stride + 15 >> 4) * 16, 
				32 => (stride + 31 >> 5) * 32, 
				_ => throw new InvalidOperationException($"Invalid Alignment: {alignment}"), 
			};
		}

		public static long RoundToAlignment(long stride, int alignment)
		{
			return alignment switch
			{
				1 => stride, 
				2 => (stride + 1 >> 1) * 2, 
				4 => (stride + 3 >> 2) * 4, 
				8 => (stride + 7 >> 3) * 8, 
				16 => (stride + 15 >> 4) * 16, 
				32 => (stride + 31 >> 5) * 32, 
				_ => throw new InvalidOperationException($"Invalid Alignment: {alignment}"), 
			};
		}

		public static T Empty<T>() where T : unmanaged
		{
			return new T();
		}

		public static int RoundBitsUpTo64(int bits)
		{
			return (bits + 63 >> 6) * 64;
		}

		public static int RoundBitsUpTo32(int bits)
		{
			return (bits + 31 >> 5) * 32;
		}

		public unsafe static int GetAlignment<T>() where T : unmanaged
		{
			return GetAlignment(sizeof(T));
		}

		public static int GetAlignment(int stride)
		{
			if (stride % 16 == 0)
			{
				return 16;
			}
			if (stride % 8 == 0)
			{
				return 8;
			}
			if (stride % 4 == 0)
			{
				return 4;
			}
			return (stride % 2 != 0) ? 1 : 2;
		}

		public static int GetMaxAlignment(int a, int b)
		{
			return Math.Max(GetAlignment(a), GetAlignment(b));
		}

		public static int GetMaxAlignment(int a, int b, int c)
		{
			return Math.Max(GetMaxAlignment(a, b), GetAlignment(c));
		}

		public static int GetMaxAlignment(int a, int b, int c, int d)
		{
			return Math.Max(GetMaxAlignment(a, b, c), GetAlignment(d));
		}

		public static int GetMaxAlignment(int a, int b, int c, int d, int e)
		{
			return Math.Max(GetMaxAlignment(a, b, c, e), GetAlignment(e));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static byte* ReferenceToPointer<T>(ref T obj) where T : unmanaged
		{
			fixed (T* result = &obj)
			{
				return (byte*)result;
			}
		}

		[Conditional("ENABLE_NATIVE_ALLOC_SENTINELS")]
		private unsafe static void InitBlockSentinels(IntPtr memory, int size)
		{
			ulong num = 15705636252112664309uL;
			ulong num2 = 12580085127939517179uL;
			Span<byte> dst = new Span<byte>((void*)memory, 0);
			Span<byte> dst2 = new Span<byte>((byte*)(void*)memory + size, 0);
			new ReadOnlySpan<byte>(&num, 8).RepeatingCopyTo(dst);
			new ReadOnlySpan<byte>(&num2, 8).RepeatingCopyTo(dst2);
		}

		[Conditional("ENABLE_NATIVE_ALLOC_SENTINELS")]
		public unsafe static void ValidateBlockSentinels(IntPtr memory, int size)
		{
			ulong num = 15705636252112664309uL;
			ulong num2 = 12580085127939517179uL;
			ReadOnlySpan<byte> readOnlySpan = new ReadOnlySpan<byte>((void*)memory, 0);
			ReadOnlySpan<byte> readOnlySpan2 = new ReadOnlySpan<byte>((byte*)(void*)memory + size, 0);
			if (!readOnlySpan.RepeatingSequenceEqualTo(new ReadOnlySpan<byte>(&num, 8)))
			{
				InternalLogStreams.LogError?.Log("MSG600 Leading sentinel mismatch: " + BinUtils.BytesToHex(readOnlySpan));
			}
			if (!readOnlySpan2.RepeatingSequenceEqualTo(new ReadOnlySpan<byte>(&num2, 8)))
			{
				InternalLogStreams.LogError?.Log("MSG601 Trailing sentinel mismatch: " + BinUtils.BytesToHex(readOnlySpan2));
			}
		}

		public unsafe static int MallocAndClearBlock(int size0, int size1, out void* ptr0, out void* ptr1, int alignment = 8)
		{
			size0 = RoundToAlignment(size0, alignment);
			size1 = RoundToAlignment(size1, alignment);
			int num = size0 + size1;
			byte* ptr2 = (byte*)(ptr0 = MallocAndClear(num)) + size0;
			ptr1 = ptr2;
			Assert.Check(IsPointerAligned(ptr0, alignment));
			Assert.Check(IsPointerAligned(ptr1, alignment));
			return num;
		}

		public unsafe static int MallocAndClearBlock(int size0, int size1, int size2, out void* ptr0, out void* ptr1, out void* ptr2, int alignment = 8)
		{
			size0 = RoundToAlignment(size0, alignment);
			size1 = RoundToAlignment(size1, alignment);
			size2 = RoundToAlignment(size2, alignment);
			int num = size0 + size1 + size2;
			byte* ptr3 = (byte*)(ptr1 = (byte*)(ptr0 = MallocAndClear(num)) + size0) + size1;
			ptr2 = ptr3;
			Assert.Check(IsPointerAligned(ptr0, alignment));
			Assert.Check(IsPointerAligned(ptr1, alignment));
			Assert.Check(IsPointerAligned(ptr2, alignment));
			return num;
		}

		public unsafe static int MallocAndClearBlock(int size0, int size1, int size2, int size3, out void* ptr0, out void* ptr1, out void* ptr2, out void* ptr3, int alignment = 8)
		{
			size0 = RoundToAlignment(size0, alignment);
			size1 = RoundToAlignment(size1, alignment);
			size2 = RoundToAlignment(size2, alignment);
			size3 = RoundToAlignment(size3, alignment);
			int num = size0 + size1 + size2 + size3;
			byte* ptr4 = (byte*)(ptr2 = (byte*)(ptr1 = (byte*)(ptr0 = MallocAndClear(num)) + size0) + size1) + size2;
			ptr3 = ptr4;
			Assert.Check(IsPointerAligned(ptr0, alignment));
			Assert.Check(IsPointerAligned(ptr1, alignment));
			Assert.Check(IsPointerAligned(ptr2, alignment));
			Assert.Check(IsPointerAligned(ptr3, alignment));
			return num;
		}

		public unsafe static int MallocAndClearBlock(int size0, int size1, int size2, int size3, int size4, out void* ptr0, out void* ptr1, out void* ptr2, out void* ptr3, out void* ptr4, int alignment = 8)
		{
			size0 = RoundToAlignment(size0, alignment);
			size1 = RoundToAlignment(size1, alignment);
			size2 = RoundToAlignment(size2, alignment);
			size3 = RoundToAlignment(size3, alignment);
			size4 = RoundToAlignment(size4, alignment);
			int num = size0 + size1 + size2 + size3 + size4;
			byte* ptr5 = (byte*)(ptr3 = (byte*)(ptr2 = (byte*)(ptr1 = (byte*)(ptr0 = MallocAndClear(num)) + size0) + size1) + size2) + size3;
			ptr4 = ptr5;
			Assert.Check(IsPointerAligned(ptr0, alignment));
			Assert.Check(IsPointerAligned(ptr1, alignment));
			Assert.Check(IsPointerAligned(ptr2, alignment));
			Assert.Check(IsPointerAligned(ptr3, alignment));
			Assert.Check(IsPointerAligned(ptr4, alignment));
			return num;
		}

		public unsafe static int MallocAndClearBlock(int size0, int size1, int size2, int size3, int size4, int size5, out void* ptr0, out void* ptr1, out void* ptr2, out void* ptr3, out void* ptr4, out void* ptr5, int alignment = 8)
		{
			size0 = RoundToAlignment(size0, alignment);
			size1 = RoundToAlignment(size1, alignment);
			size2 = RoundToAlignment(size2, alignment);
			size3 = RoundToAlignment(size3, alignment);
			size4 = RoundToAlignment(size4, alignment);
			size5 = RoundToAlignment(size5, alignment);
			int num = size0 + size1 + size2 + size3 + size4 + size5;
			byte* ptr6 = (byte*)(ptr4 = (byte*)(ptr3 = (byte*)(ptr2 = (byte*)(ptr1 = (byte*)(ptr0 = MallocAndClear(num)) + size0) + size1) + size2) + size3) + size4;
			ptr5 = ptr6;
			Assert.Check(IsPointerAligned(ptr0, alignment));
			Assert.Check(IsPointerAligned(ptr1, alignment));
			Assert.Check(IsPointerAligned(ptr2, alignment));
			Assert.Check(IsPointerAligned(ptr3, alignment));
			Assert.Check(IsPointerAligned(ptr4, alignment));
			Assert.Check(IsPointerAligned(ptr5, alignment));
			return num;
		}

		public unsafe static int MallocAndClearBlock(int size0, int size1, int size2, int size3, int size4, int size5, int size6, out void* ptr0, out void* ptr1, out void* ptr2, out void* ptr3, out void* ptr4, out void* ptr5, out void* ptr6, int alignment = 8)
		{
			size0 = RoundToAlignment(size0, alignment);
			size1 = RoundToAlignment(size1, alignment);
			size2 = RoundToAlignment(size2, alignment);
			size3 = RoundToAlignment(size3, alignment);
			size4 = RoundToAlignment(size4, alignment);
			size5 = RoundToAlignment(size5, alignment);
			size6 = RoundToAlignment(size6, alignment);
			int num = size0 + size1 + size2 + size3 + size4 + size5 + size6;
			byte* ptr7 = (byte*)(ptr5 = (byte*)(ptr4 = (byte*)(ptr3 = (byte*)(ptr2 = (byte*)(ptr1 = (byte*)(ptr0 = MallocAndClear(num)) + size0) + size1) + size2) + size3) + size4) + size5;
			ptr6 = ptr7;
			Assert.Check(IsPointerAligned(ptr0, alignment));
			Assert.Check(IsPointerAligned(ptr1, alignment));
			Assert.Check(IsPointerAligned(ptr2, alignment));
			Assert.Check(IsPointerAligned(ptr3, alignment));
			Assert.Check(IsPointerAligned(ptr4, alignment));
			Assert.Check(IsPointerAligned(ptr5, alignment));
			Assert.Check(IsPointerAligned(ptr6, alignment));
			return num;
		}

		public unsafe static int MallocAndClearBlock(int size0, int size1, int size2, int size3, int size4, int size5, int size6, int size7, out void* ptr0, out void* ptr1, out void* ptr2, out void* ptr3, out void* ptr4, out void* ptr5, out void* ptr6, out void* ptr7, int alignment = 8)
		{
			size0 = RoundToAlignment(size0, alignment);
			size1 = RoundToAlignment(size1, alignment);
			size2 = RoundToAlignment(size2, alignment);
			size3 = RoundToAlignment(size3, alignment);
			size4 = RoundToAlignment(size4, alignment);
			size5 = RoundToAlignment(size5, alignment);
			size6 = RoundToAlignment(size6, alignment);
			size7 = RoundToAlignment(size7, alignment);
			int num = size0 + size1 + size2 + size3 + size4 + size5 + size6 + size7;
			byte* ptr8 = (byte*)(ptr6 = (byte*)(ptr5 = (byte*)(ptr4 = (byte*)(ptr3 = (byte*)(ptr2 = (byte*)(ptr1 = (byte*)(ptr0 = MallocAndClear(num)) + size0) + size1) + size2) + size3) + size4) + size5) + size6;
			ptr7 = ptr8;
			Assert.Check(IsPointerAligned(ptr0, alignment));
			Assert.Check(IsPointerAligned(ptr1, alignment));
			Assert.Check(IsPointerAligned(ptr2, alignment));
			Assert.Check(IsPointerAligned(ptr3, alignment));
			Assert.Check(IsPointerAligned(ptr4, alignment));
			Assert.Check(IsPointerAligned(ptr5, alignment));
			Assert.Check(IsPointerAligned(ptr6, alignment));
			Assert.Check(IsPointerAligned(ptr7, alignment));
			return num;
		}

		public unsafe static int MallocAndClearBlock(int size0, int size1, int size2, int size3, int size4, int size5, int size6, int size7, int size8, out void* ptr0, out void* ptr1, out void* ptr2, out void* ptr3, out void* ptr4, out void* ptr5, out void* ptr6, out void* ptr7, out void* ptr8, int alignment = 8)
		{
			size0 = RoundToAlignment(size0, alignment);
			size1 = RoundToAlignment(size1, alignment);
			size2 = RoundToAlignment(size2, alignment);
			size3 = RoundToAlignment(size3, alignment);
			size4 = RoundToAlignment(size4, alignment);
			size5 = RoundToAlignment(size5, alignment);
			size6 = RoundToAlignment(size6, alignment);
			size7 = RoundToAlignment(size7, alignment);
			size8 = RoundToAlignment(size8, alignment);
			int num = size0 + size1 + size2 + size3 + size4 + size5 + size6 + size7 + size8;
			byte* ptr9 = (byte*)(ptr7 = (byte*)(ptr6 = (byte*)(ptr5 = (byte*)(ptr4 = (byte*)(ptr3 = (byte*)(ptr2 = (byte*)(ptr1 = (byte*)(ptr0 = MallocAndClear(num)) + size0) + size1) + size2) + size3) + size4) + size5) + size6) + size7;
			ptr8 = ptr9;
			Assert.Check(IsPointerAligned(ptr0, alignment));
			Assert.Check(IsPointerAligned(ptr1, alignment));
			Assert.Check(IsPointerAligned(ptr2, alignment));
			Assert.Check(IsPointerAligned(ptr3, alignment));
			Assert.Check(IsPointerAligned(ptr4, alignment));
			Assert.Check(IsPointerAligned(ptr5, alignment));
			Assert.Check(IsPointerAligned(ptr6, alignment));
			Assert.Check(IsPointerAligned(ptr7, alignment));
			Assert.Check(IsPointerAligned(ptr8, alignment));
			return num;
		}

		public unsafe static int MallocAndClearBlock(int size0, int size1, int size2, int size3, int size4, int size5, int size6, int size7, int size8, int size9, out void* ptr0, out void* ptr1, out void* ptr2, out void* ptr3, out void* ptr4, out void* ptr5, out void* ptr6, out void* ptr7, out void* ptr8, out void* ptr9, int alignment = 8)
		{
			size0 = RoundToAlignment(size0, alignment);
			size1 = RoundToAlignment(size1, alignment);
			size2 = RoundToAlignment(size2, alignment);
			size3 = RoundToAlignment(size3, alignment);
			size4 = RoundToAlignment(size4, alignment);
			size5 = RoundToAlignment(size5, alignment);
			size6 = RoundToAlignment(size6, alignment);
			size7 = RoundToAlignment(size7, alignment);
			size8 = RoundToAlignment(size8, alignment);
			size9 = RoundToAlignment(size9, alignment);
			int num = size0 + size1 + size2 + size3 + size4 + size5 + size6 + size7 + size8 + size9;
			byte* ptr10 = (byte*)(ptr8 = (byte*)(ptr7 = (byte*)(ptr6 = (byte*)(ptr5 = (byte*)(ptr4 = (byte*)(ptr3 = (byte*)(ptr2 = (byte*)(ptr1 = (byte*)(ptr0 = MallocAndClear(num)) + size0) + size1) + size2) + size3) + size4) + size5) + size6) + size7) + size8;
			ptr9 = ptr10;
			Assert.Check(IsPointerAligned(ptr0, alignment));
			Assert.Check(IsPointerAligned(ptr1, alignment));
			Assert.Check(IsPointerAligned(ptr2, alignment));
			Assert.Check(IsPointerAligned(ptr3, alignment));
			Assert.Check(IsPointerAligned(ptr4, alignment));
			Assert.Check(IsPointerAligned(ptr5, alignment));
			Assert.Check(IsPointerAligned(ptr6, alignment));
			Assert.Check(IsPointerAligned(ptr7, alignment));
			Assert.Check(IsPointerAligned(ptr8, alignment));
			Assert.Check(IsPointerAligned(ptr9, alignment));
			return num;
		}

		public unsafe static int MallocAndClearBlock(int size0, int size1, int size2, int size3, int size4, int size5, int size6, int size7, int size8, int size9, int size10, out void* ptr0, out void* ptr1, out void* ptr2, out void* ptr3, out void* ptr4, out void* ptr5, out void* ptr6, out void* ptr7, out void* ptr8, out void* ptr9, out void* ptr10, int alignment = 8)
		{
			size0 = RoundToAlignment(size0, alignment);
			size1 = RoundToAlignment(size1, alignment);
			size2 = RoundToAlignment(size2, alignment);
			size3 = RoundToAlignment(size3, alignment);
			size4 = RoundToAlignment(size4, alignment);
			size5 = RoundToAlignment(size5, alignment);
			size6 = RoundToAlignment(size6, alignment);
			size7 = RoundToAlignment(size7, alignment);
			size8 = RoundToAlignment(size8, alignment);
			size9 = RoundToAlignment(size9, alignment);
			size10 = RoundToAlignment(size10, alignment);
			int num = size0 + size1 + size2 + size3 + size4 + size5 + size6 + size7 + size8 + size9 + size10;
			byte* ptr11 = (byte*)(ptr9 = (byte*)(ptr8 = (byte*)(ptr7 = (byte*)(ptr6 = (byte*)(ptr5 = (byte*)(ptr4 = (byte*)(ptr3 = (byte*)(ptr2 = (byte*)(ptr1 = (byte*)(ptr0 = MallocAndClear(num)) + size0) + size1) + size2) + size3) + size4) + size5) + size6) + size7) + size8) + size9;
			ptr10 = ptr11;
			Assert.Check(IsPointerAligned(ptr0, alignment));
			Assert.Check(IsPointerAligned(ptr1, alignment));
			Assert.Check(IsPointerAligned(ptr2, alignment));
			Assert.Check(IsPointerAligned(ptr3, alignment));
			Assert.Check(IsPointerAligned(ptr4, alignment));
			Assert.Check(IsPointerAligned(ptr5, alignment));
			Assert.Check(IsPointerAligned(ptr6, alignment));
			Assert.Check(IsPointerAligned(ptr7, alignment));
			Assert.Check(IsPointerAligned(ptr8, alignment));
			Assert.Check(IsPointerAligned(ptr9, alignment));
			Assert.Check(IsPointerAligned(ptr10, alignment));
			return num;
		}

		public unsafe static int MallocAndClearBlock(int size0, int size1, int size2, int size3, int size4, int size5, int size6, int size7, int size8, int size9, int size10, int size11, out void* ptr0, out void* ptr1, out void* ptr2, out void* ptr3, out void* ptr4, out void* ptr5, out void* ptr6, out void* ptr7, out void* ptr8, out void* ptr9, out void* ptr10, out void* ptr11, int alignment = 8)
		{
			size0 = RoundToAlignment(size0, alignment);
			size1 = RoundToAlignment(size1, alignment);
			size2 = RoundToAlignment(size2, alignment);
			size3 = RoundToAlignment(size3, alignment);
			size4 = RoundToAlignment(size4, alignment);
			size5 = RoundToAlignment(size5, alignment);
			size6 = RoundToAlignment(size6, alignment);
			size7 = RoundToAlignment(size7, alignment);
			size8 = RoundToAlignment(size8, alignment);
			size9 = RoundToAlignment(size9, alignment);
			size10 = RoundToAlignment(size10, alignment);
			size11 = RoundToAlignment(size11, alignment);
			int num = size0 + size1 + size2 + size3 + size4 + size5 + size6 + size7 + size8 + size9 + size10 + size11;
			byte* ptr12 = (byte*)(ptr10 = (byte*)(ptr9 = (byte*)(ptr8 = (byte*)(ptr7 = (byte*)(ptr6 = (byte*)(ptr5 = (byte*)(ptr4 = (byte*)(ptr3 = (byte*)(ptr2 = (byte*)(ptr1 = (byte*)(ptr0 = MallocAndClear(num)) + size0) + size1) + size2) + size3) + size4) + size5) + size6) + size7) + size8) + size9) + size10;
			ptr11 = ptr12;
			Assert.Check(IsPointerAligned(ptr0, alignment));
			Assert.Check(IsPointerAligned(ptr1, alignment));
			Assert.Check(IsPointerAligned(ptr2, alignment));
			Assert.Check(IsPointerAligned(ptr3, alignment));
			Assert.Check(IsPointerAligned(ptr4, alignment));
			Assert.Check(IsPointerAligned(ptr5, alignment));
			Assert.Check(IsPointerAligned(ptr6, alignment));
			Assert.Check(IsPointerAligned(ptr7, alignment));
			Assert.Check(IsPointerAligned(ptr8, alignment));
			Assert.Check(IsPointerAligned(ptr9, alignment));
			Assert.Check(IsPointerAligned(ptr10, alignment));
			Assert.Check(IsPointerAligned(ptr11, alignment));
			return num;
		}
	}
	public static class Primes
	{
		private static int[] _primeTable = new int[30]
		{
			3, 7, 17, 29, 53, 97, 193, 389, 769, 1543,
			3079, 6151, 12289, 24593, 49157, 98317, 196613, 393241, 786433, 1572869,
			3145739, 6291469, 12582917, 25165843, 50331653, 100663319, 201326611, 402653189, 805306457, 1610612741
		};

		public static bool IsPrime(int value)
		{
			for (int i = 0; i < _primeTable.Length; i++)
			{
				if (_primeTable[i] == value)
				{
					return true;
				}
			}
			return false;
		}

		public static int GetNextPrime(int value)
		{
			for (int i = 0; i < _primeTable.Length; i++)
			{
				if (_primeTable[i] > value)
				{
					return _primeTable[i];
				}
			}
			throw new InvalidOperationException($"HashCollection can't get larger than {_primeTable[_primeTable.Length - 1]}");
		}

		public static uint GetNextPrime(uint value)
		{
			for (int i = 0; i < _primeTable.Length; i++)
			{
				if ((uint)_primeTable[i] > value)
				{
					return (uint)_primeTable[i];
				}
			}
			throw new InvalidOperationException($"HashCollection can't get larger than {_primeTable[_primeTable.Length - 1]}");
		}
	}
	public struct Timer
	{
		private long _start;

		private long _elapsed;

		private byte _running;

		public long ElapsedInTicks
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (_running == 1) ? (_elapsed + GetDelta()) : _elapsed;
			}
		}

		public double ElapsedInMilliseconds
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return ElapsedInSeconds * 1000.0;
			}
		}

		public double ElapsedInSeconds
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (double)ElapsedInTicks / (double)Stopwatch.Frequency;
			}
		}

		public bool IsRunning
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _running == 1;
			}
		}

		public static Timer StartNew()
		{
			Timer result = default(Timer);
			result.Start();
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Start()
		{
			if (_running == 0)
			{
				_start = Stopwatch.GetTimestamp();
				_running = 1;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Stop()
		{
			long delta = GetDelta();
			if (_running == 1)
			{
				_elapsed += delta;
				_running = 0;
				if (_elapsed < 0)
				{
					_elapsed = 0L;
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Reset()
		{
			_elapsed = 0L;
			_running = 0;
			_start = 0L;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Restart()
		{
			_elapsed = 0L;
			_running = 1;
			_start = Stopwatch.GetTimestamp();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private long GetDelta()
		{
			return Stopwatch.GetTimestamp() - _start;
		}
	}
	internal struct TimerDelta
	{
		private Timer _timer;

		private double _timerLast;

		public bool IsRunning => _timer.IsRunning;

		public double Consume()
		{
			double elapsedInSeconds = _timer.ElapsedInSeconds;
			double result = Math.Max(elapsedInSeconds - _timerLast, 0.0);
			_timerLast = elapsedInSeconds;
			return result;
		}

		public double Peek()
		{
			return Math.Max(_timer.ElapsedInSeconds - _timerLast, 0.0);
		}

		public static TimerDelta StartNew()
		{
			return new TimerDelta
			{
				_timer = Timer.StartNew()
			};
		}
	}
	[Flags]
	internal enum RuntimeFlagsBuildFlags
	{
		NONE = 0,
		UNITY_WEBGL = 2,
		UNITY_XBOXONE = 4,
		UNITY_GAMECORE = 8,
		UNITY_EDITOR = 0x10,
		UNITY_SWITCH = 0x20,
		UNITY_2019_4_OR_NEWER = 0x40
	}
	[Flags]
	internal enum RuntimeFlagsBuildTypes
	{
		NONE = 0,
		ENABLE_MONO = 2,
		ENABLE_IL2CPP = 4
	}
	[Flags]
	internal enum RuntimeFlagsDotNetVersion
	{
		NONE = 0,
		NET_4_6 = 2,
		NETFX_CORE = 4,
		NET_STANDARD_2_0 = 8
	}
	public static class RuntimeUnityFlagsSetup
	{
		private static RuntimeFlagsBuildFlags flagsBuildFlags;

		private static RuntimeFlagsBuildTypes flagsBuildTypes;

		private static RuntimeFlagsDotNetVersion flagsDotNetVersion;

		internal static bool IsUNITY_WEBGL => (flagsBuildFlags & RuntimeFlagsBuildFlags.UNITY_WEBGL) == RuntimeFlagsBuildFlags.UNITY_WEBGL;

		internal static bool IsUNITY_XBOXONE => (flagsBuildFlags & RuntimeFlagsBuildFlags.UNITY_XBOXONE) == RuntimeFlagsBuildFlags.UNITY_XBOXONE;

		internal static bool IsUNITY_GAMECORE => (flagsBuildFlags & RuntimeFlagsBuildFlags.UNITY_GAMECORE) == RuntimeFlagsBuildFlags.UNITY_GAMECORE;

		internal static bool IsUNITY_EDITOR => (flagsBuildFlags & RuntimeFlagsBuildFlags.UNITY_EDITOR) == RuntimeFlagsBuildFlags.UNITY_EDITOR;

		internal static bool IsUNITY_SWITCH => (flagsBuildFlags & RuntimeFlagsBuildFlags.UNITY_SWITCH) == RuntimeFlagsBuildFlags.UNITY_SWITCH;

		internal static bool IsUNITY_2019_4_OR_NEWER => (flagsBuildFlags & RuntimeFlagsBuildFlags.UNITY_2019_4_OR_NEWER) == RuntimeFlagsBuildFlags.UNITY_2019_4_OR_NEWER;

		internal static bool IsENABLE_MONO => (flagsBuildTypes & RuntimeFlagsBuildTypes.ENABLE_MONO) == RuntimeFlagsBuildTypes.ENABLE_MONO;

		internal static bool IsENABLE_IL2CPP => (flagsBuildTypes & RuntimeFlagsBuildTypes.ENABLE_IL2CPP) == RuntimeFlagsBuildTypes.ENABLE_IL2CPP;

		internal static bool IsNET_4_6 => (flagsDotNetVersion & RuntimeFlagsDotNetVersion.NET_4_6) == RuntimeFlagsDotNetVersion.NET_4_6;

		internal static bool IsNETFX_CORE => (flagsDotNetVersion & RuntimeFlagsDotNetVersion.NETFX_CORE) == RuntimeFlagsDotNetVersion.NETFX_CORE;

		internal static bool IsNET_STANDARD_2_0 => (flagsDotNetVersion & RuntimeFlagsDotNetVersion.NET_STANDARD_2_0) == RuntimeFlagsDotNetVersion.NET_STANDARD_2_0;

		[Conditional("UNITY_WEBGL")]
		public static void Check_UNITY_WEBGL()
		{
			flagsBuildFlags |= RuntimeFlagsBuildFlags.UNITY_WEBGL;
		}

		[Conditional("UNITY_XBOXONE")]
		public static void Check_UNITY_XBOXONE()
		{
			flagsBuildFlags |= RuntimeFlagsBuildFlags.UNITY_XBOXONE;
		}

		[Conditional("UNITY_GAMECORE")]
		public static void Check_UNITY_GAMECORE()
		{
			flagsBuildFlags |= RuntimeFlagsBuildFlags.UNITY_GAMECORE;
		}

		[Conditional("UNITY_EDITOR")]
		public static void Check_UNITY_EDITOR()
		{
			flagsBuildFlags |= RuntimeFlagsBuildFlags.UNITY_EDITOR;
		}

		[Conditional("UNITY_SWITCH")]
		public static void Check_UNITY_SWITCH()
		{
			flagsBuildFlags |= RuntimeFlagsBuildFlags.UNITY_SWITCH;
		}

		[Conditional("UNITY_2019_4_OR_NEWER")]
		public static void Check_UNITY_2019_4_OR_NEWER()
		{
			flagsBuildFlags |= RuntimeFlagsBuildFlags.UNITY_2019_4_OR_NEWER;
		}

		[Conditional("ENABLE_MONO")]
		public static void Check_ENABLE_MONO()
		{
			flagsBuildTypes |= RuntimeFlagsBuildTypes.ENABLE_MONO;
		}

		[Conditional("ENABLE_IL2CPP")]
		public static void Check_ENABLE_IL2CPP()
		{
			flagsBuildTypes |= RuntimeFlagsBuildTypes.ENABLE_IL2CPP;
		}

		[Conditional("NET_4_6")]
		public static void Check_NET_4_6()
		{
			flagsDotNetVersion |= RuntimeFlagsDotNetVersion.NET_4_6;
		}

		[Conditional("NETFX_CORE")]
		public static void Check_NETFX_CORE()
		{
			flagsDotNetVersion |= RuntimeFlagsDotNetVersion.NETFX_CORE;
		}

		[Conditional("NET_STANDARD_2_0")]
		public static void Check_NET_STANDARD_2_0()
		{
			flagsDotNetVersion |= RuntimeFlagsDotNetVersion.NET_STANDARD_2_0;
		}

		public static void Reset()
		{
			flagsBuildFlags = RuntimeFlagsBuildFlags.NONE;
			flagsBuildTypes = RuntimeFlagsBuildTypes.NONE;
			flagsDotNetVersion = RuntimeFlagsDotNetVersion.NONE;
		}
	}
	public static class Unsafe
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref TTo As<TFrom, TTo>(ref TFrom source)
		{
			return ref System.Runtime.CompilerServices.Unsafe.As<TFrom, TTo>(ref source);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void* AsPointer<T>(ref T value)
		{
			return System.Runtime.CompilerServices.Unsafe.AsPointer(ref value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ref T AsRef<T>(void* source)
		{
			return ref *(T*)source;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T AsRef<T>(in T source)
		{
			return ref source;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static T Read<T>(void* source)
		{
			return System.Runtime.CompilerServices.Unsafe.Read<T>(source);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static T ReadUnaligned<T>(void* source)
		{
			return System.Runtime.CompilerServices.Unsafe.ReadUnaligned<T>(source);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T ReadUnaligned<T>(ref byte source)
		{
			return System.Runtime.CompilerServices.Unsafe.ReadUnaligned<T>(ref source);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Write<T>(void* destination, T value)
		{
			System.Runtime.CompilerServices.Unsafe.Write(destination, value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void WriteUnaligned<T>(void* destination, T value)
		{
			System.Runtime.CompilerServices.Unsafe.WriteUnaligned(destination, value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteUnaligned<T>(ref byte destination, T value)
		{
			System.Runtime.CompilerServices.Unsafe.WriteUnaligned(ref destination, value);
		}
	}
	public static class UTF32Tools
	{
		public struct CharEnumerator : IEnumerator<char>, IEnumerator, IDisposable
		{
			private int _index;

			private int _length;

			private char _pendingLowSurrogate;

			private unsafe uint* _ptr;

			public char Current { get; private set; }

			object IEnumerator.Current => Current;

			internal unsafe CharEnumerator(uint* utf32, int length)
			{
				_index = 0;
				Current = (_pendingLowSurrogate = '\0');
				_ptr = utf32;
				_length = length;
			}

			public void Dispose()
			{
			}

			public unsafe bool MoveNext()
			{
				if (_pendingLowSurrogate != 0)
				{
					Current = _pendingLowSurrogate;
					_pendingLowSurrogate = '\0';
					return true;
				}
				if (_index >= _length)
				{
					return false;
				}
				(Current, _pendingLowSurrogate) = ToUTF16(_ptr[_index++]);
				return true;
			}

			public void Reset()
			{
				_index = 0;
			}
		}

		public readonly struct ConversionResult(int words, int characters)
		{
			public readonly int CharacterCount = characters;

			public readonly int CodePointCount = words;
		}

		public unsafe static ConversionResult Convert(string str, uint* dst, int dstCapacity)
		{
			if (string.IsNullOrEmpty(str))
			{
				return default(ConversionResult);
			}
			fixed (char* str2 = str)
			{
				return Convert(str2, str.Length, dst, dstCapacity);
			}
		}

		public unsafe static ConversionResult Convert(char* str, int strLength, uint* dst, int dstCapacity)
		{
			int num = 0;
			int num2 = 0;
			while (num < dstCapacity && num2 < strLength)
			{
				char c = str[num2];
				if ((uint)(c - 55296) >= 2048u)
				{
					dst[num] = c;
				}
				else
				{
					if (!char.IsHighSurrogate(c) || num2 >= strLength - 1 || !char.IsLowSurrogate(str[num2 + 1]))
					{
						Assert.AlwaysFail($"Failed to convert character {c}");
						break;
					}
					char c2 = c;
					char c3 = str[++num2];
					dst[num] = (uint)((c2 - 55296) * 1024 + (c3 - 56320) + 65536);
				}
				num++;
				num2++;
			}
			return new ConversionResult(num, num2);
		}

		internal unsafe static int CompareOrdinal(uint* strA, int aLength, uint* strB, int bLength, bool ignoreCase)
		{
			if (strA == null && aLength > 0)
			{
				throw new ArgumentNullException("strA");
			}
			if (strB == null && bLength > 0)
			{
				throw new ArgumentNullException("strB");
			}
			int num = Math.Min(aLength, bLength);
			if (!ignoreCase)
			{
				for (int i = 0; i < num; i++)
				{
					int num2 = (int)(strA[i] - strB[i]);
					if (num2 != 0)
					{
						return num2;
					}
				}
			}
			else
			{
				for (int j = 0; j < num; j++)
				{
					if (!IsValidCodePoint(strA[j]))
					{
						Assert.AlwaysFail($"Failed to convert character {strA[j]}");
						continue;
					}
					if (!IsValidCodePoint(strB[j]))
					{
						Assert.AlwaysFail($"Failed to convert character {strB[j]}");
						continue;
					}
					int num3 = (int)(strA[j] - strB[j]);
					if (num3 == 0)
					{
						continue;
					}
					uint num4 = ToLowerInvariant(strA[j]);
					if (num4 != strB[j])
					{
						uint num5 = ToLowerInvariant(strB[j]);
						if (num4 != num5)
						{
							return num3;
						}
					}
				}
			}
			return aLength - bLength;
		}

		internal unsafe static int CompareOrdinal(string strA, uint* strB, int bLength, bool ignoreCase = false)
		{
			if (strA == null)
			{
				throw new ArgumentNullException("strA");
			}
			int length = strA.Length;
			fixed (char* ptr = strA)
			{
				int num = 0;
				int num2 = 0;
				while (num < bLength && num2 < length)
				{
					char c = ptr[num2];
					if ((uint)(c - 55296) >= 2048u)
					{
						int num3 = (int)(c - strB[num]);
						if (num3 != 0)
						{
							if (!ignoreCase)
							{
								return num3;
							}
							(char, char) tuple = ToUTF16(strB[num]);
							var (c2, _) = tuple;
							if (tuple.Item2 != 0)
							{
								return num3;
							}
							num3 = char.ToLowerInvariant(c) - char.ToLowerInvariant(c2);
							if (num3 != 0)
							{
								return num3;
							}
						}
					}
					else
					{
						if (!char.IsHighSurrogate(c) || num2 >= length - 1 || !char.IsLowSurrogate(ptr[num2 + 1]))
						{
							Assert.AlwaysFail($"Failed to convert character {c}");
							break;
						}
						char charOrHighSurrogate = c;
						char lowSurrogate = ptr[++num2];
						uint num4 = ToUTF32(charOrHighSurrogate, lowSurrogate);
						int result = (int)(num4 - strB[num]);
						if (num4 != strB[num])
						{
							if (!ignoreCase)
							{
								return result;
							}
							uint num5 = ToLowerInvariant(num4);
							if (num5 != strB[num])
							{
								uint num6 = ToLowerInvariant(strB[num]);
								if (num5 != num6)
								{
									return result;
								}
							}
						}
					}
					num++;
					num2++;
				}
				return length - num2 - (bLength - num);
			}
		}

		internal unsafe static bool EndsWithOrdinal(uint* strA, int aLength, uint* bStr, int bLength, bool ignoreCase = false)
		{
			if (bLength > aLength)
			{
				return false;
			}
			return CompareOrdinal(strA + (aLength - bLength), bLength, bStr, bLength, ignoreCase) == 0;
		}

		internal unsafe static bool EndsWithOrdinal(uint* strA, int aLength, string strB, bool ignoreCase = false)
		{
			if (strB == null)
			{
				throw new ArgumentNullException("strB");
			}
			int byteCount = Encoding.UTF32.GetByteCount(strB);
			Assert.Check(byteCount % 4 == 0);
			int num = byteCount / 4;
			if (aLength < num)
			{
				return false;
			}
			return CompareOrdinal(strB, strA + (aLength - num), num, ignoreCase) == 0;
		}

		internal unsafe static int GetHashDeterministic(uint* str, int length)
		{
			int a = 352654597;
			int b = a;
			for (int i = 0; i < length; i++)
			{
				(char, char) tuple = ToUTF16(str[i]);
				char item = tuple.Item1;
				char item2 = tuple.Item2;
				a = ((a << 5) + a) ^ item;
				Swap(ref a, ref b);
				if (item2 != 0)
				{
					a = ((a << 5) + a) ^ item2;
					Swap(ref a, ref b);
				}
			}
			return a + b * 1566083941;
		}

		internal unsafe static bool StartsWithOrdinal(uint* strA, int aLength, uint* strB, int bLength, bool ignoreCase = false)
		{
			if (bLength > aLength)
			{
				return false;
			}
			return CompareOrdinal(strA, bLength, strB, bLength, ignoreCase) == 0;
		}

		internal unsafe static bool StartsWithOrdinal(uint* strA, int aLength, string strB, bool ignoreCase = false)
		{
			if (strB == null)
			{
				throw new ArgumentNullException("strB");
			}
			int byteCount = Encoding.UTF32.GetByteCount(strB);
			Assert.Check(byteCount % 4 == 0);
			int num = byteCount / 4;
			if (aLength < num)
			{
				return false;
			}
			return CompareOrdinal(strB, strA, num, ignoreCase) == 0;
		}

		internal unsafe static int IndexOf(uint* str, int length, string pattern)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			if (pattern == null)
			{
				throw new ArgumentNullException("pattern");
			}
			if (length == 0)
			{
				return -1;
			}
			int length2 = GetLength(pattern);
			if (length2 > length)
			{
				return -1;
			}
			fixed (char* ptr = pattern)
			{
				char* end = ptr + pattern.Length;
				for (int i = 0; i + length2 <= length; i++)
				{
					char* pstr = ptr;
					int j;
					for (j = 0; j < length2; j++)
					{
						uint num = ReadNextCodePoint(ref pstr, end);
						if (str[i + j] != num)
						{
							break;
						}
					}
					if (j == length2)
					{
						return i;
					}
				}
			}
			return -1;
		}

		internal unsafe static int IndexOf(uint* str, int length, uint* pattern, int patternLength)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			if (patternLength < 0)
			{
				throw new ArgumentOutOfRangeException("patternLength");
			}
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			if (pattern == null)
			{
				throw new ArgumentNullException("pattern");
			}
			if (length == 0 || patternLength > length)
			{
				return -1;
			}
			for (int i = 0; i + patternLength <= length; i++)
			{
				int j;
				for (j = 0; j < patternLength && str[i + j] == pattern[j]; j++)
				{
				}
				if (j == patternLength)
				{
					return i;
				}
			}
			return -1;
		}

		internal unsafe static void ToLowerInvariant(uint* src, uint* dst, int length)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			if (length < 0)
			{
				throw new ArgumentNullException("length");
			}
			for (int i = 0; i < length; i++)
			{
				dst[i] = ToLowerInvariant(src[i]);
			}
		}

		internal unsafe static void ToUpperInvariant(uint* src, uint* dst, int length)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (dst == null)
			{
				throw new ArgumentNullException("dst");
			}
			if (length < 0)
			{
				throw new ArgumentNullException("length");
			}
			for (int i = 0; i < length; i++)
			{
				dst[i] = ToUpperInvariant(src[i]);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static char GetHighSurrogate(uint scalar)
		{
			return (char)((scalar - 65536) / 1024 + 55296);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetLength(string str)
		{
			int byteCount = Encoding.UTF32.GetByteCount(str);
			Assert.Check(byteCount % 4 == 0);
			return byteCount / 4;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static char GetLowSurrogate(uint scalar)
		{
			return (char)((scalar - 65536) % 1024 + 56320);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsValidCodePoint(uint scalar)
		{
			return ((scalar - 1114112) ^ 0xD800) >= 4293855232u;
		}

		private unsafe static uint ReadNextCodePoint(ref char* pstr, char* end)
		{
			char c = *(pstr++);
			if (char.IsHighSurrogate(c))
			{
				Assert.Always(pstr < end, "Surrogate found at the end of the string");
				char c2 = *(pstr++);
				Assert.Check(char.IsLowSurrogate(c2));
				return (uint)((c - 55296) * 1024 + (c2 - 56320) + 65536);
			}
			Assert.Check(!char.IsLowSurrogate(c));
			return c;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Swap(ref int a, ref int b)
		{
			int num = a;
			a = b;
			b = num;
		}

		private unsafe static uint ToLowerInvariant(uint value)
		{
			var (c, c2) = ToUTF16(value);
			if (c2 == '\0')
			{
				return char.ToLowerInvariant(c);
			}
			char* ptr = stackalloc char[2];
			*ptr = c;
			ptr[1] = c2;
			string text = new string(ptr, 0, 2);
			string text2 = text.ToLowerInvariant();
			Assert.Check(text2.Length == 2);
			return ToUTF32(text2[0], text2[1]);
		}

		private unsafe static uint ToUpperInvariant(uint value)
		{
			var (c, c2) = ToUTF16(value);
			if (c2 == '\0')
			{
				return char.ToUpperInvariant(c);
			}
			char* ptr = stackalloc char[2];
			*ptr = c;
			ptr[1] = c2;
			string text = new string(ptr, 0, 2);
			string text2 = text.ToUpperInvariant();
			Assert.Check(text2.Length == 2);
			return ToUTF32(text2[0], text2[1]);
		}

		private static (char, char) ToUTF16(uint scalar)
		{
			if (scalar >= 65536)
			{
				return (GetHighSurrogate(scalar), GetLowSurrogate(scalar));
			}
			return ((char)scalar, '\0');
		}

		private static uint ToUTF32(char charOrHighSurrogate, char lowSurrogate = '\0')
		{
			if (char.IsHighSurrogate(charOrHighSurrogate))
			{
				Assert.Check(char.IsLowSurrogate(lowSurrogate));
				return (uint)((charOrHighSurrogate - 55296) * 1024 + (lowSurrogate - 56320) + 65536);
			}
			Assert.Check(lowSurrogate == '\0');
			return charOrHighSurrogate;
		}
	}
	public static class Versioning
	{
		public static readonly Version InvalidVersion = new Version(0, 0, 0);

		public static Version GetCurrentVersion
		{
			get
			{
				Version version = typeof(Versioning).Assembly.GetName().Version;
				return new Version(version.Major, version.Minor, version.Build);
			}
		}

		public static Version ShortVersion(this Version version)
		{
			return new Version(version.Major, version.Minor);
		}

		public static string AssemblyFileVersion()
		{
			FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(typeof(Versioning).Assembly.Location);
			return versionInfo.ProductVersion;
		}
	}
}
namespace Fusion.Runtime.Unity
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = true)]
	[Conditional("FUSION_UNITY")]
	internal class UnityDummyAttribute : Attribute
	{
		public UnityDummyAttribute()
		{
		}

		public UnityDummyAttribute(string str)
		{
		}
	}
}
namespace Fusion.Analyzer
{
	[AttributeUsage(AttributeTargets.Field)]
	[Conditional("false")]
	public class StaticFieldAttribute : Attribute
	{
		public StaticFieldResetMode Reset { get; }

		public StaticFieldAttribute(StaticFieldResetMode resetMode)
		{
			Reset = resetMode;
		}

		public StaticFieldAttribute()
			: this(StaticFieldResetMode.ResetMethod)
		{
		}
	}
	[AttributeUsage(AttributeTargets.Method)]
	[Conditional("false")]
	public class StaticFieldResetMethodAttribute : Attribute
	{
		public StaticFieldResetMethodAttribute(bool calledAutomatically)
		{
		}

		public StaticFieldResetMethodAttribute()
		{
		}
	}
	[AttributeUsage(AttributeTargets.Constructor)]
	[Conditional("false")]
	public class StaticConstructorAttribute : Attribute
	{
	}
	public enum StaticFieldResetMode
	{
		None,
		Manual,
		ResetMethod
	}
}
namespace Fusion.Protocol
{
	public interface ICommunicator
	{
		int CommunicatorID { get; }

		unsafe bool SendPackage(byte code, int targetActor, bool reliable, byte* buffer, int bufferLength);

		unsafe int ReceivePackage(out int senderActor, byte* buffer, int bufferLength);

		bool Poll();

		void PushPackage(int senderActor, int eventCode, object data);

		void RegisterPackageCallback<T>(Action<int, T> callback) where T : IMessage;

		void SendMessage(int targetActor, IMessage message);

		void Service();
	}
	public interface IMessage
	{
	}
}
namespace Fusion.Async
{
	internal class AsyncOperationHandler<T>
	{
		private const float OperationTimeoutSec = 30f;

		private readonly TaskCompletionSource<T> _result;

		private readonly CancellationTokenSource _cancellation;

		private readonly string _customTimeoutMsg;

		public Task<T> Task => _result.Task;

		public AsyncOperationHandler(CancellationToken externalCancellationToken = default(CancellationToken), float operationTimeout = 30f, string customTimeoutMsg = null)
		{
			_result = new TaskCompletionSource<T>();
			_customTimeoutMsg = customTimeoutMsg;
			_cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(operationTimeout));
			_cancellation.Token.Register(Expire);
			if (externalCancellationToken != default(CancellationToken))
			{
				externalCancellationToken.Register(Cancel);
			}
		}

		public void SetResult(T result)
		{
			if (_result.TrySetResult(result))
			{
				if (!_cancellation.IsCancellationRequested)
				{
					_cancellation.Cancel();
				}
				_cancellation.Dispose();
			}
		}

		public void SetException(Exception e)
		{
			if (_result.TrySetException(e))
			{
				if (!_cancellation.IsCancellationRequested)
				{
					_cancellation.Cancel();
				}
				_cancellation.Dispose();
			}
		}

		private void Expire()
		{
			SetException(new TimeoutException("Operation timed out. " + _customTimeoutMsg));
		}

		private void Cancel()
		{
			SetException(new OperationCanceledException("Operation cancelled."));
		}
	}
	public static class TaskManager
	{
		private static TaskFactory TaskFactory { get; set; } = Task.Factory;

		[Conditional("FUSION_UNITY")]
		public static void Setup()
		{
			if (TaskFactory == null || TaskFactory.Equals(Task.Factory))
			{
				TaskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskContinuationOptions.DenyChildAttach | TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.FromCurrentSynchronizationContext());
			}
		}

		public static Task Service(Action recurringAction, CancellationToken cancellationToken, int interval, string serviceName = null)
		{
			if (recurringAction == null)
			{
				return Task.CompletedTask;
			}
			Task<bool> result = Task.FromResult(result: true);
			return Service(delegate
			{
				recurringAction();
				return result;
			}, cancellationToken, interval, serviceName);
		}

		public static Task Service(Func<Task<bool>> recurringAction, CancellationToken cancellationToken, int interval, string serviceName = null)
		{
			Assert.Check(recurringAction != null, "Service Action should not be null");
			Assert.Check(interval > 0, "Service delay must be greated than 0");
			Assert.Check(cancellationToken != default(CancellationToken), "Service CancellationToken can't be the default");
			return TaskFactory.StartNew((Func<Task>)async delegate
			{
				InternalLogStreams.LogDebug?.Log("Starting service: " + (serviceName ?? recurringAction.Method.Name));
				while (!cancellationToken.IsCancellationRequested)
				{
					try
					{
						cancellationToken.ThrowIfCancellationRequested();
						await Delay(interval, cancellationToken);
						if (!(await recurringAction()))
						{
							break;
						}
					}
					catch (OperationCanceledException)
					{
						InternalLogStreams.LogDebug?.Log("Service canceled: " + (serviceName ?? recurringAction.Method.Name));
						throw;
					}
					catch (Exception error)
					{
						InternalLogStreams.LogException?.Log(error);
						break;
					}
				}
				InternalLogStreams.LogDebug?.Log("Stopping service: " + (serviceName ?? recurringAction.Method.Name));
			}, cancellationToken, TaskFactory.CreationOptions | TaskCreationOptions.LongRunning, TaskFactory.Scheduler);
		}

		public static Task Run(Func<CancellationToken, Task> action, CancellationToken cancellationToken, TaskCreationOptions options = TaskCreationOptions.None)
		{
			Assert.Check(action != null);
			Assert.Check(cancellationToken != default(CancellationToken));
			return TaskFactory.StartNew((Func<Task>)async delegate
			{
				try
				{
					cancellationToken.ThrowIfCancellationRequested();
					await action(cancellationToken);
				}
				catch (OperationCanceledException)
				{
					throw;
				}
				catch (Exception ex2)
				{
					Exception e = ex2;
					InternalLogStreams.LogException?.Log(e);
				}
			}, cancellationToken, TaskFactory.CreationOptions | options, TaskFactory.Scheduler);
		}

		public static Task ContinueWhenAll(Task[] precedingTasks, Func<CancellationToken, Task> action, CancellationToken cancellationToken)
		{
			Assert.Check(action != null);
			Assert.Check(cancellationToken != default(CancellationToken));
			Assert.Check(precedingTasks != null);
			Assert.Check(precedingTasks.Length != 0);
			return TaskFactory.ContinueWhenAll(precedingTasks, (Func<Task[], Task>)async delegate
			{
				try
				{
					cancellationToken.ThrowIfCancellationRequested();
					await action(cancellationToken);
				}
				catch (OperationCanceledException)
				{
					throw;
				}
				catch (Exception ex2)
				{
					Exception e = ex2;
					InternalLogStreams.LogException?.Log(e);
				}
			}, cancellationToken, TaskFactory.ContinuationOptions, TaskFactory.Scheduler);
		}

		public static async Task Delay(int delay, CancellationToken token = default(CancellationToken))
		{
			if (RuntimeUnityFlagsSetup.IsUNITY_WEBGL)
			{
				float endTime = (float)Stopwatch.GetTimestamp() + (float)Stopwatch.Frequency * ((float)delay / 1000f);
				while (!token.IsCancellationRequested && (float)Stopwatch.GetTimestamp() - endTime < 0f)
				{
					await Task.Yield();
				}
			}
			else
			{
				await Task.Delay(delay, token);
			}
		}
	}
}
internal class FusionCommon_ProcessedByFody
{
	internal const string FodyVersion = "6.9.1.0";

	internal const string InlineIL = "1.10.0.0";
}
