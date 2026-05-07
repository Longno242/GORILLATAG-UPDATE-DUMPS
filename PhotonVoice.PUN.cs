using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;
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
			FilePathsData = new byte[205]
			{
				0, 0, 0, 1, 0, 0, 0, 57, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 104, 111, 116,
				111, 110, 92, 80, 104, 111, 116, 111, 110, 86,
				111, 105, 99, 101, 92, 67, 111, 100, 101, 92,
				80, 85, 78, 92, 80, 104, 111, 116, 111, 110,
				86, 111, 105, 99, 101, 78, 101, 116, 119, 111,
				114, 107, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 54, 92, 65, 115, 115, 101, 116, 115,
				92, 80, 104, 111, 116, 111, 110, 92, 80, 104,
				111, 116, 111, 110, 86, 111, 105, 99, 101, 92,
				67, 111, 100, 101, 92, 80, 85, 78, 92, 80,
				104, 111, 116, 111, 110, 86, 111, 105, 99, 101,
				86, 105, 101, 119, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 70, 92, 65, 115, 115, 101,
				116, 115, 92, 80, 104, 111, 116, 111, 110, 92,
				80, 104, 111, 116, 111, 110, 86, 111, 105, 99,
				101, 92, 67, 111, 100, 101, 92, 80, 85, 78,
				92, 85, 116, 105, 108, 105, 116, 121, 83, 99,
				114, 105, 112, 116, 115, 92, 86, 111, 105, 99,
				101, 68, 101, 98, 117, 103, 83, 99, 114, 105,
				112, 116, 46, 99, 115
			},
			TypesData = new byte[130]
			{
				0, 0, 0, 0, 35, 80, 104, 111, 116, 111,
				110, 46, 86, 111, 105, 99, 101, 46, 80, 85,
				78, 124, 80, 104, 111, 116, 111, 110, 86, 111,
				105, 99, 101, 78, 101, 116, 119, 111, 114, 107,
				0, 0, 0, 0, 32, 80, 104, 111, 116, 111,
				110, 46, 86, 111, 105, 99, 101, 46, 80, 85,
				78, 124, 80, 104, 111, 116, 111, 110, 86, 111,
				105, 99, 101, 86, 105, 101, 119, 0, 0, 0,
				0, 48, 80, 104, 111, 116, 111, 110, 46, 86,
				111, 105, 99, 101, 46, 80, 85, 78, 46, 85,
				116, 105, 108, 105, 116, 121, 83, 99, 114, 105,
				112, 116, 115, 124, 86, 111, 105, 99, 101, 68,
				101, 98, 117, 103, 83, 99, 114, 105, 112, 116
			},
			TotalFiles = 3,
			TotalTypes = 3,
			IsEditorOnly = false
		};
	}
}
namespace Photon.Voice.PUN
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Photon Voice/Photon Voice Network")]
	[HelpURL("https://doc.photonengine.com/en-us/voice/v2/getting-started/voice-for-pun")]
	public class PhotonVoiceNetwork : VoiceConnection
	{
		public const string VoiceRoomNameSuffix = "_voice_";

		public bool AutoConnectAndJoin = true;

		public bool AutoLeaveAndDisconnect = true;

		public bool WorkInOfflineMode = true;

		private EnterRoomParams voiceRoomParams = new EnterRoomParams
		{
			RoomOptions = new RoomOptions
			{
				IsVisible = false
			}
		};

		private bool clientCalledConnectAndJoin;

		private bool clientCalledDisconnect;

		private bool clientCalledConnectOnly;

		private bool internalDisconnect;

		private bool internalConnect;

		private static object instanceLock = new object();

		private static PhotonVoiceNetwork instance;

		private static bool instantiated;

		[SerializeField]
		private bool usePunAppSettings = true;

		[SerializeField]
		private bool usePunAuthValues = true;

		public static PhotonVoiceNetwork Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (ConnectionHandler.AppQuits)
					{
						if (instance.Logger.IsWarningEnabled)
						{
							instance.Logger.LogWarning("PhotonVoiceNetwork Instance already destroyed on application quit. Won't create again - returning null.");
						}
						return null;
					}
					if (!instantiated)
					{
						PhotonVoiceNetwork[] array = UnityEngine.Object.FindObjectsOfType<PhotonVoiceNetwork>();
						if (array == null || array.Length < 1)
						{
							instance = new GameObject
							{
								name = "PhotonVoiceNetwork singleton"
							}.AddComponent<PhotonVoiceNetwork>();
							if (instance.Logger.IsInfoEnabled)
							{
								instance.Logger.LogInfo("An instance of PhotonVoiceNetwork was automatically created in the scene.");
							}
						}
						else if (array.Length >= 1)
						{
							instance = array[0];
							if (array.Length > 1)
							{
								if (instance.Logger.IsErrorEnabled)
								{
									instance.Logger.LogError("{0} PhotonVoiceNetwork instances found. Using first one only and destroying all the other extra instances.", array.Length);
								}
								for (int i = 1; i < array.Length; i++)
								{
									UnityEngine.Object.Destroy(array[i]);
								}
							}
						}
						instantiated = true;
						if (instance.Logger.IsDebugEnabled)
						{
							instance.Logger.LogDebug("PhotonVoiceNetwork singleton instance is now set.");
						}
					}
					return instance;
				}
			}
			set
			{
				lock (instanceLock)
				{
					if ((object)value == null || !value)
					{
						if (instantiated)
						{
							if (instance.Logger.IsErrorEnabled)
							{
								instance.Logger.LogError("Cannot set PhotonVoiceNetwork.Instance to null or destroyed.");
							}
						}
						else
						{
							UnityEngine.Debug.LogError("Cannot set PhotonVoiceNetwork.Instance to null or destroyed.");
						}
					}
					else if (instantiated)
					{
						if (instance.GetInstanceID() != value.GetInstanceID())
						{
							if (instance.Logger.IsErrorEnabled)
							{
								instance.Logger.LogError("An instance of PhotonVoiceNetwork is already set. Destroying extra instance.");
							}
							UnityEngine.Object.Destroy(value);
						}
					}
					else
					{
						instance = value;
						instantiated = true;
						if (instance.Logger.IsDebugEnabled)
						{
							instance.Logger.LogDebug("PhotonVoiceNetwork singleton instance is now set.");
						}
					}
				}
			}
		}

		public bool UsePunAuthValues
		{
			get
			{
				return usePunAuthValues;
			}
			set
			{
				usePunAuthValues = value;
			}
		}

		public bool ConnectAndJoinRoom()
		{
			if (!PhotonNetwork.InRoom)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Cannot connect and join if PUN is not joined.");
				}
				return false;
			}
			if (Connect())
			{
				clientCalledConnectAndJoin = true;
				clientCalledDisconnect = false;
				return true;
			}
			if (base.Logger.IsErrorEnabled)
			{
				base.Logger.LogError("Connecting to server failed.");
			}
			return false;
		}

		public void Disconnect()
		{
			if (!base.Client.IsConnected)
			{
				if (base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Cannot Disconnect if not connected.");
				}
			}
			else
			{
				clientCalledDisconnect = true;
				clientCalledConnectAndJoin = false;
				clientCalledConnectOnly = false;
				base.Client.Disconnect();
			}
		}

		protected override void Awake()
		{
			Instance = this;
			lock (instanceLock)
			{
				if (instantiated && instance.GetInstanceID() == GetInstanceID())
				{
					base.Awake();
				}
			}
		}

		private void OnEnable()
		{
			PhotonNetwork.NetworkingClient.StateChanged += OnPunStateChanged;
			FollowPun();
			clientCalledConnectAndJoin = false;
			clientCalledConnectOnly = false;
			clientCalledDisconnect = false;
			internalDisconnect = false;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			PhotonNetwork.NetworkingClient.StateChanged -= OnPunStateChanged;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			lock (instanceLock)
			{
				if (instantiated && instance.GetInstanceID() == GetInstanceID())
				{
					instantiated = false;
					if (instance.Logger.IsDebugEnabled)
					{
						instance.Logger.LogDebug("PhotonVoiceNetwork singleton instance is being reset because destroyed.");
					}
					instance = null;
				}
			}
		}

		private void OnPunStateChanged(ClientState fromState, ClientState toState)
		{
			if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("OnPunStateChanged from {0} to {1}", fromState, toState);
			}
			FollowPun(toState);
		}

		protected override void OnVoiceStateChanged(ClientState fromState, ClientState toState)
		{
			base.OnVoiceStateChanged(fromState, toState);
			switch (toState)
			{
			case ClientState.Disconnected:
				if (internalDisconnect)
				{
					internalDisconnect = false;
				}
				else if (!clientCalledDisconnect)
				{
					clientCalledDisconnect = base.Client.DisconnectedCause == DisconnectCause.DisconnectByClientLogic;
				}
				if ((object)base.PrimaryRecorder != null && (bool)base.PrimaryRecorder)
				{
					base.PrimaryRecorder.UserData = -1;
				}
				break;
			case ClientState.ConnectedToMasterServer:
				if (internalConnect)
				{
					internalConnect = false;
				}
				else if (!clientCalledConnectOnly && !clientCalledConnectAndJoin)
				{
					clientCalledConnectOnly = true;
					clientCalledDisconnect = false;
				}
				break;
			}
			FollowPun(toState);
		}

		private void FollowPun(ClientState toState)
		{
			if (toState == ClientState.Joined || (uint)(toState - 14) <= 1u)
			{
				FollowPun();
			}
		}

		protected override Speaker SimpleSpeakerFactory(int playerId, byte voiceId, object userData)
		{
			if (!(userData is int))
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("UserData ({0}) does not contain PhotonViewId. Remote voice {1}/{2} not linked. Do you have a Recorder not used with a PhotonVoiceView? is this expected?", (userData == null) ? "null" : userData.ToString(), playerId, voiceId);
				}
				return null;
			}
			PhotonView photonView = PhotonView.Find((int)userData);
			if ((object)photonView == null || !photonView)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("No PhotonView with ID {0} found. Remote voice {1}/{2} not linked.", userData, playerId, voiceId);
				}
				return null;
			}
			PhotonVoiceView component = photonView.GetComponent<PhotonVoiceView>();
			if ((object)component == null || !component)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("No PhotonVoiceView attached to the PhotonView with ID {0}. Remote voice {1}/{2} not linked.", userData, playerId, voiceId);
				}
				return null;
			}
			if (!component.IgnoreGlobalLogLevel)
			{
				component.LogLevel = base.LogLevel;
			}
			if (!component.IsSpeaker)
			{
				component.SetupSpeakerInUse();
			}
			return component.SpeakerInUse;
		}

		internal static string GetVoiceRoomName()
		{
			if (PhotonNetwork.InRoom)
			{
				return string.Format("{0}{1}", PhotonNetwork.CurrentRoom.Name, "_voice_");
			}
			return null;
		}

		private void ConnectOrJoin()
		{
			switch (base.ClientState)
			{
			case ClientState.PeerCreated:
			case ClientState.Disconnected:
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("PUN joined room, now connecting Voice client");
				}
				if (!Connect())
				{
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("Connecting to server failed.");
					}
				}
				else
				{
					internalConnect = AutoConnectAndJoin && !clientCalledConnectOnly && !clientCalledConnectAndJoin;
				}
				break;
			case ClientState.ConnectedToMasterServer:
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("PUN joined room, now joining Voice room");
				}
				if (!JoinRoom(GetVoiceRoomName()) && base.Logger.IsErrorEnabled)
				{
					base.Logger.LogError("Joining a voice room failed.");
				}
				break;
			default:
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("PUN joined room, Voice client is busy ({0}). Is this expected?", base.ClientState);
				}
				break;
			}
		}

		private bool Connect()
		{
			AppSettings appSettings = null;
			if (usePunAppSettings)
			{
				appSettings = new AppSettings();
				appSettings = PhotonNetwork.PhotonServerSettings.AppSettings.CopyTo(appSettings);
				if (!string.IsNullOrEmpty(PhotonNetwork.CloudRegion))
				{
					appSettings.FixedRegion = PhotonNetwork.CloudRegion;
				}
				base.Client.SerializationProtocol = PhotonNetwork.NetworkingClient.SerializationProtocol;
			}
			if (UsePunAuthValues)
			{
				if (PhotonNetwork.AuthValues != null)
				{
					if (base.Client.AuthValues == null)
					{
						base.Client.AuthValues = new AuthenticationValues();
					}
					base.Client.AuthValues = PhotonNetwork.AuthValues.CopyTo(base.Client.AuthValues);
				}
				base.Client.AuthMode = PhotonNetwork.NetworkingClient.AuthMode;
				base.Client.EncryptionMode = PhotonNetwork.NetworkingClient.EncryptionMode;
			}
			return ConnectUsingSettings(appSettings);
		}

		private bool JoinRoom(string voiceRoomName)
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
			return base.Client.OpJoinOrCreateRoom(voiceRoomParams);
		}

		private void FollowPun()
		{
			if (ConnectionHandler.AppQuits || (PhotonNetwork.OfflineMode && !WorkInOfflineMode))
			{
				return;
			}
			if (PhotonNetwork.NetworkClientState == base.ClientState)
			{
				if (PhotonNetwork.InRoom && AutoConnectAndJoin)
				{
					string voiceRoomName = GetVoiceRoomName();
					string text = base.Client.CurrentRoom.Name;
					if (!text.Equals(voiceRoomName))
					{
						if (base.Logger.IsWarningEnabled)
						{
							base.Logger.LogWarning("Voice room mismatch: Expected:\"{0}\" Current:\"{1}\", leaving the second to join the first.", voiceRoomName, text);
						}
						if (!base.Client.OpLeaveRoom(becomeInactive: false) && base.Logger.IsErrorEnabled)
						{
							base.Logger.LogError("Leaving the current voice room failed.");
						}
					}
				}
				else if (base.ClientState == ClientState.ConnectedToMasterServer && AutoLeaveAndDisconnect && !clientCalledConnectAndJoin && !clientCalledConnectOnly)
				{
					if (base.Logger.IsWarningEnabled)
					{
						base.Logger.LogWarning("Unexpected: PUN and Voice clients have the same client state: ConnectedToMasterServer, Disconnecting Voice client.");
					}
					internalDisconnect = true;
					base.Client.Disconnect();
				}
			}
			else if (PhotonNetwork.InRoom)
			{
				if (clientCalledConnectAndJoin || (AutoConnectAndJoin && !clientCalledDisconnect))
				{
					ConnectOrJoin();
				}
			}
			else if (base.Client.InRoom && AutoLeaveAndDisconnect && !clientCalledConnectAndJoin && !clientCalledConnectOnly)
			{
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("PUN left room, disconnecting Voice");
				}
				internalDisconnect = true;
				base.Client.Disconnect();
			}
		}

		internal void CheckLateLinking(Speaker speaker, int viewId)
		{
			if ((object)speaker == null || !speaker)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Cannot check late linking for null Speaker");
				}
				return;
			}
			if (viewId <= 0)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Cannot check late linking for ViewID = {0} (<= 0)", viewId);
				}
				return;
			}
			if (!base.Client.InRoom)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Cannot check late linking while not joined to a voice room, client state: {0}", Enum.GetName(typeof(ClientState), base.ClientState));
				}
				return;
			}
			for (int i = 0; i < cachedRemoteVoices.Count; i++)
			{
				RemoteVoiceLink remoteVoiceLink = cachedRemoteVoices[i];
				if (remoteVoiceLink.Info.UserData is int)
				{
					int num = (int)remoteVoiceLink.Info.UserData;
					if (viewId == num)
					{
						if (base.Logger.IsInfoEnabled)
						{
							base.Logger.LogInfo("Speaker 'late-linking' for the PhotonView with ID {0} with remote voice {1}/{2}.", viewId, remoteVoiceLink.PlayerId, remoteVoiceLink.VoiceId);
						}
						LinkSpeaker(speaker, remoteVoiceLink);
						break;
					}
				}
				else if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("VoiceInfo.UserData should be int/ViewId, received: {0}, do you have a Recorder not used with a PhotonVoiceView? is this expected?", (remoteVoiceLink.Info.UserData == null) ? "null" : $"{remoteVoiceLink.Info.UserData} ({remoteVoiceLink.Info.UserData.GetType()})");
					if (remoteVoiceLink.PlayerId == viewId / PhotonNetwork.MAX_VIEW_IDS)
					{
						base.Logger.LogWarning("Player with ActorNumber {0} has started recording (voice # {1}) too early without setting a ViewId maybe? (before PhotonVoiceView setup)", remoteVoiceLink.PlayerId, remoteVoiceLink.VoiceId);
					}
				}
			}
		}
	}
	[AddComponentMenu("Photon Voice/Photon Voice View")]
	[RequireComponent(typeof(PhotonView))]
	[HelpURL("https://doc.photonengine.com/en-us/voice/v2/getting-started/voice-for-pun")]
	public class PhotonVoiceView : VoiceComponent
	{
		private PhotonView photonView;

		[SerializeField]
		private Recorder recorderInUse;

		[SerializeField]
		private Speaker speakerInUse;

		private bool onEnableCalledOnce;

		public bool AutoCreateRecorderIfNotFound;

		public bool UsePrimaryRecorder;

		public bool SetupDebugSpeaker;

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
				else if (IsPhotonViewReady && base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("No need to set Recorder as the PhotonView does not belong to local player");
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
				else if (IsPhotonViewReady && base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Speaker not set because the PhotonView does not belong to a remote player or SetupDebugSpeaker is disabled");
				}
			}
		}

		public bool IsSetup
		{
			get
			{
				if (IsPhotonViewReady && (!RequiresRecorder || IsRecorder))
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

		public bool IsSpeaking
		{
			get
			{
				if (IsSpeaker)
				{
					return SpeakerInUse.IsPlaying;
				}
				return false;
			}
		}

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

		public bool IsPhotonViewReady
		{
			get
			{
				if ((object)photonView != null && (bool)photonView)
				{
					return photonView.ViewID > 0;
				}
				return false;
			}
		}

		internal bool RequiresSpeaker
		{
			get
			{
				if (!SetupDebugSpeaker)
				{
					if (IsPhotonViewReady)
					{
						return !photonView.IsMine;
					}
					return false;
				}
				return true;
			}
		}

		internal bool RequiresRecorder
		{
			get
			{
				if (IsPhotonViewReady)
				{
					return photonView.IsMine;
				}
				return false;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			photonView = GetComponent<PhotonView>();
			Init();
		}

		private void OnEnable()
		{
			if (onEnableCalledOnce)
			{
				Init();
			}
			else
			{
				onEnableCalledOnce = true;
			}
		}

		private void Start()
		{
			Init();
		}

		private void CheckLateLinking()
		{
			if (PhotonVoiceNetwork.Instance.Client.InRoom)
			{
				if (IsSpeaker)
				{
					if (!IsSpeakerLinked)
					{
						PhotonVoiceNetwork.Instance.CheckLateLinking(SpeakerInUse, photonView.ViewID);
					}
					else if (base.Logger.IsDebugEnabled)
					{
						base.Logger.LogDebug("Speaker already linked");
					}
				}
				else if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("PhotonVoiceView does not have a Speaker and may not need late linking check");
				}
			}
			else if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("Voice client is still not in a room, skipping late linking check");
			}
		}

		internal void Setup()
		{
			if (IsSetup)
			{
				if (base.Logger.IsDebugEnabled)
				{
					base.Logger.LogDebug("PhotonVoiceView already setup");
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
					if ((object)PhotonVoiceNetwork.Instance.PrimaryRecorder != null && (bool)PhotonVoiceNetwork.Instance.PrimaryRecorder)
					{
						recorderInUse = PhotonVoiceNetwork.Instance.PrimaryRecorder;
						return SetupRecorder(recorderInUse);
					}
					if (base.Logger.IsErrorEnabled)
					{
						base.Logger.LogError("PrimaryRecorder is not set.");
					}
				}
				Recorder[] componentsInChildren = GetComponentsInChildren<Recorder>();
				if (componentsInChildren.Length != 0)
				{
					Recorder recorder = componentsInChildren[0];
					if (componentsInChildren.Length > 1 && base.Logger.IsWarningEnabled)
					{
						base.Logger.LogWarning("Multiple Recorder components found attached to the GameObject or its children.");
					}
					if ((object)recorder != null && (bool)recorder)
					{
						recorderInUse = recorder;
						return SetupRecorder(recorderInUse);
					}
				}
				if (!AutoCreateRecorderIfNotFound)
				{
					if (base.Logger.IsWarningEnabled)
					{
						base.Logger.LogWarning("No Recorder found to be setup.");
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
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Cannot setup a null Recorder.");
				}
				return false;
			}
			if (!recorder)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Cannot setup a destroyed Recorder.");
				}
				return false;
			}
			if (!IsPhotonViewReady)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Recorder setup cannot be done before assigning a valid ViewID to the PhotonView attached to the same GameObject as the PhotonVoiceView.");
				}
				return false;
			}
			recorder.UserData = photonView.ViewID;
			if (!recorder.IsInitialized)
			{
				RecorderInUse.Init(PhotonVoiceNetwork.Instance);
			}
			if (recorder.RequiresRestart)
			{
				recorder.RestartRecording();
			}
			if (recorder.IsInitialized && recorder.UserData is int)
			{
				return photonView.ViewID == (int)recorder.UserData;
			}
			return false;
		}

		private bool SetupSpeaker()
		{
			if ((object)speakerInUse == null)
			{
				Speaker[] componentsInChildren = GetComponentsInChildren<Speaker>(includeInactive: true);
				if (componentsInChildren.Length != 0)
				{
					speakerInUse = componentsInChildren[0];
					if (componentsInChildren.Length > 1 && base.Logger.IsWarningEnabled)
					{
						base.Logger.LogWarning("Multiple Speaker components found attached to the GameObject or its children. Using the first one we found.");
					}
				}
				if ((object)speakerInUse == null)
				{
					bool flag = false;
					if ((object)PhotonVoiceNetwork.Instance.SpeakerPrefab != null)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate(PhotonVoiceNetwork.Instance.SpeakerPrefab, base.transform, worldPositionStays: false);
						componentsInChildren = gameObject.GetComponentsInChildren<Speaker>(includeInactive: true);
						if (componentsInChildren.Length != 0)
						{
							speakerInUse = componentsInChildren[0];
							if (componentsInChildren.Length > 1 && base.Logger.IsWarningEnabled)
							{
								base.Logger.LogWarning("Multiple Speaker components found attached to the GameObject (PhotonVoiceNetwork.SpeakerPrefab) or its children. Using the first one we found.");
							}
						}
						if ((object)speakerInUse == null)
						{
							if (base.Logger.IsErrorEnabled)
							{
								base.Logger.LogError("SpeakerPrefab does not have a component of type Speaker in its hierarchy.");
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
						if (!PhotonVoiceNetwork.Instance.AutoCreateSpeakerIfNotFound)
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
			if ((object)speaker == null)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Cannot setup a null Speaker");
				}
				return false;
			}
			if (!speaker)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Cannot setup a destroyed Speaker");
				}
				return false;
			}
			AudioSource component = speaker.GetComponent<AudioSource>();
			if ((object)component == null)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Unexpected (null?): no AudioSource found attached to the same GameObject as the Speaker component");
				}
				return false;
			}
			if (!component)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Unexpected (destroyed?): no AudioSource found attached to the same GameObject as the Speaker component");
				}
				return false;
			}
			if (component.mute && base.Logger.IsWarningEnabled)
			{
				base.Logger.LogWarning("audioSource.mute is true, playback may not work properly");
			}
			if (component.volume <= 0f && base.Logger.IsWarningEnabled)
			{
				base.Logger.LogWarning("audioSource.volume is zero, playback may not work properly");
			}
			if (!component.enabled && base.Logger.IsWarningEnabled)
			{
				base.Logger.LogWarning("audioSource.enabled is false, playback may not work properly");
			}
			return true;
		}

		internal void SetupRecorderInUse()
		{
			if (IsRecorder)
			{
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Recorder already setup");
				}
				return;
			}
			if (!RequiresRecorder)
			{
				if (IsPhotonViewReady && base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Recorder not needed");
				}
				return;
			}
			IsRecorder = SetupRecorder();
			if (!IsRecorder)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Recorder not setup for PhotonVoiceView: playback may not work properly.");
				}
				return;
			}
			if (!RecorderInUse.IsRecording && !RecorderInUse.AutoStart && base.Logger.IsWarningEnabled)
			{
				base.Logger.LogWarning("PhotonVoiceView.RecorderInUse.AutoStart is false, don't forget to start recording manually using recorder.StartRecording() or recorder.IsRecording = true.");
			}
			if (!RecorderInUse.TransmitEnabled && base.Logger.IsWarningEnabled)
			{
				base.Logger.LogWarning("PhotonVoiceView.RecorderInUse.TransmitEnabled is false, don't forget to set it to true to enable transmission.");
			}
			if (!RecorderInUse.isActiveAndEnabled && RecorderInUse.RecordOnlyWhenEnabled && base.Logger.IsWarningEnabled)
			{
				base.Logger.LogWarning("PhotonVoiceView.RecorderInUse may not work properly as RecordOnlyWhenEnabled is set to true and recorder is disabled or attached to an inactive GameObject.");
			}
		}

		internal void SetupSpeakerInUse()
		{
			if (IsSpeaker)
			{
				if (base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Speaker already setup");
				}
				return;
			}
			if (!RequiresSpeaker)
			{
				if (IsPhotonViewReady && base.Logger.IsInfoEnabled)
				{
					base.Logger.LogInfo("Speaker not needed");
				}
				return;
			}
			IsSpeaker = SetupSpeaker();
			if (!IsSpeaker)
			{
				if (base.Logger.IsWarningEnabled)
				{
					base.Logger.LogWarning("Speaker not setup for PhotonVoiceView: voice chat will not work.");
				}
			}
			else
			{
				CheckLateLinking();
			}
		}

		public void Init()
		{
			if (IsPhotonViewReady)
			{
				Setup();
				CheckLateLinking();
			}
			else if (base.Logger.IsDebugEnabled)
			{
				base.Logger.LogDebug("Tried to initialize PhotonVoiceView but PhotonView does not have a valid allocated ViewID yet.");
			}
		}
	}
}
namespace Photon.Voice.PUN.UtilityScripts
{
	[RequireComponent(typeof(PhotonVoiceView))]
	public class VoiceDebugScript : MonoBehaviourPun
	{
		private PhotonVoiceView photonVoiceView;

		public bool ForceRecordingAndTransmission;

		public AudioClip TestAudioClip;

		public bool TestUsingAudioClip;

		public bool DisableVad;

		public bool IncreaseLogLevels;

		public bool LocalDebug;

		private void Awake()
		{
			photonVoiceView = GetComponent<PhotonVoiceView>();
		}

		private void Update()
		{
			MaxLogs();
			if (!photonVoiceView.IsRecorder)
			{
				return;
			}
			if (TestUsingAudioClip)
			{
				if ((object)TestAudioClip == null || !TestAudioClip)
				{
					UnityEngine.Debug.LogError("Set an AudioClip first");
				}
				else
				{
					photonVoiceView.RecorderInUse.SourceType = Recorder.InputSourceType.AudioClip;
					photonVoiceView.RecorderInUse.AudioClip = TestAudioClip;
					photonVoiceView.RecorderInUse.LoopAudioClip = true;
					if (photonVoiceView.RecorderInUse.RequiresRestart)
					{
						photonVoiceView.RecorderInUse.RestartRecording();
					}
					else
					{
						photonVoiceView.RecorderInUse.StartRecording();
					}
					photonVoiceView.RecorderInUse.TransmitEnabled = true;
				}
			}
			if (ForceRecordingAndTransmission)
			{
				photonVoiceView.RecorderInUse.IsRecording = true;
				photonVoiceView.RecorderInUse.TransmitEnabled = true;
			}
			if (DisableVad)
			{
				photonVoiceView.RecorderInUse.VoiceDetection = false;
			}
		}

		[ContextMenu("CantHearYou")]
		public void CantHearYou()
		{
			if (!PhotonVoiceNetwork.Instance.Client.InRoom)
			{
				UnityEngine.Debug.LogError("local voice client is not joined to a voice room");
			}
			else if (!photonVoiceView.IsPhotonViewReady)
			{
				UnityEngine.Debug.LogError("PhotonView is not ready yet; maybe PUN client is not joined to a room yet or this PhotonView is not valid");
			}
			else if (!photonVoiceView.IsSpeaker)
			{
				if (base.photonView.IsMine && !photonVoiceView.SetupDebugSpeaker)
				{
					UnityEngine.Debug.LogError("local object does not have SetupDebugSpeaker enabled");
					if (LocalDebug)
					{
						UnityEngine.Debug.Log("setup debug speaker not enabled, enabling it now (1)");
						photonVoiceView.SetupDebugSpeaker = true;
						photonVoiceView.Setup();
					}
				}
				else
				{
					UnityEngine.Debug.LogError("locally not speaker (yet?) (1)");
					photonVoiceView.Setup();
				}
			}
			else
			{
				if (!photonVoiceView.IsSpeakerLinked)
				{
					UnityEngine.Debug.LogError("locally speaker not linked, trying late linking & asking anyway");
					PhotonVoiceNetwork.Instance.CheckLateLinking(photonVoiceView.SpeakerInUse, base.photonView.ViewID);
				}
				base.photonView.RPC("CantHearYou", base.photonView.Owner, PhotonVoiceNetwork.Instance.Client.CurrentRoom.Name, PhotonVoiceNetwork.Instance.Client.LoadBalancingPeer.ServerIpAddress, PhotonVoiceNetwork.Instance.Client.AppVersion);
			}
		}

		[PunRPC]
		private void CantHearYou(string roomName, string serverIp, string appVersion, PhotonMessageInfo photonMessageInfo)
		{
			string why;
			if (!PhotonVoiceNetwork.Instance.Client.InRoom)
			{
				why = "voice client not in a room";
			}
			else if (!PhotonVoiceNetwork.Instance.Client.CurrentRoom.Name.Equals(roomName))
			{
				why = $"voice client is on another room {PhotonVoiceNetwork.Instance.Client.CurrentRoom.Name} != {roomName}";
			}
			else if (!PhotonVoiceNetwork.Instance.Client.LoadBalancingPeer.ServerIpAddress.Equals(serverIp))
			{
				why = $"voice client is on another server {PhotonVoiceNetwork.Instance.Client.LoadBalancingPeer.ServerIpAddress} != {serverIp}, maybe different Photon Cloud regions";
			}
			else if (!PhotonVoiceNetwork.Instance.Client.AppVersion.Equals(appVersion))
			{
				why = $"voice client uses different AppVersion {PhotonVoiceNetwork.Instance.Client.AppVersion} != {appVersion}";
			}
			else if (!photonVoiceView.IsRecorder)
			{
				why = "recorder not setup (yet?)";
				photonVoiceView.Setup();
			}
			else if (!photonVoiceView.RecorderInUse.IsRecording)
			{
				why = "recorder is not recording";
				photonVoiceView.RecorderInUse.IsRecording = true;
			}
			else if (!photonVoiceView.RecorderInUse.TransmitEnabled)
			{
				why = "recorder is not transmitting";
				photonVoiceView.RecorderInUse.TransmitEnabled = true;
			}
			else if (photonVoiceView.RecorderInUse.InterestGroup != 0)
			{
				why = "recorder.InterestGroup is not zero? is this on purpose? switching it back to zero";
				photonVoiceView.RecorderInUse.InterestGroup = 0;
			}
			else if (!(photonVoiceView.RecorderInUse.UserData is int) || (int)photonVoiceView.RecorderInUse.UserData != base.photonView.ViewID)
			{
				why = $"recorder.UserData ({photonVoiceView.RecorderInUse.UserData}) != photonView.ViewID ({base.photonView.ViewID}), fixing it now";
				photonVoiceView.RecorderInUse.UserData = base.photonView.ViewID;
				photonVoiceView.RecorderInUse.RestartRecording();
			}
			else if (photonVoiceView.RecorderInUse.VoiceDetection && DisableVad)
			{
				why = "recorder vad is enabled, disable it for testing";
				photonVoiceView.RecorderInUse.VoiceDetection = false;
			}
			else if (base.photonView.OwnerActorNr == photonMessageInfo.Sender.ActorNumber)
			{
				if (LocalDebug)
				{
					if (photonVoiceView.IsSpeaker)
					{
						why = "no idea why!, should be working (1)";
						photonVoiceView.RecorderInUse.RestartRecording(force: true);
					}
					else if (!photonVoiceView.SetupDebugSpeaker)
					{
						why = "setup debug speaker not enabled, enabling it now (2)";
						photonVoiceView.SetupDebugSpeaker = true;
						photonVoiceView.Setup();
					}
					else if (!photonVoiceView.RecorderInUse.DebugEchoMode)
					{
						why = "recorder debug echo mode not enabled, enabling it now";
						photonVoiceView.RecorderInUse.DebugEchoMode = true;
					}
					else
					{
						why = "locally not speaker (yet?) (2)";
						photonVoiceView.Setup();
					}
				}
				else
				{
					why = "local object, are you trying to hear yourself? (feedback DebugEcho), LocalDebug is disabled, enable it if you want to diagnose this";
				}
			}
			else
			{
				why = "no idea why!, should be working (2)";
				photonVoiceView.RecorderInUse.RestartRecording(force: true);
			}
			Reply(why, photonMessageInfo.Sender);
		}

		private void Reply(string why, Player player)
		{
			base.photonView.RPC("HeresWhy", player, why);
		}

		[PunRPC]
		private void HeresWhy(string why, PhotonMessageInfo photonMessageInfo)
		{
			UnityEngine.Debug.LogErrorFormat("Player {0} replied to my CantHearYou message with {1}", photonMessageInfo.Sender, why);
		}

		private void MaxLogs()
		{
			if (IncreaseLogLevels)
			{
				photonVoiceView.LogLevel = DebugLevel.ALL;
				PhotonVoiceNetwork.Instance.LogLevel = DebugLevel.ALL;
				PhotonVoiceNetwork.Instance.GlobalRecordersLogLevel = DebugLevel.ALL;
				PhotonVoiceNetwork.Instance.GlobalSpeakersLogLevel = DebugLevel.ALL;
				if (photonVoiceView.IsRecorder)
				{
					photonVoiceView.RecorderInUse.LogLevel = DebugLevel.ALL;
				}
				if (photonVoiceView.IsSpeaker)
				{
					photonVoiceView.SpeakerInUse.LogLevel = DebugLevel.ALL;
				}
			}
		}
	}
}
