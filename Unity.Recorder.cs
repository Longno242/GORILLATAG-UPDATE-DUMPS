using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

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
			FilePathsData = new byte[204]
			{
				0, 0, 0, 1, 0, 0, 0, 63, 92, 80,
				97, 99, 107, 97, 103, 101, 115, 92, 99, 111,
				109, 46, 117, 110, 105, 116, 121, 46, 114, 101,
				99, 111, 114, 100, 101, 114, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 79, 98, 106, 101, 99,
				116, 82, 101, 99, 111, 114, 100, 105, 110, 103,
				83, 101, 116, 116, 105, 110, 103, 115, 46, 99,
				115, 0, 0, 0, 2, 0, 0, 0, 56, 92,
				80, 97, 99, 107, 97, 103, 101, 115, 92, 99,
				111, 109, 46, 117, 110, 105, 116, 121, 46, 114,
				101, 99, 111, 114, 100, 101, 114, 92, 82, 117,
				110, 116, 105, 109, 101, 92, 82, 101, 99, 111,
				114, 100, 101, 114, 66, 105, 110, 100, 105, 110,
				103, 115, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 61, 92, 80, 97, 99, 107, 97, 103,
				101, 115, 92, 99, 111, 109, 46, 117, 110, 105,
				116, 121, 46, 114, 101, 99, 111, 114, 100, 101,
				114, 92, 82, 117, 110, 116, 105, 109, 101, 92,
				83, 101, 114, 105, 97, 108, 105, 122, 101, 100,
				68, 105, 99, 116, 105, 111, 110, 110, 97, 114,
				121, 46, 99, 115
			},
			TypesData = new byte[195]
			{
				0, 0, 0, 0, 44, 85, 110, 105, 116, 121,
				69, 110, 103, 105, 110, 101, 46, 82, 101, 99,
				111, 114, 100, 101, 114, 124, 79, 98, 106, 101,
				99, 116, 82, 101, 99, 111, 114, 100, 105, 110,
				103, 83, 101, 116, 116, 105, 110, 103, 115, 0,
				0, 0, 0, 37, 85, 110, 105, 116, 121, 69,
				110, 103, 105, 110, 101, 46, 82, 101, 99, 111,
				114, 100, 101, 114, 124, 82, 101, 99, 111, 114,
				100, 101, 114, 66, 105, 110, 100, 105, 110, 103,
				115, 0, 0, 0, 0, 53, 85, 110, 105, 116,
				121, 69, 110, 103, 105, 110, 101, 46, 82, 101,
				99, 111, 114, 100, 101, 114, 46, 82, 101, 99,
				111, 114, 100, 101, 114, 66, 105, 110, 100, 105,
				110, 103, 115, 124, 80, 114, 111, 112, 101, 114,
				116, 121, 79, 98, 106, 101, 99, 116, 115, 0,
				0, 0, 0, 41, 85, 110, 105, 116, 121, 69,
				110, 103, 105, 110, 101, 46, 82, 101, 99, 111,
				114, 100, 101, 114, 124, 83, 101, 114, 105, 97,
				108, 105, 122, 101, 100, 68, 105, 99, 116, 105,
				111, 110, 97, 114, 121
			},
			TotalFiles = 3,
			TotalTypes = 4,
			IsEditorOnly = false
		};
	}
}
namespace UnityEngine.Recorder;

[AddComponentMenu("Recording/Object Recording Settings")]
public class ObjectRecordingSettings : MonoBehaviour
{
	[Tooltip("Record localPosition curves for this object.")]
	public bool recordPosition = true;

	[Tooltip("Record localRotation curves for this object.")]
	public bool recordRotation = true;

	[Tooltip("Record localScale curves for this object.")]
	public bool recordScale = true;
}
[ExecuteInEditMode]
public class RecorderBindings : MonoBehaviour
{
	[Serializable]
	private class PropertyObjects : SerializedDictionary<string, Object>
	{
	}

	[SerializeField]
	private PropertyObjects m_References = new PropertyObjects();

	public void SetBindingValue(string id, Object value)
	{
		m_References.dictionary[id] = value;
	}

	public Object GetBindingValue(string id)
	{
		if (!m_References.dictionary.TryGetValue(id, out var value))
		{
			return null;
		}
		return value;
	}

	public bool HasBindingValue(string id)
	{
		return m_References.dictionary.ContainsKey(id);
	}

	public void RemoveBinding(string id)
	{
		if (m_References.dictionary.ContainsKey(id))
		{
			m_References.dictionary.Remove(id);
			MarkSceneDirty();
		}
	}

	public bool IsEmpty()
	{
		if (m_References != null)
		{
			return !m_References.dictionary.Keys.Any();
		}
		return true;
	}

	public void DuplicateBinding(string src, string dst)
	{
		if (m_References.dictionary.ContainsKey(src))
		{
			m_References.dictionary[dst] = m_References.dictionary[src];
			MarkSceneDirty();
		}
	}

	private void MarkSceneDirty()
	{
	}
}
[Serializable]
internal class SerializedDictionary<TKey, TValue> : ISerializationCallbackReceiver
{
	[SerializeField]
	private List<TKey> m_Keys = new List<TKey>();

	[SerializeField]
	private List<TValue> m_Values = new List<TValue>();

	private readonly Dictionary<TKey, TValue> m_Dictionary = new Dictionary<TKey, TValue>();

	public Dictionary<TKey, TValue> dictionary => m_Dictionary;

	public void OnBeforeSerialize()
	{
		m_Keys.Clear();
		m_Values.Clear();
		foreach (KeyValuePair<TKey, TValue> item in m_Dictionary)
		{
			m_Keys.Add(item.Key);
			m_Values.Add(item.Value);
		}
	}

	public void OnAfterDeserialize()
	{
		m_Dictionary.Clear();
		for (int i = 0; i < m_Keys.Count; i++)
		{
			m_Dictionary.Add(m_Keys[i], m_Values[i]);
		}
	}
}
