using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Timers;
using WebSocketSharp.Net;
using WebSocketSharp.Net.WebSockets;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: AssemblyTitle("websocket-sharp")]
[assembly: AssemblyDescription("A C# implementation of the WebSocket protocol client and server")]
[assembly: AssemblyConfiguration("Commit 77f74bd")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("websocket-sharp.dll")]
[assembly: AssemblyCopyright("sta.blockhead")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyVersion("1.0.2.0")]
namespace WebSocketSharp
{
	public static class Ext
	{
		private static readonly byte[] _last = new byte[1];

		private static readonly int _retry = 5;

		private const string _tspecials = "()<>@,;:\\\"/[]?={} \t";

		private static byte[] compress(this byte[] data)
		{
			if (data.LongLength == 0)
			{
				return data;
			}
			using MemoryStream stream = new MemoryStream(data);
			return stream.compressToArray();
		}

		private static MemoryStream compress(this Stream stream)
		{
			MemoryStream memoryStream = new MemoryStream();
			if (stream.Length == 0)
			{
				return memoryStream;
			}
			stream.Position = 0L;
			using DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress, leaveOpen: true);
			CopyTo(stream, deflateStream, 1024);
			deflateStream.Close();
			memoryStream.Write(_last, 0, 1);
			memoryStream.Position = 0L;
			return memoryStream;
		}

		private static byte[] compressToArray(this Stream stream)
		{
			using MemoryStream memoryStream = stream.compress();
			memoryStream.Close();
			return memoryStream.ToArray();
		}

		private static byte[] decompress(this byte[] data)
		{
			if (data.LongLength == 0)
			{
				return data;
			}
			using MemoryStream stream = new MemoryStream(data);
			return stream.decompressToArray();
		}

		private static MemoryStream decompress(this Stream stream)
		{
			MemoryStream memoryStream = new MemoryStream();
			if (stream.Length == 0)
			{
				return memoryStream;
			}
			stream.Position = 0L;
			using DeflateStream sourceStream = new DeflateStream(stream, CompressionMode.Decompress, leaveOpen: true);
			CopyTo(sourceStream, memoryStream, 1024);
			memoryStream.Position = 0L;
			return memoryStream;
		}

		private static byte[] decompressToArray(this Stream stream)
		{
			using MemoryStream memoryStream = stream.decompress();
			memoryStream.Close();
			return memoryStream.ToArray();
		}

		private static bool isHttpMethod(this string value)
		{
			int result;
			switch (value)
			{
			default:
				result = ((value == "TRACE") ? 1 : 0);
				break;
			case "GET":
			case "HEAD":
			case "POST":
			case "PUT":
			case "DELETE":
			case "CONNECT":
			case "OPTIONS":
				result = 1;
				break;
			}
			return (byte)result != 0;
		}

		private static bool isHttpMethod10(this string value)
		{
			return value == "GET" || value == "HEAD" || value == "POST";
		}

		private static bool isPredefinedScheme(this string value)
		{
			switch (value[0])
			{
			case 'h':
				return value == "http" || value == "https";
			case 'w':
				return value == "ws" || value == "wss";
			case 'f':
				return value == "file" || value == "ftp";
			case 'g':
				return value == "gopher";
			case 'm':
				return value == "mailto";
			case 'n':
			{
				char c = value[1];
				return (c != 'e') ? (value == "nntp") : (value == "news" || value == "net.pipe" || value == "net.tcp");
			}
			default:
				return false;
			}
		}

		internal static byte[] Append(this ushort code, string reason)
		{
			byte[] array = code.ToByteArray(ByteOrder.Big);
			if (reason == null || reason.Length == 0)
			{
				return array;
			}
			List<byte> list = new List<byte>(array);
			byte[] bytes = Encoding.UTF8.GetBytes(reason);
			list.AddRange(bytes);
			return list.ToArray();
		}

		internal static byte[] Compress(this byte[] data, CompressionMethod method)
		{
			return (method == CompressionMethod.Deflate) ? data.compress() : data;
		}

		internal static Stream Compress(this Stream stream, CompressionMethod method)
		{
			return (method == CompressionMethod.Deflate) ? stream.compress() : stream;
		}

		internal static byte[] CompressToArray(this Stream stream, CompressionMethod method)
		{
			return (method == CompressionMethod.Deflate) ? stream.compressToArray() : stream.ToByteArray();
		}

		internal static bool Contains(this string value, params char[] anyOf)
		{
			return anyOf != null && anyOf.Length != 0 && value.IndexOfAny(anyOf) > -1;
		}

		internal static bool Contains(this NameValueCollection collection, string name)
		{
			return collection[name] != null;
		}

		internal static bool Contains(this NameValueCollection collection, string name, string value, StringComparison comparisonTypeForValue)
		{
			string text = collection[name];
			if (text == null)
			{
				return false;
			}
			string[] array = text.Split(new char[1] { ',' });
			foreach (string text2 in array)
			{
				if (text2.Trim().Equals(value, comparisonTypeForValue))
				{
					return true;
				}
			}
			return false;
		}

		internal static bool Contains<T>(this IEnumerable<T> source, Func<T, bool> condition)
		{
			foreach (T item in source)
			{
				if (condition(item))
				{
					return true;
				}
			}
			return false;
		}

		internal static bool ContainsTwice(this string[] values)
		{
			int len = values.Length;
			int end = len - 1;
			Func<int, bool> seek = null;
			seek = delegate(int idx)
			{
				if (idx == end)
				{
					return false;
				}
				string text = values[idx];
				for (int i = idx + 1; i < len; i++)
				{
					if (values[i] == text)
					{
						return true;
					}
				}
				return seek(++idx);
			};
			return seek(0);
		}

		internal static T[] Copy<T>(this T[] sourceArray, int length)
		{
			T[] array = new T[length];
			Array.Copy(sourceArray, 0, array, 0, length);
			return array;
		}

		internal static T[] Copy<T>(this T[] sourceArray, long length)
		{
			T[] array = new T[length];
			Array.Copy(sourceArray, 0L, array, 0L, length);
			return array;
		}

		internal static void CopyTo(this Stream sourceStream, Stream destinationStream, int bufferLength)
		{
			byte[] buffer = new byte[bufferLength];
			int num = 0;
			while (true)
			{
				num = sourceStream.Read(buffer, 0, bufferLength);
				if (num <= 0)
				{
					break;
				}
				destinationStream.Write(buffer, 0, num);
			}
		}

		internal static void CopyToAsync(this Stream sourceStream, Stream destinationStream, int bufferLength, Action completed, Action<Exception> error)
		{
			byte[] buff = new byte[bufferLength];
			AsyncCallback callback = null;
			callback = delegate(IAsyncResult ar)
			{
				try
				{
					int num = sourceStream.EndRead(ar);
					if (num <= 0)
					{
						if (completed != null)
						{
							completed();
						}
					}
					else
					{
						destinationStream.Write(buff, 0, num);
						sourceStream.BeginRead(buff, 0, bufferLength, callback, null);
					}
				}
				catch (Exception obj2)
				{
					if (error != null)
					{
						error(obj2);
					}
				}
			};
			try
			{
				sourceStream.BeginRead(buff, 0, bufferLength, callback, null);
			}
			catch (Exception obj)
			{
				if (error != null)
				{
					error(obj);
				}
			}
		}

		internal static byte[] Decompress(this byte[] data, CompressionMethod method)
		{
			return (method == CompressionMethod.Deflate) ? data.decompress() : data;
		}

		internal static Stream Decompress(this Stream stream, CompressionMethod method)
		{
			return (method == CompressionMethod.Deflate) ? stream.decompress() : stream;
		}

		internal static byte[] DecompressToArray(this Stream stream, CompressionMethod method)
		{
			return (method == CompressionMethod.Deflate) ? stream.decompressToArray() : stream.ToByteArray();
		}

		internal static void Emit(this EventHandler eventHandler, object sender, EventArgs e)
		{
			eventHandler?.Invoke(sender, e);
		}

		internal static void Emit<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender, TEventArgs e) where TEventArgs : EventArgs
		{
			eventHandler?.Invoke(sender, e);
		}

		internal static string GetAbsolutePath(this Uri uri)
		{
			if (uri.IsAbsoluteUri)
			{
				return uri.AbsolutePath;
			}
			string originalString = uri.OriginalString;
			if (originalString[0] != '/')
			{
				return null;
			}
			int num = originalString.IndexOfAny(new char[2] { '?', '#' });
			return (num > 0) ? originalString.Substring(0, num) : originalString;
		}

		internal static WebSocketSharp.Net.CookieCollection GetCookies(this NameValueCollection headers, bool response)
		{
			string text = headers[response ? "Set-Cookie" : "Cookie"];
			return (text != null) ? WebSocketSharp.Net.CookieCollection.Parse(text, response) : new WebSocketSharp.Net.CookieCollection();
		}

		internal static string GetDnsSafeHost(this Uri uri, bool bracketIPv6)
		{
			return (bracketIPv6 && uri.HostNameType == UriHostNameType.IPv6) ? uri.Host : uri.DnsSafeHost;
		}

		internal static string GetMessage(this CloseStatusCode code)
		{
			return code switch
			{
				CloseStatusCode.TlsHandshakeFailure => "An error has occurred during a TLS handshake.", 
				CloseStatusCode.ServerError => "WebSocket server got an internal error.", 
				CloseStatusCode.MandatoryExtension => "WebSocket client didn't receive expected extension(s).", 
				CloseStatusCode.TooBig => "A too big message has been received.", 
				CloseStatusCode.PolicyViolation => "A policy violation has occurred.", 
				CloseStatusCode.InvalidData => "Invalid data has been received.", 
				CloseStatusCode.Abnormal => "An exception has occurred.", 
				CloseStatusCode.UnsupportedData => "Unsupported data has been received.", 
				CloseStatusCode.ProtocolError => "A WebSocket protocol error has occurred.", 
				_ => string.Empty, 
			};
		}

		internal static string GetName(this string nameAndValue, char separator)
		{
			int num = nameAndValue.IndexOf(separator);
			return (num > 0) ? nameAndValue.Substring(0, num).Trim() : null;
		}

		internal static string GetUTF8DecodedString(this byte[] bytes)
		{
			return Encoding.UTF8.GetString(bytes);
		}

		internal static byte[] GetUTF8EncodedBytes(this string s)
		{
			return Encoding.UTF8.GetBytes(s);
		}

		internal static string GetValue(this string nameAndValue, char separator)
		{
			return nameAndValue.GetValue(separator, unquote: false);
		}

		internal static string GetValue(this string nameAndValue, char separator, bool unquote)
		{
			int num = nameAndValue.IndexOf(separator);
			if (num < 0 || num == nameAndValue.Length - 1)
			{
				return null;
			}
			string text = nameAndValue.Substring(num + 1).Trim();
			return unquote ? text.Unquote() : text;
		}

		internal static bool IsCompressionExtension(this string value, CompressionMethod method)
		{
			string value2 = method.ToExtensionString();
			StringComparison comparisonType = StringComparison.Ordinal;
			return value.StartsWith(value2, comparisonType);
		}

		internal static bool IsControl(this byte opcode)
		{
			return opcode > 7 && opcode < 16;
		}

		internal static bool IsControl(this Opcode opcode)
		{
			return (int)opcode >= 8;
		}

		internal static bool IsData(this byte opcode)
		{
			return opcode == 1 || opcode == 2;
		}

		internal static bool IsData(this Opcode opcode)
		{
			return opcode == Opcode.Text || opcode == Opcode.Binary;
		}

		internal static bool IsEqualTo(this int value, char c, Action<int> beforeComparing)
		{
			beforeComparing(value);
			return value == c;
		}

		internal static bool IsHttpMethod(this string value, Version version)
		{
			return (version == WebSocketSharp.Net.HttpVersion.Version10) ? value.isHttpMethod10() : value.isHttpMethod();
		}

		internal static bool IsPortNumber(this int value)
		{
			return value > 0 && value < 65536;
		}

		internal static bool IsReserved(this ushort code)
		{
			return code == 1004 || code == 1005 || code == 1006 || code == 1015;
		}

		internal static bool IsReserved(this CloseStatusCode code)
		{
			return code == CloseStatusCode.Undefined || code == CloseStatusCode.NoStatus || code == CloseStatusCode.Abnormal || code == CloseStatusCode.TlsHandshakeFailure;
		}

		internal static bool IsSupported(this byte opcode)
		{
			return Enum.IsDefined(typeof(Opcode), opcode);
		}

		internal static bool IsText(this string value)
		{
			int length = value.Length;
			for (int i = 0; i < length; i++)
			{
				char c = value[i];
				if (c < ' ')
				{
					if ("\r\n\t".IndexOf(c) == -1)
					{
						return false;
					}
					if (c == '\n')
					{
						i++;
						if (i == length)
						{
							break;
						}
						c = value[i];
						if (" \t".IndexOf(c) == -1)
						{
							return false;
						}
					}
				}
				else if (c == '\u007f')
				{
					return false;
				}
			}
			return true;
		}

		internal static bool IsToken(this string value)
		{
			foreach (char c in value)
			{
				if (c < ' ')
				{
					return false;
				}
				if (c > '~')
				{
					return false;
				}
				if ("()<>@,;:\\\"/[]?={} \t".IndexOf(c) > -1)
				{
					return false;
				}
			}
			return true;
		}

		internal static bool KeepsAlive(this NameValueCollection headers, Version version)
		{
			StringComparison comparisonTypeForValue = StringComparison.OrdinalIgnoreCase;
			return (version < WebSocketSharp.Net.HttpVersion.Version11) ? headers.Contains("Connection", "keep-alive", comparisonTypeForValue) : (!headers.Contains("Connection", "close", comparisonTypeForValue));
		}

		internal static bool MaybeUri(this string value)
		{
			int num = value.IndexOf(':');
			if (num < 2 || num > 9)
			{
				return false;
			}
			string value2 = value.Substring(0, num);
			return value2.isPredefinedScheme();
		}

		internal static string Quote(this string value)
		{
			string format = "\"{0}\"";
			string arg = value.Replace("\"", "\\\"");
			return string.Format(format, arg);
		}

		internal static byte[] ReadBytes(this Stream stream, int length)
		{
			byte[] array = new byte[length];
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (length > 0)
			{
				num3 = stream.Read(array, num, length);
				if (num3 <= 0)
				{
					if (num2 >= _retry)
					{
						return array.SubArray(0, num);
					}
					num2++;
				}
				else
				{
					num2 = 0;
					num += num3;
					length -= num3;
				}
			}
			return array;
		}

		internal static byte[] ReadBytes(this Stream stream, long length, int bufferLength)
		{
			using MemoryStream memoryStream = new MemoryStream();
			byte[] buffer = new byte[bufferLength];
			int num = 0;
			int num2 = 0;
			while (length > 0)
			{
				if (length < bufferLength)
				{
					bufferLength = (int)length;
				}
				num2 = stream.Read(buffer, 0, bufferLength);
				if (num2 <= 0)
				{
					if (num >= _retry)
					{
						break;
					}
					num++;
				}
				else
				{
					num = 0;
					memoryStream.Write(buffer, 0, num2);
					length -= num2;
				}
			}
			memoryStream.Close();
			return memoryStream.ToArray();
		}

		internal static void ReadBytesAsync(this Stream stream, int length, Action<byte[]> completed, Action<Exception> error)
		{
			byte[] buff = new byte[length];
			int offset = 0;
			int retry = 0;
			AsyncCallback callback = null;
			callback = delegate(IAsyncResult ar)
			{
				try
				{
					int num = stream.EndRead(ar);
					if (num <= 0)
					{
						if (retry < _retry)
						{
							retry++;
							stream.BeginRead(buff, offset, length, callback, null);
						}
						else if (completed != null)
						{
							completed(buff.SubArray(0, offset));
						}
					}
					else if (num == length)
					{
						if (completed != null)
						{
							completed(buff);
						}
					}
					else
					{
						retry = 0;
						offset += num;
						length -= num;
						stream.BeginRead(buff, offset, length, callback, null);
					}
				}
				catch (Exception obj2)
				{
					if (error != null)
					{
						error(obj2);
					}
				}
			};
			try
			{
				stream.BeginRead(buff, offset, length, callback, null);
			}
			catch (Exception obj)
			{
				if (error != null)
				{
					error(obj);
				}
			}
		}

		internal static void ReadBytesAsync(this Stream stream, long length, int bufferLength, Action<byte[]> completed, Action<Exception> error)
		{
			MemoryStream dest = new MemoryStream();
			byte[] buff = new byte[bufferLength];
			int retry = 0;
			Action<long> read = null;
			read = delegate(long len)
			{
				if (len < bufferLength)
				{
					bufferLength = (int)len;
				}
				stream.BeginRead(buff, 0, bufferLength, delegate(IAsyncResult ar)
				{
					try
					{
						int num = stream.EndRead(ar);
						if (num <= 0)
						{
							if (retry < _retry)
							{
								int num2 = retry;
								retry = num2 + 1;
								read(len);
							}
							else
							{
								if (completed != null)
								{
									dest.Close();
									completed(dest.ToArray());
								}
								dest.Dispose();
							}
						}
						else
						{
							dest.Write(buff, 0, num);
							if (num == len)
							{
								if (completed != null)
								{
									dest.Close();
									completed(dest.ToArray());
								}
								dest.Dispose();
							}
							else
							{
								retry = 0;
								read(len - num);
							}
						}
					}
					catch (Exception obj2)
					{
						dest.Dispose();
						if (error != null)
						{
							error(obj2);
						}
					}
				}, null);
			};
			try
			{
				read(length);
			}
			catch (Exception obj)
			{
				dest.Dispose();
				if (error != null)
				{
					error(obj);
				}
			}
		}

		internal static T[] Reverse<T>(this T[] array)
		{
			int num = array.Length;
			T[] array2 = new T[num];
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				array2[i] = array[num2 - i];
			}
			return array2;
		}

		internal static IEnumerable<string> SplitHeaderValue(this string value, params char[] separators)
		{
			int len = value.Length;
			int end = len - 1;
			StringBuilder buff = new StringBuilder(32);
			bool escaped = false;
			bool quoted = false;
			for (int i = 0; i <= end; i++)
			{
				char c = value[i];
				buff.Append(c);
				switch (c)
				{
				case '"':
					if (escaped)
					{
						escaped = false;
					}
					else
					{
						quoted = !quoted;
					}
					continue;
				case '\\':
					if (i == end)
					{
						break;
					}
					if (value[i + 1] == '"')
					{
						escaped = true;
					}
					continue;
				default:
					if (Array.IndexOf(separators, c) > -1 && !quoted)
					{
						buff.Length--;
						yield return buff.ToString();
						buff.Length = 0;
					}
					continue;
				}
				break;
			}
			yield return buff.ToString();
		}

		internal static byte[] ToByteArray(this Stream stream)
		{
			stream.Position = 0L;
			using MemoryStream memoryStream = new MemoryStream();
			CopyTo(stream, memoryStream, 1024);
			memoryStream.Close();
			return memoryStream.ToArray();
		}

		internal static byte[] ToByteArray(this ushort value, ByteOrder order)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			if (!order.IsHostOrder())
			{
				Array.Reverse((Array)bytes);
			}
			return bytes;
		}

		internal static byte[] ToByteArray(this ulong value, ByteOrder order)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			if (!order.IsHostOrder())
			{
				Array.Reverse((Array)bytes);
			}
			return bytes;
		}

		internal static CompressionMethod ToCompressionMethod(this string value)
		{
			Array values = Enum.GetValues(typeof(CompressionMethod));
			foreach (CompressionMethod item in values)
			{
				if (item.ToExtensionString() == value)
				{
					return item;
				}
			}
			return CompressionMethod.None;
		}

		internal static string ToExtensionString(this CompressionMethod method, params string[] parameters)
		{
			if (method == CompressionMethod.None)
			{
				return string.Empty;
			}
			string text = $"permessage-{method.ToString().ToLower()}";
			return (parameters != null && parameters.Length != 0) ? string.Format("{0}; {1}", text, parameters.ToString("; ")) : text;
		}

		internal static IPAddress ToIPAddress(this string value)
		{
			if (value == null || value.Length == 0)
			{
				return null;
			}
			if (IPAddress.TryParse(value, out var address))
			{
				return address;
			}
			try
			{
				IPAddress[] hostAddresses = Dns.GetHostAddresses(value);
				return hostAddresses[0];
			}
			catch
			{
				return null;
			}
		}

		internal static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
		{
			return new List<TSource>(source);
		}

		internal static string ToString(this IPAddress address, bool bracketIPv6)
		{
			return (bracketIPv6 && address.AddressFamily == AddressFamily.InterNetworkV6) ? $"[{address.ToString()}]" : address.ToString();
		}

		internal static ushort ToUInt16(this byte[] source, ByteOrder sourceOrder)
		{
			return BitConverter.ToUInt16(source.ToHostOrder(sourceOrder), 0);
		}

		internal static ulong ToUInt64(this byte[] source, ByteOrder sourceOrder)
		{
			return BitConverter.ToUInt64(source.ToHostOrder(sourceOrder), 0);
		}

		internal static IEnumerable<string> TrimEach(this IEnumerable<string> source)
		{
			foreach (string elm in source)
			{
				yield return elm.Trim();
			}
		}

		internal static string TrimSlashFromEnd(this string value)
		{
			string text = value.TrimEnd(new char[1] { '/' });
			return (text.Length > 0) ? text : "/";
		}

		internal static string TrimSlashOrBackslashFromEnd(this string value)
		{
			string text = value.TrimEnd('/', '\\');
			return (text.Length > 0) ? text : value[0].ToString();
		}

		internal static bool TryCreateVersion(this string versionString, out Version result)
		{
			result = null;
			try
			{
				result = new Version(versionString);
			}
			catch
			{
				return false;
			}
			return true;
		}

		internal static bool TryCreateWebSocketUri(this string uriString, out Uri result, out string message)
		{
			result = null;
			message = null;
			Uri uri = uriString.ToUri();
			if (uri == null)
			{
				message = "An invalid URI string.";
				return false;
			}
			if (!uri.IsAbsoluteUri)
			{
				message = "A relative URI.";
				return false;
			}
			string scheme = uri.Scheme;
			if (!(scheme == "ws") && !(scheme == "wss"))
			{
				message = "The scheme part is not 'ws' or 'wss'.";
				return false;
			}
			int port = uri.Port;
			if (port == 0)
			{
				message = "The port part is zero.";
				return false;
			}
			if (uri.Fragment.Length > 0)
			{
				message = "It includes the fragment component.";
				return false;
			}
			result = ((port != -1) ? uri : new Uri(string.Format("{0}://{1}:{2}{3}", scheme, uri.Host, (scheme == "ws") ? 80 : 443, uri.PathAndQuery)));
			return true;
		}

		internal static bool TryGetUTF8DecodedString(this byte[] bytes, out string s)
		{
			s = null;
			try
			{
				s = Encoding.UTF8.GetString(bytes);
			}
			catch
			{
				return false;
			}
			return true;
		}

		internal static bool TryGetUTF8EncodedBytes(this string s, out byte[] bytes)
		{
			bytes = null;
			try
			{
				bytes = Encoding.UTF8.GetBytes(s);
			}
			catch
			{
				return false;
			}
			return true;
		}

		internal static bool TryOpenRead(this FileInfo fileInfo, out FileStream fileStream)
		{
			fileStream = null;
			try
			{
				fileStream = fileInfo.OpenRead();
			}
			catch
			{
				return false;
			}
			return true;
		}

		internal static string Unquote(this string value)
		{
			int num = value.IndexOf('"');
			if (num == -1)
			{
				return value;
			}
			int num2 = value.LastIndexOf('"');
			if (num2 == num)
			{
				return value;
			}
			int num3 = num2 - num - 1;
			return (num3 > 0) ? value.Substring(num + 1, num3).Replace("\\\"", "\"") : string.Empty;
		}

		internal static bool Upgrades(this NameValueCollection headers, string protocol)
		{
			StringComparison comparisonTypeForValue = StringComparison.OrdinalIgnoreCase;
			return headers.Contains("Upgrade", protocol, comparisonTypeForValue) && headers.Contains("Connection", "Upgrade", comparisonTypeForValue);
		}

		internal static string UrlDecode(this string value, Encoding encoding)
		{
			return HttpUtility.UrlDecode(value, encoding);
		}

		internal static string UrlEncode(this string value, Encoding encoding)
		{
			return HttpUtility.UrlEncode(value, encoding);
		}

		internal static void WriteBytes(this Stream stream, byte[] bytes, int bufferLength)
		{
			using MemoryStream sourceStream = new MemoryStream(bytes);
			CopyTo(sourceStream, stream, bufferLength);
		}

		internal static void WriteBytesAsync(this Stream stream, byte[] bytes, int bufferLength, Action completed, Action<Exception> error)
		{
			MemoryStream src = new MemoryStream(bytes);
			src.CopyToAsync(stream, bufferLength, delegate
			{
				if (completed != null)
				{
					completed();
				}
				src.Dispose();
			}, delegate(Exception ex)
			{
				src.Dispose();
				if (error != null)
				{
					error(ex);
				}
			});
		}

		public static string GetDescription(this WebSocketSharp.Net.HttpStatusCode code)
		{
			return ((int)code).GetStatusDescription();
		}

		public static string GetStatusDescription(this int code)
		{
			return code switch
			{
				100 => "Continue", 
				101 => "Switching Protocols", 
				102 => "Processing", 
				200 => "OK", 
				201 => "Created", 
				202 => "Accepted", 
				203 => "Non-Authoritative Information", 
				204 => "No Content", 
				205 => "Reset Content", 
				206 => "Partial Content", 
				207 => "Multi-Status", 
				300 => "Multiple Choices", 
				301 => "Moved Permanently", 
				302 => "Found", 
				303 => "See Other", 
				304 => "Not Modified", 
				305 => "Use Proxy", 
				307 => "Temporary Redirect", 
				400 => "Bad Request", 
				401 => "Unauthorized", 
				402 => "Payment Required", 
				403 => "Forbidden", 
				404 => "Not Found", 
				405 => "Method Not Allowed", 
				406 => "Not Acceptable", 
				407 => "Proxy Authentication Required", 
				408 => "Request Timeout", 
				409 => "Conflict", 
				410 => "Gone", 
				411 => "Length Required", 
				412 => "Precondition Failed", 
				413 => "Request Entity Too Large", 
				414 => "Request-Uri Too Long", 
				415 => "Unsupported Media Type", 
				416 => "Requested Range Not Satisfiable", 
				417 => "Expectation Failed", 
				422 => "Unprocessable Entity", 
				423 => "Locked", 
				424 => "Failed Dependency", 
				500 => "Internal Server Error", 
				501 => "Not Implemented", 
				502 => "Bad Gateway", 
				503 => "Service Unavailable", 
				504 => "Gateway Timeout", 
				505 => "Http Version Not Supported", 
				507 => "Insufficient Storage", 
				_ => string.Empty, 
			};
		}

		public static bool IsCloseStatusCode(this ushort value)
		{
			return value > 999 && value < 5000;
		}

		public static bool IsEnclosedIn(this string value, char c)
		{
			if (value == null)
			{
				return false;
			}
			int length = value.Length;
			return length > 1 && value[0] == c && value[length - 1] == c;
		}

		public static bool IsHostOrder(this ByteOrder order)
		{
			return BitConverter.IsLittleEndian == (order == ByteOrder.Little);
		}

		public static bool IsLocal(this IPAddress address)
		{
			if (address == null)
			{
				throw new ArgumentNullException("address");
			}
			if (address.Equals(IPAddress.Any))
			{
				return true;
			}
			if (address.Equals(IPAddress.Loopback))
			{
				return true;
			}
			if (Socket.OSSupportsIPv6)
			{
				if (address.Equals(IPAddress.IPv6Any))
				{
					return true;
				}
				if (address.Equals(IPAddress.IPv6Loopback))
				{
					return true;
				}
			}
			string hostName = Dns.GetHostName();
			IPAddress[] hostAddresses = Dns.GetHostAddresses(hostName);
			IPAddress[] array = hostAddresses;
			foreach (IPAddress obj in array)
			{
				if (address.Equals(obj))
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsNullOrEmpty(this string value)
		{
			return value == null || value.Length == 0;
		}

		public static T[] SubArray<T>(this T[] array, int startIndex, int length)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int num = array.Length;
			if (num == 0)
			{
				if (startIndex != 0)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
				if (length != 0)
				{
					throw new ArgumentOutOfRangeException("length");
				}
				return array;
			}
			if (startIndex < 0 || startIndex >= num)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			if (length < 0 || length > num - startIndex)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			if (length == 0)
			{
				return new T[0];
			}
			if (length == num)
			{
				return array;
			}
			T[] array2 = new T[length];
			Array.Copy(array, startIndex, array2, 0, length);
			return array2;
		}

		public static T[] SubArray<T>(this T[] array, long startIndex, long length)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			long num = array.LongLength;
			if (num == 0)
			{
				if (startIndex != 0)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
				if (length != 0)
				{
					throw new ArgumentOutOfRangeException("length");
				}
				return array;
			}
			if (startIndex < 0 || startIndex >= num)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			if (length < 0 || length > num - startIndex)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			if (length == 0)
			{
				return new T[0];
			}
			if (length == num)
			{
				return array;
			}
			T[] array2 = new T[length];
			Array.Copy(array, startIndex, array2, 0L, length);
			return array2;
		}

		public static void Times(this int n, Action<int> action)
		{
			if (n > 0 && action != null)
			{
				for (int i = 0; i < n; i++)
				{
					action(i);
				}
			}
		}

		public static void Times(this long n, Action<long> action)
		{
			if (n > 0 && action != null)
			{
				for (long num = 0L; num < n; num++)
				{
					action(num);
				}
			}
		}

		public static byte[] ToHostOrder(this byte[] source, ByteOrder sourceOrder)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (source.Length < 2)
			{
				return source;
			}
			if (sourceOrder.IsHostOrder())
			{
				return source;
			}
			return source.Reverse();
		}

		public static string ToString<T>(this T[] array, string separator)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int num = array.Length;
			if (num == 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(64);
			int num2 = num - 1;
			for (int i = 0; i < num2; i++)
			{
				stringBuilder.AppendFormat("{0}{1}", array[i], separator);
			}
			stringBuilder.AppendFormat("{0}", array[num2]);
			return stringBuilder.ToString();
		}

		public static Uri ToUri(this string value)
		{
			if (value == null || value.Length == 0)
			{
				return null;
			}
			UriKind uriKind = (value.MaybeUri() ? UriKind.Absolute : UriKind.Relative);
			Uri.TryCreate(value, uriKind, out var result);
			return result;
		}
	}
	public class MessageEventArgs : EventArgs
	{
		private string _data;

		private bool _dataSet;

		private Opcode _opcode;

		private byte[] _rawData;

		internal Opcode Opcode => _opcode;

		public string Data
		{
			get
			{
				setData();
				return _data;
			}
		}

		public bool IsBinary => _opcode == Opcode.Binary;

		public bool IsPing => _opcode == Opcode.Ping;

		public bool IsText => _opcode == Opcode.Text;

		public byte[] RawData
		{
			get
			{
				setData();
				return _rawData;
			}
		}

		internal MessageEventArgs(WebSocketFrame frame)
		{
			_opcode = frame.Opcode;
			_rawData = frame.PayloadData.ApplicationData;
		}

		internal MessageEventArgs(Opcode opcode, byte[] rawData)
		{
			if ((ulong)rawData.LongLength > PayloadData.MaxLength)
			{
				throw new WebSocketException(CloseStatusCode.TooBig);
			}
			_opcode = opcode;
			_rawData = rawData;
		}

		private void setData()
		{
			if (_dataSet)
			{
				return;
			}
			if (_opcode == Opcode.Binary)
			{
				_dataSet = true;
				return;
			}
			if (_rawData.TryGetUTF8DecodedString(out var s))
			{
				_data = s;
			}
			_dataSet = true;
		}
	}
	public class CloseEventArgs : EventArgs
	{
		private bool _clean;

		private PayloadData _payloadData;

		public ushort Code => _payloadData.Code;

		public string Reason => _payloadData.Reason;

		public bool WasClean => _clean;

		internal CloseEventArgs(PayloadData payloadData, bool clean)
		{
			_payloadData = payloadData;
			_clean = clean;
		}

		internal CloseEventArgs(ushort code, string reason, bool clean)
		{
			_payloadData = new PayloadData(code, reason);
			_clean = clean;
		}
	}
	public enum ByteOrder
	{
		Little,
		Big
	}
	public class ErrorEventArgs : EventArgs
	{
		private Exception _exception;

		private string _message;

		public Exception Exception => _exception;

		public string Message => _message;

		internal ErrorEventArgs(string message)
			: this(message, null)
		{
		}

		internal ErrorEventArgs(string message, Exception exception)
		{
			_message = message;
			_exception = exception;
		}
	}
	public class WebSocket : IDisposable
	{
		private AuthenticationChallenge _authChallenge;

		private string _base64Key;

		private bool _client;

		private Action _closeContext;

		private CompressionMethod _compression;

		private WebSocketContext _context;

		private WebSocketSharp.Net.CookieCollection _cookies;

		private WebSocketSharp.Net.NetworkCredential _credentials;

		private bool _emitOnPing;

		private bool _enableRedirection;

		private string _extensions;

		private bool _extensionsRequested;

		private object _forMessageEventQueue;

		private object _forPing;

		private object _forSend;

		private object _forState;

		private MemoryStream _fragmentsBuffer;

		private bool _fragmentsCompressed;

		private Opcode _fragmentsOpcode;

		private const string _guid = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";

		private Func<WebSocketContext, string> _handshakeRequestChecker;

		private bool _ignoreExtensions;

		private bool _inContinuation;

		private volatile bool _inMessage;

		private volatile Logger _logger;

		private static readonly int _maxRetryCountForConnect;

		private Action<MessageEventArgs> _message;

		private Queue<MessageEventArgs> _messageEventQueue;

		private uint _nonceCount;

		private string _origin;

		private ManualResetEvent _pongReceived;

		private bool _preAuth;

		private string _protocol;

		private string[] _protocols;

		private bool _protocolsRequested;

		private WebSocketSharp.Net.NetworkCredential _proxyCredentials;

		private Uri _proxyUri;

		private volatile WebSocketState _readyState;

		private ManualResetEvent _receivingExited;

		private int _retryCountForConnect;

		private bool _secure;

		private ClientSslConfiguration _sslConfig;

		private Stream _stream;

		private TcpClient _tcpClient;

		private Uri _uri;

		private const string _version = "13";

		private TimeSpan _waitTime;

		internal static readonly byte[] EmptyBytes;

		internal static readonly int FragmentLength;

		internal static readonly RandomNumberGenerator RandomNumber;

		internal WebSocketSharp.Net.CookieCollection CookieCollection => _cookies;

		internal Func<WebSocketContext, string> CustomHandshakeRequestChecker
		{
			get
			{
				return _handshakeRequestChecker;
			}
			set
			{
				_handshakeRequestChecker = value;
			}
		}

		internal bool HasMessage
		{
			get
			{
				lock (_forMessageEventQueue)
				{
					return _messageEventQueue.Count > 0;
				}
			}
		}

		internal bool IgnoreExtensions
		{
			get
			{
				return _ignoreExtensions;
			}
			set
			{
				_ignoreExtensions = value;
			}
		}

		internal bool IsConnected => _readyState == WebSocketState.Open || _readyState == WebSocketState.Closing;

		public CompressionMethod Compression
		{
			get
			{
				return _compression;
			}
			set
			{
				string text = null;
				if (!_client)
				{
					text = "This instance is not a client.";
					throw new InvalidOperationException(text);
				}
				if (!canSet(out text))
				{
					_logger.Warn(text);
					return;
				}
				lock (_forState)
				{
					if (!canSet(out text))
					{
						_logger.Warn(text);
					}
					else
					{
						_compression = value;
					}
				}
			}
		}

		public IEnumerable<WebSocketSharp.Net.Cookie> Cookies
		{
			get
			{
				lock (_cookies.SyncRoot)
				{
					foreach (WebSocketSharp.Net.Cookie cookie in _cookies)
					{
						yield return cookie;
					}
				}
			}
		}

		public WebSocketSharp.Net.NetworkCredential Credentials => _credentials;

		public bool EmitOnPing
		{
			get
			{
				return _emitOnPing;
			}
			set
			{
				_emitOnPing = value;
			}
		}

		public bool EnableRedirection
		{
			get
			{
				return _enableRedirection;
			}
			set
			{
				string text = null;
				if (!_client)
				{
					text = "This instance is not a client.";
					throw new InvalidOperationException(text);
				}
				if (!canSet(out text))
				{
					_logger.Warn(text);
					return;
				}
				lock (_forState)
				{
					if (!canSet(out text))
					{
						_logger.Warn(text);
					}
					else
					{
						_enableRedirection = value;
					}
				}
			}
		}

		public string Extensions => _extensions ?? string.Empty;

		public bool IsAlive => ping(EmptyBytes);

		public bool IsSecure => _secure;

		public Logger Log
		{
			get
			{
				return _logger;
			}
			internal set
			{
				_logger = value;
			}
		}

		public string Origin
		{
			get
			{
				return _origin;
			}
			set
			{
				string text = null;
				if (!_client)
				{
					text = "This instance is not a client.";
					throw new InvalidOperationException(text);
				}
				if (!value.IsNullOrEmpty())
				{
					if (!Uri.TryCreate(value, UriKind.Absolute, out var result))
					{
						text = "Not an absolute URI string.";
						throw new ArgumentException(text, "value");
					}
					if (result.Segments.Length > 1)
					{
						text = "It includes the path segments.";
						throw new ArgumentException(text, "value");
					}
				}
				if (!canSet(out text))
				{
					_logger.Warn(text);
					return;
				}
				lock (_forState)
				{
					if (!canSet(out text))
					{
						_logger.Warn(text);
						return;
					}
					_origin = ((!value.IsNullOrEmpty()) ? value.TrimEnd(new char[1] { '/' }) : value);
				}
			}
		}

		public string Protocol
		{
			get
			{
				return _protocol ?? string.Empty;
			}
			internal set
			{
				_protocol = value;
			}
		}

		public WebSocketState ReadyState => _readyState;

		public ClientSslConfiguration SslConfiguration
		{
			get
			{
				if (!_client)
				{
					string text = "This instance is not a client.";
					throw new InvalidOperationException(text);
				}
				if (!_secure)
				{
					string text2 = "This instance does not use a secure connection.";
					throw new InvalidOperationException(text2);
				}
				return getSslConfiguration();
			}
		}

		public Uri Url => _client ? _uri : _context.RequestUri;

		public TimeSpan WaitTime
		{
			get
			{
				return _waitTime;
			}
			set
			{
				if (value <= TimeSpan.Zero)
				{
					throw new ArgumentOutOfRangeException("value", "Zero or less.");
				}
				if (!canSet(out var text))
				{
					_logger.Warn(text);
					return;
				}
				lock (_forState)
				{
					if (!canSet(out text))
					{
						_logger.Warn(text);
					}
					else
					{
						_waitTime = value;
					}
				}
			}
		}

		public event EventHandler<CloseEventArgs> OnClose;

		public event EventHandler<ErrorEventArgs> OnError;

		public event EventHandler<MessageEventArgs> OnMessage;

		public event EventHandler OnOpen;

		static WebSocket()
		{
			_maxRetryCountForConnect = 10;
			EmptyBytes = new byte[0];
			FragmentLength = 1016;
			RandomNumber = new RNGCryptoServiceProvider();
		}

		internal WebSocket(HttpListenerWebSocketContext context, string protocol)
		{
			_context = context;
			_protocol = protocol;
			_closeContext = context.Close;
			_logger = context.Log;
			_message = messages;
			_secure = context.IsSecureConnection;
			_stream = context.Stream;
			_waitTime = TimeSpan.FromSeconds(1.0);
			init();
		}

		internal WebSocket(TcpListenerWebSocketContext context, string protocol)
		{
			_context = context;
			_protocol = protocol;
			_closeContext = context.Close;
			_logger = context.Log;
			_message = messages;
			_secure = context.IsSecureConnection;
			_stream = context.Stream;
			_waitTime = TimeSpan.FromSeconds(1.0);
			init();
		}

		public WebSocket(string url, params string[] protocols)
		{
			if (url == null)
			{
				throw new ArgumentNullException("url");
			}
			if (url.Length == 0)
			{
				throw new ArgumentException("An empty string.", "url");
			}
			if (!url.TryCreateWebSocketUri(out _uri, out var text))
			{
				throw new ArgumentException(text, "url");
			}
			if (protocols != null && protocols.Length != 0)
			{
				if (!checkProtocols(protocols, out text))
				{
					throw new ArgumentException(text, "protocols");
				}
				_protocols = protocols;
			}
			_base64Key = CreateBase64Key();
			_client = true;
			_logger = new Logger();
			_message = messagec;
			_secure = _uri.Scheme == "wss";
			_waitTime = TimeSpan.FromSeconds(5.0);
			init();
		}

		private bool accept()
		{
			if (_readyState == WebSocketState.Open)
			{
				string text = "The handshake request has already been accepted.";
				_logger.Warn(text);
				return false;
			}
			lock (_forState)
			{
				if (_readyState == WebSocketState.Open)
				{
					string text2 = "The handshake request has already been accepted.";
					_logger.Warn(text2);
					return false;
				}
				if (_readyState == WebSocketState.Closing)
				{
					string text3 = "The close process has set in.";
					_logger.Error(text3);
					text3 = "An interruption has occurred while attempting to accept.";
					error(text3, null);
					return false;
				}
				if (_readyState == WebSocketState.Closed)
				{
					string text4 = "The connection has been closed.";
					_logger.Error(text4);
					text4 = "An interruption has occurred while attempting to accept.";
					error(text4, null);
					return false;
				}
				try
				{
					if (!acceptHandshake())
					{
						return false;
					}
				}
				catch (Exception ex)
				{
					_logger.Fatal(ex.Message);
					_logger.Debug(ex.ToString());
					string text5 = "An exception has occurred while attempting to accept.";
					fatal(text5, ex);
					return false;
				}
				_readyState = WebSocketState.Open;
				return true;
			}
		}

		private bool acceptHandshake()
		{
			_logger.Debug($"A handshake request from {_context.UserEndPoint}:\n{_context}");
			if (!checkHandshakeRequest(_context, out var text))
			{
				_logger.Error(text);
				refuseHandshake(CloseStatusCode.ProtocolError, "A handshake error has occurred while attempting to accept.");
				return false;
			}
			if (!customCheckHandshakeRequest(_context, out text))
			{
				_logger.Error(text);
				refuseHandshake(CloseStatusCode.PolicyViolation, "A handshake error has occurred while attempting to accept.");
				return false;
			}
			_base64Key = _context.Headers["Sec-WebSocket-Key"];
			if (_protocol != null)
			{
				IEnumerable<string> secWebSocketProtocols = _context.SecWebSocketProtocols;
				processSecWebSocketProtocolClientHeader(secWebSocketProtocols);
			}
			if (!_ignoreExtensions)
			{
				string value = _context.Headers["Sec-WebSocket-Extensions"];
				processSecWebSocketExtensionsClientHeader(value);
			}
			return sendHttpResponse(createHandshakeResponse());
		}

		private bool canSet(out string message)
		{
			message = null;
			if (_readyState == WebSocketState.Open)
			{
				message = "The connection has already been established.";
				return false;
			}
			if (_readyState == WebSocketState.Closing)
			{
				message = "The connection is closing.";
				return false;
			}
			return true;
		}

		private bool checkHandshakeRequest(WebSocketContext context, out string message)
		{
			message = null;
			if (!context.IsWebSocketRequest)
			{
				message = "Not a handshake request.";
				return false;
			}
			if (context.RequestUri == null)
			{
				message = "It specifies an invalid Request-URI.";
				return false;
			}
			NameValueCollection headers = context.Headers;
			string text = headers["Sec-WebSocket-Key"];
			if (text == null)
			{
				message = "It includes no Sec-WebSocket-Key header.";
				return false;
			}
			if (text.Length == 0)
			{
				message = "It includes an invalid Sec-WebSocket-Key header.";
				return false;
			}
			string text2 = headers["Sec-WebSocket-Version"];
			if (text2 == null)
			{
				message = "It includes no Sec-WebSocket-Version header.";
				return false;
			}
			if (text2 != "13")
			{
				message = "It includes an invalid Sec-WebSocket-Version header.";
				return false;
			}
			string text3 = headers["Sec-WebSocket-Protocol"];
			if (text3 != null && text3.Length == 0)
			{
				message = "It includes an invalid Sec-WebSocket-Protocol header.";
				return false;
			}
			if (!_ignoreExtensions)
			{
				string text4 = headers["Sec-WebSocket-Extensions"];
				if (text4 != null && text4.Length == 0)
				{
					message = "It includes an invalid Sec-WebSocket-Extensions header.";
					return false;
				}
			}
			return true;
		}

		private bool checkHandshakeResponse(HttpResponse response, out string message)
		{
			message = null;
			if (response.IsRedirect)
			{
				message = "Indicates the redirection.";
				return false;
			}
			if (response.IsUnauthorized)
			{
				message = "Requires the authentication.";
				return false;
			}
			if (!response.IsWebSocketResponse)
			{
				message = "Not a WebSocket handshake response.";
				return false;
			}
			NameValueCollection headers = response.Headers;
			if (!validateSecWebSocketAcceptHeader(headers["Sec-WebSocket-Accept"]))
			{
				message = "Includes no Sec-WebSocket-Accept header, or it has an invalid value.";
				return false;
			}
			if (!validateSecWebSocketProtocolServerHeader(headers["Sec-WebSocket-Protocol"]))
			{
				message = "Includes no Sec-WebSocket-Protocol header, or it has an invalid value.";
				return false;
			}
			if (!validateSecWebSocketExtensionsServerHeader(headers["Sec-WebSocket-Extensions"]))
			{
				message = "Includes an invalid Sec-WebSocket-Extensions header.";
				return false;
			}
			if (!validateSecWebSocketVersionServerHeader(headers["Sec-WebSocket-Version"]))
			{
				message = "Includes an invalid Sec-WebSocket-Version header.";
				return false;
			}
			return true;
		}

		private static bool checkProtocols(string[] protocols, out string message)
		{
			message = null;
			Func<string, bool> condition = (string protocol) => protocol.IsNullOrEmpty() || !protocol.IsToken();
			if (protocols.Contains(condition))
			{
				message = "It contains a value that is not a token.";
				return false;
			}
			if (protocols.ContainsTwice())
			{
				message = "It contains a value twice.";
				return false;
			}
			return true;
		}

		private bool checkReceivedFrame(WebSocketFrame frame, out string message)
		{
			message = null;
			bool isMasked = frame.IsMasked;
			if (_client && isMasked)
			{
				message = "A frame from the server is masked.";
				return false;
			}
			if (!_client && !isMasked)
			{
				message = "A frame from a client is not masked.";
				return false;
			}
			if (_inContinuation && frame.IsData)
			{
				message = "A data frame has been received while receiving continuation frames.";
				return false;
			}
			if (frame.IsCompressed && _compression == CompressionMethod.None)
			{
				message = "A compressed frame has been received without any agreement for it.";
				return false;
			}
			if (frame.Rsv2 == Rsv.On)
			{
				message = "The RSV2 of a frame is non-zero without any negotiation for it.";
				return false;
			}
			if (frame.Rsv3 == Rsv.On)
			{
				message = "The RSV3 of a frame is non-zero without any negotiation for it.";
				return false;
			}
			return true;
		}

		private void close(ushort code, string reason)
		{
			if (_readyState == WebSocketState.Closing)
			{
				_logger.Info("The closing is already in progress.");
				return;
			}
			if (_readyState == WebSocketState.Closed)
			{
				_logger.Info("The connection has already been closed.");
				return;
			}
			if (code == 1005)
			{
				close(PayloadData.Empty, send: true, receive: true, received: false);
				return;
			}
			bool receive = !code.IsReserved();
			close(new PayloadData(code, reason), receive, receive, received: false);
		}

		private void close(PayloadData payloadData, bool send, bool receive, bool received)
		{
			lock (_forState)
			{
				if (_readyState == WebSocketState.Closing)
				{
					_logger.Info("The closing is already in progress.");
					return;
				}
				if (_readyState == WebSocketState.Closed)
				{
					_logger.Info("The connection has already been closed.");
					return;
				}
				send = send && _readyState == WebSocketState.Open;
				receive = send && receive;
				_readyState = WebSocketState.Closing;
			}
			_logger.Trace("Begin closing the connection.");
			bool clean = closeHandshake(payloadData, send, receive, received);
			releaseResources();
			_logger.Trace("End closing the connection.");
			_readyState = WebSocketState.Closed;
			CloseEventArgs e = new CloseEventArgs(payloadData, clean);
			try
			{
				this.OnClose.Emit(this, e);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				_logger.Debug(ex.ToString());
			}
		}

		private void closeAsync(ushort code, string reason)
		{
			if (_readyState == WebSocketState.Closing)
			{
				_logger.Info("The closing is already in progress.");
				return;
			}
			if (_readyState == WebSocketState.Closed)
			{
				_logger.Info("The connection has already been closed.");
				return;
			}
			if (code == 1005)
			{
				closeAsync(PayloadData.Empty, send: true, receive: true, received: false);
				return;
			}
			bool receive = !code.IsReserved();
			closeAsync(new PayloadData(code, reason), receive, receive, received: false);
		}

		private void closeAsync(PayloadData payloadData, bool send, bool receive, bool received)
		{
			Action<PayloadData, bool, bool, bool> closer = close;
			closer.BeginInvoke(payloadData, send, receive, received, delegate(IAsyncResult ar)
			{
				closer.EndInvoke(ar);
			}, null);
		}

		private bool closeHandshake(byte[] frameAsBytes, bool receive, bool received)
		{
			bool flag = frameAsBytes != null && sendBytes(frameAsBytes);
			if (!received && flag && receive && _receivingExited != null)
			{
				received = _receivingExited.WaitOne(_waitTime);
			}
			bool flag2 = flag && received;
			_logger.Debug($"Was clean?: {flag2}\n  sent: {flag}\n  received: {received}");
			return flag2;
		}

		private bool closeHandshake(PayloadData payloadData, bool send, bool receive, bool received)
		{
			bool flag = false;
			if (send)
			{
				WebSocketFrame webSocketFrame = WebSocketFrame.CreateCloseFrame(payloadData, _client);
				flag = sendBytes(webSocketFrame.ToArray());
				if (_client)
				{
					webSocketFrame.Unmask();
				}
			}
			if (!received && flag && receive && _receivingExited != null)
			{
				received = _receivingExited.WaitOne(_waitTime);
			}
			bool flag2 = flag && received;
			_logger.Debug($"Was clean?: {flag2}\n  sent: {flag}\n  received: {received}");
			return flag2;
		}

		private bool connect()
		{
			if (_readyState == WebSocketState.Open)
			{
				string text = "The connection has already been established.";
				_logger.Warn(text);
				return false;
			}
			lock (_forState)
			{
				if (_readyState == WebSocketState.Open)
				{
					string text2 = "The connection has already been established.";
					_logger.Warn(text2);
					return false;
				}
				if (_readyState == WebSocketState.Closing)
				{
					string text3 = "The close process has set in.";
					_logger.Error(text3);
					text3 = "An interruption has occurred while attempting to connect.";
					error(text3, null);
					return false;
				}
				if (_retryCountForConnect > _maxRetryCountForConnect)
				{
					string text4 = "An opportunity for reconnecting has been lost.";
					_logger.Error(text4);
					text4 = "An interruption has occurred while attempting to connect.";
					error(text4, null);
					return false;
				}
				_readyState = WebSocketState.Connecting;
				try
				{
					doHandshake();
				}
				catch (Exception ex)
				{
					_retryCountForConnect++;
					_logger.Fatal(ex.Message);
					_logger.Debug(ex.ToString());
					string text5 = "An exception has occurred while attempting to connect.";
					fatal(text5, ex);
					return false;
				}
				_retryCountForConnect = 1;
				_readyState = WebSocketState.Open;
				return true;
			}
		}

		private string createExtensions()
		{
			StringBuilder stringBuilder = new StringBuilder(80);
			if (_compression != CompressionMethod.None)
			{
				string arg = _compression.ToExtensionString("server_no_context_takeover", "client_no_context_takeover");
				stringBuilder.AppendFormat("{0}, ", arg);
			}
			int length = stringBuilder.Length;
			if (length > 2)
			{
				stringBuilder.Length = length - 2;
				return stringBuilder.ToString();
			}
			return null;
		}

		private HttpResponse createHandshakeFailureResponse(WebSocketSharp.Net.HttpStatusCode code)
		{
			HttpResponse httpResponse = HttpResponse.CreateCloseResponse(code);
			httpResponse.Headers["Sec-WebSocket-Version"] = "13";
			return httpResponse;
		}

		private HttpRequest createHandshakeRequest()
		{
			HttpRequest httpRequest = HttpRequest.CreateWebSocketRequest(_uri);
			NameValueCollection headers = httpRequest.Headers;
			if (!_origin.IsNullOrEmpty())
			{
				headers["Origin"] = _origin;
			}
			headers["Sec-WebSocket-Key"] = _base64Key;
			_protocolsRequested = _protocols != null;
			if (_protocolsRequested)
			{
				headers["Sec-WebSocket-Protocol"] = _protocols.ToString(", ");
			}
			_extensionsRequested = _compression != CompressionMethod.None;
			if (_extensionsRequested)
			{
				headers["Sec-WebSocket-Extensions"] = createExtensions();
			}
			headers["Sec-WebSocket-Version"] = "13";
			AuthenticationResponse authenticationResponse = null;
			if (_authChallenge != null && _credentials != null)
			{
				authenticationResponse = new AuthenticationResponse(_authChallenge, _credentials, _nonceCount);
				_nonceCount = authenticationResponse.NonceCount;
			}
			else if (_preAuth)
			{
				authenticationResponse = new AuthenticationResponse(_credentials);
			}
			if (authenticationResponse != null)
			{
				headers["Authorization"] = authenticationResponse.ToString();
			}
			if (_cookies.Count > 0)
			{
				httpRequest.SetCookies(_cookies);
			}
			return httpRequest;
		}

		private HttpResponse createHandshakeResponse()
		{
			HttpResponse httpResponse = HttpResponse.CreateWebSocketResponse();
			NameValueCollection headers = httpResponse.Headers;
			headers["Sec-WebSocket-Accept"] = CreateResponseKey(_base64Key);
			if (_protocol != null)
			{
				headers["Sec-WebSocket-Protocol"] = _protocol;
			}
			if (_extensions != null)
			{
				headers["Sec-WebSocket-Extensions"] = _extensions;
			}
			if (_cookies.Count > 0)
			{
				httpResponse.SetCookies(_cookies);
			}
			return httpResponse;
		}

		private bool customCheckHandshakeRequest(WebSocketContext context, out string message)
		{
			message = null;
			if (_handshakeRequestChecker == null)
			{
				return true;
			}
			message = _handshakeRequestChecker(context);
			return message == null;
		}

		private MessageEventArgs dequeueFromMessageEventQueue()
		{
			lock (_forMessageEventQueue)
			{
				return (_messageEventQueue.Count > 0) ? _messageEventQueue.Dequeue() : null;
			}
		}

		private void doHandshake()
		{
			setClientStream();
			HttpResponse httpResponse = sendHandshakeRequest();
			if (!checkHandshakeResponse(httpResponse, out var text))
			{
				throw new WebSocketException(CloseStatusCode.ProtocolError, text);
			}
			if (_protocolsRequested)
			{
				_protocol = httpResponse.Headers["Sec-WebSocket-Protocol"];
			}
			if (_extensionsRequested)
			{
				processSecWebSocketExtensionsServerHeader(httpResponse.Headers["Sec-WebSocket-Extensions"]);
			}
			processCookies(httpResponse.Cookies);
		}

		private void enqueueToMessageEventQueue(MessageEventArgs e)
		{
			lock (_forMessageEventQueue)
			{
				_messageEventQueue.Enqueue(e);
			}
		}

		private void error(string message, Exception exception)
		{
			try
			{
				this.OnError.Emit(this, new ErrorEventArgs(message, exception));
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				_logger.Debug(ex.ToString());
			}
		}

		private void fatal(string message, Exception exception)
		{
			CloseStatusCode code = ((exception is WebSocketException) ? ((WebSocketException)exception).Code : CloseStatusCode.Abnormal);
			fatal(message, (ushort)code);
		}

		private void fatal(string message, ushort code)
		{
			PayloadData payloadData = new PayloadData(code, message);
			close(payloadData, !code.IsReserved(), receive: false, received: false);
		}

		private void fatal(string message, CloseStatusCode code)
		{
			fatal(message, (ushort)code);
		}

		private ClientSslConfiguration getSslConfiguration()
		{
			if (_sslConfig == null)
			{
				_sslConfig = new ClientSslConfiguration(_uri.DnsSafeHost);
			}
			return _sslConfig;
		}

		private void init()
		{
			_compression = CompressionMethod.None;
			_cookies = new WebSocketSharp.Net.CookieCollection();
			_forPing = new object();
			_forSend = new object();
			_forState = new object();
			_messageEventQueue = new Queue<MessageEventArgs>();
			_forMessageEventQueue = ((ICollection)_messageEventQueue).SyncRoot;
			_readyState = WebSocketState.Connecting;
		}

		private void message()
		{
			MessageEventArgs obj = null;
			lock (_forMessageEventQueue)
			{
				if (_inMessage || _messageEventQueue.Count == 0 || _readyState != WebSocketState.Open)
				{
					return;
				}
				_inMessage = true;
				obj = _messageEventQueue.Dequeue();
			}
			_message(obj);
		}

		private void messagec(MessageEventArgs e)
		{
			while (true)
			{
				try
				{
					this.OnMessage.Emit(this, e);
				}
				catch (Exception ex)
				{
					_logger.Error(ex.ToString());
					error("An error has occurred during an OnMessage event.", ex);
				}
				lock (_forMessageEventQueue)
				{
					if (_messageEventQueue.Count == 0 || _readyState != WebSocketState.Open)
					{
						_inMessage = false;
						break;
					}
					e = _messageEventQueue.Dequeue();
				}
				bool flag = true;
			}
		}

		private void messages(MessageEventArgs e)
		{
			try
			{
				this.OnMessage.Emit(this, e);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.ToString());
				error("An error has occurred during an OnMessage event.", ex);
			}
			lock (_forMessageEventQueue)
			{
				if (_messageEventQueue.Count == 0 || _readyState != WebSocketState.Open)
				{
					_inMessage = false;
					return;
				}
				e = _messageEventQueue.Dequeue();
			}
			ThreadPool.QueueUserWorkItem(delegate
			{
				messages(e);
			});
		}

		private void open()
		{
			_inMessage = true;
			startReceiving();
			try
			{
				this.OnOpen.Emit(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.ToString());
				error("An error has occurred during the OnOpen event.", ex);
			}
			MessageEventArgs obj = null;
			lock (_forMessageEventQueue)
			{
				if (_messageEventQueue.Count == 0 || _readyState != WebSocketState.Open)
				{
					_inMessage = false;
					return;
				}
				obj = _messageEventQueue.Dequeue();
			}
			_message.BeginInvoke(obj, delegate(IAsyncResult ar)
			{
				_message.EndInvoke(ar);
			}, null);
		}

		private bool ping(byte[] data)
		{
			if (_readyState != WebSocketState.Open)
			{
				return false;
			}
			ManualResetEvent pongReceived = _pongReceived;
			if (pongReceived == null)
			{
				return false;
			}
			lock (_forPing)
			{
				try
				{
					pongReceived.Reset();
					if (!send(Fin.Final, Opcode.Ping, data, compressed: false))
					{
						return false;
					}
					return pongReceived.WaitOne(_waitTime);
				}
				catch (ObjectDisposedException)
				{
					return false;
				}
			}
		}

		private bool processCloseFrame(WebSocketFrame frame)
		{
			PayloadData payloadData = frame.PayloadData;
			close(payloadData, !payloadData.HasReservedCode, receive: false, received: true);
			return false;
		}

		private void processCookies(WebSocketSharp.Net.CookieCollection cookies)
		{
			if (cookies.Count != 0)
			{
				_cookies.SetOrRemove(cookies);
			}
		}

		private bool processDataFrame(WebSocketFrame frame)
		{
			enqueueToMessageEventQueue(frame.IsCompressed ? new MessageEventArgs(frame.Opcode, frame.PayloadData.ApplicationData.Decompress(_compression)) : new MessageEventArgs(frame));
			return true;
		}

		private bool processFragmentFrame(WebSocketFrame frame)
		{
			if (!_inContinuation)
			{
				if (frame.IsContinuation)
				{
					return true;
				}
				_fragmentsOpcode = frame.Opcode;
				_fragmentsCompressed = frame.IsCompressed;
				_fragmentsBuffer = new MemoryStream();
				_inContinuation = true;
			}
			_fragmentsBuffer.WriteBytes(frame.PayloadData.ApplicationData, 1024);
			if (frame.IsFinal)
			{
				using (_fragmentsBuffer)
				{
					byte[] rawData = (_fragmentsCompressed ? _fragmentsBuffer.DecompressToArray(_compression) : _fragmentsBuffer.ToArray());
					enqueueToMessageEventQueue(new MessageEventArgs(_fragmentsOpcode, rawData));
				}
				_fragmentsBuffer = null;
				_inContinuation = false;
			}
			return true;
		}

		private bool processPingFrame(WebSocketFrame frame)
		{
			_logger.Trace("A ping was received.");
			WebSocketFrame webSocketFrame = WebSocketFrame.CreatePongFrame(frame.PayloadData, _client);
			lock (_forState)
			{
				if (_readyState != WebSocketState.Open)
				{
					_logger.Error("The connection is closing.");
					return true;
				}
				if (!sendBytes(webSocketFrame.ToArray()))
				{
					return false;
				}
			}
			_logger.Trace("A pong to this ping has been sent.");
			if (_emitOnPing)
			{
				if (_client)
				{
					webSocketFrame.Unmask();
				}
				enqueueToMessageEventQueue(new MessageEventArgs(frame));
			}
			return true;
		}

		private bool processPongFrame(WebSocketFrame frame)
		{
			_logger.Trace("A pong was received.");
			try
			{
				_pongReceived.Set();
			}
			catch (NullReferenceException ex)
			{
				_logger.Error(ex.Message);
				_logger.Debug(ex.ToString());
				return false;
			}
			catch (ObjectDisposedException ex2)
			{
				_logger.Error(ex2.Message);
				_logger.Debug(ex2.ToString());
				return false;
			}
			_logger.Trace("It has been signaled.");
			return true;
		}

		private bool processReceivedFrame(WebSocketFrame frame)
		{
			if (!checkReceivedFrame(frame, out var text))
			{
				throw new WebSocketException(CloseStatusCode.ProtocolError, text);
			}
			frame.Unmask();
			return frame.IsFragment ? processFragmentFrame(frame) : (frame.IsData ? processDataFrame(frame) : (frame.IsPing ? processPingFrame(frame) : (frame.IsPong ? processPongFrame(frame) : (frame.IsClose ? processCloseFrame(frame) : processUnsupportedFrame(frame)))));
		}

		private void processSecWebSocketExtensionsClientHeader(string value)
		{
			if (value == null)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder(80);
			bool flag = false;
			foreach (string item in value.SplitHeaderValue(','))
			{
				string text = item.Trim();
				if (text.Length != 0 && !flag && text.IsCompressionExtension(CompressionMethod.Deflate))
				{
					_compression = CompressionMethod.Deflate;
					stringBuilder.AppendFormat("{0}, ", _compression.ToExtensionString("client_no_context_takeover", "server_no_context_takeover"));
					flag = true;
				}
			}
			int length = stringBuilder.Length;
			if (length > 2)
			{
				stringBuilder.Length = length - 2;
				_extensions = stringBuilder.ToString();
			}
		}

		private void processSecWebSocketExtensionsServerHeader(string value)
		{
			if (value == null)
			{
				_compression = CompressionMethod.None;
			}
			else
			{
				_extensions = value;
			}
		}

		private void processSecWebSocketProtocolClientHeader(IEnumerable<string> values)
		{
			if (!values.Contains((string val) => val == _protocol))
			{
				_protocol = null;
			}
		}

		private bool processUnsupportedFrame(WebSocketFrame frame)
		{
			_logger.Fatal("An unsupported frame:" + frame.PrintToString(dumped: false));
			fatal("There is no way to handle it.", CloseStatusCode.PolicyViolation);
			return false;
		}

		private void refuseHandshake(CloseStatusCode code, string reason)
		{
			_readyState = WebSocketState.Closing;
			HttpResponse response = createHandshakeFailureResponse(WebSocketSharp.Net.HttpStatusCode.BadRequest);
			sendHttpResponse(response);
			releaseServerResources();
			_readyState = WebSocketState.Closed;
			CloseEventArgs e = new CloseEventArgs((ushort)code, reason, clean: false);
			try
			{
				this.OnClose.Emit(this, e);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				_logger.Debug(ex.ToString());
			}
		}

		private void releaseClientResources()
		{
			if (_stream != null)
			{
				_stream.Dispose();
				_stream = null;
			}
			if (_tcpClient != null)
			{
				_tcpClient.Close();
				_tcpClient = null;
			}
		}

		private void releaseCommonResources()
		{
			if (_fragmentsBuffer != null)
			{
				_fragmentsBuffer.Dispose();
				_fragmentsBuffer = null;
				_inContinuation = false;
			}
			if (_pongReceived != null)
			{
				_pongReceived.Close();
				_pongReceived = null;
			}
			if (_receivingExited != null)
			{
				_receivingExited.Close();
				_receivingExited = null;
			}
		}

		private void releaseResources()
		{
			if (_client)
			{
				releaseClientResources();
			}
			else
			{
				releaseServerResources();
			}
			releaseCommonResources();
		}

		private void releaseServerResources()
		{
			if (_closeContext != null)
			{
				_closeContext();
				_closeContext = null;
				_stream = null;
				_context = null;
			}
		}

		private bool send(Opcode opcode, Stream stream)
		{
			lock (_forSend)
			{
				Stream stream2 = stream;
				bool flag = false;
				bool flag2 = false;
				try
				{
					if (_compression != CompressionMethod.None)
					{
						stream = stream.Compress(_compression);
						flag = true;
					}
					flag2 = send(opcode, stream, flag);
					if (!flag2)
					{
						error("A send has been interrupted.", null);
					}
				}
				catch (Exception ex)
				{
					_logger.Error(ex.ToString());
					error("An error has occurred during a send.", ex);
				}
				finally
				{
					if (flag)
					{
						stream.Dispose();
					}
					stream2.Dispose();
				}
				return flag2;
			}
		}

		private bool send(Opcode opcode, Stream stream, bool compressed)
		{
			long length = stream.Length;
			if (length == 0)
			{
				return send(Fin.Final, opcode, EmptyBytes, compressed: false);
			}
			long num = length / FragmentLength;
			int num2 = (int)(length % FragmentLength);
			byte[] array = null;
			switch (num)
			{
			case 0L:
				array = new byte[num2];
				return stream.Read(array, 0, num2) == num2 && send(Fin.Final, opcode, array, compressed);
			case 1L:
				if (num2 == 0)
				{
					array = new byte[FragmentLength];
					return stream.Read(array, 0, FragmentLength) == FragmentLength && send(Fin.Final, opcode, array, compressed);
				}
				break;
			}
			array = new byte[FragmentLength];
			if (stream.Read(array, 0, FragmentLength) != FragmentLength || !send(Fin.More, opcode, array, compressed))
			{
				return false;
			}
			long num3 = ((num2 == 0) ? (num - 2) : (num - 1));
			for (long num4 = 0L; num4 < num3; num4++)
			{
				if (stream.Read(array, 0, FragmentLength) != FragmentLength || !send(Fin.More, Opcode.Cont, array, compressed: false))
				{
					return false;
				}
			}
			if (num2 == 0)
			{
				num2 = FragmentLength;
			}
			else
			{
				array = new byte[num2];
			}
			return stream.Read(array, 0, num2) == num2 && send(Fin.Final, Opcode.Cont, array, compressed: false);
		}

		private bool send(Fin fin, Opcode opcode, byte[] data, bool compressed)
		{
			lock (_forState)
			{
				if (_readyState != WebSocketState.Open)
				{
					_logger.Error("The connection is closing.");
					return false;
				}
				WebSocketFrame webSocketFrame = new WebSocketFrame(fin, opcode, data, compressed, _client);
				return sendBytes(webSocketFrame.ToArray());
			}
		}

		private void sendAsync(Opcode opcode, Stream stream, Action<bool> completed)
		{
			Func<Opcode, Stream, bool> sender = send;
			sender.BeginInvoke(opcode, stream, delegate(IAsyncResult ar)
			{
				try
				{
					bool obj = sender.EndInvoke(ar);
					if (completed != null)
					{
						completed(obj);
					}
				}
				catch (Exception ex)
				{
					_logger.Error(ex.ToString());
					error("An error has occurred during the callback for an async send.", ex);
				}
			}, null);
		}

		private bool sendBytes(byte[] bytes)
		{
			try
			{
				_stream.Write(bytes, 0, bytes.Length);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				_logger.Debug(ex.ToString());
				return false;
			}
			return true;
		}

		private HttpResponse sendHandshakeRequest()
		{
			HttpRequest httpRequest = createHandshakeRequest();
			HttpResponse httpResponse = sendHttpRequest(httpRequest, 90000);
			if (httpResponse.IsUnauthorized)
			{
				string text = httpResponse.Headers["WWW-Authenticate"];
				_logger.Warn($"Received an authentication requirement for '{text}'.");
				if (text.IsNullOrEmpty())
				{
					_logger.Error("No authentication challenge is specified.");
					return httpResponse;
				}
				_authChallenge = AuthenticationChallenge.Parse(text);
				if (_authChallenge == null)
				{
					_logger.Error("An invalid authentication challenge is specified.");
					return httpResponse;
				}
				if (_credentials != null && (!_preAuth || _authChallenge.Scheme == WebSocketSharp.Net.AuthenticationSchemes.Digest))
				{
					if (httpResponse.HasConnectionClose)
					{
						releaseClientResources();
						setClientStream();
					}
					AuthenticationResponse authenticationResponse = new AuthenticationResponse(_authChallenge, _credentials, _nonceCount);
					_nonceCount = authenticationResponse.NonceCount;
					httpRequest.Headers["Authorization"] = authenticationResponse.ToString();
					httpResponse = sendHttpRequest(httpRequest, 15000);
				}
			}
			if (httpResponse.IsRedirect)
			{
				string text2 = httpResponse.Headers["Location"];
				_logger.Warn($"Received a redirection to '{text2}'.");
				if (_enableRedirection)
				{
					if (text2.IsNullOrEmpty())
					{
						_logger.Error("No url to redirect is located.");
						return httpResponse;
					}
					if (!text2.TryCreateWebSocketUri(out var result, out var text3))
					{
						_logger.Error("An invalid url to redirect is located: " + text3);
						return httpResponse;
					}
					releaseClientResources();
					_uri = result;
					_secure = result.Scheme == "wss";
					setClientStream();
					return sendHandshakeRequest();
				}
			}
			return httpResponse;
		}

		private HttpResponse sendHttpRequest(HttpRequest request, int millisecondsTimeout)
		{
			_logger.Debug("A request to the server:\n" + request.ToString());
			HttpResponse response = request.GetResponse(_stream, millisecondsTimeout);
			_logger.Debug("A response to this request:\n" + response.ToString());
			return response;
		}

		private bool sendHttpResponse(HttpResponse response)
		{
			_logger.Debug($"A response to {_context.UserEndPoint}:\n{response}");
			return sendBytes(response.ToByteArray());
		}

		private void sendProxyConnectRequest()
		{
			HttpRequest httpRequest = HttpRequest.CreateConnectRequest(_uri);
			HttpResponse httpResponse = sendHttpRequest(httpRequest, 90000);
			if (httpResponse.IsProxyAuthenticationRequired)
			{
				string text = httpResponse.Headers["Proxy-Authenticate"];
				_logger.Warn($"Received a proxy authentication requirement for '{text}'.");
				if (text.IsNullOrEmpty())
				{
					throw new WebSocketException("No proxy authentication challenge is specified.");
				}
				AuthenticationChallenge authenticationChallenge = AuthenticationChallenge.Parse(text);
				if (authenticationChallenge == null)
				{
					throw new WebSocketException("An invalid proxy authentication challenge is specified.");
				}
				if (_proxyCredentials != null)
				{
					if (httpResponse.HasConnectionClose)
					{
						releaseClientResources();
						_tcpClient = new TcpClient(_proxyUri.DnsSafeHost, _proxyUri.Port);
						_stream = _tcpClient.GetStream();
					}
					AuthenticationResponse authenticationResponse = new AuthenticationResponse(authenticationChallenge, _proxyCredentials, 0u);
					httpRequest.Headers["Proxy-Authorization"] = authenticationResponse.ToString();
					httpResponse = sendHttpRequest(httpRequest, 15000);
				}
				if (httpResponse.IsProxyAuthenticationRequired)
				{
					throw new WebSocketException("A proxy authentication is required.");
				}
			}
			if (httpResponse.StatusCode[0] != '2')
			{
				throw new WebSocketException("The proxy has failed a connection to the requested host and port.");
			}
		}

		private void setClientStream()
		{
			if (_proxyUri != null)
			{
				_tcpClient = new TcpClient(_proxyUri.DnsSafeHost, _proxyUri.Port);
				_stream = _tcpClient.GetStream();
				sendProxyConnectRequest();
			}
			else
			{
				_tcpClient = new TcpClient(_uri.DnsSafeHost, _uri.Port);
				_stream = _tcpClient.GetStream();
			}
			if (_secure)
			{
				ClientSslConfiguration sslConfiguration = getSslConfiguration();
				string targetHost = sslConfiguration.TargetHost;
				if (targetHost != _uri.DnsSafeHost)
				{
					throw new WebSocketException(CloseStatusCode.TlsHandshakeFailure, "An invalid host name is specified.");
				}
				try
				{
					SslStream sslStream = new SslStream(_stream, leaveInnerStreamOpen: false, sslConfiguration.ServerCertificateValidationCallback, sslConfiguration.ClientCertificateSelectionCallback);
					sslStream.AuthenticateAsClient(targetHost, sslConfiguration.ClientCertificates, sslConfiguration.EnabledSslProtocols, sslConfiguration.CheckCertificateRevocation);
					_stream = sslStream;
				}
				catch (Exception innerException)
				{
					throw new WebSocketException(CloseStatusCode.TlsHandshakeFailure, innerException);
				}
			}
		}

		private void startReceiving()
		{
			if (_messageEventQueue.Count > 0)
			{
				_messageEventQueue.Clear();
			}
			_pongReceived = new ManualResetEvent(initialState: false);
			_receivingExited = new ManualResetEvent(initialState: false);
			Action receive = null;
			receive = delegate
			{
				WebSocketFrame.ReadFrameAsync(_stream, unmask: false, delegate(WebSocketFrame frame)
				{
					if (!processReceivedFrame(frame) || _readyState == WebSocketState.Closed)
					{
						_receivingExited?.Set();
					}
					else
					{
						receive();
						if (!_inMessage && HasMessage && _readyState == WebSocketState.Open)
						{
							message();
						}
					}
				}, delegate(Exception ex)
				{
					_logger.Fatal(ex.ToString());
					fatal("An exception has occurred while receiving.", ex);
				});
			};
			receive();
		}

		private bool validateSecWebSocketAcceptHeader(string value)
		{
			return value != null && value == CreateResponseKey(_base64Key);
		}

		private bool validateSecWebSocketExtensionsServerHeader(string value)
		{
			if (value == null)
			{
				return true;
			}
			if (value.Length == 0)
			{
				return false;
			}
			if (!_extensionsRequested)
			{
				return false;
			}
			bool flag = _compression != CompressionMethod.None;
			foreach (string item in value.SplitHeaderValue(','))
			{
				string text = item.Trim();
				if (flag && text.IsCompressionExtension(_compression))
				{
					if (!text.Contains("server_no_context_takeover"))
					{
						_logger.Error("The server hasn't sent back 'server_no_context_takeover'.");
						return false;
					}
					if (!text.Contains("client_no_context_takeover"))
					{
						_logger.Warn("The server hasn't sent back 'client_no_context_takeover'.");
					}
					string method = _compression.ToExtensionString();
					if (text.SplitHeaderValue(';').Contains(delegate(string t)
					{
						t = t.Trim();
						return t != method && t != "server_no_context_takeover" && t != "client_no_context_takeover";
					}))
					{
						return false;
					}
					continue;
				}
				return false;
			}
			return true;
		}

		private bool validateSecWebSocketProtocolServerHeader(string value)
		{
			if (value == null)
			{
				return !_protocolsRequested;
			}
			if (value.Length == 0)
			{
				return false;
			}
			return _protocolsRequested && _protocols.Contains((string p) => p == value);
		}

		private bool validateSecWebSocketVersionServerHeader(string value)
		{
			return value == null || value == "13";
		}

		internal void Close(HttpResponse response)
		{
			_readyState = WebSocketState.Closing;
			sendHttpResponse(response);
			releaseServerResources();
			_readyState = WebSocketState.Closed;
		}

		internal void Close(WebSocketSharp.Net.HttpStatusCode code)
		{
			Close(createHandshakeFailureResponse(code));
		}

		internal void Close(PayloadData payloadData, byte[] frameAsBytes)
		{
			lock (_forState)
			{
				if (_readyState == WebSocketState.Closing)
				{
					_logger.Info("The closing is already in progress.");
					return;
				}
				if (_readyState == WebSocketState.Closed)
				{
					_logger.Info("The connection has already been closed.");
					return;
				}
				_readyState = WebSocketState.Closing;
			}
			_logger.Trace("Begin closing the connection.");
			bool flag = frameAsBytes != null && sendBytes(frameAsBytes);
			bool flag2 = flag && _receivingExited != null && _receivingExited.WaitOne(_waitTime);
			bool flag3 = flag && flag2;
			_logger.Debug($"Was clean?: {flag3}\n  sent: {flag}\n  received: {flag2}");
			releaseServerResources();
			releaseCommonResources();
			_logger.Trace("End closing the connection.");
			_readyState = WebSocketState.Closed;
			CloseEventArgs e = new CloseEventArgs(payloadData, flag3);
			try
			{
				this.OnClose.Emit(this, e);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				_logger.Debug(ex.ToString());
			}
		}

		internal static string CreateBase64Key()
		{
			byte[] array = new byte[16];
			RandomNumber.GetBytes(array);
			return Convert.ToBase64String(array);
		}

		internal static string CreateResponseKey(string base64Key)
		{
			StringBuilder stringBuilder = new StringBuilder(base64Key, 64);
			stringBuilder.Append("258EAFA5-E914-47DA-95CA-C5AB0DC85B11");
			SHA1 sHA = new SHA1CryptoServiceProvider();
			byte[] inArray = sHA.ComputeHash(stringBuilder.ToString().GetUTF8EncodedBytes());
			return Convert.ToBase64String(inArray);
		}

		internal void InternalAccept()
		{
			try
			{
				if (!acceptHandshake())
				{
					return;
				}
			}
			catch (Exception ex)
			{
				_logger.Fatal(ex.Message);
				_logger.Debug(ex.ToString());
				string text = "An exception has occurred while attempting to accept.";
				fatal(text, ex);
				return;
			}
			_readyState = WebSocketState.Open;
			open();
		}

		internal bool Ping(byte[] frameAsBytes, TimeSpan timeout)
		{
			if (_readyState != WebSocketState.Open)
			{
				return false;
			}
			ManualResetEvent pongReceived = _pongReceived;
			if (pongReceived == null)
			{
				return false;
			}
			lock (_forPing)
			{
				try
				{
					pongReceived.Reset();
					lock (_forState)
					{
						if (_readyState != WebSocketState.Open)
						{
							return false;
						}
						if (!sendBytes(frameAsBytes))
						{
							return false;
						}
					}
					return pongReceived.WaitOne(timeout);
				}
				catch (ObjectDisposedException)
				{
					return false;
				}
			}
		}

		internal void Send(Opcode opcode, byte[] data, Dictionary<CompressionMethod, byte[]> cache)
		{
			lock (_forSend)
			{
				lock (_forState)
				{
					if (_readyState != WebSocketState.Open)
					{
						_logger.Error("The connection is closing.");
						return;
					}
					if (!cache.TryGetValue(_compression, out var value))
					{
						value = new WebSocketFrame(Fin.Final, opcode, data.Compress(_compression), _compression != CompressionMethod.None, mask: false).ToArray();
						cache.Add(_compression, value);
					}
					sendBytes(value);
				}
			}
		}

		internal void Send(Opcode opcode, Stream stream, Dictionary<CompressionMethod, Stream> cache)
		{
			lock (_forSend)
			{
				if (!cache.TryGetValue(_compression, out var value))
				{
					value = stream.Compress(_compression);
					cache.Add(_compression, value);
				}
				else
				{
					value.Position = 0L;
				}
				send(opcode, value, _compression != CompressionMethod.None);
			}
		}

		public void Accept()
		{
			if (_client)
			{
				string text = "This instance is a client.";
				throw new InvalidOperationException(text);
			}
			if (_readyState == WebSocketState.Closing)
			{
				string text2 = "The close process is in progress.";
				throw new InvalidOperationException(text2);
			}
			if (_readyState == WebSocketState.Closed)
			{
				string text3 = "The connection has already been closed.";
				throw new InvalidOperationException(text3);
			}
			if (accept())
			{
				open();
			}
		}

		public void AcceptAsync()
		{
			if (_client)
			{
				string text = "This instance is a client.";
				throw new InvalidOperationException(text);
			}
			if (_readyState == WebSocketState.Closing)
			{
				string text2 = "The close process is in progress.";
				throw new InvalidOperationException(text2);
			}
			if (_readyState == WebSocketState.Closed)
			{
				string text3 = "The connection has already been closed.";
				throw new InvalidOperationException(text3);
			}
			Func<bool> acceptor = accept;
			acceptor.BeginInvoke(delegate(IAsyncResult ar)
			{
				if (acceptor.EndInvoke(ar))
				{
					open();
				}
			}, null);
		}

		public void Close()
		{
			close(1005, string.Empty);
		}

		public void Close(ushort code)
		{
			if (!code.IsCloseStatusCode())
			{
				string text = "Less than 1000 or greater than 4999.";
				throw new ArgumentOutOfRangeException("code", text);
			}
			if (_client && code == 1011)
			{
				string text2 = "1011 cannot be used.";
				throw new ArgumentException(text2, "code");
			}
			if (!_client && code == 1010)
			{
				string text3 = "1010 cannot be used.";
				throw new ArgumentException(text3, "code");
			}
			close(code, string.Empty);
		}

		public void Close(CloseStatusCode code)
		{
			if (_client && code == CloseStatusCode.ServerError)
			{
				string text = "ServerError cannot be used.";
				throw new ArgumentException(text, "code");
			}
			if (!_client && code == CloseStatusCode.MandatoryExtension)
			{
				string text2 = "MandatoryExtension cannot be used.";
				throw new ArgumentException(text2, "code");
			}
			close((ushort)code, string.Empty);
		}

		public void Close(ushort code, string reason)
		{
			if (!code.IsCloseStatusCode())
			{
				string text = "Less than 1000 or greater than 4999.";
				throw new ArgumentOutOfRangeException("code", text);
			}
			if (_client && code == 1011)
			{
				string text2 = "1011 cannot be used.";
				throw new ArgumentException(text2, "code");
			}
			if (!_client && code == 1010)
			{
				string text3 = "1010 cannot be used.";
				throw new ArgumentException(text3, "code");
			}
			if (reason.IsNullOrEmpty())
			{
				close(code, string.Empty);
				return;
			}
			if (code == 1005)
			{
				string text4 = "1005 cannot be used.";
				throw new ArgumentException(text4, "code");
			}
			if (!reason.TryGetUTF8EncodedBytes(out var bytes))
			{
				string text5 = "It could not be UTF-8-encoded.";
				throw new ArgumentException(text5, "reason");
			}
			if (bytes.Length > 123)
			{
				string text6 = "Its size is greater than 123 bytes.";
				throw new ArgumentOutOfRangeException("reason", text6);
			}
			close(code, reason);
		}

		public void Close(CloseStatusCode code, string reason)
		{
			if (_client && code == CloseStatusCode.ServerError)
			{
				string text = "ServerError cannot be used.";
				throw new ArgumentException(text, "code");
			}
			if (!_client && code == CloseStatusCode.MandatoryExtension)
			{
				string text2 = "MandatoryExtension cannot be used.";
				throw new ArgumentException(text2, "code");
			}
			if (reason.IsNullOrEmpty())
			{
				close((ushort)code, string.Empty);
				return;
			}
			if (code == CloseStatusCode.NoStatus)
			{
				string text3 = "NoStatus cannot be used.";
				throw new ArgumentException(text3, "code");
			}
			if (!reason.TryGetUTF8EncodedBytes(out var bytes))
			{
				string text4 = "It could not be UTF-8-encoded.";
				throw new ArgumentException(text4, "reason");
			}
			if (bytes.Length > 123)
			{
				string text5 = "Its size is greater than 123 bytes.";
				throw new ArgumentOutOfRangeException("reason", text5);
			}
			close((ushort)code, reason);
		}

		public void CloseAsync()
		{
			closeAsync(1005, string.Empty);
		}

		public void CloseAsync(ushort code)
		{
			if (!code.IsCloseStatusCode())
			{
				string text = "Less than 1000 or greater than 4999.";
				throw new ArgumentOutOfRangeException("code", text);
			}
			if (_client && code == 1011)
			{
				string text2 = "1011 cannot be used.";
				throw new ArgumentException(text2, "code");
			}
			if (!_client && code == 1010)
			{
				string text3 = "1010 cannot be used.";
				throw new ArgumentException(text3, "code");
			}
			closeAsync(code, string.Empty);
		}

		public void CloseAsync(CloseStatusCode code)
		{
			if (_client && code == CloseStatusCode.ServerError)
			{
				string text = "ServerError cannot be used.";
				throw new ArgumentException(text, "code");
			}
			if (!_client && code == CloseStatusCode.MandatoryExtension)
			{
				string text2 = "MandatoryExtension cannot be used.";
				throw new ArgumentException(text2, "code");
			}
			closeAsync((ushort)code, string.Empty);
		}

		public void CloseAsync(ushort code, string reason)
		{
			if (!code.IsCloseStatusCode())
			{
				string text = "Less than 1000 or greater than 4999.";
				throw new ArgumentOutOfRangeException("code", text);
			}
			if (_client && code == 1011)
			{
				string text2 = "1011 cannot be used.";
				throw new ArgumentException(text2, "code");
			}
			if (!_client && code == 1010)
			{
				string text3 = "1010 cannot be used.";
				throw new ArgumentException(text3, "code");
			}
			if (reason.IsNullOrEmpty())
			{
				closeAsync(code, string.Empty);
				return;
			}
			if (code == 1005)
			{
				string text4 = "1005 cannot be used.";
				throw new ArgumentException(text4, "code");
			}
			if (!reason.TryGetUTF8EncodedBytes(out var bytes))
			{
				string text5 = "It could not be UTF-8-encoded.";
				throw new ArgumentException(text5, "reason");
			}
			if (bytes.Length > 123)
			{
				string text6 = "Its size is greater than 123 bytes.";
				throw new ArgumentOutOfRangeException("reason", text6);
			}
			closeAsync(code, reason);
		}

		public void CloseAsync(CloseStatusCode code, string reason)
		{
			if (_client && code == CloseStatusCode.ServerError)
			{
				string text = "ServerError cannot be used.";
				throw new ArgumentException(text, "code");
			}
			if (!_client && code == CloseStatusCode.MandatoryExtension)
			{
				string text2 = "MandatoryExtension cannot be used.";
				throw new ArgumentException(text2, "code");
			}
			if (reason.IsNullOrEmpty())
			{
				closeAsync((ushort)code, string.Empty);
				return;
			}
			if (code == CloseStatusCode.NoStatus)
			{
				string text3 = "NoStatus cannot be used.";
				throw new ArgumentException(text3, "code");
			}
			if (!reason.TryGetUTF8EncodedBytes(out var bytes))
			{
				string text4 = "It could not be UTF-8-encoded.";
				throw new ArgumentException(text4, "reason");
			}
			if (bytes.Length > 123)
			{
				string text5 = "Its size is greater than 123 bytes.";
				throw new ArgumentOutOfRangeException("reason", text5);
			}
			closeAsync((ushort)code, reason);
		}

		public void Connect()
		{
			if (!_client)
			{
				string text = "This instance is not a client.";
				throw new InvalidOperationException(text);
			}
			if (_readyState == WebSocketState.Closing)
			{
				string text2 = "The close process is in progress.";
				throw new InvalidOperationException(text2);
			}
			if (_retryCountForConnect > _maxRetryCountForConnect)
			{
				string text3 = "A series of reconnecting has failed.";
				throw new InvalidOperationException(text3);
			}
			if (connect())
			{
				open();
			}
		}

		public void ConnectAsync()
		{
			if (!_client)
			{
				string text = "This instance is not a client.";
				throw new InvalidOperationException(text);
			}
			if (_readyState == WebSocketState.Closing)
			{
				string text2 = "The close process is in progress.";
				throw new InvalidOperationException(text2);
			}
			if (_retryCountForConnect > _maxRetryCountForConnect)
			{
				string text3 = "A series of reconnecting has failed.";
				throw new InvalidOperationException(text3);
			}
			Func<bool> connector = connect;
			connector.BeginInvoke(delegate(IAsyncResult ar)
			{
				if (connector.EndInvoke(ar))
				{
					open();
				}
			}, null);
		}

		public bool Ping()
		{
			return ping(EmptyBytes);
		}

		public bool Ping(string message)
		{
			if (message.IsNullOrEmpty())
			{
				return ping(EmptyBytes);
			}
			if (!message.TryGetUTF8EncodedBytes(out var bytes))
			{
				string text = "It could not be UTF-8-encoded.";
				throw new ArgumentException(text, "message");
			}
			if (bytes.Length > 125)
			{
				string text2 = "Its size is greater than 125 bytes.";
				throw new ArgumentOutOfRangeException("message", text2);
			}
			return ping(bytes);
		}

		public void Send(byte[] data)
		{
			if (_readyState != WebSocketState.Open)
			{
				string text = "The current state of the connection is not Open.";
				throw new InvalidOperationException(text);
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			send(Opcode.Binary, new MemoryStream(data));
		}

		public void Send(FileInfo fileInfo)
		{
			if (_readyState != WebSocketState.Open)
			{
				string text = "The current state of the connection is not Open.";
				throw new InvalidOperationException(text);
			}
			if (fileInfo == null)
			{
				throw new ArgumentNullException("fileInfo");
			}
			if (!fileInfo.Exists)
			{
				string text2 = "The file does not exist.";
				throw new ArgumentException(text2, "fileInfo");
			}
			if (!fileInfo.TryOpenRead(out var fileStream))
			{
				string text3 = "The file could not be opened.";
				throw new ArgumentException(text3, "fileInfo");
			}
			send(Opcode.Binary, fileStream);
		}

		public void Send(string data)
		{
			if (_readyState != WebSocketState.Open)
			{
				string text = "The current state of the connection is not Open.";
				throw new InvalidOperationException(text);
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (!data.TryGetUTF8EncodedBytes(out var bytes))
			{
				string text2 = "It could not be UTF-8-encoded.";
				throw new ArgumentException(text2, "data");
			}
			send(Opcode.Text, new MemoryStream(bytes));
		}

		public void Send(Stream stream, int length)
		{
			if (_readyState != WebSocketState.Open)
			{
				string text = "The current state of the connection is not Open.";
				throw new InvalidOperationException(text);
			}
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanRead)
			{
				string text2 = "It cannot be read.";
				throw new ArgumentException(text2, "stream");
			}
			if (length < 1)
			{
				string text3 = "Less than 1.";
				throw new ArgumentException(text3, "length");
			}
			byte[] array = stream.ReadBytes(length);
			int num = array.Length;
			if (num == 0)
			{
				string text4 = "No data could be read from it.";
				throw new ArgumentException(text4, "stream");
			}
			if (num < length)
			{
				_logger.Warn($"Only {num} byte(s) of data could be read from the stream.");
			}
			send(Opcode.Binary, new MemoryStream(array));
		}

		public void SendAsync(byte[] data, Action<bool> completed)
		{
			if (_readyState != WebSocketState.Open)
			{
				string text = "The current state of the connection is not Open.";
				throw new InvalidOperationException(text);
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			sendAsync(Opcode.Binary, new MemoryStream(data), completed);
		}

		public void SendAsync(FileInfo fileInfo, Action<bool> completed)
		{
			if (_readyState != WebSocketState.Open)
			{
				string text = "The current state of the connection is not Open.";
				throw new InvalidOperationException(text);
			}
			if (fileInfo == null)
			{
				throw new ArgumentNullException("fileInfo");
			}
			if (!fileInfo.Exists)
			{
				string text2 = "The file does not exist.";
				throw new ArgumentException(text2, "fileInfo");
			}
			if (!fileInfo.TryOpenRead(out var fileStream))
			{
				string text3 = "The file could not be opened.";
				throw new ArgumentException(text3, "fileInfo");
			}
			sendAsync(Opcode.Binary, fileStream, completed);
		}

		public void SendAsync(string data, Action<bool> completed)
		{
			if (_readyState != WebSocketState.Open)
			{
				string text = "The current state of the connection is not Open.";
				throw new InvalidOperationException(text);
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (!data.TryGetUTF8EncodedBytes(out var bytes))
			{
				string text2 = "It could not be UTF-8-encoded.";
				throw new ArgumentException(text2, "data");
			}
			sendAsync(Opcode.Text, new MemoryStream(bytes), completed);
		}

		public void SendAsync(Stream stream, int length, Action<bool> completed)
		{
			if (_readyState != WebSocketState.Open)
			{
				string text = "The current state of the connection is not Open.";
				throw new InvalidOperationException(text);
			}
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanRead)
			{
				string text2 = "It cannot be read.";
				throw new ArgumentException(text2, "stream");
			}
			if (length < 1)
			{
				string text3 = "Less than 1.";
				throw new ArgumentException(text3, "length");
			}
			byte[] array = stream.ReadBytes(length);
			int num = array.Length;
			if (num == 0)
			{
				string text4 = "No data could be read from it.";
				throw new ArgumentException(text4, "stream");
			}
			if (num < length)
			{
				_logger.Warn($"Only {num} byte(s) of data could be read from the stream.");
			}
			sendAsync(Opcode.Binary, new MemoryStream(array), completed);
		}

		public void SetCookie(WebSocketSharp.Net.Cookie cookie)
		{
			string text = null;
			if (!_client)
			{
				text = "This instance is not a client.";
				throw new InvalidOperationException(text);
			}
			if (cookie == null)
			{
				throw new ArgumentNullException("cookie");
			}
			if (!canSet(out text))
			{
				_logger.Warn(text);
				return;
			}
			lock (_forState)
			{
				if (!canSet(out text))
				{
					_logger.Warn(text);
					return;
				}
				lock (_cookies.SyncRoot)
				{
					_cookies.SetOrRemove(cookie);
				}
			}
		}

		public void SetCredentials(string username, string password, bool preAuth)
		{
			string text = null;
			if (!_client)
			{
				text = "This instance is not a client.";
				throw new InvalidOperationException(text);
			}
			if (!username.IsNullOrEmpty() && (Ext.Contains(username, ':') || !username.IsText()))
			{
				text = "It contains an invalid character.";
				throw new ArgumentException(text, "username");
			}
			if (!password.IsNullOrEmpty() && !password.IsText())
			{
				text = "It contains an invalid character.";
				throw new ArgumentException(text, "password");
			}
			if (!canSet(out text))
			{
				_logger.Warn(text);
				return;
			}
			lock (_forState)
			{
				if (!canSet(out text))
				{
					_logger.Warn(text);
				}
				else if (username.IsNullOrEmpty())
				{
					_credentials = null;
					_preAuth = false;
				}
				else
				{
					_credentials = new WebSocketSharp.Net.NetworkCredential(username, password, _uri.PathAndQuery);
					_preAuth = preAuth;
				}
			}
		}

		public void SetProxy(string url, string username, string password)
		{
			string text = null;
			if (!_client)
			{
				text = "This instance is not a client.";
				throw new InvalidOperationException(text);
			}
			Uri result = null;
			if (!url.IsNullOrEmpty())
			{
				if (!Uri.TryCreate(url, UriKind.Absolute, out result))
				{
					text = "Not an absolute URI string.";
					throw new ArgumentException(text, "url");
				}
				if (result.Scheme != "http")
				{
					text = "The scheme part is not http.";
					throw new ArgumentException(text, "url");
				}
				if (result.Segments.Length > 1)
				{
					text = "It includes the path segments.";
					throw new ArgumentException(text, "url");
				}
			}
			if (!username.IsNullOrEmpty() && (Ext.Contains(username, ':') || !username.IsText()))
			{
				text = "It contains an invalid character.";
				throw new ArgumentException(text, "username");
			}
			if (!password.IsNullOrEmpty() && !password.IsText())
			{
				text = "It contains an invalid character.";
				throw new ArgumentException(text, "password");
			}
			if (!canSet(out text))
			{
				_logger.Warn(text);
				return;
			}
			lock (_forState)
			{
				if (!canSet(out text))
				{
					_logger.Warn(text);
				}
				else if (url.IsNullOrEmpty())
				{
					_proxyUri = null;
					_proxyCredentials = null;
				}
				else
				{
					_proxyUri = result;
					_proxyCredentials = ((!username.IsNullOrEmpty()) ? new WebSocketSharp.Net.NetworkCredential(username, password, $"{_uri.DnsSafeHost}:{_uri.Port}") : null);
				}
			}
		}

		void IDisposable.Dispose()
		{
			close(1001, string.Empty);
		}
	}
	public enum CloseStatusCode : ushort
	{
		Normal = 1000,
		Away = 1001,
		ProtocolError = 1002,
		UnsupportedData = 1003,
		Undefined = 1004,
		NoStatus = 1005,
		Abnormal = 1006,
		InvalidData = 1007,
		PolicyViolation = 1008,
		TooBig = 1009,
		MandatoryExtension = 1010,
		ServerError = 1011,
		TlsHandshakeFailure = 1015
	}
	internal enum Fin : byte
	{
		More,
		Final
	}
	internal enum Mask : byte
	{
		Off,
		On
	}
	internal enum Opcode : byte
	{
		Cont = 0,
		Text = 1,
		Binary = 2,
		Close = 8,
		Ping = 9,
		Pong = 10
	}
	internal class PayloadData : IEnumerable<byte>, IEnumerable
	{
		private byte[] _data;

		private long _extDataLength;

		private long _length;

		public static readonly PayloadData Empty;

		public static readonly ulong MaxLength;

		internal ushort Code => (ushort)((_length >= 2) ? _data.SubArray(0, 2).ToUInt16(ByteOrder.Big) : 1005);

		internal long ExtensionDataLength
		{
			get
			{
				return _extDataLength;
			}
			set
			{
				_extDataLength = value;
			}
		}

		internal bool HasReservedCode => _length >= 2 && Code.IsReserved();

		internal string Reason
		{
			get
			{
				if (_length <= 2)
				{
					return string.Empty;
				}
				byte[] bytes = _data.SubArray(2L, _length - 2);
				string s;
				return bytes.TryGetUTF8DecodedString(out s) ? s : string.Empty;
			}
		}

		public byte[] ApplicationData => (_extDataLength > 0) ? _data.SubArray(_extDataLength, _length - _extDataLength) : _data;

		public byte[] ExtensionData => (_extDataLength > 0) ? _data.SubArray(0L, _extDataLength) : WebSocket.EmptyBytes;

		public ulong Length => (ulong)_length;

		static PayloadData()
		{
			Empty = new PayloadData(WebSocket.EmptyBytes, 0L);
			MaxLength = 9223372036854775807uL;
		}

		internal PayloadData(byte[] data)
			: this(data, data.LongLength)
		{
		}

		internal PayloadData(byte[] data, long length)
		{
			_data = data;
			_length = length;
		}

		internal PayloadData(ushort code, string reason)
		{
			_data = code.Append(reason);
			_length = _data.LongLength;
		}

		internal void Mask(byte[] key)
		{
			for (long num = 0L; num < _length; num++)
			{
				_data[num] ^= key[num % 4];
			}
		}

		public IEnumerator<byte> GetEnumerator()
		{
			byte[] data = _data;
			for (int i = 0; i < data.Length; i++)
			{
				yield return data[i];
			}
		}

		public byte[] ToArray()
		{
			return _data;
		}

		public override string ToString()
		{
			return BitConverter.ToString(_data);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	internal enum Rsv : byte
	{
		Off,
		On
	}
	public enum CompressionMethod : byte
	{
		None,
		Deflate
	}
	public class WebSocketException : Exception
	{
		private CloseStatusCode _code;

		public CloseStatusCode Code => _code;

		internal WebSocketException()
			: this(CloseStatusCode.Abnormal, null, null)
		{
		}

		internal WebSocketException(Exception innerException)
			: this(CloseStatusCode.Abnormal, null, innerException)
		{
		}

		internal WebSocketException(string message)
			: this(CloseStatusCode.Abnormal, message, null)
		{
		}

		internal WebSocketException(CloseStatusCode code)
			: this(code, null, null)
		{
		}

		internal WebSocketException(string message, Exception innerException)
			: this(CloseStatusCode.Abnormal, message, innerException)
		{
		}

		internal WebSocketException(CloseStatusCode code, Exception innerException)
			: this(code, null, innerException)
		{
		}

		internal WebSocketException(CloseStatusCode code, string message)
			: this(code, message, null)
		{
		}

		internal WebSocketException(CloseStatusCode code, string message, Exception innerException)
			: base(message ?? code.GetMessage(), innerException)
		{
			_code = code;
		}
	}
	public class LogData
	{
		private StackFrame _caller;

		private DateTime _date;

		private LogLevel _level;

		private string _message;

		public StackFrame Caller => _caller;

		public DateTime Date => _date;

		public LogLevel Level => _level;

		public string Message => _message;

		internal LogData(LogLevel level, StackFrame caller, string message)
		{
			_level = level;
			_caller = caller;
			_message = message ?? string.Empty;
			_date = DateTime.Now;
		}

		public override string ToString()
		{
			string text = $"{_date}|{_level,-5}|";
			MethodBase method = _caller.GetMethod();
			Type declaringType = method.DeclaringType;
			int fileLineNumber = _caller.GetFileLineNumber();
			string arg = $"{text}{declaringType.Name}.{method.Name}:{fileLineNumber}|";
			string[] array = _message.Replace("\r\n", "\n").TrimEnd(new char[1] { '\n' }).Split(new char[1] { '\n' });
			if (array.Length <= 1)
			{
				return $"{arg}{_message}";
			}
			StringBuilder stringBuilder = new StringBuilder($"{arg}{array[0]}\n", 64);
			string format = $"{{0,{text.Length}}}{{1}}\n";
			for (int i = 1; i < array.Length; i++)
			{
				stringBuilder.AppendFormat(format, "", array[i]);
			}
			stringBuilder.Length--;
			return stringBuilder.ToString();
		}
	}
	public enum LogLevel
	{
		Trace,
		Debug,
		Info,
		Warn,
		Error,
		Fatal
	}
	public class Logger
	{
		private volatile string _file;

		private volatile LogLevel _level;

		private Action<LogData, string> _output;

		private object _sync;

		public string File
		{
			get
			{
				return _file;
			}
			set
			{
				lock (_sync)
				{
					_file = value;
					Warn($"The current path to the log file has been changed to {_file}.");
				}
			}
		}

		public LogLevel Level
		{
			get
			{
				return _level;
			}
			set
			{
				lock (_sync)
				{
					_level = value;
					Warn($"The current logging level has been changed to {_level}.");
				}
			}
		}

		public Action<LogData, string> Output
		{
			get
			{
				return _output;
			}
			set
			{
				lock (_sync)
				{
					_output = value ?? new Action<LogData, string>(defaultOutput);
					Warn("The current output action has been changed.");
				}
			}
		}

		public Logger()
			: this(LogLevel.Error, null, null)
		{
		}

		public Logger(LogLevel level)
			: this(level, null, null)
		{
		}

		public Logger(LogLevel level, string file, Action<LogData, string> output)
		{
			_level = level;
			_file = file;
			_output = output ?? new Action<LogData, string>(defaultOutput);
			_sync = new object();
		}

		private static void defaultOutput(LogData data, string path)
		{
			string value = data.ToString();
			Console.WriteLine(value);
			if (path != null && path.Length > 0)
			{
				writeToFile(value, path);
			}
		}

		private void output(string message, LogLevel level)
		{
			lock (_sync)
			{
				if (_level > level)
				{
					return;
				}
				LogData logData = null;
				try
				{
					logData = new LogData(level, new StackFrame(2, fNeedFileInfo: true), message);
					_output(logData, _file);
				}
				catch (Exception ex)
				{
					logData = new LogData(LogLevel.Fatal, new StackFrame(0, fNeedFileInfo: true), ex.Message);
					Console.WriteLine(logData.ToString());
				}
			}
		}

		private static void writeToFile(string value, string path)
		{
			using StreamWriter writer = new StreamWriter(path, append: true);
			using TextWriter textWriter = TextWriter.Synchronized(writer);
			textWriter.WriteLine(value);
		}

		public void Debug(string message)
		{
			if (_level <= LogLevel.Debug)
			{
				output(message, LogLevel.Debug);
			}
		}

		public void Error(string message)
		{
			if (_level <= LogLevel.Error)
			{
				output(message, LogLevel.Error);
			}
		}

		public void Fatal(string message)
		{
			output(message, LogLevel.Fatal);
		}

		public void Info(string message)
		{
			if (_level <= LogLevel.Info)
			{
				output(message, LogLevel.Info);
			}
		}

		public void Trace(string message)
		{
			if (_level <= LogLevel.Trace)
			{
				output(message, LogLevel.Trace);
			}
		}

		public void Warn(string message)
		{
			if (_level <= LogLevel.Warn)
			{
				output(message, LogLevel.Warn);
			}
		}
	}
	public enum WebSocketState : ushort
	{
		Connecting,
		Open,
		Closing,
		Closed
	}
	internal class WebSocketFrame : IEnumerable<byte>, IEnumerable
	{
		private byte[] _extPayloadLength;

		private Fin _fin;

		private Mask _mask;

		private byte[] _maskingKey;

		private Opcode _opcode;

		private PayloadData _payloadData;

		private byte _payloadLength;

		private Rsv _rsv1;

		private Rsv _rsv2;

		private Rsv _rsv3;

		internal ulong ExactPayloadLength => (_payloadLength < 126) ? _payloadLength : ((_payloadLength == 126) ? _extPayloadLength.ToUInt16(ByteOrder.Big) : _extPayloadLength.ToUInt64(ByteOrder.Big));

		internal int ExtendedPayloadLengthWidth => (_payloadLength >= 126) ? ((_payloadLength == 126) ? 2 : 8) : 0;

		public byte[] ExtendedPayloadLength => _extPayloadLength;

		public Fin Fin => _fin;

		public bool IsBinary => _opcode == Opcode.Binary;

		public bool IsClose => _opcode == Opcode.Close;

		public bool IsCompressed => _rsv1 == Rsv.On;

		public bool IsContinuation => _opcode == Opcode.Cont;

		public bool IsControl => (int)_opcode >= 8;

		public bool IsData => _opcode == Opcode.Text || _opcode == Opcode.Binary;

		public bool IsFinal => _fin == Fin.Final;

		public bool IsFragment => _fin == Fin.More || _opcode == Opcode.Cont;

		public bool IsMasked => _mask == Mask.On;

		public bool IsPing => _opcode == Opcode.Ping;

		public bool IsPong => _opcode == Opcode.Pong;

		public bool IsText => _opcode == Opcode.Text;

		public ulong Length => (ulong)(2L + (long)(_extPayloadLength.Length + _maskingKey.Length)) + _payloadData.Length;

		public Mask Mask => _mask;

		public byte[] MaskingKey => _maskingKey;

		public Opcode Opcode => _opcode;

		public PayloadData PayloadData => _payloadData;

		public byte PayloadLength => _payloadLength;

		public Rsv Rsv1 => _rsv1;

		public Rsv Rsv2 => _rsv2;

		public Rsv Rsv3 => _rsv3;

		private WebSocketFrame()
		{
		}

		internal WebSocketFrame(Opcode opcode, PayloadData payloadData, bool mask)
			: this(Fin.Final, opcode, payloadData, compressed: false, mask)
		{
		}

		internal WebSocketFrame(Fin fin, Opcode opcode, byte[] data, bool compressed, bool mask)
			: this(fin, opcode, new PayloadData(data), compressed, mask)
		{
		}

		internal WebSocketFrame(Fin fin, Opcode opcode, PayloadData payloadData, bool compressed, bool mask)
		{
			_fin = fin;
			_opcode = opcode;
			_rsv1 = ((opcode.IsData() && compressed) ? Rsv.On : Rsv.Off);
			_rsv2 = Rsv.Off;
			_rsv3 = Rsv.Off;
			ulong length = payloadData.Length;
			if (length < 126)
			{
				_payloadLength = (byte)length;
				_extPayloadLength = WebSocket.EmptyBytes;
			}
			else if (length < 65536)
			{
				_payloadLength = 126;
				_extPayloadLength = ((ushort)length).ToByteArray(ByteOrder.Big);
			}
			else
			{
				_payloadLength = 127;
				_extPayloadLength = length.ToByteArray(ByteOrder.Big);
			}
			if (mask)
			{
				_mask = Mask.On;
				_maskingKey = createMaskingKey();
				payloadData.Mask(_maskingKey);
			}
			else
			{
				_mask = Mask.Off;
				_maskingKey = WebSocket.EmptyBytes;
			}
			_payloadData = payloadData;
		}

		private static byte[] createMaskingKey()
		{
			byte[] array = new byte[4];
			WebSocket.RandomNumber.GetBytes(array);
			return array;
		}

		private static string dump(WebSocketFrame frame)
		{
			ulong length = frame.Length;
			long num = (long)(length / 4);
			int num2 = (int)(length % 4);
			int num3;
			string arg;
			if (num < 10000)
			{
				num3 = 4;
				arg = "{0,4}";
			}
			else if (num < 65536)
			{
				num3 = 4;
				arg = "{0,4:X}";
			}
			else if (num < 4294967296L)
			{
				num3 = 8;
				arg = "{0,8:X}";
			}
			else
			{
				num3 = 16;
				arg = "{0,16:X}";
			}
			string arg2 = $"{{0,{num3}}}";
			string format = string.Format("\r\n{0} 01234567 89ABCDEF 01234567 89ABCDEF\r\n{0}+--------+--------+--------+--------+\\n", arg2);
			string lineFmt = $"{arg}|{{1,8}} {{2,8}} {{3,8}} {{4,8}}|\n";
			string format2 = $"{arg2}+--------+--------+--------+--------+";
			StringBuilder buff = new StringBuilder(64);
			Func<Action<string, string, string, string>> func = delegate
			{
				long lineCnt = 0L;
				return delegate(string text, string text2, string text3, string text4)
				{
					buff.AppendFormat(lineFmt, ++lineCnt, text, text2, text3, text4);
				};
			};
			Action<string, string, string, string> action = func();
			byte[] array = frame.ToArray();
			buff.AppendFormat(format, string.Empty);
			for (long num4 = 0L; num4 <= num; num4++)
			{
				long num5 = num4 * 4;
				if (num4 < num)
				{
					action(Convert.ToString(array[num5], 2).PadLeft(8, '0'), Convert.ToString(array[num5 + 1], 2).PadLeft(8, '0'), Convert.ToString(array[num5 + 2], 2).PadLeft(8, '0'), Convert.ToString(array[num5 + 3], 2).PadLeft(8, '0'));
				}
				else if (num2 > 0)
				{
					action(Convert.ToString(array[num5], 2).PadLeft(8, '0'), (num2 >= 2) ? Convert.ToString(array[num5 + 1], 2).PadLeft(8, '0') : string.Empty, (num2 == 3) ? Convert.ToString(array[num5 + 2], 2).PadLeft(8, '0') : string.Empty, string.Empty);
				}
			}
			buff.AppendFormat(format2, string.Empty);
			return buff.ToString();
		}

		private static string print(WebSocketFrame frame)
		{
			byte payloadLength = frame._payloadLength;
			string text = ((payloadLength > 125) ? frame.ExactPayloadLength.ToString() : string.Empty);
			string text2 = BitConverter.ToString(frame._maskingKey);
			string text3 = ((payloadLength == 0) ? string.Empty : ((payloadLength > 125) ? "---" : ((!frame.IsText || frame.IsFragment || frame.IsMasked || frame.IsCompressed) ? frame._payloadData.ToString() : utf8Decode(frame._payloadData.ApplicationData))));
			string format = "\r\n                    FIN: {0}\r\n                   RSV1: {1}\r\n                   RSV2: {2}\r\n                   RSV3: {3}\r\n                 Opcode: {4}\r\n                   MASK: {5}\r\n         Payload Length: {6}\r\nExtended Payload Length: {7}\r\n            Masking Key: {8}\r\n           Payload Data: {9}";
			return string.Format(format, frame._fin, frame._rsv1, frame._rsv2, frame._rsv3, frame._opcode, frame._mask, payloadLength, text, text2, text3);
		}

		private static WebSocketFrame processHeader(byte[] header)
		{
			if (header.Length != 2)
			{
				string message = "The header part of a frame could not be read.";
				throw new WebSocketException(message);
			}
			Fin fin = (((header[0] & 0x80) == 128) ? Fin.Final : Fin.More);
			Rsv rsv = (((header[0] & 0x40) == 64) ? Rsv.On : Rsv.Off);
			Rsv rsv2 = (((header[0] & 0x20) == 32) ? Rsv.On : Rsv.Off);
			Rsv rsv3 = (((header[0] & 0x10) == 16) ? Rsv.On : Rsv.Off);
			byte opcode = (byte)(header[0] & 0xF);
			Mask mask = (((header[1] & 0x80) == 128) ? Mask.On : Mask.Off);
			byte b = (byte)(header[1] & 0x7F);
			if (!opcode.IsSupported())
			{
				string message2 = "A frame has an unsupported opcode.";
				throw new WebSocketException(CloseStatusCode.ProtocolError, message2);
			}
			if (!opcode.IsData() && rsv == Rsv.On)
			{
				string message3 = "A non data frame is compressed.";
				throw new WebSocketException(CloseStatusCode.ProtocolError, message3);
			}
			if (opcode.IsControl())
			{
				if (fin == Fin.More)
				{
					string message4 = "A control frame is fragmented.";
					throw new WebSocketException(CloseStatusCode.ProtocolError, message4);
				}
				if (b > 125)
				{
					string message5 = "A control frame has too long payload length.";
					throw new WebSocketException(CloseStatusCode.ProtocolError, message5);
				}
			}
			WebSocketFrame webSocketFrame = new WebSocketFrame();
			webSocketFrame._fin = fin;
			webSocketFrame._rsv1 = rsv;
			webSocketFrame._rsv2 = rsv2;
			webSocketFrame._rsv3 = rsv3;
			webSocketFrame._opcode = (Opcode)opcode;
			webSocketFrame._mask = mask;
			webSocketFrame._payloadLength = b;
			return webSocketFrame;
		}

		private static WebSocketFrame readExtendedPayloadLength(Stream stream, WebSocketFrame frame)
		{
			int extendedPayloadLengthWidth = frame.ExtendedPayloadLengthWidth;
			if (extendedPayloadLengthWidth == 0)
			{
				frame._extPayloadLength = WebSocket.EmptyBytes;
				return frame;
			}
			byte[] array = stream.ReadBytes(extendedPayloadLengthWidth);
			if (array.Length != extendedPayloadLengthWidth)
			{
				string message = "The extended payload length of a frame could not be read.";
				throw new WebSocketException(message);
			}
			frame._extPayloadLength = array;
			return frame;
		}

		private static void readExtendedPayloadLengthAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error)
		{
			int len = frame.ExtendedPayloadLengthWidth;
			if (len == 0)
			{
				frame._extPayloadLength = WebSocket.EmptyBytes;
				completed(frame);
				return;
			}
			stream.ReadBytesAsync(len, delegate(byte[] bytes)
			{
				if (bytes.Length != len)
				{
					string message = "The extended payload length of a frame could not be read.";
					throw new WebSocketException(message);
				}
				frame._extPayloadLength = bytes;
				completed(frame);
			}, error);
		}

		private static WebSocketFrame readHeader(Stream stream)
		{
			byte[] header = stream.ReadBytes(2);
			return processHeader(header);
		}

		private static void readHeaderAsync(Stream stream, Action<WebSocketFrame> completed, Action<Exception> error)
		{
			stream.ReadBytesAsync(2, delegate(byte[] bytes)
			{
				WebSocketFrame obj = processHeader(bytes);
				completed(obj);
			}, error);
		}

		private static WebSocketFrame readMaskingKey(Stream stream, WebSocketFrame frame)
		{
			if (!frame.IsMasked)
			{
				frame._maskingKey = WebSocket.EmptyBytes;
				return frame;
			}
			int num = 4;
			byte[] array = stream.ReadBytes(num);
			if (array.Length != num)
			{
				string message = "The masking key of a frame could not be read.";
				throw new WebSocketException(message);
			}
			frame._maskingKey = array;
			return frame;
		}

		private static void readMaskingKeyAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error)
		{
			if (!frame.IsMasked)
			{
				frame._maskingKey = WebSocket.EmptyBytes;
				completed(frame);
				return;
			}
			int len = 4;
			stream.ReadBytesAsync(len, delegate(byte[] bytes)
			{
				if (bytes.Length != len)
				{
					string message = "The masking key of a frame could not be read.";
					throw new WebSocketException(message);
				}
				frame._maskingKey = bytes;
				completed(frame);
			}, error);
		}

		private static WebSocketFrame readPayloadData(Stream stream, WebSocketFrame frame)
		{
			ulong exactPayloadLength = frame.ExactPayloadLength;
			if (exactPayloadLength > PayloadData.MaxLength)
			{
				string message = "A frame has too long payload length.";
				throw new WebSocketException(CloseStatusCode.TooBig, message);
			}
			if (exactPayloadLength == 0)
			{
				frame._payloadData = PayloadData.Empty;
				return frame;
			}
			long num = (long)exactPayloadLength;
			byte[] array = ((frame._payloadLength < 127) ? stream.ReadBytes((int)exactPayloadLength) : stream.ReadBytes(num, 1024));
			if (array.LongLength != num)
			{
				string message2 = "The payload data of a frame could not be read.";
				throw new WebSocketException(message2);
			}
			frame._payloadData = new PayloadData(array, num);
			return frame;
		}

		private static void readPayloadDataAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error)
		{
			ulong exactPayloadLength = frame.ExactPayloadLength;
			if (exactPayloadLength > PayloadData.MaxLength)
			{
				string message = "A frame has too long payload length.";
				throw new WebSocketException(CloseStatusCode.TooBig, message);
			}
			if (exactPayloadLength == 0)
			{
				frame._payloadData = PayloadData.Empty;
				completed(frame);
				return;
			}
			long len = (long)exactPayloadLength;
			Action<byte[]> completed2 = delegate(byte[] bytes)
			{
				if (bytes.LongLength != len)
				{
					string message2 = "The payload data of a frame could not be read.";
					throw new WebSocketException(message2);
				}
				frame._payloadData = new PayloadData(bytes, len);
				completed(frame);
			};
			if (frame._payloadLength < 127)
			{
				stream.ReadBytesAsync((int)exactPayloadLength, completed2, error);
			}
			else
			{
				stream.ReadBytesAsync(len, 1024, completed2, error);
			}
		}

		private static string utf8Decode(byte[] bytes)
		{
			try
			{
				return Encoding.UTF8.GetString(bytes);
			}
			catch
			{
				return null;
			}
		}

		internal static WebSocketFrame CreateCloseFrame(PayloadData payloadData, bool mask)
		{
			return new WebSocketFrame(Fin.Final, Opcode.Close, payloadData, compressed: false, mask);
		}

		internal static WebSocketFrame CreatePingFrame(bool mask)
		{
			return new WebSocketFrame(Fin.Final, Opcode.Ping, PayloadData.Empty, compressed: false, mask);
		}

		internal static WebSocketFrame CreatePingFrame(byte[] data, bool mask)
		{
			return new WebSocketFrame(Fin.Final, Opcode.Ping, new PayloadData(data), compressed: false, mask);
		}

		internal static WebSocketFrame CreatePongFrame(PayloadData payloadData, bool mask)
		{
			return new WebSocketFrame(Fin.Final, Opcode.Pong, payloadData, compressed: false, mask);
		}

		internal static WebSocketFrame ReadFrame(Stream stream, bool unmask)
		{
			WebSocketFrame webSocketFrame = readHeader(stream);
			readExtendedPayloadLength(stream, webSocketFrame);
			readMaskingKey(stream, webSocketFrame);
			readPayloadData(stream, webSocketFrame);
			if (unmask)
			{
				webSocketFrame.Unmask();
			}
			return webSocketFrame;
		}

		internal static void ReadFrameAsync(Stream stream, bool unmask, Action<WebSocketFrame> completed, Action<Exception> error)
		{
			readHeaderAsync(stream, delegate(WebSocketFrame frame)
			{
				readExtendedPayloadLengthAsync(stream, frame, delegate(WebSocketFrame frame2)
				{
					readMaskingKeyAsync(stream, frame2, delegate(WebSocketFrame frame3)
					{
						readPayloadDataAsync(stream, frame3, delegate(WebSocketFrame webSocketFrame)
						{
							if (unmask)
							{
								webSocketFrame.Unmask();
							}
							completed(webSocketFrame);
						}, error);
					}, error);
				}, error);
			}, error);
		}

		internal void Unmask()
		{
			if (_mask != Mask.Off)
			{
				_payloadData.Mask(_maskingKey);
				_maskingKey = WebSocket.EmptyBytes;
				_mask = Mask.Off;
			}
		}

		public IEnumerator<byte> GetEnumerator()
		{
			byte[] array = ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				yield return array[i];
			}
		}

		public void Print(bool dumped)
		{
			string value = (dumped ? dump(this) : print(this));
			Console.WriteLine(value);
		}

		public string PrintToString(bool dumped)
		{
			return dumped ? dump(this) : print(this);
		}

		public byte[] ToArray()
		{
			using MemoryStream memoryStream = new MemoryStream();
			int fin = (int)_fin;
			fin = (fin << 1) + (int)_rsv1;
			fin = (fin << 1) + (int)_rsv2;
			fin = (fin << 1) + (int)_rsv3;
			fin = (fin << 4) + (int)_opcode;
			fin = (fin << 1) + (int)_mask;
			fin = (fin << 7) + _payloadLength;
			ushort value = (ushort)fin;
			byte[] buffer = value.ToByteArray(ByteOrder.Big);
			memoryStream.Write(buffer, 0, 2);
			if (_payloadLength > 125)
			{
				int count = ((_payloadLength == 126) ? 2 : 8);
				memoryStream.Write(_extPayloadLength, 0, count);
			}
			if (_mask == Mask.On)
			{
				memoryStream.Write(_maskingKey, 0, 4);
			}
			if (_payloadLength > 0)
			{
				byte[] array = _payloadData.ToArray();
				if (_payloadLength < 127)
				{
					memoryStream.Write(array, 0, array.Length);
				}
				else
				{
					memoryStream.WriteBytes(array, 1024);
				}
			}
			memoryStream.Close();
			return memoryStream.ToArray();
		}

		public override string ToString()
		{
			byte[] array = ToArray();
			return BitConverter.ToString(array);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	internal abstract class HttpBase
	{
		private NameValueCollection _headers;

		private const int _headersMaxLength = 8192;

		private Version _version;

		internal byte[] EntityBodyData;

		protected const string CrLf = "\r\n";

		public string EntityBody
		{
			get
			{
				if (EntityBodyData == null || EntityBodyData.LongLength == 0)
				{
					return string.Empty;
				}
				Encoding encoding = null;
				string text = _headers["Content-Type"];
				if (text != null && text.Length > 0)
				{
					encoding = HttpUtility.GetEncoding(text);
				}
				return (encoding ?? Encoding.UTF8).GetString(EntityBodyData);
			}
		}

		public NameValueCollection Headers => _headers;

		public Version ProtocolVersion => _version;

		protected HttpBase(Version version, NameValueCollection headers)
		{
			_version = version;
			_headers = headers;
		}

		private static byte[] readEntityBody(Stream stream, string length)
		{
			if (!long.TryParse(length, out var result))
			{
				throw new ArgumentException("Cannot be parsed.", "length");
			}
			if (result < 0)
			{
				throw new ArgumentOutOfRangeException("length", "Less than zero.");
			}
			return (result > 1024) ? stream.ReadBytes(result, 1024) : ((result > 0) ? stream.ReadBytes((int)result) : null);
		}

		private static string[] readHeaders(Stream stream, int maxLength)
		{
			List<byte> buff = new List<byte>();
			int cnt = 0;
			Action<int> beforeComparing = delegate(int i)
			{
				if (i == -1)
				{
					throw new EndOfStreamException("The header cannot be read from the data source.");
				}
				buff.Add((byte)i);
				cnt++;
			};
			bool flag = false;
			while (cnt < maxLength)
			{
				if (stream.ReadByte().IsEqualTo('\r', beforeComparing) && stream.ReadByte().IsEqualTo('\n', beforeComparing) && stream.ReadByte().IsEqualTo('\r', beforeComparing) && stream.ReadByte().IsEqualTo('\n', beforeComparing))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				throw new WebSocketException("The length of header part is greater than the max length.");
			}
			return Encoding.UTF8.GetString(buff.ToArray()).Replace("\r\n ", " ").Replace("\r\n\t", " ")
				.Split(new string[1] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
		}

		protected static T Read<T>(Stream stream, Func<string[], T> parser, int millisecondsTimeout) where T : HttpBase
		{
			bool timeout = false;
			System.Threading.Timer timer = new System.Threading.Timer(delegate
			{
				timeout = true;
				stream.Close();
			}, null, millisecondsTimeout, -1);
			T val = null;
			Exception ex = null;
			try
			{
				val = parser(readHeaders(stream, 8192));
				string text = val.Headers["Content-Length"];
				if (text != null && text.Length > 0)
				{
					val.EntityBodyData = readEntityBody(stream, text);
				}
			}
			catch (Exception ex2)
			{
				ex = ex2;
			}
			finally
			{
				timer.Change(-1, -1);
				timer.Dispose();
			}
			string text2 = (timeout ? "A timeout has occurred while reading an HTTP request/response." : ((ex != null) ? "An exception has occurred while reading an HTTP request/response." : null));
			if (text2 != null)
			{
				throw new WebSocketException(text2, ex);
			}
			return val;
		}

		public byte[] ToByteArray()
		{
			return Encoding.UTF8.GetBytes(ToString());
		}
	}
	internal class HttpRequest : HttpBase
	{
		private WebSocketSharp.Net.CookieCollection _cookies;

		private string _method;

		private string _uri;

		public AuthenticationResponse AuthenticationResponse
		{
			get
			{
				string text = base.Headers["Authorization"];
				return (text != null && text.Length > 0) ? AuthenticationResponse.Parse(text) : null;
			}
		}

		public WebSocketSharp.Net.CookieCollection Cookies
		{
			get
			{
				if (_cookies == null)
				{
					_cookies = base.Headers.GetCookies(response: false);
				}
				return _cookies;
			}
		}

		public string HttpMethod => _method;

		public bool IsWebSocketRequest => _method == "GET" && base.ProtocolVersion > WebSocketSharp.Net.HttpVersion.Version10 && base.Headers.Upgrades("websocket");

		public string RequestUri => _uri;

		private HttpRequest(string method, string uri, Version version, NameValueCollection headers)
			: base(version, headers)
		{
			_method = method;
			_uri = uri;
		}

		internal HttpRequest(string method, string uri)
			: this(method, uri, WebSocketSharp.Net.HttpVersion.Version11, new NameValueCollection())
		{
			base.Headers["User-Agent"] = "websocket-sharp/1.0";
		}

		internal static HttpRequest CreateConnectRequest(Uri uri)
		{
			string dnsSafeHost = uri.DnsSafeHost;
			int port = uri.Port;
			string text = $"{dnsSafeHost}:{port}";
			HttpRequest httpRequest = new HttpRequest("CONNECT", text);
			httpRequest.Headers["Host"] = ((port == 80) ? dnsSafeHost : text);
			return httpRequest;
		}

		internal static HttpRequest CreateWebSocketRequest(Uri uri)
		{
			HttpRequest httpRequest = new HttpRequest("GET", uri.PathAndQuery);
			NameValueCollection headers = httpRequest.Headers;
			int port = uri.Port;
			string scheme = uri.Scheme;
			headers["Host"] = (((port == 80 && scheme == "ws") || (port == 443 && scheme == "wss")) ? uri.DnsSafeHost : uri.Authority);
			headers["Upgrade"] = "websocket";
			headers["Connection"] = "Upgrade";
			return httpRequest;
		}

		internal HttpResponse GetResponse(Stream stream, int millisecondsTimeout)
		{
			byte[] array = ToByteArray();
			stream.Write(array, 0, array.Length);
			return HttpBase.Read(stream, HttpResponse.Parse, millisecondsTimeout);
		}

		internal static HttpRequest Parse(string[] headerParts)
		{
			string[] array = headerParts[0].Split(new char[1] { ' ' }, 3);
			if (array.Length != 3)
			{
				throw new ArgumentException("Invalid request line: " + headerParts[0]);
			}
			WebSocketSharp.Net.WebHeaderCollection webHeaderCollection = new WebSocketSharp.Net.WebHeaderCollection();
			for (int i = 1; i < headerParts.Length; i++)
			{
				webHeaderCollection.InternalSet(headerParts[i], response: false);
			}
			return new HttpRequest(array[0], array[1], new Version(array[2].Substring(5)), webHeaderCollection);
		}

		internal static HttpRequest Read(Stream stream, int millisecondsTimeout)
		{
			return HttpBase.Read(stream, Parse, millisecondsTimeout);
		}

		public void SetCookies(WebSocketSharp.Net.CookieCollection cookies)
		{
			if (cookies == null || cookies.Count == 0)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder(64);
			foreach (WebSocketSharp.Net.Cookie item in cookies.Sorted)
			{
				if (!item.Expired)
				{
					stringBuilder.AppendFormat("{0}; ", item.ToString());
				}
			}
			int length = stringBuilder.Length;
			if (length > 2)
			{
				stringBuilder.Length = length - 2;
				base.Headers["Cookie"] = stringBuilder.ToString();
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.AppendFormat("{0} {1} HTTP/{2}{3}", _method, _uri, base.ProtocolVersion, "\r\n");
			NameValueCollection headers = base.Headers;
			string[] allKeys = headers.AllKeys;
			foreach (string text in allKeys)
			{
				stringBuilder.AppendFormat("{0}: {1}{2}", text, headers[text], "\r\n");
			}
			stringBuilder.Append("\r\n");
			string entityBody = base.EntityBody;
			if (entityBody.Length > 0)
			{
				stringBuilder.Append(entityBody);
			}
			return stringBuilder.ToString();
		}
	}
	internal class HttpResponse : HttpBase
	{
		private string _code;

		private string _reason;

		public WebSocketSharp.Net.CookieCollection Cookies => base.Headers.GetCookies(response: true);

		public bool HasConnectionClose
		{
			get
			{
				StringComparison comparisonTypeForValue = StringComparison.OrdinalIgnoreCase;
				return base.Headers.Contains("Connection", "close", comparisonTypeForValue);
			}
		}

		public bool IsProxyAuthenticationRequired => _code == "407";

		public bool IsRedirect => _code == "301" || _code == "302";

		public bool IsUnauthorized => _code == "401";

		public bool IsWebSocketResponse => base.ProtocolVersion > WebSocketSharp.Net.HttpVersion.Version10 && _code == "101" && base.Headers.Upgrades("websocket");

		public string Reason => _reason;

		public string StatusCode => _code;

		private HttpResponse(string code, string reason, Version version, NameValueCollection headers)
			: base(version, headers)
		{
			_code = code;
			_reason = reason;
		}

		internal HttpResponse(WebSocketSharp.Net.HttpStatusCode code)
			: this(code, code.GetDescription())
		{
		}

		internal HttpResponse(WebSocketSharp.Net.HttpStatusCode code, string reason)
			: this(((int)code).ToString(), reason, WebSocketSharp.Net.HttpVersion.Version11, new NameValueCollection())
		{
			base.Headers["Server"] = "websocket-sharp/1.0";
		}

		internal static HttpResponse CreateCloseResponse(WebSocketSharp.Net.HttpStatusCode code)
		{
			HttpResponse httpResponse = new HttpResponse(code);
			httpResponse.Headers["Connection"] = "close";
			return httpResponse;
		}

		internal static HttpResponse CreateUnauthorizedResponse(string challenge)
		{
			HttpResponse httpResponse = new HttpResponse(WebSocketSharp.Net.HttpStatusCode.Unauthorized);
			httpResponse.Headers["WWW-Authenticate"] = challenge;
			return httpResponse;
		}

		internal static HttpResponse CreateWebSocketResponse()
		{
			HttpResponse httpResponse = new HttpResponse(WebSocketSharp.Net.HttpStatusCode.SwitchingProtocols);
			NameValueCollection headers = httpResponse.Headers;
			headers["Upgrade"] = "websocket";
			headers["Connection"] = "Upgrade";
			return httpResponse;
		}

		internal static HttpResponse Parse(string[] headerParts)
		{
			string[] array = headerParts[0].Split(new char[1] { ' ' }, 3);
			if (array.Length != 3)
			{
				throw new ArgumentException("Invalid status line: " + headerParts[0]);
			}
			WebSocketSharp.Net.WebHeaderCollection webHeaderCollection = new WebSocketSharp.Net.WebHeaderCollection();
			for (int i = 1; i < headerParts.Length; i++)
			{
				webHeaderCollection.InternalSet(headerParts[i], response: true);
			}
			return new HttpResponse(array[1], array[2], new Version(array[0].Substring(5)), webHeaderCollection);
		}

		internal static HttpResponse Read(Stream stream, int millisecondsTimeout)
		{
			return HttpBase.Read(stream, Parse, millisecondsTimeout);
		}

		public void SetCookies(WebSocketSharp.Net.CookieCollection cookies)
		{
			if (cookies == null || cookies.Count == 0)
			{
				return;
			}
			NameValueCollection headers = base.Headers;
			foreach (WebSocketSharp.Net.Cookie item in cookies.Sorted)
			{
				headers.Add("Set-Cookie", item.ToResponseString());
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.AppendFormat("HTTP/{0} {1} {2}{3}", base.ProtocolVersion, _code, _reason, "\r\n");
			NameValueCollection headers = base.Headers;
			string[] allKeys = headers.AllKeys;
			foreach (string text in allKeys)
			{
				stringBuilder.AppendFormat("{0}: {1}{2}", text, headers[text], "\r\n");
			}
			stringBuilder.Append("\r\n");
			string entityBody = base.EntityBody;
			if (entityBody.Length > 0)
			{
				stringBuilder.Append(entityBody);
			}
			return stringBuilder.ToString();
		}
	}
}
namespace WebSocketSharp.Net
{
	public enum AuthenticationSchemes
	{
		None = 0,
		Digest = 1,
		Basic = 8,
		Anonymous = 0x8000
	}
	internal class ChunkStream
	{
		private int _chunkRead;

		private int _chunkSize;

		private List<Chunk> _chunks;

		private int _count;

		private byte[] _endBuffer;

		private bool _gotIt;

		private WebHeaderCollection _headers;

		private int _offset;

		private StringBuilder _saved;

		private bool _sawCr;

		private InputChunkState _state;

		private int _trailerState;

		internal int Count => _count;

		internal byte[] EndBuffer => _endBuffer;

		internal int Offset => _offset;

		public WebHeaderCollection Headers => _headers;

		public bool WantsMore => _state < InputChunkState.End;

		public ChunkStream(WebHeaderCollection headers)
		{
			_headers = headers;
			_chunkSize = -1;
			_chunks = new List<Chunk>();
			_saved = new StringBuilder();
		}

		private int read(byte[] buffer, int offset, int count)
		{
			int num = 0;
			int count2 = _chunks.Count;
			for (int i = 0; i < count2; i++)
			{
				Chunk chunk = _chunks[i];
				if (chunk == null)
				{
					continue;
				}
				if (chunk.ReadLeft == 0)
				{
					_chunks[i] = null;
					continue;
				}
				num += chunk.Read(buffer, offset + num, count - num);
				if (num == count)
				{
					break;
				}
			}
			return num;
		}

		private InputChunkState seekCrLf(byte[] buffer, ref int offset, int length)
		{
			if (!_sawCr)
			{
				if (buffer[offset++] != 13)
				{
					throwProtocolViolation("CR is expected.");
				}
				_sawCr = true;
				if (offset == length)
				{
					return InputChunkState.DataEnded;
				}
			}
			if (buffer[offset++] != 10)
			{
				throwProtocolViolation("LF is expected.");
			}
			return InputChunkState.None;
		}

		private InputChunkState setChunkSize(byte[] buffer, ref int offset, int length)
		{
			byte b = 0;
			while (offset < length)
			{
				b = buffer[offset++];
				if (_sawCr)
				{
					if (b != 10)
					{
						throwProtocolViolation("LF is expected.");
					}
					break;
				}
				switch (b)
				{
				case 13:
					_sawCr = true;
					continue;
				case 10:
					throwProtocolViolation("LF is unexpected.");
					break;
				}
				if (!_gotIt)
				{
					if (b == 32 || b == 59)
					{
						_gotIt = true;
					}
					else
					{
						_saved.Append((char)b);
					}
				}
			}
			if (_saved.Length > 20)
			{
				throwProtocolViolation("The chunk size is too big.");
			}
			if (b != 10)
			{
				return InputChunkState.None;
			}
			string s = _saved.ToString();
			try
			{
				_chunkSize = int.Parse(s, NumberStyles.HexNumber);
			}
			catch
			{
				throwProtocolViolation("The chunk size cannot be parsed.");
			}
			_chunkRead = 0;
			if (_chunkSize == 0)
			{
				_trailerState = 2;
				return InputChunkState.Trailer;
			}
			return InputChunkState.Data;
		}

		private InputChunkState setTrailer(byte[] buffer, ref int offset, int length)
		{
			while (offset < length && _trailerState != 4)
			{
				byte b = buffer[offset++];
				_saved.Append((char)b);
				if (_trailerState == 1 || _trailerState == 3)
				{
					if (b != 10)
					{
						throwProtocolViolation("LF is expected.");
					}
					_trailerState++;
					continue;
				}
				switch (b)
				{
				case 13:
					_trailerState++;
					continue;
				case 10:
					throwProtocolViolation("LF is unexpected.");
					break;
				}
				_trailerState = 0;
			}
			int length2 = _saved.Length;
			if (length2 > 4196)
			{
				throwProtocolViolation("The trailer is too long.");
			}
			if (_trailerState < 4)
			{
				return InputChunkState.Trailer;
			}
			if (length2 == 2)
			{
				return InputChunkState.End;
			}
			_saved.Length = length2 - 2;
			string s = _saved.ToString();
			StringReader stringReader = new StringReader(s);
			while (true)
			{
				string text = stringReader.ReadLine();
				if (text == null || text.Length == 0)
				{
					break;
				}
				_headers.Add(text);
			}
			return InputChunkState.End;
		}

		private static void throwProtocolViolation(string message)
		{
			throw new WebException(message, null, WebExceptionStatus.ServerProtocolViolation, null);
		}

		private void write(byte[] buffer, int offset, int length)
		{
			if (_state == InputChunkState.End)
			{
				throwProtocolViolation("The chunks were ended.");
			}
			if (_state == InputChunkState.None)
			{
				_state = setChunkSize(buffer, ref offset, length);
				if (_state == InputChunkState.None)
				{
					return;
				}
				_saved.Length = 0;
				_sawCr = false;
				_gotIt = false;
			}
			if (_state == InputChunkState.Data)
			{
				if (offset >= length)
				{
					return;
				}
				_state = writeData(buffer, ref offset, length);
				if (_state == InputChunkState.Data)
				{
					return;
				}
			}
			if (_state == InputChunkState.DataEnded)
			{
				if (offset >= length)
				{
					return;
				}
				_state = seekCrLf(buffer, ref offset, length);
				if (_state == InputChunkState.DataEnded)
				{
					return;
				}
				_sawCr = false;
			}
			if (_state == InputChunkState.Trailer)
			{
				if (offset >= length)
				{
					return;
				}
				_state = setTrailer(buffer, ref offset, length);
				if (_state == InputChunkState.Trailer)
				{
					return;
				}
				_saved.Length = 0;
			}
			if (_state == InputChunkState.End)
			{
				_endBuffer = buffer;
				_offset = offset;
				_count = length - offset;
			}
			else if (offset < length)
			{
				write(buffer, offset, length);
			}
		}

		private InputChunkState writeData(byte[] buffer, ref int offset, int length)
		{
			int num = length - offset;
			int num2 = _chunkSize - _chunkRead;
			if (num > num2)
			{
				num = num2;
			}
			byte[] array = new byte[num];
			Buffer.BlockCopy(buffer, offset, array, 0, num);
			Chunk item = new Chunk(array);
			_chunks.Add(item);
			offset += num;
			_chunkRead += num;
			return (_chunkRead != _chunkSize) ? InputChunkState.Data : InputChunkState.DataEnded;
		}

		internal void ResetChunkStore()
		{
			_chunkRead = 0;
			_chunkSize = -1;
			_chunks.Clear();
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			if (count <= 0)
			{
				return 0;
			}
			return read(buffer, offset, count);
		}

		public void Write(byte[] buffer, int offset, int count)
		{
			if (count > 0)
			{
				write(buffer, offset, offset + count);
			}
		}
	}
	[Serializable]
	public sealed class Cookie
	{
		private string _comment;

		private Uri _commentUri;

		private bool _discard;

		private string _domain;

		private static readonly int[] _emptyPorts;

		private DateTime _expires;

		private bool _httpOnly;

		private string _name;

		private string _path;

		private string _port;

		private int[] _ports;

		private static readonly char[] _reservedCharsForValue;

		private string _sameSite;

		private bool _secure;

		private DateTime _timeStamp;

		private string _value;

		private int _version;

		internal bool ExactDomain => _domain.Length == 0 || _domain[0] != '.';

		internal int MaxAge
		{
			get
			{
				if (_expires == DateTime.MinValue)
				{
					return 0;
				}
				DateTime dateTime = ((_expires.Kind != DateTimeKind.Local) ? _expires.ToLocalTime() : _expires);
				TimeSpan timeSpan = dateTime - DateTime.Now;
				return (timeSpan > TimeSpan.Zero) ? ((int)timeSpan.TotalSeconds) : 0;
			}
			set
			{
				_expires = ((value > 0) ? DateTime.Now.AddSeconds(value) : DateTime.Now);
			}
		}

		internal int[] Ports => _ports ?? _emptyPorts;

		internal string SameSite
		{
			get
			{
				return _sameSite;
			}
			set
			{
				_sameSite = value;
			}
		}

		public string Comment
		{
			get
			{
				return _comment;
			}
			internal set
			{
				_comment = value;
			}
		}

		public Uri CommentUri
		{
			get
			{
				return _commentUri;
			}
			internal set
			{
				_commentUri = value;
			}
		}

		public bool Discard
		{
			get
			{
				return _discard;
			}
			internal set
			{
				_discard = value;
			}
		}

		public string Domain
		{
			get
			{
				return _domain;
			}
			set
			{
				_domain = value ?? string.Empty;
			}
		}

		public bool Expired
		{
			get
			{
				return _expires != DateTime.MinValue && _expires <= DateTime.Now;
			}
			set
			{
				_expires = (value ? DateTime.Now : DateTime.MinValue);
			}
		}

		public DateTime Expires
		{
			get
			{
				return _expires;
			}
			set
			{
				_expires = value;
			}
		}

		public bool HttpOnly
		{
			get
			{
				return _httpOnly;
			}
			set
			{
				_httpOnly = value;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length == 0)
				{
					throw new ArgumentException("An empty string.", "value");
				}
				if (value[0] == '$')
				{
					string message = "It starts with a dollar sign.";
					throw new ArgumentException(message, "value");
				}
				if (!value.IsToken())
				{
					string message2 = "It contains an invalid character.";
					throw new ArgumentException(message2, "value");
				}
				_name = value;
			}
		}

		public string Path
		{
			get
			{
				return _path;
			}
			set
			{
				_path = value ?? string.Empty;
			}
		}

		public string Port
		{
			get
			{
				return _port;
			}
			internal set
			{
				if (tryCreatePorts(value, out var result))
				{
					_port = value;
					_ports = result;
				}
			}
		}

		public bool Secure
		{
			get
			{
				return _secure;
			}
			set
			{
				_secure = value;
			}
		}

		public DateTime TimeStamp => _timeStamp;

		public string Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				if (value.Contains(_reservedCharsForValue) && !value.IsEnclosedIn('"'))
				{
					string message = "A string not enclosed in double quotes.";
					throw new ArgumentException(message, "value");
				}
				_value = value;
			}
		}

		public int Version
		{
			get
			{
				return _version;
			}
			internal set
			{
				if (value >= 0 && value <= 1)
				{
					_version = value;
				}
			}
		}

		static Cookie()
		{
			_emptyPorts = new int[0];
			_reservedCharsForValue = new char[2] { ';', ',' };
		}

		internal Cookie()
		{
			init(string.Empty, string.Empty, string.Empty, string.Empty);
		}

		public Cookie(string name, string value)
			: this(name, value, string.Empty, string.Empty)
		{
		}

		public Cookie(string name, string value, string path)
			: this(name, value, path, string.Empty)
		{
		}

		public Cookie(string name, string value, string path, string domain)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException("An empty string.", "name");
			}
			if (name[0] == '$')
			{
				string message = "It starts with a dollar sign.";
				throw new ArgumentException(message, "name");
			}
			if (!name.IsToken())
			{
				string message2 = "It contains an invalid character.";
				throw new ArgumentException(message2, "name");
			}
			if (value == null)
			{
				value = string.Empty;
			}
			if (value.Contains(_reservedCharsForValue) && !value.IsEnclosedIn('"'))
			{
				string message3 = "A string not enclosed in double quotes.";
				throw new ArgumentException(message3, "value");
			}
			init(name, value, path ?? string.Empty, domain ?? string.Empty);
		}

		private static int hash(int i, int j, int k, int l, int m)
		{
			return i ^ ((j << 13) | (j >> 19)) ^ ((k << 26) | (k >> 6)) ^ ((l << 7) | (l >> 25)) ^ ((m << 20) | (m >> 12));
		}

		private void init(string name, string value, string path, string domain)
		{
			_name = name;
			_value = value;
			_path = path;
			_domain = domain;
			_expires = DateTime.MinValue;
			_timeStamp = DateTime.Now;
		}

		private string toResponseStringVersion0()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.AppendFormat("{0}={1}", _name, _value);
			if (_expires != DateTime.MinValue)
			{
				stringBuilder.AppendFormat("; Expires={0}", _expires.ToUniversalTime().ToString("ddd, dd'-'MMM'-'yyyy HH':'mm':'ss 'GMT'", CultureInfo.CreateSpecificCulture("en-US")));
			}
			if (!_path.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("; Path={0}", _path);
			}
			if (!_domain.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("; Domain={0}", _domain);
			}
			if (!_sameSite.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("; SameSite={0}", _sameSite);
			}
			if (_secure)
			{
				stringBuilder.Append("; Secure");
			}
			if (_httpOnly)
			{
				stringBuilder.Append("; HttpOnly");
			}
			return stringBuilder.ToString();
		}

		private string toResponseStringVersion1()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.AppendFormat("{0}={1}; Version={2}", _name, _value, _version);
			if (_expires != DateTime.MinValue)
			{
				stringBuilder.AppendFormat("; Max-Age={0}", MaxAge);
			}
			if (!_path.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("; Path={0}", _path);
			}
			if (!_domain.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("; Domain={0}", _domain);
			}
			if (_port != null)
			{
				if (_port != "\"\"")
				{
					stringBuilder.AppendFormat("; Port={0}", _port);
				}
				else
				{
					stringBuilder.Append("; Port");
				}
			}
			if (_comment != null)
			{
				stringBuilder.AppendFormat("; Comment={0}", HttpUtility.UrlEncode(_comment));
			}
			if (_commentUri != null)
			{
				string originalString = _commentUri.OriginalString;
				stringBuilder.AppendFormat("; CommentURL={0}", (!originalString.IsToken()) ? originalString.Quote() : originalString);
			}
			if (_discard)
			{
				stringBuilder.Append("; Discard");
			}
			if (_secure)
			{
				stringBuilder.Append("; Secure");
			}
			return stringBuilder.ToString();
		}

		private static bool tryCreatePorts(string value, out int[] result)
		{
			result = null;
			string[] array = value.Trim(new char[1] { '"' }).Split(new char[1] { ',' });
			int num = array.Length;
			int[] array2 = new int[num];
			for (int i = 0; i < num; i++)
			{
				string text = array[i].Trim();
				if (text.Length == 0)
				{
					array2[i] = int.MinValue;
				}
				else if (!int.TryParse(text, out array2[i]))
				{
					return false;
				}
			}
			result = array2;
			return true;
		}

		internal bool EqualsWithoutValue(Cookie cookie)
		{
			StringComparison comparisonType = StringComparison.InvariantCulture;
			StringComparison comparisonType2 = StringComparison.InvariantCultureIgnoreCase;
			return _name.Equals(cookie._name, comparisonType2) && _path.Equals(cookie._path, comparisonType) && _domain.Equals(cookie._domain, comparisonType2) && _version == cookie._version;
		}

		internal bool EqualsWithoutValueAndVersion(Cookie cookie)
		{
			StringComparison comparisonType = StringComparison.InvariantCulture;
			StringComparison comparisonType2 = StringComparison.InvariantCultureIgnoreCase;
			return _name.Equals(cookie._name, comparisonType2) && _path.Equals(cookie._path, comparisonType) && _domain.Equals(cookie._domain, comparisonType2);
		}

		internal string ToRequestString(Uri uri)
		{
			if (_name.Length == 0)
			{
				return string.Empty;
			}
			if (_version == 0)
			{
				return $"{_name}={_value}";
			}
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.AppendFormat("$Version={0}; {1}={2}", _version, _name, _value);
			if (!_path.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("; $Path={0}", _path);
			}
			else if (uri != null)
			{
				stringBuilder.AppendFormat("; $Path={0}", uri.GetAbsolutePath());
			}
			else
			{
				stringBuilder.Append("; $Path=/");
			}
			if (!_domain.IsNullOrEmpty() && (uri == null || uri.Host != _domain))
			{
				stringBuilder.AppendFormat("; $Domain={0}", _domain);
			}
			if (_port != null)
			{
				if (_port != "\"\"")
				{
					stringBuilder.AppendFormat("; $Port={0}", _port);
				}
				else
				{
					stringBuilder.Append("; $Port");
				}
			}
			return stringBuilder.ToString();
		}

		internal string ToResponseString()
		{
			return (_name.Length == 0) ? string.Empty : ((_version == 0) ? toResponseStringVersion0() : toResponseStringVersion1());
		}

		internal static bool TryCreate(string name, string value, out Cookie result)
		{
			result = null;
			try
			{
				result = new Cookie(name, value);
			}
			catch
			{
				return false;
			}
			return true;
		}

		public override bool Equals(object comparand)
		{
			if (!(comparand is Cookie cookie))
			{
				return false;
			}
			StringComparison comparisonType = StringComparison.InvariantCulture;
			StringComparison comparisonType2 = StringComparison.InvariantCultureIgnoreCase;
			return _name.Equals(cookie._name, comparisonType2) && _value.Equals(cookie._value, comparisonType) && _path.Equals(cookie._path, comparisonType) && _domain.Equals(cookie._domain, comparisonType2) && _version == cookie._version;
		}

		public override int GetHashCode()
		{
			return hash(StringComparer.InvariantCultureIgnoreCase.GetHashCode(_name), _value.GetHashCode(), _path.GetHashCode(), StringComparer.InvariantCultureIgnoreCase.GetHashCode(_domain), _version);
		}

		public override string ToString()
		{
			return ToRequestString(null);
		}
	}
	[Serializable]
	public class CookieCollection : ICollection<Cookie>, IEnumerable<Cookie>, IEnumerable
	{
		private List<Cookie> _list;

		private bool _readOnly;

		private object _sync;

		internal IList<Cookie> List => _list;

		internal IEnumerable<Cookie> Sorted
		{
			get
			{
				List<Cookie> list = new List<Cookie>(_list);
				if (list.Count > 1)
				{
					list.Sort(compareForSorted);
				}
				return list;
			}
		}

		public int Count => _list.Count;

		public bool IsReadOnly
		{
			get
			{
				return _readOnly;
			}
			internal set
			{
				_readOnly = value;
			}
		}

		public bool IsSynchronized => false;

		public Cookie this[int index]
		{
			get
			{
				if (index < 0 || index >= _list.Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return _list[index];
			}
		}

		public Cookie this[string name]
		{
			get
			{
				if (name == null)
				{
					throw new ArgumentNullException("name");
				}
				StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase;
				foreach (Cookie item in Sorted)
				{
					if (item.Name.Equals(name, comparisonType))
					{
						return item;
					}
				}
				return null;
			}
		}

		public object SyncRoot => _sync;

		public CookieCollection()
		{
			_list = new List<Cookie>();
			_sync = ((ICollection)_list).SyncRoot;
		}

		private void add(Cookie cookie)
		{
			int num = search(cookie);
			if (num == -1)
			{
				_list.Add(cookie);
			}
			else
			{
				_list[num] = cookie;
			}
		}

		private static int compareForSort(Cookie x, Cookie y)
		{
			return x.Name.Length + x.Value.Length - (y.Name.Length + y.Value.Length);
		}

		private static int compareForSorted(Cookie x, Cookie y)
		{
			int num = x.Version - y.Version;
			return (num != 0) ? num : (((num = x.Name.CompareTo(y.Name)) != 0) ? num : (y.Path.Length - x.Path.Length));
		}

		private static CookieCollection parseRequest(string value)
		{
			CookieCollection cookieCollection = new CookieCollection();
			Cookie result = null;
			int num = 0;
			StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase;
			List<string> list = value.SplitHeaderValue(',', ';').ToList();
			for (int i = 0; i < list.Count; i++)
			{
				string text = list[i].Trim();
				if (text.Length == 0)
				{
					continue;
				}
				int num2 = text.IndexOf('=');
				switch (num2)
				{
				case -1:
					if (result != null && text.Equals("$port", comparisonType))
					{
						result.Port = "\"\"";
					}
					continue;
				case 0:
					if (result != null)
					{
						cookieCollection.add(result);
						result = null;
					}
					continue;
				}
				string text2 = text.Substring(0, num2).TrimEnd(new char[1] { ' ' });
				string text3 = ((num2 < text.Length - 1) ? text.Substring(num2 + 1).TrimStart(new char[1] { ' ' }) : string.Empty);
				if (text2.Equals("$version", comparisonType))
				{
					if (text3.Length != 0 && int.TryParse(text3.Unquote(), out var result2))
					{
						num = result2;
					}
					continue;
				}
				if (text2.Equals("$path", comparisonType))
				{
					if (result != null && text3.Length != 0)
					{
						result.Path = text3;
					}
					continue;
				}
				if (text2.Equals("$domain", comparisonType))
				{
					if (result != null && text3.Length != 0)
					{
						result.Domain = text3;
					}
					continue;
				}
				if (text2.Equals("$port", comparisonType))
				{
					if (result != null && text3.Length != 0)
					{
						result.Port = text3;
					}
					continue;
				}
				if (result != null)
				{
					cookieCollection.add(result);
				}
				if (Cookie.TryCreate(text2, text3, out result) && num != 0)
				{
					result.Version = num;
				}
			}
			if (result != null)
			{
				cookieCollection.add(result);
			}
			return cookieCollection;
		}

		private static CookieCollection parseResponse(string value)
		{
			CookieCollection cookieCollection = new CookieCollection();
			Cookie result = null;
			StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase;
			List<string> list = value.SplitHeaderValue(',', ';').ToList();
			for (int i = 0; i < list.Count; i++)
			{
				string text = list[i].Trim();
				if (text.Length == 0)
				{
					continue;
				}
				int num = text.IndexOf('=');
				switch (num)
				{
				case -1:
					if (result != null)
					{
						if (text.Equals("port", comparisonType))
						{
							result.Port = "\"\"";
						}
						else if (text.Equals("discard", comparisonType))
						{
							result.Discard = true;
						}
						else if (text.Equals("secure", comparisonType))
						{
							result.Secure = true;
						}
						else if (text.Equals("httponly", comparisonType))
						{
							result.HttpOnly = true;
						}
					}
					continue;
				case 0:
					if (result != null)
					{
						cookieCollection.add(result);
						result = null;
					}
					continue;
				}
				string text2 = text.Substring(0, num).TrimEnd(new char[1] { ' ' });
				string text3 = ((num < text.Length - 1) ? text.Substring(num + 1).TrimStart(new char[1] { ' ' }) : string.Empty);
				if (text2.Equals("version", comparisonType))
				{
					if (result != null && text3.Length != 0 && int.TryParse(text3.Unquote(), out var result2))
					{
						result.Version = result2;
					}
				}
				else if (text2.Equals("expires", comparisonType))
				{
					if (text3.Length == 0)
					{
						continue;
					}
					if (i == list.Count - 1)
					{
						break;
					}
					i++;
					if (result != null && !(result.Expires != DateTime.MinValue))
					{
						StringBuilder stringBuilder = new StringBuilder(text3, 32);
						stringBuilder.AppendFormat(", {0}", list[i].Trim());
						if (DateTime.TryParseExact(stringBuilder.ToString(), new string[2] { "ddd, dd'-'MMM'-'yyyy HH':'mm':'ss 'GMT'", "r" }, CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out var result3))
						{
							result.Expires = result3.ToLocalTime();
						}
					}
				}
				else if (text2.Equals("max-age", comparisonType))
				{
					if (result != null && text3.Length != 0 && int.TryParse(text3.Unquote(), out var result4))
					{
						result.MaxAge = result4;
					}
				}
				else if (text2.Equals("path", comparisonType))
				{
					if (result != null && text3.Length != 0)
					{
						result.Path = text3;
					}
				}
				else if (text2.Equals("domain", comparisonType))
				{
					if (result != null && text3.Length != 0)
					{
						result.Domain = text3;
					}
				}
				else if (text2.Equals("port", comparisonType))
				{
					if (result != null && text3.Length != 0)
					{
						result.Port = text3;
					}
				}
				else if (text2.Equals("comment", comparisonType))
				{
					if (result != null && text3.Length != 0)
					{
						result.Comment = urlDecode(text3, Encoding.UTF8);
					}
				}
				else if (text2.Equals("commenturl", comparisonType))
				{
					if (result != null && text3.Length != 0)
					{
						result.CommentUri = text3.Unquote().ToUri();
					}
				}
				else if (text2.Equals("samesite", comparisonType))
				{
					if (result != null && text3.Length != 0)
					{
						result.SameSite = text3.Unquote();
					}
				}
				else
				{
					if (result != null)
					{
						cookieCollection.add(result);
					}
					Cookie.TryCreate(text2, text3, out result);
				}
			}
			if (result != null)
			{
				cookieCollection.add(result);
			}
			return cookieCollection;
		}

		private int search(Cookie cookie)
		{
			for (int num = _list.Count - 1; num >= 0; num--)
			{
				if (_list[num].EqualsWithoutValue(cookie))
				{
					return num;
				}
			}
			return -1;
		}

		private static string urlDecode(string s, Encoding encoding)
		{
			if (s.IndexOfAny(new char[2] { '%', '+' }) == -1)
			{
				return s;
			}
			try
			{
				return HttpUtility.UrlDecode(s, encoding);
			}
			catch
			{
				return null;
			}
		}

		internal static CookieCollection Parse(string value, bool response)
		{
			try
			{
				return response ? parseResponse(value) : parseRequest(value);
			}
			catch (Exception innerException)
			{
				throw new CookieException("It could not be parsed.", innerException);
			}
		}

		internal void SetOrRemove(Cookie cookie)
		{
			int num = search(cookie);
			if (num == -1)
			{
				if (!cookie.Expired)
				{
					_list.Add(cookie);
				}
			}
			else if (cookie.Expired)
			{
				_list.RemoveAt(num);
			}
			else
			{
				_list[num] = cookie;
			}
		}

		internal void SetOrRemove(CookieCollection cookies)
		{
			foreach (Cookie item in cookies._list)
			{
				SetOrRemove(item);
			}
		}

		internal void Sort()
		{
			if (_list.Count > 1)
			{
				_list.Sort(compareForSort);
			}
		}

		public void Add(Cookie cookie)
		{
			if (_readOnly)
			{
				string message = "The collection is read-only.";
				throw new InvalidOperationException(message);
			}
			if (cookie == null)
			{
				throw new ArgumentNullException("cookie");
			}
			add(cookie);
		}

		public void Add(CookieCollection cookies)
		{
			if (_readOnly)
			{
				string message = "The collection is read-only.";
				throw new InvalidOperationException(message);
			}
			if (cookies == null)
			{
				throw new ArgumentNullException("cookies");
			}
			foreach (Cookie item in cookies._list)
			{
				add(item);
			}
		}

		public void Clear()
		{
			if (_readOnly)
			{
				string message = "The collection is read-only.";
				throw new InvalidOperationException(message);
			}
			_list.Clear();
		}

		public bool Contains(Cookie cookie)
		{
			if (cookie == null)
			{
				throw new ArgumentNullException("cookie");
			}
			return search(cookie) > -1;
		}

		public void CopyTo(Cookie[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", "Less than zero.");
			}
			if (array.Length - index < _list.Count)
			{
				string message = "The available space of the array is not enough to copy to.";
				throw new ArgumentException(message);
			}
			_list.CopyTo(array, index);
		}

		public IEnumerator<Cookie> GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		public bool Remove(Cookie cookie)
		{
			if (_readOnly)
			{
				string message = "The collection is read-only.";
				throw new InvalidOperationException(message);
			}
			if (cookie == null)
			{
				throw new ArgumentNullException("cookie");
			}
			int num = search(cookie);
			if (num == -1)
			{
				return false;
			}
			_list.RemoveAt(num);
			return true;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _list.GetEnumerator();
		}
	}
	[Serializable]
	public class CookieException : FormatException, ISerializable
	{
		internal CookieException(string message)
			: base(message)
		{
		}

		internal CookieException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected CookieException(SerializationInfo serializationInfo, StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
		}

		public CookieException()
		{
		}

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			base.GetObjectData(serializationInfo, streamingContext);
		}

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter, SerializationFormatter = true)]
		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			base.GetObjectData(serializationInfo, streamingContext);
		}
	}
	internal sealed class EndPointListener
	{
		private List<HttpListenerPrefix> _all;

		private Dictionary<HttpConnection, HttpConnection> _connections;

		private object _connectionsSync;

		private static readonly string _defaultCertFolderPath;

		private IPEndPoint _endpoint;

		private List<HttpListenerPrefix> _prefixes;

		private bool _secure;

		private Socket _socket;

		private ServerSslConfiguration _sslConfig;

		private List<HttpListenerPrefix> _unhandled;

		public IPAddress Address => _endpoint.Address;

		public bool IsSecure => _secure;

		public int Port => _endpoint.Port;

		public ServerSslConfiguration SslConfiguration => _sslConfig;

		static EndPointListener()
		{
			_defaultCertFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		}

		internal EndPointListener(IPEndPoint endpoint, bool secure, string certificateFolderPath, ServerSslConfiguration sslConfig, bool reuseAddress)
		{
			_endpoint = endpoint;
			if (secure)
			{
				X509Certificate2 certificate = getCertificate(endpoint.Port, certificateFolderPath, sslConfig.ServerCertificate);
				if (certificate == null)
				{
					string message = "No server certificate could be found.";
					throw new ArgumentException(message);
				}
				_secure = true;
				_sslConfig = new ServerSslConfiguration(sslConfig);
				_sslConfig.ServerCertificate = certificate;
			}
			_prefixes = new List<HttpListenerPrefix>();
			_connections = new Dictionary<HttpConnection, HttpConnection>();
			_connectionsSync = ((ICollection)_connections).SyncRoot;
			_socket = new Socket(endpoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			if (reuseAddress)
			{
				_socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, optionValue: true);
			}
			_socket.Bind(endpoint);
			_socket.Listen(500);
			_socket.BeginAccept(onAccept, this);
		}

		private static void addSpecial(List<HttpListenerPrefix> prefixes, HttpListenerPrefix prefix)
		{
			string path = prefix.Path;
			foreach (HttpListenerPrefix prefix2 in prefixes)
			{
				if (prefix2.Path == path)
				{
					string message = "The prefix is already in use.";
					throw new HttpListenerException(87, message);
				}
			}
			prefixes.Add(prefix);
		}

		private void clearConnections()
		{
			HttpConnection[] array = null;
			lock (_connectionsSync)
			{
				int count = _connections.Count;
				if (count == 0)
				{
					return;
				}
				array = new HttpConnection[count];
				Dictionary<HttpConnection, HttpConnection>.ValueCollection values = _connections.Values;
				values.CopyTo(array, 0);
				_connections.Clear();
			}
			HttpConnection[] array2 = array;
			foreach (HttpConnection httpConnection in array2)
			{
				httpConnection.Close(force: true);
			}
		}

		private static RSACryptoServiceProvider createRSAFromFile(string path)
		{
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
			byte[] keyBlob = File.ReadAllBytes(path);
			rSACryptoServiceProvider.ImportCspBlob(keyBlob);
			return rSACryptoServiceProvider;
		}

		private static X509Certificate2 getCertificate(int port, string folderPath, X509Certificate2 defaultCertificate)
		{
			if (folderPath == null || folderPath.Length == 0)
			{
				folderPath = _defaultCertFolderPath;
			}
			try
			{
				string text = Path.Combine(folderPath, $"{port}.cer");
				string path = Path.Combine(folderPath, $"{port}.key");
				if (File.Exists(text) && File.Exists(path))
				{
					X509Certificate2 x509Certificate = new X509Certificate2(text);
					x509Certificate.PrivateKey = createRSAFromFile(path);
					return x509Certificate;
				}
			}
			catch
			{
			}
			return defaultCertificate;
		}

		private void leaveIfNoPrefix()
		{
			if (_prefixes.Count > 0)
			{
				return;
			}
			List<HttpListenerPrefix> unhandled = _unhandled;
			if (unhandled == null || unhandled.Count <= 0)
			{
				unhandled = _all;
				if (unhandled == null || unhandled.Count <= 0)
				{
					Close();
				}
			}
		}

		private static void onAccept(IAsyncResult asyncResult)
		{
			EndPointListener endPointListener = (EndPointListener)asyncResult.AsyncState;
			Socket socket = null;
			try
			{
				socket = endPointListener._socket.EndAccept(asyncResult);
			}
			catch (ObjectDisposedException)
			{
				return;
			}
			catch (Exception)
			{
			}
			try
			{
				endPointListener._socket.BeginAccept(onAccept, endPointListener);
			}
			catch (Exception)
			{
				socket?.Close();
				return;
			}
			if (socket != null)
			{
				processAccepted(socket, endPointListener);
			}
		}

		private static void processAccepted(Socket socket, EndPointListener listener)
		{
			HttpConnection httpConnection = null;
			try
			{
				httpConnection = new HttpConnection(socket, listener);
			}
			catch (Exception)
			{
				socket.Close();
				return;
			}
			lock (listener._connectionsSync)
			{
				listener._connections.Add(httpConnection, httpConnection);
			}
			httpConnection.BeginReadRequest();
		}

		private static bool removeSpecial(List<HttpListenerPrefix> prefixes, HttpListenerPrefix prefix)
		{
			string path = prefix.Path;
			int count = prefixes.Count;
			for (int i = 0; i < count; i++)
			{
				if (prefixes[i].Path == path)
				{
					prefixes.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		private static HttpListener searchHttpListenerFromSpecial(string path, List<HttpListenerPrefix> prefixes)
		{
			if (prefixes == null)
			{
				return null;
			}
			HttpListener result = null;
			int num = -1;
			foreach (HttpListenerPrefix prefix in prefixes)
			{
				string path2 = prefix.Path;
				int length = path2.Length;
				if (length >= num && path.StartsWith(path2, StringComparison.Ordinal))
				{
					num = length;
					result = prefix.Listener;
				}
			}
			return result;
		}

		internal static bool CertificateExists(int port, string folderPath)
		{
			if (folderPath == null || folderPath.Length == 0)
			{
				folderPath = _defaultCertFolderPath;
			}
			string path = Path.Combine(folderPath, $"{port}.cer");
			string path2 = Path.Combine(folderPath, $"{port}.key");
			return File.Exists(path) && File.Exists(path2);
		}

		internal void RemoveConnection(HttpConnection connection)
		{
			lock (_connectionsSync)
			{
				_connections.Remove(connection);
			}
		}

		internal bool TrySearchHttpListener(Uri uri, out HttpListener listener)
		{
			listener = null;
			if (uri == null)
			{
				return false;
			}
			string host = uri.Host;
			bool flag = Uri.CheckHostName(host) == UriHostNameType.Dns;
			string text = uri.Port.ToString();
			string text2 = HttpUtility.UrlDecode(uri.AbsolutePath);
			if (text2[text2.Length - 1] != '/')
			{
				text2 += "/";
			}
			if (host != null && host.Length > 0)
			{
				List<HttpListenerPrefix> prefixes = _prefixes;
				int num = -1;
				foreach (HttpListenerPrefix item in prefixes)
				{
					if (flag)
					{
						string host2 = item.Host;
						if (Uri.CheckHostName(host2) == UriHostNameType.Dns && host2 != host)
						{
							continue;
						}
					}
					if (!(item.Port != text))
					{
						string path = item.Path;
						int length = path.Length;
						if (length >= num && text2.StartsWith(path, StringComparison.Ordinal))
						{
							num = length;
							listener = item.Listener;
						}
					}
				}
				if (num != -1)
				{
					return true;
				}
			}
			listener = searchHttpListenerFromSpecial(text2, _unhandled);
			if (listener != null)
			{
				return true;
			}
			listener = searchHttpListenerFromSpecial(text2, _all);
			return listener != null;
		}

		public void AddPrefix(HttpListenerPrefix prefix)
		{
			List<HttpListenerPrefix> unhandled;
			List<HttpListenerPrefix> list;
			if (prefix.Host == "*")
			{
				do
				{
					unhandled = _unhandled;
					list = ((unhandled != null) ? new List<HttpListenerPrefix>(unhandled) : new List<HttpListenerPrefix>());
					addSpecial(list, prefix);
				}
				while (Interlocked.CompareExchange(ref _unhandled, list, unhandled) != unhandled);
				return;
			}
			if (prefix.Host == "+")
			{
				do
				{
					unhandled = _all;
					list = ((unhandled != null) ? new List<HttpListenerPrefix>(unhandled) : new List<HttpListenerPrefix>());
					addSpecial(list, prefix);
				}
				while (Interlocked.CompareExchange(ref _all, list, unhandled) != unhandled);
				return;
			}
			do
			{
				unhandled = _prefixes;
				int num = unhandled.IndexOf(prefix);
				if (num > -1)
				{
					if (unhandled[num].Listener != prefix.Listener)
					{
						string message = $"There is another listener for {prefix}.";
						throw new HttpListenerException(87, message);
					}
					break;
				}
				list = new List<HttpListenerPrefix>(unhandled);
				list.Add(prefix);
			}
			while (Interlocked.CompareExchange(ref _prefixes, list, unhandled) != unhandled);
		}

		public void Close()
		{
			_socket.Close();
			clearConnections();
			EndPointManager.RemoveEndPoint(_endpoint);
		}

		public void RemovePrefix(HttpListenerPrefix prefix)
		{
			List<HttpListenerPrefix> unhandled;
			List<HttpListenerPrefix> list;
			if (prefix.Host == "*")
			{
				do
				{
					unhandled = _unhandled;
					if (unhandled == null)
					{
						break;
					}
					list = new List<HttpListenerPrefix>(unhandled);
				}
				while (removeSpecial(list, prefix) && Interlocked.CompareExchange(ref _unhandled, list, unhandled) != unhandled);
				leaveIfNoPrefix();
				return;
			}
			if (prefix.Host == "+")
			{
				do
				{
					unhandled = _all;
					if (unhandled == null)
					{
						break;
					}
					list = new List<HttpListenerPrefix>(unhandled);
				}
				while (removeSpecial(list, prefix) && Interlocked.CompareExchange(ref _all, list, unhandled) != unhandled);
				leaveIfNoPrefix();
				return;
			}
			do
			{
				unhandled = _prefixes;
				if (!unhandled.Contains(prefix))
				{
					break;
				}
				list = new List<HttpListenerPrefix>(unhandled);
				list.Remove(prefix);
			}
			while (Interlocked.CompareExchange(ref _prefixes, list, unhandled) != unhandled);
			leaveIfNoPrefix();
		}
	}
	internal sealed class EndPointManager
	{
		private static readonly Dictionary<IPEndPoint, EndPointListener> _endpoints;

		static EndPointManager()
		{
			_endpoints = new Dictionary<IPEndPoint, EndPointListener>();
		}

		private EndPointManager()
		{
		}

		private static void addPrefix(string uriPrefix, HttpListener listener)
		{
			HttpListenerPrefix httpListenerPrefix = new HttpListenerPrefix(uriPrefix, listener);
			IPAddress iPAddress = convertToIPAddress(httpListenerPrefix.Host);
			if (iPAddress == null)
			{
				string message = "The URI prefix includes an invalid host.";
				throw new HttpListenerException(87, message);
			}
			if (!iPAddress.IsLocal())
			{
				string message2 = "The URI prefix includes an invalid host.";
				throw new HttpListenerException(87, message2);
			}
			if (!int.TryParse(httpListenerPrefix.Port, out var result))
			{
				string message3 = "The URI prefix includes an invalid port.";
				throw new HttpListenerException(87, message3);
			}
			if (!result.IsPortNumber())
			{
				string message4 = "The URI prefix includes an invalid port.";
				throw new HttpListenerException(87, message4);
			}
			string path = httpListenerPrefix.Path;
			if (path.IndexOf('%') != -1)
			{
				string message5 = "The URI prefix includes an invalid path.";
				throw new HttpListenerException(87, message5);
			}
			if (path.IndexOf("//", StringComparison.Ordinal) != -1)
			{
				string message6 = "The URI prefix includes an invalid path.";
				throw new HttpListenerException(87, message6);
			}
			IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, result);
			if (_endpoints.TryGetValue(iPEndPoint, out var value))
			{
				if (value.IsSecure ^ httpListenerPrefix.IsSecure)
				{
					string message7 = "The URI prefix includes an invalid scheme.";
					throw new HttpListenerException(87, message7);
				}
			}
			else
			{
				value = new EndPointListener(iPEndPoint, httpListenerPrefix.IsSecure, listener.CertificateFolderPath, listener.SslConfiguration, listener.ReuseAddress);
				_endpoints.Add(iPEndPoint, value);
			}
			value.AddPrefix(httpListenerPrefix);
		}

		private static IPAddress convertToIPAddress(string hostname)
		{
			if (hostname == "*")
			{
				return IPAddress.Any;
			}
			if (hostname == "+")
			{
				return IPAddress.Any;
			}
			return hostname.ToIPAddress();
		}

		private static void removePrefix(string uriPrefix, HttpListener listener)
		{
			HttpListenerPrefix httpListenerPrefix = new HttpListenerPrefix(uriPrefix, listener);
			IPAddress iPAddress = convertToIPAddress(httpListenerPrefix.Host);
			if (iPAddress == null || !iPAddress.IsLocal() || !int.TryParse(httpListenerPrefix.Port, out var result) || !result.IsPortNumber())
			{
				return;
			}
			string path = httpListenerPrefix.Path;
			if (path.IndexOf('%') == -1 && path.IndexOf("//", StringComparison.Ordinal) == -1)
			{
				IPEndPoint key = new IPEndPoint(iPAddress, result);
				if (_endpoints.TryGetValue(key, out var value) && !(value.IsSecure ^ httpListenerPrefix.IsSecure))
				{
					value.RemovePrefix(httpListenerPrefix);
				}
			}
		}

		internal static bool RemoveEndPoint(IPEndPoint endpoint)
		{
			lock (((ICollection)_endpoints).SyncRoot)
			{
				return _endpoints.Remove(endpoint);
			}
		}

		public static void AddListener(HttpListener listener)
		{
			List<string> list = new List<string>();
			lock (((ICollection)_endpoints).SyncRoot)
			{
				try
				{
					foreach (string prefix in listener.Prefixes)
					{
						addPrefix(prefix, listener);
						list.Add(prefix);
					}
				}
				catch
				{
					foreach (string item in list)
					{
						removePrefix(item, listener);
					}
					throw;
				}
			}
		}

		public static void AddPrefix(string uriPrefix, HttpListener listener)
		{
			lock (((ICollection)_endpoints).SyncRoot)
			{
				addPrefix(uriPrefix, listener);
			}
		}

		public static void RemoveListener(HttpListener listener)
		{
			lock (((ICollection)_endpoints).SyncRoot)
			{
				foreach (string prefix in listener.Prefixes)
				{
					removePrefix(prefix, listener);
				}
			}
		}

		public static void RemovePrefix(string uriPrefix, HttpListener listener)
		{
			lock (((ICollection)_endpoints).SyncRoot)
			{
				removePrefix(uriPrefix, listener);
			}
		}
	}
	internal sealed class HttpConnection
	{
		private int _attempts;

		private byte[] _buffer;

		private static readonly int _bufferLength;

		private HttpListenerContext _context;

		private StringBuilder _currentLine;

		private InputState _inputState;

		private RequestStream _inputStream;

		private LineState _lineState;

		private EndPointListener _listener;

		private EndPoint _localEndPoint;

		private static readonly int _maxInputLength;

		private ResponseStream _outputStream;

		private int _position;

		private EndPoint _remoteEndPoint;

		private MemoryStream _requestBuffer;

		private int _reuses;

		private bool _secure;

		private Socket _socket;

		private Stream _stream;

		private object _sync;

		private int _timeout;

		private Dictionary<int, bool> _timeoutCanceled;

		private System.Threading.Timer _timer;

		public bool IsClosed => _socket == null;

		public bool IsLocal => ((IPEndPoint)_remoteEndPoint).Address.IsLocal();

		public bool IsSecure => _secure;

		public IPEndPoint LocalEndPoint => (IPEndPoint)_localEndPoint;

		public IPEndPoint RemoteEndPoint => (IPEndPoint)_remoteEndPoint;

		public int Reuses => _reuses;

		public Stream Stream => _stream;

		static HttpConnection()
		{
			_bufferLength = 8192;
			_maxInputLength = 32768;
		}

		internal HttpConnection(Socket socket, EndPointListener listener)
		{
			_socket = socket;
			_listener = listener;
			NetworkStream networkStream = new NetworkStream(socket, ownsSocket: false);
			if (listener.IsSecure)
			{
				ServerSslConfiguration sslConfiguration = listener.SslConfiguration;
				SslStream sslStream = new SslStream(networkStream, leaveInnerStreamOpen: false, sslConfiguration.ClientCertificateValidationCallback);
				sslStream.AuthenticateAsServer(sslConfiguration.ServerCertificate, sslConfiguration.ClientCertificateRequired, sslConfiguration.EnabledSslProtocols, sslConfiguration.CheckCertificateRevocation);
				_secure = true;
				_stream = sslStream;
			}
			else
			{
				_stream = networkStream;
			}
			_buffer = new byte[_bufferLength];
			_localEndPoint = socket.LocalEndPoint;
			_remoteEndPoint = socket.RemoteEndPoint;
			_sync = new object();
			_timeoutCanceled = new Dictionary<int, bool>();
			_timer = new System.Threading.Timer(onTimeout, this, -1, -1);
			init(new MemoryStream(), 90000);
		}

		private void close()
		{
			lock (_sync)
			{
				if (_socket == null)
				{
					return;
				}
				disposeTimer();
				disposeRequestBuffer();
				disposeStream();
				closeSocket();
			}
			_context.Unregister();
			_listener.RemoveConnection(this);
		}

		private void closeSocket()
		{
			try
			{
				_socket.Shutdown(SocketShutdown.Both);
			}
			catch
			{
			}
			_socket.Close();
			_socket = null;
		}

		private static MemoryStream createRequestBuffer(RequestStream inputStream)
		{
			MemoryStream memoryStream = new MemoryStream();
			if (inputStream is ChunkedRequestStream)
			{
				ChunkedRequestStream chunkedRequestStream = (ChunkedRequestStream)inputStream;
				if (chunkedRequestStream.HasRemainingBuffer)
				{
					byte[] remainingBuffer = chunkedRequestStream.RemainingBuffer;
					memoryStream.Write(remainingBuffer, 0, remainingBuffer.Length);
				}
				return memoryStream;
			}
			int count = inputStream.Count;
			if (count > 0)
			{
				memoryStream.Write(inputStream.InitialBuffer, inputStream.Offset, count);
			}
			return memoryStream;
		}

		private void disposeRequestBuffer()
		{
			if (_requestBuffer != null)
			{
				_requestBuffer.Dispose();
				_requestBuffer = null;
			}
		}

		private void disposeStream()
		{
			if (_stream != null)
			{
				_stream.Dispose();
				_stream = null;
			}
		}

		private void disposeTimer()
		{
			if (_timer != null)
			{
				try
				{
					_timer.Change(-1, -1);
				}
				catch
				{
				}
				_timer.Dispose();
				_timer = null;
			}
		}

		private void init(MemoryStream requestBuffer, int timeout)
		{
			_requestBuffer = requestBuffer;
			_timeout = timeout;
			_context = new HttpListenerContext(this);
			_currentLine = new StringBuilder(64);
			_inputState = InputState.RequestLine;
			_inputStream = null;
			_lineState = LineState.None;
			_outputStream = null;
			_position = 0;
		}

		private static void onRead(IAsyncResult asyncResult)
		{
			HttpConnection httpConnection = (HttpConnection)asyncResult.AsyncState;
			int attempts = httpConnection._attempts;
			if (httpConnection._socket == null)
			{
				return;
			}
			lock (httpConnection._sync)
			{
				if (httpConnection._socket == null)
				{
					return;
				}
				httpConnection._timer.Change(-1, -1);
				httpConnection._timeoutCanceled[attempts] = true;
				int num = 0;
				try
				{
					num = httpConnection._stream.EndRead(asyncResult);
				}
				catch (Exception)
				{
					httpConnection.close();
					return;
				}
				if (num <= 0)
				{
					httpConnection.close();
					return;
				}
				httpConnection._requestBuffer.Write(httpConnection._buffer, 0, num);
				if (!httpConnection.processRequestBuffer())
				{
					httpConnection.BeginReadRequest();
				}
			}
		}

		private static void onTimeout(object state)
		{
			HttpConnection httpConnection = (HttpConnection)state;
			int attempts = httpConnection._attempts;
			if (httpConnection._socket == null)
			{
				return;
			}
			lock (httpConnection._sync)
			{
				if (httpConnection._socket != null && !httpConnection._timeoutCanceled[attempts])
				{
					httpConnection._context.SendError(408);
				}
			}
		}

		private bool processInput(byte[] data, int length)
		{
			try
			{
				while (true)
				{
					int nread;
					string text = readLineFrom(data, _position, length, out nread);
					_position += nread;
					if (text == null)
					{
						break;
					}
					if (text.Length == 0)
					{
						if (_inputState == InputState.RequestLine)
						{
							continue;
						}
						if (_position > _maxInputLength)
						{
							_context.ErrorMessage = "Headers too long";
						}
						return true;
					}
					if (_inputState == InputState.RequestLine)
					{
						_context.Request.SetRequestLine(text);
						_inputState = InputState.Headers;
					}
					else
					{
						_context.Request.AddHeader(text);
					}
					if (!_context.HasErrorMessage)
					{
						continue;
					}
					return true;
				}
			}
			catch (Exception ex)
			{
				_context.ErrorMessage = ex.Message;
				return true;
			}
			if (_position >= _maxInputLength)
			{
				_context.ErrorMessage = "Headers too long";
				return true;
			}
			return false;
		}

		private bool processRequestBuffer()
		{
			byte[] buffer = _requestBuffer.GetBuffer();
			int length = (int)_requestBuffer.Length;
			if (!processInput(buffer, length))
			{
				return false;
			}
			if (!_context.HasErrorMessage)
			{
				_context.Request.FinishInitialization();
			}
			if (_context.HasErrorMessage)
			{
				_context.SendError();
				return true;
			}
			Uri url = _context.Request.Url;
			if (!_listener.TrySearchHttpListener(url, out var listener))
			{
				_context.SendError(404);
				return true;
			}
			listener.RegisterContext(_context);
			return true;
		}

		private string readLineFrom(byte[] buffer, int offset, int length, out int nread)
		{
			nread = 0;
			for (int i = offset; i < length; i++)
			{
				nread++;
				byte b = buffer[i];
				switch (b)
				{
				case 13:
					_lineState = LineState.Cr;
					continue;
				case 10:
					break;
				default:
					_currentLine.Append((char)b);
					continue;
				}
				_lineState = LineState.Lf;
				break;
			}
			if (_lineState != LineState.Lf)
			{
				return null;
			}
			string result = _currentLine.ToString();
			_currentLine.Length = 0;
			_lineState = LineState.None;
			return result;
		}

		private MemoryStream takeOverRequestBuffer()
		{
			if (_inputStream != null)
			{
				return createRequestBuffer(_inputStream);
			}
			MemoryStream memoryStream = new MemoryStream();
			byte[] buffer = _requestBuffer.GetBuffer();
			int num = (int)_requestBuffer.Length;
			int num2 = num - _position;
			if (num2 > 0)
			{
				memoryStream.Write(buffer, _position, num2);
			}
			disposeRequestBuffer();
			return memoryStream;
		}

		internal void BeginReadRequest()
		{
			_attempts++;
			_timeoutCanceled.Add(_attempts, value: false);
			_timer.Change(_timeout, -1);
			try
			{
				_stream.BeginRead(_buffer, 0, _bufferLength, onRead, this);
			}
			catch (Exception)
			{
				close();
			}
		}

		internal void Close(bool force)
		{
			if (_socket == null)
			{
				return;
			}
			lock (_sync)
			{
				if (_socket == null)
				{
					return;
				}
				if (force)
				{
					if (_outputStream != null)
					{
						_outputStream.Close(force: true);
					}
					close();
					return;
				}
				GetResponseStream().Close(force: false);
				if (_context.Response.CloseConnection)
				{
					close();
					return;
				}
				if (!_context.Request.FlushInput())
				{
					close();
					return;
				}
				_context.Unregister();
				_reuses++;
				MemoryStream memoryStream = takeOverRequestBuffer();
				long length = memoryStream.Length;
				init(memoryStream, 15000);
				if (length <= 0 || !processRequestBuffer())
				{
					BeginReadRequest();
				}
			}
		}

		public void Close()
		{
			Close(force: false);
		}

		public RequestStream GetRequestStream(long contentLength, bool chunked)
		{
			lock (_sync)
			{
				if (_socket == null)
				{
					return null;
				}
				if (_inputStream != null)
				{
					return _inputStream;
				}
				byte[] buffer = _requestBuffer.GetBuffer();
				int num = (int)_requestBuffer.Length;
				int count = num - _position;
				_inputStream = (chunked ? new ChunkedRequestStream(_stream, buffer, _position, count, _context) : new RequestStream(_stream, buffer, _position, count, contentLength));
				disposeRequestBuffer();
				return _inputStream;
			}
		}

		public ResponseStream GetResponseStream()
		{
			lock (_sync)
			{
				if (_socket == null)
				{
					return null;
				}
				if (_outputStream != null)
				{
					return _outputStream;
				}
				bool ignoreWriteExceptions = _context.Listener?.IgnoreWriteExceptions ?? true;
				_outputStream = new ResponseStream(_stream, _context.Response, ignoreWriteExceptions);
				return _outputStream;
			}
		}
	}
	public sealed class HttpListener : IDisposable
	{
		private AuthenticationSchemes _authSchemes;

		private Func<HttpListenerRequest, AuthenticationSchemes> _authSchemeSelector;

		private string _certFolderPath;

		private Queue<HttpListenerContext> _contextQueue;

		private LinkedList<HttpListenerContext> _contextRegistry;

		private object _contextRegistrySync;

		private static readonly string _defaultRealm;

		private bool _disposed;

		private bool _ignoreWriteExceptions;

		private volatile bool _listening;

		private Logger _log;

		private string _objectName;

		private HttpListenerPrefixCollection _prefixes;

		private string _realm;

		private bool _reuseAddress;

		private ServerSslConfiguration _sslConfig;

		private Func<IIdentity, NetworkCredential> _userCredFinder;

		private Queue<HttpListenerAsyncResult> _waitQueue;

		internal bool ReuseAddress
		{
			get
			{
				return _reuseAddress;
			}
			set
			{
				_reuseAddress = value;
			}
		}

		public AuthenticationSchemes AuthenticationSchemes
		{
			get
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				return _authSchemes;
			}
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				_authSchemes = value;
			}
		}

		public Func<HttpListenerRequest, AuthenticationSchemes> AuthenticationSchemeSelector
		{
			get
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				return _authSchemeSelector;
			}
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				_authSchemeSelector = value;
			}
		}

		public string CertificateFolderPath
		{
			get
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				return _certFolderPath;
			}
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				_certFolderPath = value;
			}
		}

		public bool IgnoreWriteExceptions
		{
			get
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				return _ignoreWriteExceptions;
			}
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				_ignoreWriteExceptions = value;
			}
		}

		public bool IsListening => _listening;

		public static bool IsSupported => true;

		public Logger Log => _log;

		public HttpListenerPrefixCollection Prefixes
		{
			get
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				return _prefixes;
			}
		}

		public string Realm
		{
			get
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				return _realm;
			}
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				_realm = value;
			}
		}

		public ServerSslConfiguration SslConfiguration
		{
			get
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				if (_sslConfig == null)
				{
					_sslConfig = new ServerSslConfiguration();
				}
				return _sslConfig;
			}
		}

		public bool UnsafeConnectionNtlmAuthentication
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public Func<IIdentity, NetworkCredential> UserCredentialsFinder
		{
			get
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				return _userCredFinder;
			}
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				_userCredFinder = value;
			}
		}

		static HttpListener()
		{
			_defaultRealm = "SECRET AREA";
		}

		public HttpListener()
		{
			_authSchemes = AuthenticationSchemes.Anonymous;
			_contextQueue = new Queue<HttpListenerContext>();
			_contextRegistry = new LinkedList<HttpListenerContext>();
			_contextRegistrySync = ((ICollection)_contextRegistry).SyncRoot;
			_log = new Logger();
			_objectName = GetType().ToString();
			_prefixes = new HttpListenerPrefixCollection(this);
			_waitQueue = new Queue<HttpListenerAsyncResult>();
		}

		private bool authenticateContext(HttpListenerContext context)
		{
			HttpListenerRequest request = context.Request;
			AuthenticationSchemes authenticationSchemes = selectAuthenticationScheme(request);
			switch (authenticationSchemes)
			{
			case AuthenticationSchemes.Anonymous:
				return true;
			case AuthenticationSchemes.None:
			{
				string message = "Authentication not allowed";
				context.SendError(403, message);
				return false;
			}
			default:
			{
				string realm = getRealm();
				IPrincipal principal = HttpUtility.CreateUser(request.Headers["Authorization"], authenticationSchemes, realm, request.HttpMethod, _userCredFinder);
				if (principal == null || !principal.Identity.IsAuthenticated)
				{
					context.SendAuthenticationChallenge(authenticationSchemes, realm);
					return false;
				}
				context.User = principal;
				return true;
			}
			}
		}

		private HttpListenerAsyncResult beginGetContext(AsyncCallback callback, object state)
		{
			lock (_contextRegistrySync)
			{
				if (!_listening)
				{
					string message = (_disposed ? "The listener is closed." : "The listener is stopped.");
					throw new HttpListenerException(995, message);
				}
				HttpListenerAsyncResult httpListenerAsyncResult = new HttpListenerAsyncResult(callback, state);
				if (_contextQueue.Count == 0)
				{
					_waitQueue.Enqueue(httpListenerAsyncResult);
					return httpListenerAsyncResult;
				}
				HttpListenerContext context = _contextQueue.Dequeue();
				httpListenerAsyncResult.Complete(context, completedSynchronously: true);
				return httpListenerAsyncResult;
			}
		}

		private void cleanupContextQueue(bool force)
		{
			if (_contextQueue.Count == 0)
			{
				return;
			}
			if (force)
			{
				_contextQueue.Clear();
				return;
			}
			HttpListenerContext[] array = _contextQueue.ToArray();
			_contextQueue.Clear();
			HttpListenerContext[] array2 = array;
			foreach (HttpListenerContext httpListenerContext in array2)
			{
				httpListenerContext.SendError(503);
			}
		}

		private void cleanupContextRegistry()
		{
			int count = _contextRegistry.Count;
			if (count != 0)
			{
				HttpListenerContext[] array = new HttpListenerContext[count];
				_contextRegistry.CopyTo(array, 0);
				_contextRegistry.Clear();
				HttpListenerContext[] array2 = array;
				foreach (HttpListenerContext httpListenerContext in array2)
				{
					httpListenerContext.Connection.Close(force: true);
				}
			}
		}

		private void cleanupWaitQueue(string message)
		{
			if (_waitQueue.Count != 0)
			{
				HttpListenerAsyncResult[] array = _waitQueue.ToArray();
				_waitQueue.Clear();
				HttpListenerAsyncResult[] array2 = array;
				foreach (HttpListenerAsyncResult httpListenerAsyncResult in array2)
				{
					HttpListenerException exception = new HttpListenerException(995, message);
					httpListenerAsyncResult.Complete(exception);
				}
			}
		}

		private void close(bool force)
		{
			if (!_listening)
			{
				_disposed = true;
				return;
			}
			_listening = false;
			cleanupContextQueue(force);
			cleanupContextRegistry();
			string message = "The listener is closed.";
			cleanupWaitQueue(message);
			EndPointManager.RemoveListener(this);
			_disposed = true;
		}

		private string getRealm()
		{
			string realm = _realm;
			return (realm != null && realm.Length > 0) ? realm : _defaultRealm;
		}

		private bool registerContext(HttpListenerContext context)
		{
			lock (_contextRegistrySync)
			{
				if (!_listening)
				{
					return false;
				}
				context.Listener = this;
				_contextRegistry.AddLast(context);
				if (_waitQueue.Count == 0)
				{
					_contextQueue.Enqueue(context);
					return true;
				}
				HttpListenerAsyncResult httpListenerAsyncResult = _waitQueue.Dequeue();
				httpListenerAsyncResult.Complete(context, completedSynchronously: false);
				return true;
			}
		}

		private AuthenticationSchemes selectAuthenticationScheme(HttpListenerRequest request)
		{
			Func<HttpListenerRequest, AuthenticationSchemes> authSchemeSelector = _authSchemeSelector;
			if (authSchemeSelector == null)
			{
				return _authSchemes;
			}
			try
			{
				return authSchemeSelector(request);
			}
			catch
			{
				return AuthenticationSchemes.None;
			}
		}

		internal void CheckDisposed()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(_objectName);
			}
		}

		internal bool RegisterContext(HttpListenerContext context)
		{
			if (!authenticateContext(context))
			{
				return false;
			}
			if (!registerContext(context))
			{
				context.SendError(503);
				return false;
			}
			return true;
		}

		internal void UnregisterContext(HttpListenerContext context)
		{
			lock (_contextRegistrySync)
			{
				_contextRegistry.Remove(context);
			}
		}

		public void Abort()
		{
			if (_disposed)
			{
				return;
			}
			lock (_contextRegistrySync)
			{
				if (!_disposed)
				{
					close(force: true);
				}
			}
		}

		public IAsyncResult BeginGetContext(AsyncCallback callback, object state)
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(_objectName);
			}
			if (!_listening)
			{
				string message = "The listener has not been started.";
				throw new InvalidOperationException(message);
			}
			if (_prefixes.Count == 0)
			{
				string message2 = "The listener has no URI prefix on which listens.";
				throw new InvalidOperationException(message2);
			}
			return beginGetContext(callback, state);
		}

		public void Close()
		{
			if (_disposed)
			{
				return;
			}
			lock (_contextRegistrySync)
			{
				if (!_disposed)
				{
					close(force: false);
				}
			}
		}

		public HttpListenerContext EndGetContext(IAsyncResult asyncResult)
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(_objectName);
			}
			if (!_listening)
			{
				string message = "The listener has not been started.";
				throw new InvalidOperationException(message);
			}
			if (asyncResult == null)
			{
				throw new ArgumentNullException("asyncResult");
			}
			if (!(asyncResult is HttpListenerAsyncResult { SyncRoot: var syncRoot } httpListenerAsyncResult))
			{
				string message2 = "A wrong IAsyncResult instance.";
				throw new ArgumentException(message2, "asyncResult");
			}
			Monitor.Enter(syncRoot);
			try
			{
				if (httpListenerAsyncResult.EndCalled)
				{
					string message3 = "This IAsyncResult instance cannot be reused.";
					throw new InvalidOperationException(message3);
				}
				httpListenerAsyncResult.EndCalled = true;
			}
			finally
			{
				Monitor.Exit(syncRoot);
			}
			if (!httpListenerAsyncResult.IsCompleted)
			{
				httpListenerAsyncResult.AsyncWaitHandle.WaitOne();
			}
			return httpListenerAsyncResult.Context;
		}

		public HttpListenerContext GetContext()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(_objectName);
			}
			if (!_listening)
			{
				string message = "The listener has not been started.";
				throw new InvalidOperationException(message);
			}
			if (_prefixes.Count == 0)
			{
				string message2 = "The listener has no URI prefix on which listens.";
				throw new InvalidOperationException(message2);
			}
			HttpListenerAsyncResult httpListenerAsyncResult = beginGetContext(null, null);
			httpListenerAsyncResult.EndCalled = true;
			if (!httpListenerAsyncResult.IsCompleted)
			{
				httpListenerAsyncResult.AsyncWaitHandle.WaitOne();
			}
			return httpListenerAsyncResult.Context;
		}

		public void Start()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(_objectName);
			}
			lock (_contextRegistrySync)
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				if (!_listening)
				{
					EndPointManager.AddListener(this);
					_listening = true;
				}
			}
		}

		public void Stop()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(_objectName);
			}
			lock (_contextRegistrySync)
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(_objectName);
				}
				if (_listening)
				{
					_listening = false;
					cleanupContextQueue(force: false);
					cleanupContextRegistry();
					string message = "The listener is stopped.";
					cleanupWaitQueue(message);
					EndPointManager.RemoveListener(this);
				}
			}
		}

		void IDisposable.Dispose()
		{
			if (_disposed)
			{
				return;
			}
			lock (_contextRegistrySync)
			{
				if (!_disposed)
				{
					close(force: true);
				}
			}
		}
	}
	public sealed class HttpListenerContext
	{
		private HttpConnection _connection;

		private string _errorMessage;

		private int _errorStatusCode;

		private HttpListener _listener;

		private HttpListenerRequest _request;

		private HttpListenerResponse _response;

		private IPrincipal _user;

		private HttpListenerWebSocketContext _websocketContext;

		internal HttpConnection Connection => _connection;

		internal string ErrorMessage
		{
			get
			{
				return _errorMessage;
			}
			set
			{
				_errorMessage = value;
			}
		}

		internal int ErrorStatusCode
		{
			get
			{
				return _errorStatusCode;
			}
			set
			{
				_errorStatusCode = value;
			}
		}

		internal bool HasErrorMessage => _errorMessage != null;

		internal HttpListener Listener
		{
			get
			{
				return _listener;
			}
			set
			{
				_listener = value;
			}
		}

		public HttpListenerRequest Request => _request;

		public HttpListenerResponse Response => _response;

		public IPrincipal User
		{
			get
			{
				return _user;
			}
			internal set
			{
				_user = value;
			}
		}

		internal HttpListenerContext(HttpConnection connection)
		{
			_connection = connection;
			_errorStatusCode = 400;
			_request = new HttpListenerRequest(this);
			_response = new HttpListenerResponse(this);
		}

		private static string createErrorContent(int statusCode, string statusDescription, string message)
		{
			return (message != null && message.Length > 0) ? $"<html><body><h1>{statusCode} {statusDescription} ({message})</h1></body></html>" : $"<html><body><h1>{statusCode} {statusDescription}</h1></body></html>";
		}

		internal HttpListenerWebSocketContext GetWebSocketContext(string protocol)
		{
			_websocketContext = new HttpListenerWebSocketContext(this, protocol);
			return _websocketContext;
		}

		internal void SendAuthenticationChallenge(AuthenticationSchemes scheme, string realm)
		{
			_response.StatusCode = 401;
			string value = new AuthenticationChallenge(scheme, realm).ToString();
			_response.Headers.InternalSet("WWW-Authenticate", value, response: true);
			_response.Close();
		}

		internal void SendError()
		{
			try
			{
				_response.StatusCode = _errorStatusCode;
				_response.ContentType = "text/html";
				string s = createErrorContent(_errorStatusCode, _response.StatusDescription, _errorMessage);
				Encoding uTF = Encoding.UTF8;
				byte[] bytes = uTF.GetBytes(s);
				_response.ContentEncoding = uTF;
				_response.ContentLength64 = bytes.LongLength;
				_response.Close(bytes, willBlock: true);
			}
			catch
			{
				_connection.Close(force: true);
			}
		}

		internal void SendError(int statusCode)
		{
			_errorStatusCode = statusCode;
			SendError();
		}

		internal void SendError(int statusCode, string message)
		{
			_errorStatusCode = statusCode;
			_errorMessage = message;
			SendError();
		}

		internal void Unregister()
		{
			if (_listener != null)
			{
				_listener.UnregisterContext(this);
			}
		}

		public HttpListenerWebSocketContext AcceptWebSocket(string protocol)
		{
			if (_websocketContext != null)
			{
				string message = "The accepting is already in progress.";
				throw new InvalidOperationException(message);
			}
			if (protocol != null)
			{
				if (protocol.Length == 0)
				{
					string message2 = "An empty string.";
					throw new ArgumentException(message2, "protocol");
				}
				if (!protocol.IsToken())
				{
					string message3 = "It contains an invalid character.";
					throw new ArgumentException(message3, "protocol");
				}
			}
			return GetWebSocketContext(protocol);
		}
	}
	[Serializable]
	public class HttpListenerException : Win32Exception
	{
		public override int ErrorCode => base.NativeErrorCode;

		protected HttpListenerException(SerializationInfo serializationInfo, StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
		}

		public HttpListenerException()
		{
		}

		public HttpListenerException(int errorCode)
			: base(errorCode)
		{
		}

		public HttpListenerException(int errorCode, string message)
			: base(errorCode, message)
		{
		}
	}
	public class HttpListenerPrefixCollection : ICollection<string>, IEnumerable<string>, IEnumerable
	{
		private HttpListener _listener;

		private List<string> _prefixes;

		public int Count => _prefixes.Count;

		public bool IsReadOnly => false;

		public bool IsSynchronized => false;

		internal HttpListenerPrefixCollection(HttpListener listener)
		{
			_listener = listener;
			_prefixes = new List<string>();
		}

		public void Add(string uriPrefix)
		{
			_listener.CheckDisposed();
			HttpListenerPrefix.CheckPrefix(uriPrefix);
			if (!_prefixes.Contains(uriPrefix))
			{
				if (_listener.IsListening)
				{
					EndPointManager.AddPrefix(uriPrefix, _listener);
				}
				_prefixes.Add(uriPrefix);
			}
		}

		public void Clear()
		{
			_listener.CheckDisposed();
			if (_listener.IsListening)
			{
				EndPointManager.RemoveListener(_listener);
			}
			_prefixes.Clear();
		}

		public bool Contains(string uriPrefix)
		{
			_listener.CheckDisposed();
			if (uriPrefix == null)
			{
				throw new ArgumentNullException("uriPrefix");
			}
			return _prefixes.Contains(uriPrefix);
		}

		public void CopyTo(string[] array, int offset)
		{
			_listener.CheckDisposed();
			_prefixes.CopyTo(array, offset);
		}

		public IEnumerator<string> GetEnumerator()
		{
			return _prefixes.GetEnumerator();
		}

		public bool Remove(string uriPrefix)
		{
			_listener.CheckDisposed();
			if (uriPrefix == null)
			{
				throw new ArgumentNullException("uriPrefix");
			}
			if (!_prefixes.Contains(uriPrefix))
			{
				return false;
			}
			if (_listener.IsListening)
			{
				EndPointManager.RemovePrefix(uriPrefix, _listener);
			}
			return _prefixes.Remove(uriPrefix);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _prefixes.GetEnumerator();
		}
	}
	public sealed class HttpListenerRequest
	{
		private static readonly byte[] _100continue;

		private string[] _acceptTypes;

		private bool _chunked;

		private HttpConnection _connection;

		private Encoding _contentEncoding;

		private long _contentLength;

		private HttpListenerContext _context;

		private CookieCollection _cookies;

		private WebHeaderCollection _headers;

		private string _httpMethod;

		private Stream _inputStream;

		private Version _protocolVersion;

		private NameValueCollection _queryString;

		private string _rawUrl;

		private Guid _requestTraceIdentifier;

		private Uri _url;

		private Uri _urlReferrer;

		private bool _urlSet;

		private string _userHostName;

		private string[] _userLanguages;

		public string[] AcceptTypes
		{
			get
			{
				string text = _headers["Accept"];
				if (text == null)
				{
					return null;
				}
				if (_acceptTypes == null)
				{
					_acceptTypes = text.SplitHeaderValue(',').TrimEach().ToList()
						.ToArray();
				}
				return _acceptTypes;
			}
		}

		public int ClientCertificateError
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public Encoding ContentEncoding
		{
			get
			{
				if (_contentEncoding == null)
				{
					_contentEncoding = getContentEncoding();
				}
				return _contentEncoding;
			}
		}

		public long ContentLength64 => _contentLength;

		public string ContentType => _headers["Content-Type"];

		public CookieCollection Cookies
		{
			get
			{
				if (_cookies == null)
				{
					_cookies = _headers.GetCookies(response: false);
				}
				return _cookies;
			}
		}

		public bool HasEntityBody => _contentLength > 0 || _chunked;

		public NameValueCollection Headers => _headers;

		public string HttpMethod => _httpMethod;

		public Stream InputStream
		{
			get
			{
				if (_inputStream == null)
				{
					_inputStream = ((_contentLength > 0 || _chunked) ? _connection.GetRequestStream(_contentLength, _chunked) : Stream.Null);
				}
				return _inputStream;
			}
		}

		public bool IsAuthenticated => _context.User != null;

		public bool IsLocal => _connection.IsLocal;

		public bool IsSecureConnection => _connection.IsSecure;

		public bool IsWebSocketRequest => _httpMethod == "GET" && _headers.Upgrades("websocket");

		public bool KeepAlive => _headers.KeepsAlive(_protocolVersion);

		public IPEndPoint LocalEndPoint => _connection.LocalEndPoint;

		public Version ProtocolVersion => _protocolVersion;

		public NameValueCollection QueryString
		{
			get
			{
				if (_queryString == null)
				{
					Uri url = Url;
					_queryString = QueryStringCollection.Parse((url != null) ? url.Query : null, Encoding.UTF8);
				}
				return _queryString;
			}
		}

		public string RawUrl => _rawUrl;

		public IPEndPoint RemoteEndPoint => _connection.RemoteEndPoint;

		public Guid RequestTraceIdentifier => _requestTraceIdentifier;

		public Uri Url
		{
			get
			{
				if (!_urlSet)
				{
					_url = HttpUtility.CreateRequestUrl(_rawUrl, _userHostName ?? UserHostAddress, IsWebSocketRequest, IsSecureConnection);
					_urlSet = true;
				}
				return _url;
			}
		}

		public Uri UrlReferrer
		{
			get
			{
				string text = _headers["Referer"];
				if (text == null)
				{
					return null;
				}
				if (_urlReferrer == null)
				{
					_urlReferrer = text.ToUri();
				}
				return _urlReferrer;
			}
		}

		public string UserAgent => _headers["User-Agent"];

		public string UserHostAddress => _connection.LocalEndPoint.ToString();

		public string UserHostName => _userHostName;

		public string[] UserLanguages
		{
			get
			{
				string text = _headers["Accept-Language"];
				if (text == null)
				{
					return null;
				}
				if (_userLanguages == null)
				{
					_userLanguages = text.Split(new char[1] { ',' }).TrimEach().ToList()
						.ToArray();
				}
				return _userLanguages;
			}
		}

		static HttpListenerRequest()
		{
			_100continue = Encoding.ASCII.GetBytes("HTTP/1.1 100 Continue\r\n\r\n");
		}

		internal HttpListenerRequest(HttpListenerContext context)
		{
			_context = context;
			_connection = context.Connection;
			_contentLength = -1L;
			_headers = new WebHeaderCollection();
			_requestTraceIdentifier = Guid.NewGuid();
		}

		private Encoding getContentEncoding()
		{
			string text = _headers["Content-Type"];
			if (text == null)
			{
				return Encoding.UTF8;
			}
			Encoding result;
			return HttpUtility.TryGetEncoding(text, out result) ? result : Encoding.UTF8;
		}

		internal void AddHeader(string headerField)
		{
			char c = headerField[0];
			if (c == ' ' || c == '\t')
			{
				_context.ErrorMessage = "Invalid header field";
				return;
			}
			int num = headerField.IndexOf(':');
			if (num < 1)
			{
				_context.ErrorMessage = "Invalid header field";
				return;
			}
			string text = headerField.Substring(0, num).Trim();
			if (text.Length == 0 || !text.IsToken())
			{
				_context.ErrorMessage = "Invalid header name";
				return;
			}
			string text2 = ((num < headerField.Length - 1) ? headerField.Substring(num + 1).Trim() : string.Empty);
			_headers.InternalSet(text, text2, response: false);
			string text3 = text.ToLower(CultureInfo.InvariantCulture);
			if (text3 == "host")
			{
				if (_userHostName != null)
				{
					_context.ErrorMessage = "Invalid Host header";
				}
				else if (text2.Length == 0)
				{
					_context.ErrorMessage = "Invalid Host header";
				}
				else
				{
					_userHostName = text2;
				}
			}
			else if (text3 == "content-length")
			{
				long result;
				if (_contentLength > -1)
				{
					_context.ErrorMessage = "Invalid Content-Length header";
				}
				else if (!long.TryParse(text2, out result))
				{
					_context.ErrorMessage = "Invalid Content-Length header";
				}
				else if (result < 0)
				{
					_context.ErrorMessage = "Invalid Content-Length header";
				}
				else
				{
					_contentLength = result;
				}
			}
		}

		internal void FinishInitialization()
		{
			if (_userHostName == null)
			{
				_context.ErrorMessage = "Host header required";
				return;
			}
			string text = _headers["Transfer-Encoding"];
			if (text != null)
			{
				StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;
				if (!text.Equals("chunked", comparisonType))
				{
					_context.ErrorMessage = "Invalid Transfer-Encoding header";
					_context.ErrorStatusCode = 501;
					return;
				}
				_chunked = true;
			}
			if ((_httpMethod == "POST" || _httpMethod == "PUT") && _contentLength <= 0 && !_chunked)
			{
				_context.ErrorMessage = string.Empty;
				_context.ErrorStatusCode = 411;
				return;
			}
			string text2 = _headers["Expect"];
			if (text2 != null)
			{
				StringComparison comparisonType2 = StringComparison.OrdinalIgnoreCase;
				if (!text2.Equals("100-continue", comparisonType2))
				{
					_context.ErrorMessage = "Invalid Expect header";
					return;
				}
				ResponseStream responseStream = _connection.GetResponseStream();
				responseStream.InternalWrite(_100continue, 0, _100continue.Length);
			}
		}

		internal bool FlushInput()
		{
			Stream inputStream = InputStream;
			if (inputStream == Stream.Null)
			{
				return true;
			}
			int num = 2048;
			if (_contentLength > 0 && _contentLength < num)
			{
				num = (int)_contentLength;
			}
			byte[] buffer = new byte[num];
			while (true)
			{
				try
				{
					IAsyncResult asyncResult = inputStream.BeginRead(buffer, 0, num, null, null);
					if (!asyncResult.IsCompleted)
					{
						int millisecondsTimeout = 100;
						if (!asyncResult.AsyncWaitHandle.WaitOne(millisecondsTimeout))
						{
							return false;
						}
					}
					if (inputStream.EndRead(asyncResult) <= 0)
					{
						return true;
					}
				}
				catch
				{
					return false;
				}
			}
		}

		internal bool IsUpgradeRequest(string protocol)
		{
			return _headers.Upgrades(protocol);
		}

		internal void SetRequestLine(string requestLine)
		{
			string[] array = requestLine.Split(new char[1] { ' ' }, 3);
			if (array.Length < 3)
			{
				_context.ErrorMessage = "Invalid request line (parts)";
				return;
			}
			string text = array[0];
			if (text.Length == 0)
			{
				_context.ErrorMessage = "Invalid request line (method)";
				return;
			}
			string text2 = array[1];
			if (text2.Length == 0)
			{
				_context.ErrorMessage = "Invalid request line (target)";
				return;
			}
			string text3 = array[2];
			Version result;
			if (text3.Length != 8)
			{
				_context.ErrorMessage = "Invalid request line (version)";
			}
			else if (!text3.StartsWith("HTTP/", StringComparison.Ordinal))
			{
				_context.ErrorMessage = "Invalid request line (version)";
			}
			else if (!text3.Substring(5).TryCreateVersion(out result))
			{
				_context.ErrorMessage = "Invalid request line (version)";
			}
			else if (result != HttpVersion.Version11)
			{
				_context.ErrorMessage = "Invalid request line (version)";
				_context.ErrorStatusCode = 505;
			}
			else if (!text.IsHttpMethod(result))
			{
				_context.ErrorMessage = "Invalid request line (method)";
				_context.ErrorStatusCode = 501;
			}
			else
			{
				_httpMethod = text;
				_rawUrl = text2;
				_protocolVersion = result;
			}
		}

		public IAsyncResult BeginGetClientCertificate(AsyncCallback requestCallback, object state)
		{
			throw new NotSupportedException();
		}

		public X509Certificate2 EndGetClientCertificate(IAsyncResult asyncResult)
		{
			throw new NotSupportedException();
		}

		public X509Certificate2 GetClientCertificate()
		{
			throw new NotSupportedException();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.AppendFormat("{0} {1} HTTP/{2}\r\n", _httpMethod, _rawUrl, _protocolVersion).Append(_headers.ToString());
			return stringBuilder.ToString();
		}
	}
	public sealed class HttpListenerResponse : IDisposable
	{
		private bool _closeConnection;

		private Encoding _contentEncoding;

		private long _contentLength;

		private string _contentType;

		private HttpListenerContext _context;

		private CookieCollection _cookies;

		private bool _disposed;

		private WebHeaderCollection _headers;

		private bool _headersSent;

		private bool _keepAlive;

		private ResponseStream _outputStream;

		private Uri _redirectLocation;

		private bool _sendChunked;

		private int _statusCode;

		private string _statusDescription;

		private Version _version;

		internal bool CloseConnection
		{
			get
			{
				return _closeConnection;
			}
			set
			{
				_closeConnection = value;
			}
		}

		internal WebHeaderCollection FullHeaders
		{
			get
			{
				WebHeaderCollection webHeaderCollection = new WebHeaderCollection(HttpHeaderType.Response, internallyUsed: true);
				if (_headers != null)
				{
					webHeaderCollection.Add(_headers);
				}
				if (_contentType != null)
				{
					webHeaderCollection.InternalSet("Content-Type", createContentTypeHeaderText(_contentType, _contentEncoding), response: true);
				}
				if (webHeaderCollection["Server"] == null)
				{
					webHeaderCollection.InternalSet("Server", "websocket-sharp/1.0", response: true);
				}
				if (webHeaderCollection["Date"] == null)
				{
					webHeaderCollection.InternalSet("Date", DateTime.UtcNow.ToString("r", CultureInfo.InvariantCulture), response: true);
				}
				if (_sendChunked)
				{
					webHeaderCollection.InternalSet("Transfer-Encoding", "chunked", response: true);
				}
				else
				{
					webHeaderCollection.InternalSet("Content-Length", _contentLength.ToString(CultureInfo.InvariantCulture), response: true);
				}
				bool flag = !_context.Request.KeepAlive || !_keepAlive || _statusCode == 400 || _statusCode == 408 || _statusCode == 411 || _statusCode == 413 || _statusCode == 414 || _statusCode == 500 || _statusCode == 503;
				int reuses = _context.Connection.Reuses;
				if (flag || reuses >= 100)
				{
					webHeaderCollection.InternalSet("Connection", "close", response: true);
				}
				else
				{
					webHeaderCollection.InternalSet("Keep-Alive", $"timeout=15,max={100 - reuses}", response: true);
					if (_context.Request.ProtocolVersion < HttpVersion.Version11)
					{
						webHeaderCollection.InternalSet("Connection", "keep-alive", response: true);
					}
				}
				if (_redirectLocation != null)
				{
					webHeaderCollection.InternalSet("Location", _redirectLocation.AbsoluteUri, response: true);
				}
				if (_cookies != null)
				{
					foreach (Cookie cookie in _cookies)
					{
						webHeaderCollection.InternalSet("Set-Cookie", cookie.ToResponseString(), response: true);
					}
				}
				return webHeaderCollection;
			}
		}

		internal bool HeadersSent
		{
			get
			{
				return _headersSent;
			}
			set
			{
				_headersSent = value;
			}
		}

		internal string StatusLine => $"HTTP/{_version} {_statusCode} {_statusDescription}\r\n";

		public Encoding ContentEncoding
		{
			get
			{
				return _contentEncoding;
			}
			set
			{
				if (_disposed)
				{
					string objectName = GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				_contentEncoding = value;
			}
		}

		public long ContentLength64
		{
			get
			{
				return _contentLength;
			}
			set
			{
				if (_disposed)
				{
					string objectName = GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				if (value < 0)
				{
					string paramName = "Less than zero.";
					throw new ArgumentOutOfRangeException(paramName, "value");
				}
				_contentLength = value;
			}
		}

		public string ContentType
		{
			get
			{
				return _contentType;
			}
			set
			{
				if (_disposed)
				{
					string objectName = GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				if (value == null)
				{
					_contentType = null;
					return;
				}
				if (value.Length == 0)
				{
					string message2 = "An empty string.";
					throw new ArgumentException(message2, "value");
				}
				if (!isValidForContentType(value))
				{
					string message3 = "It contains an invalid character.";
					throw new ArgumentException(message3, "value");
				}
				_contentType = value;
			}
		}

		public CookieCollection Cookies
		{
			get
			{
				if (_cookies == null)
				{
					_cookies = new CookieCollection();
				}
				return _cookies;
			}
			set
			{
				_cookies = value;
			}
		}

		public WebHeaderCollection Headers
		{
			get
			{
				if (_headers == null)
				{
					_headers = new WebHeaderCollection(HttpHeaderType.Response, internallyUsed: false);
				}
				return _headers;
			}
			set
			{
				if (value == null)
				{
					_headers = null;
					return;
				}
				if (value.State != HttpHeaderType.Response)
				{
					string message = "The value is not valid for a response.";
					throw new InvalidOperationException(message);
				}
				_headers = value;
			}
		}

		public bool KeepAlive
		{
			get
			{
				return _keepAlive;
			}
			set
			{
				if (_disposed)
				{
					string objectName = GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				_keepAlive = value;
			}
		}

		public Stream OutputStream
		{
			get
			{
				if (_disposed)
				{
					string objectName = GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				if (_outputStream == null)
				{
					_outputStream = _context.Connection.GetResponseStream();
				}
				return _outputStream;
			}
		}

		public Version ProtocolVersion => _version;

		public string RedirectLocation
		{
			get
			{
				return (_redirectLocation != null) ? _redirectLocation.OriginalString : null;
			}
			set
			{
				if (_disposed)
				{
					string objectName = GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				if (value == null)
				{
					_redirectLocation = null;
					return;
				}
				if (value.Length == 0)
				{
					string message2 = "An empty string.";
					throw new ArgumentException(message2, "value");
				}
				if (!Uri.TryCreate(value, UriKind.Absolute, out var result))
				{
					string message3 = "Not an absolute URL.";
					throw new ArgumentException(message3, "value");
				}
				_redirectLocation = result;
			}
		}

		public bool SendChunked
		{
			get
			{
				return _sendChunked;
			}
			set
			{
				if (_disposed)
				{
					string objectName = GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				_sendChunked = value;
			}
		}

		public int StatusCode
		{
			get
			{
				return _statusCode;
			}
			set
			{
				if (_disposed)
				{
					string objectName = GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				if (value < 100 || value > 999)
				{
					string message2 = "A value is not between 100 and 999 inclusive.";
					throw new ProtocolViolationException(message2);
				}
				_statusCode = value;
				_statusDescription = value.GetStatusDescription();
			}
		}

		public string StatusDescription
		{
			get
			{
				return _statusDescription;
			}
			set
			{
				if (_disposed)
				{
					string objectName = GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length == 0)
				{
					_statusDescription = _statusCode.GetStatusDescription();
					return;
				}
				if (!isValidForStatusDescription(value))
				{
					string message2 = "It contains an invalid character.";
					throw new ArgumentException(message2, "value");
				}
				_statusDescription = value;
			}
		}

		internal HttpListenerResponse(HttpListenerContext context)
		{
			_context = context;
			_keepAlive = true;
			_statusCode = 200;
			_statusDescription = "OK";
			_version = HttpVersion.Version11;
		}

		private bool canSetCookie(Cookie cookie)
		{
			List<Cookie> list = findCookie(cookie).ToList();
			if (list.Count == 0)
			{
				return true;
			}
			int version = cookie.Version;
			foreach (Cookie item in list)
			{
				if (item.Version == version)
				{
					return true;
				}
			}
			return false;
		}

		private void close(bool force)
		{
			_disposed = true;
			_context.Connection.Close(force);
		}

		private void close(byte[] responseEntity, int bufferLength, bool willBlock)
		{
			Stream outputStream = OutputStream;
			if (willBlock)
			{
				outputStream.WriteBytes(responseEntity, bufferLength);
				close(force: false);
			}
			else
			{
				outputStream.WriteBytesAsync(responseEntity, bufferLength, delegate
				{
					close(force: false);
				}, null);
			}
		}

		private static string createContentTypeHeaderText(string value, Encoding encoding)
		{
			if (value.IndexOf("charset=", StringComparison.Ordinal) > -1)
			{
				return value;
			}
			if (encoding == null)
			{
				return value;
			}
			return $"{value}; charset={encoding.WebName}";
		}

		private IEnumerable<Cookie> findCookie(Cookie cookie)
		{
			if (_cookies == null || _cookies.Count == 0)
			{
				yield break;
			}
			foreach (Cookie c in _cookies)
			{
				if (c.EqualsWithoutValueAndVersion(cookie))
				{
					yield return c;
				}
			}
		}

		private static bool isValidForContentType(string value)
		{
			foreach (char c in value)
			{
				if (c < ' ')
				{
					return false;
				}
				if (c > '~')
				{
					return false;
				}
				if ("()<>@:\\[]?{}".IndexOf(c) > -1)
				{
					return false;
				}
			}
			return true;
		}

		private static bool isValidForStatusDescription(string value)
		{
			foreach (char c in value)
			{
				if (c < ' ')
				{
					return false;
				}
				if (c > '~')
				{
					return false;
				}
			}
			return true;
		}

		public void Abort()
		{
			if (!_disposed)
			{
				close(force: true);
			}
		}

		public void AppendCookie(Cookie cookie)
		{
			Cookies.Add(cookie);
		}

		public void AppendHeader(string name, string value)
		{
			Headers.Add(name, value);
		}

		public void Close()
		{
			if (!_disposed)
			{
				close(force: false);
			}
		}

		public void Close(byte[] responseEntity, bool willBlock)
		{
			if (_disposed)
			{
				string objectName = GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			if (responseEntity == null)
			{
				throw new ArgumentNullException("responseEntity");
			}
			long num = responseEntity.LongLength;
			if (num > int.MaxValue)
			{
				close(responseEntity, 1024, willBlock);
				return;
			}
			Stream stream = OutputStream;
			if (willBlock)
			{
				stream.Write(responseEntity, 0, (int)num);
				close(force: false);
				return;
			}
			stream.BeginWrite(responseEntity, 0, (int)num, delegate(IAsyncResult ar)
			{
				stream.EndWrite(ar);
				close(force: false);
			}, null);
		}

		public void CopyFrom(HttpListenerResponse templateResponse)
		{
			if (templateResponse == null)
			{
				throw new ArgumentNullException("templateResponse");
			}
			WebHeaderCollection headers = templateResponse._headers;
			if (headers != null)
			{
				if (_headers != null)
				{
					_headers.Clear();
				}
				Headers.Add(headers);
			}
			else
			{
				_headers = null;
			}
			_contentLength = templateResponse._contentLength;
			_statusCode = templateResponse._statusCode;
			_statusDescription = templateResponse._statusDescription;
			_keepAlive = templateResponse._keepAlive;
			_version = templateResponse._version;
		}

		public void Redirect(string url)
		{
			if (_disposed)
			{
				string objectName = GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			if (_headersSent)
			{
				string message = "The response is already being sent.";
				throw new InvalidOperationException(message);
			}
			if (url == null)
			{
				throw new ArgumentNullException("url");
			}
			if (url.Length == 0)
			{
				string message2 = "An empty string.";
				throw new ArgumentException(message2, "url");
			}
			if (!Uri.TryCreate(url, UriKind.Absolute, out var result))
			{
				string message3 = "Not an absolute URL.";
				throw new ArgumentException(message3, "url");
			}
			_redirectLocation = result;
			_statusCode = 302;
			_statusDescription = "Found";
		}

		public void SetCookie(Cookie cookie)
		{
			if (cookie == null)
			{
				throw new ArgumentNullException("cookie");
			}
			if (!canSetCookie(cookie))
			{
				string message = "It cannot be updated.";
				throw new ArgumentException(message, "cookie");
			}
			Cookies.Add(cookie);
		}

		public void SetHeader(string name, string value)
		{
			Headers.Set(name, value);
		}

		void IDisposable.Dispose()
		{
			if (!_disposed)
			{
				close(force: true);
			}
		}
	}
	internal class HttpStreamAsyncResult : IAsyncResult
	{
		private byte[] _buffer;

		private AsyncCallback _callback;

		private bool _completed;

		private int _count;

		private Exception _exception;

		private int _offset;

		private object _state;

		private object _sync;

		private int _syncRead;

		private ManualResetEvent _waitHandle;

		internal byte[] Buffer
		{
			get
			{
				return _buffer;
			}
			set
			{
				_buffer = value;
			}
		}

		internal int Count
		{
			get
			{
				return _count;
			}
			set
			{
				_count = value;
			}
		}

		internal Exception Exception => _exception;

		internal bool HasException => _exception != null;

		internal int Offset
		{
			get
			{
				return _offset;
			}
			set
			{
				_offset = value;
			}
		}

		internal int SyncRead
		{
			get
			{
				return _syncRead;
			}
			set
			{
				_syncRead = value;
			}
		}

		public object AsyncState => _state;

		public WaitHandle AsyncWaitHandle
		{
			get
			{
				lock (_sync)
				{
					if (_waitHandle == null)
					{
						_waitHandle = new ManualResetEvent(_completed);
					}
					return _waitHandle;
				}
			}
		}

		public bool CompletedSynchronously => _syncRead == _count;

		public bool IsCompleted
		{
			get
			{
				lock (_sync)
				{
					return _completed;
				}
			}
		}

		internal HttpStreamAsyncResult(AsyncCallback callback, object state)
		{
			_callback = callback;
			_state = state;
			_sync = new object();
		}

		internal void Complete()
		{
			lock (_sync)
			{
				if (_completed)
				{
					return;
				}
				_completed = true;
				if (_waitHandle != null)
				{
					_waitHandle.Set();
				}
				if (_callback != null)
				{
					_callback.BeginInvoke(this, delegate(IAsyncResult ar)
					{
						_callback.EndInvoke(ar);
					}, null);
				}
			}
		}

		internal void Complete(Exception exception)
		{
			lock (_sync)
			{
				if (_completed)
				{
					return;
				}
				_completed = true;
				_exception = exception;
				if (_waitHandle != null)
				{
					_waitHandle.Set();
				}
				if (_callback != null)
				{
					_callback.BeginInvoke(this, delegate(IAsyncResult ar)
					{
						_callback.EndInvoke(ar);
					}, null);
				}
			}
		}
	}
	internal static class HttpUtility
	{
		private static Dictionary<string, char> _entities;

		private static char[] _hexChars;

		private static object _sync;

		static HttpUtility()
		{
			_hexChars = "0123456789ABCDEF".ToCharArray();
			_sync = new object();
		}

		private static Dictionary<string, char> getEntities()
		{
			lock (_sync)
			{
				if (_entities == null)
				{
					initEntities();
				}
				return _entities;
			}
		}

		private static int getNumber(char c)
		{
			return (c >= '0' && c <= '9') ? (c - 48) : ((c >= 'A' && c <= 'F') ? (c - 65 + 10) : ((c >= 'a' && c <= 'f') ? (c - 97 + 10) : (-1)));
		}

		private static int getNumber(byte[] bytes, int offset, int count)
		{
			int num = 0;
			int num2 = offset + count - 1;
			for (int i = offset; i <= num2; i++)
			{
				int number = getNumber((char)bytes[i]);
				if (number == -1)
				{
					return -1;
				}
				num = (num << 4) + number;
			}
			return num;
		}

		private static int getNumber(string s, int offset, int count)
		{
			int num = 0;
			int num2 = offset + count - 1;
			for (int i = offset; i <= num2; i++)
			{
				int number = getNumber(s[i]);
				if (number == -1)
				{
					return -1;
				}
				num = (num << 4) + number;
			}
			return num;
		}

		private static string htmlDecode(string s)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			StringBuilder stringBuilder2 = new StringBuilder();
			int num2 = 0;
			foreach (char c in s)
			{
				if (num == 0)
				{
					if (c == '&')
					{
						stringBuilder2.Append('&');
						num = 1;
					}
					else
					{
						stringBuilder.Append(c);
					}
					continue;
				}
				if (c == '&')
				{
					stringBuilder.Append(stringBuilder2.ToString());
					stringBuilder2.Length = 0;
					stringBuilder2.Append('&');
					num = 1;
					continue;
				}
				stringBuilder2.Append(c);
				switch (num)
				{
				case 1:
					if (c == ';')
					{
						stringBuilder.Append(stringBuilder2.ToString());
						stringBuilder2.Length = 0;
						num = 0;
					}
					else
					{
						num2 = 0;
						num = ((c == '#') ? 3 : 2);
					}
					break;
				case 2:
					if (c == ';')
					{
						string text = stringBuilder2.ToString();
						string key = text.Substring(1, text.Length - 2);
						Dictionary<string, char> entities = getEntities();
						if (entities.ContainsKey(key))
						{
							stringBuilder.Append(entities[key]);
						}
						else
						{
							stringBuilder.Append(text);
						}
						stringBuilder2.Length = 0;
						num = 0;
					}
					break;
				case 3:
					switch (c)
					{
					case ';':
						if (stringBuilder2.Length > 3 && num2 < 65536)
						{
							stringBuilder.Append((char)num2);
						}
						else
						{
							stringBuilder.Append(stringBuilder2.ToString());
						}
						stringBuilder2.Length = 0;
						num = 0;
						break;
					case 'x':
						num = ((stringBuilder2.Length == 3) ? 4 : 2);
						break;
					default:
						if (!isNumeric(c))
						{
							num = 2;
						}
						else
						{
							num2 = num2 * 10 + (c - 48);
						}
						break;
					}
					break;
				case 4:
					if (c == ';')
					{
						if (stringBuilder2.Length > 4 && num2 < 65536)
						{
							stringBuilder.Append((char)num2);
						}
						else
						{
							stringBuilder.Append(stringBuilder2.ToString());
						}
						stringBuilder2.Length = 0;
						num = 0;
					}
					else
					{
						int number = getNumber(c);
						if (number == -1)
						{
							num = 2;
						}
						else
						{
							num2 = (num2 << 4) + number;
						}
					}
					break;
				}
			}
			if (stringBuilder2.Length > 0)
			{
				stringBuilder.Append(stringBuilder2.ToString());
			}
			return stringBuilder.ToString();
		}

		private static string htmlEncode(string s, bool minimal)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < s.Length; i++)
			{
				char c = s[i];
				stringBuilder.Append(c switch
				{
					'>' => "&gt;", 
					'<' => "&lt;", 
					'&' => "&amp;", 
					'"' => "&quot;", 
					_ => (!minimal && c > '\u009f') ? $"&#{(int)c};" : c.ToString(), 
				});
			}
			return stringBuilder.ToString();
		}

		private static void initEntities()
		{
			_entities = new Dictionary<string, char>();
			_entities.Add("nbsp", '\u00a0');
			_entities.Add("iexcl", '¡');
			_entities.Add("cent", '¢');
			_entities.Add("pound", '£');
			_entities.Add("curren", '¤');
			_entities.Add("yen", '¥');
			_entities.Add("brvbar", '¦');
			_entities.Add("sect", '§');
			_entities.Add("uml", '\u00a8');
			_entities.Add("copy", '©');
			_entities.Add("ordf", 'ª');
			_entities.Add("laquo", '«');
			_entities.Add("not", '¬');
			_entities.Add("shy", '\u00ad');
			_entities.Add("reg", '®');
			_entities.Add("macr", '\u00af');
			_entities.Add("deg", '°');
			_entities.Add("plusmn", '±');
			_entities.Add("sup2", '²');
			_entities.Add("sup3", '³');
			_entities.Add("acute", '\u00b4');
			_entities.Add("micro", 'µ');
			_entities.Add("para", '¶');
			_entities.Add("middot", '·');
			_entities.Add("cedil", '\u00b8');
			_entities.Add("sup1", '¹');
			_entities.Add("ordm", 'º');
			_entities.Add("raquo", '»');
			_entities.Add("frac14", '¼');
			_entities.Add("frac12", '½');
			_entities.Add("frac34", '¾');
			_entities.Add("iquest", '¿');
			_entities.Add("Agrave", 'À');
			_entities.Add("Aacute", 'Á');
			_entities.Add("Acirc", 'Â');
			_entities.Add("Atilde", 'Ã');
			_entities.Add("Auml", 'Ä');
			_entities.Add("Aring", 'Å');
			_entities.Add("AElig", 'Æ');
			_entities.Add("Ccedil", 'Ç');
			_entities.Add("Egrave", 'È');
			_entities.Add("Eacute", 'É');
			_entities.Add("Ecirc", 'Ê');
			_entities.Add("Euml", 'Ë');
			_entities.Add("Igrave", 'Ì');
			_entities.Add("Iacute", 'Í');
			_entities.Add("Icirc", 'Î');
			_entities.Add("Iuml", 'Ï');
			_entities.Add("ETH", 'Ð');
			_entities.Add("Ntilde", 'Ñ');
			_entities.Add("Ograve", 'Ò');
			_entities.Add("Oacute", 'Ó');
			_entities.Add("Ocirc", 'Ô');
			_entities.Add("Otilde", 'Õ');
			_entities.Add("Ouml", 'Ö');
			_entities.Add("times", '×');
			_entities.Add("Oslash", 'Ø');
			_entities.Add("Ugrave", 'Ù');
			_entities.Add("Uacute", 'Ú');
			_entities.Add("Ucirc", 'Û');
			_entities.Add("Uuml", 'Ü');
			_entities.Add("Yacute", 'Ý');
			_entities.Add("THORN", 'Þ');
			_entities.Add("szlig", 'ß');
			_entities.Add("agrave", 'à');
			_entities.Add("aacute", 'á');
			_entities.Add("acirc", 'â');
			_entities.Add("atilde", 'ã');
			_entities.Add("auml", 'ä');
			_entities.Add("aring", 'å');
			_entities.Add("aelig", 'æ');
			_entities.Add("ccedil", 'ç');
			_entities.Add("egrave", 'è');
			_entities.Add("eacute", 'é');
			_entities.Add("ecirc", 'ê');
			_entities.Add("euml", 'ë');
			_entities.Add("igrave", 'ì');
			_entities.Add("iacute", 'í');
			_entities.Add("icirc", 'î');
			_entities.Add("iuml", 'ï');
			_entities.Add("eth", 'ð');
			_entities.Add("ntilde", 'ñ');
			_entities.Add("ograve", 'ò');
			_entities.Add("oacute", 'ó');
			_entities.Add("ocirc", 'ô');
			_entities.Add("otilde", 'õ');
			_entities.Add("ouml", 'ö');
			_entities.Add("divide", '÷');
			_entities.Add("oslash", 'ø');
			_entities.Add("ugrave", 'ù');
			_entities.Add("uacute", 'ú');
			_entities.Add("ucirc", 'û');
			_entities.Add("uuml", 'ü');
			_entities.Add("yacute", 'ý');
			_entities.Add("thorn", 'þ');
			_entities.Add("yuml", 'ÿ');
			_entities.Add("fnof", 'ƒ');
			_entities.Add("Alpha", '?');
			_entities.Add("Beta", '?');
			_entities.Add("Gamma", 'G');
			_entities.Add("Delta", '?');
			_entities.Add("Epsilon", '?');
			_entities.Add("Zeta", '?');
			_entities.Add("Eta", '?');
			_entities.Add("Theta", 'Ø');
			_entities.Add("Iota", '?');
			_entities.Add("Kappa", '?');
			_entities.Add("Lambda", '?');
			_entities.Add("Mu", '?');
			_entities.Add("Nu", '?');
			_entities.Add("Xi", '?');
			_entities.Add("Omicron", '?');
			_entities.Add("Pi", '?');
			_entities.Add("Rho", '?');
			_entities.Add("Sigma", 'S');
			_entities.Add("Tau", '?');
			_entities.Add("Upsilon", '?');
			_entities.Add("Phi", 'F');
			_entities.Add("Chi", '?');
			_entities.Add("Psi", '?');
			_entities.Add("Omega", 'O');
			_entities.Add("alpha", 'a');
			_entities.Add("beta", 'ß');
			_entities.Add("gamma", '?');
			_entities.Add("delta", 'd');
			_entities.Add("epsilon", 'e');
			_entities.Add("zeta", '?');
			_entities.Add("eta", '?');
			_entities.Add("theta", '?');
			_entities.Add("iota", '?');
			_entities.Add("kappa", '?');
			_entities.Add("lambda", '?');
			_entities.Add("mu", 'µ');
			_entities.Add("nu", '?');
			_entities.Add("xi", '?');
			_entities.Add("omicron", '?');
			_entities.Add("pi", 'p');
			_entities.Add("rho", '?');
			_entities.Add("sigmaf", '?');
			_entities.Add("sigma", 's');
			_entities.Add("tau", 't');
			_entities.Add("upsilon", '?');
			_entities.Add("phi", 'f');
			_entities.Add("chi", '?');
			_entities.Add("psi", '?');
			_entities.Add("omega", '?');
			_entities.Add("thetasym", '?');
			_entities.Add("upsih", '?');
			_entities.Add("piv", '?');
			_entities.Add("bull", '');
			_entities.Add("hellip", '.');
			_entities.Add("prime", '´');
			_entities.Add("Prime", '"');
			_entities.Add("oline", '?');
			_entities.Add("frasl", '/');
			_entities.Add("weierp", 'P');
			_entities.Add("image", 'I');
			_entities.Add("real", 'R');
			_entities.Add("trade", 'T');
			_entities.Add("alefsym", '?');
			_entities.Add("larr", '');
			_entities.Add("uarr", '');
			_entities.Add("rarr", '');
			_entities.Add("darr", '');
			_entities.Add("harr", '');
			_entities.Add("crarr", '?');
			_entities.Add("lArr", '?');
			_entities.Add("uArr", '?');
			_entities.Add("rArr", '?');
			_entities.Add("dArr", '?');
			_entities.Add("hArr", '?');
			_entities.Add("forall", '?');
			_entities.Add("part", '?');
			_entities.Add("exist", '?');
			_entities.Add("empty", 'Ø');
			_entities.Add("nabla", '?');
			_entities.Add("isin", '?');
			_entities.Add("notin", '?');
			_entities.Add("ni", '?');
			_entities.Add("prod", '?');
			_entities.Add("sum", 'S');
			_entities.Add("minus", '-');
			_entities.Add("lowast", '*');
			_entities.Add("radic", 'V');
			_entities.Add("prop", '?');
			_entities.Add("infin", '8');
			_entities.Add("ang", '?');
			_entities.Add("and", '?');
			_entities.Add("or", '?');
			_entities.Add("cap", 'n');
			_entities.Add("cup", '?');
			_entities.Add("int", '?');
			_entities.Add("there4", '?');
			_entities.Add("sim", '~');
			_entities.Add("cong", '?');
			_entities.Add("asymp", '~');
			_entities.Add("ne", '?');
			_entities.Add("equiv", '=');
			_entities.Add("le", '=');
			_entities.Add("ge", '=');
			_entities.Add("sub", '?');
			_entities.Add("sup", '?');
			_entities.Add("nsub", '?');
			_entities.Add("sube", '?');
			_entities.Add("supe", '?');
			_entities.Add("oplus", '?');
			_entities.Add("otimes", '?');
			_entities.Add("perp", '?');
			_entities.Add("sdot", '·');
			_entities.Add("lceil", '?');
			_entities.Add("rceil", '?');
			_entities.Add("lfloor", '?');
			_entities.Add("rfloor", '?');
			_entities.Add("lang", '<');
			_entities.Add("rang", '>');
			_entities.Add("loz", '?');
			_entities.Add("spades", '');
			_entities.Add("clubs", '');
			_entities.Add("hearts", '');
			_entities.Add("diams", '');
			_entities.Add("quot", '"');
			_entities.Add("amp", '&');
			_entities.Add("lt", '<');
			_entities.Add("gt", '>');
			_entities.Add("OElig", 'O');
			_entities.Add("oelig", 'o');
			_entities.Add("Scaron", 'S');
			_entities.Add("scaron", 's');
			_entities.Add("Yuml", 'Y');
			_entities.Add("circ", '^');
			_entities.Add("tilde", '\u02dc');
			_entities.Add("ensp", '\u2002');
			_entities.Add("emsp", '\u2003');
			_entities.Add("thinsp", '\u2009');
			_entities.Add("zwnj", '\u200c');
			_entities.Add("zwj", '\u200d');
			_entities.Add("lrm", '\u200e');
			_entities.Add("rlm", '\u200f');
			_entities.Add("ndash", '-');
			_entities.Add("mdash", '-');
			_entities.Add("lsquo", ''');
			_entities.Add("rsquo", ''');
			_entities.Add("sbquo", ''');
			_entities.Add("ldquo", '"');
			_entities.Add("rdquo", '"');
			_entities.Add("bdquo", '"');
			_entities.Add("dagger", '┼');
			_entities.Add("Dagger", '╬');
			_entities.Add("permil", '%');
			_entities.Add("lsaquo", '<');
			_entities.Add("rsaquo", '>');
			_entities.Add("euro", '?');
		}

		private static bool isAlphabet(char c)
		{
			return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
		}

		private static bool isNumeric(char c)
		{
			return c >= '0' && c <= '9';
		}

		private static bool isUnreserved(char c)
		{
			return c == '*' || c == '-' || c == '.' || c == '_';
		}

		private static bool isUnreservedInRfc2396(char c)
		{
			return c == '!' || c == '\'' || c == '(' || c == ')' || c == '*' || c == '-' || c == '.' || c == '_' || c == '~';
		}

		private static bool isUnreservedInRfc3986(char c)
		{
			return c == '-' || c == '.' || c == '_' || c == '~';
		}

		private static byte[] urlDecodeToBytes(byte[] bytes, int offset, int count)
		{
			using MemoryStream memoryStream = new MemoryStream();
			int num = offset + count - 1;
			for (int i = offset; i <= num; i++)
			{
				byte b = bytes[i];
				switch ((char)b)
				{
				case '%':
					if (i <= num - 2)
					{
						int number = getNumber(bytes, i + 1, 2);
						if (number != -1)
						{
							memoryStream.WriteByte((byte)number);
							i += 2;
							continue;
						}
					}
					break;
				case '+':
					memoryStream.WriteByte(32);
					continue;
				default:
					memoryStream.WriteByte(b);
					continue;
				}
				break;
			}
			memoryStream.Close();
			return memoryStream.ToArray();
		}

		private static void urlEncode(byte b, Stream output)
		{
			if (b > 31 && b < 127)
			{
				char c = (char)b;
				if (c == ' ')
				{
					output.WriteByte(43);
					return;
				}
				if (isNumeric(c))
				{
					output.WriteByte(b);
					return;
				}
				if (isAlphabet(c))
				{
					output.WriteByte(b);
					return;
				}
				if (isUnreserved(c))
				{
					output.WriteByte(b);
					return;
				}
			}
			byte[] buffer = new byte[3]
			{
				37,
				(byte)_hexChars[b >> 4],
				(byte)_hexChars[b & 0xF]
			};
			output.Write(buffer, 0, 3);
		}

		private static byte[] urlEncodeToBytes(byte[] bytes, int offset, int count)
		{
			using MemoryStream memoryStream = new MemoryStream();
			int num = offset + count - 1;
			for (int i = offset; i <= num; i++)
			{
				urlEncode(bytes[i], memoryStream);
			}
			memoryStream.Close();
			return memoryStream.ToArray();
		}

		internal static Uri CreateRequestUrl(string requestUri, string host, bool websocketRequest, bool secure)
		{
			if (requestUri == null || requestUri.Length == 0)
			{
				return null;
			}
			if (host == null || host.Length == 0)
			{
				return null;
			}
			string text = null;
			string arg = null;
			Uri result;
			bool num;
			if (requestUri.IndexOf('/') == 0)
			{
				arg = requestUri;
			}
			else
			{
				if (requestUri.MaybeUri())
				{
					if (!Uri.TryCreate(requestUri, UriKind.Absolute, out result))
					{
						return null;
					}
					text = result.Scheme;
					if (!websocketRequest)
					{
						if (!(text == "http"))
						{
							num = text == "https";
							goto IL_00c6;
						}
					}
					else if (!(text == "ws"))
					{
						num = text == "wss";
						goto IL_00c6;
					}
					goto IL_00db;
				}
				if (!(requestUri == "*"))
				{
					host = requestUri;
				}
			}
			goto IL_0109;
			IL_0109:
			if (text == null)
			{
				text = ((!websocketRequest) ? (secure ? "https" : "http") : (secure ? "wss" : "ws"));
			}
			if (host.IndexOf(':') == -1)
			{
				host = $"{host}:{(secure ? 443 : 80)}";
			}
			string uriString = $"{text}://{host}{arg}";
			Uri result2;
			return Uri.TryCreate(uriString, UriKind.Absolute, out result2) ? result2 : null;
			IL_00c6:
			if (!num)
			{
				return null;
			}
			goto IL_00db;
			IL_00db:
			host = result.Authority;
			arg = result.PathAndQuery;
			goto IL_0109;
		}

		internal static IPrincipal CreateUser(string response, AuthenticationSchemes scheme, string realm, string method, Func<IIdentity, NetworkCredential> credentialsFinder)
		{
			if (response == null || response.Length == 0)
			{
				return null;
			}
			switch (scheme)
			{
			case AuthenticationSchemes.Digest:
				if (realm == null || realm.Length == 0)
				{
					return null;
				}
				if (method == null || method.Length == 0)
				{
					return null;
				}
				break;
			default:
				return null;
			case AuthenticationSchemes.Basic:
				break;
			}
			if (credentialsFinder == null)
			{
				return null;
			}
			StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;
			if (response.IndexOf(scheme.ToString(), comparisonType) != 0)
			{
				return null;
			}
			AuthenticationResponse authenticationResponse = AuthenticationResponse.Parse(response);
			if (authenticationResponse == null)
			{
				return null;
			}
			IIdentity identity = authenticationResponse.ToIdentity();
			if (identity == null)
			{
				return null;
			}
			NetworkCredential networkCredential = null;
			try
			{
				networkCredential = credentialsFinder(identity);
			}
			catch
			{
			}
			if (networkCredential == null)
			{
				return null;
			}
			if (scheme == AuthenticationSchemes.Basic)
			{
				HttpBasicIdentity httpBasicIdentity = (HttpBasicIdentity)identity;
				return (httpBasicIdentity.Password == networkCredential.Password) ? new GenericPrincipal(identity, networkCredential.Roles) : null;
			}
			HttpDigestIdentity httpDigestIdentity = (HttpDigestIdentity)identity;
			return httpDigestIdentity.IsValid(networkCredential.Password, realm, method, null) ? new GenericPrincipal(identity, networkCredential.Roles) : null;
		}

		internal static Encoding GetEncoding(string contentType)
		{
			string value = "charset=";
			StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;
			foreach (string item in contentType.SplitHeaderValue(';'))
			{
				string text = item.Trim();
				if (!text.StartsWith(value, comparisonType))
				{
					continue;
				}
				string value2 = text.GetValue('=', unquote: true);
				if (value2 == null || value2.Length == 0)
				{
					return null;
				}
				return Encoding.GetEncoding(value2);
			}
			return null;
		}

		internal static bool TryGetEncoding(string contentType, out Encoding result)
		{
			result = null;
			try
			{
				result = GetEncoding(contentType);
			}
			catch
			{
				return false;
			}
			return result != null;
		}

		public static string HtmlAttributeEncode(string s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			return (s.Length > 0) ? htmlEncode(s, minimal: true) : s;
		}

		public static void HtmlAttributeEncode(string s, TextWriter output)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (output == null)
			{
				throw new ArgumentNullException("output");
			}
			if (s.Length != 0)
			{
				output.Write(htmlEncode(s, minimal: true));
			}
		}

		public static string HtmlDecode(string s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			return (s.Length > 0) ? htmlDecode(s) : s;
		}

		public static void HtmlDecode(string s, TextWriter output)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (output == null)
			{
				throw new ArgumentNullException("output");
			}
			if (s.Length != 0)
			{
				output.Write(htmlDecode(s));
			}
		}

		public static string HtmlEncode(string s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			return (s.Length > 0) ? htmlEncode(s, minimal: false) : s;
		}

		public static void HtmlEncode(string s, TextWriter output)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (output == null)
			{
				throw new ArgumentNullException("output");
			}
			if (s.Length != 0)
			{
				output.Write(htmlEncode(s, minimal: false));
			}
		}

		public static string UrlDecode(string s)
		{
			return UrlDecode(s, Encoding.UTF8);
		}

		public static string UrlDecode(byte[] bytes, Encoding encoding)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			return (num > 0) ? (encoding ?? Encoding.UTF8).GetString(urlDecodeToBytes(bytes, 0, num)) : string.Empty;
		}

		public static string UrlDecode(string s, Encoding encoding)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (s.Length == 0)
			{
				return s;
			}
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			return (encoding ?? Encoding.UTF8).GetString(urlDecodeToBytes(bytes, 0, bytes.Length));
		}

		public static string UrlDecode(byte[] bytes, int offset, int count, Encoding encoding)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num == 0)
			{
				if (offset != 0)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (count != 0)
				{
					throw new ArgumentOutOfRangeException("count");
				}
				return string.Empty;
			}
			if (offset < 0 || offset >= num)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0 || count > num - offset)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			return (count > 0) ? (encoding ?? Encoding.UTF8).GetString(urlDecodeToBytes(bytes, offset, count)) : string.Empty;
		}

		public static byte[] UrlDecodeToBytes(byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			return (num > 0) ? urlDecodeToBytes(bytes, 0, num) : bytes;
		}

		public static byte[] UrlDecodeToBytes(string s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (s.Length == 0)
			{
				return new byte[0];
			}
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			return urlDecodeToBytes(bytes, 0, bytes.Length);
		}

		public static byte[] UrlDecodeToBytes(byte[] bytes, int offset, int count)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num == 0)
			{
				if (offset != 0)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (count != 0)
				{
					throw new ArgumentOutOfRangeException("count");
				}
				return bytes;
			}
			if (offset < 0 || offset >= num)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0 || count > num - offset)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			return (count > 0) ? urlDecodeToBytes(bytes, offset, count) : new byte[0];
		}

		public static string UrlEncode(byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			return (num > 0) ? Encoding.ASCII.GetString(urlEncodeToBytes(bytes, 0, num)) : string.Empty;
		}

		public static string UrlEncode(string s)
		{
			return UrlEncode(s, Encoding.UTF8);
		}

		public static string UrlEncode(string s, Encoding encoding)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			int length = s.Length;
			if (length == 0)
			{
				return s;
			}
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
			byte[] bytes = new byte[encoding.GetMaxByteCount(length)];
			int bytes2 = encoding.GetBytes(s, 0, length, bytes, 0);
			return Encoding.ASCII.GetString(urlEncodeToBytes(bytes, 0, bytes2));
		}

		public static string UrlEncode(byte[] bytes, int offset, int count)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num == 0)
			{
				if (offset != 0)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (count != 0)
				{
					throw new ArgumentOutOfRangeException("count");
				}
				return string.Empty;
			}
			if (offset < 0 || offset >= num)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0 || count > num - offset)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			return (count > 0) ? Encoding.ASCII.GetString(urlEncodeToBytes(bytes, offset, count)) : string.Empty;
		}

		public static byte[] UrlEncodeToBytes(byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			return (num > 0) ? urlEncodeToBytes(bytes, 0, num) : bytes;
		}

		public static byte[] UrlEncodeToBytes(string s)
		{
			return UrlEncodeToBytes(s, Encoding.UTF8);
		}

		public static byte[] UrlEncodeToBytes(string s, Encoding encoding)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (s.Length == 0)
			{
				return new byte[0];
			}
			byte[] bytes = (encoding ?? Encoding.UTF8).GetBytes(s);
			return urlEncodeToBytes(bytes, 0, bytes.Length);
		}

		public static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num == 0)
			{
				if (offset != 0)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (count != 0)
				{
					throw new ArgumentOutOfRangeException("count");
				}
				return bytes;
			}
			if (offset < 0 || offset >= num)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0 || count > num - offset)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			return (count > 0) ? urlEncodeToBytes(bytes, offset, count) : new byte[0];
		}
	}
	internal class RequestStream : Stream
	{
		private long _bodyLeft;

		private int _count;

		private bool _disposed;

		private byte[] _initialBuffer;

		private Stream _innerStream;

		private int _offset;

		internal int Count => _count;

		internal byte[] InitialBuffer => _initialBuffer;

		internal int Offset => _offset;

		public override bool CanRead => true;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		internal RequestStream(Stream innerStream, byte[] initialBuffer, int offset, int count, long contentLength)
		{
			_innerStream = innerStream;
			_initialBuffer = initialBuffer;
			_offset = offset;
			_count = count;
			_bodyLeft = contentLength;
		}

		private int fillFromInitialBuffer(byte[] buffer, int offset, int count)
		{
			if (_bodyLeft == 0)
			{
				return -1;
			}
			if (_count == 0)
			{
				return 0;
			}
			if (count > _count)
			{
				count = _count;
			}
			if (_bodyLeft > 0 && _bodyLeft < count)
			{
				count = (int)_bodyLeft;
			}
			Buffer.BlockCopy(_initialBuffer, _offset, buffer, offset, count);
			_offset += count;
			_count -= count;
			if (_bodyLeft > 0)
			{
				_bodyLeft -= count;
			}
			return count;
		}

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			if (_disposed)
			{
				string objectName = GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				string message = "A negative value.";
				throw new ArgumentOutOfRangeException("offset", message);
			}
			if (count < 0)
			{
				string message2 = "A negative value.";
				throw new ArgumentOutOfRangeException("count", message2);
			}
			int num = buffer.Length;
			if (offset + count > num)
			{
				string message3 = "The sum of 'offset' and 'count' is greater than the length of 'buffer'.";
				throw new ArgumentException(message3);
			}
			if (count == 0)
			{
				return _innerStream.BeginRead(buffer, offset, 0, callback, state);
			}
			int num2 = fillFromInitialBuffer(buffer, offset, count);
			if (num2 != 0)
			{
				HttpStreamAsyncResult httpStreamAsyncResult = new HttpStreamAsyncResult(callback, state);
				httpStreamAsyncResult.Buffer = buffer;
				httpStreamAsyncResult.Offset = offset;
				httpStreamAsyncResult.Count = count;
				httpStreamAsyncResult.SyncRead = ((num2 > 0) ? num2 : 0);
				httpStreamAsyncResult.Complete();
				return httpStreamAsyncResult;
			}
			if (_bodyLeft > 0 && _bodyLeft < count)
			{
				count = (int)_bodyLeft;
			}
			return _innerStream.BeginRead(buffer, offset, count, callback, state);
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException();
		}

		public override void Close()
		{
			_disposed = true;
		}

		public override int EndRead(IAsyncResult asyncResult)
		{
			if (_disposed)
			{
				string objectName = GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			if (asyncResult == null)
			{
				throw new ArgumentNullException("asyncResult");
			}
			if (asyncResult is HttpStreamAsyncResult)
			{
				HttpStreamAsyncResult httpStreamAsyncResult = (HttpStreamAsyncResult)asyncResult;
				if (!httpStreamAsyncResult.IsCompleted)
				{
					httpStreamAsyncResult.AsyncWaitHandle.WaitOne();
				}
				return httpStreamAsyncResult.SyncRead;
			}
			int num = _innerStream.EndRead(asyncResult);
			if (num > 0 && _bodyLeft > 0)
			{
				_bodyLeft -= num;
			}
			return num;
		}

		public override void EndWrite(IAsyncResult asyncResult)
		{
			throw new NotSupportedException();
		}

		public override void Flush()
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (_disposed)
			{
				string objectName = GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				string message = "A negative value.";
				throw new ArgumentOutOfRangeException("offset", message);
			}
			if (count < 0)
			{
				string message2 = "A negative value.";
				throw new ArgumentOutOfRangeException("count", message2);
			}
			int num = buffer.Length;
			if (offset + count > num)
			{
				string message3 = "The sum of 'offset' and 'count' is greater than the length of 'buffer'.";
				throw new ArgumentException(message3);
			}
			if (count == 0)
			{
				return 0;
			}
			int num2 = fillFromInitialBuffer(buffer, offset, count);
			if (num2 == -1)
			{
				return 0;
			}
			if (num2 > 0)
			{
				return num2;
			}
			if (_bodyLeft > 0 && _bodyLeft < count)
			{
				count = (int)_bodyLeft;
			}
			num2 = _innerStream.Read(buffer, offset, count);
			if (num2 > 0 && _bodyLeft > 0)
			{
				_bodyLeft -= num2;
			}
			return num2;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}
	}
	internal class ResponseStream : Stream
	{
		private MemoryStream _bodyBuffer;

		private static readonly byte[] _crlf;

		private bool _disposed;

		private Stream _innerStream;

		private static readonly byte[] _lastChunk;

		private static readonly int _maxHeadersLength;

		private HttpListenerResponse _response;

		private bool _sendChunked;

		private Action<byte[], int, int> _write;

		private Action<byte[], int, int> _writeBody;

		private Action<byte[], int, int> _writeChunked;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => !_disposed;

		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		static ResponseStream()
		{
			_crlf = new byte[2] { 13, 10 };
			_lastChunk = new byte[5] { 48, 13, 10, 13, 10 };
			_maxHeadersLength = 32768;
		}

		internal ResponseStream(Stream innerStream, HttpListenerResponse response, bool ignoreWriteExceptions)
		{
			_innerStream = innerStream;
			_response = response;
			if (ignoreWriteExceptions)
			{
				_write = writeWithoutThrowingException;
				_writeChunked = writeChunkedWithoutThrowingException;
			}
			else
			{
				_write = innerStream.Write;
				_writeChunked = writeChunked;
			}
			_bodyBuffer = new MemoryStream();
		}

		private bool flush(bool closing)
		{
			if (!_response.HeadersSent)
			{
				if (!flushHeaders())
				{
					return false;
				}
				_response.HeadersSent = true;
				_sendChunked = _response.SendChunked;
				_writeBody = (_sendChunked ? _writeChunked : _write);
			}
			flushBody(closing);
			return true;
		}

		private void flushBody(bool closing)
		{
			using (_bodyBuffer)
			{
				long length = _bodyBuffer.Length;
				if (length > int.MaxValue)
				{
					_bodyBuffer.Position = 0L;
					int num = 1024;
					byte[] array = new byte[num];
					int num2 = 0;
					while (true)
					{
						num2 = _bodyBuffer.Read(array, 0, num);
						if (num2 <= 0)
						{
							break;
						}
						_writeBody(array, 0, num2);
					}
				}
				else if (length > 0)
				{
					_writeBody(_bodyBuffer.GetBuffer(), 0, (int)length);
				}
			}
			if (!closing)
			{
				_bodyBuffer = new MemoryStream();
				return;
			}
			if (_sendChunked)
			{
				_write(_lastChunk, 0, 5);
			}
			_bodyBuffer = null;
		}

		private bool flushHeaders()
		{
			if (!_response.SendChunked && _response.ContentLength64 != _bodyBuffer.Length)
			{
				return false;
			}
			string statusLine = _response.StatusLine;
			WebHeaderCollection fullHeaders = _response.FullHeaders;
			MemoryStream memoryStream = new MemoryStream();
			Encoding uTF = Encoding.UTF8;
			using (StreamWriter streamWriter = new StreamWriter(memoryStream, uTF, 256))
			{
				streamWriter.Write(statusLine);
				streamWriter.Write(fullHeaders.ToStringMultiValue(response: true));
				streamWriter.Flush();
				int num = uTF.GetPreamble().Length;
				long num2 = memoryStream.Length - num;
				if (num2 > _maxHeadersLength)
				{
					return false;
				}
				_write(memoryStream.GetBuffer(), num, (int)num2);
			}
			_response.CloseConnection = fullHeaders["Connection"] == "close";
			return true;
		}

		private static byte[] getChunkSizeBytes(int size)
		{
			string s = $"{size:x}\r\n";
			return Encoding.ASCII.GetBytes(s);
		}

		private void writeChunked(byte[] buffer, int offset, int count)
		{
			byte[] chunkSizeBytes = getChunkSizeBytes(count);
			_innerStream.Write(chunkSizeBytes, 0, chunkSizeBytes.Length);
			_innerStream.Write(buffer, offset, count);
			_innerStream.Write(_crlf, 0, 2);
		}

		private void writeChunkedWithoutThrowingException(byte[] buffer, int offset, int count)
		{
			try
			{
				writeChunked(buffer, offset, count);
			}
			catch
			{
			}
		}

		private void writeWithoutThrowingException(byte[] buffer, int offset, int count)
		{
			try
			{
				_innerStream.Write(buffer, offset, count);
			}
			catch
			{
			}
		}

		internal void Close(bool force)
		{
			if (_disposed)
			{
				return;
			}
			_disposed = true;
			if (!force)
			{
				if (flush(closing: true))
				{
					_response.Close();
					_response = null;
					_innerStream = null;
					return;
				}
				_response.CloseConnection = true;
			}
			if (_sendChunked)
			{
				_write(_lastChunk, 0, 5);
			}
			_bodyBuffer.Dispose();
			_response.Abort();
			_bodyBuffer = null;
			_response = null;
			_innerStream = null;
		}

		internal void InternalWrite(byte[] buffer, int offset, int count)
		{
			_write(buffer, offset, count);
		}

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException();
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			if (_disposed)
			{
				string objectName = GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			return _bodyBuffer.BeginWrite(buffer, offset, count, callback, state);
		}

		public override void Close()
		{
			Close(force: false);
		}

		protected override void Dispose(bool disposing)
		{
			Close(!disposing);
		}

		public override int EndRead(IAsyncResult asyncResult)
		{
			throw new NotSupportedException();
		}

		public override void EndWrite(IAsyncResult asyncResult)
		{
			if (_disposed)
			{
				string objectName = GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			_bodyBuffer.EndWrite(asyncResult);
		}

		public override void Flush()
		{
			if (!_disposed && (_sendChunked || _response.SendChunked))
			{
				flush(closing: false);
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (_disposed)
			{
				string objectName = GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			_bodyBuffer.Write(buffer, offset, count);
		}
	}
	[Serializable]
	[ComVisible(true)]
	public class WebHeaderCollection : NameValueCollection, ISerializable
	{
		private static readonly Dictionary<string, HttpHeaderInfo> _headers;

		private bool _internallyUsed;

		private HttpHeaderType _state;

		internal HttpHeaderType State => _state;

		public override string[] AllKeys => base.AllKeys;

		public override int Count => base.Count;

		public string this[HttpRequestHeader header]
		{
			get
			{
				string key = header.ToString();
				string headerName = getHeaderName(key);
				return Get(headerName);
			}
			set
			{
				Add(header, value);
			}
		}

		public string this[HttpResponseHeader header]
		{
			get
			{
				string key = header.ToString();
				string headerName = getHeaderName(key);
				return Get(headerName);
			}
			set
			{
				Add(header, value);
			}
		}

		public override KeysCollection Keys => base.Keys;

		static WebHeaderCollection()
		{
			_headers = new Dictionary<string, HttpHeaderInfo>(StringComparer.InvariantCultureIgnoreCase)
			{
				{
					"Accept",
					new HttpHeaderInfo("Accept", HttpHeaderType.Request | HttpHeaderType.Restricted | HttpHeaderType.MultiValue)
				},
				{
					"AcceptCharset",
					new HttpHeaderInfo("Accept-Charset", HttpHeaderType.Request | HttpHeaderType.MultiValue)
				},
				{
					"AcceptEncoding",
					new HttpHeaderInfo("Accept-Encoding", HttpHeaderType.Request | HttpHeaderType.MultiValue)
				},
				{
					"AcceptLanguage",
					new HttpHeaderInfo("Accept-Language", HttpHeaderType.Request | HttpHeaderType.MultiValue)
				},
				{
					"AcceptRanges",
					new HttpHeaderInfo("Accept-Ranges", HttpHeaderType.Response | HttpHeaderType.MultiValue)
				},
				{
					"Age",
					new HttpHeaderInfo("Age", HttpHeaderType.Response)
				},
				{
					"Allow",
					new HttpHeaderInfo("Allow", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
				},
				{
					"Authorization",
					new HttpHeaderInfo("Authorization", HttpHeaderType.Request | HttpHeaderType.MultiValue)
				},
				{
					"CacheControl",
					new HttpHeaderInfo("Cache-Control", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
				},
				{
					"Connection",
					new HttpHeaderInfo("Connection", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted | HttpHeaderType.MultiValue)
				},
				{
					"ContentEncoding",
					new HttpHeaderInfo("Content-Encoding", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
				},
				{
					"ContentLanguage",
					new HttpHeaderInfo("Content-Language", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
				},
				{
					"ContentLength",
					new HttpHeaderInfo("Content-Length", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted)
				},
				{
					"ContentLocation",
					new HttpHeaderInfo("Content-Location", HttpHeaderType.Request | HttpHeaderType.Response)
				},
				{
					"ContentMd5",
					new HttpHeaderInfo("Content-MD5", HttpHeaderType.Request | HttpHeaderType.Response)
				},
				{
					"ContentRange",
					new HttpHeaderInfo("Content-Range", HttpHeaderType.Request | HttpHeaderType.Response)
				},
				{
					"ContentType",
					new HttpHeaderInfo("Content-Type", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted)
				},
				{
					"Cookie",
					new HttpHeaderInfo("Cookie", HttpHeaderType.Request)
				},
				{
					"Cookie2",
					new HttpHeaderInfo("Cookie2", HttpHeaderType.Request)
				},
				{
					"Date",
					new HttpHeaderInfo("Date", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted)
				},
				{
					"Expect",
					new HttpHeaderInfo("Expect", HttpHeaderType.Request | HttpHeaderType.Restricted | HttpHeaderType.MultiValue)
				},
				{
					"Expires",
					new HttpHeaderInfo("Expires", HttpHeaderType.Request | HttpHeaderType.Response)
				},
				{
					"ETag",
					new HttpHeaderInfo("ETag", HttpHeaderType.Response)
				},
				{
					"From",
					new HttpHeaderInfo("From", HttpHeaderType.Request)
				},
				{
					"Host",
					new HttpHeaderInfo("Host", HttpHeaderType.Request | HttpHeaderType.Restricted)
				},
				{
					"IfMatch",
					new HttpHeaderInfo("If-Match", HttpHeaderType.Request | HttpHeaderType.MultiValue)
				},
				{
					"IfModifiedSince",
					new HttpHeaderInfo("If-Modified-Since", HttpHeaderType.Request | HttpHeaderType.Restricted)
				},
				{
					"IfNoneMatch",
					new HttpHeaderInfo("If-None-Match", HttpHeaderType.Request | HttpHeaderType.MultiValue)
				},
				{
					"IfRange",
					new HttpHeaderInfo("If-Range", HttpHeaderType.Request)
				},
				{
					"IfUnmodifiedSince",
					new HttpHeaderInfo("If-Unmodified-Since", HttpHeaderType.Request)
				},
				{
					"KeepAlive",
					new HttpHeaderInfo("Keep-Alive", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
				},
				{
					"LastModified",
					new HttpHeaderInfo("Last-Modified", HttpHeaderType.Request | HttpHeaderType.Response)
				},
				{
					"Location",
					new HttpHeaderInfo("Location", HttpHeaderType.Response)
				},
				{
					"MaxForwards",
					new HttpHeaderInfo("Max-Forwards", HttpHeaderType.Request)
				},
				{
					"Pragma",
					new HttpHeaderInfo("Pragma", HttpHeaderType.Request | HttpHeaderType.Response)
				},
				{
					"ProxyAuthenticate",
					new HttpHeaderInfo("Proxy-Authenticate", HttpHeaderType.Response | HttpHeaderType.MultiValue)
				},
				{
					"ProxyAuthorization",
					new HttpHeaderInfo("Proxy-Authorization", HttpHeaderType.Request)
				},
				{
					"ProxyConnection",
					new HttpHeaderInfo("Proxy-Connection", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted)
				},
				{
					"Public",
					new HttpHeaderInfo("Public", HttpHeaderType.Response | HttpHeaderType.MultiValue)
				},
				{
					"Range",
					new HttpHeaderInfo("Range", HttpHeaderType.Request | HttpHeaderType.Restricted | HttpHeaderType.MultiValue)
				},
				{
					"Referer",
					new HttpHeaderInfo("Referer", HttpHeaderType.Request | HttpHeaderType.Restricted)
				},
				{
					"RetryAfter",
					new HttpHeaderInfo("Retry-After", HttpHeaderType.Response)
				},
				{
					"SecWebSocketAccept",
					new HttpHeaderInfo("Sec-WebSocket-Accept", HttpHeaderType.Response | HttpHeaderType.Restricted)
				},
				{
					"SecWebSocketExtensions",
					new HttpHeaderInfo("Sec-WebSocket-Extensions", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted | HttpHeaderType.MultiValueInRequest)
				},
				{
					"SecWebSocketKey",
					new HttpHeaderInfo("Sec-WebSocket-Key", HttpHeaderType.Request | HttpHeaderType.Restricted)
				},
				{
					"SecWebSocketProtocol",
					new HttpHeaderInfo("Sec-WebSocket-Protocol", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValueInRequest)
				},
				{
					"SecWebSocketVersion",
					new HttpHeaderInfo("Sec-WebSocket-Version", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted | HttpHeaderType.MultiValueInResponse)
				},
				{
					"Server",
					new HttpHeaderInfo("Server", HttpHeaderType.Response)
				},
				{
					"SetCookie",
					new HttpHeaderInfo("Set-Cookie", HttpHeaderType.Response | HttpHeaderType.MultiValue)
				},
				{
					"SetCookie2",
					new HttpHeaderInfo("Set-Cookie2", HttpHeaderType.Response | HttpHeaderType.MultiValue)
				},
				{
					"Te",
					new HttpHeaderInfo("TE", HttpHeaderType.Request)
				},
				{
					"Trailer",
					new HttpHeaderInfo("Trailer", HttpHeaderType.Request | HttpHeaderType.Response)
				},
				{
					"TransferEncoding",
					new HttpHeaderInfo("Transfer-Encoding", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted | HttpHeaderType.MultiValue)
				},
				{
					"Translate",
					new HttpHeaderInfo("Translate", HttpHeaderType.Request)
				},
				{
					"Upgrade",
					new HttpHeaderInfo("Upgrade", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
				},
				{
					"UserAgent",
					new HttpHeaderInfo("User-Agent", HttpHeaderType.Request | HttpHeaderType.Restricted)
				},
				{
					"Vary",
					new HttpHeaderInfo("Vary", HttpHeaderType.Response | HttpHeaderType.MultiValue)
				},
				{
					"Via",
					new HttpHeaderInfo("Via", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
				},
				{
					"Warning",
					new HttpHeaderInfo("Warning", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
				},
				{
					"WwwAuthenticate",
					new HttpHeaderInfo("WWW-Authenticate", HttpHeaderType.Response | HttpHeaderType.Restricted | HttpHeaderType.MultiValue)
				}
			};
		}

		internal WebHeaderCollection(HttpHeaderType state, bool internallyUsed)
		{
			_state = state;
			_internallyUsed = internallyUsed;
		}

		protected WebHeaderCollection(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			if (serializationInfo == null)
			{
				throw new ArgumentNullException("serializationInfo");
			}
			try
			{
				_internallyUsed = serializationInfo.GetBoolean("InternallyUsed");
				_state = (HttpHeaderType)serializationInfo.GetInt32("State");
				int @int = serializationInfo.GetInt32("Count");
				for (int i = 0; i < @int; i++)
				{
					base.Add(serializationInfo.GetString(i.ToString()), serializationInfo.GetString((@int + i).ToString()));
				}
			}
			catch (SerializationException ex)
			{
				throw new ArgumentException(ex.Message, "serializationInfo", ex);
			}
		}

		public WebHeaderCollection()
		{
		}

		private void add(string name, string value, HttpHeaderType headerType)
		{
			base.Add(name, value);
			if (_state == HttpHeaderType.Unspecified && headerType != HttpHeaderType.Unspecified)
			{
				_state = headerType;
			}
		}

		private void checkAllowed(HttpHeaderType headerType)
		{
			if (_state == HttpHeaderType.Unspecified || headerType == HttpHeaderType.Unspecified || headerType == _state)
			{
				return;
			}
			string message = "This instance does not allow the header.";
			throw new InvalidOperationException(message);
		}

		private static string checkName(string name, string paramName)
		{
			if (name == null)
			{
				string message = "The name is null.";
				throw new ArgumentNullException(paramName, message);
			}
			if (name.Length == 0)
			{
				string message2 = "The name is an empty string.";
				throw new ArgumentException(message2, paramName);
			}
			name = name.Trim();
			if (name.Length == 0)
			{
				string message3 = "The name is a string of spaces.";
				throw new ArgumentException(message3, paramName);
			}
			if (!name.IsToken())
			{
				string message4 = "The name contains an invalid character.";
				throw new ArgumentException(message4, paramName);
			}
			return name;
		}

		private void checkRestricted(string name, HttpHeaderType headerType)
		{
			if (!_internallyUsed)
			{
				bool response = headerType == HttpHeaderType.Response;
				if (isRestricted(name, response))
				{
					string message = "The header is a restricted header.";
					throw new ArgumentException(message);
				}
			}
		}

		private static string checkValue(string value, string paramName)
		{
			if (value == null)
			{
				return string.Empty;
			}
			value = value.Trim();
			int length = value.Length;
			if (length == 0)
			{
				return value;
			}
			if (length > 65535)
			{
				string message = "The length of the value is greater than 65,535 characters.";
				throw new ArgumentOutOfRangeException(paramName, message);
			}
			if (!value.IsText())
			{
				string message2 = "The value contains an invalid character.";
				throw new ArgumentException(message2, paramName);
			}
			return value;
		}

		private static HttpHeaderInfo getHeaderInfo(string name)
		{
			StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase;
			foreach (HttpHeaderInfo value in _headers.Values)
			{
				if (value.HeaderName.Equals(name, comparisonType))
				{
					return value;
				}
			}
			return null;
		}

		private static string getHeaderName(string key)
		{
			HttpHeaderInfo value;
			return _headers.TryGetValue(key, out value) ? value.HeaderName : null;
		}

		private static HttpHeaderType getHeaderType(string name)
		{
			HttpHeaderInfo headerInfo = getHeaderInfo(name);
			if (headerInfo == null)
			{
				return HttpHeaderType.Unspecified;
			}
			if (headerInfo.IsRequest)
			{
				return (!headerInfo.IsResponse) ? HttpHeaderType.Request : HttpHeaderType.Unspecified;
			}
			return headerInfo.IsResponse ? HttpHeaderType.Response : HttpHeaderType.Unspecified;
		}

		private static bool isMultiValue(string name, bool response)
		{
			return getHeaderInfo(name)?.IsMultiValue(response) ?? false;
		}

		private static bool isRestricted(string name, bool response)
		{
			return getHeaderInfo(name)?.IsRestricted(response) ?? false;
		}

		private void set(string name, string value, HttpHeaderType headerType)
		{
			base.Set(name, value);
			if (_state == HttpHeaderType.Unspecified && headerType != HttpHeaderType.Unspecified)
			{
				_state = headerType;
			}
		}

		internal void InternalRemove(string name)
		{
			base.Remove(name);
		}

		internal void InternalSet(string header, bool response)
		{
			int num = header.IndexOf(':');
			if (num == -1)
			{
				string message = "It does not contain a colon character.";
				throw new ArgumentException(message, "header");
			}
			string name = header.Substring(0, num);
			string value = ((num < header.Length - 1) ? header.Substring(num + 1) : string.Empty);
			name = checkName(name, "header");
			value = checkValue(value, "header");
			if (isMultiValue(name, response))
			{
				base.Add(name, value);
			}
			else
			{
				base.Set(name, value);
			}
		}

		internal void InternalSet(string name, string value, bool response)
		{
			value = checkValue(value, "value");
			if (isMultiValue(name, response))
			{
				base.Add(name, value);
			}
			else
			{
				base.Set(name, value);
			}
		}

		internal string ToStringMultiValue(bool response)
		{
			int count = Count;
			if (count == 0)
			{
				return "\r\n";
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				string key = GetKey(i);
				if (isMultiValue(key, response))
				{
					string[] values = GetValues(i);
					foreach (string arg in values)
					{
						stringBuilder.AppendFormat("{0}: {1}\r\n", key, arg);
					}
				}
				else
				{
					stringBuilder.AppendFormat("{0}: {1}\r\n", key, Get(i));
				}
			}
			stringBuilder.Append("\r\n");
			return stringBuilder.ToString();
		}

		protected void AddWithoutValidate(string headerName, string headerValue)
		{
			headerName = checkName(headerName, "headerName");
			headerValue = checkValue(headerValue, "headerValue");
			HttpHeaderType headerType = getHeaderType(headerName);
			checkAllowed(headerType);
			add(headerName, headerValue, headerType);
		}

		public void Add(string header)
		{
			if (header == null)
			{
				throw new ArgumentNullException("header");
			}
			int length = header.Length;
			if (length == 0)
			{
				string message = "An empty string.";
				throw new ArgumentException(message, "header");
			}
			int num = header.IndexOf(':');
			if (num == -1)
			{
				string message2 = "It does not contain a colon character.";
				throw new ArgumentException(message2, "header");
			}
			string name = header.Substring(0, num);
			string value = ((num < length - 1) ? header.Substring(num + 1) : string.Empty);
			name = checkName(name, "header");
			value = checkValue(value, "header");
			HttpHeaderType headerType = getHeaderType(name);
			checkRestricted(name, headerType);
			checkAllowed(headerType);
			add(name, value, headerType);
		}

		public void Add(HttpRequestHeader header, string value)
		{
			value = checkValue(value, "value");
			string key = header.ToString();
			string headerName = getHeaderName(key);
			checkRestricted(headerName, HttpHeaderType.Request);
			checkAllowed(HttpHeaderType.Request);
			add(headerName, value, HttpHeaderType.Request);
		}

		public void Add(HttpResponseHeader header, string value)
		{
			value = checkValue(value, "value");
			string key = header.ToString();
			string headerName = getHeaderName(key);
			checkRestricted(headerName, HttpHeaderType.Response);
			checkAllowed(HttpHeaderType.Response);
			add(headerName, value, HttpHeaderType.Response);
		}

		public override void Add(string name, string value)
		{
			name = checkName(name, "name");
			value = checkValue(value, "value");
			HttpHeaderType headerType = getHeaderType(name);
			checkRestricted(name, headerType);
			checkAllowed(headerType);
			add(name, value, headerType);
		}

		public override void Clear()
		{
			base.Clear();
			_state = HttpHeaderType.Unspecified;
		}

		public override string Get(int index)
		{
			return base.Get(index);
		}

		public override string Get(string name)
		{
			return base.Get(name);
		}

		public override IEnumerator GetEnumerator()
		{
			return base.GetEnumerator();
		}

		public override string GetKey(int index)
		{
			return base.GetKey(index);
		}

		public override string[] GetValues(int index)
		{
			string[] values = base.GetValues(index);
			return (values != null && values.Length != 0) ? values : null;
		}

		public override string[] GetValues(string name)
		{
			string[] values = base.GetValues(name);
			return (values != null && values.Length != 0) ? values : null;
		}

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			if (serializationInfo == null)
			{
				throw new ArgumentNullException("serializationInfo");
			}
			serializationInfo.AddValue("InternallyUsed", _internallyUsed);
			serializationInfo.AddValue("State", (int)_state);
			int count = Count;
			serializationInfo.AddValue("Count", count);
			for (int i = 0; i < count; i++)
			{
				serializationInfo.AddValue(i.ToString(), GetKey(i));
				serializationInfo.AddValue((count + i).ToString(), Get(i));
			}
		}

		public static bool IsRestricted(string headerName)
		{
			return IsRestricted(headerName, response: false);
		}

		public static bool IsRestricted(string headerName, bool response)
		{
			headerName = checkName(headerName, "headerName");
			return isRestricted(headerName, response);
		}

		public override void OnDeserialization(object sender)
		{
		}

		public void Remove(HttpRequestHeader header)
		{
			string key = header.ToString();
			string headerName = getHeaderName(key);
			checkRestricted(headerName, HttpHeaderType.Request);
			checkAllowed(HttpHeaderType.Request);
			base.Remove(headerName);
		}

		public void Remove(HttpResponseHeader header)
		{
			string key = header.ToString();
			string headerName = getHeaderName(key);
			checkRestricted(headerName, HttpHeaderType.Response);
			checkAllowed(HttpHeaderType.Response);
			base.Remove(headerName);
		}

		public override void Remove(string name)
		{
			name = checkName(name, "name");
			HttpHeaderType headerType = getHeaderType(name);
			checkRestricted(name, headerType);
			checkAllowed(headerType);
			base.Remove(name);
		}

		public void Set(HttpRequestHeader header, string value)
		{
			value = checkValue(value, "value");
			string key = header.ToString();
			string headerName = getHeaderName(key);
			checkRestricted(headerName, HttpHeaderType.Request);
			checkAllowed(HttpHeaderType.Request);
			set(headerName, value, HttpHeaderType.Request);
		}

		public void Set(HttpResponseHeader header, string value)
		{
			value = checkValue(value, "value");
			string key = header.ToString();
			string headerName = getHeaderName(key);
			checkRestricted(headerName, HttpHeaderType.Response);
			checkAllowed(HttpHeaderType.Response);
			set(headerName, value, HttpHeaderType.Response);
		}

		public override void Set(string name, string value)
		{
			name = checkName(name, "name");
			value = checkValue(value, "value");
			HttpHeaderType headerType = getHeaderType(name);
			checkRestricted(name, headerType);
			checkAllowed(headerType);
			set(name, value, headerType);
		}

		public byte[] ToByteArray()
		{
			return Encoding.UTF8.GetBytes(ToString());
		}

		public override string ToString()
		{
			int count = Count;
			if (count == 0)
			{
				return "\r\n";
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				stringBuilder.AppendFormat("{0}: {1}\r\n", GetKey(i), Get(i));
			}
			stringBuilder.Append("\r\n");
			return stringBuilder.ToString();
		}

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter, SerializationFormatter = true)]
		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			GetObjectData(serializationInfo, streamingContext);
		}
	}
	public class HttpVersion
	{
		public static readonly Version Version10 = new Version(1, 0);

		public static readonly Version Version11 = new Version(1, 1);
	}
	public enum HttpStatusCode
	{
		Continue = 100,
		SwitchingProtocols = 101,
		OK = 200,
		Created = 201,
		Accepted = 202,
		NonAuthoritativeInformation = 203,
		NoContent = 204,
		ResetContent = 205,
		PartialContent = 206,
		MultipleChoices = 300,
		Ambiguous = 300,
		MovedPermanently = 301,
		Moved = 301,
		Found = 302,
		Redirect = 302,
		SeeOther = 303,
		RedirectMethod = 303,
		NotModified = 304,
		UseProxy = 305,
		Unused = 306,
		TemporaryRedirect = 307,
		RedirectKeepVerb = 307,
		BadRequest = 400,
		Unauthorized = 401,
		PaymentRequired = 402,
		Forbidden = 403,
		NotFound = 404,
		MethodNotAllowed = 405,
		NotAcceptable = 406,
		ProxyAuthenticationRequired = 407,
		RequestTimeout = 408,
		Conflict = 409,
		Gone = 410,
		LengthRequired = 411,
		PreconditionFailed = 412,
		RequestEntityTooLarge = 413,
		RequestUriTooLong = 414,
		UnsupportedMediaType = 415,
		RequestedRangeNotSatisfiable = 416,
		ExpectationFailed = 417,
		InternalServerError = 500,
		NotImplemented = 501,
		BadGateway = 502,
		ServiceUnavailable = 503,
		GatewayTimeout = 504,
		HttpVersionNotSupported = 505
	}
	[Flags]
	internal enum HttpHeaderType
	{
		Unspecified = 0,
		Request = 1,
		Response = 2,
		Restricted = 4,
		MultiValue = 8,
		MultiValueInRequest = 0x10,
		MultiValueInResponse = 0x20
	}
	internal class HttpHeaderInfo
	{
		private string _headerName;

		private HttpHeaderType _headerType;

		internal bool IsMultiValueInRequest
		{
			get
			{
				HttpHeaderType httpHeaderType = _headerType & HttpHeaderType.MultiValueInRequest;
				return httpHeaderType == HttpHeaderType.MultiValueInRequest;
			}
		}

		internal bool IsMultiValueInResponse
		{
			get
			{
				HttpHeaderType httpHeaderType = _headerType & HttpHeaderType.MultiValueInResponse;
				return httpHeaderType == HttpHeaderType.MultiValueInResponse;
			}
		}

		public string HeaderName => _headerName;

		public HttpHeaderType HeaderType => _headerType;

		public bool IsRequest
		{
			get
			{
				HttpHeaderType httpHeaderType = _headerType & HttpHeaderType.Request;
				return httpHeaderType == HttpHeaderType.Request;
			}
		}

		public bool IsResponse
		{
			get
			{
				HttpHeaderType httpHeaderType = _headerType & HttpHeaderType.Response;
				return httpHeaderType == HttpHeaderType.Response;
			}
		}

		internal HttpHeaderInfo(string headerName, HttpHeaderType headerType)
		{
			_headerName = headerName;
			_headerType = headerType;
		}

		public bool IsMultiValue(bool response)
		{
			HttpHeaderType httpHeaderType = _headerType & HttpHeaderType.MultiValue;
			if (httpHeaderType != HttpHeaderType.MultiValue)
			{
				return response ? IsMultiValueInResponse : IsMultiValueInRequest;
			}
			return response ? IsResponse : IsRequest;
		}

		public bool IsRestricted(bool response)
		{
			HttpHeaderType httpHeaderType = _headerType & HttpHeaderType.Restricted;
			if (httpHeaderType != HttpHeaderType.Restricted)
			{
				return false;
			}
			return response ? IsResponse : IsRequest;
		}
	}
	public class HttpBasicIdentity : GenericIdentity
	{
		private string _password;

		public virtual string Password => _password;

		internal HttpBasicIdentity(string username, string password)
			: base(username, "Basic")
		{
			_password = password;
		}
	}
	public class HttpDigestIdentity : GenericIdentity
	{
		private NameValueCollection _parameters;

		public string Algorithm => _parameters["algorithm"];

		public string Cnonce => _parameters["cnonce"];

		public string Nc => _parameters["nc"];

		public string Nonce => _parameters["nonce"];

		public string Opaque => _parameters["opaque"];

		public string Qop => _parameters["qop"];

		public string Realm => _parameters["realm"];

		public string Response => _parameters["response"];

		public string Uri => _parameters["uri"];

		internal HttpDigestIdentity(NameValueCollection parameters)
			: base(parameters["username"], "Digest")
		{
			_parameters = parameters;
		}

		internal bool IsValid(string password, string realm, string method, string entity)
		{
			NameValueCollection nameValueCollection = new NameValueCollection(_parameters);
			nameValueCollection["password"] = password;
			nameValueCollection["realm"] = realm;
			nameValueCollection["method"] = method;
			nameValueCollection["entity"] = entity;
			string text = AuthenticationResponse.CreateRequestDigest(nameValueCollection);
			return _parameters["response"] == text;
		}
	}
	public class NetworkCredential
	{
		private string _domain;

		private static readonly string[] _noRoles;

		private string _password;

		private string[] _roles;

		private string _username;

		public string Domain
		{
			get
			{
				return _domain ?? string.Empty;
			}
			internal set
			{
				_domain = value;
			}
		}

		public string Password
		{
			get
			{
				return _password ?? string.Empty;
			}
			internal set
			{
				_password = value;
			}
		}

		public string[] Roles
		{
			get
			{
				return _roles ?? _noRoles;
			}
			internal set
			{
				_roles = value;
			}
		}

		public string Username
		{
			get
			{
				return _username;
			}
			internal set
			{
				_username = value;
			}
		}

		static NetworkCredential()
		{
			_noRoles = new string[0];
		}

		public NetworkCredential(string username, string password)
			: this(username, password, (string)null, (string[])null)
		{
		}

		public NetworkCredential(string username, string password, string domain, params string[] roles)
		{
			if (username == null)
			{
				throw new ArgumentNullException("username");
			}
			if (username.Length == 0)
			{
				throw new ArgumentException("An empty string.", "username");
			}
			_username = username;
			_password = password;
			_domain = domain;
			_roles = roles;
		}
	}
	internal enum InputState
	{
		RequestLine,
		Headers
	}
	internal enum LineState
	{
		None,
		Cr,
		Lf
	}
	internal class ReadBufferState
	{
		private HttpStreamAsyncResult _asyncResult;

		private byte[] _buffer;

		private int _count;

		private int _initialCount;

		private int _offset;

		public HttpStreamAsyncResult AsyncResult
		{
			get
			{
				return _asyncResult;
			}
			set
			{
				_asyncResult = value;
			}
		}

		public byte[] Buffer
		{
			get
			{
				return _buffer;
			}
			set
			{
				_buffer = value;
			}
		}

		public int Count
		{
			get
			{
				return _count;
			}
			set
			{
				_count = value;
			}
		}

		public int InitialCount
		{
			get
			{
				return _initialCount;
			}
			set
			{
				_initialCount = value;
			}
		}

		public int Offset
		{
			get
			{
				return _offset;
			}
			set
			{
				_offset = value;
			}
		}

		public ReadBufferState(byte[] buffer, int offset, int count, HttpStreamAsyncResult asyncResult)
		{
			_buffer = buffer;
			_offset = offset;
			_count = count;
			_asyncResult = asyncResult;
			_initialCount = count;
		}
	}
	internal class Chunk
	{
		private byte[] _data;

		private int _offset;

		public int ReadLeft => _data.Length - _offset;

		public Chunk(byte[] data)
		{
			_data = data;
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			int num = _data.Length - _offset;
			if (num == 0)
			{
				return 0;
			}
			if (count > num)
			{
				count = num;
			}
			Buffer.BlockCopy(_data, _offset, buffer, offset, count);
			_offset += count;
			return count;
		}
	}
	internal enum InputChunkState
	{
		None,
		Data,
		DataEnded,
		Trailer,
		End
	}
	internal class ChunkedRequestStream : RequestStream
	{
		private static readonly int _bufferLength;

		private HttpListenerContext _context;

		private ChunkStream _decoder;

		private bool _disposed;

		private bool _noMoreData;

		internal bool HasRemainingBuffer => _decoder.Count + base.Count > 0;

		internal byte[] RemainingBuffer
		{
			get
			{
				using MemoryStream memoryStream = new MemoryStream();
				int count = _decoder.Count;
				if (count > 0)
				{
					memoryStream.Write(_decoder.EndBuffer, _decoder.Offset, count);
				}
				count = base.Count;
				if (count > 0)
				{
					memoryStream.Write(base.InitialBuffer, base.Offset, count);
				}
				memoryStream.Close();
				return memoryStream.ToArray();
			}
		}

		static ChunkedRequestStream()
		{
			_bufferLength = 8192;
		}

		internal ChunkedRequestStream(Stream innerStream, byte[] initialBuffer, int offset, int count, HttpListenerContext context)
			: base(innerStream, initialBuffer, offset, count, -1L)
		{
			_context = context;
			_decoder = new ChunkStream((WebHeaderCollection)context.Request.Headers);
		}

		private void onRead(IAsyncResult asyncResult)
		{
			ReadBufferState readBufferState = (ReadBufferState)asyncResult.AsyncState;
			HttpStreamAsyncResult asyncResult2 = readBufferState.AsyncResult;
			try
			{
				int count = base.EndRead(asyncResult);
				_decoder.Write(asyncResult2.Buffer, asyncResult2.Offset, count);
				count = _decoder.Read(readBufferState.Buffer, readBufferState.Offset, readBufferState.Count);
				readBufferState.Offset += count;
				readBufferState.Count -= count;
				if (readBufferState.Count == 0 || !_decoder.WantsMore || count == 0)
				{
					_noMoreData = !_decoder.WantsMore && count == 0;
					asyncResult2.Count = readBufferState.InitialCount - readBufferState.Count;
					asyncResult2.Complete();
				}
				else
				{
					base.BeginRead(asyncResult2.Buffer, asyncResult2.Offset, asyncResult2.Count, (AsyncCallback)onRead, (object)readBufferState);
				}
			}
			catch (Exception exception)
			{
				_context.ErrorMessage = "I/O operation aborted";
				_context.SendError();
				asyncResult2.Complete(exception);
			}
		}

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			if (_disposed)
			{
				string objectName = GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				string message = "A negative value.";
				throw new ArgumentOutOfRangeException("offset", message);
			}
			if (count < 0)
			{
				string message2 = "A negative value.";
				throw new ArgumentOutOfRangeException("count", message2);
			}
			int num = buffer.Length;
			if (offset + count > num)
			{
				string message3 = "The sum of 'offset' and 'count' is greater than the length of 'buffer'.";
				throw new ArgumentException(message3);
			}
			HttpStreamAsyncResult httpStreamAsyncResult = new HttpStreamAsyncResult(callback, state);
			if (_noMoreData)
			{
				httpStreamAsyncResult.Complete();
				return httpStreamAsyncResult;
			}
			int num2 = _decoder.Read(buffer, offset, count);
			offset += num2;
			count -= num2;
			if (count == 0)
			{
				httpStreamAsyncResult.Count = num2;
				httpStreamAsyncResult.Complete();
				return httpStreamAsyncResult;
			}
			if (!_decoder.WantsMore)
			{
				_noMoreData = num2 == 0;
				httpStreamAsyncResult.Count = num2;
				httpStreamAsyncResult.Complete();
				return httpStreamAsyncResult;
			}
			httpStreamAsyncResult.Buffer = new byte[_bufferLength];
			httpStreamAsyncResult.Offset = 0;
			httpStreamAsyncResult.Count = _bufferLength;
			ReadBufferState readBufferState = new ReadBufferState(buffer, offset, count, httpStreamAsyncResult);
			readBufferState.InitialCount += num2;
			base.BeginRead(httpStreamAsyncResult.Buffer, httpStreamAsyncResult.Offset, httpStreamAsyncResult.Count, (AsyncCallback)onRead, (object)readBufferState);
			return httpStreamAsyncResult;
		}

		public override void Close()
		{
			if (!_disposed)
			{
				base.Close();
				_disposed = true;
			}
		}

		public override int EndRead(IAsyncResult asyncResult)
		{
			if (_disposed)
			{
				string objectName = GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			if (asyncResult == null)
			{
				throw new ArgumentNullException("asyncResult");
			}
			if (!(asyncResult is HttpStreamAsyncResult httpStreamAsyncResult))
			{
				string message = "A wrong IAsyncResult instance.";
				throw new ArgumentException(message, "asyncResult");
			}
			if (!httpStreamAsyncResult.IsCompleted)
			{
				httpStreamAsyncResult.AsyncWaitHandle.WaitOne();
			}
			if (httpStreamAsyncResult.HasException)
			{
				string message2 = "The I/O operation has been aborted.";
				throw new HttpListenerException(995, message2);
			}
			return httpStreamAsyncResult.Count;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			IAsyncResult asyncResult = BeginRead(buffer, offset, count, null, null);
			return EndRead(asyncResult);
		}
	}
	internal sealed class QueryStringCollection : NameValueCollection
	{
		public QueryStringCollection()
		{
		}

		public QueryStringCollection(int capacity)
			: base(capacity)
		{
		}

		private static string urlDecode(string s, Encoding encoding)
		{
			return (s.IndexOfAny(new char[2] { '%', '+' }) > -1) ? HttpUtility.UrlDecode(s, encoding) : s;
		}

		public static QueryStringCollection Parse(string query)
		{
			return Parse(query, Encoding.UTF8);
		}

		public static QueryStringCollection Parse(string query, Encoding encoding)
		{
			if (query == null)
			{
				return new QueryStringCollection(1);
			}
			if (query.Length == 0)
			{
				return new QueryStringCollection(1);
			}
			if (query == "?")
			{
				return new QueryStringCollection(1);
			}
			if (query[0] == '?')
			{
				query = query.Substring(1);
			}
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
			QueryStringCollection queryStringCollection = new QueryStringCollection();
			string[] array = query.Split(new char[1] { '&' });
			string[] array2 = array;
			foreach (string text in array2)
			{
				int length = text.Length;
				if (length != 0 && !(text == "="))
				{
					int num = text.IndexOf('=');
					if (num < 0)
					{
						queryStringCollection.Add(null, urlDecode(text, encoding));
						continue;
					}
					if (num == 0)
					{
						queryStringCollection.Add(null, urlDecode(text.Substring(1), encoding));
						continue;
					}
					string name = urlDecode(text.Substring(0, num), encoding);
					int num2 = num + 1;
					string value = ((num2 < length) ? urlDecode(text.Substring(num2), encoding) : string.Empty);
					queryStringCollection.Add(name, value);
				}
			}
			return queryStringCollection;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] allKeys = AllKeys;
			foreach (string text in allKeys)
			{
				stringBuilder.AppendFormat("{0}={1}&", text, base[text]);
			}
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Length--;
			}
			return stringBuilder.ToString();
		}
	}
	internal class AuthenticationChallenge : AuthenticationBase
	{
		public string Domain => Parameters["domain"];

		public string Stale => Parameters["stale"];

		private AuthenticationChallenge(AuthenticationSchemes scheme, NameValueCollection parameters)
			: base(scheme, parameters)
		{
		}

		internal AuthenticationChallenge(AuthenticationSchemes scheme, string realm)
			: base(scheme, new NameValueCollection())
		{
			Parameters["realm"] = realm;
			if (scheme == AuthenticationSchemes.Digest)
			{
				Parameters["nonce"] = AuthenticationBase.CreateNonceValue();
				Parameters["algorithm"] = "MD5";
				Parameters["qop"] = "auth";
			}
		}

		internal static AuthenticationChallenge CreateBasicChallenge(string realm)
		{
			return new AuthenticationChallenge(AuthenticationSchemes.Basic, realm);
		}

		internal static AuthenticationChallenge CreateDigestChallenge(string realm)
		{
			return new AuthenticationChallenge(AuthenticationSchemes.Digest, realm);
		}

		internal static AuthenticationChallenge Parse(string value)
		{
			string[] array = value.Split(new char[1] { ' ' }, 2);
			if (array.Length != 2)
			{
				return null;
			}
			string text = array[0].ToLower();
			return (text == "basic") ? new AuthenticationChallenge(AuthenticationSchemes.Basic, AuthenticationBase.ParseParameters(array[1])) : ((text == "digest") ? new AuthenticationChallenge(AuthenticationSchemes.Digest, AuthenticationBase.ParseParameters(array[1])) : null);
		}

		internal override string ToBasicString()
		{
			return string.Format("Basic realm=\"{0}\"", Parameters["realm"]);
		}

		internal override string ToDigestString()
		{
			StringBuilder stringBuilder = new StringBuilder(128);
			string text = Parameters["domain"];
			if (text != null)
			{
				stringBuilder.AppendFormat("Digest realm=\"{0}\", domain=\"{1}\", nonce=\"{2}\"", Parameters["realm"], text, Parameters["nonce"]);
			}
			else
			{
				stringBuilder.AppendFormat("Digest realm=\"{0}\", nonce=\"{1}\"", Parameters["realm"], Parameters["nonce"]);
			}
			string text2 = Parameters["opaque"];
			if (text2 != null)
			{
				stringBuilder.AppendFormat(", opaque=\"{0}\"", text2);
			}
			string text3 = Parameters["stale"];
			if (text3 != null)
			{
				stringBuilder.AppendFormat(", stale={0}", text3);
			}
			string text4 = Parameters["algorithm"];
			if (text4 != null)
			{
				stringBuilder.AppendFormat(", algorithm={0}", text4);
			}
			string text5 = Parameters["qop"];
			if (text5 != null)
			{
				stringBuilder.AppendFormat(", qop=\"{0}\"", text5);
			}
			return stringBuilder.ToString();
		}
	}
	internal class AuthenticationResponse : AuthenticationBase
	{
		private uint _nonceCount;

		internal uint NonceCount => (_nonceCount < uint.MaxValue) ? _nonceCount : 0u;

		public string Cnonce => Parameters["cnonce"];

		public string Nc => Parameters["nc"];

		public string Password => Parameters["password"];

		public string Response => Parameters["response"];

		public string Uri => Parameters["uri"];

		public string UserName => Parameters["username"];

		private AuthenticationResponse(AuthenticationSchemes scheme, NameValueCollection parameters)
			: base(scheme, parameters)
		{
		}

		internal AuthenticationResponse(NetworkCredential credentials)
			: this(AuthenticationSchemes.Basic, new NameValueCollection(), credentials, 0u)
		{
		}

		internal AuthenticationResponse(AuthenticationChallenge challenge, NetworkCredential credentials, uint nonceCount)
			: this(challenge.Scheme, challenge.Parameters, credentials, nonceCount)
		{
		}

		internal AuthenticationResponse(AuthenticationSchemes scheme, NameValueCollection parameters, NetworkCredential credentials, uint nonceCount)
			: base(scheme, parameters)
		{
			Parameters["username"] = credentials.Username;
			Parameters["password"] = credentials.Password;
			Parameters["uri"] = credentials.Domain;
			_nonceCount = nonceCount;
			if (scheme == AuthenticationSchemes.Digest)
			{
				initAsDigest();
			}
		}

		private static string createA1(string username, string password, string realm)
		{
			return $"{username}:{realm}:{password}";
		}

		private static string createA1(string username, string password, string realm, string nonce, string cnonce)
		{
			return $"{hash(createA1(username, password, realm))}:{nonce}:{cnonce}";
		}

		private static string createA2(string method, string uri)
		{
			return $"{method}:{uri}";
		}

		private static string createA2(string method, string uri, string entity)
		{
			return $"{method}:{uri}:{hash(entity)}";
		}

		private static string hash(string value)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(value);
			MD5 mD = MD5.Create();
			byte[] array = mD.ComputeHash(bytes);
			StringBuilder stringBuilder = new StringBuilder(64);
			byte[] array2 = array;
			foreach (byte b in array2)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		private void initAsDigest()
		{
			string text = Parameters["qop"];
			if (text != null)
			{
				if (text.Split(new char[1] { ',' }).Contains((string qop) => qop.Trim().ToLower() == "auth"))
				{
					Parameters["qop"] = "auth";
					Parameters["cnonce"] = AuthenticationBase.CreateNonceValue();
					Parameters["nc"] = $"{++_nonceCount:x8}";
				}
				else
				{
					Parameters["qop"] = null;
				}
			}
			Parameters["method"] = "GET";
			Parameters["response"] = CreateRequestDigest(Parameters);
		}

		internal static string CreateRequestDigest(NameValueCollection parameters)
		{
			string username = parameters["username"];
			string password = parameters["password"];
			string realm = parameters["realm"];
			string text = parameters["nonce"];
			string uri = parameters["uri"];
			string text2 = parameters["algorithm"];
			string text3 = parameters["qop"];
			string text4 = parameters["cnonce"];
			string text5 = parameters["nc"];
			string method = parameters["method"];
			string value = ((text2 != null && text2.ToLower() == "md5-sess") ? createA1(username, password, realm, text, text4) : createA1(username, password, realm));
			string value2 = ((text3 != null && text3.ToLower() == "auth-int") ? createA2(method, uri, parameters["entity"]) : createA2(method, uri));
			string arg = hash(value);
			string arg2 = ((text3 != null) ? $"{text}:{text5}:{text4}:{text3}:{hash(value2)}" : $"{text}:{hash(value2)}");
			return hash($"{arg}:{arg2}");
		}

		internal static AuthenticationResponse Parse(string value)
		{
			try
			{
				string[] array = value.Split(new char[1] { ' ' }, 2);
				if (array.Length != 2)
				{
					return null;
				}
				string text = array[0].ToLower();
				return (text == "basic") ? new AuthenticationResponse(AuthenticationSchemes.Basic, ParseBasicCredentials(array[1])) : ((text == "digest") ? new AuthenticationResponse(AuthenticationSchemes.Digest, AuthenticationBase.ParseParameters(array[1])) : null);
			}
			catch
			{
			}
			return null;
		}

		internal static NameValueCollection ParseBasicCredentials(string value)
		{
			string text = Encoding.Default.GetString(Convert.FromBase64String(value));
			int num = text.IndexOf(':');
			string text2 = text.Substring(0, num);
			string value2 = ((num < text.Length - 1) ? text.Substring(num + 1) : string.Empty);
			num = text2.IndexOf('\\');
			if (num > -1)
			{
				text2 = text2.Substring(num + 1);
			}
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["username"] = text2;
			nameValueCollection["password"] = value2;
			return nameValueCollection;
		}

		internal override string ToBasicString()
		{
			string s = string.Format("{0}:{1}", Parameters["username"], Parameters["password"]);
			string text = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
			return "Basic " + text;
		}

		internal override string ToDigestString()
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			stringBuilder.AppendFormat("Digest username=\"{0}\", realm=\"{1}\", nonce=\"{2}\", uri=\"{3}\", response=\"{4}\"", Parameters["username"], Parameters["realm"], Parameters["nonce"], Parameters["uri"], Parameters["response"]);
			string text = Parameters["opaque"];
			if (text != null)
			{
				stringBuilder.AppendFormat(", opaque=\"{0}\"", text);
			}
			string text2 = Parameters["algorithm"];
			if (text2 != null)
			{
				stringBuilder.AppendFormat(", algorithm={0}", text2);
			}
			string text3 = Parameters["qop"];
			if (text3 != null)
			{
				stringBuilder.AppendFormat(", qop={0}, cnonce=\"{1}\", nc={2}", text3, Parameters["cnonce"], Parameters["nc"]);
			}
			return stringBuilder.ToString();
		}

		public IIdentity ToIdentity()
		{
			AuthenticationSchemes scheme = base.Scheme;
			IIdentity result;
			if (scheme != AuthenticationSchemes.Basic)
			{
				IIdentity identity = ((scheme == AuthenticationSchemes.Digest) ? new HttpDigestIdentity(Parameters) : null);
				result = identity;
			}
			else
			{
				IIdentity identity = new HttpBasicIdentity(Parameters["username"], Parameters["password"]);
				result = identity;
			}
			return result;
		}
	}
	internal abstract class AuthenticationBase
	{
		private AuthenticationSchemes _scheme;

		internal NameValueCollection Parameters;

		public string Algorithm => Parameters["algorithm"];

		public string Nonce => Parameters["nonce"];

		public string Opaque => Parameters["opaque"];

		public string Qop => Parameters["qop"];

		public string Realm => Parameters["realm"];

		public AuthenticationSchemes Scheme => _scheme;

		protected AuthenticationBase(AuthenticationSchemes scheme, NameValueCollection parameters)
		{
			_scheme = scheme;
			Parameters = parameters;
		}

		internal static string CreateNonceValue()
		{
			byte[] array = new byte[16];
			Random random = new Random();
			random.NextBytes(array);
			StringBuilder stringBuilder = new StringBuilder(32);
			byte[] array2 = array;
			foreach (byte b in array2)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		internal static NameValueCollection ParseParameters(string value)
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			foreach (string item in value.SplitHeaderValue(','))
			{
				int num = item.IndexOf('=');
				string name = ((num > 0) ? item.Substring(0, num).Trim() : null);
				string value2 = ((num < 0) ? item.Trim().Trim(new char[1] { '"' }) : ((num < item.Length - 1) ? item.Substring(num + 1).Trim().Trim(new char[1] { '"' }) : string.Empty));
				nameValueCollection.Add(name, value2);
			}
			return nameValueCollection;
		}

		internal abstract string ToBasicString();

		internal abstract string ToDigestString();

		public override string ToString()
		{
			return (_scheme == AuthenticationSchemes.Basic) ? ToBasicString() : ((_scheme == AuthenticationSchemes.Digest) ? ToDigestString() : string.Empty);
		}
	}
	internal sealed class HttpListenerPrefix
	{
		private string _host;

		private HttpListener _listener;

		private string _original;

		private string _path;

		private string _port;

		private string _prefix;

		private bool _secure;

		public string Host => _host;

		public bool IsSecure => _secure;

		public HttpListener Listener => _listener;

		public string Original => _original;

		public string Path => _path;

		public string Port => _port;

		internal HttpListenerPrefix(string uriPrefix, HttpListener listener)
		{
			_original = uriPrefix;
			_listener = listener;
			parse(uriPrefix);
		}

		private void parse(string uriPrefix)
		{
			if (uriPrefix.StartsWith("https"))
			{
				_secure = true;
			}
			int length = uriPrefix.Length;
			int num = uriPrefix.IndexOf(':') + 3;
			int num2 = uriPrefix.IndexOf('/', num + 1, length - num - 1);
			int num3 = uriPrefix.LastIndexOf(':', num2 - 1, num2 - num - 1);
			if (uriPrefix[num2 - 1] != ']' && num3 > num)
			{
				_host = uriPrefix.Substring(num, num3 - num);
				_port = uriPrefix.Substring(num3 + 1, num2 - num3 - 1);
			}
			else
			{
				_host = uriPrefix.Substring(num, num2 - num);
				_port = (_secure ? "443" : "80");
			}
			_path = uriPrefix.Substring(num2);
			_prefix = string.Format("{0}://{1}:{2}{3}", _secure ? "https" : "http", _host, _port, _path);
		}

		public static void CheckPrefix(string uriPrefix)
		{
			if (uriPrefix == null)
			{
				throw new ArgumentNullException("uriPrefix");
			}
			int length = uriPrefix.Length;
			if (length == 0)
			{
				string message = "An empty string.";
				throw new ArgumentException(message, "uriPrefix");
			}
			if (!uriPrefix.StartsWith("http://") && !uriPrefix.StartsWith("https://"))
			{
				string message2 = "The scheme is not 'http' or 'https'.";
				throw new ArgumentException(message2, "uriPrefix");
			}
			int num = length - 1;
			if (uriPrefix[num] != '/')
			{
				string message3 = "It ends without '/'.";
				throw new ArgumentException(message3, "uriPrefix");
			}
			int num2 = uriPrefix.IndexOf(':') + 3;
			if (num2 >= num)
			{
				string message4 = "No host is specified.";
				throw new ArgumentException(message4, "uriPrefix");
			}
			if (uriPrefix[num2] == ':')
			{
				string message5 = "No host is specified.";
				throw new ArgumentException(message5, "uriPrefix");
			}
			int num3 = uriPrefix.IndexOf('/', num2, length - num2);
			if (num3 == num2)
			{
				string message6 = "No host is specified.";
				throw new ArgumentException(message6, "uriPrefix");
			}
			if (uriPrefix[num3 - 1] == ':')
			{
				string message7 = "No port is specified.";
				throw new ArgumentException(message7, "uriPrefix");
			}
			if (num3 == num - 1)
			{
				string message8 = "No path is specified.";
				throw new ArgumentException(message8, "uriPrefix");
			}
		}

		public override bool Equals(object obj)
		{
			return obj is HttpListenerPrefix httpListenerPrefix && _prefix.Equals(httpListenerPrefix._prefix);
		}

		public override int GetHashCode()
		{
			return _prefix.GetHashCode();
		}

		public override string ToString()
		{
			return _prefix;
		}
	}
	public class ClientSslConfiguration
	{
		private bool _checkCertRevocation;

		private LocalCertificateSelectionCallback _clientCertSelectionCallback;

		private X509CertificateCollection _clientCerts;

		private SslProtocols _enabledSslProtocols;

		private RemoteCertificateValidationCallback _serverCertValidationCallback;

		private string _targetHost;

		public bool CheckCertificateRevocation
		{
			get
			{
				return _checkCertRevocation;
			}
			set
			{
				_checkCertRevocation = value;
			}
		}

		public X509CertificateCollection ClientCertificates
		{
			get
			{
				return _clientCerts;
			}
			set
			{
				_clientCerts = value;
			}
		}

		public LocalCertificateSelectionCallback ClientCertificateSelectionCallback
		{
			get
			{
				if (_clientCertSelectionCallback == null)
				{
					_clientCertSelectionCallback = defaultSelectClientCertificate;
				}
				return _clientCertSelectionCallback;
			}
			set
			{
				_clientCertSelectionCallback = value;
			}
		}

		public SslProtocols EnabledSslProtocols
		{
			get
			{
				return _enabledSslProtocols;
			}
			set
			{
				_enabledSslProtocols = value;
			}
		}

		public RemoteCertificateValidationCallback ServerCertificateValidationCallback
		{
			get
			{
				if (_serverCertValidationCallback == null)
				{
					_serverCertValidationCallback = defaultValidateServerCertificate;
				}
				return _serverCertValidationCallback;
			}
			set
			{
				_serverCertValidationCallback = value;
			}
		}

		public string TargetHost
		{
			get
			{
				return _targetHost;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length == 0)
				{
					throw new ArgumentException("An empty string.", "value");
				}
				_targetHost = value;
			}
		}

		public ClientSslConfiguration(string targetHost)
		{
			if (targetHost == null)
			{
				throw new ArgumentNullException("targetHost");
			}
			if (targetHost.Length == 0)
			{
				throw new ArgumentException("An empty string.", "targetHost");
			}
			_targetHost = targetHost;
			_enabledSslProtocols = SslProtocols.None;
		}

		public ClientSslConfiguration(ClientSslConfiguration configuration)
		{
			if (configuration == null)
			{
				throw new ArgumentNullException("configuration");
			}
			_checkCertRevocation = configuration._checkCertRevocation;
			_clientCertSelectionCallback = configuration._clientCertSelectionCallback;
			_clientCerts = configuration._clientCerts;
			_enabledSslProtocols = configuration._enabledSslProtocols;
			_serverCertValidationCallback = configuration._serverCertValidationCallback;
			_targetHost = configuration._targetHost;
		}

		private static X509Certificate defaultSelectClientCertificate(object sender, string targetHost, X509CertificateCollection clientCertificates, X509Certificate serverCertificate, string[] acceptableIssuers)
		{
			return null;
		}

		private static bool defaultValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}
	}
	public class ServerSslConfiguration
	{
		private bool _checkCertRevocation;

		private bool _clientCertRequired;

		private RemoteCertificateValidationCallback _clientCertValidationCallback;

		private SslProtocols _enabledSslProtocols;

		private X509Certificate2 _serverCert;

		public bool CheckCertificateRevocation
		{
			get
			{
				return _checkCertRevocation;
			}
			set
			{
				_checkCertRevocation = value;
			}
		}

		public bool ClientCertificateRequired
		{
			get
			{
				return _clientCertRequired;
			}
			set
			{
				_clientCertRequired = value;
			}
		}

		public RemoteCertificateValidationCallback ClientCertificateValidationCallback
		{
			get
			{
				if (_clientCertValidationCallback == null)
				{
					_clientCertValidationCallback = defaultValidateClientCertificate;
				}
				return _clientCertValidationCallback;
			}
			set
			{
				_clientCertValidationCallback = value;
			}
		}

		public SslProtocols EnabledSslProtocols
		{
			get
			{
				return _enabledSslProtocols;
			}
			set
			{
				_enabledSslProtocols = value;
			}
		}

		public X509Certificate2 ServerCertificate
		{
			get
			{
				return _serverCert;
			}
			set
			{
				_serverCert = value;
			}
		}

		public ServerSslConfiguration()
		{
			_enabledSslProtocols = SslProtocols.None;
		}

		public ServerSslConfiguration(ServerSslConfiguration configuration)
		{
			if (configuration == null)
			{
				throw new ArgumentNullException("configuration");
			}
			_checkCertRevocation = configuration._checkCertRevocation;
			_clientCertRequired = configuration._clientCertRequired;
			_clientCertValidationCallback = configuration._clientCertValidationCallback;
			_enabledSslProtocols = configuration._enabledSslProtocols;
			_serverCert = configuration._serverCert;
		}

		private static bool defaultValidateClientCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}
	}
	internal class HttpListenerAsyncResult : IAsyncResult
	{
		private AsyncCallback _callback;

		private bool _completed;

		private bool _completedSynchronously;

		private HttpListenerContext _context;

		private bool _endCalled;

		private Exception _exception;

		private object _state;

		private object _sync;

		private ManualResetEvent _waitHandle;

		internal HttpListenerContext Context
		{
			get
			{
				if (_exception != null)
				{
					throw _exception;
				}
				return _context;
			}
		}

		internal bool EndCalled
		{
			get
			{
				return _endCalled;
			}
			set
			{
				_endCalled = value;
			}
		}

		internal object SyncRoot => _sync;

		public object AsyncState => _state;

		public WaitHandle AsyncWaitHandle
		{
			get
			{
				lock (_sync)
				{
					if (_waitHandle == null)
					{
						_waitHandle = new ManualResetEvent(_completed);
					}
					return _waitHandle;
				}
			}
		}

		public bool CompletedSynchronously => _completedSynchronously;

		public bool IsCompleted
		{
			get
			{
				lock (_sync)
				{
					return _completed;
				}
			}
		}

		internal HttpListenerAsyncResult(AsyncCallback callback, object state)
		{
			_callback = callback;
			_state = state;
			_sync = new object();
		}

		private void complete()
		{
			lock (_sync)
			{
				_completed = true;
				if (_waitHandle != null)
				{
					_waitHandle.Set();
				}
			}
			if (_callback == null)
			{
				return;
			}
			ThreadPool.QueueUserWorkItem(delegate
			{
				try
				{
					_callback(this);
				}
				catch
				{
				}
			}, null);
		}

		internal void Complete(Exception exception)
		{
			_exception = exception;
			complete();
		}

		internal void Complete(HttpListenerContext context, bool completedSynchronously)
		{
			_context = context;
			_completedSynchronously = completedSynchronously;
			complete();
		}
	}
	public enum HttpRequestHeader
	{
		CacheControl,
		Connection,
		Date,
		KeepAlive,
		Pragma,
		Trailer,
		TransferEncoding,
		Upgrade,
		Via,
		Warning,
		Allow,
		ContentLength,
		ContentType,
		ContentEncoding,
		ContentLanguage,
		ContentLocation,
		ContentMd5,
		ContentRange,
		Expires,
		LastModified,
		Accept,
		AcceptCharset,
		AcceptEncoding,
		AcceptLanguage,
		Authorization,
		Cookie,
		Expect,
		From,
		Host,
		IfMatch,
		IfModifiedSince,
		IfNoneMatch,
		IfRange,
		IfUnmodifiedSince,
		MaxForwards,
		ProxyAuthorization,
		Referer,
		Range,
		Te,
		Translate,
		UserAgent,
		SecWebSocketKey,
		SecWebSocketExtensions,
		SecWebSocketProtocol,
		SecWebSocketVersion
	}
	public enum HttpResponseHeader
	{
		CacheControl,
		Connection,
		Date,
		KeepAlive,
		Pragma,
		Trailer,
		TransferEncoding,
		Upgrade,
		Via,
		Warning,
		Allow,
		ContentLength,
		ContentType,
		ContentEncoding,
		ContentLanguage,
		ContentLocation,
		ContentMd5,
		ContentRange,
		Expires,
		LastModified,
		AcceptRanges,
		Age,
		ETag,
		Location,
		ProxyAuthenticate,
		RetryAfter,
		Server,
		SetCookie,
		Vary,
		WwwAuthenticate,
		SecWebSocketExtensions,
		SecWebSocketAccept,
		SecWebSocketProtocol,
		SecWebSocketVersion
	}
}
namespace WebSocketSharp.Net.WebSockets
{
	public class HttpListenerWebSocketContext : WebSocketContext
	{
		private HttpListenerContext _context;

		private WebSocket _websocket;

		internal Logger Log => _context.Listener.Log;

		internal Stream Stream => _context.Connection.Stream;

		public override CookieCollection CookieCollection => _context.Request.Cookies;

		public override NameValueCollection Headers => _context.Request.Headers;

		public override string Host => _context.Request.UserHostName;

		public override bool IsAuthenticated => _context.Request.IsAuthenticated;

		public override bool IsLocal => _context.Request.IsLocal;

		public override bool IsSecureConnection => _context.Request.IsSecureConnection;

		public override bool IsWebSocketRequest => _context.Request.IsWebSocketRequest;

		public override string Origin => _context.Request.Headers["Origin"];

		public override NameValueCollection QueryString => _context.Request.QueryString;

		public override Uri RequestUri => _context.Request.Url;

		public override string SecWebSocketKey => _context.Request.Headers["Sec-WebSocket-Key"];

		public override IEnumerable<string> SecWebSocketProtocols
		{
			get
			{
				string val = _context.Request.Headers["Sec-WebSocket-Protocol"];
				if (val == null || val.Length == 0)
				{
					yield break;
				}
				string[] array = val.Split(new char[1] { ',' });
				foreach (string elm in array)
				{
					string protocol = elm.Trim();
					if (protocol.Length != 0)
					{
						yield return protocol;
					}
				}
			}
		}

		public override string SecWebSocketVersion => _context.Request.Headers["Sec-WebSocket-Version"];

		public override IPEndPoint ServerEndPoint => _context.Request.LocalEndPoint;

		public override IPrincipal User => _context.User;

		public override IPEndPoint UserEndPoint => _context.Request.RemoteEndPoint;

		public override WebSocket WebSocket => _websocket;

		internal HttpListenerWebSocketContext(HttpListenerContext context, string protocol)
		{
			_context = context;
			_websocket = new WebSocket(this, protocol);
		}

		internal void Close()
		{
			_context.Connection.Close(force: true);
		}

		internal void Close(HttpStatusCode code)
		{
			_context.Response.StatusCode = (int)code;
			_context.Response.Close();
		}

		public override string ToString()
		{
			return _context.Request.ToString();
		}
	}
	internal class TcpListenerWebSocketContext : WebSocketContext
	{
		private Logger _log;

		private NameValueCollection _queryString;

		private HttpRequest _request;

		private Uri _requestUri;

		private bool _secure;

		private EndPoint _serverEndPoint;

		private Stream _stream;

		private TcpClient _tcpClient;

		private IPrincipal _user;

		private EndPoint _userEndPoint;

		private WebSocket _websocket;

		internal Logger Log => _log;

		internal Stream Stream => _stream;

		public override CookieCollection CookieCollection => _request.Cookies;

		public override NameValueCollection Headers => _request.Headers;

		public override string Host => _request.Headers["Host"];

		public override bool IsAuthenticated => _user != null;

		public override bool IsLocal => UserEndPoint.Address.IsLocal();

		public override bool IsSecureConnection => _secure;

		public override bool IsWebSocketRequest => _request.IsWebSocketRequest;

		public override string Origin => _request.Headers["Origin"];

		public override NameValueCollection QueryString
		{
			get
			{
				if (_queryString == null)
				{
					Uri requestUri = RequestUri;
					_queryString = QueryStringCollection.Parse((requestUri != null) ? requestUri.Query : null, Encoding.UTF8);
				}
				return _queryString;
			}
		}

		public override Uri RequestUri
		{
			get
			{
				if (_requestUri == null)
				{
					_requestUri = HttpUtility.CreateRequestUrl(_request.RequestUri, _request.Headers["Host"], _request.IsWebSocketRequest, _secure);
				}
				return _requestUri;
			}
		}

		public override string SecWebSocketKey => _request.Headers["Sec-WebSocket-Key"];

		public override IEnumerable<string> SecWebSocketProtocols
		{
			get
			{
				string val = _request.Headers["Sec-WebSocket-Protocol"];
				if (val == null || val.Length == 0)
				{
					yield break;
				}
				string[] array = val.Split(new char[1] { ',' });
				foreach (string elm in array)
				{
					string protocol = elm.Trim();
					if (protocol.Length != 0)
					{
						yield return protocol;
					}
				}
			}
		}

		public override string SecWebSocketVersion => _request.Headers["Sec-WebSocket-Version"];

		public override IPEndPoint ServerEndPoint => (IPEndPoint)_serverEndPoint;

		public override IPrincipal User => _user;

		public override IPEndPoint UserEndPoint => (IPEndPoint)_userEndPoint;

		public override WebSocket WebSocket => _websocket;

		internal TcpListenerWebSocketContext(TcpClient tcpClient, string protocol, bool secure, ServerSslConfiguration sslConfig, Logger log)
		{
			_tcpClient = tcpClient;
			_secure = secure;
			_log = log;
			NetworkStream stream = tcpClient.GetStream();
			if (secure)
			{
				SslStream sslStream = new SslStream(stream, leaveInnerStreamOpen: false, sslConfig.ClientCertificateValidationCallback);
				sslStream.AuthenticateAsServer(sslConfig.ServerCertificate, sslConfig.ClientCertificateRequired, sslConfig.EnabledSslProtocols, sslConfig.CheckCertificateRevocation);
				_stream = sslStream;
			}
			else
			{
				_stream = stream;
			}
			Socket client = tcpClient.Client;
			_serverEndPoint = client.LocalEndPoint;
			_userEndPoint = client.RemoteEndPoint;
			_request = HttpRequest.Read(_stream, 90000);
			_websocket = new WebSocket(this, protocol);
		}

		private HttpRequest sendAuthenticationChallenge(string challenge)
		{
			HttpResponse httpResponse = HttpResponse.CreateUnauthorizedResponse(challenge);
			byte[] array = httpResponse.ToByteArray();
			_stream.Write(array, 0, array.Length);
			return HttpRequest.Read(_stream, 15000);
		}

		internal bool Authenticate(AuthenticationSchemes scheme, string realm, Func<IIdentity, NetworkCredential> credentialsFinder)
		{
			string chal = new AuthenticationChallenge(scheme, realm).ToString();
			int retry = -1;
			Func<bool> auth = null;
			auth = delegate
			{
				retry++;
				if (retry > 99)
				{
					return false;
				}
				IPrincipal principal = HttpUtility.CreateUser(_request.Headers["Authorization"], scheme, realm, _request.HttpMethod, credentialsFinder);
				if (principal != null && principal.Identity.IsAuthenticated)
				{
					_user = principal;
					return true;
				}
				_request = sendAuthenticationChallenge(chal);
				return auth();
			};
			return auth();
		}

		internal void Close()
		{
			_stream.Close();
			_tcpClient.Close();
		}

		internal void Close(HttpStatusCode code)
		{
			HttpResponse httpResponse = HttpResponse.CreateCloseResponse(code);
			byte[] array = httpResponse.ToByteArray();
			_stream.Write(array, 0, array.Length);
			_stream.Close();
			_tcpClient.Close();
		}

		public override string ToString()
		{
			return _request.ToString();
		}
	}
	public abstract class WebSocketContext
	{
		public abstract CookieCollection CookieCollection { get; }

		public abstract NameValueCollection Headers { get; }

		public abstract string Host { get; }

		public abstract bool IsAuthenticated { get; }

		public abstract bool IsLocal { get; }

		public abstract bool IsSecureConnection { get; }

		public abstract bool IsWebSocketRequest { get; }

		public abstract string Origin { get; }

		public abstract NameValueCollection QueryString { get; }

		public abstract Uri RequestUri { get; }

		public abstract string SecWebSocketKey { get; }

		public abstract IEnumerable<string> SecWebSocketProtocols { get; }

		public abstract string SecWebSocketVersion { get; }

		public abstract IPEndPoint ServerEndPoint { get; }

		public abstract IPrincipal User { get; }

		public abstract IPEndPoint UserEndPoint { get; }

		public abstract WebSocket WebSocket { get; }
	}
}
namespace WebSocketSharp.Server
{
	public class WebSocketServer
	{
		private IPAddress _address;

		private bool _allowForwardedRequest;

		private WebSocketSharp.Net.AuthenticationSchemes _authSchemes;

		private static readonly string _defaultRealm;

		private bool _dnsStyle;

		private string _hostname;

		private TcpListener _listener;

		private Logger _log;

		private int _port;

		private string _realm;

		private string _realmInUse;

		private Thread _receiveThread;

		private bool _reuseAddress;

		private bool _secure;

		private WebSocketServiceManager _services;

		private ServerSslConfiguration _sslConfig;

		private ServerSslConfiguration _sslConfigInUse;

		private volatile ServerState _state;

		private object _sync;

		private Func<IIdentity, WebSocketSharp.Net.NetworkCredential> _userCredFinder;

		public IPAddress Address => _address;

		public bool AllowForwardedRequest
		{
			get
			{
				return _allowForwardedRequest;
			}
			set
			{
				lock (_sync)
				{
					if (canSet())
					{
						_allowForwardedRequest = value;
					}
				}
			}
		}

		public WebSocketSharp.Net.AuthenticationSchemes AuthenticationSchemes
		{
			get
			{
				return _authSchemes;
			}
			set
			{
				lock (_sync)
				{
					if (canSet())
					{
						_authSchemes = value;
					}
				}
			}
		}

		public bool IsListening => _state == ServerState.Start;

		public bool IsSecure => _secure;

		public bool KeepClean
		{
			get
			{
				return _services.KeepClean;
			}
			set
			{
				_services.KeepClean = value;
			}
		}

		public Logger Log => _log;

		public int Port => _port;

		public string Realm
		{
			get
			{
				return _realm;
			}
			set
			{
				lock (_sync)
				{
					if (canSet())
					{
						_realm = value;
					}
				}
			}
		}

		public bool ReuseAddress
		{
			get
			{
				return _reuseAddress;
			}
			set
			{
				lock (_sync)
				{
					if (canSet())
					{
						_reuseAddress = value;
					}
				}
			}
		}

		public ServerSslConfiguration SslConfiguration
		{
			get
			{
				if (!_secure)
				{
					string message = "The server does not provide secure connections.";
					throw new InvalidOperationException(message);
				}
				return getSslConfiguration();
			}
		}

		public Func<IIdentity, WebSocketSharp.Net.NetworkCredential> UserCredentialsFinder
		{
			get
			{
				return _userCredFinder;
			}
			set
			{
				lock (_sync)
				{
					if (canSet())
					{
						_userCredFinder = value;
					}
				}
			}
		}

		public TimeSpan WaitTime
		{
			get
			{
				return _services.WaitTime;
			}
			set
			{
				_services.WaitTime = value;
			}
		}

		public WebSocketServiceManager WebSocketServices => _services;

		static WebSocketServer()
		{
			_defaultRealm = "SECRET AREA";
		}

		public WebSocketServer()
		{
			IPAddress any = IPAddress.Any;
			init(any.ToString(), any, 80, secure: false);
		}

		public WebSocketServer(int port)
			: this(port, port == 443)
		{
		}

		public WebSocketServer(string url)
		{
			if (url == null)
			{
				throw new ArgumentNullException("url");
			}
			if (url.Length == 0)
			{
				throw new ArgumentException("An empty string.", "url");
			}
			if (!tryCreateUri(url, out var result, out var message))
			{
				throw new ArgumentException(message, "url");
			}
			string dnsSafeHost = result.DnsSafeHost;
			IPAddress iPAddress = dnsSafeHost.ToIPAddress();
			if (iPAddress == null)
			{
				message = "The host part could not be converted to an IP address.";
				throw new ArgumentException(message, "url");
			}
			if (!iPAddress.IsLocal())
			{
				message = "The IP address of the host is not a local IP address.";
				throw new ArgumentException(message, "url");
			}
			init(dnsSafeHost, iPAddress, result.Port, result.Scheme == "wss");
		}

		public WebSocketServer(int port, bool secure)
		{
			if (!port.IsPortNumber())
			{
				string message = "It is less than 1 or greater than 65535.";
				throw new ArgumentOutOfRangeException("port", message);
			}
			IPAddress any = IPAddress.Any;
			init(any.ToString(), any, port, secure);
		}

		public WebSocketServer(IPAddress address, int port)
			: this(address, port, port == 443)
		{
		}

		public WebSocketServer(IPAddress address, int port, bool secure)
		{
			if (address == null)
			{
				throw new ArgumentNullException("address");
			}
			if (!address.IsLocal())
			{
				string message = "It is not a local IP address.";
				throw new ArgumentException(message, "address");
			}
			if (!port.IsPortNumber())
			{
				string message2 = "It is less than 1 or greater than 65535.";
				throw new ArgumentOutOfRangeException("port", message2);
			}
			init(address.ToString(), address, port, secure);
		}

		private void abort()
		{
			lock (_sync)
			{
				if (_state != ServerState.Start)
				{
					return;
				}
				_state = ServerState.ShuttingDown;
			}
			try
			{
				_listener.Stop();
			}
			catch (Exception ex)
			{
				_log.Fatal(ex.Message);
				_log.Debug(ex.ToString());
			}
			try
			{
				_services.Stop(1006, string.Empty);
			}
			catch (Exception ex2)
			{
				_log.Fatal(ex2.Message);
				_log.Debug(ex2.ToString());
			}
			_state = ServerState.Stop;
		}

		private bool authenticateClient(TcpListenerWebSocketContext context)
		{
			if (_authSchemes == WebSocketSharp.Net.AuthenticationSchemes.Anonymous)
			{
				return true;
			}
			if (_authSchemes == WebSocketSharp.Net.AuthenticationSchemes.None)
			{
				return false;
			}
			return context.Authenticate(_authSchemes, _realmInUse, _userCredFinder);
		}

		private bool canSet()
		{
			return _state == ServerState.Ready || _state == ServerState.Stop;
		}

		private bool checkHostNameForRequest(string name)
		{
			return !_dnsStyle || Uri.CheckHostName(name) != UriHostNameType.Dns || name == _hostname;
		}

		private string getRealm()
		{
			string realm = _realm;
			return (realm != null && realm.Length > 0) ? realm : _defaultRealm;
		}

		private ServerSslConfiguration getSslConfiguration()
		{
			if (_sslConfig == null)
			{
				_sslConfig = new ServerSslConfiguration();
			}
			return _sslConfig;
		}

		private void init(string hostname, IPAddress address, int port, bool secure)
		{
			_hostname = hostname;
			_address = address;
			_port = port;
			_secure = secure;
			_authSchemes = WebSocketSharp.Net.AuthenticationSchemes.Anonymous;
			_dnsStyle = Uri.CheckHostName(hostname) == UriHostNameType.Dns;
			_listener = new TcpListener(address, port);
			_log = new Logger();
			_services = new WebSocketServiceManager(_log);
			_sync = new object();
		}

		private void processRequest(TcpListenerWebSocketContext context)
		{
			if (!authenticateClient(context))
			{
				context.Close(WebSocketSharp.Net.HttpStatusCode.Forbidden);
				return;
			}
			Uri requestUri = context.RequestUri;
			if (requestUri == null)
			{
				context.Close(WebSocketSharp.Net.HttpStatusCode.BadRequest);
				return;
			}
			if (!_allowForwardedRequest)
			{
				if (requestUri.Port != _port)
				{
					context.Close(WebSocketSharp.Net.HttpStatusCode.BadRequest);
					return;
				}
				if (!checkHostNameForRequest(requestUri.DnsSafeHost))
				{
					context.Close(WebSocketSharp.Net.HttpStatusCode.NotFound);
					return;
				}
			}
			string text = requestUri.AbsolutePath;
			if (text.IndexOfAny(new char[2] { '%', '+' }) > -1)
			{
				text = HttpUtility.UrlDecode(text, Encoding.UTF8);
			}
			if (!_services.InternalTryGetServiceHost(text, out var host))
			{
				context.Close(WebSocketSharp.Net.HttpStatusCode.NotImplemented);
			}
			else
			{
				host.StartSession(context);
			}
		}

		private void receiveRequest()
		{
			while (true)
			{
				TcpClient cl = null;
				try
				{
					cl = _listener.AcceptTcpClient();
					ThreadPool.QueueUserWorkItem(delegate
					{
						try
						{
							TcpListenerWebSocketContext context = new TcpListenerWebSocketContext(cl, null, _secure, _sslConfigInUse, _log);
							processRequest(context);
						}
						catch (Exception ex4)
						{
							_log.Error(ex4.Message);
							_log.Debug(ex4.ToString());
							cl.Close();
						}
					});
				}
				catch (SocketException ex)
				{
					if (_state == ServerState.ShuttingDown)
					{
						_log.Info("The underlying listener is stopped.");
						return;
					}
					_log.Fatal(ex.Message);
					_log.Debug(ex.ToString());
					break;
				}
				catch (InvalidOperationException ex2)
				{
					if (_state == ServerState.ShuttingDown)
					{
						_log.Info("The underlying listener is stopped.");
						return;
					}
					_log.Fatal(ex2.Message);
					_log.Debug(ex2.ToString());
					break;
				}
				catch (Exception ex3)
				{
					_log.Fatal(ex3.Message);
					_log.Debug(ex3.ToString());
					if (cl != null)
					{
						cl.Close();
					}
					if (_state == ServerState.ShuttingDown)
					{
						return;
					}
					break;
				}
			}
			abort();
		}

		private void start()
		{
			lock (_sync)
			{
				if (_state == ServerState.Start || _state == ServerState.ShuttingDown)
				{
					return;
				}
				if (_secure)
				{
					ServerSslConfiguration sslConfiguration = getSslConfiguration();
					ServerSslConfiguration serverSslConfiguration = new ServerSslConfiguration(sslConfiguration);
					if (serverSslConfiguration.ServerCertificate == null)
					{
						string message = "There is no server certificate for secure connection.";
						throw new InvalidOperationException(message);
					}
					_sslConfigInUse = serverSslConfiguration;
				}
				_realmInUse = getRealm();
				_services.Start();
				try
				{
					startReceiving();
				}
				catch
				{
					_services.Stop(1011, string.Empty);
					throw;
				}
				_state = ServerState.Start;
			}
		}

		private void startReceiving()
		{
			if (_reuseAddress)
			{
				_listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, optionValue: true);
			}
			try
			{
				_listener.Start();
			}
			catch (Exception innerException)
			{
				string message = "The underlying listener has failed to start.";
				throw new InvalidOperationException(message, innerException);
			}
			ThreadStart threadStart = receiveRequest;
			_receiveThread = new Thread(threadStart);
			_receiveThread.IsBackground = true;
			_receiveThread.Start();
		}

		private void stop(ushort code, string reason)
		{
			lock (_sync)
			{
				if (_state != ServerState.Start)
				{
					return;
				}
				_state = ServerState.ShuttingDown;
			}
			try
			{
				stopReceiving(5000);
			}
			catch (Exception ex)
			{
				_log.Fatal(ex.Message);
				_log.Debug(ex.ToString());
			}
			try
			{
				_services.Stop(code, reason);
			}
			catch (Exception ex2)
			{
				_log.Fatal(ex2.Message);
				_log.Debug(ex2.ToString());
			}
			_state = ServerState.Stop;
		}

		private void stopReceiving(int millisecondsTimeout)
		{
			_listener.Stop();
			_receiveThread.Join(millisecondsTimeout);
		}

		private static bool tryCreateUri(string uriString, out Uri result, out string message)
		{
			if (!uriString.TryCreateWebSocketUri(out result, out message))
			{
				return false;
			}
			if (result.PathAndQuery != "/")
			{
				result = null;
				message = "It includes either or both path and query components.";
				return false;
			}
			return true;
		}

		public void AddWebSocketService<TBehavior>(string path) where TBehavior : WebSocketBehavior, new()
		{
			_services.AddService<TBehavior>(path, null);
		}

		public void AddWebSocketService<TBehavior>(string path, Action<TBehavior> initializer) where TBehavior : WebSocketBehavior, new()
		{
			_services.AddService(path, initializer);
		}

		public bool RemoveWebSocketService(string path)
		{
			return _services.RemoveService(path);
		}

		public void Start()
		{
			if (_state != ServerState.Start && _state != ServerState.ShuttingDown)
			{
				start();
			}
		}

		public void Stop()
		{
			if (_state == ServerState.Start)
			{
				stop(1001, string.Empty);
			}
		}
	}
	public class HttpServer
	{
		private IPAddress _address;

		private string _docRootPath;

		private string _hostname;

		private WebSocketSharp.Net.HttpListener _listener;

		private Logger _log;

		private int _port;

		private Thread _receiveThread;

		private bool _secure;

		private WebSocketServiceManager _services;

		private volatile ServerState _state;

		private object _sync;

		public IPAddress Address => _address;

		public WebSocketSharp.Net.AuthenticationSchemes AuthenticationSchemes
		{
			get
			{
				return _listener.AuthenticationSchemes;
			}
			set
			{
				lock (_sync)
				{
					if (canSet())
					{
						_listener.AuthenticationSchemes = value;
					}
				}
			}
		}

		public string DocumentRootPath
		{
			get
			{
				return _docRootPath;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length == 0)
				{
					throw new ArgumentException("An empty string.", "value");
				}
				value = value.TrimSlashOrBackslashFromEnd();
				if (value == "/")
				{
					throw new ArgumentException("An absolute root.", "value");
				}
				if (value == "\\")
				{
					throw new ArgumentException("An absolute root.", "value");
				}
				if (value.Length == 2 && value[1] == ':')
				{
					throw new ArgumentException("An absolute root.", "value");
				}
				string text = null;
				try
				{
					text = Path.GetFullPath(value);
				}
				catch (Exception innerException)
				{
					throw new ArgumentException("An invalid path string.", "value", innerException);
				}
				if (text == "/")
				{
					throw new ArgumentException("An absolute root.", "value");
				}
				text = text.TrimSlashOrBackslashFromEnd();
				if (text.Length == 2 && text[1] == ':')
				{
					throw new ArgumentException("An absolute root.", "value");
				}
				lock (_sync)
				{
					if (canSet())
					{
						_docRootPath = value;
					}
				}
			}
		}

		public bool IsListening => _state == ServerState.Start;

		public bool IsSecure => _secure;

		public bool KeepClean
		{
			get
			{
				return _services.KeepClean;
			}
			set
			{
				_services.KeepClean = value;
			}
		}

		public Logger Log => _log;

		public int Port => _port;

		public string Realm
		{
			get
			{
				return _listener.Realm;
			}
			set
			{
				lock (_sync)
				{
					if (canSet())
					{
						_listener.Realm = value;
					}
				}
			}
		}

		public bool ReuseAddress
		{
			get
			{
				return _listener.ReuseAddress;
			}
			set
			{
				lock (_sync)
				{
					if (canSet())
					{
						_listener.ReuseAddress = value;
					}
				}
			}
		}

		public ServerSslConfiguration SslConfiguration
		{
			get
			{
				if (!_secure)
				{
					string message = "The server does not provide secure connections.";
					throw new InvalidOperationException(message);
				}
				return _listener.SslConfiguration;
			}
		}

		public Func<IIdentity, WebSocketSharp.Net.NetworkCredential> UserCredentialsFinder
		{
			get
			{
				return _listener.UserCredentialsFinder;
			}
			set
			{
				lock (_sync)
				{
					if (canSet())
					{
						_listener.UserCredentialsFinder = value;
					}
				}
			}
		}

		public TimeSpan WaitTime
		{
			get
			{
				return _services.WaitTime;
			}
			set
			{
				_services.WaitTime = value;
			}
		}

		public WebSocketServiceManager WebSocketServices => _services;

		public event EventHandler<HttpRequestEventArgs> OnConnect;

		public event EventHandler<HttpRequestEventArgs> OnDelete;

		public event EventHandler<HttpRequestEventArgs> OnGet;

		public event EventHandler<HttpRequestEventArgs> OnHead;

		public event EventHandler<HttpRequestEventArgs> OnOptions;

		public event EventHandler<HttpRequestEventArgs> OnPost;

		public event EventHandler<HttpRequestEventArgs> OnPut;

		public event EventHandler<HttpRequestEventArgs> OnTrace;

		public HttpServer()
		{
			init("*", IPAddress.Any, 80, secure: false);
		}

		public HttpServer(int port)
			: this(port, port == 443)
		{
		}

		public HttpServer(string url)
		{
			if (url == null)
			{
				throw new ArgumentNullException("url");
			}
			if (url.Length == 0)
			{
				throw new ArgumentException("An empty string.", "url");
			}
			if (!tryCreateUri(url, out var result, out var message))
			{
				throw new ArgumentException(message, "url");
			}
			string dnsSafeHost = result.GetDnsSafeHost(bracketIPv6: true);
			IPAddress iPAddress = dnsSafeHost.ToIPAddress();
			if (iPAddress == null)
			{
				message = "The host part could not be converted to an IP address.";
				throw new ArgumentException(message, "url");
			}
			if (!iPAddress.IsLocal())
			{
				message = "The IP address of the host is not a local IP address.";
				throw new ArgumentException(message, "url");
			}
			init(dnsSafeHost, iPAddress, result.Port, result.Scheme == "https");
		}

		public HttpServer(int port, bool secure)
		{
			if (!port.IsPortNumber())
			{
				string message = "It is less than 1 or greater than 65535.";
				throw new ArgumentOutOfRangeException("port", message);
			}
			init("*", IPAddress.Any, port, secure);
		}

		public HttpServer(IPAddress address, int port)
			: this(address, port, port == 443)
		{
		}

		public HttpServer(IPAddress address, int port, bool secure)
		{
			if (address == null)
			{
				throw new ArgumentNullException("address");
			}
			if (!address.IsLocal())
			{
				string message = "It is not a local IP address.";
				throw new ArgumentException(message, "address");
			}
			if (!port.IsPortNumber())
			{
				string message2 = "It is less than 1 or greater than 65535.";
				throw new ArgumentOutOfRangeException("port", message2);
			}
			init(address.ToString(bracketIPv6: true), address, port, secure);
		}

		private void abort()
		{
			lock (_sync)
			{
				if (_state != ServerState.Start)
				{
					return;
				}
				_state = ServerState.ShuttingDown;
			}
			try
			{
				_services.Stop(1006, string.Empty);
			}
			catch (Exception ex)
			{
				_log.Fatal(ex.Message);
				_log.Debug(ex.ToString());
			}
			try
			{
				_listener.Abort();
			}
			catch (Exception ex2)
			{
				_log.Fatal(ex2.Message);
				_log.Debug(ex2.ToString());
			}
			_state = ServerState.Stop;
		}

		private bool canSet()
		{
			return _state == ServerState.Ready || _state == ServerState.Stop;
		}

		private bool checkCertificate(out string message)
		{
			message = null;
			bool flag = _listener.SslConfiguration.ServerCertificate != null;
			string certificateFolderPath = _listener.CertificateFolderPath;
			bool flag2 = EndPointListener.CertificateExists(_port, certificateFolderPath);
			if (!(flag || flag2))
			{
				message = "There is no server certificate for secure connection.";
				return false;
			}
			if (flag && flag2)
			{
				string message2 = "The server certificate associated with the port is used.";
				_log.Warn(message2);
			}
			return true;
		}

		private static WebSocketSharp.Net.HttpListener createListener(string hostname, int port, bool secure)
		{
			WebSocketSharp.Net.HttpListener httpListener = new WebSocketSharp.Net.HttpListener();
			string arg = (secure ? "https" : "http");
			string uriPrefix = $"{arg}://{hostname}:{port}/";
			httpListener.Prefixes.Add(uriPrefix);
			return httpListener;
		}

		private void init(string hostname, IPAddress address, int port, bool secure)
		{
			_hostname = hostname;
			_address = address;
			_port = port;
			_secure = secure;
			_docRootPath = "./Public";
			_listener = createListener(_hostname, _port, _secure);
			_log = _listener.Log;
			_services = new WebSocketServiceManager(_log);
			_sync = new object();
		}

		private void processRequest(WebSocketSharp.Net.HttpListenerContext context)
		{
			EventHandler<HttpRequestEventArgs> eventHandler = context.Request.HttpMethod switch
			{
				"TRACE" => this.OnTrace, 
				"OPTIONS" => this.OnOptions, 
				"CONNECT" => this.OnConnect, 
				"DELETE" => this.OnDelete, 
				"PUT" => this.OnPut, 
				"POST" => this.OnPost, 
				"HEAD" => this.OnHead, 
				"GET" => this.OnGet, 
				_ => null, 
			};
			if (eventHandler == null)
			{
				context.ErrorStatusCode = 501;
				context.SendError();
			}
			else
			{
				HttpRequestEventArgs e = new HttpRequestEventArgs(context, _docRootPath);
				eventHandler(this, e);
				context.Response.Close();
			}
		}

		private void processRequest(HttpListenerWebSocketContext context)
		{
			Uri requestUri = context.RequestUri;
			if (requestUri == null)
			{
				context.Close(WebSocketSharp.Net.HttpStatusCode.BadRequest);
				return;
			}
			string text = requestUri.AbsolutePath;
			if (text.IndexOfAny(new char[2] { '%', '+' }) > -1)
			{
				text = HttpUtility.UrlDecode(text, Encoding.UTF8);
			}
			if (!_services.InternalTryGetServiceHost(text, out var host))
			{
				context.Close(WebSocketSharp.Net.HttpStatusCode.NotImplemented);
			}
			else
			{
				host.StartSession(context);
			}
		}

		private void receiveRequest()
		{
			while (true)
			{
				WebSocketSharp.Net.HttpListenerContext ctx = null;
				try
				{
					ctx = _listener.GetContext();
					ThreadPool.QueueUserWorkItem(delegate
					{
						try
						{
							if (ctx.Request.IsUpgradeRequest("websocket"))
							{
								processRequest(ctx.GetWebSocketContext(null));
							}
							else
							{
								processRequest(ctx);
							}
						}
						catch (Exception ex4)
						{
							_log.Error(ex4.Message);
							_log.Debug(ex4.ToString());
							ctx.Connection.Close(force: true);
						}
					});
				}
				catch (WebSocketSharp.Net.HttpListenerException ex)
				{
					if (_state == ServerState.ShuttingDown)
					{
						_log.Info("The underlying listener is stopped.");
						return;
					}
					_log.Fatal(ex.Message);
					_log.Debug(ex.ToString());
					break;
				}
				catch (InvalidOperationException ex2)
				{
					if (_state == ServerState.ShuttingDown)
					{
						_log.Info("The underlying listener is stopped.");
						return;
					}
					_log.Fatal(ex2.Message);
					_log.Debug(ex2.ToString());
					break;
				}
				catch (Exception ex3)
				{
					_log.Fatal(ex3.Message);
					_log.Debug(ex3.ToString());
					if (ctx != null)
					{
						ctx.Connection.Close(force: true);
					}
					if (_state == ServerState.ShuttingDown)
					{
						return;
					}
					break;
				}
			}
			abort();
		}

		private void start()
		{
			lock (_sync)
			{
				if (_state != ServerState.Start && _state != ServerState.ShuttingDown)
				{
					if (_secure && !checkCertificate(out var message))
					{
						throw new InvalidOperationException(message);
					}
					_services.Start();
					try
					{
						startReceiving();
					}
					catch
					{
						_services.Stop(1011, string.Empty);
						throw;
					}
					_state = ServerState.Start;
				}
			}
		}

		private void startReceiving()
		{
			try
			{
				_listener.Start();
			}
			catch (Exception innerException)
			{
				string message = "The underlying listener has failed to start.";
				throw new InvalidOperationException(message, innerException);
			}
			ThreadStart threadStart = receiveRequest;
			_receiveThread = new Thread(threadStart);
			_receiveThread.IsBackground = true;
			_receiveThread.Start();
		}

		private void stop(ushort code, string reason)
		{
			lock (_sync)
			{
				if (_state != ServerState.Start)
				{
					return;
				}
				_state = ServerState.ShuttingDown;
			}
			try
			{
				_services.Stop(code, reason);
			}
			catch (Exception ex)
			{
				_log.Fatal(ex.Message);
				_log.Debug(ex.ToString());
			}
			try
			{
				stopReceiving(5000);
			}
			catch (Exception ex2)
			{
				_log.Fatal(ex2.Message);
				_log.Debug(ex2.ToString());
			}
			_state = ServerState.Stop;
		}

		private void stopReceiving(int millisecondsTimeout)
		{
			_listener.Stop();
			_receiveThread.Join(millisecondsTimeout);
		}

		private static bool tryCreateUri(string uriString, out Uri result, out string message)
		{
			result = null;
			message = null;
			Uri uri = uriString.ToUri();
			if (uri == null)
			{
				message = "An invalid URI string.";
				return false;
			}
			if (!uri.IsAbsoluteUri)
			{
				message = "A relative URI.";
				return false;
			}
			string scheme = uri.Scheme;
			if (!(scheme == "http") && !(scheme == "https"))
			{
				message = "The scheme part is not 'http' or 'https'.";
				return false;
			}
			if (uri.PathAndQuery != "/")
			{
				message = "It includes either or both path and query components.";
				return false;
			}
			if (uri.Fragment.Length > 0)
			{
				message = "It includes the fragment component.";
				return false;
			}
			if (uri.Port == 0)
			{
				message = "The port part is zero.";
				return false;
			}
			result = uri;
			return true;
		}

		public void AddWebSocketService<TBehavior>(string path) where TBehavior : WebSocketBehavior, new()
		{
			_services.AddService<TBehavior>(path, null);
		}

		public void AddWebSocketService<TBehavior>(string path, Action<TBehavior> initializer) where TBehavior : WebSocketBehavior, new()
		{
			_services.AddService(path, initializer);
		}

		public bool RemoveWebSocketService(string path)
		{
			return _services.RemoveService(path);
		}

		public void Start()
		{
			if (_state != ServerState.Start && _state != ServerState.ShuttingDown)
			{
				start();
			}
		}

		public void Stop()
		{
			if (_state == ServerState.Start)
			{
				stop(1001, string.Empty);
			}
		}
	}
	public abstract class WebSocketServiceHost
	{
		private Logger _log;

		private string _path;

		private WebSocketSessionManager _sessions;

		internal ServerState State => _sessions.State;

		protected Logger Log => _log;

		public bool KeepClean
		{
			get
			{
				return _sessions.KeepClean;
			}
			set
			{
				_sessions.KeepClean = value;
			}
		}

		public string Path => _path;

		public WebSocketSessionManager Sessions => _sessions;

		public abstract Type BehaviorType { get; }

		public TimeSpan WaitTime
		{
			get
			{
				return _sessions.WaitTime;
			}
			set
			{
				_sessions.WaitTime = value;
			}
		}

		protected WebSocketServiceHost(string path, Logger log)
		{
			_path = path;
			_log = log;
			_sessions = new WebSocketSessionManager(log);
		}

		internal void Start()
		{
			_sessions.Start();
		}

		internal void StartSession(WebSocketContext context)
		{
			CreateSession().Start(context, _sessions);
		}

		internal void Stop(ushort code, string reason)
		{
			_sessions.Stop(code, reason);
		}

		protected abstract WebSocketBehavior CreateSession();
	}
	public class HttpRequestEventArgs : EventArgs
	{
		private WebSocketSharp.Net.HttpListenerContext _context;

		private string _docRootPath;

		public WebSocketSharp.Net.HttpListenerRequest Request => _context.Request;

		public WebSocketSharp.Net.HttpListenerResponse Response => _context.Response;

		public IPrincipal User => _context.User;

		internal HttpRequestEventArgs(WebSocketSharp.Net.HttpListenerContext context, string documentRootPath)
		{
			_context = context;
			_docRootPath = documentRootPath;
		}

		private string createFilePath(string childPath)
		{
			childPath = childPath.TrimStart('/', '\\');
			return new StringBuilder(_docRootPath, 32).AppendFormat("/{0}", childPath).ToString().Replace('\\', '/');
		}

		private static bool tryReadFile(string path, out byte[] contents)
		{
			contents = null;
			if (!File.Exists(path))
			{
				return false;
			}
			try
			{
				contents = File.ReadAllBytes(path);
			}
			catch
			{
				return false;
			}
			return true;
		}

		public byte[] ReadFile(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			if (path.IndexOf("..") > -1)
			{
				throw new ArgumentException("It contains '..'.", "path");
			}
			path = createFilePath(path);
			tryReadFile(path, out var contents);
			return contents;
		}

		public bool TryReadFile(string path, out byte[] contents)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			if (path.IndexOf("..") > -1)
			{
				throw new ArgumentException("It contains '..'.", "path");
			}
			path = createFilePath(path);
			return tryReadFile(path, out contents);
		}
	}
	public interface IWebSocketSession
	{
		WebSocketState ConnectionState { get; }

		WebSocketContext Context { get; }

		string ID { get; }

		string Protocol { get; }

		DateTime StartTime { get; }
	}
	public class WebSocketSessionManager
	{
		private static readonly byte[] _emptyPingFrameAsBytes;

		private object _forSweep;

		private volatile bool _keepClean;

		private Logger _log;

		private Dictionary<string, IWebSocketSession> _sessions;

		private volatile ServerState _state;

		private volatile bool _sweeping;

		private System.Timers.Timer _sweepTimer;

		private object _sync;

		private TimeSpan _waitTime;

		internal ServerState State => _state;

		public IEnumerable<string> ActiveIDs
		{
			get
			{
				foreach (KeyValuePair<string, bool> res in broadping(_emptyPingFrameAsBytes))
				{
					if (res.Value)
					{
						yield return res.Key;
					}
				}
			}
		}

		public int Count
		{
			get
			{
				lock (_sync)
				{
					return _sessions.Count;
				}
			}
		}

		public IEnumerable<string> IDs
		{
			get
			{
				if (_state != ServerState.Start)
				{
					return Enumerable.Empty<string>();
				}
				lock (_sync)
				{
					if (_state != ServerState.Start)
					{
						return Enumerable.Empty<string>();
					}
					return _sessions.Keys.ToList();
				}
			}
		}

		public IEnumerable<string> InactiveIDs
		{
			get
			{
				foreach (KeyValuePair<string, bool> res in broadping(_emptyPingFrameAsBytes))
				{
					if (!res.Value)
					{
						yield return res.Key;
					}
				}
			}
		}

		public IWebSocketSession this[string id]
		{
			get
			{
				if (id == null)
				{
					throw new ArgumentNullException("id");
				}
				if (id.Length == 0)
				{
					throw new ArgumentException("An empty string.", "id");
				}
				tryGetSession(id, out var session);
				return session;
			}
		}

		public bool KeepClean
		{
			get
			{
				return _keepClean;
			}
			set
			{
				lock (_sync)
				{
					if (canSet())
					{
						_keepClean = value;
					}
				}
			}
		}

		public IEnumerable<IWebSocketSession> Sessions
		{
			get
			{
				if (_state != ServerState.Start)
				{
					return Enumerable.Empty<IWebSocketSession>();
				}
				lock (_sync)
				{
					if (_state != ServerState.Start)
					{
						return Enumerable.Empty<IWebSocketSession>();
					}
					return _sessions.Values.ToList();
				}
			}
		}

		public TimeSpan WaitTime
		{
			get
			{
				return _waitTime;
			}
			set
			{
				if (value <= TimeSpan.Zero)
				{
					string message = "It is zero or less.";
					throw new ArgumentOutOfRangeException("value", message);
				}
				lock (_sync)
				{
					if (canSet())
					{
						_waitTime = value;
					}
				}
			}
		}

		static WebSocketSessionManager()
		{
			_emptyPingFrameAsBytes = WebSocketFrame.CreatePingFrame(mask: false).ToArray();
		}

		internal WebSocketSessionManager(Logger log)
		{
			_log = log;
			_forSweep = new object();
			_keepClean = true;
			_sessions = new Dictionary<string, IWebSocketSession>();
			_state = ServerState.Ready;
			_sync = ((ICollection)_sessions).SyncRoot;
			_waitTime = TimeSpan.FromSeconds(1.0);
			setSweepTimer(60000.0);
		}

		private void broadcast(Opcode opcode, byte[] data, Action completed)
		{
			Dictionary<CompressionMethod, byte[]> dictionary = new Dictionary<CompressionMethod, byte[]>();
			try
			{
				foreach (IWebSocketSession session in Sessions)
				{
					if (_state != ServerState.Start)
					{
						_log.Error("The service is shutting down.");
						break;
					}
					session.Context.WebSocket.Send(opcode, data, dictionary);
				}
				completed?.Invoke();
			}
			catch (Exception ex)
			{
				_log.Error(ex.Message);
				_log.Debug(ex.ToString());
			}
			finally
			{
				dictionary.Clear();
			}
		}

		private void broadcast(Opcode opcode, Stream stream, Action completed)
		{
			Dictionary<CompressionMethod, Stream> dictionary = new Dictionary<CompressionMethod, Stream>();
			try
			{
				foreach (IWebSocketSession session in Sessions)
				{
					if (_state != ServerState.Start)
					{
						_log.Error("The service is shutting down.");
						break;
					}
					session.Context.WebSocket.Send(opcode, stream, dictionary);
				}
				completed?.Invoke();
			}
			catch (Exception ex)
			{
				_log.Error(ex.Message);
				_log.Debug(ex.ToString());
			}
			finally
			{
				foreach (Stream value in dictionary.Values)
				{
					value.Dispose();
				}
				dictionary.Clear();
			}
		}

		private void broadcastAsync(Opcode opcode, byte[] data, Action completed)
		{
			ThreadPool.QueueUserWorkItem(delegate
			{
				broadcast(opcode, data, completed);
			});
		}

		private void broadcastAsync(Opcode opcode, Stream stream, Action completed)
		{
			ThreadPool.QueueUserWorkItem(delegate
			{
				broadcast(opcode, stream, completed);
			});
		}

		private Dictionary<string, bool> broadping(byte[] frameAsBytes)
		{
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
			foreach (IWebSocketSession session in Sessions)
			{
				if (_state != ServerState.Start)
				{
					_log.Error("The service is shutting down.");
					break;
				}
				bool value = session.Context.WebSocket.Ping(frameAsBytes, _waitTime);
				dictionary.Add(session.ID, value);
			}
			return dictionary;
		}

		private bool canSet()
		{
			return _state == ServerState.Ready || _state == ServerState.Stop;
		}

		private static string createID()
		{
			return Guid.NewGuid().ToString("N");
		}

		private void setSweepTimer(double interval)
		{
			_sweepTimer = new System.Timers.Timer(interval);
			_sweepTimer.Elapsed += delegate
			{
				Sweep();
			};
		}

		private void stop(PayloadData payloadData, bool send)
		{
			byte[] frameAsBytes = (send ? WebSocketFrame.CreateCloseFrame(payloadData, mask: false).ToArray() : null);
			lock (_sync)
			{
				_state = ServerState.ShuttingDown;
				_sweepTimer.Enabled = false;
				foreach (IWebSocketSession item in _sessions.Values.ToList())
				{
					item.Context.WebSocket.Close(payloadData, frameAsBytes);
				}
				_state = ServerState.Stop;
			}
		}

		private bool tryGetSession(string id, out IWebSocketSession session)
		{
			session = null;
			if (_state != ServerState.Start)
			{
				return false;
			}
			lock (_sync)
			{
				if (_state != ServerState.Start)
				{
					return false;
				}
				return _sessions.TryGetValue(id, out session);
			}
		}

		internal string Add(IWebSocketSession session)
		{
			lock (_sync)
			{
				if (_state != ServerState.Start)
				{
					return null;
				}
				string text = createID();
				_sessions.Add(text, session);
				return text;
			}
		}

		internal bool Remove(string id)
		{
			lock (_sync)
			{
				return _sessions.Remove(id);
			}
		}

		internal void Start()
		{
			lock (_sync)
			{
				_sweepTimer.Enabled = _keepClean;
				_state = ServerState.Start;
			}
		}

		internal void Stop(ushort code, string reason)
		{
			if (code == 1005)
			{
				stop(PayloadData.Empty, send: true);
				return;
			}
			PayloadData payloadData = new PayloadData(code, reason);
			bool send = !code.IsReserved();
			stop(payloadData, send);
		}

		public void Broadcast(byte[] data)
		{
			if (_state != ServerState.Start)
			{
				string message = "The current state of the service is not Start.";
				throw new InvalidOperationException(message);
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (data.LongLength <= WebSocket.FragmentLength)
			{
				broadcast(Opcode.Binary, data, null);
			}
			else
			{
				broadcast(Opcode.Binary, new MemoryStream(data), null);
			}
		}

		public void Broadcast(string data)
		{
			if (_state != ServerState.Start)
			{
				string message = "The current state of the service is not Start.";
				throw new InvalidOperationException(message);
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (!data.TryGetUTF8EncodedBytes(out var bytes))
			{
				string message2 = "It could not be UTF-8-encoded.";
				throw new ArgumentException(message2, "data");
			}
			if (bytes.LongLength <= WebSocket.FragmentLength)
			{
				broadcast(Opcode.Text, bytes, null);
			}
			else
			{
				broadcast(Opcode.Text, new MemoryStream(bytes), null);
			}
		}

		public void Broadcast(Stream stream, int length)
		{
			if (_state != ServerState.Start)
			{
				string message = "The current state of the service is not Start.";
				throw new InvalidOperationException(message);
			}
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanRead)
			{
				string message2 = "It cannot be read.";
				throw new ArgumentException(message2, "stream");
			}
			if (length < 1)
			{
				string message3 = "It is less than 1.";
				throw new ArgumentException(message3, "length");
			}
			byte[] array = stream.ReadBytes(length);
			int num = array.Length;
			if (num == 0)
			{
				string message4 = "No data could be read from it.";
				throw new ArgumentException(message4, "stream");
			}
			if (num < length)
			{
				string format = "Only {0} byte(s) of data could be read from the stream.";
				string message5 = string.Format(format, num);
				_log.Warn(message5);
			}
			if (num <= WebSocket.FragmentLength)
			{
				broadcast(Opcode.Binary, array, null);
			}
			else
			{
				broadcast(Opcode.Binary, new MemoryStream(array), null);
			}
		}

		public void BroadcastAsync(byte[] data, Action completed)
		{
			if (_state != ServerState.Start)
			{
				string message = "The current state of the service is not Start.";
				throw new InvalidOperationException(message);
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (data.LongLength <= WebSocket.FragmentLength)
			{
				broadcastAsync(Opcode.Binary, data, completed);
			}
			else
			{
				broadcastAsync(Opcode.Binary, new MemoryStream(data), completed);
			}
		}

		public void BroadcastAsync(string data, Action completed)
		{
			if (_state != ServerState.Start)
			{
				string message = "The current state of the service is not Start.";
				throw new InvalidOperationException(message);
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (!data.TryGetUTF8EncodedBytes(out var bytes))
			{
				string message2 = "It could not be UTF-8-encoded.";
				throw new ArgumentException(message2, "data");
			}
			if (bytes.LongLength <= WebSocket.FragmentLength)
			{
				broadcastAsync(Opcode.Text, bytes, completed);
			}
			else
			{
				broadcastAsync(Opcode.Text, new MemoryStream(bytes), completed);
			}
		}

		public void BroadcastAsync(Stream stream, int length, Action completed)
		{
			if (_state != ServerState.Start)
			{
				string message = "The current state of the service is not Start.";
				throw new InvalidOperationException(message);
			}
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanRead)
			{
				string message2 = "It cannot be read.";
				throw new ArgumentException(message2, "stream");
			}
			if (length < 1)
			{
				string message3 = "It is less than 1.";
				throw new ArgumentException(message3, "length");
			}
			byte[] array = stream.ReadBytes(length);
			int num = array.Length;
			if (num == 0)
			{
				string message4 = "No data could be read from it.";
				throw new ArgumentException(message4, "stream");
			}
			if (num < length)
			{
				string format = "Only {0} byte(s) of data could be read from the stream.";
				string message5 = string.Format(format, num);
				_log.Warn(message5);
			}
			if (num <= WebSocket.FragmentLength)
			{
				broadcastAsync(Opcode.Binary, array, completed);
			}
			else
			{
				broadcastAsync(Opcode.Binary, new MemoryStream(array), completed);
			}
		}

		public void CloseSession(string id)
		{
			if (!TryGetSession(id, out var session))
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			session.Context.WebSocket.Close();
		}

		public void CloseSession(string id, ushort code, string reason)
		{
			if (!TryGetSession(id, out var session))
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			session.Context.WebSocket.Close(code, reason);
		}

		public void CloseSession(string id, CloseStatusCode code, string reason)
		{
			if (!TryGetSession(id, out var session))
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			session.Context.WebSocket.Close(code, reason);
		}

		public bool PingTo(string id)
		{
			if (!TryGetSession(id, out var session))
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			return session.Context.WebSocket.Ping();
		}

		public bool PingTo(string message, string id)
		{
			if (!TryGetSession(id, out var session))
			{
				string message2 = "The session could not be found.";
				throw new InvalidOperationException(message2);
			}
			return session.Context.WebSocket.Ping(message);
		}

		public void SendTo(byte[] data, string id)
		{
			if (!TryGetSession(id, out var session))
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			session.Context.WebSocket.Send(data);
		}

		public void SendTo(string data, string id)
		{
			if (!TryGetSession(id, out var session))
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			session.Context.WebSocket.Send(data);
		}

		public void SendTo(Stream stream, int length, string id)
		{
			if (!TryGetSession(id, out var session))
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			session.Context.WebSocket.Send(stream, length);
		}

		public void SendToAsync(byte[] data, string id, Action<bool> completed)
		{
			if (!TryGetSession(id, out var session))
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			session.Context.WebSocket.SendAsync(data, completed);
		}

		public void SendToAsync(string data, string id, Action<bool> completed)
		{
			if (!TryGetSession(id, out var session))
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			session.Context.WebSocket.SendAsync(data, completed);
		}

		public void SendToAsync(Stream stream, int length, string id, Action<bool> completed)
		{
			if (!TryGetSession(id, out var session))
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			session.Context.WebSocket.SendAsync(stream, length, completed);
		}

		public void Sweep()
		{
			if (_sweeping)
			{
				_log.Info("The sweeping is already in progress.");
				return;
			}
			lock (_forSweep)
			{
				if (_sweeping)
				{
					_log.Info("The sweeping is already in progress.");
					return;
				}
				_sweeping = true;
			}
			foreach (string inactiveID in InactiveIDs)
			{
				if (_state != ServerState.Start)
				{
					break;
				}
				lock (_sync)
				{
					if (_state != ServerState.Start)
					{
						break;
					}
					if (_sessions.TryGetValue(inactiveID, out var value))
					{
						switch (value.ConnectionState)
						{
						case WebSocketState.Open:
							value.Context.WebSocket.Close(CloseStatusCode.Abnormal);
							break;
						default:
							_sessions.Remove(inactiveID);
							break;
						case WebSocketState.Closing:
							break;
						}
					}
					continue;
				}
			}
			_sweeping = false;
		}

		public bool TryGetSession(string id, out IWebSocketSession session)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}
			if (id.Length == 0)
			{
				throw new ArgumentException("An empty string.", "id");
			}
			return tryGetSession(id, out session);
		}
	}
	internal enum ServerState
	{
		Ready,
		Start,
		ShuttingDown,
		Stop
	}
	public class WebSocketServiceManager
	{
		private Dictionary<string, WebSocketServiceHost> _hosts;

		private volatile bool _keepClean;

		private Logger _log;

		private volatile ServerState _state;

		private object _sync;

		private TimeSpan _waitTime;

		public int Count
		{
			get
			{
				lock (_sync)
				{
					return _hosts.Count;
				}
			}
		}

		public IEnumerable<WebSocketServiceHost> Hosts
		{
			get
			{
				lock (_sync)
				{
					return _hosts.Values.ToList();
				}
			}
		}

		public WebSocketServiceHost this[string path]
		{
			get
			{
				if (path == null)
				{
					throw new ArgumentNullException("path");
				}
				if (path.Length == 0)
				{
					throw new ArgumentException("An empty string.", "path");
				}
				if (path[0] != '/')
				{
					string message = "It is not an absolute path.";
					throw new ArgumentException(message, "path");
				}
				if (path.IndexOfAny(new char[2] { '?', '#' }) > -1)
				{
					string message2 = "It includes either or both query and fragment components.";
					throw new ArgumentException(message2, "path");
				}
				InternalTryGetServiceHost(path, out var host);
				return host;
			}
		}

		public bool KeepClean
		{
			get
			{
				return _keepClean;
			}
			set
			{
				lock (_sync)
				{
					if (!canSet())
					{
						return;
					}
					foreach (WebSocketServiceHost value2 in _hosts.Values)
					{
						value2.KeepClean = value;
					}
					_keepClean = value;
				}
			}
		}

		public IEnumerable<string> Paths
		{
			get
			{
				lock (_sync)
				{
					return _hosts.Keys.ToList();
				}
			}
		}

		public TimeSpan WaitTime
		{
			get
			{
				return _waitTime;
			}
			set
			{
				if (value <= TimeSpan.Zero)
				{
					string message = "It is zero or less.";
					throw new ArgumentOutOfRangeException("value", message);
				}
				lock (_sync)
				{
					if (!canSet())
					{
						return;
					}
					foreach (WebSocketServiceHost value2 in _hosts.Values)
					{
						value2.WaitTime = value;
					}
					_waitTime = value;
				}
			}
		}

		internal WebSocketServiceManager(Logger log)
		{
			_log = log;
			_hosts = new Dictionary<string, WebSocketServiceHost>();
			_keepClean = true;
			_state = ServerState.Ready;
			_sync = ((ICollection)_hosts).SyncRoot;
			_waitTime = TimeSpan.FromSeconds(1.0);
		}

		private bool canSet()
		{
			return _state == ServerState.Ready || _state == ServerState.Stop;
		}

		internal bool InternalTryGetServiceHost(string path, out WebSocketServiceHost host)
		{
			path = path.TrimSlashFromEnd();
			lock (_sync)
			{
				return _hosts.TryGetValue(path, out host);
			}
		}

		internal void Start()
		{
			lock (_sync)
			{
				foreach (WebSocketServiceHost value in _hosts.Values)
				{
					value.Start();
				}
				_state = ServerState.Start;
			}
		}

		internal void Stop(ushort code, string reason)
		{
			lock (_sync)
			{
				_state = ServerState.ShuttingDown;
				foreach (WebSocketServiceHost value in _hosts.Values)
				{
					value.Stop(code, reason);
				}
				_state = ServerState.Stop;
			}
		}

		public void AddService<TBehavior>(string path, Action<TBehavior> initializer) where TBehavior : WebSocketBehavior, new()
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			if (path[0] != '/')
			{
				string message = "It is not an absolute path.";
				throw new ArgumentException(message, "path");
			}
			if (path.IndexOfAny(new char[2] { '?', '#' }) > -1)
			{
				string message2 = "It includes either or both query and fragment components.";
				throw new ArgumentException(message2, "path");
			}
			path = path.TrimSlashFromEnd();
			lock (_sync)
			{
				if (_hosts.TryGetValue(path, out var value))
				{
					string message3 = "It is already in use.";
					throw new ArgumentException(message3, "path");
				}
				value = new WebSocketServiceHost<TBehavior>(path, initializer, _log);
				if (!_keepClean)
				{
					value.KeepClean = false;
				}
				if (_waitTime != value.WaitTime)
				{
					value.WaitTime = _waitTime;
				}
				if (_state == ServerState.Start)
				{
					value.Start();
				}
				_hosts.Add(path, value);
			}
		}

		public void Clear()
		{
			List<WebSocketServiceHost> list = null;
			lock (_sync)
			{
				list = _hosts.Values.ToList();
				_hosts.Clear();
			}
			foreach (WebSocketServiceHost item in list)
			{
				if (item.State == ServerState.Start)
				{
					item.Stop(1001, string.Empty);
				}
			}
		}

		public bool RemoveService(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			if (path[0] != '/')
			{
				string message = "It is not an absolute path.";
				throw new ArgumentException(message, "path");
			}
			if (path.IndexOfAny(new char[2] { '?', '#' }) > -1)
			{
				string message2 = "It includes either or both query and fragment components.";
				throw new ArgumentException(message2, "path");
			}
			path = path.TrimSlashFromEnd();
			WebSocketServiceHost value;
			lock (_sync)
			{
				if (!_hosts.TryGetValue(path, out value))
				{
					return false;
				}
				_hosts.Remove(path);
			}
			if (value.State == ServerState.Start)
			{
				value.Stop(1001, string.Empty);
			}
			return true;
		}

		public bool TryGetServiceHost(string path, out WebSocketServiceHost host)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			if (path[0] != '/')
			{
				string message = "It is not an absolute path.";
				throw new ArgumentException(message, "path");
			}
			if (path.IndexOfAny(new char[2] { '?', '#' }) > -1)
			{
				string message2 = "It includes either or both query and fragment components.";
				throw new ArgumentException(message2, "path");
			}
			return InternalTryGetServiceHost(path, out host);
		}
	}
	public abstract class WebSocketBehavior : IWebSocketSession
	{
		private WebSocketContext _context;

		private Func<WebSocketSharp.Net.CookieCollection, WebSocketSharp.Net.CookieCollection, bool> _cookiesValidator;

		private bool _emitOnPing;

		private string _id;

		private bool _ignoreExtensions;

		private Func<string, bool> _originValidator;

		private string _protocol;

		private WebSocketSessionManager _sessions;

		private DateTime _startTime;

		private WebSocket _websocket;

		protected NameValueCollection Headers => (_context != null) ? _context.Headers : null;

		protected NameValueCollection QueryString => (_context != null) ? _context.QueryString : null;

		protected WebSocketSessionManager Sessions => _sessions;

		public WebSocketState ConnectionState => (_websocket != null) ? _websocket.ReadyState : WebSocketState.Connecting;

		public WebSocketContext Context => _context;

		public Func<WebSocketSharp.Net.CookieCollection, WebSocketSharp.Net.CookieCollection, bool> CookiesValidator
		{
			get
			{
				return _cookiesValidator;
			}
			set
			{
				_cookiesValidator = value;
			}
		}

		public bool EmitOnPing
		{
			get
			{
				return (_websocket != null) ? _websocket.EmitOnPing : _emitOnPing;
			}
			set
			{
				if (_websocket != null)
				{
					_websocket.EmitOnPing = value;
				}
				else
				{
					_emitOnPing = value;
				}
			}
		}

		public string ID => _id;

		public bool IgnoreExtensions
		{
			get
			{
				return _ignoreExtensions;
			}
			set
			{
				_ignoreExtensions = value;
			}
		}

		public Func<string, bool> OriginValidator
		{
			get
			{
				return _originValidator;
			}
			set
			{
				_originValidator = value;
			}
		}

		public string Protocol
		{
			get
			{
				return (_websocket != null) ? _websocket.Protocol : (_protocol ?? string.Empty);
			}
			set
			{
				if (_websocket != null)
				{
					string message = "The session has already started.";
					throw new InvalidOperationException(message);
				}
				if (value == null || value.Length == 0)
				{
					_protocol = null;
					return;
				}
				if (!value.IsToken())
				{
					string message2 = "It is not a token.";
					throw new ArgumentException(message2, "value");
				}
				_protocol = value;
			}
		}

		public DateTime StartTime => _startTime;

		protected WebSocketBehavior()
		{
			_startTime = DateTime.MaxValue;
		}

		private string checkHandshakeRequest(WebSocketContext context)
		{
			if (_originValidator != null && !_originValidator(context.Origin))
			{
				return "It includes no Origin header or an invalid one.";
			}
			if (_cookiesValidator != null)
			{
				WebSocketSharp.Net.CookieCollection cookieCollection = context.CookieCollection;
				WebSocketSharp.Net.CookieCollection cookieCollection2 = context.WebSocket.CookieCollection;
				if (!_cookiesValidator(cookieCollection, cookieCollection2))
				{
					return "It includes no cookie or an invalid one.";
				}
			}
			return null;
		}

		private void onClose(object sender, CloseEventArgs e)
		{
			if (_id != null)
			{
				_sessions.Remove(_id);
				OnClose(e);
			}
		}

		private void onError(object sender, ErrorEventArgs e)
		{
			OnError(e);
		}

		private void onMessage(object sender, MessageEventArgs e)
		{
			OnMessage(e);
		}

		private void onOpen(object sender, EventArgs e)
		{
			_id = _sessions.Add(this);
			if (_id == null)
			{
				_websocket.Close(CloseStatusCode.Away);
				return;
			}
			_startTime = DateTime.Now;
			OnOpen();
		}

		internal void Start(WebSocketContext context, WebSocketSessionManager sessions)
		{
			_context = context;
			_sessions = sessions;
			_websocket = context.WebSocket;
			_websocket.CustomHandshakeRequestChecker = checkHandshakeRequest;
			_websocket.EmitOnPing = _emitOnPing;
			_websocket.IgnoreExtensions = _ignoreExtensions;
			_websocket.Protocol = _protocol;
			TimeSpan waitTime = sessions.WaitTime;
			if (waitTime != _websocket.WaitTime)
			{
				_websocket.WaitTime = waitTime;
			}
			_websocket.OnOpen += onOpen;
			_websocket.OnMessage += onMessage;
			_websocket.OnError += onError;
			_websocket.OnClose += onClose;
			_websocket.InternalAccept();
		}

		protected void Close()
		{
			if (_websocket == null)
			{
				string message = "The session has not started yet.";
				throw new InvalidOperationException(message);
			}
			_websocket.Close();
		}

		protected void Close(ushort code, string reason)
		{
			if (_websocket == null)
			{
				string message = "The session has not started yet.";
				throw new InvalidOperationException(message);
			}
			_websocket.Close(code, reason);
		}

		protected void Close(CloseStatusCode code, string reason)
		{
			if (_websocket == null)
			{
				string message = "The session has not started yet.";
				throw new InvalidOperationException(message);
			}
			_websocket.Close(code, reason);
		}

		protected void CloseAsync()
		{
			if (_websocket == null)
			{
				string message = "The session has not started yet.";
				throw new InvalidOperationException(message);
			}
			_websocket.CloseAsync();
		}

		protected void CloseAsync(ushort code, string reason)
		{
			if (_websocket == null)
			{
				string message = "The session has not started yet.";
				throw new InvalidOperationException(message);
			}
			_websocket.CloseAsync(code, reason);
		}

		protected void CloseAsync(CloseStatusCode code, string reason)
		{
			if (_websocket == null)
			{
				string message = "The session has not started yet.";
				throw new InvalidOperationException(message);
			}
			_websocket.CloseAsync(code, reason);
		}

		protected virtual void OnClose(CloseEventArgs e)
		{
		}

		protected virtual void OnError(ErrorEventArgs e)
		{
		}

		protected virtual void OnMessage(MessageEventArgs e)
		{
		}

		protected virtual void OnOpen()
		{
		}

		protected bool Ping()
		{
			if (_websocket == null)
			{
				string message = "The session has not started yet.";
				throw new InvalidOperationException(message);
			}
			return _websocket.Ping();
		}

		protected bool Ping(string message)
		{
			if (_websocket == null)
			{
				string message2 = "The session has not started yet.";
				throw new InvalidOperationException(message2);
			}
			return _websocket.Ping(message);
		}

		protected void Send(byte[] data)
		{
			if (_websocket == null)
			{
				string message = "The current state of the connection is not Open.";
				throw new InvalidOperationException(message);
			}
			_websocket.Send(data);
		}

		protected void Send(FileInfo fileInfo)
		{
			if (_websocket == null)
			{
				string message = "The current state of the connection is not Open.";
				throw new InvalidOperationException(message);
			}
			_websocket.Send(fileInfo);
		}

		protected void Send(string data)
		{
			if (_websocket == null)
			{
				string message = "The current state of the connection is not Open.";
				throw new InvalidOperationException(message);
			}
			_websocket.Send(data);
		}

		protected void Send(Stream stream, int length)
		{
			if (_websocket == null)
			{
				string message = "The current state of the connection is not Open.";
				throw new InvalidOperationException(message);
			}
			_websocket.Send(stream, length);
		}

		protected void SendAsync(byte[] data, Action<bool> completed)
		{
			if (_websocket == null)
			{
				string message = "The current state of the connection is not Open.";
				throw new InvalidOperationException(message);
			}
			_websocket.SendAsync(data, completed);
		}

		protected void SendAsync(FileInfo fileInfo, Action<bool> completed)
		{
			if (_websocket == null)
			{
				string message = "The current state of the connection is not Open.";
				throw new InvalidOperationException(message);
			}
			_websocket.SendAsync(fileInfo, completed);
		}

		protected void SendAsync(string data, Action<bool> completed)
		{
			if (_websocket == null)
			{
				string message = "The current state of the connection is not Open.";
				throw new InvalidOperationException(message);
			}
			_websocket.SendAsync(data, completed);
		}

		protected void SendAsync(Stream stream, int length, Action<bool> completed)
		{
			if (_websocket == null)
			{
				string message = "The current state of the connection is not Open.";
				throw new InvalidOperationException(message);
			}
			_websocket.SendAsync(stream, length, completed);
		}
	}
	internal class WebSocketServiceHost<TBehavior> : WebSocketServiceHost where TBehavior : WebSocketBehavior, new()
	{
		private Func<TBehavior> _creator;

		public override Type BehaviorType => typeof(TBehavior);

		internal WebSocketServiceHost(string path, Action<TBehavior> initializer, Logger log)
			: base(path, log)
		{
			_creator = createSessionCreator(initializer);
		}

		private static Func<TBehavior> createSessionCreator(Action<TBehavior> initializer)
		{
			if (initializer == null)
			{
				return () => new TBehavior();
			}
			return delegate
			{
				TBehavior val = new TBehavior();
				initializer(val);
				return val;
			};
		}

		protected override WebSocketBehavior CreateSession()
		{
			return _creator();
		}
	}
}
