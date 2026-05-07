#define UNITY_ASSERTIONS
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Pool;
using UnityEngine.Scripting;

[assembly: InternalsVisibleTo("UnityEditor.CoreModule")]
[assembly: InternalsVisibleTo("UnityEditor.AccessibilityModule")]
[assembly: InternalsVisibleTo("Unity.Modules.Accessibility.Tests.Editor")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("Acessibility.VisionUtility.Tests")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine.Accessibility;

[StructLayout(LayoutKind.Sequential)]
[RequiredByNativeCode]
[NativeHeader("Modules/Accessibility/Native/AccessibilityAction.h")]
internal sealed class AccessibilityAction : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(AccessibilityAction obj)
		{
			return obj.m_Ptr;
		}

		public static AccessibilityAction ConvertToManaged(IntPtr ptr)
		{
			return new AccessibilityAction(ptr);
		}
	}

	private IntPtr m_Ptr;

	public int id
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_id_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_id_Injected(intPtr, value);
		}
	}

	public unsafe string label
	{
		get
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_label_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}
		set
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						set_label_Injected(intPtr, ref managedSpanWrapper);
						return;
					}
				}
				set_label_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}
	}

	public Func<bool> activated { get; set; }

	public AccessibilityAction()
	{
		m_Ptr = Internal_Create(this);
	}

	public AccessibilityAction(IntPtr ptr)
	{
		m_Ptr = ptr;
	}

	~AccessibilityAction()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool disposing)
	{
		if (m_Ptr != IntPtr.Zero)
		{
			Internal_Destroy(m_Ptr);
			m_Ptr = IntPtr.Zero;
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Internal_Create([Unmarshalled] AccessibilityAction self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_Destroy(IntPtr ptr);

	[RequiredByNativeCode]
	private bool Internal_InvokeActivated()
	{
		return activated != null && activated();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_id_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_id_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_label_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_label_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);
}
[VisibleToOtherModules(new string[] { "UnityEditor.AccessibilityModule" })]
[NativeHeader("Modules/Accessibility/Native/AccessibilityManager.h")]
internal static class AccessibilityManager
{
	public struct NotificationContext
	{
		public AccessibilityNotification notification { get; set; }

		public bool isScreenReaderEnabled { get; set; }

		public string announcement { get; set; }

		public bool wasAnnouncementSuccessful { get; set; }

		public AccessibilityNode currentNode { get; set; }

		public AccessibilityNode nextNode { get; set; }

		public float fontScale { get; set; }

		public bool isBoldTextEnabled { get; set; }

		public bool isClosedCaptioningEnabled { get; set; }

		public AccessibilityNotificationContext nativeContext { get; set; }

		public NotificationContext(ref AccessibilityNotificationContext nativeNotification)
		{
			nativeContext = nativeNotification;
			notification = nativeNotification.notification;
			isScreenReaderEnabled = nativeNotification.isScreenReaderEnabled;
			announcement = nativeNotification.announcement;
			wasAnnouncementSuccessful = nativeNotification.wasAnnouncementSuccessful;
			AccessibilityNode node = null;
			AssistiveSupport.activeHierarchy?.TryGetNode(nativeNotification.currentNodeId, out node);
			currentNode = node;
			AssistiveSupport.activeHierarchy?.TryGetNode(nativeNotification.nextNodeId, out node);
			nextNode = node;
			fontScale = 1f;
			isBoldTextEnabled = false;
			isClosedCaptioningEnabled = false;
		}
	}

	private sealed class ExclusiveLock : IDisposable
	{
		private bool m_Disposed;

		public ExclusiveLock()
		{
			Lock();
		}

		~ExclusiveLock()
		{
			InternalDispose();
		}

		private void InternalDispose()
		{
			if (!m_Disposed)
			{
				Unlock();
				m_Disposed = true;
			}
		}

		public void Dispose()
		{
			InternalDispose();
			GC.SuppressFinalize(this);
		}
	}

	internal static Queue<NotificationContext> asyncNotificationContexts = new Queue<NotificationContext>();

	public static bool isSupportedPlatform
	{
		get
		{
			RuntimePlatform platform = Application.platform;
			return platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer;
		}
	}

	public static event Action<bool> screenReaderStatusChanged;

	public static event Action<AccessibilityNode> nodeFocusChanged;

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool IsScreenReaderEnabled();

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SendAccessibilityNotification(in AccessibilityNotificationContext context);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern SystemLanguage GetApplicationAccessibilityLanguage();

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetApplicationAccessibilityLanguage(SystemLanguage languageCode);

	[RequiredByNativeCode]
	[VisibleToOtherModules(new string[] { "UnityEditor.AccessibilityModule" })]
	internal static void Internal_Initialize()
	{
		AssistiveSupport.Initialize();
	}

	[RequiredByNativeCode]
	private static void Internal_Update()
	{
		if (asyncNotificationContexts.Count == 0)
		{
			return;
		}
		NotificationContext[] array;
		lock (asyncNotificationContexts)
		{
			if (asyncNotificationContexts.Count == 0)
			{
				return;
			}
			array = asyncNotificationContexts.ToArray();
			asyncNotificationContexts.Clear();
		}
		using (GetExclusiveLock())
		{
			NotificationContext[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				NotificationContext notificationContext = array2[i];
				switch (notificationContext.notification)
				{
				case AccessibilityNotification.ScreenReaderStatusChanged:
					AccessibilityManager.screenReaderStatusChanged?.Invoke(notificationContext.isScreenReaderEnabled);
					break;
				case AccessibilityNotification.ElementFocused:
					notificationContext.currentNode.InvokeFocusChanged(isNodeFocused: true);
					AccessibilityManager.nodeFocusChanged?.Invoke(notificationContext.currentNode);
					break;
				case AccessibilityNotification.ElementUnfocused:
					notificationContext.currentNode.InvokeFocusChanged(isNodeFocused: false);
					break;
				case AccessibilityNotification.FontScaleChanged:
					AccessibilitySettings.InvokeFontScaleChanged(notificationContext.fontScale);
					break;
				case AccessibilityNotification.BoldTextStatusChanged:
					AccessibilitySettings.InvokeBoldTextStatusChanged(notificationContext.isBoldTextEnabled);
					break;
				case AccessibilityNotification.ClosedCaptioningStatusChanged:
					AccessibilitySettings.InvokeClosedCaptionStatusChanged(notificationContext.isClosedCaptioningEnabled);
					break;
				}
			}
		}
	}

	[RequiredByNativeCode]
	internal static int[] Internal_GetRootNodeIds()
	{
		List<AccessibilityNode> list = AssistiveSupport.GetService<AccessibilityHierarchyService>()?.GetRootNodes();
		if (list == null || list.Count == 0)
		{
			return null;
		}
		List<int> value;
		using (CollectionPool<List<int>, int>.Get(out value))
		{
			for (int i = 0; i < list.Count; i++)
			{
				value.Add(list[i].id);
			}
			return (value.Count == 0) ? null : value.ToArray();
		}
	}

	[RequiredByNativeCode]
	internal static bool Internal_GetNode(int id, ref AccessibilityNodeData nodeData)
	{
		AccessibilityHierarchyService service = AssistiveSupport.GetService<AccessibilityHierarchyService>();
		if (service == null)
		{
			return false;
		}
		if (service.TryGetNode(id, out var node))
		{
			node.GetNodeData(ref nodeData);
			return true;
		}
		return false;
	}

	[RequiredByNativeCode]
	internal static int Internal_GetNodeIdAt(float x, float y)
	{
		AccessibilityHierarchyService service = AssistiveSupport.GetService<AccessibilityHierarchyService>();
		AccessibilityNode node;
		return (service != null && service.TryGetNodeAt(x, y, out node)) ? node.id : (-1);
	}

	[RequiredByNativeCode]
	internal static void Internal_OnAccessibilityNotificationReceived(ref AccessibilityNotificationContext context)
	{
		if (context.notification != AccessibilityNotification.ElementFocused)
		{
			QueueNotification(new NotificationContext(ref context));
		}
	}

	internal static void QueueNotification(NotificationContext notification)
	{
		lock (asyncNotificationContexts)
		{
			asyncNotificationContexts.Enqueue(notification);
		}
	}

	internal static IDisposable GetExclusiveLock()
	{
		return new ExclusiveLock();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[ThreadSafe]
	private static extern void Lock();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[ThreadSafe]
	private static extern void Unlock();
}
[NativeHeader("Modules/Accessibility/Native/AccessibilityNodeData.h")]
[Flags]
public enum AccessibilityRole : ushort
{
	None = 0,
	Button = 1,
	Image = 2,
	StaticText = 4,
	SearchField = 8,
	KeyboardKey = 0x10,
	Header = 0x20,
	TabBar = 0x40,
	Slider = 0x80,
	Toggle = 0x100
}
[NativeHeader("Modules/Accessibility/Native/AccessibilityNodeData.h")]
[Flags]
public enum AccessibilityState : ushort
{
	None = 0,
	Disabled = 1,
	Selected = 2
}
[RequiredByNativeCode]
[NativeType(CodegenOptions.Custom, "MonoAccessibilityNodeData")]
[NativeHeader("Modules/Accessibility/Bindings/AccessibilityNodeData.bindings.h")]
[NativeHeader("Modules/Accessibility/Native/AccessibilityNodeData.h")]
internal struct AccessibilityNodeData
{
	public int id { get; set; }

	public bool isActive { get; set; }

	public string label { get; set; }

	public string value { get; set; }

	public string hint { get; set; }

	public AccessibilityRole role { get; set; }

	public bool allowsDirectInteraction { get; set; }

	public AccessibilityState state { get; set; }

	public Rect frame { get; set; }

	public int parentId { get; set; }

	public int[] childIds { get; set; }

	public bool isFocused { get; }

	internal SystemLanguage language { get; set; }

	public bool implementsSelected { get; set; }

	public bool implementsDismissed { get; set; }
}
[NativeHeader("Modules/Accessibility/Native/AccessibilityNodeManager.h")]
internal static class AccessibilityNodeManager
{
	internal const int k_InvalidNodeId = -1;

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool CreateNativeNode(int id);

	internal static bool CreateNativeNodeWithData(AccessibilityNodeData nodeData)
	{
		return CreateNativeNodeWithData_Injected(ref nodeData);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void DestroyNativeNode(int id, int parentId);

	internal static void SetNodeData(int id, AccessibilityNodeData nodeData)
	{
		SetNodeData_Injected(id, ref nodeData);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetIsActive(int id, bool isActive);

	internal unsafe static void SetLabel(int id, string label)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(label, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(label);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					SetLabel_Injected(id, ref managedSpanWrapper);
					return;
				}
			}
			SetLabel_Injected(id, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	internal unsafe static void SetValue(int id, string value)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					SetValue_Injected(id, ref managedSpanWrapper);
					return;
				}
			}
			SetValue_Injected(id, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	internal unsafe static void SetHint(int id, string hint)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(hint, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(hint);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					SetHint_Injected(id, ref managedSpanWrapper);
					return;
				}
			}
			SetHint_Injected(id, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetRole(int id, AccessibilityRole role);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetAllowsDirectInteraction(int id, bool allows);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetState(int id, AccessibilityState state);

	internal static void SetFrame(int id, Rect frame)
	{
		SetFrame_Injected(id, ref frame);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetParent(int id, int parentId, int index = -1);

	internal unsafe static void SetChildren(int id, int[] childIds)
	{
		Span<int> span = new Span<int>(childIds);
		fixed (int* begin = span)
		{
			ManagedSpanWrapper childIds2 = new ManagedSpanWrapper(begin, span.Length);
			SetChildren_Injected(id, ref childIds2);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool GetIsFocused(int id);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetActions(int id, AccessibilityAction[] actions);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void SetLanguage(int id, SystemLanguage language);

	[RequiredByNativeCode]
	internal static void Internal_InvokeFocusChanged(int id, bool isNodeFocused)
	{
		AccessibilityHierarchyService service = AssistiveSupport.GetService<AccessibilityHierarchyService>();
		if (service != null && service.TryGetNode(id, out var node))
		{
			node.NotifyFocusChanged(isNodeFocused);
		}
	}

	[RequiredByNativeCode]
	internal static bool Internal_InvokeSelected(int id)
	{
		AccessibilityHierarchyService service = AssistiveSupport.GetService<AccessibilityHierarchyService>();
		if (service == null)
		{
			return false;
		}
		if (service.TryGetNode(id, out var node))
		{
			return node.InvokeSelected();
		}
		return false;
	}

	[RequiredByNativeCode]
	internal static void Internal_InvokeIncremented(int id)
	{
		AccessibilityHierarchyService service = AssistiveSupport.GetService<AccessibilityHierarchyService>();
		if (service != null && service.TryGetNode(id, out var node))
		{
			node.InvokeIncremented();
		}
	}

	[RequiredByNativeCode]
	internal static void Internal_InvokeDecremented(int id)
	{
		AccessibilityHierarchyService service = AssistiveSupport.GetService<AccessibilityHierarchyService>();
		if (service != null && service.TryGetNode(id, out var node))
		{
			node.InvokeDecremented();
		}
	}

	[RequiredByNativeCode]
	internal static bool Internal_InvokeDismissed(int id)
	{
		AccessibilityHierarchyService service = AssistiveSupport.GetService<AccessibilityHierarchyService>();
		if (service == null)
		{
			return false;
		}
		if (service.TryGetNode(id, out var node))
		{
			return node.Dismissed();
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool CreateNativeNodeWithData_Injected([In] ref AccessibilityNodeData nodeData);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetNodeData_Injected(int id, [In] ref AccessibilityNodeData nodeData);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetLabel_Injected(int id, ref ManagedSpanWrapper label);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetValue_Injected(int id, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetHint_Injected(int id, ref ManagedSpanWrapper hint);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetFrame_Injected(int id, [In] ref Rect frame);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetChildren_Injected(int id, ref ManagedSpanWrapper childIds);
}
[NativeHeader("Modules/Accessibility/Native/AccessibilityNotificationContext.h")]
internal enum AccessibilityNotification
{
	None,
	Announcement,
	AnnouncementFinished,
	ScreenReaderStatusChanged,
	ScreenChanged,
	LayoutChanged,
	PageScrolled,
	ElementFocused,
	ElementUnfocused,
	FontScaleChanged,
	BoldTextStatusChanged,
	ClosedCaptioningStatusChanged
}
[RequiredByNativeCode]
[NativeType(CodegenOptions.Custom, "MonoAccessibilityNotificationContext")]
[NativeHeader("Modules/Accessibility/Native/AccessibilityNotificationContext.h")]
[NativeHeader("Modules/Accessibility/Bindings/AccessibilityNotificationContext.bindings.h")]
internal struct AccessibilityNotificationContext
{
	public AccessibilityNotification notification { get; set; }

	public bool isScreenReaderEnabled { get; }

	public string announcement { get; set; }

	public bool wasAnnouncementSuccessful { get; }

	public int currentNodeId { get; }

	public int nextNodeId { get; set; }
}
[NativeHeader("Modules/Accessibility/Native/AccessibilitySettings.h")]
public static class AccessibilitySettings
{
	public static float fontScale => GetFontScale();

	public static bool isBoldTextEnabled => IsBoldTextEnabled();

	public static bool isClosedCaptioningEnabled => IsClosedCaptioningEnabled();

	public static event Action<float> fontScaleChanged;

	public static event Action<bool> boldTextStatusChanged;

	public static event Action<bool> closedCaptioningStatusChanged;

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetFontScale();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsBoldTextEnabled();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsClosedCaptioningEnabled();

	[RequiredByNativeCode]
	private static void Internal_OnFontScaleChanged(float newFontScale)
	{
		AccessibilityManager.QueueNotification(new AccessibilityManager.NotificationContext
		{
			notification = AccessibilityNotification.FontScaleChanged,
			fontScale = newFontScale
		});
	}

	[RequiredByNativeCode]
	private static void Internal_OnBoldTextStatusChanged(bool enabled)
	{
		AccessibilityManager.QueueNotification(new AccessibilityManager.NotificationContext
		{
			notification = AccessibilityNotification.BoldTextStatusChanged,
			isBoldTextEnabled = enabled
		});
	}

	[RequiredByNativeCode]
	private static void Internal_OnClosedCaptioningStatusChanged(bool enabled)
	{
		AccessibilityManager.QueueNotification(new AccessibilityManager.NotificationContext
		{
			notification = AccessibilityNotification.ClosedCaptioningStatusChanged,
			isClosedCaptioningEnabled = enabled
		});
	}

	internal static void InvokeFontScaleChanged(float newFontScale)
	{
		AccessibilitySettings.fontScaleChanged?.Invoke(newFontScale);
	}

	internal static void InvokeBoldTextStatusChanged(bool enabled)
	{
		AccessibilitySettings.boldTextStatusChanged?.Invoke(enabled);
	}

	internal static void InvokeClosedCaptionStatusChanged(bool enabled)
	{
		AccessibilitySettings.closedCaptioningStatusChanged?.Invoke(enabled);
	}
}
public static class AssistiveSupport
{
	internal class NotificationDispatcher : IAccessibilityNotificationDispatcher
	{
		private static void Send(in AccessibilityNotificationContext context)
		{
			AccessibilityManager.SendAccessibilityNotification(in context);
		}

		public void SendAnnouncement(string announcement)
		{
			AccessibilityNotificationContext context = new AccessibilityNotificationContext
			{
				notification = AccessibilityNotification.Announcement,
				announcement = announcement
			};
			Send(in context);
		}

		public void SendPageScrolledAnnouncement(string announcement)
		{
			AccessibilityNotificationContext context = new AccessibilityNotificationContext
			{
				notification = AccessibilityNotification.PageScrolled,
				announcement = announcement
			};
			Send(in context);
		}

		public void SendScreenChanged(AccessibilityNode nodeToFocus = null)
		{
			AccessibilityNotificationContext context = new AccessibilityNotificationContext
			{
				notification = AccessibilityNotification.ScreenChanged,
				nextNodeId = (nodeToFocus?.id ?? (-1))
			};
			Send(in context);
		}

		public void SendLayoutChanged(AccessibilityNode nodeToFocus = null)
		{
			AccessibilityNotificationContext context = new AccessibilityNotificationContext
			{
				notification = AccessibilityNotification.LayoutChanged,
				nextNodeId = (nodeToFocus?.id ?? (-1))
			};
			Send(in context);
		}
	}

	private static ServiceManager s_ServiceManager;

	public static bool isScreenReaderEnabled { get; private set; }

	public static IAccessibilityNotificationDispatcher notificationDispatcher { get; } = new NotificationDispatcher();

	public static AccessibilityHierarchy activeHierarchy
	{
		get
		{
			return GetService<AccessibilityHierarchyService>()?.hierarchy;
		}
		set
		{
			CheckPlatformSupported();
			using (AccessibilityManager.GetExclusiveLock())
			{
				AccessibilityHierarchyService service = GetService<AccessibilityHierarchyService>();
				if (service != null)
				{
					service.hierarchy = value;
					AssistiveSupport.s_ActiveHierarchyChanged?.Invoke(value);
				}
			}
		}
	}

	public static event Action<AccessibilityNode> nodeFocusChanged;

	public static event Action<bool> screenReaderStatusChanged;

	private static event Action<AccessibilityHierarchy> s_ActiveHierarchyChanged;

	internal static event Action<AccessibilityHierarchy> activeHierarchyChanged
	{
		[VisibleToOtherModules(new string[] { "UnityEditor.AccessibilityModule" })]
		add
		{
			s_ActiveHierarchyChanged += value;
		}
		[VisibleToOtherModules(new string[] { "UnityEditor.AccessibilityModule" })]
		remove
		{
			s_ActiveHierarchyChanged -= value;
		}
	}

	internal static void Initialize()
	{
		isScreenReaderEnabled = AccessibilityManager.IsScreenReaderEnabled();
		AccessibilityManager.screenReaderStatusChanged += ScreenReaderStatusChanged;
		AccessibilityManager.nodeFocusChanged += NodeFocusChanged;
		s_ServiceManager = new ServiceManager();
	}

	internal static T GetService<T>() where T : IService
	{
		if (s_ServiceManager == null)
		{
			return default(T);
		}
		return s_ServiceManager.GetService<T>();
	}

	internal static bool IsServiceRunning<T>() where T : IService
	{
		IService service = GetService<T>();
		return service != null;
	}

	internal static void SetApplicationAccessibilityLanguage(SystemLanguage language)
	{
		AccessibilityManager.SetApplicationAccessibilityLanguage(language);
	}

	private static void ScreenReaderStatusChanged(bool screenReaderEnabled)
	{
		if (isScreenReaderEnabled != screenReaderEnabled)
		{
			isScreenReaderEnabled = screenReaderEnabled;
			AssistiveSupport.screenReaderStatusChanged?.Invoke(isScreenReaderEnabled);
		}
	}

	private static void NodeFocusChanged(AccessibilityNode currentNode)
	{
		AssistiveSupport.nodeFocusChanged?.Invoke(currentNode);
	}

	internal static void OnHierarchyNodeFramesRefreshed(AccessibilityHierarchy hierarchy)
	{
		if (activeHierarchy == hierarchy)
		{
			notificationDispatcher.SendLayoutChanged();
		}
	}

	private static void CheckPlatformSupported()
	{
		if (!Application.isEditor && !AccessibilityManager.isSupportedPlatform)
		{
			throw new PlatformNotSupportedException($"This API is not supported for platform {Application.platform}");
		}
	}
}
public class AccessibilityHierarchy
{
	internal List<AccessibilityNode> m_RootNodes;

	private Stack<AccessibilityNode> m_FirstLowestCommonAncestorChain;

	private Stack<AccessibilityNode> m_SecondLowestCommonAncestorChain;

	private static int m_NextUniqueNodeId;

	private readonly IDictionary<int, AccessibilityNode> m_Nodes;

	public IReadOnlyList<AccessibilityNode> rootNodes => m_RootNodes;

	private event Action<AccessibilityHierarchy> m_Changed;

	internal event Action<AccessibilityHierarchy> changed
	{
		[VisibleToOtherModules(new string[] { "UnityEditor.AccessibilityModule" })]
		add
		{
			m_Changed += value;
		}
		[VisibleToOtherModules(new string[] { "UnityEditor.AccessibilityModule" })]
		remove
		{
			m_Changed -= value;
		}
	}

	public AccessibilityHierarchy()
	{
		m_FirstLowestCommonAncestorChain = new Stack<AccessibilityNode>();
		m_SecondLowestCommonAncestorChain = new Stack<AccessibilityNode>();
		m_Nodes = new Dictionary<int, AccessibilityNode>();
		m_RootNodes = new List<AccessibilityNode>();
	}

	internal void NotifyHierarchyChanged()
	{
		this.m_Changed?.Invoke(this);
	}

	public void Clear()
	{
		for (int num = m_RootNodes.Count - 1; num >= 0; num--)
		{
			RemoveNode(m_RootNodes[num]);
		}
	}

	public bool TryGetNode(int id, out AccessibilityNode node)
	{
		return m_Nodes.TryGetValue(id, out node);
	}

	public AccessibilityNode AddNode(string label = null, AccessibilityNode parent = null)
	{
		return InsertNode(-1, label, parent);
	}

	public AccessibilityNode InsertNode(int childIndex, string label = null, AccessibilityNode parent = null)
	{
		if (parent != null)
		{
			ValidateNodeInHierarchy(parent);
		}
		AccessibilityNode accessibilityNode = GenerateNewNode();
		m_Nodes[accessibilityNode.id] = accessibilityNode;
		if (label != null)
		{
			accessibilityNode.label = label;
		}
		IList<AccessibilityNode> newParentChildren;
		if (parent != null)
		{
			newParentChildren = parent.childList;
		}
		else
		{
			IList<AccessibilityNode> list = m_RootNodes;
			newParentChildren = list;
		}
		SetParent(accessibilityNode, parent, null, newParentChildren, childIndex);
		NotifyHierarchyChanged();
		return accessibilityNode;
	}

	public bool MoveNode(AccessibilityNode node, AccessibilityNode newParent, int newChildIndex = -1)
	{
		ValidateNodeInHierarchy(node);
		if (node == newParent)
		{
			throw new ArgumentException($"Attempting to move the node {node} under itself.");
		}
		if (node.parent == newParent)
		{
			IList<AccessibilityNode> list;
			if (newParent != null)
			{
				list = newParent.childList;
			}
			else
			{
				IList<AccessibilityNode> list2 = m_RootNodes;
				list = list2;
			}
			IList<AccessibilityNode> list3 = list;
			if (newChildIndex == list3.IndexOf(node))
			{
				return false;
			}
			CheckForLoopsAndSetParent(node, newParent, newChildIndex);
			return true;
		}
		if (newParent == null)
		{
			if (node.parent == null)
			{
				return false;
			}
			CheckForLoopsAndSetParent(node, null, newChildIndex);
			return true;
		}
		ValidateNodeInHierarchy(newParent);
		CheckForLoopsAndSetParent(node, newParent, newChildIndex);
		NotifyHierarchyChanged();
		return true;
	}

	public void RemoveNode(AccessibilityNode node, bool removeChildren = true)
	{
		ValidateNodeInHierarchy(node);
		if (removeChildren)
		{
			removeFromNodes(node);
		}
		else
		{
			m_Nodes.Remove(node.id);
		}
		if (m_RootNodes.Contains(node))
		{
			m_RootNodes.Remove(node);
			if (!removeChildren)
			{
				m_RootNodes.AddRange(node.childList);
			}
		}
		node.Destroy(removeChildren);
		NotifyHierarchyChanged();
		void removeFromNodes(AccessibilityNode child)
		{
			m_Nodes.Remove(child.id);
			for (int i = 0; i < child.childList.Count; i++)
			{
				removeFromNodes(child.childList[i]);
			}
		}
	}

	public bool ContainsNode(AccessibilityNode node)
	{
		return node != null && m_Nodes.ContainsKey(node.id) && m_Nodes[node.id] == node;
	}

	private void CheckForLoopsAndSetParent(AccessibilityNode node, AccessibilityNode parent, int newChildIndex = -1)
	{
		if (parent == null)
		{
			SetParent(node, null, node.parent?.childList ?? m_RootNodes, m_RootNodes, newChildIndex);
			return;
		}
		if (node.parent == parent)
		{
			SetParent(node, parent, parent.childList, parent.childList, newChildIndex);
			return;
		}
		if (node.parent == null && parent.parent == null)
		{
			SetParent(node, parent, m_RootNodes, parent.childList, newChildIndex);
			return;
		}
		for (AccessibilityNode parent2 = parent.parent; parent2 != null; parent2 = parent2.parent)
		{
			if (parent2 == node)
			{
				throw new ArgumentException($"Trying to set the node {node} to have parent {parent}, but this would create a loop.");
			}
		}
		SetParent(node, parent, node.parent?.childList ?? m_RootNodes, parent.childList, newChildIndex);
	}

	private void SetParent(AccessibilityNode node, AccessibilityNode parent, IList<AccessibilityNode> previousParentChildren, IList<AccessibilityNode> newParentChildren, int newChildIndex = -1)
	{
		previousParentChildren?.Remove(node);
		node.SetParent(parent, newChildIndex);
		if (newChildIndex < 0 || newChildIndex > newParentChildren.Count)
		{
			newParentChildren.Add(node);
		}
		else
		{
			newParentChildren.Insert(newChildIndex, node);
		}
	}

	internal void AllocateNative()
	{
		foreach (AccessibilityNode rootNode in m_RootNodes)
		{
			rootNode.AllocateNative();
		}
	}

	internal void FreeNative()
	{
		foreach (AccessibilityNode rootNode in m_RootNodes)
		{
			rootNode.FreeNative(freeChildren: true);
		}
	}

	public void RefreshNodeFrames()
	{
		foreach (AccessibilityNode value in m_Nodes.Values)
		{
			value.CalculateFrame();
		}
		AssistiveSupport.OnHierarchyNodeFramesRefreshed(this);
	}

	public bool TryGetNodeAt(float horizontalPosition, float verticalPosition, out AccessibilityNode node)
	{
		node = FindNodeContainingPoint(pos: new Vector2(horizontalPosition, verticalPosition), nodes: m_RootNodes);
		return node != null;
		static AccessibilityNode FindNodeContainingPoint(IList<AccessibilityNode> nodes, Vector2 pos)
		{
			for (int num = nodes.Count - 1; num >= 0; num--)
			{
				AccessibilityNode accessibilityNode = nodes[num];
				AccessibilityNode accessibilityNode2 = FindNodeContainingPoint(accessibilityNode.childList, pos);
				if (accessibilityNode2 != null)
				{
					return accessibilityNode2;
				}
				if (accessibilityNode.isActive && accessibilityNode.frame.Contains(pos))
				{
					return accessibilityNode;
				}
			}
			return null;
		}
	}

	public AccessibilityNode GetLowestCommonAncestor(AccessibilityNode firstNode, AccessibilityNode secondNode)
	{
		if (firstNode == null || secondNode == null)
		{
			return null;
		}
		if (firstNode.parent == null && secondNode.parent == null)
		{
			return null;
		}
		if (!ContainsNode(firstNode) || !ContainsNode(secondNode))
		{
			return null;
		}
		m_FirstLowestCommonAncestorChain.Clear();
		m_SecondLowestCommonAncestorChain.Clear();
		buildNodeIdStack(firstNode, ref m_FirstLowestCommonAncestorChain);
		buildNodeIdStack(secondNode, ref m_SecondLowestCommonAncestorChain);
		AccessibilityNode result = null;
		for (int num = Mathf.Min(m_FirstLowestCommonAncestorChain.Count, m_SecondLowestCommonAncestorChain.Count); num > 0; num--)
		{
			AccessibilityNode accessibilityNode = m_FirstLowestCommonAncestorChain.Pop();
			AccessibilityNode accessibilityNode2 = m_SecondLowestCommonAncestorChain.Pop();
			if (accessibilityNode != accessibilityNode2)
			{
				break;
			}
			result = accessibilityNode;
		}
		return result;
		void buildNodeIdStack(AccessibilityNode node, ref Stack<AccessibilityNode> nodeStack)
		{
			while (node != null)
			{
				nodeStack.Push(node);
				node = m_Nodes[node.id].parent;
			}
		}
	}

	internal AccessibilityNode GenerateNewNode()
	{
		if (m_NextUniqueNodeId >= int.MaxValue)
		{
			throw new Exception($"Could not generate unique node for hierarchy. A hierarchy may only have up to {int.MaxValue} nodes.");
		}
		AccessibilityNode accessibilityNode = new AccessibilityNode(m_NextUniqueNodeId, this);
		m_NextUniqueNodeId = accessibilityNode.id + 1;
		return accessibilityNode;
	}

	private void ValidateNodeInHierarchy(AccessibilityNode node)
	{
		if (node != null)
		{
			if (ContainsNode(node))
			{
				return;
			}
			throw new ArgumentException($"Trying to use an AccessibilityNode with ID {node.id} that is not part of this hierarchy.");
		}
		throw new ArgumentNullException("node");
	}
}
public class AccessibilityNode
{
	private class ObservableList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>, IList, ICollection
	{
		private readonly List<T> m_Items;

		public int Count => m_Items.Count;

		public bool IsSynchronized => ((ICollection)m_Items)?.IsSynchronized ?? false;

		public object SyncRoot => ((ICollection)m_Items)?.SyncRoot ?? ((object)false);

		public bool IsReadOnly => ((IList)m_Items)?.IsReadOnly ?? false;

		object IList.this[int index]
		{
			get
			{
				return m_Items[index];
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public bool IsFixedSize { get; }

		public T this[int index]
		{
			get
			{
				return m_Items[index];
			}
			set
			{
				m_Items[index] = value;
			}
		}

		public event Action listChanged;

		public ObservableList()
		{
			m_Items = new List<T>();
		}

		public ObservableList(IEnumerable<T> enumerable)
		{
			m_Items = new List<T>(enumerable);
		}

		public void CopyTo(Array array, int index)
		{
			((ICollection)m_Items)?.CopyTo(array, index);
		}

		public void Add(T item)
		{
			m_Items.Add(item);
			this.listChanged?.Invoke();
		}

		public void Insert(int index, T item)
		{
			m_Items.Insert(index, item);
			this.listChanged?.Invoke();
		}

		public void Remove(T item)
		{
			m_Items.Remove(item);
			this.listChanged?.Invoke();
		}

		bool ICollection<T>.Remove(T item)
		{
			bool flag = m_Items.Remove(item);
			if (flag)
			{
				this.listChanged?.Invoke();
			}
			return flag;
		}

		public void Remove(object value)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			m_Items.RemoveAt(index);
			this.listChanged?.Invoke();
		}

		public int Add(object value)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			m_Items.Clear();
			this.listChanged?.Invoke();
		}

		public bool Contains(object value)
		{
			throw new NotImplementedException();
		}

		public int IndexOf(object value)
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, object value)
		{
			throw new NotImplementedException();
		}

		public int IndexOf(T item)
		{
			return m_Items.IndexOf(item);
		}

		public bool Contains(T item)
		{
			return m_Items.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			m_Items.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return m_Items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return m_Items.GetEnumerator();
		}
	}

	private Func<Rect> m_FrameGetter;

	private string m_Label;

	private string m_Value;

	private string m_Hint;

	private bool m_IsActive = true;

	private AccessibilityRole m_Role;

	private bool m_AllowsDirectInteraction;

	private AccessibilityState m_State;

	private AccessibilityNode m_Parent;

	private ObservableList<AccessibilityNode> m_Children;

	private ObservableList<AccessibilityAction> m_Actions;

	private Rect m_Frame;

	private SystemLanguage m_Language = SystemLanguage.Unknown;

	private AccessibilityHierarchy m_Hierarchy;

	public int id { get; private set; }

	public string label
	{
		get
		{
			return m_Label;
		}
		set
		{
			if (!string.Equals(m_Label, value))
			{
				m_Label = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetLabel(id, value);
				}
			}
		}
	}

	public string value
	{
		get
		{
			return m_Value;
		}
		set
		{
			if (!string.Equals(m_Value, value))
			{
				m_Value = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetValue(id, value);
				}
			}
		}
	}

	public string hint
	{
		get
		{
			return m_Hint;
		}
		set
		{
			if (!string.Equals(m_Hint, value))
			{
				m_Hint = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetHint(id, value);
				}
			}
		}
	}

	public bool isActive
	{
		get
		{
			return m_IsActive;
		}
		set
		{
			if (m_IsActive != value)
			{
				m_IsActive = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetIsActive(id, value);
				}
			}
		}
	}

	public AccessibilityRole role
	{
		get
		{
			return m_Role;
		}
		set
		{
			if (m_Role != value)
			{
				m_Role = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetRole(id, value);
				}
			}
		}
	}

	public bool allowsDirectInteraction
	{
		get
		{
			return m_AllowsDirectInteraction;
		}
		set
		{
			if (value && !Application.isEditor && Application.platform != RuntimePlatform.IPhonePlayer)
			{
				throw new PlatformNotSupportedException("allowsDirectInteraction is only supported on iOS.");
			}
			if (m_AllowsDirectInteraction != value)
			{
				m_AllowsDirectInteraction = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetAllowsDirectInteraction(id, value);
				}
			}
		}
	}

	public AccessibilityState state
	{
		get
		{
			return m_State;
		}
		set
		{
			if (m_State != value)
			{
				m_State = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetState(id, value);
				}
			}
		}
	}

	public AccessibilityNode parent => m_Parent;

	internal IList<AccessibilityNode> childList
	{
		get
		{
			return m_Children;
		}
		set
		{
			if (m_Children != null)
			{
				m_Children.listChanged -= ChildrenChanged;
			}
			m_Children = new ObservableList<AccessibilityNode>(value);
			ChildrenChanged();
			m_Children.listChanged += ChildrenChanged;
		}
	}

	public IReadOnlyList<AccessibilityNode> children => m_Children;

	internal IList<AccessibilityAction> actions
	{
		get
		{
			return m_Actions;
		}
		set
		{
			if (m_Actions != null)
			{
				m_Actions.listChanged -= ActionsChanged;
			}
			m_Actions = new ObservableList<AccessibilityAction>(value);
			ActionsChanged();
			m_Actions.listChanged += ActionsChanged;
		}
	}

	public Rect frame
	{
		get
		{
			if (m_Frame == default(Rect))
			{
				CalculateFrame();
			}
			return m_Frame;
		}
		set
		{
			SetFrame(value);
		}
	}

	public Func<Rect> frameGetter
	{
		get
		{
			return m_FrameGetter;
		}
		set
		{
			if (m_FrameGetter != value)
			{
				m_FrameGetter = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetFrame(id, frame);
				}
			}
		}
	}

	internal SystemLanguage language
	{
		get
		{
			return m_Language;
		}
		set
		{
			if (m_Language != value)
			{
				m_Language = value;
				if (IsInActiveHierarchy())
				{
					AccessibilityNodeManager.SetLanguage(id, value);
				}
			}
		}
	}

	public bool isFocused => IsInActiveHierarchy() && AccessibilityNodeManager.GetIsFocused(id);

	public event Action<AccessibilityNode, bool> focusChanged;

	public event Func<bool> selected;

	public event Action incremented;

	public event Action decremented;

	public event Func<bool> dismissed;

	internal AccessibilityNode(int id, AccessibilityHierarchy hierarchy)
	{
		this.id = id;
		m_Hierarchy = hierarchy;
		m_Children = new ObservableList<AccessibilityNode>();
		m_Actions = new ObservableList<AccessibilityAction>();
		if (IsInActiveHierarchy())
		{
			AccessibilityNodeData nodeData = new AccessibilityNodeData
			{
				id = id,
				isActive = isActive,
				parentId = -1
			};
			CreateNativeNodeWithData(ref nodeData);
			m_Actions.listChanged += ActionsChanged;
			m_Children.listChanged += ChildrenChanged;
		}
	}

	private void CreateNativeNodeWithData(ref AccessibilityNodeData nodeData)
	{
		if (AccessibilityManager.isSupportedPlatform)
		{
			while (!AccessibilityNodeManager.CreateNativeNodeWithData(nodeData))
			{
				Debug.LogWarning($"AccessibilityNode.CreateNativeNodeWithData: id '{nodeData.id}' is already used");
				nodeData.id++;
			}
		}
		id = nodeData.id;
	}

	internal void AllocateNative()
	{
		if (!IsInActiveHierarchy())
		{
			return;
		}
		AccessibilityNodeData nodeData = new AccessibilityNodeData
		{
			id = id,
			label = label,
			value = value,
			hint = hint,
			isActive = isActive,
			role = role,
			allowsDirectInteraction = allowsDirectInteraction,
			state = state,
			parentId = (parent?.id ?? (-1)),
			frame = frame,
			language = language,
			implementsSelected = (this.selected != null),
			implementsDismissed = (this.dismissed != null)
		};
		CreateNativeNodeWithData(ref nodeData);
		ActionsChanged();
		m_Actions.listChanged += ActionsChanged;
		foreach (AccessibilityNode child in m_Children)
		{
			child.AllocateNative();
		}
		ChildrenChanged();
		m_Children.listChanged += ChildrenChanged;
	}

	internal void FreeNative(bool freeChildren)
	{
		if (freeChildren)
		{
			foreach (AccessibilityNode child in m_Children)
			{
				child.FreeNative(freeChildren: true);
			}
		}
		m_Children.listChanged -= ChildrenChanged;
		m_Actions.listChanged -= ActionsChanged;
		if (IsInActiveHierarchy())
		{
			int parentId = parent?.id ?? (-1);
			AccessibilityNodeManager.DestroyNativeNode(id, parentId);
		}
	}

	internal void SetParent(AccessibilityNode parent, int index = -1)
	{
		m_Parent = parent;
		if (IsInActiveHierarchy())
		{
			int parentId = parent?.id ?? (-1);
			AccessibilityNodeManager.SetParent(id, parentId, index);
		}
	}

	private void SetFrame(Rect frame)
	{
		if (!(m_Frame == frame))
		{
			m_Frame = frame;
			if (IsInActiveHierarchy())
			{
				AccessibilityNodeManager.SetFrame(id, frame);
			}
		}
	}

	internal void CalculateFrame()
	{
		SetFrame(frameGetter?.Invoke() ?? Rect.zero);
	}

	internal void GetNodeData(ref AccessibilityNodeData nodeData)
	{
		nodeData.id = id;
		nodeData.isActive = isActive;
		nodeData.label = label;
		nodeData.value = value;
		nodeData.hint = hint;
		nodeData.role = role;
		nodeData.allowsDirectInteraction = allowsDirectInteraction;
		nodeData.state = state;
		nodeData.frame = frame;
		nodeData.parentId = parent?.id ?? (-1);
		int[] array = new int[m_Children.Count];
		for (int i = 0; i < m_Children.Count; i++)
		{
			array[i] = m_Children[i].id;
		}
		nodeData.childIds = array;
		nodeData.language = language;
		nodeData.implementsSelected = this.selected != null;
		nodeData.implementsDismissed = this.dismissed != null;
	}

	internal void Destroy(bool destroyChildren)
	{
		FreeNative(destroyChildren);
		parent?.childList.Remove(this);
		if (destroyChildren)
		{
			for (int num = childList.Count - 1; num >= 0; num--)
			{
				childList[num].Destroy(destroyChildren: true);
			}
		}
		else
		{
			foreach (AccessibilityNode child in childList)
			{
				child.SetParent(parent);
				parent?.childList.Add(child);
			}
		}
		childList.Clear();
		m_Hierarchy = null;
	}

	public override int GetHashCode()
	{
		return id;
	}

	public override string ToString()
	{
		return $"AccessibilityNode(ID: {id}, Label: {label})";
	}

	private void ChildrenChanged()
	{
		if (IsInActiveHierarchy())
		{
			int[] array = new int[m_Children.Count];
			for (int i = 0; i < m_Children.Count; i++)
			{
				array[i] = m_Children[i].id;
			}
			AccessibilityNodeManager.SetChildren(id, array);
		}
	}

	private void ActionsChanged()
	{
		if (IsInActiveHierarchy())
		{
			AccessibilityAction[] array = new AccessibilityAction[m_Actions.Count];
			for (int i = 0; i < m_Actions.Count; i++)
			{
				array[i] = m_Actions[i];
			}
			AccessibilityNodeManager.SetActions(id, array);
		}
	}

	private bool IsInActiveHierarchy()
	{
		return m_Hierarchy != null && AssistiveSupport.activeHierarchy == m_Hierarchy;
	}

	internal void NotifyFocusChanged(bool isNodeFocused)
	{
		AccessibilityManager.QueueNotification(new AccessibilityManager.NotificationContext
		{
			notification = (isNodeFocused ? AccessibilityNotification.ElementFocused : AccessibilityNotification.ElementUnfocused),
			currentNode = this
		});
	}

	internal void InvokeFocusChanged(bool isNodeFocused)
	{
		this.focusChanged?.Invoke(this, isNodeFocused);
	}

	internal bool InvokeSelected()
	{
		return this.selected?.Invoke() ?? false;
	}

	internal void InvokeIncremented()
	{
		this.incremented?.Invoke();
	}

	internal void InvokeDecremented()
	{
		this.decremented?.Invoke();
	}

	internal bool Dismissed()
	{
		return this.dismissed?.Invoke() ?? false;
	}
}
public interface IAccessibilityNotificationDispatcher
{
	void SendAnnouncement(string announcement);

	void SendScreenChanged(AccessibilityNode nodeToFocus = null);

	void SendLayoutChanged(AccessibilityNode nodeToFocus = null);
}
internal class AccessibilityHierarchyService : IService
{
	private AccessibilityHierarchy m_Hierarchy;

	internal AccessibilityHierarchy hierarchy
	{
		get
		{
			return m_Hierarchy;
		}
		set
		{
			if (value == null)
			{
				RemoveActiveHierarchy(notifyScreenChanged: true);
				return;
			}
			RemoveActiveHierarchy(notifyScreenChanged: false);
			m_Hierarchy = value;
			m_Hierarchy.AllocateNative();
			AssistiveSupport.notificationDispatcher.SendScreenChanged();
		}
	}

	public void Start()
	{
	}

	public void Stop()
	{
		if (m_Hierarchy != null)
		{
			RemoveActiveHierarchy(notifyScreenChanged: true);
		}
	}

	private void RemoveActiveHierarchy(bool notifyScreenChanged)
	{
		if (m_Hierarchy != null)
		{
			m_Hierarchy.FreeNative();
			m_Hierarchy = null;
			if (notifyScreenChanged)
			{
				AssistiveSupport.notificationDispatcher.SendScreenChanged();
			}
		}
	}

	internal bool TryGetNode(int id, out AccessibilityNode node)
	{
		node = null;
		return m_Hierarchy != null && m_Hierarchy.TryGetNode(id, out node);
	}

	internal List<AccessibilityNode> GetRootNodes()
	{
		return m_Hierarchy?.m_RootNodes;
	}

	internal bool TryGetNodeAt(float x, float y, out AccessibilityNode node)
	{
		node = null;
		return m_Hierarchy != null && m_Hierarchy.TryGetNodeAt(x, y, out node);
	}
}
internal interface IService
{
	void Start();

	void Stop();
}
internal class ServiceManager
{
	private readonly IDictionary<Type, IService> m_Services;

	public ServiceManager()
	{
		m_Services = new Dictionary<Type, IService>();
		AccessibilityManager.screenReaderStatusChanged += ScreenReaderStatusChanged;
		UpdateServices(AssistiveSupport.isScreenReaderEnabled);
	}

	public T GetService<T>() where T : IService
	{
		Type typeFromHandle = typeof(T);
		m_Services.TryGetValue(typeFromHandle, out var value);
		return (T)value;
	}

	private void StartService<T>() where T : IService
	{
		T service = GetService<T>();
		if (service == null)
		{
			Type typeFromHandle = typeof(T);
			service = (T)Activator.CreateInstance(typeFromHandle);
			service.Start();
			m_Services.Add(typeFromHandle, service);
		}
	}

	private void StopService<T>() where T : IService
	{
		T service = GetService<T>();
		if (service != null)
		{
			service.Stop();
			m_Services.Remove(typeof(T));
		}
	}

	private void UpdateServices(bool isScreenReaderEnabled)
	{
		if (isScreenReaderEnabled)
		{
			if (!m_Services.ContainsKey(typeof(AccessibilityHierarchyService)))
			{
				AccessibilityHierarchyService accessibilityHierarchyService = new AccessibilityHierarchyService();
				accessibilityHierarchyService.Start();
				m_Services.Add(typeof(AccessibilityHierarchyService), accessibilityHierarchyService);
			}
		}
		else
		{
			StopService<AccessibilityHierarchyService>();
		}
	}

	protected void ScreenReaderStatusChanged(bool isScreenReaderEnabled)
	{
		UpdateServices(isScreenReaderEnabled);
	}
}
[UsedByNativeCode]
public static class VisionUtility
{
	private static readonly Color[] s_ColorBlindSafePalette = new Color[19]
	{
		new Color32(0, 0, 0, byte.MaxValue),
		new Color32(73, 0, 146, byte.MaxValue),
		new Color32(7, 71, 81, byte.MaxValue),
		new Color32(0, 146, 146, byte.MaxValue),
		new Color32(182, 109, byte.MaxValue, byte.MaxValue),
		new Color32(byte.MaxValue, 109, 182, byte.MaxValue),
		new Color32(109, 182, byte.MaxValue, byte.MaxValue),
		new Color32(36, byte.MaxValue, 36, byte.MaxValue),
		new Color32(byte.MaxValue, 182, 219, byte.MaxValue),
		new Color32(182, 219, byte.MaxValue, byte.MaxValue),
		new Color32(byte.MaxValue, byte.MaxValue, 109, byte.MaxValue),
		new Color32(30, 92, 92, byte.MaxValue),
		new Color32(74, 154, 87, byte.MaxValue),
		new Color32(113, 66, 183, byte.MaxValue),
		new Color32(162, 66, 183, byte.MaxValue),
		new Color32(178, 92, 25, byte.MaxValue),
		new Color32(100, 100, 100, byte.MaxValue),
		new Color32(80, 203, 181, byte.MaxValue),
		new Color32(82, 205, 242, byte.MaxValue)
	};

	private static readonly float[] s_ColorBlindSafePaletteLuminanceValues = s_ColorBlindSafePalette.Select((Color c) => ComputePerceivedLuminance(c)).ToArray();

	internal static float ComputePerceivedLuminance(Color color)
	{
		color = color.linear;
		return Mathf.LinearToGammaSpace(0.2126f * color.r + 0.7152f * color.g + 0.0722f * color.b);
	}

	internal static void GetLuminanceValuesForPalette(Color[] palette, ref float[] outLuminanceValues)
	{
		Debug.Assert(palette != null && outLuminanceValues != null, "Passed in arrays can't be null.");
		Debug.Assert(palette.Length == outLuminanceValues.Length, "Passed in arrays need to be of the same length.");
		for (int i = 0; i < palette.Length; i++)
		{
			outLuminanceValues[i] = ComputePerceivedLuminance(palette[i]);
		}
	}

	public unsafe static int GetColorBlindSafePalette(Color[] palette, float minimumLuminance, float maximumLuminance)
	{
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		fixed (Color* palette2 = palette)
		{
			return GetColorBlindSafePaletteInternal(palette2, palette.Length, minimumLuminance, maximumLuminance, useColor32: false);
		}
	}

	internal unsafe static int GetColorBlindSafePalette(Color32[] palette, float minimumLuminance, float maximumLuminance)
	{
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		fixed (Color32* palette2 = palette)
		{
			return GetColorBlindSafePaletteInternal(palette2, palette.Length, minimumLuminance, maximumLuminance, useColor32: true);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static int GetColorBlindSafePaletteInternal(void* palette, int paletteLength, float minimumLuminance, float maximumLuminance, bool useColor32)
	{
		if (palette == null)
		{
			throw new ArgumentNullException("palette");
		}
		Color[] array = (from i in Enumerable.Range(0, s_ColorBlindSafePalette.Length)
			where s_ColorBlindSafePaletteLuminanceValues[i] >= minimumLuminance && s_ColorBlindSafePaletteLuminanceValues[i] <= maximumLuminance
			select s_ColorBlindSafePalette[i]).ToArray();
		int num = Mathf.Min(paletteLength, array.Length);
		if (num > 0)
		{
			for (int num2 = 0; num2 < paletteLength; num2++)
			{
				if (useColor32)
				{
					((Color32*)palette)[num2] = array[num2 % num];
				}
				else
				{
					((Color*)palette)[num2] = array[num2 % num];
				}
			}
		}
		else
		{
			for (int num3 = 0; num3 < paletteLength; num3++)
			{
				if (useColor32)
				{
					((Color32*)palette)[num3] = default(Color32);
				}
				else
				{
					((Color*)palette)[num3] = default(Color);
				}
			}
		}
		return num;
	}
}
