using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyVersion("0.0.0.0")]
public class NodeEnumAttribute : PropertyAttribute
{
}
[AttributeUsage(AttributeTargets.Field)]
public class PortTypeOverrideAttribute : Attribute
{
	public Type type;

	public PortTypeOverrideAttribute(Type type)
	{
		this.type = type;
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
			FilePathsData = new byte[406]
			{
				0, 0, 0, 1, 0, 0, 0, 47, 92, 65,
				115, 115, 101, 116, 115, 92, 84, 104, 105, 114,
				100, 80, 97, 114, 116, 121, 92, 120, 78, 111,
				100, 101, 92, 65, 116, 116, 114, 105, 98, 117,
				116, 101, 115, 92, 78, 111, 100, 101, 69, 110,
				117, 109, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 64, 92, 65, 115, 115, 101, 116, 115,
				92, 84, 104, 105, 114, 100, 80, 97, 114, 116,
				121, 92, 120, 78, 111, 100, 101, 92, 65, 116,
				116, 114, 105, 98, 117, 116, 101, 115, 92, 80,
				111, 114, 116, 84, 121, 112, 101, 79, 118, 101,
				114, 114, 105, 100, 101, 65, 116, 116, 114, 105,
				98, 117, 116, 101, 46, 99, 115, 0, 0, 0,
				8, 0, 0, 0, 32, 92, 65, 115, 115, 101,
				116, 115, 92, 84, 104, 105, 114, 100, 80, 97,
				114, 116, 121, 92, 120, 78, 111, 100, 101, 92,
				78, 111, 100, 101, 46, 99, 115, 0, 0, 0,
				2, 0, 0, 0, 41, 92, 65, 115, 115, 101,
				116, 115, 92, 84, 104, 105, 114, 100, 80, 97,
				114, 116, 121, 92, 120, 78, 111, 100, 101, 92,
				78, 111, 100, 101, 68, 97, 116, 97, 67, 97,
				99, 104, 101, 46, 99, 115, 0, 0, 0, 2,
				0, 0, 0, 37, 92, 65, 115, 115, 101, 116,
				115, 92, 84, 104, 105, 114, 100, 80, 97, 114,
				116, 121, 92, 120, 78, 111, 100, 101, 92, 78,
				111, 100, 101, 71, 114, 97, 112, 104, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 47, 92,
				65, 115, 115, 101, 116, 115, 92, 84, 104, 105,
				114, 100, 80, 97, 114, 116, 121, 92, 120, 78,
				111, 100, 101, 92, 78, 111, 100, 101, 73, 110,
				115, 112, 101, 99, 116, 111, 114, 66, 114, 105,
				100, 103, 101, 46, 99, 115, 0, 0, 0, 2,
				0, 0, 0, 36, 92, 65, 115, 115, 101, 116,
				115, 92, 84, 104, 105, 114, 100, 80, 97, 114,
				116, 121, 92, 120, 78, 111, 100, 101, 92, 78,
				111, 100, 101, 80, 111, 114, 116, 46, 99, 115,
				0, 0, 0, 2, 0, 0, 0, 38, 92, 65,
				115, 115, 101, 116, 115, 92, 84, 104, 105, 114,
				100, 80, 97, 114, 116, 121, 92, 120, 78, 111,
				100, 101, 92, 83, 99, 101, 110, 101, 71, 114,
				97, 112, 104, 46, 99, 115
			},
			TypesData = new byte[564]
			{
				0, 0, 0, 0, 18, 124, 78, 111, 100, 101,
				69, 110, 117, 109, 65, 116, 116, 114, 105, 98,
				117, 116, 101, 0, 0, 0, 0, 26, 124, 80,
				111, 114, 116, 84, 121, 112, 101, 79, 118, 101,
				114, 114, 105, 100, 101, 65, 116, 116, 114, 105,
				98, 117, 116, 101, 0, 0, 0, 0, 10, 88,
				78, 111, 100, 101, 124, 78, 111, 100, 101, 0,
				0, 0, 0, 25, 88, 78, 111, 100, 101, 46,
				78, 111, 100, 101, 124, 73, 110, 112, 117, 116,
				65, 116, 116, 114, 105, 98, 117, 116, 101, 0,
				0, 0, 0, 26, 88, 78, 111, 100, 101, 46,
				78, 111, 100, 101, 124, 79, 117, 116, 112, 117,
				116, 65, 116, 116, 114, 105, 98, 117, 116, 101,
				0, 0, 0, 0, 34, 88, 78, 111, 100, 101,
				46, 78, 111, 100, 101, 124, 67, 114, 101, 97,
				116, 101, 78, 111, 100, 101, 77, 101, 110, 117,
				65, 116, 116, 114, 105, 98, 117, 116, 101, 0,
				0, 0, 0, 41, 88, 78, 111, 100, 101, 46,
				78, 111, 100, 101, 124, 68, 105, 115, 97, 108,
				108, 111, 119, 77, 117, 108, 116, 105, 112, 108,
				101, 78, 111, 100, 101, 115, 65, 116, 116, 114,
				105, 98, 117, 116, 101, 0, 0, 0, 0, 28,
				88, 78, 111, 100, 101, 46, 78, 111, 100, 101,
				124, 78, 111, 100, 101, 84, 105, 110, 116, 65,
				116, 116, 114, 105, 98, 117, 116, 101, 0, 0,
				0, 0, 29, 88, 78, 111, 100, 101, 46, 78,
				111, 100, 101, 124, 78, 111, 100, 101, 87, 105,
				100, 116, 104, 65, 116, 116, 114, 105, 98, 117,
				116, 101, 0, 0, 0, 0, 29, 88, 78, 111,
				100, 101, 46, 78, 111, 100, 101, 124, 78, 111,
				100, 101, 80, 111, 114, 116, 68, 105, 99, 116,
				105, 111, 110, 97, 114, 121, 0, 0, 0, 0,
				19, 88, 78, 111, 100, 101, 124, 78, 111, 100,
				101, 68, 97, 116, 97, 67, 97, 99, 104, 101,
				0, 0, 0, 0, 33, 88, 78, 111, 100, 101,
				46, 78, 111, 100, 101, 68, 97, 116, 97, 67,
				97, 99, 104, 101, 124, 80, 111, 114, 116, 68,
				97, 116, 97, 67, 97, 99, 104, 101, 0, 0,
				0, 0, 15, 88, 78, 111, 100, 101, 124, 78,
				111, 100, 101, 71, 114, 97, 112, 104, 0, 0,
				0, 0, 36, 88, 78, 111, 100, 101, 46, 78,
				111, 100, 101, 71, 114, 97, 112, 104, 124, 82,
				101, 113, 117, 105, 114, 101, 78, 111, 100, 101,
				65, 116, 116, 114, 105, 98, 117, 116, 101, 0,
				0, 0, 0, 25, 88, 78, 111, 100, 101, 124,
				78, 111, 100, 101, 73, 110, 115, 112, 101, 99,
				116, 111, 114, 66, 114, 105, 100, 103, 101, 0,
				0, 0, 0, 14, 88, 78, 111, 100, 101, 124,
				78, 111, 100, 101, 80, 111, 114, 116, 0, 0,
				0, 0, 29, 88, 78, 111, 100, 101, 46, 78,
				111, 100, 101, 80, 111, 114, 116, 124, 80, 111,
				114, 116, 67, 111, 110, 110, 101, 99, 116, 105,
				111, 110, 1, 0, 0, 0, 16, 88, 78, 111,
				100, 101, 124, 83, 99, 101, 110, 101, 71, 114,
				97, 112, 104, 1, 0, 0, 0, 16, 88, 78,
				111, 100, 101, 124, 83, 99, 101, 110, 101, 71,
				114, 97, 112, 104
			},
			TotalFiles = 8,
			TotalTypes = 19,
			IsEditorOnly = false
		};
	}
}
namespace XNode;

[Serializable]
public abstract class Node : ScriptableObject
{
	public enum ShowBackingValue
	{
		Never,
		Unconnected,
		Always
	}

	public enum ConnectionType
	{
		Multiple,
		Override
	}

	public enum TypeConstraint
	{
		None,
		Inherited,
		Strict,
		InheritedInverse,
		InheritedAny
	}

	[AttributeUsage(AttributeTargets.Field)]
	public class InputAttribute : Attribute
	{
		public ShowBackingValue backingValue;

		public ConnectionType connectionType;

		public bool dynamicPortList;

		public TypeConstraint typeConstraint;

		[Obsolete("Use dynamicPortList instead")]
		public bool instancePortList
		{
			get
			{
				return dynamicPortList;
			}
			set
			{
				dynamicPortList = value;
			}
		}

		public InputAttribute(ShowBackingValue backingValue = ShowBackingValue.Unconnected, ConnectionType connectionType = ConnectionType.Multiple, TypeConstraint typeConstraint = TypeConstraint.None, bool dynamicPortList = false)
		{
			this.backingValue = backingValue;
			this.connectionType = connectionType;
			this.dynamicPortList = dynamicPortList;
			this.typeConstraint = typeConstraint;
		}
	}

	[AttributeUsage(AttributeTargets.Field)]
	public class OutputAttribute : Attribute
	{
		public ShowBackingValue backingValue;

		public ConnectionType connectionType;

		public bool dynamicPortList;

		public TypeConstraint typeConstraint;

		[Obsolete("Use dynamicPortList instead")]
		public bool instancePortList
		{
			get
			{
				return dynamicPortList;
			}
			set
			{
				dynamicPortList = value;
			}
		}

		public OutputAttribute(ShowBackingValue backingValue = ShowBackingValue.Never, ConnectionType connectionType = ConnectionType.Multiple, TypeConstraint typeConstraint = TypeConstraint.None, bool dynamicPortList = false)
		{
			this.backingValue = backingValue;
			this.connectionType = connectionType;
			this.dynamicPortList = dynamicPortList;
			this.typeConstraint = typeConstraint;
		}

		[Obsolete("Use constructor with TypeConstraint")]
		public OutputAttribute(ShowBackingValue backingValue, ConnectionType connectionType, bool dynamicPortList)
			: this(backingValue, connectionType, TypeConstraint.None, dynamicPortList)
		{
		}
	}

	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class CreateNodeMenuAttribute : Attribute
	{
		public string menuName;

		public int order;

		public CreateNodeMenuAttribute(string menuName)
		{
			this.menuName = menuName;
			order = 0;
		}

		public CreateNodeMenuAttribute(string menuName, int order)
		{
			this.menuName = menuName;
			this.order = order;
		}
	}

	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class DisallowMultipleNodesAttribute : Attribute
	{
		public int max;

		public DisallowMultipleNodesAttribute(int max = 1)
		{
			this.max = max;
		}
	}

	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class NodeTintAttribute : Attribute
	{
		public Color color;

		public NodeTintAttribute(float r, float g, float b)
		{
			color = new Color(r, g, b);
		}

		public NodeTintAttribute(string hex)
		{
			ColorUtility.TryParseHtmlString(hex, out color);
		}

		public NodeTintAttribute(byte r, byte g, byte b)
		{
			color = new Color32(r, g, b, byte.MaxValue);
		}
	}

	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class NodeWidthAttribute : Attribute
	{
		public int width;

		public NodeWidthAttribute(int width)
		{
			this.width = width;
		}
	}

	[Serializable]
	private class NodePortDictionary : Dictionary<string, NodePort>, ISerializationCallbackReceiver
	{
		[SerializeField]
		private List<string> keys = new List<string>();

		[SerializeField]
		private List<NodePort> values = new List<NodePort>();

		public void OnBeforeSerialize()
		{
			keys.Clear();
			values.Clear();
			keys.Capacity = base.Count;
			values.Capacity = base.Count;
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, NodePort> current = enumerator.Current;
				keys.Add(current.Key);
				values.Add(current.Value);
			}
		}

		public void OnAfterDeserialize()
		{
			Clear();
			EnsureCapacity(keys.Count);
			if (keys.Count != values.Count)
			{
				throw new Exception("there are " + keys.Count + " keys and " + values.Count + " values after deserialization. Make sure that both key and value types are serializable.");
			}
			for (int i = 0; i < keys.Count; i++)
			{
				Add(keys[i], values[i]);
			}
		}
	}

	[SerializeField]
	public NodeGraph graph;

	[SerializeField]
	public Vector2 position;

	[SerializeField]
	private NodePortDictionary ports = new NodePortDictionary();

	public static NodeGraph graphHotfix;

	[Obsolete("Use DynamicPorts instead")]
	public IEnumerable<NodePort> InstancePorts => DynamicPorts;

	[Obsolete("Use DynamicOutputs instead")]
	public IEnumerable<NodePort> InstanceOutputs => DynamicOutputs;

	[Obsolete("Use DynamicInputs instead")]
	public IEnumerable<NodePort> InstanceInputs => DynamicInputs;

	public IEnumerable<NodePort> Ports
	{
		get
		{
			foreach (NodePort value in ports.Values)
			{
				yield return value;
			}
		}
	}

	public IEnumerable<NodePort> Outputs
	{
		get
		{
			foreach (NodePort port in Ports)
			{
				if (port.IsOutput)
				{
					yield return port;
				}
			}
		}
	}

	public IEnumerable<NodePort> Inputs
	{
		get
		{
			foreach (NodePort port in Ports)
			{
				if (port.IsInput)
				{
					yield return port;
				}
			}
		}
	}

	public IEnumerable<NodePort> DynamicPorts
	{
		get
		{
			foreach (NodePort port in Ports)
			{
				if (port.IsDynamic)
				{
					yield return port;
				}
			}
		}
	}

	public IEnumerable<NodePort> DynamicOutputs
	{
		get
		{
			foreach (NodePort port in Ports)
			{
				if (port.IsDynamic && port.IsOutput)
				{
					yield return port;
				}
			}
		}
	}

	public IEnumerable<NodePort> DynamicInputs
	{
		get
		{
			foreach (NodePort port in Ports)
			{
				if (port.IsDynamic && port.IsInput)
				{
					yield return port;
				}
			}
		}
	}

	[Obsolete("Use AddDynamicInput instead")]
	public NodePort AddInstanceInput(Type type, ConnectionType connectionType = ConnectionType.Multiple, TypeConstraint typeConstraint = TypeConstraint.None, string fieldName = null)
	{
		return AddDynamicInput(type, connectionType, typeConstraint, fieldName);
	}

	[Obsolete("Use AddDynamicOutput instead")]
	public NodePort AddInstanceOutput(Type type, ConnectionType connectionType = ConnectionType.Multiple, TypeConstraint typeConstraint = TypeConstraint.None, string fieldName = null)
	{
		return AddDynamicOutput(type, connectionType, typeConstraint, fieldName);
	}

	[Obsolete("Use AddDynamicPort instead")]
	private NodePort AddInstancePort(Type type, NodePort.IO direction, ConnectionType connectionType = ConnectionType.Multiple, TypeConstraint typeConstraint = TypeConstraint.None, string fieldName = null)
	{
		return AddDynamicPort(type, direction, connectionType, typeConstraint, fieldName);
	}

	[Obsolete("Use RemoveDynamicPort instead")]
	public void RemoveInstancePort(string fieldName)
	{
		RemoveDynamicPort(fieldName);
	}

	[Obsolete("Use RemoveDynamicPort instead")]
	public void RemoveInstancePort(NodePort port)
	{
		RemoveDynamicPort(port);
	}

	[Obsolete("Use ClearDynamicPorts instead")]
	public void ClearInstancePorts()
	{
		ClearDynamicPorts();
	}

	protected void OnEnable()
	{
		if (graphHotfix != null)
		{
			graph = graphHotfix;
		}
		graphHotfix = null;
		UpdatePorts();
		Init();
	}

	public void UpdatePorts()
	{
		NodeDataCache.UpdatePorts(this, ports);
	}

	protected virtual void Init()
	{
	}

	public void VerifyConnections()
	{
		foreach (NodePort port in Ports)
		{
			port.VerifyConnections();
		}
	}

	public NodePort AddDynamicInput(Type type, ConnectionType connectionType = ConnectionType.Multiple, TypeConstraint typeConstraint = TypeConstraint.None, string fieldName = null)
	{
		return AddDynamicPort(type, NodePort.IO.Input, connectionType, typeConstraint, fieldName);
	}

	public NodePort AddDynamicOutput(Type type, ConnectionType connectionType = ConnectionType.Multiple, TypeConstraint typeConstraint = TypeConstraint.None, string fieldName = null)
	{
		return AddDynamicPort(type, NodePort.IO.Output, connectionType, typeConstraint, fieldName);
	}

	private NodePort AddDynamicPort(Type type, NodePort.IO direction, ConnectionType connectionType = ConnectionType.Multiple, TypeConstraint typeConstraint = TypeConstraint.None, string fieldName = null)
	{
		if (fieldName == null)
		{
			fieldName = "dynamicInput_0";
			int num = 0;
			while (HasPort(fieldName))
			{
				fieldName = "dynamicInput_" + ++num;
			}
		}
		else if (HasPort(fieldName))
		{
			UnityEngine.Debug.LogWarning("Port '" + fieldName + "' already exists in " + base.name, this);
			return ports[fieldName];
		}
		NodePort nodePort = new NodePort(fieldName, type, direction, connectionType, typeConstraint, this);
		ports.Add(fieldName, nodePort);
		return nodePort;
	}

	public void RemoveDynamicPort(string fieldName)
	{
		if (GetPort(fieldName) == null)
		{
			throw new ArgumentException("port " + fieldName + " doesn't exist");
		}
		RemoveDynamicPort(GetPort(fieldName));
	}

	public void RemoveDynamicPort(NodePort port)
	{
		if (port == null)
		{
			throw new ArgumentNullException("port");
		}
		if (port.IsStatic)
		{
			throw new ArgumentException("cannot remove static port");
		}
		port.ClearConnections();
		ports.Remove(port.fieldName);
	}

	[ContextMenu("Clear Dynamic Ports")]
	public void ClearDynamicPorts()
	{
		foreach (NodePort item in new List<NodePort>(DynamicPorts))
		{
			RemoveDynamicPort(item);
		}
	}

	public NodePort GetOutputPort(string fieldName)
	{
		NodePort port = GetPort(fieldName);
		if (port == null || port.direction != NodePort.IO.Output)
		{
			return null;
		}
		return port;
	}

	public NodePort GetInputPort(string fieldName)
	{
		NodePort port = GetPort(fieldName);
		if (port == null || port.direction != NodePort.IO.Input)
		{
			return null;
		}
		return port;
	}

	public NodePort GetPort(string fieldName)
	{
		if (ports.TryGetValue(fieldName, out var value))
		{
			return value;
		}
		return null;
	}

	public bool HasPort(string fieldName)
	{
		return ports.ContainsKey(fieldName);
	}

	public T GetInputValue<T>(string fieldName, T fallback = default(T))
	{
		NodePort port = GetPort(fieldName);
		if (port != null && port.IsConnected)
		{
			return port.GetInputValue<T>();
		}
		return fallback;
	}

	public T[] GetInputValues<T>(string fieldName, params T[] fallback)
	{
		NodePort port = GetPort(fieldName);
		if (port != null && port.IsConnected)
		{
			return port.GetInputValues<T>();
		}
		return fallback;
	}

	public virtual object GetValue(NodePort port)
	{
		UnityEngine.Debug.LogWarning("No GetValue(NodePort port) override defined for " + GetType());
		return null;
	}

	public virtual void OnCreateConnection(NodePort from, NodePort to)
	{
	}

	public virtual void OnRemoveConnection(NodePort port)
	{
	}

	public void ClearConnections()
	{
		foreach (NodePort port in Ports)
		{
			port.ClearConnections();
		}
	}
}
public static class NodeDataCache
{
	[Serializable]
	private class PortDataCache : Dictionary<Type, Dictionary<string, NodePort>>
	{
	}

	private static PortDataCache portDataCache;

	private static Dictionary<Type, Dictionary<string, string>> formerlySerializedAsCache;

	private static Dictionary<Type, string> typeQualifiedNameCache;

	private static bool Initialized => portDataCache != null;

	public static string GetTypeQualifiedName(Type type)
	{
		if (typeQualifiedNameCache == null)
		{
			typeQualifiedNameCache = new Dictionary<Type, string>();
		}
		if (!typeQualifiedNameCache.TryGetValue(type, out var value))
		{
			value = type.AssemblyQualifiedName;
			typeQualifiedNameCache.Add(type, value);
		}
		return value;
	}

	public static void UpdatePorts(Node node, Dictionary<string, NodePort> ports)
	{
		if (!Initialized)
		{
			BuildCache();
		}
		Dictionary<string, List<NodePort>> dictionary = new Dictionary<string, List<NodePort>>();
		Type type = node.GetType();
		Dictionary<string, string> value = null;
		if (formerlySerializedAsCache != null)
		{
			formerlySerializedAsCache.TryGetValue(type, out value);
		}
		List<NodePort> list = new List<NodePort>();
		if (!portDataCache.TryGetValue(type, out var value2))
		{
			value2 = new Dictionary<string, NodePort>();
		}
		NodePort[] array = ports.Values.ToArray();
		foreach (NodePort nodePort in array)
		{
			if (value2.TryGetValue(nodePort.fieldName, out var value3))
			{
				if (nodePort.IsDynamic || nodePort.direction != value3.direction || nodePort.connectionType != value3.connectionType || nodePort.typeConstraint != value3.typeConstraint)
				{
					if (!nodePort.IsDynamic && nodePort.direction == value3.direction)
					{
						dictionary.Add(nodePort.fieldName, nodePort.GetConnections());
					}
					nodePort.ClearConnections();
					ports.Remove(nodePort.fieldName);
				}
				else
				{
					nodePort.ValueType = value3.ValueType;
				}
			}
			else if (nodePort.IsStatic)
			{
				string value4 = null;
				if (value != null && value.TryGetValue(nodePort.fieldName, out value4))
				{
					dictionary.Add(value4, nodePort.GetConnections());
				}
				nodePort.ClearConnections();
				ports.Remove(nodePort.fieldName);
			}
			else if (IsDynamicListPort(nodePort))
			{
				list.Add(nodePort);
			}
		}
		foreach (NodePort value6 in value2.Values)
		{
			if (ports.ContainsKey(value6.fieldName))
			{
				continue;
			}
			NodePort nodePort2 = new NodePort(value6, node);
			if (dictionary.TryGetValue(value6.fieldName, out var value5))
			{
				for (int j = 0; j < value5.Count; j++)
				{
					NodePort nodePort3 = value5[j];
					if (nodePort3 != null && nodePort2.CanConnectTo(nodePort3))
					{
						nodePort2.Connect(nodePort3);
					}
				}
			}
			ports.Add(value6.fieldName, nodePort2);
		}
		foreach (NodePort item in list)
		{
			string key = item.fieldName.Substring(0, item.fieldName.IndexOf(' '));
			NodePort nodePort4 = value2[key];
			item.ValueType = GetBackingValueType(nodePort4.ValueType);
			item.direction = nodePort4.direction;
			item.connectionType = nodePort4.connectionType;
			item.typeConstraint = nodePort4.typeConstraint;
		}
	}

	private static Type GetBackingValueType(Type portValType)
	{
		if (portValType.HasElementType)
		{
			return portValType.GetElementType();
		}
		if (portValType.IsGenericType && portValType.GetGenericTypeDefinition() == typeof(List<>))
		{
			return portValType.GetGenericArguments()[0];
		}
		return portValType;
	}

	private static bool IsDynamicListPort(NodePort port)
	{
		string[] array = port.fieldName.Split(' ');
		if (array.Length != 2)
		{
			return false;
		}
		FieldInfo field = port.node.GetType().GetField(array[0]);
		if (field == null)
		{
			return false;
		}
		return field.GetCustomAttributes(inherit: true).Any(delegate(object x)
		{
			Node.InputAttribute inputAttribute = x as Node.InputAttribute;
			Node.OutputAttribute outputAttribute = x as Node.OutputAttribute;
			return (inputAttribute != null && inputAttribute.dynamicPortList) || (outputAttribute?.dynamicPortList ?? false);
		});
	}

	private static void BuildCache()
	{
		portDataCache = new PortDataCache();
		Type baseType = typeof(Node);
		List<Type> list = new List<Type>();
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			string text = assembly.GetName().Name;
			int num = text.IndexOf('.');
			if (num != -1)
			{
				text = text.Substring(0, num);
			}
			switch (text)
			{
			case "UnityEditor":
			case "UnityEngine":
			case "Unity":
			case "System":
			case "mscorlib":
			case "Microsoft":
				continue;
			}
			list.AddRange((from t in assembly.GetTypes()
				where !t.IsAbstract && baseType.IsAssignableFrom(t)
				select t).ToArray());
		}
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			CachePorts(list[num2]);
		}
	}

	public static List<FieldInfo> GetNodeFields(Type nodeType)
	{
		List<FieldInfo> list = new List<FieldInfo>(nodeType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
		Type type = nodeType;
		while ((type = type.BaseType) != typeof(Node))
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
			foreach (FieldInfo parentField in fields)
			{
				if (list.TrueForAll((FieldInfo x) => x.Name != parentField.Name))
				{
					list.Add(parentField);
				}
			}
		}
		return list;
	}

	private static void CachePorts(Type nodeType)
	{
		List<FieldInfo> nodeFields = GetNodeFields(nodeType);
		for (int i = 0; i < nodeFields.Count; i++)
		{
			object[] customAttributes = nodeFields[i].GetCustomAttributes(inherit: true);
			Node.InputAttribute inputAttribute = customAttributes.FirstOrDefault((object x) => x is Node.InputAttribute) as Node.InputAttribute;
			Node.OutputAttribute outputAttribute = customAttributes.FirstOrDefault((object x) => x is Node.OutputAttribute) as Node.OutputAttribute;
			FormerlySerializedAsAttribute formerlySerializedAsAttribute = customAttributes.FirstOrDefault((object x) => x is FormerlySerializedAsAttribute) as FormerlySerializedAsAttribute;
			if (inputAttribute == null && outputAttribute == null)
			{
				continue;
			}
			if (inputAttribute != null && outputAttribute != null)
			{
				UnityEngine.Debug.LogError("Field " + nodeFields[i].Name + " of type " + nodeType.FullName + " cannot be both input and output.");
			}
			else
			{
				if (!portDataCache.ContainsKey(nodeType))
				{
					portDataCache.Add(nodeType, new Dictionary<string, NodePort>());
				}
				NodePort nodePort = new NodePort(nodeFields[i]);
				portDataCache[nodeType].Add(nodePort.fieldName, nodePort);
			}
			if (formerlySerializedAsAttribute != null)
			{
				if (formerlySerializedAsCache == null)
				{
					formerlySerializedAsCache = new Dictionary<Type, Dictionary<string, string>>();
				}
				if (!formerlySerializedAsCache.ContainsKey(nodeType))
				{
					formerlySerializedAsCache.Add(nodeType, new Dictionary<string, string>());
				}
				if (formerlySerializedAsCache[nodeType].ContainsKey(formerlySerializedAsAttribute.oldName))
				{
					UnityEngine.Debug.LogError("Another FormerlySerializedAs with value '" + formerlySerializedAsAttribute.oldName + "' already exist on this node.");
				}
				else
				{
					formerlySerializedAsCache[nodeType].Add(formerlySerializedAsAttribute.oldName, nodeFields[i].Name);
				}
			}
		}
	}
}
[Serializable]
public abstract class NodeGraph : ScriptableObject
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class RequireNodeAttribute : Attribute
	{
		public Type type0;

		public Type type1;

		public Type type2;

		public RequireNodeAttribute(Type type)
		{
			type0 = type;
			type1 = null;
			type2 = null;
		}

		public RequireNodeAttribute(Type type, Type type2)
		{
			type0 = type;
			type1 = type2;
			this.type2 = null;
		}

		public RequireNodeAttribute(Type type, Type type2, Type type3)
		{
			type0 = type;
			type1 = type2;
			this.type2 = type3;
		}

		public bool Requires(Type type)
		{
			if (type == null)
			{
				return false;
			}
			if (type == type0)
			{
				return true;
			}
			if (type == type1)
			{
				return true;
			}
			if (type == type2)
			{
				return true;
			}
			return false;
		}
	}

	[SerializeField]
	public List<Node> nodes = new List<Node>();

	public T AddNode<T>() where T : Node
	{
		return AddNode(typeof(T)) as T;
	}

	public virtual Node AddNode(Type type)
	{
		Node.graphHotfix = this;
		Node node = ScriptableObject.CreateInstance(type) as Node;
		node.graph = this;
		nodes.Add(node);
		return node;
	}

	public virtual Node CopyNode(Node original)
	{
		Node.graphHotfix = this;
		Node node = UnityEngine.Object.Instantiate(original);
		node.graph = this;
		node.ClearConnections();
		nodes.Add(node);
		return node;
	}

	public virtual void RemoveNode(Node node)
	{
		node.ClearConnections();
		nodes.Remove(node);
		if (Application.isPlaying)
		{
			UnityEngine.Object.Destroy(node);
		}
	}

	public virtual void Clear()
	{
		if (Application.isPlaying)
		{
			for (int i = 0; i < nodes.Count; i++)
			{
				if (nodes[i] != null)
				{
					UnityEngine.Object.Destroy(nodes[i]);
				}
			}
		}
		nodes.Clear();
	}

	public virtual NodeGraph Copy()
	{
		NodeGraph nodeGraph = UnityEngine.Object.Instantiate(this);
		for (int i = 0; i < nodes.Count; i++)
		{
			if (!(nodes[i] == null))
			{
				Node.graphHotfix = nodeGraph;
				Node node = UnityEngine.Object.Instantiate(nodes[i]);
				node.graph = nodeGraph;
				nodeGraph.nodes[i] = node;
			}
		}
		for (int j = 0; j < nodeGraph.nodes.Count; j++)
		{
			if (nodeGraph.nodes[j] == null)
			{
				continue;
			}
			foreach (NodePort port in nodeGraph.nodes[j].Ports)
			{
				port.Redirect(nodes, nodeGraph.nodes);
			}
		}
		return nodeGraph;
	}

	protected virtual void OnDestroy()
	{
		Clear();
	}
}
public static class NodeInspectorBridge
{
	public static bool InNodeEditor;
}
[Serializable]
public class NodePort
{
	public enum IO
	{
		Input,
		Output
	}

	[Serializable]
	private class PortConnection
	{
		[SerializeField]
		public string fieldName;

		[SerializeField]
		public Node node;

		[NonSerialized]
		private NodePort port;

		[SerializeField]
		public List<Vector2> reroutePoints = new List<Vector2>();

		public NodePort Port
		{
			get
			{
				if (port == null)
				{
					return port = GetPort();
				}
				return port;
			}
		}

		public PortConnection(NodePort port)
		{
			this.port = port;
			node = port.node;
			fieldName = port.fieldName;
		}

		private NodePort GetPort()
		{
			if (node == null || string.IsNullOrEmpty(fieldName))
			{
				return null;
			}
			return node.GetPort(fieldName);
		}
	}

	private Type valueType;

	[SerializeField]
	private string _fieldName;

	[SerializeField]
	private Node _node;

	[SerializeField]
	private string _typeQualifiedName;

	[SerializeField]
	private List<PortConnection> connections = new List<PortConnection>();

	[SerializeField]
	private IO _direction;

	[SerializeField]
	private Node.ConnectionType _connectionType;

	[SerializeField]
	private Node.TypeConstraint _typeConstraint;

	[SerializeField]
	private bool _dynamic;

	public int ConnectionCount => connections.Count;

	public NodePort Connection
	{
		get
		{
			for (int i = 0; i < connections.Count; i++)
			{
				if (connections[i] != null)
				{
					return connections[i].Port;
				}
			}
			return null;
		}
	}

	public IO direction
	{
		get
		{
			return _direction;
		}
		internal set
		{
			_direction = value;
		}
	}

	public Node.ConnectionType connectionType
	{
		get
		{
			return _connectionType;
		}
		internal set
		{
			_connectionType = value;
		}
	}

	public Node.TypeConstraint typeConstraint
	{
		get
		{
			return _typeConstraint;
		}
		internal set
		{
			_typeConstraint = value;
		}
	}

	public bool IsConnected => connections.Count != 0;

	public bool IsInput => direction == IO.Input;

	public bool IsOutput => direction == IO.Output;

	public string fieldName => _fieldName;

	public Node node => _node;

	public bool IsDynamic => _dynamic;

	public bool IsStatic => !_dynamic;

	public Type ValueType
	{
		get
		{
			if (valueType == null && !string.IsNullOrEmpty(_typeQualifiedName))
			{
				valueType = Type.GetType(_typeQualifiedName, throwOnError: false);
			}
			return valueType;
		}
		set
		{
			if (!(valueType == value))
			{
				valueType = value;
				if (value != null)
				{
					_typeQualifiedName = NodeDataCache.GetTypeQualifiedName(value);
				}
			}
		}
	}

	public NodePort(FieldInfo fieldInfo)
	{
		_fieldName = fieldInfo.Name;
		ValueType = fieldInfo.FieldType;
		_dynamic = false;
		object[] customAttributes = fieldInfo.GetCustomAttributes(inherit: false);
		for (int i = 0; i < customAttributes.Length; i++)
		{
			if (customAttributes[i] is Node.InputAttribute)
			{
				_direction = IO.Input;
				_connectionType = (customAttributes[i] as Node.InputAttribute).connectionType;
				_typeConstraint = (customAttributes[i] as Node.InputAttribute).typeConstraint;
			}
			else if (customAttributes[i] is Node.OutputAttribute)
			{
				_direction = IO.Output;
				_connectionType = (customAttributes[i] as Node.OutputAttribute).connectionType;
				_typeConstraint = (customAttributes[i] as Node.OutputAttribute).typeConstraint;
			}
			if (customAttributes[i] is PortTypeOverrideAttribute)
			{
				ValueType = (customAttributes[i] as PortTypeOverrideAttribute).type;
			}
		}
	}

	public NodePort(NodePort nodePort, Node node)
	{
		_fieldName = nodePort._fieldName;
		ValueType = nodePort.valueType;
		_direction = nodePort.direction;
		_dynamic = nodePort._dynamic;
		_connectionType = nodePort._connectionType;
		_typeConstraint = nodePort._typeConstraint;
		_node = node;
	}

	public NodePort(string fieldName, Type type, IO direction, Node.ConnectionType connectionType, Node.TypeConstraint typeConstraint, Node node)
	{
		_fieldName = fieldName;
		ValueType = type;
		_direction = direction;
		_node = node;
		_dynamic = true;
		_connectionType = connectionType;
		_typeConstraint = typeConstraint;
	}

	public void VerifyConnections()
	{
		for (int num = connections.Count - 1; num >= 0; num--)
		{
			if (!(connections[num].node != null) || string.IsNullOrEmpty(connections[num].fieldName) || connections[num].node.GetPort(connections[num].fieldName) == null)
			{
				connections.RemoveAt(num);
			}
		}
	}

	public object GetOutputValue()
	{
		if (direction == IO.Input)
		{
			return null;
		}
		return node.GetValue(this);
	}

	public object GetInputValue()
	{
		return Connection?.GetOutputValue();
	}

	public object[] GetInputValues()
	{
		object[] array = new object[ConnectionCount];
		for (int i = 0; i < ConnectionCount; i++)
		{
			NodePort port = connections[i].Port;
			if (port == null)
			{
				connections.RemoveAt(i);
				i--;
			}
			else
			{
				array[i] = port.GetOutputValue();
			}
		}
		return array;
	}

	public T GetInputValue<T>()
	{
		object inputValue = GetInputValue();
		if (!(inputValue is T))
		{
			return default(T);
		}
		return (T)inputValue;
	}

	public T[] GetInputValues<T>()
	{
		object[] inputValues = GetInputValues();
		T[] array = new T[inputValues.Length];
		for (int i = 0; i < inputValues.Length; i++)
		{
			if (inputValues[i] is T)
			{
				array[i] = (T)inputValues[i];
			}
		}
		return array;
	}

	public bool TryGetInputValue<T>(out T value)
	{
		object inputValue = GetInputValue();
		if (inputValue is T)
		{
			value = (T)inputValue;
			return true;
		}
		value = default(T);
		return false;
	}

	public float GetInputSum(float fallback)
	{
		object[] inputValues = GetInputValues();
		if (inputValues.Length == 0)
		{
			return fallback;
		}
		float num = 0f;
		for (int i = 0; i < inputValues.Length; i++)
		{
			if (inputValues[i] is float)
			{
				num += (float)inputValues[i];
			}
		}
		return num;
	}

	public int GetInputSum(int fallback)
	{
		object[] inputValues = GetInputValues();
		if (inputValues.Length == 0)
		{
			return fallback;
		}
		int num = 0;
		for (int i = 0; i < inputValues.Length; i++)
		{
			if (inputValues[i] is int)
			{
				num += (int)inputValues[i];
			}
		}
		return num;
	}

	public void Connect(NodePort port)
	{
		if (connections == null)
		{
			connections = new List<PortConnection>();
		}
		if (port == null)
		{
			UnityEngine.Debug.LogWarning("Cannot connect to null port");
			return;
		}
		if (port == this)
		{
			UnityEngine.Debug.LogWarning("Cannot connect port to self.");
			return;
		}
		if (IsConnectedTo(port))
		{
			UnityEngine.Debug.LogWarning("Port already connected. ");
			return;
		}
		if (direction == port.direction)
		{
			UnityEngine.Debug.LogWarning("Cannot connect two " + ((direction == IO.Input) ? "input" : "output") + " connections");
			return;
		}
		if (port.connectionType == Node.ConnectionType.Override && port.ConnectionCount != 0)
		{
			port.ClearConnections();
		}
		if (connectionType == Node.ConnectionType.Override && ConnectionCount != 0)
		{
			ClearConnections();
		}
		connections.Add(new PortConnection(port));
		if (port.connections == null)
		{
			port.connections = new List<PortConnection>();
		}
		if (!port.IsConnectedTo(this))
		{
			port.connections.Add(new PortConnection(this));
		}
		node.OnCreateConnection(this, port);
		port.node.OnCreateConnection(this, port);
	}

	public List<NodePort> GetConnections()
	{
		List<NodePort> list = new List<NodePort>();
		for (int i = 0; i < connections.Count; i++)
		{
			NodePort connection = GetConnection(i);
			if (connection != null)
			{
				list.Add(connection);
			}
		}
		return list;
	}

	public NodePort GetConnection(int i)
	{
		if (connections[i].node == null || string.IsNullOrEmpty(connections[i].fieldName))
		{
			connections.RemoveAt(i);
			return null;
		}
		NodePort port = connections[i].node.GetPort(connections[i].fieldName);
		if (port == null)
		{
			connections.RemoveAt(i);
			return null;
		}
		return port;
	}

	public int GetConnectionIndex(NodePort port)
	{
		for (int i = 0; i < ConnectionCount; i++)
		{
			if (connections[i].Port == port)
			{
				return i;
			}
		}
		return -1;
	}

	public bool IsConnectedTo(NodePort port)
	{
		for (int i = 0; i < connections.Count; i++)
		{
			if (connections[i].Port == port)
			{
				return true;
			}
		}
		return false;
	}

	public bool CanConnectTo(NodePort port)
	{
		NodePort nodePort = null;
		NodePort nodePort2 = null;
		if (IsInput)
		{
			nodePort = this;
		}
		else
		{
			nodePort2 = this;
		}
		if (port.IsInput)
		{
			nodePort = port;
		}
		else
		{
			nodePort2 = port;
		}
		if (nodePort == null || nodePort2 == null)
		{
			return false;
		}
		if (nodePort.typeConstraint == Node.TypeConstraint.Inherited && !nodePort.ValueType.IsAssignableFrom(nodePort2.ValueType))
		{
			return false;
		}
		if (nodePort.typeConstraint == Node.TypeConstraint.Strict && nodePort.ValueType != nodePort2.ValueType)
		{
			return false;
		}
		if (nodePort.typeConstraint == Node.TypeConstraint.InheritedInverse && !nodePort2.ValueType.IsAssignableFrom(nodePort.ValueType))
		{
			return false;
		}
		if (nodePort.typeConstraint == Node.TypeConstraint.InheritedAny && !nodePort.ValueType.IsAssignableFrom(nodePort2.ValueType) && !nodePort2.ValueType.IsAssignableFrom(nodePort.ValueType))
		{
			return false;
		}
		if (nodePort2.typeConstraint == Node.TypeConstraint.Inherited && !nodePort.ValueType.IsAssignableFrom(nodePort2.ValueType))
		{
			return false;
		}
		if (nodePort2.typeConstraint == Node.TypeConstraint.Strict && nodePort.ValueType != nodePort2.ValueType)
		{
			return false;
		}
		if (nodePort2.typeConstraint == Node.TypeConstraint.InheritedInverse && !nodePort2.ValueType.IsAssignableFrom(nodePort.ValueType))
		{
			return false;
		}
		if (nodePort2.typeConstraint == Node.TypeConstraint.InheritedAny && !nodePort.ValueType.IsAssignableFrom(nodePort2.ValueType) && !nodePort2.ValueType.IsAssignableFrom(nodePort.ValueType))
		{
			return false;
		}
		return true;
	}

	public void Disconnect(NodePort port)
	{
		for (int num = connections.Count - 1; num >= 0; num--)
		{
			if (connections[num].Port == port)
			{
				connections.RemoveAt(num);
			}
		}
		if (port != null)
		{
			for (int i = 0; i < port.connections.Count; i++)
			{
				if (port.connections[i].Port == this)
				{
					port.connections.RemoveAt(i);
					port.node.OnRemoveConnection(port);
				}
			}
		}
		node.OnRemoveConnection(this);
	}

	public void Disconnect(int i)
	{
		NodePort port = connections[i].Port;
		port?.connections.RemoveAll((PortConnection it) => it.Port == this);
		connections.RemoveAt(i);
		node.OnRemoveConnection(this);
		port?.node.OnRemoveConnection(port);
	}

	public void ClearConnections()
	{
		while (connections.Count > 0)
		{
			Disconnect(connections[0].Port);
		}
	}

	public List<Vector2> GetReroutePoints(int index)
	{
		return connections[index].reroutePoints;
	}

	public void SwapConnections(NodePort targetPort)
	{
		int count = connections.Count;
		int count2 = targetPort.connections.Count;
		List<NodePort> list = new List<NodePort>();
		List<NodePort> list2 = new List<NodePort>();
		for (int i = 0; i < count; i++)
		{
			list.Add(connections[i].Port);
		}
		for (int j = 0; j < count2; j++)
		{
			list2.Add(targetPort.connections[j].Port);
		}
		ClearConnections();
		targetPort.ClearConnections();
		for (int k = 0; k < list.Count; k++)
		{
			targetPort.Connect(list[k]);
		}
		for (int l = 0; l < list2.Count; l++)
		{
			Connect(list2[l]);
		}
	}

	public void AddConnections(NodePort targetPort)
	{
		int connectionCount = targetPort.ConnectionCount;
		for (int i = 0; i < connectionCount; i++)
		{
			NodePort port = targetPort.connections[i].Port;
			Connect(port);
		}
	}

	public void MoveConnections(NodePort targetPort)
	{
		int count = connections.Count;
		for (int i = 0; i < count; i++)
		{
			NodePort port = targetPort.connections[i].Port;
			Connect(port);
		}
		ClearConnections();
	}

	public void Redirect(List<Node> oldNodes, List<Node> newNodes)
	{
		foreach (PortConnection connection in connections)
		{
			int num = oldNodes.IndexOf(connection.node);
			if (num >= 0)
			{
				connection.node = newNodes[num];
			}
		}
	}
}
public class SceneGraph : MonoBehaviour
{
	public NodeGraph graph;
}
public class SceneGraph<T> : SceneGraph where T : NodeGraph
{
	public new T graph
	{
		get
		{
			return base.graph as T;
		}
		set
		{
			base.graph = value;
		}
	}
}
