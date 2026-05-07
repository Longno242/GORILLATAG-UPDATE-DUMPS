#define SUPPORTED_UNITY
#define TRACE
#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Encryption;
using Fusion.Async;
using Fusion.Photon.Realtime;
using Fusion.Photon.Realtime.Async;
using Fusion.Photon.Realtime.Extension;
using Microsoft.CodeAnalysis;
using UnityEngine;
using UnityEngine.Networking;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: ComVisible(false)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = ".NET Standard 2.1")]
[assembly: AssemblyCompany("Exit Games GmbH")]
[assembly: AssemblyConfiguration("Unity Debug")]
[assembly: AssemblyCopyright("? Exit Games GmbH")]
[assembly: AssemblyFileVersion("2.0.6.1034")]
[assembly: AssemblyInformationalVersion("2.0.6.1034+94e2793d")]
[assembly: AssemblyProduct("Fusion.Realtime")]
[assembly: AssemblyTitle("Fusion.Realtime (Unity Debug)")]
[assembly: InternalsVisibleTo("Fusion.Plugin")]
[assembly: InternalsVisibleTo("Fusion.Runtime")]
[assembly: InternalsVisibleTo("Fusion.Sockets")]
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
	public struct RegionInfo
	{
		public string RegionCode;

		public int RegionPing;
	}
	internal static class FusionRealtimeProxy
	{
		private const float REGION_INFO_CACHE_TIME = 10f;

		private static float _lastRegionRequestTime;

		private static List<RegionInfo> _cachedRegionInfo;

		internal static async Task<List<RegionInfo>> GetEnabledRegions(string appId, CancellationToken cancellationToken)
		{
			if (PhotonAppSettings.TryGetGlobal(out var global) && appId == null)
			{
				appId = global.AppSettings.AppIdFusion;
			}
			if (appId == null)
			{
				InternalLogStreams.LogDebug?.Warn("Could not get enabled regions. Provided App id is not valid.");
				return null;
			}
			if (Time.time <= _lastRegionRequestTime + 10f && _cachedRegionInfo != null)
			{
				return await Task.FromResult(_cachedRegionInfo);
			}
			LoadBalancingClient client = new LoadBalancingClient
			{
				AppId = appId
			};
			RegionHandler regionHandler = await client.GetRegionsAsync(throwOnError: true, createServiceTask: true, cancellationToken);
			await client.LeaveRoomAsync(createServiceTask: true, cancellationToken);
			await client.DisconnectAsync(createServiceTask: true, cancellationToken);
			List<RegionInfo> list = new List<RegionInfo>();
			if (regionHandler == null)
			{
				return list;
			}
			foreach (Region region in regionHandler.EnabledRegions)
			{
				list.Add(new RegionInfo
				{
					RegionCode = region.Code,
					RegionPing = region.Ping
				});
			}
			_cachedRegionInfo = new List<RegionInfo>(list);
			_lastRegionRequestTime = Time.unscaledTime;
			return list;
		}
	}
	public sealed class SessionProperty
	{
		private object _value = null;

		public object PropertyValue => _value;

		public Type PropertyType => _value.GetType();

		public bool IsInt => _value is int;

		public bool IsString => _value is string;

		public bool Isbool => _value is bool;

		private SessionProperty()
		{
		}

		public static implicit operator int(SessionProperty sessionProperty)
		{
			if (sessionProperty._value is int result)
			{
				return result;
			}
			throw new InvalidCastException();
		}

		public static implicit operator SessionProperty(int v)
		{
			return new SessionProperty
			{
				_value = v
			};
		}

		public static implicit operator string(SessionProperty sessionProperty)
		{
			if (sessionProperty._value is string result)
			{
				return result;
			}
			throw new InvalidCastException();
		}

		public static implicit operator SessionProperty(string v)
		{
			return new SessionProperty
			{
				_value = v
			};
		}

		public static implicit operator bool(SessionProperty sessionProperty)
		{
			if (sessionProperty._value is bool result)
			{
				return result;
			}
			throw new InvalidCastException();
		}

		public static implicit operator SessionProperty(bool v)
		{
			return new SessionProperty
			{
				_value = v
			};
		}

		public static bool Support(object obj)
		{
			return obj is int || obj is string || obj is bool;
		}

		public static SessionProperty Convert(object obj)
		{
			if (obj is int num)
			{
				return num;
			}
			if (obj is string text)
			{
				return text;
			}
			if (obj is bool flag)
			{
				return flag;
			}
			throw new ArgumentException("Invalid Object type, not supported");
		}

		public override string ToString()
		{
			return string.Format("[{0}: {1}, Type={2}]", "SessionProperty", _value, PropertyType);
		}
	}
}
namespace Fusion.Photon.Realtime
{
	internal class FusionRelayClient : LoadBalancingClient, IInRoomCallbacks, IMatchmakingCallbacks, ILobbyCallbacks, IConnectionCallbacks
	{
		private ConnectionHandler _connectionHandler;

		private const string FUSION_PLUGIN_NAME = "FusionPlugin";

		private const string SERVER_HOST_CN = "ns.photonengine.cn";

		private const string REGION_CN_ID = "cn";

		private readonly RaiseEventOptions _raiseEventOptions;

		private readonly SendOptions _optionsUnreliable;

		private readonly SendOptions _optionsReliable;

		private GameObject _loggerGO;

		private FusionAppSettings Config;

		public bool IsReadyAndInRoom => base.IsConnectedAndReady && base.InRoom;

		public bool IsEncryptionEnabled => EncryptionMode != EncryptionMode.PayloadEncryption;

		public bool UseDefaultPorts { get; set; }

		public int DisconnectTimeout
		{
			get
			{
				return base.LoadBalancingPeer.DisconnectTimeout;
			}
			set
			{
				base.LoadBalancingPeer.DisconnectTimeout = value;
			}
		}

		public event Action OnRoomChanged;

		public event Action<int, int, object> OnEventCallback;

		public void StartFallbackSendAck()
		{
			if (!_connectionHandler)
			{
				GameObject gameObject = new GameObject("Fusion_PhotonBackgroundConnectionHandler", typeof(ConnectionHandler))
				{
					hideFlags = HideFlags.NotEditable
				};
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				_connectionHandler = gameObject.GetComponent<ConnectionHandler>();
				_connectionHandler.Client = this;
				_connectionHandler.KeepAliveInBackground = 60000;
			}
			_connectionHandler.StartFallbackSendAckThread();
		}

		public void StopFallbackSendAck()
		{
			if ((bool)_connectionHandler)
			{
				_connectionHandler.StopFallbackSendAckThread();
				UnityEngine.Object.Destroy(_connectionHandler.gameObject);
				_connectionHandler = null;
			}
		}

		private void OnEventHandler(EventData evt)
		{
			int sender = evt.Sender;
			byte code = evt.Code;
			object customData = evt.CustomData;
			this.OnEventCallback?.Invoke(sender, code, customData);
		}

		public unsafe bool SendEvent(int target, byte eventCode, byte* buffer, int bufferLength, bool reliable)
		{
			if (!IsReadyAndInRoom)
			{
				return false;
			}
			ByteArraySlice byteArraySlice = base.LoadBalancingPeer.ByteArraySlicePool.Acquire(bufferLength);
			if (buffer != null)
			{
				fixed (byte* buffer2 = byteArraySlice.Buffer)
				{
					Native.MemCpy(buffer2, buffer, bufferLength);
				}
			}
			byteArraySlice.Count = bufferLength;
			_raiseEventOptions.TargetActors[0] = target;
			bool result = OpRaiseEvent(eventCode, byteArraySlice, _raiseEventOptions, reliable ? _optionsReliable : _optionsUnreliable);
			if (base.LoadBalancingPeer.SendOutgoingCommands())
			{
				base.LoadBalancingPeer.SendOutgoingCommands();
			}
			return result;
		}

		public void ExtractData(object dataObj, byte[] buffer, ref int bufferLength)
		{
			if (dataObj is ByteArraySlice byteArraySlice)
			{
				Assert.Always(byteArraySlice.Count <= bufferLength, "Array slice to large for the buffer {0} {1}", bufferLength, byteArraySlice.Count);
				bufferLength = byteArraySlice.Count;
				Array.Copy(byteArraySlice.Buffer, buffer, bufferLength);
				byteArraySlice.Release();
			}
			else
			{
				bufferLength = -1;
			}
		}

		public FusionRelayClient(FusionAppSettings config)
		{
			InternalLogStreams.LogTraceRealtime?.Info(config?.ToString());
			Config = config;
			base.ClientType = ClientAppType.Fusion;
			base.SerializationProtocol = SerializationProtocol.GpBinaryV18;
			base.LoadBalancingPeer.TimePingInterval = 200;
			base.LoadBalancingPeer.UseByteArraySlicePoolForEvents = true;
			base.LoadBalancingPeer.ReuseEventInstance = true;
			base.LoadBalancingPeer.QuickResendAttempts = 8;
			base.LoadBalancingPeer.SentCountAllowance *= 10;
			base.LoadBalancingPeer.DisconnectTimeout = 15000;
			base.LoadBalancingPeer.SendWindowSize /= 3;
			EncryptionMode = Config.encryptionMode;
			base.LoadBalancingPeer.EncryptorType = (IsEncryptionEnabled ? LoadPhotonEncryptorType() : null);
			base.LoadBalancingPeer.OnDisconnectMessage += OnDisconnectMessage;
			UseDefaultPorts = false;
			base.EventReceived += OnEventHandler;
			AddCallbackTarget(this);
			_raiseEventOptions = new RaiseEventOptions
			{
				TargetActors = new int[1]
			};
			_optionsUnreliable = new SendOptions
			{
				Channel = 0,
				DeliveryMode = DeliveryMode.UnreliableUnsequenced
			};
			_optionsReliable = new SendOptions
			{
				Channel = 1,
				DeliveryMode = DeliveryMode.Reliable
			};
		}

		private static Type LoadPhotonEncryptorType()
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			bool flag = true;
			while (true)
			{
				Assembly[] array = assemblies;
				foreach (Assembly assembly in array)
				{
					string text = assembly.FullName.ToLower();
					if (flag && !text.Contains("assembly-csharp") && !text.Contains("fusion") && !text.Contains("photon"))
					{
						continue;
					}
					Type[] types = assembly.GetTypes();
					foreach (Type type in types)
					{
						if (!typeof(IPhotonEncryptor).IsAssignableFrom(type) || type.IsInterface || type.IsAbstract)
						{
							continue;
						}
						try
						{
							IPhotonEncryptor photonEncryptor = (IPhotonEncryptor)Activator.CreateInstance(type);
							photonEncryptor.Init(Array.Empty<byte>(), Array.Empty<byte>());
							(photonEncryptor as IDisposable)?.Dispose();
						}
						catch
						{
							continue;
						}
						InternalLogStreams.LogTraceRealtime?.Info($"Encryption IPhotonEncryptor Type: {type.FullName}/{type.Assembly}");
						return type;
					}
				}
				if (!flag)
				{
					break;
				}
				flag = false;
			}
			throw new InvalidOperationException("No implementation of IPhotonEncryptor found. Make sure to include a Photon Realtime Encryption Library in your project.");
		}

		public void Reset()
		{
			UnityEngine.Object.Destroy(_loggerGO);
		}

		public override bool ConnectUsingSettings(AppSettings appSettings)
		{
			AppSettings copy = appSettings.GetCopy();
			ServerPortOverrides = default(PhotonPortDefinition);
			if (RuntimeUnityFlagsSetup.IsUNITY_WEBGL)
			{
				copy.Protocol = ConnectionProtocol.WebSocketSecure;
				InternalLogStreams.LogTraceRealtime?.Info("Changing Photon Cloud Communication Protocol to WebSocketSecure");
			}
			if (copy.Protocol == ConnectionProtocol.Udp && copy.IsDefaultPort && !UseDefaultPorts)
			{
				ServerPortOverrides = PhotonPortDefinition.AlternativeUdpPorts;
				InternalLogStreams.LogTraceRealtime?.Info("Changing Photon Cloud Communication Ports to [" + string.Format("{0}={1},", "NameServerPort", ServerPortOverrides.NameServerPort) + string.Format("{0}={1},", "MasterServerPort", ServerPortOverrides.MasterServerPort) + string.Format("{0}={1}", "GameServerPort", ServerPortOverrides.GameServerPort) + "]");
			}
			if (copy.FixedRegion.ToLower().Equals("cn") && string.IsNullOrEmpty(copy.Server?.Trim()))
			{
				copy.Server = "ns.photonengine.cn";
			}
			return base.ConnectUsingSettings(copy);
		}

		public bool UpdateRoomProperties(Dictionary<string, SessionProperty> customProperties)
		{
			if (customProperties == null || customProperties.Count == 0)
			{
				return false;
			}
			if (base.CurrentRoom.IsOffline)
			{
				return false;
			}
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			hashtable.Merge(base.CurrentRoom.CustomProperties);
			bool flag = false;
			foreach (string key in customProperties.Keys)
			{
				if (hashtable.ContainsKey(key))
				{
					if (!hashtable[key].Equals(customProperties[key].PropertyValue))
					{
						hashtable[key] = customProperties[key].PropertyValue;
						flag = true;
					}
				}
				else
				{
					InternalLogStreams.LogWarn?.Log("Invalid custom property key [" + key + "], ignore. Only existing custom properties can be updated.");
				}
			}
			if (hashtable.Count > 10)
			{
				InternalLogStreams.LogWarn?.Log("Max number of Custom Session Properties reached, only 10 properties are allowed.");
				return false;
			}
			int num = hashtable.CalculateTotalSize();
			if (num > 500)
			{
				InternalLogStreams.LogWarn?.Log($"Max size of Custom Session Properties reached, current size of {num} bytes, max 500 bytes are allowed.");
				return false;
			}
			return flag && base.CurrentRoom.SetCustomProperties(hashtable);
		}

		public bool UpdateRoomIsVisible(bool value)
		{
			if (base.CurrentRoom.IsOffline)
			{
				return false;
			}
			if (base.CurrentRoom.IsVisible == value)
			{
				return false;
			}
			base.CurrentRoom.IsVisible = value;
			return true;
		}

		public bool UpdateRoomIsOpen(bool value)
		{
			if (base.CurrentRoom.IsOffline)
			{
				return false;
			}
			if (base.CurrentRoom.IsOpen == value)
			{
				return false;
			}
			base.CurrentRoom.IsOpen = value;
			return true;
		}

		public void Update()
		{
			if (_loggerGO == null && (int)base.LoadBalancingPeer.DebugOut >= 2)
			{
				SupportLogger supportLogger = UnityEngine.Object.FindObjectOfType<SupportLogger>();
				if (supportLogger == null)
				{
					_loggerGO = new GameObject
					{
						name = "RealtimeLogger",
						hideFlags = HideFlags.NotEditable
					};
					UnityEngine.Object.DontDestroyOnLoad(_loggerGO);
					supportLogger = _loggerGO.AddComponent<SupportLogger>();
				}
				supportLogger.Client = this;
				_loggerGO = supportLogger.gameObject;
			}
			try
			{
				Service();
			}
			catch (Exception error)
			{
				InternalLogStreams.LogError?.Log(error);
			}
		}

		private void OnDisconnectMessage(DisconnectMessage obj)
		{
			InternalLogStreams.LogError?.Log($"DisconnectMessage. Code: {obj.Code} Msg: \"{obj.DebugMessage}\". Debug Info: {obj.Parameters.ToStringFull()}");
		}

		public EnterRoomParams BuildEnterRoomParams(TypedLobby typedLobby, string roomName, int maxPlayers, Dictionary<string, SessionProperty> customProperties = null, bool isOpen = true, bool isVisible = true, bool useDefaultEmptyRoomTtl = true, bool extendedTtl = false)
		{
			BuildSessionCustomPropertyHolders(customProperties, out var sessionCustomProperties, out var publicSessionProperties);
			EnterRoomParams enterRoomParams = new EnterRoomParams();
			enterRoomParams.RoomName = roomName;
			enterRoomParams.Lobby = typedLobby;
			enterRoomParams.RoomOptions = new RoomOptions
			{
				MaxPlayers = maxPlayers,
				IsOpen = isOpen,
				IsVisible = isVisible,
				DeleteNullProperties = true,
				PlayerTtl = (extendedTtl ? 15000 : 0),
				EmptyRoomTtl = ((!useDefaultEmptyRoomTtl) ? Config.emptyRoomTtl : 0),
				Plugins = new string[1] { "FusionPlugin" },
				SuppressRoomEvents = false,
				SuppressPlayerInfo = false,
				PublishUserId = true,
				CustomRoomProperties = sessionCustomProperties,
				CustomRoomPropertiesForLobby = publicSessionProperties
			};
			return enterRoomParams;
		}

		public OpJoinRandomRoomParams BuildJoinParams(TypedLobby typedLobby, Dictionary<string, SessionProperty> customProperties = null, MatchmakingMode matchmakingMode = MatchmakingMode.FillRoom)
		{
			BuildSessionCustomPropertyHolders(customProperties, out var sessionCustomProperties, out var _);
			return new OpJoinRandomRoomParams
			{
				MatchingType = matchmakingMode,
				TypedLobby = typedLobby,
				ExpectedCustomRoomProperties = sessionCustomProperties
			};
		}

		private static void BuildSessionCustomPropertyHolders(Dictionary<string, SessionProperty> customProperties, out ExitGames.Client.Photon.Hashtable sessionCustomProperties, out string[] publicSessionProperties)
		{
			sessionCustomProperties = null;
			publicSessionProperties = null;
			if (customProperties != null && customProperties.Count > 0)
			{
				sessionCustomProperties = customProperties.ConvertToHashtable();
				publicSessionProperties = new List<string>(customProperties.Keys).ToArray();
			}
		}

		public void OnJoinedRoom()
		{
			StartFallbackSendAck();
		}

		public void OnLeftRoom()
		{
			StopFallbackSendAck();
		}

		public void OnCreatedRoom()
		{
		}

		public void OnCreateRoomFailed(short returnCode, string message)
		{
		}

		public void OnFriendListUpdate(List<FriendInfo> friendList)
		{
		}

		public void OnJoinRandomFailed(short returnCode, string message)
		{
		}

		public void OnJoinRoomFailed(short returnCode, string message)
		{
		}

		public void OnJoinedLobby()
		{
			StartFallbackSendAck();
		}

		public void OnLeftLobby()
		{
			StopFallbackSendAck();
		}

		public void OnRoomListUpdate(List<RoomInfo> roomList)
		{
		}

		public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
		{
		}

		public void OnMasterClientSwitched(Player newMasterClient)
		{
			this.OnRoomChanged?.Invoke();
		}

		public void OnPlayerEnteredRoom(Player newPlayer)
		{
			this.OnRoomChanged?.Invoke();
		}

		public void OnPlayerLeftRoom(Player otherPlayer)
		{
			this.OnRoomChanged?.Invoke();
		}

		public void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
		{
		}

		public void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
		{
			this.OnRoomChanged?.Invoke();
		}

		public void OnConnected()
		{
		}

		public void OnConnectedToMaster()
		{
		}

		public void OnDisconnected(DisconnectCause cause)
		{
			StopFallbackSendAck();
		}

		public void OnRegionListReceived(RegionHandler regionHandler)
		{
		}

		public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
		{
		}

		public void OnCustomAuthenticationFailed(string debugMessage)
		{
		}
	}
	internal static class Debug_
	{
		[Conditional("DEBUG")]
		public static void Log(string msg)
		{
			InternalLogStreams.LogTraceRealtime?.Log(msg);
		}

		[Conditional("DEBUG")]
		public static void LogWarning(string msg)
		{
			InternalLogStreams.LogWarn?.Log(msg);
		}

		[Conditional("DEBUG")]
		public static void LogError(string msg)
		{
			InternalLogStreams.LogError?.Log(msg);
		}

		[Conditional("DEBUG")]
		public static void LogException(Exception ex)
		{
			InternalLogStreams.LogException?.Log(ex);
		}
	}
	[Serializable]
	public class AppSettings
	{
		[NonSerialized]
		[InlineHelp]
		public string AppIdRealtime;

		[InlineHelp]
		public string AppIdFusion;

		[InlineHelp]
		public string AppIdChat;

		[InlineHelp]
		public string AppIdVoice;

		[InlineHelp]
		public string AppVersion;

		[InlineHelp]
		public bool UseNameServer = true;

		[InlineHelp]
		public string FixedRegion;

		[NonSerialized]
		[InlineHelp]
		public string BestRegionSummaryFromStorage;

		[InlineHelp]
		public string Server;

		[InlineHelp]
		public int Port;

		[InlineHelp]
		public string ProxyServer;

		[Header("Miscellaneous")]
		[InlineHelp]
		public ConnectionProtocol Protocol = ConnectionProtocol.Udp;

		[InlineHelp]
		public bool EnableProtocolFallback = true;

		[InlineHelp]
		public AuthModeOption AuthMode = AuthModeOption.Auth;

		[InlineHelp]
		public bool EnableLobbyStatistics;

		public DebugLevel NetworkLogging
		{
			get
			{
				if (InternalLogStreams.LogTraceRealtime != null)
				{
					return DebugLevel.ALL;
				}
				switch (Log.Settings.Level)
				{
				case LogLevel.Debug:
				case LogLevel.Info:
				case LogLevel.Warn:
					return DebugLevel.WARNING;
				case LogLevel.Error:
					return DebugLevel.ERROR;
				default:
					return DebugLevel.OFF;
				}
			}
			set
			{
			}
		}

		public bool IsMasterServerAddress => !UseNameServer;

		public bool IsBestRegion => UseNameServer && string.IsNullOrEmpty(FixedRegion);

		public bool IsDefaultNameServer => UseNameServer && string.IsNullOrEmpty(Server);

		public bool IsDefaultPort => Port <= 0;

		public string ToStringFull()
		{
			return string.Format("appId {0}{1}{2}{3}use ns: {4}, reg: {5}, {9}, {6}{7}{8}auth: {10}", string.IsNullOrEmpty(AppIdRealtime) ? string.Empty : ("Realtime/PUN: " + HideAppId(AppIdRealtime) + ", "), string.IsNullOrEmpty(AppIdFusion) ? string.Empty : ("Fusion: " + HideAppId(AppIdFusion) + ", "), string.IsNullOrEmpty(AppIdChat) ? string.Empty : ("Chat: " + HideAppId(AppIdChat) + ", "), string.IsNullOrEmpty(AppIdVoice) ? string.Empty : ("Voice: " + HideAppId(AppIdVoice) + ", "), string.IsNullOrEmpty(AppVersion) ? string.Empty : ("AppVersion: " + AppVersion + ", "), "UseNameServer: " + UseNameServer + ", ", "Fixed Region: " + FixedRegion + ", ", string.IsNullOrEmpty(Server) ? string.Empty : ("Server: " + Server + ", "), IsDefaultPort ? string.Empty : ("Port: " + Port + ", "), string.IsNullOrEmpty(ProxyServer) ? string.Empty : ("Proxy: " + ProxyServer + ", "), Protocol, AuthMode);
		}

		public static bool IsAppId(string val)
		{
			try
			{
				new Guid(val);
			}
			catch
			{
				return false;
			}
			return true;
		}

		private string HideAppId(string appId)
		{
			return (string.IsNullOrEmpty(appId) || appId.Length < 8) ? appId : (appId.Substring(0, 8) + "***");
		}

		public AppSettings CopyTo(AppSettings d)
		{
			d.AppIdRealtime = AppIdRealtime;
			d.AppIdFusion = AppIdFusion;
			d.AppIdChat = AppIdChat;
			d.AppIdVoice = AppIdVoice;
			d.AppVersion = AppVersion;
			d.UseNameServer = UseNameServer;
			d.FixedRegion = FixedRegion;
			d.BestRegionSummaryFromStorage = BestRegionSummaryFromStorage;
			d.Server = Server;
			d.Port = Port;
			d.ProxyServer = ProxyServer;
			d.Protocol = Protocol;
			d.AuthMode = AuthMode;
			d.EnableLobbyStatistics = EnableLobbyStatistics;
			d.NetworkLogging = NetworkLogging;
			d.EnableProtocolFallback = EnableProtocolFallback;
			return d;
		}

		public AppSettings GetCopy()
		{
			return CopyTo(new AppSettings());
		}
	}
	internal class ConnectionHandler : MonoBehaviour
	{
		public bool DisconnectAfterKeepAlive = false;

		public int KeepAliveInBackground = 60000;

		public bool ApplyDontDestroyOnLoad = true;

		[NonSerialized]
		public static bool AppQuits;

		[NonSerialized]
		public static bool AppPause;

		[NonSerialized]
		public static bool AppPauseRecent;

		[NonSerialized]
		public static bool AppOutOfFocus;

		[NonSerialized]
		public static bool AppOutOfFocusRecent;

		private bool didSendAcks;

		private readonly Stopwatch backgroundStopwatch = new Stopwatch();

		private System.Threading.Timer stateTimer;

		public LoadBalancingClient Client { get; set; }

		public int CountSendAcksOnly { get; private set; }

		public bool FallbackThreadRunning { get; private set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void StaticReset()
		{
			AppQuits = false;
			AppPause = false;
			AppPauseRecent = false;
			AppOutOfFocus = false;
			AppOutOfFocusRecent = false;
		}

		protected virtual void Awake()
		{
			if (ApplyDontDestroyOnLoad)
			{
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
		}

		protected virtual void OnDisable()
		{
			StopFallbackSendAckThread();
			if (AppQuits)
			{
				if (Client != null && Client.IsConnected)
				{
					Client.Disconnect(DisconnectCause.ApplicationQuit);
					Client.LoadBalancingPeer.StopThread();
					Client.LoadBalancingPeer.IsSimulationEnabled = false;
				}
				SupportClass.StopAllBackgroundCalls();
			}
		}

		public void OnApplicationQuit()
		{
			AppQuits = true;
		}

		public void OnApplicationPause(bool pause)
		{
			AppPause = pause;
			if (pause)
			{
				AppPauseRecent = true;
				CancelInvoke("ResetAppPauseRecent");
			}
			else
			{
				Invoke("ResetAppPauseRecent", 5f);
			}
		}

		private void ResetAppPauseRecent()
		{
			AppPauseRecent = false;
		}

		public void OnApplicationFocus(bool focus)
		{
			AppOutOfFocus = !focus;
			if (!focus)
			{
				AppOutOfFocusRecent = true;
				CancelInvoke("ResetAppOutOfFocusRecent");
			}
			else
			{
				Invoke("ResetAppOutOfFocusRecent", 5f);
			}
		}

		private void ResetAppOutOfFocusRecent()
		{
			AppOutOfFocusRecent = false;
		}

		public static bool IsNetworkReachableUnity()
		{
			return Application.internetReachability != NetworkReachability.NotReachable;
		}

		public void StartFallbackSendAckThread()
		{
			if (RuntimeUnityFlagsSetup.IsUNITY_WEBGL)
			{
				if (!FallbackThreadRunning)
				{
					InvokeRepeating("RealtimeFallbackInvoke", 0.05f, 0.05f);
				}
			}
			else
			{
				if (stateTimer != null)
				{
					return;
				}
				stateTimer = new System.Threading.Timer(RealtimeFallback, null, 50, 50);
			}
			FallbackThreadRunning = true;
		}

		public void StopFallbackSendAckThread()
		{
			if (RuntimeUnityFlagsSetup.IsUNITY_WEBGL)
			{
				if (FallbackThreadRunning)
				{
					CancelInvoke("RealtimeFallbackInvoke");
				}
			}
			else if (stateTimer != null)
			{
				stateTimer.Dispose();
				stateTimer = null;
			}
			FallbackThreadRunning = false;
		}

		public void RealtimeFallbackInvoke()
		{
			RealtimeFallback();
		}

		public void RealtimeFallback(object state = null)
		{
			if (Client == null)
			{
				return;
			}
			if (Client.IsConnected && Client.LoadBalancingPeer.ConnectionTime - Client.LoadBalancingPeer.LastSendOutgoingTime > 100)
			{
				if (!didSendAcks)
				{
					backgroundStopwatch.Reset();
					backgroundStopwatch.Start();
				}
				if (backgroundStopwatch.ElapsedMilliseconds > KeepAliveInBackground)
				{
					if (DisconnectAfterKeepAlive && Client.State != ClientState.Disconnecting)
					{
						Client.Disconnect();
					}
				}
				else
				{
					didSendAcks = true;
					CountSendAcksOnly++;
					Client.LoadBalancingPeer.SendAcksOnly();
				}
			}
			else
			{
				if (backgroundStopwatch.IsRunning)
				{
					backgroundStopwatch.Reset();
				}
				didSendAcks = false;
			}
		}
	}
	internal static class CustomTypesUnity
	{
		private const int SizeV2 = 8;

		private const int SizeV3 = 12;

		private const int SizeQuat = 16;

		public static readonly byte[] memVector3 = new byte[12];

		public static readonly byte[] memVector2 = new byte[8];

		public static readonly byte[] memQuarternion = new byte[16];

		internal static void Register()
		{
			PhotonPeer.RegisterType(typeof(Vector2), 87, SerializeVector2, DeserializeVector2);
			PhotonPeer.RegisterType(typeof(Vector3), 86, SerializeVector3, DeserializeVector3);
			PhotonPeer.RegisterType(typeof(Quaternion), 81, SerializeQuaternion, DeserializeQuaternion);
		}

		private static short SerializeVector3(StreamBuffer outStream, object customobject)
		{
			Vector3 vector = (Vector3)customobject;
			int targetOffset = 0;
			lock (memVector3)
			{
				byte[] array = memVector3;
				ExitGames.Client.Photon.Protocol.Serialize(vector.x, array, ref targetOffset);
				ExitGames.Client.Photon.Protocol.Serialize(vector.y, array, ref targetOffset);
				ExitGames.Client.Photon.Protocol.Serialize(vector.z, array, ref targetOffset);
				outStream.Write(array, 0, 12);
			}
			return 12;
		}

		private static object DeserializeVector3(StreamBuffer inStream, short length)
		{
			Vector3 vector = default(Vector3);
			if (length != 12)
			{
				return vector;
			}
			lock (memVector3)
			{
				inStream.Read(memVector3, 0, 12);
				int offset = 0;
				ExitGames.Client.Photon.Protocol.Deserialize(out vector.x, memVector3, ref offset);
				ExitGames.Client.Photon.Protocol.Deserialize(out vector.y, memVector3, ref offset);
				ExitGames.Client.Photon.Protocol.Deserialize(out vector.z, memVector3, ref offset);
			}
			return vector;
		}

		private static short SerializeVector2(StreamBuffer outStream, object customobject)
		{
			Vector2 vector = (Vector2)customobject;
			lock (memVector2)
			{
				byte[] array = memVector2;
				int targetOffset = 0;
				ExitGames.Client.Photon.Protocol.Serialize(vector.x, array, ref targetOffset);
				ExitGames.Client.Photon.Protocol.Serialize(vector.y, array, ref targetOffset);
				outStream.Write(array, 0, 8);
			}
			return 8;
		}

		private static object DeserializeVector2(StreamBuffer inStream, short length)
		{
			Vector2 vector = default(Vector2);
			if (length != 8)
			{
				return vector;
			}
			lock (memVector2)
			{
				inStream.Read(memVector2, 0, 8);
				int offset = 0;
				ExitGames.Client.Photon.Protocol.Deserialize(out vector.x, memVector2, ref offset);
				ExitGames.Client.Photon.Protocol.Deserialize(out vector.y, memVector2, ref offset);
			}
			return vector;
		}

		private static short SerializeQuaternion(StreamBuffer outStream, object customobject)
		{
			Quaternion quaternion = (Quaternion)customobject;
			lock (memQuarternion)
			{
				byte[] array = memQuarternion;
				int targetOffset = 0;
				ExitGames.Client.Photon.Protocol.Serialize(quaternion.w, array, ref targetOffset);
				ExitGames.Client.Photon.Protocol.Serialize(quaternion.x, array, ref targetOffset);
				ExitGames.Client.Photon.Protocol.Serialize(quaternion.y, array, ref targetOffset);
				ExitGames.Client.Photon.Protocol.Serialize(quaternion.z, array, ref targetOffset);
				outStream.Write(array, 0, 16);
			}
			return 16;
		}

		private static object DeserializeQuaternion(StreamBuffer inStream, short length)
		{
			Quaternion identity = Quaternion.identity;
			if (length != 16)
			{
				return identity;
			}
			lock (memQuarternion)
			{
				inStream.Read(memQuarternion, 0, 16);
				int offset = 0;
				ExitGames.Client.Photon.Protocol.Deserialize(out identity.w, memQuarternion, ref offset);
				ExitGames.Client.Photon.Protocol.Deserialize(out identity.x, memQuarternion, ref offset);
				ExitGames.Client.Photon.Protocol.Deserialize(out identity.y, memQuarternion, ref offset);
				ExitGames.Client.Photon.Protocol.Deserialize(out identity.z, memQuarternion, ref offset);
			}
			return identity;
		}
	}
	internal static class Extensions
	{
		private static readonly List<object> keysWithNullValue = new List<object>();

		public static void Merge(this IDictionary target, IDictionary addHash)
		{
			if (addHash == null || target.Equals(addHash))
			{
				return;
			}
			foreach (object key in addHash.Keys)
			{
				target[key] = addHash[key];
			}
		}

		public static void MergeStringKeys(this IDictionary target, IDictionary addHash)
		{
			if (addHash == null || target.Equals(addHash))
			{
				return;
			}
			foreach (object key in addHash.Keys)
			{
				if (key is string)
				{
					target[key] = addHash[key];
				}
			}
		}

		public static string ToStringFull(this IDictionary origin)
		{
			return SupportClass.DictionaryToString(origin, includeTypes: false);
		}

		public static string ToStringFull<T>(this List<T> data)
		{
			if (data == null)
			{
				return "null";
			}
			string[] array = new string[data.Count];
			for (int i = 0; i < data.Count; i++)
			{
				object obj = data[i];
				array[i] = ((obj != null) ? obj.ToString() : "null");
			}
			return string.Join(", ", array);
		}

		public static string ToStringFull(this object[] data)
		{
			if (data == null)
			{
				return "null";
			}
			string[] array = new string[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				object obj = data[i];
				array[i] = ((obj != null) ? obj.ToString() : "null");
			}
			return string.Join(", ", array);
		}

		public static ExitGames.Client.Photon.Hashtable StripToStringKeys(this IDictionary original)
		{
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			if (original != null)
			{
				foreach (object key in original.Keys)
				{
					if (key is string)
					{
						hashtable[key] = original[key];
					}
				}
			}
			return hashtable;
		}

		public static ExitGames.Client.Photon.Hashtable StripToStringKeys(this ExitGames.Client.Photon.Hashtable original)
		{
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			if (original != null)
			{
				foreach (DictionaryEntry item in original)
				{
					if (item.Key is string)
					{
						hashtable[item.Key] = original[item.Key];
					}
				}
			}
			return hashtable;
		}

		public static void StripKeysWithNullValues(this IDictionary original)
		{
			lock (keysWithNullValue)
			{
				keysWithNullValue.Clear();
				foreach (DictionaryEntry item in original)
				{
					if (item.Value == null)
					{
						keysWithNullValue.Add(item.Key);
					}
				}
				for (int i = 0; i < keysWithNullValue.Count; i++)
				{
					object key = keysWithNullValue[i];
					original.Remove(key);
				}
			}
		}

		public static void StripKeysWithNullValues(this ExitGames.Client.Photon.Hashtable original)
		{
			lock (keysWithNullValue)
			{
				keysWithNullValue.Clear();
				foreach (DictionaryEntry item in original)
				{
					if (item.Value == null)
					{
						keysWithNullValue.Add(item.Key);
					}
				}
				for (int i = 0; i < keysWithNullValue.Count; i++)
				{
					object key = keysWithNullValue[i];
					original.Remove(key);
				}
			}
		}

		public static bool Contains(this int[] target, int nr)
		{
			if (target == null)
			{
				return false;
			}
			for (int i = 0; i < target.Length; i++)
			{
				if (target[i] == nr)
				{
					return true;
				}
			}
			return false;
		}
	}
	internal class FriendInfo
	{
		[Obsolete("Use UserId.")]
		public string Name => UserId;

		public string UserId { get; protected internal set; }

		public bool IsOnline { get; protected internal set; }

		public string Room { get; protected internal set; }

		public bool IsInRoom => IsOnline && !string.IsNullOrEmpty(Room);

		public override string ToString()
		{
			return string.Format("{0}\t is: {1}", UserId, (!IsOnline) ? "offline" : (IsInRoom ? "playing" : "on master"));
		}
	}
	internal enum ClientState
	{
		PeerCreated = 0,
		Authenticating = 1,
		Authenticated = 2,
		JoiningLobby = 3,
		JoinedLobby = 4,
		DisconnectingFromMasterServer = 5,
		[Obsolete("Renamed to DisconnectingFromMasterServer")]
		DisconnectingFromMasterserver = 5,
		ConnectingToGameServer = 6,
		[Obsolete("Renamed to ConnectingToGameServer")]
		ConnectingToGameserver = 6,
		ConnectedToGameServer = 7,
		[Obsolete("Renamed to ConnectedToGameServer")]
		ConnectedToGameserver = 7,
		Joining = 8,
		Joined = 9,
		Leaving = 10,
		DisconnectingFromGameServer = 11,
		[Obsolete("Renamed to DisconnectingFromGameServer")]
		DisconnectingFromGameserver = 11,
		ConnectingToMasterServer = 12,
		[Obsolete("Renamed to ConnectingToMasterServer.")]
		ConnectingToMasterserver = 12,
		Disconnecting = 13,
		Disconnected = 14,
		ConnectedToMasterServer = 15,
		[Obsolete("Renamed to ConnectedToMasterServer.")]
		ConnectedToMasterserver = 15,
		[Obsolete("Renamed to ConnectedToMasterServer.")]
		ConnectedToMaster = 15,
		ConnectingToNameServer = 16,
		ConnectedToNameServer = 17,
		DisconnectingFromNameServer = 18,
		ConnectWithFallbackProtocol = 19
	}
	internal enum JoinType
	{
		CreateRoom,
		JoinRoom,
		JoinRandomRoom,
		JoinRandomOrCreateRoom,
		JoinOrCreateRoom
	}
	internal enum DisconnectCause
	{
		None,
		ExceptionOnConnect,
		DnsExceptionOnConnect,
		ServerAddressInvalid,
		Exception,
		SendException,
		ReceiveException,
		ServerTimeout,
		ClientTimeout,
		DisconnectByServerLogic,
		DisconnectByServerReasonUnknown,
		InvalidAuthentication,
		CustomAuthenticationFailed,
		AuthenticationTicketExpired,
		MaxCcuReached,
		InvalidRegion,
		OperationNotAllowedInCurrentState,
		DisconnectByClientLogic,
		DisconnectByOperationLimit,
		DisconnectByDisconnectMessage,
		ApplicationQuit
	}
	public enum ServerConnection
	{
		MasterServer,
		GameServer,
		NameServer
	}
	internal enum ClientAppType
	{
		Realtime,
		Voice,
		Fusion
	}
	public enum EncryptionMode
	{
		PayloadEncryption = 0,
		DatagramEncryptionGCM = 13
	}
	internal struct PhotonPortDefinition
	{
		public static readonly PhotonPortDefinition AlternativeUdpPorts = new PhotonPortDefinition
		{
			NameServerPort = 27000,
			MasterServerPort = 27001,
			GameServerPort = 27002
		};

		public ushort NameServerPort;

		public ushort MasterServerPort;

		public ushort GameServerPort;
	}
	internal class LoadBalancingClient : IPhotonPeerListener
	{
		private class EncryptionDataParameters
		{
			public const byte Mode = 0;

			public const byte Secret1 = 1;

			public const byte Secret2 = 2;
		}

		private class CallbackTargetChange
		{
			public readonly object Target;

			public readonly bool AddTarget;

			public CallbackTargetChange(object target, bool addTarget)
			{
				Target = target;
				AddTarget = addTarget;
			}
		}

		public AuthModeOption AuthMode = AuthModeOption.Auth;

		public EncryptionMode EncryptionMode = EncryptionMode.PayloadEncryption;

		private object tokenCache;

		public string NameServerHost = "ns.photonengine.io";

		private static readonly Dictionary<ConnectionProtocol, int> ProtocolToNameServerPort = new Dictionary<ConnectionProtocol, int>
		{
			{
				ConnectionProtocol.Udp,
				5058
			},
			{
				ConnectionProtocol.Tcp,
				4533
			},
			{
				ConnectionProtocol.WebSocket,
				80
			},
			{
				ConnectionProtocol.WebSocketSecure,
				443
			}
		};

		public PhotonPortDefinition ServerPortOverrides;

		public Func<string, ServerConnection, string> AddressRewriter;

		public string ProxyServerAddress;

		private ClientState state = ClientState.PeerCreated;

		public ConnectionCallbacksContainer ConnectionCallbackTargets;

		public MatchMakingCallbacksContainer MatchMakingCallbackTargets;

		internal InRoomCallbacksContainer InRoomCallbackTargets;

		internal LobbyCallbacksContainer LobbyCallbackTargets;

		internal WebRpcCallbacksContainer WebRpcCallbackTargets;

		internal ErrorInfoCallbacksContainer ErrorInfoCallbackTargets;

		public string DisconnectMessage;

		public bool TelemetryEnabled = false;

		private bool telemetrySent = false;

		public SystemConnectionSummary SystemConnectionSummary;

		public bool EnableLobbyStatistics;

		private readonly List<TypedLobbyInfo> lobbyStatistics = new List<TypedLobbyInfo>();

		private JoinType lastJoinType;

		private EnterRoomParams enterRoomParamsCache;

		private OperationResponse failedRoomEntryOperation;

		private const int FriendRequestListMax = 512;

		private string[] friendListRequested;

		public RegionHandler RegionHandler;

		private string bestRegionSummaryFromStorage;

		public string SummaryToCache;

		private bool connectToBestRegion = true;

		private readonly Queue<CallbackTargetChange> callbackTargetChanges = new Queue<CallbackTargetChange>();

		private readonly HashSet<object> callbackTargets = new HashSet<object>();

		public int NameServerPortInAppSettings;

		public LoadBalancingPeer LoadBalancingPeer { get; private set; }

		public SerializationProtocol SerializationProtocol
		{
			get
			{
				return LoadBalancingPeer.SerializationProtocolType;
			}
			set
			{
				LoadBalancingPeer.SerializationProtocolType = value;
			}
		}

		public string AppVersion { get; set; }

		public string AppId { get; set; }

		public ClientAppType ClientType { get; set; }

		public AuthenticationValues AuthValues { get; set; }

		public ConnectionProtocol? ExpectedProtocol { get; set; }

		private object TokenForInit
		{
			get
			{
				if (AuthMode == AuthModeOption.Auth)
				{
					return null;
				}
				return (AuthValues != null) ? AuthValues.Token : null;
			}
		}

		public bool IsUsingNameServer { get; set; }

		public string NameServerAddress => GetNameServerAddress();

		[Obsolete("Set port overrides in ServerPortOverrides. Not used anymore!")]
		public bool UseAlternativeUdpPorts { get; set; }

		public bool EnableProtocolFallback { get; set; }

		public string CurrentServerAddress => LoadBalancingPeer.ServerAddress;

		public string MasterServerAddress { get; set; }

		public string GameServerAddress { get; protected internal set; }

		public ServerConnection Server { get; private set; }

		public int ConnectCount { get; private set; }

		public ClientState State
		{
			get
			{
				return state;
			}
			set
			{
				if (state != value)
				{
					ClientState arg = state;
					state = value;
					if (this.StateChanged != null)
					{
						this.StateChanged(arg, state);
					}
				}
			}
		}

		public bool IsConnected => LoadBalancingPeer != null && State != ClientState.PeerCreated && State != ClientState.Disconnected;

		public bool IsConnectedAndReady
		{
			get
			{
				if (LoadBalancingPeer == null)
				{
					return false;
				}
				switch (State)
				{
				case ClientState.PeerCreated:
				case ClientState.Authenticating:
				case ClientState.DisconnectingFromMasterServer:
				case ClientState.ConnectingToGameServer:
				case ClientState.Joining:
				case ClientState.Leaving:
				case ClientState.DisconnectingFromGameServer:
				case ClientState.ConnectingToMasterServer:
				case ClientState.Disconnecting:
				case ClientState.Disconnected:
				case ClientState.ConnectingToNameServer:
				case ClientState.DisconnectingFromNameServer:
					return false;
				default:
					return true;
				}
			}
		}

		public DisconnectCause DisconnectedCause { get; protected set; }

		public bool InLobby => State == ClientState.JoinedLobby;

		public TypedLobby CurrentLobby { get; internal set; }

		public Player LocalPlayer { get; internal set; }

		public string NickName
		{
			get
			{
				return LocalPlayer.NickName;
			}
			set
			{
				if (LocalPlayer != null)
				{
					LocalPlayer.NickName = value;
				}
			}
		}

		public string UserId
		{
			get
			{
				if (AuthValues != null)
				{
					return AuthValues.UserId;
				}
				return null;
			}
			set
			{
				if (AuthValues == null)
				{
					AuthValues = new AuthenticationValues();
				}
				AuthValues.UserId = value;
			}
		}

		public Room CurrentRoom { get; set; }

		public bool InRoom => state == ClientState.Joined && CurrentRoom != null;

		public int PlayersOnMasterCount { get; internal set; }

		public int PlayersInRoomsCount { get; internal set; }

		public int RoomsCount { get; internal set; }

		public bool IsFetchingFriendList => friendListRequested != null;

		public string CloudRegion { get; private set; }

		public string CurrentCluster { get; private set; }

		public event Action<ClientState, ClientState> StateChanged;

		public event Action<EventData> EventReceived;

		public event Action<OperationResponse> OpResponseReceived;

		public LoadBalancingClient(ConnectionProtocol protocol = ConnectionProtocol.Udp)
		{
			ConnectionCallbackTargets = new ConnectionCallbacksContainer(this);
			MatchMakingCallbackTargets = new MatchMakingCallbacksContainer(this);
			InRoomCallbackTargets = new InRoomCallbacksContainer(this);
			LobbyCallbackTargets = new LobbyCallbacksContainer(this);
			WebRpcCallbackTargets = new WebRpcCallbacksContainer(this);
			ErrorInfoCallbackTargets = new ErrorInfoCallbacksContainer(this);
			LoadBalancingPeer = new LoadBalancingPeer(this, protocol);
			LoadBalancingPeer.OnDisconnectMessage += OnDisconnectMessageReceived;
			SerializationProtocol = SerializationProtocol.GpBinaryV18;
			LocalPlayer = CreatePlayer(string.Empty, -1, isLocal: true, null);
			CustomTypesUnity.Register();
			if (RuntimeUnityFlagsSetup.IsUNITY_WEBGL && (LoadBalancingPeer.TransportProtocol == ConnectionProtocol.Tcp || LoadBalancingPeer.TransportProtocol == ConnectionProtocol.Udp))
			{
				LoadBalancingPeer.Listener.DebugReturn(DebugLevel.WARNING, "WebGL requires WebSockets. Switching TransportProtocol to WebSocketSecure.");
				LoadBalancingPeer.TransportProtocol = ConnectionProtocol.WebSocketSecure;
			}
			State = ClientState.PeerCreated;
		}

		public LoadBalancingClient(string masterAddress, string appId, string gameVersion, ConnectionProtocol protocol = ConnectionProtocol.Udp)
			: this(protocol)
		{
			MasterServerAddress = masterAddress;
			AppId = appId;
			AppVersion = gameVersion;
		}

		private string GetNameServerAddress()
		{
			int value = 0;
			ProtocolToNameServerPort.TryGetValue(LoadBalancingPeer.TransportProtocol, out value);
			if (NameServerPortInAppSettings != 0)
			{
				DebugReturn(DebugLevel.INFO, $"Using NameServerPortInAppSettings: {NameServerPortInAppSettings}");
				value = NameServerPortInAppSettings;
			}
			if (ServerPortOverrides.NameServerPort > 0)
			{
				value = ServerPortOverrides.NameServerPort;
			}
			return ToProtocolAddress(NameServerHost, value, LoadBalancingPeer.TransportProtocol);
		}

		private string ToProtocolAddress(string address, int port, ConnectionProtocol protocol)
		{
			string empty = string.Empty;
			switch (protocol)
			{
			case ConnectionProtocol.Udp:
			case ConnectionProtocol.Tcp:
				return $"{address}:{port}";
			case ConnectionProtocol.WebSocket:
				empty = "ws://";
				break;
			case ConnectionProtocol.WebSocketSecure:
				empty = "wss://";
				break;
			default:
				throw new ArgumentOutOfRangeException($"Can not handle protocol: {protocol}.");
			}
			Uri uri = new Uri(empty + address);
			string text = $"{uri.Scheme}://{uri.Host}:{port}{uri.AbsolutePath}";
			if (AddressRewriter != null)
			{
				text = AddressRewriter(text, ServerConnection.NameServer);
			}
			return text;
		}

		public virtual bool ConnectUsingSettings(AppSettings appSettings)
		{
			if (LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
			{
				DebugReturn(DebugLevel.WARNING, "ConnectUsingSettings() failed. Can only connect while in state 'Disconnected'. Current state: " + LoadBalancingPeer.PeerState);
				return false;
			}
			if (appSettings == null)
			{
				DebugReturn(DebugLevel.ERROR, "ConnectUsingSettings failed. The appSettings can't be null.'");
				return false;
			}
			switch (ClientType)
			{
			case ClientAppType.Realtime:
				AppId = appSettings.AppIdRealtime;
				break;
			case ClientAppType.Voice:
				AppId = appSettings.AppIdVoice;
				break;
			case ClientAppType.Fusion:
				AppId = appSettings.AppIdFusion;
				break;
			}
			AppVersion = appSettings.AppVersion;
			IsUsingNameServer = appSettings.UseNameServer;
			CloudRegion = appSettings.FixedRegion;
			connectToBestRegion = string.IsNullOrEmpty(CloudRegion);
			EnableLobbyStatistics = appSettings.EnableLobbyStatistics;
			LoadBalancingPeer.DebugOut = appSettings.NetworkLogging;
			AuthMode = appSettings.AuthMode;
			if (appSettings.AuthMode == AuthModeOption.AuthOnceWss)
			{
				LoadBalancingPeer.TransportProtocol = ConnectionProtocol.WebSocketSecure;
				ExpectedProtocol = appSettings.Protocol;
			}
			else
			{
				LoadBalancingPeer.TransportProtocol = appSettings.Protocol;
				ExpectedProtocol = null;
			}
			EnableProtocolFallback = appSettings.EnableProtocolFallback;
			bestRegionSummaryFromStorage = appSettings.BestRegionSummaryFromStorage;
			DisconnectedCause = DisconnectCause.None;
			DisconnectMessage = null;
			SystemConnectionSummary = null;
			CheckConnectSetupWebGl();
			if (IsUsingNameServer)
			{
				Server = ServerConnection.NameServer;
				if (!appSettings.IsDefaultNameServer)
				{
					NameServerHost = appSettings.Server;
				}
				ProxyServerAddress = appSettings.ProxyServer;
				NameServerPortInAppSettings = appSettings.Port;
				if (!LoadBalancingPeer.Connect(NameServerAddress, ProxyServerAddress, AppId, TokenForInit))
				{
					return false;
				}
				State = ClientState.ConnectingToNameServer;
			}
			else
			{
				Server = ServerConnection.MasterServer;
				int port = (appSettings.IsDefaultPort ? 5055 : appSettings.Port);
				MasterServerAddress = ToProtocolAddress(appSettings.Server, port, LoadBalancingPeer.TransportProtocol);
				if (!LoadBalancingPeer.Connect(MasterServerAddress, ProxyServerAddress, AppId, TokenForInit))
				{
					return false;
				}
				State = ClientState.ConnectingToMasterServer;
			}
			return true;
		}

		[Obsolete("Use ConnectToMasterServer() instead.")]
		public bool Connect()
		{
			return ConnectToMasterServer();
		}

		public virtual bool ConnectToMasterServer()
		{
			if (LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
			{
				DebugReturn(DebugLevel.WARNING, "ConnectToMasterServer() failed. Can only connect while in state 'Disconnected'. Current state: " + LoadBalancingPeer.PeerState);
				return false;
			}
			if (AuthMode != AuthModeOption.Auth && TokenForInit == null)
			{
				DebugReturn(DebugLevel.ERROR, "Connect() failed. Can't connect to MasterServer with Token == null in AuthMode: " + AuthMode);
				return false;
			}
			CheckConnectSetupWebGl();
			DisconnectedCause = DisconnectCause.None;
			DisconnectMessage = null;
			SystemConnectionSummary = null;
			if (LoadBalancingPeer.Connect(MasterServerAddress, ProxyServerAddress, AppId, TokenForInit))
			{
				connectToBestRegion = false;
				State = ClientState.ConnectingToMasterServer;
				Server = ServerConnection.MasterServer;
				return true;
			}
			return false;
		}

		public bool ConnectToNameServer()
		{
			if (LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
			{
				DebugReturn(DebugLevel.WARNING, "ConnectToNameServer() failed. Can only connect while in state 'Disconnected'. Current state: " + LoadBalancingPeer.PeerState);
				return false;
			}
			IsUsingNameServer = true;
			CloudRegion = null;
			CheckConnectSetupWebGl();
			if (AuthMode == AuthModeOption.AuthOnceWss)
			{
				if (!ExpectedProtocol.HasValue)
				{
					ExpectedProtocol = LoadBalancingPeer.TransportProtocol;
				}
				LoadBalancingPeer.TransportProtocol = ConnectionProtocol.WebSocketSecure;
			}
			DisconnectedCause = DisconnectCause.None;
			DisconnectMessage = null;
			SystemConnectionSummary = null;
			if (LoadBalancingPeer.Connect(NameServerAddress, ProxyServerAddress, "NameServer", TokenForInit))
			{
				connectToBestRegion = false;
				State = ClientState.ConnectingToNameServer;
				Server = ServerConnection.NameServer;
				return true;
			}
			return false;
		}

		public bool ConnectToRegionMaster(string region)
		{
			if (string.IsNullOrEmpty(region))
			{
				DebugReturn(DebugLevel.ERROR, "ConnectToRegionMaster() failed. The region can not be null or empty.");
				return false;
			}
			IsUsingNameServer = true;
			if (State == ClientState.Authenticating)
			{
				if ((int)LoadBalancingPeer.DebugOut >= 3)
				{
					DebugReturn(DebugLevel.INFO, "ConnectToRegionMaster() will skip calling authenticate, as the current state is 'Authenticating'. Just wait for the result.");
				}
				return true;
			}
			if (State == ClientState.ConnectedToNameServer)
			{
				CloudRegion = region;
				bool flag = CallAuthenticate();
				if (flag)
				{
					State = ClientState.Authenticating;
				}
				return flag;
			}
			LoadBalancingPeer.Disconnect();
			CloudRegion = region;
			CheckConnectSetupWebGl();
			if (AuthMode == AuthModeOption.AuthOnceWss)
			{
				if (!ExpectedProtocol.HasValue)
				{
					ExpectedProtocol = LoadBalancingPeer.TransportProtocol;
				}
				LoadBalancingPeer.TransportProtocol = ConnectionProtocol.WebSocketSecure;
			}
			connectToBestRegion = false;
			DisconnectedCause = DisconnectCause.None;
			DisconnectMessage = null;
			SystemConnectionSummary = null;
			if (!LoadBalancingPeer.Connect(NameServerAddress, ProxyServerAddress, "NameServer", null))
			{
				return false;
			}
			State = ClientState.ConnectingToNameServer;
			Server = ServerConnection.NameServer;
			return true;
		}

		private void CheckConnectSetupWebGl()
		{
			if (RuntimeUnityFlagsSetup.IsUNITY_WEBGL)
			{
				if (LoadBalancingPeer.TransportProtocol != ConnectionProtocol.WebSocket && LoadBalancingPeer.TransportProtocol != ConnectionProtocol.WebSocketSecure)
				{
					DebugReturn(DebugLevel.WARNING, "WebGL requires WebSockets. Switching TransportProtocol to WebSocketSecure.");
					LoadBalancingPeer.TransportProtocol = ConnectionProtocol.WebSocketSecure;
				}
				EnableProtocolFallback = false;
			}
		}

		private bool Connect(string serverAddress, string proxyServerAddress, ServerConnection serverType)
		{
			if (State == ClientState.Disconnecting)
			{
				DebugReturn(DebugLevel.ERROR, "Connect() failed. Can't connect while disconnecting (still). Current state: " + State);
				return false;
			}
			if (AuthMode != AuthModeOption.Auth && serverType != ServerConnection.NameServer && TokenForInit == null)
			{
				DebugReturn(DebugLevel.ERROR, "Connect() failed. Can't connect to " + serverType.ToString() + " with Token == null in AuthMode: " + AuthMode);
				return false;
			}
			DisconnectedCause = DisconnectCause.None;
			SystemConnectionSummary = null;
			bool flag = LoadBalancingPeer.Connect(serverAddress, proxyServerAddress, AppId, TokenForInit);
			if (flag)
			{
				Server = serverType;
				switch (serverType)
				{
				case ServerConnection.NameServer:
					State = ClientState.ConnectingToNameServer;
					break;
				case ServerConnection.MasterServer:
					State = ClientState.ConnectingToMasterServer;
					break;
				case ServerConnection.GameServer:
					State = ClientState.ConnectingToGameServer;
					break;
				}
			}
			return flag;
		}

		public bool ReconnectToMaster()
		{
			if (LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
			{
				DebugReturn(DebugLevel.WARNING, "ReconnectToMaster() failed. Can only connect while in state 'Disconnected'. Current state: " + LoadBalancingPeer.PeerState);
				return false;
			}
			if (string.IsNullOrEmpty(MasterServerAddress))
			{
				DebugReturn(DebugLevel.WARNING, "ReconnectToMaster() failed. MasterServerAddress is null or empty.");
				return false;
			}
			if (tokenCache == null)
			{
				DebugReturn(DebugLevel.WARNING, "ReconnectToMaster() failed. It seems the client doesn't have any previous authentication token to re-connect.");
				return false;
			}
			if (AuthValues == null)
			{
				DebugReturn(DebugLevel.WARNING, "ReconnectToMaster() with AuthValues == null is not correct!");
				AuthValues = new AuthenticationValues();
			}
			AuthValues.Token = tokenCache;
			return Connect(MasterServerAddress, ProxyServerAddress, ServerConnection.MasterServer);
		}

		public bool ReconnectAndRejoin()
		{
			if (LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
			{
				DebugReturn(DebugLevel.WARNING, "ReconnectAndRejoin() failed. Can only connect while in state 'Disconnected'. Current state: " + LoadBalancingPeer.PeerState);
				return false;
			}
			if (string.IsNullOrEmpty(GameServerAddress))
			{
				DebugReturn(DebugLevel.WARNING, "ReconnectAndRejoin() failed. It seems the client wasn't connected to a game server before (no address).");
				return false;
			}
			if (enterRoomParamsCache == null)
			{
				DebugReturn(DebugLevel.WARNING, "ReconnectAndRejoin() failed. It seems the client doesn't have any previous room to re-join.");
				return false;
			}
			if (tokenCache == null)
			{
				DebugReturn(DebugLevel.WARNING, "ReconnectAndRejoin() failed. It seems the client doesn't have any previous authentication token to re-connect.");
				return false;
			}
			if (AuthValues == null)
			{
				AuthValues = new AuthenticationValues();
			}
			AuthValues.Token = tokenCache;
			if (!string.IsNullOrEmpty(GameServerAddress) && enterRoomParamsCache != null)
			{
				lastJoinType = JoinType.JoinRoom;
				enterRoomParamsCache.JoinMode = JoinMode.RejoinOnly;
				enterRoomParamsCache.Ticket = null;
				return Connect(GameServerAddress, ProxyServerAddress, ServerConnection.GameServer);
			}
			return false;
		}

		public void Disconnect()
		{
			Disconnect(DisconnectCause.DisconnectByClientLogic);
		}

		internal void Disconnect(DisconnectCause cause)
		{
			if (State == ClientState.Disconnecting || State == ClientState.PeerCreated)
			{
				DebugReturn(DebugLevel.INFO, "Disconnect() call gets skipped due to State " + State.ToString() + ". DisconnectedCause: " + DisconnectedCause.ToString() + " Parameter cause: " + cause);
			}
			else if (State != ClientState.Disconnected)
			{
				State = ClientState.Disconnecting;
				DisconnectedCause = cause;
				LoadBalancingPeer.Disconnect();
			}
		}

		private void DisconnectToReconnect()
		{
			switch (Server)
			{
			case ServerConnection.NameServer:
				State = ClientState.DisconnectingFromNameServer;
				break;
			case ServerConnection.MasterServer:
				State = ClientState.DisconnectingFromMasterServer;
				break;
			case ServerConnection.GameServer:
				State = ClientState.DisconnectingFromGameServer;
				break;
			}
			LoadBalancingPeer.Disconnect();
		}

		public void SimulateConnectionLoss(bool simulateTimeout)
		{
			DebugReturn(DebugLevel.WARNING, "SimulateConnectionLoss() set to: " + simulateTimeout);
			if (simulateTimeout)
			{
				LoadBalancingPeer.NetworkSimulationSettings.IncomingLossPercentage = 100;
				LoadBalancingPeer.NetworkSimulationSettings.OutgoingLossPercentage = 100;
			}
			LoadBalancingPeer.IsSimulationEnabled = simulateTimeout;
		}

		private bool CallAuthenticate()
		{
			if (IsUsingNameServer && Server != ServerConnection.NameServer && (AuthValues == null || AuthValues.Token == null))
			{
				DebugReturn(DebugLevel.ERROR, "Authenticate without Token is only allowed on Name Server. Connecting to: " + Server.ToString() + " on: " + CurrentServerAddress + ". State: " + State);
				return false;
			}
			if (AuthMode == AuthModeOption.Auth)
			{
				if (!CheckIfOpCanBeSent(230, Server, "Authenticate"))
				{
					return false;
				}
				return LoadBalancingPeer.OpAuthenticate(AppId, AppVersion, AuthValues, CloudRegion, EnableLobbyStatistics && Server == ServerConnection.MasterServer);
			}
			if (!CheckIfOpCanBeSent(231, Server, "AuthenticateOnce"))
			{
				return false;
			}
			ConnectionProtocol expectedProtocol = (ExpectedProtocol.HasValue ? ExpectedProtocol.Value : LoadBalancingPeer.TransportProtocol);
			return LoadBalancingPeer.OpAuthenticateOnce(AppId, AppVersion, AuthValues, CloudRegion, EncryptionMode, expectedProtocol);
		}

		public void Service()
		{
			if (LoadBalancingPeer != null)
			{
				LoadBalancingPeer.Service();
			}
		}

		private bool OpGetRegions()
		{
			if (!CheckIfOpCanBeSent(220, Server, "GetRegions"))
			{
				return false;
			}
			return LoadBalancingPeer.OpGetRegions(AppId);
		}

		public bool OpFindFriends(string[] friendsToFind, FindFriendsOptions options = null)
		{
			if (!CheckIfOpCanBeSent(222, Server, "FindFriends"))
			{
				return false;
			}
			if (IsFetchingFriendList)
			{
				DebugReturn(DebugLevel.WARNING, "OpFindFriends skipped: already fetching friends list.");
				return false;
			}
			if (friendsToFind == null || friendsToFind.Length == 0)
			{
				DebugReturn(DebugLevel.ERROR, "OpFindFriends skipped: friendsToFind array is null or empty.");
				return false;
			}
			if (friendsToFind.Length > 512)
			{
				DebugReturn(DebugLevel.ERROR, $"OpFindFriends skipped: friendsToFind array exceeds allowed length of {512}.");
				return false;
			}
			List<string> list = new List<string>(friendsToFind.Length);
			for (int i = 0; i < friendsToFind.Length; i++)
			{
				string text = friendsToFind[i];
				if (string.IsNullOrEmpty(text))
				{
					DebugReturn(DebugLevel.WARNING, $"friendsToFind array contains a null or empty UserId, element at position {i} skipped.");
				}
				else if (text.Equals(UserId))
				{
					DebugReturn(DebugLevel.WARNING, $"friendsToFind array contains local player's UserId \"{text}\", element at position {i} skipped.");
				}
				else if (list.Contains(text))
				{
					DebugReturn(DebugLevel.WARNING, $"friendsToFind array contains duplicate UserId \"{text}\", element at position {i} skipped.");
				}
				else
				{
					list.Add(text);
				}
			}
			if (list.Count == 0)
			{
				DebugReturn(DebugLevel.ERROR, "OpFindFriends skipped: friends list to find is empty.");
				return false;
			}
			string[] array = list.ToArray();
			bool flag = LoadBalancingPeer.OpFindFriends(array, options);
			friendListRequested = (flag ? array : null);
			return flag;
		}

		public bool OpJoinLobby(TypedLobby lobby)
		{
			if (!CheckIfOpCanBeSent(229, Server, "JoinLobby"))
			{
				return false;
			}
			if (lobby == null)
			{
				lobby = TypedLobby.Default;
			}
			bool flag = LoadBalancingPeer.OpJoinLobby(lobby);
			if (flag)
			{
				CurrentLobby = lobby;
				State = ClientState.JoiningLobby;
			}
			return flag;
		}

		public bool OpLeaveLobby()
		{
			if (!CheckIfOpCanBeSent(228, Server, "LeaveLobby"))
			{
				return false;
			}
			return LoadBalancingPeer.OpLeaveLobby();
		}

		public bool OpJoinRandomRoom(OpJoinRandomRoomParams opJoinRandomRoomParams = null)
		{
			if (!CheckIfOpCanBeSent(225, Server, "JoinRandomGame"))
			{
				return false;
			}
			if (opJoinRandomRoomParams == null)
			{
				opJoinRandomRoomParams = new OpJoinRandomRoomParams();
			}
			enterRoomParamsCache = new EnterRoomParams();
			enterRoomParamsCache.Lobby = opJoinRandomRoomParams.TypedLobby;
			enterRoomParamsCache.ExpectedUsers = opJoinRandomRoomParams.ExpectedUsers;
			enterRoomParamsCache.Ticket = opJoinRandomRoomParams.Ticket;
			bool flag = LoadBalancingPeer.OpJoinRandomRoom(opJoinRandomRoomParams);
			if (flag)
			{
				lastJoinType = JoinType.JoinRandomRoom;
				State = ClientState.Joining;
			}
			return flag;
		}

		public bool OpJoinRandomOrCreateRoom(OpJoinRandomRoomParams opJoinRandomRoomParams, EnterRoomParams createRoomParams)
		{
			if (!CheckIfOpCanBeSent(225, Server, "OpJoinRandomOrCreateRoom"))
			{
				return false;
			}
			if (opJoinRandomRoomParams == null)
			{
				opJoinRandomRoomParams = new OpJoinRandomRoomParams();
			}
			if (createRoomParams == null)
			{
				createRoomParams = new EnterRoomParams();
			}
			createRoomParams.JoinMode = JoinMode.CreateIfNotExists;
			enterRoomParamsCache = createRoomParams;
			enterRoomParamsCache.Lobby = opJoinRandomRoomParams.TypedLobby;
			enterRoomParamsCache.ExpectedUsers = opJoinRandomRoomParams.ExpectedUsers;
			if (opJoinRandomRoomParams.Ticket != null)
			{
				enterRoomParamsCache.Ticket = opJoinRandomRoomParams.Ticket;
			}
			bool flag = LoadBalancingPeer.OpJoinRandomOrCreateRoom(opJoinRandomRoomParams, createRoomParams);
			if (flag)
			{
				lastJoinType = JoinType.JoinRandomOrCreateRoom;
				State = ClientState.Joining;
			}
			return flag;
		}

		public bool OpCreateRoom(EnterRoomParams enterRoomParams)
		{
			if (!CheckIfOpCanBeSent(227, Server, "CreateGame"))
			{
				return false;
			}
			if (!(enterRoomParams.OnGameServer = Server == ServerConnection.GameServer))
			{
				enterRoomParamsCache = enterRoomParams;
			}
			bool flag = LoadBalancingPeer.OpCreateRoom(enterRoomParams);
			if (flag)
			{
				lastJoinType = JoinType.CreateRoom;
				State = ClientState.Joining;
			}
			return flag;
		}

		public bool OpJoinOrCreateRoom(EnterRoomParams enterRoomParams)
		{
			if (!CheckIfOpCanBeSent(226, Server, "JoinOrCreateRoom"))
			{
				return false;
			}
			bool flag = Server == ServerConnection.GameServer;
			enterRoomParams.JoinMode = JoinMode.CreateIfNotExists;
			enterRoomParams.OnGameServer = flag;
			if (!flag)
			{
				enterRoomParamsCache = enterRoomParams;
			}
			bool flag2 = LoadBalancingPeer.OpJoinRoom(enterRoomParams);
			if (flag2)
			{
				lastJoinType = JoinType.JoinOrCreateRoom;
				State = ClientState.Joining;
			}
			return flag2;
		}

		public bool OpJoinRoom(EnterRoomParams enterRoomParams)
		{
			if (!CheckIfOpCanBeSent(226, Server, "JoinRoom"))
			{
				return false;
			}
			if (!(enterRoomParams.OnGameServer = Server == ServerConnection.GameServer))
			{
				enterRoomParamsCache = enterRoomParams;
			}
			bool flag = LoadBalancingPeer.OpJoinRoom(enterRoomParams);
			if (flag)
			{
				lastJoinType = ((enterRoomParams.JoinMode != JoinMode.CreateIfNotExists) ? JoinType.JoinRoom : JoinType.JoinOrCreateRoom);
				State = ClientState.Joining;
			}
			return flag;
		}

		public bool OpRejoinRoom(string roomName, object ticket = null)
		{
			if (!CheckIfOpCanBeSent(226, Server, "RejoinRoom"))
			{
				return false;
			}
			bool onGameServer = Server == ServerConnection.GameServer;
			EnterRoomParams enterRoomParams = new EnterRoomParams();
			enterRoomParams.RoomName = roomName;
			enterRoomParams.OnGameServer = onGameServer;
			enterRoomParams.JoinMode = JoinMode.RejoinOnly;
			enterRoomParams.Ticket = ticket;
			enterRoomParamsCache = enterRoomParams;
			bool flag = LoadBalancingPeer.OpJoinRoom(enterRoomParams);
			if (flag)
			{
				lastJoinType = JoinType.JoinRoom;
				State = ClientState.Joining;
			}
			return flag;
		}

		public bool OpLeaveRoom(bool becomeInactive, bool sendAuthCookie = false)
		{
			if (!CheckIfOpCanBeSent(254, Server, "LeaveRoom"))
			{
				return false;
			}
			if (LoadBalancingPeer.OpLeaveRoom(becomeInactive, sendAuthCookie))
			{
				State = ClientState.Leaving;
				GameServerAddress = string.Empty;
				enterRoomParamsCache = null;
				return true;
			}
			return false;
		}

		public bool OpGetGameList(TypedLobby typedLobby, string sqlLobbyFilter)
		{
			if (!CheckIfOpCanBeSent(217, Server, "GetGameList"))
			{
				return false;
			}
			if (string.IsNullOrEmpty(sqlLobbyFilter))
			{
				DebugReturn(DebugLevel.ERROR, "Operation GetGameList requires a filter.");
				return false;
			}
			if (typedLobby.Type != LobbyType.SqlLobby)
			{
				DebugReturn(DebugLevel.ERROR, "Operation GetGameList can only be used for lobbies of type SqlLobby.");
				return false;
			}
			return LoadBalancingPeer.OpGetGameList(typedLobby, sqlLobbyFilter);
		}

		public bool OpSetCustomPropertiesOfActor(int actorNr, ExitGames.Client.Photon.Hashtable propertiesToSet, ExitGames.Client.Photon.Hashtable expectedProperties = null, WebFlags webFlags = null)
		{
			if (propertiesToSet == null || propertiesToSet.Count == 0)
			{
				DebugReturn(DebugLevel.ERROR, "OpSetCustomPropertiesOfActor() failed. propertiesToSet must not be null nor empty.");
				return false;
			}
			if (CurrentRoom == null)
			{
				if (expectedProperties == null && webFlags == null && LocalPlayer != null && LocalPlayer.ActorNumber == actorNr)
				{
					return LocalPlayer.SetCustomProperties(propertiesToSet);
				}
				if ((int)LoadBalancingPeer.DebugOut >= 1)
				{
					DebugReturn(DebugLevel.ERROR, "OpSetCustomPropertiesOfActor() failed. To use expectedProperties or webForward, you have to be in a room. State: " + State);
				}
				return false;
			}
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			hashtable.MergeStringKeys(propertiesToSet);
			if (hashtable.Count == 0)
			{
				DebugReturn(DebugLevel.ERROR, "OpSetCustomPropertiesOfActor() failed. Only string keys allowed for custom properties.");
				return false;
			}
			return OpSetPropertiesOfActor(actorNr, hashtable, expectedProperties, webFlags);
		}

		protected internal bool OpSetPropertiesOfActor(int actorNr, ExitGames.Client.Photon.Hashtable actorProperties, ExitGames.Client.Photon.Hashtable expectedProperties = null, WebFlags webFlags = null)
		{
			if (!CheckIfOpCanBeSent(252, Server, "SetProperties"))
			{
				return false;
			}
			if (actorProperties == null || actorProperties.Count == 0)
			{
				DebugReturn(DebugLevel.ERROR, "OpSetPropertiesOfActor() failed. actorProperties must not be null nor empty.");
				return false;
			}
			bool flag = LoadBalancingPeer.OpSetPropertiesOfActor(actorNr, actorProperties, expectedProperties, webFlags);
			if (flag && !CurrentRoom.BroadcastPropertiesChangeToAll && (expectedProperties == null || expectedProperties.Count == 0))
			{
				Player player = CurrentRoom.GetPlayer(actorNr);
				if (player != null)
				{
					player.InternalCacheProperties(actorProperties);
					InRoomCallbackTargets.OnPlayerPropertiesUpdate(player, actorProperties);
				}
			}
			return flag;
		}

		public bool OpSetCustomPropertiesOfRoom(ExitGames.Client.Photon.Hashtable propertiesToSet, ExitGames.Client.Photon.Hashtable expectedProperties = null, WebFlags webFlags = null)
		{
			if (propertiesToSet == null || propertiesToSet.Count == 0)
			{
				DebugReturn(DebugLevel.ERROR, "OpSetCustomPropertiesOfRoom() failed. propertiesToSet must not be null nor empty.");
				return false;
			}
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			hashtable.MergeStringKeys(propertiesToSet);
			if (hashtable.Count == 0)
			{
				DebugReturn(DebugLevel.ERROR, "OpSetCustomPropertiesOfRoom() failed. Only string keys are allowed for custom properties.");
				return false;
			}
			return OpSetPropertiesOfRoom(hashtable, expectedProperties, webFlags);
		}

		protected internal bool OpSetPropertyOfRoom(byte propCode, object value)
		{
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			hashtable[propCode] = value;
			return OpSetPropertiesOfRoom(hashtable);
		}

		protected internal bool OpSetPropertiesOfRoom(ExitGames.Client.Photon.Hashtable gameProperties, ExitGames.Client.Photon.Hashtable expectedProperties = null, WebFlags webFlags = null)
		{
			if (!CheckIfOpCanBeSent(252, Server, "SetProperties"))
			{
				return false;
			}
			if (gameProperties == null || gameProperties.Count == 0)
			{
				DebugReturn(DebugLevel.ERROR, "OpSetPropertiesOfRoom() failed. gameProperties must not be null nor empty.");
				return false;
			}
			bool flag = LoadBalancingPeer.OpSetPropertiesOfRoom(gameProperties, expectedProperties, webFlags);
			if (flag && !CurrentRoom.BroadcastPropertiesChangeToAll && (expectedProperties == null || expectedProperties.Count == 0))
			{
				CurrentRoom.InternalCacheProperties(gameProperties);
				InRoomCallbackTargets.OnRoomPropertiesUpdate(gameProperties);
			}
			return flag;
		}

		public virtual bool OpRaiseEvent(byte eventCode, object customEventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
		{
			if (!CheckIfOpCanBeSent(253, Server, "RaiseEvent"))
			{
				return false;
			}
			return LoadBalancingPeer.OpRaiseEvent(eventCode, customEventContent, raiseEventOptions, sendOptions);
		}

		public virtual bool OpChangeGroups(byte[] groupsToRemove, byte[] groupsToAdd)
		{
			if (!CheckIfOpCanBeSent(248, Server, "ChangeGroups"))
			{
				return false;
			}
			return LoadBalancingPeer.OpChangeGroups(groupsToRemove, groupsToAdd);
		}

		private void ReadoutProperties(ExitGames.Client.Photon.Hashtable gameProperties, ExitGames.Client.Photon.Hashtable actorProperties, int targetActorNr)
		{
			if (CurrentRoom != null && gameProperties != null)
			{
				CurrentRoom.InternalCacheProperties(gameProperties);
				if (InRoom)
				{
					InRoomCallbackTargets.OnRoomPropertiesUpdate(gameProperties);
				}
			}
			if (actorProperties == null || actorProperties.Count <= 0)
			{
				return;
			}
			if (targetActorNr > 0)
			{
				Player player = CurrentRoom.GetPlayer(targetActorNr);
				if (player != null)
				{
					ExitGames.Client.Photon.Hashtable hashtable = ReadoutPropertiesForActorNr(actorProperties, targetActorNr);
					player.InternalCacheProperties(hashtable);
					InRoomCallbackTargets.OnPlayerPropertiesUpdate(player, hashtable);
				}
				return;
			}
			foreach (object key in actorProperties.Keys)
			{
				int num = (int)key;
				if (num != 0)
				{
					ExitGames.Client.Photon.Hashtable hashtable2 = (ExitGames.Client.Photon.Hashtable)actorProperties[key];
					string actorName = (string)hashtable2[byte.MaxValue];
					Player player2 = CurrentRoom.GetPlayer(num);
					if (player2 == null)
					{
						player2 = CreatePlayer(actorName, num, isLocal: false, hashtable2);
						CurrentRoom.StorePlayer(player2);
					}
					player2.InternalCacheProperties(hashtable2);
				}
			}
		}

		private ExitGames.Client.Photon.Hashtable ReadoutPropertiesForActorNr(ExitGames.Client.Photon.Hashtable actorProperties, int actorNr)
		{
			if (actorProperties.ContainsKey(actorNr))
			{
				return (ExitGames.Client.Photon.Hashtable)actorProperties[actorNr];
			}
			return actorProperties;
		}

		public void ChangeLocalID(int newId, bool applyUserId = false)
		{
			if (LocalPlayer == null)
			{
				DebugReturn(DebugLevel.ERROR, "loadBalancingClient.LocalPlayer is null. It should be set in constructor and not changed. Failed to ChangeLocalID.");
				return;
			}
			if (applyUserId && string.IsNullOrEmpty(LocalPlayer.UserId))
			{
				LocalPlayer.UserId = ((AuthValues == null || string.IsNullOrEmpty(AuthValues.UserId)) ? default(Guid).ToString() : AuthValues.UserId);
			}
			if (CurrentRoom == null)
			{
				LocalPlayer.ChangeLocalID(newId);
				LocalPlayer.RoomReference = null;
			}
			else
			{
				CurrentRoom.RemovePlayer(LocalPlayer);
				LocalPlayer.ChangeLocalID(newId);
				CurrentRoom.StorePlayer(LocalPlayer);
			}
		}

		private void GameEnteredOnGameServer(OperationResponse operationResponse)
		{
			CurrentRoom = CreateRoom(enterRoomParamsCache.RoomName, enterRoomParamsCache.RoomOptions);
			CurrentRoom.LoadBalancingClient = this;
			int newId = (int)operationResponse[254];
			ChangeLocalID(newId);
			if (operationResponse.Parameters.ContainsKey(252))
			{
				int[] actorsInGame = (int[])operationResponse.Parameters[252];
				UpdatedActorList(actorsInGame);
			}
			ExitGames.Client.Photon.Hashtable actorProperties = (ExitGames.Client.Photon.Hashtable)operationResponse[249];
			ExitGames.Client.Photon.Hashtable gameProperties = (ExitGames.Client.Photon.Hashtable)operationResponse[248];
			ReadoutProperties(gameProperties, actorProperties, 0);
			if (operationResponse.Parameters.TryGetValue(191, out var value))
			{
				CurrentRoom.InternalCacheRoomFlags((int)value);
			}
			if (CurrentRoom.SuppressRoomEvents)
			{
				State = ClientState.Joined;
				LocalPlayer.UpdateNickNameOnJoined();
				if (lastJoinType == JoinType.CreateRoom || (lastJoinType == JoinType.JoinOrCreateRoom && LocalPlayer.ActorNumber == 1))
				{
					MatchMakingCallbackTargets.OnCreatedRoom();
				}
				MatchMakingCallbackTargets.OnJoinedRoom();
			}
		}

		private void UpdatedActorList(int[] actorsInGame)
		{
			if (actorsInGame == null)
			{
				return;
			}
			foreach (int num in actorsInGame)
			{
				if (num != 0)
				{
					Player player = CurrentRoom.GetPlayer(num);
					if (player == null)
					{
						CurrentRoom.StorePlayer(CreatePlayer(string.Empty, num, isLocal: false, null));
					}
				}
			}
		}

		protected internal virtual Player CreatePlayer(string actorName, int actorNumber, bool isLocal, ExitGames.Client.Photon.Hashtable actorProperties)
		{
			return new Player(actorName, actorNumber, isLocal, actorProperties);
		}

		protected internal virtual Room CreateRoom(string roomName, RoomOptions opt)
		{
			return new Room(roomName, opt);
		}

		private bool CheckIfOpAllowedOnServer(byte opCode, ServerConnection serverConnection)
		{
			switch (serverConnection)
			{
			case ServerConnection.MasterServer:
				switch (opCode)
				{
				case 217:
				case 218:
				case 219:
				case 221:
				case 222:
				case 225:
				case 226:
				case 227:
				case 228:
				case 229:
				case 230:
				case 231:
					return true;
				}
				break;
			case ServerConnection.GameServer:
				switch (opCode)
				{
				case 218:
				case 219:
				case 226:
				case 227:
				case 230:
				case 231:
				case 248:
				case 251:
				case 252:
				case 253:
				case 254:
					return true;
				}
				break;
			case ServerConnection.NameServer:
			{
				byte b = opCode;
				byte b2 = b;
				if (b2 != 218 && b2 != 220 && (uint)(b2 - 230) > 1u)
				{
					break;
				}
				return true;
			}
			default:
				throw new ArgumentOutOfRangeException("serverConnection", serverConnection, null);
			}
			return false;
		}

		private bool CheckIfOpCanBeSent(byte opCode, ServerConnection serverConnection, string opName)
		{
			if (LoadBalancingPeer == null)
			{
				DebugReturn(DebugLevel.ERROR, $"Operation {opName} ({opCode}) can't be sent because peer is null");
				return false;
			}
			if (!CheckIfOpAllowedOnServer(opCode, serverConnection))
			{
				if ((int)LoadBalancingPeer.DebugOut >= 1)
				{
					DebugReturn(DebugLevel.ERROR, $"Operation {opName} ({opCode}) not allowed on current server ({serverConnection})");
				}
				return false;
			}
			if (!CheckIfClientIsReadyToCallOperation(opCode))
			{
				DebugLevel debugLevel = DebugLevel.ERROR;
				if (opCode == 253 && (State == ClientState.Leaving || State == ClientState.Disconnecting || State == ClientState.DisconnectingFromGameServer))
				{
					debugLevel = DebugLevel.INFO;
				}
				if ((int)LoadBalancingPeer.DebugOut >= (int)debugLevel)
				{
					DebugReturn(debugLevel, $"Operation {opName} ({opCode}) not called because client is not connected or not ready yet, client state: {Enum.GetName(typeof(ClientState), State)}");
				}
				return false;
			}
			if (LoadBalancingPeer.PeerState != PeerStateValue.Connected)
			{
				DebugReturn(DebugLevel.ERROR, $"Operation {opName} ({opCode}) can't be sent because peer is not connected, peer state: {LoadBalancingPeer.PeerState}");
				return false;
			}
			return true;
		}

		private bool CheckIfClientIsReadyToCallOperation(byte opCode)
		{
			switch (opCode)
			{
			case 230:
			case 231:
				return IsConnectedAndReady || State == ClientState.ConnectingToNameServer || State == ClientState.ConnectingToMasterServer || State == ClientState.ConnectingToGameServer;
			case 248:
			case 251:
			case 252:
			case 253:
			case 254:
				return InRoom;
			case 226:
			case 227:
				return State == ClientState.ConnectedToMasterServer || InLobby || State == ClientState.ConnectedToGameServer;
			case 228:
				return InLobby;
			case 217:
			case 221:
			case 222:
			case 225:
			case 229:
				return State == ClientState.ConnectedToMasterServer || InLobby;
			case 220:
				return State == ClientState.ConnectedToNameServer;
			default:
				return IsConnected;
			}
		}

		public virtual void DebugReturn(DebugLevel level, string message)
		{
			if (LoadBalancingPeer.DebugOut == DebugLevel.ALL || (int)level <= (int)LoadBalancingPeer.DebugOut)
			{
				switch (level)
				{
				case DebugLevel.ERROR:
					Debug_.LogError(message);
					break;
				case DebugLevel.WARNING:
					Debug_.LogWarning(message);
					break;
				case DebugLevel.INFO:
					Debug_.Log(message);
					break;
				case DebugLevel.ALL:
					Debug_.Log(message);
					break;
				}
			}
		}

		private void CallbackRoomEnterFailed(OperationResponse operationResponse)
		{
			if (operationResponse.ReturnCode != 0)
			{
				if (operationResponse.OperationCode == 226)
				{
					MatchMakingCallbackTargets.OnJoinRoomFailed(operationResponse.ReturnCode, operationResponse.DebugMessage);
				}
				else if (operationResponse.OperationCode == 227)
				{
					MatchMakingCallbackTargets.OnCreateRoomFailed(operationResponse.ReturnCode, operationResponse.DebugMessage);
				}
				else if (operationResponse.OperationCode == 225)
				{
					MatchMakingCallbackTargets.OnJoinRandomFailed(operationResponse.ReturnCode, operationResponse.DebugMessage);
				}
			}
		}

		public virtual void OnOperationResponse(OperationResponse operationResponse)
		{
			if (operationResponse.Parameters.ContainsKey(221))
			{
				if (AuthValues == null)
				{
					AuthValues = new AuthenticationValues();
				}
				AuthValues.Token = operationResponse.Parameters[221];
				tokenCache = AuthValues.Token;
			}
			if (operationResponse.ReturnCode == 32743)
			{
				Disconnect(DisconnectCause.DisconnectByOperationLimit);
			}
			switch (operationResponse.OperationCode)
			{
			case 230:
			case 231:
			{
				if (operationResponse.Parameters.ContainsKey(187))
				{
					TelemetryEnabled = (bool)operationResponse[187];
				}
				if (operationResponse.ReturnCode != 0)
				{
					DebugReturn(DebugLevel.ERROR, operationResponse.ToStringFull() + " Server: " + Server.ToString() + " Address: " + LoadBalancingPeer.ServerAddress);
					switch (operationResponse.ReturnCode)
					{
					case short.MaxValue:
						DisconnectedCause = DisconnectCause.InvalidAuthentication;
						break;
					case 32755:
						DisconnectedCause = DisconnectCause.CustomAuthenticationFailed;
						ConnectionCallbackTargets.OnCustomAuthenticationFailed(operationResponse.DebugMessage);
						break;
					case 32756:
						DisconnectedCause = DisconnectCause.InvalidRegion;
						break;
					case 32757:
						DisconnectedCause = DisconnectCause.MaxCcuReached;
						break;
					case -3:
					case -2:
						DisconnectedCause = DisconnectCause.OperationNotAllowedInCurrentState;
						break;
					case 32753:
						DisconnectedCause = DisconnectCause.AuthenticationTicketExpired;
						break;
					}
					DisconnectMessage = $"Op: {operationResponse.OperationCode} ReturnCode: {operationResponse.ReturnCode} '{operationResponse.DebugMessage}'";
					Disconnect(DisconnectedCause);
					break;
				}
				if (Server == ServerConnection.NameServer || Server == ServerConnection.MasterServer)
				{
					if (operationResponse.Parameters.ContainsKey(225))
					{
						string text3 = (string)operationResponse.Parameters[225];
						if (!string.IsNullOrEmpty(text3))
						{
							UserId = text3;
							LocalPlayer.UserId = text3;
							DebugReturn(DebugLevel.INFO, $"Received your UserID from server. Updating local value to: {UserId}");
						}
					}
					if (operationResponse.Parameters.ContainsKey(202))
					{
						NickName = (string)operationResponse.Parameters[202];
						DebugReturn(DebugLevel.INFO, $"Received your NickName from server. Updating local value to: {NickName}");
					}
					if (operationResponse.Parameters.ContainsKey(192))
					{
						SetupEncryption((Dictionary<byte, object>)operationResponse.Parameters[192]);
					}
				}
				if (Server == ServerConnection.NameServer)
				{
					if (AuthMode == AuthModeOption.AuthOnceWss && ExpectedProtocol.HasValue)
					{
						DebugReturn(DebugLevel.INFO, $"AuthOnceWss mode. Auth response switches TransportProtocol to ExpectedProtocol: {ExpectedProtocol}.");
						LoadBalancingPeer.TransportProtocol = ExpectedProtocol.Value;
						ExpectedProtocol = null;
					}
					string text4 = operationResponse[196] as string;
					if (!string.IsNullOrEmpty(text4))
					{
						CurrentCluster = text4;
					}
					MasterServerAddress = operationResponse[230] as string;
					if (ServerPortOverrides.MasterServerPort != 0)
					{
						MasterServerAddress = ReplacePortWithAlternative(MasterServerAddress, ServerPortOverrides.MasterServerPort);
					}
					if (AddressRewriter != null)
					{
						MasterServerAddress = AddressRewriter(MasterServerAddress, ServerConnection.MasterServer);
					}
					DisconnectToReconnect();
				}
				else if (Server == ServerConnection.MasterServer)
				{
					State = ClientState.ConnectedToMasterServer;
					if (failedRoomEntryOperation == null)
					{
						ConnectionCallbackTargets.OnConnectedToMaster();
					}
					else
					{
						CallbackRoomEnterFailed(failedRoomEntryOperation);
						failedRoomEntryOperation = null;
					}
					if (AuthMode != AuthModeOption.Auth)
					{
						LoadBalancingPeer.OpSettings(EnableLobbyStatistics);
					}
				}
				else if (Server == ServerConnection.GameServer)
				{
					State = ClientState.Joining;
					if (enterRoomParamsCache.JoinMode == JoinMode.RejoinOnly)
					{
						enterRoomParamsCache.PlayerProperties = null;
					}
					else
					{
						ExitGames.Client.Photon.Hashtable hashtable2 = new ExitGames.Client.Photon.Hashtable();
						hashtable2.Merge(LocalPlayer.CustomProperties);
						if (!string.IsNullOrEmpty(LocalPlayer.NickName))
						{
							hashtable2[byte.MaxValue] = LocalPlayer.NickName;
						}
						enterRoomParamsCache.PlayerProperties = hashtable2;
					}
					enterRoomParamsCache.OnGameServer = true;
					if (lastJoinType == JoinType.JoinRoom || lastJoinType == JoinType.JoinRandomRoom || lastJoinType == JoinType.JoinRandomOrCreateRoom || lastJoinType == JoinType.JoinOrCreateRoom)
					{
						LoadBalancingPeer.OpJoinRoom(enterRoomParamsCache);
					}
					else if (lastJoinType == JoinType.CreateRoom)
					{
						LoadBalancingPeer.OpCreateRoom(enterRoomParamsCache);
					}
					break;
				}
				Dictionary<string, object> dictionary = (Dictionary<string, object>)operationResponse[245];
				if (dictionary != null)
				{
					ConnectionCallbackTargets.OnCustomAuthenticationResponse(dictionary);
				}
				break;
			}
			case 220:
				if (operationResponse.ReturnCode == short.MaxValue)
				{
					DebugReturn(DebugLevel.ERROR, string.Format("GetRegions failed. AppId is unknown on the (cloud) server. " + operationResponse.DebugMessage));
					Disconnect(DisconnectCause.InvalidAuthentication);
					break;
				}
				if (operationResponse.ReturnCode != 0)
				{
					DebugReturn(DebugLevel.ERROR, "GetRegions failed. Can't provide regions list. ReturnCode: " + operationResponse.ReturnCode + ": " + operationResponse.DebugMessage);
					Disconnect(DisconnectCause.InvalidAuthentication);
					break;
				}
				if (RegionHandler == null)
				{
					RegionHandler = new RegionHandler(ServerPortOverrides.MasterServerPort);
				}
				if (RegionHandler.IsPinging)
				{
					DebugReturn(DebugLevel.WARNING, "Received an response for OpGetRegions while the RegionHandler is pinging regions already. Skipping this response in favor of completing the current region-pinging.");
					return;
				}
				RegionHandler.SetRegions(operationResponse, this);
				ConnectionCallbackTargets.OnRegionListReceived(RegionHandler);
				if (connectToBestRegion)
				{
					RegionHandler.PingMinimumOfRegions(OnRegionPingCompleted, bestRegionSummaryFromStorage);
				}
				break;
			case 225:
			case 226:
			case 227:
			{
				if (operationResponse.ReturnCode != 0)
				{
					if (Server == ServerConnection.GameServer)
					{
						failedRoomEntryOperation = operationResponse;
						DisconnectToReconnect();
					}
					else
					{
						State = (InLobby ? ClientState.JoinedLobby : ClientState.ConnectedToMasterServer);
						CallbackRoomEnterFailed(operationResponse);
					}
					break;
				}
				if (Server == ServerConnection.GameServer)
				{
					GameEnteredOnGameServer(operationResponse);
					break;
				}
				GameServerAddress = (string)operationResponse[230];
				if (ServerPortOverrides.GameServerPort != 0)
				{
					GameServerAddress = ReplacePortWithAlternative(GameServerAddress, ServerPortOverrides.GameServerPort);
				}
				if (AddressRewriter != null)
				{
					GameServerAddress = AddressRewriter(GameServerAddress, ServerConnection.GameServer);
				}
				string text2 = operationResponse[byte.MaxValue] as string;
				if (!string.IsNullOrEmpty(text2))
				{
					enterRoomParamsCache.RoomName = text2;
				}
				DisconnectToReconnect();
				break;
			}
			case 217:
			{
				if (operationResponse.ReturnCode != 0)
				{
					DebugReturn(DebugLevel.ERROR, "GetGameList failed: " + operationResponse.ToStringFull());
					break;
				}
				List<RoomInfo> list2 = new List<RoomInfo>();
				ExitGames.Client.Photon.Hashtable hashtable = (ExitGames.Client.Photon.Hashtable)operationResponse[222];
				foreach (string key in hashtable.Keys)
				{
					list2.Add(new RoomInfo(key, (ExitGames.Client.Photon.Hashtable)hashtable[key]));
				}
				LobbyCallbackTargets.OnRoomListUpdate(list2);
				break;
			}
			case 229:
				State = ClientState.JoinedLobby;
				LobbyCallbackTargets.OnJoinedLobby();
				break;
			case 228:
				State = ClientState.ConnectedToMasterServer;
				LobbyCallbackTargets.OnLeftLobby();
				break;
			case 254:
				DisconnectToReconnect();
				break;
			case 222:
			{
				if (operationResponse.ReturnCode != 0)
				{
					DebugReturn(DebugLevel.ERROR, "OpFindFriends failed: " + operationResponse.ToStringFull());
					friendListRequested = null;
					break;
				}
				bool[] array = operationResponse[1] as bool[];
				string[] array2 = operationResponse[2] as string[];
				List<FriendInfo> list = new List<FriendInfo>(friendListRequested.Length);
				for (int i = 0; i < friendListRequested.Length; i++)
				{
					FriendInfo friendInfo = new FriendInfo();
					friendInfo.UserId = friendListRequested[i];
					friendInfo.Room = array2[i];
					friendInfo.IsOnline = array[i];
					list.Insert(i, friendInfo);
				}
				friendListRequested = null;
				MatchMakingCallbackTargets.OnFriendListUpdate(list);
				break;
			}
			case 219:
				WebRpcCallbackTargets.OnWebRpcResponse(operationResponse);
				break;
			}
			if (this.OpResponseReceived != null)
			{
				this.OpResponseReceived(operationResponse);
			}
		}

		public virtual void OnStatusChanged(StatusCode statusCode)
		{
			switch (statusCode)
			{
			case StatusCode.Connect:
				ConnectCount++;
				telemetrySent = false;
				if (State == ClientState.ConnectingToNameServer)
				{
					if ((int)LoadBalancingPeer.DebugOut >= 5)
					{
						DebugReturn(DebugLevel.ALL, "Connected to nameserver.");
					}
					Server = ServerConnection.NameServer;
					if (AuthValues != null)
					{
						AuthValues.Token = null;
					}
				}
				if (State == ClientState.ConnectingToGameServer)
				{
					if ((int)LoadBalancingPeer.DebugOut >= 5)
					{
						DebugReturn(DebugLevel.ALL, "Connected to gameserver.");
					}
					Server = ServerConnection.GameServer;
				}
				if (State == ClientState.ConnectingToMasterServer)
				{
					if ((int)LoadBalancingPeer.DebugOut >= 5)
					{
						DebugReturn(DebugLevel.ALL, "Connected to masterserver.");
					}
					Server = ServerConnection.MasterServer;
					ConnectionCallbackTargets.OnConnected();
				}
				if (LoadBalancingPeer.TransportProtocol != ConnectionProtocol.WebSocketSecure)
				{
					if (Server == ServerConnection.NameServer || AuthMode == AuthModeOption.Auth)
					{
						LoadBalancingPeer.EstablishEncryption();
					}
					break;
				}
				goto case StatusCode.EncryptionEstablished;
			case StatusCode.EncryptionEstablished:
				if (Server == ServerConnection.NameServer)
				{
					State = ClientState.ConnectedToNameServer;
					if (string.IsNullOrEmpty(CloudRegion))
					{
						OpGetRegions();
						break;
					}
				}
				else if (AuthMode == AuthModeOption.AuthOnce || AuthMode == AuthModeOption.AuthOnceWss)
				{
					break;
				}
				if (CallAuthenticate())
				{
					State = ClientState.Authenticating;
				}
				else
				{
					DebugReturn(DebugLevel.ERROR, "OpAuthenticate failed. Check log output and AuthValues. State: " + State);
				}
				break;
			case StatusCode.Disconnect:
			{
				friendListRequested = null;
				bool flag = CurrentRoom != null;
				CurrentRoom = null;
				ChangeLocalID(-1);
				if (Server == ServerConnection.GameServer && flag)
				{
					MatchMakingCallbackTargets.OnLeftRoom();
				}
				if (ExpectedProtocol.HasValue && LoadBalancingPeer.TransportProtocol != ExpectedProtocol)
				{
					DebugReturn(DebugLevel.INFO, $"On disconnect switches TransportProtocol to ExpectedProtocol: {ExpectedProtocol}.");
					LoadBalancingPeer.TransportProtocol = ExpectedProtocol.Value;
					ExpectedProtocol = null;
				}
				switch (State)
				{
				case ClientState.ConnectWithFallbackProtocol:
					EnableProtocolFallback = false;
					LoadBalancingPeer.TransportProtocol = ConnectionProtocol.WebSocketSecure;
					NameServerPortInAppSettings = 0;
					ServerPortOverrides = default(PhotonPortDefinition);
					if (LoadBalancingPeer.Connect(NameServerAddress, ProxyServerAddress, AppId, TokenForInit))
					{
						State = ClientState.ConnectingToNameServer;
					}
					break;
				case ClientState.PeerCreated:
				case ClientState.Disconnecting:
					if (AuthValues != null)
					{
						AuthValues.Token = null;
					}
					State = ClientState.Disconnected;
					ConnectionCallbackTargets.OnDisconnected(DisconnectedCause);
					break;
				case ClientState.DisconnectingFromGameServer:
				case ClientState.DisconnectingFromNameServer:
					ConnectToMasterServer();
					break;
				case ClientState.DisconnectingFromMasterServer:
					Connect(GameServerAddress, ProxyServerAddress, ServerConnection.GameServer);
					break;
				case ClientState.Disconnected:
					break;
				default:
				{
					string text = "";
					text = new StackTrace(fNeedFileInfo: true).ToString();
					DebugReturn(DebugLevel.WARNING, "Got a unexpected Disconnect in LoadBalancingClient State: " + State.ToString() + ". Server: " + Server.ToString() + " Trace: " + text);
					if (AuthValues != null)
					{
						AuthValues.Token = null;
					}
					State = ClientState.Disconnected;
					ConnectionCallbackTargets.OnDisconnected(DisconnectedCause);
					break;
				}
				}
				break;
			}
			case StatusCode.DisconnectByServerUserLimit:
				DebugReturn(DebugLevel.ERROR, "This connection was rejected due to the apps CCU limit.");
				DisconnectedCause = DisconnectCause.MaxCcuReached;
				State = ClientState.Disconnecting;
				break;
			case StatusCode.DnsExceptionOnConnect:
				DisconnectedCause = DisconnectCause.DnsExceptionOnConnect;
				State = ClientState.Disconnecting;
				break;
			case StatusCode.ServerAddressInvalid:
				DisconnectedCause = DisconnectCause.ServerAddressInvalid;
				State = ClientState.Disconnecting;
				break;
			case StatusCode.SecurityExceptionOnConnect:
			case StatusCode.ExceptionOnConnect:
			case StatusCode.EncryptionFailedToEstablish:
			{
				SystemConnectionSummary = new SystemConnectionSummary(this);
				DebugReturn(DebugLevel.ERROR, $"Connection lost. OnStatusChanged to {statusCode}. Client state was: {State}. {SystemConnectionSummary.ToString()}");
				DisconnectedCause = DisconnectCause.ExceptionOnConnect;
				ClientState clientState = ClientState.Disconnecting;
				if (State == ClientState.ConnectingToNameServer && EnableProtocolFallback && LoadBalancingPeer.UsedProtocol != ConnectionProtocol.WebSocketSecure)
				{
					clientState = ClientState.ConnectWithFallbackProtocol;
				}
				State = clientState;
				break;
			}
			case StatusCode.Exception:
			case StatusCode.SendError:
			case StatusCode.ExceptionOnReceive:
				SystemConnectionSummary = new SystemConnectionSummary(this);
				DebugReturn(DebugLevel.ERROR, $"Connection lost. OnStatusChanged to {statusCode}. Client state was: {State}. {SystemConnectionSummary.ToString()}");
				DisconnectedCause = DisconnectCause.Exception;
				State = ClientState.Disconnecting;
				break;
			case StatusCode.DisconnectByServerTimeout:
				SystemConnectionSummary = new SystemConnectionSummary(this);
				DebugReturn(DebugLevel.ERROR, $"Connection lost. OnStatusChanged to {statusCode}. Client state was: {State}. {SystemConnectionSummary.ToString()}");
				DisconnectedCause = DisconnectCause.ServerTimeout;
				State = ClientState.Disconnecting;
				break;
			case StatusCode.TimeoutDisconnect:
			{
				SystemConnectionSummary = new SystemConnectionSummary(this);
				DebugReturn(DebugLevel.ERROR, $"Connection lost. OnStatusChanged to {statusCode}. Client state was: {State}. {SystemConnectionSummary.ToString()}");
				DisconnectedCause = DisconnectCause.ClientTimeout;
				ClientState clientState = ClientState.Disconnecting;
				if (State == ClientState.ConnectingToNameServer && EnableProtocolFallback && LoadBalancingPeer.UsedProtocol != ConnectionProtocol.WebSocketSecure)
				{
					clientState = ClientState.ConnectWithFallbackProtocol;
				}
				State = clientState;
				break;
			}
			case StatusCode.DisconnectByServerLogic:
				DisconnectedCause = DisconnectCause.DisconnectByServerLogic;
				State = ClientState.Disconnecting;
				break;
			case StatusCode.DisconnectByServerReasonUnknown:
				DisconnectedCause = DisconnectCause.DisconnectByServerReasonUnknown;
				State = ClientState.Disconnecting;
				break;
			case (StatusCode)1027:
			case (StatusCode)1028:
			case (StatusCode)1029:
			case (StatusCode)1031:
			case (StatusCode)1032:
			case (StatusCode)1033:
			case (StatusCode)1034:
			case (StatusCode)1035:
			case (StatusCode)1036:
			case (StatusCode)1037:
			case (StatusCode)1038:
			case (StatusCode)1045:
			case (StatusCode)1046:
			case (StatusCode)1047:
				break;
			}
		}

		public virtual void OnEvent(EventData photonEvent)
		{
			int sender = photonEvent.Sender;
			Player player = ((CurrentRoom != null) ? CurrentRoom.GetPlayer(sender) : null);
			switch (photonEvent.Code)
			{
			case 229:
			case 230:
			{
				List<RoomInfo> list = new List<RoomInfo>();
				ExitGames.Client.Photon.Hashtable hashtable2 = (ExitGames.Client.Photon.Hashtable)photonEvent[222];
				foreach (string key in hashtable2.Keys)
				{
					list.Add(new RoomInfo(key, (ExitGames.Client.Photon.Hashtable)hashtable2[key]));
				}
				LobbyCallbackTargets.OnRoomListUpdate(list);
				break;
			}
			case byte.MaxValue:
			{
				ExitGames.Client.Photon.Hashtable hashtable = (ExitGames.Client.Photon.Hashtable)photonEvent[249];
				if (player == null)
				{
					if (sender > 0)
					{
						player = CreatePlayer(string.Empty, sender, isLocal: false, hashtable);
						CurrentRoom.StorePlayer(player);
					}
				}
				else
				{
					player.InternalCacheProperties(hashtable);
					player.IsInactive = false;
					player.HasRejoined = sender != LocalPlayer.ActorNumber;
				}
				if (sender == LocalPlayer.ActorNumber)
				{
					int[] actorsInGame = (int[])photonEvent[252];
					UpdatedActorList(actorsInGame);
					player.HasRejoined = enterRoomParamsCache != null && enterRoomParamsCache.JoinMode == JoinMode.RejoinOnly;
					State = ClientState.Joined;
					LocalPlayer.UpdateNickNameOnJoined();
					if (lastJoinType == JoinType.CreateRoom || (lastJoinType == JoinType.JoinOrCreateRoom && LocalPlayer.ActorNumber == 1))
					{
						MatchMakingCallbackTargets.OnCreatedRoom();
					}
					MatchMakingCallbackTargets.OnJoinedRoom();
				}
				else
				{
					InRoomCallbackTargets.OnPlayerEnteredRoom(player);
				}
				break;
			}
			case 254:
				if (player != null)
				{
					bool flag = false;
					if (photonEvent.Parameters.ContainsKey(233))
					{
						flag = (bool)photonEvent.Parameters[233];
					}
					player.IsInactive = flag;
					player.HasRejoined = false;
					if (!flag)
					{
						CurrentRoom.RemovePlayer(sender);
					}
				}
				if (photonEvent.Parameters.ContainsKey(203))
				{
					int num = (int)photonEvent[203];
					if (num != 0)
					{
						CurrentRoom.masterClientId = num;
						InRoomCallbackTargets.OnMasterClientSwitched(CurrentRoom.GetPlayer(num));
					}
				}
				InRoomCallbackTargets.OnPlayerLeftRoom(player);
				break;
			case 253:
			{
				int num2 = 0;
				if (photonEvent.Parameters.ContainsKey(253))
				{
					num2 = (int)photonEvent[253];
				}
				ExitGames.Client.Photon.Hashtable gameProperties = null;
				ExitGames.Client.Photon.Hashtable actorProperties = null;
				if (num2 == 0)
				{
					gameProperties = (ExitGames.Client.Photon.Hashtable)photonEvent[251];
				}
				else
				{
					actorProperties = (ExitGames.Client.Photon.Hashtable)photonEvent[251];
				}
				ReadoutProperties(gameProperties, actorProperties, num2);
				break;
			}
			case 226:
				PlayersInRoomsCount = (int)photonEvent[229];
				RoomsCount = (int)photonEvent[228];
				PlayersOnMasterCount = (int)photonEvent[227];
				break;
			case 224:
			{
				string[] array = photonEvent[213] as string[];
				int[] array2 = photonEvent[229] as int[];
				int[] array3 = photonEvent[228] as int[];
				ByteArraySlice byteArraySlice = photonEvent[212] as ByteArraySlice;
				bool flag2 = byteArraySlice != null;
				byte[] array4 = ((!flag2) ? (photonEvent[212] as byte[]) : byteArraySlice.Buffer);
				lobbyStatistics.Clear();
				for (int i = 0; i < array.Length; i++)
				{
					TypedLobbyInfo typedLobbyInfo = new TypedLobbyInfo();
					typedLobbyInfo.Name = array[i];
					typedLobbyInfo.Type = (LobbyType)array4[i];
					typedLobbyInfo.PlayerCount = array2[i];
					typedLobbyInfo.RoomCount = array3[i];
					lobbyStatistics.Add(typedLobbyInfo);
				}
				if (flag2)
				{
					byteArraySlice.Release();
				}
				LobbyCallbackTargets.OnLobbyStatisticsUpdate(lobbyStatistics);
				break;
			}
			case 251:
				ErrorInfoCallbackTargets.OnErrorInfo(new ErrorInfo(photonEvent));
				break;
			case 223:
				if (AuthValues == null)
				{
					AuthValues = new AuthenticationValues();
				}
				AuthValues.Token = photonEvent[221];
				tokenCache = AuthValues.Token;
				break;
			}
			UpdateCallbackTargets();
			if (this.EventReceived != null)
			{
				this.EventReceived(photonEvent);
			}
		}

		public virtual void OnMessage(object message)
		{
			DebugReturn(DebugLevel.ALL, $"got OnMessage {message}");
		}

		private void OnDisconnectMessageReceived(DisconnectMessage obj)
		{
			DebugReturn(DebugLevel.ERROR, $"Got DisconnectMessage. Code: {obj.Code} Msg: \"{obj.DebugMessage}\". Debug Info: {obj.Parameters.ToStringFull()}");
			DisconnectMessage = $"DisconnectMessage {obj.Code}: {obj.DebugMessage}";
			Disconnect(DisconnectCause.DisconnectByDisconnectMessage);
		}

		private void OnRegionPingCompleted(RegionHandler regionHandler)
		{
			foreach (Region enabledRegion in regionHandler.EnabledRegions)
			{
				Debug_.Log($"OnRegionPingCompleted: {enabledRegion}");
			}
			Debug_.Log($"OnRegionPingCompleted: Best Region={regionHandler.BestRegion}");
			Debug_.Log("RegionPingSummary: " + regionHandler.SummaryToCache);
			SummaryToCache = regionHandler.SummaryToCache;
			ConnectToRegionMaster(regionHandler.BestRegion.Code);
		}

		protected internal static string ReplacePortWithAlternative(string address, ushort replacementPort)
		{
			if (string.IsNullOrEmpty(address) || replacementPort == 0)
			{
				return address;
			}
			if (address.StartsWith("ws"))
			{
				UriBuilder uriBuilder = new UriBuilder(address);
				uriBuilder.Port = replacementPort;
				return uriBuilder.ToString();
			}
			UriBuilder uriBuilder2 = new UriBuilder("scheme://" + address);
			return $"{uriBuilder2.Host}:{replacementPort}";
		}

		private void SetupEncryption(Dictionary<byte, object> encryptionData)
		{
			switch ((EncryptionMode)(byte)encryptionData[0])
			{
			case EncryptionMode.PayloadEncryption:
			{
				byte[] secret = (byte[])encryptionData[1];
				LoadBalancingPeer.InitPayloadEncryption(secret);
				break;
			}
			case EncryptionMode.DatagramEncryptionGCM:
			{
				byte[] encryptionSecret = (byte[])encryptionData[1];
				LoadBalancingPeer.InitDatagramEncryption(encryptionSecret, null, randomizedSequenceNumbers: true, chainingModeGCM: true);
				break;
			}
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public bool OpWebRpc(string uriPath, object parameters, bool sendAuthCookie = false)
		{
			if (string.IsNullOrEmpty(uriPath))
			{
				DebugReturn(DebugLevel.ERROR, "WebRPC method name must not be null nor empty.");
				return false;
			}
			if (!CheckIfOpCanBeSent(219, Server, "WebRpc"))
			{
				return false;
			}
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			dictionary.Add(209, uriPath);
			if (parameters != null)
			{
				dictionary.Add(208, parameters);
			}
			if (sendAuthCookie)
			{
				dictionary.Add(234, (byte)2);
			}
			return LoadBalancingPeer.SendOperation(219, dictionary, SendOptions.SendReliable);
		}

		public void AddCallbackTarget(object target)
		{
			callbackTargetChanges.Enqueue(new CallbackTargetChange(target, addTarget: true));
		}

		public void RemoveCallbackTarget(object target)
		{
			callbackTargetChanges.Enqueue(new CallbackTargetChange(target, addTarget: false));
		}

		protected internal void UpdateCallbackTargets()
		{
			while (callbackTargetChanges.Count > 0)
			{
				CallbackTargetChange callbackTargetChange = callbackTargetChanges.Dequeue();
				if (callbackTargetChange.AddTarget)
				{
					if (callbackTargets.Contains(callbackTargetChange.Target))
					{
						continue;
					}
					callbackTargets.Add(callbackTargetChange.Target);
				}
				else
				{
					if (!callbackTargets.Contains(callbackTargetChange.Target))
					{
						continue;
					}
					callbackTargets.Remove(callbackTargetChange.Target);
				}
				UpdateCallbackTarget(callbackTargetChange, InRoomCallbackTargets);
				UpdateCallbackTarget(callbackTargetChange, ConnectionCallbackTargets);
				UpdateCallbackTarget(callbackTargetChange, MatchMakingCallbackTargets);
				UpdateCallbackTarget(callbackTargetChange, LobbyCallbackTargets);
				UpdateCallbackTarget(callbackTargetChange, WebRpcCallbackTargets);
				UpdateCallbackTarget(callbackTargetChange, ErrorInfoCallbackTargets);
				if (callbackTargetChange.Target is IOnEventCallback onEventCallback)
				{
					if (callbackTargetChange.AddTarget)
					{
						EventReceived += onEventCallback.OnEvent;
					}
					else
					{
						EventReceived -= onEventCallback.OnEvent;
					}
				}
			}
		}

		private void UpdateCallbackTarget<T>(CallbackTargetChange change, List<T> container) where T : class
		{
			if (change.Target is T item)
			{
				if (change.AddTarget)
				{
					container.Add(item);
				}
				else
				{
					container.Remove(item);
				}
			}
		}
	}
	internal interface IConnectionCallbacks
	{
		void OnConnected();

		void OnConnectedToMaster();

		void OnDisconnected(DisconnectCause cause);

		void OnRegionListReceived(RegionHandler regionHandler);

		void OnCustomAuthenticationResponse(Dictionary<string, object> data);

		void OnCustomAuthenticationFailed(string debugMessage);
	}
	internal interface ILobbyCallbacks
	{
		void OnJoinedLobby();

		void OnLeftLobby();

		void OnRoomListUpdate(List<RoomInfo> roomList);

		void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics);
	}
	internal interface IMatchmakingCallbacks
	{
		void OnFriendListUpdate(List<FriendInfo> friendList);

		void OnCreatedRoom();

		void OnCreateRoomFailed(short returnCode, string message);

		void OnJoinedRoom();

		void OnJoinRoomFailed(short returnCode, string message);

		void OnJoinRandomFailed(short returnCode, string message);

		void OnLeftRoom();
	}
	internal interface IInRoomCallbacks
	{
		void OnPlayerEnteredRoom(Player newPlayer);

		void OnPlayerLeftRoom(Player otherPlayer);

		void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged);

		void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps);

		void OnMasterClientSwitched(Player newMasterClient);
	}
	internal interface IOnEventCallback
	{
		void OnEvent(EventData photonEvent);
	}
	internal interface IWebRpcCallback
	{
		void OnWebRpcResponse(OperationResponse response);
	}
	internal interface IErrorInfoCallback
	{
		void OnErrorInfo(ErrorInfo errorInfo);
	}
	internal class ConnectionCallbacksContainer : List<IConnectionCallbacks>, IConnectionCallbacks
	{
		private readonly LoadBalancingClient client;

		public ConnectionCallbacksContainer(LoadBalancingClient client)
		{
			this.client = client;
		}

		public void OnConnected()
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IConnectionCallbacks current = enumerator.Current;
				current.OnConnected();
			}
		}

		public void OnConnectedToMaster()
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IConnectionCallbacks current = enumerator.Current;
				current.OnConnectedToMaster();
			}
		}

		public void OnRegionListReceived(RegionHandler regionHandler)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IConnectionCallbacks current = enumerator.Current;
				current.OnRegionListReceived(regionHandler);
			}
		}

		public void OnDisconnected(DisconnectCause cause)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IConnectionCallbacks current = enumerator.Current;
				current.OnDisconnected(cause);
			}
		}

		public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IConnectionCallbacks current = enumerator.Current;
				current.OnCustomAuthenticationResponse(data);
			}
		}

		public void OnCustomAuthenticationFailed(string debugMessage)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IConnectionCallbacks current = enumerator.Current;
				current.OnCustomAuthenticationFailed(debugMessage);
			}
		}
	}
	internal class MatchMakingCallbacksContainer : List<IMatchmakingCallbacks>, IMatchmakingCallbacks
	{
		private readonly LoadBalancingClient client;

		public MatchMakingCallbacksContainer(LoadBalancingClient client)
		{
			this.client = client;
		}

		public void OnCreatedRoom()
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IMatchmakingCallbacks current = enumerator.Current;
				current.OnCreatedRoom();
			}
		}

		public void OnJoinedRoom()
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IMatchmakingCallbacks current = enumerator.Current;
				current.OnJoinedRoom();
			}
		}

		public void OnCreateRoomFailed(short returnCode, string message)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IMatchmakingCallbacks current = enumerator.Current;
				current.OnCreateRoomFailed(returnCode, message);
			}
		}

		public void OnJoinRandomFailed(short returnCode, string message)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IMatchmakingCallbacks current = enumerator.Current;
				current.OnJoinRandomFailed(returnCode, message);
			}
		}

		public void OnJoinRoomFailed(short returnCode, string message)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IMatchmakingCallbacks current = enumerator.Current;
				current.OnJoinRoomFailed(returnCode, message);
			}
		}

		public void OnLeftRoom()
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IMatchmakingCallbacks current = enumerator.Current;
				current.OnLeftRoom();
			}
		}

		public void OnFriendListUpdate(List<FriendInfo> friendList)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IMatchmakingCallbacks current = enumerator.Current;
				current.OnFriendListUpdate(friendList);
			}
		}
	}
	internal class InRoomCallbacksContainer : List<IInRoomCallbacks>, IInRoomCallbacks
	{
		private readonly LoadBalancingClient client;

		public InRoomCallbacksContainer(LoadBalancingClient client)
		{
			this.client = client;
		}

		public void OnPlayerEnteredRoom(Player newPlayer)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IInRoomCallbacks current = enumerator.Current;
				current.OnPlayerEnteredRoom(newPlayer);
			}
		}

		public void OnPlayerLeftRoom(Player otherPlayer)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IInRoomCallbacks current = enumerator.Current;
				current.OnPlayerLeftRoom(otherPlayer);
			}
		}

		public void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IInRoomCallbacks current = enumerator.Current;
				current.OnRoomPropertiesUpdate(propertiesThatChanged);
			}
		}

		public void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProp)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IInRoomCallbacks current = enumerator.Current;
				current.OnPlayerPropertiesUpdate(targetPlayer, changedProp);
			}
		}

		public void OnMasterClientSwitched(Player newMasterClient)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IInRoomCallbacks current = enumerator.Current;
				current.OnMasterClientSwitched(newMasterClient);
			}
		}
	}
	internal class LobbyCallbacksContainer : List<ILobbyCallbacks>, ILobbyCallbacks
	{
		private readonly LoadBalancingClient client;

		public LobbyCallbacksContainer(LoadBalancingClient client)
		{
			this.client = client;
		}

		public void OnJoinedLobby()
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				ILobbyCallbacks current = enumerator.Current;
				current.OnJoinedLobby();
			}
		}

		public void OnLeftLobby()
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				ILobbyCallbacks current = enumerator.Current;
				current.OnLeftLobby();
			}
		}

		public void OnRoomListUpdate(List<RoomInfo> roomList)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				ILobbyCallbacks current = enumerator.Current;
				current.OnRoomListUpdate(roomList);
			}
		}

		public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				ILobbyCallbacks current = enumerator.Current;
				current.OnLobbyStatisticsUpdate(lobbyStatistics);
			}
		}
	}
	internal class WebRpcCallbacksContainer : List<IWebRpcCallback>, IWebRpcCallback
	{
		private LoadBalancingClient client;

		public WebRpcCallbacksContainer(LoadBalancingClient client)
		{
			this.client = client;
		}

		public void OnWebRpcResponse(OperationResponse response)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IWebRpcCallback current = enumerator.Current;
				current.OnWebRpcResponse(response);
			}
		}
	}
	internal class ErrorInfoCallbacksContainer : List<IErrorInfoCallback>, IErrorInfoCallback
	{
		private LoadBalancingClient client;

		public ErrorInfoCallbacksContainer(LoadBalancingClient client)
		{
			this.client = client;
		}

		public void OnErrorInfo(ErrorInfo errorInfo)
		{
			client.UpdateCallbackTargets();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				IErrorInfoCallback current = enumerator.Current;
				current.OnErrorInfo(errorInfo);
			}
		}
	}
	internal class ErrorInfo
	{
		public readonly string Info;

		public ErrorInfo(EventData eventData)
		{
			Info = eventData[218] as string;
		}

		public override string ToString()
		{
			return $"ErrorInfo: {Info}";
		}
	}
	internal class LoadBalancingPeer : PhotonPeer
	{
		private readonly Pool<ParameterDictionary> paramDictionaryPool = new Pool<ParameterDictionary>(() => new ParameterDictionary(), delegate(ParameterDictionary x)
		{
			x.Clear();
		}, 1);

		[Obsolete("Use RegionHandler.PingImplementation directly.")]
		protected internal static Type PingImplementation
		{
			get
			{
				return RegionHandler.PingImplementation;
			}
			set
			{
				RegionHandler.PingImplementation = value;
			}
		}

		public LoadBalancingPeer(ConnectionProtocol protocolType)
			: base(protocolType)
		{
			ConfigUnitySockets();
		}

		public LoadBalancingPeer(IPhotonPeerListener listener, ConnectionProtocol protocolType)
			: this(protocolType)
		{
			base.Listener = listener;
		}

		[Conditional("SUPPORTED_UNITY")]
		private void ConfigUnitySockets()
		{
			Type type = null;
			if ((RuntimeUnityFlagsSetup.IsUNITY_XBOXONE || RuntimeUnityFlagsSetup.IsUNITY_GAMECORE) && !RuntimeUnityFlagsSetup.IsUNITY_EDITOR)
			{
				type = Type.GetType("ExitGames.Client.Photon.SocketNativeSource, Assembly-CSharp", throwOnError: false);
				if (type == null)
				{
					type = Type.GetType("ExitGames.Client.Photon.SocketNativeSource, Assembly-CSharp-firstpass", throwOnError: false);
				}
				if (type == null)
				{
					type = Type.GetType("ExitGames.Client.Photon.SocketNativeSource, PhotonRealtime", throwOnError: false);
				}
				if (type != null)
				{
					SocketImplementationConfig[ConnectionProtocol.Udp] = type;
				}
			}
			else
			{
				type = Type.GetType("ExitGames.Client.Photon.SocketWebTcp, PhotonWebSocket", throwOnError: false);
				if (type == null)
				{
					type = Type.GetType("ExitGames.Client.Photon.SocketWebTcp, Assembly-CSharp-firstpass", throwOnError: false);
				}
				if (type == null)
				{
					type = Type.GetType("ExitGames.Client.Photon.SocketWebTcp, Assembly-CSharp", throwOnError: false);
				}
				if (RuntimeUnityFlagsSetup.IsUNITY_WEBGL && type == null && (int)DebugOut >= 2)
				{
					base.Listener.DebugReturn(DebugLevel.WARNING, "SocketWebTcp type not found in the usual Assemblies. This is required as wrapper for the browser WebSocket API. Make sure to make the PhotonLibs\\WebSocket code available.");
				}
			}
			if (type != null)
			{
				SocketImplementationConfig[ConnectionProtocol.WebSocket] = type;
				SocketImplementationConfig[ConnectionProtocol.WebSocketSecure] = type;
			}
		}

		public virtual bool OpGetRegions(string appId)
		{
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>(1);
			dictionary[224] = appId;
			return SendOperation(220, dictionary, new SendOptions
			{
				Reliability = true,
				Encrypt = true
			});
		}

		public virtual bool OpJoinLobby(TypedLobby lobby = null)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinLobby()");
			}
			Dictionary<byte, object> dictionary = null;
			if (lobby != null && !lobby.IsDefault)
			{
				dictionary = new Dictionary<byte, object>();
				dictionary[213] = lobby.Name;
				dictionary[212] = (byte)lobby.Type;
			}
			return SendOperation(229, dictionary, SendOptions.SendReliable);
		}

		public virtual bool OpLeaveLobby()
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpLeaveLobby()");
			}
			return SendOperation((byte)228, (Dictionary<byte, object>)null, SendOptions.SendReliable);
		}

		private void RoomOptionsToOpParameters(Dictionary<byte, object> op, RoomOptions roomOptions, bool usePropertiesKey = false)
		{
			if (roomOptions == null)
			{
				roomOptions = new RoomOptions();
			}
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			hashtable[253] = roomOptions.IsOpen;
			hashtable[254] = roomOptions.IsVisible;
			hashtable[250] = ((roomOptions.CustomRoomPropertiesForLobby == null) ? new string[0] : roomOptions.CustomRoomPropertiesForLobby);
			hashtable.MergeStringKeys(roomOptions.CustomRoomProperties);
			if (roomOptions.MaxPlayers > 0)
			{
				byte b = (byte)((roomOptions.MaxPlayers <= 255) ? ((byte)roomOptions.MaxPlayers) : 0);
				hashtable[byte.MaxValue] = b;
				hashtable[243] = roomOptions.MaxPlayers;
			}
			if (!usePropertiesKey)
			{
				op[248] = hashtable;
			}
			else
			{
				op[251] = hashtable;
			}
			int num = 0;
			if (roomOptions.CleanupCacheOnLeave)
			{
				op[241] = true;
				num |= 2;
			}
			else
			{
				op[241] = false;
				hashtable[249] = false;
			}
			num |= 1;
			op[232] = true;
			if (roomOptions.PlayerTtl > 0 || roomOptions.PlayerTtl == -1)
			{
				op[235] = roomOptions.PlayerTtl;
			}
			if (roomOptions.EmptyRoomTtl > 0)
			{
				op[236] = roomOptions.EmptyRoomTtl;
			}
			if (roomOptions.SuppressRoomEvents)
			{
				num |= 4;
				op[237] = true;
			}
			if (roomOptions.SuppressPlayerInfo)
			{
				num |= 0x40;
			}
			if (roomOptions.Plugins != null)
			{
				op[204] = roomOptions.Plugins;
			}
			if (roomOptions.PublishUserId)
			{
				num |= 8;
				op[239] = true;
			}
			if (roomOptions.DeleteNullProperties)
			{
				num |= 0x10;
			}
			if (roomOptions.BroadcastPropsChangeToAll)
			{
				num |= 0x20;
			}
			op[191] = num;
		}

		public virtual bool OpCreateRoom(EnterRoomParams opParams)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpCreateRoom()");
			}
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			SendOptions sendOptions = new SendOptions
			{
				Reliability = true
			};
			if (!string.IsNullOrEmpty(opParams.RoomName))
			{
				dictionary[byte.MaxValue] = opParams.RoomName;
			}
			if (opParams.Lobby != null && !opParams.Lobby.IsDefault)
			{
				dictionary[213] = opParams.Lobby.Name;
				dictionary[212] = (byte)opParams.Lobby.Type;
			}
			if (opParams.ExpectedUsers != null && opParams.ExpectedUsers.Length != 0)
			{
				dictionary[238] = opParams.ExpectedUsers;
				sendOptions.Encrypt = true;
			}
			if (opParams.Ticket != null)
			{
				dictionary[190] = opParams.Ticket;
			}
			if (opParams.OnGameServer)
			{
				if (opParams.PlayerProperties != null && opParams.PlayerProperties.Count > 0)
				{
					dictionary[249] = opParams.PlayerProperties;
				}
				dictionary[250] = true;
				RoomOptionsToOpParameters(dictionary, opParams.RoomOptions);
			}
			return SendOperation(227, dictionary, sendOptions);
		}

		public virtual bool OpJoinRoom(EnterRoomParams opParams)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinRoom()");
			}
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			SendOptions sendOptions = new SendOptions
			{
				Reliability = true
			};
			if (!string.IsNullOrEmpty(opParams.RoomName))
			{
				dictionary[byte.MaxValue] = opParams.RoomName;
			}
			if (opParams.JoinMode == JoinMode.CreateIfNotExists)
			{
				dictionary[215] = (byte)1;
				if (opParams.Lobby != null && !opParams.Lobby.IsDefault)
				{
					dictionary[213] = opParams.Lobby.Name;
					dictionary[212] = (byte)opParams.Lobby.Type;
				}
			}
			else if (opParams.JoinMode == JoinMode.RejoinOnly)
			{
				dictionary[215] = (byte)3;
			}
			if (opParams.ExpectedUsers != null && opParams.ExpectedUsers.Length != 0)
			{
				dictionary[238] = opParams.ExpectedUsers;
				sendOptions.Encrypt = true;
			}
			if (opParams.Ticket != null)
			{
				dictionary[190] = opParams.Ticket;
			}
			if (opParams.OnGameServer)
			{
				if (opParams.PlayerProperties != null && opParams.PlayerProperties.Count > 0)
				{
					dictionary[249] = opParams.PlayerProperties;
				}
				dictionary[250] = true;
				RoomOptionsToOpParameters(dictionary, opParams.RoomOptions);
			}
			return SendOperation(226, dictionary, sendOptions);
		}

		public virtual bool OpJoinRandomRoom(OpJoinRandomRoomParams opJoinRandomRoomParams)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinRandomRoom()");
			}
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			hashtable.MergeStringKeys(opJoinRandomRoomParams.ExpectedCustomRoomProperties);
			if (opJoinRandomRoomParams.ExpectedMaxPlayers > 0)
			{
				byte b = (byte)((opJoinRandomRoomParams.ExpectedMaxPlayers <= 255) ? ((byte)opJoinRandomRoomParams.ExpectedMaxPlayers) : 0);
				hashtable[byte.MaxValue] = b;
				if (opJoinRandomRoomParams.ExpectedMaxPlayers > 255)
				{
					hashtable[243] = opJoinRandomRoomParams.ExpectedMaxPlayers;
				}
			}
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			SendOptions sendOptions = new SendOptions
			{
				Reliability = true
			};
			if (hashtable.Count > 0)
			{
				dictionary[248] = hashtable;
			}
			if (opJoinRandomRoomParams.MatchingType != MatchmakingMode.FillRoom)
			{
				dictionary[223] = (byte)opJoinRandomRoomParams.MatchingType;
			}
			if (opJoinRandomRoomParams.TypedLobby != null && !opJoinRandomRoomParams.TypedLobby.IsDefault)
			{
				dictionary[213] = opJoinRandomRoomParams.TypedLobby.Name;
				dictionary[212] = (byte)opJoinRandomRoomParams.TypedLobby.Type;
			}
			if (!string.IsNullOrEmpty(opJoinRandomRoomParams.SqlLobbyFilter))
			{
				dictionary[245] = opJoinRandomRoomParams.SqlLobbyFilter;
			}
			if (opJoinRandomRoomParams.ExpectedUsers != null && opJoinRandomRoomParams.ExpectedUsers.Length != 0)
			{
				dictionary[238] = opJoinRandomRoomParams.ExpectedUsers;
				sendOptions.Encrypt = true;
			}
			if (opJoinRandomRoomParams.Ticket != null)
			{
				dictionary[190] = opJoinRandomRoomParams.Ticket;
			}
			dictionary[188] = true;
			return SendOperation(225, dictionary, sendOptions);
		}

		public virtual bool OpJoinRandomOrCreateRoom(OpJoinRandomRoomParams opJoinRandomRoomParams, EnterRoomParams createRoomParams)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinRandomOrCreateRoom()");
			}
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			hashtable.MergeStringKeys(opJoinRandomRoomParams.ExpectedCustomRoomProperties);
			if (opJoinRandomRoomParams.ExpectedMaxPlayers > 0)
			{
				byte b = (byte)((opJoinRandomRoomParams.ExpectedMaxPlayers <= 255) ? ((byte)opJoinRandomRoomParams.ExpectedMaxPlayers) : 0);
				hashtable[byte.MaxValue] = b;
				if (opJoinRandomRoomParams.ExpectedMaxPlayers > 255)
				{
					hashtable[243] = opJoinRandomRoomParams.ExpectedMaxPlayers;
				}
			}
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			SendOptions sendOptions = new SendOptions
			{
				Reliability = true
			};
			if (hashtable.Count > 0)
			{
				dictionary[248] = hashtable;
			}
			if (opJoinRandomRoomParams.MatchingType != MatchmakingMode.FillRoom)
			{
				dictionary[223] = (byte)opJoinRandomRoomParams.MatchingType;
			}
			if (opJoinRandomRoomParams.TypedLobby != null && !opJoinRandomRoomParams.TypedLobby.IsDefault)
			{
				dictionary[213] = opJoinRandomRoomParams.TypedLobby.Name;
				dictionary[212] = (byte)opJoinRandomRoomParams.TypedLobby.Type;
			}
			if (!string.IsNullOrEmpty(opJoinRandomRoomParams.SqlLobbyFilter))
			{
				dictionary[245] = opJoinRandomRoomParams.SqlLobbyFilter;
			}
			if (opJoinRandomRoomParams.ExpectedUsers != null && opJoinRandomRoomParams.ExpectedUsers.Length != 0)
			{
				dictionary[238] = opJoinRandomRoomParams.ExpectedUsers;
				sendOptions.Encrypt = true;
			}
			if (opJoinRandomRoomParams.Ticket != null)
			{
				dictionary[190] = opJoinRandomRoomParams.Ticket;
			}
			dictionary[215] = (byte)1;
			dictionary[188] = true;
			if (createRoomParams != null && !string.IsNullOrEmpty(createRoomParams.RoomName))
			{
				dictionary[byte.MaxValue] = createRoomParams.RoomName;
			}
			return SendOperation(225, dictionary, sendOptions);
		}

		public virtual bool OpLeaveRoom(bool becomeInactive, bool sendAuthCookie = false)
		{
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			if (becomeInactive)
			{
				dictionary[233] = true;
			}
			if (sendAuthCookie)
			{
				dictionary[234] = (byte)2;
			}
			return SendOperation(254, dictionary, SendOptions.SendReliable);
		}

		public virtual bool OpGetGameList(TypedLobby lobby, string queryData)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpGetGameList()");
			}
			if (lobby == null)
			{
				if ((int)DebugOut >= 3)
				{
					base.Listener.DebugReturn(DebugLevel.INFO, "OpGetGameList not sent. Lobby cannot be null.");
				}
				return false;
			}
			if (lobby.Type != LobbyType.SqlLobby)
			{
				if ((int)DebugOut >= 3)
				{
					base.Listener.DebugReturn(DebugLevel.INFO, "OpGetGameList not sent. LobbyType must be SqlLobby.");
				}
				return false;
			}
			if (lobby.IsDefault)
			{
				if ((int)DebugOut >= 3)
				{
					base.Listener.DebugReturn(DebugLevel.INFO, "OpGetGameList not sent. LobbyName must be not null and not empty.");
				}
				return false;
			}
			if (string.IsNullOrEmpty(queryData))
			{
				if ((int)DebugOut >= 3)
				{
					base.Listener.DebugReturn(DebugLevel.INFO, "OpGetGameList not sent. queryData must be not null and not empty.");
				}
				return false;
			}
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			dictionary[213] = lobby.Name;
			dictionary[212] = (byte)lobby.Type;
			dictionary[245] = queryData;
			return SendOperation(217, dictionary, SendOptions.SendReliable);
		}

		public virtual bool OpFindFriends(string[] friendsToFind, FindFriendsOptions options = null)
		{
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			if (friendsToFind != null && friendsToFind.Length != 0)
			{
				dictionary[1] = friendsToFind;
			}
			if (options != null)
			{
				dictionary[2] = options.ToIntFlags();
			}
			SendOptions sendOptions = new SendOptions
			{
				Reliability = true,
				Encrypt = true
			};
			return SendOperation(222, dictionary, sendOptions);
		}

		public bool OpSetCustomPropertiesOfActor(int actorNr, ExitGames.Client.Photon.Hashtable actorProperties)
		{
			return OpSetPropertiesOfActor(actorNr, actorProperties.StripToStringKeys());
		}

		protected internal bool OpSetPropertiesOfActor(int actorNr, ExitGames.Client.Photon.Hashtable actorProperties, ExitGames.Client.Photon.Hashtable expectedProperties = null, WebFlags webflags = null)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfActor()");
			}
			if (actorNr <= 0 || actorProperties == null || actorProperties.Count == 0)
			{
				if ((int)DebugOut >= 3)
				{
					base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfActor not sent. ActorNr must be > 0 and actorProperties must be not null nor empty.");
				}
				return false;
			}
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			dictionary.Add(251, actorProperties);
			dictionary.Add(254, actorNr);
			dictionary.Add(250, true);
			if (expectedProperties != null && expectedProperties.Count != 0)
			{
				dictionary.Add(231, expectedProperties);
			}
			if (webflags != null && webflags.HttpForward)
			{
				dictionary[234] = webflags.WebhookFlags;
			}
			return SendOperation(252, dictionary, SendOptions.SendReliable);
		}

		protected bool OpSetPropertyOfRoom(byte propCode, object value)
		{
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			hashtable[propCode] = value;
			return OpSetPropertiesOfRoom(hashtable);
		}

		public bool OpSetCustomPropertiesOfRoom(ExitGames.Client.Photon.Hashtable gameProperties)
		{
			return OpSetPropertiesOfRoom(gameProperties.StripToStringKeys());
		}

		protected internal bool OpSetPropertiesOfRoom(ExitGames.Client.Photon.Hashtable gameProperties, ExitGames.Client.Photon.Hashtable expectedProperties = null, WebFlags webflags = null)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfRoom()");
			}
			if (gameProperties == null || gameProperties.Count == 0)
			{
				if ((int)DebugOut >= 3)
				{
					base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfRoom not sent. gameProperties must be not null nor empty.");
				}
				return false;
			}
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			dictionary.Add(251, gameProperties);
			dictionary.Add(250, true);
			if (expectedProperties != null && expectedProperties.Count != 0)
			{
				dictionary.Add(231, expectedProperties);
			}
			if (webflags != null && webflags.HttpForward)
			{
				dictionary[234] = webflags.WebhookFlags;
			}
			return SendOperation(252, dictionary, SendOptions.SendReliable);
		}

		public virtual bool OpAuthenticate(string appId, string appVersion, AuthenticationValues authValues, string regionCode, bool getLobbyStatistics)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpAuthenticate()");
			}
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			if (getLobbyStatistics)
			{
				dictionary[211] = true;
			}
			if (authValues != null && authValues.Token != null)
			{
				dictionary[221] = authValues.Token;
				return SendOperation(230, dictionary, SendOptions.SendReliable);
			}
			dictionary[220] = appVersion;
			dictionary[224] = appId;
			if (!string.IsNullOrEmpty(regionCode))
			{
				dictionary[210] = regionCode;
			}
			if (authValues != null)
			{
				if (!string.IsNullOrEmpty(authValues.UserId))
				{
					dictionary[225] = authValues.UserId;
				}
				if (authValues.AuthType != CustomAuthenticationType.None)
				{
					dictionary[217] = (byte)authValues.AuthType;
					if (!string.IsNullOrEmpty(authValues.AuthGetParameters))
					{
						dictionary[216] = authValues.AuthGetParameters;
					}
					if (authValues.AuthPostData != null)
					{
						dictionary[214] = authValues.AuthPostData;
					}
				}
			}
			return SendOperation(230, dictionary, new SendOptions
			{
				Reliability = true,
				Encrypt = true
			});
		}

		public virtual bool OpAuthenticateOnce(string appId, string appVersion, AuthenticationValues authValues, string regionCode, EncryptionMode encryptionMode, ConnectionProtocol expectedProtocol)
		{
			if ((int)DebugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "OpAuthenticateOnce(): authValues = " + authValues?.ToString() + ", region = " + regionCode + ", encryption = " + encryptionMode);
			}
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			if (authValues != null && authValues.Token != null)
			{
				dictionary[221] = authValues.Token;
				return SendOperation(231, dictionary, SendOptions.SendReliable);
			}
			if (encryptionMode == EncryptionMode.DatagramEncryptionGCM && expectedProtocol != ConnectionProtocol.Udp)
			{
				throw new NotSupportedException("Expected protocol set to UDP, due to encryption mode DatagramEncryptionGCM.");
			}
			dictionary[195] = (byte)expectedProtocol;
			dictionary[193] = (byte)encryptionMode;
			dictionary[220] = appVersion;
			dictionary[224] = appId;
			if (!string.IsNullOrEmpty(regionCode))
			{
				dictionary[210] = regionCode;
			}
			if (authValues != null)
			{
				if (!string.IsNullOrEmpty(authValues.UserId))
				{
					dictionary[225] = authValues.UserId;
				}
				if (authValues.AuthType != CustomAuthenticationType.None)
				{
					dictionary[217] = (byte)authValues.AuthType;
					if (authValues.Token != null)
					{
						dictionary[221] = authValues.Token;
					}
					else
					{
						if (!string.IsNullOrEmpty(authValues.AuthGetParameters))
						{
							dictionary[216] = authValues.AuthGetParameters;
						}
						if (authValues.AuthPostData != null)
						{
							dictionary[214] = authValues.AuthPostData;
						}
					}
				}
			}
			return SendOperation(231, dictionary, new SendOptions
			{
				Reliability = true,
				Encrypt = true
			});
		}

		public virtual bool OpChangeGroups(byte[] groupsToRemove, byte[] groupsToAdd)
		{
			if ((int)DebugOut >= 5)
			{
				base.Listener.DebugReturn(DebugLevel.ALL, "OpChangeGroups()");
			}
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			if (groupsToRemove != null)
			{
				dictionary[239] = groupsToRemove;
			}
			if (groupsToAdd != null)
			{
				dictionary[238] = groupsToAdd;
			}
			return SendOperation(248, dictionary, SendOptions.SendReliable);
		}

		public virtual bool OpRaiseEvent(byte eventCode, object customEventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
		{
			ParameterDictionary parameterDictionary = paramDictionaryPool.Acquire();
			try
			{
				if (raiseEventOptions != null)
				{
					if (raiseEventOptions.CachingOption != EventCaching.DoNotCache)
					{
						parameterDictionary.Add(247, (byte)raiseEventOptions.CachingOption);
					}
					switch (raiseEventOptions.CachingOption)
					{
					case EventCaching.SliceSetIndex:
					case EventCaching.SlicePurgeIndex:
					case EventCaching.SlicePurgeUpToIndex:
						return SendOperation(253, parameterDictionary, sendOptions);
					case EventCaching.RemoveFromRoomCacheForActorsLeft:
					case EventCaching.SliceIncreaseIndex:
						return SendOperation(253, parameterDictionary, sendOptions);
					case EventCaching.RemoveFromRoomCache:
						if (raiseEventOptions.TargetActors != null)
						{
							parameterDictionary.Add(252, raiseEventOptions.TargetActors);
						}
						break;
					default:
						if (raiseEventOptions.TargetActors != null)
						{
							parameterDictionary.Add(252, raiseEventOptions.TargetActors);
						}
						else if (raiseEventOptions.InterestGroup != 0)
						{
							parameterDictionary.Add(240, raiseEventOptions.InterestGroup);
						}
						else if (raiseEventOptions.Receivers != ReceiverGroup.Others)
						{
							parameterDictionary.Add(246, (byte)raiseEventOptions.Receivers);
						}
						if (raiseEventOptions.Flags.HttpForward)
						{
							parameterDictionary.Add(234, raiseEventOptions.Flags.WebhookFlags);
						}
						break;
					}
				}
				parameterDictionary.Add(244, eventCode);
				if (customEventContent != null)
				{
					parameterDictionary.Add(245, customEventContent);
				}
				return SendOperation(253, parameterDictionary, sendOptions);
			}
			finally
			{
				paramDictionaryPool.Release(parameterDictionary);
			}
		}

		public virtual bool OpSettings(bool receiveLobbyStats)
		{
			if ((int)DebugOut >= 5)
			{
				base.Listener.DebugReturn(DebugLevel.ALL, "OpSettings()");
			}
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			if (receiveLobbyStats)
			{
				dictionary[0] = receiveLobbyStats;
			}
			if (dictionary.Count == 0)
			{
				return true;
			}
			return SendOperation(218, dictionary, SendOptions.SendReliable);
		}
	}
	internal enum RoomOptionBit
	{
		CheckUserOnJoin = 1,
		DeleteCacheOnLeave = 2,
		SuppressRoomEvents = 4,
		PublishUserId = 8,
		DeleteNullProps = 0x10,
		BroadcastPropsChangeToAll = 0x20,
		SuppressPlayerInfo = 0x40
	}
	internal class FindFriendsOptions
	{
		public bool CreatedOnGs = false;

		public bool Visible = false;

		public bool Open = false;

		internal int ToIntFlags()
		{
			int num = 0;
			if (CreatedOnGs)
			{
				num |= 1;
			}
			if (Visible)
			{
				num |= 2;
			}
			if (Open)
			{
				num |= 4;
			}
			return num;
		}
	}
	internal class OpJoinRandomRoomParams
	{
		public ExitGames.Client.Photon.Hashtable ExpectedCustomRoomProperties;

		public int ExpectedMaxPlayers;

		public MatchmakingMode MatchingType;

		public TypedLobby TypedLobby;

		public string SqlLobbyFilter;

		public string[] ExpectedUsers;

		public object Ticket;
	}
	internal class EnterRoomParams
	{
		public string RoomName;

		public RoomOptions RoomOptions;

		public TypedLobby Lobby;

		public ExitGames.Client.Photon.Hashtable PlayerProperties;

		protected internal bool OnGameServer = true;

		protected internal JoinMode JoinMode;

		public string[] ExpectedUsers;

		public object Ticket;
	}
	internal class ErrorCode
	{
		public const int Ok = 0;

		public const int OperationNotAllowedInCurrentState = -3;

		[Obsolete("Use InvalidOperation.")]
		public const int InvalidOperationCode = -2;

		public const int InvalidOperation = -2;

		public const int InternalServerError = -1;

		public const int InvalidAuthentication = 32767;

		public const int GameIdAlreadyExists = 32766;

		public const int GameFull = 32765;

		public const int GameClosed = 32764;

		[Obsolete("No longer used, cause random matchmaking is no longer a process.")]
		public const int AlreadyMatched = 32763;

		public const int ServerFull = 32762;

		public const int UserBlocked = 32761;

		public const int NoRandomMatchFound = 32760;

		public const int GameDoesNotExist = 32758;

		public const int MaxCcuReached = 32757;

		public const int InvalidRegion = 32756;

		public const int CustomAuthenticationFailed = 32755;

		public const int AuthenticationTicketExpired = 32753;

		public const int PluginReportedError = 32752;

		public const int PluginMismatch = 32751;

		public const int JoinFailedPeerAlreadyJoined = 32750;

		public const int JoinFailedFoundInactiveJoiner = 32749;

		public const int JoinFailedWithRejoinerNotFound = 32748;

		public const int JoinFailedFoundExcludedUserId = 32747;

		public const int JoinFailedFoundActiveJoiner = 32746;

		public const int HttpLimitReached = 32745;

		public const int ExternalHttpCallFailed = 32744;

		public const int OperationLimitReached = 32743;

		public const int SlotError = 32742;

		public const int InvalidEncryptionParameters = 32741;
	}
	internal class ActorProperties
	{
		public const byte PlayerName = byte.MaxValue;

		public const byte IsInactive = 254;

		public const byte UserId = 253;
	}
	internal class GamePropertyKey
	{
		public const byte MaxPlayers = byte.MaxValue;

		public const byte MaxPlayersInt = 243;

		public const byte IsVisible = 254;

		public const byte IsOpen = 253;

		public const byte PlayerCount = 252;

		public const byte Removed = 251;

		public const byte PropsListedInLobby = 250;

		public const byte CleanupCacheOnLeave = 249;

		public const byte MasterClientId = 248;

		public const byte ExpectedUsers = 247;

		public const byte PlayerTtl = 246;

		public const byte EmptyRoomTtl = 245;
	}
	internal class EventCode
	{
		public const byte GameList = 230;

		public const byte GameListUpdate = 229;

		public const byte QueueState = 228;

		public const byte Match = 227;

		public const byte AppStats = 226;

		public const byte LobbyStats = 224;

		[Obsolete("TCP routing was removed after becoming obsolete.")]
		public const byte AzureNodeInfo = 210;

		public const byte Join = byte.MaxValue;

		public const byte Leave = 254;

		public const byte PropertiesChanged = 253;

		[Obsolete("Use PropertiesChanged now.")]
		public const byte SetProperties = 253;

		public const byte ErrorInfo = 251;

		public const byte CacheSliceChanged = 250;

		public const byte AuthEvent = 223;
	}
	internal class ParameterCode
	{
		public const byte SuppressRoomEvents = 237;

		public const byte EmptyRoomTTL = 236;

		public const byte PlayerTTL = 235;

		public const byte EventForward = 234;

		[Obsolete("Use: IsInactive")]
		public const byte IsComingBack = 233;

		public const byte IsInactive = 233;

		public const byte CheckUserOnJoin = 232;

		public const byte ExpectedValues = 231;

		public const byte Address = 230;

		public const byte PeerCount = 229;

		public const byte GameCount = 228;

		public const byte MasterPeerCount = 227;

		public const byte UserId = 225;

		public const byte ApplicationId = 224;

		public const byte Position = 223;

		public const byte MatchMakingType = 223;

		public const byte GameList = 222;

		public const byte Token = 221;

		public const byte AppVersion = 220;

		[Obsolete("TCP routing was removed after becoming obsolete.")]
		public const byte AzureNodeInfo = 210;

		[Obsolete("TCP routing was removed after becoming obsolete.")]
		public const byte AzureLocalNodeId = 209;

		[Obsolete("TCP routing was removed after becoming obsolete.")]
		public const byte AzureMasterNodeId = 208;

		public const byte RoomName = byte.MaxValue;

		public const byte Broadcast = 250;

		public const byte ActorList = 252;

		public const byte ActorNr = 254;

		public const byte PlayerProperties = 249;

		public const byte CustomEventContent = 245;

		public const byte Data = 245;

		public const byte Code = 244;

		public const byte GameProperties = 248;

		public const byte Properties = 251;

		public const byte TargetActorNr = 253;

		public const byte ReceiverGroup = 246;

		public const byte Cache = 247;

		public const byte CleanupCacheOnLeave = 241;

		public const byte Group = 240;

		public const byte Remove = 239;

		public const byte PublishUserId = 239;

		public const byte Add = 238;

		public const byte Info = 218;

		public const byte ClientAuthenticationType = 217;

		public const byte ClientAuthenticationParams = 216;

		public const byte JoinMode = 215;

		public const byte ClientAuthenticationData = 214;

		public const byte MasterClientId = 203;

		public const byte FindFriendsRequestList = 1;

		public const byte FindFriendsOptions = 2;

		public const byte FindFriendsResponseOnlineList = 1;

		public const byte FindFriendsResponseRoomIdList = 2;

		public const byte LobbyName = 213;

		public const byte LobbyType = 212;

		public const byte LobbyStats = 211;

		public const byte Region = 210;

		public const byte UriPath = 209;

		public const byte WebRpcParameters = 208;

		public const byte WebRpcReturnCode = 207;

		public const byte WebRpcReturnMessage = 206;

		public const byte CacheSliceIndex = 205;

		public const byte Plugins = 204;

		public const byte NickName = 202;

		public const byte PluginName = 201;

		public const byte PluginVersion = 200;

		public const byte Cluster = 196;

		public const byte ExpectedProtocol = 195;

		public const byte CustomInitData = 194;

		public const byte EncryptionMode = 193;

		public const byte EncryptionData = 192;

		public const byte RoomOptionFlags = 191;

		public const byte Ticket = 190;

		public const byte MatchMakingGroupId = 189;

		public const byte AllowRepeats = 188;

		public const byte ReportQos = 187;
	}
	internal class OperationCode
	{
		[Obsolete("Exchanging encrpytion keys is done internally in the lib now. Don't expect this operation-result.")]
		public const byte ExchangeKeysForEncryption = 250;

		[Obsolete]
		public const byte Join = byte.MaxValue;

		public const byte AuthenticateOnce = 231;

		public const byte Authenticate = 230;

		public const byte JoinLobby = 229;

		public const byte LeaveLobby = 228;

		public const byte CreateGame = 227;

		public const byte JoinGame = 226;

		public const byte JoinRandomGame = 225;

		public const byte Leave = 254;

		public const byte RaiseEvent = 253;

		public const byte SetProperties = 252;

		public const byte GetProperties = 251;

		public const byte ChangeGroups = 248;

		public const byte FindFriends = 222;

		public const byte GetLobbyStats = 221;

		public const byte GetRegions = 220;

		public const byte WebRpc = 219;

		public const byte ServerSettings = 218;

		public const byte GetGameList = 217;
	}
	internal enum JoinMode : byte
	{
		Default,
		CreateIfNotExists,
		JoinOrRejoin,
		RejoinOnly
	}
	public enum MatchmakingMode : byte
	{
		FillRoom,
		SerialMatching,
		RandomMatching
	}
	internal enum ReceiverGroup : byte
	{
		Others,
		All,
		MasterClient
	}
	internal enum EventCaching : byte
	{
		DoNotCache = 0,
		[Obsolete]
		MergeCache = 1,
		[Obsolete]
		ReplaceCache = 2,
		[Obsolete]
		RemoveCache = 3,
		AddToRoomCache = 4,
		AddToRoomCacheGlobal = 5,
		RemoveFromRoomCache = 6,
		RemoveFromRoomCacheForActorsLeft = 7,
		SliceIncreaseIndex = 10,
		SliceSetIndex = 11,
		SlicePurgeIndex = 12,
		SlicePurgeUpToIndex = 13
	}
	[Flags]
	internal enum PropertyTypeFlag : byte
	{
		None = 0,
		Game = 1,
		Actor = 2,
		GameAndActor = 3
	}
	internal class RoomOptions
	{
		private bool isVisible = true;

		private bool isOpen = true;

		public int MaxPlayers;

		public int PlayerTtl;

		public int EmptyRoomTtl;

		private bool cleanupCacheOnLeave = true;

		public ExitGames.Client.Photon.Hashtable CustomRoomProperties;

		public string[] CustomRoomPropertiesForLobby = new string[0];

		public string[] Plugins;

		private bool broadcastPropsChangeToAll = true;

		public bool IsVisible
		{
			get
			{
				return isVisible;
			}
			set
			{
				isVisible = value;
			}
		}

		public bool IsOpen
		{
			get
			{
				return isOpen;
			}
			set
			{
				isOpen = value;
			}
		}

		public bool CleanupCacheOnLeave
		{
			get
			{
				return cleanupCacheOnLeave;
			}
			set
			{
				cleanupCacheOnLeave = value;
			}
		}

		public bool SuppressRoomEvents { get; set; }

		public bool SuppressPlayerInfo { get; set; }

		public bool PublishUserId { get; set; }

		public bool DeleteNullProperties { get; set; }

		public bool BroadcastPropsChangeToAll
		{
			get
			{
				return broadcastPropsChangeToAll;
			}
			set
			{
				broadcastPropsChangeToAll = value;
			}
		}
	}
	internal class RaiseEventOptions
	{
		public static readonly RaiseEventOptions Default = new RaiseEventOptions();

		public EventCaching CachingOption;

		public byte InterestGroup;

		public int[] TargetActors;

		public ReceiverGroup Receivers;

		[Obsolete("Not used where SendOptions are a parameter too. Use SendOptions.Channel instead.")]
		public byte SequenceChannel;

		public WebFlags Flags = WebFlags.Default;
	}
	internal enum LobbyType : byte
	{
		Default = 0,
		SqlLobby = 2,
		AsyncRandomLobby = 3
	}
	internal class TypedLobby
	{
		public string Name;

		public LobbyType Type;

		public static readonly TypedLobby Default = new TypedLobby();

		public bool IsDefault => string.IsNullOrEmpty(Name);

		internal TypedLobby()
		{
		}

		public TypedLobby(string name, LobbyType type)
		{
			Name = name;
			Type = type;
		}

		public override string ToString()
		{
			return $"lobby '{Name}'[{Type}]";
		}
	}
	internal class TypedLobbyInfo : TypedLobby
	{
		public int PlayerCount;

		public int RoomCount;

		public override string ToString()
		{
			return $"TypedLobbyInfo '{Name}'[{Type}] rooms: {RoomCount} players: {PlayerCount}";
		}
	}
	public enum AuthModeOption
	{
		Auth,
		AuthOnce,
		AuthOnceWss
	}
	public enum CustomAuthenticationType : byte
	{
		Custom = 0,
		Steam = 1,
		Facebook = 2,
		Oculus = 3,
		PlayStation4 = 4,
		[Obsolete("Use PlayStation4 or PlayStation5 as needed")]
		PlayStation = 4,
		Xbox = 5,
		Viveport = 10,
		NintendoSwitch = 11,
		PlayStation5 = 12,
		[Obsolete("Use PlayStation4 or PlayStation5 as needed")]
		Playstation5 = 12,
		Epic = 13,
		FacebookGaming = 15,
		None = byte.MaxValue
	}
	public class AuthenticationValues
	{
		private CustomAuthenticationType authType = CustomAuthenticationType.None;

		public CustomAuthenticationType AuthType
		{
			get
			{
				return authType;
			}
			set
			{
				authType = value;
			}
		}

		public string AuthGetParameters { get; set; }

		public object AuthPostData { get; private set; }

		public object Token { get; protected internal set; }

		public string UserId { get; set; }

		public AuthenticationValues()
		{
		}

		public AuthenticationValues(string userId)
		{
			UserId = userId;
		}

		public virtual void SetAuthPostData(string stringData)
		{
			AuthPostData = (string.IsNullOrEmpty(stringData) ? null : stringData);
		}

		public virtual void SetAuthPostData(byte[] byteData)
		{
			AuthPostData = byteData;
		}

		public virtual void SetAuthPostData(Dictionary<string, object> dictData)
		{
			AuthPostData = dictData;
		}

		public virtual void AddAuthParameter(string key, string value)
		{
			string text = (string.IsNullOrEmpty(AuthGetParameters) ? "" : "&");
			AuthGetParameters = $"{AuthGetParameters}{text}{Uri.EscapeDataString(key)}={Uri.EscapeDataString(value)}";
		}

		public override string ToString()
		{
			return string.Format("AuthenticationValues = AuthType: {0} UserId: {1}{2}{3}{4}", AuthType, UserId, string.IsNullOrEmpty(AuthGetParameters) ? " GetParameters: yes" : "", (AuthPostData == null) ? "" : " PostData: yes", (Token == null) ? "" : " Token: yes");
		}

		public AuthenticationValues CopyTo(AuthenticationValues copy)
		{
			copy.AuthType = AuthType;
			copy.AuthGetParameters = AuthGetParameters;
			copy.AuthPostData = AuthPostData;
			copy.UserId = UserId;
			return copy;
		}
	}
	internal abstract class PhotonPing : IDisposable
	{
		public string DebugString = "";

		public bool Successful;

		protected internal bool GotResult;

		protected internal int PingLength = 13;

		protected internal byte[] PingBytes = new byte[13]
		{
			125, 125, 125, 125, 125, 125, 125, 125, 125, 125,
			125, 125, 0
		};

		protected internal byte PingId;

		private static readonly System.Random RandomIdProvider = new System.Random();

		public virtual bool StartPing(string ip)
		{
			throw new NotImplementedException();
		}

		public virtual bool Done()
		{
			throw new NotImplementedException();
		}

		public virtual void Dispose()
		{
			throw new NotImplementedException();
		}

		protected internal void Init()
		{
			GotResult = false;
			Successful = false;
			PingId = (byte)RandomIdProvider.Next(255);
		}
	}
	internal class PingMono : PhotonPing
	{
		private Socket sock;

		public override bool StartPing(string ip)
		{
			Init();
			try
			{
				if (sock == null)
				{
					if (ip.Contains("."))
					{
						sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
					}
					else
					{
						sock = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
					}
					sock.ReceiveTimeout = 5000;
					int port = ((RegionHandler.PortToPingOverride != 0) ? RegionHandler.PortToPingOverride : 5055);
					sock.Connect(ip, port);
				}
				PingBytes[PingBytes.Length - 1] = PingId;
				sock.Send(PingBytes);
				PingBytes[PingBytes.Length - 1] = (byte)(PingId + 1);
			}
			catch (Exception ex)
			{
				sock = null;
				System.Diagnostics.Debug.WriteLine(ex.ToString());
				throw;
			}
			return false;
		}

		public override bool Done()
		{
			if (GotResult || sock == null)
			{
				return true;
			}
			int num = 0;
			try
			{
				if (!sock.Poll(0, SelectMode.SelectRead))
				{
					return false;
				}
				num = sock.Receive(PingBytes, SocketFlags.None);
			}
			catch (Exception ex)
			{
				if (sock != null)
				{
					sock.Close();
					sock = null;
				}
				DebugString = DebugString + " Exception of socket! " + ex.GetType()?.ToString() + " ";
				return true;
			}
			bool flag = PingBytes[PingBytes.Length - 1] == PingId && num == PingLength;
			if (!flag)
			{
				DebugString += " ReplyMatch is false! ";
			}
			Successful = flag;
			GotResult = true;
			return true;
		}

		public override void Dispose()
		{
			if (sock != null)
			{
				try
				{
					sock.Close();
				}
				catch
				{
				}
				sock = null;
			}
		}
	}
	internal class PingHttp : PhotonPing
	{
		private UnityWebRequest webRequest;

		public override bool StartPing(string address)
		{
			Init();
			string arg = (Application.isEditor ? "http://" : "https://");
			address = $"{arg}{address}/photon/m/?ping&r={UnityEngine.Random.Range(0, 10000)}";
			webRequest = UnityWebRequest.Get(address);
			webRequest.SendWebRequest();
			return true;
		}

		public override bool Done()
		{
			if (webRequest.isDone)
			{
				Successful = true;
				return true;
			}
			return false;
		}

		public override void Dispose()
		{
			webRequest.Dispose();
		}
	}
	internal class Player
	{
		private int actorNumber = -1;

		public readonly bool IsLocal;

		private string nickName = string.Empty;

		public object TagObject;

		protected internal Room RoomReference { get; set; }

		public int ActorNumber => actorNumber;

		public bool HasRejoined { get; internal set; }

		public string NickName
		{
			get
			{
				return nickName;
			}
			set
			{
				if (string.IsNullOrEmpty(nickName) || !nickName.Equals(value))
				{
					nickName = value;
					if (IsLocal)
					{
						SetPlayerNameProperty();
					}
				}
			}
		}

		public string UserId { get; internal set; }

		public bool IsMasterClient
		{
			get
			{
				if (RoomReference == null)
				{
					return false;
				}
				return ActorNumber == RoomReference.MasterClientId;
			}
		}

		public bool IsInactive { get; protected internal set; }

		public ExitGames.Client.Photon.Hashtable CustomProperties { get; set; }

		protected internal Player(string nickName, int actorNumber, bool isLocal)
			: this(nickName, actorNumber, isLocal, null)
		{
		}

		protected internal Player(string nickName, int actorNumber, bool isLocal, ExitGames.Client.Photon.Hashtable playerProperties)
		{
			IsLocal = isLocal;
			this.actorNumber = actorNumber;
			NickName = nickName;
			CustomProperties = new ExitGames.Client.Photon.Hashtable();
			InternalCacheProperties(playerProperties);
		}

		public Player Get(int id)
		{
			if (RoomReference == null)
			{
				return null;
			}
			return RoomReference.GetPlayer(id);
		}

		public Player GetNext()
		{
			return GetNextFor(ActorNumber);
		}

		public Player GetNextFor(Player currentPlayer)
		{
			if (currentPlayer == null)
			{
				return null;
			}
			return GetNextFor(currentPlayer.ActorNumber);
		}

		public Player GetNextFor(int currentPlayerId)
		{
			if (RoomReference == null || RoomReference.Players == null || RoomReference.Players.Count < 2)
			{
				return null;
			}
			Dictionary<int, Player> players = RoomReference.Players;
			int num = int.MaxValue;
			int num2 = currentPlayerId;
			foreach (int key in players.Keys)
			{
				if (key < num2)
				{
					num2 = key;
				}
				else if (key > currentPlayerId && key < num)
				{
					num = key;
				}
			}
			return (num != int.MaxValue) ? players[num] : players[num2];
		}

		protected internal virtual void InternalCacheProperties(ExitGames.Client.Photon.Hashtable properties)
		{
			if (properties != null && properties.Count != 0 && !CustomProperties.Equals(properties))
			{
				if (!IsLocal && properties.ContainsKey(byte.MaxValue))
				{
					string text = (string)properties[byte.MaxValue];
					NickName = text;
				}
				if (properties.ContainsKey(253))
				{
					UserId = (string)properties[253];
				}
				if (properties.ContainsKey(254))
				{
					IsInactive = (bool)properties[254];
				}
				CustomProperties.MergeStringKeys(properties);
				CustomProperties.StripKeysWithNullValues();
			}
		}

		public override string ToString()
		{
			return $"#{ActorNumber:00} '{NickName}'";
		}

		public string ToStringFull()
		{
			return string.Format("#{0:00} '{1}'{2} {3}", ActorNumber, NickName, IsInactive ? " (inactive)" : "", CustomProperties.ToStringFull());
		}

		public override bool Equals(object p)
		{
			return p is Player player && GetHashCode() == player.GetHashCode();
		}

		public override int GetHashCode()
		{
			return ActorNumber;
		}

		protected internal void ChangeLocalID(int newID)
		{
			if (IsLocal)
			{
				actorNumber = newID;
			}
		}

		public bool SetCustomProperties(ExitGames.Client.Photon.Hashtable propertiesToSet, ExitGames.Client.Photon.Hashtable expectedValues = null, WebFlags webFlags = null)
		{
			if (propertiesToSet == null || propertiesToSet.Count == 0)
			{
				return false;
			}
			ExitGames.Client.Photon.Hashtable hashtable = propertiesToSet.StripToStringKeys();
			if (RoomReference != null)
			{
				if (RoomReference.IsOffline)
				{
					if (hashtable.Count == 0)
					{
						return false;
					}
					CustomProperties.Merge(hashtable);
					CustomProperties.StripKeysWithNullValues();
					RoomReference.LoadBalancingClient.InRoomCallbackTargets.OnPlayerPropertiesUpdate(this, hashtable);
					return true;
				}
				ExitGames.Client.Photon.Hashtable expectedProperties = expectedValues.StripToStringKeys();
				return RoomReference.LoadBalancingClient.OpSetPropertiesOfActor(actorNumber, hashtable, expectedProperties, webFlags);
			}
			if (IsLocal)
			{
				if (hashtable.Count == 0)
				{
					return false;
				}
				if (expectedValues == null && webFlags == null)
				{
					CustomProperties.Merge(hashtable);
					CustomProperties.StripKeysWithNullValues();
					return true;
				}
			}
			return false;
		}

		internal bool UpdateNickNameOnJoined()
		{
			if (RoomReference == null || RoomReference.CustomProperties == null || !IsLocal)
			{
				return false;
			}
			string b = (RoomReference.CustomProperties.ContainsKey(byte.MaxValue) ? (RoomReference.CustomProperties[byte.MaxValue] as string) : string.Empty);
			if (!string.Equals(NickName, b))
			{
				return SetPlayerNameProperty();
			}
			return true;
		}

		private bool SetPlayerNameProperty()
		{
			if (RoomReference != null && !RoomReference.IsOffline)
			{
				ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
				hashtable[byte.MaxValue] = nickName;
				return RoomReference.LoadBalancingClient.OpSetPropertiesOfActor(ActorNumber, hashtable);
			}
			return false;
		}
	}
	internal class Region
	{
		public string Code { get; private set; }

		public string Cluster { get; private set; }

		public string HostAndPort { get; protected internal set; }

		public int Ping { get; set; }

		public bool WasPinged => Ping != int.MaxValue;

		public Region(string code, string address)
		{
			SetCodeAndCluster(code);
			HostAndPort = address;
			Ping = int.MaxValue;
		}

		public Region(string code, int ping)
		{
			SetCodeAndCluster(code);
			Ping = ping;
		}

		private void SetCodeAndCluster(string codeAsString)
		{
			if (codeAsString == null)
			{
				Code = "";
				Cluster = "";
				return;
			}
			codeAsString = codeAsString.ToLower();
			int num = codeAsString.IndexOf('/');
			Code = ((num <= 0) ? codeAsString : codeAsString.Substring(0, num));
			Cluster = ((num <= 0) ? "" : codeAsString.Substring(num + 1, codeAsString.Length - num - 1));
		}

		public override string ToString()
		{
			return ToString();
		}

		public string ToString(bool compact = false)
		{
			string text = Code;
			if (!string.IsNullOrEmpty(Cluster))
			{
				text = text + "/" + Cluster;
			}
			if (compact)
			{
				return $"{text}:{Ping}";
			}
			return string.Format("{0}[{2}]: {1}ms", text, Ping, HostAndPort);
		}
	}
	internal class RegionHandler
	{
		public static Type PingImplementation;

		private string availableRegionCodes;

		private Region bestRegionCache;

		private readonly List<RegionPinger> pingerList = new List<RegionPinger>();

		private Action<RegionHandler> onCompleteCall;

		private int previousPing;

		private string previousSummaryProvided;

		protected internal static ushort PortToPingOverride;

		private float rePingFactor = 1.2f;

		private float pingSimilarityFactor = 1.2f;

		public int BestRegionSummaryPingLimit = 90;

		private MonoBehaviourEmpty emptyMonoBehavior;

		public List<Region> EnabledRegions { get; protected internal set; }

		public Region BestRegion
		{
			get
			{
				if (EnabledRegions == null)
				{
					return null;
				}
				if (bestRegionCache != null)
				{
					return bestRegionCache;
				}
				EnabledRegions.Sort((Region a, Region b) => a.Ping.CompareTo(b.Ping));
				int num = (int)((float)EnabledRegions[0].Ping * pingSimilarityFactor);
				Region region = EnabledRegions[0];
				foreach (Region enabledRegion in EnabledRegions)
				{
					if (enabledRegion.Ping <= num && enabledRegion.Code.CompareTo(region.Code) < 0)
					{
						region = enabledRegion;
					}
				}
				bestRegionCache = region;
				return bestRegionCache;
			}
		}

		public string SummaryToCache
		{
			get
			{
				if (BestRegion != null && BestRegion.Ping < RegionPinger.MaxMillisecondsPerPing)
				{
					return BestRegion.Code + ";" + BestRegion.Ping + ";" + availableRegionCodes;
				}
				return availableRegionCodes;
			}
		}

		public bool IsPinging { get; private set; }

		public bool Aborted { get; private set; }

		public string GetResults()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Region Pinging Result: {0}\n", BestRegion.ToString());
			foreach (RegionPinger pinger in pingerList)
			{
				stringBuilder.AppendLine(pinger.GetResults());
			}
			stringBuilder.AppendFormat("Previous summary: {0}", previousSummaryProvided);
			return stringBuilder.ToString();
		}

		public void SetRegions(OperationResponse opGetRegions, LoadBalancingClient loadBalancingClient = null)
		{
			if (opGetRegions.OperationCode != 220 || opGetRegions.ReturnCode != 0)
			{
				return;
			}
			string[] array = opGetRegions[210] as string[];
			string[] array2 = opGetRegions[230] as string[];
			if (array == null || array2 == null || array.Length != array2.Length)
			{
				loadBalancingClient?.DebugReturn(DebugLevel.ERROR, "RegionHandler.SetRegions() failed. Received regions and servers must be non null and of equal length. Could not read regions.");
				return;
			}
			bestRegionCache = null;
			EnabledRegions = new List<Region>(array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				string text = array2[i];
				if (PortToPingOverride != 0)
				{
					text = LoadBalancingClient.ReplacePortWithAlternative(array2[i], PortToPingOverride);
				}
				if (loadBalancingClient != null && loadBalancingClient.AddressRewriter != null)
				{
					text = loadBalancingClient.AddressRewriter(text, ServerConnection.MasterServer);
				}
				Region region = new Region(array[i], text);
				if (!string.IsNullOrEmpty(region.Code))
				{
					EnabledRegions.Add(region);
				}
			}
			Array.Sort(array);
			availableRegionCodes = string.Join(",", array);
		}

		public RegionHandler(ushort masterServerPortOverride = 0)
		{
			PortToPingOverride = masterServerPortOverride;
		}

		public bool PingMinimumOfRegions(Action<RegionHandler> onCompleteCallback, string previousSummary)
		{
			if (EnabledRegions == null || EnabledRegions.Count == 0)
			{
				return false;
			}
			if (IsPinging)
			{
				return false;
			}
			Aborted = false;
			IsPinging = true;
			previousSummaryProvided = previousSummary;
			if (emptyMonoBehavior != null)
			{
				emptyMonoBehavior.SelfDestroy();
			}
			emptyMonoBehavior = MonoBehaviourEmpty.BuildInstance("RegionHandler");
			emptyMonoBehavior.onCompleteCall = onCompleteCallback;
			onCompleteCall = emptyMonoBehavior.CompleteOnMainThread;
			if (string.IsNullOrEmpty(previousSummary))
			{
				return PingEnabledRegions();
			}
			string[] array = previousSummary.Split(';');
			if (array.Length < 3)
			{
				return PingEnabledRegions();
			}
			if (!int.TryParse(array[1], out var result))
			{
				return PingEnabledRegions();
			}
			string prevBestRegionCode = array[0];
			string value = array[2];
			if (string.IsNullOrEmpty(prevBestRegionCode))
			{
				return PingEnabledRegions();
			}
			if (string.IsNullOrEmpty(value))
			{
				return PingEnabledRegions();
			}
			if (!availableRegionCodes.Equals(value) || !availableRegionCodes.Contains(prevBestRegionCode))
			{
				return PingEnabledRegions();
			}
			if (result >= RegionPinger.PingWhenFailed)
			{
				return PingEnabledRegions();
			}
			previousPing = result;
			Region region = EnabledRegions.Find((Region r) => r.Code.Equals(prevBestRegionCode));
			RegionPinger regionPinger = new RegionPinger(region, OnPreferredRegionPinged);
			lock (pingerList)
			{
				pingerList.Clear();
				pingerList.Add(regionPinger);
			}
			regionPinger.Start();
			return true;
		}

		public void Abort()
		{
			if (Aborted)
			{
				return;
			}
			Aborted = true;
			lock (pingerList)
			{
				foreach (RegionPinger pinger in pingerList)
				{
					pinger.Abort();
				}
			}
			if (emptyMonoBehavior != null)
			{
				emptyMonoBehavior.SelfDestroy();
			}
		}

		private void OnPreferredRegionPinged(Region preferredRegion)
		{
			if (preferredRegion.Ping > BestRegionSummaryPingLimit || (float)preferredRegion.Ping > (float)previousPing * rePingFactor)
			{
				PingEnabledRegions();
				return;
			}
			IsPinging = false;
			onCompleteCall(this);
		}

		private bool PingEnabledRegions()
		{
			if (EnabledRegions == null || EnabledRegions.Count == 0)
			{
				return false;
			}
			lock (pingerList)
			{
				pingerList.Clear();
				foreach (Region enabledRegion in EnabledRegions)
				{
					RegionPinger regionPinger = new RegionPinger(enabledRegion, OnRegionDone);
					pingerList.Add(regionPinger);
					regionPinger.Start();
				}
			}
			return true;
		}

		private void OnRegionDone(Region region)
		{
			lock (pingerList)
			{
				if (!IsPinging)
				{
					return;
				}
				bestRegionCache = null;
				foreach (RegionPinger pinger in pingerList)
				{
					if (!pinger.Done)
					{
						return;
					}
				}
				IsPinging = false;
			}
			if (!Aborted)
			{
				onCompleteCall(this);
			}
		}
	}
	internal class RegionPinger
	{
		public static int Attempts = 5;

		public static int MaxMillisecondsPerPing = 800;

		public static int PingWhenFailed = Attempts * MaxMillisecondsPerPing;

		public int CurrentAttempt = 0;

		private Action<Region> onDoneCall;

		private PhotonPing ping;

		private List<int> rttResults;

		private Region region;

		private string regionAddress;

		public bool Done { get; private set; }

		public bool Aborted { get; internal set; }

		public RegionPinger(Region region, Action<Region> onDoneCallback)
		{
			this.region = region;
			this.region.Ping = PingWhenFailed;
			Done = false;
			onDoneCall = onDoneCallback;
		}

		private PhotonPing GetPingImplementation()
		{
			PhotonPing photonPing = null;
			if (RuntimeUnityFlagsSetup.IsUNITY_WEBGL)
			{
				if (RegionHandler.PingImplementation == null || RegionHandler.PingImplementation == typeof(PingHttp))
				{
					photonPing = new PingHttp();
				}
			}
			else if (RegionHandler.PingImplementation == null || RegionHandler.PingImplementation == typeof(PingMono))
			{
				photonPing = new PingMono();
			}
			if (photonPing == null && RegionHandler.PingImplementation != null)
			{
				photonPing = (PhotonPing)Activator.CreateInstance(RegionHandler.PingImplementation);
			}
			return photonPing;
		}

		public bool Start()
		{
			ping = GetPingImplementation();
			Done = false;
			CurrentAttempt = 0;
			rttResults = new List<int>(Attempts);
			if (Aborted)
			{
				return false;
			}
			if (RuntimeUnityFlagsSetup.IsUNITY_WEBGL)
			{
				MonoBehaviourEmpty.BuildInstance("RegionPing_" + region.Code).StartCoroutineAndDestroy(RegionPingCoroutine());
			}
			else
			{
				bool flag = false;
				try
				{
					flag = ThreadPool.QueueUserWorkItem(delegate
					{
						RegionPingThreaded();
					});
				}
				catch
				{
					flag = false;
				}
				if (!flag)
				{
					SupportClass.StartBackgroundCalls(RegionPingThreaded, 0, "RegionPing_" + region.Code + "_" + region.Cluster);
				}
			}
			return true;
		}

		protected internal void Abort()
		{
			Aborted = true;
			if (ping != null)
			{
				ping.Dispose();
			}
		}

		protected internal bool RegionPingThreaded()
		{
			region.Ping = PingWhenFailed;
			int num = 0;
			int num2 = 0;
			Stopwatch stopwatch = new Stopwatch();
			try
			{
				string text = region.HostAndPort;
				int num3 = text.LastIndexOf(':');
				if (num3 > 1)
				{
					text = text.Substring(0, num3);
				}
				stopwatch.Start();
				regionAddress = ResolveHost(text);
				stopwatch.Stop();
				if (stopwatch.ElapsedMilliseconds > 100)
				{
					System.Diagnostics.Debug.WriteLine($"RegionPingThreaded.ResolveHost() took: {stopwatch.ElapsedMilliseconds}ms");
				}
			}
			catch (Exception arg)
			{
				System.Diagnostics.Debug.WriteLine($"RegionPingThreaded ResolveHost failed for {region}. Caught: {arg}");
				Aborted = true;
			}
			CurrentAttempt = 0;
			while (CurrentAttempt < Attempts && !Aborted)
			{
				stopwatch.Reset();
				stopwatch.Start();
				try
				{
					ping.StartPing(regionAddress);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine("RegionPinger.RegionPingThreaded() caught exception for ping.StartPing(). Exception: " + ex?.ToString() + " Source: " + ex.Source + " Message: " + ex.Message);
					break;
				}
				while (!ping.Done() && stopwatch.ElapsedMilliseconds < MaxMillisecondsPerPing)
				{
					Thread.Sleep(1);
				}
				stopwatch.Stop();
				int num4 = (int)(ping.Successful ? stopwatch.ElapsedMilliseconds : MaxMillisecondsPerPing);
				rttResults.Add(num4);
				num += num4;
				num2++;
				region.Ping = num / num2;
				int num5 = 4;
				while (!ping.Done() && num5 > 0)
				{
					num5--;
					Thread.Sleep(100);
				}
				Thread.Sleep(10);
				CurrentAttempt++;
			}
			Done = true;
			ping.Dispose();
			if (rttResults.Count > 1 && num2 > 0)
			{
				int num6 = rttResults.Min();
				int num7 = rttResults.Max();
				int num8 = num - num7 + num6;
				region.Ping = num8 / num2;
			}
			onDoneCall(region);
			return false;
		}

		protected internal IEnumerator RegionPingCoroutine()
		{
			region.Ping = PingWhenFailed;
			int rttSum = 0;
			int replyCount = 0;
			Stopwatch sw = new Stopwatch();
			try
			{
				string address = region.HostAndPort;
				int indexOfColon = address.LastIndexOf(':');
				if (indexOfColon > 1)
				{
					address = address.Substring(0, indexOfColon);
				}
				sw.Start();
				regionAddress = ResolveHost(address);
				sw.Stop();
				if (sw.ElapsedMilliseconds > 100)
				{
					UnityEngine.Debug.Log($"RegionPingCoroutine.ResolveHost() took: {sw.ElapsedMilliseconds}ms");
				}
			}
			catch (Exception ex)
			{
				Exception e = ex;
				UnityEngine.Debug.Log($"RegionPingCoroutine ResolveHost failed for {region}. Caught: {e}");
				Aborted = true;
			}
			for (CurrentAttempt = 0; CurrentAttempt < Attempts; CurrentAttempt++)
			{
				if (Aborted)
				{
					yield return null;
				}
				sw.Reset();
				sw.Start();
				try
				{
					ping.StartPing(regionAddress);
				}
				catch (Exception ex2)
				{
					UnityEngine.Debug.Log("RegionPinger.RegionPingCoroutine() caught exception for ping.StartPing(). Exception: " + ex2?.ToString() + " Source: " + ex2.Source + " Message: " + ex2.Message);
					break;
				}
				while (!ping.Done() && sw.ElapsedMilliseconds < MaxMillisecondsPerPing)
				{
					yield return new WaitForSecondsRealtime(0.01f);
				}
				sw.Stop();
				int rtt = (int)(ping.Successful ? sw.ElapsedMilliseconds : MaxMillisecondsPerPing);
				rttResults.Add(rtt);
				rttSum += rtt;
				replyCount++;
				region.Ping = rttSum / replyCount;
				int i = 4;
				while (!ping.Done() && i > 0)
				{
					i--;
					yield return new WaitForSeconds(0.1f);
				}
				yield return new WaitForSeconds(0.1f);
			}
			Done = true;
			ping.Dispose();
			if (rttResults.Count > 1 && replyCount > 0)
			{
				int bestRtt = rttResults.Min();
				int worstRtt = rttResults.Max();
				int weighedRttSum = rttSum - worstRtt + bestRtt;
				region.Ping = weighedRttSum / replyCount;
			}
			onDoneCall(region);
			yield return null;
		}

		public string GetResults()
		{
			return $"{region.Code}: {region.Ping} ({rttResults.ToStringFull()})";
		}

		public static string ResolveHost(string hostName)
		{
			if (hostName.StartsWith("wss://"))
			{
				hostName = hostName.Substring(6);
			}
			if (hostName.StartsWith("ws://"))
			{
				hostName = hostName.Substring(5);
			}
			string text = string.Empty;
			try
			{
				if (RuntimeUnityFlagsSetup.IsUNITY_WEBGL)
				{
					return hostName;
				}
				IPAddress[] hostAddresses = Dns.GetHostAddresses(hostName);
				if (hostAddresses.Length == 1)
				{
					return hostAddresses[0].ToString();
				}
				foreach (IPAddress iPAddress in hostAddresses)
				{
					if (iPAddress != null)
					{
						if (iPAddress.ToString().Contains(":"))
						{
							return iPAddress.ToString();
						}
						if (string.IsNullOrEmpty(text))
						{
							text = hostAddresses.ToString();
						}
					}
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("RegionPinger.ResolveHost() caught an exception for Dns.GetHostAddresses(). Exception: " + ex?.ToString() + " Source: " + ex.Source + " Message: " + ex.Message);
			}
			return text;
		}
	}
	internal class MonoBehaviourEmpty : MonoBehaviour
	{
		internal Action<RegionHandler> onCompleteCall;

		private RegionHandler obj;

		public static MonoBehaviourEmpty BuildInstance(string id = null)
		{
			GameObject gameObject = new GameObject(id ?? "MonoBehaviourEmpty");
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
			return gameObject.AddComponent<MonoBehaviourEmpty>();
		}

		public void SelfDestroy()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private void Update()
		{
			if (obj != null)
			{
				onCompleteCall(obj);
				obj = null;
				onCompleteCall = null;
				SelfDestroy();
			}
		}

		public void CompleteOnMainThread(RegionHandler obj)
		{
			this.obj = obj;
		}

		public void StartCoroutineAndDestroy(IEnumerator coroutine)
		{
			StartCoroutine(Routine());
			IEnumerator Routine()
			{
				yield return coroutine;
				SelfDestroy();
			}
		}
	}
	internal class Room : RoomInfo
	{
		private bool isOffline;

		private Dictionary<int, Player> players = new Dictionary<int, Player>();

		public LoadBalancingClient LoadBalancingClient { get; set; }

		public new string Name
		{
			get
			{
				return name;
			}
			internal set
			{
				name = value;
			}
		}

		public bool IsOffline
		{
			get
			{
				return isOffline;
			}
			private set
			{
				isOffline = value;
			}
		}

		public new bool IsOpen
		{
			get
			{
				return isOpen;
			}
			set
			{
				if (value != isOpen && !isOffline)
				{
					LoadBalancingClient.OpSetPropertiesOfRoom(new ExitGames.Client.Photon.Hashtable { { 253, value } });
				}
				isOpen = value;
			}
		}

		public new bool IsVisible
		{
			get
			{
				return isVisible;
			}
			set
			{
				if (value != isVisible && !isOffline)
				{
					LoadBalancingClient.OpSetPropertiesOfRoom(new ExitGames.Client.Photon.Hashtable { { 254, value } });
				}
				isVisible = value;
			}
		}

		public new int MaxPlayers
		{
			get
			{
				return maxPlayers;
			}
			set
			{
				if (value >= 0 && value != maxPlayers)
				{
					maxPlayers = value;
					byte b = (byte)((value <= 255) ? ((byte)value) : 0);
					if (!isOffline)
					{
						LoadBalancingClient.OpSetPropertiesOfRoom(new ExitGames.Client.Photon.Hashtable
						{
							{
								byte.MaxValue,
								b
							},
							{ 243, maxPlayers }
						});
					}
				}
			}
		}

		public new int PlayerCount
		{
			get
			{
				if (Players == null)
				{
					return 0;
				}
				return (byte)Players.Count;
			}
		}

		public Dictionary<int, Player> Players
		{
			get
			{
				return players;
			}
			private set
			{
				players = value;
			}
		}

		public string[] ExpectedUsers => expectedUsers;

		public int PlayerTtl
		{
			get
			{
				return playerTtl;
			}
			set
			{
				if (value != playerTtl && !isOffline)
				{
					LoadBalancingClient.OpSetPropertyOfRoom(246, value);
				}
				playerTtl = value;
			}
		}

		public int EmptyRoomTtl
		{
			get
			{
				return emptyRoomTtl;
			}
			set
			{
				if (value != emptyRoomTtl && !isOffline)
				{
					LoadBalancingClient.OpSetPropertyOfRoom(245, value);
				}
				emptyRoomTtl = value;
			}
		}

		public int MasterClientId => masterClientId;

		public string[] PropertiesListedInLobby
		{
			get
			{
				return propertiesListedInLobby;
			}
			private set
			{
				propertiesListedInLobby = value;
			}
		}

		public bool AutoCleanUp => autoCleanUp;

		public bool BroadcastPropertiesChangeToAll { get; private set; }

		public bool SuppressRoomEvents { get; private set; }

		public bool SuppressPlayerInfo { get; private set; }

		public bool PublishUserId { get; private set; }

		public bool DeleteNullProperties { get; private set; }

		public Room(string roomName, RoomOptions options, bool isOffline = false)
			: base(roomName, options?.CustomRoomProperties)
		{
			if (options != null)
			{
				isVisible = options.IsVisible;
				isOpen = options.IsOpen;
				maxPlayers = options.MaxPlayers;
				propertiesListedInLobby = options.CustomRoomPropertiesForLobby;
			}
			this.isOffline = isOffline;
		}

		internal void InternalCacheRoomFlags(int roomFlags)
		{
			BroadcastPropertiesChangeToAll = (roomFlags & 0x20) != 0;
			SuppressRoomEvents = (roomFlags & 4) != 0;
			SuppressPlayerInfo = (roomFlags & 0x40) != 0;
			PublishUserId = (roomFlags & 8) != 0;
			DeleteNullProperties = (roomFlags & 0x10) != 0;
			autoCleanUp = (roomFlags & 2) != 0;
		}

		protected internal override void InternalCacheProperties(ExitGames.Client.Photon.Hashtable propertiesToCache)
		{
			int num = masterClientId;
			base.InternalCacheProperties(propertiesToCache);
			if (num != 0 && masterClientId != num)
			{
				LoadBalancingClient.InRoomCallbackTargets.OnMasterClientSwitched(GetPlayer(masterClientId));
			}
		}

		public virtual bool SetCustomProperties(ExitGames.Client.Photon.Hashtable propertiesToSet, ExitGames.Client.Photon.Hashtable expectedProperties = null, WebFlags webFlags = null)
		{
			if (propertiesToSet == null || propertiesToSet.Count == 0)
			{
				return false;
			}
			ExitGames.Client.Photon.Hashtable hashtable = propertiesToSet.StripToStringKeys();
			if (isOffline)
			{
				if (hashtable.Count == 0)
				{
					return false;
				}
				base.CustomProperties.Merge(hashtable);
				base.CustomProperties.StripKeysWithNullValues();
				LoadBalancingClient.InRoomCallbackTargets.OnRoomPropertiesUpdate(propertiesToSet);
				return true;
			}
			return LoadBalancingClient.OpSetPropertiesOfRoom(hashtable, expectedProperties, webFlags);
		}

		public bool SetPropertiesListedInLobby(string[] lobbyProps)
		{
			if (isOffline)
			{
				return false;
			}
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			hashtable[250] = lobbyProps;
			return LoadBalancingClient.OpSetPropertiesOfRoom(hashtable);
		}

		protected internal virtual void RemovePlayer(Player player)
		{
			Players.Remove(player.ActorNumber);
			player.RoomReference = null;
		}

		protected internal virtual void RemovePlayer(int id)
		{
			RemovePlayer(GetPlayer(id));
		}

		public bool SetMasterClient(Player masterClientPlayer)
		{
			if (isOffline)
			{
				return false;
			}
			ExitGames.Client.Photon.Hashtable gameProperties = new ExitGames.Client.Photon.Hashtable { { 248, masterClientPlayer.ActorNumber } };
			ExitGames.Client.Photon.Hashtable expectedProperties = new ExitGames.Client.Photon.Hashtable { { 248, MasterClientId } };
			return LoadBalancingClient.OpSetPropertiesOfRoom(gameProperties, expectedProperties);
		}

		public virtual bool AddPlayer(Player player)
		{
			if (!Players.ContainsKey(player.ActorNumber))
			{
				StorePlayer(player);
				return true;
			}
			return false;
		}

		public virtual Player StorePlayer(Player player)
		{
			Players[player.ActorNumber] = player;
			player.RoomReference = this;
			return player;
		}

		public virtual Player GetPlayer(int id, bool findMaster = false)
		{
			int key = ((findMaster && id == 0) ? MasterClientId : id);
			Player value = null;
			Players.TryGetValue(key, out value);
			return value;
		}

		public bool ClearExpectedUsers()
		{
			if (ExpectedUsers == null || ExpectedUsers.Length == 0)
			{
				return false;
			}
			return SetExpectedUsers(new string[0], ExpectedUsers);
		}

		public bool SetExpectedUsers(string[] newExpectedUsers)
		{
			if (newExpectedUsers == null || newExpectedUsers.Length == 0)
			{
				LoadBalancingClient.DebugReturn(DebugLevel.ERROR, "newExpectedUsers array is null or empty, call Room.ClearExpectedUsers() instead if this is what you want.");
				return false;
			}
			return SetExpectedUsers(newExpectedUsers, ExpectedUsers);
		}

		private bool SetExpectedUsers(string[] newExpectedUsers, string[] oldExpectedUsers)
		{
			if (isOffline)
			{
				return false;
			}
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable(1);
			hashtable.Add(247, newExpectedUsers);
			ExitGames.Client.Photon.Hashtable hashtable2 = null;
			if (oldExpectedUsers != null)
			{
				hashtable2 = new ExitGames.Client.Photon.Hashtable(1);
				hashtable2.Add(247, oldExpectedUsers);
			}
			return LoadBalancingClient.OpSetPropertiesOfRoom(hashtable, hashtable2);
		}

		public override string ToString()
		{
			return string.Format("Room: '{0}' {1},{2} {4}/{3} players.", name, isVisible ? "visible" : "hidden", isOpen ? "open" : "closed", maxPlayers, PlayerCount);
		}

		public new string ToStringFull()
		{
			return string.Format("Room: '{0}' {1},{2} {4}/{3} players.\ncustomProps: {5}", name, isVisible ? "visible" : "hidden", isOpen ? "open" : "closed", maxPlayers, PlayerCount, base.CustomProperties.ToStringFull());
		}
	}
	internal class RoomInfo
	{
		public bool RemovedFromList;

		private ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();

		protected int maxPlayers = 0;

		protected int emptyRoomTtl = 0;

		protected int playerTtl = 0;

		protected string[] expectedUsers;

		protected bool isOpen = true;

		protected bool isVisible = true;

		protected bool autoCleanUp = true;

		protected string name;

		public int masterClientId;

		protected string[] propertiesListedInLobby;

		public ExitGames.Client.Photon.Hashtable CustomProperties => customProperties;

		public string Name => name;

		public int PlayerCount { get; private set; }

		public int MaxPlayers => maxPlayers;

		public bool IsOpen => isOpen;

		public bool IsVisible => isVisible;

		protected internal RoomInfo(string roomName, ExitGames.Client.Photon.Hashtable roomProperties)
		{
			InternalCacheProperties(roomProperties);
			name = roomName;
		}

		public override bool Equals(object other)
		{
			return other is RoomInfo roomInfo && Name.Equals(roomInfo.name);
		}

		public override int GetHashCode()
		{
			return name.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("Room: '{0}' {1},{2} {4}/{3} players.", name, isVisible ? "visible" : "hidden", isOpen ? "open" : "closed", maxPlayers, PlayerCount);
		}

		public string ToStringFull()
		{
			return string.Format("Room: '{0}' {1},{2} {4}/{3} players.\ncustomProps: {5}", name, isVisible ? "visible" : "hidden", isOpen ? "open" : "closed", maxPlayers, PlayerCount, customProperties.ToStringFull());
		}

		protected internal virtual void InternalCacheProperties(ExitGames.Client.Photon.Hashtable propertiesToCache)
		{
			if (propertiesToCache == null || propertiesToCache.Count == 0 || customProperties.Equals(propertiesToCache))
			{
				return;
			}
			if (propertiesToCache.ContainsKey(251))
			{
				RemovedFromList = (bool)propertiesToCache[251];
				if (RemovedFromList)
				{
					return;
				}
			}
			if (propertiesToCache.ContainsKey(243))
			{
				maxPlayers = Convert.ToInt32(propertiesToCache[243]);
			}
			else if (propertiesToCache.ContainsKey(byte.MaxValue))
			{
				maxPlayers = Convert.ToInt32(propertiesToCache[byte.MaxValue]);
			}
			if (propertiesToCache.ContainsKey(253))
			{
				isOpen = (bool)propertiesToCache[253];
			}
			if (propertiesToCache.ContainsKey(254))
			{
				isVisible = (bool)propertiesToCache[254];
			}
			if (propertiesToCache.ContainsKey(252))
			{
				PlayerCount = Convert.ToInt32(propertiesToCache[252]);
			}
			if (propertiesToCache.ContainsKey(249))
			{
				autoCleanUp = (bool)propertiesToCache[249];
			}
			if (propertiesToCache.ContainsKey(248))
			{
				masterClientId = (int)propertiesToCache[248];
			}
			if (propertiesToCache.ContainsKey(250))
			{
				propertiesListedInLobby = propertiesToCache[250] as string[];
			}
			if (propertiesToCache.ContainsKey(247))
			{
				expectedUsers = (string[])propertiesToCache[247];
			}
			if (propertiesToCache.ContainsKey(245))
			{
				emptyRoomTtl = (int)propertiesToCache[245];
			}
			if (propertiesToCache.ContainsKey(246))
			{
				playerTtl = (int)propertiesToCache[246];
			}
			customProperties.MergeStringKeys(propertiesToCache);
			customProperties.StripKeysWithNullValues();
		}
	}
	[DisallowMultipleComponent]
	[AddComponentMenu("")]
	internal class SupportLogger : MonoBehaviour, IConnectionCallbacks, IMatchmakingCallbacks, IInRoomCallbacks, ILobbyCallbacks, IErrorInfoCallback
	{
		public bool LogTrafficStats = true;

		private LoadBalancingClient client;

		private Stopwatch startStopwatch;

		private bool initialOnApplicationPauseSkipped = false;

		private int pingMax;

		private int pingMin;

		public LoadBalancingClient Client
		{
			get
			{
				return client;
			}
			set
			{
				if (client != value)
				{
					if (client != null)
					{
						client.RemoveCallbackTarget(this);
					}
					client = value;
					if (client != null)
					{
						client.AddCallbackTarget(this);
					}
				}
			}
		}

		protected void Start()
		{
			LogBasics();
			if (startStopwatch == null)
			{
				startStopwatch = new Stopwatch();
				startStopwatch.Start();
			}
		}

		protected void OnDestroy()
		{
			Client = null;
		}

		protected void OnApplicationPause(bool pause)
		{
			if (!initialOnApplicationPauseSkipped)
			{
				initialOnApplicationPauseSkipped = true;
			}
			else
			{
				Debug_.Log(string.Format("{0} SupportLogger OnApplicationPause({1}). Client: {2}.", GetFormattedTimestamp(), pause, (client == null) ? "null" : client.State.ToString()));
			}
		}

		protected void OnApplicationQuit()
		{
			CancelInvoke();
		}

		public void StartLogStats()
		{
			InvokeRepeating("LogStats", 10f, 10f);
		}

		public void StopLogStats()
		{
			CancelInvoke("LogStats");
		}

		private void StartTrackValues()
		{
			InvokeRepeating("TrackValues", 0.5f, 0.5f);
		}

		private void StopTrackValues()
		{
			CancelInvoke("TrackValues");
		}

		private string GetFormattedTimestamp()
		{
			if (startStopwatch == null)
			{
				startStopwatch = new Stopwatch();
				startStopwatch.Start();
			}
			TimeSpan elapsed = startStopwatch.Elapsed;
			if (elapsed.Minutes > 0)
			{
				return string.Format("[{0}:{1}.{1}]", elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds);
			}
			return $"[{elapsed.Seconds}.{elapsed.Milliseconds}]";
		}

		private void TrackValues()
		{
			if (client != null)
			{
				int roundTripTime = client.LoadBalancingPeer.RoundTripTime;
				if (roundTripTime > pingMax)
				{
					pingMax = roundTripTime;
				}
				if (roundTripTime < pingMin)
				{
					pingMin = roundTripTime;
				}
			}
		}

		public void LogStats()
		{
			if (client != null && client.State != ClientState.PeerCreated && LogTrafficStats)
			{
				Debug_.Log($"{GetFormattedTimestamp()} SupportLogger {client.LoadBalancingPeer.VitalStatsToString(all: false)} Ping min/max: {pingMin}/{pingMax}");
			}
		}

		private void LogBasics()
		{
			if (client != null)
			{
				List<string> list = new List<string>(10);
				list.Add(Application.unityVersion);
				list.Add(Application.platform.ToString());
				if (RuntimeUnityFlagsSetup.IsENABLE_IL2CPP)
				{
					list.Add("ENABLE_IL2CPP");
				}
				if (RuntimeUnityFlagsSetup.IsENABLE_MONO)
				{
					list.Add("ENABLE_MONO");
				}
				list.Add("DEBUG");
				if (RuntimeUnityFlagsSetup.IsNET_4_6)
				{
					list.Add("NET_4_6");
				}
				if (RuntimeUnityFlagsSetup.IsNET_STANDARD_2_0)
				{
					list.Add("NET_STANDARD_2_0");
				}
				StringBuilder stringBuilder = new StringBuilder();
				string text = ((string.IsNullOrEmpty(client.AppId) || client.AppId.Length < 8) ? client.AppId : (client.AppId.Substring(0, 8) + "***"));
				stringBuilder.AppendFormat("{0} SupportLogger Info: ", GetFormattedTimestamp());
				stringBuilder.AppendFormat("AppID: \"{0}\" AppVersion: \"{1}\" Client: v{2} ({4}) Build: {3} ", text, client.AppVersion, PhotonPeer.Version, string.Join(", ", list.ToArray()), client.LoadBalancingPeer.TargetFramework);
				if (client != null && client.LoadBalancingPeer != null && client.LoadBalancingPeer.SocketImplementation != null)
				{
					stringBuilder.AppendFormat("Socket: {0} ", client.LoadBalancingPeer.SocketImplementation.Name);
				}
				stringBuilder.AppendFormat("UserId: \"{0}\" AuthType: {1} AuthMode: {2} {3} ", client.UserId, (client.AuthValues != null) ? client.AuthValues.AuthType.ToString() : "N/A", client.AuthMode, client.EncryptionMode);
				stringBuilder.AppendFormat("State: {0} ", client.State);
				stringBuilder.AppendFormat("PeerID: {0} ", client.LoadBalancingPeer.PeerID);
				stringBuilder.AppendFormat("NameServer: {0} Current Server: {1} IP: {2} Region: {3} ", client.NameServerHost, client.CurrentServerAddress, client.LoadBalancingPeer.ServerIpAddress, client.CloudRegion);
				stringBuilder.AppendFormat("{0} UTC", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
				Debug_.LogWarning(stringBuilder.ToString());
			}
		}

		public void OnConnected()
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnConnected().");
			pingMax = 0;
			pingMin = client.LoadBalancingPeer.RoundTripTime;
			LogBasics();
			if (LogTrafficStats)
			{
				client.LoadBalancingPeer.TrafficStatsEnabled = false;
				client.LoadBalancingPeer.TrafficStatsEnabled = true;
				StartLogStats();
			}
			StartTrackValues();
		}

		public void OnConnectedToMaster()
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnConnectedToMaster().");
		}

		public void OnFriendListUpdate(List<FriendInfo> friendList)
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnFriendListUpdate(friendList).");
		}

		public void OnJoinedLobby()
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnJoinedLobby(" + client.CurrentLobby?.ToString() + ").");
		}

		public void OnLeftLobby()
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnLeftLobby().");
		}

		public void OnCreateRoomFailed(short returnCode, string message)
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnCreateRoomFailed(" + returnCode + "," + message + ").");
		}

		public void OnJoinedRoom()
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnJoinedRoom(" + client.CurrentRoom?.ToString() + "). " + client.CurrentLobby?.ToString() + " GameServer:" + client.GameServerAddress);
		}

		public void OnJoinRoomFailed(short returnCode, string message)
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnJoinRoomFailed(" + returnCode + "," + message + ").");
		}

		public void OnJoinRandomFailed(short returnCode, string message)
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnJoinRandomFailed(" + returnCode + "," + message + ").");
		}

		public void OnCreatedRoom()
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnCreatedRoom(" + client.CurrentRoom?.ToString() + "). " + client.CurrentLobby?.ToString() + " GameServer:" + client.GameServerAddress);
		}

		public void OnLeftRoom()
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnLeftRoom().");
		}

		public void OnDisconnected(DisconnectCause cause)
		{
			StopLogStats();
			StopTrackValues();
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnDisconnected(" + cause.ToString() + ").");
			LogBasics();
			LogStats();
		}

		public void OnRegionListReceived(RegionHandler regionHandler)
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnRegionListReceived(regionHandler).");
		}

		public void OnRoomListUpdate(List<RoomInfo> roomList)
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnRoomListUpdate(roomList). roomList.Count: " + roomList.Count);
		}

		public void OnPlayerEnteredRoom(Player newPlayer)
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnPlayerEnteredRoom(" + newPlayer?.ToString() + ").");
		}

		public void OnPlayerLeftRoom(Player otherPlayer)
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnPlayerLeftRoom(" + otherPlayer?.ToString() + ").");
		}

		public void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnRoomPropertiesUpdate(propertiesThatChanged).");
		}

		public void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnPlayerPropertiesUpdate(targetPlayer,changedProps).");
		}

		public void OnMasterClientSwitched(Player newMasterClient)
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnMasterClientSwitched(" + newMasterClient?.ToString() + ").");
		}

		public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnCustomAuthenticationResponse(" + data.ToStringFull() + ").");
		}

		public void OnCustomAuthenticationFailed(string debugMessage)
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnCustomAuthenticationFailed(" + debugMessage + ").");
		}

		public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
		{
			Debug_.Log(GetFormattedTimestamp() + " SupportLogger OnLobbyStatisticsUpdate(lobbyStatistics).");
		}

		public void OnErrorInfo(ErrorInfo errorInfo)
		{
			Debug_.LogError(errorInfo.ToString());
		}
	}
	internal class SystemConnectionSummary
	{
		private class SCSBitPos
		{
			public const int Version = 28;

			public const int UsedProtocol = 25;

			public const int EmptyBit = 24;

			public const int AppQuits = 23;

			public const int AppPause = 22;

			public const int AppPauseRecent = 21;

			public const int AppOutOfFocus = 20;

			public const int AppOutOfFocusRecent = 19;

			public const int NetworkReachable = 18;

			public const int ErrorCodeFits = 17;

			public const int ErrorCodeWinSock = 16;
		}

		public readonly byte Version = 0;

		public byte UsedProtocol;

		public bool AppQuits;

		public bool AppPause;

		public bool AppPauseRecent;

		public bool AppOutOfFocus;

		public bool AppOutOfFocusRecent;

		public bool NetworkReachable;

		public bool ErrorCodeFits;

		public bool ErrorCodeWinSock;

		public int SocketErrorCode;

		private static readonly string[] ProtocolIdToName = new string[8] { "UDP", "TCP", "2(N/A)", "3(N/A)", "WS", "WSS", "6(N/A)", "7WebRTC" };

		public SystemConnectionSummary(LoadBalancingClient client)
		{
			if (client != null)
			{
				UsedProtocol = (byte)(client.LoadBalancingPeer.UsedProtocol & (ConnectionProtocol)7);
				SocketErrorCode = client.LoadBalancingPeer.SocketErrorCode;
			}
			AppQuits = ConnectionHandler.AppQuits;
			AppPause = ConnectionHandler.AppPause;
			AppPauseRecent = ConnectionHandler.AppPauseRecent;
			AppOutOfFocus = ConnectionHandler.AppOutOfFocus;
			AppOutOfFocusRecent = ConnectionHandler.AppOutOfFocusRecent;
			NetworkReachable = ConnectionHandler.IsNetworkReachableUnity();
			ErrorCodeFits = SocketErrorCode <= 32767;
			ErrorCodeWinSock = true;
		}

		public SystemConnectionSummary(int summary)
		{
			Version = GetBits(ref summary, 28, 15);
			UsedProtocol = GetBits(ref summary, 25, 7);
			AppQuits = GetBit(ref summary, 23);
			AppPause = GetBit(ref summary, 22);
			AppPauseRecent = GetBit(ref summary, 21);
			AppOutOfFocus = GetBit(ref summary, 20);
			AppOutOfFocusRecent = GetBit(ref summary, 19);
			NetworkReachable = GetBit(ref summary, 18);
			ErrorCodeFits = GetBit(ref summary, 17);
			ErrorCodeWinSock = GetBit(ref summary, 16);
			SocketErrorCode = summary & 0xFFFF;
		}

		public int ToInt()
		{
			int value = 0;
			SetBits(ref value, Version, 28);
			SetBits(ref value, UsedProtocol, 25);
			SetBit(ref value, AppQuits, 23);
			SetBit(ref value, AppPause, 22);
			SetBit(ref value, AppPauseRecent, 21);
			SetBit(ref value, AppOutOfFocus, 20);
			SetBit(ref value, AppOutOfFocusRecent, 19);
			SetBit(ref value, NetworkReachable, 18);
			SetBit(ref value, ErrorCodeFits, 17);
			SetBit(ref value, ErrorCodeWinSock, 16);
			int num = SocketErrorCode & 0xFFFF;
			return value | num;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			string arg = ProtocolIdToName[UsedProtocol];
			stringBuilder.Append($"SCS v{Version} {arg} SocketErrorCode: {SocketErrorCode} ");
			if (AppQuits)
			{
				stringBuilder.Append("AppQuits ");
			}
			if (AppPause)
			{
				stringBuilder.Append("AppPause ");
			}
			if (!AppPause && AppPauseRecent)
			{
				stringBuilder.Append("AppPauseRecent ");
			}
			if (AppOutOfFocus)
			{
				stringBuilder.Append("AppOutOfFocus ");
			}
			if (!AppOutOfFocus && AppOutOfFocusRecent)
			{
				stringBuilder.Append("AppOutOfFocusRecent ");
			}
			if (!NetworkReachable)
			{
				stringBuilder.Append("NetworkUnreachable ");
			}
			if (!ErrorCodeFits)
			{
				stringBuilder.Append("ErrorCodeRangeExceeded ");
			}
			if (ErrorCodeWinSock)
			{
				stringBuilder.Append("WinSock");
			}
			else
			{
				stringBuilder.Append("BSDSock");
			}
			return stringBuilder.ToString();
		}

		public static bool GetBit(ref int value, int bitpos)
		{
			int num = (value >> bitpos) & 1;
			return num != 0;
		}

		public static byte GetBits(ref int value, int bitpos, byte mask)
		{
			int num = (value >> bitpos) & mask;
			return (byte)num;
		}

		public static void SetBit(ref int value, bool bitval, int bitpos)
		{
			if (bitval)
			{
				value |= 1 << bitpos;
			}
			else
			{
				value &= ~(1 << bitpos);
			}
		}

		public static void SetBits(ref int value, byte bitvals, int bitpos)
		{
			value |= bitvals << bitpos;
		}
	}
	internal class WebRpcResponse
	{
		public string Name { get; private set; }

		public int ResultCode { get; private set; }

		[Obsolete("Use ResultCode instead")]
		public int ReturnCode => ResultCode;

		public string Message { get; private set; }

		[Obsolete("Use Message instead")]
		public string DebugMessage => Message;

		public Dictionary<string, object> Parameters { get; private set; }

		public WebRpcResponse(OperationResponse response)
		{
			if (response.Parameters.TryGetValue(209, out var value))
			{
				Name = value as string;
			}
			ResultCode = -1;
			if (response.Parameters.TryGetValue(207, out value))
			{
				ResultCode = (byte)value;
			}
			if (response.Parameters.TryGetValue(208, out value))
			{
				Parameters = value as Dictionary<string, object>;
			}
			if (response.Parameters.TryGetValue(206, out value))
			{
				Message = value as string;
			}
		}

		public string ToStringFull()
		{
			return string.Format("{0}={2}: {1} \"{3}\"", Name, SupportClass.DictionaryToString(Parameters), ResultCode, Message);
		}
	}
	internal class WebFlags
	{
		public static readonly WebFlags Default = new WebFlags(0);

		public byte WebhookFlags;

		public const byte HttpForwardConst = 1;

		public const byte SendAuthCookieConst = 2;

		public const byte SendSyncConst = 4;

		public const byte SendStateConst = 8;

		public bool HttpForward
		{
			get
			{
				return (WebhookFlags & 1) != 0;
			}
			set
			{
				if (value)
				{
					WebhookFlags |= 1;
				}
				else
				{
					WebhookFlags = (byte)(WebhookFlags & -2);
				}
			}
		}

		public bool SendAuthCookie
		{
			get
			{
				return (WebhookFlags & 2) != 0;
			}
			set
			{
				if (value)
				{
					WebhookFlags |= 2;
				}
				else
				{
					WebhookFlags = (byte)(WebhookFlags & -3);
				}
			}
		}

		public bool SendSync
		{
			get
			{
				return (WebhookFlags & 4) != 0;
			}
			set
			{
				if (value)
				{
					WebhookFlags |= 4;
				}
				else
				{
					WebhookFlags = (byte)(WebhookFlags & -5);
				}
			}
		}

		public bool SendState
		{
			get
			{
				return (WebhookFlags & 8) != 0;
			}
			set
			{
				if (value)
				{
					WebhookFlags |= 8;
				}
				else
				{
					WebhookFlags = (byte)(WebhookFlags & -9);
				}
			}
		}

		public WebFlags(byte webhookFlags)
		{
			WebhookFlags = webhookFlags;
		}
	}
	[Serializable]
	public class FusionAppSettings : AppSettings
	{
		[InlineHelp]
		public EncryptionMode encryptionMode;

		[InlineHelp]
		public int emptyRoomTtl;

		public new FusionAppSettings GetCopy()
		{
			FusionAppSettings fusionAppSettings = new FusionAppSettings();
			CopyTo(fusionAppSettings);
			fusionAppSettings.encryptionMode = encryptionMode;
			fusionAppSettings.emptyRoomTtl = emptyRoomTtl;
			return fusionAppSettings;
		}

		public override string ToString()
		{
			return $"encryptionMode {encryptionMode}, emptyRoomTtl {emptyRoomTtl}, {ToStringFull()}";
		}
	}
	[Serializable]
	[HelpURL("https://doc.photonengine.com/en-us/pun/v2/getting-started/initial-setup")]
	[CreateAssetMenu(menuName = "Fusion/Photon Application Settings", fileName = "PhotonAppSettings")]
	[FusionGlobalScriptableObject("Assets/Photon/Fusion/Resources/PhotonAppSettings.asset")]
	public class PhotonAppSettings : FusionGlobalScriptableObject<PhotonAppSettings>
	{
		[InlineHelp]
		public FusionAppSettings AppSettings;

		public static PhotonAppSettings Global => FusionGlobalScriptableObject<PhotonAppSettings>.GlobalInternal;

		public static bool IsGlobalLoaded => FusionGlobalScriptableObject<PhotonAppSettings>.IsGlobalLoadedInternal;

		public static bool TryGetGlobal(out PhotonAppSettings settings)
		{
			return FusionGlobalScriptableObject<PhotonAppSettings>.TryGetGlobalInternal(out settings);
		}
	}
}
namespace Fusion.Photon.Realtime.Extension
{
	internal static class RealtimeExtensions_Hashtable
	{
		private static readonly StreamBuffer buffer = new StreamBuffer(1024);

		private static readonly Protocol18 protocol = new Protocol18();

		public static Dictionary<string, SessionProperty> ConvertToDictionaryProperty(this ExitGames.Client.Photon.Hashtable customProperties)
		{
			Dictionary<string, SessionProperty> dictionary = new Dictionary<string, SessionProperty>();
			foreach (DictionaryEntry customProperty in customProperties)
			{
				if (customProperty.Key is string key && SessionProperty.Support(customProperty.Value))
				{
					dictionary[key] = SessionProperty.Convert(customProperty.Value);
				}
			}
			return dictionary;
		}

		public static ExitGames.Client.Photon.Hashtable ConvertToHashtable(this Dictionary<string, SessionProperty> properties)
		{
			ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
			foreach (KeyValuePair<string, SessionProperty> property in properties)
			{
				if (property.Key != null && property.Value != null)
				{
					hashtable[property.Key] = property.Value.PropertyValue;
				}
			}
			return hashtable;
		}

		public static int CalculateTotalSize(this ExitGames.Client.Photon.Hashtable hashtable)
		{
			buffer.Position = 0;
			protocol.Serialize(buffer, hashtable, setType: true);
			return buffer.Position;
		}
	}
	internal static class RealtimeExtensions_RoomInfo
	{
		public static Dictionary<string, SessionProperty> GetCustomProperties(this RoomInfo roomInfo)
		{
			return roomInfo.CustomProperties.ConvertToDictionaryProperty();
		}
	}
	internal static class RealtimeExtensions_DictionaryProperties
	{
		public static int CalculateTotalSize(Dictionary<string, SessionProperty> dictionary)
		{
			return dictionary.ConvertToHashtable().CalculateTotalSize();
		}
	}
}
namespace Fusion.Photon.Realtime.Async
{
	internal class PhotonConnectionCallbacks
	{
		public Action ConnectedToMaster;

		public Action ConnectedToNameServer;

		public Action<RegionHandler> RegionListReceived;

		public Action<DisconnectCause> Disconnected;

		public Action<string> CustomAuthenticationFailed;

		public Action<Dictionary<string, object>> CustomAuthenticationResponse;
	}
	internal class PhotonMatchmakingCallbacks
	{
		public Action<List<FriendInfo>> FriendListUpdate;

		public Action JoinedRoom;

		public Action CreatedRoom;

		public Action<short, string> JoinRoomFailed;

		public Action<short, string> JoinRoomRandomFailed;

		public Action<short, string> CreateRoomFailed;

		public Action LeftRoom;
	}
	internal class PhotonLobbyCallbacks
	{
		public Action JoinedLobby;
	}
	internal class DisconnectException : Exception
	{
		public DisconnectCause Cause;

		public DisconnectException(DisconnectCause cause)
			: base(cause.ToString())
		{
			Cause = cause;
		}
	}
	internal class AuthenticationFailedException : Exception
	{
		public AuthenticationFailedException(string message)
			: base(message)
		{
		}
	}
	internal class OperationException : Exception
	{
		public short ErrorCode;

		public OperationException(short errorCode, string message)
			: base($"{message} (ErrorCode: {errorCode})")
		{
			ErrorCode = errorCode;
		}
	}
	internal class OperationStartException : Exception
	{
		public OperationStartException(string message)
			: base(message)
		{
		}
	}
	internal class OperationTimeoutException : Exception
	{
		public OperationTimeoutException(string message)
			: base(message)
		{
		}
	}
	internal static class LoadBalancingClientAsyncExtensions
	{
		private const int SERVICE_INTERVAL_MS = 10;

		public static Task<RegionHandler> GetRegionsAsync(this LoadBalancingClient client, bool throwOnError = true, bool createServiceTask = true, CancellationToken externalCancelationToken = default(CancellationToken))
		{
			if (!client.ConnectToNameServer())
			{
				return Task.FromException<RegionHandler>(new OperationStartException("Failed to get regions"));
			}
			TaskCompletionSource<RegionHandler> result = new TaskCompletionSource<RegionHandler>(externalCancelationToken);
			OperationHandler handler = client.CreateOpHandler(throwOnError, createServiceTask, externalCancelationToken);
			PhotonConnectionCallbacks connectionCallbacks = handler.ConnectionCallbacks;
			connectionCallbacks.Disconnected = (Action<DisconnectCause>)Delegate.Combine(connectionCallbacks.Disconnected, (Action<DisconnectCause>)delegate(DisconnectCause cause)
			{
				handler.SetResult(0);
				result.SetException(new OperationStartException($"Failed to get regions. Disconnection cause: {cause}"));
			});
			PhotonConnectionCallbacks connectionCallbacks2 = handler.ConnectionCallbacks;
			connectionCallbacks2.RegionListReceived = (Action<RegionHandler>)Delegate.Combine(connectionCallbacks2.RegionListReceived, (Action<RegionHandler>)delegate(RegionHandler regionHandler)
			{
				regionHandler.PingMinimumOfRegions(delegate(RegionHandler regionHandlerWithPing)
				{
					if (externalCancelationToken.IsCancellationRequested)
					{
						result.SetResult(null);
						handler.SetResult(0);
					}
					else
					{
						result.SetResult(regionHandlerWithPing);
						handler.SetResult(0);
					}
				}, string.Empty);
			});
			return result.Task;
		}

		public static Task ConnectUsingSettingsAsync(this LoadBalancingClient client, AppSettings appSettings, bool createServiceTask = true, CancellationToken externalCancellationToken = default(CancellationToken))
		{
			if (client.State != ClientState.Disconnected && client.State != ClientState.PeerCreated)
			{
				return Task.FromException(new OperationStartException("Client still connected"));
			}
			if (!client.ConnectUsingSettings(appSettings))
			{
				return Task.FromException(new OperationStartException("Failed to start connecting"));
			}
			return client.CreateOpHandler(throwOnErrors: true, createServiceTask, externalCancellationToken).Task;
		}

		public static Task ReconnectAndRejoinAsync(this LoadBalancingClient client, bool throwOnError = true, bool createServiceTask = true, CancellationToken externalCancellationToken = default(CancellationToken))
		{
			if (client.State != ClientState.Disconnected)
			{
				return Task.FromException(new OperationStartException("Client still connected"));
			}
			if (!client.ReconnectAndRejoin())
			{
				return Task.FromException(new OperationStartException("Failed to start reconnecting"));
			}
			return client.CreateOpHandler(throwOnError, createServiceTask, externalCancellationToken).Task;
		}

		public static Task DisconnectAsync(this LoadBalancingClient client, bool createServiceTask = true, CancellationToken externalCancellationToken = default(CancellationToken))
		{
			if (client == null)
			{
				return Task.CompletedTask;
			}
			if (client.State == ClientState.Disconnected)
			{
				return Task.CompletedTask;
			}
			OperationHandler handler = client.CreateOpHandler(throwOnErrors: true, createServiceTask, externalCancellationToken);
			PhotonConnectionCallbacks connectionCallbacks = handler.ConnectionCallbacks;
			connectionCallbacks.Disconnected = (Action<DisconnectCause>)Delegate.Combine(connectionCallbacks.Disconnected, (Action<DisconnectCause>)delegate(DisconnectCause cause)
			{
				InternalLogStreams.LogInfo?.Log($"Disconnected: {cause}");
				handler.SetResult(0);
			});
			client.Disconnect();
			return handler.Task;
		}

		public static Task LeaveRoomAsync(this LoadBalancingClient client, bool createServiceTask = true, CancellationToken externalCancellationToken = default(CancellationToken))
		{
			if (client == null)
			{
				return Task.CompletedTask;
			}
			if (client.State == ClientState.Disconnected || !client.InRoom)
			{
				return Task.CompletedTask;
			}
			OperationHandler handler = client.CreateOpHandler(throwOnErrors: true, createServiceTask, externalCancellationToken);
			PhotonMatchmakingCallbacks matchmakingCallbacks = handler.MatchmakingCallbacks;
			matchmakingCallbacks.LeftRoom = (Action)Delegate.Combine(matchmakingCallbacks.LeftRoom, (Action)delegate
			{
				InternalLogStreams.LogInfo?.Log("Left Room");
				handler.SetResult(0);
			});
			client.OpLeaveRoom(becomeInactive: false);
			return handler.Task;
		}

		public static Task<short> CreateRoomAsync(this LoadBalancingClient client, EnterRoomParams enterRoomParams, bool throwOnError = true, bool createServiceTask = true, CancellationToken externalCancellationToken = default(CancellationToken))
		{
			if (!client.OpCreateRoom(enterRoomParams))
			{
				return Task.FromException<short>(new OperationStartException("Failed to send CreateRoom operation"));
			}
			return client.CreateOpHandler(throwOnError, createServiceTask, externalCancellationToken).Task;
		}

		public static Task<short> CreateOrJoinRoomAsync(this LoadBalancingClient client, EnterRoomParams enterRoomParams, bool throwOnError = true, bool createServiceTask = true, CancellationToken externalCancellationToken = default(CancellationToken))
		{
			if (!client.OpJoinOrCreateRoom(enterRoomParams))
			{
				return Task.FromException<short>(new OperationStartException("Failed to send CreateRoom operation"));
			}
			return client.CreateOpHandler(throwOnError, createServiceTask, externalCancellationToken).Task;
		}

		public static Task<short> JoinRoomAsync(this LoadBalancingClient client, EnterRoomParams enterRoomParams, bool throwOnError = true, bool createServiceTask = true, CancellationToken externalCancellationToken = default(CancellationToken))
		{
			if (!client.OpJoinRoom(enterRoomParams))
			{
				return Task.FromException<short>(new OperationStartException("Failed to send JoinRoom operation"));
			}
			return client.CreateOpHandler(throwOnError, createServiceTask, externalCancellationToken).Task;
		}

		public static Task<short> JoinRandomOrCreateRoomAsync(this LoadBalancingClient client, OpJoinRandomRoomParams joinRandomRoomParams, EnterRoomParams enterRoomParams, bool throwOnError = true, bool createServiceTask = true, CancellationToken externalCancellationToken = default(CancellationToken))
		{
			if (!client.OpJoinRandomOrCreateRoom(joinRandomRoomParams, enterRoomParams))
			{
				return Task.FromException<short>(new OperationStartException("Failed to send JoinRandomOrCreateRoom operation"));
			}
			return client.CreateOpHandler(throwOnError, createServiceTask, externalCancellationToken).Task;
		}

		public static Task<short> JoinRandomRoomAsync(this LoadBalancingClient client, OpJoinRandomRoomParams joinRandomRoomParams, bool throwOnError = true, bool createServiceTask = true, CancellationToken externalCancellationToken = default(CancellationToken))
		{
			if (!client.OpJoinRandomRoom(joinRandomRoomParams))
			{
				return Task.FromException<short>(new OperationStartException("Failed to send JoinRandomRoom operation"));
			}
			return client.CreateOpHandler(throwOnError, createServiceTask, externalCancellationToken).Task;
		}

		public static Task<short> JoinLobbyAsync(this LoadBalancingClient client, TypedLobby lobby, bool throwOnError = true, bool createServiceTask = true, CancellationToken externalCancelationToken = default(CancellationToken))
		{
			if (!client.OpJoinLobby(lobby))
			{
				return Task.FromException<short>(new OperationStartException("Failed to send JoinLobby operation"));
			}
			return client.CreateOpHandler(throwOnError, createServiceTask, externalCancelationToken).Task;
		}

		public static OperationHandler CreateOpHandler(this LoadBalancingClient client, bool throwOnErrors = true, bool createServiceTask = true, CancellationToken externalCancellationToken = default(CancellationToken))
		{
			OperationHandler handler = new OperationHandler(throwOnErrors, externalCancellationToken);
			client.AddCallbackTarget(handler);
			TaskManager.ContinueWhenAll(new Task[1] { handler.Task }, delegate
			{
				client.RemoveCallbackTarget(handler);
				return Task.CompletedTask;
			}, handler.Token);
			if (createServiceTask)
			{
				client.Service_ClientUpdate(handler.Token, handler.CompletionSource);
			}
			return handler;
		}

		public static void Service_ClientUpdate(this LoadBalancingClient client, CancellationToken token, TaskCompletionSource<short> completionSource)
		{
			TaskManager.Service(delegate
			{
				try
				{
					if (!token.IsCancellationRequested)
					{
						client.Service();
					}
				}
				catch (Exception exception)
				{
					completionSource.TrySetException(exception);
				}
				return Task.FromResult(client.IsConnected);
			}, token, 10, "AsyncClientUpdate");
		}
	}
	internal class OperationHandler : IConnectionCallbacks, IMatchmakingCallbacks, ILobbyCallbacks
	{
		public PhotonConnectionCallbacks ConnectionCallbacks = new PhotonConnectionCallbacks();

		public PhotonMatchmakingCallbacks MatchmakingCallbacks = new PhotonMatchmakingCallbacks();

		public PhotonLobbyCallbacks LobbyCallbacks = new PhotonLobbyCallbacks();

		private bool _throwOnErrors;

		private TaskCompletionSource<short> _result;

		private CancellationTokenSource _cancellation;

		private const float OPERATION_TIMEOUT_SEC = 30f;

		public Task<short> Task => _result.Task;

		public TaskCompletionSource<short> CompletionSource => _result;

		public CancellationToken Token => _cancellation.Token;

		public bool IsCancellationRequested => _cancellation.IsCancellationRequested;

		public OperationHandler(bool throwOnErrors = true, CancellationToken externalCancellationToken = default(CancellationToken))
		{
			_result = new TaskCompletionSource<short>();
			_cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(30.0));
			_cancellation.Token.Register(Expire);
			_throwOnErrors = throwOnErrors;
			if (externalCancellationToken != default(CancellationToken))
			{
				externalCancellationToken.Register(Cancel);
			}
		}

		public void SetResult(short result)
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
			SetException(new OperationTimeoutException("Operation timed out"));
		}

		private void Cancel()
		{
			SetException(new OperationCanceledException("Operation cancelled."));
		}

		public void OnConnected()
		{
			ConnectionCallbacks.ConnectedToNameServer?.Invoke();
		}

		public void OnConnectedToMaster()
		{
			if (ConnectionCallbacks.ConnectedToMaster != null)
			{
				ConnectionCallbacks.ConnectedToMaster();
			}
			else
			{
				SetResult(0);
			}
		}

		public void OnCustomAuthenticationFailed(string debugMessage)
		{
			if (ConnectionCallbacks.CustomAuthenticationFailed != null)
			{
				ConnectionCallbacks.CustomAuthenticationFailed(debugMessage);
			}
			else
			{
				SetException(new AuthenticationFailedException(debugMessage));
			}
		}

		public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
		{
			ConnectionCallbacks.CustomAuthenticationResponse?.Invoke(data);
		}

		public void OnDisconnected(DisconnectCause cause)
		{
			if (ConnectionCallbacks.Disconnected != null)
			{
				ConnectionCallbacks.Disconnected(cause);
			}
			else
			{
				SetException(new DisconnectException(cause));
			}
		}

		public void OnRegionListReceived(RegionHandler regionHandler)
		{
			ConnectionCallbacks.RegionListReceived?.Invoke(regionHandler);
		}

		public void OnCreatedRoom()
		{
			MatchmakingCallbacks.CreatedRoom?.Invoke();
		}

		public void OnCreateRoomFailed(short returnCode, string message)
		{
			if (MatchmakingCallbacks.CreateRoomFailed != null)
			{
				MatchmakingCallbacks.CreateRoomFailed(returnCode, message);
				return;
			}
			if (_throwOnErrors)
			{
				SetException(new OperationException(returnCode, message));
				return;
			}
			InternalLogStreams.LogError?.Log(message);
			SetResult(returnCode);
		}

		public void OnFriendListUpdate(List<FriendInfo> friendList)
		{
			MatchmakingCallbacks.FriendListUpdate?.Invoke(friendList);
		}

		public void OnJoinedRoom()
		{
			if (MatchmakingCallbacks.JoinedRoom != null)
			{
				MatchmakingCallbacks.JoinedRoom();
			}
			else
			{
				SetResult(0);
			}
		}

		public void OnJoinRandomFailed(short returnCode, string message)
		{
			if (MatchmakingCallbacks.JoinRoomRandomFailed != null)
			{
				MatchmakingCallbacks.JoinRoomRandomFailed(returnCode, message);
				return;
			}
			if (_throwOnErrors)
			{
				SetException(new OperationException(returnCode, message));
				return;
			}
			InternalLogStreams.LogError?.Log(message);
			SetResult(returnCode);
		}

		public void OnJoinRoomFailed(short returnCode, string message)
		{
			if (MatchmakingCallbacks.JoinRoomFailed != null)
			{
				MatchmakingCallbacks.JoinRoomFailed(returnCode, message);
				return;
			}
			if (_throwOnErrors)
			{
				SetException(new OperationException(returnCode, message));
				return;
			}
			InternalLogStreams.LogError?.Log(message);
			SetResult(returnCode);
		}

		public void OnLeftRoom()
		{
			if (MatchmakingCallbacks.LeftRoom != null)
			{
				MatchmakingCallbacks.LeftRoom();
			}
			else
			{
				SetResult(0);
			}
		}

		public void OnJoinedLobby()
		{
			if (LobbyCallbacks.JoinedLobby != null)
			{
				LobbyCallbacks.JoinedLobby();
			}
			else
			{
				SetResult(0);
			}
		}

		public void OnLeftLobby()
		{
		}

		public void OnRoomListUpdate(List<RoomInfo> roomList)
		{
		}

		public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
		{
		}
	}
}
