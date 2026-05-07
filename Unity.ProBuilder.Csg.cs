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
			FilePathsData = new byte[651]
			{
				0, 0, 0, 1, 0, 0, 0, 85, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				112, 114, 111, 98, 117, 105, 108, 100, 101, 114,
				64, 57, 98, 54, 54, 57, 51, 102, 48, 57,
				102, 57, 55, 92, 69, 120, 116, 101, 114, 110,
				97, 108, 92, 67, 83, 71, 92, 67, 108, 97,
				115, 115, 101, 115, 92, 77, 111, 100, 101, 108,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				84, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 117, 110, 105,
				116, 121, 46, 112, 114, 111, 98, 117, 105, 108,
				100, 101, 114, 64, 57, 98, 54, 54, 57, 51,
				102, 48, 57, 102, 57, 55, 92, 69, 120, 116,
				101, 114, 110, 97, 108, 92, 67, 83, 71, 92,
				67, 108, 97, 115, 115, 101, 115, 92, 78, 111,
				100, 101, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 85, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 117,
				110, 105, 116, 121, 46, 112, 114, 111, 98, 117,
				105, 108, 100, 101, 114, 64, 57, 98, 54, 54,
				57, 51, 102, 48, 57, 102, 57, 55, 92, 69,
				120, 116, 101, 114, 110, 97, 108, 92, 67, 83,
				71, 92, 67, 108, 97, 115, 115, 101, 115, 92,
				80, 108, 97, 110, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 87, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 117, 110, 105, 116, 121, 46, 112, 114,
				111, 98, 117, 105, 108, 100, 101, 114, 64, 57,
				98, 54, 54, 57, 51, 102, 48, 57, 102, 57,
				55, 92, 69, 120, 116, 101, 114, 110, 97, 108,
				92, 67, 83, 71, 92, 67, 108, 97, 115, 115,
				101, 115, 92, 80, 111, 108, 121, 103, 111, 110,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				86, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 117, 110, 105,
				116, 121, 46, 112, 114, 111, 98, 117, 105, 108,
				100, 101, 114, 64, 57, 98, 54, 54, 57, 51,
				102, 48, 57, 102, 57, 55, 92, 69, 120, 116,
				101, 114, 110, 97, 108, 92, 67, 83, 71, 92,
				67, 108, 97, 115, 115, 101, 115, 92, 86, 101,
				114, 116, 101, 120, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 93, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 117, 110, 105, 116, 121, 46, 112, 114, 111,
				98, 117, 105, 108, 100, 101, 114, 64, 57, 98,
				54, 54, 57, 51, 102, 48, 57, 102, 57, 55,
				92, 69, 120, 116, 101, 114, 110, 97, 108, 92,
				67, 83, 71, 92, 67, 108, 97, 115, 115, 101,
				115, 92, 86, 101, 114, 116, 101, 120, 85, 116,
				105, 108, 105, 116, 121, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 75, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 117, 110, 105, 116, 121, 46, 112, 114,
				111, 98, 117, 105, 108, 100, 101, 114, 64, 57,
				98, 54, 54, 57, 51, 102, 48, 57, 102, 57,
				55, 92, 69, 120, 116, 101, 114, 110, 97, 108,
				92, 67, 83, 71, 92, 67, 83, 71, 46, 99,
				115
			},
			TypesData = new byte[267]
			{
				0, 0, 0, 0, 32, 85, 110, 105, 116, 121,
				69, 110, 103, 105, 110, 101, 46, 80, 114, 111,
				66, 117, 105, 108, 100, 101, 114, 46, 67, 115,
				103, 124, 77, 111, 100, 101, 108, 0, 0, 0,
				0, 31, 85, 110, 105, 116, 121, 69, 110, 103,
				105, 110, 101, 46, 80, 114, 111, 66, 117, 105,
				108, 100, 101, 114, 46, 67, 115, 103, 124, 78,
				111, 100, 101, 0, 0, 0, 0, 32, 85, 110,
				105, 116, 121, 69, 110, 103, 105, 110, 101, 46,
				80, 114, 111, 66, 117, 105, 108, 100, 101, 114,
				46, 67, 115, 103, 124, 80, 108, 97, 110, 101,
				0, 0, 0, 0, 34, 85, 110, 105, 116, 121,
				69, 110, 103, 105, 110, 101, 46, 80, 114, 111,
				66, 117, 105, 108, 100, 101, 114, 46, 67, 115,
				103, 124, 80, 111, 108, 121, 103, 111, 110, 0,
				0, 0, 0, 33, 85, 110, 105, 116, 121, 69,
				110, 103, 105, 110, 101, 46, 80, 114, 111, 66,
				117, 105, 108, 100, 101, 114, 46, 67, 115, 103,
				124, 86, 101, 114, 116, 101, 120, 0, 0, 0,
				0, 40, 85, 110, 105, 116, 121, 69, 110, 103,
				105, 110, 101, 46, 80, 114, 111, 66, 117, 105,
				108, 100, 101, 114, 46, 67, 115, 103, 124, 86,
				101, 114, 116, 101, 120, 85, 116, 105, 108, 105,
				116, 121, 0, 0, 0, 0, 30, 85, 110, 105,
				116, 121, 69, 110, 103, 105, 110, 101, 46, 80,
				114, 111, 66, 117, 105, 108, 100, 101, 114, 46,
				67, 115, 103, 124, 67, 83, 71
			},
			TotalFiles = 7,
			TotalTypes = 7,
			IsEditorOnly = false
		};
	}
}
namespace UnityEngine.ProBuilder.Csg;

internal sealed class Model
{
	private List<Vertex> m_Vertices;

	private List<Material> m_Materials;

	private List<List<int>> m_Indices;

	public List<Material> materials
	{
		get
		{
			return m_Materials;
		}
		set
		{
			m_Materials = value;
		}
	}

	public List<Vertex> vertices
	{
		get
		{
			return m_Vertices;
		}
		set
		{
			m_Vertices = value;
		}
	}

	public List<List<int>> indices
	{
		get
		{
			return m_Indices;
		}
		set
		{
			m_Indices = value;
		}
	}

	public Mesh mesh => (Mesh)this;

	public Model(GameObject gameObject)
		: this(gameObject.GetComponent<MeshFilter>()?.sharedMesh, gameObject.GetComponent<MeshRenderer>()?.sharedMaterials, gameObject.GetComponent<Transform>())
	{
	}

	public Model(Mesh mesh, Material[] materials, Transform transform)
	{
		if (mesh == null)
		{
			throw new ArgumentNullException("mesh");
		}
		if (transform == null)
		{
			throw new ArgumentNullException("transform");
		}
		m_Vertices = (from x in mesh.GetVertices()
			select transform.TransformVertex(x)).ToList();
		m_Materials = new List<Material>(materials);
		m_Indices = new List<List<int>>();
		int num = 0;
		for (int subMeshCount = mesh.subMeshCount; num < subMeshCount; num++)
		{
			if (mesh.GetTopology(num) == MeshTopology.Triangles)
			{
				List<int> item = new List<int>();
				mesh.GetIndices(item, num);
				m_Indices.Add(item);
			}
		}
	}

	internal Model(List<Polygon> polygons)
	{
		m_Vertices = new List<Vertex>();
		Dictionary<Material, List<int>> dictionary = new Dictionary<Material, List<int>>();
		int num = 0;
		for (int i = 0; i < polygons.Count; i++)
		{
			Polygon polygon = polygons[i];
			if (!dictionary.TryGetValue(polygon.material, out var value))
			{
				dictionary.Add(polygon.material, value = new List<int>());
			}
			for (int j = 2; j < polygon.vertices.Count; j++)
			{
				m_Vertices.Add(polygon.vertices[0]);
				value.Add(num++);
				m_Vertices.Add(polygon.vertices[j - 1]);
				value.Add(num++);
				m_Vertices.Add(polygon.vertices[j]);
				value.Add(num++);
			}
		}
		m_Materials = dictionary.Keys.ToList();
		m_Indices = dictionary.Values.ToList();
	}

	internal List<Polygon> ToPolygons()
	{
		List<Polygon> list = new List<Polygon>();
		int i = 0;
		for (int count = m_Indices.Count; i < count; i++)
		{
			List<int> list2 = m_Indices[i];
			int j = 0;
			_ = list2.Count;
			for (; j < list2.Count; j += 3)
			{
				List<Vertex> list3 = new List<Vertex>
				{
					m_Vertices[list2[j]],
					m_Vertices[list2[j + 1]],
					m_Vertices[list2[j + 2]]
				};
				list.Add(new Polygon(list3, m_Materials[i]));
			}
		}
		return list;
	}

	public static explicit operator Mesh(Model model)
	{
		Mesh mesh = new Mesh();
		VertexUtility.SetMesh(mesh, model.m_Vertices);
		mesh.subMeshCount = model.m_Indices.Count;
		int i = 0;
		for (int subMeshCount = mesh.subMeshCount; i < subMeshCount; i++)
		{
			mesh.SetIndices(model.m_Indices[i], MeshTopology.Triangles, i);
		}
		return mesh;
	}
}
internal sealed class Node
{
	public List<Polygon> polygons;

	public Node front;

	public Node back;

	public Plane plane;

	public Node()
	{
		front = null;
		back = null;
	}

	public Node(List<Polygon> list)
	{
		Build(list);
	}

	public Node(List<Polygon> list, Plane plane, Node front, Node back)
	{
		polygons = list;
		this.plane = plane;
		this.front = front;
		this.back = back;
	}

	public Node Clone()
	{
		return new Node(polygons, plane, front, back);
	}

	public void ClipTo(Node other)
	{
		polygons = other.ClipPolygons(polygons);
		if (front != null)
		{
			front.ClipTo(other);
		}
		if (back != null)
		{
			back.ClipTo(other);
		}
	}

	public void Invert()
	{
		for (int i = 0; i < polygons.Count; i++)
		{
			polygons[i].Flip();
		}
		plane.Flip();
		if (front != null)
		{
			front.Invert();
		}
		if (back != null)
		{
			back.Invert();
		}
		Node node = front;
		front = back;
		back = node;
	}

	public void Build(List<Polygon> list)
	{
		if (list.Count < 1)
		{
			return;
		}
		bool flag = plane == null || !plane.Valid();
		if (flag)
		{
			plane = new Plane();
			plane.normal = list[0].plane.normal;
			plane.w = list[0].plane.w;
		}
		if (polygons == null)
		{
			polygons = new List<Polygon>();
		}
		List<Polygon> list2 = new List<Polygon>();
		List<Polygon> list3 = new List<Polygon>();
		for (int i = 0; i < list.Count; i++)
		{
			plane.SplitPolygon(list[i], polygons, polygons, list2, list3);
		}
		if (list2.Count > 0)
		{
			if (flag && list.SequenceEqual(list2))
			{
				polygons.AddRange(list2);
			}
			else
			{
				(front ?? (front = new Node())).Build(list2);
			}
		}
		if (list3.Count > 0)
		{
			if (flag && list.SequenceEqual(list3))
			{
				polygons.AddRange(list3);
			}
			else
			{
				(back ?? (back = new Node())).Build(list3);
			}
		}
	}

	public List<Polygon> ClipPolygons(List<Polygon> list)
	{
		if (!plane.Valid())
		{
			return list;
		}
		List<Polygon> list2 = new List<Polygon>();
		List<Polygon> list3 = new List<Polygon>();
		for (int i = 0; i < list.Count; i++)
		{
			plane.SplitPolygon(list[i], list2, list3, list2, list3);
		}
		if (front != null)
		{
			list2 = front.ClipPolygons(list2);
		}
		if (back != null)
		{
			list3 = back.ClipPolygons(list3);
		}
		else
		{
			list3.Clear();
		}
		list2.AddRange(list3);
		return list2;
	}

	public List<Polygon> AllPolygons()
	{
		List<Polygon> list = polygons;
		List<Polygon> collection = new List<Polygon>();
		List<Polygon> collection2 = new List<Polygon>();
		if (front != null)
		{
			collection = front.AllPolygons();
		}
		if (back != null)
		{
			collection2 = back.AllPolygons();
		}
		list.AddRange(collection);
		list.AddRange(collection2);
		return list;
	}

	public static Node Union(Node a1, Node b1)
	{
		Node node = a1.Clone();
		Node node2 = b1.Clone();
		node.ClipTo(node2);
		node2.ClipTo(node);
		node2.Invert();
		node2.ClipTo(node);
		node2.Invert();
		node.Build(node2.AllPolygons());
		return new Node(node.AllPolygons());
	}

	public static Node Subtract(Node a1, Node b1)
	{
		Node node = a1.Clone();
		Node node2 = b1.Clone();
		node.Invert();
		node.ClipTo(node2);
		node2.ClipTo(node);
		node2.Invert();
		node2.ClipTo(node);
		node2.Invert();
		node.Build(node2.AllPolygons());
		node.Invert();
		return new Node(node.AllPolygons());
	}

	public static Node Intersect(Node a1, Node b1)
	{
		Node node = a1.Clone();
		Node node2 = b1.Clone();
		node.Invert();
		node2.ClipTo(node);
		node2.Invert();
		node.ClipTo(node2);
		node2.ClipTo(node);
		node.Build(node2.AllPolygons());
		node.Invert();
		return new Node(node.AllPolygons());
	}
}
internal sealed class Plane
{
	[Flags]
	private enum EPolygonType
	{
		Coplanar = 0,
		Front = 1,
		Back = 2,
		Spanning = 3
	}

	public Vector3 normal;

	public float w;

	public Plane()
	{
		normal = Vector3.zero;
		w = 0f;
	}

	public Plane(Vector3 a, Vector3 b, Vector3 c)
	{
		normal = Vector3.Cross(b - a, c - a);
		w = Vector3.Dot(normal, a);
	}

	public override string ToString()
	{
		return $"{normal} {w}";
	}

	public bool Valid()
	{
		return normal.magnitude > 0f;
	}

	public void Flip()
	{
		normal *= -1f;
		w *= -1f;
	}

	public void SplitPolygon(Polygon polygon, List<Polygon> coplanarFront, List<Polygon> coplanarBack, List<Polygon> front, List<Polygon> back)
	{
		EPolygonType ePolygonType = EPolygonType.Coplanar;
		List<EPolygonType> list = new List<EPolygonType>();
		for (int i = 0; i < polygon.vertices.Count; i++)
		{
			float num = Vector3.Dot(normal, polygon.vertices[i].position) - w;
			EPolygonType ePolygonType2 = ((num < 0f - CSG.epsilon) ? EPolygonType.Back : ((num > CSG.epsilon) ? EPolygonType.Front : EPolygonType.Coplanar));
			ePolygonType |= ePolygonType2;
			list.Add(ePolygonType2);
		}
		switch (ePolygonType)
		{
		case EPolygonType.Coplanar:
			if (Vector3.Dot(normal, polygon.plane.normal) > 0f)
			{
				coplanarFront.Add(polygon);
			}
			else
			{
				coplanarBack.Add(polygon);
			}
			break;
		case EPolygonType.Front:
			front.Add(polygon);
			break;
		case EPolygonType.Back:
			back.Add(polygon);
			break;
		case EPolygonType.Spanning:
		{
			List<Vertex> list2 = new List<Vertex>();
			List<Vertex> list3 = new List<Vertex>();
			for (int j = 0; j < polygon.vertices.Count; j++)
			{
				int index = (j + 1) % polygon.vertices.Count;
				EPolygonType ePolygonType3 = list[j];
				EPolygonType ePolygonType4 = list[index];
				Vertex vertex = polygon.vertices[j];
				Vertex y = polygon.vertices[index];
				if (ePolygonType3 != EPolygonType.Back)
				{
					list2.Add(vertex);
				}
				if (ePolygonType3 != EPolygonType.Front)
				{
					list3.Add(vertex);
				}
				if ((ePolygonType3 | ePolygonType4) == EPolygonType.Spanning)
				{
					float weight = (w - Vector3.Dot(normal, vertex.position)) / Vector3.Dot(normal, y.position - vertex.position);
					Vertex item = vertex.Mix(y, weight);
					list2.Add(item);
					list3.Add(item);
				}
			}
			if (list2.Count >= 3)
			{
				if (list2.SequenceEqual(polygon.vertices))
				{
					front.Add(polygon);
				}
				else
				{
					Polygon polygon2 = new Polygon(list2, polygon.material);
					if (polygon2.plane.Valid())
					{
						front.Add(polygon2);
					}
				}
			}
			if (list3.Count < 3)
			{
				break;
			}
			if (list3.SequenceEqual(polygon.vertices))
			{
				back.Add(polygon);
				break;
			}
			Polygon polygon3 = new Polygon(list3, polygon.material);
			if (polygon3.plane.Valid())
			{
				back.Add(polygon3);
			}
			break;
		}
		}
	}
}
internal sealed class Polygon
{
	public List<Vertex> vertices;

	public Plane plane;

	public Material material;

	public Polygon(List<Vertex> list, Material mat)
	{
		vertices = list;
		plane = new Plane(list[0].position, list[1].position, list[2].position);
		material = mat;
	}

	public void Flip()
	{
		vertices.Reverse();
		for (int i = 0; i < vertices.Count; i++)
		{
			vertices[i].Flip();
		}
		plane.Flip();
	}

	public override string ToString()
	{
		return $"[{vertices.Count}] {plane.normal}";
	}
}
internal struct Vertex
{
	private Vector3 m_Position;

	private Color m_Color;

	private Vector3 m_Normal;

	private Vector4 m_Tangent;

	private Vector2 m_UV0;

	private Vector2 m_UV2;

	private Vector4 m_UV3;

	private Vector4 m_UV4;

	private VertexAttributes m_Attributes;

	public Vector3 position
	{
		get
		{
			return m_Position;
		}
		set
		{
			hasPosition = true;
			m_Position = value;
		}
	}

	public Color color
	{
		get
		{
			return m_Color;
		}
		set
		{
			hasColor = true;
			m_Color = value;
		}
	}

	public Vector3 normal
	{
		get
		{
			return m_Normal;
		}
		set
		{
			hasNormal = true;
			m_Normal = value;
		}
	}

	public Vector4 tangent
	{
		get
		{
			return m_Tangent;
		}
		set
		{
			hasTangent = true;
			m_Tangent = value;
		}
	}

	public Vector2 uv0
	{
		get
		{
			return m_UV0;
		}
		set
		{
			hasUV0 = true;
			m_UV0 = value;
		}
	}

	public Vector2 uv2
	{
		get
		{
			return m_UV2;
		}
		set
		{
			hasUV2 = true;
			m_UV2 = value;
		}
	}

	public Vector4 uv3
	{
		get
		{
			return m_UV3;
		}
		set
		{
			hasUV3 = true;
			m_UV3 = value;
		}
	}

	public Vector4 uv4
	{
		get
		{
			return m_UV4;
		}
		set
		{
			hasUV4 = true;
			m_UV4 = value;
		}
	}

	public bool hasPosition
	{
		get
		{
			return (m_Attributes & VertexAttributes.Position) == VertexAttributes.Position;
		}
		private set
		{
			m_Attributes = (value ? (m_Attributes | VertexAttributes.Position) : (m_Attributes & ~VertexAttributes.Position));
		}
	}

	public bool hasColor
	{
		get
		{
			return (m_Attributes & VertexAttributes.Color) == VertexAttributes.Color;
		}
		private set
		{
			m_Attributes = (value ? (m_Attributes | VertexAttributes.Color) : (m_Attributes & ~VertexAttributes.Color));
		}
	}

	public bool hasNormal
	{
		get
		{
			return (m_Attributes & VertexAttributes.Normal) == VertexAttributes.Normal;
		}
		private set
		{
			m_Attributes = (value ? (m_Attributes | VertexAttributes.Normal) : (m_Attributes & ~VertexAttributes.Normal));
		}
	}

	public bool hasTangent
	{
		get
		{
			return (m_Attributes & VertexAttributes.Tangent) == VertexAttributes.Tangent;
		}
		private set
		{
			m_Attributes = (value ? (m_Attributes | VertexAttributes.Tangent) : (m_Attributes & ~VertexAttributes.Tangent));
		}
	}

	public bool hasUV0
	{
		get
		{
			return (m_Attributes & VertexAttributes.Texture0) == VertexAttributes.Texture0;
		}
		private set
		{
			m_Attributes = (value ? (m_Attributes | VertexAttributes.Texture0) : (m_Attributes & ~VertexAttributes.Texture0));
		}
	}

	public bool hasUV2
	{
		get
		{
			return (m_Attributes & VertexAttributes.Texture1) == VertexAttributes.Texture1;
		}
		private set
		{
			m_Attributes = (value ? (m_Attributes | VertexAttributes.Texture1) : (m_Attributes & ~VertexAttributes.Texture1));
		}
	}

	public bool hasUV3
	{
		get
		{
			return (m_Attributes & VertexAttributes.Texture2) == VertexAttributes.Texture2;
		}
		private set
		{
			m_Attributes = (value ? (m_Attributes | VertexAttributes.Texture2) : (m_Attributes & ~VertexAttributes.Texture2));
		}
	}

	public bool hasUV4
	{
		get
		{
			return (m_Attributes & VertexAttributes.Texture3) == VertexAttributes.Texture3;
		}
		private set
		{
			m_Attributes = (value ? (m_Attributes | VertexAttributes.Texture3) : (m_Attributes & ~VertexAttributes.Texture3));
		}
	}

	public bool HasArrays(VertexAttributes attribute)
	{
		return (m_Attributes & attribute) == attribute;
	}

	public void Flip()
	{
		if (hasNormal)
		{
			m_Normal *= -1f;
		}
		if (hasTangent)
		{
			m_Tangent *= -1f;
		}
	}
}
[Flags]
internal enum VertexAttributes
{
	Position = 1,
	Texture0 = 2,
	Texture1 = 4,
	Lightmap = 4,
	Texture2 = 8,
	Texture3 = 0x10,
	Color = 0x20,
	Normal = 0x40,
	Tangent = 0x80,
	All = 0xFF
}
internal static class VertexUtility
{
	public static void GetArrays(IList<Vertex> vertices, out Vector3[] position, out Color[] color, out Vector2[] uv0, out Vector3[] normal, out Vector4[] tangent, out Vector2[] uv2, out List<Vector4> uv3, out List<Vector4> uv4)
	{
		GetArrays(vertices, out position, out color, out uv0, out normal, out tangent, out uv2, out uv3, out uv4, VertexAttributes.All);
	}

	public static void GetArrays(IList<Vertex> vertices, out Vector3[] position, out Color[] color, out Vector2[] uv0, out Vector3[] normal, out Vector4[] tangent, out Vector2[] uv2, out List<Vector4> uv3, out List<Vector4> uv4, VertexAttributes attributes)
	{
		if (vertices == null)
		{
			throw new ArgumentNullException("vertices");
		}
		int count = vertices.Count;
		Vertex vertex = ((count < 1) ? default(Vertex) : vertices[0]);
		bool flag = (attributes & VertexAttributes.Position) == VertexAttributes.Position && vertex.hasPosition;
		bool flag2 = (attributes & VertexAttributes.Color) == VertexAttributes.Color && vertex.hasColor;
		bool flag3 = (attributes & VertexAttributes.Texture0) == VertexAttributes.Texture0 && vertex.hasUV0;
		bool flag4 = (attributes & VertexAttributes.Normal) == VertexAttributes.Normal && vertex.hasNormal;
		bool flag5 = (attributes & VertexAttributes.Tangent) == VertexAttributes.Tangent && vertex.hasTangent;
		bool flag6 = (attributes & VertexAttributes.Texture1) == VertexAttributes.Texture1 && vertex.hasUV2;
		bool flag7 = (attributes & VertexAttributes.Texture2) == VertexAttributes.Texture2 && vertex.hasUV3;
		bool flag8 = (attributes & VertexAttributes.Texture3) == VertexAttributes.Texture3 && vertex.hasUV4;
		position = (flag ? new Vector3[count] : null);
		color = (flag2 ? new Color[count] : null);
		uv0 = (flag3 ? new Vector2[count] : null);
		normal = (flag4 ? new Vector3[count] : null);
		tangent = (flag5 ? new Vector4[count] : null);
		uv2 = (flag6 ? new Vector2[count] : null);
		uv3 = (flag7 ? new List<Vector4>(count) : null);
		uv4 = (flag8 ? new List<Vector4>(count) : null);
		for (int i = 0; i < count; i++)
		{
			if (flag)
			{
				position[i] = vertices[i].position;
			}
			if (flag2)
			{
				color[i] = vertices[i].color;
			}
			if (flag3)
			{
				uv0[i] = vertices[i].uv0;
			}
			if (flag4)
			{
				normal[i] = vertices[i].normal;
			}
			if (flag5)
			{
				tangent[i] = vertices[i].tangent;
			}
			if (flag6)
			{
				uv2[i] = vertices[i].uv2;
			}
			if (flag7)
			{
				uv3.Add(vertices[i].uv3);
			}
			if (flag8)
			{
				uv4.Add(vertices[i].uv4);
			}
		}
	}

	public static Vertex[] GetVertices(this Mesh mesh)
	{
		if (mesh == null)
		{
			return null;
		}
		int vertexCount = mesh.vertexCount;
		Vertex[] array = new Vertex[vertexCount];
		Vector3[] vertices = mesh.vertices;
		Color[] colors = mesh.colors;
		Vector3[] normals = mesh.normals;
		Vector4[] tangents = mesh.tangents;
		Vector2[] uv = mesh.uv;
		Vector2[] uv2 = mesh.uv2;
		List<Vector4> list = new List<Vector4>();
		List<Vector4> list2 = new List<Vector4>();
		mesh.GetUVs(2, list);
		mesh.GetUVs(3, list2);
		bool flag = vertices != null && vertices.Length == vertexCount;
		bool flag2 = colors != null && colors.Length == vertexCount;
		bool flag3 = normals != null && normals.Length == vertexCount;
		bool flag4 = tangents != null && tangents.Length == vertexCount;
		bool flag5 = uv != null && uv.Length == vertexCount;
		bool flag6 = uv2 != null && uv2.Length == vertexCount;
		bool flag7 = list.Count == vertexCount;
		bool flag8 = list2.Count == vertexCount;
		for (int i = 0; i < vertexCount; i++)
		{
			array[i] = default(Vertex);
			if (flag)
			{
				array[i].position = vertices[i];
			}
			if (flag2)
			{
				array[i].color = colors[i];
			}
			if (flag3)
			{
				array[i].normal = normals[i];
			}
			if (flag4)
			{
				array[i].tangent = tangents[i];
			}
			if (flag5)
			{
				array[i].uv0 = uv[i];
			}
			if (flag6)
			{
				array[i].uv2 = uv2[i];
			}
			if (flag7)
			{
				array[i].uv3 = list[i];
			}
			if (flag8)
			{
				array[i].uv4 = list2[i];
			}
		}
		return array;
	}

	public static void SetMesh(Mesh mesh, IList<Vertex> vertices)
	{
		if (mesh == null)
		{
			throw new ArgumentNullException("mesh");
		}
		if (vertices == null)
		{
			throw new ArgumentNullException("vertices");
		}
		Vector3[] position = null;
		Color[] color = null;
		Vector2[] uv = null;
		Vector3[] normal = null;
		Vector4[] tangent = null;
		Vector2[] uv2 = null;
		List<Vector4> uv3 = null;
		List<Vector4> uv4 = null;
		GetArrays(vertices, out position, out color, out uv, out normal, out tangent, out uv2, out uv3, out uv4);
		mesh.Clear();
		Vertex vertex = vertices[0];
		if (vertex.hasPosition)
		{
			mesh.vertices = position;
		}
		if (vertex.hasColor)
		{
			mesh.colors = color;
		}
		if (vertex.hasUV0)
		{
			mesh.uv = uv;
		}
		if (vertex.hasNormal)
		{
			mesh.normals = normal;
		}
		if (vertex.hasTangent)
		{
			mesh.tangents = tangent;
		}
		if (vertex.hasUV2)
		{
			mesh.uv2 = uv2;
		}
		if (vertex.hasUV3 && uv3 != null)
		{
			mesh.SetUVs(2, uv3);
		}
		if (vertex.hasUV4 && uv4 != null)
		{
			mesh.SetUVs(3, uv4);
		}
	}

	public static Vertex Mix(this Vertex x, Vertex y, float weight)
	{
		float num = 1f - weight;
		Vertex result = new Vertex
		{
			position = x.position * num + y.position * weight
		};
		if (x.hasColor && y.hasColor)
		{
			result.color = x.color * num + y.color * weight;
		}
		else if (x.hasColor)
		{
			result.color = x.color;
		}
		else if (y.hasColor)
		{
			result.color = y.color;
		}
		if (x.hasNormal && y.hasNormal)
		{
			result.normal = x.normal * num + y.normal * weight;
		}
		else if (x.hasNormal)
		{
			result.normal = x.normal;
		}
		else if (y.hasNormal)
		{
			result.normal = y.normal;
		}
		if (x.hasTangent && y.hasTangent)
		{
			result.tangent = x.tangent * num + y.tangent * weight;
		}
		else if (x.hasTangent)
		{
			result.tangent = x.tangent;
		}
		else if (y.hasTangent)
		{
			result.tangent = y.tangent;
		}
		if (x.hasUV0 && y.hasUV0)
		{
			result.uv0 = x.uv0 * num + y.uv0 * weight;
		}
		else if (x.hasUV0)
		{
			result.uv0 = x.uv0;
		}
		else if (y.hasUV0)
		{
			result.uv0 = y.uv0;
		}
		if (x.hasUV2 && y.hasUV2)
		{
			result.uv2 = x.uv2 * num + y.uv2 * weight;
		}
		else if (x.hasUV2)
		{
			result.uv2 = x.uv2;
		}
		else if (y.hasUV2)
		{
			result.uv2 = y.uv2;
		}
		if (x.hasUV3 && y.hasUV3)
		{
			result.uv3 = x.uv3 * num + y.uv3 * weight;
		}
		else if (x.hasUV3)
		{
			result.uv3 = x.uv3;
		}
		else if (y.hasUV3)
		{
			result.uv3 = y.uv3;
		}
		if (x.hasUV4 && y.hasUV4)
		{
			result.uv4 = x.uv4 * num + y.uv4 * weight;
		}
		else if (x.hasUV4)
		{
			result.uv4 = x.uv4;
		}
		else if (y.hasUV4)
		{
			result.uv4 = y.uv4;
		}
		return result;
	}

	public static Vertex TransformVertex(this Transform transform, Vertex vertex)
	{
		Vertex result = default(Vertex);
		if (vertex.HasArrays(VertexAttributes.Position))
		{
			result.position = transform.TransformPoint(vertex.position);
		}
		if (vertex.HasArrays(VertexAttributes.Color))
		{
			result.color = vertex.color;
		}
		if (vertex.HasArrays(VertexAttributes.Normal))
		{
			result.normal = transform.TransformDirection(vertex.normal);
		}
		if (vertex.HasArrays(VertexAttributes.Tangent))
		{
			result.tangent = transform.rotation * vertex.tangent;
		}
		if (vertex.HasArrays(VertexAttributes.Texture0))
		{
			result.uv0 = vertex.uv0;
		}
		if (vertex.HasArrays(VertexAttributes.Texture1))
		{
			result.uv2 = vertex.uv2;
		}
		if (vertex.HasArrays(VertexAttributes.Texture2))
		{
			result.uv3 = vertex.uv3;
		}
		if (vertex.HasArrays(VertexAttributes.Texture3))
		{
			result.uv4 = vertex.uv4;
		}
		return result;
	}
}
internal static class CSG
{
	public enum BooleanOp
	{
		Intersection,
		Union,
		Subtraction
	}

	private const float k_DefaultEpsilon = 1E-05f;

	private static float s_Epsilon = 1E-05f;

	public static float epsilon
	{
		get
		{
			return s_Epsilon;
		}
		set
		{
			s_Epsilon = value;
		}
	}

	public static Model Perform(BooleanOp op, GameObject lhs, GameObject rhs)
	{
		return op switch
		{
			BooleanOp.Intersection => Intersect(lhs, rhs), 
			BooleanOp.Union => Union(lhs, rhs), 
			BooleanOp.Subtraction => Subtract(lhs, rhs), 
			_ => null, 
		};
	}

	public static Model Union(GameObject lhs, GameObject rhs)
	{
		Model model = new Model(lhs);
		Model model2 = new Model(rhs);
		Node a = new Node(model.ToPolygons());
		Node b = new Node(model2.ToPolygons());
		return new Model(Node.Union(a, b).AllPolygons());
	}

	public static Model Subtract(GameObject lhs, GameObject rhs)
	{
		Model model = new Model(lhs);
		Model model2 = new Model(rhs);
		Node a = new Node(model.ToPolygons());
		Node b = new Node(model2.ToPolygons());
		return new Model(Node.Subtract(a, b).AllPolygons());
	}

	public static Model Intersect(GameObject lhs, GameObject rhs)
	{
		Model model = new Model(lhs);
		Model model2 = new Model(rhs);
		Node a = new Node(model.ToPolygons());
		Node b = new Node(model2.ToPolygons());
		return new Model(Node.Intersect(a, b).AllPolygons());
	}
}
