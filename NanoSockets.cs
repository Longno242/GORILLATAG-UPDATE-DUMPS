using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("NanoSockets")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("NanoSockets")]
[assembly: AssemblyTitle("NanoSockets")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
namespace NanoSockets;

public enum Status
{
	Ok = 0,
	Error = -1
}
[StructLayout(LayoutKind.Explicit)]
public struct Socket
{
	[FieldOffset(0)]
	public long handle;

	public bool IsCreated => handle > 0;

	public static implicit operator long(Socket socket)
	{
		return socket.handle;
	}

	public static implicit operator Socket(long handle)
	{
		Socket result = default(Socket);
		result.handle = handle;
		return result;
	}
}
[StructLayout(LayoutKind.Explicit, Size = 24)]
public struct Address : IEquatable<Address>
{
	[FieldOffset(0)]
	public ulong _address0;

	[FieldOffset(8)]
	public ulong _address1;

	[FieldOffset(16)]
	public ushort Port;

	public bool Equals(Address other)
	{
		if (_address0 == other._address0 && _address1 == other._address1)
		{
			return Port == other.Port;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is Address other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ((17 * 31 + _address0.GetHashCode()) * 31 + _address1.GetHashCode()) * 31 + Port.GetHashCode();
	}

	public override string ToString()
	{
		Address address = this;
		int num = 64;
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		UDP.GetIP(ref address, intPtr, num);
		string arg = Marshal.PtrToStringAnsi(intPtr);
		Marshal.FreeHGlobal(intPtr);
		return string.Format("[{0} Ip={1} Port={2}]", "Address", arg, Port);
	}

	public static Address LocalhostIPv4(ushort port = 0)
	{
		return CreateFromIpPort("127.0.0.1", port);
	}

	public static Address Any(ushort port = 0)
	{
		return CreateFromIpPort("0.0.0.0", port);
	}

	public static Address CreateFromIpPort(string ip, ushort port)
	{
		Address address = default(Address);
		if (UDP.SetIP(ref address, ip) != Status.Ok)
		{
			throw new Exception("Can not CreateFromIpPort. IP not Set");
		}
		address.Port = port;
		return address;
	}
}
[SuppressUnmanagedCodeSecurity]
public static class UDP
{
	private const string NativeLibrary = "nanosockets";

	public const int HostNameSize = 1025;

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_initialize")]
	public static extern Status Initialize();

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_deinitialize")]
	public static extern void Deinitialize();

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_create")]
	public static extern long Create(int sendBufferSize, int receiveBufferSize);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_destroy")]
	public static extern void Destroy(ref long socket);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_bind")]
	public static extern int Bind(long socket, IntPtr address);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_bind")]
	public static extern int Bind(long socket, ref Address address);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_connect")]
	public static extern int Connect(long socket, ref Address address);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_set_option")]
	public static extern Status SetOption(long socket, int level, int optionName, ref int optionValue, int optionLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_get_option")]
	public static extern Status GetOption(long socket, int level, int optionName, ref int optionValue, ref int optionLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_set_nonblocking")]
	public static extern Status SetNonBlocking(long socket);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_set_dontfragment")]
	public static extern Status SetDontFragment(long socket, byte df);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_send")]
	public static extern int Send(long socket, IntPtr address, IntPtr buffer, int bufferLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_send")]
	public static extern int Send(long socket, IntPtr address, byte[] buffer, int bufferLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_send")]
	public static extern int Send(long socket, ref Address address, IntPtr buffer, int bufferLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_send")]
	public static extern int Send(long socket, ref Address address, byte[] buffer, int bufferLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_send")]
	public unsafe static extern int Send(long socket, Address* address, byte* buffer, int bufferLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_receive")]
	public static extern int Receive(long socket, IntPtr address, IntPtr buffer, int bufferLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_receive")]
	public static extern int Receive(long socket, IntPtr address, byte[] buffer, int bufferLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_receive")]
	public static extern int Receive(long socket, ref Address address, IntPtr buffer, int bufferLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_receive")]
	public static extern int Receive(long socket, ref Address address, byte[] buffer, int bufferLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_receive")]
	public unsafe static extern int Receive(long socket, Address* address, byte* buffer, int bufferLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_poll")]
	public static extern int Poll(long socket, long timeout);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_address_get")]
	public static extern Status GetAddress(long socket, ref Address address);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_address_is_equal")]
	public static extern Status IsEqual(ref Address left, ref Address right);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_address_set_ip")]
	public static extern Status SetIP(ref Address address, IntPtr ip);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_address_set_ip")]
	public static extern Status SetIP(ref Address address, string ip);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_address_get_ip")]
	public static extern Status GetIP(ref Address address, IntPtr ip, int ipLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_address_get_ip")]
	public static extern Status GetIP(ref Address address, StringBuilder ip, int ipLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_address_set_hostname")]
	public static extern Status SetHostName(ref Address address, IntPtr name);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_address_set_hostname")]
	public static extern Status SetHostName(ref Address address, string name);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_address_get_hostname")]
	public static extern Status GetHostName(ref Address address, IntPtr name, int nameLength);

	[DllImport("nanosockets", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nanosockets_address_get_hostname")]
	public static extern Status GetHostName(ref Address address, StringBuilder name, int nameLength);
}
