using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction.Input;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
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
			FilePathsData = new byte[945]
			{
				0, 0, 0, 1, 0, 0, 0, 93, 92, 80,
				97, 99, 107, 97, 103, 101, 115, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 105, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 46, 111, 118, 114, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 97,
				109, 112, 108, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 77, 101, 110, 117, 92, 73, 83,
				68, 75, 83, 99, 101, 110, 101, 77, 101, 110,
				117, 77, 97, 110, 97, 103, 101, 114, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 88, 92,
				80, 97, 99, 107, 97, 103, 101, 115, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 111, 118, 114,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				97, 109, 112, 108, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 77, 101, 110, 117, 92, 77,
				101, 110, 117, 87, 114, 105, 115, 116, 66, 117,
				116, 116, 111, 110, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 87, 92, 80, 97, 99, 107,
				97, 103, 101, 115, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 105, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 46, 111, 118, 114, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 83, 97, 109, 112, 108,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				77, 101, 110, 117, 92, 86, 101, 114, 115, 105,
				111, 110, 84, 101, 120, 116, 71, 85, 73, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 117,
				92, 80, 97, 99, 107, 97, 103, 101, 115, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 105, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 46, 111, 118,
				114, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				83, 97, 109, 112, 108, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 77, 117, 108, 116, 105,
				77, 111, 100, 97, 108, 92, 69, 110, 97, 98,
				108, 101, 79, 86, 82, 67, 111, 110, 99, 117,
				114, 114, 101, 110, 116, 72, 97, 110, 100, 115,
				65, 110, 100, 67, 111, 110, 116, 114, 111, 108,
				108, 101, 114, 115, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 93, 92, 80, 97, 99, 107,
				97, 103, 101, 115, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 105, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 46, 111, 118, 114, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 83, 97, 109, 112, 108,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				77, 117, 108, 116, 105, 77, 111, 100, 97, 108,
				92, 80, 105, 110, 103, 80, 111, 110, 103, 80,
				97, 100, 100, 108, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 88, 92, 80, 97, 99,
				107, 97, 103, 101, 115, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 105, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 111, 118, 114, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 83, 97, 109, 112,
				108, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 77, 117, 108, 116, 105, 77, 111, 100, 97,
				108, 92, 83, 108, 105, 110, 103, 115, 104, 111,
				116, 46, 99, 115, 0, 0, 0, 2, 0, 0,
				0, 93, 92, 80, 97, 99, 107, 97, 103, 101,
				115, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 105, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				111, 118, 114, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 83, 97, 109, 112, 108, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 80, 97, 115,
				115, 84, 104, 114, 111, 117, 103, 104, 92, 77,
				82, 80, 97, 115, 115, 116, 104, 114, 111, 117,
				103, 104, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 106, 92, 80, 97, 99, 107, 97, 103,
				101, 115, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 105,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				46, 111, 118, 114, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 83, 97, 109, 112, 108, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 80, 97,
				115, 115, 84, 104, 114, 111, 117, 103, 104, 92,
				77, 82, 80, 97, 115, 115, 84, 104, 114, 111,
				117, 103, 104, 72, 97, 110, 100, 86, 105, 115,
				117, 97, 108, 105, 122, 101, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 108, 92, 80, 97,
				99, 107, 97, 103, 101, 115, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 105, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 111, 118, 114, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 97, 109,
				112, 108, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 80, 97, 115, 115, 84, 104, 114, 111,
				117, 103, 104, 92, 77, 82, 80, 97, 115, 115,
				84, 104, 114, 111, 117, 103, 104, 77, 97, 116,
				101, 114, 105, 97, 108, 67, 104, 97, 110, 103,
				101, 114, 46, 99, 115
			},
			TypesData = new byte[514]
			{
				0, 0, 0, 0, 47, 79, 99, 117, 108, 117,
				115, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 83, 97, 109, 112, 108, 101,
				115, 124, 73, 83, 68, 75, 83, 99, 101, 110,
				101, 77, 101, 110, 117, 77, 97, 110, 97, 103,
				101, 114, 0, 0, 0, 0, 42, 79, 99, 117,
				108, 117, 115, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 46, 83, 97, 109, 112,
				108, 101, 115, 124, 77, 101, 110, 117, 87, 114,
				105, 115, 116, 66, 117, 116, 116, 111, 110, 0,
				0, 0, 0, 33, 79, 99, 117, 108, 117, 115,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 124, 86, 101, 114, 115, 105, 111, 110,
				84, 101, 120, 116, 71, 85, 73, 0, 0, 0,
				0, 65, 79, 99, 117, 108, 117, 115, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				46, 83, 97, 109, 112, 108, 101, 115, 124, 69,
				110, 97, 98, 108, 101, 79, 86, 82, 67, 111,
				110, 99, 117, 114, 114, 101, 110, 116, 72, 97,
				110, 100, 115, 65, 110, 100, 67, 111, 110, 116,
				114, 111, 108, 108, 101, 114, 115, 0, 0, 0,
				0, 41, 79, 99, 117, 108, 117, 115, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				46, 83, 97, 109, 112, 108, 101, 115, 124, 80,
				105, 110, 103, 80, 111, 110, 103, 80, 97, 100,
				100, 108, 101, 0, 0, 0, 0, 36, 79, 99,
				117, 108, 117, 115, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 83, 97, 109,
				112, 108, 101, 115, 124, 83, 108, 105, 110, 103,
				115, 104, 111, 116, 0, 0, 0, 0, 40, 79,
				99, 117, 108, 117, 115, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 46, 83, 97,
				109, 112, 108, 101, 115, 124, 77, 82, 80, 97,
				115, 115, 116, 104, 114, 111, 117, 103, 104, 0,
				0, 0, 0, 52, 79, 99, 117, 108, 117, 115,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 46, 83, 97, 109, 112, 108, 101, 115,
				46, 77, 82, 80, 97, 115, 115, 116, 104, 114,
				111, 117, 103, 104, 124, 80, 97, 115, 115, 84,
				104, 114, 111, 117, 103, 104, 0, 0, 0, 0,
				53, 79, 99, 117, 108, 117, 115, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				83, 97, 109, 112, 108, 101, 115, 124, 77, 82,
				80, 97, 115, 115, 84, 104, 114, 111, 117, 103,
				104, 72, 97, 110, 100, 86, 105, 115, 117, 97,
				108, 105, 122, 101, 0, 0, 0, 0, 55, 79,
				99, 117, 108, 117, 115, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 46, 83, 97,
				109, 112, 108, 101, 115, 124, 77, 82, 80, 97,
				115, 115, 84, 104, 114, 111, 117, 103, 104, 77,
				97, 116, 101, 114, 105, 97, 108, 67, 104, 97,
				110, 103, 101, 114
			},
			TotalFiles = 9,
			TotalTypes = 10,
			IsEditorOnly = false
		};
	}
}
namespace Oculus.Interaction
{
	[Obsolete("Use VersionTextVisual instead")]
	public class VersionTextGUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _text;

		protected bool _started;

		protected virtual void Reset()
		{
			_text = GetComponent<TextMeshProUGUI>();
		}

		protected virtual void Start()
		{
			_text.text = "Version: " + Application.version;
		}

		public void InjectAllVersionTextGuiVisual(TextMeshProUGUI text)
		{
			InjectTextUI(text);
		}

		public void InjectTextUI(TextMeshProUGUI text)
		{
			_text = text;
		}
	}
}
namespace Oculus.Interaction.Samples
{
	public class ISDKSceneMenuManager : MonoBehaviour
	{
		[Tooltip("The parent object of the menu")]
		[Header("Place the grabbable parent object here")]
		[SerializeField]
		private GameObject _menuParent;

		[Tooltip("The audio to play when showing the menu panel")]
		[Header("Place the menu open audio here")]
		[SerializeField]
		private AudioSource _showMenuAudio;

		[Tooltip("The audio to play when hiding the menu panel")]
		[Header("Place the menu hide audio here")]
		[SerializeField]
		private AudioSource _hideMenuAudio;

		[Tooltip("The location the menu should be spawning at")]
		[Header("The location the menu should be spawning at")]
		[SerializeField]
		private GameObject _spawnPoint;

		protected bool _started;

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			this.EndStart(ref _started);
		}

		public void ToggleMenu()
		{
			if (_menuParent.activeSelf)
			{
				_hideMenuAudio.Play();
				_menuParent.SetActive(value: false);
				return;
			}
			_showMenuAudio.Play();
			_menuParent.transform.position = _spawnPoint.transform.position;
			_menuParent.transform.rotation = _spawnPoint.transform.rotation;
			_menuParent.SetActive(value: true);
		}

		public void InjectAllMenuItems(GameObject parent, AudioSource show, AudioSource hide, GameObject spawnpoint)
		{
			InjectMenuParent(parent);
			InjectShowAudio(show);
			InjectHideAudio(hide);
			InjectSpawnPoint(spawnpoint);
		}

		public void InjectMenuParent(GameObject parent)
		{
			_menuParent = parent;
		}

		public void InjectShowAudio(AudioSource show)
		{
			_showMenuAudio = show;
		}

		public void InjectHideAudio(AudioSource hide)
		{
			_showMenuAudio = hide;
		}

		public void InjectSpawnPoint(GameObject spawnpoint)
		{
			_menuParent = spawnpoint;
		}
	}
	public class MenuWristButton : MonoBehaviour
	{
		[Header("The Toggle Button")]
		[Tooltip("Place the toggle on the wrist here")]
		[SerializeField]
		private Toggle _toggle;

		[Header("The Menu Manager")]
		[Tooltip("There should only be 1 ISDK manager in the scene loacted on the ISDKMenuManager.prefab")]
		[SerializeField]
		private ISDKSceneMenuManager _menuManager;

		protected bool _started;

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			this.EndStart(ref _started);
		}

		protected virtual void OnEnable()
		{
			if (_started)
			{
				_toggle.onValueChanged.AddListener(OnToggleValueChanged);
			}
		}

		private void OnToggleValueChanged(bool value)
		{
			_menuManager.ToggleMenu();
		}

		protected virtual void OnDisable()
		{
			if (_started)
			{
				_toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
			}
		}

		public void InjectAllMenuWrist(Toggle toggle, ISDKSceneMenuManager manager)
		{
			InjectToggle(toggle);
			InjectManager(manager);
		}

		public void InjectToggle(Toggle toggle)
		{
			_toggle = toggle;
		}

		public void InjectManager(ISDKSceneMenuManager manager)
		{
			_menuManager = manager;
		}
	}
	public class EnableOVRConcurrentHandsAndControllers : MonoBehaviour
	{
		private void OnEnable()
		{
			if (OVRPlugin.SetSimultaneousHandsAndControllersEnabled(enabled: true))
			{
				UnityEngine.Debug.Log("Concurrent hands and controllers mode succesfully set.");
			}
			else
			{
				UnityEngine.Debug.LogWarning("Concurrent Hands and controllers not supported.");
			}
		}

		private void OnDisable()
		{
			if (OVRPlugin.SetSimultaneousHandsAndControllersEnabled(enabled: false))
			{
				UnityEngine.Debug.Log("Concurrent hands and controllers mode succesfully unset.");
			}
			else
			{
				UnityEngine.Debug.LogWarning("Concurrent Hands and controllers not supported.");
			}
		}
	}
	public class PingPongPaddle : MonoBehaviour, ITransformer
	{
		[SerializeField]
		private HandGrabInteractable _leftHandGrabInteractable;

		[SerializeField]
		private HandGrabInteractable _rightHandGrabInteractable;

		[SerializeField]
		private Rigidbody _rigidbody;

		[SerializeField]
		private AnimationCurve _collisionStrength;

		private const float _timeBetweenCollisions = 0.1f;

		private WaitForSeconds _hapticsWait = new WaitForSeconds(0.1f);

		private AudioPhysics.CollisionEvents _collisionEvents;

		private float _timeAtLastCollision;

		protected bool _started;

		private OVRInput.Controller _activeController;

		private IGrabbable _grabbable;

		private Pose _grabDeltaInLocalSpace;

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			_collisionEvents = _rigidbody.gameObject.AddComponent<AudioPhysics.CollisionEvents>();
			this.EndStart(ref _started);
		}

		protected virtual void OnEnable()
		{
			if (_started)
			{
				_collisionEvents.WhenCollisionEnter += HandleCollisionEnter;
				_leftHandGrabInteractable.WhenStateChanged += HandleLeftHandGrabInteractableStateChanged;
				_rightHandGrabInteractable.WhenStateChanged += HandleRightHandGrabInteractableStateChanged;
			}
		}

		protected virtual void OnDisable()
		{
			if (_started)
			{
				_collisionEvents.WhenCollisionEnter -= HandleCollisionEnter;
				_leftHandGrabInteractable.WhenStateChanged -= HandleLeftHandGrabInteractableStateChanged;
				_rightHandGrabInteractable.WhenStateChanged -= HandleRightHandGrabInteractableStateChanged;
			}
		}

		private void HandleLeftHandGrabInteractableStateChanged(InteractableStateChangeArgs stateChange)
		{
			if (stateChange.NewState == InteractableState.Select)
			{
				_activeController |= OVRInput.Controller.LTouch;
			}
			else if (stateChange.PreviousState == InteractableState.Select)
			{
				_activeController &= ~OVRInput.Controller.LTouch;
			}
		}

		private void HandleRightHandGrabInteractableStateChanged(InteractableStateChangeArgs stateChange)
		{
			if (stateChange.NewState == InteractableState.Select)
			{
				_activeController |= OVRInput.Controller.RTouch;
			}
			else if (stateChange.PreviousState == InteractableState.Select)
			{
				_activeController &= ~OVRInput.Controller.RTouch;
			}
		}

		private void HandleCollisionEnter(Collision collision)
		{
			TryPlayCollisionAudio(collision);
		}

		private void TryPlayCollisionAudio(Collision collision)
		{
			float sqrMagnitude = collision.relativeVelocity.sqrMagnitude;
			if (!(collision.collider.gameObject == null))
			{
				float num = Time.time - _timeAtLastCollision;
				if (!(0.1f > num))
				{
					_timeAtLastCollision = Time.time;
					PlayCollisionHaptics(sqrMagnitude);
				}
			}
		}

		private void PlayCollisionHaptics(float strength)
		{
			float pitch = _collisionStrength.Evaluate(strength);
			StartCoroutine(HapticsRoutine(pitch, _activeController));
		}

		private IEnumerator HapticsRoutine(float pitch, OVRInput.Controller controller)
		{
			OVRInput.SetControllerVibration(pitch * 0.5f, pitch * 0.2f, controller);
			yield return _hapticsWait;
			OVRInput.SetControllerVibration(0f, 0f, controller);
		}

		public void Initialize(IGrabbable grabbable)
		{
			_grabbable = grabbable;
		}

		public void BeginTransform()
		{
			Pose pose = _grabbable.GrabPoints[0];
			Transform transform = _rigidbody.transform;
			_grabDeltaInLocalSpace = new Pose(transform.InverseTransformVector(pose.position - transform.position), Quaternion.Inverse(pose.rotation) * transform.rotation);
		}

		public void UpdateTransform()
		{
			Pose pose = _grabbable.GrabPoints[0];
			_rigidbody.MoveRotation(pose.rotation * _grabDeltaInLocalSpace.rotation);
			_rigidbody.MovePosition(pose.position - _rigidbody.transform.TransformVector(_grabDeltaInLocalSpace.position));
		}

		public void EndTransform()
		{
		}
	}
	public class Slingshot : MonoBehaviour, ITransformer
	{
		[SerializeField]
		private Pose _neutralPose;

		[SerializeField]
		private Transform _holder;

		[SerializeField]
		private Transform _leftRubberPoint;

		[SerializeField]
		private Transform _rightRubberPoint;

		[SerializeField]
		private float _rubberAngle = 60f;

		[SerializeField]
		private AnimationCurve _translationResistance;

		[SerializeField]
		private AnimationCurve _aimingResistance;

		[SerializeField]
		private float _springForce = 0.1f;

		[SerializeField]
		private float _damping = 0.95f;

		[SerializeField]
		private float _slingshotStrength = 10f;

		[SerializeField]
		private HandGrabInteractable[] _handGrabInteractables;

		[Header("Feedback")]
		[SerializeField]
		private AudioSource _audioSource;

		[SerializeField]
		private AudioClip _stretchAudioClip;

		[SerializeField]
		private AnimationCurve _strecthAudioPitch;

		[SerializeField]
		private AnimationCurve _stretchAudioStep;

		private IGrabbable _grabbable;

		private Pose _grabDeltaInLocalSpace;

		private bool _isGrabbed;

		private Vector3 _positionVelocity = Vector3.zero;

		private float _rotationVelocity;

		private SlingshotPellet _loadedPellet;

		private WaitForSeconds _hapticsWait = new WaitForSeconds(0.05f);

		private float _lastTensionStep;

		private float _lastTensionTime;

		private const float _tensionStepLength = 0.1f;

		private void OnTriggerEnter(Collider other)
		{
			if (!(_loadedPellet != null) && other.TryGetComponent<SlingshotPellet>(out var component))
			{
				HandlePelletSnapped(component);
			}
		}

		private void HandlePelletSnapped(SlingshotPellet pellet)
		{
			HandGrabInteractor handGrabber = pellet.HandGrabber;
			if (handGrabber == null || handGrabber.State != InteractorState.Select)
			{
				return;
			}
			HandGrabInteractable[] handGrabInteractables = _handGrabInteractables;
			foreach (HandGrabInteractable handGrabInteractable in handGrabInteractables)
			{
				if (handGrabber.CanInteractWith(handGrabInteractable))
				{
					handGrabber.ForceRelease();
					handGrabber.ForceSelect(handGrabInteractable, allowManualRelease: true);
					_loadedPellet = pellet;
					_loadedPellet.Attach();
					break;
				}
			}
		}

		public void Initialize(IGrabbable grabbable)
		{
			_grabbable = grabbable;
		}

		public void BeginTransform()
		{
			Pose pose = _grabbable.GrabPoints[0];
			Transform transform = _grabbable.Transform;
			_grabDeltaInLocalSpace = new Pose(transform.InverseTransformVector(pose.position - transform.position), Quaternion.Inverse(pose.rotation) * transform.rotation);
			_isGrabbed = true;
			_positionVelocity = Vector3.zero;
			_rotationVelocity = 0f;
			CurveHolder(_rubberAngle);
		}

		public void UpdateTransform()
		{
			Pose pose = _grabbable.GrabPoints[0];
			Transform transform = _grabbable.Transform;
			Vector3 localPosition = transform.localPosition;
			Vector3 position = pose.position - transform.TransformVector(_grabDeltaInLocalSpace.position);
			Quaternion rotation = pose.rotation * _grabDeltaInLocalSpace.rotation;
			Pose pose2 = transform.parent.Delta(new Pose(position, rotation));
			Vector3 vector = pose2.position - _neutralPose.position;
			float num = Vector3.Distance(localPosition, _neutralPose.position);
			float num2 = vector.magnitude;
			if (num2 > num)
			{
				float maxDelta = _translationResistance.Evaluate(num) * Time.deltaTime;
				num2 = Mathf.MoveTowards(num, num2, maxDelta);
			}
			Vector3 normalized = Vector3.ProjectOnPlane(vector, Vector3.right).normalized;
			vector = Vector3.Slerp(vector, normalized, _aimingResistance.Evaluate(num)).normalized;
			Vector3 localPoint = (transform.localPosition = _neutralPose.position + vector * num2);
			num = Tension(localPoint);
			float t = _aimingResistance.Evaluate(num);
			Quaternion b = Quaternion.LookRotation(-vector, pose2.up);
			transform.localRotation = Quaternion.SlerpUnclamped(pose2.rotation, b, t);
			OnStretch(num);
		}

		public void EndTransform()
		{
			_isGrabbed = false;
			if (_loadedPellet != null)
			{
				Vector3 force = SlingshotLaunchForce();
				_loadedPellet.Eject(force);
				_loadedPellet = null;
			}
			CurveHolder(0f);
		}

		private void Update()
		{
			if (!_isGrabbed)
			{
				Transform transform = base.transform;
				Vector3 vector = (_neutralPose.position - transform.localPosition) * _springForce;
				_positionVelocity = _positionVelocity * _damping + vector * Time.deltaTime;
				transform.localPosition += _positionVelocity;
				transform.localRotation.ToAngleAxis(out var angle, out var axis);
				if (angle > 180f)
				{
					angle -= 360f;
				}
				_rotationVelocity = _rotationVelocity * _damping + angle * _springForce * Time.deltaTime;
				transform.localRotation = Quaternion.AngleAxis(_rotationVelocity, -axis.normalized) * transform.localRotation;
			}
		}

		private void LateUpdate()
		{
			if (_loadedPellet != null)
			{
				_loadedPellet.Move(_holder);
			}
		}

		private void CurveHolder(float angle)
		{
			_rightRubberPoint.localEulerAngles = Vector3.up * angle;
			_leftRubberPoint.localEulerAngles = -Vector3.up * angle;
		}

		private float Tension(Vector3 localPoint)
		{
			return Vector3.Distance(localPoint, _neutralPose.position);
		}

		private Vector3 SlingshotLaunchForce()
		{
			Transform transform = _grabbable.Transform;
			float num = Tension(transform.localPosition);
			return (transform.parent.position - transform.position).normalized * num * _slingshotStrength;
		}

		public void OnStretch(float currentTension)
		{
			if (Mathf.Abs(_lastTensionStep - currentTension) > _stretchAudioStep.Evaluate(currentTension) && Time.unscaledTime - _lastTensionTime > 0.1f)
			{
				PlayStretchAudio(currentTension);
				PlayStretchHaptics(currentTension);
				_lastTensionStep = currentTension;
				_lastTensionTime = Time.unscaledTime;
			}
		}

		private void PlayStretchAudio(float tension)
		{
			float pitch = _strecthAudioPitch.Evaluate(tension);
			_audioSource.pitch = pitch;
			_audioSource.PlayOneShot(_stretchAudioClip, 1f);
		}

		private void PlayStretchHaptics(float tension)
		{
			float pitch = _strecthAudioPitch.Evaluate(tension);
			StartCoroutine(HapticsRoutine(pitch));
		}

		private IEnumerator HapticsRoutine(float pitch)
		{
			OVRInput.Controller controllers = OVRInput.Controller.Touch;
			OVRInput.SetControllerVibration(pitch * 0.5f, pitch * 0.2f, controllers);
			yield return _hapticsWait;
			OVRInput.SetControllerVibration(0f, 0f, controllers);
		}
	}
	public class MRPassthrough : MonoBehaviour
	{
		public static class PassThrough
		{
			public static bool IsPassThroughOn;

			public static bool IsPassThroughCompatible;
		}

		[Tooltip("Objects that shouldn't be rendered during passthrough")]
		[Header("Passthrough Objects To Remove")]
		[SerializeField]
		private GameObject[] _objects;

		[Tooltip("These are UI objects that should be toggled ON/OFF during passthrough button")]
		[SerializeField]
		private Toggle _passThroughToggle;

		[Tooltip("The OVRPassthrough Layer")]
		[SerializeField]
		private OVRPassthroughLayer _layer;

		[Tooltip("Use the CenterEyeAnchor or Center Camera")]
		[SerializeField]
		private Camera _camera;

		protected bool _started;

		protected virtual void Reset()
		{
			_layer = UnityEngine.Object.FindFirstObjectByType<OVRPassthroughLayer>();
			_camera = OVRManager.FindMainCamera();
		}

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			this.EndStart(ref _started);
		}

		protected virtual void OnEnable()
		{
			if (_started)
			{
				ValidatePassthrough();
			}
		}

		private void ValidatePassthrough()
		{
			if (OVRManager.HasInsightPassthroughInitFailed())
			{
				_camera.clearFlags = CameraClearFlags.Skybox;
				_passThroughToggle.enabled = false;
				return;
			}
			if (PassThrough.IsPassThroughOn)
			{
				TurnPassThroughOn();
				return;
			}
			TurnPassThroughOff();
			if (PassThrough.IsPassThroughCompatible)
			{
				_passThroughToggle.enabled = false;
			}
			else
			{
				_passThroughToggle.enabled = true;
			}
		}

		[Obsolete]
		public void TurnLocoMotionSceneOn()
		{
			PassThrough.IsPassThroughCompatible = true;
		}

		[Obsolete]
		public void TurnLocoMotionSceneOff()
		{
			PassThrough.IsPassThroughCompatible = false;
		}

		public void TogglePassThrough()
		{
			if (PassThrough.IsPassThroughOn)
			{
				TurnPassThroughOff();
			}
			else
			{
				TurnPassThroughOn();
			}
		}

		public void CheckPassthroughToggle()
		{
			if (_passThroughToggle.enabled && PassThrough.IsPassThroughOn)
			{
				_passThroughToggle.isOn = true;
				TurnPassThroughOn();
			}
		}

		private void TurnPassThroughOn()
		{
			if (OVRManager.IsInsightPassthroughInitialized())
			{
				PassThrough.IsPassThroughOn = true;
				_layer.textureOpacity = 1f;
				_camera.clearFlags = CameraClearFlags.Color;
				GameObject[] objects = _objects;
				for (int i = 0; i < objects.Length; i++)
				{
					objects[i].SetActive(value: false);
				}
			}
			else
			{
				UnityEngine.Debug.LogError("Failed to initialize Passthrough please check the OVRManager in the Hierarchy and check if Passthrough is supported and enabled.");
			}
		}

		private void TurnPassThroughOff()
		{
			PassThrough.IsPassThroughOn = false;
			_layer.textureOpacity = 0f;
			_camera.clearFlags = CameraClearFlags.Skybox;
			GameObject[] objects = _objects;
			for (int i = 0; i < objects.Length; i++)
			{
				objects[i].SetActive(value: true);
			}
		}

		public void InjectAllMRPassthrough(GameObject[] objects, Toggle passThroughToggle, OVRPassthroughLayer layer, Camera camera)
		{
			InjectObjects(objects);
			InjectPassThroughToggle(passThroughToggle);
			InjectLayer(layer);
			InjectCamera(camera);
		}

		public void InjectObjects(GameObject[] objects)
		{
			_objects = objects;
		}

		public void InjectPassThroughToggle(Toggle passThroughToggle)
		{
			_passThroughToggle = passThroughToggle;
		}

		public void InjectLayer(OVRPassthroughLayer layer)
		{
			_layer = layer;
		}

		public void InjectCamera(Camera camera)
		{
			_camera = camera;
		}
	}
	public class MRPassThroughHandVisualize : MonoBehaviour
	{
		[SerializeField]
		private List<Transform> _eyeAnchors;

		[SerializeField]
		private HandVisual _handVisual;

		[Header("Raycast Properties")]
		[SerializeField]
		private LayerMask _layer;

		[SerializeField]
		private float _sphereRadius;

		[SerializeField]
		private float _castDistance;

		[Header("Material Properties")]
		[SerializeField]
		private MaterialPropertyBlockEditor[] _handMaterialPropertyBlocks;

		[SerializeField]
		private float _opacity;

		[SerializeField]
		private float _outlineOpacity;

		[SerializeField]
		private float _animationSpeed;

		private float _currentOpacity;

		private float _currentOutlineOpacity;

		private readonly int _opacityId = Shader.PropertyToID("_Opacity");

		private readonly int _outlineOpacityId = Shader.PropertyToID("_OutlineOpacity");

		private (Vector3, float) _palmTarget;

		private readonly HandJointId[] _handJointTargets = new HandJointId[10]
		{
			HandJointId.HandIndex2,
			HandJointId.HandIndex3,
			HandJointId.HandThumb2,
			HandJointId.HandThumb3,
			HandJointId.HandMiddle2,
			HandJointId.HandMiddle3,
			HandJointId.HandRing2,
			HandJointId.HandRing3,
			HandJointId.HandPinky2,
			HandJointId.HandPinky3
		};

		private Ray[] _eyeRays;

		private bool _started;

		private void Start()
		{
			this.BeginStart(ref _started);
			this.EndStart(ref _started);
			_eyeRays = new Ray[_eyeAnchors.Count];
			_currentOpacity = _opacity;
			_currentOutlineOpacity = _outlineOpacity;
			List<Vector3> list = new List<Vector3>
			{
				_handVisual.GetJointPose(HandJointId.HandWristRoot, Space.World).position,
				_handVisual.GetJointPose(HandJointId.HandThumb1, Space.World).position,
				_handVisual.GetJointPose(HandJointId.HandIndex1, Space.World).position,
				_handVisual.GetJointPose(HandJointId.HandMiddle1, Space.World).position,
				_handVisual.GetJointPose(HandJointId.HandRing1, Space.World).position,
				_handVisual.GetJointPose(HandJointId.HandPinky1, Space.World).position
			};
			Vector3 zero = Vector3.zero;
			foreach (Vector3 item2 in list)
			{
				zero += item2;
			}
			zero *= 1f / (float)list.Count;
			Vector3 item = _handVisual.GetTransformByHandJointId(HandJointId.HandWristRoot).InverseTransformPoint(zero);
			float num = 0f;
			foreach (Vector3 item3 in list)
			{
				num = Mathf.Max(num, Vector3.Distance(zero, item3));
			}
			_palmTarget = (item, num * 0.65f);
		}

		private bool SphereCast(Vector3 target, float radius)
		{
			for (int i = 0; i < _eyeAnchors.Count; i++)
			{
				Vector3 position = _eyeAnchors[i].position;
				Vector3 normalized = (target - position).normalized;
				_eyeRays[i] = new Ray(position, normalized);
			}
			Ray[] eyeRays = _eyeRays;
			for (int j = 0; j < eyeRays.Length; j++)
			{
				if (Physics.SphereCast(eyeRays[j], radius, _castDistance, _layer))
				{
					return true;
				}
			}
			return false;
		}

		private bool SphereCastAllTargets()
		{
			Vector3 target = _handVisual.GetTransformByHandJointId(HandJointId.HandWristRoot).TransformPoint(_palmTarget.Item1);
			if (SphereCast(target, _palmTarget.Item2))
			{
				return true;
			}
			HandJointId[] handJointTargets = _handJointTargets;
			foreach (HandJointId jointId in handJointTargets)
			{
				if (SphereCast(_handVisual.GetJointPose(jointId, Space.World).position, _sphereRadius))
				{
					return true;
				}
			}
			return false;
		}

		private void UpdateMaterialPropertyBlock(bool sphereCastHit)
		{
			float b = (sphereCastHit ? _opacity : 0f);
			float b2 = (sphereCastHit ? _outlineOpacity : 0f);
			float t = _animationSpeed * Time.deltaTime;
			_currentOpacity = Mathf.Lerp(_currentOpacity, b, t);
			_currentOutlineOpacity = Mathf.Lerp(_currentOutlineOpacity, b2, t);
			MaterialPropertyBlockEditor[] handMaterialPropertyBlocks = _handMaterialPropertyBlocks;
			foreach (MaterialPropertyBlockEditor obj in handMaterialPropertyBlocks)
			{
				obj.MaterialPropertyBlock.SetFloat(_opacityId, _currentOpacity);
				obj.MaterialPropertyBlock.SetFloat(_outlineOpacityId, _currentOutlineOpacity);
			}
		}

		private void Update()
		{
			if (MRPassthrough.PassThrough.IsPassThroughOn)
			{
				if (_eyeAnchors != null && !(_handVisual == null))
				{
					UpdateMaterialPropertyBlock(SphereCastAllTargets());
				}
				return;
			}
			MaterialPropertyBlockEditor[] handMaterialPropertyBlocks = _handMaterialPropertyBlocks;
			foreach (MaterialPropertyBlockEditor obj in handMaterialPropertyBlocks)
			{
				obj.MaterialPropertyBlock.SetFloat(_opacityId, _opacity);
				obj.MaterialPropertyBlock.SetFloat(_outlineOpacityId, _outlineOpacity);
			}
		}
	}
	public class MRPassThroughMaterialChanger : MonoBehaviour
	{
		[Header("Passthrough Material")]
		[Tooltip("Material that should be rendered during passthrough")]
		[SerializeField]
		private Material _passThroughMaterial;

		[Header("Current GameObject Material")]
		[SerializeField]
		private Material _material;

		[Tooltip("This current gameobject renderer")]
		[SerializeField]
		private Renderer _renderer;

		protected bool _started;

		protected virtual void Reset()
		{
			_renderer = base.gameObject.GetComponent<Renderer>();
			_material = _renderer.material;
		}

		protected virtual void Start()
		{
			if (_renderer == null)
			{
				_renderer = base.gameObject.GetComponent<Renderer>();
				_material = _renderer.material;
			}
			this.BeginStart(ref _started);
			this.EndStart(ref _started);
		}

		private void Update()
		{
			if (_passThroughMaterial != null && MRPassthrough.PassThrough.IsPassThroughOn)
			{
				_renderer.material = _passThroughMaterial;
			}
			else
			{
				_renderer.material = _material;
			}
		}

		public void InjectAllChanger(Material passthroughMaterial, Renderer render, Material material)
		{
			InjectPassthroughMaterial(passthroughMaterial);
			InjectRenderer(render);
			InjectMaterial(material);
		}

		public void InjectPassthroughMaterial(Material passthroughMaterial)
		{
			_passThroughMaterial = passthroughMaterial;
		}

		public void InjectRenderer(Renderer render)
		{
			_renderer = render;
		}

		public void InjectMaterial(Material material)
		{
			_material = material;
		}
	}
}
