using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using Oculus.Interaction;
using Oculus.Interaction.Body.Input;
using Oculus.Interaction.Body.PoseDetection;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction.HandGrab.Visuals;
using Oculus.Interaction.Input;
using Oculus.Interaction.Locomotion;
using Oculus.Interaction.Surfaces;
using Oculus.Interaction.UnityCanvas;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
public class CanvasGroupAlphaToggle : MonoBehaviour
{
	public CanvasGroup canvasGroup;

	public float animationSpeed;

	private bool visible;

	public void ToggleVisible()
	{
		visible = !visible;
	}

	private void Start()
	{
	}

	private void Update()
	{
		canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, visible ? 1f : 0f, animationSpeed * Time.deltaTime);
	}
}
[RequireComponent(typeof(RectTransform), typeof(GridLayoutGroup))]
public class GridSpacingScaler : MonoBehaviour
{
	public enum Axis
	{
		Horizontal,
		Vertical
	}

	public Axis scaleAxis;

	public Vector2 minSpacing;

	private GridLayoutGroup _gridLayoutGroup;

	private RectTransform _rectTransform;

	private void Start()
	{
		_rectTransform = base.transform as RectTransform;
		if (_rectTransform == null)
		{
			UnityEngine.Debug.LogError("GameObject Transform is not a Rect Transform");
		}
		_gridLayoutGroup = base.gameObject.GetComponent<GridLayoutGroup>();
		if (_gridLayoutGroup == null)
		{
			UnityEngine.Debug.LogError("GameObject does not include a GridLayoutGroup");
		}
	}

	private void LateUpdate()
	{
		float num = Mathf.Floor(_rectTransform.rect.size[(int)scaleAxis]);
		float num2 = minSpacing[(int)scaleAxis];
		float num3 = _gridLayoutGroup.cellSize[(int)scaleAxis];
		int num4 = ((scaleAxis == Axis.Horizontal) ? _gridLayoutGroup.padding.horizontal : _gridLayoutGroup.padding.vertical);
		if (!(num3 + num2 <= 0f))
		{
			int num5 = Mathf.Max(1, Mathf.FloorToInt((num - (float)num4 + num2 + 0.001f) / (num3 + num2)));
			float num6 = num - (float)num5 * num3;
			_gridLayoutGroup.constraint = ((scaleAxis == Axis.Horizontal) ? GridLayoutGroup.Constraint.FixedColumnCount : GridLayoutGroup.Constraint.FixedRowCount);
			_gridLayoutGroup.constraintCount = num5;
			if (num5 > 1)
			{
				float f = num6 / (float)(num5 - 1);
				Vector2 spacing = _gridLayoutGroup.spacing;
				spacing[(int)scaleAxis] = Mathf.Floor(f);
				_gridLayoutGroup.spacing = spacing;
			}
		}
	}
}
public class PageScroll : UIBehaviour
{
	[Serializable]
	public struct Page
	{
		public Toggle toggle;

		public RectTransform container;

		public CanvasGroup canvasGroup;
	}

	[SerializeField]
	private ToggleGroup _toggleGroup;

	[SerializeField]
	private RectTransform _contentContainer;

	[SerializeField]
	private List<Page> _pages;

	[SerializeField]
	private int _pageIndex;

	public float animationSpeed;

	public AnimationCurve alphaTransitionCurve;

	private float _pageAnim;

	public void SetPageIndex(int pageIndex)
	{
		int num = ((pageIndex >= 0) ? ((pageIndex > _pages.Count - 1) ? (_pages.Count - 1) : pageIndex) : 0);
		if (_pageIndex != num)
		{
			_pageIndex = num;
			_pages[_pageIndex].toggle.isOn = true;
		}
	}

	public void ScrollPage(int direction)
	{
		int pageIndex = _pageIndex + direction;
		SetPageIndex(pageIndex);
	}

	protected override void OnEnable()
	{
		foreach (Page page in _pages)
		{
			page.toggle.onValueChanged.AddListener(delegate
			{
				ActiveToggleChanged(page.toggle);
			});
		}
	}

	protected override void OnDisable()
	{
		foreach (Page page in _pages)
		{
			page.toggle.onValueChanged.RemoveAllListeners();
		}
	}

	private void ActiveToggleChanged(Toggle toggle)
	{
		if (!(toggle == null) && toggle.isOn)
		{
			int num = _pages.FindIndex((Page page) => page.toggle == toggle);
			if (num >= 0)
			{
				_pageIndex = num;
			}
		}
	}

	protected override void Start()
	{
		StartCoroutine(LateStart());
	}

	private IEnumerator LateStart()
	{
		yield return null;
		if (_pages != null)
		{
			_pages[0].toggle.isOn = true;
		}
	}

	protected virtual void Update()
	{
		_pageAnim = Mathf.Lerp(_pageAnim, _pageIndex, animationSpeed * Time.deltaTime);
		_pageAnim = Mathf.Clamp(_pageAnim, 0f, _pages.Count - 1);
		UpdateVisial();
	}

	private void UpdateVisial()
	{
		if (Mathf.Abs(_pageAnim - (float)_pageIndex) < 0.005f)
		{
			Vector2 anchoredPosition = _pages[_pageIndex].container.anchoredPosition;
			_pages[_pageIndex].canvasGroup.alpha = 1f;
			SetOtherPagesTransparent(_pageIndex, -1);
			_contentContainer.anchoredPosition = anchoredPosition * new Vector2(-1f, 1f);
			return;
		}
		float num = Mathf.Clamp(_pageAnim, 0f, _pages.Count - 1);
		float num2 = Mathf.Floor(num);
		float num3 = Mathf.Ceil(num);
		int num4 = (int)num2;
		int num5 = (int)num3;
		float num6 = num - num2;
		Vector2 anchoredPosition2 = _pages[num4].container.anchoredPosition;
		Vector2 anchoredPosition3 = _pages[num5].container.anchoredPosition;
		SetOtherPagesTransparent(num4, num5);
		_pages[num4].canvasGroup.alpha = alphaTransitionCurve.Evaluate(1f - num6);
		_pages[num5].canvasGroup.alpha = alphaTransitionCurve.Evaluate(num6);
		_contentContainer.anchoredPosition = Vector2.Lerp(anchoredPosition2, anchoredPosition3, num6) * new Vector2(-1f, 1f);
	}

	private void SetOtherPagesTransparent(int index0, int index1)
	{
		for (int i = 0; i < _pages.Count; i++)
		{
			if (i != index0 && i != index1 && !(_pages[i].canvasGroup == null))
			{
				_pages[i].canvasGroup.alpha = 0f;
			}
		}
	}

	public void InjectAllPageScroll(ToggleGroup toggleGroup, RectTransform contentContainer, List<Page> pages, int pageIndex)
	{
		InjectToggleGroup(toggleGroup);
		InjectContentContainer(contentContainer);
		InjectPages(pages);
		InjectPageIndex(pageIndex);
	}

	public void InjectToggleGroup(ToggleGroup toggleGroup)
	{
		_toggleGroup = toggleGroup;
	}

	public void InjectContentContainer(RectTransform contentContainer)
	{
		_contentContainer = contentContainer;
	}

	public void InjectPages(List<Page> pages)
	{
		_pages = pages;
	}

	public void InjectPageIndex(int pageIndex)
	{
		_pageIndex = pageIndex;
	}
}
[ExecuteAlways]
[RequireComponent(typeof(RectTransform))]
public class RectSizeConstraint : UIBehaviour
{
	public RectTransform target;

	protected virtual void LateUpdate()
	{
		if (target != null)
		{
			RectTransform obj = (RectTransform)base.transform;
			obj.sizeDelta = new Vector2(target.rect.width, target.rect.height);
			obj.ForceUpdateRectTransforms();
		}
	}
}
public class RoundedBoxUIProperties : UIBehaviour, IMeshModifier
{
	private Image _image;

	public Vector4 borderRadius;

	protected override void OnEnable()
	{
		_image = base.gameObject.GetComponent<Image>();
	}

	protected override void OnDisable()
	{
		_image = null;
	}

	protected override void Start()
	{
		StartCoroutine(DelayVertexGeneration());
	}

	private IEnumerator DelayVertexGeneration()
	{
		yield return new WaitForSeconds(0.1f);
		if (_image == null)
		{
			_image = base.gameObject.GetComponent<Image>();
			if (_image == null)
			{
				yield break;
			}
		}
		_image.SetAllDirty();
	}

	public void ModifyMesh(Mesh mesh)
	{
	}

	public void ModifyMesh(VertexHelper verts)
	{
		if (_image == null)
		{
			_image = base.gameObject.GetComponent<Image>();
			if (_image == null)
			{
				return;
			}
		}
		Rect rect = ((RectTransform)base.transform).rect;
		Vector4 vector = new Vector4(rect.x, rect.y, Mathf.Abs(rect.width), Mathf.Abs(rect.height));
		UIVertex vertex = default(UIVertex);
		for (int i = 0; i < verts.currentVertCount; i++)
		{
			verts.PopulateUIVertex(ref vertex, i);
			Vector4 uv = vertex.uv0;
			uv.z = vector.z;
			uv.w = vector.w;
			vertex.uv0 = uv;
			vertex.uv1 = borderRadius * 0.5f;
			verts.SetUIVertex(vertex, i);
		}
	}
}
public class RoundedBoxVideoController : MonoBehaviour
{
	private struct BoxAnimation
	{
		public RectTransform rectTransform;

		public Image image;

		public float duration;

		public float startHeight;

		public float animationMaxHeight;

		public float startVelocity;

		public float startTime;

		public float acceleration;

		public void Update(float animationTime)
		{
			float value = animationTime - startTime;
			value = Mathf.Clamp(value, 0f, duration);
			float num = value * value;
			float num2 = startVelocity * value - 0.5f * acceleration * num;
			float num3 = num2 / animationMaxHeight;
			float y = startHeight - num2;
			Vector2 anchoredPosition = rectTransform.anchoredPosition;
			anchoredPosition.y = y;
			rectTransform.anchoredPosition = anchoredPosition;
			rectTransform.rotation = Quaternion.Euler(0f, 0f, num3 * 360f);
		}

		public void SetColor(Color color)
		{
			image.color = color;
		}
	}

	public Slider timeSlider;

	public float animationDuration;

	public float animationTime;

	public int cycleCount;

	public Sprite playIcon;

	public Sprite pauseIcon;

	public Image playPauseImg;

	public bool isPlaying;

	public List<Color> boxColors;

	public List<RectTransform> boxes;

	private float animationCycleDuration;

	[Header("Time Labels")]
	public TextMeshProUGUI leftLabel;

	public TextMeshProUGUI rightLabel;

	[Header("Background Material Settings")]
	public Image backgroundImage;

	public Vector2 direction;

	public Color colorA;

	public Color colorB;

	private readonly int columnDirectionID = Shader.PropertyToID("columnDirection");

	private readonly int rowDirectionID = Shader.PropertyToID("rowDirection");

	private readonly int animationTimeID = Shader.PropertyToID("animationTime");

	private readonly int colorAID = Shader.PropertyToID("colorA");

	private readonly int colorBID = Shader.PropertyToID("colorB");

	private List<BoxAnimation> animations;

	private void OnEnable()
	{
		UpdateBackgroundMaterialProperties();
	}

	private void Start()
	{
		animations = new List<BoxAnimation>();
		Vector2 size = ((RectTransform)base.transform).rect.size;
		float num = size.x / (float)boxes.Count;
		timeSlider.onValueChanged.AddListener(delegate
		{
			OnSliderValueChange();
		});
		float num2 = ((float)boxes.Count - 1f) * 0.35f + 1f;
		animationCycleDuration = animationDuration / (float)cycleCount;
		float num3 = animationCycleDuration / num2;
		float num4 = boxes[0].rect.height * 0.6f;
		float num5 = size.y * 0.5f + num4;
		float num6 = 2f * num5 / (num3 * 0.5f);
		float acceleration = num6 / (num3 * 0.5f);
		for (int num7 = 0; num7 < boxes.Count; num7++)
		{
			RectTransform rectTransform = boxes[num7];
			float num8 = (float)num7 + 0.5f;
			rectTransform.anchoredPosition = new Vector2(num8 * num, 0f);
			BoxAnimation item = new BoxAnimation
			{
				duration = num3,
				startHeight = num4,
				animationMaxHeight = num5,
				rectTransform = rectTransform,
				startVelocity = num6,
				acceleration = acceleration,
				startTime = num3 * 0.35f * (float)num7,
				image = rectTransform.GetComponent<Image>()
			};
			animations.Add(item);
		}
		SetPlay();
		UpdateBackgroundMaterialProperties();
	}

	public void UpdateBackgroundMaterialProperties()
	{
		Vector2 normalized = direction.normalized;
		backgroundImage.materialForRendering.SetVector(columnDirectionID, normalized);
		backgroundImage.materialForRendering.SetVector(rowDirectionID, new Vector2(0f - normalized.y, normalized.x));
		backgroundImage.materialForRendering.SetColor(colorAID, colorA.linear);
		backgroundImage.materialForRendering.SetColor(colorBID, colorB.linear);
		backgroundImage.materialForRendering.SetFloat(animationTimeID, animationTime);
	}

	public void OnSliderValueChange()
	{
		animationTime = timeSlider.value * animationDuration;
	}

	public void TogglePlayPause()
	{
		if (isPlaying)
		{
			SetPaused();
			return;
		}
		if (Mathf.Abs(animationDuration - animationTime) < 0.1f)
		{
			animationTime = 0f;
		}
		SetPlay();
	}

	private void SetPaused()
	{
		isPlaying = false;
		playPauseImg.sprite = playIcon;
	}

	private void SetPlay()
	{
		isPlaying = true;
		playPauseImg.sprite = pauseIcon;
	}

	private string FormatTime(float seconds)
	{
		int num = Mathf.FloorToInt(seconds / 60f);
		int num2 = (int)seconds % 60;
		string text = num.ToString();
		string text2 = num2.ToString("D2");
		return text + ":" + text2;
	}

	private void LateUpdate()
	{
		if (isPlaying)
		{
			animationTime += Time.deltaTime;
			timeSlider.SetValueWithoutNotify(animationTime / animationDuration);
			if (animationTime > animationDuration)
			{
				animationTime = animationDuration;
				SetPaused();
			}
		}
		else
		{
			animationTime = timeSlider.value * animationDuration;
		}
		for (int i = 0; i < animations.Count; i++)
		{
			float num = Mathf.Floor(animationTime / animationCycleDuration) % (float)boxColors.Count;
			animations[i].SetColor(boxColors[(int)num]);
			animations[i].Update(animationTime % animationCycleDuration);
		}
		float seconds = Mathf.Round(animationDuration - animationTime);
		leftLabel.SetText(FormatTime(animationTime));
		rightLabel.SetText(FormatTime(seconds));
		backgroundImage.materialForRendering.SetFloat(animationTimeID, animationTime);
	}
}
public class SwipeGesture : UIBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler
{
	public enum Axis
	{
		Horizontal,
		Vertical
	}

	public float gestureMaxDuration = 1f;

	public float gestureMinDistanceNormalized = 0.15f;

	[Space(10f)]
	public bool invertScroll;

	public Axis swipeAxis;

	private float startTime;

	private Vector2 startLocalPosition;

	[Space(10f)]
	[SerializeField]
	private UnityEvent<int> swipeExecuted;

	public void OnBeginDrag(PointerEventData eventData)
	{
		startTime = Time.time;
		RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)base.transform, eventData.position, eventData.pressEventCamera, out var localPoint);
		startLocalPosition = localPoint;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		float num = Time.time - startTime;
		RectTransform rectTransform = (RectTransform)base.transform;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out var localPoint);
		Vector2 vector = localPoint - startLocalPosition;
		bool flag = Mathf.Abs(vector.normalized[(int)swipeAxis]) > 0.5f;
		bool flag2 = num < gestureMaxDuration;
		float num2 = ((swipeAxis == Axis.Horizontal) ? rectTransform.rect.width : rectTransform.rect.height);
		float num3 = Mathf.Abs(vector[(int)swipeAxis]);
		float num4 = num2 * gestureMinDistanceNormalized;
		bool flag3 = num3 > num4;
		if (flag && flag3 && flag2)
		{
			int num5 = (int)Mathf.Sign(vector[(int)swipeAxis]);
			num5 *= ((!invertScroll) ? 1 : (-1));
			swipeExecuted.Invoke(num5);
		}
	}
}
[ExecuteAlways]
public class VirtualLayout : UIBehaviour
{
	public float animationSpeed;

	[SerializeField]
	private RectTransform _layoutParent;

	private List<RectTransform> _rectChildren;

	private List<RectTransform> _virtualLayoutChildren;

	protected override void OnEnable()
	{
		if (_layoutParent == null)
		{
			return;
		}
		RectTransform[] componentsInChildren = _layoutParent.gameObject.GetComponentsInChildren<RectTransform>();
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			RectTransform rectTransform = componentsInChildren[i];
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(rectTransform.gameObject);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(rectTransform.gameObject);
			}
		}
		RectTransform[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<RectTransform>();
		_rectChildren = new List<RectTransform>();
		_virtualLayoutChildren = new List<RectTransform>();
		for (int j = 1; j < componentsInChildren2.Length; j++)
		{
			RectTransform rectTransform2 = componentsInChildren2[j];
			if (!(rectTransform2.parent != (RectTransform)base.transform))
			{
				_rectChildren.Add(rectTransform2);
				ResetChildTransform(rectTransform2);
				GameObject obj = new GameObject();
				obj.hideFlags = HideFlags.HideAndDontSave;
				obj.name = rectTransform2.name;
				obj.AddComponent<RectTransform>();
				RectTransform rectTransform3 = (RectTransform)obj.transform;
				rectTransform3.SetParent(_layoutParent, worldPositionStays: false);
				ResetChildTransform(rectTransform3);
				_virtualLayoutChildren.Add(rectTransform3);
			}
		}
		_layoutParent.ForceUpdateRectTransforms();
	}

	private void ResetChildTransform(RectTransform child)
	{
		child.localPosition = Vector3.zero;
		child.anchoredPosition = Vector2.zero;
		child.localScale = Vector3.one;
		child.localRotation = Quaternion.identity;
		child.anchorMin = Vector2.zero;
		child.anchorMax = Vector2.zero;
		child.pivot = new Vector2(0.5f, 0.5f);
	}

	protected override void OnDisable()
	{
		foreach (RectTransform virtualLayoutChild in _virtualLayoutChildren)
		{
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(virtualLayoutChild.gameObject);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(virtualLayoutChild.gameObject);
			}
		}
	}

	private void LateUpdate()
	{
		if (_layoutParent == null)
		{
			return;
		}
		((RectTransform)base.transform).anchoredPosition = _layoutParent.anchoredPosition;
		for (int i = 0; i < _virtualLayoutChildren.Count; i++)
		{
			RectTransform rectTransform = _rectChildren[i];
			RectTransform rectTransform2 = _virtualLayoutChildren[i];
			if (Application.isPlaying)
			{
				rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, rectTransform2.anchoredPosition, animationSpeed * Time.deltaTime);
				rectTransform.sizeDelta = Vector2.Lerp(rectTransform.sizeDelta, rectTransform2.sizeDelta, animationSpeed * Time.deltaTime);
			}
			else
			{
				rectTransform.anchoredPosition = rectTransform2.anchoredPosition + _layoutParent.anchoredPosition;
				rectTransform.sizeDelta = rectTransform2.sizeDelta;
			}
		}
	}

	public void InjectAllVirtualLayoutElement(RectTransform layoutParent)
	{
		_layoutParent = layoutParent;
	}
}
public class MoveRelativeToTargetProvider : MonoBehaviour, IMovementProvider
{
	public IMovement CreateMovement()
	{
		return new MoveRelativeToTarget();
	}
}
public class MoveRelativeToTarget : IMovement
{
	private Pose _current = Pose.identity;

	private Pose _originalTarget;

	private Pose _originalSource;

	private Pose _offset = Pose.identity;

	public Pose Pose => _current;

	public bool Stopped => true;

	public void MoveTo(Pose target)
	{
		_originalTarget = target;
		_offset = PoseUtils.Delta(in _originalTarget, in _originalSource);
	}

	public void UpdateTarget(Pose target)
	{
		_current = PoseUtils.Multiply(in target, in _offset);
	}

	public void StopAndSetPose(Pose source)
	{
		_current = (_originalSource = source);
	}

	public void Tick()
	{
	}
}
public class CanvasSizeConstraint : MonoBehaviour
{
	public Transform horizontalAnchorA;

	public Transform horizontalAnchorB;

	public Transform verticalAnchorA;

	public Transform verticalAnchorB;

	public float horizontalSizeOffset;

	public float verticalSizeOffset;

	private Vector2 _initialSize;

	private Vector2 _initialRectSize;

	private RectTransform _rectTransform;

	private Vector3 _initialLocalScale;

	private void Start()
	{
		_rectTransform = GetComponent<RectTransform>();
		_initialRectSize = _rectTransform.sizeDelta;
		_initialSize = new Vector2(Vector3.Distance(horizontalAnchorA.position, horizontalAnchorB.position) - horizontalSizeOffset, Vector3.Distance(verticalAnchorA.position, verticalAnchorB.position) - verticalSizeOffset);
		_initialLocalScale = _rectTransform.localScale;
	}

	private void Update()
	{
		Vector2 vector = new Vector2(Vector3.Distance(horizontalAnchorA.position, horizontalAnchorB.position) - horizontalSizeOffset, Vector3.Distance(verticalAnchorA.position, verticalAnchorB.position) - verticalSizeOffset);
		Vector2 vector2 = new Vector2(vector.x / _initialSize.x, vector.y / _initialSize.y);
		_rectTransform.localScale = new Vector3(_initialLocalScale.x / vector2.x, _initialLocalScale.y / vector2.y, _initialLocalScale.z);
		_rectTransform.sizeDelta = new Vector2(_initialRectSize.x * vector2.x, _initialRectSize.y * vector2.y);
	}
}
public class ColliderSizeConstraint : MonoBehaviour
{
	public Vector3 size;

	public int expandingAxis;

	public Transform pointA;

	public Transform pointB;

	public float wideSideOffset;

	private void Update()
	{
		float num = Vector3.Distance(pointA.position, pointB.position);
		num -= wideSideOffset;
		Vector3 lossyScale = base.transform.parent.lossyScale;
		Vector3 vector = size;
		vector[expandingAxis] = num;
		Vector3 localScale = new Vector3(vector.x / lossyScale.x, vector.y / lossyScale.y, vector.z / lossyScale.z);
		base.transform.localScale = localScale;
	}
}
public class PanelHoverState : MonoBehaviour
{
	public List<Grabbable> grabbables = new List<Grabbable>();

	private bool hovered;

	public bool Hovered => hovered;

	public event Action<bool> WhenStateChanged = delegate
	{
	};

	private void Update()
	{
		bool flag = hovered;
		hovered = false;
		foreach (Grabbable grabbable in grabbables)
		{
			if (grabbable.PointsCount > 0)
			{
				hovered = true;
				break;
			}
		}
		if (flag != hovered)
		{
			this.WhenStateChanged(hovered);
		}
	}
}
public class PanelSetup : MonoBehaviour
{
	public float InteractableLength;

	public float InteractableDepth;

	public bool AddVerticalRotation;

	public bool AddHorizontalRotation;

	public RectTransform panelTransform;

	public UnionClippedPlaneSurface panelClippedPlaneSurface;

	public BoundsClipper boundsClipper;

	public Transform topLeftCornerAnchor;

	[Header("Anchors")]
	public Transform AnchorTopLeft;

	public Transform AnchorTopRight;

	public Transform AnchorBottomLeft;

	public Transform AnchorBottomRight;

	[Header("SideCollider")]
	public GameObject PanelInteractable;

	[Header("Scaler")]
	public GameObject ScalerTopLeft;

	public GameObject ScalerTopRight;

	public GameObject ScalerBottomLeft;

	public GameObject ScalerBottomRight;

	[Header("Rotator")]
	public GameObject RotatorVerticalTop;

	public GameObject RotatorVerticalBottom;

	public GameObject RotatorHorizontalLeft;

	public GameObject RotatorHorizontalRight;

	[ContextMenu("Update Panel")]
	public void UpdatePanelProperties()
	{
		UnityEngine.Debug.Log("Update Function");
		Vector2 vector = panelTransform.sizeDelta * panelTransform.lossyScale;
		Vector3[] rectCorners = GetRectCorners(Vector3.zero, vector);
		float num = InteractableLength * 0.5f;
		AnchorTopLeft.localPosition = rectCorners[0] + num * (Vector3)Vec2Sign(rectCorners[0]);
		AnchorTopRight.localPosition = rectCorners[1] + num * (Vector3)Vec2Sign(rectCorners[1]);
		AnchorBottomLeft.localPosition = rectCorners[2] + num * (Vector3)Vec2Sign(rectCorners[2]);
		AnchorBottomRight.localPosition = rectCorners[3] + num * (Vector3)Vec2Sign(rectCorners[3]);
		Vector3 size = new Vector3(InteractableLength, InteractableLength, InteractableDepth);
		SetColliderSize(ScalerTopLeft, size);
		SetColliderSize(ScalerTopRight, size);
		SetColliderSize(ScalerBottomLeft, size);
		SetColliderSize(ScalerBottomRight, size);
		if (AddVerticalRotation)
		{
			SetColliderSize(RotatorVerticalTop, size);
			SetColliderSize(RotatorVerticalBottom, size);
			RotatorVerticalTop.gameObject.SetActive(value: true);
			RotatorVerticalBottom.gameObject.SetActive(value: true);
		}
		else
		{
			RotatorVerticalTop.gameObject.SetActive(value: false);
			RotatorVerticalBottom.gameObject.SetActive(value: false);
		}
		if (AddHorizontalRotation)
		{
			SetColliderSize(RotatorHorizontalLeft, size);
			SetColliderSize(RotatorHorizontalRight, size);
			RotatorHorizontalLeft.gameObject.SetActive(value: true);
			RotatorHorizontalRight.gameObject.SetActive(value: true);
		}
		else
		{
			RotatorHorizontalLeft.gameObject.SetActive(value: false);
			RotatorHorizontalRight.gameObject.SetActive(value: false);
		}
		Vector3[] rectSides = GetRectSides(Vector3.zero, vector);
		if (AddVerticalRotation)
		{
			CreateCollider("ColliderUpLeft", vector, rectSides[0], Vector3.up, Vector3.left, fullSize: false, 0, 1, RotatorVerticalTop.transform, ScalerTopLeft.transform);
			CreateCollider("ColliderUpRight", vector, rectSides[0], Vector3.up, Vector3.right, fullSize: false, 0, 1, RotatorVerticalTop.transform, ScalerTopRight.transform);
			CreateCollider("ColliderDownLeft", vector, rectSides[1], Vector3.down, Vector3.left, fullSize: false, 0, 1, RotatorVerticalBottom.transform, ScalerBottomLeft.transform);
			CreateCollider("ColliderDownRight", vector, rectSides[1], Vector3.down, Vector3.right, fullSize: false, 0, 1, RotatorVerticalBottom.transform, ScalerBottomRight.transform);
		}
		else
		{
			CreateCollider("ColliderUp", vector, rectSides[0], Vector3.up, Vector3.zero, fullSize: true, 0, 1, ScalerTopLeft.transform, ScalerTopRight.transform);
			CreateCollider("ColliderDown", vector, rectSides[1], Vector3.down, Vector3.zero, fullSize: true, 0, 1, ScalerBottomLeft.transform, ScalerBottomRight.transform);
		}
		if (AddHorizontalRotation)
		{
			CreateCollider("ColliderLeftUp", vector, rectSides[2], Vector3.left, Vector3.up, fullSize: false, 1, 0, RotatorHorizontalLeft.transform, ScalerTopLeft.transform);
			CreateCollider("ColliderLeftDown", vector, rectSides[2], Vector3.left, Vector3.down, fullSize: false, 1, 0, RotatorHorizontalLeft.transform, ScalerBottomLeft.transform);
			CreateCollider("ColliderRightUp", vector, rectSides[3], Vector3.right, Vector3.up, fullSize: false, 1, 0, RotatorHorizontalRight.transform, ScalerTopRight.transform);
			CreateCollider("ColliderRightDown", vector, rectSides[3], Vector3.right, Vector3.down, fullSize: false, 1, 0, RotatorHorizontalRight.transform, ScalerBottomRight.transform);
		}
		else
		{
			CreateCollider("ColliderLeft", vector, rectSides[2], Vector3.left, Vector3.zero, fullSize: true, 1, 0, ScalerBottomLeft.transform, ScalerTopLeft.transform);
			CreateCollider("ColliderRight", vector, rectSides[3], Vector3.right, Vector3.zero, fullSize: true, 1, 0, ScalerBottomRight.transform, ScalerTopRight.transform);
		}
		boundsClipper.Size = new Vector3(vector.x, vector.y, InteractableDepth);
		topLeftCornerAnchor.localPosition = new Vector3((0f - vector.x) * 0.5f, vector.y * 0.5f, 0f);
	}

	private void CreateCollider(string name, Vector2 rectSize, Vector3 sidePosition, Vector3 sideDirection, Vector3 offsetDirection, bool fullSize, int wideAxis, int normalAxis, Transform anchorA, Transform anchorB)
	{
		float num = InteractableLength * 0.5f;
		GameObject obj = new GameObject(name);
		obj.transform.SetParent(PanelInteractable.transform, worldPositionStays: false);
		obj.AddComponent<BoxCollider>().isTrigger = true;
		obj.AddComponent<BoundsClipper>();
		PositionConstraint positionConstraint = obj.AddComponent<PositionConstraint>();
		positionConstraint.AddSource(new ConstraintSource
		{
			sourceTransform = anchorA,
			weight = 1f
		});
		positionConstraint.AddSource(new ConstraintSource
		{
			sourceTransform = anchorB,
			weight = 1f
		});
		positionConstraint.constraintActive = true;
		obj.transform.localPosition = sidePosition + sideDirection * num;
		float num2 = (fullSize ? rectSize[wideAxis] : (Mathf.Abs(rectSize[wideAxis] - InteractableLength) / 2f));
		obj.transform.localPosition += offsetDirection * (num + num2 * 0.5f);
		Vector3 vector = new Vector3(0f, 0f, InteractableDepth)
		{
			[wideAxis] = num2,
			[normalAxis] = InteractableLength
		};
		ColliderSizeConstraint colliderSizeConstraint = obj.AddComponent<ColliderSizeConstraint>();
		colliderSizeConstraint.pointA = anchorA;
		colliderSizeConstraint.pointB = anchorB;
		colliderSizeConstraint.size = vector;
		colliderSizeConstraint.wideSideOffset = InteractableLength;
		colliderSizeConstraint.expandingAxis = wideAxis;
		obj.transform.localScale = vector;
	}

	private void SetColliderSize(GameObject colliderGO, Vector3 size)
	{
		if (!(colliderGO == null))
		{
			Vector3 lossyScale = colliderGO.transform.lossyScale;
			Vector3 size2 = new Vector3(size.x / lossyScale.x, size.y / lossyScale.y, size.z / lossyScale.z);
			BoxCollider component = colliderGO.GetComponent<BoxCollider>();
			if (component != null)
			{
				component.size = size2;
			}
			BoundsClipper component2 = colliderGO.GetComponent<BoundsClipper>();
			if (component2 != null)
			{
				component2.Size = size2;
			}
		}
	}

	private Vector2 Vec2Sign(Vector2 value)
	{
		return new Vector2(Mathf.Sign(value.x), Mathf.Sign(value.y));
	}

	private Vector3[] GetRectCorners(Vector3 position, Vector2 size)
	{
		return new Vector3[4]
		{
			position + new Vector3((0f - size.x) * 0.5f, size.y * 0.5f, 0f),
			position + new Vector3(size.x * 0.5f, size.y * 0.5f, 0f),
			position + new Vector3((0f - size.x) * 0.5f, (0f - size.y) * 0.5f, 0f),
			position + new Vector3(size.x * 0.5f, (0f - size.y) * 0.5f, 0f)
		};
	}

	private Vector3[] GetRectSides(Vector3 position, Vector2 size)
	{
		return new Vector3[4]
		{
			position + new Vector3(0f, size.y * 0.5f, 0f),
			position + new Vector3(0f, (0f - size.y) * 0.5f, 0f),
			position + new Vector3((0f - size.x) * 0.5f, 0f, 0f),
			position + new Vector3(size.x * 0.5f, 0f, 0f)
		};
	}
}
public class SkinnedRoundedBoxMesh : MonoBehaviour
{
	[SerializeField]
	private Transform _topLeft;

	[SerializeField]
	private Transform _topRight;

	[SerializeField]
	private Transform _bottomLeft;

	[SerializeField]
	private Transform _bottomRight;

	[SerializeField]
	private int _cornerSegmentCount;

	[SerializeField]
	private int _cylinderFaceCount;

	[SerializeField]
	private float _borderRadius;

	[SerializeField]
	private float _cylinderRadius;

	[SerializeField]
	private SkinnedMeshRenderer _skinnedMeshRenderer;

	public bool generateOnStart;

	private void Start()
	{
		if (generateOnStart)
		{
			GenerateMesh(_cornerSegmentCount, _borderRadius, _cylinderFaceCount, _cylinderRadius, _skinnedMeshRenderer, _topLeft, _topRight, _bottomLeft, _bottomRight);
		}
	}

	public static Vector2[] GenerateArcPath(float startAngle, float endAngle, int steps, float radius, bool closed)
	{
		float num = (endAngle - startAngle) / (float)steps;
		List<Vector2> list = new List<Vector2>();
		int num2 = (closed ? (steps + 1) : steps);
		for (int i = 0; i < num2; i++)
		{
			Vector2 vector = new Vector2(Mathf.Cos(startAngle + num * (float)i), Mathf.Sin(startAngle + num * (float)i));
			list.Add(vector * radius);
		}
		return list.ToArray();
	}

	public static Vector3[] GenerateCylinderAroundPath(List<Vector2> path, int cylinderFaceCount, float cylinderRadius)
	{
		Vector2[] array = GenerateArcPath(0f, MathF.PI * 2f, cylinderFaceCount, cylinderRadius, closed: false);
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < path.Count; i++)
		{
			Vector2 vector = path[i];
			Vector3 vector2 = Vector3.Normalize(Vector3.Cross(Vector3.Normalize(path[(i + 1) % path.Count] - vector), new Vector3(0f, 0f, 1f)));
			for (int j = 0; j < array.Length; j++)
			{
				Vector3 item = (Vector3)vector + array[j].x * vector2 + array[j].y * Vector3.forward;
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	public static int[] GenerateCylinderIndices(int cornerSegmentCount, int cylinderFaceCount)
	{
		List<int> list = new List<int>();
		int num = cornerSegmentCount * 4;
		for (int i = 0; i < num; i++)
		{
			int num2 = cylinderFaceCount * i;
			int num3 = cylinderFaceCount * ((i + 1) % num);
			for (int j = 0; j < cylinderFaceCount; j++)
			{
				int num4 = j;
				int num5 = (j + 1) % cylinderFaceCount;
				list.Add(num2 + num4);
				list.Add(num3 + num4);
				list.Add(num3 + num5);
				list.Add(num2 + num4);
				list.Add(num3 + num5);
				list.Add(num2 + num5);
			}
		}
		return list.ToArray();
	}

	private static void PushBoneWeigth(int boneIndex, List<BoneWeight> weights, int cornerSegmentCount, int cylinderFaceCount)
	{
		int num = cornerSegmentCount * cylinderFaceCount;
		for (int i = 0; i < num; i++)
		{
			weights.Add(new BoneWeight
			{
				boneIndex0 = boneIndex,
				weight0 = 1f,
				boneIndex1 = 0,
				boneIndex2 = 0,
				boneIndex3 = 0
			});
		}
	}

	public static void GenerateMesh(int cornerSegmentCount, float borderRadius, int cylinderFaceCount, float cylinderRadius, SkinnedMeshRenderer skinnedMeshRenderer, Transform topLeft, Transform topRight, Transform bottomLeft, Transform bottomRight)
	{
		Mesh mesh = new Mesh();
		List<Vector2> list = new List<Vector2>();
		list.AddRange(GenerateArcPath(MathF.PI, MathF.PI / 2f, cornerSegmentCount, borderRadius, closed: false));
		list.AddRange(GenerateArcPath(MathF.PI / 2f, 0f, cornerSegmentCount, borderRadius, closed: false));
		list.AddRange(GenerateArcPath(0f, -MathF.PI / 2f, cornerSegmentCount, borderRadius, closed: false));
		list.AddRange(GenerateArcPath(-MathF.PI / 2f, -MathF.PI, cornerSegmentCount, borderRadius, closed: false));
		Vector3[] vertices = GenerateCylinderAroundPath(list, cylinderFaceCount, cylinderRadius);
		int[] indices = GenerateCylinderIndices(cornerSegmentCount, cylinderFaceCount);
		List<BoneWeight> list2 = new List<BoneWeight>();
		PushBoneWeigth(0, list2, cornerSegmentCount, cylinderFaceCount);
		PushBoneWeigth(1, list2, cornerSegmentCount, cylinderFaceCount);
		PushBoneWeigth(3, list2, cornerSegmentCount, cylinderFaceCount);
		PushBoneWeigth(2, list2, cornerSegmentCount, cylinderFaceCount);
		mesh.vertices = vertices;
		mesh.SetIndices(indices, MeshTopology.Triangles, 0);
		mesh.boneWeights = list2.ToArray();
		mesh.bindposes = new Matrix4x4[4]
		{
			Matrix4x4.identity,
			Matrix4x4.identity,
			Matrix4x4.identity,
			Matrix4x4.identity
		};
		mesh.name = "SkinnedRoundedBoxMesh";
		skinnedMeshRenderer.bones = new Transform[4] { topLeft, topRight, bottomLeft, bottomRight };
		skinnedMeshRenderer.rootBone = topLeft;
		skinnedMeshRenderer.sharedMesh = mesh;
		mesh.RecalculateBounds();
	}

	[ContextMenu("Generate Mesh")]
	public void GenerateMeshFromMenu()
	{
		GenerateMesh(_cornerSegmentCount, _borderRadius, _cylinderFaceCount, _cylinderRadius, _skinnedMeshRenderer, _topLeft, _topRight, _bottomLeft, _bottomRight);
	}
}
public class UpdateRoundedBoxAnchorConstraint : MonoBehaviour
{
	[SerializeField]
	private PositionConstraint _topLeft;

	[SerializeField]
	private PositionConstraint _topRight;

	[SerializeField]
	private PositionConstraint _bottomLeft;

	[SerializeField]
	private PositionConstraint _bottomRight;

	[SerializeField]
	private float _interactableLength;

	[SerializeField]
	private Vector2 _offset;

	private static void UpdateOffset(PositionConstraint constraint, Vector2 direction, Vector2 offset, float interactableLength)
	{
		constraint.translationOffset = direction * offset + direction * interactableLength * 0.5f;
	}

	public static void UpdateAnchors(PositionConstraint topLeft, PositionConstraint topRight, PositionConstraint bottomLeft, PositionConstraint bottomRight, Vector2 offset, float interactableLength)
	{
		UpdateOffset(topLeft, new Vector2(1f, -1f), offset, interactableLength);
		UpdateOffset(topRight, new Vector2(-1f, -1f), offset, interactableLength);
		UpdateOffset(bottomLeft, new Vector2(1f, 1f), offset, interactableLength);
		UpdateOffset(bottomRight, new Vector2(-1f, 1f), offset, interactableLength);
	}

	[ContextMenu("Update Anchors")]
	public void UpdateAnchorsMenu()
	{
		UpdateAnchors(_topLeft, _topRight, _bottomLeft, _bottomRight, _offset, _interactableLength);
	}
}
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
			FilePathsData = new byte[10310]
			{
				0, 0, 0, 1, 0, 0, 0, 119, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 105, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 64, 98, 101,
				53, 51, 100, 101, 53, 51, 55, 49, 48, 98,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				97, 109, 112, 108, 101, 92, 79, 98, 106, 101,
				99, 116, 115, 92, 85, 73, 83, 101, 116, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 68, 105,
				115, 97, 98, 108, 101, 82, 97, 121, 99, 97,
				115, 116, 101, 114, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 116, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 105, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 64, 98, 101, 53, 51, 100,
				101, 53, 51, 55, 49, 48, 98, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 83, 97, 109, 112,
				108, 101, 92, 79, 98, 106, 101, 99, 116, 115,
				92, 85, 73, 83, 101, 116, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 68, 114, 111, 112, 68,
				111, 119, 110, 71, 114, 111, 117, 112, 46, 99,
				115, 0, 0, 0, 2, 0, 0, 0, 110, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 105, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 64, 98,
				101, 53, 51, 100, 101, 53, 51, 55, 49, 48,
				98, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				83, 97, 109, 112, 108, 101, 92, 79, 98, 106,
				101, 99, 116, 115, 92, 85, 73, 83, 101, 116,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 85,
				73, 84, 104, 101, 109, 101, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 117, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 64, 98, 101, 53,
				51, 100, 101, 53, 51, 55, 49, 48, 98, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 97,
				109, 112, 108, 101, 92, 79, 98, 106, 101, 99,
				116, 115, 92, 85, 73, 83, 101, 116, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 85, 73, 84,
				104, 101, 109, 101, 77, 97, 110, 97, 103, 101,
				114, 46, 99, 115, 0, 0, 0, 3, 0, 0,
				0, 101, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				105, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 64, 98, 101, 53, 51, 100, 101, 53, 51,
				55, 49, 48, 98, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 83, 97, 109, 112, 108, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 65, 117,
				100, 105, 111, 80, 104, 121, 115, 105, 99, 115,
				46, 99, 115, 0, 0, 0, 2, 0, 0, 0,
				101, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 105,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				64, 98, 101, 53, 51, 100, 101, 53, 51, 55,
				49, 48, 98, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 83, 97, 109, 112, 108, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 65, 117, 100,
				105, 111, 84, 114, 105, 103, 103, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 110,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 105, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 64,
				98, 101, 53, 51, 100, 101, 53, 51, 55, 49,
				48, 98, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 97, 109, 112, 108, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 66, 111, 100, 121,
				92, 66, 111, 100, 121, 80, 111, 115, 101, 83,
				119, 105, 116, 99, 104, 101, 114, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 108, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 105, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 64, 98, 101,
				53, 51, 100, 101, 53, 51, 55, 49, 48, 98,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				97, 109, 112, 108, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 66, 111, 100, 121, 92, 76,
				111, 99, 107, 101, 100, 66, 111, 100, 121, 80,
				111, 115, 101, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 114, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 105, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 64, 98, 101, 53, 51, 100, 101,
				53, 51, 55, 49, 48, 98, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 83, 97, 109, 112, 108,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				66, 111, 100, 121, 92, 80, 111, 115, 101, 67,
				97, 112, 116, 117, 114, 101, 67, 111, 117, 110,
				116, 100, 111, 119, 110, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 114, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 105, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 64, 98, 101, 53, 51,
				100, 101, 53, 51, 55, 49, 48, 98, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 97, 109,
				112, 108, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 67, 97, 110, 118, 97, 115, 67, 111,
				110, 115, 116, 97, 110, 116, 87, 105, 100, 116,
				104, 83, 99, 97, 108, 101, 114, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 101, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 105, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 64, 98, 101,
				53, 51, 100, 101, 53, 51, 55, 49, 48, 98,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				97, 109, 112, 108, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 67, 97, 114, 111, 117, 115,
				101, 108, 86, 105, 101, 119, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 101, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 64, 98, 101, 53,
				51, 100, 101, 53, 51, 55, 49, 48, 98, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 97,
				109, 112, 108, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 67, 111, 108, 111, 114, 67, 104,
				97, 110, 103, 101, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 142, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 105, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 64, 98, 101, 53, 51,
				100, 101, 53, 51, 55, 49, 48, 98, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 97, 109,
				112, 108, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 67, 111, 109, 112, 114, 101, 104, 101,
				110, 115, 105, 118, 101, 82, 105, 103, 69, 120,
				97, 109, 112, 108, 101, 85, 73, 92, 65, 110,
				105, 109, 97, 116, 111, 114, 79, 118, 101, 114,
				114, 105, 100, 101, 76, 97, 121, 101, 114, 87,
				101, 105, 103, 116, 104, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 137, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 105, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 64, 98, 101, 53, 51,
				100, 101, 53, 51, 55, 49, 48, 98, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 97, 109,
				112, 108, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 67, 111, 109, 112, 114, 101, 104, 101,
				110, 115, 105, 118, 101, 82, 105, 103, 69, 120,
				97, 109, 112, 108, 101, 85, 73, 92, 67, 97,
				110, 118, 97, 115, 71, 114, 111, 117, 112, 65,
				108, 112, 104, 97, 84, 111, 103, 103, 108, 101,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				132, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 105,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				64, 98, 101, 53, 51, 100, 101, 53, 51, 55,
				49, 48, 98, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 83, 97, 109, 112, 108, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 67, 111, 109,
				112, 114, 101, 104, 101, 110, 115, 105, 118, 101,
				82, 105, 103, 69, 120, 97, 109, 112, 108, 101,
				85, 73, 92, 71, 114, 105, 100, 83, 112, 97,
				99, 105, 110, 103, 83, 99, 97, 108, 101, 114,
				46, 99, 115, 0, 0, 0, 2, 0, 0, 0,
				125, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 105,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				64, 98, 101, 53, 51, 100, 101, 53, 51, 55,
				49, 48, 98, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 83, 97, 109, 112, 108, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 67, 111, 109,
				112, 114, 101, 104, 101, 110, 115, 105, 118, 101,
				82, 105, 103, 69, 120, 97, 109, 112, 108, 101,
				85, 73, 92, 80, 97, 103, 101, 83, 99, 114,
				111, 108, 108, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 133, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 105, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 64, 98, 101, 53, 51, 100, 101,
				53, 51, 55, 49, 48, 98, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 83, 97, 109, 112, 108,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				67, 111, 109, 112, 114, 101, 104, 101, 110, 115,
				105, 118, 101, 82, 105, 103, 69, 120, 97, 109,
				112, 108, 101, 85, 73, 92, 82, 101, 99, 116,
				83, 105, 122, 101, 67, 111, 110, 115, 116, 114,
				97, 105, 110, 116, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 137, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 105, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 64, 98, 101, 53, 51, 100,
				101, 53, 51, 55, 49, 48, 98, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 83, 97, 109, 112,
				108, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 67, 111, 109, 112, 114, 101, 104, 101, 110,
				115, 105, 118, 101, 82, 105, 103, 69, 120, 97,
				109, 112, 108, 101, 85, 73, 92, 82, 111, 117,
				110, 100, 101, 100, 66, 111, 120, 85, 73, 80,
				114, 111, 112, 101, 114, 116, 105, 101, 115, 46,
				99, 115, 0, 0, 0, 2, 0, 0, 0, 140,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 105, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 64,
				98, 101, 53, 51, 100, 101, 53, 51, 55, 49,
				48, 98, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 97, 109, 112, 108, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 67, 111, 109, 112,
				114, 101, 104, 101, 110, 115, 105, 118, 101, 82,
				105, 103, 69, 120, 97, 109, 112, 108, 101, 85,
				73, 92, 82, 111, 117, 110, 100, 101, 100, 66,
				111, 120, 86, 105, 100, 101, 111, 67, 111, 110,
				116, 114, 111, 108, 108, 101, 114, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 127, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 105, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 64, 98, 101,
				53, 51, 100, 101, 53, 51, 55, 49, 48, 98,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				97, 109, 112, 108, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 67, 111, 109, 112, 114, 101,
				104, 101, 110, 115, 105, 118, 101, 82, 105, 103,
				69, 120, 97, 109, 112, 108, 101, 85, 73, 92,
				83, 119, 105, 112, 101, 71, 101, 115, 116, 117,
				114, 101, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 128, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 105, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 64, 98, 101, 53, 51, 100, 101, 53,
				51, 55, 49, 48, 98, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 83, 97, 109, 112, 108, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 67,
				111, 109, 112, 114, 101, 104, 101, 110, 115, 105,
				118, 101, 82, 105, 103, 69, 120, 97, 109, 112,
				108, 101, 85, 73, 92, 86, 105, 114, 116, 117,
				97, 108, 76, 97, 121, 111, 117, 116, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 103, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 105, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 64, 98,
				101, 53, 51, 100, 101, 53, 51, 55, 49, 48,
				98, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				83, 97, 109, 112, 108, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 67, 111, 117, 110, 116,
				100, 111, 119, 110, 84, 105, 109, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 108,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 105, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 64,
				98, 101, 53, 51, 100, 101, 53, 51, 55, 49,
				48, 98, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 97, 109, 112, 108, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 69, 110, 97, 98,
				108, 101, 84, 97, 114, 103, 101, 116, 79, 110,
				83, 116, 97, 114, 116, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 108, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 105, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 64, 98, 101, 53, 51,
				100, 101, 53, 51, 55, 49, 48, 98, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 97, 109,
				112, 108, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 70, 97, 100, 101, 84, 101, 120, 116,
				65, 102, 116, 101, 114, 65, 99, 116, 105, 118,
				101, 46, 99, 115, 0, 0, 0, 3, 0, 0,
				0, 128, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				105, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 64, 98, 101, 53, 51, 100, 101, 53, 51,
				55, 49, 48, 98, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 83, 97, 109, 112, 108, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 72, 97,
				110, 100, 71, 114, 97, 98, 82, 101, 99, 111,
				114, 100, 92, 72, 97, 110, 100, 71, 114, 97,
				98, 80, 111, 115, 101, 76, 105, 118, 101, 82,
				101, 99, 111, 114, 100, 101, 114, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 118, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 105, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 64, 98, 101,
				53, 51, 100, 101, 53, 51, 55, 49, 48, 98,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				97, 109, 112, 108, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 72, 97, 110, 100, 71, 114,
				97, 98, 82, 101, 99, 111, 114, 100, 92, 84,
				105, 109, 101, 114, 85, 73, 67, 111, 110, 116,
				114, 111, 108, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 117, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 105, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 64, 98, 101, 53, 51, 100, 101,
				53, 51, 55, 49, 48, 98, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 83, 97, 109, 112, 108,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				72, 97, 110, 100, 71, 114, 97, 98, 85, 115,
				101, 92, 69, 102, 102, 101, 99, 116, 115, 92,
				77, 101, 115, 104, 66, 108, 105, 116, 46, 99,
				115, 0, 0, 0, 2, 0, 0, 0, 130, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 105, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 64, 98,
				101, 53, 51, 100, 101, 53, 51, 55, 49, 48,
				98, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				83, 97, 109, 112, 108, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 72, 97, 110, 100, 71,
				114, 97, 98, 85, 115, 101, 92, 69, 102, 102,
				101, 99, 116, 115, 92, 87, 97, 116, 101, 114,
				83, 112, 114, 97, 121, 92, 87, 97, 116, 101,
				114, 83, 112, 114, 97, 121, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 147, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 64, 98, 101, 53,
				51, 100, 101, 53, 51, 55, 49, 48, 98, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 97,
				109, 112, 108, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 72, 97, 110, 100, 71, 114, 97,
				98, 85, 115, 101, 92, 69, 102, 102, 101, 99,
				116, 115, 92, 87, 97, 116, 101, 114, 83, 112,
				114, 97, 121, 92, 87, 97, 116, 101, 114, 83,
				112, 114, 97, 121, 78, 111, 122, 122, 108, 101,
				84, 114, 97, 110, 115, 102, 111, 114, 109, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 126, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				105, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 64, 98, 101, 53, 51, 100, 101, 53, 51,
				55, 49, 48, 98, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 83, 97, 109, 112, 108, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 72, 97,
				110, 100, 71, 114, 97, 98, 85, 115, 101, 92,
				82, 101, 110, 100, 101, 114, 105, 110, 103, 92,
				66, 97, 115, 105, 99, 80, 66, 82, 71, 108,
				111, 98, 97, 108, 115, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 109, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 105, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 64, 98, 101, 53, 51,
				100, 101, 53, 51, 55, 49, 48, 98, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 97, 109,
				112, 108, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 72, 105, 100, 101, 72, 97, 110, 100,
				86, 105, 115, 117, 97, 108, 79, 110, 71, 114,
				97, 98, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 112, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 105, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 64, 98, 101, 53, 51, 100, 101, 53,
				51, 55, 49, 48, 98, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 83, 97, 109, 112, 108, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 73,
				110, 116, 101, 114, 97, 99, 116, 97, 98, 108,
				101, 79, 98, 106, 101, 99, 116, 76, 97, 98,
				101, 108, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 115, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 105, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 64, 98, 101, 53, 51, 100, 101, 53,
				51, 55, 49, 48, 98, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 83, 97, 109, 112, 108, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 76,
				111, 99, 111, 109, 111, 116, 105, 111, 110, 92,
				65, 100, 106, 117, 115, 116, 97, 98, 108, 101,
				65, 117, 100, 105, 111, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 151, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 105, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 64, 98, 101, 53, 51,
				100, 101, 53, 51, 55, 49, 48, 98, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 97, 109,
				112, 108, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 76, 111, 99, 111, 109, 111, 116, 105,
				111, 110, 92, 76, 111, 99, 111, 109, 111, 116,
				105, 111, 110, 83, 101, 116, 116, 105, 110, 103,
				115, 92, 76, 111, 99, 111, 109, 111, 116, 105,
				111, 110, 67, 111, 109, 102, 111, 114, 116, 86,
				105, 103, 110, 101, 116, 116, 101, 83, 101, 116,
				116, 105, 110, 103, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 142, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 105, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 64, 98, 101, 53, 51, 100,
				101, 53, 51, 55, 49, 48, 98, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 83, 97, 109, 112,
				108, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 76, 111, 99, 111, 109, 111, 116, 105, 111,
				110, 92, 76, 111, 99, 111, 109, 111, 116, 105,
				111, 110, 83, 101, 116, 116, 105, 110, 103, 115,
				92, 76, 111, 99, 111, 109, 111, 116, 105, 111,
				110, 83, 101, 97, 116, 101, 100, 83, 101, 116,
				116, 105, 110, 103, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 146, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 105, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 64, 98, 101, 53, 51, 100,
				101, 53, 51, 55, 49, 48, 98, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 83, 97, 109, 112,
				108, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 76, 111, 99, 111, 109, 111, 116, 105, 111,
				110, 92, 76, 111, 99, 111, 109, 111, 116, 105,
				111, 110, 83, 101, 116, 116, 105, 110, 103, 115,
				92, 76, 111, 99, 111, 109, 111, 116, 105, 111,
				110, 84, 117, 114, 110, 83, 108, 105, 100, 101,
				114, 83, 101, 116, 116, 105, 110, 103, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 130, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 105, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 64, 98,
				101, 53, 51, 100, 101, 53, 51, 55, 49, 48,
				98, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				83, 97, 109, 112, 108, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 76, 111, 99, 111, 109,
				111, 116, 105, 111, 110, 92, 76, 111, 99, 111,
				109, 111, 116, 105, 111, 110, 83, 101, 116, 116,
				105, 110, 103, 115, 92, 77, 101, 110, 117, 84,
				111, 103, 103, 108, 101, 114, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 137, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 64, 98, 101, 53,
				51, 100, 101, 53, 51, 55, 49, 48, 98, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 97,
				109, 112, 108, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 76, 111, 99, 111, 109, 111, 116,
				105, 111, 110, 92, 76, 111, 99, 111, 109, 111,
				116, 105, 111, 110, 83, 101, 116, 116, 105, 110,
				103, 115, 92, 84, 111, 103, 103, 108, 101, 114,
				65, 99, 116, 105, 118, 101, 83, 116, 97, 116,
				101, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 144, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				105, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 64, 98, 101, 53, 51, 100, 101, 53, 51,
				55, 49, 48, 98, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 83, 97, 109, 112, 108, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 76, 111,
				99, 111, 109, 111, 116, 105, 111, 110, 92, 76,
				111, 99, 111, 109, 111, 116, 105, 111, 110, 84,
				117, 116, 111, 114, 105, 97, 108, 65, 110, 105,
				109, 97, 116, 105, 111, 110, 85, 110, 105, 116,
				121, 69, 118, 101, 110, 116, 87, 114, 97, 112,
				112, 101, 114, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 133, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 105, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 64, 98, 101, 53, 51, 100, 101,
				53, 51, 55, 49, 48, 98, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 83, 97, 109, 112, 108,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				76, 111, 99, 111, 109, 111, 116, 105, 111, 110,
				92, 76, 111, 99, 111, 109, 111, 116, 105, 111,
				110, 84, 117, 116, 111, 114, 105, 97, 108, 80,
				114, 111, 103, 114, 101, 115, 115, 84, 114, 97,
				99, 107, 101, 114, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 128, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 105, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 64, 98, 101, 53, 51, 100,
				101, 53, 51, 55, 49, 48, 98, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 83, 97, 109, 112,
				108, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 76, 111, 99, 111, 109, 111, 116, 105, 111,
				110, 92, 76, 111, 99, 111, 109, 111, 116, 105,
				111, 110, 84, 117, 116, 111, 114, 105, 97, 108,
				84, 117, 114, 110, 86, 105, 115, 117, 97, 108,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				114, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 105,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				64, 98, 101, 53, 51, 100, 101, 53, 51, 55,
				49, 48, 98, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 83, 97, 109, 112, 108, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 76, 111, 99,
				111, 109, 111, 116, 105, 111, 110, 92, 76, 111,
				99, 111, 109, 111, 116, 111, 114, 83, 111, 117,
				110, 100, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 101, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 105, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 64, 98, 101, 53, 51, 100, 101, 53,
				51, 55, 49, 48, 98, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 83, 97, 109, 112, 108, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 76,
				111, 111, 107, 65, 116, 84, 97, 114, 103, 101,
				116, 46, 99, 115, 0, 0, 0, 2, 0, 0,
				0, 117, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				105, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 64, 98, 101, 53, 51, 100, 101, 53, 51,
				55, 49, 48, 98, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 83, 97, 109, 112, 108, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 77, 111,
				118, 101, 82, 101, 108, 97, 116, 105, 118, 101,
				84, 111, 84, 97, 114, 103, 101, 116, 80, 114,
				111, 118, 105, 100, 101, 114, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 115, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 64, 98, 101, 53,
				51, 100, 101, 53, 51, 55, 49, 48, 98, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 97,
				109, 112, 108, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 77, 117, 108, 116, 105, 77, 111,
				100, 97, 108, 92, 83, 108, 105, 110, 103, 115,
				104, 111, 116, 80, 101, 108, 108, 101, 116, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 126,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 105, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 64,
				98, 101, 53, 51, 100, 101, 53, 51, 55, 49,
				48, 98, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 97, 109, 112, 108, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 80, 97, 108, 109,
				77, 101, 110, 117, 92, 68, 111, 109, 105, 110,
				97, 110, 116, 72, 97, 110, 100, 71, 97, 109,
				101, 79, 98, 106, 101, 99, 116, 70, 105, 108,
				116, 101, 114, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 137, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 105, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 64, 98, 101, 53, 51, 100, 101,
				53, 51, 55, 49, 48, 98, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 83, 97, 109, 112, 108,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				80, 97, 108, 109, 77, 101, 110, 117, 92, 77,
				97, 116, 99, 104, 78, 111, 110, 68, 111, 109,
				105, 110, 97, 110, 116, 80, 97, 108, 109, 87,
				111, 114, 108, 100, 83, 112, 97, 99, 101, 84,
				114, 97, 110, 115, 102, 111, 114, 109, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 113, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 105, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 64, 98,
				101, 53, 51, 100, 101, 53, 51, 55, 49, 48,
				98, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				83, 97, 109, 112, 108, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 80, 97, 108, 109, 77,
				101, 110, 117, 92, 80, 97, 108, 109, 77, 101,
				110, 117, 69, 120, 97, 109, 112, 108, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 127,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 105, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 64,
				98, 101, 53, 51, 100, 101, 53, 51, 55, 49,
				48, 98, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 97, 109, 112, 108, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 80, 97, 108, 109,
				77, 101, 110, 117, 92, 80, 97, 108, 109, 77,
				101, 110, 117, 69, 120, 97, 109, 112, 108, 101,
				66, 117, 116, 116, 111, 110, 72, 97, 110, 100,
				108, 101, 114, 115, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 143, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 105, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 64, 98, 101, 53, 51, 100,
				101, 53, 51, 55, 49, 48, 98, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 83, 97, 109, 112,
				108, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 80, 97, 110, 101, 108, 87, 105, 116, 104,
				77, 97, 110, 105, 112, 117, 108, 97, 116, 111,
				114, 115, 92, 65, 110, 99, 104, 111, 114, 101,
				100, 87, 111, 114, 108, 100, 83, 112, 97, 99,
				101, 68, 105, 115, 116, 97, 110, 99, 101, 83,
				99, 97, 108, 101, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 134, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 105, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 64, 98, 101, 53, 51,
				100, 101, 53, 51, 55, 49, 48, 98, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 97, 109,
				112, 108, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 80, 97, 110, 101, 108, 87, 105, 116,
				104, 77, 97, 110, 105, 112, 117, 108, 97, 116,
				111, 114, 115, 92, 65, 114, 99, 65, 102, 102,
				111, 114, 100, 97, 110, 99, 101, 67, 111, 110,
				116, 114, 111, 108, 108, 101, 114, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 131, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 105, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 64, 98, 101,
				53, 51, 100, 101, 53, 51, 55, 49, 48, 98,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				97, 109, 112, 108, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 80, 97, 110, 101, 108, 87,
				105, 116, 104, 77, 97, 110, 105, 112, 117, 108,
				97, 116, 111, 114, 115, 92, 67, 97, 110, 118,
				97, 115, 83, 105, 122, 101, 67, 111, 110, 115,
				116, 114, 97, 105, 110, 116, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 133, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 64, 98, 101, 53,
				51, 100, 101, 53, 51, 55, 49, 48, 98, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 97,
				109, 112, 108, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 80, 97, 110, 101, 108, 87, 105,
				116, 104, 77, 97, 110, 105, 112, 117, 108, 97,
				116, 111, 114, 115, 92, 67, 111, 108, 108, 105,
				100, 101, 114, 83, 105, 122, 101, 67, 111, 110,
				115, 116, 114, 97, 105, 110, 116, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 142, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 105, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 64, 98, 101,
				53, 51, 100, 101, 53, 51, 55, 49, 48, 98,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				97, 109, 112, 108, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 80, 97, 110, 101, 108, 87,
				105, 116, 104, 77, 97, 110, 105, 112, 117, 108,
				97, 116, 111, 114, 115, 92, 77, 97, 110, 105,
				112, 117, 108, 97, 116, 111, 114, 65, 102, 102,
				111, 114, 100, 97, 110, 99, 101, 67, 111, 110,
				116, 114, 111, 108, 108, 101, 114, 46, 99, 115,
				0, 0, 0, 2, 0, 0, 0, 134, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 105, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 64, 98, 101,
				53, 51, 100, 101, 53, 51, 55, 49, 48, 98,
				92, 82, 117, 110, 116, 105, 109, 101, 92, 83,
				97, 109, 112, 108, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 80, 97, 110, 101, 108, 87,
				105, 116, 104, 77, 97, 110, 105, 112, 117, 108,
				97, 116, 111, 114, 115, 92, 79, 110, 101, 71,
				114, 97, 98, 83, 99, 97, 108, 101, 84, 114,
				97, 110, 115, 102, 111, 114, 109, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 149,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 105, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 64,
				98, 101, 53, 51, 100, 101, 53, 51, 55, 49,
				48, 98, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 97, 109, 112, 108, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 80, 97, 110, 101,
				108, 87, 105, 116, 104, 77, 97, 110, 105, 112,
				117, 108, 97, 116, 111, 114, 115, 92, 79, 112,
				97, 99, 105, 116, 121, 70, 114, 111, 109, 65,
				110, 105, 109, 97, 116, 101, 100, 84, 114, 97,
				110, 115, 102, 111, 114, 109, 67, 111, 110, 116,
				114, 111, 108, 108, 101, 114, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 126, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 64, 98, 101, 53,
				51, 100, 101, 53, 51, 55, 49, 48, 98, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 97,
				109, 112, 108, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 80, 97, 110, 101, 108, 87, 105,
				116, 104, 77, 97, 110, 105, 112, 117, 108, 97,
				116, 111, 114, 115, 92, 80, 97, 110, 101, 108,
				72, 111, 118, 101, 114, 83, 116, 97, 116, 101,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				121, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 105,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				64, 98, 101, 53, 51, 100, 101, 53, 51, 55,
				49, 48, 98, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 83, 97, 109, 112, 108, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 80, 97, 110,
				101, 108, 87, 105, 116, 104, 77, 97, 110, 105,
				112, 117, 108, 97, 116, 111, 114, 115, 92, 80,
				97, 110, 101, 108, 83, 101, 116, 117, 112, 46,
				99, 115, 0, 0, 0, 3, 0, 0, 0, 158,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 105, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 64,
				98, 101, 53, 51, 100, 101, 53, 51, 55, 49,
				48, 98, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 97, 109, 112, 108, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 80, 97, 110, 101,
				108, 87, 105, 116, 104, 77, 97, 110, 105, 112,
				117, 108, 97, 116, 111, 114, 115, 92, 80, 97,
				110, 101, 108, 87, 105, 116, 104, 77, 97, 110,
				105, 112, 117, 108, 97, 116, 111, 114, 115, 66,
				111, 114, 100, 101, 114, 65, 102, 102, 111, 114,
				100, 97, 110, 99, 101, 67, 111, 110, 116, 114,
				111, 108, 108, 101, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 145, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 105, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 64, 98, 101, 53, 51,
				100, 101, 53, 51, 55, 49, 48, 98, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 97, 109,
				112, 108, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 80, 97, 110, 101, 108, 87, 105, 116,
				104, 77, 97, 110, 105, 112, 117, 108, 97, 116,
				111, 114, 115, 92, 80, 97, 110, 101, 108, 87,
				105, 116, 104, 77, 97, 110, 105, 112, 117, 108,
				97, 116, 111, 114, 115, 83, 116, 97, 116, 101,
				83, 105, 103, 110, 97, 108, 101, 114, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 130, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 105, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 64, 98,
				101, 53, 51, 100, 101, 53, 51, 55, 49, 48,
				98, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				83, 97, 109, 112, 108, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 80, 97, 110, 101, 108,
				87, 105, 116, 104, 77, 97, 110, 105, 112, 117,
				108, 97, 116, 111, 114, 115, 92, 80, 97, 114,
				101, 110, 116, 83, 99, 97, 108, 101, 73, 110,
				118, 101, 114, 116, 101, 114, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 132, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 64, 98, 101, 53,
				51, 100, 101, 53, 51, 55, 49, 48, 98, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 97,
				109, 112, 108, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 80, 97, 110, 101, 108, 87, 105,
				116, 104, 77, 97, 110, 105, 112, 117, 108, 97,
				116, 111, 114, 115, 92, 83, 107, 105, 110, 110,
				101, 100, 82, 111, 117, 110, 100, 101, 100, 66,
				111, 120, 77, 101, 115, 104, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 135, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 64, 98, 101, 53,
				51, 100, 101, 53, 51, 55, 49, 48, 98, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 97,
				109, 112, 108, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 80, 97, 110, 101, 108, 87, 105,
				116, 104, 77, 97, 110, 105, 112, 117, 108, 97,
				116, 111, 114, 115, 92, 85, 110, 105, 111, 110,
				67, 108, 105, 112, 112, 101, 100, 80, 108, 97,
				110, 101, 83, 117, 114, 102, 97, 99, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 143,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 105, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 64,
				98, 101, 53, 51, 100, 101, 53, 51, 55, 49,
				48, 98, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 97, 109, 112, 108, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 80, 97, 110, 101,
				108, 87, 105, 116, 104, 77, 97, 110, 105, 112,
				117, 108, 97, 116, 111, 114, 115, 92, 85, 112,
				100, 97, 116, 101, 82, 111, 117, 110, 100, 101,
				100, 66, 111, 120, 65, 110, 99, 104, 111, 114,
				67, 111, 110, 115, 116, 114, 97, 105, 110, 116,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				102, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 105,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				64, 98, 101, 53, 51, 100, 101, 53, 51, 55,
				49, 48, 98, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 83, 97, 109, 112, 108, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 80, 111, 115,
				101, 85, 115, 101, 83, 97, 109, 112, 108, 101,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				102, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 105,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				64, 98, 101, 53, 51, 100, 101, 53, 51, 55,
				49, 48, 98, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 83, 97, 109, 112, 108, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 82, 101, 115,
				112, 97, 119, 110, 79, 110, 68, 114, 111, 112,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				108, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 105,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				64, 98, 101, 53, 51, 100, 101, 53, 51, 55,
				49, 48, 98, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 83, 97, 109, 112, 108, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 82, 111, 116,
				97, 116, 105, 111, 110, 65, 117, 100, 105, 111,
				69, 118, 101, 110, 116, 115, 46, 99, 115, 0,
				0, 0, 3, 0, 0, 0, 105, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 64, 98, 101, 53,
				51, 100, 101, 53, 51, 55, 49, 48, 98, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 97,
				109, 112, 108, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 83, 97, 109, 112, 108, 101, 83,
				99, 101, 110, 101, 71, 114, 111, 117, 112, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 105,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 105, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 64,
				98, 101, 53, 51, 100, 101, 53, 51, 55, 49,
				48, 98, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 97, 109, 112, 108, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 83, 97, 109, 112,
				108, 101, 115, 73, 110, 102, 111, 80, 97, 110,
				101, 108, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 105, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 105, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 64, 98, 101, 53, 51, 100, 101, 53,
				51, 55, 49, 48, 98, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 83, 97, 109, 112, 108, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 83,
				99, 97, 108, 101, 65, 117, 100, 105, 111, 69,
				118, 101, 110, 116, 115, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 102, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 105, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 64, 98, 101, 53, 51,
				100, 101, 53, 51, 55, 49, 48, 98, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 97, 109,
				112, 108, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 83, 99, 97, 108, 101, 77, 111, 100,
				105, 102, 105, 101, 114, 46, 99, 115, 0, 0,
				0, 3, 0, 0, 0, 105, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 105, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 64, 98, 101, 53, 51,
				100, 101, 53, 51, 55, 49, 48, 98, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 83, 97, 109,
				112, 108, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 83, 99, 101, 110, 101, 71, 114, 111,
				117, 112, 76, 111, 97, 100, 101, 114, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 100, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 105, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 64, 98,
				101, 53, 51, 100, 101, 53, 51, 55, 49, 48,
				98, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				83, 97, 109, 112, 108, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 83, 99, 101, 110, 101,
				76, 111, 97, 100, 101, 114, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 109, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 64, 98, 101, 53,
				51, 100, 101, 53, 51, 55, 49, 48, 98, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 97,
				109, 112, 108, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 83, 104, 111, 117, 108, 100, 72,
				105, 100, 101, 72, 97, 110, 100, 79, 110, 71,
				114, 97, 98, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 110, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 105, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 64, 98, 101, 53, 51, 100, 101,
				53, 51, 55, 49, 48, 98, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 83, 97, 109, 112, 108,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				83, 110, 97, 112, 92, 67, 111, 110, 115, 116,
				97, 110, 116, 82, 111, 116, 97, 116, 105, 111,
				110, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 130, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				105, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 64, 98, 101, 53, 51, 100, 101, 53, 51,
				55, 49, 48, 98, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 83, 97, 109, 112, 108, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 83, 110,
				97, 112, 92, 76, 105, 115, 116, 83, 110, 97,
				112, 80, 111, 115, 101, 68, 101, 108, 101, 103,
				97, 116, 101, 82, 111, 117, 110, 100, 101, 100,
				66, 111, 120, 86, 105, 115, 117, 97, 108, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 99,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 105, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 64,
				98, 101, 53, 51, 100, 101, 53, 51, 55, 49,
				48, 98, 92, 82, 117, 110, 116, 105, 109, 101,
				92, 83, 97, 109, 112, 108, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 83, 116, 97, 121,
				73, 110, 86, 105, 101, 119, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 122, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 64, 98, 101, 53,
				51, 100, 101, 53, 51, 55, 49, 48, 98, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 97,
				109, 112, 108, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 85, 115, 101, 71, 114, 97, 98,
				80, 114, 101, 115, 115, 117, 114, 101, 92, 80,
				114, 101, 115, 115, 117, 114, 101, 66, 114, 101,
				97, 107, 97, 98, 108, 101, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 123, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 105, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 64, 98, 101, 53,
				51, 100, 101, 53, 51, 55, 49, 48, 98, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 83, 97,
				109, 112, 108, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 85, 115, 101, 71, 114, 97, 98,
				80, 114, 101, 115, 115, 117, 114, 101, 92, 80,
				114, 101, 115, 115, 117, 114, 101, 83, 113, 117,
				105, 115, 104, 97, 98, 108, 101, 46, 99, 115
			},
			TypesData = new byte[4677]
			{
				0, 0, 0, 0, 35, 79, 99, 117, 108, 117,
				115, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 124, 68, 105, 115, 97, 98, 108,
				101, 82, 97, 121, 99, 97, 115, 116, 101, 114,
				0, 0, 0, 0, 40, 79, 99, 117, 108, 117,
				115, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 83, 97, 109, 112, 108, 101,
				115, 124, 68, 114, 111, 112, 68, 111, 119, 110,
				71, 114, 111, 117, 112, 0, 0, 0, 0, 26,
				79, 99, 117, 108, 117, 115, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 124, 85,
				73, 84, 104, 101, 109, 101, 0, 0, 0, 0,
				40, 79, 99, 117, 108, 117, 115, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				85, 73, 84, 104, 101, 109, 101, 124, 69, 108,
				101, 109, 101, 110, 116, 67, 111, 108, 111, 114,
				115, 0, 0, 0, 0, 33, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 124, 85, 73, 84, 104, 101,
				109, 101, 77, 97, 110, 97, 103, 101, 114, 0,
				0, 0, 0, 31, 79, 99, 117, 108, 117, 115,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 124, 65, 117, 100, 105, 111, 80, 104,
				121, 115, 105, 99, 115, 0, 0, 0, 0, 47,
				79, 99, 117, 108, 117, 115, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 46, 65,
				117, 100, 105, 111, 80, 104, 121, 115, 105, 99,
				115, 124, 67, 111, 108, 108, 105, 115, 105, 111,
				110, 69, 118, 101, 110, 116, 115, 0, 0, 0,
				0, 30, 79, 99, 117, 108, 117, 115, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				124, 73, 109, 112, 97, 99, 116, 65, 117, 100,
				105, 111, 0, 0, 0, 0, 31, 79, 99, 117,
				108, 117, 115, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 124, 65, 117, 100, 105,
				111, 84, 114, 105, 103, 103, 101, 114, 0, 0,
				0, 0, 29, 79, 99, 117, 108, 117, 115, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 124, 77, 105, 110, 77, 97, 120, 80, 97,
				105, 114, 0, 0, 0, 0, 48, 79, 99, 117,
				108, 117, 115, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 46, 66, 111, 100, 121,
				46, 83, 97, 109, 112, 108, 101, 115, 124, 66,
				111, 100, 121, 80, 111, 115, 101, 83, 119, 105,
				116, 99, 104, 101, 114, 0, 0, 0, 0, 46,
				79, 99, 117, 108, 117, 115, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 46, 66,
				111, 100, 121, 46, 83, 97, 109, 112, 108, 101,
				115, 124, 76, 111, 99, 107, 101, 100, 66, 111,
				100, 121, 80, 111, 115, 101, 0, 0, 0, 0,
				52, 79, 99, 117, 108, 117, 115, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				66, 111, 100, 121, 46, 83, 97, 109, 112, 108,
				101, 115, 124, 80, 111, 115, 101, 67, 97, 112,
				116, 117, 114, 101, 67, 111, 117, 110, 116, 100,
				111, 119, 110, 0, 0, 0, 0, 52, 79, 99,
				117, 108, 117, 115, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 83, 97, 109,
				112, 108, 101, 115, 124, 67, 97, 110, 118, 97,
				115, 67, 111, 110, 115, 116, 97, 110, 116, 87,
				105, 100, 116, 104, 83, 99, 97, 108, 101, 114,
				0, 0, 0, 0, 39, 79, 99, 117, 108, 117,
				115, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 83, 97, 109, 112, 108, 101,
				115, 124, 67, 97, 114, 111, 117, 115, 101, 108,
				86, 105, 101, 119, 0, 0, 0, 0, 39, 79,
				99, 117, 108, 117, 115, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 46, 83, 97,
				109, 112, 108, 101, 115, 124, 67, 111, 108, 111,
				114, 67, 104, 97, 110, 103, 101, 114, 0, 0,
				0, 0, 54, 79, 99, 117, 108, 117, 115, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 46, 83, 97, 109, 112, 108, 101, 115, 124,
				65, 110, 105, 109, 97, 116, 111, 114, 79, 118,
				101, 114, 114, 105, 100, 101, 76, 97, 121, 101,
				114, 87, 101, 105, 103, 116, 104, 0, 0, 0,
				0, 23, 124, 67, 97, 110, 118, 97, 115, 71,
				114, 111, 117, 112, 65, 108, 112, 104, 97, 84,
				111, 103, 103, 108, 101, 0, 0, 0, 0, 18,
				124, 71, 114, 105, 100, 83, 112, 97, 99, 105,
				110, 103, 83, 99, 97, 108, 101, 114, 0, 0,
				0, 0, 11, 124, 80, 97, 103, 101, 83, 99,
				114, 111, 108, 108, 0, 0, 0, 0, 15, 80,
				97, 103, 101, 83, 99, 114, 111, 108, 108, 124,
				80, 97, 103, 101, 0, 0, 0, 0, 19, 124,
				82, 101, 99, 116, 83, 105, 122, 101, 67, 111,
				110, 115, 116, 114, 97, 105, 110, 116, 0, 0,
				0, 0, 23, 124, 82, 111, 117, 110, 100, 101,
				100, 66, 111, 120, 85, 73, 80, 114, 111, 112,
				101, 114, 116, 105, 101, 115, 0, 0, 0, 0,
				26, 124, 82, 111, 117, 110, 100, 101, 100, 66,
				111, 120, 86, 105, 100, 101, 111, 67, 111, 110,
				116, 114, 111, 108, 108, 101, 114, 0, 0, 0,
				0, 38, 82, 111, 117, 110, 100, 101, 100, 66,
				111, 120, 86, 105, 100, 101, 111, 67, 111, 110,
				116, 114, 111, 108, 108, 101, 114, 124, 66, 111,
				120, 65, 110, 105, 109, 97, 116, 105, 111, 110,
				0, 0, 0, 0, 13, 124, 83, 119, 105, 112,
				101, 71, 101, 115, 116, 117, 114, 101, 0, 0,
				0, 0, 14, 124, 86, 105, 114, 116, 117, 97,
				108, 76, 97, 121, 111, 117, 116, 0, 0, 0,
				0, 41, 79, 99, 117, 108, 117, 115, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				46, 83, 97, 109, 112, 108, 101, 115, 124, 67,
				111, 117, 110, 116, 100, 111, 119, 110, 84, 105,
				109, 101, 114, 0, 0, 0, 0, 46, 79, 99,
				117, 108, 117, 115, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 83, 97, 109,
				112, 108, 101, 115, 124, 69, 110, 97, 98, 108,
				101, 84, 97, 114, 103, 101, 116, 79, 110, 83,
				116, 97, 114, 116, 0, 0, 0, 0, 46, 79,
				99, 117, 108, 117, 115, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 46, 83, 97,
				109, 112, 108, 101, 115, 124, 70, 97, 100, 101,
				84, 101, 120, 116, 65, 102, 116, 101, 114, 65,
				99, 116, 105, 118, 101, 0, 0, 0, 0, 61,
				79, 99, 117, 108, 117, 115, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 46, 72,
				97, 110, 100, 71, 114, 97, 98, 46, 82, 101,
				99, 111, 114, 100, 101, 114, 124, 72, 97, 110,
				100, 71, 114, 97, 98, 80, 111, 115, 101, 76,
				105, 118, 101, 82, 101, 99, 111, 114, 100, 101,
				114, 0, 0, 0, 0, 74, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 72, 97, 110, 100, 71,
				114, 97, 98, 46, 82, 101, 99, 111, 114, 100,
				101, 114, 46, 72, 97, 110, 100, 71, 114, 97,
				98, 80, 111, 115, 101, 76, 105, 118, 101, 82,
				101, 99, 111, 114, 100, 101, 114, 124, 82, 101,
				99, 111, 114, 100, 101, 114, 83, 116, 101, 112,
				0, 0, 0, 0, 54, 79, 99, 117, 108, 117,
				115, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 72, 97, 110, 100, 71, 114,
				97, 98, 46, 82, 101, 99, 111, 114, 100, 101,
				114, 124, 82, 105, 103, 105, 100, 98, 111, 100,
				121, 68, 101, 116, 101, 99, 116, 111, 114, 0,
				0, 0, 0, 51, 79, 99, 117, 108, 117, 115,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 46, 72, 97, 110, 100, 71, 114, 97,
				98, 46, 82, 101, 99, 111, 114, 100, 101, 114,
				124, 84, 105, 109, 101, 114, 85, 73, 67, 111,
				110, 116, 114, 111, 108, 0, 0, 0, 0, 32,
				79, 99, 117, 108, 117, 115, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 46, 68,
				101, 109, 111, 124, 77, 101, 115, 104, 66, 108,
				105, 116, 0, 0, 0, 0, 34, 79, 99, 117,
				108, 117, 115, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 46, 68, 101, 109, 111,
				124, 87, 97, 116, 101, 114, 83, 112, 114, 97,
				121, 0, 0, 0, 0, 43, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 68, 101, 109, 111, 46,
				87, 97, 116, 101, 114, 83, 112, 114, 97, 121,
				124, 78, 111, 110, 65, 108, 108, 111, 99, 0,
				0, 0, 0, 51, 79, 99, 117, 108, 117, 115,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 46, 68, 101, 109, 111, 124, 87, 97,
				116, 101, 114, 83, 112, 114, 97, 121, 78, 111,
				122, 122, 108, 101, 84, 114, 97, 110, 115, 102,
				111, 114, 109, 101, 114, 0, 0, 0, 0, 39,
				79, 99, 117, 108, 117, 115, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 46, 68,
				101, 109, 111, 124, 66, 97, 115, 105, 99, 80,
				66, 82, 71, 108, 111, 98, 97, 108, 115, 0,
				0, 0, 0, 47, 79, 99, 117, 108, 117, 115,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 46, 83, 97, 109, 112, 108, 101, 115,
				124, 72, 105, 100, 101, 72, 97, 110, 100, 86,
				105, 115, 117, 97, 108, 79, 110, 71, 114, 97,
				98, 0, 0, 0, 0, 50, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 83, 97, 109, 112, 108,
				101, 115, 124, 73, 110, 116, 101, 114, 97, 99,
				116, 97, 98, 108, 101, 79, 98, 106, 101, 99,
				116, 76, 97, 98, 101, 108, 0, 0, 0, 0,
				45, 79, 99, 117, 108, 117, 115, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				76, 111, 99, 111, 109, 111, 116, 105, 111, 110,
				124, 65, 100, 106, 117, 115, 116, 97, 98, 108,
				101, 65, 117, 100, 105, 111, 0, 0, 0, 0,
				62, 79, 99, 117, 108, 117, 115, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				76, 111, 99, 111, 109, 111, 116, 105, 111, 110,
				124, 76, 111, 99, 111, 109, 111, 116, 105, 111,
				110, 67, 111, 109, 102, 111, 114, 116, 86, 105,
				103, 110, 101, 116, 116, 101, 83, 101, 116, 116,
				105, 110, 103, 0, 0, 0, 0, 53, 79, 99,
				117, 108, 117, 115, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 76, 111, 99,
				111, 109, 111, 116, 105, 111, 110, 124, 76, 111,
				99, 111, 109, 111, 116, 105, 111, 110, 83, 101,
				97, 116, 101, 100, 83, 101, 116, 116, 105, 110,
				103, 0, 0, 0, 0, 57, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 76, 111, 99, 111, 109,
				111, 116, 105, 111, 110, 124, 76, 111, 99, 111,
				109, 111, 116, 105, 111, 110, 84, 117, 114, 110,
				83, 108, 105, 100, 101, 114, 83, 101, 116, 116,
				105, 110, 103, 0, 0, 0, 0, 41, 79, 99,
				117, 108, 117, 115, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 76, 111, 99,
				111, 109, 111, 116, 105, 111, 110, 124, 77, 101,
				110, 117, 84, 111, 103, 103, 108, 101, 114, 0,
				0, 0, 0, 37, 79, 99, 117, 108, 117, 115,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 124, 84, 111, 103, 103, 108, 101, 114,
				65, 99, 116, 105, 118, 101, 83, 116, 97, 116,
				101, 0, 0, 0, 0, 71, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 83, 97, 109, 112, 108,
				101, 115, 124, 76, 111, 99, 111, 109, 111, 116,
				105, 111, 110, 84, 117, 116, 111, 114, 105, 97,
				108, 65, 110, 105, 109, 97, 116, 105, 111, 110,
				85, 110, 105, 116, 121, 69, 118, 101, 110, 116,
				87, 114, 97, 112, 112, 101, 114, 0, 0, 0,
				0, 60, 79, 99, 117, 108, 117, 115, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				46, 83, 97, 109, 112, 108, 101, 115, 124, 76,
				111, 99, 111, 109, 111, 116, 105, 111, 110, 84,
				117, 116, 111, 114, 105, 97, 108, 80, 114, 111,
				103, 114, 101, 115, 115, 84, 114, 97, 99, 107,
				101, 114, 0, 0, 0, 0, 55, 79, 99, 117,
				108, 117, 115, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 46, 83, 97, 109, 112,
				108, 101, 115, 124, 76, 111, 99, 111, 109, 111,
				116, 105, 111, 110, 84, 117, 116, 111, 114, 105,
				97, 108, 84, 117, 114, 110, 86, 105, 115, 117,
				97, 108, 0, 0, 0, 0, 44, 79, 99, 117,
				108, 117, 115, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 46, 76, 111, 99, 111,
				109, 111, 116, 105, 111, 110, 124, 76, 111, 99,
				111, 109, 111, 116, 111, 114, 83, 111, 117, 110,
				100, 0, 0, 0, 0, 39, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 83, 97, 109, 112, 108,
				101, 115, 124, 76, 111, 111, 107, 65, 116, 84,
				97, 114, 103, 101, 116, 0, 0, 0, 0, 29,
				124, 77, 111, 118, 101, 82, 101, 108, 97, 116,
				105, 118, 101, 84, 111, 84, 97, 114, 103, 101,
				116, 80, 114, 111, 118, 105, 100, 101, 114, 0,
				0, 0, 0, 21, 124, 77, 111, 118, 101, 82,
				101, 108, 97, 116, 105, 118, 101, 84, 111, 84,
				97, 114, 103, 101, 116, 0, 0, 0, 0, 42,
				79, 99, 117, 108, 117, 115, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 46, 83,
				97, 109, 112, 108, 101, 115, 124, 83, 108, 105,
				110, 103, 115, 104, 111, 116, 80, 101, 108, 108,
				101, 116, 0, 0, 0, 0, 64, 79, 99, 117,
				108, 117, 115, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 46, 83, 97, 109, 112,
				108, 101, 115, 46, 80, 97, 108, 109, 77, 101,
				110, 117, 124, 68, 111, 109, 105, 110, 97, 110,
				116, 72, 97, 110, 100, 71, 97, 109, 101, 79,
				98, 106, 101, 99, 116, 70, 105, 108, 116, 101,
				114, 0, 0, 0, 0, 75, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 83, 97, 109, 112, 108,
				101, 115, 46, 80, 97, 108, 109, 77, 101, 110,
				117, 124, 77, 97, 116, 99, 104, 78, 111, 110,
				68, 111, 109, 105, 110, 97, 110, 116, 80, 97,
				108, 109, 87, 111, 114, 108, 100, 83, 112, 97,
				99, 101, 84, 114, 97, 110, 115, 102, 111, 114,
				109, 0, 0, 0, 0, 51, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 83, 97, 109, 112, 108,
				101, 115, 46, 80, 97, 108, 109, 77, 101, 110,
				117, 124, 80, 97, 108, 109, 77, 101, 110, 117,
				69, 120, 97, 109, 112, 108, 101, 0, 0, 0,
				0, 65, 79, 99, 117, 108, 117, 115, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				46, 83, 97, 109, 112, 108, 101, 115, 46, 80,
				97, 108, 109, 77, 101, 110, 117, 124, 80, 97,
				108, 109, 77, 101, 110, 117, 69, 120, 97, 109,
				112, 108, 101, 66, 117, 116, 116, 111, 110, 72,
				97, 110, 100, 108, 101, 114, 115, 0, 0, 0,
				0, 59, 79, 99, 117, 108, 117, 115, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				46, 83, 97, 109, 112, 108, 101, 115, 124, 65,
				110, 99, 104, 111, 114, 101, 100, 87, 111, 114,
				108, 100, 83, 112, 97, 99, 101, 68, 105, 115,
				116, 97, 110, 99, 101, 83, 99, 97, 108, 101,
				114, 0, 0, 0, 0, 50, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 83, 97, 109, 112, 108,
				101, 115, 124, 65, 114, 99, 65, 102, 102, 111,
				114, 100, 97, 110, 99, 101, 67, 111, 110, 116,
				114, 111, 108, 108, 101, 114, 0, 0, 0, 0,
				21, 124, 67, 97, 110, 118, 97, 115, 83, 105,
				122, 101, 67, 111, 110, 115, 116, 114, 97, 105,
				110, 116, 0, 0, 0, 0, 23, 124, 67, 111,
				108, 108, 105, 100, 101, 114, 83, 105, 122, 101,
				67, 111, 110, 115, 116, 114, 97, 105, 110, 116,
				0, 0, 0, 0, 58, 79, 99, 117, 108, 117,
				115, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 83, 97, 109, 112, 108, 101,
				115, 124, 77, 97, 110, 105, 112, 117, 108, 97,
				116, 111, 114, 65, 102, 102, 111, 114, 100, 97,
				110, 99, 101, 67, 111, 110, 116, 114, 111, 108,
				108, 101, 114, 0, 0, 0, 0, 50, 79, 99,
				117, 108, 117, 115, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 83, 97, 109,
				112, 108, 101, 115, 124, 79, 110, 101, 71, 114,
				97, 98, 83, 99, 97, 108, 101, 84, 114, 97,
				110, 115, 102, 111, 114, 109, 101, 114, 0, 0,
				0, 0, 74, 79, 99, 117, 108, 117, 115, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 46, 83, 97, 109, 112, 108, 101, 115, 46,
				79, 110, 101, 71, 114, 97, 98, 83, 99, 97,
				108, 101, 84, 114, 97, 110, 115, 102, 111, 114,
				109, 101, 114, 124, 79, 110, 101, 71, 114, 97,
				98, 83, 99, 97, 108, 101, 67, 111, 110, 115,
				116, 114, 97, 105, 110, 116, 115, 0, 0, 0,
				0, 65, 79, 99, 117, 108, 117, 115, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				46, 83, 97, 109, 112, 108, 101, 115, 124, 79,
				112, 97, 99, 105, 116, 121, 70, 114, 111, 109,
				65, 110, 105, 109, 97, 116, 101, 100, 84, 114,
				97, 110, 115, 102, 111, 114, 109, 67, 111, 110,
				116, 114, 111, 108, 108, 101, 114, 0, 0, 0,
				0, 16, 124, 80, 97, 110, 101, 108, 72, 111,
				118, 101, 114, 83, 116, 97, 116, 101, 0, 0,
				0, 0, 11, 124, 80, 97, 110, 101, 108, 83,
				101, 116, 117, 112, 0, 0, 0, 0, 74, 79,
				99, 117, 108, 117, 115, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 46, 83, 97,
				109, 112, 108, 101, 115, 124, 80, 97, 110, 101,
				108, 87, 105, 116, 104, 77, 97, 110, 105, 112,
				117, 108, 97, 116, 111, 114, 115, 66, 111, 114,
				100, 101, 114, 65, 102, 102, 111, 114, 100, 97,
				110, 99, 101, 67, 111, 110, 116, 114, 111, 108,
				108, 101, 114, 0, 0, 0, 0, 85, 79, 99,
				117, 108, 117, 115, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 83, 97, 109,
				112, 108, 101, 115, 46, 80, 97, 110, 101, 108,
				87, 105, 116, 104, 77, 97, 110, 105, 112, 117,
				108, 97, 116, 111, 114, 115, 66, 111, 114, 100,
				101, 114, 65, 102, 102, 111, 114, 100, 97, 110,
				99, 101, 67, 111, 110, 116, 114, 111, 108, 108,
				101, 114, 124, 65, 102, 102, 111, 114, 100, 97,
				110, 99, 101, 0, 0, 0, 0, 84, 79, 99,
				117, 108, 117, 115, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 83, 97, 109,
				112, 108, 101, 115, 46, 80, 97, 110, 101, 108,
				87, 105, 116, 104, 77, 97, 110, 105, 112, 117,
				108, 97, 116, 111, 114, 115, 66, 111, 114, 100,
				101, 114, 65, 102, 102, 111, 114, 100, 97, 110,
				99, 101, 67, 111, 110, 116, 114, 111, 108, 108,
				101, 114, 124, 70, 97, 100, 101, 80, 111, 105,
				110, 116, 0, 0, 0, 0, 61, 79, 99, 117,
				108, 117, 115, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 46, 83, 97, 109, 112,
				108, 101, 115, 124, 80, 97, 110, 101, 108, 87,
				105, 116, 104, 77, 97, 110, 105, 112, 117, 108,
				97, 116, 111, 114, 115, 83, 116, 97, 116, 101,
				83, 105, 103, 110, 97, 108, 101, 114, 0, 0,
				0, 0, 46, 79, 99, 117, 108, 117, 115, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 46, 83, 97, 109, 112, 108, 101, 115, 124,
				80, 97, 114, 101, 110, 116, 83, 99, 97, 108,
				101, 73, 110, 118, 101, 114, 116, 101, 114, 0,
				0, 0, 0, 22, 124, 83, 107, 105, 110, 110,
				101, 100, 82, 111, 117, 110, 100, 101, 100, 66,
				111, 120, 77, 101, 115, 104, 0, 0, 0, 0,
				52, 79, 99, 117, 108, 117, 115, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				83, 117, 114, 102, 97, 99, 101, 115, 124, 85,
				110, 105, 111, 110, 67, 108, 105, 112, 112, 101,
				100, 80, 108, 97, 110, 101, 83, 117, 114, 102,
				97, 99, 101, 0, 0, 0, 0, 33, 124, 85,
				112, 100, 97, 116, 101, 82, 111, 117, 110, 100,
				101, 100, 66, 111, 120, 65, 110, 99, 104, 111,
				114, 67, 111, 110, 115, 116, 114, 97, 105, 110,
				116, 0, 0, 0, 0, 40, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 83, 97, 109, 112, 108,
				101, 115, 124, 80, 111, 115, 101, 85, 115, 101,
				83, 97, 109, 112, 108, 101, 0, 0, 0, 0,
				40, 79, 99, 117, 108, 117, 115, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				83, 97, 109, 112, 108, 101, 115, 124, 82, 101,
				115, 112, 97, 119, 110, 79, 110, 68, 114, 111,
				112, 0, 0, 0, 0, 46, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 83, 97, 109, 112, 108,
				101, 115, 124, 82, 111, 116, 97, 116, 105, 111,
				110, 65, 117, 100, 105, 111, 69, 118, 101, 110,
				116, 115, 0, 0, 0, 0, 43, 79, 99, 117,
				108, 117, 115, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 46, 83, 97, 109, 112,
				108, 101, 115, 124, 83, 97, 109, 112, 108, 101,
				83, 99, 101, 110, 101, 71, 114, 111, 117, 112,
				0, 0, 0, 0, 54, 79, 99, 117, 108, 117,
				115, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 46, 83, 97, 109, 112, 108, 101,
				115, 46, 83, 97, 109, 112, 108, 101, 83, 99,
				101, 110, 101, 71, 114, 111, 117, 112, 124, 73,
				83, 99, 101, 110, 101, 73, 110, 102, 111, 0,
				0, 0, 0, 53, 79, 99, 117, 108, 117, 115,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 46, 83, 97, 109, 112, 108, 101, 115,
				46, 83, 97, 109, 112, 108, 101, 83, 99, 101,
				110, 101, 71, 114, 111, 117, 112, 124, 83, 99,
				101, 110, 101, 73, 110, 102, 111, 0, 0, 0,
				0, 43, 79, 99, 117, 108, 117, 115, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				46, 83, 97, 109, 112, 108, 101, 115, 124, 83,
				97, 109, 112, 108, 101, 115, 73, 110, 102, 111,
				80, 97, 110, 101, 108, 0, 0, 0, 0, 43,
				79, 99, 117, 108, 117, 115, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 46, 83,
				97, 109, 112, 108, 101, 115, 124, 83, 99, 97,
				108, 101, 65, 117, 100, 105, 111, 69, 118, 101,
				110, 116, 115, 0, 0, 0, 0, 40, 79, 99,
				117, 108, 117, 115, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 46, 83, 97, 109,
				112, 108, 101, 115, 124, 83, 99, 97, 108, 101,
				77, 111, 100, 105, 102, 105, 101, 114, 0, 0,
				0, 0, 43, 79, 99, 117, 108, 117, 115, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 46, 83, 97, 109, 112, 108, 101, 115, 124,
				83, 99, 101, 110, 101, 71, 114, 111, 117, 112,
				76, 111, 97, 100, 101, 114, 0, 0, 0, 0,
				58, 79, 99, 117, 108, 117, 115, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				83, 97, 109, 112, 108, 101, 115, 46, 83, 99,
				101, 110, 101, 71, 114, 111, 117, 112, 76, 111,
				97, 100, 101, 114, 124, 83, 99, 101, 110, 101,
				71, 114, 111, 117, 112, 86, 105, 101, 119, 0,
				0, 0, 0, 57, 79, 99, 117, 108, 117, 115,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 46, 83, 97, 109, 112, 108, 101, 115,
				46, 83, 99, 101, 110, 101, 71, 114, 111, 117,
				112, 76, 111, 97, 100, 101, 114, 124, 83, 99,
				101, 110, 101, 84, 105, 108, 101, 86, 105, 101,
				119, 0, 0, 0, 0, 38, 79, 99, 117, 108,
				117, 115, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 46, 83, 97, 109, 112, 108,
				101, 115, 124, 83, 99, 101, 110, 101, 76, 111,
				97, 100, 101, 114, 0, 0, 0, 0, 47, 79,
				99, 117, 108, 117, 115, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 46, 83, 97,
				109, 112, 108, 101, 115, 124, 83, 104, 111, 117,
				108, 100, 72, 105, 100, 101, 72, 97, 110, 100,
				79, 110, 71, 114, 97, 98, 0, 0, 0, 0,
				43, 79, 99, 117, 108, 117, 115, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 46,
				83, 97, 109, 112, 108, 101, 115, 124, 67, 111,
				110, 115, 116, 97, 110, 116, 82, 111, 116, 97,
				116, 105, 111, 110, 0, 0, 0, 0, 63, 79,
				99, 117, 108, 117, 115, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 46, 83, 97,
				109, 112, 108, 101, 115, 124, 76, 105, 115, 116,
				83, 110, 97, 112, 80, 111, 115, 101, 68, 101,
				108, 101, 103, 97, 116, 101, 82, 111, 117, 110,
				100, 101, 100, 66, 111, 120, 86, 105, 115, 117,
				97, 108, 0, 0, 0, 0, 37, 79, 99, 117,
				108, 117, 115, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 46, 83, 97, 109, 112,
				108, 101, 115, 124, 83, 116, 97, 121, 73, 110,
				86, 105, 101, 119, 0, 0, 0, 0, 36, 79,
				99, 117, 108, 117, 115, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 124, 80, 114,
				101, 115, 115, 117, 114, 101, 66, 114, 101, 97,
				107, 97, 98, 108, 101, 0, 0, 0, 0, 37,
				79, 99, 117, 108, 117, 115, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 124, 80,
				114, 101, 115, 115, 117, 114, 101, 83, 113, 117,
				105, 115, 104, 97, 98, 108, 101
			},
			TotalFiles = 79,
			TotalTypes = 96,
			IsEditorOnly = false
		};
	}
}
namespace Oculus.Interaction
{
	public class DisableRaycaster : MonoBehaviour
	{
		public float minAlpha;

		public GraphicRaycaster raycaster;

		public CanvasGroup group;

		private void Update()
		{
			raycaster.enabled = group.alpha > minAlpha;
		}
	}
	public class UITheme : ScriptableObject
	{
		[Serializable]
		public struct ElementColors
		{
			public Color normal;

			public Color highlighted;

			public Color pressed;

			public Color selected;

			public Color disabled;
		}

		private const int CurrentThemeVersion = 2;

		[SerializeField]
		[HideInInspector]
		private int _themeVersion = 2;

		public Color backplateColor;

		public Material backplateGradientMaterial;

		public Color buttonPlateColor;

		public Color sectionPlateColor;

		public Color tooltipColor;

		[Header("Shared")]
		public Color textPrimaryColor;

		public Color textSecondaryColor;

		public Color textPrimaryInvertedColor;

		public Color textSecondaryInvertedColor;

		[Header("Per Element Type Color")]
		public ElementColors primaryButton;

		public ElementColors secondaryButton;

		public ElementColors borderlessButton;

		public ElementColors destructiveButton;

		[Header("Fonts")]
		public TMP_FontAsset textFontBold;

		public TMP_FontAsset textFontMedium;

		public TMP_FontAsset textFontRegular;

		[Header("Animators")]
		public RuntimeAnimatorController acPrimaryButton;

		public RuntimeAnimatorController acSecondaryButton;

		public RuntimeAnimatorController acBorderlessButton;

		public RuntimeAnimatorController acDestructiveButton;

		public RuntimeAnimatorController acToggleButton;

		public RuntimeAnimatorController acToggleBorderlessButton;

		public RuntimeAnimatorController acToggleSwitch;

		public RuntimeAnimatorController acToggleCheckboxRadio;

		public RuntimeAnimatorController acTextInputField;

		[Space(10f)]
		public string colorPath = "Content/Background";

		public int ThemeVersion => _themeVersion;
	}
	public class UIThemeManager : MonoBehaviour
	{
		[SerializeField]
		private UITheme[] _themes;

		[SerializeField]
		private int _currentThemeIndex;

		public UITheme[] Themes => _themes;

		public int CurrentThemeIndex => _currentThemeIndex;

		private void Start()
		{
			ApplyTheme(_currentThemeIndex);
		}

		public void ApplyCurrentTheme()
		{
			ApplyTheme(_currentThemeIndex);
		}

		public void ApplyTheme(int index)
		{
			if (index < 0 || index >= _themes.Length)
			{
				UnityEngine.Debug.LogError("Theme index out of range.");
				return;
			}
			_currentThemeIndex = index;
			UITheme uITheme = _themes[index];
			Animator[] componentsInChildren = GetComponentsInChildren<Animator>();
			foreach (Animator animator in componentsInChildren)
			{
				if (animator.CompareTag("QDSUIPrimaryButton"))
				{
					animator.runtimeAnimatorController = uITheme.acPrimaryButton;
				}
				else if (animator.CompareTag("QDSUISecondaryButton"))
				{
					animator.runtimeAnimatorController = uITheme.acSecondaryButton;
				}
				else if (animator.CompareTag("QDSUIBorderlessButton"))
				{
					animator.runtimeAnimatorController = uITheme.acBorderlessButton;
				}
				else if (animator.CompareTag("QDSUIDestructiveButton"))
				{
					animator.runtimeAnimatorController = uITheme.acDestructiveButton;
				}
				else if (animator.CompareTag("QDSUIToggleButton"))
				{
					animator.runtimeAnimatorController = uITheme.acToggleButton;
				}
				else if (animator.CompareTag("QDSUIToggleBorderlessButton"))
				{
					animator.runtimeAnimatorController = uITheme.acToggleBorderlessButton;
				}
				else if (animator.CompareTag("QDSUIToggleSwitch"))
				{
					animator.runtimeAnimatorController = uITheme.acToggleSwitch;
				}
				else if (animator.CompareTag("QDSUIToggleCheckboxRadio"))
				{
					animator.runtimeAnimatorController = uITheme.acToggleCheckboxRadio;
				}
				else if (animator.CompareTag("QDSUITextInputField"))
				{
					animator.runtimeAnimatorController = uITheme.acTextInputField;
				}
				animator.Update(0f);
			}
			Image[] componentsInChildren2 = GetComponentsInChildren<Image>();
			foreach (Image image in componentsInChildren2)
			{
				if (image.CompareTag("QDSUIIcon"))
				{
					image.color = uITheme.textPrimaryColor;
				}
				else if (image.CompareTag("QDSUIAccentColor"))
				{
					image.color = uITheme.primaryButton.normal;
				}
				else if (!image.CompareTag("QDSUISharedThemeColor") && !image.CompareTag("QDSUIDestructiveButton") && !image.CompareTag("QDSUIBorderlessButton") && !image.CompareTag("QDSUIToggleBorderlessButton") && !image.CompareTag("QDSUISecondaryButton") && !image.CompareTag("QDSUIToggleButton"))
				{
					if (image.CompareTag("QDSUISection"))
					{
						image.color = uITheme.sectionPlateColor;
					}
					else if (image.CompareTag("QDSUITooltip"))
					{
						image.color = uITheme.tooltipColor;
					}
					else if (!image.CompareTag("QDSUITextInputField"))
					{
						image.color = uITheme.backplateColor;
					}
				}
				if (uITheme.ThemeVersion == 2)
				{
					if (image.CompareTag("QDSUIBackplateGradient"))
					{
						image.color = uITheme.backplateColor;
						image.material = uITheme.backplateGradientMaterial;
					}
					if (image.CompareTag("QDSUITextInvertedColor"))
					{
						image.color = uITheme.textPrimaryInvertedColor;
					}
				}
			}
			SpriteRenderer[] componentsInChildren3 = GetComponentsInChildren<SpriteRenderer>();
			for (int i = 0; i < componentsInChildren3.Length; i++)
			{
				componentsInChildren3[i].color = uITheme.tooltipColor;
			}
			TextMeshProUGUI[] componentsInChildren4 = GetComponentsInChildren<TextMeshProUGUI>();
			foreach (TextMeshProUGUI textMeshProUGUI in componentsInChildren4)
			{
				textMeshProUGUI.font = uITheme.textFontMedium;
				if (!textMeshProUGUI.CompareTag("QDSUISharedThemeColor") && !textMeshProUGUI.CompareTag("QDSUIDestructiveButton"))
				{
					if (textMeshProUGUI.CompareTag("QDSUITextSecondaryColor"))
					{
						textMeshProUGUI.color = uITheme.textSecondaryColor;
					}
					else
					{
						textMeshProUGUI.color = uITheme.textPrimaryColor;
					}
				}
				if (uITheme.ThemeVersion == 2)
				{
					if (textMeshProUGUI.CompareTag("QDSUITextInvertedColor"))
					{
						textMeshProUGUI.color = uITheme.textPrimaryInvertedColor;
					}
					if (textMeshProUGUI.CompareTag("QDSUITextSecondaryInvertedColor"))
					{
						textMeshProUGUI.color = uITheme.textSecondaryInvertedColor;
					}
				}
			}
		}
	}
	public class AudioPhysics : MonoBehaviour
	{
		public class CollisionEvents : MonoBehaviour
		{
			public event Action<Collision> WhenCollisionEnter = delegate
			{
			};

			private void OnCollisionEnter(Collision collision)
			{
				this.WhenCollisionEnter(collision);
			}
		}

		[Tooltip("Add a reference to the rigidbody on this gameobject.")]
		[SerializeField]
		private Rigidbody _rigidbody;

		[Tooltip("Reference an audio trigger instance for soft and hard collisions.")]
		[SerializeField]
		private ImpactAudio _impactAudioEvents;

		[Tooltip("Collisions below this value will play a soft audio event, and collisions above will play a hard audio event.")]
		[Range(0f, 8f)]
		[SerializeField]
		private float _velocitySplit = 1f;

		[Tooltip("Collisions below this value will be ignored and will not play audio.")]
		[Range(0f, 2f)]
		[SerializeField]
		private float _minimumVelocity;

		[Tooltip("The shortest amount of time in seconds between collisions. Used to cull multiple fast collision events.")]
		[Range(0f, 2f)]
		[SerializeField]
		private float _timeBetweenCollisions = 0.2f;

		[Tooltip("By default (false), when two physics objects collide with physics audio components, we only play the one with the higher velocity.Setting this to true will allow both impacts to play.")]
		[SerializeField]
		private bool _allowMultipleCollisions;

		private float _timeAtLastCollision;

		protected bool _started;

		private CollisionEvents _collisionEvents;

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			_collisionEvents = _rigidbody.gameObject.AddComponent<CollisionEvents>();
			this.EndStart(ref _started);
		}

		protected virtual void OnEnable()
		{
			if (_started)
			{
				_collisionEvents.WhenCollisionEnter += HandleCollisionEnter;
			}
		}

		protected virtual void OnDisable()
		{
			if (_started)
			{
				_collisionEvents.WhenCollisionEnter -= HandleCollisionEnter;
			}
		}

		protected virtual void OnDestroy()
		{
			if (_collisionEvents != null)
			{
				UnityEngine.Object.Destroy(_collisionEvents);
			}
		}

		private void HandleCollisionEnter(Collision collision)
		{
			TryPlayCollisionAudio(collision, _rigidbody);
		}

		private void TryPlayCollisionAudio(Collision collision, Rigidbody rigidbody)
		{
			float sqrMagnitude = collision.relativeVelocity.sqrMagnitude;
			if (!(collision.collider.gameObject == null))
			{
				float num = Time.time - _timeAtLastCollision;
				if (!(_timeBetweenCollisions > num) && (_allowMultipleCollisions || !collision.collider.gameObject.TryGetComponent<AudioPhysics>(out var component) || !(GetObjectVelocity(component) > GetObjectVelocity(this))))
				{
					_timeAtLastCollision = Time.time;
					PlayCollisionAudio(_impactAudioEvents, sqrMagnitude);
				}
			}
		}

		private void PlayCollisionAudio(ImpactAudio impactAudio, float magnitude)
		{
			if (!(impactAudio.HardCollisionSound == null) && !(impactAudio.SoftCollisionSound == null) && magnitude > _minimumVelocity)
			{
				if (magnitude > _velocitySplit && impactAudio.HardCollisionSound != null)
				{
					PlaySoundOnAudioTrigger(impactAudio.HardCollisionSound);
				}
				else
				{
					PlaySoundOnAudioTrigger(impactAudio.SoftCollisionSound);
				}
			}
		}

		private static float GetObjectVelocity(AudioPhysics target)
		{
			return target._rigidbody.velocity.sqrMagnitude;
		}

		private void PlaySoundOnAudioTrigger(AudioTrigger audioTrigger)
		{
			if (audioTrigger != null)
			{
				audioTrigger.PlayAudio();
			}
		}
	}
	[Serializable]
	public struct ImpactAudio
	{
		[Tooltip("Hard collision sound will play when impact velocity is above the velocity split value.")]
		[SerializeField]
		private AudioTrigger _hardCollisionSound;

		[Tooltip("Soft collision sound will play when impact velocity is below the velocity split value.")]
		[SerializeField]
		private AudioTrigger _softCollisionSound;

		public AudioTrigger HardCollisionSound => _hardCollisionSound;

		public AudioTrigger SoftCollisionSound => _softCollisionSound;
	}
	public class AudioTrigger : MonoBehaviour
	{
		[SerializeField]
		private AudioSource _audioSource;

		[Tooltip("Audio clip arrays with a value greater than 1 will have randomized playback.")]
		[SerializeField]
		private AudioClip[] _audioClips;

		[Tooltip("Volume set here will override the volume set on the attached sound source component.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float _volume = 0.7f;

		[Tooltip("Check the 'Use Random Range' bool and adjust the min and max slider values for randomized volume level playback.")]
		[SerializeField]
		private MinMaxPair _volumeRandomization;

		[Tooltip("Pitch set here will override the volume set on the attached sound source component.")]
		[SerializeField]
		[Range(-3f, 3f)]
		[Space(10f)]
		private float _pitch = 1f;

		[Tooltip("Check the 'Use Random Range' bool and adjust the min and max slider values for randomized volume level playback.")]
		[SerializeField]
		private MinMaxPair _pitchRandomization;

		[Tooltip("True by default. Set to false for sounds to bypass the spatializer plugin. Will override settings on attached audio source.")]
		[SerializeField]
		[Space(10f)]
		private bool _spatialize = true;

		[Tooltip("False by default. Set to true to enable looping on this sound. Will override settings on attached audio source.")]
		[SerializeField]
		private bool _loop;

		[Tooltip("100% by default. Sets likelihood sample will actually play when called.")]
		[SerializeField]
		private float _chanceToPlay = 100f;

		[Tooltip("If enabled, audio will play automatically when this gameobject is enabled.")]
		[SerializeField]
		[Optional]
		private bool _playOnStart;

		private int _previousAudioClipIndex = -1;

		public float Volume
		{
			get
			{
				return _volume;
			}
			set
			{
				_volume = value;
			}
		}

		public MinMaxPair VolumeRandomization
		{
			get
			{
				return _volumeRandomization;
			}
			set
			{
				_volumeRandomization = value;
			}
		}

		public float Pitch
		{
			get
			{
				return _pitch;
			}
			set
			{
				_pitch = value;
			}
		}

		public MinMaxPair PitchRandomization
		{
			get
			{
				return _pitchRandomization;
			}
			set
			{
				_pitchRandomization = value;
			}
		}

		public bool Spatialize
		{
			get
			{
				return _spatialize;
			}
			set
			{
				_spatialize = value;
			}
		}

		public bool Loop
		{
			get
			{
				return _loop;
			}
			set
			{
				_loop = value;
			}
		}

		public float ChanceToPlay
		{
			get
			{
				return _chanceToPlay;
			}
			set
			{
				_chanceToPlay = value;
			}
		}

		protected virtual void Start()
		{
			if (_audioSource == null)
			{
				_audioSource = base.gameObject.GetComponent<AudioSource>();
			}
			if (_playOnStart)
			{
				PlayAudio();
			}
		}

		public void PlayAudio()
		{
			float num = UnityEngine.Random.Range(0f, 100f);
			if (!(_chanceToPlay < 100f) || !(num > _chanceToPlay))
			{
				if (_volumeRandomization.UseRandomRange)
				{
					_audioSource.volume = UnityEngine.Random.Range(_volumeRandomization.Min, _volumeRandomization.Max);
				}
				else
				{
					_audioSource.volume = _volume;
				}
				if (_pitchRandomization.UseRandomRange)
				{
					_audioSource.pitch = UnityEngine.Random.Range(_pitchRandomization.Min, _pitchRandomization.Max);
				}
				else
				{
					_audioSource.pitch = _pitch;
				}
				_audioSource.spatialize = _spatialize;
				_audioSource.loop = _loop;
				_audioSource.clip = RandomClipWithoutRepeat();
				_audioSource.Play();
			}
		}

		private AudioClip RandomClipWithoutRepeat()
		{
			if (_audioClips.Length == 1)
			{
				return _audioClips[0];
			}
			int num = UnityEngine.Random.Range(1, _audioClips.Length);
			int num2 = (_previousAudioClipIndex = (_previousAudioClipIndex + num) % _audioClips.Length);
			return _audioClips[num2];
		}

		public void InjectAllAudioTrigger(AudioSource audioSource, AudioClip[] audioClips)
		{
			InjectAudioSource(audioSource);
			InjectAudioClips(audioClips);
		}

		public void InjectAudioSource(AudioSource audioSource)
		{
			_audioSource = audioSource;
		}

		public void InjectAudioClips(AudioClip[] audioClips)
		{
			_audioClips = audioClips;
		}

		public void InjectOptionalPlayOnStart(bool playOnStart)
		{
			_playOnStart = playOnStart;
		}
	}
	[Serializable]
	public struct MinMaxPair
	{
		[SerializeField]
		private bool _useRandomRange;

		[SerializeField]
		private float _min;

		[SerializeField]
		private float _max;

		public bool UseRandomRange => _useRandomRange;

		public float Min => _min;

		public float Max => _max;
	}
	public class TogglerActiveState : MonoBehaviour, IActiveState
	{
		[SerializeField]
		private Toggle _toggle;

		protected bool _started;

		public bool Active => _toggle.isOn;

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			this.EndStart(ref _started);
		}

		public void InjectAllTogglerActiveState(Toggle toggle)
		{
			InjectAllToggle(toggle);
		}

		public void InjectAllToggle(Toggle toggle)
		{
			_toggle = toggle;
		}
	}
	public class PressureBreakable : MonoBehaviour, IHandGrabUseDelegate
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float _breakThreshold = 0.9f;

		[SerializeField]
		private GameObject _unbrokenObject;

		[SerializeField]
		private GameObject _brokenObject;

		[SerializeField]
		private Rigidbody[] _brokenBodies;

		[SerializeField]
		private HandGrabInteractable[] _grabInteractables;

		[Header("Break Effects")]
		[SerializeField]
		private float _explosionForce = 3f;

		[SerializeField]
		private float _explosionRadius = 0.5f;

		[SerializeField]
		private float _unbreakDelay = 3f;

		private float _useStrength;

		private bool _isBroken;

		private Pose[] _brokenBodiesInitialPoses;

		protected virtual void Awake()
		{
			_unbrokenObject.SetActive(!_isBroken);
			_brokenObject.SetActive(_isBroken);
		}

		protected virtual void Start()
		{
			_brokenBodiesInitialPoses = new Pose[_brokenBodies.Length];
			for (int i = 0; i < _brokenBodies.Length; i++)
			{
				Rigidbody rigidbody = _brokenBodies[i];
				_brokenBodiesInitialPoses[i] = new Pose(rigidbody.transform.localPosition, rigidbody.transform.localRotation);
			}
		}

		protected virtual void Update()
		{
			if (_useStrength >= _breakThreshold)
			{
				Break();
			}
		}

		public void BeginUse()
		{
		}

		public void EndUse()
		{
			_useStrength = 0f;
		}

		public float ComputeUseStrength(float strength)
		{
			_useStrength = strength;
			return _useStrength;
		}

		private void Break()
		{
			if (!_isBroken)
			{
				_isBroken = true;
				_unbrokenObject.SetActive(!_isBroken);
				HandGrabInteractable[] grabInteractables = _grabInteractables;
				for (int i = 0; i < grabInteractables.Length; i++)
				{
					grabInteractables[i].Disable();
				}
				_brokenObject.SetActive(_isBroken);
				Rigidbody[] brokenBodies = _brokenBodies;
				foreach (Rigidbody obj in brokenBodies)
				{
					obj.mass = 1f / (float)_brokenBodies.Length;
					obj.AddExplosionForce(_explosionForce, base.transform.position, _explosionRadius);
				}
				StartCoroutine(Unbreak());
			}
		}

		private IEnumerator Unbreak()
		{
			if (_isBroken)
			{
				yield return new WaitForSeconds(_unbreakDelay);
				_isBroken = false;
				_brokenObject.SetActive(_isBroken);
				for (int i = 0; i < _brokenBodies.Length; i++)
				{
					Rigidbody obj = _brokenBodies[i];
					Pose pose = _brokenBodiesInitialPoses[i];
					obj.velocity = Vector3.zero;
					obj.angularVelocity = Vector3.zero;
					obj.transform.localPosition = pose.position;
					obj.transform.localRotation = pose.rotation;
				}
				HandGrabInteractable[] grabInteractables = _grabInteractables;
				for (int j = 0; j < grabInteractables.Length; j++)
				{
					grabInteractables[j].Enable();
				}
				_unbrokenObject.SetActive(!_isBroken);
			}
		}
	}
	public class PressureSquishable : MonoBehaviour, IHandGrabUseDelegate
	{
		[SerializeField]
		private GameObject _squishableObject;

		[SerializeField]
		[Range(0.01f, 1f)]
		private float _maxSquish = 0.25f;

		[SerializeField]
		[Range(0.01f, 1f)]
		private float _maxStretch = 0.15f;

		protected bool _started;

		private Vector3 _initialScale;

		protected virtual void Start()
		{
			_initialScale = _squishableObject.transform.localScale;
		}

		public void BeginUse()
		{
		}

		public void EndUse()
		{
			_squishableObject.transform.localScale = _initialScale;
		}

		public float ComputeUseStrength(float strength)
		{
			float num = Mathf.Lerp(1f, 1f - _maxSquish, strength);
			float num2 = Mathf.Lerp(1f, 1f + _maxStretch, strength);
			_squishableObject.transform.localScale = new Vector3(_initialScale.x * num2, _initialScale.y * num, _initialScale.z * num2);
			return strength;
		}
	}
}
namespace Oculus.Interaction.Surfaces
{
	public class UnionClippedPlaneSurface : MonoBehaviour, IClippedSurface<IBoundsClipper>, ISurfacePatch, ISurface
	{
		private static readonly Bounds InfiniteBounds = new Bounds(Vector3.zero, Vector3.one * float.PositiveInfinity);

		private static readonly Bounds PlaneBounds = new Bounds(Vector3.zero, new Vector3(float.PositiveInfinity, float.PositiveInfinity, 1E-05f));

		[Tooltip("The Plane Surface to be clipped.")]
		[SerializeField]
		private PlaneSurface _planeSurface;

		[Tooltip("The clippers that will be used to clip the Plane Surface.")]
		[SerializeField]
		[Interface(typeof(IBoundsClipper), new Type[] { })]
		private List<UnityEngine.Object> _clippers = new List<UnityEngine.Object>();

		private List<IBoundsClipper> Clippers { get; set; }

		public ISurface BackingSurface => _planeSurface;

		public Transform Transform => _planeSurface.Transform;

		public IReadOnlyList<IBoundsClipper> GetClippers()
		{
			if (Clippers != null)
			{
				return Clippers;
			}
			return _clippers.ConvertAll((UnityEngine.Object clipper) => clipper as IBoundsClipper);
		}

		protected virtual void Awake()
		{
			Clippers = _clippers.ConvertAll((UnityEngine.Object clipper) => clipper as IBoundsClipper);
		}

		protected virtual void Start()
		{
		}

		[Obsolete("Use the non-alloc version instead")]
		public List<Bounds> GetLocalBounds()
		{
			List<Bounds> clipBounds = new List<Bounds>();
			GetLocalBoundsNonAlloc(ref clipBounds);
			return clipBounds;
		}

		public void GetLocalBoundsNonAlloc(ref List<Bounds> clipBounds)
		{
			IReadOnlyList<IBoundsClipper> clippers = GetClippers();
			for (int i = 0; i < clippers.Count; i++)
			{
				IBoundsClipper boundsClipper = clippers[i];
				if (boundsClipper != null && boundsClipper.GetLocalBounds(Transform, out var bounds))
				{
					clipBounds.Add(bounds);
				}
			}
		}

		private Vector3 ClampPoint(in Vector3 point, in Bounds bounds)
		{
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			Vector3 vector = Transform.InverseTransformPoint(point);
			Vector3 position = new Vector3(Mathf.Clamp(vector.x, min.x, max.x), Mathf.Clamp(vector.y, min.y, max.y), Mathf.Clamp(vector.z, min.z, max.z));
			return Transform.TransformPoint(position);
		}

		public bool ClosestSurfacePoint(in Vector3 point, out SurfaceHit hit, float maxDistance = 0f)
		{
			if (!_planeSurface.ClosestSurfacePoint(in point, out hit, maxDistance))
			{
				return false;
			}
			List<Bounds> clipBounds = CollectionPool<List<Bounds>, Bounds>.Get();
			GetLocalBoundsNonAlloc(ref clipBounds);
			List<(Vector3, float)> list = new List<(Vector3, float)>();
			foreach (Bounds item in clipBounds)
			{
				Bounds bounds = item;
				Vector3 size = bounds.size;
				size.z = 1E-05f;
				bounds.size = size;
				Vector3 vector = ClampPoint(hit.Point, in bounds);
				float num = Vector3.Distance(point, vector);
				if (maxDistance <= 0f || num <= maxDistance)
				{
					list.Add((vector, num));
				}
			}
			CollectionPool<List<Bounds>, Bounds>.Release(clipBounds);
			clipBounds = null;
			if (list.Count == 0)
			{
				return false;
			}
			(Vector3, float) tuple = list[0];
			for (int i = 1; i < list.Count; i++)
			{
				(Vector3, float) tuple2 = list[i];
				if (tuple2.Item2 < tuple.Item2)
				{
					tuple = tuple2;
				}
			}
			(hit.Point, hit.Distance) = tuple;
			return true;
		}

		public bool Raycast(in Ray ray, out SurfaceHit hit, float maxDistance = 0f)
		{
			if (BackingSurface.Raycast(in ray, out hit, maxDistance))
			{
				List<Bounds> clipBounds = CollectionPool<List<Bounds>, Bounds>.Get();
				GetLocalBoundsNonAlloc(ref clipBounds);
				foreach (Bounds item in clipBounds)
				{
					if (item.Contains(Transform.InverseTransformPoint(hit.Point)))
					{
						CollectionPool<List<Bounds>, Bounds>.Release(clipBounds);
						return true;
					}
				}
				CollectionPool<List<Bounds>, Bounds>.Release(clipBounds);
				return false;
			}
			return false;
		}

		public void InjectAllClippedPlaneSurface(PlaneSurface planeSurface, IEnumerable<IBoundsClipper> clippers)
		{
			InjectPlaneSurface(planeSurface);
			InjectClippers(clippers);
		}

		public void InjectPlaneSurface(PlaneSurface planeSurface)
		{
			_planeSurface = planeSurface;
		}

		public void InjectClippers(IEnumerable<IBoundsClipper> clippers)
		{
			_clippers = new List<UnityEngine.Object>(clippers.Select((IBoundsClipper c) => c as UnityEngine.Object));
			Clippers = clippers.ToList();
		}

		bool ISurface.Raycast(in Ray ray, out SurfaceHit hit, float maxDistance)
		{
			return Raycast(in ray, out hit, maxDistance);
		}

		bool ISurface.ClosestSurfacePoint(in Vector3 point, out SurfaceHit hit, float maxDistance)
		{
			return ClosestSurfacePoint(in point, out hit, maxDistance);
		}
	}
}
namespace Oculus.Interaction.Locomotion
{
	[RequireComponent(typeof(AudioSource))]
	public class AdjustableAudio : MonoBehaviour
	{
		[SerializeField]
		private AudioSource _audioSource;

		[SerializeField]
		private AudioClip _audioClip;

		[SerializeField]
		[Range(0f, 1f)]
		private float _volumeFactor = 1f;

		[SerializeField]
		private AnimationCurve _volumeCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		private AnimationCurve _pitchCurve = AnimationCurve.Linear(0f, 0.5f, 1f, 1.5f);

		protected bool _started;

		public AudioClip AudioClip
		{
			get
			{
				return _audioClip;
			}
			set
			{
				_audioClip = value;
			}
		}

		public float VolumeFactor
		{
			get
			{
				return _volumeFactor;
			}
			set
			{
				_volumeFactor = value;
			}
		}

		public AnimationCurve VolumeCurve
		{
			get
			{
				return _volumeCurve;
			}
			set
			{
				_volumeCurve = value;
			}
		}

		public AnimationCurve PitchCurve
		{
			get
			{
				return _pitchCurve;
			}
			set
			{
				_pitchCurve = value;
			}
		}

		protected virtual void Reset()
		{
			_audioSource = base.gameObject.GetComponent<AudioSource>();
			_audioClip = _audioSource.clip;
		}

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			this.EndStart(ref _started);
		}

		public void PlayAudio(float volumeT, float pitchT, float pan = 0f)
		{
			if (_audioSource.isActiveAndEnabled)
			{
				_audioSource.volume = _volumeCurve.Evaluate(volumeT) * VolumeFactor;
				_audioSource.pitch = _pitchCurve.Evaluate(pitchT);
				_audioSource.panStereo = pan;
				_audioSource.PlayOneShot(_audioClip);
			}
		}

		public void InjectAllAdjustableAudio(AudioSource audioSource)
		{
			InjectAudioSource(audioSource);
		}

		public void InjectAudioSource(AudioSource audioSource)
		{
			_audioSource = audioSource;
		}
	}
	public class LocomotionComfortVignetteSetting : MonoBehaviour
	{
		public enum ComfortType
		{
			Turning,
			Accelerating,
			Moving
		}

		[SerializeField]
		private Toggle _toggle;

		[SerializeField]
		private ComfortType _comfortType;

		[SerializeField]
		private AnimationCurve _curve;

		[SerializeField]
		private LocomotionTunneling _tunneling;

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
				_toggle.onValueChanged.AddListener(InjectCurve);
				InjectCurve(_toggle.isOn);
			}
		}

		protected virtual void OnDisable()
		{
			if (_started)
			{
				_toggle.onValueChanged.RemoveListener(InjectCurve);
			}
		}

		private void InjectCurve(bool inject)
		{
			if (inject)
			{
				switch (_comfortType)
				{
				case ComfortType.Turning:
					_tunneling.RotationStrength = _curve;
					break;
				case ComfortType.Accelerating:
					_tunneling.AccelerationStrength = _curve;
					break;
				case ComfortType.Moving:
					_tunneling.MovementStrength = _curve;
					break;
				}
			}
		}

		public void InjectAllComfortOption(ComfortType comfortType, Toggle toggle, AnimationCurve curve, LocomotionTunneling tunneling)
		{
			InjectComfortType(comfortType);
			InjectToggle(toggle);
			InjectCurve(curve);
			InjectTunneling(tunneling);
		}

		public void InjectComfortType(ComfortType comfortType)
		{
			_comfortType = comfortType;
		}

		public void InjectToggle(Toggle toggle)
		{
			_toggle = toggle;
		}

		public void InjectCurve(AnimationCurve curve)
		{
			_curve = curve;
		}

		public void InjectTunneling(LocomotionTunneling tunneling)
		{
			_tunneling = tunneling;
		}
	}
	public class LocomotionSeatedSetting : MonoBehaviour
	{
		[SerializeField]
		private Toggle _seated;

		[SerializeField]
		private Toggle _standing;

		[SerializeField]
		private FirstPersonLocomotor _locomotor;

		[SerializeField]
		private float _seatedHeightOffset = 0.5f;

		protected bool _started;

		public float SeatedHeightOffset
		{
			get
			{
				return _seatedHeightOffset;
			}
			set
			{
				_seatedHeightOffset = value;
			}
		}

		protected void Start()
		{
			this.BeginStart(ref _started);
			this.EndStart(ref _started);
		}

		protected virtual void OnEnable()
		{
			if (_started)
			{
				_seated.onValueChanged.AddListener(HandleSeatedChanged);
				_standing.onValueChanged.AddListener(HandleStandingChanged);
				if (_standing.isOn)
				{
					HandleStandingChanged(standing: true);
				}
				else
				{
					HandleSeatedChanged(seated: true);
				}
			}
		}

		protected virtual void OnDisable()
		{
			if (_started)
			{
				_seated.onValueChanged.RemoveListener(HandleSeatedChanged);
				_standing.onValueChanged.RemoveListener(HandleStandingChanged);
			}
		}

		private void HandleSeatedChanged(bool seated)
		{
			if (seated)
			{
				_locomotor.HeightOffset = _seatedHeightOffset;
			}
		}

		private void HandleStandingChanged(bool standing)
		{
			if (standing)
			{
				_locomotor.HeightOffset = 0f;
			}
		}

		public void InjectAllSeatedMode(Toggle seated, Toggle standing, FirstPersonLocomotor locomotor)
		{
			InjectSeated(seated);
			InjectStanding(standing);
			InjectLocomotor(locomotor);
		}

		public void InjectSeated(Toggle seated)
		{
			_seated = seated;
		}

		public void InjectStanding(Toggle standing)
		{
			_standing = standing;
		}

		public void InjectLocomotor(FirstPersonLocomotor locomotor)
		{
			_locomotor = locomotor;
		}
	}
	public class LocomotionTurnSliderSetting : MonoBehaviour
	{
		[SerializeField]
		private Slider _slider;

		[SerializeField]
		private Toggle _snapTurnToggle;

		[SerializeField]
		private Toggle _smoothTurnToggle;

		[SerializeField]
		private float[] _snapTurnSteps = new float[3] { 30f, 45f, 90f };

		[SerializeField]
		private AnimationCurve[] _smoothTurnSteps;

		[SerializeField]
		private TurnerEventBroadcaster[] _controllerTurners;

		[SerializeField]
		private TurnerEventBroadcaster[] _handTurners;

		[SerializeField]
		private TurnLocomotionBroadcaster[] _locomotionTurners;

		protected bool _started;

		protected void Start()
		{
			this.BeginStart(ref _started);
			this.EndStart(ref _started);
		}

		protected virtual void OnEnable()
		{
			if (_started)
			{
				_slider.onValueChanged.AddListener(HandleValueChanged);
				_snapTurnToggle.onValueChanged.AddListener(HandleSnapTurnChanged);
				_smoothTurnToggle.onValueChanged.AddListener(HandleSmoothTurnChanged);
				HandleValueChanged(_slider.value);
				HandleSnapTurnChanged(_snapTurnToggle.isOn);
				HandleSmoothTurnChanged(_smoothTurnToggle.isOn);
			}
		}

		protected virtual void OnDisable()
		{
			if (_started)
			{
				_slider.onValueChanged.RemoveListener(HandleValueChanged);
				_snapTurnToggle.onValueChanged.RemoveListener(HandleSnapTurnChanged);
				_smoothTurnToggle.onValueChanged.RemoveListener(HandleSmoothTurnChanged);
			}
		}

		private void HandleValueChanged(float arg0)
		{
			int num = Mathf.RoundToInt(arg0);
			float snapTurnDegrees = _snapTurnSteps[num];
			AnimationCurve smoothTurnCurve = _smoothTurnSteps[num];
			TurnerEventBroadcaster[] controllerTurners = _controllerTurners;
			foreach (TurnerEventBroadcaster obj in controllerTurners)
			{
				obj.SnapTurnDegrees = snapTurnDegrees;
				obj.SmoothTurnCurve = smoothTurnCurve;
			}
			controllerTurners = _handTurners;
			foreach (TurnerEventBroadcaster obj2 in controllerTurners)
			{
				obj2.SnapTurnDegrees = snapTurnDegrees;
				obj2.SmoothTurnCurve = smoothTurnCurve;
			}
			TurnLocomotionBroadcaster[] locomotionTurners = _locomotionTurners;
			foreach (TurnLocomotionBroadcaster obj3 in locomotionTurners)
			{
				obj3.SnapTurnDegrees = snapTurnDegrees;
				obj3.SmoothTurnCurve = smoothTurnCurve;
			}
		}

		private void HandleSnapTurnChanged(bool snapTurn)
		{
			if (snapTurn)
			{
				TurnerEventBroadcaster[] controllerTurners = _controllerTurners;
				for (int i = 0; i < controllerTurners.Length; i++)
				{
					controllerTurners[i].TurnMethod = TurnerEventBroadcaster.TurnMode.Snap;
				}
			}
		}

		private void HandleSmoothTurnChanged(bool smoothTurn)
		{
			if (smoothTurn)
			{
				TurnerEventBroadcaster[] controllerTurners = _controllerTurners;
				for (int i = 0; i < controllerTurners.Length; i++)
				{
					controllerTurners[i].TurnMethod = TurnerEventBroadcaster.TurnMode.Smooth;
				}
			}
		}
	}
	public class MenuToggler : MonoBehaviour
	{
		[SerializeField]
		private GameObject _panel;

		[SerializeField]
		[Optional]
		private Button _closeButton;

		[SerializeField]
		private Transform _headAnchor;

		[SerializeField]
		private Vector3 _spawnOffset = new Vector3(0f, -0.1f, 0.3f);

		protected bool _started;

		public Transform HeadAnchor
		{
			get
			{
				return _headAnchor;
			}
			set
			{
				_headAnchor = value;
			}
		}

		public Vector3 SpawnOffset
		{
			get
			{
				return _spawnOffset;
			}
			set
			{
				_spawnOffset = value;
			}
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
				if (_closeButton != null)
				{
					_closeButton.onClick.AddListener(HidePanel);
				}
				if (!_panel.activeSelf)
				{
					HidePanel();
				}
			}
		}

		protected virtual void OnDisable()
		{
			if (_started && _closeButton != null)
			{
				_closeButton.onClick.RemoveListener(HidePanel);
			}
		}

		public void TogglePanel()
		{
			if (_panel.activeSelf)
			{
				HidePanel();
			}
			else
			{
				ShowPanel();
			}
		}

		public void HidePanel()
		{
			_panel.SetActive(value: false);
		}

		public void ShowPanel()
		{
			Quaternion quaternion = Quaternion.LookRotation(Vector3.ProjectOnPlane(_headAnchor.forward, Vector3.up).normalized);
			Vector3 position = _headAnchor.position + quaternion * _spawnOffset;
			quaternion *= Quaternion.Euler(15f, 0f, 0f);
			Pose pose = new Pose(position, quaternion);
			_panel.transform.SetPose(in pose);
			_panel.SetActive(value: true);
		}

		public void InjectAllAUIToggler(GameObject panel)
		{
			InjectPanel(panel);
		}

		public void InjectPanel(GameObject panel)
		{
			_panel = panel;
		}

		public void InjectOptionalCloseButton(Button closeButton)
		{
			_closeButton = closeButton;
		}
	}
	public class LocomotorSound : MonoBehaviour
	{
		[SerializeField]
		[Interface(typeof(ILocomotionEventHandler), new Type[] { })]
		private UnityEngine.Object _locomotor;

		[SerializeField]
		private AdjustableAudio _translationSound;

		[SerializeField]
		private AdjustableAudio _translationDeniedSound;

		[SerializeField]
		private AdjustableAudio _snapTurnSound;

		[SerializeField]
		private AnimationCurve _translationCurve = AnimationCurve.EaseInOut(0f, 0f, 2f, 1f);

		[SerializeField]
		private AnimationCurve _rotationCurve = AnimationCurve.EaseInOut(0f, 0f, 180f, 1f);

		[SerializeField]
		private float _pitchVariance = 0.05f;

		protected bool _started;

		private ILocomotionEventHandler Locomotor { get; set; }

		protected virtual void Awake()
		{
			Locomotor = _locomotor as ILocomotionEventHandler;
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
				Locomotor.WhenLocomotionEventHandled += HandleLocomotionEvent;
			}
		}

		protected virtual void OnDisable()
		{
			if (_started)
			{
				Locomotor.WhenLocomotionEventHandled -= HandleLocomotionEvent;
			}
		}

		private void HandleLocomotionEvent(LocomotionEvent locomotionEvent, Pose delta)
		{
			if (locomotionEvent.Translation == LocomotionEvent.TranslationType.Absolute || locomotionEvent.Translation == LocomotionEvent.TranslationType.AbsoluteEyeLevel || locomotionEvent.Translation == LocomotionEvent.TranslationType.Relative)
			{
				PlayTranslationSound(delta.position.magnitude);
			}
			if (locomotionEvent.Rotation == LocomotionEvent.RotationType.Relative)
			{
				PlayRotationSound(delta.rotation.y * delta.rotation.w);
			}
			if (locomotionEvent.Translation == LocomotionEvent.TranslationType.None && locomotionEvent.Rotation == LocomotionEvent.RotationType.None)
			{
				PlayDenialSound(delta.position.magnitude);
			}
		}

		private void PlayTranslationSound(float translationDistance)
		{
			float num = _translationCurve.Evaluate(translationDistance);
			float pitchT = num + UnityEngine.Random.Range(0f - _pitchVariance, _pitchVariance);
			_translationSound.PlayAudio(num, pitchT);
		}

		private void PlayDenialSound(float translationDistance)
		{
			float num = _translationCurve.Evaluate(translationDistance);
			float pitchT = num + UnityEngine.Random.Range(0f - _pitchVariance, _pitchVariance);
			_translationDeniedSound.PlayAudio(num, pitchT);
		}

		private void PlayRotationSound(float rotationLength)
		{
			float num = _rotationCurve.Evaluate(Mathf.Abs(rotationLength));
			float pitchT = num + UnityEngine.Random.Range(0f - _pitchVariance, _pitchVariance);
			_snapTurnSound.PlayAudio(num, pitchT, rotationLength);
		}

		public void InjectAllLocomotorSound(ILocomotionEventHandler locomotor)
		{
			InjectPlayerLocomotor(locomotor);
		}

		public void InjectPlayerLocomotor(ILocomotionEventHandler locomotor)
		{
			_locomotor = locomotor as UnityEngine.Object;
			Locomotor = locomotor;
		}
	}
}
namespace Oculus.Interaction.Demo
{
	[RequireComponent(typeof(MeshFilter))]
	public class MeshBlit : MonoBehaviour
	{
		private static int MAIN_TEX = Shader.PropertyToID("_MainTex");

		public Material material;

		public RenderTexture renderTexture;

		[SerializeField]
		private float _blitsPerSecond = -1f;

		private Mesh _mesh;

		private WaitForSeconds _waitForSeconds;

		public float BlitsPerSecond
		{
			get
			{
				return _blitsPerSecond;
			}
			set
			{
				SetBlitsPerSecond(value);
			}
		}

		private Mesh Mesh
		{
			get
			{
				if (!_mesh)
				{
					return _mesh = GetComponent<MeshFilter>().sharedMesh;
				}
				return _mesh;
			}
		}

		private void OnEnable()
		{
			SetBlitsPerSecond(_blitsPerSecond);
			StartCoroutine(BlitRoutine());
			IEnumerator BlitRoutine()
			{
				while (true)
				{
					yield return _waitForSeconds;
					Blit();
				}
			}
		}

		public void Blit()
		{
			if (renderTexture == null)
			{
				throw new NullReferenceException("MeshBlit.Blit must have a RenderTexture assigned");
			}
			if (material == null)
			{
				throw new NullReferenceException("MeshBlit.Blit must have a Material assigned");
			}
			if (Mesh == null)
			{
				throw new NullReferenceException("MeshBlit.Blit's MeshFilter has no mesh");
			}
			RenderTexture temporary = RenderTexture.GetTemporary(renderTexture.descriptor);
			Graphics.Blit(renderTexture, temporary);
			material.SetTexture(MAIN_TEX, temporary);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = renderTexture;
			material.SetPass(0);
			Graphics.DrawMeshNow(Mesh, base.transform.localToWorldMatrix);
			RenderTexture.active = active;
			material.SetTexture(MAIN_TEX, null);
			RenderTexture.ReleaseTemporary(temporary);
		}

		private void SetBlitsPerSecond(float value)
		{
			_blitsPerSecond = value;
			_waitForSeconds = ((value > 0f) ? new WaitForSeconds(1f / _blitsPerSecond) : null);
		}
	}
	public class WaterSpray : MonoBehaviour, IHandGrabUseDelegate
	{
		public enum NozzleMode
		{
			Spray,
			Stream
		}

		private static class NonAlloc
		{
			public static readonly Collider[] _overlapResults = new Collider[12];

			public static readonly Dictionary<int, MeshBlit> _blits = new Dictionary<int, MeshBlit>();

			private static readonly List<MeshFilter> _meshFilters = new List<MeshFilter>();

			private static readonly HashSet<Transform> _roots = new HashSet<Transform>();

			private static MaterialPropertyBlock _block;

			public static MaterialPropertyBlock PropertyBlock
			{
				get
				{
					if (_block == null)
					{
						return _block = new MaterialPropertyBlock();
					}
					return _block;
				}
			}

			public static List<MeshFilter> GetMeshFiltersInChildren(Transform root)
			{
				root.GetComponentsInChildren(_meshFilters);
				return _meshFilters;
			}

			public static HashSet<Transform> GetRootsFromOverlapResults(int hitCount)
			{
				_roots.Clear();
				for (int i = 0; i < hitCount; i++)
				{
					Transform root = GetRoot(_overlapResults[i]);
					_roots.Add(root);
				}
				return _roots;
			}

			private static Transform GetRoot(Collider hit)
			{
				if (!hit.attachedRigidbody)
				{
					if (!hit.transform.parent)
					{
						return hit.transform;
					}
					return hit.transform.parent;
				}
				return hit.attachedRigidbody.transform;
			}

			public static void CleanUpDestroyedBlits()
			{
				if (!_blits.ContainsValue(null))
				{
					return;
				}
				foreach (int item in new List<int>(_blits.Keys))
				{
					if (_blits[item] == null)
					{
						_blits.Remove(item);
					}
				}
			}
		}

		[Header("Input")]
		[SerializeField]
		private Transform _trigger;

		[SerializeField]
		private Transform _nozzle;

		[SerializeField]
		private AnimationCurve _triggerRotationCurve;

		[SerializeField]
		private SnapAxis _axis = SnapAxis.X;

		[SerializeField]
		[Range(0f, 1f)]
		private float _releaseThresold = 0.3f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _fireThresold = 0.9f;

		[SerializeField]
		private float _triggerSpeed = 3f;

		[SerializeField]
		private AnimationCurve _strengthCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		[Header("Output")]
		[SerializeField]
		[Tooltip("Masks the Raycast used to find objects to make wet")]
		private LayerMask _raycastLayerMask = -1;

		[SerializeField]
		[Tooltip("The spread angle when spraying, larger values will make a larger area wet")]
		private float _spraySpreadAngle = 40f;

		[SerializeField]
		[Tooltip("The spread angle when using stream, larger values will make a larger area wet")]
		private float _streamSpreadAngle = 4f;

		[SerializeField]
		private float _sprayStrength = 1.5f;

		[SerializeField]
		private int _sprayHits = 6;

		[SerializeField]
		private float _sprayRandomness = 6f;

		[SerializeField]
		[Tooltip("The max distance of the spray, controls the raycast and shader")]
		private float _maxDistance = 2f;

		[SerializeField]
		private float _dryingSpeed = 0.1f;

		[SerializeField]
		[Tooltip("Material for applying a stamp, should using the MeshBlitStamp shader or similar")]
		private Material _sprayStampMaterial;

		[SerializeField]
		[Tooltip("When not null, will be set as the '_WetBumpMap' property on wet renderers")]
		private Texture _waterBumpOverride;

		[SerializeField]
		private UnityEvent WhenSpray;

		[SerializeField]
		private UnityEvent WhenStream;

		private static readonly int WET_MAP_PROPERTY = Shader.PropertyToID("_WetMap");

		private static readonly int STAMP_MULTIPLIER_PROPERTY = Shader.PropertyToID("_StampMultipler");

		private static readonly int SUBTRACT_PROPERTY = Shader.PropertyToID("_Subtract");

		private static readonly int WET_BUMPMAP_PROPERTY = Shader.PropertyToID("_WetBumpMap");

		private static readonly int STAMP_MATRIX_PROPERTY = Shader.PropertyToID("_StampMatrix");

		private static readonly WaitForSeconds WAIT_TIME = new WaitForSeconds(0.1f);

		private bool _wasFired;

		private float _dampedUseStrength;

		private float _lastUseTime;

		private void SprayWater()
		{
			switch (GetNozzleMode())
			{
			case NozzleMode.Spray:
				Spray();
				WhenSpray?.Invoke();
				break;
			case NozzleMode.Stream:
				Stream();
				WhenStream?.Invoke();
				break;
			}
		}

		private void UpdateTriggerRotation(float progress)
		{
			float num = _triggerRotationCurve.Evaluate(progress);
			Vector3 localEulerAngles = _trigger.localEulerAngles;
			if ((_axis & SnapAxis.X) != SnapAxis.None)
			{
				localEulerAngles.x = num;
			}
			if ((_axis & SnapAxis.Y) != SnapAxis.None)
			{
				localEulerAngles.y = num;
			}
			if ((_axis & SnapAxis.Z) != SnapAxis.None)
			{
				localEulerAngles.z = num;
			}
			_trigger.localEulerAngles = localEulerAngles;
		}

		private NozzleMode GetNozzleMode()
		{
			if (((int)_nozzle.localEulerAngles.z + 45) / 90 % 2 == 0)
			{
				return NozzleMode.Spray;
			}
			return NozzleMode.Stream;
		}

		private void Spray()
		{
			StartCoroutine(StampRoutine(_sprayHits, _sprayRandomness, _spraySpreadAngle, _sprayStrength));
		}

		private void Stream()
		{
			StartCoroutine(StampRoutine(_sprayHits, 0f, _streamSpreadAngle, _sprayStrength));
		}

		private IEnumerator StampRoutine(int stampCount, float randomness, float spread, float strength)
		{
			StartStamping();
			Pose originalPose = _nozzle.GetPose();
			for (int i = 0; i < stampCount; i++)
			{
				yield return WAIT_TIME;
				Pose pose = originalPose;
				pose.rotation *= Quaternion.Euler(UnityEngine.Random.Range(0f - randomness, randomness), UnityEngine.Random.Range(0f - randomness, randomness), 0f);
				Stamp(pose, _maxDistance, spread, strength);
			}
			StartDrying();
		}

		private void StartStamping()
		{
			_sprayStampMaterial.SetFloat(SUBTRACT_PROPERTY, 0f);
		}

		private void StartDrying()
		{
			_sprayStampMaterial.SetMatrix(STAMP_MATRIX_PROPERTY, Matrix4x4.zero);
			_sprayStampMaterial.SetFloat(SUBTRACT_PROPERTY, _dryingSpeed);
		}

		private void Stamp(Pose pose, float maxDistance, float angle, float strength)
		{
			_sprayStampMaterial.SetMatrix(STAMP_MATRIX_PROPERTY, CreateStampMatrix(pose, angle));
			_sprayStampMaterial.SetFloat(STAMP_MULTIPLIER_PROPERTY, strength);
			float num = Mathf.Tan(MathF.PI / 180f * angle / 2f) * maxDistance;
			Vector3 point = pose.position + pose.forward * num;
			Vector3 point2 = pose.position + pose.forward * maxDistance;
			HashSet<Transform> rootsFromOverlapResults = NonAlloc.GetRootsFromOverlapResults(Physics.OverlapCapsuleNonAlloc(point, point2, num, NonAlloc._overlapResults, _raycastLayerMask.value, QueryTriggerInteraction.Ignore));
			foreach (Transform item in rootsFromOverlapResults)
			{
				RenderSplash(item);
			}
			rootsFromOverlapResults.Clear();
		}

		private void RenderSplash(Transform rootObject)
		{
			List<MeshFilter> meshFiltersInChildren = NonAlloc.GetMeshFiltersInChildren(rootObject);
			for (int i = 0; i < meshFiltersInChildren.Count; i++)
			{
				int instanceID = meshFiltersInChildren[i].GetInstanceID();
				if (!NonAlloc._blits.ContainsKey(instanceID))
				{
					NonAlloc._blits[instanceID] = CreateMeshBlit(meshFiltersInChildren[i]);
				}
				NonAlloc._blits[instanceID].Blit();
			}
		}

		private MeshBlit CreateMeshBlit(MeshFilter meshFilter)
		{
			MeshBlit meshBlit = meshFilter.gameObject.AddComponent<MeshBlit>();
			meshBlit.material = _sprayStampMaterial;
			meshBlit.renderTexture = new RenderTexture(512, 512, 0, RenderTextureFormat.RHalf);
			meshBlit.BlitsPerSecond = 30f;
			if (meshFilter.TryGetComponent<Renderer>(out var component))
			{
				component.GetPropertyBlock(NonAlloc.PropertyBlock);
				NonAlloc.PropertyBlock.SetTexture(WET_MAP_PROPERTY, meshBlit.renderTexture);
				if ((bool)_waterBumpOverride)
				{
					NonAlloc.PropertyBlock.SetTexture(WET_BUMPMAP_PROPERTY, _waterBumpOverride);
				}
				component.SetPropertyBlock(NonAlloc.PropertyBlock);
			}
			return meshBlit;
		}

		private Matrix4x4 CreateStampMatrix(Pose pose, float angle)
		{
			Matrix4x4 inverse = Matrix4x4.TRS(pose.position, pose.rotation, Vector3.one).inverse;
			inverse.m20 *= -1f;
			inverse.m21 *= -1f;
			inverse.m22 *= -1f;
			inverse.m23 *= -1f;
			return GL.GetGPUProjectionMatrix(Matrix4x4.Perspective(angle, 1f, 0f, _maxDistance), renderIntoTexture: true) * inverse;
		}

		private void OnDestroy()
		{
			NonAlloc.CleanUpDestroyedBlits();
		}

		public void BeginUse()
		{
			_dampedUseStrength = 0f;
			_lastUseTime = Time.realtimeSinceStartup;
		}

		public void EndUse()
		{
		}

		public float ComputeUseStrength(float strength)
		{
			float num = Time.realtimeSinceStartup - _lastUseTime;
			_lastUseTime = Time.realtimeSinceStartup;
			if (strength > _dampedUseStrength)
			{
				_dampedUseStrength = Mathf.Lerp(_dampedUseStrength, strength, _triggerSpeed * num);
			}
			else
			{
				_dampedUseStrength = strength;
			}
			float num2 = _strengthCurve.Evaluate(_dampedUseStrength);
			UpdateTriggerProgress(num2);
			return num2;
		}

		private void UpdateTriggerProgress(float progress)
		{
			UpdateTriggerRotation(progress);
			if (progress >= _fireThresold && !_wasFired)
			{
				_wasFired = true;
				SprayWater();
			}
			else if (progress <= _releaseThresold)
			{
				_wasFired = false;
			}
		}
	}
	public class WaterSprayNozzleTransformer : MonoBehaviour, ITransformer
	{
		[SerializeField]
		private float _factor = 3f;

		[SerializeField]
		private float _snapAngle = 90f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _snappiness = 0.8f;

		[SerializeField]
		private int _maxSteps = 1;

		private float _relativeAngle;

		private int _stepsCount;

		private IGrabbable _grabbable;

		private Pose _previousGrabPose;

		public void Initialize(IGrabbable grabbable)
		{
			_grabbable = grabbable;
		}

		public void BeginTransform()
		{
			_previousGrabPose = _grabbable.GrabPoints[0];
			_relativeAngle = 0f;
			_stepsCount = 0;
		}

		public void UpdateTransform()
		{
			Pose previousGrabPose = _grabbable.GrabPoints[0];
			Transform transform = _grabbable.Transform;
			Vector3 forward = Vector3.forward;
			Vector3 vector = transform.TransformDirection(forward);
			Vector3 normalized = Vector3.ProjectOnPlane(_previousGrabPose.right, vector).normalized;
			Vector3 normalized2 = Vector3.ProjectOnPlane(previousGrabPose.right, vector).normalized;
			float num = Vector3.SignedAngle(normalized, normalized2, vector) * _factor;
			_relativeAngle += num;
			if (Mathf.Abs(_relativeAngle) > _snapAngle * (1f - _snappiness) && Mathf.Abs((float)_stepsCount + Mathf.Sign(_relativeAngle)) <= (float)_maxSteps)
			{
				int num2 = Mathf.FloorToInt((transform.localEulerAngles.z + _snappiness * 0.5f) / _snapAngle);
				float num3 = Mathf.Sign(_relativeAngle);
				float z = ((num3 > 0f) ? (_snapAngle * (float)(num2 + 1)) : (_snapAngle * (float)num2));
				Vector3 localEulerAngles = transform.localEulerAngles;
				localEulerAngles.z = z;
				transform.localEulerAngles = localEulerAngles;
				_relativeAngle = 0f;
				_stepsCount += (int)num3;
			}
			else
			{
				transform.Rotate(vector, num, Space.World);
			}
			_previousGrabPose = previousGrabPose;
		}

		public void EndTransform()
		{
		}
	}
	public class BasicPBRGlobals : MonoBehaviour
	{
		[SerializeField]
		private Light _mainlight;

		private void Update()
		{
			UpateShaderGlobals();
		}

		private void UpateShaderGlobals()
		{
			Light mainlight = _mainlight;
			bool flag = (bool)mainlight && mainlight.isActiveAndEnabled;
			Shader.SetGlobalVector("_BasicPBRLightDir", flag ? mainlight.transform.forward : Vector3.down);
			Shader.SetGlobalColor("_BasicPBRLightColor", flag ? mainlight.color : Color.black);
		}
	}
}
namespace Oculus.Interaction.HandGrab.Recorder
{
	public class HandGrabPoseLiveRecorder : MonoBehaviour, IActiveState
	{
		private struct RecorderStep
		{
			public HandGrabInteractable interactable;

			public HandPose RawHandPose { get; private set; }

			public Pose GrabPoint { get; private set; }

			public Rigidbody Item { get; private set; }

			public float HandScale { get; private set; }

			public RecorderStep(HandPose rawPose, Pose grabPoint, float scale, Rigidbody item)
			{
				RawHandPose = new HandPose(rawPose);
				GrabPoint = grabPoint;
				HandScale = scale;
				Item = item;
				interactable = null;
			}

			public void ClearInteractable()
			{
				if (interactable != null)
				{
					UnityEngine.Object.Destroy(interactable.gameObject);
				}
			}
		}

		[SerializeField]
		private HandGrabInteractor _leftHand;

		[SerializeField]
		private HandGrabInteractor _rightHand;

		[HideInInspector]
		[SerializeField]
		[Tooltip("Prototypes of the static hands (ghosts) that visualize holding poses")]
		private HandGhostProvider _ghostProvider;

		[SerializeField]
		[Tooltip("Prototypes of the static hands (ghosts) that visualize holding poses")]
		private HandGhostProvider _handGhostProvider;

		[SerializeField]
		[Optional]
		private TimerUIControl _timerControl;

		[SerializeField]
		[Optional]
		private TextMeshPro _delayLabel;

		private RigidbodyDetector _leftDetector;

		private RigidbodyDetector _rightDetector;

		private WaitForSeconds _waitOneSeconds = new WaitForSeconds(1f);

		private Coroutine _delayedSnapRoutine;

		public UnityEvent WhenTimeStep;

		public UnityEvent WhenSnapshot;

		public UnityEvent WhenError;

		[Space]
		public UnityEvent<bool> WhenCanUndo;

		public UnityEvent<bool> WhenCanRedo;

		public UnityEvent WhenGrabAllowed;

		public UnityEvent WhenGrabDisallowed;

		private List<RecorderStep> _recorderSteps = new List<RecorderStep>();

		private int _currentStepIndex;

		private bool _grabbingEnabled = true;

		private HandGhostProvider GhostProvider => _handGhostProvider;

		private int CurrentStepIndex
		{
			get
			{
				return _currentStepIndex;
			}
			set
			{
				_currentStepIndex = value;
				WhenCanUndo?.Invoke(_currentStepIndex >= 0);
				WhenCanRedo?.Invoke(_currentStepIndex + 1 < _recorderSteps.Count);
			}
		}

		public bool Active => _grabbingEnabled;

		private void Awake()
		{
			_leftHand.InjectOptionalActiveState(this);
			_rightHand.InjectOptionalActiveState(this);
		}

		private void Start()
		{
			ClearSnapshot();
			_leftDetector = _leftHand.Rigidbody.gameObject.AddComponent<RigidbodyDetector>();
			_leftDetector.IgnoreBody(_rightHand.Rigidbody);
			_rightDetector = _rightHand.Rigidbody.gameObject.AddComponent<RigidbodyDetector>();
			_rightDetector.IgnoreBody(_leftHand.Rigidbody);
			CurrentStepIndex = -1;
			EnableGrabbing(enable: true);
		}

		public void Record()
		{
			ClearSnapshot();
			if (_timerControl != null)
			{
				_delayedSnapRoutine = StartCoroutine(DelayedSnapshot(_timerControl.DelaySeconds));
			}
			else
			{
				TakeSnapshot();
			}
		}

		private void ClearSnapshot()
		{
			if (_delayedSnapRoutine != null)
			{
				StopCoroutine(_delayedSnapRoutine);
				_delayedSnapRoutine = null;
			}
			_delayLabel.text = string.Empty;
		}

		private IEnumerator DelayedSnapshot(int seconds)
		{
			for (int i = seconds; i > 0; i--)
			{
				_delayLabel.text = i.ToString();
				WhenTimeStep?.Invoke();
				yield return _waitOneSeconds;
			}
			if (TakeSnapshot())
			{
				_delayLabel.text = "<size=10>Snap!";
				WhenSnapshot?.Invoke();
			}
			else
			{
				_delayLabel.text = "<size=10>Error";
				WhenError?.Invoke();
			}
			yield return _waitOneSeconds;
			_delayLabel.text = string.Empty;
		}

		private bool TakeSnapshot()
		{
			float bestDistance;
			Rigidbody rigidbody = FindNearestItem(_leftHand.Rigidbody, _leftDetector, out bestDistance);
			float bestDistance2;
			Rigidbody rigidbody2 = FindNearestItem(_rightHand.Rigidbody, _rightDetector, out bestDistance2);
			if (bestDistance < bestDistance2 && rigidbody != null)
			{
				return Record(_leftHand.Hand, rigidbody);
			}
			if (rigidbody2 != null)
			{
				return Record(_rightHand.Hand, rigidbody2);
			}
			UnityEngine.Debug.LogError("No rigidbody detected near any hand");
			return false;
		}

		private Rigidbody FindNearestItem(Rigidbody handBody, RigidbodyDetector detector, out float bestDistance)
		{
			Vector3 worldCenterOfMass = handBody.worldCenterOfMass;
			float num = float.PositiveInfinity;
			Rigidbody result = null;
			foreach (Rigidbody intersectingBody in detector.IntersectingBodies)
			{
				float num2 = Vector3.Distance(intersectingBody.worldCenterOfMass, worldCenterOfMass);
				if (num2 < num)
				{
					num = num2;
					result = intersectingBody;
				}
			}
			bestDistance = num;
			return result;
		}

		public void Undo()
		{
			if (CurrentStepIndex >= 0)
			{
				_recorderSteps[CurrentStepIndex].ClearInteractable();
				CurrentStepIndex--;
			}
		}

		public void Redo()
		{
			if (CurrentStepIndex + 1 < _recorderSteps.Count)
			{
				CurrentStepIndex++;
				RecorderStep recorderStep = _recorderSteps[CurrentStepIndex];
				AddHandGrabPose(recorderStep, out recorderStep.interactable, out var handGrabPose);
				AttachGhost(handGrabPose, recorderStep.HandScale);
				_recorderSteps[CurrentStepIndex] = recorderStep;
			}
		}

		public void EnableGrabbing(bool enable)
		{
			_grabbingEnabled = enable;
			if (enable)
			{
				WhenGrabAllowed?.Invoke();
			}
			else
			{
				WhenGrabDisallowed?.Invoke();
			}
		}

		private bool Record(IHand hand, Rigidbody item)
		{
			HandPose handPose = TrackedPose(hand);
			if (handPose == null)
			{
				UnityEngine.Debug.LogError("Tracked Pose could not be retrieved", this);
				return false;
			}
			if (!hand.GetRootPose(out var pose))
			{
				UnityEngine.Debug.LogError("Hand Root pose could not be retrieved", this);
				return false;
			}
			Pose grabPoint = PoseUtils.DeltaScaled(item.transform, pose);
			RecorderStep recorderStep = new RecorderStep(handPose, grabPoint, hand.Scale, item);
			AddHandGrabPose(recorderStep, out recorderStep.interactable, out var handGrabPose);
			AttachGhost(handGrabPose, recorderStep.HandScale);
			int num = CurrentStepIndex + 1;
			if (num < _recorderSteps.Count)
			{
				_recorderSteps.RemoveRange(num, _recorderSteps.Count - num);
			}
			_recorderSteps.Add(recorderStep);
			CurrentStepIndex = _recorderSteps.Count - 1;
			return true;
		}

		private HandPose TrackedPose(IHand hand)
		{
			if (!hand.GetJointPosesLocal(out var localJointPoses))
			{
				return null;
			}
			HandPose handPose = new HandPose(hand.Handedness);
			for (int i = 0; i < FingersMetadata.HAND_JOINT_IDS.Length; i++)
			{
				HandJointId index = FingersMetadata.HAND_JOINT_IDS[i];
				handPose.JointRotations[i] = localJointPoses[index].rotation;
			}
			return handPose;
		}

		private void AddHandGrabPose(RecorderStep recorderStep, out HandGrabInteractable interactable, out HandGrabPose handGrabPose)
		{
			interactable = HandGrabUtils.CreateHandGrabInteractable(recorderStep.Item.transform);
			if (recorderStep.Item.TryGetComponent<Grabbable>(out var component))
			{
				interactable.InjectOptionalPointableElement(component);
			}
			HandGrabUtils.HandGrabPoseData poseData = new HandGrabUtils.HandGrabPoseData
			{
				handPose = recorderStep.RawHandPose,
				scale = recorderStep.HandScale / interactable.RelativeTo.lossyScale.x,
				gripPose = recorderStep.GrabPoint
			};
			handGrabPose = HandGrabUtils.LoadHandGrabPose(interactable, poseData);
		}

		private void AttachGhost(HandGrabPose point, float referenceScale)
		{
			if (!(GhostProvider == null))
			{
				HandGhost handGhost = UnityEngine.Object.Instantiate(GhostProvider.GetHand(point.HandPose.Handedness), point.transform);
				handGhost.transform.localScale = Vector3.one * (referenceScale / point.transform.lossyScale.x);
				handGhost.SetPose(point);
			}
		}
	}
	public class RigidbodyDetector : MonoBehaviour
	{
		private HashSet<Rigidbody> _ignoredBodies = new HashSet<Rigidbody>();

		public List<Rigidbody> IntersectingBodies { get; private set; } = new List<Rigidbody>();

		public void IgnoreBody(Rigidbody body)
		{
			if (!_ignoredBodies.Contains(body))
			{
				_ignoredBodies.Add(body);
			}
			if (IntersectingBodies.Contains(body))
			{
				IntersectingBodies.Remove(body);
			}
		}

		public void UnIgnoreBody(Rigidbody body)
		{
			if (_ignoredBodies.Contains(body))
			{
				_ignoredBodies.Remove(body);
			}
		}

		private void OnTriggerEnter(Collider collider)
		{
			Rigidbody attachedRigidbody = collider.attachedRigidbody;
			if (!(attachedRigidbody == null) && !_ignoredBodies.Contains(attachedRigidbody) && !IntersectingBodies.Contains(attachedRigidbody))
			{
				IntersectingBodies.Add(attachedRigidbody);
			}
		}

		private void OnTriggerExit(Collider collider)
		{
			Rigidbody attachedRigidbody = collider.attachedRigidbody;
			if (!(attachedRigidbody == null) && IntersectingBodies.Contains(attachedRigidbody))
			{
				IntersectingBodies.Remove(attachedRigidbody);
			}
		}
	}
	public class TimerUIControl : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _timerLabel;

		[SerializeField]
		private int _delaySeconds = 3;

		[SerializeField]
		private int _maxSeconds = 10;

		[SerializeField]
		private Button _moreButton;

		[SerializeField]
		private Button _lessButton;

		public int DelaySeconds
		{
			get
			{
				return _delaySeconds;
			}
			set
			{
				_delaySeconds = Mathf.Clamp(value, 0, _maxSeconds);
				UpdateDisplay(value);
			}
		}

		private void OnEnable()
		{
			_moreButton.onClick.AddListener(IncreaseTime);
			_lessButton.onClick.AddListener(DecreaseTime);
		}

		private void OnDisable()
		{
			_moreButton.onClick.RemoveListener(IncreaseTime);
			_lessButton.onClick.RemoveListener(DecreaseTime);
		}

		private void Start()
		{
			UpdateDisplay(DelaySeconds);
		}

		private void IncreaseTime()
		{
			DelaySeconds++;
		}

		private void DecreaseTime()
		{
			DelaySeconds--;
		}

		private void UpdateDisplay(int seconds)
		{
			_timerLabel.text = $"{seconds}\nseconds";
			_lessButton.interactable = seconds > 0;
			_moreButton.interactable = seconds < _maxSeconds;
		}
	}
}
namespace Oculus.Interaction.Body.Samples
{
	public class BodyPoseSwitcher : MonoBehaviour, IBodyPose
	{
		public enum PoseSource
		{
			PoseA,
			PoseB
		}

		[SerializeField]
		[Interface(typeof(IBodyPose), new Type[] { })]
		private UnityEngine.Object _poseA;

		private IBodyPose PoseA;

		[SerializeField]
		[Interface(typeof(IBodyPose), new Type[] { })]
		private UnityEngine.Object _poseB;

		private IBodyPose PoseB;

		[SerializeField]
		private PoseSource _source;

		protected bool _started;

		public ISkeletonMapping SkeletonMapping => GetPose().SkeletonMapping;

		public PoseSource Source
		{
			get
			{
				return _source;
			}
			set
			{
				bool num = value != _source;
				_source = value;
				if (num)
				{
					this.WhenBodyPoseUpdated();
				}
			}
		}

		public event Action WhenBodyPoseUpdated = delegate
		{
		};

		public bool GetJointPoseFromRoot(BodyJointId bodyJointId, out Pose pose)
		{
			return GetPose().GetJointPoseFromRoot(bodyJointId, out pose);
		}

		public bool GetJointPoseLocal(BodyJointId bodyJointId, out Pose pose)
		{
			return GetPose().GetJointPoseLocal(bodyJointId, out pose);
		}

		public void UsePoseA()
		{
			Source = PoseSource.PoseA;
		}

		public void UsePoseB()
		{
			Source = PoseSource.PoseB;
		}

		protected virtual void Awake()
		{
			PoseA = _poseA as IBodyPose;
			PoseB = _poseB as IBodyPose;
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
				PoseA.WhenBodyPoseUpdated += delegate
				{
					OnPoseUpdated(PoseSource.PoseA);
				};
				PoseB.WhenBodyPoseUpdated += delegate
				{
					OnPoseUpdated(PoseSource.PoseB);
				};
			}
		}

		protected virtual void OnDisable()
		{
			if (_started)
			{
				PoseA.WhenBodyPoseUpdated -= delegate
				{
					OnPoseUpdated(PoseSource.PoseA);
				};
				PoseB.WhenBodyPoseUpdated -= delegate
				{
					OnPoseUpdated(PoseSource.PoseB);
				};
			}
		}

		private void OnPoseUpdated(PoseSource source)
		{
			if (source == Source)
			{
				this.WhenBodyPoseUpdated();
			}
		}

		private IBodyPose GetPose()
		{
			PoseSource source = Source;
			if (source == PoseSource.PoseA || source != PoseSource.PoseB)
			{
				return PoseA;
			}
			return PoseB;
		}
	}
	public class LockedBodyPose : MonoBehaviour, IBodyPose
	{
		private static readonly Pose HIP_OFFSET = new Pose
		{
			position = new Vector3(0f, 0.923987f, 0f),
			rotation = Quaternion.Euler(0f, 270f, 270f)
		};

		[Tooltip("The body pose to be locked")]
		[SerializeField]
		[Interface(typeof(IBodyPose), new Type[] { })]
		private UnityEngine.Object _pose;

		private IBodyPose Pose;

		[Tooltip("The body pose will be locked relative to this joint at the specified offset.")]
		[SerializeField]
		private BodyJointId _referenceJoint = BodyJointId.Body_Hips;

		[Tooltip("The reference joint will be placed at this offset from the root.")]
		[SerializeField]
		private Pose _referenceOffset = HIP_OFFSET;

		protected bool _started;

		private Dictionary<BodyJointId, Pose> _lockedPoses;

		public ISkeletonMapping SkeletonMapping => Pose.SkeletonMapping;

		public event Action WhenBodyPoseUpdated = delegate
		{
		};

		public bool GetJointPoseLocal(BodyJointId bodyJointId, out Pose pose)
		{
			return Pose.GetJointPoseLocal(bodyJointId, out pose);
		}

		public bool GetJointPoseFromRoot(BodyJointId bodyJointId, out Pose pose)
		{
			return _lockedPoses.TryGetValue(bodyJointId, out pose);
		}

		private void UpdateLockedBodyPose()
		{
			_lockedPoses.Clear();
			for (int i = 0; i < 84; i++)
			{
				BodyJointId bodyJointId = (BodyJointId)i;
				if (Pose.GetJointPoseFromRoot(_referenceJoint, out var pose) && Pose.GetJointPoseFromRoot(bodyJointId, out var pose2))
				{
					pose.Invert();
					PoseUtils.Multiply(in pose, in pose2, ref pose2);
					PoseUtils.Multiply(in _referenceOffset, in pose2, ref pose2);
					_lockedPoses[bodyJointId] = pose2;
				}
			}
			this.WhenBodyPoseUpdated();
		}

		protected virtual void Awake()
		{
			_lockedPoses = new Dictionary<BodyJointId, Pose>();
			Pose = _pose as IBodyPose;
		}

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			UpdateLockedBodyPose();
			this.EndStart(ref _started);
		}

		protected virtual void OnEnable()
		{
			if (_started)
			{
				Pose.WhenBodyPoseUpdated += UpdateLockedBodyPose;
			}
		}

		protected virtual void OnDisable()
		{
			if (_started)
			{
				Pose.WhenBodyPoseUpdated -= UpdateLockedBodyPose;
			}
		}
	}
	public class PoseCaptureCountdown : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent _timerStart = new UnityEvent();

		[SerializeField]
		private UnityEvent _timerSecondTick = new UnityEvent();

		[SerializeField]
		private UnityEvent _timeUp = new UnityEvent();

		[SerializeField]
		private TextMeshProUGUI _countdownText;

		[SerializeField]
		private string _poseText = "Capture Pose";

		[SerializeField]
		private float duration = 10f;

		[SerializeField]
		[Optional]
		private Renderer _renderer;

		[SerializeField]
		[Optional]
		private Color _resetColor;

		private float _timer;

		public void Restart()
		{
			_timer = duration;
			_timerStart.Invoke();
			if (_renderer != null)
			{
				_renderer.material.color = _resetColor;
			}
		}

		private void Update()
		{
			bool num = _timer > 0f;
			if (num)
			{
				int num2 = (int)_timer;
				_timer -= Time.unscaledDeltaTime;
				if ((int)_timer < num2)
				{
					_timerSecondTick.Invoke();
				}
			}
			bool flag = _timer > 0f;
			if (num && !flag)
			{
				_timer = 0f;
				_timeUp.Invoke();
				_countdownText.text = _poseText;
			}
			else if (flag)
			{
				_countdownText.text = _timer.ToString("#0.0");
			}
		}
	}
}
namespace Oculus.Interaction.Samples
{
	public class DropDownGroup : MonoBehaviour
	{
		[SerializeField]
		[Optional(OptionalAttribute.Flag.AutoGenerated)]
		[Tooltip("ToggleGroup for all the options in the dropdown. It will be enforced to dissallow off-state and be referenced in all toggles. If none provided it will be searched in the hierarchy under this component.")]
		private ToggleGroup _toggleGroup;

		[SerializeField]
		[Optional]
		[Tooltip("The toggle for the headerIt will be closed automatically when an option is selected.")]
		private Toggle _headerToggle;

		[SerializeField]
		[Optional(OptionalAttribute.Flag.AutoGenerated)]
		[Tooltip("Toggles for all options in the dropdown, if none provided it will be searched in the hierarchy under the toggle group.")]
		private Toggle[] _toggles;

		public UnityEvent<int> WhenSelectionChanged;

		[Header("Header visuals")]
		[SerializeField]
		[Optional(OptionalAttribute.Flag.DontHide)]
		[Tooltip("Title label in the header")]
		private TextMeshProUGUI _title;

		[SerializeField]
		[ConditionalHide("_title", null, ConditionalHideAttribute.DisplayMode.HideIfTrue)]
		[Tooltip("Name of the Gameobject holding the title in each option.")]
		private string _titleName = "Title";

		[SerializeField]
		[Optional(OptionalAttribute.Flag.DontHide)]
		[Tooltip("Subtitle label in the header.")]
		private TextMeshProUGUI _subtitle;

		[SerializeField]
		[ConditionalHide("_subtitle", null, ConditionalHideAttribute.DisplayMode.HideIfTrue)]
		[Tooltip("Name of the Gameobject holding the subtitle in each option.")]
		private string _subtitleName = "Subtitle";

		[SerializeField]
		[Optional(OptionalAttribute.Flag.DontHide)]
		[Tooltip("Image for the icon in the header.")]
		private Image _icon;

		[SerializeField]
		[ConditionalHide("_icon", null, ConditionalHideAttribute.DisplayMode.HideIfTrue)]
		[Tooltip("Name of the Gameobject holding the icon in each option.")]
		private string _iconName = "Icon";

		private int _selectedIndex = -1;

		private UnityAction<bool>[] _toggleActions;

		protected bool _started;

		public TextMeshProUGUI Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
			}
		}

		public string TitleName
		{
			get
			{
				return _titleName;
			}
			set
			{
				_titleName = value;
			}
		}

		public TextMeshProUGUI Subtitle
		{
			get
			{
				return _subtitle;
			}
			set
			{
				_subtitle = value;
			}
		}

		public string SubtitleName
		{
			get
			{
				return _subtitleName;
			}
			set
			{
				_subtitleName = value;
			}
		}

		public Image Icon
		{
			get
			{
				return _icon;
			}
			set
			{
				_icon = value;
			}
		}

		public string IconName
		{
			get
			{
				return _iconName;
			}
			set
			{
				_iconName = value;
			}
		}

		public int SelectedIndex
		{
			get
			{
				return _selectedIndex;
			}
			private set
			{
				if (_selectedIndex != value)
				{
					_selectedIndex = value;
					WhenSelectionChanged.Invoke(_selectedIndex);
				}
			}
		}

		public Toggle SelectedToggle
		{
			get
			{
				if (_selectedIndex < 0)
				{
					return null;
				}
				return _toggles[_selectedIndex];
			}
		}

		protected virtual void Reset()
		{
			_toggleGroup = GetComponentInChildren<ToggleGroup>();
		}

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			if (_toggleGroup == null)
			{
				_toggleGroup = GetComponentInChildren<ToggleGroup>();
			}
			if (_toggles == null || _toggles.Length == 0)
			{
				Toggle[] componentsInChildren = _toggleGroup.transform.GetComponentsInChildren<Toggle>();
				_toggles = componentsInChildren.Where((Toggle toggle) => toggle.group == _toggleGroup).ToArray();
			}
			InitializeToggleActions();
			InitializeToggleGroup();
			this.EndStart(ref _started);
		}

		protected virtual void OnEnable()
		{
			if (_started)
			{
				for (int i = 0; i < _toggles.Length; i++)
				{
					_toggles[i].onValueChanged.AddListener(_toggleActions[i]);
				}
				ForceUpdateSelectedIndex();
			}
		}

		protected virtual void OnDisable()
		{
			if (_started)
			{
				for (int i = 0; i < _toggles.Length; i++)
				{
					_toggles[i].onValueChanged.RemoveListener(_toggleActions[i]);
				}
			}
		}

		private void ForceUpdateSelectedIndex()
		{
			for (int i = 0; i < _toggles.Length; i++)
			{
				if (_toggles[i].isOn)
				{
					SelectedIndex = i;
					break;
				}
			}
			HandleToggleChanged(isOn: true, SelectedIndex);
		}

		private void InitializeToggleActions()
		{
			_toggleActions = new UnityAction<bool>[_toggles.Length];
			for (int i = 0; i < _toggleActions.Length; i++)
			{
				int toggleIndex = i;
				_toggleActions[i] = delegate(bool isOn)
				{
					HandleToggleChanged(isOn, toggleIndex);
					if (isOn)
					{
						_headerToggle.isOn = false;
					}
				};
			}
		}

		private void InitializeToggleGroup()
		{
			_toggleGroup.allowSwitchOff = false;
			Toggle[] toggles = _toggles;
			foreach (Toggle toggle in toggles)
			{
				if (!(toggle.group == _toggleGroup))
				{
					if (toggle.group != null)
					{
						toggle.group.UnregisterToggle(toggle);
					}
					toggle.group = _toggleGroup;
					_toggleGroup.RegisterToggle(toggle);
				}
			}
			_toggleGroup.EnsureValidState();
		}

		private void HandleToggleChanged(bool isOn, int index)
		{
			if (isOn && index >= 0)
			{
				Toggle toggle = _toggles[index];
				if (_title != null && _title.gameObject.activeSelf && TryGetChildComponent<TextMeshProUGUI>(toggle.transform, _titleName, out var component))
				{
					_title.text = component.text;
				}
				if (_subtitle != null && _subtitle.gameObject.activeSelf && TryGetChildComponent<TextMeshProUGUI>(toggle.transform, _subtitleName, out var component2))
				{
					_subtitle.text = component2.text;
				}
				if (_icon != null && _icon.gameObject.activeSelf && TryGetChildComponent<Image>(toggle.transform, _iconName, out var component3))
				{
					_icon.sprite = component3.sprite;
				}
				SelectedIndex = index;
			}
		}

		private static bool TryGetChildComponent<TComponent>(Transform root, string childName, out TComponent component) where TComponent : UnityEngine.Component
		{
			Transform transform = root.FindChildRecursive(childName);
			if (transform != null && transform.gameObject.activeSelf && transform.TryGetComponent<TComponent>(out component))
			{
				return true;
			}
			component = null;
			return false;
		}

		public void InjectAllDropDownShowSelectedItem(Toggle[] toggles, ToggleGroup toggleGroup)
		{
			InjectToggles(toggles);
			InjectToggleGroup(toggleGroup);
		}

		public void InjectToggles(Toggle[] toggles)
		{
			_toggles = toggles;
		}

		public void InjectToggleGroup(ToggleGroup toggleGroup)
		{
			_toggleGroup = toggleGroup;
		}
	}
	public class CanvasConstantWidthScaler : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _rect;

		private float _initialLocalScaleY;

		private float _initialWidth;

		private float _initialHeight;

		private void Start()
		{
			_initialLocalScaleY = base.transform.localScale.y;
			_initialWidth = _rect.sizeDelta.x;
			_initialHeight = _rect.sizeDelta.y;
		}

		private void Update()
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x, _initialLocalScaleY * base.transform.parent.lossyScale.x / base.transform.parent.lossyScale.y, base.transform.localScale.z);
			_rect.sizeDelta = new Vector2(_initialWidth, _initialHeight * base.transform.localScale.x / base.transform.localScale.y);
		}
	}
	public class CarouselView : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _viewport;

		[SerializeField]
		private RectTransform _content;

		[SerializeField]
		private AnimationCurve _easeCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		[SerializeField]
		[Optional]
		private GameObject _emptyCarouselVisuals;

		private int _currentChildIndex;

		private float _scrollVal;

		public int CurrentChildIndex => _currentChildIndex;

		public RectTransform ContentArea => _content;

		protected virtual void Start()
		{
		}

		public void ScrollRight()
		{
			if (_content.childCount > 1)
			{
				if (_currentChildIndex > 0)
				{
					RectTransform currentChild = GetCurrentChild();
					_content.GetChild(0).SetAsLastSibling();
					LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
					ScrollToChild(currentChild, 1f);
				}
				else
				{
					_currentChildIndex++;
				}
				_scrollVal = Time.time;
			}
		}

		public void ScrollLeft()
		{
			if (_content.childCount > 1)
			{
				if (_currentChildIndex < _content.childCount - 1)
				{
					RectTransform currentChild = GetCurrentChild();
					_content.GetChild(_content.childCount - 1).SetAsFirstSibling();
					LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
					ScrollToChild(currentChild, 1f);
				}
				else
				{
					_currentChildIndex--;
				}
				_scrollVal = Time.time;
			}
		}

		private RectTransform GetCurrentChild()
		{
			return _content.GetChild(_currentChildIndex) as RectTransform;
		}

		private void ScrollToChild(RectTransform child, float amount01)
		{
			if (!(child == null))
			{
				amount01 = Mathf.Clamp01(amount01);
				Vector3 vector = _viewport.TransformPoint(_viewport.rect.center);
				Vector3 vector2 = child.TransformPoint(child.rect.center) - vector;
				if (vector2.sqrMagnitude > float.Epsilon)
				{
					Vector3 b = _content.position - vector2;
					float t = Mathf.Clamp01(_easeCurve.Evaluate(amount01));
					_content.position = Vector3.Lerp(_content.position, b, t);
				}
			}
		}

		protected virtual void Update()
		{
			_currentChildIndex = Mathf.Clamp(_currentChildIndex, 0, _content.childCount - 1);
			bool flag = _content.childCount > 0;
			if (flag)
			{
				RectTransform currentChild = GetCurrentChild();
				ScrollToChild(currentChild, Time.time - _scrollVal);
			}
			if (_emptyCarouselVisuals != null)
			{
				_emptyCarouselVisuals.SetActive(!flag);
			}
		}
	}
	public class ColorChanger : MonoBehaviour
	{
		[SerializeField]
		private Renderer _target;

		private Material _targetMaterial;

		private Color _savedColor;

		private float _lastHue;

		public void NextColor()
		{
			_lastHue = (_lastHue + 0.3f) % 1f;
			Color color = Color.HSVToRGB(_lastHue, 0.8f, 0.8f);
			_targetMaterial.color = color;
		}

		public void Save()
		{
			_savedColor = _targetMaterial.color;
		}

		public void Revert()
		{
			_targetMaterial.color = _savedColor;
		}

		protected virtual void Start()
		{
			_targetMaterial = _target.material;
			_savedColor = _targetMaterial.color;
		}

		private void OnDestroy()
		{
			UnityEngine.Object.Destroy(_targetMaterial);
		}
	}
	public class AnimatorOverrideLayerWeigth : MonoBehaviour
	{
		[SerializeField]
		[FormerlySerializedAs("animator")]
		private Animator _animator;

		[SerializeField]
		[FormerlySerializedAs("overrideLayer")]
		private string _overrideLayer = "Selected Layer";

		[SerializeField]
		[FormerlySerializedAs("transitionDuration")]
		public float _transitionDuration = 0.2f;

		[SerializeField]
		[FormerlySerializedAs("transitionCurve")]
		public AnimationCurve _transitionCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		[Space]
		[SerializeField]
		[Optional(OptionalAttribute.Flag.DontHide)]
		[Tooltip("If provided, the animation layer will be syncronized with the isOn state of the toggle")]
		public Toggle _toggle;

		private bool _layerIsActive;

		private int _layerIndex = -1;

		protected bool _started;

		public float TransitionDuration
		{
			get
			{
				return _transitionDuration;
			}
			set
			{
				_transitionDuration = value;
			}
		}

		public AnimationCurve TransitionCurve
		{
			get
			{
				return _transitionCurve;
			}
			set
			{
				_transitionCurve = value;
			}
		}

		protected virtual void Reset()
		{
			_animator = GetComponent<Animator>();
			_toggle = GetComponent<Toggle>();
		}

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			_layerIndex = _animator.GetLayerIndex(_overrideLayer);
			this.EndStart(ref _started);
		}

		protected virtual void OnEnable()
		{
			if (_started)
			{
				if (_layerIsActive)
				{
					_animator.SetLayerWeight(_layerIndex, 1f);
				}
				if (_toggle != null)
				{
					_toggle.onValueChanged.AddListener(SetOverrideLayerActive);
					SetOverrideLayerActive(_toggle.isOn);
				}
			}
		}

		protected virtual void OnDisable()
		{
			if (_started && _toggle != null)
			{
				_toggle.onValueChanged.RemoveListener(SetOverrideLayerActive);
			}
		}

		public void SetOverrideLayerActive(bool active)
		{
			_layerIsActive = active;
			if ((double)_transitionDuration > 0.0)
			{
				StopAllCoroutines();
				StartCoroutine(LayerTransition(_layerIndex, active ? 1f : 0f));
			}
			else
			{
				_animator.SetLayerWeight(_layerIndex, active ? 1f : 0f);
			}
		}

		private IEnumerator LayerTransition(int layerIndex, float targetWeight)
		{
			float startTime = Time.time;
			float startWeight = _animator.GetLayerWeight(layerIndex);
			while (true)
			{
				float num = (Time.time - startTime) / _transitionDuration;
				float t = _transitionCurve.Evaluate(Mathf.Clamp01(num));
				float weight = Mathf.Lerp(startWeight, targetWeight, t);
				_animator.SetLayerWeight(layerIndex, weight);
				if ((double)num >= 1.0)
				{
					break;
				}
				yield return null;
			}
		}

		public void InjectAllAnimatorOverrideLayerWeigth(Animator animator, string overrideLayer)
		{
			InjectAnimator(animator);
			InjectOverrideLayer(overrideLayer);
		}

		public void InjectAnimator(Animator animator)
		{
			_animator = animator;
		}

		public void InjectOverrideLayer(string overrideLayer)
		{
			_overrideLayer = overrideLayer;
		}

		public void InjectOptionalToggle(Toggle toggle)
		{
			_toggle = toggle;
		}
	}
	public class CountdownTimer : MonoBehaviour
	{
		[SerializeField]
		[Min(0f)]
		private float _countdownTime = 1f;

		[SerializeField]
		private bool _countdownOn;

		[SerializeField]
		private UnityEvent _callback;

		[SerializeField]
		private UnityEvent<float> _progressCallback;

		private float _countdownTimer;

		public bool CountdownOn
		{
			get
			{
				return _countdownOn;
			}
			set
			{
				if (value && !_countdownOn)
				{
					_countdownTimer = _countdownTime;
				}
				_countdownOn = value;
			}
		}

		private void Awake()
		{
		}

		private void Update()
		{
			if (!_countdownOn || _countdownTimer < 0f)
			{
				_progressCallback.Invoke(0f);
				return;
			}
			_countdownTimer -= Time.deltaTime;
			if (_countdownTimer < 0f)
			{
				_countdownTimer = -1f;
				_callback.Invoke();
				_progressCallback.Invoke(1f);
			}
			else
			{
				_progressCallback.Invoke(1f - _countdownTimer / _countdownTime);
			}
		}
	}
	public class EnableTargetOnStart : MonoBehaviour
	{
		public MonoBehaviour[] _components;

		public GameObject[] _gameObjects;

		private void Start()
		{
			if (_components != null)
			{
				MonoBehaviour[] components = _components;
				for (int i = 0; i < components.Length; i++)
				{
					components[i].enabled = true;
				}
			}
			if (_gameObjects != null)
			{
				GameObject[] gameObjects = _gameObjects;
				for (int i = 0; i < gameObjects.Length; i++)
				{
					gameObjects[i].SetActive(value: true);
				}
			}
		}
	}
	public class FadeTextAfterActive : MonoBehaviour
	{
		[SerializeField]
		private float _fadeOutTime;

		[SerializeField]
		private TextMeshPro _text;

		private float _timeLeft;

		protected virtual void OnEnable()
		{
			_timeLeft = _fadeOutTime;
			_text.fontMaterial.color = new Color(_text.color.r, _text.color.g, _text.color.b, 255f);
		}

		protected virtual void Update()
		{
			if (!(_timeLeft <= 0f))
			{
				float t = 1f - _timeLeft / _fadeOutTime;
				float a = Mathf.SmoothStep(1f, 0f, t);
				_text.color = new Color(_text.color.r, _text.color.g, _text.color.b, a);
				_timeLeft -= Time.deltaTime;
			}
		}
	}
	public class HideHandVisualOnGrab : MonoBehaviour
	{
		[SerializeField]
		private HandGrabInteractor _handGrabInteractor;

		[SerializeField]
		[Interface(typeof(IHandVisual), new Type[] { })]
		private UnityEngine.Object _handVisual;

		private IHandVisual HandVisual;

		protected virtual void Awake()
		{
			HandVisual = _handVisual as IHandVisual;
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
			GameObject gameObject = null;
			if (_handGrabInteractor.State == InteractorState.Select)
			{
				gameObject = _handGrabInteractor.SelectedInteractable?.gameObject;
			}
			if ((bool)gameObject)
			{
				if (gameObject.TryGetComponent<ShouldHideHandOnGrab>(out var _))
				{
					HandVisual.ForceOffVisibility = true;
				}
			}
			else
			{
				HandVisual.ForceOffVisibility = false;
			}
		}

		public void InjectAll(HandGrabInteractor handGrabInteractor, IHandVisual handVisual)
		{
			InjectHandGrabInteractor(handGrabInteractor);
			InjectHandVisual(handVisual);
		}

		private void InjectHandGrabInteractor(HandGrabInteractor handGrabInteractor)
		{
			_handGrabInteractor = handGrabInteractor;
		}

		private void InjectHandVisual(IHandVisual handVisual)
		{
			_handVisual = handVisual as UnityEngine.Object;
			HandVisual = handVisual;
		}
	}
	public class InteractableObjectLabel : MonoBehaviour
	{
		private enum LabelState
		{
			Hidden,
			FocusCheck,
			Focused,
			HideCheck,
			Used
		}

		[Tooltip("The positions of these transforms are used to check if the user is facing the object")]
		public List<Transform> viewTargets;

		[Tooltip("The possible positions for the label, the component always selected the one that has the highest y position component")]
		public List<Transform> labelPositions;

		[Tooltip("The position between the left and right cameras")]
		[Optional(OptionalAttribute.Flag.AutoGenerated)]
		public Transform playerHead;

		[Tooltip("This group should contain all the interactions in the object, and when one is triggered the label is hidden")]
		public InteractableGroupView interactableGroup;

		private Vector3 _startScale;

		[Space(10f)]
		[Tooltip("Canvas group at the root of the label canvas, used to make the canvas completely transparent")]
		public CanvasGroup group;

		public float alphaAnimationSpeed;

		public float focusDelay;

		public float hideDelay;

		public float alignmentThreshold;

		public float minScale;

		public float positionAnimationSpeed;

		[Space(10f)]
		public Mesh quadMesh;

		public Material quadMaterial;

		public RectTransform canvasTransform;

		public CanvasRenderTexture canvasTexture;

		private LabelState _currentState;

		private float _targetAlpha;

		private float _currentAlpha;

		private float _startTime;

		private MaterialPropertyBlock _block;

		private Transform _quadTransform;

		private MeshRenderer _quadRenderer;

		private Vector3 currentLabelPosition;

		protected bool _started;

		private void Start()
		{
			_targetAlpha = 0f;
			this.BeginStart(ref _started);
			if (playerHead == null)
			{
				playerHead = Camera.main.transform;
			}
			CreateTextureQuad();
			_startScale = _quadTransform.localScale;
			_block = new MaterialPropertyBlock();
			this.EndStart(ref _started);
		}

		private void CreateTextureQuad()
		{
			GameObject gameObject = new GameObject();
			gameObject.name = "CanvasTexture";
			_quadTransform = gameObject.transform;
			_quadTransform.parent = base.transform;
			_quadTransform.localScale = new Vector3
			{
				x = canvasTransform.sizeDelta.x * canvasTransform.localScale.x,
				y = canvasTransform.sizeDelta.y * canvasTransform.localScale.y,
				z = 1f
			};
			gameObject.AddComponent<MeshFilter>().sharedMesh = quadMesh;
			_quadRenderer = gameObject.AddComponent<MeshRenderer>();
			_quadRenderer.sharedMaterial = quadMaterial;
		}

		private void OnEnable()
		{
			interactableGroup.WhenStateChanged += InteractableStateChange;
		}

		private void OnDisable()
		{
			interactableGroup.WhenStateChanged -= InteractableStateChange;
		}

		private void SetTargetAlpha()
		{
			switch (_currentState)
			{
			case LabelState.Hidden:
				_targetAlpha = 0f;
				break;
			case LabelState.FocusCheck:
				_targetAlpha = 0f;
				break;
			case LabelState.Focused:
				_targetAlpha = 1f;
				break;
			case LabelState.HideCheck:
				_targetAlpha = 1f;
				break;
			case LabelState.Used:
				_targetAlpha = 0f;
				break;
			}
		}

		private float MaximizedDotView()
		{
			if (viewTargets == null)
			{
				return 0f;
			}
			float num = -1f;
			foreach (Transform viewTarget in viewTargets)
			{
				Vector3 rhs = Vector3.Normalize(viewTarget.position - playerHead.position);
				float b = Vector3.Dot(playerHead.forward, rhs);
				num = Mathf.Max(num, b);
			}
			return num;
		}

		private void StateTransition()
		{
			float num = MaximizedDotView();
			switch (_currentState)
			{
			case LabelState.Hidden:
				if (num >= alignmentThreshold)
				{
					_currentState = LabelState.FocusCheck;
					_startTime = Time.time;
				}
				break;
			case LabelState.FocusCheck:
				if (num < alignmentThreshold)
				{
					_currentState = LabelState.Hidden;
				}
				else if (Time.time - _startTime >= focusDelay)
				{
					_currentState = LabelState.Focused;
				}
				break;
			case LabelState.Focused:
				if (num <= alignmentThreshold)
				{
					_currentState = LabelState.HideCheck;
					_startTime = Time.time;
				}
				break;
			case LabelState.HideCheck:
				if (num > alignmentThreshold)
				{
					_currentState = LabelState.Focused;
				}
				else if (Time.time - _startTime >= hideDelay)
				{
					_currentState = LabelState.Hidden;
				}
				break;
			}
		}

		private void InteractableStateChange(InteractableStateChangeArgs args)
		{
			switch (args.NewState)
			{
			case InteractableState.Select:
				_currentState = LabelState.Used;
				break;
			case InteractableState.Normal:
				if (_currentState == LabelState.Used)
				{
					_currentState = LabelState.Hidden;
				}
				break;
			}
		}

		private Vector3 FindHighestLabelPosition()
		{
			if (labelPositions == null)
			{
				return base.transform.position;
			}
			int num = -1;
			float num2 = base.transform.position.y;
			for (int i = 0; i < labelPositions.Count; i++)
			{
				float y = labelPositions[i].position.y;
				if (y > num2)
				{
					num = i;
					num2 = y;
				}
			}
			if (num == -1)
			{
				return base.transform.position;
			}
			return labelPositions[num].position;
		}

		private void UpdateLabelTransform()
		{
			_startScale = new Vector3
			{
				x = canvasTransform.sizeDelta.x * canvasTransform.localScale.x,
				y = canvasTransform.sizeDelta.y * canvasTransform.localScale.y,
				z = 1f
			};
			Vector3 b = FindHighestLabelPosition();
			currentLabelPosition = Vector3.Lerp(currentLabelPosition, b, positionAnimationSpeed);
			float b2 = Vector3.Distance(currentLabelPosition, playerHead.position);
			float num = Mathf.Max(minScale, b2);
			_quadTransform.localScale = _startScale * num;
			float num2 = _quadTransform.localScale.y * 0.5f;
			_quadTransform.position = currentLabelPosition + _quadTransform.up * num2;
			_quadTransform.LookAt(playerHead.position);
			_quadTransform.localRotation *= Quaternion.Euler(0f, 180f, 0f);
		}

		private void Update()
		{
			UpdateLabelTransform();
			SetTargetAlpha();
			StateTransition();
			_currentAlpha = Mathf.Lerp(_currentAlpha, _targetAlpha, alphaAnimationSpeed);
			group.alpha = Mathf.Clamp01(_currentAlpha);
			_block.SetTexture("_MainTex", canvasTexture.Texture);
			_quadRenderer.SetPropertyBlock(_block);
		}
	}
	public class LocomotionTutorialAnimationUnityEventWrapper : MonoBehaviour
	{
		public UnityEvent WhenEnableTeleportRay;

		public UnityEvent WhenDisableTeleportRay;

		public UnityEvent WhenEnableTurningRing;

		public UnityEvent WhenDisableTurningRing;

		public void EnableTeleportRay()
		{
			WhenEnableTeleportRay.Invoke();
		}

		public void DisableTeleportRay()
		{
			WhenDisableTeleportRay.Invoke();
		}

		public void EnableTurningRing()
		{
			WhenEnableTurningRing.Invoke();
		}

		public void DisableTurningRing()
		{
			WhenDisableTurningRing.Invoke();
		}
	}
	public class LocomotionTutorialProgressTracker : MonoBehaviour
	{
		[SerializeField]
		private Image[] _dots;

		[SerializeField]
		private Sprite _pendingSprite;

		[SerializeField]
		private Sprite _currentSprite;

		[SerializeField]
		private Sprite _completedSprite;

		[SerializeField]
		private List<LocomotionEvent.TranslationType> _consumeTranslationEvents = new List<LocomotionEvent.TranslationType>();

		[SerializeField]
		private List<LocomotionEvent.RotationType> _consumeRotationEvents = new List<LocomotionEvent.RotationType>();

		[SerializeField]
		[Interface(typeof(ILocomotionEventHandler), new Type[] { })]
		private UnityEngine.Object _locomotionHandler;

		private ILocomotionEventHandler LocomotionHandler;

		public UnityEvent WhenCompleted;

		protected bool _started;

		private int _currentProgress;

		private int _totalProgress;

		protected virtual void Awake()
		{
			LocomotionHandler = _locomotionHandler as ILocomotionEventHandler;
		}

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			_totalProgress = _dots.Length;
			this.EndStart(ref _started);
		}

		protected virtual void OnEnable()
		{
			if (_started)
			{
				LocomotionHandler.WhenLocomotionEventHandled += LocomotionEventHandled;
				ResetProgress();
			}
		}

		protected virtual void OnDisable()
		{
			if (_started)
			{
				LocomotionHandler.WhenLocomotionEventHandled -= LocomotionEventHandled;
			}
		}

		private void LocomotionEventHandled(LocomotionEvent arg1, Pose arg2)
		{
			if (_consumeRotationEvents.Contains(arg1.Rotation) || _consumeTranslationEvents.Contains(arg1.Translation))
			{
				Progress();
			}
		}

		private void Progress()
		{
			_currentProgress++;
			if (_currentProgress <= _totalProgress)
			{
				_dots[_currentProgress - 1].sprite = _completedSprite;
			}
			if (_currentProgress < _totalProgress)
			{
				_dots[_currentProgress].sprite = _currentSprite;
			}
			if (_currentProgress >= _totalProgress)
			{
				WhenCompleted.Invoke();
			}
		}

		private void ResetProgress()
		{
			_currentProgress = 0;
			for (int i = 0; i < _dots.Length; i++)
			{
				_dots[i].sprite = ((i == 0) ? _currentSprite : _pendingSprite);
			}
		}

		public void InjectAllLocomotionTutorialProgressTracker(Image[] dots, Sprite pendingSprite, Sprite currentSprite, Sprite completedSprite, List<LocomotionEvent.TranslationType> consumeTranslationEvents, List<LocomotionEvent.RotationType> consumeRotationEvents, ILocomotionEventHandler locomotionHandler)
		{
			InjectDots(dots);
			InjectPendingSprite(pendingSprite);
			InjectCurrentSprite(currentSprite);
			InjectCompletedSprite(completedSprite);
			InjectConsumeTranslationEvents(consumeTranslationEvents);
			InjectConsumeRotationEvents(consumeRotationEvents);
			InjectLocomotionHandler(locomotionHandler);
		}

		public void InjectDots(Image[] dots)
		{
			_dots = dots;
		}

		public void InjectPendingSprite(Sprite pendingSprite)
		{
			_pendingSprite = pendingSprite;
		}

		public void InjectCurrentSprite(Sprite currentSprite)
		{
			_currentSprite = currentSprite;
		}

		public void InjectCompletedSprite(Sprite completedSprite)
		{
			_completedSprite = completedSprite;
		}

		public void InjectConsumeTranslationEvents(List<LocomotionEvent.TranslationType> consumeTranslationEvents)
		{
			_consumeTranslationEvents = consumeTranslationEvents;
		}

		public void InjectConsumeRotationEvents(List<LocomotionEvent.RotationType> consumeRotationEvents)
		{
			_consumeRotationEvents = consumeRotationEvents;
		}

		public void InjectLocomotionHandler(ILocomotionEventHandler locomotionHandler)
		{
			_locomotionHandler = locomotionHandler as UnityEngine.Object;
			LocomotionHandler = locomotionHandler;
		}
	}
	public class LocomotionTutorialTurnVisual : MonoBehaviour
	{
		[SerializeField]
		[Range(-1f, 1f)]
		private float _value;

		[SerializeField]
		[Range(0f, 1f)]
		private float _progress;

		[Header("Visual renderers")]
		[SerializeField]
		private Renderer _leftArrow;

		[SerializeField]
		private Renderer _rightArrow;

		[SerializeField]
		private TubeRenderer _leftTrail;

		[SerializeField]
		private TubeRenderer _rightTrail;

		[SerializeField]
		private MaterialPropertyBlockEditor _leftMaterialBlock;

		[SerializeField]
		private MaterialPropertyBlockEditor _rightMaterialBlock;

		[Header("Visual parameters")]
		[SerializeField]
		private float _verticalOffset = 0.02f;

		[SerializeField]
		private float _radius = 0.07f;

		[SerializeField]
		private float _margin = 2f;

		[SerializeField]
		private float _trailLength = 15f;

		[SerializeField]
		private float _maxAngle = 45f;

		[SerializeField]
		private float _railGap = 0.005f;

		[SerializeField]
		private float _squeezeLength = 5f;

		[SerializeField]
		private Color _disabledColor = new Color(1f, 1f, 1f, 0.2f);

		[SerializeField]
		private Color _enabledColor = new Color(1f, 1f, 1f, 0.6f);

		[SerializeField]
		private Color _highligtedColor = new Color(1f, 1f, 1f, 1f);

		private const float _degreesPerSegment = 1f;

		private static readonly Quaternion _rotationCorrectionLeft = Quaternion.Euler(0f, -90f, 0f);

		private static readonly int _colorShaderPropertyID = Shader.PropertyToID("_Color");

		protected bool _started;

		public float VerticalOffset
		{
			get
			{
				return _verticalOffset;
			}
			set
			{
				_verticalOffset = value;
			}
		}

		public Color DisabledColor
		{
			get
			{
				return _disabledColor;
			}
			set
			{
				_disabledColor = value;
			}
		}

		public Color EnabledColor
		{
			get
			{
				return _enabledColor;
			}
			set
			{
				_enabledColor = value;
			}
		}

		public Color HighligtedColor
		{
			get
			{
				return _highligtedColor;
			}
			set
			{
				_highligtedColor = value;
			}
		}

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			InitializeVisuals();
			this.EndStart(ref _started);
		}

		protected virtual void OnEnable()
		{
			_leftTrail.enabled = true;
			_rightTrail.enabled = true;
			_leftArrow.enabled = true;
			_rightArrow.enabled = true;
		}

		protected virtual void OnDisable()
		{
			_leftTrail.enabled = false;
			_rightTrail.enabled = false;
			_leftArrow.enabled = false;
			_rightArrow.enabled = false;
		}

		protected virtual void Update()
		{
			UpdateArrows();
			UpdateColors();
		}

		private void InitializeVisuals()
		{
			TubePoint[] points = InitializeSegment(new Vector2(_margin, _maxAngle + _squeezeLength));
			_leftTrail.RenderTube(points);
			_rightTrail.RenderTube(points);
		}

		private void UpdateArrows()
		{
			float value = _value;
			float a = Mathf.Lerp(0f, _maxAngle, Mathf.Abs(value));
			bool flag = value < 0f;
			bool flag2 = value > 0f;
			bool flag3 = false;
			float num = Mathf.Lerp(0f, _squeezeLength, _progress);
			a = Mathf.Max(a, _trailLength);
			UpdateArrowPosition(flag2 ? (a + num) : _trailLength, _rightArrow.transform);
			RotateTrail((flag3 && flag2) ? (a - _trailLength) : 0f, _rightTrail);
			UpdateTrail(flag2 ? ((flag3 ? _trailLength : a) + num) : _trailLength, _rightTrail);
			UpdateArrowPosition(flag ? (0f - a - num) : (0f - _trailLength), _leftArrow.transform);
			RotateTrail((flag3 && flag) ? (0f - a + _trailLength) : 0f, _leftTrail);
			UpdateTrail(flag ? ((flag3 ? _trailLength : a) + num) : _trailLength, _leftTrail);
		}

		private void UpdateArrowPosition(float angle, Transform arrow)
		{
			Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.up);
			arrow.localPosition = quaternion * Vector3.forward * _radius;
			arrow.localRotation = quaternion * _rotationCorrectionLeft;
		}

		private void RotateTrail(float angle, TubeRenderer trail)
		{
			trail.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
		}

		private void UpdateTrail(float angle, TubeRenderer trail)
		{
			float num = _maxAngle + _squeezeLength;
			float totalLength = trail.TotalLength;
			float num2 = -100f;
			float num3 = (num - angle - _margin) / num;
			trail.StartFadeThresold = totalLength * num2;
			trail.EndFadeThresold = totalLength * num3;
			trail.InvertThreshold = false;
			trail.RedrawFadeThresholds();
		}

		private void UpdateColors()
		{
			bool num = Mathf.Abs(_progress) >= 1f;
			bool flag = _value < 0f;
			bool flag2 = _value > 0f;
			Color color = (num ? _highligtedColor : _enabledColor);
			_leftMaterialBlock.MaterialPropertyBlock.SetColor(_colorShaderPropertyID, flag ? color : _disabledColor);
			_rightMaterialBlock.MaterialPropertyBlock.SetColor(_colorShaderPropertyID, flag2 ? color : _disabledColor);
			_leftMaterialBlock.UpdateMaterialPropertyBlock();
			_rightMaterialBlock.UpdateMaterialPropertyBlock();
		}

		private TubePoint[] InitializeSegment(Vector2 minMax)
		{
			float x = minMax.x;
			int num = Mathf.RoundToInt(Mathf.Repeat(minMax.y - x, 360f) / 1f);
			TubePoint[] array = new TubePoint[num];
			float num2 = 1f / (float)num;
			for (int i = 0; i < num; i++)
			{
				Quaternion quaternion = Quaternion.AngleAxis((float)(-i) * 1f - x, Vector3.up);
				array[i] = new TubePoint
				{
					position = quaternion * Vector3.forward * _radius,
					rotation = quaternion * _rotationCorrectionLeft,
					relativeLength = (float)i * num2
				};
			}
			return array;
		}
	}
	public class LookAtTarget : MonoBehaviour
	{
		[SerializeField]
		private Transform _toRotate;

		[SerializeField]
		private Transform _target;

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
			Vector3 normalized = (_target.position - _toRotate.position).normalized;
			_toRotate.LookAt(_toRotate.position - normalized, Vector3.up);
		}
	}
	public class SlingshotPellet : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _rigidbody;

		[SerializeField]
		private Grabbable grabbable;

		[SerializeField]
		private HandGrabInteractable[] _handGrabInteractables;

		private HandGrabInteractor _lastHandGrabInteractor;

		private UniqueIdentifier Identifier;

		private bool _hasPendingForce;

		private Vector3 _linearVelocity;

		public HandGrabInteractor HandGrabber => _lastHandGrabInteractor;

		private void Awake()
		{
			Identifier = UniqueIdentifier.Generate(Context.Global.GetInstance(), this);
		}

		private void OnEnable()
		{
			HandGrabInteractable[] handGrabInteractables = _handGrabInteractables;
			for (int i = 0; i < handGrabInteractables.Length; i++)
			{
				handGrabInteractables[i].WhenSelectingInteractorAdded.Action += HandleSelectingHandGrabInteractorAdded;
			}
		}

		private void OnDisable()
		{
			HandGrabInteractable[] handGrabInteractables = _handGrabInteractables;
			for (int i = 0; i < handGrabInteractables.Length; i++)
			{
				handGrabInteractables[i].WhenSelectingInteractorAdded.Action -= HandleSelectingHandGrabInteractorAdded;
			}
		}

		private void HandleSelectingHandGrabInteractorAdded(HandGrabInteractor interactor)
		{
			_lastHandGrabInteractor = interactor;
		}

		public void Attach()
		{
			Pose pose = base.transform.GetPose();
			grabbable.ProcessPointerEvent(new PointerEvent(Identifier.ID, PointerEventType.Hover, pose));
			grabbable.ProcessPointerEvent(new PointerEvent(Identifier.ID, PointerEventType.Select, pose));
			grabbable.ProcessPointerEvent(new PointerEvent(Identifier.ID, PointerEventType.Move, pose));
		}

		public void Move(Transform transform)
		{
			grabbable.ProcessPointerEvent(new PointerEvent(Identifier.ID, PointerEventType.Move, transform.GetPose()));
		}

		public void Eject(Vector3 force)
		{
			grabbable.ProcessPointerEvent(new PointerEvent(Identifier.ID, PointerEventType.Cancel, base.transform.GetPose()));
			_linearVelocity = force;
			_hasPendingForce = true;
		}

		private void FixedUpdate()
		{
			if (_hasPendingForce)
			{
				_hasPendingForce = false;
				_rigidbody.AddForce(_linearVelocity, ForceMode.VelocityChange);
				_rigidbody.AddTorque(Vector3.zero, ForceMode.VelocityChange);
			}
		}
	}
	public class AnchoredWorldSpaceDistanceScaler : MonoBehaviour
	{
		public enum ScalingMode
		{
			TwoDimensional,
			ThreeDimensional
		}

		[SerializeField]
		private Transform _parentAnchor;

		[SerializeField]
		private Transform _localAnchor;

		[SerializeField]
		[Tooltip("Choose whether content should be scaled as two- or three-dimensional")]
		private ScalingMode _scalingMode;

		private Vector3 _parentAnchorOffset;

		private Vector3 _originalLocalScale;

		private Vector3 _originalParentLocalScale;

		private Vector3 _originalCombinedScale;

		private void Start()
		{
			_parentAnchorOffset = _parentAnchor.InverseTransformPoint(_localAnchor.position);
			_originalLocalScale = base.transform.localScale;
			_originalParentLocalScale = base.transform.parent.localScale;
			_originalCombinedScale = Vector3.Scale(_originalParentLocalScale, _originalLocalScale);
		}

		private void LateUpdate()
		{
			Vector3 position = _parentAnchor.TransformPoint(_parentAnchorOffset);
			Vector3 vector = base.transform.InverseTransformPoint(position);
			Vector3 localScale = base.transform.localScale;
			localScale.Scale(new Vector3((Mathf.Abs(_localAnchor.localPosition.x) < Mathf.Epsilon) ? 1f : (vector.x / _localAnchor.localPosition.x), (Mathf.Abs(_localAnchor.localPosition.y) < Mathf.Epsilon) ? 1f : (vector.y / _localAnchor.localPosition.y), (Mathf.Abs(_localAnchor.localPosition.z) < Mathf.Epsilon) ? 1f : (vector.z / _localAnchor.localPosition.z)));
			if (_scalingMode == ScalingMode.ThreeDimensional)
			{
				Vector3 vector2 = Vector3.Scale(base.transform.parent.localScale, localScale);
				if (vector2.x / vector2.y > _originalCombinedScale.x / _originalCombinedScale.y)
				{
					float num = vector2.y / _originalCombinedScale.y;
					localScale.x = _originalCombinedScale.x * num / base.transform.parent.localScale.x;
					localScale.z = _originalCombinedScale.z * num / base.transform.parent.localScale.z;
				}
				else
				{
					float num2 = vector2.x / _originalCombinedScale.x;
					localScale.y = _originalCombinedScale.y * num2 / base.transform.parent.localScale.y;
					localScale.z = _originalCombinedScale.z * num2 / base.transform.parent.localScale.z;
				}
			}
			else
			{
				localScale.z = _originalParentLocalScale.z * _originalLocalScale.z / base.transform.parent.localScale.z;
			}
			base.transform.localScale = localScale;
		}
	}
	public class ArcAffordanceController : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The animator controlling the curvature of the affordance")]
		private Animator _animator;

		[SerializeField]
		[Tooltip("The transform from which world-space distance will be calculated; intuitively, 'the center of the arc's circle'")]
		private Transform _pivot;

		[SerializeField]
		[Tooltip("The function converting distance (from the pivot, a world-space observation) into curvature (an animation parameter)")]
		private AnimationCurve _distanceToCurvatureCurve;

		[SerializeField]
		[Tooltip("The renderer for the arc affordance, on which transparency values must be set.")]
		private SkinnedMeshRenderer _renderer;

		[SerializeField]
		[Tooltip("The bone at the 'top' end of the arc's armature")]
		private Transform _topBone;

		[SerializeField]
		[Tooltip("The bone at the 'bottom' end of the arc's armature")]
		private Transform _bottomBone;

		private Vector4[] _endPositions;

		private void Start()
		{
			_endPositions = new Vector4[2];
			_endPositions[0].w = 1f;
			_endPositions[1].w = 1f;
		}

		private void Update()
		{
			_animator.SetFloat("curvature", _distanceToCurvatureCurve.Evaluate(Vector3.Distance(base.transform.position, _pivot.position)));
			_endPositions[0].x = _topBone.position.x;
			_endPositions[0].y = _topBone.position.y;
			_endPositions[0].z = _topBone.position.z;
			_endPositions[1].x = _bottomBone.position.x;
			_endPositions[1].y = _bottomBone.position.y;
			_endPositions[1].z = _bottomBone.position.z;
			_renderer.material.SetVectorArray("_WorldSpaceFadePoints", _endPositions);
		}
	}
	public class ManipulatorAffordanceController : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The grab interactable for the slate itself (as opposed to the surrounding affordances)")]
		private GrabInteractable _grabInteractable;

		[SerializeField]
		[Tooltip("The hand grab interactable for the slate itself (as opposed to the surrounding affordances)")]
		private HandGrabInteractable _handGrabInteractable;

		[SerializeField]
		[Optional]
		[Tooltip("The ray interactable for the slate itself (as opposed to the surrounding affordances)")]
		private RayInteractable _rayInteractable;

		[SerializeField]
		[Tooltip("The state signaler for the SlateWithManipulators prefab")]
		private PanelWithManipulatorsStateSignaler _stateSignaler;

		[SerializeField]
		[Tooltip("The animators (canonically geometry and opacity) whose 'state' variables should be controlled by this affordance")]
		private Animator[] _animators;

		[SerializeField]
		[Optional]
		[Tooltip("Holds the panel hover state")]
		private PanelHoverState _panelHoverState;

		private void Start()
		{
			int animatorState = GetAnimatorState();
			Animator[] animators = _animators;
			for (int i = 0; i < animators.Length; i++)
			{
				animators[i].SetInteger("state", animatorState);
			}
			_grabInteractable.WhenStateChanged += HandleInteractableStateChanged;
			_handGrabInteractable.WhenStateChanged += HandleInteractableStateChanged;
			if (_rayInteractable != null)
			{
				_rayInteractable.WhenStateChanged += HandleInteractableStateChanged;
			}
			_stateSignaler.WhenStateChanged += HandleStateChanged;
			if (_panelHoverState != null)
			{
				_panelHoverState.WhenStateChanged += PanelHoverStateChanged;
			}
		}

		private void OnDestroy()
		{
			_grabInteractable.WhenStateChanged -= HandleInteractableStateChanged;
			_handGrabInteractable.WhenStateChanged -= HandleInteractableStateChanged;
			if (_rayInteractable != null)
			{
				_rayInteractable.WhenStateChanged -= HandleInteractableStateChanged;
			}
			_stateSignaler.WhenStateChanged -= HandleStateChanged;
			if (_panelHoverState != null)
			{
				_panelHoverState.WhenStateChanged -= PanelHoverStateChanged;
			}
		}

		private int GetAnimatorStateFromInteractable(IInteractableView view)
		{
			int result = 0;
			switch (view.State)
			{
			case InteractableState.Normal:
				result = 1;
				break;
			case InteractableState.Hover:
				result = 2;
				break;
			case InteractableState.Select:
				result = 3;
				break;
			}
			return result;
		}

		private int GetAnimatorState()
		{
			int result = 0;
			if ((object)_panelHoverState != null && !_panelHoverState.Hovered)
			{
				return result;
			}
			int num = ((_rayInteractable != null) ? GetAnimatorStateFromInteractable(_rayInteractable) : 0);
			return Mathf.Max(GetAnimatorStateFromInteractable(_grabInteractable), GetAnimatorStateFromInteractable(_handGrabInteractable), num);
		}

		private void HandleInteractableStateChanged(InteractableStateChangeArgs args)
		{
			if (args.NewState == InteractableState.Select)
			{
				_stateSignaler.CurrentState = PanelWithManipulatorsStateSignaler.State.Selected;
			}
			else if (args.PreviousState == InteractableState.Select)
			{
				_stateSignaler.CurrentState = PanelWithManipulatorsStateSignaler.State.Default;
			}
			int animatorState = GetAnimatorState();
			Animator[] animators = _animators;
			for (int i = 0; i < animators.Length; i++)
			{
				animators[i].SetInteger("state", animatorState);
			}
		}

		private void PanelHoverStateChanged(bool newState)
		{
			int animatorState = GetAnimatorState();
			Animator[] animators = _animators;
			for (int i = 0; i < animators.Length; i++)
			{
				animators[i].SetInteger("state", animatorState);
			}
		}

		private void HandleStateChanged(PanelWithManipulatorsStateSignaler.State state)
		{
			if (state != PanelWithManipulatorsStateSignaler.State.Default)
			{
				bool flag = !(_rayInteractable != null) || _rayInteractable.State != InteractableState.Select;
				if (_grabInteractable.State != InteractableState.Select && _handGrabInteractable.State != InteractableState.Select && flag)
				{
					_grabInteractable.enabled = false;
					_handGrabInteractable.enabled = false;
					if (_rayInteractable != null)
					{
						_rayInteractable.enabled = false;
					}
				}
			}
			else
			{
				_grabInteractable.enabled = true;
				_handGrabInteractable.enabled = true;
				if (_rayInteractable != null)
				{
					_rayInteractable.enabled = true;
				}
			}
		}
	}
	public class OneGrabScaleTransformer : MonoBehaviour, ITransformer
	{
		[Serializable]
		public class OneGrabScaleConstraints
		{
			public bool IgnoreFixedAxes;

			public bool ConstrainXYAspectRatio;

			public FloatConstraint MinX;

			public FloatConstraint MaxX;

			public FloatConstraint MinY;

			public FloatConstraint MaxY;

			public FloatConstraint MinZ;

			public FloatConstraint MaxZ;
		}

		[SerializeField]
		[Tooltip("Constraints for allowable values on different axes")]
		private OneGrabScaleConstraints _constraints = new OneGrabScaleConstraints
		{
			IgnoreFixedAxes = false,
			ConstrainXYAspectRatio = false,
			MinX = new FloatConstraint(),
			MaxX = new FloatConstraint(),
			MinY = new FloatConstraint(),
			MaxY = new FloatConstraint(),
			MinZ = new FloatConstraint(),
			MaxZ = new FloatConstraint()
		};

		private Vector3 _initialLocalScale;

		private Vector3 _initialLocalPosition;

		private IGrabbable _grabbable;

		public OneGrabScaleConstraints Constraints
		{
			get
			{
				return _constraints;
			}
			set
			{
				_constraints = value;
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
			_initialLocalPosition = transform.InverseTransformPointUnscaled(pose.position);
			_initialLocalScale = transform.localScale;
		}

		public void UpdateTransform()
		{
			Pose pose = _grabbable.GrabPoints[0];
			Transform transform = _grabbable.Transform;
			Vector3 vector = transform.InverseTransformPointUnscaled(pose.position);
			float num = _initialLocalScale.x * vector.x / _initialLocalPosition.x;
			float num2 = _initialLocalScale.y * vector.y / _initialLocalPosition.y;
			float num3 = _initialLocalScale.z * vector.z / _initialLocalPosition.z;
			if (_constraints.MinX.Constrain)
			{
				num = Mathf.Max(_constraints.MinX.Value, num);
			}
			if (_constraints.MinY.Constrain)
			{
				num2 = Mathf.Max(_constraints.MinY.Value, num2);
			}
			if (_constraints.MinZ.Constrain)
			{
				num3 = Mathf.Max(_constraints.MinZ.Value, num3);
			}
			if (_constraints.MaxX.Constrain)
			{
				num = Mathf.Min(_constraints.MaxX.Value, num);
			}
			if (_constraints.MaxY.Constrain)
			{
				num2 = Mathf.Min(_constraints.MaxY.Value, num2);
			}
			if (_constraints.MaxZ.Constrain)
			{
				num3 = Mathf.Min(_constraints.MaxZ.Value, num3);
			}
			if (_constraints.IgnoreFixedAxes)
			{
				if (_constraints.MinX.Constrain && _constraints.MaxX.Constrain && _constraints.MinX.Value == _constraints.MaxX.Value)
				{
					num = transform.localScale.x;
				}
				if (_constraints.MinY.Constrain && _constraints.MaxY.Constrain && _constraints.MinY.Value == _constraints.MaxY.Value)
				{
					num2 = transform.localScale.y;
				}
				if (_constraints.MinZ.Constrain && _constraints.MaxZ.Constrain && _constraints.MinZ.Value == _constraints.MaxZ.Value)
				{
					num3 = transform.localScale.z;
				}
			}
			if (_constraints.ConstrainXYAspectRatio)
			{
				if (num / num2 < _initialLocalScale.x / _initialLocalScale.y)
				{
					num2 = num * _initialLocalScale.y / _initialLocalScale.x;
				}
				else
				{
					num = num2 * _initialLocalScale.x / _initialLocalScale.y;
				}
			}
			transform.localScale = new Vector3(num, num2, num3);
		}

		public void EndTransform()
		{
		}
	}
	public class OpacityFromAnimatedTransformController : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The renderer to which the opacity should be applied")]
		private Renderer _renderer;

		[SerializeField]
		[Tooltip("The animation-controlled transform whose X magnitude will be applied to the renderer as `_Opacity`")]
		private Transform _opacityTransform;

		private MaterialPropertyBlock _materialProperties;

		private bool _isSkinnedMeshRenderer;

		private void Start()
		{
			_isSkinnedMeshRenderer = _renderer is SkinnedMeshRenderer;
			if (!_isSkinnedMeshRenderer)
			{
				_materialProperties = new MaterialPropertyBlock();
			}
		}

		private void Update()
		{
			float value = Mathf.Abs(_opacityTransform.localPosition.x);
			if (_isSkinnedMeshRenderer)
			{
				_renderer.material.SetFloat("_Opacity", value);
				return;
			}
			_materialProperties.SetFloat("_Opacity", value);
			_renderer.SetPropertyBlock(_materialProperties);
		}
	}
	public class PanelWithManipulatorsBorderAffordanceController : MonoBehaviour
	{
		private enum RailState
		{
			Hidden,
			Hover,
			Selected
		}

		private enum AffordanceState
		{
			Hidden,
			Visible
		}

		[Serializable]
		private class Affordance
		{
			[SerializeField]
			[Tooltip("The parent transform of the geometry (i.e., visuals) which should be moved to place the capsule affordance")]
			private Transform _geometry;

			[SerializeField]
			[Tooltip("Then transform controlled by an animation whose X axis magnitude will be used to control the affordance's opacity")]
			private Transform _opacityTransform;

			[SerializeField]
			[Tooltip("The animators (canonically geometry and opacity) whose 'state' variables should be controlled by this affordance")]
			private Animator[] _animators;

			private AffordanceState _animationState;

			private Vector3 _lastKnownPositionParentSpace;

			public AffordanceState AnimationState
			{
				get
				{
					return _animationState;
				}
				set
				{
					if (value != _animationState)
					{
						_animationState = value;
						Animator[] animators = _animators;
						for (int i = 0; i < animators.Length; i++)
						{
							animators[i].SetInteger("state", (int)_animationState);
						}
					}
				}
			}

			public Vector3 LastKnownPositionParentSpace
			{
				get
				{
					return _lastKnownPositionParentSpace;
				}
				set
				{
					_lastKnownPositionParentSpace = value;
				}
			}

			public Transform Geometry => _geometry;

			public float Opacity => Mathf.Abs(_opacityTransform.localPosition.x);
		}

		private class FadePoint
		{
			public int affordanceIndex;

			public bool removeFlag;

			public FadePoint(int index)
			{
				affordanceIndex = index;
				removeFlag = false;
			}
		}

		[Header("Interactables")]
		[SerializeField]
		[Tooltip("The grab interactable for the slate itself (as opposed to the surrounding affordances)")]
		private GrabInteractable _grabInteractable;

		[SerializeField]
		[Tooltip("The hand grab interactable for the slate itself (as opposed to the surrounding affordances)")]
		private HandGrabInteractable _handGrabInteractable;

		[SerializeField]
		[Optional]
		[Tooltip("The hand grab interactable for the slate itself (as opposed to the surrounding affordances)")]
		private RayInteractable _rayInteractable;

		[Header("Panel Signals")]
		[SerializeField]
		[Tooltip("The state signaler for the SlateWithManipulators prefab")]
		private PanelWithManipulatorsStateSignaler _stateSignaler;

		[SerializeField]
		[Optional]
		[Tooltip("Holds the panel hover state")]
		private PanelHoverState _panelHoverState;

		[SerializeField]
		[Tooltip("The grabbable associated with the slate itself (i.e., the grabbable with One- and TwoGrabFreeTransformers")]
		private Grabbable _grabbale;

		[Space(10f)]
		[SerializeField]
		[Tooltip("The transform of one of the bones of the rail affordance (used in calculating capsule placement)")]
		private Transform _boneTransform;

		[SerializeField]
		[Tooltip("The radius of the arcs at the corners of the rail affordance (used in calculating capsule placement)")]
		private float _cornerArcRadius;

		[Space(10f)]
		[SerializeField]
		[Tooltip("The animator controlling the overall opacity of the rail affordance (note that this is independent of the localized opacities associated with the capsule affordances)")]
		private Animator _railOpacityAnimator;

		[SerializeField]
		[Tooltip("The transform being controlled by the rail opacity animator")]
		private Transform _railOpacityTransform;

		[SerializeField]
		[Tooltip("The capsule affordances")]
		private Affordance[] _affordances;

		[SerializeField]
		[Tooltip("The renderer controlling shading for the rail affordance")]
		private SkinnedMeshRenderer _railRenderer;

		private Vector4[] _fadePoints;

		private MaterialPropertyBlock _materialPropertyBlock;

		private Dictionary<int, FadePoint> _points;

		private HashSet<int> _affordancesInUse;

		private List<int> _deletePointKeys;

		private static Vector3? _projectToRoundedBoxEdge(Vector3 worldSpacePoint, Transform targetTransform, Transform boneTransform, float arcRadius)
		{
			Vector3 vector = targetTransform.InverseTransformPointUnscaled(worldSpacePoint);
			vector.z = 0f;
			Vector3 vector2 = targetTransform.InverseTransformPointUnscaled(boneTransform.position);
			float num = Mathf.Sign(vector.x) * Mathf.Min(Mathf.Abs(vector2.x), Mathf.Abs(vector.x));
			float num2 = Mathf.Sign(vector.y) * Mathf.Min(Mathf.Abs(vector2.y), Mathf.Abs(vector.y));
			bool num3 = Mathf.Abs(Mathf.Abs(num) - Mathf.Abs(vector2.x)) < Mathf.Epsilon;
			bool flag = Mathf.Abs(Mathf.Abs(num2) - Mathf.Abs(vector2.y)) < Mathf.Epsilon;
			if (num3 || flag)
			{
				Vector3 vector3 = new Vector3(num, num2, 0f);
				Vector3 normalized = (vector - vector3).normalized;
				return targetTransform.TransformPointUnscaled(vector3 + normalized * arcRadius);
			}
			return null;
		}

		private void Start()
		{
			_materialPropertyBlock = new MaterialPropertyBlock();
			_fadePoints = new Vector4[4]
			{
				Vector4.zero,
				Vector4.zero,
				Vector4.zero,
				Vector4.zero
			};
			_points = new Dictionary<int, FadePoint>();
			_affordancesInUse = new HashSet<int>();
			_deletePointKeys = new List<int>();
			_grabInteractable.WhenStateChanged += HandleInteractableStateChanged;
			_handGrabInteractable.WhenStateChanged += HandleInteractableStateChanged;
			if (_rayInteractable != null)
			{
				_rayInteractable.WhenStateChanged += HandleInteractableStateChanged;
			}
			_railOpacityAnimator.SetInteger("state", 0);
			_stateSignaler.WhenStateChanged += HandleStateChanged;
			_grabbale.WhenPointerEventRaised += HandlePointerEvent;
		}

		private void OnDestroy()
		{
			_grabInteractable.WhenStateChanged -= HandleInteractableStateChanged;
			_handGrabInteractable.WhenStateChanged -= HandleInteractableStateChanged;
			if (_rayInteractable != null)
			{
				_rayInteractable.WhenStateChanged -= HandleInteractableStateChanged;
			}
			_stateSignaler.WhenStateChanged -= HandleStateChanged;
			_grabbale.WhenPointerEventRaised -= HandlePointerEvent;
		}

		private void CreateFadePoint(int eventIdentifier)
		{
			int num = -1;
			for (int i = 0; i < _affordances.Length; i++)
			{
				if (!_affordancesInUse.Contains(i))
				{
					num = i;
					_affordancesInUse.Add(i);
					break;
				}
			}
			if (num >= 0)
			{
				_points.Add(eventIdentifier, new FadePoint(num));
			}
		}

		private void HandlePointerEvent(PointerEvent evt)
		{
			switch (evt.Type)
			{
			case PointerEventType.Hover:
			case PointerEventType.Unselect:
			case PointerEventType.Move:
			{
				Vector3? vector = _projectToRoundedBoxEdge(evt.Pose.position, _grabbale.Transform, _boneTransform, _cornerArcRadius);
				Vector3 position = evt.Pose.position;
				if (vector.HasValue)
				{
					position = vector.Value;
				}
				if (!_points.ContainsKey(evt.Identifier))
				{
					CreateFadePoint(evt.Identifier);
					break;
				}
				_points[evt.Identifier].removeFlag = false;
				_affordances[_points[evt.Identifier].affordanceIndex].LastKnownPositionParentSpace = _grabbale.Transform.InverseTransformPoint(position);
				break;
			}
			case PointerEventType.Unhover:
			case PointerEventType.Cancel:
				if (_points.ContainsKey(evt.Identifier))
				{
					_points[evt.Identifier].removeFlag = true;
				}
				break;
			case PointerEventType.Select:
				break;
			}
		}

		private void SetRailAnimatorState()
		{
			RailState railState = RailState.Hidden;
			railState = (((object)_panelHoverState == null) ? RailState.Hover : (_panelHoverState.Hovered ? RailState.Hover : RailState.Hidden));
			if (_grabbale.SelectingPoints.Count > 0)
			{
				railState = RailState.Selected;
			}
			bool flag = !(_rayInteractable != null) || _rayInteractable.State == InteractableState.Disabled;
			if (_grabInteractable.State == InteractableState.Disabled && _handGrabInteractable.State == InteractableState.Disabled && flag)
			{
				railState = RailState.Hidden;
			}
			_railOpacityAnimator.SetInteger("state", (int)railState);
		}

		private void UpdateFadePoints()
		{
			if (_points.Count <= 0)
			{
				return;
			}
			_deletePointKeys.Clear();
			foreach (KeyValuePair<int, FadePoint> point in _points)
			{
				FadePoint value = point.Value;
				Affordance affordance = _affordances[value.affordanceIndex];
				affordance.AnimationState = ((!value.removeFlag) ? AffordanceState.Visible : AffordanceState.Hidden);
				if (value.removeFlag && affordance.Opacity < 0.05f)
				{
					_deletePointKeys.Add(point.Key);
				}
			}
			foreach (int deletePointKey in _deletePointKeys)
			{
				_points.Remove(deletePointKey, out var value2);
				_affordancesInUse.Remove(value2.affordanceIndex);
			}
		}

		private void UpdateMaterialProperties()
		{
			_materialPropertyBlock.SetFloat("_OpacityMultiplier", _railOpacityTransform.localPosition.x);
			_materialPropertyBlock.SetFloat("_SelectedOpacityParam", _railOpacityTransform.localPosition.y);
			int num = 0;
			Affordance[] affordances = _affordances;
			foreach (Affordance affordance in affordances)
			{
				if (num >= _fadePoints.Length)
				{
					break;
				}
				Vector3 position = _grabbale.Transform.TransformPoint(affordance.LastKnownPositionParentSpace);
				affordance.Geometry.position = position;
				_fadePoints[num].x = position.x;
				_fadePoints[num].y = position.y;
				_fadePoints[num].z = position.z;
				_fadePoints[num].w = affordance.Opacity;
				num++;
			}
			_materialPropertyBlock.SetVectorArray("_WorldSpaceFadePoints", _fadePoints);
			_materialPropertyBlock.SetInteger("_UsedPointCount", num);
			_railRenderer.SetPropertyBlock(_materialPropertyBlock);
		}

		private void Update()
		{
			SetRailAnimatorState();
			UpdateFadePoints();
			UpdateMaterialProperties();
		}

		private void HandleInteractableStateChanged(InteractableStateChangeArgs args)
		{
			if (args.NewState == InteractableState.Select)
			{
				_stateSignaler.CurrentState = PanelWithManipulatorsStateSignaler.State.Selected;
			}
			else if (args.PreviousState == InteractableState.Select)
			{
				_stateSignaler.CurrentState = PanelWithManipulatorsStateSignaler.State.Default;
			}
		}

		private void HandleStateChanged(PanelWithManipulatorsStateSignaler.State state)
		{
			if (state != PanelWithManipulatorsStateSignaler.State.Default)
			{
				bool flag = !(_rayInteractable != null) || _rayInteractable.State != InteractableState.Select;
				if (_grabInteractable.State != InteractableState.Select && _handGrabInteractable.State != InteractableState.Select && flag)
				{
					_grabInteractable.enabled = false;
					_handGrabInteractable.enabled = false;
					if (_rayInteractable != null)
					{
						_rayInteractable.enabled = false;
					}
				}
			}
			else
			{
				_grabInteractable.enabled = true;
				_handGrabInteractable.enabled = true;
				if (_rayInteractable != null)
				{
					_rayInteractable.enabled = true;
				}
			}
		}
	}
	public class PanelWithManipulatorsStateSignaler : MonoBehaviour
	{
		public enum State
		{
			Default,
			Selected,
			Idle
		}

		private State _state;

		public State CurrentState
		{
			get
			{
				return _state;
			}
			set
			{
				if (value != _state)
				{
					_state = value;
					this.WhenStateChanged(_state);
				}
			}
		}

		public event Action<State> WhenStateChanged = delegate
		{
		};
	}
	public class ParentScaleInverter : MonoBehaviour
	{
		private Vector3 _initialLocalScale;

		private Vector3 _initialParentScale;

		private void Start()
		{
			_initialLocalScale = base.transform.localScale;
			_initialParentScale = base.transform.parent.localScale;
		}

		private void LateUpdate()
		{
			base.transform.localScale = new Vector3(_initialParentScale.x * _initialLocalScale.x / base.transform.parent.localScale.x, _initialParentScale.y * _initialLocalScale.y / base.transform.parent.localScale.y, _initialParentScale.z * _initialLocalScale.z / base.transform.parent.localScale.z);
		}
	}
	public class PoseUseSample : MonoBehaviour
	{
		[SerializeField]
		[Interface(typeof(IHmd), new Type[] { })]
		private UnityEngine.Object _hmd;

		[SerializeField]
		private ActiveStateSelector[] _poses;

		[SerializeField]
		private Material[] _onSelectIcons;

		[SerializeField]
		private GameObject _poseActiveVisualPrefab;

		private GameObject[] _poseActiveVisuals;

		private IHmd Hmd { get; set; }

		protected virtual void Awake()
		{
			Hmd = _hmd as IHmd;
		}

		protected virtual void Start()
		{
			_poseActiveVisuals = new GameObject[_poses.Length];
			for (int i = 0; i < _poses.Length; i++)
			{
				_poseActiveVisuals[i] = UnityEngine.Object.Instantiate(_poseActiveVisualPrefab);
				_poseActiveVisuals[i].GetComponentInChildren<TextMeshPro>().text = _poses[i].name;
				_poseActiveVisuals[i].GetComponentInChildren<ParticleSystemRenderer>().material = _onSelectIcons[i];
				_poseActiveVisuals[i].SetActive(value: false);
				int poseNumber = i;
				_poses[i].WhenSelected += delegate
				{
					ShowVisuals(poseNumber);
				};
				_poses[i].WhenUnselected += delegate
				{
					HideVisuals(poseNumber);
				};
			}
		}

		private void ShowVisuals(int poseNumber)
		{
			if (Hmd.TryGetRootPose(out var pose))
			{
				Vector3 position = pose.position + pose.forward;
				_poseActiveVisuals[poseNumber].transform.position = position;
				_poseActiveVisuals[poseNumber].transform.LookAt(2f * _poseActiveVisuals[poseNumber].transform.position - pose.position);
				HandRef[] components = _poses[poseNumber].GetComponents<HandRef>();
				Vector3 zero = Vector3.zero;
				HandRef[] array = components;
				foreach (HandRef obj in array)
				{
					obj.GetRootPose(out var pose2);
					Vector3 vector = ((obj.Handedness == Handedness.Left) ? pose2.right : (-pose2.right));
					zero += pose2.position + vector * 0.15f + Vector3.up * 0.02f;
				}
				_poseActiveVisuals[poseNumber].transform.position = zero / components.Length;
				_poseActiveVisuals[poseNumber].gameObject.SetActive(value: true);
			}
		}

		private void HideVisuals(int poseNumber)
		{
			_poseActiveVisuals[poseNumber].gameObject.SetActive(value: false);
		}
	}
	public class RespawnOnDrop : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Respawn will happen when the transform moves below this World Y position.")]
		private float _yThresholdForRespawn;

		[SerializeField]
		[Tooltip("UnityEvent triggered when a respawn occurs.")]
		private UnityEvent _whenRespawned = new UnityEvent();

		[SerializeField]
		[Tooltip("If the transform has an associated rigidbody, make it kinematic during this number of frames after a respawn, in order to avoid ghost collisions.")]
		private int _sleepFrames;

		private Vector3 _initialPosition;

		private Quaternion _initialRotation;

		private Vector3 _initialScale;

		private TwoGrabFreeTransformer[] _freeTransformers;

		private Rigidbody _rigidBody;

		private int _sleepCountDown;

		public UnityEvent WhenRespawned => _whenRespawned;

		protected virtual void OnEnable()
		{
			_initialPosition = base.transform.position;
			_initialRotation = base.transform.rotation;
			_initialScale = base.transform.localScale;
			_freeTransformers = GetComponents<TwoGrabFreeTransformer>();
			_rigidBody = GetComponent<Rigidbody>();
		}

		protected virtual void Update()
		{
			if (base.transform.position.y < _yThresholdForRespawn)
			{
				Respawn();
			}
		}

		protected virtual void FixedUpdate()
		{
			if (_sleepCountDown > 0 && --_sleepCountDown == 0)
			{
				_rigidBody.isKinematic = false;
			}
		}

		public void Respawn()
		{
			base.transform.position = _initialPosition;
			base.transform.rotation = _initialRotation;
			base.transform.localScale = _initialScale;
			if ((bool)_rigidBody)
			{
				_rigidBody.velocity = Vector3.zero;
				_rigidBody.angularVelocity = Vector3.zero;
				if (!_rigidBody.isKinematic && _sleepFrames > 0)
				{
					_sleepCountDown = _sleepFrames;
					_rigidBody.isKinematic = true;
				}
			}
			TwoGrabFreeTransformer[] freeTransformers = _freeTransformers;
			for (int i = 0; i < freeTransformers.Length; i++)
			{
				freeTransformers[i].MarkAsBaseScale();
			}
			_whenRespawned.Invoke();
		}
	}
	public class RotationAudioEvents : MonoBehaviour
	{
		private enum Direction
		{
			None,
			Opening,
			Closing
		}

		[SerializeField]
		[Interface(typeof(IInteractableView), new Type[] { })]
		private UnityEngine.Object _interactableView;

		[Tooltip("Transform to track rotation of. If not provided, transform of this component is used.")]
		[SerializeField]
		[Optional]
		private Transform _trackedTransform;

		[SerializeField]
		private Transform _relativeTo;

		[Tooltip("The angle delta at which the threshold crossed event will be fired.")]
		[SerializeField]
		private float _thresholdDeg = 20f;

		[Tooltip("Maximum rotation arc within which the crossed event will be triggered.")]
		[SerializeField]
		[Range(1f, 150f)]
		private float _maxRangeDeg = 150f;

		[SerializeField]
		private UnityEvent _whenRotationStarted = new UnityEvent();

		[SerializeField]
		private UnityEvent _whenRotationEnded = new UnityEvent();

		[SerializeField]
		private UnityEvent _whenRotatedOpen = new UnityEvent();

		[SerializeField]
		private UnityEvent _whenRotatedClosed = new UnityEvent();

		private IInteractableView InteractableView;

		private float _baseDelta;

		private bool _isRotating;

		private Direction _lastCrossedDirection;

		protected bool _started;

		public UnityEvent WhenRotationStarted => _whenRotationStarted;

		public UnityEvent WhenRotationEnded => _whenRotationEnded;

		public UnityEvent WhenRotatedOpen => _whenRotatedOpen;

		public UnityEvent WhenRotatedClosed => _whenRotatedClosed;

		private Transform TrackedTransform
		{
			get
			{
				if (!(_trackedTransform == null))
				{
					return _trackedTransform;
				}
				return base.transform;
			}
		}

		private void RotationStarted()
		{
			_baseDelta = GetTotalDelta();
			_lastCrossedDirection = Direction.None;
			_whenRotationStarted.Invoke();
		}

		private void RotationEnded()
		{
			_whenRotationEnded.Invoke();
		}

		private Quaternion GetCurrentRotation()
		{
			return Quaternion.Inverse(_relativeTo.rotation) * TrackedTransform.rotation;
		}

		private float GetTotalDelta()
		{
			return Quaternion.Angle(_relativeTo.rotation, GetCurrentRotation());
		}

		private void UpdateRotation()
		{
			float totalDelta = GetTotalDelta();
			if (totalDelta > _maxRangeDeg)
			{
				return;
			}
			if (Mathf.Abs(totalDelta - _baseDelta) > _thresholdDeg)
			{
				Direction direction = ((totalDelta - _baseDelta > 0f) ? Direction.Opening : Direction.Closing);
				if (direction != _lastCrossedDirection)
				{
					_lastCrossedDirection = direction;
					if (direction == Direction.Opening)
					{
						_whenRotatedOpen.Invoke();
					}
					else
					{
						_whenRotatedClosed.Invoke();
					}
				}
			}
			if (_lastCrossedDirection == Direction.Opening)
			{
				_baseDelta = Mathf.Max(_baseDelta, totalDelta);
			}
			else if (_lastCrossedDirection == Direction.Closing)
			{
				_baseDelta = Mathf.Min(_baseDelta, totalDelta);
			}
		}

		protected virtual void Awake()
		{
			InteractableView = _interactableView as IInteractableView;
		}

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			this.EndStart(ref _started);
		}

		protected virtual void Update()
		{
			bool isRotating = _isRotating;
			_isRotating = InteractableView.State == InteractableState.Select;
			if (!_isRotating)
			{
				if (isRotating)
				{
					RotationEnded();
				}
				return;
			}
			if (!isRotating)
			{
				RotationStarted();
			}
			UpdateRotation();
		}
	}
	[CreateAssetMenu(menuName = "Meta/Interaction/SDK/Scene Group")]
	public class SampleSceneGroup : ScriptableObject
	{
		public interface ISceneInfo
		{
			string DisplayName { get; }

			string SceneName { get; }

			string SceneGuid { get; }

			Sprite Thumbnail { get; }
		}

		[Serializable]
		private class SceneInfo : ISceneInfo
		{
			public string DisplayName;

			public string SceneName;

			public string SceneGuid;

			public Sprite Thumbnail;

			string ISceneInfo.DisplayName => DisplayName;

			string ISceneInfo.SceneName => SceneName;

			Sprite ISceneInfo.Thumbnail => Thumbnail;

			string ISceneInfo.SceneGuid => SceneGuid;
		}

		[Tooltip("Scenes in this group will be displayed under this header in the scene menu.")]
		[SerializeField]
		private string _groupName;

		[Tooltip("Only Enabled scene groups will be shown in the scene menu.")]
		[SerializeField]
		private bool _groupEnabled = true;

		[Tooltip("Scene groups will appear in the scene menu sorted in ascending order by this value.")]
		[SerializeField]
		private int _groupDisplayOrder;

		[SerializeField]
		[HideInInspector]
		private SceneInfo[] _sceneInfos;

		public string GroupName => _groupName;

		public bool GroupEnabled => _groupEnabled;

		public int GroupDisplayOrder => _groupDisplayOrder;

		public int SceneCount => _sceneInfos.Length;

		public IEnumerable<ISceneInfo> GetScenes()
		{
			SceneInfo[] sceneInfos = _sceneInfos;
			for (int i = 0; i < sceneInfos.Length; i++)
			{
				yield return sceneInfos[i];
			}
		}
	}
	public class SamplesInfoPanel : MonoBehaviour
	{
		public void HandleUrlButton(string url)
		{
			Application.OpenURL(url);
		}
	}
	public class ScaleAudioEvents : MonoBehaviour
	{
		private enum Direction
		{
			None,
			ScaleUp,
			ScaleDown
		}

		[SerializeField]
		[Interface(typeof(IInteractableView), new Type[] { })]
		private UnityEngine.Object _interactableView;

		[Tooltip("Transform to track scale of. If not provided, transform of this component is used.")]
		[SerializeField]
		[Optional]
		private Transform _trackedTransform;

		[Tooltip("The increase in scale magnitude that will fire the step event")]
		[SerializeField]
		private float _stepSize = 0.4f;

		[Tooltip("Events will not be fired more frequently than this many times per second")]
		[SerializeField]
		private int _maxEventFreq = 20;

		[SerializeField]
		private UnityEvent _whenScalingStarted = new UnityEvent();

		[SerializeField]
		private UnityEvent _whenScalingEnded = new UnityEvent();

		[SerializeField]
		private UnityEvent _whenScaledUp = new UnityEvent();

		[SerializeField]
		private UnityEvent _whenScaledDown = new UnityEvent();

		private IInteractableView InteractableView;

		private bool _isScaling;

		private Vector3 _lastStep;

		private float _lastEventTime;

		private Direction _direction;

		protected bool _started;

		public UnityEvent WhenScalingStarted => _whenScalingStarted;

		public UnityEvent WhenScalingEnded => _whenScalingEnded;

		public UnityEvent WhenScaledUp => _whenScaledUp;

		public UnityEvent WhenScaledDown => _whenScaledDown;

		private Transform TrackedTransform
		{
			get
			{
				if (!(_trackedTransform == null))
				{
					return _trackedTransform;
				}
				return base.transform;
			}
		}

		private void ScalingStarted()
		{
			_lastStep = TrackedTransform.localScale;
			_whenScalingStarted.Invoke();
		}

		private void ScalingEnded()
		{
			_whenScalingEnded.Invoke();
		}

		private float GetTotalDelta(out Direction direction)
		{
			float magnitude = _lastStep.magnitude;
			float magnitude2 = TrackedTransform.localScale.magnitude;
			if (magnitude2 == magnitude)
			{
				direction = Direction.None;
			}
			else
			{
				direction = ((magnitude2 > magnitude) ? Direction.ScaleUp : Direction.ScaleDown);
			}
			if (direction != Direction.ScaleUp)
			{
				return magnitude - magnitude2;
			}
			return magnitude2 - magnitude;
		}

		private void UpdateScaling()
		{
			if (_stepSize <= 0f || _maxEventFreq <= 0)
			{
				return;
			}
			float stepSize = _stepSize;
			if (!(GetTotalDelta(out _direction) > stepSize))
			{
				return;
			}
			_lastStep = TrackedTransform.localScale;
			if (Time.time - _lastEventTime >= 1f / (float)_maxEventFreq)
			{
				_lastEventTime = Time.time;
				if (_direction == Direction.ScaleUp)
				{
					_whenScaledUp.Invoke();
				}
				else
				{
					_whenScaledDown.Invoke();
				}
			}
		}

		protected virtual void Awake()
		{
			InteractableView = _interactableView as IInteractableView;
		}

		protected virtual void Start()
		{
			this.BeginStart(ref _started);
			this.EndStart(ref _started);
		}

		protected virtual void Update()
		{
			bool isScaling = _isScaling;
			_isScaling = InteractableView.State == InteractableState.Select;
			if (!_isScaling)
			{
				if (isScaling)
				{
					ScalingEnded();
				}
				return;
			}
			if (!isScaling)
			{
				ScalingStarted();
			}
			UpdateScaling();
		}
	}
	public class ScaleModifier : MonoBehaviour
	{
		public void SetScaleX(float x)
		{
			base.transform.localScale = new Vector3(x, base.transform.localScale.y, base.transform.localScale.z);
		}

		public void SetScaleY(float y)
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x, y, base.transform.localScale.z);
		}

		public void SetScaleZ(float z)
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.y, z);
		}
	}
	public class SceneGroupLoader : MonoBehaviour
	{
		private class SceneGroupView : MonoBehaviour
		{
			public TextMeshProUGUI GroupName;

			public RectTransform TileContainer;
		}

		private class SceneTileView : MonoBehaviour
		{
			public TextMeshProUGUI Label;

			public Image Image;

			public Toggle Toggle;

			public Image SceneMissingOverlay;
		}

		[SerializeField]
		private SceneLoader _sceneLoader;

		[SerializeField]
		private Transform _sceneGroupContainer;

		[SerializeField]
		private GameObject _missingSceneWarning;

		[Header("Group Template")]
		[SerializeField]
		private GameObject _groupTemplateParent;

		[SerializeField]
		private TextMeshProUGUI _groupTemplateLabel;

		[SerializeField]
		private RectTransform _groupTileContainer;

		[Header("Tile Template")]
		[SerializeField]
		private GameObject _tileTemplateParent;

		[SerializeField]
		private TextMeshProUGUI _tileTemplateLabel;

		[SerializeField]
		private Image _tileTemplateImage;

		[SerializeField]
		private Toggle _tileTemplateToggle;

		[SerializeField]
		private Image _tileTemplateSceneMissingOverlay;

		private void Start()
		{
			BuildSceneGroups();
		}

		private void BuildSceneGroups()
		{
			bool flag = false;
			foreach (SampleSceneGroup item in from g in FindSceneGroupAssets()
				where g.GroupEnabled
				where g.SceneCount > 0
				orderby g.GroupDisplayOrder
				select g)
			{
				InitializeGroupViewTemplate();
				GameObject obj = UnityEngine.Object.Instantiate(_groupTemplateParent, _sceneGroupContainer);
				obj.name = item.GroupName;
				obj.SetActive(value: true);
				SceneGroupView component = obj.GetComponent<SceneGroupView>();
				component.GroupName.text = item.GroupName;
				foreach (SampleSceneGroup.ISceneInfo sceneMenuItem in item.GetScenes())
				{
					InitializeTileViewTemplate();
					bool flag2 = CheckSceneExists(sceneMenuItem);
					flag = flag || !flag2;
					GameObject obj2 = UnityEngine.Object.Instantiate(_tileTemplateParent, component.TileContainer);
					obj2.name = sceneMenuItem.DisplayName;
					obj2.SetActive(value: true);
					SceneTileView component2 = obj2.GetComponent<SceneTileView>();
					component2.Label.text = sceneMenuItem.DisplayName;
					component2.Toggle.enabled = flag2;
					component2.Toggle.onValueChanged.AddListener(delegate
					{
						LoadScene(sceneMenuItem);
					});
					component2.Image.sprite = sceneMenuItem.Thumbnail;
					component2.Image.enabled = flag2;
					component2.SceneMissingOverlay.sprite = sceneMenuItem.Thumbnail;
					component2.SceneMissingOverlay.gameObject.SetActive(!flag2);
				}
			}
			_missingSceneWarning.SetActive(flag);
			void InitializeGroupViewTemplate()
			{
				if (!_groupTemplateParent.TryGetComponent<SceneGroupView>(out var component3))
				{
					component3 = _groupTemplateParent.AddComponent<SceneGroupView>();
					component3.GroupName = _groupTemplateLabel;
					component3.TileContainer = _groupTileContainer;
				}
			}
			void InitializeTileViewTemplate()
			{
				if (!_tileTemplateParent.TryGetComponent<SceneTileView>(out var component3))
				{
					component3 = _tileTemplateParent.AddComponent<SceneTileView>();
					component3.Image = _tileTemplateImage;
					component3.Label = _tileTemplateLabel;
					component3.Toggle = _tileTemplateToggle;
					component3.SceneMissingOverlay = _tileTemplateSceneMissingOverlay;
				}
			}
		}

		private void LoadScene(SampleSceneGroup.ISceneInfo sceneInfo)
		{
			_sceneLoader.Load(sceneInfo.SceneName);
		}

		private static bool CheckSceneExists(SampleSceneGroup.ISceneInfo sceneInfo)
		{
			return SceneUtility.GetBuildIndexByScenePath(sceneInfo.SceneName) >= 0;
		}

		private static IEnumerable<SampleSceneGroup> FindSceneGroupAssets()
		{
			return Resources.LoadAll<SampleSceneGroup>("");
		}
	}
	public class SceneLoader : MonoBehaviour
	{
		private bool _loading;

		public Action<string> WhenLoadingScene = delegate
		{
		};

		public Action<string> WhenSceneLoaded = delegate
		{
		};

		private int _waitingCount;

		public void Load(string sceneName)
		{
			if (!_loading)
			{
				_loading = true;
				_waitingCount = WhenLoadingScene.GetInvocationList().Length - 1;
				if (_waitingCount == 0)
				{
					HandleReadyToLoad(sceneName);
				}
				else
				{
					WhenLoadingScene(sceneName);
				}
			}
		}

		public void HandleReadyToLoad(string sceneName)
		{
			_waitingCount--;
			if (_waitingCount <= 0)
			{
				StartCoroutine(LoadSceneAsync(sceneName));
			}
		}

		private IEnumerator LoadSceneAsync(string sceneName)
		{
			UnityEngine.AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
			while (!asyncLoad.isDone)
			{
				yield return null;
			}
			WhenSceneLoaded(sceneName);
		}
	}
	public class ShouldHideHandOnGrab : MonoBehaviour
	{
	}
	public class ConstantRotation : MonoBehaviour
	{
		[SerializeField]
		private float _rotationSpeed;

		[SerializeField]
		private Vector3 _localAxis = Vector3.up;

		public float RotationSpeed
		{
			get
			{
				return _rotationSpeed;
			}
			set
			{
				_rotationSpeed = value;
			}
		}

		public Vector3 LocalAxis
		{
			get
			{
				return _localAxis;
			}
			set
			{
				_localAxis = value;
			}
		}

		protected virtual void Update()
		{
			base.transform.Rotate(_localAxis, _rotationSpeed * Time.deltaTime, Space.Self);
		}
	}
	public class ListSnapPoseDelegateRoundedBoxVisual : MonoBehaviour
	{
		[SerializeField]
		private ListSnapPoseDelegate _listSnapPoseDelegate;

		[SerializeField]
		private RoundedBoxProperties _properties;

		[SerializeField]
		private SnapInteractable _snapInteractable;

		[SerializeField]
		private float _minSize;

		[SerializeField]
		private ProgressCurve _curve;

		private float _targetWidth;

		private float _startWidth;

		protected virtual void LateUpdate()
		{
			float num = Mathf.Max(_listSnapPoseDelegate.Size, _minSize);
			if (num != _targetWidth)
			{
				_targetWidth = num;
				_curve.Start();
				_startWidth = _properties.Width;
			}
			_properties.Width = Mathf.Lerp(_startWidth, _targetWidth, _curve.Progress());
			_properties.BorderColor = ((_snapInteractable.Interactors.Count != _snapInteractable.SelectingInteractors.Count) ? new Color(1f, 1f, 1f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
	}
	public class StayInView : MonoBehaviour
	{
		[SerializeField]
		private Transform _eyeCenter;

		[SerializeField]
		private float _extraDistanceForward;

		[SerializeField]
		private bool _zeroOutEyeHeight = true;

		private void Update()
		{
			base.transform.rotation = Quaternion.identity;
			base.transform.position = _eyeCenter.position;
			base.transform.Rotate(0f, _eyeCenter.rotation.eulerAngles.y, 0f, Space.Self);
			base.transform.position = _eyeCenter.position + base.transform.forward.normalized * _extraDistanceForward;
			if (_zeroOutEyeHeight)
			{
				base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
			}
		}
	}
}
namespace Oculus.Interaction.Samples.PalmMenu
{
	public class DominantHandGameObjectFilter : MonoBehaviour, IGameObjectFilter
	{
		[SerializeField]
		[Interface(typeof(IHand), new Type[] { })]
		private UnityEngine.Object _leftHand;

		[SerializeField]
		private GameObject[] _leftHandedGameObjects;

		[SerializeField]
		private GameObject[] _rightHandedGameObjects;

		private readonly HashSet<GameObject> _leftHandedGameObjectSet = new HashSet<GameObject>();

		private readonly HashSet<GameObject> _rightHandedGameObjectSet = new HashSet<GameObject>();

		private IHand LeftHand { get; set; }

		protected virtual void Start()
		{
			GameObject[] leftHandedGameObjects = _leftHandedGameObjects;
			foreach (GameObject item in leftHandedGameObjects)
			{
				_leftHandedGameObjectSet.Add(item);
			}
			leftHandedGameObjects = _rightHandedGameObjects;
			foreach (GameObject item2 in leftHandedGameObjects)
			{
				_rightHandedGameObjectSet.Add(item2);
			}
			LeftHand = _leftHand as IHand;
		}

		public bool Filter(GameObject go)
		{
			if (LeftHand.IsDominantHand)
			{
				return _leftHandedGameObjectSet.Contains(go);
			}
			return _rightHandedGameObjectSet.Contains(go);
		}
	}
	[Obsolete("Use a combination of DominantHandRef and HandJoint instead")]
	public class MatchNonDominantPalmWorldSpaceTransform : MonoBehaviour
	{
		[SerializeField]
		[Interface(typeof(IHand), new Type[] { })]
		private UnityEngine.Object _leftHand;

		[SerializeField]
		[Interface(typeof(IHand), new Type[] { })]
		private UnityEngine.Object _rightHand;

		[SerializeField]
		private Vector3 _leftAnchorPoint = new Vector3(-0.060860332f, 0.0095398445f, 0.0002581277f);

		[SerializeField]
		private Vector3 _leftAimPoint = new Vector3(-0.07492584f, 0.08930927f, 0.0002581277f);

		[SerializeField]
		private Vector3 _rightAnchorPoint = new Vector3(0.065260336f, -0.011439844f, -0.004558128f);

		[SerializeField]
		private Vector3 _rightAimPoint = new Vector3(0.07932585f, -0.09120928f, -0.004558128f);

		private IHand LeftHand { get; set; }

		private IHand RightHand { get; set; }

		protected virtual void Awake()
		{
			LeftHand = _leftHand as IHand;
			RightHand = _rightHand as IHand;
		}

		private void Update()
		{
			Vector3 position = (LeftHand.IsDominantHand ? _rightAnchorPoint : _leftAnchorPoint);
			Vector3 position2 = (LeftHand.IsDominantHand ? _rightAimPoint : _leftAimPoint);
			if ((LeftHand.IsDominantHand ? RightHand : LeftHand).GetJointPose(HandJointId.HandWristRoot, out var pose))
			{
				Pose transformedBy = new Pose(position, Quaternion.identity).GetTransformedBy(pose);
				Pose transformedBy2 = new Pose(position2, Quaternion.identity).GetTransformedBy(pose);
				base.transform.SetPositionAndRotation(transformedBy.position, Quaternion.LookRotation((transformedBy2.position - transformedBy.position).normalized));
			}
		}
	}
	public class PalmMenuExample : MonoBehaviour
	{
		[SerializeField]
		private PokeInteractable _menuInteractable;

		[SerializeField]
		private GameObject _menuParent;

		[SerializeField]
		private RectTransform _menuPanel;

		[SerializeField]
		private RectTransform[] _buttons;

		[SerializeField]
		private RectTransform[] _paginationDots;

		[SerializeField]
		private RectTransform _selectionIndicatorDot;

		[SerializeField]
		private AnimationCurve _paginationButtonScaleCurve;

		[SerializeField]
		private float _defaultButtonDistance = 50f;

		[SerializeField]
		private AudioSource _paginationSwipeAudio;

		[SerializeField]
		private AudioSource _showMenuAudio;

		[SerializeField]
		private AudioSource _hideMenuAudio;

		private int _currentSelectedButtonIdx;

		private void Start()
		{
			_currentSelectedButtonIdx = CalculateNearestButtonIdx();
			_selectionIndicatorDot.position = _paginationDots[_currentSelectedButtonIdx].position;
		}

		private void Update()
		{
			int num = CalculateNearestButtonIdx();
			if (num != _currentSelectedButtonIdx)
			{
				_currentSelectedButtonIdx = num;
				_paginationSwipeAudio.Play();
				_selectionIndicatorDot.position = _paginationDots[_currentSelectedButtonIdx].position;
			}
			if (_menuInteractable.State != InteractableState.Select)
			{
				LerpToButton();
			}
		}

		private int CalculateNearestButtonIdx()
		{
			int result = 0;
			float num = float.PositiveInfinity;
			for (int i = 0; i < _buttons.Length; i++)
			{
				float num2 = _buttons[i].localPosition.x + _menuPanel.anchoredPosition.x;
				int num3 = ((num2 < 0f) ? (i + 1) : (i - 1));
				float num4 = Mathf.Abs(num2);
				if (num4 < num)
				{
					result = i;
					num = num4;
				}
				float num5 = _defaultButtonDistance;
				if (num3 >= 0 && num3 < _buttons.Length)
				{
					num5 = Mathf.Abs(_buttons[num3].localPosition.x - _buttons[i].localPosition.x);
				}
				float num6 = _paginationButtonScaleCurve.Evaluate(num4 / num5);
				_buttons[i].localScale = num6 * Vector3.one;
			}
			return result;
		}

		private void LerpToButton()
		{
			float num = _buttons[0].localPosition.x;
			float num2 = Mathf.Abs(num + _menuPanel.anchoredPosition.x);
			for (int i = 1; i < _buttons.Length; i++)
			{
				float x = _buttons[i].localPosition.x;
				float num3 = Mathf.Abs(x + _menuPanel.anchoredPosition.x);
				if (num3 < num2)
				{
					num = x;
					num2 = num3;
				}
			}
			_menuPanel.anchoredPosition = Vector2.Lerp(_menuPanel.anchoredPosition, new Vector2(0f - num, 0f), 0.2f);
		}

		public void ToggleMenu()
		{
			if (_menuParent.activeSelf)
			{
				_hideMenuAudio.Play();
				_menuParent.SetActive(value: false);
			}
			else
			{
				_showMenuAudio.Play();
				_menuParent.SetActive(value: true);
			}
		}
	}
	public class PalmMenuExampleButtonHandlers : MonoBehaviour
	{
		[SerializeField]
		private GameObject _controlledObject;

		[SerializeField]
		private Color[] _colors;

		[SerializeField]
		private GameObject _rotationEnabledIcon;

		[SerializeField]
		private GameObject _rotationDisabledIcon;

		[SerializeField]
		private float _rotationLerpSpeed = 1f;

		[SerializeField]
		private TMP_Text _rotationDirectionText;

		[SerializeField]
		private string[] _rotationDirectionNames;

		[SerializeField]
		private GameObject[] _rotationDirectionIcons;

		[SerializeField]
		private Quaternion[] _rotationDirections;

		[SerializeField]
		private TMP_Text _elevationText;

		[SerializeField]
		private float _elevationChangeIncrement;

		[SerializeField]
		private float _elevationChangeLerpSpeed = 1f;

		[SerializeField]
		private TMP_Text _shapeNameText;

		[SerializeField]
		private string[] _shapeNames;

		[SerializeField]
		private Mesh[] _shapes;

		private int _currentColorIdx;

		private bool _rotationEnabled;

		private int _currentRotationDirectionIdx;

		private Vector3 _targetPosition;

		private int _currentShapeIdx;

		private void Start()
		{
			_currentColorIdx = _colors.Length;
			CycleColor();
			_rotationEnabled = false;
			ToggleRotationEnabled();
			_currentRotationDirectionIdx = _rotationDirections.Length;
			CycleRotationDirection();
			_targetPosition = _controlledObject.transform.position;
			IncrementElevation(up: true);
			IncrementElevation(up: false);
			_currentShapeIdx = _shapes.Length;
			CycleShape(cycleForward: true);
		}

		private void Update()
		{
			if (_rotationEnabled)
			{
				Quaternion quaternion = Quaternion.Slerp(Quaternion.identity, _rotationDirections[_currentRotationDirectionIdx], _rotationLerpSpeed * Time.deltaTime);
				_controlledObject.transform.rotation = quaternion * _controlledObject.transform.rotation;
			}
			_controlledObject.transform.position = Vector3.Lerp(_controlledObject.transform.position, _targetPosition, _elevationChangeLerpSpeed * Time.deltaTime);
		}

		public void CycleColor()
		{
			_currentColorIdx++;
			if (_currentColorIdx >= _colors.Length)
			{
				_currentColorIdx = 0;
			}
			_controlledObject.GetComponent<Renderer>().material.color = _colors[_currentColorIdx];
		}

		public void ToggleRotationEnabled()
		{
			_rotationEnabled = !_rotationEnabled;
			_rotationEnabledIcon.SetActive(!_rotationEnabled);
			_rotationDisabledIcon.SetActive(_rotationEnabled);
		}

		public void CycleRotationDirection()
		{
			_currentRotationDirectionIdx++;
			if (_currentRotationDirectionIdx >= _rotationDirections.Length)
			{
				_currentRotationDirectionIdx = 0;
			}
			int num = _currentRotationDirectionIdx + 1;
			if (num >= _rotationDirections.Length)
			{
				num = 0;
			}
			_rotationDirectionText.text = _rotationDirectionNames[num];
			for (int i = 0; i < _rotationDirections.Length; i++)
			{
				_rotationDirectionIcons[i].SetActive(i == num);
			}
		}

		public void IncrementElevation(bool up)
		{
			float num = _elevationChangeIncrement;
			if (!up)
			{
				num *= -1f;
			}
			_targetPosition = new Vector3(_targetPosition.x, Mathf.Clamp(_targetPosition.y + num, 0.2f, 2f), _targetPosition.z);
			_elevationText.text = "Elevation: " + _targetPosition.y.ToString("0.0");
		}

		public void CycleShape(bool cycleForward)
		{
			_currentShapeIdx += (cycleForward ? 1 : (-1));
			if (_currentShapeIdx >= _shapes.Length)
			{
				_currentShapeIdx = 0;
			}
			else if (_currentShapeIdx < 0)
			{
				_currentShapeIdx = _shapes.Length - 1;
			}
			_shapeNameText.text = _shapeNames[_currentShapeIdx];
			_controlledObject.GetComponent<MeshFilter>().mesh = _shapes[_currentShapeIdx];
		}
	}
}
