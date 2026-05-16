using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

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
			FilePathsData = new byte[228]
			{
				0, 0, 0, 1, 0, 0, 0, 112, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				115, 99, 114, 105, 112, 116, 97, 98, 108, 101,
				98, 117, 105, 108, 100, 112, 105, 112, 101, 108,
				105, 110, 101, 64, 99, 97, 51, 101, 50, 100,
				57, 54, 97, 97, 50, 102, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 67, 111, 109, 112, 97,
				116, 105, 98, 105, 108, 105, 116, 121, 65, 115,
				115, 101, 116, 66, 117, 110, 100, 108, 101, 77,
				97, 110, 105, 102, 101, 115, 116, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 100, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				115, 99, 114, 105, 112, 116, 97, 98, 108, 101,
				98, 117, 105, 108, 100, 112, 105, 112, 101, 108,
				105, 110, 101, 64, 99, 97, 51, 101, 50, 100,
				57, 54, 97, 97, 50, 102, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 83, 104, 97, 114, 101,
				100, 92, 66, 117, 110, 100, 108, 101, 68, 101,
				116, 97, 105, 108, 115, 46, 99, 115
			},
			TypesData = new byte[109]
			{
				0, 0, 0, 0, 59, 85, 110, 105, 116, 121,
				69, 110, 103, 105, 110, 101, 46, 66, 117, 105,
				108, 100, 46, 80, 105, 112, 101, 108, 105, 110,
				101, 124, 67, 111, 109, 112, 97, 116, 105, 98,
				105, 108, 105, 116, 121, 65, 115, 115, 101, 116,
				66, 117, 110, 100, 108, 101, 77, 97, 110, 105,
				102, 101, 115, 116, 0, 0, 0, 0, 40, 85,
				110, 105, 116, 121, 69, 110, 103, 105, 110, 101,
				46, 66, 117, 105, 108, 100, 46, 80, 105, 112,
				101, 108, 105, 110, 101, 124, 66, 117, 110, 100,
				108, 101, 68, 101, 116, 97, 105, 108, 115
			},
			TotalFiles = 2,
			TotalTypes = 2,
			IsEditorOnly = false
		};
	}
}
namespace UnityEngine.Build.Pipeline;

[Serializable]
public class CompatibilityAssetBundleManifest : ScriptableObject, ISerializationCallbackReceiver
{
	private Dictionary<string, BundleDetails> m_Details;

	[SerializeField]
	private List<string> m_Keys;

	[SerializeField]
	private List<BundleDetails> m_Values;

	public void SetResults(Dictionary<string, BundleDetails> results)
	{
		m_Details = new Dictionary<string, BundleDetails>(results);
	}

	public string[] GetAllAssetBundles()
	{
		string[] array = m_Details.Keys.ToArray();
		Array.Sort(array);
		return array;
	}

	public string[] GetAllAssetBundlesWithVariant()
	{
		return new string[0];
	}

	public Hash128 GetAssetBundleHash(string assetBundleName)
	{
		if (m_Details.TryGetValue(assetBundleName, out var value))
		{
			return value.Hash;
		}
		return default(Hash128);
	}

	public uint GetAssetBundleCrc(string assetBundleName)
	{
		if (m_Details.TryGetValue(assetBundleName, out var value))
		{
			return value.Crc;
		}
		return 0u;
	}

	public string[] GetDirectDependencies(string assetBundleName)
	{
		return GetAllDependencies(assetBundleName);
	}

	public string[] GetAllDependencies(string assetBundleName)
	{
		if (m_Details.TryGetValue(assetBundleName, out var value))
		{
			return value.Dependencies.ToArray();
		}
		return new string[0];
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("ManifestFileVersion: 1\n");
		stringBuilder.Append("CompatibilityAssetBundleManifest:\n");
		if (m_Details != null && m_Details.Count > 0)
		{
			stringBuilder.Append("  AssetBundleInfos:\n");
			int num = 0;
			foreach (KeyValuePair<string, BundleDetails> detail in m_Details)
			{
				stringBuilder.AppendFormat("    Info_{0}:\n", num++);
				stringBuilder.AppendFormat("      Name: {0}\n", detail.Key);
				stringBuilder.AppendFormat("      Hash: {0}\n", detail.Value.Hash);
				stringBuilder.AppendFormat("      CRC: {0}\n", detail.Value.Crc);
				int num2 = 0;
				if (detail.Value.Dependencies != null && detail.Value.Dependencies.Length != 0)
				{
					stringBuilder.Append("      Dependencies: {}\n");
					string[] dependencies = detail.Value.Dependencies;
					foreach (string arg in dependencies)
					{
						stringBuilder.AppendFormat("        Dependency_{0}: {1}\n", num2++, arg);
					}
				}
				else
				{
					stringBuilder.Append("      Dependencies: {}\n");
				}
			}
		}
		else
		{
			stringBuilder.Append("  AssetBundleInfos: {}\n");
		}
		return stringBuilder.ToString();
	}

	public void OnBeforeSerialize()
	{
		m_Keys = new List<string>();
		m_Values = new List<BundleDetails>();
		foreach (KeyValuePair<string, BundleDetails> detail in m_Details)
		{
			m_Keys.Add(detail.Key);
			m_Values.Add(detail.Value);
		}
	}

	public void OnAfterDeserialize()
	{
		m_Details = new Dictionary<string, BundleDetails>();
		for (int i = 0; i != Math.Min(m_Keys.Count, m_Values.Count); i++)
		{
			m_Details.Add(m_Keys[i], m_Values[i]);
		}
	}
}
[Serializable]
public struct BundleDetails : IEquatable<BundleDetails>
{
	[SerializeField]
	private string m_FileName;

	[SerializeField]
	private uint m_Crc;

	[SerializeField]
	private string m_Hash;

	[SerializeField]
	private string[] m_Dependencies;

	public string FileName
	{
		get
		{
			return m_FileName;
		}
		set
		{
			m_FileName = value;
		}
	}

	public uint Crc
	{
		get
		{
			return m_Crc;
		}
		set
		{
			m_Crc = value;
		}
	}

	public Hash128 Hash
	{
		get
		{
			return Hash128.Parse(m_Hash);
		}
		set
		{
			m_Hash = value.ToString();
		}
	}

	public string[] Dependencies
	{
		get
		{
			return m_Dependencies;
		}
		set
		{
			m_Dependencies = value;
		}
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is BundleDetails)
		{
			return Equals((BundleDetails)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (int)(((((uint)(((FileName != null) ? FileName.GetHashCode() : 0) * 397) ^ Crc) * 397) ^ (uint)Hash.GetHashCode()) * 397) ^ ((Dependencies != null) ? Dependencies.GetHashCode() : 0);
	}

	public static bool operator ==(BundleDetails a, BundleDetails b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(BundleDetails a, BundleDetails b)
	{
		return !(a == b);
	}

	public bool Equals(BundleDetails other)
	{
		if (string.Equals(FileName, other.FileName) && Crc == other.Crc && Hash.Equals(other.Hash))
		{
			return object.Equals(Dependencies, other.Dependencies);
		}
		return false;
	}
}
