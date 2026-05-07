using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Fusion;
using Fusion.Photon.Realtime;
using Fusion.Sockets;
using Photon.Realtime;
using Photon.Voice.Unity;
using UnityEngine;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NetworkAssemblyWeaved]
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
			FilePathsData = new byte[202]
			{
				0, 0, 0, 1, 0, 0, 0, 59, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 86,
				111, 105, 99, 101, 92, 67, 111, 100, 101, 92,
				70, 117, 115, 105, 111, 110, 92, 70, 117, 115,
				105, 111, 110, 86, 111, 105, 99, 101, 66, 114,
				105, 100, 103, 101, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 59, 92, 65, 115, 115, 101,
				116, 115, 92, 80, 104, 111, 116, 111, 110, 92,
				80, 104, 111, 116, 111, 110, 86, 111, 105, 99,
				101, 92, 67, 111, 100, 101, 92, 70, 117, 115,
				105, 111, 110, 92, 70, 117, 115, 105, 111, 110,
				86, 111, 105, 99, 101, 67, 108, 105, 101, 110,
				116, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 60, 92, 65, 115, 115, 101, 116, 115, 92,
				80, 104, 111, 116, 111, 110, 92, 80, 104, 111,
				116, 111, 110, 86, 111, 105, 99, 101, 92, 67,
				111, 100, 101, 92, 70, 117, 115, 105, 111, 110,
				92, 86, 111, 105, 99, 101, 78, 101, 116, 119,
				111, 114, 107, 79, 98, 106, 101, 99, 116, 46,
				99, 115
			},
			TypesData = new byte[127]
			{
				0, 0, 0, 0, 37, 80, 104, 111, 116, 111,
				110, 46, 86, 111, 105, 99, 101, 46, 70, 117,
				115, 105, 111, 110, 124, 70, 117, 115, 105, 111,
				110, 86, 111, 105, 99, 101, 66, 114, 105, 100,
				103, 101, 0, 0, 0, 0, 37, 80, 104, 111,
				116, 111, 110, 46, 86, 111, 105, 99, 101, 46,
				70, 117, 115, 105, 111, 110, 124, 70, 117, 115,
				105, 111, 110, 86, 111, 105, 99, 101, 67, 108,
				105, 101, 110, 116, 0, 0, 0, 0, 38, 80,
				104, 111, 116, 111, 110, 46, 86, 111, 105, 99,
				101, 46, 70, 117, 115, 105, 111, 110, 124, 86,
				111, 105, 99, 101, 78, 101, 116, 119, 111, 114,
				107, 79, 98, 106, 101, 99, 116
			},
			TotalFiles = 3,
			TotalTypes = 3,
			IsEditorOnly = false
		};
	}
}
namespace Photon.Voice.Fusion;

[RequireComponent(typeof(NetworkRunner))]
[RequireComponent(typeof(VoiceConnection))]
public class FusionVoiceBridge : VoiceComponent, INetworkRunnerCallbacks, IPublicFacingInterface
{
	private NetworkRunner networkRunner;

	private VoiceConnection voiceConnection;

	private EnterRoomParams voiceRoomParams = new EnterRoomParams
	{
		RoomOptions = new RoomOptions
		{
			IsVisible = false
		}
	};

	private const byte FusionNetworkIdTypeCode = 0;

	private static byte[] memCompressedUInt64 = new byte[10];

	[field: SerializeField]
	public bool UseFusionAppSettings { get; set; } = true;

	[field: SerializeField]
	public bool UseFusionAuthValues { get; set; } = true;

	protected override void Awake()
	{
		base.Awake();
		VoiceRegisterCustomTypes();
		networkRunner = GetComponent<NetworkRunner>();
		voiceConnection = GetComponent<VoiceConnection>();
		voiceConnection.SpeakerFactory = FusionSpeakerFactory;
	}

	private void OnEnable()
	{
		voiceConnection.Client.StateChanged += OnVoiceClientStateChanged;
		if (networkRunner.IsPlayer && networkRunner.IsConnectedToServer)
		{
			VoiceConnectOrJoinRoom();
		}
	}

	private void OnDisable()
	{
		voiceConnection.Client.StateChanged -= OnVoiceClientStateChanged;
	}

	private void OnVoiceClientStateChanged(ClientState previous, ClientState current)
	{
		VoiceConnectOrJoinRoom(current);
	}

	private Speaker FusionSpeakerFactory(int playerId, byte voiceId, object userData)
	{
		if (!(userData is NetworkId networkId))
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("UserData ({0}) is not of type NetworkId. Remote voice {1}/{2} not linked. Do you have a Recorder not used with a VoiceNetworkObject? is this expected?", (userData == null) ? "null" : userData.ToString(), playerId, voiceId);
			}
			return null;
		}
		if (!networkId.IsValid)
		{
			if (base.Logger.IsWarningEnabled)
			{
				base.Logger.LogWarning("NetworkId is not valid ({0}). Remote voice {1}/{2} not linked.", networkId, playerId, voiceId);
			}
			return null;
		}
		VoiceNetworkObject voiceNetworkObject = networkRunner.TryGetNetworkedBehaviourFromNetworkedObjectRef<VoiceNetworkObject>(networkId);
		if ((object)voiceNetworkObject == null || !voiceNetworkObject)
		{
			if (base.Logger.IsWarningEnabled)
			{
				base.Logger.LogWarning("No voiceNetworkObject found with ID {0}. Remote voice {1}/{2} not linked.", networkId, playerId, voiceId);
			}
			return null;
		}
		if (!voiceNetworkObject.IgnoreGlobalLogLevel)
		{
			voiceNetworkObject.LogLevel = base.LogLevel;
		}
		if (!voiceNetworkObject.IsSpeaker)
		{
			voiceNetworkObject.SetupSpeakerInUse();
		}
		return voiceNetworkObject.SpeakerInUse;
	}

	private string VoiceGetMirroringRoomName()
	{
		return $"{networkRunner.SessionInfo.Name}_voice";
	}

	private void VoiceConnectOrJoinRoom()
	{
		VoiceConnectOrJoinRoom(voiceConnection.ClientState);
	}

	private void VoiceConnectOrJoinRoom(ClientState state)
	{
		if (ConnectionHandler.AppQuits)
		{
			return;
		}
		switch (state)
		{
		case ClientState.PeerCreated:
		case ClientState.Disconnected:
			if (!VoiceConnectAndFollowFusion() && base.Logger.IsErrorEnabled)
			{
				base.Logger.LogError("Connecting to server failed.");
			}
			break;
		case ClientState.ConnectedToMasterServer:
			if (!VoiceJoinMirroringRoom() && base.Logger.IsErrorEnabled)
			{
				base.Logger.LogError("Joining a voice room failed.");
			}
			break;
		case ClientState.Joined:
		{
			string text = VoiceGetMirroringRoomName();
			string text2 = voiceConnection.Client.CurrentRoom.Name;
			if (!text2.Equals(text))
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Voice room mismatch: Expected:\"{0}\" Current:\"{1}\", leaving the second to join the first.", text, text2);
				}
				if (!voiceConnection.Client.OpLeaveRoom(becomeInactive: false) && base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Leaving the current voice room failed.");
				}
			}
			break;
		}
		}
	}

	private bool VoiceConnectAndFollowFusion()
	{
		Photon.Realtime.AppSettings appSettings = new Photon.Realtime.AppSettings();
		if (UseFusionAppSettings)
		{
			appSettings.AppIdVoice = PhotonAppSettings.Global.AppSettings.AppIdVoice;
			appSettings.AppVersion = PhotonAppSettings.Global.AppSettings.AppVersion;
			appSettings.FixedRegion = PhotonAppSettings.Global.AppSettings.FixedRegion;
			appSettings.UseNameServer = PhotonAppSettings.Global.AppSettings.UseNameServer;
			appSettings.Server = PhotonAppSettings.Global.AppSettings.Server;
			appSettings.Port = PhotonAppSettings.Global.AppSettings.Port;
			appSettings.ProxyServer = PhotonAppSettings.Global.AppSettings.ProxyServer;
			appSettings.BestRegionSummaryFromStorage = PhotonAppSettings.Global.AppSettings.BestRegionSummaryFromStorage;
			appSettings.EnableLobbyStatistics = false;
			appSettings.EnableProtocolFallback = PhotonAppSettings.Global.AppSettings.EnableProtocolFallback;
			appSettings.Protocol = PhotonAppSettings.Global.AppSettings.Protocol;
			appSettings.AuthMode = (Photon.Realtime.AuthModeOption)PhotonAppSettings.Global.AppSettings.AuthMode;
			appSettings.NetworkLogging = PhotonAppSettings.Global.AppSettings.NetworkLogging;
		}
		else
		{
			voiceConnection.Settings.CopyTo(appSettings);
		}
		string region = networkRunner.SessionInfo.Region;
		if (string.IsNullOrEmpty(region))
		{
			if (base.Logger.IsWarningEnabled)
			{
				base.Logger.LogWarning("Unexpected: fusion region is empty.");
			}
			if (!string.IsNullOrEmpty(appSettings.FixedRegion))
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Unexpected: fusion region is empty while voice region is set to \"{0}\". Setting it to null now.", appSettings.FixedRegion);
				}
				appSettings.FixedRegion = null;
			}
		}
		else if (!string.Equals(appSettings.FixedRegion, region, StringComparison.OrdinalIgnoreCase))
		{
			if (base.Logger.IsInfoEnabled)
			{
				if (string.IsNullOrEmpty(appSettings.FixedRegion))
				{
					base.Logger.LogInfo("Setting voice region to \"{0}\" to match fusion region.", region);
				}
				else
				{
					base.Logger.LogInfo("Switching voice region to \"{0}\" from \"{1}\" to match fusion region.", region, appSettings.FixedRegion);
				}
			}
			appSettings.FixedRegion = region;
		}
		if (UseFusionAuthValues && networkRunner.AuthenticationValues != null)
		{
			voiceConnection.Client.AuthValues = new Photon.Realtime.AuthenticationValues(networkRunner.AuthenticationValues.UserId)
			{
				AuthGetParameters = networkRunner.AuthenticationValues.AuthGetParameters,
				AuthType = (Photon.Realtime.CustomAuthenticationType)networkRunner.AuthenticationValues.AuthType
			};
			if (networkRunner.AuthenticationValues.AuthPostData != null)
			{
				if (networkRunner.AuthenticationValues.AuthPostData is byte[] authPostData)
				{
					voiceConnection.Client.AuthValues.SetAuthPostData(authPostData);
				}
				else if (networkRunner.AuthenticationValues.AuthPostData is string authPostData2)
				{
					voiceConnection.Client.AuthValues.SetAuthPostData(authPostData2);
				}
				else if (networkRunner.AuthenticationValues.AuthPostData is Dictionary<string, object> authPostData3)
				{
					voiceConnection.Client.AuthValues.SetAuthPostData(authPostData3);
				}
			}
		}
		return voiceConnection.ConnectUsingSettings(appSettings);
	}

	private void VoiceDisconnect()
	{
		voiceConnection.Client.Disconnect();
	}

	private bool VoiceJoinRoom(string voiceRoomName)
	{
		if (string.IsNullOrEmpty(voiceRoomName))
		{
			if (base.Logger.IsErrorEnabled)
			{
				base.Logger.LogError("Voice room name is null or empty.");
			}
			return false;
		}
		voiceRoomParams.RoomName = voiceRoomName;
		return voiceConnection.Client.OpJoinOrCreateRoom(voiceRoomParams);
	}

	private bool VoiceJoinMirroringRoom()
	{
		return VoiceJoinRoom(VoiceGetMirroringRoomName());
	}

	private static void VoiceRegisterCustomTypes()
	{
		PhotonPeer.RegisterType(typeof(NetworkId), 0, SerializeFusionNetworkId, DeserializeFusionNetworkId);
	}

	private static object DeserializeFusionNetworkId(StreamBuffer instream, short length)
	{
		NetworkId networkId = default(NetworkId);
		lock (memCompressedUInt64)
		{
			ulong num = ReadCompressedUInt64(instream);
			networkId.Raw = (uint)num;
		}
		return networkId;
	}

	private static ulong ReadCompressedUInt64(StreamBuffer stream)
	{
		ulong num = 0uL;
		int num2 = 0;
		byte[] buffer = stream.GetBuffer();
		int num3 = stream.Position;
		while (num2 != 70)
		{
			if (num3 >= buffer.Length)
			{
				throw new EndOfStreamException("Failed to read full ulong.");
			}
			byte b = buffer[num3];
			num3++;
			num |= (ulong)((long)(b & 0x7F) << num2);
			num2 += 7;
			if ((b & 0x80) == 0)
			{
				break;
			}
		}
		stream.Position = num3;
		return num;
	}

	private static int WriteCompressedUInt64(StreamBuffer stream, ulong value)
	{
		int num = 0;
		lock (memCompressedUInt64)
		{
			memCompressedUInt64[num] = (byte)(value & 0x7F);
			for (value >>= 7; value != 0; value >>= 7)
			{
				memCompressedUInt64[num] |= 128;
				memCompressedUInt64[++num] = (byte)(value & 0x7F);
			}
			num++;
			stream.Write(memCompressedUInt64, 0, num);
			return num;
		}
	}

	private static short SerializeFusionNetworkId(StreamBuffer outstream, object customobject)
	{
		return (short)WriteCompressedUInt64(outstream, ((NetworkId)customobject).Raw);
	}

	void INetworkRunnerCallbacks.OnPlayerJoined(NetworkRunner runner, PlayerRef player)
	{
		if (base.Logger.IsDebugEnabled)
		{
			base.Logger.LogDebug("OnPlayerJoined {0}", player);
		}
		if (runner.LocalPlayer == player)
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("Local player joined, calling VoiceConnectOrJoinRoom");
			}
			VoiceConnectOrJoinRoom();
		}
	}

	void INetworkRunnerCallbacks.OnPlayerLeft(NetworkRunner runner, PlayerRef player)
	{
		if (base.Logger.IsDebugEnabled)
		{
			base.Logger.LogDebug("OnPlayerLeft {0}", player);
		}
		if (runner.LocalPlayer == player)
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("Local player left, calling VoiceDisconnect");
			}
			VoiceDisconnect();
		}
	}

	void INetworkRunnerCallbacks.OnInput(NetworkRunner runner, NetworkInput input)
	{
	}

	void INetworkRunnerCallbacks.OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
	{
	}

	void INetworkRunnerCallbacks.OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
	{
	}

	void INetworkRunnerCallbacks.OnConnectedToServer(NetworkRunner runner)
	{
		VoiceConnectOrJoinRoom();
	}

	void INetworkRunnerCallbacks.OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
	{
	}

	void INetworkRunnerCallbacks.OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
	{
	}

	void INetworkRunnerCallbacks.OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
	{
	}

	void INetworkRunnerCallbacks.OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
	{
	}

	void INetworkRunnerCallbacks.OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
	{
	}

	void INetworkRunnerCallbacks.OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
	{
	}

	void INetworkRunnerCallbacks.OnSceneLoadDone(NetworkRunner runner)
	{
	}

	void INetworkRunnerCallbacks.OnSceneLoadStart(NetworkRunner runner)
	{
	}

	public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
	{
	}

	public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
	{
	}

	public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
	{
		if (base.Logger.IsDebugEnabled)
		{
			base.Logger.LogDebug("OnDisconnectedFromServer, calling VoiceDisconnect");
		}
		VoiceDisconnect();
	}

	public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
	{
	}

	public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
	{
	}
}
[AddComponentMenu("Photon Voice/Fusion/Fusion Voice Client")]
[RequireComponent(typeof(NetworkRunner))]
public class FusionVoiceClient : MonoBehaviour, INetworkRunnerCallbacks, IPublicFacingInterface
{
	private NetworkRunner networkRunner;

	private EnterRoomParams voiceRoomParams = new EnterRoomParams
	{
		RoomOptions = new RoomOptions
		{
			IsVisible = false
		}
	};

	private bool voiceFollowClientStarted;

	[SerializeField]
	public bool UseFusionAppSettings = true;

	[SerializeField]
	public bool UseFusionAuthValues = true;

	private string fusionOfflineVoiceRoomName;

	private const byte FusionNetworkIdTypeCode = 0;

	private static byte[] memCompressedUInt64 = new byte[10];

	private string FusionOfflineVoiceRoomName
	{
		get
		{
			if (fusionOfflineVoiceRoomName == null)
			{
				fusionOfflineVoiceRoomName = $"fusion_offline_{Guid.NewGuid()}_voice";
			}
			return fusionOfflineVoiceRoomName;
		}
	}

	private static void VoiceRegisterCustomTypes()
	{
		PhotonPeer.RegisterType(typeof(NetworkId), 0, SerializeFusionNetworkId, DeserializeFusionNetworkId);
	}

	private static object DeserializeFusionNetworkId(StreamBuffer instream, short length)
	{
		NetworkId networkId = default(NetworkId);
		lock (memCompressedUInt64)
		{
			ulong num = ReadCompressedUInt64(instream);
			networkId.Raw = (uint)num;
		}
		return networkId;
	}

	private static ulong ReadCompressedUInt64(StreamBuffer stream)
	{
		ulong num = 0uL;
		int num2 = 0;
		byte[] buffer = stream.GetBuffer();
		int num3 = stream.Position;
		while (num2 != 70)
		{
			if (num3 >= buffer.Length)
			{
				throw new EndOfStreamException("Failed to read full ulong.");
			}
			byte b = buffer[num3];
			num3++;
			num |= (ulong)((long)(b & 0x7F) << num2);
			num2 += 7;
			if ((b & 0x80) == 0)
			{
				break;
			}
		}
		stream.Position = num3;
		return num;
	}

	private static int WriteCompressedUInt64(StreamBuffer stream, ulong value)
	{
		int num = 0;
		lock (memCompressedUInt64)
		{
			memCompressedUInt64[num] = (byte)(value & 0x7F);
			for (value >>= 7; value != 0; value >>= 7)
			{
				memCompressedUInt64[num] |= 128;
				memCompressedUInt64[++num] = (byte)(value & 0x7F);
			}
			num++;
			stream.Write(memCompressedUInt64, 0, num);
			return num;
		}
	}

	private static short SerializeFusionNetworkId(StreamBuffer outstream, object customobject)
	{
		return (short)WriteCompressedUInt64(outstream, ((NetworkId)customobject).Raw);
	}

	void INetworkRunnerCallbacks.OnPlayerJoined(NetworkRunner runner, PlayerRef player)
	{
	}

	void INetworkRunnerCallbacks.OnPlayerLeft(NetworkRunner runner, PlayerRef player)
	{
	}

	void INetworkRunnerCallbacks.OnInput(NetworkRunner runner, NetworkInput input)
	{
	}

	void INetworkRunnerCallbacks.OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
	{
	}

	void INetworkRunnerCallbacks.OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
	{
	}

	void INetworkRunnerCallbacks.OnConnectedToServer(NetworkRunner runner)
	{
	}

	void INetworkRunnerCallbacks.OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
	{
	}

	void INetworkRunnerCallbacks.OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
	{
	}

	void INetworkRunnerCallbacks.OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
	{
	}

	void INetworkRunnerCallbacks.OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
	{
	}

	void INetworkRunnerCallbacks.OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
	{
	}

	void INetworkRunnerCallbacks.OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
	{
	}

	void INetworkRunnerCallbacks.OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
	{
	}

	void INetworkRunnerCallbacks.OnSceneLoadDone(NetworkRunner runner)
	{
	}

	void INetworkRunnerCallbacks.OnSceneLoadStart(NetworkRunner runner)
	{
	}

	public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
	{
	}

	public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
	{
	}

	void INetworkRunnerCallbacks.OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey reliableKey, ArraySegment<byte> data)
	{
	}

	void INetworkRunnerCallbacks.OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey reliableKey, float progress)
	{
	}
}
[NetworkBehaviourWeaved(0)]
public class VoiceNetworkObject : NetworkBehaviour, ILoggableDependent, ILoggable
{
	private VoiceConnection voiceConnection;

	[SerializeField]
	private Speaker speakerInUse;

	[SerializeField]
	private Recorder recorderInUse;

	[SerializeField]
	protected DebugLevel logLevel = DebugLevel.ERROR;

	private VoiceLogger logger;

	[SerializeField]
	[HideInInspector]
	private bool ignoreGlobalLogLevel;

	public bool AutoCreateRecorderIfNotFound;

	public bool UsePrimaryRecorder;

	public bool SetupDebugSpeaker;

	public VoiceLogger Logger
	{
		get
		{
			if (logger == null)
			{
				logger = new VoiceLogger(this, $"{base.name}.{GetType().Name}", logLevel);
			}
			return logger;
		}
		protected set
		{
			logger = value;
		}
	}

	public DebugLevel LogLevel
	{
		get
		{
			if (Logger != null)
			{
				logLevel = Logger.LogLevel;
			}
			return logLevel;
		}
		set
		{
			logLevel = value;
			if (Logger != null)
			{
				Logger.LogLevel = logLevel;
			}
		}
	}

	public bool IgnoreGlobalLogLevel
	{
		get
		{
			return ignoreGlobalLogLevel;
		}
		set
		{
			ignoreGlobalLogLevel = value;
		}
	}

	public Recorder RecorderInUse
	{
		get
		{
			return recorderInUse;
		}
		set
		{
			if (value != recorderInUse)
			{
				recorderInUse = value;
				IsRecorder = false;
			}
			if (RequiresRecorder)
			{
				SetupRecorderInUse();
			}
			else if (IsNetworkObjectReady && Logger.IsWarningEnabled)
			{
				Logger.LogWarning("No need to set Recorder as this is a remote NetworkObject.");
			}
		}
	}

	public Speaker SpeakerInUse
	{
		get
		{
			return speakerInUse;
		}
		set
		{
			if (speakerInUse != value)
			{
				speakerInUse = value;
				IsSpeaker = false;
			}
			if (RequiresSpeaker)
			{
				SetupSpeakerInUse();
			}
			else if (IsNetworkObjectReady && Logger.IsWarningEnabled)
			{
				Logger.LogWarning("Speaker not set because this is a local NetworkObject and SetupDebugSpeaker is disabled.");
			}
		}
	}

	public bool IsSetup
	{
		get
		{
			if (IsNetworkObjectReady && (!RequiresRecorder || IsRecorder))
			{
				if (RequiresSpeaker)
				{
					return IsSpeaker;
				}
				return true;
			}
			return false;
		}
	}

	public bool IsSpeaker { get; private set; }

	public bool IsSpeaking => SpeakerInUse.IsPlaying;

	public bool IsRecorder { get; private set; }

	public bool IsRecording
	{
		get
		{
			if (IsRecorder)
			{
				return RecorderInUse.IsCurrentlyTransmitting;
			}
			return false;
		}
	}

	public bool IsSpeakerLinked
	{
		get
		{
			if (IsSpeaker)
			{
				return SpeakerInUse.IsLinked;
			}
			return false;
		}
	}

	internal bool IsNetworkObjectReady
	{
		get
		{
			if ((bool)base.Object && (object)base.Object != null && (bool)base.Object)
			{
				return base.Object.IsValid;
			}
			return false;
		}
	}

	internal bool RequiresSpeaker
	{
		get
		{
			if (IsNetworkObjectReady && IsPlayer)
			{
				if (!SetupDebugSpeaker)
				{
					return !IsLocal;
				}
				return true;
			}
			return false;
		}
	}

	internal bool RequiresRecorder
	{
		get
		{
			if (IsNetworkObjectReady && IsPlayer)
			{
				return IsLocal;
			}
			return false;
		}
	}

	internal bool IsPlayer => base.Runner.IsPlayer;

	internal bool IsLocal
	{
		get
		{
			if (!base.Object.HasInputAuthority)
			{
				return base.Object.HasStateAuthority;
			}
			return true;
		}
	}

	internal void Setup()
	{
		if (IsSetup)
		{
			if (Logger.IsDebugEnabled)
			{
				Logger.LogDebug("VoiceNetworkObject already setup");
			}
		}
		else
		{
			SetupRecorderInUse();
			SetupSpeakerInUse();
		}
	}

	private bool SetupRecorder()
	{
		if ((object)recorderInUse == null)
		{
			if (UsePrimaryRecorder)
			{
				if ((object)voiceConnection.PrimaryRecorder != null && (bool)voiceConnection.PrimaryRecorder)
				{
					recorderInUse = voiceConnection.PrimaryRecorder;
					return SetupRecorder(recorderInUse);
				}
				if (Logger.IsErrorEnabled)
				{
					Logger.LogError("PrimaryRecorder is not set.");
				}
			}
			Recorder[] componentsInChildren = GetComponentsInChildren<Recorder>();
			if (componentsInChildren.Length != 0)
			{
				Recorder recorder = componentsInChildren[0];
				if (componentsInChildren.Length > 1 && Logger.IsWarningEnabled)
				{
					Logger.LogWarning("Multiple Recorder components found attached to the GameObject or its children.");
				}
				if ((object)recorder != null && (bool)recorder)
				{
					recorderInUse = recorder;
					return SetupRecorder(recorderInUse);
				}
			}
			if (!AutoCreateRecorderIfNotFound)
			{
				if (Logger.IsWarningEnabled)
				{
					Logger.LogWarning("No Recorder found to be setup.");
				}
				return false;
			}
			recorderInUse = base.gameObject.AddComponent<Recorder>();
		}
		return SetupRecorder(recorderInUse);
	}

	private bool SetupRecorder(Recorder recorder)
	{
		if ((object)recorder == null)
		{
			if (Logger.IsWarningEnabled)
			{
				Logger.LogWarning("Cannot setup a null Recorder.");
			}
			return false;
		}
		if (!recorder)
		{
			if (Logger.IsWarningEnabled)
			{
				Logger.LogWarning("Cannot setup a destroyed Recorder.");
			}
			return false;
		}
		if (!IsNetworkObjectReady)
		{
			if (Logger.IsWarningEnabled)
			{
				Logger.LogWarning("Recorder setup cannot be done as the NetworkObject is not valid or not ready yet.");
			}
			return false;
		}
		recorder.UserData = GetUserData();
		if (!recorder.IsInitialized)
		{
			RecorderInUse.Init(voiceConnection);
		}
		if (recorder.RequiresRestart)
		{
			recorder.RestartRecording();
		}
		return recorder.IsInitialized;
	}

	private bool SetupSpeaker()
	{
		if ((object)speakerInUse == null)
		{
			Speaker[] componentsInChildren = GetComponentsInChildren<Speaker>(includeInactive: true);
			if (componentsInChildren.Length != 0)
			{
				speakerInUse = componentsInChildren[0];
				if (componentsInChildren.Length > 1 && Logger.IsWarningEnabled)
				{
					Logger.LogWarning("Multiple Speaker components found attached to the GameObject or its children. Using the first one we found.");
				}
			}
			if ((object)speakerInUse == null)
			{
				bool flag = false;
				if ((object)voiceConnection.SpeakerPrefab != null)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(voiceConnection.SpeakerPrefab, base.transform, worldPositionStays: false);
					componentsInChildren = gameObject.GetComponentsInChildren<Speaker>(includeInactive: true);
					if (componentsInChildren.Length != 0)
					{
						speakerInUse = componentsInChildren[0];
						if (componentsInChildren.Length > 1 && Logger.IsWarningEnabled)
						{
							Logger.LogWarning("Multiple Speaker components found attached to the GameObject (VoiceConnection.SpeakerPrefab) or its children. Using the first one we found.");
						}
					}
					if ((object)speakerInUse == null)
					{
						if (Logger.IsErrorEnabled)
						{
							Logger.LogError("SpeakerPrefab does not have a component of type Speaker in its hierarchy.");
						}
						UnityEngine.Object.Destroy(gameObject);
					}
					else
					{
						flag = true;
					}
				}
				if (!flag)
				{
					if (!voiceConnection.AutoCreateSpeakerIfNotFound)
					{
						return false;
					}
					speakerInUse = base.gameObject.AddComponent<Speaker>();
				}
			}
		}
		return SetupSpeaker(speakerInUse);
	}

	private bool SetupSpeaker(Speaker speaker)
	{
		if ((object)speakerInUse == null)
		{
			if (Logger.IsWarningEnabled)
			{
				Logger.LogWarning("Cannot setup a null Speaker");
			}
			return false;
		}
		if (!speakerInUse)
		{
			if (Logger.IsWarningEnabled)
			{
				Logger.LogWarning("Cannot setup a destroyed Speaker");
			}
			return false;
		}
		AudioSource component = speaker.GetComponent<AudioSource>();
		if ((object)component == null)
		{
			if (Logger.IsWarningEnabled)
			{
				Logger.LogWarning("Unexpected (null?): no AudioSource found attached to the same GameObject as the Speaker component");
			}
			return false;
		}
		if (!component)
		{
			if (Logger.IsWarningEnabled)
			{
				Logger.LogWarning("Unexpected (destroyed?): no AudioSource found attached to the same GameObject as the Speaker component");
			}
			return false;
		}
		if (component.mute && Logger.IsWarningEnabled)
		{
			Logger.LogWarning("audioSource.mute is true, playback may not work properly");
		}
		if (component.volume <= 0f && Logger.IsWarningEnabled)
		{
			Logger.LogWarning("audioSource.volume is zero, playback may not work properly");
		}
		if (!component.enabled && Logger.IsWarningEnabled)
		{
			Logger.LogWarning("audioSource.enabled is false, playback may not work properly");
		}
		return true;
	}

	internal void SetupRecorderInUse()
	{
		if (IsRecorder)
		{
			if (Logger.IsInfoEnabled)
			{
				Logger.LogInfo("Recorder already setup");
			}
			return;
		}
		if (!RequiresRecorder)
		{
			if (IsNetworkObjectReady && Logger.IsInfoEnabled)
			{
				Logger.LogInfo("Recorder not needed");
			}
			return;
		}
		IsRecorder = SetupRecorder();
		if (!IsRecorder)
		{
			if (Logger.IsWarningEnabled)
			{
				Logger.LogWarning("Recorder not setup for VoiceNetworkObject: playback may not work properly.");
			}
			return;
		}
		if (!RecorderInUse.IsRecording && !RecorderInUse.AutoStart && Logger.IsWarningEnabled)
		{
			Logger.LogWarning("VoiceNetworkObject.RecorderInUse.AutoStart is false, don't forget to start recording manually using recorder.StartRecording() or recorder.IsRecording = true.");
		}
		if (!RecorderInUse.TransmitEnabled && Logger.IsWarningEnabled)
		{
			Logger.LogWarning("VoiceNetworkObject.RecorderInUse.TransmitEnabled is false, don't forget to set it to true to enable transmission.");
		}
		if (!RecorderInUse.isActiveAndEnabled && RecorderInUse.RecordOnlyWhenEnabled && Logger.IsWarningEnabled)
		{
			Logger.LogWarning("VoiceNetworkObject.RecorderInUse may not work properly as RecordOnlyWhenEnabled is set to true and recorder is disabled or attached to an inactive GameObject.");
		}
	}

	internal void SetupSpeakerInUse()
	{
		if (IsSpeaker)
		{
			if (Logger.IsInfoEnabled)
			{
				Logger.LogInfo("Speaker already setup");
			}
			return;
		}
		if (!RequiresSpeaker)
		{
			if (IsNetworkObjectReady && Logger.IsInfoEnabled)
			{
				Logger.LogInfo("Speaker not needed");
			}
			return;
		}
		IsSpeaker = SetupSpeaker();
		if (!IsSpeaker)
		{
			if (Logger.IsWarningEnabled)
			{
				Logger.LogWarning("Speaker not setup for VoiceNetworkObject: voice chat will not work.");
			}
		}
		else
		{
			CheckLateLinking();
		}
	}

	private object GetUserData()
	{
		return base.Object.Id;
	}

	private void CheckLateLinking()
	{
		if (voiceConnection.Client.InRoom)
		{
			if (IsSpeaker)
			{
				if (!IsSpeakerLinked)
				{
					if (voiceConnection.TryLateLinkingUsingUserData(SpeakerInUse, GetUserData()))
					{
						if (Logger.IsDebugEnabled)
						{
							Logger.LogDebug("Late linking attempt succeeded.");
						}
					}
					else if (Logger.IsDebugEnabled)
					{
						Logger.LogDebug("Late linking attempt failed.");
					}
				}
				else if (Logger.IsDebugEnabled)
				{
					Logger.LogDebug("Speaker already linked");
				}
			}
			else if (Logger.IsDebugEnabled)
			{
				Logger.LogDebug("VoiceNetworkObject does not have a Speaker and may not need late linking check");
			}
		}
		else if (Logger.IsDebugEnabled)
		{
			Logger.LogDebug("Voice client is still not in a room, skipping late linking check");
		}
	}

	public override void Spawned()
	{
		voiceConnection = base.Runner.GetComponent<VoiceConnection>();
		Setup();
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
