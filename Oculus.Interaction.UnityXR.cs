using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Oculus.Interaction.GrabAPI;
using Oculus.Interaction.Input;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;

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
			FilePathsData = new byte[621]
			{
				0, 0, 0, 1, 0, 0, 0, 117, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 105, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 64, 98, 101,
				53, 51, 100, 101, 53, 51, 55, 49, 48, 98,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 85,
				110, 105, 116, 121, 88, 82, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 68, 101, 102, 97, 117,
				108, 116, 72, 97, 110, 100, 83, 107, 101, 108,
				101, 116, 111, 110, 80, 114, 111, 118, 105, 100,
				101, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 114, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 105, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 64, 98, 101, 53, 51, 100, 101, 53,
				51, 55, 49, 48, 98, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 85, 110, 105, 116, 121, 88,
				82, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				70, 114, 111, 109, 79, 112, 101, 110, 88, 82,
				72, 97, 110, 100, 68, 97, 116, 97, 83, 111,
				117, 114, 99, 101, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 121, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 105, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 64, 98, 101, 53, 51, 100,
				101, 53, 51, 55, 49, 48, 98, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 85, 110, 105, 116,
				121, 88, 82, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 70, 114, 111, 109, 85, 110, 105, 116,
				121, 88, 82, 67, 111, 110, 116, 114, 111, 108,
				108, 101, 114, 68, 97, 116, 97, 83, 111, 117,
				114, 99, 101, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 115, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 105, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 64, 98, 101, 53, 51, 100, 101,
				53, 51, 55, 49, 48, 98, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 85, 110, 105, 116, 121,
				88, 82, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 70, 114, 111, 109, 85, 110, 105, 116, 121,
				88, 82, 72, 97, 110, 100, 68, 97, 116, 97,
				83, 111, 117, 114, 99, 101, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 114, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 64, 98, 101, 53,
				51, 100, 101, 53, 51, 55, 49, 48, 98, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 85, 110,
				105, 116, 121, 88, 82, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 70, 114, 111, 109, 85, 110,
				105, 116, 121, 88, 82, 72, 109, 100, 68, 97,
				116, 97, 83, 111, 117, 114, 99, 101, 46, 99,
				115
			},
			TypesData = new byte[301]
			{
				0, 0, 0, 0, 52, 79, 99, 117, 108, 117,
				115, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 73, 110, 112, 117, 116, 124,
				68, 101, 102, 97, 117, 108, 116, 72, 97, 110,
				100, 83, 107, 101, 108, 101, 116, 111, 110, 80,
				114, 111, 118, 105, 100, 101, 114, 0, 0, 0,
				0, 57, 79, 99, 117, 108, 117, 115, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				46, 73, 110, 112, 117, 116, 46, 85, 110, 105,
				116, 121, 88, 82, 124, 70, 114, 111, 109, 79,
				112, 101, 110, 88, 82, 72, 97, 110, 100, 68,
				97, 116, 97, 83, 111, 117, 114, 99, 101, 0,
				0, 0, 0, 58, 79, 99, 117, 108, 117, 115,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 46, 85, 110, 105, 116, 121, 88, 82,
				124, 70, 114, 111, 109, 85, 110, 105, 116, 121,
				88, 82, 67, 111, 110, 116, 114, 111, 108, 108,
				101, 114, 68, 97, 116, 97, 83, 111, 117, 114,
				99, 101, 0, 0, 0, 0, 58, 79, 99, 117,
				108, 117, 115, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 46, 73, 110, 112, 117,
				116, 46, 85, 110, 105, 116, 121, 88, 82, 124,
				70, 114, 111, 109, 85, 110, 105, 116, 121, 88,
				82, 72, 97, 110, 100, 68, 97, 116, 97, 83,
				111, 117, 114, 99, 101, 0, 0, 0, 0, 51,
				79, 99, 117, 108, 117, 115, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 46, 85,
				110, 105, 116, 121, 88, 82, 124, 70, 114, 111,
				109, 85, 110, 105, 116, 121, 88, 82, 72, 109,
				100, 68, 97, 116, 97, 83, 111, 117, 114, 99,
				101
			},
			TotalFiles = 5,
			TotalTypes = 5,
			IsEditorOnly = false
		};
	}
}
namespace Oculus.Interaction.UnityXR
{
	public class FromUnityXRControllerDataSource : DataSource<ControllerDataAsset>
	{
		[Header("Shared Configuration")]
		[SerializeField]
		private Handedness _handedness;

		[SerializeField]
		[Interface(typeof(ITrackingToWorldTransformer), new Type[] { })]
		private UnityEngine.Object _trackingToWorldTransformer;

		private ITrackingToWorldTransformer TrackingToWorldTransformer;

		private static string ControllerActionMap = "{\n            \"maps\": [\n                {\n                    \"name\": \"XRController\",\n                    \"actions\": [\n                        {\n                            \"name\": \"PrimaryButton\",\n                            \"expectedControlLayout\": \"Integer\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/primaryButton\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"PrimaryTouch\",\n                            \"expectedControlLayout\": \"Integer\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/primaryTouched\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"SecondaryButton\",\n                            \"expectedControlLayout\": \"Integer\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/secondaryButton\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"SecondaryTouch\",\n                            \"expectedControlLayout\": \"Integer\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/secondaryTouched\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"GripButton\",\n                            \"expectedControlLayout\": \"Integer\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/gripPressed\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"TriggerButton\",\n                            \"expectedControlLayout\": \"Integer\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/triggerPressed\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"TriggerTouch\",\n                            \"expectedControlLayout\": \"Integer\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/triggerTouched\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"MenuButton\",\n                            \"expectedControlLayout\": \"Integer\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/menu\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"Primary2DAxisClick\",\n                            \"expectedControlLayout\": \"Integer\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/thumbstickClicked\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"Primary2DAxisTouch\",\n                            \"expectedControlLayout\": \"Integer\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/thumbstickTouched\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"Thumbrest\",\n                            \"expectedControlLayout\": \"Integer\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/thumbrestTouched\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"Trigger\",\n                            \"expectedControlLayout\": \"Axis1D\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/trigger\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"Grip\",\n                            \"expectedControlLayout\": \"Axis1D\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/grip\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"Primary2DAxis\",\n                            \"expectedControlLayout\": \"Axis2D\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/thumbstick\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"Secondary2DAxis\",\n                            \"expectedControlLayout\": \"Axis2D\",\n                            \"bindings\": [\n                                {\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"RootPose\",\n                            \"expectedControlLayout\": \"Pose\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/devicePose\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"PointerPose\",\n                            \"expectedControlLayout\": \"Pose\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<XRController>{LeftHand}/pointer\"\n                                }\n                            ]\n                        }\n                    ]\n                }\n            ]}";

		[SerializeField]
		private InputActionMap _leftHandControllerBindings = InputActionMap.FromJson(ControllerActionMap).FirstOrDefault();

		[SerializeField]
		private InputActionMap _rightHandControllerBindings = InputActionMap.FromJson(ControllerActionMap.Replace("{LeftHand}", "{RightHand}")).FirstOrDefault();

		private readonly ControllerDataAsset _dataAsset = new ControllerDataAsset();

		private readonly ControllerDataSourceConfig _config = new ControllerDataSourceConfig();

		private static readonly Quaternion OpenXRToOVRLeftRotTipInverted = Quaternion.Inverse(Quaternion.AngleAxis(90f, Vector3.forward));

		private static readonly Quaternion OpenXRToOVRRightRotTipInverted = Quaternion.Inverse(Quaternion.AngleAxis(180f, Vector3.right) * Quaternion.AngleAxis(-90f, Vector3.forward));

		private static readonly Func<int> DefaultFrameCountProvider = () => Time.frameCount;

		private Func<int> _frameCountProvider = DefaultFrameCountProvider;

		private int _lastRequiredUpdate;

		protected override ControllerDataAsset DataAsset => _dataAsset;

		public void SetTimeFrameCountProvider(Func<int> frameCountProvider)
		{
			if (frameCountProvider == null)
			{
				frameCountProvider = DefaultFrameCountProvider;
			}
			_frameCountProvider = frameCountProvider;
		}

		private void Awake()
		{
			TrackingToWorldTransformer = _trackingToWorldTransformer as ITrackingToWorldTransformer;
			UpdateConfig();
			InputActionMap inputActionMap = ((_handedness == Handedness.Left) ? _leftHandControllerBindings : _rightHandControllerBindings);
			_dataAsset.IsDominantHand = _handedness != Handedness.Left;
			string[] names = Enum.GetNames(typeof(ControllerButtonUsage));
			foreach (string text in names)
			{
				if (!(text == ControllerButtonUsage.None.ToString()))
				{
					ControllerButtonUsage usage = Enum.Parse<ControllerButtonUsage>(text);
					inputActionMap[text].started += delegate
					{
						_dataAsset.Input.SetButton(usage, value: true);
					};
					inputActionMap[text].canceled += delegate
					{
						_dataAsset.Input.SetButton(usage, value: false);
					};
				}
			}
			names = Enum.GetNames(typeof(ControllerAxis1DUsage));
			foreach (string usageName in names)
			{
				if (!(usageName == ControllerAxis1DUsage.None.ToString()))
				{
					inputActionMap[usageName].performed += delegate(InputAction.CallbackContext context)
					{
						_dataAsset.Input.SetAxis1D(Enum.Parse<ControllerAxis1DUsage>(usageName), context.ReadValue<float>());
					};
					inputActionMap[usageName].canceled += delegate
					{
						_dataAsset.Input.SetAxis1D(Enum.Parse<ControllerAxis1DUsage>(usageName), 0f);
					};
				}
			}
			names = Enum.GetNames(typeof(ControllerAxis2DUsage));
			foreach (string usageName2 in names)
			{
				if (!(usageName2 == ControllerAxis2DUsage.None.ToString()))
				{
					inputActionMap[usageName2].performed += delegate(InputAction.CallbackContext context)
					{
						_dataAsset.Input.SetAxis2D(Enum.Parse<ControllerAxis2DUsage>(usageName2), context.ReadValue<Vector2>());
					};
					inputActionMap[usageName2].canceled += delegate
					{
						_dataAsset.Input.SetAxis2D(Enum.Parse<ControllerAxis2DUsage>(usageName2), Vector2.zero);
					};
				}
			}
			inputActionMap["RootPose"].performed += delegate(InputAction.CallbackContext context)
			{
				PoseState poseState = context.ReadValue<PoseState>();
				_dataAsset.RootPose = new Pose(poseState.position, poseState.rotation);
				_dataAsset.RootPose = FlipZ(_dataAsset.RootPose);
				_dataAsset.RootPose.rotation *= ((_dataAsset.Config.Handedness == Handedness.Left) ? OpenXRToOVRLeftRotTipInverted : OpenXRToOVRRightRotTipInverted);
				_dataAsset.RootPose = FlipZ(_dataAsset.RootPose);
				_dataAsset.RootPoseOrigin = PoseOrigin.RawTrackedPose;
				_dataAsset.IsTracked = poseState.trackingState.HasFlag(InputTrackingState.Position) && poseState.trackingState.HasFlag(InputTrackingState.Rotation);
				_dataAsset.IsDataValid = _dataAsset.IsTracked;
				_dataAsset.IsConnected = _dataAsset.IsTracked;
				int num = _frameCountProvider();
				if (_lastRequiredUpdate != num)
				{
					_lastRequiredUpdate = num;
					MarkInputDataRequiresUpdate();
				}
			};
			inputActionMap["RootPose"].canceled += delegate
			{
				_dataAsset.RootPoseOrigin = PoseOrigin.None;
			};
			inputActionMap["PointerPose"].performed += delegate(InputAction.CallbackContext context)
			{
				PoseState poseState = context.ReadValue<PoseState>();
				_dataAsset.PointerPose = new Pose(poseState.position, poseState.rotation);
				_dataAsset.PointerPoseOrigin = PoseOrigin.RawTrackedPose;
			};
			inputActionMap["PointerPose"].canceled += delegate
			{
				_dataAsset.PointerPoseOrigin = PoseOrigin.None;
			};
			inputActionMap.Enable();
		}

		private static Quaternion FlipZ(Quaternion q)
		{
			return new Quaternion
			{
				x = 0f - q.x,
				y = 0f - q.y,
				z = q.z,
				w = q.w
			};
		}

		public static Pose FlipZ(Pose p)
		{
			p.rotation = FlipZ(p.rotation);
			p.position = new Vector3
			{
				x = p.position.x,
				y = p.position.y,
				z = 0f - p.position.z
			};
			return p;
		}

		protected override void Start()
		{
			this.BeginStart(ref _started, delegate
			{
				base.Start();
			});
			UpdateConfig();
			this.EndStart(ref _started);
		}

		protected override void UpdateData()
		{
		}

		private void UpdateConfig()
		{
			_config.Handedness = _handedness;
			_config.TrackingToWorldTransformer = TrackingToWorldTransformer;
			_dataAsset.Config = _config;
		}

		public void InjectHandedness(Handedness handedness)
		{
			_handedness = handedness;
		}

		public void InjectTrackingToWorldTransformer(ITrackingToWorldTransformer trackingToWorldTransformer)
		{
			_trackingToWorldTransformer = trackingToWorldTransformer as UnityEngine.Object;
			TrackingToWorldTransformer = trackingToWorldTransformer;
		}
	}
	public class FromUnityXRHmdDataSource : DataSource<HmdDataAsset>
	{
		[Header("Shared Configuration")]
		[SerializeField]
		[Interface(typeof(ITrackingToWorldTransformer), new Type[] { })]
		private UnityEngine.Object _trackingToWorldTransformer;

		private ITrackingToWorldTransformer TrackingToWorldTransformer;

		private HmdDataAsset _hmdDataAsset = new HmdDataAsset();

		private HmdDataSourceConfig _config;

		[SerializeField]
		private XROrigin _origin;

		private HmdDataSourceConfig Config
		{
			get
			{
				if (_config != null)
				{
					return _config;
				}
				_config = new HmdDataSourceConfig
				{
					TrackingToWorldTransformer = TrackingToWorldTransformer
				};
				return _config;
			}
		}

		protected override HmdDataAsset DataAsset => _hmdDataAsset;

		protected void Awake()
		{
			TrackingToWorldTransformer = _trackingToWorldTransformer as ITrackingToWorldTransformer;
		}

		protected override void Start()
		{
			this.BeginStart(ref _started, delegate
			{
				base.Start();
			});
			this.EndStart(ref _started);
		}

		protected override void UpdateData()
		{
			_hmdDataAsset.Config = Config;
			_hmdDataAsset.Root = _origin.Camera.transform.GetLocalPose();
			_hmdDataAsset.IsTracked = XRSettings.isDeviceActive;
			_hmdDataAsset.FrameId = Time.frameCount;
		}

		public void InjectAllFromOVRHmdDataSource(UpdateModeFlags updateMode, IDataSource updateAfter, bool useOvrManagerEmulatedPose, ITrackingToWorldTransformer trackingToWorldTransformer)
		{
			InjectAllDataSource(updateMode, updateAfter);
			InjectTrackingToWorldTransformer(trackingToWorldTransformer);
		}

		public void InjectTrackingToWorldTransformer(ITrackingToWorldTransformer trackingToWorldTransformer)
		{
			_trackingToWorldTransformer = trackingToWorldTransformer as UnityEngine.Object;
			TrackingToWorldTransformer = trackingToWorldTransformer;
		}
	}
}
namespace Oculus.Interaction.Input
{
	public class DefaultHandSkeletonProvider : MonoBehaviour, IHandSkeletonProvider
	{
		private readonly HandSkeleton[] _skeletons = new HandSkeleton[2]
		{
			HandSkeleton.DefaultLeftSkeleton,
			HandSkeleton.DefaultRightSkeleton
		};

		public HandSkeleton this[Handedness handedness] => _skeletons[(int)handedness];
	}
}
namespace Oculus.Interaction.Input.UnityXR
{
	public abstract class FromOpenXRHandDataSource : DataSource<HandDataAsset>
	{
		private static readonly float DefaultSkeletonIndexMagnitude = HandSkeleton.DefaultLeftSkeleton[8].pose.position.magnitude;

		private const float PressThreshold = 0.8f;

		private static readonly Vector3 TrackedRemoteAimOffset = new Vector3(0f, 0f, -0.055f);

		[SerializeField]
		[Interface(typeof(IHmd), new Type[] { })]
		private UnityEngine.Object _hmdData;

		private IHmd HmdData;

		protected readonly HandDataAsset _dataAsset = new HandDataAsset();

		protected bool _shouldMockHandTrackingAim;

		private PinchGrabAPI _fingerGrabAPI;

		protected override HandDataAsset DataAsset => _dataAsset;

		protected virtual void Awake()
		{
			HmdData = _hmdData as IHmd;
		}

		protected override void Start()
		{
			this.BeginStart(ref _started, delegate
			{
				base.Start();
			});
			this.EndStart(ref _started);
		}

		protected override void UpdateData()
		{
			for (int i = 0; i < 26; i++)
			{
				int num = (int)HandJointUtils.JointParentList[i];
				_dataAsset.Joints[i] = ((num < 0) ? Quaternion.identity : (Quaternion.Inverse(_dataAsset.JointPoses[num].rotation) * _dataAsset.JointPoses[i].rotation));
			}
			UpdateHandScale(_dataAsset.JointPoses[7].position, _dataAsset.JointPoses[8].position);
			if (_dataAsset.IsDataValidAndConnected && _shouldMockHandTrackingAim)
			{
				PopulateMockHandTrackingAim(_dataAsset.JointPoses[0]);
			}
		}

		private void UpdateHandScale(Vector3 indexProximal, Vector3 indexIntermediate)
		{
			float num = Vector3.Distance(indexProximal, indexIntermediate);
			_dataAsset.HandScale = num / DefaultSkeletonIndexMagnitude;
			float num2 = 1f / _dataAsset.HandScale;
			for (int i = 0; i < 26; i++)
			{
				_dataAsset.JointPoses[i].position *= num2;
			}
		}

		private void PopulateMockHandTrackingAim(Pose xrPalmPose)
		{
			_dataAsset.PointerPose = xrPalmPose.GetTransformedBy(new Pose(TrackedRemoteAimOffset, Quaternion.identity));
			_dataAsset.PointerPoseOrigin = PoseOrigin.SyntheticPose;
			_dataAsset.IsDominantHand = _dataAsset.Config.Handedness == Handedness.Right;
			Pose[] jointPoses = _dataAsset.JointPoses;
			if (_fingerGrabAPI == null)
			{
				_fingerGrabAPI = new PinchGrabAPI(HmdData);
			}
			_fingerGrabAPI.Update(jointPoses, _dataAsset.Config.Handedness, _dataAsset.Root, _dataAsset.HandScale);
			PopulateMockHandTrackingAimFinger(HandFinger.Index);
			PopulateMockHandTrackingAimFinger(HandFinger.Middle);
			PopulateMockHandTrackingAimFinger(HandFinger.Ring);
			PopulateMockHandTrackingAimFinger(HandFinger.Pinky);
		}

		private void PopulateMockHandTrackingAimFinger(HandFinger finger)
		{
			_dataAsset.FingerPinchStrength[(int)finger] = _fingerGrabAPI.GetFingerGrabScore(finger);
			_dataAsset.IsFingerPinching[(int)finger] = _dataAsset.FingerPinchStrength[(int)finger] > 0.8f;
		}
	}
	public class FromUnityXRHandDataSource : FromOpenXRHandDataSource
	{
		[Header("Shared Configuration")]
		[SerializeField]
		private Handedness _handedness;

		[SerializeField]
		[Interface(typeof(ITrackingToWorldTransformer), new Type[] { })]
		private UnityEngine.Object _trackingToWorldTransformer;

		private ITrackingToWorldTransformer TrackingToWorldTransformer;

		private static string _metaAimHandActionMap = "{\n            \"maps\": [\n                {\n                    \"name\": \"MetaAimHand\",\n                    \"actions\": [\n                        {\n                            \"name\": \"aimFlags\",\n                            \"expectedControlLayout\": \"Integer\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<MetaAimHand>{LeftHand}/aimFlags\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"pinchStrengthIndex\",\n                            \"expectedControlLayout\": \"Axis\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<MetaAimHand>{LeftHand}/pinchStrengthIndex\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"pinchStrengthMiddle\",\n                            \"expectedControlLayout\": \"Axis\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<MetaAimHand>{LeftHand}/pinchStrengthMiddle\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"pinchStrengthRing\",\n                            \"expectedControlLayout\": \"Axis\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<MetaAimHand>{LeftHand}/pinchStrengthRing\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"pinchStrengthLittle\",\n                            \"expectedControlLayout\": \"Axis\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<MetaAimHand>{LeftHand}/pinchStrengthLittle\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"devicePosition\",\n                            \"expectedControlLayout\": \"Vector3\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<MetaAimHand>{LeftHand}/devicePosition\"\n                                }\n                            ]\n                        },\n                        {\n                            \"name\": \"deviceRotation\",\n                            \"expectedControlLayout\": \"Quaternion\",\n                            \"bindings\": [\n                                {\n                                    \"path\":\"<MetaAimHand>{LeftHand}/deviceRotation\"\n                                }\n                            ]\n                        }\n                    ]\n                }\n            ]}";

		[SerializeField]
		private InputActionMap _metaAimHandBindingsLeft = InputActionMap.FromJson(_metaAimHandActionMap).FirstOrDefault();

		[SerializeField]
		private InputActionMap _metaAimHandBindingsRight = InputActionMap.FromJson(_metaAimHandActionMap.Replace("{LeftHand}", "{RightHand}")).FirstOrDefault();

		private HandDataSourceConfig _config;

		private InputAction _metaAimFlags;

		private InputAction _pinchStrengthIndex;

		private InputAction _pinchStrengthMiddle;

		private InputAction _pinchStrengthRing;

		private InputAction _pinchStrengthLittle;

		private InputAction _devicePosition;

		private InputAction _deviceRotation;

		private InputActionMap MetaAimHandBindings
		{
			get
			{
				if (_handedness != Handedness.Left)
				{
					return _metaAimHandBindingsRight;
				}
				return _metaAimHandBindingsLeft;
			}
		}

		private HandDataSourceConfig Config
		{
			get
			{
				if (_config != null)
				{
					return _config;
				}
				_config = new HandDataSourceConfig
				{
					Handedness = _handedness
				};
				return _config;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			TrackingToWorldTransformer = _trackingToWorldTransformer as ITrackingToWorldTransformer;
			UpdateConfig();
		}

		protected override void Start()
		{
			base.Start();
			this.BeginStart(ref _started, delegate
			{
				base.Start();
			});
			UpdateConfig();
			InputActionMap metaAimHandBindings = MetaAimHandBindings;
			_metaAimFlags = metaAimHandBindings["aimFlags"];
			_pinchStrengthIndex = metaAimHandBindings["pinchStrengthIndex"];
			_pinchStrengthMiddle = metaAimHandBindings["pinchStrengthMiddle"];
			_pinchStrengthRing = metaAimHandBindings["pinchStrengthRing"];
			_pinchStrengthLittle = metaAimHandBindings["pinchStrengthLittle"];
			_devicePosition = metaAimHandBindings["devicePosition"];
			_deviceRotation = metaAimHandBindings["deviceRotation"];
			this.EndStart(ref _started);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			MetaAimHandBindings.Enable();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			MetaAimHandBindings.Disable();
		}

		private void UpdateConfig()
		{
			Config.TrackingToWorldTransformer = TrackingToWorldTransformer;
			Config.HandSkeleton = ((_handedness == Handedness.Left) ? HandSkeleton.DefaultLeftSkeleton : HandSkeleton.DefaultRightSkeleton);
			_dataAsset.Config = Config;
		}

		public void InjectTrackingToWorldTransformer(ITrackingToWorldTransformer trackingToWorldTransformer)
		{
			_trackingToWorldTransformer = trackingToWorldTransformer as UnityEngine.Object;
			TrackingToWorldTransformer = trackingToWorldTransformer;
			UpdateConfig();
		}
	}
}
