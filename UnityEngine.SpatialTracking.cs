using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.XR.Interaction;
using UnityEngine.SpatialTracking;
using UnityEngine.XR;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("UnityEditor.XR.SpatialTracking")]
[assembly: InternalsVisibleTo("UnityEditor.SpatialTracking")]
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
			FilePathsData = new byte[241]
			{
				0, 0, 0, 1, 0, 0, 0, 112, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				120, 114, 46, 108, 101, 103, 97, 99, 121, 105,
				110, 112, 117, 116, 104, 101, 108, 112, 101, 114,
				115, 64, 98, 55, 53, 55, 57, 101, 56, 54,
				102, 51, 98, 52, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 84, 114, 97, 99, 107, 101, 100,
				80, 111, 115, 101, 68, 114, 105, 118, 101, 114,
				92, 66, 97, 115, 101, 80, 111, 115, 101, 80,
				114, 111, 118, 105, 100, 101, 114, 46, 99, 115,
				0, 0, 0, 4, 0, 0, 0, 113, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				120, 114, 46, 108, 101, 103, 97, 99, 121, 105,
				110, 112, 117, 116, 104, 101, 108, 112, 101, 114,
				115, 64, 98, 55, 53, 55, 57, 101, 56, 54,
				102, 51, 98, 52, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 84, 114, 97, 99, 107, 101, 100,
				80, 111, 115, 101, 68, 114, 105, 118, 101, 114,
				92, 84, 114, 97, 99, 107, 101, 100, 80, 111,
				115, 101, 68, 114, 105, 118, 101, 114, 46, 99,
				115
			},
			TypesData = new byte[297]
			{
				0, 0, 0, 0, 56, 85, 110, 105, 116, 121,
				69, 110, 103, 105, 110, 101, 46, 69, 120, 112,
				101, 114, 105, 109, 101, 110, 116, 97, 108, 46,
				88, 82, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 124, 66, 97, 115, 101, 80,
				111, 115, 101, 80, 114, 111, 118, 105, 100, 101,
				114, 0, 0, 0, 0, 60, 85, 110, 105, 116,
				121, 69, 110, 103, 105, 110, 101, 46, 83, 112,
				97, 116, 105, 97, 108, 84, 114, 97, 99, 107,
				105, 110, 103, 124, 84, 114, 97, 99, 107, 101,
				100, 80, 111, 115, 101, 68, 114, 105, 118, 101,
				114, 68, 97, 116, 97, 68, 101, 115, 99, 114,
				105, 112, 116, 105, 111, 110, 0, 0, 0, 0,
				69, 85, 110, 105, 116, 121, 69, 110, 103, 105,
				110, 101, 46, 83, 112, 97, 116, 105, 97, 108,
				84, 114, 97, 99, 107, 105, 110, 103, 46, 84,
				114, 97, 99, 107, 101, 100, 80, 111, 115, 101,
				68, 114, 105, 118, 101, 114, 68, 97, 116, 97,
				68, 101, 115, 99, 114, 105, 112, 116, 105, 111,
				110, 124, 80, 111, 115, 101, 68, 97, 116, 97,
				0, 0, 0, 0, 42, 85, 110, 105, 116, 121,
				69, 110, 103, 105, 110, 101, 46, 83, 112, 97,
				116, 105, 97, 108, 84, 114, 97, 99, 107, 105,
				110, 103, 124, 80, 111, 115, 101, 68, 97, 116,
				97, 83, 111, 117, 114, 99, 101, 0, 0, 0,
				0, 45, 85, 110, 105, 116, 121, 69, 110, 103,
				105, 110, 101, 46, 83, 112, 97, 116, 105, 97,
				108, 84, 114, 97, 99, 107, 105, 110, 103, 124,
				84, 114, 97, 99, 107, 101, 100, 80, 111, 115,
				101, 68, 114, 105, 118, 101, 114
			},
			TotalFiles = 2,
			TotalTypes = 5,
			IsEditorOnly = false
		};
	}
}
namespace UnityEngine.SpatialTracking
{
	internal class TrackedPoseDriverDataDescription
	{
		internal struct PoseData
		{
			public List<string> PoseNames;

			public List<TrackedPoseDriver.TrackedPose> Poses;
		}

		internal static List<PoseData> DeviceData = new List<PoseData>
		{
			new PoseData
			{
				PoseNames = new List<string> { "Left Eye", "Right Eye", "Center Eye - HMD Reference", "Head", "Color Camera" },
				Poses = new List<TrackedPoseDriver.TrackedPose>
				{
					TrackedPoseDriver.TrackedPose.LeftEye,
					TrackedPoseDriver.TrackedPose.RightEye,
					TrackedPoseDriver.TrackedPose.Center,
					TrackedPoseDriver.TrackedPose.Head,
					TrackedPoseDriver.TrackedPose.ColorCamera
				}
			},
			new PoseData
			{
				PoseNames = new List<string> { "Left Controller", "Right Controller" },
				Poses = new List<TrackedPoseDriver.TrackedPose>
				{
					TrackedPoseDriver.TrackedPose.LeftPose,
					TrackedPoseDriver.TrackedPose.RightPose
				}
			},
			new PoseData
			{
				PoseNames = new List<string> { "Device Pose" },
				Poses = new List<TrackedPoseDriver.TrackedPose> { TrackedPoseDriver.TrackedPose.RemotePose }
			}
		};
	}
	[Flags]
	public enum PoseDataFlags
	{
		NoData = 0,
		Position = 1,
		Rotation = 2
	}
	public static class PoseDataSource
	{
		internal static List<XRNodeState> nodeStates = new List<XRNodeState>();

		internal static PoseDataFlags GetNodePoseData(XRNode node, out Pose resultPose)
		{
			PoseDataFlags poseDataFlags = PoseDataFlags.NoData;
			InputTracking.GetNodeStates(nodeStates);
			foreach (XRNodeState nodeState in nodeStates)
			{
				if (nodeState.nodeType == node)
				{
					if (nodeState.TryGetPosition(out resultPose.position))
					{
						poseDataFlags |= PoseDataFlags.Position;
					}
					if (nodeState.TryGetRotation(out resultPose.rotation))
					{
						poseDataFlags |= PoseDataFlags.Rotation;
					}
					return poseDataFlags;
				}
			}
			resultPose = Pose.identity;
			return poseDataFlags;
		}

		public static bool TryGetDataFromSource(TrackedPoseDriver.TrackedPose poseSource, out Pose resultPose)
		{
			return GetDataFromSource(poseSource, out resultPose) == (PoseDataFlags.Position | PoseDataFlags.Rotation);
		}

		public static PoseDataFlags GetDataFromSource(TrackedPoseDriver.TrackedPose poseSource, out Pose resultPose)
		{
			switch (poseSource)
			{
			case TrackedPoseDriver.TrackedPose.RemotePose:
			{
				PoseDataFlags nodePoseData = GetNodePoseData(XRNode.RightHand, out resultPose);
				if (nodePoseData == PoseDataFlags.NoData)
				{
					return GetNodePoseData(XRNode.LeftHand, out resultPose);
				}
				return nodePoseData;
			}
			case TrackedPoseDriver.TrackedPose.LeftEye:
				return GetNodePoseData(XRNode.LeftEye, out resultPose);
			case TrackedPoseDriver.TrackedPose.RightEye:
				return GetNodePoseData(XRNode.RightEye, out resultPose);
			case TrackedPoseDriver.TrackedPose.Head:
				return GetNodePoseData(XRNode.Head, out resultPose);
			case TrackedPoseDriver.TrackedPose.Center:
				return GetNodePoseData(XRNode.CenterEye, out resultPose);
			case TrackedPoseDriver.TrackedPose.LeftPose:
				return GetNodePoseData(XRNode.LeftHand, out resultPose);
			case TrackedPoseDriver.TrackedPose.RightPose:
				return GetNodePoseData(XRNode.RightHand, out resultPose);
			case TrackedPoseDriver.TrackedPose.ColorCamera:
				return GetNodePoseData(XRNode.CenterEye, out resultPose);
			default:
				Debug.LogWarningFormat("Unable to retrieve pose data for poseSource: {0}", poseSource.ToString());
				resultPose = Pose.identity;
				return PoseDataFlags.NoData;
			}
		}
	}
	[Serializable]
	[DefaultExecutionOrder(-30000)]
	[AddComponentMenu("XR/Tracked Pose Driver")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.xr.legacyinputhelpers@2.1/manual/index.html")]
	public class TrackedPoseDriver : MonoBehaviour
	{
		public enum DeviceType
		{
			GenericXRDevice,
			GenericXRController,
			GenericXRRemote
		}

		public enum TrackedPose
		{
			LeftEye,
			RightEye,
			Center,
			Head,
			LeftPose,
			RightPose,
			ColorCamera,
			DepthCameraDeprecated,
			FisheyeCameraDeprected,
			DeviceDeprecated,
			RemotePose
		}

		public enum TrackingType
		{
			RotationAndPosition,
			RotationOnly,
			PositionOnly
		}

		public enum UpdateType
		{
			UpdateAndBeforeRender,
			Update,
			BeforeRender
		}

		[SerializeField]
		private DeviceType m_Device;

		[SerializeField]
		private TrackedPose m_PoseSource = TrackedPose.Center;

		[SerializeField]
		private BasePoseProvider m_PoseProviderComponent;

		[SerializeField]
		private TrackingType m_TrackingType;

		[SerializeField]
		private UpdateType m_UpdateType;

		[SerializeField]
		private bool m_UseRelativeTransform;

		protected Pose m_OriginPose;

		public DeviceType deviceType
		{
			get
			{
				return m_Device;
			}
			internal set
			{
				m_Device = value;
			}
		}

		public TrackedPose poseSource
		{
			get
			{
				return m_PoseSource;
			}
			internal set
			{
				m_PoseSource = value;
			}
		}

		public BasePoseProvider poseProviderComponent
		{
			get
			{
				return m_PoseProviderComponent;
			}
			set
			{
				m_PoseProviderComponent = value;
			}
		}

		public TrackingType trackingType
		{
			get
			{
				return m_TrackingType;
			}
			set
			{
				m_TrackingType = value;
			}
		}

		public UpdateType updateType
		{
			get
			{
				return m_UpdateType;
			}
			set
			{
				m_UpdateType = value;
			}
		}

		public bool UseRelativeTransform
		{
			get
			{
				return m_UseRelativeTransform;
			}
			set
			{
				m_UseRelativeTransform = value;
			}
		}

		public Pose originPose
		{
			get
			{
				return m_OriginPose;
			}
			set
			{
				m_OriginPose = value;
			}
		}

		public bool SetPoseSource(DeviceType deviceType, TrackedPose pose)
		{
			if ((int)deviceType < TrackedPoseDriverDataDescription.DeviceData.Count)
			{
				TrackedPoseDriverDataDescription.PoseData poseData = TrackedPoseDriverDataDescription.DeviceData[(int)deviceType];
				for (int i = 0; i < poseData.Poses.Count; i++)
				{
					if (poseData.Poses[i] == pose)
					{
						this.deviceType = deviceType;
						poseSource = pose;
						return true;
					}
				}
			}
			return false;
		}

		private PoseDataFlags GetPoseData(DeviceType device, TrackedPose poseSource, out Pose resultPose)
		{
			if (!(m_PoseProviderComponent != null))
			{
				return PoseDataSource.GetDataFromSource(poseSource, out resultPose);
			}
			return m_PoseProviderComponent.GetPoseFromProvider(out resultPose);
		}

		private void CacheLocalPosition()
		{
			m_OriginPose.position = base.transform.localPosition;
			m_OriginPose.rotation = base.transform.localRotation;
		}

		private void ResetToCachedLocalPosition()
		{
			SetLocalTransform(m_OriginPose.position, m_OriginPose.rotation, PoseDataFlags.Position | PoseDataFlags.Rotation);
		}

		protected virtual void Awake()
		{
			CacheLocalPosition();
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void OnEnable()
		{
			Application.onBeforeRender += OnBeforeRender;
		}

		protected virtual void OnDisable()
		{
			ResetToCachedLocalPosition();
			Application.onBeforeRender -= OnBeforeRender;
		}

		protected virtual void FixedUpdate()
		{
			if (m_UpdateType == UpdateType.Update || m_UpdateType == UpdateType.UpdateAndBeforeRender)
			{
				PerformUpdate();
			}
		}

		protected virtual void Update()
		{
			if (m_UpdateType == UpdateType.Update || m_UpdateType == UpdateType.UpdateAndBeforeRender)
			{
				PerformUpdate();
			}
		}

		[BeforeRenderOrder(-30000)]
		protected virtual void OnBeforeRender()
		{
			if (m_UpdateType == UpdateType.BeforeRender || m_UpdateType == UpdateType.UpdateAndBeforeRender)
			{
				PerformUpdate();
			}
		}

		protected virtual void SetLocalTransform(Vector3 newPosition, Quaternion newRotation, PoseDataFlags poseFlags)
		{
			if ((m_TrackingType == TrackingType.RotationAndPosition || m_TrackingType == TrackingType.RotationOnly) && (poseFlags & PoseDataFlags.Rotation) > PoseDataFlags.NoData)
			{
				base.transform.localRotation = newRotation;
			}
			if ((m_TrackingType == TrackingType.RotationAndPosition || m_TrackingType == TrackingType.PositionOnly) && (poseFlags & PoseDataFlags.Position) > PoseDataFlags.NoData)
			{
				base.transform.localPosition = newPosition;
			}
		}

		protected Pose TransformPoseByOriginIfNeeded(Pose pose)
		{
			if (m_UseRelativeTransform)
			{
				return pose.GetTransformedBy(m_OriginPose);
			}
			return pose;
		}

		private bool HasStereoCamera()
		{
			Camera component = GetComponent<Camera>();
			if (component != null)
			{
				return component.stereoEnabled;
			}
			return false;
		}

		protected virtual void PerformUpdate()
		{
			if (base.enabled)
			{
				Pose resultPose;
				PoseDataFlags poseData = GetPoseData(m_Device, m_PoseSource, out resultPose);
				if (poseData != PoseDataFlags.NoData)
				{
					Pose pose = TransformPoseByOriginIfNeeded(resultPose);
					SetLocalTransform(pose.position, pose.rotation, poseData);
				}
			}
		}
	}
}
namespace UnityEngine.Experimental.XR.Interaction
{
	[Serializable]
	public abstract class BasePoseProvider : MonoBehaviour
	{
		public virtual PoseDataFlags GetPoseFromProvider(out Pose output)
		{
			if (TryGetPoseFromProvider(out output))
			{
				return PoseDataFlags.Position | PoseDataFlags.Rotation;
			}
			return PoseDataFlags.NoData;
		}

		[Obsolete("This function is provided for backwards compatibility with the BasePoseProvider found in com.unity.xr.legacyinputhelpers v1.3.X. Please do not implement this function, instead use the new API via GetPoseFromProvider", false)]
		public virtual bool TryGetPoseFromProvider(out Pose output)
		{
			output = Pose.identity;
			return false;
		}
	}
}
