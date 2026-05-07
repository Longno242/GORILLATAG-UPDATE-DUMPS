using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Unity.ProBuilder")]
[assembly: InternalsVisibleTo("Unity.ProBuilder.Editor")]
[assembly: InternalsVisibleTo("Unity.ProBuilder.Editor.Tests")]
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
			FilePathsData = new byte[315]
			{
				0, 0, 0, 1, 0, 0, 0, 91, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				112, 114, 111, 98, 117, 105, 108, 100, 101, 114,
				64, 57, 98, 54, 54, 57, 51, 102, 48, 57,
				102, 57, 55, 92, 69, 120, 116, 101, 114, 110,
				97, 108, 92, 83, 116, 108, 69, 120, 112, 111,
				114, 116, 101, 114, 92, 67, 111, 100, 101, 92,
				112, 98, 95, 83, 116, 108, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 100, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 117, 110, 105, 116, 121, 46, 112,
				114, 111, 98, 117, 105, 108, 100, 101, 114, 64,
				57, 98, 54, 54, 57, 51, 102, 48, 57, 102,
				57, 55, 92, 69, 120, 116, 101, 114, 110, 97,
				108, 92, 83, 116, 108, 69, 120, 112, 111, 114,
				116, 101, 114, 92, 67, 111, 100, 101, 92, 112,
				98, 95, 83, 116, 108, 95, 69, 120, 112, 111,
				114, 116, 101, 114, 46, 99, 115, 0, 0, 0,
				2, 0, 0, 0, 100, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 117, 110, 105, 116, 121, 46, 112, 114, 111,
				98, 117, 105, 108, 100, 101, 114, 64, 57, 98,
				54, 54, 57, 51, 102, 48, 57, 102, 57, 55,
				92, 69, 120, 116, 101, 114, 110, 97, 108, 92,
				83, 116, 108, 69, 120, 112, 111, 114, 116, 101,
				114, 92, 67, 111, 100, 101, 92, 112, 98, 95,
				83, 116, 108, 95, 73, 109, 112, 111, 114, 116,
				101, 114, 46, 99, 115
			},
			TypesData = new byte[185]
			{
				0, 0, 0, 0, 33, 85, 110, 105, 116, 121,
				69, 110, 103, 105, 110, 101, 46, 80, 114, 111,
				66, 117, 105, 108, 100, 101, 114, 46, 83, 116,
				108, 124, 112, 98, 95, 83, 116, 108, 0, 0,
				0, 0, 42, 85, 110, 105, 116, 121, 69, 110,
				103, 105, 110, 101, 46, 80, 114, 111, 66, 117,
				105, 108, 100, 101, 114, 46, 83, 116, 108, 124,
				112, 98, 95, 83, 116, 108, 95, 69, 120, 112,
				111, 114, 116, 101, 114, 0, 0, 0, 0, 42,
				85, 110, 105, 116, 121, 69, 110, 103, 105, 110,
				101, 46, 80, 114, 111, 66, 117, 105, 108, 100,
				101, 114, 46, 83, 116, 108, 124, 112, 98, 95,
				83, 116, 108, 95, 73, 109, 112, 111, 114, 116,
				101, 114, 0, 0, 0, 0, 48, 85, 110, 105,
				116, 121, 69, 110, 103, 105, 110, 101, 46, 80,
				114, 111, 66, 117, 105, 108, 100, 101, 114, 46,
				83, 116, 108, 46, 112, 98, 95, 83, 116, 108,
				95, 73, 109, 112, 111, 114, 116, 101, 114, 124,
				70, 97, 99, 101, 116
			},
			TotalFiles = 3,
			TotalTypes = 4,
			IsEditorOnly = false
		};
	}
}
namespace UnityEngine.ProBuilder.Stl;

[EditorBrowsable(EditorBrowsableState.Never)]
public enum FileType
{
	Ascii,
	Binary
}
internal static class pb_Stl
{
	public static bool WriteFile(string path, Mesh mesh, FileType type = FileType.Ascii, bool convertToRightHandedCoordinates = true)
	{
		return WriteFile(path, new Mesh[1] { mesh }, type, convertToRightHandedCoordinates);
	}

	public static bool WriteFile(string path, IList<Mesh> meshes, FileType type = FileType.Ascii, bool convertToRightHandedCoordinates = true)
	{
		try
		{
			if (type == FileType.Binary)
			{
				using BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create), new ASCIIEncoding());
				binaryWriter.Write(new byte[80]);
				uint value = (uint)(meshes.Sum((Mesh x) => x.triangles.Length) / 3);
				binaryWriter.Write(value);
				foreach (Mesh mesh in meshes)
				{
					Vector3[] array = (convertToRightHandedCoordinates ? Left2Right(mesh.vertices) : mesh.vertices);
					Vector3[] array2 = (convertToRightHandedCoordinates ? Left2Right(mesh.normals) : mesh.normals);
					int[] triangles = mesh.triangles;
					int num = triangles.Length;
					if (convertToRightHandedCoordinates)
					{
						Array.Reverse(triangles);
					}
					for (int num2 = 0; num2 < num; num2 += 3)
					{
						int num3 = triangles[num2];
						int num4 = triangles[num2 + 1];
						int num5 = triangles[num2 + 2];
						Vector3 vector = AvgNrm(array2[num3], array2[num4], array2[num5]);
						binaryWriter.Write(vector.x);
						binaryWriter.Write(vector.y);
						binaryWriter.Write(vector.z);
						binaryWriter.Write(array[num3].x);
						binaryWriter.Write(array[num3].y);
						binaryWriter.Write(array[num3].z);
						binaryWriter.Write(array[num4].x);
						binaryWriter.Write(array[num4].y);
						binaryWriter.Write(array[num4].z);
						binaryWriter.Write(array[num5].x);
						binaryWriter.Write(array[num5].y);
						binaryWriter.Write(array[num5].z);
						binaryWriter.Write((ushort)0);
					}
				}
			}
			else
			{
				string contents = WriteString(meshes);
				File.WriteAllText(path, contents);
			}
		}
		catch (Exception ex)
		{
			Debug.LogError(ex.ToString());
			return false;
		}
		return true;
	}

	public static string WriteString(Mesh mesh, bool convertToRightHandedCoordinates = true)
	{
		return WriteString(new Mesh[1] { mesh }, convertToRightHandedCoordinates);
	}

	public static string WriteString(IList<Mesh> meshes, bool convertToRightHandedCoordinates = true)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string arg = ((meshes.Count == 1) ? meshes[0].name : "Composite Mesh");
		stringBuilder.AppendLine($"solid {arg}");
		foreach (Mesh mesh in meshes)
		{
			Vector3[] array = (convertToRightHandedCoordinates ? Left2Right(mesh.vertices) : mesh.vertices);
			Vector3[] array2 = (convertToRightHandedCoordinates ? Left2Right(mesh.normals) : mesh.normals);
			int[] triangles = mesh.triangles;
			if (convertToRightHandedCoordinates)
			{
				Array.Reverse(triangles);
			}
			int num = triangles.Length;
			for (int i = 0; i < num; i += 3)
			{
				int num2 = triangles[i];
				int num3 = triangles[i + 1];
				int num4 = triangles[i + 2];
				Vector3 vector = AvgNrm(array2[num2], array2[num3], array2[num4]);
				stringBuilder.AppendLine($"facet normal {vector.x} {vector.y} {vector.z}");
				stringBuilder.AppendLine("outer loop");
				stringBuilder.AppendLine($"\tvertex {array[num2].x} {array[num2].y} {array[num2].z}");
				stringBuilder.AppendLine($"\tvertex {array[num3].x} {array[num3].y} {array[num3].z}");
				stringBuilder.AppendLine($"\tvertex {array[num4].x} {array[num4].y} {array[num4].z}");
				stringBuilder.AppendLine("endloop");
				stringBuilder.AppendLine("endfacet");
			}
		}
		stringBuilder.AppendLine($"endsolid {arg}");
		return stringBuilder.ToString();
	}

	private static Vector3[] Left2Right(Vector3[] v)
	{
		Vector3[] array = new Vector3[v.Length];
		for (int i = 0; i < v.Length; i++)
		{
			array[i] = new Vector3(v[i].z, 0f - v[i].x, v[i].y);
		}
		return array;
	}

	private static Vector3 AvgNrm(Vector3 a, Vector3 b, Vector3 c)
	{
		return new Vector3((a.x + b.x + c.x) / 3f, (a.y + b.y + c.y) / 3f, (a.z + b.z + c.z) / 3f);
	}
}
internal static class pb_Stl_Exporter
{
	public static bool Export(string path, GameObject[] gameObjects, FileType type)
	{
		Mesh[] array = CreateWorldSpaceMeshesWithTransforms(gameObjects.Select((GameObject x) => x.transform).ToArray());
		bool result = false;
		if (array != null && array.Length != 0 && !string.IsNullOrEmpty(path))
		{
			result = pb_Stl.WriteFile(path, array, type);
		}
		int num = 0;
		while (array != null && num < array.Length)
		{
			Object.DestroyImmediate(array[num]);
			num++;
		}
		return result;
	}

	private static Mesh[] CreateWorldSpaceMeshesWithTransforms(IList<Transform> transforms)
	{
		if (transforms == null || transforms.Count < 1)
		{
			return null;
		}
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < transforms.Count; i++)
		{
			zero += transforms[i].position;
		}
		Vector3 position = zero / transforms.Count;
		GameObject gameObject = new GameObject();
		gameObject.name = "ROOT";
		gameObject.transform.position = position;
		foreach (Transform transform2 in transforms)
		{
			GameObject gameObject2 = Object.Instantiate(transform2.gameObject);
			gameObject2.transform.SetParent(transform2.parent, worldPositionStays: false);
			gameObject2.transform.SetParent(gameObject.transform, worldPositionStays: true);
		}
		gameObject.transform.position = Vector3.zero;
		List<MeshFilter> list = (from x in gameObject.GetComponentsInChildren<MeshFilter>()
			where x.sharedMesh != null
			select x).ToList();
		int count = list.Count;
		Mesh[] array = new Mesh[count];
		for (int num = 0; num < count; num++)
		{
			Transform transform = list[num].transform;
			Vector3[] vertices = list[num].sharedMesh.vertices;
			Vector3[] normals = list[num].sharedMesh.normals;
			for (int num2 = 0; num2 < vertices.Length; num2++)
			{
				vertices[num2] = transform.TransformPoint(vertices[num2]);
				normals[num2] = transform.TransformDirection(normals[num2]);
			}
			Mesh mesh = new Mesh();
			mesh.name = list[num].name;
			mesh.vertices = vertices;
			mesh.normals = normals;
			mesh.triangles = list[num].sharedMesh.triangles;
			array[num] = mesh;
		}
		Object.DestroyImmediate(gameObject);
		return array;
	}
}
internal static class pb_Stl_Importer
{
	private class Facet
	{
		public Vector3 normal;

		public Vector3 a;

		public Vector3 b;

		public Vector3 c;

		public override string ToString()
		{
			return $"{normal:F2}: {a:F2}, {b:F2}, {c:F2}";
		}
	}

	private const int MAX_FACETS_PER_MESH = 21845;

	private const int SOLID = 1;

	private const int FACET = 2;

	private const int OUTER = 3;

	private const int VERTEX = 4;

	private const int ENDLOOP = 5;

	private const int ENDFACET = 6;

	private const int ENDSOLID = 7;

	private const int EMPTY = 0;

	public static Mesh[] Import(string path)
	{
		if (IsBinary(path))
		{
			try
			{
				return ImportBinary(path);
			}
			catch (Exception ex)
			{
				Debug.LogWarning($"Failed importing mesh at path {path}.\n{ex.ToString()}");
				return null;
			}
		}
		return ImportAscii(path);
	}

	private static Mesh[] ImportBinary(string path)
	{
		Facet[] array;
		using (FileStream input = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			using BinaryReader binaryReader = new BinaryReader(input, new ASCIIEncoding());
			binaryReader.ReadBytes(80);
			uint num = binaryReader.ReadUInt32();
			array = new Facet[num];
			for (uint num2 = 0u; num2 < num; num2++)
			{
				array[num2] = binaryReader.GetFacet();
			}
		}
		return CreateMeshWithFacets(array);
	}

	private static Facet GetFacet(this BinaryReader binaryReader)
	{
		Facet result = new Facet
		{
			normal = binaryReader.GetVector3(),
			a = binaryReader.GetVector3(),
			c = binaryReader.GetVector3(),
			b = binaryReader.GetVector3()
		};
		binaryReader.ReadUInt16();
		return result;
	}

	private static Vector3 GetVector3(this BinaryReader binaryReader)
	{
		Vector3 vector = default(Vector3);
		for (int i = 0; i < 3; i++)
		{
			vector[i] = binaryReader.ReadSingle();
		}
		return vector.UnityCoordTrafo();
	}

	private static Vector3 UnityCoordTrafo(this Vector3 vector3)
	{
		return new Vector3(0f - vector3.y, vector3.z, vector3.x);
	}

	private static int ReadState(string line)
	{
		if (line.StartsWith("solid"))
		{
			return 1;
		}
		if (line.StartsWith("facet"))
		{
			return 2;
		}
		if (line.StartsWith("outer"))
		{
			return 3;
		}
		if (line.StartsWith("vertex"))
		{
			return 4;
		}
		if (line.StartsWith("endloop"))
		{
			return 5;
		}
		if (line.StartsWith("endfacet"))
		{
			return 6;
		}
		if (line.StartsWith("endsolid"))
		{
			return 7;
		}
		return 0;
	}

	private static Mesh[] ImportAscii(string path)
	{
		List<Facet> list = new List<Facet>();
		using (StreamReader streamReader = new StreamReader(path))
		{
			int num = 0;
			int num2 = 0;
			Facet facet = null;
			bool flag = false;
			while (streamReader.Peek() > 0 && !flag)
			{
				string text = streamReader.ReadLine().Trim();
				switch (ReadState(text))
				{
				case 2:
					facet = new Facet();
					facet.normal = StringToVec3(text.Replace("facet normal ", ""));
					break;
				case 3:
					num2 = 0;
					break;
				case 4:
					switch (num2)
					{
					case 0:
						facet.a = StringToVec3(text.Replace("vertex ", ""));
						break;
					case 2:
						facet.c = StringToVec3(text.Replace("vertex ", ""));
						break;
					case 1:
						facet.b = StringToVec3(text.Replace("vertex ", ""));
						break;
					}
					num2++;
					break;
				case 6:
					list.Add(facet);
					break;
				case 7:
					flag = true;
					break;
				}
			}
		}
		return CreateMeshWithFacets(list);
	}

	private static Vector3 StringToVec3(string str)
	{
		string[] array = str.Trim().Split((char[])null);
		Vector3 vector = default(Vector3);
		float.TryParse(array[0], out vector.x);
		float.TryParse(array[1], out vector.y);
		float.TryParse(array[2], out vector.z);
		return vector.UnityCoordTrafo();
	}

	private static bool IsBinary(string path)
	{
		FileInfo fileInfo = new FileInfo(path);
		if (fileInfo.Length < 130)
		{
			return false;
		}
		bool flag = false;
		using (FileStream stream = fileInfo.OpenRead())
		{
			using BufferedStream bufferedStream = new BufferedStream(stream);
			for (long num = 0L; num < 80; num++)
			{
				if (bufferedStream.ReadByte() == 0)
				{
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			using FileStream stream2 = fileInfo.OpenRead();
			using BufferedStream bufferedStream2 = new BufferedStream(stream2);
			byte[] array = new byte[6];
			for (int i = 0; i < 6; i++)
			{
				array[i] = (byte)bufferedStream2.ReadByte();
			}
			flag = Encoding.UTF8.GetString(array) != "solid ";
		}
		return flag;
	}

	private static Mesh[] CreateMeshWithFacets(IList<Facet> facets)
	{
		int count = facets.Count;
		int num = 0;
		int val = 65535;
		Mesh[] array = new Mesh[count / 21845 + 1];
		for (int i = 0; i < array.Length; i++)
		{
			int num2 = Math.Min(val, (count - num) * 3);
			Vector3[] array2 = new Vector3[num2];
			Vector3[] array3 = new Vector3[num2];
			int[] array4 = new int[num2];
			for (int j = 0; j < num2; j += 3)
			{
				array2[j] = facets[num].a;
				array2[j + 1] = facets[num].b;
				array2[j + 2] = facets[num].c;
				array3[j] = facets[num].normal;
				array3[j + 1] = facets[num].normal;
				array3[j + 2] = facets[num].normal;
				array4[j] = j;
				array4[j + 1] = j + 1;
				array4[j + 2] = j + 2;
				num++;
			}
			array[i] = new Mesh();
			array[i].vertices = array2;
			array[i].normals = array3;
			array[i].triangles = array4;
		}
		return array;
	}
}
