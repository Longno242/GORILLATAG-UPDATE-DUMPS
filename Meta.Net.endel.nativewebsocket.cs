using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

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
			FilePathsData = new byte[130]
			{
				0, 0, 0, 12, 0, 0, 0, 122, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 118, 111, 105, 99,
				101, 64, 100, 51, 102, 54, 102, 51, 55, 98,
				56, 101, 49, 99, 92, 76, 105, 98, 92, 87,
				105, 116, 46, 97, 105, 92, 76, 105, 98, 92,
				116, 104, 105, 114, 100, 45, 112, 97, 114, 116,
				121, 92, 78, 97, 116, 105, 118, 101, 87, 101,
				98, 83, 111, 99, 107, 101, 116, 92, 87, 101,
				98, 83, 111, 99, 107, 101, 116, 92, 87, 101,
				98, 83, 111, 99, 107, 101, 116, 46, 99, 115
			},
			TypesData = new byte[601]
			{
				0, 0, 0, 0, 35, 77, 101, 116, 97, 46,
				78, 101, 116, 46, 78, 97, 116, 105, 118, 101,
				87, 101, 98, 83, 111, 99, 107, 101, 116, 124,
				73, 87, 101, 98, 83, 111, 99, 107, 101, 116,
				0, 0, 0, 0, 41, 77, 101, 116, 97, 46,
				78, 101, 116, 46, 78, 97, 116, 105, 118, 101,
				87, 101, 98, 83, 111, 99, 107, 101, 116, 124,
				87, 101, 98, 83, 111, 99, 107, 101, 116, 72,
				101, 108, 112, 101, 114, 115, 0, 0, 0, 0,
				43, 77, 101, 116, 97, 46, 78, 101, 116, 46,
				78, 97, 116, 105, 118, 101, 87, 101, 98, 83,
				111, 99, 107, 101, 116, 124, 87, 101, 98, 83,
				111, 99, 107, 101, 116, 69, 120, 99, 101, 112,
				116, 105, 111, 110, 0, 0, 0, 0, 53, 77,
				101, 116, 97, 46, 78, 101, 116, 46, 78, 97,
				116, 105, 118, 101, 87, 101, 98, 83, 111, 99,
				107, 101, 116, 124, 87, 101, 98, 83, 111, 99,
				107, 101, 116, 85, 110, 101, 120, 112, 101, 99,
				116, 101, 100, 69, 120, 99, 101, 112, 116, 105,
				111, 110, 0, 0, 0, 0, 58, 77, 101, 116,
				97, 46, 78, 101, 116, 46, 78, 97, 116, 105,
				118, 101, 87, 101, 98, 83, 111, 99, 107, 101,
				116, 124, 87, 101, 98, 83, 111, 99, 107, 101,
				116, 73, 110, 118, 97, 108, 105, 100, 65, 114,
				103, 117, 109, 101, 110, 116, 69, 120, 99, 101,
				112, 116, 105, 111, 110, 0, 0, 0, 0, 55,
				77, 101, 116, 97, 46, 78, 101, 116, 46, 78,
				97, 116, 105, 118, 101, 87, 101, 98, 83, 111,
				99, 107, 101, 116, 124, 87, 101, 98, 83, 111,
				99, 107, 101, 116, 73, 110, 118, 97, 108, 105,
				100, 83, 116, 97, 116, 101, 69, 120, 99, 101,
				112, 116, 105, 111, 110, 0, 0, 0, 0, 48,
				77, 101, 116, 97, 46, 78, 101, 116, 46, 78,
				97, 116, 105, 118, 101, 87, 101, 98, 83, 111,
				99, 107, 101, 116, 124, 87, 97, 105, 116, 70,
				111, 114, 66, 97, 99, 107, 103, 114, 111, 117,
				110, 100, 84, 104, 114, 101, 97, 100, 0, 0,
				0, 0, 34, 77, 101, 116, 97, 46, 78, 101,
				116, 46, 78, 97, 116, 105, 118, 101, 87, 101,
				98, 83, 111, 99, 107, 101, 116, 124, 87, 101,
				98, 83, 111, 99, 107, 101, 116, 0, 0, 0,
				0, 41, 77, 101, 116, 97, 46, 78, 101, 116,
				46, 78, 97, 116, 105, 118, 101, 87, 101, 98,
				83, 111, 99, 107, 101, 116, 124, 87, 101, 98,
				83, 111, 99, 107, 101, 116, 70, 97, 99, 116,
				111, 114, 121, 0, 0, 0, 0, 39, 77, 101,
				116, 97, 46, 78, 101, 116, 46, 78, 97, 116,
				105, 118, 101, 87, 101, 98, 83, 111, 99, 107,
				101, 116, 124, 77, 97, 105, 110, 84, 104, 114,
				101, 97, 100, 85, 116, 105, 108, 0, 0, 0,
				0, 38, 77, 101, 116, 97, 46, 78, 101, 116,
				46, 78, 97, 116, 105, 118, 101, 87, 101, 98,
				83, 111, 99, 107, 101, 116, 124, 87, 97, 105,
				116, 70, 111, 114, 85, 112, 100, 97, 116, 101,
				0, 0, 0, 0, 56, 77, 101, 116, 97, 46,
				78, 101, 116, 46, 78, 97, 116, 105, 118, 101,
				87, 101, 98, 83, 111, 99, 107, 101, 116, 46,
				87, 97, 105, 116, 70, 111, 114, 85, 112, 100,
				97, 116, 101, 124, 77, 97, 105, 110, 84, 104,
				114, 101, 97, 100, 65, 119, 97, 105, 116, 101,
				114
			},
			TotalFiles = 1,
			TotalTypes = 12,
			IsEditorOnly = false
		};
	}
}
namespace Meta.Net.NativeWebSocket;

public delegate void WebSocketOpenEventHandler();
public delegate void WebSocketMessageEventHandler(byte[] data, int offset, int length);
public delegate void WebSocketErrorEventHandler(string errorMsg);
public delegate void WebSocketCloseEventHandler(WebSocketCloseCode closeCode);
public enum WebSocketCloseCode
{
	NotSet = 0,
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
public enum WebSocketState
{
	Connecting,
	Open,
	Closing,
	Closed
}
public interface IWebSocket
{
	WebSocketState State { get; }

	event WebSocketOpenEventHandler OnOpen;

	event WebSocketMessageEventHandler OnMessage;

	event WebSocketErrorEventHandler OnError;

	event WebSocketCloseEventHandler OnClose;
}
public static class WebSocketHelpers
{
	public static WebSocketCloseCode ParseCloseCodeEnum(int closeCode)
	{
		if (Enum.IsDefined(typeof(WebSocketCloseCode), closeCode))
		{
			return (WebSocketCloseCode)closeCode;
		}
		return WebSocketCloseCode.Undefined;
	}

	public static WebSocketException GetErrorMessageFromCode(int errorCode, Exception inner)
	{
		return errorCode switch
		{
			-1 => new WebSocketUnexpectedException("WebSocket instance not found.", inner), 
			-2 => new WebSocketInvalidStateException("WebSocket is already connected or in connecting state.", inner), 
			-3 => new WebSocketInvalidStateException("WebSocket is not connected.", inner), 
			-4 => new WebSocketInvalidStateException("WebSocket is already closing.", inner), 
			-5 => new WebSocketInvalidStateException("WebSocket is already closed.", inner), 
			-6 => new WebSocketInvalidStateException("WebSocket is not in open state.", inner), 
			-7 => new WebSocketInvalidArgumentException("Cannot close WebSocket. An invalid code was specified or reason is too long.", inner), 
			_ => new WebSocketUnexpectedException("Unknown error.", inner), 
		};
	}
}
public class WebSocketException : Exception
{
	public WebSocketException()
	{
	}

	public WebSocketException(string message)
		: base(message)
	{
	}

	public WebSocketException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
public class WebSocketUnexpectedException : WebSocketException
{
	public WebSocketUnexpectedException()
	{
	}

	public WebSocketUnexpectedException(string message)
		: base(message)
	{
	}

	public WebSocketUnexpectedException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
public class WebSocketInvalidArgumentException : WebSocketException
{
	public WebSocketInvalidArgumentException()
	{
	}

	public WebSocketInvalidArgumentException(string message)
		: base(message)
	{
	}

	public WebSocketInvalidArgumentException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
public class WebSocketInvalidStateException : WebSocketException
{
	public WebSocketInvalidStateException()
	{
	}

	public WebSocketInvalidStateException(string message)
		: base(message)
	{
	}

	public WebSocketInvalidStateException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
public class WaitForBackgroundThread
{
	public ConfiguredTaskAwaitable.ConfiguredTaskAwaiter GetAwaiter()
	{
		return Task.Run(delegate
		{
		}).ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
	}
}
public class WebSocket : IWebSocket
{
	private readonly object IncomingMessageLock = new object();

	private readonly object OutgoingMessageLock = new object();

	private readonly Dictionary<string, string> headers;

	private bool isSending;

	private CancellationToken m_CancellationToken;

	private readonly List<byte[]> m_MessageList = new List<byte[]>();

	private ClientWebSocket m_Socket = new ClientWebSocket();

	private CancellationTokenSource m_TokenSource;

	private readonly List<ArraySegment<byte>> sendBytesQueue = new List<ArraySegment<byte>>();

	private readonly List<ArraySegment<byte>> sendTextQueue = new List<ArraySegment<byte>>();

	private readonly List<string> subprotocols;

	private readonly Uri uri;

	public WebSocketState State
	{
		get
		{
			switch (m_Socket.State)
			{
			case System.Net.WebSockets.WebSocketState.Connecting:
				return WebSocketState.Connecting;
			case System.Net.WebSockets.WebSocketState.Open:
				return WebSocketState.Open;
			case System.Net.WebSockets.WebSocketState.CloseSent:
			case System.Net.WebSockets.WebSocketState.CloseReceived:
				return WebSocketState.Closing;
			case System.Net.WebSockets.WebSocketState.Closed:
				return WebSocketState.Closed;
			default:
				return WebSocketState.Closed;
			}
		}
	}

	public event WebSocketOpenEventHandler OnOpen;

	public event WebSocketMessageEventHandler OnMessage;

	public event WebSocketErrorEventHandler OnError;

	public event WebSocketCloseEventHandler OnClose;

	public WebSocket(string url, Dictionary<string, string> headers = null)
	{
		uri = new Uri(url);
		if (headers == null)
		{
			this.headers = new Dictionary<string, string>();
		}
		else
		{
			this.headers = headers;
		}
		subprotocols = new List<string>();
		string scheme = uri.Scheme;
		if (!scheme.Equals("ws") && !scheme.Equals("wss"))
		{
			throw new ArgumentException("Unsupported protocol: " + scheme);
		}
	}

	public WebSocket(string url, string subprotocol, Dictionary<string, string> headers = null)
	{
		uri = new Uri(url);
		if (headers == null)
		{
			this.headers = new Dictionary<string, string>();
		}
		else
		{
			this.headers = headers;
		}
		subprotocols = new List<string> { subprotocol };
		string scheme = uri.Scheme;
		if (!scheme.Equals("ws") && !scheme.Equals("wss"))
		{
			throw new ArgumentException("Unsupported protocol: " + scheme);
		}
	}

	public WebSocket(string url, List<string> subprotocols, Dictionary<string, string> headers = null)
	{
		uri = new Uri(url);
		if (headers == null)
		{
			this.headers = new Dictionary<string, string>();
		}
		else
		{
			this.headers = headers;
		}
		this.subprotocols = subprotocols;
		string scheme = uri.Scheme;
		if (!scheme.Equals("ws") && !scheme.Equals("wss"))
		{
			throw new ArgumentException("Unsupported protocol: " + scheme);
		}
	}

	public void CancelConnection()
	{
		m_TokenSource?.Cancel();
	}

	public async Task Connect()
	{
		_ = 1;
		try
		{
			m_TokenSource = new CancellationTokenSource();
			m_CancellationToken = m_TokenSource.Token;
			m_Socket = new ClientWebSocket();
			foreach (KeyValuePair<string, string> header in headers)
			{
				m_Socket.Options.SetRequestHeader(header.Key, header.Value);
			}
			foreach (string subprotocol in subprotocols)
			{
				m_Socket.Options.AddSubProtocol(subprotocol);
			}
			await m_Socket.ConnectAsync(uri, m_CancellationToken);
			this.OnOpen?.Invoke();
			await Receive();
		}
		catch (Exception ex)
		{
			this.OnError?.Invoke(ex.Message);
			this.OnClose?.Invoke(WebSocketCloseCode.Abnormal);
		}
		finally
		{
			if (m_Socket != null)
			{
				m_TokenSource.Cancel();
				m_Socket.Dispose();
			}
		}
	}

	public Task Send(byte[] bytes)
	{
		return SendMessage(sendBytesQueue, WebSocketMessageType.Binary, new ArraySegment<byte>(bytes));
	}

	public Task SendText(string message)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(message);
		return SendMessage(sendTextQueue, WebSocketMessageType.Text, new ArraySegment<byte>(bytes, 0, bytes.Length));
	}

	private async Task SendMessage(List<ArraySegment<byte>> queue, WebSocketMessageType messageType, ArraySegment<byte> buffer)
	{
		if (buffer.Count == 0)
		{
			return;
		}
		bool flag;
		lock (OutgoingMessageLock)
		{
			flag = isSending;
			if (!isSending)
			{
				isSending = true;
			}
		}
		if (!flag)
		{
			if (!Monitor.TryEnter(m_Socket, 1000))
			{
				await m_Socket.CloseAsync(WebSocketCloseStatus.InternalServerError, string.Empty, m_CancellationToken);
				return;
			}
			try
			{
				m_Socket.SendAsync(buffer, messageType, endOfMessage: true, m_CancellationToken).Wait(m_CancellationToken);
			}
			finally
			{
				Monitor.Exit(m_Socket);
			}
			lock (OutgoingMessageLock)
			{
				isSending = false;
			}
			await HandleQueue(queue, messageType);
			return;
		}
		lock (OutgoingMessageLock)
		{
			queue.Add(buffer);
		}
	}

	private async Task HandleQueue(List<ArraySegment<byte>> queue, WebSocketMessageType messageType)
	{
		ArraySegment<byte> buffer = default(ArraySegment<byte>);
		lock (OutgoingMessageLock)
		{
			if (queue.Count > 0)
			{
				buffer = queue[0];
				queue.RemoveAt(0);
			}
		}
		if (buffer.Count > 0)
		{
			await SendMessage(queue, messageType, buffer);
		}
	}

	public async Task Receive()
	{
		WebSocketCloseCode closeCode = WebSocketCloseCode.Abnormal;
		await new WaitForBackgroundThread();
		ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8192]);
		object obj = null;
		try
		{
			int num;
			_ = num - 1;
			_ = 1;
			try
			{
				while (m_Socket.State == System.Net.WebSockets.WebSocketState.Open)
				{
					WebSocketReceiveResult result;
					do
					{
						result = await m_Socket.ReceiveAsync(buffer, m_CancellationToken);
						this.OnMessage?.Invoke(buffer.Array, buffer.Offset, result.Count);
					}
					while (!result.EndOfMessage);
					if (result.MessageType == WebSocketMessageType.Close)
					{
						await Close();
						closeCode = WebSocketHelpers.ParseCloseCodeEnum((int)result.CloseStatus.Value);
						break;
					}
				}
			}
			catch (Exception)
			{
				m_TokenSource.Cancel();
			}
		}
		catch (object obj2)
		{
			obj = obj2;
		}
		await new WaitForUpdate();
		this.OnClose?.Invoke(closeCode);
		object obj3 = obj;
		if (obj3 != null)
		{
			ExceptionDispatchInfo.Capture((obj3 as Exception) ?? throw obj3).Throw();
		}
	}

	public async Task Close()
	{
		if (State == WebSocketState.Open)
		{
			await m_Socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, m_CancellationToken);
		}
	}
}
public static class WebSocketFactory
{
	public static WebSocket CreateInstance(string url)
	{
		return new WebSocket(url);
	}
}
public class MainThreadUtil : MonoBehaviour
{
	public static MainThreadUtil Instance { get; private set; }

	public static SynchronizationContext synchronizationContext { get; private set; }

	private void Awake()
	{
		base.gameObject.hideFlags = HideFlags.HideAndDontSave;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	public static void Setup()
	{
		Instance = new GameObject("MainThreadUtil").AddComponent<MainThreadUtil>();
		synchronizationContext = SynchronizationContext.Current;
	}

	public static void Run(IEnumerator waitForUpdate)
	{
		if (!Instance)
		{
			UnityEngine.Debug.LogWarning("Attempting to run on main thread after shutdown.");
			throw new Exception("Attempting to run on main thread after shutdown.");
		}
		synchronizationContext.Post(delegate
		{
			Instance.StartCoroutine(waitForUpdate);
		}, null);
	}
}
public class WaitForUpdate : CustomYieldInstruction
{
	public class MainThreadAwaiter : INotifyCompletion
	{
		private Action continuation;

		public bool IsCompleted { get; set; }

		void INotifyCompletion.OnCompleted(Action continuation)
		{
			this.continuation = continuation;
		}

		public void GetResult()
		{
		}

		public void Complete()
		{
			IsCompleted = true;
			continuation?.Invoke();
		}
	}

	public override bool keepWaiting => false;

	public MainThreadAwaiter GetAwaiter()
	{
		MainThreadAwaiter mainThreadAwaiter = new MainThreadAwaiter();
		MainThreadUtil.Run(CoroutineWrapper(this, mainThreadAwaiter));
		return mainThreadAwaiter;
	}

	public static IEnumerator CoroutineWrapper(IEnumerator theWorker, MainThreadAwaiter awaiter)
	{
		yield return theWorker;
		awaiter.Complete();
	}
}
