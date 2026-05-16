using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

[assembly: InternalsVisibleTo("Unity.Hierarchy.PerformanceTests")]
[assembly: InternalsVisibleTo("Unity.Hierarchy.Editor.Tests")]
[assembly: InternalsVisibleTo("Unity.Hierarchy.Tests")]
[assembly: InternalsVisibleTo("UnityEditor.HierarchyModule")]
[assembly: InternalsVisibleTo("UnityEngine.HierarchyModule")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("Unity.Entities.Editor.Tests")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
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
	internal sealed class IsUnmanagedAttribute : Attribute
	{
	}
}
namespace Unity.Hierarchy
{
	public readonly struct HierarchyFlattenedNodeChildren
	{
		public struct Enumerator
		{
			private readonly HierarchyFlattenedNodeChildren m_Enumerable;

			private readonly HierarchyFlattened m_HierarchyFlattened;

			private readonly HierarchyNode m_Node;

			private int m_CurrentIndex;

			private int m_ChildrenIndex;

			private int m_ChildrenCount;

			public ref readonly HierarchyNode Current
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					m_Enumerable.ThrowIfVersionChanged();
					return ref HierarchyFlattenedNode.GetNodeByRef(in m_HierarchyFlattened[m_CurrentIndex]);
				}
			}

			internal Enumerator(HierarchyFlattenedNodeChildren enumerable, HierarchyNode node)
			{
				m_Enumerable = enumerable;
				m_HierarchyFlattened = enumerable.m_HierarchyFlattened;
				m_Node = node;
				m_CurrentIndex = -1;
				m_ChildrenIndex = 0;
				m_ChildrenCount = 0;
			}

			public bool MoveNext()
			{
				m_Enumerable.ThrowIfVersionChanged();
				if (m_CurrentIndex == -1)
				{
					int num = m_HierarchyFlattened.IndexOf(in m_Node);
					if (num == -1)
					{
						return false;
					}
					ref readonly HierarchyFlattenedNode reference = ref m_HierarchyFlattened[num];
					if (reference == HierarchyFlattenedNode.Null || reference.ChildrenCount <= 0)
					{
						return false;
					}
					if (num + 1 >= m_HierarchyFlattened.Count)
					{
						return false;
					}
					m_CurrentIndex = num + 1;
					m_ChildrenIndex = 0;
					m_ChildrenCount = reference.ChildrenCount;
					return true;
				}
				ref readonly HierarchyFlattenedNode reference2 = ref m_HierarchyFlattened[m_CurrentIndex];
				if (m_ChildrenIndex + 1 >= m_ChildrenCount || reference2.NextSiblingOffset <= 0)
				{
					return false;
				}
				m_CurrentIndex += reference2.NextSiblingOffset;
				m_ChildrenIndex++;
				return true;
			}
		}

		private readonly HierarchyFlattened m_HierarchyFlattened;

		private readonly HierarchyNode m_Node;

		private readonly int m_Version;

		private readonly int m_Count;

		public int Count
		{
			get
			{
				ThrowIfVersionChanged();
				return m_Count;
			}
		}

		public ref readonly HierarchyFlattenedNode this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (index < 0 || index >= m_Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				ThrowIfVersionChanged();
				return ref m_HierarchyFlattened[index];
			}
		}

		internal HierarchyFlattenedNodeChildren(HierarchyFlattened hierarchyFlattened, in HierarchyNode node)
		{
			if (hierarchyFlattened == null)
			{
				throw new ArgumentNullException("hierarchyFlattened");
			}
			if (node == HierarchyNode.Null)
			{
				throw new ArgumentNullException("node");
			}
			if (!hierarchyFlattened.Contains(in node))
			{
				throw new InvalidOperationException($"node {node.Id}:{node.Version} not found");
			}
			m_HierarchyFlattened = hierarchyFlattened;
			m_Node = node;
			m_Version = hierarchyFlattened.Version;
			m_Count = m_HierarchyFlattened.GetChildrenCount(in m_Node);
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this, m_Node);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ThrowIfVersionChanged()
		{
			if (m_Version != m_HierarchyFlattened.Version)
			{
				throw new InvalidOperationException("HierarchyFlattened was modified.");
			}
		}
	}
	public readonly struct HierarchyNodeChildren
	{
		public struct Enumerator
		{
			private readonly HierarchyNodeChildren m_Enumerable;

			private int m_Index;

			public unsafe ref readonly HierarchyNode Current
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					m_Enumerable.ThrowIfVersionChanged();
					return ref m_Enumerable.m_Ptr[m_Index];
				}
			}

			internal Enumerator(in HierarchyNodeChildren enumerable)
			{
				m_Enumerable = enumerable;
				m_Index = -1;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				return ++m_Index < m_Enumerable.m_Count;
			}
		}

		private const int k_HierarchyNodeChildrenIsAllocBit = int.MinValue;

		private readonly Hierarchy m_Hierarchy;

		private unsafe readonly HierarchyNode* m_Ptr;

		private readonly int m_Version;

		private readonly int m_Count;

		public int Count
		{
			get
			{
				ThrowIfVersionChanged();
				return m_Count;
			}
		}

		public unsafe ref readonly HierarchyNode this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (index < 0 || index >= m_Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				ThrowIfVersionChanged();
				return ref m_Ptr[index];
			}
		}

		internal unsafe HierarchyNodeChildren(Hierarchy hierarchy, IntPtr nodeChildrenPtr)
		{
			if (hierarchy == null)
			{
				throw new ArgumentNullException("hierarchy");
			}
			if (nodeChildrenPtr == IntPtr.Zero)
			{
				throw new ArgumentNullException("nodeChildrenPtr");
			}
			m_Hierarchy = hierarchy;
			m_Version = hierarchy.Version;
			ref HierarchyNodeChildrenAlloc reference = ref *(HierarchyNodeChildrenAlloc*)(void*)nodeChildrenPtr;
			if ((reference.Reserved[0] & int.MinValue) == int.MinValue)
			{
				m_Ptr = reference.Ptr;
				m_Count = reference.Size;
				return;
			}
			m_Ptr = (HierarchyNode*)(void*)nodeChildrenPtr;
			m_Count = 0;
			for (int i = 0; i < 4 && m_Ptr[i] != HierarchyNode.Null; i++)
			{
				m_Count++;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ThrowIfVersionChanged()
		{
			if (m_Version != m_Hierarchy.Version)
			{
				throw new InvalidOperationException("Hierarchy was modified.");
			}
		}
	}
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	internal struct HierarchyNodeChildrenAlloc
	{
		[FieldOffset(0)]
		public unsafe HierarchyNode* Ptr;

		[FieldOffset(8)]
		public int Size;

		[FieldOffset(12)]
		public int Capacity;

		[FieldOffset(16)]
		public int RemovedCount;

		[FieldOffset(20)]
		public unsafe fixed int Reserved[3];
	}
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	internal struct HierarchyNodeChildrenFixed
	{
		public const int Capacity = 4;

		[FieldOffset(0)]
		private HierarchyNode m_Node1;

		[FieldOffset(8)]
		private HierarchyNode m_Node2;

		[FieldOffset(16)]
		private HierarchyNode m_Node3;

		[FieldOffset(24)]
		private HierarchyNode m_Node4;

		public unsafe HierarchyNode* Ptr => (HierarchyNode*)UnsafeUtility.AddressOf(ref m_Node1);
	}
	public struct HierarchyNodeMapUnmanaged<T> : IDisposable where T : unmanaged
	{
		private NativeSparseArray<HierarchyNode, T> m_Values;

		public bool IsCreated
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return m_Values.IsCreated;
			}
		}

		public int Capacity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return m_Values.Capacity;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_Values.Capacity = value;
			}
		}

		public int Count => m_Values.Count;

		public T this[in HierarchyNode node]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return m_Values[in node];
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_Values[in node] = value;
			}
		}

		public HierarchyNodeMapUnmanaged(Allocator allocator)
		{
			m_Values = new NativeSparseArray<HierarchyNode, T>(KeyIndex, KeyEqual, allocator);
		}

		public HierarchyNodeMapUnmanaged(in T initValue, Allocator allocator)
		{
			m_Values = new NativeSparseArray<HierarchyNode, T>(in initValue, KeyIndex, KeyEqual, allocator);
		}

		public void Dispose()
		{
			m_Values.Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Reserve(int capacity)
		{
			m_Values.Reserve(capacity);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ContainsKey(in HierarchyNode node)
		{
			return m_Values.ContainsKey(in node);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(in HierarchyNode node, in T value)
		{
			m_Values.Add(in node, in value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddNoResize(in HierarchyNode node, in T value)
		{
			m_Values.AddNoResize(in node, in value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryAdd(in HierarchyNode node, in T value)
		{
			return m_Values.TryAdd(in node, in value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryAddNoResize(in HierarchyNode node, in T value)
		{
			return m_Values.TryAddNoResize(in node, in value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryGetValue(in HierarchyNode node, out T value)
		{
			return m_Values.TryGetValue(in node, out value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Remove(in HierarchyNode node)
		{
			return m_Values.Remove(in node);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear()
		{
			m_Values.Clear();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int KeyIndex(in HierarchyNode node)
		{
			return node.Id - 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool KeyEqual(in HierarchyNode lhs, in HierarchyNode rhs)
		{
			return lhs.Version == rhs.Version;
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyNodeTypeHandlerBase.h")]
	[NativeHeader("Modules/HierarchyCore/HierarchyNodeTypeHandlerBaseBindings.h")]
	[RequiredByNativeCode(GenerateProxy = true)]
	public abstract class HierarchyNodeTypeHandlerBase : IDisposable
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(HierarchyNodeTypeHandlerBase handler)
			{
				return handler.m_Ptr;
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct ConstructorScope : IDisposable
		{
			[ThreadStatic]
			private static IntPtr m_Ptr;

			[ThreadStatic]
			private static Hierarchy m_Hierarchy;

			[ThreadStatic]
			private static HierarchyCommandList m_CommandList;

			public static IntPtr Ptr
			{
				get
				{
					return m_Ptr;
				}
				private set
				{
					m_Ptr = value;
				}
			}

			public static Hierarchy Hierarchy
			{
				get
				{
					return m_Hierarchy;
				}
				private set
				{
					m_Hierarchy = value;
				}
			}

			public static HierarchyCommandList CommandList
			{
				get
				{
					return m_CommandList;
				}
				private set
				{
					m_CommandList = value;
				}
			}

			public ConstructorScope(IntPtr nativePtr, Hierarchy hierarchy, HierarchyCommandList cmdList)
			{
				Ptr = nativePtr;
				Hierarchy = hierarchy;
				CommandList = cmdList;
			}

			public void Dispose()
			{
				Ptr = IntPtr.Zero;
				Hierarchy = null;
				CommandList = null;
			}
		}

		internal readonly IntPtr m_Ptr;

		private readonly Hierarchy m_Hierarchy;

		private readonly HierarchyCommandList m_CommandList;

		private static readonly Dictionary<Type, int> s_NodeTypes = new Dictionary<Type, int>();

		public Hierarchy Hierarchy => m_Hierarchy;

		protected HierarchyCommandList CommandList => m_CommandList;

		protected HierarchyNodeTypeHandlerBase()
		{
			m_Ptr = ConstructorScope.Ptr;
			m_Hierarchy = ConstructorScope.Hierarchy;
			m_CommandList = ConstructorScope.CommandList;
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.HierarchyModule" })]
		internal HierarchyNodeTypeHandlerBase(IntPtr nativePtr, Hierarchy hierarchy, HierarchyCommandList cmdList)
		{
			m_Ptr = nativePtr;
			m_Hierarchy = hierarchy;
			m_CommandList = cmdList;
		}

		~HierarchyNodeTypeHandlerBase()
		{
			Dispose(disposing: false);
		}

		protected virtual void Initialize()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public HierarchyNodeType GetNodeType()
		{
			return new HierarchyNodeType(GetNodeTypeFromType(GetType()));
		}

		[NativeMethod(IsThreadSafe = true)]
		public virtual string GetNodeTypeName()
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
				GetNodeTypeName_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public virtual HierarchyNodeFlags GetDefaultNodeFlags(in HierarchyNode node, HierarchyNodeFlags defaultFlags = HierarchyNodeFlags.None)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetDefaultNodeFlags_Injected(intPtr, in node, defaultFlags);
		}

		[FreeFunction("HierarchyNodeTypeHandlerBaseBindings::SearchBegin", HasExplicitThis = true, IsThreadSafe = true)]
		protected virtual void SearchBegin(HierarchySearchQueryDescriptor query)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SearchBegin_Injected(intPtr, query);
		}

		[FreeFunction("HierarchyNodeTypeHandlerBaseBindings::SearchMatch", HasExplicitThis = true, IsThreadSafe = true)]
		protected virtual bool SearchMatch(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SearchMatch_Injected(intPtr, in node);
		}

		[FreeFunction("HierarchyNodeTypeHandlerBaseBindings::SearchEnd", HasExplicitThis = true, IsThreadSafe = true)]
		protected virtual void SearchEnd()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SearchEnd_Injected(intPtr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[VisibleToOtherModules(new string[] { "UnityEngine.HierarchyModule" })]
		internal static HierarchyNodeTypeHandlerBase FromIntPtr(IntPtr handlePtr)
		{
			return (handlePtr != IntPtr.Zero) ? ((HierarchyNodeTypeHandlerBase)GCHandle.FromIntPtr(handlePtr).Target) : null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Internal_SearchBegin(HierarchySearchQueryDescriptor query)
		{
			SearchBegin(query);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal bool Internal_SearchMatch(in HierarchyNode node)
		{
			return SearchMatch(in node);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("HierarchyNodeTypeHandlerManager::Get().GetNodeType", IsThreadSafe = true, ThrowsException = true)]
		private static extern int GetNodeTypeFromType(Type type);

		[RequiredByNativeCode]
		private static IntPtr CreateNodeTypeHandlerFromType(IntPtr nativePtr, Type handlerType, IntPtr hierarchyPtr, IntPtr cmdListPtr)
		{
			if (nativePtr == IntPtr.Zero)
			{
				throw new ArgumentNullException("nativePtr");
			}
			if (hierarchyPtr == IntPtr.Zero)
			{
				throw new ArgumentNullException("hierarchyPtr");
			}
			if (cmdListPtr == IntPtr.Zero)
			{
				throw new ArgumentNullException("cmdListPtr");
			}
			Hierarchy hierarchy = Hierarchy.FromIntPtr(hierarchyPtr);
			HierarchyCommandList cmdList = HierarchyCommandList.FromIntPtr(cmdListPtr);
			using (new ConstructorScope(nativePtr, hierarchy, cmdList))
			{
				BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
				HierarchyNodeTypeHandlerBase hierarchyNodeTypeHandlerBase = (HierarchyNodeTypeHandlerBase)Activator.CreateInstance(handlerType, bindingAttr, null, null, null);
				if (hierarchyNodeTypeHandlerBase == null)
				{
					return IntPtr.Zero;
				}
				hierarchyNodeTypeHandlerBase.Initialize();
				return GCHandle.ToIntPtr(GCHandle.Alloc(hierarchyNodeTypeHandlerBase));
			}
		}

		[RequiredByNativeCode]
		private static bool TryGetStaticNodeType(Type handlerType, out int nodeType)
		{
			if (s_NodeTypes.TryGetValue(handlerType, out nodeType))
			{
				return true;
			}
			MethodInfo method = handlerType.GetMethod("GetStaticNodeType", BindingFlags.Static | BindingFlags.NonPublic);
			if (method != null)
			{
				nodeType = (int)method.Invoke(null, null);
				s_NodeTypes.Add(handlerType, nodeType);
				return true;
			}
			nodeType = 0;
			return false;
		}

		[RequiredByNativeCode]
		private static void InvokeInitialize(IntPtr handlePtr)
		{
			FromIntPtr(handlePtr).Initialize();
		}

		[RequiredByNativeCode]
		private static void InvokeDispose(IntPtr handlePtr)
		{
			HierarchyNodeTypeHandlerBase hierarchyNodeTypeHandlerBase = FromIntPtr(handlePtr);
			hierarchyNodeTypeHandlerBase.Dispose(disposing: true);
			GC.SuppressFinalize(hierarchyNodeTypeHandlerBase);
		}

		[RequiredByNativeCode]
		private static string InvokeGetNodeTypeName(IntPtr handlePtr)
		{
			return FromIntPtr(handlePtr).GetNodeTypeName();
		}

		[RequiredByNativeCode]
		private static HierarchyNodeFlags InvokeGetDefaultNodeFlags(IntPtr handlePtr, in HierarchyNode node, HierarchyNodeFlags defaultFlags)
		{
			return FromIntPtr(handlePtr).GetDefaultNodeFlags(in node, defaultFlags);
		}

		[RequiredByNativeCode]
		private static bool InvokeChangesPending(IntPtr handlePtr)
		{
			return FromIntPtr(handlePtr).ChangesPending();
		}

		[RequiredByNativeCode]
		private static bool InvokeIntegrateChanges(IntPtr handlePtr, IntPtr cmdListPtr)
		{
			return FromIntPtr(handlePtr).IntegrateChanges(HierarchyCommandList.FromIntPtr(cmdListPtr));
		}

		[RequiredByNativeCode]
		private static bool InvokeSearchMatch(IntPtr handlePtr, in HierarchyNode node)
		{
			return FromIntPtr(handlePtr).SearchMatch(in node);
		}

		[RequiredByNativeCode]
		private static void InvokeSearchEnd(IntPtr handlePtr)
		{
			FromIntPtr(handlePtr).SearchEnd();
		}

		[Obsolete("The constructor with a hierarchy parameter is obsolete and is no longer used. Remove the hierarchy parameter from your constructor.")]
		protected HierarchyNodeTypeHandlerBase(Hierarchy hierarchy)
			: this()
		{
		}

		[Obsolete("The IDisposable interface is obsolete and no longer has any effect. Instances of handlers are owned and disposed by the hierarchy so they do not need to be disposed by user code.")]
		public void Dispose()
		{
		}

		[FreeFunction("HierarchyNodeTypeHandlerBaseBindings::ChangesPending", HasExplicitThis = true, IsThreadSafe = true)]
		[Obsolete("ChangesPending is obsolete, it is replaced by adding commands into the hierarchy node type handler's CommandList.", false)]
		protected virtual bool ChangesPending()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return ChangesPending_Injected(intPtr);
		}

		[Obsolete("IntegrateChanges is obsolete, it is replaced by adding commands into the hierarchy node type handler's CommandList.", false)]
		[FreeFunction("HierarchyNodeTypeHandlerBaseBindings::IntegrateChanges", HasExplicitThis = true, IsThreadSafe = true)]
		protected virtual bool IntegrateChanges(HierarchyCommandList cmdList)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IntegrateChanges_Injected(intPtr, (cmdList == null) ? ((IntPtr)0) : HierarchyCommandList.BindingsMarshaller.ConvertToNative(cmdList));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetNodeTypeName_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern HierarchyNodeFlags GetDefaultNodeFlags_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags defaultFlags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SearchBegin_Injected(IntPtr _unity_self, HierarchySearchQueryDescriptor query);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SearchMatch_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SearchEnd_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ChangesPending_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IntegrateChanges_Injected(IntPtr _unity_self, IntPtr cmdList);
	}
	public readonly struct HierarchyNodeTypeHandlerBaseEnumerable
	{
		public struct Enumerator : IDisposable
		{
			private readonly IMemoryOwner<IntPtr> m_Handlers;

			private readonly int m_Count;

			private int m_Index;

			public HierarchyNodeTypeHandlerBase Current
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return HierarchyNodeTypeHandlerBase.FromIntPtr(m_Handlers.Memory.Span[m_Index]);
				}
			}

			internal Enumerator(Hierarchy hierarchy)
			{
				m_Handlers = MemoryPool<IntPtr>.Shared.Rent(hierarchy.GetNodeTypeHandlersBaseCount());
				m_Count = hierarchy.GetNodeTypeHandlersBaseSpan(m_Handlers.Memory.Span);
				m_Index = -1;
			}

			public void Dispose()
			{
				m_Handlers.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				return ++m_Index < m_Count;
			}
		}

		private readonly Hierarchy m_Hierarchy;

		internal HierarchyNodeTypeHandlerBaseEnumerable(Hierarchy hierarchy)
		{
			m_Hierarchy = hierarchy;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(m_Hierarchy);
		}
	}
	public readonly struct HierarchyPropertyString : IEquatable<HierarchyPropertyString>, IHierarchyProperty<string>
	{
		private readonly Hierarchy m_Hierarchy;

		internal readonly HierarchyPropertyId m_Property;

		public bool IsCreated => m_Property != HierarchyPropertyId.Null && (m_Hierarchy?.IsCreated ?? false);

		internal HierarchyPropertyString(Hierarchy hierarchy, in HierarchyPropertyId property)
		{
			if (hierarchy == null)
			{
				throw new ArgumentNullException("hierarchy");
			}
			if (property == HierarchyPropertyId.Null)
			{
				throw new ArgumentException("property");
			}
			m_Hierarchy = hierarchy;
			m_Property = property;
		}

		public string GetValue(in HierarchyNode node)
		{
			if (m_Hierarchy == null)
			{
				throw new NullReferenceException("Hierarchy reference has not been set.");
			}
			if (!m_Hierarchy.IsCreated)
			{
				throw new InvalidOperationException("Hierarchy has been disposed.");
			}
			return m_Hierarchy.GetPropertyString(in m_Property, in node);
		}

		public void SetValue(in HierarchyNode node, string value)
		{
			if (m_Hierarchy == null)
			{
				throw new NullReferenceException("Hierarchy reference has not been set.");
			}
			if (!m_Hierarchy.IsCreated)
			{
				throw new InvalidOperationException("Hierarchy has been disposed.");
			}
			m_Hierarchy.SetPropertyString(in m_Property, in node, value);
		}

		public void ClearValue(in HierarchyNode node)
		{
			if (m_Hierarchy == null)
			{
				throw new NullReferenceException("Hierarchy reference has not been set.");
			}
			if (!m_Hierarchy.IsCreated)
			{
				throw new InvalidOperationException("Hierarchy has been disposed.");
			}
			m_Hierarchy.ClearProperty(in m_Property, in node);
		}

		[ExcludeFromDocs]
		public static bool operator ==(in HierarchyPropertyString lhs, in HierarchyPropertyString rhs)
		{
			return lhs.m_Hierarchy == rhs.m_Hierarchy && lhs.m_Property == rhs.m_Property;
		}

		[ExcludeFromDocs]
		public static bool operator !=(in HierarchyPropertyString lhs, in HierarchyPropertyString rhs)
		{
			return !(lhs == rhs);
		}

		[ExcludeFromDocs]
		public bool Equals(HierarchyPropertyString other)
		{
			return m_Hierarchy == other.m_Hierarchy && m_Property == other.m_Property;
		}

		[ExcludeFromDocs]
		public override string ToString()
		{
			return m_Property.ToString();
		}

		[ExcludeFromDocs]
		public override bool Equals(object obj)
		{
			return obj is HierarchyPropertyString other && Equals(other);
		}

		[ExcludeFromDocs]
		public override int GetHashCode()
		{
			return m_Property.GetHashCode();
		}

		string IHierarchyProperty<string>.GetValue(in HierarchyNode node)
		{
			return GetValue(in node);
		}

		void IHierarchyProperty<string>.SetValue(in HierarchyNode node, string value)
		{
			SetValue(in node, value);
		}

		void IHierarchyProperty<string>.ClearValue(in HierarchyNode node)
		{
			ClearValue(in node);
		}
	}
	public readonly struct HierarchyPropertyUnmanaged<T> : IEquatable<HierarchyPropertyUnmanaged<T>>, IHierarchyProperty<T> where T : unmanaged
	{
		private readonly Hierarchy m_Hierarchy;

		internal readonly HierarchyPropertyId m_Property;

		public bool IsCreated => m_Property != HierarchyPropertyId.Null && (m_Hierarchy?.IsCreated ?? false);

		internal HierarchyPropertyUnmanaged(Hierarchy hierarchy, in HierarchyPropertyId property)
		{
			if (hierarchy == null)
			{
				throw new ArgumentNullException("hierarchy");
			}
			if (property == HierarchyPropertyId.Null)
			{
				throw new ArgumentException("property");
			}
			m_Hierarchy = hierarchy;
			m_Property = property;
		}

		public unsafe void SetValue(in HierarchyNode node, T value)
		{
			if (m_Hierarchy == null)
			{
				throw new NullReferenceException("Hierarchy reference has not been set.");
			}
			if (!m_Hierarchy.IsCreated)
			{
				throw new InvalidOperationException("Hierarchy has been disposed.");
			}
			m_Hierarchy.SetPropertyRaw(in m_Property, in node, &value, sizeof(T));
		}

		public unsafe T GetValue(in HierarchyNode node)
		{
			if (m_Hierarchy == null)
			{
				throw new NullReferenceException("Hierarchy reference has not been set.");
			}
			if (!m_Hierarchy.IsCreated)
			{
				throw new InvalidOperationException("Hierarchy has been disposed.");
			}
			int size;
			void* propertyRaw = m_Hierarchy.GetPropertyRaw(in m_Property, in node, out size);
			if (propertyRaw == null || size != sizeof(T))
			{
				return default(T);
			}
			return UnsafeUtility.AsRef<T>(propertyRaw);
		}

		public void ClearValue(in HierarchyNode node)
		{
			if (m_Hierarchy == null)
			{
				throw new NullReferenceException("Hierarchy reference has not been set.");
			}
			if (!m_Hierarchy.IsCreated)
			{
				throw new InvalidOperationException("Hierarchy has been disposed.");
			}
			m_Hierarchy.ClearProperty(in m_Property, in node);
		}

		[ExcludeFromDocs]
		public static bool operator ==(in HierarchyPropertyUnmanaged<T> lhs, in HierarchyPropertyUnmanaged<T> rhs)
		{
			return lhs.m_Hierarchy == rhs.m_Hierarchy && lhs.m_Property == rhs.m_Property;
		}

		[ExcludeFromDocs]
		public static bool operator !=(in HierarchyPropertyUnmanaged<T> lhs, in HierarchyPropertyUnmanaged<T> rhs)
		{
			return !(lhs == rhs);
		}

		[ExcludeFromDocs]
		public bool Equals(HierarchyPropertyUnmanaged<T> other)
		{
			return m_Hierarchy == other.m_Hierarchy && m_Property == other.m_Property;
		}

		[ExcludeFromDocs]
		public override string ToString()
		{
			return m_Property.ToString();
		}

		[ExcludeFromDocs]
		public override bool Equals(object obj)
		{
			return obj is HierarchyPropertyUnmanaged<T> other && Equals(other);
		}

		[ExcludeFromDocs]
		public override int GetHashCode()
		{
			return m_Property.GetHashCode();
		}

		T IHierarchyProperty<T>.GetValue(in HierarchyNode node)
		{
			return GetValue(in node);
		}

		void IHierarchyProperty<T>.SetValue(in HierarchyNode node, T value)
		{
			SetValue(in node, value);
		}

		void IHierarchyProperty<T>.ClearValue(in HierarchyNode node)
		{
			ClearValue(in node);
		}
	}
	[VisibleToOtherModules(new string[] { "UnityEditor.HierarchyModule" })]
	internal interface IHierarchySearchQueryParser
	{
		HierarchySearchQueryDescriptor ParseQuery(string query);
	}
	internal class DefaultHierarchySearchQueryParser : IHierarchySearchQueryParser
	{
		private static readonly Regex s_Filter = new Regex("([#$\\w\\[\\]]+)(<=|<|>=|>|<|=|:)(.*)", RegexOptions.Compiled);

		private static List<string> Tokenize(string s)
		{
			s = s.Trim();
			List<string> list = new List<string>();
			int num = 0;
			int i = 0;
			while (i < s.Length)
			{
				if (char.IsWhiteSpace(s[i]))
				{
					string item = s.Substring(num, i - num);
					list.Add(item);
					for (i++; i < s.Length && char.IsWhiteSpace(s[i]); i++)
					{
					}
					if (i < s.Length)
					{
						num = i;
					}
				}
				else if (s[i] == '"')
				{
					for (i++; i < s.Length && s[i] != '"'; i++)
					{
					}
					if (i >= s.Length)
					{
						return null;
					}
					i++;
				}
				else
				{
					i++;
				}
			}
			if (i != num)
			{
				string item2 = s.Substring(num, i - num);
				list.Add(item2);
			}
			return list;
		}

		public HierarchySearchQueryDescriptor ParseQuery(string query)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return HierarchySearchQueryDescriptor.Empty;
			}
			List<string> list = Tokenize(query);
			if (list == null)
			{
				return HierarchySearchQueryDescriptor.InvalidQuery;
			}
			List<string> list2 = new List<string>();
			List<HierarchySearchFilter> list3 = new List<HierarchySearchFilter>();
			bool flag = true;
			foreach (string item in list)
			{
				Match match = s_Filter.Match(item);
				if (match.Success)
				{
					if (match.Groups.Count < 4 || string.IsNullOrEmpty(match.Groups[1].Value) || string.IsNullOrEmpty(match.Groups[2].Value) || string.IsNullOrEmpty(match.Groups[3].Value))
					{
						flag = false;
						break;
					}
					list3.Add(HierarchySearchFilter.CreateFilter(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value));
				}
				else
				{
					list2.Add(item);
				}
			}
			if (!flag)
			{
				return HierarchySearchQueryDescriptor.InvalidQuery;
			}
			return new HierarchySearchQueryDescriptor(list3.ToArray(), list2.ToArray());
		}
	}
	public readonly struct HierarchyViewNodesEnumerable
	{
		internal delegate bool Predicate(in HierarchyNode node, HierarchyNodeFlags flags);

		public struct Enumerator
		{
			private readonly HierarchyFlattened m_HierarchyFlattened;

			private readonly Predicate m_Predicate;

			private readonly HierarchyNodeFlags m_Flags;

			private unsafe readonly HierarchyFlattenedNode* m_NodesPtr;

			private readonly int m_NodesCount;

			private readonly int m_Version;

			private int m_Index;

			public unsafe ref readonly HierarchyNode Current
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					ThrowIfVersionChanged();
					return ref HierarchyFlattenedNode.GetNodeByRef(in m_NodesPtr[m_Index]);
				}
			}

			internal unsafe Enumerator(HierarchyViewNodesEnumerable enumerable)
			{
				m_HierarchyFlattened = enumerable.m_HierarchyViewModel.HierarchyFlattened;
				m_Predicate = enumerable.m_Predicate;
				m_Flags = enumerable.m_Flags;
				m_NodesPtr = m_HierarchyFlattened.NodesPtr;
				m_NodesCount = m_HierarchyFlattened.Count;
				m_Version = m_HierarchyFlattened.Version;
				m_Index = 0;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public unsafe bool MoveNext()
			{
				ThrowIfVersionChanged();
				do
				{
					if (++m_Index >= m_NodesCount)
					{
						return false;
					}
				}
				while (!m_Predicate(in HierarchyFlattenedNode.GetNodeByRef(in m_NodesPtr[m_Index]), m_Flags));
				return true;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void ThrowIfVersionChanged()
			{
				if (m_Version != m_HierarchyFlattened.Version)
				{
					throw new InvalidOperationException("HierarchyFlattened was modified.");
				}
			}
		}

		private readonly HierarchyViewModel m_HierarchyViewModel;

		private readonly Predicate m_Predicate;

		private readonly HierarchyNodeFlags m_Flags;

		internal HierarchyViewNodesEnumerable(HierarchyViewModel viewModel, HierarchyNodeFlags flags, Predicate predicate)
		{
			m_HierarchyViewModel = viewModel ?? throw new ArgumentNullException("viewModel");
			m_Predicate = predicate ?? throw new ArgumentNullException("predicate");
			m_Flags = flags;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}
	}
	public interface IHierarchyProperty<T>
	{
		bool IsCreated { get; }

		T GetValue(in HierarchyNode node);

		void SetValue(in HierarchyNode node, T value);

		void ClearValue(in HierarchyNode node);
	}
	internal enum NativeSparseArrayResizePolicy
	{
		ExactSize,
		DoubleSize
	}
	internal struct NativeSparseArray<TKey, TValue> : IDisposable where TKey : unmanaged, IEquatable<TKey> where TValue : unmanaged
	{
		private readonly struct Pair(in TKey key, in TValue value)
		{
			public readonly TKey Key = key;

			public readonly TValue Value = value;
		}

		public delegate int KeyIndex(in TKey key);

		public delegate bool KeyEqual(in TKey lhs, in TKey rhs);

		private unsafe Pair* m_Ptr;

		private int m_Capacity;

		private int m_Count;

		private readonly Allocator m_Allocator;

		private readonly Pair m_InitValue;

		private readonly KeyIndex m_KeyIndex;

		private readonly KeyEqual m_KeyEqual;

		public unsafe bool IsCreated
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return m_Ptr != null;
			}
		}

		public int Capacity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return m_Capacity;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				Allocate(value);
			}
		}

		public int Count => m_Count;

		public unsafe TValue this[in TKey key]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				int num = m_KeyIndex(in key);
				ThrowIfIndexOutOfRange(num);
				ref Pair reference = ref m_Ptr[num];
				if (!m_KeyEqual(in reference.Key, in key))
				{
					throw new KeyNotFoundException(key.ToString());
				}
				return reference.Value;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				int num = m_KeyIndex(in key);
				ThrowIfIndexIsNegative(num);
				EnsureCapacity(num + 1, NativeSparseArrayResizePolicy.ExactSize);
				ref Pair reference = ref m_Ptr[num];
				if (m_KeyEqual(in reference.Key, default(TKey)))
				{
					m_Count++;
				}
				m_Ptr[num] = new Pair(in key, in value);
			}
		}

		public unsafe NativeSparseArray(KeyIndex keyIndex, Allocator allocator)
		{
			m_Ptr = null;
			m_Capacity = 0;
			m_Count = 0;
			m_Allocator = allocator;
			m_InitValue = default(Pair);
			m_KeyIndex = keyIndex;
			m_KeyEqual = delegate(in TKey lhs, in TKey rhs)
			{
				return lhs.Equals(rhs);
			};
		}

		public unsafe NativeSparseArray(KeyIndex keyIndex, KeyEqual keyEqual, Allocator allocator)
		{
			m_Ptr = null;
			m_Capacity = 0;
			m_Count = 0;
			m_Allocator = allocator;
			m_InitValue = default(Pair);
			m_KeyIndex = keyIndex;
			m_KeyEqual = keyEqual;
		}

		public unsafe NativeSparseArray(in TValue initValue, KeyIndex keyIndex, Allocator allocator)
		{
			m_Ptr = null;
			m_Capacity = 0;
			m_Count = 0;
			m_Allocator = allocator;
			m_InitValue = new Pair(default(TKey), in initValue);
			m_KeyIndex = keyIndex;
			m_KeyEqual = delegate(in TKey lhs, in TKey rhs)
			{
				return lhs.Equals(rhs);
			};
		}

		public unsafe NativeSparseArray(in TValue initValue, KeyIndex keyIndex, KeyEqual keyEqual, Allocator allocator)
		{
			m_Ptr = null;
			m_Capacity = 0;
			m_Count = 0;
			m_Allocator = allocator;
			m_InitValue = new Pair(default(TKey), in initValue);
			m_KeyIndex = keyIndex;
			m_KeyEqual = keyEqual;
		}

		public void Dispose()
		{
			Deallocate();
		}

		public void Reserve(int capacity)
		{
			EnsureCapacity(capacity, NativeSparseArrayResizePolicy.ExactSize);
		}

		public unsafe bool ContainsKey(in TKey key)
		{
			int num = m_KeyIndex(in key);
			ThrowIfIndexOutOfRange(num);
			ref Pair reference = ref m_Ptr[num];
			return m_KeyEqual(in reference.Key, in key);
		}

		public unsafe void Add(in TKey key, in TValue value, NativeSparseArrayResizePolicy policy = NativeSparseArrayResizePolicy.ExactSize)
		{
			int num = m_KeyIndex(in key);
			ThrowIfIndexIsNegative(num);
			EnsureCapacity(num + 1, policy);
			ref Pair reference = ref m_Ptr[num];
			if (m_KeyEqual(in reference.Key, in key))
			{
				throw new ArgumentException($"an element with the same key [{key}] already exists");
			}
			if (m_KeyEqual(in reference.Key, default(TKey)))
			{
				m_Count++;
			}
			m_Ptr[num] = new Pair(in key, in value);
		}

		public unsafe void AddNoResize(in TKey key, in TValue value)
		{
			int num = m_KeyIndex(in key);
			ThrowIfIndexOutOfRange(num);
			ref Pair reference = ref m_Ptr[num];
			if (m_KeyEqual(in reference.Key, in key))
			{
				throw new ArgumentException($"an element with the same key [{key}] already exists");
			}
			if (m_KeyEqual(in reference.Key, default(TKey)))
			{
				m_Count++;
			}
			m_Ptr[num] = new Pair(in key, in value);
		}

		public unsafe bool TryAdd(in TKey key, in TValue value, NativeSparseArrayResizePolicy policy = NativeSparseArrayResizePolicy.ExactSize)
		{
			int num = m_KeyIndex(in key);
			ThrowIfIndexIsNegative(num);
			EnsureCapacity(num + 1, policy);
			ref Pair reference = ref m_Ptr[num];
			if (m_KeyEqual(in reference.Key, in key))
			{
				return false;
			}
			if (m_KeyEqual(in reference.Key, default(TKey)))
			{
				m_Count++;
			}
			m_Ptr[num] = new Pair(in key, in value);
			return true;
		}

		public unsafe bool TryAddNoResize(in TKey key, in TValue value)
		{
			int num = m_KeyIndex(in key);
			ThrowIfIndexOutOfRange(num);
			ref Pair reference = ref m_Ptr[num];
			if (m_KeyEqual(in reference.Key, in key))
			{
				return false;
			}
			if (m_KeyEqual(in reference.Key, default(TKey)))
			{
				m_Count++;
			}
			m_Ptr[num] = new Pair(in key, in value);
			return true;
		}

		public unsafe bool TryGetValue(in TKey key, out TValue value)
		{
			int num = m_KeyIndex(in key);
			ThrowIfIndexOutOfRange(num);
			ref Pair reference = ref m_Ptr[num];
			if (m_KeyEqual(in reference.Key, in key))
			{
				value = reference.Value;
				return true;
			}
			value = default(TValue);
			return false;
		}

		public unsafe bool Remove(in TKey key)
		{
			int num = m_KeyIndex(in key);
			ThrowIfIndexOutOfRange(num);
			ref Pair reference = ref m_Ptr[num];
			if (!m_KeyEqual(in reference.Key, in key))
			{
				return false;
			}
			m_Ptr[num] = m_InitValue;
			m_Count--;
			return true;
		}

		public unsafe void Clear()
		{
			if (m_Ptr != null)
			{
				fixed (Pair* initValue = &m_InitValue)
				{
					void* source = initValue;
					UnsafeUtility.MemCpyReplicate(m_Ptr, source, UnsafeUtility.SizeOf<Pair>(), m_Capacity);
				}
			}
			m_Count = 0;
		}

		private unsafe void Allocate(int capacity)
		{
			if (capacity < 0)
			{
				throw new ArgumentException($"capacity [{capacity}] cannot be negative");
			}
			int num = UnsafeUtility.SizeOf<Pair>();
			int alignment = UnsafeUtility.AlignOf<Pair>();
			if (m_Ptr == null)
			{
				m_Ptr = (Pair*)UnsafeUtility.Malloc(capacity * num, alignment, m_Allocator);
				fixed (Pair* initValue = &m_InitValue)
				{
					UnsafeUtility.MemCpyReplicate(m_Ptr, initValue, num, capacity);
				}
			}
			else
			{
				m_Ptr = (Pair*)Realloc(m_Ptr, capacity * num, alignment, m_Allocator);
				if (capacity > m_Capacity)
				{
					fixed (Pair* initValue2 = &m_InitValue)
					{
						UnsafeUtility.MemCpyReplicate(m_Ptr + m_Capacity, initValue2, num, capacity - m_Capacity);
					}
				}
			}
			m_Capacity = capacity;
		}

		private unsafe void Deallocate()
		{
			if (m_Ptr != null)
			{
				UnsafeUtility.Free(m_Ptr, m_Allocator);
				m_Ptr = null;
			}
			m_Capacity = 0;
			m_Count = 0;
		}

		private void EnsureCapacity(int capacity, NativeSparseArrayResizePolicy policy)
		{
			if (capacity > m_Capacity)
			{
				switch (policy)
				{
				case NativeSparseArrayResizePolicy.ExactSize:
					Allocate(capacity);
					break;
				case NativeSparseArrayResizePolicy.DoubleSize:
					Allocate(Math.Max(capacity, m_Capacity * 2));
					break;
				default:
					throw new NotImplementedException(policy.ToString());
				}
			}
		}

		private void ThrowIfIndexIsNegative(int index)
		{
			if (index < 0)
			{
				throw new InvalidOperationException($"key index [{index}] cannot be negative");
			}
		}

		private void ThrowIfIndexOutOfRange(int index)
		{
			ThrowIfIndexIsNegative(index);
			if (index >= m_Capacity)
			{
				throw new InvalidOperationException($"key index [{index}] is out of range [0, {m_Capacity}]");
			}
		}

		private unsafe static void* Realloc(void* ptr, long size, int alignment, Allocator allocator)
		{
			if (ptr == null)
			{
				return UnsafeUtility.Malloc(size, alignment, allocator);
			}
			void* ptr2 = UnsafeUtility.Malloc(size, alignment, allocator);
			UnsafeUtility.MemCpy(ptr2, ptr, size);
			UnsafeUtility.Free(ptr, allocator);
			return ptr2;
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[NativeHeader("Modules/HierarchyCore/Public/Hierarchy.h")]
	[NativeHeader("Modules/HierarchyCore/HierarchyBindings.h")]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyNodeTypeHandlerBase.h")]
	public sealed class Hierarchy : IDisposable
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(Hierarchy hierarchy)
			{
				return hierarchy.m_Ptr;
			}
		}

		private IntPtr m_Ptr;

		private readonly IntPtr m_RootPtr;

		private readonly IntPtr m_VersionPtr;

		private readonly bool m_IsOwner;

		public bool IsCreated => m_Ptr != IntPtr.Zero;

		public unsafe ref readonly HierarchyNode Root
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return ref *(HierarchyNode*)(void*)m_RootPtr;
			}
		}

		public int Count
		{
			[NativeMethod("Count", IsThreadSafe = true)]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_Count_Injected(intPtr);
			}
		}

		public bool Updating
		{
			[NativeMethod("Updating", IsThreadSafe = true)]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_Updating_Injected(intPtr);
			}
		}

		public bool UpdateNeeded
		{
			[NativeMethod("UpdateNeeded", IsThreadSafe = true)]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_UpdateNeeded_Injected(intPtr);
			}
		}

		internal unsafe int Version
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return *(int*)(void*)m_VersionPtr;
			}
		}

		public Hierarchy()
		{
			m_Ptr = Create(GCHandle.ToIntPtr(GCHandle.Alloc(this)), out var rootPtr, out var versionPtr);
			m_RootPtr = rootPtr;
			m_VersionPtr = versionPtr;
			m_IsOwner = true;
		}

		private Hierarchy(IntPtr nativePtr, IntPtr rootPtr, IntPtr versionPtr)
		{
			m_Ptr = nativePtr;
			m_RootPtr = rootPtr;
			m_VersionPtr = versionPtr;
			m_IsOwner = false;
		}

		~Hierarchy()
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
				if (m_IsOwner)
				{
					Destroy(m_Ptr);
				}
				m_Ptr = IntPtr.Zero;
			}
		}

		public T GetOrCreateNodeTypeHandler<T>() where T : HierarchyNodeTypeHandlerBase
		{
			return (T)HierarchyNodeTypeHandlerBase.FromIntPtr(GetOrCreateNodeTypeHandler(typeof(T)));
		}

		public T GetNodeTypeHandlerBase<T>() where T : HierarchyNodeTypeHandlerBase
		{
			return (T)HierarchyNodeTypeHandlerBase.FromIntPtr(GetNodeTypeHandlerFromType(typeof(T)));
		}

		public HierarchyNodeTypeHandlerBase GetNodeTypeHandlerBase(in HierarchyNode node)
		{
			return HierarchyNodeTypeHandlerBase.FromIntPtr(GetNodeTypeHandlerFromNode(in node));
		}

		public HierarchyNodeTypeHandlerBase GetNodeTypeHandlerBase(string nodeTypeName)
		{
			return HierarchyNodeTypeHandlerBase.FromIntPtr(GetNodeTypeHandlerFromName(nodeTypeName));
		}

		public HierarchyNodeTypeHandlerBaseEnumerable EnumerateNodeTypeHandlersBase()
		{
			return new HierarchyNodeTypeHandlerBaseEnumerable(this);
		}

		public HierarchyNodeType GetNodeType<T>() where T : HierarchyNodeTypeHandlerBase
		{
			return GetNodeTypeFromType(typeof(T));
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public HierarchyNodeType GetNodeType(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetNodeType_Injected(intPtr, in node, out var ret);
			return ret;
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public void Reserve(int count)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Reserve_Injected(intPtr, count);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public void ReserveChildren(in HierarchyNode node, int count)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ReserveChildren_Injected(intPtr, in node, count);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public bool Exists(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Exists_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public HierarchyNode GetNextSibling(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetNextSibling_Injected(intPtr, in node, out var ret);
			return ret;
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int GetDepth(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetDepth_Injected(intPtr, in node);
		}

		public HierarchyNode Add(in HierarchyNode parent)
		{
			return AddNode(in parent);
		}

		public HierarchyNode[] Add(in HierarchyNode parent, int count)
		{
			HierarchyNode[] array = new HierarchyNode[count];
			AddNodeSpan(in parent, array);
			return array;
		}

		public void Add(in HierarchyNode parent, Span<HierarchyNode> outNodes)
		{
			AddNodeSpan(in parent, outNodes);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public bool Remove(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Remove_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public void RemoveChildren(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			RemoveChildren_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true)]
		public void Clear()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Clear_Injected(intPtr);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public bool SetParent(in HierarchyNode node, in HierarchyNode parent)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetParent_Injected(intPtr, in node, in parent);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public HierarchyNode GetParent(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetParent_Injected(intPtr, in node, out var ret);
			return ret;
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public HierarchyNode GetChild(in HierarchyNode node, int index)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetChild_Injected(intPtr, in node, index, out var ret);
			return ret;
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int GetChildIndex(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetChildIndex_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public HierarchyNode[] GetChildren(in HierarchyNode node)
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			HierarchyNode[] result;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetChildren_Injected(intPtr, in node, out ret);
			}
			finally
			{
				HierarchyNode[] array = default(HierarchyNode[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}

		public int GetChildren(in HierarchyNode node, Span<HierarchyNode> outChildren)
		{
			return GetNodeChildrenSpan(in node, outChildren);
		}

		public HierarchyNodeChildren EnumerateChildren(in HierarchyNode node)
		{
			return new HierarchyNodeChildren(this, EnumerateChildrenPtr(in node));
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int GetChildrenCount(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetChildrenCount_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int GetChildrenCountRecursive(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetChildrenCountRecursive_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public void SetSortIndex(in HierarchyNode node, int sortIndex)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetSortIndex_Injected(intPtr, in node, sortIndex);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int GetSortIndex(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetSortIndex_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public void SortChildren(in HierarchyNode node, bool recurse = false)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SortChildren_Injected(intPtr, in node, recurse);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public bool DoesChildrenNeedsSorting(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return DoesChildrenNeedsSorting_Injected(intPtr, in node);
		}

		public HierarchyPropertyUnmanaged<T> GetOrCreatePropertyUnmanaged<T>(string name, HierarchyPropertyStorageType type = HierarchyPropertyStorageType.Dense) where T : unmanaged
		{
			HierarchyPropertyDescriptor descriptor = new HierarchyPropertyDescriptor
			{
				Size = UnsafeUtility.SizeOf<T>(),
				Type = type
			};
			return new HierarchyPropertyUnmanaged<T>(this, GetOrCreateProperty(name, in descriptor));
		}

		public HierarchyPropertyString GetOrCreatePropertyString(string name)
		{
			HierarchyPropertyDescriptor descriptor = new HierarchyPropertyDescriptor
			{
				Size = 0,
				Type = HierarchyPropertyStorageType.Blob
			};
			return new HierarchyPropertyString(this, GetOrCreateProperty(name, in descriptor));
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public unsafe bool SetName(in HierarchyNode node, string name)
		{
			//The blocks IL_003a are reachable both inside and outside the pinned region starting at IL_0029. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return SetName_Injected(intPtr, in node, ref managedSpanWrapper);
					}
				}
				return SetName_Injected(intPtr, in node, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public string GetName(in HierarchyNode node)
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
				GetName_Injected(intPtr, in node, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public string GetPath(in HierarchyNode node)
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
				GetPath_Injected(intPtr, in node, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[NativeMethod(IsThreadSafe = true)]
		public void Update()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Update_Injected(intPtr);
		}

		[NativeMethod(IsThreadSafe = true)]
		public bool UpdateIncremental()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return UpdateIncremental_Injected(intPtr);
		}

		[NativeMethod(IsThreadSafe = true)]
		public bool UpdateIncrementalTimed(double milliseconds)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return UpdateIncrementalTimed_Injected(intPtr, milliseconds);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Hierarchy FromIntPtr(IntPtr handlePtr)
		{
			return (handlePtr != IntPtr.Zero) ? ((Hierarchy)GCHandle.FromIntPtr(handlePtr).Target) : null;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("HierarchyBindings::Create", IsThreadSafe = true)]
		private static extern IntPtr Create(IntPtr handlePtr, out IntPtr rootPtr, out IntPtr versionPtr);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("HierarchyBindings::Destroy", IsThreadSafe = true)]
		private static extern void Destroy(IntPtr nativePtr);

		[FreeFunction("HierarchyBindings::GetOrCreateNodeTypeHandler", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private IntPtr GetOrCreateNodeTypeHandler(Type type)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetOrCreateNodeTypeHandler_Injected(intPtr, type);
		}

		[FreeFunction("HierarchyBindings::GetNodeTypeHandlerFromType", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private IntPtr GetNodeTypeHandlerFromType(Type type)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetNodeTypeHandlerFromType_Injected(intPtr, type);
		}

		[FreeFunction("HierarchyBindings::GetNodeTypeHandlerFromNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private IntPtr GetNodeTypeHandlerFromNode(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetNodeTypeHandlerFromNode_Injected(intPtr, in node);
		}

		[FreeFunction("HierarchyBindings::GetNodeTypeHandlerFromName", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe IntPtr GetNodeTypeHandlerFromName(string nodeTypeName)
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
				if (!StringMarshaller.TryMarshalEmptyOrNullString(nodeTypeName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(nodeTypeName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetNodeTypeHandlerFromName_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return GetNodeTypeHandlerFromName_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.HierarchyModule" })]
		[FreeFunction("HierarchyBindings::GetNodeTypeHandlersBaseCount", HasExplicitThis = true, IsThreadSafe = true)]
		internal int GetNodeTypeHandlersBaseCount()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetNodeTypeHandlersBaseCount_Injected(intPtr);
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.HierarchyModule" })]
		[FreeFunction("HierarchyBindings::GetNodeTypeHandlersBaseSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		internal unsafe int GetNodeTypeHandlersBaseSpan(Span<IntPtr> outHandlers)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<IntPtr> span = outHandlers;
			int nodeTypeHandlersBaseSpan_Injected;
			fixed (IntPtr* begin = span)
			{
				ManagedSpanWrapper outHandlers2 = new ManagedSpanWrapper(begin, span.Length);
				nodeTypeHandlersBaseSpan_Injected = GetNodeTypeHandlersBaseSpan_Injected(intPtr, ref outHandlers2);
			}
			return nodeTypeHandlersBaseSpan_Injected;
		}

		[FreeFunction("HierarchyBindings::GetNodeTypeFromType", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private HierarchyNodeType GetNodeTypeFromType(Type type)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetNodeTypeFromType_Injected(intPtr, type, out var ret);
			return ret;
		}

		[FreeFunction("HierarchyBindings::AddNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private HierarchyNode AddNode(in HierarchyNode parent)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddNode_Injected(intPtr, in parent, out var ret);
			return ret;
		}

		[FreeFunction("HierarchyBindings::AddNodeSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe void AddNodeSpan(in HierarchyNode parent, Span<HierarchyNode> nodes)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<HierarchyNode> span = nodes;
			fixed (HierarchyNode* begin = span)
			{
				ManagedSpanWrapper nodes2 = new ManagedSpanWrapper(begin, span.Length);
				AddNodeSpan_Injected(intPtr, in parent, ref nodes2);
			}
		}

		[FreeFunction("HierarchyBindings::GetNodeChildrenSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe int GetNodeChildrenSpan(in HierarchyNode node, Span<HierarchyNode> outChildren)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<HierarchyNode> span = outChildren;
			int nodeChildrenSpan_Injected;
			fixed (HierarchyNode* begin = span)
			{
				ManagedSpanWrapper outChildren2 = new ManagedSpanWrapper(begin, span.Length);
				nodeChildrenSpan_Injected = GetNodeChildrenSpan_Injected(intPtr, in node, ref outChildren2);
			}
			return nodeChildrenSpan_Injected;
		}

		[FreeFunction("HierarchyBindings::EnumerateChildrenPtr", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private IntPtr EnumerateChildrenPtr(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return EnumerateChildrenPtr_Injected(intPtr, in node);
		}

		[FreeFunction("HierarchyBindings::GetOrCreateProperty", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe HierarchyPropertyId GetOrCreateProperty(string name, in HierarchyPropertyDescriptor descriptor)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			HierarchyPropertyId ret = default(HierarchyPropertyId);
			HierarchyPropertyId result;
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						GetOrCreateProperty_Injected(intPtr, ref managedSpanWrapper, in descriptor, out ret);
					}
				}
				else
				{
					GetOrCreateProperty_Injected(intPtr, ref managedSpanWrapper, in descriptor, out ret);
				}
			}
			finally
			{
				result = ret;
			}
			return result;
		}

		[FreeFunction("HierarchyBindings::SetPropertyRaw", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		internal unsafe void SetPropertyRaw(in HierarchyPropertyId property, in HierarchyNode node, void* ptr, int size)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetPropertyRaw_Injected(intPtr, in property, in node, ptr, size);
		}

		[FreeFunction("HierarchyBindings::GetPropertyRaw", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		internal unsafe void* GetPropertyRaw(in HierarchyPropertyId property, in HierarchyNode node, out int size)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetPropertyRaw_Injected(intPtr, in property, in node, out size);
		}

		[FreeFunction("HierarchyBindings::SetPropertyString", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		internal unsafe void SetPropertyString(in HierarchyPropertyId property, in HierarchyNode node, string value)
		{
			//The blocks IL_003b are reachable both inside and outside the pinned region starting at IL_002a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
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
						SetPropertyString_Injected(intPtr, in property, in node, ref managedSpanWrapper);
						return;
					}
				}
				SetPropertyString_Injected(intPtr, in property, in node, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[FreeFunction("HierarchyBindings::GetPropertyString", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		internal string GetPropertyString(in HierarchyPropertyId property, in HierarchyNode node)
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
				GetPropertyString_Injected(intPtr, in property, in node, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[FreeFunction("HierarchyBindings::ClearProperty", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		internal void ClearProperty(in HierarchyPropertyId property, in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ClearProperty_Injected(intPtr, in property, in node);
		}

		[RequiredByNativeCode]
		private static IntPtr CreateHierarchy(IntPtr nativePtr, IntPtr rootPtr, IntPtr versionPtr)
		{
			return GCHandle.ToIntPtr(GCHandle.Alloc(new Hierarchy(nativePtr, rootPtr, versionPtr)));
		}

		[Obsolete("RegisterNodeTypeHandler has been renamed GetOrCreateNodeTypeHandler (UnityUpgradable) -> GetOrCreateNodeTypeHandler<T>()")]
		public T RegisterNodeTypeHandler<T>() where T : HierarchyNodeTypeHandlerBase
		{
			return (T)HierarchyNodeTypeHandlerBase.FromIntPtr(GetOrCreateNodeTypeHandler(typeof(T)));
		}

		[Obsolete("UnregisterNodeTypeHandler no longer has any effect and will be removed in a future release.")]
		public void UnregisterNodeTypeHandler<T>() where T : HierarchyNodeTypeHandlerBase
		{
		}

		[Obsolete("GetAllNodeTypeHandlersBaseCount is obsolete, please use EnumerateNodeTypeHandlersBase instead.")]
		public int GetAllNodeTypeHandlersBaseCount()
		{
			return GetNodeTypeHandlersBaseCount();
		}

		[Obsolete("GetAllNodeTypeHandlersBase is obsolete, please use EnumerateNodeTypeHandlersBase instead.")]
		public void GetAllNodeTypeHandlersBase(List<HierarchyNodeTypeHandlerBase> handlers)
		{
			handlers.Clear();
			foreach (HierarchyNodeTypeHandlerBase item in EnumerateNodeTypeHandlersBase())
			{
				handlers.Add(item);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_Count_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_Updating_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_UpdateNeeded_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetNodeType_Injected(IntPtr _unity_self, in HierarchyNode node, out HierarchyNodeType ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Reserve_Injected(IntPtr _unity_self, int count);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ReserveChildren_Injected(IntPtr _unity_self, in HierarchyNode node, int count);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Exists_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetNextSibling_Injected(IntPtr _unity_self, in HierarchyNode node, out HierarchyNode ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetDepth_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Remove_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveChildren_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Clear_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetParent_Injected(IntPtr _unity_self, in HierarchyNode node, in HierarchyNode parent);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetParent_Injected(IntPtr _unity_self, in HierarchyNode node, out HierarchyNode ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetChild_Injected(IntPtr _unity_self, in HierarchyNode node, int index, out HierarchyNode ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetChildIndex_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetChildren_Injected(IntPtr _unity_self, in HierarchyNode node, out BlittableArrayWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetChildrenCount_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetChildrenCountRecursive_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSortIndex_Injected(IntPtr _unity_self, in HierarchyNode node, int sortIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetSortIndex_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SortChildren_Injected(IntPtr _unity_self, in HierarchyNode node, bool recurse);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool DoesChildrenNeedsSorting_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetName_Injected(IntPtr _unity_self, in HierarchyNode node, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetName_Injected(IntPtr _unity_self, in HierarchyNode node, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetPath_Injected(IntPtr _unity_self, in HierarchyNode node, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Update_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool UpdateIncremental_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool UpdateIncrementalTimed_Injected(IntPtr _unity_self, double milliseconds);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetOrCreateNodeTypeHandler_Injected(IntPtr _unity_self, Type type);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetNodeTypeHandlerFromType_Injected(IntPtr _unity_self, Type type);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetNodeTypeHandlerFromNode_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetNodeTypeHandlerFromName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper nodeTypeName);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetNodeTypeHandlersBaseCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetNodeTypeHandlersBaseSpan_Injected(IntPtr _unity_self, ref ManagedSpanWrapper outHandlers);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetNodeTypeFromType_Injected(IntPtr _unity_self, Type type, out HierarchyNodeType ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddNode_Injected(IntPtr _unity_self, in HierarchyNode parent, out HierarchyNode ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddNodeSpan_Injected(IntPtr _unity_self, in HierarchyNode parent, ref ManagedSpanWrapper nodes);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetNodeChildrenSpan_Injected(IntPtr _unity_self, in HierarchyNode node, ref ManagedSpanWrapper outChildren);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr EnumerateChildrenPtr_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetOrCreateProperty_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, in HierarchyPropertyDescriptor descriptor, out HierarchyPropertyId ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void SetPropertyRaw_Injected(IntPtr _unity_self, in HierarchyPropertyId property, in HierarchyNode node, void* ptr, int size);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void* GetPropertyRaw_Injected(IntPtr _unity_self, in HierarchyPropertyId property, in HierarchyNode node, out int size);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetPropertyString_Injected(IntPtr _unity_self, in HierarchyPropertyId property, in HierarchyNode node, ref ManagedSpanWrapper value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetPropertyString_Injected(IntPtr _unity_self, in HierarchyPropertyId property, in HierarchyNode node, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ClearProperty_Injected(IntPtr _unity_self, in HierarchyPropertyId property, in HierarchyNode node);
	}
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[NativeHeader("Modules/HierarchyCore/HierarchyCommandListBindings.h")]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyCommandList.h")]
	public sealed class HierarchyCommandList : IDisposable
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(HierarchyCommandList cmdList)
			{
				return cmdList.m_Ptr;
			}
		}

		private IntPtr m_Ptr;

		private readonly bool m_IsOwner;

		public bool IsCreated => m_Ptr != IntPtr.Zero;

		public int Size
		{
			[NativeMethod("Size", IsThreadSafe = true)]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_Size_Injected(intPtr);
			}
		}

		public int Capacity
		{
			[NativeMethod("Capacity", IsThreadSafe = true)]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_Capacity_Injected(intPtr);
			}
		}

		public bool IsEmpty
		{
			[NativeMethod("IsEmpty", IsThreadSafe = true)]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_IsEmpty_Injected(intPtr);
			}
		}

		public bool IsExecuting
		{
			[NativeMethod("IsExecuting", IsThreadSafe = true)]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_IsExecuting_Injected(intPtr);
			}
		}

		public HierarchyCommandList(Hierarchy hierarchy, int initialCapacity = 65536)
			: this(hierarchy, HierarchyNodeType.Null, initialCapacity)
		{
		}

		internal HierarchyCommandList(Hierarchy hierarchy, HierarchyNodeType nodeType, int initialCapacity = 65536)
		{
			m_Ptr = Create(GCHandle.ToIntPtr(GCHandle.Alloc(this)), hierarchy, nodeType, initialCapacity);
			m_IsOwner = true;
		}

		private HierarchyCommandList(IntPtr nativePtr)
		{
			m_Ptr = nativePtr;
			m_IsOwner = false;
		}

		~HierarchyCommandList()
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
				if (m_IsOwner)
				{
					Destroy(m_Ptr);
				}
				m_Ptr = IntPtr.Zero;
			}
		}

		[NativeMethod(IsThreadSafe = true)]
		public void Clear()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Clear_Injected(intPtr);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public bool Reserve(int count)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Reserve_Injected(intPtr, count);
		}

		public bool Add(in HierarchyNode parent, out HierarchyNode node)
		{
			return AddNode(in parent, out node);
		}

		public bool Add(in HierarchyNode parent, int count, out HierarchyNode[] nodes)
		{
			nodes = new HierarchyNode[count];
			return AddNodeSpan(in parent, nodes);
		}

		public bool Add(in HierarchyNode parent, Span<HierarchyNode> outNodes)
		{
			return AddNodeSpan(in parent, outNodes);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public bool Remove(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Remove_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public bool RemoveChildren(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return RemoveChildren_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public bool SetParent(in HierarchyNode node, in HierarchyNode parent)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetParent_Injected(intPtr, in node, in parent);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public bool SetSortIndex(in HierarchyNode node, int sortIndex)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetSortIndex_Injected(intPtr, in node, sortIndex);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public bool SortChildren(in HierarchyNode node, bool recurse = false)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SortChildren_Injected(intPtr, in node, recurse);
		}

		public unsafe bool SetProperty<T>(in HierarchyPropertyUnmanaged<T> property, in HierarchyNode node, T value) where T : unmanaged
		{
			return SetNodePropertyRaw(in property.m_Property, in node, &value, sizeof(T));
		}

		public bool SetProperty(in HierarchyPropertyString property, in HierarchyNode node, string value)
		{
			return SetNodePropertyString(in property.m_Property, in node, value);
		}

		public bool ClearProperty<T>(in HierarchyPropertyUnmanaged<T> property, in HierarchyNode node) where T : unmanaged
		{
			return ClearNodeProperty(in property.m_Property, in node);
		}

		public bool ClearProperty(in HierarchyPropertyString property, in HierarchyNode node)
		{
			return ClearNodeProperty(in property.m_Property, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public unsafe bool SetName(in HierarchyNode node, string name)
		{
			//The blocks IL_003a are reachable both inside and outside the pinned region starting at IL_0029. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return SetName_Injected(intPtr, in node, ref managedSpanWrapper);
					}
				}
				return SetName_Injected(intPtr, in node, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public void Execute()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Execute_Injected(intPtr);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public bool ExecuteIncremental()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return ExecuteIncremental_Injected(intPtr);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public bool ExecuteIncrementalTimed(double milliseconds)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return ExecuteIncrementalTimed_Injected(intPtr, milliseconds);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static HierarchyCommandList FromIntPtr(IntPtr handlePtr)
		{
			return (handlePtr != IntPtr.Zero) ? ((HierarchyCommandList)GCHandle.FromIntPtr(handlePtr).Target) : null;
		}

		[FreeFunction("HierarchyCommandListBindings::Create", IsThreadSafe = true)]
		private static IntPtr Create(IntPtr handlePtr, Hierarchy hierarchy, HierarchyNodeType nodeType, int initialCapacity)
		{
			return Create_Injected(handlePtr, (hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), ref nodeType, initialCapacity);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("HierarchyCommandListBindings::Destroy", IsThreadSafe = true)]
		private static extern void Destroy(IntPtr nativePtr);

		[FreeFunction("HierarchyCommandListBindings::AddNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private bool AddNode(in HierarchyNode parent, out HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return AddNode_Injected(intPtr, in parent, out node);
		}

		[FreeFunction("HierarchyCommandListBindings::AddNodeSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe bool AddNodeSpan(in HierarchyNode parent, Span<HierarchyNode> outNodes)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<HierarchyNode> span = outNodes;
			bool result;
			fixed (HierarchyNode* begin = span)
			{
				ManagedSpanWrapper outNodes2 = new ManagedSpanWrapper(begin, span.Length);
				result = AddNodeSpan_Injected(intPtr, in parent, ref outNodes2);
			}
			return result;
		}

		[FreeFunction("HierarchyCommandListBindings::SetNodePropertyRaw", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe bool SetNodePropertyRaw(in HierarchyPropertyId property, in HierarchyNode node, void* ptr, int size)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return SetNodePropertyRaw_Injected(intPtr, in property, in node, ptr, size);
		}

		[FreeFunction("HierarchyCommandListBindings::SetNodePropertyString", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe bool SetNodePropertyString(in HierarchyPropertyId property, in HierarchyNode node, string value)
		{
			//The blocks IL_003b are reachable both inside and outside the pinned region starting at IL_002a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
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
						return SetNodePropertyString_Injected(intPtr, in property, in node, ref managedSpanWrapper);
					}
				}
				return SetNodePropertyString_Injected(intPtr, in property, in node, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[FreeFunction("HierarchyCommandListBindings::ClearNodeProperty", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private bool ClearNodeProperty(in HierarchyPropertyId property, in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return ClearNodeProperty_Injected(intPtr, in property, in node);
		}

		[RequiredByNativeCode]
		private static IntPtr CreateCommandList(IntPtr nativePtr)
		{
			return GCHandle.ToIntPtr(GCHandle.Alloc(new HierarchyCommandList(nativePtr)));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_Size_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_Capacity_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_IsEmpty_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_IsExecuting_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Clear_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Reserve_Injected(IntPtr _unity_self, int count);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Remove_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool RemoveChildren_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetParent_Injected(IntPtr _unity_self, in HierarchyNode node, in HierarchyNode parent);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetSortIndex_Injected(IntPtr _unity_self, in HierarchyNode node, int sortIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SortChildren_Injected(IntPtr _unity_self, in HierarchyNode node, bool recurse);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetName_Injected(IntPtr _unity_self, in HierarchyNode node, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Execute_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ExecuteIncremental_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ExecuteIncrementalTimed_Injected(IntPtr _unity_self, double milliseconds);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Create_Injected(IntPtr handlePtr, IntPtr hierarchy, [In] ref HierarchyNodeType nodeType, int initialCapacity);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool AddNode_Injected(IntPtr _unity_self, in HierarchyNode parent, out HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool AddNodeSpan_Injected(IntPtr _unity_self, in HierarchyNode parent, ref ManagedSpanWrapper outNodes);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern bool SetNodePropertyRaw_Injected(IntPtr _unity_self, in HierarchyPropertyId property, in HierarchyNode node, void* ptr, int size);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetNodePropertyString_Injected(IntPtr _unity_self, in HierarchyPropertyId property, in HierarchyNode node, ref ManagedSpanWrapper value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ClearNodeProperty_Injected(IntPtr _unity_self, in HierarchyPropertyId property, in HierarchyNode node);
	}
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode(GenerateProxy = true)]
	[NativeHeader("Modules/HierarchyCore/HierarchyFlattenedBindings.h")]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyFlattened.h")]
	public sealed class HierarchyFlattened : IDisposable
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(HierarchyFlattened hierarchyFlattened)
			{
				return hierarchyFlattened.m_Ptr;
			}
		}

		public struct Enumerator
		{
			private readonly HierarchyFlattened m_HierarchyFlattened;

			private unsafe readonly HierarchyFlattenedNode* m_NodesPtr;

			private readonly int m_NodesCount;

			private readonly int m_Version;

			private int m_Index;

			public unsafe ref readonly HierarchyFlattenedNode Current
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					if (m_Version != m_HierarchyFlattened.m_Version)
					{
						throw new InvalidOperationException("HierarchyFlattened was modified.");
					}
					return ref m_NodesPtr[m_Index];
				}
			}

			internal unsafe Enumerator(HierarchyFlattened hierarchyFlattened)
			{
				m_HierarchyFlattened = hierarchyFlattened;
				m_NodesPtr = (HierarchyFlattenedNode*)(void*)hierarchyFlattened.m_NodesPtr;
				m_NodesCount = hierarchyFlattened.m_NodesCount;
				m_Version = hierarchyFlattened.Version;
				m_Index = -1;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				return ++m_Index < m_NodesCount;
			}
		}

		private IntPtr m_Ptr;

		private readonly Hierarchy m_Hierarchy;

		private IntPtr m_NodesPtr;

		private int m_NodesCount;

		private int m_Version;

		private readonly bool m_IsOwner;

		public bool IsCreated => m_Ptr != IntPtr.Zero;

		public int Count => m_NodesCount;

		public bool Updating
		{
			[NativeMethod("Updating", IsThreadSafe = true)]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_Updating_Injected(intPtr);
			}
		}

		public bool UpdateNeeded
		{
			[NativeMethod("UpdateNeeded", IsThreadSafe = true)]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_UpdateNeeded_Injected(intPtr);
			}
		}

		public Hierarchy Hierarchy => m_Hierarchy;

		internal unsafe HierarchyFlattenedNode* NodesPtr => (HierarchyFlattenedNode*)(void*)m_NodesPtr;

		internal int Version
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return m_Version;
			}
		}

		public unsafe ref readonly HierarchyFlattenedNode this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (index < 0 || index >= m_NodesCount)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return ref *(HierarchyFlattenedNode*)((byte*)(void*)m_NodesPtr + (nint)index * (nint)sizeof(HierarchyFlattenedNode));
			}
		}

		public HierarchyFlattened(Hierarchy hierarchy)
		{
			m_Ptr = Create(GCHandle.ToIntPtr(GCHandle.Alloc(this)), hierarchy, out var nodesPtr, out var nodesCount, out var version);
			m_Hierarchy = hierarchy;
			m_NodesPtr = nodesPtr;
			m_NodesCount = nodesCount;
			m_Version = version;
			m_IsOwner = true;
		}

		private HierarchyFlattened(IntPtr nativePtr, Hierarchy hierarchy, IntPtr nodesPtr, int nodesCount, int version)
		{
			m_Ptr = nativePtr;
			m_Hierarchy = hierarchy;
			m_NodesPtr = nodesPtr;
			m_NodesCount = nodesCount;
			m_Version = version;
			m_IsOwner = false;
		}

		~HierarchyFlattened()
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
				if (m_IsOwner)
				{
					Destroy(m_Ptr);
				}
				m_Ptr = IntPtr.Zero;
			}
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int IndexOf(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IndexOf_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public bool Contains(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Contains_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public HierarchyNode GetParent(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetParent_Injected(intPtr, in node, out var ret);
			return ret;
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public HierarchyNode GetNextSibling(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetNextSibling_Injected(intPtr, in node, out var ret);
			return ret;
		}

		public HierarchyFlattenedNodeChildren EnumerateChildren(in HierarchyNode node)
		{
			return new HierarchyFlattenedNodeChildren(this, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int GetChildrenCount(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetChildrenCount_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int GetChildrenCountRecursive(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetChildrenCountRecursive_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int GetDepth(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetDepth_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true)]
		public void Update()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Update_Injected(intPtr);
		}

		[NativeMethod(IsThreadSafe = true)]
		public bool UpdateIncremental()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return UpdateIncremental_Injected(intPtr);
		}

		[NativeMethod(IsThreadSafe = true)]
		public bool UpdateIncrementalTimed(double milliseconds)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return UpdateIncrementalTimed_Injected(intPtr, milliseconds);
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static HierarchyFlattened FromIntPtr(IntPtr handlePtr)
		{
			return (handlePtr != IntPtr.Zero) ? ((HierarchyFlattened)GCHandle.FromIntPtr(handlePtr).Target) : null;
		}

		[FreeFunction("HierarchyFlattenedBindings::Create", IsThreadSafe = true)]
		private static IntPtr Create(IntPtr handlePtr, Hierarchy hierarchy, out IntPtr nodesPtr, out int nodesCount, out int version)
		{
			return Create_Injected(handlePtr, (hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), out nodesPtr, out nodesCount, out version);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("HierarchyFlattenedBindings::Destroy", IsThreadSafe = true)]
		private static extern void Destroy(IntPtr nativePtr);

		[RequiredByNativeCode]
		private static IntPtr CreateHierarchyFlattened(IntPtr nativePtr, IntPtr hierarchyPtr, IntPtr nodesPtr, int nodesCount, int version)
		{
			return GCHandle.ToIntPtr(GCHandle.Alloc(new HierarchyFlattened(nativePtr, Hierarchy.FromIntPtr(hierarchyPtr), nodesPtr, nodesCount, version)));
		}

		[RequiredByNativeCode]
		private static void UpdateHierarchyFlattened(IntPtr handlePtr, IntPtr nodesPtr, int nodesCount, int version)
		{
			HierarchyFlattened hierarchyFlattened = FromIntPtr(handlePtr);
			hierarchyFlattened.m_NodesPtr = nodesPtr;
			hierarchyFlattened.m_NodesCount = nodesCount;
			hierarchyFlattened.m_Version = version;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_Updating_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_UpdateNeeded_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int IndexOf_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Contains_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetParent_Injected(IntPtr _unity_self, in HierarchyNode node, out HierarchyNode ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetNextSibling_Injected(IntPtr _unity_self, in HierarchyNode node, out HierarchyNode ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetChildrenCount_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetChildrenCountRecursive_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetDepth_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Update_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool UpdateIncremental_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool UpdateIncrementalTimed_Injected(IntPtr _unity_self, double milliseconds);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Create_Injected(IntPtr handlePtr, IntPtr hierarchy, out IntPtr nodesPtr, out int nodesCount, out int version);
	}
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyFlattenedNode.h")]
	public readonly struct HierarchyFlattenedNode : IEquatable<HierarchyFlattenedNode>
	{
		private static readonly HierarchyFlattenedNode s_Null;

		private readonly HierarchyNode m_Node = HierarchyNode.Null;

		private readonly HierarchyNodeType m_Type = HierarchyNodeType.Null;

		private readonly int m_ParentOffset = 0;

		private readonly int m_NextSiblingOffset = 0;

		private readonly int m_ChildrenCount = 0;

		private readonly int m_Depth = 0;

		public static ref readonly HierarchyFlattenedNode Null => ref s_Null;

		public HierarchyNode Node => m_Node;

		public HierarchyNodeType Type => m_Type;

		public int ParentOffset => m_ParentOffset;

		public int NextSiblingOffset => m_NextSiblingOffset;

		public int ChildrenCount => m_ChildrenCount;

		public int Depth => m_Depth;

		public HierarchyFlattenedNode()
		{
		}

		[ExcludeFromDocs]
		public static bool operator ==(in HierarchyFlattenedNode lhs, in HierarchyFlattenedNode rhs)
		{
			return lhs.Node == rhs.Node;
		}

		[ExcludeFromDocs]
		public static bool operator !=(in HierarchyFlattenedNode lhs, in HierarchyFlattenedNode rhs)
		{
			return !(lhs == rhs);
		}

		[ExcludeFromDocs]
		public bool Equals(HierarchyFlattenedNode other)
		{
			return other.Node == Node;
		}

		[ExcludeFromDocs]
		public override string ToString()
		{
			return "HierarchyFlattenedNode(" + ((this == Null) ? "Null" : $"{Node.Id}:{Node.Version}") + ")";
		}

		[ExcludeFromDocs]
		public override bool Equals(object obj)
		{
			return obj is HierarchyFlattenedNode other && Equals(other);
		}

		[ExcludeFromDocs]
		public override int GetHashCode()
		{
			return Node.GetHashCode();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static ref readonly HierarchyNode GetNodeByRef(in HierarchyFlattenedNode hierarchyFlattenedNode)
		{
			return ref hierarchyFlattenedNode.m_Node;
		}
	}
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyNode.h")]
	public readonly struct HierarchyNode : IEquatable<HierarchyNode>
	{
		private const int k_HierarchyNodeIdNull = 0;

		private const int k_HierarchyNodeVersionNull = 0;

		private static readonly HierarchyNode s_Null;

		private readonly int m_Id = 0;

		private readonly int m_Version = 0;

		public static ref readonly HierarchyNode Null => ref s_Null;

		public int Id => m_Id;

		public int Version => m_Version;

		public HierarchyNode()
		{
		}

		[ExcludeFromDocs]
		public static bool operator ==(in HierarchyNode lhs, in HierarchyNode rhs)
		{
			return lhs.Id == rhs.Id && lhs.Version == rhs.Version;
		}

		[ExcludeFromDocs]
		public static bool operator !=(in HierarchyNode lhs, in HierarchyNode rhs)
		{
			return !(lhs == rhs);
		}

		[ExcludeFromDocs]
		public bool Equals(HierarchyNode other)
		{
			return other.Id == Id && other.Version == Version;
		}

		[ExcludeFromDocs]
		public override string ToString()
		{
			return "HierarchyNode(" + ((this == Null) ? "Null" : $"{Id}:{Version}") + ")";
		}

		[ExcludeFromDocs]
		public override bool Equals(object obj)
		{
			return obj is HierarchyNode other && Equals(other);
		}

		[ExcludeFromDocs]
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Version);
		}
	}
	[Flags]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyNodeFlags.h")]
	public enum HierarchyNodeFlags : uint
	{
		None = 0u,
		Expanded = 1u,
		Selected = 2u,
		Cut = 4u,
		Hidden = 8u
	}
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyNodeType.h")]
	public readonly struct HierarchyNodeType : IEquatable<HierarchyNodeType>
	{
		internal const int k_HierarchyNodeTypeNull = 0;

		private static readonly HierarchyNodeType s_Null;

		private readonly int m_Id;

		public static ref readonly HierarchyNodeType Null => ref s_Null;

		public int Id => m_Id;

		public HierarchyNodeType()
		{
			m_Id = 0;
		}

		internal HierarchyNodeType(int id)
		{
			m_Id = id;
		}

		[ExcludeFromDocs]
		public static bool operator ==(in HierarchyNodeType lhs, in HierarchyNodeType rhs)
		{
			return lhs.Id == rhs.Id;
		}

		[ExcludeFromDocs]
		public static bool operator !=(in HierarchyNodeType lhs, in HierarchyNodeType rhs)
		{
			return !(lhs == rhs);
		}

		[ExcludeFromDocs]
		public bool Equals(HierarchyNodeType other)
		{
			return other.Id == Id;
		}

		[ExcludeFromDocs]
		public override string ToString()
		{
			return string.Format("{0}({1})", "HierarchyNodeType", (this == Null) ? "Null" : ((object)Id));
		}

		[ExcludeFromDocs]
		public override bool Equals(object obj)
		{
			return obj is HierarchyNodeType other && Equals(other);
		}

		[ExcludeFromDocs]
		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyPropertyDescriptor.h")]
	public struct HierarchyPropertyDescriptor
	{
		private int m_Size;

		private HierarchyPropertyStorageType m_Type;

		public int Size
		{
			get
			{
				return m_Size;
			}
			set
			{
				m_Size = value;
			}
		}

		public HierarchyPropertyStorageType Type
		{
			get
			{
				return m_Type;
			}
			set
			{
				m_Type = value;
			}
		}
	}
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyPropertyId.h")]
	internal readonly struct HierarchyPropertyId : IEquatable<HierarchyPropertyId>
	{
		private const int k_HierarchyPropertyIdNull = 0;

		private static readonly HierarchyPropertyId s_Null;

		private readonly int m_Id;

		public static ref readonly HierarchyPropertyId Null => ref s_Null;

		public int Id => m_Id;

		public HierarchyPropertyId()
		{
			m_Id = 0;
		}

		internal HierarchyPropertyId(int id)
		{
			m_Id = id;
		}

		public static bool operator ==(in HierarchyPropertyId lhs, in HierarchyPropertyId rhs)
		{
			return lhs.Id == rhs.Id;
		}

		public static bool operator !=(in HierarchyPropertyId lhs, in HierarchyPropertyId rhs)
		{
			return !(lhs == rhs);
		}

		public bool Equals(HierarchyPropertyId other)
		{
			return other.Id == Id;
		}

		public override string ToString()
		{
			return string.Format("{0}({1})", "HierarchyPropertyId", (this == Null) ? "Null" : ((object)Id));
		}

		public override bool Equals(object obj)
		{
			return obj is HierarchyPropertyId other && Equals(other);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyPropertyStorageType.h")]
	public enum HierarchyPropertyStorageType
	{
		Sparse = 0,
		Dense = 1,
		Blob = 2,
		Default = 1
	}
	[NativeHeader("Modules/HierarchyCore/Public/HierarchySearch.h")]
	public enum HierarchySearchFilterOperator
	{
		Equal,
		Contains,
		Greater,
		GreaterOrEqual,
		Lesser,
		LesserOrEqual,
		NotEqual,
		Not
	}
	[Serializable]
	[RequiredByNativeCode]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchySearch.h")]
	public struct HierarchySearchFilter
	{
		private static readonly char[] s_WhiteSpaces = new char[3] { ' ', '\t', '\n' };

		private static readonly HierarchySearchFilter s_Invalid;

		public static ref readonly HierarchySearchFilter Invalid => ref s_Invalid;

		public bool IsValid => !string.IsNullOrEmpty(Name);

		public string Name { get; set; }

		public string Value { get; set; }

		public float NumValue { get; set; }

		public HierarchySearchFilterOperator Op { get; set; }

		public static string ToString(HierarchySearchFilterOperator op)
		{
			return op switch
			{
				HierarchySearchFilterOperator.Equal => "=", 
				HierarchySearchFilterOperator.Contains => ":", 
				HierarchySearchFilterOperator.Greater => ">", 
				HierarchySearchFilterOperator.GreaterOrEqual => ">=", 
				HierarchySearchFilterOperator.Lesser => "<", 
				HierarchySearchFilterOperator.LesserOrEqual => "<=", 
				HierarchySearchFilterOperator.NotEqual => "!=", 
				HierarchySearchFilterOperator.Not => "-", 
				_ => throw new NotImplementedException($"Cannot convert {op} to string"), 
			};
		}

		public static HierarchySearchFilterOperator ToOp(string op)
		{
			return op switch
			{
				"<" => HierarchySearchFilterOperator.Lesser, 
				"<=" => HierarchySearchFilterOperator.LesserOrEqual, 
				">" => HierarchySearchFilterOperator.Greater, 
				">=" => HierarchySearchFilterOperator.GreaterOrEqual, 
				"=" => HierarchySearchFilterOperator.Equal, 
				":" => HierarchySearchFilterOperator.Contains, 
				"!=" => HierarchySearchFilterOperator.NotEqual, 
				"-" => HierarchySearchFilterOperator.Not, 
				_ => throw new NotImplementedException("Cannot convert " + op + " to SearchFilterOperator"), 
			};
		}

		public override string ToString()
		{
			string s = (float.IsNaN(NumValue) ? Value : NumValue.ToString());
			return Name + ToString(Op) + QuoteStringIfNeeded(s);
		}

		[VisibleToOtherModules(new string[] { "UnityEditor.HierarchyModule" })]
		internal static HierarchySearchFilter CreateFilter(string name, string op, string value)
		{
			return CreateFilter(name, ToOp(op), value);
		}

		internal static HierarchySearchFilter CreateFilter(string name, HierarchySearchFilterOperator op, string str)
		{
			string value = str;
			float numValue = float.NaN;
			try
			{
				numValue = Convert.ToSingle(str);
				value = null;
			}
			catch (Exception)
			{
			}
			return new HierarchySearchFilter
			{
				Name = name,
				Op = op,
				Value = value,
				NumValue = numValue
			};
		}

		internal static string QuoteStringIfNeeded(string s)
		{
			if (s.Length > 0 && s.IndexOfAny(s_WhiteSpaces) != -1 && s[0] != '"')
			{
				return "\"" + s + "\"";
			}
			return s;
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[RequiredByNativeCode]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchySearch.h")]
	[NativeAsStruct]
	public sealed class HierarchySearchQueryDescriptor
	{
		private static readonly HashSet<string> s_SystemFilters = new HashSet<string>(new string[2] { "nodetype", "strict" });

		private static readonly HierarchySearchQueryDescriptor s_Empty = new HierarchySearchQueryDescriptor();

		private static readonly HierarchySearchQueryDescriptor s_InvalidQuery = new HierarchySearchQueryDescriptor
		{
			Invalid = true
		};

		public static HierarchySearchQueryDescriptor Empty => s_Empty;

		public static HierarchySearchQueryDescriptor InvalidQuery => s_InvalidQuery;

		public HierarchySearchFilter[] SystemFilters { get; set; }

		public HierarchySearchFilter[] Filters { get; set; }

		public string[] TextValues { get; set; }

		public bool Strict { get; set; }

		public bool Invalid { get; set; }

		public bool IsValid => !Invalid && !IsEmpty;

		public bool IsEmpty => Filters.Length == 0 && TextValues.Length == 0 && SystemFilters.Length == 0;

		public bool IsSystemOnlyQuery => SystemFilters.Length != 0 && Filters.Length == 0 && TextValues.Length == 0;

		public HierarchySearchQueryDescriptor(HierarchySearchFilter[] filters = null, string[] textValues = null)
		{
			filters = filters ?? new HierarchySearchFilter[0];
			textValues = textValues ?? new string[0];
			Filters = Where(filters, (HierarchySearchFilter f) => !s_SystemFilters.Contains(f.Name));
			SystemFilters = Where(filters, (HierarchySearchFilter f) => s_SystemFilters.Contains(f.Name));
			TextValues = textValues;
			HierarchySearchFilter hierarchySearchFilter = HierarchySearchFilter.Invalid;
			HierarchySearchFilter[] systemFilters = SystemFilters;
			for (int num = 0; num < systemFilters.Length; num++)
			{
				HierarchySearchFilter hierarchySearchFilter2 = systemFilters[num];
				if (hierarchySearchFilter2.Name == "strict")
				{
					hierarchySearchFilter = hierarchySearchFilter2;
					break;
				}
			}
			Invalid = false;
			Strict = !hierarchySearchFilter.IsValid || hierarchySearchFilter.Value == "true";
		}

		public HierarchySearchQueryDescriptor(HierarchySearchQueryDescriptor desc)
		{
			SystemFilters = new HierarchySearchFilter[desc.SystemFilters.Length];
			Array.Copy(desc.SystemFilters, SystemFilters, desc.SystemFilters.Length);
			Filters = new HierarchySearchFilter[desc.Filters.Length];
			Array.Copy(desc.Filters, Filters, desc.Filters.Length);
			TextValues = new string[desc.TextValues.Length];
			Array.Copy(desc.TextValues, TextValues, desc.TextValues.Length);
			Strict = desc.Strict;
			Invalid = desc.Invalid;
		}

		public override string ToString()
		{
			return BuildQuery();
		}

		[VisibleToOtherModules(new string[] { "UnityEditor.HierarchyModule" })]
		internal string BuildFilterQuery()
		{
			return string.Join(" ", Filters);
		}

		internal string BuildSystemFilterQuery()
		{
			return string.Join(" ", SystemFilters);
		}

		internal string BuildTextQuery()
		{
			string[] array = new string[TextValues.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = HierarchySearchFilter.QuoteStringIfNeeded(TextValues[i]);
			}
			return string.Join(" ", array);
		}

		internal string BuildQuery()
		{
			string text = "";
			if (SystemFilters.Length != 0)
			{
				text += BuildSystemFilterQuery();
			}
			if (Filters.Length != 0)
			{
				if (text.Length > 0)
				{
					text += " ";
				}
				text += BuildFilterQuery();
			}
			if (TextValues.Length != 0)
			{
				if (text.Length > 0)
				{
					text += " ";
				}
				text += BuildTextQuery();
			}
			return text;
		}

		private static T[] Where<T>(IEnumerable<T> src, Func<T, bool> pred)
		{
			int num = 0;
			foreach (T item in src)
			{
				if (pred(item))
				{
					num++;
				}
			}
			T[] array = new T[num];
			int num2 = 0;
			foreach (T item2 in src)
			{
				if (pred(item2))
				{
					array[num2++] = item2;
				}
			}
			return array;
		}
	}
	[NativeHeader("Modules/HierarchyCore/HierarchyTestsHelper.h")]
	internal static class HierarchyTestsHelper
	{
		[NativeHeader("Modules/HierarchyCore/HierarchyTestsHelper.h")]
		internal enum SortOrder
		{
			Ascending,
			Descending
		}

		internal delegate void ForEachDelegate(in HierarchyNode node, int index);

		[NativeMethod(IsThreadSafe = true)]
		internal static int GenerateNodesTree(Hierarchy hierarchy, in HierarchyNode root, int width, int depth, int maxCount = 0)
		{
			return GenerateNodesTree_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), in root, width, depth, maxCount);
		}

		[NativeMethod(IsThreadSafe = true)]
		internal static void GenerateNodesCount(Hierarchy hierarchy, in HierarchyNode root, int count, int width, int depth)
		{
			GenerateNodesCount_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), in root, count, width, depth);
		}

		[NativeMethod(IsThreadSafe = true)]
		internal static void GenerateSortIndex(Hierarchy hierarchy, in HierarchyNode root, SortOrder order)
		{
			GenerateSortIndex_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), in root, order);
		}

		internal unsafe static void ForEach(Hierarchy hierarchy, in HierarchyNode root, ForEachDelegate func)
		{
			Stack<HierarchyNode> stack = new Stack<HierarchyNode>();
			stack.Push(root);
			using NativeArray<HierarchyNode> nativeArray = new NativeArray<HierarchyNode>(hierarchy.Count, Allocator.Temp);
			while (stack.Count > 0)
			{
				HierarchyNode node = stack.Pop();
				int childrenCount = hierarchy.GetChildrenCount(in node);
				Span<HierarchyNode> outChildren = new Span<HierarchyNode>(nativeArray.GetUnsafePtr(), childrenCount);
				int children = hierarchy.GetChildren(in node, outChildren);
				if (children != childrenCount)
				{
					throw new InvalidOperationException($"Expected GetChildren to return {childrenCount}, but was {children}.");
				}
				int i = 0;
				for (int length = outChildren.Length; i < length; i++)
				{
					HierarchyNode node2 = outChildren[i];
					func(in node2, i);
					stack.Push(node2);
				}
			}
		}

		[NativeMethod(IsThreadSafe = true)]
		internal static void SetNextHierarchyNodeId(Hierarchy hierarchy, int id)
		{
			SetNextHierarchyNodeId_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), id);
		}

		internal static int GetNodeType<T>() where T : HierarchyNodeTypeHandlerBase
		{
			return GetNodeType(typeof(T));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		private static extern int GetNodeType(Type type);

		[NativeMethod(IsThreadSafe = true)]
		internal static int[] GetRegisteredNodeTypes(Hierarchy hierarchy)
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			int[] result;
			try
			{
				GetRegisteredNodeTypes_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), out ret);
			}
			finally
			{
				int[] array = default(int[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}

		[NativeMethod(IsThreadSafe = true)]
		internal static int GetCapacity(Hierarchy hierarchy)
		{
			return GetCapacity_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy));
		}

		[NativeMethod(IsThreadSafe = true)]
		internal static int GetVersion(Hierarchy hierarchy)
		{
			return GetVersion_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy));
		}

		[NativeMethod(IsThreadSafe = true)]
		internal static int GetChildrenCapacity(Hierarchy hierarchy, in HierarchyNode node)
		{
			return GetChildrenCapacity_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy), in node);
		}

		internal static bool SearchMatch(HierarchyViewModel model, in HierarchyNode node)
		{
			return model.Hierarchy.GetNodeTypeHandlerBase(in node)?.Internal_SearchMatch(in node) ?? false;
		}

		[NativeMethod(IsThreadSafe = true)]
		internal static object GetHierarchyScriptingObject(Hierarchy hierarchy)
		{
			return GetHierarchyScriptingObject_Injected((hierarchy == null) ? ((IntPtr)0) : Hierarchy.BindingsMarshaller.ConvertToNative(hierarchy));
		}

		[NativeMethod(IsThreadSafe = true)]
		internal static object GetHierarchyFlattenedScriptingObject(HierarchyFlattened hierarchyFlattened)
		{
			return GetHierarchyFlattenedScriptingObject_Injected((hierarchyFlattened == null) ? ((IntPtr)0) : HierarchyFlattened.BindingsMarshaller.ConvertToNative(hierarchyFlattened));
		}

		[NativeMethod(IsThreadSafe = true)]
		internal static object GetHierarchyViewModelScriptingObject(HierarchyViewModel viewModel)
		{
			return GetHierarchyViewModelScriptingObject_Injected((viewModel == null) ? ((IntPtr)0) : HierarchyViewModel.BindingsMarshaller.ConvertToNative(viewModel));
		}

		[NativeMethod(IsThreadSafe = true)]
		internal static object GetHierarchyCommandListScriptingObject(HierarchyCommandList cmdList)
		{
			return GetHierarchyCommandListScriptingObject_Injected((cmdList == null) ? ((IntPtr)0) : HierarchyCommandList.BindingsMarshaller.ConvertToNative(cmdList));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GenerateNodesTree_Injected(IntPtr hierarchy, in HierarchyNode root, int width, int depth, int maxCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GenerateNodesCount_Injected(IntPtr hierarchy, in HierarchyNode root, int count, int width, int depth);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GenerateSortIndex_Injected(IntPtr hierarchy, in HierarchyNode root, SortOrder order);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetNextHierarchyNodeId_Injected(IntPtr hierarchy, int id);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRegisteredNodeTypes_Injected(IntPtr hierarchy, out BlittableArrayWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetCapacity_Injected(IntPtr hierarchy);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetVersion_Injected(IntPtr hierarchy);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetChildrenCapacity_Injected(IntPtr hierarchy, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern object GetHierarchyScriptingObject_Injected(IntPtr hierarchy);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern object GetHierarchyFlattenedScriptingObject_Injected(IntPtr hierarchyFlattened);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern object GetHierarchyViewModelScriptingObject_Injected(IntPtr viewModel);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern object GetHierarchyCommandListScriptingObject_Injected(IntPtr cmdList);
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyViewModel.h")]
	[NativeHeader("Modules/HierarchyCore/HierarchyViewModelBindings.h")]
	[RequiredByNativeCode(GenerateProxy = true)]
	public sealed class HierarchyViewModel : IDisposable
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(HierarchyViewModel viewModel)
			{
				return viewModel.m_Ptr;
			}
		}

		public struct Enumerator
		{
			private readonly HierarchyViewModel m_ViewModel;

			private readonly HierarchyFlattened m_HierarchyFlattened;

			private unsafe readonly int* m_NodesPtr;

			private readonly int m_NodesCount;

			private readonly int m_Version;

			private int m_Index;

			public unsafe ref readonly HierarchyNode Current
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					if (m_Version != m_ViewModel.m_Version)
					{
						throw new InvalidOperationException("HierarchyViewModel was modified.");
					}
					return ref HierarchyFlattenedNode.GetNodeByRef(in m_HierarchyFlattened[m_NodesPtr[m_Index]]);
				}
			}

			internal unsafe Enumerator(HierarchyViewModel hierarchyViewModel)
			{
				m_ViewModel = hierarchyViewModel;
				m_HierarchyFlattened = hierarchyViewModel.HierarchyFlattened;
				m_NodesPtr = (int*)(void*)hierarchyViewModel.m_NodesPtr;
				m_NodesCount = hierarchyViewModel.Count;
				m_Version = hierarchyViewModel.Version;
				m_Index = -1;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				return ++m_Index < m_NodesCount;
			}
		}

		private IntPtr m_Ptr;

		private readonly Hierarchy m_Hierarchy;

		private readonly HierarchyFlattened m_HierarchyFlattened;

		private IntPtr m_NodesPtr;

		private int m_NodesCount;

		private int m_Version;

		private readonly bool m_IsOwner;

		public bool IsCreated => m_Ptr != IntPtr.Zero;

		public int Count => m_NodesCount;

		public bool Updating
		{
			[NativeMethod("Updating", IsThreadSafe = true)]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_Updating_Injected(intPtr);
			}
		}

		public bool UpdateNeeded
		{
			[NativeMethod("UpdateNeeded", IsThreadSafe = true)]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_UpdateNeeded_Injected(intPtr);
			}
		}

		public HierarchyFlattened HierarchyFlattened => m_HierarchyFlattened;

		public Hierarchy Hierarchy => m_Hierarchy;

		internal unsafe int* NodesPtr => (int*)(void*)m_NodesPtr;

		internal int Version
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[VisibleToOtherModules(new string[] { "UnityEngine.HierarchyModule" })]
			get
			{
				return m_Version;
			}
		}

		internal float UpdateProgress
		{
			[VisibleToOtherModules(new string[] { "UnityEngine.HierarchyModule" })]
			[NativeMethod("UpdateProgress", IsThreadSafe = true)]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_UpdateProgress_Injected(intPtr);
			}
		}

		internal IHierarchySearchQueryParser QueryParser
		{
			[VisibleToOtherModules(new string[] { "UnityEditor.HierarchyModule" })]
			get;
			[VisibleToOtherModules(new string[] { "UnityEditor.HierarchyModule" })]
			set;
		}

		internal HierarchySearchQueryDescriptor Query
		{
			[NativeMethod(IsThreadSafe = true)]
			[VisibleToOtherModules(new string[] { "UnityEngine.HierarchyModule" })]
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_Query_Injected(intPtr);
			}
			[VisibleToOtherModules(new string[] { "UnityEngine.HierarchyModule" })]
			[NativeMethod(IsThreadSafe = true)]
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_Query_Injected(intPtr, value);
			}
		}

		public unsafe ref readonly HierarchyNode this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (index < 0 || index >= m_NodesCount)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return ref HierarchyFlattenedNode.GetNodeByRef(in m_HierarchyFlattened[((int*)(void*)m_NodesPtr)[index]]);
			}
		}

		public HierarchyViewModel(HierarchyFlattened hierarchyFlattened, HierarchyNodeFlags defaultFlags = HierarchyNodeFlags.None)
		{
			m_Ptr = Create(GCHandle.ToIntPtr(GCHandle.Alloc(this)), hierarchyFlattened, defaultFlags, out var nodesPtr, out var nodesCount, out var version);
			m_Hierarchy = hierarchyFlattened.Hierarchy;
			m_HierarchyFlattened = hierarchyFlattened;
			m_NodesPtr = nodesPtr;
			m_NodesCount = nodesCount;
			m_Version = version;
			m_IsOwner = true;
			QueryParser = new DefaultHierarchySearchQueryParser();
		}

		private HierarchyViewModel(IntPtr nativePtr, HierarchyFlattened hierarchyFlattened, IntPtr nodesPtr, int nodesCount, int version)
		{
			m_Ptr = nativePtr;
			m_Hierarchy = hierarchyFlattened.Hierarchy;
			m_HierarchyFlattened = hierarchyFlattened;
			m_NodesPtr = nodesPtr;
			m_NodesCount = nodesCount;
			m_Version = version;
			m_IsOwner = false;
			QueryParser = new DefaultHierarchySearchQueryParser();
		}

		~HierarchyViewModel()
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
				if (m_IsOwner)
				{
					Destroy(m_Ptr);
				}
				m_Ptr = IntPtr.Zero;
			}
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int IndexOf(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IndexOf_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public bool Contains(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Contains_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public HierarchyNode GetParent(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetParent_Injected(intPtr, in node, out var ret);
			return ret;
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public HierarchyNode GetNextSibling(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetNextSibling_Injected(intPtr, in node, out var ret);
			return ret;
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int GetChildrenCount(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetChildrenCount_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int GetChildrenCountRecursive(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetChildrenCountRecursive_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int GetDepth(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetDepth_Injected(intPtr, in node);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public HierarchyNodeFlags GetFlags(in HierarchyNode node)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetFlags_Injected(intPtr, in node);
		}

		public void SetFlags(HierarchyNodeFlags flags)
		{
			SetFlagsAll(flags);
		}

		public void SetFlags(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false)
		{
			SetFlagsNode(in node, flags, recurse);
		}

		public int SetFlags(ReadOnlySpan<HierarchyNode> nodes, HierarchyNodeFlags flags)
		{
			return SetFlagsNodes(nodes, flags);
		}

		public int SetFlags(ReadOnlySpan<int> indices, HierarchyNodeFlags flags)
		{
			return SetFlagsIndices(indices, flags);
		}

		public bool HasAllFlags(HierarchyNodeFlags flags)
		{
			return HasAllFlagsAny(flags);
		}

		public bool HasAnyFlags(HierarchyNodeFlags flags)
		{
			return HasAnyFlagsAny(flags);
		}

		public bool HasAllFlags(in HierarchyNode node, HierarchyNodeFlags flags)
		{
			return HasAllFlagsNode(in node, flags);
		}

		public bool HasAnyFlags(in HierarchyNode node, HierarchyNodeFlags flags)
		{
			return HasAnyFlagsNode(in node, flags);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int HasAllFlagsCount(HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasAllFlagsCount_Injected(intPtr, flags);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int HasAnyFlagsCount(HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasAnyFlagsCount_Injected(intPtr, flags);
		}

		public bool DoesNotHaveAllFlags(HierarchyNodeFlags flags)
		{
			return DoesNotHaveAllFlagsAny(flags);
		}

		public bool DoesNotHaveAnyFlags(HierarchyNodeFlags flags)
		{
			return DoesNotHaveAnyFlagsAny(flags);
		}

		public bool DoesNotHaveAllFlags(in HierarchyNode node, HierarchyNodeFlags flags)
		{
			return DoesNotHaveAllFlagsNode(in node, flags);
		}

		public bool DoesNotHaveAnyFlags(in HierarchyNode node, HierarchyNodeFlags flags)
		{
			return DoesNotHaveAnyFlagsNode(in node, flags);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int DoesNotHaveAllFlagsCount(HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return DoesNotHaveAllFlagsCount_Injected(intPtr, flags);
		}

		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public int DoesNotHaveAnyFlagsCount(HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return DoesNotHaveAnyFlagsCount_Injected(intPtr, flags);
		}

		public void ClearFlags(HierarchyNodeFlags flags)
		{
			ClearFlagsAll(flags);
		}

		public void ClearFlags(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false)
		{
			ClearFlagsNode(in node, flags, recurse);
		}

		public int ClearFlags(ReadOnlySpan<HierarchyNode> nodes, HierarchyNodeFlags flags)
		{
			return ClearFlagsNodes(nodes, flags);
		}

		public int ClearFlags(ReadOnlySpan<int> indices, HierarchyNodeFlags flags)
		{
			return ClearFlagsIndices(indices, flags);
		}

		public void ToggleFlags(HierarchyNodeFlags flags)
		{
			ToggleFlagsAll(flags);
		}

		public void ToggleFlags(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false)
		{
			ToggleFlagsNode(in node, flags, recurse);
		}

		public int ToggleFlags(ReadOnlySpan<HierarchyNode> nodes, HierarchyNodeFlags flags)
		{
			return ToggleFlagsNodes(nodes, flags);
		}

		public int ToggleFlags(ReadOnlySpan<int> indices, HierarchyNodeFlags flags)
		{
			return ToggleFlagsIndices(indices, flags);
		}

		public int GetNodesWithAllFlags(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
		{
			return GetNodesWithAllFlagsSpan(flags, outNodes);
		}

		public int GetNodesWithAnyFlags(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
		{
			return GetNodesWithAnyFlagsSpan(flags, outNodes);
		}

		public HierarchyNode[] GetNodesWithAllFlags(HierarchyNodeFlags flags)
		{
			int num = HasAllFlagsCount(flags);
			if (num == 0)
			{
				return Array.Empty<HierarchyNode>();
			}
			HierarchyNode[] array = new HierarchyNode[num];
			GetNodesWithAllFlagsSpan(flags, array);
			return array;
		}

		public HierarchyNode[] GetNodesWithAnyFlags(HierarchyNodeFlags flags)
		{
			int num = HasAnyFlagsCount(flags);
			if (num == 0)
			{
				return Array.Empty<HierarchyNode>();
			}
			HierarchyNode[] array = new HierarchyNode[num];
			GetNodesWithAnyFlagsSpan(flags, array);
			return array;
		}

		public HierarchyViewNodesEnumerable EnumerateNodesWithAllFlags(HierarchyNodeFlags flags)
		{
			return new HierarchyViewNodesEnumerable(this, flags, HasAllFlags);
		}

		public HierarchyViewNodesEnumerable EnumerateNodesWithAnyFlags(HierarchyNodeFlags flags)
		{
			return new HierarchyViewNodesEnumerable(this, flags, HasAnyFlags);
		}

		public int GetIndicesWithAllFlags(HierarchyNodeFlags flags, Span<int> outIndices)
		{
			return GetIndicesWithAllFlagsSpan(flags, outIndices);
		}

		public int GetIndicesWithAnyFlags(HierarchyNodeFlags flags, Span<int> outIndices)
		{
			return GetIndicesWithAnyFlagsSpan(flags, outIndices);
		}

		public int[] GetIndicesWithAllFlags(HierarchyNodeFlags flags)
		{
			int num = HasAllFlagsCount(flags);
			if (num == 0)
			{
				return Array.Empty<int>();
			}
			int[] array = new int[num];
			GetIndicesWithAllFlagsSpan(flags, array);
			return array;
		}

		public int[] GetIndicesWithAnyFlags(HierarchyNodeFlags flags)
		{
			int num = HasAnyFlagsCount(flags);
			if (num == 0)
			{
				return Array.Empty<int>();
			}
			int[] array = new int[num];
			GetIndicesWithAnyFlagsSpan(flags, array);
			return array;
		}

		public int GetNodesWithoutAllFlags(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
		{
			return GetNodesWithoutAllFlagsSpan(flags, outNodes);
		}

		public int GetNodesWithoutAnyFlags(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
		{
			return GetNodesWithoutAnyFlagsSpan(flags, outNodes);
		}

		public HierarchyNode[] GetNodesWithoutAllFlags(HierarchyNodeFlags flags)
		{
			int num = DoesNotHaveAllFlagsCount(flags);
			if (num == 0)
			{
				return Array.Empty<HierarchyNode>();
			}
			HierarchyNode[] array = new HierarchyNode[num];
			GetNodesWithoutAllFlagsSpan(flags, array);
			return array;
		}

		public HierarchyNode[] GetNodesWithoutAnyFlags(HierarchyNodeFlags flags)
		{
			int num = DoesNotHaveAnyFlagsCount(flags);
			if (num == 0)
			{
				return Array.Empty<HierarchyNode>();
			}
			HierarchyNode[] array = new HierarchyNode[num];
			GetNodesWithoutAnyFlagsSpan(flags, array);
			return array;
		}

		public HierarchyViewNodesEnumerable EnumerateNodesWithoutAllFlags(HierarchyNodeFlags flags)
		{
			return new HierarchyViewNodesEnumerable(this, flags, DoesNotHaveAllFlags);
		}

		public HierarchyViewNodesEnumerable EnumerateNodesWithoutAnyFlags(HierarchyNodeFlags flags)
		{
			return new HierarchyViewNodesEnumerable(this, flags, DoesNotHaveAnyFlags);
		}

		public int GetIndicesWithoutAllFlags(HierarchyNodeFlags flags, Span<int> outIndices)
		{
			return GetIndicesWithoutAllFlagsSpan(flags, outIndices);
		}

		public int GetIndicesWithoutAnyFlags(HierarchyNodeFlags flags, Span<int> outIndices)
		{
			return GetIndicesWithoutAnyFlagsSpan(flags, outIndices);
		}

		public int[] GetIndicesWithoutAllFlags(HierarchyNodeFlags flags)
		{
			int num = DoesNotHaveAllFlagsCount(flags);
			if (num == 0)
			{
				return Array.Empty<int>();
			}
			int[] array = new int[num];
			GetIndicesWithoutAllFlagsSpan(flags, array);
			return array;
		}

		public int[] GetIndicesWithoutAnyFlags(HierarchyNodeFlags flags)
		{
			int num = DoesNotHaveAnyFlagsCount(flags);
			if (num == 0)
			{
				return Array.Empty<int>();
			}
			int[] array = new int[num];
			GetIndicesWithoutAnyFlagsSpan(flags, array);
			return array;
		}

		public void SetQuery(string query)
		{
			HierarchySearchQueryDescriptor hierarchySearchQueryDescriptor = QueryParser.ParseQuery(query);
			if (hierarchySearchQueryDescriptor != Query)
			{
				Query = hierarchySearchQueryDescriptor;
			}
		}

		[NativeMethod(IsThreadSafe = true)]
		public void Update()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Update_Injected(intPtr);
		}

		[NativeMethod(IsThreadSafe = true)]
		public bool UpdateIncremental()
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return UpdateIncremental_Injected(intPtr);
		}

		[NativeMethod(IsThreadSafe = true)]
		public bool UpdateIncrementalTimed(double milliseconds)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return UpdateIncrementalTimed_Injected(intPtr, milliseconds);
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static HierarchyViewModel FromIntPtr(IntPtr handlePtr)
		{
			return (handlePtr != IntPtr.Zero) ? ((HierarchyViewModel)GCHandle.FromIntPtr(handlePtr).Target) : null;
		}

		[FreeFunction("HierarchyViewModelBindings::Create", IsThreadSafe = true)]
		private static IntPtr Create(IntPtr handlePtr, HierarchyFlattened hierarchyFlattened, HierarchyNodeFlags defaultFlags, out IntPtr nodesPtr, out int nodesCount, out int version)
		{
			return Create_Injected(handlePtr, (hierarchyFlattened == null) ? ((IntPtr)0) : HierarchyFlattened.BindingsMarshaller.ConvertToNative(hierarchyFlattened), defaultFlags, out nodesPtr, out nodesCount, out version);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("HierarchyViewModelBindings::Destroy", IsThreadSafe = true)]
		private static extern void Destroy(IntPtr nativePtr);

		[FreeFunction("HierarchyViewModelBindings::SetFlagsAll", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private void SetFlagsAll(HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetFlagsAll_Injected(intPtr, flags);
		}

		[FreeFunction("HierarchyViewModelBindings::SetFlagsNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private void SetFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetFlagsNode_Injected(intPtr, in node, flags, recurse);
		}

		[FreeFunction("HierarchyViewModelBindings::SetFlagsNodes", HasExplicitThis = true, IsThreadSafe = true)]
		private unsafe int SetFlagsNodes(ReadOnlySpan<HierarchyNode> nodes, HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ReadOnlySpan<HierarchyNode> readOnlySpan = nodes;
			int result;
			fixed (HierarchyNode* begin = readOnlySpan)
			{
				ManagedSpanWrapper nodes2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
				result = SetFlagsNodes_Injected(intPtr, ref nodes2, flags);
			}
			return result;
		}

		[FreeFunction("HierarchyViewModelBindings::SetFlagsIndices", HasExplicitThis = true, IsThreadSafe = true)]
		private unsafe int SetFlagsIndices(ReadOnlySpan<int> indices, HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ReadOnlySpan<int> readOnlySpan = indices;
			int result;
			fixed (int* begin = readOnlySpan)
			{
				ManagedSpanWrapper indices2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
				result = SetFlagsIndices_Injected(intPtr, ref indices2, flags);
			}
			return result;
		}

		[FreeFunction("HierarchyViewModelBindings::HasAllFlagsAny", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private bool HasAllFlagsAny(HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasAllFlagsAny_Injected(intPtr, flags);
		}

		[FreeFunction("HierarchyViewModelBindings::HasAnyFlagsAny", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private bool HasAnyFlagsAny(HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasAnyFlagsAny_Injected(intPtr, flags);
		}

		[FreeFunction("HierarchyViewModelBindings::HasAllFlagsNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private bool HasAllFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasAllFlagsNode_Injected(intPtr, in node, flags);
		}

		[FreeFunction("HierarchyViewModelBindings::HasAnyFlagsNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private bool HasAnyFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasAnyFlagsNode_Injected(intPtr, in node, flags);
		}

		[FreeFunction("HierarchyViewModelBindings::DoesNotHaveAllFlagsAny", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private bool DoesNotHaveAllFlagsAny(HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return DoesNotHaveAllFlagsAny_Injected(intPtr, flags);
		}

		[FreeFunction("HierarchyViewModelBindings::DoesNotHaveAnyFlagsAny", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private bool DoesNotHaveAnyFlagsAny(HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return DoesNotHaveAnyFlagsAny_Injected(intPtr, flags);
		}

		[FreeFunction("HierarchyViewModelBindings::DoesNotHaveAllFlagsNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private bool DoesNotHaveAllFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return DoesNotHaveAllFlagsNode_Injected(intPtr, in node, flags);
		}

		[FreeFunction("HierarchyViewModelBindings::DoesNotHaveAnyFlagsNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private bool DoesNotHaveAnyFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return DoesNotHaveAnyFlagsNode_Injected(intPtr, in node, flags);
		}

		[FreeFunction("HierarchyViewModelBindings::ClearFlagsAll", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private void ClearFlagsAll(HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ClearFlagsAll_Injected(intPtr, flags);
		}

		[FreeFunction("HierarchyViewModelBindings::ClearFlagsNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private void ClearFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ClearFlagsNode_Injected(intPtr, in node, flags, recurse);
		}

		[FreeFunction("HierarchyViewModelBindings::ClearFlagsNodes", HasExplicitThis = true, IsThreadSafe = true)]
		private unsafe int ClearFlagsNodes(ReadOnlySpan<HierarchyNode> nodes, HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ReadOnlySpan<HierarchyNode> readOnlySpan = nodes;
			int result;
			fixed (HierarchyNode* begin = readOnlySpan)
			{
				ManagedSpanWrapper nodes2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
				result = ClearFlagsNodes_Injected(intPtr, ref nodes2, flags);
			}
			return result;
		}

		[FreeFunction("HierarchyViewModelBindings::ClearFlagsIndices", HasExplicitThis = true, IsThreadSafe = true)]
		private unsafe int ClearFlagsIndices(ReadOnlySpan<int> indices, HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ReadOnlySpan<int> readOnlySpan = indices;
			int result;
			fixed (int* begin = readOnlySpan)
			{
				ManagedSpanWrapper indices2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
				result = ClearFlagsIndices_Injected(intPtr, ref indices2, flags);
			}
			return result;
		}

		[FreeFunction("HierarchyViewModelBindings::ToggleFlagsAll", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private void ToggleFlagsAll(HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ToggleFlagsAll_Injected(intPtr, flags);
		}

		[FreeFunction("HierarchyViewModelBindings::ToggleFlagsNode", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private void ToggleFlagsNode(in HierarchyNode node, HierarchyNodeFlags flags, bool recurse = false)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ToggleFlagsNode_Injected(intPtr, in node, flags, recurse);
		}

		[FreeFunction("HierarchyViewModelBindings::ToggleFlagsNodes", HasExplicitThis = true, IsThreadSafe = true)]
		private unsafe int ToggleFlagsNodes(ReadOnlySpan<HierarchyNode> nodes, HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ReadOnlySpan<HierarchyNode> readOnlySpan = nodes;
			int result;
			fixed (HierarchyNode* begin = readOnlySpan)
			{
				ManagedSpanWrapper nodes2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
				result = ToggleFlagsNodes_Injected(intPtr, ref nodes2, flags);
			}
			return result;
		}

		[FreeFunction("HierarchyViewModelBindings::ToggleFlagsIndices", HasExplicitThis = true, IsThreadSafe = true)]
		private unsafe int ToggleFlagsIndices(ReadOnlySpan<int> indices, HierarchyNodeFlags flags)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ReadOnlySpan<int> readOnlySpan = indices;
			int result;
			fixed (int* begin = readOnlySpan)
			{
				ManagedSpanWrapper indices2 = new ManagedSpanWrapper(begin, readOnlySpan.Length);
				result = ToggleFlagsIndices_Injected(intPtr, ref indices2, flags);
			}
			return result;
		}

		[FreeFunction("HierarchyViewModelBindings::GetNodesWithAllFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe int GetNodesWithAllFlagsSpan(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<HierarchyNode> span = outNodes;
			int nodesWithAllFlagsSpan_Injected;
			fixed (HierarchyNode* begin = span)
			{
				ManagedSpanWrapper outNodes2 = new ManagedSpanWrapper(begin, span.Length);
				nodesWithAllFlagsSpan_Injected = GetNodesWithAllFlagsSpan_Injected(intPtr, flags, ref outNodes2);
			}
			return nodesWithAllFlagsSpan_Injected;
		}

		[FreeFunction("HierarchyViewModelBindings::GetNodesWithAnyFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe int GetNodesWithAnyFlagsSpan(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<HierarchyNode> span = outNodes;
			int nodesWithAnyFlagsSpan_Injected;
			fixed (HierarchyNode* begin = span)
			{
				ManagedSpanWrapper outNodes2 = new ManagedSpanWrapper(begin, span.Length);
				nodesWithAnyFlagsSpan_Injected = GetNodesWithAnyFlagsSpan_Injected(intPtr, flags, ref outNodes2);
			}
			return nodesWithAnyFlagsSpan_Injected;
		}

		[FreeFunction("HierarchyViewModelBindings::GetIndicesWithAllFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe int GetIndicesWithAllFlagsSpan(HierarchyNodeFlags flags, Span<int> outIndices)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<int> span = outIndices;
			int indicesWithAllFlagsSpan_Injected;
			fixed (int* begin = span)
			{
				ManagedSpanWrapper outIndices2 = new ManagedSpanWrapper(begin, span.Length);
				indicesWithAllFlagsSpan_Injected = GetIndicesWithAllFlagsSpan_Injected(intPtr, flags, ref outIndices2);
			}
			return indicesWithAllFlagsSpan_Injected;
		}

		[FreeFunction("HierarchyViewModelBindings::GetIndicesWithAnyFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe int GetIndicesWithAnyFlagsSpan(HierarchyNodeFlags flags, Span<int> outIndices)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<int> span = outIndices;
			int indicesWithAnyFlagsSpan_Injected;
			fixed (int* begin = span)
			{
				ManagedSpanWrapper outIndices2 = new ManagedSpanWrapper(begin, span.Length);
				indicesWithAnyFlagsSpan_Injected = GetIndicesWithAnyFlagsSpan_Injected(intPtr, flags, ref outIndices2);
			}
			return indicesWithAnyFlagsSpan_Injected;
		}

		[FreeFunction("HierarchyViewModelBindings::GetNodesWithoutAllFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe int GetNodesWithoutAllFlagsSpan(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<HierarchyNode> span = outNodes;
			int nodesWithoutAllFlagsSpan_Injected;
			fixed (HierarchyNode* begin = span)
			{
				ManagedSpanWrapper outNodes2 = new ManagedSpanWrapper(begin, span.Length);
				nodesWithoutAllFlagsSpan_Injected = GetNodesWithoutAllFlagsSpan_Injected(intPtr, flags, ref outNodes2);
			}
			return nodesWithoutAllFlagsSpan_Injected;
		}

		[FreeFunction("HierarchyViewModelBindings::GetNodesWithoutAnyFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe int GetNodesWithoutAnyFlagsSpan(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<HierarchyNode> span = outNodes;
			int nodesWithoutAnyFlagsSpan_Injected;
			fixed (HierarchyNode* begin = span)
			{
				ManagedSpanWrapper outNodes2 = new ManagedSpanWrapper(begin, span.Length);
				nodesWithoutAnyFlagsSpan_Injected = GetNodesWithoutAnyFlagsSpan_Injected(intPtr, flags, ref outNodes2);
			}
			return nodesWithoutAnyFlagsSpan_Injected;
		}

		[FreeFunction("HierarchyViewModelBindings::GetIndicesWithoutAllFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe int GetIndicesWithoutAllFlagsSpan(HierarchyNodeFlags flags, Span<int> outIndices)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<int> span = outIndices;
			int indicesWithoutAllFlagsSpan_Injected;
			fixed (int* begin = span)
			{
				ManagedSpanWrapper outIndices2 = new ManagedSpanWrapper(begin, span.Length);
				indicesWithoutAllFlagsSpan_Injected = GetIndicesWithoutAllFlagsSpan_Injected(intPtr, flags, ref outIndices2);
			}
			return indicesWithoutAllFlagsSpan_Injected;
		}

		[FreeFunction("HierarchyViewModelBindings::GetIndicesWithoutAnyFlagsSpan", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private unsafe int GetIndicesWithoutAnyFlagsSpan(HierarchyNodeFlags flags, Span<int> outIndices)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<int> span = outIndices;
			int indicesWithoutAnyFlagsSpan_Injected;
			fixed (int* begin = span)
			{
				ManagedSpanWrapper outIndices2 = new ManagedSpanWrapper(begin, span.Length);
				indicesWithoutAnyFlagsSpan_Injected = GetIndicesWithoutAnyFlagsSpan_Injected(intPtr, flags, ref outIndices2);
			}
			return indicesWithoutAnyFlagsSpan_Injected;
		}

		[RequiredByNativeCode]
		private static IntPtr CreateHierarchyViewModel(IntPtr nativePtr, IntPtr flattenedPtr, IntPtr nodesPtr, int nodesCount, int version)
		{
			return GCHandle.ToIntPtr(GCHandle.Alloc(new HierarchyViewModel(nativePtr, HierarchyFlattened.FromIntPtr(flattenedPtr), nodesPtr, nodesCount, version)));
		}

		[RequiredByNativeCode]
		private static void UpdateHierarchyViewModel(IntPtr handlePtr, IntPtr nodesPtr, int nodesCount, int version)
		{
			HierarchyViewModel hierarchyViewModel = FromIntPtr(handlePtr);
			hierarchyViewModel.m_NodesPtr = nodesPtr;
			hierarchyViewModel.m_NodesCount = nodesCount;
			hierarchyViewModel.m_Version = version;
		}

		[RequiredByNativeCode]
		private static void SearchBegin(IntPtr handlePtr)
		{
			HierarchyViewModel hierarchyViewModel = FromIntPtr(handlePtr);
			foreach (HierarchyNodeTypeHandlerBase item in hierarchyViewModel.m_Hierarchy.EnumerateNodeTypeHandlersBase())
			{
				item.Internal_SearchBegin(hierarchyViewModel.Query);
			}
		}

		[Obsolete("HasFlags is obsolete, please use HasAllFlags or HasAnyFlags instead", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasFlags(HierarchyNodeFlags flags)
		{
			return HasAllFlagsAny(flags);
		}

		[Obsolete("HasFlags is obsolete, please use HasAllFlags or HasAnyFlags instead", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasFlags(in HierarchyNode node, HierarchyNodeFlags flags)
		{
			return HasAllFlagsNode(in node, flags);
		}

		[Obsolete("HasFlagsCount is obsolete, please use HasAllFlagsCount or HasAnyFlagsCount instead", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HasFlagsCount(HierarchyNodeFlags flags)
		{
			return HasAllFlagsCount(flags);
		}

		[Obsolete("DoesNotHaveFlags is obsolete, please use DoesNotHaveAllFlags or DoesNotHaveAnyFlags instead", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool DoesNotHaveFlags(HierarchyNodeFlags flags)
		{
			return DoesNotHaveAllFlagsAny(flags);
		}

		[Obsolete("DoesNotHaveFlags is obsolete, please use DoesNotHaveAllFlags or DoesNotHaveAnyFlags instead", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool DoesNotHaveFlags(in HierarchyNode node, HierarchyNodeFlags flags)
		{
			return DoesNotHaveAllFlagsNode(in node, flags);
		}

		[Obsolete("DoesNotHaveFlagsCount is obsolete, please use DoesNotHaveAllFlagsCount or DoesNotHaveAnyFlagsCount instead", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DoesNotHaveFlagsCount(HierarchyNodeFlags flags)
		{
			return DoesNotHaveAllFlagsCount(flags);
		}

		[Obsolete("GetNodesWithFlags is obsolete, please use GetNodesWithAllFlags or GetNodesWithAnyFlags instead", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetNodesWithFlags(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
		{
			return GetNodesWithAllFlagsSpan(flags, outNodes);
		}

		[Obsolete("GetNodesWithFlags is obsolete, please use GetNodesWithAllFlags or GetNodesWithAnyFlags instead", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HierarchyNode[] GetNodesWithFlags(HierarchyNodeFlags flags)
		{
			return GetNodesWithAllFlags(flags);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("EnumerateNodesWithFlags is obsolete, please use EnumerateNodesWithAllFlags or EnumerateNodesWithAnyFlags instead", false)]
		public HierarchyViewNodesEnumerable EnumerateNodesWithFlags(HierarchyNodeFlags flags)
		{
			return EnumerateNodesWithAllFlags(flags);
		}

		[Obsolete("GetIndicesWithFlags is obsolete, please use GetIndicesWithAllFlags or GetIndicesWithAnyFlags instead", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetIndicesWithFlags(HierarchyNodeFlags flags, Span<int> outIndices)
		{
			return GetIndicesWithAllFlagsSpan(flags, outIndices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("GetIndicesWithFlags is obsolete, please use GetIndicesWithAllFlags or GetIndicesWithAnyFlags instead", false)]
		public int[] GetIndicesWithFlags(HierarchyNodeFlags flags)
		{
			return GetIndicesWithAllFlags(flags);
		}

		[Obsolete("GetNodesWithoutFlags is obsolete, please use GetNodesWithoutAllFlags or GetNodesWithoutAnyFlags instead", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetNodesWithoutFlags(HierarchyNodeFlags flags, Span<HierarchyNode> outNodes)
		{
			return GetNodesWithoutAllFlagsSpan(flags, outNodes);
		}

		[Obsolete("GetNodesWithoutFlags is obsolete, please use GetNodesWithoutAllFlags or GetNodesWithoutAnyFlags instead", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HierarchyNode[] GetNodesWithoutFlags(HierarchyNodeFlags flags)
		{
			return GetNodesWithoutAllFlags(flags);
		}

		[Obsolete("EnumerateNodesWithoutFlags is obsolete, please use EnumerateNodesWithoutAllFlags or EnumerateNodesWithoutAnyFlags instead", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HierarchyViewNodesEnumerable EnumerateNodesWithoutFlags(HierarchyNodeFlags flags)
		{
			return EnumerateNodesWithoutAllFlags(flags);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("GetIndicesWithoutFlags is obsolete, please use GetIndicesWithoutAllFlags or GetIndicesWithoutAnyFlags instead", false)]
		public int GetIndicesWithoutFlags(HierarchyNodeFlags flags, Span<int> outIndices)
		{
			return GetIndicesWithoutAllFlagsSpan(flags, outIndices);
		}

		[Obsolete("GetIndicesWithoutFlags is obsolete, please use GetIndicesWithoutAllFlags or GetIndicesWithoutAnyFlags instead", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int[] GetIndicesWithoutFlags(HierarchyNodeFlags flags)
		{
			return GetIndicesWithoutAllFlags(flags);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_Updating_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_UpdateNeeded_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_UpdateProgress_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern HierarchySearchQueryDescriptor get_Query_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_Query_Injected(IntPtr _unity_self, HierarchySearchQueryDescriptor value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int IndexOf_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Contains_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetParent_Injected(IntPtr _unity_self, in HierarchyNode node, out HierarchyNode ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetNextSibling_Injected(IntPtr _unity_self, in HierarchyNode node, out HierarchyNode ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetChildrenCount_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetChildrenCountRecursive_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetDepth_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern HierarchyNodeFlags GetFlags_Injected(IntPtr _unity_self, in HierarchyNode node);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int HasAllFlagsCount_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int HasAnyFlagsCount_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int DoesNotHaveAllFlagsCount_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int DoesNotHaveAnyFlagsCount_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Update_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool UpdateIncremental_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool UpdateIncrementalTimed_Injected(IntPtr _unity_self, double milliseconds);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Create_Injected(IntPtr handlePtr, IntPtr hierarchyFlattened, HierarchyNodeFlags defaultFlags, out IntPtr nodesPtr, out int nodesCount, out int version);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFlagsAll_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags, bool recurse);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int SetFlagsNodes_Injected(IntPtr _unity_self, ref ManagedSpanWrapper nodes, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int SetFlagsIndices_Injected(IntPtr _unity_self, ref ManagedSpanWrapper indices, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasAllFlagsAny_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasAnyFlagsAny_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasAllFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasAnyFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool DoesNotHaveAllFlagsAny_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool DoesNotHaveAnyFlagsAny_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool DoesNotHaveAllFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool DoesNotHaveAnyFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ClearFlagsAll_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ClearFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags, bool recurse);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int ClearFlagsNodes_Injected(IntPtr _unity_self, ref ManagedSpanWrapper nodes, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int ClearFlagsIndices_Injected(IntPtr _unity_self, ref ManagedSpanWrapper indices, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ToggleFlagsAll_Injected(IntPtr _unity_self, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ToggleFlagsNode_Injected(IntPtr _unity_self, in HierarchyNode node, HierarchyNodeFlags flags, bool recurse);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int ToggleFlagsNodes_Injected(IntPtr _unity_self, ref ManagedSpanWrapper nodes, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int ToggleFlagsIndices_Injected(IntPtr _unity_self, ref ManagedSpanWrapper indices, HierarchyNodeFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetNodesWithAllFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outNodes);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetNodesWithAnyFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outNodes);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetIndicesWithAllFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outIndices);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetIndicesWithAnyFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outIndices);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetNodesWithoutAllFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outNodes);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetNodesWithoutAnyFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outNodes);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetIndicesWithoutAllFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outIndices);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetIndicesWithoutAnyFlagsSpan_Injected(IntPtr _unity_self, HierarchyNodeFlags flags, ref ManagedSpanWrapper outIndices);
	}
}
