using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using JetBrains.Annotations;
using UnityEngine;

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
			FilePathsData = new byte[190]
			{
				0, 0, 0, 1, 0, 0, 0, 35, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 108, 117, 103,
				105, 110, 115, 92, 77, 97, 116, 104, 71, 101,
				111, 76, 105, 98, 92, 76, 105, 110, 101, 51,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				39, 92, 65, 115, 115, 101, 116, 115, 92, 80,
				108, 117, 103, 105, 110, 115, 92, 77, 97, 116,
				104, 71, 101, 111, 76, 105, 98, 92, 77, 97,
				116, 114, 105, 120, 51, 88, 52, 46, 99, 115,
				0, 0, 0, 2, 0, 0, 0, 49, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 108, 117, 103,
				105, 110, 115, 92, 77, 97, 116, 104, 71, 101,
				111, 76, 105, 98, 92, 79, 114, 105, 101, 110,
				116, 101, 100, 66, 111, 117, 110, 100, 105, 110,
				103, 66, 111, 120, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 35, 92, 65, 115, 115, 101,
				116, 115, 92, 80, 108, 117, 103, 105, 110, 115,
				92, 77, 97, 116, 104, 71, 101, 111, 76, 105,
				98, 92, 80, 108, 97, 110, 101, 46, 99, 115
			},
			TypesData = new byte[151]
			{
				0, 0, 0, 0, 16, 77, 97, 116, 104, 71,
				101, 111, 76, 105, 98, 124, 76, 105, 110, 101,
				51, 0, 0, 0, 0, 20, 77, 97, 116, 104,
				71, 101, 111, 76, 105, 98, 124, 77, 97, 116,
				114, 105, 120, 51, 88, 52, 0, 0, 0, 0,
				30, 77, 97, 116, 104, 71, 101, 111, 76, 105,
				98, 124, 79, 114, 105, 101, 110, 116, 101, 100,
				66, 111, 117, 110, 100, 105, 110, 103, 66, 111,
				120, 0, 0, 0, 0, 44, 77, 97, 116, 104,
				71, 101, 111, 76, 105, 98, 46, 79, 114, 105,
				101, 110, 116, 101, 100, 66, 111, 117, 110, 100,
				105, 110, 103, 66, 111, 120, 124, 78, 97, 116,
				105, 118, 101, 77, 101, 116, 104, 111, 100, 115,
				0, 0, 0, 0, 16, 77, 97, 116, 104, 71,
				101, 111, 76, 105, 98, 124, 80, 108, 97, 110,
				101
			},
			TotalFiles = 4,
			TotalTypes = 5,
			IsEditorOnly = false
		};
	}
}
namespace MathGeoLib;

[PublicAPI]
public struct Line3(Vector3 point1, Vector3 point2)
{
	public readonly Vector3 Point1 = point1;

	public readonly Vector3 Point2 = point2;

	public override string ToString()
	{
		return string.Format("{0}: {1}, {2}: {3}", "Point1", Point1, "Point2", Point2);
	}
}
[PublicAPI]
public struct Matrix3X4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23)
{
	public readonly float M00 = m00;

	public readonly float M01 = m01;

	public readonly float M02 = m02;

	public readonly float M03 = m03;

	public readonly float M10 = m10;

	public readonly float M11 = m11;

	public readonly float M12 = m12;

	public readonly float M13 = m13;

	public readonly float M20 = m20;

	public readonly float M21 = m21;

	public readonly float M22 = m22;

	public readonly float M23 = m23;

	public override string ToString()
	{
		return string.Format("{0}: {1}, ", "M00", M00) + string.Format("{0}: {1}, ", "M01", M01) + string.Format("{0}: {1}, ", "M02", M02) + string.Format("{0}: {1}, ", "M03", M03) + string.Format("{0}: {1}, ", "M10", M10) + string.Format("{0}: {1}, ", "M11", M11) + string.Format("{0}: {1}, ", "M12", M12) + string.Format("{0}: {1}, ", "M13", M13) + string.Format("{0}: {1}, ", "M20", M20) + string.Format("{0}: {1}, ", "M21", M21) + string.Format("{0}: {1}, ", "M22", M22) + string.Format("{0}: {1}", "M23", M23);
	}
}
[Serializable]
[StructLayout(LayoutKind.Sequential)]
[PublicAPI]
public sealed class OrientedBoundingBox
{
	private static class NativeMethods
	{
		private const string DllName = "MathGeoLib.Exports.dll";

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern void obb_optimal_enclosing(Vector3[] points, int numPoints, out Vector3 center, out Vector3 extent, [In][Out] Vector3[] axis);

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern void obb_brute_enclosing(Vector3[] points, int numPoints, out Vector3 center, out Vector3 extent, [In][Out] Vector3[] axis);

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern void obb_enclose([In][Out] OrientedBoundingBox box, Vector3 point);

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern void obb_point_inside([In][Out] OrientedBoundingBox box, float x, float y, float z, out Vector3 point);

		[DllImport("MathGeoLib.Exports.dll")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool obb_contains([In][Out] OrientedBoundingBox box, Vector3 point);

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern void obb_corner_point([In][Out] OrientedBoundingBox box, int index, out Vector3 point);

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern void obb_face_point([In][Out] OrientedBoundingBox box, int index, float u, float v, out Vector3 point);

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern int obb_num_faces();

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern int obb_num_edges();

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern int obb_num_vertices();

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern void obb_scale([In][Out] OrientedBoundingBox box, Vector3 center, Vector3 factor);

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern void obb_translate([In][Out] OrientedBoundingBox box, Vector3 offset);

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern float obb_distance([In][Out] OrientedBoundingBox box, Vector3 point);

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern void obb_point_on_edge([In][Out] OrientedBoundingBox box, int index, float u, out Vector3 point);

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern void obb_edge([In][Out] OrientedBoundingBox box, int index, out Line3 segment);

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern void obb_world_to_local([In][Out] OrientedBoundingBox box, out Matrix3X4 local);

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern void obb_local_to_world([In][Out] OrientedBoundingBox box, out Matrix3X4 world);

		[DllImport("MathGeoLib.Exports.dll")]
		public static extern void obb_face_plane([In][Out] OrientedBoundingBox box, int index, out Plane plane);
	}

	public Vector3 Center;

	public Vector3 Extent;

	public Vector3 Axis1;

	public Vector3 Axis2;

	public Vector3 Axis3;

	public static int NumEdges => NativeMethods.obb_num_edges();

	public static int NumFaces => NativeMethods.obb_num_faces();

	public static int NumVertices => NativeMethods.obb_num_vertices();

	[PublicAPI]
	public OrientedBoundingBox()
	{
	}

	public OrientedBoundingBox(Vector3 center, Vector3 extent, Vector3 axis1, Vector3 axis2, Vector3 axis3)
	{
		Center = center;
		Extent = extent;
		Axis1 = axis1;
		Axis2 = axis2;
		Axis3 = axis3;
	}

	public static OrientedBoundingBox OptimalEnclosing(Vector3[] points)
	{
		Vector3[] array = new Vector3[3];
		NativeMethods.obb_optimal_enclosing(points, points.Length, out var center, out var extent, array);
		return new OrientedBoundingBox(center, extent, array[0], array[1], array[2]);
	}

	public static OrientedBoundingBox BruteEnclosing(Vector3[] points)
	{
		Vector3[] array = new Vector3[3];
		NativeMethods.obb_brute_enclosing(points, points.Length, out var center, out var extent, array);
		return new OrientedBoundingBox(center, extent, array[0], array[1], array[2]);
	}

	public bool Contains(Vector3 point)
	{
		return NativeMethods.obb_contains(this, point);
	}

	public Vector3 CornerPoint(int index)
	{
		NativeMethods.obb_corner_point(this, index, out var point);
		return point;
	}

	public void Enclose(Vector3 point)
	{
		NativeMethods.obb_enclose(this, point);
	}

	public Vector3 FacePoint(int index, float u, float v)
	{
		NativeMethods.obb_face_point(this, index, u, v, out var point);
		return point;
	}

	public Vector3 PointInside(float x, float y, float z)
	{
		NativeMethods.obb_point_inside(this, x, y, z, out var point);
		return point;
	}

	public void Scale(Vector3 center, Vector3 factor)
	{
		NativeMethods.obb_scale(this, center, factor);
	}

	public void Translate(Vector3 offset)
	{
		NativeMethods.obb_translate(this, offset);
	}

	public float Distance(Vector3 point)
	{
		return NativeMethods.obb_distance(this, point);
	}

	public Vector3 PointOnEdge(int index, float u)
	{
		NativeMethods.obb_point_on_edge(this, index, u, out var point);
		return point;
	}

	public Line3 Edge(int index)
	{
		NativeMethods.obb_edge(this, index, out var segment);
		return segment;
	}

	public Matrix3X4 WorldToLocal()
	{
		NativeMethods.obb_world_to_local(this, out var local);
		return local;
	}

	public Matrix3X4 LocalToWorld()
	{
		NativeMethods.obb_local_to_world(this, out var world);
		return world;
	}

	public Plane FacePlane(int index)
	{
		NativeMethods.obb_face_plane(this, index, out var plane);
		return plane;
	}

	public override string ToString()
	{
		return string.Format("{0}: {1}, {2}: {3}", "Center", Center, "Extent", Extent);
	}
}
[PublicAPI]
public struct Plane(Vector3 normal, float distance)
{
	public readonly Vector3 Normal = normal;

	public readonly float Distance = distance;

	public override string ToString()
	{
		return string.Format("{0}: {1}, {2}: {3}", "Normal", Normal, "Distance", Distance);
	}
}
