using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;
using UnityEngine.SpatialTracking;
using UnityEngine.XR;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("UnityEditor.XR.LegacyInputHelpers")]
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
			FilePathsData = new byte[425]
			{
				0, 0, 0, 1, 0, 0, 0, 96, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				120, 114, 46, 108, 101, 103, 97, 99, 121, 105,
				110, 112, 117, 116, 104, 101, 108, 112, 101, 114,
				115, 64, 98, 55, 53, 55, 57, 101, 56, 54,
				102, 51, 98, 52, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 65, 114, 109, 77, 111, 100, 101,
				108, 115, 92, 65, 114, 109, 77, 111, 100, 101,
				108, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 101, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 117, 110,
				105, 116, 121, 46, 120, 114, 46, 108, 101, 103,
				97, 99, 121, 105, 110, 112, 117, 116, 104, 101,
				108, 112, 101, 114, 115, 64, 98, 55, 53, 55,
				57, 101, 56, 54, 102, 51, 98, 52, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 65, 114, 109,
				77, 111, 100, 101, 108, 115, 92, 83, 119, 105,
				110, 103, 65, 114, 109, 77, 111, 100, 101, 108,
				46, 99, 115, 0, 0, 0, 3, 0, 0, 0,
				106, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 117, 110, 105,
				116, 121, 46, 120, 114, 46, 108, 101, 103, 97,
				99, 121, 105, 110, 112, 117, 116, 104, 101, 108,
				112, 101, 114, 115, 64, 98, 55, 53, 55, 57,
				101, 56, 54, 102, 51, 98, 52, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 65, 114, 109, 77,
				111, 100, 101, 108, 115, 92, 84, 114, 97, 110,
				115, 105, 116, 105, 111, 110, 65, 114, 109, 77,
				111, 100, 101, 108, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 90, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 117, 110, 105, 116, 121, 46, 120, 114, 46,
				108, 101, 103, 97, 99, 121, 105, 110, 112, 117,
				116, 104, 101, 108, 112, 101, 114, 115, 64, 98,
				55, 53, 55, 57, 101, 56, 54, 102, 51, 98,
				52, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				67, 97, 109, 101, 114, 97, 79, 102, 102, 115,
				101, 116, 46, 99, 115
			},
			TypesData = new byte[339]
			{
				0, 0, 0, 0, 42, 85, 110, 105, 116, 121,
				69, 110, 103, 105, 110, 101, 46, 88, 82, 46,
				76, 101, 103, 97, 99, 121, 73, 110, 112, 117,
				116, 72, 101, 108, 112, 101, 114, 115, 124, 65,
				114, 109, 77, 111, 100, 101, 108, 0, 0, 0,
				0, 47, 85, 110, 105, 116, 121, 69, 110, 103,
				105, 110, 101, 46, 88, 82, 46, 76, 101, 103,
				97, 99, 121, 73, 110, 112, 117, 116, 72, 101,
				108, 112, 101, 114, 115, 124, 83, 119, 105, 110,
				103, 65, 114, 109, 77, 111, 100, 101, 108, 0,
				0, 0, 0, 52, 85, 110, 105, 116, 121, 69,
				110, 103, 105, 110, 101, 46, 88, 82, 46, 76,
				101, 103, 97, 99, 121, 73, 110, 112, 117, 116,
				72, 101, 108, 112, 101, 114, 115, 124, 65, 114,
				109, 77, 111, 100, 101, 108, 84, 114, 97, 110,
				115, 105, 116, 105, 111, 110, 0, 0, 0, 0,
				52, 85, 110, 105, 116, 121, 69, 110, 103, 105,
				110, 101, 46, 88, 82, 46, 76, 101, 103, 97,
				99, 121, 73, 110, 112, 117, 116, 72, 101, 108,
				112, 101, 114, 115, 124, 84, 114, 97, 110, 115,
				105, 116, 105, 111, 110, 65, 114, 109, 77, 111,
				100, 101, 108, 0, 0, 0, 0, 70, 85, 110,
				105, 116, 121, 69, 110, 103, 105, 110, 101, 46,
				88, 82, 46, 76, 101, 103, 97, 99, 121, 73,
				110, 112, 117, 116, 72, 101, 108, 112, 101, 114,
				115, 46, 84, 114, 97, 110, 115, 105, 116, 105,
				111, 110, 65, 114, 109, 77, 111, 100, 101, 108,
				124, 65, 114, 109, 77, 111, 100, 101, 108, 66,
				108, 101, 110, 100, 68, 97, 116, 97, 0, 0,
				0, 0, 46, 85, 110, 105, 116, 121, 69, 100,
				105, 116, 111, 114, 46, 88, 82, 46, 76, 101,
				103, 97, 99, 121, 73, 110, 112, 117, 116, 72,
				101, 108, 112, 101, 114, 115, 124, 67, 97, 109,
				101, 114, 97, 79, 102, 102, 115, 101, 116
			},
			TotalFiles = 4,
			TotalTypes = 6,
			IsEditorOnly = false
		};
	}
}
namespace UnityEditor.XR.LegacyInputHelpers
{
	public enum UserRequestedTrackingMode
	{
		Default,
		Device,
		Floor
	}
	[AddComponentMenu("XR/Camera Offset")]
	public class CameraOffset : MonoBehaviour
	{
		private const float k_DefaultCameraYOffset = 1.36144f;

		[SerializeField]
		[Tooltip("GameObject to move to desired height off the floor (defaults to this object if none provided).")]
		private GameObject m_CameraFloorOffsetObject;

		[SerializeField]
		[Tooltip("What the user wants the tracking origin mode to be")]
		private UserRequestedTrackingMode m_RequestedTrackingMode;

		[SerializeField]
		[Tooltip("Sets the type of tracking origin to use for this Rig. Tracking origins identify where 0,0,0 is in the world of tracking.")]
		private TrackingOriginModeFlags m_TrackingOriginMode;

		[SerializeField]
		[Tooltip("Set if the XR experience is Room Scale or Stationary.")]
		private TrackingSpaceType m_TrackingSpace;

		[SerializeField]
		[Tooltip("Camera Height to be used when in Device tracking space.")]
		private float m_CameraYOffset = 1.36144f;

		private bool m_CameraInitialized;

		private bool m_CameraInitializing;

		private static List<XRInputSubsystem> s_InputSubsystems = new List<XRInputSubsystem>();

		public GameObject cameraFloorOffsetObject
		{
			get
			{
				return m_CameraFloorOffsetObject;
			}
			set
			{
				m_CameraFloorOffsetObject = value;
				UpdateTrackingOrigin(m_TrackingOriginMode);
			}
		}

		public UserRequestedTrackingMode requestedTrackingMode
		{
			get
			{
				return m_RequestedTrackingMode;
			}
			set
			{
				m_RequestedTrackingMode = value;
				TryInitializeCamera();
			}
		}

		public TrackingOriginModeFlags TrackingOriginMode
		{
			get
			{
				return m_TrackingOriginMode;
			}
			set
			{
				m_TrackingOriginMode = value;
				TryInitializeCamera();
			}
		}

		[Obsolete("CameraOffset.trackingSpace is obsolete.  Please use CameraOffset.trackingOriginMode.")]
		public TrackingSpaceType trackingSpace
		{
			get
			{
				return m_TrackingSpace;
			}
			set
			{
				m_TrackingSpace = value;
				TryInitializeCamera();
			}
		}

		public float cameraYOffset
		{
			get
			{
				return m_CameraYOffset;
			}
			set
			{
				m_CameraYOffset = value;
				UpdateTrackingOrigin(m_TrackingOriginMode);
			}
		}

		private void UpgradeTrackingSpaceToTrackingOriginMode()
		{
			if (m_TrackingOriginMode == TrackingOriginModeFlags.Unknown && m_TrackingSpace <= TrackingSpaceType.RoomScale)
			{
				switch (m_TrackingSpace)
				{
				case TrackingSpaceType.RoomScale:
					m_TrackingOriginMode = TrackingOriginModeFlags.Floor;
					break;
				case TrackingSpaceType.Stationary:
					m_TrackingOriginMode = TrackingOriginModeFlags.Device;
					break;
				}
				m_TrackingSpace = (TrackingSpaceType)3;
			}
		}

		private void Awake()
		{
			if (!m_CameraFloorOffsetObject)
			{
				UnityEngine.Debug.LogWarning("No camera container specified for XR Rig, using attached GameObject");
				m_CameraFloorOffsetObject = base.gameObject;
			}
		}

		private void Start()
		{
			TryInitializeCamera();
		}

		private void OnValidate()
		{
			UpgradeTrackingSpaceToTrackingOriginMode();
			TryInitializeCamera();
		}

		private void TryInitializeCamera()
		{
			m_CameraInitialized = SetupCamera();
			if (!m_CameraInitialized & !m_CameraInitializing)
			{
				StartCoroutine(RepeatInitializeCamera());
			}
		}

		private IEnumerator RepeatInitializeCamera()
		{
			m_CameraInitializing = true;
			yield return null;
			while (!m_CameraInitialized)
			{
				m_CameraInitialized = SetupCamera();
				yield return null;
			}
			m_CameraInitializing = false;
		}

		private bool SetupCamera()
		{
			SubsystemManager.GetInstances(s_InputSubsystems);
			bool flag = true;
			if (s_InputSubsystems.Count != 0)
			{
				for (int i = 0; i < s_InputSubsystems.Count; i++)
				{
					bool flag2 = SetupCamera(s_InputSubsystems[i]);
					if (flag2)
					{
						s_InputSubsystems[i].trackingOriginUpdated -= OnTrackingOriginUpdated;
						s_InputSubsystems[i].trackingOriginUpdated += OnTrackingOriginUpdated;
					}
					flag = flag && flag2;
				}
			}
			else if (m_RequestedTrackingMode == UserRequestedTrackingMode.Floor)
			{
				SetupCameraLegacy(TrackingSpaceType.RoomScale);
			}
			else
			{
				SetupCameraLegacy(TrackingSpaceType.Stationary);
			}
			return flag;
		}

		private bool SetupCamera(XRInputSubsystem subsystem)
		{
			if (subsystem == null)
			{
				return false;
			}
			bool flag = false;
			TrackingOriginModeFlags trackingOriginMode = subsystem.GetTrackingOriginMode();
			TrackingOriginModeFlags supportedTrackingOriginModes = subsystem.GetSupportedTrackingOriginModes();
			TrackingOriginModeFlags trackingOriginModeFlags = TrackingOriginModeFlags.Unknown;
			if (m_RequestedTrackingMode == UserRequestedTrackingMode.Default)
			{
				trackingOriginModeFlags = trackingOriginMode;
			}
			else if (m_RequestedTrackingMode == UserRequestedTrackingMode.Device)
			{
				trackingOriginModeFlags = TrackingOriginModeFlags.Device;
			}
			else if (m_RequestedTrackingMode == UserRequestedTrackingMode.Floor)
			{
				trackingOriginModeFlags = TrackingOriginModeFlags.Floor;
			}
			else
			{
				UnityEngine.Debug.LogWarning("Unknown Requested Tracking Mode");
			}
			switch (trackingOriginModeFlags)
			{
			case TrackingOriginModeFlags.Floor:
				if ((supportedTrackingOriginModes & TrackingOriginModeFlags.Floor) == 0)
				{
					UnityEngine.Debug.LogWarning("CameraOffset.SetupCamera: Attempting to set the tracking space to Floor, but that is not supported by the SDK.");
				}
				else
				{
					flag = subsystem.TrySetTrackingOriginMode(trackingOriginModeFlags);
				}
				break;
			case TrackingOriginModeFlags.Device:
				if ((supportedTrackingOriginModes & TrackingOriginModeFlags.Device) == 0)
				{
					UnityEngine.Debug.LogWarning("CameraOffset.SetupCamera: Attempting to set the tracking space to Device, but that is not supported by the SDK.");
				}
				else
				{
					flag = subsystem.TrySetTrackingOriginMode(trackingOriginModeFlags) && subsystem.TryRecenter();
				}
				break;
			}
			if (flag)
			{
				UpdateTrackingOrigin(subsystem.GetTrackingOriginMode());
			}
			return flag;
		}

		private void UpdateTrackingOrigin(TrackingOriginModeFlags trackingOriginModeFlags)
		{
			m_TrackingOriginMode = trackingOriginModeFlags;
			if (m_CameraFloorOffsetObject != null)
			{
				m_CameraFloorOffsetObject.transform.localPosition = new Vector3(m_CameraFloorOffsetObject.transform.localPosition.x, (m_TrackingOriginMode == TrackingOriginModeFlags.Device) ? cameraYOffset : 0f, m_CameraFloorOffsetObject.transform.localPosition.z);
			}
		}

		private void OnTrackingOriginUpdated(XRInputSubsystem subsystem)
		{
			UpdateTrackingOrigin(subsystem.GetTrackingOriginMode());
		}

		private void OnDestroy()
		{
			SubsystemManager.GetInstances(s_InputSubsystems);
			foreach (XRInputSubsystem s_InputSubsystem in s_InputSubsystems)
			{
				s_InputSubsystem.trackingOriginUpdated -= OnTrackingOriginUpdated;
			}
		}

		private void SetupCameraLegacy(TrackingSpaceType trackingSpace)
		{
			float y = m_CameraYOffset;
			XRDevice.SetTrackingSpaceType(trackingSpace);
			switch (trackingSpace)
			{
			case TrackingSpaceType.Stationary:
				InputTracking.Recenter();
				break;
			case TrackingSpaceType.RoomScale:
				y = 0f;
				break;
			}
			m_TrackingSpace = trackingSpace;
			if ((bool)m_CameraFloorOffsetObject)
			{
				m_CameraFloorOffsetObject.transform.localPosition = new Vector3(m_CameraFloorOffsetObject.transform.localPosition.x, y, m_CameraFloorOffsetObject.transform.localPosition.z);
			}
		}
	}
}
namespace UnityEngine.XR.LegacyInputHelpers
{
	public class ArmModel : BasePoseProvider
	{
		private Pose m_FinalPose;

		[SerializeField]
		private XRNode m_PoseSource = XRNode.LeftHand;

		[SerializeField]
		private XRNode m_HeadPoseSource = XRNode.CenterEye;

		[SerializeField]
		private Vector3 m_ElbowRestPosition = DEFAULT_ELBOW_REST_POSITION;

		[SerializeField]
		private Vector3 m_WristRestPosition = DEFAULT_WRIST_REST_POSITION;

		[SerializeField]
		private Vector3 m_ControllerRestPosition = DEFAULT_CONTROLLER_REST_POSITION;

		[SerializeField]
		private Vector3 m_ArmExtensionOffset = DEFAULT_ARM_EXTENSION_OFFSET;

		[Range(0f, 1f)]
		[SerializeField]
		private float m_ElbowBendRatio = 0.6f;

		[SerializeField]
		private bool m_IsLockedToNeck = true;

		protected Vector3 m_NeckPosition;

		protected Vector3 m_ElbowPosition;

		protected Quaternion m_ElbowRotation;

		protected Vector3 m_WristPosition;

		protected Quaternion m_WristRotation;

		protected Vector3 m_ControllerPosition;

		protected Quaternion m_ControllerRotation;

		protected Vector3 m_HandedMultiplier;

		protected Vector3 m_TorsoDirection;

		protected Quaternion m_TorsoRotation;

		protected static readonly Vector3 DEFAULT_ELBOW_REST_POSITION = new Vector3(0.195f, -0.5f, 0.005f);

		protected static readonly Vector3 DEFAULT_WRIST_REST_POSITION = new Vector3(0f, 0f, 0.25f);

		protected static readonly Vector3 DEFAULT_CONTROLLER_REST_POSITION = new Vector3(0f, 0f, 0.05f);

		protected static readonly Vector3 DEFAULT_ARM_EXTENSION_OFFSET = new Vector3(-0.13f, 0.14f, 0.08f);

		protected const float DEFAULT_ELBOW_BEND_RATIO = 0.6f;

		protected const float EXTENSION_WEIGHT = 0.4f;

		protected static readonly Vector3 SHOULDER_POSITION = new Vector3(0.17f, -0.2f, -0.03f);

		protected static readonly Vector3 NECK_OFFSET = new Vector3(0f, 0.075f, 0.08f);

		protected const float MIN_EXTENSION_ANGLE = 7f;

		protected const float MAX_EXTENSION_ANGLE = 60f;

		private List<XRNodeState> xrNodeStateListOrientation = new List<XRNodeState>();

		private List<XRNodeState> xrNodeStateListPosition = new List<XRNodeState>();

		private List<XRNodeState> xrNodeStateListAngularAcceleration = new List<XRNodeState>();

		private List<XRNodeState> xrNodeStateListAngularVelocity = new List<XRNodeState>();

		public Pose finalPose
		{
			get
			{
				return m_FinalPose;
			}
			set
			{
				m_FinalPose = value;
			}
		}

		public XRNode poseSource
		{
			get
			{
				return m_PoseSource;
			}
			set
			{
				m_PoseSource = value;
			}
		}

		public XRNode headGameObject
		{
			get
			{
				return m_HeadPoseSource;
			}
			set
			{
				m_HeadPoseSource = value;
			}
		}

		public Vector3 elbowRestPosition
		{
			get
			{
				return m_ElbowRestPosition;
			}
			set
			{
				m_ElbowRestPosition = value;
			}
		}

		public Vector3 wristRestPosition
		{
			get
			{
				return m_WristRestPosition;
			}
			set
			{
				m_WristRestPosition = value;
			}
		}

		public Vector3 controllerRestPosition
		{
			get
			{
				return m_ControllerRestPosition;
			}
			set
			{
				m_ControllerRestPosition = value;
			}
		}

		public Vector3 armExtensionOffset
		{
			get
			{
				return m_ArmExtensionOffset;
			}
			set
			{
				m_ArmExtensionOffset = value;
			}
		}

		public float elbowBendRatio
		{
			get
			{
				return m_ElbowBendRatio;
			}
			set
			{
				m_ElbowBendRatio = value;
			}
		}

		public bool isLockedToNeck
		{
			get
			{
				return m_IsLockedToNeck;
			}
			set
			{
				m_IsLockedToNeck = value;
			}
		}

		public Vector3 neckPosition => m_NeckPosition;

		public Vector3 shoulderPosition => m_NeckPosition + m_TorsoRotation * Vector3.Scale(SHOULDER_POSITION, m_HandedMultiplier);

		public Quaternion shoulderRotation => m_TorsoRotation;

		public Vector3 elbowPosition => m_ElbowPosition;

		public Quaternion elbowRotation => m_ElbowRotation;

		public Vector3 wristPosition => m_WristPosition;

		public Quaternion wristRotation => m_WristRotation;

		public Vector3 controllerPosition => m_ControllerPosition;

		public Quaternion controllerRotation => m_ControllerRotation;

		public override PoseDataFlags GetPoseFromProvider(out Pose output)
		{
			if (OnControllerInputUpdated())
			{
				output = finalPose;
				return PoseDataFlags.Position | PoseDataFlags.Rotation;
			}
			output = Pose.identity;
			return PoseDataFlags.NoData;
		}

		protected virtual void OnEnable()
		{
			UpdateTorsoDirection(forceImmediate: true);
			OnControllerInputUpdated();
		}

		protected virtual void OnDisable()
		{
		}

		public virtual bool OnControllerInputUpdated()
		{
			UpdateHandedness();
			if (UpdateTorsoDirection(forceImmediate: false) && UpdateNeckPosition() && ApplyArmModel())
			{
				return true;
			}
			return false;
		}

		protected virtual void UpdateHandedness()
		{
			m_HandedMultiplier.Set(0f, 1f, 1f);
			if (m_PoseSource == XRNode.RightHand || m_PoseSource == XRNode.TrackingReference)
			{
				m_HandedMultiplier.x = 1f;
			}
			else if (m_PoseSource == XRNode.LeftHand)
			{
				m_HandedMultiplier.x = -1f;
			}
		}

		protected virtual bool UpdateTorsoDirection(bool forceImmediate)
		{
			Vector3 forward = default(Vector3);
			if (TryGetForwardVector(m_HeadPoseSource, out forward))
			{
				forward.y = 0f;
				forward.Normalize();
				Vector3 angularAccel;
				if (forceImmediate)
				{
					m_TorsoDirection = forward;
				}
				else if (TryGetAngularAcceleration(poseSource, out angularAccel))
				{
					float t = Mathf.Clamp((angularAccel.magnitude - 0.2f) / 45f, 0f, 0.1f);
					m_TorsoDirection = Vector3.Slerp(m_TorsoDirection, forward, t);
				}
				m_TorsoRotation = Quaternion.FromToRotation(Vector3.forward, m_TorsoDirection);
				return true;
			}
			return false;
		}

		protected virtual bool UpdateNeckPosition()
		{
			if (m_IsLockedToNeck && TryGetPosition(m_HeadPoseSource, out m_NeckPosition))
			{
				return ApplyInverseNeckModel(m_NeckPosition, out m_NeckPosition);
			}
			m_NeckPosition = Vector3.zero;
			return true;
		}

		protected virtual bool ApplyArmModel()
		{
			SetUntransformedJointPositions();
			if (GetControllerRotation(out var rotation, out var xyRotation, out var xAngle))
			{
				float extensionRatio = CalculateExtensionRatio(xAngle);
				ApplyExtensionOffset(extensionRatio);
				Quaternion lerpRotation = CalculateLerpRotation(xyRotation, extensionRatio);
				CalculateFinalJointRotations(rotation, xyRotation, lerpRotation);
				ApplyRotationToJoints();
				m_FinalPose.position = m_ControllerPosition;
				m_FinalPose.rotation = m_ControllerRotation;
				return true;
			}
			return false;
		}

		protected virtual void SetUntransformedJointPositions()
		{
			m_ElbowPosition = Vector3.Scale(m_ElbowRestPosition, m_HandedMultiplier);
			m_WristPosition = Vector3.Scale(m_WristRestPosition, m_HandedMultiplier);
			m_ControllerPosition = Vector3.Scale(m_ControllerRestPosition, m_HandedMultiplier);
		}

		protected virtual float CalculateExtensionRatio(float xAngle)
		{
			return Mathf.Clamp((xAngle - 7f) / 53f, 0f, 1f);
		}

		protected virtual void ApplyExtensionOffset(float extensionRatio)
		{
			Vector3 vector = Vector3.Scale(m_ArmExtensionOffset, m_HandedMultiplier);
			m_ElbowPosition += vector * extensionRatio;
		}

		protected virtual Quaternion CalculateLerpRotation(Quaternion xyRotation, float extensionRatio)
		{
			float num = Quaternion.Angle(xyRotation, Quaternion.identity);
			float num2 = 1f - Mathf.Pow(num / 180f, 6f);
			float num3 = 1f - m_ElbowBendRatio + m_ElbowBendRatio * extensionRatio * 0.4f;
			num3 *= num2;
			return Quaternion.Lerp(Quaternion.identity, xyRotation, num3);
		}

		protected virtual void CalculateFinalJointRotations(Quaternion controllerOrientation, Quaternion xyRotation, Quaternion lerpRotation)
		{
			m_ElbowRotation = m_TorsoRotation * Quaternion.Inverse(lerpRotation) * xyRotation;
			m_WristRotation = m_ElbowRotation * lerpRotation;
			m_ControllerRotation = m_TorsoRotation * controllerOrientation;
		}

		protected virtual void ApplyRotationToJoints()
		{
			m_ElbowPosition = m_NeckPosition + m_TorsoRotation * m_ElbowPosition;
			m_WristPosition = m_ElbowPosition + m_ElbowRotation * m_WristPosition;
			m_ControllerPosition = m_WristPosition + m_WristRotation * m_ControllerPosition;
		}

		protected virtual bool ApplyInverseNeckModel(Vector3 headPosition, out Vector3 calculatedPosition)
		{
			Quaternion rotation = default(Quaternion);
			if (TryGetRotation(m_HeadPoseSource, out rotation))
			{
				Vector3 vector = rotation * NECK_OFFSET - NECK_OFFSET.y * Vector3.up;
				headPosition -= vector;
				calculatedPosition = headPosition;
				return true;
			}
			calculatedPosition = Vector3.zero;
			return false;
		}

		protected bool TryGetForwardVector(XRNode node, out Vector3 forward)
		{
			Pose pose = default(Pose);
			if (TryGetRotation(node, out pose.rotation) && TryGetPosition(node, out pose.position))
			{
				forward = pose.forward;
				return true;
			}
			forward = Vector3.zero;
			return false;
		}

		protected bool TryGetRotation(XRNode node, out Quaternion rotation)
		{
			InputTracking.GetNodeStates(xrNodeStateListOrientation);
			int count = xrNodeStateListOrientation.Count;
			for (int i = 0; i < count; i++)
			{
				XRNodeState xRNodeState = xrNodeStateListOrientation[i];
				if (xRNodeState.nodeType == node && xRNodeState.TryGetRotation(out rotation))
				{
					return true;
				}
			}
			rotation = Quaternion.identity;
			return false;
		}

		protected bool TryGetPosition(XRNode node, out Vector3 position)
		{
			InputTracking.GetNodeStates(xrNodeStateListPosition);
			int count = xrNodeStateListPosition.Count;
			for (int i = 0; i < count; i++)
			{
				XRNodeState xRNodeState = xrNodeStateListPosition[i];
				if (xRNodeState.nodeType == node && xRNodeState.TryGetPosition(out position))
				{
					return true;
				}
			}
			position = Vector3.zero;
			return false;
		}

		protected bool TryGetAngularAcceleration(XRNode node, out Vector3 angularAccel)
		{
			InputTracking.GetNodeStates(xrNodeStateListAngularAcceleration);
			int count = xrNodeStateListAngularAcceleration.Count;
			for (int i = 0; i < count; i++)
			{
				XRNodeState xRNodeState = xrNodeStateListAngularAcceleration[i];
				if (xRNodeState.nodeType == node && xRNodeState.TryGetAngularAcceleration(out angularAccel))
				{
					return true;
				}
			}
			angularAccel = Vector3.zero;
			return false;
		}

		protected bool TryGetAngularVelocity(XRNode node, out Vector3 angVel)
		{
			InputTracking.GetNodeStates(xrNodeStateListAngularVelocity);
			int count = xrNodeStateListAngularVelocity.Count;
			for (int i = 0; i < count; i++)
			{
				XRNodeState xRNodeState = xrNodeStateListAngularVelocity[i];
				if (xRNodeState.nodeType == node && xRNodeState.TryGetAngularVelocity(out angVel))
				{
					return true;
				}
			}
			angVel = Vector3.zero;
			return false;
		}

		protected bool GetControllerRotation(out Quaternion rotation, out Quaternion xyRotation, out float xAngle)
		{
			if (TryGetRotation(poseSource, out rotation))
			{
				rotation = Quaternion.Inverse(m_TorsoRotation) * rotation;
				Vector3 vector = rotation * Vector3.forward;
				xAngle = 90f - Vector3.Angle(vector, Vector3.up);
				xyRotation = Quaternion.FromToRotation(Vector3.forward, vector);
				return true;
			}
			rotation = Quaternion.identity;
			xyRotation = Quaternion.identity;
			xAngle = 0f;
			return false;
		}
	}
	public class SwingArmModel : ArmModel
	{
		[Tooltip("Portion of controller rotation applied to the shoulder joint.")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ShoulderRotationRatio = 0.5f;

		[Tooltip("Portion of controller rotation applied to the elbow joint.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_ElbowRotationRatio = 0.3f;

		[Tooltip("Portion of controller rotation applied to the wrist joint.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_WristRotationRatio = 0.2f;

		[SerializeField]
		private Vector2 m_JointShiftAngle = new Vector2(160f, 180f);

		[Tooltip("Exponent applied to the joint shift ratio to control the curve of the shift.")]
		[Range(1f, 20f)]
		[SerializeField]
		private float m_JointShiftExponent = 6f;

		[Tooltip("Portion of controller rotation applied to the shoulder joint when the controller is backwards.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_ShiftedShoulderRotationRatio = 0.1f;

		[Tooltip("Portion of controller rotation applied to the elbow joint when the controller is backwards.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_ShiftedElbowRotationRatio = 0.4f;

		[Tooltip("Portion of controller rotation applied to the wrist joint when the controller is backwards.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_ShiftedWristRotationRatio = 0.5f;

		public float shoulderRotationRatio
		{
			get
			{
				return m_ShoulderRotationRatio;
			}
			set
			{
				m_ShoulderRotationRatio = value;
			}
		}

		public float elbowRotationRatio
		{
			get
			{
				return m_ElbowRotationRatio;
			}
			set
			{
				m_ElbowRotationRatio = value;
			}
		}

		public float wristRotationRatio
		{
			get
			{
				return m_WristRotationRatio;
			}
			set
			{
				m_WristRotationRatio = value;
			}
		}

		public float minJointShiftAngle
		{
			get
			{
				return m_JointShiftAngle.x;
			}
			set
			{
				m_JointShiftAngle.x = value;
			}
		}

		public float maxJointShiftAngle
		{
			get
			{
				return m_JointShiftAngle.y;
			}
			set
			{
				m_JointShiftAngle.y = value;
			}
		}

		public float jointShiftExponent
		{
			get
			{
				return m_JointShiftExponent;
			}
			set
			{
				m_JointShiftExponent = value;
			}
		}

		public float shiftedShoulderRotationRatio
		{
			get
			{
				return m_ShiftedShoulderRotationRatio;
			}
			set
			{
				m_ShiftedShoulderRotationRatio = value;
			}
		}

		public float shiftedElbowRotationRatio
		{
			get
			{
				return m_ShiftedElbowRotationRatio;
			}
			set
			{
				m_ShiftedElbowRotationRatio = value;
			}
		}

		public float shiftedWristRotationRatio
		{
			get
			{
				return m_ShiftedWristRotationRatio;
			}
			set
			{
				m_ShiftedWristRotationRatio = value;
			}
		}

		protected override void CalculateFinalJointRotations(Quaternion controllerOrientation, Quaternion xyRotation, Quaternion lerpRotation)
		{
			float num = Quaternion.Angle(xyRotation, Quaternion.identity);
			float num2 = maxJointShiftAngle - minJointShiftAngle;
			float t = Mathf.Pow(Mathf.Clamp01((num - minJointShiftAngle) / num2), m_JointShiftExponent);
			float t2 = Mathf.Lerp(m_ShoulderRotationRatio, m_ShiftedShoulderRotationRatio, t);
			float t3 = Mathf.Lerp(m_ElbowRotationRatio, m_ShiftedElbowRotationRatio, t);
			float t4 = Mathf.Lerp(m_WristRotationRatio, m_ShiftedWristRotationRatio, t);
			Quaternion quaternion = Quaternion.Lerp(Quaternion.identity, xyRotation, t2);
			Quaternion quaternion2 = Quaternion.Lerp(Quaternion.identity, xyRotation, t3);
			Quaternion quaternion3 = Quaternion.Lerp(Quaternion.identity, xyRotation, t4);
			Quaternion quaternion4 = m_TorsoRotation * quaternion;
			m_ElbowRotation = quaternion4 * quaternion2;
			m_WristRotation = base.elbowRotation * quaternion3;
			m_ControllerRotation = m_TorsoRotation * controllerOrientation;
			m_TorsoRotation = quaternion4;
		}
	}
	[Serializable]
	public class ArmModelTransition
	{
		[SerializeField]
		private string m_KeyName;

		[SerializeField]
		private ArmModel m_ArmModel;

		public string transitionKeyName
		{
			get
			{
				return m_KeyName;
			}
			set
			{
				m_KeyName = value;
			}
		}

		public ArmModel armModel
		{
			get
			{
				return m_ArmModel;
			}
			set
			{
				m_ArmModel = value;
			}
		}
	}
	public class TransitionArmModel : ArmModel
	{
		internal struct ArmModelBlendData
		{
			public ArmModel armModel;

			public float currentBlendAmount;
		}

		[SerializeField]
		private ArmModel m_CurrentArmModelComponent;

		[SerializeField]
		public List<ArmModelTransition> m_ArmModelTransitions = new List<ArmModelTransition>();

		private const int MAX_ACTIVE_TRANSITIONS = 10;

		private const float DROP_TRANSITION_THRESHOLD = 0.035f;

		private const float LERP_CLAMP_THRESHOLD = 0.95f;

		private const float MIN_ANGULAR_VELOCITY = 0.2f;

		private const float ANGULAR_VELOCITY_DIVISOR = 45f;

		internal List<ArmModelBlendData> armModelBlendData = new List<ArmModelBlendData>(10);

		private ArmModelBlendData currentBlendingArmModel;

		public ArmModel currentArmModelComponent
		{
			get
			{
				return m_CurrentArmModelComponent;
			}
			set
			{
				m_CurrentArmModelComponent = value;
			}
		}

		public bool Queue(string key)
		{
			foreach (ArmModelTransition armModelTransition in m_ArmModelTransitions)
			{
				if (armModelTransition.transitionKeyName == key)
				{
					Queue(armModelTransition.armModel);
					return true;
				}
			}
			return false;
		}

		public void Queue(ArmModel newArmModel)
		{
			if (!(newArmModel == null))
			{
				if (m_CurrentArmModelComponent == null)
				{
					m_CurrentArmModelComponent = newArmModel;
				}
				RemoveJustStartingTransitions();
				if (armModelBlendData.Count == 10)
				{
					RemoveOldestTransition();
				}
				ArmModelBlendData item = new ArmModelBlendData
				{
					armModel = newArmModel,
					currentBlendAmount = 0f
				};
				armModelBlendData.Add(item);
			}
		}

		private void RemoveJustStartingTransitions()
		{
			for (int i = 0; i < armModelBlendData.Count; i++)
			{
				if (armModelBlendData[i].currentBlendAmount < 0.035f)
				{
					armModelBlendData.RemoveAt(i);
				}
			}
		}

		private void RemoveOldestTransition()
		{
			armModelBlendData.RemoveAt(0);
		}

		public override PoseDataFlags GetPoseFromProvider(out Pose output)
		{
			if (UpdateBlends())
			{
				output = base.finalPose;
				return PoseDataFlags.Position | PoseDataFlags.Rotation;
			}
			output = Pose.identity;
			return PoseDataFlags.NoData;
		}

		private bool UpdateBlends()
		{
			if (currentArmModelComponent == null)
			{
				return false;
			}
			if (m_CurrentArmModelComponent.OnControllerInputUpdated())
			{
				m_NeckPosition = m_CurrentArmModelComponent.neckPosition;
				m_ElbowPosition = m_CurrentArmModelComponent.elbowPosition;
				m_WristPosition = m_CurrentArmModelComponent.wristPosition;
				m_ControllerPosition = m_CurrentArmModelComponent.controllerPosition;
				m_ElbowRotation = m_CurrentArmModelComponent.elbowRotation;
				m_WristRotation = m_CurrentArmModelComponent.wristRotation;
				m_ControllerRotation = m_CurrentArmModelComponent.controllerRotation;
				if (TryGetAngularVelocity(base.poseSource, out var angVel) && armModelBlendData.Count > 0)
				{
					float t = Mathf.Clamp((angVel.magnitude - 0.2f) / 45f, 0f, 0.1f);
					for (int i = 0; i < armModelBlendData.Count; i++)
					{
						ArmModelBlendData value = armModelBlendData[i];
						value.currentBlendAmount = Mathf.Lerp(value.currentBlendAmount, 1f, t);
						if (value.currentBlendAmount > 0.95f)
						{
							value.currentBlendAmount = 1f;
						}
						else
						{
							value.armModel.OnControllerInputUpdated();
							m_NeckPosition = Vector3.Slerp(base.neckPosition, value.armModel.neckPosition, value.currentBlendAmount);
							m_ElbowPosition = Vector3.Slerp(base.elbowPosition, value.armModel.elbowPosition, value.currentBlendAmount);
							m_WristPosition = Vector3.Slerp(base.wristPosition, value.armModel.wristPosition, value.currentBlendAmount);
							m_ControllerPosition = Vector3.Slerp(base.controllerPosition, value.armModel.controllerPosition, value.currentBlendAmount);
							m_ElbowRotation = Quaternion.Slerp(base.elbowRotation, value.armModel.elbowRotation, value.currentBlendAmount);
							m_WristRotation = Quaternion.Slerp(base.wristRotation, value.armModel.wristRotation, value.currentBlendAmount);
							m_ControllerRotation = Quaternion.Slerp(base.controllerRotation, value.armModel.controllerRotation, value.currentBlendAmount);
						}
						armModelBlendData[i] = value;
						if (value.currentBlendAmount >= 1f)
						{
							m_CurrentArmModelComponent = value.armModel;
							armModelBlendData.RemoveRange(0, i + 1);
						}
					}
				}
				else if (armModelBlendData.Count > 0)
				{
					Debug.LogErrorFormat(base.gameObject, "Unable to get angular acceleration for node");
					return false;
				}
				base.finalPose = new Pose(base.controllerPosition, base.controllerRotation);
				return true;
			}
			return false;
		}
	}
}
