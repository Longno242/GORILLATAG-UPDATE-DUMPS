#define UNITY_ASSERTIONS
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Unity.IntegerTime;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("Unity.InputSystem.ForUI")]
[assembly: InternalsVisibleTo("Unity.InputSystem.Tests")]
[assembly: InternalsVisibleTo("Unity.InputSystem.IntegrationTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsModule")]
[assembly: InternalsVisibleTo("Unity.XR.Interaction.Toolkit")]
[assembly: InternalsVisibleTo("Unity.XR.Interaction.Toolkit.Editor")]
[assembly: InternalsVisibleTo("Unity.XR.Interaction.Toolkit.Samples.StarterAssets")]
[assembly: InternalsVisibleTo("Unity.XR.Interaction.Toolkit.Samples.StarterAssets.Editor")]
[assembly: InternalsVisibleTo("Unity.XR.Interaction.Toolkit.Samples.UIToolkit")]
[assembly: InternalsVisibleTo("UnityEngine.InputForUITests")]
[assembly: InternalsVisibleTo("UnityEngine.InputForUIVisualizer")]
[assembly: InternalsVisibleTo("Unity.UIElements.Tests")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("Assembly-CSharp-Editor-testable")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct CommandEvent : IEventProperties
{
	public enum Type
	{
		Validate = 1,
		Execute
	}

	public enum Command
	{
		Invalid,
		Cut,
		Copy,
		Paste,
		SelectAll,
		DeselectAll,
		InvertSelection,
		Duplicate,
		Rename,
		Delete,
		SoftDelete,
		Find,
		SelectChildren,
		SelectPrefabRoot,
		UndoRedoPerformed,
		OnLostFocus,
		NewKeyboardFocus,
		ModifierKeysChanged,
		EyeDropperUpdate,
		EyeDropperClicked,
		EyeDropperCancelled,
		ColorPickerChanged,
		FrameSelected,
		FrameSelectedWithLock
	}

	public Type type;

	public Command command;

	public DiscreteTime timestamp { get; set; }

	public EventSource eventSource { get; set; }

	public uint playerId { get; set; }

	public EventModifiers eventModifiers { get; set; }

	public override string ToString()
	{
		return $"{type} {command}";
	}
}
[StructLayout(LayoutKind.Explicit)]
[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct Event : IEventProperties
{
	public enum Type
	{
		Invalid,
		KeyEvent,
		PointerEvent,
		TextInputEvent,
		IMECompositionEvent,
		CommandEvent,
		NavigationEvent
	}

	private interface IMapFn<TOutputType>
	{
		TOutputType Map<TEventType>(ref TEventType ev) where TEventType : IEventProperties;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct MapAsObject : IMapFn<IEventProperties>
	{
		public IEventProperties Map<TEventType>(ref TEventType ev) where TEventType : IEventProperties
		{
			return ev;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct MapAsTimestamp : IMapFn<DiscreteTime>
	{
		public DiscreteTime Map<TEventType>(ref TEventType ev) where TEventType : IEventProperties
		{
			return ev.timestamp;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct MapAsEventSource : IMapFn<EventSource>
	{
		public EventSource Map<TEventType>(ref TEventType ev) where TEventType : IEventProperties
		{
			return ev.eventSource;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct MapAsPlayerId : IMapFn<uint>
	{
		public uint Map<TEventType>(ref TEventType ev) where TEventType : IEventProperties
		{
			return ev.playerId;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct MapAsEventModifiers : IMapFn<EventModifiers>
	{
		public EventModifiers Map<TEventType>(ref TEventType ev) where TEventType : IEventProperties
		{
			return ev.eventModifiers;
		}
	}

	public static Type[] TypesWithState = new Type[3]
	{
		Type.KeyEvent,
		Type.PointerEvent,
		Type.IMECompositionEvent
	};

	private const int kManagedOffset = 8;

	private const int kUnmanagedOffset = 16;

	[FieldOffset(0)]
	private Type _type;

	[FieldOffset(8)]
	private object _managedEvent;

	[FieldOffset(16)]
	private KeyEvent _keyEvent;

	[FieldOffset(16)]
	private PointerEvent _pointerEvent;

	[FieldOffset(16)]
	private TextInputEvent _textInputEvent;

	[FieldOffset(16)]
	private CommandEvent _commandEvent;

	[FieldOffset(16)]
	private NavigationEvent _navigationEvent;

	public Type type => _type;

	private IEventProperties asObject => Map<IEventProperties, MapAsObject>();

	public DiscreteTime timestamp => Map<DiscreteTime, MapAsTimestamp>();

	public EventSource eventSource => Map<EventSource, MapAsEventSource>();

	public uint playerId => Map<uint, MapAsPlayerId>();

	public EventModifiers eventModifiers => Map<EventModifiers, MapAsEventModifiers>();

	public KeyEvent asKeyEvent
	{
		get
		{
			Ensure(Type.KeyEvent);
			return _keyEvent;
		}
	}

	public PointerEvent asPointerEvent
	{
		get
		{
			Ensure(Type.PointerEvent);
			return _pointerEvent;
		}
	}

	public TextInputEvent asTextInputEvent
	{
		get
		{
			Ensure(Type.TextInputEvent);
			return _textInputEvent;
		}
	}

	public IMECompositionEvent asIMECompositionEvent
	{
		get
		{
			Ensure(Type.IMECompositionEvent);
			return (IMECompositionEvent)_managedEvent;
		}
	}

	public CommandEvent asCommandEvent
	{
		get
		{
			Ensure(Type.CommandEvent);
			return _commandEvent;
		}
	}

	public NavigationEvent asNavigationEvent
	{
		get
		{
			Ensure(Type.NavigationEvent);
			return _navigationEvent;
		}
	}

	internal static int CompareType(Event a, Event b)
	{
		if (a.type == Type.PointerEvent && b.type == Type.PointerEvent)
		{
			int value = (int)a.eventSource;
			return ((int)b.eventSource).CompareTo(value);
		}
		int num = (int)a.type;
		int value2 = (int)b.type;
		return num.CompareTo(value2);
	}

	private void Ensure(Type t)
	{
		Debug.Assert(type == t);
	}

	public override string ToString()
	{
		string text = eventModifiers.ToString();
		if (!string.IsNullOrEmpty(text))
		{
			text = " ev:" + text;
		}
		return (type == Type.Invalid) ? "Invalid" : $"{asObject}{text} src:{eventSource.ToString()}";
	}

	public static Event From(KeyEvent keyEvent)
	{
		return new Event
		{
			_type = Type.KeyEvent,
			_keyEvent = keyEvent
		};
	}

	public static Event From(PointerEvent pointerEvent)
	{
		return new Event
		{
			_type = Type.PointerEvent,
			_pointerEvent = pointerEvent
		};
	}

	public static Event From(TextInputEvent textInputEvent)
	{
		return new Event
		{
			_type = Type.TextInputEvent,
			_textInputEvent = textInputEvent
		};
	}

	public static Event From(IMECompositionEvent imeCompositionEvent)
	{
		return new Event
		{
			_type = Type.IMECompositionEvent,
			_managedEvent = imeCompositionEvent
		};
	}

	public static Event From(CommandEvent commandEvent)
	{
		return new Event
		{
			_type = Type.CommandEvent,
			_commandEvent = commandEvent
		};
	}

	public static Event From(NavigationEvent navigationEvent)
	{
		return new Event
		{
			_type = Type.NavigationEvent,
			_navigationEvent = navigationEvent
		};
	}

	private TOutputType Map<TOutputType, TMapType>(TMapType fn) where TMapType : IMapFn<TOutputType>
	{
		switch (type)
		{
		case Type.Invalid:
			return default(TOutputType);
		case Type.KeyEvent:
		{
			ref KeyEvent keyEvent = ref _keyEvent;
			return fn.Map(ref keyEvent);
		}
		case Type.PointerEvent:
		{
			ref PointerEvent pointerEvent = ref _pointerEvent;
			return fn.Map(ref pointerEvent);
		}
		case Type.TextInputEvent:
		{
			ref TextInputEvent textInputEvent = ref _textInputEvent;
			return fn.Map(ref textInputEvent);
		}
		case Type.IMECompositionEvent:
		{
			IMECompositionEvent ev = (IMECompositionEvent)_managedEvent;
			return fn.Map(ref ev);
		}
		case Type.CommandEvent:
		{
			ref CommandEvent commandEvent = ref _commandEvent;
			return fn.Map(ref commandEvent);
		}
		case Type.NavigationEvent:
		{
			ref NavigationEvent navigationEvent = ref _navigationEvent;
			return fn.Map(ref navigationEvent);
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private TOutputType Map<TOutputType, TMapType>() where TMapType : IMapFn<TOutputType>, new()
	{
		return Map<TOutputType, TMapType>(new TMapType());
	}
}
[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct EventModifiers
{
	[Flags]
	public enum Modifiers : uint
	{
		LeftShift = 1u,
		RightShift = 2u,
		Shift = 3u,
		LeftCtrl = 4u,
		RightCtrl = 8u,
		Ctrl = 0xCu,
		LeftAlt = 0x10u,
		RightAlt = 0x20u,
		Alt = 0x30u,
		LeftMeta = 0x40u,
		RightMeta = 0x80u,
		Meta = 0xC0u,
		CapsLock = 0x100u,
		Numlock = 0x200u,
		FunctionKey = 0x400u,
		Numeric = 0x800u
	}

	private uint _state;

	public bool isShiftPressed => IsPressed(Modifiers.Shift);

	public bool isCtrlPressed => IsPressed(Modifiers.Ctrl);

	public bool isAltPressed => IsPressed(Modifiers.Alt);

	public bool isMetaPressed => IsPressed(Modifiers.Meta);

	public bool isCapsLockEnabled => IsPressed(Modifiers.CapsLock);

	public bool isNumLockEnabled => IsPressed(Modifiers.Numlock);

	public bool isFunctionKeyPressed => IsPressed(Modifiers.FunctionKey);

	public bool isNumericPressed => IsPressed(Modifiers.Numeric);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool IsPressed(Modifiers mod)
	{
		return (_state & (uint)mod) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetPressed(Modifiers modifier, bool pressed)
	{
		if (pressed)
		{
			_state |= (uint)modifier;
		}
		else
		{
			_state &= (uint)(~modifier);
		}
	}

	public void Reset()
	{
		_state = 0u;
	}

	private static void Append(ref string str, string value)
	{
		str = (string.IsNullOrEmpty(str) ? value : (str + "," + value));
	}

	public override string ToString()
	{
		string str = string.Empty;
		if (IsPressed(Modifiers.LeftShift))
		{
			Append(ref str, "LeftShift");
		}
		if (IsPressed(Modifiers.RightShift))
		{
			Append(ref str, "RightShift");
		}
		if (IsPressed(Modifiers.LeftCtrl))
		{
			Append(ref str, "LeftCtrl");
		}
		if (IsPressed(Modifiers.RightCtrl))
		{
			Append(ref str, "RightCtrl");
		}
		if (IsPressed(Modifiers.LeftAlt))
		{
			Append(ref str, "LeftAlt");
		}
		if (IsPressed(Modifiers.RightAlt))
		{
			Append(ref str, "RightAlt");
		}
		if (IsPressed(Modifiers.LeftMeta))
		{
			Append(ref str, "LeftMeta");
		}
		if (IsPressed(Modifiers.RightMeta))
		{
			Append(ref str, "RightMeta");
		}
		if (IsPressed(Modifiers.CapsLock))
		{
			Append(ref str, "CapsLock");
		}
		if (IsPressed(Modifiers.Numlock))
		{
			Append(ref str, "Numlock");
		}
		if (IsPressed(Modifiers.FunctionKey))
		{
			Append(ref str, "FunctionKey");
		}
		if (IsPressed(Modifiers.Numeric))
		{
			Append(ref str, "Numeric");
		}
		return str;
	}
}
[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal enum EventSource
{
	Unspecified,
	Keyboard,
	Gamepad,
	Mouse,
	Pen,
	Touch,
	TrackedDevice
}
internal interface IEventProperties
{
	DiscreteTime timestamp { get; }

	EventSource eventSource { get; }

	uint playerId { get; }

	EventModifiers eventModifiers { get; }
}
[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct IMECompositionEvent : IEventProperties
{
	public string compositionString;

	public DiscreteTime timestamp { get; set; }

	public EventSource eventSource { get; set; }

	public uint playerId { get; set; }

	public EventModifiers eventModifiers { get; set; }

	public override string ToString()
	{
		return "IME '" + compositionString + "'";
	}
}
[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct KeyEvent : IEventProperties
{
	public enum Type
	{
		KeyPressed = 1,
		KeyRepeated,
		KeyReleased,
		State
	}

	public struct ButtonsState
	{
		private const uint kMaxIndex = 319u;

		private const uint kSizeInBytes = 40u;

		private unsafe fixed byte buttons[40];

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool ShouldBeProcessed(KeyCode keyCode)
		{
			return (uint)keyCode <= 319u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe bool GetUnchecked(uint index)
		{
			return (buttons[index >> 3] & (byte)(1 << (int)(index & 7))) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void SetUnchecked(uint index)
		{
			ref byte reference = ref buttons[index >> 3];
			reference |= (byte)(1 << (int)(index & 7));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void ClearUnchecked(uint index)
		{
			ref byte reference = ref buttons[index >> 3];
			reference &= (byte)(~(1 << (int)(index & 7)));
		}

		public bool IsPressed(KeyCode keyCode)
		{
			return ShouldBeProcessed(keyCode) && GetUnchecked((uint)keyCode);
		}

		public IEnumerable<KeyCode> GetAllPressed()
		{
			uint index = 0u;
			while (index <= 319)
			{
				if (GetUnchecked(index))
				{
					yield return (KeyCode)index;
				}
				uint num = index + 1;
				index = num;
			}
		}

		public void SetPressed(KeyCode keyCode, bool pressed)
		{
			if (ShouldBeProcessed(keyCode))
			{
				if (pressed)
				{
					SetUnchecked((uint)keyCode);
				}
				else
				{
					ClearUnchecked((uint)keyCode);
				}
			}
		}

		public unsafe void Reset()
		{
			for (int i = 0; (long)i < 40L; i++)
			{
				buttons[i] = 0;
			}
		}

		public override string ToString()
		{
			return string.Join(",", GetAllPressed());
		}
	}

	public Type type;

	public KeyCode keyCode;

	public ButtonsState buttonsState;

	public DiscreteTime timestamp { get; set; }

	public EventSource eventSource { get; set; }

	public uint playerId { get; set; }

	public EventModifiers eventModifiers { get; set; }

	public override string ToString()
	{
		switch (type)
		{
		case Type.KeyPressed:
		case Type.KeyRepeated:
		case Type.KeyReleased:
			return $"{type} {keyCode}";
		case Type.State:
			return $"{type} Pressed:{buttonsState}";
		default:
			throw new ArgumentOutOfRangeException();
		}
	}
}
[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct NavigationEvent : IEventProperties
{
	public enum Type
	{
		Move = 1,
		Submit,
		Cancel
	}

	public enum Direction
	{
		None,
		Left,
		Up,
		Right,
		Down,
		Next,
		Previous
	}

	public Type type;

	public Direction direction;

	public bool shouldBeUsed;

	public DiscreteTime timestamp { get; set; }

	public EventSource eventSource { get; set; }

	public uint playerId { get; set; }

	public EventModifiers eventModifiers { get; set; }

	public override string ToString()
	{
		return $"Navigation {type}" + ((type == Type.Move) ? $" {direction}" : "") + ((eventSource != EventSource.Keyboard) ? $" {eventSource}" : "");
	}

	internal static Direction DetermineMoveDirection(Vector2 vec, float deadZone = 0.6f)
	{
		if (vec.sqrMagnitude < deadZone * deadZone)
		{
			return Direction.None;
		}
		if (Mathf.Abs(vec.x) > Mathf.Abs(vec.y))
		{
			return (!(vec.x > 0f)) ? Direction.Left : Direction.Right;
		}
		return (vec.y > 0f) ? Direction.Up : Direction.Down;
	}
}
[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct PointerEvent : IEventProperties
{
	public enum Type
	{
		PointerMoved = 1,
		Scroll = 2,
		ButtonPressed = 3,
		ButtonReleased = 4,
		State = 5,
		TouchCanceled = 6,
		TrackedCanceled = 6
	}

	[Flags]
	public enum Button : uint
	{
		None = 0u,
		Primary = 1u,
		FingerInTouch = 1u,
		PenTipInTouch = 1u,
		PenEraserInTouch = 2u,
		PenBarrelButton = 4u,
		MouseLeft = 1u,
		MouseRight = 2u,
		MouseMiddle = 4u,
		MouseForward = 8u,
		MouseBack = 0x10u
	}

	public struct ButtonsState
	{
		private uint _state;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(Button button, bool pressed)
		{
			if (pressed)
			{
				_state |= (uint)button;
			}
			else
			{
				_state &= (uint)(~button);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(Button button)
		{
			return (_state & (uint)button) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Reset()
		{
			_state = 0u;
		}

		public override string ToString()
		{
			return $"{_state:x2}";
		}
	}

	public Type type;

	public int pointerIndex;

	public Vector2 position;

	public Vector2 deltaPosition;

	public Vector3 worldPosition;

	public Quaternion worldOrientation;

	public float maxDistance;

	public Vector2 scroll;

	public int displayIndex;

	public Vector2 tilt;

	public float twist;

	public float pressure;

	public bool isInverted;

	public Button button;

	public ButtonsState buttonsState;

	public int clickCount;

	public bool isPrimaryPointer => pointerIndex == 0;

	public Ray worldRay => new Ray(worldPosition, worldOrientation * Vector3.forward);

	public float azimuth => InputManagerProvider.TiltToAzimuth(tilt);

	public float altitude => InputManagerProvider.TiltToAltitude(tilt);

	public bool isPressed => buttonsState.Get((!isInverted) ? Button.Primary : Button.PenEraserInTouch);

	public DiscreteTime timestamp { get; set; }

	public EventSource eventSource { get; set; }

	public uint playerId { get; set; }

	public EventModifiers eventModifiers { get; set; }

	public override string ToString()
	{
		string text = ((eventSource == EventSource.Pen) ? $" tilt:({tilt.x:f1},{tilt.y:f1}) az:{azimuth:f2} al:{altitude:f2} twist:{twist} pressure:{pressure} isInverted:{(isInverted ? 1 : 0)}" : "");
		string text2 = ((eventSource == EventSource.Touch) ? $" finger:{pointerIndex} tilt:({tilt.x:f1},{tilt.y:f1}) twist:{twist} pressure:{pressure}" : "");
		string text3 = $" dsp:{displayIndex}";
		string text4 = text + text2 + text3;
		switch (type)
		{
		case Type.PointerMoved:
			return $"{type} pos:{position} dlt:{deltaPosition} btns:{buttonsState}{text4}";
		case Type.Scroll:
			return $"{type} pos:{position} scr:{scroll}{text4}";
		case Type.ButtonPressed:
		case Type.ButtonReleased:
			return $"{type} pos:{position} btn:{button} btns:{buttonsState} clk:{clickCount}{text4}";
		case Type.State:
			return $"{type} pos:{position} btns:{buttonsState}{text4}";
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	internal static Button ButtonFromButtonIndex(int index)
	{
		return (index <= 31) ? ((Button)(1 << index)) : Button.None;
	}
}
[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal struct TextInputEvent : IEventProperties
{
	public char character;

	public DiscreteTime timestamp { get; set; }

	public EventSource eventSource { get; set; }

	public uint playerId { get; set; }

	public EventModifiers eventModifiers { get; set; }

	public override string ToString()
	{
		string arg = ((character == '\0') ? string.Empty : character.ToString());
		return $"text input 0x{(int)character:x8} '{arg}'";
	}

	public static bool ShouldBeProcessed(char character)
	{
		return character > '\u001f' && character != '\u007f';
	}
}
[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal static class EventProvider
{
	private struct Registration
	{
		public EventConsumer handler;

		public int priority;

		public int? playerId;

		public HashSet<Event.Type> _types;
	}

	private static IEventProviderImpl s_impl = new InputManagerProvider();

	private static EventSanitizer s_sanitizer;

	private static IEventProviderImpl s_implMockBackup = null;

	private static bool s_focusStateBeforeMock;

	private static bool s_focusChangedRegistered;

	private static bool m_IsEnabled = true;

	private static bool m_IsInitialized = false;

	private static List<Registration> _registrations = new List<Registration>();

	public static IEventProviderImpl provider => s_impl;

	public static uint playerCount => s_impl?.playerCount ?? 0;

	internal static string _providerClassName => s_impl?.GetType().Name;

	internal static RationalTime doubleClickTime
	{
		get
		{
			int num = UnityEngine.Event.GetDoubleClickTime();
			return new RationalTime(num, new RationalTime.TicksPerSecond(1000u));
		}
	}

	public static void Subscribe(EventConsumer handler, int priority = 0, int? playerId = null, params Event.Type[] type)
	{
		Bootstrap();
		_registrations.Add(new Registration
		{
			handler = handler,
			priority = priority,
			playerId = playerId,
			_types = new HashSet<Event.Type>(type)
		});
		_registrations.Sort((Registration a, Registration b) => a.priority.CompareTo(b.priority));
	}

	public static void Unsubscribe(EventConsumer handler)
	{
		_registrations.RemoveAll((Registration x) => x.handler == handler);
	}

	public static void SetEnabled(bool enable)
	{
		m_IsEnabled = enable;
		if (enable)
		{
			Initialize();
		}
		else
		{
			Shutdown();
		}
	}

	internal static void Dispatch(in Event ev)
	{
		if (_registrations.Count == 0)
		{
			return;
		}
		s_sanitizer.Inspect(in ev);
		foreach (Registration registration in _registrations)
		{
			if ((registration._types.Count <= 0 || registration._types.Contains(ev.type)) && registration.handler(in ev))
			{
				break;
			}
		}
	}

	public static void RequestCurrentState(params Event.Type[] types)
	{
		Event.Type[] array = ((types != null && types.Length > 0) ? types : Event.TypesWithState);
		foreach (Event.Type type in array)
		{
			if (s_impl?.RequestCurrentState(type) != true)
			{
				Debug.LogWarning($"Can't provide state for type {type}");
			}
		}
	}

	private static void Bootstrap()
	{
		if (m_IsEnabled)
		{
			Initialize();
		}
	}

	private static void Initialize()
	{
		if (!m_IsInitialized)
		{
			s_sanitizer.Reset();
			s_impl?.Initialize();
			if (!s_focusChangedRegistered)
			{
				Application.focusChanged += OnFocusChanged;
				s_focusChangedRegistered = true;
			}
			m_IsInitialized = true;
		}
	}

	private static void Shutdown()
	{
		if (m_IsInitialized)
		{
			m_IsInitialized = false;
			if (s_focusChangedRegistered)
			{
				s_focusChangedRegistered = false;
				Application.focusChanged -= OnFocusChanged;
			}
			s_impl?.Shutdown();
		}
	}

	private static void OnFocusChanged(bool focus)
	{
		s_impl?.OnFocusChanged(focus);
	}

	[RequiredByNativeCode]
	internal static void NotifyUpdate()
	{
		if (Application.isPlaying && _registrations.Count != 0 && m_IsInitialized)
		{
			s_sanitizer.BeforeProviderUpdate();
			s_impl?.Update();
			s_sanitizer.AfterProviderUpdate();
		}
	}

	internal static void SetInputSystemProvider(IEventProviderImpl impl)
	{
		bool isInitialized = m_IsInitialized;
		Shutdown();
		s_impl = impl;
		if (isInitialized)
		{
			Initialize();
		}
	}

	internal static void SetMockProvider(IEventProviderImpl impl)
	{
		if (s_implMockBackup == null)
		{
			s_implMockBackup = s_impl;
		}
		s_focusStateBeforeMock = Application.isFocused;
		Shutdown();
		s_impl = impl;
		Initialize();
	}

	internal static void ClearMockProvider()
	{
		Shutdown();
		s_impl = s_implMockBackup;
		s_implMockBackup = null;
		Initialize();
		if (s_focusStateBeforeMock != Application.isFocused)
		{
			s_impl?.OnFocusChanged(Application.isFocused);
		}
	}
}
[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
internal delegate bool EventConsumer(in Event ev);
internal interface IEventProviderImpl
{
	uint playerCount { get; }

	void Initialize();

	void Shutdown();

	void Update();

	void OnFocusChanged(bool focus);

	bool RequestCurrentState(Event.Type type);
}
internal class InputEventPartialProvider : IEventProviderImpl
{
	private const int kDefaultPlayerId = 0;

	private UnityEngine.Event _ev = new UnityEngine.Event();

	private OperatingSystemFamily _operatingSystemFamily;

	private KeyEvent.ButtonsState _keyboardButtonsState;

	internal EventModifiers _eventModifiers;

	internal bool _sendNavigationEventOnTabKey;

	private IDictionary<string, CommandEvent.Command> _IMGUICommandToInputForUICommandType = new Dictionary<string, CommandEvent.Command>
	{
		{
			"Cut",
			CommandEvent.Command.Cut
		},
		{
			"Copy",
			CommandEvent.Command.Copy
		},
		{
			"Paste",
			CommandEvent.Command.Paste
		},
		{
			"SelectAll",
			CommandEvent.Command.SelectAll
		},
		{
			"DeselectAll",
			CommandEvent.Command.DeselectAll
		},
		{
			"InvertSelection",
			CommandEvent.Command.InvertSelection
		},
		{
			"Duplicate",
			CommandEvent.Command.Duplicate
		},
		{
			"Rename",
			CommandEvent.Command.Rename
		},
		{
			"Delete",
			CommandEvent.Command.Delete
		},
		{
			"SoftDelete",
			CommandEvent.Command.SoftDelete
		},
		{
			"Find",
			CommandEvent.Command.Find
		},
		{
			"SelectChildren",
			CommandEvent.Command.SelectChildren
		},
		{
			"SelectPrefabRoot",
			CommandEvent.Command.SelectPrefabRoot
		},
		{
			"UndoRedoPerformed",
			CommandEvent.Command.UndoRedoPerformed
		},
		{
			"OnLostFocus",
			CommandEvent.Command.OnLostFocus
		},
		{
			"NewKeyboardFocus",
			CommandEvent.Command.NewKeyboardFocus
		},
		{
			"ModifierKeysChanged",
			CommandEvent.Command.ModifierKeysChanged
		},
		{
			"EyeDropperUpdate",
			CommandEvent.Command.EyeDropperUpdate
		},
		{
			"EyeDropperClicked",
			CommandEvent.Command.EyeDropperClicked
		},
		{
			"EyeDropperCancelled",
			CommandEvent.Command.EyeDropperCancelled
		},
		{
			"ColorPickerChanged",
			CommandEvent.Command.ColorPickerChanged
		},
		{
			"FrameSelected",
			CommandEvent.Command.FrameSelected
		},
		{
			"FrameSelectedWithLock",
			CommandEvent.Command.FrameSelectedWithLock
		}
	};

	public uint playerCount => 0u;

	public void Initialize()
	{
		_operatingSystemFamily = SystemInfo.operatingSystemFamily;
		_keyboardButtonsState.Reset();
		_eventModifiers.Reset();
	}

	public void Shutdown()
	{
	}

	public void Update()
	{
		int eventCount = UnityEngine.Event.GetEventCount();
		for (int i = 0; i < eventCount; i++)
		{
			UnityEngine.Event.GetEventAtIndex(i, _ev);
			UpdateEventModifiers(in _ev);
			switch (_ev.type)
			{
			case EventType.KeyDown:
			case EventType.KeyUp:
				if (_ev.keyCode != KeyCode.None)
				{
					EventProvider.Dispatch(Event.From(ToKeyEvent(in _ev)));
					if (_sendNavigationEventOnTabKey)
					{
						SendNextOrPreviousNavigationEventOnTabKeyDownEvent(in _ev);
					}
				}
				if (_ev.character != 0 && _ev.type == EventType.KeyDown)
				{
					EventProvider.Dispatch(Event.From(ToTextInputEvent(in _ev)));
				}
				break;
			case EventType.ValidateCommand:
			case EventType.ExecuteCommand:
				EventProvider.Dispatch(Event.From(ToCommandEvent(in _ev)));
				break;
			}
		}
	}

	public void OnFocusChanged(bool focus)
	{
		if (!focus)
		{
			_eventModifiers.Reset();
			_keyboardButtonsState.Reset();
		}
	}

	public bool RequestCurrentState(Event.Type type)
	{
		if (type == Event.Type.KeyEvent)
		{
			EventProvider.Dispatch(Event.From(new KeyEvent
			{
				type = KeyEvent.Type.State,
				keyCode = KeyCode.None,
				buttonsState = _keyboardButtonsState,
				timestamp = (DiscreteTime)Time.timeAsRational,
				eventSource = EventSource.Keyboard,
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
			return true;
		}
		return false;
	}

	private DiscreteTime GetTimestamp(in UnityEngine.Event ev)
	{
		return (DiscreteTime)Time.timeAsRational;
	}

	private void UpdateEventModifiers(in UnityEngine.Event ev)
	{
		_eventModifiers.SetPressed(EventModifiers.Modifiers.CapsLock, ev.capsLock);
		_eventModifiers.SetPressed(EventModifiers.Modifiers.FunctionKey, ev.functionKey);
		_eventModifiers.SetPressed(EventModifiers.Modifiers.Numeric, ev.numeric);
		if (ev.isKey && ev.keyCode != KeyCode.None)
		{
			bool pressed = ev.type == EventType.KeyDown;
			switch (ev.keyCode)
			{
			case KeyCode.LeftShift:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.LeftShift, pressed);
				break;
			case KeyCode.RightShift:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.RightShift, pressed);
				break;
			case KeyCode.LeftControl:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.LeftCtrl, pressed);
				break;
			case KeyCode.RightControl:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.RightCtrl, pressed);
				break;
			case KeyCode.LeftAlt:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.LeftAlt, pressed);
				break;
			case KeyCode.RightAlt:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.RightAlt, pressed);
				break;
			case KeyCode.LeftMeta:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.LeftMeta, pressed);
				break;
			case KeyCode.RightMeta:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.RightMeta, pressed);
				break;
			case KeyCode.Numlock:
				_eventModifiers.SetPressed(EventModifiers.Modifiers.Numlock, pressed);
				break;
			}
		}
		if (ev.shift != _eventModifiers.IsPressed(EventModifiers.Modifiers.Shift))
		{
			_eventModifiers.SetPressed(EventModifiers.Modifiers.Shift, ev.shift);
		}
		if (ev.control != _eventModifiers.IsPressed(EventModifiers.Modifiers.Ctrl))
		{
			_eventModifiers.SetPressed(EventModifiers.Modifiers.Ctrl, ev.control);
		}
		if (ev.alt != _eventModifiers.IsPressed(EventModifiers.Modifiers.Alt))
		{
			_eventModifiers.SetPressed(EventModifiers.Modifiers.Alt, ev.alt);
		}
		if (ev.command != _eventModifiers.IsPressed(EventModifiers.Modifiers.Meta))
		{
			_eventModifiers.SetPressed(EventModifiers.Modifiers.Meta, ev.command);
		}
	}

	private KeyEvent ToKeyEvent(in UnityEngine.Event ev)
	{
		bool flag = _keyboardButtonsState.IsPressed(ev.keyCode);
		bool flag2 = ev.type == EventType.KeyDown;
		_keyboardButtonsState.SetPressed(ev.keyCode, flag2);
		return new KeyEvent
		{
			type = ((!flag2) ? KeyEvent.Type.KeyReleased : ((!flag) ? KeyEvent.Type.KeyPressed : KeyEvent.Type.KeyRepeated)),
			keyCode = ev.keyCode,
			buttonsState = _keyboardButtonsState,
			timestamp = GetTimestamp(in ev),
			eventSource = EventSource.Keyboard,
			playerId = 0u,
			eventModifiers = _eventModifiers
		};
	}

	private TextInputEvent ToTextInputEvent(in UnityEngine.Event ev)
	{
		return new TextInputEvent
		{
			character = ev.character,
			timestamp = GetTimestamp(in ev),
			eventSource = EventSource.Keyboard,
			playerId = 0u,
			eventModifiers = _eventModifiers
		};
	}

	private void SendNextOrPreviousNavigationEventOnTabKeyDownEvent(in UnityEngine.Event ev)
	{
		if (_ev.type == EventType.KeyDown && _ev.keyCode == KeyCode.Tab)
		{
			EventProvider.Dispatch(Event.From(new NavigationEvent
			{
				type = NavigationEvent.Type.Move,
				direction = (_ev.shift ? NavigationEvent.Direction.Previous : NavigationEvent.Direction.Next),
				timestamp = GetTimestamp(in _ev),
				eventSource = EventSource.Keyboard,
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
		}
	}

	private CommandEvent ToCommandEvent(in UnityEngine.Event ev)
	{
		if (!_IMGUICommandToInputForUICommandType.TryGetValue(ev.commandName, out var value))
		{
			Debug.LogWarning("Unsupported command name '" + ev.commandName + "'");
		}
		return new CommandEvent
		{
			type = ((ev.type == EventType.ValidateCommand) ? CommandEvent.Type.Validate : CommandEvent.Type.Execute),
			command = value,
			timestamp = GetTimestamp(in ev),
			eventSource = EventSource.Unspecified,
			playerId = 0u,
			eventModifiers = _eventModifiers
		};
	}
}
internal class InputManagerProvider : IEventProviderImpl
{
	private struct ButtonEventsIterator : IEnumerator
	{
		private uint _mask;

		private int _bit;

		private const uint kWasPressed = 1u;

		private const uint kWasReleased = 2u;

		private const int kMaxBits = 4;

		public bool Current => _bit % 2 == 0;

		object IEnumerator.Current => Current;

		public bool MoveNext()
		{
			do
			{
				_bit++;
				if ((_mask & (uint)(1 << _bit)) != 0)
				{
					return true;
				}
			}
			while (_bit < 4);
			return false;
		}

		public void Reset()
		{
			_bit = -1;
		}

		public static ButtonEventsIterator FromState(bool previous, bool down, bool up, bool current)
		{
			uint mask = ((!previous && current) ? 1u : ((previous && !current) ? 2u : 0u));
			return new ButtonEventsIterator
			{
				_mask = mask,
				_bit = -1
			};
		}
	}

	public struct Configuration
	{
		public string HorizontalAxis;

		public string VerticalAxis;

		public string SubmitButton;

		public string CancelButton;

		public string NavigateNextButton;

		public string NavigatePreviousButton;

		public float InputActionsPerSecond;

		public float RepeatDelay;

		public static Configuration GetDefaultConfiguration()
		{
			return new Configuration
			{
				HorizontalAxis = "Horizontal",
				VerticalAxis = "Vertical",
				SubmitButton = "Submit",
				CancelButton = "Cancel",
				NavigateNextButton = "Next",
				NavigatePreviousButton = "Previous",
				InputActionsPerSecond = 10f,
				RepeatDelay = 0.5f
			};
		}
	}

	internal interface IInput
	{
		string compositionString { get; }

		bool touchSupported { get; }

		int touchCount { get; }

		bool mousePresent { get; }

		Vector3 mousePosition { get; }

		Vector2 mouseScrollDelta { get; }

		bool GetKey(KeyCode keyCode);

		bool GetKeyDown(KeyCode keyCode);

		bool GetButtonDown(string button);

		float GetAxisRaw(string axis);

		PenData GetPenEvent(int index);

		PenData GetLastPenContactEvent();

		Touch GetTouch(int index);

		bool GetMouseButton(int button);

		bool GetMouseButtonDown(int button);

		bool GetMouseButtonUp(int button);
	}

	private class Input : IInput
	{
		public string compositionString => UnityEngine.Input.compositionString;

		public bool touchSupported => UnityEngine.Input.touchSupported;

		public int touchCount => UnityEngine.Input.touchCount;

		public bool mousePresent => UnityEngine.Input.mousePresent;

		public Vector3 mousePosition => UnityEngine.Input.mousePosition;

		public Vector2 mouseScrollDelta => UnityEngine.Input.mouseScrollDelta;

		public bool GetKey(KeyCode key)
		{
			return UnityEngine.Input.GetKey(key);
		}

		public bool GetKeyDown(KeyCode key)
		{
			return UnityEngine.Input.GetKeyDown(key);
		}

		public bool GetButtonDown(string button)
		{
			return UnityEngine.Input.GetButtonDown(button);
		}

		public float GetAxisRaw(string axis)
		{
			return UnityEngine.Input.GetAxisRaw(axis);
		}

		public PenData GetPenEvent(int index)
		{
			return UnityEngine.Input.GetPenEvent(index);
		}

		public PenData GetLastPenContactEvent()
		{
			return UnityEngine.Input.GetLastPenContactEvent();
		}

		public Touch GetTouch(int index)
		{
			return UnityEngine.Input.GetTouch(index);
		}

		public bool GetMouseButton(int button)
		{
			return UnityEngine.Input.GetMouseButton(button);
		}

		public bool GetMouseButtonDown(int button)
		{
			return UnityEngine.Input.GetMouseButtonDown(button);
		}

		public bool GetMouseButtonUp(int button)
		{
			return UnityEngine.Input.GetMouseButtonUp(button);
		}
	}

	internal interface ITime
	{
		RationalTime timeAsRational { get; }
	}

	private class Time : ITime
	{
		public RationalTime timeAsRational => UnityEngine.Time.timeAsRational;
	}

	private InputEventPartialProvider _inputEventPartialProvider;

	private const int kDefaultPlayerId = 0;

	private string _compositionString = string.Empty;

	private Configuration _configuration = Configuration.GetDefaultConfiguration();

	private IInput _input = new Input();

	private ITime _time = new Time();

	private NavigationEventRepeatHelper _navigationEventRepeatHelper = new NavigationEventRepeatHelper();

	private const int kMaxMouseButtons = 5;

	private PointerState _mouseState;

	private bool _isPenPresent;

	private bool _seenAtLeastOnePenPosition;

	private Vector2 _lastSeenPenPositionForDetection;

	private PointerState _penState;

	private PenData _lastPenData;

	private Dictionary<int, int> _touchFingerIdToFingerIndex = new Dictionary<int, int>();

	private int _touchNextFingerIndex;

	private PointerState _touchState;

	private const float kSmallestReportedMovementSqrDist = 0.01f;

	private const float kScrollUGUIScaleFactor = 3f;

	private EventModifiers _eventModifiers => _inputEventPartialProvider._eventModifiers;

	public uint playerCount => 1u;

	public InputManagerProvider()
	{
	}

	internal InputManagerProvider(IInput inputOverride, ITime timeOverride)
	{
		_input = inputOverride;
		_time = timeOverride;
	}

	public void Initialize()
	{
		if (_inputEventPartialProvider == null)
		{
			_inputEventPartialProvider = new InputEventPartialProvider();
		}
		_inputEventPartialProvider.Initialize();
		_inputEventPartialProvider._sendNavigationEventOnTabKey = true;
		_mouseState.Reset();
		_isPenPresent = false;
		_seenAtLeastOnePenPosition = false;
		_lastSeenPenPositionForDetection = default(Vector2);
		_penState.Reset();
		_lastPenData = default(PenData);
		_touchFingerIdToFingerIndex.Clear();
		_touchNextFingerIndex = 0;
		_touchState.Reset();
	}

	public void Shutdown()
	{
	}

	public void Update()
	{
		_inputEventPartialProvider.Update();
		DiscreteTime currentTime = (DiscreteTime)_time.timeAsRational;
		DetectPen();
		bool flag = false;
		if (_input.touchSupported)
		{
			flag = CheckTouchEvents(currentTime);
		}
		bool flag2 = false;
		if (!flag && _isPenPresent)
		{
			flag2 = CheckPenEvent(currentTime, _input.GetLastPenContactEvent());
		}
		else
		{
			_penState.Reset();
		}
		if (!flag2 && !flag && _input.mousePresent)
		{
			CheckMouseEvents(currentTime);
		}
		else
		{
			CheckMouseEvents(currentTime, muted: true);
			_mouseState.LastPositionValid = false;
		}
		if (_input.mousePresent)
		{
			CheckMouseScroll(currentTime);
		}
		CheckIfIMEChanged(currentTime);
		DirectionNavigation(currentTime);
		SubmitCancelNavigation(currentTime);
		NextPreviousNavigation(currentTime);
	}

	private bool CheckTouchEvents(DiscreteTime currentTime)
	{
		bool flag = true;
		bool result = false;
		for (int i = 0; i < _input.touchCount; i++)
		{
			Touch touch = _input.GetTouch(i);
			if (touch.type != TouchType.Indirect && touch.phase != TouchPhase.Stationary)
			{
				if (!_touchFingerIdToFingerIndex.TryGetValue(touch.fingerId, out var value))
				{
					value = _touchNextFingerIndex++;
					_touchFingerIdToFingerIndex.Add(touch.fingerId, value);
				}
				int targetDisplay;
				Vector2 position = MultiDisplayBottomLeftToPanelPosition(touch.position, out targetDisplay);
				Vector2 deltaPosition = ScreenBottomLeftToPanelDelta(touch.deltaPosition);
				PointerEvent.Type type = PointerEvent.Type.PointerMoved;
				PointerEvent.Button button = PointerEvent.Button.None;
				switch (touch.phase)
				{
				case TouchPhase.Began:
					type = PointerEvent.Type.ButtonPressed;
					button = PointerEvent.Button.Primary;
					flag = false;
					_touchState.OnButtonDown(currentTime, button);
					break;
				case TouchPhase.Ended:
					type = PointerEvent.Type.ButtonReleased;
					button = PointerEvent.Button.Primary;
					_touchState.OnButtonUp(currentTime, button);
					break;
				case TouchPhase.Canceled:
					type = PointerEvent.Type.TouchCanceled;
					button = PointerEvent.Button.Primary;
					_touchState.OnButtonUp(currentTime, button);
					break;
				case TouchPhase.Moved:
					flag = false;
					break;
				}
				EventProvider.Dispatch(Event.From(new PointerEvent
				{
					type = type,
					pointerIndex = value,
					position = position,
					deltaPosition = deltaPosition,
					scroll = Vector2.zero,
					displayIndex = targetDisplay,
					tilt = AzimuthAndAlitutudeToTilt(touch.altitudeAngle, touch.azimuthAngle),
					twist = 0f,
					pressure = ((Mathf.Abs(touch.maximumPossiblePressure) > Mathf.Epsilon) ? (touch.pressure / touch.maximumPossiblePressure) : 1f),
					isInverted = false,
					button = button,
					buttonsState = _touchState.ButtonsState,
					clickCount = _touchState.ClickCount,
					timestamp = currentTime,
					eventSource = EventSource.Touch,
					playerId = 0u,
					eventModifiers = _eventModifiers
				}));
				result = true;
			}
		}
		if (flag)
		{
			_touchNextFingerIndex = 0;
			_touchFingerIdToFingerIndex.Clear();
		}
		return result;
	}

	private void DetectPen()
	{
		if (!_isPenPresent)
		{
			Vector2 position = _input.GetLastPenContactEvent().position;
			if (_seenAtLeastOnePenPosition)
			{
				float sqrMagnitude = (position - _lastSeenPenPositionForDetection).sqrMagnitude;
				_isPenPresent = sqrMagnitude >= 0.01f;
			}
			else
			{
				_lastSeenPenPositionForDetection = position;
				_seenAtLeastOnePenPosition = true;
			}
		}
	}

	private static PointerEvent.Button PenStatusToButton(PenStatus status)
	{
		if ((status & PenStatus.Eraser) != PenStatus.None)
		{
			return PointerEvent.Button.PenEraserInTouch;
		}
		if ((status & PenStatus.Barrel) != PenStatus.None)
		{
			return PointerEvent.Button.PenBarrelButton;
		}
		return PointerEvent.Button.Primary;
	}

	private bool CheckPenEvent(DiscreteTime currentTime, in PenData currentPenData)
	{
		Vector2 position = currentPenData.position;
		int displayIndex = 0;
		Vector2 deltaPosition = (_penState.LastPositionValid ? (position - _penState.LastPosition) : Vector2.zero);
		PointerEvent.Button button = PointerEvent.Button.None;
		PointerEvent.Type type;
		if (currentPenData.contactType != _lastPenData.contactType)
		{
			switch (currentPenData.contactType)
			{
			case PenEventType.PenDown:
				type = PointerEvent.Type.ButtonPressed;
				button = PenStatusToButton(currentPenData.penStatus);
				_penState.OnButtonDown(currentTime, button);
				break;
			case PenEventType.PenUp:
				type = PointerEvent.Type.ButtonReleased;
				button = PenStatusToButton(_lastPenData.penStatus);
				_penState.OnButtonUp(currentTime, button);
				break;
			default:
				type = PointerEvent.Type.PointerMoved;
				break;
			}
		}
		else
		{
			type = PointerEvent.Type.PointerMoved;
		}
		_lastPenData = currentPenData;
		bool result = false;
		if (type != PointerEvent.Type.PointerMoved || !_penState.LastPositionValid || deltaPosition.sqrMagnitude >= 0.01f)
		{
			EventProvider.Dispatch(Event.From(new PointerEvent
			{
				type = type,
				pointerIndex = 0,
				position = position,
				deltaPosition = deltaPosition,
				scroll = Vector2.zero,
				displayIndex = displayIndex,
				tilt = currentPenData.tilt,
				twist = currentPenData.twist,
				pressure = currentPenData.pressure,
				isInverted = ((currentPenData.penStatus & PenStatus.Inverted) != 0),
				button = button,
				buttonsState = _penState.ButtonsState,
				clickCount = _penState.ClickCount,
				timestamp = currentTime,
				eventSource = EventSource.Pen,
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
			result = true;
		}
		_penState.OnMove(currentTime, position, displayIndex);
		return result;
	}

	private void CheckMouseEvents(DiscreteTime currentTime, bool muted = false)
	{
		int targetDisplay;
		Vector2 vector = MultiDisplayBottomLeftToPanelPosition(_input.mousePosition, out targetDisplay);
		if (_mouseState.LastPositionValid)
		{
			Vector2 deltaPosition = vector - _mouseState.LastPosition;
			if (deltaPosition.sqrMagnitude >= 0.01f)
			{
				if (!muted)
				{
					EventProvider.Dispatch(Event.From(new PointerEvent
					{
						type = PointerEvent.Type.PointerMoved,
						pointerIndex = 0,
						position = vector,
						deltaPosition = deltaPosition,
						scroll = Vector2.zero,
						displayIndex = targetDisplay,
						tilt = Vector2.zero,
						twist = 0f,
						pressure = 0f,
						isInverted = false,
						button = PointerEvent.Button.None,
						buttonsState = _mouseState.ButtonsState,
						clickCount = 0,
						timestamp = currentTime,
						eventSource = EventSource.Mouse,
						playerId = 0u,
						eventModifiers = _eventModifiers
					}));
				}
				_mouseState.OnMove(currentTime, vector, targetDisplay);
			}
		}
		else
		{
			_mouseState.OnMove(currentTime, vector, targetDisplay);
		}
		for (int i = 0; i < 5; i++)
		{
			PointerEvent.Button button = PointerEvent.ButtonFromButtonIndex(i);
			bool flag = _mouseState.ButtonsState.Get(button);
			bool mouseButtonDown = _input.GetMouseButtonDown(i);
			bool mouseButtonUp = _input.GetMouseButtonUp(i);
			bool mouseButton = _input.GetMouseButton(i);
			ButtonEventsIterator buttonEventsIterator = ButtonEventsIterator.FromState(flag, mouseButtonDown, mouseButtonUp, mouseButton);
			bool previousState = flag;
			while (buttonEventsIterator.MoveNext())
			{
				_mouseState.OnButtonChange(currentTime, button, previousState, buttonEventsIterator.Current);
				previousState = buttonEventsIterator.Current;
				if (!muted)
				{
					EventProvider.Dispatch(Event.From(new PointerEvent
					{
						type = (buttonEventsIterator.Current ? PointerEvent.Type.ButtonPressed : PointerEvent.Type.ButtonReleased),
						pointerIndex = 0,
						position = _mouseState.LastPosition,
						deltaPosition = Vector2.zero,
						scroll = Vector2.zero,
						displayIndex = _mouseState.LastDisplayIndex,
						tilt = Vector2.zero,
						twist = 0f,
						pressure = 0f,
						isInverted = false,
						button = button,
						buttonsState = _mouseState.ButtonsState,
						clickCount = _mouseState.ClickCount,
						timestamp = currentTime,
						eventSource = EventSource.Mouse,
						playerId = 0u,
						eventModifiers = _eventModifiers
					}));
				}
			}
		}
	}

	private void CheckMouseScroll(DiscreteTime currentTime)
	{
		Vector2 mouseScrollDelta = _input.mouseScrollDelta;
		if (!(mouseScrollDelta.sqrMagnitude < 0.01f))
		{
			int targetDisplay = 0;
			Vector2 position;
			if (_mouseState.LastPositionValid)
			{
				position = _mouseState.LastPosition;
				targetDisplay = _mouseState.LastDisplayIndex;
			}
			else
			{
				position = MultiDisplayBottomLeftToPanelPosition(_input.mousePosition, out targetDisplay);
			}
			mouseScrollDelta.x *= 3f;
			mouseScrollDelta.y *= -3f;
			EventProvider.Dispatch(Event.From(new PointerEvent
			{
				type = PointerEvent.Type.Scroll,
				pointerIndex = 0,
				position = position,
				deltaPosition = Vector2.zero,
				scroll = mouseScrollDelta,
				displayIndex = targetDisplay,
				tilt = Vector2.zero,
				twist = 0f,
				pressure = 0f,
				isInverted = false,
				button = PointerEvent.Button.None,
				buttonsState = _mouseState.ButtonsState,
				clickCount = 0,
				timestamp = currentTime,
				eventSource = EventSource.Mouse,
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
		}
	}

	private PointerEvent ToPointerStateEvent(DiscreteTime currentTime, in PointerState state, EventSource eventSource)
	{
		return new PointerEvent
		{
			type = PointerEvent.Type.State,
			pointerIndex = 0,
			position = state.LastPosition,
			deltaPosition = Vector2.zero,
			scroll = Vector2.zero,
			displayIndex = state.LastDisplayIndex,
			tilt = ((eventSource == EventSource.Pen) ? _lastPenData.tilt : Vector2.zero),
			twist = ((eventSource == EventSource.Pen) ? _lastPenData.twist : 0f),
			pressure = ((eventSource == EventSource.Pen) ? _lastPenData.pressure : 0f),
			isInverted = (eventSource == EventSource.Pen && (_lastPenData.penStatus & PenStatus.Inverted) != 0),
			button = PointerEvent.Button.None,
			buttonsState = state.ButtonsState,
			clickCount = 0,
			timestamp = currentTime,
			eventSource = eventSource,
			playerId = 0u,
			eventModifiers = _eventModifiers
		};
	}

	private void NextPreviousNavigation(DiscreteTime currentTime)
	{
		int num = (InputManagerGetButtonDownOrDefault(_configuration.NavigateNextButton) ? 1 : 0) + (InputManagerGetButtonDownOrDefault(_configuration.NavigatePreviousButton) ? (-1) : 0);
		if (num != 0)
		{
			if (_eventModifiers.isShiftPressed)
			{
				num = -num;
			}
			EventProvider.Dispatch(Event.From(new NavigationEvent
			{
				type = NavigationEvent.Type.Move,
				direction = ((num >= 0) ? NavigationEvent.Direction.Next : NavigationEvent.Direction.Previous),
				timestamp = currentTime,
				eventSource = GetEventSourceFromPressedKey(),
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
		}
	}

	private void SubmitCancelNavigation(DiscreteTime currentTime)
	{
		if (InputManagerGetButtonDownOrDefault(_configuration.SubmitButton))
		{
			EventProvider.Dispatch(Event.From(new NavigationEvent
			{
				type = NavigationEvent.Type.Submit,
				direction = NavigationEvent.Direction.None,
				timestamp = currentTime,
				eventSource = GetEventSourceFromPressedKey(),
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
		}
		if (InputManagerGetButtonDownOrDefault(_configuration.CancelButton))
		{
			EventProvider.Dispatch(Event.From(new NavigationEvent
			{
				type = NavigationEvent.Type.Cancel,
				direction = NavigationEvent.Direction.None,
				timestamp = currentTime,
				eventSource = GetEventSourceFromPressedKey(),
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
		}
	}

	private void DirectionNavigation(DiscreteTime currentTime)
	{
		(Vector2, bool) tuple = ReadCurrentNavigationMoveVector();
		Vector2 item = tuple.Item1;
		bool item2 = tuple.Item2;
		NavigationEvent.Direction direction = NavigationEvent.DetermineMoveDirection(item);
		if (direction == NavigationEvent.Direction.None)
		{
			_navigationEventRepeatHelper.Reset();
		}
		else if (_navigationEventRepeatHelper.ShouldSendMoveEvent(currentTime, direction, item2))
		{
			EventSource eventSource = GetEventSourceFromPressedKey();
			if (eventSource == EventSource.Unspecified && !item2)
			{
				eventSource = EventSource.Gamepad;
			}
			EventProvider.Dispatch(Event.From(new NavigationEvent
			{
				type = NavigationEvent.Type.Move,
				direction = direction,
				timestamp = currentTime,
				eventSource = eventSource,
				playerId = 0u,
				eventModifiers = _eventModifiers
			}));
		}
	}

	private void CheckIfIMEChanged(DiscreteTime currentTime)
	{
		string compositionString = _input.compositionString;
		if (_compositionString != compositionString)
		{
			_compositionString = compositionString;
			EventProvider.Dispatch(Event.From(ToIMECompositionEvent(currentTime, _compositionString)));
		}
	}

	public void OnFocusChanged(bool focus)
	{
		_inputEventPartialProvider.OnFocusChanged(focus);
	}

	public bool RequestCurrentState(Event.Type type)
	{
		if (_inputEventPartialProvider.RequestCurrentState(type))
		{
			return true;
		}
		DiscreteTime currentTime = (DiscreteTime)_time.timeAsRational;
		switch (type)
		{
		case Event.Type.PointerEvent:
			if (_touchState.LastPositionValid)
			{
				EventProvider.Dispatch(Event.From(ToPointerStateEvent(currentTime, in _touchState, EventSource.Touch)));
			}
			if (_penState.LastPositionValid)
			{
				EventProvider.Dispatch(Event.From(ToPointerStateEvent(currentTime, in _penState, EventSource.Pen)));
			}
			if (_mouseState.LastPositionValid)
			{
				EventProvider.Dispatch(Event.From(ToPointerStateEvent(currentTime, in _mouseState, EventSource.Mouse)));
			}
			return _touchState.LastPositionValid || _penState.LastPositionValid || _mouseState.LastPositionValid;
		case Event.Type.IMECompositionEvent:
			EventProvider.Dispatch(Event.From(ToIMECompositionEvent(currentTime, _compositionString)));
			return true;
		default:
			return false;
		}
	}

	private EventSource GetEventSourceFromPressedKey()
	{
		if (InputManagerKeyboardWasPressed())
		{
			return EventSource.Keyboard;
		}
		if (InputManagerJoystickWasPressed())
		{
			return EventSource.Gamepad;
		}
		return EventSource.Unspecified;
	}

	private bool InputManagerJoystickWasPressed()
	{
		for (KeyCode keyCode = KeyCode.Joystick1Button0; keyCode <= KeyCode.Joystick8Button19; keyCode++)
		{
			if (_input.GetKey(keyCode))
			{
				return true;
			}
		}
		return false;
	}

	private bool InputManagerKeyboardWasPressed()
	{
		for (KeyCode keyCode = KeyCode.None; keyCode <= KeyCode.Menu; keyCode++)
		{
			if (_input.GetKey(keyCode))
			{
				return true;
			}
		}
		return false;
	}

	private float InputManagerGetAxisRawOrDefault(string axisName)
	{
		try
		{
			return (!string.IsNullOrEmpty(axisName)) ? _input.GetAxisRaw(axisName) : 0f;
		}
		catch
		{
			return 0f;
		}
	}

	private bool InputManagerGetButtonDownOrDefault(string axisName)
	{
		try
		{
			return !string.IsNullOrEmpty(axisName) && _input.GetButtonDown(axisName);
		}
		catch
		{
			return false;
		}
	}

	private (Vector2, bool) ReadCurrentNavigationMoveVector()
	{
		Vector2 item = new Vector2(InputManagerGetAxisRawOrDefault(_configuration.HorizontalAxis), InputManagerGetAxisRawOrDefault(_configuration.VerticalAxis));
		bool item2 = false;
		if (InputManagerGetButtonDownOrDefault(_configuration.HorizontalAxis))
		{
			if (item.x < 0f)
			{
				item.x = -1f;
			}
			else if (item.x > 0f)
			{
				item.x = 1f;
			}
			item2 = true;
		}
		if (InputManagerGetButtonDownOrDefault(_configuration.VerticalAxis))
		{
			if (item.y < 0f)
			{
				item.y = -1f;
			}
			else if (item.y > 0f)
			{
				item.y = 1f;
			}
			item2 = true;
		}
		return (item, item2);
	}

	private IMECompositionEvent ToIMECompositionEvent(DiscreteTime currentTime, string compositionString)
	{
		return new IMECompositionEvent
		{
			compositionString = compositionString,
			timestamp = currentTime,
			eventSource = EventSource.Unspecified,
			playerId = 0u,
			eventModifiers = _eventModifiers
		};
	}

	internal static float TiltToAzimuth(Vector2 tilt)
	{
		float result = 0f;
		if (tilt.x != 0f)
		{
			result = MathF.PI / 2f - Mathf.Atan2((0f - Mathf.Cos(tilt.x)) * Mathf.Sin(tilt.y), Mathf.Cos(tilt.y) * Mathf.Sin(tilt.x));
			if (result < 0f)
			{
				result += MathF.PI * 2f;
			}
			result = ((!(result >= MathF.PI / 2f)) ? (result + 4.712389f) : (result - MathF.PI / 2f));
		}
		return result;
	}

	internal static Vector2 AzimuthAndAlitutudeToTilt(float altitude, float azimuth)
	{
		Vector2 result = new Vector2(0f, 0f);
		result.x = Mathf.Atan(Mathf.Cos(azimuth) * Mathf.Cos(altitude) / Mathf.Sin(azimuth));
		result.y = Mathf.Atan(Mathf.Cos(azimuth) * Mathf.Sin(altitude) / Mathf.Sin(azimuth));
		return result;
	}

	internal static float TiltToAltitude(Vector2 tilt)
	{
		return MathF.PI / 2f - Mathf.Acos(Mathf.Cos(tilt.x) * Mathf.Cos(tilt.y));
	}

	private static Vector2 MultiDisplayBottomLeftToPanelPosition(Vector2 position, out int targetDisplay)
	{
		int? targetDisplay2;
		Vector2 position2 = MultiDisplayToLocalScreenPosition(position, out targetDisplay2);
		targetDisplay = targetDisplay2.GetValueOrDefault();
		return ScreenBottomLeftToPanelPosition(position2, targetDisplay);
	}

	private static Vector2 MultiDisplayToLocalScreenPosition(Vector2 position, out int? targetDisplay)
	{
		Vector3 vector = Display.RelativeMouseAt(position);
		if (vector != Vector3.zero)
		{
			targetDisplay = (int)vector.z;
			return vector;
		}
		targetDisplay = null;
		return position;
	}

	private static Vector2 ScreenBottomLeftToPanelPosition(Vector2 position, int targetDisplay)
	{
		int num = Screen.height;
		if (targetDisplay > 0 && targetDisplay < Display.displays.Length)
		{
			num = Display.displays[targetDisplay].systemHeight;
		}
		position.y = (float)num - position.y;
		return position;
	}

	private static Vector2 ScreenBottomLeftToPanelDelta(Vector2 delta)
	{
		delta.y = 0f - delta.y;
		return delta;
	}
}
internal class NavigationEventRepeatHelper
{
	private int m_ConsecutiveMoveCount;

	private NavigationEvent.Direction m_LastDirection;

	private DiscreteTime m_PrevActionTime;

	private readonly DiscreteTime m_InitialRepeatDelay = new DiscreteTime(0.5f);

	private readonly DiscreteTime m_ConsecutiveRepeatDelay = new DiscreteTime(0.1f);

	public void Reset()
	{
		m_ConsecutiveMoveCount = 0;
		m_LastDirection = NavigationEvent.Direction.None;
		m_PrevActionTime = DiscreteTime.Zero;
	}

	public bool ShouldSendMoveEvent(DiscreteTime timestamp, NavigationEvent.Direction direction, bool axisButtonsWherePressedThisFrame)
	{
		if (axisButtonsWherePressedThisFrame || direction != m_LastDirection || timestamp > m_PrevActionTime + ((m_ConsecutiveMoveCount == 1) ? m_InitialRepeatDelay : m_ConsecutiveRepeatDelay))
		{
			m_ConsecutiveMoveCount = ((direction != m_LastDirection) ? 1 : (m_ConsecutiveMoveCount + 1));
			m_LastDirection = direction;
			m_PrevActionTime = timestamp;
			return true;
		}
		return false;
	}
}
internal struct PointerState
{
	private PointerEvent.ButtonsState _buttonsState;

	private static readonly DiscreteTime kClickDelay = new DiscreteTime((double)UnityEngine.Event.GetDoubleClickTime() / 1000.0);

	public PointerEvent.Button LastPressedButton { get; private set; }

	public PointerEvent.ButtonsState ButtonsState => _buttonsState;

	public DiscreteTime NextPressTime { get; private set; }

	public int ClickCount { get; private set; }

	public Vector2 LastPosition { get; private set; }

	public int LastDisplayIndex { get; private set; }

	public bool LastPositionValid { get; set; }

	public void OnButtonDown(DiscreteTime currentTime, PointerEvent.Button button)
	{
		if (LastPressedButton != button || currentTime >= NextPressTime)
		{
			ClickCount = 0;
		}
		LastPressedButton = button;
		_buttonsState.Set(button, pressed: true);
		ClickCount++;
		NextPressTime = currentTime + kClickDelay;
	}

	public void OnButtonUp(DiscreteTime currentTime, PointerEvent.Button button)
	{
		if (LastPressedButton != button)
		{
			ClickCount = 1;
		}
		_buttonsState.Set(button, pressed: false);
	}

	public void OnButtonChange(DiscreteTime currentTime, PointerEvent.Button button, bool previousState, bool newState)
	{
		if (newState && !previousState)
		{
			OnButtonDown(currentTime, button);
		}
		else if (!newState && previousState)
		{
			OnButtonUp(currentTime, button);
		}
	}

	public void OnMove(DiscreteTime currentTime, Vector2 position, int displayIndex)
	{
		LastPosition = position;
		LastDisplayIndex = displayIndex;
		LastPositionValid = true;
	}

	public void Reset()
	{
		LastPressedButton = PointerEvent.Button.None;
		ButtonsState.Reset();
		NextPressTime = DiscreteTime.Zero;
		ClickCount = 0;
		LastPosition = Vector2.zero;
		LastDisplayIndex = 0;
		LastPositionValid = false;
	}
}
internal struct EventSanitizer
{
	private interface IEventSanitizer
	{
		void Reset();

		void BeforeProviderUpdate();

		void AfterProviderUpdate();

		void Inspect(in Event ev);
	}

	private struct ClickCountEventSanitizer : IEventSanitizer
	{
		private List<PointerEvent> _activeButtons;

		private int lastPushedIndex;

		public void Reset()
		{
			_activeButtons = new List<PointerEvent>();
			lastPushedIndex = 0;
		}

		public void BeforeProviderUpdate()
		{
		}

		public void AfterProviderUpdate()
		{
		}

		public void Inspect(in Event ev)
		{
			if (ev.type != Event.Type.PointerEvent)
			{
				return;
			}
			PointerEvent asPointerEvent = ev.asPointerEvent;
			switch (asPointerEvent.type)
			{
			case PointerEvent.Type.ButtonPressed:
				lastPushedIndex = _activeButtons.Count;
				_activeButtons.Add(asPointerEvent);
				break;
			case PointerEvent.Type.ButtonReleased:
			{
				PointerEvent pointerEvent = asPointerEvent;
				for (int i = 0; i < _activeButtons.Count; i++)
				{
					PointerEvent pointerEvent2 = _activeButtons[i];
					if (pointerEvent2.eventSource != pointerEvent.eventSource || pointerEvent2.pointerIndex != pointerEvent.pointerIndex)
					{
						continue;
					}
					if (i == lastPushedIndex)
					{
						if (pointerEvent2.clickCount != pointerEvent.clickCount)
						{
							Debug.LogWarning($"ButtonReleased click count doesn't match ButtonPressed click count, where '{pointerEvent2}' and '{pointerEvent}'");
						}
					}
					else if (pointerEvent.clickCount != 1)
					{
						Debug.LogWarning($"ButtonReleased for not the last pressed button should have click count == 1, but got '{pointerEvent}'");
					}
					_activeButtons.RemoveAt(i);
					return;
				}
				Debug.LogWarning($"Can't find corresponding ButtonPressed for '{ev}'");
				break;
			}
			}
		}

		void IEventSanitizer.Inspect(in Event ev)
		{
			Inspect(in ev);
		}
	}

	private class DefaultEventSystemSanitizer : IEventSanitizer
	{
		private int m_MouseEventCount;

		private int m_PenOrTouchEventCount;

		public void Reset()
		{
		}

		public void BeforeProviderUpdate()
		{
			m_MouseEventCount = 0;
			m_PenOrTouchEventCount = 0;
		}

		public void AfterProviderUpdate()
		{
			if (m_MouseEventCount > 0 && m_PenOrTouchEventCount > 0)
			{
				Debug.LogError("PointerEvents of source Mouse and [Pen or Touch] received in the same update. This is likely an error, and Mouse events should be discarded.");
			}
		}

		public void Inspect(in Event ev)
		{
			if (ev.type != Event.Type.PointerEvent)
			{
				return;
			}
			PointerEvent asPointerEvent = ev.asPointerEvent;
			if (asPointerEvent.type == PointerEvent.Type.ButtonPressed && asPointerEvent.button == PointerEvent.Button.None)
			{
				Debug.LogError("PointerEvent of type ButtonPressed must have button property set to a value other than None.");
			}
			if (asPointerEvent.type == PointerEvent.Type.ButtonReleased && asPointerEvent.button == PointerEvent.Button.None)
			{
				Debug.LogError("PointerEvent of type ButtonReleased must have button property set to a value other than None.");
			}
			if (asPointerEvent.eventSource == EventSource.Mouse)
			{
				m_MouseEventCount++;
				if (!asPointerEvent.isPrimaryPointer)
				{
					Debug.LogError("PointerEvent of source Mouse is expected to have isPrimaryPointer set to true.");
				}
				if (asPointerEvent.pointerIndex != 0)
				{
					Debug.LogError("PointerEvent of source Mouse is expected to have pointerIndex set to 0.");
				}
			}
			else if (asPointerEvent.eventSource == EventSource.Touch)
			{
				m_PenOrTouchEventCount++;
				if (asPointerEvent.button != PointerEvent.Button.None && asPointerEvent.button != PointerEvent.Button.Primary)
				{
					Debug.LogError("PointerEvent of source Touch is expected to have button set to None or FingerInTouch.");
				}
			}
			else if (asPointerEvent.eventSource == EventSource.Pen)
			{
				m_PenOrTouchEventCount++;
				if (asPointerEvent.button != PointerEvent.Button.None && asPointerEvent.button != PointerEvent.Button.Primary && asPointerEvent.button != PointerEvent.Button.PenBarrelButton && asPointerEvent.button != PointerEvent.Button.PenEraserInTouch)
				{
					Debug.LogError("PointerEvent of source Pen is expected to have button set to None, PenTipInTouch, PenBarrelButton, or PenEraserInTouch.");
				}
			}
		}

		void IEventSanitizer.Inspect(in Event ev)
		{
			Inspect(in ev);
		}
	}

	private IEventSanitizer[] _sanitizers;

	public void Reset()
	{
		_sanitizers = new IEventSanitizer[0];
		IEventSanitizer[] sanitizers = _sanitizers;
		foreach (IEventSanitizer eventSanitizer in sanitizers)
		{
			eventSanitizer.Reset();
		}
	}

	public void BeforeProviderUpdate()
	{
		if (_sanitizers == null)
		{
			Reset();
		}
		IEventSanitizer[] sanitizers = _sanitizers;
		foreach (IEventSanitizer eventSanitizer in sanitizers)
		{
			eventSanitizer.BeforeProviderUpdate();
		}
	}

	public void AfterProviderUpdate()
	{
		if (_sanitizers == null)
		{
			Reset();
		}
		IEventSanitizer[] sanitizers = _sanitizers;
		foreach (IEventSanitizer eventSanitizer in sanitizers)
		{
			eventSanitizer.AfterProviderUpdate();
		}
	}

	public void Inspect(in Event ev)
	{
		if (_sanitizers == null)
		{
			Reset();
		}
		IEventSanitizer[] sanitizers = _sanitizers;
		foreach (IEventSanitizer eventSanitizer in sanitizers)
		{
			eventSanitizer.Inspect(in ev);
		}
	}
}
