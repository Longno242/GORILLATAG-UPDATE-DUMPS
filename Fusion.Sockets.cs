#define ENABLE_PROFILER
#define TRACE
#define DEBUG
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fusion.Async;
using Fusion.Encryption;
using Fusion.Protocol;
using Fusion.Sockets;
using Fusion.Sockets.Stun;
using Microsoft.CodeAnalysis;
using NanoSockets;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = ".NET Standard 2.1")]
[assembly: AssemblyCompany("Exit Games GmbH")]
[assembly: AssemblyConfiguration("Unity Debug")]
[assembly: AssemblyCopyright("? Exit Games GmbH")]
[assembly: AssemblyFileVersion("2.0.6.1034")]
[assembly: AssemblyInformationalVersion("2.0.6.1034+94e2793d")]
[assembly: AssemblyProduct("Fusion.Sockets")]
[assembly: AssemblyTitle("Fusion.Sockets (Unity Debug)")]
[assembly: InternalsVisibleTo("Fusion.Sockets.Tests")]
[assembly: InternalsVisibleTo("Fusion.Runtime")]
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
	[Serializable]
	public class EncryptionConfig
	{
		public bool EnableEncryption;
	}
}
namespace Fusion.Protocol
{
	public class BitStream
	{
		public delegate void ArrayElementSerializer<T>(ref T element);

		private int _ptr;

		private int _size;

		private byte[] _data;

		private bool _write;

		public int Size
		{
			get
			{
				return _size;
			}
			set
			{
				_size = Maths.Clamp(value, 0, _data.Length << 3);
			}
		}

		public int Position
		{
			get
			{
				return _ptr;
			}
			set
			{
				_ptr = Maths.Clamp(value, 0, _size);
			}
		}

		public int BytesRequired => Maths.BytesRequiredForBits(Position);

		public bool IsEvenBytes => _ptr % 8 == 0;

		public int Capacity => _data.Length;

		public bool Done => _ptr == _size;

		public bool Overflowing => _ptr > _size;

		public bool Writing
		{
			get
			{
				return _write;
			}
			set
			{
				_write = value;
			}
		}

		public bool Reading
		{
			get
			{
				return !_write;
			}
			set
			{
				_write = !value;
			}
		}

		public byte[] Data => _data;

		public BitStream()
			: this(new byte[0])
		{
		}

		public BitStream(int size)
			: this(new byte[size])
		{
		}

		public BitStream(byte[] arr)
			: this(arr, arr.Length)
		{
		}

		public BitStream(byte[] arr, int size)
		{
			_ptr = 0;
			_data = arr;
			_size = size << 3;
		}

		public void SetBuffer(byte[] arr)
		{
			SetBuffer(arr, arr.Length);
		}

		public void SetBuffer(byte[] arr, int size)
		{
			_ptr = 0;
			_data = arr;
			_size = size << 3;
		}

		public int RoundToByte()
		{
			int num = _ptr % 8;
			if (num > 0)
			{
				int num2 = 8 - num;
				if (_write)
				{
					WriteByte(0, num2);
				}
				else
				{
					_ptr += num2;
				}
			}
			Assert.Check(_ptr % 8 == 0);
			return _ptr / 8;
		}

		public void Expand()
		{
			byte[] array = new byte[_data.Length * 2];
			Buffer.BlockCopy(_data, 0, array, 0, _data.Length);
			_data = array;
			_size = array.Length << 3;
		}

		public bool CanWrite()
		{
			return CanWrite(1);
		}

		public bool CanRead()
		{
			return CanRead(1);
		}

		public bool CanWrite(int bits)
		{
			return _ptr + bits <= _size;
		}

		public bool CanRead(int bits)
		{
			return _ptr + bits <= _size;
		}

		public void CopyFromArray(byte[] array)
		{
			Assert.Check(array.Length <= _data.Length);
			Array.Copy(array, 0, _data, 0, array.Length);
			_ptr = 0;
			_size = array.Length << 3;
		}

		public void Reset()
		{
			Reset(_data.Length);
		}

		public void Reset(int byteSize)
		{
			Assert.Check(byteSize <= _data.Length);
			Array.Clear(_data, 0, _data.Length);
			_ptr = 0;
			_size = byteSize << 3;
		}

		public void ResetFast(int byteSize)
		{
			Assert.Check(byteSize <= _data.Length);
			_ptr = 0;
			_size = byteSize << 3;
		}

		public byte[] ToArray()
		{
			byte[] array = new byte[Maths.BytesRequiredForBits(_ptr)];
			Buffer.BlockCopy(_data, 0, array, 0, array.Length);
			return array;
		}

		public bool WriteBool(bool value)
		{
			InternalWriteByte((byte)(value ? 1 : 0), 1);
			return value;
		}

		public bool WriteBoolean(bool value)
		{
			InternalWriteByte((byte)(value ? 1 : 0), 1);
			return value;
		}

		public bool ReadBool()
		{
			return InternalReadByte(1) == 1;
		}

		public bool ReadBoolean()
		{
			return InternalReadByte(1) == 1;
		}

		public void WriteByte(byte value, int bits)
		{
			InternalWriteByte(value, bits);
		}

		public byte ReadByte(int bits)
		{
			return InternalReadByte(bits);
		}

		public void WriteByte(byte value)
		{
			WriteByte(value, 8);
		}

		public byte ReadByte()
		{
			return ReadByte(8);
		}

		public sbyte ReadSByte()
		{
			return (sbyte)ReadByte();
		}

		public void WriteSByte(sbyte value)
		{
			WriteByte((byte)value);
		}

		public void WriteUShort(ushort value, int bits)
		{
			if (bits <= 8)
			{
				InternalWriteByte((byte)(value & 0xFF), bits);
				return;
			}
			InternalWriteByte((byte)(value & 0xFF), 8);
			InternalWriteByte((byte)(value >> 8), bits - 8);
		}

		public ushort ReadUShort(int bits)
		{
			if (bits <= 8)
			{
				return InternalReadByte(bits);
			}
			return (ushort)(InternalReadByte(8) | (InternalReadByte(bits - 8) << 8));
		}

		public void WriteUShort(ushort value)
		{
			WriteUShort(value, 16);
		}

		public ushort ReadUShort()
		{
			return ReadUShort(16);
		}

		public void WriteShort(short value, int bits)
		{
			WriteUShort((ushort)value, bits);
		}

		public short ReadShort(int bits)
		{
			return (short)ReadUShort(bits);
		}

		public void WriteShort(short value)
		{
			WriteShort(value, 16);
		}

		public short ReadShort()
		{
			return ReadShort(16);
		}

		public void WriteChar(char value)
		{
			WriteUShort(value, 16);
		}

		public char ReadChar()
		{
			return (char)ReadUShort(16);
		}

		public void WriteUInt(uint value, int bits)
		{
			byte value2 = (byte)value;
			byte value3 = (byte)(value >> 8);
			byte value4 = (byte)(value >> 16);
			byte value5 = (byte)(value >> 24);
			switch ((bits + 7) / 8)
			{
			case 1:
				InternalWriteByte(value2, bits);
				break;
			case 2:
				InternalWriteByte(value2, 8);
				InternalWriteByte(value3, bits - 8);
				break;
			case 3:
				InternalWriteByte(value2, 8);
				InternalWriteByte(value3, 8);
				InternalWriteByte(value4, bits - 16);
				break;
			case 4:
				InternalWriteByte(value2, 8);
				InternalWriteByte(value3, 8);
				InternalWriteByte(value4, 8);
				InternalWriteByte(value5, bits - 24);
				break;
			}
		}

		public uint ReadUInt(int bits)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			switch ((bits + 7) / 8)
			{
			case 1:
				num = InternalReadByte(bits);
				break;
			case 2:
				num = InternalReadByte(8);
				num2 = InternalReadByte(bits - 8);
				break;
			case 3:
				num = InternalReadByte(8);
				num2 = InternalReadByte(8);
				num3 = InternalReadByte(bits - 16);
				break;
			case 4:
				num = InternalReadByte(8);
				num2 = InternalReadByte(8);
				num3 = InternalReadByte(8);
				num4 = InternalReadByte(bits - 24);
				break;
			}
			return (uint)(num | (num2 << 8) | (num3 << 16) | (num4 << 24));
		}

		public void WriteUInt(uint value)
		{
			WriteUInt(value, 32);
		}

		public uint ReadUInt()
		{
			return ReadUInt(32);
		}

		public void WriteInt_Shifted(int value, int bits, int shift)
		{
			WriteInt(value, 32);
		}

		public int ReadInt_Shifted(int bits, int shift)
		{
			return ReadInt(32);
		}

		public void WriteInt(int value, int bits)
		{
			WriteUInt((uint)value, bits);
		}

		public int ReadInt(int bits)
		{
			return (int)ReadUInt(bits);
		}

		public void WriteInt(int value)
		{
			WriteInt(value, 32);
		}

		public int ReadInt()
		{
			return ReadInt(32);
		}

		public void WriteULong(ulong value, int bits)
		{
			if (bits <= 32)
			{
				WriteUInt((uint)(value & 0xFFFFFFFFu), bits);
				return;
			}
			WriteUInt((uint)value, 32);
			WriteUInt((uint)(value >> 32), bits - 32);
		}

		public ulong ReadULong(int bits)
		{
			if (bits <= 32)
			{
				return ReadUInt(bits);
			}
			ulong num = ReadUInt(32);
			ulong num2 = ReadUInt(bits - 32);
			return num | (num2 << 32);
		}

		public void WriteULong(ulong value)
		{
			WriteULong(value, 64);
		}

		public ulong ReadULong()
		{
			return ReadULong(64);
		}

		public void WriteLong(long value, int bits)
		{
			WriteULong((ulong)value, bits);
		}

		public long ReadLong(int bits)
		{
			return (long)ReadULong(bits);
		}

		public void WriteLong(long value)
		{
			WriteLong(value, 64);
		}

		public long ReadLong()
		{
			return ReadLong(64);
		}

		public void WriteFloat(float value)
		{
			UdpByteConverter udpByteConverter = value;
			InternalWriteByte(udpByteConverter.Byte0, 8);
			InternalWriteByte(udpByteConverter.Byte1, 8);
			InternalWriteByte(udpByteConverter.Byte2, 8);
			InternalWriteByte(udpByteConverter.Byte3, 8);
		}

		public float ReadFloat()
		{
			UdpByteConverter udpByteConverter = new UdpByteConverter
			{
				Byte0 = InternalReadByte(8),
				Byte1 = InternalReadByte(8),
				Byte2 = InternalReadByte(8),
				Byte3 = InternalReadByte(8)
			};
			return udpByteConverter.Float32;
		}

		public void WriteDouble(double value)
		{
			UdpByteConverter udpByteConverter = value;
			InternalWriteByte(udpByteConverter.Byte0, 8);
			InternalWriteByte(udpByteConverter.Byte1, 8);
			InternalWriteByte(udpByteConverter.Byte2, 8);
			InternalWriteByte(udpByteConverter.Byte3, 8);
			InternalWriteByte(udpByteConverter.Byte4, 8);
			InternalWriteByte(udpByteConverter.Byte5, 8);
			InternalWriteByte(udpByteConverter.Byte6, 8);
			InternalWriteByte(udpByteConverter.Byte7, 8);
		}

		public double ReadDouble()
		{
			UdpByteConverter udpByteConverter = new UdpByteConverter
			{
				Byte0 = InternalReadByte(8),
				Byte1 = InternalReadByte(8),
				Byte2 = InternalReadByte(8),
				Byte3 = InternalReadByte(8),
				Byte4 = InternalReadByte(8),
				Byte5 = InternalReadByte(8),
				Byte6 = InternalReadByte(8),
				Byte7 = InternalReadByte(8)
			};
			return udpByteConverter.Float64;
		}

		public void WriteByteArray(byte[] from)
		{
			WriteByteArray(from, 0, from.Length);
		}

		public void WriteByteArray(byte[] from, int count)
		{
			WriteByteArray(from, 0, count);
		}

		public void WriteByteArray(byte[] from, int offset, int count)
		{
			int num = _ptr >> 3;
			int num2 = _ptr % 8;
			int num3 = 8 - num2;
			if (num2 == 0)
			{
				Buffer.BlockCopy(from, offset, _data, num, count);
			}
			else
			{
				for (int i = 0; i < count; i++)
				{
					byte b = from[offset + i];
					_data[num] &= (byte)(255 >> num3);
					_data[num] |= (byte)(b << num2);
					num++;
					_data[num] &= (byte)(255 << num2);
					_data[num] |= (byte)(b >> num3);
				}
			}
			_ptr += count * 8;
		}

		public byte[] ReadByteArray(int size)
		{
			byte[] array = new byte[size];
			ReadByteArray(array);
			return array;
		}

		public void ReadByteArray(byte[] to)
		{
			ReadByteArray(to, 0, to.Length);
		}

		public void ReadByteArray(byte[] to, int count)
		{
			ReadByteArray(to, 0, count);
		}

		public void ReadByteArray(byte[] to, int offset, int count)
		{
			int num = _ptr >> 3;
			int num2 = _ptr % 8;
			if (num2 == 0)
			{
				Buffer.BlockCopy(_data, num, to, offset, count);
			}
			else
			{
				int num3 = 8 - num2;
				for (int i = 0; i < count; i++)
				{
					int num4 = _data[num] >> num2;
					num++;
					int num5 = _data[num] & (255 >> num3);
					to[offset + i] = (byte)(num4 | (num5 << num3));
				}
			}
			_ptr += count * 8;
		}

		public void WriteByteArrayLengthPrefixed(byte[] array)
		{
			WriteByteArrayLengthPrefixed(array, (array != null) ? array.Length : 0);
		}

		public void WriteByteArrayLengthPrefixed(byte[] array, int maxLength)
		{
			if (WriteBool(array != null))
			{
				int num = Math.Min(array.Length, maxLength);
				if (num < array.Length)
				{
					InternalLogStreams.LogWarn?.Log($"Only sendig {num}/{array.Length} bytes from byte array");
				}
				WriteUShort((ushort)num);
				WriteByteArray(array, 0, num);
			}
		}

		public byte[] ReadByteArrayLengthPrefixed()
		{
			if (ReadBool())
			{
				byte[] array = new byte[ReadUShort()];
				ReadByteArray(array, 0, array.Length);
				return array;
			}
			return null;
		}

		public void WriteString(string value, Encoding encoding)
		{
			if (!WriteBool(value == null))
			{
				byte[] bytes = encoding.GetBytes(value);
				WriteUShort((ushort)bytes.Length);
				WriteByteArray(bytes);
			}
		}

		public void WriteString(string value)
		{
			WriteString(value, Encoding.UTF8);
		}

		public string ReadString(Encoding encoding)
		{
			if (ReadBool())
			{
				return null;
			}
			int num = ReadUShort();
			if (num == 0)
			{
				return "";
			}
			byte[] array = new byte[num];
			ReadByteArray(array);
			return encoding.GetString(array, 0, array.Length);
		}

		public string ReadString()
		{
			return ReadString(Encoding.UTF8);
		}

		public void WriteGuid(Guid guid)
		{
			WriteByteArray(guid.ToByteArray());
		}

		public Guid ReadGuid()
		{
			byte[] array = new byte[16];
			ReadByteArray(array);
			return new Guid(array);
		}

		private void InternalWriteByte(byte value, int bits)
		{
			WriteByteAt(_data, _ptr, bits, value);
			_ptr += bits;
		}

		public static void WriteByteAt(byte[] data, int ptr, int bits, byte value)
		{
			if (bits > 0)
			{
				value = (byte)(value & (255 >> 8 - bits));
				int num = ptr >> 3;
				int num2 = ptr & 7;
				int num3 = 8 - num2;
				int num4 = num3 - bits;
				if (num4 >= 0)
				{
					int num5 = (255 >> num3) | (255 << 8 - num4);
					data[num] = (byte)((data[num] & num5) | (value << num2));
				}
				else
				{
					data[num] = (byte)((data[num] & (255 >> num3)) | (value << num2));
					data[num + 1] = (byte)((data[num + 1] & (255 << bits - num3)) | (value >> num3));
				}
			}
		}

		private byte InternalReadByte(int bits)
		{
			if (bits <= 0)
			{
				return 0;
			}
			int num = _ptr >> 3;
			int num2 = _ptr % 8;
			byte result;
			if (num2 == 0 && bits == 8)
			{
				result = _data[num];
			}
			else
			{
				int num3 = _data[num] >> num2;
				int num4 = bits - (8 - num2);
				if (num4 < 1)
				{
					result = (byte)(num3 & (255 >> 8 - bits));
				}
				else
				{
					int num5 = _data[num + 1] & (255 >> 8 - num4);
					result = (byte)(num3 | (num5 << bits - num4));
				}
			}
			_ptr += bits;
			return result;
		}

		public bool Condition(bool condition)
		{
			if (_write)
			{
				WriteBool(condition);
			}
			else
			{
				condition = ReadBool();
			}
			return condition;
		}

		public void Serialize(ref string value)
		{
			if (_write)
			{
				WriteString(value, Encoding.UTF8);
			}
			else
			{
				value = ReadString(Encoding.UTF8);
			}
		}

		public void Serialize(ref bool value)
		{
			if (_write)
			{
				WriteBool(value);
			}
			else
			{
				value = ReadBool();
			}
		}

		public void Serialize(ref float value)
		{
			if (_write)
			{
				WriteFloat(value);
			}
			else
			{
				value = ReadFloat();
			}
		}

		public void Serialize(ref double value)
		{
			if (_write)
			{
				WriteDouble(value);
			}
			else
			{
				value = ReadDouble();
			}
		}

		public void Serialize(ref long value)
		{
			if (_write)
			{
				WriteLong(value);
			}
			else
			{
				value = ReadLong();
			}
		}

		public void Serialize(ref ulong value)
		{
			if (_write)
			{
				WriteULong(value);
			}
			else
			{
				value = ReadULong();
			}
		}

		public void Serialize(ref byte value)
		{
			if (_write)
			{
				WriteByte(value);
			}
			else
			{
				value = ReadByte();
			}
		}

		public void Serialize(ref uint value)
		{
			Serialize(ref value, 32);
		}

		public void Serialize(ref uint value, int bits)
		{
			if (_write)
			{
				WriteUInt(value, bits);
			}
			else
			{
				value = ReadUInt(bits);
			}
		}

		public void Serialize(ref ulong value, int bits)
		{
			if (_write)
			{
				WriteULong(value, bits);
			}
			else
			{
				value = ReadULong(bits);
			}
		}

		public void Serialize(ref int value)
		{
			Serialize(ref value, 32);
		}

		public void Serialize(ref int value, int bits)
		{
			if (_write)
			{
				WriteInt(value, bits);
			}
			else
			{
				value = ReadInt(bits);
			}
		}

		public void Serialize(ref int[] value)
		{
			if (_write)
			{
				if (WriteBool(value != null))
				{
					WriteUShort((ushort)value.Length);
					for (int i = 0; i < value.Length; i++)
					{
						WriteInt(value[i]);
					}
				}
			}
			else if (ReadBool())
			{
				value = new int[ReadUShort()];
				for (int j = 0; j < value.Length; j++)
				{
					value[j] = ReadInt();
				}
			}
			else
			{
				value = null;
			}
		}

		public void Serialize(ref byte[] value)
		{
			if (_write)
			{
				WriteByteArrayLengthPrefixed(value, value?.Length ?? 0);
			}
			else
			{
				value = ReadByteArrayLengthPrefixed();
			}
		}

		public void Serialize(ref byte[] array, ref int length)
		{
			if (_write)
			{
				if (WriteBool(array != null))
				{
					WriteUShort((ushort)length);
					WriteByteArray(array, 0, length);
				}
			}
			else if (ReadBool())
			{
				length = ReadUShort();
				if (array == null || array.Length < length)
				{
					array = new byte[length];
				}
				ReadByteArray(array, 0, length);
			}
		}

		public void Serialize(ref byte[] value, int fixedSize)
		{
			if (_write)
			{
				if (WriteBoolean(value != null && value.Length != 0))
				{
					Assert.Check(value.Length == fixedSize);
					WriteByteArray(value, fixedSize);
				}
			}
			else if (ReadBoolean())
			{
				value = ReadByteArray(fixedSize);
			}
			else
			{
				value = null;
			}
		}

		public void Serialize(ref byte[] array, ref int length, int fixedSize)
		{
			length = fixedSize;
			if (_write)
			{
				if (WriteBoolean(array != null && array.Length != 0))
				{
					Assert.Check(length == fixedSize);
					Assert.Check(array.Length <= fixedSize);
					WriteByteArray(array, fixedSize);
				}
			}
			else if (ReadBoolean())
			{
				if (array == null || array.Length < fixedSize)
				{
					array = new byte[fixedSize];
				}
				ReadByteArray(array, fixedSize);
			}
			else
			{
				array = null;
			}
		}

		public void SerializeArrayLength<T>(ref T[] array)
		{
			if (_write)
			{
				WriteInt((array != null) ? array.Length : 0);
			}
			else
			{
				array = new T[ReadInt()];
			}
		}

		public void SerializeArray<T>(ref T[] array, ArrayElementSerializer<T> serializer)
		{
			if (_write)
			{
				WriteInt((array != null) ? array.Length : 0);
			}
			else
			{
				array = new T[ReadInt()];
			}
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					serializer(ref array[i]);
				}
			}
		}

		public unsafe void Serialize(byte* v)
		{
			if (_write)
			{
				WriteByte(*v);
			}
			else
			{
				*v = ReadByte();
			}
		}

		public unsafe void Serialize(sbyte* v)
		{
			if (_write)
			{
				WriteSByte(*v);
			}
			else
			{
				*v = ReadSByte();
			}
		}

		public unsafe void Serialize(short* v)
		{
			if (_write)
			{
				WriteShort(*v);
			}
			else
			{
				*v = ReadShort();
			}
		}

		public unsafe void Serialize(ushort* v)
		{
			if (_write)
			{
				WriteUShort(*v);
			}
			else
			{
				*v = ReadUShort();
			}
		}

		public unsafe void Serialize(int* v)
		{
			if (_write)
			{
				WriteInt(*v);
			}
			else
			{
				*v = ReadInt();
			}
		}

		public unsafe void Serialize(uint* v)
		{
			if (_write)
			{
				WriteUInt(*v);
			}
			else
			{
				*v = ReadUInt();
			}
		}

		public unsafe void Serialize(long* v)
		{
			if (_write)
			{
				WriteLong(*v);
			}
			else
			{
				*v = ReadLong();
			}
		}

		public unsafe void Serialize(ulong* v)
		{
			if (_write)
			{
				WriteULong(*v);
			}
			else
			{
				*v = ReadULong();
			}
		}

		public unsafe void Serialize(uint* v, int bits)
		{
			if (_write)
			{
				WriteUInt(*v, bits);
			}
			else
			{
				*v = ReadUInt(bits);
			}
		}

		public unsafe void Serialize(int* v, int bits)
		{
			if (_write)
			{
				WriteInt(*v, bits);
			}
			else
			{
				*v = ReadInt(bits);
			}
		}

		public unsafe void SerializeBuffer(byte* buffer, int length)
		{
			if (_write)
			{
				for (int i = 0; i < length; i++)
				{
					WriteByte(buffer[i]);
				}
			}
			else
			{
				for (int j = 0; j < length; j++)
				{
					buffer[j] = ReadByte();
				}
			}
		}

		public unsafe void SerializeBuffer(sbyte* buffer, int length)
		{
			if (_write)
			{
				for (int i = 0; i < length; i++)
				{
					WriteSByte(buffer[i]);
				}
			}
			else
			{
				for (int j = 0; j < length; j++)
				{
					buffer[j] = ReadSByte();
				}
			}
		}

		public unsafe void SerializeBuffer(short* buffer, int length)
		{
			if (_write)
			{
				for (int i = 0; i < length; i++)
				{
					WriteShort(buffer[i]);
				}
			}
			else
			{
				for (int j = 0; j < length; j++)
				{
					buffer[j] = ReadShort();
				}
			}
		}

		public unsafe void SerializeBuffer(ushort* buffer, int length)
		{
			if (_write)
			{
				for (int i = 0; i < length; i++)
				{
					WriteUShort(buffer[i]);
				}
			}
			else
			{
				for (int j = 0; j < length; j++)
				{
					buffer[j] = ReadUShort();
				}
			}
		}

		public unsafe void SerializeBuffer(int* buffer, int length)
		{
			if (_write)
			{
				for (int i = 0; i < length; i++)
				{
					WriteInt(buffer[i]);
				}
			}
			else
			{
				for (int j = 0; j < length; j++)
				{
					buffer[j] = ReadInt();
				}
			}
		}

		public unsafe void SerializeBuffer(uint* buffer, int length)
		{
			if (_write)
			{
				for (int i = 0; i < length; i++)
				{
					WriteUInt(buffer[i]);
				}
			}
			else
			{
				for (int j = 0; j < length; j++)
				{
					buffer[j] = ReadUInt();
				}
			}
		}

		public unsafe void SerializeBuffer(long* buffer, int length)
		{
			if (_write)
			{
				for (int i = 0; i < length; i++)
				{
					WriteLong(buffer[i]);
				}
			}
			else
			{
				for (int j = 0; j < length; j++)
				{
					buffer[j] = ReadLong();
				}
			}
		}

		public unsafe void SerializeBuffer(ulong* buffer, int length)
		{
			if (_write)
			{
				for (int i = 0; i < length; i++)
				{
					WriteULong(buffer[i]);
				}
			}
			else
			{
				for (int j = 0; j < length; j++)
				{
					buffer[j] = ReadULong();
				}
			}
		}
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct UdpByteConverter
	{
		[FieldOffset(0)]
		public short Signed16;

		[FieldOffset(0)]
		public ushort Unsigned16;

		[FieldOffset(0)]
		public char Char;

		[FieldOffset(0)]
		public int Signed32;

		[FieldOffset(0)]
		public uint Unsigned32;

		[FieldOffset(0)]
		public long Signed64;

		[FieldOffset(0)]
		public ulong Unsigned64;

		[FieldOffset(0)]
		public float Float32;

		[FieldOffset(0)]
		public double Float64;

		[FieldOffset(0)]
		public byte Byte0;

		[FieldOffset(1)]
		public byte Byte1;

		[FieldOffset(2)]
		public byte Byte2;

		[FieldOffset(3)]
		public byte Byte3;

		[FieldOffset(4)]
		public byte Byte4;

		[FieldOffset(5)]
		public byte Byte5;

		[FieldOffset(6)]
		public byte Byte6;

		[FieldOffset(7)]
		public byte Byte7;

		public static implicit operator UdpByteConverter(short val)
		{
			return new UdpByteConverter
			{
				Signed16 = val
			};
		}

		public static implicit operator UdpByteConverter(ushort val)
		{
			return new UdpByteConverter
			{
				Unsigned16 = val
			};
		}

		public static implicit operator UdpByteConverter(char val)
		{
			return new UdpByteConverter
			{
				Char = val
			};
		}

		public static implicit operator UdpByteConverter(uint val)
		{
			return new UdpByteConverter
			{
				Unsigned32 = val
			};
		}

		public static implicit operator UdpByteConverter(int val)
		{
			return new UdpByteConverter
			{
				Signed32 = val
			};
		}

		public static implicit operator UdpByteConverter(ulong val)
		{
			return new UdpByteConverter
			{
				Unsigned64 = val
			};
		}

		public static implicit operator UdpByteConverter(long val)
		{
			return new UdpByteConverter
			{
				Signed64 = val
			};
		}

		public static implicit operator UdpByteConverter(float val)
		{
			return new UdpByteConverter
			{
				Float32 = val
			};
		}

		public static implicit operator UdpByteConverter(double val)
		{
			return new UdpByteConverter
			{
				Float64 = val
			};
		}
	}
	internal abstract class CommunicatorBase : ICommunicator
	{
		protected readonly Dictionary<Type, Action<int, IMessage>> Callbacks = new Dictionary<Type, Action<int, IMessage>>();

		protected readonly Queue<(int, Message)> MessageSendQueue = new Queue<(int, Message)>(64);

		protected readonly Queue<(int, object)> RecvQueue = new Queue<(int, object)>();

		private readonly List<Message> _messageList = new List<Message>(64);

		private readonly ProtocolSerializer _protocolSerializer = new ProtocolSerializer();

		public abstract int CommunicatorID { get; }

		public bool Poll()
		{
			return RecvQueue.Count > 0;
		}

		public void PushPackage(int senderActor, int eventCode, object data)
		{
			senderActor = ((senderActor > 0) ? senderActor : 0);
			switch (eventCode)
			{
			case 101:
				RecvQueue.Enqueue((senderActor, data));
				break;
			case 100:
				HandleProtocolPackage(senderActor, data);
				break;
			case 102:
				InternalLogStreams.LogTraceDummyTraffic?.Log($"Received Dummy Traffic from [{senderActor}]");
				break;
			}
		}

		public unsafe void SendMessage(int targetActor, IMessage message)
		{
			if (_protocolSerializer.ConvertToBuffer((Message)message, out var buffer))
			{
				fixed (byte* data = buffer.Data)
				{
					if (SendPackage(100, targetActor, reliable: true, data, buffer.BytesRequired))
					{
						InternalLogStreams.LogDebug?.Log($"Sending to [{targetActor}]: {message}");
					}
					else
					{
						MessageSendQueue.Enqueue((targetActor, (Message)message));
					}
				}
			}
			else
			{
				MessageSendQueue.Enqueue((targetActor, (Message)message));
			}
		}

		public virtual void Service()
		{
			if (MessageSendQueue.Count > 0)
			{
				var (targetActor, message) = MessageSendQueue.Dequeue();
				SendMessage(targetActor, message);
			}
		}

		private void HandleProtocolPackage(int actorNr, object data)
		{
			ConvertData(data, out var dataBuffer, out var _);
			if (dataBuffer == null || !_protocolSerializer.ConvertToMessages(dataBuffer, _messageList))
			{
				return;
			}
			foreach (Message message in _messageList)
			{
				if (Callbacks.TryGetValue(message.GetType(), out var value))
				{
					InternalLogStreams.LogDebug?.Log($"Received from [{actorNr}] :: {message}");
					value(actorNr, message);
				}
			}
		}

		public unsafe int ReceivePackage(out int senderActor, byte* buffer, int bufferLength)
		{
			if (Poll())
			{
				var (num, data) = RecvQueue.Dequeue();
				ConvertData(data, out var dataBuffer, out var maxLength);
				if (maxLength > 0)
				{
					senderActor = num;
					Assert.Always(maxLength <= bufferLength, "ReceivePackage overflow");
					fixed (byte* source = dataBuffer)
					{
						Native.MemCpy(buffer, source, maxLength);
					}
					return maxLength;
				}
			}
			senderActor = -1;
			return -1;
		}

		public unsafe abstract bool SendPackage(byte code, int targetActor, bool reliable, byte* buffer, int bufferLength);

		protected abstract void ConvertData(object data, out byte[] dataBuffer, out int maxLength);

		public void RegisterPackageCallback<K>(Action<int, K> callback) where K : IMessage
		{
			Callbacks.Add(typeof(K), delegate(int actor, IMessage msg)
			{
				callback(actor, (K)msg);
			});
		}
	}
	internal class ChangeMasterClient : Message
	{
		public int NewMasterClientCandidate;

		public ChangeMasterClient()
		{
		}

		public ChangeMasterClient(int newMasterClientCandidate, ProtocolMessageVersion protocolVersion = ProtocolMessageVersion.V1_6_0, Version serializationVersion = null)
			: base(protocolVersion, serializationVersion)
		{
			NewMasterClientCandidate = newMasterClientCandidate;
		}

		protected override void SerializeProtected(BitStream stream)
		{
			stream.Serialize(ref NewMasterClientCandidate);
		}

		public override string ToString()
		{
			return string.Format("[{0}: {1}={2}, {3}]", "ChangeMasterClient", "NewMasterClientCandidate", NewMasterClientCandidate, base.ToString());
		}
	}
	internal abstract class Message : IMessage
	{
		private const int CustomDataLength = 1024;

		public ProtocolMessageVersion ProtocolVersion;

		public Version FusionSerializationVersion;

		private string _customData = string.Empty;

		public virtual bool IsValid => HasValidVersion;

		internal bool HasValidVersion => ProtocolVersion != ProtocolMessageVersion.Invalid && FusionSerializationVersion != Versioning.InvalidVersion;

		public string CustomData
		{
			get
			{
				return _customData;
			}
			set
			{
				Assert.Always(value.Length <= 1024, $"Protocol Message Custom Data size is greater than {1024}");
				_customData = value.Substring(0, Math.Min(value.Length, 1024));
			}
		}

		public virtual Message Clone()
		{
			return (Message)MemberwiseClone();
		}

		public Message(ProtocolMessageVersion protocolMessage = ProtocolMessageVersion.V1_6_0, Version serializationVersion = null)
		{
			ProtocolVersion = protocolMessage;
			FusionSerializationVersion = serializationVersion ?? Versioning.GetCurrentVersion;
		}

		public void Serialize(BitStream stream)
		{
			byte value = (byte)ProtocolVersion;
			int value2 = FusionSerializationVersion.Major;
			int value3 = FusionSerializationVersion.Minor;
			int value4 = FusionSerializationVersion.Build;
			stream.Serialize(ref value);
			value = Math.Min((byte)10, value);
			if (value >= 2)
			{
				stream.Serialize(ref value2);
				stream.Serialize(ref value3);
				stream.Serialize(ref value4);
			}
			else
			{
				value2 = 0;
				value3 = 0;
				value4 = 0;
			}
			ProtocolVersion = (ProtocolMessageVersion)value;
			FusionSerializationVersion = new Version(value2, value3, value4);
			if (FusionSerializationVersion.ShortVersion() == Versioning.GetCurrentVersion.ShortVersion())
			{
				SerializeProtected(stream);
				if (value >= 3)
				{
					stream.Serialize(ref _customData);
				}
				else
				{
					_customData = string.Empty;
				}
			}
		}

		protected virtual void SerializeProtected(BitStream stream)
		{
		}

		public bool CheckCompatibility(ProtocolMessageVersion pluginProtocolVersion, Version pluginVersion, Version sessionSerializationVersion)
		{
			if (ProtocolVersion == ProtocolMessageVersion.Invalid || pluginProtocolVersion == ProtocolMessageVersion.Invalid || ProtocolVersion != pluginProtocolVersion)
			{
				return false;
			}
			if ((int)pluginProtocolVersion < 2)
			{
				return true;
			}
			if (FusionSerializationVersion == Versioning.InvalidVersion || sessionSerializationVersion == Versioning.InvalidVersion || FusionSerializationVersion.ShortVersion() > pluginVersion.ShortVersion() || FusionSerializationVersion.ShortVersion() < new Version(1, 0))
			{
				return false;
			}
			return FusionSerializationVersion == sessionSerializationVersion;
		}

		public override string ToString()
		{
			return string.Format("{0}={1}, {2}={3}, {4}={5}", "ProtocolVersion", ProtocolVersion, "FusionSerializationVersion", FusionSerializationVersion, "CustomData", CustomData);
		}
	}
	internal class Disconnect : Message
	{
		public DisconnectReason DisconnectReason;

		public Disconnect()
		{
		}

		public Disconnect(DisconnectReason reason, ProtocolMessageVersion protocolVersion = ProtocolMessageVersion.V1_6_0, Version serializationVersion = null)
			: base(protocolVersion, serializationVersion)
		{
			DisconnectReason = reason;
		}

		protected override void SerializeProtected(BitStream stream)
		{
			string value = DisconnectReason.ToString();
			byte value2 = (byte)DisconnectReason;
			if ((int)ProtocolVersion >= 2)
			{
				stream.Serialize(ref value2);
			}
			else
			{
				stream.Serialize(ref value);
			}
			DisconnectReason = (DisconnectReason)value2;
		}

		public override string ToString()
		{
			return string.Format("[{0}: {1}={2}, {3}]", "Disconnect", "DisconnectReason", DisconnectReason, base.ToString());
		}
	}
	public enum DisconnectReason : byte
	{
		None,
		ServerLogic,
		InvalidEventCode,
		InvalidJoinMsgType,
		InvalidJoinGameMode,
		IncompatibleConfiguration,
		ServerAlreadyInRoom,
		Error
	}
	internal class DummyTrafficSync : Message
	{
		private const int DummySendIntervalMax = 5000;

		private const int DummySendIntervalMin = 100;

		private const int DummySizeMax = 128;

		private const int DummySizeMin = 2;

		public int SendInterval { get; private set; } = 5000;

		public int Size { get; private set; } = 2;

		public override bool IsValid => base.IsValid && SendInterval >= 100 && SendInterval <= 5000 && Size >= 2 && Size <= 128;

		public DummyTrafficSync()
		{
		}

		public DummyTrafficSync(int sendInterval, int size, ProtocolMessageVersion protocolVersion = ProtocolMessageVersion.V1_6_0, Version serializationVersion = null)
			: base(protocolVersion, serializationVersion)
		{
			SendInterval = Math.Max(Math.Min(sendInterval, 5000), 100);
			Size = Math.Max(Math.Min(size, 128), 2);
		}

		protected override void SerializeProtected(BitStream stream)
		{
			int value = SendInterval;
			int value2 = Size;
			stream.Serialize(ref value);
			stream.Serialize(ref value2);
			SendInterval = Math.Max(Math.Min(value, 5000), 100);
			Size = Math.Max(Math.Min(value2, 128), 2);
		}

		public override string ToString()
		{
			return string.Format("[{0}: {1}={2}, {3}={4}, {5}]", "DummyTrafficSync", "SendInterval", SendInterval, "Size", Size, base.ToString());
		}
	}
	internal class HostMigration : Message
	{
		public PeerMode PeerMode;

		public HostMigration()
		{
		}

		public HostMigration(PeerMode peerMode, ProtocolMessageVersion protocolVersion = ProtocolMessageVersion.V1_6_0, Version serializationVersion = null)
			: base(protocolVersion, serializationVersion)
		{
			PeerMode = peerMode;
		}

		protected override void SerializeProtected(BitStream stream)
		{
			byte value = (byte)PeerMode;
			stream.Serialize(ref value);
			PeerMode = (PeerMode)value;
		}

		public override string ToString()
		{
			return string.Format("[{0}: {1}={2}, {3}]", "HostMigration", "PeerMode", PeerMode, base.ToString());
		}
	}
	internal enum JoinMessageType : byte
	{
		Request = 1,
		Confirmation
	}
	internal enum PeerMode : byte
	{
		None,
		Server,
		Client
	}
	[Flags]
	internal enum JoinRequests : uint
	{
		None = 0u,
		NetworkConfig = 2u,
		ReflexiveInfo = 4u,
		DisableNATPunch = 8u
	}
	internal class Join : Message
	{
		public JoinMessageType Type;

		public PluginGameMode GameMode;

		public PeerMode PeerMode;

		public JoinRequests JoinRequests;

		public byte[] UniqueId;

		public int PlayerRef;

		public byte[] EncryptionKey;

		public byte[] EncryptionKeySecret;

		public Join()
		{
		}

		public Join(JoinMessageType type, PluginGameMode mode, PeerMode peerMode, int playerRef, JoinRequests joinRequests = JoinRequests.None, byte[] uniqueID = null, byte[] encryptionKey = null, byte[] encryptionKeySecret = null, ProtocolMessageVersion protocolVersion = ProtocolMessageVersion.V1_6_0, Version serializationVersion = null)
			: base(protocolVersion, serializationVersion)
		{
			if (type == JoinMessageType.Request)
			{
				Assert.Check(playerRef == 0);
			}
			else
			{
				Assert.Check(playerRef > 0);
			}
			Type = type;
			GameMode = mode;
			JoinRequests = joinRequests;
			PeerMode = peerMode;
			UniqueId = uniqueID;
			PlayerRef = playerRef;
			EncryptionKey = encryptionKey;
			EncryptionKeySecret = encryptionKeySecret;
		}

		protected override void SerializeProtected(BitStream stream)
		{
			byte value = (byte)Type;
			byte value2 = (byte)GameMode;
			byte value3 = (byte)PeerMode;
			uint value4 = (uint)JoinRequests;
			stream.Serialize(ref value);
			stream.Serialize(ref value2);
			stream.Serialize(ref value3);
			stream.Serialize(ref value4);
			if ((int)ProtocolVersion >= 6)
			{
				stream.Serialize(ref UniqueId);
			}
			if ((int)ProtocolVersion >= 7)
			{
				stream.Serialize(ref PlayerRef);
			}
			if ((int)ProtocolVersion >= 9)
			{
				stream.Serialize(ref EncryptionKey);
				stream.Serialize(ref EncryptionKeySecret);
			}
			Type = (JoinMessageType)value;
			GameMode = (PluginGameMode)value2;
			PeerMode = (PeerMode)value3;
			JoinRequests = (JoinRequests)value4;
		}

		public override string ToString()
		{
			long num = ((UniqueId != null && UniqueId.Length == 8) ? BitConverter.ToInt64(UniqueId, 0) : 0);
			return string.Format("[{0}: {1}={2}, {3}={4}, {5}={6}, {7}={8}, {9}={10}, {11}]", "Join", "Type", Type, "GameMode", GameMode, "PeerMode", PeerMode, "JoinRequests", JoinRequests, "UniqueId", num, base.ToString());
		}
	}
	internal enum SyncType : byte
	{
		Request = 1,
		Response,
		Override
	}
	internal class NetworkConfigSync : Message
	{
		public SyncType Type;

		public string NetworkConfig;

		public NetworkConfigSync()
		{
		}

		public NetworkConfigSync(SyncType type, string serializedNetworkConfig, ProtocolMessageVersion protocolVersion = ProtocolMessageVersion.V1_6_0, Version serializationVersion = null)
			: base(protocolVersion, serializationVersion)
		{
			Type = type;
			NetworkConfig = serializedNetworkConfig;
		}

		protected override void SerializeProtected(BitStream stream)
		{
			byte value = (byte)Type;
			stream.Serialize(ref value);
			stream.Serialize(ref NetworkConfig);
			Type = (SyncType)value;
		}

		public override string ToString()
		{
			return string.Format("[{0}: {1}={2}, {3}={4}, {5}]", "NetworkConfigSync", "Type", Type, "NetworkConfig", NetworkConfig, base.ToString());
		}
	}
	internal class PlayerRefMapping : Message
	{
		public int ActorId;

		public int PlayerRef;

		public byte[] UniqueId;

		protected override void SerializeProtected(BitStream stream)
		{
			stream.Serialize(ref ActorId);
			stream.Serialize(ref PlayerRef);
			stream.Serialize(ref UniqueId);
		}

		public override string ToString()
		{
			long num = ((UniqueId != null && UniqueId.Length == 8) ? BitConverter.ToInt64(UniqueId, 0) : 0);
			return string.Format("[{0}: {1}={2}, {3}={4}, {5}={6}, {7}]", "PlayerRefMapping", "ActorId", ActorId, "PlayerRef", PlayerRef, "UniqueId", num, base.ToString());
		}
	}
	internal class ReflexiveInfo : Message
	{
		public int ActorNr;

		public NetAddress PublicAddr;

		public NetAddress PrivateAddr;

		public NATType NatType;

		public byte[] UniqueId;

		public override bool IsValid => base.IsValid && PublicAddr.IsValid && PrivateAddr.IsValid;

		public ReflexiveInfo()
		{
		}

		public ReflexiveInfo(int actorNr, NetAddress publicAddr, NetAddress privateAddr, NATType stunNatType, byte[] uniqueID = null, ProtocolMessageVersion protocolVersion = ProtocolMessageVersion.V1_6_0, Version serializationVersion = null)
			: base(protocolVersion, serializationVersion)
		{
			ActorNr = actorNr;
			PublicAddr = publicAddr;
			PrivateAddr = privateAddr;
			NatType = stunNatType;
			UniqueId = uniqueID;
		}

		protected override void SerializeProtected(BitStream stream)
		{
			stream.Serialize(ref ActorNr);
			PublicAddr.Serialize(stream);
			PrivateAddr.Serialize(stream);
			byte value = (byte)NatType;
			if ((int)ProtocolVersion >= 4)
			{
				stream.Serialize(ref value);
			}
			else
			{
				value = 4;
			}
			NatType = (NATType)value;
			if ((int)ProtocolVersion >= 6)
			{
				stream.Serialize(ref UniqueId);
			}
		}

		public override string ToString()
		{
			long num = ((UniqueId != null && UniqueId.Length == 8) ? BitConverter.ToInt64(UniqueId, 0) : 0);
			return string.Format("[{0}: {1}={2}, {3}={4}, {5}={6}, {7}={8}, {9}={10}, {11}]", "ReflexiveInfo", "ActorNr", ActorNr, "PublicAddr", PublicAddr, "PrivateAddr", PrivateAddr, "NatType", NatType, "UniqueId", num, base.ToString());
		}
	}
	internal enum SnapshotType : byte
	{
		Invalid,
		Data,
		Confirmation
	}
	internal class Snapshot : Message
	{
		public int Tick { get; private set; }

		public uint NetworkID { get; private set; }

		public SnapshotType SnapshotType { get; private set; }

		public int TotalSize { get; private set; }

		public override bool IsValid => base.IsValid && CRC == ComputeCRC(Data, TotalSize);

		public byte[] Data { get; private set; }

		private ulong CRC { get; set; }

		public Snapshot()
		{
		}

		public Snapshot(int tick, uint networkID, SnapshotType snapshotType, int snapshotSize, byte[] data, ProtocolMessageVersion protocolVersion = ProtocolMessageVersion.V1_6_0, Version serializationVersion = null)
			: base(protocolVersion, serializationVersion)
		{
			Tick = tick;
			NetworkID = networkID;
			SnapshotType = snapshotType;
			TotalSize = snapshotSize;
			Data = data;
			CRC = ComputeCRC(Data, TotalSize);
		}

		protected override void SerializeProtected(BitStream stream)
		{
			int value = Tick;
			uint value2 = NetworkID;
			byte value3 = (byte)SnapshotType;
			ulong value4 = CRC;
			int value5 = TotalSize;
			byte[] array = Data;
			stream.Serialize(ref value);
			stream.Serialize(ref value2);
			stream.Serialize(ref value3);
			int value6 = 0;
			stream.Serialize(ref value6);
			stream.Serialize(ref value4);
			stream.Serialize(ref value5);
			stream.Serialize(ref array, ref value5);
			Tick = value;
			NetworkID = value2;
			SnapshotType = (SnapshotType)value3;
			CRC = value4;
			TotalSize = value5;
			Data = array;
		}

		private unsafe static ulong ComputeCRC(byte[] data, int length)
		{
			if (data == null)
			{
				return 0uL;
			}
			fixed (byte* data2 = data)
			{
				return CRC64.Compute(data2, length);
			}
		}

		public override Message Clone()
		{
			return new Snapshot();
		}

		public override string ToString()
		{
			return string.Format("[{0}: {1}={2}, {3}={4}, {5}={6}, {7}={8}, CRC={9}, {10}={11}, {12}]", "Snapshot", "Tick", Tick, "NetworkID", NetworkID, "SnapshotType", SnapshotType, "TotalSize", TotalSize, CRC, "IsValid", IsValid, base.ToString());
		}
	}
	[Flags]
	internal enum StartRequests : uint
	{
		None = 0u,
		ConnectToShared = 2u,
		WaitForReflexiveInfo = 4u
	}
	internal class Start : Message
	{
		public int RemoteServerID;

		public StartRequests StartRequests;

		public Start()
		{
		}

		public Start(int remoteServerId, StartRequests startRequests, ProtocolMessageVersion protocolVersion = ProtocolMessageVersion.V1_6_0, Version serializationVersion = null)
			: base(protocolVersion, serializationVersion)
		{
			RemoteServerID = remoteServerId;
			StartRequests = startRequests;
		}

		protected override void SerializeProtected(BitStream stream)
		{
			uint value = (uint)StartRequests;
			stream.Serialize(ref RemoteServerID);
			stream.Serialize(ref value);
			StartRequests = (StartRequests)value;
		}

		public override string ToString()
		{
			return string.Format("[{0}: {1}={2}, {3}={4}, {5}]", "Start", "RemoteServerID", RemoteServerID, "StartRequests", StartRequests, base.ToString());
		}
	}
	internal enum PluginGameMode : byte
	{
		Invalid,
		ClientServer,
		Shared
	}
	internal static class EventCodes
	{
		public const byte PROTOCOL = 100;

		public const byte DATA = 101;

		public const byte DUMMY = 102;
	}
	internal static class PhotonConstants
	{
		public const byte SERVER_ACTOR_ID = 0;

		public const byte FUSION_DATA_EVENT_PARAMETER_CODE = 245;
	}
	internal class ProtocolSerializer
	{
		private readonly BitStream _writeStream = new BitStream(new byte[8192]);

		private readonly BitStream _readStream = new BitStream(new byte[0]);

		private readonly Dictionary<Type, byte> _typeToId = new Dictionary<Type, byte>();

		private readonly Dictionary<byte, Message> _idToType = new Dictionary<byte, Message>();

		public ProtocolSerializer()
		{
			RegisterProtocolMsg(1, new Join());
			RegisterProtocolMsg(2, new NetworkConfigSync());
			RegisterProtocolMsg(3, new ReflexiveInfo());
			RegisterProtocolMsg(4, new Disconnect());
			RegisterProtocolMsg(5, new Start());
			RegisterProtocolMsg(6, new Snapshot());
			RegisterProtocolMsg(7, new HostMigration());
			RegisterProtocolMsg(8, new PlayerRefMapping());
			RegisterProtocolMsg(9, new ChangeMasterClient());
			RegisterProtocolMsg(10, new DummyTrafficSync());
		}

		public bool ConvertToMessages(byte[] data, List<Message> messages)
		{
			Assert.Check(data != null, "Data buffer can't be null to convert Messages");
			try
			{
				_readStream.SetBuffer(data, data.Length);
				_readStream.Reading = true;
				messages.Clear();
				Message msg;
				while (ReadNext(_readStream, out msg))
				{
					messages.Add(msg);
				}
				return messages.Count > 0;
			}
			catch (Exception message)
			{
				InternalLogStreams.LogDebug?.Error(message);
			}
			return false;
		}

		public bool ConvertToBuffer(Message message, out BitStream buffer)
		{
			try
			{
				_writeStream.Reset();
				_writeStream.Writing = true;
				if (PackNext(message, _writeStream))
				{
					buffer = _writeStream;
					return true;
				}
			}
			catch (IndexOutOfRangeException)
			{
				_writeStream.Expand();
			}
			catch (Exception message2)
			{
				InternalLogStreams.LogDebug?.Error(message2);
			}
			buffer = null;
			return false;
		}

		private void RegisterProtocolMsg(byte id, Message message)
		{
			_idToType.Add(id, message);
			_typeToId.Add(message.GetType(), id);
		}

		private bool PackNext(Message msg, BitStream stream)
		{
			int position = stream.Position;
			Assert.Check(stream.Writing);
			Assert.Check(_typeToId.ContainsKey(msg.GetType()), "Message {0} not registered", msg.GetType());
			stream.WriteByte(_typeToId[msg.GetType()]);
			msg.Serialize(stream);
			if (stream.Overflowing)
			{
				stream.Position = position;
				return false;
			}
			return true;
		}

		private bool ReadNext(BitStream stream, out Message msg)
		{
			try
			{
				Assert.Check(stream.Reading);
				if (!stream.CanRead(8))
				{
					msg = null;
					return false;
				}
				byte key = stream.ReadByte();
				msg = _idToType[key].Clone();
				msg.Serialize(stream);
				return true;
			}
			catch
			{
				msg = null;
				return false;
			}
		}
	}
	internal enum ProtocolMessageVersion : byte
	{
		Invalid = 0,
		V1_0_0 = 1,
		V1_1_0 = 2,
		V1_2_0 = 3,
		V1_2_1 = 4,
		V1_2_2 = 5,
		V1_2_3 = 6,
		V1_3_0 = 7,
		V1_4_0 = 8,
		V1_5_0 = 9,
		V1_6_0 = 10,
		LATEST = 10
	}
}
namespace Fusion.Sockets
{
	public interface INetBitWriteStream
	{
		int OffsetBits { get; }

		void WriteInt32(int value, int bits = 32);

		void WriteInt32VarLength(int value);

		void WriteInt32VarLength(int value, int blockSize);

		void WriteUInt64VarLength(ulong value, int blockSize);

		bool WriteBoolean(bool b);

		unsafe void WriteBytesAligned(void* buffer, int length);

		void WriteBytesAligned(Span<byte> buffer);
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct NetAddress : IEquatable<NetAddress>
	{
		public sealed class EqualityComparer : IEqualityComparer<NetAddress>
		{
			public bool Equals(NetAddress x, NetAddress y)
			{
				return x.Block0 == y.Block0 && x.Block1 == y.Block1 && x.Block2 == y.Block2;
			}

			public int GetHashCode(NetAddress obj)
			{
				int hashCode = obj.Block0.GetHashCode();
				hashCode = (hashCode * 397) ^ obj.Block1.GetHashCode();
				return (hashCode * 397) ^ obj.Block2.GetHashCode();
			}
		}

		internal static class SubnetMask
		{
			public static NetAddress[] SubnetMasks { get; private set; } = new NetAddress[3]
			{
				CreateFromIpPort("255.0.0.0", 0),
				CreateFromIpPort("255.255.0.0", 0),
				CreateFromIpPort("255.255.255.0", 0)
			};

			public static bool IsSameSubNet(NetAddress addressA, NetAddress addressB)
			{
				if (!addressA.IsValid || !addressB.IsValid)
				{
					return false;
				}
				if (addressA.IsIPv6 ^ addressB.IsIPv6)
				{
					return false;
				}
				if (addressA.IsIPv6 && addressB.IsIPv6)
				{
					return true;
				}
				if (!addressA.IsIPv6 && !addressB.IsIPv6)
				{
					NetAddress[] subnetMasks = SubnetMasks;
					foreach (NetAddress subnetMask in subnetMasks)
					{
						NetAddress networkAddress = GetNetworkAddress(addressA, subnetMask);
						NetAddress networkAddress2 = GetNetworkAddress(addressB, subnetMask);
						if (networkAddress.Equals(networkAddress2))
						{
							return true;
						}
					}
				}
				return false;
			}

			public static NetAddress GetNetworkAddress(NetAddress netAddress, NetAddress subnetMask)
			{
				NetAddress result = Any(0);
				result.Block0 = netAddress.Block0 & subnetMask.Block0;
				result.Block1 = netAddress.Block1 & subnetMask.Block1;
				result.Block2 = netAddress.Block2 & subnetMask.Block2;
				return result;
			}
		}

		[FieldOffset(0)]
		internal Address NativeAddress;

		[FieldOffset(0)]
		internal ulong Block0;

		[FieldOffset(8)]
		internal ulong Block1;

		[FieldOffset(16)]
		internal ulong Block2;

		[FieldOffset(20)]
		private int _actorId;

		internal static NetAddress AnyIPv4Addr = new NetAddress
		{
			NativeAddress = new Address
			{
				_address0 = 0uL,
				_address1 = 4294901760uL,
				Port = 0
			},
			_actorId = 0
		};

		internal static NetAddress AnyIPv6Addr = new NetAddress
		{
			NativeAddress = new Address
			{
				_address0 = 0uL,
				_address1 = 0uL,
				Port = 0
			},
			_actorId = 0
		};

		public int ActorId => _actorId - 1;

		public bool IsRelayAddr => ActorId >= 0;

		public bool IsIPv6 => !IsRelayAddr && (NativeAddress._address0 != 0L || (NativeAddress._address1 & 0xFFFF0000u) != 4294901760u);

		public bool IsIPv4 => !IsRelayAddr && (NativeAddress._address1 & 0xFFFF0000u) == 4294901760u;

		public bool IsValid => !Equals(AnyIPv4Addr) && !Equals(AnyIPv6Addr);

		public bool HasAddress
		{
			get
			{
				if (IsRelayAddr)
				{
					return false;
				}
				if (IsIPv6)
				{
					return NativeAddress._address0 != 0L || NativeAddress._address1 != 0;
				}
				if (IsIPv4)
				{
					return NativeAddress._address0 == 0L && NativeAddress._address1 >> 32 != 0;
				}
				return false;
			}
		}

		public static NetAddress FromActorId(int actorId)
		{
			Assert.Check(actorId >= 0, "ActorID must be 0 or greater");
			return new NetAddress
			{
				_actorId = actorId + 1
			};
		}

		internal static ulong Hash64(NetAddress address)
		{
			ulong num = 17uL;
			num = num * 31 + address.Block0;
			num = num * 31 + address.Block1;
			return num * 31 + address.Block2;
		}

		public static NetAddress LocalhostIPv4(ushort port = 0)
		{
			return CreateFromIpPort("127.0.0.1", port);
		}

		public static NetAddress LocalhostIPv6(ushort port = 0)
		{
			return CreateFromIpPort("::1", port);
		}

		public static NetAddress Any(ushort port = 0)
		{
			return CreateFromIpPort("0.0.0.0", port);
		}

		public static NetAddress AnyIPv6(ushort port = 0)
		{
			return CreateFromIpPort("::", port);
		}

		public static NetAddress CreateFromIpPort(string ip, ushort port)
		{
			if (string.IsNullOrEmpty(ip) || !IPAddress.TryParse(ip, out var _))
			{
				throw new ArgumentException("IP/Port passed are invalid.");
			}
			ip = ip.Split('%')[0];
			Address address2 = default(Address);
			Assert.Always(UDP.SetIP(ref address2, ip) == Status.Ok, "Unable to parse IP. Verify if it represents a valid IP.");
			address2.Port = port;
			return new NetAddress
			{
				NativeAddress = address2,
				_actorId = 0
			};
		}

		internal void Serialize(BitStream stream)
		{
			stream.Serialize(ref Block0);
			stream.Serialize(ref Block1);
			stream.Serialize(ref Block2);
		}

		public bool Equals(NetAddress other)
		{
			return Block0 == other.Block0 && Block1 == other.Block1 && Block2 == other.Block2;
		}

		public override bool Equals(object obj)
		{
			return obj is NetAddress other && Equals(other);
		}

		public override int GetHashCode()
		{
			int hashCode = Block0.GetHashCode();
			hashCode = (hashCode * 397) ^ Block1.GetHashCode();
			return (hashCode * 397) ^ Block2.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("[{0}: {1}: {2}, {3}: {4}, {5}: {6}, {7}: {8}, {9}: {10}, [{11},{12},{13}]]", "NetAddress", "IsValid", IsValid, "ActorId", ActorId, "NativeAddress", NativeAddress, "IsIPv6", IsIPv6, "IsRelayAddr", IsRelayAddr, Block0, Block1, Block2);
		}
	}
	public struct NetBitBuffer : INetBitWriteStream, ILogDumpable
	{
		public unsafe struct Offset(NetBitBuffer* buffer)
		{
			private unsafe int _offset = buffer->OffsetBits;

			public unsafe int GetLength(NetBitBuffer* buffer)
			{
				return buffer->OffsetBits - _offset;
			}
		}

		private const int BITCOUNT = 64;

		private const int USEDMASK = 63;

		private const int INDEXSHIFT = 6;

		private const int BYTESHIFT = 3;

		private const ulong MAXVALUE = ulong.MaxValue;

		public NetAddress Address;

		internal unsafe NetBitBuffer* Prev;

		internal unsafe NetBitBuffer* Next;

		internal unsafe NetBitBufferBlock* _block;

		internal unsafe NetBitBuffer* _allocNext;

		private int _group;

		private unsafe ulong* _data;

		private unsafe ulong* _dataBlockOriginal;

		private int _offsetBits;

		private int _lengthBits;

		private int _lengthBytes;

		internal short Group
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (short)(_group - 1);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				_group = value + 1;
			}
		}

		public unsafe ulong* Data
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _data;
			}
			internal set
			{
				_data = value;
			}
		}

		public int LengthBits
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _lengthBits;
			}
		}

		public int BytesRemaining => _lengthBytes - Maths.BytesRequiredForBits(_offsetBits);

		public int LengthBytes
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _lengthBytes;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal set
			{
				Assert.Check(value >= 0);
				_lengthBits = value << 3;
				_lengthBytes = value;
			}
		}

		public int OffsetBits
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _offsetBits;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal set
			{
				Assert.Check(value >= 0 && value <= _lengthBits);
				_offsetBits = value;
			}
		}

		public bool Done
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _offsetBits == _lengthBits;
			}
		}

		public bool Overflow
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _offsetBits > _lengthBits;
			}
		}

		internal bool OverflowOrLessThanOneByteRemaining
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _offsetBits + 8 > _lengthBits;
			}
		}

		public int OffsetBitsUnsafe
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _offsetBits;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				_offsetBits = value;
			}
		}

		public bool DoneOrOverflow
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _offsetBits >= _lengthBits;
			}
		}

		public bool MoreToRead
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _offsetBits < _lengthBits;
			}
		}

		internal unsafe NetPacketType PacketType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return *(NetPacketType*)_data;
			}
			set
			{
				*(NetPacketType*)_data = value;
			}
		}

		public bool IsOnEvenByte
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _offsetBits % 8 == 0;
			}
		}

		public int OffsetBytes
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				Assert.Check(IsOnEvenByte);
				Assert.Check(Maths.BytesRequiredForBits(_offsetBits) == _offsetBits / 8);
				return _offsetBits / 8;
			}
		}

		public unsafe void ReplaceDataFromBlockWithTemp(int tempSize)
		{
			EngineProfiler.Begin("ReplaceDataFromBlockWithTemp");
			tempSize = Native.RoundToAlignment(tempSize, 8);
			if (_dataBlockOriginal == null)
			{
				_dataBlockOriginal = _data;
				_data = (ulong*)Native.MallocAndClear(tempSize + 1024);
				Native.MemCpy(_data, _dataBlockOriginal, _lengthBytes);
			}
			else
			{
				ulong* memory = _data;
				_data = (ulong*)Native.MallocAndClear(tempSize + 1024);
				Native.MemCpy(_data, memory, _lengthBytes);
				Native.Free(ref memory);
			}
			_lengthBytes = tempSize;
			_lengthBits = tempSize << 3;
			EngineProfiler.End();
		}

		public unsafe static Offset GetOffset(NetBitBuffer* buffer)
		{
			return new Offset(buffer);
		}

		public unsafe static NetBitBuffer* Allocate(int group, int size)
		{
			if (size <= 0)
			{
				throw new InvalidOperationException();
			}
			size = Native.RoundToAlignment(size, 8);
			Native.MallocAndClearBlock(sizeof(NetBitBuffer), size, out var ptr, out var ptr2);
			NetBitBuffer* ptr3 = (NetBitBuffer*)ptr;
			ptr3->_group = group;
			ptr3->SetBufferLengthBytes((ulong*)ptr2, size);
			return ptr3;
		}

		public unsafe static void ReleaseRef(ref NetBitBuffer* buffer)
		{
			if (buffer != null)
			{
				NetBitBuffer* buffer2 = buffer;
				buffer = null;
				Release(buffer2);
			}
		}

		public unsafe static void Release(NetBitBuffer* buffer)
		{
			if (buffer != null)
			{
				if (buffer->_dataBlockOriginal != null)
				{
					Native.Free(ref buffer->_data);
					buffer->_data = buffer->_dataBlockOriginal;
					buffer->_dataBlockOriginal = null;
				}
				if (buffer->_block != null)
				{
					buffer->_block->Release(buffer);
				}
				else
				{
					InternalLogStreams.LogDebug?.Warn("NetBitBuffer trying to release with a null block.");
				}
			}
		}

		public unsafe void SetBufferLengthBytes(ulong* buffer, int lenghtInBytes)
		{
			Assert.Check((long)buffer % 8L == 0);
			Assert.Check(lenghtInBytes % 8 == 0);
			_data = buffer;
			_lengthBits = lenghtInBytes << 3;
			_lengthBytes = lenghtInBytes;
		}

		public unsafe void Clear()
		{
			Assert.Check(_data != null);
			Assert.Check(_lengthBytes > 0);
			Native.MemClear(_data, _lengthBytes);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool WriteBoolean(bool value)
		{
			Write((ulong)(value ? 1 : 0), 1);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ReadBoolean()
		{
			return Read(1) == 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool PeekBoolean()
		{
			return Peek(1) == 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteByte(byte value, int bits = 8)
		{
			Assert.Check(bits >= 0 && bits <= 8);
			Write(value, bits);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte ReadByte(int bits = 8)
		{
			Assert.Check(bits >= 0 && bits <= 8, bits);
			return (byte)Read(bits);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteInt16(short value, int bits = 16)
		{
			Assert.Check(bits >= 0 && bits <= 16);
			Write((ulong)value, bits);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public short ReadInt16(int bits = 16)
		{
			Assert.Check(bits >= 0 && bits <= 16, bits);
			return (short)Read(bits);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUInt16(ushort value, int bits = 16)
		{
			Assert.Check(bits >= 0 && bits <= 16);
			Write(value, bits);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ushort ReadUInt16(int bits = 16)
		{
			Assert.Check(bits >= 0 && bits <= 16, bits);
			return (ushort)Read(bits);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteInt32(int value, int bits = 32)
		{
			Assert.Check(bits >= 0 && bits <= 32);
			Write((ulong)value, bits);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int ReadInt32(int bits = 32)
		{
			Assert.Check(bits >= 0 && bits <= 32, bits);
			return (int)Read(bits);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUInt32(uint value, int bits = 32)
		{
			Assert.Check(bits >= 0 && bits <= 32);
			Write(value, bits);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteString(string value)
		{
			WriteString(value, Encoding.UTF8);
		}

		public void WriteString(string value, Encoding encoding)
		{
			if (!WriteBoolean(value == null))
			{
				byte[] bytes = encoding.GetBytes(value);
				WriteUInt16((ushort)bytes.Length);
				WriteBytesAligned(bytes, bytes.Length);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ReadString()
		{
			return ReadString(Encoding.UTF8);
		}

		public unsafe string ReadString(Encoding encoding)
		{
			if (ReadBoolean())
			{
				return null;
			}
			int num = ReadUInt16();
			SeekToByteBoundary();
			Assert.Check(IsOnEvenByte);
			if (num == 0)
			{
				return "";
			}
			int num2 = Advance(num * 8, writing: false);
			byte* bytes = (byte*)_data + num2 / 8;
			return encoding.GetString(bytes, num);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool CanWrite(int bits)
		{
			return CanRead(bits);
		}

		public bool CanRead(int bits)
		{
			return _offsetBits + bits <= _lengthBits;
		}

		public void PadToByteBoundary()
		{
			if (_offsetBits % 8 != 0)
			{
				WriteByte(0, 8 - _offsetBits % 8);
			}
		}

		public unsafe byte* GetDataPointer()
		{
			Assert.Check(IsOnEvenByte);
			return (byte*)_data + _offsetBits / 8;
		}

		public unsafe byte* PadToByteBoundaryAndGetPtr()
		{
			PadToByteBoundary();
			Assert.Check(_offsetBits % 8 == 0);
			return (byte*)_data + _offsetBits / 8;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool CheckBitCount(int count)
		{
			return count >= 0 && OffsetBits + count <= _lengthBits;
		}

		public void SeekToByteBoundary()
		{
			_offsetBits = (_offsetBits + 7) & -8;
		}

		public unsafe void WriteBytesAligned(byte[] buffer, int length)
		{
			fixed (byte* buffer2 = buffer)
			{
				WriteBytesAligned(buffer2, length);
			}
		}

		public unsafe void WriteBytesAligned(void* buffer, int length)
		{
			PadToByteBoundary();
			Assert.Check(IsOnEvenByte);
			Assert.Check(OffsetBytes + length <= _lengthBytes, OffsetBytes + length, OffsetBytes, length, _lengthBytes);
			int num = Advance(length * 8, writing: true);
			int num2 = num >> 6;
			int num3 = num + length * 8 >> 6;
			if (num3 != num2)
			{
				_data[num3] = 0uL;
			}
			Native.MemCpy((byte*)_data + num / 8, buffer, length);
		}

		public unsafe void WriteBytesAligned(Span<byte> buffer)
		{
			PadToByteBoundary();
			Assert.Check(IsOnEvenByte);
			Assert.Check(OffsetBytes + buffer.Length <= _lengthBytes, OffsetBytes + buffer.Length, OffsetBytes, buffer.Length, _lengthBytes);
			int num = Advance(buffer.Length * 8, writing: true);
			int num2 = num >> 6;
			int num3 = num + buffer.Length * 8 >> 6;
			if (num3 != num2)
			{
				_data[num3] = 0uL;
			}
			Span<byte> d = new Span<byte>((byte*)_data + num / 8, buffer.Length);
			Native.MemCpy(d, buffer);
		}

		public unsafe void ReadBytesAligned(byte[] buffer, int length)
		{
			fixed (byte* buffer2 = buffer)
			{
				ReadBytesAligned(buffer2, length);
			}
		}

		public unsafe void ReadBytesAligned(Span<byte> buffer)
		{
			SeekToByteBoundary();
			Assert.Check(IsOnEvenByte);
			int num = Advance(buffer.Length * 8, writing: false);
			Native.MemCpy(buffer, new Span<byte>((byte*)_data + num / 8, buffer.Length));
		}

		public unsafe void ReadBytesAligned(void* buffer, int length)
		{
			SeekToByteBoundary();
			Assert.Check(IsOnEvenByte);
			int num = Advance(length * 8, writing: false);
			Native.MemCpy(buffer, (byte*)_data + num / 8, length);
		}

		public void WriteInt64VarLength(long value, int blockSize)
		{
			WriteUInt64VarLength((ulong)value, blockSize);
		}

		public void WriteInt32VarLength(int value)
		{
			WriteUInt32VarLength((uint)value);
		}

		public void WriteInt32VarLength(int value, int blockSize)
		{
			WriteUInt32VarLength((uint)value, blockSize);
		}

		public int ReadInt32VarLength()
		{
			return (int)ReadUInt32VarLength();
		}

		public long ReadInt64VarLength(int blockSize)
		{
			return (long)ReadUInt64VarLength(blockSize);
		}

		public int ReadInt32VarLength(int blockSize)
		{
			return (int)ReadUInt32VarLength(blockSize);
		}

		public uint ReadUInt32VarLength(int blockSize)
		{
			blockSize = Maths.Clamp(blockSize, 2, 16);
			int num = 1;
			while (!ReadBoolean() && !DoneOrOverflow)
			{
				num++;
			}
			if (DoneOrOverflow)
			{
				return 0u;
			}
			return ReadUInt32(num * blockSize);
		}

		public ulong ReadUInt64VarLength(int blockSize)
		{
			blockSize = Maths.Clamp(blockSize, 2, 16);
			int num = 1;
			while (!ReadBoolean() && !DoneOrOverflow)
			{
				num++;
			}
			if (DoneOrOverflow)
			{
				return 0uL;
			}
			return ReadUInt64(num * blockSize);
		}

		public void WriteUInt32VarLength(uint value, int blockSize)
		{
			blockSize = Maths.Clamp(blockSize, 2, 16);
			int num = (Maths.BitScanReverse(value) + blockSize) / blockSize;
			WriteUInt32((uint)(1 << num - 1), num);
			WriteUInt32(value, num * blockSize);
		}

		public void WriteUInt64VarLength(ulong value, int blockSize)
		{
			blockSize = Maths.Clamp(blockSize, 2, 16);
			int num = (Maths.BitScanReverse(value) + blockSize) / blockSize;
			WriteUInt32((uint)(1 << num - 1), num);
			WriteUInt64(value, num * blockSize);
		}

		public unsafe void WriteUInt32VarLength(uint value)
		{
			int num = 0;
			ulong value2 = 0uL;
			byte* ptr = (byte*)(&value2);
			while (true)
			{
				ptr[num] = (byte)(value & 0x7F);
				value >>= 7;
				if (value == 0)
				{
					break;
				}
				byte* num2 = ptr + num++;
				*num2 |= 0x80;
			}
			Write(value2, (num + 1) * 8);
		}

		public unsafe uint ReadUInt32VarLength()
		{
			Assert.Check(_offsetBits < _lengthBits);
			int num = _lengthBits - _offsetBits;
			if (num > 64)
			{
				num = 64;
			}
			ulong num2 = Peek(num);
			int num3 = 0;
			uint num4 = 0u;
			byte* ptr = (byte*)(&num2);
			while (true)
			{
				Assert.Check(num3 >= 0 && num3 <= 7);
				uint num5 = ptr[num3];
				num4 |= (num5 & 0x7F) << 7 * num3;
				if ((num5 & 0x80) != 128)
				{
					break;
				}
				num3++;
			}
			_offsetBits += (num3 + 1) * 8;
			return num4;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint ReadUInt32(int bits = 32)
		{
			Assert.Check(bits >= 0 && bits <= 32, bits);
			return (uint)Read(bits);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteInt64(long value, int bits = 64)
		{
			Assert.Check(bits >= 0 && bits <= 64);
			Write((ulong)value, bits);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long ReadInt64(int bits = 64)
		{
			Assert.Check(bits >= 0 && bits <= 64, bits);
			return (long)Read(bits);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUInt64(ulong value, int bits = 64)
		{
			Assert.Check(bits >= 0 && bits <= 64, bits);
			Write(value, bits);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ulong ReadUInt64(int bits = 64)
		{
			Assert.Check(bits >= 0 && bits <= 64, bits);
			return Read(bits);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteSingle(float value)
		{
			Write(*(uint*)(&value), 32);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe float ReadSingle()
		{
			ulong num = Read(32);
			return *(float*)(&num);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteDouble(double value)
		{
			Write(*(ulong*)(&value), 64);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe double ReadDouble()
		{
			ulong num = Read(64);
			return *(double*)(&num);
		}

		public void WriteInt32AtOffset(int value, int offset, int bits)
		{
			int offsetBits = _offsetBits;
			try
			{
				_offsetBits = offset;
				WriteSlow((uint)value, bits);
			}
			finally
			{
				_offsetBits = offsetBits;
			}
		}

		public void WriteUInt64AtOffset(ulong value, int offset, int bits)
		{
			int offsetBits = _offsetBits;
			try
			{
				_offsetBits = offset;
				WriteSlow(value, bits);
			}
			finally
			{
				_offsetBits = offsetBits;
			}
		}

		public unsafe void Write(ulong value, int bits)
		{
			Assert.Check(bits >= 0 && bits <= 64, bits);
			value &= ulong.MaxValue >> 64 - bits;
			Assert.Check(bits >= 0 && bits <= 64);
			int num = Advance(bits, writing: true);
			int num2 = num & 0x3F;
			int num3 = 64 - num2;
			Assert.Check(num2 + num3 == 64);
			ulong* ptr = _data + (num >> 6);
			bool arg = false;
			*ptr = (*ptr & (ulong)((1L << num2) - 1)) | (value << num2);
			if (num3 < bits)
			{
				arg = true;
				ptr[1] = value >> num3;
			}
			_offsetBits = num;
			ulong num4 = Read(bits);
			Assert.Check(num4 == value, num4, value, arg);
		}

		public unsafe void WriteSlow(ulong value, int bits)
		{
			Assert.Check(bits >= 0 && bits <= 64, bits);
			if (bits > 0)
			{
				value &= ulong.MaxValue >> 64 - bits;
				int num = Advance(bits, writing: false);
				int num2 = num >> 6;
				int num3 = num & 0x3F;
				int num4 = 64 - num3;
				int num5 = num4 - bits;
				ulong* data = _data;
				if (num5 >= 0)
				{
					ulong num6 = (ulong.MaxValue >> num4) | (ulong)(-1L << 64 - num5);
					data[num2] = (data[num2] & num6) | (value << num3);
				}
				else
				{
					data[num2] = (data[num2] & (ulong.MaxValue >> num4)) | (value << num3);
					data[num2 + 1] = (data[num2 + 1] & (ulong)(-1L << bits - num4)) | (value >> num4);
				}
			}
		}

		private unsafe ulong Read(int bits)
		{
			Assert.Check(bits >= 0 && bits <= 64, bits);
			if (bits <= 0)
			{
				return 0uL;
			}
			int num = Advance(bits, writing: false);
			int num2 = num >> 6;
			int num3 = num & 0x3F;
			ulong num4 = _data[num2] >> num3;
			int num5 = bits - (64 - num3);
			ulong result;
			if (num5 < 1)
			{
				result = num4 & (ulong.MaxValue >> 64 - bits);
			}
			else
			{
				ulong num6 = _data[num2 + 1] & (ulong.MaxValue >> 64 - num5);
				result = num4 | (num6 << bits - num5);
			}
			return result;
		}

		private unsafe ulong Peek(int bits)
		{
			Assert.Check(bits >= 0 && bits <= 64, bits);
			if (bits <= 0)
			{
				return 0uL;
			}
			if (!CheckBitCount(bits))
			{
				throw new InvalidOperationException($"Out of bounds. Bit position: {_offsetBits}, length: {bits}, capacity: {LengthBits}");
			}
			int offsetBits = _offsetBits;
			int num = offsetBits >> 6;
			int num2 = offsetBits & 0x3F;
			ulong num3 = _data[num] >> num2;
			int num4 = bits - (64 - num2);
			ulong result;
			if (num4 < 1)
			{
				result = num3 & (ulong.MaxValue >> 64 - bits);
			}
			else
			{
				ulong num5 = _data[num + 1] & (ulong.MaxValue >> 64 - num4);
				result = num3 | (num5 << bits - num4);
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal int Advance(int bits, bool writing)
		{
			int offsetBits = _offsetBits;
			_offsetBits += bits;
			if (_offsetBits > LengthBits)
			{
				if (!writing)
				{
					throw new InvalidOperationException($"Tried to read out of bounds, position: {offsetBits}, reading: {bits}, capacity: {LengthBits}");
				}
				ReplaceDataFromBlockWithTemp(LengthBytes * 2);
			}
			return offsetBits;
		}

		void ILogDumpable.Dump(StringBuilder builder)
		{
			builder.Append($"[Offset: {OffsetBits}]");
		}
	}
	internal struct NetBitBufferBlock
	{
		private int _packetSize;

		private IntPtr _freeHead;

		private unsafe NetBitBufferBlock* _self;

		private unsafe NetBitBuffer* _allocatedHead;

		public unsafe static void Dispose(ref NetBitBufferBlock* block)
		{
			if (block != null)
			{
				NetBitBuffer* memory = block->_allocatedHead;
				while (memory != null)
				{
					Assert.Check(memory->_block == block);
					NetBitBuffer* allocNext = memory->_allocNext;
					memory->_block = null;
					Native.Free(ref memory);
					memory = allocNext;
				}
				Native.Free(ref block);
			}
		}

		public unsafe static NetBitBufferBlock* Create(int packetSize)
		{
			NetBitBufferBlock* ptr = Native.MallocAndClear<NetBitBufferBlock>();
			ptr->_self = ptr;
			ptr->_freeHead = default(IntPtr);
			ptr->_packetSize = packetSize;
			return ptr;
		}

		public unsafe void Release(NetBitBuffer* ptr)
		{
			Assert.Check(ptr->_block == _self);
			IntPtr freeHead;
			do
			{
				freeHead = _freeHead;
				ptr->Next = (NetBitBuffer*)(void*)freeHead;
			}
			while (Interlocked.CompareExchange(ref _freeHead, (IntPtr)ptr, freeHead) != freeHead);
		}

		public unsafe NetBitBuffer* TryAcquire()
		{
			if (TryAcquire(out var ptr))
			{
				return ptr;
			}
			return null;
		}

		public unsafe bool TryAcquire(out NetBitBuffer* ptr)
		{
			IntPtr intPtr;
			do
			{
				intPtr = Volatile.Read(ref _freeHead);
				if (intPtr == IntPtr.Zero)
				{
					NetBitBuffer* ptr2 = NetBitBuffer.Allocate(0, _packetSize);
					ptr2->_block = _self;
					ptr2->_allocNext = _allocatedHead;
					_allocatedHead = ptr2;
					intPtr = new IntPtr(ptr2);
					break;
				}
			}
			while (Interlocked.CompareExchange(ref _freeHead, (IntPtr)((NetBitBuffer*)(void*)intPtr)->Next, intPtr) != intPtr);
			ptr = (NetBitBuffer*)(void*)intPtr;
			Assert.Check(ptr->_block == _self);
			ptr->SetBufferLengthBytes(ptr->Data, _packetSize);
			Native.MemClear(ptr->Data, _packetSize);
			ptr->OffsetBits = 0;
			ptr->_block = _self;
			return true;
		}
	}
	internal struct NetBitBufferList
	{
		public int Count;

		public unsafe NetBitBuffer* Head;

		public unsafe NetBitBuffer* Tail;

		public unsafe void AddFirst(NetBitBuffer* item)
		{
			Assert.Check(!IsInList(item));
			item->Next = Head;
			item->Prev = null;
			if (Head != null)
			{
				Head->Prev = item;
				Head = item;
			}
			else
			{
				Head = item;
				Tail = item;
			}
			Count++;
		}

		public unsafe void AddLast(NetBitBuffer* item)
		{
			Assert.Check(!IsInList(item));
			item->Next = null;
			item->Prev = Tail;
			if (Tail != null)
			{
				Tail->Next = item;
				Tail = item;
			}
			else
			{
				Head = item;
				Tail = item;
			}
			Count++;
		}

		public unsafe NetBitBuffer* RemoveHead()
		{
			Assert.Check(Count > 0);
			Assert.Check(Head != null);
			Assert.Check(IsInList(Head));
			NetBitBuffer* head = Head;
			Remove(head);
			return head;
		}

		public unsafe void Remove(NetBitBuffer* item)
		{
			Assert.Check(IsInList(item));
			if (item->Prev != null)
			{
				item->Prev->Next = item->Next;
			}
			if (item->Next != null)
			{
				item->Next->Prev = item->Prev;
			}
			if (item == Tail)
			{
				Tail = item->Prev;
			}
			if (item == Head)
			{
				Head = item->Next;
			}
			item->Prev = null;
			item->Next = null;
			Count--;
		}

		private unsafe bool IsInList(NetBitBuffer* item)
		{
			for (NetBitBuffer* ptr = Head; ptr != null; ptr = ptr->Next)
			{
				if (ptr == item)
				{
					return true;
				}
			}
			return false;
		}
	}
	public struct NetBitBufferNull : INetBitWriteStream
	{
		private int _offsetBits;

		public int OffsetBits
		{
			get
			{
				return _offsetBits;
			}
			set
			{
				_offsetBits = value;
			}
		}

		public void PadToByteBoundary()
		{
			if (_offsetBits % 8 != 0)
			{
				WriteByte(0, 8 - _offsetBits % 8);
			}
		}

		public void WriteByte(byte value, int bits = 8)
		{
			_offsetBits += bits;
		}

		public void WriteInt32(int value, int bits = 32)
		{
			_offsetBits += bits;
		}

		public void WriteInt32VarLength(int value)
		{
			WriteUInt32VarLength((uint)value);
		}

		public void WriteInt32VarLength(int value, int blockSize)
		{
			WriteUInt32VarLength((uint)value, blockSize);
		}

		public void WriteUInt32VarLength(uint value, int blockSize)
		{
			blockSize = Maths.Clamp(blockSize, 2, 16);
			int num = (Maths.BitScanReverse(value) + blockSize) / blockSize;
			_offsetBits += num + num * blockSize;
		}

		public void WriteUInt64VarLength(ulong value, int blockSize)
		{
			blockSize = Maths.Clamp(blockSize, 2, 16);
			int num = (Maths.BitScanReverse(value) + blockSize) / blockSize;
			_offsetBits += num + num * blockSize;
		}

		public void WriteUInt32VarLength(uint value)
		{
			int num = 0;
			while (true)
			{
				value >>= 7;
				if (value == 0)
				{
					break;
				}
				num++;
			}
			_offsetBits += (num + 1) * 8;
		}

		public bool WriteBoolean(bool b)
		{
			_offsetBits++;
			return b;
		}

		public unsafe void WriteBytesAligned(void* buffer, int length)
		{
			PadToByteBoundary();
			_offsetBits += length * 8;
		}

		public void WriteBytesAligned(Span<byte> buffer)
		{
			PadToByteBoundary();
			_offsetBits += buffer.Length * 8;
		}
	}
	public struct NetBitBufferSerializer
	{
		private bool _write;

		private unsafe NetBitBuffer* _buffer;

		public bool Writing => _write;

		public bool Reading => !_write;

		public unsafe NetBitBuffer* Buffer => _buffer;

		private unsafe NetBitBufferSerializer(NetBitBuffer* buffer, bool write)
		{
			_write = write;
			_buffer = buffer;
		}

		public unsafe static NetBitBufferSerializer Writer(NetBitBuffer* buffer)
		{
			return new NetBitBufferSerializer(buffer, write: true);
		}

		public unsafe static NetBitBufferSerializer Reader(NetBitBuffer* buffer)
		{
			return new NetBitBufferSerializer(buffer, write: false);
		}

		public unsafe bool Check(bool value)
		{
			if (_write)
			{
				return _buffer->WriteBoolean(value);
			}
			return _buffer->ReadBoolean();
		}

		public unsafe void Serialize(ref float value)
		{
			if (_write)
			{
				_buffer->WriteSingle(value);
			}
			else
			{
				value = _buffer->ReadSingle();
			}
		}

		public unsafe void Serialize(ref byte value)
		{
			if (_write)
			{
				_buffer->WriteByte(value);
			}
			else
			{
				value = _buffer->ReadByte();
			}
		}

		public unsafe void Serialize(ref bool value)
		{
			if (_write)
			{
				_buffer->WriteBoolean(value);
			}
			else
			{
				value = _buffer->ReadBoolean();
			}
		}

		public unsafe void Serialize(ref int value)
		{
			if (_write)
			{
				_buffer->WriteInt32(value);
			}
			else
			{
				value = _buffer->ReadInt32();
			}
		}

		public unsafe void Serialize(ref uint value)
		{
			if (_write)
			{
				_buffer->WriteUInt32(value);
			}
			else
			{
				value = _buffer->ReadUInt32();
			}
		}

		public unsafe void Serialize(ref ulong value)
		{
			if (_write)
			{
				_buffer->WriteUInt64(value);
			}
			else
			{
				value = _buffer->ReadUInt64();
			}
		}

		public unsafe void Serialize(ref string value)
		{
			if (_write)
			{
				_buffer->WriteString(value, Encoding.UTF8);
			}
			else
			{
				value = _buffer->ReadString(Encoding.UTF8);
			}
		}
	}
	internal struct NetBitBufferStack
	{
		private int _capacity;

		public unsafe NetBitBuffer** Stack;

		public int Count;

		public unsafe bool TryPop(NetBitBuffer** result)
		{
			Assert.Check(Count >= 0);
			if (Count == 0)
			{
				return false;
			}
			*result = Stack[--Count];
			return true;
		}

		public unsafe static NetBitBufferStack Create(int capacity)
		{
			return new NetBitBufferStack
			{
				_capacity = capacity,
				Stack = Native.MallocAndClearPtrArray<NetBitBuffer>(capacity)
			};
		}

		public unsafe static void Dispose(ref NetBitBufferStack stack)
		{
			Native.Free(ref stack.Stack);
			stack.Count = 0;
			stack._capacity = 0;
		}

		public unsafe void PushFromHead(NetBitBuffer* head)
		{
			while (head != null)
			{
				NetBitBuffer* next = head->Next;
				head->Next = null;
				head->Prev = null;
				Assert.Check(Count >= 0 && Count <= _capacity);
				if (Count == _capacity)
				{
					try
					{
						Stack = Native.DoublePtrArray(Stack, _capacity);
					}
					catch (OutOfMemoryException)
					{
						InternalLogStreams.LogInfo?.Log($"OOM resize to _capacity:{_capacity}, Count:{Count}");
						throw;
					}
					_capacity *= 2;
				}
				Stack[Count++] = head;
				head = next;
			}
		}
	}
	internal enum NetCommands : byte
	{
		Connect = 1,
		Accepted,
		Refused,
		Disconnect,
		Ping
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct NetCommandHeader
	{
		public const int SIZE_BYTES = 2;

		public const int SIZE_BITS = 16;

		[FieldOffset(0)]
		public NetPacketType PacketType;

		[FieldOffset(1)]
		public NetCommands Command;

		public static NetCommandHeader Create(NetCommands command)
		{
			return new NetCommandHeader
			{
				PacketType = NetPacketType.Command,
				Command = command
			};
		}

		public static implicit operator NetCommandHeader(NetCommands commands)
		{
			return Create(commands);
		}
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct NetCommandConnect
	{
		public const int TOKEN_MAX_LENGTH_BYTES = 128;

		public const int UNIQUE_ID_LENGTH_BYTES = 8;

		public const int SIZE_BYTES = 152;

		public const int SIZE_BITS = 1216;

		[FieldOffset(0)]
		public NetCommandHeader Header;

		[FieldOffset(4)]
		public int TokenLength;

		[FieldOffset(8)]
		public NetConnectionId ConnectionId;

		[FieldOffset(16)]
		public unsafe fixed byte TokenData[128];

		[FieldOffset(144)]
		public unsafe fixed byte UniqueId[8];

		public static int ClampTokenLength(int tokenLength)
		{
			if (tokenLength < 0)
			{
				InternalLogStreams.LogWarn?.Log("Connection token length can't be negative");
			}
			if (tokenLength > 128)
			{
				InternalLogStreams.LogWarn?.Log($"Connection token length to large, truncated to {128} bytes.");
			}
			return Maths.Clamp(tokenLength, 0, 128);
		}

		public unsafe static byte[] GetTokenDataAsArray(NetCommandConnect command)
		{
			int num = ClampTokenLength(command.TokenLength);
			if (num == 0)
			{
				return null;
			}
			byte[] array = new byte[num];
			fixed (byte* destination = array)
			{
				Native.MemCpy(destination, command.TokenData, num);
			}
			return array;
		}

		public unsafe static byte[] GetUniqueIdAsArray(NetCommandConnect command)
		{
			byte[] array = new byte[8];
			fixed (byte* destination = array)
			{
				Native.MemCpy(destination, command.UniqueId, 8);
			}
			return array;
		}

		public unsafe static NetCommandConnect Create(NetConnectionId id, byte* token = null, int tokenLength = 0, byte* uniqueId = null)
		{
			tokenLength = ClampTokenLength(tokenLength);
			NetCommandConnect result = new NetCommandConnect
			{
				Header = NetCommands.Connect,
				ConnectionId = id,
				TokenLength = tokenLength
			};
			if (result.TokenLength > 0)
			{
				Assert.Check(token != null);
				Native.MemCpy(result.TokenData, token, result.TokenLength);
			}
			if (uniqueId != null)
			{
				Native.MemCpy(result.UniqueId, uniqueId, 8);
			}
			return result;
		}
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct NetCommandAccepted
	{
		[FieldOffset(0)]
		public NetCommandHeader Header;

		[FieldOffset(8)]
		public NetConnectionId AcceptedLocalId;

		[FieldOffset(16)]
		public NetConnectionId AcceptedRemoteId;

		[FieldOffset(24)]
		public uint Counter;

		public static NetCommandAccepted Create(NetConnectionId localId, NetConnectionId remoteId, uint counter)
		{
			return new NetCommandAccepted
			{
				Header = NetCommands.Accepted,
				AcceptedLocalId = localId,
				AcceptedRemoteId = remoteId,
				Counter = counter
			};
		}
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct NetCommandRefused
	{
		public const int SIZE_IN_BYTES = 3;

		public const int SIZE_IN_BITS = 24;

		[FieldOffset(0)]
		public NetCommandHeader Header;

		[FieldOffset(2)]
		public NetConnectFailedReason Reason;

		public static NetCommandRefused Create(NetConnectFailedReason reason)
		{
			return new NetCommandRefused
			{
				Header = NetCommands.Refused,
				Reason = reason
			};
		}
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct NetCommandDisconnect
	{
		public const int TOKEN_MAX_LENGTH_BYTES = 128;

		[FieldOffset(0)]
		public NetCommandHeader Header;

		[FieldOffset(2)]
		public NetDisconnectReason Reason;

		[FieldOffset(4)]
		public int TokenLength;

		[FieldOffset(8)]
		public unsafe fixed byte TokenData[128];

		public unsafe static NetCommandDisconnect Create(NetDisconnectReason reason, byte[] token)
		{
			int num = Math.Min(128, (token?.Length).GetValueOrDefault());
			NetCommandDisconnect result = new NetCommandDisconnect
			{
				Header = NetCommands.Disconnect,
				Reason = reason,
				TokenLength = num
			};
			for (int i = 0; i < num; i++)
			{
				result.TokenData[i] = token[i];
			}
			return result;
		}

		public unsafe static NetCommandDisconnect Create(NetDisconnectReason reason, byte* token, int tokenLength)
		{
			tokenLength = Math.Min(128, tokenLength);
			NetCommandDisconnect result = new NetCommandDisconnect
			{
				Header = NetCommands.Disconnect,
				Reason = reason,
				TokenLength = tokenLength
			};
			for (int i = 0; i < tokenLength; i++)
			{
				result.TokenData[i] = token[i];
			}
			return result;
		}
	}
	public struct NetConfig
	{
		public int ConnectionSendBuffers;

		public int ConnectionGroups;

		public int MaxConnections;

		public int SocketSendBuffer;

		public int SocketRecvBuffer;

		public int PacketSize;

		public int ConnectAttempts;

		public double ConnectInterval;

		public double OperationExpireTime;

		public double ConnectionDefaultRtt;

		public double ConnectionTimeout;

		public double ConnectionPingInterval;

		public double ConnectionShutdownTime;

		public NetAddress Address;

		public NetConfigNotify Notify;

		public NetConfigSimulation Simulation;

		public int ConnectionsPerGroup
		{
			get
			{
				int num = MaxConnections / ConnectionGroups;
				if (num * ConnectionGroups == MaxConnections)
				{
					return num;
				}
				return num + 1;
			}
		}

		public int PacketSizeInBits => PacketSize * 8;

		public static NetConfig Defaults
		{
			get
			{
				NetConfig result = default(NetConfig);
				result.ConnectionDefaultRtt = 0.1;
				result.ConnectionSendBuffers = 4;
				result.ConnectionGroups = 12;
				result.MaxConnections = 1000;
				result.SocketSendBuffer = 262144;
				result.SocketRecvBuffer = 262144;
				result.PacketSize = 1280;
				result.ConnectAttempts = 10;
				result.ConnectInterval = 0.5;
				result.ConnectionTimeout = 10.0;
				result.ConnectionPingInterval = 1.0;
				result.ConnectionShutdownTime = 1.0;
				result.OperationExpireTime = 3.0;
				result.Notify = NetConfigNotify.Defaults;
				result.Simulation = NetConfigSimulation.Defaults;
				result.Address = default(NetAddress);
				return result;
			}
		}
	}
	public struct NetConfigNotify
	{
		public int AckMaskBytes;

		public int AckForceCount;

		public double AckForceTimeout;

		public int WindowSize;

		public int SequenceBytes;

		public int SequenceBounds => WindowSize * 16;

		public int AckMaskBits => AckMaskBytes * 8;

		public static NetConfigNotify Defaults
		{
			get
			{
				NetConfigNotify result = default(NetConfigNotify);
				result.AckMaskBytes = 8;
				result.AckForceCount = 8;
				result.AckForceTimeout = 0.1;
				result.WindowSize = 128;
				result.SequenceBytes = 2;
				return result;
			}
		}
	}
	public struct NetConfigSimulation
	{
		public unsafe short* LossNotifySequences;

		public int LossNotifySequencesLength;

		public NetConfigSimulationOscillator DelayOscillator;

		public NetConfigSimulationOscillator LossOscillator;

		public double DuplicateChance;

		public unsafe static NetConfigSimulation Defaults
		{
			get
			{
				NetConfigSimulation result = default(NetConfigSimulation);
				result.LossNotifySequences = default(short*);
				result.LossNotifySequencesLength = 0;
				result.DuplicateChance = 0.0;
				result.DelayOscillator = default(NetConfigSimulationOscillator);
				result.LossOscillator = default(NetConfigSimulationOscillator);
				return result;
			}
		}

		public unsafe static NetConfigSimulation WithLossNotifySequences(params short[] sequences)
		{
			NetConfigSimulation defaults = Defaults;
			if (sequences.Length != 0)
			{
				defaults.LossNotifySequencesLength = sequences.Length;
				defaults.LossNotifySequences = Native.MallocAndClearArray<short>(sequences.Length);
				for (int i = 0; i < sequences.Length; i++)
				{
					defaults.LossNotifySequences[i] = sequences[i];
				}
			}
			return defaults;
		}
	}
	public struct NetConfigSimulationOscillator
	{
		public enum WaveShape
		{
			Noise,
			Sine,
			Square,
			Triangle,
			Saw,
			ReverseSaw
		}

		public WaveShape Shape;

		public double Min;

		public double Max;

		public double Period;

		public double Threshold;

		public double Additional;

		public double GetCurveValue(Random rng, double elapsedSecs)
		{
			double num;
			if (Period == 0.0 && Shape != WaveShape.Noise)
			{
				num = Min + (Max - Min) * 0.5;
			}
			else if (Min == Max)
			{
				num = Min;
			}
			else
			{
				double num2 = Shape switch
				{
					WaveShape.Noise => rng.NextDouble(), 
					WaveShape.Sine => Math.Sin(elapsedSecs * 2.0 * Math.PI / Period) * 0.5 + 0.5, 
					WaveShape.Square => (elapsedSecs / Period % 1.0 > 0.5) ? 1 : 0, 
					WaveShape.Triangle => Math.Abs(elapsedSecs / Period % 1.0 * 2.0 - 1.0), 
					WaveShape.Saw => elapsedSecs / Period % 1.0, 
					WaveShape.ReverseSaw => 1.0 - elapsedSecs / Period % 1.0, 
					_ => 0.0, 
				};
				num2 = ((num2 > Threshold) ? num2 : 0.0);
				num = Min + (Max - Min) * num2;
			}
			double num3 = Additional * (rng.NextDouble() - 0.5);
			return num + num3;
		}
	}
	public enum NetConnectFailedReason : byte
	{
		Timeout = 1,
		ServerFull,
		ServerRefused
	}
	public struct NetConnection
	{
		internal struct StateConnectingData
		{
			public int Attempts;

			public double AttemptTimeout;
		}

		internal struct StateShutdownData
		{
			public double Timeout;

			public int Unmapped;
		}

		internal struct StateDisconnectedData
		{
			public NetDisconnectReason Reason;

			public int CallbackInvoked;

			public int SentDisconnectCommand;
		}

		internal const byte UNIQUE_ID_SIZE = 8;

		internal ulong MapHash;

		internal unsafe NetConnection* MapNext;

		internal NetConnectionMap.EntryState MapState;

		internal NetConnectionId LocalId;

		internal NetConnectionId RemoteId;

		internal NetAddress Address;

		internal NetConnectionStatus Status;

		internal double Rtt;

		internal double SendTime;

		internal double RecvTime;

		internal StateConnectingData StateConnecting;

		internal StateDisconnectedData StateDisconnected;

		internal StateShutdownData StateShutdown;

		internal NetSendEnvelopeRingBuffer NotifySendWindow;

		internal NetSequencer NotifySendSequencer;

		internal double NotifySendTime;

		internal double NotifyRecvAckTime;

		internal int NotifyRecvAckOutdatedCount;

		internal double NotifyRecvTime;

		internal ulong NotifyRecvMask;

		internal ushort NotifyRecvSequence;

		internal int NotifyRecvUnackedCount;

		internal int NotifyRecvFragment;

		internal unsafe byte* NotifyRecvFragmentBuffer;

		internal int NotifyRecvFragmentBufferLength;

		internal int NotifyRecvFragmentSequenceDistance;

		internal unsafe byte* ConnectionToken;

		internal int ConnectionTokenLength;

		internal unsafe byte* DisconnectToken;

		internal int DisconnectTokenLength;

		internal long UniqueIdHash;

		internal unsafe byte* UniqueId;

		internal uint Counter;

		internal ReliableBuffer ReliableBuffer;

		internal ReliableList ReliableSendList;

		internal TimerDelta ReliableSendTimer;

		public bool Active => MapState == NetConnectionMap.EntryState.Used;

		public double RoundTripTime => Rtt;

		public NetAddress RemoteAddress => Address;

		public NetConnectionStatus ConnectionStatus => Status;

		public NetConnectionId LocalConnectionId => LocalId;

		public NetConnectionId RemoteConnectionId => RemoteId;

		internal unsafe static ushort NextNotifySendSequence(NetConnection* c)
		{
			ulong num = c->NotifySendSequencer.Next();
			Assert.Check(num <= 65535);
			return (ushort)num;
		}

		internal unsafe static void Initialize(NetConnection* c, short group, short index, NetConfig* config)
		{
			c->LocalId.Group = group;
			c->LocalId.GroupIndex = index;
			c->NotifySendWindow = NetSendEnvelopeRingBuffer.Create(config->Notify.WindowSize);
			c->NotifySendSequencer = new NetSequencer(config->Notify.SequenceBytes);
			c->NotifyRecvFragmentBuffer = (byte*)Native.MallocAndClear(51200);
			c->NotifyRecvFragmentBufferLength = 0;
			c->NotifyRecvFragment = 0;
			Reset(c);
		}

		internal unsafe static void SetRtt(NetConnection* c, double rtt = 0.0)
		{
			c->Rtt = rtt;
		}

		internal unsafe static void Reset(NetConnection* c)
		{
			Assert.Check(c->NotifySendWindow.Count == 0);
			c->LocalId.Generation++;
			if (c->LocalId.Generation == 0)
			{
				c->LocalId.Generation++;
			}
			Native.Free(ref c->ConnectionToken);
			c->ConnectionTokenLength = 0;
			Native.Free(ref c->DisconnectToken);
			c->DisconnectTokenLength = 0;
			Native.Free(ref c->UniqueId);
			c->UniqueIdHash = 0L;
			c->ReliableSendList.Dispose();
			c->ReliableSendTimer = TimerDelta.StartNew();
			c->ReliableBuffer.Dispose();
			c->ReliableBuffer = ReliableBuffer.Create();
			c->Address = default(NetAddress);
			c->NotifySendWindow.Reset();
			c->NotifySendSequencer.Reset();
			c->Status = (NetConnectionStatus)0;
			c->StateShutdown = default(StateShutdownData);
			c->StateConnecting = default(StateConnectingData);
			c->StateDisconnected = default(StateDisconnectedData);
			c->RemoteId = default(NetConnectionId);
			c->MapState = NetConnectionMap.EntryState.None;
			c->UniqueId = null;
			c->UniqueIdHash = 0L;
			c->SendTime = 0.0;
			c->RecvTime = 0.0;
			c->Rtt = 0.0;
			c->NotifySendTime = 0.0;
			c->NotifyRecvTime = 0.0;
			c->NotifyRecvMask = 0uL;
			c->NotifyRecvAckTime = 0.0;
			c->NotifyRecvSequence = 0;
			c->NotifyRecvUnackedCount = 0;
			c->NotifyRecvAckOutdatedCount = 0;
			c->NotifyRecvFragment = 0;
			c->NotifyRecvFragmentBufferLength = 0;
			c->NotifyRecvFragmentSequenceDistance = 0;
		}

		public override string ToString()
		{
			return string.Format("[{0}: {1}={2}, {3}={4}]", "NetConnection", "RemoteAddress", RemoteAddress, "UniqueId", UniqueIdHash);
		}
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct NetConnectionId : IEquatable<NetConnectionId>
	{
		public class EqualityComparer : IEqualityComparer<NetConnectionId>
		{
			public bool Equals(NetConnectionId x, NetConnectionId y)
			{
				return x.Raw == y.Raw;
			}

			public int GetHashCode(NetConnectionId obj)
			{
				return obj.Raw.GetHashCode();
			}
		}

		[FieldOffset(0)]
		internal ulong Raw;

		[FieldOffset(0)]
		public short Group;

		[FieldOffset(2)]
		public short GroupIndex;

		[FieldOffset(4)]
		internal uint Generation;

		public bool Equals(NetConnectionId other)
		{
			return Raw == other.Raw;
		}

		public override bool Equals(object obj)
		{
			return obj is NetConnectionId other && Equals(other);
		}

		public override int GetHashCode()
		{
			return Raw.GetHashCode();
		}

		public static bool operator ==(NetConnectionId a, NetConnectionId b)
		{
			return a.Raw == b.Raw;
		}

		public static bool operator !=(NetConnectionId a, NetConnectionId b)
		{
			return a.Raw != b.Raw;
		}

		public override string ToString()
		{
			return $"[NetConnectionId Group:{Group}, GroupIndex:{GroupIndex}, Generation:{Generation}]";
		}
	}
	public struct NetConnectionMap
	{
		public enum EntryState
		{
			None,
			Free,
			Used
		}

		private struct UniqueIdMapping
		{
			public long UniqueId;

			public short Index;
		}

		public struct Iterator
		{
			private unsafe NetConnectionMap* _map;

			private int _index;

			private int _count;

			public unsafe NetConnection* Current => IsValid ? (_map->Connections + _index) : null;

			public bool IsValid => _index >= 0 && _index < _count;

			public unsafe Iterator(NetConnectionMap* map)
			{
				_map = map;
				_index = -1;
				_count = (int)_map->UsedCount;
			}

			public unsafe bool Next()
			{
				while (++_index < _count)
				{
					if (_map->Connections[_index].MapState == EntryState.Used && _map->Connections[_index].Status < NetConnectionStatus.Disconnected)
					{
						return true;
					}
				}
				return false;
			}
		}

		private unsafe NetConnection** Buckets;

		private unsafe NetConnection* FreeHead;

		internal unsafe NetConnection* Connections;

		private unsafe UniqueIdMapping* UniqueIdHashes;

		private short Group;

		private ulong UsedCount;

		private ulong FreeCount;

		private ulong IdsCount;

		private ulong CapacityAllocated;

		internal ulong CapacityUsable;

		public int Count => (int)(UsedCount - FreeCount);

		public int CountUsed => (int)UsedCount;

		public unsafe NetConnection* ConnectionsBuffer => Connections;

		public bool Full => UsedCount == CapacityAllocated;

		public unsafe static void Dispose(ref NetConnectionMap* map, INetPeerGroupCallbacks callbacks)
		{
			if (map == null)
			{
				return;
			}
			for (int i = 0; i < (int)map->CapacityUsable; i++)
			{
				NetConnection* ptr = map->Connections + i;
				while (ptr->NotifySendWindow.Count > 0)
				{
					NetSendEnvelope envelope = ptr->NotifySendWindow.Peek();
					ptr->NotifySendWindow.Pop();
					callbacks.OnNotifyDispose(ref envelope);
				}
				ptr->NotifySendWindow.Dispose();
				Native.Free(ref ptr->NotifyRecvFragmentBuffer);
				Native.Free(ref ptr->ConnectionToken);
				ptr->ConnectionTokenLength = 0;
				Native.Free(ref ptr->UniqueId);
				ptr->UniqueIdHash = 0L;
				ptr->ReliableSendList.Dispose();
				ptr->ReliableBuffer.Dispose();
			}
			Native.Free(ref map);
		}

		public unsafe static NetConnectionMap* Allocate(int capacity, short groupIndex, in NetConfig* config)
		{
			Assert.Check(capacity >= 0);
			int nextPrime = Primes.GetNextPrime(capacity);
			int num = Native.RoundToMaxAlignment(sizeof(NetConnectionMap));
			int num2 = Native.RoundToMaxAlignment(sizeof(NetConnection*) * nextPrime);
			int num3 = Native.RoundToMaxAlignment(sizeof(NetConnection) * nextPrime);
			int num4 = Native.RoundToMaxAlignment(sizeof(UniqueIdMapping) * nextPrime);
			byte* ptr = (byte*)Native.MallocAndClear(num + num2 + num3 + num4);
			NetConnectionMap* ptr2 = (NetConnectionMap*)ptr;
			ptr2->Buckets = (NetConnection**)(ptr + num);
			ptr2->Connections = (NetConnection*)(ptr + num + num2);
			ptr2->UniqueIdHashes = (UniqueIdMapping*)(ptr + num + num2 + num3);
			ptr2->Group = groupIndex;
			ptr2->UsedCount = 0uL;
			ptr2->FreeCount = 0uL;
			ptr2->IdsCount = 0uL;
			ptr2->CapacityAllocated = (ulong)nextPrime;
			ptr2->CapacityUsable = (ulong)capacity;
			for (int i = 0; i < nextPrime; i++)
			{
				ptr2->UniqueIdHashes[i] = default(UniqueIdMapping);
			}
			for (short num5 = 0; num5 < capacity; num5++)
			{
				NetConnection.Initialize(ptr2->Connections + num5, groupIndex, num5, config);
			}
			return ptr2;
		}

		public unsafe NetConnection* Remap(NetAddress oldAddress, NetAddress newAddress)
		{
			ulong num = NetAddress.Hash64(oldAddress);
			ulong num2 = NetAddress.Hash64(newAddress);
			ulong num3 = num % CapacityAllocated;
			NetConnection* ptr = Buckets[num3];
			NetConnection* ptr2 = default(NetConnection*);
			ulong num4 = num2 % CapacityAllocated;
			while (ptr != null)
			{
				if (ptr->MapHash == num && ptr->Address.Block0 == oldAddress.Block0 && ptr->Address.Block1 == oldAddress.Block1 && ptr->Address.Block2 == oldAddress.Block2)
				{
					Assert.Check(ptr->MapState == EntryState.Used);
					if (ptr2 == null)
					{
						Buckets[num3] = ptr->MapNext;
					}
					else
					{
						ptr2->MapNext = ptr->MapNext;
					}
					ptr->Address = newAddress;
					ptr->MapHash = num2;
					ptr->MapNext = Buckets[num4];
					Buckets[num4] = ptr;
					return ptr;
				}
				ptr2 = ptr;
				ptr = ptr->MapNext;
			}
			Assert.AlwaysFail($"Remap failed from {oldAddress} to {newAddress}");
			return null;
		}

		public unsafe bool Remove(NetAddress address)
		{
			ulong num = NetAddress.Hash64(address);
			ulong num2 = num % CapacityAllocated;
			NetConnection* ptr = Buckets[num2];
			NetConnection* ptr2 = default(NetConnection*);
			while (ptr != null)
			{
				if (ptr->MapHash == num && ptr->Address.Block0 == address.Block0 && ptr->Address.Block1 == address.Block1 && ptr->Address.Block2 == address.Block2)
				{
					if (ptr2 == null)
					{
						Buckets[num2] = ptr->MapNext;
					}
					else
					{
						ptr2->MapNext = ptr->MapNext;
					}
					Assert.Check(ptr->MapState == EntryState.Used);
					RemoveUniqueId(ptr->UniqueIdHash);
					NetConnection.Reset(ptr);
					ptr->MapNext = FreeHead;
					ptr->MapState = EntryState.Free;
					FreeHead = ptr;
					FreeCount++;
					return true;
				}
				ptr2 = ptr;
				ptr = ptr->MapNext;
			}
			return false;
		}

		public unsafe NetConnection* Insert(NetAddress address, byte[] uniqueId)
		{
			Assert.Check(Find(address) == null);
			Assert.Check(!address.Equals(default(NetAddress)));
			long num = BitConverter.ToInt64(uniqueId, 0);
			if (ContainsUniqueId(num, out var groupIndex))
			{
				NetAddress address2 = FindByIndex(groupIndex)->Address;
				NetConnection* ptr = Remap(address2, address);
				StoreUniqueId(num, ptr->LocalId.GroupIndex);
				InternalLogStreams.LogDebug?.Log($"UniqueId ({num}) already used. Update connection address from {address2} to {address}");
				return null;
			}
			ulong num2 = NetAddress.Hash64(address);
			ulong num3 = num2 % CapacityAllocated;
			NetConnection* ptr2;
			if (FreeHead != null)
			{
				Assert.Check(FreeCount != 0);
				ptr2 = FreeHead;
				FreeHead = ptr2->MapNext;
				FreeCount--;
				Assert.Check(ptr2->MapState == EntryState.Free);
			}
			else
			{
				if (UsedCount == CapacityUsable)
				{
					return null;
				}
				ptr2 = Connections + UsedCount++;
				Assert.Check(ptr2->MapState == EntryState.None);
				Assert.Check(ptr2->MapNext == null);
			}
			Assert.Check(ptr2 == Connections + ptr2->LocalId.GroupIndex);
			ptr2->Address = address;
			ptr2->MapHash = num2;
			ptr2->MapState = EntryState.Used;
			ptr2->MapNext = Buckets[num3];
			if (ptr2->UniqueId == null)
			{
				ptr2->UniqueId = (byte*)Native.MallocAndClear(uniqueId.Length);
			}
			ptr2->UniqueIdHash = num;
			fixed (byte* source = uniqueId)
			{
				Native.MemCpy(ptr2->UniqueId, source, 8);
			}
			StoreUniqueId(num, ptr2->LocalId.GroupIndex);
			Buckets[num3] = ptr2;
			return ptr2;
		}

		public unsafe NetConnection* FindByIndex(int index)
		{
			if (index >= 0 && index < (int)CapacityUsable)
			{
				return Connections + index;
			}
			throw new IndexOutOfRangeException();
		}

		public unsafe bool TryFindByIndex(int index, out NetConnection* connection)
		{
			if (index >= 0 && index < (int)CapacityUsable)
			{
				connection = Connections + index;
				return true;
			}
			connection = null;
			return false;
		}

		public unsafe NetConnection* Find(NetConnectionId id)
		{
			Assert.Check(Group == id.Group);
			NetConnection* ptr = Connections + id.GroupIndex;
			if (ptr->LocalId.Raw == id.Raw)
			{
				return ptr;
			}
			return null;
		}

		public unsafe NetConnection* Find(NetAddress address)
		{
			ulong num = NetAddress.Hash64(address);
			ulong num2 = num % CapacityAllocated;
			for (NetConnection* ptr = Buckets[num2]; ptr != null; ptr = ptr->MapNext)
			{
				if (ptr->MapHash == num && ptr->Address.Block0 == address.Block0 && ptr->Address.Block1 == address.Block1 && ptr->Address.Block2 == address.Block2)
				{
					return ptr;
				}
			}
			return null;
		}

		private unsafe bool ContainsUniqueId(long value, out short groupIndex)
		{
			groupIndex = -1;
			ulong num = FindInsertionIndex(value);
			if (num < IdsCount && UniqueIdHashes[num].UniqueId == value)
			{
				groupIndex = UniqueIdHashes[num].Index;
				return true;
			}
			return false;
		}

		private unsafe void StoreUniqueId(long value, short groupIndex)
		{
			ulong num = FindInsertionIndex(value);
			if (UniqueIdHashes[num].UniqueId == value)
			{
				UniqueIdHashes[num].Index = groupIndex;
				return;
			}
			Native.MemMove(UniqueIdHashes + num + 1, UniqueIdHashes + num, (int)(IdsCount - num) * sizeof(UniqueIdMapping));
			UniqueIdHashes[num].UniqueId = value;
			UniqueIdHashes[num].Index = groupIndex;
			Assert.Check(IdsCount + 1 <= CapacityUsable, "Unique Ids count exceeds capacity");
			IdsCount++;
		}

		private unsafe bool RemoveUniqueId(long value)
		{
			ulong num = FindInsertionIndex(value);
			if (num >= IdsCount || UniqueIdHashes[num].UniqueId != value)
			{
				return false;
			}
			Native.MemMove(UniqueIdHashes + num, UniqueIdHashes + num + 1, (int)(IdsCount - num - 1) * sizeof(UniqueIdMapping));
			Assert.Check(IdsCount != 0, "Unique Ids count is already 0");
			IdsCount--;
			return true;
		}

		private unsafe ulong FindInsertionIndex(long value)
		{
			ulong num = 0uL;
			ulong num2 = IdsCount;
			while (num < num2)
			{
				ulong num3 = (num + num2) / 2;
				if (UniqueIdHashes[num3].UniqueId < value)
				{
					num = num3 + 1;
				}
				else
				{
					num2 = num3;
				}
			}
			return num;
		}
	}
	public enum NetConnectionStatus
	{
		Created = 1,
		Connecting,
		Connected,
		Disconnected,
		Shutdown
	}
	internal static class NetConstants
	{
		public const int FALSE = 0;

		public const int TRUE = 1;
	}
	internal struct NetDelayedPacket
	{
		public unsafe NetDelayedPacket* Prev;

		public unsafe NetDelayedPacket* Next;

		public double DeliveryTime;

		public NetAddress Address;

		public unsafe byte* Data;

		public int DataLength;

		public unsafe static NetDelayedPacket* Create(int dataLength)
		{
			int num = Native.RoundToMaxAlignment(sizeof(NetDelayedPacket));
			int num2 = Native.RoundToMaxAlignment(dataLength);
			byte* ptr = (byte*)Native.MallocAndClear(num + num2);
			NetDelayedPacket* ptr2 = (NetDelayedPacket*)ptr;
			ptr2->Data = ptr + num;
			ptr2->DataLength = dataLength;
			return ptr2;
		}

		public unsafe static void Dispose(ref NetDelayedPacket* delayed)
		{
			Native.Free(ref delayed);
		}
	}
	internal struct NetDelayedPacketList
	{
		public int Count;

		public unsafe NetDelayedPacket* Head;

		public unsafe NetDelayedPacket* Tail;

		public unsafe void AddFirst(NetDelayedPacket* item)
		{
			Assert.Check(!IsInList(item));
			item->Next = Head;
			item->Prev = null;
			if (Head != null)
			{
				Head->Prev = item;
				Head = item;
			}
			else
			{
				Head = item;
				Tail = item;
			}
			Count++;
		}

		public unsafe void AddLast(NetDelayedPacket* item)
		{
			Assert.Check(!IsInList(item));
			item->Next = null;
			item->Prev = Tail;
			if (Tail != null)
			{
				Tail->Next = item;
				Tail = item;
			}
			else
			{
				Head = item;
				Tail = item;
			}
			Count++;
		}

		public unsafe NetDelayedPacket* RemoveHead()
		{
			Assert.Check(Count > 0);
			Assert.Check(Head != null);
			Assert.Check(IsInList(Head));
			NetDelayedPacket* head = Head;
			Remove(head);
			return head;
		}

		public unsafe void Remove(NetDelayedPacket* item)
		{
			Assert.Check(IsInList(item));
			if (item->Prev != null)
			{
				item->Prev->Next = item->Next;
			}
			if (item->Next != null)
			{
				item->Next->Prev = item->Prev;
			}
			if (item == Tail)
			{
				Tail = item->Prev;
			}
			if (item == Head)
			{
				Head = item->Next;
			}
			item->Prev = null;
			item->Next = null;
			Count--;
		}

		private unsafe bool IsInList(NetDelayedPacket* item)
		{
			for (NetDelayedPacket* ptr = Head; ptr != null; ptr = ptr->Next)
			{
				if (ptr == item)
				{
					return true;
				}
			}
			return false;
		}

		public unsafe void Dispose()
		{
			while (Count > 0)
			{
				NetDelayedPacket* memory = RemoveHead();
				Native.Free(ref memory);
			}
			Assert.Check(Head == null);
			Assert.Check(Tail == null);
		}
	}
	public enum NetDisconnectReason : byte
	{
		Unknown = 1,
		Timeout,
		Requested,
		SequenceOutOfBounds,
		SendWindowFull,
		ByRemote
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct NetNotifyHeader
	{
		public const int SIZE_IN_BYTES = 14;

		public const int SIZE_IN_BITS = 112;

		[FieldOffset(0)]
		public NetPacketType PacketType;

		[FieldOffset(1)]
		public byte Fragment;

		[FieldOffset(2)]
		public ushort Sequence;

		[FieldOffset(4)]
		public ushort AckSequence;

		[FieldOffset(6)]
		public ulong AckMask;

		public unsafe override string ToString()
		{
			ulong ackMask = AckMask;
			return $"[Type: {PacketType} Frag:{Fragment} Seq:{Sequence}, AckSeq:{AckSequence}, AckMask:{Maths.PrintBits((byte*)(&ackMask), 8)}]";
		}

		public static NetNotifyHeader CreateData(ushort sequence, ushort ackSequence, ulong ackMask)
		{
			NetNotifyHeader result = default(NetNotifyHeader);
			result.PacketType = NetPacketType.NotifyData;
			result.Sequence = sequence;
			result.AckSequence = ackSequence;
			result.AckMask = ackMask;
			result.Fragment = 0;
			return result;
		}

		public static NetNotifyHeader CreateAcks(ushort ackSequence, ulong ackMask)
		{
			NetNotifyHeader result = default(NetNotifyHeader);
			result.PacketType = NetPacketType.NotifyAcks;
			result.Sequence = 0;
			result.AckSequence = ackSequence;
			result.AckMask = ackMask;
			result.Fragment = 0;
			return result;
		}
	}
	internal enum NetPacketType : byte
	{
		Command = 1,
		UnreliableData,
		NotifyData,
		NotifyAcks,
		Unconnected,
		MtuDiscoveryReq,
		MtuDiscoveryRep,
		NotifyReliableData
	}
	public struct NetPeer
	{
		public const int DEFAULT_HEADERS = 144;

		public const int MAX_MTU_BYTES_TOTAL = 1280;

		public const int MAX_MTU_BYTES_PAYLOAD = 1136;

		public const int MAX_MTU_BITS_PAYLOAD = 9088;

		public const int MAX_PACKET_BYTES_PAYLOAD = 44880;

		public const int MAX_PACKET_BYTES_TOTAL = 51200;

		internal const int FRAG_MAX_COUNT = 40;

		internal const byte FRAG_END_BIT = 128;

		private const int STATE_RUNNING = 0;

		private const int STATE_SHUTDOWN = 2;

		private volatile int _state;

		private NetConfig _config;

		private Timer _recvTimer;

		private unsafe byte* _fragmentBuffer;

		internal NetSocket _socket;

		private NetAddress _address;

		private NetBitBufferStack _sendStack;

		private unsafe NetPeerGroup* _groups;

		private unsafe NetPeerGroupMap* _groupsMap;

		private unsafe int* _groupsAssigned;

		private unsafe NetCommandRefused* _refusedCommand;

		private unsafe NetBitBuffer* _recv;

		private unsafe NetBitBufferBlock* _recvBlock;

		private Timer _delayedClock;

		private NetDelayedPacketList _delayedPackets;

		public NetAddress Address => _address;

		public NetConfig Config => _config;

		public int GroupCount => _config.ConnectionGroups;

		public bool IsShutdown => _state == 2;

		public unsafe static NetConfig* GetConfigPointer(NetPeer* p)
		{
			if (p->_state == 2)
			{
				return null;
			}
			return &p->_config;
		}

		public unsafe static NetPeerGroup* GetGroup(NetPeer* p, int index)
		{
			if (p->_state == 2)
			{
				return null;
			}
			Assert.Check((uint)index < (uint)p->_config.ConnectionGroups);
			return p->_groups + index;
		}

		public unsafe static void Update(NetPeer* p, INetSocket socket, Random rng)
		{
			bool flag = false;
			Update(p, socket, &flag, rng);
		}

		public unsafe static void Update(NetPeer* p, INetSocket socket, bool* work, Random rng)
		{
			if (p->_state != 2)
			{
				if (p->_state != 0)
				{
					InternalLogStreams.LogError?.Log("Can't call Update on NetPeer which is running or has been running on a thread");
					return;
				}
				RecvInternal(p, socket, work, rng);
				SendInternal(p, socket, work);
			}
		}

		public unsafe static void Recv(NetPeer* p, INetSocket socket, Random rng)
		{
			bool flag = false;
			Recv(p, socket, &flag, rng);
		}

		public unsafe static void Recv(NetPeer* p, INetSocket socket, bool* work, Random rng)
		{
			if (p->_state != 2)
			{
				if (p->_state != 0)
				{
					InternalLogStreams.LogError?.Log("Can't call Update on NetPeer which is running or has been running on a thread");
				}
				else
				{
					RecvInternal(p, socket, work, rng);
				}
			}
		}

		public unsafe static void RemapAddress(NetPeer* p, NetAddress oldAddress, NetAddress newAddress)
		{
			int num = p->_groupsMap->Remove(oldAddress);
			Assert.Check(num >= 0);
			p->_groupsMap->Insert(newAddress, 0);
		}

		public unsafe static void Send(NetPeer* p, INetSocket socket)
		{
			if (p->_state != 2)
			{
				bool flag = false;
				Send(p, socket, &flag);
			}
		}

		public unsafe static void Send(NetPeer* p, INetSocket socket, bool* work)
		{
			if (p->_state != 2)
			{
				if (p->_state != 0)
				{
					InternalLogStreams.LogError?.Log("Can't call Update on NetPeer which is running or has been running on a thread");
				}
				else
				{
					SendInternal(p, socket, work);
				}
			}
		}

		public unsafe static NetPeer* Initialize(NetConfig config, INetSocket socket)
		{
			NetPeer* ptr = Native.MallocAndClear<NetPeer>();
			Initialize(ptr, config, socket);
			return ptr;
		}

		public unsafe static void Initialize(NetPeer* p, NetConfig config, INetSocket socket)
		{
			config.MaxConnections = Maths.Clamp(config.MaxConnections, 1, 2048);
			socket.Initialize(config);
			p->_config = config;
			p->_state = 0;
			p->_recvTimer = default(Timer);
			p->_fragmentBuffer = (byte*)Native.MallocAndClear(1280);
			p->_refusedCommand = Native.MallocAndClear<NetCommandRefused>();
			p->_delayedClock = Timer.StartNew();
			p->_delayedPackets = default(NetDelayedPacketList);
			p->_sendStack = NetBitBufferStack.Create(2048);
			p->_recvBlock = NetBitBufferBlock.Create(config.PacketSize);
			p->_socket = socket.Create(config);
			p->_groupsMap = NetPeerGroupMap.Allocate(config.MaxConnections);
			p->_groups = Native.MallocAndClearArray<NetPeerGroup>(config.ConnectionGroups);
			p->_groupsAssigned = Native.MallocAndClearArray<int>(config.ConnectionGroups);
			for (short num = 0; num < config.ConnectionGroups; num++)
			{
				NetPeerGroup.Initialize(num, p->_groups + num, p, config);
			}
			p->_address = socket.Bind(p->_socket, p->_config);
			InternalLogStreams.LogTraceNetwork?.Log($"socket bound to {p->_address}");
		}

		public unsafe static void Destroy(NetPeer* p, INetSocket socket, INetPeerGroupCallbacks callbacks)
		{
			if (p->_state == 0)
			{
				p->_state = 2;
				DestroySocket(p, socket, callbacks);
			}
		}

		private unsafe static void DestroySocket(NetPeer* p, INetSocket socket, INetPeerGroupCallbacks callbacks)
		{
			if (p != null && p->_socket.IsCreated)
			{
				NetBitBufferStack.Dispose(ref p->_sendStack);
				p->_delayedPackets.Dispose();
				for (int i = 0; i < p->GroupCount; i++)
				{
					NetPeerGroup.Dispose(p->_groups + i, callbacks);
				}
				NetBitBuffer.ReleaseRef(ref p->_recv);
				NetBitBufferBlock.Dispose(ref p->_recvBlock);
				NetPeerGroupMap.Dispose(ref p->_groupsMap);
				Native.Free(ref p->_groupsAssigned);
				Native.Free(ref p->_refusedCommand);
				Native.Free(ref p->_fragmentBuffer);
				Native.Free(ref p->_groups);
				socket.Destroy(p->_socket);
				p->_socket = default(NetSocket);
				Native.Free(ref p);
			}
		}

		private unsafe static short FindGroupWithLeastAssignedAddresses(NetPeer* p)
		{
			short result = -1;
			int num = p->_config.ConnectionsPerGroup;
			for (short num2 = 0; num2 < p->_config.ConnectionGroups; num2++)
			{
				if (p->_groupsAssigned[num2] < num)
				{
					result = num2;
					num = p->_groupsAssigned[num2];
				}
			}
			return result;
		}

		private unsafe static void RecvInternal(NetPeer* p, INetSocket socket, bool* work, Random rng)
		{
			p->_recvTimer.Restart();
			RecvDelayed(p, socket, work, rng);
			if (RecvExpired(p))
			{
				return;
			}
			int num;
			while (RecvBufferAvailable(p) && (num = socket.Receive(p->_socket, &p->_recv->Address, (byte*)p->_recv->Data, p->_config.PacketSize)) > 0)
			{
				InternalLogStreams.LogTraceNetwork?.Log($"recv {p->_recv->Address} <= {num} bytes");
				*work = true;
				p->_recv->LengthBytes = num;
				if (p->_config.Simulation.LossNotifySequencesLength > 0 && p->_recv->PacketType == NetPacketType.NotifyData)
				{
					Assert.Check(p->_config.Simulation.LossNotifySequences != null);
					ushort sequence = ((NetNotifyHeader*)p->_recv->Data)->Sequence;
					bool flag = false;
					for (int i = 0; i < p->_config.Simulation.LossNotifySequencesLength; i++)
					{
						if (p->_config.Simulation.LossNotifySequences[i] == sequence)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						continue;
					}
				}
				NetConfigSimulationOscillator lossOscillator = p->_config.Simulation.LossOscillator;
				if (lossOscillator.Min > 0.0 && lossOscillator.Min <= lossOscillator.Max)
				{
					double curveValue = lossOscillator.GetCurveValue(rng, p->_delayedClock.ElapsedInSeconds);
					if (rng.NextDouble() <= curveValue)
					{
						continue;
					}
				}
				NetConfigSimulationOscillator delayOscillator = p->_config.Simulation.DelayOscillator;
				if (delayOscillator.Min > 0.0 && delayOscillator.Min <= delayOscillator.Max)
				{
					NetDelayedPacket* ptr = NetDelayedPacket.Create(p->_recv->LengthBytes);
					Native.MemCpy(ptr->Data, p->_recv->Data, p->_recv->LengthBytes);
					ptr->Address = p->_recv->Address;
					double curveValue2 = delayOscillator.GetCurveValue(rng, p->_delayedClock.ElapsedInSeconds);
					ptr->DeliveryTime = p->_delayedClock.ElapsedInSeconds + curveValue2;
					if (curveValue2 > 0.0)
					{
						p->_delayedPackets.AddLast(ptr);
						continue;
					}
				}
				RecvBufferPushToGroup(p, socket, rng);
				if (RecvExpired(p))
				{
					break;
				}
			}
		}

		private unsafe static void RecvBufferPushToGroup(NetPeer* p, INetSocket socket, Random rng)
		{
			Assert.Check(p->_recv != null);
			Assert.Check(!p->_recv->Address.Equals(default(NetAddress)));
			short num = p->_groupsMap->Find(p->_recv->Address);
			if (num == -1)
			{
				NetCommandHeader data = *(NetCommandHeader*)p->_recv->Data;
				if (data.PacketType != NetPacketType.Command || data.Command != NetCommands.Connect)
				{
					return;
				}
				num = FindGroupWithLeastAssignedAddresses(p);
				if (num == -1)
				{
					*p->_refusedCommand = NetCommandRefused.Create(NetConnectFailedReason.ServerFull);
					socket.Send(p->_socket, &p->_recv->Address, (byte*)p->_refusedCommand, 3);
					return;
				}
				Assert.Check(p->_groupsAssigned[num] >= 0 && p->_groupsAssigned[num] < p->_config.ConnectionsPerGroup);
				if (!p->_groupsMap->Insert(p->_recv->Address, num))
				{
					return;
				}
				p->_groupsAssigned[num]++;
			}
			Assert.Check(num >= 0 && num <= p->_config.ConnectionGroups);
			if (p->_config.Simulation.DuplicateChance > 0.0 && rng.NextDouble() <= p->_config.Simulation.DuplicateChance && p->_recvBlock->TryAcquire(out var ptr))
			{
				ptr->Address = p->_recv->Address;
				ptr->LengthBytes = p->_recv->LengthBytes;
				Native.MemCpy(ptr->Data, p->_recv->Data, p->_recv->LengthBytes);
				NetPeerGroup.PushOnRecvHead(p->_groups + num, ptr);
			}
			NetPeerGroup.PushOnRecvHead(p->_groups + num, p->_recv);
			p->_recv = null;
		}

		private unsafe static void RecvDelayed(NetPeer* p, INetSocket socket, bool* work, Random rng)
		{
			while (p->_delayedPackets.Count > 0 && p->_delayedPackets.Head->DeliveryTime < p->_delayedClock.ElapsedInSeconds && RecvBufferAvailable(p) && !RecvExpired(p))
			{
				*work = true;
				NetDelayedPacket* memory = p->_delayedPackets.RemoveHead();
				Native.MemCpy(p->_recv->Data, memory->Data, memory->DataLength);
				p->_recv->Address = memory->Address;
				p->_recv->LengthBytes = memory->DataLength;
				RecvBufferPushToGroup(p, socket, rng);
				Native.Free(ref memory);
			}
		}

		private unsafe static void SendInternal(NetPeer* p, INetSocket socket, bool* work)
		{
			SendFromStack(p, socket, work);
			Assert.Check(p->_sendStack.Count == 0);
			for (int i = 0; i < p->_config.ConnectionGroups; i++)
			{
				IntPtr intPtr = NetPeerGroup.PopSendHead(p->_groups + i);
				if (!(intPtr == IntPtr.Zero))
				{
					*work = true;
					p->_sendStack.PushFromHead((NetBitBuffer*)(void*)intPtr);
				}
			}
			SendFromStack(p, socket, work);
		}

		private unsafe static void SendFromStack(NetPeer* p, INetSocket socket, bool* work)
		{
			NetBitBuffer* ptr = null;
			while (p->_sendStack.TryPop(&ptr))
			{
				*work = true;
				Assert.Check(!ptr->Address.Equals(default(NetAddress)));
				if (ptr->PacketType == NetPacketType.Command)
				{
					NetCommandHeader* data = (NetCommandHeader*)ptr->Data;
					if (data->Command == NetCommands.Connect)
					{
						short num = p->_groupsMap->Find(ptr->Address);
						if (num == -1)
						{
							if (!p->_groupsMap->Insert(ptr->Address, ptr->Group))
							{
								NetBitBuffer.Release(ptr);
								continue;
							}
							p->_groupsAssigned[ptr->Group]++;
						}
					}
				}
				if (ptr->PacketType != NetPacketType.Unconnected)
				{
					Assert.Check((uint)p->_groupsMap->Find(ptr->Address) < (uint)p->_config.ConnectionGroups);
				}
				if (ptr->Group == -1)
				{
					Assert.Check(ptr->OffsetBits == 0);
					int num2 = p->_groupsMap->Remove(ptr->Address);
					socket.DeleteEncryptionKey(ptr->Address);
					InternalLogStreams.LogTraceNetwork?.Log($"{ptr->Address} unmapped from {num2}");
					Assert.Check((uint)num2 < (uint)p->_config.ConnectionGroups);
					p->_groupsAssigned[num2]--;
					Assert.Check(p->_groupsAssigned[num2] >= 0);
					NetBitBuffer.Release(ptr);
					continue;
				}
				int num3 = Maths.BytesRequiredForBits(ptr->OffsetBits);
				if (ptr->PacketType == NetPacketType.NotifyData && num3 > 1280)
				{
					InternalLogStreams.LogTraceNetwork?.Log($"send {ptr->Address} => {num3} bytes [FRAGMENTED, MTU:{1280}]");
					NetNotifyHeader netNotifyHeader = default(NetNotifyHeader);
					Native.MemCpy(&netNotifyHeader, ptr->Data, 14);
					byte* ptr2 = (byte*)ptr->Data + 14;
					int num4 = num3 - 14;
					byte b = 1;
					InternalLogStreams.LogTraceNetwork?.Log("frag-send-start");
					while (num4 > 0)
					{
						Assert.Check(b >= 1 && b <= 40, "Max amount of fragments reached {0}, remaining data: {1}", 40, num4);
						int num5 = Math.Min(1122, num4);
						num4 -= num5;
						Assert.Check(num4 >= 0);
						netNotifyHeader.Fragment = b;
						if (num4 == 0)
						{
							netNotifyHeader.Fragment |= 128;
						}
						InternalLogStreams.LogTraceNetwork?.Log($"frag-send:{b} seq:{netNotifyHeader.Sequence} size:{num5} last:{(netNotifyHeader.Fragment & 0x80) == 128}");
						Native.MemCpy(p->_fragmentBuffer, &netNotifyHeader, 14);
						Native.MemCpy(p->_fragmentBuffer + 14, ptr2, num5);
						ptr2 += num5;
						b++;
						socket.Send(p->_socket, &ptr->Address, p->_fragmentBuffer, num5 + 14, reliable: true);
					}
					InternalLogStreams.LogTraceNetwork?.Log("frag-send-end");
				}
				else
				{
					socket.Send(p->_socket, &ptr->Address, (byte*)ptr->Data, num3);
				}
				if (ptr->PacketType == NetPacketType.Command)
				{
					NetCommandHeader* data2 = (NetCommandHeader*)ptr->Data;
					if (data2->Command == NetCommands.Refused && p->_groupsMap->Find(ptr->Address) != -1)
					{
						int num6 = p->_groupsMap->Remove(ptr->Address);
						InternalLogStreams.LogTraceNetwork?.Log($"{ptr->Address} unmapped from {num6} because it was refused.");
						Assert.Check((uint)num6 < (uint)p->_config.ConnectionGroups);
						p->_groupsAssigned[num6]--;
						Assert.Check(p->_groupsAssigned[num6] >= 0);
					}
				}
				NetBitBuffer.Release(ptr);
			}
			Assert.Check(p->_sendStack.Count == 0);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static bool RecvBufferAvailable(NetPeer* p)
		{
			if (p->_recv == null)
			{
				p->_recv = p->_recvBlock->TryAcquire();
			}
			if (p->_recv != null)
			{
				p->_recv->Address = default(NetAddress);
			}
			return p->_recv != null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static bool RecvExpired(NetPeer* p)
		{
			return p->_recvTimer.ElapsedInMilliseconds > p->_config.OperationExpireTime;
		}
	}
	public struct NetPeerGroup
	{
		private const double RELIABLE_SEND_INTERVAL = 0.05;

		private unsafe NetPeer* _peer;

		private short _group;

		private Timer _clock;

		private NetConfig _config;

		private uint _counter;

		private IntPtr _sendHead;

		private IntPtr _recvHead;

		private NetBitBufferStack _recvStack;

		private unsafe NetBitBufferBlock* _sendBlock;

		private unsafe NetConnectionMap* _connectionsMap;

		internal double ReliableSendInterval;

		public double Time => _clock.ElapsedInSeconds;

		public int Group => _group;

		public unsafe int ConnectionCount => _connectionsMap->Count;

		internal unsafe static void Dispose(NetPeerGroup* g, INetPeerGroupCallbacks callbacks)
		{
			if (g != null)
			{
				NetConnectionMap.Dispose(ref g->_connectionsMap, callbacks);
				NetBitBufferBlock.Dispose(ref g->_sendBlock);
				NetBitBufferStack.Dispose(ref g->_recvStack);
			}
		}

		public unsafe static NetConnection* GetConnection(NetPeerGroup* g, NetConnectionId id)
		{
			return g->_connectionsMap->Find(id);
		}

		public unsafe static NetConnection* GetConnectionByIndex(NetPeerGroup* g, int index)
		{
			return g->_connectionsMap->FindByIndex(index);
		}

		public unsafe static bool TryGetConnectionByIndex(NetPeerGroup* g, int index, out NetConnection* connection)
		{
			return g->_connectionsMap->TryFindByIndex(index, out connection);
		}

		public unsafe static NetConnectionMap.Iterator ConnectionIterator(NetPeerGroup* g)
		{
			return new NetConnectionMap.Iterator(g->_connectionsMap);
		}

		public unsafe static void Connect(NetPeerGroup* g, NetAddress address, byte[] token, byte[] uniqueId = null)
		{
			NetConnection* ptr = AllocateConnection(g, address, token, uniqueId);
			if (ptr == null)
			{
				InternalLogStreams.LogError?.Log("No free connection slots");
				return;
			}
			ChangeConnectionStatus(g, null, ptr, NetConnectionStatus.Connecting);
			SendCommandConnect(g, null, ptr);
		}

		public unsafe static void Connect(NetPeerGroup* g, string ip, ushort port, byte[] token, byte[] uniqueId = null)
		{
			Connect(g, NetAddress.CreateFromIpPort(ip, port), token, uniqueId);
		}

		public unsafe static void Disconnect(NetPeerGroup* g, NetConnection* c, byte[] token)
		{
			if (g != null && (c->Status == NetConnectionStatus.Connected || c->Status == NetConnectionStatus.Connecting))
			{
				SendCommand(g, c, NetCommandDisconnect.Create(NetDisconnectReason.Requested, token));
				DisconnectInternal(g, c, NetDisconnectReason.Requested);
			}
		}

		internal unsafe static void DisconnectInternal(NetPeerGroup* g, NetConnection* c, NetDisconnectReason reason = NetDisconnectReason.ByRemote, byte[] token = null)
		{
			if (g == null || (c->Status != NetConnectionStatus.Connected && c->Status != NetConnectionStatus.Connecting))
			{
				return;
			}
			c->StateDisconnected = default(NetConnection.StateDisconnectedData);
			c->StateDisconnected.Reason = reason;
			if (token != null)
			{
				int num = (c->DisconnectTokenLength = Math.Min(128, token.Length));
				c->DisconnectToken = Native.MallocAndClearArray<byte>(num);
				for (int i = 0; i < num; i++)
				{
					c->DisconnectToken[i] = token[i];
				}
			}
			else
			{
				c->DisconnectToken = null;
				c->DisconnectTokenLength = 0;
			}
			ChangeConnectionStatus(g, null, c, NetConnectionStatus.Disconnected);
		}

		public unsafe static void Update(NetPeerGroup* g, INetPeerGroupCallbacks cb)
		{
			if (g != null)
			{
				Receive(g, cb);
				Assert.Check(g->_recvStack.Count == 0);
				UpdateConnections(g, cb);
				IntPtr intPtr;
				do
				{
					intPtr = Volatile.Read(ref g->_recvHead);
				}
				while (Interlocked.CompareExchange(ref g->_recvHead, IntPtr.Zero, intPtr) != intPtr);
				if (intPtr != IntPtr.Zero)
				{
					g->_recvStack.PushFromHead((NetBitBuffer*)(void*)intPtr);
					Receive(g, cb);
				}
			}
		}

		internal unsafe static void Initialize(short groupIndex, NetPeerGroup* g, NetPeer* p, NetConfig config)
		{
			*g = default(NetPeerGroup);
			g->_config = config;
			g->_peer = p;
			g->_group = groupIndex;
			g->_clock = Timer.StartNew();
			g->_sendBlock = NetBitBufferBlock.Create(config.PacketSize);
			g->_recvStack = NetBitBufferStack.Create(1024);
			g->_connectionsMap = NetConnectionMap.Allocate(g->_config.ConnectionsPerGroup, groupIndex, &g->_config);
			g->ReliableSendInterval = 0.05;
		}

		internal unsafe static IntPtr PopSendHead(NetPeerGroup* g)
		{
			IntPtr intPtr;
			do
			{
				intPtr = Volatile.Read(ref g->_sendHead);
			}
			while (Interlocked.CompareExchange(ref g->_sendHead, IntPtr.Zero, intPtr) != intPtr);
			return intPtr;
		}

		internal unsafe static void PushOnRecvHead(NetPeerGroup* g, NetBitBuffer* b)
		{
			IntPtr intPtr;
			do
			{
				intPtr = Volatile.Read(ref g->_recvHead);
				b->Next = (NetBitBuffer*)(void*)intPtr;
			}
			while (Interlocked.CompareExchange(ref g->_recvHead, (IntPtr)b, intPtr) != intPtr);
		}

		private unsafe static void UpdateConnections(NetPeerGroup* g, INetPeerGroupCallbacks cb)
		{
			int countUsed = g->_connectionsMap->CountUsed;
			NetConnection* connectionsBuffer = g->_connectionsMap->ConnectionsBuffer;
			for (int i = 0; i < countUsed; i++)
			{
				NetConnection* ptr = connectionsBuffer + i;
				if (ptr->MapState == NetConnectionMap.EntryState.Used)
				{
					switch (ptr->Status)
					{
					case NetConnectionStatus.Connecting:
						UpdateConnecting(g, cb, ptr);
						break;
					case NetConnectionStatus.Connected:
						UpdateConnected(g, cb, ptr);
						break;
					case NetConnectionStatus.Disconnected:
						UpdateDisconnected(g, cb, ptr);
						break;
					case NetConnectionStatus.Shutdown:
						UpdateShutdown(g, cb, ptr);
						break;
					}
				}
			}
		}

		public unsafe static void SendReliable(NetPeerGroup* g, NetConnection* c, ReliableId rid, byte* data, int dataLength)
		{
			Assert.Check(sizeof(ReliableId) == 48);
			Assert.Check(sizeof(ReliableHeader) == 64);
			Assert.Check(c->Status == NetConnectionStatus.Connected);
			Assert.Check(data);
			Assert.Check(dataLength >= 0);
			int num = dataLength;
			while (dataLength > 0)
			{
				int num2 = Math.Min(dataLength, 1088);
				ReliableHeader* ptr = (ReliableHeader*)Native.MallocAndClear(64 + num2);
				rid.Sequence = c->ReliableBuffer.NextSendSequence();
				rid.SliceLength = num2;
				rid.TotalLength = ((rid.TotalLength < num) ? num : rid.TotalLength);
				ptr->Id = rid;
				Native.MemCpy((byte*)ptr + 64, data, num2);
				data += num2;
				dataLength -= num2;
				c->ReliableSendList.AddLast(ptr);
			}
		}

		public unsafe static void ChangeConnectionAddressDuringConnecting(NetPeerGroup* g, NetConnection* c, NetAddress newAddress)
		{
			Assert.Check(c->Status == NetConnectionStatus.Connecting);
			InternalLogStreams.LogTraceNetwork?.Log($"Changing address for connection ({c->LocalId}:{(IntPtr)c}) from {c->Address} to {newAddress} during connecting phase");
			NetAddress address = c->Address;
			g->_connectionsMap->Remap(address, newAddress);
			Assert.Check(c->Address.Equals(newAddress));
			NetPeer.RemapAddress(g->_peer, address, newAddress);
		}

		private unsafe static void SendCommandConnect(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c)
		{
			Assert.Check(c->Status == NetConnectionStatus.Connecting);
			if (c->StateConnecting.Attempts == g->_config.ConnectAttempts)
			{
				Assert.Check(cb != null);
				NetAddress address = c->Address;
				ChangeConnectionStatus(g, cb, c, NetConnectionStatus.Shutdown);
				cb.OnConnectionFailed(address, NetConnectFailedReason.Timeout);
			}
			else
			{
				cb?.OnConnectionAttempt(c, c->StateConnecting.Attempts, g->_config.ConnectAttempts);
				c->StateConnecting.Attempts++;
				c->StateConnecting.AttemptTimeout = g->_clock.ElapsedInSeconds + g->_config.ConnectInterval;
				SendCommand(g, c, NetCommandConnect.Create(c->LocalId, c->ConnectionToken, c->ConnectionTokenLength, c->UniqueId));
				InternalLogStreams.LogDebug?.Log($"Connection Attempt: {*c} [{c->StateConnecting.Attempts}/{g->_config.ConnectAttempts}]");
			}
		}

		private unsafe static void UpdateConnecting(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c)
		{
			if (c->StateConnecting.AttemptTimeout < g->_clock.ElapsedInSeconds)
			{
				SendCommandConnect(g, cb, c);
			}
		}

		private unsafe static void UpdateConnected(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c)
		{
			if (c->RecvTime + g->_config.ConnectionTimeout < g->_clock.ElapsedInSeconds)
			{
				DisconnectInternal(g, c, NetDisconnectReason.Timeout);
				return;
			}
			if (c->ReliableSendTimer.IsRunning && c->ReliableSendTimer.Peek() >= g->ReliableSendInterval && c->ReliableSendList.Count > 0 && GetNotifyDataBuffer(g, c, out var b))
			{
				c->ReliableSendTimer.Consume();
				ReliableHeader* memory = c->ReliableSendList.RemoveHead();
				byte* data = ReliableHeader.GetData(memory);
				b->WriteBytesAligned(&memory->Id, 48);
				Native.MemCpy(b->GetDataPointer(), data, memory->Id.SliceLength);
				b->OffsetBits += memory->Id.SliceLength * 8;
				b->PacketType = NetPacketType.NotifyReliableData;
				if (!SendNotifyDataBuffer(g, c, b, memory))
				{
					Native.Free(ref memory);
					c->ReliableSendList.Dispose();
				}
			}
			if (((c->NotifyRecvUnackedCount > 0 && c->NotifyRecvUnackedCount >= g->_config.Notify.AckForceCount) || c->NotifySendTime + g->_config.Notify.AckForceTimeout < g->_clock.ElapsedInSeconds) && GetConnectionSendBuffer(g, c, out var b2))
			{
				c->NotifyRecvUnackedCount = 0;
				c->NotifySendTime = g->_clock.ElapsedInSeconds;
				*(NetNotifyHeader*)b2->Data = NetNotifyHeader.CreateAcks(c->NotifyRecvSequence, c->NotifyRecvMask);
				b2->OffsetBits = 112;
				Send(g, c, b2);
			}
		}

		private unsafe static void UpdateDisconnected(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c)
		{
			if (c->StateDisconnected.SentDisconnectCommand == 0)
			{
				c->StateDisconnected.SentDisconnectCommand = (SendCommand(g, c, NetCommandDisconnect.Create(c->StateDisconnected.Reason, c->DisconnectToken, c->DisconnectTokenLength)) ? 1 : 0);
			}
			if (c->StateDisconnected.CallbackInvoked == 0)
			{
				c->StateDisconnected.CallbackInvoked = 1;
				cb.OnDisconnected(c, c->StateDisconnected.Reason);
			}
			if (c->StateDisconnected.SentDisconnectCommand == 1 && c->StateDisconnected.CallbackInvoked == 1)
			{
				ChangeConnectionStatus(g, cb, c, NetConnectionStatus.Shutdown);
			}
		}

		private unsafe static void UpdateShutdown(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c)
		{
			if (c->StateShutdown.Unmapped == 1)
			{
				if (c->StateShutdown.Timeout < g->_clock.ElapsedInSeconds)
				{
					ReleaseConnection(g, cb, c);
				}
			}
			else if (c->StateShutdown.Unmapped == 0)
			{
				QueueAddressUnmap(g, c);
			}
		}

		private unsafe static void SendUnconnected(NetPeerGroup* g, NetBitBuffer* b)
		{
			IntPtr sendHead;
			do
			{
				sendHead = g->_sendHead;
				b->Next = (NetBitBuffer*)(void*)sendHead;
			}
			while (Interlocked.CompareExchange(ref g->_sendHead, (IntPtr)b, sendHead) != sendHead);
		}

		private unsafe static void Send(NetPeerGroup* g, NetConnection* c, NetBitBuffer* b)
		{
			Assert.Check(!c->Address.Equals(default(NetAddress)));
			if (b->PacketType == NetPacketType.NotifyData)
			{
				c->NotifyRecvUnackedCount = 0;
			}
			c->SendTime = g->_clock.ElapsedInSeconds;
			IntPtr sendHead;
			do
			{
				sendHead = g->_sendHead;
				b->Next = (NetBitBuffer*)(void*)sendHead;
			}
			while (Interlocked.CompareExchange(ref g->_sendHead, (IntPtr)b, sendHead) != sendHead);
		}

		private unsafe static bool GetConnectionSendBuffer(NetPeerGroup* g, NetConnection* c, out NetBitBuffer* b)
		{
			if (g->_sendBlock->TryAcquire(out b))
			{
				b->Group = g->_group;
				b->Address = c->Address;
				return true;
			}
			return false;
		}

		public unsafe static bool SendUnconnectedData(NetPeerGroup* g, NetAddress address, void* data, int dataLength)
		{
			if (g->_sendBlock->TryAcquire(out var ptr))
			{
				*(sbyte*)ptr->Data = 5;
				ptr->Group = 0;
				ptr->OffsetBits = 8;
				ptr->Address = address;
				ptr->WriteBytesAligned(data, dataLength);
				SendUnconnected(g, ptr);
				return true;
			}
			return false;
		}

		public unsafe static bool GetUnreliableDataBuffer(NetPeerGroup* g, NetConnection* c, out NetBitBuffer* b)
		{
			if (c->Status == NetConnectionStatus.Connected && GetConnectionSendBuffer(g, c, out b))
			{
				*(NetUnreliableHeader*)b->Data = NetUnreliableHeader.Create();
				b->OffsetBits = 8;
				return true;
			}
			b = null;
			return false;
		}

		public unsafe static bool SendUnreliableDataBuffer(NetPeerGroup* g, NetConnection* c, NetBitBuffer* b)
		{
			Assert.Check(b->PacketType == NetPacketType.UnreliableData);
			if (c->Status != NetConnectionStatus.Connected)
			{
				NetBitBuffer.Release(b);
				return false;
			}
			Send(g, c, b);
			return true;
		}

		public unsafe static bool GetNotifyDataBuffer(NetPeerGroup* g, NetConnection* c, out NetBitBuffer* b)
		{
			if (c->Status == NetConnectionStatus.Connected && !c->NotifySendWindow.IsFull && GetConnectionSendBuffer(g, c, out b))
			{
				NetNotifyHeader netNotifyHeader = new NetNotifyHeader
				{
					PacketType = NetPacketType.NotifyData
				};
				*(NetNotifyHeader*)b->Data = netNotifyHeader;
				b->OffsetBits = 112;
				return true;
			}
			b = null;
			return false;
		}

		public unsafe static bool SendNotifyDataBuffer(NetPeerGroup* g, NetConnection* c, NetBitBuffer* b, void* userData)
		{
			Assert.Check(b->PacketType == NetPacketType.NotifyData || b->PacketType == NetPacketType.NotifyReliableData);
			if (c->Status != NetConnectionStatus.Connected)
			{
				NetBitBuffer.Release(b);
				return false;
			}
			if (c->NotifySendWindow.IsFull)
			{
				DisconnectInternal(g, c, NetDisconnectReason.SendWindowFull);
				NetBitBuffer.Release(b);
				return false;
			}
			InternalLogStreams.LogTraceNetwork?.Log($"{LogUtils.GetDump(b)} Send:{Maths.BytesRequiredForBits(b->OffsetBits)}");
			NetNotifyHeader netNotifyHeader = NetNotifyHeader.CreateData(NetConnection.NextNotifySendSequence(c), c->NotifyRecvSequence, c->NotifyRecvMask);
			if (b->PacketType == NetPacketType.NotifyReliableData)
			{
				netNotifyHeader.PacketType = NetPacketType.NotifyReliableData;
			}
			Native.MemCpy(b->Data, &netNotifyHeader, 14);
			NetSendEnvelope envelope = default(NetSendEnvelope);
			envelope.Sequence = netNotifyHeader.Sequence;
			envelope.UserData = userData;
			envelope.SendTime = g->_clock.ElapsedInSeconds;
			envelope.PacketType = b->PacketType;
			c->NotifySendWindow.Push(envelope);
			c->NotifySendTime = envelope.SendTime;
			Send(g, c, b);
			return true;
		}

		private unsafe static void Receive(NetPeerGroup* g, INetPeerGroupCallbacks cb)
		{
			NetBitBuffer* ptr = null;
			while (g->_recvStack.TryPop(&ptr))
			{
				InternalLogStreams.LogTraceNetwork?.Log($"Receive:{ptr->LengthBytes}");
				try
				{
					NetConnection* ptr2 = g->_connectionsMap->Find(ptr->Address);
					if (ptr2 == null)
					{
						HandlePacketUnconnected(g, cb, ptr);
					}
					else
					{
						HandlePacket(g, cb, ptr2, ptr);
					}
				}
				finally
				{
					NetBitBuffer.Release(ptr);
				}
			}
		}

		private unsafe static void HandlePacketUnconnected(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetBitBuffer* b)
		{
			if (b->PacketType == NetPacketType.Command)
			{
				InternalLogStreams.LogDebug?.Log($"Handle Packet Unconnected from {b->Address}");
				NetCommandHeader* data = (NetCommandHeader*)b->Data;
				if (data->Command != NetCommands.Connect)
				{
					return;
				}
				NetCommandConnect data2 = *(NetCommandConnect*)b->Data;
				byte[] tokenDataAsArray = NetCommandConnect.GetTokenDataAsArray(data2);
				byte[] uniqueIdAsArray = NetCommandConnect.GetUniqueIdAsArray(data2);
				switch (cb.OnConnectionRequest(b->Address, tokenDataAsArray, uniqueIdAsArray))
				{
				case OnConnectionRequestReply.Ok:
				{
					NetConnection* ptr = AllocateConnection(g, b->Address, tokenDataAsArray, uniqueIdAsArray);
					if (ptr != null)
					{
						HandlePacketCommand(g, cb, ptr, b);
					}
					break;
				}
				case OnConnectionRequestReply.Refuse:
					if (!SendCommandUnconnected(g, b->Address, NetCommandRefused.Create(NetConnectFailedReason.ServerRefused)))
					{
						InternalLogStreams.LogDebug?.Error("Sending Refused Connection Failed");
					}
					break;
				case OnConnectionRequestReply.Waiting:
					break;
				}
			}
			else if (b->PacketType == NetPacketType.Unconnected)
			{
				cb.OnUnconnectedData(b);
			}
		}

		public unsafe static double GetConnectionIdleTime(NetPeerGroup* g, NetConnection* c)
		{
			return g->Time - c->RecvTime;
		}

		private unsafe static void HandlePacket(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c, NetBitBuffer* b)
		{
			c->RecvTime = g->_clock.ElapsedInSeconds;
			switch (b->PacketType)
			{
			case NetPacketType.Command:
				if (c->Status == NetConnectionStatus.Connecting || c->Status == NetConnectionStatus.Connected)
				{
					HandlePacketCommand(g, cb, c, b);
				}
				break;
			case NetPacketType.NotifyData:
			case NetPacketType.NotifyReliableData:
				if (c->Status == NetConnectionStatus.Connected)
				{
					HandlePacketNotifyData(g, cb, c, b);
				}
				break;
			case NetPacketType.NotifyAcks:
				if (c->Status == NetConnectionStatus.Connected)
				{
					HandlePacketNotifyAcks(g, cb, c, b);
				}
				break;
			case NetPacketType.UnreliableData:
				if (c->Status == NetConnectionStatus.Connected)
				{
					HandlePacketUnreliableData(g, cb, c, b);
				}
				break;
			case NetPacketType.Unconnected:
				break;
			default:
				InternalLogStreams.LogError?.Log($"Invalid Packet Type {b->PacketType}");
				break;
			}
		}

		private unsafe static void HandlePacketNotifyAcks(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c, NetBitBuffer* b)
		{
			if (b->LengthBytes >= 14)
			{
				c->NotifyRecvTime = g->_clock.ElapsedInSeconds;
				HandlePacketAcks(g, cb, c, *(NetNotifyHeader*)b->Data);
			}
		}

		private unsafe static void HandlePacketNotifyData(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c, NetBitBuffer* b)
		{
			if (b->LengthBytes <= 14)
			{
				return;
			}
			NetNotifyHeader header = default(NetNotifyHeader);
			Native.MemCpy(&header, b->Data, 14);
			int num = c->NotifySendSequencer.Distance(header.Sequence, c->NotifyRecvSequence);
			if (num > g->_config.Notify.SequenceBounds || num < -g->_config.Notify.SequenceBounds)
			{
				DisconnectInternal(g, c, NetDisconnectReason.SequenceOutOfBounds);
			}
			else
			{
				if (num < 0)
				{
					return;
				}
				if (header.Fragment != 0)
				{
					if (num == 0)
					{
						return;
					}
					Assert.Check(b->PacketType == NetPacketType.NotifyData);
					int num2 = header.Fragment & -129;
					if (num2 == 1)
					{
						InternalLogStreams.LogTraceNetwork?.Log("frag-recv-start");
						InternalLogStreams.LogTraceNetwork?.Log($"frag-recv:{num2} seq:{header.Sequence} size:{b->LengthBytes}");
						c->NotifyRecvFragment = num2;
						c->NotifyRecvFragmentBufferLength = 0;
						c->NotifyRecvFragmentSequenceDistance = num;
						Native.MemCpy(c->NotifyRecvFragmentBuffer, b->Data, b->LengthBytes);
						c->NotifyRecvFragmentBufferLength = b->LengthBytes;
					}
					else if (num2 > 1 && num == c->NotifyRecvFragmentSequenceDistance && c->NotifyRecvFragment + 1 == num2)
					{
						InternalLogStreams.LogTraceNetwork?.Log($"frag-recv:{num2} seq:{header.Sequence} size:{b->LengthBytes}");
						c->NotifyRecvFragment = num2;
						int num3 = b->LengthBytes - 14;
						if (c->NotifyRecvFragmentBufferLength + num3 > 51200)
						{
							InternalLogStreams.LogError?.Log("Fragment buffer overflow");
							c->NotifyRecvFragment = 0;
							c->NotifyRecvFragmentBufferLength = 0;
							c->NotifyRecvFragmentSequenceDistance = 0;
							return;
						}
						Native.MemCpy(c->NotifyRecvFragmentBuffer + c->NotifyRecvFragmentBufferLength, (byte*)b->Data + 14, num3);
						c->NotifyRecvFragmentBufferLength += num3;
						if ((header.Fragment & 0x80) == 128)
						{
							HandlePacketNotifyData_Part2(header, num, g, cb, c, b);
							InternalLogStreams.LogTraceNetwork?.Log("frag-reassembled");
							NetBitBuffer netBitBuffer = new NetBitBuffer
							{
								LengthBytes = c->NotifyRecvFragmentBufferLength,
								OffsetBits = 112,
								Data = (ulong*)c->NotifyRecvFragmentBuffer,
								Address = b->Address,
								Group = (short)g->Group
							};
							cb.OnNotifyData(c, &netBitBuffer);
							c->NotifyRecvFragment = 0;
							c->NotifyRecvFragmentBufferLength = 0;
							c->NotifyRecvFragmentSequenceDistance = 0;
						}
					}
					else
					{
						c->NotifyRecvFragment = 0;
						c->NotifyRecvFragmentBufferLength = 0;
						c->NotifyRecvFragmentSequenceDistance = 0;
					}
				}
				else
				{
					if (num <= 0)
					{
						return;
					}
					c->NotifyRecvFragment = 0;
					c->NotifyRecvFragmentBufferLength = 0;
					c->NotifyRecvFragmentSequenceDistance = 0;
					HandlePacketNotifyData_Part2(header, num, g, cb, c, b);
					if (b->PacketType == NetPacketType.NotifyReliableData)
					{
						if (c->ReliableBuffer.Receive(b, out var rid))
						{
							byte* data = b->GetDataPointer();
							cb.OnReliableData(c, rid, data);
							void* root;
							while (c->ReliableBuffer.LateReceive(out root, out rid, out data))
							{
								cb.OnReliableData(c, rid, data);
								c->ReliableBuffer.LateFree(ref root);
							}
						}
					}
					else
					{
						cb.OnNotifyData(c, b);
					}
				}
			}
		}

		private unsafe static void HandlePacketNotifyData_Part2(NetNotifyHeader header, int sequenceDistance, NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c, NetBitBuffer* b)
		{
			c->NotifyRecvSequence = header.Sequence;
			if (sequenceDistance >= g->_config.Notify.AckMaskBits)
			{
				InternalLogStreams.LogTraceNetwork?.Warn("Huge loss. Clear Ack Mask.");
				c->NotifyRecvMask = 1uL;
			}
			else
			{
				c->NotifyRecvMask = (c->NotifyRecvMask << sequenceDistance) | 1;
			}
			c->NotifyRecvTime = g->_clock.ElapsedInSeconds;
			c->NotifyRecvUnackedCount++;
			HandlePacketAcks(g, cb, c, header);
			b->OffsetBits = 112;
		}

		private unsafe static void HandlePacketAcks(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c, NetNotifyHeader h)
		{
			int num = 0;
			while (c->NotifySendWindow.Count > 0)
			{
				NetSendEnvelope envelope = c->NotifySendWindow.Peek();
				int num2 = c->NotifySendSequencer.Distance(envelope.Sequence, h.AckSequence);
				if (num2 > 0)
				{
					break;
				}
				if (num2 == 0)
				{
					c->Rtt = Math.Max(0.0, g->_clock.ElapsedInSeconds - envelope.SendTime);
				}
				num++;
				c->NotifyRecvAckTime = g->_clock.ElapsedInSeconds;
				c->NotifySendWindow.Pop();
				if (num2 <= -g->_config.Notify.AckMaskBits || (h.AckMask & (ulong)(1L << -num2)) == 0)
				{
					if (envelope.PacketType == NetPacketType.NotifyReliableData)
					{
						ReliableHeader* item = envelope.TakeUserData<ReliableHeader>();
						c->ReliableSendList.AddFirst(item);
					}
					else
					{
						cb.OnNotifyLost(c, ref envelope);
					}
				}
				else if (envelope.PacketType == NetPacketType.NotifyReliableData)
				{
					ReliableHeader* memory = envelope.TakeUserData<ReliableHeader>();
					Native.Free(ref memory);
				}
				else
				{
					cb.OnNotifyDelivered(c, ref envelope);
				}
				Assert.Always(envelope.UserData == null, (IntPtr)envelope.UserData);
			}
			if (num == 0)
			{
				c->NotifyRecvAckOutdatedCount++;
			}
		}

		private unsafe static void HandlePacketUnreliableData(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c, NetBitBuffer* b)
		{
			b->OffsetBits = 8;
			cb.OnUnreliableData(c, b);
		}

		private unsafe static void HandlePacketCommand(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c, NetBitBuffer* b)
		{
			NetCommandHeader* data = (NetCommandHeader*)b->Data;
			InternalLogStreams.LogTraceNetwork?.Log($"command {c->Address} <= {data->Command}");
			switch (data->Command)
			{
			case NetCommands.Connect:
				HandleCommandConnect(g, cb, c, *(NetCommandConnect*)b->Data);
				break;
			case NetCommands.Refused:
				HandleCommandRefused(g, cb, c, *(NetCommandRefused*)b->Data);
				break;
			case NetCommands.Accepted:
				HandleCommandAccepted(g, cb, c, *(NetCommandAccepted*)b->Data);
				break;
			case NetCommands.Disconnect:
				HandleCommandDisconnect(g, cb, c, *(NetCommandDisconnect*)b->Data);
				break;
			default:
				InternalLogStreams.LogError?.Log($"Invalid Command Type {data->Command}");
				break;
			}
		}

		private unsafe static void HandleCommandRefused(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c, NetCommandRefused cmd)
		{
			Assert.Check(c->Status == NetConnectionStatus.Connecting);
			try
			{
				cb.OnConnectionFailed(c->Address, cmd.Reason);
			}
			catch (Exception error)
			{
				InternalLogStreams.LogException?.Log(error);
			}
			ChangeConnectionStatus(g, cb, c, NetConnectionStatus.Shutdown);
		}

		private unsafe static void HandleCommandDisconnect(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c, NetCommandDisconnect cmd)
		{
			if (c->Status != NetConnectionStatus.Connected)
			{
				InternalLogStreams.LogError?.Log(string.Format("received {0} with connection status {1}", "NetCommandDisconnect", c->Status));
			}
			else
			{
				DisconnectInternal(g, c, cmd.Reason);
			}
		}

		private unsafe static void HandleCommandConnect(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c, NetCommandConnect cmd)
		{
			switch (c->Status)
			{
			case NetConnectionStatus.Created:
				c->RemoteId = cmd.ConnectionId;
				c->Counter = ++g->_counter;
				ChangeConnectionStatus(g, cb, c, NetConnectionStatus.Connected);
				SendCommand(g, c, NetCommandAccepted.Create(c->LocalId, c->RemoteId, c->Counter));
				cb.OnConnected(c);
				break;
			case NetConnectionStatus.Connected:
				SendCommand(g, c, NetCommandAccepted.Create(c->LocalId, c->RemoteId, c->Counter));
				break;
			default:
				InternalLogStreams.LogError?.Log(string.Format("received {0} with connection status {1}", "NetCommandConnect", c->Status));
				break;
			}
		}

		private unsafe static void HandleCommandAccepted(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c, NetCommandAccepted cmd)
		{
			NetConnectionStatus status = c->Status;
			NetConnectionStatus netConnectionStatus = status;
			if (netConnectionStatus == NetConnectionStatus.Connecting)
			{
				Assert.Check(c->LocalId.Equals(cmd.AcceptedRemoteId));
				c->RemoteId = cmd.AcceptedLocalId;
				c->Counter = cmd.Counter;
				ChangeConnectionStatus(g, cb, c, NetConnectionStatus.Connected);
				cb.OnConnected(c);
			}
			else
			{
				InternalLogStreams.LogTraceNetwork?.Error(string.Format("received {0} with connection status {1}", "NetCommandAccepted", c->Status));
			}
		}

		private unsafe static bool SendCommand<T>(NetPeerGroup* g, NetConnection* c, T cmd) where T : unmanaged
		{
			if (GetConnectionSendBuffer(g, c, out var b))
			{
				*(T*)b->Data = cmd;
				b->OffsetBits = Maths.SizeOfBits<T>();
				Send(g, c, b);
				InternalLogStreams.LogTraceNetwork?.Log($"command {c->Address} => {((NetCommandHeader*)b->Data)->Command}");
				return true;
			}
			return false;
		}

		private unsafe static bool SendCommandUnconnected<T>(NetPeerGroup* g, NetAddress address, T cmd) where T : unmanaged
		{
			if (g->_sendBlock->TryAcquire(out var ptr))
			{
				*(T*)ptr->Data = cmd;
				ptr->Group = g->_group;
				ptr->Address = address;
				ptr->OffsetBits = Maths.SizeOfBits<T>();
				SendUnconnected(g, ptr);
				InternalLogStreams.LogTraceNetwork?.Log($"command {address} => {((NetCommandHeader*)ptr->Data)->Command}");
				return true;
			}
			return false;
		}

		private unsafe static void QueueAddressUnmap(NetPeerGroup* g, NetConnection* c)
		{
			Assert.Check(c->Status == NetConnectionStatus.Shutdown);
			Assert.Check(c->StateShutdown.Unmapped == 0);
			if (c->StateShutdown.Unmapped == 0 && GetConnectionSendBuffer(g, c, out var b))
			{
				InternalLogStreams.LogTraceNetwork?.Log($"Sending Unmap For: {c->Address}");
				b->Group = -1;
				b->OffsetBits = 0;
				Send(g, c, b);
				c->StateShutdown.Unmapped = 1;
			}
		}

		private unsafe static void ChangeConnectionStatus(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c, NetConnectionStatus status)
		{
			if (c->Status == status)
			{
				return;
			}
			InternalLogStreams.LogTraceNetwork?.Log($"{c->Address} status changed from {c->Status} to {status}");
			c->Status = status;
			if (status == NetConnectionStatus.Shutdown)
			{
				c->StateShutdown.Unmapped = 0;
				c->StateShutdown.Timeout = g->_clock.ElapsedInSeconds + g->_config.ConnectionShutdownTime;
				while (c->NotifySendWindow.Count > 0)
				{
					NetSendEnvelope envelope = c->NotifySendWindow.Peek();
					c->NotifySendWindow.Pop();
					cb.OnNotifyDispose(ref envelope);
					Assert.Always(envelope.UserData == null, (IntPtr)envelope.UserData);
				}
				QueueAddressUnmap(g, c);
			}
		}

		private unsafe static void ReleaseConnection(NetPeerGroup* g, INetPeerGroupCallbacks cb, NetConnection* c)
		{
			Assert.Check(g->_connectionsMap->Find(c->Address) == c);
			g->_connectionsMap->Remove(c->Address);
		}

		private unsafe static NetConnection* AllocateConnection(NetPeerGroup* g, NetAddress address, byte[] token, byte[] uniqueId)
		{
			Assert.Check(uniqueId != null, "UniqueId is required");
			NetConnection* ptr = g->_connectionsMap->Insert(address, uniqueId);
			if (ptr == null)
			{
				return null;
			}
			Assert.Check(ptr->RecvTime == 0.0, "c->RecvTime == 0");
			Assert.Check(ptr->SendTime == 0.0, "c->SendTime == 0");
			Assert.Check(ptr->Rtt == 0.0, "c->Rtt == 0");
			Assert.Check(ptr->NotifySendSequencer.Sequence == 0, "c->NotifySendSequencer.Sequence == 0");
			Assert.Check(ptr->NotifySendWindow.Head == 0, "c->NotifySendWindow.Head == 0");
			Assert.Check(ptr->NotifySendWindow.Tail == 0, "c->NotifySendWindow.Tail == 0");
			Assert.Check(ptr->NotifySendWindow.Count == 0, "c->NotifySendWindow.Count == 0");
			Assert.Check(ptr->NotifyRecvTime == 0.0, "c->NotifyRecvTime == 0");
			Assert.Check(ptr->NotifyRecvMask == 0, "c->NotifyRecvMask == 0");
			Assert.Check(ptr->NotifyRecvSequence == 0, "c->NotifyRecvSequence == 0");
			Assert.Check(ptr->NotifyRecvUnackedCount == 0, "c->NotifyRecvUnackedCount == 0");
			ptr->RecvTime = g->_clock.ElapsedInSeconds;
			ptr->SendTime = ptr->RecvTime;
			ptr->Rtt = g->_config.ConnectionDefaultRtt;
			ptr->Status = NetConnectionStatus.Created;
			if (token != null)
			{
				ptr->ConnectionTokenLength = NetCommandConnect.ClampTokenLength(token.Length);
				ptr->ConnectionToken = (byte*)Native.MallocAndClear(token.Length);
				fixed (byte* source = token)
				{
					Native.MemCpy(ptr->ConnectionToken, source, ptr->ConnectionTokenLength);
				}
			}
			return ptr;
		}
	}
	public enum OnConnectionRequestReply
	{
		Ok,
		Refuse,
		Waiting
	}
	public interface INetPeerGroupCallbacks
	{
		unsafe void OnConnected(NetConnection* connection);

		unsafe void OnDisconnected(NetConnection* connection, NetDisconnectReason reason);

		unsafe void OnUnreliableData(NetConnection* connection, NetBitBuffer* buffer);

		unsafe void OnUnconnectedData(NetBitBuffer* buffer);

		unsafe void OnNotifyData(NetConnection* connection, NetBitBuffer* buffer);

		unsafe void OnNotifyLost(NetConnection* connection, ref NetSendEnvelope envelope);

		unsafe void OnNotifyDelivered(NetConnection* connection, ref NetSendEnvelope envelope);

		void OnNotifyDispose(ref NetSendEnvelope envelope);

		unsafe void OnReliableData(NetConnection* connection, ReliableId id, byte* data);

		OnConnectionRequestReply OnConnectionRequest(NetAddress remoteAddress, byte[] token, byte[] uniqueId);

		void OnConnectionFailed(NetAddress address, NetConnectFailedReason reason);

		unsafe void OnConnectionAttempt(NetConnection* connection, int attempts, int totalConnectAttempts);
	}
	internal struct NetPeerGroupMap
	{
		public enum EntryState
		{
			None,
			Free,
			Used
		}

		public struct Entry
		{
			public unsafe Entry* Next;

			public ulong Hash;

			public EntryState State;

			public NetAddress Address;

			public short Group;
		}

		public unsafe Entry** Buckets;

		public unsafe Entry* Entries;

		public unsafe Entry* FreeHead;

		public ulong UsedCount;

		public ulong FreeCount;

		public ulong CapacityUsable;

		public ulong CapacityAllocated;

		public ulong Count => UsedCount - FreeCount;

		public bool Full => UsedCount == CapacityAllocated;

		public unsafe static void Dispose(ref NetPeerGroupMap* map)
		{
			Native.Free(ref map);
		}

		public unsafe static NetPeerGroupMap* Allocate(int capacity)
		{
			Assert.Check(capacity >= 0);
			int nextPrime = Primes.GetNextPrime(capacity * 2);
			int num = Native.RoundToMaxAlignment(sizeof(NetPeerGroupMap));
			int num2 = Native.RoundToMaxAlignment(sizeof(Entry*) * nextPrime);
			int num3 = Native.RoundToMaxAlignment(sizeof(Entry) * nextPrime);
			byte* ptr = (byte*)Native.MallocAndClear(num + num2 + num3);
			NetPeerGroupMap* ptr2 = (NetPeerGroupMap*)ptr;
			ptr2->Buckets = (Entry**)(ptr + num);
			ptr2->Entries = (Entry*)(ptr + num + num2);
			ptr2->UsedCount = 0uL;
			ptr2->FreeCount = 0uL;
			ptr2->CapacityUsable = (ulong)capacity;
			ptr2->CapacityAllocated = (ulong)nextPrime;
			for (int i = 0; i < capacity; i++)
			{
				ptr2->Entries[i].Group = -1;
			}
			return ptr2;
		}

		public unsafe int Remove(NetAddress address)
		{
			ulong num = NetAddress.Hash64(address);
			ulong num2 = num % CapacityAllocated;
			Entry* ptr = Buckets[num2];
			Entry* ptr2 = default(Entry*);
			while (ptr != null)
			{
				if (ptr->Hash == num && ptr->Address.Block0 == address.Block0 && ptr->Address.Block1 == address.Block1 && ptr->Address.Block2 == address.Block2)
				{
					if (ptr2 == null)
					{
						Buckets[num2] = ptr->Next;
					}
					else
					{
						ptr2->Next = ptr->Next;
					}
					Assert.Check(ptr->State == EntryState.Used);
					short result = ptr->Group;
					*ptr = default(Entry);
					ptr->Group = -1;
					ptr->Next = FreeHead;
					ptr->State = EntryState.Free;
					FreeHead = ptr;
					FreeCount++;
					return result;
				}
				ptr2 = ptr;
				ptr = ptr->Next;
			}
			return -1;
		}

		public unsafe bool Insert(NetAddress address, short group)
		{
			Assert.Check(Find(address) == -1);
			ulong num = NetAddress.Hash64(address);
			ulong num2 = num % CapacityAllocated;
			Entry* ptr;
			if (FreeHead != null)
			{
				Assert.Check(FreeCount != 0);
				ptr = FreeHead;
				FreeHead = ptr->Next;
				FreeCount--;
				Assert.Check(ptr->State == EntryState.Free);
			}
			else
			{
				if (UsedCount == CapacityUsable)
				{
					InternalLogStreams.LogTraceNetwork?.Log("NetPeerGroupMap is full");
					return false;
				}
				ptr = Entries + UsedCount++;
				Assert.Check(ptr->Group == -1);
				Assert.Check(ptr->State == EntryState.None);
				Assert.Check(ptr->Next == null);
			}
			InternalLogStreams.LogTraceNetwork?.Log($"{address.ToString()} mapped to group {group}");
			ptr->Hash = num;
			ptr->Group = group;
			ptr->Address = address;
			ptr->State = EntryState.Used;
			ptr->Next = Buckets[num2];
			Buckets[num2] = ptr;
			return true;
		}

		public unsafe short Find(NetAddress address)
		{
			ulong num = NetAddress.Hash64(address);
			ulong num2 = num % CapacityAllocated;
			for (Entry* ptr = Buckets[num2]; ptr != null; ptr = ptr->Next)
			{
				if (ptr->Hash == num && ptr->Address.Block0 == address.Block0 && ptr->Address.Block1 == address.Block1 && ptr->Address.Block2 == address.Block2)
				{
					return ptr->Group;
				}
			}
			return -1;
		}
	}
	public struct NetSendEnvelope
	{
		public unsafe void* UserData;

		public double SendTime;

		public ushort Sequence;

		internal NetPacketType PacketType;

		[return: NotNull]
		public unsafe T* TakeUserData<T>() where T : unmanaged
		{
			Assert.Always(UserData != null, (IntPtr)UserData);
			T* userData = (T*)UserData;
			UserData = null;
			return userData;
		}
	}
	internal struct NetSendEnvelopeRingBuffer
	{
		private unsafe NetSendEnvelope* _items;

		private int _itemsCapacity;

		public int Head;

		public int Tail;

		public int Count;

		public bool IsFull => Count == _itemsCapacity;

		public bool IsEmpty => Count == 0;

		public unsafe void Push(NetSendEnvelope envelope)
		{
			if (Count == _itemsCapacity)
			{
				throw new InvalidOperationException();
			}
			_items[Head] = envelope;
			Head = (Head + 1) % _itemsCapacity;
			Count++;
		}

		public unsafe bool TryPush(NetSendEnvelope envelope)
		{
			if (Count == _itemsCapacity)
			{
				return false;
			}
			_items[Head] = envelope;
			Head = (Head + 1) % _itemsCapacity;
			Count++;
			return true;
		}

		public unsafe NetSendEnvelope Peek()
		{
			Assert.Check(Count > 0);
			return _items[Tail];
		}

		public void Pop()
		{
			Assert.Check(Count > 0);
			Tail = (Tail + 1) % _itemsCapacity;
			Count--;
		}

		public void Reset()
		{
			Head = 0;
			Tail = 0;
			Count = 0;
		}

		public unsafe void Dispose()
		{
			Native.Free(ref _items);
		}

		public unsafe static NetSendEnvelopeRingBuffer Create(int capacity)
		{
			NetSendEnvelopeRingBuffer result = default(NetSendEnvelopeRingBuffer);
			result.Head = 0;
			result.Tail = 0;
			result.Count = 0;
			result._itemsCapacity = capacity;
			result._items = Native.MallocAndClearArray<NetSendEnvelope>(capacity);
			return result;
		}
	}
	internal struct NetSequencer
	{
		private int _shift;

		private int _bytes;

		private ulong _mask;

		private ulong _sequence;

		public int Bits => _bytes * 8;

		public int Bytes => _bytes;

		public ulong Sequence
		{
			get
			{
				return _sequence;
			}
			set
			{
				Assert.Check(value <= _mask);
				_sequence = value & _mask;
			}
		}

		public void Reset()
		{
			_sequence = 0uL;
		}

		public NetSequencer(int bytes)
		{
			_bytes = bytes;
			_sequence = 0uL;
			_mask = (ulong)((1L << bytes * 8) - 1);
			_shift = (8 - bytes) * 8;
		}

		public ulong Next()
		{
			return _sequence = NextAfter(_sequence);
		}

		public ulong NextAfter(ulong sequence)
		{
			return (sequence + 1) & _mask;
		}

		public int Distance(ulong from, ulong to)
		{
			to <<= _shift;
			from <<= _shift;
			long num = (long)(from - to) >> _shift;
			Assert.Check(num >= int.MinValue && num <= int.MaxValue);
			return (int)num;
		}
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct NetUnreliableHeader
	{
		public const int SIZE = 1;

		public const int SIZE_IN_BITS = 8;

		[FieldOffset(0)]
		public NetPacketType PacketType;

		public static NetUnreliableHeader Create()
		{
			NetUnreliableHeader result = default(NetUnreliableHeader);
			result.PacketType = NetPacketType.UnreliableData;
			return result;
		}
	}
	internal struct ReliableBuffer
	{
		public const int SEQ_BYTES = 4;

		private NetSequencer _sequencer;

		private ReliableList _receiveList;

		private ulong _receiveSequence;

		public int SequenceBits => _sequencer.Bits;

		public static ReliableBuffer Create()
		{
			return new ReliableBuffer
			{
				_sequencer = new NetSequencer(4)
			};
		}

		public ulong NextSendSequence()
		{
			return _sequencer.Next();
		}

		public void Dispose()
		{
			_receiveList.Dispose();
		}

		public unsafe bool LateReceive(out void* root, out ReliableId id, out byte* data)
		{
			for (ReliableHeader* ptr = _receiveList.Head; ptr != null; ptr = ptr->Next)
			{
				if (_sequencer.Distance(ptr->Id.Sequence, _receiveSequence) == 1)
				{
					_receiveSequence = ptr->Id.Sequence;
					_receiveList.Remove(ptr);
					root = ptr;
					id = ptr->Id;
					data = (byte*)ptr + sizeof(ReliableHeader);
					return true;
				}
			}
			id = default(ReliableId);
			root = null;
			data = null;
			return false;
		}

		public unsafe void LateFree(ref void* root)
		{
			Native.Free(ref root);
		}

		public unsafe bool Receive(NetBitBuffer* buffer, out ReliableId rid)
		{
			Assert.Always(sizeof(ReliableHeader) == 64, "ReliableHeader size mismatch {0}", sizeof(ReliableHeader));
			ReliableId reliableId = default(ReliableId);
			buffer->ReadBytesAligned(&reliableId, 48);
			if (_sequencer.Distance(reliableId.Sequence, _receiveSequence) == 1)
			{
				_receiveSequence = reliableId.Sequence;
				rid = reliableId;
				return true;
			}
			Assert.Check(buffer->IsOnEvenByte);
			reliableId.SliceLength = buffer->LengthBytes - buffer->OffsetBytes;
			byte* ptr = (byte*)Native.Malloc(reliableId.SliceLength + sizeof(ReliableHeader));
			Native.MemCpy(ptr + sizeof(ReliableHeader), buffer->PadToByteBoundaryAndGetPtr(), reliableId.SliceLength);
			ReliableHeader* ptr2 = (ReliableHeader*)ptr;
			ptr2->Id = reliableId;
			_receiveList.AddLast(ptr2);
			rid = default(ReliableId);
			return false;
		}
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct ReliableKey
	{
		public const int SIZE = 16;

		[FieldOffset(0)]
		public unsafe fixed byte Data[16];

		public unsafe void GetInts(out int key0, out int key1, out int key2, out int key3)
		{
			ReliableKey reliableKey = this;
			key0 = *(int*)reliableKey.Data;
			key1 = *(int*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reliableKey.Data[4]);
			key2 = *(int*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reliableKey.Data[8]);
			key3 = *(int*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reliableKey.Data[12]);
		}

		public unsafe void GetUlongs(out ulong key0, out ulong key1)
		{
			ReliableKey reliableKey = this;
			key0 = *(ulong*)reliableKey.Data;
			key1 = *(ulong*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reliableKey.Data[8]);
		}

		public unsafe static ReliableKey FromInts(int key0 = 0, int key1 = 0, int key2 = 0, int key3 = 0)
		{
			ReliableKey result = default(ReliableKey);
			*(int*)result.Data = key0;
			*(int*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref result.Data[4]) = key1;
			*(int*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref result.Data[8]) = key2;
			*(int*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref result.Data[12]) = key3;
			return result;
		}

		public unsafe static ReliableKey FromULongs(ulong key0 = 0uL, ulong key1 = 0uL)
		{
			ReliableKey result = default(ReliableKey);
			*(ulong*)result.Data = key0;
			*(ulong*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref result.Data[8]) = key1;
			return result;
		}
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct ReliableId
	{
		public const int SIZE = 48;

		[FieldOffset(0)]
		public ulong Sequence;

		[FieldOffset(8)]
		public int SliceLength;

		[FieldOffset(12)]
		public int TotalLength;

		[FieldOffset(16)]
		public int Source;

		[FieldOffset(20)]
		public int SourceSend;

		[FieldOffset(24)]
		public int Target;

		[FieldOffset(28)]
		public ReliableKey Key;

		[FieldOffset(44)]
		private int _padding;

		public long SourceCombined => ((long)Source << 32) | SourceSend;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct ReliableHeader
	{
		public const int SIZE = 64;

		[FieldOffset(0)]
		public unsafe ReliableHeader* Next;

		[FieldOffset(8)]
		public unsafe ReliableHeader* Prev;

		[FieldOffset(16)]
		public ReliableId Id;

		public unsafe static byte* GetData(ReliableHeader* header)
		{
			Assert.Check(sizeof(ReliableHeader) == 64);
			return (byte*)header + 64;
		}
	}
	public struct ReliableList
	{
		public int Count;

		public unsafe ReliableHeader* Head;

		public unsafe ReliableHeader* Tail;

		public unsafe void AddFirst(ReliableHeader* item)
		{
			Assert.Check(!IsInList(item));
			item->Next = Head;
			item->Prev = null;
			if (Head != null)
			{
				Head->Prev = item;
				Head = item;
			}
			else
			{
				Head = item;
				Tail = item;
			}
			Count++;
		}

		public unsafe void AddLast(ReliableHeader* item)
		{
			Assert.Check(!IsInList(item));
			item->Next = null;
			item->Prev = Tail;
			if (Tail != null)
			{
				Tail->Next = item;
				Tail = item;
			}
			else
			{
				Head = item;
				Tail = item;
			}
			Count++;
		}

		public unsafe void AddBefore(ReliableHeader* before, ReliableHeader* item)
		{
			Assert.Check(Count > 0);
			Assert.Check(IsInList(before));
			Assert.Check(!IsInList(item));
			if (before == Head)
			{
				AddFirst(item);
			}
			else
			{
				item->Next = before;
				item->Prev = before->Prev;
				before->Prev->Next = item;
				before->Prev = item;
				Count++;
			}
			Assert.Check(IsInList(before));
			Assert.Check(IsInList(item));
		}

		public unsafe void AddAfter(ReliableHeader* after, ReliableHeader* item)
		{
			Assert.Check(Count > 0);
			Assert.Check(IsInList(after));
			Assert.Check(!IsInList(item));
			if (after == Tail)
			{
				AddLast(item);
			}
			else
			{
				item->Next = after->Next;
				item->Prev = after;
				after->Next->Prev = item;
				after->Next = item;
				Count++;
			}
			Assert.Check(IsInList(after));
			Assert.Check(IsInList(item));
		}

		public unsafe ReliableHeader* RemoveHead()
		{
			Assert.Check(Count > 0);
			Assert.Check(Head != null);
			Assert.Check(IsInList(Head));
			ReliableHeader* head = Head;
			Remove(head);
			return head;
		}

		public unsafe void Remove(ReliableHeader* item)
		{
			Assert.Check(IsInList(item));
			if (item->Prev != null)
			{
				item->Prev->Next = item->Next;
			}
			if (item->Next != null)
			{
				item->Next->Prev = item->Prev;
			}
			if (item == Tail)
			{
				Tail = item->Prev;
			}
			if (item == Head)
			{
				Head = item->Next;
			}
			item->Prev = null;
			item->Next = null;
			Count--;
		}

		private unsafe bool IsInList(ReliableHeader* item)
		{
			for (ReliableHeader* ptr = Head; ptr != null; ptr = ptr->Next)
			{
				if (ptr == item)
				{
					return true;
				}
			}
			return false;
		}

		public unsafe void Dispose()
		{
			while (Count > 0)
			{
				ReliableHeader* memory = RemoveHead();
				Native.Free(ref memory);
			}
			Assert.Check(Head == null);
			Assert.Check(Tail == null);
		}
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct NetSocket
	{
		[FieldOffset(0)]
		public long Handle;

		[FieldOffset(0)]
		public NanoSockets.Socket NativeSocket;

		public bool IsCreated => NativeSocket.IsCreated;
	}
	public interface INetSocket
	{
		bool SupportsMultiThreading { get; }

		void Initialize(NetConfig config);

		NetSocket Create(NetConfig config);

		NetAddress Bind(NetSocket socket, NetConfig config);

		bool CanFragment(NetAddress address);

		bool Poll(NetSocket socket, long timeout);

		unsafe int Receive(NetSocket socket, NetAddress* address, byte* buffer, int bufferLength);

		unsafe int Send(NetSocket socket, NetAddress* address, byte* buffer, int bufferLength, bool reliable = false);

		void Destroy(NetSocket socket);

		void DeleteEncryptionKey(NetAddress address);

		void SetupEncryption(byte[] key, byte[] encryptedKey);
	}
	internal class NetSocketHybrid : INetSocket
	{
		private NetSocket _relayNetSocketRef;

		private NetAddress _relayAddress;

		private readonly NetSocketRelay _relaySocket;

		private readonly NetSocketNative _nativeSocket;

		private readonly ICommunicator _client;

		public bool SupportsMultiThreading => false;

		public NetSocketHybrid(ICommunicator client)
		{
			_client = client;
			_relaySocket = new NetSocketRelay(_client);
			_nativeSocket = new NetSocketNative();
		}

		public void Initialize(NetConfig config)
		{
			_relaySocket.Initialize(config);
			_nativeSocket.Initialize(config);
		}

		public NetSocket Create(NetConfig config)
		{
			_relayNetSocketRef = _relaySocket.Create(config);
			return _nativeSocket.Create(config);
		}

		public void Destroy(NetSocket netSocket)
		{
			_relaySocket.Destroy(_relayNetSocketRef);
			_nativeSocket.Destroy(netSocket);
		}

		public void DeleteEncryptionKey(NetAddress address)
		{
			_relaySocket.DeleteEncryptionKey(address);
			_nativeSocket.DeleteEncryptionKey(address);
		}

		public void SetupEncryption(byte[] key, byte[] encryptedKey)
		{
			_relaySocket.SetupEncryption(key, encryptedKey);
			_nativeSocket.SetupEncryption(key, encryptedKey);
		}

		public NetAddress Bind(NetSocket socket, NetConfig config)
		{
			_relayAddress = _relaySocket.Bind(_relayNetSocketRef, config);
			return _nativeSocket.Bind(socket, config);
		}

		public bool CanFragment(NetAddress address)
		{
			return address.IsRelayAddr ? _relaySocket.CanFragment(address) : _nativeSocket.CanFragment(address);
		}

		public bool Poll(NetSocket socket, long timeout)
		{
			return _relaySocket.Poll(_relayNetSocketRef, timeout) || _nativeSocket.Poll(socket, timeout);
		}

		public unsafe int Receive(NetSocket socket, NetAddress* address, byte* buffer, int bufferLength)
		{
			Assert.Check(address->Equals(default(NetAddress)), address->ToString());
			int num = _nativeSocket.Receive(socket, address, buffer, bufferLength);
			if (num < 0)
			{
				num = _relaySocket.Receive(_relayNetSocketRef, address, buffer, bufferLength);
			}
			return num;
		}

		public unsafe int Send(NetSocket socket, NetAddress* address, byte* buffer, int bufferLength, bool reliable = false)
		{
			if (address->IsRelayAddr)
			{
				return _relaySocket.Send(_relayNetSocketRef, address, buffer, bufferLength, reliable);
			}
			return _nativeSocket.Send(socket, address, buffer, bufferLength, reliable);
		}
	}
	internal class NetSocketNative : INetSocket
	{
		private EncryptionManager<NetAddress, DataEncryptor> _encryptionManager;

		private EncryptionToken _encryptionToken;

		private NetAddress _remoteEncryptionHandler;

		private unsafe byte* _encryptionBuffer = null;

		private const int EncryptionBufferLength = 2048;

		public bool SupportsMultiThreading => true;

		public void Initialize(NetConfig config)
		{
			Assert.Always(UDP.Initialize() == Status.Ok, "Unable to initialize Socket");
		}

		public NetSocket Create(NetConfig config)
		{
			NanoSockets.Socket socket = UDP.Create(config.SocketSendBuffer, config.SocketRecvBuffer);
			Assert.Always(socket.IsCreated, "Unable to create Socket");
			Assert.Always(UDP.SetNonBlocking(socket) == Status.Ok, "Unable to set Socket as NonBlocking");
			return new NetSocket
			{
				NativeSocket = socket
			};
		}

		public NetAddress Bind(NetSocket socket, NetConfig config)
		{
			Address address = config.Address.NativeAddress;
			if (UDP.Bind(socket.NativeSocket.handle, ref address) != 0)
			{
				UDP.Destroy(ref socket.NativeSocket.handle);
				throw new InvalidOperationException($"Failed to bind socket to {config.Address.NativeAddress}");
			}
			address = default(Address);
			if (UDP.GetAddress(socket.NativeSocket.handle, ref address) != Status.Ok)
			{
				UDP.Destroy(ref socket.NativeSocket.handle);
				throw new InvalidOperationException("Failed to resolve address for bound socket");
			}
			address._address0 = config.Address.NativeAddress._address0;
			address._address1 = config.Address.NativeAddress._address1;
			return new NetAddress
			{
				NativeAddress = address
			};
		}

		public bool CanFragment(NetAddress address)
		{
			return true;
		}

		public bool Poll(NetSocket socket, long timeout)
		{
			return UDP.Poll(socket.NativeSocket.handle, timeout) > 0;
		}

		public unsafe int Receive(NetSocket socket, NetAddress* address, byte* buffer, int bufferLength)
		{
			int received = UDP.Receive(socket.NativeSocket.handle, &address->NativeAddress, buffer, bufferLength);
			if (received > 0 && StunMessage.IsStunMessage(buffer, bufferLength))
			{
				StunClient.TryParseAndStoreStunMessage(address, buffer, received);
				return -1;
			}
			EngineProfiler.Begin("Encryption.Socket.Receive");
			bool flag = HandleEncryptionIngoing(address, ref buffer, bufferLength, ref received);
			EngineProfiler.End();
			if (!flag)
			{
				return -1;
			}
			return received;
		}

		public unsafe int Send(NetSocket socket, NetAddress* address, byte* buffer, int bufferLength, bool reliable = false)
		{
			EngineProfiler.Begin("Encryption.Socket.Send");
			bool flag = HandleEncryptionOutgoing(address, ref buffer, ref bufferLength);
			EngineProfiler.End();
			if (!flag)
			{
				return -1;
			}
			return UDP.Send(socket.NativeSocket.handle, &address->NativeAddress, buffer, bufferLength);
		}

		public void Destroy(NetSocket netSocket)
		{
			ResetEncryption();
			UDP.Destroy(ref netSocket.NativeSocket.handle);
		}

		public unsafe void SetupEncryption(byte[] key, byte[] encryptedKey)
		{
			if (_encryptionManager != null)
			{
				InternalLogStreams.LogTraceEncryption?.Warn("SetupEncryption: already setup, ignoring...");
				return;
			}
			if (key == null || key.Length == 0 || Array.TrueForAll(key, (byte b) => b == 0))
			{
				InternalLogStreams.LogTraceEncryption?.Warn("SetupEncryption: no key, ignoring...");
				return;
			}
			_encryptionManager = new EncryptionManager<NetAddress, DataEncryptor>();
			_encryptionManager.RegisterEncryptionKey(default(NetAddress), key);
			_encryptionToken = new EncryptionToken
			{
				Key = key,
				KeyEncrypted = encryptedKey
			};
			_encryptionBuffer = Native.MallocAndClearArray<byte>(2048);
			InternalLogStreams.LogTraceEncryption?.Log($"SetupEncryption: {_encryptionToken}");
			InternalLogStreams.LogDebug?.Log("Encryption is enabled");
		}

		private unsafe bool HandleEncryptionOutgoing(NetAddress* address, ref byte* buffer, ref int bufferLength)
		{
			if (_encryptionManager != null && bufferLength > 1)
			{
				NetAddress netAddress = *address;
				int num = 0;
				Assert.Check(bufferLength <= 2048, "Buffer is too big");
				Native.MemClear(_encryptionBuffer, 2048);
				Native.MemCpy(_encryptionBuffer, buffer, Math.Min(bufferLength, 2048));
				buffer = _encryptionBuffer;
				if (!_encryptionManager.HasEncryptionForHandle(netAddress))
				{
					InternalLogStreams.LogTraceEncryption?.Warn($"Encryption Handler not found: {netAddress}");
					if (_encryptionToken.KeyEncrypted == null)
					{
						InternalLogStreams.LogTraceEncryption?.Warn("Encryption failed. Invalid encryption handler.");
						return false;
					}
					int num2 = _encryptionToken.KeyEncrypted.Length;
					Assert.Check(num2 <= 255, "KeyEncrypted is too big");
					num = num2 + 1;
					Native.MemMove(buffer + num, buffer, bufferLength);
					*buffer = (byte)num2;
					Native.CopyFromArray(buffer + 1, _encryptionToken.KeyEncrypted);
					_remoteEncryptionHandler = netAddress;
					netAddress = default(NetAddress);
					InternalLogStreams.LogTraceEncryption?.Log($"Sending encrypted key: {netAddress}");
				}
				if (!_encryptionManager.Wrap(netAddress, buffer + num, ref bufferLength, 2048))
				{
					InternalLogStreams.LogTraceEncryption?.Warn("Encryption failed. Unable to wrap data.");
					return false;
				}
				bufferLength += num;
			}
			return true;
		}

		private unsafe bool HandleEncryptionIngoing(NetAddress* address, ref byte* buffer, int bufferLength, ref int received)
		{
			if (_encryptionManager != null && received > 1)
			{
				NetAddress netAddress = *address;
				if (!_encryptionManager.HasEncryptionForHandle(netAddress))
				{
					InternalLogStreams.LogTraceEncryption?.Warn($"Encryption Handler not found: {address->ToString()}/{netAddress}");
					if (_encryptionToken.KeyEncrypted != null)
					{
						if (!_remoteEncryptionHandler.Equals(netAddress))
						{
							InternalLogStreams.LogTraceEncryption?.Warn("Encryption failed. Invalid encryption handler.");
							return false;
						}
						_encryptionManager.RegisterEncryptionKey(netAddress, _encryptionToken.Key);
						_remoteEncryptionHandler = default(NetAddress);
						InternalLogStreams.LogTraceEncryption?.Log($"Encryption Handler registered: {address->ToString()}/{netAddress}");
					}
					else
					{
						int length = *buffer;
						byte* ptr = buffer + 1;
						int num = length + 1;
						if (!_encryptionManager.Unwrap(default(NetAddress), ptr, ref length, length))
						{
							InternalLogStreams.LogTraceEncryption?.Warn("Encryption failed. Unable to unwrap keys.");
							return false;
						}
						byte[] array = new byte[length];
						Native.CopyToArray(array, ptr);
						_encryptionManager.RegisterEncryptionKey(netAddress, array);
						received -= num;
						Native.MemMove(buffer, buffer + num, received);
					}
				}
				if (!_encryptionManager.Unwrap(netAddress, buffer, ref received, bufferLength))
				{
					InternalLogStreams.LogTraceEncryption?.Warn("Encryption failed. Unable to unwrap data.");
					return false;
				}
			}
			return true;
		}

		private unsafe void ResetEncryption()
		{
			InternalLogStreams.LogTraceEncryption?.Log("ResetEncryption");
			_encryptionManager?.Dispose();
			_encryptionManager = null;
			_encryptionToken = null;
			_remoteEncryptionHandler = default(NetAddress);
			Native.Free(ref _encryptionBuffer);
		}

		public void DeleteEncryptionKey(NetAddress address)
		{
			_encryptionManager?.DeleteEncryptionKey(address);
		}
	}
	internal class NetSocketNull : INetSocket
	{
		public bool SupportsMultiThreading { get; }

		public void Initialize(NetConfig config)
		{
		}

		public NetSocket Create(NetConfig config)
		{
			return new NetSocket
			{
				Handle = 1L
			};
		}

		public NetAddress Bind(NetSocket socket, NetConfig config)
		{
			return default(NetAddress);
		}

		public bool CanFragment(NetAddress address)
		{
			return false;
		}

		public bool Poll(NetSocket socket, long timeout)
		{
			return false;
		}

		public unsafe int Receive(NetSocket socket, NetAddress* address, byte* buffer, int bufferLength)
		{
			return 0;
		}

		public unsafe int Send(NetSocket socket, NetAddress* address, byte* buffer, int bufferLength, bool reliable = false)
		{
			return bufferLength;
		}

		public void Destroy(NetSocket netSocket)
		{
		}

		public void DeleteEncryptionKey(NetAddress address)
		{
		}

		public void SetupEncryption(byte[] key, byte[] encryptedKey)
		{
		}
	}
	internal class NetSocketRelay : INetSocket
	{
		private long _handle;

		private readonly ICommunicator _communicator;

		public bool SupportsMultiThreading => false;

		public NetAddress LocalAddress => NetAddress.FromActorId(_communicator.CommunicatorID);

		public NetSocketRelay(ICommunicator communicator)
		{
			_communicator = communicator;
		}

		public NetAddress Bind(NetSocket socket, NetConfig config)
		{
			Assert.Check(socket.Handle == _handle);
			return LocalAddress;
		}

		public bool CanFragment(NetAddress address)
		{
			return true;
		}

		public NetSocket Create(NetConfig config)
		{
			return new NetSocket
			{
				Handle = _handle
			};
		}

		public void Destroy(NetSocket netSocket)
		{
			_handle = 0L;
		}

		public void DeleteEncryptionKey(NetAddress address)
		{
		}

		public void SetupEncryption(byte[] key, byte[] encryptedKey)
		{
		}

		public void Initialize(NetConfig config)
		{
			_handle = Environment.TickCount;
		}

		public bool Poll(NetSocket socket, long timeout)
		{
			Assert.Check(_communicator != null);
			Assert.Check(_handle != 0);
			Assert.Check(_handle == socket.Handle);
			return _communicator.Poll();
		}

		public unsafe int Receive(NetSocket socket, NetAddress* address, byte* buffer, int bufferLength)
		{
			Assert.Check(_communicator != null);
			Assert.Check(_handle != 0);
			Assert.Check(_handle == socket.Handle);
			int senderActor;
			int num = _communicator.ReceivePackage(out senderActor, buffer, bufferLength);
			if (num > 0)
			{
				*address = NetAddress.FromActorId(senderActor);
			}
			return num;
		}

		public unsafe int Send(NetSocket socket, NetAddress* address, byte* buffer, int bufferLength, bool reliable = false)
		{
			Assert.Check(_communicator != null);
			Assert.Check(_handle != 0);
			Assert.Check(_handle == socket.Handle);
			if (address->IsRelayAddr && _communicator != null && _communicator.SendPackage(101, address->ActorId, reliable, buffer, bufferLength))
			{
				return bufferLength;
			}
			return -1;
		}
	}
}
namespace Fusion.Sockets.Stun
{
	public enum NATType : byte
	{
		Invalid = 0,
		UdpBlocked = 1,
		OpenInternet = 2,
		FullCone = 4,
		Symmetric = 8
	}
	internal static class StunNatTypeExtensions
	{
		public static bool IsValid(this NATType natType)
		{
			switch (natType)
			{
			case NATType.Invalid:
			case NATType.UdpBlocked:
				return false;
			case NATType.OpenInternet:
			case NATType.FullCone:
			case NATType.Symmetric:
				return true;
			default:
				return false;
			}
		}
	}
	internal static class StunClient
	{
		private static class TestIPs
		{
			public static readonly IPEndPoint TestNetIpv4 = new IPEndPoint(IPAddress.Parse("203.0.113.0"), 65530);

			public static readonly IPEndPoint TestNetIpv6 = new IPEndPoint(IPAddress.Parse("2001:db8::"), 65530);
		}

		private static readonly ConcurrentDictionary<Guid, ConcurrentDictionary<int, NetAddress>> PendingRequests = new ConcurrentDictionary<Guid, ConcurrentDictionary<int, NetAddress>>();

		public static void Reset()
		{
			PendingRequests.Clear();
		}

		public static async Task<StunResult> QueryReflexiveInfo(NetAddress boundLocalAddress, Func<byte[], NetAddress, bool> sendDataViaSocket, NetAddress? customPublicAddress, string customStunServer = null, bool extendedAttempts = false, Func<bool> keepRunning = null)
		{
			if (QueryLocalAddress(boundLocalAddress, out var localAddressFamily, out var localAddress))
			{
				InternalLogStreams.LogTraceStun?.Log($"Local Address: {localAddress}");
				NetAddress publicAddr1 = NetAddress.AnyIPv4Addr;
				NetAddress publicAddr2 = NetAddress.AnyIPv4Addr;
				if (customPublicAddress.HasValue)
				{
					NetAddress value;
					publicAddr2 = (value = customPublicAddress.Value);
					publicAddr1 = value;
					InternalLogStreams.LogDebug?.Log($"[STUN] Bypass Reflexive Info discovery, using {publicAddr1}");
				}
				else
				{
					await StunServers.SetupStunServers(customStunServer);
					int debugMultiplier = ((!extendedAttempts) ? 1 : 10);
					int stunTimeout = 1500 * debugMultiplier;
					Guid requestID = Guid.Empty;
					Stopwatch queryWatch = Stopwatch.StartNew();
					Stopwatch attemptWatch = Stopwatch.StartNew();
					while ((keepRunning == null || keepRunning()) && queryWatch.ElapsedMilliseconds < stunTimeout && (publicAddr1.Equals(NetAddress.AnyIPv4Addr) || publicAddr2.Equals(NetAddress.AnyIPv4Addr)))
					{
						if (QueryPublicAddress(sendDataViaSocket, localAddressFamily, ref requestID, out var skipNATDiscovery))
						{
							InternalLogStreams.LogTraceStun?.Log($"Request sent with ID: {requestID}");
							PendingRequests.TryAdd(requestID, new ConcurrentDictionary<int, NetAddress>());
							attemptWatch.Restart();
							while (attemptWatch.ElapsedMilliseconds < 150)
							{
								await TaskManager.Delay(15);
								if (PendingRequests.TryGetValue(requestID, out var addresses) && addresses.Count > 0)
								{
									NetAddress[] publicAddresses = addresses.Values.ToArray();
									if (publicAddresses.Length >= 1 && publicAddr1.Equals(NetAddress.AnyIPv4Addr))
									{
										publicAddr1 = publicAddresses[0];
										if (skipNATDiscovery)
										{
											publicAddr2 = publicAddr1;
										}
									}
									if (publicAddresses.Length >= 2 && publicAddr2.Equals(NetAddress.AnyIPv4Addr))
									{
										publicAddr2 = publicAddresses[1];
									}
									if (!publicAddr1.Equals(NetAddress.AnyIPv4Addr) && !publicAddr2.Equals(NetAddress.AnyIPv4Addr))
									{
										break;
									}
								}
								addresses = null;
							}
							continue;
						}
						InternalLogStreams.LogDebug?.Warn("[STUN] Unable to send STUN Requests to any STUN Server, aborting.");
						break;
					}
					if (queryWatch.ElapsedMilliseconds > stunTimeout)
					{
						InternalLogStreams.LogDebug?.Log("[STUN] Timeout reached, aborting STUN Query.");
					}
					PendingRequests.TryRemove(requestID, out var _);
				}
				if (publicAddr1.Equals(NetAddress.AnyIPv4Addr) && publicAddr2.Equals(NetAddress.AnyIPv4Addr) && boundLocalAddress.IsIPv6)
				{
					InternalLogStreams.LogDebug?.Log("[STUN] Fallback to using Local Address as Public Address (IPv6)");
					NetAddress value;
					publicAddr2 = (value = boundLocalAddress);
					publicAddr1 = value;
				}
				return StunResult.BuildStunResult(publicAddr1, publicAddr2, localAddress);
			}
			InternalLogStreams.LogDebug?.Warn("[STUN] Unable to resolve Local Address");
			return StunResult.Invalid;
		}

		public unsafe static bool TryParseAndStoreStunMessage(NetAddress* origin, byte* buffer, int bufferLength)
		{
			StunMessage stunMessage = StunMessage.TryParse(buffer, bufferLength);
			if (stunMessage?.MappedAddress == null)
			{
				InternalLogStreams.LogTraceStun?.Log("Invalid STUN Message, no Mapped Address found.");
				return false;
			}
			if (PendingRequests.TryGetValue(stunMessage.ID, out var value))
			{
				int port = stunMessage.MappedAddress.Port;
				string ip = stunMessage.MappedAddress.Address.ToString();
				NetAddress value2 = NetAddress.CreateFromIpPort(ip, (ushort)port);
				if (value2.IsValid && value.TryAdd(origin->GetHashCode(), value2))
				{
					InternalLogStreams.LogTraceStun?.Log($"Reply received (ID={stunMessage.ID}, STUN Server={origin->NativeAddress}): {value2.NativeAddress}");
					return true;
				}
			}
			InternalLogStreams.LogTraceStun?.Log($"Capture STUN Message from {origin->NativeAddress}");
			return true;
		}

		private static bool QueryLocalAddress(NetAddress boundLocalAddress, out AddressFamily addressFamily, out NetAddress localAddress)
		{
			AddressFamily addressFamily2 = (boundLocalAddress.IsIPv6 ? AddressFamily.InterNetworkV6 : AddressFamily.InterNetwork);
			if (boundLocalAddress.HasAddress)
			{
				InternalLogStreams.LogTraceStun?.Log($"Using Local Address ({boundLocalAddress}");
				localAddress = boundLocalAddress;
				addressFamily = addressFamily2;
				return true;
			}
			localAddress = NetAddress.AnyIPv4Addr;
			addressFamily = addressFamily2;
			InternalLogStreams.LogTraceStun?.Log($"Resolving Local Address ({addressFamily2})");
			if (GetLocalAddress(ref addressFamily, out var localIP))
			{
				if (addressFamily != addressFamily2)
				{
					InternalLogStreams.LogTraceStun?.Warn($"No Address of Family {addressFamily2} found, changed to {addressFamily}");
				}
				try
				{
					NetAddress netAddress = NetAddress.CreateFromIpPort(localIP.ToString(), boundLocalAddress.NativeAddress.Port);
					if (netAddress.IsValid)
					{
						localAddress = netAddress;
						return true;
					}
				}
				catch
				{
				}
			}
			InternalLogStreams.LogWarn?.Log("[STUN] Unable to resolve Local Address");
			return false;
		}

		private static bool QueryPublicAddress(Func<byte[], NetAddress, bool> sendAnyData, AddressFamily originalFamily, ref Guid requestID, out bool skipNATDiscovery)
		{
			skipNATDiscovery = false;
			if (sendAnyData == null)
			{
				return false;
			}
			bool flag = originalFamily == AddressFamily.InterNetworkV6;
			List<StunServers.StunServer> stunServer = StunServers.GetStunServer(flag);
			if (stunServer.Count == 0)
			{
				InternalLogStreams.LogWarn?.Log("[STUN] Unable to find any valid STUN Server, aborting Reflexive Address query.");
				return false;
			}
			if (stunServer.Count == 1)
			{
				InternalLogStreams.LogDebug?.Log("[STUN] Only one STUN Server found, skip NAT Type Discovery.");
				skipNATDiscovery = true;
			}
			StunMessage stunMessage = new StunMessage(requestID);
			byte[] arg = stunMessage.Serialize();
			bool flag2 = false;
			foreach (StunServers.StunServer item in stunServer)
			{
				try
				{
					NetAddress netAddress = (flag ? item.IPv6Addr : item.IPv4Addr);
					if (netAddress.IsValid)
					{
						if (sendAnyData(arg, netAddress))
						{
							flag2 = true;
							InternalLogStreams.LogTraceStun?.Log($"Request sent to {netAddress}");
						}
						else
						{
							InternalLogStreams.LogTraceStun?.Warn($"Unable to send request to {netAddress}");
						}
					}
				}
				catch (Exception message)
				{
					InternalLogStreams.LogTraceStun?.Error(message);
				}
			}
			if (!flag2)
			{
				return false;
			}
			requestID = stunMessage.ID;
			return true;
		}

		private static bool GetLocalAddress(ref AddressFamily addressFamily, out IPAddress localIP)
		{
			localIP = IPAddress.None;
			try
			{
				using System.Net.Sockets.Socket socket = new System.Net.Sockets.Socket(addressFamily, SocketType.Dgram, ProtocolType.IP);
				socket.Connect((addressFamily == AddressFamily.InterNetwork) ? TestIPs.TestNetIpv4 : TestIPs.TestNetIpv6);
				localIP = ((IPEndPoint)socket.LocalEndPoint).Address;
			}
			catch
			{
				if (addressFamily != AddressFamily.InterNetworkV6)
				{
					return false;
				}
				addressFamily = AddressFamily.InterNetwork;
				InternalLogStreams.LogTraceStun?.Warn("No Address of Family InterNetworkV6 found, changed to InterNetwork");
				return GetLocalAddress(ref addressFamily, out localIP);
			}
			return !localIP.Equals(IPAddress.None);
		}
	}
	internal class StunErrorAttribute
	{
		public int Code { get; set; } = 0;

		public string ReasonText { get; set; } = "";

		public StunErrorAttribute(int code, string reasonText)
		{
			Code = code;
			ReasonText = reasonText;
		}
	}
	internal class StunMessage
	{
		public enum StunMessageType
		{
			BindingRequest = 1,
			BindingResponse = 257,
			BindingErrorResponse = 273,
			SharedSecretRequest = 2,
			SharedSecretResponse = 258,
			SharedSecretErrorResponse = 274
		}

		private enum AttributeType
		{
			MappedAddress = 1,
			Username = 6,
			MessageIntegrity = 8,
			ErrorCode = 9,
			UnknownAttribute = 10,
			Realm = 20,
			Nonce = 21,
			XorMappedAddress = 32
		}

		internal static class StunDefines
		{
			public const int STUN_MAGIC_COOKIE = 554869826;

			public const ulong STUN_MAGIC_COOKIE_NETWORK_ORDER = 1118048801uL;

			public const short STUN_MAGIC_COOKIE_PARTIAL = 8466;

			public const int STUN_XOR_FINGERPRINT = 1398035790;

			public const int HEADER_SIZE = 20;

			public const int TRANSACTION_ID_SIZE = 12;
		}

		private enum IPFamily
		{
			IPv4 = 1,
			IPv6
		}

		private Guid _id = Guid.Empty;

		private static HashSet<int> _stunMessageTypeValues;

		private static HashSet<int> StunMessageTypeValues
		{
			get
			{
				if (_stunMessageTypeValues == null)
				{
					_stunMessageTypeValues = new HashSet<int>();
					foreach (object value in Enum.GetValues(typeof(StunMessageType)))
					{
						_stunMessageTypeValues.Add((int)value);
					}
				}
				return _stunMessageTypeValues;
			}
		}

		public StunMessageType Type { get; private set; }

		public Guid ID
		{
			get
			{
				if (_id.Equals(Guid.Empty))
				{
					byte[] array = new byte[16];
					Array.Copy(TransactionID, array, 12);
					_id = new Guid(array);
				}
				return _id;
			}
		}

		private byte[] TransactionID { get; set; }

		public IPEndPoint MappedAddress
		{
			get
			{
				if (Attributes.TryGetValue(AttributeType.MappedAddress, out var value))
				{
					return value as IPEndPoint;
				}
				return null;
			}
			set
			{
				Attributes[AttributeType.MappedAddress] = value;
			}
		}

		public string UserName { get; set; } = null;

		public StunErrorAttribute ErrorCode { get; set; } = null;

		private Dictionary<AttributeType, object> Attributes { get; set; }

		public StunMessage(Guid msgID, StunMessageType messageType = StunMessageType.BindingRequest)
		{
			Type = messageType;
			TransactionID = new byte[12];
			Array.Copy(msgID.Equals(Guid.Empty) ? Guid.NewGuid().ToByteArray() : msgID.ToByteArray(), TransactionID, 12);
			Attributes = new Dictionary<AttributeType, object>();
		}

		public unsafe static bool IsStunMessage(byte* data, int length)
		{
			if (length <= 0 || length < 20)
			{
				InternalLogStreams.LogTraceStun?.Log("Invalid STUN Message Size");
				return false;
			}
			int num = (*data << 8) | data[1];
			int num2 = (data[4] << 24) | (data[5] << 16) | (data[6] << 8) | data[7];
			bool flag = num2 == 554869826 && (num & 0xC000) == 0 && StunMessageTypeValues.Contains(num);
			InternalLogStreams.LogTraceStun?.Log($"STUN Message Type: {num}, Magic Cookie: {num2}, Result: {flag}");
			return flag;
		}

		public unsafe static StunMessage TryParse(byte* data, int length)
		{
			if (length <= 0 || length < 20)
			{
				return null;
			}
			int offset = 0;
			int num = (data[offset++] << 8) | data[offset++];
			if ((num & 0xC000) == 0 && Enum.IsDefined(typeof(StunMessageType), num))
			{
				StunMessageType type = (StunMessageType)num;
				int num2 = (data[offset++] << 8) | data[offset++];
				int num3 = (data[offset++] << 24) | (data[offset++] << 16) | (data[offset++] << 8) | data[offset++];
				if (num3 != 554869826)
				{
					return null;
				}
				StunMessage stunMessage = new StunMessage(Guid.Empty);
				stunMessage.Type = type;
				stunMessage.TransactionID = new byte[12];
				StunMessage stunMessage2 = stunMessage;
				for (int i = 0; i < 12; i++)
				{
					stunMessage2.TransactionID[i] = data[offset++];
				}
				while (offset - 20 < num2)
				{
					stunMessage2.ReadAttribute(data, ref offset);
				}
				return stunMessage2;
			}
			return null;
		}

		public byte[] Serialize()
		{
			byte[] array = new byte[512];
			int num = 0;
			array[num++] = (byte)((int)Type >> 8);
			array[num++] = (byte)(Type & (StunMessageType)255);
			int num2 = num;
			array[num++] = 0;
			array[num++] = 0;
			array[num++] = 33;
			array[num++] = 18;
			array[num++] = 164;
			array[num++] = 66;
			Array.Copy(TransactionID, 0, array, num, 12);
			num += 12;
			WriteAttributes(array, ref num);
			int num3 = num - 20;
			array[num2++] = (byte)(num3 >> 8);
			array[num2++] = (byte)(num3 & 0xFF);
			byte[] array2 = new byte[num];
			Array.Copy(array, array2, array2.Length);
			return array2;
		}

		private void WriteAttributes(byte[] msg, ref int offset)
		{
			foreach (KeyValuePair<AttributeType, object> attribute in Attributes)
			{
				switch (attribute.Key)
				{
				case AttributeType.MappedAddress:
					StoreEndPoint(AttributeType.MappedAddress, (IPEndPoint)attribute.Value, msg, ref offset);
					break;
				case AttributeType.Username:
				{
					byte[] bytes2 = Encoding.ASCII.GetBytes((string)attribute.Value);
					msg[offset++] = 0;
					msg[offset++] = 6;
					msg[offset++] = (byte)(bytes2.Length >> 8);
					msg[offset++] = (byte)(bytes2.Length & 0xFF);
					Array.Copy(bytes2, 0, msg, offset, bytes2.Length);
					offset += bytes2.Length;
					break;
				}
				case AttributeType.ErrorCode:
				{
					byte[] bytes = Encoding.ASCII.GetBytes(ErrorCode.ReasonText);
					msg[offset++] = 0;
					msg[offset++] = 9;
					msg[offset++] = 0;
					msg[offset++] = (byte)(4 + bytes.Length);
					msg[offset++] = 0;
					msg[offset++] = 0;
					msg[offset++] = (byte)Math.Floor((double)(ErrorCode.Code / 100));
					msg[offset++] = (byte)(ErrorCode.Code & 0xFF);
					Array.Copy(bytes, msg, bytes.Length);
					offset += bytes.Length;
					break;
				}
				}
			}
		}

		private unsafe void ReadAttribute(byte* data, ref int offset)
		{
			AttributeType attributeType = (AttributeType)((data[offset++] << 8) | data[offset++]);
			int num = (data[offset++] << 8) | data[offset++];
			int num2 = offset;
			try
			{
				switch (attributeType)
				{
				case AttributeType.XorMappedAddress:
					InternalLogStreams.LogTraceStun?.Log("AttributeType.XorMappedAddress");
					MappedAddress = ParseXorEndPoint(data, ref offset);
					break;
				case AttributeType.MappedAddress:
					InternalLogStreams.LogTraceStun?.Log("AttributeType.MappedAddress");
					MappedAddress = ParseEndPoint(data, ref offset);
					break;
				case AttributeType.UnknownAttribute:
					InternalLogStreams.LogTraceStun?.Error("UnknownAttribute");
					break;
				}
			}
			catch (Exception message)
			{
				InternalLogStreams.LogDebug?.Error(message);
			}
			offset = num2 + num;
		}

		private unsafe IPEndPoint ParseEndPoint(byte* data, ref int offset)
		{
			offset++;
			byte b = data[offset++];
			int port = (data[offset++] << 8) | data[offset++];
			return new IPEndPoint(new IPAddress(new byte[4]
			{
				data[offset++],
				data[offset++],
				data[offset++],
				data[offset++]
			}), port);
		}

		private unsafe IPEndPoint ParseXorEndPoint(byte* data, ref int offset)
		{
			offset++;
			IPFamily iPFamily = (IPFamily)data[offset++];
			int num = (data[offset++] << 8) | data[offset++];
			num ^= 0x2112;
			switch (iPFamily)
			{
			case IPFamily.IPv4:
			{
				byte[] array2 = new byte[4]
				{
					data[offset++],
					data[offset++],
					data[offset++],
					data[offset++]
				};
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(array2);
				}
				uint num6 = BitConverter.ToUInt32(array2, 0);
				num6 ^= 0x2112A442;
				byte[] bytes3 = BitConverter.GetBytes(num6);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(bytes3);
				}
				num6 = BitConverter.ToUInt32(bytes3, 0);
				return new IPEndPoint(num6, num);
			}
			case IPFamily.IPv6:
			{
				ulong num2 = ((ulong)data[offset++] << 56) | ((ulong)data[offset++] << 48) | ((ulong)data[offset++] << 40) | ((ulong)data[offset++] << 32) | ((ulong)data[offset++] << 24) | ((ulong)data[offset++] << 16) | ((ulong)data[offset++] << 8) | data[offset++];
				ulong num3 = ((ulong)data[offset++] << 56) | ((ulong)data[offset++] << 48) | ((ulong)data[offset++] << 40) | ((ulong)data[offset++] << 32) | ((ulong)data[offset++] << 24) | ((ulong)data[offset++] << 16) | ((ulong)data[offset++] << 8) | data[offset++];
				ulong num4 = BitConverter.ToUInt32(TransactionID, 0);
				ulong num5 = BitConverter.ToUInt64(TransactionID, 4);
				num4 = (num4 << 32) | 0x42A41221;
				ulong value = num2 ^ num4;
				ulong value2 = num3 ^ num5;
				byte[] bytes = BitConverter.GetBytes(value);
				byte[] bytes2 = BitConverter.GetBytes(value2);
				byte[] array = new byte[16];
				Array.Copy(bytes, 0, array, 0, bytes.Length);
				Array.Copy(bytes2, 0, array, 8, bytes2.Length);
				return new IPEndPoint(new IPAddress(array), num);
			}
			default:
				return null;
			}
		}

		private void StoreEndPoint(AttributeType type, IPEndPoint endPoint, byte[] message, ref int offset)
		{
			message[offset++] = (byte)((int)type >> 8);
			message[offset++] = (byte)(type & (AttributeType)255);
			message[offset++] = 0;
			message[offset++] = 8;
			message[offset++] = 0;
			message[offset++] = 1;
			message[offset++] = (byte)(endPoint.Port >> 8);
			message[offset++] = (byte)(endPoint.Port & 0xFF);
			byte[] addressBytes = endPoint.Address.GetAddressBytes();
			message[offset++] = addressBytes[0];
			message[offset++] = addressBytes[0];
			message[offset++] = addressBytes[0];
			message[offset++] = addressBytes[0];
		}
	}
	internal class StunResult
	{
		public NATType NatType = NATType.Invalid;

		public static readonly StunResult Invalid = new StunResult(NetAddress.AnyIPv4Addr, NetAddress.AnyIPv4Addr);

		public bool IsValid => PublicEndPoint.IsValid && PrivateEndPoint.IsValid;

		public NetAddress PublicEndPoint { get; private set; } = default(NetAddress);

		public NetAddress PrivateEndPoint { get; private set; } = default(NetAddress);

		private StunResult(NetAddress publicEndPoint = default(NetAddress), NetAddress privateEndPoint = default(NetAddress))
		{
			PublicEndPoint = publicEndPoint;
			PrivateEndPoint = privateEndPoint;
		}

		public static StunResult BuildStunResult(NetAddress publicEndPoint1, NetAddress publicEndPoint2, NetAddress privateEndPoint)
		{
			StunResult stunResult = new StunResult(publicEndPoint1, privateEndPoint)
			{
				NatType = NATType.Invalid
			};
			if (publicEndPoint1.Equals(NetAddress.AnyIPv4Addr) && publicEndPoint2.Equals(NetAddress.AnyIPv4Addr))
			{
				stunResult.NatType = NATType.UdpBlocked;
			}
			else if (publicEndPoint1.Equals(privateEndPoint))
			{
				stunResult.NatType = NATType.OpenInternet;
			}
			else if (publicEndPoint1.Equals(publicEndPoint2))
			{
				stunResult.NatType = NATType.FullCone;
			}
			else
			{
				stunResult.NatType = NATType.Symmetric;
			}
			return stunResult;
		}

		public override string ToString()
		{
			return string.Format("[{0}: {1}={2}, {3}={4}, {5}={6}]", "StunResult", "PublicEndPoint", PublicEndPoint, "PrivateEndPoint", PrivateEndPoint, "NatType", NatType);
		}
	}
	internal static class StunServers
	{
		public class StunServer
		{
			private sealed class Pv4AddrEqualityComparer : IEqualityComparer<StunServer>
			{
				public bool Equals(StunServer x, StunServer y)
				{
					if (x == y)
					{
						return true;
					}
					if (x == null)
					{
						return false;
					}
					if (y == null)
					{
						return false;
					}
					if (x.GetType() != y.GetType())
					{
						return false;
					}
					return x.IPv4Addr.Equals(y.IPv4Addr);
				}

				public int GetHashCode(StunServer obj)
				{
					return obj.IPv4Addr.GetHashCode();
				}
			}

			public NetAddress IPv4Addr;

			public NetAddress IPv6Addr;

			public bool HasIPv4Support => IPv4Addr.IsValid;

			public bool HasIPv6Support => IPv6Addr.IsValid;

			public static IEqualityComparer<StunServer> StunServerEqualityComparer { get; } = new Pv4AddrEqualityComparer();

			public override string ToString()
			{
				return string.Format("[{0}: {1}: {2}, {3}: {4}]", "StunServer", "IPv4Addr", IPv4Addr, "IPv6Addr", IPv6Addr);
			}
		}

		private static readonly string[] DefaultStunServerList;

		private static volatile StunServer[] _stunServers;

		private static volatile bool _runningResolution;

		static StunServers()
		{
			DefaultStunServerList = new string[4] { "stun1.l.google.com:19302", "stun2.l.google.com:19302", "stun3.l.google.com:19302", "stun4.l.google.com:19302" };
		}

		public static List<StunServer> GetStunServer(bool IPv6Support)
		{
			List<StunServer> list = new List<StunServer>();
			if (_stunServers == null)
			{
				return list;
			}
			StunServer[] stunServers = _stunServers;
			foreach (StunServer stunServer in stunServers)
			{
				if (stunServer != null && stunServer.HasIPv4Support && (!IPv6Support || stunServer.HasIPv6Support))
				{
					list.Add(stunServer);
				}
			}
			return list;
		}

		public static async Task SetupStunServers(string customStunServer = null)
		{
			while (_runningResolution)
			{
				await TaskManager.Delay(10);
			}
			if (_stunServers != null)
			{
				return;
			}
			_runningResolution = true;
			HashSet<StunServer> stunServers = new HashSet<StunServer>(StunServer.StunServerEqualityComparer);
			customStunServer = customStunServer?.Trim();
			if (!string.IsNullOrEmpty(customStunServer))
			{
				string[] customStunServers = (from s in customStunServer.Split(';')
					select s.Trim()).ToArray();
				string[] array = customStunServers;
				foreach (string stunServerAddress in array)
				{
					StunServer customStunServerResolved = await ResolveStunServerInfo(stunServerAddress);
					if (customStunServerResolved != null)
					{
						stunServers.Add(customStunServerResolved);
					}
				}
			}
			if (_stunServers == null)
			{
				string[] defaultStunServerList = DefaultStunServerList;
				foreach (string stunServerAddress2 in defaultStunServerList)
				{
					StunServer server = await ResolveStunServerInfo(stunServerAddress2);
					if (server != null)
					{
						stunServers.Add(server);
					}
				}
				_stunServers = stunServers.ToArray();
			}
			_runningResolution = false;
		}

		private static async Task<StunServer> ResolveStunServerInfo(string stunServerAddress)
		{
			if (string.IsNullOrEmpty(stunServerAddress))
			{
				return null;
			}
			string[] addressParts = stunServerAddress.Split(':');
			if (addressParts.Length == 2 && ushort.TryParse(addressParts[1], out var port) && port != 0)
			{
				string ipOrName = addressParts[0];
				StunServer stunServer = new StunServer();
				if (IPAddress.TryParse(ipOrName, out var address))
				{
					NetAddress netAddress = NetAddress.CreateFromIpPort(address.ToString(), port);
					if (address.AddressFamily == AddressFamily.InterNetwork)
					{
						stunServer.IPv4Addr = netAddress;
					}
				}
				else
				{
					try
					{
						IPAddress[] array = await Dns.GetHostAddressesAsync(ipOrName);
						foreach (IPAddress serverAddress in array)
						{
							InternalLogStreams.LogTraceStun?.Log($"Server {ipOrName} IP: {serverAddress}");
							if (!IPAddress.IsLoopback(serverAddress))
							{
								if (stunServer.IPv4Addr.Equals(default(NetAddress)) && serverAddress.AddressFamily == AddressFamily.InterNetwork)
								{
									stunServer.IPv4Addr = NetAddress.CreateFromIpPort(serverAddress.ToString(), port);
								}
								if (stunServer.IPv6Addr.Equals(default(NetAddress)) && serverAddress.AddressFamily == AddressFamily.InterNetworkV6)
								{
									stunServer.IPv6Addr = NetAddress.CreateFromIpPort(serverAddress.ToString(), port);
								}
								if (!stunServer.IPv4Addr.Equals(default(NetAddress)) && !stunServer.IPv6Addr.Equals(default(NetAddress)))
								{
									break;
								}
							}
						}
					}
					catch (Exception)
					{
					}
				}
				if (stunServer.HasIPv4Support)
				{
					InternalLogStreams.LogTraceStun?.Log($"Server {ipOrName} resolved as {stunServer}");
					return stunServer;
				}
				InternalLogStreams.LogTraceStun?.Warn("Unable to resolve Address for " + ipOrName);
				return null;
			}
			InternalLogStreams.LogTraceStun?.Warn("Unable to parse STUN Server Address");
			return null;
		}
	}
}
namespace Fusion.Encryption
{
	public class DataEncryptor : IDataEncryption, IDisposable
	{
		private const int TempBufferLength = 4096;

		private const int AesKeySize = 32;

		private const int HMACKeySize = 32;

		private const int IVSize = 16;

		private const int HASHSize = 32;

		private Aes _cryptoProvider;

		private HMACSHA256 _hmacsha256;

		private RandomNumberGenerator _rng;

		private byte[] _encryptBufferEncrypt;

		private byte[] _encryptBufferDecrypt;

		private byte[] _aesKey;

		private readonly byte[] _ivEncryptBuffer = new byte[16];

		private readonly byte[] _ivDecryptBuffer = new byte[16];

		public void Setup(byte[] key)
		{
			Assert.Check(key.Length == 64, "key.Length == AesKeySize + HMACKeySize");
			_aesKey = new byte[32];
			byte[] array = new byte[32];
			Buffer.BlockCopy(key, 0, _aesKey, 0, 32);
			Buffer.BlockCopy(key, 32, array, 0, 32);
			_cryptoProvider = BuildAesProvider(_aesKey);
			_hmacsha256 = BuildHMACSHA256(array);
			_rng = RandomNumberGenerator.Create();
			_encryptBufferEncrypt = new byte[4096];
			_encryptBufferDecrypt = new byte[4096];
		}

		public byte[] GenerateKey()
		{
			byte[] array = new byte[64];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			return array;
		}

		public unsafe bool EncryptData(byte* buffer, ref int bufferLength, int capacity)
		{
			if (buffer == null || bufferLength == 0 || capacity == 0)
			{
				InternalLogStreams.LogTraceEncryption?.Warn("Unable to encrypt data, invalid buffer");
				return false;
			}
			if (_cryptoProvider == null)
			{
				InternalLogStreams.LogTraceEncryption?.Warn("Encryption Provider was not initialized");
				return false;
			}
			byte[] bufferEncrypt = GetBufferEncrypt();
			if (bufferEncrypt == null)
			{
				InternalLogStreams.LogTraceEncryption?.Warn("Unable to allocate memory for encryption");
				return false;
			}
			int num;
			using (UnmanagedMemoryStream unmanagedMemoryStream = new UnmanagedMemoryStream(buffer, bufferLength))
			{
				using MemoryStream memoryStream = new MemoryStream(bufferEncrypt, writable: true);
				_rng.GetBytes(_ivEncryptBuffer);
				memoryStream.Write(_ivEncryptBuffer, 0, _ivEncryptBuffer.Length);
				Assert.Check(16 == memoryStream.Position, "IVSize == memoryStream.Position");
				using ICryptoTransform transform = _cryptoProvider.CreateEncryptor(_aesKey, _ivEncryptBuffer);
				using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
				unmanagedMemoryStream.CopyTo(cryptoStream, bufferLength);
				cryptoStream.FlushFinalBlock();
				num = (int)memoryStream.Position;
			}
			Assert.Check(capacity >= num, "Unable to copy result, original buffer is too short. {0} vs {1}", capacity, num);
			fixed (byte* source = bufferEncrypt)
			{
				Native.MemCpy(buffer, source, num);
			}
			bufferLength = num;
			return true;
		}

		public unsafe bool DecryptData(byte* buffer, ref int bufferLength, int capacity)
		{
			if (buffer == null || bufferLength == 0 || capacity == 0)
			{
				InternalLogStreams.LogTraceEncryption?.Warn("Unable to encrypt data, invalid buffer");
				return false;
			}
			if (_cryptoProvider == null)
			{
				InternalLogStreams.LogTraceEncryption?.Warn("Encryption Provider was not initialized");
				return false;
			}
			byte[] bufferDecrypt = GetBufferDecrypt();
			if (bufferDecrypt == null)
			{
				InternalLogStreams.LogTraceEncryption?.Warn("Unable to allocate memory for encryption");
				return false;
			}
			int num2;
			using (UnmanagedMemoryStream unmanagedMemoryStream = new UnmanagedMemoryStream(buffer, bufferLength))
			{
				int num = unmanagedMemoryStream.Read(_ivDecryptBuffer, 0, 16);
				Assert.Check(num == 16, "read == IVSize");
				bufferLength -= 16;
				using MemoryStream memoryStream = new MemoryStream(bufferDecrypt, writable: true);
				using ICryptoTransform transform = _cryptoProvider.CreateDecryptor(_aesKey, _ivDecryptBuffer);
				using CryptoStream cryptoStream = new CryptoStream(unmanagedMemoryStream, transform, CryptoStreamMode.Read);
				cryptoStream.CopyTo(memoryStream, bufferLength);
				num2 = (int)memoryStream.Position;
			}
			Assert.Check(capacity >= num2, "Unable to copy result, original buffer is too short");
			fixed (byte* source = bufferDecrypt)
			{
				Native.MemCpy(buffer, source, num2);
			}
			bufferLength = num2;
			return true;
		}

		public unsafe bool ComputeHash(byte* buffer, ref int bufferLength, int capacity)
		{
			if (_hmacsha256 == null)
			{
				InternalLogStreams.LogTraceEncryption?.Warn("Hasher was not initialized");
				return false;
			}
			_hmacsha256.Initialize();
			using (UnmanagedMemoryStream inputStream = new UnmanagedMemoryStream(buffer, bufferLength))
			{
				byte[] array = _hmacsha256.ComputeHash(inputStream);
				Assert.Check(array.Length == 32, "hash.Length == HASHSize");
				Assert.Check(capacity >= bufferLength + 32, "Unable to copy hash, original buffer is too short");
				Native.CopyFromArray(buffer + bufferLength, array);
			}
			bufferLength += 32;
			return true;
		}

		public unsafe bool VerifyHash(byte* buffer, ref int bufferLength, int capacity)
		{
			if (_hmacsha256 == null)
			{
				InternalLogStreams.LogTraceEncryption?.Warn("Hasher was not initialized");
				return false;
			}
			_hmacsha256.Initialize();
			using UnmanagedMemoryStream inputStream = new UnmanagedMemoryStream(buffer, bufferLength - 32);
			byte[] array = _hmacsha256.ComputeHash(inputStream);
			bufferLength -= 32;
			fixed (byte* ptr = array)
			{
				return Native.MemCmp(buffer + bufferLength, ptr, 32) == 0;
			}
		}

		private static Aes BuildAesProvider(byte[] key)
		{
			Aes aes = Aes.Create();
			aes.Key = key;
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			return aes;
		}

		private static HMACSHA256 BuildHMACSHA256(byte[] key)
		{
			return new HMACSHA256(key);
		}

		private byte[] GetBufferEncrypt()
		{
			Array.Clear(_encryptBufferEncrypt, 0, 4096);
			return _encryptBufferEncrypt;
		}

		private byte[] GetBufferDecrypt()
		{
			Array.Clear(_encryptBufferDecrypt, 0, 4096);
			return _encryptBufferDecrypt;
		}

		public void Dispose()
		{
			InternalLogStreams.LogTraceEncryption?.Log("Disposing DataEncryptor...");
			_cryptoProvider?.Dispose();
			_cryptoProvider = null;
			_hmacsha256?.Dispose();
			_hmacsha256 = null;
			_rng?.Dispose();
			_rng = null;
			_encryptBufferEncrypt = null;
			_encryptBufferDecrypt = null;
		}
	}
	public interface IDataEncryption : IDisposable
	{
		void Setup(byte[] key);

		byte[] GenerateKey();

		unsafe bool EncryptData(byte* buffer, ref int bufferLength, int capacity);

		unsafe bool DecryptData(byte* buffer, ref int bufferLength, int capacity);

		unsafe bool ComputeHash(byte* buffer, ref int bufferLength, int capacity);

		unsafe bool VerifyHash(byte* buffer, ref int bufferLength, int capacity);
	}
	internal class EncryptionManager<THandler, TEncryption> : IDisposable where THandler : IEquatable<THandler> where TEncryption : IDataEncryption, new()
	{
		private readonly Dictionary<THandler, TEncryption> _cyphers = new Dictionary<THandler, TEncryption>();

		public void Dispose()
		{
			InternalLogStreams.LogTraceEncryption?.Log("Disposing EncryptionManager...");
			foreach (TEncryption value in _cyphers.Values)
			{
				value.Dispose();
			}
			_cyphers.Clear();
		}

		public void RegisterEncryptionKey(THandler handle, byte[] key)
		{
			if (HasEncryptionForHandle(handle))
			{
				InternalLogStreams.LogTraceEncryption?.Warn($"RegisterEncryptionKey: handle={handle} already registered");
				return;
			}
			TEncryption value = new TEncryption();
			value.Setup(key);
			_cyphers[handle] = value;
			InternalLogStreams.LogTraceEncryption?.Log($"RegisterEncryptionKey: handle={handle} key={BinUtils.BytesToHex(key)}");
		}

		public void DeleteEncryptionKey(THandler handle)
		{
			if (_cyphers.TryGetValue(handle, out var value))
			{
				_cyphers.Remove(handle);
				value.Dispose();
				InternalLogStreams.LogTraceEncryption?.Log($"DeleteEncryptionKey: handle={handle}");
			}
		}

		public bool HasEncryptionForHandle(THandler handle)
		{
			return _cyphers.ContainsKey(handle);
		}

		public unsafe bool Wrap(THandler handle, byte* buffer, ref int length, int capacity)
		{
			EngineProfiler.Begin("Encryption.Wrap");
			bool result = Encrypt(handle, buffer, ref length, capacity) && ComputeHash(handle, buffer, ref length, capacity);
			EngineProfiler.End();
			return result;
		}

		public unsafe bool Unwrap(THandler handle, byte* buffer, ref int length, int capacity)
		{
			EngineProfiler.Begin("Encryption.Unwrap");
			bool result = VerifyHash(handle, buffer, ref length, capacity) && Decrypt(handle, buffer, ref length, capacity);
			EngineProfiler.End();
			return result;
		}

		public byte[] GenerateKey()
		{
			return new TEncryption().GenerateKey();
		}

		public unsafe bool ComputeHash(THandler handle, byte* buffer, ref int length, int capacity)
		{
			if (_cyphers.TryGetValue(handle, out var value))
			{
				return value.ComputeHash(buffer, ref length, capacity);
			}
			InternalLogStreams.LogTraceEncryption?.Warn($"ComputeHash: handle={handle} not found");
			return false;
		}

		public unsafe bool VerifyHash(THandler handle, byte* buffer, ref int length, int capacity)
		{
			if (_cyphers.TryGetValue(handle, out var value))
			{
				return value.VerifyHash(buffer, ref length, capacity);
			}
			InternalLogStreams.LogTraceEncryption?.Warn($"VerifyHash: handle={handle} not found");
			return false;
		}

		public unsafe bool Encrypt(THandler handle, byte* buffer, ref int length, int capacity)
		{
			if (_cyphers.TryGetValue(handle, out var value))
			{
				return value.EncryptData(buffer, ref length, capacity);
			}
			InternalLogStreams.LogTraceEncryption?.Warn($"Encrypt: handle={handle} not found");
			return false;
		}

		public unsafe bool Decrypt(THandler handle, byte* buffer, ref int length, int capacity)
		{
			if (_cyphers.TryGetValue(handle, out var value))
			{
				return value.DecryptData(buffer, ref length, capacity);
			}
			InternalLogStreams.LogTraceEncryption?.Warn($"Decrypt: handle={handle} not found");
			return false;
		}
	}
	internal class EncryptionToken
	{
		public byte[] Key;

		public byte[] KeyEncrypted;

		public override string ToString()
		{
			return "[EncryptionToken: Key=" + BinUtils.BytesToHex(Key?.Take(5).ToArray()) + ", KeyEncrypted=" + BinUtils.BytesToHex(KeyEncrypted?.Take(5).ToArray()) + "]";
		}
	}
}
